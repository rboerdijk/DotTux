# Copyright 2004 OTP Systems Oy. All rights reserved.

BASE_DIR := ..

include $(BASE_DIR)/Makefile.include

all:
	$(MAKE) -C DotTux
	$(MAKE) -C DotTuxWS

clean:
	$(MAKE) -C DotTux clean
	$(MAKE) -C DotTuxWS clean

packages:
	$(MAKE) -C DotTux package
	$(MAKE) -C DotTuxWS package

upload: packages
	$(upload) DotTux/build/*.tar.gz DotTuxWS/build/*.tar.gz $(upload_target)
