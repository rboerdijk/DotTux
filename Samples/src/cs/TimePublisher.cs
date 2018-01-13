/*
 * TimePublisher.cs
 * 
 * The TimePublisher class shown below is a Tuxedo server that posts
 * TIME messages to the Tuxedo event broker in one-second intervals. 
 * This class shows how to post messages to the Tuxedo event broker 
 * using DotTux. In particular, this class shows how to use the 
 * DotTux.Atmi.ATMI.tppost() method.
 */

using DotTux.Atmi;
using DotTux;
using System.Threading;
using System;

public class TimePublisher
{
    public static int tpsvrinit(string[] args)
    {
        ATMI.tpacall("PUBLISH_TIME", null, 0, ATMI.TPNOREPLY);
        return 0;
    }

    public static void PUBLISH_TIME(TPSVCINFO svcinfo)
    {
        ByteBuffer message = StringUtils.NewStringBuffer("It is now " + DateTime.Now);
        try 
        {
            ATMI.tppost("TIME", message, 0, 0);
        } 
        catch (TPENOENT) 
        {
            // EventBroker not running yet (ignored)
        } 
        finally 
        {
            ATMI.tpfree(message);
        }

        Thread.Sleep(1000);

        ATMI.tpacall("PUBLISH_TIME", null, 0, ATMI.TPNOREPLY);

        ATMI.tpreturn(ATMI.TPSUCCESS, 0, null, 0, 0);
    }
}
