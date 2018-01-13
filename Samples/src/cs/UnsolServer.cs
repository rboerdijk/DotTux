/*
 * UnsolServer.cs
 * 
 * The UnsolServer class shown below is a Tuxedo server that sends an unsolicited message 
 * on being called. This class shows how to send unsolicited messages using DotTux. 
 * In particular, this class shows how to use the DotTux.Atmi.ATMI.tpnotify() and 
 * DotTux.Atmi.ATMI.tpbroadcast() methods.
 */

using DotTux.Atmi;
using DotTux;

public class UnsolServer
{
    public static void NOTIFY_TOUPPER(TPSVCINFO rqst)
    {
        ByteBuffer message = StringUtils.NewStringBuffer("Your request is forwarded to the TOUPPER service");
        try 
        {
            ATMI.tpnotify(rqst.cltid, message, 0, 0);
        } 
        finally 
        {
            ATMI.tpfree(message);
        }

        ATMI.tpforward("TOUPPER", rqst.data, rqst.len, 0);
    }
    
    public static void BRDCST_TOUPPER(TPSVCINFO rqst)
    {
        ByteBuffer message = StringUtils.NewStringBuffer("Forwarding request to service TOUPPER");
        try 
        {
            ATMI.tpbroadcast(null, null, "sample", message, 0, 0);
        } 
        finally 
        {
            ATMI.tpfree(message);
        }
	
        ATMI.tpforward("TOUPPER", rqst.data, rqst.len, 0);
    }
}
