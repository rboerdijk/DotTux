# Copyright 2004 OTP Systems Oy. All rights reserved.

BASE_DIR := .

default: bin

include $(BASE_DIR)/Makefile.include

# See GNU Make section 4.6 "Phony Targets" for more information about the
# build strategy below.

BINDIRS := CTools/Platform/Library \
	   CTools/Tuxedo/Library \
	   CTools/Tuxedo/Qipcrm \
	   Classes \
	   Interop \
	   DotClient \
	   DotServer \
	   Packages \
	   Samples

DOCDIRS := DocTools \
	   Docs

SUBDIRS := $(BINDIRS) $(DOCDIRS)

CLEAN_SUBDIRS := $(foreach SUBDIR,$(SUBDIRS),$(SUBDIR).clean)

.PHONY: $(SUBDIRS) $(CLEAN_SUBDIRS)

# Main build target

all: bin doc

bin: $(BINDIRS)

doc: $(DOCDIRS)

$(SUBDIRS):
	$(MAKE) -C $@

# Dependency declarations (needed for parallel and isolated builds)

Libraries := CTools/Tuxedo/Library CTools/Platform/Library

Interop: $(Libraries)

DotClient: $(Libraries)

DotServer: $(Libraries)

Packages: Classes Interop DotClient DotServer CTools/Tuxedo/Qipcrm 

Samples: Packages 

# Cleanup

clean: $(CLEAN_SUBDIRS)
	rm -rf build

$(CLEAN_SUBDIRS):
	$(MAKE) -C $(basename $@) clean

test:
	$(MAKE) -C Samples test
