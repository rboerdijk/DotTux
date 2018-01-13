/*
 * StringUtils.cs
 * 
 * The StringUtils class shown below provides a collection of utility methods
 * for dealing with Tuxedo STRING buffers in .NET.
 */

using DotTux.Atmi;
using DotTux;
using System.Text;

public class StringUtils
{
    // Creates a STRING buffer and fills it with the given string
    
    public static ByteBuffer NewStringBuffer(string s)
    {
        byte[] bytes = Encoding.Default.GetBytes(s); // Convert to single-byte character sequence
        ByteBuffer buffer = ATMI.tpalloc("STRING", null, bytes.Length + 1); // One byte extra for terminating zero
        buffer.PutBytes(bytes);
        buffer.PutByte(bytes.Length, 0); // Terminating zero
        return buffer;
    }
    
    // Reads a string from a STRING buffer
    
    public static string ReadStringBuffer(ByteBuffer buffer, int len)
    {
        byte[] bytes = new byte[len - 1]; // Don't read terminating zero
        buffer.GetBytes(bytes);
        return Encoding.Default.GetString(bytes);
    }
}
