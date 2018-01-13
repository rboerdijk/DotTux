/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System; // IntPtr
using System.Runtime.InteropServices; // Marshal

namespace DotTux
{
    /// <summary>
    /// Provides methods for copying bytes to and from unmanaged memory
    /// buffers.
    /// </summary>

    public class ByteBuffer
    {
	internal IntPtr ptr;

	internal int size;

	/// <exclude/>
	/// 
        /// Must be public for DotServer.

	public ByteBuffer(IntPtr ptr, int size)
	{
	    if (ptr == IntPtr.Zero) {
		throw new ArgumentException("ptr must not be IntPtr.Zero");
	    }

	    if (size < 0) {
		throw new ArgumentException("size must not be negative");
	    }

	    this.ptr = ptr;

	    this.size = size;
	}

	/// <summary>
	/// The size of the unmanaged memory buffer.
	/// </summary>

	public int Size
	{
	    get { return size; }
	}

	/// <summary>
	/// Puts a byte in the unmanaged memory buffer.
	/// </summary>
	///
	/// <param name="pos">
	/// The position in the buffer at which to put the byte;
	/// must not be negative and smaller than <see cref="Size"/>.
	/// </param>
	///
	/// <param name="b">
	/// The byte to put.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>

	public void PutByte(int pos, byte b)
	{
	    if (pos < 0) {
		throw new ArgumentException("pos must not be negative");
	    }

	    if (pos >= size) {
		throw new ArgumentException("pos must be smaller than Size");
	    }

	    Marshal.WriteByte(ptr, pos, b);
	}

	/// <summary>
	/// Copies bytes from a a byte array to the unmanaged memory buffer.
	/// </summary>
	///
	/// <param name="to">
	/// The position in the buffer at which to put the first byte;
	/// must not be negative and not exceed
	/// <see cref="Size"/> - <paramref name="len"/>.
	/// </param>
	///
	/// <param name="bytes">
	/// The byte array from which to copy the bytes; must not be null
	/// and <paramref name="bytes"/>.Length must be at least
	/// <paramref name="from"/> + <paramref name="len"/>.
	/// </param>
	///
	/// <param name="from">
	/// The position in the byte array from which to get the first byte;
	/// must not be negative and not exceed
	/// <paramref name="bytes"/>.Length - <paramref name="len"/>.
	/// </param>
	///
	/// <param name="len">
	/// The number of bytes to copy; must not be negative and
	/// not exceed <see cref="Size"/> - <paramref name="to"/> or
	/// <paramref name="bytes"/>.Length - <paramref name="from"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; len; i++) {
	///     <see cref="PutByte">PutByte</see>(to + i, bytes[from + i]);
	/// }
	/// </code>
	/// </remarks>

	public void PutBytes(int to, byte[] bytes, int from, int len)
	{
	    // Marshal.Copy checks that bytes != null, from >= 0,
	    // len >=0 and from + len <= bytes.Length => we only
	    // need to check that to >=0 and to + len <= size. 

	    if (to < 0) {
	        throw new ArgumentException("to must not be negative");
	    }

    	    if (to + len > size) {
		throw new ArgumentException("to + len must not exceed Size");
	    }

	    IntPtr toPtr = new IntPtr(ptr.ToInt32() + to);

	    Marshal.Copy(bytes, from, toPtr, len);
	}

	/// <summary>
	/// Copies bytes from a byte array to the unmanaged memory buffer.
	/// </summary>
	///
	/// <param name="to">
	/// The position in the buffer at which to put the first byte;
	/// must not be negative and not exceed
	/// <see cref="Size"/> - <paramref name="bytes"/>.Length.
	/// </param>
	///
	/// <param name="bytes">
	/// The byte array from which to copy the bytes; must not be null 
	/// and <paramref name="bytes"/>.Length must not exceed
	/// <see cref="Size"/> - <paramref name="to"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; bytes.Length; i++) {
	///     <see cref="PutByte">PutByte</see>(to + i, bytes[i]);
	/// }
	/// </code>
	/// </remarks>
	
	public void PutBytes(int to, byte[] bytes)
	{
	    PutBytes(to, bytes, 0, bytes.Length);
	}

	/// <summary>
	/// Copies bytes from a byte array to the unmanaged memory buffer.
	/// </summary>
	///
	/// <param name="bytes">
	/// The byte array from which to copy the bytes; must not be null
	/// and <paramref name="bytes"/>.Length must be at least
	/// <paramref name="from"/> + <paramref name="len"/>.
	/// </param>
	///
	/// <param name="from">
	/// The position in the byte array from which to get the first byte;
	/// must not be negative and not exceed
	/// <paramref name="bytes"/>.Length - <paramref name="len"/>.
	/// </param>
	///
	/// <param name="len">
	/// The number of bytes to copy; must not be negative and
	/// not exceed <see cref="Size"/> or
	/// <paramref name="bytes"/>.Length - <paramref name="from"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; len; i++) {
	///     <see cref="PutByte">PutByte</see>(i, bytes[from + i]);
	/// }
	/// </code>
	/// </remarks>
	
	public void PutBytes(byte[] bytes, int from, int len)
	{
	    // Marshal.Copy checks that bytes != null, from >= 0, len >=0
	    // and from + len <= bytes.Length => we only need to check
	    // that len <= size.
	    
	    if (len > size) {
		throw new ArgumentException("len must not exceed Size");
	    }

	    Marshal.Copy(bytes, from, ptr, len);
	}

	/// <summary>
	/// Copies bytes from a byte array to the unmanaged memory buffer.
	/// </summary>
	///
	/// <param name="bytes">
	/// The bytes array from which to copy the bytes; must not be null 
	/// and <paramref name="bytes"/>.Length must not exceed
	/// <see cref="Size"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; bytes.Length; i++) {
	///     <see cref="PutByte">PutByte</see>(i, bytes[i]);
	/// }
	/// </code>
	/// </remarks>
	
	public void PutBytes(byte[] bytes)
	{
	    PutBytes(bytes, 0, bytes.Length);
	}

	/// <summary>
	/// Gets a byte from the unmanaged memory buffer.
	/// </summary>
	///
	/// <param name="pos">
	/// The position in the buffer from which to get the byte;
	/// must not be negative and smaller than <see cref="Size"/>.
	/// </param>
	///
	/// <returns>
	/// The byte at the given position in the buffer.
	/// </returns>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>

	public byte GetByte(int pos)
	{
	    if (pos < 0) {
		throw new ArgumentException("pos must not be negative");
	    }

	    if (pos >= size) {
		throw new ArgumentException("pos must be smaller than Size");
	    }

	    return Marshal.ReadByte(ptr, pos);
	}

	/// <summary>
	/// Copies bytes from the unmanaged memory buffer to a byte array.
	/// </summary>
	///
	/// <param name="from">
	/// The position in the buffer from which to get the first byte;
	/// must not be negative and not exceed
	/// <see cref="Size"/> - <paramref name="len"/>.
	/// </param>
	///
	/// <param name="bytes">
	/// The byte array into which to copy the bytes; must not be null
	/// and <paramref name="bytes"/>.Length must be at least
	/// <paramref name="to"/> + <paramref name="len"/>.
	/// </param>
	///
	/// <param name="to">
	/// The position in the byte array at which to put the first byte;
	/// must not be negative and not exceed
	/// <paramref name="bytes"/>.Length - <paramref name="len"/>.
	/// </param>
	///
	/// <param name="len">
	/// The number of bytes to copy; must not be negative and
	/// not exceed <see cref="Size"/> - <paramref name="from"/> or
	/// <paramref name="bytes"/>.Length - <paramref name="to"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; len; i++) {
	///     bytes[to + i] = <see cref="GetByte">GetByte</see>(from + i);
	/// }
	/// </code>
	/// </remarks>

	public void GetBytes(int from, byte[] bytes, int to, int len)
	{
	    // Marshal.Copy checks that bytes != null, to >= 0, len >=0
	    // and to + len <= bytes.Length => we only need to check
	    // that from >=0 and from + len <= size. 

	    if (from < 0) {
		throw new ArgumentException("from must not be negative");
	    }

	    if (from + len > size) {
		throw new ArgumentException("from + len must not exceed Size");
	    }

	    IntPtr fromPtr = new IntPtr(ptr.ToInt32() + from);

	    Marshal.Copy(fromPtr, bytes, to, len);
	}

	/// <summary>
	/// Copies bytes from the unmanaged memory buffer to a byte array.
	/// </summary>
	///
	/// <param name="from">
	/// The position in the buffer from which to get the first byte;
	/// must not be negative and not exceed
	/// <see cref="Size"/> - <paramref name="bytes"/>.Length.
	/// </param>
	///
	/// <param name="bytes">
	/// The byte array into which to copy the bytes; must not be null 
	/// and <paramref name="bytes"/>.Length must not exceed
	/// <see cref="Size"/> - <paramref name="from"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; bytes.Length; i++) {
	///     bytes[i] = <see cref="GetByte">GetByte</see>(from + i);
	/// }
	/// </code>
	/// </remarks>
	
	public void GetBytes(int from, byte[] bytes)
	{
	    GetBytes(from, bytes, 0, bytes.Length);
	}

	/// <summary>
	/// Copies bytes from the unmanaged memory buffer to a byte array.
	/// </summary>
	///
	/// <param name="bytes">
	/// The byte array into which to copy the bytes; must not be null
	/// and <paramref name="bytes"/>.Length must be at least
	/// <paramref name="to"/> + <paramref name="len"/>.
	/// </param>
	///
	/// <param name="to">
	/// The position in the byte array at which to put the first byte;
	/// must not be negative and not exceed
	/// <paramref name="bytes"/>.Length - <paramref name="len"/>.
	/// </param>
	///
	/// <param name="len">
	/// The number of bytes to copy; must not be negative and
	/// not exceed <see cref="Size"/> or
	/// <paramref name="bytes"/>.Length - <paramref name="to"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; len; i++) {
	///     bytes[to + i] = <see cref="GetByte">GetByte</see>(i);
	/// }
	/// </code>
	/// </remarks>
	
	public void GetBytes(byte[] bytes, int to, int len)
	{
	    // Marshal.Copy checks that bytes != null, to >= 0, len >=0
	    // and to + len <= bytes.Length => we only need to check
	    // that len <= size.
	    
	    if (len > size) {
		throw new ArgumentException("len must not exceed Size");
	    }

	    Marshal.Copy(ptr, bytes, to, len);
	}

	/// <summary>
	/// Copies bytes from the unmanaged memory buffer to a byte array.
	/// </summary>
	///
	/// <param name="bytes">
	/// The byte array into which to copy the bytes; must not be null 
	/// and <paramref name="bytes"/>.Length must not exceed
	/// <see cref="Size"/>.
	/// </param>
	///
        /// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
	///
	/// <remarks>
	/// This method is functionally equivalent with the following code:
	/// <code>
	/// for (int i = 0; i &lt; bytes.Length; i++) {
	///     bytes[i] = <see cref="GetByte">GetByte</see>(i);
	/// }
	/// </code>
	/// </remarks>
	
	public void GetBytes(byte[] bytes)
	{
	    GetBytes(bytes, 0, bytes.Length);
	}
    }
}
