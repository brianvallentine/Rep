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
using Sias.VidaEmGrupo.DB2.VG1473B;

namespace Code
{
    public class VG1473B
    {
        public bool IsCall { get; set; }

        public VG1473B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA ARQUIVO SAM PARA FARMASSIST   *      */
        /*"      *                             CONVENIO USS, PARA                 *      */
        /*"      *                             APOLICES VIDA MULHER (VG).         *      */
        /*"      *                                                                *      */
        /*"      *   PERIODICIDADE >>>>>>>>>   ENVIA OS ARQUIVOS DIARIAMENTE NO   *      */
        /*"      *                                        (JPVGD02)               *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  NORA CORTABERRIA SANZ              *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1473B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  02/03/2005                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *               A L T E R A C O E S                              *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO XX - HIST 181.584                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * O NSAS DO MOVIMENTO-EA N O SER  MAIS O MESMO QUE O NSAS DO     *      */
        /*"      * CONT_ARQUIVOS_EA (SEQUENCIAL POR ANO) SE NA  QUE SER  IGUAL    *      */
        /*"      * AO SEQ-GERACAO DA GE_AR_DETALHE (SEQUENCIAL POR ARQUIVO)       *      */
        /*"      * 31/05/05 NORA                                                  *      */
        /*"      *          NAO GRAVAR NA MOVIMENTOS-EA POIS O VA9471B GRAVA A    *      */
        /*"      *          MESMA COISA PARA O SAF                                *      */
        /*"      * 28/06/05 NORA                                                  *      */
        /*"      *          COLOCAR AS LINHAS DE ESCREVER NO ARQUIVO FORA DO      *      */
        /*"      *          PARAGRAFO 0200-INSERT-REPSAF (DESDE A ANTERIOR ALTE-  *      */
        /*"      *          RACAO O ARQUIVO DE SAIDA ESTA VAZIO)                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  25/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *    INCLUSAO DA CLAUSULA WITH UR NO COMANDO SELECT   - WV0808   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  15/10/08   FAST COMPUTER                           *      */
        /*"      * CAD-16.057                                                     *      */
        /*"      *                                                                *      */
        /*"      * CORRECAO DO ABEND OCORRIDO NA TABELA GE_AR_DETALHE             *      */
        /*"      *                                        PROCURE POR V.01        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  20/08/09   CESAR DALAZUANA                         *      */
        /*"      * CAD-28.693                                                     *      */
        /*"      *                                                                *      */
        /*"      * INCLUSAO DE CAMPOS NA TABELA  GE_AR_DETALHE                    *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _REPSAF { get; set; } = new FileBasis(new PIC("X", "496", "X(496)"));

        public FileBasis REPSAF
        {
            get
            {
                _.Move(REPSAF_RECORD, _REPSAF); VarBasis.RedefinePassValue(REPSAF_RECORD, _REPSAF, REPSAF_RECORD); return _REPSAF;
            }
        }
        /*"01   REPSAF-RECORD PIC X(496).*/
        public StringBasis REPSAF_RECORD { get; set; } = new StringBasis(new PIC("X", "496", "X(496)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  PROPVA-DTQIT10A               PIC  X(10).*/
        public StringBasis PROPVA_DTQIT10A { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I               PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  ENDERECO-DES-COMPLEMENTO-I    PIC S9(04) COMP.*/
        public IntBasis ENDERECO_DES_COMPLEMENTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PRODVG-ICODPRODEA             PIC S9(04) COMP.*/
        public IntBasis PRODVG_ICODPRODEA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WNUM-ITEM-NUM-9               PIC 9(09).*/
        public IntBasis WNUM_ITEM_NUM_9 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
        /*"01  WNUM-ITEM.*/
        public VG1473B_WNUM_ITEM WNUM_ITEM { get; set; } = new VG1473B_WNUM_ITEM();
        public class VG1473B_WNUM_ITEM : VarBasis
        {
            /*"    03  WNUM-ITEM-NUM-5           PIC  9(05).*/
            public IntBasis WNUM_ITEM_NUM_5 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    03  WNUM-ITEM-ALF-5     REDEFINES WNUM-ITEM-NUM-5                                  PIC X(05).*/
            private _REDEF_StringBasis _wnum_item_alf_5 { get; set; }
            public _REDEF_StringBasis WNUM_ITEM_ALF_5
            {
                get { _wnum_item_alf_5 = new _REDEF_StringBasis(new PIC("X", "05", "X(05).")); ; _.Move(WNUM_ITEM_NUM_5, _wnum_item_alf_5); VarBasis.RedefinePassValue(WNUM_ITEM_NUM_5, _wnum_item_alf_5, WNUM_ITEM_NUM_5); _wnum_item_alf_5.ValueChanged += () => { _.Move(_wnum_item_alf_5, WNUM_ITEM_NUM_5); }; return _wnum_item_alf_5; }
                set { VarBasis.RedefinePassValue(value, _wnum_item_alf_5, WNUM_ITEM_NUM_5); }
            }  //Redefines
            /*"01  SISTEMAS-DTCURREN             PIC  X(10).*/
        }
        public StringBasis SISTEMAS_DTCURREN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  SISTEMAS-DTCURINI             PIC  X(10).*/
        public StringBasis SISTEMAS_DTCURINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01 WS-DISPLAY-GERAL         PIC  X(01) VALUE ' '.*/

        public SelectorBasis WS_DISPLAY_GERAL { get; set; } = new SelectorBasis("01", " ")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-DISPLAY-G                     VALUE 'S'. */
							new SelectorItemBasis("WS_DISPLAY_G", "S")
                }
        };

        /*"01  WS-WORK-AREAS.*/
        public VG1473B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VG1473B_WS_WORK_AREAS();
        public class VG1473B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-FLAG                   PIC 9 VALUE 0.*/
            public IntBasis WS_FLAG { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOF                    PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WSQLCODE3                 PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03  W01DTSQL.*/
            public VG1473B_W01DTSQL W01DTSQL { get; set; } = new VG1473B_W01DTSQL();
            public class VG1473B_W01DTSQL : VarBasis
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
            public VG1473B_W01DTCOR W01DTCOR { get; set; } = new VG1473B_W01DTCOR();
            public class VG1473B_W01DTCOR : VarBasis
            {
                /*"       05  W01DDCOR               PIC 9(002).*/
                public IntBasis W01DDCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01MMCOR               PIC 9(002).*/
                public IntBasis W01MMCOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01AACOR               PIC 9(004).*/
                public IntBasis W01AACOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03  W01DTINV.*/
            }
            public VG1473B_W01DTINV W01DTINV { get; set; } = new VG1473B_W01DTINV();
            public class VG1473B_W01DTINV : VarBasis
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
            private _REDEF_VG1473B_WS_ANO_REF_R _ws_ano_ref_r { get; set; }
            public _REDEF_VG1473B_WS_ANO_REF_R WS_ANO_REF_R
            {
                get { _ws_ano_ref_r = new _REDEF_VG1473B_WS_ANO_REF_R(); _.Move(WS_ANO_REF, _ws_ano_ref_r); VarBasis.RedefinePassValue(WS_ANO_REF, _ws_ano_ref_r, WS_ANO_REF); _ws_ano_ref_r.ValueChanged += () => { _.Move(_ws_ano_ref_r, WS_ANO_REF); }; return _ws_ano_ref_r; }
                set { VarBasis.RedefinePassValue(value, _ws_ano_ref_r, WS_ANO_REF); }
            }  //Redefines
            public class _REDEF_VG1473B_WS_ANO_REF_R : VarBasis
            {
                /*"       05  FILLER                 PIC X(002).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       05  WS-ANO-REF-2           PIC 9(002).*/
                public IntBasis WS_ANO_REF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03  TABELA-ULT-DIAS.*/

                public _REDEF_VG1473B_WS_ANO_REF_R()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_ANO_REF_2.ValueChanged += OnValueChanged;
                }

            }
            public VG1473B_TABELA_ULT_DIAS TABELA_ULT_DIAS { get; set; } = new VG1473B_TABELA_ULT_DIAS();
            public class VG1473B_TABELA_ULT_DIAS : VarBasis
            {
                /*"      05 TAB-DIAS.*/
                public VG1473B_TAB_DIAS TAB_DIAS { get; set; } = new VG1473B_TAB_DIAS();
                public class VG1473B_TAB_DIAS : VarBasis
                {
                    /*"         09  FILLER               PIC  X(024)   VALUE            '312831303130313130313031'.*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                    /*"      05 TAB-DIAS-R               REDEFINES     TAB-DIAS.*/
                }
                private _REDEF_VG1473B_TAB_DIAS_R _tab_dias_r { get; set; }
                public _REDEF_VG1473B_TAB_DIAS_R TAB_DIAS_R
                {
                    get { _tab_dias_r = new _REDEF_VG1473B_TAB_DIAS_R(); _.Move(TAB_DIAS, _tab_dias_r); VarBasis.RedefinePassValue(TAB_DIAS, _tab_dias_r, TAB_DIAS); _tab_dias_r.ValueChanged += () => { _.Move(_tab_dias_r, TAB_DIAS); }; return _tab_dias_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_dias_r, TAB_DIAS); }
                }  //Redefines
                public class _REDEF_VG1473B_TAB_DIAS_R : VarBasis
                {
                    /*"         09  ULT-DIA              OCCURS  12    TIMES                                  PIC  X(002).*/
                    public ListBasis<StringBasis, string> ULT_DIA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "2", "X(002)."), 12);
                    /*"    03  AC-LIDOS                  PIC  9(006) VALUE  0.*/

                    public _REDEF_VG1473B_TAB_DIAS_R()
                    {
                        ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-REGISTROS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_REGISTROS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-INCLUIDOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_INCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-ALTERADOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_ALTERADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-EXCLUIDOS              PIC  9(006) VALUE  0.*/
            public IntBasis AC_EXCLUIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03  AC-REATIVADOS             PIC  9(006) VALUE  0.*/
            public IntBasis AC_REATIVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"01  HEADER-RECORD.*/
        }
        public VG1473B_HEADER_RECORD HEADER_RECORD { get; set; } = new VG1473B_HEADER_RECORD();
        public class VG1473B_HEADER_RECORD : VarBasis
        {
            /*"    05  HEA-COD-CLIENTE           PIC  9(003).*/
            public IntBasis HEA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  HEA-COD-PRODUTO           PIC  9(002).*/
            public IntBasis HEA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  HEA-DATA-CRIACAO          PIC  X(008).*/
            public StringBasis HEA_DATA_CRIACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05  HEA-NUM-ARQ-ATU           PIC  9(005).*/
            public IntBasis HEA_NUM_ARQ_ATU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"01  DETAIL-RECORD.*/
        }
        public VG1473B_DETAIL_RECORD DETAIL_RECORD { get; set; } = new VG1473B_DETAIL_RECORD();
        public class VG1473B_DETAIL_RECORD : VarBasis
        {
            /*"    05  DET-APOLICE               PIC  X(040).*/
            public StringBasis DET_APOLICE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-ITEM                  PIC  X(005).*/
            public StringBasis DET_ITEM { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"    05  DET-CARTAO                PIC  X(030).*/
            public StringBasis DET_CARTAO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  DET-IDPLANOUSS            PIC  9(010).*/
            public IntBasis DET_IDPLANOUSS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05  DET-TIPO-MOV              PIC  X(001).*/
            public StringBasis DET_TIPO_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  DET-DTINIVIG              PIC  9(008).*/
            public IntBasis DET_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  DET-DTTERVIG              PIC  9(008).*/
            public IntBasis DET_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  DET-NOME-RAZAO            PIC  X(040).*/
            public StringBasis DET_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-CPFCNPJ               PIC  9(014).*/
            public IntBasis DET_CPFCNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  DET-ENDERECO              PIC  X(060).*/
            public StringBasis DET_ENDERECO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"    05  DET-NUMERO                PIC  9(006).*/
            public IntBasis DET_NUMERO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  DET-COMPL                 PIC  X(040).*/
            public StringBasis DET_COMPL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-CIDADE                PIC  X(060).*/
            public StringBasis DET_CIDADE { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"    05  DET-BAIRRO                PIC  X(040).*/
            public StringBasis DET_BAIRRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05  DET-CEP                   PIC  9(008).*/
            public IntBasis DET_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  DET-PAIS                  PIC  X(020).*/
            public StringBasis DET_PAIS { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  DET-DDI                   PIC  9(003).*/
            public IntBasis DET_DDI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  DET-DDD                   PIC  9(003).*/
            public IntBasis DET_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05  DET-TELEFONE              PIC  9(010).*/
            public IntBasis DET_TELEFONE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05  DET-SEXO                  PIC  9(001).*/
            public IntBasis DET_SEXO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  DET-DTNASC                PIC  9(008).*/
            public IntBasis DET_DTNASC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  DET-RG                    PIC  X(020).*/
            public StringBasis DET_RG { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05  DET-ESTCIVIL              PIC  9(001).*/
            public IntBasis DET_ESTCIVIL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05  DET-PROFISSAO             PIC  X(060).*/
            public StringBasis DET_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"01  TRAILLER-RECORD.*/
        }
        public VG1473B_TRAILLER_RECORD TRAILLER_RECORD { get; set; } = new VG1473B_TRAILLER_RECORD();
        public class VG1473B_TRAILLER_RECORD : VarBasis
        {
            /*"    05  TRA-TOT-REGISTROS         PIC  9(005).*/
            public IntBasis TRA_TOT_REGISTROS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  FILLER                    PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05  TRA-ID-INCLUSOES          PIC  X(001) VALUE 'I'.*/
            public StringBasis TRA_ID_INCLUSOES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
            /*"    05  TRA-TOT-INCLUSOES         PIC  9(005).*/
            public IntBasis TRA_TOT_INCLUSOES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  TRA-ID-ALTERACOES         PIC  X(001) VALUE 'A'.*/
            public StringBasis TRA_ID_ALTERACOES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"A");
            /*"    05  TRA-TOT-ALTERACOES        PIC  9(005).*/
            public IntBasis TRA_TOT_ALTERACOES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  TRA-ID-EXCLUSOES          PIC  X(001) VALUE 'E'.*/
            public StringBasis TRA_ID_EXCLUSOES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"E");
            /*"    05  TRA-TOT-EXCLUSOES         PIC  9(005).*/
            public IntBasis TRA_TOT_EXCLUSOES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05  TRA-ID-REATIVACOES        PIC  X(001) VALUE 'R'.*/
            public StringBasis TRA_ID_REATIVACOES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"R");
            /*"    05  TRA-TOT-REATIVACOES       PIC  9(005).*/
            public IntBasis TRA_TOT_REATIVACOES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"01  WABEND.*/
        }
        public VG1473B_WABEND WABEND { get; set; } = new VG1473B_WABEND();
        public class VG1473B_WABEND : VarBasis
        {
            /*"      10  FILLER                  PIC  X(010) VALUE         'VG1473B  '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG1473B  ");
            /*"      10  FILLER                  PIC  X(028) VALUE         ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10  FILLER                  PIC  X(014) VALUE         '    SQLCODE = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10  WSQLCODE                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD1 = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10  WSQLERRD1               PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10  WSQLERRD2               PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10  FILLER                  PIC  X(014)   VALUE         '   SQLERRD2 = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10  LOCALIZA-ABEND-1.*/
            public VG1473B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG1473B_LOCALIZA_ABEND_1();
            public class VG1473B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15  FILLER                  PIC  X(012)   VALUE           'PARAGRAFO = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15  PARAGRAFO               PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10  LOCALIZA-ABEND-2.*/
            }
            public VG1473B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG1473B_LOCALIZA_ABEND_2();
            public class VG1473B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15  FILLER                  PIC  X(012)   VALUE           'COMANDO   = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15  COMANDO                 PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  WVERSAO.*/
            }
        }
        public VG1473B_WVERSAO WVERSAO { get; set; } = new VG1473B_WVERSAO();
        public class VG1473B_WVERSAO : VarBasis
        {
            /*"      10  WS-VERSAO               PIC  X(006) VALUE ' V.02 '.*/
            public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" V.02 ");
            /*"      10  WS-CADMUS               PIC  X(006) VALUE '28.693'.*/
            public StringBasis WS_CADMUS { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"28.693");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.MOVIMEA MOVIMEA { get; set; } = new Dclgens.MOVIMEA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.UNIDAFED UNIDAFED { get; set; } = new Dclgens.UNIDAFED();
        public Dclgens.PAISES PAISES { get; set; } = new Dclgens.PAISES();
        public VG1473B_CPROPVA CPROPVA { get; set; } = new VG1473B_CPROPVA();
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
            /*" -310- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -314- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -319- DISPLAY 'VG1473B - VERSAO' WS-VERSAO 'CADMUS ' WS-CADMUS. */

            $"VG1473B - VERSAO{WVERSAO.WS_VERSAO}CADMUS {WVERSAO.WS_CADMUS}"
            .Display();

            /*" -321- OPEN OUTPUT REPSAF. */
            REPSAF.Open(REPSAF_RECORD);

            /*" -322- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -324- MOVE 'SELECT SISTEMAS' TO COMANDO. */
            _.Move("SELECT SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -332- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -335- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -336- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -338- END-IF. */
            }


            /*" -339- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -341- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -343- DISPLAY 'DTMOVABE ....... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DTMOVABE ....... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -344- MOVE SISTEMAS-DTCURREN TO W01DTSQL. */
            _.Move(SISTEMAS_DTCURREN, WS_WORK_AREAS.W01DTSQL);

            /*" -345- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -346- MOVE W01DTSQL TO SISTEMAS-DTCURINI. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURINI);

            /*" -347- MOVE ULT-DIA(W01MMSQL) TO W01DDSQL. */
            _.Move(WS_WORK_AREAS.TABELA_ULT_DIAS.TAB_DIAS_R.ULT_DIA[WS_WORK_AREAS.W01DTSQL.W01MMSQL], WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -349- MOVE W01DTSQL TO SISTEMAS-DTCURREN. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMAS_DTCURREN);

            /*" -350- DISPLAY 'DTCURINI ....... ' SISTEMAS-DTCURINI. */
            _.Display($"DTCURINI ....... {SISTEMAS_DTCURINI}");

            /*" -352- DISPLAY 'DTCURREN ....... ' SISTEMAS-DTCURREN. */
            _.Display($"DTCURREN ....... {SISTEMAS_DTCURREN}");

            /*" -353- MOVE SISTEMAS-DATA-MOV-ABERTO TO W01DTSQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_WORK_AREAS.W01DTSQL);

            /*" -354- MOVE W01DDSQL TO W01DDINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTINV.W01DDINV);

            /*" -355- MOVE W01MMSQL TO W01MMINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTINV.W01MMINV);

            /*" -356- MOVE W01AASQL TO W01AAINV. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTINV.W01AAINV);

            /*" -358- MOVE W01DTINV TO HEA-DATA-CRIACAO. */
            _.Move(WS_WORK_AREAS.W01DTINV, HEADER_RECORD.HEA_DATA_CRIACAO);

            /*" -359- MOVE 009 TO HEA-COD-CLIENTE. */
            _.Move(009, HEADER_RECORD.HEA_COD_CLIENTE);

            /*" -366- MOVE 001 TO HEA-COD-PRODUTO. */
            _.Move(001, HEADER_RECORD.HEA_COD_PRODUTO);

            /*" -367- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -368- DISPLAY 'SELECT GE-AR-DETALHE' */
                _.Display($"SELECT GE-AR-DETALHE");

                /*" -370- END-IF */
            }


            /*" -371- MOVE 'SELECT GE-AR-DETALHE' TO COMANDO. */
            _.Move("SELECT GE-AR-DETALHE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -373- MOVE 'VGCONUSS' TO GEARDETA-NOM-ARQUIVO. */
            _.Move("VGCONUSS", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -378- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -381- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -382- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -384- END-IF */
            }


            /*" -387- IF SQLCODE EQUAL ZEROES OR SQLCODE EQUAL -811 */

            if (DB.SQLCODE == 00 || DB.SQLCODE == -811)
            {

                /*" -388- MOVE 'SELECT MAX SEQ-GERACAO' TO COMANDO */
                _.Move("SELECT MAX SEQ-GERACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -389- IF WS-DISPLAY-G */

                if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                {

                    /*" -390- DISPLAY 'SELECT MAX SEQ-GERACAO' */
                    _.Display($"SELECT MAX SEQ-GERACAO");

                    /*" -391- END-IF */
                }


                /*" -396- PERFORM M_0000_PRINCIPAL_DB_SELECT_3 */

                M_0000_PRINCIPAL_DB_SELECT_3();

                /*" -398- IF WS-DISPLAY-G */

                if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                {

                    /*" -399- DISPLAY 'SQLCODE:' SQLCODE */
                    _.Display($"SQLCODE:{DB.SQLCODE}");

                    /*" -401- END-IF */
                }


                /*" -402- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -403- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -406- END-IF */
                }


                /*" -407- MOVE 'SELECT GERACAO' TO COMANDO */
                _.Move("SELECT GERACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -408- IF WS-DISPLAY-G */

                if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                {

                    /*" -409- DISPLAY 'SELECT GERACAO' */
                    _.Display($"SELECT GERACAO");

                    /*" -410- END-IF */
                }


                /*" -418- PERFORM M_0000_PRINCIPAL_DB_SELECT_4 */

                M_0000_PRINCIPAL_DB_SELECT_4();

                /*" -420- IF WS-DISPLAY-G */

                if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                {

                    /*" -421- DISPLAY 'SQLCODE:' SQLCODE */
                    _.Display($"SQLCODE:{DB.SQLCODE}");

                    /*" -422- END-IF */
                }


                /*" -423- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -424- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -425- END-IF */
                }


                /*" -426- ADD 1 TO GEARDETA-SEQ-GERACAO */
                GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO + 1;

                /*" -427- ELSE */
            }
            else
            {


                /*" -429- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -430- MOVE 0 TO GEARDETA-SEQ-GERACAO */
                    _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);

                    /*" -431- ELSE */
                }
                else
                {


                    /*" -432- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -433- END-IF */
                }


                /*" -435- END-IF. */
            }


            /*" -440- MOVE GEARDETA-SEQ-GERACAO TO HEA-NUM-ARQ-ATU. */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, HEADER_RECORD.HEA_NUM_ARQ_ATU);

            /*" -441- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -442- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -443- DISPLAY 'DECLARE CPROPVA' */
                _.Display($"DECLARE CPROPVA");

                /*" -447- END-IF */
            }


            /*" -469- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -472- DISPLAY '*** VG1473B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VG1473B *** ABRINDO CURSOR ...");

            /*" -473- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -473- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -477- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -478- DISPLAY '*** VG1473B *** PROCESSANDO ...' . */
            _.Display($"*** VG1473B *** PROCESSANDO ...");

            /*" -481- PERFORM M-0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -485- IF AC-INCLUIDOS EQUAL ZEROS AND AC-ALTERADOS EQUAL ZEROS AND AC-EXCLUIDOS EQUAL ZEROS AND AC-REATIVADOS EQUAL ZEROS */

            if (WS_WORK_AREAS.AC_INCLUIDOS == 00 && WS_WORK_AREAS.AC_ALTERADOS == 00 && WS_WORK_AREAS.AC_EXCLUIDOS == 00 && WS_WORK_AREAS.AC_REATIVADOS == 00)
            {

                /*" -488- GO TO 0000-TERMINA. */

                M_0000_TERMINA(); //GOTO
                return;
            }


            /*" -491- MOVE AC-REGISTROS TO GEARDETA-QTD-REG-PROCESSADO GEARDETA-QTD-REG-ACEITOS TRA-TOT-REGISTROS. */
            _.Move(WS_WORK_AREAS.AC_REGISTROS, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS, TRAILLER_RECORD.TRA_TOT_REGISTROS);

            /*" -492- MOVE ZEROS TO GEARDETA-QTD-REG-REJEITADOS. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS);

            /*" -493- MOVE AC-INCLUIDOS TO TRA-TOT-INCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_INCLUIDOS, TRAILLER_RECORD.TRA_TOT_INCLUSOES);

            /*" -494- MOVE AC-ALTERADOS TO TRA-TOT-ALTERACOES. */
            _.Move(WS_WORK_AREAS.AC_ALTERADOS, TRAILLER_RECORD.TRA_TOT_ALTERACOES);

            /*" -495- MOVE AC-EXCLUIDOS TO TRA-TOT-EXCLUSOES. */
            _.Move(WS_WORK_AREAS.AC_EXCLUIDOS, TRAILLER_RECORD.TRA_TOT_EXCLUSOES);

            /*" -497- MOVE AC-REATIVADOS TO TRA-TOT-REATIVACOES. */
            _.Move(WS_WORK_AREAS.AC_REATIVADOS, TRAILLER_RECORD.TRA_TOT_REATIVACOES);

            /*" -498- MOVE W01AASQL TO GEARDETA-DTH-ANO-REFERENCIA. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA);

            /*" -499- MOVE W01MMSQL TO GEARDETA-DTH-MES-REFERENCIA. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA);

            /*" -500- MOVE 'E' TO GEARDETA-IND-MEIO-ENVIO. */
            _.Move("E", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO);

            /*" -501- MOVE 'E' TO GEARDETA-STA-ENVIO-RECEPCAO. */
            _.Move("E", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO);

            /*" -503- MOVE 'TXT' TO GEARDETA-COD-TIPO-ARQUIVO. */
            _.Move("TXT", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO);

            /*" -504- MOVE 'INSERT GE_AR_DETALHE' TO COMANDO. */
            _.Move("INSERT GE_AR_DETALHE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -505- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -506- DISPLAY 'INSERT GE_AR_DETALHE' */
                _.Display($"INSERT GE_AR_DETALHE");

                /*" -510- END-IF */
            }


            /*" -549- PERFORM M_0000_PRINCIPAL_DB_INSERT_1 */

            M_0000_PRINCIPAL_DB_INSERT_1();

            /*" -551- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -552- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -554- END-IF */
            }


            /*" -555- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -557- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -557- WRITE REPSAF-RECORD FROM TRAILLER-RECORD. */
            _.Move(TRAILLER_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -332- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DTCURREN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' WITH UR END-EXEC. */

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
            /*" -563- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -565- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -565- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -378- EXEC SQL SELECT SEQ_GERACAO INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -575- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -579- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -580- MOVE 'SELECT MOVIMENTO_EA MAX' TO COMANDO. */
            _.Move("SELECT MOVIMENTO_EA MAX", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -581- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -582- DISPLAY 'SELECT MOVIMENTO_EA MAX' */
                _.Display($"SELECT MOVIMENTO_EA MAX");

                /*" -584- END-IF */
            }


            /*" -590- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -592- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -593- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -594- DISPLAY 'MOVIMEA-NSAS: ' MOVIMEA-NSAS */
                _.Display($"MOVIMEA-NSAS: {MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS}");

                /*" -596- END-IF. */
            }


            /*" -597- IF MOVIMEA-NSAS GREATER 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS > 0)
            {

                /*" -598- MOVE 'SELECT MOVIMENTO_EA.TIPO_MOVIMENTO' TO COMANDO */
                _.Move("SELECT MOVIMENTO_EA.TIPO_MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -599- IF WS-DISPLAY-G */

                if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                {

                    /*" -600- DISPLAY 'SELECT MOVIMENTO_EA.TIPO_MOVIMENTO' */
                    _.Display($"SELECT MOVIMENTO_EA.TIPO_MOVIMENTO");

                    /*" -601- END-IF */
                }


                /*" -608- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

                /*" -610- IF WS-DISPLAY-G */

                if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                {

                    /*" -611- DISPLAY 'SQLCODE:' SQLCODE */
                    _.Display($"SQLCODE:{DB.SQLCODE}");

                    /*" -612- DISPLAY 'TIPO MOVIMENTO:' MOVIMEA-TIPO-MOVIMENTO */
                    _.Display($"TIPO MOVIMENTO:{MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO}");

                    /*" -613- END-IF */
                }


                /*" -614- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -617- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -618- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -619- DISPLAY 'ANALISA A OPCAOPAG E A ULTIMA PARCELA PAGADA' */
                _.Display($"ANALISA A OPCAOPAG E A ULTIMA PARCELA PAGADA");

                /*" -620- DISPLAY 'PRODUVG-OPCAO-PAGAMENTO:' PRODUVG-OPCAO-PAGAMENTO */
                _.Display($"PRODUVG-OPCAO-PAGAMENTO:{PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO}");

                /*" -621- END-IF */
            }


            /*" -623- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '4' NEXT SENTENCE */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO == "4")
            {

                /*" -624- ELSE */
            }
            else
            {


                /*" -625- IF PRODUVG-OPCAO-PAGAMENTO EQUAL '5' OR '3' */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO.In("5", "3"))
                {

                    /*" -626- MOVE 'SELECT PARCELAS_VIDAZUL' TO COMANDO */
                    _.Move("SELECT PARCELAS_VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -627- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                    /*" -637- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

                    M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

                    /*" -639- IF WS-DISPLAY-G */

                    if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
                    {

                        /*" -640- DISPLAY 'SQLCODE:' SQLCODE */
                        _.Display($"SQLCODE:{DB.SQLCODE}");

                        /*" -641- END-IF */
                    }


                    /*" -642- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -643- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -645- IF PROPOVA-SIT-REGISTRO EQUAL '2' NEXT SENTENCE */

                            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                            {

                                /*" -646- ELSE */
                            }
                            else
                            {


                                /*" -647- GO TO 0100-NEXT */

                                M_0100_NEXT(); //GOTO
                                return;

                                /*" -648- ELSE */
                            }

                        }
                        else
                        {


                            /*" -650- IF SQLCODE EQUAL -811 NEXT SENTENCE */

                            if (DB.SQLCODE == -811)
                            {

                                /*" -651- ELSE */
                            }
                            else
                            {


                                /*" -653- DISPLAY 'ERRO NA LEITURA DA PARCELAS_VIDAZUL ' PROPOVA-NUM-CERTIFICADO */
                                _.Display($"ERRO NA LEITURA DA PARCELAS_VIDAZUL {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                                /*" -656- GO TO 9999-ERRO. */

                                M_9999_ERRO(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -657- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -658- DISPLAY 'ANALISA A SITUACAO DO MOVIMENTO' */
                _.Display($"ANALISA A SITUACAO DO MOVIMENTO");

                /*" -659- DISPLAY 'PROPOVA-SIT-REGISTRO:' PROPOVA-SIT-REGISTRO */
                _.Display($"PROPOVA-SIT-REGISTRO:{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}");

                /*" -660- DISPLAY 'MOVIMEA-TIPO-MOVIMENTO:' MOVIMEA-TIPO-MOVIMENTO */
                _.Display($"MOVIMEA-TIPO-MOVIMENTO:{MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO}");

                /*" -661- END-IF */
            }


            /*" -662- IF MOVIMEA-NSAS EQUAL 0 */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS == 0)
            {

                /*" -664- IF PROPOVA-SIT-REGISTRO EQUAL '2' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                {

                    /*" -665- GO TO 0100-NEXT */

                    M_0100_NEXT(); //GOTO
                    return;

                    /*" -666- ELSE */
                }
                else
                {


                    /*" -667- MOVE 'I' TO MOVIMEA-TIPO-MOVIMENTO */
                    _.Move("I", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                    /*" -668- END-IF */
                }


                /*" -669- ELSE */
            }
            else
            {


                /*" -670- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

                if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
                {

                    /*" -673- IF PROPOVA-SIT-REGISTRO EQUAL '0' OR '1' */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("0", "1"))
                    {

                        /*" -674- GO TO 0100-NEXT */

                        M_0100_NEXT(); //GOTO
                        return;

                        /*" -675- ELSE */
                    }
                    else
                    {


                        /*" -676- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO */
                        _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                        /*" -677- END-IF */
                    }


                    /*" -678- ELSE */
                }
                else
                {


                    /*" -679- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

                    if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
                    {

                        /*" -681- IF PROPOVA-SIT-REGISTRO EQUAL '2' */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO == "2")
                        {

                            /*" -682- GO TO 0100-NEXT */

                            M_0100_NEXT(); //GOTO
                            return;

                            /*" -683- ELSE */
                        }
                        else
                        {


                            /*" -684- MOVE 'R' TO MOVIMEA-TIPO-MOVIMENTO */
                            _.Move("R", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                            /*" -685- END-IF */
                        }


                        /*" -686- ELSE */
                    }
                    else
                    {


                        /*" -687- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'R' */

                        if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "R")
                        {

                            /*" -690- IF PROPOVA-SIT-REGISTRO EQUAL '0' OR '1' */

                            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("0", "1"))
                            {

                                /*" -691- GO TO 0100-NEXT */

                                M_0100_NEXT(); //GOTO
                                return;

                                /*" -692- ELSE */
                            }
                            else
                            {


                                /*" -693- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO */
                                _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);

                                /*" -694- END-IF */
                            }


                            /*" -695- ELSE */
                        }
                        else
                        {


                            /*" -698- IF PROPOVA-SIT-REGISTRO EQUAL '0' OR '1' */

                            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("0", "1"))
                            {

                                /*" -699- GO TO 0100-NEXT */

                                M_0100_NEXT(); //GOTO
                                return;

                                /*" -700- ELSE */
                            }
                            else
                            {


                                /*" -703- MOVE 'E' TO MOVIMEA-TIPO-MOVIMENTO. */
                                _.Move("E", MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
                            }

                        }

                    }

                }

            }


            /*" -704- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'I' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "I")
            {

                /*" -705- MOVE 'IN' TO DET-TIPO-MOV */
                _.Move("IN", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -707- ADD 1 TO AC-INCLUIDOS. */
                WS_WORK_AREAS.AC_INCLUIDOS.Value = WS_WORK_AREAS.AC_INCLUIDOS + 1;
            }


            /*" -708- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'A' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "A")
            {

                /*" -709- MOVE 'AL' TO DET-TIPO-MOV */
                _.Move("AL", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -711- ADD 1 TO AC-ALTERADOS. */
                WS_WORK_AREAS.AC_ALTERADOS.Value = WS_WORK_AREAS.AC_ALTERADOS + 1;
            }


            /*" -712- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'E' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "E")
            {

                /*" -713- MOVE 'EX' TO DET-TIPO-MOV */
                _.Move("EX", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -715- ADD 1 TO AC-EXCLUIDOS. */
                WS_WORK_AREAS.AC_EXCLUIDOS.Value = WS_WORK_AREAS.AC_EXCLUIDOS + 1;
            }


            /*" -716- IF MOVIMEA-TIPO-MOVIMENTO EQUAL 'R' */

            if (MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO == "R")
            {

                /*" -717- MOVE 'RE' TO DET-TIPO-MOV */
                _.Move("RE", DETAIL_RECORD.DET_TIPO_MOV);

                /*" -721- ADD 1 TO AC-REATIVADOS. */
                WS_WORK_AREAS.AC_REATIVADOS.Value = WS_WORK_AREAS.AC_REATIVADOS + 1;
            }


            /*" -723- MOVE 'SELECT PROPOSTAS_VA' TO COMANDO. */
            _.Move("SELECT PROPOSTAS_VA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -724- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -732- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -735- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -737- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -739- MOVE 'SELECT GE-DOC-CLIENTE' TO COMANDO. */
            _.Move("SELECT GE-DOC-CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -740- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -757- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -758- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -770- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -773- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -775- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -776- IF CLIENT-DTNASC-I LESS ZEROES */

            if (CLIENT_DTNASC_I < 00)
            {

                /*" -777- MOVE 'SELECT SEGURADOS_VGAP' TO COMANDO */
                _.Move("SELECT SEGURADOS_VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -784- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_6 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_6();

                /*" -787- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -788- GO TO 9999-ERRO */

                    M_9999_ERRO(); //GOTO
                    return;

                    /*" -790- END-IF */
                }


                /*" -791- IF CLIENT-DTNASC-I LESS ZEROES */

                if (CLIENT_DTNASC_I < 00)
                {

                    /*" -793- DISPLAY 'DATA DE NASCIMENTO INVALIDA NAS TABELAS ' PROPOVA-COD-CLIENTE */
                    _.Display($"DATA DE NASCIMENTO INVALIDA NAS TABELAS {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                    /*" -810- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -812- MOVE 'SELECT ENDERECOS' TO COMANDO. */
            _.Move("SELECT ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -834- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_7 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_7();

            /*" -842- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -843- DISPLAY 'CLIENTE: ' PROPOVA-COD-CLIENTE */
                _.Display($"CLIENTE: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -844- DISPLAY 'OCORR-ENDERECO: ' SEGURVGA-OCORR-ENDERECO */
                _.Display($"OCORR-ENDERECO: {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO}");

                /*" -846- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -848- MOVE 'SELECT UNIDADE_FEDERACAO' TO COMANDO. */
            _.Move("SELECT UNIDADE_FEDERACAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -856- IF ENDERECO-SIGLA-UF NOT EQUAL 'AC' AND 'AL' AND 'AM' AND 'AP' AND 'BA' AND 'CE' AND 'DF' AND 'ES' AND 'GO' AND 'MA' AND 'MG' AND 'MS' AND 'MT' AND 'PA' AND 'PB' AND 'PE' AND 'PI' AND 'PR' AND 'RJ' AND 'RN' AND 'RO' AND 'RR' AND 'RS' AND 'SC' AND 'SE' AND 'SP' AND 'TO' */

            if (!ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.In("AC", "AL", "AM", "AP", "BA", "CE", "DF", "ES", "GO", "MA", "MG", "MS", "MT", "PA", "PB", "PE", "PI", "PR", "RJ", "RN", "RO", "RR", "RS", "SC", "SE", "SP", "TO"))
            {

                /*" -857- MOVE 'DF' TO ENDERECO-SIGLA-UF */
                _.Move("DF", ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

                /*" -859- END-IF. */
            }


            /*" -865- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_8 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_8();

            /*" -868- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -870- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -885- MOVE 'SELECT PAISES' TO COMANDO. */
            _.Move("SELECT PAISES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -886- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETAIL_RECORD.DET_NOME_RAZAO);

            /*" -887- MOVE ENDERECO-ENDERECO TO DET-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETAIL_RECORD.DET_ENDERECO);

            /*" -888- MOVE ZEROS TO DET-NUMERO. */
            _.Move(0, DETAIL_RECORD.DET_NUMERO);

            /*" -889- MOVE ENDERECO-DES-COMPLEMENTO TO DET-COMPL. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO, DETAIL_RECORD.DET_COMPL);

            /*" -890- MOVE ENDERECO-BAIRRO TO DET-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETAIL_RECORD.DET_BAIRRO);

            /*" -892- MOVE ENDERECO-CIDADE TO DET-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETAIL_RECORD.DET_CIDADE);

            /*" -894- MOVE ENDERECO-CEP TO DET-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETAIL_RECORD.DET_CEP);

            /*" -896- MOVE 'BRASIL' TO DET-PAIS. */
            _.Move("BRASIL", DETAIL_RECORD.DET_PAIS);

            /*" -897- MOVE ZEROS TO DET-TELEFONE. */
            _.Move(0, DETAIL_RECORD.DET_TELEFONE);

            /*" -898- MOVE ZEROS TO DET-DDI. */
            _.Move(0, DETAIL_RECORD.DET_DDI);

            /*" -899- MOVE ENDERECO-DDD TO DET-DDD. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, DETAIL_RECORD.DET_DDD);

            /*" -900- MOVE CLIENTES-CGCCPF TO DET-CPFCNPJ. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETAIL_RECORD.DET_CPFCNPJ);

            /*" -901- MOVE CLIENTES-DATA-NASCIMENTO TO W01DTSQL. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, WS_WORK_AREAS.W01DTSQL);

            /*" -902- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -903- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -904- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -905- MOVE W01DTCOR TO DET-DTNASC. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTNASC);

            /*" -906- MOVE PROPOVA-DATA-QUITACAO TO W01DTSQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WS_WORK_AREAS.W01DTSQL);

            /*" -907- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -908- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -909- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -910- MOVE W01DTCOR TO DET-DTINIVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTINIVIG);

            /*" -911- MOVE PROPVA-DTQIT10A TO W01DTSQL. */
            _.Move(PROPVA_DTQIT10A, WS_WORK_AREAS.W01DTSQL);

            /*" -912- MOVE W01DDSQL TO W01DDCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01DDSQL, WS_WORK_AREAS.W01DTCOR.W01DDCOR);

            /*" -913- MOVE W01MMSQL TO W01MMCOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_WORK_AREAS.W01DTCOR.W01MMCOR);

            /*" -914- MOVE W01AASQL TO W01AACOR. */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_WORK_AREAS.W01DTCOR.W01AACOR);

            /*" -915- MOVE W01DTCOR TO DET-DTTERVIG. */
            _.Move(WS_WORK_AREAS.W01DTCOR, DETAIL_RECORD.DET_DTTERVIG);

            /*" -916- MOVE PROPOVA-NUM-APOLICE TO DET-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, DETAIL_RECORD.DET_APOLICE);

            /*" -917- MOVE SEGURVGA-NUM-ITEM TO WNUM-ITEM-NUM-9. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, WNUM_ITEM_NUM_9);

            /*" -918- MOVE WNUM-ITEM-NUM-9 TO WNUM-ITEM-NUM-5. */
            _.Move(WNUM_ITEM_NUM_9, WNUM_ITEM.WNUM_ITEM_NUM_5);

            /*" -919- MOVE WNUM-ITEM-ALF-5 TO DET-ITEM. */
            _.Move(WNUM_ITEM.WNUM_ITEM_ALF_5, DETAIL_RECORD.DET_ITEM);

            /*" -920- MOVE PROPOVA-NUM-CERTIFICADO TO DET-CARTAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, DETAIL_RECORD.DET_CARTAO);

            /*" -922- MOVE 01 TO DET-IDPLANOUSS. */
            _.Move(01, DETAIL_RECORD.DET_IDPLANOUSS);

            /*" -923- MOVE ZEROS TO DET-RG. */
            _.Move(0, DETAIL_RECORD.DET_RG);

            /*" -924- IF PROPOVA-IDE-SEXO = 'M' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO == "M")
            {

                /*" -925- MOVE 1 TO DET-SEXO */
                _.Move(1, DETAIL_RECORD.DET_SEXO);

                /*" -926- ELSE */
            }
            else
            {


                /*" -927- IF PROPOVA-IDE-SEXO = 'F' */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO == "F")
                {

                    /*" -928- MOVE 2 TO DET-SEXO */
                    _.Move(2, DETAIL_RECORD.DET_SEXO);

                    /*" -929- ELSE */
                }
                else
                {


                    /*" -930- MOVE 0 TO DET-SEXO */
                    _.Move(0, DETAIL_RECORD.DET_SEXO);

                    /*" -931- END-IF */
                }


                /*" -933- END-IF. */
            }


            /*" -934- EVALUATE PROPOVA-ESTADO-CIVIL */
            switch (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL.Value.Trim())
            {

                /*" -935- WHEN 'C' */
                case "C":

                    /*" -936- MOVE 1 TO DET-ESTCIVIL */
                    _.Move(1, DETAIL_RECORD.DET_ESTCIVIL);

                    /*" -937- WHEN 'S' */
                    break;
                case "S":

                    /*" -938- MOVE 2 TO DET-ESTCIVIL */
                    _.Move(2, DETAIL_RECORD.DET_ESTCIVIL);

                    /*" -939- WHEN 'D' */
                    break;
                case "D":

                    /*" -940- MOVE 3 TO DET-ESTCIVIL */
                    _.Move(3, DETAIL_RECORD.DET_ESTCIVIL);

                    /*" -941- WHEN 'V' */
                    break;
                case "V":

                    /*" -942- MOVE 4 TO DET-ESTCIVIL */
                    _.Move(4, DETAIL_RECORD.DET_ESTCIVIL);

                    /*" -943- WHEN OTHER */
                    break;
                default:

                    /*" -944- MOVE 5 TO DET-ESTCIVIL */
                    _.Move(5, DETAIL_RECORD.DET_ESTCIVIL);

                    /*" -946- END-EVALUATE. */
                    break;
            }


            /*" -954- MOVE PROPOVA-PROFISSAO TO DET-PROFISSAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO, DETAIL_RECORD.DET_PROFISSAO);

            /*" -955- IF WS-FLAG EQUAL ZEROES */

            if (WS_WORK_AREAS.WS_FLAG == 00)
            {

                /*" -956- MOVE 1 TO WS-FLAG */
                _.Move(1, WS_WORK_AREAS.WS_FLAG);

                /*" -958- WRITE REPSAF-RECORD FROM HEADER-RECORD. */
                _.Move(HEADER_RECORD.GetMoveValues(), REPSAF_RECORD);

                REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());
            }


            /*" -959- WRITE REPSAF-RECORD FROM DETAIL-RECORD. */
            _.Move(DETAIL_RECORD.GetMoveValues(), REPSAF_RECORD);

            REPSAF.Write(REPSAF_RECORD.GetMoveValues().ToString());

            /*" -959- ADD 1 TO AC-REGISTROS. */
            WS_WORK_AREAS.AC_REGISTROS.Value = WS_WORK_AREAS.AC_REGISTROS + 1;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -590- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :MOVIMEA-NSAS FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_USUARIO = 'VG1473B' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_NSAS, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -469- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT NUM_CERTIFICADO, NUM_APOLICE, COD_SUBGRUPO, COD_CLIENTE, DATA_INIVIGENCIA, DATA_INIVIGENCIA + 10 YEARS, SIT_REGISTRO, 'SS' , '4' , NUM_ITEM, ESTADO_CIVIL, IDE_SEXO, OCORR_ENDERECO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE IN ( 109300000709 ,3009300000709 ) AND TIPO_SEGURADO = '1' ORDER BY 6,1 WITH UR END-EXEC. */
            CPROPVA = new VG1473B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_CLIENTE
							, 
							DATA_INIVIGENCIA
							, 
							DATA_INIVIGENCIA + 10 YEARS
							, 
							SIT_REGISTRO
							, 
							'SS'
							, 
							'4'
							, 
							NUM_ITEM
							, 
							ESTADO_CIVIL
							, 
							IDE_SEXO
							, 
							OCORR_ENDERECO 
							FROM SEGUROS.SEGURADOS_VGAP 
							WHERE 
							NUM_APOLICE IN ( 109300000709 
							,3009300000709 ) 
							AND TIPO_SEGURADO = '1' 
							ORDER BY 6
							,1";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -608- EXEC SQL SELECT TIPO_MOVIMENTO INTO :MOVIMEA-TIPO-MOVIMENTO FROM SEGUROS.MOVIMENTO_EA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NSAS = :MOVIMEA-NSAS AND COD_USUARIO = 'VG1473B' END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                MOVIMEA_NSAS = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_NSAS.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMEA_TIPO_MOVIMENTO, MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -473- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -637- EXEC SQL SELECT NUM_PARCELA INTO :PARCEVID-NUM-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND SIT_REGISTRO = '1' AND DATA_VENCIMENTO >= :SISTEMAS-DTCURINI AND DATA_VENCIMENTO <= :SISTEMAS-DTCURREN WITH UR END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                SISTEMAS_DTCURINI = SISTEMAS_DTCURINI.ToString(),
                SISTEMAS_DTCURREN = SISTEMAS_DTCURREN.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-INSERT-1 */
        public void M_0000_PRINCIPAL_DB_INSERT_1()
        {
            /*" -549- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO , SEQ_GERACAO , DTH_ANO_REFERENCIA , DTH_MES_REFERENCIA , DTH_MOVIMENTO , DTH_GERACAO , DTH_RECEPCAO , IND_MEIO_ENVIO , STA_ENVIO_RECEPCAO , COD_TIPO_ARQUIVO , QTD_REG_PROCESSADO , QTD_REG_REJEITADOS , QTD_REG_ACEITOS , DTH_TIMESTAMP , NOM_DATASET , QTD_REG_INF , IND_OPERACAO , COD_ULT_REGISTRO ) VALUES (:GEARDETA-NOM-ARQUIVO , :GEARDETA-SEQ-GERACAO , :GEARDETA-DTH-ANO-REFERENCIA, :GEARDETA-DTH-MES-REFERENCIA, CURRENT_DATE , CURRENT_DATE , CURRENT_DATE , :GEARDETA-IND-MEIO-ENVIO , :GEARDETA-STA-ENVIO-RECEPCAO, :GEARDETA-COD-TIPO-ARQUIVO , :GEARDETA-QTD-REG-PROCESSADO, :GEARDETA-QTD-REG-REJEITADOS, :GEARDETA-QTD-REG-ACEITOS , CURRENT_TIMESTAMP , NULL , 0 , NULL , NULL) END-EXEC. */

            var m_0000_PRINCIPAL_DB_INSERT_1_Insert1 = new M_0000_PRINCIPAL_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                GEARDETA_DTH_ANO_REFERENCIA = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA.ToString(),
                GEARDETA_DTH_MES_REFERENCIA = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA.ToString(),
                GEARDETA_IND_MEIO_ENVIO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO.ToString(),
                GEARDETA_STA_ENVIO_RECEPCAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO.ToString(),
                GEARDETA_COD_TIPO_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO.ToString(),
                GEARDETA_QTD_REG_PROCESSADO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.ToString(),
                GEARDETA_QTD_REG_REJEITADOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS.ToString(),
                GEARDETA_QTD_REG_ACEITOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS.ToString(),
            };

            M_0000_PRINCIPAL_DB_INSERT_1_Insert1.Execute(m_0000_PRINCIPAL_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -732- EXEC SQL SELECT PROFISSAO INTO :PROPOVA-PROFISSAO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_PROFISSAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_PROFISSAO);
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -396- EXEC SQL SELECT VALUE(MAX(SEQ_GERACAO),0) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO END-EXEC */

            var m_0000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_PRINCIPAL_DB_SELECT_3_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -770- EXEC SQL SELECT CGCCPF, NOME_RAZAO, DATA_NASCIMENTO INTO :CLIENTES-CGCCPF, :CLIENTES-NOME-RAZAO, :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

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

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -964- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -966- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-6 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_6()
        {
            /*" -784- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENTES-DATA-NASCIMENTO:CLIENT-DTNASC-I FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC */

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
        /*" M-0000-PRINCIPAL-DB-SELECT-4 */
        public void M_0000_PRINCIPAL_DB_SELECT_4()
        {
            /*" -418- EXEC SQL SELECT DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA INTO :GEARDETA-DTH-ANO-REFERENCIA, :GEARDETA-DTH-MES-REFERENCIA FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO END-EXEC */

            var m_0000_PRINCIPAL_DB_SELECT_4_Query1 = new M_0000_PRINCIPAL_DB_SELECT_4_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_4_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_DTH_ANO_REFERENCIA, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA);
                _.Move(executed_1.GEARDETA_DTH_MES_REFERENCIA, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-7 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_7()
        {
            /*" -834- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, TELEFONE, DES_COMPLEMENTO, DDD INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-TELEFONE, :ENDERECO-DES-COMPLEMENTO:ENDERECO-DES-COMPLEMENTO-I, :ENDERECO-DDD FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE AND OCORR_ENDERECO = :SEGURVGA-OCORR-ENDERECO WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_7_Query1()
            {
                SEGURVGA_OCORR_ENDERECO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO.ToString(),
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
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
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO_I, ENDERECO_DES_COMPLEMENTO_I);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-8 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_8()
        {
            /*" -865- EXEC SQL SELECT COD_PAIS INTO :UNIDAFED-COD-PAIS FROM SEGUROS.UNIDADE_FEDERACAO WHERE SIGLA_UF = :ENDERECO-SIGLA-UF WITH UR END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1()
            {
                ENDERECO_SIGLA_UF = ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.UNIDAFED_COD_PAIS, UNIDAFED.DCLUNIDADE_FEDERACAO.UNIDAFED_COD_PAIS);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -977- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -978- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -979- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -980- DISPLAY 'FETCH CPROPVA' */
                _.Display($"FETCH CPROPVA");

                /*" -982- END-IF */
            }


            /*" -984- MOVE ZEROS TO PRODVG-ICODPRODEA. */
            _.Move(0, PRODVG_ICODPRODEA);

            /*" -999- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -1001- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -1002- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -1004- END-IF */
            }


            /*" -1005- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1006- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1007- MOVE 1 TO WS-EOF */
                    _.Move(1, WS_WORK_AREAS.WS_EOF);

                    /*" -1008- MOVE 'CLOSE CPROPVA' TO COMANDO */
                    _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1008- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                    M_0110_FETCH_DB_CLOSE_1();

                    /*" -1010- GO TO 0110-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/ //GOTO
                    return;

                    /*" -1011- ELSE */
                }
                else
                {


                    /*" -1013- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1014- MOVE 'SELECT SUBGRUPOS ' TO COMANDO. */
            _.Move("SELECT SUBGRUPOS ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1015- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -1016- DISPLAY 'SELECT SUBGRUPOS ' */
                _.Display($"SELECT SUBGRUPOS ");

                /*" -1018- END-IF */
            }


            /*" -1019- MOVE PROPOVA-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1021- MOVE ZEROS TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(0, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -1028- PERFORM M_0110_FETCH_DB_SELECT_1 */

            M_0110_FETCH_DB_SELECT_1();

            /*" -1030- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -1031- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -1033- END-IF. */
            }


            /*" -1034- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1036- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1037- IF SUBGVGAP-SIT-REGISTRO EQUAL '2' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_SIT_REGISTRO == "2")
            {

                /*" -1037- MOVE '2' TO PROPOVA-SIT-REGISTRO. */
                _.Move("2", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -999- EXEC SQL FETCH CPROPVA INTO :PROPOVA-NUM-CERTIFICADO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-CLIENTE, :PROPOVA-DATA-QUITACAO, :PROPVA-DTQIT10A, :PROPOVA-SIT-REGISTRO, :PRODUVG-COD-PRODUTO-EA:PRODVG-ICODPRODEA, :PRODUVG-OPCAO-PAGAMENTO, :SEGURVGA-NUM-ITEM, :PROPOVA-ESTADO-CIVIL, :PROPOVA-IDE-SEXO, :SEGURVGA-OCORR-ENDERECO END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CPROPVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CPROPVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CPROPVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CPROPVA.PROPVA_DTQIT10A, PROPVA_DTQIT10A);
                _.Move(CPROPVA.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CPROPVA.PRODUVG_COD_PRODUTO_EA, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO_EA);
                _.Move(CPROPVA.PRODVG_ICODPRODEA, PRODVG_ICODPRODEA);
                _.Move(CPROPVA.PRODUVG_OPCAO_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_OPCAO_PAGAMENTO);
                _.Move(CPROPVA.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(CPROPVA.PROPOVA_ESTADO_CIVIL, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_ESTADO_CIVIL);
                _.Move(CPROPVA.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
                _.Move(CPROPVA.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -1008- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-SELECT-1 */
        public void M_0110_FETCH_DB_SELECT_1()
        {
            /*" -1028- EXEC SQL SELECT SIT_REGISTRO INTO :SUBGVGAP-SIT-REGISTRO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var m_0110_FETCH_DB_SELECT_1_Query1 = new M_0110_FETCH_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_0110_FETCH_DB_SELECT_1_Query1.Execute(m_0110_FETCH_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_SIT_REGISTRO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0200-INSERT-REPSAF */
        private void M_0200_INSERT_REPSAF(bool isPerform = false)
        {
            /*" -1048- MOVE '0200-INSERT-REPSAF' TO PARAGRAFO. */
            _.Move("0200-INSERT-REPSAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1050- MOVE 'INSERT MOVIMENTO_EA' TO COMANDO. */
            _.Move("INSERT MOVIMENTO_EA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1057- PERFORM M_0200_INSERT_REPSAF_DB_INSERT_1 */

            M_0200_INSERT_REPSAF_DB_INSERT_1();

            /*" -1059- IF WS-DISPLAY-G */

            if (WS_DISPLAY_GERAL["WS_DISPLAY_G"])
            {

                /*" -1060- DISPLAY 'SQLCODE:' SQLCODE */
                _.Display($"SQLCODE:{DB.SQLCODE}");

                /*" -1062- END-IF */
            }


            /*" -1063- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1063- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0200-INSERT-REPSAF-DB-INSERT-1 */
        public void M_0200_INSERT_REPSAF_DB_INSERT_1()
        {
            /*" -1057- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_EA VALUES (:PROPOVA-NUM-CERTIFICADO, :GEARDETA-SEQ-GERACAO, :MOVIMEA-TIPO-MOVIMENTO, 'VG1473B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 = new M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                MOVIMEA_TIPO_MOVIMENTO = MOVIMEA.DCLMOVIMENTO_EA.MOVIMEA_TIPO_MOVIMENTO.ToString(),
            };

            M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1.Execute(m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -1076- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -1077- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1078- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1078- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1081- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1082- DISPLAY 'LIDOS ..................... ' AC-LIDOS. */
            _.Display($"LIDOS ..................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1083- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1084- DISPLAY 'INCLUIDOS ................. ' AC-INCLUIDOS. */
            _.Display($"INCLUIDOS ................. {WS_WORK_AREAS.AC_INCLUIDOS}");

            /*" -1085- DISPLAY 'ALTERADOS ................. ' AC-ALTERADOS. */
            _.Display($"ALTERADOS ................. {WS_WORK_AREAS.AC_ALTERADOS}");

            /*" -1086- DISPLAY 'EXCLUIDOS ................. ' AC-EXCLUIDOS. */
            _.Display($"EXCLUIDOS ................. {WS_WORK_AREAS.AC_EXCLUIDOS}");

            /*" -1087- DISPLAY 'REATIVADOS ................ ' AC-REATIVADOS. */
            _.Display($"REATIVADOS ................ {WS_WORK_AREAS.AC_REATIVADOS}");

            /*" -1088- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1088- DISPLAY '*** VG1473B *** TERMINO NORMAL' . */
            _.Display($"*** VG1473B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1100- CLOSE REPSAF. */
            REPSAF.Close();

            /*" -1101- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1102- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1103- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1104- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -1106- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1108- DISPLAY '*** VG1473B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VG1473B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1108- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1111- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1112- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1112- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1115- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1116- DISPLAY 'LIDOS ......................... ' AC-LIDOS. */
            _.Display($"LIDOS ......................... {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1117- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1118- DISPLAY 'CERTIFICADO...  ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"CERTIFICADO...  {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -1119- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1121- DISPLAY '*** VG1473B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VG1473B *** ERRO DE EXECUCAO");

            /*" -1122- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1122- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}