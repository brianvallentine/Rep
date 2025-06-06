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
using Sias.Sinistro.DB2.SI0890B;

namespace Code
{
    public class SI0890B
    {
        public bool IsCall { get; set; }

        public SI0890B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      * SISTEMA.....: SINISTRO                                         *      */
        /*"      * PROGRAMA....: SI0890B.                                         *      */
        /*"      * REF.........: MAI/2004                                         *      */
        /*"      * ANALISTA....: SANDRA                                           *      */
        /*"      * PROGRAMADOR.: SANDRA                                           *      */
        /*"      * VERSAO .....: 16012009 17:00HS                                 *      */
        /*"      * OBJETIVO....: GERACAO DE RELATORIO DE SINISTRO DE LOTERICOS    *      */
        /*"      *               O QUAL E SOLICITADO ATRAVES DO SIAS              *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 06 - CAD 176076 E 176034                              *      */
        /*"      *   EM 27/08/2019 -  MICHAEL NOGUEIRA                            *      */
        /*"      *   INCLUS�O DE DISPLAY CASO OCORRE ERRO DE NAO ENCONTRAR        *      */
        /*"      *   NA TABELA LOTERICO01 DA ROTINA R111020-LE-LOTERICO01         *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 95.992                                       *      */
        /*"      *   EM 20/04/2014 -  DAIRO LOPES    TRATAR CCA                   *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 10.003                                       *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      * MANUTENCOES:                                                          */
        /*"      *                                                                       */
        /*"      * 06/04/2005 - PRODEXTER                                                */
        /*"      * SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A              */
        /*"      * SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO            */
        /*"      *                                                                       */
        /*"      * 30/06/2005 - ALEXIS VEAS ITURRIAGA                                    */
        /*"      * INCLUSAO DO SALDO DA IS NO ARQUIVO DE SAIDA.                          */
        /*"      *                                                                       */
        /*"      * 23/09/2005 - ALEXIS VEAS ITURRIAGA                                    */
        /*"      * SIMPLIFICACAO DO JOIN PARA PODER SEMPRE BUSCAR AS INFORMACOES         */
        /*"      * NAS TABELAS DA EMISSAO.                                               */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *---------------------*                                                 */
        #endregion


        #region VARIABLES

        public FileBasis _LOTER01 { get; set; } = new FileBasis(new PIC("X", "615", "X(615)"));

        public FileBasis LOTER01
        {
            get
            {
                _.Move(REG_LOTER01, _LOTER01); VarBasis.RedefinePassValue(REG_LOTER01, _LOTER01, REG_LOTER01); return _LOTER01;
            }
        }
        /*"01  REG-LOTER01                 PIC X(615).*/
        public StringBasis REG_LOTER01 { get; set; } = new StringBasis(new PIC("X", "615", "X(615)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-VALOR-PAGO                  PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-VALOR-PENDENTE              PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-VALOR-ADIANTAMENTO          PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-VALOR-AVISO                 PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_AVISO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-VALOR-FRANQUIA              PIC S9(11)V9(02) COMP-3.*/
        public DoubleBasis HOST_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V9(02)"), 2);
        /*"77  HOST-DATA-AVISO                  PIC X(10).*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-ADIANTAMENTO           PIC X(10).*/
        public StringBasis HOST_DATA_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01 INICIO-WORK.*/
        public SI0890B_INICIO_WORK INICIO_WORK { get; set; } = new SI0890B_INICIO_WORK();
        public class SI0890B_INICIO_WORK : VarBasis
        {
            /*"    03 WS-VERSAO                     PIC X(50) VALUE          'PROG.SI0890B VERSAO: 24112009 10:26HS'.*/
            public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"PROG.SI0890B VERSAO: 24112009 10:26HS");
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
            /*"    03 CT-LIDOS-RELAT           PIC S9(05)    VALUE ZEROS COMP-3*/
            public IntBasis CT_LIDOS_RELAT { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
            /*"    03 CT-CR-LOTER              PIC S9(05)    VALUE ZEROS COMP-3*/
            public IntBasis CT_CR_LOTER { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
            /*"    03 CT-GRAVADOS              PIC S9(05)    VALUE ZEROS COMP-3*/
            public IntBasis CT_GRAVADOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
            /*"    03 QBAT-CR-LOTER            PIC X(05)     VALUE LOW-VALUE.*/
            public StringBasis QBAT_CR_LOTER { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"    03 QBAT-CR-RELAT            PIC X(05)     VALUE LOW-VALUE.*/
            public StringBasis QBAT_CR_RELAT { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"01  CAB-CALC-0.*/
        }
        public SI0890B_CAB_CALC_0 CAB_CALC_0 { get; set; } = new SI0890B_CAB_CALC_0();
        public class SI0890B_CAB_CALC_0 : VarBasis
        {
            /*"    03 FILLER                  PIC X(25) VALUE    'CAIXA SEGUROS - SINISTRO'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"CAIXA SEGUROS - SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  CAB-CALC-1.*/
        }
        public SI0890B_CAB_CALC_1 CAB_CALC_1 { get; set; } = new SI0890B_CAB_CALC_1();
        public class SI0890B_CAB_CALC_1 : VarBasis
        {
            /*"    03 FILLER                  PIC X(21) VALUE    'SINISTROS DE LOTERICO'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"SINISTROS DE LOTERICO");
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
        public SI0890B_CAB_CALC_2 CAB_CALC_2 { get; set; } = new SI0890B_CAB_CALC_2();
        public class SI0890B_CAB_CALC_2 : VarBasis
        {
            /*"    03 FILLER                  PIC X(03) VALUE                               'UF'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"UF");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(07) VALUE                               'CIDADE'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"CIDADE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(12) VALUE                               'CODIGO CAIXA'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"CODIGO CAIXA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(06) VALUE                               'CLASSE'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CLASSE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               '    C N P J    '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"    C N P J    ");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(11) VALUE                               '   S.R.    '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"   S.R.    ");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(12) VALUE                               'NUM APOLICE'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM APOLICE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(12) VALUE                               'NUM SINISTRO'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(12) VALUE                               'CAUSA'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"CAUSA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(08) VALUE                               'SEGURADO'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DT AVISO'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DT AVISO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DT ADIANTAMENTO'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DT ADIANTAMENTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'DT OCORRENCIA  '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DT OCORRENCIA  ");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(14) VALUE                               'VALOR IS OCORR'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VALOR IS OCORR");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VALOR AVISADO'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR AVISADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VALOR ADIANTADO'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR ADIANTADO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VALOR PAGO'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR PAGO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VALOR PENDENTE'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR PENDENTE");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE                               'VALOR FRANQUIA'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"VALOR FRANQUIA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE       'SALDO DA I.S.'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"SALDO DA I.S.");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(15) VALUE       'COD.COBERTURA'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"COD.COBERTURA");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 FILLER                  PIC X(11) VALUE       'COD.PRODUTO'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD.PRODUTO");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01  REG-LOTERI01.*/
        }
        public SI0890B_REG_LOTERI01 REG_LOTERI01 { get; set; } = new SI0890B_REG_LOTERI01();
        public class SI0890B_REG_LOTERI01 : VarBasis
        {
            /*"    03 LOTE-UF                 PIC X(02) VALUE SPACES.*/
            public StringBasis LOTE_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-CIDADE             PIC X(20) VALUE SPACES.*/
            public StringBasis LOTE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-COD-LOT-CEF        PIC 9(09) VALUE ZEROS.*/
            public IntBasis LOTE_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-CLASSE             PIC X(01) VALUE SPACES.*/
            public StringBasis LOTE_CLASSE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-CNPJ               PIC 9(15) VALUE ZEROS.*/
            public IntBasis LOTE_CNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-ESCNEG             PIC ---9  VALUE ZEROS.*/
            public IntBasis LOTE_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "---9"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-NUM-APOLICE        PIC 9(13) VALUE 0.*/
            public IntBasis LOTE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-NUM-SINISTRO       PIC 9(13) VALUE 0.*/
            public IntBasis LOTE_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-CAUSA              PIC X(40) VALUE SPACES.*/
            public StringBasis LOTE_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-SEGURADO           PIC X(40) VALUE SPACES.*/
            public StringBasis LOTE_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-DATA-AVISO         PIC X(10) VALUE SPACES.*/
            public StringBasis LOTE_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-DATA-ADIANTAMENTO  PIC X(10) VALUE SPACES.*/
            public StringBasis LOTE_DATA_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-DATA-OCORR         PIC X(10) VALUE SPACES.*/
            public StringBasis LOTE_DATA_OCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-VALOR-IS           PIC -----99,99.*/
            public DoubleBasis LOTE_VALOR_IS { get; set; } = new DoubleBasis(new PIC("9", "7", "-----99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-VALOR-AVISADO      PIC -----99,99.*/
            public DoubleBasis LOTE_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "7", "-----99V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-VALOR-ADIANTAMENTO PIC ------------9,99.*/
            public DoubleBasis LOTE_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-VALOR-PAGO         PIC ------------9,99.*/
            public DoubleBasis LOTE_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-VALOR-PENDENTE     PIC ------------9,99.*/
            public DoubleBasis LOTE_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-VALOR-FRANQUIA     PIC ------------9,99.*/
            public DoubleBasis LOTE_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-SALDO-IS           PIC ------------9,99.*/
            public DoubleBasis LOTE_SALDO_IS { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-COD-COBERTURA      PIC 9999.*/
            public IntBasis LOTE_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 LOTE-COD-PRODUTO        PIC 9(09) VALUE ZEROS.*/
            public IntBasis LOTE_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01          WABEND1.*/
        }
        public SI0890B_WABEND1 WABEND1 { get; set; } = new SI0890B_WABEND1();
        public class SI0890B_WABEND1 : VarBasis
        {
            /*"    05      FILLER              PIC  X(10) VALUE           ' SI0890B'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0890B");
            /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(30) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01          WABEND2.*/
        }
        public SI0890B_WABEND2 WABEND2 { get; set; } = new SI0890B_WABEND2();
        public class SI0890B_WABEND2 : VarBasis
        {
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01  W-AUXILIARES.*/
        }
        public SI0890B_W_AUXILIARES W_AUXILIARES { get; set; } = new SI0890B_W_AUXILIARES();
        public class SI0890B_W_AUXILIARES : VarBasis
        {
            /*"    02 W-DATA-DB2.*/
            public SI0890B_W_DATA_DB2 W_DATA_DB2 { get; set; } = new SI0890B_W_DATA_DB2();
            public class SI0890B_W_DATA_DB2 : VarBasis
            {
                /*"       03 W-ANO-DB2             PIC 9(04).*/
                public IntBasis W_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-MES-DB2             PIC 9(02).*/
                public IntBasis W_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01).*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       03 W-DIA-DB2             PIC 9(02).*/
                public IntBasis W_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    02 W-DATA-PLAN.*/
            }
            public SI0890B_W_DATA_PLAN W_DATA_PLAN { get; set; } = new SI0890B_W_DATA_PLAN();
            public class SI0890B_W_DATA_PLAN : VarBasis
            {
                /*"       03 W-DIA-PLAN            PIC 9(02).*/
                public IntBasis W_DIA_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-MES-PLAN            PIC 9(02).*/
                public IntBasis W_MES_PLAN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       03 FILLER                PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       03 W-ANO-PLAN            PIC 9(04).*/
                public IntBasis W_ANO_PLAN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"01 LK2-LINK.*/
            }
        }
        public SI0890B_LK2_LINK LK2_LINK { get; set; } = new SI0890B_LK2_LINK();
        public class SI0890B_LK2_LINK : VarBasis
        {
            /*"   05 LK2-RTCODE                   PIC S9(04) COMP VALUE +0.*/
            public IntBasis LK2_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 LK2-LOTERI01-NUM-APOLICE     PIC  9(13).*/
            public IntBasis LK2_LOTERI01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 LK2-AV-COD-NATUREZA          PIC  9(02).*/
            public IntBasis LK2_AV_COD_NATUREZA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 LK2-LOTERI01-COD-LOT-CEF     PIC  9(13).*/
            public IntBasis LK2_LOTERI01_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 LK2-LOTERI01-COD-LOT-FENAL   PIC  9(13).*/
            public IntBasis LK2_LOTERI01_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 LK2-IMP-SEGURADA-IX          PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis LK2_IMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"   05 LK2-DATA-INIVIGENCIA         PIC  X(10).*/
            public StringBasis LK2_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 LK2-DATA-TERVIGENCIA         PIC  X(10).*/
            public StringBasis LK2_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 LK2-W-HOST-VALOR-SALDO-IS    PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis LK2_W_HOST_VALOR_SALDO_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"   05 LK2-W-HOST-VAL-AVISOS        PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis LK2_W_HOST_VAL_AVISOS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"   05 LK2-W-HOST-INDENIZ-EFETIV    PIC S9(13)V99 COMP-3 VALUE +0*/
            public DoubleBasis LK2_W_HOST_INDENIZ_EFETIV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.OUTROCOB OUTROCOB { get; set; } = new Dclgens.OUTROCOB();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();

        public SI0890B_CR_LOTER CR_LOTER { get; set; } = new SI0890B_CR_LOTER(true);
        string GetQuery_CR_LOTER()
        {
            var query = @$"SELECT H.NUM_APOLICE
							, H.NUM_APOL_SINISTRO
							, C.DESCR_CAUSA
							, H.NOME_FAVORECIDO
							, H.DATA_MOVIMENTO
							, M.DATA_OCORRENCIA
							, M.COD_PRODUTO
							, H.VAL_OPERACAO
							, L.COD_CLIENTE
							, L.COD_LOT_CEF
							, L.COD_COBERTURA
							, C.COD_CAUSA
							FROM SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.SINISTRO_MESTRE M
							, SEGUROS.SINI_LOTERICO01 L
							, SEGUROS.SINISTRO_CAUSA C WHERE M.COD_PRODUTO IN (1803
							, 1805) AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND L.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND C.RAMO_EMISSOR = M.RAMO AND C.COD_CAUSA = M.COD_CAUSA AND H.COD_OPERACAO = 101 AND M.DATA_OCORRENCIA BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' AND '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' ORDER BY H.NUM_APOLICE
							, H.NUM_APOL_SINISTRO
							, C.DESCR_CAUSA
							, H.NOME_FAVORECIDO
							, H.DATA_MOVIMENTO
							, M.DATA_OCORRENCIA
							, H.VAL_OPERACAO
							, L.COD_LOT_CEF
							, L.COD_COBERTURA";

            return query;
        }


        public SI0890B_CR_RELAT CR_RELAT { get; set; } = new SI0890B_CR_RELAT(false);
        string GetQuery_CR_RELAT()
        {
            var query = @$"SELECT PERI_INICIAL
							, PERI_FINAL
							, COD_PRODUTOR
							FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0890B' AND SIT_REGISTRO = '0' AND IDE_SISTEMA = 'SI'";

            return query;
        }


        public SI0890B_CR_ADIANT CR_ADIANT { get; set; } = new SI0890B_CR_ADIANT(true);
        string GetQuery_CR_ADIANT()
        {
            var query = @$"SELECT H.DATA_MOVIMENTO
							, SUM(I.VAL_OPERACAO * P.NUM_FATOR)
							FROM SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.SINISTRO_HISTORICO I
							, SEGUROS.GE_SIS_FUNCAO_OPER P WHERE H.NUM_APOL_SINISTRO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}' AND H.COD_OPERACAO = 1070 AND H.NUM_APOL_SINISTRO = I.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = I.OCORR_HISTORICO AND P.IDE_SISTEMA = 'SI' AND P.COD_OPERACAO = I.COD_OPERACAO AND P.COD_FUNCAO = 2 AND P.IDE_SISTEMA_OPER = P.IDE_SISTEMA AND P.TIPO_ENDOSSO = '9' GROUP BY H.DATA_MOVIMENTO ORDER BY H.DATA_MOVIMENTO";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string LOTER01_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                LOTER01.SetFile(LOTER01_FILE_NAME_P);
                InitializeGetQuery();

                /*" -442- DISPLAY 'SI0890B - INICIO DE PROCESSAMENTO' */
                _.Display($"SI0890B - INICIO DE PROCESSAMENTO");

                /*" -444- DISPLAY WS-VERSAO. */
                _.Display(INICIO_WORK.WS_VERSAO);

                /*" -444- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -445- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -446- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -450- OPEN OUTPUT LOTER01. */
                LOTER01.Open(REG_LOTER01);

                /*" -452- PERFORM R10-PROCESSA-RELATORIO THRU R10-FIM. */

                R10_PROCESSA_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/


                /*" -453- IF CT-LIDOS-RELAT EQUAL ZEROS */

                if (INICIO_WORK.CT_LIDOS_RELAT == 00)
                {

                    /*" -454- DISPLAY '*********************************************' */
                    _.Display($"*********************************************");

                    /*" -455- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -456- DISPLAY '*               SI0890B                     *' */
                    _.Display($"*               SI0890B                     *");

                    /*" -457- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -458- DISPLAY '*       SEM MOVIMENTO PARA O DIA            *' */
                    _.Display($"*       SEM MOVIMENTO PARA O DIA            *");

                    /*" -459- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -460- DISPLAY '* NAO FOI ENCONTRADA A SOLICITACAO NA       *' */
                    _.Display($"* NAO FOI ENCONTRADA A SOLICITACAO NA       *");

                    /*" -461- DISPLAY '* RELATORIOS                                *' */
                    _.Display($"* RELATORIOS                                *");

                    /*" -462- DISPLAY '*                                           *' */
                    _.Display($"*                                           *");

                    /*" -463- DISPLAY '*********************************************' */
                    _.Display($"*********************************************");

                    /*" -464- ELSE */
                }
                else
                {


                    /*" -465- PERFORM R20-UPDATE-RELATORIO THRU R20-FIM */

                    R20_UPDATE_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/


                    /*" -467- END-IF. */
                }


                /*" -469- CLOSE LOTER01. */
                LOTER01.Close();

                /*" -470- DISPLAY 'PERIODO INICIAL = ' RELATORI-PERI-INICIAL. */
                _.Display($"PERIODO INICIAL = {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}");

                /*" -471- DISPLAY 'PERIODO FINAL   = ' RELATORI-PERI-FINAL. */
                _.Display($"PERIODO FINAL   = {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                /*" -473- DISPLAY '*** SI0890B - FIM NORMAL DE SERVICO ***' . */
                _.Display($"*** SI0890B - FIM NORMAL DE SERVICO ***");

                /*" -473- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CR_LOTER.GetQueryEvent += GetQuery_CR_LOTER;
            CR_RELAT.GetQueryEvent += GetQuery_CR_RELAT;
            CR_ADIANT.GetQueryEvent += GetQuery_CR_ADIANT;
        }

        [StopWatch]
        /*" R10-PROCESSA-RELATORIO */
        private void R10_PROCESSA_RELATORIO(bool isPerform = false)
        {
            /*" -483- PERFORM R100-OPEN-CR-RELAT THRU R100-FIM. */

            R100_OPEN_CR_RELAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_FIM*/


            /*" -486- PERFORM R110-LE-RELATORIO THRU R110-FIM UNTIL QBAT-CR-RELAT EQUAL HIGH-VALUE. */

            while (!(INICIO_WORK.QBAT_CR_RELAT.IsHighValues))
            {

                R110_LE_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_FIM*/

            }

            /*" -486- PERFORM R120-CLOSE-CR-RELAT THRU R120-FIM. */

            R120_CLOSE_CR_RELAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/

        [StopWatch]
        /*" R100-OPEN-CR-RELAT */
        private void R100_OPEN_CR_RELAT(bool isPerform = false)
        {
            /*" -499- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND1.WNR_EXEC_SQL);

            /*" -501- PERFORM R100_OPEN_CR_RELAT_DB_OPEN_1 */

            R100_OPEN_CR_RELAT_DB_OPEN_1();

            /*" -504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -505- DISPLAY '*** SI0890B - ERRO OPEN CURSOR CR_RELAT ***' */
                _.Display($"*** SI0890B - ERRO OPEN CURSOR CR_RELAT ***");

                /*" -506- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -506- END-IF. */
            }


        }

        [StopWatch]
        /*" R100-OPEN-CR-RELAT-DB-OPEN-1 */
        public void R100_OPEN_CR_RELAT_DB_OPEN_1()
        {
            /*" -501- EXEC SQL OPEN CR_RELAT END-EXEC. */

            CR_RELAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_FIM*/

        [StopWatch]
        /*" R110-LE-RELATORIO */
        private void R110_LE_RELATORIO(bool isPerform = false)
        {
            /*" -519- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND1.WNR_EXEC_SQL);

            /*" -524- PERFORM R110_LE_RELATORIO_DB_FETCH_1 */

            R110_LE_RELATORIO_DB_FETCH_1();

            /*" -527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -528- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -529- DISPLAY '*** SI0890B - ERRO NO FETCH RELATORIOS ***' */
                    _.Display($"*** SI0890B - ERRO NO FETCH RELATORIOS ***");

                    /*" -530- GO TO M-999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -531- END-IF */
                }


                /*" -533- END-IF. */
            }


            /*" -534- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -535- MOVE HIGH-VALUE TO QBAT-CR-RELAT */

                INICIO_WORK.QBAT_CR_RELAT.IsHighValues = true;

                /*" -536- GO TO R110-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_FIM*/ //GOTO
                return;

                /*" -538- END-IF. */
            }


            /*" -540- ADD 1 TO CT-LIDOS-RELAT. */
            INICIO_WORK.CT_LIDOS_RELAT.Value = INICIO_WORK.CT_LIDOS_RELAT + 1;

            /*" -542- WRITE REG-LOTER01 FROM CAB-CALC-0. */
            _.Move(CAB_CALC_0.GetMoveValues(), REG_LOTER01);

            LOTER01.Write(REG_LOTER01.GetMoveValues().ToString());

            /*" -543- MOVE RELATORI-PERI-INICIAL TO W-DATA-DB2. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, W_AUXILIARES.W_DATA_DB2);

            /*" -544- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
            _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

            /*" -545- MOVE W-MES-DB2 TO W-MES-PLAN. */
            _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

            /*" -546- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
            _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

            /*" -547- MOVE W-DATA-PLAN TO CAB-DATA-INI. */
            _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_CALC_1.CAB_DATA_INI);

            /*" -548- MOVE RELATORI-PERI-FINAL TO W-DATA-DB2. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, W_AUXILIARES.W_DATA_DB2);

            /*" -549- MOVE W-DIA-DB2 TO W-DIA-PLAN. */
            _.Move(W_AUXILIARES.W_DATA_DB2.W_DIA_DB2, W_AUXILIARES.W_DATA_PLAN.W_DIA_PLAN);

            /*" -550- MOVE W-MES-DB2 TO W-MES-PLAN. */
            _.Move(W_AUXILIARES.W_DATA_DB2.W_MES_DB2, W_AUXILIARES.W_DATA_PLAN.W_MES_PLAN);

            /*" -551- MOVE W-ANO-DB2 TO W-ANO-PLAN. */
            _.Move(W_AUXILIARES.W_DATA_DB2.W_ANO_DB2, W_AUXILIARES.W_DATA_PLAN.W_ANO_PLAN);

            /*" -553- MOVE W-DATA-PLAN TO CAB-DATA-FIN. */
            _.Move(W_AUXILIARES.W_DATA_PLAN, CAB_CALC_1.CAB_DATA_FIN);

            /*" -554- WRITE REG-LOTER01 FROM CAB-CALC-1. */
            _.Move(CAB_CALC_1.GetMoveValues(), REG_LOTER01);

            LOTER01.Write(REG_LOTER01.GetMoveValues().ToString());

            /*" -556- WRITE REG-LOTER01 FROM CAB-CALC-2. */
            _.Move(CAB_CALC_2.GetMoveValues(), REG_LOTER01);

            LOTER01.Write(REG_LOTER01.GetMoveValues().ToString());

            /*" -558- MOVE LOW-VALUE TO QBAT-CR-LOTER. */
            _.Move("", INICIO_WORK.QBAT_CR_LOTER);

            /*" -560- PERFORM R1100-OPEN-CR-LOTER THRU R1100-FIM. */

            R1100_OPEN_CR_LOTER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_FIM*/


            /*" -563- PERFORM R1110-LE-CR-LOTER THRU R1110-FIM UNTIL QBAT-CR-LOTER EQUAL HIGH-VALUE. */

            while (!(INICIO_WORK.QBAT_CR_LOTER.IsHighValues))
            {

                R1110_LE_CR_LOTER(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_FIM*/

            }

            /*" -563- PERFORM R1120-CLOSE-CR-LOTER THRU R1120-FIM. */

            R1120_CLOSE_CR_LOTER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_FIM*/


        }

        [StopWatch]
        /*" R110-LE-RELATORIO-DB-FETCH-1 */
        public void R110_LE_RELATORIO_DB_FETCH_1()
        {
            /*" -524- EXEC SQL FETCH CR_RELAT INTO :RELATORI-PERI-INICIAL, :RELATORI-PERI-FINAL, :RELATORI-COD-PRODUTOR END-EXEC. */

            if (CR_RELAT.Fetch())
            {
                _.Move(CR_RELAT.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(CR_RELAT.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(CR_RELAT.RELATORI_COD_PRODUTOR, RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_FIM*/

        [StopWatch]
        /*" R1100-OPEN-CR-LOTER */
        private void R1100_OPEN_CR_LOTER(bool isPerform = false)
        {
            /*" -576- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND1.WNR_EXEC_SQL);

            /*" -578- PERFORM R1100_OPEN_CR_LOTER_DB_OPEN_1 */

            R1100_OPEN_CR_LOTER_DB_OPEN_1();

            /*" -581- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -582- DISPLAY '*** SI0890B - ERRO OPEN CURSOR CR_LOTER ***' */
                _.Display($"*** SI0890B - ERRO OPEN CURSOR CR_LOTER ***");

                /*" -583- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -583- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-OPEN-CR-LOTER-DB-OPEN-1 */
        public void R1100_OPEN_CR_LOTER_DB_OPEN_1()
        {
            /*" -578- EXEC SQL OPEN CR_LOTER END-EXEC. */

            CR_LOTER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_FIM*/

        [StopWatch]
        /*" R1110-LE-CR-LOTER */
        private void R1110_LE_CR_LOTER(bool isPerform = false)
        {
            /*" -596- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND1.WNR_EXEC_SQL);

            /*" -611- PERFORM R1110_LE_CR_LOTER_DB_FETCH_1 */

            R1110_LE_CR_LOTER_DB_FETCH_1();

            /*" -614- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -615- MOVE HIGH-VALUE TO QBAT-CR-LOTER */

                INICIO_WORK.QBAT_CR_LOTER.IsHighValues = true;

                /*" -616- GO TO R1110-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_FIM*/ //GOTO
                return;

                /*" -618- END-IF. */
            }


            /*" -619- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -620- DISPLAY '*** SI0890B - ERRO FETCH DO CURSOR CR_LOTER ***' */
                _.Display($"*** SI0890B - ERRO FETCH DO CURSOR CR_LOTER ***");

                /*" -621- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -622- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -623- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -625- END-IF. */
            }


            /*" -627- ADD 1 TO CT-CR-LOTER. */
            INICIO_WORK.CT_CR_LOTER.Value = INICIO_WORK.CT_CR_LOTER + 1;

            /*" -628- PERFORM R0130-LER-CLIENTES THRU R0130-LER-CLIENTES. */

            R0130_LER_CLIENTES(true);

            /*" -628- PERFORM R11100-GRAVA-LOTER01 THRU R11100-FIM. */

            R11100_GRAVA_LOTER01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R11100_FIM*/


        }

        [StopWatch]
        /*" R1110-LE-CR-LOTER-DB-FETCH-1 */
        public void R1110_LE_CR_LOTER_DB_FETCH_1()
        {
            /*" -611- EXEC SQL FETCH CR_LOTER INTO :SINISHIS-NUM-APOLICE , :SINISHIS-NUM-APOL-SINISTRO, :SINISCAU-DESCR-CAUSA , :SINISHIS-NOME-FAVORECIDO , :HOST-DATA-AVISO , :SINISMES-DATA-OCORRENCIA , :SINISMES-COD-PRODUTO , :HOST-VALOR-AVISO , :SINILT01-COD-CLIENTE , :SINILT01-COD-LOT-CEF , :SINILT01-COD-COBERTURA , :SINISCAU-COD-CAUSA END-EXEC. */

            if (CR_LOTER.Fetch())
            {
                _.Move(CR_LOTER.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(CR_LOTER.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(CR_LOTER.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(CR_LOTER.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(CR_LOTER.HOST_DATA_AVISO, HOST_DATA_AVISO);
                _.Move(CR_LOTER.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CR_LOTER.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(CR_LOTER.HOST_VALOR_AVISO, HOST_VALOR_AVISO);
                _.Move(CR_LOTER.SINILT01_COD_CLIENTE, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE);
                _.Move(CR_LOTER.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
                _.Move(CR_LOTER.SINILT01_COD_COBERTURA, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA);
                _.Move(CR_LOTER.SINISCAU_COD_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_FIM*/

        [StopWatch]
        /*" R0130-LER-CLIENTES */
        private void R0130_LER_CLIENTES(bool isPerform = false)
        {
            /*" -638- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", WABEND1.WNR_EXEC_SQL);

            /*" -645- PERFORM R0130_LER_CLIENTES_DB_SELECT_1 */

            R0130_LER_CLIENTES_DB_SELECT_1();

            /*" -648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -649- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -650- MOVE 0 TO CLIENTES-CGCCPF */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

                /*" -653- DISPLAY ' CLIENTE INEXISTE ' SINILT01-COD-CLIENTE ' SQLCODE   ' SQLCODE */

                $" CLIENTE INEXISTE {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE} SQLCODE   {DB.SQLCODE}"
                .Display();

                /*" -653- END-IF. */
            }


        }

        [StopWatch]
        /*" R0130-LER-CLIENTES-DB-SELECT-1 */
        public void R0130_LER_CLIENTES_DB_SELECT_1()
        {
            /*" -645- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SINILT01-COD-CLIENTE END-EXEC. */

            var r0130_LER_CLIENTES_DB_SELECT_1_Query1 = new R0130_LER_CLIENTES_DB_SELECT_1_Query1()
            {
                SINILT01_COD_CLIENTE = SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0130_LER_CLIENTES_DB_SELECT_1_Query1.Execute(r0130_LER_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_SAIDA*/

        [StopWatch]
        /*" R0140-LER-DESC-CAUSAS */
        private void R0140_LER_DESC_CAUSAS(bool isPerform = false)
        {
            /*" -662- MOVE '0140' TO WNR-EXEC-SQL. */
            _.Move("0140", WABEND1.WNR_EXEC_SQL);

            /*" -668- PERFORM R0140_LER_DESC_CAUSAS_DB_SELECT_1 */

            R0140_LER_DESC_CAUSAS_DB_SELECT_1();

            /*" -671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -672- MOVE SPACES TO SINISCAU-DESCR-CAUSA */
                _.Move("", SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);

                /*" -673- DISPLAY 'R0140- CAUSA NAO ENCONTRADA ' SINISCAU-COD-CAUSA */
                _.Display($"R0140- CAUSA NAO ENCONTRADA {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA}");

                /*" -674- DISPLAY ' SQLCODE =' SQLCODE */
                _.Display($" SQLCODE ={DB.SQLCODE}");

                /*" -674- END-IF. */
            }


        }

        [StopWatch]
        /*" R0140-LER-DESC-CAUSAS-DB-SELECT-1 */
        public void R0140_LER_DESC_CAUSAS_DB_SELECT_1()
        {
            /*" -668- EXEC SQL SELECT DESCR_CAUSA INTO :SINISCAU-DESCR-CAUSA FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = 18 AND COD_CAUSA = :SINISCAU-COD-CAUSA END-EXEC. */

            var r0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1 = new R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1()
            {
                SINISCAU_COD_CAUSA = SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA.ToString(),
            };

            var executed_1 = R0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1.Execute(r0140_LER_DESC_CAUSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_SAIDA*/

        [StopWatch]
        /*" R11100-GRAVA-LOTER01 */
        private void R11100_GRAVA_LOTER01(bool isPerform = false)
        {
            /*" -686- INITIALIZE REG-LOTERI01. */
            _.Initialize(
                REG_LOTERI01
            );

            /*" -688- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -690- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -692- CALL 'SI1002S' USING SI1001S-PARAMETROS. */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -693- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -694- DISPLAY '*** SI0890B - PROBLEMA CALL SI1002S ***' */
                _.Display($"*** SI0890B - PROBLEMA CALL SI1002S ***");

                /*" -695- DISPLAY 'SQLCODE  = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -696- DISPLAY 'MENSAGEM = ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -697- DISPLAY 'SINISTRO = ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO = {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -698- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -700- END-IF. */
            }


            /*" -702- MOVE SI1001S-VALOR-CALCULADO TO HOST-VALOR-PAGO. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VALOR_PAGO);

            /*" -704- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -706- MOVE SINISHIS-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -708- CALL 'SI1001S' USING SI1001S-PARAMETROS. */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -709- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -710- DISPLAY '*** SI0890B - PROBLEMA CALL SI1001S ***' */
                _.Display($"*** SI0890B - PROBLEMA CALL SI1001S ***");

                /*" -711- DISPLAY 'SQLCODE  = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -712- DISPLAY 'MENSAGEM = ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -713- DISPLAY 'SINISTRO = ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO = {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -714- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -716- END-IF. */
            }


            /*" -718- MOVE SI1001S-VALOR-CALCULADO TO HOST-VALOR-PENDENTE. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_VALOR_PENDENTE);

            /*" -719- IF HOST-VALOR-PENDENTE GREATER ZEROS */

            if (HOST_VALOR_PENDENTE > 00)
            {

                /*" -720- PERFORM R111000-PESQUISA-ADIANTAMENTO THRU R111000-FIM */

                R111000_PESQUISA_ADIANTAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R111000_FIM*/


                /*" -721- MOVE HOST-VALOR-ADIANTAMENTO TO LOTE-VALOR-ADIANTAMENTO */
                _.Move(HOST_VALOR_ADIANTAMENTO, REG_LOTERI01.LOTE_VALOR_ADIANTAMENTO);

                /*" -722- MOVE HOST-DATA-ADIANTAMENTO TO LOTE-DATA-ADIANTAMENTO */
                _.Move(HOST_DATA_ADIANTAMENTO, REG_LOTERI01.LOTE_DATA_ADIANTAMENTO);

                /*" -724- COMPUTE HOST-VALOR-PAGO = HOST-VALOR-PAGO - HOST-VALOR-ADIANTAMENTO */
                HOST_VALOR_PAGO.Value = HOST_VALOR_PAGO - HOST_VALOR_ADIANTAMENTO;

                /*" -726- END-IF. */
            }


            /*" -728- PERFORM R111010-PESQUISA-FRANQUIA THRU R111010-FIM. */

            R111010_PESQUISA_FRANQUIA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111010_FIM*/


            /*" -730- MOVE HOST-VALOR-FRANQUIA TO LOTE-VALOR-FRANQUIA. */
            _.Move(HOST_VALOR_FRANQUIA, REG_LOTERI01.LOTE_VALOR_FRANQUIA);

            /*" -732- PERFORM R111020-LE-LOTERICO01 THRU R111020-FIM. */

            R111020_LE_LOTERICO01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111020_FIM*/


            /*" -734- PERFORM R111030-LE-APOLICES THRU R111030-FIM. */

            R111030_LE_APOLICES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111030_FIM*/


            /*" -736- PERFORM R111040-LE-OUTROS-COB THRU R111040-FIM. */

            R111040_LE_OUTROS_COB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111040_FIM*/


            /*" -738- PERFORM R111050-LE-AGENCIAS THRU R111050-FIM. */

            R111050_LE_AGENCIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R111050_FIM*/


            /*" -739- IF SINILT01-COD-COBERTURA EQUAL 2 OR 7 OR 8 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA.In("2", "7", "8"))
            {

                /*" -740- PERFORM R111060-SALDO-IS THRU R111060-FIM */

                R111060_SALDO_IS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R111060_FIM*/


                /*" -741- ELSE */
            }
            else
            {


                /*" -742- MOVE ZEROS TO LK2-W-HOST-VALOR-SALDO-IS */
                _.Move(0, LK2_LINK.LK2_W_HOST_VALOR_SALDO_IS);

                /*" -747- END-IF. */
            }


            /*" -749- IF SINILT01-COD-COBERTURA EQUAL 7 AND SINISCAU-COD-CAUSA EQUAL 10 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA == 7 && SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA == 10)
            {

                /*" -750- MOVE 31 TO SINISCAU-COD-CAUSA */
                _.Move(31, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);

                /*" -751- PERFORM R0140-LER-DESC-CAUSAS */

                R0140_LER_DESC_CAUSAS(true);

                /*" -752- ELSE */
            }
            else
            {


                /*" -754- IF SINILT01-COD-COBERTURA EQUAL 8 AND SINISCAU-COD-CAUSA EQUAL 10 */

                if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA == 8 && SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA == 10)
                {

                    /*" -755- MOVE 14 TO SINISCAU-COD-CAUSA */
                    _.Move(14, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);

                    /*" -756- PERFORM R0140-LER-DESC-CAUSAS */

                    R0140_LER_DESC_CAUSAS(true);

                    /*" -757- END-IF */
                }


                /*" -759- END-IF. */
            }


            /*" -760- MOVE LK2-W-HOST-VALOR-SALDO-IS TO LOTE-SALDO-IS. */
            _.Move(LK2_LINK.LK2_W_HOST_VALOR_SALDO_IS, REG_LOTERI01.LOTE_SALDO_IS);

            /*" -761- MOVE LOTERI01-SIGLA-UF TO LOTE-UF. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF, REG_LOTERI01.LOTE_UF);

            /*" -762- MOVE LOTERI01-CIDADE TO LOTE-CIDADE. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE, REG_LOTERI01.LOTE_CIDADE);

            /*" -763- MOVE SINILT01-COD-LOT-CEF TO LOTE-COD-LOT-CEF. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, REG_LOTERI01.LOTE_COD_LOT_CEF);

            /*" -764- MOVE LOTERI01-COD-CLASSE-ADESAO TO LOTE-CLASSE. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO, REG_LOTERI01.LOTE_CLASSE);

            /*" -765- MOVE AGENCCEF-COD-ESCNEG TO LOTE-ESCNEG. */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, REG_LOTERI01.LOTE_ESCNEG);

            /*" -766- MOVE SINISHIS-NUM-APOLICE TO LOTE-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, REG_LOTERI01.LOTE_NUM_APOLICE);

            /*" -767- MOVE SINISHIS-NUM-APOL-SINISTRO TO LOTE-NUM-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, REG_LOTERI01.LOTE_NUM_SINISTRO);

            /*" -768- MOVE SINISCAU-DESCR-CAUSA TO LOTE-CAUSA. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, REG_LOTERI01.LOTE_CAUSA);

            /*" -769- MOVE SINISHIS-NOME-FAVORECIDO TO LOTE-SEGURADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, REG_LOTERI01.LOTE_SEGURADO);

            /*" -770- MOVE HOST-DATA-AVISO TO LOTE-DATA-AVISO. */
            _.Move(HOST_DATA_AVISO, REG_LOTERI01.LOTE_DATA_AVISO);

            /*" -771- MOVE SINISMES-DATA-OCORRENCIA TO LOTE-DATA-OCORR. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, REG_LOTERI01.LOTE_DATA_OCORR);

            /*" -772- MOVE OUTROCOB-IMP-SEGURADA-IX TO LOTE-VALOR-IS. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_LOTERI01.LOTE_VALOR_IS);

            /*" -773- MOVE HOST-VALOR-PAGO TO LOTE-VALOR-PAGO. */
            _.Move(HOST_VALOR_PAGO, REG_LOTERI01.LOTE_VALOR_PAGO);

            /*" -774- MOVE HOST-VALOR-AVISO TO LOTE-VALOR-AVISADO. */
            _.Move(HOST_VALOR_AVISO, REG_LOTERI01.LOTE_VALOR_AVISADO);

            /*" -775- MOVE HOST-VALOR-PENDENTE TO LOTE-VALOR-PENDENTE. */
            _.Move(HOST_VALOR_PENDENTE, REG_LOTERI01.LOTE_VALOR_PENDENTE);

            /*" -776- MOVE SINILT01-COD-COBERTURA TO LOTE-COD-COBERTURA. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA, REG_LOTERI01.LOTE_COD_COBERTURA);

            /*" -778- MOVE SINISMES-COD-PRODUTO TO LOTE-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, REG_LOTERI01.LOTE_COD_PRODUTO);

            /*" -778- WRITE REG-LOTER01 FROM REG-LOTERI01. */
            _.Move(REG_LOTERI01.GetMoveValues(), REG_LOTER01);

            LOTER01.Write(REG_LOTER01.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R11100_FIM*/

        [StopWatch]
        /*" R111000-PESQUISA-ADIANTAMENTO */
        private void R111000_PESQUISA_ADIANTAMENTO(bool isPerform = false)
        {
            /*" -791- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND1.WNR_EXEC_SQL);

            /*" -793- PERFORM R111000_PESQUISA_ADIANTAMENTO_DB_OPEN_1 */

            R111000_PESQUISA_ADIANTAMENTO_DB_OPEN_1();

            /*" -796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -797- DISPLAY '*** SI0890B - ERRO NO OPEN CURSOR CR_ADIANT ***' */
                _.Display($"*** SI0890B - ERRO NO OPEN CURSOR CR_ADIANT ***");

                /*" -798- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -800- END-IF. */
            }


            /*" -804- PERFORM R111000_PESQUISA_ADIANTAMENTO_DB_FETCH_1 */

            R111000_PESQUISA_ADIANTAMENTO_DB_FETCH_1();

            /*" -807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -809- MOVE ZEROS TO HOST-VALOR-ADIANTAMENTO */
                    _.Move(0, HOST_VALOR_ADIANTAMENTO);

                    /*" -810- MOVE SPACES TO HOST-DATA-ADIANTAMENTO */
                    _.Move("", HOST_DATA_ADIANTAMENTO);

                    /*" -811- ELSE */
                }
                else
                {


                    /*" -812- DISPLAY '*** SI0890B - ERRO NO FETCH CR_ADIANT ***' */
                    _.Display($"*** SI0890B - ERRO NO FETCH CR_ADIANT ***");

                    /*" -813- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -814- GO TO R10010199-MENSAGEM-LOCK */

                    R10010199_MENSAGEM_LOCK(); //GOTO
                    return;

                    /*" -815- END-IF */
                }


                /*" -817- END-IF. */
            }


            /*" -819- PERFORM R111000_PESQUISA_ADIANTAMENTO_DB_CLOSE_1 */

            R111000_PESQUISA_ADIANTAMENTO_DB_CLOSE_1();

            /*" -822- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -823- DISPLAY '*** SI0890B - ERRO CLOSE CURSOR CR_ADIANT ***' */
                _.Display($"*** SI0890B - ERRO CLOSE CURSOR CR_ADIANT ***");

                /*" -824- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -824- END-IF. */
            }


        }

        [StopWatch]
        /*" R111000-PESQUISA-ADIANTAMENTO-DB-OPEN-1 */
        public void R111000_PESQUISA_ADIANTAMENTO_DB_OPEN_1()
        {
            /*" -793- EXEC SQL OPEN CR_ADIANT END-EXEC. */

            CR_ADIANT.Open();

        }

        [StopWatch]
        /*" R111000-PESQUISA-ADIANTAMENTO-DB-FETCH-1 */
        public void R111000_PESQUISA_ADIANTAMENTO_DB_FETCH_1()
        {
            /*" -804- EXEC SQL FETCH CR_ADIANT INTO :HOST-DATA-ADIANTAMENTO, :HOST-VALOR-ADIANTAMENTO END-EXEC. */

            if (CR_ADIANT.Fetch())
            {
                _.Move(CR_ADIANT.HOST_DATA_ADIANTAMENTO, HOST_DATA_ADIANTAMENTO);
                _.Move(CR_ADIANT.HOST_VALOR_ADIANTAMENTO, HOST_VALOR_ADIANTAMENTO);
            }

        }

        [StopWatch]
        /*" R111000-PESQUISA-ADIANTAMENTO-DB-CLOSE-1 */
        public void R111000_PESQUISA_ADIANTAMENTO_DB_CLOSE_1()
        {
            /*" -819- EXEC SQL CLOSE CR_ADIANT END-EXEC. */

            CR_ADIANT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111000_FIM*/

        [StopWatch]
        /*" R111010-PESQUISA-FRANQUIA */
        private void R111010_PESQUISA_FRANQUIA(bool isPerform = false)
        {
            /*" -837- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND1.WNR_EXEC_SQL);

            /*" -843- PERFORM R111010_PESQUISA_FRANQUIA_DB_SELECT_1 */

            R111010_PESQUISA_FRANQUIA_DB_SELECT_1();

            /*" -846- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -847- DISPLAY 'SI0890B - ERRO SELECT SUM FRANQUIA' */
                _.Display($"SI0890B - ERRO SELECT SUM FRANQUIA");

                /*" -848- DISPLAY 'NUMERO SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUMERO SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -849- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -849- END-IF. */
            }


        }

        [StopWatch]
        /*" R111010-PESQUISA-FRANQUIA-DB-SELECT-1 */
        public void R111010_PESQUISA_FRANQUIA_DB_SELECT_1()
        {
            /*" -843- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :HOST-VALOR-FRANQUIA FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 21 END-EXEC. */

            var r111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1 = new R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1.Execute(r111010_PESQUISA_FRANQUIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_FRANQUIA, HOST_VALOR_FRANQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111010_FIM*/

        [StopWatch]
        /*" R111020-LE-LOTERICO01 */
        private void R111020_LE_LOTERICO01(bool isPerform = false)
        {
            /*" -861- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND1.WNR_EXEC_SQL);

            /*" -862- MOVE SINISHIS-NUM-APOLICE TO LOTERI01-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE);

            /*" -864- MOVE SINILT01-COD-LOT-CEF TO LOTERI01-COD-LOT-FENAL. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL);

            /*" -887- PERFORM R111020_LE_LOTERICO01_DB_SELECT_1 */

            R111020_LE_LOTERICO01_DB_SELECT_1();

            /*" -890- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -891- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -892- DISPLAY 'OUTROCOB-NUM-APOLICE =' OUTROCOB-NUM-APOLICE */
                    _.Display($"OUTROCOB-NUM-APOLICE ={OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_NUM_APOLICE}");

                    /*" -893- DISPLAY 'OUTROCOB-RAMO-COBER =' OUTROCOB-RAMO-COBERTURA */
                    _.Display($"OUTROCOB-RAMO-COBER ={OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_RAMO_COBERTURA}");

                    /*" -894- DISPLAY 'OUTROCOB-MOD-COBER=' OUTROCOB-MODALI-COBERTURA */
                    _.Display($"OUTROCOB-MOD-COBER={OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_MODALI_COBERTURA}");

                    /*" -895- DISPLAY 'OUTROCOB-COD-COBER =' OUTROCOB-COD-COBERTURA */
                    _.Display($"OUTROCOB-COD-COBER ={OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA}");

                    /*" -897- DISPLAY 'SINISMES-DATA-OCOR =' SINISMES-DATA-OCORRENCIA */
                    _.Display($"SINISMES-DATA-OCOR ={SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA}");

                    /*" -898- MOVE SPACES TO LOTERI01-SIGLA-UF */
                    _.Move("", LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF);

                    /*" -899- MOVE SPACES TO LOTERI01-CIDADE */
                    _.Move("", LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE);

                    /*" -900- MOVE SPACES TO LOTERI01-COD-CLASSE-ADESAO */
                    _.Move("", LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO);

                    /*" -901- MOVE ZEROS TO LOTERI01-AGENCIA */
                    _.Move(0, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA);

                    /*" -902- ELSE */
                }
                else
                {


                    /*" -903- DISPLAY '*** SI0890B - ERRO SELECT LOTERICO01 ***' */
                    _.Display($"*** SI0890B - ERRO SELECT LOTERICO01 ***");

                    /*" -904- DISPLAY 'NUMERO SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUMERO SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -905- GO TO R10010199-MENSAGEM-LOCK */

                    R10010199_MENSAGEM_LOCK(); //GOTO
                    return;

                    /*" -906- END-IF */
                }


                /*" -906- END-IF. */
            }


        }

        [StopWatch]
        /*" R111020-LE-LOTERICO01-DB-SELECT-1 */
        public void R111020_LE_LOTERICO01_DB_SELECT_1()
        {
            /*" -887- EXEC SQL SELECT SIGLA_UF, CIDADE, COD_CLASSE_ADESAO, AGENCIA INTO :LOTERI01-SIGLA-UF, :LOTERI01-CIDADE, :LOTERI01-COD-CLASSE-ADESAO, :LOTERI01-AGENCIA FROM SEGUROS.LOTERICO01 WHERE COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND NUM_APOLICE = :LOTERI01-NUM-APOLICE AND DTINIVIG <= :SINISMES-DATA-OCORRENCIA AND DTTERVIG >= :SINISMES-DATA-OCORRENCIA AND DTINIVIG = (SELECT MAX(A.DTINIVIG) FROM SEGUROS.LOTERICO01 A WHERE A.NUM_APOLICE = :LOTERI01-NUM-APOLICE AND A.COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL AND A.DTINIVIG <= :SINISMES-DATA-OCORRENCIA AND A.DTTERVIG >= :SINISMES-DATA-OCORRENCIA) END-EXEC. */

            var r111020_LE_LOTERICO01_DB_SELECT_1_Query1 = new R111020_LE_LOTERICO01_DB_SELECT_1_Query1()
            {
                SINISMES_DATA_OCORRENCIA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.ToString(),
                LOTERI01_COD_LOT_FENAL = LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL.ToString(),
                LOTERI01_NUM_APOLICE = LOTERI01.DCLLOTERICO01.LOTERI01_NUM_APOLICE.ToString(),
            };

            var executed_1 = R111020_LE_LOTERICO01_DB_SELECT_1_Query1.Execute(r111020_LE_LOTERICO01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_SIGLA_UF, LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF);
                _.Move(executed_1.LOTERI01_CIDADE, LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE);
                _.Move(executed_1.LOTERI01_COD_CLASSE_ADESAO, LOTERI01.DCLLOTERICO01.LOTERI01_COD_CLASSE_ADESAO);
                _.Move(executed_1.LOTERI01_AGENCIA, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111020_FIM*/

        [StopWatch]
        /*" R111030-LE-APOLICES */
        private void R111030_LE_APOLICES(bool isPerform = false)
        {
            /*" -918- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND1.WNR_EXEC_SQL);

            /*" -920- MOVE SINISHIS-NUM-APOLICE TO APOLICES-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -929- PERFORM R111030_LE_APOLICES_DB_SELECT_1 */

            R111030_LE_APOLICES_DB_SELECT_1();

            /*" -932- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -933- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -934- DISPLAY '*** SI0890B - APOLICE NAO ENCONTRADA ***' */
                    _.Display($"*** SI0890B - APOLICE NAO ENCONTRADA ***");

                    /*" -935- ELSE */
                }
                else
                {


                    /*" -936- DISPLAY '*** SI0890B - ERRO SELECT APOLICES ***' */
                    _.Display($"*** SI0890B - ERRO SELECT APOLICES ***");

                    /*" -937- END-IF */
                }


                /*" -938- DISPLAY 'APOLICE = ' APOLICES-NUM-APOLICE */
                _.Display($"APOLICE = {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -939- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -939- END-IF. */
            }


        }

        [StopWatch]
        /*" R111030-LE-APOLICES-DB-SELECT-1 */
        public void R111030_LE_APOLICES_DB_SELECT_1()
        {
            /*" -929- EXEC SQL SELECT RAMO_EMISSOR, COD_MODALIDADE INTO :APOLICES-RAMO-EMISSOR, :APOLICES-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE END-EXEC. */

            var r111030_LE_APOLICES_DB_SELECT_1_Query1 = new R111030_LE_APOLICES_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R111030_LE_APOLICES_DB_SELECT_1_Query1.Execute(r111030_LE_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111030_FIM*/

        [StopWatch]
        /*" R111040-LE-OUTROS-COB */
        private void R111040_LE_OUTROS_COB(bool isPerform = false)
        {
            /*" -951- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WABEND1.WNR_EXEC_SQL);

            /*" -952- MOVE SINISHIS-NUM-APOLICE TO OUTROCOB-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_NUM_APOLICE);

            /*" -953- MOVE SINILT01-COD-COBERTURA TO OUTROCOB-COD-COBERTURA. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA);

            /*" -954- MOVE APOLICES-RAMO-EMISSOR TO OUTROCOB-RAMO-COBERTURA. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_RAMO_COBERTURA);

            /*" -956- MOVE APOLICES-COD-MODALIDADE TO OUTROCOB-MODALI-COBERTURA. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_MODALI_COBERTURA);

            /*" -989- PERFORM R111040_LE_OUTROS_COB_DB_SELECT_1 */

            R111040_LE_OUTROS_COB_DB_SELECT_1();

            /*" -992- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -993- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -994- MOVE ZEROS TO OUTROCOB-IMP-SEGURADA-IX */
                    _.Move(0, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);

                    /*" -995- MOVE SPACES TO OUTROCOB-DATA-INIVIGENCIA */
                    _.Move("", OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA);

                    /*" -996- MOVE SPACES TO OUTROCOB-DATA-TERVIGENCIA */
                    _.Move("", OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA);

                    /*" -997- ELSE */
                }
                else
                {


                    /*" -998- DISPLAY '*** SI0890B - ERRO SELECT OUTROS_COBERTURAS *' */
                    _.Display($"*** SI0890B - ERRO SELECT OUTROS_COBERTURAS *");

                    /*" -999- DISPLAY 'NUMERO SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUMERO SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1000- GO TO M-999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1001- END-IF */
                }


                /*" -1001- END-IF. */
            }


        }

        [StopWatch]
        /*" R111040-LE-OUTROS-COB-DB-SELECT-1 */
        public void R111040_LE_OUTROS_COB_DB_SELECT_1()
        {
            /*" -989- EXEC SQL SELECT IMP_SEGURADA_IX, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :OUTROCOB-IMP-SEGURADA-IX, :OUTROCOB-DATA-INIVIGENCIA, :OUTROCOB-DATA-TERVIGENCIA FROM SEGUROS.OUTROS_COBERTURAS B WHERE B.NUM_APOLICE = :OUTROCOB-NUM-APOLICE AND B.RAMO_COBERTURA = :OUTROCOB-RAMO-COBERTURA AND B.MODALI_COBERTURA = :OUTROCOB-MODALI-COBERTURA AND B.COD_COBERTURA = :OUTROCOB-COD-COBERTURA AND B.DATA_TERVIGENCIA >= :SINISMES-DATA-OCORRENCIA AND B.DATA_INIVIGENCIA = (SELECT MAX(O.DATA_INIVIGENCIA) FROM SEGUROS.OUTROS_COBERTURAS O WHERE O.NUM_APOLICE = B.NUM_APOLICE AND O.RAMO_COBERTURA = B.RAMO_COBERTURA AND O.MODALI_COBERTURA = B.MODALI_COBERTURA AND O.COD_COBERTURA = B.COD_COBERTURA AND O.DATA_INIVIGENCIA <= :SINISMES-DATA-OCORRENCIA AND O.DATA_TERVIGENCIA >= :SINISMES-DATA-OCORRENCIA) AND B.TIMESTAMP = (SELECT MAX(Q.TIMESTAMP) FROM SEGUROS.OUTROS_COBERTURAS Q WHERE Q.NUM_APOLICE = B.NUM_APOLICE AND Q.RAMO_COBERTURA = B.RAMO_COBERTURA AND Q.MODALI_COBERTURA = B.MODALI_COBERTURA AND Q.COD_COBERTURA = B.COD_COBERTURA AND Q.DATA_INIVIGENCIA <= :SINISMES-DATA-OCORRENCIA AND Q.DATA_TERVIGENCIA >= :SINISMES-DATA-OCORRENCIA) END-EXEC. */

            var r111040_LE_OUTROS_COB_DB_SELECT_1_Query1 = new R111040_LE_OUTROS_COB_DB_SELECT_1_Query1()
            {
                OUTROCOB_MODALI_COBERTURA = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_MODALI_COBERTURA.ToString(),
                SINISMES_DATA_OCORRENCIA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.ToString(),
                OUTROCOB_RAMO_COBERTURA = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_RAMO_COBERTURA.ToString(),
                OUTROCOB_COD_COBERTURA = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA.ToString(),
                OUTROCOB_NUM_APOLICE = OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R111040_LE_OUTROS_COB_DB_SELECT_1_Query1.Execute(r111040_LE_OUTROS_COB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OUTROCOB_IMP_SEGURADA_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);
                _.Move(executed_1.OUTROCOB_DATA_INIVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA);
                _.Move(executed_1.OUTROCOB_DATA_TERVIGENCIA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111040_FIM*/

        [StopWatch]
        /*" R111050-LE-AGENCIAS */
        private void R111050_LE_AGENCIAS(bool isPerform = false)
        {
            /*" -1013- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND1.WNR_EXEC_SQL);

            /*" -1015- MOVE LOTERI01-AGENCIA TO AGENCCEF-COD-AGENCIA. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -1022- PERFORM R111050_LE_AGENCIAS_DB_SELECT_1 */

            R111050_LE_AGENCIAS_DB_SELECT_1();

            /*" -1025- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1026- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1027- MOVE ZEROS TO AGENCCEF-COD-ESCNEG */
                    _.Move(0, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);

                    /*" -1028- ELSE */
                }
                else
                {


                    /*" -1029- DISPLAY '*** SI0890B - ERRO SELECT AGENCIAS_CEF ***' */
                    _.Display($"*** SI0890B - ERRO SELECT AGENCIAS_CEF ***");

                    /*" -1030- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1031- DISPLAY 'AGENCIA  = ' AGENCCEF-COD-AGENCIA */
                    _.Display($"AGENCIA  = {AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA}");

                    /*" -1032- GO TO M-999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1033- END-IF */
                }


                /*" -1033- END-IF. */
            }


        }

        [StopWatch]
        /*" R111050-LE-AGENCIAS-DB-SELECT-1 */
        public void R111050_LE_AGENCIAS_DB_SELECT_1()
        {
            /*" -1022- EXEC SQL SELECT COD_ESCNEG INTO :AGENCCEF-COD-ESCNEG FROM SEGUROS.AGENCIAS_CEF WHERE COD_AGENCIA = :AGENCCEF-COD-AGENCIA END-EXEC. */

            var r111050_LE_AGENCIAS_DB_SELECT_1_Query1 = new R111050_LE_AGENCIAS_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R111050_LE_AGENCIAS_DB_SELECT_1_Query1.Execute(r111050_LE_AGENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111050_FIM*/

        [StopWatch]
        /*" R111060-SALDO-IS */
        private void R111060_SALDO_IS(bool isPerform = false)
        {
            /*" -1045- MOVE ZEROS TO LK2-RTCODE. */
            _.Move(0, LK2_LINK.LK2_RTCODE);

            /*" -1046- MOVE SINISHIS-NUM-APOLICE TO LK2-LOTERI01-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE, LK2_LINK.LK2_LOTERI01_NUM_APOLICE);

            /*" -1047- MOVE SINILT01-COD-COBERTURA TO LK2-AV-COD-NATUREZA. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA, LK2_LINK.LK2_AV_COD_NATUREZA);

            /*" -1048- MOVE SINILT01-COD-LOT-CEF TO LK2-LOTERI01-COD-LOT-CEF. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, LK2_LINK.LK2_LOTERI01_COD_LOT_CEF);

            /*" -1049- MOVE SINILT01-COD-LOT-CEF TO LK2-LOTERI01-COD-LOT-FENAL. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, LK2_LINK.LK2_LOTERI01_COD_LOT_FENAL);

            /*" -1050- MOVE OUTROCOB-IMP-SEGURADA-IX TO LK2-IMP-SEGURADA-IX. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, LK2_LINK.LK2_IMP_SEGURADA_IX);

            /*" -1051- MOVE OUTROCOB-DATA-INIVIGENCIA TO LK2-DATA-INIVIGENCIA. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_INIVIGENCIA, LK2_LINK.LK2_DATA_INIVIGENCIA);

            /*" -1053- MOVE OUTROCOB-DATA-TERVIGENCIA TO LK2-DATA-TERVIGENCIA. */
            _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_DATA_TERVIGENCIA, LK2_LINK.LK2_DATA_TERVIGENCIA);

            /*" -1055- CALL 'SI0006S' USING LK2-LINK */
            _.Call("SI0006S", LK2_LINK);

            /*" -1056- IF LK2-RTCODE NOT EQUAL ZEROS */

            if (LK2_LINK.LK2_RTCODE != 00)
            {

                /*" -1057- DISPLAY 'PROBLEMA ROTINA CALCULA SALDO SI0006S' */
                _.Display($"PROBLEMA ROTINA CALCULA SALDO SI0006S");

                /*" -1058- DISPLAY 'LK2-RTCODE = ' LK2-RTCODE */
                _.Display($"LK2-RTCODE = {LK2_LINK.LK2_RTCODE}");

                /*" -1059- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1059- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R111060_FIM*/

        [StopWatch]
        /*" R1120-CLOSE-CR-LOTER */
        private void R1120_CLOSE_CR_LOTER(bool isPerform = false)
        {
            /*" -1072- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND1.WNR_EXEC_SQL);

            /*" -1074- PERFORM R1120_CLOSE_CR_LOTER_DB_CLOSE_1 */

            R1120_CLOSE_CR_LOTER_DB_CLOSE_1();

            /*" -1077- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1078- DISPLAY '*** SI0890B - ERRO CLOSE CURSOR CR_LOTER ***' */
                _.Display($"*** SI0890B - ERRO CLOSE CURSOR CR_LOTER ***");

                /*" -1079- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1079- END-IF. */
            }


        }

        [StopWatch]
        /*" R1120-CLOSE-CR-LOTER-DB-CLOSE-1 */
        public void R1120_CLOSE_CR_LOTER_DB_CLOSE_1()
        {
            /*" -1074- EXEC SQL CLOSE CR_LOTER END-EXEC. */

            CR_LOTER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_FIM*/

        [StopWatch]
        /*" R120-CLOSE-CR-RELAT */
        private void R120_CLOSE_CR_RELAT(bool isPerform = false)
        {
            /*" -1092- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND1.WNR_EXEC_SQL);

            /*" -1094- PERFORM R120_CLOSE_CR_RELAT_DB_CLOSE_1 */

            R120_CLOSE_CR_RELAT_DB_CLOSE_1();

            /*" -1097- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1098- DISPLAY '*** SI0890B - ERRO CLOSE CURSOR CR_RELAT ***' */
                _.Display($"*** SI0890B - ERRO CLOSE CURSOR CR_RELAT ***");

                /*" -1099- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1099- END-IF. */
            }


        }

        [StopWatch]
        /*" R120-CLOSE-CR-RELAT-DB-CLOSE-1 */
        public void R120_CLOSE_CR_RELAT_DB_CLOSE_1()
        {
            /*" -1094- EXEC SQL CLOSE CR_RELAT END-EXEC. */

            CR_RELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_FIM*/

        [StopWatch]
        /*" R20-UPDATE-RELATORIO */
        private void R20_UPDATE_RELATORIO(bool isPerform = false)
        {
            /*" -1112- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", WABEND1.WNR_EXEC_SQL);

            /*" -1117- PERFORM R20_UPDATE_RELATORIO_DB_UPDATE_1 */

            R20_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -1120- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1121- DISPLAY '*** SI0890B - ERRO NO UPDATE DA RELATORIOS ***' */
                _.Display($"*** SI0890B - ERRO NO UPDATE DA RELATORIOS ***");

                /*" -1122- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1122- END-IF. */
            }


        }

        [StopWatch]
        /*" R20-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R20_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -1117- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0890B' AND SIT_REGISTRO = '0' END-EXEC. */

            var r20_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
            };

            R20_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(r20_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1133- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1134- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

                /*" -1135- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND2.WSQLCODE1);

                /*" -1136- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND2.WSQLCODE2);

                /*" -1137- DISPLAY WABEND1. */
                _.Display(WABEND1);
            }


            /*" -1139- DISPLAY WABEND2. */
            _.Display(WABEND2);

            /*" -1140- CLOSE LOTER01. */
            LOTER01.Close();

            /*" -1140- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1142- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1142- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -1150- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

            /*" -1153- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1156- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1159- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1162- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1165- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1168- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1171- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1174- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *");

            /*" -1177- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1180- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1183- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *");

            /*" -1186- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1189- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1192- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -1195- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1201- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1203- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1205- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1207- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1209- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1211- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1213- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1215- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1217- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O CALCISTA   *");

            /*" -1219- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1221- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1223- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O CALCISTA RESPONSAVEL  *");

            /*" -1225- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1227- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1229- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1231- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -1233- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1233- GO TO 999-999-ROT-ERRO. */

            M_999_999_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}