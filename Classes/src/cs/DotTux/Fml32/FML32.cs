/* 
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Text;
using System.Runtime.InteropServices;

using DotTux;

namespace DotTux.Fml32
{
    /// <summary>
    /// Provides methods and constants for executing FML32 system calls. 
    /// </summary>

    public class FML32
    {
	private FML32() 
	{
	    // Nothing to do, just make sure it is not public.
	}

	/*
	 * The symbol table below was generated using OTPTuxSymbolDumper
	 */

	/// <summary>FML field type</summary>
	public const int FLD_SHORT = 0;

	/// <summary>FML field type</summary>
	public const int FLD_LONG = 1;

	/// <summary>FML field type</summary>
	public const int FLD_CHAR = 2;

	/// <summary>FML field type</summary>
	public const int FLD_FLOAT = 3;

	/// <summary>FML field type</summary>
	public const int FLD_DOUBLE = 4;

	/// <summary>FML field type</summary>
	public const int FLD_STRING = 5;

	/// <summary>FML field type</summary>
	public const int FLD_CARRAY = 6;

	/// <summary>FML field type</summary>
	public const int FLD_PTR = 9;

	/// <summary>FML field type</summary>
	public const int FLD_FML32 = 10;

	/// <summary>FML field type</summary>
	public const int FLD_VIEW32 = 11;

	/// <summary>FML field type</summary>
	public const int FLD_MBSTRING = 12;

	/// <summary>Invalid field identifier</summary>
	public const int BADFLDID = 0;

	/// <summary>Initial field identifier for Fnext</summary>
	public const int FIRSTFLDID = 0;

	/// <summary>FML error code</summary>
	public const int FALIGNERR = 1;

	/// <summary>FML error code</summary>
	public const int FNOTFLD = 2;

	/// <summary>FML error code</summary>
	public const int FNOSPACE = 3;

	/// <summary>FML error code</summary>
	public const int FNOTPRES = 4;

	/// <summary>FML error code</summary>
	public const int FBADFLD = 5;

	/// <summary>FML error code</summary>
	public const int FTYPERR = 6;

	/// <summary>FML error code</summary>
	public const int FEUNIX = 7;

	/// <summary>FML error code</summary>
	public const int FBADNAME = 8;

	/// <summary>FML error code</summary>
	public const int FMALLOC = 9;

	/// <summary>FML error code</summary>
	public const int FSYNTAX = 10;

	/// <summary>FML error code</summary>
	public const int FFTOPEN = 11;

	/// <summary>FML error code</summary>
	public const int FFTSYNTAX = 12;

	/// <summary>FML error code</summary>
	public const int FEINVAL = 13;

	/// <summary>FML error code</summary>
	public const int FBADTBL = 14;

	/// <summary>FML error code</summary>
	public const int FBADVIEW = 15;

	/// <summary>FML error code</summary>
	public const int FVFSYNTAX = 16;

	/// <summary>FML error code</summary>
	public const int FVFOPEN = 17;

	/// <summary>FML error code</summary>
	public const int FBADACM = 18;

	/// <summary>FML error code</summary>
	public const int FNOCNAME = 19;

	/// <summary>FML error code</summary>
	public const int FEBADOP = 20;

	internal static int Ferror {
	    get { return DotTuxInterop.get_Ferror32(); }
	}

        static FException NewFException(int err)
        {
	    switch (err) {
	        case FML32.FALIGNERR:
		    throw new FALIGNERR();
	        case FML32.FNOTFLD:
		    throw new FNOTFLD();
	        case FML32.FNOSPACE:
		    throw new FNOSPACE();
	        case FML32.FNOTPRES:
		    throw new FNOTPRES();
	        case FML32.FBADFLD:
		    throw new FBADFLD();
	        case FML32.FTYPERR:
		    throw new FTYPERR();
	        case FML32.FEUNIX:
		    throw new FEUNIX();
	        case FML32.FBADNAME:
		    throw new FBADNAME();
	        case FML32.FMALLOC:
		    throw new FMALLOC();
	        case FML32.FSYNTAX:
		    throw new FSYNTAX();
	        case FML32.FFTOPEN:
		    throw new FFTOPEN();
	        case FML32.FFTSYNTAX:
		    throw new FFTSYNTAX();
	        case FML32.FEINVAL:
		    throw new FEINVAL();
	        case FML32.FBADTBL:
		    throw new FBADTBL();
	        case FML32.FBADVIEW:
		    throw new FBADVIEW();
	        case FML32.FVFSYNTAX:
		    throw new FVFSYNTAX();
	        case FML32.FVFOPEN:
		    throw new FVFOPEN();
	        case FML32.FBADACM:
		    throw new FBADACM();
	        case FML32.FNOCNAME:
		    throw new FNOCNAME();
	        case FML32.FEBADOP:
		    throw new FEBADOP();
	        default:
	            return new FException(err);
	    }
	}

	internal static FException NewFException()
	{
	    return NewFException(Ferror);
	}

	internal static string Fstrerror(int err)
	{
	    IntPtr str = DotTuxInterop.Fstrerror32(err);
	    if (str == IntPtr.Zero) {
		return null;
	    }
	    return Marshal.PtrToStringAnsi(str);
	}

	/*-----------------*/
	/* SFadd() methods */
	/*-----------------*/

	internal static bool SFaddByte(ByteBuffer fbfr, int fldid,
	    byte value)
	{
	    if (DotTuxInterop.CFaddByte32(fbfr.ptr, fldid, value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFaddShort(ByteBuffer fbfr, int fldid,
	    short value)
	{
	    if (DotTuxInterop.CFaddShort32(fbfr.ptr, fldid, value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFaddInt(ByteBuffer fbfr, int fldid,
	    int value)
	{
	    if (DotTuxInterop.CFaddInt32(fbfr.ptr, fldid, value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFaddFloat(ByteBuffer fbfr, int fldid,
	    float value)
	{
	    if (DotTuxInterop.CFaddFloat32(fbfr.ptr, fldid, value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFaddDouble(ByteBuffer fbfr, int fldid,
	    double value)
	{
	    if (DotTuxInterop.CFaddDouble32(fbfr.ptr, fldid, value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFaddString(ByteBuffer fbfr, int fldid,
	    string value)
	{
	    // We use SFaddBytes() to let the underlying CFadd32() call
	    // handle the conversion of the byte array resulting from
	    // the string to a zero-terminated C string if necessary.

	    byte[] bytes = Encoding.Default.GetBytes(value);

	    return SFaddBytes(fbfr, fldid, bytes);
        }

        internal static bool SFaddBytes(ByteBuffer fbfr, int fldid,
            byte[] value)
        {
            if (DotTuxInterop.CFaddBytes32(fbfr.ptr, fldid, value, 
		    value.Length) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

        internal static bool SFadd(ByteBuffer fbfr, int fldid, object value)
        {
	    if (value is byte) {
	        return SFaddByte(fbfr, fldid, (byte) value);
	    } else if (value is short) {
	        return SFaddShort(fbfr, fldid, (short) value);
	    } else if (value is int) {
	        return SFaddInt(fbfr, fldid, (int) value);
	    } else if (value is float) {
	        return SFaddFloat(fbfr, fldid, (float) value);
	    } else if (value is double) {
	        return SFaddDouble(fbfr, fldid, (double) value);
	    } else if (value is string) {
	        return SFaddString(fbfr, fldid, (string) value);
	    } else if (value is byte[]) {
	        return SFaddBytes(fbfr, fldid, (byte[]) value);
	    } else {
	        throw new ArgumentException("Unsupported value type: "
		    + value.GetType());
	    }
	}

        /*----------------*/
        /* Fadd() methods */
        /*----------------*/

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a byte.
        /// </param>
	/// 
	/// <remarks>
        /// The given byte value is converted to match the type of the field 
        /// using the conversion rules for FML source type char summarized in 
        /// Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddByte(ByteBuffer fbfr, int fldid, byte value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddByte(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a short.
        /// </param>
        /// 
        /// <remarks>
        /// The given short value is converted to match the type of the field 
        /// using the conversion rules for FML source type short summarized in 
        /// Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddShort(ByteBuffer fbfr, int fldid, short value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddShort(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as an int.
        /// </param>
        /// 
	/// <remarks>
        /// The given int value is converted to match the type of the field 
        /// using the conversion rules for FML source type long summarized in 
        /// Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddInt(ByteBuffer fbfr, int fldid, int value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddInt(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a float.
        /// </param>
        /// 
	/// <remarks>
        /// The given float value is converted to match the type of the field 
        /// using the conversion rules for FML source type float summarized 
        /// in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddFloat(ByteBuffer fbfr, int fldid, float value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddFloat(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a double.
        /// </param>
        /// 
	/// <remarks>
        /// The given double value is converted to match the type of the field 
        /// using the conversion rules for FML source type double summarized in 
        /// Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddDouble(ByteBuffer fbfr, int fldid, 
	    double value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddDouble(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a string.
        /// </param>
        /// 
	/// <remarks>
        /// The given string value is converted to match the type of the field 
        /// using the conversion rules for FML source type string summarized in 
        /// Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddString(ByteBuffer fbfr, int fldid, 
	    string value)
        {
	    if ((fbfr == null) || (value == null)) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddString(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a byte[].
        /// </param>
        /// 
	/// <remarks>
        /// The give byte[] value is converted to match the type of the field 
        /// using the conversion rules for FML source type carray summarized in 
        /// Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void FaddBytes(ByteBuffer fbfr, int fldid, byte[] value)
        {
	    if ((fbfr == null) || (value == null)) {
		throw new ArgumentNullException();
	    }

	    if (!SFaddBytes(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a byte, short, int, 
        /// float, double, string or byte[]
        /// </param>
        /// 
        /// <remarks>
        /// The given value is converted to match the type of the field using 
        /// the conversion rules summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded 
        /// automatically when adding field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public static void Fadd(ByteBuffer fbfr, int fldid, Object value)
        {
	    if ((fbfr == null) || (value == null)) {
		throw new ArgumentNullException();
	    }

	    if (!SFadd(fbfr, fldid, value)) {
	        throw new FNOSPACE();
	    }
        }

	/*-----------------*/
	/* SFchg() methods */
	/*-----------------*/

	internal static bool SFchgByte(ByteBuffer fbfr, int fldid, int occ,
	    byte value)
	{
	    if (DotTuxInterop.CFchgByte32(fbfr.ptr, fldid, occ, 
		    value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFchgShort(ByteBuffer fbfr, int fldid, int occ,
	    short value)
	{
	    if (DotTuxInterop.CFchgShort32(fbfr.ptr, fldid, occ, 
		    value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFchgInt(ByteBuffer fbfr, int fldid, int occ,
	    int value)
	{
	    if (DotTuxInterop.CFchgInt32(fbfr.ptr, fldid, occ, 
		    value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFchgFloat(ByteBuffer fbfr, int fldid, int occ,
	    float value)
	{
	    if (DotTuxInterop.CFchgFloat32(fbfr.ptr, fldid, occ, 
		    value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFchgDouble(ByteBuffer fbfr, int fldid, int occ,
	    double value)
	{
	    if (DotTuxInterop.CFchgDouble32(fbfr.ptr, fldid, occ, 
		    value) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

	internal static bool SFchgString(ByteBuffer fbfr, int fldid, int occ,
	    string value)
	{
	    // We use SFaddBytes() to let the underlying CFadd32() call
	    // handle the conversion of the byte array resulting from
	    // the string to a zero-terminated C string if necessary.

	    byte[] bytes = Encoding.Default.GetBytes(value);

	    return SFchgBytes(fbfr, fldid, occ, bytes);
        }

        internal static bool SFchgBytes(ByteBuffer fbfr, int fldid, int occ,
            byte[] value)
        {
            if (DotTuxInterop.CFchgBytes32(fbfr.ptr, fldid, occ, value, 
		    value.Length) == -1) {
	        if (Ferror != FNOSPACE) {
		    throw NewFException();
		}
		return false;
	    }
	    return true;
	}

        internal static bool SFchg(ByteBuffer fbfr, int fldid, int occ,
	    object value)
        {
	    if (value is byte) {
	        return SFchgByte(fbfr, fldid, occ, (byte) value);
	    } else if (value is short) {
	        return SFchgShort(fbfr, fldid, occ, (short) value);
	    } else if (value is int) {
	        return SFchgInt(fbfr, fldid, occ, (int) value);
	    } else if (value is float) {
	        return SFchgFloat(fbfr, fldid, occ, (float) value);
	    } else if (value is double) {
	        return SFchgDouble(fbfr, fldid, occ, (double) value);
	    } else if (value is string) {
	        return SFchgString(fbfr, fldid, occ, (string) value);
	    } else if (value is byte[]) {
	        return SFchgBytes(fbfr, fldid, occ, (byte[]) value);
	    } else {
	        throw new ArgumentException("Unsupported value type: "
		    + value.GetType());
	    }
	}

        /*----------------*/
        /* Fchg() methods */
        /*----------------*/

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a byte.
        /// </param>
        /// 
        /// <remarks>
        /// The given byte value is converted to match the type of the field 
        /// using the conversion rules for FML source type char summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgByte(ByteBuffer fbfr, int fldid, int occ,
	    byte value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgByte(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a short.
        /// </param>
        /// 
        /// <remarks>
        /// The given short value is converted to match the type of the field 
        /// using the conversion rules for FML source type short summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgShort(ByteBuffer fbfr, int fldid, int occ,
	    short value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgShort(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as an int.
        /// </param>
        /// 
        /// <remarks>
        /// The given int value is converted to match the type of the field 
        /// using the conversion rules for FML source type long summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgInt(ByteBuffer fbfr, int fldid, int occ,
	    int value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgInt(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a float.
        /// </param>
        /// 
        /// <remarks>
        /// The given float value is converted to match the type of the field 
        /// using the conversion rules for FML source type float summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgFloat(ByteBuffer fbfr, int fldid, int occ,
	    float value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgFloat(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a double.
        /// </param>
        /// 
        /// <remarks>
        /// The given double value is converted to match the type of the field 
        /// using the conversion rules for FML source type double summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgDouble(ByteBuffer fbfr, int fldid, int occ,
	    double value)
        {
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgDouble(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a string.
        /// </param>
        /// 
        /// <remarks>
        /// The given string value is converted to match the type of the field 
        /// using the conversion rules for FML source type string summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgString(ByteBuffer fbfr, int fldid, int occ,
	    string value)
        {
	    if ((fbfr == null) || (value == null)) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgString(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a byte[].
        /// </param>
        /// 
        /// <remarks>
        /// The given byte[] value is converted to match the type of the field 
        /// using the conversion rules for FML source type carray summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void FchgBytes(ByteBuffer fbfr, int fldid, int occ,
	    byte[] value)
        {
	    if ((fbfr == null) || (value == null)) {
		throw new ArgumentNullException();
	    }

	    if (!SFchgBytes(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field occurrence, as a byte, short, int,
        /// float, double, string or byte[].
        /// </param>
        /// 
        /// <remarks>
        /// The given value is converted to match the type of the field 
        /// using the conversion rules summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOSPACE">
        /// There is not enough space in the buffer for the new field value. 
        /// Use an <see cref="FBuilder"/> if you want the buffer to be expanded automatically
        /// when setting field occurrences.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public static void Fchg(ByteBuffer fbfr, int fldid, int occ,
	    Object value)
        {
	    if ((fbfr == null) || (value == null)) {
		throw new ArgumentNullException();
	    }

	    if (!SFchg(fbfr, fldid, occ, value)) {
	        throw new FNOSPACE();
	    }
        }

	/*----------------*/
	/* Fget() methods */
	/*----------------*/

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a byte.
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to a byte using the conversion rules for FML 
        /// destination type char summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

        public static byte FgetByte(ByteBuffer fbfr, int fldid, int occ)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    byte value;

	    if (DotTuxInterop.CFgetByte32(fbfr.ptr, fldid, occ, 
		    out value) == -1) {
		throw NewFException();
	    }

	    return value;
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a short.
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to a short using the conversion rules for FML 
        /// destination type short summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

	public static short FgetShort(ByteBuffer fbfr, int fldid, int occ)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    short value;

	    if (DotTuxInterop.CFgetShort32(fbfr.ptr, fldid, occ, 
		    out value) == -1) {
		throw NewFException();
	    }

	    return value;
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as an int.
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to an int using the conversion rules for FML 
        /// destination type long summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

	public static int FgetInt(ByteBuffer fbfr, int fldid, int occ)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int value;

	    if (DotTuxInterop.CFgetInt32(fbfr.ptr, fldid, occ, 
		    out value) == -1) {
		throw NewFException();
	    }

	    return value;
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a float.
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to a float using the conversion rules for FML 
        /// destination type float summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

	public static float FgetFloat(ByteBuffer fbfr, int fldid, int occ)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    float value;

	    if (DotTuxInterop.CFgetFloat32(fbfr.ptr, fldid, occ, 
		    out value) == -1) {
		throw NewFException();
	    }

	    return value;
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a double.
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to a double using the conversion rules for FML 
        /// destination type double summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

	public static double FgetDouble(ByteBuffer fbfr, int fldid, int occ)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    double value;

	    if (DotTuxInterop.CFgetDouble32(fbfr.ptr, fldid, occ, 
		    out value) == -1) {
		throw NewFException();
	    }

	    return value;
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a string.
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to a string using the conversion rules for FML 
        /// destination type string summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

	public static string FgetString(ByteBuffer fbfr, int fldid, int occ)
	{
	    byte[] bytes = FgetBytes(fbfr, fldid, occ);

	    return Encoding.Default.GetString(bytes);
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a byte[].
        /// </returns>
        /// 
	/// <remarks>
        /// The value of the field occurrence is converted to a byte[] using the conversion rules for FML 
        /// destination type carray summarized in Table 5-2 of the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

	public static byte[] FgetBytes(ByteBuffer fbfr, int fldid, int occ)
	{
            if (fbfr == null) {
	        throw new ArgumentNullException();
	    }

	    int len;

	    IntPtr valuePtr = DotTuxInterop.CFfindBytes32(fbfr.ptr, fldid, occ,
		out len);
	    if (valuePtr == IntPtr.Zero) {
		throw NewFException();
	    }

	    byte[] value = new byte[len];

	    Marshal.Copy(valuePtr, value, 0, len);

	    return value;
	}

        /// <summary>
        /// Returns the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The value of the field occurrence, as a byte, short, int,
        /// float, double, string or byte[].
        /// </returns>
        /// 
	/// <remarks>
        /// The type of the returned value depends on the type of the
        /// FML field as specified by the following table.
        /// <list type="table">
        ///   <listheader>
        ///     <term>FML field type</term>
        ///     <term>Return type</term>
        ///   </listheader>
        ///   <item>
        ///     <term>char</term>
        ///     <term>byte</term>
        ///   </item>
        ///   <item>
        ///     <term>short</term>
        ///     <term>short</term>
        ///   </item>
        ///   <item>
        ///     <term>long</term>
        ///     <term>int</term>
        ///   </item>
        ///   <item>
        ///     <term>float</term>
        ///     <term>float</term>
        ///   </item>
        ///   <item>
        ///     <term>double</term>
        ///     <term>double</term>
        ///   </item>
        ///   <item>
        ///     <term>string</term>
        ///     <term>string</term>
        ///   </item>
        ///   <item>
        ///     <term>carray</term>
        ///     <term>byte[]</term>
        ///   </item>
        /// </list>
	/// </remarks>
	/// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFget32(3fml) manual page.
        /// </exception>

        public static object Fget(ByteBuffer fbfr, int fldid, int occ)
        {
	    switch (Fldtype(fldid)) {
	        case FLD_CHAR:
		    return FgetByte(fbfr, fldid, occ);
	        case FLD_SHORT:
		    return FgetShort(fbfr, fldid, occ);
	        case FLD_LONG:
		    return FgetInt(fbfr, fldid, occ);
	        case FLD_FLOAT:
		    return FgetFloat(fbfr, fldid, occ);
	        case FLD_DOUBLE:
		    return FgetDouble(fbfr, fldid, occ);
	        case FLD_STRING:
		    return FgetString(fbfr, fldid, occ);
	        case FLD_CARRAY:
		    return FgetBytes(fbfr, fldid, occ);
	        default:
		    throw new ArgumentException("Unsupported field type "
		        + Fldtype(fldid));
	    }
	}

	/*---------------*/
	/* Other methods */
	/*---------------*/

        /// <summary>
        /// Deletes a field occurrence from an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fdel32(3fml) manual page.
        /// </exception>

        public static void Fdel(ByteBuffer fbfr, int fldid, int occ)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (DotTuxInterop.Fdel32(fbfr.ptr, fldid, occ) == -1) {
		throw NewFException();
	    }
	}

	/// <summary>
	/// Deletes all occurrences of a particular field from an FML32 buffer. 
	/// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
	/// 
	/// <exception cref="DotTux.Fml32.FNOTPRES">
	/// The buffer does not contain any occurrences of the requested field.
	/// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fdelall32(3fml) manual page.
        /// </exception>
    
	public static void Fdelall(ByteBuffer fbfr, int fldid)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    if (DotTuxInterop.Fdelall32(fbfr.ptr, fldid) == -1) {
		throw NewFException();
	    }
	}

        /// <summary>
        /// Initializes a memory buffer as an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The memory buffer.
        /// </param>
        /// 
        /// <param name="buflen">
        /// The size of the FML32 region of the buffer;
        /// must not exceed the size of the buffer.
        /// </param>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Finit32(3fml) manual page.
        /// </exception>

        public static void Finit(ByteBuffer fbfr, int buflen)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

            if (buflen > fbfr.Size) {
                throw new ArgumentException("buflen must not exceed the size of the buffer");
            }

	    if (DotTuxInterop.Finit32(fbfr.ptr, buflen) == -1) {
		throw NewFException();
	    }
	}

        /// <summary>
        /// Returns the FML32 field identifier for a given field name. 
        /// </summary>
        /// 
        /// <param name="name">
        /// The field name.
        /// </param>
        /// 
        /// <returns>
        /// The field identifier for <paramref name="name"/>.
        /// </returns>
        /// 
        /// <exception cref="DotTux.Fml32.FBADNAME">
        /// The given field name cannot be found in the FML field tables.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fldid32(3fml) manual page.
        /// </exception>

        public static int Fldid(string name)
	{
	    if (name == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Fldid32(name);
	    if (result == BADFLDID) {
		throw NewFException();
	    }
	    return result;
	}

        /// <summary>
        /// Returns the field number of an FML32 field identifier. 
        /// </summary>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <returns>
        /// The field number of <paramref name="fldid"/>.
        /// </returns>

        public static int Fldno(int fldid)
	{
	    return DotTuxInterop.Fldno32(fldid);
	}

        /// <summary>
        /// Returns the field type of an FML32 field identifier. 
        /// </summary>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <returns>
        /// The field type of <paramref name="fldid"/>.
        /// </returns>

        public static int Fldtype(int fldid)
	{
	    return DotTuxInterop.Fldtype32(fldid);
	}

        /// <summary>
        /// Returns the length of the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="occ">
        /// The field occurrence number.
        /// </param>
        /// 
        /// <returns>
        /// The length of the value of the field occurrence.
        /// </returns>
        /// 
        /// <exception cref="DotTux.Fml32.FNOTPRES">
        /// The buffer does not contain the requested field occurrence.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Flen32(3fml) manual page.
        /// </exception>

        public static int Flen(ByteBuffer fbfr, int fldid, int occ) 
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Flen32(fbfr.ptr, fldid, occ);
	    if (result == -1) {
		throw NewFException();
	    }
	    return result;
	}

        /// <summary>
        /// Constructs an FML32 field identifier from a field type and field number. 
        /// </summary>
        /// 
        /// <param name="fldtype">
        /// The field type.
        /// </param>
        /// 
        /// <param name="fldno">
        /// The field number.
        /// </param>
        /// 
        /// <returns>
        /// The field identifier constructed from <paramref name="fldtype"/>
        /// and <paramref name="fldno"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fmkfldid32(3fml) manual page.
        /// </exception>

        public static int Fmkfldid(int fldtype, int fldno)
	{
	    int result = DotTuxInterop.Fmkfldid32(fldtype, fldno);
	    if (result == BADFLDID) {
		throw NewFException();
	    }
	    return result;
	}

	internal static string Fldname(int fldid)
	{
	    IntPtr result = DotTuxInterop.Fname32(fldid);
	    if (result == IntPtr.Zero) {
		if (Ferror != FBADFLD) {
		    throw NewFException();
		}
		return null;
	    }
	    return Marshal.PtrToStringAnsi(result);
	}

        /// <summary>
        /// Returns the the field name for an FML32 field identifier. 
        /// </summary>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <returns>
        /// The field name for <paramref name="fldid"/>.
        /// </returns>
        /// 
        /// <exception cref="DotTux.Fml32.FBADFLD">
        /// The given field identifier is invalid or cannot be found in the FML field tables.
        /// </exception>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fname32(3fml) manual page.
        /// </exception>

        public static string Fname(int fldid)
	{
	    IntPtr result = DotTuxInterop.Fname32(fldid);
	    if (result == IntPtr.Zero) {
		throw NewFException();
	    }
	    return Marshal.PtrToStringAnsi(result);
	}

        /// <summary>
        /// Gets the next field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldidRef">
        /// The field identifier for which to get the next field occurrence.
        /// Gets updated with the field identifier of the next field occurrence.
        /// </param>
        /// 
        /// <param name="occRef">
        /// The field occurrence number for which to get the next field occurrence.
        /// Gets updated with the field occurrence number of the next field occurrence.
        /// </param>
        /// 
        /// <returns>
        /// True if the given field occurrence has a next field occurrence, 
        /// false otherwise.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fnext32(3fml) manual page.
        /// </exception>
        /// 
        /// <example>
        /// The following C# code fragment shows how to iterate through the
        /// field occurrences in an FML32 buffer using <see cref="Fnext"/>.
        /// <code>
        /// int fldid = FML32.FIRSTFLDID;
        /// int occ = 0;
        /// 
        /// while (FML32.Fnext(fbfr, ref fldid, ref occ)) {
        ///     object value = FML32.Fget(fbfr, fldid, occ);
        ///     // Do something with value
        /// }
        /// </code>
        /// </example>

	public static bool Fnext(ByteBuffer fbfr, ref int fldidRef,
	    ref int occRef)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Fnext32(fbfr.ptr, ref fldidRef, ref occRef);
	    if (result == -1) {
		throw NewFException();
	    }

	    return (result != 0);
	}

	// Fneeded() skipped because I don't trust this method.

        /// <summary>
        /// Returns the total number of field occurrences in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <returns>
        /// The total number of field occurrences in <paramref name="fbfr"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fnum32(3fml) manual page.
        /// </exception>

        public static int Fnum(ByteBuffer fbfr)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Fnum32(fbfr.ptr);
	    if (result == -1) {
		throw NewFException();
	    }
	    return result;
	}

        /// <summary>
        /// Returns the number of occurrences of a field in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <returns>
        /// The number of occurrences of <paramref name="fldid"/> in <paramref name="fbfr"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Foccur32(3fml) manual page.
        /// </exception>

        public static int Foccur(ByteBuffer fbfr, int fldid)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Foccur32(fbfr.ptr, fldid);
	    if (result == -1) {
		throw NewFException();
	    }
	    return result;
	}

	// Fpres() skipped because of weird (i.e. absent) failure semantics

        /// <summary>
        /// Returns the size of an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <returns>
        /// The size of the FML32 region in <paramref name="fbfr"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fsizeof32(3fml) manual page.
        /// </exception>

        public static int Fsizeof(ByteBuffer fbfr)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Fsizeof32(fbfr.ptr);
	    if (result == -1) {
		throw NewFException();
	    }
	    return result;
	}

        /// <summary>
        /// Returns the name of the type of an FML field identifier. 
        /// </summary>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <returns>
        /// The name of the type of <paramref name="fldid"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Ftype32(3fml) manual page.
        /// </exception>

        public static string Ftype(int fldid)
	{
	    IntPtr str = DotTuxInterop.Ftype32(fldid);
	    if (str == IntPtr.Zero) {
		throw NewFException();
	    }
	    return Marshal.PtrToStringAnsi(str);
	}

        /// <summary>
        /// Returns the amount of unused space in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <returns>
        /// The amount of unused space in the FML32 region of <paramref name="fbfr"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Funused32(3fml) manual page.
        /// </exception>

        public static int Funused(ByteBuffer fbfr)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Funused32(fbfr.ptr);
	    if (result == -1) {
		throw NewFException();
	    }
	    return result;
	}

        /// <summary>
        /// Returns the amount of used space in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <returns>
        /// The amount of used space in the FML32 region of <paramref name="fbfr"/>.
        /// </returns>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo Fused32(3fml) manual page.
        /// </exception>

        public static int Fused(ByteBuffer fbfr)
	{
	    if (fbfr == null) {
		throw new ArgumentNullException();
	    }

	    int result = DotTuxInterop.Fused32(fbfr.ptr);
	    if (result == -1) {
		throw NewFException();
	    }
	    return result;
	}

        /// <summary>
        /// Unloads the mapping table used to resolve FML32 
        /// field identifiers to field names. 
        /// </summary>
        
	public static void Fidnm_unload()
	{
	    DotTuxInterop.Fidnm_unload32();
	}

        /// <summary>
        /// Unloads the mapping table used to resolve field names to 
        /// FML32 field identifiers. 
        /// </summary>
        
	public static void Fnmid_unload()
	{
	    DotTuxInterop.Fnmid_unload32();
	}

        /// <summary>
        /// Returns a string representation of the contents of an 
        /// FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfr">
        /// The FML32 buffer.
        /// </param>
        /// 
        /// <returns>
        /// A string representation of the contents of <paramref name="fbfr"/>.
        /// </returns>
        /// 
        /// <remarks>
        /// The actual string representation is not specified and should
        /// not be relied upon.
        /// </remarks>

	public static string ToString(ByteBuffer fbfr)
	{
	    if (fbfr == null) {
		return "null";
	    }

	    StringBuilder s = new StringBuilder();

	    int fldid = FIRSTFLDID;
	    int occ = 0;

	    s.Append('{');

	    bool isFirst = true;

	    while (Fnext(fbfr, ref fldid, ref occ)) {

		if (isFirst) {
		    isFirst = false;
		} else {
		    s.Append(", ");
		}

		string fldname = Fldname(fldid);
		if (fldname == null) {
		    s.Append(fldid);
		} else {
		    s.Append(fldname);
		}

		s.Append("=[");

		int fldtype = Fldtype(fldid);

		int occur = Foccur(fbfr, fldid);
		for (int i = 0; i < occur; i++) {

		    if (i > 0) {
			s.Append(", ");
		    }

		    switch (fldtype) {
			case FLD_CHAR:
			    s.Append(FgetByte(fbfr, fldid, i));
			    break;
			case FLD_SHORT:
			    s.Append(FgetShort(fbfr, fldid, i));
			    break;
			case FLD_LONG:
			    s.Append(FgetInt(fbfr, fldid, i));
			    break;
			case FLD_FLOAT:
			    s.Append(FgetFloat(fbfr, fldid, i));
			    break;
			case FLD_DOUBLE:
			    s.Append(FgetDouble(fbfr, fldid, i));
			    break;
			case FLD_STRING:
			    s.Append('\'');
			    s.Append(FgetString(fbfr, fldid, i));
			    s.Append('\'');
			    break;
			default:
			    s.Append("<...>");
			    break; // Required in C#
		    }
		}

		s.Append(']');

		occ = occur;
	    }

	    s.Append('}');

	    return s.ToString();
	}

        /// <summary>
        /// Registers an FML32 field mapping table at runtime. 
        /// </summary>
        /// 
        /// <param name="fieldTable">
        /// The FML field table file.
        /// </param>

        public static void AddFieldTable(string fieldTable)
	{
	    // According to section field_table(5) of the Tuxedo reference
	    // guide, the FLDTBLDIR32 environment variable is a
	    // colon-separated list of directory names. It does not say
	    // that it is a semi-colon separated list on Windows. To
	    // prevent any problems caused by directories containing colons
	    // on Windows, we do not use the FLDTBLDIR32 environment variable
	    // but simply put the absolute path name of the field table in
	    // the FIELDTBLS32 environment variable. The same section
	    // documents that this is possible and that in this case, the
	    // FLDTBLDIR32 environment variable is not consulted. This only
	    // works, however, if the field table path does not contain a
	    // comma.

	    if (fieldTable.IndexOf(',') != -1) {
		throw new ArgumentException("Field table path '" + fieldTable
		    + "' contains a comma");
	    }
	    
	    string FIELDTBLS32 = TUX.tuxgetenv("FIELDTBLS32");
	    if (FIELDTBLS32 == null) {
		FIELDTBLS32 = fieldTable;
	    } else {
		FIELDTBLS32 = FIELDTBLS32 + ',' + fieldTable;
	    }
	    TUX.tuxputenv("FIELDTBLS32=" + FIELDTBLS32);

	    // After setting FIELDTBLS32, we need to unload the current field
	    // mappings to force Fname32() and Fldid32() to reload the new
	    // list of field tables.
	    
	    Fidnm_unload();
	    Fnmid_unload();
	}
    }
}
