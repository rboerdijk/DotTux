/*
 * Copyright 2003, 2004 OTP Systems Oy. All rights reserved.
 */

using System.Runtime.InteropServices;

namespace DotTux.Atmi
{
    /// <summary>
    /// The .NET version of Tuxedo's TPQCTL data structure.
    /// </summary>

    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
    public class TPQCTL
    {
        /// <summary>
        /// Indicates which fields are set.
        /// </summary>
        
	public int flags;
        
        /// <summary>
        /// Absolute or relative dequeuing time for queued message.
        /// </summary>
        
	public int deq_time;
        
        /// <summary>
        /// Priority of queued message.
        /// </summary>
	
        public int priority;
        
        /// <summary>
        /// Reason for failure of queuing operation.
        /// </summary>
	
        public int diagnostic;
        
        /// <summary>
        /// Message id of queued message.
        /// </summary>
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
        public byte[] msgid;
        
        /// <summary>
        /// Correlation id of queued message.
        /// </summary>

        [MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
        public byte[] corrid;
        
        /// <summary>
        /// Queue name for reply message.
        /// </summary>
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=16)]
	public string replyqueue;
        
        /// <summary>
        /// Failure queue name for queued message.
        /// </summary>
        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=16)]
	public string failurequeue;
        
        /// <summary>
        /// Client identifier of originating client.
        /// </summary>
	
        public CLIENTID cltid;
        
        /// <summary>
        /// Application return code for queued message.
        /// </summary>
	
        public int urcode;
        
        /// <summary>
        /// Application authentication key of originating client.
        /// </summary>
	
        public int appkey;
        
        /// <summary>
        /// Quality-of-service for queued message.
        /// </summary>
	
        public int delivery_qos;
        
        /// <summary>
        /// Quality-of-service for reply message.
        /// </summary>
	
        public int reply_qos;
        
        /// <summary>
        /// Expiration time of queued message.
        /// </summary>
	
        public int exp_time;
    }
}
