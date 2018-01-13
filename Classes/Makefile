# Copyright 2004 OTP Systems Oy. All rights reserved.

BASE_DIR := ..

default: all

include $(BASE_DIR)/Makefile.include

all: $(DotTuxAssembly) $(DotTuxWSAssembly)

$(DotTuxAssembly) $(DotTuxWSAssembly):
	-mkdir build
	copy src\sn\DotTux.snk build
	copy src\sn\DotTuxWS.snk build
	cd src\cs && csc /warnaserror+ /t:library /out:$(DotTuxAssembly) DotTux\*.cs DotTux\Atmi\*.cs DotTux\FML32\*.cs DotTux\Tmib\*.cs DotTux\Install\TestServer.cs
	cd src\cs && csc /warnaserror+ /t:library /define:WSCLIENT /out:$(DotTuxWSAssembly) DotTux\*.cs DotTux\Atmi\*.cs DotTux\Fml32\*.cs

clean:
	rm -rf build
