# Copyright 2004 OTP Systems Oy. All rights reserved

BASE_DIR := ..

default: all

include $(BASE_DIR)/Makefile.include

all: $(DotServer)

# export CFLAGS := $(common_CC_flags) /clr $(DotTux_version_defines) -I../../DotTuxInterop/src/c -I../../CTools/Tuxedo/src/c /AI../../DotTuxAssembly/build

$(DotServer): src/cpp/DotServer.cpp
	-mkdir build
	cd build && buildserver -v -t -s tpservice -o $(DotServer) -f "$(CFLAGS) /clr /AI../../Classes/build -I../../Interop/src/c ../src/cpp/DotServer.cpp $(DotTuxInteropLinkLibrary)"

clean:
	rm -rf build
