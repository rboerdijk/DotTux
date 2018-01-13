/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

#ifndef DotTuxRuntime_h_included
#define DotTuxRuntime_h_included

#ifdef _WIN32
#define DOTTUX_DLL_IMPORT __declspec(dllimport)
#define DOTTUX_DLL_EXPORT __declspec(dllexport)
#else
#define DOTTUX_DLL_IMPORT /* empty */
#define DOTTUX_DLL_EXPORT /* empty */
#endif

#ifdef DOTTUX_DLL_IMPL
#define DOTTUX_DLL_ENTRY DOTTUX_DLL_EXPORT
#else
#define DOTTUX_DLL_ENTRY DOTTUX_DLL_IMPORT
#endif

#endif
