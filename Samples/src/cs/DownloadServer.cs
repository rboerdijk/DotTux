/*
 * DownloadServer.cs
 * 
 * The DownloadServer class shown below is a conversational Tuxedo server that allows
 * clients to download files from the machine were the server is running. This class 
 * shows how to write conversational Tuxedo servers using DotTux. 
 * In particular, this class shows how to use the DotTux.Atmi.ATMI.tpsend() method.
 * 
 * A download session proceeds as follows:
 * 
 *   1. The client connects to the conversational DOWNLOAD service, sending the name 
 *      of the remote file to download as part of the connect request.
 * 
 *   2. The DOWNLOAD service sends back the contents of the requested file in fixed
 *      size chunks.
 * 
 *   3. The DOWNLOAD service terminates by returning a NULL message after sending 
 *      the full contents of the requested file.
 */

using DotTux.Atmi;
using DotTux;
using System.IO;

public class DownloadServer
{
    // The DOWNLOAD service routine

    public static void DOWNLOAD(TPSVCINFO rqst)
    {
        if ((rqst.flags & ATMI.TPSENDONLY) == 0) 
        {
            TUX.userlog("ERROR: Client not in receive mode"); 
            ATMI.tpreturn(ATMI.TPFAIL, 0, null, 0, 0); // Return null message as client is not in receive mode
            return;
        }
	
        string fileName = StringUtils.ReadStringBuffer(rqst.data, rqst.len);
        try 
        {
            FileStream fs = File.OpenRead(fileName);
            try 
            {
                Send(fs, rqst.cd);
            } 
            finally 
            {
                fs.Close();
            }
            ATMI.tpreturn(ATMI.TPSUCCESS, 0, null, 0, 0);
        } 
        catch (FileNotFoundException eFileNotFound) 
        {
            ServerUtils.ReturnReply(ATMI.TPFAIL, 0, eFileNotFound.Message);
        }
    }

    // Reads data from a FileStream and sends it across a conversational connection.
    
    private static void Send(FileStream fs, int cd)
    {
        byte[] bytes = new byte[4096];

        ByteBuffer buffer = ATMI.tpalloc("CARRAY", null, 4096);
        try 
        {
            while (true) 
            {
                int len = fs.Read(bytes, 0, 4096);
                if (len == 0) 
                { // End of file
                    return;
                }
                buffer.PutBytes(bytes, 0, len);
                ATMI.tpsend(cd, buffer, len, 0);
            }
        } 
        finally 
        {
            ATMI.tpfree(buffer);
        }
    }
}
