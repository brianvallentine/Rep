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
using Sias.Sinistro.DB2.SI0891B;

namespace Code
{
    public class SI0891B
    {
        public bool IsCall { get; set; }

        public SI0891B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA   : SINISTRO                                        //      */
        /*"      * PROGRAMA  : SI0891B.                                        //      */
        /*"      * OBJETIVO  : GERACAO DE RELATORIO DE SINISTRO MANUSEADOS     //      */
        /*"      *             PELA FENAE                                              */
        /*"      *                                                             //      */
        /*"      * ANALISTA/PROGRAMADOR :    SANDRA                            //      */
        /*"      * DATA                 :    MAIO    / 2004                    //      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      * MANUTENCOES:                                                          */
        /*"      *                                                                       */
        /*"      * 07/04/2005 - PRODEXTER                                                */
        /*"      *  SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A             */
        /*"      *  SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO           */
        /*"      *                                                                       */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *                                                                *      */
        /*"      *  20/10/2010 - CADIMUS 47494/2010 - CIRCULAR 395:               *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *               MARCELO NEVES (TE41729)   PROCURAR: C395         *      */
        /*"      *                                                                *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *---------------------*                                                 */
        #endregion


        #region VARIABLES

        public FileBasis _FENAE01 { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis FENAE01
        {
            get
            {
                _.Move(REG_FENAE01, _FENAE01); VarBasis.RedefinePassValue(REG_FENAE01, _FENAE01, REG_FENAE01); return _FENAE01;
            }
        }
        /*"01  REG-FENAE01                 PIC X(600).*/
        public StringBasis REG_FENAE01 { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-VALOR-PAGO                  PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-VALOR-HABILIT               PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_HABILIT { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-SITUACAO                    PIC  X(10).*/
        public StringBasis HOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01 INICIO-WORK.*/
        public SI0891B_INICIO_WORK INICIO_WORK { get; set; } = new SI0891B_INICIO_WORK();
        public class SI0891B_INICIO_WORK : VarBasis
        {
            /*"    03 W-IND-FIM-CTRAB               PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_CTRAB { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-FIM-CMOTI               PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_CMOTI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-FIM-RELAT               PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_RELAT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CONTA-LIDOS                 PIC 9(05) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 W-CONTA-LIDOS1                PIC 9(05) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 W-CONTA-LIDOS2                PIC 9(05) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 W-FENAE-VLR-SALDO-DEV         PIC 9(11)V99 VALUE ZEROS.*/
            public DoubleBasis W_FENAE_VLR_SALDO_DEV { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V99"), 2);
            /*"    03 W-FENAE-VLR-PART-CEF          PIC 9(11)V99 VALUE ZEROS.*/
            public DoubleBasis W_FENAE_VLR_PART_CEF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V99"), 2);
            /*"    03 W-FENAE-PERC-PARTIC           PIC 9(03)V99 VALUE ZEROS.*/
            public DoubleBasis W_FENAE_PERC_PARTIC { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V99"), 2);
            /*"    03 W-FENAE-PLD-CORR-SEM-CEF      PIC 9(11)V99 VALUE ZEROS.*/
            public DoubleBasis W_FENAE_PLD_CORR_SEM_CEF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V99"), 2);
            /*"    03 W-FENAE-PLD-INICIAL-CORR      PIC 9(11)V9(04) VALUE ZEROS*/
            public DoubleBasis W_FENAE_PLD_INICIAL_CORR { get; set; } = new DoubleBasis(new PIC("9", "11", "9(11)V9(04)"), 4);
            /*"01  CAB-FENAE-0.*/
        }
        public SI0891B_CAB_FENAE_0 CAB_FENAE_0 { get; set; } = new SI0891B_CAB_FENAE_0();
        public class SI0891B_CAB_FENAE_0 : VarBasis
        {
            /*"    03 FILLER                  PIC X(25) VALUE    'CAIXA SEGUROS - SINISTRO'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"CAIXA SEGUROS - SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB-FENAE-1.*/
        }
        public SI0891B_CAB_FENAE_1 CAB_FENAE_1 { get; set; } = new SI0891B_CAB_FENAE_1();
        public class SI0891B_CAB_FENAE_1 : VarBasis
        {
            /*"    03 FILLER                  PIC X(32) VALUE    'SINISTROS MANUSEADOS PELA FENAE'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"SINISTROS MANUSEADOS PELA FENAE");
            /*"    03 FILLER                  PIC X(09) VALUE       ' NO DIA'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" NO DIA");
            /*"    03 CAB-DATA-FIN            PIC X(10).*/
            public StringBasis CAB_DATA_FIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB-FENAE-2.*/
        }
        public SI0891B_CAB_FENAE_2 CAB_FENAE_2 { get; set; } = new SI0891B_CAB_FENAE_2();
        public class SI0891B_CAB_FENAE_2 : VarBasis
        {
            /*"    03 FILLER                  PIC X(25) VALUE    'SEM MOVIMENTO PARA O DIA'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"SEM MOVIMENTO PARA O DIA");
            /*"    03 CAB-2-DATA              PIC X(10) VALUE SPACES.*/
            public StringBasis CAB_2_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"01  CAB-FENAE-3.*/
        }
        public SI0891B_CAB_FENAE_3 CAB_FENAE_3 { get; set; } = new SI0891B_CAB_FENAE_3();
        public class SI0891B_CAB_FENAE_3 : VarBasis
        {
            /*"    03 FILLER                  PIC X(04) VALUE                               'OPE'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"OPE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(05) VALUE                               'PROD'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"PROD");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(06) VALUE                               'AGENC'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"AGENC");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(09) VALUE                               'CONTRATO'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"CONTRATO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DATA MOVIMENTO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA MOVIMENTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'SITUACAO'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"SITUACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(09) VALUE                               'OPERACAO'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"OPERACAO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DESC ABREVIADA'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DESC ABREVIADA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(18) VALUE                               'VALOR HABILITADO'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"VALOR HABILITADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VALOR PAGO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR PAGO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'NUM SINISTRO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUM SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'COD USUARIO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"COD USUARIO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'NOME USUARIO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NOME USUARIO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'COD FONTE'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"COD FONTE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'NUM PROTOCOLO'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NUM PROTOCOLO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(09) VALUE                               'MOTIVO 1'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MOTIVO 1");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(09) VALUE                               'MOTIVO 2'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MOTIVO 2");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(09) VALUE                               'MOTIVO 3'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MOTIVO 3");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(09) VALUE                               'MOTIVO 4'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MOTIVO 4");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  REG-FENAERI01.*/
        }
        public SI0891B_REG_FENAERI01 REG_FENAERI01 { get; set; } = new SI0891B_REG_FENAERI01();
        public class SI0891B_REG_FENAERI01 : VarBasis
        {
            /*"    03 FENAE-OPERACAO           PIC 9(02) VALUE ZEROS.*/
            public IntBasis FENAE_OPERACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-PRODUTO            PIC 9(04) VALUE 0.*/
            public IntBasis FENAE_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-AGENCIA            PIC 9(04) VALUE 0.*/
            public IntBasis FENAE_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-CONTRATO           PIC 9(09) VALUE ZEROS.*/
            public IntBasis FENAE_CONTRATO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-DATA-MOVIMENTO     PIC X(10) VALUE SPACES.*/
            public StringBasis FENAE_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-SITUACAO           PIC X(10) VALUE SPACES.*/
            public StringBasis FENAE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-OPER               PIC 9(04) VALUE ZEROS.*/
            public IntBasis FENAE_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-ABREVIACAO         PIC X(20) VALUE SPACES.*/
            public StringBasis FENAE_ABREVIACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-VALOR-HABILIT      PIC -----99,99.*/
            public DoubleBasis FENAE_VALOR_HABILIT { get; set; } = new DoubleBasis(new PIC("9", "7", "-----99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-VALOR-PAGO         PIC -----99,99.*/
            public DoubleBasis FENAE_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "7", "-----99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-NUM-SINISTRO       PIC 9(13) VALUE ZEROS.*/
            public IntBasis FENAE_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-COD-USUARIO        PIC X(08).*/
            public StringBasis FENAE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-NOME-USUARIO       PIC X(40).*/
            public StringBasis FENAE_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-COD-FONTE          PIC 99.*/
            public IntBasis FENAE_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"    03 FILLER                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-NUM-PROTOCOLO      PIC 9(09).*/
            public IntBasis FENAE_NUM_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    03 FILLER                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-MOTIVO1            PIC X(40).*/
            public StringBasis FENAE_MOTIVO1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    03 FILLER                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-MOTIVO2            PIC X(40).*/
            public StringBasis FENAE_MOTIVO2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    03 FILLER                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-MOTIVO3            PIC X(40).*/
            public StringBasis FENAE_MOTIVO3 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    03 FILLER                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FENAE-MOTIVO4            PIC X(40).*/
            public StringBasis FENAE_MOTIVO4 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    03 FILLER                   PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01          WABEND1.*/
        }
        public SI0891B_WABEND1 WABEND1 { get; set; } = new SI0891B_WABEND1();
        public class SI0891B_WABEND1 : VarBasis
        {
            /*"    05      FILLER              PIC  X(10) VALUE           ' SI0873B'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0873B");
            /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(30) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01          WABEND2.*/
        }
        public SI0891B_WABEND2 WABEND2 { get; set; } = new SI0891B_WABEND2();
        public class SI0891B_WABEND2 : VarBasis
        {
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01  W-AUXILIARES.*/
        }
        public SI0891B_W_AUXILIARES W_AUXILIARES { get; set; } = new SI0891B_W_AUXILIARES();
        public class SI0891B_W_AUXILIARES : VarBasis
        {
            /*"    02 W-DATA-DB2.*/
            public SI0891B_W_DATA_DB2 W_DATA_DB2 { get; set; } = new SI0891B_W_DATA_DB2();
            public class SI0891B_W_DATA_DB2 : VarBasis
            {
                /*"       03 W-ANO-DB2             PIC 9(04).*/
                public IntBasis W_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-MES-DB2             PIC 9(02).*/
                public IntBasis W_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-DIA-DB2             PIC 9(02).*/
                public IntBasis W_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    02 W-DATA-PLAN.*/
            }
            public SI0891B_W_DATA_PLAN W_DATA_PLAN { get; set; } = new SI0891B_W_DATA_PLAN();
            public class SI0891B_W_DATA_PLAN : VarBasis
            {
                /*"       03 W-DIA-PLAN            PIC 9(02).*/
                public IntBasis W_DIA_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-MES-PLAN            PIC 9(02).*/
                public IntBasis W_MES_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-ANO-PLAN            PIC 9(04).*/
                public IntBasis W_ANO_PLAN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            }
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SITIPMOT SITIPMOT { get; set; } = new Dclgens.SITIPMOT();
        public SI0891B_CTRAB CTRAB { get; set; } = new SI0891B_CTRAB();
        public SI0891B_CMOTI CMOTI { get; set; } = new SI0891B_CMOTI();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string FENAE01_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                FENAE01.SetFile(FENAE01_FILE_NAME_P);

                /*" -305- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -306- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -307- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -310- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND1.WNR_EXEC_SQL);

                /*" -312- OPEN OUTPUT FENAE01. */
                FENAE01.Open(REG_FENAE01);

                /*" -313- PERFORM R010-LE-SISTEMA THRU R010-EXIT. */

                R010_LE_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -314- WRITE REG-FENAE01 FROM CAB-FENAE-0. */
                _.Move(CAB_FENAE_0.GetMoveValues(), REG_FENAE01);

                FENAE01.Write(REG_FENAE01.GetMoveValues().ToString());

                /*" -315- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-DB2. */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_AUXILIARES.W_DATA_DB2);

                /*" -316- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

                /*" -317- MOVE W-MES-DB2 TO W-MES-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

                /*" -318- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
                _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

                /*" -319- MOVE W-DATA-PLAN TO CAB-DATA-FIN. */
                _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_FENAE_1.CAB_DATA_FIN);

                /*" -320- WRITE REG-FENAE01 FROM CAB-FENAE-1. */
                _.Move(CAB_FENAE_1.GetMoveValues(), REG_FENAE01);

                FENAE01.Write(REG_FENAE01.GetMoveValues().ToString());

                /*" -321- WRITE REG-FENAE01 FROM CAB-FENAE-3. */
                _.Move(CAB_FENAE_3.GetMoveValues(), REG_FENAE01);

                FENAE01.Write(REG_FENAE01.GetMoveValues().ToString());

                /*" -322- MOVE 'NAO' TO W-IND-FIM-RELAT. */
                _.Move("NAO", INICIO_WORK.W_IND_FIM_RELAT);

                /*" -325- PERFORM R040-PROCESSA-RELAT THRU R040-EXIT. */

                R040_PROCESSA_RELAT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


                /*" -326- CLOSE FENAE01. */
                FENAE01.Close();

                /*" -327- MOVE '002' TO WNR-EXEC-SQL. */
                _.Move("002", WABEND1.WNR_EXEC_SQL);

                /*" -328- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -329- DISPLAY 'SI0891B         *** FIM NORMAL ***' . */
                _.Display($"SI0891B         *** FIM NORMAL ***");

                /*" -329- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R010-LE-SISTEMA */
        private void R010_LE_SISTEMA(bool isPerform = false)
        {
            /*" -336- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND1.WNR_EXEC_SQL);

            /*" -343- PERFORM R010_LE_SISTEMA_DB_SELECT_1 */

            R010_LE_SISTEMA_DB_SELECT_1();

            /*" -346- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -347- DISPLAY 'ERRO SELECT - SISTEMAS....................' */
                _.Display($"ERRO SELECT - SISTEMAS....................");

                /*" -349- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -350- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -351- DISPLAY '* PROGRAMA SI0891B                              *' */
            _.Display($"* PROGRAMA SI0891B                              *");

            /*" -352- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -353- DISPLAY ' ' . */
            _.Display($" ");

            /*" -354- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -359- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) '' SISTEMAS-DATA-MOV-ABERTO(8:1) '' SISTEMAS-DATA-MOV-ABERTO(6:2) '' SISTEMAS-DATA-MOV-ABERTO(5:1) '' SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -360- DISPLAY ' ' . */
            _.Display($" ");

            /*" -361- DISPLAY 'DATA DO ULTIMO PROCESSAMENTO(SI)' . */
            _.Display($"DATA DO ULTIMO PROCESSAMENTO(SI)");

            /*" -365- DISPLAY SISTEMAS-DATULT-PROCESSAMEN(9:2) '' SISTEMAS-DATULT-PROCESSAMEN(8:1) '' SISTEMAS-DATULT-PROCESSAMEN(6:2) '' SISTEMAS-DATULT-PROCESSAMEN(5:1) '' SISTEMAS-DATULT-PROCESSAMEN(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(1, 4)}"
            .Display();

        }

        [StopWatch]
        /*" R010-LE-SISTEMA-DB-SELECT-1 */
        public void R010_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -343- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_LE_SISTEMA_DB_SELECT_1_Query1 = new R010_LE_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMA_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R040-PROCESSA-RELAT */
        private void R040_PROCESSA_RELAT(bool isPerform = false)
        {
            /*" -373- MOVE 'NAO' TO W-IND-FIM-CTRAB. */
            _.Move("NAO", INICIO_WORK.W_IND_FIM_CTRAB);

            /*" -375- PERFORM R030-DECLARE-CTRAB THRU R030-EXIT. */

            R030_DECLARE_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


            /*" -377- PERFORM R031-FETCH-CTRAB THRU R031-EXIT. */

            R031_FETCH_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


            /*" -378- IF W-IND-FIM-CTRAB EQUAL 'SIM' */

            if (INICIO_WORK.W_IND_FIM_CTRAB == "SIM")
            {

                /*" -379- DISPLAY 'SI0891B  - NAO HA MOVIMENTACAO DE SINISTRO' */
                _.Display($"SI0891B  - NAO HA MOVIMENTACAO DE SINISTRO");

                /*" -381- DISPLAY 'PARA O PRODUTO  4801 MOVIMENTADO PELA FENAE' 'NO DIA ' SISTEMAS-DATA-MOV-ABERTO */

                $"PARA O PRODUTO  4801 MOVIMENTADO PELA FENAENO DIA {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -382- MOVE SISTEMAS-DATA-MOV-ABERTO TO CAB-2-DATA */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CAB_FENAE_2.CAB_2_DATA);

                /*" -384- WRITE REG-FENAE01 FROM CAB-FENAE-2. */
                _.Move(CAB_FENAE_2.GetMoveValues(), REG_FENAE01);

                FENAE01.Write(REG_FENAE01.GetMoveValues().ToString());
            }


            /*" -385- PERFORM R100-PROCESSA-CTRAB THRU R100-EXIT UNTIL W-IND-FIM-CTRAB EQUAL 'SIM' . */

            while (!(INICIO_WORK.W_IND_FIM_CTRAB == "SIM"))
            {

                R100_PROCESSA_CTRAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R030-DECLARE-CTRAB */
        private void R030_DECLARE_CTRAB(bool isPerform = false)
        {
            /*" -393- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND1.WNR_EXEC_SQL);

            /*" -483- PERFORM R030_DECLARE_CTRAB_DB_DECLARE_1 */

            R030_DECLARE_CTRAB_DB_DECLARE_1();

            /*" -486- DISPLAY 'ESTA FAZENDO O OPEN DO DECLARE PRINCIPAL' . */
            _.Display($"ESTA FAZENDO O OPEN DO DECLARE PRINCIPAL");

            /*" -488- DISPLAY 'QUANDO ACABAR, VAI INFORMAR QUE ACABOU O DECLARE' . */
            _.Display($"QUANDO ACABAR, VAI INFORMAR QUE ACABOU O DECLARE");

            /*" -490- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND1.WNR_EXEC_SQL);

            /*" -490- PERFORM R030_DECLARE_CTRAB_DB_OPEN_1 */

            R030_DECLARE_CTRAB_DB_OPEN_1();

            /*" -493- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -494- DISPLAY 'ERRO NA ABERTURA DO CURSOR PRINCIPAL ....' */
                _.Display($"ERRO NA ABERTURA DO CURSOR PRINCIPAL ....");

                /*" -496- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


            /*" -496- DISPLAY 'TERMINADO O DECLARE' . */
            _.Display($"TERMINADO O DECLARE");

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-DECLARE-1 */
        public void R030_DECLARE_CTRAB_DB_DECLARE_1()
        {
            /*" -483- EXEC SQL DECLARE CTRAB CURSOR FOR SELECT A.OPERACAO, H.COD_PRODUTO, A.PONTO_VENDA, A.NUM_CONTRATO, H.DATA_MOVIMENTO, CASE M.SIT_REGISTRO WHEN '0' THEN 'PENDENTE' WHEN '1' THEN 'C/ PAGTO' WHEN '2' THEN 'CANCELADO' END AS SITUACAO, H.COD_OPERACAO, O.DES_ABREVIADA, H1.VAL_OPERACAO, M.NUM_APOL_SINISTRO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, U.COD_USUARIO, U.NOME_USUARIO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO H1, SEGUROS.USUARIOS U, SEGUROS.SINISTRO_HABIT01 A, SEGUROS.GE_OPERACAO O, (SELECT DISTINCT H.NUM_APOL_SINISTRO FROM SEGUROS.USUARIOS U, SEGUROS.SINISTRO_HISTORICO H WHERE H.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND H.NUM_APOL_SINISTRO BETWEEN 0104800000000 AND 0104899999999 AND H.NUM_APOL_SINISTRO BETWEEN 0106000000000 AND 0106099999999 AND H.NUM_APOL_SINISTRO BETWEEN 0107000000000 AND 0107099999999 AND H.COD_PRODUTO = 4801 AND U.COD_USUARIO = H.COD_USUARIO AND U.DEPARTAMENTO LIKE 'FENAE%' ) W WHERE M.NUM_APOL_SINISTRO = W.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO BETWEEN 0104800000000 AND 0104899999999 AND H.NUM_APOL_SINISTRO BETWEEN 0106000000000 AND 0106099999999 AND H.NUM_APOL_SINISTRO BETWEEN 0107000000000 AND 0107099999999 AND A.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND U.COD_USUARIO = H.COD_USUARIO AND H.DATA_MOVIMENTO BETWEEN '2003-06-01' AND :SISTEMAS-DATA-MOV-ABERTO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO IN ( 'IN' , 'AV' ) AND H1.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H1.COD_OPERACAO = 101 GROUP BY A.OPERACAO, H.COD_PRODUTO, A.PONTO_VENDA, A.NUM_CONTRATO, H.DATA_MOVIMENTO, M.SIT_REGISTRO, H.COD_OPERACAO, O.DES_ABREVIADA, H1.VAL_OPERACAO, M.NUM_APOL_SINISTRO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, U.COD_USUARIO, U.NOME_USUARIO ORDER BY A.OPERACAO, H.COD_PRODUTO, A.PONTO_VENDA, A.NUM_CONTRATO, H.DATA_MOVIMENTO, M.SIT_REGISTRO, H.COD_OPERACAO, O.DES_ABREVIADA, H1.VAL_OPERACAO, M.NUM_APOL_SINISTRO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, U.COD_USUARIO, U.NOME_USUARIO END-EXEC. */
            CTRAB = new SI0891B_CTRAB(true);
            string GetQuery_CTRAB()
            {
                var query = @$"SELECT 
							A.OPERACAO
							, 
							H.COD_PRODUTO
							, 
							A.PONTO_VENDA
							, 
							A.NUM_CONTRATO
							, 
							H.DATA_MOVIMENTO
							, 
							CASE M.SIT_REGISTRO 
							WHEN '0' THEN 'PENDENTE' 
							WHEN '1' THEN 'C/ PAGTO' 
							WHEN '2' THEN 'CANCELADO' 
							END AS SITUACAO
							, 
							H.COD_OPERACAO
							, 
							O.DES_ABREVIADA
							, 
							H1.VAL_OPERACAO
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							U.COD_USUARIO
							, 
							U.NOME_USUARIO 
							FROM 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO H1
							, 
							SEGUROS.USUARIOS U
							, 
							SEGUROS.SINISTRO_HABIT01 A
							, 
							SEGUROS.GE_OPERACAO O
							, 
							(SELECT DISTINCT H.NUM_APOL_SINISTRO 
							FROM 
							SEGUROS.USUARIOS U
							, 
							SEGUROS.SINISTRO_HISTORICO H 
							WHERE 
							H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND H.NUM_APOL_SINISTRO BETWEEN 
							0104800000000 AND 0104899999999 
							AND H.NUM_APOL_SINISTRO BETWEEN 
							0106000000000 AND 0106099999999 
							AND H.NUM_APOL_SINISTRO BETWEEN 
							0107000000000 AND 0107099999999 
							AND H.COD_PRODUTO = 4801 
							AND U.COD_USUARIO = H.COD_USUARIO 
							AND U.DEPARTAMENTO LIKE 'FENAE%' ) W 
							WHERE 
							M.NUM_APOL_SINISTRO = W.NUM_APOL_SINISTRO 
							AND M.NUM_APOL_SINISTRO BETWEEN 
							0104800000000 AND 0104899999999 
							AND H.NUM_APOL_SINISTRO BETWEEN 
							0106000000000 AND 0106099999999 
							AND H.NUM_APOL_SINISTRO BETWEEN 
							0107000000000 AND 0107099999999 
							AND A.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND U.COD_USUARIO = H.COD_USUARIO 
							AND H.DATA_MOVIMENTO BETWEEN '2003-06-01' 
							AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO IN ( 'IN'
							, 'AV' ) 
							AND H1.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H1.COD_OPERACAO = 101 
							GROUP BY 
							A.OPERACAO
							, 
							H.COD_PRODUTO
							, 
							A.PONTO_VENDA
							, 
							A.NUM_CONTRATO
							, 
							H.DATA_MOVIMENTO
							, 
							M.SIT_REGISTRO
							, 
							H.COD_OPERACAO
							, 
							O.DES_ABREVIADA
							, 
							H1.VAL_OPERACAO
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							U.COD_USUARIO
							, 
							U.NOME_USUARIO 
							ORDER BY 
							A.OPERACAO
							, 
							H.COD_PRODUTO
							, 
							A.PONTO_VENDA
							, 
							A.NUM_CONTRATO
							, 
							H.DATA_MOVIMENTO
							, 
							M.SIT_REGISTRO
							, 
							H.COD_OPERACAO
							, 
							O.DES_ABREVIADA
							, 
							H1.VAL_OPERACAO
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							U.COD_USUARIO
							, 
							U.NOME_USUARIO";

                return query;
            }
            CTRAB.GetQueryEvent += GetQuery_CTRAB;

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-OPEN-1 */
        public void R030_DECLARE_CTRAB_DB_OPEN_1()
        {
            /*" -490- EXEC SQL OPEN CTRAB END-EXEC. */

            CTRAB.Open();

        }

        [StopWatch]
        /*" R110-PESQUISA-MOTIVO-DB-DECLARE-1 */
        public void R110_PESQUISA_MOTIVO_DB_DECLARE_1()
        {
            /*" -643- EXEC SQL DECLARE CMOTI CURSOR FOR SELECT DISTINCT D.DES_TIPO_MOTIVO FROM SEGUROS.SI_PROTOCOLO_ACOMP A, SEGUROS.SI_HIST_MOTIVO B, SEGUROS.SI_MOTIVO C, SEGUROS.SI_TIPO_MOTIVO D WHERE A.COD_FONTE = :SINISMES-COD-FONTE AND A.NUM_PROTOCOLO_SINI = :SINISMES-NUM-PROTOCOLO-SINI AND A.OCORR_HISTORICO = (SELECT MAX(X.OCORR_HISTORICO) FROM SEGUROS.SI_PROTOCOLO_ACOMP X WHERE X.COD_FONTE = :SINISMES-COD-FONTE AND X.NUM_PROTOCOLO_SINI = :SINISMES-NUM-PROTOCOLO-SINI AND X.NUM_CARTA IS NOT NULL AND X.COD_EVENTO = 1014) AND A.COD_FONTE = B.COD_FONTE AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND A.OCORR_HISTORICO = B.OCORR_HISTORICO AND B.NUM_MOTIVO = C.NUM_MOTIVO AND D.COD_TIPO_MOTIVO = C.COD_TIPO_MOTIVO END-EXEC. */
            CMOTI = new SI0891B_CMOTI(true);
            string GetQuery_CMOTI()
            {
                var query = @$"SELECT DISTINCT D.DES_TIPO_MOTIVO 
							FROM SEGUROS.SI_PROTOCOLO_ACOMP A
							, 
							SEGUROS.SI_HIST_MOTIVO B
							, 
							SEGUROS.SI_MOTIVO C
							, 
							SEGUROS.SI_TIPO_MOTIVO D 
							WHERE A.COD_FONTE = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}' 
							AND A.NUM_PROTOCOLO_SINI = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI}' 
							AND A.OCORR_HISTORICO = 
							(SELECT MAX(X.OCORR_HISTORICO) 
							FROM SEGUROS.SI_PROTOCOLO_ACOMP X 
							WHERE X.COD_FONTE = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}' 
							AND X.NUM_PROTOCOLO_SINI = 
							'{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI}' 
							AND X.NUM_CARTA IS NOT NULL 
							AND X.COD_EVENTO = 1014) 
							AND A.COD_FONTE = B.COD_FONTE 
							AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI 
							AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI 
							AND A.OCORR_HISTORICO = B.OCORR_HISTORICO 
							AND B.NUM_MOTIVO = C.NUM_MOTIVO 
							AND D.COD_TIPO_MOTIVO = C.COD_TIPO_MOTIVO";

                return query;
            }
            CMOTI.GetQueryEvent += GetQuery_CMOTI;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R031-FETCH-CTRAB */
        private void R031_FETCH_CTRAB(bool isPerform = false)
        {
            /*" -504- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND1.WNR_EXEC_SQL);

            /*" -519- PERFORM R031_FETCH_CTRAB_DB_FETCH_1 */

            R031_FETCH_CTRAB_DB_FETCH_1();

            /*" -522- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -523- ADD 1 TO W-CONTA-LIDOS */
                INICIO_WORK.W_CONTA_LIDOS.Value = INICIO_WORK.W_CONTA_LIDOS + 1;

                /*" -524- IF W-CONTA-LIDOS EQUAL 10000 */

                if (INICIO_WORK.W_CONTA_LIDOS == 10000)
                {

                    /*" -525- ADD W-CONTA-LIDOS TO W-CONTA-LIDOS1 */
                    INICIO_WORK.W_CONTA_LIDOS1.Value = INICIO_WORK.W_CONTA_LIDOS1 + INICIO_WORK.W_CONTA_LIDOS;

                    /*" -526- DISPLAY 'LIDOS ATE AGORA = ' W-CONTA-LIDOS1 */
                    _.Display($"LIDOS ATE AGORA = {INICIO_WORK.W_CONTA_LIDOS1}");

                    /*" -528- MOVE 0 TO W-CONTA-LIDOS. */
                    _.Move(0, INICIO_WORK.W_CONTA_LIDOS);
                }

            }


            /*" -529- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -530- DISPLAY 'ERRO FETCH DO CURSOR PRINCIPAL ........' */
                _.Display($"ERRO FETCH DO CURSOR PRINCIPAL ........");

                /*" -531- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -532- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -533- DISPLAY 'RAMO     : ' SINISMES-RAMO */
                _.Display($"RAMO     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -534- DISPLAY 'PRODUTO  : ' SINISMES-COD-PRODUTO */
                _.Display($"PRODUTO  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -535- DISPLAY 'COD CAUSA: ' SINISMES-COD-CAUSA */
                _.Display($"COD CAUSA: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -536- DISPLAY 'COD FONTE: ' SINISMES-COD-FONTE */
                _.Display($"COD FONTE: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -538- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -539- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -539- PERFORM R031_FETCH_CTRAB_DB_CLOSE_1 */

                R031_FETCH_CTRAB_DB_CLOSE_1();

                /*" -540- MOVE 'SIM' TO W-IND-FIM-CTRAB. */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_CTRAB);
            }


        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-FETCH-1 */
        public void R031_FETCH_CTRAB_DB_FETCH_1()
        {
            /*" -519- EXEC SQL FETCH CTRAB INTO :SINIHAB1-OPERACAO, :SINISHIS-COD-PRODUTO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO, :SINISHIS-DATA-MOVIMENTO, :HOST-SITUACAO, :SINISHIS-COD-OPERACAO, :GEOPERAC-DES-ABREVIADA, :HOST-VALOR-HABILIT, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI, :USUARIOS-COD-USUARIO, :USUARIOS-NOME-USUARIO END-EXEC. */

            if (CTRAB.Fetch())
            {
                _.Move(CTRAB.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(CTRAB.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(CTRAB.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(CTRAB.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
                _.Move(CTRAB.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(CTRAB.HOST_SITUACAO, HOST_SITUACAO);
                _.Move(CTRAB.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(CTRAB.GEOPERAC_DES_ABREVIADA, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_ABREVIADA);
                _.Move(CTRAB.HOST_VALOR_HABILIT, HOST_VALOR_HABILIT);
                _.Move(CTRAB.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(CTRAB.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(CTRAB.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(CTRAB.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
                _.Move(CTRAB.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }

        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-CLOSE-1 */
        public void R031_FETCH_CTRAB_DB_CLOSE_1()
        {
            /*" -539- EXEC SQL CLOSE CTRAB END-EXEC */

            CTRAB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-CTRAB */
        private void R100_PROCESSA_CTRAB(bool isPerform = false)
        {
            /*" -550- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -551- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -552- MOVE '2003-06-01' TO SI1001S-DATA-INICIO */
            _.Move("2003-06-01", LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO);

            /*" -554- MOVE SISTEMAS-DATA-MOV-ABERTO TO SI1001S-DATA-FIM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -556- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -557- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -558- DISPLAY 'PROBLEMA CALL SI1002S ' */
                _.Display($"PROBLEMA CALL SI1002S ");

                /*" -559- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -560- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -561- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -562- DISPLAY ' ' SI1001S-DATA-INICIO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_INICIO}");

                /*" -563- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -565- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -567- MOVE SI1001S-VALOR-CALCULADO TO HOST-VALOR-PAGO. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VALOR_PAGO);

            /*" -569- INITIALIZE REG-FENAE01 REG-FENAERI01. */
            _.Initialize(
                REG_FENAE01
                , REG_FENAERI01
            );

            /*" -570- MOVE SINIHAB1-OPERACAO TO FENAE-OPERACAO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, REG_FENAERI01.FENAE_OPERACAO);

            /*" -571- MOVE SINISHIS-COD-PRODUTO TO FENAE-PRODUTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, REG_FENAERI01.FENAE_PRODUTO);

            /*" -572- MOVE SINIHAB1-PONTO-VENDA TO FENAE-AGENCIA. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, REG_FENAERI01.FENAE_AGENCIA);

            /*" -573- MOVE SINIHAB1-NUM-CONTRATO TO FENAE-CONTRATO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, REG_FENAERI01.FENAE_CONTRATO);

            /*" -574- MOVE SINISHIS-DATA-MOVIMENTO TO FENAE-DATA-MOVIMENTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, REG_FENAERI01.FENAE_DATA_MOVIMENTO);

            /*" -575- MOVE HOST-SITUACAO TO FENAE-SITUACAO. */
            _.Move(HOST_SITUACAO, REG_FENAERI01.FENAE_SITUACAO);

            /*" -576- MOVE SINISHIS-COD-OPERACAO TO FENAE-OPER. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, REG_FENAERI01.FENAE_OPER);

            /*" -577- MOVE GEOPERAC-DES-ABREVIADA TO FENAE-ABREVIACAO. */
            _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_ABREVIADA, REG_FENAERI01.FENAE_ABREVIACAO);

            /*" -578- MOVE HOST-VALOR-HABILIT TO FENAE-VALOR-HABILIT. */
            _.Move(HOST_VALOR_HABILIT, REG_FENAERI01.FENAE_VALOR_HABILIT);

            /*" -579- MOVE HOST-VALOR-PAGO TO FENAE-VALOR-PAGO. */
            _.Move(HOST_VALOR_PAGO, REG_FENAERI01.FENAE_VALOR_PAGO);

            /*" -580- MOVE SINISMES-NUM-APOL-SINISTRO TO FENAE-NUM-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REG_FENAERI01.FENAE_NUM_SINISTRO);

            /*" -581- MOVE USUARIOS-COD-USUARIO TO FENAE-COD-USUARIO. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO, REG_FENAERI01.FENAE_COD_USUARIO);

            /*" -582- MOVE USUARIOS-NOME-USUARIO TO FENAE-NOME-USUARIO. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, REG_FENAERI01.FENAE_NOME_USUARIO);

            /*" -583- MOVE SINISMES-COD-FONTE TO FENAE-COD-FONTE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, REG_FENAERI01.FENAE_COD_FONTE);

            /*" -585- MOVE SINISMES-NUM-PROTOCOLO-SINI TO FENAE-NUM-PROTOCOLO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, REG_FENAERI01.FENAE_NUM_PROTOCOLO);

            /*" -586- MOVE 'NAO' TO W-IND-FIM-CMOTI. */
            _.Move("NAO", INICIO_WORK.W_IND_FIM_CMOTI);

            /*" -587- MOVE 0 TO W-CONTA-LIDOS2. */
            _.Move(0, INICIO_WORK.W_CONTA_LIDOS2);

            /*" -589- PERFORM R110-PESQUISA-MOTIVO THRU R110-EXIT. */

            R110_PESQUISA_MOTIVO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -591- PERFORM R041-FETCH-CMOTI THRU R041-EXIT. */

            R041_FETCH_CMOTI(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R041_EXIT*/


            /*" -592- IF W-IND-FIM-CMOTI EQUAL 'NAO' */

            if (INICIO_WORK.W_IND_FIM_CMOTI == "NAO")
            {

                /*" -594- PERFORM UNTIL W-CONTA-LIDOS2 > 4 OR W-IND-FIM-CMOTI = 'SIM' */

                while (!(INICIO_WORK.W_CONTA_LIDOS2 > 4 || INICIO_WORK.W_IND_FIM_CMOTI == "SIM"))
                {

                    /*" -595- EVALUATE W-CONTA-LIDOS2 */
                    switch (INICIO_WORK.W_CONTA_LIDOS2.Value)
                    {

                        /*" -596- WHEN 1 */
                        case 1:

                            /*" -597- MOVE SITIPMOT-DES-TIPO-MOTIVO TO FENAE-MOTIVO1 */
                            _.Move(SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO, REG_FENAERI01.FENAE_MOTIVO1);

                            /*" -598- WHEN 2 */
                            break;
                        case 2:

                            /*" -599- MOVE SITIPMOT-DES-TIPO-MOTIVO TO FENAE-MOTIVO2 */
                            _.Move(SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO, REG_FENAERI01.FENAE_MOTIVO2);

                            /*" -600- WHEN 3 */
                            break;
                        case 3:

                            /*" -601- MOVE SITIPMOT-DES-TIPO-MOTIVO TO FENAE-MOTIVO3 */
                            _.Move(SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO, REG_FENAERI01.FENAE_MOTIVO3);

                            /*" -602- WHEN 4 */
                            break;
                        case 4:

                            /*" -603- MOVE SITIPMOT-DES-TIPO-MOTIVO TO FENAE-MOTIVO4 */
                            _.Move(SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO, REG_FENAERI01.FENAE_MOTIVO4);

                            /*" -605- END-EVALUATE */
                            break;
                    }


                    /*" -607- PERFORM R041-FETCH-CMOTI THRU R041-EXIT */

                    R041_FETCH_CMOTI(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R041_EXIT*/


                    /*" -609- END-PERFORM */
                }

                /*" -611- END-IF. */
            }


            /*" -613- WRITE REG-FENAE01 FROM REG-FENAERI01. */
            _.Move(REG_FENAERI01.GetMoveValues(), REG_FENAE01);

            FENAE01.Write(REG_FENAE01.GetMoveValues().ToString());

            /*" -613- PERFORM R031-FETCH-CTRAB THRU R031-EXIT. */

            R031_FETCH_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-PESQUISA-MOTIVO */
        private void R110_PESQUISA_MOTIVO(bool isPerform = false)
        {
            /*" -621- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND1.WNR_EXEC_SQL);

            /*" -643- PERFORM R110_PESQUISA_MOTIVO_DB_DECLARE_1 */

            R110_PESQUISA_MOTIVO_DB_DECLARE_1();

            /*" -645- PERFORM R110_PESQUISA_MOTIVO_DB_OPEN_1 */

            R110_PESQUISA_MOTIVO_DB_OPEN_1();

            /*" -648- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -649- DISPLAY 'ERRO NA ABERTURA DO CURSOR PRINCIPAL ....' */
                _.Display($"ERRO NA ABERTURA DO CURSOR PRINCIPAL ....");

                /*" -649- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R110-PESQUISA-MOTIVO-DB-OPEN-1 */
        public void R110_PESQUISA_MOTIVO_DB_OPEN_1()
        {
            /*" -645- EXEC SQL OPEN CMOTI END-EXEC. */

            CMOTI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R041-FETCH-CMOTI */
        private void R041_FETCH_CMOTI(bool isPerform = false)
        {
            /*" -657- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND1.WNR_EXEC_SQL);

            /*" -659- PERFORM R041_FETCH_CMOTI_DB_FETCH_1 */

            R041_FETCH_CMOTI_DB_FETCH_1();

            /*" -662- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -663- DISPLAY 'ERRO FETCH DO CURSOR CMOTI ........' */
                _.Display($"ERRO FETCH DO CURSOR CMOTI ........");

                /*" -664- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -665- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -666- DISPLAY 'RAMO     : ' SINISMES-RAMO */
                _.Display($"RAMO     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -667- DISPLAY 'PRODUTO  : ' SINISMES-COD-PRODUTO */
                _.Display($"PRODUTO  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -668- DISPLAY 'COD CAUSA: ' SINISMES-COD-CAUSA */
                _.Display($"COD CAUSA: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -669- DISPLAY 'COD FONTE: ' SINISMES-COD-FONTE */
                _.Display($"COD FONTE: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -671- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -672- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -672- PERFORM R041_FETCH_CMOTI_DB_CLOSE_1 */

                R041_FETCH_CMOTI_DB_CLOSE_1();

                /*" -674- MOVE 'SIM' TO W-IND-FIM-CMOTI */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_CMOTI);

                /*" -675- ELSE */
            }
            else
            {


                /*" -676- ADD 1 TO W-CONTA-LIDOS2 */
                INICIO_WORK.W_CONTA_LIDOS2.Value = INICIO_WORK.W_CONTA_LIDOS2 + 1;

                /*" -677- IF W-CONTA-LIDOS2 > 4 */

                if (INICIO_WORK.W_CONTA_LIDOS2 > 4)
                {

                    /*" -677- PERFORM R041_FETCH_CMOTI_DB_CLOSE_2 */

                    R041_FETCH_CMOTI_DB_CLOSE_2();

                    /*" -678- MOVE 'SIM' TO W-IND-FIM-CMOTI. */
                    _.Move("SIM", INICIO_WORK.W_IND_FIM_CMOTI);
                }

            }


        }

        [StopWatch]
        /*" R041-FETCH-CMOTI-DB-FETCH-1 */
        public void R041_FETCH_CMOTI_DB_FETCH_1()
        {
            /*" -659- EXEC SQL FETCH CMOTI INTO :SITIPMOT-DES-TIPO-MOTIVO END-EXEC. */

            if (CMOTI.Fetch())
            {
                _.Move(CMOTI.SITIPMOT_DES_TIPO_MOTIVO, SITIPMOT.DCLSI_TIPO_MOTIVO.SITIPMOT_DES_TIPO_MOTIVO);
            }

        }

        [StopWatch]
        /*" R041-FETCH-CMOTI-DB-CLOSE-1 */
        public void R041_FETCH_CMOTI_DB_CLOSE_1()
        {
            /*" -672- EXEC SQL CLOSE CMOTI END-EXEC */

            CMOTI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R041_EXIT*/

        [StopWatch]
        /*" R041-FETCH-CMOTI-DB-CLOSE-2 */
        public void R041_FETCH_CMOTI_DB_CLOSE_2()
        {
            /*" -677- EXEC SQL CLOSE CMOTI END-EXEC */

            CMOTI.Close();

        }

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -688- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -689- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

                /*" -690- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND2.WSQLCODE1);

                /*" -691- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND2.WSQLCODE2);

                /*" -692- DISPLAY WABEND1. */
                _.Display(WABEND1);
            }


            /*" -694- DISPLAY WABEND2. */
            _.Display(WABEND2);

            /*" -695- CLOSE FENAE01. */
            FENAE01.Close();

            /*" -695- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -697- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -697- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -705- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

            /*" -708- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -711- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -714- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -717- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -720- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -723- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -726- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -729- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O FENAEISTA  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O FENAEISTA  *WITHNOADVANCING"
            .Display();

            /*" -732- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -735- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -738- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O FENAEISTA RESPONSAVEL *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O FENAEISTA RESPONSAVEL *WITHNOADVANCING"
            .Display();

            /*" -741- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -744- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -747- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -750- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -756- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -758- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -760- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -762- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -764- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -766- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -768- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -770- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -772- DISPLAY '*       VERIFIQUE O LOG ANTES DE LIGAR PARA O FENAEISTA   *' */
            _.Display($"*       VERIFIQUE O LOG ANTES DE LIGAR PARA O FENAEISTA   *");

            /*" -774- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -776- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -778- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O FENAEISTA RESPONSAVEL *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O FENAEISTA RESPONSAVEL *");

            /*" -780- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -782- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -784- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -786- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -788- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -788- GO TO 999-999-ROT-ERRO. */

            M_999_999_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}