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
using Sias.Outros.DB2.FC0038B;

namespace Code
{
    public class FC0038B
    {
        public bool IsCall { get; set; }

        public FC0038B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  FC0038B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CARLOS AURELIO DE BRITO            *      */
        /*"      *   PROGRAMADOR ............  CARLOS AURELIO DE BRITO E          *      */
        /*"      *                             SILVIO (LONTRA SILVESTRE)          *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/2002                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  EMITE CORRESPONDENCIAS GERANDO     *      */
        /*"      *                             CONTROLE DE FAC PARA DUPLEX.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *                                                                *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * FAIXA_CEP                           V0FAIXA_CEP       INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 05/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERADO POR CARLOS AURELIO EM 19/01/1999 PARA IDENTIFICAR O   *      */
        /*"      * TIPO DE MALA DIRETA PELA VARIAVEL WPRODUTO.                    *      */
        /*"      * QUANDO : 3100 - AZULCAR COBRANCA                               *      */
        /*"      *          3101 - AZULCAR RENOVACAO                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NOVAS FAIXAS DE CEP AMARRADO ECT - PRODEXTER(VANDO-18/11/2002) *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA { get; set; } = new FileBasis(new PIC("X", "80", "X(80)"));

        public FileBasis ENTRADA
        {
            get
            {
                _.Move(REG_ENTRADA, _ENTRADA); VarBasis.RedefinePassValue(REG_ENTRADA, _ENTRADA, REG_ENTRADA); return _ENTRADA;
            }
        }
        public FileBasis _ARQCARTA { get; set; } = new FileBasis(new PIC("X", "3500", "X(3500)"));

        public FileBasis ARQCARTA
        {
            get
            {
                _.Move(REG_ARQCARTA, _ARQCARTA); VarBasis.RedefinePassValue(REG_ARQCARTA, _ARQCARTA, REG_ARQCARTA); return _ARQCARTA;
            }
        }
        public FileBasis _RFC0038B1 { get; set; } = new FileBasis(new PIC("X", "3482", "X(3482)"));

        public FileBasis RFC0038B1
        {
            get
            {
                _.Move(RES_FC0038B1, _RFC0038B1); VarBasis.RedefinePassValue(RES_FC0038B1, _RFC0038B1, RES_FC0038B1); return _RFC0038B1;
            }
        }
        public FileBasis _RFC0038B2 { get; set; } = new FileBasis(new PIC("X", "3482", "X(3482)"));

        public FileBasis RFC0038B2
        {
            get
            {
                _.Move(RES_FC0038B2, _RFC0038B2); VarBasis.RedefinePassValue(RES_FC0038B2, _RFC0038B2, RES_FC0038B2); return _RFC0038B2;
            }
        }
        public FileBasis _CEPERROS { get; set; } = new FileBasis(new PIC("X", "3500", "X(3500)"));

        public FileBasis CEPERROS
        {
            get
            {
                _.Move(REG_CEPERROS, _CEPERROS); VarBasis.RedefinePassValue(REG_CEPERROS, _CEPERROS, REG_CEPERROS); return _CEPERROS;
            }
        }
        /*"01             REG-ENTRADA.*/
        public FC0038B_REG_ENTRADA REG_ENTRADA { get; set; } = new FC0038B_REG_ENTRADA();
        public class FC0038B_REG_ENTRADA : VarBasis
        {
            /*"    05         REG-QTDIAS                 PIC  9(002).*/
            public IntBasis REG_QTDIAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05         FILLER                     PIC  X(078).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "78", "X(078)."), @"");
            /*"01             REG-ARQCARTA.*/
        }
        public FC0038B_REG_ARQCARTA REG_ARQCARTA { get; set; } = new FC0038B_REG_ARQCARTA();
        public class FC0038B_REG_ARQCARTA : VarBasis
        {
            /*"    05         REG-NUMCEP                 PIC  9(008).*/
            public IntBasis REG_NUMCEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05         REG-CONTADOR               PIC  9(006).*/
            public IntBasis REG_CONTADOR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05         REG-LINHANR                PIC  9(003).*/
            public IntBasis REG_LINHANR { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05         REG-BRANCO                 PIC  X(001).*/
            public StringBasis REG_BRANCO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05         REG-LINHA.*/
            public FC0038B_REG_LINHA REG_LINHA { get; set; } = new FC0038B_REG_LINHA();
            public class FC0038B_REG_LINHA : VarBasis
            {
                /*"       07      REG-LINHA-PARTE1           PIC  X(0003).*/
                public StringBasis REG_LINHA_PARTE1 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)."), @"");
                /*"       07      REG-LIN-CONTRATO           PIC  X(0012).*/
                public StringBasis REG_LIN_CONTRATO { get; set; } = new StringBasis(new PIC("X", "12", "X(0012)."), @"");
                /*"       07      REG-INICIO-VERSO           PIC  X(0004).*/
                public StringBasis REG_INICIO_VERSO { get; set; } = new StringBasis(new PIC("X", "4", "X(0004)."), @"");
                /*"       07      REG-INICIO-VERSO-R REDEFINES REG-INICIO-VERSO                                          PIC  9(0004).*/
                private _REDEF_IntBasis _reg_inicio_verso_r { get; set; }
                public _REDEF_IntBasis REG_INICIO_VERSO_R
                {
                    get { _reg_inicio_verso_r = new _REDEF_IntBasis(new PIC("9", "0004", "9(0004).")); ; _.Move(REG_INICIO_VERSO, _reg_inicio_verso_r); VarBasis.RedefinePassValue(REG_INICIO_VERSO, _reg_inicio_verso_r, REG_INICIO_VERSO); _reg_inicio_verso_r.ValueChanged += () => { _.Move(_reg_inicio_verso_r, REG_INICIO_VERSO); }; return _reg_inicio_verso_r; }
                    set { VarBasis.RedefinePassValue(value, _reg_inicio_verso_r, REG_INICIO_VERSO); }
                }  //Redefines
                /*"       07      FILLER                     PIC  X(0001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
                /*"       07      REG-NOM-EMPRESA            PIC  X(0040).*/
                public StringBasis REG_NOM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"       07      REG-END-EMPRESA            PIC  X(0040).*/
                public StringBasis REG_END_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"       07      REG-TIP-PRODUTO            PIC  X(0040).*/
                public StringBasis REG_TIP_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(0040)."), @"");
                /*"       07      REG-LINHA-PARTE3           PIC  X(3342).*/
                public StringBasis REG_LINHA_PARTE3 { get; set; } = new StringBasis(new PIC("X", "3342", "X(3342)."), @"");
                /*"01             RES-FC0038B1               PIC  X(3482).*/
            }
        }
        public StringBasis RES_FC0038B1 { get; set; } = new StringBasis(new PIC("X", "3482", "X(3482)."), @"");
        /*"01             RES-FC0038B2               PIC  X(3482).*/
        public StringBasis RES_FC0038B2 { get; set; } = new StringBasis(new PIC("X", "3482", "X(3482)."), @"");
        /*"01             REG-CEPERROS               PIC  X(3500).*/
        public StringBasis REG_CEPERROS { get; set; } = new StringBasis(new PIC("X", "3500", "X(3500)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-DTMOVABE              PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V0SIST-DTMOVABE             PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0SIST-MESREFER             PIC S9(004)      COMP.*/
        public IntBasis V0SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0SIST-ANOREFER             PIC S9(004)      COMP.*/
        public IntBasis V0SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0FCEP-FAIXA                PIC S9(004)      COMP.*/
        public IntBasis V0FCEP_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0FCEP-DTINIVIG             PIC  X(010).*/
        public StringBasis V0FCEP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0FCEP-DTTERVIG             PIC  X(010).*/
        public StringBasis V0FCEP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0FCEP-CEPINI               PIC S9(009)      COMP.*/
        public IntBasis V0FCEP_CEPINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0FCEP-CEPFIM               PIC S9(009)      COMP.*/
        public IntBasis V0FCEP_CEPFIM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0FCEP-DESC-FAIXA           PIC  X(072).*/
        public StringBasis V0FCEP_DESC_FAIXA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77  V0FCEP-CENTRALIZADOR        PIC  X(072).*/
        public StringBasis V0FCEP_CENTRALIZADOR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
        /*"77  V0RELA-CODUSU               PIC X(8).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0RELA-DATA-SOLICITACAO     PIC X(10).*/
        public StringBasis V0RELA_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-IDSISTEM             PIC X(2).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"77  V0RELA-CODRELAT             PIC X(8).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0RELA-NRCOPIAS             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-NRCOPIAS               PIC S9(04) COMP    VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), -1);
        /*"77  V0RELA-QUANTIDADE           PIC S9(04) COMP.*/
        public IntBasis V0RELA_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-PERI-INICIAL         PIC X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-PERI-FINAL           PIC X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-DATA-REFERENCIA      PIC X(10).*/
        public StringBasis V0RELA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-MES-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-ANO-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-ORGAO                PIC S9(04) COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-MODALIDA             PIC S9(04) COMP.*/
        public IntBasis V0RELA_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CONGENER             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NRCERTIF             PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0RELA-NRTIT                PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-CODSUBES             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-COD-PLANO            PIC S9(04) COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-OCORHIST             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-APOLIDER             PIC X(15).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-ENDOSLID             PIC X(15).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-NUM-PARC-LIDER       PIC S9(04) COMP.*/
        public IntBasis V0RELA_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NUM-SINISTRO         PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis V0RELA_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-NUM-ORDEM            PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0RELA-CODUNIMO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CORRECAO             PIC X(1).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-SITUACAO             PIC X(1).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-PREVIA-DEFINITIVA    PIC X(1).*/
        public StringBasis V0RELA_PREVIA_DEFINITIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-ANAL-RESUMO          PIC X(1).*/
        public StringBasis V0RELA_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-PERI-RENOVACAO       PIC S9(04) COMP.*/
        public IntBasis V0RELA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-PCT-AUMENTO          PIC S9(3)V9(2) COMP-3.*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"77  V0RELA-TIMESTAMP            PIC X(26).*/
        public StringBasis V0RELA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  WS-COUNT                      PIC  9(002) COMP VALUE ZEROS.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"77  WHOST-PROXIMA-DATA            PIC  X(010)      VALUE SPACES.*/
        public StringBasis WHOST_PROXIMA_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01           WLINHA-AUX01.*/
        public FC0038B_WLINHA_AUX01 WLINHA_AUX01 { get; set; } = new FC0038B_WLINHA_AUX01();
        public class FC0038B_WLINHA_AUX01 : VarBasis
        {
            /*"   05        WLINHA-AUX-01        PIC  X(001) OCCURS 3482 TIMES.*/
            public ListBasis<StringBasis, string> WLINHA_AUX_01 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 3482);
            /*"01           WLINHA-AUX02.*/
        }
        public FC0038B_WLINHA_AUX02 WLINHA_AUX02 { get; set; } = new FC0038B_WLINHA_AUX02();
        public class FC0038B_WLINHA_AUX02 : VarBasis
        {
            /*"   05        WLINHA-AUX-02        PIC  X(001) OCCURS 3482 TIMES.*/
            public ListBasis<StringBasis, string> WLINHA_AUX_02 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 3482);
            /*"01           AREA-DE-WORK.*/
        }
        public FC0038B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new FC0038B_AREA_DE_WORK();
        public class FC0038B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WS-DTREFER.*/
            public FC0038B_WS_DTREFER WS_DTREFER { get; set; } = new FC0038B_WS_DTREFER();
            public class FC0038B_WS_DTREFER : VarBasis
            {
                /*"    10       WS-ANOREFER          PIC  9(004).*/
                public IntBasis WS_ANOREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER               PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-MESREFER          PIC  9(002).*/
                public IntBasis WS_MESREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER               PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIAREFER          PIC  9(002).*/
                public IntBasis WS_DIAREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-DTPROC.*/
            }
            public FC0038B_WDATA_DTPROC WDATA_DTPROC { get; set; } = new FC0038B_WDATA_DTPROC();
            public class FC0038B_WDATA_DTPROC : VarBasis
            {
                /*"     07      WDATA-ANOPROC.*/
                public FC0038B_WDATA_ANOPROC WDATA_ANOPROC { get; set; } = new FC0038B_WDATA_ANOPROC();
                public class FC0038B_WDATA_ANOPROC : VarBasis
                {
                    /*"       09    WDATA-ANOPROC4       PIC  9(001).*/
                    public IntBasis WDATA_ANOPROC4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       09    WDATA-ANOPROC3       PIC  9(001).*/
                    public IntBasis WDATA_ANOPROC3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       09    WDATA-ANOPROC2       PIC  9(001).*/
                    public IntBasis WDATA_ANOPROC2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       09    WDATA-ANOPROC1       PIC  9(001).*/
                    public IntBasis WDATA_ANOPROC1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"     07      FILLER               PIC  X(001).*/
                }
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WDATA-MESPROC.*/
                public FC0038B_WDATA_MESPROC WDATA_MESPROC { get; set; } = new FC0038B_WDATA_MESPROC();
                public class FC0038B_WDATA_MESPROC : VarBasis
                {
                    /*"       09    WDATA-MESPROC2       PIC  9(001).*/
                    public IntBasis WDATA_MESPROC2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       09    WDATA-MESPROC1       PIC  9(001).*/
                    public IntBasis WDATA_MESPROC1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"     07      FILLER               PIC  X(001).*/
                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WDATA-DIAPROC.*/
                public FC0038B_WDATA_DIAPROC WDATA_DIAPROC { get; set; } = new FC0038B_WDATA_DIAPROC();
                public class FC0038B_WDATA_DIAPROC : VarBasis
                {
                    /*"       09    WDATA-DIAPROC2       PIC  9(001).*/
                    public IntBasis WDATA_DIAPROC2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       09    WDATA-DIAPROC1       PIC  9(001).*/
                    public IntBasis WDATA_DIAPROC1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"  05         WNUM-OBJETO          PIC S9(005) COMP-3 VALUE +1.*/
                }
            }
            public IntBasis WNUM_OBJETO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
            /*"  05         WNUM-OBJETO-E        PIC    999.999.*/
            public IntBasis WNUM_OBJETO_E { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"  05         WNUM-OBJETO-ER REDEFINES WNUM-OBJETO-E.*/
            private _REDEF_FC0038B_WNUM_OBJETO_ER _wnum_objeto_er { get; set; }
            public _REDEF_FC0038B_WNUM_OBJETO_ER WNUM_OBJETO_ER
            {
                get { _wnum_objeto_er = new _REDEF_FC0038B_WNUM_OBJETO_ER(); _.Move(WNUM_OBJETO_E, _wnum_objeto_er); VarBasis.RedefinePassValue(WNUM_OBJETO_E, _wnum_objeto_er, WNUM_OBJETO_E); _wnum_objeto_er.ValueChanged += () => { _.Move(_wnum_objeto_er, WNUM_OBJETO_E); }; return _wnum_objeto_er; }
                set { VarBasis.RedefinePassValue(value, _wnum_objeto_er, WNUM_OBJETO_E); }
            }  //Redefines
            public class _REDEF_FC0038B_WNUM_OBJETO_ER : VarBasis
            {
                /*"     07      WNUM-OBJETO-01       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WNUM-OBJETO-02       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WNUM-OBJETO-03       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WNUM-OBJETO-04       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WNUM-OBJETO-05       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WNUM-OBJETO-06       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WNUM-OBJETO-07       PIC  X(001).*/
                public StringBasis WNUM_OBJETO_07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         WNUM-AMARRADO        PIC S9(005) COMP-3 VALUE +1.*/

                public _REDEF_FC0038B_WNUM_OBJETO_ER()
                {
                    WNUM_OBJETO_01.ValueChanged += OnValueChanged;
                    WNUM_OBJETO_02.ValueChanged += OnValueChanged;
                    WNUM_OBJETO_03.ValueChanged += OnValueChanged;
                    WNUM_OBJETO_04.ValueChanged += OnValueChanged;
                    WNUM_OBJETO_05.ValueChanged += OnValueChanged;
                    WNUM_OBJETO_06.ValueChanged += OnValueChanged;
                    WNUM_OBJETO_07.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_AMARRADO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
            /*"  05         WCEP-NUMANT          PIC  9(008)        VALUE ZEROS*/
            public IntBasis WCEP_NUMANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WANT-REGISTRO        PIC  9(006)        VALUE ZEROS*/
            public IntBasis WANT_REGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-EOF               PIC  X(001)  VALUE 'N'.*/
            public StringBasis WS_EOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05         WOK                  PIC  X(001)  VALUE 'S'.*/
            public StringBasis WOK { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05         IND                  PIC  9(004)  VALUE ZEROS.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         IND2                 PIC  9(004)  VALUE ZEROS.*/
            public IntBasis IND2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         IND3                 PIC  9(004)  VALUE ZEROS.*/
            public IntBasis IND3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         IND4                 PIC  9(004)  VALUE ZEROS.*/
            public IntBasis IND4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         IND5                 PIC  9(004)  VALUE ZEROS.*/
            public IntBasis IND5 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AUX1                 PIC  9(004)  VALUE ZEROS.*/
            public IntBasis AUX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WCEPERRO             PIC  9(008)  VALUE ZEROS.*/
            public IntBasis WCEPERRO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WCODIGO              PIC  9(004)  VALUE ZEROS.*/
            public IntBasis WCODIGO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WCONTRATO            PIC  X(015)  VALUE SPACES.*/
            public StringBasis WCONTRATO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  05         WEMPRESA             PIC  X(040)  VALUE SPACES.*/
            public StringBasis WEMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05         WENDEMPR             PIC  X(040)  VALUE SPACES.*/
            public StringBasis WENDEMPR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05         WTIPPROD             PIC  X(040)  VALUE SPACES.*/
            public StringBasis WTIPPROD { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05         WREG-INICIO-VERSO    PIC  9(004)  VALUE ZEROS.*/
            public IntBasis WREG_INICIO_VERSO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WD01-LINHA.*/
            public FC0038B_WD01_LINHA WD01_LINHA { get; set; } = new FC0038B_WD01_LINHA();
            public class FC0038B_WD01_LINHA : VarBasis
            {
                /*"    10       WD01-LITERAL         PIC  X(015)  VALUE  SPACES.*/
                public StringBasis WD01_LITERAL { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10       WD01-OBJETOS         PIC  ZZZZZ9.*/
                public IntBasis WD01_OBJETOS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"  05         WLINHA01.*/
            }
            public FC0038B_WLINHA01 WLINHA01 { get; set; } = new FC0038B_WLINHA01();
            public class FC0038B_WLINHA01 : VarBasis
            {
                /*"     07      WLINHA011            PIC  X(0018) VALUE SPACES.*/
                public StringBasis WLINHA011 { get; set; } = new StringBasis(new PIC("X", "18", "X(0018)"), @"");
                /*"     07      WLINHA012.*/
                public FC0038B_WLINHA012 WLINHA012 { get; set; } = new FC0038B_WLINHA012();
                public class FC0038B_WLINHA012 : VarBasis
                {
                    /*"       09    WLINHA0121           PIC  X(0003) VALUE SPACES.*/
                    public StringBasis WLINHA0121 { get; set; } = new StringBasis(new PIC("X", "3", "X(0003)"), @"");
                    /*"       09    WLINHA0122           PIC  X(4000) VALUE SPACES.*/
                    public StringBasis WLINHA0122 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                    /*"  05         WLINHA02.*/
                }
            }
            public FC0038B_WLINHA02 WLINHA02 { get; set; } = new FC0038B_WLINHA02();
            public class FC0038B_WLINHA02 : VarBasis
            {
                /*"     07      WLINHA021            PIC  X(0018) VALUE SPACES.*/
                public StringBasis WLINHA021 { get; set; } = new StringBasis(new PIC("X", "18", "X(0018)"), @"");
                /*"     07      WLINHA022            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA022 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA03.*/
            }
            public FC0038B_WLINHA03 WLINHA03 { get; set; } = new FC0038B_WLINHA03();
            public class FC0038B_WLINHA03 : VarBasis
            {
                /*"     07      WLINHA031            PIC  X(0018) VALUE SPACES.*/
                public StringBasis WLINHA031 { get; set; } = new StringBasis(new PIC("X", "18", "X(0018)"), @"");
                /*"     07      WLINHA032            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA032 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA04.*/
            }
            public FC0038B_WLINHA04 WLINHA04 { get; set; } = new FC0038B_WLINHA04();
            public class FC0038B_WLINHA04 : VarBasis
            {
                /*"     07      WLINHA041            PIC  X(0018) VALUE SPACES.*/
                public StringBasis WLINHA041 { get; set; } = new StringBasis(new PIC("X", "18", "X(0018)"), @"");
                /*"     07      WLINHA042            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA042 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA05.*/
            }
            public FC0038B_WLINHA05 WLINHA05 { get; set; } = new FC0038B_WLINHA05();
            public class FC0038B_WLINHA05 : VarBasis
            {
                /*"     07      WLINHA051            PIC  X(0005) VALUE '%%EOF'.*/
                public StringBasis WLINHA051 { get; set; } = new StringBasis(new PIC("X", "5", "X(0005)"), @"%%EOF");
                /*"     07      WLINHA052            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA052 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA06.*/
            }
            public FC0038B_WLINHA06 WLINHA06 { get; set; } = new FC0038B_WLINHA06();
            public class FC0038B_WLINHA06 : VarBasis
            {
                /*"     07      WLINHA061            PIC  X(0002) VALUE '%!'.*/
                public StringBasis WLINHA061 { get; set; } = new StringBasis(new PIC("X", "2", "X(0002)"), @"%!");
                /*"     07      WLINHA062            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA062 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA07.*/
            }
            public FC0038B_WLINHA07 WLINHA07 { get; set; } = new FC0038B_WLINHA07();
            public class FC0038B_WLINHA07 : VarBasis
            {
                /*"     07      WLINHA071            PIC  X(0012) VALUE                                  '(|) SETDBSEP'.*/
                public StringBasis WLINHA071 { get; set; } = new StringBasis(new PIC("X", "12", "X(0012)"), @"(|) SETDBSEP");
                /*"     07      WLINHA072            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA072 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA08.*/
            }
            public FC0038B_WLINHA08 WLINHA08 { get; set; } = new FC0038B_WLINHA08();
            public class FC0038B_WLINHA08 : VarBasis
            {
                /*"     07      WLINHA081            PIC  X(0020) VALUE                                  '(co04.dbm) STARTDBM'.*/
                public StringBasis WLINHA081 { get; set; } = new StringBasis(new PIC("X", "20", "X(0020)"), @"(co04.dbm) STARTDBM");
                /*"     07      WLINHA082            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA082 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA09.*/
            }
            public FC0038B_WLINHA09 WLINHA09 { get; set; } = new FC0038B_WLINHA09();
            public class FC0038B_WLINHA09 : VarBasis
            {
                /*"     07      WLINHA091            PIC  X(0043) VALUE            'LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA'.*/
                public StringBasis WLINHA091 { get; set; } = new StringBasis(new PIC("X", "43", "X(0043)"), @"LOCALIDADE|FAIXA|OBJETOS|AMARRADO|SEQUENCIA");
                /*"     07      WLINHA092            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA092 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA12.*/
            }
            public FC0038B_WLINHA12 WLINHA12 { get; set; } = new FC0038B_WLINHA12();
            public class FC0038B_WLINHA12 : VarBasis
            {
                /*"     07      WLINHA121            PIC  X(0018) VALUE                                  '(co05.jdt) STARTLM'.*/
                public StringBasis WLINHA121 { get; set; } = new StringBasis(new PIC("X", "18", "X(0018)"), @"(co05.jdt) STARTLM");
                /*"     07      WLINHA122            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA122 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA13.*/
            }
            public FC0038B_WLINHA13 WLINHA13 { get; set; } = new FC0038B_WLINHA13();
            public class FC0038B_WLINHA13 : VarBasis
            {
                /*"     07      WLINHA131            PIC  X(0102) VALUE            'NUMRELATMES|FOLHAPAG|PRODUTO|DATAREL|CEPINI|CEPFIM|O            'BJINI|OBJFIM|AMRINI|AMRFIM|QTDOBJ|QTDAMR|DESCRICAO'*/
                public StringBasis WLINHA131 { get; set; } = new StringBasis(new PIC("X", "102", "X(0102)"), @"NUMRELATMES|FOLHAPAG|PRODUTO|DATAREL|CEPINI|CEPFIM|O            ");
                /*"     07      WLINHA132            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA132 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA15.*/
            }
            public FC0038B_WLINHA15 WLINHA15 { get; set; } = new FC0038B_WLINHA15();
            public class FC0038B_WLINHA15 : VarBasis
            {
                /*"     07      WLINHA151            PIC  X(0005) VALUE '%%EOF'.*/
                public StringBasis WLINHA151 { get; set; } = new StringBasis(new PIC("X", "5", "X(0005)"), @"%%EOF");
                /*"     07      WLINHA152            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA152 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA15.*/
            }
            public FC0038B_WLINHA15_0 WLINHA15_0 { get; set; } = new FC0038B_WLINHA15_0();
            public class FC0038B_WLINHA15_0 : VarBasis
            {
                /*"     07      WLINHA151            PIC  X(0005) VALUE '%%EOF'.*/
                public StringBasis WLINHA151_0 { get; set; } = new StringBasis(new PIC("X", "5", "X(0005)"), @"%%EOF");
                /*"     07      WLINHA152            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA152_0 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA16.*/
            }
            public FC0038B_WLINHA16 WLINHA16 { get; set; } = new FC0038B_WLINHA16();
            public class FC0038B_WLINHA16 : VarBasis
            {
                /*"     07      WLINHA161            PIC  X(0024) VALUE                                 '%XRXrequeriments: duplex'.*/
                public StringBasis WLINHA161 { get; set; } = new StringBasis(new PIC("X", "24", "X(0024)"), @"%XRXrequeriments: duplex");
                /*"     07      WLINHA162            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA162 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA17.*/
            }
            public FC0038B_WLINHA17 WLINHA17 { get; set; } = new FC0038B_WLINHA17();
            public class FC0038B_WLINHA17 : VarBasis
            {
                /*"     07      WLINHA171            PIC  X(0028) VALUE                                 '%%BeginFeature: *Duplex True'.*/
                public StringBasis WLINHA171 { get; set; } = new StringBasis(new PIC("X", "28", "X(0028)"), @"%%BeginFeature: *Duplex True");
                /*"     07      WLINHA172            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA172 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA18.*/
            }
            public FC0038B_WLINHA18 WLINHA18 { get; set; } = new FC0038B_WLINHA18();
            public class FC0038B_WLINHA18 : VarBasis
            {
                /*"     07      WLINHA181            PIC  X(0030) VALUE                                '<</Duplex true>> setpagedevice'*/
                public StringBasis WLINHA181 { get; set; } = new StringBasis(new PIC("X", "30", "X(0030)"), @"<</Duplex true>> setpagedevice");
                /*"     07      WLINHA182            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA182 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA19.*/
            }
            public FC0038B_WLINHA19 WLINHA19 { get; set; } = new FC0038B_WLINHA19();
            public class FC0038B_WLINHA19 : VarBasis
            {
                /*"     07      WLINHA191            PIC  X(0012) VALUE                                  '%%EndFeature'.*/
                public StringBasis WLINHA191 { get; set; } = new StringBasis(new PIC("X", "12", "X(0012)"), @"%%EndFeature");
                /*"     07      WLINHA192            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA192 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA20.*/
            }
            public FC0038B_WLINHA20 WLINHA20 { get; set; } = new FC0038B_WLINHA20();
            public class FC0038B_WLINHA20 : VarBasis
            {
                /*"     07      WLINHA201            PIC  X(0047) VALUE               '%%DocumentMedia: papel1 595 842 75 white normal'*/
                public StringBasis WLINHA201 { get; set; } = new StringBasis(new PIC("X", "47", "X(0047)"), @"%%DocumentMedia: papel1 595 842 75 white normal");
                /*"     07      WLINHA202            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA202 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA21.*/
            }
            public FC0038B_WLINHA21 WLINHA21 { get; set; } = new FC0038B_WLINHA21();
            public class FC0038B_WLINHA21 : VarBasis
            {
                /*"     07      WLINHA211            PIC  X(0030) VALUE                                '%%+papel2 595 842 75 blue azul'*/
                public StringBasis WLINHA211 { get; set; } = new StringBasis(new PIC("X", "30", "X(0030)"), @"%%+papel2 595 842 75 blue azul");
                /*"     07      WLINHA212            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA212 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WLINHA22.*/
            }
            public FC0038B_WLINHA22 WLINHA22 { get; set; } = new FC0038B_WLINHA22();
            public class FC0038B_WLINHA22 : VarBasis
            {
                /*"     07      WLINHA221            PIC  X(0068) VALUE            '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)            '>> setpagedevice'.*/
                public StringBasis WLINHA221 { get; set; } = new StringBasis(new PIC("X", "68", "X(0068)"), @"<</MediaColor (blue) /MediaWeight 75/MediaType(azul)            ");
                /*"     07      WLINHA222            PIC  X(4000) VALUE SPACES.*/
                public StringBasis WLINHA222 { get; set; } = new StringBasis(new PIC("X", "4000", "X(4000)"), @"");
                /*"  05         WCONTLIN             PIC  9(002)  VALUE ZEROS.*/
            }
            public IntBasis WCONTLIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WDATA-SISTEMA.*/
            public FC0038B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new FC0038B_WDATA_SISTEMA();
            public class FC0038B_WDATA_SISTEMA : VarBasis
            {
                /*"     07      WDATA-ANOSIS         PIC  9(04).*/
                public IntBasis WDATA_ANOSIS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     07      WDATA-MESSIS         PIC  9(02).*/
                public IntBasis WDATA_MESSIS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     07      WDATA-DIASIS         PIC  9(02).*/
                public IntBasis WDATA_DIASIS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05         W-DATA.*/
            }
            public FC0038B_W_DATA W_DATA { get; set; } = new FC0038B_W_DATA();
            public class FC0038B_W_DATA : VarBasis
            {
                /*"     07      W-DD                 PIC  9(02).*/
                public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     07      W-MM                 PIC  9(02).*/
                public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     07      W-AA                 PIC  9(04).*/
                public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  05         PROSOMW099.*/
            }
            public FC0038B_PROSOMW099 PROSOMW099 { get; set; } = new FC0038B_PROSOMW099();
            public class FC0038B_PROSOMW099 : VarBasis
            {
                /*"     07      W-DATA01             PIC  9(08).*/
                public IntBasis W_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"     07      W-QTDIA              PIC S9(05)  COMP-3.*/
                public IntBasis W_QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
                /*"     07      W-DATA02             PIC  9(08).*/
                public IntBasis W_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"  05         W-DATA-EDITADA.*/
            }
            public FC0038B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new FC0038B_W_DATA_EDITADA();
            public class FC0038B_W_DATA_EDITADA : VarBasis
            {
                /*"     07      W-ANO                PIC  9(04).*/
                public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     07      FILLER               PIC  X(01).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     07      W-MES                PIC  9(02).*/
                public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     07      FILLER               PIC  X(01).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     07      W-DIA                PIC  9(02).*/
                public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05         TABELA-MESES.*/
            }
            public FC0038B_TABELA_MESES TABELA_MESES { get; set; } = new FC0038B_TABELA_MESES();
            public class FC0038B_TABELA_MESES : VarBasis
            {
                /*"     07      FILLER               PIC X(010)  VALUE '0 JANEIRO '*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 JANEIRO ");
                /*"     07      FILLER               PIC X(010)  VALUE '0FEVEREIRO'*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0FEVEREIRO");
                /*"     07      FILLER               PIC X(010)  VALUE '0  MARCO  '*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  MARCO  ");
                /*"     07      FILLER               PIC X(010)  VALUE '0  ABRIL  '*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  ABRIL  ");
                /*"     07      FILLER               PIC X(010)  VALUE '0  MAIO   '*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  MAIO   ");
                /*"     07      FILLER               PIC X(010)  VALUE '0  JUNHO  '*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  JUNHO  ");
                /*"     07      FILLER               PIC X(010)  VALUE '0  JULHO  '*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0  JULHO  ");
                /*"     07      FILLER               PIC X(010)  VALUE '0 AGOSTO  '*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 AGOSTO  ");
                /*"     07      FILLER               PIC X(010)  VALUE '0SETEMBRO '*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0SETEMBRO ");
                /*"     07      FILLER               PIC X(010)  VALUE '0 OUTUBRO '*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0 OUTUBRO ");
                /*"     07      FILLER               PIC X(010)  VALUE '0NOVEMBRO '*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0NOVEMBRO ");
                /*"     07      FILLER               PIC X(010)  VALUE '0DEZEMBRO '*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0DEZEMBRO ");
                /*"  05         FILLER   REDEFINES   TABELA-MESES                                  OCCURS      12.*/
            }
            private ListBasis<_REDEF_FC0038B_FILLER_20> _filler_20 { get; set; }
            public ListBasis<_REDEF_FC0038B_FILLER_20> FILLER_20
            {
                get { _filler_20 = new ListBasis<_REDEF_FC0038B_FILLER_20>(12); _.Move(TABELA_MESES, _filler_20); VarBasis.RedefinePassValue(TABELA_MESES, _filler_20, TABELA_MESES); _filler_20.ValueChanged += () => { _.Move(_filler_20, TABELA_MESES); }; return _filler_20; }
                set { VarBasis.RedefinePassValue(value, _filler_20, TABELA_MESES); }
            }  //Redefines
            public class _REDEF_FC0038B_FILLER_20 : VarBasis
            {
                /*"     07      TAB-FLGMES           PIC  X(001).*/
                public StringBasis TAB_FLGMES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      TAB-MES              PIC  X(009).*/
                public StringBasis TAB_MES { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"  05         FAIXAS-CEP.*/

                public _REDEF_FC0038B_FILLER_20()
                {
                    TAB_FLGMES.ValueChanged += OnValueChanged;
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
            public FC0038B_FAIXAS_CEP FAIXAS_CEP { get; set; } = new FC0038B_FAIXAS_CEP();
            public class FC0038B_FAIXAS_CEP : VarBasis
            {
                /*"   06        FAIXA-CEP            OCCURS     2000.*/
                public ListBasis<FC0038B_FAIXA_CEP> FAIXA_CEP { get; set; } = new ListBasis<FC0038B_FAIXA_CEP>(2000);
                public class FC0038B_FAIXA_CEP : VarBasis
                {
                    /*"     07      TAB-CEPINI           PIC  9(008).*/
                    public IntBasis TAB_CEPINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"     07      TAB-CEPFIM           PIC  9(008).*/
                    public IntBasis TAB_CEPFIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"     07      TAB-DESCRI           PIC  X(072).*/
                    public StringBasis TAB_DESCRI { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"     07      TAB-CENTRA           PIC  X(072).*/
                    public StringBasis TAB_CENTRA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"  05         WTAB-IND             PIC  9(005)        VALUE ZEROS*/
                }
            }
            public IntBasis WTAB_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTAB-QTDREG          PIC  9(005)        VALUE 2000.*/
            public IntBasis WTAB_QTDREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"), 2000);
            /*"  05         TABELAS-RESUMO.*/
            public FC0038B_TABELAS_RESUMO TABELAS_RESUMO { get; set; } = new FC0038B_TABELAS_RESUMO();
            public class FC0038B_TABELAS_RESUMO : VarBasis
            {
                /*"   06        TABELA-RESUMO        OCCURS     2000.*/
                public ListBasis<FC0038B_TABELA_RESUMO> TABELA_RESUMO { get; set; } = new ListBasis<FC0038B_TABELA_RESUMO>(2000);
                public class FC0038B_TABELA_RESUMO : VarBasis
                {
                    /*"     07      TB2-CEPINI           PIC  9(008).*/
                    public IntBasis TB2_CEPINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"     07      TB2-CEPFIM           PIC  9(008).*/
                    public IntBasis TB2_CEPFIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"     07      TB2-OBJINI           PIC  9(006).*/
                    public IntBasis TB2_OBJINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"     07      TB2-OBJFIM           PIC  9(006).*/
                    public IntBasis TB2_OBJFIM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"     07      TB2-AMRINI           PIC  9(006).*/
                    public IntBasis TB2_AMRINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"     07      TB2-AMRFIM           PIC  9(006).*/
                    public IntBasis TB2_AMRFIM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"     07      TB2-QTDOBJ           PIC  9(006).*/
                    public IntBasis TB2_QTDOBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"     07      TB2-QTDAMR           PIC  9(006).*/
                    public IntBasis TB2_QTDAMR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"     07      TB2-DESCRI           PIC  X(072).*/
                    public StringBasis TB2_DESCRI { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"     07      TB2-CENTRA           PIC  X(072).*/
                    public StringBasis TB2_CENTRA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"  05         WTB2-IND             PIC  9(005)        VALUE ZEROS*/
                }
            }
            public IntBasis WTB2_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WTB2-QTDREG          PIC  9(005)        VALUE 2000.*/
            public IntBasis WTB2_QTDREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"), 2000);
            /*"  05         WCONT-CONTADOR       PIC S9(008) COMP-3 VALUE +0.*/
            public IntBasis WCONT_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"  05         WTOT-CONTADOR        PIC S9(008) COMP-3 VALUE +0.*/
            public IntBasis WTOT_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"  05         WCONT-OBJETO         PIC S9(008) COMP-3 VALUE +0.*/
            public IntBasis WCONT_OBJETO { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"  05         WCONT-AMARRADO       PIC S9(008) COMP-3 VALUE +0.*/
            public IntBasis WCONT_AMARRADO { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"  05         WTOT-AMARRADO        PIC S9(008) COMP-3 VALUE +0.*/
            public IntBasis WTOT_AMARRADO { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"  05         WCEP-NUMANT          PIC  9(008)        VALUE ZEROS*/
            public IntBasis WCEP_NUMANT_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WFAI-CEPINI          PIC  9(008)        VALUE ZEROS*/
            public IntBasis WFAI_CEPINI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WFAI-CEPFIM          PIC  9(008)        VALUE ZEROS*/
            public IntBasis WFAI_CEPFIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WFAI-OBJINI          PIC  9(006)        VALUE ZEROS*/
            public IntBasis WFAI_OBJINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFAI-OBJFIM          PIC  9(006)        VALUE ZEROS*/
            public IntBasis WFAI_OBJFIM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFAI-AMRINI          PIC  9(006)        VALUE ZEROS*/
            public IntBasis WFAI_AMRINI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFAI-AMRFIM          PIC  9(006)        VALUE ZEROS*/
            public IntBasis WFAI_AMRFIM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFAI-QTDOBJ          PIC  9(006)        VALUE ZEROS*/
            public IntBasis WFAI_QTDOBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFAI-QTDAMR          PIC  9(006)        VALUE ZEROS*/
            public IntBasis WFAI_QTDAMR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFAI-DESCRICAO       PIC  X(072)       VALUE spaces*/
            public StringBasis WFAI_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"spaces");
            /*"  05         WFAI-CENTRALIZA      PIC  X(072)       VALUE SPACES*/
            public StringBasis WFAI_CENTRALIZA { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
            /*"  05         WFIM-ARQCARTA        PIC  X(001) VALUE SPACES.*/
            public StringBasis WFIM_ARQCARTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0FAIXACEP      PIC  X(001) VALUE SPACES.*/
            public StringBasis WFIM_V0FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-FAIXA-CEP       PIC  X(001) VALUE SPACES.*/
            public StringBasis WFIM_FAIXA_CEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTAB-PESQUISA        PIC  X(001) VALUE SPACES.*/
            public StringBasis WTAB_PESQUISA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-FOLHA             PIC S9(003) COMP-3 VALUE +0.*/
            public IntBasis AC_FOLHA { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         AC-PAGINA            PIC S9(003) COMP-3 VALUE +0.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         AC-LINHAS            PIC S9(003) COMP-3 VALUE +20.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +20);
            /*"  05         AC-L-ARQCARTA        PIC S9(005) COMP-3 VALUE +0.*/
            public IntBasis AC_L_ARQCARTA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         AC-I-ARQCARTA        PIC S9(005) COMP-3 VALUE +0.*/
            public IntBasis AC_I_ARQCARTA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         AC-I-RELATORIOS      PIC S9(005) COMP-3 VALUE +0.*/
            public IntBasis AC_I_RELATORIOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05         WWORK-QTDE           PIC S9(003) COMP-3 VALUE +0.*/
            public IntBasis WWORK_QTDE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WFLAG                PIC  9(001)        VALUE ZEROS*/
            public IntBasis WFLAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WCONTROLE            PIC  9(001)        VALUE ZEROS*/
            public IntBasis WCONTROLE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WTAB-IND2            PIC  9(005) VALUE  ZEROS.*/
            public IntBasis WTAB_IND2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WFLAG-QUEBRA         PIC  X(001) VALUE  SPACES.*/
            public StringBasis WFLAG_QUEBRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFAIXA-OBJETOS       PIC S9(008)  COMP-3 VALUE +0.*/
            public IntBasis WFAIXA_OBJETOS { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"  05         CHAVE-TOLIGADO       PIC  X(001) VALUE  SPACES.*/
            public StringBasis CHAVE_TOLIGADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WQUANT-AMARRADO      PIC  9(005) VALUE  ZEROS.*/
            public IntBasis WQUANT_AMARRADO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WCHAVE-LEITURA       PIC  X(001) VALUE  SPACES.*/
            public StringBasis WCHAVE_LEITURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         TOTAL-OBJETOS        PIC  9(006) VALUE  ZEROS.*/
            public IntBasis TOTAL_OBJETOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WREL-DTPROC.*/
            public FC0038B_WREL_DTPROC WREL_DTPROC { get; set; } = new FC0038B_WREL_DTPROC();
            public class FC0038B_WREL_DTPROC : VarBasis
            {
                /*"     07      WREL-DIAPROC         PIC  9(002).*/
                public IntBasis WREL_DIAPROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     07      WREL-BARR1           PIC  X(001).*/
                public StringBasis WREL_BARR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WREL-MESPROC         PIC  9(002).*/
                public IntBasis WREL_MESPROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     07      WREL-BARR2           PIC  X(001).*/
                public StringBasis WREL_BARR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     07      WREL-ANOPROC         PIC  9(004).*/
                public IntBasis WREL_ANOPROC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WW01-NUMCEP.*/
            }
            public FC0038B_WW01_NUMCEP WW01_NUMCEP { get; set; } = new FC0038B_WW01_NUMCEP();
            public class FC0038B_WW01_NUMCEP : VarBasis
            {
                /*"     07      WW01-NUMCEP-1        PIC  9(005).*/
                public IntBasis WW01_NUMCEP_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"     07      WW01-COMPCEP         PIC  9(003).*/
                public IntBasis WW01_COMPCEP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05         WREL-NUMCEP.*/
            }
            public FC0038B_WREL_NUMCEP WREL_NUMCEP { get; set; } = new FC0038B_WREL_NUMCEP();
            public class FC0038B_WREL_NUMCEP : VarBasis
            {
                /*"     07      WREL-NUMCEP-1        PIC  9(005).*/
                public IntBasis WREL_NUMCEP_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"     07      WREL-TRACO           PIC  X(001) VALUE '-'.*/
                public StringBasis WREL_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     07      WREL-COMPCEP         PIC  9(003).*/
                public IntBasis WREL_COMPCEP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"01  LC01.*/
            }
        }
        public FC0038B_LC01 LC01 { get; set; } = new FC0038B_LC01();
        public class FC0038B_LC01 : VarBasis
        {
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LC01-NUMRELAT                PIC  999.*/
            public IntBasis LC01_NUMRELAT { get; set; } = new IntBasis(new PIC("9", "3", "999."));
            /*"    05 FILLER                       PIC  X(002) VALUE '/ '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"/ ");
            /*"    05 LC01-MESPROC                 PIC  X(020).*/
            public StringBasis LC01_MESPROC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"    05 FILLER                       PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"01  LC02.*/
        }
        public FC0038B_LC02 LC02 { get; set; } = new FC0038B_LC02();
        public class FC0038B_LC02 : VarBasis
        {
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LC02-PRODUTO                 PIC  X(100) VALUE SPACES.*/
            public StringBasis LC02_PRODUTO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
            /*"01  LC03.*/
        }
        public FC0038B_LC03 LC03 { get; set; } = new FC0038B_LC03();
        public class FC0038B_LC03 : VarBasis
        {
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LC03-DATREL                  PIC  X(010) VALUE SPACES.*/
            public StringBasis LC03_DATREL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  LC04.*/
        }
        public FC0038B_LC04 LC04 { get; set; } = new FC0038B_LC04();
        public class FC0038B_LC04 : VarBasis
        {
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LC04-FOLHA                   PIC  999.*/
            public IntBasis LC04_FOLHA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
            /*"    05 FILLER                       PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05 LC04-PAGINA                  PIC  999.*/
            public IntBasis LC04_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "999."));
            /*"01  LD01.*/
        }
        public FC0038B_LD01 LD01 { get; set; } = new FC0038B_LD01();
        public class FC0038B_LD01 : VarBasis
        {
            /*"    05 LD01-CANAL                   PIC  X(002) VALUE spaces.*/
            public StringBasis LD01_CANAL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"spaces");
            /*"    05 FILLER                       PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 LD01-CEPINI                  PIC  X(009) VALUE SPACES.*/
            public StringBasis LD01_CEPINI { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"    05 FILLER                       PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"    05 LD01-CEPFIM                  PIC  X(009) VALUE SPACES.*/
            public StringBasis LD01_CEPFIM { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"    05 FILLER                       PIC  X(007) VALUE SPACES.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"    05 LD01-OBJET1                  PIC  999.999.*/
            public IntBasis LD01_OBJET1 { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LD01-OBJET2                  PIC  999.999.*/
            public IntBasis LD01_OBJET2 { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LD01-AMARR1                  PIC  999.999.*/
            public IntBasis LD01_AMARR1 { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"    05 LD01-AMARR2                  PIC  999.999.*/
            public IntBasis LD01_AMARR2 { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(006) VALUE SPACES.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
            /*"    05 LD01-QTDOBJ                  PIC  999.999.*/
            public IntBasis LD01_QTDOBJ { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    05 LD01-QTDAMA                  PIC  999.999.*/
            public IntBasis LD01_QTDAMA { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(004) VALUE SPACES.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05 LD01-OBSERVACAO              PIC  X(022) VALUE SPACES.*/
            public StringBasis LD01_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
            /*"01  LF01.*/
        }
        public FC0038B_LF01 LF01 { get; set; } = new FC0038B_LF01();
        public class FC0038B_LF01 : VarBasis
        {
            /*"    05 LF01-LOCAL                   PIC  X(072) VALUE SPACES.*/
            public StringBasis LF01_LOCAL { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
            /*"    05 FILLER                       PIC  X(001) VALUE '|'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"    05 LF01-CEPINI                  PIC  X(009) VALUE SPACES.*/
            public StringBasis LF01_CEPINI { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"    05 FILLER                       PIC  X(005) VALUE '  A  '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  A  ");
            /*"    05 LF01-CEPFIM                  PIC  X(009) VALUE SPACES.*/
            public StringBasis LF01_CEPFIM { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"    05 FILLER                       PIC  X(001) VALUE '|'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"    05 LF01-QTDOBJ                  PIC  999.*/
            public IntBasis LF01_QTDOBJ { get; set; } = new IntBasis(new PIC("9", "3", "999."));
            /*"    05 FILLER                       PIC  X(001) VALUE '|'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"    05 LF01-NUMAMR                  PIC  999.999.*/
            public IntBasis LF01_NUMAMR { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(001) VALUE '|'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
            /*"    05 LF01-OBJINI                  PIC  999.999.*/
            public IntBasis LF01_OBJINI { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"    05 FILLER                       PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05 LF01-OBJFIM                  PIC  999.999.*/
            public IntBasis LF01_OBJFIM { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
            /*"01  WABEND.*/
        }
        public FC0038B_WABEND WABEND { get; set; } = new FC0038B_WABEND();
        public class FC0038B_WABEND : VarBasis
        {
            /*"    03 FILLER       PIC X(010) VALUE 'FC0038B '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FC0038B ");
            /*"    03 FILLER       PIC X(026) VALUE '*** ERRO EXEC SQL NUMERO '*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"    03 WNR-EXEC-SQL PIC X(005) VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"    03 FILLER       PIC X(013) VALUE ' *** SQLCODE '.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    03 WSQLCODE     PIC ZZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-."));
            /*"    03 FILLER       PIC X(02)  VALUE '=>'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"=>");
            /*"    03 FILLER       PIC X(12)  VALUE ' PARAGRAFO '.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" PARAGRAFO ");
            /*"    03 PARAGRAFO    PIC X(30)  VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
        }


        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public FC0038B_V0FAIXACEP V0FAIXACEP { get; set; } = new FC0038B_V0FAIXACEP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ENTRADA_FILE_NAME_P, string ARQCARTA_FILE_NAME_P, string RFC0038B1_FILE_NAME_P, string RFC0038B2_FILE_NAME_P, string CEPERROS_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ENTRADA.SetFile(ENTRADA_FILE_NAME_P);
                ARQCARTA.SetFile(ARQCARTA_FILE_NAME_P);
                RFC0038B1.SetFile(RFC0038B1_FILE_NAME_P);
                RFC0038B2.SetFile(RFC0038B2_FILE_NAME_P);
                CEPERROS.SetFile(CEPERROS_FILE_NAME_P);

                /*" -558- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -559- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -561- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -563- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -563- FLUXCONTROL_PERFORM R0000-01-PRINCIPAL-SECTION */

                R0000_01_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-01-PRINCIPAL-SECTION */
        private void R0000_01_PRINCIPAL_SECTION()
        {
            /*" -572- OPEN INPUT ENTRADA */
            ENTRADA.Open(REG_ENTRADA);

            /*" -573- INPUT ARQCARTA */
            ARQCARTA.Open(REG_ARQCARTA);

            /*" -574- OUTPUT RFC0038B1 */
            RFC0038B1.Open(RES_FC0038B1);

            /*" -575- OUTPUT RFC0038B2 */
            RFC0038B2.Open(RES_FC0038B2);

            /*" -577- OUTPUT CEPERROS. */
            CEPERROS.Open(REG_CEPERROS);

            /*" -579- MOVE SPACES TO FAIXAS-CEP TABELAS-RESUMO. */
            _.Move("", AREA_DE_WORK.FAIXAS_CEP, AREA_DE_WORK.TABELAS_RESUMO);

            /*" -579- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -584- DISPLAY 'O ARQUIVO DE ENTRADA NAO CONTEM A QUANTIDADE DE DIAS UTEIS Q 'UE SERA USADA PARA PROCESSAMENTO E ENVELOPAMENTO DAS CARTAS 'A SEREM GERADAS' */

                    $"O ARQUIVO DE ENTRADA NAO CONTEM A QUANTIDADE DE DIAS UTEIS Q UESERAUSADAPARAPROCESSAMENTOEENVELOPAMENTODASCARTASA SEREM GERADAS"
                    .Display();

                    /*" -586- DISPLAY 'O PROGRAMA NAO SERA PROCESSADO' */
                    _.Display($"O PROGRAMA NAO SERA PROCESSADO");

                    /*" -587- MOVE 'E' TO WOK */
                    _.Move("E", AREA_DE_WORK.WOK);

                    /*" -589- GO TO R0000-80-FINALIZA. */

                    R0000_80_FINALIZA(); //GOTO
                    return;
                });

                _.Move(ENTRADA.Value, REG_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -590- IF REG-QTDIAS NOT NUMERIC */

            if (!REG_ENTRADA.REG_QTDIAS.IsNumeric())
            {

                /*" -593- DISPLAY 'INFORMACAO DE QUANTIDADE DE DIAS NAO NUMERICA PARA PROCESSAM 'ENTO E ENVELOPAMENTO DAS CARTAS A SEREM GERADAS' */

                $"INFORMACAO DE QUANTIDADE DE DIAS NAO NUMERICA PARA PROCESSAM ENTOEENVELOPAMENTODASCARTASASEREMGERADAS"
                .Display();

                /*" -595- DISPLAY 'O PROGRAMA NAO SERA PROCESSADO' */
                _.Display($"O PROGRAMA NAO SERA PROCESSADO");

                /*" -596- MOVE 'E' TO WOK */
                _.Move("E", AREA_DE_WORK.WOK);

                /*" -598- GO TO R0000-80-FINALIZA. */

                R0000_80_FINALIZA(); //GOTO
                return;
            }


            /*" -600- PERFORM R0100-00-ACESSA-V0SISTEMA. */

            R0100_00_ACESSA_V0SISTEMA_SECTION();

            /*" -601- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, WS_COUNT);

            /*" -603- MOVE WHOST-DTMOVABE TO WHOST-PROXIMA-DATA. */
            _.Move(WHOST_DTMOVABE, WHOST_PROXIMA_DATA);

            /*" -606- PERFORM R0110-00-CALC-DIAS-UTEIS UNTIL WS-COUNT EQUAL REG-QTDIAS. */

            while (!(WS_COUNT == REG_ENTRADA.REG_QTDIAS))
            {

                R0110_00_CALC_DIAS_UTEIS_SECTION();
            }

            /*" -607- MOVE CALENDAR-DATA-CALENDARIO TO WS-DTREFER. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, AREA_DE_WORK.WS_DTREFER);

            /*" -608- MOVE WS-MESREFER TO V0SIST-MESREFER. */
            _.Move(AREA_DE_WORK.WS_DTREFER.WS_MESREFER, V0SIST_MESREFER);

            /*" -610- MOVE WS-ANOREFER TO V0SIST-ANOREFER. */
            _.Move(AREA_DE_WORK.WS_DTREFER.WS_ANOREFER, V0SIST_ANOREFER);

            /*" -611- DISPLAY 'DATA DO SISTEMA................ = ' V0SIST-DTMOVABE. */
            _.Display($"DATA DO SISTEMA................ = {V0SIST_DTMOVABE}");

            /*" -612- DISPLAY 'QTDE DIAS INFORMADA NO ARQUIVO. = ' REG-QTDIAS. */
            _.Display($"QTDE DIAS INFORMADA NO ARQUIVO. = {REG_ENTRADA.REG_QTDIAS}");

            /*" -615- DISPLAY 'DATA CALCULADA................. = ' CALENDAR-DATA-CALENDARIO. */
            _.Display($"DATA CALCULADA................. = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

            /*" -617- PERFORM R0200-00-MONTA-TABCEP. */

            R0200_00_MONTA_TABCEP_SECTION();

            /*" -618- IF WTAB-QTDREG EQUAL 1 */

            if (AREA_DE_WORK.WTAB_QTDREG == 1)
            {

                /*" -620- DISPLAY 'FAIXA CEP NAO CARREGADA - PROGRAMA NAO PROCESSADO' */
                _.Display($"FAIXA CEP NAO CARREGADA - PROGRAMA NAO PROCESSADO");

                /*" -622- GO TO R0000-80-FINALIZA. */

                R0000_80_FINALIZA(); //GOTO
                return;
            }


            /*" -624- PERFORM R0300-00-OBTEM-NUMERACAO. */

            R0300_00_OBTEM_NUMERACAO_SECTION();

            /*" -625- MOVE ' ' TO WFIM-ARQCARTA. */
            _.Move(" ", AREA_DE_WORK.WFIM_ARQCARTA);

            /*" -627- PERFORM R0900-00-LE-ARQCARTA. */

            R0900_00_LE_ARQCARTA_SECTION();

            /*" -628- IF REG-LIN-CONTRATO EQUAL SPACES */

            if (REG_ARQCARTA.REG_LINHA.REG_LIN_CONTRATO.IsEmpty())
            {

                /*" -631- DISPLAY 'O PROGRAMA DE ENTRADA NAO TEM O NUMERO DO CONTRATO DA EMPRES 'A EMISSORA DAS CARTAS A SEREM IMPRESSAS, COM A ECT.' */

                $"O PROGRAMA DE ENTRADA NAO TEM O NUMERO DO CONTRATO DA EMPRES AEMISSORADASCARTASASEREMIMPRESSAS,COMAECT."
                .Display();

                /*" -633- DISPLAY 'O PROGRAMA NAO SERA PROCESSADO' */
                _.Display($"O PROGRAMA NAO SERA PROCESSADO");

                /*" -634- MOVE 'F' TO WOK */
                _.Move("F", AREA_DE_WORK.WOK);

                /*" -635- GO TO R0000-80-FINALIZA */

                R0000_80_FINALIZA(); //GOTO
                return;

                /*" -636- ELSE */
            }
            else
            {


                /*" -638- MOVE REG-LIN-CONTRATO TO WCONTRATO. */
                _.Move(REG_ARQCARTA.REG_LINHA.REG_LIN_CONTRATO, AREA_DE_WORK.WCONTRATO);
            }


            /*" -639- IF REG-NOM-EMPRESA EQUAL SPACES */

            if (REG_ARQCARTA.REG_LINHA.REG_NOM_EMPRESA.IsEmpty())
            {

                /*" -642- DISPLAY 'O PROGRAMA DE ENTRADA NAO TEM O NOME DA EMPRESA EMISSORA DAS 'CARTAS A SEREM IMPRESSAS E ENVIADAS A ECT.' */

                $"O PROGRAMA DE ENTRADA NAO TEM O NOME DA EMPRESA EMISSORA DAS CARTASASEREMIMPRESSASEENVIADASAECT."
                .Display();

                /*" -644- DISPLAY 'O PROGRAMA NAO SERA PROCESSADO' */
                _.Display($"O PROGRAMA NAO SERA PROCESSADO");

                /*" -645- MOVE 'G' TO WOK */
                _.Move("G", AREA_DE_WORK.WOK);

                /*" -646- GO TO R0000-80-FINALIZA */

                R0000_80_FINALIZA(); //GOTO
                return;

                /*" -647- ELSE */
            }
            else
            {


                /*" -649- MOVE REG-NOM-EMPRESA TO WEMPRESA. */
                _.Move(REG_ARQCARTA.REG_LINHA.REG_NOM_EMPRESA, AREA_DE_WORK.WEMPRESA);
            }


            /*" -650- IF REG-END-EMPRESA EQUAL SPACES */

            if (REG_ARQCARTA.REG_LINHA.REG_END_EMPRESA.IsEmpty())
            {

                /*" -653- DISPLAY 'O PROGRAMA DE ENTRADA NAO TEM O ENDERECO DA EMPRESA EMISSORA 'DAS CARTAS A SEREM IMPRESSAS E ENVIADAS A ECT.' */

                $"O PROGRAMA DE ENTRADA NAO TEM O ENDERECO DA EMPRESA EMISSORA DASCARTASASEREMIMPRESSASEENVIADASAECT."
                .Display();

                /*" -655- DISPLAY 'O PROGRAMA NAO SERA PROCESSADO' */
                _.Display($"O PROGRAMA NAO SERA PROCESSADO");

                /*" -656- MOVE 'H' TO WOK */
                _.Move("H", AREA_DE_WORK.WOK);

                /*" -657- GO TO R0000-80-FINALIZA */

                R0000_80_FINALIZA(); //GOTO
                return;

                /*" -658- ELSE */
            }
            else
            {


                /*" -660- MOVE REG-END-EMPRESA TO WENDEMPR. */
                _.Move(REG_ARQCARTA.REG_LINHA.REG_END_EMPRESA, AREA_DE_WORK.WENDEMPR);
            }


            /*" -668- IF REG-TIP-PRODUTO EQUAL SPACES */

            if (REG_ARQCARTA.REG_LINHA.REG_TIP_PRODUTO.IsEmpty())
            {

                /*" -669- MOVE REG-NOM-EMPRESA TO WTIPPROD */
                _.Move(REG_ARQCARTA.REG_LINHA.REG_NOM_EMPRESA, AREA_DE_WORK.WTIPPROD);

                /*" -670- ELSE */
            }
            else
            {


                /*" -672- MOVE REG-TIP-PRODUTO TO WTIPPROD. */
                _.Move(REG_ARQCARTA.REG_LINHA.REG_TIP_PRODUTO, AREA_DE_WORK.WTIPPROD);
            }


            /*" -673- IF WFIM-ARQCARTA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_ARQCARTA.IsEmpty())
            {

                /*" -674- PERFORM R9000-00-ENCERRA-SEM-MOVTO */

                R9000_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -676- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -678- IF REG-INICIO-VERSO EQUAL SPACES OR REG-INICIO-VERSO-R EQUAL ZEROS */

            if (REG_ARQCARTA.REG_LINHA.REG_INICIO_VERSO.IsEmpty() || REG_ARQCARTA.REG_LINHA.REG_INICIO_VERSO_R == 00)
            {

                /*" -681- DISPLAY 'O PROGRAMA DE ENTRADA NAO TEM A INFORMACAO DO INICIO DO VERS 'O DAS CARTAS A SEREM IMPRESSAS E ENVIADAS A ECT.' */

                $"O PROGRAMA DE ENTRADA NAO TEM A INFORMACAO DO INICIO DO VERS ODASCARTASASEREMIMPRESSASEENVIADASAECT."
                .Display();

                /*" -683- DISPLAY 'O PROGRAMA NAO SERA PROCESSADO' */
                _.Display($"O PROGRAMA NAO SERA PROCESSADO");

                /*" -684- MOVE 'I' TO WOK */
                _.Move("I", AREA_DE_WORK.WOK);

                /*" -685- GO TO R0000-80-FINALIZA */

                R0000_80_FINALIZA(); //GOTO
                return;

                /*" -686- ELSE */
            }
            else
            {


                /*" -688- MOVE REG-INICIO-VERSO-R TO WREG-INICIO-VERSO. */
                _.Move(REG_ARQCARTA.REG_LINHA.REG_INICIO_VERSO_R, AREA_DE_WORK.WREG_INICIO_VERSO);
            }


            /*" -690- DISPLAY '*** FC0038B *** PROCESSANDO...' . */
            _.Display($"*** FC0038B *** PROCESSANDO...");

            /*" -692- ADD 1 TO WCONTLIN */
            AREA_DE_WORK.WCONTLIN.Value = AREA_DE_WORK.WCONTLIN + 1;

            /*" -694- MOVE REG-ARQCARTA TO WLINHA01 */
            _.Move(ARQCARTA?.Value, AREA_DE_WORK.WLINHA01);

            /*" -696- MOVE SPACES TO WLINHA0122 */
            _.Move("", AREA_DE_WORK.WLINHA01.WLINHA012.WLINHA0122);

            /*" -697- WRITE RES-FC0038B1 FROM WLINHA012 */
            _.Move(AREA_DE_WORK.WLINHA01.WLINHA012.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -698- WRITE RES-FC0038B1 FROM WLINHA20 */
            _.Move(AREA_DE_WORK.WLINHA20.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -699- WRITE RES-FC0038B1 FROM WLINHA21 */
            _.Move(AREA_DE_WORK.WLINHA21.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -700- WRITE RES-FC0038B1 FROM WLINHA16 */
            _.Move(AREA_DE_WORK.WLINHA16.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -701- WRITE RES-FC0038B1 FROM WLINHA17 */
            _.Move(AREA_DE_WORK.WLINHA17.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -702- WRITE RES-FC0038B1 FROM WLINHA18 */
            _.Move(AREA_DE_WORK.WLINHA18.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -704- WRITE RES-FC0038B1 FROM WLINHA19 */
            _.Move(AREA_DE_WORK.WLINHA19.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -706- PERFORM R0900-00-LE-ARQCARTA. */

            R0900_00_LE_ARQCARTA_SECTION();

            /*" -709- PERFORM R1000-00-PROCESSA-CARTA UNTIL WFIM-ARQCARTA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_ARQCARTA.IsEmpty()))
            {

                R1000_00_PROCESSA_CARTA_SECTION();
            }

            /*" -711- IF WOK EQUAL 'A' OR WOK EQUAL 'C' */

            if (AREA_DE_WORK.WOK == "A" || AREA_DE_WORK.WOK == "C")
            {

                /*" -714- DISPLAY 'DATA DE POSTAGEM E OBJETO QUE CONSTAM NO VERSO DA CARTA DO 'LADO ESQUERDO ESTAO INCONSISTENTES' */

                $"DATA DE POSTAGEM E OBJETO QUE CONSTAM NO VERSO DA CARTA DO LADOESQUERDOESTAOINCONSISTENTES"
                .Display();

                /*" -716- DISPLAY 'ARQUIVO DESPREZADO' ' ' WOK ' ' AC-L-ARQCARTA */

                $"ARQUIVO DESPREZADO {AREA_DE_WORK.WOK} {AREA_DE_WORK.AC_L_ARQCARTA}"
                .Display();

                /*" -717- GO TO R0000-80-FINALIZA */

                R0000_80_FINALIZA(); //GOTO
                return;

                /*" -718- ELSE */
            }
            else
            {


                /*" -719- IF WOK EQUAL 'B' */

                if (AREA_DE_WORK.WOK == "B")
                {

                    /*" -722- DISPLAY 'O CEP QUE CONSTA NA CARTA ESTA INVALIDO. ARQUIVO DESPREZADO ' ' ' ' WOK */

                    $"O CEP QUE CONSTA NA CARTA ESTA INVALIDO. ARQUIVO DESPREZADO  {AREA_DE_WORK.WOK}"
                    .Display();

                    /*" -723- GO TO R0000-80-FINALIZA */

                    R0000_80_FINALIZA(); //GOTO
                    return;

                    /*" -724- END-IF */
                }


                /*" -726- END-IF */
            }


            /*" -728- WRITE RES-FC0038B1 FROM WLINHA05. */
            _.Move(AREA_DE_WORK.WLINHA05.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -729- MOVE WTB2-IND TO WTB2-QTDREG. */
            _.Move(AREA_DE_WORK.WTB2_IND, AREA_DE_WORK.WTB2_QTDREG);

            /*" -730- MOVE 1 TO WTB2-IND. */
            _.Move(1, AREA_DE_WORK.WTB2_IND);

            /*" -731- COMPUTE AC-PAGINA = (WTB2-QTDREG / 18) */
            AREA_DE_WORK.AC_PAGINA.Value = (AREA_DE_WORK.WTB2_QTDREG / 18);

            /*" -732- COMPUTE WWORK-QTDE = AC-PAGINA * 18 */
            AREA_DE_WORK.WWORK_QTDE.Value = AREA_DE_WORK.AC_PAGINA * 18;

            /*" -733- COMPUTE WWORK-QTDE = WTB2-QTDREG - WWORK-QTDE */
            AREA_DE_WORK.WWORK_QTDE.Value = AREA_DE_WORK.WTB2_QTDREG - AREA_DE_WORK.WWORK_QTDE;

            /*" -734- IF WWORK-QTDE NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WWORK_QTDE != 00)
            {

                /*" -736- COMPUTE AC-PAGINA = AC-PAGINA + 1. */
                AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;
            }


            /*" -737- WRITE RES-FC0038B2 FROM WLINHA06 */
            _.Move(AREA_DE_WORK.WLINHA06.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -739- WRITE RES-FC0038B2 FROM WLINHA12 */
            _.Move(AREA_DE_WORK.WLINHA12.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -742- PERFORM R4000-00-IMPRIME-RESUMO UNTIL WTB2-IND GREATER WTB2-QTDREG. */

            while (!(AREA_DE_WORK.WTB2_IND > AREA_DE_WORK.WTB2_QTDREG))
            {

                R4000_00_IMPRIME_RESUMO_SECTION();
            }

            /*" -742- WRITE RES-FC0038B2 FROM WLINHA05. */
            _.Move(AREA_DE_WORK.WLINHA05.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R0000_80_FINALIZA */

            R0000_80_FINALIZA();

        }

        [StopWatch]
        /*" R0000-80-FINALIZA */
        private void R0000_80_FINALIZA(bool isPerform = false)
        {
            /*" -747- DISPLAY '************ FC0038B * RESUMO ***********' */
            _.Display($"************ FC0038B * RESUMO ***********");

            /*" -748- DISPLAY '* REGISTROS LIDOS          = ' AC-L-ARQCARTA */
            _.Display($"* REGISTROS LIDOS          = {AREA_DE_WORK.AC_L_ARQCARTA}");

            /*" -749- DISPLAY '* REGISTROS REJEITADOS     = ' WCEPERRO */
            _.Display($"* REGISTROS REJEITADOS     = {AREA_DE_WORK.WCEPERRO}");

            /*" -750- DISPLAY '* REGISTROS IMPRESSOS      = ' AC-I-ARQCARTA */
            _.Display($"* REGISTROS IMPRESSOS      = {AREA_DE_WORK.AC_I_ARQCARTA}");

            /*" -750- DISPLAY '*****************************************' . */
            _.Display($"*****************************************");

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -760- CLOSE ENTRADA ARQCARTA RFC0038B1 RFC0038B2 CEPERROS */
            ENTRADA.Close();
            ARQCARTA.Close();
            RFC0038B1.Close();
            RFC0038B2.Close();
            CEPERROS.Close();

            /*" -761- IF WOK NOT EQUAL 'S' */

            if (AREA_DE_WORK.WOK != "S")
            {

                /*" -762- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -764- DISPLAY '*** FC0038B *** TERMINO ANORMAL = ' WOK */
                _.Display($"*** FC0038B *** TERMINO ANORMAL = {AREA_DE_WORK.WOK}");

                /*" -765- ELSE */
            }
            else
            {


                /*" -766- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -768- DISPLAY '*** FC0038B *** TERMINO NORMAL' . */
                _.Display($"*** FC0038B *** TERMINO NORMAL");
            }


            /*" -768- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-ACESSA-V0SISTEMA-SECTION */
        private void R0100_00_ACESSA_V0SISTEMA_SECTION()
        {
            /*" -783- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -785- MOVE 'ACESSA-SISTEMA' TO PARAGRAFO. */
            _.Move("ACESSA-SISTEMA", WABEND.PARAGRAFO);

            /*" -792- PERFORM R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1 */

            R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1();

            /*" -795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -796- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -797- DISPLAY 'FC0038B - SISTEMA FINANCEIRO  NAO CADASTRADO' */
                    _.Display($"FC0038B - SISTEMA FINANCEIRO  NAO CADASTRADO");

                    /*" -798- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -799- ELSE */
                }
                else
                {


                    /*" -800- DISPLAY 'FC0038B - PROBLEMAS SELECT V1SISTEMA' */
                    _.Display($"FC0038B - PROBLEMAS SELECT V1SISTEMA");

                    /*" -800- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-00-ACESSA-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1()
        {
            /*" -792- EXEC SQL SELECT DTMOVABE, (DTMOVABE + 1 DAY) INTO :V0SIST-DTMOVABE, :WHOST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'FI' END-EXEC. */

            var r0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_ACESSA_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.WHOST_DTMOVABE, WHOST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-CALC-DIAS-UTEIS-SECTION */
        private void R0110_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -834- PERFORM R0120-00-CALCULA-DIA-UTIL. */

            R0120_00_CALCULA_DIA_UTIL_SECTION();

            /*" -838- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO EQUAL 'N' NEXT SENTENCE */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO == "N")
            {

                /*" -839- ELSE */
            }
            else
            {


                /*" -839- ADD 1 TO WS-COUNT. */
                WS_COUNT.Value = WS_COUNT + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-CALCULA-DIA-UTIL-SECTION */
        private void R0120_00_CALCULA_DIA_UTIL_SECTION()
        {
            /*" -851- MOVE '293' TO WNR-EXEC-SQL. */
            _.Move("293", WABEND.WNR_EXEC_SQL);

            /*" -865- PERFORM R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1 */

            R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1();

            /*" -868- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -869- DISPLAY 'FC0038B - PROBLEMAS SELECT CALENDARIO' */
                _.Display($"FC0038B - PROBLEMAS SELECT CALENDARIO");

                /*" -869- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-CALCULA-DIA-UTIL-DB-SELECT-1 */
        public void R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1()
        {
            /*" -865- EXEC SQL SELECT DATA_CALENDARIO, (DATA_CALENDARIO + 1 DAY), DIA_SEMANA, FERIADO INTO :CALENDAR-DATA-CALENDARIO, :WHOST-PROXIMA-DATA, :CALENDAR-DIA-SEMANA, :CALENDAR-FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :WHOST-PROXIMA-DATA END-EXEC. */

            var r0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1 = new R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1()
            {
                WHOST_PROXIMA_DATA = WHOST_PROXIMA_DATA.ToString(),
            };

            var executed_1 = R0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1.Execute(r0120_00_CALCULA_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(executed_1.WHOST_PROXIMA_DATA, WHOST_PROXIMA_DATA);
                _.Move(executed_1.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(executed_1.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-MONTA-TABCEP-SECTION */
        private void R0200_00_MONTA_TABCEP_SECTION()
        {
            /*" -880- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -882- MOVE 'MONTA-TABCEP' TO PARAGRAFO. */
            _.Move("MONTA-TABCEP", WABEND.PARAGRAFO);

            /*" -884- PERFORM R0210-00-DECLARE-FAIXACEP. */

            R0210_00_DECLARE_FAIXACEP_SECTION();

            /*" -886- PERFORM R0220-00-LE-FAIXACEP. */

            R0220_00_LE_FAIXACEP_SECTION();

            /*" -889- PERFORM R0230-00-MONTA-TABELA-CEP UNTIL WFIM-FAIXA-CEP NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_FAIXA_CEP.IsEmpty()))
            {

                R0230_00_MONTA_TABELA_CEP_SECTION();
            }

            /*" -890- MOVE WTAB-IND TO WTAB-QTDREG. */
            _.Move(AREA_DE_WORK.WTAB_IND, AREA_DE_WORK.WTAB_QTDREG);

            /*" -890- MOVE 1 TO WTAB-IND. */
            _.Move(1, AREA_DE_WORK.WTAB_IND);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-DECLARE-FAIXACEP-SECTION */
        private void R0210_00_DECLARE_FAIXACEP_SECTION()
        {
            /*" -903- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND.WNR_EXEC_SQL);

            /*" -905- MOVE 'MONTA-TABCEP' TO PARAGRAFO. */
            _.Move("MONTA-TABCEP", WABEND.PARAGRAFO);

            /*" -914- PERFORM R0210_00_DECLARE_FAIXACEP_DB_DECLARE_1 */

            R0210_00_DECLARE_FAIXACEP_DB_DECLARE_1();

            /*" -916- PERFORM R0210_00_DECLARE_FAIXACEP_DB_OPEN_1 */

            R0210_00_DECLARE_FAIXACEP_DB_OPEN_1();

            /*" -919- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -920- DISPLAY 'FC0038B - PROBLEMAS OPEN    V0FAIXA_CEP' */
                _.Display($"FC0038B - PROBLEMAS OPEN    V0FAIXA_CEP");

                /*" -920- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-DECLARE-FAIXACEP-DB-DECLARE-1 */
        public void R0210_00_DECLARE_FAIXACEP_DB_DECLARE_1()
        {
            /*" -914- EXEC SQL DECLARE V0FAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :V0SIST-DTMOVABE AND DATA_TERVIGENCIA >= :V0SIST-DTMOVABE END-EXEC. */
            V0FAIXACEP = new FC0038B_V0FAIXACEP(true);
            string GetQuery_V0FAIXACEP()
            {
                var query = @$"SELECT FAIXA
							, 
							CEP_INICIAL
							, 
							CEP_FINAL
							, 
							DESCRICAO_FAIXA
							, 
							CENTRALIZADOR 
							FROM SEGUROS.GE_FAIXA_CEP 
							WHERE DATA_INIVIGENCIA <= '{V0SIST_DTMOVABE}' 
							AND DATA_TERVIGENCIA >= '{V0SIST_DTMOVABE}'";

                return query;
            }
            V0FAIXACEP.GetQueryEvent += GetQuery_V0FAIXACEP;

        }

        [StopWatch]
        /*" R0210-00-DECLARE-FAIXACEP-DB-OPEN-1 */
        public void R0210_00_DECLARE_FAIXACEP_DB_OPEN_1()
        {
            /*" -916- EXEC SQL OPEN V0FAIXACEP END-EXEC. */

            V0FAIXACEP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-LE-FAIXACEP-SECTION */
        private void R0220_00_LE_FAIXACEP_SECTION()
        {
            /*" -933- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", WABEND.WNR_EXEC_SQL);

            /*" -935- MOVE 'LE-FAIXACEP' TO PARAGRAFO. */
            _.Move("LE-FAIXACEP", WABEND.PARAGRAFO);

            /*" -941- PERFORM R0220_00_LE_FAIXACEP_DB_FETCH_1 */

            R0220_00_LE_FAIXACEP_DB_FETCH_1();

            /*" -944- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -945- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -946- MOVE 'S' TO WFIM-FAIXA-CEP */
                    _.Move("S", AREA_DE_WORK.WFIM_FAIXA_CEP);

                    /*" -946- PERFORM R0220_00_LE_FAIXACEP_DB_CLOSE_1 */

                    R0220_00_LE_FAIXACEP_DB_CLOSE_1();

                    /*" -948- ELSE */
                }
                else
                {


                    /*" -949- DISPLAY 'FC0038B - PROBLEMAS LEITURA V0FAIXA_CEP' */
                    _.Display($"FC0038B - PROBLEMAS LEITURA V0FAIXA_CEP");

                    /*" -949- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0220-00-LE-FAIXACEP-DB-FETCH-1 */
        public void R0220_00_LE_FAIXACEP_DB_FETCH_1()
        {
            /*" -941- EXEC SQL FETCH V0FAIXACEP INTO :V0FCEP-FAIXA, :V0FCEP-CEPINI, :V0FCEP-CEPFIM, :V0FCEP-DESC-FAIXA, :V0FCEP-CENTRALIZADOR END-EXEC. */

            if (V0FAIXACEP.Fetch())
            {
                _.Move(V0FAIXACEP.V0FCEP_FAIXA, V0FCEP_FAIXA);
                _.Move(V0FAIXACEP.V0FCEP_CEPINI, V0FCEP_CEPINI);
                _.Move(V0FAIXACEP.V0FCEP_CEPFIM, V0FCEP_CEPFIM);
                _.Move(V0FAIXACEP.V0FCEP_DESC_FAIXA, V0FCEP_DESC_FAIXA);
                _.Move(V0FAIXACEP.V0FCEP_CENTRALIZADOR, V0FCEP_CENTRALIZADOR);
            }

        }

        [StopWatch]
        /*" R0220-00-LE-FAIXACEP-DB-CLOSE-1 */
        public void R0220_00_LE_FAIXACEP_DB_CLOSE_1()
        {
            /*" -946- EXEC SQL CLOSE V0FAIXACEP END-EXEC */

            V0FAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-MONTA-TABELA-CEP-SECTION */
        private void R0230_00_MONTA_TABELA_CEP_SECTION()
        {
            /*" -962- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", WABEND.WNR_EXEC_SQL);

            /*" -964- MOVE 'MONTA-TABELA-CEP' TO PARAGRAFO. */
            _.Move("MONTA-TABELA-CEP", WABEND.PARAGRAFO);

            /*" -966- ADD 1 TO WTAB-IND. */
            AREA_DE_WORK.WTAB_IND.Value = AREA_DE_WORK.WTAB_IND + 1;

            /*" -967- IF WTAB-IND GREATER WTAB-QTDREG */

            if (AREA_DE_WORK.WTAB_IND > AREA_DE_WORK.WTAB_QTDREG)
            {

                /*" -968- DISPLAY 'FC0038B - ESTOURO DA TABELA DE CEPS' */
                _.Display($"FC0038B - ESTOURO DA TABELA DE CEPS");

                /*" -970- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -971- MOVE V0FCEP-CEPINI TO TAB-CEPINI(WTAB-IND) */
            _.Move(V0FCEP_CEPINI, AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPINI);

            /*" -972- MOVE V0FCEP-CEPFIM TO TAB-CEPFIM(WTAB-IND) */
            _.Move(V0FCEP_CEPFIM, AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPFIM);

            /*" -973- MOVE V0FCEP-DESC-FAIXA TO TAB-DESCRI(WTAB-IND) */
            _.Move(V0FCEP_DESC_FAIXA, AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_DESCRI);

            /*" -975- MOVE V0FCEP-CENTRALIZADOR TO TAB-CENTRA(WTAB-IND) */
            _.Move(V0FCEP_CENTRALIZADOR, AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CENTRA);

            /*" -975- PERFORM R0220-00-LE-FAIXACEP. */

            R0220_00_LE_FAIXACEP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-OBTEM-NUMERACAO-SECTION */
        private void R0300_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -990- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -992- MOVE 'OBTEM-NUMERACAO' TO PARAGRAFO. */
            _.Move("OBTEM-NUMERACAO", WABEND.PARAGRAFO);

            /*" -999- PERFORM R0300_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R0300_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -1002- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1003- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1004- MOVE ZEROS TO V0RELA-NRCOPIAS */
                    _.Move(0, V0RELA_NRCOPIAS);

                    /*" -1005- ELSE */
                }
                else
                {


                    /*" -1006- DISPLAY 'FC0038B - PROBLEMAS SELECT V0RELATORIOS' */
                    _.Display($"FC0038B - PROBLEMAS SELECT V0RELATORIOS");

                    /*" -1008- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1009- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -1009- MOVE ZEROS TO V0RELA-NRCOPIAS. */
                _.Move(0, V0RELA_NRCOPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM B0300_10_INCLUI_RELATORIO */

            B0300_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R0300-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R0300_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -999- EXEC SQL SELECT MAX(NRCOPIAS) INTO :V0RELA-NRCOPIAS:VIND-NRCOPIAS FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'CARTAECT' AND MES_REFERENCIA = :V0SIST-MESREFER AND ANO_REFERENCIA = :V0SIST-ANOREFER END-EXEC. */

            var r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V0SIST_MESREFER = V0SIST_MESREFER.ToString(),
                V0SIST_ANOREFER = V0SIST_ANOREFER.ToString(),
            };

            var executed_1 = R0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r0300_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_NRCOPIAS, V0RELA_NRCOPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" B0300-10-INCLUI-RELATORIO */
        private void B0300_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -1015- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WABEND.WNR_EXEC_SQL);

            /*" -1017- MOVE 'INCLUI-RELATORIO' TO PARAGRAFO. */
            _.Move("INCLUI-RELATORIO", WABEND.PARAGRAFO);

            /*" -1019- ADD 1 TO V0RELA-NRCOPIAS. */
            V0RELA_NRCOPIAS.Value = V0RELA_NRCOPIAS + 1;

            /*" -1020- MOVE 'FC0038B' TO V0RELA-CODUSU */
            _.Move("FC0038B", V0RELA_CODUSU);

            /*" -1021- MOVE V0SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V0SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -1022- MOVE 'EM' TO V0RELA-IDSISTEM */
            _.Move("EM", V0RELA_IDSISTEM);

            /*" -1023- MOVE 'CARTAECT' TO V0RELA-CODRELAT */
            _.Move("CARTAECT", V0RELA_CODRELAT);

            /*" -1024- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -1025- MOVE V0SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V0SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -1026- MOVE V0SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V0SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -1027- MOVE V0SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(V0SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -1028- MOVE V0SIST-MESREFER TO V0RELA-MES-REFERENCIA */
            _.Move(V0SIST_MESREFER, V0RELA_MES_REFERENCIA);

            /*" -1029- MOVE V0SIST-ANOREFER TO V0RELA-ANO-REFERENCIA */
            _.Move(V0SIST_ANOREFER, V0RELA_ANO_REFERENCIA);

            /*" -1030- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -1031- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -1032- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -1033- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -1034- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -1035- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -1036- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -1037- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -1038- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -1039- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -1040- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -1041- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -1042- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -1043- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -1044- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -1045- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -1046- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -1047- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -1048- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -1049- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -1050- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -1051- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -1052- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -1053- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -1054- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -1055- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -1056- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -1057- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -1059- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -1102- PERFORM B0300_10_INCLUI_RELATORIO_DB_INSERT_1 */

            B0300_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -1105- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -1106- DISPLAY 'B0300-10 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B0300-10 (REGISTRO DUPLICADO) ... ");

                /*" -1108- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1110- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -1112- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1112- ADD 1 TO AC-I-RELATORIOS. */
            AREA_DE_WORK.AC_I_RELATORIOS.Value = AREA_DE_WORK.AC_I_RELATORIOS + 1;

        }

        [StopWatch]
        /*" B0300-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void B0300_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -1102- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var b0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DATA_SOLICITACAO = V0RELA_DATA_SOLICITACAO.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QUANTIDADE = V0RELA_QUANTIDADE.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFERENCIA = V0RELA_DATA_REFERENCIA.ToString(),
                V0RELA_MES_REFERENCIA = V0RELA_MES_REFERENCIA.ToString(),
                V0RELA_ANO_REFERENCIA = V0RELA_ANO_REFERENCIA.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALIDA = V0RELA_MODALIDA.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOLICE = V0RELA_NUM_APOLICE.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOLIDER = V0RELA_APOLIDER.ToString(),
                V0RELA_ENDOSLID = V0RELA_ENDOSLID.ToString(),
                V0RELA_NUM_PARC_LIDER = V0RELA_NUM_PARC_LIDER.ToString(),
                V0RELA_NUM_SINISTRO = V0RELA_NUM_SINISTRO.ToString(),
                V0RELA_NUM_SINI_LIDER = V0RELA_NUM_SINI_LIDER.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PREVIA_DEFINITIVA = V0RELA_PREVIA_DEFINITIVA.ToString(),
                V0RELA_ANAL_RESUMO = V0RELA_ANAL_RESUMO.ToString(),
                V0RELA_COD_EMPRESA = V0RELA_COD_EMPRESA.ToString(),
                V0RELA_PERI_RENOVACAO = V0RELA_PERI_RENOVACAO.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
            };

            B0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1.Execute(b0300_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-LE-ARQCARTA-SECTION */
        private void R0900_00_LE_ARQCARTA_SECTION()
        {
            /*" -1125- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1127- MOVE 'LE-ARQCARTA        ' TO PARAGRAFO. */
            _.Move("LE-ARQCARTA        ", WABEND.PARAGRAFO);

            /*" -1127- READ ARQCARTA AT END */
            try
            {
                ARQCARTA.Read(() =>
                {

                    /*" -1129- MOVE 'S' TO WFIM-ARQCARTA */
                    _.Move("S", AREA_DE_WORK.WFIM_ARQCARTA);

                    /*" -1131- GO TO R0900-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ARQCARTA.Value, REG_ARQCARTA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1133- ADD 1 TO AC-L-ARQCARTA. */
            AREA_DE_WORK.AC_L_ARQCARTA.Value = AREA_DE_WORK.AC_L_ARQCARTA + 1;

            /*" -1134- IF REG-LINHANR EQUAL 6 */

            if (REG_ARQCARTA.REG_LINHANR == 6)
            {

                /*" -1134- GO TO R0900-00-LE-ARQCARTA. */
                new Task(() => R0900_00_LE_ARQCARTA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CARTA-SECTION */
        private void R1000_00_PROCESSA_CARTA_SECTION()
        {
            /*" -1147- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -1149- MOVE 'PROCESSA-CARTA' TO PARAGRAFO. */
            _.Move("PROCESSA-CARTA", WABEND.PARAGRAFO);

            /*" -1150- IF REG-CONTADOR EQUAL ZEROS */

            if (REG_ARQCARTA.REG_CONTADOR == 00)
            {

                /*" -1151- ADD 1 TO WCONTLIN */
                AREA_DE_WORK.WCONTLIN.Value = AREA_DE_WORK.WCONTLIN + 1;

                /*" -1152- IF WCONTLIN EQUAL 2 */

                if (AREA_DE_WORK.WCONTLIN == 2)
                {

                    /*" -1153- MOVE REG-ARQCARTA TO WLINHA02 */
                    _.Move(ARQCARTA?.Value, AREA_DE_WORK.WLINHA02);

                    /*" -1154- WRITE RES-FC0038B1 FROM WLINHA022 */
                    _.Move(AREA_DE_WORK.WLINHA02.WLINHA022.GetMoveValues(), RES_FC0038B1);

                    RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

                    /*" -1155- END-IF */
                }


                /*" -1156- IF WCONTLIN EQUAL 3 */

                if (AREA_DE_WORK.WCONTLIN == 3)
                {

                    /*" -1157- MOVE REG-ARQCARTA TO WLINHA03 */
                    _.Move(ARQCARTA?.Value, AREA_DE_WORK.WLINHA03);

                    /*" -1158- WRITE RES-FC0038B1 FROM WLINHA032 */
                    _.Move(AREA_DE_WORK.WLINHA03.WLINHA032.GetMoveValues(), RES_FC0038B1);

                    RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

                    /*" -1159- END-IF */
                }


                /*" -1160- IF WCONTLIN EQUAL 4 */

                if (AREA_DE_WORK.WCONTLIN == 4)
                {

                    /*" -1161- MOVE REG-ARQCARTA TO WLINHA04 */
                    _.Move(ARQCARTA?.Value, AREA_DE_WORK.WLINHA04);

                    /*" -1162- WRITE RES-FC0038B1 FROM WLINHA042 */
                    _.Move(AREA_DE_WORK.WLINHA04.WLINHA042.GetMoveValues(), RES_FC0038B1);

                    RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

                    /*" -1163- END-IF */
                }


                /*" -1164- PERFORM R0900-00-LE-ARQCARTA */

                R0900_00_LE_ARQCARTA_SECTION();

                /*" -1166- GO TO R1000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1167- MOVE 1 TO WCONT-OBJETO */
            _.Move(1, AREA_DE_WORK.WCONT_OBJETO);

            /*" -1168- MOVE ZEROS TO WCONT-AMARRADO */
            _.Move(0, AREA_DE_WORK.WCONT_AMARRADO);

            /*" -1170- MOVE ZEROS TO WCONT-CONTADOR WTOT-CONTADOR */
            _.Move(0, AREA_DE_WORK.WCONT_CONTADOR, AREA_DE_WORK.WTOT_CONTADOR);

            /*" -1172- MOVE ' ' TO WTAB-PESQUISA */
            _.Move(" ", AREA_DE_WORK.WTAB_PESQUISA);

            /*" -1174- MOVE 1 TO WTAB-IND */
            _.Move(1, AREA_DE_WORK.WTAB_IND);

            /*" -1177- PERFORM R2000-00-PESQUISA-CEP UNTIL WTAB-PESQUISA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WTAB_PESQUISA.IsEmpty()))
            {

                R2000_00_PESQUISA_CEP_SECTION();
            }

            /*" -1178- IF WTAB-PESQUISA EQUAL 'N' */

            if (AREA_DE_WORK.WTAB_PESQUISA == "N")
            {

                /*" -1179- PERFORM R0900-00-LE-ARQCARTA */

                R0900_00_LE_ARQCARTA_SECTION();

                /*" -1181- ELSE */
            }
            else
            {


                /*" -1182- MOVE TAB-CEPINI(WTAB-IND) TO WFAI-CEPINI */
                _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPINI, AREA_DE_WORK.WFAI_CEPINI);

                /*" -1183- MOVE TAB-CEPFIM(WTAB-IND) TO WFAI-CEPFIM */
                _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPFIM, AREA_DE_WORK.WFAI_CEPFIM);

                /*" -1184- MOVE TAB-DESCRI(WTAB-IND) TO WFAI-DESCRICAO */
                _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_DESCRI, AREA_DE_WORK.WFAI_DESCRICAO);

                /*" -1185- MOVE TAB-CENTRA(WTAB-IND) TO WFAI-CENTRALIZA */
                _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CENTRA, AREA_DE_WORK.WFAI_CENTRALIZA);

                /*" -1186- MOVE WNUM-OBJETO TO WFAI-OBJINI */
                _.Move(AREA_DE_WORK.WNUM_OBJETO, AREA_DE_WORK.WFAI_OBJINI);

                /*" -1188- MOVE WNUM-AMARRADO TO WFAI-AMRINI */
                _.Move(AREA_DE_WORK.WNUM_AMARRADO, AREA_DE_WORK.WFAI_AMRINI);

                /*" -1196- MOVE ZEROS TO WCONTROLE IND IND2 IND3 IND4 IND4 AUX1 */
                _.Move(0, AREA_DE_WORK.WCONTROLE, AREA_DE_WORK.IND, AREA_DE_WORK.IND2, AREA_DE_WORK.IND3, AREA_DE_WORK.IND4, AREA_DE_WORK.IND4, AREA_DE_WORK.AUX1);

                /*" -1197- MOVE SPACES TO WLINHA-AUX02 */
                _.Move("", WLINHA_AUX02);

                /*" -1199- MOVE SPACES TO WLINHA-AUX01 */
                _.Move("", WLINHA_AUX01);

                /*" -1200- MOVE ZEROS TO WFAIXA-OBJETOS */
                _.Move(0, AREA_DE_WORK.WFAIXA_OBJETOS);

                /*" -1201- MOVE SPACES TO WFLAG-QUEBRA */
                _.Move("", AREA_DE_WORK.WFLAG_QUEBRA);

                /*" -1202- MOVE SPACES TO CHAVE-TOLIGADO */
                _.Move("", AREA_DE_WORK.CHAVE_TOLIGADO);

                /*" -1203- MOVE ZEROS TO WQUANT-AMARRADO */
                _.Move(0, AREA_DE_WORK.WQUANT_AMARRADO);

                /*" -1207- PERFORM R1100-00-PROCESSA-CEP UNTIL ((WFLAG-QUEBRA NOT EQUAL SPACES) OR (WFIM-ARQCARTA EQUAL 'S' )) */

                while (!(((!AREA_DE_WORK.WFLAG_QUEBRA.IsEmpty()) || (AREA_DE_WORK.WFIM_ARQCARTA == "S"))))
                {

                    R1100_00_PROCESSA_CEP_SECTION();
                }

                /*" -1208- IF WCONTROLE EQUAL 1 */

                if (AREA_DE_WORK.WCONTROLE == 1)
                {

                    /*" -1209- WRITE RES-FC0038B1 FROM WLINHA-AUX01 */
                    _.Move(WLINHA_AUX01.GetMoveValues(), RES_FC0038B1);

                    RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

                    /*" -1212- END-IF */
                }


                /*" -1213- ADD 1 TO WCONT-AMARRADO */
                AREA_DE_WORK.WCONT_AMARRADO.Value = AREA_DE_WORK.WCONT_AMARRADO + 1;

                /*" -1215- ADD WCONT-AMARRADO TO WTOT-AMARRADO */
                AREA_DE_WORK.WTOT_AMARRADO.Value = AREA_DE_WORK.WTOT_AMARRADO + AREA_DE_WORK.WCONT_AMARRADO;

                /*" -1217- MOVE WTOT-CONTADOR TO WFAI-QTDOBJ */
                _.Move(AREA_DE_WORK.WTOT_CONTADOR, AREA_DE_WORK.WFAI_QTDOBJ);

                /*" -1218- MOVE WCONT-AMARRADO TO WFAI-QTDAMR */
                _.Move(AREA_DE_WORK.WCONT_AMARRADO, AREA_DE_WORK.WFAI_QTDAMR);

                /*" -1219- MOVE WTOT-AMARRADO TO WFAI-AMRFIM */
                _.Move(AREA_DE_WORK.WTOT_AMARRADO, AREA_DE_WORK.WFAI_AMRFIM);

                /*" -1220- PERFORM R2100-00-IMPRIME-AMARRADO */

                R2100_00_IMPRIME_AMARRADO_SECTION();

                /*" -1222- MOVE 1 TO WCONT-CONTADOR */
                _.Move(1, AREA_DE_WORK.WCONT_CONTADOR);

                /*" -1223- COMPUTE WNUM-AMARRADO = WFAI-AMRFIM + 1 */
                AREA_DE_WORK.WNUM_AMARRADO.Value = AREA_DE_WORK.WFAI_AMRFIM + 1;

                /*" -1225- MOVE ZEROS TO WCONT-AMARRADO */
                _.Move(0, AREA_DE_WORK.WCONT_AMARRADO);

                /*" -1225- PERFORM R3000-00-TOTALIZA-FAIXA. */

                R3000_00_TOTALIZA_FAIXA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-CEP-SECTION */
        private void R1100_00_PROCESSA_CEP_SECTION()
        {
            /*" -1240- ADD 1 TO WCONT-CONTADOR WTOT-CONTADOR. */
            AREA_DE_WORK.WCONT_CONTADOR.Value = AREA_DE_WORK.WCONT_CONTADOR + 1;
            AREA_DE_WORK.WTOT_CONTADOR.Value = AREA_DE_WORK.WTOT_CONTADOR + 1;

            /*" -1241- IF WCONT-CONTADOR GREATER 200 */

            if (AREA_DE_WORK.WCONT_CONTADOR > 200)
            {

                /*" -1242- ADD 1 TO WQUANT-AMARRADO */
                AREA_DE_WORK.WQUANT_AMARRADO.Value = AREA_DE_WORK.WQUANT_AMARRADO + 1;

                /*" -1244- COMPUTE WCONT-CONTADOR = WCONT-CONTADOR - 1 */
                AREA_DE_WORK.WCONT_CONTADOR.Value = AREA_DE_WORK.WCONT_CONTADOR - 1;

                /*" -1245- MOVE WCONT-CONTADOR TO WFAI-QTDOBJ */
                _.Move(AREA_DE_WORK.WCONT_CONTADOR, AREA_DE_WORK.WFAI_QTDOBJ);

                /*" -1246- ADD 1 TO WCONT-AMARRADO */
                AREA_DE_WORK.WCONT_AMARRADO.Value = AREA_DE_WORK.WCONT_AMARRADO + 1;

                /*" -1248- COMPUTE WFAI-AMRFIM = WTOT-AMARRADO + WCONT-AMARRADO */
                AREA_DE_WORK.WFAI_AMRFIM.Value = AREA_DE_WORK.WTOT_AMARRADO + AREA_DE_WORK.WCONT_AMARRADO;

                /*" -1249- PERFORM R2100-00-IMPRIME-AMARRADO */

                R2100_00_IMPRIME_AMARRADO_SECTION();

                /*" -1251- MOVE 1 TO WCONT-CONTADOR. */
                _.Move(1, AREA_DE_WORK.WCONT_CONTADOR);
            }


            /*" -1252- MOVE REG-CONTADOR TO WANT-REGISTRO */
            _.Move(REG_ARQCARTA.REG_CONTADOR, AREA_DE_WORK.WANT_REGISTRO);

            /*" -1254- MOVE WNUM-OBJETO TO WFAI-OBJFIM. */
            _.Move(AREA_DE_WORK.WNUM_OBJETO, AREA_DE_WORK.WFAI_OBJFIM);

            /*" -1259- PERFORM R1200-00-IMPRIME UNTIL ((REG-CONTADOR NOT EQUAL WANT-REGISTRO) OR (WFLAG-QUEBRA NOT EQUAL SPACES) OR (WFIM-ARQCARTA NOT EQUAL SPACES)). */

            while (!(((REG_ARQCARTA.REG_CONTADOR != AREA_DE_WORK.WANT_REGISTRO) || (!AREA_DE_WORK.WFLAG_QUEBRA.IsEmpty()) || (!AREA_DE_WORK.WFIM_ARQCARTA.IsEmpty()))))
            {

                R1200_00_IMPRIME_SECTION();
            }

            /*" -1260- ADD 1 TO WNUM-OBJETO. */
            AREA_DE_WORK.WNUM_OBJETO.Value = AREA_DE_WORK.WNUM_OBJETO + 1;

            /*" -1261- ADD 1 TO WFAIXA-OBJETOS. */
            AREA_DE_WORK.WFAIXA_OBJETOS.Value = AREA_DE_WORK.WFAIXA_OBJETOS + 1;

            /*" -1262- IF REG-NUMCEP NOT GREATER WFAI-CEPFIM */

            if (REG_ARQCARTA.REG_NUMCEP <= AREA_DE_WORK.WFAI_CEPFIM)
            {

                /*" -1264- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1264- MOVE SPACES TO WCHAVE-LEITURA. */
            _.Move("", AREA_DE_WORK.WCHAVE_LEITURA);

            /*" -0- FLUXCONTROL_PERFORM R1100_10_LOOP */

            R1100_10_LOOP();

        }

        [StopWatch]
        /*" R1100-10-LOOP */
        private void R1100_10_LOOP(bool isPerform = false)
        {
            /*" -1269- MOVE ' ' TO WTAB-PESQUISA */
            _.Move(" ", AREA_DE_WORK.WTAB_PESQUISA);

            /*" -1270- IF WCHAVE-LEITURA EQUAL SPACES */

            if (AREA_DE_WORK.WCHAVE_LEITURA.IsEmpty())
            {

                /*" -1272- MOVE WTAB-IND TO WTAB-IND2. */
                _.Move(AREA_DE_WORK.WTAB_IND, AREA_DE_WORK.WTAB_IND2);
            }


            /*" -1273- MOVE 1 TO WTAB-IND */
            _.Move(1, AREA_DE_WORK.WTAB_IND);

            /*" -1276- PERFORM R2000-00-PESQUISA-CEP UNTIL WTAB-PESQUISA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WTAB_PESQUISA.IsEmpty()))
            {

                R2000_00_PESQUISA_CEP_SECTION();
            }

            /*" -1277- IF WTAB-PESQUISA EQUAL 'N' */

            if (AREA_DE_WORK.WTAB_PESQUISA == "N")
            {

                /*" -1278- IF WCHAVE-LEITURA EQUAL SPACES */

                if (AREA_DE_WORK.WCHAVE_LEITURA.IsEmpty())
                {

                    /*" -1279- MOVE '*' TO WCHAVE-LEITURA */
                    _.Move("*", AREA_DE_WORK.WCHAVE_LEITURA);

                    /*" -1280- GO TO R1100-10-LOOP */
                    new Task(() => R1100_10_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1281- ELSE */
                }
                else
                {


                    /*" -1282- PERFORM R0900-00-LE-ARQCARTA */

                    R0900_00_LE_ARQCARTA_SECTION();

                    /*" -1294- GO TO R1100-10-LOOP. */
                    new Task(() => R1100_10_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1295- IF WFAIXA-OBJETOS LESS 30 */

            if (AREA_DE_WORK.WFAIXA_OBJETOS < 30)
            {

                /*" -1297- IF TAB-CENTRA(WTAB-IND) NOT EQUAL TAB-CENTRA(WTAB-IND2) */

                if (AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CENTRA != AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND2].TAB_CENTRA)
                {

                    /*" -1298- MOVE '3' TO WFLAG-QUEBRA */
                    _.Move("3", AREA_DE_WORK.WFLAG_QUEBRA);

                    /*" -1299- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1300- ELSE */
                }
                else
                {


                    /*" -1301- MOVE '*' TO CHAVE-TOLIGADO */
                    _.Move("*", AREA_DE_WORK.CHAVE_TOLIGADO);

                    /*" -1302- MOVE TAB-CEPFIM(WTAB-IND) TO WFAI-CEPFIM */
                    _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPFIM, AREA_DE_WORK.WFAI_CEPFIM);

                    /*" -1303- MOVE TAB-CENTRA(WTAB-IND) TO WFAI-CENTRALIZA */
                    _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CENTRA, AREA_DE_WORK.WFAI_CENTRALIZA);

                    /*" -1304- ELSE */
                }

            }
            else
            {


                /*" -1305- IF CHAVE-TOLIGADO EQUAL SPACES */

                if (AREA_DE_WORK.CHAVE_TOLIGADO.IsEmpty())
                {

                    /*" -1306- MOVE '2' TO WFLAG-QUEBRA */
                    _.Move("2", AREA_DE_WORK.WFLAG_QUEBRA);

                    /*" -1307- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1308- ELSE */
                }
                else
                {


                    /*" -1310- IF TAB-CENTRA(WTAB-IND) NOT EQUAL TAB-CENTRA(WTAB-IND2) */

                    if (AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CENTRA != AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND2].TAB_CENTRA)
                    {

                        /*" -1311- MOVE '3' TO WFLAG-QUEBRA */
                        _.Move("3", AREA_DE_WORK.WFLAG_QUEBRA);

                        /*" -1312- GO TO R1100-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                        return;

                        /*" -1313- ELSE */
                    }
                    else
                    {


                        /*" -1314- MOVE TAB-CEPFIM(WTAB-IND) TO WFAI-CEPFIM */
                        _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPFIM, AREA_DE_WORK.WFAI_CEPFIM);

                        /*" -1314- MOVE TAB-CENTRA(WTAB-IND) TO WFAI-CENTRALIZA. */
                        _.Move(AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CENTRA, AREA_DE_WORK.WFAI_CENTRALIZA);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-IMPRIME-SECTION */
        private void R1200_00_IMPRIME_SECTION()
        {
            /*" -1326- IF REG-NUMCEP EQUAL 99999999 */

            if (REG_ARQCARTA.REG_NUMCEP == 99999999)
            {

                /*" -1327- COMPUTE WTOT-CONTADOR = WTOT-CONTADOR - 1 */
                AREA_DE_WORK.WTOT_CONTADOR.Value = AREA_DE_WORK.WTOT_CONTADOR - 1;

                /*" -1328- COMPUTE WNUM-OBJETO = WNUM-OBJETO - 1 */
                AREA_DE_WORK.WNUM_OBJETO.Value = AREA_DE_WORK.WNUM_OBJETO - 1;

                /*" -1329- COMPUTE WFAI-OBJFIM = WFAI-OBJFIM - 1 */
                AREA_DE_WORK.WFAI_OBJFIM.Value = AREA_DE_WORK.WFAI_OBJFIM - 1;

                /*" -1331- GO TO R1200-90-LER. */

                R1200_90_LER(); //GOTO
                return;
            }


            /*" -1332- ADD 1 TO WCONTROLE. */
            AREA_DE_WORK.WCONTROLE.Value = AREA_DE_WORK.WCONTROLE + 1;

            /*" -1334- MOVE 'S' TO WOK. */
            _.Move("S", AREA_DE_WORK.WOK);

            /*" -1335- IF WCONTROLE EQUAL 1 */

            if (AREA_DE_WORK.WCONTROLE == 1)
            {

                /*" -1336- MOVE SPACES TO WLINHA-AUX01 */
                _.Move("", WLINHA_AUX01);

                /*" -1337- MOVE REG-LINHA TO WLINHA-AUX01 */
                _.Move(REG_ARQCARTA.REG_LINHA, WLINHA_AUX01);

                /*" -1338- MOVE ZEROS TO IND */
                _.Move(0, AREA_DE_WORK.IND);

                /*" -1339- PERFORM R1300-00-POSICIONA-DT-POSTAGEM */

                R1300_00_POSICIONA_DT_POSTAGEM_SECTION();

                /*" -1340- IF WOK EQUAL 'A' */

                if (AREA_DE_WORK.WOK == "A")
                {

                    /*" -1341- MOVE ZEROS TO WFAI-CEPFIM */
                    _.Move(0, AREA_DE_WORK.WFAI_CEPFIM);

                    /*" -1342- MOVE 999999 TO WANT-REGISTRO */
                    _.Move(999999, AREA_DE_WORK.WANT_REGISTRO);

                    /*" -1343- MOVE 'S' TO WFIM-ARQCARTA */
                    _.Move("S", AREA_DE_WORK.WFIM_ARQCARTA);

                    /*" -1344- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -1345- END-IF */
                }


                /*" -1346- COMPUTE IND3 = (WREG-INICIO-VERSO - 19) */
                AREA_DE_WORK.IND3.Value = (AREA_DE_WORK.WREG_INICIO_VERSO - 19);

                /*" -1347- COMPUTE IND2 = (IND3 / 2) + 1 */
                AREA_DE_WORK.IND2.Value = (AREA_DE_WORK.IND3 / 2) + 1;

                /*" -1348- MOVE 3482 TO IND */
                _.Move(3482, AREA_DE_WORK.IND);

                /*" -1349- PERFORM R1400-00-POSICIONA-CEP */

                R1400_00_POSICIONA_CEP_SECTION();

                /*" -1350- IF WOK EQUAL 'B' */

                if (AREA_DE_WORK.WOK == "B")
                {

                    /*" -1351- MOVE SPACES TO WOK */
                    _.Move("", AREA_DE_WORK.WOK);

                    /*" -1352- MOVE 3482 TO IND */
                    _.Move(3482, AREA_DE_WORK.IND);

                    /*" -1353- PERFORM R1450-00-POSICIONA-CEP */

                    R1450_00_POSICIONA_CEP_SECTION();

                    /*" -1354- IF WOK EQUAL 'B' */

                    if (AREA_DE_WORK.WOK == "B")
                    {

                        /*" -1355- MOVE ZEROS TO WFAI-CEPFIM */
                        _.Move(0, AREA_DE_WORK.WFAI_CEPFIM);

                        /*" -1356- MOVE 999999 TO WANT-REGISTRO */
                        _.Move(999999, AREA_DE_WORK.WANT_REGISTRO);

                        /*" -1357- MOVE 'S' TO WFIM-ARQCARTA */
                        _.Move("S", AREA_DE_WORK.WFIM_ARQCARTA);

                        /*" -1358- GO TO R1200-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                        return;

                        /*" -1359- END-IF */
                    }


                    /*" -1360- END-IF */
                }


                /*" -1361- COMPUTE IND4 = IND + 10 */
                AREA_DE_WORK.IND4.Value = AREA_DE_WORK.IND + 10;

                /*" -1362- ELSE */
            }
            else
            {


                /*" -1363- MOVE SPACES TO WLINHA-AUX02 */
                _.Move("", WLINHA_AUX02);

                /*" -1364- MOVE REG-LINHA TO WLINHA-AUX02 */
                _.Move(REG_ARQCARTA.REG_LINHA, WLINHA_AUX02);

                /*" -1365- MOVE ZEROS TO IND */
                _.Move(0, AREA_DE_WORK.IND);

                /*" -1366- MOVE ZEROS TO IND5 */
                _.Move(0, AREA_DE_WORK.IND5);

                /*" -1367- PERFORM R1500-00-MONTA-FRENTE-ESQUERDA */

                R1500_00_MONTA_FRENTE_ESQUERDA_SECTION();

                /*" -1368- COMPUTE IND5 = IND4 - 1 */
                AREA_DE_WORK.IND5.Value = AREA_DE_WORK.IND4 - 1;

                /*" -1369- COMPUTE IND4 = IND4 - 1 */
                AREA_DE_WORK.IND4.Value = AREA_DE_WORK.IND4 - 1;

                /*" -1370- PERFORM R1600-00-MONTA-VERSO-ESQUERDO */

                R1600_00_MONTA_VERSO_ESQUERDO_SECTION();

                /*" -1371- MOVE 3482 TO IND */
                _.Move(3482, AREA_DE_WORK.IND);

                /*" -1372- PERFORM R1700-00-ATUALIZA-DATA */

                R1700_00_ATUALIZA_DATA_SECTION();

                /*" -1373- IF WOK EQUAL 'C' */

                if (AREA_DE_WORK.WOK == "C")
                {

                    /*" -1374- MOVE ZEROS TO WFAI-CEPFIM */
                    _.Move(0, AREA_DE_WORK.WFAI_CEPFIM);

                    /*" -1375- MOVE 999999 TO WANT-REGISTRO */
                    _.Move(999999, AREA_DE_WORK.WANT_REGISTRO);

                    /*" -1376- MOVE 'S' TO WFIM-ARQCARTA */
                    _.Move("S", AREA_DE_WORK.WFIM_ARQCARTA);

                    /*" -1377- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -1378- END-IF */
                }


                /*" -1379- WRITE RES-FC0038B1 FROM WLINHA-AUX01 */
                _.Move(WLINHA_AUX01.GetMoveValues(), RES_FC0038B1);

                RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

                /*" -1381- MOVE ZERO TO WCONTROLE. */
                _.Move(0, AREA_DE_WORK.WCONTROLE);
            }


            /*" -1381- ADD 1 TO AC-I-ARQCARTA. */
            AREA_DE_WORK.AC_I_ARQCARTA.Value = AREA_DE_WORK.AC_I_ARQCARTA + 1;

            /*" -0- FLUXCONTROL_PERFORM R1200_90_LER */

            R1200_90_LER();

        }

        [StopWatch]
        /*" R1200-90-LER */
        private void R1200_90_LER(bool isPerform = false)
        {
            /*" -1385- PERFORM R0900-00-LE-ARQCARTA. */

            R0900_00_LE_ARQCARTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-POSICIONA-DT-POSTAGEM-SECTION */
        private void R1300_00_POSICIONA_DT_POSTAGEM_SECTION()
        {
            /*" -1399- ADD 1 TO IND. */
            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

            /*" -1400- IF IND GREATER 3482 */

            if (AREA_DE_WORK.IND > 3482)
            {

                /*" -1401- MOVE 'A' TO WOK */
                _.Move("A", AREA_DE_WORK.WOK);

                /*" -1403- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1404- IF WLINHA-AUX-01(IND) NOT EQUAL 'X' */

            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != "X")
            {

                /*" -1405- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1407- ELSE */
            }
            else
            {


                /*" -1409- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                {

                    /*" -1410- ADD 1 TO IND */
                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                    /*" -1412- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                    {

                        /*" -1413- ADD 1 TO IND */
                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                        /*" -1414- IF WLINHA-AUX-01(IND) EQUAL '/' */

                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "/")
                        {

                            /*" -1415- ADD 1 TO IND */
                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                            /*" -1417- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                            {

                                /*" -1418- ADD 1 TO IND */
                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                /*" -1420- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                {

                                    /*" -1421- ADD 1 TO IND */
                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                    /*" -1422- IF WLINHA-AUX-01(IND) EQUAL '/' */

                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "/")
                                    {

                                        /*" -1423- ADD 1 TO IND */
                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                        /*" -1425- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                        {

                                            /*" -1426- ADD 1 TO IND */
                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                            /*" -1428- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                            {

                                                /*" -1429- ADD 1 TO IND */
                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                /*" -1431- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                {

                                                    /*" -1432- ADD 1 TO IND */
                                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                    /*" -1434- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                    {

                                                        /*" -1435- ADD 1 TO IND */
                                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                        /*" -1436- IF WLINHA-AUX-01(IND) EQUAL '|' */

                                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "|")
                                                        {

                                                            /*" -1437- ADD 1 TO IND */
                                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                            /*" -1439- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                            {

                                                                /*" -1440- ADD 1 TO IND */
                                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                                /*" -1442- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                {

                                                                    /*" -1443- ADD 1 TO IND */
                                                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                                    /*" -1445- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                    {

                                                                        /*" -1446- ADD 1 TO IND */
                                                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                                        /*" -1447- IF WLINHA-AUX-01(IND) EQUAL '.' */

                                                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == ".")
                                                                        {

                                                                            /*" -1448- ADD 1 TO IND */
                                                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                                            /*" -1450- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                            {

                                                                                /*" -1451- ADD 1 TO IND */
                                                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                                                /*" -1453- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                                {

                                                                                    /*" -1454- ADD 1 TO IND */
                                                                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                                                    /*" -1457- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' NEXT SENTENCE */

                                                                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                                    {

                                                                                        /*" -1458- ELSE */
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        /*" -1459- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                                        new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                                        return;//Recursividade detectada, cuidado...

                                                                                        /*" -1460- ELSE */
                                                                                    }

                                                                                }
                                                                                else
                                                                                {


                                                                                    /*" -1461- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                                    new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                                    return;//Recursividade detectada, cuidado...

                                                                                    /*" -1462- ELSE */
                                                                                }

                                                                            }
                                                                            else
                                                                            {


                                                                                /*" -1463- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                                new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                                return;//Recursividade detectada, cuidado...

                                                                                /*" -1464- ELSE */
                                                                            }

                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1465- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                            new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                            return;//Recursividade detectada, cuidado...

                                                                            /*" -1466- ELSE */
                                                                        }

                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1467- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                        new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                        return;//Recursividade detectada, cuidado...

                                                                        /*" -1468- ELSE */
                                                                    }

                                                                }
                                                                else
                                                                {


                                                                    /*" -1469- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                    new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                    return;//Recursividade detectada, cuidado...

                                                                    /*" -1470- ELSE */
                                                                }

                                                            }
                                                            else
                                                            {


                                                                /*" -1471- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                                new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                                return;//Recursividade detectada, cuidado...

                                                                /*" -1472- ELSE */
                                                            }

                                                        }
                                                        else
                                                        {


                                                            /*" -1473- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                            new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                            return;//Recursividade detectada, cuidado...

                                                            /*" -1474- ELSE */
                                                        }

                                                    }
                                                    else
                                                    {


                                                        /*" -1475- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                        new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                        return;//Recursividade detectada, cuidado...

                                                        /*" -1476- ELSE */
                                                    }

                                                }
                                                else
                                                {


                                                    /*" -1477- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                    new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                    return;//Recursividade detectada, cuidado...

                                                    /*" -1478- ELSE */
                                                }

                                            }
                                            else
                                            {


                                                /*" -1479- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                                new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                                return;//Recursividade detectada, cuidado...

                                                /*" -1480- ELSE */
                                            }

                                        }
                                        else
                                        {


                                            /*" -1481- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                            new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                            return;//Recursividade detectada, cuidado...

                                            /*" -1482- ELSE */
                                        }

                                    }
                                    else
                                    {


                                        /*" -1483- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                        new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                        return;//Recursividade detectada, cuidado...

                                        /*" -1484- ELSE */
                                    }

                                }
                                else
                                {


                                    /*" -1485- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                    new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1486- ELSE */
                                }

                            }
                            else
                            {


                                /*" -1487- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                                new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1488- ELSE */
                            }

                        }
                        else
                        {


                            /*" -1489- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                            new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -1490- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1491- GO TO R1300-00-POSICIONA-DT-POSTAGEM */
                        new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1492- ELSE */
                    }

                }
                else
                {


                    /*" -1492- GO TO R1300-00-POSICIONA-DT-POSTAGEM. */
                    new Task(() => R1300_00_POSICIONA_DT_POSTAGEM_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1300_10_ATUALIZA_DT_POSTAGEM */

            R1300_10_ATUALIZA_DT_POSTAGEM();

        }

        [StopWatch]
        /*" R1300-10-ATUALIZA-DT-POSTAGEM */
        private void R1300_10_ATUALIZA_DT_POSTAGEM(bool isPerform = false)
        {
            /*" -1499- COMPUTE AUX1 = IND - 17 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.IND - 17;

            /*" -1500- MOVE WNUM-OBJETO TO WNUM-OBJETO-E */
            _.Move(AREA_DE_WORK.WNUM_OBJETO, AREA_DE_WORK.WNUM_OBJETO_E);

            /*" -1501- MOVE WS-DTREFER TO WDATA-DTPROC */
            _.Move(AREA_DE_WORK.WS_DTREFER, AREA_DE_WORK.WDATA_DTPROC);

            /*" -1502- MOVE WDATA-DIAPROC2 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_DIAPROC.WDATA_DIAPROC2, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1503- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1504- MOVE WDATA-DIAPROC1 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_DIAPROC.WDATA_DIAPROC1, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1505- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1506- MOVE '/' TO WLINHA-AUX-01(AUX1) */
            _.Move("/", WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1507- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1508- MOVE WDATA-MESPROC2 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_MESPROC.WDATA_MESPROC2, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1509- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1510- MOVE WDATA-MESPROC1 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_MESPROC.WDATA_MESPROC1, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1511- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1512- MOVE '/' TO WLINHA-AUX-01(AUX1) */
            _.Move("/", WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1513- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1514- MOVE WDATA-ANOPROC4 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC4, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1515- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1516- MOVE WDATA-ANOPROC3 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC3, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1517- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1518- MOVE WDATA-ANOPROC2 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC2, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1519- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1520- MOVE WDATA-ANOPROC1 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC1, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1521- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1522- MOVE '|' TO WLINHA-AUX-01(AUX1) */
            _.Move("|", WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1523- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1524- MOVE WNUM-OBJETO-01 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_01, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1525- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1526- MOVE WNUM-OBJETO-02 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_02, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1527- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1528- MOVE WNUM-OBJETO-03 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_03, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1529- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1530- MOVE WNUM-OBJETO-04 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_04, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1531- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1532- MOVE WNUM-OBJETO-05 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_05, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1533- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1534- MOVE WNUM-OBJETO-06 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_06, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1535- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1535- MOVE WNUM-OBJETO-07 TO WLINHA-AUX-01(AUX1). */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_07, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-POSICIONA-CEP-SECTION */
        private void R1400_00_POSICIONA_CEP_SECTION()
        {
            /*" -1549- SUBTRACT 1 FROM IND. */
            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

            /*" -1550- IF IND EQUAL ZEROS */

            if (AREA_DE_WORK.IND == 00)
            {

                /*" -1551- MOVE 'B' TO WOK */
                _.Move("B", AREA_DE_WORK.WOK);

                /*" -1553- GO TO R1400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1554- IF WLINHA-AUX-01(IND) EQUAL SPACES */

            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == string.Empty)
            {

                /*" -1555- GO TO R1400-00-POSICIONA-CEP */
                new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1556- ELSE */
            }
            else
            {


                /*" -1557- SUBTRACT 1 FROM IND */
                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                /*" -1558- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                {

                    /*" -1559- SUBTRACT 1 FROM IND */
                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                    /*" -1560- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                    {

                        /*" -1561- SUBTRACT 1 FROM IND */
                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                        /*" -1562- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                        {

                            /*" -1563- SUBTRACT 1 FROM IND */
                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                            /*" -1564- IF WLINHA-AUX-01(IND) EQUAL '-' */

                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "-")
                            {

                                /*" -1565- SUBTRACT 1 FROM IND */
                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                /*" -1566- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                {

                                    /*" -1567- SUBTRACT 1 FROM IND */
                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                    /*" -1568- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                    {

                                        /*" -1569- SUBTRACT 1 FROM IND */
                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                        /*" -1570- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                        {

                                            /*" -1571- SUBTRACT 1 FROM IND */
                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                            /*" -1572- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                            {

                                                /*" -1573- SUBTRACT 1 FROM IND */
                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                /*" -1575- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES NEXT SENTENCE */

                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                                {

                                                    /*" -1576- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1577- GO TO R1400-00-POSICIONA-CEP */
                                                    new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                                    return;//Recursividade detectada, cuidado...

                                                    /*" -1578- ELSE */
                                                }

                                            }
                                            else
                                            {


                                                /*" -1579- GO TO R1400-00-POSICIONA-CEP */
                                                new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                                return;//Recursividade detectada, cuidado...

                                                /*" -1580- ELSE */
                                            }

                                        }
                                        else
                                        {


                                            /*" -1581- GO TO R1400-00-POSICIONA-CEP */
                                            new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                            return;//Recursividade detectada, cuidado...

                                            /*" -1582- ELSE */
                                        }

                                    }
                                    else
                                    {


                                        /*" -1583- GO TO R1400-00-POSICIONA-CEP */
                                        new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                        return;//Recursividade detectada, cuidado...

                                        /*" -1584- ELSE */
                                    }

                                }
                                else
                                {


                                    /*" -1585- GO TO R1400-00-POSICIONA-CEP */
                                    new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1586- ELSE */
                                }

                            }
                            else
                            {


                                /*" -1587- GO TO R1400-00-POSICIONA-CEP */
                                new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1588- ELSE */
                            }

                        }
                        else
                        {


                            /*" -1589- GO TO R1400-00-POSICIONA-CEP */
                            new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -1590- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1591- GO TO R1400-00-POSICIONA-CEP */
                        new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1592- ELSE */
                    }

                }
                else
                {


                    /*" -1592- GO TO R1400-00-POSICIONA-CEP. */
                    new Task(() => R1400_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-POSICIONA-CEP-SECTION */
        private void R1450_00_POSICIONA_CEP_SECTION()
        {
            /*" -1606- SUBTRACT 1 FROM IND. */
            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

            /*" -1607- IF IND GREATER 3482 */

            if (AREA_DE_WORK.IND > 3482)
            {

                /*" -1608- MOVE 'B' TO WOK */
                _.Move("B", AREA_DE_WORK.WOK);

                /*" -1610- GO TO R1450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1611- IF WLINHA-AUX-01(IND) EQUAL SPACES */

            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == string.Empty)
            {

                /*" -1612- GO TO R1450-00-POSICIONA-CEP */
                new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1613- ELSE */
            }
            else
            {


                /*" -1614- ADD 1 TO IND */
                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                /*" -1615- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                {

                    /*" -1616- ADD 1 TO IND */
                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                    /*" -1617- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                    {

                        /*" -1618- ADD 1 TO IND */
                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                        /*" -1619- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                        {

                            /*" -1620- ADD 1 TO IND */
                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                            /*" -1621- IF WLINHA-AUX-01(IND) EQUAL '-' */

                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "-")
                            {

                                /*" -1622- ADD 1 TO IND */
                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                /*" -1623- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                {

                                    /*" -1624- ADD 1 TO IND */
                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                    /*" -1625- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                    {

                                        /*" -1626- ADD 1 TO IND */
                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                        /*" -1627- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                        {

                                            /*" -1628- ADD 1 TO IND */
                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                            /*" -1629- IF WLINHA-AUX-01(IND) EQUAL '.' */

                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == ".")
                                            {

                                                /*" -1630- ADD 1 TO IND */
                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                /*" -1631- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES */

                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                                {

                                                    /*" -1632- ADD 1 TO IND */
                                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

                                                    /*" -1634- IF WLINHA-AUX-01(IND) NOT EQUAL SPACES NEXT SENTENCE */

                                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != string.Empty)
                                                    {

                                                        /*" -1635- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1636- GO TO R1450-00-POSICIONA-CEP */
                                                        new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                                        return;//Recursividade detectada, cuidado...

                                                        /*" -1637- ELSE */
                                                    }

                                                }
                                                else
                                                {


                                                    /*" -1638- GO TO R1450-00-POSICIONA-CEP */
                                                    new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                                    return;//Recursividade detectada, cuidado...

                                                    /*" -1639- ELSE */
                                                }

                                            }
                                            else
                                            {


                                                /*" -1640- GO TO R1450-00-POSICIONA-CEP */
                                                new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                                return;//Recursividade detectada, cuidado...

                                                /*" -1641- ELSE */
                                            }

                                        }
                                        else
                                        {


                                            /*" -1642- GO TO R1450-00-POSICIONA-CEP */
                                            new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                            return;//Recursividade detectada, cuidado...

                                            /*" -1643- ELSE */
                                        }

                                    }
                                    else
                                    {


                                        /*" -1644- GO TO R1450-00-POSICIONA-CEP */
                                        new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                        return;//Recursividade detectada, cuidado...

                                        /*" -1645- ELSE */
                                    }

                                }
                                else
                                {


                                    /*" -1646- GO TO R1450-00-POSICIONA-CEP */
                                    new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1647- ELSE */
                                }

                            }
                            else
                            {


                                /*" -1648- GO TO R1450-00-POSICIONA-CEP */
                                new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1649- ELSE */
                            }

                        }
                        else
                        {


                            /*" -1650- GO TO R1450-00-POSICIONA-CEP */
                            new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -1651- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1651- GO TO R1450-00-POSICIONA-CEP. */
                        new Task(() => R1450_00_POSICIONA_CEP_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-MONTA-FRENTE-ESQUERDA-SECTION */
        private void R1500_00_MONTA_FRENTE_ESQUERDA_SECTION()
        {
            /*" -1665- ADD 1 TO IND. */
            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND + 1;

            /*" -1667- IF IND LESS IND2 NEXT SENTENCE */

            if (AREA_DE_WORK.IND < AREA_DE_WORK.IND2)
            {

                /*" -1668- ELSE */
            }
            else
            {


                /*" -1669- IF IND GREATER IND3 */

                if (AREA_DE_WORK.IND > AREA_DE_WORK.IND3)
                {

                    /*" -1670- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -1671- ELSE */
                }
                else
                {


                    /*" -1672- ADD 1 TO IND5 */
                    AREA_DE_WORK.IND5.Value = AREA_DE_WORK.IND5 + 1;

                    /*" -1673- MOVE WLINHA-AUX-02(IND5) TO WLINHA-AUX-01(IND) */
                    _.Move(WLINHA_AUX02.WLINHA_AUX_02[AREA_DE_WORK.IND5], WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND]);

                    /*" -1674- END-IF */
                }


                /*" -1676- END-IF. */
            }


            /*" -1676- GO TO R1500-00-MONTA-FRENTE-ESQUERDA. */
            new Task(() => R1500_00_MONTA_FRENTE_ESQUERDA_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-MONTA-VERSO-ESQUERDO-SECTION */
        private void R1600_00_MONTA_VERSO_ESQUERDO_SECTION()
        {
            /*" -1691- ADD 1 TO IND3 IND4. */
            AREA_DE_WORK.IND3.Value = AREA_DE_WORK.IND3 + 1;
            AREA_DE_WORK.IND4.Value = AREA_DE_WORK.IND4 + 1;

            /*" -1692- IF IND3 NOT LESS IND5 */

            if (AREA_DE_WORK.IND3 >= AREA_DE_WORK.IND5)
            {

                /*" -1693- GO TO R1600-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                return;

                /*" -1694- ELSE */
            }
            else
            {


                /*" -1695- MOVE WLINHA-AUX-02(IND3) TO WLINHA-AUX-01(IND4) */
                _.Move(WLINHA_AUX02.WLINHA_AUX_02[AREA_DE_WORK.IND3], WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND4]);

                /*" -1697- END-IF. */
            }


            /*" -1697- GO TO R1600-00-MONTA-VERSO-ESQUERDO. */
            new Task(() => R1600_00_MONTA_VERSO_ESQUERDO_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-ATUALIZA-DATA-SECTION */
        private void R1700_00_ATUALIZA_DATA_SECTION()
        {
            /*" -1708- SUBTRACT 1 FROM IND. */
            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

            /*" -1709- IF IND EQUAL ZEROS */

            if (AREA_DE_WORK.IND == 00)
            {

                /*" -1710- MOVE 'C' TO WOK */
                _.Move("C", AREA_DE_WORK.WOK);

                /*" -1712- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1713- IF WLINHA-AUX-01(IND) EQUAL SPACES */

            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == string.Empty)
            {

                /*" -1714- GO TO R1700-00-ATUALIZA-DATA */
                new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1715- ELSE */
            }
            else
            {


                /*" -1716- IF WLINHA-AUX-01(IND) NOT EQUAL '.' */

                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] != ".")
                {

                    /*" -1717- GO TO R1700-00-ATUALIZA-DATA */
                    new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1718- ELSE */
                }
                else
                {


                    /*" -1719- SUBTRACT 1 FROM IND */
                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                    /*" -1721- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                    {

                        /*" -1722- SUBTRACT 1 FROM IND */
                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                        /*" -1724- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                        {

                            /*" -1725- SUBTRACT 1 FROM IND */
                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                            /*" -1727- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                            {

                                /*" -1728- SUBTRACT 1 FROM IND */
                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                /*" -1729- IF WLINHA-AUX-01(IND) EQUAL '|' */

                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "|")
                                {

                                    /*" -1730- SUBTRACT 1 FROM IND */
                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                    /*" -1732- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                    {

                                        /*" -1733- SUBTRACT 1 FROM IND */
                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                        /*" -1735- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                        {

                                            /*" -1736- SUBTRACT 1 FROM IND */
                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                            /*" -1738- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                            {

                                                /*" -1739- SUBTRACT 1 FROM IND */
                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                /*" -1741- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                {

                                                    /*" -1742- SUBTRACT 1 FROM IND */
                                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                    /*" -1743- IF WLINHA-AUX-01(IND) EQUAL '/' */

                                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "/")
                                                    {

                                                        /*" -1744- SUBTRACT 1 FROM IND */
                                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                        /*" -1746- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                        {

                                                            /*" -1747- SUBTRACT 1 FROM IND */
                                                            AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                            /*" -1749- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                            if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                            {

                                                                /*" -1750- SUBTRACT 1 FROM IND */
                                                                AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                                /*" -1751- IF WLINHA-AUX-01(IND) EQUAL '/' */

                                                                if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "/")
                                                                {

                                                                    /*" -1752- SUBTRACT 1 FROM IND */
                                                                    AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                                    /*" -1754- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' */

                                                                    if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                    {

                                                                        /*" -1755- SUBTRACT 1 FROM IND */
                                                                        AREA_DE_WORK.IND.Value = AREA_DE_WORK.IND - 1;

                                                                        /*" -1758- IF WLINHA-AUX-01(IND) EQUAL 'X' OR WLINHA-AUX-01(IND) EQUAL 'x' NEXT SENTENCE */

                                                                        if (WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "X" || WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.IND] == "x")
                                                                        {

                                                                            /*" -1759- ELSE */
                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1760- GO TO R1700-00-ATUALIZA-DATA */
                                                                            new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                                            return;//Recursividade detectada, cuidado...

                                                                            /*" -1761- ELSE */
                                                                        }

                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1762- GO TO R1700-00-ATUALIZA-DATA */
                                                                        new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                                        return;//Recursividade detectada, cuidado...

                                                                        /*" -1763- ELSE */
                                                                    }

                                                                }
                                                                else
                                                                {


                                                                    /*" -1764- GO TO R1700-00-ATUALIZA-DATA */
                                                                    new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                                    return;//Recursividade detectada, cuidado...

                                                                    /*" -1765- ELSE */
                                                                }

                                                            }
                                                            else
                                                            {


                                                                /*" -1766- GO TO R1700-00-ATUALIZA-DATA */
                                                                new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                                return;//Recursividade detectada, cuidado...

                                                                /*" -1767- ELSE */
                                                            }

                                                        }
                                                        else
                                                        {


                                                            /*" -1768- GO TO R1700-00-ATUALIZA-DATA */
                                                            new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                            return;//Recursividade detectada, cuidado...

                                                            /*" -1769- ELSE */
                                                        }

                                                    }
                                                    else
                                                    {


                                                        /*" -1770- GO TO R1700-00-ATUALIZA-DATA */
                                                        new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                        return;//Recursividade detectada, cuidado...

                                                        /*" -1771- ELSE */
                                                    }

                                                }
                                                else
                                                {


                                                    /*" -1772- GO TO R1700-00-ATUALIZA-DATA */
                                                    new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                    return;//Recursividade detectada, cuidado...

                                                    /*" -1773- ELSE */
                                                }

                                            }
                                            else
                                            {


                                                /*" -1774- GO TO R1700-00-ATUALIZA-DATA */
                                                new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                                return;//Recursividade detectada, cuidado...

                                                /*" -1775- ELSE */
                                            }

                                        }
                                        else
                                        {


                                            /*" -1776- GO TO R1700-00-ATUALIZA-DATA */
                                            new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                            return;//Recursividade detectada, cuidado...

                                            /*" -1777- ELSE */
                                        }

                                    }
                                    else
                                    {


                                        /*" -1778- GO TO R1700-00-ATUALIZA-DATA */
                                        new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                        return;//Recursividade detectada, cuidado...

                                        /*" -1779- ELSE */
                                    }

                                }
                                else
                                {


                                    /*" -1780- GO TO R1700-00-ATUALIZA-DATA */
                                    new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                    return;//Recursividade detectada, cuidado...

                                    /*" -1781- ELSE */
                                }

                            }
                            else
                            {


                                /*" -1782- GO TO R1700-00-ATUALIZA-DATA */
                                new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                                return;//Recursividade detectada, cuidado...

                                /*" -1783- ELSE */
                            }

                        }
                        else
                        {


                            /*" -1784- GO TO R1700-00-ATUALIZA-DATA */
                            new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -1785- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1785- GO TO R1700-00-ATUALIZA-DATA. */
                        new Task(() => R1700_00_ATUALIZA_DATA_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1700_10_ATUALIZA_DATA */

            R1700_10_ATUALIZA_DATA();

        }

        [StopWatch]
        /*" R1700-10-ATUALIZA-DATA */
        private void R1700_10_ATUALIZA_DATA(bool isPerform = false)
        {
            /*" -1792- MOVE IND TO AUX1 */
            _.Move(AREA_DE_WORK.IND, AREA_DE_WORK.AUX1);

            /*" -1793- MOVE WNUM-OBJETO TO WNUM-OBJETO-E */
            _.Move(AREA_DE_WORK.WNUM_OBJETO, AREA_DE_WORK.WNUM_OBJETO_E);

            /*" -1794- MOVE WS-DTREFER TO WDATA-DTPROC */
            _.Move(AREA_DE_WORK.WS_DTREFER, AREA_DE_WORK.WDATA_DTPROC);

            /*" -1795- MOVE WDATA-DIAPROC2 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_DIAPROC.WDATA_DIAPROC2, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1796- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1797- MOVE WDATA-DIAPROC1 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_DIAPROC.WDATA_DIAPROC1, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1798- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1799- MOVE '/' TO WLINHA-AUX-01(AUX1) */
            _.Move("/", WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1800- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1801- MOVE WDATA-MESPROC2 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_MESPROC.WDATA_MESPROC2, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1802- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1803- MOVE WDATA-MESPROC1 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_MESPROC.WDATA_MESPROC1, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1804- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1805- MOVE '/' TO WLINHA-AUX-01(AUX1) */
            _.Move("/", WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1806- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1807- MOVE WDATA-ANOPROC4 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC4, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1808- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1809- MOVE WDATA-ANOPROC3 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC3, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1810- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1811- MOVE WDATA-ANOPROC2 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC2, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1812- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1813- MOVE WDATA-ANOPROC1 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC.WDATA_ANOPROC1, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1814- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1815- MOVE '|' TO WLINHA-AUX-01(AUX1) */
            _.Move("|", WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1816- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1817- MOVE WNUM-OBJETO-01 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_01, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1818- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1819- MOVE WNUM-OBJETO-02 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_02, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1820- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1821- MOVE WNUM-OBJETO-03 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_03, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1822- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1823- MOVE WNUM-OBJETO-04 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_04, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1824- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1825- MOVE WNUM-OBJETO-05 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_05, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1826- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1827- MOVE WNUM-OBJETO-06 TO WLINHA-AUX-01(AUX1) */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_06, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

            /*" -1828- ADD 1 TO AUX1 */
            AREA_DE_WORK.AUX1.Value = AREA_DE_WORK.AUX1 + 1;

            /*" -1828- MOVE WNUM-OBJETO-07 TO WLINHA-AUX-01(AUX1). */
            _.Move(AREA_DE_WORK.WNUM_OBJETO_ER.WNUM_OBJETO_07, WLINHA_AUX01.WLINHA_AUX_01[AREA_DE_WORK.AUX1]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PESQUISA-CEP-SECTION */
        private void R2000_00_PESQUISA_CEP_SECTION()
        {
            /*" -1841- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND.WNR_EXEC_SQL);

            /*" -1844- IF REG-NUMCEP GREATER ZEROS AND (REG-NUMCEP NOT LESS TAB-CEPINI(WTAB-IND) AND REG-NUMCEP NOT GREATER TAB-CEPFIM(WTAB-IND)) */

            if (REG_ARQCARTA.REG_NUMCEP > 00 && (REG_ARQCARTA.REG_NUMCEP >= AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPINI && REG_ARQCARTA.REG_NUMCEP <= AREA_DE_WORK.FAIXAS_CEP.FAIXA_CEP[AREA_DE_WORK.WTAB_IND].TAB_CEPFIM))
            {

                /*" -1845- MOVE 'S' TO WTAB-PESQUISA */
                _.Move("S", AREA_DE_WORK.WTAB_PESQUISA);

                /*" -1846- ELSE */
            }
            else
            {


                /*" -1847- ADD 1 TO WTAB-IND */
                AREA_DE_WORK.WTAB_IND.Value = AREA_DE_WORK.WTAB_IND + 1;

                /*" -1848- IF WTAB-IND GREATER WTAB-QTDREG */

                if (AREA_DE_WORK.WTAB_IND > AREA_DE_WORK.WTAB_QTDREG)
                {

                    /*" -1849- DISPLAY 'FAIXA DE CEP NAO ENCONTRADA' */
                    _.Display($"FAIXA DE CEP NAO ENCONTRADA");

                    /*" -1851- DISPLAY 'REGISTRO = ' REG-CONTADOR ' CEP = ' REG-NUMCEP */

                    $"REGISTRO = {REG_ARQCARTA.REG_CONTADOR} CEP = {REG_ARQCARTA.REG_NUMCEP}"
                    .Display();

                    /*" -1852- MOVE 'N' TO WTAB-PESQUISA */
                    _.Move("N", AREA_DE_WORK.WTAB_PESQUISA);

                    /*" -1853- MOVE REG-ARQCARTA TO REG-CEPERROS */
                    _.Move(ARQCARTA?.Value, REG_CEPERROS);

                    /*" -1854- ADD 1 TO WCEPERRO */
                    AREA_DE_WORK.WCEPERRO.Value = AREA_DE_WORK.WCEPERRO + 1;

                    /*" -1854- WRITE REG-CEPERROS. */
                    CEPERROS.Write(REG_CEPERROS.GetMoveValues().ToString());
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-IMPRIME-AMARRADO-SECTION */
        private void R2100_00_IMPRIME_AMARRADO_SECTION()
        {
            /*" -1868- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -1870- WRITE RES-FC0038B1 FROM WLINHA05 */
            _.Move(AREA_DE_WORK.WLINHA05.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1871- WRITE RES-FC0038B1 FROM WLINHA06 */
            _.Move(AREA_DE_WORK.WLINHA06.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1872- WRITE RES-FC0038B1 FROM WLINHA22 */
            _.Move(AREA_DE_WORK.WLINHA22.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1873- WRITE RES-FC0038B1 FROM WLINHA07 */
            _.Move(AREA_DE_WORK.WLINHA07.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1874- WRITE RES-FC0038B1 FROM WLINHA08 */
            _.Move(AREA_DE_WORK.WLINHA08.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1876- WRITE RES-FC0038B1 FROM WLINHA09 */
            _.Move(AREA_DE_WORK.WLINHA09.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1877- MOVE SPACES TO RES-FC0038B1 */
            _.Move("", RES_FC0038B1);

            /*" -1879- MOVE SPACES TO LF01-LOCAL */
            _.Move("", LF01.LF01_LOCAL);

            /*" -1881- IF CHAVE-TOLIGADO EQUAL SPACES OR WFLAG-QUEBRA EQUAL '2' */

            if (AREA_DE_WORK.CHAVE_TOLIGADO.IsEmpty() || AREA_DE_WORK.WFLAG_QUEBRA == "2")
            {

                /*" -1882- MOVE WFAI-DESCRICAO TO LF01-LOCAL */
                _.Move(AREA_DE_WORK.WFAI_DESCRICAO, LF01.LF01_LOCAL);

                /*" -1883- ELSE */
            }
            else
            {


                /*" -1885- MOVE WFAI-CENTRALIZA TO LF01-LOCAL. */
                _.Move(AREA_DE_WORK.WFAI_CENTRALIZA, LF01.LF01_LOCAL);
            }


            /*" -1887- MOVE ZEROS TO LF01-CEPINI LF01-CEPFIM. */
            _.Move(0, LF01.LF01_CEPINI, LF01.LF01_CEPFIM);

            /*" -1888- MOVE WFAI-CEPINI TO WW01-NUMCEP. */
            _.Move(AREA_DE_WORK.WFAI_CEPINI, AREA_DE_WORK.WW01_NUMCEP);

            /*" -1889- MOVE WW01-NUMCEP-1 TO WREL-NUMCEP-1. */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_NUMCEP_1, AREA_DE_WORK.WREL_NUMCEP.WREL_NUMCEP_1);

            /*" -1890- MOVE WW01-COMPCEP TO WREL-COMPCEP. */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_COMPCEP, AREA_DE_WORK.WREL_NUMCEP.WREL_COMPCEP);

            /*" -1891- MOVE WREL-NUMCEP TO LF01-CEPINI. */
            _.Move(AREA_DE_WORK.WREL_NUMCEP, LF01.LF01_CEPINI);

            /*" -1892- MOVE WFAI-CEPFIM TO WW01-NUMCEP. */
            _.Move(AREA_DE_WORK.WFAI_CEPFIM, AREA_DE_WORK.WW01_NUMCEP);

            /*" -1893- MOVE WW01-NUMCEP-1 TO WREL-NUMCEP-1. */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_NUMCEP_1, AREA_DE_WORK.WREL_NUMCEP.WREL_NUMCEP_1);

            /*" -1894- MOVE WW01-COMPCEP TO WREL-COMPCEP. */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_COMPCEP, AREA_DE_WORK.WREL_NUMCEP.WREL_COMPCEP);

            /*" -1896- MOVE WREL-NUMCEP TO LF01-CEPFIM. */
            _.Move(AREA_DE_WORK.WREL_NUMCEP, LF01.LF01_CEPFIM);

            /*" -1897- MOVE ZEROS TO LF01-QTDOBJ */
            _.Move(0, LF01.LF01_QTDOBJ);

            /*" -1899- MOVE WFAI-QTDOBJ TO LF01-QTDOBJ. */
            _.Move(AREA_DE_WORK.WFAI_QTDOBJ, LF01.LF01_QTDOBJ);

            /*" -1902- MOVE ZEROS TO LF01-NUMAMR LF01-OBJINI LF01-OBJFIM. */
            _.Move(0, LF01.LF01_NUMAMR, LF01.LF01_OBJINI, LF01.LF01_OBJFIM);

            /*" -1903- MOVE WFAI-AMRFIM TO LF01-NUMAMR. */
            _.Move(AREA_DE_WORK.WFAI_AMRFIM, LF01.LF01_NUMAMR);

            /*" -1904- MOVE WFAI-OBJINI TO LF01-OBJINI. */
            _.Move(AREA_DE_WORK.WFAI_OBJINI, LF01.LF01_OBJINI);

            /*" -1906- MOVE WFAI-OBJFIM TO LF01-OBJFIM. */
            _.Move(AREA_DE_WORK.WFAI_OBJFIM, LF01.LF01_OBJFIM);

            /*" -1907- IF WQUANT-AMARRADO GREATER ZEROS */

            if (AREA_DE_WORK.WQUANT_AMARRADO > 00)
            {

                /*" -1908- MOVE ZEROS TO LF01-QTDOBJ */
                _.Move(0, LF01.LF01_QTDOBJ);

                /*" -1909- MOVE ZEROS TO LF01-OBJINI */
                _.Move(0, LF01.LF01_OBJINI);

                /*" -1910- MOVE ZEROS TO LF01-OBJFIM */
                _.Move(0, LF01.LF01_OBJFIM);

                /*" -1911- MOVE WCONT-CONTADOR TO LF01-QTDOBJ */
                _.Move(AREA_DE_WORK.WCONT_CONTADOR, LF01.LF01_QTDOBJ);

                /*" -1913- COMPUTE WCONT-CONTADOR = WNUM-OBJETO - WCONT-CONTADOR */
                AREA_DE_WORK.WCONT_CONTADOR.Value = AREA_DE_WORK.WNUM_OBJETO - AREA_DE_WORK.WCONT_CONTADOR;

                /*" -1914- MOVE WCONT-CONTADOR TO LF01-OBJINI */
                _.Move(AREA_DE_WORK.WCONT_CONTADOR, LF01.LF01_OBJINI);

                /*" -1916- COMPUTE WCONT-CONTADOR = WNUM-OBJETO - 1 */
                AREA_DE_WORK.WCONT_CONTADOR.Value = AREA_DE_WORK.WNUM_OBJETO - 1;

                /*" -1918- MOVE WCONT-CONTADOR TO LF01-OBJFIM. */
                _.Move(AREA_DE_WORK.WCONT_CONTADOR, LF01.LF01_OBJFIM);
            }


            /*" -1920- WRITE RES-FC0038B1 FROM LF01. */
            _.Move(LF01.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1922- WRITE RES-FC0038B1 FROM WLINHA05. */
            _.Move(AREA_DE_WORK.WLINHA05.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1923- MOVE SPACES TO RES-FC0038B1. */
            _.Move("", RES_FC0038B1);

            /*" -1925- WRITE RES-FC0038B1 FROM WLINHA012. */
            _.Move(AREA_DE_WORK.WLINHA01.WLINHA012.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1926- MOVE SPACES TO RES-FC0038B1. */
            _.Move("", RES_FC0038B1);

            /*" -1928- WRITE RES-FC0038B1 FROM WLINHA022. */
            _.Move(AREA_DE_WORK.WLINHA02.WLINHA022.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1929- MOVE SPACES TO RES-FC0038B1. */
            _.Move("", RES_FC0038B1);

            /*" -1931- WRITE RES-FC0038B1 FROM WLINHA032. */
            _.Move(AREA_DE_WORK.WLINHA03.WLINHA032.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

            /*" -1932- MOVE SPACES TO RES-FC0038B1. */
            _.Move("", RES_FC0038B1);

            /*" -1932- WRITE RES-FC0038B1 FROM WLINHA042. */
            _.Move(AREA_DE_WORK.WLINHA04.WLINHA042.GetMoveValues(), RES_FC0038B1);

            RFC0038B1.Write(RES_FC0038B1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TOTALIZA-FAIXA-SECTION */
        private void R3000_00_TOTALIZA_FAIXA_SECTION()
        {
            /*" -1945- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -1947- ADD 1 TO WTB2-IND. */
            AREA_DE_WORK.WTB2_IND.Value = AREA_DE_WORK.WTB2_IND + 1;

            /*" -1948- MOVE WFAI-CEPINI TO TB2-CEPINI(WTB2-IND) */
            _.Move(AREA_DE_WORK.WFAI_CEPINI, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_CEPINI);

            /*" -1949- MOVE WFAI-CEPFIM TO TB2-CEPFIM(WTB2-IND) */
            _.Move(AREA_DE_WORK.WFAI_CEPFIM, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_CEPFIM);

            /*" -1950- MOVE WFAI-OBJINI TO TB2-OBJINI(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_OBJINI, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_OBJINI);

            /*" -1951- MOVE WFAI-OBJFIM TO TB2-OBJFIM(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_OBJFIM, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_OBJFIM);

            /*" -1952- MOVE WFAI-AMRINI TO TB2-AMRINI(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_AMRINI, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_AMRINI);

            /*" -1953- MOVE WFAI-AMRFIM TO TB2-AMRFIM(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_AMRFIM, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_AMRFIM);

            /*" -1954- MOVE WFAI-QTDOBJ TO TB2-QTDOBJ(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_QTDOBJ, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_QTDOBJ);

            /*" -1955- MOVE WFAI-QTDAMR TO TB2-QTDAMR(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_QTDAMR, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_QTDAMR);

            /*" -1956- MOVE WFAI-DESCRICAO TO TB2-DESCRI(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_DESCRICAO, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_DESCRI);

            /*" -1956- MOVE WFAI-CENTRALIZA TO TB2-CENTRA(WTB2-IND). */
            _.Move(AREA_DE_WORK.WFAI_CENTRALIZA, AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_CENTRA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-IMPRIME-RESUMO-SECTION */
        private void R4000_00_IMPRIME_RESUMO_SECTION()
        {
            /*" -1969- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -1970- IF AC-LINHAS GREATER 18 */

            if (AREA_DE_WORK.AC_LINHAS > 18)
            {

                /*" -1971- IF WFLAG EQUAL 1 */

                if (AREA_DE_WORK.WFLAG == 1)
                {

                    /*" -1972- MOVE SPACES TO LD01 */
                    _.Move("", LD01);

                    /*" -1973- MOVE '1 ' TO LD01-CANAL */
                    _.Move("1 ", LD01.LD01_CANAL);

                    /*" -1974- WRITE RES-FC0038B2 FROM LD01 */
                    _.Move(LD01.GetMoveValues(), RES_FC0038B2);

                    RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

                    /*" -1975- MOVE SPACES TO LD01 */
                    _.Move("", LD01);

                    /*" -1976- ELSE */
                }
                else
                {


                    /*" -1977- MOVE 1 TO WFLAG */
                    _.Move(1, AREA_DE_WORK.WFLAG);

                    /*" -1978- END-IF */
                }


                /*" -1979- PERFORM R4100-00-CABECALHO */

                R4100_00_CABECALHO_SECTION();

                /*" -1981- END-IF. */
            }


            /*" -1982- MOVE TB2-CEPINI(WTB2-IND) TO WW01-NUMCEP */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_CEPINI, AREA_DE_WORK.WW01_NUMCEP);

            /*" -1983- MOVE WW01-NUMCEP-1 TO WREL-NUMCEP-1 */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_NUMCEP_1, AREA_DE_WORK.WREL_NUMCEP.WREL_NUMCEP_1);

            /*" -1984- MOVE WW01-COMPCEP TO WREL-COMPCEP */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_COMPCEP, AREA_DE_WORK.WREL_NUMCEP.WREL_COMPCEP);

            /*" -1985- MOVE WREL-NUMCEP TO LD01-CEPINI */
            _.Move(AREA_DE_WORK.WREL_NUMCEP, LD01.LD01_CEPINI);

            /*" -1986- MOVE TB2-CEPFIM(WTB2-IND) TO WW01-NUMCEP. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_CEPFIM, AREA_DE_WORK.WW01_NUMCEP);

            /*" -1987- MOVE WW01-NUMCEP-1 TO WREL-NUMCEP-1 */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_NUMCEP_1, AREA_DE_WORK.WREL_NUMCEP.WREL_NUMCEP_1);

            /*" -1988- MOVE WW01-COMPCEP TO WREL-COMPCEP */
            _.Move(AREA_DE_WORK.WW01_NUMCEP.WW01_COMPCEP, AREA_DE_WORK.WREL_NUMCEP.WREL_COMPCEP);

            /*" -1989- MOVE WREL-NUMCEP TO LD01-CEPFIM */
            _.Move(AREA_DE_WORK.WREL_NUMCEP, LD01.LD01_CEPFIM);

            /*" -1990- MOVE TB2-OBJINI(WTB2-IND) TO LD01-OBJET1. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_OBJINI, LD01.LD01_OBJET1);

            /*" -1991- MOVE TB2-OBJFIM(WTB2-IND) TO LD01-OBJET2. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_OBJFIM, LD01.LD01_OBJET2);

            /*" -1992- MOVE TB2-AMRINI(WTB2-IND) TO LD01-AMARR1. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_AMRINI, LD01.LD01_AMARR1);

            /*" -1993- MOVE TB2-AMRFIM(WTB2-IND) TO LD01-AMARR2. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_AMRFIM, LD01.LD01_AMARR2);

            /*" -1994- MOVE TB2-QTDOBJ(WTB2-IND) TO LD01-QTDOBJ. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_QTDOBJ, LD01.LD01_QTDOBJ);

            /*" -1995- MOVE TB2-QTDAMR(WTB2-IND) TO LD01-QTDAMA. */
            _.Move(AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_QTDAMR, LD01.LD01_QTDAMA);

            /*" -1997- MOVE ' ' TO LD01-OBSERVACAO. */
            _.Move(" ", LD01.LD01_OBSERVACAO);

            /*" -1998- ADD TB2-QTDOBJ(WTB2-IND) TO TOTAL-OBJETOS */
            AREA_DE_WORK.TOTAL_OBJETOS.Value = AREA_DE_WORK.TOTAL_OBJETOS + AREA_DE_WORK.TABELAS_RESUMO.TABELA_RESUMO[AREA_DE_WORK.WTB2_IND].TB2_QTDOBJ;

            /*" -1999- IF WTB2-IND EQUAL WTB2-QTDREG */

            if (AREA_DE_WORK.WTB2_IND == AREA_DE_WORK.WTB2_QTDREG)
            {

                /*" -2000- MOVE 'TOTAL OBJETOS: ' TO WD01-LITERAL */
                _.Move("TOTAL OBJETOS: ", AREA_DE_WORK.WD01_LINHA.WD01_LITERAL);

                /*" -2001- MOVE TOTAL-OBJETOS TO WD01-OBJETOS */
                _.Move(AREA_DE_WORK.TOTAL_OBJETOS, AREA_DE_WORK.WD01_LINHA.WD01_OBJETOS);

                /*" -2003- MOVE WD01-LINHA TO LD01-OBSERVACAO. */
                _.Move(AREA_DE_WORK.WD01_LINHA, LD01.LD01_OBSERVACAO);
            }


            /*" -2004- ADD 1 TO WTB2-IND. */
            AREA_DE_WORK.WTB2_IND.Value = AREA_DE_WORK.WTB2_IND + 1;

            /*" -2006- ADD 1 TO AC-LINHAS. */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -2007- WRITE RES-FC0038B2 FROM LD01. */
            _.Move(LD01.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2007- MOVE SPACES TO LD01. */
            _.Move("", LD01);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-CABECALHO-SECTION */
        private void R4100_00_CABECALHO_SECTION()
        {
            /*" -2020- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -2021- MOVE SPACES TO LC02. */
            _.Move("", LC02);

            /*" -2022- MOVE WCONTRATO TO LC02-PRODUTO */
            _.Move(AREA_DE_WORK.WCONTRATO, LC02.LC02_PRODUTO);

            /*" -2024- WRITE RES-FC0038B2 FROM LC02. */
            _.Move(LC02.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2025- MOVE SPACES TO LC02. */
            _.Move("", LC02);

            /*" -2026- IF WCONTRATO EQUAL '100134700-6    ' */

            if (AREA_DE_WORK.WCONTRATO == "100134700-6    ")
            {

                /*" -2027- MOVE 'CAIXA SEGUROS' TO LC02-PRODUTO */
                _.Move("CAIXA SEGUROS", LC02.LC02_PRODUTO);

                /*" -2028- ELSE */
            }
            else
            {


                /*" -2031- MOVE 'CAIXA CAPITALIZACAO' TO LC02-PRODUTO. */
                _.Move("CAIXA CAPITALIZACAO", LC02.LC02_PRODUTO);
            }


            /*" -2033- WRITE RES-FC0038B2 FROM LC02. */
            _.Move(LC02.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2034- MOVE SPACES TO LC02. */
            _.Move("", LC02);

            /*" -2035- MOVE WENDEMPR TO LC02-PRODUTO */
            _.Move(AREA_DE_WORK.WENDEMPR, LC02.LC02_PRODUTO);

            /*" -2037- WRITE RES-FC0038B2 FROM LC02. */
            _.Move(LC02.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2038- MOVE SPACES TO LC02. */
            _.Move("", LC02);

            /*" -2039- MOVE 'BRASILIA - DF' TO LC02-PRODUTO */
            _.Move("BRASILIA - DF", LC02.LC02_PRODUTO);

            /*" -2041- WRITE RES-FC0038B2 FROM LC02. */
            _.Move(LC02.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2042- MOVE WS-DTREFER TO WDATA-DTPROC. */
            _.Move(AREA_DE_WORK.WS_DTREFER, AREA_DE_WORK.WDATA_DTPROC);

            /*" -2043- MOVE WDATA-DIAPROC TO WREL-DIAPROC. */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_DIAPROC, AREA_DE_WORK.WREL_DTPROC.WREL_DIAPROC);

            /*" -2044- MOVE '/' TO WREL-BARR1. */
            _.Move("/", AREA_DE_WORK.WREL_DTPROC.WREL_BARR1);

            /*" -2045- MOVE WDATA-MESPROC TO WREL-MESPROC. */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_MESPROC, AREA_DE_WORK.WREL_DTPROC.WREL_MESPROC);

            /*" -2046- MOVE '/' TO WREL-BARR2. */
            _.Move("/", AREA_DE_WORK.WREL_DTPROC.WREL_BARR2);

            /*" -2048- MOVE WDATA-ANOPROC TO WREL-ANOPROC. */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC, AREA_DE_WORK.WREL_DTPROC.WREL_ANOPROC);

            /*" -2049- MOVE V0RELA-NRCOPIAS TO LC01-NUMRELAT. */
            _.Move(V0RELA_NRCOPIAS, LC01.LC01_NUMRELAT);

            /*" -2050- ADD 1 TO AC-FOLHA. */
            AREA_DE_WORK.AC_FOLHA.Value = AREA_DE_WORK.AC_FOLHA + 1;

            /*" -2051- MOVE 1 TO AC-LINHAS. */
            _.Move(1, AREA_DE_WORK.AC_LINHAS);

            /*" -2052- MOVE AC-FOLHA TO LC04-FOLHA. */
            _.Move(AREA_DE_WORK.AC_FOLHA, LC04.LC04_FOLHA);

            /*" -2053- MOVE AC-PAGINA TO LC04-PAGINA. */
            _.Move(AREA_DE_WORK.AC_PAGINA, LC04.LC04_PAGINA);

            /*" -2055- MOVE WREL-DTPROC TO LC03-DATREL. */
            _.Move(AREA_DE_WORK.WREL_DTPROC, LC03.LC03_DATREL);

            /*" -2058- MOVE TAB-MES(WREL-MESPROC) TO LC01-MESPROC. */
            _.Move(AREA_DE_WORK.FILLER_20[AREA_DE_WORK.WREL_DTPROC.WREL_MESPROC].TAB_MES, LC01.LC01_MESPROC);

            /*" -2060- WRITE RES-FC0038B2 FROM LC01. */
            _.Move(LC01.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2062- MOVE WTIPPROD TO LC02-PRODUTO. */
            _.Move(AREA_DE_WORK.WTIPPROD, LC02.LC02_PRODUTO);

            /*" -2064- WRITE RES-FC0038B2 FROM LC02. */
            _.Move(LC02.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2066- WRITE RES-FC0038B2 FROM LC03. */
            _.Move(LC03.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2067- MOVE SPACES TO LC02. */
            _.Move("", LC02);

            /*" -2068- MOVE 'BRASILIA - DF' TO LC02-PRODUTO */
            _.Move("BRASILIA - DF", LC02.LC02_PRODUTO);

            /*" -2070- WRITE RES-FC0038B2 FROM LC02. */
            _.Move(LC02.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

            /*" -2070- WRITE RES-FC0038B2 FROM LC04. */
            _.Move(LC04.GetMoveValues(), RES_FC0038B2);

            RFC0038B2.Write(RES_FC0038B2.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9000_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2082- MOVE V0SIST-DTMOVABE TO WDATA-DTPROC. */
            _.Move(V0SIST_DTMOVABE, AREA_DE_WORK.WDATA_DTPROC);

            /*" -2083- MOVE WDATA-DIAPROC TO WREL-DIAPROC. */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_DIAPROC, AREA_DE_WORK.WREL_DTPROC.WREL_DIAPROC);

            /*" -2084- MOVE '/' TO WREL-BARR1. */
            _.Move("/", AREA_DE_WORK.WREL_DTPROC.WREL_BARR1);

            /*" -2085- MOVE WDATA-MESPROC TO WREL-MESPROC. */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_MESPROC, AREA_DE_WORK.WREL_DTPROC.WREL_MESPROC);

            /*" -2086- MOVE '/' TO WREL-BARR2. */
            _.Move("/", AREA_DE_WORK.WREL_DTPROC.WREL_BARR2);

            /*" -2088- MOVE WDATA-ANOPROC TO WREL-ANOPROC. */
            _.Move(AREA_DE_WORK.WDATA_DTPROC.WDATA_ANOPROC, AREA_DE_WORK.WREL_DTPROC.WREL_ANOPROC);

            /*" -2089- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -2090- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2091- DISPLAY '*  FC0038B - CARTA DE CADUCOS FEDERAL CAP  *' */
            _.Display($"*  FC0038B - CARTA DE CADUCOS FEDERAL CAP  *");

            /*" -2092- DISPLAY '*  -------   ----- -- ------- ------- ---  *' */
            _.Display($"*  -------   ----- -- ------- ------- ---  *");

            /*" -2093- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2094- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -2096- DISPLAY '*              ' WREL-DTPROC '                  *' */

            $"*              {AREA_DE_WORK.WREL_DTPROC}                  *"
            .Display();

            /*" -2097- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -2097- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2109- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2110- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2111- CLOSE ENTRADA RFC0038B1 RFC0038B2 CEPERROS */
            ENTRADA.Close();
            RFC0038B1.Close();
            RFC0038B2.Close();
            CEPERROS.Close();

            /*" -2111- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2113- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2113- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}