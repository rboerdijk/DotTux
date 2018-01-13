/*
 * SimpleSubscriber.cs
 * 
 * The SimpleSubscriber class shown below is a Tuxedo client that subscribes to
 * events posted to the Tuxedo event broker. This class shows how to subscribe 
 * to events using DotTux and DotTux Workstation. In particular, this class shows 
 * how to use the DotTux.Atmi.ATMI.tpsubscribe() method.
 */

using DotTux.Atmi;
using DotTux;
using System.Threading;
using System;

public class SimpleSubscriber
{
    public static void tpunsol(ByteBuffer data, int len, int flags)
    {
        Console.WriteLine("Received message: " + StringUtils.ReadStringBuffer(data, len));
    }

    static void ProcessMessages(int seconds)
    {
        Console.WriteLine("Waiting for message(s)");

        for (int i = 0, reps = seconds * 10; i < reps; i++) 
        {
            Thread.Sleep(100);
            ATMI.tpchkunsol();
        }
    }

    public static void Main(string[] args)
    {
        if ((args.Length < 1) || (args.Length > 2)) 
        {
            Console.WriteLine("Usage: SimpleSubscriber <eventexpr> [<filter>]");
            Environment.Exit(1);
        }

        string eventexpr = args[0];
        string filter = (args.Length < 2) ? null : args[1];

        ATMI.tpinit(null);
        try 
        {
            ATMI.tpsetunsol(new UnsolHandler(tpunsol));
            try 
            {
                Console.WriteLine("Subscribing to events matching '" + eventexpr + "'");
                int handle = ATMI.tpsubscribe(eventexpr, filter, null, 0);
                try 
                {
                    ProcessMessages(5);
                } 
                finally 
                {
                    ATMI.tpunsubscribe(handle, 0);
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
