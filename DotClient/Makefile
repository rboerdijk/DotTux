# Copyright 2004 OTP Systems Oy. All rights reserved

BASE_DIR := ..

default: all

include $(BASE_DIR)/Makefile.include

all: $(DotClient)

$(DotClient): src/cpp/DotClient.cpp
	-mkdir build
	cd build && buildclient -v -o $(DotClient) -f "$(CFLAGS) /clr /AI../../Classes/build ../src/cpp/DotClient.cpp"

clean:
	rm -rf build
