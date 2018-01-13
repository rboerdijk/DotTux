/*
 * Copyright 2004 OTP Systems Oy. All rights reserved.
 */

namespace DotTux.Tmib
{
    /// <summary>
    /// Defines symbolic constants for interacting with the Tuxedo MIB.
    /// </summary>

    public class TMIB
    {
	private TMIB()
       	{
	   // Nothing to do, just make sure it is not public.
	}

	// The following symbol table was generated using OTPTuxSymbolDumper

	/// <summary>TMIB field identifier</summary>
	public const int TA_ATTFLAGS = 33560884;

	/// <summary>TMIB field identifier</summary>
	public const int TA_ATTRIBUTE = 33560432;

	/// <summary>TMIB field identifier</summary>
	public const int TA_BADFLD = 33560433;

	/// <summary>TMIB field identifier</summary>
	public const int TA_CLASS = 167778162;

	/// <summary>TMIB field identifier</summary>
	public const int TA_CLASSNAME = 167778163;

	/// <summary>TMIB field identifier</summary>
	public const int TA_CURSOR = 167778164;

	/// <summary>TMIB field identifier</summary>
	public const int TA_CURSORHOLD = 33560437;

	/// <summary>TMIB field identifier</summary>
	public const int TA_DEFAULT = 167778615;

	/// <summary>TMIB field identifier</summary>
	public const int TA_ERROR = 33560438;

	/// <summary>TMIB field identifier</summary>
	public const int TA_EVENT_DESCRIPTION = 167779165;

	/// <summary>TMIB field identifier</summary>
	public const int TA_EVENT_LMID = 167779162;

	/// <summary>TMIB field identifier</summary>
	public const int TA_EVENT_NAME = 167779160;

	/// <summary>TMIB field identifier</summary>
	public const int TA_EVENT_SEVERITY = 167779161;

	/// <summary>TMIB field identifier</summary>
	public const int TA_EVENT_TIME = 33561435;

	/// <summary>TMIB field identifier</summary>
	public const int TA_EVENT_USEC = 33561436;

	/// <summary>TMIB field identifier</summary>
	public const int TA_FACTPERM = 33560888;

	/// <summary>TMIB field identifier</summary>
	public const int TA_FILTER = 33560439;

	/// <summary>TMIB field identifier</summary>
	public const int TA_FLAGS = 33560440;

	/// <summary>TMIB field identifier</summary>
	public const int TA_GETSTATES = 167778617;

	/// <summary>TMIB field identifier</summary>
	public const int TA_INASTATES = 167778623;

	/// <summary>TMIB field identifier</summary>
	public const int TA_MAXPERM = 33560901;

	/// <summary>TMIB field identifier</summary>
	public const int TA_MIBTIMEOUT = 33560441;

	/// <summary>TMIB field identifier</summary>
	public const int TA_MORE = 33560442;

	/// <summary>TMIB field identifier</summary>
	public const int TA_OCCURS = 33560443;

	/// <summary>TMIB field identifier</summary>
	public const int TA_OPERATION = 167778172;

	/// <summary>TMIB field identifier</summary>
	public const int TA_PERM = 33560445;

	/// <summary>TMIB field identifier</summary>
	public const int TA_SETSTATES = 167778639;

	/// <summary>TMIB field identifier</summary>
	public const int TA_STATE = 167778174;

	/// <summary>TMIB field identifier</summary>
	public const int TA_STATUS = 167778175;

	/// <summary>TMIB field identifier</summary>
	public const int TA_ULOGCAT = 167778588;

	/// <summary>TMIB field identifier</summary>
	public const int TA_ULOGMSGNUM = 33560863;

	/// <summary>TMIB field identifier</summary>
	public const int TA_VALIDATION = 167778597;

	/// <summary>TMIB status code</summary>
	public const int TAOK = 0;

	/// <summary>TMIB status code</summary>
	public const int TAUPDATED = 1;

	/// <summary>TMIB status code</summary>
	public const int TAPARTIAL = 2;

	/// <summary>TMIB flag</summary>
	public const int MIB_LOCAL = 0x10000;

	/// <summary>TMIB flag</summary>
	public const int MIB_PREIMAGE = 0x1;

	/// <summary>TMIB flag</summary>
	public const int MIB_SELF = 0x100000;

	/// <summary>TMIB error code</summary>
	public const int TAEAPP = -1;

	/// <summary>TMIB error code</summary>
	public const int TAECONFIG = -2;

	/// <summary>TMIB error code</summary>
	public const int TAEINVAL = -3;

	/// <summary>TMIB error code</summary>
	public const int TAEOS = -4;

	/// <summary>TMIB error code</summary>
	public const int TAEPERM = -5;

	/// <summary>TMIB error code</summary>
	public const int TAEPREIMAGE = -6;

	/// <summary>TMIB error code</summary>
	public const int TAEPROTO = -7;

	/// <summary>TMIB error code</summary>
	public const int TAEREQUIRED = -8;

	/// <summary>TMIB error code</summary>
	public const int TAESUPPORT = -9;

	/// <summary>TMIB error code</summary>
	public const int TAESYSTEM = -10;

	/// <summary>TMIB error code</summary>
	public const int TAEUNIQ = -11;

	/// <summary>TM_MIB flag</summary>
	public const int TMIB_ADMONLY = 0x40000;

	/// <summary>TM_MIB flag</summary>
	public const int TMIB_APPONLY = 0x200000;

	/// <summary>TM_MIB flag</summary>
	public const int TMIB_CONFIG = 0x80000;

	/// <summary>TM_MIB flag</summary>
	public const int TMIB_NOTIFY = 0x20000;

	/// <summary>APPQ_MIB flag</summary>
	public const int QMIB_FORCECLOSE = 0x20000;

	/// <summary>APPQ_MIB flag</summary>
	public const int QMIB_FORCEDELETE = 0x80000;

	/// <summary>APPQ_MIB flag</summary>
	public const int QMIB_FORCEPURGE = 0x40000;

	/// <summary>TMIB attribute flag</summary>
	public const int MIBATT_KEYFIELD = 0x1;

	/// <summary>TMIB attribute flag</summary>
	public const int MIBATT_LOCAL = 0x2;

	/// <summary>TMIB attribute flag</summary>
	public const int MIBATT_REGEXKEY = 0x4;

	/// <summary>TMIB attribute flag</summary>
	public const int MIBATT_REQUIRED = 0x8;

	/// <summary>TMIB attribute flag</summary>
	public const int MIBATT_SETKEY = 0x10;

	/// <summary>TMIB attribute flag</summary>
	public const int MIBATT_NEWONLY = 0x20;
    }
}
