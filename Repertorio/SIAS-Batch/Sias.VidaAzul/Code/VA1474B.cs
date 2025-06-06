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
using Sias.VidaAzul.DB2.VA1474B;

namespace Code
{
    public class VA1474B
    {
        public bool IsCall { get; set; }

        public VA1474B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  GERA REPASE SAF PARA A ICATU       *      */
        /*"      *                             CONVENIO EUROPE ASSISTANCE, PARA   *      */
        /*"      *                             O PRODUTO EMPRESA GLOBAL.          *      */
        /*"      *   PERIODICIDADE >>>>>>>>>   ENVIA OS ARQUIVOS DIARIAMENTE.     *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FAST COMPUTER                      *      */
        /*"      *   PROGRAMA ...............  VA1474B                            *      */
        /*"      *   DATA ...................  14/03/2007                         *      */
        /*"      *   VERSAO DO PROGRAMA......  VA1471B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *               A L T E R A C O E S                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *VERSAO V.10-DEMANDA 510565 - RAUL 20/11/2023-Inclus�o de nova   *      */
        /*"V.10  * ap�lice 3008211398371 (ESG) para substituir 3008218874329      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *VERSAO V.09-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV108 *VERSAO 08: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV108 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV108 *           - PROCURAR POR JV108                                 *      */
        /*"JV108 *----------------------------------------------------------------*      */
        /*"      * VERSAO 07     EM 01/08/2019                                    *      */
        /*"      *    PARA ATENDER DEMANDA JAZZ 199509 - VINCULO ERRADO           *      */
        /*"      *    INCLUIR DUAS APOLICES: 0108211323063 E 0108211323064        *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.07                        CANETTA             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  006 - 04/02/2019 - ADAILTON DIAS                              *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 28/01/2019 - ATOS BR        PROCURAR POR JV1              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  005 - 14/02/2007 - LUCIA VIEITA                               *      */
        /*"      *    INIBE DISPLAYS PARA ATENDER CADMUS 1940                     *      */
        /*"      *                                                                *      */
        /*"      *                          PROCURAR POR V.03                     *      */
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
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 21/11/01 - MESSIAS                                      *      */
        /*"      *    O PRODUTO EXCLUSIVO, GEROU PARCELAS COM O MESMO VENCIMENTO. *      */
        /*"      * OCASIONOU, ABEND 811- NA LEITURA DA PARCELVA, IMPEDINDO O REPAS*      */
        /*"      * SE DO SAF NOVAMENTE.                       PROCURE POR MM1101  *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _REPSAF { get; set; } = new FileBasis(new PIC("X", "356", "X(356)"));

        public FileBasis REPSAF
        {
            get
            {
                _.Move(REPSAF_RECORD, _REPSAF); VarBasis.RedefinePassValue(REPSAF_RECORD, _REPSAF, REPSAF_RECORD); return _REPSAF;
            }
        }
        /*"01   REPSAF-RECORD PIC X(356).*/
        public StringBasis REPSAF_RECORD { get; set; } = new StringBasis(new PIC("X", "356", "X(356)."), @"");

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
        /*"01  CONARQEA-ANO-REF-ANT          PIC S9(04) COMP.*/
        public IntBasis CONARQEA_ANO_REF_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CONARQEA-ANO-REF-ATU          PIC S9(04) COMP.*/
        public IntBasis CONARQEA_ANO_REF_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  REPSAF-DTINIVIG               PIC  X(10).*/
        public StringBasis REPSAF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public VA1474B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VA1474B_WS_WORK_AREAS();
        public class VA1474B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-EOF                    PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WSQLCODE3                 PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  W01DTSQL.*/
            public VA1474B_W01DTSQL W01DTSQL { get; set; } = new VA1474B_W01DTSQL();
            public class VA1474B_W01DTSQL : VarBasis
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
            public VA1474B_W01DTCOR W01DTCOR { get; set; } = new VA1474B_W01DTCOR();
            public class VA1474B_W01DTCOR : VarBasis
            {
                /*"       05  W01DDCOR               PIC 9(002).*/
                public IntBasis W01DDCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01MMCOR               PIC 9(002).*/
                public IntBasis W01MMCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01AACOR               PIC 9(004).*/
                public IntBasis W01AACOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03  W01DTINV.*/
            }
            public VA1474B_W01DTINV W01DTINV { get; set; } = new VA1474B_W01DTINV();
            public class VA1474B_W01DTINV : VarBasis
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
            private _REDEF_VA1474B_WS_ANO_REF_R _ws_ano_ref_r { get; set; }
            public _REDEF_VA1474B_WS_ANO_REF_R WS_ANO_REF_R
            {
                get { _ws_ano_ref_r = new _REDEF_VA1474B_WS_ANO_REF_R(); _.Move(WS_ANO_REF, _ws_ano_ref_r); VarBasis.RedefinePassValue(WS_ANO_REF, _ws_ano_ref_r, WS_ANO_REF); _ws_ano_ref_r.ValueChanged += () => { _.Move(_ws_ano_ref_r, WS_ANO_REF); }; return _ws_ano_ref_r; }
                set { VarBasis.RedefinePassValue(value, _ws_ano_ref_r, WS_ANO_REF); }
            }  //Redefines
            public class _REDEF_VA1474B_WS_ANO_REF_R : VarBasis
            {
                /*"       05  FILLER                 PIC X(002).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       05  WS-ANO-REF-2           PIC 9(002).*/
                public IntBasis WS_ANO_REF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  TABELA-ULT-DIAS.*/

                public _REDEF_VA1474B_WS_ANO_REF_R()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_ANO_REF_2.ValueChanged += OnValueChanged;
                }

            }
            public VA1474B_TABELA_ULT_DIAS TABELA_ULT_DIAS { get; set; } = new VA1474B_TABELA_ULT_DIAS();
            public class VA1474B_TABELA_ULT_DIAS : VarBasis
            {
                /*"      05 TAB-DIAS.*/
                public VA1474B_TAB_DIAS TAB_DIAS { get; set; } = new VA1474B_TAB_DIAS();
                public class VA1474B_TAB_DIAS : VarBasis
                {
                    /*"         09  FILLER               PIC  X(024)   VALUE            '312831303130313130313031'.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                    /*"      05 TAB-DIAS-R               REDEFINES     TAB-DIAS.*/
                }
                private _REDEF_VA1474B_TAB_DIAS_R _tab_dias_r { get; set; }
                public _REDEF_VA1474B_TAB_DIAS_R TAB_DIAS_R
                {
                    get { _tab_dias_r = new _REDEF_VA1474B_TAB_DIAS_R(); _.Move(TAB_DIAS, _tab_dias_r); VarBasis.RedefinePassValue(TAB_DIAS, _tab_dias_r, TAB_DIAS); _tab_dias_r.ValueChanged += () => { _.Move(_tab_dias_r, TAB_DIAS); }; return _tab_dias_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_dias_r, TAB_DIAS); }
                }  //Redefines
                public class _REDEF_VA1474B_TAB_DIAS_R : VarBasis
                {
                    /*"         09  ULT-DIA              OCCURS  12    TIMES                                  PIC  X(002).*/
                    public ListBasis<StringBasis, string> ULT_DIA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "2", "X(002)."), 12);
                    /*"    03  WS-TIME                   PIC  X(008) VALUE  SPACES.*/

                    public _REDEF_VA1474B_TAB_DIAS_R()
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
        public VA1474B_HEADER_RECORD HEADER_RECORD { get; set; } = new VA1474B_HEADER_RECORD();
        public class VA1474B_HEADER_RECORD : VarBasis
        {
            /*"    05  FILLER                    PIC  X(021) VALUE      'HICATU HARTFORD'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"HICATU HARTFORD");
            /*"    05  HEA-DATA-CRIACAO          PIC  X(008).*/
            public StringBasis HEA_DATA_CRIACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  HEA-ARQUIVO-ATU.*/
            public VA1474B_HEA_ARQUIVO_ATU HEA_ARQUIVO_ATU { get; set; } = new VA1474B_HEA_ARQUIVO_ATU();
            public class VA1474B_HEA_ARQUIVO_ATU : VarBasis
            {
                /*"      10  FILLER                  PIC  X(002) VALUE        'IH'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"IH");
                /*"      10  HEA-ANO-REF-ATU         PIC  9(002).*/
                public IntBasis HEA_ANO_REF_ATU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10  HEA-NUM-ARQ-ATU         PIC  9(004).*/
                public IntBasis HEA_NUM_ARQ_ATU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HEA-ARQUIVO-ANT.*/
            }
            public VA1474B_HEA_ARQUIVO_ANT HEA_ARQUIVO_ANT { get; set; } = new VA1474B_HEA_ARQUIVO_ANT();
            public class VA1474B_HEA_ARQUIVO_ANT : VarBasis
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
        public VA1474B_DETAIL_RECORD DETAIL_RECORD { get; set; } = new VA1474B_DETAIL_RECORD();
        public class VA1474B_DETAIL_RECORD : VarBasis
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
            /*"    05  FILLER                    PIC  X(001) VALUE 'J'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"J");
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
            /*"    05  FILLER                    PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  DET-NUM-ITEM              PIC  9(009).*/
            public IntBasis DET_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  DET-QTD-MED-VIDAS         PIC  9(006) VALUE 000005.*/
            public IntBasis DET_QTD_MED_VIDAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 000005);
            /*"    05  DET-DTCANCEL              PIC  X(008).*/
            public StringBasis DET_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  FILLER                    PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"01  TRAILLER-RECORD.*/
        }
        public VA1474B_TRAILLER_RECORD TRAILLER_RECORD { get; set; } = new VA1474B_TRAILLER_RECORD();
        public class VA1474B_TRAILLER_RECORD : VarBasis
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
        public VA1474B_WABEND WABEND { get; set; } = new VA1474B_WABEND();
        public class VA1474B_WABEND : VarBasis
        {
            /*"      10  FILLER                  PIC  X(010) VALUE         'VA1474B  '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1474B  ");
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
            public VA1474B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1474B_LOCALIZA_ABEND_1();
            public class VA1474B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15  FILLER                PIC  X(012)   VALUE           'PARAGRAFO = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15  PARAGRAFO             PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10  LOCALIZA-ABEND-2.*/
            }
            public VA1474B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1474B_LOCALIZA_ABEND_2();
            public class VA1474B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15  FILLER                PIC  X(012)   VALUE           'COMANDO   = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15  COMANDO               PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public VA1474B_WS_HORAS WS_HORAS { get; set; } = new VA1474B_WS_HORAS();
        public class VA1474B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA1474B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA1474B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA1474B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA1474B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VA1474B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA1474B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA1474B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA1474B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA1474B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_VA1474B_WS_HORA_FIM_R()
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
        public VA1474B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA1474B_TOTAIS_ROT();
        public class VA1474B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VA1474B_FILLER_22> FILLER_22 { get; set; } = new ListBasis<VA1474B_FILLER_22>(50);
            public class VA1474B_FILLER_22 : VarBasis
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
        public VA1474B_CPROPVA CPROPVA { get; set; } = new VA1474B_CPROPVA();
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
            /*" -321- DISPLAY ' ' */
            _.Display($" ");

            /*" -323- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -331- DISPLAY 'PROGRAMA EM EXECUCAO VA1474B-' 'VERSAO V.10- DEMANDA 510565 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA EM EXECUCAO VA1474B-VERSAO V.10- DEMANDA 510565 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -333- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -335- DISPLAY ' ' */
            _.Display($" ");

            /*" -337- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -339- OPEN OUTPUT REPSAF. */
            REPSAF.Open(REPSAF_RECORD);

            /*" -340- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -342- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -343- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -344- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -351- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -354- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -355- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -357- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -359- DISPLAY 'DTMOVABE ....... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DTMOVABE ....... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -360- MOVE SISTEMAS-DTCURREN TO W01DTSQL. */
            _.Move(SISTEMAS_DTCURREN, WS_WORK_AREAS.W01DTSQL);

            /*" -361- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -362- MOVE W01DTSQL TO SISTEMAS-DTCURINI. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURINI);

            /*" -363- MOVE ULT-DIA(W01MMSQL) TO W01DDSQL. */
            _.Move(WS_WORK_AREAS.TABELA_ULT_DIAS.TAB_DIAS_R.ULT_DIA[WS_WORK_AREAS.W01DTSQL.W01MMSQL], WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -365- MOVE W01DTSQL TO SISTEMAS-DTCURREN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURREN);

            /*" -366- DISPLAY 'DTCURINI ....... ' SISTEMAS-DTCURINI. */
            _.Display($"DTCURINI ....... {SISTEMAS_DTCURINI}");

            /*" -368- DISPLAY 'DTCURREN ....... ' SISTEMAS-DTCURREN. */
            _.Display($"DTCURREN ....... {SISTEMAS_DTCURREN}");

            /*" -369- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_WORK_AREAS.W01DTSQL);

            /*" -370- MOVE W01DDSQL TO W01DDINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTINV.W01DDINV);

            /*" -371- MOVE W01MMSQL TO W01MMINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTINV.W01MMINV);

            /*" -372- MOVE W01AASQL TO W01AAINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTINV.W01AAINV);

            /*" -381- MOVE W01DTINV TO HEA-DATA-CRIACAO. */
            _.Move(WS_WORK_AREAS.W01DTINV, HEADER_RECORD.HEA_DATA_CRIACAO);

            /*" -384- MOVE 'SELECT MAX NSAS' TO COMANDO. */
            _.Move("SELECT MAX NSAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -385- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -386- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -391- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -394- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -395- IF CONARQEA-NSAS EQUAL 0 */

            if (CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS == 0)
            {

                /*" -396- MOVE W01AASQL TO CONARQEA-ANO-REFERENCIA */
                _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);

                /*" -397- MOVE SPACES TO HEA-ARQUIVO-ANT */
                _.Move("", HEADER_RECORD.HEA_ARQUIVO_ANT);

                /*" -398- MOVE 0 TO CONARQEA-NUM-ARQUIVO */
                _.Move(0, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);

                /*" -399- ELSE */
            }
            else
            {


                /*" -400- MOVE 03 TO SII */
                _.Move(03, WS_HORAS.SII);

                /*" -401- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -403- MOVE 'SELECT NSAS' TO COMANDO */
                _.Move("SELECT NSAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -410- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

                M_0000_PRINCIPAL_DB_SELECT_3();

                /*" -412- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -413- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -414- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -415- END-IF */
                }


                /*" -416- MOVE CONARQEA-NUM-ARQUIVO TO HEA-NUM-ARQ-ANT */
                _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO, HEADER_RECORD.HEA_ARQUIVO_ANT.HEA_NUM_ARQ_ANT);

                /*" -418- MOVE CONARQEA-ANO-REFERENCIA TO WS-ANO-REF HEA-ANO-REF-ANT */
                _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA, WS_WORK_AREAS.WS_ANO_REF, HEADER_RECORD.HEA_ARQUIVO_ANT.HEA_ANO_REF_ANT);

                /*" -421- MOVE WS-ANO-REF-2 TO CONARQEA-ANO-REF-ANT. */
                _.Move(WS_WORK_AREAS.WS_ANO_REF_R.WS_ANO_REF_2, CONARQEA_ANO_REF_ANT);
            }


            /*" -423- ADD 1 TO CONARQEA-NSAS. */
            CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.Value = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS + 1;

            /*" -424- IF W01AASQL NOT EQUAL CONARQEA-ANO-REFERENCIA */

            if (WS_WORK_AREAS.W01DTSQL.W01AASQL != CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA)
            {

                /*" -425- MOVE 1 TO CONARQEA-NUM-ARQUIVO */
                _.Move(1, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO);

                /*" -426- MOVE W01AASQL TO CONARQEA-ANO-REFERENCIA */
                _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA);

                /*" -427- ELSE */
            }
            else
            {


                /*" -429- ADD 1 TO CONARQEA-NUM-ARQUIVO. */
                CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO.Value = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO + 1;
            }


            /*" -430- MOVE CONARQEA-NUM-ARQUIVO TO HEA-NUM-ARQ-ATU. */
            _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ARQUIVO, HEADER_RECORD.HEA_ARQUIVO_ATU.HEA_NUM_ARQ_ATU);

            /*" -431- MOVE CONARQEA-ANO-REFERENCIA TO WS-ANO-REF. */
            _.Move(CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_ANO_REFERENCIA, WS_WORK_AREAS.WS_ANO_REF);

            /*" -434- MOVE WS-ANO-REF-2 TO CONARQEA-ANO-REF-ATU HEA-ANO-REF-ATU. */
            _.Move(WS_WORK_AREAS.WS_ANO_REF_R.WS_ANO_REF_2, CONARQEA_ANO_REF_ATU, HEADER_RECORD.HEA_ARQUIVO_ATU.HEA_ANO_REF_ATU);

            /*" -436- WRITE REPSAF-RECORD FROM HEADER-RECORD. */
            _.Move(HEADER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -439- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -471- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -476- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -477- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -478- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -478- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -481- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -484- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -487- PERFORM M-0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -490- MOVE 'INSERT CONT_ARQUIVOS_EA' TO COMANDO. */
            _.Move("INSERT CONT_ARQUIVOS_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -492- MOVE AC-INCLUIDOS TO CONARQEA-NUM-INCLUSOES TRA-TOT-INCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_INCLUIDOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_INCLUSOES, TRAILLER_RECORD.TRA_TOT_INCLUSOES);

            /*" -494- MOVE AC-ALTERADOS TO CONARQEA-NUM-ALTERACOES TRA-TOT-ALTERACOES. */
            _.Move(WS_WORK_AREAS.AC_ALTERADOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_ALTERACOES, TRAILLER_RECORD.TRA_TOT_ALTERACOES);

            /*" -496- MOVE AC-EXCLUIDOS TO CONARQEA-NUM-EXCLUSOES TRA-TOT-EXCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_EXCLUIDOS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_EXCLUSOES, TRAILLER_RECORD.TRA_TOT_EXCLUSOES);

            /*" -499- MOVE AC-REGISTROS TO CONARQEA-NUM-REGISTROS TRA-TOT-REGISTROS. */
            _.Move(WS_WORK_AREAS.AC_REGISTROS, CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NUM_REGISTROS, TRAILLER_RECORD.TRA_TOT_REGISTROS);

            /*" -500- MOVE 05 TO SII. */
            _.Move(05, WS_HORAS.SII);

            /*" -501- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -513- PERFORM M_0000_PRINCIPAL_DB_INSERT_1 */

            M_0000_PRINCIPAL_DB_INSERT_1();

            /*" -516- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -517- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -519- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -519- WRITE REPSAF-RECORD FROM TRAILLER-RECORD. */
            _.Move(TRAILLER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -351- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DTCURREN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DTCURREN, SISTEMAS_DTCURREN);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -525- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -527- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -527- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -391- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :CONARQEA-NSAS FROM SEGUROS.CONT_ARQUIVOS_EA WHERE NSAS > 0 END-EXEC. */

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
            /*" -471- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT A.NUM_CERTIFICADO, A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_CLIENTE, A.OCOREND , A.DATA_VENCIMENTO, A.DATA_QUITACAO, A.DATA_QUITACAO + 10 YEARS, A.SIT_REGISTRO, A.DTPROXVEN, B.COD_PRODUTO_EA, B.OPCAO_PAGAMENTO, B.PERI_PAGAMENTO, B.ORIG_PRODU FROM SEGUROS.PROPOSTAS_VA A, SEGUROS.PRODUTOS_VG B WHERE A.SIT_REGISTRO NOT IN ( '0' , '1' , '2' ) AND A.NUM_APOLICE IN (108208874329, 3008208874329, 3008218874329, 3008211398371, 109300000959, 0108211323063, 0108211323064) AND A.DTPROXVEN <> '9999-12-31' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO ORDER BY 6,1 END-EXEC. */
            CPROPVA = new VA1474B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_CLIENTE
							, 
							A.OCOREND
							, 
							A.DATA_VENCIMENTO
							, 
							A.DATA_QUITACAO
							, 
							A.DATA_QUITACAO + 10 YEARS
							, 
							A.SIT_REGISTRO
							, 
							A.DTPROXVEN
							, 
							B.COD_PRODUTO_EA
							, 
							B.OPCAO_PAGAMENTO
							, 
							B.PERI_PAGAMENTO
							, 
							B.ORIG_PRODU 
							FROM SEGUROS.PROPOSTAS_VA A
							, 
							SEGUROS.PRODUTOS_VG B 
							WHERE A.SIT_REGISTRO NOT IN ( '0'
							, '1'
							, '2' ) 
							AND A.NUM_APOLICE IN (108208874329
							, 
							3008208874329
							, 
							3008218874329
							, 
							3008211398371
							, 
							109300000959
							, 
							0108211323063
							, 
							0108211323064) 
							AND A.DTPROXVEN <> '9999-12-31' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
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
            /*" -478- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-INSERT-1 */
        public void M_0000_PRINCIPAL_DB_INSERT_1()
        {
            /*" -513- EXEC SQL INSERT INTO SEGUROS.CONT_ARQUIVOS_EA VALUES (:CONARQEA-NSAS, :CONARQEA-ANO-REFERENCIA, :CONARQEA-NUM-ARQUIVO, CURRENT DATE, :CONARQEA-NUM-REGISTROS, :CONARQEA-NUM-INCLUSOES, :CONARQEA-NUM-ALTERACOES, :CONARQEA-NUM-EXCLUSOES, 'VA1474B' , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -537- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -538- IF PRODUVG-ORIG-PRODU EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -539- IF PROPVA-DTQIT10A < SISTEMAS-DATA-MOV-ABERTO */

                if (PROPVA_DTQIT10A < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
                {

                    /*" -541- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -542- IF PRODUVG-ORIG-PRODU EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -544- IF PROPOVA-NUM-CERTIFICADO > 80000000000 AND PROPOVA-NUM-CERTIFICADO < 89999999999 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO > 80000000000 && PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO < 89999999999)
                {

                    /*" -546- GO TO 0100-NEXT. */

                    M_0100_NEXT(); //GOTO
                    return;
                }

            }


            /*" -547- IF PRODUVG-ORIG-PRODU EQUAL 'BILHE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -549- MOVE PROPOVA-NUM-CERTIFICADO TO CONVERSI-NUM-SICOB */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_SICOB);

                /*" -550- MOVE 06 TO SII */
                _.Move(06, WS_HORAS.SII);

                /*" -551- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -553- MOVE 'SELECT CONVERSI     ' TO COMANDO */
                _.Move("SELECT CONVERSI     ", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -561- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

                /*" -563- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -564- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -565- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -566- END-IF */
                }


                /*" -567- IF CONVERSI-COD-PRODUTO-SIVPF NOT EQUAL 09 */

                if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF != 09)
                {

                    /*" -568- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -569- END-IF */
                }


                /*" -572- IF CONVERSI-NUM-PROPOSTA-SIVPF > 50000000000000 AND CONVERSI-NUM-PROPOSTA-SIVPF < 59999999999999 NEXT SENTENCE */

                if (CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF > 50000000000000 && CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF < 59999999999999)
                {

                    /*" -573- ELSE */
                }
                else
                {


                    /*" -574- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -578- END-IF. */
                }

            }


            /*" -581- MOVE 'SELECT MOVIMENTO_EA MAX' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_EA MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -582- MOVE 08 TO SII */
            _.Move(08, WS_HORAS.SII);

            /*" -583- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -588- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

            /*" -591- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -592- IF MOVIMEA-NSAS GREATER 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS > 0)
            {

                /*" -594- MOVE 'SELECT MOVIMENTO_EA MAX' TO COMANDO */
                _.Move("SELECT MOVIMENTO_EA MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -595- MOVE 09 TO SII */
                _.Move(09, WS_HORAS.SII);

                /*" -596- PERFORM R9000-00-INICIO */

                R9000_00_INICIO(true);

                /*" -602- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

                /*" -604- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO(true);

                /*" -605- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -609- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -612- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '4' OR PRODUVG-ORIG-PRODU EQUAL 'BILHE' NEXT SENTENCE */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO == "4" || PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "BILHE")
            {

                /*" -613- ELSE */
            }
            else
            {


                /*" -614- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '5' OR '3' */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO.In("5", "3"))
                {

                    /*" -616- MOVE 'SELECT PARCELAS_VIDAZUL' TO COMANDO */
                    _.Move("SELECT PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -617- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                    /*" -619- MOVE 10 TO SII */
                    _.Move(10, WS_HORAS.SII);

                    /*" -620- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO(true);

                    /*" -628- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

                    M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

                    /*" -630- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO(true);

                    /*" -631- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -632- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -634- IF PRODUVG-PERI-PAGAMENTO GREATER 01 NEXT SENTENCE */

                            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO > 01)
                            {

                                /*" -635- ELSE */
                            }
                            else
                            {


                                /*" -637- IF PROPOVA-SIT-REGISTRO EQUAL '4' NEXT SENTENCE */

                                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "4")
                                {

                                    /*" -638- ELSE */
                                }
                                else
                                {


                                    /*" -639- GO TO 0100-NEXT */

                                    M_0100_NEXT(); //GOTO
                                    return;

                                    /*" -640- ELSE */
                                }

                            }

                        }
                        else
                        {


                            /*" -642- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                            if (DB.SQLCODE == -811)
                            {

                                /*" -643- ELSE */
                            }
                            else
                            {


                                /*" -645- DISPLAY 'ERRO NA LEITURA DA PARCELAS_VIDAZUL ' PROPOVA-NUM-CERTIFICADO */
                                _.Display($"ERRO NA LEITURA DA PARCELAS_VIDAZUL {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                                /*" -650- GO TO 9999-ERRO. */

                                M_9999_ERRO(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -651- IF MOVIMEA-NSAS EQUAL 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS == 0)
            {

                /*" -652- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                {

                    /*" -653- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -654- ELSE */
                }
                else
                {


                    /*" -655- MOVE 'I' TO MOVIMEA-TIPO-MOVIMENTO */
                    _.Move("I", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                    /*" -656- ELSE */
                }

            }
            else
            {


                /*" -657- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

                if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
                {

                    /*" -658- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
                    {

                        /*" -659- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -660- ELSE */
                    }
                    else
                    {


                        /*" -661- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO */
                        _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                        /*" -662- ELSE */
                    }

                }
                else
                {


                    /*" -663- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

                    if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
                    {

                        /*" -664- IF PROPOVA-SIT-REGISTRO NOT EQUAL '3' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO != "3")
                        {

                            /*" -665- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -666- ELSE */
                        }
                        else
                        {


                            /*" -667- MOVE 'A' TO MOVIMEA-TIPO-MOVIMENTO */
                            _.Move("A", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                            /*" -668- ELSE */
                        }

                    }
                    else
                    {


                        /*" -669- IF PROPOVA-SIT-REGISTRO EQUAL '3' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "3")
                        {

                            /*" -670- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -671- ELSE */
                        }
                        else
                        {


                            /*" -673- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO. */
                            _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
                        }

                    }

                }

            }


            /*" -674- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
            {

                /*" -675- MOVE 'IN' TO DET-TIPO-MOV */
                _.Move("IN", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -677- ADD 1 TO AC-INCLUIDOS. */
                WS_WORK_AREAS.AC_INCLUIDOS.Value = WS_WORK_AREAS.AC_INCLUIDOS + 1;
            }


            /*" -678- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'A' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "A")
            {

                /*" -679- MOVE 'AL' TO DET-TIPO-MOV */
                _.Move("AL", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -681- ADD 1 TO AC-ALTERADOS. */
                WS_WORK_AREAS.AC_ALTERADOS.Value = WS_WORK_AREAS.AC_ALTERADOS + 1;
            }


            /*" -682- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
            {

                /*" -683- MOVE 'EX' TO DET-TIPO-MOV */
                _.Move("EX", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -687- ADD 1 TO AC-EXCLUIDOS. */
                WS_WORK_AREAS.AC_EXCLUIDOS.Value = WS_WORK_AREAS.AC_EXCLUIDOS + 1;
            }


            /*" -690- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -691- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -694- MOVE 11 TO SII */
            _.Move(11, WS_HORAS.SII);

            /*" -695- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -702- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -705- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -706- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -708- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -710- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
            _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

            /*" -713- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -714- MOVE 13 TO SII */
            _.Move(13, WS_HORAS.SII);

            /*" -715- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -732- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

            /*" -735- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -738- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -739- MOVE PRODUVG-COD-PRODUTO-EA TO DET-CODPRODEA. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA, DETAIL_RECORD.DET_CODPRODEA);

            /*" -740- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETAIL_RECORD.DET_NOME_RAZAO);

            /*" -741- MOVE ENDERECO-ENDERECO TO DET-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETAIL_RECORD.DET_ENDERECO);

            /*" -742- MOVE ENDERECO-BAIRRO TO DET-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETAIL_RECORD.DET_BAIRRO);

            /*" -743- MOVE ENDERECO-CIDADE TO DET-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETAIL_RECORD.DET_CIDADE);

            /*" -744- MOVE ENDERECO-SIGLA-UF TO DET-SIGLA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETAIL_RECORD.DET_SIGLA_UF);

            /*" -745- MOVE ENDERECO-CEP TO DET-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETAIL_RECORD.DET_CEP);

            /*" -746- MOVE ENDERECO-TELEFONE TO DET-TELEFONE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, DETAIL_RECORD.DET_TELEFONE);

            /*" -747- MOVE CLIENTES-CGCCPF TO DET-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETAIL_RECORD.DET_CGCCPF);

            /*" -748- MOVE CLIENTES-DATA-NASCIMENTO TO W01DTSQL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, WS_WORK_AREAS.W01DTSQL);

            /*" -749- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -750- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -751- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -752- MOVE W01DTCOR TO DET-DTNASC. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTNASC);

            /*" -753- MOVE PROPOVA-DATA-QUITACAO TO W01DTSQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WS_WORK_AREAS.W01DTSQL);

            /*" -754- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -755- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -756- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -757- MOVE W01DTCOR TO DET-DTEMIS. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTEMIS);

            /*" -758- MOVE W01DTCOR TO DET-DTINIVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTINIVIG);

            /*" -759- MOVE PROPVA-DTQIT10A TO W01DTSQL. */
            _.Move(PROPVA_DTQIT10A, WS_WORK_AREAS.W01DTSQL);

            /*" -760- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -761- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -762- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -763- MOVE W01DTCOR TO DET-DTTERVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTTERVIG);

            /*" -764- MOVE PROPOVA-NUM-CERTIFICADO TO DET-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, DETAIL_RECORD.DET_NRCERTIF);

            /*" -765- MOVE PROPOVA-NUM-APOLICE TO DET-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, DETAIL_RECORD.DET_APOLICE);

            /*" -767- MOVE PROPOVA-COD-SUBGRUPO TO DET-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, DETAIL_RECORD.DET_SUBGRUPO);

            /*" -767- PERFORM 0200-INSERT-REPSAF THRU 0200-FIM. */

            M_0200_INSERT_REPSAF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -561- EXEC SQL SELECT NUM_PROPOSTA_SIVPF , COD_PRODUTO_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF , :CONVERSI-COD-PRODUTO-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :CONVERSI-NUM-SICOB END-EXEC */

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
            /*" -410- EXEC SQL SELECT ANO_REFERENCIA, NUM_ARQUIVO INTO :CONARQEA-ANO-REFERENCIA, :CONARQEA-NUM-ARQUIVO FROM SEGUROS.CONT_ARQUIVOS_EA WHERE NSAS = :CONARQEA-NSAS END-EXEC */

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
            /*" -588- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :MOVIMEA-NSAS FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

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
            /*" -772- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -774- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -602- EXEC SQL SELECT TIPO_MOVIMENTO INTO :MOVIMEA-TIPO-MOVIMENTO FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NSAS = :MOVIMEA-NSAS END-EXEC */

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
            /*" -628- EXEC SQL SELECT NUM_PARCELA INTO :PARCEVID-NUM-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO = '1' AND DATA_VENCIMENTO >= :SISTEMAS-DTCURINI AND DATA_VENCIMENTO <= :SISTEMAS-DTCURREN END-EXEC */

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
            /*" -785- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -788- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -789- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -790- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -806- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -809- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -810- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -811- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -812- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -814- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -814- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -816- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -817- ELSE */
                }
                else
                {


                    /*" -818- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -819- END-IF */
                }


                /*" -828- END-IF. */
            }


            /*" -830- IF PRODUVG-ORIG-PRODU EQUAL 'GLOBAL' NEXT SENTENCE */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU == "GLOBAL")
            {

                /*" -831- ELSE */
            }
            else
            {


                /*" -832- GO TO 0110-FETCH */
                new Task(() => M_0110_FETCH()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -835- END-IF. */
            }


            /*" -837- ADD 1 TO AC-LIDOS AC-CONTA */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;
            WS_WORK_AREAS.AC_CONTA.Value = WS_WORK_AREAS.AC_CONTA + 1;

            /*" -838- IF AC-CONTA > 999 */

            if (WS_WORK_AREAS.AC_CONTA > 999)
            {

                /*" -839- PERFORM R9900-00-MOSTRA-TOTAIS */

                R9900_00_MOSTRA_TOTAIS(true);

                /*" -840- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WS_WORK_AREAS.AC_CONTA);

                /*" -841- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -842- DISPLAY 'LIDOS ---------> ' AC-LIDOS ' ' WS-TIME ' ' PROPOVA-NUM-CERTIFICADO. */

                $"LIDOS ---------> {WS_WORK_AREAS.AC_LIDOS} {WS_WORK_AREAS.WS_TIME} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -806- EXEC SQL FETCH CPROPVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-DATA-VENCIMENTO, :PROPOVA-DATA-QUITACAO, :PROPVA-DTQIT10A, :PROPOVA-SIT-REGISTRO, :PROPOVA-DTPROXVEN, :PRODUVG-COD-PRODUTO-EA:PRODVG-ICODPRODEA, :PRODUVG-OPCAO-PAGAMENTO, :PRODUVG-PERI-PAGAMENTO, :PRODUVG-ORIG-PRODU END-EXEC. */

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
            /*" -814- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -702- EXEC SQL SELECT CGCCPF, NOME_RAZAO INTO :CLIENTES-CGCCPF, :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -732- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, TELEFONE INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-TELEFONE FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :PROPOVA-OCOREND END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
                PROPOVA_OCOREND = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_6_Query1);
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

        [StopWatch]
        /*" M-0200-INSERT-REPSAF */
        private void M_0200_INSERT_REPSAF(bool isPerform = false)
        {
            /*" -853- MOVE '0200-INSERT-REPSAF' TO PARAGRAFO. */
            _.Move("0200-INSERT-REPSAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -856- MOVE 'INSERT MOVIMENTO_EA' TO COMANDO. */
            _.Move("INSERT MOVIMENTO_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -857- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -858- PERFORM R9000-00-INICIO */

            R9000_00_INICIO(true);

            /*" -865- PERFORM M_0200_INSERT_REPSAF_DB_INSERT_1 */

            M_0200_INSERT_REPSAF_DB_INSERT_1();

            /*" -868- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO(true);

            /*" -869- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -871- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -872- WRITE REPSAF-RECORD FROM DETAIL-RECORD. */
            _.Move(DETAIL_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -872- ADD 1 TO AC-REGISTROS. */
            WS_WORK_AREAS.AC_REGISTROS.Value = WS_WORK_AREAS.AC_REGISTROS + 1;

        }

        [StopWatch]
        /*" M-0200-INSERT-REPSAF-DB-INSERT-1 */
        public void M_0200_INSERT_REPSAF_DB_INSERT_1()
        {
            /*" -865- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_EA VALUES (:PROPOVA-NUM-CERTIFICADO, :CONARQEA-NSAS, :MOVIMEA-TIPO-MOVIMENTO, 'VA1474B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 = new M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                CONARQEA_NSAS = CONARQEA.DCLCONT_ARQUIVOS_EA.CONARQEA_NSAS.ToString(),
                MOVIMEA_TIPO_MOVIMENTO = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO.ToString(),
            };

            M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1.Execute(m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -884- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -885- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -888- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -889- DISPLAY ' ' . */
            _.Display($" ");

            /*" -890- DISPLAY 'LIDOS ..................... ' AC-LIDOS. */
            _.Display($"LIDOS ..................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -891- DISPLAY ' ' . */
            _.Display($" ");

            /*" -892- DISPLAY 'INCLUIDOS ................. ' AC-INCLUIDOS. */
            _.Display($"INCLUIDOS ................. {WS_WORK_AREAS.AC_INCLUIDOS}");

            /*" -893- DISPLAY 'ALTERADOS ................. ' AC-ALTERADOS. */
            _.Display($"ALTERADOS ................. {WS_WORK_AREAS.AC_ALTERADOS}");

            /*" -894- DISPLAY 'EXCLUIDOS ................. ' AC-EXCLUIDOS. */
            _.Display($"EXCLUIDOS ................. {WS_WORK_AREAS.AC_EXCLUIDOS}");

            /*" -895- DISPLAY ' ' . */
            _.Display($" ");

            /*" -895- DISPLAY '*** VA1474B *** TERMINO NORMAL' . */
            _.Display($"*** VA1474B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" R9000-00-INICIO */
        private void R9000_00_INICIO(bool isPerform = false)
        {
            /*" -903- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -904- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO */
        private void R9100_00_TERMINO(bool isPerform = false)
        {
            /*" -912- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -913- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -914- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -915- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -916- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_22[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_22[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS */
        private void R9900_00_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -924- DISPLAY ' ' . */
            _.Display($" ");

            /*" -925- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -930- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -931- IF SII < 16 */

            if (WS_HORAS.SII < 16)
            {

                /*" -932- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -934- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_22[WS_HORAS.SII]}"
                .Display();

                /*" -936- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -937- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -949- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -950- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -951- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -952- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -953- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -954- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WABEND.WSQLERRMC);

            /*" -956- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -958- DISPLAY '*** VA1474B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VA1474B *** ROLLBACK EM ANDAMENTO ...");

            /*" -958- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -961- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -963- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -963- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -966- DISPLAY ' ' . */
            _.Display($" ");

            /*" -967- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -968- DISPLAY ' ' . */
            _.Display($" ");

            /*" -969- DISPLAY 'CERTIFICADO...  ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"CERTIFICADO...  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -970- DISPLAY ' ' . */
            _.Display($" ");

            /*" -972- DISPLAY '*** VA1474B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VA1474B *** ERRO DE EXECUCAO");

            /*" -973- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -973- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}