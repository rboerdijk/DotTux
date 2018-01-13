/*
 * SimpleServer.cs
 * 
 * The SimpleServer class shown below is the C# version of Tuxedo's well-known
 * TOUPPER server. This class shows the basics of writing Tuxedo servers using
 * DotTux, including:
 *
 *   - How to write a server initialization method (tpsvrinit).
 * 
 *   - The use of the TUX.userlog() method to write to the Tuxedo ULOG.
 * 
 *   - How to write a service routine method (TOUPPER).
 * 
 *   - The use of the DotTux.Atmi.TPSVCINFO class for reading service request
 *     parameters.
 * 
 *   - The use of the DotTux.ByteBuffer class for reading and writing Tuxedo 
 *     buffers.
 * 
 *   - The use of the System.Text.Encoding class to translate Tuxedo C strings 
 *     into .NET Unicode strings and vice versa.
 * 
 *   - The use of the DotTux.Atmi.ATMI.tpreturn() method for terminating a
 *     service routine.
 * 
 * Instructions for compiling this class can be found in the manual page of the 
 * DotTux assembly. Instructions for running the resuling Tuxedo server assembly 
 * can be found in the manual page of the DotServer executable.
 */

using DotTux.Atmi;
using DotTux;
using System.Text;

public class SimpleServer
{
    // The server initialization method.

    public static int tpsvrinit(string[] args)
    {
        TUX.userlog("Welcome to the simple server written in C#");
        return 0;
    }
    
    // The TOUPPER service routine

    public static void TOUPPER(TPSVCINFO rqst)
    {
        ByteBuffer data = rqst.data;
        
        byte[] bytes = new byte[rqst.len - 1];
        data.GetBytes(bytes);
        string s = Encoding.Default.GetString(bytes);
        
        s = s.ToUpper();

        bytes = Encoding.Default.GetBytes(s);
        data.PutBytes(bytes);
        data.PutByte(bytes.Length, 0);
        
        ATMI.tpreturn(ATMI.TPSUCCESS, 0, data, 0, 0);
    }
}   
