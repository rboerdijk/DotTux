/*
 * Copyright 2003, 2004 OTP Systems Oy. All rights reserved.
 */

using DotTux;
using DotTux.Atmi;

namespace DotTux.Atmi
{
    /// <summary>
    /// Provides methods for managing the client side of a conversation.
    /// </summary>
    /// 
    /// <remarks>
    /// A Conversation object wraps a conversational connection, allowing it to be
    /// treated as regular .NET resource. 
    /// This means that the initiator can manage a conversation using the 
    /// well-known try/finally pattern: 
    /// <code>
    /// Conversation conv = new Conversation(...);
    /// try {
    ///     ... // Send and receive messages using conv.Send() and conv.Receive()
    /// } finally {
    ///     conv.Close();
    /// }
    /// </code>
    /// A Conversation tracks the state of the conversation: terminated by the server or not. 
    /// If a Conversation is closed before the server has terminated the conversation 
    /// then the <see cref="Close"/> method performs an abortive disconnect. 
    /// Otherwise, the <see cref="Close"/> method does nothing.
    /// </remarks>

    public class Conversation
    {
	private int cd;

        /// <summary>
        /// Initializes a new Conversation by establishing a connection with a conversational Tuxedo service. 
        /// </summary>
        /// 
        /// <param name="svc">
        /// The name of the Tuxedo service.
        /// </param>
        /// 
        /// <param name="message">
        /// A typed buffer containing the message to send along with the connect request; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="message"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// Must contain either TPSENDONLY or TPRECVONLY.
        /// See the Tuxedo tpconnect(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpconnect(3c) manual page.
        /// </exception>
        /// 
        /// <seealso cref="ATMI.tpconnect"/>.

	public Conversation(string svc, ByteBuffer message, int len, int flags)
	{
	    cd = ATMI.tpconnect(svc, message, len, flags);
	}

        /// <summary>
        /// Sends a message as part of the conversation.
        /// </summary>
        /// 
        /// <param name="message">
        /// A typed buffer containing the message to send; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="message"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// Set TPRECVONLY to give up control of the conversation.
        /// See the Tuxedo tpsend(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsend(3c) manual page.
        /// </exception>
        /// 
        /// <seealso cref="ATMI.tpsend"/>.

        public void Send(ByteBuffer message, int len, int flags)
	{
	    try {
		ATMI.tpsend(cd, message, len, flags);
	    } catch (TPEEVENT eEvent) {
		cd = -1;
		throw eEvent;
	    }
	}


        /// <summary>
        /// Receives a message as part of a conversation.
        /// </summary>
        /// 
        /// <param name="messageRef">
        /// A typed buffer allocated using <see cref="ATMI.tpalloc"/>.
        /// Gets updated with a typed buffer containing the message received
        /// a part of the conversation.
        /// </param>
        ///
        /// <param name="lenOut">
        /// Gets updated with the length of the data in <paramref name="messageRef"/>.
        /// If the length is 0 then a null message was received.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tprecv(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="DotTux.Atmi.TPEV_SENDONLY">
        /// The other end of the connection has given up control of the conversation. 
        /// </exception>
        /// 
        /// <exception cref="DotTux.Atmi.TPEV_SVCSUCC">
        /// The service routine returned successfully. 
        /// In this case, <paramref name="messageRef"/> and <paramref name="lenOut"/>
        /// are updated as described above.
        /// </exception>
        /// 
        /// <exception cref="DotTux.Atmi.TPEV_SVCFAIL">
        /// The service routine returned with an application level service failure. 
        /// In this case, <paramref name="messageRef"/> and <paramref name="lenOut"/>
        /// are updated as described above.
        /// </exception>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tprecv(3c) manual page.
        /// </exception>
        /// 
        /// <seealso cref="ATMI.tprecv"/>

	public void Receive(ref ByteBuffer messageRef, out int lenOut, int flags)
	{
	    try {
		ATMI.tprecv(cd, ref messageRef, out lenOut, flags);
	    } catch (TPEV_SENDONLY eSendOnly) {
		throw eSendOnly;
	    } catch (TPEEVENT eEvent) {
		cd = -1;
		throw eEvent;
	    }
	}

        /// <summary>
        /// Closes the conversation. 
        /// </summary>
        /// 
        /// <remarks>
        /// If the conversation has not terminated at the time this method is called 
        /// then the conversation is aborted. 
        /// </remarks>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpdiscon(3c) manual page.
        /// </exception>
        /// 
        /// <seealso cref="ATMI.tpdiscon"/>

	public void Close()
	{
	    if (cd != -1) {
		ATMI.tpdiscon(cd);
		cd = -1;
	    }
	}
    }
}
