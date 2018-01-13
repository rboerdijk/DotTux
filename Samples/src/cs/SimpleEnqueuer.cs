/*
 * SimpleEnqueuer.cs
 * 
 * The SimpleEnqueuer class shown below is a Tuxedo client that enqueues a
 * message in a Tuxedo/Q queue. This class shows how to enqueue messages in 
 * Tuxedo/Q queues using DotTux and DotTux Workstation. In particular, this 
 * class shows how to use the DotTux.Atmi.TPQCTL class and the 
 * DotTux.Atmi.ATMI.tpenqueue() method.
 */

using DotTux.Atmi;
using DotTux;
using System;

public class SimpleEnqueuer
{
    public static void Main(string[] args)
    {
        if ((args.Length < 3) || (args.Length > 4)) 
        {
            Console.WriteLine("Usage: SimpleEnqueuer <qspace> <qname> <message> [<replyq>]");
            Environment.Exit(1);
        }

        string qSpace = args[0];
        string qName = args[1];
        string message = args[2];
        string replyQ = (args.Length < 4) ? null : args[3];

        ATMI.tpinit(null);
        try 
        {
            ByteBuffer data = StringUtils.NewStringBuffer(message);
            try 
            {
                TPQCTL ctl = new TPQCTL();
                ctl.flags = ATMI.TPNOFLAGS;
                if (replyQ != null) 
                {
                    ctl.flags = ctl.flags | ATMI.TPQREPLYQ;
                    ctl.replyqueue = replyQ;
                }
                ATMI.tpenqueue(qSpace, qName, ctl, data, 0, 0);
                Console.WriteLine("Enqueued '" + message + "' in " + qSpace + "." + qName);
            } 
            finally 
            {
                ATMI.tpfree(data);
            }
        } 
        finally 
        {
            ATMI.tpterm();
        }
    }
}
