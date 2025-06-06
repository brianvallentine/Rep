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
using Sias.VidaAzul.DB2.VA0415B;

namespace Code
{
    public class VA0415B
    {
        public bool IsCall { get; set; }

        public VA0415B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA NA V0HISTREPSAF O MOVIMENTO   *      */
        /*"      *                             DE TRANSFERENCIA DE SUBGRUPO.      *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  LUIZ CARLOS.                       *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0415B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  22/10/1999.                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 01 - MESSIAS - 07/08/2000                           *      */
        /*"      *  RETIRADO O ARGUMENTO NRCERTIF NA ATUALIZACAO DA V0SAFCOBER    *      */
        /*"      *  R080, POIS, ESTAVA ABENDANDO QUANDO ENCONTRAVA 2 LINHAS.      *      */
        /*"      *                                       PROCURE POR MM0800       *      */
        /*"      ******************************************************************      */
        /*"      *  ALTERACAO 02 - MESSIAS - 09/08/2000                           *      */
        /*"      *  ESTAVA DESCENDO MATRICULAS NULAS NO FETCH E ABENDANDO PROGRAMA*      */
        /*"      *  SERA DADO DISPLAY DESTES CASOS E O REGISTRO SERA DESPREZADO.  *      */
        /*"      *                                       PROCURE POR MM0800       *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-MATRIC                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_MATRIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1SIST-DTMOVABE                  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0COBV-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBV_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0COBV-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBV_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V0COBV-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBV_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-APOLICE                   PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0PROP-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0PROP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PROP-NUM-MATRICULA             PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0HSEG-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HSEG_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0HSEG-DTREFER                   PIC  X(10).*/
        public StringBasis V0HSEG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SEGV-NUMITEM                   PIC S9(09)    COMP.*/
        public IntBasis V0SEGV_NUMITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SEGV-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0SEGV_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0SEGV-SITUACAO                  PIC  X(01).*/
        public StringBasis V0SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01     AC-L-SEGURAVG                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_SEGURAVG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-HISTSEGVG                PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_HISTSEGVG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-PROPOVA                  PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_PROPOVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-FUNCIOCEF                PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_FUNCIOCEF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-COBERPROPVA              PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_COBERPROPVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-L-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_L_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-CONTA                      PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-I-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_I_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-C-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_C_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-R-SAFCOBER                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_R_SAFCOBER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-A-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_A_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-C-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_C_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-S-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_S_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-I-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_I_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-R-HISTREPSAF               PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_R_HISTREPSAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-T-SUBGRUPO                 PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_T_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     AC-SEM-SAF                    PIC 9(06) VALUE ZEROS.*/
        public IntBasis AC_SEM_SAF { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"01     WFIM-CPROPOVA                 PIC X(01) VALUE SPACES.*/
        public StringBasis WFIM_CPROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01     WDATA-WORK.*/
        public VA0415B_WDATA_WORK WDATA_WORK { get; set; } = new VA0415B_WDATA_WORK();
        public class VA0415B_WDATA_WORK : VarBasis
        {
            /*"    05 ANO-WORK                   PIC 9(04).*/
            public IntBasis ANO_WORK { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 MES-WORK                   PIC 9(02).*/
            public IntBasis MES_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 DIA-WORK                   PIC 9(02).*/
            public IntBasis DIA_WORK { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WDATA-INIVIG.*/
        }
        public VA0415B_WDATA_INIVIG WDATA_INIVIG { get; set; } = new VA0415B_WDATA_INIVIG();
        public class VA0415B_WDATA_INIVIG : VarBasis
        {
            /*"    05 ANO-WORK-INIVIG            PIC 9(04).*/
            public IntBasis ANO_WORK_INIVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 MES-WORK-INIVIG            PIC 9(02).*/
            public IntBasis MES_WORK_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 DIA-WORK-INIVIG            PIC 9(02).*/
            public IntBasis DIA_WORK_INIVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01     WMES-VIG                      PIC 9(06).*/
        }
        public IntBasis WMES_VIG { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
        /*"01     WMES-VIG-R REDEFINES WMES-VIG.*/
        private _REDEF_VA0415B_WMES_VIG_R _wmes_vig_r { get; set; }
        public _REDEF_VA0415B_WMES_VIG_R WMES_VIG_R
        {
            get { _wmes_vig_r = new _REDEF_VA0415B_WMES_VIG_R(); _.Move(WMES_VIG, _wmes_vig_r); VarBasis.RedefinePassValue(WMES_VIG, _wmes_vig_r, WMES_VIG); _wmes_vig_r.ValueChanged += () => { _.Move(_wmes_vig_r, WMES_VIG); }; return _wmes_vig_r; }
            set { VarBasis.RedefinePassValue(value, _wmes_vig_r, WMES_VIG); }
        }  //Redefines
        public class _REDEF_VA0415B_WMES_VIG_R : VarBasis
        {
            /*"    05 MES-VIG                    PIC 9(02).*/
            public IntBasis MES_VIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 ANO-VIG                    PIC 9(04).*/
            public IntBasis ANO_VIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01     WS-TIME                       PIC X(08).*/

            public _REDEF_VA0415B_WMES_VIG_R()
            {
                MES_VIG.ValueChanged += OnValueChanged;
                ANO_VIG.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"01     WS-DATA-SQL.*/
        public VA0415B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA0415B_WS_DATA_SQL();
        public class VA0415B_WS_DATA_SQL : VarBasis
        {
            /*"    05 WS-ANO-SQL                 PIC 9(04).*/
            public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 WS-MES-SQL                 PIC 9(02).*/
            public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 FILLER                     PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    05 WS-DIA-SQL                 PIC 9(02).*/
            public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WABEND*/
        }
        public VA0415B_WABEND WABEND { get; set; } = new VA0415B_WABEND();
        public class VA0415B_WABEND : VarBasis
        {
            /*"    05     FILLER.*/
            public VA0415B_FILLER_6 FILLER_6 { get; set; } = new VA0415B_FILLER_6();
            public class VA0415B_FILLER_6 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(016) VALUE            '*** VA0415B *** '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"*** VA0415B *** ");
                /*"      10    FILLER                   PIC  X(013) VALUE            'ERRO SQL *** '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"ERRO SQL *** ");
                /*"      10    FILLER                   PIC  X(010) VALUE            'SQLCODE = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD1 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(011)   VALUE            'SQLERRD2 = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0415B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0415B_LOCALIZA_ABEND_1();
            public class VA0415B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0415B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0415B_LOCALIZA_ABEND_2();
            public class VA0415B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA0415B_CPROPOVA CPROPOVA { get; set; } = new VA0415B_CPROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -180- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -182- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -184- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -188- MOVE 'R000-VA0415B  ' TO PARAGRAFO. */
                _.Move("R000-VA0415B  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

                /*" -190- PERFORM R001-SELECT-SISTEMA. */

                R001_SELECT_SISTEMA_SECTION();

                /*" -192- PERFORM R010-DECLARE-PROPOVA. */

                R010_DECLARE_PROPOVA_SECTION();

                /*" -194- PERFORM R020-FETCH-PROPOVA. */

                R020_FETCH_PROPOVA_SECTION();

                /*" -195- IF WFIM-CPROPOVA EQUAL ' ' */

                if (WFIM_CPROPOVA == " ")
                {

                    /*" -197- DISPLAY '** VA0415B ** PROCESSANDO ...' . */
                    _.Display($"** VA0415B ** PROCESSANDO ...");
                }


                /*" -200- PERFORM R030-PROCESSAMENTO THRU R030-EXIT UNTIL WFIM-CPROPOVA EQUAL 'S' . */

                while (!(WFIM_CPROPOVA == "S"))
                {

                    R030_PROCESSAMENTO_SECTION();

                    R030_NEXT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -201- MOVE 'COMMIT WORK' TO COMANDO. */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -201- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -204- DISPLAY '** VA0415B ** LIDOS PROPOVA     ' AC-L-PROPOVA */
                _.Display($"** VA0415B ** LIDOS PROPOVA     {AC_L_PROPOVA}");

                /*" -205- DISPLAY '** VA0415B ** LIDOS COBERPROP   ' AC-L-COBERPROPVA */
                _.Display($"** VA0415B ** LIDOS COBERPROP   {AC_L_COBERPROPVA}");

                /*" -206- DISPLAY '** VA0415B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
                _.Display($"** VA0415B ** LIDOS SEGURAVG    {AC_L_SEGURAVG}");

                /*" -207- DISPLAY '** VA0415B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
                _.Display($"** VA0415B ** LIDOS HISTSEGVG   {AC_L_HISTSEGVG}");

                /*" -208- DISPLAY '                                ' . */
                _.Display($"                                ");

                /*" -209- DISPLAY '** VA0415B ** INCL. HISTREPSAF  ' AC-I-HISTREPSAF */
                _.Display($"** VA0415B ** INCL. HISTREPSAF  {AC_I_HISTREPSAF}");

                /*" -210- DISPLAY '** VA0415B ** INCL. SAFCOBER    ' AC-I-SAFCOBER */
                _.Display($"** VA0415B ** INCL. SAFCOBER    {AC_I_SAFCOBER}");

                /*" -211- DISPLAY '                                ' . */
                _.Display($"                                ");

                /*" -213- DISPLAY '** VA0415B ** TERMINO NORMAL    ' . */
                _.Display($"** VA0415B ** TERMINO NORMAL    ");

                /*" -215- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -215- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R001-SELECT-SISTEMA-SECTION */
        private void R001_SELECT_SISTEMA_SECTION()
        {
            /*" -223- MOVE 'R001-SELECT-SISTEMA ' TO PARAGRAFO. */
            _.Move("R001-SELECT-SISTEMA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -228- PERFORM R001_SELECT_SISTEMA_DB_SELECT_1 */

            R001_SELECT_SISTEMA_DB_SELECT_1();

            /*" -231- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -232- DISPLAY 'R001 - PROBLEMAS SELECT V0SISTEMA ....' */
                _.Display($"R001 - PROBLEMAS SELECT V0SISTEMA ....");

                /*" -233- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -236- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -236- DISPLAY 'DATA DO PROCESSAMENTO....  ' V1SIST-DTMOVABE. */
            _.Display($"DATA DO PROCESSAMENTO....  {V1SIST_DTMOVABE}");

        }

        [StopWatch]
        /*" R001-SELECT-SISTEMA-DB-SELECT-1 */
        public void R001_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -228- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r001_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R001_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R001_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r001_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R001_EXIT*/

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-SECTION */
        private void R010_DECLARE_PROPOVA_SECTION()
        {
            /*" -248- MOVE 'R010-DECLARE-PROPOVA' TO PARAGRAFO. */
            _.Move("R010-DECLARE-PROPOVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -271- PERFORM R010_DECLARE_PROPOVA_DB_DECLARE_1 */

            R010_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -273- PERFORM R010_DECLARE_PROPOVA_DB_OPEN_1 */

            R010_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -276- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -277- DISPLAY 'R010 - PROBLEMAS DECLARE CPROPOVA ....' */
                _.Display($"R010 - PROBLEMAS DECLARE CPROPOVA ....");

                /*" -278- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -278- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R010_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -271- EXEC SQL DECLARE CPROPOVA CURSOR FOR SELECT B.CODCLIEN, B.NUM_APOLICE, B.CODSUBES, B.NRCERTIF, A.COD_OPERACAO, B.SITUACAO, B.OCORHIST, B.NUM_MATRICULA FROM SEGUROS.V0MOVIMENTO A, SEGUROS.V0PROPOSTAVA B WHERE A.NUM_APOLICE = 93010000890 AND A.COD_OPERACAO >= 200 AND A.COD_OPERACAO <= 399 AND A.DATA_OPERACAO = :V1SIST-DTMOVABE AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.COD_SUBGRUPO AND B.CODCLIEN = A.COD_CLIENTE AND B.NRCERTIF = A.NUM_CERTIFICADO ORDER BY B.CODCLIEN, B.NRCERTIF END-EXEC. */
            CPROPOVA = new VA0415B_CPROPOVA(true);
            string GetQuery_CPROPOVA()
            {
                var query = @$"SELECT B.CODCLIEN
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.NRCERTIF
							, 
							A.COD_OPERACAO
							, 
							B.SITUACAO
							, 
							B.OCORHIST
							, 
							B.NUM_MATRICULA 
							FROM SEGUROS.V0MOVIMENTO A
							, 
							SEGUROS.V0PROPOSTAVA B 
							WHERE A.NUM_APOLICE = 93010000890 
							AND A.COD_OPERACAO >= 200 
							AND A.COD_OPERACAO <= 399 
							AND A.DATA_OPERACAO = '{V1SIST_DTMOVABE}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.COD_SUBGRUPO 
							AND B.CODCLIEN = A.COD_CLIENTE 
							AND B.NRCERTIF = A.NUM_CERTIFICADO 
							ORDER BY B.CODCLIEN
							, B.NRCERTIF";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R010-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R010_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -273- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-FETCH-PROPOVA-SECTION */
        private void R020_FETCH_PROPOVA_SECTION()
        {
            /*" -291- MOVE 'R020-FETCH-PROPOVA ' TO PARAGRAFO. */
            _.Move("R020-FETCH-PROPOVA ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -300- PERFORM R020_FETCH_PROPOVA_DB_FETCH_1 */

            R020_FETCH_PROPOVA_DB_FETCH_1();

            /*" -303- IF VIND-MATRIC LESS ZEROES */

            if (VIND_MATRIC < 00)
            {

                /*" -305- DISPLAY 'MATRICULA ESTA NULA, REGISTRO DESPREZADO ' V0PROP-NRCERTIF ' ' V0PROP-CODCLIEN */

                $"MATRICULA ESTA NULA, REGISTRO DESPREZADO {V0PROP_NRCERTIF} {V0PROP_CODCLIEN}"
                .Display();

                /*" -307- GO TO R020-FETCH-PROPOVA. */
                new Task(() => R020_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -308- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -309- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -310- MOVE 'S' TO WFIM-CPROPOVA */
                    _.Move("S", WFIM_CPROPOVA);

                    /*" -310- PERFORM R020_FETCH_PROPOVA_DB_CLOSE_1 */

                    R020_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -312- ELSE */
                }
                else
                {


                    /*" -313- DISPLAY 'R020 - (PROBLEMAS NO FETCH CPROPOVA ....' */
                    _.Display($"R020 - (PROBLEMAS NO FETCH CPROPOVA ....");

                    /*" -314- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -314- PERFORM R020_FETCH_PROPOVA_DB_CLOSE_2 */

                    R020_FETCH_PROPOVA_DB_CLOSE_2();

                    /*" -316- GO TO 9999-ERRO */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -317- ELSE */
                }

            }
            else
            {


                /*" -319- ADD 1 TO AC-L-PROPOVA AC-CONTA. */
                AC_L_PROPOVA.Value = AC_L_PROPOVA + 1;
                AC_CONTA.Value = AC_CONTA + 1;
            }


            /*" -320- IF AC-CONTA > 999 */

            if (AC_CONTA > 999)
            {

                /*" -321- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -322- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -322- DISPLAY 'LIDOS ' AC-L-PROPOVA ' ' WS-TIME. */

                $"LIDOS {AC_L_PROPOVA} {WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-FETCH-1 */
        public void R020_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -300- EXEC SQL FETCH CPROPOVA INTO :V0PROP-CODCLIEN, :V0PROP-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-CODOPER, :V0PROP-SITUACAO, :V0PROP-OCORHIST, :V0PROP-NUM-MATRICULA:VIND-MATRIC END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPOVA.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(CPROPOVA.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPOVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPOVA.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPOVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPOVA.V0PROP_OCORHIST, V0PROP_OCORHIST);
                _.Move(CPROPOVA.V0PROP_NUM_MATRICULA, V0PROP_NUM_MATRICULA);
                _.Move(CPROPOVA.VIND_MATRIC, VIND_MATRIC);
            }

        }

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R020_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -310- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R020-FETCH-PROPOVA-DB-CLOSE-2 */
        public void R020_FETCH_PROPOVA_DB_CLOSE_2()
        {
            /*" -314- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }

        [StopWatch]
        /*" R030-PROCESSAMENTO-SECTION */
        private void R030_PROCESSAMENTO_SECTION()
        {
            /*" -334- PERFORM R040-SELECT-COBERPROPVA. */

            R040_SELECT_COBERPROPVA_SECTION();

            /*" -335- IF V0COBV-VLCUSTAUXF-I NOT = 0 */

            if (V0COBV_VLCUSTAUXF_I != 0)
            {

                /*" -336- ADD 1 TO AC-SEM-SAF */
                AC_SEM_SAF.Value = AC_SEM_SAF + 1;

                /*" -337- GO TO R030-NEXT */

                R030_NEXT(); //GOTO
                return;

                /*" -338- ELSE */
            }
            else
            {


                /*" -339- IF V0COBV-VLCUSTAUXF = 0 */

                if (V0COBV_VLCUSTAUXF == 0)
                {

                    /*" -340- ADD 1 TO AC-SEM-SAF */
                    AC_SEM_SAF.Value = AC_SEM_SAF + 1;

                    /*" -342- GO TO R030-NEXT. */

                    R030_NEXT(); //GOTO
                    return;
                }

            }


            /*" -344- PERFORM R050-SELECT-SEGURAVG. */

            R050_SELECT_SEGURAVG_SECTION();

            /*" -346- PERFORM R060-SELECT-HISTSEGVG. */

            R060_SELECT_HISTSEGVG_SECTION();

            /*" -348- IF V0PROP-CODOPER > 199 AND V0PROP-CODOPER < 300 */

            if (V0PROP_CODOPER > 199 && V0PROP_CODOPER < 300)
            {

                /*" -349- PERFORM R070-TRATA-TRANS-CREDITO */

                R070_TRATA_TRANS_CREDITO_SECTION();

                /*" -350- ELSE */
            }
            else
            {


                /*" -350- PERFORM R080-TRATA-TRANS-DEBITO. */

                R080_TRATA_TRANS_DEBITO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R030_NEXT */

            R030_NEXT();

        }

        [StopWatch]
        /*" R030-NEXT */
        private void R030_NEXT(bool isPerform = false)
        {
            /*" -356- PERFORM R020-FETCH-PROPOVA. */

            R020_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R040-SELECT-COBERPROPVA-SECTION */
        private void R040_SELECT_COBERPROPVA_SECTION()
        {
            /*" -368- MOVE 'SELECT R040-COBERPROPVA' TO PARAGRAFO. */
            _.Move("SELECT R040-COBERPROPVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -378- PERFORM R040_SELECT_COBERPROPVA_DB_SELECT_1 */

            R040_SELECT_COBERPROPVA_DB_SELECT_1();

            /*" -381- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -382- DISPLAY 'R040 - PROBLEMAS SELECT V0COBERPROPVA.' */
                _.Display($"R040 - PROBLEMAS SELECT V0COBERPROPVA.");

                /*" -383- DISPLAY ' CERT ' V0PROP-NRCERTIF */
                _.Display($" CERT {V0PROP_NRCERTIF}");

                /*" -384- DISPLAY ' OCOH ' V0PROP-OCORHIST */
                _.Display($" OCOH {V0PROP_OCORHIST}");

                /*" -386- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -386- ADD 1 TO AC-L-COBERPROPVA. */
            AC_L_COBERPROPVA.Value = AC_L_COBERPROPVA + 1;

        }

        [StopWatch]
        /*" R040-SELECT-COBERPROPVA-DB-SELECT-1 */
        public void R040_SELECT_COBERPROPVA_DB_SELECT_1()
        {
            /*" -378- EXEC SQL SELECT PRMVG + 3.74, IMPSEGAUXF, VLCUSTAUXF INTO :V0COBV-VLPREMIO, :V0COBV-IMPSEGAUXF:V0COBV-IMPSEGAUXF-I, :V0COBV-VLCUSTAUXF:V0COBV-VLCUSTAUXF-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1 = new R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R040_SELECT_COBERPROPVA_DB_SELECT_1_Query1.Execute(r040_SELECT_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBV_VLPREMIO, V0COBV_VLPREMIO);
                _.Move(executed_1.V0COBV_IMPSEGAUXF, V0COBV_IMPSEGAUXF);
                _.Move(executed_1.V0COBV_IMPSEGAUXF_I, V0COBV_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBV_VLCUSTAUXF, V0COBV_VLCUSTAUXF);
                _.Move(executed_1.V0COBV_VLCUSTAUXF_I, V0COBV_VLCUSTAUXF_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R050-SELECT-SEGURAVG-SECTION */
        private void R050_SELECT_SEGURAVG_SECTION()
        {
            /*" -398- MOVE 'SELECT R050-SEGURAVG   ' TO PARAGRAFO. */
            _.Move("SELECT R050-SEGURAVG   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -410- PERFORM R050_SELECT_SEGURAVG_DB_SELECT_1 */

            R050_SELECT_SEGURAVG_DB_SELECT_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -414- DISPLAY 'R050 - PROBLEMAS SELECT V0SEGURAVG  ..' */
                _.Display($"R050 - PROBLEMAS SELECT V0SEGURAVG  ..");

                /*" -415- DISPLAY ' CERTIFICADO  ' V0PROP-NRCERTIF */
                _.Display($" CERTIFICADO  {V0PROP_NRCERTIF}");

                /*" -417- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -417- ADD 1 TO AC-L-SEGURAVG. */
            AC_L_SEGURAVG.Value = AC_L_SEGURAVG + 1;

        }

        [StopWatch]
        /*" R050-SELECT-SEGURAVG-DB-SELECT-1 */
        public void R050_SELECT_SEGURAVG_DB_SELECT_1()
        {
            /*" -410- EXEC SQL SELECT SIT_REGISTRO, OCORR_HISTORICO, NUM_ITEM INTO :V0SEGV-SITUACAO, :V0SEGV-OCORHIST, :V0SEGV-NUMITEM FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :V0PROP-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES AND NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r050_SELECT_SEGURAVG_DB_SELECT_1_Query1 = new R050_SELECT_SEGURAVG_DB_SELECT_1_Query1()
            {
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_APOLICE = V0PROP_APOLICE.ToString(),
            };

            var executed_1 = R050_SELECT_SEGURAVG_DB_SELECT_1_Query1.Execute(r050_SELECT_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGV_SITUACAO, V0SEGV_SITUACAO);
                _.Move(executed_1.V0SEGV_OCORHIST, V0SEGV_OCORHIST);
                _.Move(executed_1.V0SEGV_NUMITEM, V0SEGV_NUMITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R060-SELECT-HISTSEGVG-SECTION */
        private void R060_SELECT_HISTSEGVG_SECTION()
        {
            /*" -429- MOVE 'R060-SELECT V0HISTSEGVG' TO PARAGRAFO. */
            _.Move("R060-SELECT V0HISTSEGVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -438- PERFORM R060_SELECT_HISTSEGVG_DB_SELECT_1 */

            R060_SELECT_HISTSEGVG_DB_SELECT_1();

            /*" -441- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -442- DISPLAY 'R060 - PROBLEMAS SELECT V0HISTSEGVG ..' */
                _.Display($"R060 - PROBLEMAS SELECT V0HISTSEGVG ..");

                /*" -443- DISPLAY ' CERT ' V0PROP-NRCERTIF */
                _.Display($" CERT {V0PROP_NRCERTIF}");

                /*" -444- DISPLAY ' ITEM ' V0SEGV-NUMITEM */
                _.Display($" ITEM {V0SEGV_NUMITEM}");

                /*" -445- DISPLAY ' OCOH ' V0SEGV-OCORHIST */
                _.Display($" OCOH {V0SEGV_OCORHIST}");

                /*" -447- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -447- ADD 1 TO AC-L-HISTSEGVG. */
            AC_L_HISTSEGVG.Value = AC_L_HISTSEGVG + 1;

        }

        [StopWatch]
        /*" R060-SELECT-HISTSEGVG-DB-SELECT-1 */
        public void R060_SELECT_HISTSEGVG_DB_SELECT_1()
        {
            /*" -438- EXEC SQL SELECT COD_OPERACAO, DATA_REFERENCIA INTO :V0HSEG-CODOPER, :V0HSEG-DTREFER FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :V0PROP-APOLICE AND NUM_ITEM = :V0SEGV-NUMITEM AND OCORR_HISTORICO = :V0SEGV-OCORHIST END-EXEC. */

            var r060_SELECT_HISTSEGVG_DB_SELECT_1_Query1 = new R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1()
            {
                V0SEGV_OCORHIST = V0SEGV_OCORHIST.ToString(),
                V0PROP_APOLICE = V0PROP_APOLICE.ToString(),
                V0SEGV_NUMITEM = V0SEGV_NUMITEM.ToString(),
            };

            var executed_1 = R060_SELECT_HISTSEGVG_DB_SELECT_1_Query1.Execute(r060_SELECT_HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HSEG_CODOPER, V0HSEG_CODOPER);
                _.Move(executed_1.V0HSEG_DTREFER, V0HSEG_DTREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

        [StopWatch]
        /*" R070-TRATA-TRANS-CREDITO-SECTION */
        private void R070_TRATA_TRANS_CREDITO_SECTION()
        {
            /*" -459- MOVE 'R070-TRATA-TRANS-CREDITO' TO PARAGRAFO. */
            _.Move("R070-TRATA-TRANS-CREDITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -471- PERFORM R070_TRATA_TRANS_CREDITO_DB_INSERT_1 */

            R070_TRATA_TRANS_CREDITO_DB_INSERT_1();

            /*" -474- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -475- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -476- DISPLAY 'REGISTRO DUPLICADO V0SAFCOBER OPER. 200' */
                    _.Display($"REGISTRO DUPLICADO V0SAFCOBER OPER. 200");

                    /*" -477- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                    _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                    /*" -478- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                    _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                    /*" -479- DISPLAY 'V0HSEG-DTREFER  ' V0HSEG-DTREFER */
                    _.Display($"V0HSEG-DTREFER  {V0HSEG_DTREFER}");

                    /*" -480- ELSE */
                }
                else
                {


                    /*" -481- DISPLAY 'PROBLEMA INSERT DA V0SAFCOBER OPER. 200' */
                    _.Display($"PROBLEMA INSERT DA V0SAFCOBER OPER. 200");

                    /*" -482- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                    _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                    /*" -483- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                    _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                    /*" -484- DISPLAY 'V0HSEG-DTREFER  ' V0HSEG-DTREFER */
                    _.Display($"V0HSEG-DTREFER  {V0HSEG_DTREFER}");

                    /*" -485- DISPLAY 'SQLCODE         ' SQLCODE */
                    _.Display($"SQLCODE         {DB.SQLCODE}");

                    /*" -487- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -489- ADD 1 TO AC-I-SAFCOBER. */
            AC_I_SAFCOBER.Value = AC_I_SAFCOBER + 1;

            /*" -505- PERFORM R070_TRATA_TRANS_CREDITO_DB_INSERT_2 */

            R070_TRATA_TRANS_CREDITO_DB_INSERT_2();

            /*" -508- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -509- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -510- DISPLAY 'REGISTRO DUPLICADO V0HISTREPSAF OPER. 200' */
                    _.Display($"REGISTRO DUPLICADO V0HISTREPSAF OPER. 200");

                    /*" -511- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                    _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                    /*" -512- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                    _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                    /*" -513- DISPLAY 'V0HSEG-DTREFER  ' V0HSEG-DTREFER */
                    _.Display($"V0HSEG-DTREFER  {V0HSEG_DTREFER}");

                    /*" -514- ELSE */
                }
                else
                {


                    /*" -515- DISPLAY 'PROBLEMA INSERT DA V0HISTREPSAF OPER. 200' */
                    _.Display($"PROBLEMA INSERT DA V0HISTREPSAF OPER. 200");

                    /*" -516- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                    _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                    /*" -517- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                    _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                    /*" -518- DISPLAY 'V0HSEG-DTREFER  ' V0HSEG-DTREFER */
                    _.Display($"V0HSEG-DTREFER  {V0HSEG_DTREFER}");

                    /*" -519- DISPLAY 'SQLCODE         ' SQLCODE */
                    _.Display($"SQLCODE         {DB.SQLCODE}");

                    /*" -521- GO TO 9999-ERRO. */

                    M_9999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -521- ADD 1 TO AC-I-HISTREPSAF. */
            AC_I_HISTREPSAF.Value = AC_I_HISTREPSAF + 1;

        }

        [StopWatch]
        /*" R070-TRATA-TRANS-CREDITO-DB-INSERT-1 */
        public void R070_TRATA_TRANS_CREDITO_DB_INSERT_1()
        {
            /*" -471- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0HSEG-DTREFER, '9999-12-31' , :V0COBV-IMPSEGAUXF, :V0COBV-VLCUSTAUXF, :V0PROP-NRCERTIF, 01, '0' , 'VA0415B' , CURRENT TIMESTAMP) END-EXEC. */

            var r070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1 = new R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0HSEG_DTREFER = V0HSEG_DTREFER.ToString(),
                V0COBV_IMPSEGAUXF = V0COBV_IMPSEGAUXF.ToString(),
                V0COBV_VLCUSTAUXF = V0COBV_VLCUSTAUXF.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            R070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1.Execute(r070_TRATA_TRANS_CREDITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/

        [StopWatch]
        /*" R070-TRATA-TRANS-CREDITO-DB-INSERT-2 */
        public void R070_TRATA_TRANS_CREDITO_DB_INSERT_2()
        {
            /*" -505- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0HSEG-DTREFER, :V0PROP-NRCERTIF, 00, :V0PROP-NUM-MATRICULA, :V0COBV-VLCUSTAUXF, :V0PROP-CODOPER, '7' , '0' , 000, 000, 'VA0415B' , CURRENT TIMESTAMP, :V1SIST-DTMOVABE) END-EXEC. */

            var r070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1 = new R070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0HSEG_DTREFER = V0HSEG_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NUM_MATRICULA = V0PROP_NUM_MATRICULA.ToString(),
                V0COBV_VLCUSTAUXF = V0COBV_VLCUSTAUXF.ToString(),
                V0PROP_CODOPER = V0PROP_CODOPER.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1.Execute(r070_TRATA_TRANS_CREDITO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R080-TRATA-TRANS-DEBITO-SECTION */
        private void R080_TRATA_TRANS_DEBITO_SECTION()
        {
            /*" -560- MOVE 'R080-TRATA-TRANS-DEBITO' TO PARAGRAFO. */
            _.Move("R080-TRATA-TRANS-DEBITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -569- PERFORM R080_TRATA_TRANS_DEBITO_DB_UPDATE_1 */

            R080_TRATA_TRANS_DEBITO_DB_UPDATE_1();

            /*" -572- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -573- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -574- DISPLAY 'REGISTRO NAO EXISTE NA V0SAFCOBER' */
                    _.Display($"REGISTRO NAO EXISTE NA V0SAFCOBER");

                    /*" -575- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                    _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                    /*" -576- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                    _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                    /*" -577- ELSE */
                }
                else
                {


                    /*" -578- IF SQLCODE NOT EQUAL -803 */

                    if (DB.SQLCODE != -803)
                    {

                        /*" -579- DISPLAY 'PROBLEMA UPDATE DA V0SAFCOBER OPER. 300' */
                        _.Display($"PROBLEMA UPDATE DA V0SAFCOBER OPER. 300");

                        /*" -580- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                        _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                        /*" -581- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                        _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                        /*" -582- DISPLAY 'SQLCODE         ' SQLCODE */
                        _.Display($"SQLCODE         {DB.SQLCODE}");

                        /*" -583- GO TO 9999-ERRO */

                        M_9999_ERRO_SECTION(); //GOTO
                        return;

                        /*" -584- ELSE */
                    }
                    else
                    {


                        /*" -591- PERFORM R080_TRATA_TRANS_DEBITO_DB_UPDATE_2 */

                        R080_TRATA_TRANS_DEBITO_DB_UPDATE_2();

                        /*" -594- IF SQLCODE NOT EQUAL 00 */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -595- DISPLAY 'PROBLEMA UPDATE DA V0SAFCOBER 2 OPER. 300' */
                            _.Display($"PROBLEMA UPDATE DA V0SAFCOBER 2 OPER. 300");

                            /*" -596- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                            _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                            /*" -597- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                            _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                            /*" -598- DISPLAY 'SQLCODE         ' SQLCODE */
                            _.Display($"SQLCODE         {DB.SQLCODE}");

                            /*" -600- GO TO 9999-ERRO. */

                            M_9999_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -602- ADD 1 TO AC-C-SAFCOBER. */
            AC_C_SAFCOBER.Value = AC_C_SAFCOBER + 1;

            /*" -618- PERFORM R080_TRATA_TRANS_DEBITO_DB_INSERT_1 */

            R080_TRATA_TRANS_DEBITO_DB_INSERT_1();

            /*" -621- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -622- DISPLAY 'PROBLEMA INSERT DA V0HISTREPSAF OPER. 300' */
                _.Display($"PROBLEMA INSERT DA V0HISTREPSAF OPER. 300");

                /*" -623- DISPLAY 'V0PROP-NRCERTIF ' V0PROP-NRCERTIF */
                _.Display($"V0PROP-NRCERTIF {V0PROP_NRCERTIF}");

                /*" -624- DISPLAY 'V0PROP-CODCLIEN ' V0PROP-CODCLIEN */
                _.Display($"V0PROP-CODCLIEN {V0PROP_CODCLIEN}");

                /*" -625- DISPLAY 'SQLCODE         ' SQLCODE */
                _.Display($"SQLCODE         {DB.SQLCODE}");

                /*" -627- GO TO 9999-ERRO. */

                M_9999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -627- ADD 1 TO AC-I-HISTREPSAF. */
            AC_I_HISTREPSAF.Value = AC_I_HISTREPSAF + 1;

        }

        [StopWatch]
        /*" R080-TRATA-TRANS-DEBITO-DB-UPDATE-1 */
        public void R080_TRATA_TRANS_DEBITO_DB_UPDATE_1()
        {
            /*" -569- EXEC SQL UPDATE SEGUROS.V0SAFCOBER SET DTTERVIG = :V0HSEG-DTREFER, CODUSU = 'VA0415B' , SITUACA = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1 = new R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1()
            {
                V0HSEG_DTREFER = V0HSEG_DTREFER.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1.Execute(r080_TRATA_TRANS_DEBITO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/

        [StopWatch]
        /*" R080-TRATA-TRANS-DEBITO-DB-INSERT-1 */
        public void R080_TRATA_TRANS_DEBITO_DB_INSERT_1()
        {
            /*" -618- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0HSEG-DTREFER, :V0PROP-NRCERTIF, 00, :V0PROP-NUM-MATRICULA, :V0COBV-VLCUSTAUXF, :V0PROP-CODOPER, '7' , '0' , 000, 000, 'VA0415B' , CURRENT TIMESTAMP, :V0HSEG-DTREFER:VIND-DTMOVTO) END-EXEC. */

            var r080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1 = new R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0HSEG_DTREFER = V0HSEG_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NUM_MATRICULA = V0PROP_NUM_MATRICULA.ToString(),
                V0COBV_VLCUSTAUXF = V0COBV_VLCUSTAUXF.ToString(),
                V0PROP_CODOPER = V0PROP_CODOPER.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1.Execute(r080_TRATA_TRANS_DEBITO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R080-TRATA-TRANS-DEBITO-DB-UPDATE-2 */
        public void R080_TRATA_TRANS_DEBITO_DB_UPDATE_2()
        {
            /*" -591- EXEC SQL UPDATE SEGUROS.V0SAFCOBER SET CODUSU = 'VA0415B' , SITUACA = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC */

            var r080_TRATA_TRANS_DEBITO_DB_UPDATE_2_Update1 = new R080_TRATA_TRANS_DEBITO_DB_UPDATE_2_Update1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            R080_TRATA_TRANS_DEBITO_DB_UPDATE_2_Update1.Execute(r080_TRATA_TRANS_DEBITO_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-9999-ERRO-SECTION */
        private void M_9999_ERRO_SECTION()
        {
            /*" -641- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.FILLER_6.WSQLCODE);

            /*" -642- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.FILLER_6.WSQLERRD1);

            /*" -643- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.FILLER_6.WSQLERRD2);

            /*" -645- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -646- DISPLAY '** VA0415B ** LIDOS PROPOVA     ' AC-L-PROPOVA */
            _.Display($"** VA0415B ** LIDOS PROPOVA     {AC_L_PROPOVA}");

            /*" -647- DISPLAY '** VA0415B ** LIDOS COBERPROP   ' AC-L-COBERPROPVA */
            _.Display($"** VA0415B ** LIDOS COBERPROP   {AC_L_COBERPROPVA}");

            /*" -648- DISPLAY '** VA0415B ** LIDOS FUNCIOCEF   ' AC-L-FUNCIOCEF */
            _.Display($"** VA0415B ** LIDOS FUNCIOCEF   {AC_L_FUNCIOCEF}");

            /*" -649- DISPLAY '** VA0415B ** LIDOS SAFCOBER    ' AC-L-SAFCOBER */
            _.Display($"** VA0415B ** LIDOS SAFCOBER    {AC_L_SAFCOBER}");

            /*" -650- DISPLAY '** VA0415B ** LIDOS SEGURAVG    ' AC-L-SEGURAVG */
            _.Display($"** VA0415B ** LIDOS SEGURAVG    {AC_L_SEGURAVG}");

            /*" -651- DISPLAY '** VA0415B ** LIDOS HISTSEGVG   ' AC-L-HISTSEGVG */
            _.Display($"** VA0415B ** LIDOS HISTSEGVG   {AC_L_HISTSEGVG}");

            /*" -652- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -653- DISPLAY '** VA0415B ** INCL. HISTREPSAF  ' AC-I-HISTREPSAF */
            _.Display($"** VA0415B ** INCL. HISTREPSAF  {AC_I_HISTREPSAF}");

            /*" -654- DISPLAY '** VA0415B ** INCL. SAFCOBER    ' AC-I-SAFCOBER */
            _.Display($"** VA0415B ** INCL. SAFCOBER    {AC_I_SAFCOBER}");

            /*" -655- DISPLAY '** VA0415B ** CANC. SAFCOBER    ' AC-C-SAFCOBER */
            _.Display($"** VA0415B ** CANC. SAFCOBER    {AC_C_SAFCOBER}");

            /*" -656- DISPLAY '** VA0415B ** REAB. SAFCOBER    ' AC-R-SAFCOBER */
            _.Display($"** VA0415B ** REAB. SAFCOBER    {AC_R_SAFCOBER}");

            /*" -657- DISPLAY '** VA0415B ** CANC. HISTREPSAF  ' AC-C-HISTREPSAF */
            _.Display($"** VA0415B ** CANC. HISTREPSAF  {AC_C_HISTREPSAF}");

            /*" -658- DISPLAY '** VA0415B ** SUSP. HISTREPSAF  ' AC-S-HISTREPSAF */
            _.Display($"** VA0415B ** SUSP. HISTREPSAF  {AC_S_HISTREPSAF}");

            /*" -659- DISPLAY '** VA0415B ** REAB. HISTREPSAF  ' AC-R-HISTREPSAF */
            _.Display($"** VA0415B ** REAB. HISTREPSAF  {AC_R_HISTREPSAF}");

            /*" -661- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -663- DISPLAY '*** VA0415B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA0415B *** ROLLBACK EM ANDAMENTO ...");

            /*" -663- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -666- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -667- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -667- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -671- DISPLAY '*** VA0415B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA0415B *** ERRO DE EXECUCAO");

            /*" -672- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -672- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_FIM*/
    }
}