/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Text;

using DotTux;

namespace DotTux.Atmi
{
    /// <summary>
    /// Delegate type for unsolicited message handlers.
    /// </summary>

    public delegate void UnsolHandler(ByteBuffer data, int len, int flags);

    /// <summary>
    /// Provides methods and constants for executing ATMI system calls.
    /// </summary>

    public class ATMI
    {
	private ATMI() 
	{
	    // Nothing to do, just make sure it is not public.
	}

	// The symbol table below was generated using OTPTuxSymbolDumper

	/// <summary>ATMI system call flag</summary>
	public const int TPNOFLAGS = 0x0;

	/// <summary>ATMI system call flag</summary>
	public const int TPNOBLOCK = 0x1;

	/// <summary>ATMI system call flag</summary>
	public const int TPSIGRSTRT = 0x2;

	/// <summary>ATMI system call flag</summary>
	public const int TPNOREPLY = 0x4;

	/// <summary>ATMI system call flag</summary>
	public const int TPNOTRAN = 0x8;

	/// <summary>ATMI system call flag</summary>
	public const int TPTRAN = 0x10;

	/// <summary>ATMI system call flag</summary>
	public const int TPNOTIME = 0x20;

	/// <summary>ATMI system call flag</summary>
	public const int TPABSOLUTE = 0x40;

	/// <summary>ATMI system call flag</summary>
	public const int TPGETANY = 0x80;

	/// <summary>ATMI system call flag</summary>
	public const int TPNOCHANGE = 0x100;

	/// <summary>ATMI system call flag</summary>
	public const int TPCONV = 0x400;

	/// <summary>ATMI system call flag</summary>
	public const int TPSENDONLY = 0x800;

	/// <summary>ATMI system call flag</summary>
	public const int TPRECVONLY = 0x1000;

	/// <summary>ATMI system call flag</summary>
	public const int TPACK = 0x2000;

#if WSCLIENT
        /* Skip service routine return values */
#else
	/// <summary>Return value for service routines</summary>
	public const int TPFAIL = 0x1;

	/// <summary>Return value for service routines</summary>
	public const int TPEXIT = 0x8000000;

	/// <summary>Return value for service routines</summary>
	public const int TPSUCCESS = 0x2;
#endif

	/// <summary>Possible TP_COMMIT_CONTROL value</summary>
	public const int TP_CMT_LOGGED = 1;

	/// <summary>Possible TP_COMMIT_CONTROL value</summary>
	public const int TP_CMT_COMPLETE = 2;

	/// <summary>Unsolicited notification mode</summary>
	public const int TPU_MASK = 0x47;

	/// <summary>Unsolicited notification mode</summary>
	public const int TPU_SIG = 0x1;

	/// <summary>Unsolicited notification mode</summary>
	public const int TPU_DIP = 0x2;

	/// <summary>Unsolicited notification mode</summary>
	public const int TPU_IGN = 0x4;

	/// <summary>Unsolicited notification mode</summary>
	public const int TPU_THREAD = 0x40;

	/// <summary>System access mode</summary>
	public const int TPSA_FASTPATH = 0x8;

	/// <summary>System access mode</summary>
	public const int TPSA_PROTECTED = 0x10;

	/// <summary>Multicontexts mode</summary>
	public const int TPMULTICONTEXTS = 0x20;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQCORRID = 0x1;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQFAILUREQ = 0x2;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQBEFOREMSGID = 0x4;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQMSGID = 0x10;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQPRIORITY = 0x20;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQTOP = 0x40;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQWAIT = 0x80;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQREPLYQ = 0x100;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQTIME_ABS = 0x200;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQTIME_REL = 0x400;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQPEEK = 0x1000;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQDELIVERYQOS = 0x2000;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQREPLYQOS = 0x4000;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQEXPTIME_ABS = 0x8000;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQEXPTIME_REL = 0x10000;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQEXPTIME_NONE = 0x20000;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQGETBYMSGID = 0x40008;

	/// <summary>Tuxedo/Q flag</summary>
	public const int TPQGETBYCORRID = 0x80800;

	/// <summary>Tuxedo/Q QoS</summary>
	public const int TPQQOSDEFAULTPERSIST = 1;

	/// <summary>Tuxedo/Q QoS</summary>
	public const int TPQQOSPERSISTENT = 2;

	/// <summary>Tuxedo/Q QoS</summary>
	public const int TPQQOSNONPERSISTENT = 4;

	/// <summary>ATMI error code</summary>
	public const int TPEABORT = 1;

	/// <summary>ATMI error code</summary>
	public const int TPEBADDESC = 2;

	/// <summary>ATMI error code</summary>
	public const int TPEBLOCK = 3;

	/// <summary>ATMI error code</summary>
	public const int TPEINVAL = 4;

	/// <summary>ATMI error code</summary>
	public const int TPELIMIT = 5;

	/// <summary>ATMI error code</summary>
	public const int TPENOENT = 6;

	/// <summary>ATMI error code</summary>
	public const int TPEOS = 7;

	/// <summary>ATMI error code</summary>
	public const int TPEPERM = 8;

	/// <summary>ATMI error code</summary>
	public const int TPEPROTO = 9;

	/// <summary>ATMI error code</summary>
	public const int TPESVCERR = 10;

	/// <summary>ATMI error code</summary>
	public const int TPESVCFAIL = 11;

	/// <summary>ATMI error code</summary>
	public const int TPESYSTEM = 12;

	/// <summary>ATMI error code</summary>
	public const int TPETIME = 13;

	/// <summary>ATMI error code</summary>
	public const int TPETRAN = 14;

	/// <summary>ATMI error code</summary>
	public const int TPGOTSIG = 15;

	/// <summary>ATMI error code</summary>
	public const int TPERMERR = 16;

	/// <summary>ATMI error code</summary>
	public const int TPEITYPE = 17;

	/// <summary>ATMI error code</summary>
	public const int TPEOTYPE = 18;

	/// <summary>ATMI error code</summary>
	public const int TPERELEASE = 19;

	/// <summary>ATMI error code</summary>
	public const int TPEHAZARD = 20;

	/// <summary>ATMI error code</summary>
	public const int TPEHEURISTIC = 21;

	/// <summary>ATMI error code</summary>
	public const int TPEEVENT = 22;

	/// <summary>ATMI error code</summary>
	public const int TPEMATCH = 23;

	/// <summary>ATMI error code</summary>
	public const int TPEDIAGNOSTIC = 24;

	/// <summary>ATMI error code</summary>
	public const int TPEMIB = 25;

	/// <summary>Conversational event code</summary>
	public const int TPEV_DISCONIMM = 1;

	/// <summary>Conversational event code</summary>
	public const int TPEV_SVCERR = 2;

	/// <summary>Conversational event code</summary>
	public const int TPEV_SVCFAIL = 4;

	/// <summary>Conversational event code</summary>
	public const int TPEV_SVCSUCC = 8;

	/// <summary>Conversational event code</summary>
	public const int TPEV_SENDONLY = 32;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEINVAL = -1;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEBADRMID = -2;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMENOTOPEN = -3;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMETRAN = -4;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEBADMSGID = -5;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMESYSTEM = -6;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEOS = -7;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEABORTED = -8;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMENOTA = -8;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEPROTO = -9;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEBADQUEUE = -10;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMENOMSG = -11;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEINUSE = -12;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMENOSPACE = -13;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMERELEASE = -14;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMEINVHANDLE = -15;

	/// <summary>Tuxedo/Q error code</summary>
	public const int QMESHARE = -16;

	/// <summary>Event broker flag</summary>
	public const int TPEVSERVICE = 1;

	/// <summary>Event broker flag</summary>
	public const int TPEVQUEUE = 2;

	/// <summary>Event broker flag</summary>
	public const int TPEVTRAN = 4;

	/// <summary>Event broker flag</summary>
	public const int TPEVPERSIST = 8;

	/// <summary>Authentication level</summary>
	public const int TPNOAUTH = 0;

	/// <summary>Authentication level</summary>
	public const int TPSYSAUTH = 1;

	/// <summary>Authentication level</summary>
	public const int TPAPPAUTH = 2;

	/// <summary>Context identifier</summary>
	public const int TPSINGLECONTEXT = 0;

	/// <summary>Context identifier</summary>
	public const int TPNULLCONTEXT = -2;

	/// <summary>Context identifier</summary>
	public const int TPINVALIDCONTEXT = -1;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_CLIENTDISCONNECTED = 6;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_DECRYPTION_FAILURE = 11;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_DOMAINUNREACHABLE = 5;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_INVALID_CERTIFICATE = 9;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_INVALID_SIGNATURE = 10;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_INVALIDCONTEXT = 12;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_INVALID_XA_TRANSACTION = 13;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_NOCLIENT = 4;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_NOUNSOLHANDLER = 3;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_SVCTIMEOUT = 1;

	/// <summary>ATMI error detail code</summary>
	public const int TPED_TERM = 2;

        /// <summary>Remove encoding flag</summary>
        public const int RM_ENC = 0x1;

	internal static int tperrno()
	{
	    return DotTuxInterop.get_tperrno();
	}

	internal static string tpstrerror(int err)
	{
	    IntPtr str = DotTuxInterop.tpstrerror(err);
	    if (str == IntPtr.Zero) {
		return null;
	    } else {
	        return Marshal.PtrToStringAnsi(str);
	    }
	}

	/*
	 * The "Introduction to the C language ATMI interface" document
	 * states that tperrno is not reset by successful calls.
	 * Unfortunately, this is not the case in practice. The tptypes()
	 * call below will actually reset tperrno to 0. We must therefore
	 * be careful to save tperrno before calling this method if
	 * necessary.
	 */

	static ByteBuffer NewTypedBuffer(IntPtr data)
	{
	    int size = DotTuxInterop.tptypes(data, null, null);
	    if (size == -1) {
		throw new InvalidOperationException("tptypes() failed "
		    + "on buffer returned by Tuxedo");
	    }
	    return new ByteBuffer(data, size);
	}

	static TPException NewTPException(int err)
	{
	    switch (err) {
		case ATMI.TPEABORT:
		    return new TPEABORT();
		case ATMI.TPEBADDESC:
		    return new TPEBADDESC();
		case ATMI.TPEBLOCK:
		    return new TPEBLOCK();
		case ATMI.TPEINVAL:
		    return new TPEINVAL();
		case ATMI.TPELIMIT:
		    return new TPELIMIT();
		case ATMI.TPENOENT:
		    return new TPENOENT();
		case ATMI.TPEOS:
		    return new TPEOS();
		case ATMI.TPEPERM:
		    return new TPEPERM();
		case ATMI.TPEPROTO:
		    return new TPEPROTO();
		case ATMI.TPESVCERR:
		    return new TPESVCERR();
		case ATMI.TPESVCFAIL:
		    return new TPESVCFAIL();
		case ATMI.TPESYSTEM:
		    return new TPESYSTEM();
		case ATMI.TPETIME:
		    return new TPETIME();
		case ATMI.TPETRAN:
		    return new TPETRAN();
		case ATMI.TPGOTSIG:
		    return new TPGOTSIG();
		case ATMI.TPERMERR:
		    return new TPERMERR();
		case ATMI.TPEITYPE:
		    return new TPEITYPE();
		case ATMI.TPEOTYPE:
		    return new TPEOTYPE();
		case ATMI.TPERELEASE:
		    return new TPERELEASE();
		case ATMI.TPEHAZARD:
		    return new TPEHAZARD();
		case ATMI.TPEHEURISTIC:
		    return new TPEHEURISTIC();
		case ATMI.TPEMATCH:
		    return new TPEMATCH();
		case ATMI.TPEMIB:
		    return new TPEMIB();
		default:
		    return new TPException(err);
	    }
	}

	static TPException NewTPException()
	{
	    return NewTPException(tperrno());
	}

	static TPEEVENT NewTPEEVENT(int ev)
	{
	    switch (ev) {
		case ATMI.TPEV_DISCONIMM:
		    return new TPEV_DISCONIMM();
		case ATMI.TPEV_SVCERR:
		    return new TPEV_SVCERR();
		case ATMI.TPEV_SVCFAIL:
		    return new TPEV_SVCFAIL();
		case ATMI.TPEV_SVCSUCC:
		    return new TPEV_SVCSUCC();
		case ATMI.TPEV_SENDONLY:
		    return new TPEV_SENDONLY();
		default:
		    return new TPEEVENT(ev);
	    }
	}

	static TPEDIAGNOSTIC NewTPEDIAGNOSTIC(int diagnostic)
	{
	    switch (diagnostic)
	    {
		case ATMI.QMEINVAL:
		    return new QMEINVAL();
		case ATMI.QMEBADRMID:
		    return new QMEBADRMID();
		case ATMI.QMENOTOPEN:
		    return new QMENOTOPEN();
		case ATMI.QMETRAN:
		    return new QMETRAN();
		case ATMI.QMEBADMSGID:
		    return new QMEBADMSGID();
		case ATMI.QMESYSTEM:
		    return new QMESYSTEM();
		case ATMI.QMEOS:
		    return new QMEOS();
		case ATMI.QMEABORTED:
		    return new QMEABORTED();
		case ATMI.QMEPROTO:
		    return new QMEPROTO();
		case ATMI.QMEBADQUEUE:
		    return new QMEBADQUEUE();
		case ATMI.QMENOMSG:
		    return new QMENOMSG();
		case ATMI.QMEINUSE:
		    return new QMEINUSE();
		case ATMI.QMENOSPACE:
		    return new QMENOSPACE();
		case ATMI.QMERELEASE:
		    return new QMERELEASE();
		case ATMI.QMEINVHANDLE:
		    return new QMEINVHANDLE();
		case ATMI.QMESHARE:
		    return new QMESHARE();
		default:
		    return new TPEDIAGNOSTIC(diagnostic);
	    }
	}

        /// <summary>
        /// Returns the application specific return code of the last 
        /// service invocation.
        /// </summary>
        /// 
        /// <returns>
        /// The application specific return code of the last 
        /// service invocation.
        /// </returns>

        public static int tpurcode()
	{
	    return DotTuxInterop.get_tpurcode();
	}

        /// <summary>
        /// Allocates a typed buffer. 
        /// </summary>
        /// 
        /// <param name="type">
        /// The type of the typed buffer; must not be null.
        /// </param>
        /// 
        /// <param name="subtype">
        /// The subtype of the typed buffer; may be null.
        /// </param>
        /// 
        /// <param name="size">
        /// The size of the typed buffer.
        /// </param>
        /// 
        /// <returns>
        /// The newly allocated typed buffer.
        /// </returns>
        /// 
        /// <remarks>
        /// The returned buffer must be freed using <see cref="tpfree"/> 
        /// when no longer used.
        /// </remarks>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpalloc(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to allocate a typed
        /// buffer and how to make sure that it gets freed when it is not
        /// used anymore.
        /// <code>
        /// ByteBuffer buffer = ATMI.tpalloc("STRING", null, 1024);
        /// try {
        ///     ... // Use buffer
        /// } finally {
        ///     ATMI.tpfree(buffer);
        /// }
        /// </code>
        /// </example>

	public static ByteBuffer tpalloc(string type, string subtype, 
	    int size)
	{
	    IntPtr data = DotTuxInterop.tpalloc(type, subtype, size);
	    if (data == IntPtr.Zero) {
		throw NewTPException();
	    }
	    return NewTypedBuffer(data);
	}

        /// <summary>
        /// Returns the type and size of a typed buffer. 
        /// </summary>
        /// 
        /// <param name="buffer">
        /// The typed buffer; must have been allocated using <see cref="tpalloc"/>.
        /// </param>
        /// 
        /// <param name="typeOut">
        /// Gets updated with the type of the typed buffer.
        /// </param>
        /// 
        /// <returns>
        /// The size of the typed buffer.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tptypes(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to get the
        /// type and size of a typed buffer. 
        /// <code>
        /// ByteBuffer buffer = ...;
        /// string type;
        /// int size = ATMI.tptypes(buffer, out type);
        /// Console.WriteLine("type=" + type);
        /// Console.WriteLine("size=" + size);
        /// </code>
        /// </example>

	public static int tptypes(ByteBuffer buffer, out string typeOut)
	{
            IntPtr ptr = (buffer == null) ? IntPtr.Zero : buffer.ptr;

	    StringBuilder typeBuilder = new StringBuilder(8);

	    int result = DotTuxInterop.tptypes(ptr, typeBuilder, null);
	    if (result == -1) {
		throw NewTPException();
	    }

	    typeOut = typeBuilder.ToString();

	    return result;
	}

        /// <summary>
        /// Returns the type, subtype and size of a typed buffer. 
        /// </summary>
        /// 
        /// <param name="buffer">
        /// The typed buffer; must have been allocated using <see cref="tpalloc"/>.
        /// </param>
        /// 
        /// <param name="typeOut">
        /// Gets updated with the type of the typed buffer.
        /// </param>
        /// 
        /// <param name="subtypeOut">
        /// Gets updated with the subtype of the typed buffer.
        /// </param>
        /// 
        /// <returns>
        /// The size of the typed buffer.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tptypes(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to get the
        /// type, subtype and size of a typed buffer. 
        /// <code>
        /// ByteBuffer buffer = ...;
        /// string type;
        /// strint subtype;
        /// int size = ATMI.tptypes(buffer, out type, out subtype);
        /// Console.WriteLine("type=" + type);
        /// Console.WriteLine("subtype=" + subtype);
        /// Console.WriteLine("size=" + size);
        /// </code>
        /// </example>
 
	public static int tptypes(ByteBuffer buffer, out string typeOut,
	    out string subtypeOut)
	{
            IntPtr ptr = (buffer == null) ? IntPtr.Zero : buffer.ptr;

	    StringBuilder typeBuilder = new StringBuilder(8);

	    StringBuilder subtypeBuilder = new StringBuilder(16);

	    int result = DotTuxInterop.tptypes(ptr, typeBuilder, 
		subtypeBuilder);
	    if (result == -1) {
		throw NewTPException();
	    }

	    typeOut = typeBuilder.ToString();

	    subtypeOut = subtypeBuilder.ToString();

	    return result;
	}

        /// <summary>
        /// Reallocates a typed buffer. 
        /// </summary>
        /// 
        /// <param name="buffer">
        /// The typed buffer; must have been allocated using <see cref="tpalloc"/>.
        /// </param>
        /// 
        /// <param name="newSize">
        /// The new size of the buffer.
        /// </param>
        /// 
        /// <returns>
        /// The reallocated buffer.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tprealloc(3c) manual page.
        /// </exception>

        public static ByteBuffer tprealloc(ByteBuffer buffer, int newSize)
	{
            IntPtr ptr = (buffer == null) ? IntPtr.Zero : buffer.ptr;

	    IntPtr data = DotTuxInterop.tprealloc(ptr, newSize);
	    if (data == IntPtr.Zero) {
		throw NewTPException();
	    }

	    return NewTypedBuffer(data);
	}
	
        /// <summary>
        /// Frees a typed buffer. 
        /// </summary>
        /// 
        /// <param name="buffer">
        /// The typed buffer; must have been allocated using <see cref="tpalloc"/>.
        /// </param>

        public static void tpfree(ByteBuffer buffer)
	{
            IntPtr ptr = (buffer == null) ? IntPtr.Zero : buffer.ptr;

	    DotTuxInterop.tpfree(ptr);
	}

#if WSCLIENT
	/* Skip tpadmcall() */
#else
        /// <summary>
        /// Peforms an administrative Tuxedo operation. 
        /// </summary>
        /// 
        /// <param name="request">
        /// A typed buffer of type FML32 containing the administrative request.
        /// </param>
        /// 
        /// <param name="replyRef">
        /// A typed buffer of type FML32 allocated using <see cref="tpalloc"/>.
        /// Gets updated with a buffer containing the reply received in response 
        /// to the administrative request.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpadmcall(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="DotTux.Atmi.TPEMIB">
        /// The administrative request failed. 
        /// In this case, <paramref name="replyRef"/> is updated as described above.
        /// </exception>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpadmcall(3c) manual page.
        /// </exception>

        public static void tpadmcall(ByteBuffer request, ref ByteBuffer replyRef,
	    int flags)
	{
	    IntPtr requestPtr = (request == null) ? IntPtr.Zero : request.ptr;

	    IntPtr replyRefPtr = (replyRef == null) ? IntPtr.Zero : replyRef.ptr;

	    if (DotTuxInterop.tpadmcall(requestPtr, ref replyRefPtr, 
		    flags) == -1) {
		if (tperrno() == TPEMIB) {
	            replyRef = NewTypedBuffer(replyRefPtr); // resets tperrno (!)
		    throw NewTPException(TPEMIB);
		}
		throw NewTPException();
	    }

	    replyRef = NewTypedBuffer(replyRefPtr);
	}
#endif

        /// <summary>
        /// Returns the application context of the current thread. 
        /// </summary>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpgetctxt(3c) manual page.
        /// </param>
        /// 
        /// <returns>
        /// The application context of the current thread.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpgetctxt(3c) manual page.
        /// </exception>

	public static int tpgetctxt(int flags)
	{
	    int context;
	    if (DotTuxInterop.tpgetctxt(out context, flags) == -1) {
		throw NewTPException();
	    }
	    return context;
	}

        /// <summary>
        /// Sets the application context of the current thread. 
        /// </summary>
        /// 
        /// <param name="ctxt">
        /// The application context to set.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpsetctxt(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsetctxt(3c) manual page.
        /// </exception>

	public static void tpsetctxt(int ctxt, int flags)
	{
	    if (DotTuxInterop.tpsetctxt(ctxt, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Returns the authentication level required to join the application. 
        /// </summary>
        /// 
        /// <returns>
        /// The authentication level required to join the application.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpchkauth(3c) manual page.
        /// </exception>

        public static int tpchkauth()
	{
	    int result = DotTuxInterop.tpchkauth();
	    if (result == -1) {
		throw NewTPException();
	    }
	    return result;
	}

	private static Hashtable unsolHandlers = new Hashtable();

	private static void tpunsol(IntPtr data, int len, int flags)
	{
	    try {
	        int ctxt = tpgetctxt(0);

	        UnsolHandler handler;

	        lock (unsolHandlers) {
	            if (!unsolHandlers.ContainsKey(ctxt)) { // No handler
	                throw new InvalidOperationException(
			    "DotTux.Atmi.ATMI.tpunsol() called "
			    + " but no handler in this context");
	            }
	            handler = (UnsolHandler) unsolHandlers[ctxt];
	            if (handler == null) { // NULL handler
	                throw new InvalidOperationException(
			    "DotTux.Atmi.ATMI.tpunsol() called "
		            + "but handler in this context is null");
	            }
		}

	        handler(NewTypedBuffer(data), len, flags);

	    } catch (Exception e) {
	        TUX.userlog("ERROR: Exception handling unsolicited message:");
		TUX.userlog(e.ToString());
	    }
	}

	private static DotTuxInterop.NativeUnsolHandler nativeUnsolHandler
	    = new DotTuxInterop.NativeUnsolHandler(tpunsol);

	private static UnsolHandler perProcessDefaultUnsolHandler = null;

        /// <summary>
        /// Sets the unsolicited message handler of the current application 
        /// context.
        /// </summary>
        /// 
        /// <param name="handler">
        /// The unsolicited message handler to set; may be null.
        /// </param>
        /// 
        /// <returns>
        /// The previous unsolicited message handler of the current application 
        /// context; may be null.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsetunsol(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to set the unsolicited
        /// message handler of the current application context:
        /// <code>
        /// static void MyUsol(ByteBuffer data, int len, int flags)
        /// {
        ///     ... // Handle unsolicited message
        /// }
        /// 
        /// ATMI.tpsetunsol(new UnsolHandler(MyUnsol));
        /// </code>
        /// </example>

        public static UnsolHandler tpsetunsol(UnsolHandler handler)
	{
	    DotTuxInterop.NativeUnsolHandler unsol = (handler == null) ? null
		: nativeUnsolHandler;

	    if (DotTuxInterop.tpsetunsol(unsol) == -1) {
		throw NewTPException();
	    }

	    int ctxt = tpgetctxt(0);

	    if (ctxt == TPNULLCONTEXT) {
		UnsolHandler oldHandler = perProcessDefaultUnsolHandler;
		perProcessDefaultUnsolHandler = handler;
		return oldHandler;
	    } else {
		lock (unsolHandlers) {
		    UnsolHandler oldHandler = (UnsolHandler)
		       	unsolHandlers[ctxt];
		    // handler == null means NULL handler, not no handler (!)
		    unsolHandlers[ctxt] = handler;
		    return oldHandler;
		}
	    }
	}

        /// <summary>
        /// Logs a client on to a running Tuxedo application.
        /// </summary>
        /// 
        /// <param name="tpinfo">
        /// Client identification data; may be null.
        /// </param>
        /// 
        /// <remarks>
        /// The client must be logged off using <see cref="tpterm"/>
        /// when it doesn't use the Tuxedo services anymore.
        /// </remarks>
        /// 
        /// <exception cref="DotTux.Atmi.TPEPERM">
        /// The client does not have permission to join the application.
        /// </exception>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpinit(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to log a client on
        /// to a running Tuxedo application and how to make sure that 
        /// it gets logged off when it doesn't use the Tuxedo services
        /// anymore.
        /// <code>
        /// TPINIT tpinfo = new TPINIT();
        /// tpinfo.usrname = ...;
        /// tpinfo.passwd = ...;
        /// 
        /// ATMI.tpinit(tpinfo);
        /// try {
        ///     ... // Use Tuxedo services
        /// } finally {
        ///     ATMI.tpterm();
        /// } 
        /// </code>
        /// </example>

        public static void tpinit(TPINIT tpinfo)
	{
	    if (tpinfo == null) {
		if (DotTuxInterop.tpinit(IntPtr.Zero) == -1) {
		    throw NewTPException();
		}
	    } else {
		byte[] data = tpinfo.data;
	        int datalen = (data == null) ? 0 : data.Length;
	        int size = DotTuxInterop.TPINITNEED(datalen);
	        ByteBuffer buffer = tpalloc("TPINIT", null, size);
	        try {
		    tpinfo.write(buffer);
		    if (DotTuxInterop.tpinit(buffer.ptr) == -1) {
			throw NewTPException();
		    }
		    tpinfo.read(buffer); // For updating flags (see tpinit(3c))
	        } finally {
		    tpfree(buffer);
	        }
	    }

	    int ctxt = tpgetctxt(0); // Must get context *after* tpinit (!)

	    lock (unsolHandlers) {
		if (!unsolHandlers.ContainsKey(ctxt)) { // No handler
		    if (perProcessDefaultUnsolHandler != null) {
			unsolHandlers[ctxt] = perProcessDefaultUnsolHandler;
		    }
		}
	    }
	}

        /// <summary>
        /// Logs a client off from a running Tuxedo application. 
        /// </summary>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpterm(3c) manual page.
        /// </exception>
        
	public static void tpterm()
	{
	    // Note that tpterm() does *not* clear the unsol handler

	    if (DotTuxInterop.tpterm() == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Sends a request to a Tuxedo service without waiting for a reply. 
        /// </summary>
        /// 
        /// <param name="svc">
        /// The name of the Tuxedo service.
        /// </param>
        /// 
        /// <param name="request">
        /// A typed buffer containing the request; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="request"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpacall(3c) manual page.
        /// </param>
        /// 
        /// <returns>
        /// A call descriptor for use by <see cref="tpgetrply"/> or <see cref="tpcancel"/>.
        /// </returns>
        /// 
        /// <remarks>
        /// The caller must make sure to either complete the outstanding
        /// service call using <see cref="tpgetrply"/>, or cancel it using 
        /// <see cref="tpcancel"/>.
        /// </remarks>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpacall(3c) manual page.
        /// </exception>

        public static int tpacall(string svc, ByteBuffer request, int len,
	    int flags)
	{
	    IntPtr ptr = (request == null) ? IntPtr.Zero : request.ptr;

	    int result = DotTuxInterop.tpacall(svc, ptr, len, flags);
	    if (result == -1) {
		throw NewTPException();
	    }

	    return result;
	}

        /// <summary>
        /// Waits for the reply of an outstanding service call.
        /// </summary>
        /// 
        /// <param name="cdRef">
        /// <para>
        /// If the TPGETANY flag is set then the input value of this
        /// parameter is ignored.
        /// On return, if a reply was retrieved, this parameter is set to the
        /// call descriptor of the outstanding service call whose reply was 
        /// retrieved.
        /// Otherwise, it is set to 0.
        /// </para>
        /// <para>
        /// If the TPGETANY flag is not set then the input value of
        /// this parameter must be the call descriptor of an
        /// outstanding service call returned by <see cref="tpacall"/>.
        /// On return, if a reply was retrieved, the call descriptor is 
        /// invalidated (i.e., set to -1).
        /// Otherwise, the call descriptor remains valid.
        /// </para>
        /// </param>
        /// 
        /// <param name="replyRef">
        /// A typed buffer allocated using <see cref="tpalloc"/>.
        /// Gets updated with a typed buffer containing the reply data of the 
        /// completed outstanding service call, if any.
        /// </param>
        ///
        /// <param name="lenOut">
        /// Gets updated with the length of the data in <paramref name="replyRef"/>.
        /// If the length is 0 then the called service returned a null reply.
        /// </param>
        /// 
        /// <param name="flags">
        /// Set TPGETANY to wait for the reply of any outstanding
        /// service call.
        /// See the Tuxedo tpgetrply(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="DotTux.Atmi.TPESVCFAIL">
        /// The called service returned an application level service failure.
        /// In this case <paramref name="replyRef"/> and <paramref name="lenOut"/> 
        /// are updated as described above. 
        /// </exception>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpgetrply(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to send a request
        /// to a Tuxedo service and wait for its reply using 
        /// <see cref="tpacall"/> and <see cref="tpgetrply"/>.
        /// <code>
        /// ByteBuffer buffer = ATMI.tpalloc("STRING", null, 1024);
        /// try {
        ///     ... // Add request data to buffer
        ///     int cd = ATMI.tpacall("SVC", buffer, 0, ATMI.TPNOTRAN);
        ///     try {
        ///         ... // Do some other processing
        ///         int len;
        ///         try {
        ///             ATMI.tpgetrply(ref cd, ref buffer, out len, 0);
        ///             ... // Process normal reply data in buffer
        ///         } catch (TPESVCFAIL) {
        ///             ... // Process error reply data in buffer
        ///         }
        ///     } finally {
        ///         if (cd != -1) {
        ///             ATMI.tpcancel(cd);
        ///         }
        ///     }
        /// } finally {
        ///     ATMI.tpfree(buffer);
        /// }
        /// </code>
        /// </example>

        public static void tpgetrply(ref int cdRef, ref ByteBuffer replyRef,
	    out int lenOut, int flags)
	{
            // The Tuxedo ATMI reference states that tpgetrply() invalidates
            // cdRef on normal return and the error cases described under
            // callDescriptorInvalidated() below. Unfortunately, it does not say 
            // which value cdRef gets in this case, so we explicitly set it 
            // to -1 ourselves.

	    IntPtr ptr = (replyRef == null) ? IntPtr.Zero : replyRef.ptr;

	    if (DotTuxInterop.tpgetrply(ref cdRef, ref ptr, out lenOut, 
		    flags) == -1) {

                int err = tperrno();

                if (callDescriptorInvalidated(err)) {
                    cdRef = -1;
                }
                
                if (err == TPESVCFAIL) {
		    replyRef = NewTypedBuffer(ptr); // resets tperrno (!)
                }
                
                throw NewTPException(err);
            }

            cdRef = -1;

	    replyRef = NewTypedBuffer(ptr);
	}

        private static bool callDescriptorInvalidated(int err)
        {
            // According to the Tuxedo ATMI reference, tpgetrply() invalidates
            // the call descriptor on error, except for the following errors:
            // TPEINVAL, TPETIME (unless the caller is in transaction mode) 
            // and TPEBLOCK. 

            switch (err) {
                case TPEINVAL:
                    return false;
                case TPETIME:
                    return (DotTuxInterop.tpgetlev() == 1);
                case TPEBLOCK:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// Cancels the call descriptor of an outstanding service call. 
        /// </summary>
        /// 
        /// <param name="cd">
        /// The call descriptor to cancel.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpcancel(3c) manual page.
        /// </exception>

        public static void tpcancel(int cd)
	{
	    if (DotTuxInterop.tpcancel(cd) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Sends a request to a Tuxedo service and waits for its reply. 
        /// </summary>
        /// 
        /// <param name="svc">
        /// The name of the Tuxedo service.
        /// </param>
        /// 
        /// <param name="request">
        /// A typed buffer containing the request; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="request"/>.
        /// </param>
        /// 
        /// <param name="replyRef">
        /// A typed buffer allocated using <see cref="tpalloc"/>.
        /// Gets updated with a typed buffer containing the reply data returned 
        /// by the called service, if any.
        /// </param>
        ///
        /// <param name="lenOut">
        /// Gets updated with the length of the data in <paramref name="replyRef"/>.
        /// If the length is 0 then the called service returned a null reply.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpcall(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="DotTux.Atmi.TPESVCFAIL">
        /// The called service returned an application level service failure.
        /// In this case, <paramref name="replyRef"/> and <paramref name="lenOut"/>
        /// are updated as described above. 
        /// </exception>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpcall(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to send a request to a Tuxedo 
        /// service and wait for its reply using <see cref="tpcall"/>.
        /// <code>
        /// ByteBuffer buffer = ATMI.tpalloc("STRING", null, 1024);
        /// try {
        ///     ... // Add request data to buffer
        ///     int len;
        ///     try {
        ///         ATMI.tpcall("SVC", buffer, 0, ref buffer, out len, 0);
        ///         ... // Process normal reply data in buffer
        ///     } catch (TPESVCFAIL) {
        ///         ... // Process error reply data in buffer
        ///     }
        /// } finally {
        ///     ATMI.tpfree(buffer);
        /// }
        /// </code>
        /// </example>

	public static void tpcall(string svc, ByteBuffer request, int len,
	    ref ByteBuffer replyRef, out int lenOut, int flags)
	{
	    IntPtr requestPtr = (request == null) ? IntPtr.Zero : request.ptr;

	    IntPtr replyPtr = (replyRef == null) ? IntPtr.Zero : replyRef.ptr;

	    if (DotTuxInterop.tpcall(svc, requestPtr, len, ref replyPtr, 
		    out lenOut, flags) == -1) {
		if (tperrno() == TPESVCFAIL) {
		    replyRef = NewTypedBuffer(replyPtr); // resets tperrno (!)
		    throw NewTPException(TPESVCFAIL);
		}
		throw NewTPException();
	    }

	    replyRef = NewTypedBuffer(replyPtr);
	}

        /// <summary>
        /// Establishes a connection with a conversational Tuxedo service. 
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
        /// <returns>
        /// A connection descriptor for use by <see cref="tpsend"/>, 
        /// <see cref="tprecv"/> and <see cref="tpdiscon"/>.
        /// </returns>
        /// 
        /// <remarks>
        /// The caller must make sure to either keep sending and receiving
        /// data until the conversation terminates, or abort the conversation
        /// using <see cref="tpdiscon"/>.
        /// This requires a small amount of non-trivial boilerplate code
        /// which can be avoided by using the <see cref="Conversation"/> 
        /// class.
        /// </remarks> 
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpconnect(3c) manual page.
        /// </exception>

        public static int tpconnect(string svc, ByteBuffer message, int len,
	    int flags)
	{
	    IntPtr ptr = (message == null) ? IntPtr.Zero : message.ptr;

	    int result = DotTuxInterop.tpconnect(svc, ptr, len, flags);
	    if (result == -1) {
		throw NewTPException();
	    }

	    return result;
	}

        /// <summary>
        /// Sends a message as part of a conversation.
        /// </summary>
        /// 
        /// <param name="cd">
        /// The connection descriptor of the conversation.
        /// </param>
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

	public static void tpsend(int cd, ByteBuffer message, int len,
	    int flags)
	{
	    IntPtr ptr = (message == null) ? IntPtr.Zero : message.ptr;

	    int revent;

	    if (DotTuxInterop.tpsend(cd, ptr, len, flags, out revent) == -1) {
                int err = tperrno();
		if (err == TPEEVENT) {
		    throw NewTPEEVENT(revent);
		}
		throw NewTPException(err);
	    }
	}

        /// <summary>
        /// Receives a message as part of a conversation.
        /// </summary>
        /// 
        /// <param name="cd">
        /// The connection descriptor of the conversation.
        /// </param>
        /// 
        /// <param name="messageRef">
        /// A typed buffer allocated using <see cref="tpalloc"/>.
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

        public static void tprecv(int cd, ref ByteBuffer messageRef,
	    out int lenOut, int flags)
	{
	    IntPtr ptr = (messageRef == null) ? IntPtr.Zero : messageRef.ptr;

	    int revent;

	    if (DotTuxInterop.tprecv(cd, ref ptr, out lenOut, flags, 
		    out revent) == -1) {
                int err = tperrno();
	        if (err == TPEEVENT) {
		    if ((revent == TPEV_SENDONLY) || (revent == TPEV_SVCSUCC)
			    || (revent == TPEV_SVCFAIL)) {
		        messageRef = NewTypedBuffer(ptr); // resets tperrno (!)
		    }
		    throw NewTPEEVENT(revent);
		}
		throw NewTPException(err);
	    }

	    messageRef = NewTypedBuffer(ptr);
	}

        /// <summary>
        /// Terminates a conversation abortively. 
        /// </summary>
        /// 
        /// <param name="cd">
        /// The connection descriptor of the conversation.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpdiscon(3c) manual page.
        /// </exception>
        
	public static void tpdiscon(int cd)
	{
	    if (DotTuxInterop.tpdiscon(cd) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Enqueues a message in a Tuxedo/Q queue. 
        /// </summary>
        /// 
        /// <param name="qspace">
        /// The name of the queue space containing the queue.
        /// </param>
        /// 
        /// <param name="qname">
        /// The name of the queue.
        /// </param>
        /// 
        /// <param name="qctl">
        /// Control parameters for the enqueue operation.
        /// See <see cref="TPQCTL"/> and the Tuxedo tpenqueue(3c) manual page.
        /// </param>
        /// 
        /// <param name="message">
        /// A typed buffer containing the message to enqueue; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="message"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpenqueue(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpenqueue(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to enqueue a message  
        /// in a Tuxedo/Q queue using <see cref="tpenqueue"/>.
        /// <code>
        /// ByteBuffer buffer = ATMI.tpalloc("STRING", null, 1024);
        /// try {
        ///     ... // Add message data to buffer
   	///     TPQCTL qctl = new TPQCTL();
	///     qctl.flags = ATMI.TPQREPLYQ; 
	///     qctl.replyqueue = "REPLYQ";
	///     ATMI.tpenqueue("QSPACE", "SVC", qctl, buffer, 0, 0);
        /// } finally {
        ///     ATMI.tpfree(buffer);
        /// }
        /// </code>
        /// </example>

        public static void tpenqueue(string qspace, string qname, 
	    TPQCTL qctl, ByteBuffer message, int len, int flags)
	{
	    /*
	     * tpenqueue(3c) says the following about the ctl parameter:
	     *
	     *     "If this parameter is NULL, the input flags are considered
	     *     to be TPNOFLAGS and no output information is made available
	     *     to the application program."
	     *
	     * On Windows, however, tpenqueue() crashes when ctl == NULL.
	     * Fortunately, we never pass NULL to tpenqueue() ourselves
	     * because we always use a TPQCTL for the diagnostic value.
	     * Better keep it that way.
	     */

	    if (qctl == null) {
		qctl = new TPQCTL();
		qctl.flags = ATMI.TPNOFLAGS;
	    }

	    IntPtr ptr = (message == null) ? IntPtr.Zero : message.ptr;

	    if (DotTuxInterop.tpenqueue(qspace, qname, qctl, ptr,
		    len, flags) == -1) {
                int err = tperrno();
		if (err == TPEDIAGNOSTIC) {
		    throw NewTPEDIAGNOSTIC(qctl.diagnostic);
		}
		throw NewTPException(err);
	    }
	}

        /// <summary>
        /// Dequeues a message from a Tuxedo/Q queue. 
        /// </summary>
        /// 
        /// <param name="qspace">
        /// The name of the queue space containing the queue.
        /// </param>
        /// 
        /// <param name="qname">
        /// The name of the queue.
        /// </param>
        /// 
        /// <param name="qctl">
        /// Control parameters for the dequeue operation.
        /// See <see cref="TPQCTL"/> and the Tuxedo tpdequeue(3c) manual page.
        /// </param>
        /// 
        /// <param name="messageRef">
        /// A typed buffer allocated using <see cref="tpalloc"/>.
        /// Gets updated with a typed buffer containing the data dequeued
        /// from the queue.
        /// </param>
        ///
        /// <param name="lenOut">
        /// Gets updated with the length of the data in <paramref name="messageRef"/>.
        /// If the length is 0 then a null message was dequeued.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpdequeue(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpdequeue(3c) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to dequeue a message  
        /// from a Tuxedo/Q queue using <see cref="tpdequeue"/>.
        /// <code>
        /// ByteBuffer buffer = ATMI.tpalloc("STRING", null, 1024);
        /// try {
   	///     TPQCTL qctl = new TPQCTL();
   	///     qctl.flags = ATMI.TPQWAIT;
        ///     int len;
	///     ATMI.tpdequeue("QSPACE", "REPLYQ", qctl, ref buffer, out len, 0);
        ///     ... // Process reply data in buffer
        /// } finally {
        ///     ATMI.tpfree(buffer);
        /// }
        /// </code>
        /// </example>

        public static void tpdequeue(string qspace, string qname, 
	    TPQCTL qctl, ref ByteBuffer messageRef, out int lenOut, 
            int flags)
	{
	    if (qctl == null) {
		qctl = new TPQCTL();
		qctl.flags = ATMI.TPNOFLAGS;
	    }

	    IntPtr ptr = (messageRef == null) ? IntPtr.Zero : messageRef.ptr;

	    if (DotTuxInterop.tpdequeue(qspace, qname, qctl, ref ptr,
		    out lenOut, flags) == -1) {
                int err = tperrno();
		if (err == TPEDIAGNOSTIC) {
		    throw NewTPEDIAGNOSTIC(qctl.diagnostic);
		}
		throw NewTPException(err);
	    }

	    messageRef = NewTypedBuffer(ptr);
	}

        /// <summary>
        /// Starts a new global transaction. 
        /// </summary>
        /// 
        /// <param name="timeout">
        /// The transaction timeout in seconds; must not be negative.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpbegin(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpbegin(3c) manual page.
        /// </exception>

        public static void tpbegin(int timeout, int flags)
	{
            // timeout is an unsigned long in C => make sure
            // timeout is >= 0.

            if (timeout < 0) {
                throw new ArgumentException("timeout must not be negative");
            }

	    if (DotTuxInterop.tpbegin(timeout, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Aborts the current global transaction. 
        /// </summary>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpabort(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpabort(3c) manual page.
        /// </exception>

        public static void tpabort(int flags)
	{
	    if (DotTuxInterop.tpabort(flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Commits the current global transaction. 
        /// </summary>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpcommit(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpcommit(3c) manual page.
        /// </exception>

        public static void tpcommit(int flags)
	{
	    if (DotTuxInterop.tpcommit(flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Returns the current transaction level. 
        /// </summary>
        /// 
        /// <returns>
        /// The current transaction level (1 if the caller is 
        /// in transaction mode, 0 if the caller is not in transaction 
        /// mode).
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpgetlev(3c) manual page.
        /// </exception>

        public static int tpgetlev()
	{
	    int result = DotTuxInterop.tpgetlev();
	    if (result == -1) {
		throw NewTPException();
	    }
	    return result;
	}

        /// <summary>
        /// Sets the TP_COMMIT_CONTROL characteristic. 
        /// </summary>
        /// 
        /// <param name="flags">
        /// The value can be either TP_CMT_LOGGED or TP_CMT_COMPLETE.
        /// See the Tuxedo tpscmt(3c) manual page.
        /// </param>
        /// 
        /// <returns>
        /// The previous value of the TP_COMMIT_CONTROL characteristic.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpscmt(3c) manual page.
        /// </exception>

        public static int tpscmt(int flags)
	{
	    int result = DotTuxInterop.tpscmt(flags);
	    if (result == -1) {
		throw NewTPException();
	    }
	    return result;
	}

        /// <summary>
        /// Suspends the current global transaction. 
        /// </summary>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpsuspend(3c) manual page.
        /// </param>
        /// 
        /// <returns>
        /// 
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsuspend(3c) manual page.
        /// </exception>

	public static TPTRANID tpsuspend(int flags)
	{
            TPTRANID tranid = new TPTRANID();
	    if (DotTuxInterop.tpsuspend(tranid, flags) == -1) {
		throw NewTPException();
	    }
	    return tranid;
	}

        /// <summary>
        /// Resumes a suspended global transaction. 
        /// </summary>
        /// 
        /// <param name="tranid">
        /// The transaction id of the suspended global transaction
        /// to resume.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpresume(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpresume(3c) manual page.
        /// </exception>

        public static void tpresume(TPTRANID tranid, int flags)
	{
	    if (DotTuxInterop.tpresume(tranid, flags) == -1) {
		throw NewTPException();
	    }
	}

#if WSCLIENT
	/* Skip tpopen() */
#else
        /// <summary>
        /// Opens the resource manager to which the caller is linked. 
        /// </summary>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpopen(3c) manual page.
        /// </exception>
        
        public static void tpopen()
	{
	    if (DotTuxInterop.tpopen() == -1) {
		throw NewTPException();
	    }
	}
#endif

#if WSCLIENT
	/* Skip tpclose() */
#else
        /// <summary>
        /// Closes the resource manager to which the caller is linked. 
        /// </summary>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpclose(3c) manual page.
        /// </exception>
        
	public static void tpclose()
	{
	    if (DotTuxInterop.tpclose() == -1) {
		throw NewTPException();
	    }
	}
#endif

        /// <summary>
        /// Returns the priority level of the last request sent of received 
        /// by the current thread. 
        /// </summary>
        /// 
        /// <returns>
        /// The priority level of the last request sent of received 
        /// by the current thread.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpgprio(3c) manual page.
        /// </exception>

        public static int tpgprio()
	{
	    int result = DotTuxInterop.tpgprio();
	    if (result == -1) {
		throw NewTPException();
	    }
	    return result;
	}

        /// <summary>
        /// Sets the priority level of the next request sent of forwarded 
        /// by the current thread. 
        /// </summary>
        /// 
        /// <param name="prio">
        /// The priority level to set.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpsprio(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsprio(3c) manual page.
        /// </exception>

        public static void tpsprio(int prio, int flags)
	{
	    if (DotTuxInterop.tpsprio(prio, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Triggers the handling of unsolicited messages. 
        /// </summary>
        /// 
        /// <returns>
        /// The number of unsolicited messages handled.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpchkunsol(3c) manual page.
        /// </exception>

        public static int tpchkunsol()
	{
	    int result = DotTuxInterop.tpchkunsol();
	    if (result == -1) {
		throw NewTPException();
	    }
	    return result;
	}

        /// <summary>
        /// Broadcasts an unsolicited message to a set of clients. 
        /// </summary>
        /// 
        /// <param name="lmid">
        /// The logical machine ID of the machine to which the broadcast is 
        /// restricted.
        /// If null then the broadcast is not restricted to a particular machine.
        /// </param>
        /// 
        /// <param name="usrname">
        /// The user name to which the broadcast is restricted.
        /// If null then the broadcast is not restricted to a particular user.
        /// </param>
        /// 
        /// <param name="cltname">
        /// The client name to which the broadcast is restricted.
        /// If null then the broadcast is not restricted to a particular client type.
        /// </param>
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
        /// See the Tuxedo tpbroadcast(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpbroadcast(3c) manual page.
        /// </exception>

        public static void tpbroadcast(string lmid, string usrname,
	    string cltname, ByteBuffer message, int len, int flags)
	{
	    IntPtr ptr = (message == null) ? IntPtr.Zero : message.ptr;
	    
	    if (DotTuxInterop.tpbroadcast(lmid, usrname, cltname, ptr,
		    len, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Sends an unsolicited message to an individual client. 
        /// </summary>
        /// 
        /// <param name="cltid">
        /// The client id of the client to which to send the message.
        /// </param>
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
        /// See the Tuxedo tpnotify(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpnotify(3c) manual page.
        /// </exception>

        public static void tpnotify(CLIENTID cltid, ByteBuffer message,
	    int len, int flags)
	{
	    IntPtr ptr = (message == null) ? IntPtr.Zero : message.ptr;

	    if (DotTuxInterop.tpnotify(cltid, ptr, len, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Posts a message using the Tuxedo event broker. 
        /// </summary>
        /// 
        /// <param name="eventname">
        /// The name of the event.
        /// </param>
        /// 
        /// <param name="message">
        /// A typed buffer containing the message to post; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="message"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tppost(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tppost(3c) manual page.
        /// </exception>

        public static void tppost(string eventname, ByteBuffer message,
	    int len, int flags)
	{
	    IntPtr ptr = (message == null) ? IntPtr.Zero : message.ptr;

	    if (DotTuxInterop.tppost(eventname, ptr, len, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Sets up a subscription to one or more events. 
        /// </summary>
        /// 
        /// <param name="eventexpr">
        /// A regular expression specifying the events to which to subscribe.
        /// </param>
        /// 
        /// <param name="filter">
        /// An additional filter rule evaluated by the event broker before
        /// sending an event message; may be null.
        /// </param>
        /// 
        /// <param name="evctl">
        /// Control parameters for the subscription operation.
        /// See <see cref="TPEVCTL"/> and
	/// the Tuxedo tpsubscribe(3c) manual page.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpsubscribe(3c) manual page.
        /// </param>
        /// 
        /// <returns>
        /// A subscription handle for use by <see cref="tpunsubscribe"/>.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsubscribe(3c) manual page.
        /// </exception>

        public static int tpsubscribe(string eventexpr, string filter,
	    TPEVCTL evctl, int flags)
	{
	    int result = DotTuxInterop.tpsubscribe(eventexpr, filter,
		evctl, flags);
	    if (result == -1) {
		throw NewTPException();
	    }
	    return result;
	}

        /// <summary>
        /// Cancels an event subscription. 
        /// </summary>
        /// 
        /// <param name="subscription">
        /// The subscription handle to cancel.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpunsubscribe(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpunsubscribe(3c) manual page.
        /// </exception>

        public static void tpunsubscribe(int subscription, int flags)
	{
	    if (DotTuxInterop.tpunsubscribe(subscription, flags) == -1) {
		throw NewTPException();
	    }
	}

        /// <summary>
        /// Returns the multi-byte encoding name of a typed buffer. 
        /// </summary>
        /// 
        /// <param name="buffer">
        /// The typed buffer.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpgetmbenc(3c) manual page.
        /// </param>
        /// 
        /// <returns>
        /// The multi-byte encoding name of <paramref name="buffer"/>.
        /// </returns>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpgetmbenc(3c) manual page.
        /// </exception>

        public static String tpgetmbenc(ByteBuffer buffer, int flags)
	{
	    IntPtr bufferPtr = (buffer == null) ? IntPtr.Zero : buffer.ptr;

	    StringBuilder encBuilder = new StringBuilder(256);

	    if (DotTuxInterop.tpgetmbenc(bufferPtr, encBuilder, 
		    flags) == -1) {
		throw NewTPException();
	    }

	    return encBuilder.ToString();
	}

        /// <summary>
        /// Sets the multi-byte encoding name of a typed buffer. 
        /// </summary>
        /// 
        /// <param name="buffer">
        /// The typed buffer.
        /// </param>
        /// 
        /// <param name="enc">
        /// The multi-byte encoding to set.
        /// </param>
        /// 
        /// <param name="flags">
        /// Use RM_ENC to clear the multi-byte encoding name.
        /// See the Tuxedo tpsetmbenc(3c) manual page.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpsetmbenc(3c) manual page.
        /// </exception>

        public static void tpsetmbenc(ByteBuffer buffer, string enc,
	    int flags)
	{
	    IntPtr bufferPtr = (buffer == null) ? IntPtr.Zero : buffer.ptr;

	    if (DotTuxInterop.tpsetmbenc(bufferPtr, enc, flags) != 0) {
	       	// Not == -1 (!), see tpsetmbenc(3c)
		throw NewTPException();
	    }
	}

#if WSCLIENT
        /* Skip tpadvertise() */
#else
        /// <summary>
        /// Dynamically advertises a Tuxedo service. 
	/// </summary>
	/// 
	/// <param name="svc">
	/// The name of the service.
	/// </param>
	/// 
	/// <param name="func">
	/// The name of the service routine.
	/// This must be the name of a Tuxedo server class method
	/// that has been identified as a service routine using the
	/// <c>-s</c> command line option of the DotServer executable.
        /// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpadvertise(3c) manual page.
        /// </exception>

        public static void tpadvertise(string svc, string func)
	{
	    if (DotTuxInterop.tpadvertise(svc, func) == -1) {
		throw NewTPException();
	    }
	}
#endif

#if WSCLIENT
        /* Skip tpunadvertise() */
#else
        /// <summary>
        /// Dynamically unadvertises a service. 
        /// </summary>
	/// 
	/// <param name="svc">
	/// The name of the service.
	/// </param>
        /// 
        /// <exception cref="TPException">
        /// See the Tuxedo tpunadvertise(3c) manual page.
        /// </exception>

        public static void tpunadvertise(string svc)
	{
	    if (DotTuxInterop.tpunadvertise(svc) == -1) {
		throw NewTPException();
	    }
	}
#endif

#if WSCLIENT
        /* Skip tpreturn() */
#else
        /// <summary>
        /// Returns a reply from a service routine. 
        /// </summary>
        /// 
        /// <param name="rval">
        /// The termination status of the service routine (TPSUCCESS, TPFAIL or TPEXIT).
        /// </param>
        /// 
        /// <param name="rcode">
        /// The application return code.
        /// </param>
        /// 
        /// <param name="reply">
        /// A typed buffer containing the reply to return; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="reply"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpreturn(3c) manual page.
        /// </param>
        /// 
        /// <remarks>
        /// This method does not actually terminate the service routine but 
        /// only marks the service routine as being terminated. 
        /// It is the responsibility of the programmer to make sure that the 
        /// service routine returns promplty after calling this method. 
        /// </remarks>
        /// 
        /// <exception cref="DotTux.Atmi.TPEPROTO">
        /// The service routine was already terminated by a previous call 
        /// to <see cref="tpreturn"/> or <see cref="tpforward"/>.
        /// </exception>

        public static void tpreturn(int rval, int rcode, ByteBuffer reply,
	    int len, int flags)
	{
	    IntPtr ptr = (reply == null) ? IntPtr.Zero : reply.ptr;

	    if (DotTuxInterop.tpreturn(rval, rcode, ptr, len, flags) == -1) {
		throw NewTPException();
	    }
	}
#endif

#if WSCLIENT
        /* Skip tpforward() */
#else
        /// <summary>
        /// Forwards a request to another Tuxedo service. 
        /// </summary>
        /// 
        /// <param name="svc">
        /// The name of the service.
        /// </param>
        /// 
        /// <param name="request">
        /// A typed buffer containing the request to forward; may be null.
        /// </param>
        /// 
        /// <param name="len">
        /// The length of the data in <paramref name="request"/>.
        /// </param>
        /// 
        /// <param name="flags">
        /// See the Tuxedo tpreturn(3c) manual page.
        /// </param>
        /// 
        /// <remarks>
        /// This method does not actually terminate the service routine but 
        /// merely marks the service routine as being terminated. 
        /// It is the responsibility of the programmer to make sure that the 
        /// service routine returns promplty after calling this method. 
        /// </remarks>
        /// 
        /// <exception cref="DotTux.Atmi.TPEPROTO">
        /// The service routine was already terminated by a previous call 
        /// to <see cref="tpreturn"/> or <see cref="tpforward"/>.
        /// </exception>
        
	public static void tpforward(string svc, ByteBuffer request, int len,
	    int flags)
	{
	    IntPtr ptr = (request == null) ? IntPtr.Zero : request.ptr;

	    if (DotTuxInterop.tpforward(svc, ptr, len, flags) == -1) {
		throw NewTPException();
	    }
	}
#endif
    }
}
