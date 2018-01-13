/*
 * UnsolClient.cs
 * 
 * The UnsolClient class shown below is a Tuxedo client that 
 * receives unsolicited messages and prints them to the screen. 
 * This class shows how to handle unsolicited messages using 
 * DotTux and DotTux Workstation. In particular, this class shows:
 * 
 *   - How to write an unsolicited message handler (tpunsol).
 * 
 *   - How to register an unsolicted message handler using the
 *     DotTux.Atmi.ATMI.tpsetunsol() method.
 * 
 *   - How to trigger unsolicited message handling using the
 *     DotTux.Atmi.ATMI.tpchkunsol() method.
 * 
 * This class is designed to work with a Tuxedo service that
 * sends an unsolicited message back to the client as part of
 * its operation.
 */

using DotTux.Atmi;
using DotTux;
using System.Threading;
using System;

public class UnsolClient
{
    // This is the unsollicited message handling method
    
    public static void tpunsol(ByteBuffer data, int len, int flags)
    {
        Console.WriteLine("Received unsolicited message: " + StringUtils.ReadStringBuffer(data, len));
    }

    private static void WaitForMessages(int timeout)
    {
        while (timeout > 0) 
        {
            Console.WriteLine("Waiting for unsolicited message(s)");
            Thread.Sleep(1000);
            if (ATMI.tpchkunsol() > 0) 
            {
                return;
            }
            timeout--;
        }
        Console.WriteLine("Giving up");
    }

    public static void Main(string[] args)
    {
        if (args.Length != 2) 
        {
            Console.WriteLine("Usage: UnsolClient <service> <message>");
            Environment.Exit(1);
        }

        string service = args[0];
        string message = args[1];

        TPINIT tpinfo = new TPINIT();
        tpinfo.cltname = "sample";

        ATMI.tpinit(tpinfo);
        try 
        {
            ATMI.tpsetunsol(new UnsolHandler(tpunsol));
            try 
            {
                ByteBuffer data = StringUtils.NewStringBuffer(message);
                try 
                {
                    Console.WriteLine("Sending '" + message + "' to service " + service);
                    int cd = ATMI.tpacall(service, data, 0, 0);
	            
                    WaitForMessages(10);
	            
                    int len;
                    ATMI.tpgetrply(ref cd, ref data, out len, 0);
                    message = StringUtils.ReadStringBuffer(data, len);
                    Console.WriteLine("Returned string is: " + message);
                } 
                finally 
                {
                    ATMI.tpfree(data);
                }
            } 
            finally 
            {
                ATMI.tpsetunsol(null);
            }
        } 
        finally 
        {
            ATMI.tpterm();
        }
    }
}
