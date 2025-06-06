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
using Sias.VidaAzul.DB2.VA1473B;

namespace Code
{
    public class VA1473B
    {
        public bool IsCall { get; set; }

        public VA1473B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA REPASE SAF PARA A ICATU       *      */
        /*"      *                             CONVENIO EUROPE ASSISTANCE, EXCETO *      */
        /*"      *                             PARA O CAAES E FEDERAL CLUBE.      *      */
        /*"      *                                                                *      */
        /*"      *   PERIODICIDADE >>>>>>>>>   ENVIA OS ARQUIVOS DIARIAMENTE.     *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  M MESSIAS DE S                     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA1473B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  17/10/2001                         *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO DO PROGRAMA......  VF0471B                            *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *               A L T E R A C O E S                              *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  005 - 29/05/2008 - FAST COMPUTER                              *      */
        /*"      *    PROJETO FGV - TUNNING                                       *      */
        /*"      *                                                                *      */
        /*"      *                          PROCURAR POR V.05                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 07/01/2007 - FAST COMPUTER                              *      */
        /*"      *    PASSA A TRATAR TAMBEM BILHETES AP VENDIDOS NO CANAD DE VENDA*      */
        /*"      *    GITEL.                                                      *      */
        /*"      *                          PROCURAR POR V.02                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 31/08/2006 - MARCO ANTONIO                              *      */
        /*"      *    CORRECAO DO ABEND OCORRIODO SQLCODE = 100 NO SEGURADOS_VGAP *      */
        /*"      *                          PROCURAR POR V.01                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 18/06/03 - MANOEL MESSIAS                               *      */
        /*"      *    AUMENTO DO CAMPO NRCERTIF DE 11 PARA 15 POSICOES.           *      */
        /*"      *                                            PROCURE POR MM0603  *      */
        /*"      ******************************************************************      */
        /*"      *  001 - 21/11/01 - MESSIAS                                      *      */
        /*"      *    O PRODUTO EXCLUSIVO, GEROU PARCELAS COM O MESMO VENCIMENTO. *      */
        /*"      * OCASIONOU, ABEND 811- NA LEITURA DA PARCELVA, IMPEDINDO O REPAS*      */
        /*"      * SE DO SAF NOVAMENTE.                       PROCURE POR MM1101  *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _REPSAF { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis REPSAF
        {
            get
            {
                _.Move(REPSAF_RECORD, _REPSAF); VarBasis.RedefinePassValue(REPSAF_RECORD, _REPSAF, REPSAF_RECORD); return _REPSAF;
            }
        }
        /*"01   REPSAF-RECORD PIC X(350).*/
        public StringBasis REPSAF_RECORD { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  PROPVA-DTQIT10A               PIC  X(10).*/
        public StringBasis PROPVA_DTQIT10A { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I               PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ICODPRODEA             PIC S9(04) COMP.*/
        public IntBasis PRODVG_ICODPRODEA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  SISTEMA-DTMVM06M              PIC  X(10).*/
        public StringBasis SISTEMA_DTMVM06M { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURREN             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURREN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURINI             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTMOVABE-10          PIC  X(10).*/
        public StringBasis SISTEMAS_DTMOVABE_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CONARQEA-ANO-REF-ANT          PIC S9(04) COMP.*/
        public IntBasis CONARQEA_ANO_REF_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CONARQEA-ANO-REF-ATU          PIC S9(04) COMP.*/
        public IntBasis CONARQEA_ANO_REF_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  REPSAF-DTINIVIG               PIC  X(10).*/
        public StringBasis REPSAF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VA1473B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA1473B_WS_WORK_AREAS();
        public class VA1473B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-EOF                    PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WSQLCODE3                 PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  W01DTSQL.*/
            public VA1473B_W01DTSQL W01DTSQL { get; set; } = new VA1473B_W01DTSQL();
            public class VA1473B_W01DTSQL : VarBasis
            {
                /*"       05  W01AASQL               PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL               PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL               PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL               PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL               PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  W01DTCOR.*/
            }
            public VA1473B_W01DTCOR W01DTCOR { get; set; } = new VA1473B_W01DTCOR();
            public class VA1473B_W01DTCOR : VarBasis
            {
                /*"       05  W01DDCOR               PIC 9(002).*/
                public IntBasis W01DDCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01MMCOR               PIC 9(002).*/
                public IntBasis W01MMCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01AACOR               PIC 9(004).*/
                public IntBasis W01AACOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03  W01DTINV.*/
            }
            public VA1473B_W01DTINV W01DTINV { get; set; } = new VA1473B_W01DTINV();
            public class VA1473B_W01DTINV : VarBasis
            {
                /*"       05  W01AAINV               PIC 9(004).*/
                public IntBasis W01AAINV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01MMINV               PIC 9(002).*/
                public IntBasis W01MMINV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01DDINV               PIC 9(002).*/
                public IntBasis W01DDINV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  WS-ANO-REF                PIC 9(004).*/
            }
            public IntBasis WS_ANO_REF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03  WS-ANO-REF-R              REDEFINES        WS-ANO-REF.*/
            private _REDEF_VA1473B_WS_ANO_REF_R _ws_ano_ref_r { get; set; }
            public _REDEF_VA1473B_WS_ANO_REF_R WS_ANO_REF_R
            {
                get { _ws_ano_ref_r = new _REDEF_VA1473B_WS_ANO_REF_R(); _.Move(WS_ANO_REF, _ws_ano_ref_r); VarBasis.RedefinePassValue(WS_ANO_REF, _ws_ano_ref_r, WS_ANO_REF); _ws_ano_ref_r.ValueChanged += () => { _.Move(_ws_ano_ref_r, WS_ANO_REF); }; return _ws_ano_ref_r; }
                set { VarBasis.RedefinePassValue(value, _ws_ano_ref_r, WS_ANO_REF); }
            }  //Redefines
            public class _REDEF_VA1473B_WS_ANO_REF_R : VarBasis
            {
                /*"       05  FILLER                 PIC X(002).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       05  WS-ANO-REF-2           PIC 9(002).*/
                public IntBasis WS_ANO_REF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  TABELA-ULT-DIAS.*/

                public _REDEF_VA1473B_WS_ANO_REF_R()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_ANO_REF_2.ValueChanged += OnValueChanged;
                }

            }
            public VA1473B_TABELA_ULT_DIAS TABELA_ULT_DIAS { get; set; } = new VA1473B_TABELA_ULT_DIAS();
            public class VA1473B_TABELA_ULT_DIAS : VarBasis
            {
                /*"      05 TAB-DIAS.*/
                public VA1473B_TAB_DIAS TAB_DIAS { get; set; } = new VA1473B_TAB_DIAS();
                public class VA1473B_TAB_DIAS : VarBasis
                {
                    /*"         09  FILLER               PIC  X(024)   VALUE            '312831303130313130313031'.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                    /*"      05 TAB-DIAS-R               REDEFINES     TAB-DIAS.*/
                }
                private _REDEF_VA1473B_TAB_DIAS_R _tab_dias_r { get; set; }
                public _REDEF_VA1473B_TAB_DIAS_R TAB_DIAS_R
                {
                    get { _tab_dias_r = new _REDEF_VA1473B_TAB_DIAS_R(); _.Move(TAB_DIAS, _tab_dias_r); VarBasis.RedefinePassValue(TAB_DIAS, _tab_dias_r, TAB_DIAS); _tab_dias_r.ValueChanged += () => { _.Move(_tab_dias_r, TAB_DIAS); }; return _tab_dias_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_dias_r, TAB_DIAS); }
                }  //Redefines
                public class _REDEF_VA1473B_TAB_DIAS_R : VarBasis
                {
                    /*"         09  ULT-DIA              OCCURS  12    TIMES                                  PIC  X(002).*/
                    public ListBasis<StringBasis, string> ULT_DIA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "2", "X(002)."), 12);
                    /*"    03  WS-TIME                   PIC  X(008) VALUE  SPACES.*/

                    public _REDEF_VA1473B_TAB_DIAS_R()
                    {
                        ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    03  AC-CONTA                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-LIDOS                  PIC  9(006) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-REGISTROS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-INCLUIDOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_INCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ALTERADOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_ALTERADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-EXCLUIDOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_EXCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  HEADER-RECORD.*/
        }
        public VA1473B_HEADER_RECORD HEADER_RECORD { get; set; } = new VA1473B_HEADER_RECORD();
        public class VA1473B_HEADER_RECORD : VarBasis
        {
            /*"    05  FILLER                    PIC  X(021) VALUE      'HICATU HARTFORD'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"HICATU HARTFORD");
            /*"    05  HEA-DATA-CRIACAO          PIC  X(008).*/
            public StringBasis HEA_DATA_CRIACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  HEA-ARQUIVO-ATU.*/
            public VA1473B_HEA_ARQUIVO_ATU HEA_ARQUIVO_ATU { get; set; } = new VA1473B_HEA_ARQUIVO_ATU();
            public class VA1473B_HEA_ARQUIVO_ATU : VarBasis
            {
                /*"      10  FILLER                  PIC  X(002) VALUE        'IH'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"IH");
                /*"      10  HEA-ANO-REF-ATU         PIC  9(002).*/
                public IntBasis HEA_ANO_REF_ATU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  HEA-NUM-ARQ-ATU         PIC  9(004).*/
                public IntBasis HEA_NUM_ARQ_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HEA-ARQUIVO-ANT.*/
            }
            public VA1473B_HEA_ARQUIVO_ANT HEA_ARQUIVO_ANT { get; set; } = new VA1473B_HEA_ARQUIVO_ANT();
            public class VA1473B_HEA_ARQUIVO_ANT : VarBasis
            {
                /*"      10  FILLER                  PIC  X(002) VALUE        'IH'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"IH");
                /*"      10  HEA-ANO-REF-ANT         PIC  9(002).*/
                public IntBasis HEA_ANO_REF_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  HEA-NUM-ARQ-ANT         PIC  9(004).*/
                public IntBasis HEA_NUM_ARQ_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  DETAIL-RECORD.*/
            }
        }
        public VA1473B_DETAIL_RECORD DETAIL_RECORD { get; set; } = new VA1473B_DETAIL_RECORD();
        public class VA1473B_DETAIL_RECORD : VarBasis
        {
            /*"    05  DET-TIPO-MOV              PIC  X(002).*/
            public StringBasis DET_TIPO_MOV { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  FILLER                    PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05  DET-NRCERTIF              PIC  9(015).*/
            public IntBasis DET_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  DET-CODPRODEA             PIC  X(002).*/
            public StringBasis DET_CODPRODEA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-NOME-RAZAO            PIC  X(040).*/
            public StringBasis DET_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-ENDERECO              PIC  X(040).*/
            public StringBasis DET_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  FILLER                    PIC  X(010) VALUE SPACES.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  DET-CIDADE                PIC  X(030).*/
            public StringBasis DET_CIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  DET-CEP                   PIC  9(008).*/
            public IntBasis DET_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  DET-SIGLA-UF              PIC  X(002).*/
            public StringBasis DET_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05  DET-BAIRRO                PIC  X(020).*/
            public StringBasis DET_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  DET-CGCCPF                PIC  9(014).*/
            public IntBasis DET_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  FILLER                    PIC  X(001) VALUE 'F'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"F");
            /*"    05  FILLER                    PIC  X(011) VALUE SPACES.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
            /*"    05  DET-TELEFONE              PIC  9(009).*/
            public IntBasis DET_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  DET-DTNASC                PIC  X(008).*/
            public StringBasis DET_DTNASC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTEMIS                PIC  X(008).*/
            public StringBasis DET_DTEMIS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTINIVIG              PIC  X(008).*/
            public StringBasis DET_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  DET-DTTERVIG              PIC  X(008).*/
            public StringBasis DET_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  FILLER                    PIC  X(068) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "68", "X(068)"), @"");
            /*"    05  DET-APOLICE               PIC  9(015).*/
            public IntBasis DET_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  DET-SUBGRUPO              PIC  9(004).*/
            public IntBasis DET_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  FILLER                    PIC  X(003) VALUE '001'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"001");
            /*"    05  DET-NUM-ITEM              PIC  9(009).*/
            public IntBasis DET_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  DET-DTCANCEL              PIC  X(008).*/
            public StringBasis DET_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  FILLER                    PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"01  TRAILLER-RECORD.*/
        }
        public VA1473B_TRAILLER_RECORD TRAILLER_RECORD { get; set; } = new VA1473B_TRAILLER_RECORD();
        public class VA1473B_TRAILLER_RECORD : VarBasis
        {
            /*"    05  FILLER                    PIC  X(001) VALUE 'T'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"T");
            /*"    05  TRA-TOT-REGISTROS         PIC  9(008).*/
            public IntBasis TRA_TOT_REGISTROS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  TRA-TOT-INCLUSOES         PIC  9(008).*/
            public IntBasis TRA_TOT_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  TRA-TOT-ALTERACOES        PIC  9(008).*/
            public IntBasis TRA_TOT_ALTERACOES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  TRA-TOT-EXCLUSOES         PIC  9(008).*/
            public IntBasis TRA_TOT_EXCLUSOES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"01  WABEND.*/
        }
        public VA1473B_WABEND WABEND { get; set; } = new VA1473B_WABEND();
        public class VA1473B_WABEND : VarBasis
        {
            /*"      10  FILLER                  PIC  X(010) VALUE         'VA1473B  '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1473B  ");
            /*"      10  FILLER                  PIC  X(028) VALUE         ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10  FILLER                  PIC  X(014) VALUE         '    SQLCODE = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10  WSQLCODE                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD1 = '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10  WSQLERRD1               PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10  WSQLERRD2               PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRMC = '.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
            /*"      10  WSQLERRMC               PIC  X(070)   VALUE SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            /*"      10  LOCALIZA-ABEND-1.*/
            public VA1473B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1473B_LOCALIZA_ABEND_1();
            public class VA1473B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15  FILLER                  PIC  X(012)   VALUE           'PARAGRAFO = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15  PARAGRAFO               PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10  LOCALIZA-ABEND-2.*/
            }
            public VA1473B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1473B_LOCALIZA_ABEND_2();
            public class VA1473B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15  FILLER                  PIC  X(012)   VALUE           'COMANDO   = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15  COMANDO                 PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public VA1473B_WS_HORAS WS_HORAS { get; set; } = new VA1473B_WS_HORAS();
        public class VA1473B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA1473B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA1473B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA1473B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA1473B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VA1473B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA1473B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA1473B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA1473B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA1473B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_VA1473B_WS_HORA_FIM_R()
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
        public VA1473B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA1473B_TOTAIS_ROT();
        public class VA1473B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VA1473B_FILLER_22> FILLER_22 { get; set; } = new ListBasis<VA1473B_FILLER_22>(50);
            public class VA1473B_FILLER_22 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONARQEA CONARQEA { get; set; } = new Dclgens.CONARQEA();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.MOVIMEA MOVIMEA { get; set; } = new Dclgens.MOVIMEA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public VA1473B_CPROPVA CPROPVA { get; set; } = new VA1473B_CPROPVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string REPSAF_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                REPSAF.SetFile(REPSAF_FILE_NAME_P);

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
            /*" -316- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -318- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -320- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -324- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -326- OPEN OUTPUT REPSAF. */
            REPSAF.Open(REPSAF_RECORD);

            /*" -327- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -329- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -330- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -331- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -340- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -343- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -344- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -346- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -348- DISPLAY 'DTMOVABE ....... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DTMOVABE ....... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -349- MOVE SISTEMAS-DTCURREN TO W01DTSQL. */
            _.Move(SISTEMAS_DTCURREN, WS_WORK_AREAS.W01DTSQL);

            /*" -350- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -351- MOVE W01DTSQL TO SISTEMAS-DTCURINI. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURINI);

            /*" -352- MOVE ULT-DIA(W01MMSQL) TO W01DDSQL. */
            _.Move(WS_WORK_AREAS.TABELA_ULT_DIAS.TAB_DIAS_R.ULT_DIA[WS_WORK_AREAS.W01DTSQL.W01MMSQL], WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -354- MOVE W01DTSQL TO SISTEMAS-DTCURREN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURREN);

            /*" -355- DISPLAY 'DTCURINI ....... ' SISTEMAS-DTCURINI. */
            _.Display($"DTCURINI ....... {SISTEMAS_DTCURINI}");

            /*" -357- DISPLAY 'DTCURREN ....... ' SISTEMAS-DTCURREN. */
            _.Display($"DTCURREN ....... {SISTEMAS_DTCURREN}");

            /*" -358- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_WORK_AREAS.W01DTSQL);

            /*" -359- MOVE W01DDSQL TO W01DDINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTINV.W01DDINV);

            /*" -360- MOVE W01MMSQL TO W01MMINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTINV.W01MMINV);

            /*" -361- MOVE W01AASQL TO W01AAINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTINV.W01AAINV);

            /*" -370- MOVE W01DTINV TO HEA-DATA-CRIACAO. */
            _.Move(WS_WORK_AREAS.W01DTINV, HEADER_RECORD.HEA_DATA_CRIACAO);

            /*" -373- MOVE 'SELECT MAX NSAS' TO COMANDO. */
            _.Move("SELECT MAX NSAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -374- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -375- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -380- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -383- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -384- IF CONARQEA-NSAS EQUAL 0 */

            if (CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS == 0)
            {

                /*" -385- MOVE W01AASQL TO CONARQEA-ANO-REFERENCIA */
                _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);

                /*" -386- MOVE SPACES TO HEA-ARQUIVO-ANT */
                _.Move("", HEADER_RECORD.HEA_ARQUIVO_ANT);

                /*" -387- MOVE 0 TO CONARQEA-NUM-ARQUIVO */
                _.Move(0, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);

                /*" -388- ELSE */
            }
            else
            {


                /*" -389- MOVE 03 TO SII */
                _.Move(03, WS_HORAS.SII);

                /*" -390- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -392- MOVE 'SELECT NSAS' TO COMANDO */
                _.Move("SELECT NSAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -399- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

                M_0000_PRINCIPAL_DB_SELECT_3();

                /*" -401- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -402- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -403- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -404- END-IF */
                }


                /*" -405- MOVE CONARQEA-NUM-ARQUIVO TO HEA-NUM-ARQ-ANT */
                _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO, HEADER_RECORD.HEA_ARQUIVO_ANT.HEA_NUM_ARQ_ANT);

                /*" -407- MOVE CONARQEA-ANO-REFERENCIA TO WS-ANO-REF HEA-ANO-REF-ANT */
                _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA, WS_WORK_AREAS.WS_ANO_REF, HEADER_RECORD.HEA_ARQUIVO_ANT.HEA_ANO_REF_ANT);

                /*" -410- MOVE WS-ANO-REF-2 TO CONARQEA-ANO-REF-ANT. */
                _.Move(WS_WORK_AREAS.WS_ANO_REF_R.WS_ANO_REF_2, CONARQEA_ANO_REF_ANT);
            }


            /*" -412- ADD 1 TO CONARQEA-NSAS. */
            CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.Value = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS + 1;

            /*" -413- IF W01AASQL NOT EQUAL CONARQEA-ANO-REFERENCIA */

            if (WS_WORK_AREAS.W01DTSQL.W01AASQL != CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA)
            {

                /*" -414- MOVE 1 TO CONARQEA-NUM-ARQUIVO */
                _.Move(1, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);

                /*" -415- MOVE W01AASQL TO CONARQEA-ANO-REFERENCIA */
                _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);

                /*" -416- ELSE */
            }
            else
            {


                /*" -418- ADD 1 TO CONARQEA-NUM-ARQUIVO. */
                CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO.Value = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO + 1;
            }


            /*" -419- MOVE CONARQEA-NUM-ARQUIVO TO HEA-NUM-ARQ-ATU. */
            _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO, HEADER_RECORD.HEA_ARQUIVO_ATU.HEA_NUM_ARQ_ATU);

            /*" -420- MOVE CONARQEA-ANO-REFERENCIA TO WS-ANO-REF. */
            _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA, WS_WORK_AREAS.WS_ANO_REF);

            /*" -423- MOVE WS-ANO-REF-2 TO CONARQEA-ANO-REF-ATU HEA-ANO-REF-ATU. */
            _.Move(WS_WORK_AREAS.WS_ANO_REF_R.WS_ANO_REF_2, CONARQEA_ANO_REF_ATU, HEADER_RECORD.HEA_ARQUIVO_ATU.HEA_ANO_REF_ATU);

            /*" -425- WRITE REPSAF-RECORD FROM HEADER-RECORD. */
            _.Move(HEADER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -428- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -449- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -452- DISPLAY '*** VA1473B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VA1473B *** ABRINDO CURSOR ...");

            /*" -454- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -455- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -456- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -456- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -459- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -461- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -462- DISPLAY '*** VA1473B *** PROCESSANDO ...' . */
            _.Display($"*** VA1473B *** PROCESSANDO ...");

            /*" -465- PERFORM M-0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -468- MOVE 'INSERT CONT_ARQUIVOS_EA' TO COMANDO. */
            _.Move("INSERT CONT_ARQUIVOS_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -470- MOVE AC-INCLUIDOS TO CONARQEA-NUM-INCLUSOES TRA-TOT-INCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_INCLUIDOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_INCLUSOES, TRAILLER_RECORD.TRA_TOT_INCLUSOES);

            /*" -472- MOVE AC-ALTERADOS TO CONARQEA-NUM-ALTERACOES TRA-TOT-ALTERACOES. */
            _.Move(WS_WORK_AREAS.AC_ALTERADOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ALTERACOES, TRAILLER_RECORD.TRA_TOT_ALTERACOES);

            /*" -474- MOVE AC-EXCLUIDOS TO CONARQEA-NUM-EXCLUSOES TRA-TOT-EXCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_EXCLUIDOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_EXCLUSOES, TRAILLER_RECORD.TRA_TOT_EXCLUSOES);

            /*" -477- MOVE AC-REGISTROS TO CONARQEA-NUM-REGISTROS TRA-TOT-REGISTROS. */
            _.Move(WS_WORK_AREAS.AC_REGISTROS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_REGISTROS, TRAILLER_RECORD.TRA_TOT_REGISTROS);

            /*" -478- MOVE 05 TO SII. */
            _.Move(05, WS_HORAS.SII);

            /*" -479- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -491- PERFORM M_0000_PRINCIPAL_DB_INSERT_1 */

            M_0000_PRINCIPAL_DB_INSERT_1();

            /*" -494- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -495- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -497- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -497- WRITE REPSAF-RECORD FROM TRAILLER-RECORD. */
            _.Move(TRAILLER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -340- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 10 DAYS, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DTMOVABE-10, :SISTEMAS-DTCURREN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DTMOVABE_10, SISTEMAS_DTMOVABE_10);
                _.Move(executed_1.SISTEMAS_DTCURREN, SISTEMAS_DTCURREN);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -503- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -505- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -505- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -380- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :CONARQEA-NSAS FROM SEGUROS.CONT_ARQUIVOS_EA WHERE NSAS > 0 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONARQEA_NSAS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -449- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_BILHETE , NUM_APOLICE, 0 , COD_CLIENTE, OCORR_ENDERECO, DATA_QUITACAO, DATA_QUITACAO, DATA_QUITACAO + 1 YEAR, '3' , DATA_QUITACAO + 1 YEAR, 'SS' , '1' , 12, 'BILHE' FROM SEGUROS.BILHETE WHERE DATA_QUITACAO > :SISTEMAS-DTMOVABE-10 AND SITUACAO = '9' ORDER BY 6,1 END-EXEC. */
            CPROPVA = new VA1473B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_BILHETE
							, 
							NUM_APOLICE
							, 
							0
							, 
							COD_CLIENTE
							, 
							OCORR_ENDERECO
							, 
							DATA_QUITACAO
							, 
							DATA_QUITACAO
							, 
							DATA_QUITACAO + 1 YEAR
							, 
							'3'
							, 
							DATA_QUITACAO + 1 YEAR
							, 
							'SS'
							, 
							'1'
							, 
							12
							, 
							'BILHE' 
							FROM SEGUROS.BILHETE 
							WHERE DATA_QUITACAO > '{SISTEMAS_DTMOVABE_10}' 
							AND SITUACAO = '9' 
							ORDER BY 6
							,1";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -456- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-INSERT-1 */
        public void M_0000_PRINCIPAL_DB_INSERT_1()
        {
            /*" -491- EXEC SQL INSERT INTO SEGUROS.CONT_ARQUIVOS_EA VALUES (:CONARQEA-NSAS, :CONARQEA-ANO-REFERENCIA, :CONARQEA-NUM-ARQUIVO, CURRENT DATE, :CONARQEA-NUM-REGISTROS, :CONARQEA-NUM-INCLUSOES, :CONARQEA-NUM-ALTERACOES, :CONARQEA-NUM-EXCLUSOES, 'VA1473B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_0000_PRINCIPAL_DB_INSERT_1_Insert1 = new M_0000_PRINCIPAL_DB_INSERT_1_Insert1()
            {
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
                CONARQEA_ANO_REFERENCIA = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA.ToString(),
                CONARQEA_NUM_ARQUIVO = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO.ToString(),
                CONARQEA_NUM_REGISTROS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_REGISTROS.ToString(),
                CONARQEA_NUM_INCLUSOES = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_INCLUSOES.ToString(),
                CONARQEA_NUM_ALTERACOES = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ALTERACOES.ToString(),
                CONARQEA_NUM_EXCLUSOES = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_EXCLUSOES.ToString(),
            };

            M_0000_PRINCIPAL_DB_INSERT_1_Insert1.Execute(m_0000_PRINCIPAL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -515- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -516- IF PRODUVG-ORIG-PRODU EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -517- IF PROPVA-DTQIT10A < SISTEMAS-DATA-MOV-ABERTO */

                if (PROPVA_DTQIT10A < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
                {

                    /*" -519- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -520- IF PRODUVG-ORIG-PRODU EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -522- MOVE PROPOVA-NUM-CERTIFICADO TO CONVERSI-NUM-SICOB */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

                /*" -523- MOVE 06 TO SII */
                _.Move(06, WS_HORAS.SII);

                /*" -524- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -526- MOVE 'SELECT CONVERSI     ' TO COMANDO */
                _.Move("SELECT CONVERSI     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -534- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

                /*" -536- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -537- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -538- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -539- END-IF */
                }


                /*" -540- IF CONVERSI-COD-PRODUTO-SIVPF NOT EQUAL 09 */

                if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF != 09)
                {

                    /*" -541- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -542- END-IF */
                }


                /*" -545- IF CONVERSI-NUM-PROPOSTA-SIVPF > 50000000000000 AND CONVERSI-NUM-PROPOSTA-SIVPF < 59999999999999 NEXT SENTENCE */

                if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF > 50000000000000 && CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF < 59999999999999)
                {

                    /*" -546- ELSE */
                }
                else
                {


                    /*" -547- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -551- END-IF. */
                }

            }


            /*" -554- MOVE 'SELECT MOVIMENTO_EA MAX' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_EA MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -555- MOVE 08 TO SII */
            _.Move(08, WS_HORAS.SII);

            /*" -556- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -561- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -564- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -565- IF MOVIMEA-NSAS GREATER 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS > 0)
            {

                /*" -567- MOVE 'SELECT MOVIMENTO_EA MAX' TO COMANDO */
                _.Move("SELECT MOVIMENTO_EA MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -568- MOVE 09 TO SII */
                _.Move(09, WS_HORAS.SII);

                /*" -569- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -575- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

                /*" -577- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -578- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -582- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -585- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '4' OR PRODUVG-ORIG-PRODU EQUAL 'BILHE' NEXT SENTENCE */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO == "4" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -586- ELSE */
            }
            else
            {


                /*" -587- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '5' OR '3' */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO.In("5", "3"))
                {

                    /*" -589- MOVE 'SELECT PARCELAS_VIDAZUL' TO COMANDO */
                    _.Move("SELECT PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -590- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                    /*" -592- MOVE 10 TO SII */
                    _.Move(10, WS_HORAS.SII);

                    /*" -593- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO(true);

                    /*" -601- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

                    M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

                    /*" -603- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO(true);

                    /*" -604- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -605- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -607- IF PRODUVG-PERI-PAGAMENTO GREATER 01 NEXT SENTENCE */

                            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO > 01)
                            {

                                /*" -608- ELSE */
                            }
                            else
                            {


                                /*" -610- IF PROPOVA-SIT-REGISTRO EQUAL '4' NEXT SENTENCE */

                                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
                                {

                                    /*" -611- ELSE */
                                }
                                else
                                {


                                    /*" -612- GO TO 0100-NEXT */

                                    M_0100_NEXT(); //GOTO
                                    return;

                                    /*" -613- ELSE */
                                }

                            }

                        }
                        else
                        {


                            /*" -615- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                            if (DB.SQLCODE == -811)
                            {

                                /*" -616- ELSE */
                            }
                            else
                            {


                                /*" -618- DISPLAY 'ERRO NA LEITURA DA PARCELAS_VIDAZUL ' PROPOVA-NUM-CERTIFICADO */
                                _.Display($"ERRO NA LEITURA DA PARCELAS_VIDAZUL {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                                /*" -622- GO TO 9999-ERRO. */

                                M_9999_ERRO(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -623- IF MOVIMEA-NSAS EQUAL 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS == 0)
            {

                /*" -624- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                {

                    /*" -625- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -626- ELSE */
                }
                else
                {


                    /*" -627- MOVE 'I' TO MOVIMEA-TIPO-MOVIMENTO */
                    _.Move("I", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                    /*" -628- ELSE */
                }

            }
            else
            {


                /*" -629- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

                if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
                {

                    /*" -630- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
                    {

                        /*" -631- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -632- ELSE */
                    }
                    else
                    {


                        /*" -633- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO */
                        _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                        /*" -634- ELSE */
                    }

                }
                else
                {


                    /*" -635- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

                    if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
                    {

                        /*" -636- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                        {

                            /*" -637- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -638- ELSE */
                        }
                        else
                        {


                            /*" -639- MOVE 'A' TO MOVIMEA-TIPO-MOVIMENTO */
                            _.Move("A", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                            /*" -640- ELSE */
                        }

                    }
                    else
                    {


                        /*" -641- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
                        {

                            /*" -642- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -643- ELSE */
                        }
                        else
                        {


                            /*" -645- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO. */
                            _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
                        }

                    }

                }

            }


            /*" -646- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
            {

                /*" -647- MOVE 'IN' TO DET-TIPO-MOV */
                _.Move("IN", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -649- ADD 1 TO AC-INCLUIDOS. */
                WS_WORK_AREAS.AC_INCLUIDOS.Value = WS_WORK_AREAS.AC_INCLUIDOS + 1;
            }


            /*" -650- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'A' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "A")
            {

                /*" -651- MOVE 'AL' TO DET-TIPO-MOV */
                _.Move("AL", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -653- ADD 1 TO AC-ALTERADOS. */
                WS_WORK_AREAS.AC_ALTERADOS.Value = WS_WORK_AREAS.AC_ALTERADOS + 1;
            }


            /*" -654- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
            {

                /*" -655- MOVE 'EX' TO DET-TIPO-MOV */
                _.Move("EX", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -659- ADD 1 TO AC-EXCLUIDOS. */
                WS_WORK_AREAS.AC_EXCLUIDOS.Value = WS_WORK_AREAS.AC_EXCLUIDOS + 1;
            }


            /*" -662- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -663- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -666- MOVE 11 TO SII */
            _.Move(11, WS_HORAS.SII);

            /*" -667- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -676- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -679- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -680- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -682- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -683- IF CLIENT-DTNASC-I LESS ZEROES */

            if (CLIENT_DTNASC_I < 00)
            {

                /*" -685- MOVE 'SELECT SEGURADOS_VGAP' TO COMANDO */
                _.Move("SELECT SEGURADOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -686- MOVE 12 TO SII */
                _.Move(12, WS_HORAS.SII);

                /*" -687- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -693- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

                /*" -696- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -697- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -698- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -699- IF PRODUVG-ORIG-PRODU EQUAL 'GLOBAL' OR 'BILHE' */

                        if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("GLOBAL", "BILHE"))
                        {

                            /*" -700- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                            _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                            /*" -701- END-IF */
                        }


                        /*" -702- ELSE */
                    }
                    else
                    {


                        /*" -703- GO TO 9999-ERRO */

                        M_9999_ERRO(); //GOTO
                        return;

                        /*" -704- END-IF */
                    }


                    /*" -706- END-IF */
                }


                /*" -707- IF CLIENT-DTNASC-I LESS ZEROES */

                if (CLIENT_DTNASC_I < 00)
                {

                    /*" -709- DISPLAY 'DATA DE NASCIMENTO INVALIDA NAS TABELAS ' PROPOVA-COD-CLIENTE */
                    _.Display($"DATA DE NASCIMENTO INVALIDA NAS TABELAS {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                    /*" -724- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -727- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -728- MOVE 13 TO SII */
            _.Move(13, WS_HORAS.SII);

            /*" -729- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -746- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

            /*" -749- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -750- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -752- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -753- MOVE PRODUVG-COD-PRODUTO-EA TO DET-CODPRODEA. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA, DETAIL_RECORD.DET_CODPRODEA);

            /*" -754- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETAIL_RECORD.DET_NOME_RAZAO);

            /*" -755- MOVE ENDERECO-ENDERECO TO DET-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETAIL_RECORD.DET_ENDERECO);

            /*" -756- MOVE ENDERECO-BAIRRO TO DET-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETAIL_RECORD.DET_BAIRRO);

            /*" -757- MOVE ENDERECO-CIDADE TO DET-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETAIL_RECORD.DET_CIDADE);

            /*" -758- MOVE ENDERECO-SIGLA-UF TO DET-SIGLA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETAIL_RECORD.DET_SIGLA_UF);

            /*" -759- MOVE ENDERECO-CEP TO DET-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETAIL_RECORD.DET_CEP);

            /*" -760- MOVE ENDERECO-TELEFONE TO DET-TELEFONE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, DETAIL_RECORD.DET_TELEFONE);

            /*" -761- MOVE CLIENTES-CGCCPF TO DET-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETAIL_RECORD.DET_CGCCPF);

            /*" -762- MOVE CLIENTES-DATA-NASCIMENTO TO W01DTSQL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, WS_WORK_AREAS.W01DTSQL);

            /*" -763- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -764- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -765- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -766- MOVE W01DTCOR TO DET-DTNASC. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTNASC);

            /*" -767- MOVE PROPOVA-DATA-QUITACAO TO W01DTSQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WS_WORK_AREAS.W01DTSQL);

            /*" -768- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -769- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -770- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -771- MOVE W01DTCOR TO DET-DTEMIS. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTEMIS);

            /*" -772- MOVE W01DTCOR TO DET-DTINIVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTINIVIG);

            /*" -773- MOVE PROPVA-DTQIT10A TO W01DTSQL. */
            _.Move(PROPVA_DTQIT10A, WS_WORK_AREAS.W01DTSQL);

            /*" -774- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -775- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -776- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -777- MOVE W01DTCOR TO DET-DTTERVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTTERVIG);

            /*" -778- MOVE PROPOVA-NUM-CERTIFICADO TO DET-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, DETAIL_RECORD.DET_NRCERTIF);

            /*" -779- MOVE PROPOVA-NUM-APOLICE TO DET-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, DETAIL_RECORD.DET_APOLICE);

            /*" -781- MOVE PROPOVA-COD-SUBGRUPO TO DET-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, DETAIL_RECORD.DET_SUBGRUPO);

            /*" -781- PERFORM 0200-INSERT-REPSAF THRU 0200-FIM. */

            M_0200_INSERT_REPSAF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -534- EXEC SQL SELECT NUM_PROPOSTA_SIVPF , COD_PRODUTO_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :CONVERSI-NUM-SICOB END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_SICOB = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -399- EXEC SQL SELECT ANO_REFERENCIA, NUM_ARQUIVO INTO :CONARQEA-ANO-REFERENCIA, :CONARQEA-NUM-ARQUIVO FROM SEGUROS.CONT_ARQUIVOS_EA WHERE NSAS = :CONARQEA-NSAS END-EXEC */

            var m_0000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_PRINCIPAL_DB_SELECT_3_Query1()
            {
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONARQEA_ANO_REFERENCIA, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);
                _.Move(executed_1.CONARQEA_NUM_ARQUIVO, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -561- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :MOVIMEA-NSAS FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_NSAS, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -786- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -788- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -575- EXEC SQL SELECT TIPO_MOVIMENTO INTO :MOVIMEA-TIPO-MOVIMENTO FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NSAS = :MOVIMEA-NSAS END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                MOVIMEA_NSAS = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_TIPO_MOVIMENTO, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -601- EXEC SQL SELECT NUM_PARCELA INTO :PARCEVID-NUM-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO = '1' AND DATA_VENCIMENTO >= :SISTEMAS-DTCURINI AND DATA_VENCIMENTO <= :SISTEMAS-DTCURREN END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                SISTEMAS_DTCURINI = SISTEMAS_DTCURINI.ToString(),
                SISTEMAS_DTCURREN = SISTEMAS_DTCURREN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -799- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -802- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -803- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -804- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -820- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -823- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -825- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -826- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -828- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -828- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -830- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -831- ELSE */
                }
                else
                {


                    /*" -832- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -833- END-IF */
                }


                /*" -835- END-IF. */
            }


            /*" -836- IF PROPOVA-NUM-APOLICE EQUAL 109300000567 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300000567)
            {

                /*" -837- MOVE '4' TO PROPOVA-SIT-REGISTRO */
                _.Move("4", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -839- END-IF. */
            }


            /*" -841- IF PRODUVG-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' OR 'ESPE1' OR 'ESPE2' OR 'ESPE3' OR 'GLOBAL' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("EMPRE", "ESPEC", "ESPE1", "ESPE2", "ESPE3", "GLOBAL"))
            {

                /*" -842- IF PROPOVA-DTPROXVEN NOT EQUAL '9999-12-31' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN != "9999-12-31")
                {

                    /*" -843- GO TO 0110-FETCH */
                    new Task(() => M_0110_FETCH()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -844- END-IF */
                }


                /*" -846- END-IF. */
            }


            /*" -848- ADD 1 TO AC-LIDOS AC-CONTA */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;
            WS_WORK_AREAS.AC_CONTA.Value = WS_WORK_AREAS.AC_CONTA + 1;

            /*" -850- IF AC-CONTA > 999 */

            if (WS_WORK_AREAS.AC_CONTA > 999)
            {

                /*" -851- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_CONTA);

                /*" -852- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -853- DISPLAY 'LIDOS ---------> ' AC-LIDOS ' ' WS-TIME ' ' PROPOVA-NUM-CERTIFICADO. */

                $"LIDOS ---------> {WS_WORK_AREAS.AC_LIDOS} {WS_WORK_AREAS.WS_TIME} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -820- EXEC SQL FETCH CPROPVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-DATA-VENCIMENTO, :PROPOVA-DATA-QUITACAO, :PROPVA-DTQIT10A, :PROPOVA-SIT-REGISTRO, :PROPOVA-DTPROXVEN, :PRODUVG-COD-PRODUTO-EA:PRODVG-ICODPRODEA, :PRODUVG-OPCAO-PAGAMENTO, :PRODUVG-PERI-PAGAMENTO, :PRODUVG-ORIG-PRODU END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CPROPVA.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(CPROPVA.PROPOVA_DATA_VENCIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);
                _.Move(CPROPVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CPROPVA.PROPVA_DTQIT10A, PROPVA_DTQIT10A);
                _.Move(CPROPVA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CPROPVA.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CPROPVA.PRODUVG_COD_PRODUTO_EA, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);
                _.Move(CPROPVA.PRODVG_ICODPRODEA, PRODVG_ICODPRODEA);
                _.Move(CPROPVA.PRODUVG_OPCAO_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO);
                _.Move(CPROPVA.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CPROPVA.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -828- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -676- EXEC SQL SELECT CGCCPF, NOME_RAZAO, DATA_NASCIMENTO INTO :CLIENTES-CGCCPF, :CLIENTES-NOME-RAZAO, :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -693- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-0200-INSERT-REPSAF */
        private void M_0200_INSERT_REPSAF(bool isPerform = false)
        {
            /*" -864- MOVE '0200-INSERT-REPSAF' TO PARAGRAFO. */
            _.Move("0200-INSERT-REPSAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -867- MOVE 'INSERT MOVIMENTO_EA' TO COMANDO. */
            _.Move("INSERT MOVIMENTO_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -868- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -869- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -876- PERFORM M_0200_INSERT_REPSAF_DB_INSERT_1 */

            M_0200_INSERT_REPSAF_DB_INSERT_1();

            /*" -879- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -880- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -882- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -883- WRITE REPSAF-RECORD FROM DETAIL-RECORD. */
            _.Move(DETAIL_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -883- ADD 1 TO AC-REGISTROS. */
            WS_WORK_AREAS.AC_REGISTROS.Value = WS_WORK_AREAS.AC_REGISTROS + 1;

        }

        [StopWatch]
        /*" M-0200-INSERT-REPSAF-DB-INSERT-1 */
        public void M_0200_INSERT_REPSAF_DB_INSERT_1()
        {
            /*" -876- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_EA VALUES (:PROPOVA-NUM-CERTIFICADO, :CONARQEA-NSAS, :MOVIMEA-TIPO-MOVIMENTO, 'VA1473B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 = new M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
                MOVIMEA_TIPO_MOVIMENTO = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO.ToString(),
            };

            M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1.Execute(m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -746- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, TELEFONE INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-TELEFONE FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -895- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -896- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -898- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -898- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -901- DISPLAY ' ' . */
            _.Display($" ");

            /*" -902- DISPLAY 'LIDOS ..................... ' AC-LIDOS. */
            _.Display($"LIDOS ..................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -903- DISPLAY ' ' . */
            _.Display($" ");

            /*" -904- DISPLAY 'INCLUIDOS ................. ' AC-INCLUIDOS. */
            _.Display($"INCLUIDOS ................. {WS_WORK_AREAS.AC_INCLUIDOS}");

            /*" -905- DISPLAY 'ALTERADOS ................. ' AC-ALTERADOS. */
            _.Display($"ALTERADOS ................. {WS_WORK_AREAS.AC_ALTERADOS}");

            /*" -906- DISPLAY 'EXCLUIDOS ................. ' AC-EXCLUIDOS. */
            _.Display($"EXCLUIDOS ................. {WS_WORK_AREAS.AC_EXCLUIDOS}");

            /*" -907- DISPLAY ' ' . */
            _.Display($" ");

            /*" -907- DISPLAY '*** VA1473B *** TERMINO NORMAL' . */
            _.Display($"*** VA1473B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" R9000-00-INICIO */
        private void R9000_00_INICIO(bool isPerform = false)
        {
            /*" -915- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -916- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO */
        private void R9100_00_TERMINO(bool isPerform = false)
        {
            /*" -924- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -925- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -926- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -927- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -928- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_22[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_22[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS */
        private void R9900_00_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -936- DISPLAY ' ' . */
            _.Display($" ");

            /*" -937- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -942- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -943- IF SII < 16 */

            if (WS_HORAS.SII < 16)
            {

                /*" -944- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -946- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_22[WS_HORAS.SII]}"
                .Display();

                /*" -948- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -949- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -961- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -962- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -963- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -964- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -965- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -966- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -968- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -970- DISPLAY '*** VA1473B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA1473B *** ROLLBACK EM ANDAMENTO ...");

            /*" -970- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -973- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -975- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -975- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -978- DISPLAY ' ' . */
            _.Display($" ");

            /*" -979- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -980- DISPLAY ' ' . */
            _.Display($" ");

            /*" -981- DISPLAY 'CERTIFICADO...  ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"CERTIFICADO...  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -982- DISPLAY ' ' . */
            _.Display($" ");

            /*" -984- DISPLAY '*** VA1473B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA1473B *** ERRO DE EXECUCAO");

            /*" -985- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -985- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}