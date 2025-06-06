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
using Sias.Geral.DB2.GE0355S;

namespace Code
{
    public class GE0355S
    {
        public bool IsCall { get; set; }

        public GE0355S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SIGCB - BOLETO REGISTRADO SAP      *      */
        /*"      *   PROGRAMA ...............  GE0355S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  ELIERMES OLIVEIRA                  *      */
        /*"      *   PROGRAMADOR ............  ELIERMES OLIVEIRA                  *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO 2016                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO: SUBROTINA PARA CALCULO E GERACAO DE CODIGO DE BARRAS,*      */
        /*"      *           LINHA DIGITAVEL E DATA JULIANA PARA IMPRESSAO DE     *      */
        /*"      *           BOLETOS                                              *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS VIDA - 140.778                                        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           AREA-DE-WORK.*/
        public GE0355S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0355S_AREA_DE_WORK();
        public class GE0355S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WK-RCCODE         PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WK_RCCODE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05 WCALCULO                  PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WCALCULO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 FILLER       REDEFINES   WCALCULO.*/
            private _REDEF_GE0355S_FILLER_0 _filler_0 { get; set; }
            public _REDEF_GE0355S_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_GE0355S_FILLER_0(); _.Move(WCALCULO, _filler_0); VarBasis.RedefinePassValue(WCALCULO, _filler_0, WCALCULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WCALCULO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WCALCULO); }
            }  //Redefines
            public class _REDEF_GE0355S_FILLER_0 : VarBasis
            {
                /*"      10  WCALCUL1             PIC  9(001).*/
                public IntBasis WCALCUL1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10  WCALCUL2             PIC  9(001).*/
                public IntBasis WCALCUL2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01          NR-CODIG-DE-BARRA.*/

                public _REDEF_GE0355S_FILLER_0()
                {
                    WCALCUL1.ValueChanged += OnValueChanged;
                    WCALCUL2.ValueChanged += OnValueChanged;
                }

            }
        }
        public GE0355S_NR_CODIG_DE_BARRA NR_CODIG_DE_BARRA { get; set; } = new GE0355S_NR_CODIG_DE_BARRA();
        public class GE0355S_NR_CODIG_DE_BARRA : VarBasis
        {
            /*"  03        NR-COD-XEROX          PIC  X(050)   VALUE           '10001010011100000101101000110000011100100101000110'.*/
            public StringBasis NR_COD_XEROX { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"10001010011100000101101000110000011100100101000110");
            /*"  03        RNR-COD-XEROX         REDEFINES     NR-COD-XEROX.*/
            private _REDEF_GE0355S_RNR_COD_XEROX _rnr_cod_xerox { get; set; }
            public _REDEF_GE0355S_RNR_COD_XEROX RNR_COD_XEROX
            {
                get { _rnr_cod_xerox = new _REDEF_GE0355S_RNR_COD_XEROX(); _.Move(NR_COD_XEROX, _rnr_cod_xerox); VarBasis.RedefinePassValue(NR_COD_XEROX, _rnr_cod_xerox, NR_COD_XEROX); _rnr_cod_xerox.ValueChanged += () => { _.Move(_rnr_cod_xerox, NR_COD_XEROX); }; return _rnr_cod_xerox; }
                set { VarBasis.RedefinePassValue(value, _rnr_cod_xerox, NR_COD_XEROX); }
            }  //Redefines
            public class _REDEF_GE0355S_RNR_COD_XEROX : VarBasis
            {
                /*"    05      NR-COD-XEROX10        OCCURS        10 TIMES.*/
                public ListBasis<GE0355S_NR_COD_XEROX10> NR_COD_XEROX10 { get; set; } = new ListBasis<GE0355S_NR_COD_XEROX10>(10);
                public class GE0355S_NR_COD_XEROX10 : VarBasis
                {
                    /*"      07    NR-COD-XEROX5         OCCURS        5  TIMES                                  PIC  9(001).*/
                    public ListBasis<IntBasis, Int64> NR_COD_XEROX5 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 5);
                    /*"  03        NR-COMP-XEROX.*/

                    public GE0355S_NR_COD_XEROX10()
                    {
                        NR_COD_XEROX5.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_GE0355S_RNR_COD_XEROX()
                {
                    NR_COD_XEROX10.ValueChanged += OnValueChanged;
                }

            }
            public GE0355S_NR_COMP_XEROX NR_COMP_XEROX { get; set; } = new GE0355S_NR_COMP_XEROX();
            public class GE0355S_NR_COMP_XEROX : VarBasis
            {
                /*"    05      NR-COMPOSTO-XEROX     OCCURS        10 TIMES                                  PIC  9(001).*/
                public ListBasis<IntBasis, Int64> NR_COMPOSTO_XEROX { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 10);
                /*"  03        RNR-COMP-XEROX        REDEFINES     NR-COMP-XEROX.*/
            }
            private _REDEF_GE0355S_RNR_COMP_XEROX _rnr_comp_xerox { get; set; }
            public _REDEF_GE0355S_RNR_COMP_XEROX RNR_COMP_XEROX
            {
                get { _rnr_comp_xerox = new _REDEF_GE0355S_RNR_COMP_XEROX(); _.Move(NR_COMP_XEROX, _rnr_comp_xerox); VarBasis.RedefinePassValue(NR_COMP_XEROX, _rnr_comp_xerox, NR_COMP_XEROX); _rnr_comp_xerox.ValueChanged += () => { _.Move(_rnr_comp_xerox, NR_COMP_XEROX); }; return _rnr_comp_xerox; }
                set { VarBasis.RedefinePassValue(value, _rnr_comp_xerox, NR_COMP_XEROX); }
            }  //Redefines
            public class _REDEF_GE0355S_RNR_COMP_XEROX : VarBasis
            {
                /*"    05      RNR-COMPOSTO-XEROX    OCCURS        5  TIMES                                  PIC  9(002).*/
                public ListBasis<IntBasis, Int64> RNR_COMPOSTO_XEROX { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "2", "9(002)."), 5);
                /*"  03        NR-COD-BARRA-NUM.*/

                public _REDEF_GE0355S_RNR_COMP_XEROX()
                {
                    RNR_COMPOSTO_XEROX.ValueChanged += OnValueChanged;
                }

            }
            public GE0355S_NR_COD_BARRA_NUM NR_COD_BARRA_NUM { get; set; } = new GE0355S_NR_COD_BARRA_NUM();
            public class GE0355S_NR_COD_BARRA_NUM : VarBasis
            {
                /*"    05      NR-NUMERO             PIC  X(044).*/
                public StringBasis NR_NUMERO { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
                /*"  03        RNR-COD-BARRA-NUM     REDEFINES     NR-COD-BARRA-NUM*/
            }
            private _REDEF_GE0355S_RNR_COD_BARRA_NUM _rnr_cod_barra_num { get; set; }
            public _REDEF_GE0355S_RNR_COD_BARRA_NUM RNR_COD_BARRA_NUM
            {
                get { _rnr_cod_barra_num = new _REDEF_GE0355S_RNR_COD_BARRA_NUM(); _.Move(NR_COD_BARRA_NUM, _rnr_cod_barra_num); VarBasis.RedefinePassValue(NR_COD_BARRA_NUM, _rnr_cod_barra_num, NR_COD_BARRA_NUM); _rnr_cod_barra_num.ValueChanged += () => { _.Move(_rnr_cod_barra_num, NR_COD_BARRA_NUM); }; return _rnr_cod_barra_num; }
                set { VarBasis.RedefinePassValue(value, _rnr_cod_barra_num, NR_COD_BARRA_NUM); }
            }  //Redefines
            public class _REDEF_GE0355S_RNR_COD_BARRA_NUM : VarBasis
            {
                /*"    05      RNR-COD-BARRA-30      OCCURS        44 TIMES                                  PIC  9(001).*/
                public ListBasis<IntBasis, Int64> RNR_COD_BARRA_30 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "1", "9(001)."), 44);
                /*"  03        NR-COD-BARRA-XEROX    PIC  X(110).*/

                public _REDEF_GE0355S_RNR_COD_BARRA_NUM()
                {
                    RNR_COD_BARRA_30.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis NR_COD_BARRA_XEROX { get; set; } = new StringBasis(new PIC("X", "110", "X(110)."), @"");
            /*"  03        RNR-COD-BARRA-XEROX   REDEFINES   NR-COD-BARRA-XEROX*/
            private _REDEF_GE0355S_RNR_COD_BARRA_XEROX _rnr_cod_barra_xerox { get; set; }
            public _REDEF_GE0355S_RNR_COD_BARRA_XEROX RNR_COD_BARRA_XEROX
            {
                get { _rnr_cod_barra_xerox = new _REDEF_GE0355S_RNR_COD_BARRA_XEROX(); _.Move(NR_COD_BARRA_XEROX, _rnr_cod_barra_xerox); VarBasis.RedefinePassValue(NR_COD_BARRA_XEROX, _rnr_cod_barra_xerox, NR_COD_BARRA_XEROX); _rnr_cod_barra_xerox.ValueChanged += () => { _.Move(_rnr_cod_barra_xerox, NR_COD_BARRA_XEROX); }; return _rnr_cod_barra_xerox; }
                set { VarBasis.RedefinePassValue(value, _rnr_cod_barra_xerox, NR_COD_BARRA_XEROX); }
            }  //Redefines
            public class _REDEF_GE0355S_RNR_COD_BARRA_XEROX : VarBasis
            {
                /*"    05      NR-COD-BAR-XER        OCCURS        110  TIMES                                  PIC  X(001).*/
                public ListBasis<StringBasis, string> NR_COD_BAR_XER { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 110);
                /*"  03        NR-INDEX1-XEROX       PIC  9(003)   VALUE ZERO.*/

                public _REDEF_GE0355S_RNR_COD_BARRA_XEROX()
                {
                    NR_COD_BAR_XER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis NR_INDEX1_XEROX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        NR-INDEX2-XEROX       PIC  9(003)   VALUE ZERO.*/
            public IntBasis NR_INDEX2_XEROX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        NR-INDEX1-BARRA       PIC  9(003)   VALUE ZERO.*/
            public IntBasis NR_INDEX1_BARRA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        NR-INDEX2-BARRA       PIC  9(003)   VALUE ZERO.*/
            public IntBasis NR_INDEX2_BARRA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03        NR-INDEX-XER-COMP     PIC  9(003)   VALUE ZERO.*/
            public IntBasis NR_INDEX_XER_COMP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"01    WS-NN-REGISTRADO            PIC  9(018).*/
        }
        public IntBasis WS_NN_REGISTRADO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
        /*"01    WS-NN-REGISTRADO-R REDEFINES WS-NN-REGISTRADO.*/
        private _REDEF_GE0355S_WS_NN_REGISTRADO_R _ws_nn_registrado_r { get; set; }
        public _REDEF_GE0355S_WS_NN_REGISTRADO_R WS_NN_REGISTRADO_R
        {
            get { _ws_nn_registrado_r = new _REDEF_GE0355S_WS_NN_REGISTRADO_R(); _.Move(WS_NN_REGISTRADO, _ws_nn_registrado_r); VarBasis.RedefinePassValue(WS_NN_REGISTRADO, _ws_nn_registrado_r, WS_NN_REGISTRADO); _ws_nn_registrado_r.ValueChanged += () => { _.Move(_ws_nn_registrado_r, WS_NN_REGISTRADO); }; return _ws_nn_registrado_r; }
            set { VarBasis.RedefinePassValue(value, _ws_nn_registrado_r, WS_NN_REGISTRADO); }
        }  //Redefines
        public class _REDEF_GE0355S_WS_NN_REGISTRADO_R : VarBasis
        {
            /*"    05      WS-NN-REG-CONST-1     PIC  9(001).*/
            public IntBasis WS_NN_REG_CONST_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      WS-NN-REG-CONST-2     PIC  9(001).*/
            public IntBasis WS_NN_REG_CONST_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      WS-NN-REG-3P5P        PIC  9(003).*/
            public IntBasis WS_NN_REG_3P5P { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      WS-NN-REG-6P8P        PIC  9(003).*/
            public IntBasis WS_NN_REG_6P8P { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      WS-NN-REG-9P17P       PIC  9(009).*/
            public IntBasis WS_NN_REG_9P17P { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05      WS-NN-REG-DV          PIC  9(001).*/
            public IntBasis WS_NN_REG_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01    WS-COD-BENEFIC              PIC  X(020).*/

            public _REDEF_GE0355S_WS_NN_REGISTRADO_R()
            {
                WS_NN_REG_CONST_1.ValueChanged += OnValueChanged;
                WS_NN_REG_CONST_2.ValueChanged += OnValueChanged;
                WS_NN_REG_3P5P.ValueChanged += OnValueChanged;
                WS_NN_REG_6P8P.ValueChanged += OnValueChanged;
                WS_NN_REG_9P17P.ValueChanged += OnValueChanged;
                WS_NN_REG_DV.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_COD_BENEFIC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01    WS-COD-BENEFIC-R   REDEFINES WS-COD-BENEFIC.*/
        private _REDEF_GE0355S_WS_COD_BENEFIC_R _ws_cod_benefic_r { get; set; }
        public _REDEF_GE0355S_WS_COD_BENEFIC_R WS_COD_BENEFIC_R
        {
            get { _ws_cod_benefic_r = new _REDEF_GE0355S_WS_COD_BENEFIC_R(); _.Move(WS_COD_BENEFIC, _ws_cod_benefic_r); VarBasis.RedefinePassValue(WS_COD_BENEFIC, _ws_cod_benefic_r, WS_COD_BENEFIC); _ws_cod_benefic_r.ValueChanged += () => { _.Move(_ws_cod_benefic_r, WS_COD_BENEFIC); }; return _ws_cod_benefic_r; }
            set { VarBasis.RedefinePassValue(value, _ws_cod_benefic_r, WS_COD_BENEFIC); }
        }  //Redefines
        public class _REDEF_GE0355S_WS_COD_BENEFIC_R : VarBasis
        {
            /*"    05      WS-AG-BENEFICIARIO    PIC  9(004).*/
            public IntBasis WS_AG_BENEFICIARIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      WS-FILLER             PIC  X(001).*/
            public StringBasis WS_FILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05      WS-COD-BENEFICIARIO   PIC  9(006).*/
            public IntBasis WS_COD_BENEFICIARIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05      WS-FILLER             PIC  X(001).*/
            public StringBasis WS_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05      WS-DV-BENEFICIARIO    PIC  9(001).*/
            public IntBasis WS_DV_BENEFICIARIO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      WS-FILLER             PIC  X(007).*/
            public StringBasis WS_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"01    NR-NUMER                    PIC  X(044).*/

            public _REDEF_GE0355S_WS_COD_BENEFIC_R()
            {
                WS_AG_BENEFICIARIO.ValueChanged += OnValueChanged;
                WS_FILLER.ValueChanged += OnValueChanged;
                WS_COD_BENEFICIARIO.ValueChanged += OnValueChanged;
                WS_FILLER_0.ValueChanged += OnValueChanged;
                WS_DV_BENEFICIARIO.ValueChanged += OnValueChanged;
                WS_FILLER_1.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis NR_NUMER { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
        /*"01    NR-NUMER-R     REDEFINES NR-NUMER.*/
        private _REDEF_GE0355S_NR_NUMER_R _nr_numer_r { get; set; }
        public _REDEF_GE0355S_NR_NUMER_R NR_NUMER_R
        {
            get { _nr_numer_r = new _REDEF_GE0355S_NR_NUMER_R(); _.Move(NR_NUMER, _nr_numer_r); VarBasis.RedefinePassValue(NR_NUMER, _nr_numer_r, NR_NUMER); _nr_numer_r.ValueChanged += () => { _.Move(_nr_numer_r, NR_NUMER); }; return _nr_numer_r; }
            set { VarBasis.RedefinePassValue(value, _nr_numer_r, NR_NUMER); }
        }  //Redefines
        public class _REDEF_GE0355S_NR_NUMER_R : VarBasis
        {
            /*"    05      NR-BANCO              PIC  9(003).*/
            public IntBasis NR_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      NR-MOEDA              PIC  9(001).*/
            public IntBasis NR_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NR-DV-GERAL           PIC  9(001).*/
            public IntBasis NR_DV_GERAL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NR-FATOR-VENC         PIC  9(004).*/
            public IntBasis NR_FATOR_VENC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      NR-VLR-BOLETO         PIC  9(008)V99.*/
            public DoubleBasis NR_VLR_BOLETO { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
            /*"    05      NR-VLR-BOLETO-R REDEFINES NR-VLR-BOLETO                                  PIC  9(010).*/
            private _REDEF_IntBasis _nr_vlr_boleto_r { get; set; }
            public _REDEF_IntBasis NR_VLR_BOLETO_R
            {
                get { _nr_vlr_boleto_r = new _REDEF_IntBasis(new PIC("9", "010", "9(010).")); ; _.Move(NR_VLR_BOLETO, _nr_vlr_boleto_r); VarBasis.RedefinePassValue(NR_VLR_BOLETO, _nr_vlr_boleto_r, NR_VLR_BOLETO); _nr_vlr_boleto_r.ValueChanged += () => { _.Move(_nr_vlr_boleto_r, NR_VLR_BOLETO); }; return _nr_vlr_boleto_r; }
                set { VarBasis.RedefinePassValue(value, _nr_vlr_boleto_r, NR_VLR_BOLETO); }
            }  //Redefines
            /*"    05      NR-COD-BENEFIC        PIC  9(006).*/
            public IntBasis NR_COD_BENEFIC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05      NR-DV-BENEFIC         PIC  9(001).*/
            public IntBasis NR_DV_BENEFIC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NR-NN-SEQ-1           PIC  9(003).*/
            public IntBasis NR_NN_SEQ_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      NR-NN-CONST-1         PIC  9(001).*/
            public IntBasis NR_NN_CONST_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NR-NN-SEQ-2           PIC  9(003).*/
            public IntBasis NR_NN_SEQ_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      NR-NN-CONST-2         PIC  9(001).*/
            public IntBasis NR_NN_CONST_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NR-NN-SEQ-3           PIC  9(009).*/
            public IntBasis NR_NN_SEQ_3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05      NR-DV-CAMPO-LIVRE     PIC  9(001).*/
            public IntBasis NR_DV_CAMPO_LIVRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01    NR-NUMER-R1  REDEFINES NR-NUMER.*/

            public _REDEF_GE0355S_NR_NUMER_R()
            {
                NR_BANCO.ValueChanged += OnValueChanged;
                NR_MOEDA.ValueChanged += OnValueChanged;
                NR_DV_GERAL.ValueChanged += OnValueChanged;
                NR_FATOR_VENC.ValueChanged += OnValueChanged;
                NR_VLR_BOLETO.ValueChanged += OnValueChanged;
                NR_VLR_BOLETO_R.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_GE0355S_NR_NUMER_R1 _nr_numer_r1 { get; set; }
        public _REDEF_GE0355S_NR_NUMER_R1 NR_NUMER_R1
        {
            get { _nr_numer_r1 = new _REDEF_GE0355S_NR_NUMER_R1(); _.Move(NR_NUMER, _nr_numer_r1); VarBasis.RedefinePassValue(NR_NUMER, _nr_numer_r1, NR_NUMER); _nr_numer_r1.ValueChanged += () => { _.Move(_nr_numer_r1, NR_NUMER); }; return _nr_numer_r1; }
            set { VarBasis.RedefinePassValue(value, _nr_numer_r1, NR_NUMER); }
        }  //Redefines
        public class _REDEF_GE0355S_NR_NUMER_R1 : VarBasis
        {
            /*"    05      FILLER                PIC  X(019).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"    05      NR-NUMER-24P          PIC  X(024).*/
            public StringBasis NR_NUMER_24P { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
            /*"    05      FILLER                PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01    NR-NUMER-R2  REDEFINES NR-NUMER.*/

            public _REDEF_GE0355S_NR_NUMER_R1()
            {
                FILLER_1.ValueChanged += OnValueChanged;
                NR_NUMER_24P.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_GE0355S_NR_NUMER_R2 _nr_numer_r2 { get; set; }
        public _REDEF_GE0355S_NR_NUMER_R2 NR_NUMER_R2
        {
            get { _nr_numer_r2 = new _REDEF_GE0355S_NR_NUMER_R2(); _.Move(NR_NUMER, _nr_numer_r2); VarBasis.RedefinePassValue(NR_NUMER, _nr_numer_r2, NR_NUMER); _nr_numer_r2.ValueChanged += () => { _.Move(_nr_numer_r2, NR_NUMER); }; return _nr_numer_r2; }
            set { VarBasis.RedefinePassValue(value, _nr_numer_r2, NR_NUMER); }
        }  //Redefines
        public class _REDEF_GE0355S_NR_NUMER_R2 : VarBasis
        {
            /*"    05      FILLER                PIC  X(024).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
            /*"    05      NR-NUMER-25A29P       PIC  9(005).*/
            public IntBasis NR_NUMER_25A29P { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05      NR-NUMER-30A34P       PIC  9(005).*/
            public IntBasis NR_NUMER_30A34P { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05      NR-NUMER-35A39P       PIC  9(005).*/
            public IntBasis NR_NUMER_35A39P { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05      NR-NUMER-40A44P       PIC  9(005).*/
            public IntBasis NR_NUMER_40A44P { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"01     NG-NUMER                   PIC  X(043).*/

            public _REDEF_GE0355S_NR_NUMER_R2()
            {
                FILLER_3.ValueChanged += OnValueChanged;
                NR_NUMER_25A29P.ValueChanged += OnValueChanged;
                NR_NUMER_30A34P.ValueChanged += OnValueChanged;
                NR_NUMER_35A39P.ValueChanged += OnValueChanged;
                NR_NUMER_40A44P.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis NG_NUMER { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
        /*"01     NG-NUMER-R     REDEFINES NG-NUMER.*/
        private _REDEF_GE0355S_NG_NUMER_R _ng_numer_r { get; set; }
        public _REDEF_GE0355S_NG_NUMER_R NG_NUMER_R
        {
            get { _ng_numer_r = new _REDEF_GE0355S_NG_NUMER_R(); _.Move(NG_NUMER, _ng_numer_r); VarBasis.RedefinePassValue(NG_NUMER, _ng_numer_r, NG_NUMER); _ng_numer_r.ValueChanged += () => { _.Move(_ng_numer_r, NG_NUMER); }; return _ng_numer_r; }
            set { VarBasis.RedefinePassValue(value, _ng_numer_r, NG_NUMER); }
        }  //Redefines
        public class _REDEF_GE0355S_NG_NUMER_R : VarBasis
        {
            /*"    05      NG-BANCO              PIC  9(003).*/
            public IntBasis NG_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      NG-MOEDA              PIC  9(001).*/
            public IntBasis NG_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NG-FATOR-VENC         PIC  9(004).*/
            public IntBasis NG_FATOR_VENC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05      NG-VLR-BOLETO         PIC  9(008)V99.*/
            public DoubleBasis NG_VLR_BOLETO { get; set; } = new DoubleBasis(new PIC("9", "8", "9(008)V99."), 2);
            /*"    05      NG-COD-BENEFIC        PIC  9(006).*/
            public IntBasis NG_COD_BENEFIC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05      NG-DV-BENEFIC         PIC  9(001).*/
            public IntBasis NG_DV_BENEFIC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NG-NN-SEQ-1           PIC  9(003).*/
            public IntBasis NG_NN_SEQ_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      NG-NN-CONST-1         PIC  9(001).*/
            public IntBasis NG_NN_CONST_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NG-NN-SEQ-2           PIC  9(003).*/
            public IntBasis NG_NN_SEQ_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05      NG-NN-CONST-2         PIC  9(001).*/
            public IntBasis NG_NN_CONST_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05      NG-NN-SEQ-3           PIC  9(009).*/
            public IntBasis NG_NN_SEQ_3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05      NG-DV-CAMPO-LIVRE     PIC  9(001).*/
            public IntBasis NG_DV_CAMPO_LIVRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01     WS-NUMER-AUX.*/

            public _REDEF_GE0355S_NG_NUMER_R()
            {
                NG_BANCO.ValueChanged += OnValueChanged;
                NG_MOEDA.ValueChanged += OnValueChanged;
                NG_FATOR_VENC.ValueChanged += OnValueChanged;
                NG_VLR_BOLETO.ValueChanged += OnValueChanged;
                NG_COD_BENEFIC.ValueChanged += OnValueChanged;
                NG_DV_BENEFIC.ValueChanged += OnValueChanged;
                NG_NN_SEQ_1.ValueChanged += OnValueChanged;
                NG_NN_CONST_1.ValueChanged += OnValueChanged;
                NG_NN_SEQ_2.ValueChanged += OnValueChanged;
                NG_NN_CONST_2.ValueChanged += OnValueChanged;
                NG_NN_SEQ_3.ValueChanged += OnValueChanged;
                NG_DV_CAMPO_LIVRE.ValueChanged += OnValueChanged;
            }

        }
        public GE0355S_WS_NUMER_AUX WS_NUMER_AUX { get; set; } = new GE0355S_WS_NUMER_AUX();
        public class GE0355S_WS_NUMER_AUX : VarBasis
        {
            /*"    05      WS-NUMER-AUX43        PIC  X(043).*/
            public StringBasis WS_NUMER_AUX43 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
            /*"    05      WS-NUMER-AUX43R  REDEFINES WS-NUMER-AUX43.*/
            private _REDEF_GE0355S_WS_NUMER_AUX43R _ws_numer_aux43r { get; set; }
            public _REDEF_GE0355S_WS_NUMER_AUX43R WS_NUMER_AUX43R
            {
                get { _ws_numer_aux43r = new _REDEF_GE0355S_WS_NUMER_AUX43R(); _.Move(WS_NUMER_AUX43, _ws_numer_aux43r); VarBasis.RedefinePassValue(WS_NUMER_AUX43, _ws_numer_aux43r, WS_NUMER_AUX43); _ws_numer_aux43r.ValueChanged += () => { _.Move(_ws_numer_aux43r, WS_NUMER_AUX43); }; return _ws_numer_aux43r; }
                set { VarBasis.RedefinePassValue(value, _ws_numer_aux43r, WS_NUMER_AUX43); }
            }  //Redefines
            public class _REDEF_GE0355S_WS_NUMER_AUX43R : VarBasis
            {
                /*"        10  WS-NUMER-AUX43R-19P   PIC  X(019).*/
                public StringBasis WS_NUMER_AUX43R_19P { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"        10  WS-NUMER-AUX43R-24P   PIC  X(024).*/
                public StringBasis WS_NUMER_AUX43R_24P { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                /*"    05      FILLER                PIC  X(001).*/

                public _REDEF_GE0355S_WS_NUMER_AUX43R()
                {
                    WS_NUMER_AUX43R_19P.ValueChanged += OnValueChanged;
                    WS_NUMER_AUX43R_24P.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01 WS-CAMPO-AUX                   PIC  9(010).*/
        }
        public IntBasis WS_CAMPO_AUX { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
        /*"01 WS-CAMPO-AUX-R  REDEFINES    WS-CAMPO-AUX.*/
        private _REDEF_GE0355S_WS_CAMPO_AUX_R _ws_campo_aux_r { get; set; }
        public _REDEF_GE0355S_WS_CAMPO_AUX_R WS_CAMPO_AUX_R
        {
            get { _ws_campo_aux_r = new _REDEF_GE0355S_WS_CAMPO_AUX_R(); _.Move(WS_CAMPO_AUX, _ws_campo_aux_r); VarBasis.RedefinePassValue(WS_CAMPO_AUX, _ws_campo_aux_r, WS_CAMPO_AUX); _ws_campo_aux_r.ValueChanged += () => { _.Move(_ws_campo_aux_r, WS_CAMPO_AUX); }; return _ws_campo_aux_r; }
            set { VarBasis.RedefinePassValue(value, _ws_campo_aux_r, WS_CAMPO_AUX); }
        }  //Redefines
        public class _REDEF_GE0355S_WS_CAMPO_AUX_R : VarBasis
        {
            /*"    05 WS-CAMPO-AUX1              PIC  9(005).*/
            public IntBasis WS_CAMPO_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 WS-CAMPO-AUX2              PIC  9(005).*/
            public IntBasis WS_CAMPO_AUX2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"01 WS-LD-CAMPO1                   PIC  9(010).*/

            public _REDEF_GE0355S_WS_CAMPO_AUX_R()
            {
                WS_CAMPO_AUX1.ValueChanged += OnValueChanged;
                WS_CAMPO_AUX2.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_LD_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
        /*"01 WS-LD-CAMPO1-R  REDEFINES    WS-LD-CAMPO1.*/
        private _REDEF_GE0355S_WS_LD_CAMPO1_R _ws_ld_campo1_r { get; set; }
        public _REDEF_GE0355S_WS_LD_CAMPO1_R WS_LD_CAMPO1_R
        {
            get { _ws_ld_campo1_r = new _REDEF_GE0355S_WS_LD_CAMPO1_R(); _.Move(WS_LD_CAMPO1, _ws_ld_campo1_r); VarBasis.RedefinePassValue(WS_LD_CAMPO1, _ws_ld_campo1_r, WS_LD_CAMPO1); _ws_ld_campo1_r.ValueChanged += () => { _.Move(_ws_ld_campo1_r, WS_LD_CAMPO1); }; return _ws_ld_campo1_r; }
            set { VarBasis.RedefinePassValue(value, _ws_ld_campo1_r, WS_LD_CAMPO1); }
        }  //Redefines
        public class _REDEF_GE0355S_WS_LD_CAMPO1_R : VarBasis
        {
            /*"    05 WS-LD-5P-1-CAMPO1          PIC  9(005).*/
            public IntBasis WS_LD_5P_1_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 WS-LD-5P-2-CAMPO1          PIC  9(004).*/
            public IntBasis WS_LD_5P_2_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WS-LD-1P-3-CAMPO1          PIC  9(001).*/
            public IntBasis WS_LD_1P_3_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01 WS-LD-CAMPO1-R2 REDEFINES    WS-LD-CAMPO1.*/

            public _REDEF_GE0355S_WS_LD_CAMPO1_R()
            {
                WS_LD_5P_1_CAMPO1.ValueChanged += OnValueChanged;
                WS_LD_5P_2_CAMPO1.ValueChanged += OnValueChanged;
                WS_LD_1P_3_CAMPO1.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_GE0355S_WS_LD_CAMPO1_R2 _ws_ld_campo1_r2 { get; set; }
        public _REDEF_GE0355S_WS_LD_CAMPO1_R2 WS_LD_CAMPO1_R2
        {
            get { _ws_ld_campo1_r2 = new _REDEF_GE0355S_WS_LD_CAMPO1_R2(); _.Move(WS_LD_CAMPO1, _ws_ld_campo1_r2); VarBasis.RedefinePassValue(WS_LD_CAMPO1, _ws_ld_campo1_r2, WS_LD_CAMPO1); _ws_ld_campo1_r2.ValueChanged += () => { _.Move(_ws_ld_campo1_r2, WS_LD_CAMPO1); }; return _ws_ld_campo1_r2; }
            set { VarBasis.RedefinePassValue(value, _ws_ld_campo1_r2, WS_LD_CAMPO1); }
        }  //Redefines
        public class _REDEF_GE0355S_WS_LD_CAMPO1_R2 : VarBasis
        {
            /*"    05 WS-LD-BANCO-CAMPO1         PIC  9(003).*/
            public IntBasis WS_LD_BANCO_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05 WS-LD-MOEDA-CAMPO1         PIC  9(001).*/
            public IntBasis WS_LD_MOEDA_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 WS-LD-COD-BENEFIC-CAMPO1   PIC  9(006).*/
            public IntBasis WS_LD_COD_BENEFIC_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01 WS-LD-CAMPO3-R  REDEFINES    WS-LD-CAMPO1.*/

            public _REDEF_GE0355S_WS_LD_CAMPO1_R2()
            {
                WS_LD_BANCO_CAMPO1.ValueChanged += OnValueChanged;
                WS_LD_MOEDA_CAMPO1.ValueChanged += OnValueChanged;
                WS_LD_COD_BENEFIC_CAMPO1.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_GE0355S_WS_LD_CAMPO3_R _ws_ld_campo3_r { get; set; }
        public _REDEF_GE0355S_WS_LD_CAMPO3_R WS_LD_CAMPO3_R
        {
            get { _ws_ld_campo3_r = new _REDEF_GE0355S_WS_LD_CAMPO3_R(); _.Move(WS_LD_CAMPO1, _ws_ld_campo3_r); VarBasis.RedefinePassValue(WS_LD_CAMPO1, _ws_ld_campo3_r, WS_LD_CAMPO1); _ws_ld_campo3_r.ValueChanged += () => { _.Move(_ws_ld_campo3_r, WS_LD_CAMPO1); }; return _ws_ld_campo3_r; }
            set { VarBasis.RedefinePassValue(value, _ws_ld_campo3_r, WS_LD_CAMPO1); }
        }  //Redefines
        public class _REDEF_GE0355S_WS_LD_CAMPO3_R : VarBasis
        {
            /*"    05 WS-LD-9P-1-CAMPO1          PIC  9(009).*/
            public IntBasis WS_LD_9P_1_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 WS-LD-1P-2-CAMPO1          PIC  9(001).*/
            public IntBasis WS_LD_1P_2_CAMPO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01    LD-LINHA-DIGITAVEL          PIC  X(054).*/

            public _REDEF_GE0355S_WS_LD_CAMPO3_R()
            {
                WS_LD_9P_1_CAMPO1.ValueChanged += OnValueChanged;
                WS_LD_1P_2_CAMPO1.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis LD_LINHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
        /*"01    LD-LINHA-DIGITAVEL-R REDEFINES LD-LINHA-DIGITAVEL.*/
        private _REDEF_GE0355S_LD_LINHA_DIGITAVEL_R _ld_linha_digitavel_r { get; set; }
        public _REDEF_GE0355S_LD_LINHA_DIGITAVEL_R LD_LINHA_DIGITAVEL_R
        {
            get { _ld_linha_digitavel_r = new _REDEF_GE0355S_LD_LINHA_DIGITAVEL_R(); _.Move(LD_LINHA_DIGITAVEL, _ld_linha_digitavel_r); VarBasis.RedefinePassValue(LD_LINHA_DIGITAVEL, _ld_linha_digitavel_r, LD_LINHA_DIGITAVEL); _ld_linha_digitavel_r.ValueChanged += () => { _.Move(_ld_linha_digitavel_r, LD_LINHA_DIGITAVEL); }; return _ld_linha_digitavel_r; }
            set { VarBasis.RedefinePassValue(value, _ld_linha_digitavel_r, LD_LINHA_DIGITAVEL); }
        }  //Redefines
        public class _REDEF_GE0355S_LD_LINHA_DIGITAVEL_R : VarBasis
        {
            /*"      10      LD-CAMPO1.*/
            public GE0355S_LD_CAMPO1 LD_CAMPO1 { get; set; } = new GE0355S_LD_CAMPO1();
            public class GE0355S_LD_CAMPO1 : VarBasis
            {
                /*"        15    LD-CAMPO1-5P-1      PIC  9(005).*/
                public IntBasis LD_CAMPO1_5P_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"        15    LD-PONTO-1          PIC  X(001).*/
                public StringBasis LD_PONTO_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        15    LD-CAMPO1-5P-2      PIC  9(004).*/
                public IntBasis LD_CAMPO1_5P_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        15    LD-CAMPO1-DV        PIC  9(001).*/
                public IntBasis LD_CAMPO1_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LD-SPACE-1          PIC  X(001).*/
                public StringBasis LD_SPACE_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      LD-CAMPO2.*/

                public GE0355S_LD_CAMPO1()
                {
                    LD_CAMPO1_5P_1.ValueChanged += OnValueChanged;
                    LD_PONTO_1.ValueChanged += OnValueChanged;
                    LD_CAMPO1_5P_2.ValueChanged += OnValueChanged;
                    LD_CAMPO1_DV.ValueChanged += OnValueChanged;
                    LD_SPACE_1.ValueChanged += OnValueChanged;
                }

            }
            public GE0355S_LD_CAMPO2 LD_CAMPO2 { get; set; } = new GE0355S_LD_CAMPO2();
            public class GE0355S_LD_CAMPO2 : VarBasis
            {
                /*"        15    LD-CAMPO2-5P-1      PIC  9(005).*/
                public IntBasis LD_CAMPO2_5P_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"        15    LD-PONTO-2          PIC  X(001).*/
                public StringBasis LD_PONTO_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        15    LD-CAMPO2-5P-2      PIC  9(005).*/
                public IntBasis LD_CAMPO2_5P_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"        15    LD-CAMPO2-DV        PIC  9(001).*/
                public IntBasis LD_CAMPO2_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LD-SPACE-2          PIC  X(001).*/
                public StringBasis LD_SPACE_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      LD-CAMPO3.*/

                public GE0355S_LD_CAMPO2()
                {
                    LD_CAMPO2_5P_1.ValueChanged += OnValueChanged;
                    LD_PONTO_2.ValueChanged += OnValueChanged;
                    LD_CAMPO2_5P_2.ValueChanged += OnValueChanged;
                    LD_CAMPO2_DV.ValueChanged += OnValueChanged;
                    LD_SPACE_2.ValueChanged += OnValueChanged;
                }

            }
            public GE0355S_LD_CAMPO3 LD_CAMPO3 { get; set; } = new GE0355S_LD_CAMPO3();
            public class GE0355S_LD_CAMPO3 : VarBasis
            {
                /*"        15    LD-CAMPO3-5P-1      PIC  9(005).*/
                public IntBasis LD_CAMPO3_5P_1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"        15    LD-PONTO-3          PIC  X(001).*/
                public StringBasis LD_PONTO_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        15    LD-CAMPO3-5P-2      PIC  9(005).*/
                public IntBasis LD_CAMPO3_5P_2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"        15    LD-CAMPO3-DV        PIC  9(001).*/
                public IntBasis LD_CAMPO3_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LD-SPACE-3          PIC  X(001).*/
                public StringBasis LD_SPACE_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      LD-CAMPO4.*/

                public GE0355S_LD_CAMPO3()
                {
                    LD_CAMPO3_5P_1.ValueChanged += OnValueChanged;
                    LD_PONTO_3.ValueChanged += OnValueChanged;
                    LD_CAMPO3_5P_2.ValueChanged += OnValueChanged;
                    LD_CAMPO3_DV.ValueChanged += OnValueChanged;
                    LD_SPACE_3.ValueChanged += OnValueChanged;
                }

            }
            public GE0355S_LD_CAMPO4 LD_CAMPO4 { get; set; } = new GE0355S_LD_CAMPO4();
            public class GE0355S_LD_CAMPO4 : VarBasis
            {
                /*"        15    LD-CAMPO4-1P        PIC  9(001).*/
                public IntBasis LD_CAMPO4_1P { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LD-SPACE-4          PIC  X(001).*/
                public StringBasis LD_SPACE_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      LD-CAMPO5.*/

                public GE0355S_LD_CAMPO4()
                {
                    LD_CAMPO4_1P.ValueChanged += OnValueChanged;
                    LD_SPACE_4.ValueChanged += OnValueChanged;
                }

            }
            public GE0355S_LD_CAMPO5 LD_CAMPO5 { get; set; } = new GE0355S_LD_CAMPO5();
            public class GE0355S_LD_CAMPO5 : VarBasis
            {
                /*"        15    LD-CAMPO5-5P-1      PIC  9(004).*/
                public IntBasis LD_CAMPO5_5P_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        15    LD-CAMPO5-5P-2      PIC  9(010).*/
                public IntBasis LD_CAMPO5_5P_2 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"01          NR-CODIGO-DE-BARRA.*/

                public GE0355S_LD_CAMPO5()
                {
                    LD_CAMPO5_5P_1.ValueChanged += OnValueChanged;
                    LD_CAMPO5_5P_2.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_GE0355S_LD_LINHA_DIGITAVEL_R()
            {
                LD_CAMPO1.ValueChanged += OnValueChanged;
                LD_CAMPO2.ValueChanged += OnValueChanged;
                LD_CAMPO3.ValueChanged += OnValueChanged;
                LD_CAMPO4.ValueChanged += OnValueChanged;
                LD_CAMPO5.ValueChanged += OnValueChanged;
            }

        }
        public GE0355S_NR_CODIGO_DE_BARRA NR_CODIGO_DE_BARRA { get; set; } = new GE0355S_NR_CODIGO_DE_BARRA();
        public class GE0355S_NR_CODIGO_DE_BARRA : VarBasis
        {
            /*"  03        NR-START              PIC  X(001)   VALUE '<'.*/
            public StringBasis NR_START { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"<");
            /*"  03        NR-CODBARRA           PIC  X(110)   VALUE  SPACES.*/
            public StringBasis NR_CODBARRA { get; set; } = new StringBasis(new PIC("X", "110", "X(110)"), @"");
            /*"  03        NR-STOP               PIC  X(001)   VALUE '>'.*/
            public StringBasis NR_STOP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @">");
            /*"01 W91-DIGITO          PIC  9(002)    VALUE ZEROS.*/
        }
        public IntBasis W91_DIGITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01 WPARM01-AUX         PIC S9(009)    VALUE +0 COMP-3.*/
        public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 WPARM91-AUX         PIC S9(009)    VALUE +0 COMP-3.*/
        public IntBasis WPARM91_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 WQUOCIENTE          PIC S9(004)    VALUE +0 COMP-3.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 WRESTO              PIC S9(004)    VALUE +0 COMP-3.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 WS-FATOR-VENC       PIC S9(009)    VALUE +0 COMP-3.*/
        public IntBasis WS_FATOR_VENC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01 WS-DATA-VENCIMENTO  PIC  X(010).*/
        public StringBasis WS_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01 LPARM91X.*/
        public GE0355S_LPARM91X LPARM91X { get; set; } = new GE0355S_LPARM91X();
        public class GE0355S_LPARM91X : VarBasis
        {
            /*"      10      LPARM91             PIC  X(043).*/
            public StringBasis LPARM91 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)."), @"");
            /*"      10      LPARM91-R  REDEFINES  LPARM91.*/
            private _REDEF_GE0355S_LPARM91_R _lparm91_r { get; set; }
            public _REDEF_GE0355S_LPARM91_R LPARM91_R
            {
                get { _lparm91_r = new _REDEF_GE0355S_LPARM91_R(); _.Move(LPARM91, _lparm91_r); VarBasis.RedefinePassValue(LPARM91, _lparm91_r, LPARM91); _lparm91_r.ValueChanged += () => { _.Move(_lparm91_r, LPARM91); }; return _lparm91_r; }
                set { VarBasis.RedefinePassValue(value, _lparm91_r, LPARM91); }
            }  //Redefines
            public class _REDEF_GE0355S_LPARM91_R : VarBasis
            {
                /*"        15    LPARM91-1           PIC  9(001).*/
                public IntBasis LPARM91_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-2           PIC  9(001).*/
                public IntBasis LPARM91_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-3           PIC  9(001).*/
                public IntBasis LPARM91_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-4           PIC  9(001).*/
                public IntBasis LPARM91_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-5           PIC  9(001).*/
                public IntBasis LPARM91_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-6           PIC  9(001).*/
                public IntBasis LPARM91_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-7           PIC  9(001).*/
                public IntBasis LPARM91_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-8           PIC  9(001).*/
                public IntBasis LPARM91_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-9           PIC  9(001).*/
                public IntBasis LPARM91_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-10          PIC  9(001).*/
                public IntBasis LPARM91_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-11          PIC  9(001).*/
                public IntBasis LPARM91_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-12          PIC  9(001).*/
                public IntBasis LPARM91_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-13          PIC  9(001).*/
                public IntBasis LPARM91_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-14          PIC  9(001).*/
                public IntBasis LPARM91_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-15          PIC  9(001).*/
                public IntBasis LPARM91_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-16          PIC  9(001).*/
                public IntBasis LPARM91_16 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-17          PIC  9(001).*/
                public IntBasis LPARM91_17 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-18          PIC  9(001).*/
                public IntBasis LPARM91_18 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-19          PIC  9(001).*/
                public IntBasis LPARM91_19 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-20          PIC  9(001).*/
                public IntBasis LPARM91_20 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-21          PIC  9(001).*/
                public IntBasis LPARM91_21 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-22          PIC  9(001).*/
                public IntBasis LPARM91_22 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-23          PIC  9(001).*/
                public IntBasis LPARM91_23 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-24          PIC  9(001).*/
                public IntBasis LPARM91_24 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-25          PIC  9(001).*/
                public IntBasis LPARM91_25 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-26          PIC  9(001).*/
                public IntBasis LPARM91_26 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-27          PIC  9(001).*/
                public IntBasis LPARM91_27 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-28          PIC  9(001).*/
                public IntBasis LPARM91_28 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-29          PIC  9(001).*/
                public IntBasis LPARM91_29 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-30          PIC  9(001).*/
                public IntBasis LPARM91_30 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-31          PIC  9(001).*/
                public IntBasis LPARM91_31 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-32          PIC  9(001).*/
                public IntBasis LPARM91_32 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-33          PIC  9(001).*/
                public IntBasis LPARM91_33 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-34          PIC  9(001).*/
                public IntBasis LPARM91_34 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-35          PIC  9(001).*/
                public IntBasis LPARM91_35 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-36          PIC  9(001).*/
                public IntBasis LPARM91_36 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-37          PIC  9(001).*/
                public IntBasis LPARM91_37 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-38          PIC  9(001).*/
                public IntBasis LPARM91_38 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-39          PIC  9(001).*/
                public IntBasis LPARM91_39 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-40          PIC  9(001).*/
                public IntBasis LPARM91_40 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-41          PIC  9(001).*/
                public IntBasis LPARM91_41 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-42          PIC  9(001).*/
                public IntBasis LPARM91_42 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM91-43          PIC  9(001).*/
                public IntBasis LPARM91_43 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10      LPARM92             PIC S9(004) COMP.*/

                public _REDEF_GE0355S_LPARM91_R()
                {
                    LPARM91_1.ValueChanged += OnValueChanged;
                    LPARM91_2.ValueChanged += OnValueChanged;
                    LPARM91_3.ValueChanged += OnValueChanged;
                    LPARM91_4.ValueChanged += OnValueChanged;
                    LPARM91_5.ValueChanged += OnValueChanged;
                    LPARM91_6.ValueChanged += OnValueChanged;
                    LPARM91_7.ValueChanged += OnValueChanged;
                    LPARM91_8.ValueChanged += OnValueChanged;
                    LPARM91_9.ValueChanged += OnValueChanged;
                    LPARM91_10.ValueChanged += OnValueChanged;
                    LPARM91_11.ValueChanged += OnValueChanged;
                    LPARM91_12.ValueChanged += OnValueChanged;
                    LPARM91_13.ValueChanged += OnValueChanged;
                    LPARM91_14.ValueChanged += OnValueChanged;
                    LPARM91_15.ValueChanged += OnValueChanged;
                    LPARM91_16.ValueChanged += OnValueChanged;
                    LPARM91_17.ValueChanged += OnValueChanged;
                    LPARM91_18.ValueChanged += OnValueChanged;
                    LPARM91_19.ValueChanged += OnValueChanged;
                    LPARM91_20.ValueChanged += OnValueChanged;
                    LPARM91_21.ValueChanged += OnValueChanged;
                    LPARM91_22.ValueChanged += OnValueChanged;
                    LPARM91_23.ValueChanged += OnValueChanged;
                    LPARM91_24.ValueChanged += OnValueChanged;
                    LPARM91_25.ValueChanged += OnValueChanged;
                    LPARM91_26.ValueChanged += OnValueChanged;
                    LPARM91_27.ValueChanged += OnValueChanged;
                    LPARM91_28.ValueChanged += OnValueChanged;
                    LPARM91_29.ValueChanged += OnValueChanged;
                    LPARM91_30.ValueChanged += OnValueChanged;
                    LPARM91_31.ValueChanged += OnValueChanged;
                    LPARM91_32.ValueChanged += OnValueChanged;
                    LPARM91_33.ValueChanged += OnValueChanged;
                    LPARM91_34.ValueChanged += OnValueChanged;
                    LPARM91_35.ValueChanged += OnValueChanged;
                    LPARM91_36.ValueChanged += OnValueChanged;
                    LPARM91_37.ValueChanged += OnValueChanged;
                    LPARM91_38.ValueChanged += OnValueChanged;
                    LPARM91_39.ValueChanged += OnValueChanged;
                    LPARM91_40.ValueChanged += OnValueChanged;
                    LPARM91_41.ValueChanged += OnValueChanged;
                    LPARM91_42.ValueChanged += OnValueChanged;
                    LPARM91_43.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LPARM92 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      10      LPARM93             PIC  9(001).*/
            public IntBasis LPARM93 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"      10      LPARM93-R           REDEFINES   LPARM93                                  PIC  X(001).*/
            private _REDEF_StringBasis _lparm93_r { get; set; }
            public _REDEF_StringBasis LPARM93_R
            {
                get { _lparm93_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM93, _lparm93_r); VarBasis.RedefinePassValue(LPARM93, _lparm93_r, LPARM93); _lparm93_r.ValueChanged += () => { _.Move(_lparm93_r, LPARM93); }; return _lparm93_r; }
                set { VarBasis.RedefinePassValue(value, _lparm93_r, LPARM93); }
            }  //Redefines
            /*"01    WK-NUMERO                   PIC  9(015)    VALUE  ZEROS.*/
        }
        public IntBasis WK_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"01    WK-DIGITO                   PIC  9(001)    VALUE  ZEROS.*/
        public IntBasis WK_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01    LPARM01X.*/
        public GE0355S_LPARM01X LPARM01X { get; set; } = new GE0355S_LPARM01X();
        public class GE0355S_LPARM01X : VarBasis
        {
            /*"      10      LPARM01             PIC  9(015).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"      10      LPARM01-R           REDEFINES              LPARM01.*/
            private _REDEF_GE0355S_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_GE0355S_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_GE0355S_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_GE0355S_LPARM01_R : VarBasis
            {
                /*"        15    LPARM01-1           PIC  9(001).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-2           PIC  9(001).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-3           PIC  9(001).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-4           PIC  9(001).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-5           PIC  9(001).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-6           PIC  9(001).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-7           PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-8           PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-9           PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-10          PIC  9(001).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-11          PIC  9(001).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-12          PIC  9(001).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-13          PIC  9(001).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-14          PIC  9(001).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        15    LPARM01-15          PIC  9(001).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        LPARM02             PIC S9(004) COMP.*/
                public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05        LPARM03             PIC  9(001).*/
                public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        LPARM03-R           REDEFINES   LPARM03                                  PIC  X(001).*/
                private _REDEF_StringBasis _lparm03_r { get; set; }
                public _REDEF_StringBasis LPARM03_R
                {
                    get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                    set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
                }  //Redefines
                /*"01  REGISTRO-LINKAGE-GE0355S.*/

                public _REDEF_GE0355S_LPARM01_R()
                {
                    LPARM01_1.ValueChanged += OnValueChanged;
                    LPARM01_2.ValueChanged += OnValueChanged;
                    LPARM01_3.ValueChanged += OnValueChanged;
                    LPARM01_4.ValueChanged += OnValueChanged;
                    LPARM01_5.ValueChanged += OnValueChanged;
                    LPARM01_6.ValueChanged += OnValueChanged;
                    LPARM01_7.ValueChanged += OnValueChanged;
                    LPARM01_8.ValueChanged += OnValueChanged;
                    LPARM01_9.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                    LPARM02.ValueChanged += OnValueChanged;
                    LPARM03.ValueChanged += OnValueChanged;
                    LPARM03_R.ValueChanged += OnValueChanged;
                }

            }
        }
        public GE0355S_REGISTRO_LINKAGE_GE0355S REGISTRO_LINKAGE_GE0355S { get; set; } = new GE0355S_REGISTRO_LINKAGE_GE0355S();
        public class GE0355S_REGISTRO_LINKAGE_GE0355S : VarBasis
        {
            /*"  03   LK-GE355-IN-BANCO               PIC  9(003).*/
            public IntBasis LK_GE355_IN_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03   LK-GE355-IN-MOEDA               PIC  9(001).*/
            public IntBasis LK_GE355_IN_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03   LK-GE355-IN-VLR-BOLETO          PIC  9(012)V99.*/
            public DoubleBasis LK_GE355_IN_VLR_BOLETO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99."), 2);
            /*"  03   LK-GE355-IN-NOSSO-NUMERO        PIC  9(018).*/
            public IntBasis LK_GE355_IN_NOSSO_NUMERO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"  03   LK-GE355-IN-DATA-VENCIMENTO     PIC  X(010).*/
            public StringBasis LK_GE355_IN_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03   LK-GE355-IN-COD-BENEFICIARIO    PIC  X(020).*/
            public StringBasis LK_GE355_IN_COD_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  03   LK-GE355-OUT-COD-BARRA          PIC  X(044).*/
            public StringBasis LK_GE355_OUT_COD_BARRA { get; set; } = new StringBasis(new PIC("X", "44", "X(044)."), @"");
            /*"  03   LK-GE355-OUT-DESENHO-BARRA      PIC  X(112).*/
            public StringBasis LK_GE355_OUT_DESENHO_BARRA { get; set; } = new StringBasis(new PIC("X", "112", "X(112)."), @"");
            /*"  03   LK-GE355-OUT-LINHA-DIGITAVEL    PIC  X(054).*/
            public StringBasis LK_GE355_OUT_LINHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
            /*"  03   LK-GE355-OUT-FATOR-VENCIMENTO   PIC  9(004).*/
            public IntBasis LK_GE355_OUT_FATOR_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03   LK-GE355-OUT-COD-RETORNO        PIC  X(001).*/
            public StringBasis LK_GE355_OUT_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  03   LK-GE355-OUT-MENSAGEM.*/
            public GE0355S_LK_GE355_OUT_MENSAGEM LK_GE355_OUT_MENSAGEM { get; set; } = new GE0355S_LK_GE355_OUT_MENSAGEM();
            public class GE0355S_LK_GE355_OUT_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE355-OUT-SQLCODE         PIC  -ZZ9.*/
                public IntBasis LK_GE355_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                       PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       20 LK-GE355-OUT-MSG-RETORNO     PIC  X(075).*/
                public StringBasis LK_GE355_OUT_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0355S_REGISTRO_LINKAGE_GE0355S GE0355S_REGISTRO_LINKAGE_GE0355S_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_GE0355S*/
        {
            try
            {
                this.REGISTRO_LINKAGE_GE0355S = GE0355S_REGISTRO_LINKAGE_GE0355S_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_GE0355S, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -326- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -328- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -330- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -343- MOVE '0' TO LK-GE355-OUT-COD-RETORNO */
            _.Move("0", REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO);

            /*" -344- MOVE 0 TO LK-GE355-OUT-SQLCODE */
            _.Move(0, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_SQLCODE);

            /*" -346- MOVE SPACES TO LK-GE355-OUT-MENSAGEM. */
            _.Move("", REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM);

            /*" -347- IF (LK-GE355-IN-DATA-VENCIMENTO NOT EQUAL SPACES) */

            if ((!REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_DATA_VENCIMENTO.IsEmpty()))
            {

                /*" -348- PERFORM R2000-00-CALCULA-FATOR-VENC */

                R2000_00_CALCULA_FATOR_VENC_SECTION();

                /*" -349- MOVE WS-FATOR-VENC TO LK-GE355-OUT-FATOR-VENCIMENTO */
                _.Move(WS_FATOR_VENC, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_FATOR_VENCIMENTO);

                /*" -350- ELSE */
            }
            else
            {


                /*" -351- MOVE ZEROS TO LK-GE355-OUT-FATOR-VENCIMENTO */
                _.Move(0, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_FATOR_VENCIMENTO);

                /*" -353- END-IF */
            }


            /*" -355- PERFORM R1000-00-PROCESSA-COD-BARRA */

            R1000_00_PROCESSA_COD_BARRA_SECTION();

            /*" -364- PERFORM R3000-00-CALC-LINHA-DIGITAVEL */

            R3000_00_CALC_LINHA_DIGITAVEL_SECTION();

            /*" -364- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-COD-BARRA-SECTION */
        private void R1000_00_PROCESSA_COD_BARRA_SECTION()
        {
            /*" -376- PERFORM R1200-00-CALCULA-NR-NUMER */

            R1200_00_CALCULA_NR_NUMER_SECTION();

            /*" -378- MOVE NR-NUMER TO NR-NUMERO LK-GE355-OUT-COD-BARRA */
            _.Move(NR_NUMER, NR_CODIG_DE_BARRA.NR_COD_BARRA_NUM.NR_NUMERO, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_BARRA);

            /*" -379- MOVE 1 TO NR-INDEX-XER-COMP */
            _.Move(1, NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP);

            /*" -380- MOVE 1 TO NR-INDEX1-BARRA */
            _.Move(1, NR_CODIG_DE_BARRA.NR_INDEX1_BARRA);

            /*" -381- MOVE 2 TO NR-INDEX2-BARRA */
            _.Move(2, NR_CODIG_DE_BARRA.NR_INDEX2_BARRA);

            /*" -382- PERFORM R1100-00-MONTA-BARRAS 22 TIMES */

            for (int i = 0; i < 22; i++)
            {

                R1100_00_MONTA_BARRAS_SECTION();

            }

            /*" -384- MOVE NR-COD-BARRA-XEROX TO NR-CODBARRA. */
            _.Move(NR_CODIG_DE_BARRA.NR_COD_BARRA_XEROX, NR_CODIGO_DE_BARRA.NR_CODBARRA);

            /*" -385- IF RETURN-CODE EQUAL ZEROS */

            if (RETURN_CODE == 00)
            {

                /*" -386- MOVE NR-CODIGO-DE-BARRA TO LK-GE355-OUT-DESENHO-BARRA */
                _.Move(NR_CODIGO_DE_BARRA, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_DESENHO_BARRA);

                /*" -387- ELSE */
            }
            else
            {


                /*" -388- MOVE SPACES TO LK-GE355-OUT-DESENHO-BARRA */
                _.Move("", REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_DESENHO_BARRA);

                /*" -389- MOVE '1' TO LK-GE355-OUT-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO);

                /*" -391- MOVE 'GE0355S - ERRO NO CALCULO DO DESENHO COD BARRA' TO LK-GE355-OUT-MSG-RETORNO */
                _.Move("GE0355S - ERRO NO CALCULO DO DESENHO COD BARRA", REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_MSG_RETORNO);

                /*" -392- DISPLAY 'ERRO NO CALCULO DO DESENHO COD BARRA ' */
                _.Display($"ERRO NO CALCULO DO DESENHO COD BARRA ");

                /*" -393- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -393- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-MONTA-BARRAS-SECTION */
        private void R1100_00_MONTA_BARRAS_SECTION()
        {
            /*" -405- MOVE RNR-COD-BARRA-30 (NR-INDEX1-BARRA) TO NR-INDEX1-XEROX */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_BARRA_NUM.RNR_COD_BARRA_30[NR_CODIG_DE_BARRA.NR_INDEX1_BARRA], NR_CODIG_DE_BARRA.NR_INDEX1_XEROX);

            /*" -406- IF NR-INDEX1-XEROX EQUAL ZERO */

            if (NR_CODIG_DE_BARRA.NR_INDEX1_XEROX == 00)
            {

                /*" -408- MOVE 10 TO NR-INDEX1-XEROX. */
                _.Move(10, NR_CODIG_DE_BARRA.NR_INDEX1_XEROX);
            }


            /*" -410- MOVE RNR-COD-BARRA-30 (NR-INDEX2-BARRA) TO NR-INDEX2-XEROX */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_BARRA_NUM.RNR_COD_BARRA_30[NR_CODIG_DE_BARRA.NR_INDEX2_BARRA], NR_CODIG_DE_BARRA.NR_INDEX2_XEROX);

            /*" -411- IF NR-INDEX2-XEROX EQUAL ZERO */

            if (NR_CODIG_DE_BARRA.NR_INDEX2_XEROX == 00)
            {

                /*" -413- MOVE 10 TO NR-INDEX2-XEROX. */
                _.Move(10, NR_CODIG_DE_BARRA.NR_INDEX2_XEROX);
            }


            /*" -415- MOVE NR-COD-XEROX5 (NR-INDEX1-XEROX 1) TO NR-COMPOSTO-XEROX (01) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX1_XEROX].NR_COD_XEROX5[1], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[01]);

            /*" -418- MOVE NR-COD-XEROX5 (NR-INDEX2-XEROX 1) TO NR-COMPOSTO-XEROX (02) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX2_XEROX].NR_COD_XEROX5[1], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[02]);

            /*" -420- MOVE NR-COD-XEROX5 (NR-INDEX1-XEROX 2) TO NR-COMPOSTO-XEROX (03) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX1_XEROX].NR_COD_XEROX5[2], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[03]);

            /*" -423- MOVE NR-COD-XEROX5 (NR-INDEX2-XEROX 2) TO NR-COMPOSTO-XEROX (04) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX2_XEROX].NR_COD_XEROX5[2], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[04]);

            /*" -425- MOVE NR-COD-XEROX5 (NR-INDEX1-XEROX 3) TO NR-COMPOSTO-XEROX (05) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX1_XEROX].NR_COD_XEROX5[3], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[05]);

            /*" -428- MOVE NR-COD-XEROX5 (NR-INDEX2-XEROX 3) TO NR-COMPOSTO-XEROX (06) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX2_XEROX].NR_COD_XEROX5[3], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[06]);

            /*" -430- MOVE NR-COD-XEROX5 (NR-INDEX1-XEROX 4) TO NR-COMPOSTO-XEROX (07) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX1_XEROX].NR_COD_XEROX5[4], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[07]);

            /*" -433- MOVE NR-COD-XEROX5 (NR-INDEX2-XEROX 4) TO NR-COMPOSTO-XEROX (08) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX2_XEROX].NR_COD_XEROX5[4], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[08]);

            /*" -435- MOVE NR-COD-XEROX5 (NR-INDEX1-XEROX 5) TO NR-COMPOSTO-XEROX (09) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX1_XEROX].NR_COD_XEROX5[5], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[09]);

            /*" -438- MOVE NR-COD-XEROX5 (NR-INDEX2-XEROX 5) TO NR-COMPOSTO-XEROX (10) */
            _.Move(NR_CODIG_DE_BARRA.RNR_COD_XEROX.NR_COD_XEROX10[NR_CODIG_DE_BARRA.NR_INDEX2_XEROX].NR_COD_XEROX5[5], NR_CODIG_DE_BARRA.NR_COMP_XEROX.NR_COMPOSTO_XEROX[10]);

            /*" -439- IF RNR-COMPOSTO-XEROX (01) EQUAL 01 */

            if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[01] == 01)
            {

                /*" -440- MOVE 'N' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                _.Move("N", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                /*" -441- ELSE */
            }
            else
            {


                /*" -442- IF RNR-COMPOSTO-XEROX (01) EQUAL 11 */

                if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[01] == 11)
                {

                    /*" -443- MOVE 'W' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                    _.Move("W", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                    /*" -444- ELSE */
                }
                else
                {


                    /*" -445- IF RNR-COMPOSTO-XEROX (01) EQUAL 00 */

                    if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[01] == 00)
                    {

                        /*" -446- MOVE 'n' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                        _.Move("n", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                        /*" -447- ELSE */
                    }
                    else
                    {


                        /*" -449- MOVE 'w' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP). */
                        _.Move("w", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -451- ADD 1 TO NR-INDEX-XER-COMP */
            NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP.Value = NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP + 1;

            /*" -452- IF RNR-COMPOSTO-XEROX (02) EQUAL 01 */

            if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[02] == 01)
            {

                /*" -453- MOVE 'N' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                _.Move("N", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                /*" -454- ELSE */
            }
            else
            {


                /*" -455- IF RNR-COMPOSTO-XEROX (02) EQUAL 11 */

                if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[02] == 11)
                {

                    /*" -456- MOVE 'W' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                    _.Move("W", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                    /*" -457- ELSE */
                }
                else
                {


                    /*" -458- IF RNR-COMPOSTO-XEROX (02) EQUAL 00 */

                    if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[02] == 00)
                    {

                        /*" -459- MOVE 'n' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                        _.Move("n", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                        /*" -460- ELSE */
                    }
                    else
                    {


                        /*" -462- MOVE 'w' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP). */
                        _.Move("w", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -464- ADD 1 TO NR-INDEX-XER-COMP */
            NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP.Value = NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP + 1;

            /*" -465- IF RNR-COMPOSTO-XEROX (03) EQUAL 01 */

            if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[03] == 01)
            {

                /*" -466- MOVE 'N' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                _.Move("N", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                /*" -467- ELSE */
            }
            else
            {


                /*" -468- IF RNR-COMPOSTO-XEROX (03) EQUAL 11 */

                if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[03] == 11)
                {

                    /*" -469- MOVE 'W' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                    _.Move("W", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                    /*" -470- ELSE */
                }
                else
                {


                    /*" -471- IF RNR-COMPOSTO-XEROX (03) EQUAL 00 */

                    if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[03] == 00)
                    {

                        /*" -472- MOVE 'n' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                        _.Move("n", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                        /*" -473- ELSE */
                    }
                    else
                    {


                        /*" -475- MOVE 'w' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP). */
                        _.Move("w", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -477- ADD 1 TO NR-INDEX-XER-COMP */
            NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP.Value = NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP + 1;

            /*" -478- IF RNR-COMPOSTO-XEROX (04) EQUAL 01 */

            if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[04] == 01)
            {

                /*" -479- MOVE 'N' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                _.Move("N", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                /*" -480- ELSE */
            }
            else
            {


                /*" -481- IF RNR-COMPOSTO-XEROX (04) EQUAL 11 */

                if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[04] == 11)
                {

                    /*" -482- MOVE 'W' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                    _.Move("W", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                    /*" -483- ELSE */
                }
                else
                {


                    /*" -484- IF RNR-COMPOSTO-XEROX (04) EQUAL 00 */

                    if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[04] == 00)
                    {

                        /*" -485- MOVE 'n' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                        _.Move("n", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                        /*" -486- ELSE */
                    }
                    else
                    {


                        /*" -488- MOVE 'w' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP). */
                        _.Move("w", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -490- ADD 1 TO NR-INDEX-XER-COMP */
            NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP.Value = NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP + 1;

            /*" -491- IF RNR-COMPOSTO-XEROX (05) EQUAL 01 */

            if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[05] == 01)
            {

                /*" -492- MOVE 'N' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                _.Move("N", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                /*" -493- ELSE */
            }
            else
            {


                /*" -494- IF RNR-COMPOSTO-XEROX (05) EQUAL 11 */

                if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[05] == 11)
                {

                    /*" -495- MOVE 'W' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                    _.Move("W", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                    /*" -496- ELSE */
                }
                else
                {


                    /*" -497- IF RNR-COMPOSTO-XEROX (05) EQUAL 00 */

                    if (NR_CODIG_DE_BARRA.RNR_COMP_XEROX.RNR_COMPOSTO_XEROX[05] == 00)
                    {

                        /*" -498- MOVE 'n' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP) */
                        _.Move("n", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);

                        /*" -499- ELSE */
                    }
                    else
                    {


                        /*" -501- MOVE 'w' TO NR-COD-BAR-XER (NR-INDEX-XER-COMP). */
                        _.Move("w", NR_CODIG_DE_BARRA.RNR_COD_BARRA_XEROX.NR_COD_BAR_XER[NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP]);
                    }

                }

            }


            /*" -502- ADD 1 TO NR-INDEX-XER-COMP */
            NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP.Value = NR_CODIG_DE_BARRA.NR_INDEX_XER_COMP + 1;

            /*" -503- ADD 2 TO NR-INDEX1-BARRA */
            NR_CODIG_DE_BARRA.NR_INDEX1_BARRA.Value = NR_CODIG_DE_BARRA.NR_INDEX1_BARRA + 2;

            /*" -503- ADD 2 TO NR-INDEX2-BARRA. */
            NR_CODIG_DE_BARRA.NR_INDEX2_BARRA.Value = NR_CODIG_DE_BARRA.NR_INDEX2_BARRA + 2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CALCULA-NR-NUMER-SECTION */
        private void R1200_00_CALCULA_NR_NUMER_SECTION()
        {
            /*" -514- MOVE LK-GE355-IN-BANCO TO NR-BANCO NG-BANCO */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_BANCO, NR_NUMER_R.NR_BANCO);
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_BANCO, NG_NUMER_R.NG_BANCO);


            /*" -516- MOVE LK-GE355-IN-MOEDA TO NR-MOEDA NG-MOEDA */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_MOEDA, NR_NUMER_R.NR_MOEDA);
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_MOEDA, NG_NUMER_R.NG_MOEDA);


            /*" -518- MOVE LK-GE355-OUT-FATOR-VENCIMENTO TO NR-FATOR-VENC NG-FATOR-VENC */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_FATOR_VENCIMENTO, NR_NUMER_R.NR_FATOR_VENC);
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_FATOR_VENCIMENTO, NG_NUMER_R.NG_FATOR_VENC);


            /*" -521- MOVE LK-GE355-IN-VLR-BOLETO TO NR-VLR-BOLETO NG-VLR-BOLETO */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_VLR_BOLETO, NR_NUMER_R.NR_VLR_BOLETO);
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_VLR_BOLETO, NG_NUMER_R.NG_VLR_BOLETO);


            /*" -522- MOVE LK-GE355-IN-COD-BENEFICIARIO TO WS-COD-BENEFIC */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_COD_BENEFICIARIO, WS_COD_BENEFIC);

            /*" -524- MOVE WS-COD-BENEFICIARIO TO NR-COD-BENEFIC NG-COD-BENEFIC */
            _.Move(WS_COD_BENEFIC_R.WS_COD_BENEFICIARIO, NR_NUMER_R.NR_COD_BENEFIC);
            _.Move(WS_COD_BENEFIC_R.WS_COD_BENEFICIARIO, NG_NUMER_R.NG_COD_BENEFIC);


            /*" -527- MOVE WS-DV-BENEFICIARIO TO NR-DV-BENEFIC NG-DV-BENEFIC */
            _.Move(WS_COD_BENEFIC_R.WS_DV_BENEFICIARIO, NR_NUMER_R.NR_DV_BENEFIC);
            _.Move(WS_COD_BENEFIC_R.WS_DV_BENEFICIARIO, NG_NUMER_R.NG_DV_BENEFIC);


            /*" -528- MOVE LK-GE355-IN-NOSSO-NUMERO TO WS-NN-REGISTRADO */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_NOSSO_NUMERO, WS_NN_REGISTRADO);

            /*" -530- MOVE WS-NN-REG-3P5P TO NR-NN-SEQ-1 NG-NN-SEQ-1 */
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_3P5P, NR_NUMER_R.NR_NN_SEQ_1);
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_3P5P, NG_NUMER_R.NG_NN_SEQ_1);


            /*" -532- MOVE WS-NN-REG-CONST-1 TO NR-NN-CONST-1 NG-NN-CONST-1 */
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_CONST_1, NR_NUMER_R.NR_NN_CONST_1);
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_CONST_1, NG_NUMER_R.NG_NN_CONST_1);


            /*" -534- MOVE WS-NN-REG-6P8P TO NR-NN-SEQ-2 NG-NN-SEQ-2 */
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_6P8P, NR_NUMER_R.NR_NN_SEQ_2);
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_6P8P, NG_NUMER_R.NG_NN_SEQ_2);


            /*" -536- MOVE WS-NN-REG-CONST-2 TO NR-NN-CONST-2 NG-NN-CONST-2 */
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_CONST_2, NR_NUMER_R.NR_NN_CONST_2);
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_CONST_2, NG_NUMER_R.NG_NN_CONST_2);


            /*" -539- MOVE WS-NN-REG-9P17P TO NR-NN-SEQ-3 NG-NN-SEQ-3 */
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_9P17P, NR_NUMER_R.NR_NN_SEQ_3);
            _.Move(WS_NN_REGISTRADO_R.WS_NN_REG_9P17P, NG_NUMER_R.NG_NN_SEQ_3);


            /*" -540- MOVE '0000000000000000000' TO WS-NUMER-AUX43R-19P. */
            _.Move("0000000000000000000", WS_NUMER_AUX.WS_NUMER_AUX43R.WS_NUMER_AUX43R_19P);

            /*" -542- MOVE NR-NUMER-24P TO WS-NUMER-AUX43R-24P. */
            _.Move(NR_NUMER_R1.NR_NUMER_24P, WS_NUMER_AUX.WS_NUMER_AUX43R.WS_NUMER_AUX43R_24P);

            /*" -544- MOVE WS-NUMER-AUX43 TO LPARM91X. */
            _.Move(WS_NUMER_AUX.WS_NUMER_AUX43, LPARM91X);

            /*" -546- PERFORM R1300-00-CALC-DV-MODULO-11 */

            R1300_00_CALC_DV_MODULO_11_SECTION();

            /*" -547- IF (W91-DIGITO > 9) */

            if ((W91_DIGITO > 9))
            {

                /*" -549- MOVE ZEROS TO NR-DV-CAMPO-LIVRE NG-DV-CAMPO-LIVRE */
                _.Move(0, NR_NUMER_R.NR_DV_CAMPO_LIVRE);
                _.Move(0, NG_NUMER_R.NG_DV_CAMPO_LIVRE);


                /*" -550- ELSE */
            }
            else
            {


                /*" -552- MOVE W91-DIGITO TO NR-DV-CAMPO-LIVRE NG-DV-CAMPO-LIVRE */
                _.Move(W91_DIGITO, NR_NUMER_R.NR_DV_CAMPO_LIVRE);
                _.Move(W91_DIGITO, NG_NUMER_R.NG_DV_CAMPO_LIVRE);


                /*" -554- END-IF */
            }


            /*" -556- MOVE NG-NUMER TO LPARM91X. */
            _.Move(NG_NUMER, LPARM91X);

            /*" -558- PERFORM R1300-00-CALC-DV-MODULO-11 */

            R1300_00_CALC_DV_MODULO_11_SECTION();

            /*" -559- IF (W91-DIGITO > 9) OR (W91-DIGITO EQUAL 0) */

            if ((W91_DIGITO > 9) || (W91_DIGITO == 0))
            {

                /*" -560- MOVE 1 TO NR-DV-GERAL */
                _.Move(1, NR_NUMER_R.NR_DV_GERAL);

                /*" -561- ELSE */
            }
            else
            {


                /*" -562- MOVE W91-DIGITO TO NR-DV-GERAL */
                _.Move(W91_DIGITO, NR_NUMER_R.NR_DV_GERAL);

                /*" -562- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-CALC-DV-MODULO-11-SECTION */
        private void R1300_00_CALC_DV_MODULO_11_SECTION()
        {
            /*" -573- MOVE ZEROS TO WPARM91-AUX */
            _.Move(0, WPARM91_AUX);

            /*" -617- COMPUTE WPARM91-AUX = LPARM91-1 * 4 + LPARM91-2 * 3 + LPARM91-3 * 2 + LPARM91-4 * 9 + LPARM91-5 * 8 + LPARM91-6 * 7 + LPARM91-7 * 6 + LPARM91-8 * 5 + LPARM91-9 * 4 + LPARM91-10 * 3 + LPARM91-11 * 2 + LPARM91-12 * 9 + LPARM91-13 * 8 + LPARM91-14 * 7 + LPARM91-15 * 6 + LPARM91-16 * 5 + LPARM91-17 * 4 + LPARM91-18 * 3 + LPARM91-19 * 2 + LPARM91-20 * 9 + LPARM91-21 * 8 + LPARM91-22 * 7 + LPARM91-23 * 6 + LPARM91-24 * 5 + LPARM91-25 * 4 + LPARM91-26 * 3 + LPARM91-27 * 2 + LPARM91-28 * 9 + LPARM91-29 * 8 + LPARM91-30 * 7 + LPARM91-31 * 6 + LPARM91-32 * 5 + LPARM91-33 * 4 + LPARM91-34 * 3 + LPARM91-35 * 2 + LPARM91-36 * 9 + LPARM91-37 * 8 + LPARM91-38 * 7 + LPARM91-39 * 6 + LPARM91-40 * 5 + LPARM91-41 * 4 + LPARM91-42 * 3 + LPARM91-43 * 2 */
            WPARM91_AUX.Value = LPARM91X.LPARM91_R.LPARM91_1 * 4 + LPARM91X.LPARM91_R.LPARM91_2 * 3 + LPARM91X.LPARM91_R.LPARM91_3 * 2 + LPARM91X.LPARM91_R.LPARM91_4 * 9 + LPARM91X.LPARM91_R.LPARM91_5 * 8 + LPARM91X.LPARM91_R.LPARM91_6 * 7 + LPARM91X.LPARM91_R.LPARM91_7 * 6 + LPARM91X.LPARM91_R.LPARM91_8 * 5 + LPARM91X.LPARM91_R.LPARM91_9 * 4 + LPARM91X.LPARM91_R.LPARM91_10 * 3 + LPARM91X.LPARM91_R.LPARM91_11 * 2 + LPARM91X.LPARM91_R.LPARM91_12 * 9 + LPARM91X.LPARM91_R.LPARM91_13 * 8 + LPARM91X.LPARM91_R.LPARM91_14 * 7 + LPARM91X.LPARM91_R.LPARM91_15 * 6 + LPARM91X.LPARM91_R.LPARM91_16 * 5 + LPARM91X.LPARM91_R.LPARM91_17 * 4 + LPARM91X.LPARM91_R.LPARM91_18 * 3 + LPARM91X.LPARM91_R.LPARM91_19 * 2 + LPARM91X.LPARM91_R.LPARM91_20 * 9 + LPARM91X.LPARM91_R.LPARM91_21 * 8 + LPARM91X.LPARM91_R.LPARM91_22 * 7 + LPARM91X.LPARM91_R.LPARM91_23 * 6 + LPARM91X.LPARM91_R.LPARM91_24 * 5 + LPARM91X.LPARM91_R.LPARM91_25 * 4 + LPARM91X.LPARM91_R.LPARM91_26 * 3 + LPARM91X.LPARM91_R.LPARM91_27 * 2 + LPARM91X.LPARM91_R.LPARM91_28 * 9 + LPARM91X.LPARM91_R.LPARM91_29 * 8 + LPARM91X.LPARM91_R.LPARM91_30 * 7 + LPARM91X.LPARM91_R.LPARM91_31 * 6 + LPARM91X.LPARM91_R.LPARM91_32 * 5 + LPARM91X.LPARM91_R.LPARM91_33 * 4 + LPARM91X.LPARM91_R.LPARM91_34 * 3 + LPARM91X.LPARM91_R.LPARM91_35 * 2 + LPARM91X.LPARM91_R.LPARM91_36 * 9 + LPARM91X.LPARM91_R.LPARM91_37 * 8 + LPARM91X.LPARM91_R.LPARM91_38 * 7 + LPARM91X.LPARM91_R.LPARM91_39 * 6 + LPARM91X.LPARM91_R.LPARM91_40 * 5 + LPARM91X.LPARM91_R.LPARM91_41 * 4 + LPARM91X.LPARM91_R.LPARM91_42 * 3 + LPARM91X.LPARM91_R.LPARM91_43 * 2;

            /*" -620- DIVIDE WPARM91-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(WPARM91_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -621- SUBTRACT WRESTO FROM 11 GIVING W91-DIGITO. */
            W91_DIGITO.Value = 11 - WRESTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CALCULA-FATOR-VENC-SECTION */
        private void R2000_00_CALCULA_FATOR_VENC_SECTION()
        {
            /*" -632- MOVE LK-GE355-IN-DATA-VENCIMENTO TO WS-DATA-VENCIMENTO */
            _.Move(REGISTRO_LINKAGE_GE0355S.LK_GE355_IN_DATA_VENCIMENTO, WS_DATA_VENCIMENTO);

            /*" -639- PERFORM R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1 */

            R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1();

            /*" -642- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -644- DISPLAY 'GE0355S-ERRO R2000-00-CALCULA-FATOR-VENC. ' 'WS-DATA-VENCIMENTO<' WS-DATA-VENCIMENTO '>' */

                $"GE0355S-ERRO R2000-00-CALCULA-FATOR-VENC. WS-DATA-VENCIMENTO<{WS_DATA_VENCIMENTO}>"
                .Display();

                /*" -645- MOVE '1' TO LK-GE355-OUT-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_COD_RETORNO);

                /*" -646- GO TO RXXXX-ROTINA-RETORNO */

                RXXXX_ROTINA_RETORNO_SECTION(); //GOTO
                return;

                /*" -646- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-CALCULA-FATOR-VENC-DB-SELECT-1 */
        public void R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1()
        {
            /*" -639- EXEC SQL SELECT DAYS(DATE(:WS-DATA-VENCIMENTO)) - DAYS( '1997-10-07' ) INTO :WS-FATOR-VENC FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1 = new R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1()
            {
                WS_DATA_VENCIMENTO = WS_DATA_VENCIMENTO.ToString(),
            };

            var executed_1 = R2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1.Execute(r2000_00_CALCULA_FATOR_VENC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_FATOR_VENC, WS_FATOR_VENC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CALC-LINHA-DIGITAVEL-SECTION */
        private void R3000_00_CALC_LINHA_DIGITAVEL_SECTION()
        {
            /*" -659- MOVE '.' TO LD-PONTO-1 LD-PONTO-2 LD-PONTO-3 */
            _.Move(".", LD_LINHA_DIGITAVEL_R.LD_CAMPO1.LD_PONTO_1);
            _.Move(".", LD_LINHA_DIGITAVEL_R.LD_CAMPO2.LD_PONTO_2);
            _.Move(".", LD_LINHA_DIGITAVEL_R.LD_CAMPO3.LD_PONTO_3);


            /*" -664- MOVE SPACES TO LD-SPACE-1 LD-SPACE-2 LD-SPACE-3 LD-SPACE-4 */
            _.Move("", LD_LINHA_DIGITAVEL_R.LD_CAMPO1.LD_SPACE_1);
            _.Move("", LD_LINHA_DIGITAVEL_R.LD_CAMPO2.LD_SPACE_2);
            _.Move("", LD_LINHA_DIGITAVEL_R.LD_CAMPO3.LD_SPACE_3);
            _.Move("", LD_LINHA_DIGITAVEL_R.LD_CAMPO4.LD_SPACE_4);


            /*" -665- MOVE NR-BANCO TO WS-LD-BANCO-CAMPO1 */
            _.Move(NR_NUMER_R.NR_BANCO, WS_LD_CAMPO1_R2.WS_LD_BANCO_CAMPO1);

            /*" -666- MOVE NR-MOEDA TO WS-LD-MOEDA-CAMPO1 */
            _.Move(NR_NUMER_R.NR_MOEDA, WS_LD_CAMPO1_R2.WS_LD_MOEDA_CAMPO1);

            /*" -668- MOVE NR-COD-BENEFIC TO WS-LD-COD-BENEFIC-CAMPO1 */
            _.Move(NR_NUMER_R.NR_COD_BENEFIC, WS_LD_CAMPO1_R2.WS_LD_COD_BENEFIC_CAMPO1);

            /*" -670- MOVE WS-LD-9P-1-CAMPO1 TO WK-NUMERO */
            _.Move(WS_LD_CAMPO3_R.WS_LD_9P_1_CAMPO1, WK_NUMERO);

            /*" -672- PERFORM R3100-00-CALC-DV-MODULO-10. */

            R3100_00_CALC_DV_MODULO_10_SECTION();

            /*" -673- MOVE WS-LD-5P-1-CAMPO1 TO LD-CAMPO1-5P-1 */
            _.Move(WS_LD_CAMPO1_R.WS_LD_5P_1_CAMPO1, LD_LINHA_DIGITAVEL_R.LD_CAMPO1.LD_CAMPO1_5P_1);

            /*" -674- MOVE WS-LD-5P-2-CAMPO1 TO LD-CAMPO1-5P-2 */
            _.Move(WS_LD_CAMPO1_R.WS_LD_5P_2_CAMPO1, LD_LINHA_DIGITAVEL_R.LD_CAMPO1.LD_CAMPO1_5P_2);

            /*" -676- MOVE WK-DIGITO TO LD-CAMPO1-DV */
            _.Move(WK_DIGITO, LD_LINHA_DIGITAVEL_R.LD_CAMPO1.LD_CAMPO1_DV);

            /*" -678- MOVE NR-NUMER-25A29P TO LD-CAMPO2-5P-1 WS-CAMPO-AUX1 */
            _.Move(NR_NUMER_R2.NR_NUMER_25A29P, LD_LINHA_DIGITAVEL_R.LD_CAMPO2.LD_CAMPO2_5P_1);
            _.Move(NR_NUMER_R2.NR_NUMER_25A29P, WS_CAMPO_AUX_R.WS_CAMPO_AUX1);


            /*" -680- MOVE NR-NUMER-30A34P TO LD-CAMPO2-5P-2 WS-CAMPO-AUX2 */
            _.Move(NR_NUMER_R2.NR_NUMER_30A34P, LD_LINHA_DIGITAVEL_R.LD_CAMPO2.LD_CAMPO2_5P_2);
            _.Move(NR_NUMER_R2.NR_NUMER_30A34P, WS_CAMPO_AUX_R.WS_CAMPO_AUX2);


            /*" -682- MOVE WS-CAMPO-AUX TO WK-NUMERO */
            _.Move(WS_CAMPO_AUX, WK_NUMERO);

            /*" -683- PERFORM R3100-00-CALC-DV-MODULO-10. */

            R3100_00_CALC_DV_MODULO_10_SECTION();

            /*" -685- MOVE WK-DIGITO TO LD-CAMPO2-DV */
            _.Move(WK_DIGITO, LD_LINHA_DIGITAVEL_R.LD_CAMPO2.LD_CAMPO2_DV);

            /*" -687- MOVE NR-NUMER-35A39P TO LD-CAMPO3-5P-1 WS-CAMPO-AUX1 */
            _.Move(NR_NUMER_R2.NR_NUMER_35A39P, LD_LINHA_DIGITAVEL_R.LD_CAMPO3.LD_CAMPO3_5P_1);
            _.Move(NR_NUMER_R2.NR_NUMER_35A39P, WS_CAMPO_AUX_R.WS_CAMPO_AUX1);


            /*" -689- MOVE NR-NUMER-40A44P TO LD-CAMPO3-5P-2 WS-CAMPO-AUX2 */
            _.Move(NR_NUMER_R2.NR_NUMER_40A44P, LD_LINHA_DIGITAVEL_R.LD_CAMPO3.LD_CAMPO3_5P_2);
            _.Move(NR_NUMER_R2.NR_NUMER_40A44P, WS_CAMPO_AUX_R.WS_CAMPO_AUX2);


            /*" -690- MOVE WS-CAMPO-AUX TO WK-NUMERO */
            _.Move(WS_CAMPO_AUX, WK_NUMERO);

            /*" -691- PERFORM R3100-00-CALC-DV-MODULO-10. */

            R3100_00_CALC_DV_MODULO_10_SECTION();

            /*" -693- MOVE WK-DIGITO TO LD-CAMPO3-DV */
            _.Move(WK_DIGITO, LD_LINHA_DIGITAVEL_R.LD_CAMPO3.LD_CAMPO3_DV);

            /*" -695- MOVE NR-DV-GERAL TO LD-CAMPO4-1P */
            _.Move(NR_NUMER_R.NR_DV_GERAL, LD_LINHA_DIGITAVEL_R.LD_CAMPO4.LD_CAMPO4_1P);

            /*" -696- MOVE NR-FATOR-VENC TO LD-CAMPO5-5P-1. */
            _.Move(NR_NUMER_R.NR_FATOR_VENC, LD_LINHA_DIGITAVEL_R.LD_CAMPO5.LD_CAMPO5_5P_1);

            /*" -698- MOVE NR-VLR-BOLETO-R TO LD-CAMPO5-5P-2. */
            _.Move(NR_NUMER_R.NR_VLR_BOLETO_R, LD_LINHA_DIGITAVEL_R.LD_CAMPO5.LD_CAMPO5_5P_2);

            /*" -698- MOVE LD-LINHA-DIGITAVEL TO LK-GE355-OUT-LINHA-DIGITAVEL. */
            _.Move(LD_LINHA_DIGITAVEL, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_LINHA_DIGITAVEL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-CALC-DV-MODULO-10-SECTION */
        private void R3100_00_CALC_DV_MODULO_10_SECTION()
        {
            /*" -709- MOVE WK-NUMERO TO LPARM01 */
            _.Move(WK_NUMERO, LPARM01X.LPARM01);

            /*" -711- MOVE ZEROS TO WPARM01-AUX */
            _.Move(0, WPARM01_AUX);

            /*" -712- COMPUTE WCALCULO = LPARM01-15 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -713- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -715- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -717- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -718- COMPUTE WCALCULO = LPARM01-14 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_14 * 1;

            /*" -719- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -721- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -723- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -724- COMPUTE WCALCULO = LPARM01-13 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_13 * 2;

            /*" -725- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -727- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -729- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -730- COMPUTE WCALCULO = LPARM01-12 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_12 * 1;

            /*" -731- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -733- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -735- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -736- COMPUTE WCALCULO = LPARM01-11 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_11 * 2;

            /*" -737- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -739- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -741- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -742- COMPUTE WCALCULO = LPARM01-10 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_10 * 1;

            /*" -743- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -745- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -747- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -748- COMPUTE WCALCULO = LPARM01-9 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_9 * 2;

            /*" -749- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -751- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -753- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -754- COMPUTE WCALCULO = LPARM01-8 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_8 * 1;

            /*" -755- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -757- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -759- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -760- COMPUTE WCALCULO = LPARM01-7 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_7 * 2;

            /*" -761- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -763- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -765- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -766- COMPUTE WCALCULO = LPARM01-6 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_6 * 1;

            /*" -767- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -769- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -771- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -772- COMPUTE WCALCULO = LPARM01-5 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_5 * 2;

            /*" -773- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -775- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -777- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -778- COMPUTE WCALCULO = LPARM01-4 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_4 * 1;

            /*" -779- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -781- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -783- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -784- COMPUTE WCALCULO = LPARM01-3 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_3 * 2;

            /*" -785- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -787- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -789- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -790- COMPUTE WCALCULO = LPARM01-2 * 1 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_2 * 1;

            /*" -791- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -793- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -795- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -796- COMPUTE WCALCULO = LPARM01-1 * 2 */
            AREA_DE_WORK.WCALCULO.Value = LPARM01X.LPARM01_R.LPARM01_1 * 2;

            /*" -797- IF WCALCULO GREATER 9 */

            if (AREA_DE_WORK.WCALCULO > 9)
            {

                /*" -799- COMPUTE WCALCULO = WCALCUL1 + WCALCUL2. */
                AREA_DE_WORK.WCALCULO.Value = AREA_DE_WORK.FILLER_0.WCALCUL1 + AREA_DE_WORK.FILLER_0.WCALCUL2;
            }


            /*" -801- ADD WCALCULO TO WPARM01-AUX */
            WPARM01_AUX.Value = WPARM01_AUX + AREA_DE_WORK.WCALCULO;

            /*" -804- DIVIDE WPARM01-AUX BY 10 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(WPARM01_AUX, 10, WQUOCIENTE, WRESTO);

            /*" -805- IF (WRESTO EQUAL ZEROS) */

            if ((WRESTO == 00))
            {

                /*" -806- MOVE 0 TO WK-DIGITO */
                _.Move(0, WK_DIGITO);

                /*" -807- ELSE */
            }
            else
            {


                /*" -809- SUBTRACT WRESTO FROM 10 GIVING WK-DIGITO */
                WK_DIGITO.Value = 10 - WRESTO;

                /*" -809- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO-SECTION */
        private void RXXXX_ROTINA_RETORNO_SECTION()
        {
            /*" -820- MOVE SQLCODE TO LK-GE355-OUT-SQLCODE */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE_GE0355S.LK_GE355_OUT_MENSAGEM.LK_GE355_OUT_SQLCODE);

            /*" -820- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/
    }
}