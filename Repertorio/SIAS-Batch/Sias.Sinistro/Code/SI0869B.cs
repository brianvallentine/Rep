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
using Sias.Sinistro.DB2.SI0869B;

namespace Code
{
    public class SI0869B
    {
        public bool IsCall { get; set; }

        public SI0869B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA   : SINISTRO                                        //      */
        /*"      * PROGRAMA  : SI0869B                                         //      */
        /*"      * OBJETIVO  : GERACAO DE ARQUIVO SEQUENCIALPARA A CARTEIRA    //      */
        /*"      *             DE LOTERICO,PRODUTO 7105/1803 APENAS PARA OS    //      */
        /*"      *             LOTERICOS EM QUE O ESTIPULANTE EH A CEF.        //      */
        /*"      *             IDENTIFICADO PELO COD_LOT_CEF = COD_LOT_FENAL   //      */
        /*"      *             E OS  ABATIMENTOS NA  SEGUROS.SINI_LOT_ABAT02   //      */
        /*"      *             PARA SER ENVIADO AA FENAE CORRETORA  E PARA A   //      */
        /*"      *             DELPHOS SERVI OS.                               //      */
        /*"      * ANALISTA/PROGRAMADOR :    HEIDER/RICARDO                    //      */
        /*"      * DATA                 :    JULHO / 2002                      //      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/01/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO  *    DATA     *    AUTOR    *       HISTORICO        *      */
        /*"      *           *             *             *                        *      */
        /*"      *     01    *  12/07/2002 * RICARDO     * CRIACAO.               *      */
        /*"      *           *             *             *                        *      */
        /*"      *     02    *  18/07/2002 * RICARDO     * ALTERACAO DO LAYOUT DO *      */
        /*"      *           *             *             * ARQUIVO POR SUGESTAO   *      */
        /*"      *           *             *             * DA FENAE E DA DELPHOS  *      */
        /*"      *           *             *             *                        *      */
        /*"      *     03    *  31/07/2002 * RICARDO     * RETORNO DO NUMERO  DO  *      */
        /*"      *           *             *             * SINISTRO NO LAYOUT DO  *      */
        /*"      *           *             *             * ARQUIVO E ACERTOS.     *      */
        /*"      *           *             *             * PROCURAR LRC03         *      */
        /*"      *           *             *             *                        *      */
        /*"      *     04    *  05/07/2002 * RICARDO     * ACERTO DE ABEND PARA   *      */
        /*"      *           *             *             * CODIGO DE OPERACAO     *      */
        /*"      *           *             *             * 1030 E 1040.           *      */
        /*"      *           *             *             * PROCURAR LRC04         *      */
        /*"      *     05    *  30/07/2002 * RICARDO     * ACERTO DE ABEND PARA   *      */
        /*"      *           *             *             * CODIGO DE OPERACAO     *      */
        /*"      *           *             *             * 1030 E 1040.           *      */
        /*"      *           *             *             * PROCURAR LRC04         *      */
        /*"      *     06    *  01/04/2005 * PRODEXTER   * SUBSTITUICAO DA TABELA *      */
        /*"      *           *             *             * PARAMETR_OPER_SINI     *      */
        /*"      *           *             *             * PELA                   *      */
        /*"      *           *             *             * GE_OPERACAO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *---------------------*                                                 */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "700", "X(700)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_ARQ_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_ARQ_SAIDA, _ARQ_SAIDA, REG_ARQ_SAIDA); return _ARQ_SAIDA;
            }
        }
        /*"01  REG-ARQ-SAIDA                  PIC X(700).*/
        public StringBasis REG_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "700", "X(700)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-VALOR-APURADO          PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_APURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-FRANQUIA         PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-REINTEG          PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_REINTEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-IOF-REINTEG      PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_IOF_REINTEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-AGRAV            PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_AGRAV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-IOF-AGRAV        PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_IOF_AGRAV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-OPERACAO-EST           PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis HOST_OPERACAO_EST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COD-OPERACAO           PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis HOST_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COD-OPERACAO-SICOV     PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis HOST_COD_OPERACAO_SICOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-DATA-ADIANTAMENTO      PIC  X(10).*/
        public StringBasis HOST_DATA_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-MOVIMENTO         PIC  X(10).*/
        public StringBasis HOST_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-DATA-VALOR-APURADO     PIC  X(10).*/
        public StringBasis HOST_DATA_VALOR_APURADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-VALOR-ADIANTAMENTO     PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-INDENIZACAO      PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-VALOR-DIFERENCA        PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  ACM-VAL-AGRAVAMENTO         PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis ACM_VAL_AGRAVAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  ACM-VAL-IOF-AGRAV           PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis ACM_VAL_IOF_AGRAV { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  W-ARQUIVO.*/
        public SI0869B_W_ARQUIVO W_ARQUIVO { get; set; } = new SI0869B_W_ARQUIVO();
        public class SI0869B_W_ARQUIVO : VarBasis
        {
            /*"    03 LC00.*/
            public SI0869B_LC00 LC00 { get; set; } = new SI0869B_LC00();
            public class SI0869B_LC00 : VarBasis
            {
                /*"       05  C00-FILLER           PIC  X(650) VALUE SPACES.*/
                public StringBasis C00_FILLER { get; set; } = new StringBasis(new PIC("X", "650", "X(650)"), @"");
                /*"    03 LC01.*/
            }
            public SI0869B_LC01 LC01 { get; set; } = new SI0869B_LC01();
            public class SI0869B_LC01 : VarBasis
            {
                /*"       05  C01-IDENTIFICADOR    PIC  X(650) VALUE           'PROGRAMA GERADOR >>> SI0869B;'.*/
                public StringBasis C01_IDENTIFICADOR { get; set; } = new StringBasis(new PIC("X", "650", "X(650)"), @"PROGRAMA GERADOR >>> SI0869B;");
                /*"    03 LC02A.*/
            }
            public SI0869B_LC02A LC02A { get; set; } = new SI0869B_LC02A();
            public class SI0869B_LC02A : VarBasis
            {
                /*"       05  C03-FUNCAO           PIC  X(049) VALUE        'DEMONSTRATIVO DE PAGAMENTO DE SINISTROS LOTERICOS'.*/
                public StringBasis C03_FUNCAO { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"DEMONSTRATIVO DE PAGAMENTO DE SINISTROS LOTERICOS");
                /*"       05  FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    03 LC02B.*/
            }
            public SI0869B_LC02B LC02B { get; set; } = new SI0869B_LC02B();
            public class SI0869B_LC02B : VarBasis
            {
                /*"       05  C03-FUNCAO           PIC  X(057) VALUE        'INFORMACOES DE SINISTROS LOTERICOS PARA A FENAE E DELPHO        'S'.*/
                public StringBasis C03_FUNCAO_0 { get; set; } = new StringBasis(new PIC("X", "57", "X(057)"), @"INFORMACOES DE SINISTROS LOTERICOS PARA A FENAE E DELPHO        ");
                /*"       05  FILLER               PIC  X(001) VALUE ';'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    03 LC03.*/
            }
            public SI0869B_LC03 LC03 { get; set; } = new SI0869B_LC03();
            public class SI0869B_LC03 : VarBasis
            {
                /*"       05 FILLER                PIC X(14) VALUE          'DATA MOVIMENTO'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"DATA MOVIMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(15) VALUE          'SINISTRO SEGUR.'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"SINISTRO SEGUR.");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(15) VALUE          'SINISTRO PREST.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"SINISTRO PREST.");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(17) VALUE          'COD. LOTERICO CEF'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"COD. LOTERICO CEF");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(08) VALUE          'LOTERICO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"LOTERICO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(03) VALUE          'DDD'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(08) VALUE          'TELEFONE'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(09) VALUE          'DATA OCOR'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DATA OCOR");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(10) VALUE          'DATA AVISO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA AVISO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(06) VALUE          'CAUSA'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CAUSA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(14) VALUE          'TIPO MOVIMENTO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"TIPO MOVIMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(14) VALUE          'TIPO PAGAMENTO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"TIPO PAGAMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(15) VALUE          'FORMA PAGAMENTO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"FORMA PAGAMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(10) VALUE          'DATA ENVIO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA ENVIO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(13) VALUE          'DATA DEB/CRED'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA DEB/CRED");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(07) VALUE          'AGENCIA'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(05) VALUE          'CONTA'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CONTA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(02) VALUE          'DV'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"DV");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(19) VALUE          'SIN. PAGO DE NUMERO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"SIN. PAGO DE NUMERO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(22) VALUE          '$ IMPORTANCIA SEGURADA'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"$ IMPORTANCIA SEGURADA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(09) VALUE          '$ AVISADO'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"$ AVISADO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(12) VALUE          '$ REGISTRADO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"$ REGISTRADO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(14) VALUE          '$ ADIANTAMENTO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"$ ADIANTAMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(13) VALUE          '$ INDENIZACAO'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"$ INDENIZACAO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(10) VALUE          '$ REGULADO'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ REGULADO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(10) VALUE          '% FRANQUIA'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"% FRANQUIA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(10) VALUE          '$ FRANQUIA'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ FRANQUIA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(20) VALUE          '$ FRANQUIA CALCULADA'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"$ FRANQUIA CALCULADA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(17) VALUE          '$ FRANQUIA MINIMA'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"$ FRANQUIA MINIMA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(14) VALUE          '$ REINTEGRACAO'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"$ REINTEGRACAO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(18) VALUE          '$ IOF REINTEGRACAO'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"$ IOF REINTEGRACAO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(13) VALUE          '% AGRAVAMENTO'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"% AGRAVAMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(13) VALUE          '$ AGRAVAMENTO'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"$ AGRAVAMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(17) VALUE          '$ IOF AGRAVAMENTO'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"$ IOF AGRAVAMENTO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(17) VALUE          '$ DIF INDENIZACAO'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"$ DIF INDENIZACAO");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 FILLER                PIC X(16) VALUE          'CRD/DEB NA CONTA'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"CRD/DEB NA CONTA");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01.*/
            }
            public SI0869B_LD01 LD01 { get; set; } = new SI0869B_LD01();
            public class SI0869B_LD01 : VarBasis
            {
                /*"       05 LD01-DATA-MVTO        PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_MVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-SINISTRO-SEG     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_SINISTRO_SEG { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-SINISTRO-PREST   PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_SINISTRO_PREST { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-COD-LOTERICO     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_COD_LOTERICO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-NOME-LOTERICO    PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DDD              PIC 9(04) VALUE 0.*/
                public IntBasis LD01_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-TELEFONE         PIC 9(11) VALUE 0.*/
                public IntBasis LD01_TELEFONE { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATA-OCORRENCIA  PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATA-AVISO       PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-CAUSA-SINISTRO   PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_CAUSA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-TIPO-MOVIMENTO   PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-TIPO-PAGAMENTO   PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-FORMA-PAGAMENTO  PIC X(40) VALUE SPACES.*/
                public StringBasis LD01_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATA-ENVIO       PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DATA-DEB-CRED    PIC X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_DEB_CRED { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-AGENCIA          PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-CONTA            PIC 999.999.999.999.*/
                public IntBasis LD01_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "999.999.999.999."));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-DV               PIC 9(01) VALUE 0.*/
                public IntBasis LD01_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-QTD-SINI-PAG     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_QTD_SINI_PAG { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-IMP-SEGURADA PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_IMP_SEGURADA { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-AVISADO      PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-REGISTRADO   PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_REGISTRADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-ADIANTAMENTO PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-INDENIZACAO  PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-REGULADO     PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_REGULADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-PER-FRANQUIA     PIC --9,99.*/
                public DoubleBasis LD01_PER_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "3", "--9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-FRANQUIA     PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-FRANQ-CALC   PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_FRANQ_CALC { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-FRANQUIA-MIN PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_FRANQUIA_MIN { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-REINTEGRACAO PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_REINTEGRACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-IOF-REINT    PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_IOF_REINT { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-PER-AGRAVAMENTO  PIC --9,99.*/
                public DoubleBasis LD01_PER_AGRAVAMENTO { get; set; } = new DoubleBasis(new PIC("9", "3", "--9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-AGRAVAMENTO  PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_AGRAVAMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-IOF-AGRAV    PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_IOF_AGRAV { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-VAL-DIF-INDEN    PIC ------------9,99.*/
                public DoubleBasis LD01_VAL_DIF_INDEN { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"       05 LD01-MOVIMENTO-CONTA  PIC X(15) VALUE SPACES.*/
                public StringBasis LD01_MOVIMENTO_CONTA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       05 FILLER                PIC X(01) VALUE ';'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03            WSQLCODE3          PIC S9(09) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03 W-DATA-AAAA-MM-DD.*/
            public SI0869B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0869B_W_DATA_AAAA_MM_DD();
            public class SI0869B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"       05 W-DATA-AAAA-MM-DD-AAAA      PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-AAAA-MM-DD-MM        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-AAAA-MM-DD-DD        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03 W-DATA-DD-MM-AAAA.*/
            }
            public SI0869B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0869B_W_DATA_DD_MM_AAAA();
            public class SI0869B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       05 W-DATA-DD-MM-AAAA-DD        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-DD-MM-AAAA-MM        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-DD-MM-AAAA-AAAA      PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 W-DATA-DD-MM-AAAA1.*/
            }
            public SI0869B_W_DATA_DD_MM_AAAA1 W_DATA_DD_MM_AAAA1 { get; set; } = new SI0869B_W_DATA_DD_MM_AAAA1();
            public class SI0869B_W_DATA_DD_MM_AAAA1 : VarBasis
            {
                /*"       05 W-DATA-DD-MM-AAAA1-DD       PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 W-DATA-DD-MM-AAAA1-MM       PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 W-DATA-DD-MM-AAAA1-AAAA     PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA1_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 W-GDA-COD-LOTERICO             PIC 9(13) VALUE ZEROS.*/
            }
            public IntBasis W_GDA_COD_LOTERICO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER REDEFINES W-GDA-COD-LOTERICO.*/
            private _REDEF_SI0869B_FILLER_116 _filler_116 { get; set; }
            public _REDEF_SI0869B_FILLER_116 FILLER_116
            {
                get { _filler_116 = new _REDEF_SI0869B_FILLER_116(); _.Move(W_GDA_COD_LOTERICO, _filler_116); VarBasis.RedefinePassValue(W_GDA_COD_LOTERICO, _filler_116, W_GDA_COD_LOTERICO); _filler_116.ValueChanged += () => { _.Move(_filler_116, W_GDA_COD_LOTERICO); }; return _filler_116; }
                set { VarBasis.RedefinePassValue(value, _filler_116, W_GDA_COD_LOTERICO); }
            }  //Redefines
            public class _REDEF_SI0869B_FILLER_116 : VarBasis
            {
                /*"       05 W-GDA-COD-CAIXA             PIC 9(06).*/
                public IntBasis W_GDA_COD_CAIXA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       05 W-GDA-COD-LOT               PIC 9(06).*/
                public IntBasis W_GDA_COD_LOT { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       05 W-GDA-DIG-COD-LOT           PIC 9.*/
                public IntBasis W_GDA_DIG_COD_LOT { get; set; } = new IntBasis(new PIC("9", "1", "9."));
                /*"    03 W-GDA-CPF                      PIC 9(15) VALUE ZEROS.*/

                public _REDEF_SI0869B_FILLER_116()
                {
                    W_GDA_COD_CAIXA.ValueChanged += OnValueChanged;
                    W_GDA_COD_LOT.ValueChanged += OnValueChanged;
                    W_GDA_DIG_COD_LOT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_GDA_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    03 FILLER REDEFINES W-GDA-CPF.*/
            private _REDEF_SI0869B_FILLER_117 _filler_117 { get; set; }
            public _REDEF_SI0869B_FILLER_117 FILLER_117
            {
                get { _filler_117 = new _REDEF_SI0869B_FILLER_117(); _.Move(W_GDA_CPF, _filler_117); VarBasis.RedefinePassValue(W_GDA_CPF, _filler_117, W_GDA_CPF); _filler_117.ValueChanged += () => { _.Move(_filler_117, W_GDA_CPF); }; return _filler_117; }
                set { VarBasis.RedefinePassValue(value, _filler_117, W_GDA_CPF); }
            }  //Redefines
            public class _REDEF_SI0869B_FILLER_117 : VarBasis
            {
                /*"       05 W-GDA-NUM-CPF               PIC 9(13).*/
                public IntBasis W_GDA_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       05 W-GDA-DGV-CPF               PIC 9(02).*/
                public IntBasis W_GDA_DGV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 W-GDA-CGC                      PIC 9(15) VALUE ZEROS.*/

                public _REDEF_SI0869B_FILLER_117()
                {
                    W_GDA_NUM_CPF.ValueChanged += OnValueChanged;
                    W_GDA_DGV_CPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_GDA_CGC { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    03 FILLER REDEFINES W-GDA-CGC.*/
            private _REDEF_SI0869B_FILLER_118 _filler_118 { get; set; }
            public _REDEF_SI0869B_FILLER_118 FILLER_118
            {
                get { _filler_118 = new _REDEF_SI0869B_FILLER_118(); _.Move(W_GDA_CGC, _filler_118); VarBasis.RedefinePassValue(W_GDA_CGC, _filler_118, W_GDA_CGC); _filler_118.ValueChanged += () => { _.Move(_filler_118, W_GDA_CGC); }; return _filler_118; }
                set { VarBasis.RedefinePassValue(value, _filler_118, W_GDA_CGC); }
            }  //Redefines
            public class _REDEF_SI0869B_FILLER_118 : VarBasis
            {
                /*"       05 W-GDA-NUM-CGC               PIC 9(09).*/
                public IntBasis W_GDA_NUM_CGC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"       05 W-GDA-COMPL-CGC             PIC 9(04).*/
                public IntBasis W_GDA_COMPL_CGC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 W-GDA-DGV-CGC               PIC 9(02).*/
                public IntBasis W_GDA_DGV_CGC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 W-CGC.*/

                public _REDEF_SI0869B_FILLER_118()
                {
                    W_GDA_NUM_CGC.ValueChanged += OnValueChanged;
                    W_GDA_COMPL_CGC.ValueChanged += OnValueChanged;
                    W_GDA_DGV_CGC.ValueChanged += OnValueChanged;
                }

            }
            public SI0869B_W_CGC W_CGC { get; set; } = new SI0869B_W_CGC();
            public class SI0869B_W_CGC : VarBasis
            {
                /*"       05 W-NUM-CGC                   PIC Z99.999.999.*/
                public IntBasis W_NUM_CGC { get; set; } = new IntBasis(new PIC("9", "9", "Z99.999.999."));
                /*"       05 FILLER                      PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"       05 W-COMPL-CGC                 PIC 9999.*/
                public IntBasis W_COMPL_CGC { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DGV-CGC                   PIC 99.*/
                public IntBasis W_DGV_CGC { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    03 W-CPF.*/
            }
            public SI0869B_W_CPF W_CPF { get; set; } = new SI0869B_W_CPF();
            public class SI0869B_W_CPF : VarBasis
            {
                /*"       05 W-NUM-CPF                   PIC ZZZ.999.999.999.*/
                public IntBasis W_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "12", "ZZZ.999.999.999."));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DGV-CPF                   PIC 99.*/
                public IntBasis W_DGV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"    03 W-NUMDOC                      PIC 9(13) VALUE ZEROS.*/
            }
            public IntBasis W_NUMDOC { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 WFIM-SINISTRO-HISTORICO       PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_SINISTRO_HISTORICO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 WFIM-CURSOR-RETENCOES         PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_CURSOR_RETENCOES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-PRODUTO-OPERACAO             PIC 9(09).*/
            public IntBasis W_PRODUTO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    03 FILLER         REDEFINES       W-PRODUTO-OPERACAO.*/
            private _REDEF_SI0869B_FILLER_122 _filler_122 { get; set; }
            public _REDEF_SI0869B_FILLER_122 FILLER_122
            {
                get { _filler_122 = new _REDEF_SI0869B_FILLER_122(); _.Move(W_PRODUTO_OPERACAO, _filler_122); VarBasis.RedefinePassValue(W_PRODUTO_OPERACAO, _filler_122, W_PRODUTO_OPERACAO); _filler_122.ValueChanged += () => { _.Move(_filler_122, W_PRODUTO_OPERACAO); }; return _filler_122; }
                set { VarBasis.RedefinePassValue(value, _filler_122, W_PRODUTO_OPERACAO); }
            }  //Redefines
            public class _REDEF_SI0869B_FILLER_122 : VarBasis
            {
                /*"       10 FILLER                      PIC 9(01).*/
                public IntBasis FILLER_123 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 W-PRODUTO-OPERACAO-PRODUTO  PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-PRODUTO-OPERACAO-OPERACAO PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03 W-IND01                       PIC 9(03) VALUE ZEROS.*/

                public _REDEF_SI0869B_FILLER_122()
                {
                    FILLER_123.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_PRODUTO.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_IND01 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 W-IND02                       PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_IND02 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 WTAB01.*/
            public SI0869B_WTAB01 WTAB01 { get; set; } = new SI0869B_WTAB01();
            public class SI0869B_WTAB01 : VarBasis
            {
                /*"       05 WTAB01-LETRA               PIC X(01) OCCURS 132.*/
                public ListBasis<StringBasis, string> WTAB01_LETRA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 132);
                /*"    03 WTAB02.*/
            }
            public SI0869B_WTAB02 WTAB02 { get; set; } = new SI0869B_WTAB02();
            public class SI0869B_WTAB02 : VarBasis
            {
                /*"       05 WTAB02-LETRA               PIC X(01) OCCURS 132.*/
                public ListBasis<StringBasis, string> WTAB02_LETRA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 132);
                /*"     03 WTABMES-G.*/
                public SI0869B_WTABMES_G WTABMES_G { get; set; } = new SI0869B_WTABMES_G();
                public class SI0869B_WTABMES_G : VarBasis
                {
                    /*"        05 FILLER     PIC  X(009) VALUE 'JANEIRO  '.*/
                    public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JANEIRO  ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'FEVEREIRO'.*/
                    public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                    /*"        05 FILLER     PIC  X(009) VALUE 'MARCO    '.*/
                    public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MARCO    ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'ABRIL    '.*/
                    public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ABRIL    ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'MAIO     '.*/
                    public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MAIO     ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'JUNHO    '.*/
                    public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JUNHO    ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'JULHO    '.*/
                    public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JULHO    ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'AGOSTO   '.*/
                    public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AGOSTO   ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'SETEMBRO '.*/
                    public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SETEMBRO ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'OUTUBRO  '.*/
                    public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"OUTUBRO  ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'NOVEMBRO '.*/
                    public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NOVEMBRO ");
                    /*"        05 FILLER     PIC  X(009) VALUE 'DEZEMBRO '.*/
                    public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DEZEMBRO ");
                    /*"     03 WTABMES REDEFINES WTABMES-G PIC X(09) OCCURS 12.*/
                }
                private _REDEF_StringBasis _wtabmes { get; set; }
                public _REDEF_StringBasis WTABMES
                {
                    get { _wtabmes = new _REDEF_StringBasis(new PIC("X", "09", "X(09)")); ; _.Move(WTABMES_G, _wtabmes); VarBasis.RedefinePassValue(WTABMES_G, _wtabmes, WTABMES_G); _wtabmes.ValueChanged += () => { _.Move(_wtabmes, WTABMES_G); }; return _wtabmes; }
                    set { VarBasis.RedefinePassValue(value, _wtabmes, WTABMES_G); }
                }  //Redefines
                /*"  03        WABEND.*/
                public SI0869B_WABEND WABEND { get; set; } = new SI0869B_WABEND();
                public class SI0869B_WABEND : VarBasis
                {
                    /*"    05      FILLER              PIC  X(10) VALUE           ' SI0869B'.*/
                }
            }
        }
        public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0869B");
        /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
        public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
        /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
        /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
        public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
        /*"    05      PARAGRAFO           PIC  X(30) VALUE SPACES.*/
        public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
        /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
        public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
        /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
        public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
        public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
        /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
        public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
        public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
        /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
        public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        /*"01          LK-LINK.*/
        public SI0869B_LK_LINK LK_LINK { get; set; } = new SI0869B_LK_LINK();
        public class SI0869B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(04)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03        LK-TAMANHO          PIC  S9(04)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SILOTDC2 SILOTDC2 { get; set; } = new Dclgens.SILOTDC2();
        public Dclgens.SINLOTDO SINLOTDO { get; set; } = new Dclgens.SINLOTDO();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SIMOLOT1 SIMOLOT1 { get; set; } = new Dclgens.SIMOLOT1();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.LOTECHEQ LOTECHEQ { get; set; } = new Dclgens.LOTECHEQ();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.SINLOAB2 SINLOAB2 { get; set; } = new Dclgens.SINLOAB2();
        public SI0869B_INDENIZACOES INDENIZACOES { get; set; } = new SI0869B_INDENIZACOES();
        public SI0869B_RETENCOES RETENCOES { get; set; } = new SI0869B_RETENCOES();
        public SI0869B_LOTERICO LOTERICO { get; set; } = new SI0869B_LOTERICO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQ_SAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQ_SAIDA.SetFile(ARQ_SAIDA_FILE_NAME_P);

                /*" -522- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -523- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -524- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -528- OPEN OUTPUT ARQ-SAIDA. */
                ARQ_SAIDA.Open(REG_ARQ_SAIDA);

                /*" -530- PERFORM R010-LE-SISTEMA THRU R010-EXIT. */

                R010_LE_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -531- MOVE 'NAO' TO WFIM-SINISTRO-HISTORICO. */
                _.Move("NAO", W_ARQUIVO.WFIM_SINISTRO_HISTORICO);

                /*" -532- PERFORM R020-DECLARE-PAGAMENTOS THRU R020-EXIT. */

                R020_DECLARE_PAGAMENTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -534- PERFORM R021-FETCH-PAGAMENTOS THRU R021-EXIT. */

                R021_FETCH_PAGAMENTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -535- WRITE REG-ARQ-SAIDA FROM LC01. */
                _.Move(W_ARQUIVO.LC01.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -536- WRITE REG-ARQ-SAIDA FROM LC02A. */
                _.Move(W_ARQUIVO.LC02A.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -537- WRITE REG-ARQ-SAIDA FROM LC02B. */
                _.Move(W_ARQUIVO.LC02B.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -539- WRITE REG-ARQ-SAIDA FROM LC03. */
                _.Move(W_ARQUIVO.LC03.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                /*" -540- IF WFIM-SINISTRO-HISTORICO EQUAL 'SIM' */

                if (W_ARQUIVO.WFIM_SINISTRO_HISTORICO == "SIM")
                {

                    /*" -541- DISPLAY 'SI0869B  - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                    _.Display($"SI0869B  - NAO HOUVE SOLICITACAO P/ EMISSAO");

                    /*" -542- MOVE 'NAO HOUVE MOVIMENTO NA DATA DE HOJE' TO C00-FILLER */
                    _.Move("NAO HOUVE MOVIMENTO NA DATA DE HOJE", W_ARQUIVO.LC00.C00_FILLER);

                    /*" -543- WRITE REG-ARQ-SAIDA FROM LC00 */
                    _.Move(W_ARQUIVO.LC00.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -545- GO TO 000-900-FIM. */

                    M_000_900_FIM(); //GOTO
                    return Result;
                }


                /*" -548- PERFORM R100-PROCESSA-PAGAMENTOS THRU R100-EXIT UNTIL WFIM-SINISTRO-HISTORICO EQUAL 'SIM' . */

                while (!(W_ARQUIVO.WFIM_SINISTRO_HISTORICO == "SIM"))
                {

                    R100_PROCESSA_PAGAMENTOS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -548- CLOSE ARQ-SAIDA. */
                ARQ_SAIDA.Close();

                /*" -548- FLUXCONTROL_PERFORM M-000-900-FIM */

                M_000_900_FIM();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -553- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -554- DISPLAY 'SI0869B         *** FIM NORMAL ***' . */
            _.Display($"SI0869B         *** FIM NORMAL ***");

            /*" -554- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-LE-SISTEMA */
        private void R010_LE_SISTEMA(bool isPerform = false)
        {
            /*" -561- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WNR_EXEC_SQL);

            /*" -568- PERFORM R010_LE_SISTEMA_DB_SELECT_1 */

            R010_LE_SISTEMA_DB_SELECT_1();

            /*" -571- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -572- DISPLAY 'ERRO SELECT - SISTEMAS....................' */
                _.Display($"ERRO SELECT - SISTEMAS....................");

                /*" -574- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -575- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -576- DISPLAY '* PROGRAMA SI0869B                              *' */
            _.Display($"* PROGRAMA SI0869B                              *");

            /*" -577- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -578- DISPLAY ' ' . */
            _.Display($" ");

            /*" -579- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -584- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) ' ' SISTEMAS-DATA-MOV-ABERTO(8:1) ' ' SISTEMAS-DATA-MOV-ABERTO(6:2) ' ' SISTEMAS-DATA-MOV-ABERTO(5:1) ' ' SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -585- DISPLAY ' ' . */
            _.Display($" ");

            /*" -586- DISPLAY 'DATA DO ULTIMO PROCESSAMENTO(SI)' . */
            _.Display($"DATA DO ULTIMO PROCESSAMENTO(SI)");

            /*" -591- DISPLAY SISTEMAS-DATULT-PROCESSAMEN(9:2) ' ' SISTEMAS-DATULT-PROCESSAMEN(8:1) ' ' SISTEMAS-DATULT-PROCESSAMEN(6:2) ' ' SISTEMAS-DATULT-PROCESSAMEN(5:1) ' ' SISTEMAS-DATULT-PROCESSAMEN(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(9, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(8, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(6, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(5, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(1, 4)}"
            .Display();

            /*" -593- DISPLAY ' ' . */
            _.Display($" ");

            /*" -594- MOVE SISTEMAS-DATULT-PROCESSAMEN TO W-DATA-AAAA-MM-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN, W_ARQUIVO.W_DATA_AAAA_MM_DD);

            /*" -595- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA. */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -596- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM. */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -596- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD. */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

        }

        [StopWatch]
        /*" R010-LE-SISTEMA-DB-SELECT-1 */
        public void R010_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -568- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
        /*" R020-DECLARE-PAGAMENTOS */
        private void R020_DECLARE_PAGAMENTOS(bool isPerform = false)
        {
            /*" -605- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WNR_EXEC_SQL);

            /*" -655- PERFORM R020_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            R020_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -658- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WNR_EXEC_SQL);

            /*" -658- PERFORM R020_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            R020_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -661- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -662- DISPLAY 'ERRO OPEN MOVTO_DEBITOCC_CEF ............. ' */
                _.Display($"ERRO OPEN MOVTO_DEBITOCC_CEF ............. ");

                /*" -663- DISPLAY 'PODE TER SIDO CAUSADO POR LOCK NA TABELA   ' */
                _.Display($"PODE TER SIDO CAUSADO POR LOCK NA TABELA   ");

                /*" -664- DISPLAY 'FAVOR VERIFICAR E ME LIGAR.    HEIDER      ' */
                _.Display($"FAVOR VERIFICAR E ME LIGAR.    HEIDER      ");

                /*" -664- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R020-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void R020_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -655- EXEC SQL DECLARE INDENIZACOES CURSOR FOR SELECT H.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.DATA_OCORRENCIA, M.COD_CAUSA, S.DESCR_CAUSA, H.COD_OPERACAO, H.COD_PRODUTO, H.DATA_MOVIMENTO, H.OCORR_HISTORICO, H.VAL_OPERACAO, H.SIT_CONTABIL, L.COD_CLIENTE, C.NOME_RAZAO, C.CGCCPF, C.TIPO_PESSOA, L.COD_LOT_FENAL, L.COD_LOT_CEF, L.COD_COBERTURA, A.VALOR_INFORMADO, A.VALOR_REGISTRADO, A.VAL_IS, A.DATA_AVISO, A.VAL_ADIANTAMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 L, SEGUROS.SI_MOV_LOTERICO1 A, SEGUROS.CLIENTES C, SEGUROS.SINISTRO_CAUSA S, SEGUROS.GE_OPERACAO O WHERE H.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND ((H.COD_PRODUTO = 7105 AND L.COD_COBERTURA = 4) OR (H.COD_PRODUTO = 1803 AND L.COD_COBERTURA = 2)) AND H.COD_OPERACAO IN (1071,1072,1073,1074, 1030,1040) AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'IN' AND O.IDE_SISTEMA = 'SI' AND O.FUNCAO_OPERACAO IN ( 'IND' , 'LIB' , 'EIND' ) AND L.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND L.COD_LOT_FENAL = L.COD_LOT_CEF AND C.COD_CLIENTE = L.COD_CLIENTE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.RAMO_EMISSOR = M.RAMO AND S.COD_CAUSA = M.COD_CAUSA ORDER BY H.NUM_APOL_SINISTRO END-EXEC. */
            INDENIZACOES = new SI0869B_INDENIZACOES(true);
            string GetQuery_INDENIZACOES()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							M.NUM_APOLICE
							, 
							M.DATA_OCORRENCIA
							, 
							M.COD_CAUSA
							, 
							S.DESCR_CAUSA
							, 
							H.COD_OPERACAO
							, 
							H.COD_PRODUTO
							, 
							H.DATA_MOVIMENTO
							, 
							H.OCORR_HISTORICO
							, 
							H.VAL_OPERACAO
							, 
							H.SIT_CONTABIL
							, 
							L.COD_CLIENTE
							, 
							C.NOME_RAZAO
							, 
							C.CGCCPF
							, 
							C.TIPO_PESSOA
							, 
							L.COD_LOT_FENAL
							, 
							L.COD_LOT_CEF
							, 
							L.COD_COBERTURA
							, 
							A.VALOR_INFORMADO
							, 
							A.VALOR_REGISTRADO
							, 
							A.VAL_IS
							, 
							A.DATA_AVISO
							, 
							A.VAL_ADIANTAMENTO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINI_LOTERICO01 L
							, 
							SEGUROS.SI_MOV_LOTERICO1 A
							, 
							SEGUROS.CLIENTES C
							, 
							SEGUROS.SINISTRO_CAUSA S
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND ((H.COD_PRODUTO = 7105 AND 
							L.COD_COBERTURA = 4) OR 
							(H.COD_PRODUTO = 1803 AND 
							L.COD_COBERTURA = 2)) 
							AND H.COD_OPERACAO IN (1071
							,1072
							,1073
							,1074
							, 
							1030
							,1040) 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO = 'IN' 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.FUNCAO_OPERACAO IN ( 'IND'
							, 'LIB'
							, 'EIND' ) 
							AND L.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND L.COD_LOT_FENAL = L.COD_LOT_CEF 
							AND C.COD_CLIENTE = L.COD_CLIENTE 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND S.RAMO_EMISSOR = M.RAMO 
							AND S.COD_CAUSA = M.COD_CAUSA 
							ORDER BY H.NUM_APOL_SINISTRO";

                return query;
            }
            INDENIZACOES.GetQueryEvent += GetQuery_INDENIZACOES;

        }

        [StopWatch]
        /*" R020-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void R020_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -658- EXEC SQL OPEN INDENIZACOES END-EXEC. */

            INDENIZACOES.Open();

        }

        [StopWatch]
        /*" R150-DECLARE-CURSOR-RETENCAO-DB-DECLARE-1 */
        public void R150_DECLARE_CURSOR_RETENCAO_DB_DECLARE_1()
        {
            /*" -1043- EXEC SQL DECLARE RETENCOES CURSOR FOR SELECT VALUE(SUM(VALOR_RETENCAO),0), VLR_RETENCAO_CALC, IND_VLR_RETENCAO, PERCENT_RETENCAO, COD_RETENCAO, QTD_SINISTRO_PAGO FROM SEGUROS.SINI_LOT_ABAT02 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO GROUP BY VLR_RETENCAO_CALC, IND_VLR_RETENCAO, PERCENT_RETENCAO, COD_RETENCAO, QTD_SINISTRO_PAGO ORDER BY VLR_RETENCAO_CALC, IND_VLR_RETENCAO, PERCENT_RETENCAO, COD_RETENCAO, QTD_SINISTRO_PAGO END-EXEC. */
            RETENCOES = new SI0869B_RETENCOES(true);
            string GetQuery_RETENCOES()
            {
                var query = @$"SELECT VALUE(SUM(VALOR_RETENCAO)
							,0)
							, 
							VLR_RETENCAO_CALC
							, 
							IND_VLR_RETENCAO
							, 
							PERCENT_RETENCAO
							, 
							COD_RETENCAO
							, 
							QTD_SINISTRO_PAGO 
							FROM SEGUROS.SINI_LOT_ABAT02 
							WHERE NUM_APOL_SINISTRO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}' 
							GROUP BY VLR_RETENCAO_CALC
							, 
							IND_VLR_RETENCAO
							, 
							PERCENT_RETENCAO
							, 
							COD_RETENCAO
							, 
							QTD_SINISTRO_PAGO 
							ORDER BY VLR_RETENCAO_CALC
							, 
							IND_VLR_RETENCAO
							, 
							PERCENT_RETENCAO
							, 
							COD_RETENCAO
							, 
							QTD_SINISTRO_PAGO";

                return query;
            }
            RETENCOES.GetQueryEvent += GetQuery_RETENCOES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-PAGAMENTOS */
        private void R021_FETCH_PAGAMENTOS(bool isPerform = false)
        {
            /*" -672- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WNR_EXEC_SQL);

            /*" -696- PERFORM R021_FETCH_PAGAMENTOS_DB_FETCH_1 */

            R021_FETCH_PAGAMENTOS_DB_FETCH_1();

            /*" -699- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -700- DISPLAY 'ERRO FETCH DO CURSOR INDENIZACOES ........' */
                _.Display($"ERRO FETCH DO CURSOR INDENIZACOES ........");

                /*" -702- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -703- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -703- PERFORM R021_FETCH_PAGAMENTOS_DB_CLOSE_1 */

                R021_FETCH_PAGAMENTOS_DB_CLOSE_1();

                /*" -704- MOVE 'SIM' TO WFIM-SINISTRO-HISTORICO. */
                _.Move("SIM", W_ARQUIVO.WFIM_SINISTRO_HISTORICO);
            }


        }

        [StopWatch]
        /*" R021-FETCH-PAGAMENTOS-DB-FETCH-1 */
        public void R021_FETCH_PAGAMENTOS_DB_FETCH_1()
        {
            /*" -696- EXEC SQL FETCH INDENIZACOES INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-DATA-OCORRENCIA, :SINISMES-COD-CAUSA, :SINISCAU-DESCR-CAUSA, :SINISHIS-COD-OPERACAO, :SINISHIS-COD-PRODUTO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-VAL-OPERACAO, :SINISHIS-SIT-CONTABIL, :SINILT01-COD-CLIENTE, :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-TIPO-PESSOA, :SINILT01-COD-LOT-FENAL, :SINILT01-COD-LOT-CEF, :SINILT01-COD-COBERTURA, :SIMOLOT1-VALOR-INFORMADO, :SIMOLOT1-VALOR-REGISTRADO, :SIMOLOT1-VAL-IS, :SIMOLOT1-DATA-AVISO, :SIMOLOT1-VAL-ADIANTAMENTO END-EXEC. */

            if (INDENIZACOES.Fetch())
            {
                _.Move(INDENIZACOES.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(INDENIZACOES.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(INDENIZACOES.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(INDENIZACOES.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(INDENIZACOES.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(INDENIZACOES.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(INDENIZACOES.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(INDENIZACOES.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(INDENIZACOES.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(INDENIZACOES.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(INDENIZACOES.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(INDENIZACOES.SINILT01_COD_CLIENTE, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_CLIENTE);
                _.Move(INDENIZACOES.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(INDENIZACOES.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(INDENIZACOES.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(INDENIZACOES.SINILT01_COD_LOT_FENAL, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL);
                _.Move(INDENIZACOES.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
                _.Move(INDENIZACOES.SINILT01_COD_COBERTURA, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA);
                _.Move(INDENIZACOES.SIMOLOT1_VALOR_INFORMADO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO);
                _.Move(INDENIZACOES.SIMOLOT1_VALOR_REGISTRADO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_REGISTRADO);
                _.Move(INDENIZACOES.SIMOLOT1_VAL_IS, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_IS);
                _.Move(INDENIZACOES.SIMOLOT1_DATA_AVISO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO);
                _.Move(INDENIZACOES.SIMOLOT1_VAL_ADIANTAMENTO, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_ADIANTAMENTO);
            }

        }

        [StopWatch]
        /*" R021-FETCH-PAGAMENTOS-DB-CLOSE-1 */
        public void R021_FETCH_PAGAMENTOS_DB_CLOSE_1()
        {
            /*" -703- EXEC SQL CLOSE INDENIZACOES END-EXEC */

            INDENIZACOES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-PAGAMENTOS */
        private void R100_PROCESSA_PAGAMENTOS(bool isPerform = false)
        {
            /*" -712- MOVE SINISHIS-DATA-MOVIMENTO TO W-DATA-AAAA-MM-DD. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, W_ARQUIVO.W_DATA_AAAA_MM_DD);

            /*" -713- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -714- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -715- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -718- MOVE W-DATA-DD-MM-AAAA1 TO LD01-DATA-MVTO. */
            _.Move(W_ARQUIVO.W_DATA_DD_MM_AAAA1, W_ARQUIVO.LD01.LD01_DATA_MVTO);

            /*" -719- PERFORM R105-BUSCA-SINISTRO-PREST THRU R105-EXIT. */

            R105_BUSCA_SINISTRO_PREST(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/


            /*" -722- MOVE SIMOLOT1-NUM-SINI-PREST TO LD01-SINISTRO-PREST. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_SINI_PREST, W_ARQUIVO.LD01.LD01_SINISTRO_PREST);

            /*" -724- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD01-SINISTRO-SEG. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_ARQUIVO.LD01.LD01_SINISTRO_SEG);

            /*" -725- MOVE SINILT01-COD-LOT-CEF TO LD01-COD-LOTERICO. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, W_ARQUIVO.LD01.LD01_COD_LOTERICO);

            /*" -727- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-LOTERICO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, W_ARQUIVO.LD01.LD01_NOME_LOTERICO);

            /*" -728- INITIALIZE DCLLOTERICO01 */
            _.Initialize(
                LOTERI01.DCLLOTERICO01
            );

            /*" -730- PERFORM R210-TELEFONE-TAB-LOTERICO01 THRU R210-EXIT. */

            R210_TELEFONE_TAB_LOTERICO01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -731- MOVE LOTERI01-DDD TO LD01-DDD */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DDD, W_ARQUIVO.LD01.LD01_DDD);

            /*" -733- MOVE LOTERI01-NUM-FONE TO LD01-TELEFONE. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE, W_ARQUIVO.LD01.LD01_TELEFONE);

            /*" -734- MOVE SINISMES-DATA-OCORRENCIA TO W-DATA-AAAA-MM-DD. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, W_ARQUIVO.W_DATA_AAAA_MM_DD);

            /*" -735- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -736- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -737- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -739- MOVE W-DATA-DD-MM-AAAA1 TO LD01-DATA-OCORRENCIA */
            _.Move(W_ARQUIVO.W_DATA_DD_MM_AAAA1, W_ARQUIVO.LD01.LD01_DATA_OCORRENCIA);

            /*" -740- MOVE SIMOLOT1-DATA-AVISO TO W-DATA-AAAA-MM-DD */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO, W_ARQUIVO.W_DATA_AAAA_MM_DD);

            /*" -741- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -742- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -743- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -745- MOVE W-DATA-DD-MM-AAAA1 TO LD01-DATA-AVISO */
            _.Move(W_ARQUIVO.W_DATA_DD_MM_AAAA1, W_ARQUIVO.LD01.LD01_DATA_AVISO);

            /*" -747- MOVE SINISCAU-DESCR-CAUSA TO LD01-CAUSA-SINISTRO */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W_ARQUIVO.LD01.LD01_CAUSA_SINISTRO);

            /*" -753- PERFORM R220-MONTA-TIPO-MOVIMENTO THRU R220-EXIT. */

            R220_MONTA_TIPO_MOVIMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/


            /*" -760- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB LD01-AGENCIA LD01-CONTA LD01-DV. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, W_ARQUIVO.LD01.LD01_AGENCIA, W_ARQUIVO.LD01.LD01_CONTA, W_ARQUIVO.LD01.LD01_DV);

            /*" -762- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-ENVIO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);

            /*" -764- IF (SINILT01-COD-COBERTURA EQUAL 4 OR 2) AND (SINISHIS-VAL-OPERACAO NOT EQUAL 0) */

            if ((SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA.In("4", "2")) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO != 0))
            {

                /*" -765- PERFORM R120-ACESSA-CONTA-MOVDEBCC THRU R120-EXIT */

                R120_ACESSA_CONTA_MOVDEBCC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -766- MOVE MOVDEBCE-COD-AGENCIA-DEB TO LD01-AGENCIA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, W_ARQUIVO.LD01.LD01_AGENCIA);

                /*" -767- MOVE MOVDEBCE-NUM-CONTA-DEB TO LD01-CONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, W_ARQUIVO.LD01.LD01_CONTA);

                /*" -775- MOVE MOVDEBCE-DIG-CONTA-DEB TO LD01-DV. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, W_ARQUIVO.LD01.LD01_DV);
            }


            /*" -777- MOVE SISTEMAS-DATA-MOV-ABERTO TO CALENDAR-DATA-CALENDARIO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -778- IF SINISHIS-SIT-CONTABIL EQUAL '2' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "2")
            {

                /*" -780- MOVE 'CREDITO / DEBITO EM CONTA CORRENTE' TO LD01-FORMA-PAGAMENTO */
                _.Move("CREDITO / DEBITO EM CONTA CORRENTE", W_ARQUIVO.LD01.LD01_FORMA_PAGAMENTO);

                /*" -782- MOVE MOVDEBCE-DATA-ENVIO TO CALENDAR-DATA-CALENDARIO. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


            /*" -784- PERFORM R110-CALCULA-PROX-DIA-UTIL THRU R110-EXIT. */

            R110_CALCULA_PROX_DIA_UTIL(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -785- MOVE CALENDAR-DATA-CALENDARIO TO W-DATA-AAAA-MM-DD */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, W_ARQUIVO.W_DATA_AAAA_MM_DD);

            /*" -786- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -787- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -788- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -791- MOVE W-DATA-DD-MM-AAAA1 TO LD01-DATA-ENVIO. */
            _.Move(W_ARQUIVO.W_DATA_DD_MM_AAAA1, W_ARQUIVO.LD01.LD01_DATA_ENVIO);

            /*" -792- IF SINISHIS-SIT-CONTABIL EQUAL '1' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "1")
            {

                /*" -793- MOVE CALENDAR-DATA-CALENDARIO TO W-DATA-AAAA-MM-DD */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, W_ARQUIVO.W_DATA_AAAA_MM_DD);

                /*" -794- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
                _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

                /*" -795- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
                _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

                /*" -796- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
                _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

                /*" -797- MOVE W-DATA-DD-MM-AAAA1 TO LD01-DATA-DEB-CRED */
                _.Move(W_ARQUIVO.W_DATA_DD_MM_AAAA1, W_ARQUIVO.LD01.LD01_DATA_DEB_CRED);

                /*" -798- ELSE */
            }
            else
            {


                /*" -799- IF SINISHIS-SIT-CONTABIL EQUAL '2' */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "2")
                {

                    /*" -800- MOVE MOVDEBCE-DATA-VENCIMENTO TO W-DATA-AAAA-MM-DD */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, W_ARQUIVO.W_DATA_AAAA_MM_DD);

                    /*" -801- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
                    _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

                    /*" -802- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
                    _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

                    /*" -803- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
                    _.Move(W_ARQUIVO.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W_ARQUIVO.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

                    /*" -804- MOVE W-DATA-DD-MM-AAAA1 TO LD01-DATA-DEB-CRED */
                    _.Move(W_ARQUIVO.W_DATA_DD_MM_AAAA1, W_ARQUIVO.LD01.LD01_DATA_DEB_CRED);

                    /*" -805- ELSE */
                }
                else
                {


                    /*" -807- DISPLAY 'SITUACAO CONTABIL DIFERENTE DE 1 E 2 ' SINISHIS-SIT-CONTABIL */
                    _.Display($"SITUACAO CONTABIL DIFERENTE DE 1 E 2 {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL}");

                    /*" -809- GO TO M-999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -810- MOVE SIMOLOT1-VAL-IS TO LD01-VAL-IMP-SEGURADA. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_IS, W_ARQUIVO.LD01.LD01_VAL_IMP_SEGURADA);

            /*" -811- MOVE SIMOLOT1-VALOR-INFORMADO TO LD01-VAL-AVISADO. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO, W_ARQUIVO.LD01.LD01_VAL_AVISADO);

            /*" -813- MOVE SIMOLOT1-VALOR-REGISTRADO TO LD01-VAL-REGISTRADO. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_REGISTRADO, W_ARQUIVO.LD01.LD01_VAL_REGISTRADO);

            /*" -814- IF SINISHIS-COD-OPERACAO EQUAL 1030 OR 1040 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1030", "1040"))
            {

                /*" -815- PERFORM R135-VALOR-ESTORNADO THRU R135-EXIT */

                R135_VALOR_ESTORNADO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R135_EXIT*/


                /*" -816- ELSE */
            }
            else
            {


                /*" -817- PERFORM R130-VALOR-APURADO THRU R130-EXIT. */

                R130_VALOR_APURADO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

            }


            /*" -819- MOVE HOST-VALOR-APURADO TO LD01-VAL-REGULADO. */
            _.Move(HOST_VALOR_APURADO, W_ARQUIVO.LD01.LD01_VAL_REGULADO);

            /*" -821- PERFORM R140-CALCULA-VALORES THRU R140-EXIT. */

            R140_CALCULA_VALORES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/


            /*" -822- PERFORM R180-VALOR-INDENIZACAO THRU R180-EXIT. */

            R180_VALOR_INDENIZACAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R180_EXIT*/


            /*" -824- MOVE HOST-VALOR-INDENIZACAO TO LD01-VAL-INDENIZACAO. */
            _.Move(HOST_VALOR_INDENIZACAO, W_ARQUIVO.LD01.LD01_VAL_INDENIZACAO);

            /*" -825- IF SINILT01-COD-COBERTURA EQUAL 4 OR 2 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA.In("4", "2"))
            {

                /*" -826- PERFORM R190-VALOR-ADIANTAMENTO THRU R190-EXIT */

                R190_VALOR_ADIANTAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R190_EXIT*/


                /*" -828- MOVE HOST-VALOR-ADIANTAMENTO TO LD01-VAL-ADIANTAMENTO */
                _.Move(HOST_VALOR_ADIANTAMENTO, W_ARQUIVO.LD01.LD01_VAL_ADIANTAMENTO);

                /*" -829- PERFORM R200-VALOR-DIFERENCA THRU R200-EXIT */

                R200_VALOR_DIFERENCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


                /*" -830- MOVE HOST-VALOR-DIFERENCA TO LD01-VAL-DIF-INDEN */
                _.Move(HOST_VALOR_DIFERENCA, W_ARQUIVO.LD01.LD01_VAL_DIF_INDEN);

                /*" -833- MOVE 'CREDITO / DEBITO EM CONTA CORRENTE' TO LD01-FORMA-PAGAMENTO. */
                _.Move("CREDITO / DEBITO EM CONTA CORRENTE", W_ARQUIVO.LD01.LD01_FORMA_PAGAMENTO);
            }


            /*" -834- IF HOST-VALOR-DIFERENCA < ZERO */

            if (HOST_VALOR_DIFERENCA < 00)
            {

                /*" -835- MOVE 'DEBITO NA C/C' TO LD01-MOVIMENTO-CONTA */
                _.Move("DEBITO NA C/C", W_ARQUIVO.LD01.LD01_MOVIMENTO_CONTA);

                /*" -836- ELSE */
            }
            else
            {


                /*" -838- MOVE 'CREDITO NA C/C' TO LD01-MOVIMENTO-CONTA. */
                _.Move("CREDITO NA C/C", W_ARQUIVO.LD01.LD01_MOVIMENTO_CONTA);
            }


            /*" -840- IF SINILT01-COD-COBERTURA NOT EQUAL 4 AND SINILT01-COD-COBERTURA NOT EQUAL 2 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA != 4 && SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA != 2)
            {

                /*" -843- MOVE ZEROS TO LD01-VAL-ADIANTAMENTO LD01-VAL-DIF-INDEN. */
                _.Move(0, W_ARQUIVO.LD01.LD01_VAL_ADIANTAMENTO, W_ARQUIVO.LD01.LD01_VAL_DIF_INDEN);
            }


            /*" -845- PERFORM R1000-GRAVA-ARQUIVO THRU R1000-EXIT. */

            R1000_GRAVA_ARQUIVO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


            /*" -845- PERFORM R021-FETCH-PAGAMENTOS THRU R021-EXIT. */

            R021_FETCH_PAGAMENTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R105-BUSCA-SINISTRO-PREST */
        private void R105_BUSCA_SINISTRO_PREST(bool isPerform = false)
        {
            /*" -854- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WNR_EXEC_SQL);

            /*" -859- PERFORM R105_BUSCA_SINISTRO_PREST_DB_SELECT_1 */

            R105_BUSCA_SINISTRO_PREST_DB_SELECT_1();

            /*" -862- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -863- DISPLAY 'SI0869B - ERRO NA BUSCA DO SINISTRO DA PREST...' */
                _.Display($"SI0869B - ERRO NA BUSCA DO SINISTRO DA PREST...");

                /*" -864- DISPLAY 'SINISTRO     = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -864- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R105-BUSCA-SINISTRO-PREST-DB-SELECT-1 */
        public void R105_BUSCA_SINISTRO_PREST_DB_SELECT_1()
        {
            /*" -859- EXEC SQL SELECT NUM_SINI_PREST INTO :SIMOLOT1-NUM-SINI-PREST FROM SEGUROS.SI_MOV_LOTERICO1 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1 = new R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1.Execute(r105_BUSCA_SINISTRO_PREST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOLOT1_NUM_SINI_PREST, SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_NUM_SINI_PREST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R105_EXIT*/

        [StopWatch]
        /*" R110-CALCULA-PROX-DIA-UTIL */
        private void R110_CALCULA_PROX_DIA_UTIL(bool isPerform = false)
        {
            /*" -873- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WNR_EXEC_SQL);

            /*" -884- PERFORM R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1 */

            R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1();

            /*" -887- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -888- DISPLAY 'SI0869B - ERRO CALCULO PROX DIA UTIL ..........' */
                _.Display($"SI0869B - ERRO CALCULO PROX DIA UTIL ..........");

                /*" -889- DISPLAY 'DATA SISTEMA=' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA SISTEMA={SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -890- DISPLAY 'DATA-CALENDARIO=' CALENDAR-DATA-CALENDARIO */
                _.Display($"DATA-CALENDARIO={CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

                /*" -890- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R110-CALCULA-PROX-DIA-UTIL-DB-SELECT-1 */
        public void R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1()
        {
            /*" -884- EXEC SQL SELECT MIN(DATA_CALENDARIO) INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO <= (SELECT DATA_CALENDARIO + 1 MONTH FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO) AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO = ' ' AND DATA_CALENDARIO > :CALENDAR-DATA-CALENDARIO END-EXEC. */

            var r110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1 = new R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1.Execute(r110_CALCULA_PROX_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-ACESSA-CONTA-MOVDEBCC */
        private void R120_ACESSA_CONTA_MOVDEBCC(bool isPerform = false)
        {
            /*" -899- MOVE SINISHIS-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -900- MOVE ZEROS TO W-PRODUTO-OPERACAO. */
            _.Move(0, W_ARQUIVO.W_PRODUTO_OPERACAO);

            /*" -902- MOVE SINISHIS-COD-PRODUTO TO W-PRODUTO-OPERACAO-PRODUTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, W_ARQUIVO.FILLER_122.W_PRODUTO_OPERACAO_PRODUTO);

            /*" -903- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO-SICOV */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO_SICOV);

            /*" -906- MOVE HOST-COD-OPERACAO-SICOV TO W-PRODUTO-OPERACAO-OPERACAO */
            _.Move(HOST_COD_OPERACAO_SICOV, W_ARQUIVO.FILLER_122.W_PRODUTO_OPERACAO_OPERACAO);

            /*" -907- MOVE SINISHIS-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -908- MOVE W-PRODUTO-OPERACAO TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(W_ARQUIVO.W_PRODUTO_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -910- MOVE SINISHIS-OCORR-HISTORICO TO MOVDEBCE-NUM-PARCELA */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -912- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WNR_EXEC_SQL);

            /*" -934- PERFORM R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1 */

            R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1();

            /*" -937- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -938- DISPLAY 'SI0869B - ERRO ACESSO MOVTO_DEBITOCC_CEF  (1)..' */
                _.Display($"SI0869B - ERRO ACESSO MOVTO_DEBITOCC_CEF  (1)..");

                /*" -939- DISPLAY 'NUM_APOLICE        = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE        = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -940- DISPLAY 'NUM_ENDOSSO        = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO        = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -941- DISPLAY 'NUM_PARCELA        = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA        = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -942- DISPLAY 'SQLCODE            = ' SQLCODE */
                _.Display($"SQLCODE            = {DB.SQLCODE}");

                /*" -942- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-ACESSA-CONTA-MOVDEBCC-DB-SELECT-1 */
        public void R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1()
        {
            /*" -934- EXEC SQL SELECT M.COD_AGENCIA_DEB, M.OPER_CONTA_DEB, M.NUM_CONTA_DEB, M.DIG_CONTA_DEB, VALUE(M.DATA_ENVIO,:SISTEMAS-DATA-MOV-ABERTO), M.DATA_VENCIMENTO INTO :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-DATA-ENVIO, :MOVDEBCE-DATA-VENCIMENTO FROM SEGUROS.MOVTO_DEBITOCC_CEF M WHERE M.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND M.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND M.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND M.NSAS = (SELECT MAX(X.NSAS) FROM SEGUROS.MOVTO_DEBITOCC_CEF X WHERE X.NUM_APOLICE = M.NUM_APOLICE AND X.NUM_ENDOSSO = M.NUM_ENDOSSO AND X.NUM_PARCELA = M.NUM_PARCELA) END-EXEC. */

            var r120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1 = new R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1.Execute(r120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-VALOR-APURADO */
        private void R130_VALOR_APURADO(bool isPerform = false)
        {
            /*" -950- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WNR_EXEC_SQL);

            /*" -951- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -953- ADD 110 TO HOST-COD-OPERACAO. */
            HOST_COD_OPERACAO.Value = HOST_COD_OPERACAO + 110;

            /*" -960- PERFORM R130_VALOR_APURADO_DB_SELECT_1 */

            R130_VALOR_APURADO_DB_SELECT_1();

            /*" -963- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -964- DISPLAY 'ERRO ACESSO A PRE-LIBERACAO ...................' */
                _.Display($"ERRO ACESSO A PRE-LIBERACAO ...................");

                /*" -965- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -966- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -967- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -967- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R130-VALOR-APURADO-DB-SELECT-1 */
        public void R130_VALOR_APURADO_DB_SELECT_1()
        {
            /*" -960- EXEC SQL SELECT VAL_OPERACAO INTO :HOST-VALOR-APURADO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :HOST-COD-OPERACAO END-EXEC. */

            var r130_VALOR_APURADO_DB_SELECT_1_Query1 = new R130_VALOR_APURADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                HOST_COD_OPERACAO = HOST_COD_OPERACAO.ToString(),
            };

            var executed_1 = R130_VALOR_APURADO_DB_SELECT_1_Query1.Execute(r130_VALOR_APURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_APURADO, HOST_VALOR_APURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R135-VALOR-ESTORNADO */
        private void R135_VALOR_ESTORNADO(bool isPerform = false)
        {
            /*" -976- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WNR_EXEC_SQL);

            /*" -982- PERFORM R135_VALOR_ESTORNADO_DB_SELECT_1 */

            R135_VALOR_ESTORNADO_DB_SELECT_1();

            /*" -985- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -986- DISPLAY 'ERRO ACESSO A SINISTRO_HISTORICO...............' */
                _.Display($"ERRO ACESSO A SINISTRO_HISTORICO...............");

                /*" -987- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -988- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -989- DISPLAY 'COD_OPERACAO       = ' SINISHIS-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -989- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R135-VALOR-ESTORNADO-DB-SELECT-1 */
        public void R135_VALOR_ESTORNADO_DB_SELECT_1()
        {
            /*" -982- EXEC SQL SELECT VALUE(SUM(VAL_OPERACAO),0) INTO :HOST-VALOR-APURADO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */

            var r135_VALOR_ESTORNADO_DB_SELECT_1_Query1 = new R135_VALOR_ESTORNADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R135_VALOR_ESTORNADO_DB_SELECT_1_Query1.Execute(r135_VALOR_ESTORNADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_APURADO, HOST_VALOR_APURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R135_EXIT*/

        [StopWatch]
        /*" R140-CALCULA-VALORES */
        private void R140_CALCULA_VALORES(bool isPerform = false)
        {
            /*" -998- MOVE 'NAO' TO WFIM-CURSOR-RETENCOES. */
            _.Move("NAO", W_ARQUIVO.WFIM_CURSOR_RETENCOES);

            /*" -1000- PERFORM R150-DECLARE-CURSOR-RETENCAO THRU R150-EXIT. */

            R150_DECLARE_CURSOR_RETENCAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/


            /*" -1002- PERFORM R160-FETCH-CURSOR-RETENCAO THRU R160-EXIT. */

            R160_FETCH_CURSOR_RETENCAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


            /*" -1013- MOVE ZEROS TO LD01-VAL-FRANQUIA LD01-VAL-FRANQUIA-MIN LD01-PER-FRANQUIA LD01-QTD-SINI-PAG LD01-VAL-FRANQ-CALC LD01-VAL-REINTEGRACAO LD01-VAL-IOF-REINT LD01-VAL-AGRAVAMENTO LD01-PER-AGRAVAMENTO LD01-VAL-IOF-AGRAV. */
            _.Move(0, W_ARQUIVO.LD01.LD01_VAL_FRANQUIA, W_ARQUIVO.LD01.LD01_VAL_FRANQUIA_MIN, W_ARQUIVO.LD01.LD01_PER_FRANQUIA, W_ARQUIVO.LD01.LD01_QTD_SINI_PAG, W_ARQUIVO.LD01.LD01_VAL_FRANQ_CALC, W_ARQUIVO.LD01.LD01_VAL_REINTEGRACAO, W_ARQUIVO.LD01.LD01_VAL_IOF_REINT, W_ARQUIVO.LD01.LD01_VAL_AGRAVAMENTO, W_ARQUIVO.LD01.LD01_PER_AGRAVAMENTO, W_ARQUIVO.LD01.LD01_VAL_IOF_AGRAV);

            /*" -1014- PERFORM R170-TRATA-RETENCOES THRU R170-EXIT UNTIL WFIM-CURSOR-RETENCOES EQUAL 'SIM' . */

            while (!(W_ARQUIVO.WFIM_CURSOR_RETENCOES == "SIM"))
            {

                R170_TRATA_RETENCOES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/

        [StopWatch]
        /*" R150-DECLARE-CURSOR-RETENCAO */
        private void R150_DECLARE_CURSOR_RETENCAO(bool isPerform = false)
        {
            /*" -1023- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WNR_EXEC_SQL);

            /*" -1043- PERFORM R150_DECLARE_CURSOR_RETENCAO_DB_DECLARE_1 */

            R150_DECLARE_CURSOR_RETENCAO_DB_DECLARE_1();

            /*" -1047- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WNR_EXEC_SQL);

            /*" -1047- PERFORM R150_DECLARE_CURSOR_RETENCAO_DB_OPEN_1 */

            R150_DECLARE_CURSOR_RETENCAO_DB_OPEN_1();

            /*" -1050- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1051- DISPLAY 'ERRO OPEN RETENCOES ...................... ' */
                _.Display($"ERRO OPEN RETENCOES ...................... ");

                /*" -1052- DISPLAY 'PODE TER SIDO CAUSADO POR LOCK NA TABELA   ' */
                _.Display($"PODE TER SIDO CAUSADO POR LOCK NA TABELA   ");

                /*" -1053- DISPLAY 'FAVOR VERIFICAR E ME LIGAR.    HEIDER      ' */
                _.Display($"FAVOR VERIFICAR E ME LIGAR.    HEIDER      ");

                /*" -1053- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R150-DECLARE-CURSOR-RETENCAO-DB-OPEN-1 */
        public void R150_DECLARE_CURSOR_RETENCAO_DB_OPEN_1()
        {
            /*" -1047- EXEC SQL OPEN RETENCOES END-EXEC. */

            RETENCOES.Open();

        }

        [StopWatch]
        /*" R210-TELEFONE-TAB-LOTERICO01-DB-DECLARE-1 */
        public void R210_TELEFONE_TAB_LOTERICO01_DB_DECLARE_1()
        {
            /*" -1223- EXEC SQL DECLARE LOTERICO CURSOR FOR SELECT DDD, NUM_FONE, MAX(DTTERVIG) FROM SEGUROS.LOTERICO01 WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE AND COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL AND DTTERVIG = (SELECT MAX(DTTERVIG) FROM SEGUROS.LOTERICO01 WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE AND COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL) GROUP BY DDD, NUM_FONE ORDER BY NUM_FONE END-EXEC. */
            LOTERICO = new SI0869B_LOTERICO(true);
            string GetQuery_LOTERICO()
            {
                var query = @$"SELECT DDD
							, 
							NUM_FONE
							, 
							MAX(DTTERVIG) 
							FROM SEGUROS.LOTERICO01 
							WHERE NUM_APOLICE = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}' 
							AND COD_LOT_FENAL = '{SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}' 
							AND DTTERVIG =
							(SELECT  MAX(DTTERVIG) 
							FROM SEGUROS.LOTERICO01 
							WHERE NUM_APOLICE = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}' 
							AND COD_LOT_FENAL = '{SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}') 
							GROUP BY DDD
							, 
							NUM_FONE 
							ORDER BY NUM_FONE";

                return query;
            }
            LOTERICO.GetQueryEvent += GetQuery_LOTERICO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/

        [StopWatch]
        /*" R160-FETCH-CURSOR-RETENCAO */
        private void R160_FETCH_CURSOR_RETENCAO(bool isPerform = false)
        {
            /*" -1062- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WNR_EXEC_SQL);

            /*" -1070- PERFORM R160_FETCH_CURSOR_RETENCAO_DB_FETCH_1 */

            R160_FETCH_CURSOR_RETENCAO_DB_FETCH_1();

            /*" -1073- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1074- DISPLAY 'ERRO FETCH DO CURSOR RETENCOES ...........' */
                _.Display($"ERRO FETCH DO CURSOR RETENCOES ...........");

                /*" -1076- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1077- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1077- PERFORM R160_FETCH_CURSOR_RETENCAO_DB_CLOSE_1 */

                R160_FETCH_CURSOR_RETENCAO_DB_CLOSE_1();

                /*" -1078- MOVE 'SIM' TO WFIM-CURSOR-RETENCOES. */
                _.Move("SIM", W_ARQUIVO.WFIM_CURSOR_RETENCOES);
            }


        }

        [StopWatch]
        /*" R160-FETCH-CURSOR-RETENCAO-DB-FETCH-1 */
        public void R160_FETCH_CURSOR_RETENCAO_DB_FETCH_1()
        {
            /*" -1070- EXEC SQL FETCH RETENCOES INTO :SINLOAB2-VALOR-RETENCAO, :SINLOAB2-VLR-RETENCAO-CALC, :SINLOAB2-IND-VLR-RETENCAO, :SINLOAB2-PERCENT-RETENCAO, :SINLOAB2-COD-RETENCAO, :SINLOAB2-QTD-SINISTRO-PAGO END-EXEC. */

            if (RETENCOES.Fetch())
            {
                _.Move(RETENCOES.SINLOAB2_VALOR_RETENCAO, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO);
                _.Move(RETENCOES.SINLOAB2_VLR_RETENCAO_CALC, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VLR_RETENCAO_CALC);
                _.Move(RETENCOES.SINLOAB2_IND_VLR_RETENCAO, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_IND_VLR_RETENCAO);
                _.Move(RETENCOES.SINLOAB2_PERCENT_RETENCAO, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_PERCENT_RETENCAO);
                _.Move(RETENCOES.SINLOAB2_COD_RETENCAO, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_COD_RETENCAO);
                _.Move(RETENCOES.SINLOAB2_QTD_SINISTRO_PAGO, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_QTD_SINISTRO_PAGO);
            }

        }

        [StopWatch]
        /*" R160-FETCH-CURSOR-RETENCAO-DB-CLOSE-1 */
        public void R160_FETCH_CURSOR_RETENCAO_DB_CLOSE_1()
        {
            /*" -1077- EXEC SQL CLOSE RETENCOES END-EXEC */

            RETENCOES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/

        [StopWatch]
        /*" R170-TRATA-RETENCOES */
        private void R170_TRATA_RETENCOES(bool isPerform = false)
        {
            /*" -1086- IF SINLOAB2-COD-RETENCAO EQUAL 1 */

            if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_COD_RETENCAO == 1)
            {

                /*" -1087- MULTIPLY -1 BY SINLOAB2-VALOR-RETENCAO */
                _.Multiply(-1, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO);

                /*" -1088- MOVE SINLOAB2-PERCENT-RETENCAO TO LD01-PER-FRANQUIA */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_PERCENT_RETENCAO, W_ARQUIVO.LD01.LD01_PER_FRANQUIA);

                /*" -1089- MOVE SINLOAB2-VALOR-RETENCAO TO LD01-VAL-FRANQUIA */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO, W_ARQUIVO.LD01.LD01_VAL_FRANQUIA);

                /*" -1090- MOVE SINLOAB2-VLR-RETENCAO-CALC TO LD01-VAL-FRANQ-CALC */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VLR_RETENCAO_CALC, W_ARQUIVO.LD01.LD01_VAL_FRANQ_CALC);

                /*" -1091- ADD 1 TO SINLOAB2-QTD-SINISTRO-PAGO */
                SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_QTD_SINISTRO_PAGO.Value = SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_QTD_SINISTRO_PAGO + 1;

                /*" -1092- MOVE SINLOAB2-QTD-SINISTRO-PAGO TO LD01-QTD-SINI-PAG */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_QTD_SINISTRO_PAGO, W_ARQUIVO.LD01.LD01_QTD_SINI_PAG);

                /*" -1093- IF SINLOAB2-IND-VLR-RETENCAO EQUAL '0' */

                if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_IND_VLR_RETENCAO == "0")
                {

                    /*" -1094- MOVE ZEROS TO LD01-VAL-FRANQUIA-MIN */
                    _.Move(0, W_ARQUIVO.LD01.LD01_VAL_FRANQUIA_MIN);

                    /*" -1095- ELSE */
                }
                else
                {


                    /*" -1096- IF SINLOAB2-IND-VLR-RETENCAO EQUAL '1' */

                    if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_IND_VLR_RETENCAO == "1")
                    {

                        /*" -1097- MOVE SINLOAB2-VALOR-RETENCAO TO LD01-VAL-FRANQUIA-MIN */
                        _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO, W_ARQUIVO.LD01.LD01_VAL_FRANQUIA_MIN);

                        /*" -1098- ELSE */
                    }
                    else
                    {


                        /*" -1099- DISPLAY 'ERRO IMPREVISTO DO IND-VLR-RETENCAO' */
                        _.Display($"ERRO IMPREVISTO DO IND-VLR-RETENCAO");

                        /*" -1101- GO TO M-999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO(); //GOTO
                        return;
                    }

                }

            }


            /*" -1102- IF SINLOAB2-COD-RETENCAO EQUAL 2 */

            if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_COD_RETENCAO == 2)
            {

                /*" -1103- MULTIPLY -1 BY SINLOAB2-VALOR-RETENCAO */
                _.Multiply(-1, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO);

                /*" -1105- MOVE SINLOAB2-VALOR-RETENCAO TO LD01-VAL-REINTEGRACAO. */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO, W_ARQUIVO.LD01.LD01_VAL_REINTEGRACAO);
            }


            /*" -1106- IF SINLOAB2-COD-RETENCAO EQUAL 3 */

            if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_COD_RETENCAO == 3)
            {

                /*" -1107- MULTIPLY -1 BY SINLOAB2-VALOR-RETENCAO */
                _.Multiply(-1, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO);

                /*" -1109- MOVE SINLOAB2-VALOR-RETENCAO TO LD01-VAL-IOF-REINT. */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO, W_ARQUIVO.LD01.LD01_VAL_IOF_REINT);
            }


            /*" -1110- IF SINLOAB2-COD-RETENCAO EQUAL 5 */

            if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_COD_RETENCAO == 5)
            {

                /*" -1111- MULTIPLY -1 BY SINLOAB2-VALOR-RETENCAO */
                _.Multiply(-1, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO);

                /*" -1112- MOVE SINLOAB2-VALOR-RETENCAO TO LD01-VAL-AGRAVAMENTO */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO, W_ARQUIVO.LD01.LD01_VAL_AGRAVAMENTO);

                /*" -1114- MOVE SINLOAB2-PERCENT-RETENCAO TO LD01-PER-AGRAVAMENTO. */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_PERCENT_RETENCAO, W_ARQUIVO.LD01.LD01_PER_AGRAVAMENTO);
            }


            /*" -1115- IF SINLOAB2-COD-RETENCAO EQUAL 6 */

            if (SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_COD_RETENCAO == 6)
            {

                /*" -1116- MULTIPLY -1 BY SINLOAB2-VALOR-RETENCAO */
                _.Multiply(-1, SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO);

                /*" -1121- MOVE SINLOAB2-VALOR-RETENCAO TO LD01-VAL-IOF-AGRAV. */
                _.Move(SINLOAB2.DCLSINI_LOT_ABAT02.SINLOAB2_VALOR_RETENCAO, W_ARQUIVO.LD01.LD01_VAL_IOF_AGRAV);
            }


            /*" -1121- PERFORM R160-FETCH-CURSOR-RETENCAO THRU R160-EXIT. */

            R160_FETCH_CURSOR_RETENCAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

        [StopWatch]
        /*" R180-VALOR-INDENIZACAO */
        private void R180_VALOR_INDENIZACAO(bool isPerform = false)
        {
            /*" -1129- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", WNR_EXEC_SQL);

            /*" -1132- MOVE ZEROS TO HOST-VALOR-INDENIZACAO LD01-VAL-INDENIZACAO. */
            _.Move(0, HOST_VALOR_INDENIZACAO, W_ARQUIVO.LD01.LD01_VAL_INDENIZACAO);

            /*" -1132- MOVE SINISHIS-VAL-OPERACAO TO HOST-VALOR-INDENIZACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, HOST_VALOR_INDENIZACAO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R180_EXIT*/

        [StopWatch]
        /*" R190-VALOR-ADIANTAMENTO */
        private void R190_VALOR_ADIANTAMENTO(bool isPerform = false)
        {
            /*" -1155- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", WNR_EXEC_SQL);

            /*" -1157- MOVE ZEROS TO HOST-VALOR-ADIANTAMENTO LD01-VAL-ADIANTAMENTO. */
            _.Move(0, HOST_VALOR_ADIANTAMENTO, W_ARQUIVO.LD01.LD01_VAL_ADIANTAMENTO);

            /*" -1159- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1166- PERFORM R190_VALOR_ADIANTAMENTO_DB_SELECT_1 */

            R190_VALOR_ADIANTAMENTO_DB_SELECT_1();

            /*" -1169- IF SQLCODE NOT EQUAL ZERO AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1170- DISPLAY 'ERRO ACESSO AO ADIANTAMENTO ...................' */
                _.Display($"ERRO ACESSO AO ADIANTAMENTO ...................");

                /*" -1171- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1172- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1173- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1173- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R190-VALOR-ADIANTAMENTO-DB-SELECT-1 */
        public void R190_VALOR_ADIANTAMENTO_DB_SELECT_1()
        {
            /*" -1166- EXEC SQL SELECT VALUE(B.VAL_OPERACAO * -1,0) INTO :HOST-VALOR-ADIANTAMENTO FROM SEGUROS.SINISTRO_HISTORICO B WHERE B.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.COD_OPERACAO = 1070 END-EXEC. */

            var r190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1 = new R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1.Execute(r190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_ADIANTAMENTO, HOST_VALOR_ADIANTAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R190_EXIT*/

        [StopWatch]
        /*" R200-VALOR-DIFERENCA */
        private void R200_VALOR_DIFERENCA(bool isPerform = false)
        {
            /*" -1181- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WNR_EXEC_SQL);

            /*" -1183- MOVE ZEROS TO HOST-VALOR-DIFERENCA LD01-VAL-DIF-INDEN. */
            _.Move(0, HOST_VALOR_DIFERENCA, W_ARQUIVO.LD01.LD01_VAL_DIF_INDEN);

            /*" -1185- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1193- PERFORM R200_VALOR_DIFERENCA_DB_SELECT_1 */

            R200_VALOR_DIFERENCA_DB_SELECT_1();

            /*" -1196- IF SQLCODE NOT EQUAL ZERO AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1197- DISPLAY 'ERRO ACESSO A DIFERENCA DE INDENIZACAO.........' */
                _.Display($"ERRO ACESSO A DIFERENCA DE INDENIZACAO.........");

                /*" -1198- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1199- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1200- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1200- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R200-VALOR-DIFERENCA-DB-SELECT-1 */
        public void R200_VALOR_DIFERENCA_DB_SELECT_1()
        {
            /*" -1193- EXEC SQL SELECT VALUE(VAL_OPERACAO,0) INTO :HOST-VALOR-DIFERENCA FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :HOST-COD-OPERACAO AND SIT_REGISTRO <> '2' END-EXEC. */

            var r200_VALOR_DIFERENCA_DB_SELECT_1_Query1 = new R200_VALOR_DIFERENCA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                HOST_COD_OPERACAO = HOST_COD_OPERACAO.ToString(),
            };

            var executed_1 = R200_VALOR_DIFERENCA_DB_SELECT_1_Query1.Execute(r200_VALOR_DIFERENCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_DIFERENCA, HOST_VALOR_DIFERENCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R210-TELEFONE-TAB-LOTERICO01 */
        private void R210_TELEFONE_TAB_LOTERICO01(bool isPerform = false)
        {
            /*" -1208- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", WNR_EXEC_SQL);

            /*" -1223- PERFORM R210_TELEFONE_TAB_LOTERICO01_DB_DECLARE_1 */

            R210_TELEFONE_TAB_LOTERICO01_DB_DECLARE_1();

            /*" -1227- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", WNR_EXEC_SQL);

            /*" -1227- PERFORM R210_TELEFONE_TAB_LOTERICO01_DB_OPEN_1 */

            R210_TELEFONE_TAB_LOTERICO01_DB_OPEN_1();

            /*" -1230- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1231- DISPLAY 'ERRO OPEN LOTERICO ....................... ' */
                _.Display($"ERRO OPEN LOTERICO ....................... ");

                /*" -1232- DISPLAY 'PODE TER SIDO CAUSADO POR LOCK NA TABELA   ' */
                _.Display($"PODE TER SIDO CAUSADO POR LOCK NA TABELA   ");

                /*" -1233- DISPLAY 'FAVOR VERIFICAR E ME LIGAR.    HEIDER      ' */
                _.Display($"FAVOR VERIFICAR E ME LIGAR.    HEIDER      ");

                /*" -1235- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1240- PERFORM R210_TELEFONE_TAB_LOTERICO01_DB_FETCH_1 */

            R210_TELEFONE_TAB_LOTERICO01_DB_FETCH_1();

            /*" -1243- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1244- DISPLAY 'ERRO ACESSO AO TELEFONE (LOTERICO01)' */
                _.Display($"ERRO ACESSO AO TELEFONE (LOTERICO01)");

                /*" -1245- DISPLAY 'NUM_APOLICE        = ' SINISMES-NUM-APOLICE */
                _.Display($"NUM_APOLICE        = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1246- DISPLAY 'COD_LOT_FENAL      = ' SINILT01-COD-LOT-FENAL */
                _.Display($"COD_LOT_FENAL      = {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -1247- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1248- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1249- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1250- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1252- END-IF. */
            }


            /*" -1252- PERFORM R210_TELEFONE_TAB_LOTERICO01_DB_CLOSE_1 */

            R210_TELEFONE_TAB_LOTERICO01_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R210-TELEFONE-TAB-LOTERICO01-DB-OPEN-1 */
        public void R210_TELEFONE_TAB_LOTERICO01_DB_OPEN_1()
        {
            /*" -1227- EXEC SQL OPEN LOTERICO END-EXEC. */

            LOTERICO.Open();

        }

        [StopWatch]
        /*" R210-TELEFONE-TAB-LOTERICO01-DB-FETCH-1 */
        public void R210_TELEFONE_TAB_LOTERICO01_DB_FETCH_1()
        {
            /*" -1240- EXEC SQL FETCH LOTERICO INTO :LOTERI01-DDD, :LOTERI01-NUM-FONE, :LOTERI01-DTTERVIG END-EXEC. */

            if (LOTERICO.Fetch())
            {
                _.Move(LOTERICO.LOTERI01_DDD, LOTERI01.DCLLOTERICO01.LOTERI01_DDD);
                _.Move(LOTERICO.LOTERI01_NUM_FONE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE);
                _.Move(LOTERICO.LOTERI01_DTTERVIG, LOTERI01.DCLLOTERICO01.LOTERI01_DTTERVIG);
            }

        }

        [StopWatch]
        /*" R210-TELEFONE-TAB-LOTERICO01-DB-CLOSE-1 */
        public void R210_TELEFONE_TAB_LOTERICO01_DB_CLOSE_1()
        {
            /*" -1252- EXEC SQL CLOSE LOTERICO END-EXEC. */

            LOTERICO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R220-MONTA-TIPO-MOVIMENTO */
        private void R220_MONTA_TIPO_MOVIMENTO(bool isPerform = false)
        {
            /*" -1261- IF SINISHIS-COD-OPERACAO EQUAL 1071 OR 1072 OR 1073 OR 1074 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1071", "1072", "1073", "1074"))
            {

                /*" -1262- MOVE 'PAGAMENTO' TO LD01-TIPO-MOVIMENTO */
                _.Move("PAGAMENTO", W_ARQUIVO.LD01.LD01_TIPO_MOVIMENTO);

                /*" -1263- PERFORM R230-MONTA-TIPO-PAGAMENTO THRU R230-EXIT */

                R230_MONTA_TIPO_PAGAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R230_EXIT*/


                /*" -1264- ELSE */
            }
            else
            {


                /*" -1265- MOVE 'ESTORNO  ' TO LD01-TIPO-MOVIMENTO */
                _.Move("ESTORNO  ", W_ARQUIVO.LD01.LD01_TIPO_MOVIMENTO);

                /*" -1265- PERFORM R240-MONTA-TIPO-ESTORNO THRU R240-EXIT. */

                R240_MONTA_TIPO_ESTORNO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R240_EXIT*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/

        [StopWatch]
        /*" R230-MONTA-TIPO-PAGAMENTO */
        private void R230_MONTA_TIPO_PAGAMENTO(bool isPerform = false)
        {
            /*" -1274- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", WNR_EXEC_SQL);

            /*" -1280- PERFORM R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1 */

            R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1();

            /*" -1283- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1284- DISPLAY 'ERRO ACESSO A GE_OPERACAO .....................' */
                _.Display($"ERRO ACESSO A GE_OPERACAO .....................");

                /*" -1285- DISPLAY 'COD. OPERACAO  = ' SINISHIS-COD-OPERACAO */
                _.Display($"COD. OPERACAO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                /*" -1287- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1287- MOVE GEOPERAC-DES-OPERACAO TO LD01-TIPO-PAGAMENTO. */
            _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO, W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

        }

        [StopWatch]
        /*" R230-MONTA-TIPO-PAGAMENTO-DB-SELECT-1 */
        public void R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1()
        {
            /*" -1280- EXEC SQL SELECT DES_OPERACAO INTO :GEOPERAC-DES-OPERACAO FROM SEGUROS.GE_OPERACAO WHERE COD_OPERACAO = :SINISHIS-COD-OPERACAO AND IDE_SISTEMA = 'SI' END-EXEC. */

            var r230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1 = new R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1.Execute(r230_MONTA_TIPO_PAGAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R230_EXIT*/

        [StopWatch]
        /*" R240-MONTA-TIPO-ESTORNO */
        private void R240_MONTA_TIPO_ESTORNO(bool isPerform = false)
        {
            /*" -1296- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", WNR_EXEC_SQL);

            /*" -1303- PERFORM R240_MONTA_TIPO_ESTORNO_DB_SELECT_1 */

            R240_MONTA_TIPO_ESTORNO_DB_SELECT_1();

            /*" -1306- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1307- DISPLAY 'ERRO NO ACESSO A SINISTRO_HISTORICO............' */
                _.Display($"ERRO NO ACESSO A SINISTRO_HISTORICO............");

                /*" -1308- DISPLAY 'SINISTRO       = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO       = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1309- DISPLAY 'OCORHIST       = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST       = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1311- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1312- IF SINISHIS-COD-OPERACAO = 1030 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 1030)
            {

                /*" -1313- IF HOST-OPERACAO-EST EQUAL 1001 */

                if (HOST_OPERACAO_EST == 1001)
                {

                    /*" -1315- MOVE 'DE ADIANTAMENTO COM CANCEL DE SINISTRO' TO LD01-TIPO-PAGAMENTO */
                    _.Move("DE ADIANTAMENTO COM CANCEL DE SINISTRO", W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

                    /*" -1316- ELSE */
                }
                else
                {


                    /*" -1317- IF HOST-OPERACAO-EST EQUAL 1003 */

                    if (HOST_OPERACAO_EST == 1003)
                    {

                        /*" -1319- MOVE 'DE PAG TOTAL COM CANCEL.DE SINISTRO' TO LD01-TIPO-PAGAMENTO */
                        _.Move("DE PAG TOTAL COM CANCEL.DE SINISTRO", W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

                        /*" -1320- ELSE */
                    }
                    else
                    {


                        /*" -1322- MOVE 'DE PAG.COMPLEMENTAR C/CANCEL.DE SINISTRO' TO LD01-TIPO-PAGAMENTO */
                        _.Move("DE PAG.COMPLEMENTAR C/CANCEL.DE SINISTRO", W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

                        /*" -1323- END-IF */
                    }


                    /*" -1324- END-IF */
                }


                /*" -1325- ELSE */
            }
            else
            {


                /*" -1326- IF HOST-OPERACAO-EST EQUAL 1001 */

                if (HOST_OPERACAO_EST == 1001)
                {

                    /*" -1328- MOVE 'DE ADIANTAMENTO SEM CANCEL DE SINISTRO' TO LD01-TIPO-PAGAMENTO */
                    _.Move("DE ADIANTAMENTO SEM CANCEL DE SINISTRO", W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

                    /*" -1329- ELSE */
                }
                else
                {


                    /*" -1330- IF HOST-OPERACAO-EST EQUAL 1003 */

                    if (HOST_OPERACAO_EST == 1003)
                    {

                        /*" -1332- MOVE 'DE PAG TOTAL SEM CANCEL.DE SINISTRO' TO LD01-TIPO-PAGAMENTO */
                        _.Move("DE PAG TOTAL SEM CANCEL.DE SINISTRO", W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

                        /*" -1333- ELSE */
                    }
                    else
                    {


                        /*" -1335- MOVE 'DE PAG.COMPLEMENTAR S/CANCEL.DE SINISTRO' TO LD01-TIPO-PAGAMENTO */
                        _.Move("DE PAG.COMPLEMENTAR S/CANCEL.DE SINISTRO", W_ARQUIVO.LD01.LD01_TIPO_PAGAMENTO);

                        /*" -1336- END-IF */
                    }


                    /*" -1337- END-IF */
                }


                /*" -1337- END-IF. */
            }


        }

        [StopWatch]
        /*" R240-MONTA-TIPO-ESTORNO-DB-SELECT-1 */
        public void R240_MONTA_TIPO_ESTORNO_DB_SELECT_1()
        {
            /*" -1303- EXEC SQL SELECT OPERACAO INTO :HOST-OPERACAO-EST FROM SEGUROS.V0HISTSINI WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORHIST = :SINISHIS-OCORR-HISTORICO AND OPERACAO IN (1001, 1003, 1004) END-EXEC. */

            var r240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1 = new R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1.Execute(r240_MONTA_TIPO_ESTORNO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_OPERACAO_EST, HOST_OPERACAO_EST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R240_EXIT*/

        [StopWatch]
        /*" R1000-GRAVA-ARQUIVO */
        private void R1000_GRAVA_ARQUIVO(bool isPerform = false)
        {
            /*" -1344- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(W_ARQUIVO.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1354- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WSQLCODE);

                /*" -1355- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WSQLCODE1);

                /*" -1356- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WSQLCODE2);

                /*" -1357- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W_ARQUIVO.WSQLCODE3);
            }


            /*" -1359- DISPLAY WABEND. */
            _.Display(W_ARQUIVO.WTAB02.WABEND);

            /*" -1360- CLOSE ARQ-SAIDA. */
            ARQ_SAIDA.Close();

            /*" -1360- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1362- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1362- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}