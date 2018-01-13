/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Runtime.InteropServices;
using System.Text;

using DotTux.Atmi;

namespace DotTux
{
    /*
     * Implementation notes
     *
     * The .NET Framework Developer's Guide is ambiguous about the default
     * marshaling behaviour of platform invoke w.r.t. strings. The
     * "Default Marshaling for Strings"/"Strings Used in Platform Invoke"
     * section specifies UnmanagedType.BStr to be the default, but the
     * Remarks section of the MarshalAsAttribute class overview page
     * says that it is UnmanagedType.LPStr. To make sure we get the
     * correct marshaling behaviour we decorate all string parameters with
     * the [MarshalAs(UnmanagedType.LPStr)] attribute.
     */

    internal class DotTuxInterop
    {

#if WSCLIENT
        private const string DLL = "DotTuxWSInterop.dll";
#else
        private const string DLL = "DotTuxInterop.dll";
#endif

	static DotTuxInterop()
	{
	    Marshal.PrelinkAll(typeof(DotTuxInterop));

	    if (init() == -1) {
		throw new ExternalException("Initialization failed");
	    }
	}

	[DllImport(DLL, EntryPoint="dot_init")]
	internal static extern int init();

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_tuxgetenv",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern IntPtr tuxgetenv(
	    [MarshalAs(UnmanagedType.LPStr)] string name);

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_tuxputenv",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern IntPtr tuxputenv(
	    [MarshalAs(UnmanagedType.LPStr)] string setting);

	[DllImport(DLL, EntryPoint="dot_tuxreadenv",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tuxreadenv(
	    [MarshalAs(UnmanagedType.LPStr)] string file,
	    [MarshalAs(UnmanagedType.LPStr)] string label);

	[DllImport(DLL, EntryPoint="dot_userlog")]
	internal static extern void userlog(byte[] str, int len);

	[DllImport(DLL, EntryPoint="dot_get_tperrno")]
	internal static extern int get_tperrno();

	[DllImport(DLL, EntryPoint="dot_set_tperrno")]
	internal static extern void set_tperrno(int err);

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_tpstrerror")]
	internal static extern IntPtr tpstrerror(int err);

	[DllImport(DLL, EntryPoint="dot_tperrordetail")]
	internal static extern int tperrordetail(int flags);

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_tpstrerrordetail")]
	internal static extern IntPtr tpstrerrordetail(int err, int flags);

	[DllImport(DLL, EntryPoint="dot_get_tpurcode")]
	internal static extern int get_tpurcode();

	[DllImport(DLL, EntryPoint="dot_tpalloc",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern IntPtr tpalloc(
	    [MarshalAs(UnmanagedType.LPStr)] string type, 
	    [MarshalAs(UnmanagedType.LPStr)] string subtype, int size);

	[DllImport(DLL, EntryPoint="dot_tptypes")]
	internal static extern int tptypes(IntPtr buffer, 
	    [MarshalAs(UnmanagedType.LPStr)] StringBuilder type, 
	    [MarshalAs(UnmanagedType.LPStr)] StringBuilder subtype);

	[DllImport(DLL, EntryPoint="dot_tprealloc")]
	internal static extern IntPtr tprealloc(IntPtr buffer, int size);

	[DllImport(DLL, EntryPoint="dot_tpfree")]
	internal static extern void tpfree(IntPtr buffer);

#if WSCLIENT
	// Skip tpadmcall()
#else
	[DllImport(DLL, EntryPoint="dot_tpadmcall")]
	internal static extern int tpadmcall(IntPtr idata, ref IntPtr odata,
	    int flags);
#endif

	internal delegate void NativeUnsolHandler(IntPtr data, int len,
	     int flags);

	[DllImport(DLL, EntryPoint="dot_tpsetunsol")]
	internal static extern int tpsetunsol(NativeUnsolHandler handler);

	[DllImport(DLL, EntryPoint="dot_tpgetctxt")]
	internal static extern int tpgetctxt(out int context, int flags);

	[DllImport(DLL, EntryPoint="dot_tpsetctxt")]
	internal static extern int tpsetctxt(int context, int flags);

	[DllImport(DLL, EntryPoint="dot_TPINITNEED")]
	internal static extern int TPINITNEED(int datalen);

	[DllImport(DLL, EntryPoint="dot_tpchkauth")]
	internal static extern int tpchkauth();

	[DllImport(DLL, EntryPoint="dot_tpinit")]
	internal static extern int tpinit(IntPtr tpinfo);

	[DllImport(DLL, EntryPoint="dot_tpterm")]
	internal static extern int tpterm();

#if WSCLIENT
	// Skip tpopen() and tpclose()
#else
	[DllImport(DLL, EntryPoint="dot_tpopen")]
	internal static extern int tpopen();

	[DllImport(DLL, EntryPoint="dot_tpclose")]
	internal static extern int tpclose();
#endif

	[DllImport(DLL, EntryPoint="dot_tpbegin")]
	internal static extern int tpbegin(int timeout, int flags);

	[DllImport(DLL, EntryPoint="dot_tpabort")]
	internal static extern int tpabort(int flags);

	[DllImport(DLL, EntryPoint="dot_tpcommit")]
	internal static extern int tpcommit(int flags);

	[DllImport(DLL, EntryPoint="dot_tpscmt")]
	internal static extern int tpscmt(int flags);

	[DllImport(DLL, EntryPoint="dot_tpgetlev")]
	internal static extern int tpgetlev();

	[DllImport(DLL, EntryPoint="dot_tpsuspend")]
	internal static extern int tpsuspend([Out] TPTRANID tranid, 
	    int flags);

	[DllImport(DLL, EntryPoint="dot_tpresume")]
	internal static extern int tpresume(TPTRANID tranid, int flags);

	[DllImport(DLL, EntryPoint="dot_tpcall",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpcall(
	    [MarshalAs(UnmanagedType.LPStr)] string svc, IntPtr idata,
	    int ilen, ref IntPtr odata, out int olen, int flags);

	[DllImport(DLL, EntryPoint="dot_tpacall",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpacall(
	    [MarshalAs(UnmanagedType.LPStr)] string svc, IntPtr data, 
	    int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpgetrply")]
	internal static extern int tpgetrply(ref int cd, ref IntPtr data, 
	    out int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpcancel")]
	internal static extern int tpcancel(int cd);

	[DllImport(DLL, EntryPoint="dot_tpsprio")]
	internal static extern int tpsprio(int prio, int flags);

	[DllImport(DLL, EntryPoint="dot_tpgprio")]
	internal static extern int tpgprio();

	[DllImport(DLL, EntryPoint="dot_tpconnect",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpconnect(
	    [MarshalAs(UnmanagedType.LPStr)] string svc, IntPtr data, 
	    int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpdiscon")]
	internal static extern int tpdiscon(int cd);

	[DllImport(DLL, EntryPoint="dot_tpsend")]
	internal static extern int tpsend(int cd, IntPtr data, int len,
	    int flags, out int rev);

	[DllImport(DLL, EntryPoint="dot_tprecv")]
	internal static extern int tprecv(int cd, ref IntPtr data, 
	    out int len, int flags, out int rev);

	[DllImport(DLL, EntryPoint="dot_tpenqueue",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpenqueue(
	    [MarshalAs(UnmanagedType.LPStr)] string qspace,
	    [MarshalAs(UnmanagedType.LPStr)] string qname,
	    [In, Out] TPQCTL ctl, IntPtr data, int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpdequeue",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpdequeue(
	    [MarshalAs(UnmanagedType.LPStr)] string qspace, 
	    [MarshalAs(UnmanagedType.LPStr)] string qname, 
	    [In, Out] TPQCTL ctl, ref IntPtr data, out int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpnotify")]
	internal static extern int tpnotify(CLIENTID clientid, IntPtr data,
	    int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpbroadcast",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpbroadcast(
	    [MarshalAs(UnmanagedType.LPStr)] string lmid, 
	    [MarshalAs(UnmanagedType.LPStr)] string usrname,
	    [MarshalAs(UnmanagedType.LPStr)] string cltname,
	    IntPtr data, int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpchkunsol")]
	internal static extern int tpchkunsol();

	[DllImport(DLL, EntryPoint="dot_tppost",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tppost(
	    [MarshalAs(UnmanagedType.LPStr)] string eventname,
	    IntPtr data, int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpsubscribe",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpsubscribe(
	    [MarshalAs(UnmanagedType.LPStr)] string eventexpr, 
	    [MarshalAs(UnmanagedType.LPStr)] string filter,
	    TPEVCTL ctl, int flags);

	[DllImport(DLL, EntryPoint="dot_tpunsubscribe")]
	internal static extern int tpunsubscribe(int subscription, int flags);

	[DllImport(DLL, EntryPoint="dot_tpgetmbenc")]
	internal static extern int tpgetmbenc(IntPtr bufp, 
	    [MarshalAs(UnmanagedType.LPStr)] StringBuilder enc_name, 
	    int flags);

	[DllImport(DLL, EntryPoint="dot_tpsetmbenc",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpsetmbenc(IntPtr bufp,
	     [MarshalAs(UnmanagedType.LPStr)] string enc_name, int flags);

#if WSCLIENT
	// Skip tpadvertise(), tpunadvertise(), tpreturn() and tpforward()
#else
	[DllImport(DLL, EntryPoint="dot_tpadvertise",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpadvertise(
	    [MarshalAs(UnmanagedType.LPStr)] string svc, 
	    [MarshalAs(UnmanagedType.LPStr)] string func);

	[DllImport(DLL, EntryPoint="dot_tpunadvertise",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpunadvertise(
	    [MarshalAs(UnmanagedType.LPStr)] string svc);

	[DllImport(DLL, EntryPoint="dot_tpreturn")]
	internal static extern int tpreturn(int rval, int rcode,
	    IntPtr data, int len, int flags);

	[DllImport(DLL, EntryPoint="dot_tpforward",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int tpforward(
	     [MarshalAs(UnmanagedType.LPStr)] string svc,
	     IntPtr data, int len, int flags);
#endif

	/*-------*/
	/* FML32 */
	/*-------*/

	[DllImport(DLL, EntryPoint="dot_get_Ferror32")]
	internal static extern int get_Ferror32();

	[DllImport(DLL, EntryPoint="dot_set_Ferror32")]
	internal static extern void set_Ferror32(int err);

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_Fstrerror32")]
	internal static extern IntPtr Fstrerror32(int err);

	[DllImport(DLL, EntryPoint="dot_CFaddByte32")]
	internal static extern int CFaddByte32(IntPtr fbfr, int fldid, 
	    byte value);

	[DllImport(DLL, EntryPoint="dot_CFaddShort32")]
	internal static extern int CFaddShort32(IntPtr fbfr, int fldid, 
	    short value);

	[DllImport(DLL, EntryPoint="dot_CFaddInt32")]
	internal static extern int CFaddInt32(IntPtr fbfr, int fldid, 
	    int value);

	[DllImport(DLL, EntryPoint="dot_CFaddFloat32")]
	internal static extern int CFaddFloat32(IntPtr fbfr, int fldid, 
	    float value);

	[DllImport(DLL, EntryPoint="dot_CFaddDouble32")]
	internal static extern int CFaddDouble32(IntPtr fbfr, int fldid, 
	    double value);

	[DllImport(DLL, EntryPoint="dot_CFaddBytes32")]
	internal static extern int CFaddBytes32(IntPtr fbfr, int fldid, 
	    byte[] bytes, int len);

	[DllImport(DLL, EntryPoint="dot_CFchgByte32")]
	internal static extern int CFchgByte32(IntPtr fbfr, int fldid, 
	    int occ, byte value);

	[DllImport(DLL, EntryPoint="dot_CFchgShort32")]
	internal static extern int CFchgShort32(IntPtr fbfr, int fldid, 
	    int occ, short value);

	[DllImport(DLL, EntryPoint="dot_CFchgInt32")]
	internal static extern int CFchgInt32(IntPtr fbfr, int fldid, 
	    int occ, int value);

	[DllImport(DLL, EntryPoint="dot_CFchgFloat32")]
	internal static extern int CFchgFloat32(IntPtr fbfr, int fldid, 
	    int occ, float value);

	[DllImport(DLL, EntryPoint="dot_CFchgDouble32")]
	internal static extern int CFchgDouble32(IntPtr fbfr, int fldid, 
	    int occ, double value);

	[DllImport(DLL, EntryPoint="dot_CFchgBytes32")]
	internal static extern int CFchgBytes32(IntPtr fbfr, int fldid, 
	    int occ, byte[] value, int len);

	[DllImport(DLL, EntryPoint="dot_CFgetByte32")]
	internal static extern int CFgetByte32(IntPtr fbfr, int fldid, 
	    int occ, out byte value);

	[DllImport(DLL, EntryPoint="dot_CFgetShort32")]
	internal static extern int CFgetShort32(IntPtr fbfr, int fldid, 
	    int occ, out short value);

	[DllImport(DLL, EntryPoint="dot_CFgetInt32")]
	internal static extern int CFgetInt32(IntPtr fbfr, int fldid, 
	    int occ, out int value);

	[DllImport(DLL, EntryPoint="dot_CFgetFloat32")]
	internal static extern int CFgetFloat32(IntPtr fbfr, int fldid, 
	    int occ, out float value);

	[DllImport(DLL, EntryPoint="dot_CFgetDouble32")]
	internal static extern int CFgetDouble32(IntPtr fbfr, int fldid, 
	    int occ, out double value);

	[DllImport(DLL, EntryPoint="dot_CFfindBytes32")]
	internal static extern IntPtr CFfindBytes32(IntPtr fbfr, int fldid, 
	    int occ, out int len);

	[DllImport(DLL, EntryPoint="dot_Fdel32")]
	internal static extern int Fdel32(IntPtr fbfr, int fldid, int occ);

	[DllImport(DLL, EntryPoint="dot_Fdelall32")]
	internal static extern int Fdelall32(IntPtr fbfr, int fldid);

	[DllImport(DLL, EntryPoint="dot_Finit32")]
	internal static extern int Finit32(IntPtr fbfr, int buflen);

	[DllImport(DLL,  EntryPoint="dot_Fldid32",
	       	BestFitMapping=false, ThrowOnUnmappableChar=true)]
	internal static extern int Fldid32(
	    [MarshalAs(UnmanagedType.LPStr)] string name);

	[DllImport(DLL, EntryPoint="dot_Fldno32")]
	internal static extern int Fldno32(int fldid);

	[DllImport(DLL, EntryPoint="dot_Fldtype32")]
	internal static extern int Fldtype32(int fldid);

	[DllImport(DLL, EntryPoint="dot_Flen32")]
	internal static extern int Flen32(IntPtr fbfr, int fldid, int occ);

	[DllImport(DLL, EntryPoint="dot_Fmkfldid32")]
	internal static extern int Fmkfldid32(int type, int num);

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_Fname32")]
	internal static extern IntPtr Fname32(int fldid);

	[DllImport(DLL, EntryPoint="dot_Fnext32")]
	internal static extern int Fnext32(IntPtr fbfr, ref int fldid, 
	    ref int occ);

	[DllImport(DLL, EntryPoint="dot_Fnum32")]
	internal static extern int Fnum32(IntPtr fbfr);

	[DllImport(DLL, EntryPoint="dot_Foccur32")]
	internal static extern int Foccur32(IntPtr fbfr, int fldid);

	[DllImport(DLL, EntryPoint="dot_Fsizeof32")]
	internal static extern int Fsizeof32(IntPtr fbfr);

	// Use IntPtr rather than string as return type to prevent the
	// marshaller from attempting to free the returned native string.
	[DllImport(DLL, EntryPoint="dot_Ftype32")]
	internal static extern IntPtr Ftype32(int fldid);

	[DllImport(DLL, EntryPoint="dot_Funused32")]
	internal static extern int Funused32(IntPtr fbfr);

	[DllImport(DLL, EntryPoint="dot_Fused32")]
	internal static extern int Fused32(IntPtr fbfr);

	[DllImport(DLL, EntryPoint="dot_Fidnm_unload32")]
	internal static extern void Fidnm_unload32();

	[DllImport(DLL, EntryPoint="dot_Fnmid_unload32")]
	internal static extern void Fnmid_unload32();
    }
}
