/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using DotTux;

namespace DotTux.Atmi
{
#if WSCLIENT
    /* Skip TPSVCINFO */
#else
    /// <summary>
    /// The .NET version of Tuxedo's TPSVCINFO data structure.
    /// </summary>

    public class TPSVCINFO
    {
        /// <exclude/> 
        /// Must be public for DotServer.
        
        public TPSVCINFO()
        {
        }

        /// <summary>
        /// The name of the called service.
        /// </summary>
        
	public string name;

        /// <summary>
        /// A typed buffer containing the request data of the
        /// service call; may be null.
        /// </summary>
        
	public ByteBuffer data;

        /// <summary>
        /// The length of the data in <paramref name="data"/>.
        /// </summary>
        
	public int len;
        
        /// <summary>
        /// Service invocation flags.
        /// </summary>
        
	public int flags;
        
        /// <summary>
        /// Connection descriptor for conversation.
        /// </summary>
        
	public int cd;

        /// <summary>
        /// Application authentication key of caller.
        /// </summary>
        
	public int appkey;

        /// <summary>
        /// Client identifier of caller.
        /// </summary>
        
	public CLIENTID cltid;
    }
#endif
}
