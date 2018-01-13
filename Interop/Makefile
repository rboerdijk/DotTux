# Copyright 2004 OTP Systems Oy. All rights reserved

BASE_DIR := ..

default: all

include $(BASE_DIR)/Makefile.include

all: $(DotTuxInteropDLL) $(DotTuxWSInteropDLL)

$(DotTuxInteropDLL): src/c/DotTuxInterop.c
	-mkdir build
	cd build && buildclient -v -o $(DotTuxInteropDLL) -f "$(CFLAGS) $(DllCFlags) ../src/c/DotTuxInterop.c $(OTPTuxedoLibrary) $(OTPPlatformLibrary) $(libtmib) mscoree.lib"
	cd build && lib /def: /out:$(DotTuxInteropLinkLibrary) *.obj

$(DotTuxWSInteropDLL): src/c/DotTuxInterop.c
	-mkdir build
	cd build && buildclient -v -w -o $(DotTuxWSInteropDLL) -f "$(CFLAGS) -DWSCLIENT $(DllCFlags) ../src/c/DotTuxInterop.c $(OTPTuxedoLibrary) $(OTPPlatformLibrary) mscoree.lib"

clean:
	rm -rf build
