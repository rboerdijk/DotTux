/*
 * Copyright 2003, 2004 OTP Systems Oy. All rights reserved.
 */

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace DotTux
{
    /// <summary>
    /// Provides methods for writing to the Tuxedo ULOG and for
    /// getting and setting environment variables. 
    /// </summary>

    public class TUX
    {
	private TUX()
       	{
	    // Nothing to do, just make sure it is not public.
       	}

        /// <summary>
        /// Returns the value of an environment variable.
        /// </summary>
	///
	/// <param name="name">
	/// The name of the environment variable; must not be null.
	/// </param>
	///
        /// <returns>
        /// The value of the environment variable or null if the environment
	/// variable is not set.
        /// </returns>
	///
	/// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>
        
        public static string tuxgetenv(string name)
	{
	    if (name == null) {
		throw new ArgumentException("name must not be null");
	    } else {
	        IntPtr value = DotTuxInterop.tuxgetenv(name);
		if (value == IntPtr.Zero) {
		    return null;
		} else {
		    return Marshal.PtrToStringAnsi(value);
		}
	    }
	}

        /// <summary>
        /// Sets the value of an environment variable.
        /// </summary>
	///
	/// <param name="setting">
	/// An environment setting of the form <c>name=value</c>;
	/// must not be null.
	/// </param>
	///
	/// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>

        public static void tuxputenv(string setting)
	{
	    if (setting == null) {
		throw new ArgumentException("setting must not be null");
	    } else {
		DotTuxInterop.tuxputenv(setting);
	    }
	}

        /// <summary>
        /// Reads environment settings from a file.
        /// </summary>
        ///
        /// <param name="file">
        /// The name of the file containing the environment settings to 
        /// read. If <paramref name="file"/> is null then a default file 
        /// name is used.
        /// </param> 
	///
        /// <param name="label">
        /// The name of a label in <paramref name="file"/> that identifies 
        /// a section of environment settings to read in addition to the
        /// global section. If <paramref name="label"/> is null then only 
        /// the global section is read.
        /// </param> 
	///
        /// <exception cref="IOException">
        /// An error occurred reading the environment settings.
        /// The error details were written to the Tuxedo ULOG.
        /// </exception>
        
        public static void tuxreadenv(string file, string label)
        {
            if (DotTuxInterop.tuxreadenv(file, label) != 0) {
                if (file == null) {
                    file = "default environment file";
                }
                throw new IOException("Error reading environment settings "
                    + "from " + file + " (see ULOG for error details)");
            }
        }

        /// <summary>
        /// Logs a message in the Tuxedo ULOG.
        /// </summary>
        /// 
        /// <param name="message">
        /// The message to log; must not be null.
        /// </param> 
	///
	/// <exception cref="System.ArgumentException">
	/// An invalid argument value was passed.
	/// </exception>

        public static void userlog(string message)
	{
	    if (message == null) {
		throw new ArgumentException("message must not be null");
	    } else {
	        byte[] bytes = Encoding.Default.GetBytes(message);
		DotTuxInterop.userlog(bytes, bytes.Length);
	    }
	}
    }
}
