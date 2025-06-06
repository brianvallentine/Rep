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
using Sias.Sinistro.DB2.SI0882B;

namespace Code
{
    public class SI0882B
    {
        public bool IsCall { get; set; }

        public SI0882B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA   : SINISTRO                                        //      */
        /*"      * PROGRAMA  : SI0882B.                                        //      */
        /*"      * OBJETIVO  : GERACAO DE MOVIMENTO DE CALCULO DE INDENIZACAO  //      */
        /*"      *                                                             //      */
        /*"      * CALCISTA/PROGRAMADOR :    SANDRA                            //      */
        /*"      * DATA                 :    JULHO   / 2003                    //      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *                                                                       */
        /*"      * MANUTENCOES:                                                          */
        /*"      *                                                                       */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *---------------------*                                                 */
        #endregion


        #region VARIABLES

        public FileBasis _ARQCALC { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis ARQCALC
        {
            get
            {
                _.Move(REG_ARQCALC, _ARQCALC); VarBasis.RedefinePassValue(REG_ARQCALC, _ARQCALC, REG_ARQCALC); return _ARQCALC;
            }
        }
        /*"01  REG-ARQCALC                 PIC X(600).*/
        public StringBasis REG_ARQCALC { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-PERC-PARTICIPACAO           PIC S9(03)V9(04) COMP-3.*/
        public DoubleBasis HOST_PERC_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(04)"), 4);
        /*"77  HOST-PLD-CORRECAO-SEM-CEF        PIC S9(11)V99 COMP-3.*/
        public DoubleBasis HOST_PLD_CORRECAO_SEM_CEF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  HOST-NUM-CONTRATO                PIC X(23).*/
        public StringBasis HOST_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)."), @"");
        /*"77  HOST-DATA-INI                    PIC X(10).*/
        public StringBasis HOST_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-FIN                    PIC X(10).*/
        public StringBasis HOST_DATA_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-PRODUTO                     PIC S9(04) COMP.*/
        public IntBasis HOST_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  NL-DT-PRI-PREST-PAGA             PIC S9(04) COMP.*/
        public IntBasis NL_DT_PRI_PREST_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  NL-DT-ULT-PREST-PAGA             PIC S9(04) COMP.*/
        public IntBasis NL_DT_ULT_PREST_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  NL-NUM-ULT-PREST-PAGA            PIC S9(04) COMP.*/
        public IntBasis NL_NUM_ULT_PREST_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-CHAVE-JA-LEU-CLIENTE           PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_JA_LEU_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-CHAVE-ESTORNO-APOS-DTMOVABE    PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_ESTORNO_APOS_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-CHAVE-APOLICE-EH-BILHETE       PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_APOLICE_EH_BILHETE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-CHAVE-APOLICE-EH-AUTO          PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_APOLICE_EH_AUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"01 INICIO-WORK.*/
        public SI0882B_INICIO_WORK INICIO_WORK { get; set; } = new SI0882B_INICIO_WORK();
        public class SI0882B_INICIO_WORK : VarBasis
        {
            /*"    03 W-IND-FIM-CTRAB               PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_CTRAB { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-FIM-RELAT               PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_RELAT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CONTA-LIDOS                 PIC 9(05) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 W-CONTA-LIDOS1                PIC 9(05) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 W-CALC-VLR-SALDO-DEV          PIC 9(11)V99 VALUE ZEROS.*/
            public DoubleBasis W_CALC_VLR_SALDO_DEV { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V99"), 2);
            /*"    03 W-CALC-VLR-PART-CEF           PIC 9(11)V99 VALUE ZEROS.*/
            public DoubleBasis W_CALC_VLR_PART_CEF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V99"), 2);
            /*"    03 W-CALC-PERC-PARTIC            PIC 9(03)V99 VALUE ZEROS.*/
            public DoubleBasis W_CALC_PERC_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    03 W-CALC-PLD-CORR-SEM-CEF       PIC 9(11)V99 VALUE ZEROS.*/
            public DoubleBasis W_CALC_PLD_CORR_SEM_CEF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V99"), 2);
            /*"    03 W-CALC-PLD-INICIAL-CORR       PIC 9(11)V9(04) VALUE ZEROS*/
            public DoubleBasis W_CALC_PLD_INICIAL_CORR { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(04)"), 4);
            /*"01  CAB-CALC-0.*/
        }
        public SI0882B_CAB_CALC_0 CAB_CALC_0 { get; set; } = new SI0882B_CAB_CALC_0();
        public class SI0882B_CAB_CALC_0 : VarBasis
        {
            /*"    03 FILLER                  PIC X(25) VALUE    'CAIXA SEGUROS - SINISTRO'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"CAIXA SEGUROS - SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB-CALC-1.*/
        }
        public SI0882B_CAB_CALC_1 CAB_CALC_1 { get; set; } = new SI0882B_CAB_CALC_1();
        public class SI0882B_CAB_CALC_1 : VarBasis
        {
            /*"    03 FILLER                  PIC X(35) VALUE    'CALCULOS DE INDENIZACAO DO PRODUTO '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"CALCULOS DE INDENIZACAO DO PRODUTO ");
            /*"    03 CAB-COD-PRODUTO         PIC 9(04) VALUE ZEROS.*/
            public IntBasis CAB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(16) VALUE       '  NO PERIODO DE '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"  NO PERIODO DE ");
            /*"    03 CAB-DATA-INI            PIC X(10).*/
            public StringBasis CAB_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03 FILLER                  PIC X(03) VALUE ' A'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" A");
            /*"    03 CAB-DATA-FIN            PIC X(10).*/
            public StringBasis CAB_DATA_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB-CALC-2.*/
        }
        public SI0882B_CAB_CALC_2 CAB_CALC_2 { get; set; } = new SI0882B_CAB_CALC_2();
        public class SI0882B_CAB_CALC_2 : VarBasis
        {
            /*"    03 FILLER                  PIC X(12) VALUE                               'NUM SINISTRO'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(23) VALUE                               'NUM CONTRATO'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"NUM CONTRATO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(08) VALUE                               'SEGURADO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DATA PRIM PREST'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA PRIM PREST");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(14) VALUE                               'DATA ULT PREST'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA ULT PREST");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(18) VALUE                               'NUM ULT PREST PAGA'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"NUM ULT PREST PAGA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(10) VALUE                               'VAL PREMIO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VAL PREMIO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(18) VALUE                               'QTD PRE ARECUPERAR'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"QTD PRE ARECUPERAR");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(13) VALUE                               'VLR SALDO DEV'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"VLR SALDO DEV");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(22) VALUE                               'PLD CORR PROP PART SEG'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"PLD CORR PROP PART SEG");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(12) VALUE                               'VLR PART CEF'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VLR PART CEF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(13) VALUE                               'PERC PART CEF'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PERC PART CEF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(16) VALUE                               'PLD CORR SEM CEF'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"PLD CORR SEM CEF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(28) VALUE                               'PLD PREM RECUP PROP PART SEG'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"PLD PREM RECUP PROP PART SEG");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(13) VALUE                               'PERC PART SEG'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PERC PART SEG");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VAL INDENIZACAO'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VAL INDENIZACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'NUM SIVAT'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUM SIVAT");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(11) VALUE                               'COD PRODUTO'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD PRODUTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'NOME DO PRODUTO'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO PRODUTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(16) VALUE                               'DATA INDENIZACAO'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"DATA INDENIZACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CALC.*/
        }
        public SI0882B_CALC CALC { get; set; } = new SI0882B_CALC();
        public class SI0882B_CALC : VarBasis
        {
            /*"    03 CALC-NUM-SINISTRO       PIC 9(13) VALUE 0.*/
            public IntBasis CALC_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUM-CONTRATO       PIC X(23) VALUE SPACES.*/
            public StringBasis CALC_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-SEGURADO           PIC X(40) VALUE SPACES.*/
            public StringBasis CALC_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DATA-PRI-PREST     PIC X(10) VALUE SPACES.*/
            public StringBasis CALC_DATA_PRI_PREST { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DATA-ULT-PREST     PIC X(10) VALUE SPACES.*/
            public StringBasis CALC_DATA_ULT_PREST { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUM-ULT-PREST-PAGA PIC ---9 BLANK WHEN ZEROS.*/
            public IntBasis CALC_NUM_ULT_PREST_PAGA { get; set; } = new IntBasis(new PIC("9", "4", "---9"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VAL-PREMIO         PIC -----99,99.*/
            public DoubleBasis CALC_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "7", "-----99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-QTD-PRE-ARECUPERAR PIC ---9.*/
            public IntBasis CALC_QTD_PRE_ARECUPERAR { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VLR-SALDO-DEV      PIC ------------9,99.*/
            public DoubleBasis CALC_VLR_SALDO_DEV { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PLD-INICIAL-CORR   PIC ------------9,99.*/
            public DoubleBasis CALC_PLD_INICIAL_CORR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VLR-PART-CEF       PIC ------------9,99.*/
            public DoubleBasis CALC_VLR_PART_CEF { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PERC-PARTIC        PIC --99,99.*/
            public DoubleBasis CALC_PERC_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "4", "--99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PLD-CORR-SEM-CEF   PIC ------------9,99.*/
            public DoubleBasis CALC_PLD_CORR_SEM_CEF { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PERC-PARTIC-SEG    PIC --99,99.*/
            public DoubleBasis CALC_PERC_PARTIC_SEG { get; set; } = new DoubleBasis(new PIC("9", "4", "--99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PLD-PREMIO-ARECUP  PIC ------------9,99.*/
            public DoubleBasis CALC_PLD_PREMIO_ARECUP { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VAL-INDENIZACAO    PIC ------------9,99.*/
            public DoubleBasis CALC_VAL_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUMERO-SIVAT       PIC 9(09).*/
            public IntBasis CALC_NUMERO_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-COD-PRODUTO        PIC 9(04) VALUE 0.*/
            public IntBasis CALC_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NOME-PRODUTO       PIC X(40) VALUE SPACES.*/
            public StringBasis CALC_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DATA-INDENIZ       PIC X(10) VALUE SPACES.*/
            public StringBasis CALC_DATA_INDENIZ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01          WABEND1.*/
        }
        public SI0882B_WABEND1 WABEND1 { get; set; } = new SI0882B_WABEND1();
        public class SI0882B_WABEND1 : VarBasis
        {
            /*"    05      FILLER              PIC  X(10) VALUE           ' SI0882B'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0882B");
            /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(30) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01          WABEND2.*/
        }
        public SI0882B_WABEND2 WABEND2 { get; set; } = new SI0882B_WABEND2();
        public class SI0882B_WABEND2 : VarBasis
        {
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01  W-AUXILIARES.*/
        }
        public SI0882B_W_AUXILIARES W_AUXILIARES { get; set; } = new SI0882B_W_AUXILIARES();
        public class SI0882B_W_AUXILIARES : VarBasis
        {
            /*"    02 W-DATA-DB2.*/
            public SI0882B_W_DATA_DB2 W_DATA_DB2 { get; set; } = new SI0882B_W_DATA_DB2();
            public class SI0882B_W_DATA_DB2 : VarBasis
            {
                /*"       03 W-ANO-DB2             PIC 9(04).*/
                public IntBasis W_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-MES-DB2             PIC 9(02).*/
                public IntBasis W_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-DIA-DB2             PIC 9(02).*/
                public IntBasis W_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    02 W-DATA-PLAN.*/
            }
            public SI0882B_W_DATA_PLAN W_DATA_PLAN { get; set; } = new SI0882B_W_DATA_PLAN();
            public class SI0882B_W_DATA_PLAN : VarBasis
            {
                /*"       03 W-DIA-PLAN            PIC 9(02).*/
                public IntBasis W_DIA_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-MES-PLAN            PIC 9(02).*/
                public IntBasis W_MES_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-ANO-PLAN            PIC 9(04).*/
                public IntBasis W_ANO_PLAN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.SINIPLAN SINIPLAN { get; set; } = new Dclgens.SINIPLAN();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public SI0882B_C1 C1 { get; set; } = new SI0882B_C1();
        public SI0882B_CTRAB CTRAB { get; set; } = new SI0882B_CTRAB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQCALC_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQCALC.SetFile(ARQCALC_FILE_NAME_P);

                /*" -282- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -283- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -284- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -288- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND1.WNR_EXEC_SQL);

                /*" -295- PERFORM Execute_DB_DECLARE_1 */

                Execute_DB_DECLARE_1();

                /*" -297- PERFORM Execute_DB_OPEN_1 */

                Execute_DB_OPEN_1();

                /*" -299- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZERO) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
                {

                    /*" -300- DISPLAY 'ERRO ABRIR CURSOR V0RELATORIOS' */
                    _.Display($"ERRO ABRIR CURSOR V0RELATORIOS");

                    /*" -301- GO TO M-999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -304- PERFORM R041-LER-RELAT. */

                R041_LER_RELAT(true);

                /*" -305- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -306- DISPLAY '*********************************************' */
                    _.Display($"*********************************************");

                    /*" -307- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -308- DISPLAY '*               SI0882B                     *' */
                    _.Display($"*               SI0882B                     *");

                    /*" -309- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -310- DISPLAY '*       SEM MOVIMENTO PARA O DIA            *' */
                    _.Display($"*       SEM MOVIMENTO PARA O DIA            *");

                    /*" -311- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -312- DISPLAY '* NAO FOI ENCONTRADA A SOLICITACAO NA       *' */
                    _.Display($"* NAO FOI ENCONTRADA A SOLICITACAO NA       *");

                    /*" -313- DISPLAY '* V0RELATORIOS                              *' */
                    _.Display($"* V0RELATORIOS                              *");

                    /*" -314- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -315- DISPLAY '*********************************************' */
                    _.Display($"*********************************************");

                    /*" -316- STOP RUN. */

                    throw new GoBack();   // => STOP RUN.
                }


                /*" -318- OPEN OUTPUT ARQCALC. */
                ARQCALC.Open(REG_ARQCALC);

                /*" -319- WRITE REG-ARQCALC FROM CAB-CALC-0. */
                _.Move(CAB_CALC_0.GetMoveValues(), REG_ARQCALC);

                ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

                /*" -320- MOVE RELATORI-COD-PRODUTOR TO CAB-COD-PRODUTO. */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR, CAB_CALC_1.CAB_COD_PRODUTO);

                /*" -321- MOVE RELATORI-PERI-INICIAL TO W-DATA-DB2. */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, W_AUXILIARES.W_DATA_DB2);

                /*" -322- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

                /*" -323- MOVE W-MES-DB2 TO W-MES-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

                /*" -324- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

                /*" -325- MOVE W-DATA-PLAN TO CAB-DATA-INI. */
                _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_CALC_1.CAB_DATA_INI);

                /*" -326- MOVE RELATORI-PERI-FINAL TO W-DATA-DB2. */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, W_AUXILIARES.W_DATA_DB2);

                /*" -327- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

                /*" -328- MOVE W-MES-DB2 TO W-MES-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

                /*" -329- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

                /*" -330- MOVE W-DATA-PLAN TO CAB-DATA-FIN. */
                _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_CALC_1.CAB_DATA_FIN);

                /*" -331- WRITE REG-ARQCALC FROM CAB-CALC-1. */
                _.Move(CAB_CALC_1.GetMoveValues(), REG_ARQCALC);

                ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

                /*" -332- WRITE REG-ARQCALC FROM CAB-CALC-2. */
                _.Move(CAB_CALC_2.GetMoveValues(), REG_ARQCALC);

                ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

                /*" -333- MOVE 'NAO' TO W-IND-FIM-RELAT. */
                _.Move("NAO", INICIO_WORK.W_IND_FIM_RELAT);

                /*" -335- PERFORM R040-PROCESSA-RELAT THRU R040-EXIT UNTIL W-IND-FIM-RELAT = 'SIM' . */

                while (!(INICIO_WORK.W_IND_FIM_RELAT == "SIM"))
                {

                    R040_PROCESSA_RELAT(true);

                    R041_LER_RELAT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

                }

                /*" -335- PERFORM 000-900-FIM. */

                M_000_900_FIM(true);

                /*" -335- FLUXCONTROL_PERFORM Execute-DB-DECLARE-1 */

                Execute_DB_DECLARE_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-DECLARE-1 */
        public void Execute_DB_DECLARE_1()
        {
            /*" -295- EXEC SQL DECLARE C1 CURSOR FOR SELECT PERI_INICIAL, PERI_FINAL, CODPDT FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0882B' AND SITUACAO = '0' AND IDSISTEM = 'SI' END-EXEC. */
            C1 = new SI0882B_C1(false);
            string GetQuery_C1()
            {
                var query = @$"SELECT PERI_INICIAL
							, PERI_FINAL
							, CODPDT 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'SI0882B' 
							AND SITUACAO = '0' 
							AND IDSISTEM = 'SI'";

                return query;
            }
            C1.GetQueryEvent += GetQuery_C1;

        }

        [StopWatch]
        /*" Execute-DB-OPEN-1 */
        public void Execute_DB_OPEN_1()
        {
            /*" -297- EXEC SQL OPEN C1 END-EXEC. */

            C1.Open();

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-DECLARE-1 */
        public void R030_DECLARE_CTRAB_DB_DECLARE_1()
        {
            /*" -425- EXEC SQL DECLARE CTRAB CURSOR FOR SELECT R.COD_PRODUTO, R.DESCR_PRODUTO, VALUE(P.DT_PRI_PREST_PAGA,DATE( '1900-01-01' )), VALUE(P.DT_ULT_PREST_PAGA,DATE( '1900-01-01' )), S.COD_COBERTURA, P.NUM_APOL_SINISTRO, S.NOME_SEGURADO, P.PERC_PARTICIPACAO, P.VAL_SALDO_DEVEDOR,P.VAL_INDENIZACAO, P.QTD_PRE_ARECUPERAR, P.NUM_ULT_PREST_PAGA, DIGITS(S.OPERACAO) || '.' || DIGITS(DECIMAL(S.PONTO_VENDA,4,0)) || '.' || SUBSTR(DIGITS(S.NUM_CONTRATO),3,7) || '-' || SUBSTR(DIGITS(S.NUM_CONTRATO),10,1) AS NUM_CONTRATO, P.DATA_INDENIZACAO, P.VAL_PREMIO, C.NUMERO_SIVAT FROM SEGUROS.SINI_PLANHABIT01 P, SEGUROS.SINISTRO_HABIT01 S, SEGUROS.PRODUTO R, SEGUROS.RALACAO_CHEQ_DOCTO C WHERE P.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO AND C.NUMDOC_NUM01 = P.NUM_APOL_SINISTRO AND C.OCORR_HISTORICO = P.OCORHIST AND R.COD_PRODUTO = S.COD_PRODUTO AND R.COD_PRODUTO = :RELATORI-COD-PRODUTOR AND P.DATA_INDENIZACAO BETWEEN :RELATORI-PERI-INICIAL AND :RELATORI-PERI-FINAL ORDER BY R.DESCR_PRODUTO, S.NOME_SEGURADO END-EXEC. */
            CTRAB = new SI0882B_CTRAB(true);
            string GetQuery_CTRAB()
            {
                var query = @$"SELECT R.COD_PRODUTO
							, R.DESCR_PRODUTO
							, 
							VALUE(P.DT_PRI_PREST_PAGA
							,DATE( '1900-01-01' ))
							, 
							VALUE(P.DT_ULT_PREST_PAGA
							,DATE( '1900-01-01' ))
							, 
							S.COD_COBERTURA
							, 
							P.NUM_APOL_SINISTRO
							, S.NOME_SEGURADO
							, 
							P.PERC_PARTICIPACAO
							, 
							P.VAL_SALDO_DEVEDOR
							,P.VAL_INDENIZACAO
							, 
							P.QTD_PRE_ARECUPERAR
							, P.NUM_ULT_PREST_PAGA
							, 
							DIGITS(S.OPERACAO) || '.' || 
							DIGITS(DECIMAL(S.PONTO_VENDA
							,4
							,0)) || '.' 
							|| SUBSTR(DIGITS(S.NUM_CONTRATO)
							,3
							,7) || '-' 
							|| SUBSTR(DIGITS(S.NUM_CONTRATO)
							,10
							,1) 
							AS NUM_CONTRATO
							, 
							P.DATA_INDENIZACAO
							, P.VAL_PREMIO
							, 
							C.NUMERO_SIVAT 
							FROM SEGUROS.SINI_PLANHABIT01 P
							, 
							SEGUROS.SINISTRO_HABIT01 S
							, 
							SEGUROS.PRODUTO R
							, 
							SEGUROS.RALACAO_CHEQ_DOCTO C 
							WHERE 
							P.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO 
							AND C.NUMDOC_NUM01 = P.NUM_APOL_SINISTRO 
							AND C.OCORR_HISTORICO = P.OCORHIST 
							AND R.COD_PRODUTO = S.COD_PRODUTO 
							AND R.COD_PRODUTO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR}' 
							AND P.DATA_INDENIZACAO BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							ORDER BY R.DESCR_PRODUTO
							, S.NOME_SEGURADO";

                return query;
            }
            CTRAB.GetQueryEvent += GetQuery_CTRAB;

        }

        [StopWatch]
        /*" R040-PROCESSA-RELAT */
        private void R040_PROCESSA_RELAT(bool isPerform = false)
        {
            /*" -340- MOVE 'NAO' TO W-IND-FIM-CTRAB. */
            _.Move("NAO", INICIO_WORK.W_IND_FIM_CTRAB);

            /*" -342- PERFORM R030-DECLARE-CTRAB THRU R030-EXIT. */

            R030_DECLARE_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


            /*" -344- PERFORM R031-FETCH-CTRAB THRU R031-EXIT. */

            R031_FETCH_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


            /*" -345- IF W-IND-FIM-CTRAB EQUAL 'SIM' */

            if (INICIO_WORK.W_IND_FIM_CTRAB == "SIM")
            {

                /*" -346- DISPLAY 'SI0882B  - NAO HA MOVIMENTACAO DE SINISTRO' */
                _.Display($"SI0882B  - NAO HA MOVIMENTACAO DE SINISTRO");

                /*" -350- DISPLAY 'PARA O PRODUTO ' RELATORI-COD-PRODUTOR ' E PERIODO ' RELATORI-PERI-INICIAL ' A ' RELATORI-PERI-FINAL */

                $"PARA O PRODUTO {RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR} E PERIODO {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL} A {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
                .Display();

                /*" -352- GO TO R041-LER-RELAT. */

                R041_LER_RELAT(); //GOTO
                return;
            }


            /*" -353- PERFORM R100-PROCESSA-CTRAB THRU R100-EXIT UNTIL W-IND-FIM-CTRAB EQUAL 'SIM' . */

            while (!(INICIO_WORK.W_IND_FIM_CTRAB == "SIM"))
            {

                R100_PROCESSA_CTRAB(true);

                R031_FETCH_CTRAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/

                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

            }

        }

        [StopWatch]
        /*" R041-LER-RELAT */
        private void R041_LER_RELAT(bool isPerform = false)
        {
            /*" -358- MOVE '041' TO WNR-EXEC-SQL */
            _.Move("041", WABEND1.WNR_EXEC_SQL);

            /*" -362- PERFORM R041_LER_RELAT_DB_FETCH_1 */

            R041_LER_RELAT_DB_FETCH_1();

            /*" -364- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -365- DISPLAY 'ERRO NO FETCH V0RELATORIOS' */
                _.Display($"ERRO NO FETCH V0RELATORIOS");

                /*" -366- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -367- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -367- MOVE 'SIM' TO W-IND-FIM-RELAT. */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_RELAT);
            }


        }

        [StopWatch]
        /*" R041-LER-RELAT-DB-FETCH-1 */
        public void R041_LER_RELAT_DB_FETCH_1()
        {
            /*" -362- EXEC SQL FETCH C1 INTO :RELATORI-PERI-INICIAL, :RELATORI-PERI-FINAL, :RELATORI-COD-PRODUTOR END-EXEC. */

            if (C1.Fetch())
            {
                _.Move(C1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(C1.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(C1.RELATORI_COD_PRODUTOR, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -372- CLOSE ARQCALC. */
            ARQCALC.Close();

            /*" -374- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", WABEND1.WNR_EXEC_SQL);

            /*" -379- PERFORM M_000_900_FIM_DB_UPDATE_1 */

            M_000_900_FIM_DB_UPDATE_1();

            /*" -382- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -383- DISPLAY 'ERRO NO UPDATE DA V0RELATORIOS' */
                _.Display($"ERRO NO UPDATE DA V0RELATORIOS");

                /*" -385- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -386- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -387- DISPLAY 'SI0882B         *** FIM NORMAL ***' . */
            _.Display($"SI0882B         *** FIM NORMAL ***");

            /*" -387- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-000-900-FIM-DB-UPDATE-1 */
        public void M_000_900_FIM_DB_UPDATE_1()
        {
            /*" -379- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'SI0882B' AND SITUACAO = '0' END-EXEC. */

            var m_000_900_FIM_DB_UPDATE_1_Update1 = new M_000_900_FIM_DB_UPDATE_1_Update1()
            {
            };

            M_000_900_FIM_DB_UPDATE_1_Update1.Execute(m_000_900_FIM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB */
        private void R030_DECLARE_CTRAB(bool isPerform = false)
        {
            /*" -396- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND1.WNR_EXEC_SQL);

            /*" -425- PERFORM R030_DECLARE_CTRAB_DB_DECLARE_1 */

            R030_DECLARE_CTRAB_DB_DECLARE_1();

            /*" -429- PERFORM R030_DECLARE_CTRAB_DB_OPEN_1 */

            R030_DECLARE_CTRAB_DB_OPEN_1();

            /*" -432- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -433- DISPLAY 'ERRO NA ABERTURA DO CURSOR PRINCIPAL ....' */
                _.Display($"ERRO NA ABERTURA DO CURSOR PRINCIPAL ....");

                /*" -434- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -434- END-IF. */
            }


        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-OPEN-1 */
        public void R030_DECLARE_CTRAB_DB_OPEN_1()
        {
            /*" -429- EXEC SQL OPEN CTRAB END-EXEC. */

            CTRAB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-CTRAB */
        private void R100_PROCESSA_CTRAB(bool isPerform = false)
        {
            /*" -444- INITIALIZE CALC. */
            _.Initialize(
                CALC
            );

            /*" -445- MOVE PRODUTO-COD-PRODUTO TO CALC-COD-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, CALC.CALC_COD_PRODUTO);

            /*" -446- MOVE PRODUTO-DESCR-PRODUTO TO CALC-NOME-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, CALC.CALC_NOME_PRODUTO);

            /*" -447- MOVE SINIPLAN-NUM-APOL-SINISTRO TO CALC-NUM-SINISTRO. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO, CALC.CALC_NUM_SINISTRO);

            /*" -448- MOVE SINIHAB1-NOME-SEGURADO TO CALC-SEGURADO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, CALC.CALC_SEGURADO);

            /*" -449- MOVE SINIPLAN-PERC-PARTICIPACAO TO CALC-PERC-PARTIC-SEG. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO, CALC.CALC_PERC_PARTIC_SEG);

            /*" -450- MOVE SINIPLAN-VAL-SALDO-DEVEDOR TO CALC-VLR-SALDO-DEV. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR, CALC.CALC_VLR_SALDO_DEV);

            /*" -451- MOVE SINIPLAN-DATA-INDENIZACAO TO CALC-DATA-INDENIZ. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DATA_INDENIZACAO, CALC.CALC_DATA_INDENIZ);

            /*" -452- MOVE SINIPLAN-VAL-INDENIZACAO TO CALC-VAL-INDENIZACAO. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_INDENIZACAO, CALC.CALC_VAL_INDENIZACAO);

            /*" -453- MOVE SINIPLAN-QTD-PRE-ARECUPERAR TO CALC-QTD-PRE-ARECUPERAR. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR, CALC.CALC_QTD_PRE_ARECUPERAR);

            /*" -454- MOVE SINIPLAN-NUM-ULT-PREST-PAGA TO CALC-NUM-ULT-PREST-PAGA. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_ULT_PREST_PAGA, CALC.CALC_NUM_ULT_PREST_PAGA);

            /*" -455- MOVE SINIPLAN-DT-PRI-PREST-PAGA TO CALC-DATA-PRI-PREST. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_PRI_PREST_PAGA, CALC.CALC_DATA_PRI_PREST);

            /*" -456- MOVE SINIPLAN-DT-ULT-PREST-PAGA TO CALC-DATA-ULT-PREST. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_ULT_PREST_PAGA, CALC.CALC_DATA_ULT_PREST);

            /*" -457- MOVE SINIPLAN-VAL-PREMIO TO CALC-VAL-PREMIO. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO, CALC.CALC_VAL_PREMIO);

            /*" -458- MOVE HOST-NUM-CONTRATO TO CALC-NUM-CONTRATO. */
            _.Move(HOST_NUM_CONTRATO, CALC.CALC_NUM_CONTRATO);

            /*" -459- MOVE RALCHEDO-NUMERO-SIVAT TO CALC-NUMERO-SIVAT. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT, CALC.CALC_NUMERO_SIVAT);

            /*" -460- IF PRODUTO-COD-PRODUTO NOT EQUAL 4801 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO != 4801)
            {

                /*" -461- IF SINIHAB1-COD-COBERTURA = 1 */

                if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA == 1)
                {

                    /*" -462- MOVE 0 TO CALC-PERC-PARTIC */
                    _.Move(0, CALC.CALC_PERC_PARTIC);

                    /*" -463- MOVE 0 TO W-CALC-PERC-PARTIC */
                    _.Move(0, INICIO_WORK.W_CALC_PERC_PARTIC);

                    /*" -464- ELSE */
                }
                else
                {


                    /*" -465- IF SINIHAB1-COD-COBERTURA = 3 */

                    if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA == 3)
                    {

                        /*" -466- MOVE 20 TO CALC-PERC-PARTIC */
                        _.Move(20, CALC.CALC_PERC_PARTIC);

                        /*" -467- MOVE 20 TO W-CALC-PERC-PARTIC */
                        _.Move(20, INICIO_WORK.W_CALC_PERC_PARTIC);

                        /*" -468- ELSE */
                    }
                    else
                    {


                        /*" -469- MOVE 999 TO CALC-PERC-PARTIC */
                        _.Move(999, CALC.CALC_PERC_PARTIC);

                        /*" -470- MOVE 999 TO W-CALC-PERC-PARTIC. */
                        _.Move(999, INICIO_WORK.W_CALC_PERC_PARTIC);
                    }

                }

            }


            /*" -472- COMPUTE W-CALC-VLR-PART-CEF = (SINIPLAN-VAL-SALDO-DEVEDOR / 100) * W-CALC-PERC-PARTIC. */
            INICIO_WORK.W_CALC_VLR_PART_CEF.Value = (SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR / 100f) * INICIO_WORK.W_CALC_PERC_PARTIC;

            /*" -474- COMPUTE W-CALC-PLD-CORR-SEM-CEF = SINIPLAN-VAL-SALDO-DEVEDOR - W-CALC-VLR-PART-CEF. */
            INICIO_WORK.W_CALC_PLD_CORR_SEM_CEF.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR - INICIO_WORK.W_CALC_VLR_PART_CEF;

            /*" -475- MOVE W-CALC-VLR-PART-CEF TO CALC-VLR-PART-CEF. */
            _.Move(INICIO_WORK.W_CALC_VLR_PART_CEF, CALC.CALC_VLR_PART_CEF);

            /*" -476- MOVE W-CALC-PLD-CORR-SEM-CEF TO CALC-PLD-CORR-SEM-CEF. */
            _.Move(INICIO_WORK.W_CALC_PLD_CORR_SEM_CEF, CALC.CALC_PLD_CORR_SEM_CEF);

            /*" -477- IF SINIHAB1-COD-COBERTURA = 1 */

            if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA == 1)
            {

                /*" -480- COMPUTE W-CALC-PLD-INICIAL-CORR = (W-CALC-PLD-CORR-SEM-CEF / 100) * SINIPLAN-PERC-PARTICIPACAO */
                INICIO_WORK.W_CALC_PLD_INICIAL_CORR.Value = (INICIO_WORK.W_CALC_PLD_CORR_SEM_CEF / 100f) * SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO;

                /*" -481- MOVE W-CALC-PLD-INICIAL-CORR TO CALC-PLD-INICIAL-CORR */
                _.Move(INICIO_WORK.W_CALC_PLD_INICIAL_CORR, CALC.CALC_PLD_INICIAL_CORR);

                /*" -482- ELSE */
            }
            else
            {


                /*" -483- MOVE CALC-PLD-CORR-SEM-CEF TO CALC-PLD-INICIAL-CORR. */
                _.Move(CALC.CALC_PLD_CORR_SEM_CEF, CALC.CALC_PLD_INICIAL_CORR);
            }


            /*" -484- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND1.WNR_EXEC_SQL);

            /*" -486- COMPUTE CALC-PLD-PREMIO-ARECUP = SINIPLAN-QTD-PRE-ARECUPERAR * SINIPLAN-VAL-PREMIO. */
            CALC.CALC_PLD_PREMIO_ARECUP.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR * SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO;

            /*" -486- WRITE REG-ARQCALC FROM CALC. */
            _.Move(CALC.GetMoveValues(), REG_ARQCALC);

            ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R031-FETCH-CTRAB */
        private void R031_FETCH_CTRAB(bool isPerform = false)
        {
            /*" -507- PERFORM R031_FETCH_CTRAB_DB_FETCH_1 */

            R031_FETCH_CTRAB_DB_FETCH_1();

            /*" -510- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -512- PERFORM R031_FETCH_CTRAB_DB_CLOSE_1 */

                R031_FETCH_CTRAB_DB_CLOSE_1();

                /*" -514- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -515- DISPLAY 'SI0882B - ERRO CLOSE DO CURSOR CTRAB' */
                    _.Display($"SI0882B - ERRO CLOSE DO CURSOR CTRAB");

                    /*" -516- GO TO M-999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -517- END-IF */
                }


                /*" -518- MOVE 'SIM' TO W-IND-FIM-CTRAB */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_CTRAB);

                /*" -519- GO TO R031-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/ //GOTO
                return;

                /*" -521- END-IF. */
            }


            /*" -522- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -523- DISPLAY 'ERRO FETCH DO CURSOR PRINCIPAL ........' */
                _.Display($"ERRO FETCH DO CURSOR PRINCIPAL ........");

                /*" -524- DISPLAY 'SINISTRO : ' SINIPLAN-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO}");

                /*" -525- DISPLAY 'CONTRATO : ' HOST-NUM-CONTRATO */
                _.Display($"CONTRATO : {HOST_NUM_CONTRATO}");

                /*" -526- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -528- END-IF. */
            }


            /*" -530- ADD 1 TO W-CONTA-LIDOS */
            INICIO_WORK.W_CONTA_LIDOS.Value = INICIO_WORK.W_CONTA_LIDOS + 1;

            /*" -531- IF W-CONTA-LIDOS EQUAL 10000 */

            if (INICIO_WORK.W_CONTA_LIDOS == 10000)
            {

                /*" -532- ADD W-CONTA-LIDOS TO W-CONTA-LIDOS1 */
                INICIO_WORK.W_CONTA_LIDOS1.Value = INICIO_WORK.W_CONTA_LIDOS1 + INICIO_WORK.W_CONTA_LIDOS;

                /*" -533- DISPLAY 'LIDOS ATE AGORA = ' W-CONTA-LIDOS1 */
                _.Display($"LIDOS ATE AGORA = {INICIO_WORK.W_CONTA_LIDOS1}");

                /*" -534- MOVE 0 TO W-CONTA-LIDOS */
                _.Move(0, INICIO_WORK.W_CONTA_LIDOS);

                /*" -536- END-IF. */
            }


            /*" -537- IF NL-DT-PRI-PREST-PAGA EQUAL -1 */

            if (NL_DT_PRI_PREST_PAGA == -1)
            {

                /*" -538- MOVE SPACES TO SINIPLAN-DT-PRI-PREST-PAGA */
                _.Move("", SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_PRI_PREST_PAGA);

                /*" -540- END-IF. */
            }


            /*" -541- IF NL-DT-ULT-PREST-PAGA EQUAL -1 */

            if (NL_DT_ULT_PREST_PAGA == -1)
            {

                /*" -542- MOVE SPACES TO SINIPLAN-DT-ULT-PREST-PAGA */
                _.Move("", SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_ULT_PREST_PAGA);

                /*" -544- END-IF. */
            }


            /*" -545- IF NL-NUM-ULT-PREST-PAGA EQUAL -1 */

            if (NL_NUM_ULT_PREST_PAGA == -1)
            {

                /*" -546- MOVE ZEROS TO SINIPLAN-NUM-ULT-PREST-PAGA */
                _.Move(0, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_ULT_PREST_PAGA);

                /*" -546- END-IF. */
            }


        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-FETCH-1 */
        public void R031_FETCH_CTRAB_DB_FETCH_1()
        {
            /*" -507- EXEC SQL FETCH CTRAB INTO :PRODUTO-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO, :SINIPLAN-DT-PRI-PREST-PAGA:NL-DT-PRI-PREST-PAGA, :SINIPLAN-DT-ULT-PREST-PAGA:NL-DT-ULT-PREST-PAGA, :SINIHAB1-COD-COBERTURA, :SINIPLAN-NUM-APOL-SINISTRO, :SINIHAB1-NOME-SEGURADO, :SINIPLAN-PERC-PARTICIPACAO, :SINIPLAN-VAL-SALDO-DEVEDOR, :SINIPLAN-VAL-INDENIZACAO, :SINIPLAN-QTD-PRE-ARECUPERAR, :SINIPLAN-NUM-ULT-PREST-PAGA:NL-NUM-ULT-PREST-PAGA, :HOST-NUM-CONTRATO, :SINIPLAN-DATA-INDENIZACAO, :SINIPLAN-VAL-PREMIO, :RALCHEDO-NUMERO-SIVAT END-EXEC. */

            if (CTRAB.Fetch())
            {
                _.Move(CTRAB.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(CTRAB.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(CTRAB.SINIPLAN_DT_PRI_PREST_PAGA, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_PRI_PREST_PAGA);
                _.Move(CTRAB.NL_DT_PRI_PREST_PAGA, NL_DT_PRI_PREST_PAGA);
                _.Move(CTRAB.SINIPLAN_DT_ULT_PREST_PAGA, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_ULT_PREST_PAGA);
                _.Move(CTRAB.NL_DT_ULT_PREST_PAGA, NL_DT_ULT_PREST_PAGA);
                _.Move(CTRAB.SINIHAB1_COD_COBERTURA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA);
                _.Move(CTRAB.SINIPLAN_NUM_APOL_SINISTRO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO);
                _.Move(CTRAB.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
                _.Move(CTRAB.SINIPLAN_PERC_PARTICIPACAO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO);
                _.Move(CTRAB.SINIPLAN_VAL_SALDO_DEVEDOR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR);
                _.Move(CTRAB.SINIPLAN_VAL_INDENIZACAO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_INDENIZACAO);
                _.Move(CTRAB.SINIPLAN_QTD_PRE_ARECUPERAR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR);
                _.Move(CTRAB.SINIPLAN_NUM_ULT_PREST_PAGA, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_ULT_PREST_PAGA);
                _.Move(CTRAB.NL_NUM_ULT_PREST_PAGA, NL_NUM_ULT_PREST_PAGA);
                _.Move(CTRAB.HOST_NUM_CONTRATO, HOST_NUM_CONTRATO);
                _.Move(CTRAB.SINIPLAN_DATA_INDENIZACAO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DATA_INDENIZACAO);
                _.Move(CTRAB.SINIPLAN_VAL_PREMIO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO);
                _.Move(CTRAB.RALCHEDO_NUMERO_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);
            }

        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-CLOSE-1 */
        public void R031_FETCH_CTRAB_DB_CLOSE_1()
        {
            /*" -512- EXEC SQL CLOSE CTRAB END-EXEC */

            CTRAB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -562- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -563- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

                /*" -564- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND2.WSQLCODE1);

                /*" -565- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND2.WSQLCODE2);

                /*" -566- DISPLAY WABEND1. */
                _.Display(WABEND1);
            }


            /*" -568- DISPLAY WABEND2. */
            _.Display(WABEND2);

            /*" -569- CLOSE ARQCALC. */
            ARQCALC.Close();

            /*" -569- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -571- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -571- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -579- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

            /*" -582- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -585- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -588- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -591- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -594- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -597- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -600- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -603- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *");

            /*" -606- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -609- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -612- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *");

            /*" -615- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -618- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -621- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -624- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -630- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -632- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -634- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -636- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -638- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -640- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -642- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -644- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -646- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *");

            /*" -648- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -650- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -652- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *");

            /*" -654- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -656- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -658- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -660- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -662- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -662- GO TO 999-999-ROT-ERRO. */

            M_999_999_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}