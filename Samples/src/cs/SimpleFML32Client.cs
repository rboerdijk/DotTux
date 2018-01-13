/*
 * SimpleFML32Client.cs
 * 
 * The SimpleFML32Client class shown below is a variant of the SimpleClient class
 * that uses FML32 rather than STRING messages. This class shows how to construct
 * FML32 messages using DotTux and DotTux Workstation. In particular, this class 
 * shows how to use the DotTux.Fml32.TPFBuilder class.
 */

using DotTux.Fml32;
using DotTux.Atmi;
using DotTux;
using System;

public class SimpleFML32Client
{
    public static void Main(string[] args)
    {
        if (args.Length == 0) 
        {
            Console.WriteLine("Usage: SimpleFML32Client <field>=<value> ...");
            Environment.Exit(1);
        }
        
        ATMI.tpinit(null);
        try 
        {
            ByteBuffer fbfr = ATMI.tpalloc("FML32", null, 512);
            try 
            {
                foreach (string arg in args) 
                {
                    int eqPos = arg.IndexOf('=');
                    string key = arg.Substring(0, eqPos);
                    string val = arg.Substring(eqPos + 1);
                    int fldid = FML32.Fldid(key);
                    TPFBuilder.I.FaddString(ref fbfr, fldid, val);
                }

                int len;
                ATMI.tpcall("FML32_TOUPPER", fbfr, 0, ref fbfr, out len, 0);
                
                Console.WriteLine("Returned FML32 buffer is: " + FML32.ToString(fbfr));
                
            } 
            finally 
            {
                ATMI.tpfree(fbfr);
            }
        } 
        finally 
        {
            ATMI.tpterm();
        }
    }
}
