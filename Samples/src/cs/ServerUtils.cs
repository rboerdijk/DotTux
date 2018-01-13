/*
 * ServerUtils.cs
 * 
 * The ServerUtils class shown below provides a utility method for 
 * returning a STRING message from a service routine.
 */

using DotTux.Atmi;
using DotTux;
using System.Text;

public class ServerUtils
{
    // Returns a STRING message from a service routine.

    public static void ReturnReply(int rval, int rcode, string message)
    {
        bool returned = false;
        ByteBuffer reply = StringUtils.NewStringBuffer(message);
        try 
        {
            ATMI.tpreturn(ATMI.TPFAIL, rcode, reply, 0, 0);
            returned = true;
        } 
        finally 
        {
            if (!returned) 
            {
                ATMI.tpfree(reply);
            }
        }
    }
}
