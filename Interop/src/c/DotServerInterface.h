/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

#ifndef DotServerInterface_h_included
#define DotServerInterface_h_included

#include "DotTuxInterop.h"

/*
 * This file is included in DotServer.cpp and as a result all names will
 * appear in the disassembly of DotServer.exe. To hide any implementation
 * details we rename OTPTuxServerImpl to DotServerImplementation.
 */

#define OTPTuxServerImpl DotServerImplementation

#include "OTPTuxServerImpl.h"

typedef struct {
    int (*init)(DotServerImplementation *impl, char **errorInfo);
    void (*done)();
    int (*setup)(char *setupString, char **errorInfo);
    void (*dispatch)(TPSVCINFO *svcInfo);
} DotServerInterface;

#ifdef __cplusplus
extern "C" {
#endif

DOTTUX_DLL_ENTRY
int DotServerAttach(DotServerInterface *serverInterface, char **errorInfo);

#ifdef __cplusplus
}
#endif

#endif
