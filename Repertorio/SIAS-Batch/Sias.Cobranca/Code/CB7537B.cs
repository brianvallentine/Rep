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
using Sias.Cobranca.DB2.CB7537B;

namespace Code
{
    public class CB7537B
    {
        public bool IsCall { get; set; }

        public CB7537B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB7537B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  08/07/2003                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA ARQUIVO DAS COBRANCAS DE      *      */
        /*"      *                             RESSARCIMENTO PARA CONTABILIDADE.  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RESSARCIMENTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RESSARCIMENTO
        {
            get
            {
                _.Move(REG_RESSARCIMENTO, _RESSARCIMENTO); VarBasis.RedefinePassValue(REG_RESSARCIMENTO, _RESSARCIMENTO, REG_RESSARCIMENTO); return _RESSARCIMENTO;
            }
        }
        /*"01        REG-RESSARCIMENTO   PIC  X(150).*/
        public StringBasis REG_RESSARCIMENTO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  W.*/
        public CB7537B_W W { get; set; } = new CB7537B_W();
        public class CB7537B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-GRAVADOS               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_CB7537B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB7537B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB7537B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_CB7537B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB7537B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB7537B_WDATA_CABEC();
            public class CB7537B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER             PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER             PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC     PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WS-APOLICE         PIC  9(013)    VALUE   ZEROS.*/
            }
            public IntBasis WS_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      WS-APOLICE.*/
            private _REDEF_CB7537B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_CB7537B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_CB7537B_FILLER_5(); _.Move(WS_APOLICE, _filler_5); VarBasis.RedefinePassValue(WS_APOLICE, _filler_5, WS_APOLICE); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_APOLICE); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_APOLICE); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_5 : VarBasis
            {
                /*"    10       WS-NUMAPOL1        PIC  9(003).*/
                public IntBasis WS_NUMAPOL1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WS-NUMAPOL2        PIC  9(006).*/
                public IntBasis WS_NUMAPOL2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WS-NUMAPOL3        PIC  9(004).*/
                public IntBasis WS_NUMAPOL3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WS-NRPARCEL        PIC  9(004)    VALUE   ZEROS.*/

                public _REDEF_CB7537B_FILLER_5()
                {
                    WS_NUMAPOL1.ValueChanged += OnValueChanged;
                    WS_NUMAPOL2.ValueChanged += OnValueChanged;
                    WS_NUMAPOL3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WS-NRTIT           PIC  9(011)    VALUE   ZEROS.*/
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  03         FILLER             REDEFINES      WS-NRTIT.*/
            private _REDEF_CB7537B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_CB7537B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_CB7537B_FILLER_6(); _.Move(WS_NRTIT, _filler_6); VarBasis.RedefinePassValue(WS_NRTIT, _filler_6, WS_NRTIT); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_NRTIT); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_6 : VarBasis
            {
                /*"    10       WS-NRTIT1          PIC  9(002).*/
                public IntBasis WS_NRTIT1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-NRTIT2          PIC  9(004).*/
                public IntBasis WS_NRTIT2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-NRTIT3          PIC  9(004).*/
                public IntBasis WS_NRTIT3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-NRTIT4          PIC  9(001).*/
                public IntBasis WS_NRTIT4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         AUX-TITULO         PIC  9(014)    VALUE   ZEROS.*/

                public _REDEF_CB7537B_FILLER_6()
                {
                    WS_NRTIT1.ValueChanged += OnValueChanged;
                    WS_NRTIT2.ValueChanged += OnValueChanged;
                    WS_NRTIT3.ValueChanged += OnValueChanged;
                    WS_NRTIT4.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_TITULO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      AUX-TITULO.*/
            private _REDEF_CB7537B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_CB7537B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_CB7537B_FILLER_7(); _.Move(AUX_TITULO, _filler_7); VarBasis.RedefinePassValue(AUX_TITULO, _filler_7, AUX_TITULO); _filler_7.ValueChanged += () => { _.Move(_filler_7, AUX_TITULO); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, AUX_TITULO); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_7 : VarBasis
            {
                /*"    10       AUX-NRTIT1         PIC  9(006).*/
                public IntBasis AUX_NRTIT1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       AUX-NRTIT2         PIC  9(004).*/
                public IntBasis AUX_NRTIT2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       AUX-NRTIT3         PIC  9(004).*/
                public IntBasis AUX_NRTIT3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         APO-APOLICE        PIC  9(013)    VALUE   ZEROS.*/

                public _REDEF_CB7537B_FILLER_7()
                {
                    AUX_NRTIT1.ValueChanged += OnValueChanged;
                    AUX_NRTIT2.ValueChanged += OnValueChanged;
                    AUX_NRTIT3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis APO_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      APO-APOLICE.*/
            private _REDEF_CB7537B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_CB7537B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_CB7537B_FILLER_8(); _.Move(APO_APOLICE, _filler_8); VarBasis.RedefinePassValue(APO_APOLICE, _filler_8, APO_APOLICE); _filler_8.ValueChanged += () => { _.Move(_filler_8, APO_APOLICE); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, APO_APOLICE); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_8 : VarBasis
            {
                /*"    10       APO-ORGAO          PIC  9(003).*/
                public IntBasis APO_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       APO-RAMO           PIC  9(002).*/
                public IntBasis APO_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       APO-NUMAPOL        PIC  9(006).*/
                public IntBasis APO_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       APO-NUMADIC        PIC  9(002).*/
                public IntBasis APO_NUMADIC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         TIT-TITULO         PIC  9(014)    VALUE   ZEROS.*/

                public _REDEF_CB7537B_FILLER_8()
                {
                    APO_ORGAO.ValueChanged += OnValueChanged;
                    APO_RAMO.ValueChanged += OnValueChanged;
                    APO_NUMAPOL.ValueChanged += OnValueChanged;
                    APO_NUMADIC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis TIT_TITULO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES      TIT-TITULO.*/
            private _REDEF_CB7537B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_CB7537B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_CB7537B_FILLER_9(); _.Move(TIT_TITULO, _filler_9); VarBasis.RedefinePassValue(TIT_TITULO, _filler_9, TIT_TITULO); _filler_9.ValueChanged += () => { _.Move(_filler_9, TIT_TITULO); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, TIT_TITULO); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_9 : VarBasis
            {
                /*"    10       TIT-RAMO           PIC  9(002).*/
                public IntBasis TIT_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       TIT-NUMAPOL        PIC  9(006).*/
                public IntBasis TIT_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       TIT-NUMADIC        PIC  9(002).*/
                public IntBasis TIT_NUMADIC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       TIT-NRPARCEL       PIC  9(004).*/
                public IntBasis TIT_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         SIN-APOLICE        PIC  9(013)    VALUE   ZEROS.*/

                public _REDEF_CB7537B_FILLER_9()
                {
                    TIT_RAMO.ValueChanged += OnValueChanged;
                    TIT_NUMAPOL.ValueChanged += OnValueChanged;
                    TIT_NUMADIC.ValueChanged += OnValueChanged;
                    TIT_NRPARCEL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis SIN_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      SIN-APOLICE.*/
            private _REDEF_CB7537B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_CB7537B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_CB7537B_FILLER_10(); _.Move(SIN_APOLICE, _filler_10); VarBasis.RedefinePassValue(SIN_APOLICE, _filler_10, SIN_APOLICE); _filler_10.ValueChanged += () => { _.Move(_filler_10, SIN_APOLICE); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, SIN_APOLICE); }
            }  //Redefines
            public class _REDEF_CB7537B_FILLER_10 : VarBasis
            {
                /*"    10       SIN-ORGAO          PIC  9(003).*/
                public IntBasis SIN_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       SIN-RAMO           PIC  9(002).*/
                public IntBasis SIN_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-ZERO           PIC  9(002).*/
                public IntBasis SIN_ZERO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       SIN-NUMAPOL        PIC  9(006).*/
                public IntBasis SIN_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  03        WABEND.*/

                public _REDEF_CB7537B_FILLER_10()
                {
                    SIN_ORGAO.ValueChanged += OnValueChanged;
                    SIN_RAMO.ValueChanged += OnValueChanged;
                    SIN_ZERO.ValueChanged += OnValueChanged;
                    SIN_NUMAPOL.ValueChanged += OnValueChanged;
                }

            }
            public CB7537B_WABEND WABEND { get; set; } = new CB7537B_WABEND();
            public class CB7537B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB7537B  '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB7537B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03          LC01.*/
            }
            public CB7537B_LC01 LC01 { get; set; } = new CB7537B_LC01();
            public class CB7537B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(138)  VALUE ALL '-'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)"), @"ALL");
                /*"    10        FILLER              PIC  X(012)  VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"  03          LC02.*/
            }
            public CB7537B_LC02 LC02 { get; set; } = new CB7537B_LC02();
            public class CB7537B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(007)  VALUE             'BANCO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BANCO");
                /*"    10        FILLER              PIC  X(013)  VALUE             'AGENCIA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"AGENCIA");
                /*"    10        FILLER              PIC  X(009)  VALUE             'NRAVISO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NRAVISO");
                /*"    10        FILLER              PIC  X(018)  VALUE             'QUITACAO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"QUITACAO");
                /*"    10        FILLER              PIC  X(014)  VALUE             'TITULO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"TITULO");
                /*"    10        FILLER              PIC  X(009)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(008)  VALUE             'FILIAL'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"FILIAL");
                /*"    10        FILLER              PIC  X(006)  VALUE             'RAMO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"RAMO");
                /*"    10        FILLER              PIC  X(017)  VALUE             'PRODUTO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"PRODUTO");
                /*"    10        FILLER              PIC  X(013)  VALUE             'BRUTO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"BRUTO");
                /*"    10        FILLER              PIC  X(017)  VALUE             'DESPESAS'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DESPESAS");
                /*"    10        FILLER              PIC  X(008)  VALUE             'LIQUIDO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LIQUIDO");
                /*"    10        FILLER              PIC  X(011)  VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"01        REG-SAIDA.*/
            }
        }
        public CB7537B_REG_SAIDA REG_SAIDA { get; set; } = new CB7537B_REG_SAIDA();
        public class CB7537B_REG_SAIDA : VarBasis
        {
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-COD-BANCO       PIC  9(003).*/
            public IntBasis SAI_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      FILLER              PIC  X(005).*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"  05      SAI-COD-AGENCIA     PIC  9(004).*/
            public IntBasis SAI_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-NUM-AVISO       PIC  9(009).*/
            public IntBasis SAI_NUM_AVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-DATA-QUITACAO   PIC  X(010).*/
            public StringBasis SAI_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-NUM-TITULO      PIC  9(014).*/
            public IntBasis SAI_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-NUM-APOLICE     PIC  9(013).*/
            public IntBasis SAI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      FILLER              PIC  X(004).*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      SAI-COD-FONTE       PIC  9(004).*/
            public IntBasis SAI_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-RAMO-EMISSOR    PIC  9(004).*/
            public IntBasis SAI_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER              PIC  X(005).*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"  05      SAI-COD-PRODUTO     PIC  9(004).*/
            public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-VAL-TITULO      PIC  ZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis SAI_VAL_TITULO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-VAL-DESPESA     PIC  ZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis SAI_VAL_DESPESA { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
            /*"  05      FILLER              PIC  X(002).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      SAI-VAL-CREDITO     PIC  ZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis SAI_VAL_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
            /*"  05      FILLER              PIC  X(011).*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public CB7537B_V0MOVICOB V0MOVICOB { get; set; } = new CB7537B_V0MOVICOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RESSARCIMENTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RESSARCIMENTO.SetFile(RESSARCIMENTO_FILE_NAME_P);

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
            /*" -218- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -221- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -223- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -229- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -230- MOVE SPACES TO WFIM-MOVIMENTO */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -232- PERFORM R0250-00-DECLARE-V0MOVICOB. */

            R0250_00_DECLARE_V0MOVICOB_SECTION();

            /*" -235- PERFORM R0260-00-FETCH-V0MOVICOB. */

            R0260_00_FETCH_V0MOVICOB_SECTION();

            /*" -236- PERFORM R0350-00-PROCESSA-V0MOVICOB UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_V0MOVICOB_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -241- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -245- CLOSE RESSARCIMENTO. */
            RESSARCIMENTO.Close();

            /*" -247- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -248- DISPLAY ' ' */
            _.Display($" ");

            /*" -249- DISPLAY 'CB7537B - FIM NORMAL' . */
            _.Display($"CB7537B - FIM NORMAL");

            /*" -250- DISPLAY ' ' */
            _.Display($" ");

            /*" -251- DISPLAY 'LIDOS MOVIMENTO ....... ' LD-MOVIMENTO */
            _.Display($"LIDOS MOVIMENTO ....... {W.LD_MOVIMENTO}");

            /*" -252- DISPLAY 'REGISTROS GRAVADOS .... ' AC-GRAVADOS */
            _.Display($"REGISTROS GRAVADOS .... {W.AC_GRAVADOS}");

            /*" -253- DISPLAY ' ' */
            _.Display($" ");

            /*" -254- DISPLAY 'CB7537B - FIM NORMAL' . */
            _.Display($"CB7537B - FIM NORMAL");

            /*" -257- DISPLAY ' ' */
            _.Display($" ");

            /*" -257- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -270- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -273- OPEN OUTPUT RESSARCIMENTO. */
            RESSARCIMENTO.Open(REG_RESSARCIMENTO);

            /*" -276- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -278- MOVE LC01 TO REG-RESSARCIMENTO. */
            _.Move(W.LC01, REG_RESSARCIMENTO);

            /*" -280- WRITE REG-RESSARCIMENTO. */
            RESSARCIMENTO.Write(REG_RESSARCIMENTO.GetMoveValues().ToString());

            /*" -282- MOVE LC02 TO REG-RESSARCIMENTO. */
            _.Move(W.LC02, REG_RESSARCIMENTO);

            /*" -284- WRITE REG-RESSARCIMENTO. */
            RESSARCIMENTO.Write(REG_RESSARCIMENTO.GetMoveValues().ToString());

            /*" -286- MOVE LC01 TO REG-RESSARCIMENTO. */
            _.Move(W.LC01, REG_RESSARCIMENTO);

            /*" -289- WRITE REG-RESSARCIMENTO. */
            RESSARCIMENTO.Write(REG_RESSARCIMENTO.GetMoveValues().ToString());

            /*" -289- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -302- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -310- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -315- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -318- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -320- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -321- MOVE 01 TO WDAT-REL-DIA. */
            _.Move(01, W.FILLER_0.WDAT_REL_DIA);

            /*" -322- MOVE WDATA-REL TO SISTEMAS-DATA-MOV-ABERTO. */
            _.Move(W.WDATA_REL, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -310- EXEC SQL SELECT (DATA_MOV_ABERTO - 1 MONTH) , DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-DECLARE-V0MOVICOB-SECTION */
        private void R0250_00_DECLARE_V0MOVICOB_SECTION()
        {
            /*" -335- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", W.WABEND.WNR_EXEC_SQL);

            /*" -353- PERFORM R0250_00_DECLARE_V0MOVICOB_DB_DECLARE_1 */

            R0250_00_DECLARE_V0MOVICOB_DB_DECLARE_1();

            /*" -355- PERFORM R0250_00_DECLARE_V0MOVICOB_DB_OPEN_1 */

            R0250_00_DECLARE_V0MOVICOB_DB_OPEN_1();

            /*" -359- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -360- DISPLAY 'R0250-00 - PROBLEMAS DECLARE (V0MOVICOV) ' */
                _.Display($"R0250-00 - PROBLEMAS DECLARE (V0MOVICOV) ");

                /*" -360- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0250-00-DECLARE-V0MOVICOB-DB-DECLARE-1 */
        public void R0250_00_DECLARE_V0MOVICOB_DB_DECLARE_1()
        {
            /*" -353- EXEC SQL DECLARE V0MOVICOB CURSOR FOR SELECT COD_BANCO , COD_AGENCIA , NUM_AVISO , DATA_QUITACAO , NUM_TITULO , NUM_APOLICE , NUM_PARCELA , VAL_TITULO , VAL_CREDITO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = 104 AND COD_AGENCIA = 7003 AND DATA_MOVIMENTO >= :SISTEMAS-DATA-MOV-ABERTO AND DATA_MOVIMENTO <= :SISTEMAS-DATULT-PROCESSAMEN ORDER BY COD_BANCO, COD_AGENCIA, NUM_AVISO, NUM_APOLICE END-EXEC. */
            V0MOVICOB = new CB7537B_V0MOVICOB(true);
            string GetQuery_V0MOVICOB()
            {
                var query = @$"SELECT COD_BANCO
							, 
							COD_AGENCIA
							, 
							NUM_AVISO
							, 
							DATA_QUITACAO
							, 
							NUM_TITULO
							, 
							NUM_APOLICE
							, 
							NUM_PARCELA
							, 
							VAL_TITULO
							, 
							VAL_CREDITO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE COD_BANCO = 104 
							AND COD_AGENCIA = 7003 
							AND DATA_MOVIMENTO >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DATA_MOVIMENTO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}' 
							ORDER BY COD_BANCO
							, COD_AGENCIA
							, NUM_AVISO
							, NUM_APOLICE";

                return query;
            }
            V0MOVICOB.GetQueryEvent += GetQuery_V0MOVICOB;

        }

        [StopWatch]
        /*" R0250-00-DECLARE-V0MOVICOB-DB-OPEN-1 */
        public void R0250_00_DECLARE_V0MOVICOB_DB_OPEN_1()
        {
            /*" -355- EXEC SQL OPEN V0MOVICOB END-EXEC. */

            V0MOVICOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-FETCH-V0MOVICOB-SECTION */
        private void R0260_00_FETCH_V0MOVICOB_SECTION()
        {
            /*" -373- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", W.WABEND.WNR_EXEC_SQL);

            /*" -383- PERFORM R0260_00_FETCH_V0MOVICOB_DB_FETCH_1 */

            R0260_00_FETCH_V0MOVICOB_DB_FETCH_1();

            /*" -387- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -387- PERFORM R0260_00_FETCH_V0MOVICOB_DB_CLOSE_1 */

                R0260_00_FETCH_V0MOVICOB_DB_CLOSE_1();

                /*" -389- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -391- GO TO R0260-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/ //GOTO
                return;
            }


            /*" -392- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -393- DISPLAY 'R0260-00 - PROBLEMAS FETCH (V0MOVICOB)   ' */
                _.Display($"R0260-00 - PROBLEMAS FETCH (V0MOVICOB)   ");

                /*" -396- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -396- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

        }

        [StopWatch]
        /*" R0260-00-FETCH-V0MOVICOB-DB-FETCH-1 */
        public void R0260_00_FETCH_V0MOVICOB_DB_FETCH_1()
        {
            /*" -383- EXEC SQL FETCH V0MOVICOB INTO :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-CREDITO END-EXEC. */

            if (V0MOVICOB.Fetch())
            {
                _.Move(V0MOVICOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVICOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVICOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVICOB.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(V0MOVICOB.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(V0MOVICOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVICOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVICOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVICOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
            }

        }

        [StopWatch]
        /*" R0260-00-FETCH-V0MOVICOB-DB-CLOSE-1 */
        public void R0260_00_FETCH_V0MOVICOB_DB_CLOSE_1()
        {
            /*" -387- EXEC SQL CLOSE V0MOVICOB END-EXEC */

            V0MOVICOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-V0MOVICOB-SECTION */
        private void R0350_00_PROCESSA_V0MOVICOB_SECTION()
        {
            /*" -409- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -411- MOVE SPACES TO REG-SAIDA. */
            _.Move("", REG_SAIDA);

            /*" -413- MOVE MOVIMCOB-COD-BANCO TO SAI-COD-BANCO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, REG_SAIDA.SAI_COD_BANCO);

            /*" -415- MOVE MOVIMCOB-COD-AGENCIA TO SAI-COD-AGENCIA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, REG_SAIDA.SAI_COD_AGENCIA);

            /*" -417- MOVE MOVIMCOB-NUM-AVISO TO SAI-NUM-AVISO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, REG_SAIDA.SAI_NUM_AVISO);

            /*" -419- MOVE MOVIMCOB-VAL-TITULO TO SAI-VAL-TITULO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, REG_SAIDA.SAI_VAL_TITULO);

            /*" -422- MOVE MOVIMCOB-VAL-CREDITO TO SAI-VAL-CREDITO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO, REG_SAIDA.SAI_VAL_CREDITO);

            /*" -424- COMPUTE MOVIMCOB-VAL-TITULO EQUAL (MOVIMCOB-VAL-TITULO - MOVIMCOB-VAL-CREDITO). */
            MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO.Value = (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO - MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);

            /*" -427- MOVE MOVIMCOB-VAL-TITULO TO SAI-VAL-DESPESA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO, REG_SAIDA.SAI_VAL_DESPESA);

            /*" -429- MOVE MOVIMCOB-DATA-QUITACAO TO WDATA-REL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO, W.WDATA_REL);

            /*" -430- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -431- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_0.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -432- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC. */
            _.Move(W.FILLER_0.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -436- MOVE WDATA-CABEC TO SAI-DATA-QUITACAO. */
            _.Move(W.WDATA_CABEC, REG_SAIDA.SAI_DATA_QUITACAO);

            /*" -438- MOVE MOVIMCOB-NUM-APOLICE TO APO-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, W.APO_APOLICE);

            /*" -439- MOVE APO-RAMO TO TIT-RAMO */
            _.Move(W.FILLER_8.APO_RAMO, W.FILLER_9.TIT_RAMO);

            /*" -440- MOVE APO-NUMAPOL TO TIT-NUMAPOL */
            _.Move(W.FILLER_8.APO_NUMAPOL, W.FILLER_9.TIT_NUMAPOL);

            /*" -441- MOVE APO-NUMADIC TO TIT-NUMADIC. */
            _.Move(W.FILLER_8.APO_NUMADIC, W.FILLER_9.TIT_NUMADIC);

            /*" -445- MOVE MOVIMCOB-NUM-PARCELA TO TIT-NRPARCEL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, W.FILLER_9.TIT_NRPARCEL);

            /*" -447- MOVE MOVIMCOB-NUM-APOLICE TO WS-APOLICE. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, W.WS_APOLICE);

            /*" -449- MOVE MOVIMCOB-NUM-PARCELA TO WS-NRPARCEL. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA, W.WS_NRPARCEL);

            /*" -452- MOVE MOVIMCOB-NUM-TITULO TO WS-NRTIT. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO, W.WS_NRTIT);

            /*" -454- IF WS-NRTIT2 EQUAL WS-NUMAPOL3 AND WS-NRTIT3 EQUAL WS-NRPARCEL */

            if (W.FILLER_6.WS_NRTIT2 == W.FILLER_5.WS_NUMAPOL3 && W.FILLER_6.WS_NRTIT3 == W.WS_NRPARCEL)
            {

                /*" -455- MOVE WS-NUMAPOL2 TO AUX-NRTIT1 */
                _.Move(W.FILLER_5.WS_NUMAPOL2, W.FILLER_7.AUX_NRTIT1);

                /*" -456- MOVE WS-NRTIT2 TO AUX-NRTIT2 */
                _.Move(W.FILLER_6.WS_NRTIT2, W.FILLER_7.AUX_NRTIT2);

                /*" -457- MOVE WS-NRTIT3 TO AUX-NRTIT3 */
                _.Move(W.FILLER_6.WS_NRTIT3, W.FILLER_7.AUX_NRTIT3);

                /*" -459- MOVE AUX-TITULO TO SAI-NUM-TITULO */
                _.Move(W.AUX_TITULO, REG_SAIDA.SAI_NUM_TITULO);

                /*" -460- ELSE */
            }
            else
            {


                /*" -464- MOVE TIT-TITULO TO SAI-NUM-TITULO. */
                _.Move(W.TIT_TITULO, REG_SAIDA.SAI_NUM_TITULO);
            }


            /*" -467- PERFORM R0520-00-SELECT-SINISMES. */

            R0520_00_SELECT_SINISMES_SECTION();

            /*" -469- MOVE SINISMES-NUM-APOL-SINISTRO TO SAI-NUM-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REG_SAIDA.SAI_NUM_APOLICE);

            /*" -471- MOVE SINISMES-COD-FONTE TO SAI-COD-FONTE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, REG_SAIDA.SAI_COD_FONTE);

            /*" -473- MOVE PRODUTO-RAMO-EMISSOR TO SAI-RAMO-EMISSOR. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR, REG_SAIDA.SAI_RAMO_EMISSOR);

            /*" -476- MOVE PRODUTO-COD-PRODUTO TO SAI-COD-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, REG_SAIDA.SAI_COD_PRODUTO);

            /*" -478- MOVE REG-SAIDA TO REG-RESSARCIMENTO. */
            _.Move(REG_SAIDA, REG_RESSARCIMENTO);

            /*" -479- WRITE REG-RESSARCIMENTO. */
            RESSARCIMENTO.Write(REG_RESSARCIMENTO.GetMoveValues().ToString());

            /*" -479- ADD 1 TO AC-GRAVADOS. */
            W.AC_GRAVADOS.Value = W.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -484- PERFORM R0260-00-FETCH-V0MOVICOB. */

            R0260_00_FETCH_V0MOVICOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-SELECT-SINISMES-SECTION */
        private void R0520_00_SELECT_SINISMES_SECTION()
        {
            /*" -496- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -497- MOVE APO-ORGAO TO SIN-ORGAO */
            _.Move(W.FILLER_8.APO_ORGAO, W.FILLER_10.SIN_ORGAO);

            /*" -498- MOVE APO-RAMO TO SIN-RAMO */
            _.Move(W.FILLER_8.APO_RAMO, W.FILLER_10.SIN_RAMO);

            /*" -499- MOVE ZEROS TO SIN-ZERO */
            _.Move(0, W.FILLER_10.SIN_ZERO);

            /*" -501- MOVE APO-NUMAPOL TO SIN-NUMAPOL. */
            _.Move(W.FILLER_8.APO_NUMAPOL, W.FILLER_10.SIN_NUMAPOL);

            /*" -505- MOVE SIN-APOLICE TO SINISMES-NUM-APOL-SINISTRO. */
            _.Move(W.SIN_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -517- PERFORM R0520_00_SELECT_SINISMES_DB_SELECT_1 */

            R0520_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -521- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- PERFORM R0530-00-SELECT-SINISMES. */

                R0530_00_SELECT_SINISMES_SECTION();
            }


        }

        [StopWatch]
        /*" R0520-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R0520_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -517- EXEC SQL SELECT A.COD_FONTE , B.COD_PRODUTO , B.RAMO_EMISSOR INTO :SINISMES-COD-FONTE , :PRODUTO-COD-PRODUTO , :PRODUTO-RAMO-EMISSOR FROM SEGUROS.SINISTRO_MESTRE A, SEGUROS.PRODUTO B WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND A.COD_PRODUTO = B.COD_PRODUTO WITH UR END-EXEC. */

            var r0520_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0520_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r0520_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0530-00-SELECT-SINISMES-SECTION */
        private void R0530_00_SELECT_SINISMES_SECTION()
        {
            /*" -534- MOVE '0530' TO WNR-EXEC-SQL. */
            _.Move("0530", W.WABEND.WNR_EXEC_SQL);

            /*" -538- MOVE APO-APOLICE TO SINISMES-NUM-APOL-SINISTRO. */
            _.Move(W.APO_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -550- PERFORM R0530_00_SELECT_SINISMES_DB_SELECT_1 */

            R0530_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -554- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -556- MOVE 10 TO SINISMES-COD-FONTE */
                _.Move(10, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);

                /*" -558- MOVE 99 TO PRODUTO-COD-PRODUTO PRODUTO-RAMO-EMISSOR. */
                _.Move(99, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }

        [StopWatch]
        /*" R0530-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R0530_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -550- EXEC SQL SELECT A.COD_FONTE , B.COD_PRODUTO , B.RAMO_EMISSOR INTO :SINISMES-COD-FONTE , :PRODUTO-COD-PRODUTO , :PRODUTO-RAMO-EMISSOR FROM SEGUROS.SINISTRO_MESTRE A, SEGUROS.PRODUTO B WHERE A.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND A.COD_PRODUTO = B.COD_PRODUTO WITH UR END-EXEC. */

            var r0530_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R0530_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r0530_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_RAMO_EMISSOR, PRODUTO.DCLPRODUTO.PRODUTO_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -569- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -570- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -571- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -573- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -573- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -577- CLOSE RESSARCIMENTO. */
            RESSARCIMENTO.Close();

            /*" -579- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -579- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}