/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using DotTux;

namespace DotTux.Fml32
{
    /// <summary>
    /// Provides methods for populating FML32 buffers.
    /// </summary>
    /// 
    /// <remarks>
    /// The FBuilder class provides methods for adding new field occurrences 
    /// to an FML32 buffer and changing the values of existing field occurrences 
    /// in an FML32 buffer. These methods call upon the abstract <see cref="realloc"/> method 
    /// to automatically enlarge the involved buffer if necessary. 
    /// Derived classes must provide an implementation of the <see cref="realloc"/> method 
    /// for a particular type of memory buffer. 
    /// The <see cref="TPFBuilder"/> class, for example, provides a <see cref="TPFBuilder.realloc"/>
    /// implementation of for Tuxedo typed buffers.
    /// </remarks>
    
    public abstract class FBuilder
    {
        /// <summary>
        /// Initializes a new instance of the FBuilder class.
        /// </summary>
        
        protected FBuilder()
        {
        }

        /// <summary>
        /// Reallocates a memory buffer.
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The memory buffer to reallocate.
        /// Gets updated with the reallocated memory buffer.
        /// </param>
        /// 
        /// <param name="newSize">
        /// The new size of the buffer.
        /// </param>

        public abstract ByteBuffer realloc(ByteBuffer fbfrRef, int newSize);

	private void grow(ref ByteBuffer fbfrRef)
	{
	    fbfrRef = realloc(fbfrRef, (int) (FML32.Fsizeof(fbfrRef) * 1.5));
	}

	/*----------------*/
	/* Fadd() methods */
	/*----------------*/

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// using the conversion rules for FML source type char summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
	/// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public void FaddByte(ref ByteBuffer fbfrRef, int fldid, byte value)
	{
	    while (!FML32.SFaddByte(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// using the conversion rules for FML source type short summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

	public void FaddShort(ref ByteBuffer fbfrRef, int fldid, short value)
	{
	    while (!FML32.SFaddShort(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// using the conversion rules for FML source type long summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

	public void FaddInt(ref ByteBuffer fbfrRef, int fldid, int value)
	{
	    while (!FML32.SFaddInt(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// using the conversion rules for FML source type float summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

	public void FaddFloat(ref ByteBuffer fbfrRef, int fldid, float value)
	{
	    while (!FML32.SFaddFloat(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// using the conversion rules for FML source type double summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

	public void FaddDouble(ref ByteBuffer fbfrRef, int fldid, double value)
	{
	    while (!FML32.SFaddDouble(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// using the conversion rules for FML source type string summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public void FaddString(ref ByteBuffer fbfrRef, int fldid, string value)
	{
	    while (!FML32.SFaddString(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
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
        /// The given byte[] value is converted to match the type of the field 
        /// using the conversion rules for FML source type carray summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

	public void FaddBytes(ref ByteBuffer fbfrRef, int fldid, byte[] value)
	{
	    while (!FML32.SFaddBytes(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Adds a field to an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// added field.
        /// </param>
        /// 
        /// <param name="fldid">
        /// The field identifier.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the field, as a byte, short, int,
        /// float, double, string or byte[].
        /// </param>
        /// 
        /// <remarks>
        /// The given value is converted to match the type of the field 
        /// using the conversion rules summarized in Table 5-2 of 
        /// the Tuxedo FML programming guide. 
	/// </remarks>
        /// 
        /// <exception cref="FException">
        /// See the Tuxedo CFadd32(3fml) manual page.
        /// </exception>

        public void Fadd(ref ByteBuffer fbfrRef, int fldid, object value)
	{
	    while (!FML32.SFadd(fbfrRef, fldid, value)) {
		grow(ref fbfrRef);
	    }
	}

	/*----------------*/
	/* Fchg() methods */
	/*----------------*/

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public void FchgByte(ref ByteBuffer fbfrRef, int fldid, int occ,
	    byte value)
	{
	    while (!FML32.SFchgByte(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

	public void FchgShort(ref ByteBuffer fbfrRef, int fldid, int occ,
	    short value)
	{
	    while (!FML32.SFchgShort(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

	public void FchgInt(ref ByteBuffer fbfrRef, int fldid, int occ,
	    int value)
	{
	    while (!FML32.SFchgInt(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

	public void FchgFloat(ref ByteBuffer fbfrRef, int fldid, int occ,
	    float value)
	{
	    while (!FML32.SFchgFloat(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

	public void FchgDouble(ref ByteBuffer fbfrRef, int fldid, int occ,
	    double value)
	{
	    while (!FML32.SFchgDouble(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

	public void FchgString(ref ByteBuffer fbfrRef, int fldid, int occ,
	    string value)
	{
	    while (!FML32.SFchgString(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

	public void FchgBytes(ref ByteBuffer fbfrRef, int fldid, int occ,
	    byte[] value)
	{
	    while (!FML32.SFchgBytes(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}

        /// <summary>
        /// Sets the value of a field occurrence in an FML32 buffer. 
        /// </summary>
        /// 
        /// <param name="fbfrRef">
        /// The FML32 buffer.
        /// Gets reallocated if needed to accomodate the
        /// new field occurrence value.
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
        /// <exception cref="FException">
        /// See the Tuxedo CFchg32(3fml) manual page.
        /// </exception>

        public void Fchg(ref ByteBuffer fbfrRef, int fldid, int occ, object value)
	{
	    while (!FML32.SFchg(fbfrRef, fldid, occ, value)) {
		grow(ref fbfrRef);
	    }
	}
    }
}
