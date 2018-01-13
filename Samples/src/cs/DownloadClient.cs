/*
 * DownloadClient.cs
 * 
 * The DownloadClient class shown below is a conversational client that downloads a 
 * file from a download server. This class shows how to write a conversational
 * Tuxedo client in C#. In particular, this class shows how to use the 
 * DotTux.Atmi.Conversation class.
 * 
 * A download session proceeds as follows:
 * 
 *   1. The client connects to a conversational DOWNLOAD service, sending the name 
 *      of the remote file to download as part of the connect request.
 * 
 *   2. The DOWNLOAD service sends back the contents of the requested file in fixed
 *      size chunks. The client writes these chunks to a local file.
 * 
 *   3. The DOWNLOAD service terminates by returning a NULL message after sending 
 *      the full contents of the requested file.
 */

using DotTux.Atmi;
using DotTux;
using System.IO;
using System;

public class DownloadClient
{
    // Connects to the DOWNLOAD service, passing the name of the file to download in the connect request
    
    private static Conversation Connect(string remoteFileName)
    {
        ByteBuffer request = StringUtils.NewStringBuffer(remoteFileName);
        try 
        {
            return new Conversation("DOWNLOAD", request, 0, ATMI.TPRECVONLY);
        } 
        finally 
        {
            ATMI.tpfree(request);
        }
    }
    
    // Receives data from a Conversation and writes it to a FileStream
    
    private static void Receive(Conversation conv, FileStream fs)
    {
        byte[] bytes = new byte[4096];
        int len = 0;

        ByteBuffer buffer = ATMI.tpalloc("CARRAY", null, 4096);
        try 
        {
            while (true) 
            {
                try 
                {
                    conv.Receive(ref buffer, out len, 0);
                } 
                catch (TPEV_SVCFAIL) 
                { // A download error occurred
                    throw new IOException(StringUtils.ReadStringBuffer(buffer, len));
                } 
                catch (TPEV_SVCSUCC) 
                { // Download complete
                    Console.WriteLine();
                    return;
                }
                Console.Write('.'); // Progress indicator
                buffer.GetBytes(bytes, 0, len);
                fs.Write(bytes, 0, len);
            }
        } 
        finally 
        {
            ATMI.tpfree(buffer);
        }
    }

    public static void Main(string[] args) 
    {
        if (args.Length != 2) 
        {
            Console.WriteLine("Usage: DownloadClient <remote file> <local file>");
            Environment.Exit(1);
        }
	
        string remoteFileName = args[0];
        string localFileName = args[1];

        ATMI.tpinit(null);
        try 
        {
            Conversation conv = Connect(remoteFileName);
            try 
            {
                FileStream fs = File.OpenWrite(localFileName);
                try 
                {
                    Receive(conv, fs);
                } 
                finally 
                {
                    fs.Close();
                }
            } 
            finally 
            {
                conv.Close();
            }
        } 
        catch (IOException eIO) 
        {
            Console.WriteLine("ERROR: " + eIO.Message);
            Environment.Exit(1);
        } 
        finally 
        {
            ATMI.tpterm();
        }
    }
}
