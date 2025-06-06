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
using Sias.Bilhetes.DB2.BI6254B;

namespace Code
{
    public class BI6254B
    {
        public bool IsCall { get; set; }

        public BI6254B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETES                           *      */
        /*"      *   PROGRAMA ...............  BI6254B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  06/02/2013                         *      */
        /*"      *   CADMUS   ORIGEM ........  60449                              *      */
        /*"      *   VERSAO .................  V.00                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROCESSA FITA DE ENVIO SICOV       *      */
        /*"      *                             PARA DEBITO NA CONTA DO SEGURADO.  *      */
        /*"      *                             CONVENIO 023000 - SUPERPAY         *      */
        /*"      *                             DEBITO CARTAO DE CREDITO.          *      */
        /*"      *                             A PARTIR DA LEITURA DA TABELA      *      */
        /*"      *                             MOVTO_DEBITOCC_CEF.                *      */
        /*"      *                                                                *      */
        /*"      *   GRAVA ARQUIVO PARA GERACAO DA PROXIMA PARCELA                *      */
        /*"      *   PARA BILHETES COM 60 PARCELAS.                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                         ALTERACOES                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -  ADAILTON DIAS                                          */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/01/2019 - ATOS BR                                      *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOV023000_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOV023000_CC
        {
            get
            {
                _.Move(REG_MOV023000, _MOV023000_CC); VarBasis.RedefinePassValue(REG_MOV023000, _MOV023000_CC, REG_MOV023000); return _MOV023000_CC;
            }
        }
        public FileBasis _BI6254B1 { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis BI6254B1
        {
            get
            {
                _.Move(REG_BI6254B, _BI6254B1); VarBasis.RedefinePassValue(REG_BI6254B, _BI6254B1, REG_BI6254B); return _BI6254B1;
            }
        }
        /*"01        REG-MOV023000               PIC  X(150).*/
        public StringBasis REG_MOV023000 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-BI6254B.*/
        public BI6254B_REG_BI6254B REG_BI6254B { get; set; } = new BI6254B_REG_BI6254B();
        public class BI6254B_REG_BI6254B : VarBasis
        {
            /*"  05      SAI-COD-CONVENIO          PIC 9(006).*/
            public IntBasis SAI_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SAI-NSAS                  PIC 9(006).*/
            public IntBasis SAI_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SAI-NUM-APOLICE           PIC 9(013).*/
            public IntBasis SAI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SAI-NUM-ENDOSSO           PIC 9(009).*/
            public IntBasis SAI_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SAI-NUM-PARCELA           PIC 9(004).*/
            public IntBasis SAI_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SAI-COD-PRODUTO           PIC 9(004).*/
            public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SAI-DIA-DEBITO            PIC 9(004).*/
            public IntBasis SAI_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NUMCARTAO            PIC S9(004)     COMP.*/
        public IntBasis VIND_NUMCARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-STATUS               PIC S9(004)     COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DIADEB               PIC S9(004)     COMP.*/
        public IntBasis VIND_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-DTMOVABE20         PIC  X(020).*/
        public StringBasis WSHOST_DTMOVABE20 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77    WSHOST-DATA-CURRENT       PIC  X(010).*/
        public StringBasis WSHOST_DATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  W.*/
        public BI6254B_W W { get; set; } = new BI6254B_W();
        public class BI6254B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WTEM-REGISTRO             PIC  X(001)    VALUE  'N'.*/
            public StringBasis WTEM_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-V0MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_V0MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-V0MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_V0MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SAIDA                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SAIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ANT-CONVENIO              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis ANT_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-TOTARQUIVO             PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_TOTARQUIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-TOTREGISTRO            PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-VLRTOTDEB              PIC S9(013)V99 COMP-3.*/
            public DoubleBasis AC_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AC-VALOR                  PIC  ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI6254B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI6254B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI6254B_FILLER_0(); _.Move(WTIME_DAY, _filler_0); VarBasis.RedefinePassValue(WTIME_DAY, _filler_0, WTIME_DAY); _filler_0.ValueChanged += () => { _.Move(_filler_0, WTIME_DAY); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI6254B_FILLER_0 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public BI6254B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI6254B_WTIME_DAYR();
                public class BI6254B_WTIME_DAYR : VarBasis
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

                    public BI6254B_WTIME_DAYR()
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
                /*"  03         WS-TIME.*/

                public _REDEF_BI6254B_FILLER_0()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI6254B_WS_TIME WS_TIME { get; set; } = new BI6254B_WS_TIME();
            public class BI6254B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_BI6254B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI6254B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI6254B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI6254B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WHORA-CURR.*/

                public _REDEF_BI6254B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI6254B_WHORA_CURR WHORA_CURR { get; set; } = new BI6254B_WHORA_CURR();
            public class BI6254B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03        WABEND.*/
            }
            public BI6254B_WABEND WABEND { get; set; } = new BI6254B_WABEND();
            public class BI6254B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI6254B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI6254B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public BI6254B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI6254B_HEADER_REGISTRO();
        public class BI6254B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO       PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA        PIC  X(001).*/
            public StringBasis HEADER_CODREMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODCONVENIO.*/
            public BI6254B_HEADER_CODCONVENIO HEADER_CODCONVENIO { get; set; } = new BI6254B_HEADER_CODCONVENIO();
            public class BI6254B_HEADER_CODCONVENIO : VarBasis
            {
                /*"    10    HEADER-CONVENIO          PIC  9(006).*/
                public IntBasis HEADER_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    FILLER                   PIC  X(014).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                /*"  05      HEADER-NOMEMPRESA        PIC  X(020).*/
            }
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO          PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMBANCO          PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public BI6254B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new BI6254B_HEADER_DATGERACAO();
            public class BI6254B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO               PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES               PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA               PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSAS              PIC  9(006).*/
            }
            public IntBasis HEADER_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO            PIC  X(002).*/
            public StringBasis HEADER_VERSAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-DEBCREDAUT        PIC  X(017).*/
            public StringBasis HEADER_DEBCREDAUT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      FILLER                   PIC  X(052).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public BI6254B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI6254B_MOVCC_REGISTRO();
        public class BI6254B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO        PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP.*/
            public BI6254B_MOVCC_IDTCLIEMP MOVCC_IDTCLIEMP { get; set; } = new BI6254B_MOVCC_IDTCLIEMP();
            public class BI6254B_MOVCC_IDTCLIEMP : VarBasis
            {
                /*"    10    MOVCC-NUMAPOL            PIC  9(013).*/
                public IntBasis MOVCC_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    MOVCC-NRENDOS            PIC  9(010).*/
                public IntBasis MOVCC_NRENDOS { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"    10    MOVCC-NRPARCEL           PIC  9(002).*/
                public IntBasis MOVCC_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-IDTCLIBAN.*/
            }
            public BI6254B_MOVCC_IDTCLIBAN MOVCC_IDTCLIBAN { get; set; } = new BI6254B_MOVCC_IDTCLIBAN();
            public class BI6254B_MOVCC_IDTCLIBAN : VarBasis
            {
                /*"    10    MOVCC-AGECONTA           PIC  9(004).*/
                public IntBasis MOVCC_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPECONTA           PIC  9(004).*/
                public IntBasis MOVCC_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCONTA           PIC  9(012).*/
                public IntBasis MOVCC_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCONTA           PIC  9(001).*/
                public IntBasis MOVCC_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER                   PIC  X(002).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public BI6254B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new BI6254B_MOVCC_DTCREDITO();
            public class BI6254B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANO                PIC  9(004).*/
                public IntBasis MOVCC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MES                PIC  9(002).*/
                public IntBasis MOVCC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIA                PIC  9(002).*/
                public IntBasis MOVCC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-VLDEBCRE           PIC  9(013)V99.*/
            }
            public DoubleBasis MOVCC_VLDEBCRE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-CODMOEDA           PIC  X(002).*/
            public StringBasis MOVCC_CODMOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-USOEMPRESA.*/
            public BI6254B_MOVCC_USOEMPRESA MOVCC_USOEMPRESA { get; set; } = new BI6254B_MOVCC_USOEMPRESA();
            public class BI6254B_MOVCC_USOEMPRESA : VarBasis
            {
                /*"    10    MOVCC-CONVENIO           PIC  9(006).*/
                public IntBasis MOVCC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-NSAS               PIC  9(006).*/
                public IntBasis MOVCC_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-NRSEQ              PIC  9(006).*/
                public IntBasis MOVCC_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-CODPRODU           PIC  9(004).*/
                public IntBasis MOVCC_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUM-TOKEN          PIC  9(016).*/
                public IntBasis MOVCC_NUM_TOKEN { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    MOVCC-TIPO               PIC  X(002).*/
                public StringBasis MOVCC_TIPO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10    FILLER                   PIC  X(020).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05      FILLER                   PIC  X(015).*/
            }
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      MOVCC-CODMOV             PIC  X(001).*/
            public StringBasis MOVCC_CODMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI6254B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI6254B_TRAILL_REGISTRO();
        public class BI6254B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO       PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO       PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB         PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-VLRTOTCRE         PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER            PIC  X(109).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
        }


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.AU085 AU085 { get; set; } = new Dclgens.AU085();
        public Dclgens.PROPOSTA PROPOSTA { get; set; } = new Dclgens.PROPOSTA();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public BI6254B_V0MOVDEBCE V0MOVDEBCE { get; set; } = new BI6254B_V0MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV023000_CC_FILE_NAME_P, string BI6254B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV023000_CC.SetFile(MOV023000_CC_FILE_NAME_P);
                BI6254B1.SetFile(BI6254B1_FILE_NAME_P);

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
            /*" -275- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -276- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -278- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -280- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -284- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -285- DISPLAY ' PROGRAMA EM EXECUCAO BI6254B   ' . */
            _.Display($" PROGRAMA EM EXECUCAO BI6254B   ");

            /*" -286- DISPLAY '                                ' . */
            _.Display($"                                ");

            /*" -288- DISPLAY ' VERSAO V.01 NSGD    05/10/2014 ' . */
            _.Display($" VERSAO V.01 NSGD    05/10/2014 ");

            /*" -291- DISPLAY '--------------------------------' . */
            _.Display($"--------------------------------");

            /*" -294- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -294- PERFORM R0200-00-PROCESSA. */

            R0200_00_PROCESSA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -299- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -304- CLOSE MOV023000-CC BI6254B1. */
            MOV023000_CC.Close();
            BI6254B1.Close();

            /*" -306- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -307- DISPLAY ' ' */
            _.Display($" ");

            /*" -310- DISPLAY 'BI6254B - FIM NORMAL' . */
            _.Display($"BI6254B - FIM NORMAL");

            /*" -310- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -323- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -324- DISPLAY ' BI6254B - INICIO PROCESSAMENTO ' . */
            _.Display($" BI6254B - INICIO PROCESSAMENTO ");

            /*" -325- DISPLAY ' ' . */
            _.Display($" ");

            /*" -326- DISPLAY ' CONVENIO 023000 (SUPERPAY CARTAO) - ENVIO ' */
            _.Display($" CONVENIO 023000 (SUPERPAY CARTAO) - ENVIO ");

            /*" -328- DISPLAY ' ' . */
            _.Display($" ");

            /*" -332- OPEN OUTPUT MOV023000-CC BI6254B1. */
            MOV023000_CC.Open(REG_MOV023000);
            BI6254B1.Open(REG_BI6254B);

            /*" -335- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -335- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -348- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -358- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -363- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -366- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -369- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -372- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -374- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -376- DISPLAY ' DATA DO PROCESSAMENTO + 20 DIAS .....  ' WSHOST-DTMOVABE20. */
            _.Display($" DATA DO PROCESSAMENTO + 20 DIAS .....  {WSHOST_DTMOVABE20}");

            /*" -376- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -358- EXEC SQL SELECT DATA_MOV_ABERTO , (DATA_MOV_ABERTO + 20 DAYS) , CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO , :WSHOST-DTMOVABE20 , :WSHOST-DATA-CURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WSHOST_DTMOVABE20, WSHOST_DTMOVABE20);
                _.Move(executed_1.WSHOST_DATA_CURRENT, WSHOST_DATA_CURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSA-SECTION */
        private void R0200_00_PROCESSA_SECTION()
        {
            /*" -397- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -401- MOVE 01 TO PARAMCON-TIPO-MOVTO-CC. */
            _.Move(01, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);

            /*" -402- MOVE 'BI6254B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
            _.Move("BI6254B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

            /*" -403- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
            _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

            /*" -403- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
            _.Move("GEJVS002", WS_JV1_PROGRAMA);

            /*" -404- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
            _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

            /*" -405- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

            if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
            {

                /*" -406- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                /*" -407- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                /*" -408- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                /*" -409- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                /*" -410- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, W.WABEND.WSQLCODE);

                /*" -411- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -413- END-IF */
            }


            /*" -418- PERFORM R0200_00_PROCESSA_DB_SELECT_1 */

            R0200_00_PROCESSA_DB_SELECT_1();

            /*" -421- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -422- DISPLAY 'R0200-00-PROCESSA -JV1' */
                _.Display($"R0200-00-PROCESSA -JV1");

                /*" -424- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -425- IF PROPOFID-DATA-PROPOSTA >= LK-GEJVW002-JV-DTA-INI */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA >= GEJVW002.LK_GEJVW002_JV_DTA_INI)
            {

                /*" -427- MOVE JVPRD8119 TO PARAMCON-COD-PRODUTO */
                _.Move(JVBKINCL.JV_PRODUTOS.JVPRD8119, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);

                /*" -428- ELSE */
            }
            else
            {


                /*" -430- MOVE 8119 TO PARAMCON-COD-PRODUTO */
                _.Move(8119, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);

                /*" -433- END-IF. */
            }


            /*" -435- MOVE 021000 TO PARAMCON-COD-CONVENIO. */
            _.Move(021000, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);

            /*" -438- MOVE 023000 TO MOVDEBCE-COD-CONVENIO ANT-CONVENIO. */
            _.Move(023000, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W.ANT_CONVENIO);

            /*" -442- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -448- MOVE ZEROS TO LD-V0MOVDEBCE AC-TOTREGISTRO AC-TOTARQUIVO AC-VLRTOTDEB. */
            _.Move(0, W.LD_V0MOVDEBCE, W.AC_TOTREGISTRO, W.AC_TOTARQUIVO, W.AC_VLRTOTDEB);

            /*" -449- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -450- PERFORM R0310-00-DECLARE-V0MOVDEBCE. */

            R0310_00_DECLARE_V0MOVDEBCE_SECTION();

            /*" -452- PERFORM R0320-00-FETCH-V0MOVDEBCE. */

            R0320_00_FETCH_V0MOVDEBCE_SECTION();

            /*" -453- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -454- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' */
                _.Display($"SEM MOVIMENTO NESTA DATA  ");

                /*" -457- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -460- PERFORM R0350-00-SELECT-V0PARAMCON. */

            R0350_00_SELECT_V0PARAMCON_SECTION();

            /*" -463- PERFORM R0400-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0400_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -464- MOVE AC-VLRTOTDEB TO AC-VALOR. */
            _.Move(W.AC_VLRTOTDEB, W.AC_VALOR);

            /*" -465- DISPLAY ' ' . */
            _.Display($" ");

            /*" -466- DISPLAY ' MOVDEBCE LIDOS ........ ' LD-V0MOVDEBCE. */
            _.Display($" MOVDEBCE LIDOS ........ {W.LD_V0MOVDEBCE}");

            /*" -467- DISPLAY ' MOVDEBCE DESPREZA ..... ' DP-V0MOVDEBCE. */
            _.Display($" MOVDEBCE DESPREZA ..... {W.DP_V0MOVDEBCE}");

            /*" -468- DISPLAY ' REGISTROS ENVIADOS .... ' AC-TOTREGISTRO. */
            _.Display($" REGISTROS ENVIADOS .... {W.AC_TOTREGISTRO}");

            /*" -469- DISPLAY ' VALOR TOTAL ........... ' AC-VALOR. */
            _.Display($" VALOR TOTAL ........... {W.AC_VALOR}");

            /*" -470- DISPLAY ' ' . */
            _.Display($" ");

            /*" -471- DISPLAY ' GRAVADOS SAIDA ........ ' GV-SAIDA. */
            _.Display($" GRAVADOS SAIDA ........ {W.GV_SAIDA}");

            /*" -474- DISPLAY ' ' . */
            _.Display($" ");

            /*" -475- IF AC-TOTARQUIVO NOT EQUAL ZEROS */

            if (W.AC_TOTARQUIVO != 00)
            {

                /*" -478- PERFORM R8100-00-GRAVA-TRAILLER. */

                R8100_00_GRAVA_TRAILLER_SECTION();
            }


            /*" -478- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" R0200-00-PROCESSA-DB-SELECT-1 */
        public void R0200_00_PROCESSA_DB_SELECT_1()
        {
            /*" -418- EXEC SQL SELECT DATA_PROPOSTA INTO :PROPOFID-DATA-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :MOVDEBCE-NUM-ENDOSSO END-EXEC. */

            var r0200_00_PROCESSA_DB_SELECT_1_Query1 = new R0200_00_PROCESSA_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0200_00_PROCESSA_DB_SELECT_1_Query1.Execute(r0200_00_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-DECLARE-V0MOVDEBCE-SECTION */
        private void R0310_00_DECLARE_V0MOVDEBCE_SECTION()
        {
            /*" -491- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -506- PERFORM R0310_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1 */

            R0310_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1();

            /*" -508- PERFORM R0310_00_DECLARE_V0MOVDEBCE_DB_OPEN_1 */

            R0310_00_DECLARE_V0MOVDEBCE_DB_OPEN_1();

            /*" -512- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -513- DISPLAY 'R0310-00 - PROBLEMAS DECLARE (MOVDEBCE)' */
                _.Display($"R0310-00 - PROBLEMAS DECLARE (MOVDEBCE)");

                /*" -513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-DECLARE-V0MOVDEBCE-DB-DECLARE-1 */
        public void R0310_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1()
        {
            /*" -506- EXEC SQL DECLARE V0MOVDEBCE CURSOR WITH HOLD FOR SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_VENCIMENTO , VALOR_DEBITO , DIA_DEBITO , NUM_CARTAO , STATUS_CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND DATA_VENCIMENTO <= :WSHOST-DTMOVABE20 END-EXEC. */
            V0MOVDEBCE = new BI6254B_V0MOVDEBCE(true);
            string GetQuery_V0MOVDEBCE()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							DATA_VENCIMENTO
							, 
							VALOR_DEBITO
							, 
							DIA_DEBITO
							, 
							NUM_CARTAO
							, 
							STATUS_CARTAO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE SITUACAO_COBRANCA = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}' 
							AND COD_CONVENIO = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}' 
							AND DATA_VENCIMENTO <= '{WSHOST_DTMOVABE20}'";

                return query;
            }
            V0MOVDEBCE.GetQueryEvent += GetQuery_V0MOVDEBCE;

        }

        [StopWatch]
        /*" R0310-00-DECLARE-V0MOVDEBCE-DB-OPEN-1 */
        public void R0310_00_DECLARE_V0MOVDEBCE_DB_OPEN_1()
        {
            /*" -508- EXEC SQL OPEN V0MOVDEBCE END-EXEC. */

            V0MOVDEBCE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-FETCH-V0MOVDEBCE-SECTION */
        private void R0320_00_FETCH_V0MOVDEBCE_SECTION()
        {
            /*" -526- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.WABEND.WNR_EXEC_SQL);

            /*" -535- PERFORM R0320_00_FETCH_V0MOVDEBCE_DB_FETCH_1 */

            R0320_00_FETCH_V0MOVDEBCE_DB_FETCH_1();

            /*" -539- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -539- PERFORM R0320_00_FETCH_V0MOVDEBCE_DB_CLOSE_1 */

                R0320_00_FETCH_V0MOVDEBCE_DB_CLOSE_1();

                /*" -541- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -543- GO TO R0320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -544- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -545- DISPLAY 'R0320-00 - PROBLEMAS FETCH (MOVDEBCE)' */
                _.Display($"R0320-00 - PROBLEMAS FETCH (MOVDEBCE)");

                /*" -548- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -549- IF VIND-NUMCARTAO LESS ZEROS */

            if (VIND_NUMCARTAO < 00)
            {

                /*" -552- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


            /*" -553- IF VIND-STATUS LESS ZEROS */

            if (VIND_STATUS < 00)
            {

                /*" -556- MOVE SPACES TO MOVDEBCE-STATUS-CARTAO. */
                _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);
            }


            /*" -557- IF VIND-DIADEB LESS ZEROS */

            if (VIND_DIADEB < 00)
            {

                /*" -561- MOVE ZEROS TO MOVDEBCE-DIA-DEBITO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);
            }


            /*" -562- IF MOVDEBCE-DIA-DEBITO EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO == 00)
            {

                /*" -564- MOVE MOVDEBCE-DATA-VENCIMENTO TO WDATA-REL */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, W.WDATA_REL);

                /*" -568- MOVE WDAT-REL-DIA TO MOVDEBCE-DIA-DEBITO. */
                _.Move(W.FILLER_1.WDAT_REL_DIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);
            }


            /*" -568- ADD 1 TO LD-V0MOVDEBCE. */
            W.LD_V0MOVDEBCE.Value = W.LD_V0MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R0320-00-FETCH-V0MOVDEBCE-DB-FETCH-1 */
        public void R0320_00_FETCH_V0MOVDEBCE_DB_FETCH_1()
        {
            /*" -535- EXEC SQL FETCH V0MOVDEBCE INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DIA-DEBITO:VIND-DIADEB , :MOVDEBCE-NUM-CARTAO:VIND-NUMCARTAO , :MOVDEBCE-STATUS-CARTAO:VIND-STATUS END-EXEC. */

            if (V0MOVDEBCE.Fetch())
            {
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(V0MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);
                _.Move(V0MOVDEBCE.VIND_DIADEB, VIND_DIADEB);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(V0MOVDEBCE.VIND_NUMCARTAO, VIND_NUMCARTAO);
                _.Move(V0MOVDEBCE.MOVDEBCE_STATUS_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);
                _.Move(V0MOVDEBCE.VIND_STATUS, VIND_STATUS);
            }

        }

        [StopWatch]
        /*" R0320-00-FETCH-V0MOVDEBCE-DB-CLOSE-1 */
        public void R0320_00_FETCH_V0MOVDEBCE_DB_CLOSE_1()
        {
            /*" -539- EXEC SQL CLOSE V0MOVDEBCE END-EXEC */

            V0MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-SELECT-V0PARAMCON-SECTION */
        private void R0350_00_SELECT_V0PARAMCON_SECTION()
        {
            /*" -581- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -595- PERFORM R0350_00_SELECT_V0PARAMCON_DB_SELECT_1 */

            R0350_00_SELECT_V0PARAMCON_DB_SELECT_1();

            /*" -599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -600- DISPLAY 'R0350-00 - PROBLEMAS SELECT(PARAM_CONTACEF)' */
                _.Display($"R0350-00 - PROBLEMAS SELECT(PARAM_CONTACEF)");

                /*" -603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -607- ADD 1 TO PARAMCON-NSAS. */
            PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.Value = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS + 1;

            /*" -609- DISPLAY ' NSAS DE ENVIO .......................  ' PARAMCON-NSAS. */
            _.Display($" NSAS DE ENVIO .......................  {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS}");

            /*" -609- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0350-00-SELECT-V0PARAMCON-DB-SELECT-1 */
        public void R0350_00_SELECT_V0PARAMCON_DB_SELECT_1()
        {
            /*" -595- EXEC SQL SELECT TIPO_MOVTO_CC , COD_PRODUTO , COD_CONVENIO , NSAS INTO :PARAMCON-TIPO-MOVTO-CC , :PARAMCON-COD-PRODUTO , :PARAMCON-COD-CONVENIO , :PARAMCON-NSAS FROM SEGUROS.PARAM_CONTACEF WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC AND COD_PRODUTO = :PARAMCON-COD-PRODUTO AND COD_CONVENIO = :PARAMCON-COD-CONVENIO WITH UR END-EXEC. */

            var r0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 = new R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1()
            {
                PARAMCON_TIPO_MOVTO_CC = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                PARAMCON_COD_PRODUTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMCON_TIPO_MOVTO_CC, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);
                _.Move(executed_1.PARAMCON_COD_PRODUTO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);
                _.Move(executed_1.PARAMCON_COD_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);
                _.Move(executed_1.PARAMCON_NSAS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0400_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -622- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -624- MOVE ZEROS TO ENDOSSOS-QTD-PARCELAS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);

            /*" -627- MOVE 'S' TO WTEM-REGISTRO. */
            _.Move("S", W.WTEM_REGISTRO);

            /*" -628- IF MOVDEBCE-STATUS-CARTAO EQUAL 'A' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO == "A")
            {

                /*" -629- PERFORM R0510-00-SELECT-AU085 */

                R0510_00_SELECT_AU085_SECTION();

                /*" -630- ELSE */
            }
            else
            {


                /*" -633- PERFORM R0520-00-SELECT-ENDOSSOS. */

                R0520_00_SELECT_ENDOSSOS_SECTION();
            }


            /*" -634- IF WTEM-REGISTRO EQUAL 'S' */

            if (W.WTEM_REGISTRO == "S")
            {

                /*" -635- PERFORM R0600-00-GRAVA-DETALHE */

                R0600_00_GRAVA_DETALHE_SECTION();

                /*" -636- ELSE */
            }
            else
            {


                /*" -636- ADD 1 TO DP-V0MOVDEBCE. */
                W.DP_V0MOVDEBCE.Value = W.DP_V0MOVDEBCE + 1;
            }


            /*" -0- FLUXCONTROL_PERFORM R0400_90_LEITURA */

            R0400_90_LEITURA();

        }

        [StopWatch]
        /*" R0400-90-LEITURA */
        private void R0400_90_LEITURA(bool isPerform = false)
        {
            /*" -641- PERFORM R0320-00-FETCH-V0MOVDEBCE. */

            R0320_00_FETCH_V0MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-SELECT-AU085-SECTION */
        private void R0510_00_SELECT_AU085_SECTION()
        {
            /*" -653- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -655- MOVE MOVDEBCE-NUM-APOLICE TO PROPOSTA-COD-FONTE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE);

            /*" -658- MOVE MOVDEBCE-NUM-ENDOSSO TO PROPOSTA-NUM-PROPOSTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA);

            /*" -676- PERFORM R0510_00_SELECT_AU085_DB_SELECT_1 */

            R0510_00_SELECT_AU085_DB_SELECT_1();

            /*" -680- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -681- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -682- ELSE */
            }
            else
            {


                /*" -683- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -684- DISPLAY 'R0510-00 - PROBLEMAS SELECT  (AU085)   ' */
                    _.Display($"R0510-00 - PROBLEMAS SELECT  (AU085)   ");

                    /*" -684- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-SELECT-AU085-DB-SELECT-1 */
        public void R0510_00_SELECT_AU085_DB_SELECT_1()
        {
            /*" -676- EXEC SQL SELECT A.COD_FONTE , A.NUM_PROPOSTA , A.COD_PRODUTO , B.NUM_TOKEN_PGTO INTO :PROPOSTA-COD-FONTE , :PROPOSTA-NUM-PROPOSTA , :ENDOSSOS-COD-PRODUTO , :AU085-NUM-TOKEN-PGTO FROM SEGUROS.PROPOSTAS A, SEGUROS.AU_PROPOSTA_COMPL B WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA AND A.COD_FONTE = B.COD_FONTE AND A.NUM_PROPOSTA = B.NUM_PROPOSTA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0510_00_SELECT_AU085_DB_SELECT_1_Query1 = new R0510_00_SELECT_AU085_DB_SELECT_1_Query1()
            {
                PROPOSTA_NUM_PROPOSTA = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA.ToString(),
                PROPOSTA_COD_FONTE = PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE.ToString(),
            };

            var executed_1 = R0510_00_SELECT_AU085_DB_SELECT_1_Query1.Execute(r0510_00_SELECT_AU085_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_COD_FONTE, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE);
                _.Move(executed_1.PROPOSTA_NUM_PROPOSTA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.AU085_NUM_TOKEN_PGTO, AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_TOKEN_PGTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-SELECT-ENDOSSOS-SECTION */
        private void R0520_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -697- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -721- PERFORM R0520_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0520_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -725- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -726- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -727- ELSE */
            }
            else
            {


                /*" -728- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -729- DISPLAY 'R0520-00 - PROBLEMAS SELECT  (ENDOSSOS)' */
                    _.Display($"R0520-00 - PROBLEMAS SELECT  (ENDOSSOS)");

                    /*" -729- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0520-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0520_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -721- EXEC SQL SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.SIT_REGISTRO , B.COD_PRODUTO , B.QTD_PARCELAS INTO :PARCELAS-NUM-APOLICE , :PARCELAS-NUM-ENDOSSO , :PARCELAS-NUM-PARCELA , :PARCELAS-SIT-REGISTRO , :ENDOSSOS-COD-PRODUTO , :ENDOSSOS-QTD-PARCELAS FROM SEGUROS.PARCELAS A, SEGUROS.ENDOSSOS B WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND A.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND A.SIT_REGISTRO = '0' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0520_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);
                _.Move(executed_1.PARCELAS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);
                _.Move(executed_1.PARCELAS_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);
                _.Move(executed_1.PARCELAS_SIT_REGISTRO, PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-GRAVA-DETALHE-SECTION */
        private void R0600_00_GRAVA_DETALHE_SECTION()
        {
            /*" -742- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -743- IF AC-TOTARQUIVO EQUAL ZEROS */

            if (W.AC_TOTARQUIVO == 00)
            {

                /*" -746- PERFORM R8000-00-GRAVA-HEADER. */

                R8000_00_GRAVA_HEADER_SECTION();
            }


            /*" -749- ADD 1 TO AC-TOTARQUIVO AC-TOTREGISTRO. */
            W.AC_TOTARQUIVO.Value = W.AC_TOTARQUIVO + 1;
            W.AC_TOTREGISTRO.Value = W.AC_TOTREGISTRO + 1;

            /*" -751- MOVE SPACES TO MOVCC-REGISTRO. */
            _.Move("", MOVCC_REGISTRO);

            /*" -753- MOVE 'E' TO MOVCC-CODREGISTRO. */
            _.Move("E", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -755- MOVE MOVDEBCE-NUM-APOLICE TO MOVCC-NUMAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUMAPOL);

            /*" -757- MOVE MOVDEBCE-NUM-ENDOSSO TO MOVCC-NRENDOS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NRENDOS);

            /*" -759- MOVE MOVDEBCE-NUM-PARCELA TO MOVCC-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NRPARCEL);

            /*" -765- MOVE ZEROS TO MOVCC-AGECONTA MOVCC-OPECONTA MOVCC-NUMCONTA MOVCC-DIGCONTA. */
            _.Move(0, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_AGECONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_DIGCONTA);

            /*" -767- IF MOVDEBCE-DATA-VENCIMENTO LESS SISTEMAS-DATA-MOV-ABERTO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO < SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO)
            {

                /*" -769- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

                /*" -770- ELSE */
            }
            else
            {


                /*" -773- MOVE MOVDEBCE-DATA-VENCIMENTO TO WDATA-REL. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, W.WDATA_REL);
            }


            /*" -775- MOVE WDAT-REL-ANO TO MOVCC-ANO. */
            _.Move(W.FILLER_1.WDAT_REL_ANO, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANO);

            /*" -777- MOVE WDAT-REL-MES TO MOVCC-MES. */
            _.Move(W.FILLER_1.WDAT_REL_MES, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MES);

            /*" -780- MOVE WDAT-REL-DIA TO MOVCC-DIA. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIA);

            /*" -782- MOVE MOVDEBCE-VALOR-DEBITO TO MOVCC-VLDEBCRE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

            /*" -784- ADD MOVDEBCE-VALOR-DEBITO TO AC-VLRTOTDEB. */
            W.AC_VLRTOTDEB.Value = W.AC_VLRTOTDEB + MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO;

            /*" -786- MOVE '00' TO MOVCC-CODMOEDA. */
            _.Move("00", MOVCC_REGISTRO.MOVCC_CODMOEDA);

            /*" -788- MOVE ANT-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(W.ANT_CONVENIO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_CONVENIO);

            /*" -790- MOVE PARAMCON-NSAS TO MOVCC-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_NSAS);

            /*" -792- MOVE AC-TOTREGISTRO TO MOVCC-NRSEQ. */
            _.Move(W.AC_TOTREGISTRO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_NRSEQ);

            /*" -794- MOVE ENDOSSOS-COD-PRODUTO TO MOVCC-CODPRODU. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_CODPRODU);

            /*" -796- MOVE MOVDEBCE-NUM-CARTAO TO MOVCC-NUM-TOKEN. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_NUM_TOKEN);

            /*" -798- MOVE MOVDEBCE-STATUS-CARTAO TO MOVCC-TIPO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_TIPO);

            /*" -802- MOVE '0' TO MOVCC-CODMOV. */
            _.Move("0", MOVCC_REGISTRO.MOVCC_CODMOV);

            /*" -803- MOVE MOVCC-REGISTRO TO REG-MOV023000 */
            _.Move(MOVCC_REGISTRO, REG_MOV023000);

            /*" -806- WRITE REG-MOV023000. */
            MOV023000_CC.Write(REG_MOV023000.GetMoveValues().ToString());

            /*" -815- PERFORM R0610-00-UPDATE-V0MOVDEBCE. */

            R0610_00_UPDATE_V0MOVDEBCE_SECTION();

            /*" -817- MOVE MOVDEBCE-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -820- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -823- PERFORM R0650-00-SELECT-ENDOSSOS. */

            R0650_00_SELECT_ENDOSSOS_SECTION();

            /*" -824- IF ENDOSSOS-QTD-PARCELAS NOT EQUAL 60 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS != 60)
            {

                /*" -830- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -831- IF MOVDEBCE-NUM-ENDOSSO EQUAL 60 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO == 60)
            {

                /*" -838- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -840- MOVE ANT-CONVENIO TO SAI-COD-CONVENIO. */
            _.Move(W.ANT_CONVENIO, REG_BI6254B.SAI_COD_CONVENIO);

            /*" -842- MOVE PARAMCON-NSAS TO SAI-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, REG_BI6254B.SAI_NSAS);

            /*" -844- MOVE MOVDEBCE-NUM-APOLICE TO SAI-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REG_BI6254B.SAI_NUM_APOLICE);

            /*" -846- MOVE MOVDEBCE-NUM-ENDOSSO TO SAI-NUM-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REG_BI6254B.SAI_NUM_ENDOSSO);

            /*" -848- MOVE MOVDEBCE-NUM-PARCELA TO SAI-NUM-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REG_BI6254B.SAI_NUM_PARCELA);

            /*" -850- MOVE MOVDEBCE-DIA-DEBITO TO SAI-DIA-DEBITO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO, REG_BI6254B.SAI_DIA_DEBITO);

            /*" -854- MOVE ENDOSSOS-COD-PRODUTO TO SAI-COD-PRODUTO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, REG_BI6254B.SAI_COD_PRODUTO);

            /*" -855- WRITE REG-BI6254B. */
            BI6254B1.Write(REG_BI6254B.GetMoveValues().ToString());

            /*" -855- ADD 1 TO GV-SAIDA. */
            W.GV_SAIDA.Value = W.GV_SAIDA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R0610_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -868- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", W.WABEND.WNR_EXEC_SQL);

            /*" -882- PERFORM R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -886- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -887- DISPLAY 'R0610-00 - PROBLEMAS NO UPDATE(MOVDEBCE)' */
                _.Display($"R0610-00 - PROBLEMAS NO UPDATE(MOVDEBCE)");

                /*" -887- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0610-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -882- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = '1' , TIMESTAMP = CURRENT TIMESTAMP, DATA_ENVIO = :SISTEMAS-DATA-MOV-ABERTO, NSAS = :PARAMCON-NSAS, COD_USUARIO = 'BI6254B' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND DATA_VENCIMENTO = :MOVDEBCE-DATA-VENCIMENTO AND NUM_CARTAO = :MOVDEBCE-NUM-CARTAO END-EXEC. */

            var r0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
            };

            R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-SELECT-ENDOSSOS-SECTION */
        private void R0650_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -900- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", W.WABEND.WNR_EXEC_SQL);

            /*" -909- PERFORM R0650_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0650_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -913- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -915- MOVE ZEROS TO ENDOSSOS-QTD-PARCELAS */
                _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);

                /*" -916- ELSE */
            }
            else
            {


                /*" -917- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -918- DISPLAY 'R0650-00 - PROBLEMAS SELECT  (ENDOSSOS)' */
                    _.Display($"R0650-00 - PROBLEMAS SELECT  (ENDOSSOS)");

                    /*" -918- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0650-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0650_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -909- EXEC SQL SELECT QTD_PARCELAS INTO :ENDOSSOS-QTD-PARCELAS FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0650_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-GRAVA-HEADER-SECTION */
        private void R8000_00_GRAVA_HEADER_SECTION()
        {
            /*" -931- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", W.WABEND.WNR_EXEC_SQL);

            /*" -933- MOVE 1 TO AC-TOTARQUIVO. */
            _.Move(1, W.AC_TOTARQUIVO);

            /*" -935- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -937- MOVE 'A' TO HEADER-CODREGISTRO. */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -939- MOVE '1' TO HEADER-CODREMESSA. */
            _.Move("1", HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -941- MOVE ANT-CONVENIO TO HEADER-CONVENIO. */
            _.Move(W.ANT_CONVENIO, HEADER_REGISTRO.HEADER_CODCONVENIO.HEADER_CONVENIO);

            /*" -943- MOVE 'CAIXA SEGURADORA S/A' TO HEADER-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA S/A", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -945- MOVE '104' TO HEADER-CODBANCO. */
            _.Move("104", HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -947- MOVE 'SUPERPAY - CARTAO   ' TO HEADER-NOMBANCO. */
            _.Move("SUPERPAY - CARTAO   ", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -949- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -951- MOVE WDAT-REL-ANO TO HEADER-ANO. */
            _.Move(W.FILLER_1.WDAT_REL_ANO, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_ANO);

            /*" -953- MOVE WDAT-REL-MES TO HEADER-MES. */
            _.Move(W.FILLER_1.WDAT_REL_MES, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_MES);

            /*" -955- MOVE WDAT-REL-DIA TO HEADER-DIA. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_DIA);

            /*" -957- MOVE PARAMCON-NSAS TO HEADER-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, HEADER_REGISTRO.HEADER_NSAS);

            /*" -959- MOVE '04' TO HEADER-VERSAO. */
            _.Move("04", HEADER_REGISTRO.HEADER_VERSAO);

            /*" -963- MOVE 'DEB/CRED AUTOMAT ' TO HEADER-DEBCREDAUT. */
            _.Move("DEB/CRED AUTOMAT ", HEADER_REGISTRO.HEADER_DEBCREDAUT);

            /*" -965- MOVE 'SUPERPAY - CARTAO   ' TO HEADER-NOMEMPRESA */
            _.Move("SUPERPAY - CARTAO   ", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -966- MOVE HEADER-REGISTRO TO REG-MOV023000 */
            _.Move(HEADER_REGISTRO, REG_MOV023000);

            /*" -966- WRITE REG-MOV023000. */
            MOV023000_CC.Write(REG_MOV023000.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-GRAVA-TRAILLER-SECTION */
        private void R8100_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -979- MOVE '8100' TO WNR-EXEC-SQL. */
            _.Move("8100", W.WABEND.WNR_EXEC_SQL);

            /*" -981- ADD 1 TO AC-TOTARQUIVO. */
            W.AC_TOTARQUIVO.Value = W.AC_TOTARQUIVO + 1;

            /*" -983- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -985- MOVE 'Z' TO TRAILL-CODREGISTRO. */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -987- MOVE AC-TOTARQUIVO TO TRAILL-TOTREGISTRO. */
            _.Move(W.AC_TOTARQUIVO, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -989- MOVE AC-VLRTOTDEB TO TRAILL-VLRTOTDEB. */
            _.Move(W.AC_VLRTOTDEB, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -993- MOVE ZEROS TO TRAILL-VLRTOTCRE. */
            _.Move(0, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -994- MOVE TRAILL-REGISTRO TO REG-MOV023000 */
            _.Move(TRAILL_REGISTRO, REG_MOV023000);

            /*" -997- WRITE REG-MOV023000. */
            MOV023000_CC.Write(REG_MOV023000.GetMoveValues().ToString());

            /*" -997- PERFORM R8200-00-UPDATE-V0PARAMCON. */

            R8200_00_UPDATE_V0PARAMCON_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8200-00-UPDATE-V0PARAMCON-SECTION */
        private void R8200_00_UPDATE_V0PARAMCON_SECTION()
        {
            /*" -1010- MOVE '8200' TO WNR-EXEC-SQL. */
            _.Move("8200", W.WABEND.WNR_EXEC_SQL);

            /*" -1019- PERFORM R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1 */

            R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1();

            /*" -1023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1024- DISPLAY 'R8200-00 - PROBLEMAS NO UPDATE(PARAMCON)' */
                _.Display($"R8200-00 - PROBLEMAS NO UPDATE(PARAMCON)");

                /*" -1024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8200-00-UPDATE-V0PARAMCON-DB-UPDATE-1 */
        public void R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1()
        {
            /*" -1019- EXEC SQL UPDATE SEGUROS.PARAM_CONTACEF SET NSAS = :PARAMCON-NSAS, DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, DATA_PROXIMO_DEB = :WSHOST-DTMOVABE20, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC AND COD_PRODUTO = :PARAMCON-COD-PRODUTO AND COD_CONVENIO = :PARAMCON-COD-CONVENIO END-EXEC. */

            var r8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1 = new R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WSHOST_DTMOVABE20 = WSHOST_DTMOVABE20.ToString(),
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                PARAMCON_TIPO_MOVTO_CC = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                PARAMCON_COD_PRODUTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO.ToString(),
            };

            R8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1.Execute(r8200_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1035- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -1036- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -1037- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1039- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1039- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1044- CLOSE MOV023000-CC BI6254B1. */
            MOV023000_CC.Close();
            BI6254B1.Close();

            /*" -1046- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1046- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}