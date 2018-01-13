/*
 * SimpleDequeuer.cs
 * 
 * The SimpleDequeuer class shown below is a Tuxedo client that dequeues
 * a message from a Tuxedo/Q queue. This class shows how to dequeue messages 
 * from Tuxedo/Q queues using DotTux and DotTux Workstation. In particular, 
 * this class shows how to use the DotTux.Atmi.TPQCTL class and the 
 * DotTux.Atmi.ATMI.tpdequeue() method.
 */

using DotTux.Atmi;
using DotTux;
using System;

public class SimpleDequeuer
{
    public static void Main(string[] args)
    {
        if (args.Length != 2) 
        {
            Console.WriteLine("Usage: SimpleDequeuer <qspace> <qname>");
            Environment.Exit(1);
        }
	
        string qSpace = args[0];
        string qName = args[1];

        ATMI.tpinit(null);
        try 
        {
            ByteBuffer data = ATMI.tpalloc("STRING", null, 512);
            try 
            {
                TPQCTL ctl = new TPQCTL();
                ctl.flags = ATMI.TPQWAIT;
                int len;
                ATMI.tpdequeue(qSpace, qName, ctl, ref data, out len, 0);
                string message = StringUtils.ReadStringBuffer(data, len);
                Console.WriteLine("Dequeued '" + message + "' from " + qSpace + "." + qName);
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
