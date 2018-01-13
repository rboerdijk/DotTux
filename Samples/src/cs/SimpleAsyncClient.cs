/*
 * SimpleAsyncClient.cs
 * 
 * The SimpleAsyncClient class shown below is a variant of the SimpleClient
 * class that calls the TOUPPER service asynchronously. This class shows
 * how to call Tuxedo services asynchronously using DotTux and DotTux
 * Workstation. In particular, this class shows how to use the 
 * DotTux.Atmi.ATMI.tpacall() and DotTux.Atmi.ATMI.tpgetrply() methods.
 */

using DotTux.Atmi;
using DotTux;
using System;

public class SimpleAsyncClient
{
    public static void Main(string[] args)
    {
        if (args.Length != 1) 
        {
            Console.WriteLine("Usage: SimpleAsyncClient <message>");
            Environment.Exit(1);
        }

        string message = args[0];
        
        ATMI.tpinit(null);
        try 
        {
            int cd;
            ByteBuffer sendbuf = StringUtils.NewStringBuffer(message);
            try 
            {
                Console.WriteLine("Sending '" + message + "' to service TOUPPER");
                cd = ATMI.tpacall("TOUPPER", sendbuf, 0, 0);
            } 
            finally 
            {
                ATMI.tpfree(sendbuf);
            }
            
            ByteBuffer rcvbuf = ATMI.tpalloc("STRING", null, 256);
            try 
            {
                int rcvlen;
                ATMI.tpgetrply(ref cd, ref rcvbuf, out rcvlen, 0);
                message = StringUtils.ReadStringBuffer(rcvbuf, rcvlen);
                Console.WriteLine("Returned string is: " + message);
            } 
            finally 
            {
                ATMI.tpfree(rcvbuf);
            }
        } 
        finally 
        {
            ATMI.tpterm();
        }
    }
}
