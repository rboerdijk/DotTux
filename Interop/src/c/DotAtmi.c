/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

#include "DotTuxInterop.h"
#include "OTPUserlog.h"

#include <atmi.h>

#ifndef WSCLIENT
#include <fml32.h>
#include <tpadm.h>
#endif

DOTTUX_DLL_EXPORT
char *dot_tuxgetenv(char *name)
{
    return tuxgetenv(name);
}

DOTTUX_DLL_EXPORT
int dot_tuxputenv(char *setting)
{
    return tuxputenv(setting);
}

DOTTUX_DLL_EXPORT
int dot_tuxreadenv(char *file, char *label)
{
    return tuxreadenv(file, label);
}

DOTTUX_DLL_EXPORT
void dot_userlog(char *str, int len)
{
    OTPUserlog("%.*s", len, str);
}

DOTTUX_DLL_EXPORT
int dot_get_tperrno()
{
    return tperrno;
}

DOTTUX_DLL_EXPORT
void dot_set_tperrno(int err)
{
    tperrno = err;
}

DOTTUX_DLL_EXPORT
char *dot_tpstrerror(int err)
{
    return tpstrerror(err);
}

DOTTUX_DLL_EXPORT
int dot_tperrordetail(long flags)
{
    return tperrordetail(flags);
}

DOTTUX_DLL_EXPORT
char *dot_tpstrerrordetail(int err, long flags)
{
    return tpstrerrordetail(err, flags);
}

DOTTUX_DLL_EXPORT
int dot_get_tpurcode()
{
    return tpurcode;
}

DOTTUX_DLL_EXPORT
char *dot_tpalloc(char *type, char *subtype, long size)
{
    return tpalloc(type, subtype, size);
}

DOTTUX_DLL_EXPORT
long dot_tptypes(char *ptr, char *type, char *subtype)
{
    return tptypes(ptr, type, subtype);
}

DOTTUX_DLL_EXPORT
char *dot_tprealloc(char *ptr, long size)
{
    return tprealloc(ptr, size);
}

DOTTUX_DLL_EXPORT
void dot_tpfree(char *ptr)
{
    tpfree(ptr);
}

#ifndef WSCLIENT

DOTTUX_DLL_EXPORT
int dot_tpadmcall(FBFR32 *inbuf, FBFR32 **outbuf, long flags)
{
    return tpadmcall(inbuf, outbuf, flags);
}

#endif

DOTTUX_DLL_EXPORT
int dot_tpgetctxt(TPCONTEXT_T *context, long flags)
{
    return tpgetctxt(context, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpsetctxt(TPCONTEXT_T context, long flags)
{
    return tpsetctxt(context, flags);
}

typedef void (__stdcall *UnsolHandler)(char *data, long len, long flags);

DOTTUX_DLL_EXPORT
int dot_tpsetunsol(UnsolHandler handler)
{
    return (tpsetunsol(handler) == TPUNSOLERR) ? -1 : 0;
}

DOTTUX_DLL_EXPORT
int dot_tpchkauth()
{
    return tpchkauth();
}

DOTTUX_DLL_EXPORT
int dot_TPINITNEED(int datalen)
{
    return TPINITNEED(datalen);
}

DOTTUX_DLL_EXPORT
int dot_tpinit(TPINIT *tpinfo)
{
    return tpinit(tpinfo);
}

DOTTUX_DLL_EXPORT
int dot_tpterm()
{
    return tpterm();
}

#ifndef WSCLIENT

DOTTUX_DLL_EXPORT
int dot_tpopen()
{
    return tpopen();
}

DOTTUX_DLL_EXPORT
int dot_tpclose()
{
    return tpclose();
}

#endif

DOTTUX_DLL_EXPORT
int dot_tpbegin(unsigned long timeout, long flags)
{
    return tpbegin(timeout, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpabort(long flags)
{
    return tpabort(flags);
}

DOTTUX_DLL_EXPORT
int dot_tpcommit(long flags)
{
    return tpcommit(flags);
}

DOTTUX_DLL_EXPORT
int dot_tpscmt(long flags)
{
    return tpscmt(flags);
}

DOTTUX_DLL_EXPORT
int dot_tpgetlev()
{
    return tpgetlev();
}

DOTTUX_DLL_EXPORT
int dot_tpsuspend(TPTRANID *tranid, long flags)
{
    return tpsuspend(tranid, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpresume(TPTRANID *tranid, long flags)
{
    return tpresume(tranid, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpcall(char *svc, char *idata, long ilen, char **odata, 
    long *olen, long flags)
{
    return tpcall(svc, idata, ilen, odata, olen, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpacall(char *svc, char *data, long len, long flags)
{
    return tpacall(svc, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpgetrply(int *cd, char **data, long *len, long flags)
{
    return tpgetrply(cd, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpcancel(int cd)
{
    return tpcancel(cd);
}

DOTTUX_DLL_EXPORT
int dot_tpsprio(int prio, long flags)
{
    return tpsprio(prio, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpgprio()
{
    return tpgprio();
}

DOTTUX_DLL_EXPORT
int dot_tpconnect(char *svc, char *data, long len, long flags)
{
    return tpconnect(svc, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpdiscon(int cd)
{
    return tpdiscon(cd);
}

DOTTUX_DLL_EXPORT
int dot_tpsend(int cd, char *data, long len, long flags, long *revent)
{
    return tpsend(cd, data, len, flags, revent);
}

DOTTUX_DLL_EXPORT
int dot_tprecv(int cd, char **data, long *len, long flags, long *revent)
{
    return tprecv(cd, data, len, flags, revent);
}

DOTTUX_DLL_EXPORT
int dot_tpenqueue(char *qspace, char *qname, TPQCTL *ctl, char *data, 
    long len, long flags)
{
    return tpenqueue(qspace, qname, ctl, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpdequeue(char *qspace, char *qname, TPQCTL *ctl, char **data, 
    long *len, long flags)
{
    return tpdequeue(qspace, qname, ctl, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpnotify(CLIENTID *clientid, char *data, long len, long flags)
{
    return tpnotify(clientid, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpbroadcast(char *lmid, char *usrname, char *cltname, 
    char *data, long len, long flags)
{
    return tpbroadcast(lmid, usrname, cltname, data, len, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpchkunsol()
{
    return tpchkunsol();
}

DOTTUX_DLL_EXPORT
int dot_tppost(char *eventname, char *data, long len, long flags)
{
    return tppost(eventname, data, len, flags);
}

DOTTUX_DLL_EXPORT
long dot_tpsubscribe(char *eventexpr, char *filter, TPEVCTL *ctl, long flags)
{
    return tpsubscribe(eventexpr, filter, ctl, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpunsubscribe(long subscription, long flags)
{
    return tpunsubscribe(subscription, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpgetmbenc(char *bufp, char *enc_name, long flags)
{
    return tpgetmbenc(bufp, enc_name, flags);
}

DOTTUX_DLL_EXPORT
int dot_tpsetmbenc(char *bufp, char *enc_name, long flags)
{
    return tpsetmbenc(bufp, enc_name, flags);
}

#ifndef WSCLIENT

DOTTUX_DLL_EXPORT
int dot_tpadvertise(char *svc, const char *func)
{
    if (isDotServer) {
	return OTPTuxServerAdvertise(svc, func);
    } else {
	tperrno = TPEPROTO;
	return -1;
    }
}

DOTTUX_DLL_EXPORT
int dot_tpunadvertise(char *svc)
{
    if (isDotServer) {
	return OTPTuxServerUnadvertise(svc);
    } else {
	tperrno = TPEPROTO;
	return -1;
    }
}

DOTTUX_DLL_EXPORT
int dot_tpreturn(int rval, long rcode, char *data, long len, long flags)
{
    if (isDotServer) {
	return OTPTuxServerReturn(rval, rcode, data, len, flags);
    } else {
	tperrno = TPEPROTO;
	return -1;
    }
}

DOTTUX_DLL_EXPORT
int dot_tpforward(char *svc, char *data, long len, long flags)
{
    if (isDotServer) {
	return OTPTuxServerForward(svc, data, len, flags);
    } else {
	tperrno = TPEPROTO;
	return -1;
    }
}

#endif /* for #ifndef WCLIENT */
