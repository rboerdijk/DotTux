/*
 * SimpleClient.cs
 * 
 * The SimpleClient class shown below is the C# version of Tuxedo's well-known 
 * TOUPPER client. This class shows the basics of writing Tuxedo clients in C# 
 * using DotTux and DotTux Workstation, including:
 * 
 *   - The use of the DotTux.Atmi.ATMI.tpinit() and DotTux.Atmi.ATMI.tpterm()
 *     methods for connecting to and disconnecting from Tuxedo.
 * 
 *   - The use of the DotTux.Atmi.ATMI.tpalloc() and DotTux.Atmi.ATMI.tpfree()
 *     methods for allocating and deallocating Tuxedo buffers.
 * 
 *   - How to read and write Tuxedo buffers using the DotTux.ByteBuffer class.
 * 
 *   - The use of the System.Text.Encoding class for translating .NET Unicode
 *     strings into Tuxedo C strings and vice versa.
 *
 *   - The use of the DotTux.Atmi.ATMI.tpcall() method for calling Tuxedo
 *     services.
 * 
 *   - The absence of explicit error checking code as DotTux uses exceptions to 
 *     signal the occurrence of errors.
 *
 *   - The use of the try/finally construct to ensure that Tuxedo buffers are
 *     cleaned up and the client logs off properly, even if an error occurs.
 * 
 * Instructions for compiling and running this class can be found in the 
 * manual pages of the DotTux and DotTux Workstation assemblies.
 */

using DotTux.Atmi;
using DotTux;
using System.Text;
using System;

public class SimpleClient
{
    public static void Main(string[] args)
    {
        if (args.Length != 1) 
        {
            Console.WriteLine("Usage: SimpleClient <message>");
            Environment.Exit(1);
        }
        
        string message = args[0];
        
        ATMI.tpinit(null);
        try 
        {
            byte[] bytes = Encoding.Default.GetBytes(message);
            int sendlen = bytes.Length + 1; // One byte extra for terminating zero
            ByteBuffer sendbuf = ATMI.tpalloc("STRING", null, sendlen);
            try 
            {
                ByteBuffer rcvbuf = ATMI.tpalloc("STRING", null, sendlen);
                try 
                {
                    sendbuf.PutBytes(bytes);
                    sendbuf.PutByte(bytes.Length, 0); // Terminating zero
                    int rcvlen;
                    ATMI.tpcall("TOUPPER", sendbuf, 0, ref rcvbuf, out rcvlen, 0);
                    rcvbuf.GetBytes(bytes);
                    Console.WriteLine("Returned string is: " + Encoding.Default.GetString(bytes));
                } 
                finally 
                {
                    ATMI.tpfree(rcvbuf);
                }
            } 
            finally 
            {
                ATMI.tpfree(sendbuf);
            }
        } 
        finally 
        {
            ATMI.tpterm();
        }
    }
}
