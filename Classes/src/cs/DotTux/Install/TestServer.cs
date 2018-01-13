/*
 * Copyright 2004 OTP Systems Oy. All right reserved.
 */

using DotTux.Atmi;
using DotTux;
using System.Text;

namespace DotTux.Install
{
    public class TestServer
    {
	public static void TEST(TPSVCINFO svcInfo)
	{
	    string message = "Installation OK";
	    byte[] bytes = Encoding.Default.GetBytes(message);
	    ByteBuffer reply = ATMI.tpalloc("STRING", null, bytes.Length + 1);
	    reply.PutBytes(bytes);
	    reply.PutByte(bytes.Length, 0);
	    ATMI.tpreturn(ATMI.TPSUCCESS, 0, reply, 0, 0);
	}
    }
}
