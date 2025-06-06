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
using Sias.Sinistro.DB2.SI0896B;

namespace Code
{
    public class SI0896B
    {
        public bool IsCall { get; set; }

        public SI0896B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA   : SINISTRO                                        //      */
        /*"      * PROGRAMA  : SI0896B.                                        //      */
        /*"      * OBJETIVO  : GERACAO DE MOVIMENTO DE CALCULO DE INDENIZACAO  //      */
        /*"      *                                                             //      */
        /*"      * CALCISTA/PROGRAMADOR :    SANDRA                            //      */
        /*"      * DATA                 :    JULHO   / 2003                    //      */
        /*"      *                                                             //      */
        /*"      ******************************************************************      */
        /*"      *   ESTE PROGRAMA E UMA COPIA DO PROGRAMA SI0882B QUE GERA UM    *      */
        /*"      *   ARQUIVO PARA SER ABERTO NO EXCEL DO MATERIAL DE CONSTRUCAO   *      */
        /*"      *   E ENVIADO PARA GEPOC (ANTIGA GERES)                          *      */
        /*"      *   O PROGRAMA SI0882B GERAVA O ARQUIVO ATRAVES DOS SIVAT'S      *      */
        /*"      *   ESSE NOVO PROGRAMA (SI0896B) GERA O MESMO ARQUIVO ATRAVES    *      */
        /*"      *   DA CHEQUES E SUBSTITUIRA O NUMERO DO SIVAT PELO CHEQUE       *      */
        /*"      *   POR JEFFERSON EM 28-09-2006                                  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        /*"      * MANUTENCOES:                                                          */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
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
        /*"77  HOST-VAL-PRM-REMANESC            PIC S9(11)V99 COMP-3.*/
        public DoubleBasis HOST_VAL_PRM_REMANESC { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  HOST-VAL-FRANQUIA-CEF            PIC S9(11)V99 COMP-3.*/
        public DoubleBasis HOST_VAL_FRANQUIA_CEF { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
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
        public SI0896B_INICIO_WORK INICIO_WORK { get; set; } = new SI0896B_INICIO_WORK();
        public class SI0896B_INICIO_WORK : VarBasis
        {
            /*"    03 W-CHAVE-TEM-PLANILHA          PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_PLANILHA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
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
            /*"    03 W-VALOR-NOMINAL              PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_VALOR_NOMINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 W-VALOR-CORRECAO             PIC S9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_VALOR_CORRECAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    03 W-CALC-PLD-INICIAL-CORR       PIC 9(11)V9(04) VALUE ZEROS*/
            public DoubleBasis W_CALC_PLD_INICIAL_CORR { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(04)"), 4);
            /*"01  CAB-CALC-0.*/
        }
        public SI0896B_CAB_CALC_0 CAB_CALC_0 { get; set; } = new SI0896B_CAB_CALC_0();
        public class SI0896B_CAB_CALC_0 : VarBasis
        {
            /*"    03 FILLER                  PIC X(25) VALUE    'CAIXA SEGUROS - SINISTRO'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"CAIXA SEGUROS - SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB-CALC-1.*/
        }
        public SI0896B_CAB_CALC_1 CAB_CALC_1 { get; set; } = new SI0896B_CAB_CALC_1();
        public class SI0896B_CAB_CALC_1 : VarBasis
        {
            /*"    03 FILLER                  PIC X(41) VALUE    'CALCULOS DE INDENIZACAO DO(S) PRODUTO(S) '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "41", "X(41)"), @"CALCULOS DE INDENIZACAO DO(S) PRODUTO(S) ");
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
        public SI0896B_CAB_CALC_2 CAB_CALC_2 { get; set; } = new SI0896B_CAB_CALC_2();
        public class SI0896B_CAB_CALC_2 : VarBasis
        {
            /*"    03 FILLER                  PIC X(12) VALUE 'NUM SINISTRO'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(05) VALUE 'GIPRO'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"GIPRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(11) VALUE 'PONTO VENDA'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PONTO VENDA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(23) VALUE 'NUM CONTRATO'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"NUM CONTRATO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(08) VALUE 'SEGURADO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DATA PRIM PREST'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA PRIM PREST");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(14) VALUE 'DATA ULT PREST'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA ULT PREST");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(18) VALUE                               'NUM ULT PREST PAGA'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"NUM ULT PREST PAGA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(10) VALUE 'VAL PREMIO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VAL PREMIO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(18) VALUE                               'QTD PRE ARECUPERAR'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"QTD PRE ARECUPERAR");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(13) VALUE 'VLR SALDO DEV'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"VLR SALDO DEV");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(22) VALUE                               'PLD CORR PROP PART SEG'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"PLD CORR PROP PART SEG");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(12) VALUE 'VLR PART CEF'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VLR PART CEF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(13) VALUE 'PERC PART CEF'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PERC PART CEF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(16) VALUE                               'PLD CORR SEM CEF'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"PLD CORR SEM CEF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(28) VALUE                               'PLD PREM RECUP PROP PART SEG'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"PLD PREM RECUP PROP PART SEG");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(13) VALUE 'PRM REMANESCE'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PRM REMANESCE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(24) VALUE                               'VAL INDENIZACAO S/ATUAL.'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"VAL INDENIZACAO S/ATUAL.");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VAL ATUALIZACAO'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VAL ATUALIZACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VAL INDENIZACAO'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VAL INDENIZACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'PAGTO E COMPLEM'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"PAGTO E COMPLEM");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(19) VALUE                               'NUM SIVAT ESTORNADO'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"NUM SIVAT ESTORNADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(23) VALUE                               'DT EMIS SIVAT ESTORNADO'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"DT EMIS SIVAT ESTORNADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE 'NUM CHEQUE'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUM CHEQUE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(11) VALUE 'COD PRODUTO'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD PRODUTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'NOME DO PRODUTO'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME DO PRODUTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(16) VALUE                               'DATA INDENIZACAO'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"DATA INDENIZACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CALC.*/
        }
        public SI0896B_CALC CALC { get; set; } = new SI0896B_CALC();
        public class SI0896B_CALC : VarBasis
        {
            /*"    03 CALC-NUM-SINISTRO       PIC 9(13) VALUE 0.*/
            public IntBasis CALC_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-COD-GIPRO          PIC 9(05) VALUE ZEROS.*/
            public IntBasis CALC_COD_GIPRO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PONTO-VENDA        PIC 9(05) VALUE ZEROS.*/
            public IntBasis CALC_PONTO_VENDA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUM-CONTRATO       PIC X(23) VALUE SPACES.*/
            public StringBasis CALC_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-SEGURADO           PIC X(40) VALUE SPACES.*/
            public StringBasis CALC_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DATA-PRI-PREST     PIC X(10) VALUE SPACES.*/
            public StringBasis CALC_DATA_PRI_PREST { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DATA-ULT-PREST     PIC X(10) VALUE SPACES.*/
            public StringBasis CALC_DATA_ULT_PREST { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUM-ULT-PREST-PAGA PIC ---9 BLANK WHEN ZEROS.*/
            public IntBasis CALC_NUM_ULT_PREST_PAGA { get; set; } = new IntBasis(new PIC("9", "4", "---9"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VAL-PREMIO         PIC -----99,99.*/
            public DoubleBasis CALC_VAL_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "7", "-----99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-QTD-PRE-ARECUPERAR PIC ---9.*/
            public IntBasis CALC_QTD_PRE_ARECUPERAR { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VLR-SALDO-DEV      PIC ------------9,99.*/
            public DoubleBasis CALC_VLR_SALDO_DEV { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PLD-INICIAL-CORR   PIC ------------9,99.*/
            public DoubleBasis CALC_PLD_INICIAL_CORR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VLR-PART-CEF       PIC ------------9,99.*/
            public DoubleBasis CALC_VLR_PART_CEF { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PERC-PARTIC        PIC --99,99.*/
            public DoubleBasis CALC_PERC_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "4", "--99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PLD-CORR-SEM-CEF   PIC ------------9,99.*/
            public DoubleBasis CALC_PLD_CORR_SEM_CEF { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PERC-PARTIC-SEG    PIC --99,99.*/
            public DoubleBasis CALC_PERC_PARTIC_SEG { get; set; } = new DoubleBasis(new PIC("9", "4", "--99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-PLD-PREMIO-ARECUP  PIC ------------9,99.*/
            public DoubleBasis CALC_PLD_PREMIO_ARECUP { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VAL-IND-SEM-ATU    PIC ------------9,99.*/
            public DoubleBasis CALC_VAL_IND_SEM_ATU { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VAL-ATUALIZACAO    PIC ------------9,99.*/
            public DoubleBasis CALC_VAL_ATUALIZACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-VAL-INDENIZACAO    PIC ------------9,99.*/
            public DoubleBasis CALC_VAL_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-IDE-VAL-COMPLEM    PIC X(03) VALUE SPACES.*/
            public StringBasis CALC_IDE_VAL_COMPLEM { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUM-SIVAT-ESTOR    PIC 9(09).*/
            public IntBasis CALC_NUM_SIVAT_ESTOR { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DT-EMIS-SIVAT-EST  PIC X(10).*/
            public StringBasis CALC_DT_EMIS_SIVAT_EST { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NUMERO-SIVAT       PIC 9(09).*/
            public IntBasis CALC_NUMERO_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-COD-PRODUTO        PIC 9(04) VALUE 0.*/
            public IntBasis CALC_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-NOME-PRODUTO       PIC X(40) VALUE SPACES.*/
            public StringBasis CALC_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 CALC-DATA-INDENIZ       PIC X(10) VALUE SPACES.*/
            public StringBasis CALC_DATA_INDENIZ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01          WABEND1.*/
        }
        public SI0896B_WABEND1 WABEND1 { get; set; } = new SI0896B_WABEND1();
        public class SI0896B_WABEND1 : VarBasis
        {
            /*"    05      FILLER              PIC  X(10) VALUE           ' SI0896B'.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0896B");
            /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(30) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01          WABEND2.*/
        }
        public SI0896B_WABEND2 WABEND2 { get; set; } = new SI0896B_WABEND2();
        public class SI0896B_WABEND2 : VarBasis
        {
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01  W-AUXILIARES.*/
        }
        public SI0896B_W_AUXILIARES W_AUXILIARES { get; set; } = new SI0896B_W_AUXILIARES();
        public class SI0896B_W_AUXILIARES : VarBasis
        {
            /*"    02 W-DATA-DB2.*/
            public SI0896B_W_DATA_DB2 W_DATA_DB2 { get; set; } = new SI0896B_W_DATA_DB2();
            public class SI0896B_W_DATA_DB2 : VarBasis
            {
                /*"       03 W-ANO-DB2             PIC 9(04).*/
                public IntBasis W_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-MES-DB2             PIC 9(02).*/
                public IntBasis W_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-DIA-DB2             PIC 9(02).*/
                public IntBasis W_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    02 W-DATA-PLAN.*/
            }
            public SI0896B_W_DATA_PLAN W_DATA_PLAN { get; set; } = new SI0896B_W_DATA_PLAN();
            public class SI0896B_W_DATA_PLAN : VarBasis
            {
                /*"       03 W-DIA-PLAN            PIC 9(02).*/
                public IntBasis W_DIA_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-MES-PLAN            PIC 9(02).*/
                public IntBasis W_MES_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-ANO-PLAN            PIC 9(04).*/
                public IntBasis W_ANO_PLAN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"01   W-TABELA-DISPLAY           VALUE ZEROS.*/
            }
        }
        public SI0896B_W_TABELA_DISPLAY W_TABELA_DISPLAY { get; set; } = new SI0896B_W_TABELA_DISPLAY();
        public class SI0896B_W_TABELA_DISPLAY : VarBasis
        {
            /*" 05  W-TABELA-DISPLAY-OCC      OCCURS 99 TIMES.*/
            public ListBasis<SI0896B_W_TABELA_DISPLAY_OCC> W_TABELA_DISPLAY_OCC { get; set; } = new ListBasis<SI0896B_W_TABELA_DISPLAY_OCC>(99);
            public class SI0896B_W_TABELA_DISPLAY_OCC : VarBasis
            {
                /*"  10 W-TAB-PRODUTO              PIC 9(04).*/
                public IntBasis W_TAB_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  10 W-TAB-QUANTIDADE           PIC 9(02).*/
                public IntBasis W_TAB_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"01   WIND01                     PIC 9(02) VALUE ZEROS.*/
            }
        }
        public IntBasis WIND01 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
        /*"01   WIND02                     PIC 9(02) VALUE ZEROS.*/
        public IntBasis WIND02 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.SINIPLAN SINIPLAN { get; set; } = new Dclgens.SINIPLAN();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public SI0896B_C1 C1 { get; set; } = new SI0896B_C1();
        public SI0896B_CTRAB CTRAB { get; set; } = new SI0896B_CTRAB();
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

                /*" -340- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -341- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -342- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -346- INITIALIZE W-TABELA-DISPLAY. */
                _.Initialize(
                    W_TABELA_DISPLAY
                );

                /*" -348- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND1.WNR_EXEC_SQL);

                /*" -356- PERFORM Execute_DB_DECLARE_1 */

                Execute_DB_DECLARE_1();

                /*" -358- PERFORM Execute_DB_OPEN_1 */

                Execute_DB_OPEN_1();

                /*" -360- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZERO) */

                if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
                {

                    /*" -361- DISPLAY 'ERRO ABRIR CURSOR V0RELATORIOS' */
                    _.Display($"ERRO ABRIR CURSOR V0RELATORIOS");

                    /*" -362- GO TO M-999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -365- PERFORM R041-LER-RELAT. */

                R041_LER_RELAT(true);

                /*" -366- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -367- DISPLAY '*********************************************' */
                    _.Display($"*********************************************");

                    /*" -368- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -369- DISPLAY '*               SI0896B                     *' */
                    _.Display($"*               SI0896B                     *");

                    /*" -370- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -371- DISPLAY '*       SEM MOVIMENTO PARA O DIA            *' */
                    _.Display($"*       SEM MOVIMENTO PARA O DIA            *");

                    /*" -372- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -373- DISPLAY '* NAO FOI ENCONTRADA A SOLICITACAO NA       *' */
                    _.Display($"* NAO FOI ENCONTRADA A SOLICITACAO NA       *");

                    /*" -374- DISPLAY '* V0RELATORIOS                              *' */
                    _.Display($"* V0RELATORIOS                              *");

                    /*" -375- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -376- DISPLAY '*********************************************' */
                    _.Display($"*********************************************");

                    /*" -377- STOP RUN. */

                    throw new GoBack();   // => STOP RUN.
                }


                /*" -379- OPEN OUTPUT ARQCALC. */
                ARQCALC.Open(REG_ARQCALC);

                /*" -381- WRITE REG-ARQCALC FROM CAB-CALC-0. */
                _.Move(CAB_CALC_0.GetMoveValues(), REG_ARQCALC);

                ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

                /*" -382- MOVE RELATORI-PERI-INICIAL TO W-DATA-DB2. */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, W_AUXILIARES.W_DATA_DB2);

                /*" -383- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

                /*" -384- MOVE W-MES-DB2 TO W-MES-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

                /*" -385- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

                /*" -386- MOVE W-DATA-PLAN TO CAB-DATA-INI. */
                _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_CALC_1.CAB_DATA_INI);

                /*" -387- MOVE RELATORI-PERI-FINAL TO W-DATA-DB2. */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, W_AUXILIARES.W_DATA_DB2);

                /*" -388- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

                /*" -389- MOVE W-MES-DB2 TO W-MES-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

                /*" -390- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

                /*" -391- MOVE W-DATA-PLAN TO CAB-DATA-FIN. */
                _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_CALC_1.CAB_DATA_FIN);

                /*" -392- WRITE REG-ARQCALC FROM CAB-CALC-1. */
                _.Move(CAB_CALC_1.GetMoveValues(), REG_ARQCALC);

                ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

                /*" -393- WRITE REG-ARQCALC FROM CAB-CALC-2. */
                _.Move(CAB_CALC_2.GetMoveValues(), REG_ARQCALC);

                ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

                /*" -394- MOVE 'NAO' TO W-IND-FIM-RELAT. */
                _.Move("NAO", INICIO_WORK.W_IND_FIM_RELAT);

                /*" -396- PERFORM R040-PROCESSA-RELAT THRU R040-EXIT UNTIL W-IND-FIM-RELAT = 'SIM' . */

                while (!(INICIO_WORK.W_IND_FIM_RELAT == "SIM"))
                {

                    R040_PROCESSA_RELAT(true);

                    R041_LER_RELAT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

                }

                /*" -396- PERFORM 000-900-FIM. */

                M_000_900_FIM(true);

                /*" -396- FLUXCONTROL_PERFORM Execute-DB-DECLARE-1 */

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
            /*" -356- EXEC SQL DECLARE C1 CURSOR FOR SELECT DISTINCT PERI_INICIAL, PERI_FINAL, CODPDT FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'SI0896B' AND SITUACAO = '0' AND IDSISTEM = 'SI' ORDER BY PERI_INICIAL, PERI_FINAL, CODPDT END-EXEC. */
            C1 = new SI0896B_C1(false);
            string GetQuery_C1()
            {
                var query = @$"SELECT DISTINCT PERI_INICIAL
							, PERI_FINAL
							, CODPDT 
							FROM SEGUROS.V0RELATORIOS 
							WHERE CODRELAT = 'SI0896B' 
							AND SITUACAO = '0' 
							AND IDSISTEM = 'SI' 
							ORDER BY PERI_INICIAL
							, PERI_FINAL
							, CODPDT";

                return query;
            }
            C1.GetQueryEvent += GetQuery_C1;

        }

        [StopWatch]
        /*" Execute-DB-OPEN-1 */
        public void Execute_DB_OPEN_1()
        {
            /*" -358- EXEC SQL OPEN C1 END-EXEC. */

            C1.Open();

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-DECLARE-1 */
        public void R030_DECLARE_CTRAB_DB_DECLARE_1()
        {
            /*" -495- EXEC SQL DECLARE CTRAB CURSOR FOR SELECT R.COD_PRODUTO, R.DESCR_PRODUTO, VALUE(P.DT_PRI_PREST_PAGA,DATE( '1900-01-01' )), VALUE(P.DT_ULT_PREST_PAGA,DATE( '1900-01-01' )), S.COD_COBERTURA, P.NUM_APOL_SINISTRO, S.NOME_SEGURADO, P.PERC_PARTICIPACAO, P.VAL_SALDO_DEVEDOR,P.VAL_INDENIZACAO, P.QTD_PRE_ARECUPERAR, P.NUM_ULT_PREST_PAGA, P.OCORHIST, S.PONTO_VENDA, DIGITS(S.OPERACAO) || '.' || DIGITS(DECIMAL(S.PONTO_VENDA,4,0)) || '.' || SUBSTR(DIGITS(S.NUM_CONTRATO),3,7) || '-' || SUBSTR(DIGITS(S.NUM_CONTRATO),10,1) AS NUM_CONTRATO, P.DATA_INDENIZACAO, P.VAL_PREMIO, C.NUM_CHEQUE_INTERNO FROM SEGUROS.SINI_PLANHABIT01 P, SEGUROS.SINISTRO_HABIT01 S, SEGUROS.PRODUTO R, SEGUROS.SI_SINI_CHEQUE C WHERE P.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO AND C.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND C.OCORR_HISTORICO = P.OCORHIST AND R.COD_PRODUTO = S.COD_PRODUTO AND R.COD_PRODUTO = :RELATORI-COD-PRODUTOR AND P.DATA_INDENIZACAO BETWEEN :RELATORI-PERI-INICIAL AND :RELATORI-PERI-FINAL ORDER BY R.DESCR_PRODUTO, S.NOME_SEGURADO END-EXEC. */
            CTRAB = new SI0896B_CTRAB(true);
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
							P.OCORHIST
							, 
							S.PONTO_VENDA
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
							C.NUM_CHEQUE_INTERNO 
							FROM SEGUROS.SINI_PLANHABIT01 P
							, 
							SEGUROS.SINISTRO_HABIT01 S
							, 
							SEGUROS.PRODUTO R
							, 
							SEGUROS.SI_SINI_CHEQUE C 
							WHERE 
							P.NUM_APOL_SINISTRO = S.NUM_APOL_SINISTRO 
							AND C.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO 
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
            /*" -401- MOVE 'NAO' TO W-IND-FIM-CTRAB. */
            _.Move("NAO", INICIO_WORK.W_IND_FIM_CTRAB);

            /*" -403- PERFORM R030-DECLARE-CTRAB THRU R030-EXIT. */

            R030_DECLARE_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


            /*" -405- PERFORM R031-FETCH-CTRAB THRU R031-EXIT. */

            R031_FETCH_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


            /*" -406- IF W-IND-FIM-CTRAB EQUAL 'SIM' */

            if (INICIO_WORK.W_IND_FIM_CTRAB == "SIM")
            {

                /*" -407- DISPLAY 'SI0896B  - NAO HA MOVIMENTACAO DE SINISTRO' */
                _.Display($"SI0896B  - NAO HA MOVIMENTACAO DE SINISTRO");

                /*" -411- DISPLAY 'PARA O PRODUTO ' RELATORI-COD-PRODUTOR ' E PERIODO ' RELATORI-PERI-INICIAL ' A ' RELATORI-PERI-FINAL */

                $"PARA O PRODUTO {RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR} E PERIODO {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL} A {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
                .Display();

                /*" -412- GO TO R041-LER-RELAT */

                R041_LER_RELAT(); //GOTO
                return;

                /*" -414- END-IF. */
            }


            /*" -415- PERFORM R100-PROCESSA-CTRAB THRU R100-EXIT UNTIL W-IND-FIM-CTRAB EQUAL 'SIM' . */

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
            /*" -420- MOVE '041' TO WNR-EXEC-SQL */
            _.Move("041", WABEND1.WNR_EXEC_SQL);

            /*" -424- PERFORM R041_LER_RELAT_DB_FETCH_1 */

            R041_LER_RELAT_DB_FETCH_1();

            /*" -426- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL ZERO) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 00))
            {

                /*" -427- DISPLAY 'ERRO NO FETCH V0RELATORIOS' */
                _.Display($"ERRO NO FETCH V0RELATORIOS");

                /*" -428- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -429- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -430- MOVE 'SIM' TO W-IND-FIM-RELAT. */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_RELAT);
            }


            /*" -431- IF (SQLCODE EQUAL 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -431- ADD 1 TO WIND01. */
                WIND01.Value = WIND01 + 1;
            }


        }

        [StopWatch]
        /*" R041-LER-RELAT-DB-FETCH-1 */
        public void R041_LER_RELAT_DB_FETCH_1()
        {
            /*" -424- EXEC SQL FETCH C1 INTO :RELATORI-PERI-INICIAL, :RELATORI-PERI-FINAL, :RELATORI-COD-PRODUTOR END-EXEC. */

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
            /*" -436- CLOSE ARQCALC. */
            ARQCALC.Close();

            /*" -438- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", WABEND1.WNR_EXEC_SQL);

            /*" -443- PERFORM M_000_900_FIM_DB_UPDATE_1 */

            M_000_900_FIM_DB_UPDATE_1();

            /*" -446- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -447- DISPLAY 'ERRO NO UPDATE DA V0RELATORIOS' */
                _.Display($"ERRO NO UPDATE DA V0RELATORIOS");

                /*" -449- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -450- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -451- MOVE ZEROS TO WIND02. */
            _.Move(0, WIND02);

            /*" -453- PERFORM R199-IMPRIME-PRODUTOS THRU R199-EXIT UNTIL WIND02 = WIND01. */

            while (!(WIND02 == WIND01))
            {

                R199_IMPRIME_PRODUTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R199_EXIT*/

            }

            /*" -454- DISPLAY 'SI0896B         *** FIM NORMAL ***' . */
            _.Display($"SI0896B         *** FIM NORMAL ***");

            /*" -454- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-000-900-FIM-DB-UPDATE-1 */
        public void M_000_900_FIM_DB_UPDATE_1()
        {
            /*" -443- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'SI0896B' AND SITUACAO = '0' END-EXEC. */

            var m_000_900_FIM_DB_UPDATE_1_Update1 = new M_000_900_FIM_DB_UPDATE_1_Update1()
            {
            };

            M_000_900_FIM_DB_UPDATE_1_Update1.Execute(m_000_900_FIM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB */
        private void R030_DECLARE_CTRAB(bool isPerform = false)
        {
            /*" -463- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND1.WNR_EXEC_SQL);

            /*" -495- PERFORM R030_DECLARE_CTRAB_DB_DECLARE_1 */

            R030_DECLARE_CTRAB_DB_DECLARE_1();

            /*" -499- PERFORM R030_DECLARE_CTRAB_DB_OPEN_1 */

            R030_DECLARE_CTRAB_DB_OPEN_1();

            /*" -502- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -503- DISPLAY 'ERRO NA ABERTURA DO CURSOR PRINCIPAL ....' */
                _.Display($"ERRO NA ABERTURA DO CURSOR PRINCIPAL ....");

                /*" -504- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -504- END-IF. */
            }


        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-OPEN-1 */
        public void R030_DECLARE_CTRAB_DB_OPEN_1()
        {
            /*" -499- EXEC SQL OPEN CTRAB END-EXEC. */

            CTRAB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-CTRAB */
        private void R100_PROCESSA_CTRAB(bool isPerform = false)
        {
            /*" -513- INITIALIZE CALC. */
            _.Initialize(
                CALC
            );

            /*" -514- ADD 1 TO W-TAB-QUANTIDADE(WIND01). */
            W_TABELA_DISPLAY.W_TABELA_DISPLAY_OCC[WIND01].W_TAB_QUANTIDADE.Value = W_TABELA_DISPLAY.W_TABELA_DISPLAY_OCC[WIND01].W_TAB_QUANTIDADE + 1;

            /*" -516- MOVE RELATORI-COD-PRODUTOR TO W-TAB-PRODUTO(WIND01). */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR, W_TABELA_DISPLAY.W_TABELA_DISPLAY_OCC[WIND01].W_TAB_PRODUTO);

            /*" -517- MOVE PRODUTO-COD-PRODUTO TO CALC-COD-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, CALC.CALC_COD_PRODUTO);

            /*" -518- MOVE PRODUTO-DESCR-PRODUTO TO CALC-NOME-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, CALC.CALC_NOME_PRODUTO);

            /*" -519- MOVE SINIPLAN-NUM-APOL-SINISTRO TO CALC-NUM-SINISTRO. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO, CALC.CALC_NUM_SINISTRO);

            /*" -520- MOVE SINIHAB1-NOME-SEGURADO TO CALC-SEGURADO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, CALC.CALC_SEGURADO);

            /*" -521- MOVE SINIPLAN-PERC-PARTICIPACAO TO CALC-PERC-PARTIC-SEG. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO, CALC.CALC_PERC_PARTIC_SEG);

            /*" -522- MOVE SINIPLAN-VAL-SALDO-DEVEDOR TO CALC-VLR-SALDO-DEV. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR, CALC.CALC_VLR_SALDO_DEV);

            /*" -523- MOVE SINIPLAN-DATA-INDENIZACAO TO CALC-DATA-INDENIZ. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DATA_INDENIZACAO, CALC.CALC_DATA_INDENIZ);

            /*" -524- MOVE SINIPLAN-VAL-INDENIZACAO TO CALC-VAL-INDENIZACAO. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_INDENIZACAO, CALC.CALC_VAL_INDENIZACAO);

            /*" -525- MOVE SINIPLAN-QTD-PRE-ARECUPERAR TO CALC-QTD-PRE-ARECUPERAR. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR, CALC.CALC_QTD_PRE_ARECUPERAR);

            /*" -526- MOVE SINIPLAN-NUM-ULT-PREST-PAGA TO CALC-NUM-ULT-PREST-PAGA. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_ULT_PREST_PAGA, CALC.CALC_NUM_ULT_PREST_PAGA);

            /*" -527- MOVE SINIPLAN-DT-PRI-PREST-PAGA TO CALC-DATA-PRI-PREST. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_PRI_PREST_PAGA, CALC.CALC_DATA_PRI_PREST);

            /*" -528- MOVE SINIPLAN-DT-ULT-PREST-PAGA TO CALC-DATA-ULT-PREST. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_ULT_PREST_PAGA, CALC.CALC_DATA_ULT_PREST);

            /*" -529- MOVE SINIPLAN-VAL-PREMIO TO CALC-VAL-PREMIO. */
            _.Move(SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO, CALC.CALC_VAL_PREMIO);

            /*" -530- MOVE HOST-NUM-CONTRATO TO CALC-NUM-CONTRATO. */
            _.Move(HOST_NUM_CONTRATO, CALC.CALC_NUM_CONTRATO);

            /*" -534- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO CALC-NUMERO-SIVAT. */
            _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, CALC.CALC_NUMERO_SIVAT);

            /*" -535- MOVE ZEROS TO CALC-COD-GIPRO. */
            _.Move(0, CALC.CALC_COD_GIPRO);

            /*" -537- MOVE SINIHAB1-PONTO-VENDA TO CALC-PONTO-VENDA. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, CALC.CALC_PONTO_VENDA);

            /*" -539- PERFORM R200-SELECT-NA-SINISHIS THRU R200-EXIT. */

            R200_SELECT_NA_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -540- MOVE RALCHEDO-NUMERO-SIVAT TO CALC-NUM-SIVAT-ESTOR. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT, CALC.CALC_NUM_SIVAT_ESTOR);

            /*" -542- MOVE RALCHEDO-DATA-SIVAT TO CALC-DT-EMIS-SIVAT-EST. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT, CALC.CALC_DT_EMIS_SIVAT_EST);

            /*" -543- IF SINISHIS-COD-OPERACAO = 1004 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 1004)
            {

                /*" -544- MOVE 'SIM' TO CALC-IDE-VAL-COMPLEM */
                _.Move("SIM", CALC.CALC_IDE_VAL_COMPLEM);

                /*" -545- ELSE */
            }
            else
            {


                /*" -547- MOVE 'NAO' TO CALC-IDE-VAL-COMPLEM. */
                _.Move("NAO", CALC.CALC_IDE_VAL_COMPLEM);
            }


            /*" -548- PERFORM R210-LE-SINI-PLANHABIT01 THRU R210-EXIT. */

            R210_LE_SINI_PLANHABIT01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -549- PERFORM R220-SELECT-NA-SINISHIS-OPER2 THRU R220-EXIT. */

            R220_SELECT_NA_SINISHIS_OPER2(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/


            /*" -551- PERFORM R230-SELECT-NA-SINISHIS-OPER28 THRU R230-EXIT. */

            R230_SELECT_NA_SINISHIS_OPER28(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R230_EXIT*/


            /*" -553- IF (W-CHAVE-TEM-PLANILHA = 'SIM' ) AND (PRODUTO-COD-PRODUTO = 4812 OR 7001) */

            if ((INICIO_WORK.W_CHAVE_TEM_PLANILHA == "SIM") && (PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.In("4812", "7001")))
            {

                /*" -554- IF SINIPLAN-VAL-PREMIO <= 0 */

                if (SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO <= 0)
                {

                    /*" -555- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-NOMINAL */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, INICIO_WORK.W_VALOR_NOMINAL);

                    /*" -556- MOVE 0 TO W-VALOR-CORRECAO */
                    _.Move(0, INICIO_WORK.W_VALOR_CORRECAO);

                    /*" -557- ELSE */
                }
                else
                {


                    /*" -559- IF SINIPLAN-PERC-PARTICIPACAO < 100 */

                    if (SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO < 100)
                    {

                        /*" -568- COMPUTE W-VALOR-CORRECAO = (SINIPLAN-VAL-INDENIZACAO + HOST-VAL-PRM-REMANESC + HOST-VAL-FRANQUIA-CEF - SINIPLAN-VAL-SALDO-DEVEDOR) * SINIPLAN-PERC-PARTICIPACAO / 100 */
                        INICIO_WORK.W_VALOR_CORRECAO.Value = (SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_INDENIZACAO + HOST_VAL_PRM_REMANESC + HOST_VAL_FRANQUIA_CEF - SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR) * SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO / 100f;

                        /*" -570- ELSE */
                    }
                    else
                    {


                        /*" -577- COMPUTE W-VALOR-CORRECAO = SINIPLAN-VAL-INDENIZACAO + HOST-VAL-PRM-REMANESC + HOST-VAL-FRANQUIA-CEF - SINIPLAN-VAL-SALDO-DEVEDOR */
                        INICIO_WORK.W_VALOR_CORRECAO.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_INDENIZACAO + HOST_VAL_PRM_REMANESC + HOST_VAL_FRANQUIA_CEF - SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR;

                        /*" -580- END-IF */
                    }


                    /*" -582- COMPUTE W-VALOR-NOMINAL = SINISHIS-VAL-OPERACAO - W-VALOR-CORRECAO */
                    INICIO_WORK.W_VALOR_NOMINAL.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO - INICIO_WORK.W_VALOR_CORRECAO;

                    /*" -584- IF W-VALOR-CORRECAO < 0 OR W-VALOR-NOMINAL < 0 */

                    if (INICIO_WORK.W_VALOR_CORRECAO < 0 || INICIO_WORK.W_VALOR_NOMINAL < 0)
                    {

                        /*" -585- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-NOMINAL */
                        _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, INICIO_WORK.W_VALOR_NOMINAL);

                        /*" -586- MOVE 0 TO W-VALOR-CORRECAO */
                        _.Move(0, INICIO_WORK.W_VALOR_CORRECAO);

                        /*" -587- END-IF */
                    }


                    /*" -588- END-IF */
                }


                /*" -589- ELSE */
            }
            else
            {


                /*" -590- MOVE SINISHIS-VAL-OPERACAO TO W-VALOR-NOMINAL */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, INICIO_WORK.W_VALOR_NOMINAL);

                /*" -592- MOVE 0 TO W-VALOR-CORRECAO. */
                _.Move(0, INICIO_WORK.W_VALOR_CORRECAO);
            }


            /*" -593- MOVE W-VALOR-NOMINAL TO CALC-VAL-IND-SEM-ATU. */
            _.Move(INICIO_WORK.W_VALOR_NOMINAL, CALC.CALC_VAL_IND_SEM_ATU);

            /*" -595- MOVE W-VALOR-CORRECAO TO CALC-VAL-ATUALIZACAO. */
            _.Move(INICIO_WORK.W_VALOR_CORRECAO, CALC.CALC_VAL_ATUALIZACAO);

            /*" -596- IF PRODUTO-COD-PRODUTO NOT EQUAL 4801 */

            if (PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO != 4801)
            {

                /*" -597- IF SINIHAB1-COD-COBERTURA = 1 */

                if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA == 1)
                {

                    /*" -598- MOVE 0 TO CALC-PERC-PARTIC */
                    _.Move(0, CALC.CALC_PERC_PARTIC);

                    /*" -599- MOVE 0 TO W-CALC-PERC-PARTIC */
                    _.Move(0, INICIO_WORK.W_CALC_PERC_PARTIC);

                    /*" -600- ELSE */
                }
                else
                {


                    /*" -601- IF SINIHAB1-COD-COBERTURA = 3 */

                    if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA == 3)
                    {

                        /*" -602- MOVE 20 TO CALC-PERC-PARTIC */
                        _.Move(20, CALC.CALC_PERC_PARTIC);

                        /*" -603- MOVE 20 TO W-CALC-PERC-PARTIC */
                        _.Move(20, INICIO_WORK.W_CALC_PERC_PARTIC);

                        /*" -604- ELSE */
                    }
                    else
                    {


                        /*" -605- MOVE 999 TO CALC-PERC-PARTIC */
                        _.Move(999, CALC.CALC_PERC_PARTIC);

                        /*" -609- MOVE 999 TO W-CALC-PERC-PARTIC. */
                        _.Move(999, INICIO_WORK.W_CALC_PERC_PARTIC);
                    }

                }

            }


            /*" -613- MOVE HOST-VAL-FRANQUIA-CEF TO W-CALC-VLR-PART-CEF. */
            _.Move(HOST_VAL_FRANQUIA_CEF, INICIO_WORK.W_CALC_VLR_PART_CEF);

            /*" -615- MOVE SINISHIS-VAL-OPERACAO TO W-CALC-PLD-CORR-SEM-CEF. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, INICIO_WORK.W_CALC_PLD_CORR_SEM_CEF);

            /*" -616- MOVE W-CALC-VLR-PART-CEF TO CALC-VLR-PART-CEF. */
            _.Move(INICIO_WORK.W_CALC_VLR_PART_CEF, CALC.CALC_VLR_PART_CEF);

            /*" -617- MOVE W-CALC-PLD-CORR-SEM-CEF TO CALC-PLD-CORR-SEM-CEF. */
            _.Move(INICIO_WORK.W_CALC_PLD_CORR_SEM_CEF, CALC.CALC_PLD_CORR_SEM_CEF);

            /*" -618- IF SINIHAB1-COD-COBERTURA = 1 */

            if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_COBERTURA == 1)
            {

                /*" -623- COMPUTE W-CALC-PLD-INICIAL-CORR = ((SINIPLAN-VAL-SALDO-DEVEDOR - HOST-VAL-FRANQUIA-CEF) / 100) * SINIPLAN-PERC-PARTICIPACAO */
                INICIO_WORK.W_CALC_PLD_INICIAL_CORR.Value = ((SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR - HOST_VAL_FRANQUIA_CEF) / 100f) * SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO;

                /*" -624- MOVE W-CALC-PLD-INICIAL-CORR TO CALC-PLD-INICIAL-CORR */
                _.Move(INICIO_WORK.W_CALC_PLD_INICIAL_CORR, CALC.CALC_PLD_INICIAL_CORR);

                /*" -625- ELSE */
            }
            else
            {


                /*" -628- COMPUTE W-CALC-PLD-INICIAL-CORR = SINIPLAN-VAL-SALDO-DEVEDOR - HOST-VAL-FRANQUIA-CEF */
                INICIO_WORK.W_CALC_PLD_INICIAL_CORR.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR - HOST_VAL_FRANQUIA_CEF;

                /*" -629- MOVE W-CALC-PLD-INICIAL-CORR TO CALC-PLD-INICIAL-CORR. */
                _.Move(INICIO_WORK.W_CALC_PLD_INICIAL_CORR, CALC.CALC_PLD_INICIAL_CORR);
            }


            /*" -630- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND1.WNR_EXEC_SQL);

            /*" -632- COMPUTE CALC-PLD-PREMIO-ARECUP = SINIPLAN-QTD-PRE-ARECUPERAR * SINIPLAN-VAL-PREMIO. */
            CALC.CALC_PLD_PREMIO_ARECUP.Value = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_QTD_PRE_ARECUPERAR * SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO;

            /*" -632- WRITE REG-ARQCALC FROM CALC. */
            _.Move(CALC.GetMoveValues(), REG_ARQCALC);

            ARQCALC.Write(REG_ARQCALC.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R031-FETCH-CTRAB */
        private void R031_FETCH_CTRAB(bool isPerform = false)
        {
            /*" -656- PERFORM R031_FETCH_CTRAB_DB_FETCH_1 */

            R031_FETCH_CTRAB_DB_FETCH_1();

            /*" -659- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -661- PERFORM R031_FETCH_CTRAB_DB_CLOSE_1 */

                R031_FETCH_CTRAB_DB_CLOSE_1();

                /*" -663- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -664- DISPLAY 'SI0896B - ERRO CLOSE DO CURSOR CTRAB' */
                    _.Display($"SI0896B - ERRO CLOSE DO CURSOR CTRAB");

                    /*" -665- GO TO M-999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -666- END-IF */
                }


                /*" -667- MOVE 'SIM' TO W-IND-FIM-CTRAB */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_CTRAB);

                /*" -668- GO TO R031-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/ //GOTO
                return;

                /*" -670- END-IF. */
            }


            /*" -671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -672- DISPLAY 'ERRO FETCH DO CURSOR PRINCIPAL ........' */
                _.Display($"ERRO FETCH DO CURSOR PRINCIPAL ........");

                /*" -673- DISPLAY 'SINISTRO : ' SINIPLAN-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO}");

                /*" -674- DISPLAY 'CONTRATO : ' HOST-NUM-CONTRATO */
                _.Display($"CONTRATO : {HOST_NUM_CONTRATO}");

                /*" -675- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -677- END-IF. */
            }


            /*" -679- ADD 1 TO W-CONTA-LIDOS */
            INICIO_WORK.W_CONTA_LIDOS.Value = INICIO_WORK.W_CONTA_LIDOS + 1;

            /*" -680- IF W-CONTA-LIDOS EQUAL 10000 */

            if (INICIO_WORK.W_CONTA_LIDOS == 10000)
            {

                /*" -681- ADD W-CONTA-LIDOS TO W-CONTA-LIDOS1 */
                INICIO_WORK.W_CONTA_LIDOS1.Value = INICIO_WORK.W_CONTA_LIDOS1 + INICIO_WORK.W_CONTA_LIDOS;

                /*" -682- DISPLAY 'LIDOS ATE AGORA = ' W-CONTA-LIDOS1 */
                _.Display($"LIDOS ATE AGORA = {INICIO_WORK.W_CONTA_LIDOS1}");

                /*" -683- MOVE 0 TO W-CONTA-LIDOS */
                _.Move(0, INICIO_WORK.W_CONTA_LIDOS);

                /*" -685- END-IF. */
            }


            /*" -686- IF NL-DT-PRI-PREST-PAGA EQUAL -1 */

            if (NL_DT_PRI_PREST_PAGA == -1)
            {

                /*" -687- MOVE SPACES TO SINIPLAN-DT-PRI-PREST-PAGA */
                _.Move("", SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_PRI_PREST_PAGA);

                /*" -689- END-IF. */
            }


            /*" -690- IF NL-DT-ULT-PREST-PAGA EQUAL -1 */

            if (NL_DT_ULT_PREST_PAGA == -1)
            {

                /*" -691- MOVE SPACES TO SINIPLAN-DT-ULT-PREST-PAGA */
                _.Move("", SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DT_ULT_PREST_PAGA);

                /*" -693- END-IF. */
            }


            /*" -694- IF NL-NUM-ULT-PREST-PAGA EQUAL -1 */

            if (NL_NUM_ULT_PREST_PAGA == -1)
            {

                /*" -695- MOVE ZEROS TO SINIPLAN-NUM-ULT-PREST-PAGA */
                _.Move(0, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_ULT_PREST_PAGA);

                /*" -695- END-IF. */
            }


        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-FETCH-1 */
        public void R031_FETCH_CTRAB_DB_FETCH_1()
        {
            /*" -656- EXEC SQL FETCH CTRAB INTO :PRODUTO-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO, :SINIPLAN-DT-PRI-PREST-PAGA:NL-DT-PRI-PREST-PAGA, :SINIPLAN-DT-ULT-PREST-PAGA:NL-DT-ULT-PREST-PAGA, :SINIHAB1-COD-COBERTURA, :SINIPLAN-NUM-APOL-SINISTRO, :SINIHAB1-NOME-SEGURADO, :SINIPLAN-PERC-PARTICIPACAO, :SINIPLAN-VAL-SALDO-DEVEDOR, :SINIPLAN-VAL-INDENIZACAO, :SINIPLAN-QTD-PRE-ARECUPERAR, :SINIPLAN-NUM-ULT-PREST-PAGA:NL-NUM-ULT-PREST-PAGA, :SINIPLAN-OCORHIST, :SINIHAB1-PONTO-VENDA, :HOST-NUM-CONTRATO, :SINIPLAN-DATA-INDENIZACAO, :SINIPLAN-VAL-PREMIO, :SISINCHE-NUM-CHEQUE-INTERNO END-EXEC. */

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
                _.Move(CTRAB.SINIPLAN_OCORHIST, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST);
                _.Move(CTRAB.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(CTRAB.HOST_NUM_CONTRATO, HOST_NUM_CONTRATO);
                _.Move(CTRAB.SINIPLAN_DATA_INDENIZACAO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_DATA_INDENIZACAO);
                _.Move(CTRAB.SINIPLAN_VAL_PREMIO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO);
                _.Move(CTRAB.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
            }

        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-CLOSE-1 */
        public void R031_FETCH_CTRAB_DB_CLOSE_1()
        {
            /*" -661- EXEC SQL CLOSE CTRAB END-EXEC */

            CTRAB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R199-IMPRIME-PRODUTOS */
        private void R199_IMPRIME_PRODUTOS(bool isPerform = false)
        {
            /*" -709- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND1.WNR_EXEC_SQL);

            /*" -710- ADD 1 TO WIND02. */
            WIND02.Value = WIND02 + 1;

            /*" -712- DISPLAY 'PRODUTO...................: ' W-TAB-PRODUTO(WIND02). */
            _.Display($"PRODUTO...................: {W_TABELA_DISPLAY.W_TABELA_DISPLAY_OCC[WIND02]}");

            /*" -713- DISPLAY 'QUANTIDADE LIDA DO PRODUTO: ' W-TAB-QUANTIDADE(WIND02). */
            _.Display($"QUANTIDADE LIDA DO PRODUTO: {W_TABELA_DISPLAY.W_TABELA_DISPLAY_OCC[WIND02]}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R199_EXIT*/

        [StopWatch]
        /*" R200-SELECT-NA-SINISHIS */
        private void R200_SELECT_NA_SINISHIS(bool isPerform = false)
        {
            /*" -725- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WABEND1.WNR_EXEC_SQL);

            /*" -736- PERFORM R200_SELECT_NA_SINISHIS_DB_SELECT_1 */

            R200_SELECT_NA_SINISHIS_DB_SELECT_1();

            /*" -739- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -740- DISPLAY 'ERRO NO SELECT DA SINISTRO-HISTORICO 01' */
                _.Display($"ERRO NO SELECT DA SINISTRO-HISTORICO 01");

                /*" -741- DISPLAY 'SINISTRO      : ' SINIPLAN-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO}");

                /*" -742- DISPLAY 'OCORHISTORICO : ' SINIPLAN-OCORHIST */
                _.Display($"OCORHISTORICO : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST}");

                /*" -743- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -748- END-IF. */
            }


            /*" -764- PERFORM R200_SELECT_NA_SINISHIS_DB_SELECT_2 */

            R200_SELECT_NA_SINISHIS_DB_SELECT_2();

            /*" -768- IF SQLCODE NOT = ZEROS AND SQLCODE NOT = 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -769- DISPLAY 'ERRO NO SELECT DA SINISTRO-HISTORICO 02' */
                _.Display($"ERRO NO SELECT DA SINISTRO-HISTORICO 02");

                /*" -770- DISPLAY 'SINISTRO      : ' SINIPLAN-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO}");

                /*" -771- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -773- END-IF. */
            }


            /*" -774- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -775- MOVE ZEROS TO RALCHEDO-NUMERO-SIVAT */
                _.Move(0, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);

                /*" -776- MOVE SPACES TO RALCHEDO-DATA-SIVAT */
                _.Move("", RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT);

                /*" -778- END-IF. */
            }


            /*" -779- IF RALCHEDO-DATA-SIVAT = '9999-12-31' */

            if (RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT == "9999-12-31")
            {

                /*" -780- MOVE SPACES TO RALCHEDO-DATA-SIVAT */
                _.Move("", RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT);

                /*" -780- END-IF. */
            }


        }

        [StopWatch]
        /*" R200-SELECT-NA-SINISHIS-DB-SELECT-1 */
        public void R200_SELECT_NA_SINISHIS_DB_SELECT_1()
        {
            /*" -736- EXEC SQL SELECT COD_OPERACAO, DATA_MOVIMENTO, VAL_OPERACAO INTO :SINISHIS-COD-OPERACAO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINIPLAN-OCORHIST AND COD_OPERACAO IN (1001,1002,1003,1004,1009) END-EXEC. */

            var r200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1 = new R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1()
            {
                SINIPLAN_NUM_APOL_SINISTRO = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.ToString(),
                SINIPLAN_OCORHIST = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.ToString(),
            };

            var executed_1 = R200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1.Execute(r200_SELECT_NA_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R200-SELECT-NA-SINISHIS-DB-SELECT-2 */
        public void R200_SELECT_NA_SINISHIS_DB_SELECT_2()
        {
            /*" -764- EXEC SQL SELECT A.NUMERO_SIVAT, VALUE(A.DATA_SIVAT,DATE( '9999-12-31' )) INTO :RALCHEDO-NUMERO-SIVAT, :RALCHEDO-DATA-SIVAT FROM SEGUROS.RALACAO_CHEQ_DOCTO A, SEGUROS.SINISTRO_HISTORICO B WHERE A.NUMDOC_NUM01 = :SINIPLAN-NUM-APOL-SINISTRO AND A.NUMDOC_NUM01 = B.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = B.OCORR_HISTORICO AND B.COD_OPERACAO = 1050 AND B.OCORR_HISTORICO = (SELECT VALUE(MAX(C.OCORR_HISTORICO),0) FROM SEGUROS.SINISTRO_HISTORICO C WHERE C.NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO AND C.COD_OPERACAO = 1050) END-EXEC. */

            var r200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1 = new R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1()
            {
                SINIPLAN_NUM_APOL_SINISTRO = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1.Execute(r200_SELECT_NA_SINISHIS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RALCHEDO_NUMERO_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);
                _.Move(executed_1.RALCHEDO_DATA_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT);
            }


        }

        [StopWatch]
        /*" R210-LE-SINI-PLANHABIT01 */
        private void R210_LE_SINI_PLANHABIT01(bool isPerform = false)
        {
            /*" -788- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND1.WNR_EXEC_SQL);

            /*" -790- MOVE 'SIM' TO W-CHAVE-TEM-PLANILHA. */
            _.Move("SIM", INICIO_WORK.W_CHAVE_TEM_PLANILHA);

            /*" -804- PERFORM R210_LE_SINI_PLANHABIT01_DB_SELECT_1 */

            R210_LE_SINI_PLANHABIT01_DB_SELECT_1();

            /*" -807- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -809- MOVE 'NAO' TO W-CHAVE-TEM-PLANILHA. */
                _.Move("NAO", INICIO_WORK.W_CHAVE_TEM_PLANILHA);
            }


            /*" -811- IF ( SQLCODE NOT EQUAL ZEROS ) AND ( SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -814- DISPLAY 'ERRO SELECT - SINI_PLANHABIT01-02' ' ' SINIPLAN-NUM-APOL-SINISTRO ' ' SINIPLAN-OCORHIST */

                $"ERRO SELECT - SINI_PLANHABIT01-02 {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO} {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST}"
                .Display();

                /*" -814- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R210-LE-SINI-PLANHABIT01-DB-SELECT-1 */
        public void R210_LE_SINI_PLANHABIT01_DB_SELECT_1()
        {
            /*" -804- EXEC SQL SELECT VALUE(VAL_SALDO_DEVEDOR,0), VALUE(VAL_ACORRIGIR,0), VALUE(VAL_PREMIO,0), PERC_PARTICIPACAO INTO :SINIPLAN-VAL-SALDO-DEVEDOR, :SINIPLAN-VAL-ACORRIGIR, :SINIPLAN-VAL-PREMIO, :SINIPLAN-PERC-PARTICIPACAO FROM SEGUROS.SINI_PLANHABIT01 WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO AND OCORHIST = :SINIPLAN-OCORHIST END-EXEC. */

            var r210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1 = new R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1()
            {
                SINIPLAN_NUM_APOL_SINISTRO = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.ToString(),
                SINIPLAN_OCORHIST = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.ToString(),
            };

            var executed_1 = R210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1.Execute(r210_LE_SINI_PLANHABIT01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIPLAN_VAL_SALDO_DEVEDOR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_SALDO_DEVEDOR);
                _.Move(executed_1.SINIPLAN_VAL_ACORRIGIR, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_ACORRIGIR);
                _.Move(executed_1.SINIPLAN_VAL_PREMIO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_VAL_PREMIO);
                _.Move(executed_1.SINIPLAN_PERC_PARTICIPACAO, SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_PERC_PARTICIPACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R220-SELECT-NA-SINISHIS-OPER2 */
        private void R220_SELECT_NA_SINISHIS_OPER2(bool isPerform = false)
        {
            /*" -824- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", WABEND1.WNR_EXEC_SQL);

            /*" -831- PERFORM R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1 */

            R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1();

            /*" -834- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -836- MOVE 0 TO HOST-VAL-FRANQUIA-CEF. */
                _.Move(0, HOST_VAL_FRANQUIA_CEF);
            }


            /*" -837- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -838- DISPLAY 'ERRO NO SELECT SINISTRO-HISTORICO OPER=2' */
                _.Display($"ERRO NO SELECT SINISTRO-HISTORICO OPER=2");

                /*" -839- DISPLAY 'SINISTRO      : ' SINIPLAN-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO}");

                /*" -840- DISPLAY 'OCORHISTORICO : ' SINIPLAN-OCORHIST */
                _.Display($"OCORHISTORICO : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST}");

                /*" -841- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -841- END-IF. */
            }


        }

        [StopWatch]
        /*" R220-SELECT-NA-SINISHIS-OPER2-DB-SELECT-1 */
        public void R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1()
        {
            /*" -831- EXEC SQL SELECT VAL_OPERACAO INTO :HOST-VAL-FRANQUIA-CEF FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINIPLAN-OCORHIST AND COD_OPERACAO = 2 END-EXEC. */

            var r220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1 = new R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1()
            {
                SINIPLAN_NUM_APOL_SINISTRO = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.ToString(),
                SINIPLAN_OCORHIST = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.ToString(),
            };

            var executed_1 = R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1.Execute(r220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_FRANQUIA_CEF, HOST_VAL_FRANQUIA_CEF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/

        [StopWatch]
        /*" R230-SELECT-NA-SINISHIS-OPER28 */
        private void R230_SELECT_NA_SINISHIS_OPER28(bool isPerform = false)
        {
            /*" -851- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND1.WNR_EXEC_SQL);

            /*" -858- PERFORM R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1 */

            R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1();

            /*" -861- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -863- MOVE 0 TO HOST-VAL-PRM-REMANESC. */
                _.Move(0, HOST_VAL_PRM_REMANESC);
            }


            /*" -864- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -865- DISPLAY 'ERRO NO SELECT SINISTRO-HISTORICO OPER=28' */
                _.Display($"ERRO NO SELECT SINISTRO-HISTORICO OPER=28");

                /*" -866- DISPLAY 'SINISTRO      : ' SINIPLAN-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO}");

                /*" -867- DISPLAY 'OCORHISTORICO : ' SINIPLAN-OCORHIST */
                _.Display($"OCORHISTORICO : {SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST}");

                /*" -868- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -868- END-IF. */
            }


        }

        [StopWatch]
        /*" R230-SELECT-NA-SINISHIS-OPER28-DB-SELECT-1 */
        public void R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1()
        {
            /*" -858- EXEC SQL SELECT VAL_OPERACAO INTO :HOST-VAL-PRM-REMANESC FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINIPLAN-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINIPLAN-OCORHIST AND COD_OPERACAO = 28 END-EXEC. */

            var r230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1 = new R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1()
            {
                SINIPLAN_NUM_APOL_SINISTRO = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.ToString(),
                SINIPLAN_OCORHIST = SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.ToString(),
            };

            var executed_1 = R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1.Execute(r230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_PRM_REMANESC, HOST_VAL_PRM_REMANESC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R230_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -878- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -879- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

                /*" -880- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND2.WSQLCODE1);

                /*" -881- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND2.WSQLCODE2);

                /*" -882- DISPLAY WABEND1. */
                _.Display(WABEND1);
            }


            /*" -884- DISPLAY WABEND2. */
            _.Display(WABEND2);

            /*" -885- CLOSE ARQCALC. */
            ARQCALC.Close();

            /*" -885- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -887- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -887- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -895- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

            /*" -898- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -901- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -904- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -907- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -910- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -913- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -916- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -919- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *");

            /*" -922- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -925- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -928- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *");

            /*" -931- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -934- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -937- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -940- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -946- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -948- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -950- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -952- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -954- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -956- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -958- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -960- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -962- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *");

            /*" -964- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -966- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -968- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *");

            /*" -970- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -972- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -974- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -976- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -978- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -978- GO TO 999-999-ROT-ERRO. */

            M_999_999_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}