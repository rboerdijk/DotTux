/*
 * Copyright 2003, 2004 OTP Systems Oy. All rights reserved.
 */

using System.Runtime.InteropServices;

namespace DotTux.Atmi
{
    /// <summary>
    /// The .NET version of Tuxedo's TPEVCTL data structure.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public class TPEVCTL
    {
        /// <summary>
        /// Indicates which fields are set.
        /// </summary>
         
        public int flags;

        /// <summary>
        /// Service name or queue space name.
        /// </summary>
         
	public string name1;

        /// <summary>
        /// Queue name.
        /// </summary>
         
	public string name2;
        
        /// <summary>
        /// Queue control parameters.
        /// </summary>  
	
        public TPQCTL qctl;
    }
}
