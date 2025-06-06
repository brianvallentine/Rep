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
using Sias.VidaAzul.DB2.VA0860B;

namespace Code
{
    public class VA0860B
    {
        public bool IsCall { get; set; }

        public VA0860B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ VA                                  *      */
        /*"      *   PROGRAMA ............... VA0860B                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS ................. 45.206                              *      */
        /*"      *   PROGRAMADOR ............ FAST COMPUTER (TERCIO FREITAS)      *      */
        /*"      *   DATA CODIFICACAO ....... AGOSTO / 2010                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: GERAR RELATORIOS PARA ACOMPANHAMENTO DE COBRANCAS DE *      */
        /*"      *           PREMIOS EM DEBITO EM CONTA                           *      */
        /*"      *                                                                *      */
        /*"      *-- - - - - - - - - -  ALTERACOES - - - - - - - - - - - - - - - -*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   FGV-2                                          *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA PERMITIR PARALELISMO   *      */
        /*"      *                 DOS JOBS JPVAD00 E JPCSD01.                    *      */
        /*"      *   EM 08/02/2017 - CLAUDETE RADEL                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 48.734                                       *      */
        /*"      *             - AJUSTE NO RELATORIO, RETIRAR OS CAMPOS REFERENTE *      */
        /*"      *               AO NUMERO DA CONTA DO CLIENTE.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/10/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 46.929                                       *      */
        /*"      *               - AJUSTE NO ACESSO A TABELA SEGUROS.HIST_LANC_CTA*      */
        /*"      *                                                                *      */
        /*"      *   EM 30/08/2010 - MARCO PAIVA    (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
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
        public FileBasis _AVA0860B { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis AVA0860B
        {
            get
            {
                _.Move(REG_AVA0860B, _AVA0860B); VarBasis.RedefinePassValue(REG_AVA0860B, _AVA0860B, REG_AVA0860B); return _AVA0860B;
            }
        }
        /*"01         RETDEB-RECORD       PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01         RET-HEADER.*/
        public VA0860B_RET_HEADER RET_HEADER { get; set; } = new VA0860B_RET_HEADER();
        public class VA0860B_RET_HEADER : VarBasis
        {
            /*"    05   RA-COD-REG          PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RA-COD-REMESSA      PIC 9(001).*/
            public IntBasis RA_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05   RA-COD-CONVENIO     PIC 9(004).*/
            public IntBasis RA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05   FILLER              PIC X(016).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
            /*"    05   RA-NOME-EMPRESA     PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05   RA-COD-BANCO        PIC 9(003).*/
            public IntBasis RA_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05   RA-NOME-BANCO       PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05   RA-DATA-GERACAO.*/
            public VA0860B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA0860B_RA_DATA_GERACAO();
            public class VA0860B_RA_DATA_GERACAO : VarBasis
            {
                /*"     10  RA-AA-GER           PIC X(004).*/
                public StringBasis RA_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"     10  RA-MM-GER           PIC X(002).*/
                public StringBasis RA_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"     10  RA-DD-GER           PIC X(002).*/
                public StringBasis RA_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05   RA-NSA              PIC 9(006).*/
            }
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05   RA-VERSAO-LAYOUT    PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05   RA-SERVICO          PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05   RA-RESERVADO        PIC X(052).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01         RET-CADASTRAMENTO.*/
        }
        public VA0860B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA0860B_RET_CADASTRAMENTO();
        public class VA0860B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05   RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RF-IDENT-CLI-EMPRESA.*/
            public VA0860B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA0860B_RF_IDENT_CLI_EMPRESA();
            public class VA0860B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10  RF-IDENTIF-CLI      PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  RF-IDENTIF-CLI-R REDEFINES           RF-IDENTIF-CLI.*/
                private _REDEF_VA0860B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VA0860B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VA0860B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA0860B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"           15 FILLER           PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10  RF-IDENTIF-NSA      PIC 9(005).*/

                    public _REDEF_VA0860B_RF_IDENTIF_CLI_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_IDENTIF_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  FILLER              PIC X(005).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGECTADEB            PIC 9(004).*/
            }
            public IntBasis RF_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA0860B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA0860B_RF_IDENT_CLI_BANCO();
            public class VA0860B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10  RF-COD-OPRCTADEB    PIC 9(004).*/
                public IntBasis RF_COD_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-NUM-NUMCTADEB    PIC 9(012).*/
                public IntBasis RF_NUM_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10  RF-DIG-NUMCTADEB    PIC 9(001).*/
                public IntBasis RF_DIG_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  FILLER              PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VA0860B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA0860B_RF_DATA_REAL();
            public class VA0860B_RF_DATA_REAL : VarBasis
            {
                /*"       10  RF-ANO-REAL         PIC 9(004).*/
                public IntBasis RF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-MES-REAL         PIC 9(002).*/
                public IntBasis RF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  RF-DIA-REAL         PIC 9(002).*/
                public IntBasis RF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VLPRMTOT             PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO          PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA0860B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA0860B_RF_USO_EMPRESA();
            public class VA0860B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10  RF-NSA              PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NSL              PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  FILLER              PIC X(047).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO1           PIC X(008).*/
            }
            public StringBasis RF_RESERVADO1 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 RF-NSAS2                PIC 9(005).*/
            public IntBasis RF_NSAS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 RF-RESERVADO2           PIC X(004).*/
            public StringBasis RF_RESERVADO2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05 RF-COD-MOVIMENTO        PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA0860B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA0860B_RET_TRAILLER();
        public class VA0860B_RET_TRAILLER : VarBasis
        {
            /*"    05 RZ-COD-REG              PIC X(001).*/
            public StringBasis RZ_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROS       PIC 9(006).*/
            public IntBasis RZ_QTDE_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RZ-TOT-DEB-CRUZ         PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_DEB_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-TOT-CRED-CRUZ        PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_CRED_CRUZ { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-RESERVADO            PIC X(109).*/
            public StringBasis RZ_RESERVADO { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01            REG-AVA0860B        PIC X(250).*/
        }
        public StringBasis REG_AVA0860B { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  WORK-AREA.*/
        public VA0860B_WORK_AREA WORK_AREA { get; set; } = new VA0860B_WORK_AREA();
        public class VA0860B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 AC-CONTA                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      DATA-SQL.*/
            public VA0860B_DATA_SQL DATA_SQL { get; set; } = new VA0860B_DATA_SQL();
            public class VA0860B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      DATA-DET.*/
            }
            public VA0860B_DATA_DET DATA_DET { get; set; } = new VA0860B_DATA_DET();
            public class VA0860B_DATA_DET : VarBasis
            {
                /*"      10    DIA-DET                  PIC  9(002).*/
                public IntBasis DIA_DET { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    MES-DET                  PIC  9(002).*/
                public IntBasis MES_DET { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10    ANO-DET                  PIC  9(004).*/
                public IntBasis ANO_DET { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05 WS-NSAS                       PIC  9(009).*/
            }
            public IntBasis WS_NSAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 WS-TIME                       PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 WS-DATA-INV.*/
            public VA0860B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA0860B_WS_DATA_INV();
            public class VA0860B_WS_DATA_INV : VarBasis
            {
                /*"      10 WS-ANO-INV                  PIC  9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-MES-INV                  PIC  9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 WS-DIA-INV                  PIC  9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/
            }
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-CODCONV               PIC  9(004).*/
            public IntBasis WS_CODCONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WS-REGISTROS              PIC  9(9)      VALUE  0.*/
            public IntBasis WS_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 AUX-NSAC                  PIC  9(005).*/
            public IntBasis AUX_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 AUX-CONVENIO              PIC  9(004).*/
            public IntBasis AUX_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 AUX-VLPRMTOT              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis AUX_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 AUX-VLDESPES              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis AUX_VLDESPES { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-TEM-REGISTRO           PIC  X(001) VALUE SPACES.*/
            public StringBasis WS_TEM_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA0860B_WABEND WABEND { get; set; } = new VA0860B_WABEND();
            public class VA0860B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0860B  '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0860B  ");
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
            public VA0860B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0860B_LOCALIZA_ABEND_1();
            public class VA0860B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0860B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0860B_LOCALIZA_ABEND_2();
            public class VA0860B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  AUX-TABELAS.*/
            }
        }
        public VA0860B_AUX_TABELAS AUX_TABELAS { get; set; } = new VA0860B_AUX_TABELAS();
        public class VA0860B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public VA0860B_WTABG_VALORES WTABG_VALORES { get; set; } = new VA0860B_WTABG_VALORES();
            public class VA0860B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS       500   TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<VA0860B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<VA0860B_WTABG_OCORREPRD>(500);
                public class VA0860B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<VA0860B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<VA0860B_WTABG_OCORRETIP>(003);
                    public class VA0860B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<VA0860B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<VA0860B_WTABG_OCORRESIT>(002);
                        public class VA0860B_WTABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                            public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                            public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"01    WS-HORAS.*/
                        }
                    }
                }
            }
        }
        public VA0860B_WS_HORAS WS_HORAS { get; set; } = new VA0860B_WS_HORAS();
        public class VA0860B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA0860B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA0860B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA0860B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA0860B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA0860B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA0860B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA0860B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA0860B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA0860B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VA0860B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VA0860B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA0860B_TOTAIS_ROT();
        public class VA0860B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VA0860B_FILLER_17> FILLER_17 { get; set; } = new ListBasis<VA0860B_FILLER_17>(50);
            public class VA0860B_FILLER_17 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  SAIDA.*/
            }
        }
        public VA0860B_SAIDA SAIDA { get; set; } = new VA0860B_SAIDA();
        public class VA0860B_SAIDA : VarBasis
        {
            /*"    05        LD00.*/
            public VA0860B_LD00 LD00 { get; set; } = new VA0860B_LD00();
            public class VA0860B_LD00 : VarBasis
            {
                /*"      10      FILLER              PIC X(07)   VALUE 'VA0860B'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"VA0860B");
                /*"      10      FILLER              PIC X(03)   VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(57)  VALUE      'RELATORIO ACOMPANHAMENTO DE COBRANCA DE PREMIOS FORMA DE'*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "57", "X(57)"), @"RELATORIO ACOMPANHAMENTO DE COBRANCA DE PREMIOS FORMA DE");
                /*"      10      FILLER              PIC X(27)  VALUE      'PAGAMENTO: DEBITO EM CONTA.'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"PAGAMENTO: DEBITO EM CONTA.");
                /*"      10      FILLER              PIC X(31)  VALUE      ' CODIGO DO ARQUIVO DE COBRANCA:'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @" CODIGO DO ARQUIVO DE COBRANCA:");
                /*"      10      FILLER              PIC X(01)   VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"      10      LD00-NSA            PIC 99999.*/
                public IntBasis LD00_NSA { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"      10      FILLER              PIC X(05)   VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"      10      FILLER              PIC X(08)   VALUE             ' DATA : '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" DATA : ");
                /*"      10      LD00-DATAINI        PIC X(10).*/
                public StringBasis LD00_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      FILLER              PIC X(02)   VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @";");
                /*"    05        LD00-1.*/
            }
            public VA0860B_LD00_1 LD00_1 { get; set; } = new VA0860B_LD00_1();
            public class VA0860B_LD00_1 : VarBasis
            {
                /*"      10      FILLER              PIC X(12)  VALUE             'NOME PRODUTO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NOME PRODUTO");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(11)  VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(13)  VALUE             'NOME SEGURADO'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME SEGURADO");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)  VALUE             'CPF'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(23)  VALUE             'SEQUENCIAL DE PARCELAS'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"SEQUENCIAL DE PARCELAS");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(15)  VALUE             'DATA VENCIMENTO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA VENCIMENTO");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(05)  VALUE             'VALOR'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"VALOR");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(31)  VALUE             'SITUACAO DE RETORNO DA COBRANCA'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"SITUACAO DE RETORNO DA COBRANCA");
                /*"      10      FILLER              PIC X(01)  VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05        LD01.*/
            }
            public VA0860B_LD01 LD01 { get; set; } = new VA0860B_LD01();
            public class VA0860B_LD01 : VarBasis
            {
                /*"      10      LD01-NOMPRODU       PIC X(40)   VALUE SPACES.*/
                public StringBasis LD01_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10      LD01-FIL1           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NRCERTIF       PIC 9(15).*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD01-FIL2           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NOME-RAZAO     PIC X(40).*/
                public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD01-FIL3           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CGCCPF         PIC 9(15).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD01-FIL4           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NRPARCEL       PIC 99999.*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"      10      LD01-FIL6           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DTVENCTO       PIC X(10).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      LD01-FIL7           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-VALOR          PIC ZZZZZZZZZZZZ9,99.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9V99."), 2);
                /*"      10      LD01-FIL8           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-MENSAGEM       PIC X(60)   VALUE SPACES.*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"");
                /*"      10      LD01-FIL9           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETDEB_FILE_NAME_P, string AVA0860B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                AVA0860B.SetFile(AVA0860B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -388- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -391- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -394- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -397- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -398- DISPLAY 'PROGRAMA EM EXECUCAO VA0860B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA0860B  ");

            /*" -399- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -404- DISPLAY 'VERSAO V.04 FGV-2  08/02/2016 ' */
            _.Display($"VERSAO V.04 FGV-2  08/02/2016 ");

            /*" -405- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -407- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -408- OPEN INPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -410- OPEN OUTPUT AVA0860B. */
            AVA0860B.Open(REG_AVA0860B);

            /*" -412- PERFORM R0050-00-SELECT-SISTEMAS */

            R0050_00_SELECT_SISTEMAS_SECTION();

            /*" -413- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -414- DISPLAY '*** VA0813B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA0813B *** MOVIMENTO RETORNO VAZIO");

                    /*" -416- GO TO R0001-00-FIM-NORMAL. */

                    R0001_00_FIM_NORMAL(); //GOTO
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
            /*" -417- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -418- DISPLAY '*** VA0860B *** FITA SEM HEADER' */
                _.Display($"*** VA0860B *** FITA SEM HEADER");

                /*" -419- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -421- END-IF. */
            }


            /*" -422- MOVE RA-COD-CONVENIO TO WS-CODCONV. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_CODCONV);

            /*" -424- MOVE RA-NSA TO LD00-NSA. */
            _.Move(RET_HEADER.RA_NSA, SAIDA.LD00.LD00_NSA);

            /*" -425- WRITE REG-AVA0860B FROM LD00. */
            _.Move(SAIDA.LD00.GetMoveValues(), REG_AVA0860B);

            AVA0860B.Write(REG_AVA0860B.GetMoveValues().ToString());

            /*" -429- WRITE REG-AVA0860B FROM LD00-1. */
            _.Move(SAIDA.LD00_1.GetMoveValues(), REG_AVA0860B);

            AVA0860B.Write(REG_AVA0860B.GetMoveValues().ToString());

            /*" -431- IF WS-CODCONV NOT EQUAL 6081 AND 6088 AND 6132 AND 6090 AND 6153 */

            if (!WORK_AREA.WS_CODCONV.In("6081", "6088", "6132", "6090", "6153"))
            {

                /*" -432- GO TO R0001-00-FIM-NORMAL */

                R0001_00_FIM_NORMAL(); //GOTO
                return;

                /*" -434- END-IF. */
            }


            /*" -435- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -436- DISPLAY '*** VA0860B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA0860B *** FITA SEM MOVIMENTO ");

                    /*" -438- GO TO R0001-00-FIM-NORMAL. */

                    R0001_00_FIM_NORMAL(); //GOTO
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
            /*" -439- IF RA-COD-REG NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADER.RA_COD_REG.In("F", "Z"))
            {

                /*" -440- DISPLAY 'COD REGISTRO NAO ESPERADO' */
                _.Display($"COD REGISTRO NAO ESPERADO");

                /*" -441- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -443- END-IF. */
            }


            /*" -444- IF RA-COD-REG EQUAL 'Z' */

            if (RET_HEADER.RA_COD_REG == "Z")
            {

                /*" -445- DISPLAY 'NAO HA RETORNO DE DEBITO' */
                _.Display($"NAO HA RETORNO DE DEBITO");

                /*" -446- GO TO R0001-00-FIM-NORMAL */

                R0001_00_FIM_NORMAL(); //GOTO
                return;

                /*" -448- END-IF. */
            }


            /*" -449- DISPLAY '*** VA0860B *** PROCESSANDO ...' . */
            _.Display($"*** VA0860B *** PROCESSANDO ...");

            /*" -451- DISPLAY '*** CONVENIO ' WS-CODCONV. */
            _.Display($"*** CONVENIO {WORK_AREA.WS_CODCONV}");

            /*" -455- PERFORM R0200-00-PROCESSA UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                R0200_00_PROCESSA_SECTION();
            }

            /*" -456- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -457- DISPLAY '*** VA0860B *** FITA SEM TRAILLER' */
                _.Display($"*** VA0860B *** FITA SEM TRAILLER");

                /*" -458- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -459- ELSE */
            }
            else
            {


                /*" -460- IF RA-COD-REG NOT EQUAL 'Z' */

                if (RET_HEADER.RA_COD_REG != "Z")
                {

                    /*" -461- DISPLAY 'COD REGISTRO NAO ESPERADO' */
                    _.Display($"COD REGISTRO NAO ESPERADO");

                    /*" -462- GO TO R0001-00-FIM-ANORMAL */

                    R0001_00_FIM_ANORMAL(); //GOTO
                    return;

                    /*" -463- END-IF */
                }


                /*" -465- END-IF. */
            }


            /*" -466- DISPLAY '      *** VA0860B ***      ' */
            _.Display($"      *** VA0860B ***      ");

            /*" -466- DISPLAY ' LANCAMENTOS RETORNADOS  - ' WS-REGISTROS. */
            _.Display($" LANCAMENTOS RETORNADOS  - {WORK_AREA.WS_REGISTROS}");

            /*" -0- FLUXCONTROL_PERFORM R0001_00_FIM_NORMAL */

            R0001_00_FIM_NORMAL();

        }

        [StopWatch]
        /*" R0001-00-FIM-NORMAL */
        private void R0001_00_FIM_NORMAL(bool isPerform = false)
        {
            /*" -470- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -473- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -475- CLOSE AVA0860B. */
            AVA0860B.Close();

            /*" -476- DISPLAY '*** VA0860B *** TERMINO NORMAL' . */
            _.Display($"*** VA0860B *** TERMINO NORMAL");

            /*" -478- DISPLAY ' ' . */
            _.Display($" ");

            /*" -480- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -480- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0001-00-FIM-ANORMAL */
        private void R0001_00_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -485- DISPLAY '*** VA0860B *** PROCESSAMENTO TERMINOU COM ERRO' . */
            _.Display($"*** VA0860B *** PROCESSAMENTO TERMINOU COM ERRO");

            /*" -487- DISPLAY '*** VA0860B *** VIDE ARQUIVO RETERR COM MSG' . */
            _.Display($"*** VA0860B *** VIDE ARQUIVO RETERR COM MSG");

            /*" -487- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -490- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -492- CLOSE AVA0860B. */
            AVA0860B.Close();

            /*" -494- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -494- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECT-SISTEMAS-SECTION */
        private void R0050_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -508- MOVE 'R0050-00-SELECT-SISTEMAS' TO PARAGRAFO. */
            _.Move("R0050-00-SELECT-SISTEMAS", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -514- PERFORM R0050_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0050_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -517- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -518- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -519- DISPLAY 'VA0860B-SISTEMAS = VA NAO ESTA CADASTRADO' */
                    _.Display($"VA0860B-SISTEMAS = VA NAO ESTA CADASTRADO");

                    /*" -520- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                    /*" -521- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -522- ELSE */
                }
                else
                {


                    /*" -523- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

                    /*" -524- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -525- END-IF */
                }


                /*" -527- END-IF. */
            }


            /*" -528- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), SAIDA.LD00.LD00_DATAINI, 7, 4);

            /*" -529- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", SAIDA.LD00.LD00_DATAINI, 3, 1);

            /*" -530- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), SAIDA.LD00.LD00_DATAINI, 4, 2);

            /*" -531- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", SAIDA.LD00.LD00_DATAINI, 6, 1);

            /*" -531- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), SAIDA.LD00.LD00_DATAINI, 1, 2);

        }

        [StopWatch]
        /*" R0050-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0050_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -514- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC. */

            var r0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0050_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSA-SECTION */
        private void R0200_00_PROCESSA_SECTION()
        {
            /*" -543- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -544- ADD 1 TO AC-LIDOS AC-CONTA. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.AC_CONTA.Value = WORK_AREA.AC_CONTA + 1;

            /*" -545- IF AC-CONTA > 999 */

            if (WORK_AREA.AC_CONTA > 999)
            {

                /*" -546- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WORK_AREA.AC_CONTA);

                /*" -547- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -549- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME. */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();
            }


            /*" -550- IF RF-IDENTIF-CLI-R NUMERIC */

            if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI_R.IsNumeric())
            {

                /*" -551- IF RF-IDENTIF-CLI > 0 */

                if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI > 0)
                {

                    /*" -552- PERFORM R0300-00-ACESSO-DADOS */

                    R0300_00_ACESSO_DADOS_SECTION();

                    /*" -553- IF WS-TEM-REGISTRO EQUAL 'N' */

                    if (WORK_AREA.WS_TEM_REGISTRO == "N")
                    {

                        /*" -554- GO TO R0200-00-NEXT */

                        R0200_00_NEXT(); //GOTO
                        return;

                        /*" -555- END-IF */
                    }


                    /*" -556- ELSE */
                }
                else
                {


                    /*" -557- GO TO R0200-00-NEXT */

                    R0200_00_NEXT(); //GOTO
                    return;

                    /*" -558- END-IF */
                }


                /*" -559- ELSE */
            }
            else
            {


                /*" -560- GO TO R0200-00-NEXT */

                R0200_00_NEXT(); //GOTO
                return;

                /*" -562- END-IF. */
            }


            /*" -562- PERFORM R0400-00-GRAVA-SAIDA. */

            R0400_00_GRAVA_SAIDA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0200_00_NEXT */

            R0200_00_NEXT();

        }

        [StopWatch]
        /*" R0200-00-NEXT */
        private void R0200_00_NEXT(bool isPerform = false)
        {
            /*" -567- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -568- MOVE 1 TO WS-EOF */
                    _.Move(1, WORK_AREA.WS_EOF);

                    /*" -570- GO TO R0020-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/ //GOTO
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
            /*" -570- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-ACESSO-DADOS-SECTION */
        private void R0300_00_ACESSO_DADOS_SECTION()
        {
            /*" -582- MOVE 'R0300-00-ACESSO-DADOS' TO PARAGRAFO. */
            _.Move("R0300-00-ACESSO-DADOS", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -584- MOVE 'S' TO WS-TEM-REGISTRO. */
            _.Move("S", WORK_AREA.WS_TEM_REGISTRO);

            /*" -586- MOVE RF-IDENTIF-CLI TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -596- PERFORM R0300_00_ACESSO_DADOS_DB_SELECT_1 */

            R0300_00_ACESSO_DADOS_DB_SELECT_1();

            /*" -599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -600- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -601- MOVE 'N' TO WS-TEM-REGISTRO */
                    _.Move("N", WORK_AREA.WS_TEM_REGISTRO);

                    /*" -602- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -603- ELSE */
                }
                else
                {


                    /*" -604- DISPLAY 'VA0860B-PROBLEMAS NO ACESSO PROPOSTA_VA ' */
                    _.Display($"VA0860B-PROBLEMAS NO ACESSO PROPOSTA_VA ");

                    /*" -605- DISPLAY 'NUM_CERTIFICADO - ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -606- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -607- END-IF */
                }


                /*" -609- END-IF. */
            }


            /*" -610- IF RF-NSAS2 EQUAL ZEROS */

            if (RET_CADASTRAMENTO.RF_NSAS2 == 00)
            {

                /*" -612- MOVE RF-NSA TO HISLANCT-NSAS */
                _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

                /*" -613- ADD 26000 TO HISLANCT-NSAS */
                HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.Value = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS + 26000;

                /*" -614- ELSE */
            }
            else
            {


                /*" -615- MOVE RF-NSAS2 TO HISLANCT-NSAS */
                _.Move(RET_CADASTRAMENTO.RF_NSAS2, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

                /*" -617- END-IF. */
            }


            /*" -619- MOVE RF-NSL TO HISLANCT-NSL */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL);

            /*" -627- PERFORM R0300_00_ACESSO_DADOS_DB_SELECT_2 */

            R0300_00_ACESSO_DADOS_DB_SELECT_2();

            /*" -631- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -632- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -633- MOVE 'N' TO WS-TEM-REGISTRO */
                    _.Move("N", WORK_AREA.WS_TEM_REGISTRO);

                    /*" -634- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -635- ELSE */
                }
                else
                {


                    /*" -636- DISPLAY 'VA0860B-PROBLEMAS NO ACESSO HIST_LANC_CTA' */
                    _.Display($"VA0860B-PROBLEMAS NO ACESSO HIST_LANC_CTA");

                    /*" -637- DISPLAY 'NUM_CERTIFICADO - ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"NUM_CERTIFICADO - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -638- DISPLAY 'NSAS            - ' HISLANCT-NSAS */
                    _.Display($"NSAS            - {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS}");

                    /*" -639- DISPLAY 'NSL             - ' HISLANCT-NSL */
                    _.Display($"NSL             - {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL}");

                    /*" -640- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -641- END-IF */
                }


                /*" -643- END-IF. */
            }


            /*" -649- PERFORM R0300_00_ACESSO_DADOS_DB_SELECT_3 */

            R0300_00_ACESSO_DADOS_DB_SELECT_3();

            /*" -652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -653- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -654- MOVE 'N' TO WS-TEM-REGISTRO */
                    _.Move("N", WORK_AREA.WS_TEM_REGISTRO);

                    /*" -655- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -656- ELSE */
                }
                else
                {


                    /*" -657- DISPLAY 'VA0860B - PROBLEMAS NO ACESSO PRODUTO ' */
                    _.Display($"VA0860B - PROBLEMAS NO ACESSO PRODUTO ");

                    /*" -658- DISPLAY 'COD-PRODUTO - ' PROPOVA-COD-PRODUTO */
                    _.Display($"COD-PRODUTO - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO}");

                    /*" -659- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -660- END-IF */
                }


                /*" -662- END-IF. */
            }


            /*" -670- PERFORM R0300_00_ACESSO_DADOS_DB_SELECT_4 */

            R0300_00_ACESSO_DADOS_DB_SELECT_4();

            /*" -673- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -674- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -675- MOVE 'N' TO WS-TEM-REGISTRO */
                    _.Move("N", WORK_AREA.WS_TEM_REGISTRO);

                    /*" -676- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -677- ELSE */
                }
                else
                {


                    /*" -678- DISPLAY 'VA0860B - PROBLEMAS NO ACESSO CLIENTES ' */
                    _.Display($"VA0860B - PROBLEMAS NO ACESSO CLIENTES ");

                    /*" -679- DISPLAY 'COD-CLIENTE - ' PROPOVA-COD-CLIENTE */
                    _.Display($"COD-CLIENTE - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                    /*" -680- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -681- END-IF */
                }


                /*" -681- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-ACESSO-DADOS-DB-SELECT-1 */
        public void R0300_00_ACESSO_DADOS_DB_SELECT_1()
        {
            /*" -596- EXEC SQL SELECT NUM_CERTIFICADO, COD_PRODUTO , COD_CLIENTE INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO , :PROPOVA-COD-CLIENTE FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0300_00_ACESSO_DADOS_DB_SELECT_1_Query1 = new R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0300_00_ACESSO_DADOS_DB_SELECT_1_Query1.Execute(r0300_00_ACESSO_DADOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-ACESSO-DADOS-DB-SELECT-2 */
        public void R0300_00_ACESSO_DADOS_DB_SELECT_2()
        {
            /*" -627- EXEC SQL SELECT NUM_PARCELA INTO :HISLANCT-NUM-PARCELA FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NSAS = :HISLANCT-NSAS AND NSL = :HISLANCT-NSL WITH UR END-EXEC. */

            var r0300_00_ACESSO_DADOS_DB_SELECT_2_Query1 = new R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                HISLANCT_NSAS = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.ToString(),
                HISLANCT_NSL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL.ToString(),
            };

            var executed_1 = R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1.Execute(r0300_00_ACESSO_DADOS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
            }


        }

        [StopWatch]
        /*" R0400-00-GRAVA-SAIDA-SECTION */
        private void R0400_00_GRAVA_SAIDA_SECTION()
        {
            /*" -693- MOVE 'R0400-00-GRAVA-SAIDA' TO PARAGRAFO. */
            _.Move("R0400-00-GRAVA-SAIDA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -709- MOVE ';' TO LD01-FIL1 LD01-FIL2 LD01-FIL3 LD01-FIL4 LD01-FIL6 LD01-FIL7 LD01-FIL8 LD01-FIL9. */
            _.Move(";", SAIDA.LD01.LD01_FIL1, SAIDA.LD01.LD01_FIL2, SAIDA.LD01.LD01_FIL3, SAIDA.LD01.LD01_FIL4, SAIDA.LD01.LD01_FIL6, SAIDA.LD01.LD01_FIL7, SAIDA.LD01.LD01_FIL8, SAIDA.LD01.LD01_FIL9);

            /*" -710- MOVE PRODUTO-DESCR-PRODUTO TO LD01-NOMPRODU. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, SAIDA.LD01.LD01_NOMPRODU);

            /*" -711- MOVE PROPOVA-NUM-CERTIFICADO TO LD01-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, SAIDA.LD01.LD01_NRCERTIF);

            /*" -712- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, SAIDA.LD01.LD01_NOME_RAZAO);

            /*" -719- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, SAIDA.LD01.LD01_CGCCPF);

            /*" -720- MOVE HISLANCT-NUM-PARCELA TO LD01-NRPARCEL. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA, SAIDA.LD01.LD01_NRPARCEL);

            /*" -722- MOVE RF-VLPRMTOT TO LD01-VALOR. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, SAIDA.LD01.LD01_VALOR);

            /*" -723- MOVE '00/00/0000' TO DATA-DET. */
            _.Move("00/00/0000", WORK_AREA.DATA_DET);

            /*" -724- MOVE RF-DIA-REAL TO DIA-DET. */
            _.Move(RET_CADASTRAMENTO.RF_DATA_REAL.RF_DIA_REAL, WORK_AREA.DATA_DET.DIA_DET);

            /*" -725- MOVE RF-MES-REAL TO MES-DET. */
            _.Move(RET_CADASTRAMENTO.RF_DATA_REAL.RF_MES_REAL, WORK_AREA.DATA_DET.MES_DET);

            /*" -726- MOVE RF-ANO-REAL TO ANO-DET. */
            _.Move(RET_CADASTRAMENTO.RF_DATA_REAL.RF_ANO_REAL, WORK_AREA.DATA_DET.ANO_DET);

            /*" -728- MOVE DATA-DET TO LD01-DTVENCTO. */
            _.Move(WORK_AREA.DATA_DET, SAIDA.LD01.LD01_DTVENCTO);

            /*" -729- IF RF-COD-RETORNO EQUAL 00 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 00)
            {

                /*" -730- MOVE 'DEBITO EFETUADO' TO LD01-MENSAGEM */
                _.Move("DEBITO EFETUADO", SAIDA.LD01.LD01_MENSAGEM);

                /*" -731- ELSE */
            }
            else
            {


                /*" -732- IF RF-COD-RETORNO EQUAL 01 */

                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 01)
                {

                    /*" -733- MOVE 'INSUFICIENCIA DE FUNDOS' TO LD01-MENSAGEM */
                    _.Move("INSUFICIENCIA DE FUNDOS", SAIDA.LD01.LD01_MENSAGEM);

                    /*" -734- ELSE */
                }
                else
                {


                    /*" -735- IF RF-COD-RETORNO EQUAL 02 */

                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 02)
                    {

                        /*" -736- MOVE 'CONTA NAO CADASTRADA' TO LD01-MENSAGEM */
                        _.Move("CONTA NAO CADASTRADA", SAIDA.LD01.LD01_MENSAGEM);

                        /*" -737- ELSE */
                    }
                    else
                    {


                        /*" -738- IF RF-COD-RETORNO EQUAL 04 */

                        if (RET_CADASTRAMENTO.RF_COD_RETORNO == 04)
                        {

                            /*" -739- MOVE 'OUTRAS RESTRICOES' TO LD01-MENSAGEM */
                            _.Move("OUTRAS RESTRICOES", SAIDA.LD01.LD01_MENSAGEM);

                            /*" -740- ELSE */
                        }
                        else
                        {


                            /*" -741- IF RF-COD-RETORNO EQUAL 10 */

                            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 10)
                            {

                                /*" -742- MOVE 'AGENCIA EM REGIME ENCERR' TO LD01-MENSAGEM */
                                _.Move("AGENCIA EM REGIME ENCERR", SAIDA.LD01.LD01_MENSAGEM);

                                /*" -743- ELSE */
                            }
                            else
                            {


                                /*" -744- IF RF-COD-RETORNO EQUAL 12 */

                                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 12)
                                {

                                    /*" -745- MOVE 'VALOR INVALIDO' TO LD01-MENSAGEM */
                                    _.Move("VALOR INVALIDO", SAIDA.LD01.LD01_MENSAGEM);

                                    /*" -746- ELSE */
                                }
                                else
                                {


                                    /*" -747- IF RF-COD-RETORNO EQUAL 14 */

                                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 14)
                                    {

                                        /*" -748- MOVE 'AGENCIA INVALIDA' TO LD01-MENSAGEM */
                                        _.Move("AGENCIA INVALIDA", SAIDA.LD01.LD01_MENSAGEM);

                                        /*" -749- ELSE */
                                    }
                                    else
                                    {


                                        /*" -750- IF RF-COD-RETORNO EQUAL 15 */

                                        if (RET_CADASTRAMENTO.RF_COD_RETORNO == 15)
                                        {

                                            /*" -751- MOVE 'DV DA CONTA INVALIDO' TO LD01-MENSAGEM */
                                            _.Move("DV DA CONTA INVALIDO", SAIDA.LD01.LD01_MENSAGEM);

                                            /*" -752- ELSE */
                                        }
                                        else
                                        {


                                            /*" -753- IF RF-COD-RETORNO EQUAL 30 */

                                            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 30)
                                            {

                                                /*" -754- MOVE 'SEM CONTRATO' TO LD01-MENSAGEM */
                                                _.Move("SEM CONTRATO", SAIDA.LD01.LD01_MENSAGEM);

                                                /*" -755- ELSE */
                                            }
                                            else
                                            {


                                                /*" -756- IF RF-COD-RETORNO EQUAL 96 */

                                                if (RET_CADASTRAMENTO.RF_COD_RETORNO == 96)
                                                {

                                                    /*" -757- MOVE 'VALOR ZERADO' TO LD01-MENSAGEM */
                                                    _.Move("VALOR ZERADO", SAIDA.LD01.LD01_MENSAGEM);

                                                    /*" -758- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -759- IF RF-COD-RETORNO EQUAL 97 */

                                                    if (RET_CADASTRAMENTO.RF_COD_RETORNO == 97)
                                                    {

                                                        /*" -761- MOVE 'CANCEL. P/LANC NAO ENCONT' TO LD01-MENSAGEM */
                                                        _.Move("CANCEL. P/LANC NAO ENCONT", SAIDA.LD01.LD01_MENSAGEM);

                                                        /*" -762- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -763- IF RF-COD-RETORNO EQUAL 98 */

                                                        if (RET_CADASTRAMENTO.RF_COD_RETORNO == 98)
                                                        {

                                                            /*" -765- MOVE 'CANCEL. P/LANC FORA DATA' TO LD01-MENSAGEM */
                                                            _.Move("CANCEL. P/LANC FORA DATA", SAIDA.LD01.LD01_MENSAGEM);

                                                            /*" -766- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -767- IF RF-COD-RETORNO EQUAL 99 */

                                                            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 99)
                                                            {

                                                                /*" -769- MOVE 'AUTORIZ. DEBITO CANCELADA' TO LD01-MENSAGEM */
                                                                _.Move("AUTORIZ. DEBITO CANCELADA", SAIDA.LD01.LD01_MENSAGEM);

                                                                /*" -770- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -771- MOVE 'CODIGO NAO CADASTRADO' TO LD01-MENSAGEM */
                                                                _.Move("CODIGO NAO CADASTRADO", SAIDA.LD01.LD01_MENSAGEM);

                                                                /*" -772- END-IF */
                                                            }


                                                            /*" -773- END-IF */
                                                        }


                                                        /*" -774- END-IF */
                                                    }


                                                    /*" -775- END-IF */
                                                }


                                                /*" -776- END-IF */
                                            }


                                            /*" -777- END-IF */
                                        }


                                        /*" -778- END-IF */
                                    }


                                    /*" -779- END-IF */
                                }


                                /*" -780- END-IF */
                            }


                            /*" -781- END-IF */
                        }


                        /*" -782- END-IF */
                    }


                    /*" -783- END-IF */
                }


                /*" -785- END-IF. */
            }


            /*" -785- WRITE REG-AVA0860B FROM LD01. */
            _.Move(SAIDA.LD01.GetMoveValues(), REG_AVA0860B);

            AVA0860B.Write(REG_AVA0860B.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R0300-00-ACESSO-DADOS-DB-SELECT-3 */
        public void R0300_00_ACESSO_DADOS_DB_SELECT_3()
        {
            /*" -649- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PROPOVA-COD-PRODUTO WITH UR END-EXEC. */

            var r0300_00_ACESSO_DADOS_DB_SELECT_3_Query1 = new R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1()
            {
                PROPOVA_COD_PRODUTO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0300_00_ACESSO_DADOS_DB_SELECT_3_Query1.Execute(r0300_00_ACESSO_DADOS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-ACESSO-DADOS-DB-SELECT-4 */
        public void R0300_00_ACESSO_DADOS_DB_SELECT_4()
        {
            /*" -670- EXEC SQL SELECT NOME_RAZAO , CGCCPF INTO :CLIENTES-NOME-RAZAO , :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

            var r0300_00_ACESSO_DADOS_DB_SELECT_4_Query1 = new R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0300_00_ACESSO_DADOS_DB_SELECT_4_Query1.Execute(r0300_00_ACESSO_DADOS_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -798- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -799- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -800- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -801- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -802- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -804- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -805- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -807- CLOSE AVA0860B. */
            AVA0860B.Close();

            /*" -807- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -811- DISPLAY 'LIDOS       ' AC-LIDOS. */
            _.Display($"LIDOS       {WORK_AREA.AC_LIDOS}");

            /*" -813- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -813- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}