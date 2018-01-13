/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 *
 * Be aware that all functions defined in this file, both managed and
 * unmanaged, will show up in the disassembly of DotServer.exe. The number
 * of functions defined in this file should therefore be kept to an absolute
 * minimum. This is why all generic server code is in the native
 * DotTuxInterop.dll and exposed through an invocation interface.
 * Of all functions that remain in this file, all code that does not
 * interact with the common language runtime must be placed in unmanaged
 * functions to make it harder to reverse-engineer.
 *
 * The C preprocessor can be used to make reverse-engineering even harder.
 * The use of macros rather than variables and functions, for example,
 * results in less functions with larger bodies containing a lot of redundant
 * code.
 */

#using <mscorlib.dll>
#using <DotTux.dll>

#include <atmi.h>
#include <Uunix.h>
#include <userlog.h>
#include <stdlib.h>
#include <stdio.h>

/*--------------------------------------------------------------------------*/
#pragma managed                                             /* Managed code */
/*--------------------------------------------------------------------------*/

using namespace System;
using namespace System::IO;
using namespace System::Reflection;
using namespace System::Runtime::InteropServices;

using namespace DotTux;

static void *serverClassHandle = NULL;
static void *tpsvrinitHandle = NULL;
static void *tpsvrdoneHandle = NULL;
static void *tpsvrthrinitHandle = NULL;
static void *tpsvrthrdoneHandle = NULL;

#define ALLOC_HANDLE(OBJECT) \
    ((IntPtr) GCHandle::Alloc(OBJECT)).ToPointer()

#define GET_OBJECT(HANDLE) \
    GCHandle::op_Explicit(IntPtr(HANDLE)).get_Target()

#define GET_SRVCLS_METHOD(NAME,RTYPE,PTYPES,HANDLE) \
{ \
    Type *s = dynamic_cast<Type*>(GET_OBJECT(serverClassHandle)); \
    MethodInfo* m = s->GetMethod(NAME, PTYPES); \
    if (m == NULL) { \
	HANDLE = NULL; \
    } else { \
        if (!m->get_IsStatic()) { \
	    userlog("ERROR: %s() is not static", NAME); \
	    return -1; \
	} \
        if (!m->get_IsPublic()) { \
	    userlog("ERROR: %s() is not public", NAME); \
	    return -1; \
        } \
        if (!__typeof(RTYPE)->Equals(m->get_ReturnType())) { \
	    userlog("ERROR: %s() does not have return type " #RTYPE, NAME); \
	    return -1; \
	} \
	HANDLE = ALLOC_HANDLE(m); \
    } \
} 

/*-----------------*/
/* initServerClass */
/*-----------------*/

static int initServerClass(const char *assemblyName, const char *className)
{
    try {
	Assembly *assembly;

	if (File::Exists(assemblyName)) {
	    assembly = Assembly::LoadFrom(assemblyName);
	} else {
	    assembly = Assembly::Load(assemblyName);
	}

        Type *parameterTypes[] = new Type*[1];

        parameterTypes[0] = __typeof(String*[]);

	serverClassHandle = ALLOC_HANDLE(assembly->GetType(className));

	GET_SRVCLS_METHOD("tpsvrinit", int, parameterTypes,
	    tpsvrinitHandle);

	GET_SRVCLS_METHOD("tpsvrthrinit", int, parameterTypes, 
	    tpsvrthrinitHandle);

	parameterTypes = new Type*[0];

	GET_SRVCLS_METHOD("tpsvrdone", void, parameterTypes, 
	    tpsvrdoneHandle);

	GET_SRVCLS_METHOD("tpsvrthrdone", void, parameterTypes, 
	    tpsvrthrdoneHandle);

	return 0;

    } catch (Exception* exception) {
        TUX::userlog(String::Concat("ERROR: ", exception->ToString()));
	return -1;
    }
}

/*-------------------*/
/* getServiceRoutine */
/*-------------------*/

static int getServiceRoutine(const char *name, void **serviceRoutineHandle)
{
    try {
        Type* parameterTypes[] = new Type*[1];

        parameterTypes[0] = __typeof(DotTux::Atmi::TPSVCINFO);

	void *handle;

	GET_SRVCLS_METHOD(name, void, parameterTypes, handle);
	if (handle == NULL) {
	    userlog("ERROR: %s() not found", name);
	    return -1;
	}

	*serviceRoutineHandle = handle;

	return 0;

    } catch (Exception* exception) {
        TUX::userlog(String::Concat("ERROR: ", exception->ToString()));
	return -1;
    }
}

/*--------------------*/
/* freeServiceRoutine */
/*--------------------*/

static void freeServiceRoutine(void *serviceRoutine)
{
    try {
        GCHandle::op_Explicit(IntPtr(serviceRoutine)).Free();
    } catch (Exception* exception) {
        TUX::userlog(String::Concat("ERROR: ", exception->ToString()));
    }
}

/*--------------------*/
/* callServiceRoutine */
/*--------------------*/

static void callServiceRoutine(TPSVCINFO *svcInfo, void *serviceRoutine)
{
    try {
        MethodInfo *method = dynamic_cast<MethodInfo*>
	    (GET_OBJECT(serviceRoutine));

        DotTux::Atmi::TPSVCINFO* mSvcInfo = new DotTux::Atmi::TPSVCINFO();

        mSvcInfo->name = svcInfo->name;
	mSvcInfo->data = (svcInfo->data == NULL) ? NULL
	    : new DotTux::ByteBuffer(svcInfo->data, 
		    tptypes(svcInfo->data, NULL, NULL));
	mSvcInfo->len = svcInfo->len;
	mSvcInfo->flags = svcInfo->flags;
	mSvcInfo->cd = svcInfo->cd;
	mSvcInfo->appkey = svcInfo->appkey;

	DotTux::Atmi::CLIENTID* mCltid = new DotTux::Atmi::CLIENTID();
	mCltid->clientdata0 = svcInfo->cltid.clientdata[0];
	mCltid->clientdata1 = svcInfo->cltid.clientdata[1];
	mCltid->clientdata2 = svcInfo->cltid.clientdata[2];
	mCltid->clientdata3 = svcInfo->cltid.clientdata[3];

	mSvcInfo->cltid = mCltid;

	Object* params[] = new Object*[1];
        params[0] = mSvcInfo;

	try {
	    method->Invoke(NULL, params);
	} catch (TargetInvocationException *eTarget) {
	    Exception *eInner = eTarget->get_InnerException();
	    TUX::userlog(String::Concat("ERROR: ", eInner->ToString()));
	}
    } catch (Exception* eAny) {
        TUX::userlog(String::Concat("ERROR: ", eAny->ToString()));
    }
}

/*----------------*/
/* call_svrinit() */
/*----------------*/

static int call_svrinit(void *handle, int argc, char *argv[])
{
    try {
        MethodInfo *method = dynamic_cast<MethodInfo*>(GET_OBJECT(handle));
        
        String* args[] = new String*[argc];
        for (int i = 0; i < argc; i++) {
	    args[i] = argv[i];
        }
        
        Object* params[] = new Object*[1];
        params[0] = args; 
        
        try {
	    Object *result = method->Invoke(NULL, params);
	    return *dynamic_cast<Int32*>(result); 
	} catch (TargetInvocationException *eTarget) {
	    Exception *eInner = eTarget->get_InnerException();
	    TUX::userlog(String::Concat("ERROR: ", eInner->ToString()));
	    return -1;
	}
    } catch (Exception* eAny) {
        TUX::userlog(String::Concat("ERROR: ", eAny->ToString()));
	return -1;
    }
}

/*----------------*/
/* call_svrdone() */
/*----------------*/

static int call_svrdone(void *handle)
{
    try {
        MethodInfo *method = dynamic_cast<MethodInfo*>(GET_OBJECT(handle));
        try {
	    method->Invoke(NULL, new Object*[0]);
	} catch (TargetInvocationException *eTarget) {
	    Exception *eInner = eTarget->get_InnerException();
	    TUX::userlog(String::Concat("ERROR: ", eInner->ToString()));
	}
    } catch (Exception* eAny) {
        TUX::userlog(String::Concat("ERROR: ", eAny->ToString()));
    }
}

/*--------------------------------------------------------------------------*/
#pragma unmanaged                                         /* Unmanaged code */
/*--------------------------------------------------------------------------*/

#include "DotServerInterface.h"

static DotServerInterface serverInterface;

extern "C" void tpservice(TPSVCINFO *svcInfo)
{
    serverInterface.dispatch(svcInfo);
}

static int serverClassIndex; // set by tpsvrinit(), used by tpsvrthrinit()

extern "C" int tpsvrinit(int argc, char *argv[])
{
    char *err = NULL;

    if (DotServerAttach(&serverInterface, &err) == -1) {
	goto error;
    }

    DotServerImplementation serverImplementation;

    serverImplementation.tpservice = tpservice;
    serverImplementation.getDispatchInfo = getServiceRoutine;
    serverImplementation.freeDispatchInfo = freeServiceRoutine;
    serverImplementation.dispatch = callServiceRoutine;

    if (serverInterface.init(&serverImplementation, &err) == -1) {
	goto error;
    }

    /*
     * Server class must be loaded before serverInterface.setup()
     * can be called 
     */

    int i = optind;

    while ((i < argc) && (strcmp(argv[i], "-s") == 0)) {
	i = i + 2; /* skip -s <arg> */
    }

    if (i + 1 >= argc) {
	userlog("ERROR: Missing assembly and/or server class name "
	    "in command line");
	goto error;
    }

    if (initServerClass(argv[i], argv[i + 1]) == -1) {
	goto error;
    }

    serverClassIndex = i;

    for (i = optind + 1; i < serverClassIndex; i = i + 2) {
	if (serverInterface.setup(argv[i], &err) == -1) {
	    goto error;
	}
    }

    if (tpsvrinitHandle == NULL) {
	return 0;
    } else {
	return call_svrinit(tpsvrinitHandle, argc - serverClassIndex - 1,
	    argv + serverClassIndex + 1);
    }

error:

    if (err != NULL) {
        // Truncate err to BUFSIZ-12 bytes to prevent userlog from crashing
        if (strlen(err) > BUFSIZ-12) {
	    err[BUFSIZ-12] = '\0';
        }
	userlog("ERROR: %s", err);
        free(err);
    }

    return -1;
}

extern "C" void tpsvrdone()
{
    if (tpsvrdoneHandle != NULL) {
	call_svrdone(tpsvrdoneHandle);
    }

    serverInterface.done();
}

extern "C" int tpsvrthrinit(int argc, char *argv[])
{
    if (tpsvrthrinitHandle == NULL) {
	if (tpopen() == -1) {
	    userlog("ERROR: tpopen() failed: %s", tpstrerror(tperrno));
	    return -1;
	} else {
	    return 0;
	}
    } else {
	return call_svrinit(tpsvrthrinitHandle, argc - serverClassIndex - 1,
	    argv + serverClassIndex + 1);
    }
}

extern "C" void tpsvrthrdone()
{
    if (tpsvrthrdoneHandle == NULL) {
	if (tpclose() == -1) {
	    userlog("WARNING: tpclose() failed: %s", tpstrerror(tperrno));
	}
    } else {
	call_svrdone(tpsvrthrdoneHandle);
    }
}
