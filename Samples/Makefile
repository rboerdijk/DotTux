# Copyright 2004 OTP Systems Oy. All rights reserved.

BASE_DIR := ..

default: samples

include ../Makefile.include

DOTTUXDIR := $(shell cd)\..\Packages\build\DotTux-$(DotTux_version)
DOTTUXWSDIR := $(shell cd)\..\Packages\build\DotTuxWS-$(DotTux_version)

CSC := csc /reference:$(DOTTUXDIR)\bin\DotTux.dll
CSCWS := csc /reference:$(DOTTUXWSDIR)\bin\DotTuxWS.dll

DOTCLIENT := $(DOTTUXDIR)\bin\DotClient

test: samples sample_config boot run_samples shutdown

samples: samples_dll sample_exes sample_ws_exes

samples_dll: build
	$(CSC) /target:library /out:build\Samples.dll src\cs\\*.cs

sample_exes: build
	$(CSC) /out:build\SimpleClient.exe src\cs\SimpleClient.cs
	$(CSC) /out:build\SimpleAsyncClient.exe src\cs\SimpleAsyncClient.cs src\cs\StringUtils.cs
	$(CSC) /out:build\DownloadClient.exe src\cs\DownloadClient.cs src\cs\StringUtils.cs
	$(CSC) /out:build\SimpleEnqueuer.exe src\cs\SimpleEnqueuer.cs src\cs\StringUtils.cs
	$(CSC) /out:build\SimpleDequeuer.exe src\cs\SimpleDequeuer.cs src\cs\StringUtils.cs
	$(CSC) /out:build\UnsolClient.exe src\cs\UnsolClient.cs src\cs\StringUtils.cs
	$(CSC) /out:build\SimpleSubscriber.exe src\cs\SimpleSubscriber.cs src\cs\StringUtils.cs
	$(CSC) /out:build\SimpleFML32Client.exe src\cs\SimpleFML32Client.cs src\cs\StringUtils.cs

sample_ws_exes: build
	$(CSCWS) /out:build\SimpleClientWS.exe src\cs\SimpleClient.cs
	$(CSCWS) /out:build\SimpleAsyncClientWS.exe src\cs\SimpleAsyncClient.cs src\cs\StringUtils.cs
	$(CSCWS) /out:build\DownloadClientWS.exe src\cs\DownloadClient.cs src\cs\StringUtils.cs
	$(CSCWS) /out:build\SimpleEnqueuerWS.exe src\cs\SimpleEnqueuer.cs src\cs\StringUtils.cs
	$(CSCWS) /out:build\SimpleDequeuerWS.exe src\cs\SimpleDequeuer.cs src\cs\StringUtils.cs
	$(CSCWS) /out:build\UnsolClientWS.exe src\cs\UnsolClient.cs src\cs\StringUtils.cs
	$(CSCWS) /out:build\SimpleSubscriberWS.exe src\cs\SimpleSubscriber.cs src\cs\StringUtils.cs
	$(CSCWS) /out:build\SimpleFML32ClientWS.exe src\cs\SimpleFML32Client.cs src\cs\StringUtils.cs

export TUXCONFIG := $(shell cd)\build\TUXCONFIG

sample_config:
	cd build && $(DOTCLIENT) Samples.dll SampleConfig

boot:
	set "PATH=$(TUXDIR)\bin;$(DOTTUXDIR)\bin" && tmboot -y

shutdown:
	tmshutdown -y
	-$(DOTTUXDIR)\bin\Qipcrm build\QSPACE master QSPACE

run_samples: run_dll_samples run_sample_exes run_sample_ws_exes

export FIELDTBLS32 := $(TUXDIR)\udataobj\tpadm

RUN_DLL_SAMPLE := $(DOTCLIENT) build\Samples.dll

run_dll_samples:
	$(RUN_DLL_SAMPLE) SimpleClient "Hello, World"
	$(RUN_DLL_SAMPLE) SimpleAsyncClient "Hello, World"
	$(RUN_DLL_SAMPLE) DownloadClient TUXCONFIG build\TUXCONFIG.downloaded.1
	$(RUN_DLL_SAMPLE) SimpleEnqueuer QSPACE TOUPPER "Hello, World" TOUPPER_RET
	$(RUN_DLL_SAMPLE) SimpleDequeuer QSPACE TOUPPER_RET
	$(RUN_DLL_SAMPLE) UnsolClient NOTIFY_TOUPPER "Hello, World"
	$(RUN_DLL_SAMPLE) UnsolClient BRDCST_TOUPPER "Hello, World"
	$(RUN_DLL_SAMPLE) SimpleSubscriber TIME
	$(RUN_DLL_SAMPLE) SimpleFML32Client TA_CLASS=t_domain TA_MODEL=shm TA_MASTER=master

run_sample_exes:
	copy $(DOTTUXDIR)\bin\DotTux.dll build
	copy $(DOTTUXDIR)\bin\DotTuxInterop.dll build
	build\SimpleClient "Hello, World"
	build\SimpleAsyncClient "Hello, World"
	build\DownloadClient TUXCONFIG build\TUXCONFIG.downloaded.2
	build\SimpleEnqueuer QSPACE TOUPPER "Hello, World" TOUPPER_RET
	build\SimpleDequeuer QSPACE TOUPPER_RET
	build\UnsolClient NOTIFY_TOUPPER "Hello, World"
	build\UnsolClient BRDCST_TOUPPER "Hello, World"
	build\SimpleSubscriber TIME
	build\SimpleFML32Client TA_CLASS=t_domain TA_MODEL=shm TA_MASTER=master

export WSNADDR := //localhost:55555

run_sample_ws_exes:
	copy $(DOTTUXWSDIR)\bin\DotTuxWS.dll build
	copy $(DOTTUXWSDIR)\bin\DotTuxWSInterop.dll build
	build\SimpleClientWS "Hello, World"
	build\SimpleAsyncClientWS "Hello, World"
	build\DownloadClientWS TUXCONFIG build\TUXCONFIG.downloaded.3
	build\SimpleEnqueuerWS QSPACE TOUPPER "Hello, World" TOUPPER_RET
	build\SimpleDequeuerWS QSPACE TOUPPER_RET
	build\UnsolClientWS NOTIFY_TOUPPER "Hello, World"
	build\UnsolClientWS BRDCST_TOUPPER "Hello, World"
	build\SimpleSubscriberWS TIME
	build\SimpleFML32ClientWS TA_CLASS=t_domain TA_MODEL=shm TA_MASTER=master

build:
	mkdir build

clean:
	rm -rf build
