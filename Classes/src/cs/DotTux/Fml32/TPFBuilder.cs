/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using DotTux;
using DotTux.Atmi;

namespace DotTux.Fml32
{
    /// <summary>
    /// Utility class for populating Tuxedo typed buffers of type FML32. 
    /// </summary>
    /// <remarks>
    /// This class provides an implementation of the abstract 
    /// FBuilder.realloc() method for Tuxedo typed buffers. 
    /// Applications do not need to instantiate this class but can directly 
    /// use the singleton referenced by the I variable. 
    /// This is illustrated by the following code fragment. 
    /// <code>
    /// ByteBuffer fbfr = ATMI.tpalloc("FML32", null, 1024);
    /// try {
    ///     TPFBuilder.I.FaddString(ref fbfr, ...);
    ///     TPFBuilder.I.FaddInt(ref fbfr, ...);
    ///     ...
    /// } finally {
    ///     ATMI.tpfree(fbfrRef.value);
    /// }
    /// </code>
    /// </remarks>
    
    public class TPFBuilder: FBuilder
    {
        private TPFBuilder()
        {
        }

        /// <summary>
        /// Reallocates the given buffer using <see cref="DotTux.Atmi.ATMI.tprealloc"/>. 
        /// </summary>
        
        public override ByteBuffer realloc(ByteBuffer fbfr, int newSize)
        {
	    return ATMI.tprealloc(fbfr, newSize);
        }

        /// <summary>
        /// Singleton TPFBuilder for direct use.
        /// </summary>
        
        public static readonly TPFBuilder I = new TPFBuilder();
    }
}
