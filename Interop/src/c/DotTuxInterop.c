/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

#define DOTTUX_DLL_IMPL

#include "DotTuxInterop.h"

/*
#include "md5.c"
#include "OTPDate.c"
#include "OTPError.c"
#include "OTPString.c"
#include "OTPUserlog.c"
*/

#ifndef WSCLIENT

#include "DotServerInterface.h"
#include "OTPTuxServer.h"

/*
#include "OTPThread.h"
*/

static int isDotServer = 0;

DOTTUX_DLL_EXPORT
int DotServerAttach(DotServerInterface *itf, char **errorInfo)
{
    itf->init = OTPTuxServerInit;
    itf->done = OTPTuxServerDone;
    itf->setup = OTPTuxServerSetup;
    itf->dispatch = OTPTuxServerDispatch;

    isDotServer = 1;

    return 0;
}

#endif /* for #ifndef WSCLIENT */

#include "DotAtmi.c"
#include "DotFml32.c"

#define XSTR(S) STR(S)
#define STR(S) #S

#ifdef WSCLIENT
static char *product = "DotTuxWS-" XSTR(DOTTUX_RELEASE);
#else
static char *product = "DotTux-" XSTR(DOTTUX_RELEASE);
#endif

DOTTUX_DLL_EXPORT
int dot_init()
{
    char *err = NULL;

    return 0;
}
