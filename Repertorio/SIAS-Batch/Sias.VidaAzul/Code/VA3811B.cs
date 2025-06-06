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
using Sias.VidaAzul.DB2.VA3811B;

namespace Code
{
    public class VA3811B
    {
        public bool IsCall { get; set; }

        public VA3811B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE DEBITO EM CONTA FEBRABAN       *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                             02.09.92        *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE DEBITO DE SEGURO E VERIFICA SE ALGUMA AGENCIA NAO SERA  *      */
        /*"      *     IDENTIFICADA. SE NAO IDENTIFICAR DAR DISPLAY DELA.         *      */
        /*"      *                                                                *      */
        /*"      *                                    M MESSIAS DE S              *      */
        /*"      *                                                                *      */
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
        #endregion


        #region VARIABLES

        public FileBasis _RETDEB { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETDEB
        {
            get
            {
                _.Move(RETDEB_RECORD, _RETDEB); VarBasis.RedefinePassValue(RETDEB_RECORD, _RETDEB, RETDEB_RECORD); return _RETDEB;
            }
        }
        public FileBasis _RVA3811B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RVA3811B
        {
            get
            {
                _.Move(ARQ_RVA3811B, _RVA3811B); VarBasis.RedefinePassValue(ARQ_RVA3811B, _RVA3811B, ARQ_RVA3811B); return _RVA3811B;
            }
        }
        /*"01  RETDEB-RECORD        PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01  RET-HEADER.*/
        public VA3811B_RET_HEADER RET_HEADER { get; set; } = new VA3811B_RET_HEADER();
        public class VA3811B_RET_HEADER : VarBasis
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
            /*"    05 RA-DATA-GERACAO.*/
            public VA3811B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA3811B_RA_DATA_GERACAO();
            public class VA3811B_RA_DATA_GERACAO : VarBasis
            {
                /*"       10 RA-AA-GER       PIC X(002).*/
                public StringBasis RA_AA_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10 RA-MM-GER       PIC X(002).*/
                public StringBasis RA_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10 RA-DD-GER       PIC X(002).*/
                public StringBasis RA_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RA-NSA             PIC 9(006).*/
            }
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RA-VERSAO-LAYOUT   PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RA-SERVICO         PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RA-RESERVADO       PIC X(054).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
            /*"01  RET-CADASTRAMENTO.*/
        }
        public VA3811B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA3811B_RET_CADASTRAMENTO();
        public class VA3811B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05 RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RF-IDENT-CLI-EMPRESA.*/
            public VA3811B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA3811B_RF_IDENT_CLI_EMPRESA();
            public class VA3811B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 RF-IDENTIF-CLI   PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 RF-IDENTIF-CLI-R REDEFINES          RF-IDENTIF-CLI.*/
                private _REDEF_VA3811B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VA3811B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VA3811B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA3811B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"          15 FILLER        PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 FILLER           PIC X(010).*/

                    public _REDEF_VA3811B_RF_IDENTIF_CLI_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05 RF-AGENCIA          PIC 9(004).*/
            }
            public IntBasis RF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA3811B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA3811B_RF_IDENT_CLI_BANCO();
            public class VA3811B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10 RF-COD-OPERACAO  PIC 9(004).*/
                public IntBasis RF_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10 RF-NUM-CONTA     PIC 9(012).*/
                public IntBasis RF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10 RF-DIG-CONTA     PIC 9(001).*/
                public IntBasis RF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10 FILLER           PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VA3811B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA3811B_RF_DATA_REAL();
            public class VA3811B_RF_DATA_REAL : VarBasis
            {
                /*"       10 RF-ANO-REAL      PIC 9(002).*/
                public IntBasis RF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 RF-MES-REAL      PIC 9(002).*/
                public IntBasis RF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 RF-DIA-REAL      PIC 9(002).*/
                public IntBasis RF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VALOR            PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO      PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA3811B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA3811B_RF_USO_EMPRESA();
            public class VA3811B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10 RF-NSA           PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 RF-NSL           PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10 FILLER           PIC X(049).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
                /*"    05 RF-RESERVADO        PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO    PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA3811B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA3811B_RET_TRAILLER();
        public class VA3811B_RET_TRAILLER : VarBasis
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
            /*"01  ARQ-RVA3811B.*/
        }
        public VA3811B_ARQ_RVA3811B ARQ_RVA3811B { get; set; } = new VA3811B_ARQ_RVA3811B();
        public class VA3811B_ARQ_RVA3811B : VarBasis
        {
            /*"    05  ARQ-MENSAGEM                   PIC X(34).*/
            public StringBasis ARQ_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "34", "X(34)."), @"");
            /*"    05  FILLER                         PIC X(03).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05  ARQ-AGENCIA                    PIC X(04).*/
            public StringBasis ARQ_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05  FILLER                         PIC X(03).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
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
        public VA3811B_WORK_AREA WORK_AREA { get; set; } = new VA3811B_WORK_AREA();
        public class VA3811B_WORK_AREA : VarBasis
        {
            /*"    05      TAB-FILIAL.*/
            public VA3811B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA3811B_TAB_FILIAL();
            public class VA3811B_TAB_FILIAL : VarBasis
            {
                /*"      10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<VA3811B_FILLER_7> FILLER_7 { get; set; } = new ListBasis<VA3811B_FILLER_7>(9999);
                public class VA3811B_FILLER_7 : VarBasis
                {
                    /*"        15  TAB-AGENCIA              PIC  9(4).*/
                    public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"        15  TAB-FONTE                PIC  9(4).*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
                }
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05  WS-TIME.*/
            public VA3811B_WS_TIME WS_TIME { get; set; } = new VA3811B_WS_TIME();
            public class VA3811B_WS_TIME : VarBasis
            {
                /*"      07 WS-TIME-N                   PIC 9(06).*/
                public IntBasis WS_TIME_N { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"      07 FILLER                      PIC X(02).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05  ON-INTERVAL                  PIC 9(06) VALUE 5000.*/
            }
            public IntBasis ON_INTERVAL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"), 5000);
            /*"    05  ON-COUNTER                   PIC 9(06) VALUE 0.*/
            public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WFIM-V1AGENCEF           PIC  X(001) VALUE SPACES.*/
            public StringBasis WFIM_V1AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 AC-L-V1AGENCEF                PIC 9(7) VALUE ZEROS.*/
            public IntBasis AC_L_V1AGENCEF { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA3811B_WABEND WABEND { get; set; } = new VA3811B_WABEND();
            public class VA3811B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA3811B  '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA3811B  ");
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
            public VA3811B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA3811B_LOCALIZA_ABEND_1();
            public class VA3811B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA3811B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA3811B_LOCALIZA_ABEND_2();
            public class VA3811B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VA3811B_V1AGENCEF V1AGENCEF { get; set; } = new VA3811B_V1AGENCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETDEB_FILE_NAME_P, string RVA3811B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                RVA3811B.SetFile(RVA3811B_FILE_NAME_P);

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
            /*" -238- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -241- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -244- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -247- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -248- DISPLAY 'PROGRAMA EM EXECUCAO VA3811B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO VA3811B   ");

            /*" -249- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -250- DISPLAY 'VERSAO V.02 FGV-2   08/02/2017 ' . */
            _.Display($"VERSAO V.02 FGV-2   08/02/2017 ");

            /*" -251- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -253- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -254- OPEN INPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -256- OPEN OUTPUT RVA3811B. */
            RVA3811B.Open(ARQ_RVA3811B);

            /*" -258- MOVE ZEROS TO TAB-FILIAL. */
            _.Move(0, WORK_AREA.TAB_FILIAL);

            /*" -260- PERFORM M-3000-00-DECLARE-V1AGENCEF THRU 3000-FIM. */

            M_3000_00_DECLARE_V1AGENCEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/


            /*" -262- PERFORM 3100-00-FETCH-V1AGENCEF THRU 3100-FIM. */

            M_3100_00_FETCH_V1AGENCEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/


            /*" -263- IF WFIM-V1AGENCEF NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1AGENCEF.IsEmpty())
            {

                /*" -264- DISPLAY '0000 - PROBLEMA NO FETCH DA V1AGENCIACEF' */
                _.Display($"0000 - PROBLEMA NO FETCH DA V1AGENCIACEF");

                /*" -266- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -270- PERFORM 3200-00-CARREGA-FILIAL THRU 3200-FIM UNTIL WFIM-V1AGENCEF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V1AGENCEF == "S"))
            {

                M_3200_00_CARREGA_FILIAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_FIM*/

            }

            /*" -270- PERFORM 0001-INICIO-PROCESSO. */

            M_0001_INICIO_PROCESSO(true);

        }

        [StopWatch]
        /*" M-0001-INICIO-PROCESSO */
        private void M_0001_INICIO_PROCESSO(bool isPerform = false)
        {
            /*" -277- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -278- DISPLAY '*** VA3811B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA3811B *** MOVIMENTO RETORNO VAZIO");

                    /*" -282- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -283- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -284- DISPLAY '*** VA3811B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA3811B *** FITA SEM MOVIMENTO ");

                    /*" -286- GO TO 0001-FIM-NORMAL. */

                    M_0001_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -288- DISPLAY '*** VA3811B *** PROCESSANDO ...' . */
            _.Display($"*** VA3811B *** PROCESSANDO ...");

            /*" -290- PERFORM 0020-PROCESSA THRU 0020-FIM UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                M_0020_PROCESSA(true);

                M_0020_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

            }

        }

        [StopWatch]
        /*" M-0001-FIM-NORMAL */
        private void M_0001_FIM_NORMAL(bool isPerform = false)
        {
            /*" -295- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -300- CLOSE RETDEB RVA3811B. */
            RETDEB.Close();
            RVA3811B.Close();

            /*" -301- DISPLAY '*** VA3811B *** TERMINO NORMAL' . */
            _.Display($"*** VA3811B *** TERMINO NORMAL");

            /*" -303- DISPLAY ' ' . */
            _.Display($" ");

            /*" -305- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -305- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0001-FIM-ANORMAL */
        private void M_0001_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -310- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -315- CLOSE RETDEB RVA3811B. */
            RETDEB.Close();
            RVA3811B.Close();

            /*" -317- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -317- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0020-PROCESSA */
        private void M_0020_PROCESSA(bool isPerform = false)
        {
            /*" -326- ADD 1 TO AC-LIDOS ON-COUNTER. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.ON_COUNTER.Value = WORK_AREA.ON_COUNTER + 1;

            /*" -328- IF AC-LIDOS EQUAL 1 OR ON-COUNTER EQUAL ON-INTERVAL */

            if (WORK_AREA.AC_LIDOS == 1 || WORK_AREA.ON_COUNTER == WORK_AREA.ON_INTERVAL)
            {

                /*" -329- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -330- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();

                /*" -332- MOVE 0 TO ON-COUNTER. */
                _.Move(0, WORK_AREA.ON_COUNTER);
            }


            /*" -332- PERFORM 1214-BUSCA-FONTE THRU 1214-FIM. */

            M_1214_BUSCA_FONTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1214_FIM*/


        }

        [StopWatch]
        /*" M-0020-NEXT */
        private void M_0020_NEXT(bool isPerform = false)
        {
            /*" -336- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -336- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);
                _.Move(RETDEB.Value, RET_TRAILLER);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0020_FIM*/

        [StopWatch]
        /*" M-1214-BUSCA-FONTE */
        private void M_1214_BUSCA_FONTE(bool isPerform = false)
        {
            /*" -344- MOVE '1214-BUSCA-FONTE   ' TO PARAGRAFO. */
            _.Move("1214-BUSCA-FONTE   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -346- MOVE 'SELECT V0AGENCIACEF' TO COMANDO. */
            _.Move("SELECT V0AGENCIACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -348- MOVE RF-AGENCIA TO WHOST-AGE-VENDA */
            _.Move(RET_CADASTRAMENTO.RF_AGENCIA, WHOST_AGE_VENDA);

            /*" -349- IF WHOST-AGE-VENDA = TAB-AGENCIA (WHOST-AGE-VENDA) */

            if (WHOST_AGE_VENDA == WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA].TAB_AGENCIA)
            {

                /*" -350- IF TAB-FONTE (WHOST-AGE-VENDA) EQUAL 10 */

                if (WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA].TAB_FONTE == 10)
                {

                    /*" -351- DISPLAY '*** A FONTE DA AGENCIA NAO E PERMITIDA ***' */
                    _.Display($"*** A FONTE DA AGENCIA NAO E PERMITIDA ***");

                    /*" -352- DISPLAY 'AGENCIA ... ' TAB-AGENCIA (WHOST-AGE-VENDA) */
                    _.Display($"AGENCIA ... {WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA]}");

                    /*" -353- DISPLAY 'FONTE   ... ' TAB-FONTE (WHOST-AGE-VENDA) */
                    _.Display($"FONTE   ... {WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA]}");

                    /*" -354- DISPLAY '  ' */
                    _.Display($"  ");

                    /*" -355- MOVE 'A FONTE DA AGENCIA NAO E PERMITIDA' TO ARQ-MENSAGEM */
                    _.Move("A FONTE DA AGENCIA NAO E PERMITIDA", ARQ_RVA3811B.ARQ_MENSAGEM);

                    /*" -356- MOVE TAB-AGENCIA(WHOST-AGE-VENDA) TO ARQ-AGENCIA */
                    _.Move(WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA].TAB_AGENCIA, ARQ_RVA3811B.ARQ_AGENCIA);

                    /*" -357- MOVE TAB-FONTE (WHOST-AGE-VENDA) TO ARQ-FONTE */
                    _.Move(WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA].TAB_FONTE, ARQ_RVA3811B.ARQ_FONTE);

                    /*" -358- WRITE ARQ-RVA3811B */
                    RVA3811B.Write(ARQ_RVA3811B.GetMoveValues().ToString());

                    /*" -360- GO TO 1214-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1214_FIM*/ //GOTO
                    return;
                }

            }


            /*" -361- IF WHOST-AGE-VENDA NOT = TAB-AGENCIA (WHOST-AGE-VENDA) */

            if (WHOST_AGE_VENDA != WORK_AREA.TAB_FILIAL.FILLER_7[WHOST_AGE_VENDA].TAB_AGENCIA)
            {

                /*" -362- DISPLAY '*** A AGENCIA NAO FOI IDENTIFICADA ***' */
                _.Display($"*** A AGENCIA NAO FOI IDENTIFICADA ***");

                /*" -363- DISPLAY 'AGENCIA   ... ' WHOST-AGE-VENDA */
                _.Display($"AGENCIA   ... {WHOST_AGE_VENDA}");

                /*" -364- DISPLAY '  ' */
                _.Display($"  ");

                /*" -365- MOVE 'A AGENCIA NAO FOI IDENTIFICADA ' TO ARQ-MENSAGEM */
                _.Move("A AGENCIA NAO FOI IDENTIFICADA ", ARQ_RVA3811B.ARQ_MENSAGEM);

                /*" -366- MOVE WHOST-AGE-VENDA TO ARQ-AGENCIA */
                _.Move(WHOST_AGE_VENDA, ARQ_RVA3811B.ARQ_AGENCIA);

                /*" -366- WRITE ARQ-RVA3811B. */
                RVA3811B.Write(ARQ_RVA3811B.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1214_FIM*/

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF */
        private void M_3000_00_DECLARE_V1AGENCEF(bool isPerform = false)
        {
            /*" -374- MOVE '3000-DECLA-V1AGENCEF   ' TO PARAGRAFO. */
            _.Move("3000-DECLA-V1AGENCEF   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -376- MOVE 'DECLARE V1AGENCIACEF   ' TO COMANDO. */
            _.Move("DECLARE V1AGENCIACEF   ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -386- PERFORM M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1 */

            M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1();

            /*" -388- PERFORM M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1 */

            M_3000_00_DECLARE_V1AGENCEF_DB_OPEN_1();

            /*" -391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -392- DISPLAY '3000 - PROBLEMAS DECLARE (V1AGENCEF) ..' */
                _.Display($"3000 - PROBLEMAS DECLARE (V1AGENCEF) ..");

                /*" -393- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -393- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-3000-00-DECLARE-V1AGENCEF-DB-DECLARE-1 */
        public void M_3000_00_DECLARE_V1AGENCEF_DB_DECLARE_1()
        {
            /*" -386- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.V1AGENCIACEF A, SEGUROS.V1MALHACEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            V1AGENCEF = new VA3811B_V1AGENCEF(false);
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
            /*" -388- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3000_FIM*/

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF */
        private void M_3100_00_FETCH_V1AGENCEF(bool isPerform = false)
        {
            /*" -401- MOVE '3100-FETCH-V1AGENCEF   ' TO PARAGRAFO. */
            _.Move("3100-FETCH-V1AGENCEF   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -403- MOVE 'FETCH   V1AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   V1AGENCIACEF   ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -406- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1 */

            M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1();

            /*" -409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -410- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -411- MOVE 'S' TO WFIM-V1AGENCEF */
                    _.Move("S", WORK_AREA.WFIM_V1AGENCEF);

                    /*" -411- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1 */

                    M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_1();

                    /*" -413- ELSE */
                }
                else
                {


                    /*" -413- PERFORM M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2 */

                    M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2();

                    /*" -415- DISPLAY '3100 - (PROBLEMAS NO FETCH V1AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH V1AGENCEF) ..");

                    /*" -416- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -417- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -418- ELSE */
                }

            }
            else
            {


                /*" -418- ADD 1 TO AC-L-V1AGENCEF. */
                WORK_AREA.AC_L_V1AGENCEF.Value = WORK_AREA.AC_L_V1AGENCEF + 1;
            }


        }

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-FETCH-1 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_FETCH_1()
        {
            /*" -406- EXEC SQL FETCH V1AGENCEF INTO :V1ACEF-COD-AGENCIA, :V1MCEF-COD-FONTE END-EXEC. */

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
            /*" -411- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/

        [StopWatch]
        /*" M-3100-00-FETCH-V1AGENCEF-DB-CLOSE-2 */
        public void M_3100_00_FETCH_V1AGENCEF_DB_CLOSE_2()
        {
            /*" -413- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" M-3200-00-CARREGA-FILIAL */
        private void M_3200_00_CARREGA_FILIAL(bool isPerform = false)
        {
            /*" -427- MOVE '3200-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("3200-CARREGA-FILIAL    ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -429- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -431- MOVE V1ACEF-COD-AGENCIA TO TAB-AGENCIA (V1ACEF-COD-AGENCIA) */
            _.Move(V1ACEF_COD_AGENCIA, WORK_AREA.TAB_FILIAL.FILLER_7[V1ACEF_COD_AGENCIA].TAB_AGENCIA);

            /*" -434- MOVE V1MCEF-COD-FONTE TO TAB-FONTE (V1ACEF-COD-AGENCIA) */
            _.Move(V1MCEF_COD_FONTE, WORK_AREA.TAB_FILIAL.FILLER_7[V1ACEF_COD_AGENCIA].TAB_FONTE);

            /*" -434- PERFORM 3100-00-FETCH-V1AGENCEF THRU 3100-FIM. */

            M_3100_00_FETCH_V1AGENCEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3100_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_3200_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -445- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -446- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -447- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -448- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -449- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -451- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -454- CLOSE RETDEB RVA3811B. */
            RETDEB.Close();
            RVA3811B.Close();

            /*" -457- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -461- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -461- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}