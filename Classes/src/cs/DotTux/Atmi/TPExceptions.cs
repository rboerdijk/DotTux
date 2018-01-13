/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Text;
using System.Runtime.InteropServices;

namespace DotTux.Atmi
{
    /// <summary>
    /// Thrown if an ATMI system call failed.
    /// </summary>
    /// 
    /// <remarks>
    /// A TPException carries an ATMI error code that identifies the reason why 
    /// the exception was thrown. 
    /// The symbolic constants for these error codes are defined in the ATMI class. 
    /// </remarks>
    
    public class TPException: ApplicationException
    {
	private int err;

	internal TPException(int err)
	{
	    this.err = err;
	}

        /// <summary>
        /// The ATMI error code that identifies the reason why this 
        /// exception was thrown.
        /// </summary>
        
	public int tperrno
	{
	    get { return err; }
	}

        /// <summary>
        /// A short message that describes the reason why this 
        /// exception was thrown.
        /// </summary>
        
	override public string Message
	{
	    get {
	        string s = ATMI.tpstrerror(err);
		if (s == null) {
		    return "tperrno=" + err;
		} else {
		    return s;
		}
	    }
	}
    }

    /// <summary>
    /// Thrown if a transaction could not be committed.
    /// </summary>

    public class TPEABORT: TPException
    {
	internal TPEABORT() : base(ATMI.TPEABORT) {}
    }

    /// <summary>
    /// Thrown if an invalid communication descriptor was
    /// passed to an ATMI system call.
    /// </summary>

    public class TPEBADDESC: TPException
    {
	internal TPEBADDESC() : base(ATMI.TPEBADDESC) {}
    }

    /// <summary>
    /// Thrown if an ATMI system call would block.
    /// </summary>

    public class TPEBLOCK: TPException
    {
	internal TPEBLOCK() : base(ATMI.TPEBLOCK) {}
    }

    /// <summary>
    /// Thrown if an illegal argument was passed to an ATMI
    /// system call.
    /// </summary>

    public class TPEINVAL: TPException
    {
	internal TPEINVAL() : base(ATMI.TPEINVAL) {}
    }

    /// <summary>
    /// Thrown if a system resource limit was exceeded.
    /// </summary>

    public class TPELIMIT: TPException
    {
	internal TPELIMIT() : base(ATMI.TPELIMIT) {}
    }

    /// <summary>
    /// Thrown if a named system resource does not exist.
    /// </summary>

    public class TPENOENT: TPException
    {
	internal TPENOENT() : base(ATMI.TPENOENT) {}
    }

    /// <summary>
    /// Thrown if an OS level system error occurred.
    /// </summary>

    public class TPEOS: TPException
    {
	internal TPEOS() : base(ATMI.TPEOS) {}
    }

    /// <summary>
    /// Thrown if there was no permission to perform
    /// a certain operation.
    /// </summary>

    public class TPEPERM: TPException
    {
	internal TPEPERM() : base(ATMI.TPEPERM) {}
    }

    /// <summary>
    /// Thrown if an ATMI system call was executed in the
    /// wrong context.
    /// </summary>

    public class TPEPROTO: TPException
    {
	internal TPEPROTO() : base(ATMI.TPEPROTO) {}
    }

    /// <summary>
    /// Thrown is a service routine terminated without
    /// returning a reply.
    /// </summary>

    public class TPESVCERR: TPException
    {
	internal TPESVCERR() : base(ATMI.TPESVCERR) {}
    }

    /// <summary>
    /// Thrown if a service routine returned an application
    /// level service failure.
    /// </summary>

    public class TPESVCFAIL: TPException
    {
	internal TPESVCFAIL() : base(ATMI.TPESVCFAIL) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo level system error occurred.
    /// </summary>

    public class TPESYSTEM: TPException
    {
	internal TPESYSTEM() : base(ATMI.TPESYSTEM) {}
    }

    /// <summary>
    /// Thrown if a timeout occurred.
    /// </summary>

    public class TPETIME: TPException
    {
	internal TPETIME() : base(ATMI.TPETIME) {}
    }

    /// <summary>
    /// Thrown if there was an error starting a transaction.
    /// </summary>

    public class TPETRAN: TPException
    {
	internal TPETRAN() : base(ATMI.TPETRAN) {}
    }

    /// <summary>
    /// Thrown if an ATMI system call was interrupted by
    /// an OS signal.
    /// </summary>

    public class TPGOTSIG: TPException
    {
	internal TPGOTSIG() : base(ATMI.TPGOTSIG) {}
    }

    /// <summary>
    /// Thrown if a resource manager failed to open correctly.
    /// </summary>

    public class TPERMERR: TPException
    {
	internal TPERMERR() : base(ATMI.TPERMERR) {}
    }

    /// <summary>
    /// Thrown if a non-supported message type was sent
    /// to a service routine.
    /// </summary>

    public class TPEITYPE: TPException
    {
	internal TPEITYPE() : base(ATMI.TPEITYPE) {}
    }

    /// <summary>
    /// Thrown if a non-supported message type was received
    /// from a service routine.
    /// </summary>

    public class TPEOTYPE: TPException
    {
	internal TPEOTYPE() : base(ATMI.TPEOTYPE) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo version mismatch was detected.
    /// </summary>

    public class TPERELEASE: TPException
    {
	internal TPERELEASE() : base(ATMI.TPERELEASE) {}
    }

    /// <summary>
    /// Thrown if a transaction could have been heuristically completed.
    /// </summary>

    public class TPEHAZARD: TPException
    {
	internal TPEHAZARD() : base(ATMI.TPEHAZARD) {}
    }

    /// <summary>
    /// Thrown if a transaction was partially committed and partially aborted.
    /// </summary>

    public class TPEHEURISTIC: TPException
    {
	internal TPEHEURISTIC() : base(ATMI.TPEHEURISTIC) {}
    }

    /// <summary>
    /// Thrown if a conversational event occurred.
    /// </summary>
    /// 
    /// <remarks>
    /// A TPEEVENT carries an ATMI event code that identifies the type of
    /// event that occurred.
    /// The symbolic constants for these event codes are defined in the ATMI class. 
    /// </remarks>
    
    public class TPEEVENT: TPException
    {
	private int ev; // 'event' is a C# keyword

	internal TPEEVENT(int ev) : base(ATMI.TPEEVENT)
	{
	    this.ev = ev;
	}

        /// <summary>
        /// The ATMI event code that identifies the type of event that
        /// occurred.
        /// </summary>
        
	public int Event
	{
	    get { return ev; }
	}

	internal string EventDescription
	{
	    get {
	        switch (ev) {
	            case ATMI.TPEV_SENDONLY:
		        return "TPEV_SENDONLY";
	            case ATMI.TPEV_SVCSUCC:
		        return "TPEV_SVCSUCC";
	            case ATMI.TPEV_SVCFAIL:
		        return "TPEV_SVCFAIL";
	            case ATMI.TPEV_SVCERR:
		        return "TPEV_SVCERR";
	            case ATMI.TPEV_DISCONIMM:
		        return "TPEV_DISCONIMM";
	            default:
		        return "" + ev;
		}
	    }
	}
 
        /// <summary>
        /// A short message that describes the type of event 
        /// that occurred.
        /// </summary>
        
	override public string Message
	{
	    get {
		return base.Message + ": " + EventDescription;
	    }
	}
    }

    /// <summary>
    /// Thrown if a conversation was terminated abortively.
    /// </summary>

    public class TPEV_DISCONIMM: TPEEVENT
    {
	internal TPEV_DISCONIMM() : base(ATMI.TPEV_DISCONIMM) {}
    }

    /// <summary>
    /// Thrown if a conversational service routine terminated without
    /// sending a reply.
    /// </summary>

    public class TPEV_SVCERR: TPEEVENT
    {
	internal TPEV_SVCERR() : base(ATMI.TPEV_SVCERR) {}
    }

    /// <summary>
    /// Thrown if a conversational service routine returned an
    /// application level service failure.
    /// </summary>

    public class TPEV_SVCFAIL: TPEEVENT
    {
	internal TPEV_SVCFAIL() : base(ATMI.TPEV_SVCFAIL) {}
    }

    /// <summary>
    /// Thrown if a conversational service routine returned 
    /// normally.
    /// </summary>

    public class TPEV_SVCSUCC: TPEEVENT
    {
	internal TPEV_SVCSUCC() : base(ATMI.TPEV_SVCSUCC) {}
    }

    /// <summary>
    /// Thrown if the other end of a connection has given up
    /// control of the conversation.
    /// </summary>

    public class TPEV_SENDONLY: TPEEVENT
    {
	internal TPEV_SENDONLY() : base(ATMI.TPEV_SENDONLY) {}
    }

    /// <summary>
    /// Thrown if an attempt was made to reconfigure an existing 
    /// resource.
    /// </summary>

    public class TPEMATCH: TPException
    {
	internal TPEMATCH() : base(ATMI.TPEMATCH) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo/Q operation failed.
    /// </summary>
    /// 
    /// <remarks>
    /// A TPEDIAGNOSTIC carries a Tuxedo/Q diagnostic error code that 
    /// identifies the type of failure that occurred.
    /// The symbolic constants for these Tuxedo/Q diagnostic error 
    /// codes are defined in the ATMI class. 
    /// </remarks>
    
    public class TPEDIAGNOSTIC: TPException
    {
	private int diagnostic;

	internal TPEDIAGNOSTIC(int diagnostic) : base(ATMI.TPEDIAGNOSTIC)
	{
	    this.diagnostic = diagnostic;
	}

        /// <summary>
        /// The Tuxedo/Q diagnostic error code that identifies the 
        /// type of failure that occurred.
        /// </summary>

	public int Diagnostic
	{
	    get {
		return diagnostic;
	    }
	}

        internal string DiagnosticDescription
	{
	    get {
	        switch (diagnostic) {
	            case ATMI.QMEINVAL:
		        return "QMEINVAL";
	            case ATMI.QMEBADRMID:
		        return "QMEBADRMID";
	            case ATMI.QMENOTOPEN:
		        return "QMENOTOPEN";
	            case ATMI.QMETRAN:
		        return "QMETRAN";
	            case ATMI.QMEBADMSGID:
		        return "QMEBADMSGID";
	            case ATMI.QMESYSTEM:
		        return "QMESYSTEM";
	            case ATMI.QMEOS:
		        return "QMEOS";
	            case ATMI.QMEABORTED:
		        return "QMEABORTED";
	            case ATMI.QMEPROTO:
		        return "QMEPROTO";
	            case ATMI.QMEBADQUEUE:
		        return "QMEBADQUEUE";
	            case ATMI.QMENOMSG:
		        return "QMENOMSG";
	            case ATMI.QMEINUSE:
		        return "QMEINUSE";
	            case ATMI.QMENOSPACE:
		        return "QMENOSPACE";
	            case ATMI.QMERELEASE:
		        return "QMERELEASE";
	            case ATMI.QMEINVHANDLE:
		        return "QMEINVHANDLE";
	            case ATMI.QMESHARE:
		        return "QMESHARE";
	            default:
		        return "" + diagnostic;
		}
	    }
	}

        /// <summary>
        /// Returns a short message that describes the type of failure that
        /// occurred.
        /// </summary>
        
	override public string Message
	{
	    get {
		return base.Message + ": " + DiagnosticDescription;
	    }
	}
    }

    /// <summary>
    /// Thrown if an illegal argument was passed to a Tuxedo/Q
    /// system call.
    /// </summary>

    public class QMEINVAL: TPEDIAGNOSTIC
    {
	internal QMEINVAL() : base(ATMI.QMEINVAL) {}
    }

    /// <summary>
    /// Thrown if an invalid Tuxedo/Q resource manager was specified.
    /// </summary>

    public class QMEBADRMID: TPEDIAGNOSTIC
    {
	internal QMEBADRMID() : base(ATMI.QMEBADRMID) {}
    }

    /// <summary>
    /// Thrown if the Tuxedo/Q resource manager was not open.
    /// </summary>

    public class QMENOTOPEN: TPEDIAGNOSTIC
    {
	internal QMENOTOPEN() : base(ATMI.QMENOTOPEN) {}
    }

    /// <summary>
    /// Thrown if there was an error starting a Tuxedo/Q 
    /// transaction.
    /// </summary>

    public class QMETRAN: TPEDIAGNOSTIC
    {
	internal QMETRAN() : base(ATMI.QMETRAN) {}
    }

    /// <summary>
    /// Thrown if an invalid Tuxedo/Q message identifier was
    /// specified.
    /// </summary>

    public class QMEBADMSGID: TPEDIAGNOSTIC
    {
	internal QMEBADMSGID() : base(ATMI.QMEBADMSGID) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo level system error occurred during
    /// a Tuxedo/Q operation.
    /// </summary>

    public class QMESYSTEM: TPEDIAGNOSTIC
    {
	internal QMESYSTEM() : base(ATMI.QMESYSTEM) {}
    }

    /// <summary>
    /// Thrown if an OS level system error occurred during a
    /// Tuxedo/Q operation.
    /// </summary>

    public class QMEOS: TPEDIAGNOSTIC
    {
	internal QMEOS() : base(ATMI.QMEOS) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo/Q operation was aborted.
    /// </summary>

    public class QMEABORTED: TPEDIAGNOSTIC
    {
	internal QMEABORTED() : base(ATMI.QMEABORTED) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo/Q operation was executed in the
    /// wrong context.
    /// </summary>

    public class QMEPROTO: TPEDIAGNOSTIC
    {
	internal QMEPROTO() : base(ATMI.QMEPROTO) {}
    }

    /// <summary>
    /// Thrown if an invalid Tuxedo/Q queue name was specified.
    /// </summary>

    public class QMEBADQUEUE: TPEDIAGNOSTIC
    {
	internal QMEBADQUEUE() : base(ATMI.QMEBADQUEUE) {}
    }

    /// <summary>
    /// Thrown if there was no Tuxedo/Q message available for
    /// dequeuing.
    /// </summary>

    public class QMENOMSG: TPEDIAGNOSTIC
    {
	internal QMENOMSG() : base(ATMI.QMENOMSG) {}
    }

    /// <summary>
    /// Thrown if a message available for dequeuing is in use 
    /// by another transaction.
    /// </summary>

    public class QMEINUSE: TPEDIAGNOSTIC
    {
	internal QMEINUSE() : base(ATMI.QMEINUSE) {}
    }

    /// <summary>
    /// Thrown if there was not enough space to enqueue
    /// a Tuxedo/Q message.
    /// </summary>

    public class QMENOSPACE: TPEDIAGNOSTIC
    {
	internal QMENOSPACE() : base(ATMI.QMENOSPACE) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo/Q version mismatch was detected.
    /// </summary>

    public class QMERELEASE: TPEDIAGNOSTIC
    {
	internal QMERELEASE() : base(ATMI.QMERELEASE) {}
    }

    // QMEINVHANDLE it is neither documented in
    // tpenqueue(3c) nor tpdequeue(3c) => hide it from
    // public view.

    internal class QMEINVHANDLE: TPEDIAGNOSTIC
    {
	internal QMEINVHANDLE() : base(ATMI.QMEINVHANDLE) {}
    }

    /// <summary>
    /// Thrown if a Tuxedo/Q resource was accessed that is in
    /// exclusive use by another application.
    /// </summary>

    public class QMESHARE: TPEDIAGNOSTIC
    {
	internal QMESHARE() : base(ATMI.QMESHARE) {}
    }

    /// <summary>
    /// Thrown if an administrative Tuxedo operation failed.
    /// </summary>

    public class TPEMIB: TPException
    {
	internal TPEMIB() : base(ATMI.TPEMIB) {}
    }
}
