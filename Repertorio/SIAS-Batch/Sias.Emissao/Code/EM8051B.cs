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
using Sias.Emissao.DB2.EM8051B;

namespace Code
{
    public class EM8051B
    {
        public bool IsCall { get; set; }

        public EM8051B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8051B (COPIA EM8006B).           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MILLENIUM                          *      */
        /*"      *   PROGRAMADOR ............  MILLENIUM                          *      */
        /*"      *   CADMUS .... ............  338421/338425                      *      */
        /*"      *   DATA CODIFICACAO .......  23/12/2021                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  CONVERSAO DO ARQUIVO RECEBIDO DO   *      */
        /*"      *                             SAP REFERENTE AO RETORNO (ARQ-H)          */
        /*"      *                             DOS MOVIMENTOS DO SIAS E SIES      *      */
        /*"      *                             CONVERTE CODIGOS DE RETORNO NO     *      */
        /*"      *                             LAYOUT CNAB150(NOVO) PARA O        *      */
        /*"      *                             LAYOUT CNAB240(ATUAL) SOMENTE PARA *      */
        /*"      *                             O REG 2 E CONVENIO 367771          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * VERSAO  : V.01 30122021 12:03HS                                *      */
        /*"      * MOTIVO  : CONVERTE RETORNO DO BANCO NO LAYOUT CNAB150 PARA O   *      */
        /*"      *           LAYOUT CNAB240 PARA OS ARQUIVOS DE COBRANCA DO SIAS  *      */
        /*"      *           E SIES                                               *      */
        /*"      * DEMANDA : 338421(SIAS) E 338425(SIES)                          *      */
        /*"      * DATA    : 23/12/2021                                           *      */
        /*"      * NOME    : MILLENIUM / FLAVIO LIMA                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVARQH { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis MOVARQH
        {
            get
            {
                _.Move(REG_ARQH, _MOVARQH); VarBasis.RedefinePassValue(REG_ARQH, _MOVARQH, REG_ARQH); return _MOVARQH;
            }
        }
        public FileBasis _MOVARQHS { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis MOVARQHS
        {
            get
            {
                _.Move(REG_ARQHS, _MOVARQHS); VarBasis.RedefinePassValue(REG_ARQHS, _MOVARQHS, REG_ARQHS); return _MOVARQHS;
            }
        }
        /*"01        REG-ARQH                    PIC  X(500).*/
        public StringBasis REG_ARQH { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01        REG-ARQHS                   PIC  X(500).*/
        public StringBasis REG_ARQHS { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_ALF { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_BET { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77 WS-FLAG-DIRID                  PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_FLAG_DIRID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77 WS-COD-RETSAP                  PIC X(02) VALUE SPACES.*/
        public StringBasis WS_COD_RETSAP { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"77 WS-COD-RETSIAS                 PIC X(02) VALUE SPACES.*/
        public StringBasis WS_COD_RETSIAS { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"77 WS-COD-RET240                  PIC X(02) VALUE SPACES.*/
        public StringBasis WS_COD_RET240 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"77 WS-MOVCC-RETORNO               PIC X(02) VALUE SPACES.*/
        public StringBasis WS_MOVCC_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
        /*"77 WS-ERRO                        PIC S9(004)     COMP.*/
        public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WS-ALT-RET367771               PIC S9(006)     COMP.*/
        public IntBasis WS_ALT_RET367771 { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
        /*"77 WS-QTD-RET367771               PIC S9(006)     COMP.*/
        public IntBasis WS_QTD_RET367771 { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
        /*"77    VIND-DTRETORNO            PIC S9(004)     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RETORNO              PIC S9(004)     COMP.*/
        public IntBasis VIND_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-USUARIO              PIC S9(004)     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEQUENCIA            PIC S9(004)     COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-DATA-EM             PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DATA_EM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77    WS-NULL1                  PIC S9(04)      COMP.*/
        public IntBasis WS_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    WS-COUNT                  PIC S9(04)      COMP.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    WS-CONTRATO-EF            PIC  X(03)      VALUE SPACES.*/
        public StringBasis WS_CONTRATO_EF { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"77    WS-NUM-REQUISICAO         PIC  9(13)      VALUE ZEROS.*/
        public IntBasis WS_NUM_REQUISICAO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-COUNT              PIC S9(009)     COMP VALUE +0.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WS-QTD-DISPLAY            PIC  9(007) VALUE ZEROS.*/
        public IntBasis WS_QTD_DISPLAY { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77 WS-COD-CONGENERE             PIC S9(04) VALUE +0   COMP.*/
        public IntBasis WS_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  W.*/
        public EM8051B_W W { get; set; } = new EM8051B_W();
        public class EM8051B_W : VarBasis
        {
            /*"  03  WS-MOVCC-CONVENIO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_MOVCC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WTEM-REGISTRO             PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WTEM_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WNSAS-DISPLAY             PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis WNSAS_DISPLAY { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03  LD-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-TIPOREG                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_TIPOREG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-HEADER                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-TRAILLER               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_TRAILLER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESP01                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESP01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESP02                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESP02 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESP16                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESP16 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESPXX                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESPXX { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-VIDA                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_VIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CONV1313               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CONV1313 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-LOTERICO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_LOTERICO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-BILHETE                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-AUTO                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_AUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-REDCHQ                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_REDCHQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET11                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET14                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET14 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET12                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET12 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET11                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET14                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET14 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET12                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET12 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SICAP                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SICAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SICOB                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SIGPF                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SIGPF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CARTAO                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CARTAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SIACC                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SIACC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CHEQUE                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CHEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SINISTRO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-BANCOOB                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_BANCOOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET13                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET13 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET13                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET13 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET15                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET15 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET16                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET16 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET13-CNTRLE           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET13_CNTRLE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-SINISTRO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TE_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-TRATA                  PIC  X(001)    VALUE   'S'.*/
            public StringBasis WS_TRATA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03  WS-EMP-ANT                PIC  X(004)    VALUE   SPACES.*/
            public StringBasis WS_EMP_ANT { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  03  WS-TEM-BILHETE            PIC  X(001)    VALUE   'S'.*/
            public StringBasis WS_TEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03  WS-TRATA-SINISTRO         PIC  X(003)    VALUE    SPACES.*/
            public StringBasis WS_TRATA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  AC-GRAV-SAIDA1            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA2            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA2 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA3            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA4            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA4 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA5            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA5 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA6            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA6 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA7            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA7 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA9            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA11           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA11 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA12           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA13           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA13 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA14           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA14 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA15           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA15 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA16           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA16 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA17           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA17 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-ARQHS             PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_ARQHS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  BAC-ADESAO                PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis BAC_ADESAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  BAC-DEMAIS                PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis BAC_DEMAIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-FLAG-TEM-NN-CNTRLE     PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG_TEM_NN_CNTRLE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-FLAG-DUP               PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG_DUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-FLAG-SEGUIR            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG_SEGUIR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-SQLCODE                PIC  X(004)    VALUE   SPACES.*/
            public StringBasis WS_SQLCODE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  03  WS-NOSSO-NUMERO-SAP       PIC  9(018).*/
            public IntBasis WS_NOSSO_NUMERO_SAP { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"  03         FILLER REDEFINES    WS-NOSSO-NUMERO-SAP.*/
            private _REDEF_EM8051B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM8051B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM8051B_FILLER_0(); _.Move(WS_NOSSO_NUMERO_SAP, _filler_0); VarBasis.RedefinePassValue(WS_NOSSO_NUMERO_SAP, _filler_0, WS_NOSSO_NUMERO_SAP); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NOSSO_NUMERO_SAP); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_NOSSO_NUMERO_SAP); }
            }  //Redefines
            public class _REDEF_EM8051B_FILLER_0 : VarBasis
            {
                /*"     10     FILLER              PIC  9(003).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"     10     WS-NUM-TITULO-NN    PIC  9(014).*/
                public IntBasis WS_NUM_TITULO_NN { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"     10     FILLER              PIC  9(001).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  WS-HEA-NSASAP             PIC  9(009).*/

                public _REDEF_EM8051B_FILLER_0()
                {
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_NUM_TITULO_NN.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_HEA_NSASAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   03 WS-IDLG-DIRID               PIC X(40).*/
            public StringBasis WS_IDLG_DIRID { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   03 WS-IDLG-DIRID-R1 REDEFINES WS-IDLG-DIRID.*/
            private _REDEF_EM8051B_WS_IDLG_DIRID_R1 _ws_idlg_dirid_r1 { get; set; }
            public _REDEF_EM8051B_WS_IDLG_DIRID_R1 WS_IDLG_DIRID_R1
            {
                get { _ws_idlg_dirid_r1 = new _REDEF_EM8051B_WS_IDLG_DIRID_R1(); _.Move(WS_IDLG_DIRID, _ws_idlg_dirid_r1); VarBasis.RedefinePassValue(WS_IDLG_DIRID, _ws_idlg_dirid_r1, WS_IDLG_DIRID); _ws_idlg_dirid_r1.ValueChanged += () => { _.Move(_ws_idlg_dirid_r1, WS_IDLG_DIRID); }; return _ws_idlg_dirid_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_idlg_dirid_r1, WS_IDLG_DIRID); }
            }  //Redefines
            public class _REDEF_EM8051B_WS_IDLG_DIRID_R1 : VarBasis
            {
                /*"      10 WS-IDLG-EMP-SIS-TIP      PIC X(13).*/
                public StringBasis WS_IDLG_EMP_SIS_TIP { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"      10 WS-IDLG-APO-END          PIC X(27).*/
                public StringBasis WS_IDLG_APO_END { get; set; } = new StringBasis(new PIC("X", "27", "X(27)."), @"");
                /*"      10 WS-IDLG-APO-END-R1 REDEFINES WS-IDLG-APO-END.*/
                private _REDEF_EM8051B_WS_IDLG_APO_END_R1 _ws_idlg_apo_end_r1 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_APO_END_R1 WS_IDLG_APO_END_R1
                {
                    get { _ws_idlg_apo_end_r1 = new _REDEF_EM8051B_WS_IDLG_APO_END_R1(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r1); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r1, WS_IDLG_APO_END); _ws_idlg_apo_end_r1.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r1, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r1; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r1, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_APO_END_R1 : VarBasis
                {
                    /*"         15 WS-IDLG-APO-NUM       PIC 9(13).*/
                    public IntBasis WS_IDLG_APO_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15  FILLER REDEFINES    WS-IDLG-APO-NUM.*/
                    private _REDEF_EM8051B_FILLER_3 _filler_3 { get; set; }
                    public _REDEF_EM8051B_FILLER_3 FILLER_3
                    {
                        get { _filler_3 = new _REDEF_EM8051B_FILLER_3(); _.Move(WS_IDLG_APO_NUM, _filler_3); VarBasis.RedefinePassValue(WS_IDLG_APO_NUM, _filler_3, WS_IDLG_APO_NUM); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_IDLG_APO_NUM); }; return _filler_3; }
                        set { VarBasis.RedefinePassValue(value, _filler_3, WS_IDLG_APO_NUM); }
                    }  //Redefines
                    public class _REDEF_EM8051B_FILLER_3 : VarBasis
                    {
                        /*"            20 WS-IDLG-APO-NUM-ID PIC 9(01).*/
                        public IntBasis WS_IDLG_APO_NUM_ID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-APO-NUM-RE PIC 9(12).*/
                        public IntBasis WS_IDLG_APO_NUM_RE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                        /*"         15 WS-IDLG-APO-PAR       PIC 9(02).*/

                        public _REDEF_EM8051B_FILLER_3()
                        {
                            WS_IDLG_APO_NUM_ID.ValueChanged += OnValueChanged;
                            WS_IDLG_APO_NUM_RE.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_IDLG_APO_PAR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER                PIC X(12).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
                    /*"      10 WS-IDLG-APO-END-R2 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8051B_WS_IDLG_APO_END_R1()
                    {
                        WS_IDLG_APO_NUM.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_WS_IDLG_APO_END_R2 _ws_idlg_apo_end_r2 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_APO_END_R2 WS_IDLG_APO_END_R2
                {
                    get { _ws_idlg_apo_end_r2 = new _REDEF_EM8051B_WS_IDLG_APO_END_R2(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r2); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r2, WS_IDLG_APO_END); _ws_idlg_apo_end_r2.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r2, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r2; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r2, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_APO_END_R2 : VarBasis
                {
                    /*"         15 WS-IDLG-END-APO       PIC 9(13).*/
                    public IntBasis WS_IDLG_END_APO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG-END-NUM       PIC 9(04).*/
                    public IntBasis WS_IDLG_END_NUM { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"         15 WS-IDLG-END-PAR       PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR.*/
                    private _REDEF_EM8051B_FILLER_5 _filler_5 { get; set; }
                    public _REDEF_EM8051B_FILLER_5 FILLER_5
                    {
                        get { _filler_5 = new _REDEF_EM8051B_FILLER_5(); _.Move(WS_IDLG_END_PAR, _filler_5); VarBasis.RedefinePassValue(WS_IDLG_END_PAR, _filler_5, WS_IDLG_END_PAR); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_IDLG_END_PAR); }; return _filler_5; }
                        set { VarBasis.RedefinePassValue(value, _filler_5, WS_IDLG_END_PAR); }
                    }  //Redefines
                    public class _REDEF_EM8051B_FILLER_5 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(08).*/

                        public _REDEF_EM8051B_FILLER_5()
                        {
                            WS_IDLG_END_PAR_P1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_P2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                    /*"      10 WS-IDLG-APO-END-R3 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8051B_WS_IDLG_APO_END_R2()
                    {
                        WS_IDLG_END_APO.ValueChanged += OnValueChanged;
                        WS_IDLG_END_NUM.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR.ValueChanged += OnValueChanged;
                        FILLER_5.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_WS_IDLG_APO_END_R3 _ws_idlg_apo_end_r3 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_APO_END_R3 WS_IDLG_APO_END_R3
                {
                    get { _ws_idlg_apo_end_r3 = new _REDEF_EM8051B_WS_IDLG_APO_END_R3(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r3); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r3, WS_IDLG_APO_END); _ws_idlg_apo_end_r3.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r3, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r3; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r3, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_APO_END_R3 : VarBasis
                {
                    /*"         15 WS-IDLG-END-APO-R3    PIC 9(13).*/
                    public IntBasis WS_IDLG_END_APO_R3 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG-END-NUM-R3    PIC 9(04).*/
                    public IntBasis WS_IDLG_END_NUM_R3 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"         15 WS-IDLG-END-PAR-R3    PIC 9(03).*/
                    public IntBasis WS_IDLG_END_PAR_R3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR-R3.*/
                    private _REDEF_EM8051B_FILLER_7 _filler_7 { get; set; }
                    public _REDEF_EM8051B_FILLER_7 FILLER_7
                    {
                        get { _filler_7 = new _REDEF_EM8051B_FILLER_7(); _.Move(WS_IDLG_END_PAR_R3, _filler_7); VarBasis.RedefinePassValue(WS_IDLG_END_PAR_R3, _filler_7, WS_IDLG_END_PAR_R3); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_IDLG_END_PAR_R3); }; return _filler_7; }
                        set { VarBasis.RedefinePassValue(value, _filler_7, WS_IDLG_END_PAR_R3); }
                    }  //Redefines
                    public class _REDEF_EM8051B_FILLER_7 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-R3-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R3_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R3-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R3_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R3-P3 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R3_P3 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(07).*/

                        public _REDEF_EM8051B_FILLER_7()
                        {
                            WS_IDLG_END_PAR_R3_P1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R3_P2.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R3_P3.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                    /*"      10 WS-IDLG-APO-END-R4 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8051B_WS_IDLG_APO_END_R3()
                    {
                        WS_IDLG_END_APO_R3.ValueChanged += OnValueChanged;
                        WS_IDLG_END_NUM_R3.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R3.ValueChanged += OnValueChanged;
                        FILLER_7.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_WS_IDLG_APO_END_R4 _ws_idlg_apo_end_r4 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_APO_END_R4 WS_IDLG_APO_END_R4
                {
                    get { _ws_idlg_apo_end_r4 = new _REDEF_EM8051B_WS_IDLG_APO_END_R4(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r4); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r4, WS_IDLG_APO_END); _ws_idlg_apo_end_r4.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r4, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r4; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r4, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_APO_END_R4 : VarBasis
                {
                    /*"         15 WS-IDLG-END-APO-R4    PIC 9(13).*/
                    public IntBasis WS_IDLG_END_APO_R4 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG-END-NUM-R4    PIC 9(03).*/
                    public IntBasis WS_IDLG_END_NUM_R4 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 WS-IDLG-END-PAR-R4    PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR_R4 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER                PIC X(09).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                    /*"      10 WS-IDLG-PRO-END-R5 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8051B_WS_IDLG_APO_END_R4()
                    {
                        WS_IDLG_END_APO_R4.ValueChanged += OnValueChanged;
                        WS_IDLG_END_NUM_R4.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R4.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_WS_IDLG_PRO_END_R5 _ws_idlg_pro_end_r5 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_PRO_END_R5 WS_IDLG_PRO_END_R5
                {
                    get { _ws_idlg_pro_end_r5 = new _REDEF_EM8051B_WS_IDLG_PRO_END_R5(); _.Move(WS_IDLG_APO_END, _ws_idlg_pro_end_r5); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_pro_end_r5, WS_IDLG_APO_END); _ws_idlg_pro_end_r5.ValueChanged += () => { _.Move(_ws_idlg_pro_end_r5, WS_IDLG_APO_END); }; return _ws_idlg_pro_end_r5; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_pro_end_r5, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_PRO_END_R5 : VarBasis
                {
                    /*"         15 WS-IDLG-PRO-NUM       PIC 9(12).*/
                    public IntBasis WS_IDLG_PRO_NUM { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                    /*"         15  FILLER REDEFINES    WS-IDLG-PRO-NUM.*/
                    private _REDEF_EM8051B_FILLER_10 _filler_10 { get; set; }
                    public _REDEF_EM8051B_FILLER_10 FILLER_10
                    {
                        get { _filler_10 = new _REDEF_EM8051B_FILLER_10(); _.Move(WS_IDLG_PRO_NUM, _filler_10); VarBasis.RedefinePassValue(WS_IDLG_PRO_NUM, _filler_10, WS_IDLG_PRO_NUM); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_IDLG_PRO_NUM); }; return _filler_10; }
                        set { VarBasis.RedefinePassValue(value, _filler_10, WS_IDLG_PRO_NUM); }
                    }  //Redefines
                    public class _REDEF_EM8051B_FILLER_10 : VarBasis
                    {
                        /*"            20 WS-IDLG-PRO-NUM-ID PIC 9(01).*/
                        public IntBasis WS_IDLG_PRO_NUM_ID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-PRO-NUM-RE PIC 9(11).*/
                        public IntBasis WS_IDLG_PRO_NUM_RE { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                        /*"         15 FILLER                PIC X(15).*/

                        public _REDEF_EM8051B_FILLER_10()
                        {
                            WS_IDLG_PRO_NUM_ID.ValueChanged += OnValueChanged;
                            WS_IDLG_PRO_NUM_RE.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                    /*"      10 WS-IDLG-APO-END-R6 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8051B_WS_IDLG_PRO_END_R5()
                    {
                        WS_IDLG_PRO_NUM.ValueChanged += OnValueChanged;
                        FILLER_10.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_WS_IDLG_APO_END_R6 _ws_idlg_apo_end_r6 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_APO_END_R6 WS_IDLG_APO_END_R6
                {
                    get { _ws_idlg_apo_end_r6 = new _REDEF_EM8051B_WS_IDLG_APO_END_R6(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r6); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r6, WS_IDLG_APO_END); _ws_idlg_apo_end_r6.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r6, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r6; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r6, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_APO_END_R6 : VarBasis
                {
                    /*"         15 WS-IDLG-END-PRO-R6    PIC 9(10).*/
                    public IntBasis WS_IDLG_END_PRO_R6 { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"         15 WS-IDLG-END-PAR-R6    PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR_R6 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR-R6.*/
                    private _REDEF_EM8051B_FILLER_12 _filler_12 { get; set; }
                    public _REDEF_EM8051B_FILLER_12 FILLER_12
                    {
                        get { _filler_12 = new _REDEF_EM8051B_FILLER_12(); _.Move(WS_IDLG_END_PAR_R6, _filler_12); VarBasis.RedefinePassValue(WS_IDLG_END_PAR_R6, _filler_12, WS_IDLG_END_PAR_R6); _filler_12.ValueChanged += () => { _.Move(_filler_12, WS_IDLG_END_PAR_R6); }; return _filler_12; }
                        set { VarBasis.RedefinePassValue(value, _filler_12, WS_IDLG_END_PAR_R6); }
                    }  //Redefines
                    public class _REDEF_EM8051B_FILLER_12 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-R1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(15).*/

                        public _REDEF_EM8051B_FILLER_12()
                        {
                            WS_IDLG_END_PAR_R1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                    /*"      10 WS-IDLG-APO-END-R7 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8051B_WS_IDLG_APO_END_R6()
                    {
                        WS_IDLG_END_PRO_R6.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R6.ValueChanged += OnValueChanged;
                        FILLER_12.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_WS_IDLG_APO_END_R7 _ws_idlg_apo_end_r7 { get; set; }
                public _REDEF_EM8051B_WS_IDLG_APO_END_R7 WS_IDLG_APO_END_R7
                {
                    get { _ws_idlg_apo_end_r7 = new _REDEF_EM8051B_WS_IDLG_APO_END_R7(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r7); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r7, WS_IDLG_APO_END); _ws_idlg_apo_end_r7.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r7, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r7; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r7, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8051B_WS_IDLG_APO_END_R7 : VarBasis
                {
                    /*"         15 WS-IDLG-END-PRO-R7    PIC 9(09).*/
                    public IntBasis WS_IDLG_END_PRO_R7 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                    /*"         15 WS-IDLG-END-PAR-R7    PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR_R7 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR-R7.*/
                    private _REDEF_EM8051B_FILLER_14 _filler_14 { get; set; }
                    public _REDEF_EM8051B_FILLER_14 FILLER_14
                    {
                        get { _filler_14 = new _REDEF_EM8051B_FILLER_14(); _.Move(WS_IDLG_END_PAR_R7, _filler_14); VarBasis.RedefinePassValue(WS_IDLG_END_PAR_R7, _filler_14, WS_IDLG_END_PAR_R7); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_IDLG_END_PAR_R7); }; return _filler_14; }
                        set { VarBasis.RedefinePassValue(value, _filler_14, WS_IDLG_END_PAR_R7); }
                    }  //Redefines
                    public class _REDEF_EM8051B_FILLER_14 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-R7-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R7_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R7-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R7_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(16).*/

                        public _REDEF_EM8051B_FILLER_14()
                        {
                            WS_IDLG_END_PAR_R7_P1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R7_P2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
                    /*"  03        WS-IDLG-VIDA        PIC  X(040).*/

                    public _REDEF_EM8051B_WS_IDLG_APO_END_R7()
                    {
                        WS_IDLG_END_PRO_R7.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R7.ValueChanged += OnValueChanged;
                        FILLER_14.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_EM8051B_WS_IDLG_DIRID_R1()
                {
                    WS_IDLG_EMP_SIS_TIP.ValueChanged += OnValueChanged;
                    WS_IDLG_APO_END.ValueChanged += OnValueChanged;
                    WS_IDLG_APO_END_R1.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis WS_IDLG_VIDA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-VIDA.*/
        private _REDEF_EM8051B_FILLER_16 _filler_16 { get; set; }
        public _REDEF_EM8051B_FILLER_16 FILLER_16
        {
            get { _filler_16 = new _REDEF_EM8051B_FILLER_16(); _.Move(WS_IDLG_VIDA, _filler_16); VarBasis.RedefinePassValue(WS_IDLG_VIDA, _filler_16, WS_IDLG_VIDA); _filler_16.ValueChanged += () => { _.Move(_filler_16, WS_IDLG_VIDA); }; return _filler_16; }
            set { VarBasis.RedefinePassValue(value, _filler_16, WS_IDLG_VIDA); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_16 : VarBasis
        {
            /*"     10     WS-IDLG-CONV        PIC  9(006).*/
            public IntBasis WS_IDLG_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NSA         PIC  9(006).*/
            public IntBasis WS_IDLG_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NRSEQ       PIC  9(008).*/
            public IntBasis WS_IDLG_NRSEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10     FILLER              PIC  X(020).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  03        WS-IDLG-1313        PIC  X(040).*/

            public _REDEF_EM8051B_FILLER_16()
            {
                WS_IDLG_CONV.ValueChanged += OnValueChanged;
                WS_IDLG_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_NRSEQ.ValueChanged += OnValueChanged;
                FILLER_17.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_1313 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-1313.*/
        private _REDEF_EM8051B_FILLER_18 _filler_18 { get; set; }
        public _REDEF_EM8051B_FILLER_18 FILLER_18
        {
            get { _filler_18 = new _REDEF_EM8051B_FILLER_18(); _.Move(WS_IDLG_1313, _filler_18); VarBasis.RedefinePassValue(WS_IDLG_1313, _filler_18, WS_IDLG_1313); _filler_18.ValueChanged += () => { _.Move(_filler_18, WS_IDLG_1313); }; return _filler_18; }
            set { VarBasis.RedefinePassValue(value, _filler_18, WS_IDLG_1313); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_18 : VarBasis
        {
            /*"     10     WS-IDLG-CONV-1313   PIC  9(006).*/
            public IntBasis WS_IDLG_CONV_1313 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NSA-1313    PIC  9(006).*/
            public IntBasis WS_IDLG_NSA_1313 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NRSEQ-1313  PIC  9(009).*/
            public IntBasis WS_IDLG_NRSEQ_1313 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     FILLER              PIC  X(019).*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  03        WS-IDLG-BILHETE     PIC  X(040).*/

            public _REDEF_EM8051B_FILLER_18()
            {
                WS_IDLG_CONV_1313.ValueChanged += OnValueChanged;
                WS_IDLG_NSA_1313.ValueChanged += OnValueChanged;
                WS_IDLG_NRSEQ_1313.ValueChanged += OnValueChanged;
                FILLER_19.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_BILHETE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-BILHETE.*/
        private _REDEF_EM8051B_FILLER_20 _filler_20 { get; set; }
        public _REDEF_EM8051B_FILLER_20 FILLER_20
        {
            get { _filler_20 = new _REDEF_EM8051B_FILLER_20(); _.Move(WS_IDLG_BILHETE, _filler_20); VarBasis.RedefinePassValue(WS_IDLG_BILHETE, _filler_20, WS_IDLG_BILHETE); _filler_20.ValueChanged += () => { _.Move(_filler_20, WS_IDLG_BILHETE); }; return _filler_20; }
            set { VarBasis.RedefinePassValue(value, _filler_20, WS_IDLG_BILHETE); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_20 : VarBasis
        {
            /*"     10     WS-IDLG-BIL-CON     PIC  9(006).*/
            public IntBasis WS_IDLG_BIL_CON { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-BIL-NSA     PIC  9(006).*/
            public IntBasis WS_IDLG_BIL_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-BIL-BIL     PIC  9(015).*/
            public IntBasis WS_IDLG_BIL_BIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10     WS-IDLG-BIL-ESP     PIC  X(013).*/
            public StringBasis WS_IDLG_BIL_ESP { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  03        WS-IDLG-DEMAIS      PIC  X(040).*/

            public _REDEF_EM8051B_FILLER_20()
            {
                WS_IDLG_BIL_CON.ValueChanged += OnValueChanged;
                WS_IDLG_BIL_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_BIL_BIL.ValueChanged += OnValueChanged;
                WS_IDLG_BIL_ESP.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_DEMAIS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-DEMAIS.*/
        private _REDEF_EM8051B_FILLER_21 _filler_21 { get; set; }
        public _REDEF_EM8051B_FILLER_21 FILLER_21
        {
            get { _filler_21 = new _REDEF_EM8051B_FILLER_21(); _.Move(WS_IDLG_DEMAIS, _filler_21); VarBasis.RedefinePassValue(WS_IDLG_DEMAIS, _filler_21, WS_IDLG_DEMAIS); _filler_21.ValueChanged += () => { _.Move(_filler_21, WS_IDLG_DEMAIS); }; return _filler_21; }
            set { VarBasis.RedefinePassValue(value, _filler_21, WS_IDLG_DEMAIS); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_21 : VarBasis
        {
            /*"     10     WS-IDLG-DEM-CON     PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_CON { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-NSA     PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-APO     PIC  9(013).*/
            public IntBasis WS_IDLG_DEM_APO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10     WS-IDLG-DEM-END     PIC  9(009).*/
            public IntBasis WS_IDLG_DEM_END { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     WS-IDLG-DEM-PAR     PIC  9(004).*/
            public IntBasis WS_IDLG_DEM_PAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10     FILLER              PIC  X(002).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03        WS-IDLG-DEMAIS-PARC PIC  X(040).*/

            public _REDEF_EM8051B_FILLER_21()
            {
                WS_IDLG_DEM_CON.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_APO.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_END.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_PAR.ValueChanged += OnValueChanged;
                FILLER_22.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_DEMAIS_PARC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-DEMAIS-PARC.*/
        private _REDEF_EM8051B_FILLER_23 _filler_23 { get; set; }
        public _REDEF_EM8051B_FILLER_23 FILLER_23
        {
            get { _filler_23 = new _REDEF_EM8051B_FILLER_23(); _.Move(WS_IDLG_DEMAIS_PARC, _filler_23); VarBasis.RedefinePassValue(WS_IDLG_DEMAIS_PARC, _filler_23, WS_IDLG_DEMAIS_PARC); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS_IDLG_DEMAIS_PARC); }; return _filler_23; }
            set { VarBasis.RedefinePassValue(value, _filler_23, WS_IDLG_DEMAIS_PARC); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_23 : VarBasis
        {
            /*"     10     WS-IDLG-DEM-CON-P   PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_CON_P { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-NSA-P   PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_NSA_P { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-APO-P   PIC  9(015).*/
            public IntBasis WS_IDLG_DEM_APO_P { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10     WS-IDLG-DEM-END-P   PIC  9(009).*/
            public IntBasis WS_IDLG_DEM_END_P { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     WS-IDLG-DEM-PAR-P   PIC  9(004).*/
            public IntBasis WS_IDLG_DEM_PAR_P { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03        WS-IDLG-CHQ         PIC  X(040).*/

            public _REDEF_EM8051B_FILLER_23()
            {
                WS_IDLG_DEM_CON_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_NSA_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_APO_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_END_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_PAR_P.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_CHQ { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-CHQ.*/
        private _REDEF_EM8051B_FILLER_24 _filler_24 { get; set; }
        public _REDEF_EM8051B_FILLER_24 FILLER_24
        {
            get { _filler_24 = new _REDEF_EM8051B_FILLER_24(); _.Move(WS_IDLG_CHQ, _filler_24); VarBasis.RedefinePassValue(WS_IDLG_CHQ, _filler_24, WS_IDLG_CHQ); _filler_24.ValueChanged += () => { _.Move(_filler_24, WS_IDLG_CHQ); }; return _filler_24; }
            set { VarBasis.RedefinePassValue(value, _filler_24, WS_IDLG_CHQ); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_24 : VarBasis
        {
            /*"     10     WS-IDLG-NROCHQ      PIC  9(009).*/
            public IntBasis WS_IDLG_NROCHQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     WS-IDLG-DVCHQ       PIC  9(001).*/
            public IntBasis WS_IDLG_DVCHQ { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10     FILLER              PIC  X(030).*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  03        WS-IDLG-CARTAO      PIC  X(040).*/

            public _REDEF_EM8051B_FILLER_24()
            {
                WS_IDLG_NROCHQ.ValueChanged += OnValueChanged;
                WS_IDLG_DVCHQ.ValueChanged += OnValueChanged;
                FILLER_25.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-CARTAO.*/
        private _REDEF_EM8051B_FILLER_26 _filler_26 { get; set; }
        public _REDEF_EM8051B_FILLER_26 FILLER_26
        {
            get { _filler_26 = new _REDEF_EM8051B_FILLER_26(); _.Move(WS_IDLG_CARTAO, _filler_26); VarBasis.RedefinePassValue(WS_IDLG_CARTAO, _filler_26, WS_IDLG_CARTAO); _filler_26.ValueChanged += () => { _.Move(_filler_26, WS_IDLG_CARTAO); }; return _filler_26; }
            set { VarBasis.RedefinePassValue(value, _filler_26, WS_IDLG_CARTAO); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_26 : VarBasis
        {
            /*"     10     WS-IDLG-CAR-CONV    PIC  9(006).*/
            public IntBasis WS_IDLG_CAR_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-CAR-NSA     PIC  9(006).*/
            public IntBasis WS_IDLG_CAR_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-CAR-NRSEQ   PIC  9(009).*/
            public IntBasis WS_IDLG_CAR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     FILLER              PIC  X(019).*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  03         WS-OCORR           PIC  X(010).*/

            public _REDEF_EM8051B_FILLER_26()
            {
                WS_IDLG_CAR_CONV.ValueChanged += OnValueChanged;
                WS_IDLG_CAR_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_CAR_NRSEQ.ValueChanged += OnValueChanged;
                FILLER_27.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_OCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"  03          FILLER REDEFINES    WS-OCORR.*/
        private _REDEF_EM8051B_FILLER_28 _filler_28 { get; set; }
        public _REDEF_EM8051B_FILLER_28 FILLER_28
        {
            get { _filler_28 = new _REDEF_EM8051B_FILLER_28(); _.Move(WS_OCORR, _filler_28); VarBasis.RedefinePassValue(WS_OCORR, _filler_28, WS_OCORR); _filler_28.ValueChanged += () => { _.Move(_filler_28, WS_OCORR); }; return _filler_28; }
            set { VarBasis.RedefinePassValue(value, _filler_28, WS_OCORR); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_28 : VarBasis
        {
            /*"     10      WS-OCORR1          PIC  X(002).*/
            public StringBasis WS_OCORR1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR2          PIC  X(002).*/
            public StringBasis WS_OCORR2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR3          PIC  X(002).*/
            public StringBasis WS_OCORR3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR4          PIC  X(002).*/
            public StringBasis WS_OCORR4 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR5          PIC  X(002).*/
            public StringBasis WS_OCORR5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-PROPOSTA       PIC   9(014).*/

            public _REDEF_EM8051B_FILLER_28()
            {
                WS_OCORR1.ValueChanged += OnValueChanged;
                WS_OCORR2.ValueChanged += OnValueChanged;
                WS_OCORR3.ValueChanged += OnValueChanged;
                WS_OCORR4.ValueChanged += OnValueChanged;
                WS_OCORR5.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"  03         FILLER            REDEFINES      WS-PROPOSTA.*/
        private _REDEF_EM8051B_FILLER_29 _filler_29 { get; set; }
        public _REDEF_EM8051B_FILLER_29 FILLER_29
        {
            get { _filler_29 = new _REDEF_EM8051B_FILLER_29(); _.Move(WS_PROPOSTA, _filler_29); VarBasis.RedefinePassValue(WS_PROPOSTA, _filler_29, WS_PROPOSTA); _filler_29.ValueChanged += () => { _.Move(_filler_29, WS_PROPOSTA); }; return _filler_29; }
            set { VarBasis.RedefinePassValue(value, _filler_29, WS_PROPOSTA); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_29 : VarBasis
        {
            /*"    05       WS-PROPOS1        PIC   9(013).*/
            public IntBasis WS_PROPOS1 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05       FILLER            PIC   9(001).*/
            public IntBasis FILLER_30 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         WS-NUMALFA        PIC   X(013).*/

            public _REDEF_EM8051B_FILLER_29()
            {
                WS_PROPOS1.ValueChanged += OnValueChanged;
                FILLER_30.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_NUMALFA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
        /*"  03         FILLER            REDEFINES      WS-NUMALFA.*/
        private _REDEF_EM8051B_FILLER_31 _filler_31 { get; set; }
        public _REDEF_EM8051B_FILLER_31 FILLER_31
        {
            get { _filler_31 = new _REDEF_EM8051B_FILLER_31(); _.Move(WS_NUMALFA, _filler_31); VarBasis.RedefinePassValue(WS_NUMALFA, _filler_31, WS_NUMALFA); _filler_31.ValueChanged += () => { _.Move(_filler_31, WS_NUMALFA); }; return _filler_31; }
            set { VarBasis.RedefinePassValue(value, _filler_31, WS_NUMALFA); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_31 : VarBasis
        {
            /*"    05       TB-NUMALFA        OCCURS         13 TIMES                               INDEXED  BY    WS-ALF.*/
            public ListBasis<EM8051B_TB_NUMALFA> TB_NUMALFA { get; set; } = new ListBasis<EM8051B_TB_NUMALFA>(13);
            public class EM8051B_TB_NUMALFA : VarBasis
            {
                /*"     10      WS-ALFA01          PIC  X(001).*/
                public StringBasis WS_ALFA01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WS-NUMBETA        PIC   9(013).*/

                public EM8051B_TB_NUMALFA()
                {
                    WS_ALFA01.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_EM8051B_FILLER_31()
            {
                TB_NUMALFA.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_NUMBETA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
        /*"  03         FILLER            REDEFINES      WS-NUMBETA.*/
        private _REDEF_EM8051B_FILLER_32 _filler_32 { get; set; }
        public _REDEF_EM8051B_FILLER_32 FILLER_32
        {
            get { _filler_32 = new _REDEF_EM8051B_FILLER_32(); _.Move(WS_NUMBETA, _filler_32); VarBasis.RedefinePassValue(WS_NUMBETA, _filler_32, WS_NUMBETA); _filler_32.ValueChanged += () => { _.Move(_filler_32, WS_NUMBETA); }; return _filler_32; }
            set { VarBasis.RedefinePassValue(value, _filler_32, WS_NUMBETA); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_32 : VarBasis
        {
            /*"    05       TB-NUMBETA        OCCURS         13 TIMES                               INDEXED  BY    WS-BET.*/
            public ListBasis<EM8051B_TB_NUMBETA> TB_NUMBETA { get; set; } = new ListBasis<EM8051B_TB_NUMBETA>(13);
            public class EM8051B_TB_NUMBETA : VarBasis
            {
                /*"     10      WS-BETA01          PIC  X(001).*/
                public StringBasis WS_BETA01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WS-IDTCLIDET3      PIC  X(025).*/

                public EM8051B_TB_NUMBETA()
                {
                    WS_BETA01.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_EM8051B_FILLER_32()
            {
                TB_NUMBETA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIDET3 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIDET3.*/
        private _REDEF_EM8051B_FILLER_33 _filler_33 { get; set; }
        public _REDEF_EM8051B_FILLER_33 FILLER_33
        {
            get { _filler_33 = new _REDEF_EM8051B_FILLER_33(); _.Move(WS_IDTCLIDET3, _filler_33); VarBasis.RedefinePassValue(WS_IDTCLIDET3, _filler_33, WS_IDTCLIDET3); _filler_33.ValueChanged += () => { _.Move(_filler_33, WS_IDTCLIDET3); }; return _filler_33; }
            set { VarBasis.RedefinePassValue(value, _filler_33, WS_IDTCLIDET3); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_33 : VarBasis
        {
            /*"    10       MOVCC-ANO-DET3     PIC  9(004).*/
            public IntBasis MOVCC_ANO_DET3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       MOVCC-MES-DET3     PIC  9(002).*/
            public IntBasis MOVCC_MES_DET3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       MOVCC-DIA-DET3     PIC  9(002).*/
            public IntBasis MOVCC_DIA_DET3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER             PIC  X(017).*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  03         WS-IDTCLIEMP       PIC  X(025).*/

            public _REDEF_EM8051B_FILLER_33()
            {
                MOVCC_ANO_DET3.ValueChanged += OnValueChanged;
                MOVCC_MES_DET3.ValueChanged += OnValueChanged;
                MOVCC_DIA_DET3.ValueChanged += OnValueChanged;
                FILLER_34.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP.*/
        private _REDEF_EM8051B_FILLER_35 _filler_35 { get; set; }
        public _REDEF_EM8051B_FILLER_35 FILLER_35
        {
            get { _filler_35 = new _REDEF_EM8051B_FILLER_35(); _.Move(WS_IDTCLIEMP, _filler_35); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_35, WS_IDTCLIEMP); _filler_35.ValueChanged += () => { _.Move(_filler_35, WS_IDTCLIEMP); }; return _filler_35; }
            set { VarBasis.RedefinePassValue(value, _filler_35, WS_IDTCLIEMP); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_35 : VarBasis
        {
            /*"     10      WS-NUM-CERTIF      PIC  9(015).*/
            public IntBasis WS_NUM_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10      WS-NUM-NSAS        PIC  9(005).*/
            public IntBasis WS_NUM_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10      FILLER             PIC  9(005).*/
            public IntBasis FILLER_36 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  03         WS-IDTCLIEMP-LOT   PIC  X(025).*/

            public _REDEF_EM8051B_FILLER_35()
            {
                WS_NUM_CERTIF.ValueChanged += OnValueChanged;
                WS_NUM_NSAS.ValueChanged += OnValueChanged;
                FILLER_36.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_LOT { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-LOT.*/
        private _REDEF_EM8051B_FILLER_37 _filler_37 { get; set; }
        public _REDEF_EM8051B_FILLER_37 FILLER_37
        {
            get { _filler_37 = new _REDEF_EM8051B_FILLER_37(); _.Move(WS_IDTCLIEMP_LOT, _filler_37); VarBasis.RedefinePassValue(WS_IDTCLIEMP_LOT, _filler_37, WS_IDTCLIEMP_LOT); _filler_37.ValueChanged += () => { _.Move(_filler_37, WS_IDTCLIEMP_LOT); }; return _filler_37; }
            set { VarBasis.RedefinePassValue(value, _filler_37, WS_IDTCLIEMP_LOT); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_37 : VarBasis
        {
            /*"     10      WS-CODFENAL        PIC  9(009).*/
            public IntBasis WS_CODFENAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10      WS-NRPARCEL        PIC  9(003).*/
            public IntBasis WS_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10      WS-NUMAPOL         PIC  9(013).*/
            public IntBasis WS_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  03         WS-IDTCLIEMP-RED   PIC  X(025).*/

            public _REDEF_EM8051B_FILLER_37()
            {
                WS_CODFENAL.ValueChanged += OnValueChanged;
                WS_NRPARCEL.ValueChanged += OnValueChanged;
                WS_NUMAPOL.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_RED { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-RED.*/
        private _REDEF_EM8051B_FILLER_38 _filler_38 { get; set; }
        public _REDEF_EM8051B_FILLER_38 FILLER_38
        {
            get { _filler_38 = new _REDEF_EM8051B_FILLER_38(); _.Move(WS_IDTCLIEMP_RED, _filler_38); VarBasis.RedefinePassValue(WS_IDTCLIEMP_RED, _filler_38, WS_IDTCLIEMP_RED); _filler_38.ValueChanged += () => { _.Move(_filler_38, WS_IDTCLIEMP_RED); }; return _filler_38; }
            set { VarBasis.RedefinePassValue(value, _filler_38, WS_IDTCLIEMP_RED); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_38 : VarBasis
        {
            /*"     10      WS-RED-NRAPOL      PIC  9(013).*/
            public IntBasis WS_RED_NRAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10      WS-RED-NRENDO      PIC  9(008).*/
            public IntBasis WS_RED_NRENDO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      WS-RED-NRPARC      PIC  9(004).*/
            public IntBasis WS_RED_NRPARC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03         WS-IDTCLIEMP-BI1   PIC  X(025).*/

            public _REDEF_EM8051B_FILLER_38()
            {
                WS_RED_NRAPOL.ValueChanged += OnValueChanged;
                WS_RED_NRENDO.ValueChanged += OnValueChanged;
                WS_RED_NRPARC.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_BI1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-BI1.*/
        private _REDEF_EM8051B_FILLER_39 _filler_39 { get; set; }
        public _REDEF_EM8051B_FILLER_39 FILLER_39
        {
            get { _filler_39 = new _REDEF_EM8051B_FILLER_39(); _.Move(WS_IDTCLIEMP_BI1, _filler_39); VarBasis.RedefinePassValue(WS_IDTCLIEMP_BI1, _filler_39, WS_IDTCLIEMP_BI1); _filler_39.ValueChanged += () => { _.Move(_filler_39, WS_IDTCLIEMP_BI1); }; return _filler_39; }
            set { VarBasis.RedefinePassValue(value, _filler_39, WS_IDTCLIEMP_BI1); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_39 : VarBasis
        {
            /*"     10      WS-BI1-NRAPOL      PIC  9(013).*/
            public IntBasis WS_BI1_NRAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10      WS-BI1-NRENDO      PIC  9(006).*/
            public IntBasis WS_BI1_NRENDO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BI1-NRPARC      PIC  9(002).*/
            public IntBasis WS_BI1_NRPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10      FILLER             PIC  X(004).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  03         WS-IDTCLIEMP-BI2   PIC  X(025).*/

            public _REDEF_EM8051B_FILLER_39()
            {
                WS_BI1_NRAPOL.ValueChanged += OnValueChanged;
                WS_BI1_NRENDO.ValueChanged += OnValueChanged;
                WS_BI1_NRPARC.ValueChanged += OnValueChanged;
                FILLER_40.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_BI2 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-BI2.*/
        private _REDEF_EM8051B_FILLER_41 _filler_41 { get; set; }
        public _REDEF_EM8051B_FILLER_41 FILLER_41
        {
            get { _filler_41 = new _REDEF_EM8051B_FILLER_41(); _.Move(WS_IDTCLIEMP_BI2, _filler_41); VarBasis.RedefinePassValue(WS_IDTCLIEMP_BI2, _filler_41, WS_IDTCLIEMP_BI2); _filler_41.ValueChanged += () => { _.Move(_filler_41, WS_IDTCLIEMP_BI2); }; return _filler_41; }
            set { VarBasis.RedefinePassValue(value, _filler_41, WS_IDTCLIEMP_BI2); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_41 : VarBasis
        {
            /*"     10      WS-BI2-NUMBIL      PIC  9(015).*/
            public IntBasis WS_BI2_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10      FILLER             PIC  X(010).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         WS-IDTCLIEMP-BI3   PIC  X(025).*/

            public _REDEF_EM8051B_FILLER_41()
            {
                WS_BI2_NUMBIL.ValueChanged += OnValueChanged;
                FILLER_42.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_BI3 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-BI3.*/
        private _REDEF_EM8051B_FILLER_43 _filler_43 { get; set; }
        public _REDEF_EM8051B_FILLER_43 FILLER_43
        {
            get { _filler_43 = new _REDEF_EM8051B_FILLER_43(); _.Move(WS_IDTCLIEMP_BI3, _filler_43); VarBasis.RedefinePassValue(WS_IDTCLIEMP_BI3, _filler_43, WS_IDTCLIEMP_BI3); _filler_43.ValueChanged += () => { _.Move(_filler_43, WS_IDTCLIEMP_BI3); }; return _filler_43; }
            set { VarBasis.RedefinePassValue(value, _filler_43, WS_IDTCLIEMP_BI3); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_43 : VarBasis
        {
            /*"     10      WS-BI3-NRAPOL      PIC  9(015).*/
            public IntBasis WS_BI3_NRAPOL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10      WS-BI3-NRENDO      PIC  9(006).*/
            public IntBasis WS_BI3_NRENDO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BI3-NRPARC      PIC  9(002).*/
            public IntBasis WS_BI3_NRPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10      FILLER             PIC  X(002).*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-NSL             PIC  9(005).*/

            public _REDEF_EM8051B_FILLER_43()
            {
                WS_BI3_NRAPOL.ValueChanged += OnValueChanged;
                WS_BI3_NRENDO.ValueChanged += OnValueChanged;
                WS_BI3_NRPARC.ValueChanged += OnValueChanged;
                FILLER_44.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
        /*"  03          FILLER REDEFINES    WS-NSL.*/
        private _REDEF_EM8051B_FILLER_45 _filler_45 { get; set; }
        public _REDEF_EM8051B_FILLER_45 FILLER_45
        {
            get { _filler_45 = new _REDEF_EM8051B_FILLER_45(); _.Move(WS_NSL, _filler_45); VarBasis.RedefinePassValue(WS_NSL, _filler_45, WS_NSL); _filler_45.ValueChanged += () => { _.Move(_filler_45, WS_NSL); }; return _filler_45; }
            set { VarBasis.RedefinePassValue(value, _filler_45, WS_NSL); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_45 : VarBasis
        {
            /*"     10      WS-NSL1            PIC  9(002).*/
            public IntBasis WS_NSL1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10      WS-NSL2            PIC  9(003).*/
            public IntBasis WS_NSL2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03         WS-USOEMPRESA      PIC  X(060).*/

            public _REDEF_EM8051B_FILLER_45()
            {
                WS_NSL1.ValueChanged += OnValueChanged;
                WS_NSL2.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPRESA.*/
        private _REDEF_EM8051B_FILLER_46 _filler_46 { get; set; }
        public _REDEF_EM8051B_FILLER_46 FILLER_46
        {
            get { _filler_46 = new _REDEF_EM8051B_FILLER_46(); _.Move(WS_USOEMPRESA, _filler_46); VarBasis.RedefinePassValue(WS_USOEMPRESA, _filler_46, WS_USOEMPRESA); _filler_46.ValueChanged += () => { _.Move(_filler_46, WS_USOEMPRESA); }; return _filler_46; }
            set { VarBasis.RedefinePassValue(value, _filler_46, WS_USOEMPRESA); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_46 : VarBasis
        {
            /*"     10      WS-NUM-NSL         PIC  9(003).*/
            public IntBasis WS_NUM_NSL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10      WS-NUM-NRSEQ       PIC  9(008).*/
            public IntBasis WS_NUM_NRSEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      FILLER             PIC  X(049).*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
            /*"  03         WS-USOEMPR-BIL     PIC  X(060).*/

            public _REDEF_EM8051B_FILLER_46()
            {
                WS_NUM_NSL.ValueChanged += OnValueChanged;
                WS_NUM_NRSEQ.ValueChanged += OnValueChanged;
                FILLER_47.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPR_BIL { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPR-BIL.*/
        private _REDEF_EM8051B_FILLER_48 _filler_48 { get; set; }
        public _REDEF_EM8051B_FILLER_48 FILLER_48
        {
            get { _filler_48 = new _REDEF_EM8051B_FILLER_48(); _.Move(WS_USOEMPR_BIL, _filler_48); VarBasis.RedefinePassValue(WS_USOEMPR_BIL, _filler_48, WS_USOEMPR_BIL); _filler_48.ValueChanged += () => { _.Move(_filler_48, WS_USOEMPR_BIL); }; return _filler_48; }
            set { VarBasis.RedefinePassValue(value, _filler_48, WS_USOEMPR_BIL); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_48 : VarBasis
        {
            /*"     10      WS-BIL-CODCONV     PIC  9(006).*/
            public IntBasis WS_BIL_CODCONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BIL-NSAS        PIC  9(006).*/
            public IntBasis WS_BIL_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BIL-NUMREQ      PIC  9(006).*/
            public IntBasis WS_BIL_NUMREQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      FILLER             PIC  X(042).*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
            /*"  03         WS-USOEMPR-CHQ     PIC  X(060).*/

            public _REDEF_EM8051B_FILLER_48()
            {
                WS_BIL_CODCONV.ValueChanged += OnValueChanged;
                WS_BIL_NSAS.ValueChanged += OnValueChanged;
                WS_BIL_NUMREQ.ValueChanged += OnValueChanged;
                FILLER_49.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPR_CHQ { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPR-CHQ.*/
        private _REDEF_EM8051B_FILLER_50 _filler_50 { get; set; }
        public _REDEF_EM8051B_FILLER_50 FILLER_50
        {
            get { _filler_50 = new _REDEF_EM8051B_FILLER_50(); _.Move(WS_USOEMPR_CHQ, _filler_50); VarBasis.RedefinePassValue(WS_USOEMPR_CHQ, _filler_50, WS_USOEMPR_CHQ); _filler_50.ValueChanged += () => { _.Move(_filler_50, WS_USOEMPR_CHQ); }; return _filler_50; }
            set { VarBasis.RedefinePassValue(value, _filler_50, WS_USOEMPR_CHQ); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_50 : VarBasis
        {
            /*"     10      WS-CHQ-CODCONV     PIC  9(006).*/
            public IntBasis WS_CHQ_CODCONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-CHQ-NSAS        PIC  9(006).*/
            public IntBasis WS_CHQ_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-CHQ-NUMREQ      PIC  9(006).*/
            public IntBasis WS_CHQ_NUMREQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-CHQ-CODPROD     PIC  9(004).*/
            public IntBasis WS_CHQ_CODPROD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10      WS-CHQ-OCMOVTO     PIC  9(009).*/
            public IntBasis WS_CHQ_OCMOVTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10      FILLER             PIC  X(029).*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)."), @"");
            /*"  03         WS-USOEMPR-LOT     PIC  X(060).*/

            public _REDEF_EM8051B_FILLER_50()
            {
                WS_CHQ_CODCONV.ValueChanged += OnValueChanged;
                WS_CHQ_NSAS.ValueChanged += OnValueChanged;
                WS_CHQ_NUMREQ.ValueChanged += OnValueChanged;
                WS_CHQ_CODPROD.ValueChanged += OnValueChanged;
                WS_CHQ_OCMOVTO.ValueChanged += OnValueChanged;
                FILLER_51.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPR_LOT { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPR-LOT.*/
        private _REDEF_EM8051B_FILLER_52 _filler_52 { get; set; }
        public _REDEF_EM8051B_FILLER_52 FILLER_52
        {
            get { _filler_52 = new _REDEF_EM8051B_FILLER_52(); _.Move(WS_USOEMPR_LOT, _filler_52); VarBasis.RedefinePassValue(WS_USOEMPR_LOT, _filler_52, WS_USOEMPR_LOT); _filler_52.ValueChanged += () => { _.Move(_filler_52, WS_USOEMPR_LOT); }; return _filler_52; }
            set { VarBasis.RedefinePassValue(value, _filler_52, WS_USOEMPR_LOT); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_52 : VarBasis
        {
            /*"     10      WS-LOT-NSA         PIC  9(006).*/
            public IntBasis WS_LOT_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-LOT-NSL         PIC  9(006).*/
            public IntBasis WS_LOT_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-LOT-NUMLAC      PIC  9(013).*/
            public IntBasis WS_LOT_NUMLAC { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10      WS-LOT-CODPRODU    PIC  9(004).*/
            public IntBasis WS_LOT_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10      WS-LOT-NRENDOS     PIC  9(008).*/
            public IntBasis WS_LOT_NRENDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      WS-LOT-CODCOBER    PIC  9(003).*/
            public IntBasis WS_LOT_CODCOBER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10      WS-LOT-NUMFATUR    PIC  9(008).*/
            public IntBasis WS_LOT_NUMFATUR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      WS-LOT-DATADEB     PIC  X(010).*/
            public StringBasis WS_LOT_DATADEB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"     10      WS-LOT-TPREG       PIC  X(002).*/
            public StringBasis WS_LOT_TPREG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03        WS-DATA-SAP.*/

            public _REDEF_EM8051B_FILLER_52()
            {
                WS_LOT_NSA.ValueChanged += OnValueChanged;
                WS_LOT_NSL.ValueChanged += OnValueChanged;
                WS_LOT_NUMLAC.ValueChanged += OnValueChanged;
                WS_LOT_CODPRODU.ValueChanged += OnValueChanged;
                WS_LOT_NRENDOS.ValueChanged += OnValueChanged;
                WS_LOT_CODCOBER.ValueChanged += OnValueChanged;
                WS_LOT_NUMFATUR.ValueChanged += OnValueChanged;
                WS_LOT_DATADEB.ValueChanged += OnValueChanged;
                WS_LOT_TPREG.ValueChanged += OnValueChanged;
            }

        }
        public EM8051B_WS_DATA_SAP WS_DATA_SAP { get; set; } = new EM8051B_WS_DATA_SAP();
        public class EM8051B_WS_DATA_SAP : VarBasis
        {
            /*"     10     WS-DD-SAP           PIC  9(002).*/
            public IntBasis WS_DD_SAP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-MM-SAP           PIC  9(002).*/
            public IntBasis WS_MM_SAP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-AA-SAP           PIC  9(004).*/
            public IntBasis WS_AA_SAP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03        WS-DATA-SAP1.*/
        }
        public EM8051B_WS_DATA_SAP1 WS_DATA_SAP1 { get; set; } = new EM8051B_WS_DATA_SAP1();
        public class EM8051B_WS_DATA_SAP1 : VarBasis
        {
            /*"     10     WS-DD-SAP1          PIC  9(002).*/
            public IntBasis WS_DD_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-MM-SAP1          PIC  9(002).*/
            public IntBasis WS_MM_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-SS-SAP1          PIC  9(002).*/
            public IntBasis WS_SS_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-AA-SAP1          PIC  9(002).*/
            public IntBasis WS_AA_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
        }
        public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
        private _REDEF_EM8051B_FILLER_53 _filler_53 { get; set; }
        public _REDEF_EM8051B_FILLER_53 FILLER_53
        {
            get { _filler_53 = new _REDEF_EM8051B_FILLER_53(); _.Move(WTIME_DAY, _filler_53); VarBasis.RedefinePassValue(WTIME_DAY, _filler_53, WTIME_DAY); _filler_53.ValueChanged += () => { _.Move(_filler_53, WTIME_DAY); }; return _filler_53; }
            set { VarBasis.RedefinePassValue(value, _filler_53, WTIME_DAY); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_53 : VarBasis
        {
            /*"    05       WTIME-DAYR.*/
            public EM8051B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM8051B_WTIME_DAYR();
            public class EM8051B_WTIME_DAYR : VarBasis
            {
                /*"      10     WTIME-HORA         PIC  X(002).*/
                public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-2PT1         PIC  X(001).*/
                public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WTIME-MINU         PIC  X(002).*/
                public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-2PT2         PIC  X(001).*/
                public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WTIME-SEGU         PIC  X(002).*/
                public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       WTIME-2PT3         PIC  X(001).*/

                public EM8051B_WTIME_DAYR()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_2PT1.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_2PT2.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05       WTIME-CCSE         PIC  X(002).*/
            public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-VLR-AUX         PIC  S9(13)V99 USAGE COMP-3.*/

            public _REDEF_EM8051B_FILLER_53()
            {
                WTIME_DAYR.ValueChanged += OnValueChanged;
                WTIME_2PT3.ValueChanged += OnValueChanged;
                WTIME_CCSE.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis WS_VLR_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"  03         WS-TIME-SQL         PIC  X(08).*/
        public StringBasis WS_TIME_SQL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"  03          FILLER REDEFINES    WS-TIME-SQL.*/
        private _REDEF_EM8051B_FILLER_54 _filler_54 { get; set; }
        public _REDEF_EM8051B_FILLER_54 FILLER_54
        {
            get { _filler_54 = new _REDEF_EM8051B_FILLER_54(); _.Move(WS_TIME_SQL, _filler_54); VarBasis.RedefinePassValue(WS_TIME_SQL, _filler_54, WS_TIME_SQL); _filler_54.ValueChanged += () => { _.Move(_filler_54, WS_TIME_SQL); }; return _filler_54; }
            set { VarBasis.RedefinePassValue(value, _filler_54, WS_TIME_SQL); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_54 : VarBasis
        {
            /*"     10      WS-HH-SQL           PIC  9(02).*/
            public IntBasis WS_HH_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-HH-PTO1          PIC  X(01).*/
            public StringBasis WS_HH_PTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     10      WS-MM-SQL           PIC  9(02).*/
            public IntBasis WS_MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-HH-PTO2          PIC  X(01).*/
            public StringBasis WS_HH_PTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     10      WS-SS-SQL           PIC  9(02).*/
            public IntBasis WS_SS_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  03         WS-TIME             PIC  X(06).*/

            public _REDEF_EM8051B_FILLER_54()
            {
                WS_HH_SQL.ValueChanged += OnValueChanged;
                WS_HH_PTO1.ValueChanged += OnValueChanged;
                WS_MM_SQL.ValueChanged += OnValueChanged;
                WS_HH_PTO2.ValueChanged += OnValueChanged;
                WS_SS_SQL.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
        /*"  03          FILLER REDEFINES    WS-TIME.*/
        private _REDEF_EM8051B_FILLER_55 _filler_55 { get; set; }
        public _REDEF_EM8051B_FILLER_55 FILLER_55
        {
            get { _filler_55 = new _REDEF_EM8051B_FILLER_55(); _.Move(WS_TIME, _filler_55); VarBasis.RedefinePassValue(WS_TIME, _filler_55, WS_TIME); _filler_55.ValueChanged += () => { _.Move(_filler_55, WS_TIME); }; return _filler_55; }
            set { VarBasis.RedefinePassValue(value, _filler_55, WS_TIME); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_55 : VarBasis
        {
            /*"     10      WS-HH               PIC  9(02).*/
            public IntBasis WS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-MM               PIC  9(02).*/
            public IntBasis WS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-SS               PIC  9(02).*/
            public IntBasis WS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/

            public _REDEF_EM8051B_FILLER_55()
            {
                WS_HH.ValueChanged += OnValueChanged;
                WS_MM.ValueChanged += OnValueChanged;
                WS_SS.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03         FILLER             REDEFINES      WDATA-REL.*/
        private _REDEF_EM8051B_FILLER_56 _filler_56 { get; set; }
        public _REDEF_EM8051B_FILLER_56 FILLER_56
        {
            get { _filler_56 = new _REDEF_EM8051B_FILLER_56(); _.Move(WDATA_REL, _filler_56); VarBasis.RedefinePassValue(WDATA_REL, _filler_56, WDATA_REL); _filler_56.ValueChanged += () => { _.Move(_filler_56, WDATA_REL); }; return _filler_56; }
            set { VarBasis.RedefinePassValue(value, _filler_56, WDATA_REL); }
        }  //Redefines
        public class _REDEF_EM8051B_FILLER_56 : VarBasis
        {
            /*"    10       WDAT-REL-ANO       PIC  9(004).*/
            public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WDAT-REL-HIFEN-1   PIC  X(001).*/
            public StringBasis WDAT_REL_HIFEN_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDAT-REL-MES       PIC  9(002).*/
            public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WDAT-REL-HIFEN-2   PIC  X(001).*/
            public StringBasis WDAT_REL_HIFEN_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDAT-REL-DIA       PIC  9(002).*/
            public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WDATA-SQL.*/

            public _REDEF_EM8051B_FILLER_56()
            {
                WDAT_REL_ANO.ValueChanged += OnValueChanged;
                WDAT_REL_HIFEN_1.ValueChanged += OnValueChanged;
                WDAT_REL_MES.ValueChanged += OnValueChanged;
                WDAT_REL_HIFEN_2.ValueChanged += OnValueChanged;
                WDAT_REL_DIA.ValueChanged += OnValueChanged;
            }

        }
        public EM8051B_WDATA_SQL WDATA_SQL { get; set; } = new EM8051B_WDATA_SQL();
        public class EM8051B_WDATA_SQL : VarBasis
        {
            /*"    05       WDATA-AA-SQL      PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WDATA_AA_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '-'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05       WDATA-MM-SQL      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '-'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05       WDATA-DD-SQL      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_DD_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03         WDATA-CABEC.*/
        }
        public EM8051B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8051B_WDATA_CABEC();
        public class EM8051B_WDATA_CABEC : VarBasis
        {
            /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01 WS-NUM-OCORR-MOVTO          PIC S9(18)V USAGE COMP-3.*/
        }
        public DoubleBasis WS_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"01  ABEN.*/
        public EM8051B_ABEN ABEN { get; set; } = new EM8051B_ABEN();
        public class EM8051B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8051B_WABEND WABEND { get; set; } = new EM8051B_WABEND();
            public class EM8051B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8051B  '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8051B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8051B_WABEND1 WABEND1 { get; set; } = new EM8051B_WABEND1();
            public class EM8051B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          HEA-REGISTRO.*/
            }
        }
        public EM8051B_HEA_REGISTRO HEA_REGISTRO { get; set; } = new EM8051B_HEA_REGISTRO();
        public class EM8051B_HEA_REGISTRO : VarBasis
        {
            /*"  05        HEA-TIPREG             PIC  9(002).*/
            public IntBasis HEA_TIPREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        HEA-SEQREG             PIC  9(009).*/
            public IntBasis HEA_SEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        HEA-DATPRO             PIC  X(008).*/
            public StringBasis HEA_DATPRO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        HEA-EMPRESA            PIC  X(004).*/
            public StringBasis HEA_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05        HEA-NSASAP             PIC  9(009).*/
            public IntBasis HEA_NSASAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        FILLER                 PIC  X(468).*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "468", "X(468)."), @"");
            /*"01          DET-REGISTRO.*/
        }
        public EM8051B_DET_REGISTRO DET_REGISTRO { get; set; } = new EM8051B_DET_REGISTRO();
        public class EM8051B_DET_REGISTRO : VarBasis
        {
            /*"  05        DET-TIPREG             PIC  9(002).*/
            public IntBasis DET_TIPREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        DET-SEQREG             PIC  9(009).*/
            public IntBasis DET_SEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        DET-IDLG               PIC  X(040).*/
            public StringBasis DET_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        DET-AUGST              PIC  X(001).*/
            public StringBasis DET_AUGST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05        DET-AUGRD              PIC  9(002).*/
            public IntBasis DET_AUGRD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        DET-BELNR              PIC  X(010).*/
            public StringBasis DET_BELNR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        DET-BUZEI              PIC  9(003).*/
            public IntBasis DET_BUZEI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05        DET-OPBEL              PIC  X(012).*/
            public StringBasis DET_OPBEL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"  05        DET-OPUPK              PIC  9(004).*/
            public IntBasis DET_OPUPK { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        DET-AUGBL              PIC  X(012).*/
            public StringBasis DET_AUGBL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"  05        DET-AUGVD              PIC  9(008).*/
            public IntBasis DET_AUGVD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05        DET-BLART              PIC  X(002).*/
            public StringBasis DET_BLART { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        DET-BLDAT              PIC  X(008).*/
            public StringBasis DET_BLDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        DET-BUDAT              PIC  X(008).*/
            public StringBasis DET_BUDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        DET-BUKRS              PIC  X(004).*/
            public StringBasis DET_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05        DET-NSA-BCO            PIC  9(006).*/
            public IntBasis DET_NSA_BCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05        DET-REG1.*/
            public EM8051B_DET_REG1 DET_REG1 { get; set; } = new EM8051B_DET_REG1();
            public class EM8051B_DET_REG1 : VarBasis
            {
                /*"   10       DET1-CGCCPF            PIC  X(020).*/
                public StringBasis DET1_CGCCPF { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET1-EVENTO            PIC  X(010).*/
                public StringBasis DET1_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET1-VLR-BRUTO         PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-IRRF          PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-ISS           PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-INSS          PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-COFINS        PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_COFINS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-CSLL          PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_CSLL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-PIS           PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_PIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-VLR-PG-REC        PIC  9(013)V99.*/
                public DoubleBasis DET1_VLR_PG_REC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET1-DT-MOVTO          PIC  X(008).*/
                public StringBasis DET1_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET1-DT-ENVIO          PIC  X(008).*/
                public StringBasis DET1_DT_ENVIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET1-DT-CONTABIL       PIC  X(008).*/
                public StringBasis DET1_DT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET1-MEIO-PAGTO        PIC  X(001).*/
                public StringBasis DET1_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10       DET1-NRO-CHQ-INT       PIC  X(013).*/
                public StringBasis DET1_NRO_CHQ_INT { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"   10       DET1-NRO-SIVAT         PIC  9(009).*/
                public IntBasis DET1_NRO_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"   10       DET1-OCORRENCIA        PIC  X(010).*/
                public StringBasis DET1_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       FILLER                 PIC  X(162).*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "162", "X(162)."), @"");
                /*"  05        DET-REG2     REDEFINES   DET-REG1.*/
            }
            private _REDEF_EM8051B_DET_REG2 _det_reg2 { get; set; }
            public _REDEF_EM8051B_DET_REG2 DET_REG2
            {
                get { _det_reg2 = new _REDEF_EM8051B_DET_REG2(); _.Move(DET_REG1, _det_reg2); VarBasis.RedefinePassValue(DET_REG1, _det_reg2, DET_REG1); _det_reg2.ValueChanged += () => { _.Move(_det_reg2, DET_REG1); }; return _det_reg2; }
                set { VarBasis.RedefinePassValue(value, _det_reg2, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG2 : VarBasis
            {
                /*"   10       DET2-DT-MOVTO           PIC  X(008).*/
                public StringBasis DET2_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET2-COD-CONV           PIC  9(006).*/
                public IntBasis DET2_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET2-COD-BCO            PIC  9(003).*/
                public IntBasis DET2_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET2-COD-AGE            PIC  9(005).*/
                public IntBasis DET2_COD_AGE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET2-DV-AGE             PIC  9(001).*/
                public IntBasis DET2_DV_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET2-OPCONTA.*/
                public EM8051B_DET2_OPCONTA DET2_OPCONTA { get; set; } = new EM8051B_DET2_OPCONTA();
                public class EM8051B_DET2_OPCONTA : VarBasis
                {
                    /*"     15     DET2-TIP-CONTA          PIC  9(004).*/
                    public IntBasis DET2_TIP_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15     DET2-NRO-CONTA          PIC  9(008).*/
                    public IntBasis DET2_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"   10       DET2-TESTE   REDEFINES  DET2-OPCONTA.*/

                    public EM8051B_DET2_OPCONTA()
                    {
                        DET2_TIP_CONTA.ValueChanged += OnValueChanged;
                        DET2_NRO_CONTA.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_DET2_TESTE _det2_teste { get; set; }
                public _REDEF_EM8051B_DET2_TESTE DET2_TESTE
                {
                    get { _det2_teste = new _REDEF_EM8051B_DET2_TESTE(); _.Move(DET2_OPCONTA, _det2_teste); VarBasis.RedefinePassValue(DET2_OPCONTA, _det2_teste, DET2_OPCONTA); _det2_teste.ValueChanged += () => { _.Move(_det2_teste, DET2_OPCONTA); }; return _det2_teste; }
                    set { VarBasis.RedefinePassValue(value, _det2_teste, DET2_OPCONTA); }
                }  //Redefines
                public class _REDEF_EM8051B_DET2_TESTE : VarBasis
                {
                    /*"     15     DET2-FILLER             PIC  9(003).*/
                    public IntBasis DET2_FILLER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"     15     DET2-CONTA-TESTE        PIC  9(009).*/
                    public IntBasis DET2_CONTA_TESTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"   10       DET2-NSGD    REDEFINES  DET2-OPCONTA                                    PIC  9(012).*/

                    public _REDEF_EM8051B_DET2_TESTE()
                    {
                        DET2_FILLER.ValueChanged += OnValueChanged;
                        DET2_CONTA_TESTE.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_IntBasis _det2_nsgd { get; set; }
                public _REDEF_IntBasis DET2_NSGD
                {
                    get { _det2_nsgd = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(DET2_OPCONTA, _det2_nsgd); VarBasis.RedefinePassValue(DET2_OPCONTA, _det2_nsgd, DET2_OPCONTA); _det2_nsgd.ValueChanged += () => { _.Move(_det2_nsgd, DET2_OPCONTA); }; return _det2_nsgd; }
                    set { VarBasis.RedefinePassValue(value, _det2_nsgd, DET2_OPCONTA); }
                }  //Redefines
                /*"   10       DET2-DV-CTA             PIC  9(001).*/
                public IntBasis DET2_DV_CTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET2-DT-EFETIV          PIC  X(008).*/
                public StringBasis DET2_DT_EFETIV { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET2-VLR-EFET           PIC  9(013)V99.*/
                public DoubleBasis DET2_VLR_EFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET2-OCORRENCIA         PIC  X(010).*/
                public StringBasis DET2_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET2-PROC-ADVERT        PIC  X(002).*/
                public StringBasis DET2_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET2-NIVE-ADVERT        PIC  X(002).*/
                public StringBasis DET2_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       FILLER                  PIC  X(296).*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "296", "X(296)."), @"");
                /*"  05        DET-REG3     REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG2()
                {
                    DET2_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET2_COD_CONV.ValueChanged += OnValueChanged;
                    DET2_COD_BCO.ValueChanged += OnValueChanged;
                    DET2_COD_AGE.ValueChanged += OnValueChanged;
                    DET2_DV_AGE.ValueChanged += OnValueChanged;
                    DET2_OPCONTA.ValueChanged += OnValueChanged;
                    DET2_TESTE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG3 _det_reg3 { get; set; }
            public _REDEF_EM8051B_DET_REG3 DET_REG3
            {
                get { _det_reg3 = new _REDEF_EM8051B_DET_REG3(); _.Move(DET_REG1, _det_reg3); VarBasis.RedefinePassValue(DET_REG1, _det_reg3, DET_REG1); _det_reg3.ValueChanged += () => { _.Move(_det_reg3, DET_REG1); }; return _det_reg3; }
                set { VarBasis.RedefinePassValue(value, _det_reg3, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG3 : VarBasis
            {
                /*"   10       DET3-DT-MOVTO           PIC  X(008).*/
                public StringBasis DET3_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET3-COD-CONV           PIC  9(004).*/
                public IntBasis DET3_COD_CONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET3-MOTIVO             PIC  X(002).*/
                public StringBasis DET3_MOTIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET3-COD-TRANS          PIC  9(003).*/
                public IntBasis DET3_COD_TRANS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET3-NRO-PARC           PIC  9(003).*/
                public IntBasis DET3_NRO_PARC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET3-NRO-CARTAO         PIC  X(019).*/
                public StringBasis DET3_NRO_CARTAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"   10       DET3-DT-VENCTO          PIC  X(008).*/
                public StringBasis DET3_DT_VENCTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET3-NOVO-NROCAR        PIC  X(019).*/
                public StringBasis DET3_NOVO_NROCAR { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"   10       DET3-NOVO-DIA-VENCTO    PIC  9(004).*/
                public IntBasis DET3_NOVO_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET3-DT-AGENDTO         PIC  X(008).*/
                public StringBasis DET3_DT_AGENDTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET3-MOTIVO-RET         PIC  X(002).*/
                public StringBasis DET3_MOTIVO_RET { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET3-MOTIVO-CANC        PIC  X(002).*/
                public StringBasis DET3_MOTIVO_CANC { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET3-VLR-CREDITO        PIC  9(013)V99.*/
                public DoubleBasis DET3_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET3-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET3_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET3-BANCO              PIC  9(003).*/
                public IntBasis DET3_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET3-AGENCIA            PIC  9(005).*/
                public IntBasis DET3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET3-CONTA              PIC  9(012).*/
                public IntBasis DET3_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"   10       DET3-VALOR              PIC  9(013)V99.*/
                public DoubleBasis DET3_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       FILLER                  PIC  X(222).*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "222", "X(222)."), @"");
                /*"  05        DET-REG4     REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG3()
                {
                    DET3_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET3_COD_CONV.ValueChanged += OnValueChanged;
                    DET3_MOTIVO.ValueChanged += OnValueChanged;
                    DET3_COD_TRANS.ValueChanged += OnValueChanged;
                    DET3_NRO_PARC.ValueChanged += OnValueChanged;
                    DET3_NRO_CARTAO.ValueChanged += OnValueChanged;
                    DET3_DT_VENCTO.ValueChanged += OnValueChanged;
                    DET3_NOVO_NROCAR.ValueChanged += OnValueChanged;
                    DET3_NOVO_DIA_VENCTO.ValueChanged += OnValueChanged;
                    DET3_DT_AGENDTO.ValueChanged += OnValueChanged;
                    DET3_MOTIVO_RET.ValueChanged += OnValueChanged;
                    DET3_MOTIVO_CANC.ValueChanged += OnValueChanged;
                    DET3_VLR_CREDITO.ValueChanged += OnValueChanged;
                    DET3_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET3_BANCO.ValueChanged += OnValueChanged;
                    DET3_AGENCIA.ValueChanged += OnValueChanged;
                    DET3_CONTA.ValueChanged += OnValueChanged;
                    DET3_VALOR.ValueChanged += OnValueChanged;
                    FILLER_69.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG4 _det_reg4 { get; set; }
            public _REDEF_EM8051B_DET_REG4 DET_REG4
            {
                get { _det_reg4 = new _REDEF_EM8051B_DET_REG4(); _.Move(DET_REG1, _det_reg4); VarBasis.RedefinePassValue(DET_REG1, _det_reg4, DET_REG1); _det_reg4.ValueChanged += () => { _.Move(_det_reg4, DET_REG1); }; return _det_reg4; }
                set { VarBasis.RedefinePassValue(value, _det_reg4, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG4 : VarBasis
            {
                /*"   10       DET4-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET4_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET4-COD-CONV           PIC  9(006).*/
                public IntBasis DET4_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET4-COD-BCO            PIC  9(003).*/
                public IntBasis DET4_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET4-COD-AGE            PIC  9(004).*/
                public IntBasis DET4_COD_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET4-OPCONTA.*/
                public EM8051B_DET4_OPCONTA DET4_OPCONTA { get; set; } = new EM8051B_DET4_OPCONTA();
                public class EM8051B_DET4_OPCONTA : VarBasis
                {
                    /*"     15     DET4-TIP-CONTA          PIC  9(003).*/
                    public IntBasis DET4_TIP_CONTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"     15     DET4-NRO-CONTA          PIC  9(008).*/
                    public IntBasis DET4_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"   10       DET4-TESTE   REDEFINES  DET4-OPCONTA.*/

                    public EM8051B_DET4_OPCONTA()
                    {
                        DET4_TIP_CONTA.ValueChanged += OnValueChanged;
                        DET4_NRO_CONTA.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8051B_DET4_TESTE _det4_teste { get; set; }
                public _REDEF_EM8051B_DET4_TESTE DET4_TESTE
                {
                    get { _det4_teste = new _REDEF_EM8051B_DET4_TESTE(); _.Move(DET4_OPCONTA, _det4_teste); VarBasis.RedefinePassValue(DET4_OPCONTA, _det4_teste, DET4_OPCONTA); _det4_teste.ValueChanged += () => { _.Move(_det4_teste, DET4_OPCONTA); }; return _det4_teste; }
                    set { VarBasis.RedefinePassValue(value, _det4_teste, DET4_OPCONTA); }
                }  //Redefines
                public class _REDEF_EM8051B_DET4_TESTE : VarBasis
                {
                    /*"     15     DET4-FILLER             PIC  9(002).*/
                    public IntBasis DET4_FILLER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"     15     DET4-CONTA-TESTE        PIC  9(009).*/
                    public IntBasis DET4_CONTA_TESTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"   10       DET4-NSGD    REDEFINES  DET4-OPCONTA                                    PIC  9(011).*/

                    public _REDEF_EM8051B_DET4_TESTE()
                    {
                        DET4_FILLER.ValueChanged += OnValueChanged;
                        DET4_CONTA_TESTE.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_IntBasis _det4_nsgd { get; set; }
                public _REDEF_IntBasis DET4_NSGD
                {
                    get { _det4_nsgd = new _REDEF_IntBasis(new PIC("9", "011", "9(011).")); ; _.Move(DET4_OPCONTA, _det4_nsgd); VarBasis.RedefinePassValue(DET4_OPCONTA, _det4_nsgd, DET4_OPCONTA); _det4_nsgd.ValueChanged += () => { _.Move(_det4_nsgd, DET4_OPCONTA); }; return _det4_nsgd; }
                    set { VarBasis.RedefinePassValue(value, _det4_nsgd, DET4_OPCONTA); }
                }  //Redefines
                /*"   10       DET4-DV-CONTA           PIC  9(001).*/
                public IntBasis DET4_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  9(003).*/
                public IntBasis FILLER_70 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET4-DT-DEBITO          PIC  X(008).*/
                public StringBasis DET4_DT_DEBITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET4-VLR-ORIGINAL       PIC  9(013)V99.*/
                public DoubleBasis DET4_VLR_ORIGINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET4-COD-RETORNO        PIC  X(002).*/
                public StringBasis DET4_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET4-COD-MOVTO          PIC  9(001).*/
                public IntBasis DET4_COD_MOVTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  X(307).*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "307", "X(307)."), @"");
                /*"  05        DET-REG5     REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG4()
                {
                    DET4_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET4_COD_CONV.ValueChanged += OnValueChanged;
                    DET4_COD_BCO.ValueChanged += OnValueChanged;
                    DET4_COD_AGE.ValueChanged += OnValueChanged;
                    DET4_OPCONTA.ValueChanged += OnValueChanged;
                    DET4_TESTE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG5 _det_reg5 { get; set; }
            public _REDEF_EM8051B_DET_REG5 DET_REG5
            {
                get { _det_reg5 = new _REDEF_EM8051B_DET_REG5(); _.Move(DET_REG1, _det_reg5); VarBasis.RedefinePassValue(DET_REG1, _det_reg5, DET_REG1); _det_reg5.ValueChanged += () => { _.Move(_det_reg5, DET_REG1); }; return _det_reg5; }
                set { VarBasis.RedefinePassValue(value, _det_reg5, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG5 : VarBasis
            {
                /*"   10       DET5-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET5_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-COD-BANCO          PIC  9(003).*/
                public IntBasis DET5_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-TP-INSCR           PIC  9(002).*/
                public IntBasis DET5_TP_INSCR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET5-NRO-INSCR          PIC  9(014).*/
                public IntBasis DET5_NRO_INSCR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET5-COD-CEDENTE        PIC  9(016).*/
                public IntBasis DET5_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       DET5-TITU-EMP           PIC  9(016).*/
                public IntBasis DET5_TITU_EMP { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       DET5-TITU-BCO           PIC  9(011).*/
                public IntBasis DET5_TITU_BCO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"   10       DET5-COD-REJ            PIC  9(003).*/
                public IntBasis DET5_COD_REJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-COD-OCORR          PIC  9(002).*/
                public IntBasis DET5_COD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET5-DT-OCORR           PIC  X(008).*/
                public StringBasis DET5_DT_OCORR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-DT-VENCTO          PIC  X(008).*/
                public StringBasis DET5_DT_VENCTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-VLR-NOMINAL        PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_NOMINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-COD-BCO-PAGTO      PIC  9(003).*/
                public IntBasis DET5_COD_BCO_PAGTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-AGE-PAGTO          PIC  9(004).*/
                public IntBasis DET5_AGE_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET5-DV-AGE-PAGTO       PIC  9(001).*/
                public IntBasis DET5_DV_AGE_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET5-ESPECIE            PIC  X(002).*/
                public StringBasis DET5_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET5-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-FORMA-LIQ          PIC  9(003).*/
                public IntBasis DET5_FORMA_LIQ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-FORMA-PAGTO        PIC  9(001).*/
                public IntBasis DET5_FORMA_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET5-QTD-DIAS-FLO       PIC  9(002).*/
                public IntBasis DET5_QTD_DIAS_FLO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET5-DT-DEB-TARIFA      PIC  X(008).*/
                public StringBasis DET5_DT_DEB_TARIFA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-VLR-IOF            PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-ABATIMEN       PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_ABATIMEN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-DESCTO         PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_DESCTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-PRINC          PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_PRINC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-JUROS          PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-MULTA          PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-COD-MOEDA          PIC  9(001).*/
                public IntBasis DET5_COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET5-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET5_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-FINANCEIRO         PIC  9(016).*/
                public IntBasis DET5_FINANCEIRO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       FILLER                  PIC  X(109).*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
                /*"  05        DET-REG6     REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG5()
                {
                    DET5_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET5_COD_BANCO.ValueChanged += OnValueChanged;
                    DET5_TP_INSCR.ValueChanged += OnValueChanged;
                    DET5_NRO_INSCR.ValueChanged += OnValueChanged;
                    DET5_COD_CEDENTE.ValueChanged += OnValueChanged;
                    DET5_TITU_EMP.ValueChanged += OnValueChanged;
                    DET5_TITU_BCO.ValueChanged += OnValueChanged;
                    DET5_COD_REJ.ValueChanged += OnValueChanged;
                    DET5_COD_OCORR.ValueChanged += OnValueChanged;
                    DET5_DT_OCORR.ValueChanged += OnValueChanged;
                    DET5_DT_VENCTO.ValueChanged += OnValueChanged;
                    DET5_VLR_NOMINAL.ValueChanged += OnValueChanged;
                    DET5_COD_BCO_PAGTO.ValueChanged += OnValueChanged;
                    DET5_AGE_PAGTO.ValueChanged += OnValueChanged;
                    DET5_DV_AGE_PAGTO.ValueChanged += OnValueChanged;
                    DET5_ESPECIE.ValueChanged += OnValueChanged;
                    DET5_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET5_FORMA_LIQ.ValueChanged += OnValueChanged;
                    DET5_FORMA_PAGTO.ValueChanged += OnValueChanged;
                    DET5_QTD_DIAS_FLO.ValueChanged += OnValueChanged;
                    DET5_DT_DEB_TARIFA.ValueChanged += OnValueChanged;
                    DET5_VLR_IOF.ValueChanged += OnValueChanged;
                    DET5_VLR_ABATIMEN.ValueChanged += OnValueChanged;
                    DET5_VLR_DESCTO.ValueChanged += OnValueChanged;
                    DET5_VLR_PRINC.ValueChanged += OnValueChanged;
                    DET5_VLR_JUROS.ValueChanged += OnValueChanged;
                    DET5_VLR_MULTA.ValueChanged += OnValueChanged;
                    DET5_COD_MOEDA.ValueChanged += OnValueChanged;
                    DET5_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET5_FINANCEIRO.ValueChanged += OnValueChanged;
                    FILLER_72.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG6 _det_reg6 { get; set; }
            public _REDEF_EM8051B_DET_REG6 DET_REG6
            {
                get { _det_reg6 = new _REDEF_EM8051B_DET_REG6(); _.Move(DET_REG1, _det_reg6); VarBasis.RedefinePassValue(DET_REG1, _det_reg6, DET_REG1); _det_reg6.ValueChanged += () => { _.Move(_det_reg6, DET_REG1); }; return _det_reg6; }
                set { VarBasis.RedefinePassValue(value, _det_reg6, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG6 : VarBasis
            {
                /*"   10       DET6-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET6_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET6-NRO-SIVPF          PIC  9(014).*/
                public IntBasis DET6_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET6-AGENCIA            PIC  9(004).*/
                public IntBasis DET6_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET6-OPERACAO           PIC  9(003).*/
                public IntBasis DET6_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET6-CONTA              PIC  9(008).*/
                public IntBasis DET6_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET6-DV-CONTA           PIC  9(001).*/
                public IntBasis DET6_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET6-VLR-PAGO           PIC  9(013)V99.*/
                public DoubleBasis DET6_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET6-VLR-BALCAO         PIC  9(013)V99.*/
                public DoubleBasis DET6_VLR_BALCAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET6-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET6_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET6-DT-PAGTO           PIC  X(008).*/
                public StringBasis DET6_DT_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET6-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET6_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       FILLER                  PIC  X(270).*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "270", "X(270)."), @"");
                /*"  05        DET-REG7     REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG6()
                {
                    DET6_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET6_NRO_SIVPF.ValueChanged += OnValueChanged;
                    DET6_AGENCIA.ValueChanged += OnValueChanged;
                    DET6_OPERACAO.ValueChanged += OnValueChanged;
                    DET6_CONTA.ValueChanged += OnValueChanged;
                    DET6_DV_CONTA.ValueChanged += OnValueChanged;
                    DET6_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET6_VLR_BALCAO.ValueChanged += OnValueChanged;
                    DET6_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET6_DT_PAGTO.ValueChanged += OnValueChanged;
                    DET6_DT_CREDITO.ValueChanged += OnValueChanged;
                    FILLER_73.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG7 _det_reg7 { get; set; }
            public _REDEF_EM8051B_DET_REG7 DET_REG7
            {
                get { _det_reg7 = new _REDEF_EM8051B_DET_REG7(); _.Move(DET_REG1, _det_reg7); VarBasis.RedefinePassValue(DET_REG1, _det_reg7, DET_REG1); _det_reg7.ValueChanged += () => { _.Move(_det_reg7, DET_REG1); }; return _det_reg7; }
                set { VarBasis.RedefinePassValue(value, _det_reg7, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG7 : VarBasis
            {
                /*"   10       DET7-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET7_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET7-COD-REMESSA        PIC  9(001).*/
                public IntBasis DET7_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET7-COD-CONV           PIC  9(006).*/
                public IntBasis DET7_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET7-NOME-EMPR          PIC  X(020).*/
                public StringBasis DET7_NOME_EMPR { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET7-COD-BCO            PIC  9(003).*/
                public IntBasis DET7_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET7-NOME-BCO           PIC  X(020).*/
                public StringBasis DET7_NOME_BCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET7-AGENCIA            PIC  9(004).*/
                public IntBasis DET7_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET7-OPERACAO           PIC  9(003).*/
                public IntBasis DET7_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET7-NRO-CONTA          PIC  9(008).*/
                public IntBasis DET7_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET7-DV-CONTA           PIC  9(001).*/
                public IntBasis DET7_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET7-DT-PAGTO           PIC  X(008).*/
                public StringBasis DET7_DT_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET7-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET7_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET7-BARRA01            PIC  X(016).*/
                public StringBasis DET7_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"   10       DET7-BANCO              PIC  9(003).*/
                public IntBasis DET7_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET7-BARRA02            PIC  X(005).*/
                public StringBasis DET7_BARRA02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"   10       DET7-NRO-SIVPF          PIC  9(013).*/
                public IntBasis DET7_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"   10       DET7-BARRA03            PIC  X(007).*/
                public StringBasis DET7_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"   10       DET7-VLR-PAGO           PIC  9(013)V99.*/
                public DoubleBasis DET7_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET7-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET7_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET7-VLR-TOT-PAGO       PIC  9(013)V99.*/
                public DoubleBasis DET7_VLR_TOT_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       FILLER                  PIC  X(190).*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "190", "X(190)."), @"");
                /*"  05        DET-REG9     REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG7()
                {
                    DET7_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET7_COD_REMESSA.ValueChanged += OnValueChanged;
                    DET7_COD_CONV.ValueChanged += OnValueChanged;
                    DET7_NOME_EMPR.ValueChanged += OnValueChanged;
                    DET7_COD_BCO.ValueChanged += OnValueChanged;
                    DET7_NOME_BCO.ValueChanged += OnValueChanged;
                    DET7_AGENCIA.ValueChanged += OnValueChanged;
                    DET7_OPERACAO.ValueChanged += OnValueChanged;
                    DET7_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET7_DV_CONTA.ValueChanged += OnValueChanged;
                    DET7_DT_PAGTO.ValueChanged += OnValueChanged;
                    DET7_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET7_BARRA01.ValueChanged += OnValueChanged;
                    DET7_BANCO.ValueChanged += OnValueChanged;
                    DET7_BARRA02.ValueChanged += OnValueChanged;
                    DET7_NRO_SIVPF.ValueChanged += OnValueChanged;
                    DET7_BARRA03.ValueChanged += OnValueChanged;
                    DET7_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET7_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET7_VLR_TOT_PAGO.ValueChanged += OnValueChanged;
                    FILLER_74.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG9 _det_reg9 { get; set; }
            public _REDEF_EM8051B_DET_REG9 DET_REG9
            {
                get { _det_reg9 = new _REDEF_EM8051B_DET_REG9(); _.Move(DET_REG1, _det_reg9); VarBasis.RedefinePassValue(DET_REG1, _det_reg9, DET_REG1); _det_reg9.ValueChanged += () => { _.Move(_det_reg9, DET_REG1); }; return _det_reg9; }
                set { VarBasis.RedefinePassValue(value, _det_reg9, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG9 : VarBasis
            {
                /*"   10       DET9-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET9_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-COD-CEDENTE        PIC  9(008).*/
                public IntBasis DET9_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET9-COD-CONVENIO       PIC  9(006).*/
                public IntBasis DET9_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET9-CGCCPF             PIC  9(014).*/
                public IntBasis DET9_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET9-COD-BCO            PIC  9(003).*/
                public IntBasis DET9_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET9-DIG-BCO            PIC  9(001).*/
                public IntBasis DET9_DIG_BCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-AGENCIA            PIC  9(004).*/
                public IntBasis DET9_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET9-DIG-AGE            PIC  9(001).*/
                public IntBasis DET9_DIG_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-NRO-CONTA          PIC  9(008).*/
                public IntBasis DET9_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET9-DV-CONTA           PIC  9(001).*/
                public IntBasis DET9_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-CONTROLE           PIC  X(025).*/
                public StringBasis DET9_CONTROLE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"   10       DET9-NRO-TITULO         PIC  9(011).*/
                public IntBasis DET9_NRO_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"   10       DET9-DIG-TITULO         PIC  9(001).*/
                public IntBasis DET9_DIG_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-NRPARCEL           PIC  9(002).*/
                public IntBasis DET9_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-DIAS-CALC          PIC  9(004).*/
                public IntBasis DET9_DIAS_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET9-MOTIVO             PIC  9(002).*/
                public IntBasis DET9_MOTIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-PREFIXO            PIC  X(003).*/
                public StringBasis DET9_PREFIXO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"   10       DET9-VARIACAO           PIC  9(003).*/
                public IntBasis DET9_VARIACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET9-TAXA-DESCONTO      PIC  9(003)V99.*/
                public DoubleBasis DET9_TAXA_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"   10       DET9-TAXA-IOF           PIC  9(001)V9999.*/
                public DoubleBasis DET9_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "9(001)V9999."), 4);
                /*"   10       DET9-CARTEIRA           PIC  9(002).*/
                public IntBasis DET9_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-COMANDO            PIC  9(002).*/
                public IntBasis DET9_COMANDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-DT-LIQUIDA         PIC  X(008).*/
                public StringBasis DET9_DT_LIQUIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-SEU-NUMERO         PIC  X(010).*/
                public StringBasis DET9_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET9-DT-VENCTO          PIC  X(008).*/
                public StringBasis DET9_DT_VENCTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-VALOR-TITULO       PIC  9(013)V99.*/
                public DoubleBasis DET9_VALOR_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-BANCO              PIC  9(003).*/
                public IntBasis DET9_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET9-AGE-COBR           PIC  9(004).*/
                public IntBasis DET9_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET9-DIG-COBR           PIC  9(001).*/
                public IntBasis DET9_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-ESPECIE            PIC  9(002).*/
                public IntBasis DET9_ESPECIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET9_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET9_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-OUT-DESPESAS       PIC  9(013)V99.*/
                public DoubleBasis DET9_OUT_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-JUROS              PIC  9(013)V99.*/
                public DoubleBasis DET9_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-VALOR-IOF          PIC  9(013)V99.*/
                public DoubleBasis DET9_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-ABATIMENTO         PIC  9(013)V99.*/
                public DoubleBasis DET9_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-DESCONTO           PIC  9(013)V99.*/
                public DoubleBasis DET9_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-VLR-RECEBIDO       PIC  9(013)V99.*/
                public DoubleBasis DET9_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-MORA               PIC  9(013)V99.*/
                public DoubleBasis DET9_MORA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-OUT-RECEBE         PIC  9(013)V99.*/
                public DoubleBasis DET9_OUT_RECEBE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-VLR-LANCADO        PIC  9(013)V99.*/
                public DoubleBasis DET9_VLR_LANCADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-INDICA-VLR         PIC  9(001).*/
                public IntBasis DET9_INDICA_VLR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  X(040).*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05        DET-REG11    REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG9()
                {
                    DET9_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET9_COD_CEDENTE.ValueChanged += OnValueChanged;
                    DET9_COD_CONVENIO.ValueChanged += OnValueChanged;
                    DET9_CGCCPF.ValueChanged += OnValueChanged;
                    DET9_COD_BCO.ValueChanged += OnValueChanged;
                    DET9_DIG_BCO.ValueChanged += OnValueChanged;
                    DET9_AGENCIA.ValueChanged += OnValueChanged;
                    DET9_DIG_AGE.ValueChanged += OnValueChanged;
                    DET9_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET9_DV_CONTA.ValueChanged += OnValueChanged;
                    DET9_CONTROLE.ValueChanged += OnValueChanged;
                    DET9_NRO_TITULO.ValueChanged += OnValueChanged;
                    DET9_DIG_TITULO.ValueChanged += OnValueChanged;
                    DET9_NRPARCEL.ValueChanged += OnValueChanged;
                    DET9_DIAS_CALC.ValueChanged += OnValueChanged;
                    DET9_MOTIVO.ValueChanged += OnValueChanged;
                    DET9_PREFIXO.ValueChanged += OnValueChanged;
                    DET9_VARIACAO.ValueChanged += OnValueChanged;
                    DET9_TAXA_DESCONTO.ValueChanged += OnValueChanged;
                    DET9_TAXA_IOF.ValueChanged += OnValueChanged;
                    DET9_CARTEIRA.ValueChanged += OnValueChanged;
                    DET9_COMANDO.ValueChanged += OnValueChanged;
                    DET9_DT_LIQUIDA.ValueChanged += OnValueChanged;
                    DET9_SEU_NUMERO.ValueChanged += OnValueChanged;
                    DET9_DT_VENCTO.ValueChanged += OnValueChanged;
                    DET9_VALOR_TITULO.ValueChanged += OnValueChanged;
                    DET9_BANCO.ValueChanged += OnValueChanged;
                    DET9_AGE_COBR.ValueChanged += OnValueChanged;
                    DET9_DIG_COBR.ValueChanged += OnValueChanged;
                    DET9_ESPECIE.ValueChanged += OnValueChanged;
                    DET9_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET9_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET9_OUT_DESPESAS.ValueChanged += OnValueChanged;
                    DET9_JUROS.ValueChanged += OnValueChanged;
                    DET9_VALOR_IOF.ValueChanged += OnValueChanged;
                    DET9_ABATIMENTO.ValueChanged += OnValueChanged;
                    DET9_DESCONTO.ValueChanged += OnValueChanged;
                    DET9_VLR_RECEBIDO.ValueChanged += OnValueChanged;
                    DET9_MORA.ValueChanged += OnValueChanged;
                    DET9_OUT_RECEBE.ValueChanged += OnValueChanged;
                    DET9_VLR_LANCADO.ValueChanged += OnValueChanged;
                    DET9_INDICA_VLR.ValueChanged += OnValueChanged;
                    FILLER_75.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG11 _det_reg11 { get; set; }
            public _REDEF_EM8051B_DET_REG11 DET_REG11
            {
                get { _det_reg11 = new _REDEF_EM8051B_DET_REG11(); _.Move(DET_REG1, _det_reg11); VarBasis.RedefinePassValue(DET_REG1, _det_reg11, DET_REG1); _det_reg11.ValueChanged += () => { _.Move(_det_reg11, DET_REG1); }; return _det_reg11; }
                set { VarBasis.RedefinePassValue(value, _det_reg11, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG11 : VarBasis
            {
                /*"   10       DET11-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET11_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET11-USO-EMPRESA.*/
                public EM8051B_DET11_USO_EMPRESA DET11_USO_EMPRESA { get; set; } = new EM8051B_DET11_USO_EMPRESA();
                public class EM8051B_DET11_USO_EMPRESA : VarBasis
                {
                    /*"     15     DET11-USO-PARTE01        PIC  9(010).*/
                    public IntBasis DET11_USO_PARTE01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"     15     DET11-NRO-SIVPF          PIC  9(015).*/
                    public IntBasis DET11_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"   10       DET11-AGENCIA            PIC  9(004).*/

                    public EM8051B_DET11_USO_EMPRESA()
                    {
                        DET11_USO_PARTE01.ValueChanged += OnValueChanged;
                        DET11_NRO_SIVPF.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DET11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET11-OPERACAO           PIC  9(003).*/
                public IntBasis DET11_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET11-NRO-CONTA          PIC  9(008).*/
                public IntBasis DET11_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET11-DV-CONTA           PIC  9(001).*/
                public IntBasis DET11_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET11-VLR-PAGO           PIC  9(013)V99.*/
                public DoubleBasis DET11_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET11-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET11_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET11-DT-PAGTO           PIC  X(008).*/
                public StringBasis DET11_DT_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET11-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET11_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       FILLER                   PIC  X(274).*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "274", "X(274)."), @"");
                /*"  05        DET-REG12    REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG11()
                {
                    DET11_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET11_USO_EMPRESA.ValueChanged += OnValueChanged;
                    DET11_AGENCIA.ValueChanged += OnValueChanged;
                    DET11_OPERACAO.ValueChanged += OnValueChanged;
                    DET11_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET11_DV_CONTA.ValueChanged += OnValueChanged;
                    DET11_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET11_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET11_DT_PAGTO.ValueChanged += OnValueChanged;
                    DET11_DT_CREDITO.ValueChanged += OnValueChanged;
                    FILLER_76.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG12 _det_reg12 { get; set; }
            public _REDEF_EM8051B_DET_REG12 DET_REG12
            {
                get { _det_reg12 = new _REDEF_EM8051B_DET_REG12(); _.Move(DET_REG1, _det_reg12); VarBasis.RedefinePassValue(DET_REG1, _det_reg12, DET_REG1); _det_reg12.ValueChanged += () => { _.Move(_det_reg12, DET_REG1); }; return _det_reg12; }
                set { VarBasis.RedefinePassValue(value, _det_reg12, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG12 : VarBasis
            {
                /*"   10       DET12-DT-MOVTO           PIC  X(008).*/
                public StringBasis DET12_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET12-CONVENIO           PIC  9(006).*/
                public IntBasis DET12_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET12-BANCO              PIC  9(003).*/
                public IntBasis DET12_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET12-NUMCONTA           PIC  X(019).*/
                public StringBasis DET12_NUMCONTA { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"   10       DET12-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET12_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET12-VLR-PARCELA        PIC  9(013)V99.*/
                public DoubleBasis DET12_VLR_PARCELA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET12-COD-ERRO           PIC  9(002).*/
                public IntBasis DET12_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       FILLER                   PIC  X(308).*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "308", "X(308)."), @"");
                /*"  05        DET-REG13    REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG12()
                {
                    DET12_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET12_CONVENIO.ValueChanged += OnValueChanged;
                    DET12_BANCO.ValueChanged += OnValueChanged;
                    DET12_NUMCONTA.ValueChanged += OnValueChanged;
                    DET12_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET12_VLR_PARCELA.ValueChanged += OnValueChanged;
                    DET12_COD_ERRO.ValueChanged += OnValueChanged;
                    FILLER_77.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG13 _det_reg13 { get; set; }
            public _REDEF_EM8051B_DET_REG13 DET_REG13
            {
                get { _det_reg13 = new _REDEF_EM8051B_DET_REG13(); _.Move(DET_REG1, _det_reg13); VarBasis.RedefinePassValue(DET_REG1, _det_reg13, DET_REG1); _det_reg13.ValueChanged += () => { _.Move(_det_reg13, DET_REG1); }; return _det_reg13; }
                set { VarBasis.RedefinePassValue(value, _det_reg13, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG13 : VarBasis
            {
                /*"   10       DET13-NUM-PROPOSTA      PIC  X(016).*/
                public StringBasis DET13_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"   10       DET13-NUM-BOL-INTERNO   PIC  X(010).*/
                public StringBasis DET13_NUM_BOL_INTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET13-NN-REGISTRADO     PIC  X(018).*/
                public StringBasis DET13_NN_REGISTRADO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                /*"   10       DET13-LNHA-DIGITAVEL    PIC  X(054).*/
                public StringBasis DET13_LNHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
                /*"   10       DET13-COD-AG-CEDENTE    PIC  X(020).*/
                public StringBasis DET13_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET13-NUM-BCO-RECEB     PIC  9(003).*/
                public IntBasis DET13_NUM_BCO_RECEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET13-NUM-AGE-RECEB     PIC  9(005).*/
                public IntBasis DET13_NUM_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET13-DV-AGE-RECEB      PIC  9(001).*/
                public IntBasis DET13_DV_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET13-DTA-VENCIMENTO    PIC  X(008).*/
                public StringBasis DET13_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-DTA-PAGAMENTO     PIC  X(008).*/
                public StringBasis DET13_DTA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-DTA-CREDITO       PIC  X(008).*/
                public StringBasis DET13_DTA_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-DTA-DEB-TARIFA    PIC  X(008).*/
                public StringBasis DET13_DTA_DEB_TARIFA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-VLR-ACRESCIMO     PIC  9(015).*/
                public IntBasis DET13_VLR_ACRESCIMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-DESCONTO      PIC  9(015).*/
                public IntBasis DET13_VLR_DESCONTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-ABATIMENTO    PIC  9(015).*/
                public IntBasis DET13_VLR_ABATIMENTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-IOF           PIC  9(015).*/
                public IntBasis DET13_VLR_IOF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-PAGO          PIC  9(015).*/
                public IntBasis DET13_VLR_PAGO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-LIQUIDO       PIC  9(015).*/
                public IntBasis DET13_VLR_LIQUIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-TARIFA        PIC  9(015).*/
                public IntBasis DET13_VLR_TARIFA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-COD-MOVIMENTO     PIC  9(002).*/
                public IntBasis DET13_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET13-COD-REJEICAO      PIC  X(010).*/
                public StringBasis DET13_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       FILLER                  PIC  X(093).*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "93", "X(093)."), @"");
                /*"  05        DET-REG14    REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG13()
                {
                    DET13_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                    DET13_NUM_BOL_INTERNO.ValueChanged += OnValueChanged;
                    DET13_NN_REGISTRADO.ValueChanged += OnValueChanged;
                    DET13_LNHA_DIGITAVEL.ValueChanged += OnValueChanged;
                    DET13_COD_AG_CEDENTE.ValueChanged += OnValueChanged;
                    DET13_NUM_BCO_RECEB.ValueChanged += OnValueChanged;
                    DET13_NUM_AGE_RECEB.ValueChanged += OnValueChanged;
                    DET13_DV_AGE_RECEB.ValueChanged += OnValueChanged;
                    DET13_DTA_VENCIMENTO.ValueChanged += OnValueChanged;
                    DET13_DTA_PAGAMENTO.ValueChanged += OnValueChanged;
                    DET13_DTA_CREDITO.ValueChanged += OnValueChanged;
                    DET13_DTA_DEB_TARIFA.ValueChanged += OnValueChanged;
                    DET13_VLR_ACRESCIMO.ValueChanged += OnValueChanged;
                    DET13_VLR_DESCONTO.ValueChanged += OnValueChanged;
                    DET13_VLR_ABATIMENTO.ValueChanged += OnValueChanged;
                    DET13_VLR_IOF.ValueChanged += OnValueChanged;
                    DET13_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET13_VLR_LIQUIDO.ValueChanged += OnValueChanged;
                    DET13_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET13_COD_MOVIMENTO.ValueChanged += OnValueChanged;
                    DET13_COD_REJEICAO.ValueChanged += OnValueChanged;
                    FILLER_78.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG14 _det_reg14 { get; set; }
            public _REDEF_EM8051B_DET_REG14 DET_REG14
            {
                get { _det_reg14 = new _REDEF_EM8051B_DET_REG14(); _.Move(DET_REG1, _det_reg14); VarBasis.RedefinePassValue(DET_REG1, _det_reg14, DET_REG1); _det_reg14.ValueChanged += () => { _.Move(_det_reg14, DET_REG1); }; return _det_reg14; }
                set { VarBasis.RedefinePassValue(value, _det_reg14, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG14 : VarBasis
            {
                /*"   10       DET14-DT-MOVTO                PIC  9(008).*/
                public IntBasis DET14_DT_MOVTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-NRO-PROPOSTA            PIC  9(016).*/
                public IntBasis DET14_NRO_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       DET14-NUM-COM-CIELO           PIC  9(010).*/
                public IntBasis DET14_NUM_COM_CIELO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"   10       DET14-COD-BCO-CRED            PIC  9(003).*/
                public IntBasis DET14_COD_BCO_CRED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET14-COD-AGE-CRED            PIC  9(005).*/
                public IntBasis DET14_COD_AGE_CRED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET14-NUM-CTA-CRED            PIC  9(012).*/
                public IntBasis DET14_NUM_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"   10       DET14-DIG-CTA-CRED            PIC  9(001).*/
                public IntBasis DET14_DIG_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET14-COD-CART-BANDEIRA       PIC  9(004).*/
                public IntBasis DET14_COD_CART_BANDEIRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET14-NUM-CARTAO              PIC  X(025).*/
                public StringBasis DET14_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"   10       DET14-COD-TOKEN-CARTAO        PIC  X(040).*/
                public StringBasis DET14_COD_TOKEN_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"   10       DET14-STA-CART-PADRAO-SAP     PIC  X(001).*/
                public StringBasis DET14_STA_CART_PADRAO_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10       DET14-COD-TID-CIELO           PIC  X(020).*/
                public StringBasis DET14_COD_TID_CIELO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET14-VLR-COBRANCA            PIC  9(013)V99.*/
                public DoubleBasis DET14_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET14-VLR-LIQUIDO             PIC  9(013)V99.*/
                public DoubleBasis DET14_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET14-VLR-TAX-ADM             PIC  9(013)V99.*/
                public DoubleBasis DET14_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET14-DTA-VENCIMENTO          PIC  9(008).*/
                public IntBasis DET14_DTA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-DT-CREDITO              PIC  9(008).*/
                public IntBasis DET14_DT_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-DT-DEBITO               PIC  9(008).*/
                public IntBasis DET14_DT_DEBITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-DTA-AJU-CAPTURA         PIC  9(008).*/
                public IntBasis DET14_DTA_AJU_CAPTURA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-COD-MOVIMENTO           PIC  X(002).*/
                public StringBasis DET14_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET14-COD-RETORNO             PIC  X(003).*/
                public StringBasis DET14_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"   10       DET14-PROC-ADVERT             PIC  X(002).*/
                public StringBasis DET14_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET14-NIVE-ADVERT             PIC  X(002).*/
                public StringBasis DET14_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       FILLER                        PIC  X(138).*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)."), @"");
                /*"  05        DET-CESTA    REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_REG14()
                {
                    DET14_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET14_NRO_PROPOSTA.ValueChanged += OnValueChanged;
                    DET14_NUM_COM_CIELO.ValueChanged += OnValueChanged;
                    DET14_COD_BCO_CRED.ValueChanged += OnValueChanged;
                    DET14_COD_AGE_CRED.ValueChanged += OnValueChanged;
                    DET14_NUM_CTA_CRED.ValueChanged += OnValueChanged;
                    DET14_DIG_CTA_CRED.ValueChanged += OnValueChanged;
                    DET14_COD_CART_BANDEIRA.ValueChanged += OnValueChanged;
                    DET14_NUM_CARTAO.ValueChanged += OnValueChanged;
                    DET14_COD_TOKEN_CARTAO.ValueChanged += OnValueChanged;
                    DET14_STA_CART_PADRAO_SAP.ValueChanged += OnValueChanged;
                    DET14_COD_TID_CIELO.ValueChanged += OnValueChanged;
                    DET14_VLR_COBRANCA.ValueChanged += OnValueChanged;
                    DET14_VLR_LIQUIDO.ValueChanged += OnValueChanged;
                    DET14_VLR_TAX_ADM.ValueChanged += OnValueChanged;
                    DET14_DTA_VENCIMENTO.ValueChanged += OnValueChanged;
                    DET14_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET14_DT_DEBITO.ValueChanged += OnValueChanged;
                    DET14_DTA_AJU_CAPTURA.ValueChanged += OnValueChanged;
                    DET14_COD_MOVIMENTO.ValueChanged += OnValueChanged;
                    DET14_COD_RETORNO.ValueChanged += OnValueChanged;
                    DET14_PROC_ADVERT.ValueChanged += OnValueChanged;
                    DET14_NIVE_ADVERT.ValueChanged += OnValueChanged;
                    FILLER_79.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_CESTA _det_cesta { get; set; }
            public _REDEF_EM8051B_DET_CESTA DET_CESTA
            {
                get { _det_cesta = new _REDEF_EM8051B_DET_CESTA(); _.Move(DET_REG1, _det_cesta); VarBasis.RedefinePassValue(DET_REG1, _det_cesta, DET_REG1); _det_cesta.ValueChanged += () => { _.Move(_det_cesta, DET_REG1); }; return _det_cesta; }
                set { VarBasis.RedefinePassValue(value, _det_cesta, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_CESTA : VarBasis
            {
                /*"   10       DET15-DT-GERACAO        PIC  9(008).*/
                public IntBasis DET15_DT_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET15-NUM-PROPPOSTA     PIC  9(014).*/
                public IntBasis DET15_NUM_PROPPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET15-AGENCIA-CLI       PIC  9(004).*/
                public IntBasis DET15_AGENCIA_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET15-OPERACAO-CLI      PIC  9(004).*/
                public IntBasis DET15_OPERACAO_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET15-CONTA-CLI         PIC  9(012).*/
                public IntBasis DET15_CONTA_CLI { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"   10       DET15-CONTA-DV-CLI      PIC  9(001).*/
                public IntBasis DET15_CONTA_DV_CLI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET15-VALOR-PAGO        PIC  9(013)V99.*/
                public DoubleBasis DET15_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET15-COD-RETORNO       PIC  9(003).*/
                public IntBasis DET15_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET15-MSG-RETORNO       PIC  X(045).*/
                public StringBasis DET15_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
                /*"   10       DET15-FILLER            PIC  X(263).*/
                public StringBasis DET15_FILLER { get; set; } = new StringBasis(new PIC("X", "263", "X(263)."), @"");
                /*"  05        DET-REG16    REDEFINES   DET-REG1.*/

                public _REDEF_EM8051B_DET_CESTA()
                {
                    DET15_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET15_NUM_PROPPOSTA.ValueChanged += OnValueChanged;
                    DET15_AGENCIA_CLI.ValueChanged += OnValueChanged;
                    DET15_OPERACAO_CLI.ValueChanged += OnValueChanged;
                    DET15_CONTA_CLI.ValueChanged += OnValueChanged;
                    DET15_CONTA_DV_CLI.ValueChanged += OnValueChanged;
                    DET15_VALOR_PAGO.ValueChanged += OnValueChanged;
                    DET15_COD_RETORNO.ValueChanged += OnValueChanged;
                    DET15_MSG_RETORNO.ValueChanged += OnValueChanged;
                    DET15_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8051B_DET_REG16 _det_reg16 { get; set; }
            public _REDEF_EM8051B_DET_REG16 DET_REG16
            {
                get { _det_reg16 = new _REDEF_EM8051B_DET_REG16(); _.Move(DET_REG1, _det_reg16); VarBasis.RedefinePassValue(DET_REG1, _det_reg16, DET_REG1); _det_reg16.ValueChanged += () => { _.Move(_det_reg16, DET_REG1); }; return _det_reg16; }
                set { VarBasis.RedefinePassValue(value, _det_reg16, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8051B_DET_REG16 : VarBasis
            {
                /*"   10       DET16-DT-MOVTO          PIC  X(008).*/
                public StringBasis DET16_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET16-COD-CONV          PIC  9(006).*/
                public IntBasis DET16_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET16-COD-BCO           PIC  9(003).*/
                public IntBasis DET16_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET16-COD-AGE           PIC  9(004).*/
                public IntBasis DET16_COD_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET16-OPE-CTA           PIC  9(003).*/
                public IntBasis DET16_OPE_CTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET16-NRO-CONTA         PIC  9(008).*/
                public IntBasis DET16_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET16-DV-CTA            PIC  9(001).*/
                public IntBasis DET16_DV_CTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  X(003).*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"   10       DET16-DT-DEBITO         PIC  X(008).*/
                public StringBasis DET16_DT_DEBITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET16-VLR-DEBITO        PIC  9(013)V99.*/
                public DoubleBasis DET16_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET16-COD-RETORNO       PIC  X(002).*/
                public StringBasis DET16_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET16-COD-MOVTO         PIC  X(001).*/
                public StringBasis DET16_COD_MOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10       DET16-PROC-ADVERT       PIC  X(002).*/
                public StringBasis DET16_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET16-NIVE-ADVERT       PIC  X(002).*/
                public StringBasis DET16_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       FILLER                  PIC  X(303).*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "303", "X(303)."), @"");
                /*"01          TRAI-REGISTRO.*/

                public _REDEF_EM8051B_DET_REG16()
                {
                    DET16_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET16_COD_CONV.ValueChanged += OnValueChanged;
                    DET16_COD_BCO.ValueChanged += OnValueChanged;
                    DET16_COD_AGE.ValueChanged += OnValueChanged;
                    DET16_OPE_CTA.ValueChanged += OnValueChanged;
                    DET16_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET16_DV_CTA.ValueChanged += OnValueChanged;
                    FILLER_80.ValueChanged += OnValueChanged;
                    DET16_DT_DEBITO.ValueChanged += OnValueChanged;
                    DET16_VLR_DEBITO.ValueChanged += OnValueChanged;
                    DET16_COD_RETORNO.ValueChanged += OnValueChanged;
                    DET16_COD_MOVTO.ValueChanged += OnValueChanged;
                    DET16_PROC_ADVERT.ValueChanged += OnValueChanged;
                    DET16_NIVE_ADVERT.ValueChanged += OnValueChanged;
                    FILLER_81.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8051B_TRAI_REGISTRO TRAI_REGISTRO { get; set; } = new EM8051B_TRAI_REGISTRO();
        public class EM8051B_TRAI_REGISTRO : VarBasis
        {
            /*"  05        TRAI-TIPREG            PIC  9(002).*/
            public IntBasis TRAI_TIPREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        TRAI-SEQREG            PIC  9(009).*/
            public IntBasis TRAI_SEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        TRAI-DT-PROC           PIC  X(008).*/
            public StringBasis TRAI_DT_PROC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        TRAI-TOT-REG           PIC  9(009).*/
            public IntBasis TRAI_TOT_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        FILLER                 PIC  X(472).*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "472", "X(472)."), @"");
            /*"01          WS-COD-AG-CEDENTE      PIC  X(020).*/
        }
        public StringBasis WS_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01 WS-CEDENTE-R REDEFINES WS-COD-AG-CEDENTE.*/
        private _REDEF_EM8051B_WS_CEDENTE_R _ws_cedente_r { get; set; }
        public _REDEF_EM8051B_WS_CEDENTE_R WS_CEDENTE_R
        {
            get { _ws_cedente_r = new _REDEF_EM8051B_WS_CEDENTE_R(); _.Move(WS_COD_AG_CEDENTE, _ws_cedente_r); VarBasis.RedefinePassValue(WS_COD_AG_CEDENTE, _ws_cedente_r, WS_COD_AG_CEDENTE); _ws_cedente_r.ValueChanged += () => { _.Move(_ws_cedente_r, WS_COD_AG_CEDENTE); }; return _ws_cedente_r; }
            set { VarBasis.RedefinePassValue(value, _ws_cedente_r, WS_COD_AG_CEDENTE); }
        }  //Redefines
        public class _REDEF_EM8051B_WS_CEDENTE_R : VarBasis
        {
            /*"   15       FILLER                 PIC  X(007).*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"   15       WS-COD-AGE-CED         PIC  9(004).*/
            public IntBasis WS_COD_AGE_CED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   15       FILLER                 PIC  X(001).*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   15       WS-COD-CEDENTE         PIC  9(006).*/
            public IntBasis WS_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   15       FILLER                 PIC  X(001).*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   15       WS-DV-CEDENTE          PIC  9(001).*/
            public IntBasis WS_DV_CEDENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        MOVCC-REGISTRO.*/

            public _REDEF_EM8051B_WS_CEDENTE_R()
            {
                FILLER_83.ValueChanged += OnValueChanged;
                WS_COD_AGE_CED.ValueChanged += OnValueChanged;
                FILLER_84.ValueChanged += OnValueChanged;
                WS_COD_CEDENTE.ValueChanged += OnValueChanged;
                FILLER_85.ValueChanged += OnValueChanged;
                WS_DV_CEDENTE.ValueChanged += OnValueChanged;
            }

        }
        public EM8051B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new EM8051B_MOVCC_REGISTRO();
        public class EM8051B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis MOVCC_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      MOVCC-CODBANCO           PIC  9(003) VALUE ZEROS.*/
            public IntBasis MOVCC_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      MOVCC-CONVENIO           PIC  9(006) VALUE ZEROS.*/
            public IntBasis MOVCC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      MOVCC-NSAS               PIC  9(005) VALUE ZEROS.*/
            public IntBasis MOVCC_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05      MOVCC-CONVENIO-SAP       PIC  9(006) VALUE ZEROS.*/
            public IntBasis MOVCC_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      MOVCC-NSAC               PIC  9(005) VALUE ZEROS.*/
            public IntBasis MOVCC_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05      MOVCC-DTGERACAO.*/
            public EM8051B_MOVCC_DTGERACAO MOVCC_DTGERACAO { get; set; } = new EM8051B_MOVCC_DTGERACAO();
            public class EM8051B_MOVCC_DTGERACAO : VarBasis
            {
                /*"    10    MOVCC-ANO-HEADER         PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    MOVCC-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      MOVCC-IDTCLIEMP          PIC  X(025) VALUE SPACES.*/
            }
            public StringBasis MOVCC_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05      MOVCC-IDTCLIBAN.*/
            public EM8051B_MOVCC_IDTCLIBAN MOVCC_IDTCLIBAN { get; set; } = new EM8051B_MOVCC_IDTCLIBAN();
            public class EM8051B_MOVCC_IDTCLIBAN : VarBasis
            {
                /*"    10    MOVCC-AGECONTA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-OPECONTA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-NUMCONTA           PIC  9(012) VALUE ZEROS.*/
                public IntBasis MOVCC_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"    10    MOVCC-DIGCONTA           PIC  9(001) VALUE ZEROS.*/
                public IntBasis MOVCC_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"    10    FILLER                   PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public EM8051B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new EM8051B_MOVCC_DTCREDITO();
            public class EM8051B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANO                PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-MES                PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    MOVCC-DIA                PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      MOVCC-VLDEBCRE           PIC  9(013)V99 VALUE ZEROS.*/
            }
            public DoubleBasis MOVCC_VLDEBCRE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      MOVCC-RETORNO            PIC  X(002) VALUE SPACES.*/
            public StringBasis MOVCC_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      FILLER              REDEFINES        MOVCC-RETORNO.*/
            private _REDEF_EM8051B_FILLER_87 _filler_87 { get; set; }
            public _REDEF_EM8051B_FILLER_87 FILLER_87
            {
                get { _filler_87 = new _REDEF_EM8051B_FILLER_87(); _.Move(MOVCC_RETORNO, _filler_87); VarBasis.RedefinePassValue(MOVCC_RETORNO, _filler_87, MOVCC_RETORNO); _filler_87.ValueChanged += () => { _.Move(_filler_87, MOVCC_RETORNO); }; return _filler_87; }
                set { VarBasis.RedefinePassValue(value, _filler_87, MOVCC_RETORNO); }
            }  //Redefines
            public class _REDEF_EM8051B_FILLER_87 : VarBasis
            {
                /*"    10    MOVCC-CODRET             PIC  9(002).*/
                public IntBasis MOVCC_CODRET { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-USOEMPRESA         PIC  X(060) VALUE SPACES.*/

                public _REDEF_EM8051B_FILLER_87()
                {
                    MOVCC_CODRET.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"  05      MOVCC-PROCE-ADVERT       PIC  X(002) VALUE SPACES.*/
            public StringBasis MOVCC_PROCE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      MOVCC-NIVEL-ADVERT       PIC  X(002) VALUE SPACES.*/
            public StringBasis MOVCC_NIVEL_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      MOVCC-MOTIV-COMPEN       PIC  9(002) VALUE ZEROS.*/
            public IntBasis MOVCC_MOTIV_COMPEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      FILLER                   PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05      MOVCC-CODMOV             PIC  9(001) VALUE ZEROS.*/
            public IntBasis MOVCC_CODMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05      MOVCC-IDLG               PIC  X(040) VALUE SPACES.*/
            public StringBasis MOVCC_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      MOVCC-RETSIACC           PIC  X(010) VALUE SPACES.*/
            public StringBasis MOVCC_RETSIACC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*" 01        REG-SICAP.*/
            public EM8051B_REG_SICAP REG_SICAP { get; set; } = new EM8051B_REG_SICAP();
            public class EM8051B_REG_SICAP : VarBasis
            {
                /*"   10      SICAP-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
                public StringBasis SICAP_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"   10      SICAP-BANCO              PIC  9(003) VALUE ZEROS.*/
                public IntBasis SICAP_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   10      SICAP-CONVENIO-SAP       PIC  9(006) VALUE ZEROS.*/
                public IntBasis SICAP_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   10      SICAP-NSAC               PIC  9(005) VALUE ZEROS.*/
                public IntBasis SICAP_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"   10      SICAP-DTGERACAO.*/
                public EM8051B_SICAP_DTGERACAO SICAP_DTGERACAO { get; set; } = new EM8051B_SICAP_DTGERACAO();
                public class EM8051B_SICAP_DTGERACAO : VarBasis
                {
                    /*"     15    SICAP-ANO-HEADER         PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICAP_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     15    SICAP-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     15    SICAP-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   10      SICAP-COD-REGISTRO       PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis SICAP_COD_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"   10      SICAP-AGENCIA            PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICAP_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   10      SICAP-OPERACAO           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICAP_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   10      SICAP-NUM-CONTA          PIC  9(012) VALUE ZEROS.*/
                public IntBasis SICAP_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"   10      SICAP-DIG-CONTA          PIC  9(001) VALUE ZEROS.*/
                public IntBasis SICAP_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   10      SICAP-DATA-PAGTO.*/
                public EM8051B_SICAP_DATA_PAGTO SICAP_DATA_PAGTO { get; set; } = new EM8051B_SICAP_DATA_PAGTO();
                public class EM8051B_SICAP_DATA_PAGTO : VarBasis
                {
                    /*"     15    SICAP-ANO-PAGTO          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICAP_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     15    SICAP-MES-PAGTO          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     15    SICAP-DIA-PAGTO          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   10      SICAP-DATA-CREDITO.*/
                }
                public EM8051B_SICAP_DATA_CREDITO SICAP_DATA_CREDITO { get; set; } = new EM8051B_SICAP_DATA_CREDITO();
                public class EM8051B_SICAP_DATA_CREDITO : VarBasis
                {
                    /*"     15    SICAP-ANO-CRED           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICAP_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     15    SICAP-MES-CRED           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     15    SICAP-DIA-CRED           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   10      SICAP-BARRA01            PIC  X(016) VALUE SPACES.*/
                }
                public StringBasis SICAP_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"   10      SICAP-CODBANCO           PIC  9(003) VALUE ZEROS.*/
                public IntBasis SICAP_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   10      SICAP-BARRA02            PIC  X(005) VALUE SPACES.*/
                public StringBasis SICAP_BARRA02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10      SICAP-NUM-SIVPF          PIC  9(013) VALUE ZEROS.*/
                public IntBasis SICAP_NUM_SIVPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"   10      SICAP-BARRA03            PIC  X(007) VALUE SPACES.*/
                public StringBasis SICAP_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"   10      SICAP-VALOR-PAGO         PIC  9(010)V99 VALUE ZEROS.*/
                public DoubleBasis SICAP_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
                /*"   10      SICAP-VALOR-TARIFA       PIC  9(005)V99 VALUE ZEROS.*/
                public DoubleBasis SICAP_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99"), 2);
                /*" 01        REG-SICA11.*/
            }
            public EM8051B_REG_SICA11 REG_SICA11 { get; set; } = new EM8051B_REG_SICA11();
            public class EM8051B_REG_SICA11 : VarBasis
            {
                /*"   05      SICA11-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SICA11_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      SICA11-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SICA11_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"   05      SICA11-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SICA11_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"   05      SICA11-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SICA11_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SICA11-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
                public IntBasis SICA11_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   05      SICA11-DTGERACAO.*/
                public EM8051B_SICA11_DTGERACAO SICA11_DTGERACAO { get; set; } = new EM8051B_SICA11_DTGERACAO();
                public class EM8051B_SICA11_DTGERACAO : VarBasis
                {
                    /*"     10    SICA11-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA11_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA11-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA11-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA11-USO-EMPRESA       PIC  X(025) VALUE SPACES.*/
                }
                public StringBasis SICA11_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"   05      SICA11-AGENCIA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICA11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05      SICA11-OPERACAO          PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICA11_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05      SICA11-NUM-CONTA         PIC  9(012) VALUE ZEROS.*/
                public IntBasis SICA11_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"   05      SICA11-DIG-CONTA         PIC  9(001) VALUE ZEROS.*/
                public IntBasis SICA11_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   05      SICA11-VALOR-PAGO        PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis SICA11_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA11-VALOR-TARIFA      PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis SICA11_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA11-DATA-PAGTO.*/
                public EM8051B_SICA11_DATA_PAGTO SICA11_DATA_PAGTO { get; set; } = new EM8051B_SICA11_DATA_PAGTO();
                public class EM8051B_SICA11_DATA_PAGTO : VarBasis
                {
                    /*"     10    SICA11-ANO-PAGTO         PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA11_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA11-MES-PAGTO         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA11-DIA-PAGTO         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA11-DATA-CREDITO.*/
                }
                public EM8051B_SICA11_DATA_CREDITO SICA11_DATA_CREDITO { get; set; } = new EM8051B_SICA11_DATA_CREDITO();
                public class EM8051B_SICA11_DATA_CREDITO : VarBasis
                {
                    /*"     10    SICA11-ANO-CRED          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA11_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA11-MES-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA11-DIA-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA11-FILLER            PIC  X(144).*/
                }
                public StringBasis SICA11_FILLER { get; set; } = new StringBasis(new PIC("X", "144", "X(144)."), @"");
                /*" 01        REG-SIGC13.*/
            }
            public EM8051B_REG_SIGC13 REG_SIGC13 { get; set; } = new EM8051B_REG_SIGC13();
            public class EM8051B_REG_SIGC13 : VarBasis
            {
                /*"   05      SIGC13-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SIGC13_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      SIGC13-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SIGC13_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"   05      SIGC13-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SIGC13_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"   05      SIGC13-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SIGC13_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SIGC13-NSAC              PIC  9(005) VALUE ZEROS.*/
                public IntBasis SIGC13_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"   05      SIGC13-RESTO.*/
                public EM8051B_SIGC13_RESTO SIGC13_RESTO { get; set; } = new EM8051B_SIGC13_RESTO();
                public class EM8051B_SIGC13_RESTO : VarBasis
                {
                    /*"      10   SIGC13-NUM-PROPOSTA      PIC  X(016) VALUE SPACES.*/
                    public StringBasis SIGC13_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                    /*"      10   SIGC13-NUM-BOL-INTERNO   PIC  X(010) VALUE SPACES.*/
                    public StringBasis SIGC13_NUM_BOL_INTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"      10   SIGC13-NN-REGISTRADO     PIC  X(018) VALUE SPACES.*/
                    public StringBasis SIGC13_NN_REGISTRADO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                    /*"      10   SIGC13-LNHA-DIGITAVEL    PIC  X(054) VALUE SPACES.*/
                    public StringBasis SIGC13_LNHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
                    /*"      10   SIGC13-COD-AG-CEDENTE    PIC  X(020) VALUE SPACES.*/
                    public StringBasis SIGC13_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                    /*"      10   SIGC13-NUM-BCO-RECEB     PIC  9(003) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_BCO_RECEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                    /*"      10   SIGC13-NUM-AGE-RECEB     PIC  9(005) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                    /*"      10   SIGC13-DV-AGE-RECEB      PIC  9(001) VALUE ZEROS.*/
                    public IntBasis SIGC13_DV_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"      10   SIGC13-DTA-VENCIMENTO.*/
                    public EM8051B_SIGC13_DTA_VENCIMENTO SIGC13_DTA_VENCIMENTO { get; set; } = new EM8051B_SIGC13_DTA_VENCIMENTO();
                    public class EM8051B_SIGC13_DTA_VENCIMENTO : VarBasis
                    {
                        /*"         15 SIGC13-DIA-VENCIMENTO   PIC  9(002) VALUE ZEROS.*/
                        public IntBasis SIGC13_DIA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                        /*"         15 SIGC13-MES-VENCIMENTO   PIC  9(002) VALUE ZEROS.*/
                        public IntBasis SIGC13_MES_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                        /*"         15 SIGC13-ANO-VENCIMENTO   PIC  9(004) VALUE ZEROS.*/
                        public IntBasis SIGC13_ANO_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                        /*"      10   SIGC13-DTA-PAGAMENTO     PIC  9(008) VALUE ZEROS.*/
                    }
                    public IntBasis SIGC13_DTA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   SIGC13-DTA-CREDITO       PIC  9(008) VALUE ZEROS.*/
                    public IntBasis SIGC13_DTA_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   SIGC13-DTA-DEB-TARIFA    PIC  9(008) VALUE ZEROS.*/
                    public IntBasis SIGC13_DTA_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   SIGC13-VLR-ACRESCIMO     PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_ACRESCIMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-DESCONTO      PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_DESCONTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-ABATIMENTO    PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_ABATIMENTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-IOF           PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_IOF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-PAGO          PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_PAGO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-LIQUIDO       PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_LIQUIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-TARIFA        PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_TARIFA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-COD-MOVIMENTO     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      10   SIGC13-COD-REJEICAO      PIC  X(010) VALUE SPACES.*/
                    public StringBasis SIGC13_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"      10   SIGC13-NUM-TITULO        PIC  9(016) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
                    /*"      10   SIGC13-COD-SISTEMA       PIC  X(003) VALUE SPACES.*/
                    public StringBasis SIGC13_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      10   SIGC13-NUM-PARCELA       PIC  9(003) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                    /*"      10   SIGC13-COD-PRODUTO       PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10   SIGC13-DTA-GERACAO       PIC  9(008) VALUE ZEROS.*/
                    public IntBasis SIGC13_DTA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   FILLER                   PIC  X(030) VALUE SPACES.*/
                    public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"01        REG-CESTA-HEAD.*/
                }
            }
        }
        public EM8051B_REG_CESTA_HEAD REG_CESTA_HEAD { get; set; } = new EM8051B_REG_CESTA_HEAD();
        public class EM8051B_REG_CESTA_HEAD : VarBasis
        {
            /*"  05      CESTA-H-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
            public StringBasis CESTA_H_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CESTA-H-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
            public IntBasis CESTA_H_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CESTA-H-DT-PROCESSA       PIC  X(008) VALUE SPACES.*/
            public StringBasis CESTA_H_DT_PROCESSA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CESTA-H-ORIG-EMP          PIC  X(004) VALUE SPACES.*/
            public StringBasis CESTA_H_ORIG_EMP { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      CESTA-H-NSA-SAP           PIC  9(009) VALUE ZEROS.*/
            public IntBasis CESTA_H_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CESTA-H-FILLER            PIC  X(268) VALUE SPACES.*/
            public StringBasis CESTA_H_FILLER { get; set; } = new StringBasis(new PIC("X", "268", "X(268)"), @"");
            /*"01        REG-CESTA-DET.*/
        }
        public EM8051B_REG_CESTA_DET REG_CESTA_DET { get; set; } = new EM8051B_REG_CESTA_DET();
        public class EM8051B_REG_CESTA_DET : VarBasis
        {
            /*"  05      CESTA-D-TIPO-REGISTRO     PIC  9(002) VALUE ZEROS.*/
            public IntBasis CESTA_D_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      CESTA-D-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
            public IntBasis CESTA_D_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CESTA-D-IDLG              PIC  X(040) VALUE SPACES.*/
            public StringBasis CESTA_D_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      CESTA-D-AUGST             PIC  X(001) VALUE SPACES.*/
            public StringBasis CESTA_D_AUGST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      CESTA-D-AUGRD             PIC  9(002) VALUE ZEROS.*/
            public IntBasis CESTA_D_AUGRD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      CESTA-D-BELNR             PIC  X(010) VALUE SPACES.*/
            public StringBasis CESTA_D_BELNR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CESTA-D-BUZEI             PIC  9(003) VALUE ZEROS.*/
            public IntBasis CESTA_D_BUZEI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CESTA-D-OPBEL             PIC  X(012) VALUE SPACES.*/
            public StringBasis CESTA_D_OPBEL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      CESTA-D-OPUPK             PIC  9(004) VALUE ZEROS.*/
            public IntBasis CESTA_D_OPUPK { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CESTA-D-AUGBL             PIC  X(012) VALUE SPACES.*/
            public StringBasis CESTA_D_AUGBL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      CESTA-D-AUGVD             PIC  9(008) VALUE ZEROS.*/
            public IntBasis CESTA_D_AUGVD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05      CESTA-D-BLART             PIC  X(002) VALUE SPACES.*/
            public StringBasis CESTA_D_BLART { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CESTA-D-BLDAT             PIC  X(008) VALUE SPACES.*/
            public StringBasis CESTA_D_BLDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CESTA-D-BUDAT             PIC  X(008) VALUE SPACES.*/
            public StringBasis CESTA_D_BUDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CESTA-D-BUKRS             PIC  X(004) VALUE SPACES.*/
            public StringBasis CESTA_D_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      CESTA-D-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis CESTA_D_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CESTA-D-DT-GERACAO        PIC  9(008) VALUE ZEROS.*/
            public IntBasis CESTA_D_DT_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05      CESTA-D-NUM-PROPOSTA      PIC  9(014) VALUE ZEROS.*/
            public IntBasis CESTA_D_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05      CESTA-D-AGENCIA-CLI       PIC  9(004) VALUE ZEROS.*/
            public IntBasis CESTA_D_AGENCIA_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CESTA-D-OPERACAO-CLI      PIC  9(004) VALUE ZEROS.*/
            public IntBasis CESTA_D_OPERACAO_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CESTA-D-CONTA-CLI         PIC  9(012) VALUE ZEROS.*/
            public IntBasis CESTA_D_CONTA_CLI { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"  05      CESTA-D-CONTA-DV-CLI      PIC  9(001) VALUE ZEROS.*/
            public IntBasis CESTA_D_CONTA_DV_CLI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05      CESTA-D-VALOR-PAGO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CESTA_D_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CESTA-D-COD-RETORNO       PIC  9(003) VALUE ZEROS.*/
            public IntBasis CESTA_D_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CESTA-D-MSG-RETORNO       PIC  X(045) VALUE SPACES.*/
            public StringBasis CESTA_D_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
            /*"  05      CESTA-H-FILLER            PIC  X(063) VALUE SPACES.*/
            public StringBasis CESTA_H_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "63", "X(063)"), @"");
            /*" 01        HEADER-SAIDA11.*/
            public EM8051B_HEADER_SAIDA11 HEADER_SAIDA11 { get; set; } = new EM8051B_HEADER_SAIDA11();
            public class EM8051B_HEADER_SAIDA11 : VarBasis
            {
                /*"   05      HEAD11-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis HEAD11_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      HEAD11-DTMOVTO.*/
                public EM8051B_HEAD11_DTMOVTO HEAD11_DTMOVTO { get; set; } = new EM8051B_HEAD11_DTMOVTO();
                public class EM8051B_HEAD11_DTMOVTO : VarBasis
                {
                    /*"     10    HEAD11-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis HEAD11_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    HEAD11-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD11_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    HEAD11-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD11_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      HEAD11-DESCRICAO         PIC  X(050) VALUE SPACES.*/
                }
                public StringBasis HEAD11_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*" 01        REG-SICA12.*/
            }
            public EM8051B_REG_SICA12 REG_SICA12 { get; set; } = new EM8051B_REG_SICA12();
            public class EM8051B_REG_SICA12 : VarBasis
            {
                /*"   05      SICA12-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SICA12_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      SICA12-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SICA12_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"   05      SICA12-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SICA12_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"   05      SICA12-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SICA12_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SICA12-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
                public IntBasis SICA12_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   05      SICA12-DTMOVTO.*/
                public EM8051B_SICA12_DTMOVTO SICA12_DTMOVTO { get; set; } = new EM8051B_SICA12_DTMOVTO();
                public class EM8051B_SICA12_DTMOVTO : VarBasis
                {
                    /*"     10    SICA12-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA12_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA12-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA12-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA12-VALOR-VENDA       PIC  9(013)V99 VALUE ZEROS.*/
                }
                public DoubleBasis SICA12_VALOR_VENDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA12-VALOR-PARCELA     PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis SICA12_VALOR_PARCELA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA12-DATA-CREDITO.*/
                public EM8051B_SICA12_DATA_CREDITO SICA12_DATA_CREDITO { get; set; } = new EM8051B_SICA12_DATA_CREDITO();
                public class EM8051B_SICA12_DATA_CREDITO : VarBasis
                {
                    /*"     10    SICA12-ANO-CRED          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA12_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA12-MES-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA12-DIA-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA12-BANCO             PIC  9(003) VALUE ZEROS.*/
                }
                public IntBasis SICA12_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   05      SICA12-BANCO-DV          PIC  9(001) VALUE ZEROS.*/
                public IntBasis SICA12_BANCO_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   05      SICA12-AGENCIA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICA12_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05      SICA12-STATUS            PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICA12_STATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05      SICA12-COD-ERRO          PIC  X(004) VALUE SPACES.*/
                public StringBasis SICA12_COD_ERRO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SICA12-FILLER            PIC  X(179).*/
                public StringBasis SICA12_FILLER { get; set; } = new StringBasis(new PIC("X", "179", "X(179)."), @"");
                /*" 01        HEADER-SAIDA12.*/
            }
            public EM8051B_HEADER_SAIDA12 HEADER_SAIDA12 { get; set; } = new EM8051B_HEADER_SAIDA12();
            public class EM8051B_HEADER_SAIDA12 : VarBasis
            {
                /*"   05      HEAD12-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis HEAD12_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      HEAD12-DTMOVTO.*/
                public EM8051B_HEAD12_DTMOVTO HEAD12_DTMOVTO { get; set; } = new EM8051B_HEAD12_DTMOVTO();
                public class EM8051B_HEAD12_DTMOVTO : VarBasis
                {
                    /*"     10    HEAD12-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis HEAD12_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    HEAD12-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD12_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    HEAD12-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD12_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      HEAD12-DESCRICAO         PIC  X(050) VALUE SPACES.*/
                }
                public StringBasis HEAD12_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"01        REG-SICOB.*/
            }
        }
        public EM8051B_REG_SICOB REG_SICOB { get; set; } = new EM8051B_REG_SICOB();
        public class EM8051B_REG_SICOB : VarBasis
        {
            /*"  10      SICOB-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis SICOB_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      SICOB-COD-REGISTRO       PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-TIPO-INSCRICAO     PIC  9(002) VALUE ZEROS.*/
            public IntBasis SICOB_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      SICOB-NUM-INSCRICAO      PIC  9(014) VALUE ZEROS.*/
            public IntBasis SICOB_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  10      SICOB-COD-CEDENTE        PIC  9(016) VALUE ZEROS.*/
            public IntBasis SICOB_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  10      SICOB-COD-BANCO          PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-NSAC               PIC  9(005) VALUE ZEROS.*/
            public IntBasis SICOB_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  10      SICOB-DTGERACAO.*/
            public EM8051B_SICOB_DTGERACAO SICOB_DTGERACAO { get; set; } = new EM8051B_SICOB_DTGERACAO();
            public class EM8051B_SICOB_DTGERACAO : VarBasis
            {
                /*"    15    SICOB-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-TITULO-EMPRESA     PIC  9(016) VALUE ZEROS.*/
            }
            public IntBasis SICOB_TITULO_EMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  10      SICOB-TITULO-BANCO       PIC  9(011) VALUE ZEROS.*/
            public IntBasis SICOB_TITULO_BANCO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  10      SICOB-COD-REJEICAO       PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_COD_REJEICAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-COD-OCORRENCIA     PIC  9(002) VALUE ZEROS.*/
            public IntBasis SICOB_COD_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      SICOB-DATA-OCORRENCIA.*/
            public EM8051B_SICOB_DATA_OCORRENCIA SICOB_DATA_OCORRENCIA { get; set; } = new EM8051B_SICOB_DATA_OCORRENCIA();
            public class EM8051B_SICOB_DATA_OCORRENCIA : VarBasis
            {
                /*"    15    SICOB-DIA-OCORR          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-OCORR          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-OCORR          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-DATA-VENCIMENTO.*/
            }
            public EM8051B_SICOB_DATA_VENCIMENTO SICOB_DATA_VENCIMENTO { get; set; } = new EM8051B_SICOB_DATA_VENCIMENTO();
            public class EM8051B_SICOB_DATA_VENCIMENTO : VarBasis
            {
                /*"    15    SICOB-DIA-VENCTO         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-VENCTO         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-VENCTO         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-VLR-NOMINAL-TIT    PIC  9(011)V99 VALUE ZEROS.*/
            }
            public DoubleBasis SICOB_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-COD-COMP-CAIXA     PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_COD_COMP_CAIXA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-AGE-COBR           PIC  9(004) VALUE ZEROS.*/
            public IntBasis SICOB_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      SICOB-AGE-DIG-COBR       PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-ESPECIE            PIC  X(002) VALUE SPACES.*/
            public StringBasis SICOB_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  10      SICOB-VLR-TARIFA         PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-FORMA-LIQUIDACAO   PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_FORMA_LIQUIDACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-FORMA-PAGAMENTO    PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_FORMA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-QTD-DIAS-FLOAT     PIC  9(002) VALUE ZEROS.*/
            public IntBasis SICOB_QTD_DIAS_FLOAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      SICOB-DATA-DEB-TARIFA.*/
            public EM8051B_SICOB_DATA_DEB_TARIFA SICOB_DATA_DEB_TARIFA { get; set; } = new EM8051B_SICOB_DATA_DEB_TARIFA();
            public class EM8051B_SICOB_DATA_DEB_TARIFA : VarBasis
            {
                /*"    15    SICOB-DIA-TARIFA         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-TARIFA         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-TARIFA         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-VLR-IOF            PIC  9(011)V99 VALUE ZEROS.*/
            }
            public DoubleBasis SICOB_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-ABATIMENTO     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-DESCONTO       PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-PRINCIPAL      PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-JUROS          PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-MULTA          PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-COD-MOEDA          PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-DATA-CREDITO.*/
            public EM8051B_SICOB_DATA_CREDITO SICOB_DATA_CREDITO { get; set; } = new EM8051B_SICOB_DATA_CREDITO();
            public class EM8051B_SICOB_DATA_CREDITO : VarBasis
            {
                /*"    15    SICOB-DIA-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-FINANCEIRO         PIC  9(016) VALUE ZEROS.*/
            }
            public IntBasis SICOB_FINANCEIRO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"01        REG-SIGPF.*/
        }
        public EM8051B_REG_SIGPF REG_SIGPF { get; set; } = new EM8051B_REG_SIGPF();
        public class EM8051B_REG_SIGPF : VarBasis
        {
            /*"  10      SIGPF-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis SIGPF_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      SIGPF-CONVENIO-SAP       PIC  9(006) VALUE ZEROS.*/
            public IntBasis SIGPF_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  10      SIGPF-NSAC               PIC  9(005) VALUE ZEROS.*/
            public IntBasis SIGPF_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  10      SIGPF-DTGERACAO.*/
            public EM8051B_SIGPF_DTGERACAO SIGPF_DTGERACAO { get; set; } = new EM8051B_SIGPF_DTGERACAO();
            public class EM8051B_SIGPF_DTGERACAO : VarBasis
            {
                /*"    15    SIGPF-ANO-HEADER         PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGPF_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    15    SIGPF-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SIGPF-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SIGPF-COD-REGISTRO       PIC  9(001) VALUE ZEROS.*/
            }
            public IntBasis SIGPF_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SIGPF-NUM-SIVPF          PIC  9(014) VALUE ZEROS.*/
            public IntBasis SIGPF_NUM_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  10      SIGPF-AGENCIA            PIC  9(004) VALUE ZEROS.*/
            public IntBasis SIGPF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      SIGPF-OPERACAO           PIC  9(004) VALUE ZEROS.*/
            public IntBasis SIGPF_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      SIGPF-NUM-CONTA          PIC  9(012) VALUE ZEROS.*/
            public IntBasis SIGPF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"  10      SIGPF-DIG-CONTA          PIC  9(001) VALUE ZEROS.*/
            public IntBasis SIGPF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SIGPF-VALOR-PAGO         PIC  9(012)V99 VALUE ZEROS.*/
            public DoubleBasis SIGPF_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
            /*"  10      SIGPF-VALOR-BALCAO       PIC  9(012)V99 VALUE ZEROS.*/
            public DoubleBasis SIGPF_VALOR_BALCAO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
            /*"  10      SIGPF-VALOR-TARIFA       PIC  9(012)V99 VALUE ZEROS.*/
            public DoubleBasis SIGPF_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
            /*"  10      SIGPF-DATA-PAGTO.*/
            public EM8051B_SIGPF_DATA_PAGTO SIGPF_DATA_PAGTO { get; set; } = new EM8051B_SIGPF_DATA_PAGTO();
            public class EM8051B_SIGPF_DATA_PAGTO : VarBasis
            {
                /*"    15    SIGPF-ANO-PAGTO          PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGPF_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    15    SIGPF-MES-PAGTO          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SIGPF-DIA-PAGTO          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SIGPF-DATA-CREDITO.*/
            }
            public EM8051B_SIGPF_DATA_CREDITO SIGPF_DATA_CREDITO { get; set; } = new EM8051B_SIGPF_DATA_CREDITO();
            public class EM8051B_SIGPF_DATA_CREDITO : VarBasis
            {
                /*"    15    SIGPF-ANO-CRED           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGPF_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    15    SIGPF-MES-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SIGPF-DIA-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01        REG-CARTAO.*/
            }
        }
        public EM8051B_REG_CARTAO REG_CARTAO { get; set; } = new EM8051B_REG_CARTAO();
        public class EM8051B_REG_CARTAO : VarBasis
        {
            /*"  05      CARTAO-TIPO-ARQUIVO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CARTAO_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CARTAO-CODBANCO          PIC  9(003) VALUE ZEROS.*/
            public IntBasis CARTAO_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CARTAO-CONVENIO          PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-NSAS              PIC  9(006) VALUE ZEROS.*/
            public IntBasis CARTAO_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CARTAO-NUM-APOLICE       PIC  9(013) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      CARTAO-NUM-ENDOSSO       PIC  9(009) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CARTAO-NUM-PARCELA       PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-NUM-REQUISICAO    PIC  9(009) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_REQUISICAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CARTAO-TIPO-LANCAMENTO   PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_TIPO_LANCAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-NSAC              PIC  9(006) VALUE ZEROS.*/
            public IntBasis CARTAO_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CARTAO-DTGERACAO.*/
            public EM8051B_CARTAO_DTGERACAO CARTAO_DTGERACAO { get; set; } = new EM8051B_CARTAO_DTGERACAO();
            public class EM8051B_CARTAO_DTGERACAO : VarBasis
            {
                /*"    10    CARTAO-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                public IntBasis CARTAO_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    CARTAO-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    CARTAO-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      CARTAO-MOTIVO            PIC  X(002) VALUE SPACES.*/
            }
            public StringBasis CARTAO_MOTIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CARTAO-COD-TRANSACAO     PIC  9(003) VALUE ZEROS.*/
            public IntBasis CARTAO_COD_TRANSACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CARTAO-NUM-CARTAO        PIC  X(019) VALUE SPACES.*/
            public StringBasis CARTAO_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"  05      CARTAO-DTVENCTO.*/
            public EM8051B_CARTAO_DTVENCTO CARTAO_DTVENCTO { get; set; } = new EM8051B_CARTAO_DTVENCTO();
            public class EM8051B_CARTAO_DTVENCTO : VarBasis
            {
                /*"    10    CARTAO-ANO-VENCTO        PIC  9(004) VALUE ZEROS.*/
                public IntBasis CARTAO_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    CARTAO-MES-VENCTO        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    CARTAO-DIA-VENCTO        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      CARTAO-VLR-TRANSACAO     PIC  9(013)V99 VALUE ZEROS.*/
            }
            public DoubleBasis CARTAO_VLR_TRANSACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CARTAO-VLR-CREDITO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CARTAO_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CARTAO-VLR-TARIFA        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CARTAO_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CARTAO-NOVO-CARTAO       PIC  X(019) VALUE SPACES.*/
            public StringBasis CARTAO_NOVO_CARTAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"  05      CARTAO-NOVO-DIA-VENCTO   PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_NOVO_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-DATA-AGENDAMENTO.*/
            public EM8051B_CARTAO_DATA_AGENDAMENTO CARTAO_DATA_AGENDAMENTO { get; set; } = new EM8051B_CARTAO_DATA_AGENDAMENTO();
            public class EM8051B_CARTAO_DATA_AGENDAMENTO : VarBasis
            {
                /*"    10    CARTAO-ANO-AGENDA        PIC  9(004) VALUE ZEROS.*/
                public IntBasis CARTAO_ANO_AGENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    CARTAO-MES-AGENDA        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_MES_AGENDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    CARTAO-DIA-AGENDA        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_DIA_AGENDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      CARTAO-MOT-RETORNO       PIC  9(002) VALUE ZEROS.*/
            }
            public IntBasis CARTAO_MOT_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      CARTAO-MOT-CANCEL        PIC  X(002) VALUE SPACES.*/
            public StringBasis CARTAO_MOT_CANCEL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CARTAO-BANCO             PIC  9(003) VALUE ZEROS.*/
            public IntBasis CARTAO_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CARTAO-AGENCIA           PIC  9(005) VALUE ZEROS.*/
            public IntBasis CARTAO_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05      CARTAO-CONTA             PIC  9(012) VALUE ZEROS.*/
            public IntBasis CARTAO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"01        REG-CHEQUE.*/
        }
        public EM8051B_REG_CHEQUE REG_CHEQUE { get; set; } = new EM8051B_REG_CHEQUE();
        public class EM8051B_REG_CHEQUE : VarBasis
        {
            /*"  05      CHEQUE-TIPO-ARQUIVO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CHEQUE_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CHEQUE-ORIGEM-EMPRESA    PIC  X(004) VALUE SPACES.*/
            public StringBasis CHEQUE_ORIGEM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      CHEQUE-IDLG              PIC  X(040) VALUE SPACES.*/
            public StringBasis CHEQUE_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      CHEQUE-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis CHEQUE_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CHEQUE-CPF-CNPJ          PIC  X(020) VALUE SPACES.*/
            public StringBasis CHEQUE_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05      CHEQUE-EVENTO            PIC  X(010) VALUE SPACES.*/
            public StringBasis CHEQUE_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CHEQUE-VALOR-BRUTO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-IRRF        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-ISS         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-INSS        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-COFINS      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_COFINS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-CSLL        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_CSLL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-PIS         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_PIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-PAGTO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_PAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-DATA-CREDITO      PIC  X(008) VALUE SPACES.*/
            public StringBasis CHEQUE_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CHEQUE-DATA-ENVIO        PIC  X(008) VALUE SPACES.*/
            public StringBasis CHEQUE_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CHEQUE-DATA-CONTABIL     PIC  X(008) VALUE SPACES.*/
            public StringBasis CHEQUE_DATA_CONTABIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CHEQUE-MEIO-PAGTO        PIC  X(001) VALUE SPACES.*/
            public StringBasis CHEQUE_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      CHEQUE-NUM-CHEQUE        PIC  9(013) VALUE ZEROS.*/
            public IntBasis CHEQUE_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      CHEQUE-NUM-SIVAT         PIC  9(009) VALUE ZEROS.*/
            public IntBasis CHEQUE_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CHEQUE-OCORRENCIA        PIC  X(010) VALUE SPACES.*/
            public StringBasis CHEQUE_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01        REG-SIACC.*/
        }
        public EM8051B_REG_SIACC REG_SIACC { get; set; } = new EM8051B_REG_SIACC();
        public class EM8051B_REG_SIACC : VarBasis
        {
            /*"  05      SIACC-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis SIACC_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      SIACC-ORIGEM-EMPRESA     PIC  X(004) VALUE SPACES.*/
            public StringBasis SIACC_ORIGEM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      SIACC-IDLG               PIC  X(040) VALUE SPACES.*/
            public StringBasis SIACC_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      SIACC-CONVENIO           PIC  9(006) VALUE ZEROS.*/
            public IntBasis SIACC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      SIACC-NSA-BANCO          PIC  9(006) VALUE ZEROS.*/
            public IntBasis SIACC_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      SIACC-CPF-CNPJ           PIC  X(020) VALUE SPACES.*/
            public StringBasis SIACC_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05      SIACC-EVENTO             PIC  X(010) VALUE SPACES.*/
            public StringBasis SIACC_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      SIACC-VALOR-BRUTO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-IRRF         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-ISS          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-INSS         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-COFINS       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_COFINS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-CSLL         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_CSLL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-PIS          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_PIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-PAGTO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_PAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-DATA-CREDITO       PIC  X(008) VALUE SPACES.*/
            public StringBasis SIACC_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      SIACC-DATA-ENVIO         PIC  X(008) VALUE SPACES.*/
            public StringBasis SIACC_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      SIACC-DATA-CONTABIL      PIC  X(008) VALUE SPACES.*/
            public StringBasis SIACC_DATA_CONTABIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      SIACC-MEIO-PAGTO         PIC  X(001) VALUE SPACES.*/
            public StringBasis SIACC_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      SIACC-NUM-CHEQUE         PIC  9(013) VALUE ZEROS.*/
            public IntBasis SIACC_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      SIACC-NUM-SIVAT          PIC  9(009) VALUE ZEROS.*/
            public IntBasis SIACC_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      SIACC-OCORRENCIA         PIC  X(010) VALUE SPACES.*/
            public StringBasis SIACC_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01        REG-BANCOOB.*/
        }
        public EM8051B_REG_BANCOOB REG_BANCOOB { get; set; } = new EM8051B_REG_BANCOOB();
        public class EM8051B_REG_BANCOOB : VarBasis
        {
            /*"  10      BANCOOB-TIPO-ARQUIVO     PIC  X(010) VALUE SPACES.*/
            public StringBasis BANCOOB_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      BANCOOB-COD-REGISTRO     PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-TIPO-INSCRICAO   PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-NUM-INSCRICAO    PIC  9(014) VALUE ZEROS.*/
            public IntBasis BANCOOB_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  10      BANCOOB-COD-AGENCIA      PIC  9(004) VALUE ZEROS.*/
            public IntBasis BANCOOB_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      BANCOOB-DIG-AGENCIA      PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-NRO-CONTA        PIC  9(012) VALUE ZEROS.*/
            public IntBasis BANCOOB_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"  10      BANCOOB-DIG-CONTA        PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-CEDENTE          PIC  9(008) VALUE ZEROS.*/
            public IntBasis BANCOOB_CEDENTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  10      BANCOOB-CONVENIO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis BANCOOB_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  10      BANCOOB-CONTROLE         PIC  X(025) VALUE SPACES.*/
            public StringBasis BANCOOB_CONTROLE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  10      BANCOOB-NRO-TITULO       PIC  9(011) VALUE ZEROS.*/
            public IntBasis BANCOOB_NRO_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  10      BANCOOB-DIG-TITULO       PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIG_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-NRO-PARCELA      PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_NRO_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-DIAS-CALCULO     PIC  9(004) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIAS_CALCULO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      BANCOOB-MOTIVO           PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_MOTIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-PREFIXO          PIC  X(003) VALUE SPACES.*/
            public StringBasis BANCOOB_PREFIXO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  10      BANCOOB-VARIACAO         PIC  9(003) VALUE ZEROS.*/
            public IntBasis BANCOOB_VARIACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      BANCOOB-CAUCAO           PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_CAUCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-RESPONSABIL      PIC  9(005) VALUE ZEROS.*/
            public IntBasis BANCOOB_RESPONSABIL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  10      BANCOOB-DIGITO           PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-TAXA-DESCON      PIC  9(003)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_TAXA_DESCON { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
            /*"  10      BANCOOB-TAXA-IOF         PIC  9(001)V9999 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "9(001)V9999"), 4);
            /*"  10      FILLER                   PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  10      BANCOOB-CARTEIRA         PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-COMANDO          PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_COMANDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-DTLIQUIDA.*/
            public EM8051B_BANCOOB_DTLIQUIDA BANCOOB_DTLIQUIDA { get; set; } = new EM8051B_BANCOOB_DTLIQUIDA();
            public class EM8051B_BANCOOB_DTLIQUIDA : VarBasis
            {
                /*"    15    BANCOOB-DIA-LIQUIDA      PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-LIQUIDA      PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-LIQUIDA      PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      BANCOOB-SEU-NUMERO       PIC  X(010) VALUE SPACES.*/
            }
            public StringBasis BANCOOB_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      FILLER                   PIC  X(020) VALUE SPACES.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  10      BANCOOB-DTVENCTO.*/
            public EM8051B_BANCOOB_DTVENCTO BANCOOB_DTVENCTO { get; set; } = new EM8051B_BANCOOB_DTVENCTO();
            public class EM8051B_BANCOOB_DTVENCTO : VarBasis
            {
                /*"    15    BANCOOB-DIA-VENCTO       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-VENCTO       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-VENCTO       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      BANCOOB-VLR-NOMINAL-TIT  PIC  9(011)V99 VALUE ZEROS.*/
            }
            public DoubleBasis BANCOOB_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-COD-BANCO        PIC  9(003) VALUE ZEROS.*/
            public IntBasis BANCOOB_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      BANCOOB-AGE-COBR         PIC  9(004) VALUE ZEROS.*/
            public IntBasis BANCOOB_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      BANCOOB-AGE-DIG-COBR     PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-ESPECIE          PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_ESPECIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-DATA-CREDITO.*/
            public EM8051B_BANCOOB_DATA_CREDITO BANCOOB_DATA_CREDITO { get; set; } = new EM8051B_BANCOOB_DATA_CREDITO();
            public class EM8051B_BANCOOB_DATA_CREDITO : VarBasis
            {
                /*"    15    BANCOOB-DIA-CRED         PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-CRED         PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-CRED         PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      BANCOOB-VLR-TARIFA       PIC  9(005)V99 VALUE ZEROS.*/
            }
            public DoubleBasis BANCOOB_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99"), 2);
            /*"  10      BANCOOB-VLR-DESPESAS     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-JUROS        PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-IOF          PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-ABATIMENTO   PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-DESCONTO     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-RECEBIDO     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-MORA         PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_MORA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-OUTROS       PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_OUTROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-ABATNAO      PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_ABATNAO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-LANCADO      PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_LANCADO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-IND-DEBCRE       PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_IND_DEBCRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-IND-VALOR        PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_IND_VALOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-VLR-AJUSTE       PIC  9(010)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
            /*"  10      FILLER                   PIC  X(010) VALUE SPACES.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      BANCOOB-BANCO            PIC  9(003) VALUE ZEROS.*/
            public IntBasis BANCOOB_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      BANCOOB-DIGBCO           PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIGBCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-NSAC             PIC  9(006) VALUE ZEROS.*/
            public IntBasis BANCOOB_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  10      BANCOOB-DTGERACAO.*/
            public EM8051B_BANCOOB_DTGERACAO BANCOOB_DTGERACAO { get; set; } = new EM8051B_BANCOOB_DTGERACAO();
            public class EM8051B_BANCOOB_DTGERACAO : VarBasis
            {
                /*"    15    BANCOOB-DIA-HEADER       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-HEADER       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-HEADER       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      FILLER                   PIC  X(020) VALUE SPACES.*/
            }
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"01        BACKS-REGISTRO.*/
        }
        public EM8051B_BACKS_REGISTRO BACKS_REGISTRO { get; set; } = new EM8051B_BACKS_REGISTRO();
        public class EM8051B_BACKS_REGISTRO : VarBasis
        {
            /*"  05      BACKS-CODREGISTRO  PIC  X(001).*/
            public StringBasis BACKS_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      BACKS-CTACOBRANCA.*/
            public EM8051B_BACKS_CTACOBRANCA BACKS_CTACOBRANCA { get; set; } = new EM8051B_BACKS_CTACOBRANCA();
            public class EM8051B_BACKS_CTACOBRANCA : VarBasis
            {
                /*"    10    BACKS-AGENCIA      PIC  9(004).*/
                public IntBasis BACKS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-OPERACAO     PIC  9(003).*/
                public IntBasis BACKS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    BACKS-NUMCTA       PIC  9(008).*/
                public IntBasis BACKS_NUMCTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    BACKS-DIGCTA       PIC  9(001).*/
                public IntBasis BACKS_DIGCTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER             PIC  X(004).*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      BACKS-DTPAGTO.*/
            }
            public EM8051B_BACKS_DTPAGTO BACKS_DTPAGTO { get; set; } = new EM8051B_BACKS_DTPAGTO();
            public class EM8051B_BACKS_DTPAGTO : VarBasis
            {
                /*"    10    BACKS-ANOPAG       PIC  9(004).*/
                public IntBasis BACKS_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-MESPAG       PIC  9(002).*/
                public IntBasis BACKS_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    BACKS-DIAPAG       PIC  9(002).*/
                public IntBasis BACKS_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      BACKS-DTCREDITO.*/
            }
            public EM8051B_BACKS_DTCREDITO BACKS_DTCREDITO { get; set; } = new EM8051B_BACKS_DTCREDITO();
            public class EM8051B_BACKS_DTCREDITO : VarBasis
            {
                /*"    10    BACKS-ANOCRE       PIC  9(004).*/
                public IntBasis BACKS_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-MESCRE       PIC  9(002).*/
                public IntBasis BACKS_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    BACKS-DIACRE       PIC  9(002).*/
                public IntBasis BACKS_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      BACKS-CODBARRA.*/
            }
            public EM8051B_BACKS_CODBARRA BACKS_CODBARRA { get; set; } = new EM8051B_BACKS_CODBARRA();
            public class EM8051B_BACKS_CODBARRA : VarBasis
            {
                /*"    10    BACKS-COD-BANCO    PIC  9(003).*/
                public IntBasis BACKS_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    BACKS-AGENCIA-DEB  PIC  9(004).*/
                public IntBasis BACKS_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-OPERACAO-DEB PIC  9(004).*/
                public IntBasis BACKS_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-NUMCTA-DEB   PIC  9(012).*/
                public IntBasis BACKS_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    BACKS-DIGCTA-DEB   PIC  X(001).*/
                public StringBasis BACKS_DIGCTA_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    FILLER             PIC  X(001).*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    BACKS-NUM-PROPOSTA PIC  9(013).*/
                public IntBasis BACKS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    BACKS-NUM-PARCELA  PIC  9(004).*/
                public IntBasis BACKS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-BARRA3       PIC  X(004).*/
                public StringBasis BACKS_BARRA3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      BACKS-VLRPAGO      PIC  9(010)V99.*/
            }
            public DoubleBasis BACKS_VLRPAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      BACKS-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis BACKS_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      BACKS-NRSEQREG     PIC  9(008).*/
            public IntBasis BACKS_NRSEQREG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      BACKS-AGENCIA-ARREC PIC X(008).*/
            public StringBasis BACKS_AGENCIA_ARREC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      BACKS-FORMA-ARREC  PIC  X(001).*/
            public StringBasis BACKS_FORMA_ARREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      BACKS-NUM-AUTENTIC.*/
            public EM8051B_BACKS_NUM_AUTENTIC BACKS_NUM_AUTENTIC { get; set; } = new EM8051B_BACKS_NUM_AUTENTIC();
            public class EM8051B_BACKS_NUM_AUTENTIC : VarBasis
            {
                /*"    10    BACKS-NUM-CARTAO   PIC  9(016).*/
                public IntBasis BACKS_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    BACKS-COD-RETORNO  PIC  9(002).*/
                public IntBasis BACKS_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    BACKS-RESERVADO    PIC  9(005).*/
                public IntBasis BACKS_RESERVADO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05      BACKS-FORMAPAG     PIC  9(001).*/
            }
            public IntBasis BACKS_FORMAPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER             PIC  X(007).*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"01       CIELO-17.*/
        }
        public EM8051B_CIELO_17 CIELO_17 { get; set; } = new EM8051B_CIELO_17();
        public class EM8051B_CIELO_17 : VarBasis
        {
            /*"  05      DET17-TP-REGISTRO             PIC  9(002).*/
            public IntBasis DET17_TP_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      DET17-TP-MOVIMENTO            PIC  X(002).*/
            public StringBasis DET17_TP_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      DET17-IDLG                    PIC  X(040).*/
            public StringBasis DET17_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      DET17-STA-COMPENSACAO         PIC  X(001).*/
            public StringBasis DET17_STA_COMPENSACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      DET17-MOTIVO-COMPENSACAO      PIC  9(002).*/
            public IntBasis DET17_MOTIVO_COMPENSACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      DET17-NSA-SAP                 PIC  9(009).*/
            public IntBasis DET17_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      DET17-NUM-FATURA              PIC  X(012).*/
            public StringBasis DET17_NUM_FATURA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"  05      DET17-NUM-ITEM-FATURA         PIC  9(004).*/
            public IntBasis DET17_NUM_ITEM_FATURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DET17-NSA-BANCO               PIC  9(006).*/
            public IntBasis DET17_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      DET17-DTA-MOV                 PIC  9(008).*/
            public IntBasis DET17_DTA_MOV { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-NUM-PROPOSTA            PIC  9(016).*/
            public IntBasis DET17_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      DET17-NUM-COM-CIELO           PIC  9(010).*/
            public IntBasis DET17_NUM_COM_CIELO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05      DET17-COD-BCO-CRED            PIC  9(003).*/
            public IntBasis DET17_COD_BCO_CRED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      DET17-COD-AGE-CRED            PIC  9(005).*/
            public IntBasis DET17_COD_AGE_CRED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      DET17-NUM-CTA-CRED            PIC  9(012).*/
            public IntBasis DET17_NUM_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05      DET17-DIG-CTA-CRED            PIC  9(001).*/
            public IntBasis DET17_DIG_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      DET17-COD-CART-BANDEIRA       PIC  9(004).*/
            public IntBasis DET17_COD_CART_BANDEIRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DET17-NUM-CARTAO              PIC  X(025).*/
            public StringBasis DET17_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      DET17-COD-TOKEN-CARTAO        PIC  X(040).*/
            public StringBasis DET17_COD_TOKEN_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      DET17-STA-CART-PADRAO-SAP     PIC  X(001).*/
            public StringBasis DET17_STA_CART_PADRAO_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      DET17-COD-TID-CIELO           PIC  X(020).*/
            public StringBasis DET17_COD_TID_CIELO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      DET17-VLR-COBRANCA            PIC  9(013)V99.*/
            public DoubleBasis DET17_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DET17-VLR-LIQUIDO             PIC  9(013)V99.*/
            public DoubleBasis DET17_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DET17-VLR-TAX-ADM             PIC  9(013)V99.*/
            public DoubleBasis DET17_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DET17-DTA-VENCIMENTO          PIC  9(008).*/
            public IntBasis DET17_DTA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-DTA-CREDITO             PIC  9(008).*/
            public IntBasis DET17_DTA_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-DTA-DEB-TARIFA-ADM      PIC  9(008).*/
            public IntBasis DET17_DTA_DEB_TARIFA_ADM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-DTA-AJU-CAPTURA         PIC  9(008).*/
            public IntBasis DET17_DTA_AJU_CAPTURA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-COD-MOVIMENTO           PIC  X(002).*/
            public StringBasis DET17_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      DET17-COD-RETORNO             PIC  X(003).*/
            public StringBasis DET17_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      DET17-PROC-ADVERT             PIC  X(002).*/
            public StringBasis DET17_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      DET17-NIVE-ADVERT             PIC  X(002).*/
            public StringBasis DET17_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      FILLER                        PIC  X(041).*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)."), @"");
            /*"01        HEADER-REGISTRO.*/
        }
        public EM8051B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8051B_HEADER_REGISTRO();
        public class EM8051B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  9(010).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05      FILLER              PIC  X(010).*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public EM8051B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new EM8051B_HEADER_DATGERACAO();
            public class EM8051B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO          PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSA          PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER              PIC  X(069).*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8051B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8051B_TRAILL_REGISTRO();
        public class EM8051B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTPAG    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTPAG { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER              PIC  X(126).*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01        FILLER.*/
        }
        public EM8051B_FILLER_101 FILLER_101 { get; set; } = new EM8051B_FILLER_101();
        public class EM8051B_FILLER_101 : VarBasis
        {
            /*"  05 WS-NUM-APOLICE           PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis WS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"  05 WS-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis WS_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"  05 WS-NUM-PARCELA           PIC S9(4) USAGE COMP.*/
            public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05 WS-NUM-TITULO            PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis WS_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"  05 WS-COD-PRODUTO           PIC S9(4) USAGE COMP.*/
            public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05 WS-COD-CLIENTE           PIC S9(9) USAGE COMP.*/
            public IntBasis WS_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"01  LK-IDLG-REGISTRO-SINISTRO.*/
        }
        public EM8051B_LK_IDLG_REGISTRO_SINISTRO LK_IDLG_REGISTRO_SINISTRO { get; set; } = new EM8051B_LK_IDLG_REGISTRO_SINISTRO();
        public class EM8051B_LK_IDLG_REGISTRO_SINISTRO : VarBasis
        {
            /*"  03   LK-IDLG-DADOS-ENTRADA.*/
            public EM8051B_LK_IDLG_DADOS_ENTRADA LK_IDLG_DADOS_ENTRADA { get; set; } = new EM8051B_LK_IDLG_DADOS_ENTRADA();
            public class EM8051B_LK_IDLG_DADOS_ENTRADA : VarBasis
            {
                /*"    05 LK-IDLG-CODIGO-SINISTRO          PIC X(40).*/
                public StringBasis LK_IDLG_CODIGO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05 LK-IDLG-SIAS-SINI      REDEFINES  LK-IDLG-CODIGO-SINISTRO*/
                private _REDEF_EM8051B_LK_IDLG_SIAS_SINI _lk_idlg_sias_sini { get; set; }
                public _REDEF_EM8051B_LK_IDLG_SIAS_SINI LK_IDLG_SIAS_SINI
                {
                    get { _lk_idlg_sias_sini = new _REDEF_EM8051B_LK_IDLG_SIAS_SINI(); _.Move(LK_IDLG_CODIGO_SINISTRO, _lk_idlg_sias_sini); VarBasis.RedefinePassValue(LK_IDLG_CODIGO_SINISTRO, _lk_idlg_sias_sini, LK_IDLG_CODIGO_SINISTRO); _lk_idlg_sias_sini.ValueChanged += () => { _.Move(_lk_idlg_sias_sini, LK_IDLG_CODIGO_SINISTRO); }; return _lk_idlg_sias_sini; }
                    set { VarBasis.RedefinePassValue(value, _lk_idlg_sias_sini, LK_IDLG_CODIGO_SINISTRO); }
                }  //Redefines
                public class _REDEF_EM8051B_LK_IDLG_SIAS_SINI : VarBasis
                {
                    /*"       10 LK-IDLG-SINISTRO              PIC X(01).*/
                    public StringBasis LK_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-NUM-APOL-SINISTRO     PIC 9(13).*/
                    public IntBasis LK_IDLG_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"       10 LK-IDLG-FILLER-1              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-OCORR-HISTORICO       PIC 9(05).*/
                    public IntBasis LK_IDLG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       10 LK-IDLG-FILLER-2              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-COD-OPERACAO          PIC 9(04).*/
                    public IntBasis LK_IDLG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"       10 LK-IDLG-FILLER-3              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-TIPO-MOVIMENTO        PIC X(01).*/
                    public StringBasis LK_IDLG_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FILLER-4              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FORMA-PAGAMENTO       PIC X(01).*/
                    public StringBasis LK_IDLG_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FILLER-5              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-COMPLEMENTO           PIC X(10).*/
                    public StringBasis LK_IDLG_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       10 LK-IDLG-COMPLEMENTO-1  REDEFINES  LK-IDLG-COMPLEMENTO.*/
                    private _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_1 _lk_idlg_complemento_1 { get; set; }
                    public _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_1 LK_IDLG_COMPLEMENTO_1
                    {
                        get { _lk_idlg_complemento_1 = new _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_1(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_1); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_1.ValueChanged += () => { _.Move(_lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_1; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_1 : VarBasis
                    {
                        /*"          15 LK-IDLG-NUM-CHEQUE-INTERNO PIC 9(10).*/
                        public IntBasis LK_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                        /*"       10 LK-IDLG-COMPLEMENTO-2  REDEFINES  LK-IDLG-COMPLEMENTO.*/

                        public _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_1()
                        {
                            LK_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_2 _lk_idlg_complemento_2 { get; set; }
                    public _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_2 LK_IDLG_COMPLEMENTO_2
                    {
                        get { _lk_idlg_complemento_2 = new _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_2(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_2); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_2.ValueChanged += () => { _.Move(_lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_2; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_2 : VarBasis
                    {
                        /*"          15 LK-IDLG-NSAS               PIC 9(10).*/
                        public IntBasis LK_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                        /*"       10 LK-IDLG-COMPLEMENTO-3  REDEFINES  LK-IDLG-COMPLEMENTO.*/

                        public _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_2()
                        {
                            LK_IDLG_NSAS.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_3 _lk_idlg_complemento_3 { get; set; }
                    public _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_3 LK_IDLG_COMPLEMENTO_3
                    {
                        get { _lk_idlg_complemento_3 = new _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_3(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_3); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_3.ValueChanged += () => { _.Move(_lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_3; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_3 : VarBasis
                    {
                        /*"          15 LK-IDLG-NUM-ACORDO         PIC 9(05).*/
                        public IntBasis LK_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                        /*"          15 FILLER                     PIC X(01).*/
                        public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                        /*"          15 LK-IDLG-NUM-PARCELA        PIC 9(04).*/
                        public IntBasis LK_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                        /*"  03   LK-IDLG-DADOS-RETORNO.*/

                        public _REDEF_EM8051B_LK_IDLG_COMPLEMENTO_3()
                        {
                            LK_IDLG_NUM_ACORDO.ValueChanged += OnValueChanged;
                            FILLER_102.ValueChanged += OnValueChanged;
                            LK_IDLG_NUM_PARCELA.ValueChanged += OnValueChanged;
                        }

                    }

                    public _REDEF_EM8051B_LK_IDLG_SIAS_SINI()
                    {
                        LK_IDLG_SINISTRO.ValueChanged += OnValueChanged;
                        LK_IDLG_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_1.ValueChanged += OnValueChanged;
                        LK_IDLG_OCORR_HISTORICO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_2.ValueChanged += OnValueChanged;
                        LK_IDLG_COD_OPERACAO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_3.ValueChanged += OnValueChanged;
                        LK_IDLG_TIPO_MOVIMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_4.ValueChanged += OnValueChanged;
                        LK_IDLG_FORMA_PAGAMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_5.ValueChanged += OnValueChanged;
                        LK_IDLG_COMPLEMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_COMPLEMENTO_1.ValueChanged += OnValueChanged;
                    }

                }
            }
            public EM8051B_LK_IDLG_DADOS_RETORNO LK_IDLG_DADOS_RETORNO { get; set; } = new EM8051B_LK_IDLG_DADOS_RETORNO();
            public class EM8051B_LK_IDLG_DADOS_RETORNO : VarBasis
            {
                /*"    05 LK-IDLG-RET-EH-SINISTRO       PIC  X(03).*/
                public StringBasis LK_IDLG_RET_EH_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"    05 LK-IDLG-RET-NUM-APOL-SINISTRO PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-OCORR-HISTORICO   PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-COD-OPERACAO      PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-COD-PAGA-RECEBE   PIC  9(02).*/
                public IntBasis LK_IDLG_RET_COD_PAGA_RECEBE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05 LK-IDLG-RET-COD-PAGA-TEXTO    PIC  X(50).*/
                public StringBasis LK_IDLG_RET_COD_PAGA_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LK-IDLG-RET-COD-FINANC        PIC  9(02).*/
                public IntBasis LK_IDLG_RET_COD_FINANC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05 LK-IDLG-RET-COD-FINANC-TEXTO  PIC  X(50).*/
                public StringBasis LK_IDLG_RET_COD_FINANC_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LK-IDLG-RET-LAYOUT            PIC  9(02).*/
                public IntBasis LK_IDLG_RET_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05 LK-IDLG-RET-LAYOUT-TEXTO      PIC  X(50).*/
                public StringBasis LK_IDLG_RET_LAYOUT_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LK-IDLG-RET-NUM-OCORR-MOVTO   PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-IDE-SISTEMA       PIC  X(02).*/
                public StringBasis LK_IDLG_RET_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05 LK-IDLG-RET-MOVDEB-NUM-APOLICE                                     PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_MOVDEB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-MOVDEB-NUM-ENDOSSO                                     PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-MOVDEB-PARCELA                                     PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-MOVDEB-CONVENIO                                     PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-MOVDEB-NSAS-ENVIO                                     PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_NSAS_ENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-MOVDEB-NUM-REQUISI                                     PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_MOVDEB_NUM_REQUISI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-CHQ-CHQINT                                     PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_CHQ_CHQINT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-RESSARC-NUM-ACORDO                                     PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_RESSARC_NUM_ACORDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-RESSARC-PARCELA                                     PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_RESSARC_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-CODIGO-RETORNO    PIC X(01)        .*/
                public StringBasis LK_IDLG_RET_CODIGO_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LK-IDLG-RET-MENSAGEM          PIC X(80)        .*/
                public StringBasis LK_IDLG_RET_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                /*"01  REGISTRO-LINKAGE-GE0302B.*/
            }
        }
        public EM8051B_REGISTRO_LINKAGE_GE0302B REGISTRO_LINKAGE_GE0302B { get; set; } = new EM8051B_REGISTRO_LINKAGE_GE0302B();
        public class EM8051B_REGISTRO_LINKAGE_GE0302B : VarBasis
        {
            /*"    05 LK-GE0302B-IDLG                    PIC  X(40).*/
            public StringBasis LK_GE0302B_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0302B-ACHOU-USO-EMPRESA       PIC  X(03).*/
            public StringBasis LK_GE0302B_ACHOU_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-GE0302B-EH-SINISTRO             PIC  X(03).*/
            public StringBasis LK_GE0302B_EH_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-GE0302B-CHR-USO-EMPRESA         PIC  X(200).*/
            public StringBasis LK_GE0302B_CHR_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"    05 LK-GE0302B-SICOV-IDENT-CLIENTE     PIC  X(25).*/
            public StringBasis LK_GE0302B_SICOV_IDENT_CLIENTE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05 LK-GE0302B-SICOV-USO-EMPRESA       PIC  X(60).*/
            public StringBasis LK_GE0302B_SICOV_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"    05 LK-GE0302B-SIACC                   PIC  X(40).*/
            public StringBasis LK_GE0302B_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0302B-COD-RETORNO             PIC  X(01).*/
            public StringBasis LK_GE0302B_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-GE0302B-MENSAGEM.*/
            public EM8051B_LK_GE0302B_MENSAGEM LK_GE0302B_MENSAGEM { get; set; } = new EM8051B_LK_GE0302B_MENSAGEM();
            public class EM8051B_LK_GE0302B_MENSAGEM : VarBasis
            {
                /*"       10 LK-GE0302B-SQLCODE              PIC   -ZZ9.*/
                public IntBasis LK_GE0302B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-GE0302B-MENSAGEM-RETORNO     PIC  X(75).*/
                public StringBasis LK_GE0302B_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01  REGISTRO-LINKAGE-VA9991S.*/
            }
        }
        public EM8051B_REGISTRO_LINKAGE_VA9991S REGISTRO_LINKAGE_VA9991S { get; set; } = new EM8051B_REGISTRO_LINKAGE_VA9991S();
        public class EM8051B_REGISTRO_LINKAGE_VA9991S : VarBasis
        {
            /*"    05 LK-VA9991S-COD-IDLG               PIC  X(40).*/
            public StringBasis LK_VA9991S_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-VA9991S-COD-CONVENIO           PIC  9(06).*/
            public IntBasis LK_VA9991S_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 LK-VA9991S-NSAS                   PIC  9(06).*/
            public IntBasis LK_VA9991S_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 LK-VA9991S-NSL                    PIC  9(08).*/
            public IntBasis LK_VA9991S_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05 LK-VA9991S-TIPO-REGISTRO-ARQH     PIC  9(02).*/
            public IntBasis LK_VA9991S_TIPO_REGISTRO_ARQH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-VA9991S-CODIGO-RETORNO-SAP     PIC  X(02).*/
            public StringBasis LK_VA9991S_CODIGO_RETORNO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 LK-VA9991S-COD-USUARIO            PIC  X(08).*/
            public StringBasis LK_VA9991S_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-VA9991S-COD-RETORNO            PIC  X(01).*/
            public StringBasis LK_VA9991S_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-VA9991S-MENSAGEM.*/
            public EM8051B_LK_VA9991S_MENSAGEM LK_VA9991S_MENSAGEM { get; set; } = new EM8051B_LK_VA9991S_MENSAGEM();
            public class EM8051B_LK_VA9991S_MENSAGEM : VarBasis
            {
                /*"       10 LK-VA9991S-SQLCODE             PIC  -ZZ9.*/
                public IntBasis LK_VA9991S_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                         PIC  X(01).*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-VA9991S-MENSAGEM-RETORNO    PIC  X(75).*/
                public StringBasis LK_VA9991S_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Copies.LBGE8051 LBGE8051 { get; set; } = new Copies.LBGE8051();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.GE100 GE100 { get; set; } = new Dclgens.GE100();
        public Dclgens.GE094 GE094 { get; set; } = new Dclgens.GE094();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.EF150 EF150 { get; set; } = new Dclgens.EF150();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVARQH_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVARQH.SetFile(MOVARQH_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1719- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1719- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1721- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1723- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1726- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -1727- DISPLAY '       EM8051B - PROCESSA ARQUIVO <ARQ_H>          ' */
            _.Display($"       EM8051B - PROCESSA ARQUIVO <ARQ_H>          ");

            /*" -1728- DISPLAY '                                                   ' */
            _.Display($"                                                   ");

            /*" -1729- DISPLAY 'VERSAO V.053: ' FUNCTION WHEN-COMPILED ' - 278.146' */

            $"VERSAO V.053: FUNCTION{_.WhenCompiled()} - 278.146"
            .Display();

            /*" -1730- DISPLAY ' ' */
            _.Display($" ");

            /*" -1737- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1738- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1740- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1742- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1743- PERFORM R0400-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0400_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1749- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1754- CLOSE MOVARQH MOVARQHS */
            MOVARQH.Close();
            MOVARQHS.Close();

            /*" -1756- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1757- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -1758- DISPLAY '                 E M 8 0 5 1 B  ' */
            _.Display($"                 E M 8 0 5 1 B  ");

            /*" -1759- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -1760- DISPLAY 'LIDOS HEADER ............ ' TT-HEADER */
            _.Display($"LIDOS HEADER ............ {W.TT_HEADER}");

            /*" -1761- DISPLAY 'LIDOS TRAILLER .......... ' TT-TRAILLER */
            _.Display($"LIDOS TRAILLER .......... {W.TT_TRAILLER}");

            /*" -1762- DISPLAY 'LIDOS DETALHE ........... ' LD-MOVIMENTO */
            _.Display($"LIDOS DETALHE ........... {W.LD_MOVIMENTO}");

            /*" -1763- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -1764- DISPLAY 'DESPREZA DETALHE ........ ' DP-MOVIMENTO */
            _.Display($"DESPREZA DETALHE ........ {W.DP_MOVIMENTO}");

            /*" -1765- DISPLAY 'DESPREZA TIPOREG ........ ' DP-TIPOREG */
            _.Display($"DESPREZA TIPOREG ........ {W.DP_TIPOREG}");

            /*" -1766- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -1767- DISPLAY 'REGISTROS GRAV ARQHS..... ' AC-GRAV-ARQHS */
            _.Display($"REGISTROS GRAV ARQHS..... {W.AC_GRAV_ARQHS}");

            /*" -1768- DISPLAY 'REGISTROS QTD CONV367771. ' WS-QTD-RET367771 */
            _.Display($"REGISTROS QTD CONV367771. {WS_QTD_RET367771}");

            /*" -1769- DISPLAY 'REGISTROS ALT CONV367771. ' WS-ALT-RET367771 */
            _.Display($"REGISTROS ALT CONV367771. {WS_ALT_RET367771}");

            /*" -1770- DISPLAY ' ' */
            _.Display($" ");

            /*" -1771- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -1772- DISPLAY '            EM8051B - FIM NORMAL' . */
            _.Display($"            EM8051B - FIM NORMAL");

            /*" -1774- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -1774- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -1785- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1786- OPEN INPUT MOVARQH. */
            MOVARQH.Open(REG_ARQH);

            /*" -1788- OPEN OUTPUT MOVARQHS. */
            MOVARQHS.Open(REG_ARQHS);

            /*" -1790- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -1791- MOVE 'S' TO WS-TRATA. */
            _.Move("S", W.WS_TRATA);

            /*" -1793- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -1795- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -1796- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -1797- GO TO R9990-00-SEM-MOVIMENTO */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;

                /*" -1797- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -1808- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1813- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -1816- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1817- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -1821- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1823- DISPLAY 'DATA DO MOVIMENTO: ' WHOST-DATA-EM */
            _.Display($"DATA DO MOVIMENTO: {WHOST_DATA_EM}");

            /*" -1823- MOVE WHOST-DATA-EM TO WDATA-REL. */
            _.Move(WHOST_DATA_EM, WDATA_REL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -1813- EXEC SQL SELECT DATA_MOV_ABERTO INTO :WHOST-DATA-EM FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FA' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_EM, WHOST_DATA_EM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -1834- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1835- READ MOVARQH AT END */
            try
            {
                MOVARQH.Read(() =>
                {

                    /*" -1838- MOVE 'S' TO WFIM-MOVIMENTO. */
                    _.Move("S", W.WFIM_MOVIMENTO);
                });

                _.Move(MOVARQH.Value, REG_ARQH);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1838- DISPLAY 'R0300-LIDO:' REG-ARQH. */
            _.Display($"R0300-LIDO:{REG_ARQH}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0400_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -1851- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1857- MOVE REG-ARQH TO DET-REGISTRO HEA-REGISTRO */
            _.Move(MOVARQH?.Value, DET_REGISTRO, HEA_REGISTRO);

            /*" -1858- IF (HEA-TIPREG EQUAL 00) */

            if ((HEA_REGISTRO.HEA_TIPREG == 00))
            {

                /*" -1859- ADD 1 TO TT-HEADER */
                W.TT_HEADER.Value = W.TT_HEADER + 1;

                /*" -1860- PERFORM R0410-00-TRATA-HEADER */

                R0410_00_TRATA_HEADER_SECTION();

                /*" -1861- GO TO R0400-90-LEITURA */

                R0400_90_LEITURA(); //GOTO
                return;

                /*" -1862- ELSE */
            }
            else
            {


                /*" -1863- IF (HEA-TIPREG EQUAL 99) */

                if ((HEA_REGISTRO.HEA_TIPREG == 99))
                {

                    /*" -1864- ADD 1 TO TT-TRAILLER */
                    W.TT_TRAILLER.Value = W.TT_TRAILLER + 1;

                    /*" -1865- PERFORM R0410-00-TRATA-HEADER */

                    R0410_00_TRATA_HEADER_SECTION();

                    /*" -1866- GO TO R0400-90-LEITURA */

                    R0400_90_LEITURA(); //GOTO
                    return;

                    /*" -1867- END-IF */
                }


                /*" -1869- END-IF. */
            }


            /*" -1872- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

            /*" -1873- IF DET-TIPREG EQUAL 02 */

            if (DET_REGISTRO.DET_TIPREG == 02)
            {

                /*" -1874- IF DET2-COD-CONV EQUAL 367771 */

                if (DET_REGISTRO.DET_REG2.DET2_COD_CONV == 367771)
                {

                    /*" -1875- PERFORM R1055-00-TRATA-RET-SIACC-150 */

                    R1055_00_TRATA_RET_SIACC_150_SECTION();

                    /*" -1876- MOVE 56614 TO DET2-COD-CONV */
                    _.Move(56614, DET_REGISTRO.DET_REG2.DET2_COD_CONV);

                    /*" -1877- MOVE WS-MOVCC-RETORNO TO DET2-OCORRENCIA(1:2) */
                    _.MoveAtPosition(WS_MOVCC_RETORNO, DET_REGISTRO.DET_REG2.DET2_OCORRENCIA, 1, 2);

                    /*" -1878- END-IF */
                }


                /*" -1880- END-IF */
            }


            /*" -1882- WRITE REG-ARQHS FROM DET-REGISTRO */
            _.Move(DET_REGISTRO.GetMoveValues(), REG_ARQHS);

            MOVARQHS.Write(REG_ARQHS.GetMoveValues().ToString());

            /*" -1882- ADD 1 TO AC-GRAV-ARQHS. */
            W.AC_GRAV_ARQHS.Value = W.AC_GRAV_ARQHS + 1;

            /*" -0- FLUXCONTROL_PERFORM R0400_90_LEITURA */

            R0400_90_LEITURA();

        }

        [StopWatch]
        /*" R0400-90-LEITURA */
        private void R0400_90_LEITURA(bool isPerform = false)
        {
            /*" -1886- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-TRATA-HEADER-SECTION */
        private void R0410_00_TRATA_HEADER_SECTION()
        {
            /*" -1897- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1898- WRITE REG-ARQHS FROM DET-REGISTRO */
            _.Move(DET_REGISTRO.GetMoveValues(), REG_ARQHS);

            MOVARQHS.Write(REG_ARQHS.GetMoveValues().ToString());

            /*" -1899- DISPLAY 'R0410-GRAV:' DET-REGISTRO */
            _.Display($"R0410-GRAV:{DET_REGISTRO}");

            /*" -1900- ADD 1 TO AC-GRAV-ARQHS */
            W.AC_GRAV_ARQHS.Value = W.AC_GRAV_ARQHS + 1;

            /*" -1900- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R1055-00-TRATA-RET-SIACC-150-SECTION */
        private void R1055_00_TRATA_RET_SIACC_150_SECTION()
        {
            /*" -1909- DISPLAY ' TIPOREG:' DET-TIPREG ' CONV:' DET2-COD-CONV ' IDLG:' DET-IDLG */

            $" TIPOREG:{DET_REGISTRO.DET_TIPREG} CONV:{DET_REGISTRO.DET_REG2.DET2_COD_CONV} IDLG:{DET_REGISTRO.DET_IDLG}"
            .Display();

            /*" -1910- MOVE 0 TO WS-ERRO */
            _.Move(0, WS_ERRO);

            /*" -1911- ADD 1 TO WS-QTD-RET367771 */
            WS_QTD_RET367771.Value = WS_QTD_RET367771 + 1;

            /*" -1912- MOVE SPACES TO WS-MOVCC-RETORNO */
            _.Move("", WS_MOVCC_RETORNO);

            /*" -1913- MOVE DET2-OCORRENCIA(1:2) TO WS-COD-RETSAP */
            _.Move(DET_REGISTRO.DET_REG2.DET2_OCORRENCIA.Substring(1, 2), WS_COD_RETSAP);

            /*" -1915- SET WS150 TO 1 */
            LBGE8051.WS150.Value = 1;

            /*" -1917- SEARCH TB-COD-SIACC-150 AT END */
            void SearchAtEnd0()
            {

                /*" -1918- MOVE 1 TO WS-ERRO */
                _.Move(1, WS_ERRO);

                /*" -1919- MOVE 'AJ' TO WS-MOVCC-RETORNO */
                _.Move("AJ", WS_MOVCC_RETORNO);

                /*" -1921- DISPLAY 'R1055-COD SIACC-150 NAO ENCONTRADO-RET AJ' ' :' WS-COD-RETSAP */

                $"R1055-COD SIACC-150 NAO ENCONTRADO-RET AJ :{WS_COD_RETSAP}"
                .Display();

                /*" -1922- WHEN WS-COD-RETSAP EQUAL TB-COD-RET-150(WS150) */
            };

            var mustSearchAtEnd0 = true;
            for (; LBGE8051.WS150 < LBGE8051.TABELA_COD_SIACC_150_R.TB_COD_SIACC_150.Items.Count; LBGE8051.WS150.Value++)
            {

                if (WS_COD_RETSAP == LBGE8051.TABELA_COD_SIACC_150_R.TB_COD_SIACC_150[LBGE8051.WS150].TB_COD_RET_150)
                {

                    mustSearchAtEnd0 = false;

                    /*" -1923- SET WS240 TO WS150 */
                    LBGE8051.WS240.Value = LBGE8051.WS150;

                    /*" -1924- MOVE TB-COD-RET-PADSIAS(WS150) TO WS-COD-RETSIAS */
                    _.Move(LBGE8051.TABELA_COD_SIACC_150_R.TB_COD_SIACC_150[LBGE8051.WS150].TB_COD_RET_PADSIAS, WS_COD_RETSIAS);

                    /*" -1925- MOVE TB-COD-RET-PAD240 (WS150) TO WS-COD-RET240 */
                    _.Move(LBGE8051.TABELA_COD_SIACC_150_R.TB_COD_SIACC_150[LBGE8051.WS150].TB_COD_RET_PAD240, WS_COD_RET240);

                    /*" -1928- DISPLAY 'COD150:' TB-COD-RET-150(WS150) ' NOM-150:' TB-NOME-RET-150(WS150) */

                    $"COD150:{LBGE8051.TABELA_COD_SIACC_150_R.TB_COD_SIACC_150[LBGE8051.WS150]} NOM-150:{LBGE8051.TABELA_COD_SIACC_150_R.TB_COD_SIACC_150[LBGE8051.WS150]}"
                    .Display();

                    /*" -1929- SET WS240 TO 1 */
                    LBGE8051.WS240.Value = 1;

                    /*" -1931- SEARCH TB-COD-SIACC-240 AT END */
                    void SearchAtEnd1()
                    {

                        /*" -1932- MOVE 2 TO WS-ERRO */
                        _.Move(2, WS_ERRO);

                        /*" -1933- MOVE 'AJ' TO WS-MOVCC-RETORNO */
                        _.Move("AJ", WS_MOVCC_RETORNO);

                        /*" -1935- DISPLAY 'R1055-COD:' WS-COD-RET240 ' COD SIACC-240 NAO ENCONTRADO RET AJ' */

                        $"R1055-COD:{WS_COD_RET240} COD SIACC-240 NAO ENCONTRADO RET AJ"
                        .Display();

                        /*" -1936- WHEN WS-COD-RET240 EQUAL TB-COD-RET-240 (WS240) */
                    };

                    var mustSearchAtEnd1 = true;
                    for (; LBGE8051.WS240 < LBGE8051.TABELA_COD_SIACC_240_R.TB_COD_SIACC_240.Items.Count; LBGE8051.WS240.Value++)
                    {

                        if (WS_COD_RET240 == LBGE8051.TABELA_COD_SIACC_240_R.TB_COD_SIACC_240[LBGE8051.WS240].TB_COD_RET_240)
                        {

                            mustSearchAtEnd1 = false;

                            /*" -1938- DISPLAY 'COD240:' TB-COD-RET-240 (WS240) ' NOM-240:' TB-NOME-RET-240 (WS240) */

                            $"COD240:{LBGE8051.TABELA_COD_SIACC_240_R.TB_COD_SIACC_240[LBGE8051.WS240]} NOM-240:{LBGE8051.TABELA_COD_SIACC_240_R.TB_COD_SIACC_240[LBGE8051.WS240]}"
                            .Display();

                            /*" -1939- MOVE WS-COD-RET240 TO WS-MOVCC-RETORNO */
                            _.Move(WS_COD_RET240, WS_MOVCC_RETORNO);

                            /*" -1940- ADD 1 TO WS-ALT-RET367771 */
                            WS_ALT_RET367771.Value = WS_ALT_RET367771 + 1;

                            /*" -1940- END-SEARCH. */
                            break;
                        }
                    }

                    if (mustSearchAtEnd1)
                        SearchAtEnd1();

                    /*" -1957- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1055_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-TRATA-RET-SIACC-150-SECTION */
        private void R1060_00_TRATA_RET_SIACC_150_SECTION()
        {
            /*" -1969- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1970- IF WS-OCORR1 EQUAL '00' */

            if (FILLER_28.WS_OCORR1 == "00")
            {

                /*" -1972- MOVE WS-OCORR1 TO MOVCC-RETORNO */
                _.Move(FILLER_28.WS_OCORR1, MOVCC_REGISTRO.MOVCC_RETORNO);

                /*" -1973- ELSE */
            }
            else
            {


                /*" -1974- IF WS-OCORR1 EQUAL '05' */

                if (FILLER_28.WS_OCORR1 == "05")
                {

                    /*" -1976- MOVE '01' TO MOVCC-RETORNO */
                    _.Move("01", MOVCC_REGISTRO.MOVCC_RETORNO);

                    /*" -1977- ELSE */
                }
                else
                {


                    /*" -1978- IF WS-OCORR1 EQUAL '99' */

                    if (FILLER_28.WS_OCORR1 == "99")
                    {

                        /*" -1980- MOVE WS-OCORR1 TO MOVCC-RETORNO */
                        _.Move(FILLER_28.WS_OCORR1, MOVCC_REGISTRO.MOVCC_RETORNO);

                        /*" -1981- ELSE */
                    }
                    else
                    {


                        /*" -1984- IF WS-OCORR1 EQUAL '12' OR '53' OR '57' */

                        if (FILLER_28.WS_OCORR1.In("12", "53", "57"))
                        {

                            /*" -1986- MOVE '14' TO MOVCC-RETORNO */
                            _.Move("14", MOVCC_REGISTRO.MOVCC_RETORNO);

                            /*" -1987- ELSE */
                        }
                        else
                        {


                            /*" -1991- IF WS-OCORR1 EQUAL '60' OR '61' OR '81' OR '82' */

                            if (FILLER_28.WS_OCORR1.In("60", "61", "81", "82"))
                            {

                                /*" -1993- MOVE '02' TO MOVCC-RETORNO */
                                _.Move("02", MOVCC_REGISTRO.MOVCC_RETORNO);

                                /*" -1994- ELSE */
                            }
                            else
                            {


                                /*" -2001- IF WS-OCORR1 EQUAL '19' OR '34' OR '46' OR '67' OR '85' OR '89' OR '95' */

                                if (FILLER_28.WS_OCORR1.In("19", "34", "46", "67", "85", "89", "95"))
                                {

                                    /*" -2003- MOVE '13' TO MOVCC-RETORNO */
                                    _.Move("13", MOVCC_REGISTRO.MOVCC_RETORNO);

                                    /*" -2004- ELSE */
                                }
                                else
                                {


                                    /*" -2006- IF WS-OCORR1 EQUAL '22' OR '35' */

                                    if (FILLER_28.WS_OCORR1.In("22", "35"))
                                    {

                                        /*" -2008- MOVE '12' TO MOVCC-RETORNO */
                                        _.Move("12", MOVCC_REGISTRO.MOVCC_RETORNO);

                                        /*" -2009- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2013- MOVE '04' TO MOVCC-RETORNO. */
                                        _.Move("04", MOVCC_REGISTRO.MOVCC_RETORNO);
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -2013- MOVE WS-OCORR TO MOVCC-RETSIACC. */
            _.Move(WS_OCORR, MOVCC_REGISTRO.MOVCC_RETSIACC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -2023- MOVE WHOST-DATA-EM TO WDATA-SQL */
            _.Move(WHOST_DATA_EM, WDATA_SQL);

            /*" -2024- MOVE WDATA-DD-SQL TO WDATA-DD-CABEC */
            _.Move(WDATA_SQL.WDATA_DD_SQL, WDATA_CABEC.WDATA_DD_CABEC);

            /*" -2025- MOVE WDATA-MM-SQL TO WDATA-MM-CABEC */
            _.Move(WDATA_SQL.WDATA_MM_SQL, WDATA_CABEC.WDATA_MM_CABEC);

            /*" -2027- MOVE WDATA-AA-SQL TO WDATA-AA-CABEC. */
            _.Move(WDATA_SQL.WDATA_AA_SQL, WDATA_CABEC.WDATA_AA_CABEC);

            /*" -2030- DISPLAY 'ARQUIVO SEM MOVIMENTO PROCESSADO NESTA DATA - ' WDATA-CABEC. */
            _.Display($"ARQUIVO SEM MOVIMENTO PROCESSADO NESTA DATA - {WDATA_CABEC}");

            /*" -2033- CLOSE MOVARQH MOVARQHS. */
            MOVARQH.Close();
            MOVARQHS.Close();

            /*" -2036- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -2036- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2044- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -2045- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -2046- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -2047- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -2049- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -2049- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2054- CLOSE MOVARQH MOVARQHS */
            MOVARQH.Close();
            MOVARQHS.Close();

            /*" -2056- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2056- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}