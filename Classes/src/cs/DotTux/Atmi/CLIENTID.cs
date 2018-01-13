/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Runtime.InteropServices;

namespace DotTux.Atmi
{
    /// <summary>
    /// The .NET version of Tuxedo's CLIENTID data structure.
    /// </summary>
    
    [StructLayout(LayoutKind.Sequential)]
    public class CLIENTID
    {
	// The members must be public for DotServer
	
	/// <exclude/>
	
        public int clientdata0;

	/// <exclude/>
	
        public int clientdata1;

	/// <exclude/>
	
        public int clientdata2;

	/// <exclude/>
	
        public int clientdata3;

        /// <exclude/>
        
        public CLIENTID()
        {
            // Nothing to do
        }

        /// <summary>
        /// Determines whether this CLIENTID equals another object.
        /// </summary>
        /// 
        /// <param name="obj">
        /// The other object.
        /// </param>
        /// 
        /// <returns>
        /// True if the other object is also a CLIENTID and has the
        /// same value as this CLIENTID, false otherwise.
        /// </returns>
        
        public override bool Equals(Object obj)
        {
            if ((obj == null) || (GetType() != obj.GetType())) {
                return false;
            }

            CLIENTID cltid = (CLIENTID) obj;

            return (clientdata0 == cltid.clientdata0)
                && (clientdata1 == cltid.clientdata1)
                && (clientdata2 == cltid.clientdata2)
                && (clientdata3 == cltid.clientdata3);
        }

        /// <summary>
        /// Returns the hash code for this CLIENTID.
        /// </summary>
        /// 
        /// <returns>
        /// The hash code for this CLIENTID.
        /// </returns>
        
        public override int GetHashCode()
        {
            return clientdata0 ^ clientdata1 ^ clientdata2 ^ clientdata3;
        }
    }
}
