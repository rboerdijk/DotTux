/*
 * SimpleFML32Server.cs
 * 
 * The SimpleFML32Server class shown below is a variant of the SimpleServer
 * class that uses FML32 rather than STRING messages. This class shows how
 * to read and write FML32 buffers using DotTux. In particular, this class 
 * shows how to use the Fnext(), Fldtype(), FgetString() and Fchg() methods 
 * of the DotTux.Fml32.FML32 class.
 */

using DotTux.Fml32;
using DotTux.Atmi;
using DotTux;

public class SimpleFML32Server
{
    public static void FML32_TOUPPER(TPSVCINFO rqst)
    {
        ByteBuffer fbfr = rqst.data;

        int fldid = FML32.FIRSTFLDID;
        int occ = 0;
        
        while (FML32.Fnext(fbfr, ref fldid, ref occ)) 
        {
            int occur = FML32.Foccur(fbfr, fldid);
            if (FML32.Fldtype(fldid) == FML32.FLD_STRING) 
            {
                for (int i = 0; i < occur; i++) 
                {
                    string s = FML32.FgetString(fbfr, fldid, i);
                    s = s.ToUpper();
                    FML32.Fchg(fbfr, fldid, i, s);
                }
            }
            occ = occur; // Skip to next field id
        }
        
        ATMI.tpreturn(ATMI.TPSUCCESS, 0, fbfr, 0, 0);
    }
}
