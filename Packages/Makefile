# Copyright 2004 OTP Systems Oy. All rights reserved.

BASE_DIR := ..

default: all

include $(BASE_DIR)/Makefile.include

DOTTUX=DotTux-$(DotTux_version)
DOTTUXPKG=$(DOTTUX)-$(SHORT_PLATFORM)

DOTTUXWS=DotTuxWS-$(DotTux_version)
DOTTUXWSPKG=$(DOTTUXWS)-$(SHORT_PLATFORM)

all: DotTux DotTuxWS

DotTux:
	-mkdir build
	-cd build && mkdir $(DOTTUX)
	-cd build/$(DOTTUX) && mkdir bin
	cp $(DotTuxAssembly) build/$(DOTTUX)/bin
	cp $(DotTuxInteropDLL) build/$(DOTTUX)/bin
	csc /out:build\$(DOTTUX)\bin\TestConfig.exe /r:$(DotTuxAssembly) ..\Classes\src\cs\DotTux\Install\TestConfig.cs
	csc /out:build\$(DOTTUX)\bin\TestClient.exe /r:$(DotTuxAssembly) ..\Classes\src\cs\DotTux\Install\TestClient.cs
	cp $(DotClient) build/$(DOTTUX)/bin
	cp $(DotServer) build/$(DOTTUX)/bin
	cp $(Qipcrm) build/$(DOTTUX)/bin
	cp $(MSVCR71DLL) build/$(DOTTUX)/bin
	attrib -r build/$(DOTTUX)/bin/*.dll
	cd build && pacomp -a -r -P $(DOTTUXPKG).zip $(DOTTUX)\*

DotTuxWS:
	-mkdir build
	-cd build && mkdir $(DOTTUXWS)
	-cd build/$(DOTTUXWS) && mkdir bin
	cp $(DotTuxWSAssembly) build/$(DOTTUXWS)/bin
	cp $(DotTuxWSInteropDLL) build/$(DOTTUXWS)/bin
	cp $(MSVCR71DLL) build/$(DOTTUXWS)/bin
	attrib -r build/$(DOTTUXWS)/bin/*.dll
	cd build && pacomp -a -r -P $(DOTTUXWSPKG).zip $(DOTTUXWS)\*

clean:
	rm -rf build

upload:
	cd build && $(upload) $(DOTTUXPKG).zip $(DOTTUXWSPKG).zip $(upload_target)
