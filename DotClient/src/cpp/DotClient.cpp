/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

#include <atmi.h>
#include <userlog.h>
#include <string.h>
#include <stdlib.h> /* getenv() */

#using <mscorlib.dll>
#using <DotTux.dll>

using namespace System;
using namespace System::IO;
using namespace System::Reflection;

using namespace DotTux;

static void set_ULOGPFX()
{
    /*
     * On Windows tuxgetenv("ULOGPFX") returns %TUXDIR%\ULOG if ULOGPFX
     * is not set which causes userlog() messages to end up where nobody
     * expects them. To prevent this behaviour, we use getenv() to test
     * wheter ULOGPFX is really set, and if not, set it to ".\ULOG" so that
     * userlog() messages end up in a more sensible place (i.e., the
     * directory from which DotClient is run).
     */

    char *ULOGPFX = getenv("ULOGPFX");
    if (ULOGPFX == NULL) {
        tuxputenv("ULOGPFX=.\\ULOG");
    }
}

static void set_proc_name(char *executablePath)
{
    /*
     * buildclient does not set proc_name so we do it here.
     * This must be done before the first userlog() call to 
     * have any effect.
     */

    char *lastSlash = strrchr(executablePath, '\\');
    if (lastSlash == NULL) {
	proc_name = executablePath;
    } else {
	proc_name = lastSlash + 1;
    }
}

extern "C" int main(int argc, char* argv[])
{
    try {
	set_ULOGPFX();

	set_proc_name(argv[0]);

	int assemblyIndex = 1;
	int mainClassIndex = 2;

        if (mainClassIndex >= argc) {
	    userlog("ERROR: Usage: DotClient <assembly> <class> [<arg> ...]");
	    exit(1);
        }

	Assembly *assembly;

	char *assemblyName = argv[assemblyIndex];

	if (File::Exists(assemblyName)) {
	    assembly = Assembly::LoadFrom(argv[assemblyIndex]);
	} else {
	    assembly = Assembly::Load(assemblyName);
	}

	char *mainClassName = argv[mainClassIndex];

	Type *mainClass = assembly->GetType(mainClassName);

	Type* mainParameterTypes[] = new Type*[1];
	mainParameterTypes[0] = __typeof(String*[]);

        MethodInfo* mainMethod = mainClass->GetMethod("Main", 
	    mainParameterTypes);
        if (mainMethod == NULL) {
	    TUX::userlog(String::Concat("ERROR: No such method: ", 
		mainClassName , ".Main(string[])"));
	    return 1;
        }

        if (!mainMethod->get_IsStatic()) {
	    TUX::userlog("ERROR: Main() method is not static");
	    return 1;
        }

        if (!mainMethod->get_IsPublic()) {
	    TUX::userlog("ERROR: Main() method is not public");
	    return 1;
        }

        if (!__typeof(void)->Equals(mainMethod->get_ReturnType())) {
	    TUX::userlog("ERROR: Main() method does not have return type void");
	    return 1;
	}

	int firstArgIndex = mainClassIndex + 1;

	String* args[] = new String*[argc - firstArgIndex];
	for (int i = firstArgIndex; i < argc; i++) {
	    args[i - firstArgIndex] = argv[i];
	}

	Object* params[] = new Object*[1];
	params[0] = args;

	try {
	    mainMethod->Invoke(NULL, params);
	} catch (TargetInvocationException *eTarget) {
	    Exception *eInner = eTarget->get_InnerException();
	    TUX::userlog(String::Concat("ERROR: ", eInner->ToString()));
	    return 1;
	}
    } catch (Exception* eAny) {
        TUX::userlog(String::Concat(S"ERROR: ", eAny->ToString()));
	return 1;
    }
}
