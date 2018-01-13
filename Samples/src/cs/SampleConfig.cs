using DotTux.Tmib;
using DotTux.Atmi;
using DotTux.Fml32;
using DotTux;
using System.IO;
using System.Collections;
using System;

public class SampleConfig
{
    private static string TUXDIR;
    private static string APPDIR;
    
    private static bool hasWSL;
    
    private static string TUXCONFIG;
    private static string TLOG;
    private static string QSPACE;
    
    public static void Main(string[] args)
    {
        Init();
        
        Config();
    }
    
    static void Init()
    {
        TUXDIR = TUX.tuxgetenv("TUXDIR");
        if (TUXDIR == null) {
            Console.WriteLine("ERROR: Environment variable TUXDIR not set");
            Environment.Exit(1);
        }
        
        APPDIR = Environment.CurrentDirectory;
        
        hasWSL = File.Exists(TUXDIR + "\\bin\\WSL.exe");
        
        TUXCONFIG = APPDIR + "\\TUXCONFIG";
        if (File.Exists(TUXCONFIG)) {
            File.Delete(TUXCONFIG);
        }
        
        TLOG = APPDIR + "\\TLOG";
        if (File.Exists(TLOG)) {
            File.Delete(TLOG);
        }
        
        QSPACE = APPDIR + "\\QSPACE";
        if (File.Exists(QSPACE)) {
            File.Delete(QSPACE);
        }
        
        TUX.tuxputenv("TUXCONFIG=" + TUXCONFIG);
        
        FML32.AddFieldTable(TUXDIR + "\\udataobj\\tpadm");
    }
    
    static void Config()
    {
        Create("T_DOMAIN", new string[] {
            "TA_IPCKEY=51966",
            "TA_MODEL=SHM",
            "TA_MASTER=master",
            "TA_MAXWSCLIENTS=10",
        });
        
        Update("T_MACHINE", new string[] {
            "TA_LMID=master",
            "TA_APPDIR=" + APPDIR,
            "TA_TLOGDEVICE=" + TLOG,
            "TA_ULOGPFX=" + APPDIR + "\\ULOG"
        });
        
        Create("T_DEVICE", new string[] {
            "TA_CFGDEVICE=" + TLOG,
            "TA_DEVSIZE=200"
        });
        
        Create("T_GROUP", new string[] {
            "TA_SRVGRP=DGRP",
            "TA_LMID=master",
            "TA_GRPNO=1"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=DotServer",
            "TA_SRVGRP=DGRP",
            "TA_SRVID=1",
            "TA_CLOPT=-- -s TOUPPER Samples.dll SimpleServer"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=DotServer",
            "TA_SRVGRP=DGRP",
            "TA_SRVID=2",
            "TA_CONV=Y",
            "TA_CLOPT=-- -s DOWNLOAD Samples.dll DownloadServer",
            "TA_MINDISPATCHTHREADS=3",
            "TA_MAXDISPATCHTHREADS=9"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=DotServer",
            "TA_SRVGRP=DGRP",
            "TA_SRVID=3",
            "TA_CLOPT=-- -s NOTIFY_TOUPPER,BRDCST_TOUPPER Samples.dll UnsolServer"
        });

        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=DotServer",
            "TA_SRVGRP=DGRP",
            "TA_SRVID=4",
            "TA_CLOPT=-- -s PUBLISH_TIME Samples.dll TimePublisher"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=DotServer",
            "TA_SRVGRP=DGRP",
            "TA_SRVID=5",
            "TA_CLOPT=-- -s FML32_TOUPPER Samples.dll SimpleFML32Server"
        });
        
        Create("T_GROUP", new string[] {
            "TA_SRVGRP=EGRP",
            "TA_LMID=master",
            "TA_GRPNO=2"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=TMUSREVT",
            "TA_SRVGRP=EGRP",
            "TA_SRVID=1",
            "TA_CLOPT=-A --"
        });
        
        Create("T_DEVICE", new string[] {
            "TA_CFGDEVICE=" + QSPACE,
            "TA_DEVSIZE=2000"
        });
        
        Create("T_APPQSPACE", new string[] {
            "TA_APPQSPACENAME=QSPACE",
            "TA_QMCONFIG=" + QSPACE,
            "TA_LMID=master",
            "TA_IPCKEY=47787",
            "TA_MAXMSG=10000",
            "TA_MAXPAGES=1000",
            "TA_MAXPROC=100",
            "TA_MAXQUEUES=50",
            "TA_MAXTRANS=100"
        });

        Create("T_APPQ", new string[] {
            "TA_APPQSPACENAME=QSPACE",
            "TA_QMCONFIG=" + QSPACE,
            "TA_APPQNAME=TOUPPER"
        });
        
        Create("T_APPQ", new string[] {
            "TA_APPQSPACENAME=QSPACE",
            "TA_QMCONFIG=" + QSPACE,
            "TA_APPQNAME=TOUPPER_RET"
        });
        
        Clean("T_APPQSPACE", new string[] {
            "TA_APPQSPACENAME=QSPACE",
            "TA_QMCONFIG=" + QSPACE,
            "TA_LMID=master",
        });
    
        Create("T_GROUP", new string[] {
            "TA_SRVGRP=QGRP",
            "TA_LMID=master",
            "TA_GRPNO=3",
            "TA_TMSNAME=TMS_QM",
            "TA_OPENINFO=TUXEDO/QM:" + QSPACE + ";QSPACE"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=TMQUEUE",
            "TA_SRVGRP=QGRP",
            "TA_SRVID=1",
            "TA_CLOPT=-s QSPACE:TMQUEUE -- -t 5"
        });

        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=TMQFORWARD",
            "TA_SRVGRP=QGRP",
            "TA_SRVID=2",
            "TA_CLOPT=-- -q TOUPPER -i 1 -n"
        });
        
        if (!hasWSL) {
            Console.WriteLine("INFO: WSL not found, skipping WGRP");
            return;
        }
    
        Create("T_GROUP", new string[] {
            "TA_SRVGRP=WGRP",
            "TA_LMID=master",
            "TA_GRPNO=4"
        });
        
        Create("T_SERVER", new string[] {
            "TA_SERVERNAME=WSL",
            "TA_SRVGRP=WGRP",
            "TA_SRVID=1",
            "TA_CLOPT=-A -- -n //localhost:55555 -m 1"
        });
    }

    static void Create(string cls, string[] attributes)
    {
        Set(cls, "NEW", attributes);
    }
    
    static void Update(string cls, string[] attributes)
    {
        Set(cls, null, attributes);
    }
    
    static void Clean(string cls, string[] attributes)
    {
        Set(cls, "CLEANING", attributes);
    }    
    
    static void Set(string cls, string state, string[] attributes)
    {
        ByteBuffer fbfr = ATMI.tpalloc("FML32", null, 1024);
        try {
            TPFBuilder.I.FaddString(ref fbfr, TMIB.TA_OPERATION, "SET");
            TPFBuilder.I.FaddString(ref fbfr, TMIB.TA_CLASS, cls);
            if (state != null) {
                TPFBuilder.I.FaddString(ref fbfr, TMIB.TA_STATE, state);
                if (state.Equals("CLEANING")) {
                    TPFBuilder.I.FaddInt(ref fbfr, TMIB.TA_FLAGS, TMIB.QMIB_FORCECLOSE);
                }
            }
            foreach (string attribute in attributes) {
                int eqPos = attribute.IndexOf('=');
                string key = attribute.Substring(0, eqPos);
                string val = attribute.Substring(eqPos + 1);
                int fieldID = FML32.Fldid(key);
                TPFBuilder.I.FaddString(ref fbfr, fieldID, val);
            }
            try {
                Console.WriteLine("INFO: Executing " + cls + ".SET(" + state + ", "
                     + ToString(attributes) + ")");
                ATMI.tpadmcall(fbfr, ref fbfr, 0);
            } catch (TPEMIB) {
                Console.WriteLine("ERROR: " + FML32.ToString(fbfr));
                Environment.Exit(1);
            }
        } finally {
            ATMI.tpfree(fbfr);
        }
    }

    static string ToString(String[] strArray)
    {
        string result = null;
        foreach (string str in strArray) {
            if (result == null) {
                result = str;
            } else {
                result = result + ", " + str;
            }
        }
        return result;
    }
}
