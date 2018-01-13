/*
 * Copyright 2003, 2004 OTP Systems Oy. All rights reserved.
 */

using System.Text;
using System.Runtime.InteropServices;

using DotTux;

namespace DotTux.Atmi
{
    /// <summary>
    /// The .NET version of Tuxedo's TPINIT data structure.
    /// </summary>
    
    public class TPINIT
    {
        /// <summary>
        /// User name for logon.
        /// </summary>
        
	public string usrname;

        /// <summary>
        /// Client class name.
        /// </summary>
        
	public string cltname;
        
        /// <summary>
        /// Password for logon.
        /// </summary>
        
	public string passwd;
        
        /// <summary>
        /// Name of server group to run in.
        /// </summary>
        
	public string grpname;
        
        /// <summary>
        /// Connect flags.
        /// </summary>
        
	public int flags;
        
        /// <summary>
        /// Additional authentication data for logon.
        /// </summary>
        
	public byte[] data;

	private static int usrnameOfs = 0;
	private static int cltnameOfs = usrnameOfs + 32;
	private static int passwdOfs = cltnameOfs + 32;
	private static int grpnameOfs = passwdOfs + 32;
	private static int flagsOfs = grpnameOfs + 32;
	private static int datalenOfs = flagsOfs + 4;
	private static int dataOfs = datalenOfs + 4;

	private static void writeString(ByteBuffer buffer, int ofs,
	    string s)
	{
	    if (s == null) {
		buffer.PutByte(ofs, 0); // empty string
	    } else {
		byte[] bytes = Encoding.Default.GetBytes(s);
		if (bytes.Length > 30) {
		    buffer.PutBytes(ofs, bytes, 0, 30);
		    buffer.PutByte(ofs + 30, 0); // zero terminator
		} else {
		    buffer.PutBytes(ofs, bytes);
		    buffer.PutByte(ofs + bytes.Length, 0); // zero terminator
		}
	    }
	}

	internal void write(ByteBuffer buffer)
	{
	    writeString(buffer, usrnameOfs, usrname);
	    writeString(buffer, cltnameOfs, cltname);
	    writeString(buffer, passwdOfs, passwd);
	    writeString(buffer, grpnameOfs, grpname);
	    Marshal.WriteInt32(buffer.ptr, flagsOfs, flags);
	    if (data == null) {
		Marshal.WriteInt32(buffer.ptr, datalenOfs, 0);
	    } else {
		Marshal.WriteInt32(buffer.ptr, datalenOfs, data.Length);
		buffer.PutBytes(dataOfs, data);
	    }
	}

	internal void read(ByteBuffer buffer)
	{
	    flags = Marshal.ReadInt32(buffer.ptr, flagsOfs);
	}
    }
}
