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
using Sias.VidaAzul.DB2.VA3812B;

namespace Code
{
    public class VA3812B
    {
        public bool IsCall { get; set; }

        public VA3812B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE CREDITO EM CONTA FEBRABAN      *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                                             *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE CREDITO NAO EFETUADOS E VERIFICA SE ALGUMA AGENCIA NAO  *      */
        /*"      *     SERA IDENTIFICADA. SE NAO IDENTIFICAR DAR DISPLAY DELA.    *      */
        /*"      *                                                                *      */
        /*"      *                                    M MESSIAS DE S              *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4           10/06/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           18/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * IMPLEMENTACAO DA NOVA CODIFICACAO DE ESCRITORIO DE NEGOCIOS    *      */
        /*"      * (PROCURAR POR EB0202) - ENRICO (PRODEXTER)            FEV/2002 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   FGV-2                                          *      */
        /*"      *               - AJUSTES NO PROGRAMA A FIM DE FAZER UMA EXECUCAO*      */
        /*"      *                 PARALELA ENTRE A JPVAD00 E JPCSD01.            *      */
        /*"      *   EM 08/02/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RETCRE { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETCRE
        {
            get
            {
                _.Move(RETCRE_RECORD, _RETCRE); VarBasis.RedefinePassValue(RETCRE_RECORD, _RETCRE, RETCRE_RECORD); return _RETCRE;
            }
        }
        public FileBasis _RVA3812B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RVA3812B
        {
            get
            {
                _.Move(ARQ_RVA3812B, _RVA3812B); VarBasis.RedefinePassValue(ARQ_RVA3812B, _RVA3812B, ARQ_RVA3812B); return _RVA3812B;
            }
        }
        /*"01  RETCRE-RECORD        PIC X(150).*/
        public StringBasis RETCRE_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RET-HEADER.*/
        public VA3812B_RET_HEADER RET_HEADER { get; set; } = new VA3812B_RET_HEADER();
        public class VA3812B_RET_HEADER : VarBasis
        {
            /*"    05 RA-COD-REG         PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RA-COD-REMESSA     PIC 9(001).*/
            public IntBasis RA_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 RA-COD-CONVENIO    PIC 9(004).*/
            public IntBasis RA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 FILLER             PIC X(016).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"    05 RA-NOME-EMPRESA    PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 RA-COD-BANCO       PIC 9(003).*/
            public IntBasis RA_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05 RA-NOME-BANCO      PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 RA-DATA-GERACAO    PIC X(006).*/
            public StringBasis RA_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05 RA-NSA             PIC 9(006).*/
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RA-VERSAO-LAYOUT   PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RA-SERVICO         PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RA-RESERVADO       PIC X(054).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
            /*"01  RET-CADASTRAMENTO.*/
        }
        public VA3812B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA3812B_RET_CADASTRAMENTO();
        public class VA3812B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05 RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RF-IDENT-CLI-EMPRESA.*/
            public VA3812B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA3812B_RF_IDENT_CLI_EMPRESA();
            public class VA3812B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 RF-NRCERTIF      PIC 9(015).*/
                public IntBasis RF_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 FILLER           PIC X(010).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05 RF-AGENCIA          PIC 9(004).*/
            }
            public IntBasis RF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA3812B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA3812B_RF_IDENT_CLI_BANCO();
            public class VA3812B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 RF-COD-OPERACAO  PIC 9(004).*/
                public IntBasis RF_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RF-NUM-CONTA     PIC 9(012).*/
                public IntBasis RF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 RF-DIG-CONTA     PIC 9(001).*/
                public IntBasis RF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER           PIC X(002).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL        PIC X(006).*/
            }
            public StringBasis RF_DATA_REAL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05 RF-VALOR            PIC 9(013)V99.*/
            public DoubleBasis RF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO      PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA3812B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA3812B_RF_USO_EMPRESA();
            public class VA3812B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10 RF-NSA           PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 RF-NSA-R         REDEFINES          RF-NSA.*/
                private _REDEF_VA3812B_RF_NSA_R _rf_nsa_r { get; set; }
                public _REDEF_VA3812B_RF_NSA_R RF_NSA_R
                {
                    get { _rf_nsa_r = new _REDEF_VA3812B_RF_NSA_R(); _.Move(RF_NSA, _rf_nsa_r); VarBasis.RedefinePassValue(RF_NSA, _rf_nsa_r, RF_NSA); _rf_nsa_r.ValueChanged += () => { _.Move(_rf_nsa_r, RF_NSA); }; return _rf_nsa_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_nsa_r, RF_NSA); }
                }  //Redefines
                public class _REDEF_VA3812B_RF_NSA_R : VarBasis
                {
                    /*"          15 FILLER        PIC X(001).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"          15 RF-SERIE      PIC 9(002).*/
                    public IntBasis RF_SERIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"       10 RF-NSL           PIC 9(008).*/

                    public _REDEF_VA3812B_RF_NSA_R()
                    {
                        FILLER_3.ValueChanged += OnValueChanged;
                        RF_SERIE.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 RF-NSL-R         REDEFINES          RF-NSL.*/
                private _REDEF_VA3812B_RF_NSL_R _rf_nsl_r { get; set; }
                public _REDEF_VA3812B_RF_NSL_R RF_NSL_R
                {
                    get { _rf_nsl_r = new _REDEF_VA3812B_RF_NSL_R(); _.Move(RF_NSL, _rf_nsl_r); VarBasis.RedefinePassValue(RF_NSL, _rf_nsl_r, RF_NSL); _rf_nsl_r.ValueChanged += () => { _.Move(_rf_nsl_r, RF_NSL); }; return _rf_nsl_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_nsl_r, RF_NSL); }
                }  //Redefines
                public class _REDEF_VA3812B_RF_NSL_R : VarBasis
                {
                    /*"          15 RF-NSL-7      PIC 9(007).*/
                    public IntBasis RF_NSL_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                    /*"          15 FILLER        PIC X(001).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"       10 FILLER           PIC X(049).*/

                    public _REDEF_VA3812B_RF_NSL_R()
                    {
                        RF_NSL_7.ValueChanged += OnValueChanged;
                        FILLER_4.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
                /*"    05 RF-RESERVADO        PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO    PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA3812B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA3812B_RET_TRAILLER();
        public class VA3812B_RET_TRAILLER : VarBasis
        {
            /*"    05 RZ-COD-REG         PIC X(001).*/
            public StringBasis RZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROS  PIC 9(006).*/
            public IntBasis RZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RZ-TOT-DEB-CRUZ    PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-TOT-CRED-CRUZ   PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-RESERVADO       PIC X(109).*/
            public StringBasis RZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01  ARQ-RVA3812B.*/
        }
        public VA3812B_ARQ_RVA3812B ARQ_RVA3812B { get; set; } = new VA3812B_ARQ_RVA3812B();
        public class VA3812B_ARQ_RVA3812B : VarBasis
        {
            /*"    05  ARQ-MENSAGEM                   PIC X(34).*/
            public StringBasis ARQ_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "34", "X(34)."), @"");
            /*"    05  FILLER                         PIC X(03).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05  ARQ-AGENCIA                    PIC X(04).*/
            public StringBasis ARQ_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05  FILLER                         PIC X(03).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05  ARQ-FONTE                      PIC X(04).*/
            public StringBasis ARQ_FONTE { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  V1MCEF-COD-FONTE                 PIC S9(4) COMP.*/
        public IntBasis V1MCEF_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  V1ACEF-COD-AGENCIA               PIC S9(4) COMP.*/
        public IntBasis V1ACEF_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WHOST-AGE-VENDA                  PIC S9(4) COMP.*/
        public IntBasis WHOST_AGE_VENDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WORK-AREA.*/
        public VA3812B_WORK_AREA WORK_AREA { get; set; } = new VA3812B_WORK_AREA();
        public class VA3812B_WORK_AREA : VarBasis
        {
            /*"    05      TAB-FILIAL.*/
            public VA3812B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA3812B_TAB_FILIAL();
            public class VA3812B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<VA3812B_FILLER_8> FILLER_8 { get; set; } = new ListBasis<VA3812B_FILLER_8>(9999);
                public class VA3812B_FILLER_8 : VarBasis
                {
                    /*"        15  TAB-AGENCIA              PIC  9(4).*/
                    public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"        15  TAB-FONTE                PIC  9(4).*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
                }
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WFIM-V1AGENCEF           PIC  X(001) VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 AC-L-V1AGENCEF            PIC  9(7) VALUE ZEROS.*/
            public IntBasis AC_L_V1AGENCEF { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA3812B_WABEND WABEND { get; set; } = new VA3812B_WABEND();
            public class VA3812B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA3812B  '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA3812B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA3812B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA3812B_LOCALIZA_ABEND_1();
            public class VA3812B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA3812B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA3812B_LOCALIZA_ABEND_2();
            public class VA3812B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  WS-TIME.*/
            }
        }
        public VA3812B_WS_TIME WS_TIME { get; set; } = new VA3812B_WS_TIME();
        public class VA3812B_WS_TIME : VarBasis
        {
            /*"    05 WS-TIME-N                     PIC 9(06).*/
            public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 FILLER                        PIC X(02).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"01  ON-INTERVAL                      PIC 9(06) VALUE 10000.*/
        }
        public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"), 10000);
        /*"01  ON-COUNTER                       PIC 9(06) VALUE 0.*/
        public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));


        public VA3812B_V1AGENCEF V1AGENCEF { get; set; } = new VA3812B_V1AGENCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETCRE_FILE_NAME_P, string RVA3812B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETCRE.SetFile(RETCRE_FILE_NAME_P);
                RVA3812B.SetFile(RVA3812B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -231- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -234- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -237- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -240- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -241- DISPLAY 'PROGRAMA EM EXECUCAO VA3812B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO VA3812B   ");

            /*" -242- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -243- DISPLAY 'VERSAO V.02 FGV-2   08/02/2017 ' . */
            _.Display($"VERSAO V.02 FGV-2   08/02/2017 ");

            /*" -244- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -246- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -247- OPEN INPUT RETCRE. */
            RETCRE.Open(RETCRE_RECORD);

            /*" -249- OPEN OUTPUT RVA3812B. */
            RVA3812B.Open(ARQ_RVA3812B);

            /*" -251- MOVE ZEROS TO TAB-FILIAL. */
            _.Move(0, WORK_AREA.TAB_FILIAL);

            /*" -253- PERFORM M-3000-00-DECLARE-V1AGENCEF */

            M_3000_00_DECLARE_V1AGENCEF(true);

            /*" -255- PERFORM 3100-00-FETCH-V1AGENCEF */

            M_3100_00_FETCH_V1AGENCEF(true);

            /*" -256- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -257- DISPLAY '0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -259- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -262- PERFORM 3200-00-CARREGA-FILIAL THRU 3200-FIM UNTIL WFIM-V1AGENCEF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V1AGENCEF == "S"))
            {

                M_3200_00_CARREGA_FILIAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_FIM*/

            }

            /*" -262- PERFORM 0001-INICIO-PROCESSO. */

            M_0001_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-0001-INICIO-PROCESSO */
        private void M_0001_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -270- MOVE '0001-INICIO-PROCESSO' TO PARAGRAFO. */
            _.Move("0001-INICIO-PROCESSO", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -271- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -272- DISPLAY '*** VA3812B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA3812B *** MOVIMENTO RETORNO VAZIO");

                    /*" -276- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADER);
                _.Move(RETCRE.Value, RET_CADASTRAMENTO);
                _.Move(RETCRE.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -277- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -278- DISPLAY '*** VA3812B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA3812B *** FITA SEM MOVIMENTO ");

                    /*" -280- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADER);
                _.Move(RETCRE.Value, RET_CADASTRAMENTO);
                _.Move(RETCRE.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -282- DISPLAY '*** VA3812B *** PROCESSANDO ...' . */
            _.Display($"*** VA3812B *** PROCESSANDO ...");

            /*" -284- PERFORM 0020-PROCESSA THRU 0020-FIM UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                M_0020_PROCESSA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

            }

        }

        [StopWatch]
        /*" M-0001-FIM-NORMAL */
        private void M_0001_FIM_NORMAL(bool isPerform = false)
        {
            /*" -288- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -293- CLOSE RETCRE RVA3812B. */
            RETCRE.Close();
            RVA3812B.Close();

            /*" -295- DISPLAY '*** VA3812B *** TERMINO NORMAL' . */
            _.Display($"*** VA3812B *** TERMINO NORMAL");

            /*" -297- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -297- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0001-FIM-ANORMAL */
        private void M_0001_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -301- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -306- CLOSE RETCRE RVA3812B. */
            RETCRE.Close();
            RVA3812B.Close();

            /*" -308- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -308- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0020-PROCESSA */
        private void M_0020_PROCESSA(bool isPerform = false)
        {
            /*" -315- MOVE '0020-PROCESSA ..    ' TO PARAGRAFO. */
            _.Move("0020-PROCESSA ..    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -318- ADD 1 TO AC-LIDOS ON-COUNTER. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            ON_COUNTER.Value = ON_COUNTER + 1;

            /*" -320- IF AC-LIDOS EQUAL 1 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WORK_AREA.AC_LIDOS == 1 || ON_COUNTER == ON_INTERVAL)
            {

                /*" -321- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -322- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WS_TIME}"
                .Display();

                /*" -324- MOVE 0 TO ON-COUNTER. */
                _.Move(0, ON_COUNTER);
            }


            /*" -326- PERFORM 3300-BUSCA-FONTE THRU 3300-FIM. */

            M_3300_BUSCA_FONTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_FIM*/


            /*" -327- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -328- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADER);
                _.Move(RETCRE.Value, RET_CADASTRAMENTO);
                _.Move(RETCRE.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF */
        private void M_3000_00_DECLARE_V1AGENCEF(bool isPerform = false)
        {
            /*" -336- MOVE '3000-DECLA-V1AGENCEF   ' TO PARAGRAFO. */
            _.Move("3000-DECLA-V1AGENCEF   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -338- MOVE 'DECLARE V1AGENCEF+V1MALHCEF' TO COMANDO. */
            _.Move("DECLARE V1AGENCEF+V1MALHCEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -348- PERFORM M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -350- PERFORM M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -354- DISPLAY '3000 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"3000 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -355- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -355- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -348- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            V1AGENCEF = new VA3812B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.V1AGENCIACEF A
							, 
							SEGUROS.V1MALHACEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF-DB-OPEN-1 */
        public void M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1()
        {
            /*" -350- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF */
        private void M_3100_00_FETCH_V1AGENCEF(bool isPerform = false)
        {
            /*" -363- MOVE '3100-FETCH-V1AGENCEF   ' TO PARAGRAFO. */
            _.Move("3100-FETCH-V1AGENCEF   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -365- MOVE 'FETCH   V1AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   V1AGENCIACEF   ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -368- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -371- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -372- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -373- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", WORK_AREA.WFIM_V1AGENCEF);

                    /*" -373- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -375- ELSE */
                }
                else
                {


                    /*" -375- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -377- DISPLAY '3100 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -378- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -379- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -380- ELSE */
                }

            }
            else
            {


                /*" -380- ADD 1 TO AC-L-V1AGENCEF. */
                WORK_AREA.AC_L_V1AGENCEF.Value = WORK_AREA.AC_L_V1AGENCEF + 1;
            }


        }

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -368- EXEC SQL FETCH V1AGENCEF INTO :V1ACEF-COD-AGENCIA, :V1MCEF-COD-FONTE END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.V1ACEF_COD_AGENCIA, V1ACEF_COD_AGENCIA);
                _.Move(V1AGENCEF.V1MCEF_COD_FONTE, V1MCEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-CLOSE-1 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1()
        {
            /*" -373- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -375- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" M-3200-00-CARREGA-FILIAL */
        private void M_3200_00_CARREGA_FILIAL(bool isPerform = false)
        {
            /*" -389- MOVE '3200-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("3200-CARREGA-FILIAL    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -391- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -393- MOVE V1ACEF-COD-AGENCIA TO TAB-AGENCIA (V1ACEF-COD-AGENCIA) */
            _.Move(V1ACEF_COD_AGENCIA, WORK_AREA.TAB_FILIAL.FILLER_8[V1ACEF_COD_AGENCIA].TAB_AGENCIA);

            /*" -396- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (V1ACEF-COD-AGENCIA) */
            _.Move(V1MCEF_COD_FONTE, WORK_AREA.TAB_FILIAL.FILLER_8[V1ACEF_COD_AGENCIA].TAB_FONTE);

            /*" -396- PERFORM 3100-00-FETCH-V1AGENCEF. */

            M_3100_00_FETCH_V1AGENCEF(true);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_FIM*/

        [StopWatch]
        /*" M-3300-BUSCA-FONTE */
        private void M_3300_BUSCA_FONTE(bool isPerform = false)
        {
            /*" -405- MOVE '3300-BUSCA-FONTE   ' TO PARAGRAFO. */
            _.Move("3300-BUSCA-FONTE   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -407- MOVE 'BUSCA-FONTE        ' TO COMANDO. */
            _.Move("BUSCA-FONTE        ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -409- MOVE RF-AGENCIA TO WHOST-AGE-VENDA */
            _.Move(RET_CADASTRAMENTO.RF_AGENCIA, WHOST_AGE_VENDA);

            /*" -410- IF WHOST-AGE-VENDA = TAB-AGENCIA (WHOST-AGE-VENDA) */

            if (WHOST_AGE_VENDA == WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA].TAB_AGENCIA)
            {

                /*" -411- IF TAB-FONTE (WHOST-AGE-VENDA) EQUAL 10 */

                if (WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA].TAB_FONTE == 10)
                {

                    /*" -412- DISPLAY '*** A FONTE DA AGENCIA NAO E PERMITIDA ***' */
                    _.Display($"*** A FONTE DA AGENCIA NAO E PERMITIDA ***");

                    /*" -413- DISPLAY 'AGENCIA ... ' TAB-AGENCIA (WHOST-AGE-VENDA) */
                    _.Display($"AGENCIA ... {WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA]}");

                    /*" -414- DISPLAY 'FONTE   ... ' TAB-FONTE (WHOST-AGE-VENDA) */
                    _.Display($"FONTE   ... {WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA]}");

                    /*" -415- DISPLAY '  ' */
                    _.Display($"  ");

                    /*" -416- MOVE 'A FONTE DA AGENCIA NAO E PERMITIDA' TO ARQ-MENSAGEM */
                    _.Move("A FONTE DA AGENCIA NAO E PERMITIDA", ARQ_RVA3812B.ARQ_MENSAGEM);

                    /*" -417- MOVE TAB-AGENCIA(WHOST-AGE-VENDA) TO ARQ-AGENCIA */
                    _.Move(WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA].TAB_AGENCIA, ARQ_RVA3812B.ARQ_AGENCIA);

                    /*" -418- MOVE TAB-FONTE (WHOST-AGE-VENDA) TO ARQ-FONTE */
                    _.Move(WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA].TAB_FONTE, ARQ_RVA3812B.ARQ_FONTE);

                    /*" -419- WRITE ARQ-RVA3812B */
                    RVA3812B.Write(ARQ_RVA3812B.GetMoveValues().ToString());

                    /*" -421- GO TO 3300-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_FIM*/ //GOTO
                    return;
                }

            }


            /*" -422- IF WHOST-AGE-VENDA NOT = TAB-AGENCIA (WHOST-AGE-VENDA) */

            if (WHOST_AGE_VENDA != WORK_AREA.TAB_FILIAL.FILLER_8[WHOST_AGE_VENDA].TAB_AGENCIA)
            {

                /*" -423- DISPLAY '*** A AGENCIA NAO FOI IDENTIFICADA ***' */
                _.Display($"*** A AGENCIA NAO FOI IDENTIFICADA ***");

                /*" -424- DISPLAY 'AGENCIA   ... ' WHOST-AGE-VENDA */
                _.Display($"AGENCIA   ... {WHOST_AGE_VENDA}");

                /*" -425- DISPLAY '  ' */
                _.Display($"  ");

                /*" -426- MOVE 'A AGENCIA NAO FOI IDENTIFICADA ' TO ARQ-MENSAGEM */
                _.Move("A AGENCIA NAO FOI IDENTIFICADA ", ARQ_RVA3812B.ARQ_MENSAGEM);

                /*" -427- MOVE WHOST-AGE-VENDA TO ARQ-AGENCIA */
                _.Move(WHOST_AGE_VENDA, ARQ_RVA3812B.ARQ_AGENCIA);

                /*" -427- WRITE ARQ-RVA3812B. */
                RVA3812B.Write(ARQ_RVA3812B.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3300_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -437- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -438- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -439- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -440- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -441- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -443- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -446- CLOSE RETCRE RVA3812B. */
            RETCRE.Close();
            RVA3812B.Close();

            /*" -448- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -452- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -452- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}