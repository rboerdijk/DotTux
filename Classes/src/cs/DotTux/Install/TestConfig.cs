/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using DotTux;
using System;
using System.IO;
using System.Net;

namespace DotTux.Install
{
    public class TestConfig
    {
	public static void Main(string[] args)
	{
	    string TUXDIR = TUX.tuxgetenv("TUXDIR");
	    if (TUXDIR == null) {
		Console.WriteLine("ERROR: Environment variable TUXDIR not set");
		Environment.Exit(1);
	    }

	    string APPDIR = Environment.CurrentDirectory;

	    string TUXCONFIG = APPDIR + "\\TUXCONFIG";

	    string UBBCONFIG = APPDIR + "\\test.ubb";

	    Console.WriteLine("Creating " + UBBCONFIG);

	    string hostName = Dns.GetHostName().ToUpper();

	    StreamWriter ubb = File.CreateText(UBBCONFIG);
	    try {
		ubb.WriteLine("*RESOURCES");
		ubb.WriteLine();
		ubb.WriteLine("IPCKEY\t" + 0xCAFE);
		ubb.WriteLine("MODEL\tSHM");
		ubb.WriteLine("MASTER\tmachine");
		ubb.WriteLine();
		ubb.WriteLine("*MACHINES");
		ubb.WriteLine();
		ubb.WriteLine(hostName);
		ubb.WriteLine("\tLMID=machine");
		ubb.WriteLine("\tTUXDIR=\"" + TUXDIR + "\"");
		ubb.WriteLine("\tAPPDIR=\"" + APPDIR + "\"");
		ubb.WriteLine("\tTUXCONFIG=\"" + TUXCONFIG + "\"");
		ubb.WriteLine();
		ubb.WriteLine("*GROUPS");
		ubb.WriteLine();
		ubb.WriteLine("TESTGRP");
		ubb.WriteLine("\tLMID=machine");
		ubb.WriteLine("\tGRPNO=1");
		ubb.WriteLine();
		ubb.WriteLine("*SERVERS");
		ubb.WriteLine();
		ubb.WriteLine("DotServer");
		ubb.WriteLine("\tSRVGRP=TESTGRP");
		ubb.WriteLine("\tSRVID=1");
		ubb.WriteLine("\tCLOPT=\"-- -s TEST DotTux "
		    + "DotTux.Install.TestServer\"");
		ubb.WriteLine();
		ubb.WriteLine("*SERVICES");
	    } finally {
		ubb.Close();
	    }
	}
    }
}
