/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using DotTux.Atmi;
using DotTux;
using System.Text;
using System;

namespace DotTux.Install
{
    public class TestClient
    {
	public static void Main(string[] args)
	{
	    ATMI.tpinit(null);
	    try {
		ByteBuffer reply = ATMI.tpalloc("STRING", null, 1024);
		try {
		    int len;
		    ATMI.tpcall("TEST", null, 0, ref reply, out len, 0);
		    byte[] bytes = new byte[len - 1];
		    reply.GetBytes(bytes);
		    string message = Encoding.Default.GetString(bytes);
		    Console.WriteLine(message);
		} finally {
		    ATMI.tpfree(reply);
		}
	    } finally {
		ATMI.tpterm();
	    }
	}
    }
}
