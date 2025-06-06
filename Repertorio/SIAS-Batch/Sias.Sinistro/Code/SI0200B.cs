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
using Sias.Sinistro.DB2.SI0200B;

namespace Code
{
    public class SI0200B
    {
        public bool IsCall { get; set; }

        public SI0200B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *-----------------------------------------------------------*           */
        /*" ====>* MIGRACAO P/ COBOL II - FASE 1 - ITEM 3.2.A -> OK - ADRIANA            */
        /*"      *-----------------------------------------------------------*           */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  REGISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0200B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/96                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  INSERIR NA TABELA V0RELATORIOS OS  *      */
        /*"      *                             PEDIDOS DE RELATORIOS DO MES DE    *      */
        /*"      *                             FECHAMENTO.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO BARAN 27/01/97 : A DATA INICIAL PARA O RELATORIO     *      */
        /*"      *                            SI0821B FOI ALTERADO PARA:          *      */
        /*"      *                            '1995-03-27'                        *      */
        /*"      *                            CONFORME PEDIDO DO USUARIO (LUCIA). *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            VIEW                 ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          V1SISTEMA            INPUT   *      */
        /*"      * RELATORIOS                        V0RELATORIOS         I-O     *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO - ANO 2000          CONSEDA4           05/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-COD-EMPR               PIC S9(004)                 COMP*/
        public IntBasis VIND_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-PERI-RENOV             PIC S9(004)                 COMP*/
        public IntBasis VIND_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-PCT-AUMENTO            PIC S9(004)                 COMP*/
        public IntBasis VIND_PCT_AUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SIST-DTMOVABE             PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SIST-DTCURRENT            PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RELA-CODUSU               PIC  X(008).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0RELA-DT-SOLIC             PIC  X(010).*/
        public StringBasis V0RELA_DT_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RELA-IDSISTEM             PIC  X(002).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77  V0RELA-CODRELAT             PIC  X(008).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0RELA-NRCOPIAS             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-QTDE                 PIC S9(004)                 COMP*/
        public IntBasis V0RELA_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-PERI-INIC            PIC  X(010).*/
        public StringBasis V0RELA_PERI_INIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RELA-PERI-FINAL           PIC  X(010).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RELA-DATA-REFER           PIC  X(010).*/
        public StringBasis V0RELA_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RELA-MES-REFER            PIC S9(004)                 COMP*/
        public IntBasis V0RELA_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-ANO-REFER            PIC S9(004)                 COMP*/
        public IntBasis V0RELA_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-ORGAO                PIC S9(004)                 COMP*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-FONTE                PIC S9(004)                 COMP*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-CODPDT               PIC S9(009)                 COMP*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0RELA-RAMO                 PIC S9(004)                 COMP*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-MODALID              PIC S9(004)                 COMP*/
        public IntBasis V0RELA_MODALID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-CONGENER             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-NUM-APOL             PIC S9(013)               COMP-3*/
        public IntBasis V0RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0RELA-NRENDOS              PIC S9(009)                 COMP*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0RELA-NRPARCEL             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-NRCERTIF             PIC S9(015)               COMP-3*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0RELA-NRTIT                PIC S9(013)               COMP-3*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0RELA-CODSUBES             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-OPERACAO             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-COD-PLANO            PIC S9(004)                 COMP*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-OCORHIST             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-APOL-LIDER           PIC  X(015).*/
        public StringBasis V0RELA_APOL_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77  V0RELA-ENDS-LIDER           PIC  X(015).*/
        public StringBasis V0RELA_ENDS_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77  V0RELA-NRPARC-LID           PIC S9(004)                 COMP*/
        public IntBasis V0RELA_NRPARC_LID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-NUM-SINIST           PIC S9(013)               COMP-3*/
        public IntBasis V0RELA_NUM_SINIST { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0RELA-NSINI-LID            PIC  X(015).*/
        public StringBasis V0RELA_NSINI_LID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77  V0RELA-NUM-ORDEM            PIC S9(015)               COMP-3*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0RELA-CODUNIMO             PIC S9(004)                 COMP*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-CORRECAO             PIC  X(001).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0RELA-SITUACAO             PIC  X(001).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0RELA-PRV-DEF              PIC  X(001).*/
        public StringBasis V0RELA_PRV_DEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0RELA-ANAL-RESU            PIC  X(001).*/
        public StringBasis V0RELA_ANAL_RESU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0RELA-COD-EMPR             PIC S9(009)                 COMP*/
        public IntBasis V0RELA_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0RELA-PERI-RENOV           PIC S9(004)                 COMP*/
        public IntBasis V0RELA_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-PCT-AUMENTO          PIC S9(003)V9(2)          COMP-3*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"01           AREA-DE-WORK.*/
        public SI0200B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0200B_AREA_DE_WORK();
        public class SI0200B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WRESTO            PIC S9(003)    VALUE +0 COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_SI0200B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0200B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0200B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_SI0200B_FILLER_0 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W-DTMOVABE                PIC  X(010)  VALUE SPACES.*/

                public _REDEF_SI0200B_FILLER_0()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  FILLER                    REDEFINES    W-DTMOVABE.*/
            private _REDEF_SI0200B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_SI0200B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_SI0200B_FILLER_3(); _.Move(W_DTMOVABE, _filler_3); VarBasis.RedefinePassValue(W_DTMOVABE, _filler_3, W_DTMOVABE); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DTMOVABE); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_SI0200B_FILLER_3 : VarBasis
            {
                /*"    10       W-DTMOVABE-ANO      PIC  9(004).*/
                public IntBasis W_DTMOVABE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER              PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W-DTMOVABE-MES      PIC  9(002).*/
                public IntBasis W_DTMOVABE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W-DTMOVABE-DIA      PIC  9(002).*/
                public IntBasis W_DTMOVABE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W-DATA-PERI-INICIAL       PIC X(010)          VALUE SPACES*/

                public _REDEF_SI0200B_FILLER_3()
                {
                    W_DTMOVABE_ANO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    W_DTMOVABE_MES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    W_DTMOVABE_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  FILLER                    REDEFINES    W-DATA-PERI-INICIAL*/
            private _REDEF_SI0200B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_SI0200B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_SI0200B_FILLER_6(); _.Move(W_DATA_PERI_INICIAL, _filler_6); VarBasis.RedefinePassValue(W_DATA_PERI_INICIAL, _filler_6, W_DATA_PERI_INICIAL); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_DATA_PERI_INICIAL); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_DATA_PERI_INICIAL); }
            }  //Redefines
            public class _REDEF_SI0200B_FILLER_6 : VarBasis
            {
                /*"    10       W-PERI-INICIAL-ANO     PIC  9(004).*/
                public IntBasis W_PERI_INICIAL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W-PERI-INICIAL-BR1     PIC  X(001).*/
                public StringBasis W_PERI_INICIAL_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W-PERI-INICIAL-MES     PIC  9(002).*/
                public IntBasis W_PERI_INICIAL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W-PERI-INICIAL-BR2     PIC  X(001).*/
                public StringBasis W_PERI_INICIAL_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W-PERI-INICIAL-DIA     PIC  9(002).*/
                public IntBasis W_PERI_INICIAL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05  W-DATA-PERI-FINAL            PIC  X(010)      VALUE SPACES*/

                public _REDEF_SI0200B_FILLER_6()
                {
                    W_PERI_INICIAL_ANO.ValueChanged += OnValueChanged;
                    W_PERI_INICIAL_BR1.ValueChanged += OnValueChanged;
                    W_PERI_INICIAL_MES.ValueChanged += OnValueChanged;
                    W_PERI_INICIAL_BR2.ValueChanged += OnValueChanged;
                    W_PERI_INICIAL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  FILLER                    REDEFINES    W-DATA-PERI-FINAL.*/
            private _REDEF_SI0200B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_SI0200B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_SI0200B_FILLER_7(); _.Move(W_DATA_PERI_FINAL, _filler_7); VarBasis.RedefinePassValue(W_DATA_PERI_FINAL, _filler_7, W_DATA_PERI_FINAL); _filler_7.ValueChanged += () => { _.Move(_filler_7, W_DATA_PERI_FINAL); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, W_DATA_PERI_FINAL); }
            }  //Redefines
            public class _REDEF_SI0200B_FILLER_7 : VarBasis
            {
                /*"    10       W-PERI-FINAL-ANO     PIC  9(004).*/
                public IntBasis W_PERI_FINAL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W-PERI-FINAL-BR1     PIC  X(001).*/
                public StringBasis W_PERI_FINAL_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W-PERI-FINAL-MES     PIC  9(002).*/
                public IntBasis W_PERI_FINAL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W-PERI-FINAL-BR2     PIC  X(001).*/
                public StringBasis W_PERI_FINAL_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W-PERI-FINAL-DIA     PIC  9(002).*/
                public IntBasis W_PERI_FINAL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-DTSOLICIT   PIC  X(010)    VALUE SPACES.*/

                public _REDEF_SI0200B_FILLER_7()
                {
                    W_PERI_FINAL_ANO.ValueChanged += OnValueChanged;
                    W_PERI_FINAL_BR1.ValueChanged += OnValueChanged;
                    W_PERI_FINAL_MES.ValueChanged += OnValueChanged;
                    W_PERI_FINAL_BR2.ValueChanged += OnValueChanged;
                    W_PERI_FINAL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DTSOLICIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-DTSOLICIT.*/
            private _REDEF_SI0200B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_SI0200B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_SI0200B_FILLER_8(); _.Move(WDATA_DTSOLICIT, _filler_8); VarBasis.RedefinePassValue(WDATA_DTSOLICIT, _filler_8, WDATA_DTSOLICIT); _filler_8.ValueChanged += () => { _.Move(_filler_8, WDATA_DTSOLICIT); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WDATA_DTSOLICIT); }
            }  //Redefines
            public class _REDEF_SI0200B_FILLER_8 : VarBasis
            {
                /*"    10       WDATA-ANO-SOL     PIC  9(004).*/
                public IntBasis WDATA_ANO_SOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WDATA-BR1-SOL     PIC  X(001).*/
                public StringBasis WDATA_BR1_SOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MES-SOL     PIC  9(002).*/
                public IntBasis WDATA_MES_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-BR2-SOL     PIC  X(001).*/
                public StringBasis WDATA_BR2_SOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DIA-SOL     PIC  9(002).*/
                public IntBasis WDATA_DIA_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/

                public _REDEF_SI0200B_FILLER_8()
                {
                    WDATA_ANO_SOL.ValueChanged += OnValueChanged;
                    WDATA_BR1_SOL.ValueChanged += OnValueChanged;
                    WDATA_MES_SOL.ValueChanged += OnValueChanged;
                    WDATA_BR2_SOL.ValueChanged += OnValueChanged;
                    WDATA_DIA_SOL.ValueChanged += OnValueChanged;
                }

            }
            public SI0200B_WABEND WABEND { get; set; } = new SI0200B_WABEND();
            public class SI0200B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' SI0200B'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0200B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -216- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -219- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -222- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -222- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -228- PERFORM 000-00-SELECT-V1SISTEMA. */

            M_000_00_SELECT_V1SISTEMA_SECTION();

            /*" -229- PERFORM 000-00-DELETE-V0RELATORIO. */

            M_000_00_DELETE_V0RELATORIO_SECTION();

            /*" -230- PERFORM 000-00-MONTA-SOLIC-RELAT. */

            M_000_00_MONTA_SOLIC_RELAT_SECTION();

            /*" -232- PERFORM 000-00-GRAVA-SOLIC-RELAT. */

            M_000_00_GRAVA_SOLIC_RELAT_SECTION();

            /*" -233- EXEC SQL COMMIT WORK RELEASE END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -237- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -238- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -239- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -240- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -241- DISPLAY '//     ==>     SI0200B      <==        //' */
            _.Display($"//     ==>     SI0200B      <==        //");

            /*" -242- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -243- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -244- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -245- DISPLAY '// ==> GERACAO OK NA V0RELATORIOS  <== //' */
            _.Display($"// ==> GERACAO OK NA V0RELATORIOS  <== //");

            /*" -246- DISPLAY '//                                     //' */
            _.Display($"//                                     //");

            /*" -247- DISPLAY '/////////////////////////////////////////' */
            _.Display($"/////////////////////////////////////////");

            /*" -249- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -249- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-000-00-SELECT-V1SISTEMA-SECTION */
        private void M_000_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -256- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -261- PERFORM M_000_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            M_000_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -264- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -265- DISPLAY 'ERRO NO SELECT DA V1SISTEMA......' */
                _.Display($"ERRO NO SELECT DA V1SISTEMA......");

                /*" -267- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -270- MOVE V1SIST-DTMOVABE TO W-DTMOVABE W-DATA-PERI-INICIAL W-DATA-PERI-FINAL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.W_DTMOVABE, AREA_DE_WORK.W_DATA_PERI_INICIAL, AREA_DE_WORK.W_DATA_PERI_FINAL);

            /*" -271- DISPLAY '===========================================' . */
            _.Display($"===========================================");

            /*" -272- DISPLAY '==>  DATA DO SISTEMA PARA O FECHAMENTO  <==' . */
            _.Display($"==>  DATA DO SISTEMA PARA O FECHAMENTO  <==");

            /*" -273- DISPLAY '===========================================' . */
            _.Display($"===========================================");

            /*" -275- DISPLAY 'V1SIST-DTMOVABE = ' V1SIST-DTMOVABE. */
            _.Display($"V1SIST-DTMOVABE = {V1SIST_DTMOVABE}");

            /*" -277- MOVE 01 TO W-PERI-INICIAL-DIA. */
            _.Move(01, AREA_DE_WORK.FILLER_6.W_PERI_INICIAL_DIA);

            /*" -278- IF W-DTMOVABE-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.FILLER_3.W_DTMOVABE_MES.In("04", "06", "09", "11"))
            {

                /*" -279- MOVE 30 TO W-PERI-FINAL-DIA */
                _.Move(30, AREA_DE_WORK.FILLER_7.W_PERI_FINAL_DIA);

                /*" -280- ELSE */
            }
            else
            {


                /*" -281- IF W-DTMOVABE-MES EQUAL 02 */

                if (AREA_DE_WORK.FILLER_3.W_DTMOVABE_MES == 02)
                {

                    /*" -285- COMPUTE WRESTO = W-DTMOVABE-ANO - (W-DTMOVABE-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.FILLER_3.W_DTMOVABE_ANO - (AREA_DE_WORK.FILLER_3.W_DTMOVABE_ANO / 4 * 4);

                    /*" -286- IF WRESTO EQUAL ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -287- MOVE 29 TO W-PERI-FINAL-DIA */
                        _.Move(29, AREA_DE_WORK.FILLER_7.W_PERI_FINAL_DIA);

                        /*" -288- ELSE */
                    }
                    else
                    {


                        /*" -289- MOVE 28 TO W-PERI-FINAL-DIA */
                        _.Move(28, AREA_DE_WORK.FILLER_7.W_PERI_FINAL_DIA);

                        /*" -290- ELSE */
                    }

                }
                else
                {


                    /*" -292- MOVE 31 TO W-PERI-FINAL-DIA. */
                    _.Move(31, AREA_DE_WORK.FILLER_7.W_PERI_FINAL_DIA);
                }

            }


            /*" -293- MOVE V1SIST-DTCURRENT TO WDATA-CURR */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -294- MOVE WDATA-DD-CURR TO WDATA-DIA-SOL. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.FILLER_8.WDATA_DIA_SOL);

            /*" -295- MOVE WDATA-MM-CURR TO WDATA-MES-SOL. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.FILLER_8.WDATA_MES_SOL);

            /*" -297- MOVE WDATA-AA-CURR TO WDATA-ANO-SOL. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.FILLER_8.WDATA_ANO_SOL);

            /*" -303- MOVE '-' TO W-PERI-INICIAL-BR1 W-PERI-INICIAL-BR2 W-PERI-FINAL-BR1 W-PERI-FINAL-BR2 WDATA-BR1-SOL WDATA-BR2-SOL. */
            _.Move("-", AREA_DE_WORK.FILLER_6.W_PERI_INICIAL_BR1);
            _.Move("-", AREA_DE_WORK.FILLER_6.W_PERI_INICIAL_BR2);
            _.Move("-", AREA_DE_WORK.FILLER_7.W_PERI_FINAL_BR1);
            _.Move("-", AREA_DE_WORK.FILLER_7.W_PERI_FINAL_BR2);
            _.Move("-", AREA_DE_WORK.FILLER_8.WDATA_BR1_SOL);
            _.Move("-", AREA_DE_WORK.FILLER_8.WDATA_BR2_SOL);


            /*" -304- DISPLAY 'DATA PERI INICIAL = ' W-DATA-PERI-INICIAL. */
            _.Display($"DATA PERI INICIAL = {AREA_DE_WORK.W_DATA_PERI_INICIAL}");

            /*" -304- DISPLAY 'DATA PERI FINAL   = ' W-DATA-PERI-FINAL. */
            _.Display($"DATA PERI FINAL   = {AREA_DE_WORK.W_DATA_PERI_FINAL}");

        }

        [StopWatch]
        /*" M-000-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void M_000_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -261- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var m_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new M_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(m_000_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" M-000-00-DELETE-V0RELATORIO-SECTION */
        private void M_000_00_DELETE_V0RELATORIO_SECTION()
        {
            /*" -311- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -315- PERFORM M_000_00_DELETE_V0RELATORIO_DB_DELETE_1 */

            M_000_00_DELETE_V0RELATORIO_DB_DELETE_1();

            /*" -318- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -320- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -321- ELSE */
                }
                else
                {


                    /*" -322- DISPLAY 'ERRO NO DELETE DA VORELATORIOS ......' */
                    _.Display($"ERRO NO DELETE DA VORELATORIOS ......");

                    /*" -322- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-000-00-DELETE-V0RELATORIO-DB-DELETE-1 */
        public void M_000_00_DELETE_V0RELATORIO_DB_DELETE_1()
        {
            /*" -315- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'SI' AND CODUSU = 'SI0200B' END-EXEC. */

            var m_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 = new M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1()
            {
            };

            M_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1.Execute(m_000_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" M-000-00-MONTA-SOLIC-RELAT-SECTION */
        private void M_000_00_MONTA_SOLIC_RELAT_SECTION()
        {
            /*" -328- MOVE 'SI0200B ' TO V0RELA-CODUSU. */
            _.Move("SI0200B ", V0RELA_CODUSU);

            /*" -329- MOVE W-DTMOVABE TO V0RELA-DT-SOLIC. */
            _.Move(AREA_DE_WORK.W_DTMOVABE, V0RELA_DT_SOLIC);

            /*" -330- MOVE SPACES TO V0RELA-IDSISTEM. */
            _.Move("", V0RELA_IDSISTEM);

            /*" -332- MOVE ZEROS TO V0RELA-NRCOPIAS V0RELA-QTDE. */
            _.Move(0, V0RELA_NRCOPIAS, V0RELA_QTDE);

            /*" -333- MOVE W-DATA-PERI-INICIAL TO V0RELA-PERI-INIC. */
            _.Move(AREA_DE_WORK.W_DATA_PERI_INICIAL, V0RELA_PERI_INIC);

            /*" -335- MOVE W-DATA-PERI-FINAL TO V0RELA-PERI-FINAL V0RELA-DATA-REFER. */
            _.Move(AREA_DE_WORK.W_DATA_PERI_FINAL, V0RELA_PERI_FINAL, V0RELA_DATA_REFER);

            /*" -336- MOVE W-DTMOVABE-MES TO V0RELA-MES-REFER. */
            _.Move(AREA_DE_WORK.FILLER_3.W_DTMOVABE_MES, V0RELA_MES_REFER);

            /*" -337- MOVE W-DTMOVABE-ANO TO V0RELA-ANO-REFER. */
            _.Move(AREA_DE_WORK.FILLER_3.W_DTMOVABE_ANO, V0RELA_ANO_REFER);

            /*" -352- MOVE ZEROS TO V0RELA-ORGAO V0RELA-FONTE V0RELA-CODPDT V0RELA-RAMO V0RELA-MODALID V0RELA-CONGENER V0RELA-NUM-APOL V0RELA-NRENDOS V0RELA-NRPARCEL V0RELA-NRCERTIF V0RELA-NRTIT V0RELA-CODSUBES V0RELA-OPERACAO V0RELA-COD-PLANO V0RELA-OCORHIST. */
            _.Move(0, V0RELA_ORGAO, V0RELA_FONTE, V0RELA_CODPDT, V0RELA_RAMO, V0RELA_MODALID, V0RELA_CONGENER, V0RELA_NUM_APOL, V0RELA_NRENDOS, V0RELA_NRPARCEL, V0RELA_NRCERTIF, V0RELA_NRTIT, V0RELA_CODSUBES, V0RELA_OPERACAO, V0RELA_COD_PLANO, V0RELA_OCORHIST);

            /*" -354- MOVE SPACES TO V0RELA-APOL-LIDER V0RELA-ENDS-LIDER. */
            _.Move("", V0RELA_APOL_LIDER, V0RELA_ENDS_LIDER);

            /*" -356- MOVE ZEROS TO V0RELA-NRPARC-LID V0RELA-NUM-SINIST. */
            _.Move(0, V0RELA_NRPARC_LID, V0RELA_NUM_SINIST);

            /*" -357- MOVE SPACES TO V0RELA-NSINI-LID. */
            _.Move("", V0RELA_NSINI_LID);

            /*" -359- MOVE ZEROS TO V0RELA-NUM-ORDEM V0RELA-CODUNIMO. */
            _.Move(0, V0RELA_NUM_ORDEM, V0RELA_CODUNIMO);

            /*" -360- MOVE SPACES TO V0RELA-CORRECAO. */
            _.Move("", V0RELA_CORRECAO);

            /*" -361- MOVE ZEROS TO V0RELA-SITUACAO. */
            _.Move(0, V0RELA_SITUACAO);

            /*" -362- MOVE 'D' TO V0RELA-PRV-DEF. */
            _.Move("D", V0RELA_PRV_DEF);

            /*" -364- MOVE 'A' TO V0RELA-ANAL-RESU. */
            _.Move("A", V0RELA_ANAL_RESU);

            /*" -368- MOVE ZEROS TO V0RELA-COD-EMPR V0RELA-PERI-RENOV V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_COD_EMPR, V0RELA_PERI_RENOV, V0RELA_PCT_AUMENTO);

            /*" -370- MOVE -1 TO VIND-COD-EMPR VIND-PERI-RENOV VIND-PCT-AUMENTO. */
            _.Move(-1, VIND_COD_EMPR, VIND_PERI_RENOV, VIND_PCT_AUMENTO);

        }

        [StopWatch]
        /*" M-000-00-GRAVA-SOLIC-RELAT-SECTION */
        private void M_000_00_GRAVA_SOLIC_RELAT_SECTION()
        {
            /*" -378- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -379- MOVE 'SI0822B' TO V0RELA-CODRELAT. */
            _.Move("SI0822B", V0RELA_CODRELAT);

            /*" -407- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -408- MOVE 'EDMARP' TO V0RELA-CODUSU. */
            _.Move("EDMARP", V0RELA_CODUSU);

            /*" -410- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -411- MOVE 'SI0110B' TO V0RELA-CODRELAT. */
            _.Move("SI0110B", V0RELA_CODRELAT);

            /*" -412- MOVE 0104800000005 TO V0RELA-NUM-APOL. */
            _.Move(0104800000005, V0RELA_NUM_APOL);

            /*" -413- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -414- MOVE 0104800000009 TO V0RELA-NUM-APOL. */
            _.Move(0104800000009, V0RELA_NUM_APOL);

            /*" -415- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -416- MOVE 0104800000011 TO V0RELA-NUM-APOL. */
            _.Move(0104800000011, V0RELA_NUM_APOL);

            /*" -417- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -418- MOVE 0104800000012 TO V0RELA-NUM-APOL. */
            _.Move(0104800000012, V0RELA_NUM_APOL);

            /*" -419- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -420- MOVE 0104800000016 TO V0RELA-NUM-APOL. */
            _.Move(0104800000016, V0RELA_NUM_APOL);

            /*" -421- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -422- MOVE 0104800000017 TO V0RELA-NUM-APOL. */
            _.Move(0104800000017, V0RELA_NUM_APOL);

            /*" -423- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -424- MOVE 0104800000018 TO V0RELA-NUM-APOL. */
            _.Move(0104800000018, V0RELA_NUM_APOL);

            /*" -425- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -426- MOVE 0104800000020 TO V0RELA-NUM-APOL. */
            _.Move(0104800000020, V0RELA_NUM_APOL);

            /*" -427- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -428- MOVE 0107100000100 TO V0RELA-NUM-APOL. */
            _.Move(0107100000100, V0RELA_NUM_APOL);

            /*" -429- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -430- MOVE 0107100000102 TO V0RELA-NUM-APOL. */
            _.Move(0107100000102, V0RELA_NUM_APOL);

            /*" -431- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -432- MOVE 0107100000313 TO V0RELA-NUM-APOL. */
            _.Move(0107100000313, V0RELA_NUM_APOL);

            /*" -433- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -434- MOVE 0107300000124 TO V0RELA-NUM-APOL. */
            _.Move(0107300000124, V0RELA_NUM_APOL);

            /*" -435- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -436- MOVE 0107300000142 TO V0RELA-NUM-APOL. */
            _.Move(0107300000142, V0RELA_NUM_APOL);

            /*" -437- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -438- MOVE 0107300000144 TO V0RELA-NUM-APOL. */
            _.Move(0107300000144, V0RELA_NUM_APOL);

            /*" -439- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -440- MOVE 0107300000163 TO V0RELA-NUM-APOL. */
            _.Move(0107300000163, V0RELA_NUM_APOL);

            /*" -441- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -442- MOVE 0107300000168 TO V0RELA-NUM-APOL. */
            _.Move(0107300000168, V0RELA_NUM_APOL);

            /*" -443- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -444- MOVE 0107300000171 TO V0RELA-NUM-APOL. */
            _.Move(0107300000171, V0RELA_NUM_APOL);

            /*" -445- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -446- MOVE 0107300000172 TO V0RELA-NUM-APOL. */
            _.Move(0107300000172, V0RELA_NUM_APOL);

            /*" -447- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -448- MOVE 0109300000004 TO V0RELA-NUM-APOL. */
            _.Move(0109300000004, V0RELA_NUM_APOL);

            /*" -449- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -450- MOVE 0109300000064 TO V0RELA-NUM-APOL. */
            _.Move(0109300000064, V0RELA_NUM_APOL);

            /*" -452- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -453- MOVE 'SI0103B' TO V0RELA-CODRELAT. */
            _.Move("SI0103B", V0RELA_CODRELAT);

            /*" -454- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -455- MOVE 0104800000005 TO V0RELA-NUM-APOL. */
            _.Move(0104800000005, V0RELA_NUM_APOL);

            /*" -456- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -457- MOVE 0104800000009 TO V0RELA-NUM-APOL. */
            _.Move(0104800000009, V0RELA_NUM_APOL);

            /*" -458- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -459- MOVE 0104800000011 TO V0RELA-NUM-APOL. */
            _.Move(0104800000011, V0RELA_NUM_APOL);

            /*" -460- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -461- MOVE 0104800000012 TO V0RELA-NUM-APOL. */
            _.Move(0104800000012, V0RELA_NUM_APOL);

            /*" -462- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -463- MOVE 0104800000016 TO V0RELA-NUM-APOL. */
            _.Move(0104800000016, V0RELA_NUM_APOL);

            /*" -464- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -465- MOVE 0104800000017 TO V0RELA-NUM-APOL. */
            _.Move(0104800000017, V0RELA_NUM_APOL);

            /*" -466- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -467- MOVE 0104800000018 TO V0RELA-NUM-APOL. */
            _.Move(0104800000018, V0RELA_NUM_APOL);

            /*" -468- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -469- MOVE 0104800000020 TO V0RELA-NUM-APOL. */
            _.Move(0104800000020, V0RELA_NUM_APOL);

            /*" -470- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -471- MOVE 0107100000100 TO V0RELA-NUM-APOL. */
            _.Move(0107100000100, V0RELA_NUM_APOL);

            /*" -472- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -473- MOVE 0107100000102 TO V0RELA-NUM-APOL. */
            _.Move(0107100000102, V0RELA_NUM_APOL);

            /*" -474- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -475- MOVE 0107100000313 TO V0RELA-NUM-APOL. */
            _.Move(0107100000313, V0RELA_NUM_APOL);

            /*" -476- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -477- MOVE 0107300000124 TO V0RELA-NUM-APOL. */
            _.Move(0107300000124, V0RELA_NUM_APOL);

            /*" -478- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -479- MOVE 0107300000142 TO V0RELA-NUM-APOL. */
            _.Move(0107300000142, V0RELA_NUM_APOL);

            /*" -480- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -481- MOVE 0107300000144 TO V0RELA-NUM-APOL. */
            _.Move(0107300000144, V0RELA_NUM_APOL);

            /*" -482- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -483- MOVE 0107300000163 TO V0RELA-NUM-APOL. */
            _.Move(0107300000163, V0RELA_NUM_APOL);

            /*" -484- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -485- MOVE 0107300000168 TO V0RELA-NUM-APOL. */
            _.Move(0107300000168, V0RELA_NUM_APOL);

            /*" -486- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -487- MOVE 0107300000171 TO V0RELA-NUM-APOL. */
            _.Move(0107300000171, V0RELA_NUM_APOL);

            /*" -488- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -489- MOVE 0107300000172 TO V0RELA-NUM-APOL. */
            _.Move(0107300000172, V0RELA_NUM_APOL);

            /*" -490- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -491- MOVE 0109300000004 TO V0RELA-NUM-APOL. */
            _.Move(0109300000004, V0RELA_NUM_APOL);

            /*" -492- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -493- MOVE 0109300000064 TO V0RELA-NUM-APOL. */
            _.Move(0109300000064, V0RELA_NUM_APOL);

            /*" -495- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -498- COMPUTE W-PERI-INICIAL-ANO = W-PERI-INICIAL-ANO - 1. */
            AREA_DE_WORK.FILLER_6.W_PERI_INICIAL_ANO.Value = AREA_DE_WORK.FILLER_6.W_PERI_INICIAL_ANO - 1;

            /*" -500- MOVE '1995-03-27' TO V0RELA-PERI-INIC. */
            _.Move("1995-03-27", V0RELA_PERI_INIC);

            /*" -501- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -502- MOVE 0 TO V0RELA-NUM-APOL. */
            _.Move(0, V0RELA_NUM_APOL);

            /*" -503- MOVE 'LUCIA' TO V0RELA-CODUSU. */
            _.Move("LUCIA", V0RELA_CODUSU);

            /*" -504- MOVE 'LUCIA TAVARES' TO V0RELA-APOL-LIDER. */
            _.Move("LUCIA TAVARES", V0RELA_APOL_LIDER);

            /*" -505- MOVE 'ASATE' TO V0RELA-ENDS-LIDER. */
            _.Move("ASATE", V0RELA_ENDS_LIDER);

            /*" -506- MOVE '1' TO V0RELA-ANAL-RESU. */
            _.Move("1", V0RELA_ANAL_RESU);

            /*" -507- MOVE 'SI0821B' TO V0RELA-CODRELAT. */
            _.Move("SI0821B", V0RELA_CODRELAT);

            /*" -508- MOVE 72 TO V0RELA-RAMO. */
            _.Move(72, V0RELA_RAMO);

            /*" -515- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -517- MOVE 'SI0200B' TO V0RELA-CODUSU. */
            _.Move("SI0200B", V0RELA_CODUSU);

            /*" -518- MOVE 'SI0830B' TO V0RELA-CODRELAT. */
            _.Move("SI0830B", V0RELA_CODRELAT);

            /*" -520- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -521- MOVE 'SI0831B' TO V0RELA-CODRELAT. */
            _.Move("SI0831B", V0RELA_CODRELAT);

            /*" -523- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -524- MOVE 'SI0839B' TO V0RELA-CODRELAT. */
            _.Move("SI0839B", V0RELA_CODRELAT);

            /*" -524- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

        }

        [StopWatch]
        /*" R0500-00-INSERT-V0RELATORIO-SECTION */
        private void R0500_00_INSERT_V0RELATORIO_SECTION()
        {
            /*" -531- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -574- PERFORM R0500_00_INSERT_V0RELATORIO_DB_INSERT_1 */

            R0500_00_INSERT_V0RELATORIO_DB_INSERT_1();

            /*" -577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -578- DISPLAY 'R0500-00- (ERRO INSERT NA V0RELATORIOS)' */
                _.Display($"R0500-00- (ERRO INSERT NA V0RELATORIOS)");

                /*" -578- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-INSERT-V0RELATORIO-DB-INSERT-1 */
        public void R0500_00_INSERT_V0RELATORIO_DB_INSERT_1()
        {
            /*" -574- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU , :V0RELA-DT-SOLIC , :V0RELA-IDSISTEM , :V0RELA-CODRELAT , :V0RELA-NRCOPIAS , :V0RELA-QTDE , :V0RELA-PERI-INIC , :V0RELA-PERI-FINAL , :V0RELA-DATA-REFER , :V0RELA-MES-REFER , :V0RELA-ANO-REFER , :V0RELA-ORGAO , :V0RELA-FONTE , :V0RELA-CODPDT , :V0RELA-RAMO , :V0RELA-MODALID , :V0RELA-CONGENER , :V0RELA-NUM-APOL , :V0RELA-NRENDOS , :V0RELA-NRPARCEL , :V0RELA-NRCERTIF , :V0RELA-NRTIT , :V0RELA-CODSUBES , :V0RELA-OPERACAO , :V0RELA-COD-PLANO , :V0RELA-OCORHIST , :V0RELA-APOL-LIDER , :V0RELA-ENDS-LIDER , :V0RELA-NRPARC-LID , :V0RELA-NUM-SINIST , :V0RELA-NSINI-LID , :V0RELA-NUM-ORDEM , :V0RELA-CODUNIMO , :V0RELA-CORRECAO , :V0RELA-SITUACAO , :V0RELA-PRV-DEF , :V0RELA-ANAL-RESU , :V0RELA-COD-EMPR:VIND-COD-EMPR , :V0RELA-PERI-RENOV:VIND-PERI-RENOV , :V0RELA-PCT-AUMENTO:VIND-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1 = new R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DT_SOLIC = V0RELA_DT_SOLIC.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QTDE = V0RELA_QTDE.ToString(),
                V0RELA_PERI_INIC = V0RELA_PERI_INIC.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFER = V0RELA_DATA_REFER.ToString(),
                V0RELA_MES_REFER = V0RELA_MES_REFER.ToString(),
                V0RELA_ANO_REFER = V0RELA_ANO_REFER.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALID = V0RELA_MODALID.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOL = V0RELA_NUM_APOL.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOL_LIDER = V0RELA_APOL_LIDER.ToString(),
                V0RELA_ENDS_LIDER = V0RELA_ENDS_LIDER.ToString(),
                V0RELA_NRPARC_LID = V0RELA_NRPARC_LID.ToString(),
                V0RELA_NUM_SINIST = V0RELA_NUM_SINIST.ToString(),
                V0RELA_NSINI_LID = V0RELA_NSINI_LID.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PRV_DEF = V0RELA_PRV_DEF.ToString(),
                V0RELA_ANAL_RESU = V0RELA_ANAL_RESU.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
                VIND_COD_EMPR = VIND_COD_EMPR.ToString(),
                V0RELA_PERI_RENOV = V0RELA_PERI_RENOV.ToString(),
                VIND_PERI_RENOV = VIND_PERI_RENOV.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
                VIND_PCT_AUMENTO = VIND_PCT_AUMENTO.ToString(),
            };

            R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1.Execute(r0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -593- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -595- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -595- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -597- EXEC SQL ROLLBACK WORK RELEASE END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

        }
    }
}