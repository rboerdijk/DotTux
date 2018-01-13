/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

#include <fml32.h>
#include <Wtypes.h>

#define DOTTUX_DLL_EXPORT __declspec(dllexport)

DOTTUX_DLL_EXPORT
int dot_get_Ferror32()
{
    return Ferror32;
}

DOTTUX_DLL_EXPORT
void dot_set_Ferror32(int err)
{
    Ferror32 = err;
}

DOTTUX_DLL_EXPORT
char *dot_Fstrerror32(int err)
{
    return Fstrerror32(err);
}

DOTTUX_DLL_EXPORT
int dot_CFaddByte32(FBFR32 *fbfr, FLDID32 fldid, unsigned char value)
{
    return CFadd32(fbfr, fldid, (char *) &value, 0, FLD_CHAR);
}

DOTTUX_DLL_EXPORT
int dot_CFaddShort32(FBFR32 *fbfr, FLDID32 fldid, short value)
{
    return CFadd32(fbfr, fldid, (char *) &value, 0, FLD_SHORT);
}

DOTTUX_DLL_EXPORT
int dot_CFaddInt32(FBFR32 *fbfr, FLDID32 fldid, long value)
{
    return CFadd32(fbfr, fldid, (char *) &value, 0, FLD_LONG);
}

DOTTUX_DLL_EXPORT
int dot_CFaddFloat32(FBFR32 *fbfr, FLDID32 fldid, float value)
{
    return CFadd32(fbfr, fldid, (char *) &value, 0, FLD_FLOAT);
}

DOTTUX_DLL_EXPORT
int dot_CFaddDouble32(FBFR32 *fbfr, FLDID32 fldid, double value)
{
    return CFadd32(fbfr, fldid, (char *) &value, 0, FLD_DOUBLE);
}

DOTTUX_DLL_EXPORT
int dot_CFaddBytes32(FBFR32 *fbfr, FLDID32 fldid, char *bytes, int len)
{
    return CFadd32(fbfr, fldid, bytes, len, FLD_CARRAY);
}

DOTTUX_DLL_EXPORT
int dot_CFchgByte32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, 
    unsigned char value)
{
    return CFchg32(fbfr, fldid, occ, (char *) &value, 0, FLD_CHAR);
}

DOTTUX_DLL_EXPORT
int dot_CFchgShort32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, short value)
{
    return CFchg32(fbfr, fldid, occ, (char *) &value, 0, FLD_SHORT);
}

DOTTUX_DLL_EXPORT
int dot_CFchgInt32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, long value)
{
    return CFchg32(fbfr, fldid, occ, (char *) &value, 0, FLD_LONG);
}

DOTTUX_DLL_EXPORT
int dot_CFchgFloat32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, float value)
{
    return CFchg32(fbfr, fldid, occ, (char *) &value, 0, FLD_FLOAT);
}

DOTTUX_DLL_EXPORT
int dot_CFchgDouble32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, double value)
{
    return CFchg32(fbfr, fldid, occ, (char *) &value, 0, FLD_DOUBLE);
}

DOTTUX_DLL_EXPORT
int dot_CFchgBytes32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, 
    char *bytes, int len)
{
    return CFchg32(fbfr, fldid, occ, bytes, len, FLD_CARRAY);
}

DOTTUX_DLL_EXPORT
int dot_CFgetByte32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, 
    unsigned char *value)
{
    return CFget32(fbfr, fldid, occ, (char *) value, 0, FLD_CHAR);
}

DOTTUX_DLL_EXPORT
int dot_CFgetShort32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, short *value)
{
    return CFget32(fbfr, fldid, occ, (char *) value, 0, FLD_SHORT);
}

DOTTUX_DLL_EXPORT
int dot_CFgetInt32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, long *value)
{
    return CFget32(fbfr, fldid, occ, (char *) value, 0, FLD_LONG);
}

DOTTUX_DLL_EXPORT
int dot_CFgetFloat32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, float *value)
{
    return CFget32(fbfr, fldid, occ, (char *) value, 0, FLD_FLOAT);
}

DOTTUX_DLL_EXPORT
int dot_CFgetDouble32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, double *value)
{
    return CFget32(fbfr, fldid, occ, (char *) value, 0, FLD_DOUBLE);
}

DOTTUX_DLL_EXPORT
char* dot_CFfindBytes32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ, 
    FLDLEN32 *len)
{
    return CFfind32(fbfr, fldid, occ, len, FLD_CARRAY);
}

DOTTUX_DLL_EXPORT
int dot_Fdel32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ)
{
    return Fdel32(fbfr, fldid, occ);
}

DOTTUX_DLL_EXPORT
int dot_Fdelall32(FBFR32 *fbfr, FLDID32 fldid)
{
    return Fdelall32(fbfr, fldid);
}

DOTTUX_DLL_EXPORT
int dot_Finit32(FBFR32 *fbfr, FLDLEN32 buflen)
{
    return Finit32(fbfr, buflen);
}

DOTTUX_DLL_EXPORT
FLDID32 dot_Fldid32(char *name)
{
    return Fldid32(name);
}

DOTTUX_DLL_EXPORT
long dot_Fldno32(FLDID32 fldid)
{
    return Fldno32(fldid);
}

DOTTUX_DLL_EXPORT
int dot_Fldtype32(FLDID32 fldid)
{
    return Fldtype32(fldid);
}

DOTTUX_DLL_EXPORT
long dot_Flen32(FBFR32 *fbfr, FLDID32 fldid, FLDOCC32 occ)
{
    return Flen32(fbfr, fldid, occ);
}

DOTTUX_DLL_EXPORT
FLDID32 dot_Fmkfldid32(int type, FLDID32 num)
{
    return Fmkfldid32(type, num);
}

DOTTUX_DLL_EXPORT
char *dot_Fname32(FLDID32 fldid)
{
    return Fname32(fldid);
}

DOTTUX_DLL_EXPORT
int dot_Fnext32(FBFR32 *fbfr, FLDID32 *fldid, FLDOCC32 *occ)
{
    return Fnext32(fbfr, fldid, occ, NULL, NULL);
}
	
DOTTUX_DLL_EXPORT
FLDOCC32 dot_Fnum32(FBFR32 *fbfr)
{
    return Fnum32(fbfr);
}

DOTTUX_DLL_EXPORT
FLDOCC32 dot_Foccur32(FBFR32 *fbfr, FLDID32 fldid)
{
    return Foccur32(fbfr, fldid);
}

DOTTUX_DLL_EXPORT
long dot_Fsizeof32(FBFR32 *fbfr)
{
    return Fsizeof32(fbfr);
}

DOTTUX_DLL_EXPORT
char *dot_Ftype32(FLDID32 fldid)
{
    return Ftype32(fldid);
}

DOTTUX_DLL_EXPORT
long dot_Funused32(FBFR32 *fbfr)
{
    return Funused32(fbfr);
}

DOTTUX_DLL_EXPORT
long dot_Fused32(FBFR32 *fbfr)
{
    return Fused32(fbfr);
}

DOTTUX_DLL_EXPORT
void dot_Fidnm_unload32()
{
    Fidnm_unload32();
}

DOTTUX_DLL_EXPORT
void dot_Fnmid_unload32()
{
    Fnmid_unload32();
}
