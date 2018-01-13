/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Runtime.InteropServices;

namespace DotTux.Atmi
{
    /// <summary>
    /// The .NET version of Tuxedo's TPTRANID data structure.
    /// </summary>
    /// 
    /// <remarks>
    /// This is an opaque class without any publicly visible members.
    /// </remarks>

    [StructLayout(LayoutKind.Sequential)]
    public class TPTRANID
    {
	internal int info0;
	internal int info1;
	internal int info2;
	internal int info3;
	internal int info4;
	internal int info5;

        internal TPTRANID()
        {
            /* Must use the above fields, otherwise it does not compile */

            info0 = 0;
            info1 = 0;
            info2 = 0;
            info3 = 0;
            info4 = 0;
            info5 = 0;
        }

        /// <summary>
        /// Determines whether this TPTRANID equals another object.
        /// </summary>
        /// 
        /// <param name="obj">
        /// The other object.
        /// </param>
        /// 
        /// <returns>
        /// True if the other object is also a TPTRANID and has the
        /// same value as this TPTRANID, false otherwise.
        /// </returns>
        
        public override bool Equals(Object obj)
        {
            if ((obj == null) || (GetType() != obj.GetType())) {
                return false;
            }

            TPTRANID cltid = (TPTRANID) obj;

            return (info0 == cltid.info0)
                && (info1 == cltid.info1)
                && (info2 == cltid.info2)
                && (info3 == cltid.info3)
                && (info4 == cltid.info4)
                && (info5 == cltid.info5);
        }

        /// <summary>
        /// Returns the hash code for this TPTRANID.
        /// </summary>
        /// 
        /// <returns>
        /// The hash code for this TPTRANID.
        /// </returns>
        
        public override int GetHashCode()
        {
            return info0 ^ info1 ^ info2 ^ info3 ^ info4 ^ info5;
        }
    }
}