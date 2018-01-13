/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Text;
using System.Runtime.InteropServices;

using DotTux;

namespace DotTux.Fml32
{
    /// <summary>
    /// Thrown if an FML32 system call failed.
    /// </summary>
    /// 
    /// <remarks> 
    /// An FException carries an FML32 error code that identifies the reason why 
    /// the exception was thrown. 
    /// The symbolic constants for these error codes are defined in the FML32 class. 
    /// </remarks>

    public class FException: ApplicationException
    {
	private int err;

	internal FException(int err)
	{
	    this.err = err;
	}

        /// <summary>
        /// The FML32 error code that identifies the reason why this 
        /// exception was thrown.
        /// </summary>

        public int Ferror
	{
            get {
	        return err;
            }
	}

        /// <summary>
        /// A short message that describes the reason why this 
        /// exception was thrown.
        /// </summary>
        
	override public string Message
	{
	    get {
		string s = FML32.Fstrerror(err);
                if (s == null) {
		    return "Ferror=" + err;
		} else {
		    return s;
                }
	    }
	}

	internal static FException NewFException(int err)
	{
	    switch (err) {
		case FML32.FALIGNERR:
		    throw new FALIGNERR();
		case FML32.FNOTFLD:
		    throw new FNOTFLD();
		case FML32.FNOSPACE:
		    throw new FNOSPACE();
		case FML32.FNOTPRES:
		    throw new FNOTPRES();
		case FML32.FBADFLD:
		    throw new FBADFLD();
		case FML32.FTYPERR:
		    throw new FTYPERR();
		case FML32.FEUNIX:
		    throw new FEUNIX();
		case FML32.FBADNAME:
		    throw new FBADNAME();
		case FML32.FMALLOC:
		    throw new FMALLOC();
		case FML32.FSYNTAX:
		    throw new FSYNTAX();
		case FML32.FFTOPEN:
		    throw new FFTOPEN();
		case FML32.FFTSYNTAX:
		    throw new FFTSYNTAX();
		case FML32.FEINVAL:
		    throw new FEINVAL();
		case FML32.FBADTBL:
		    throw new FBADTBL();
		case FML32.FBADVIEW:
		    throw new FBADVIEW();
		case FML32.FVFSYNTAX:
		    throw new FVFSYNTAX();
		case FML32.FVFOPEN:
		    throw new FVFOPEN();
		case FML32.FBADACM:
		    throw new FBADACM();
		case FML32.FNOCNAME:
		    throw new FNOCNAME();
		case FML32.FEBADOP:
		    throw new FEBADOP();
		default:
		    return new FException(err);
	    }
	}
    }

    /// <summary>
    /// Thrown if an incorrectly aligned buffer was passed to
    /// an FML32 system call.
    /// </summary>
    
    public class FALIGNERR: FException
    {
	internal FALIGNERR() : base(FML32.FALIGNERR) {}
    }

    /// <summary>
    /// Thrown if a non-FML32 buffer was passed to an FML32
    /// system call.
    /// </summary>
    
    public class FNOTFLD: FException
    {
	internal FNOTFLD() : base(FML32.FNOTFLD) {}
    }

    /// <summary>
    /// Thrown if there is no space for adding a field to
    /// an FML32 buffer.
    /// </summary>
    
    public class FNOSPACE: FException
    {
	internal FNOSPACE() : base(FML32.FNOSPACE) {}
    }

    /// <summary>
    /// Thrown if a requested field is not present in an
    /// FML32 buffer.
    /// </summary>
    
    public class FNOTPRES: FException
    {
	internal FNOTPRES() : base(FML32.FNOTPRES) {}
    }

    /// <summary>
    /// Thrown if an invalid field identifier was passed to
    /// an FML32 system call.
    /// </summary>
    
    public class FBADFLD: FException
    {
	internal FBADFLD() : base(FML32.FBADFLD) {}
    }

    /// <summary>
    /// Thrown if an invalid field type was passed to an
    /// FML32 system call.
    /// </summary>
    
    public class FTYPERR: FException
    {
	internal FTYPERR() : base(FML32.FTYPERR) {}
    }

    /// <summary>
    /// Thrown if an OS level system error occurred.
    /// </summary>
    
    public class FEUNIX: FException
    {
	internal FEUNIX() : base(FML32.FEUNIX) {}
    }

    /// <summary>
    /// Thrown if an invalid field name was passed to an
    /// FML32 system call.
    /// </summary>
    
    public class FBADNAME: FException
    {
	internal FBADNAME() : base(FML32.FBADNAME) {}
    }

    /// <summary>
    /// Thrown if a memory allocation failure occurred.
    /// </summary>
    
    public class FMALLOC: FException
    {
	internal FMALLOC() : base(FML32.FMALLOC) {}
    }

    /// <summary>
    /// Thrown if an invalid boolean expression was passed
    /// to an FML32 system call.
    /// </summary>
    
    public class FSYNTAX: FException
    {
	internal FSYNTAX() : base(FML32.FSYNTAX) {}
    }

    // Not documented => hide.
    
    internal class FFTOPEN: FException
    {
	internal FFTOPEN() : base(FML32.FFTOPEN) {}
    }

    // Not documented => hide.
    
    internal class FFTSYNTAX: FException
    {
	internal FFTSYNTAX() : base(FML32.FFTSYNTAX) {}
    }

    /// <summary>
    /// Thrown if an invalid argument was passed to an
    /// FML32 system call.
    /// </summary>
    
    public class FEINVAL: FException
    {
	internal FEINVAL() : base(FML32.FEINVAL) {}
    }

    // Not documented => hide.
    
    internal class FBADTBL: FException
    {
	internal FBADTBL() : base(FML32.FBADTBL) {}
    }

    /// <summary>
    /// Thrown if a named view could not be found.
    /// </summary>
    
    public class FBADVIEW: FException
    {
	internal FBADVIEW() : base(FML32.FBADVIEW) {}
    }

    /// <summary>
    /// Thrown if an invalid view file was encountered.
    /// </summary>
    
    public class FVFSYNTAX: FException
    {
	internal FVFSYNTAX() : base(FML32.FVFSYNTAX) {}
    }

    /// <summary>
    /// Thrown if a view file could not be opened.
    /// </summary>
    
    public class FVFOPEN: FException
    {
	internal FVFOPEN() : base(FML32.FVFOPEN) {}
    }

    /// <summary>
    /// Thrown if an invalid ACM was passed to an FML32
    /// system call.
    /// </summary>
    
    public class FBADACM: FException
    {
	internal FBADACM() : base(FML32.FBADACM) {}
    }

    /// <summary>
    /// Thrown if the name of a C struct field could not be found.
    /// </summary>
    
    public class FNOCNAME: FException
    {
	internal FNOCNAME() : base(FML32.FNOCNAME) {}
    }

    /// <summary>
    /// Thrown if a buffer containing an unsupported field type was passed to
    /// an FML32 system call.
    /// </summary>
    
    public class FEBADOP: FException
    {
	internal FEBADOP() : base(FML32.FEBADOP) {}
    }
}
