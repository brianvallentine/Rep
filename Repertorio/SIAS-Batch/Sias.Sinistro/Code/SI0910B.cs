using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Copies;
using Sias.Sinistro.DB2.SI0910B;

namespace Code
{
    public class SI0910B
    {
        public bool IsCall { get; set; }

        public SI0910B()
        {
            AppSettings.Load();
        }

        #region VARIABLES

        public FileBasis _SIJC0910 { get; set; } = new FileBasis(new PIC("X", "80", "X(80)"));

        public FileBasis SIJC0910
        {
            get
            {
                _.Move(REG_JC0910, _SIJC0910); VarBasis.RedefinePassValue(REG_JC0910, _SIJC0910, REG_JC0910); return _SIJC0910;
            }
        }
        /*"01 REG-JC0910.*/
        public SI0910B_REG_JC0910 REG_JC0910 { get; set; } = new SI0910B_REG_JC0910();
        public class SI0910B_REG_JC0910 : VarBasis
        {
            /*"   05 JC0910-LINHA PIC  X(80).*/
            public StringBasis JC0910_LINHA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        }

        /*"77 WS-DT-SISTEMA        PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-HR-SISTEMA        PIC X(10) VALUE SPACES.*/
        public StringBasis WS_HR_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-FLAG-DT-LIMITE    PIC X(01) VALUE 'N'.*/
        public StringBasis WS_FLAG_DT_LIMITE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"N");
        /*"77 WS-PRIMEIRA-PRODUCAO PIC 9(01) VALUE 0.*/
        public IntBasis WS_PRIMEIRA_PRODUCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"01 WS-CALL.*/
        public SI0910B_WS_CALL WS_CALL { get; set; } = new SI0910B_WS_CALL();
        public class SI0910B_WS_CALL : VarBasis
        {
            /*"   03 WS-ID-AMBIENTE        PIC X(03).*/
            public StringBasis WS_ID_AMBIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"   03 FILLER                PIC X(003).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"01 WS-AREA-TRABALHO.*/
        }
        public SI0910B_WS_AREA_TRABALHO WS_AREA_TRABALHO { get; set; } = new SI0910B_WS_AREA_TRABALHO();
        public class SI0910B_WS_AREA_TRABALHO : VarBasis
        {
            /*"   03 WS-LOCAL              PIC  X(30) VALUE SPACES.*/
            public StringBasis WS_LOCAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"   03 WS-TIMESTAMP-INI      PIC  X(26).*/
            public StringBasis WS_TIMESTAMP_INI { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
            /*"   03 WS-DT-PROCESSAMENTO   PIC  X(10).*/
            public StringBasis WS_DT_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   03 WS-AUX-JCL            PIC  X(78).*/
            public StringBasis WS_AUX_JCL { get; set; } = new StringBasis(new PIC("X", "78", "X(78)."), @"");
            /*"   03 WS-HH-CURRENT         PIC  X(08) VALUE SPACES.*/
            public StringBasis WS_HH_CURRENT { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   03 WS-SQLCODE            PIC  9(03) VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"   03 WS-IND                PIC 9(004) VALUE ZEROS.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"   03 WS-TAM                PIC  9(04)  VALUE ZEROS.*/
            public IntBasis WS_TAM { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"01 WS-DISP-EDITADO          PIC  ZZZZZZZZ9.*/
        }
        public IntBasis WS_DISP_EDITADO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
        /*"01 WS-JCL-EXECUTA.*/
        public SI0910B_WS_JCL_EXECUTA WS_JCL_EXECUTA { get; set; } = new SI0910B_WS_JCL_EXECUTA();
        public class SI0910B_WS_JCL_EXECUTA : VarBasis
        {
            /*"    03 FILLER               PIC X(80) VALUE       "01//JDSI0932 JOB (,EV),'GESEF',TIME=1440,CLASS=D,".*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"01//JDSI0932 JOB (,EV),'GESEF',TIME=1440,CLASS=D,");
            /*"    03 FILLER               PIC X(80) VALUE       "02//         MSGCLASS=T,MSGLEVEL=(1,1), NOTIFY=TE05764".*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"02//         MSGCLASS=T,MSGLEVEL=(1,1), NOTIFY=TE05764");
            /*"    03 FILLER               PIC X(80) VALUE       "03//         REGION=0M".*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"03//         REGION=0M");
            /*"    03 FILLER               PIC X(80) VALUE       "04//JOBLIB   DD DISP=SHR,DSN=DSNA10.SDSNLOAD".*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"04//JOBLIB   DD DISP=SHR,DSN=DSNA10.SDSNLOAD");
            /*"    03 FILLER               PIC X(80) VALUE       "05//         DD DISP=SHR,DSN=DES.V01.LOAD".*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"05//         DD DISP=SHR,DSN=DES.V01.LOAD");
            /*"    03 FILLER               PIC X(80) VALUE       "06//STEPDEL  EXEC PGM=IEFBR14".*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"06//STEPDEL  EXEC PGM=IEFBR14");
            /*"    03 FILLER               PIC X(80) VALUE       "07//SYSTSPRT DD SYSOUT=*".*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"07//SYSTSPRT DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "08//SYSUDUMP DD SYSOUT=Z".*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"08//SYSUDUMP DD SYSOUT=Z");
            /*"    03 FILLER               PIC X(80) VALUE       "09//SYSUT1   DD DISP=(MOD,DELETE),UNIT=SYSALLDA,".*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"09//SYSUT1   DD DISP=(MOD,DELETE),UNIT=SYSALLDA,");
            /*"    03 FILLER               PIC X(80) VALUE       "10//         SPACE=(TRK,(5,5)),".*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"10//         SPACE=(TRK,(5,5)),");
            /*"    03 FILLER               PIC X(80) VALUE       "11//         DSN=DES.SI.DAAMMDD.INDENIZA.PRSTMSTA".*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"11//         DSN=DES.SI.DAAMMDD.INDENIZA.PRSTMSTA");
            /*"    03 FILLER               PIC X(80) VALUE       "12//STEP002  EXEC PGM=IKJEFT01,DYNAMNBR=20".*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"12//STEP002  EXEC PGM=IKJEFT01,DYNAMNBR=20");
            /*"    03 FILLER               PIC X(80) VALUE       "13//SYSTSPRT DD SYSOUT=*".*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"13//SYSTSPRT DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "14//SYSPRINT DD SYSOUT=*".*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"14//SYSPRINT DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "15//SYSUDUMP DD SYSOUT=Z".*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"15//SYSUDUMP DD SYSOUT=Z");
            /*"    03 FILLER               PIC X(80) VALUE       "16//SYSOUT   DD SYSOUT=*".*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"16//SYSOUT   DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "17//ARQ0932B DD DSN=DES.SI.DAAMMDD.INDENIZA.PRSTMSTA,".*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"17//ARQ0932B DD DSN=DES.SI.DAAMMDD.INDENIZA.PRSTMSTA,");
            /*"    03 FILLER               PIC X(80) VALUE       "18//         UNIT=SYSDA,DISP=(,CATLG,DELETE),".*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"18//         UNIT=SYSDA,DISP=(,CATLG,DELETE),");
            /*"    03 FILLER               PIC X(80) VALUE       "19//         SPACE=(TRK,(5000,500),RLSE),".*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"19//         SPACE=(TRK,(5000,500),RLSE),");
            /*"    03 FILLER               PIC X(80) VALUE      "20//         DCB=(RECFM=FB,LRECL=200,BLKSIZE=0,DSORG=PS)"*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"20//         DCB=(RECFM=FB,LRECL=200,BLKSIZE=0,DSORG=PS)");
            /*"    03 FILLER               PIC X(80) VALUE       "21//SYSDBOUT DD SYSOUT=*".*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"21//SYSDBOUT DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "22//SYSABOUT DD SYSOUT=*".*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"22//SYSABOUT DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "23//SYSTSIN  DD *".*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"23//SYSTSIN  DD *");
            /*"    03 FILLER               PIC X(80) VALUE       "24    DSN    SYSTEM(DB2D)".*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"24    DSN    SYSTEM(DB2D)");
            /*"    03 FILLER               PIC X(80) VALUE       "25    RUN    PROGRAM(SI0932B) PLAN(SIASBAT) -".*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"25    RUN    PROGRAM(SI0932B) PLAN(SIASBAT) -");
            /*"    03 FILLER               PIC X(80) VALUE       "26       LIB('DES.V01.LOAD')            -".*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"26       LIB('DES.V01.LOAD')            -");
            /*"    03 FILLER               PIC X(80) VALUE       "27       PARMS('/ABTERMENC(ABEND)')".*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"27       PARMS('/ABTERMENC(ABEND)')");
            /*"    03 FILLER               PIC X(80) VALUE       "28//*-------------------------------------------------*"*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"28//*-------------------------------------------------*");
            /*"    03 FILLER               PIC X(80) VALUE       "29//FTPD   EXEC PGM=FTP,REGION=4096K,TIME=NOLIMIT,".*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"29//FTPD   EXEC PGM=FTP,REGION=4096K,TIME=NOLIMIT,");
            /*"    03 FILLER               PIC X(80) VALUE       "30//            PARM='10.100.2.144'".*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"30//            PARM='10.100.2.144");
            /*"    03 FILLER               PIC X(80) VALUE       "31//STEPLIB  DD DSN=TCPIP.SEZALOAD,DISP=SHR".*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"31//STEPLIB  DD DSN=TCPIP.SEZALOAD,DISP=SHR");
            /*"    03 FILLER               PIC X(80) VALUE       "32//SYSTCPD  DD DSN=DES1.TCPPARMS(TCPDATA),DISP=SHR".*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"32//SYSTCPD  DD DSN=DES1.TCPPARMS(TCPDATA),DISP=SHR");
            /*"    03 FILLER               PIC X(80) VALUE       "33//SYSFTPD  DD DSN=DES1.TCPPARMS(FTPSDATA),DISP=SHR".*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"33//SYSFTPD  DD DSN=DES1.TCPPARMS(FTPSDATA),DISP=SHR");
            /*"    03 FILLER               PIC X(80) VALUE       "34//SYSMDUMP DD SYSOUT=Z".*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"34//SYSMDUMP DD SYSOUT=Z");
            /*"    03 FILLER               PIC X(80) VALUE       "35//SYSOUT   DD SYSOUT=*".*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"35//SYSOUT   DD SYSOUT=*");
            /*"    03 FILLER               PIC X(80) VALUE       "36//INPUT    DD *".*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"36//INPUT    DD *");
            /*"    03 FILLER               PIC X(80) VALUE       "37USERPROD USRPRD".*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"37USERPROD USRPRD");
            /*"    03 FILLER               PIC X(80) VALUE       "38*REM LOCSITE LRECL=130 BLKSIZE=0 RECFM=FB".*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"38*REM LOCSITE LRECL=130 BLKSIZE=0 RECFM=FB");
            /*"    03 FILLER               PIC X(80) VALUE       "39PUT 'DES.SI.DAAMMDD.INDENIZA.PRSTMSTA' +".*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"39PUT 'DES.SI.DAAMMDD.INDENIZA.PRSTMSTA' +");
            /*"    03 FILLER               PIC X(80) VALUE       "40'UPLOAD\TSUGUIRO\DES.SI.DAAMMDD.INDENIZA.PRSTMSTA.TXT'"       .*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"40'UPLOAD\TSUGUIRO\DES.SI.DAAMMDD.INDENIZA.PRSTMSTA.TXT");
            /*"    03 FILLER               PIC X(80) VALUE       "41PUT 'DES.SI.DAAMMDD.INDENIZA.PRSTMSTA' +".*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"41PUT 'DES.SI.DAAMMDD.INDENIZA.PRSTMSTA' +");
            /*"    03 FILLER               PIC X(80) VALUE       "42'UPLOAD\DIOGO\DES.SI.DAAMMDD.INDENIZA.PRSTMSTA.TXT'"       .*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"42'UPLOAD\DIOGO\DES.SI.DAAMMDD.INDENIZA.PRSTMSTA.TXT");
            /*"    03 FILLER               PIC X(80) VALUE       "43QUIT".*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"43QUIT");
            /*"01 RWS-JCL-EXECUTA REDEFINES    WS-JCL-EXECUTA.*/
        }
        private _REDEF_SI0910B_RWS_JCL_EXECUTA _rws_jcl_executa { get; set; }
        public _REDEF_SI0910B_RWS_JCL_EXECUTA RWS_JCL_EXECUTA
        {
            get { _rws_jcl_executa = new _REDEF_SI0910B_RWS_JCL_EXECUTA(); _.Move(WS_JCL_EXECUTA, _rws_jcl_executa); VarBasis.RedefinePassValue(WS_JCL_EXECUTA, _rws_jcl_executa, WS_JCL_EXECUTA); _rws_jcl_executa.ValueChanged += () => { _.Move(_rws_jcl_executa, WS_JCL_EXECUTA); }; return _rws_jcl_executa; }
            set { VarBasis.RedefinePassValue(value, _rws_jcl_executa, WS_JCL_EXECUTA); }
        }  //Redefines
        public class _REDEF_SI0910B_RWS_JCL_EXECUTA : VarBasis
        {
            /*"    03 WS-JCL-EXEC OCCURS 43.*/
            public ListBasis<SI0910B_WS_JCL_EXEC> WS_JCL_EXEC { get; set; } = new ListBasis<SI0910B_WS_JCL_EXEC>(43);
            public class SI0910B_WS_JCL_EXEC : VarBasis
            {
                /*"       05 WS-JCL-SEQUENCIA  PIC 9(02).*/
                public IntBasis WS_JCL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 WS-JCL-CONTEUDO   PIC X(78).*/
                public StringBasis WS_JCL_CONTEUDO { get; set; } = new StringBasis(new PIC("X", "78", "X(78)."), @"");
                /*"01  LK-PARAMETROS.*/

                public SI0910B_WS_JCL_EXEC()
                {
                    WS_JCL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WS_JCL_CONTEUDO.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_SI0910B_RWS_JCL_EXECUTA()
            {
                WS_JCL_EXEC.ValueChanged += OnValueChanged;
            }

        }
        public SI0910B_LK_PARAMETROS LK_PARAMETROS { get; set; } = new SI0910B_LK_PARAMETROS();
        public class SI0910B_LK_PARAMETROS : VarBasis
        {
            /*"   03 LK-PARM-CONTEUDO.*/
            public SI0910B_LK_PARM_CONTEUDO LK_PARM_CONTEUDO { get; set; } = new SI0910B_LK_PARM_CONTEUDO();
            public class SI0910B_LK_PARM_CONTEUDO : VarBasis
            {
                /*"      05 LK-ID-AMBIENTE     PIC X(01).*/
                public StringBasis LK_ID_AMBIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      05 LK-TP-ERRO         PIC 9(01).*/
                public IntBasis LK_TP_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      05 LK-MSG-RETORNO     PIC X(40).*/
                public StringBasis LK_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            }
        }


        public Dclgens.AD001 AD001 { get; set; } = new Dclgens.AD001();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI0910B_LK_PARAMETROS SI0910B_LK_PARAMETROS_P, string SIJC0910_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETROS*/
        {
            try
            {
                this.LK_PARAMETROS = SI0910B_LK_PARAMETROS_P;
                SIJC0910.SetFile(SIJC0910_FILE_NAME_P);

                /*" -151- PERFORM P1000-PROCEDIMENTOS-INICIAIS THRU P1000-FIM */

                P1000_PROCEDIMENTOS_INICIAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_FIM*/


                /*" -152- PERFORM P2000-PROCEDIMENTOS-PRINCIPAIS THRU P2000-FIM */

                P2000_PROCEDIMENTOS_PRINCIPAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_FIM*/


                /*" -153- PERFORM P9000-PROCEDIMENTOS-FINAIS THRU P9000-FIM */

                P9000_PROCEDIMENTOS_FINAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_FIM*/


                /*" -154- GOBACK */

                throw new GoBack();

                /*" -154- . */

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" P1000-PROCEDIMENTOS-INICIAIS */
        private void P1000_PROCEDIMENTOS_INICIAIS(bool isPerform = false)
        {
            /*" -158- MOVE 'P1000-PROCEDIMENTOS-INICIAIS' TO WS-LOCAL */
            _.Move("P1000-PROCEDIMENTOS-INICIAIS", WS_AREA_TRABALHO.WS_LOCAL);

            /*" -162- INITIALIZE WS-AREA-TRABALHO REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROS */
            _.Initialize(
                WS_AREA_TRABALHO
            );

            /*" -164- PERFORM P1000_PROCEDIMENTOS_INICIAIS_DB_SET_1 */

            P1000_PROCEDIMENTOS_INICIAIS_DB_SET_1();

            /*" -170- STRING WS-TIMESTAMP-INI (9:2) '/' WS-TIMESTAMP-INI (6:2) '/' WS-TIMESTAMP-INI (1:4) DELIMITED BY SIZE INTO WS-DT-PROCESSAMENTO END-STRING */
            #region STRING
            var spl1 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
            spl1 += "/";
            var spl2 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
            spl2 += "/";
            var spl3 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(1, 4).GetMoveValues();
            var results4 = spl1 + spl2 + spl3;
            _.Move(results4, WS_AREA_TRABALHO.WS_DT_PROCESSAMENTO);
            #endregion

            /*" -175- STRING WS-TIMESTAMP-INI (12:2) ':' WS-TIMESTAMP-INI (15:2) ':' WS-TIMESTAMP-INI (18:2) DELIMITED BY SIZE INTO WS-HH-CURRENT END-STRING */
            #region STRING
            var spl4 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(12, 2).GetMoveValues();
            spl4 += ":";
            var spl5 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(15, 2).GetMoveValues();
            spl5 += ":";
            var spl6 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(18, 2).GetMoveValues();
            var results7 = spl4 + spl5 + spl6;
            _.Move(results7, WS_AREA_TRABALHO.WS_HH_CURRENT);
            #endregion

            /*" -176- DISPLAY '*------------------------------------------------*' */
            _.Display($"*------------------------------------------------*");

            /*" -177- DISPLAY '*       -----> INICIO DE PROCESSAMENTO <------   *' */
            _.Display($"*       -----> INICIO DE PROCESSAMENTO <------   *");

            /*" -178- DISPLAY '*------------------------------------------------*' */
            _.Display($"*------------------------------------------------*");

            /*" -179- DISPLAY '* SISTEMA   : SINISTRO                           *' */
            _.Display($"* SISTEMA   : SINISTRO                           *");

            /*" -180- DISPLAY '* PROGRAMA  : SI0910B                           *' */
            _.Display($"* PROGRAMA  : SI0910B                           *");

            /*" -181- DISPLAY '*------------------------------------------------*' */
            _.Display($"*------------------------------------------------*");

            /*" -182- DISPLAY '*                   OBJETIVO                     *' */
            _.Display($"*                   OBJETIVO                     *");

            /*" -183- DISPLAY 'MONTAR E EXECUTAR JCL COM OS PARAMETROS RECEBITOS*' */
            _.Display($"MONTAR E EXECUTAR JCL COM OS PARAMETROS RECEBITOS*");

            /*" -184- DISPLAY '*------------------------------------------------*' */
            _.Display($"*------------------------------------------------*");

            /*" -185- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -187- DISPLAY '* DATA DE PROCESSAMENTO: ' WS-DT-PROCESSAMENTO '              *' . */

            $"* DATA DE PROCESSAMENTO: {WS_AREA_TRABALHO.WS_DT_PROCESSAMENTO}              *"
            .Display();

            /*" -192- DISPLAY '* HORA INICIO PROC.: ' WS-HH-CURRENT '                    *' */

            $"* HORA INICIO PROC.: {WS_AREA_TRABALHO.WS_HH_CURRENT}                    *"
            .Display();

            /*" -198- PERFORM P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1 */

            P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1();

            /*" -200-  EVALUATE SQLCODE  */

            /*" -201-  WHEN ZEROS  */

            /*" -201- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -202- DISPLAY 'ESTOU NO AMBIENTE: ' AD001-DES-AMBIENTE */
                _.Display($"ESTOU NO AMBIENTE: {AD001.DCLAD_AMBIENTE.AD001_DES_AMBIENTE}");

                /*" -203-  WHEN 100  */

                /*" -203- ELSE IF   SQLCODE EQUALS  100 */
            }
            else

            if (DB.SQLCODE == 100)
            {

                /*" -204- MOVE 1 TO LK-TP-ERRO */
                _.Move(1, LK_PARAMETROS.LK_PARM_CONTEUDO.LK_TP_ERRO);

                /*" -205- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_TRABALHO.WS_SQLCODE);

                /*" -209- STRING 'EF0910B-ERRO, AMBIENTE INEXISTENTE - 555' ', SQLCODE - ' WS-SQLCODE DELIMITED BY SIZE INTO LK-MSG-RETORNO END-STRING */
                #region STRING
                var spl7 = "EF0910B-ERRO, AMBIENTE INEXISTENTE - 555" + ", SQLCODE - " + WS_AREA_TRABALHO.WS_SQLCODE.GetMoveValues();
                _.Move(spl7, LK_PARAMETROS.LK_PARM_CONTEUDO.LK_MSG_RETORNO);
                #endregion

                /*" -210- PERFORM P9000-PROCEDIMENTOS-FINAIS THRU P9000-FIM */

                P9000_PROCEDIMENTOS_FINAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_FIM*/


                /*" -211-  WHEN OTHER  */

                /*" -211- ELSE */
            }
            else
            {


                /*" -212- MOVE 1 TO LK-TP-ERRO */
                _.Move(1, LK_PARAMETROS.LK_PARM_CONTEUDO.LK_TP_ERRO);

                /*" -213- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_AREA_TRABALHO.WS_SQLCODE);

                /*" -217- STRING 'EF0910B-ERRO, SQLCODE - ' WS-SQLCODE DELIMITED BY SIZE INTO LK-MSG-RETORNO END-STRING */
                #region STRING
                var spl8 = "EF0910B-ERRO, SQLCODE - " + WS_AREA_TRABALHO.WS_SQLCODE.GetMoveValues();
                _.Move(spl8, LK_PARAMETROS.LK_PARM_CONTEUDO.LK_MSG_RETORNO);
                #endregion

                /*" -218- PERFORM P9000-PROCEDIMENTOS-FINAIS THRU P9000-FIM */

                P9000_PROCEDIMENTOS_FINAIS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_FIM*/


                /*" -219-  END-EVALUATE  */

                /*" -219- END-IF */
            }


            /*" -220- MOVE AD001-DES-AMBIENTE TO WS-ID-AMBIENTE */
            _.Move(AD001.DCLAD_AMBIENTE.AD001_DES_AMBIENTE, WS_CALL.WS_ID_AMBIENTE);

            /*" -220- . */

        }

        [StopWatch]
        /*" P1000-PROCEDIMENTOS-INICIAIS-DB-SET-1 */
        public void P1000_PROCEDIMENTOS_INICIAIS_DB_SET_1()
        {
            /*" -164- EXEC SQL SET :WS-TIMESTAMP-INI = CURRENT_TIMESTAMP END-EXEC */
            _.Move(_.CurrentDate(), WS_AREA_TRABALHO.WS_TIMESTAMP_INI);

        }

        [StopWatch]
        /*" P1000-PROCEDIMENTOS-INICIAIS-DB-SELECT-1 */
        public void P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1()
        {
            /*" -198- EXEC SQL SELECT VALUE(SUBSTR(DES_AMBIENTE,1,3), ' ' ) INTO :AD001-DES-AMBIENTE FROM SEGUROS.AD_AMBIENTE WHERE NUM_AMBIENTE = 555 WITH UR END-EXEC */

            var p1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1 = new P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1.Execute(p1000_PROCEDIMENTOS_INICIAIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AD001_DES_AMBIENTE, AD001.DCLAD_AMBIENTE.AD001_DES_AMBIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_FIM*/

        [StopWatch]
        /*" P2000-PROCEDIMENTOS-PRINCIPAIS */
        private void P2000_PROCEDIMENTOS_PRINCIPAIS(bool isPerform = false)
        {
            /*" -228- MOVE 'P2000-PROCEDIMENTOS-PRINCIPAIS' TO WS-LOCAL */
            _.Move("P2000-PROCEDIMENTOS-PRINCIPAIS", WS_AREA_TRABALHO.WS_LOCAL);

            /*" -229- DISPLAY 'EF0910B-VALIDAR AMBIENTE=' WS-ID-AMBIENTE */
            _.Display($"EF0910B-VALIDAR AMBIENTE={WS_CALL.WS_ID_AMBIENTE}");

            /*" -230- EVALUATE WS-ID-AMBIENTE */
            switch (WS_CALL.WS_ID_AMBIENTE.Value.Trim())
            {

                /*" -231- WHEN 'PRD' */
                case "PRD":

                    /*" -232- DISPLAY 'SI0910B-CHAMAR MONTAGEM JCL PRD.' */
                    _.Display($"SI0910B-CHAMAR MONTAGEM JCL PRD.");

                    /*" -233- PERFORM P2100-EXEC-JCL-PRODUCAO THRU P2100-FIM */

                    P2100_EXEC_JCL_PRODUCAO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P2100_FIM*/


                    /*" -234- WHEN 'HMP' */
                    break;
                case "HMP":

                    /*" -235- DISPLAY 'SI0910B-CHAMAR MONTAGEM JCL HMP.' */
                    _.Display($"SI0910B-CHAMAR MONTAGEM JCL HMP.");

                    /*" -236- PERFORM P2200-EXEC-JCL-HOMOLOGA THRU P2200-FIM */

                    P2200_EXEC_JCL_HOMOLOGA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P2200_FIM*/


                    /*" -237- WHEN 'DES' */
                    break;
                case "DES":

                    /*" -238- DISPLAY 'SI0910B-CHAMAR MONTAGEM JCL DESENVOLVIMENTO' */
                    _.Display($"SI0910B-CHAMAR MONTAGEM JCL DESENVOLVIMENTO");

                    /*" -239- PERFORM P2300-EXEC-JCL-DESENVOL THRU P2300-FIM */

                    P2300_EXEC_JCL_DESENVOL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P2300_FIM*/


                    /*" -241- END-EVALUATE */
                    break;
            }


            /*" -242- DISPLAY 'ARQ GERADO=' WS-JCL-CONTEUDO(11)(16:30) */
            _.Display($"ARQ GERADO={RWS_JCL_EXECUTA.WS_JCL_EXEC[11]}");

            /*" -243- DISPLAY '*-----------------------------------------------*' */
            _.Display($"*-----------------------------------------------*");

            /*" -243- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_FIM*/

        [StopWatch]
        /*" P2100-EXEC-JCL-PRODUCAO */
        private void P2100_EXEC_JCL_PRODUCAO(bool isPerform = false)
        {
            /*" -252- MOVE 'P2100-EXEC-JCL- RODUCAO' TO WS-LOCAL. */
            _.Move("P2100-EXEC-JCL- RODUCAO", WS_AREA_TRABALHO.WS_LOCAL);

            /*" -254- OPEN OUTPUT SIJC0910 */
            SIJC0910.Open(REG_JC0910);

            /*" -256- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 43 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 43); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -257- EVALUATE WS-JCL-SEQUENCIA(WS-IND) */
                switch (RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_SEQUENCIA.Value)
                {

                    /*" -258- WHEN 01 */
                    case 01:

                        /*" -262- STRING 'JPSI' DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(3:4) END-STRING */
                        #region STRING
                        var spl9 = "JPSI";
                        _.Move(spl9, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(3, 4));
                        #endregion

                        /*" -263- WHEN 05 */
                        break;
                    case 05:

                        /*" -264- MOVE 'PRD' TO WS-JCL-CONTEUDO(WS-IND)(28:3) */
                        _.Move("PRD", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(28, 3));

                        /*" -265- WHEN 11 */
                        break;
                    case 11:

                        /*" -266- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -267- MOVE 'PRD' TO WS-AUX-JCL(16:3) */
                        _.MoveAtPosition("PRD", WS_AREA_TRABALHO.WS_AUX_JCL, 16, 3);

                        /*" -275- STRING WS-AUX-JCL(1:23) WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(30:20) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl10 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 23).GetMoveValues();
                        var spl11 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl12 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl13 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl14 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(30, 20).GetMoveValues();
                        var results15 = spl10 + spl11 + spl12 + spl13 + spl14;
                        _.Move(results15, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -276- WHEN 17 */
                        break;
                    case 17:

                        /*" -277- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -278- MOVE 'PRD' TO WS-AUX-JCL(19:3) */
                        _.MoveAtPosition("PRD", WS_AREA_TRABALHO.WS_AUX_JCL, 19, 3);

                        /*" -286- STRING WS-AUX-JCL(1:26) WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(33:20) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl15 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 26).GetMoveValues();
                        var spl16 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl17 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl18 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl19 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(33, 20).GetMoveValues();
                        var results20 = spl15 + spl16 + spl17 + spl18 + spl19;
                        _.Move(results20, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -287- WHEN 18 */
                        break;
                    case 18:

                        /*" -288- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -294- STRING WS-AUX-JCL(1:19) 'PRO' WS-AUX-JCL(22:25) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl20 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 19).GetMoveValues();
                        spl20 += "PRO";
                        var spl21 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(22, 25).GetMoveValues();
                        var results22 = spl20 + spl21;
                        _.Move(results22, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -295- WHEN 24 */
                        break;
                    case 24:

                        /*" -296- MOVE 'P' TO WS-JCL-CONTEUDO(WS-IND)(22:1) */
                        _.Move("P", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(22, 1));

                        /*" -297- WHEN 26 */
                        break;
                    case 26:

                        /*" -298- MOVE 'PRD' TO WS-JCL-CONTEUDO(WS-IND)(13:3) */
                        _.Move("PRD", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(13, 3));

                        /*" -299- WHEN 32 */
                        break;
                    case 32:

                        /*" -300- MOVE 'PRD1' TO WS-JCL-CONTEUDO(WS-IND)(19:4) */
                        _.Move("PRD1", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(19, 4));

                        /*" -301- WHEN 33 */
                        break;
                    case 33:

                        /*" -302- MOVE 'PRD1' TO WS-JCL-CONTEUDO(WS-IND)(19:4) */
                        _.Move("PRD1", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(19, 4));

                        /*" -303- WHEN 39 */
                        break;
                    case 39:

                        /*" -304- MOVE 'PRD' TO WS-JCL-CONTEUDO(WS-IND)(6:3) */
                        _.Move("PRD", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(6, 3));

                        /*" -310- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(14:6) END-STRING */
                        #region STRING
                        var spl22 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl23 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl24 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results25 = spl22 + spl23 + spl24;
                        _.Move(results25, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(14, 6));
                        #endregion

                        /*" -311- WHEN 41 */
                        break;
                    case 41:

                        /*" -312- MOVE 'PRD' TO WS-JCL-CONTEUDO(WS-IND)(6:3) */
                        _.Move("PRD", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(6, 3));

                        /*" -318- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(14:6) END-STRING */
                        #region STRING
                        var spl25 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl26 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl27 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results28 = spl25 + spl26 + spl27;
                        _.Move(results28, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(14, 6));
                        #endregion

                        /*" -319- WHEN 40 */
                        break;
                    case 40:

                        /*" -320- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -321- MOVE SPACES TO WS-JCL-CONTEUDO(WS-IND) */
                        _.Move("", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);

                        /*" -330- STRING WS-AUX-JCL(1:1) 'GERES\PRD.SI.D' WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(32:25) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl28 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 1).GetMoveValues();
                        spl28 += "GERES/PRD.SI.D";
                        var spl29 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl30 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl31 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl32 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(32, 25).GetMoveValues();
                        var results33 = spl28 + spl29 + spl30 + spl31 + spl32;
                        _.Move(results33, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -331- WHEN 42 */
                        break;
                    case 42:

                        /*" -332- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -333- MOVE SPACES TO WS-JCL-CONTEUDO(WS-IND) */
                        _.Move("", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);

                        /*" -342- STRING WS-AUX-JCL(1:1) 'GESEF\RELATORIO_DIARIO\PRD.SI.D' WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(29:25) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl33 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 1).GetMoveValues();
                        spl33 += "GESEF/RELATORIO_DIARIO/PRD.SI.D";
                        var spl34 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl35 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl36 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl37 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(29, 25).GetMoveValues();
                        var results38 = spl33 + spl34 + spl35 + spl36 + spl37;
                        _.Move(results38, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -343- END-EVALUATE */
                        break;
                }


                /*" -345- WRITE REG-JC0910 FROM WS-JCL-CONTEUDO(WS-IND) END-WRITE */
                _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.GetMoveValues(), REG_JC0910);

                SIJC0910.Write(REG_JC0910.GetMoveValues().ToString());

                /*" -346- END-PERFORM */
            }

            /*" -347- DISPLAY 'FINAL DA MONTAGEM JCL PRODUCAO' */
            _.Display($"FINAL DA MONTAGEM JCL PRODUCAO");

            /*" -348- CLOSE SIJC0910 */
            SIJC0910.Close();

            /*" -348- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2100_FIM*/

        [StopWatch]
        /*" P2200-EXEC-JCL-HOMOLOGA */
        private void P2200_EXEC_JCL_HOMOLOGA(bool isPerform = false)
        {
            /*" -356- MOVE 'P2200-EXEC-JCL-HOMOLOGA' TO WS-LOCAL */
            _.Move("P2200-EXEC-JCL-HOMOLOGA", WS_AREA_TRABALHO.WS_LOCAL);

            /*" -357- OPEN OUTPUT SIJC0910 */
            SIJC0910.Open(REG_JC0910);

            /*" -359- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 43 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 43); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -360- EVALUATE WS-JCL-SEQUENCIA(WS-IND) */
                switch (RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_SEQUENCIA.Value)
                {

                    /*" -361- WHEN 01 */
                    case 01:

                        /*" -365- STRING 'JHSI' DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(3:4) END-STRING */
                        #region STRING
                        var spl38 = "JHSI";
                        _.Move(spl38, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(3, 4));
                        #endregion

                        /*" -366- WHEN 05 */
                        break;
                    case 05:

                        /*" -367- MOVE 'HMP' TO WS-JCL-CONTEUDO(WS-IND)(28:3) */
                        _.Move("HMP", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(28, 3));

                        /*" -368- WHEN 11 */
                        break;
                    case 11:

                        /*" -369- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -370- MOVE 'HMP' TO WS-AUX-JCL(16:3) */
                        _.MoveAtPosition("HMP", WS_AREA_TRABALHO.WS_AUX_JCL, 16, 3);

                        /*" -378- STRING WS-AUX-JCL(1:23) WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(30:20) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl39 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 23).GetMoveValues();
                        var spl40 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl41 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl42 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl43 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(30, 20).GetMoveValues();
                        var results44 = spl39 + spl40 + spl41 + spl42 + spl43;
                        _.Move(results44, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -379- WHEN 17 */
                        break;
                    case 17:

                        /*" -380- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -381- MOVE 'HMP' TO WS-AUX-JCL(19:3) */
                        _.MoveAtPosition("HMP", WS_AREA_TRABALHO.WS_AUX_JCL, 19, 3);

                        /*" -389- STRING WS-AUX-JCL(1:26) WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(33:20) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl44 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 26).GetMoveValues();
                        var spl45 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl46 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl47 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl48 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(33, 20).GetMoveValues();
                        var results49 = spl44 + spl45 + spl46 + spl47 + spl48;
                        _.Move(results49, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -390- WHEN 24 */
                        break;
                    case 24:

                        /*" -391- MOVE 'H' TO WS-JCL-CONTEUDO(WS-IND)(22:1) */
                        _.Move("H", RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(22, 1));

                        /*" -392- WHEN 39 */
                        break;
                    case 39:

                        /*" -398- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(14:6) END-STRING */
                        #region STRING
                        var spl49 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl50 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl51 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results52 = spl49 + spl50 + spl51;
                        _.Move(results52, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(14, 6));
                        #endregion

                        /*" -399- WHEN 40 */
                        break;
                    case 40:

                        /*" -405- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(28:6) END-STRING */
                        #region STRING
                        var spl52 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl53 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl54 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results55 = spl52 + spl53 + spl54;
                        _.Move(results55, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(28, 6));
                        #endregion

                        /*" -406- END-EVALUATE */
                        break;
                }


                /*" -408- WRITE REG-JC0910 FROM WS-JCL-CONTEUDO(WS-IND) END-WRITE */
                _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.GetMoveValues(), REG_JC0910);

                SIJC0910.Write(REG_JC0910.GetMoveValues().ToString());

                /*" -409- END-PERFORM */
            }

            /*" -410- CLOSE SIJC0910 */
            SIJC0910.Close();

            /*" -410- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2200_FIM*/

        [StopWatch]
        /*" P2300-EXEC-JCL-DESENVOL */
        private void P2300_EXEC_JCL_DESENVOL(bool isPerform = false)
        {
            /*" -419- MOVE 'P2300-EXEC-JCL-DESENVOL' TO WS-LOCAL. */
            _.Move("P2300-EXEC-JCL-DESENVOL", WS_AREA_TRABALHO.WS_LOCAL);

            /*" -420- OPEN OUTPUT SIJC0910 */
            SIJC0910.Open(REG_JC0910);

            /*" -422- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 43 */

            for (WS_AREA_TRABALHO.WS_IND.Value = 1; !(WS_AREA_TRABALHO.WS_IND > 43); WS_AREA_TRABALHO.WS_IND.Value += 1)
            {

                /*" -423- EVALUATE WS-JCL-SEQUENCIA(WS-IND) */
                switch (RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_SEQUENCIA.Value)
                {

                    /*" -424- WHEN 11 */
                    case 11:

                        /*" -425- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -433- STRING WS-AUX-JCL(1:23) WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(30:20) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl55 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 23).GetMoveValues();
                        var spl56 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl57 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl58 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl59 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(30, 20).GetMoveValues();
                        var results60 = spl55 + spl56 + spl57 + spl58 + spl59;
                        _.Move(results60, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -434- WHEN 17 */
                        break;
                    case 17:

                        /*" -435- MOVE WS-JCL-CONTEUDO(WS-IND) TO WS-AUX-JCL */
                        _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO, WS_AREA_TRABALHO.WS_AUX_JCL);

                        /*" -443- STRING WS-AUX-JCL(1:26) WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) WS-AUX-JCL(33:20) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND) END-STRING */
                        #region STRING
                        var spl60 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(1, 26).GetMoveValues();
                        var spl61 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl62 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl63 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var spl64 = WS_AREA_TRABALHO.WS_AUX_JCL.Substring(33, 20).GetMoveValues();
                        var results65 = spl60 + spl61 + spl62 + spl63 + spl64;
                        _.Move(results65, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO);
                        #endregion

                        /*" -444- WHEN 39 */
                        break;
                    case 39:

                        /*" -450- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(14:6) END-STRING */
                        #region STRING
                        var spl65 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl66 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl67 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results68 = spl65 + spl66 + spl67;
                        _.Move(results68, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(14, 6));
                        #endregion

                        /*" -451- WHEN 41 */
                        break;
                    case 41:

                        /*" -457- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(14:6) END-STRING */
                        #region STRING
                        var spl68 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl69 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl70 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results71 = spl68 + spl69 + spl70;
                        _.Move(results71, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(14, 6));
                        #endregion

                        /*" -458- WHEN 40 */
                        break;
                    case 40:

                        /*" -464- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(28:6) END-STRING */
                        #region STRING
                        var spl71 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl72 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl73 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results74 = spl71 + spl72 + spl73;
                        _.Move(results74, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(28, 6));
                        #endregion

                        /*" -465- WHEN 42 */
                        break;
                    case 42:

                        /*" -471- STRING WS-TIMESTAMP-INI(3:2) WS-TIMESTAMP-INI(6:2) WS-TIMESTAMP-INI(9:2) DELIMITED BY SIZE INTO WS-JCL-CONTEUDO(WS-IND)(23:6) END-STRING */
                        #region STRING
                        var spl74 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(3, 2).GetMoveValues();
                        var spl75 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(6, 2).GetMoveValues();
                        var spl76 = WS_AREA_TRABALHO.WS_TIMESTAMP_INI.Substring(9, 2).GetMoveValues();
                        var results77 = spl74 + spl75 + spl76;
                        _.Move(results77, RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.Substring(23, 6));
                        #endregion

                        /*" -472- END-EVALUATE */
                        break;
                }


                /*" -474- WRITE REG-JC0910 FROM WS-JCL-CONTEUDO(WS-IND) END-WRITE */
                _.Move(RWS_JCL_EXECUTA.WS_JCL_EXEC[WS_AREA_TRABALHO.WS_IND].WS_JCL_CONTEUDO.GetMoveValues(), REG_JC0910);

                SIJC0910.Write(REG_JC0910.GetMoveValues().ToString());

                /*" -475- END-PERFORM */
            }

            /*" -476- CLOSE SIJC0910 */
            SIJC0910.Close();

            /*" -476- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2300_FIM*/

        [StopWatch]
        /*" P9000-PROCEDIMENTOS-FINAIS */
        private void P9000_PROCEDIMENTOS_FINAIS(bool isPerform = false)
        {
            /*" -483- DISPLAY '              PROCEDIMENTOS FINAIS                 ' */
            _.Display($"              PROCEDIMENTOS FINAIS                 ");

            /*" -484- DISPLAY '===================================================' */
            _.Display($"===================================================");

            /*" -485- DISPLAY '---------> PROGRAMA TERMINOU NORMALMENTE <---------' */
            _.Display($"---------> PROGRAMA TERMINOU NORMALMENTE <---------");

            /*" -485- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_FIM*/
    }
}