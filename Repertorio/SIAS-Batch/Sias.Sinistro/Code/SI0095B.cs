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
using Sias.Sinistro.DB2.SI0095B;

namespace Code
{
    public class SI0095B
    {
        public bool IsCall { get; set; }

        public SI0095B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA   : SINISTRO                                        //      */
        /*"      * PROGRAMA  : SI0095B                                         //      */
        /*"      * OBJETIVO  : EMISSAO DO RECIBO DE INDENIZACAO PARA A CARTEIRA//      */
        /*"      *             DE LOTERICO (PRODUTO 7105), APENAS PARA OS      //      */
        /*"      *             LOTERICOS EM QUE O ESTIPULANTE E A CEF.         //      */
        /*"      *             IDENTIFICADO PELO COD_LOT_CEF = COD_LOT_FENAL   //      */
        /*"      *             E OS ABATIMENTOS NA SEGUROS.SINI_LOT_ABAT02     //      */
        /*"      * ANALISTA/PROGRAMADOR :    HEIDER                            //      */
        /*"      * DATA                 :    JULHO / 2001                      //      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *                                                                *      */
        /*"      * 26/06/2002 - RICARDO    - LR001 - ALTERACAO NO LAYOUT DO RE-   *      */
        /*"      *              CIBO PARA SER ENVIADO POR E-MAIL.                 *      */
        /*"      *                                                                *      */
        /*"      * 24/05/2002 - RICARDO    - LR001 - ALTERACAO NO LAYOUT DO RE-   *      */
        /*"      *              CIBO.                                             *      */
        /*"      *                                                                *      */
        /*"      * 19/12/2001 - RILDO SICO - RS001 - TRATAMENTO DAS COBERTURAS    *      */
        /*"      *              DIFERENTES DE VALORES                             *      */
        /*"      *                                                                *      */
        /*"      * 07/04/2005 - PRODEXTER -                                       *      */
        /*"      *              SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI         *      */
        /*"      *              GE_OPERACAO.                                      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SI0090M1 { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis SI0090M1
        {
            get
            {
                _.Move(REG_SI0090M1, _SI0090M1); VarBasis.RedefinePassValue(REG_SI0090M1, _SI0090M1, REG_SI0090M1); return _SI0090M1;
            }
        }
        /*"01  REG-SI0090M1.*/
        public SI0095B_REG_SI0090M1 REG_SI0090M1 { get; set; } = new SI0095B_REG_SI0090M1();
        public class SI0095B_REG_SI0090M1 : VarBasis
        {
            /*"    05 LINHA              PIC  X(80).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        }

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
        /*"77  HOST-VALOR-DIFERENCA        PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-GDA-AGENCIA               PIC  9(04)           VALUE  0.*/
        public IntBasis W_GDA_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  W.*/
        public SI0095B_W W { get; set; } = new SI0095B_W();
        public class SI0095B_W : VarBasis
        {
            /*"  03 LC00-BRANCO.*/
            public SI0095B_LC00_BRANCO LC00_BRANCO { get; set; } = new SI0095B_LC00_BRANCO();
            public class SI0095B_LC00_BRANCO : VarBasis
            {
                /*"       05 FILLER                     PIC X(80) VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                /*"  03 LC00.*/
            }
            public SI0095B_LC00 LC00 { get; set; } = new SI0095B_LC00();
            public class SI0095B_LC00 : VarBasis
            {
                /*"       05 FILLER                     PIC X(80) VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                /*"  03 LC01.*/
            }
            public SI0095B_LC01 LC01 { get; set; } = new SI0095B_LC01();
            public class SI0095B_LC01 : VarBasis
            {
                /*"    05 FILLER                     PIC X(09) VALUE          'SI0095B.1'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SI0095B.1");
                /*"    05 FILLER                     PIC X(10) VALUE  SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 FILLER                     PIC X(38) VALUE          '         CAIXA SEGURADORA S/A         '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"         CAIXA SEGURADORA S/A         ");
                /*"    05 FILLER                     PIC X(07) VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
                /*"    05 FILLER                     PIC X(06) VALUE          'DATA: '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"DATA: ");
                /*"    05 LC01-DATA                  PIC X(10) VALUE  SPACES.*/
                public StringBasis LC01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03 LC02.*/
            }
            public SI0095B_LC02 LC02 { get; set; } = new SI0095B_LC02();
            public class SI0095B_LC02 : VarBasis
            {
                /*"    05 FILLER                     PIC X(15) VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"    05 FILLER                     PIC X(49) VALUE          'RECIBO DE INDENIZACAO DE SINISTRO - LOTERICO (RD)'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "49", "X(49)"), @"RECIBO DE INDENIZACAO DE SINISTRO - LOTERICO (RD)");
                /*"    05 FILLER                     PIC X(16) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"  03 LC03.*/
            }
            public SI0095B_LC03 LC03 { get; set; } = new SI0095B_LC03();
            public class SI0095B_LC03 : VarBasis
            {
                /*"    05 FILLER                     PIC X(10) VALUE          'SEGURADO: '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SEGURADO: ");
                /*"    05 LC03-NOME-RAZAO            PIC X(50) VALUE SPACES.*/
                public StringBasis LC03_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"");
                /*"    05 FILLER                     PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"  03 LC03A.*/
            }
            public SI0095B_LC03A LC03A { get; set; } = new SI0095B_LC03A();
            public class SI0095B_LC03A : VarBasis
            {
                /*"    05 FILLER                     PIC X(10) VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC03A-ENDERECO             PIC X(40) VALUE SPACES.*/
                public StringBasis LC03A_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05 FILLER                     PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LC03A-COMPL-ENDERECO       PIC X(15) VALUE SPACES.*/
                public StringBasis LC03A_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"  03 LC03B.*/
            }
            public SI0095B_LC03B LC03B { get; set; } = new SI0095B_LC03B();
            public class SI0095B_LC03B : VarBasis
            {
                /*"    05 FILLER                     PIC X(10) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC03B-BAIRRO               PIC X(20) VALUE SPACES.*/
                public StringBasis LC03B_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"    05 FILLER                     PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LC03B-CEP                  PIC 9(08) VALUE ZEROS.*/
                public IntBasis LC03B_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
                /*"    05 FILLER                     PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LC03B-CIDADE               PIC X(20) VALUE SPACES.*/
                public StringBasis LC03B_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"    05 FILLER                     PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LC03B-SIGLA-UF             PIC X(02) VALUE SPACES.*/
                public StringBasis LC03B_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"  03 LC04.*/
            }
            public SI0095B_LC04 LC04 { get; set; } = new SI0095B_LC04();
            public class SI0095B_LC04 : VarBasis
            {
                /*"    05 FILLER                     PIC X(17) VALUE          'COD. LOTERICO CEF'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"COD. LOTERICO CEF");
                /*"    05 FILLER                     PIC X(02) VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05 FILLER                     PIC X(13) VALUE          'APOLICE      '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"APOLICE      ");
                /*"    05 FILLER                     PIC X(04) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    05 FILLER                     PIC X(13) VALUE          'SINISTRO     '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SINISTRO     ");
                /*"    05 FILLER                     PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"  03 LC05.*/
            }
            public SI0095B_LC05 LC05 { get; set; } = new SI0095B_LC05();
            public class SI0095B_LC05 : VarBasis
            {
                /*"    05 LC05-COD-CAIXA               PIC ZZZZZZ.*/
                public StringBasis LC05_COD_CAIXA { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZ."), @"");
                /*"    05 FILLER                       PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"    05 LC05-COD-LOT-CEF             PIC 999999.*/
                public IntBasis LC05_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                /*"    05 FILLER                       PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 LC05-DIG-LOT-CEF             PIC 9.*/
                public IntBasis LC05_DIG_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "1", "9."));
                /*"    05 FILLER                       PIC X(04) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    05 LC05-APOLICE                 PIC 9(13) VALUE ZEROS.*/
                public IntBasis LC05_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    05 FILLER                       PIC X(04) VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"    05 LC05-SINISTRO                PIC 9(13) VALUE ZEROS.*/
                public IntBasis LC05_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    05 FILLER                       PIC X(01) VALUE SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"  03 LC06.*/
            }
            public SI0095B_LC06 LC06 { get; set; } = new SI0095B_LC06();
            public class SI0095B_LC06 : VarBasis
            {
                /*"    05 FILLER                       PIC X(10) VALUE          'DT. OCOR. '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT. OCOR. ");
                /*"    05 FILLER                       PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05 FILLER                       PIC X(10) VALUE          'DT. AVISO '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT. AVISO ");
                /*"    05 FILLER                       PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05 FILLER                       PIC X(06) VALUE          'EVENTO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"EVENTO");
                /*"  03 LC07.*/
            }
            public SI0095B_LC07 LC07 { get; set; } = new SI0095B_LC07();
            public class SI0095B_LC07 : VarBasis
            {
                /*"    05 LC07-DATA-OCORRENCIA         PIC X(10) VALUE SPACES.*/
                public StringBasis LC07_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 FILLER                       PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05 LC07-DATA-AVISO              PIC X(10) VALUE SPACES.*/
                public StringBasis LC07_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 FILLER                       PIC X(03) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05 LC07-DESCRICAO-CAUSA         PIC X(40) VALUE SPACES.*/
                public StringBasis LC07_DESCRICAO_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  03 LC08.*/
            }
            public SI0095B_LC08 LC08 { get; set; } = new SI0095B_LC08();
            public class SI0095B_LC08 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'DEMONSTRATIVO             '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"DEMONSTRATIVO             ");
                /*"    05 FILLER                       PIC X(16) VALUE        '   VALORES      '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"   VALORES      ");
                /*"    05 FILLER                       PIC X(10) VALUE        'DATA      '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA      ");
                /*"  03 LV01.*/
            }
            public SI0095B_LV01 LV01 { get; set; } = new SI0095B_LV01();
            public class SI0095B_LV01 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'VALOR DA IMPORTANCIA SEGURADA ........................'*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"VALOR DA IMPORTANCIA SEGURADA ........................");
                /*"    05 LV01-VALOR-IS                PIC ***.***.**9,99.*/
                public DoubleBasis LV01_VALOR_IS { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99."), 2);
                /*"    05 FILLER                       PIC X(02) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    05 LV01-DATA-AVISO-SIAS         PIC X(10) VALUE SPACES.*/
                public StringBasis LV01_DATA_AVISO_SIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03 LV02.*/
            }
            public SI0095B_LV02 LV02 { get; set; } = new SI0095B_LV02();
            public class SI0095B_LV02 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'VALOR INFORMADO (PELO LOTERICO) ......................'*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"VALOR INFORMADO (PELO LOTERICO) ......................");
                /*"    05 LV02-VALOR-INFORMADO         PIC ***.***.**9,99.*/
                public DoubleBasis LV02_VALOR_INFORMADO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99."), 2);
                /*"  03 LV03.*/
            }
            public SI0095B_LV03 LV03 { get; set; } = new SI0095B_LV03();
            public class SI0095B_LV03 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'VALOR REGISTRADO (LIMITADO A IMPORTANCIA SEGURADA) ...'*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"VALOR REGISTRADO (LIMITADO A IMPORTANCIA SEGURADA) ...");
                /*"    05 LV03-VALOR-REGISTRADO        PIC ***.***.**9,99.*/
                public DoubleBasis LV03_VALOR_REGISTRADO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99."), 2);
                /*"  03 LV04.*/
            }
            public SI0095B_LV04 LV04 { get; set; } = new SI0095B_LV04();
            public class SI0095B_LV04 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'VALOR APURADO PELA REGULACAO .........................'*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"VALOR APURADO PELA REGULACAO .........................");
                /*"    05 LV04-VALOR-APURADO           PIC ***.***.**9,99+.*/
                public DoubleBasis LV04_VALOR_APURADO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"    05 FILLER                       PIC X(01) VALUE SPACE.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LV04-DATA-VALOR-APURADO      PIC X(10) VALUE SPACES.*/
                public StringBasis LV04_DATA_VALOR_APURADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03 LV05.*/
            }
            public SI0095B_LV05 LV05 { get; set; } = new SI0095B_LV05();
            public class SI0095B_LV05 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'DESCONTO DE FRANQUIA .................................'*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"DESCONTO DE FRANQUIA .................................");
                /*"    05 LV05-VALOR-FRANQUIA          PIC ***.***.**9,99+.*/
                public DoubleBasis LV05_VALOR_FRANQUIA { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"  03 LV06.*/
            }
            public SI0095B_LV06 LV06 { get; set; } = new SI0095B_LV06();
            public class SI0095B_LV06 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'REINTEGRACAO DE PREMIO NA OCOR. DO SINISTRO ..........'*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"REINTEGRACAO DE PREMIO NA OCOR. DO SINISTRO ..........");
                /*"    05 LV06-VALOR-REINTEGRACAO      PIC ***.***.**9,99+.*/
                public DoubleBasis LV06_VALOR_REINTEGRACAO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"  03 LV07.*/
            }
            public SI0095B_LV07 LV07 { get; set; } = new SI0095B_LV07();
            public class SI0095B_LV07 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'IOF DA REINTEGRACAO DO PREMIO ........................'*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"IOF DA REINTEGRACAO DO PREMIO ........................");
                /*"    05 LV07-VALOR-IOF-REINTEGRACAO  PIC ***.***.**9,99+.*/
                public DoubleBasis LV07_VALOR_IOF_REINTEGRACAO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"  03 LV08.*/
            }
            public SI0095B_LV08 LV08 { get; set; } = new SI0095B_LV08();
            public class SI0095B_LV08 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'AGRAVAMENTO DE PREMIO SOBRE PARCELAS PAGAS ...........'*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"AGRAVAMENTO DE PREMIO SOBRE PARCELAS PAGAS ...........");
                /*"    05 LV08-VALOR-AGRAVAMENTO       PIC ***.***.**9,99-.*/
                public DoubleBasis LV08_VALOR_AGRAVAMENTO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99-."), 3);
                /*"  03 LV09.*/
            }
            public SI0095B_LV09 LV09 { get; set; } = new SI0095B_LV09();
            public class SI0095B_LV09 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'IOF AGRAVAMENTO DE PREMIO SOBRE PARCELAS PAGAS .......'*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"IOF AGRAVAMENTO DE PREMIO SOBRE PARCELAS PAGAS .......");
                /*"    05 LV09-VALOR-IOF-AGRAVAMENTO   PIC ***.***.**9,99-.*/
                public DoubleBasis LV09_VALOR_IOF_AGRAVAMENTO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99-."), 3);
                /*"  03 LV10.*/
            }
            public SI0095B_LV10 LV10 { get; set; } = new SI0095B_LV10();
            public class SI0095B_LV10 : VarBasis
            {
                /*"    05 FILLER                       PIC X(54) VALUE        'VALOR DA INDENIZACAO .................................'*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "54", "X(54)"), @"VALOR DA INDENIZACAO .................................");
                /*"    05 LV10-VALOR-INDENIZACAO       PIC ***.***.**9,99+.*/
                public DoubleBasis LV10_VALOR_INDENIZACAO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"    05 FILLER                       PIC X(01) VALUE SPACE.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LV10-DATA-EMISSAO-CHQ        PIC X(10) VALUE SPACES.*/
                public StringBasis LV10_DATA_EMISSAO_CHQ { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03 LV11.*/
            }
            public SI0095B_LV11 LV11 { get; set; } = new SI0095B_LV11();
            public class SI0095B_LV11 : VarBasis
            {
                /*"    05 FILLER                       PIC X(21) VALUE        'VALOR DO ADIANTAMENTO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"VALOR DO ADIANTAMENTO");
                /*"    05 LV11-ADIANTAMENTO.*/
                public SI0095B_LV11_ADIANTAMENTO LV11_ADIANTAMENTO { get; set; } = new SI0095B_LV11_ADIANTAMENTO();
                public class SI0095B_LV11_ADIANTAMENTO : VarBasis
                {
                    /*"        10 LV11-TEXTO-ADIANTAMENTO   PIC X(04) VALUE ' EM '.*/
                    public StringBasis LV11_TEXTO_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @" EM ");
                    /*"        10 LV11-DATA-ADIANTAMENTO    PIC X(10) VALUE SPACES.*/
                    public StringBasis LV11_DATA_ADIANTAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                    /*"    05 FILLER                       PIC X(19) VALUE        '...................'.*/
                }
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"...................");
                /*"    05 LV11-VALOR-ADIANTAMENTO      PIC ***.***.**9,99+.*/
                public DoubleBasis LV11_VALOR_ADIANTAMENTO { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"  03 LV12.*/
            }
            public SI0095B_LV12 LV12 { get; set; } = new SI0095B_LV12();
            public class SI0095B_LV12 : VarBasis
            {
                /*"    05 FILLER                       PIC X(34) VALUE        'VALOR DA DIFERENCA DE INDENIZACAO '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"VALOR DA DIFERENCA DE INDENIZACAO ");
                /*"    05 LV12-CREDITO-DEBITO          PIC X(09) VALUE SPACES.*/
                public StringBasis LV12_CREDITO_DEBITO { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    05 FILLER                       PIC X(11) VALUE        '...........'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"...........");
                /*"    05 LV12-VALOR-DIFERENCA         PIC ***.***.**9,99+.*/
                public DoubleBasis LV12_VALOR_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "1", "***.***.**9V99+."), 2);
                /*"  03 LT01.*/
            }
            public SI0095B_LT01 LT01 { get; set; } = new SI0095B_LT01();
            public class SI0095B_LT01 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'RECEBI (EMOS) DA CAIXA SEGURADORA S/A A IMPORTANC               'IA SUPRACITADA  COMO INDENIZA-'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"RECEBI (EMOS) DA CAIXA SEGURADORA S/A A IMPORTANC               ");
                /*"  03 LT02.*/
            }
            public SI0095B_LT02 LT02 { get; set; } = new SI0095B_LT02();
            public class SI0095B_LT02 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'CAO, POR TODOS OS DANOS E PREJUIZOS QUE SE ORIGIN               'ARAM DA OCORRENCIA DESCRITA E '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"CAO, POR TODOS OS DANOS E PREJUIZOS QUE SE ORIGIN               ");
                /*"  03 LT03.*/
            }
            public SI0095B_LT03 LT03 { get; set; } = new SI0095B_LT03();
            public class SI0095B_LT03 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'REGULADA NO PROCESSO DE SINISTRO EM REFERENCIA.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"REGULADA");
                /*"  03 LT04.*/
            }
            public SI0095B_LT04 LT04 { get; set; } = new SI0095B_LT04();
            public class SI0095B_LT04 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               'COMPANHIA, PLENA, GERAL E  IR-'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"RECEBENDO ESTA INDENIZACAO DOU (AMOS) A REFERIDA               ");
                /*"  03 LT05.*/
            }
            public SI0095B_LT05 LT05 { get; set; } = new SI0095B_LT05();
            public class SI0095B_LT05 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'REVOGAVEL QUITACAO DE PAGO (S) E SATISFEITO (S) D               'E TODOS OS PREJUIZOS SOFRIDOS,'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"REVOGAVEL QUITACAO DE PAGO (S) E SATISFEITO (S) D               ");
                /*"  03 LT06.*/
            }
            public SI0095B_LT06 LT06 { get; set; } = new SI0095B_LT06();
            public class SI0095B_LT06 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               'ONTRA O CAUSADOR E/OU  RESPON-'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"SUB-ROGANDO-LHE TODAS AS ACOES QUE POSSAM CABER C               ");
                /*"  03 LT07.*/
            }
            public SI0095B_LT07 LT07 { get; set; } = new SI0095B_LT07();
            public class SI0095B_LT07 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'SAVEL PELO EVENTO, E DIREITOS SOBRE A PROPRIEDADE               ' DO (S) BEM (NS)  CARACTERIZA-'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"SAVEL PELO EVENTO, E DIREITOS SOBRE A PROPRIEDADE               ");
                /*"  03 LT08.*/
            }
            public SI0095B_LT08 LT08 { get; set; } = new SI0095B_LT08();
            public class SI0095B_LT08 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'DO (S) SENDO O MESMO UTILIZADO PELA COMPANHIA DA               'MANEIRA QUE LHE CONVIR SEM QUE'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"DO (S) SENDO O MESMO UTILIZADO PELA COMPANHIA DA               ");
                /*"  03 LT09.*/
            }
            public SI0095B_LT09 LT09 { get; set; } = new SI0095B_LT09();
            public class SI0095B_LT09 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'NOS ASSISTA DIREITO A RECLAMACOES.'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"NOS ASSISTA DIREITO A RECLAMACOES.");
                /*"  03 LT10.*/
            }
            public SI0095B_LT10 LT10 { get; set; } = new SI0095B_LT10();
            public class SI0095B_LT10 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               'BO EM 3 (TRES) VIAS  DE  IGUAL'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"PARA MAIOR CLAREZA, ASSINO (AMOS) O PRESENTE RECI               ");
                /*"  03 LT11.*/
            }
            public SI0095B_LT11 LT11 { get; set; } = new SI0095B_LT11();
            public class SI0095B_LT11 : VarBasis
            {
                /*"    05          FILLER              PIC  X(80) VALUE               'TEOR PARA UM SO EFEITO.'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"TEOR PARA UM SO EFEITO.");
                /*"  03 LC16A.*/
            }
            public SI0095B_LC16A LC16A { get; set; } = new SI0095B_LC16A();
            public class SI0095B_LC16A : VarBasis
            {
                /*"    05 FILLER                       PIC X(58) VALUE        'IDENTIFICACAO DO TIPO DE PAGAMENTO (USO EXCLUSIVO SASSE)        ': '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "58", "X(58)"), @"IDENTIFICACAO DO TIPO DE PAGAMENTO (USO EXCLUSIVO SASSE)        ");
                /*"    05 LC16A-TIPO-PAGAMENTO         PIC X(22) VALUE SPACES.*/
                public StringBasis LC16A_TIPO_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"");
                /*"  03 LC17A.*/
            }
            public SI0095B_LC17A LC17A { get; set; } = new SI0095B_LC17A();
            public class SI0095B_LC17A : VarBasis
            {
                /*"    05 FILLER                       PIC X(20) VALUE        'CAUSA DO SINISTRO - '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"CAUSA DO SINISTRO - ");
                /*"    05 LC17A-DESCAU                 PIC X(40) VALUE SPACES.*/
                public StringBasis LC17A_DESCAU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  03 LC18A.*/
            }
            public SI0095B_LC18A LC18A { get; set; } = new SI0095B_LC18A();
            public class SI0095B_LC18A : VarBasis
            {
                /*"    05 FILLER                       PIC X(11) VALUE        'ENVIADO EM '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"ENVIADO EM ");
                /*"    05 LC18A-DATA-MVTO              PIC X(10) VALUE SPACES.*/
                public StringBasis LC18A_DATA_MVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 FILLER                       PIC X(06) VALUE        ' PARA '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @" PARA ");
                /*"    05 LC18A-CREDITO-DEBITO         PIC X(09) VALUE SPACES.*/
                public StringBasis LC18A_CREDITO_DEBITO { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    05 FILLER                       PIC X(03) VALUE        'EM '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"EM ");
                /*"    05 LC18A-DATA-VCTO              PIC X(10) VALUE SPACES.*/
                public StringBasis LC18A_DATA_VCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"  03 LC19A.*/
            }
            public SI0095B_LC19A LC19A { get; set; } = new SI0095B_LC19A();
            public class SI0095B_LC19A : VarBasis
            {
                /*"    05 FILLER                       PIC X(18) VALUE        'NA CONTA CORRENTE '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"NA CONTA CORRENTE ");
                /*"    05 LC19A-BANCO                  PIC 9(03) VALUE ZEROS.*/
                public IntBasis LC19A_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    05 FILLER                       PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 LC19A-AGENCIA                PIC 9(04) VALUE ZEROS.*/
                public IntBasis LC19A_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 FILLER                       PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 LC19A-OPERACAO               PIC 9(04) VALUE ZEROS.*/
                public IntBasis LC19A_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 FILLER                       PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 LC19A-CONTA                  PIC 999.999.999.999.*/
                public IntBasis LC19A_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "999.999.999.999."));
                /*"    05 FILLER                       PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 LC19A-DV                     PIC 9(01) VALUE 0.*/
                public IntBasis LC19A_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"  03            LCEG.*/
            }
            public SI0095B_LCEG LCEG { get; set; } = new SI0095B_LCEG();
            public class SI0095B_LCEG : VarBasis
            {
                /*"    05          FILLER              PIC  X(05) VALUE '(###)'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"(###)");
                /*"    05          FILLER              PIC  X(75) VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "75", "X(75)"), @"");
                /*"  03            LCEGA.*/
            }
            public SI0095B_LCEGA LCEGA { get; set; } = new SI0095B_LCEGA();
            public class SI0095B_LCEGA : VarBasis
            {
                /*"    05          FILLER              PIC  X(06) VALUE '(PARA)'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"(PARA)");
                /*"    05          FILLER              PIC  X(74) VALUE SPACES.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "74", "X(74)"), @"");
                /*"  03            LCEGB1.*/
            }
            public SI0095B_LCEGB1 LCEGB1 { get; set; } = new SI0095B_LCEGB1();
            public class SI0095B_LCEGB1 : VarBasis
            {
                /*"    05          FILLER              PIC  X(27) VALUE                'HEIDERC@CAIXASEGUROS.COM.BR'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "27", "X(27)"), @"HEIDERC@CAIXASEGUROS.COM.BR");
                /*"    05          FILLER              PIC  X(53) VALUE  SPACES.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "53", "X(53)"), @"");
                /*"  03            LCEGB2.*/
            }
            public SI0095B_LCEGB2 LCEGB2 { get; set; } = new SI0095B_LCEGB2();
            public class SI0095B_LCEGB2 : VarBasis
            {
                /*"    05          FILLER              PIC  X(32) VALUE                'LUIS.RICARDO@CAIXASEGUROS.COM.BR'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @"LUIS.RICARDO@CAIXASEGUROS.COM.BR");
                /*"    05          FILLER              PIC  X(48) VALUE  SPACES.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "48", "X(48)"), @"");
                /*"  03            LCEGB3.*/
            }
            public SI0095B_LCEGB3 LCEGB3 { get; set; } = new SI0095B_LCEGB3();
            public class SI0095B_LCEGB3 : VarBasis
            {
                /*"    05          FILLER              PIC  X(24) VALUE                'MRUA@CAIXASEGUROS.COM.BR'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"MRUA@CAIXASEGUROS.COM.BR");
                /*"    05          FILLER              PIC  X(56) VALUE  SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "56", "X(56)"), @"");
                /*"  03            LCEGB.*/
            }
            public SI0095B_LCEGB LCEGB { get; set; } = new SI0095B_LCEGB();
            public class SI0095B_LCEGB : VarBasis
            {
                /*"    05          FILLER              PIC  X(01) VALUE 'A'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"A");
                /*"    05          LCEGB-DESTINATARIO  PIC  9(04) VALUE  0.*/
                public IntBasis LCEGB_DESTINATARIO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05          FILLER              PIC  X(13) VALUE                '@CAIXA.GOV.BR'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"@CAIXA.GOV.BR");
                /*"    05          FILLER              PIC  X(62) VALUE SPACES.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "62", "X(62)"), @"");
                /*"  03            LCEGC.*/
            }
            public SI0095B_LCEGC LCEGC { get; set; } = new SI0095B_LCEGC();
            public class SI0095B_LCEGC : VarBasis
            {
                /*"    05          FILLER              PIC  X(15) VALUE                '(NOMEDOARQUIVO)'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"(NOMEDOARQUIVO)");
                /*"    05          FILLER              PIC  X(65) VALUE SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "65", "X(65)"), @"");
                /*"  03            LCEGD.*/
            }
            public SI0095B_LCEGD LCEGD { get; set; } = new SI0095B_LCEGD();
            public class SI0095B_LCEGD : VarBasis
            {
                /*"    05          LCEGD-NOME-ARQ      PIC  X(14) VALUE SPACES.*/
                public StringBasis LCEGD_NOME_ARQ { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"");
                /*"    05          LCEGD-SEQ-ARQ       PIC  9(03) VALUE 0.*/
                public IntBasis LCEGD_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"    05          FILLER              PIC  X(04) VALUE '.DOC'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @".DOC");
                /*"    05          FILLER              PIC  X(63) VALUE SPACES.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "63", "X(63)"), @"");
                /*"  03            LCEGE.*/
            }
            public SI0095B_LCEGE LCEGE { get; set; } = new SI0095B_LCEGE();
            public class SI0095B_LCEGE : VarBasis
            {
                /*"    05          FILLER              PIC  X(09) VALUE                '(ASSUNTO)'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"(ASSUNTO)");
                /*"  03            LCEGF.*/
            }
            public SI0095B_LCEGF LCEGF { get; set; } = new SI0095B_LCEGF();
            public class SI0095B_LCEGF : VarBasis
            {
                /*"    05          FILLER              PIC  X(33) VALUE                'RECIBO DE SINISTRO DE LOTERICO - '.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "33", "X(33)"), @"RECIBO DE SINISTRO DE LOTERICO - ");
                /*"    05          LCEGF-ASSUNTO       PIC  X(40) VALUE SPACES.*/
                public StringBasis LCEGF_ASSUNTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  03            LC0E.*/
            }
            public SI0095B_LC0E LC0E { get; set; } = new SI0095B_LC0E();
            public class SI0095B_LC0E : VarBasis
            {
                /*"    05          FILLER              PIC  X(01) VALUE  SPACE.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05          FILLER              PIC  X(80) VALUE 'CORRETOR'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"CORRETOR");
                /*"  03            LC58A.*/
            }
            public SI0095B_LC58A LC58A { get; set; } = new SI0095B_LC58A();
            public class SI0095B_LC58A : VarBasis
            {
                /*"    05          FILLER              PIC  X(13) VALUE SPACES.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"    05          LC58A-LOCAL-E-DATA  PIC  X(67) VALUE SPACES.*/
                public StringBasis LC58A_LOCAL_E_DATA { get; set; } = new StringBasis(new PIC("X", "67", "X(67)"), @"");
                /*"  03            LC58B.*/
            }
            public SI0095B_LC58B LC58B { get; set; } = new SI0095B_LC58B();
            public class SI0095B_LC58B : VarBasis
            {
                /*"    05          FILLER              PIC  X(13) VALUE SPACES.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"    05          FILLER              PIC  X(36) VALUE ALL '-'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"ALL");
                /*"  03            LC58C.*/
            }
            public SI0095B_LC58C LC58C { get; set; } = new SI0095B_LC58C();
            public class SI0095B_LC58C : VarBasis
            {
                /*"    05          FILLER              PIC  X(13) VALUE SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"    05          LC58C-NOME-LOTERICO PIC  X(40) VALUE SPACES.*/
                public StringBasis LC58C_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"  03            LC58D.*/
            }
            public SI0095B_LC58D LC58D { get; set; } = new SI0095B_LC58D();
            public class SI0095B_LC58D : VarBasis
            {
                /*"    05          FILLER              PIC  X(13) VALUE SPACES.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"    05          FILLER              PIC  X(13) VALUE                                         'CPF / CNPJ - '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CPF / CNPJ - ");
                /*"    05          LC58D-CPF-CNPJ      PIC  X(20) VALUE SPACES.*/
                public StringBasis LC58D_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
                /*"  03            LC58E.*/
            }
            public SI0095B_LC58E LC58E { get; set; } = new SI0095B_LC58E();
            public class SI0095B_LC58E : VarBasis
            {
                /*"    05          FILLER              PIC  X(13) VALUE SPACES.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"");
                /*"    05          FILLER              PIC  X(06) VALUE 'IDENT:'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"IDENT:");
                /*"  03    LC100.*/
            }
            public SI0095B_LC100 LC100 { get; set; } = new SI0095B_LC100();
            public class SI0095B_LC100 : VarBasis
            {
                /*"    05  FILLER                   PIC  X(13) VALUE        'CHQ. INTERNO:'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CHQ. INTERNO:");
                /*"    05  FILLER                   PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05  LC100-CHQINT             PIC  ZZZZZZZ9.*/
                public IntBasis LC100_CHQINT { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
                /*"    05  FILLER                   PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05  LC100-DIGINT             PIC  9(01) VALUE 0.*/
                public IntBasis LC100_DIGINT { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"    05  FILLER                   PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05  FILLER                   PIC  X(05) VALUE        'BCO: '.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"BCO: ");
                /*"    05  LC100-BANCO              PIC  ZZ9.*/
                public IntBasis LC100_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                /*"    05  FILLER                   PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05  FILLER                   PIC  X(05) VALUE        'AGE: '.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"AGE: ");
                /*"    05  LC100-AGENCIA            PIC  ZZZ9.*/
                public IntBasis LC100_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    05  FILLER                   PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05  FILLER                   PIC  X(11) VALUE        'SERIE/NUM: '.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SERIE/NUM: ");
                /*"    05  LC100-SERCHQ             PIC  X(03) VALUE SPACES.*/
                public StringBasis LC100_SERCHQ { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"    05  FILLER                   PIC  X(01) VALUE SPACES.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05  LC100-NUMCHQ             PIC  ZZZ.ZZZ.ZZ9.*/
                public IntBasis LC100_NUMCHQ { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
                /*"    05  FILLER                   PIC  X(01) VALUE '-'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05  LC100-DIGCHQ             PIC  9(01) VALUE 0.*/
                public IntBasis LC100_DIGCHQ { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"  03            WSQLCODE3          PIC S9(09) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  03 W-DATA-AAAA-MM-DD.*/
            public SI0095B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0095B_W_DATA_AAAA_MM_DD();
            public class SI0095B_W_DATA_AAAA_MM_DD : VarBasis
            {
                /*"    05 W-DATA-AAAA-MM-DD-AAAA      PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 W-DATA-AAAA-MM-DD-MM        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 W-DATA-AAAA-MM-DD-DD        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  03 W-DATA-DD-MM-AAAA.*/
            }
            public SI0095B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI0095B_W_DATA_DD_MM_AAAA();
            public class SI0095B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"    05 W-DATA-DD-MM-AAAA-DD        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 W-DATA-DD-MM-AAAA-MM        PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 W-DATA-DD-MM-AAAA-AAAA      PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  03 W-DATA-DD-MM-AAAA1.*/
            }
            public SI0095B_W_DATA_DD_MM_AAAA1 W_DATA_DD_MM_AAAA1 { get; set; } = new SI0095B_W_DATA_DD_MM_AAAA1();
            public class SI0095B_W_DATA_DD_MM_AAAA1 : VarBasis
            {
                /*"    05 W-DATA-DD-MM-AAAA1-DD       PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 FILLER                      PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05 W-DATA-DD-MM-AAAA1-MM       PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 FILLER                      PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05 W-DATA-DD-MM-AAAA1-AAAA     PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_DD_MM_AAAA1_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"  03 W-GDA-COD-LOTERICO             PIC 9(13) VALUE ZEROS.*/
            }
            public IntBasis W_GDA_COD_LOTERICO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  03 FILLER REDEFINES W-GDA-COD-LOTERICO.*/
            private _REDEF_SI0095B_FILLER_123 _filler_123 { get; set; }
            public _REDEF_SI0095B_FILLER_123 FILLER_123
            {
                get { _filler_123 = new _REDEF_SI0095B_FILLER_123(); _.Move(W_GDA_COD_LOTERICO, _filler_123); VarBasis.RedefinePassValue(W_GDA_COD_LOTERICO, _filler_123, W_GDA_COD_LOTERICO); _filler_123.ValueChanged += () => { _.Move(_filler_123, W_GDA_COD_LOTERICO); }; return _filler_123; }
                set { VarBasis.RedefinePassValue(value, _filler_123, W_GDA_COD_LOTERICO); }
            }  //Redefines
            public class _REDEF_SI0095B_FILLER_123 : VarBasis
            {
                /*"    05 W-GDA-COD-CAIXA             PIC 9(06).*/
                public IntBasis W_GDA_COD_CAIXA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"    05 W-GDA-COD-LOT               PIC 9(06).*/
                public IntBasis W_GDA_COD_LOT { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"    05 W-GDA-DIG-COD-LOT           PIC 9.*/
                public IntBasis W_GDA_DIG_COD_LOT { get; set; } = new IntBasis(new PIC("9", "1", "9."));
                /*"  03 W-GDA-CPF                      PIC 9(15) VALUE ZEROS.*/

                public _REDEF_SI0095B_FILLER_123()
                {
                    W_GDA_COD_CAIXA.ValueChanged += OnValueChanged;
                    W_GDA_COD_LOT.ValueChanged += OnValueChanged;
                    W_GDA_DIG_COD_LOT.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_GDA_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"  03 FILLER REDEFINES W-GDA-CPF.*/
            private _REDEF_SI0095B_FILLER_124 _filler_124 { get; set; }
            public _REDEF_SI0095B_FILLER_124 FILLER_124
            {
                get { _filler_124 = new _REDEF_SI0095B_FILLER_124(); _.Move(W_GDA_CPF, _filler_124); VarBasis.RedefinePassValue(W_GDA_CPF, _filler_124, W_GDA_CPF); _filler_124.ValueChanged += () => { _.Move(_filler_124, W_GDA_CPF); }; return _filler_124; }
                set { VarBasis.RedefinePassValue(value, _filler_124, W_GDA_CPF); }
            }  //Redefines
            public class _REDEF_SI0095B_FILLER_124 : VarBasis
            {
                /*"    05 W-GDA-NUM-CPF               PIC 9(13).*/
                public IntBasis W_GDA_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"    05 W-GDA-DGV-CPF               PIC 9(02).*/
                public IntBasis W_GDA_DGV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03 W-GDA-CGC                      PIC 9(15) VALUE ZEROS.*/

                public _REDEF_SI0095B_FILLER_124()
                {
                    W_GDA_NUM_CPF.ValueChanged += OnValueChanged;
                    W_GDA_DGV_CPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_GDA_CGC { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"  03 FILLER REDEFINES W-GDA-CGC.*/
            private _REDEF_SI0095B_FILLER_125 _filler_125 { get; set; }
            public _REDEF_SI0095B_FILLER_125 FILLER_125
            {
                get { _filler_125 = new _REDEF_SI0095B_FILLER_125(); _.Move(W_GDA_CGC, _filler_125); VarBasis.RedefinePassValue(W_GDA_CGC, _filler_125, W_GDA_CGC); _filler_125.ValueChanged += () => { _.Move(_filler_125, W_GDA_CGC); }; return _filler_125; }
                set { VarBasis.RedefinePassValue(value, _filler_125, W_GDA_CGC); }
            }  //Redefines
            public class _REDEF_SI0095B_FILLER_125 : VarBasis
            {
                /*"    05 W-GDA-NUM-CGC               PIC 9(09).*/
                public IntBasis W_GDA_NUM_CGC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"    05 W-GDA-COMPL-CGC             PIC 9(04).*/
                public IntBasis W_GDA_COMPL_CGC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05 W-GDA-DGV-CGC               PIC 9(02).*/
                public IntBasis W_GDA_DGV_CGC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03 W-CGC.*/

                public _REDEF_SI0095B_FILLER_125()
                {
                    W_GDA_NUM_CGC.ValueChanged += OnValueChanged;
                    W_GDA_COMPL_CGC.ValueChanged += OnValueChanged;
                    W_GDA_DGV_CGC.ValueChanged += OnValueChanged;
                }

            }
            public SI0095B_W_CGC W_CGC { get; set; } = new SI0095B_W_CGC();
            public class SI0095B_W_CGC : VarBasis
            {
                /*"    05 W-NUM-CGC                   PIC Z99.999.999.*/
                public IntBasis W_NUM_CGC { get; set; } = new IntBasis(new PIC("9", "9", "Z99.999.999."));
                /*"    05 FILLER                      PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"    05 W-COMPL-CGC                 PIC 9999.*/
                public IntBasis W_COMPL_CGC { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"    05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 W-DGV-CGC                   PIC 99.*/
                public IntBasis W_DGV_CGC { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"  03 W-CPF.*/
            }
            public SI0095B_W_CPF W_CPF { get; set; } = new SI0095B_W_CPF();
            public class SI0095B_W_CPF : VarBasis
            {
                /*"    05 W-NUM-CPF                   PIC ZZZ.999.999.999.*/
                public IntBasis W_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "12", "ZZZ.999.999.999."));
                /*"    05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"    05 W-DGV-CPF                   PIC 99.*/
                public IntBasis W_DGV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"  03 W-NUMDOC                      PIC 9(13) VALUE ZEROS.*/
            }
            public IntBasis W_NUMDOC { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"  03 WFIM-SINISTRO-HISTORICO       PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_SINISTRO_HISTORICO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  03 W-PRODUTO-OPERACAO             PIC 9(09).*/
            public IntBasis W_PRODUTO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"  03 FILLER         REDEFINES       W-PRODUTO-OPERACAO.*/
            private _REDEF_SI0095B_FILLER_129 _filler_129 { get; set; }
            public _REDEF_SI0095B_FILLER_129 FILLER_129
            {
                get { _filler_129 = new _REDEF_SI0095B_FILLER_129(); _.Move(W_PRODUTO_OPERACAO, _filler_129); VarBasis.RedefinePassValue(W_PRODUTO_OPERACAO, _filler_129, W_PRODUTO_OPERACAO); _filler_129.ValueChanged += () => { _.Move(_filler_129, W_PRODUTO_OPERACAO); }; return _filler_129; }
                set { VarBasis.RedefinePassValue(value, _filler_129, W_PRODUTO_OPERACAO); }
            }  //Redefines
            public class _REDEF_SI0095B_FILLER_129 : VarBasis
            {
                /*"       10 FILLER                      PIC 9(01).*/
                public IntBasis FILLER_130 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 W-PRODUTO-OPERACAO-PRODUTO  PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-PRODUTO-OPERACAO-OPERACAO PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"  03 W-IND01                       PIC 9(03) VALUE ZEROS.*/

                public _REDEF_SI0095B_FILLER_129()
                {
                    FILLER_130.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_PRODUTO.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_IND01 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03 W-IND02                       PIC 9(03) VALUE ZEROS.*/
            public IntBasis W_IND02 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"  03 W-IND-PRINT-EMAIL             PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_PRINT_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"  03 WTAB01.*/
            public SI0095B_WTAB01 WTAB01 { get; set; } = new SI0095B_WTAB01();
            public class SI0095B_WTAB01 : VarBasis
            {
                /*"    05 WTAB01-LETRA               PIC X(01) OCCURS 132.*/
                public ListBasis<StringBasis, string> WTAB01_LETRA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 132);
                /*"  03 WTAB02.*/
            }
            public SI0095B_WTAB02 WTAB02 { get; set; } = new SI0095B_WTAB02();
            public class SI0095B_WTAB02 : VarBasis
            {
                /*"    05 WTAB02-LETRA               PIC X(01) OCCURS 132.*/
                public ListBasis<StringBasis, string> WTAB02_LETRA { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 132);
                /*"  03 WTABMES-G.*/
            }
            public SI0095B_WTABMES_G WTABMES_G { get; set; } = new SI0095B_WTABMES_G();
            public class SI0095B_WTABMES_G : VarBasis
            {
                /*"    05 FILLER     PIC  X(009) VALUE 'JANEIRO  '.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JANEIRO  ");
                /*"    05 FILLER     PIC  X(009) VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    05 FILLER     PIC  X(009) VALUE 'MARCO    '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MARCO    ");
                /*"    05 FILLER     PIC  X(009) VALUE 'ABRIL    '.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ABRIL    ");
                /*"    05 FILLER     PIC  X(009) VALUE 'MAIO     '.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MAIO     ");
                /*"    05 FILLER     PIC  X(009) VALUE 'JUNHO    '.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JUNHO    ");
                /*"    05 FILLER     PIC  X(009) VALUE 'JULHO    '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JULHO    ");
                /*"    05 FILLER     PIC  X(009) VALUE 'AGOSTO   '.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AGOSTO   ");
                /*"    05 FILLER     PIC  X(009) VALUE 'SETEMBRO '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SETEMBRO ");
                /*"    05 FILLER     PIC  X(009) VALUE 'OUTUBRO  '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"OUTUBRO  ");
                /*"    05 FILLER     PIC  X(009) VALUE 'NOVEMBRO '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NOVEMBRO ");
                /*"    05 FILLER     PIC  X(009) VALUE 'DEZEMBRO '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DEZEMBRO ");
                /*"  03  FILLER REDEFINES WTABMES-G OCCURS 12*/
            }
            private ListBasis<_REDEF_SI0095B_FILLER_143> _filler_143 { get; set; }
            public ListBasis<_REDEF_SI0095B_FILLER_143> FILLER_143
            {
                get { _filler_143 = new ListBasis<_REDEF_SI0095B_FILLER_143>(12); _.Move(WTABMES_G, _filler_143); VarBasis.RedefinePassValue(WTABMES_G, _filler_143, WTABMES_G); _filler_143.ValueChanged += () => { _.Move(_filler_143, WTABMES_G); }; return _filler_143; }
                set { VarBasis.RedefinePassValue(value, _filler_143, WTABMES_G); }
            }  //Redefines
            public class _REDEF_SI0095B_FILLER_143 : VarBasis
            {
                /*"    05 WTABMES    PIC X(09).*/
                public StringBasis WTABMES { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                /*"  03        WABEND.*/

                public _REDEF_SI0095B_FILLER_143()
                {
                    WTABMES.ValueChanged += OnValueChanged;
                }

            }
            public SI0095B_WABEND WABEND { get; set; } = new SI0095B_WABEND();
            public class SI0095B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(10) VALUE           ' SI0095B'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0095B");
                /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
                /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(30) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public SI0095B_LK_LINK LK_LINK { get; set; } = new SI0095B_LK_LINK();
        public class SI0095B_LK_LINK : VarBasis
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
        public SI0095B_INDENIZACOES INDENIZACOES { get; set; } = new SI0095B_INDENIZACOES();
        public SI0095B_LOTERICO LOTERICO { get; set; } = new SI0095B_LOTERICO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0090M1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0090M1.SetFile(SI0090M1_FILE_NAME_P);

                /*" -662- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -663- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -664- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -668- OPEN OUTPUT SI0090M1. */
                SI0090M1.Open(REG_SI0090M1);

                /*" -670- PERFORM R010-LE-SISTEMA THRU R010-EXIT. */

                R010_LE_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -671- MOVE 'NAO' TO WFIM-SINISTRO-HISTORICO. */
                _.Move("NAO", W.WFIM_SINISTRO_HISTORICO);

                /*" -672- PERFORM R020-DECLARE-PAGAMENTOS THRU R020-EXIT. */

                R020_DECLARE_PAGAMENTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -674- PERFORM R021-FETCH-PAGAMENTOS THRU R021-EXIT. */

                R021_FETCH_PAGAMENTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -675- IF WFIM-SINISTRO-HISTORICO EQUAL 'SIM' */

                if (W.WFIM_SINISTRO_HISTORICO == "SIM")
                {

                    /*" -676- DISPLAY 'SI0095B  - NAO HOUVE SOLICITACAO P/ EMISSAO' */
                    _.Display($"SI0095B  - NAO HOUVE SOLICITACAO P/ EMISSAO");

                    /*" -678- GO TO 000-900-FIM. */

                    M_000_900_FIM(); //GOTO
                    return Result;
                }


                /*" -679- PERFORM R100-PROCESSA-PAGAMENTOS THRU R100-EXIT UNTIL WFIM-SINISTRO-HISTORICO EQUAL 'SIM' . */

                while (!(W.WFIM_SINISTRO_HISTORICO == "SIM"))
                {

                    R100_PROCESSA_PAGAMENTOS(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -679- FLUXCONTROL_PERFORM M-000-900-FIM */

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
            /*" -686- CLOSE SI0090M1. */
            SI0090M1.Close();

            /*" -688- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -690- DISPLAY '*** SI0095B - FIM NORMAL DE PROCESSAMENTO ***' . */
            _.Display($"*** SI0095B - FIM NORMAL DE PROCESSAMENTO ***");

            /*" -690- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-LE-SISTEMA */
        private void R010_LE_SISTEMA(bool isPerform = false)
        {
            /*" -697- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", W.WABEND.WNR_EXEC_SQL);

            /*" -704- PERFORM R010_LE_SISTEMA_DB_SELECT_1 */

            R010_LE_SISTEMA_DB_SELECT_1();

            /*" -707- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -708- DISPLAY 'ERRO SELECT - SISTEMAS....................' */
                _.Display($"ERRO SELECT - SISTEMAS....................");

                /*" -710- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -711- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -712- DISPLAY '* PROGRAMA SI0095B                              *' */
            _.Display($"* PROGRAMA SI0095B                              *");

            /*" -713- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -714- DISPLAY ' ' . */
            _.Display($" ");

            /*" -715- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -720- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) '' SISTEMAS-DATA-MOV-ABERTO(8:1) '' SISTEMAS-DATA-MOV-ABERTO(6:2) '' SISTEMAS-DATA-MOV-ABERTO(5:1) '' SISTEMAS-DATA-MOV-ABERTO(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -721- DISPLAY ' ' . */
            _.Display($" ");

            /*" -722- DISPLAY 'DATA DO ULTIMO PROCESSAMENTO(SI)' . */
            _.Display($"DATA DO ULTIMO PROCESSAMENTO(SI)");

            /*" -727- DISPLAY SISTEMAS-DATULT-PROCESSAMEN(9:2) '' SISTEMAS-DATULT-PROCESSAMEN(8:1) '' SISTEMAS-DATULT-PROCESSAMEN(6:2) '' SISTEMAS-DATULT-PROCESSAMEN(5:1) '' SISTEMAS-DATULT-PROCESSAMEN(1:4). */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(1, 4)}"
            .Display();

            /*" -729- DISPLAY ' ' . */
            _.Display($" ");

            /*" -730- MOVE SISTEMAS-DATULT-PROCESSAMEN TO W-DATA-AAAA-MM-DD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN, W.W_DATA_AAAA_MM_DD);

            /*" -731- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -732- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -733- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -733- MOVE W-DATA-DD-MM-AAAA1 TO LC01-DATA. */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LC01.LC01_DATA);

        }

        [StopWatch]
        /*" R010-LE-SISTEMA-DB-SELECT-1 */
        public void R010_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -704- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -741- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", W.WABEND.WNR_EXEC_SQL);

            /*" -789- PERFORM R020_DECLARE_PAGAMENTOS_DB_DECLARE_1 */

            R020_DECLARE_PAGAMENTOS_DB_DECLARE_1();

            /*" -793- PERFORM R020_DECLARE_PAGAMENTOS_DB_OPEN_1 */

            R020_DECLARE_PAGAMENTOS_DB_OPEN_1();

            /*" -796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -797- DISPLAY 'SI0095B - ERRO NO OPEN DO CURSOR INDENIZACOES' */
                _.Display($"SI0095B - ERRO NO OPEN DO CURSOR INDENIZACOES");

                /*" -798- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -798- END-IF. */
            }


        }

        [StopWatch]
        /*" R020-DECLARE-PAGAMENTOS-DB-DECLARE-1 */
        public void R020_DECLARE_PAGAMENTOS_DB_DECLARE_1()
        {
            /*" -789- EXEC SQL DECLARE INDENIZACOES CURSOR FOR SELECT H.NUM_APOL_SINISTRO, M.NUM_APOLICE, M.DATA_OCORRENCIA, M.COD_CAUSA, S.DESCR_CAUSA, H.COD_OPERACAO, H.COD_PRODUTO, H.DATA_MOVIMENTO, H.OCORR_HISTORICO, H.VAL_OPERACAO, H.SIT_CONTABIL, L.COD_CLIENTE, C.NOME_RAZAO, C.CGCCPF, C.TIPO_PESSOA, L.COD_LOT_FENAL, L.COD_LOT_CEF, L.COD_COBERTURA, A.VALOR_INFORMADO, A.VALOR_REGISTRADO, A.VAL_IS, A.DATA_AVISO, A.VAL_ADIANTAMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 L, SEGUROS.SI_MOV_LOTERICO1 A, SEGUROS.CLIENTES C, SEGUROS.SINISTRO_CAUSA S, SEGUROS.GE_OPERACAO O WHERE H.DATA_MOVIMENTO = :SISTEMAS-DATULT-PROCESSAMEN AND H.SIT_REGISTRO = '1' AND M.NUM_APOLICE > 0107100057625 AND H.COD_PRODUTO = 7105 AND H.COD_OPERACAO IN (1002, 1003,1004,1009) AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO = 'IN' AND O.FUNCAO_OPERACAO = 'IND' AND L.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND L.COD_LOT_FENAL = L.COD_LOT_CEF AND C.COD_CLIENTE = L.COD_CLIENTE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.RAMO_EMISSOR = M.RAMO AND S.COD_CAUSA = M.COD_CAUSA ORDER BY H.NUM_APOL_SINISTRO DESC END-EXEC. */
            INDENIZACOES = new SI0095B_INDENIZACOES(true);
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
							WHERE H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}' 
							AND H.SIT_REGISTRO = '1' 
							AND M.NUM_APOLICE > 0107100057625 
							AND H.COD_PRODUTO = 7105 
							AND H.COD_OPERACAO IN (1002
							, 1003
							,1004
							,1009) 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO = 'IN' 
							AND O.FUNCAO_OPERACAO = 'IND' 
							AND L.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND L.COD_LOT_FENAL = L.COD_LOT_CEF 
							AND C.COD_CLIENTE = L.COD_CLIENTE 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND A.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND S.RAMO_EMISSOR = M.RAMO 
							AND S.COD_CAUSA = M.COD_CAUSA 
							ORDER BY H.NUM_APOL_SINISTRO DESC";

                return query;
            }
            INDENIZACOES.GetQueryEvent += GetQuery_INDENIZACOES;

        }

        [StopWatch]
        /*" R020-DECLARE-PAGAMENTOS-DB-OPEN-1 */
        public void R020_DECLARE_PAGAMENTOS_DB_OPEN_1()
        {
            /*" -793- EXEC SQL OPEN INDENIZACOES END-EXEC. */

            INDENIZACOES.Open();

        }

        [StopWatch]
        /*" R210-ENDERECO-TAB-LOTERICO01-DB-DECLARE-1 */
        public void R210_ENDERECO_TAB_LOTERICO01_DB_DECLARE_1()
        {
            /*" -1348- EXEC SQL DECLARE LOTERICO CURSOR FOR SELECT ENDERECO, COMPL_ENDERECO, BAIRRO, CEP, CIDADE, SIGLA_UF, AGENCIA, MAX(DTTERVIG) FROM SEGUROS.LOTERICO01 WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE AND COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL GROUP BY ENDERECO, COMPL_ENDERECO, BAIRRO, CEP, CIDADE, AGENCIA, SIGLA_UF ORDER BY ENDERECO, COMPL_ENDERECO, BAIRRO, CEP, CIDADE, AGENCIA, SIGLA_UF END-EXEC. */
            LOTERICO = new SI0095B_LOTERICO(true);
            string GetQuery_LOTERICO()
            {
                var query = @$"SELECT ENDERECO
							, 
							COMPL_ENDERECO
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							AGENCIA
							, 
							MAX(DTTERVIG) 
							FROM SEGUROS.LOTERICO01 
							WHERE NUM_APOLICE = '{SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}' 
							AND COD_LOT_FENAL = '{SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}' 
							GROUP BY ENDERECO
							, 
							COMPL_ENDERECO
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							AGENCIA
							, 
							SIGLA_UF 
							ORDER BY ENDERECO
							, 
							COMPL_ENDERECO
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							AGENCIA
							, 
							SIGLA_UF";

                return query;
            }
            LOTERICO.GetQueryEvent += GetQuery_LOTERICO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-PAGAMENTOS */
        private void R021_FETCH_PAGAMENTOS(bool isPerform = false)
        {
            /*" -806- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", W.WABEND.WNR_EXEC_SQL);

            /*" -830- PERFORM R021_FETCH_PAGAMENTOS_DB_FETCH_1 */

            R021_FETCH_PAGAMENTOS_DB_FETCH_1();

            /*" -833- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -834- DISPLAY 'ERRO FETCH DO CURSOR INDENIZACOES ........' */
                _.Display($"ERRO FETCH DO CURSOR INDENIZACOES ........");

                /*" -836- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -837- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -839- PERFORM R021_FETCH_PAGAMENTOS_DB_CLOSE_1 */

                R021_FETCH_PAGAMENTOS_DB_CLOSE_1();

                /*" -841- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -842- DISPLAY 'SI0095B - ERRO OPEN DO CURSOR INDENIZACOES' */
                    _.Display($"SI0095B - ERRO OPEN DO CURSOR INDENIZACOES");

                    /*" -843- GO TO M-999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -844- END-IF */
                }


                /*" -845- MOVE 'SIM' TO WFIM-SINISTRO-HISTORICO */
                _.Move("SIM", W.WFIM_SINISTRO_HISTORICO);

                /*" -845- END-IF. */
            }


        }

        [StopWatch]
        /*" R021-FETCH-PAGAMENTOS-DB-FETCH-1 */
        public void R021_FETCH_PAGAMENTOS_DB_FETCH_1()
        {
            /*" -830- EXEC SQL FETCH INDENIZACOES INTO :SINISHIS-NUM-APOL-SINISTRO, :SINISMES-NUM-APOLICE, :SINISMES-DATA-OCORRENCIA, :SINISMES-COD-CAUSA, :SINISCAU-DESCR-CAUSA, :SINISHIS-COD-OPERACAO, :SINISHIS-COD-PRODUTO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-VAL-OPERACAO, :SINISHIS-SIT-CONTABIL, :SINILT01-COD-CLIENTE, :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-TIPO-PESSOA, :SINILT01-COD-LOT-FENAL, :SINILT01-COD-LOT-CEF, :SINILT01-COD-COBERTURA, :SIMOLOT1-VALOR-INFORMADO, :SIMOLOT1-VALOR-REGISTRADO, :SIMOLOT1-VAL-IS, :SIMOLOT1-DATA-AVISO, :SIMOLOT1-VAL-ADIANTAMENTO END-EXEC. */

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
            /*" -839- EXEC SQL CLOSE INDENIZACOES END-EXEC */

            INDENIZACOES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-PAGAMENTOS */
        private void R100_PROCESSA_PAGAMENTOS(bool isPerform = false)
        {
            /*" -870- MOVE ZEROS TO LV01-VALOR-IS LV02-VALOR-INFORMADO LV03-VALOR-REGISTRADO LV04-VALOR-APURADO LV04-DATA-VALOR-APURADO LV05-VALOR-FRANQUIA LV06-VALOR-REINTEGRACAO LV07-VALOR-IOF-REINTEGRACAO LV08-VALOR-AGRAVAMENTO LV09-VALOR-IOF-AGRAVAMENTO LV10-VALOR-INDENIZACAO LV11-VALOR-ADIANTAMENTO LV12-VALOR-DIFERENCA HOST-VALOR-APURADO HOST-VALOR-FRANQUIA HOST-VALOR-REINTEG HOST-VALOR-IOF-REINTEG HOST-VALOR-AGRAV HOST-VALOR-IOF-AGRAV. */
            _.Move(0, W.LV01.LV01_VALOR_IS, W.LV02.LV02_VALOR_INFORMADO, W.LV03.LV03_VALOR_REGISTRADO, W.LV04.LV04_VALOR_APURADO, W.LV04.LV04_DATA_VALOR_APURADO, W.LV05.LV05_VALOR_FRANQUIA, W.LV06.LV06_VALOR_REINTEGRACAO, W.LV07.LV07_VALOR_IOF_REINTEGRACAO, W.LV08.LV08_VALOR_AGRAVAMENTO, W.LV09.LV09_VALOR_IOF_AGRAVAMENTO, W.LV10.LV10_VALOR_INDENIZACAO, W.LV11.LV11_VALOR_ADIANTAMENTO, W.LV12.LV12_VALOR_DIFERENCA, HOST_VALOR_APURADO, HOST_VALOR_FRANQUIA, HOST_VALOR_REINTEG, HOST_VALOR_IOF_REINTEG, HOST_VALOR_AGRAV, HOST_VALOR_IOF_AGRAV);

            /*" -872- MOVE SPACES TO LV10-DATA-EMISSAO-CHQ. */
            _.Move("", W.LV10.LV10_DATA_EMISSAO_CHQ);

            /*" -874- MOVE CLIENTES-NOME-RAZAO TO LC03-NOME-RAZAO LC58C-NOME-LOTERICO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, W.LC03.LC03_NOME_RAZAO, W.LC58C.LC58C_NOME_LOTERICO);

            /*" -875- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -876- MOVE CLIENTES-CGCCPF TO W-GDA-CPF */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, W.W_GDA_CPF);

                /*" -877- MOVE W-GDA-NUM-CPF TO W-NUM-CPF */
                _.Move(W.FILLER_124.W_GDA_NUM_CPF, W.W_CPF.W_NUM_CPF);

                /*" -878- MOVE W-GDA-DGV-CPF TO W-DGV-CPF */
                _.Move(W.FILLER_124.W_GDA_DGV_CPF, W.W_CPF.W_DGV_CPF);

                /*" -879- MOVE W-CPF TO LC58D-CPF-CNPJ */
                _.Move(W.W_CPF, W.LC58D.LC58D_CPF_CNPJ);

                /*" -880- ELSE */
            }
            else
            {


                /*" -881- MOVE CLIENTES-CGCCPF TO W-GDA-CGC */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, W.W_GDA_CGC);

                /*" -882- MOVE W-GDA-NUM-CGC TO W-NUM-CGC */
                _.Move(W.FILLER_125.W_GDA_NUM_CGC, W.W_CGC.W_NUM_CGC);

                /*" -883- MOVE W-GDA-COMPL-CGC TO W-COMPL-CGC */
                _.Move(W.FILLER_125.W_GDA_COMPL_CGC, W.W_CGC.W_COMPL_CGC);

                /*" -884- MOVE W-GDA-DGV-CGC TO W-DGV-CGC */
                _.Move(W.FILLER_125.W_GDA_DGV_CGC, W.W_CGC.W_DGV_CGC);

                /*" -886- MOVE W-CGC TO LC58D-CPF-CNPJ. */
                _.Move(W.W_CGC, W.LC58D.LC58D_CPF_CNPJ);
            }


            /*" -887- MOVE SINISHIS-NUM-APOL-SINISTRO TO LC05-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W.LC05.LC05_SINISTRO);

            /*" -888- MOVE SINISMES-NUM-APOLICE TO LC05-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, W.LC05.LC05_APOLICE);

            /*" -889- MOVE SINILT01-COD-LOT-CEF TO W-GDA-COD-LOTERICO. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, W.W_GDA_COD_LOTERICO);

            /*" -890- MOVE W-GDA-COD-CAIXA TO LC05-COD-CAIXA. */
            _.Move(W.FILLER_123.W_GDA_COD_CAIXA, W.LC05.LC05_COD_CAIXA);

            /*" -891- MOVE W-GDA-COD-LOT TO LC05-COD-LOT-CEF. */
            _.Move(W.FILLER_123.W_GDA_COD_LOT, W.LC05.LC05_COD_LOT_CEF);

            /*" -894- MOVE W-GDA-DIG-COD-LOT TO LC05-DIG-LOT-CEF. */
            _.Move(W.FILLER_123.W_GDA_DIG_COD_LOT, W.LC05.LC05_DIG_LOT_CEF);

            /*" -895- MOVE SINISMES-DATA-OCORRENCIA TO W-DATA-AAAA-MM-DD. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, W.W_DATA_AAAA_MM_DD);

            /*" -896- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -897- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -898- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -900- MOVE W-DATA-DD-MM-AAAA1 TO LC07-DATA-OCORRENCIA */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LC07.LC07_DATA_OCORRENCIA);

            /*" -901- MOVE SIMOLOT1-DATA-AVISO TO W-DATA-AAAA-MM-DD */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO, W.W_DATA_AAAA_MM_DD);

            /*" -902- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -903- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -904- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -906- MOVE W-DATA-DD-MM-AAAA1 TO LC07-DATA-AVISO */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LC07.LC07_DATA_AVISO);

            /*" -908- PERFORM R220-BUSCA-DATA-AVISO THRU R220-EXIT. */

            R220_BUSCA_DATA_AVISO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/


            /*" -909- MOVE HOST-DATA-MOVIMENTO TO W-DATA-AAAA-MM-DD */
            _.Move(HOST_DATA_MOVIMENTO, W.W_DATA_AAAA_MM_DD);

            /*" -910- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -911- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -912- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -914- MOVE W-DATA-DD-MM-AAAA1 TO LV01-DATA-AVISO-SIAS */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LV01.LV01_DATA_AVISO_SIAS);

            /*" -919- MOVE SINISCAU-DESCR-CAUSA TO LC07-DESCRICAO-CAUSA */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W.LC07.LC07_DESCRICAO_CAUSA);

            /*" -920- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -921- MOVE ZEROS TO MOVDEBCE-OPER-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

            /*" -922- MOVE ZEROS TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -923- MOVE ZEROS TO MOVDEBCE-DIG-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -924- MOVE ZEROS TO LC19A-BANCO */
            _.Move(0, W.LC19A.LC19A_BANCO);

            /*" -925- DISPLAY 'COD-COB ' SINILT01-COD-COBERTURA */
            _.Display($"COD-COB {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA}");

            /*" -926- IF SINILT01-COD-COBERTURA EQUAL 4 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA == 4)
            {

                /*" -927- PERFORM R120-ACESSA-CONTA-MOVDEBCC THRU R120-EXIT */

                R120_ACESSA_CONTA_MOVDEBCC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


                /*" -928- MOVE 104 TO LC19A-BANCO */
                _.Move(104, W.LC19A.LC19A_BANCO);

                /*" -929- END-IF */
            }


            /*" -930- MOVE MOVDEBCE-COD-AGENCIA-DEB TO LC19A-AGENCIA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, W.LC19A.LC19A_AGENCIA);

            /*" -931- MOVE MOVDEBCE-OPER-CONTA-DEB TO LC19A-OPERACAO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, W.LC19A.LC19A_OPERACAO);

            /*" -932- MOVE MOVDEBCE-NUM-CONTA-DEB TO LC19A-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, W.LC19A.LC19A_CONTA);

            /*" -934- MOVE MOVDEBCE-DIG-CONTA-DEB TO LC19A-DV */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, W.LC19A.LC19A_DV);

            /*" -935- MOVE MOVDEBCE-DATA-VENCIMENTO TO W-DATA-AAAA-MM-DD. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, W.W_DATA_AAAA_MM_DD);

            /*" -936- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -937- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -938- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -940- MOVE W-DATA-DD-MM-AAAA1 TO LC18A-DATA-VCTO. */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LC18A.LC18A_DATA_VCTO);

            /*" -941- MOVE MOVDEBCE-DATA-MOVIMENTO TO W-DATA-AAAA-MM-DD. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO, W.W_DATA_AAAA_MM_DD);

            /*" -942- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -943- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -944- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD. */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -946- MOVE W-DATA-DD-MM-AAAA1 TO LC18A-DATA-MVTO. */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LC18A.LC18A_DATA_MVTO);

            /*" -947- MOVE SIMOLOT1-VALOR-INFORMADO TO LV02-VALOR-INFORMADO. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_INFORMADO, W.LV02.LV02_VALOR_INFORMADO);

            /*" -948- MOVE SIMOLOT1-VALOR-REGISTRADO TO LV03-VALOR-REGISTRADO. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VALOR_REGISTRADO, W.LV03.LV03_VALOR_REGISTRADO);

            /*" -949- MOVE SIMOLOT1-VAL-IS TO LV01-VALOR-IS. */
            _.Move(SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_VAL_IS, W.LV01.LV01_VALOR_IS);

            /*" -951- MOVE SINISHIS-VAL-OPERACAO TO LV10-VALOR-INDENIZACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, W.LV10.LV10_VALOR_INDENIZACAO);

            /*" -952- PERFORM R130-VALOR-APURADO THRU R130-EXIT. */

            R130_VALOR_APURADO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


            /*" -954- MOVE HOST-VALOR-APURADO TO LV04-VALOR-APURADO */
            _.Move(HOST_VALOR_APURADO, W.LV04.LV04_VALOR_APURADO);

            /*" -955- MOVE HOST-DATA-VALOR-APURADO TO W-DATA-AAAA-MM-DD */
            _.Move(HOST_DATA_VALOR_APURADO, W.W_DATA_AAAA_MM_DD);

            /*" -956- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

            /*" -957- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

            /*" -958- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
            _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

            /*" -960- MOVE W-DATA-DD-MM-AAAA1 TO LV04-DATA-VALOR-APURADO */
            _.Move(W.W_DATA_DD_MM_AAAA1, W.LV04.LV04_DATA_VALOR_APURADO);

            /*" -961- PERFORM R140-VALOR-FRANQUIA THRU R140-EXIT. */

            R140_VALOR_FRANQUIA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/


            /*" -963- MOVE HOST-VALOR-FRANQUIA TO LV05-VALOR-FRANQUIA */
            _.Move(HOST_VALOR_FRANQUIA, W.LV05.LV05_VALOR_FRANQUIA);

            /*" -964- PERFORM R150-VALOR-REINTEG THRU R150-EXIT. */

            R150_VALOR_REINTEG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/


            /*" -966- MOVE HOST-VALOR-REINTEG TO LV06-VALOR-REINTEGRACAO */
            _.Move(HOST_VALOR_REINTEG, W.LV06.LV06_VALOR_REINTEGRACAO);

            /*" -967- PERFORM R160-VALOR-IOF-REINTEG THRU R160-EXIT. */

            R160_VALOR_IOF_REINTEG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


            /*" -969- MOVE HOST-VALOR-IOF-REINTEG TO LV07-VALOR-IOF-REINTEGRACAO */
            _.Move(HOST_VALOR_IOF_REINTEG, W.LV07.LV07_VALOR_IOF_REINTEGRACAO);

            /*" -970- PERFORM R170-VALOR-AGRAV THRU R170-EXIT. */

            R170_VALOR_AGRAV(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/


            /*" -972- MOVE HOST-VALOR-AGRAV TO LV08-VALOR-AGRAVAMENTO */
            _.Move(HOST_VALOR_AGRAV, W.LV08.LV08_VALOR_AGRAVAMENTO);

            /*" -973- PERFORM R180-VALOR-IOF-AGRAV THRU R180-EXIT. */

            R180_VALOR_IOF_AGRAV(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R180_EXIT*/


            /*" -975- MOVE HOST-VALOR-IOF-AGRAV TO LV09-VALOR-IOF-AGRAVAMENTO */
            _.Move(HOST_VALOR_IOF_AGRAV, W.LV09.LV09_VALOR_IOF_AGRAVAMENTO);

            /*" -976- INITIALIZE DCLLOTERICO01 */
            _.Initialize(
                LOTERI01.DCLLOTERICO01
            );

            /*" -977- IF SINISMES-NUM-APOLICE >= 107100057625 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE >= 107100057625)
            {

                /*" -978- PERFORM R210-ENDERECO-TAB-LOTERICO01 THRU R210-EXIT */

                R210_ENDERECO_TAB_LOTERICO01(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


                /*" -980- END-IF. */
            }


            /*" -981- MOVE LOTERI01-ENDERECO TO LC03A-ENDERECO */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO, W.LC03A.LC03A_ENDERECO);

            /*" -982- MOVE LOTERI01-COMPL-ENDERECO TO LC03A-COMPL-ENDERECO */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COMPL_ENDERECO, W.LC03A.LC03A_COMPL_ENDERECO);

            /*" -983- MOVE LOTERI01-BAIRRO TO LC03B-BAIRRO */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_BAIRRO, W.LC03B.LC03B_BAIRRO);

            /*" -984- MOVE LOTERI01-CEP TO LC03B-CEP */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CEP, W.LC03B.LC03B_CEP);

            /*" -985- MOVE LOTERI01-CIDADE TO LC03B-CIDADE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE, W.LC03B.LC03B_CIDADE);

            /*" -987- MOVE LOTERI01-SIGLA-UF TO LC03B-SIGLA-UF. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF, W.LC03B.LC03B_SIGLA_UF);

            /*" -988- MOVE LOTERI01-AGENCIA TO LCEGB-DESTINATARIO */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA, W.LCEGB.LCEGB_DESTINATARIO);

            /*" -989- MOVE 'RECIBO_SI0095B' TO LCEGD-NOME-ARQ */
            _.Move("RECIBO_SI0095B", W.LCEGD.LCEGD_NOME_ARQ);

            /*" -990- MOVE CLIENTES-NOME-RAZAO TO LCEGF-ASSUNTO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, W.LCEGF.LCEGF_ASSUNTO);

            /*" -993- ADD 1 TO LCEGD-SEQ-ARQ. */
            W.LCEGD.LCEGD_SEQ_ARQ.Value = W.LCEGD.LCEGD_SEQ_ARQ + 1;

            /*" -994- IF SINILT01-COD-COBERTURA NOT EQUAL 4 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA != 4)
            {

                /*" -996- MOVE ZEROS TO LV11-VALOR-ADIANTAMENTO LV12-VALOR-DIFERENCA */
                _.Move(0, W.LV11.LV11_VALOR_ADIANTAMENTO, W.LV12.LV12_VALOR_DIFERENCA);

                /*" -999- MOVE ALL '.' TO LV12-CREDITO-DEBITO LV11-ADIANTAMENTO LV12-CREDITO-DEBITO */
                _.MoveAll(".", W.LV12.LV12_CREDITO_DEBITO, W.LV11.LV11_ADIANTAMENTO, W.LV12.LV12_CREDITO_DEBITO);

                /*" -1000- MOVE '???????' TO LC18A-CREDITO-DEBITO */
                _.Move("???????", W.LC18A.LC18A_CREDITO_DEBITO);

                /*" -1001- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.W_DATA_AAAA_MM_DD);

                /*" -1002- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
                _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

                /*" -1003- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
                _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

                /*" -1004- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
                _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

                /*" -1006- MOVE W-DATA-DD-MM-AAAA1 TO LV10-DATA-EMISSAO-CHQ. */
                _.Move(W.W_DATA_DD_MM_AAAA1, W.LV10.LV10_DATA_EMISSAO_CHQ);
            }


            /*" -1007- IF SINILT01-COD-COBERTURA EQUAL 4 */

            if (SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_COBERTURA == 4)
            {

                /*" -1008- PERFORM R190-VALOR-ADIANTAMENTO THRU R190-EXIT */

                R190_VALOR_ADIANTAMENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R190_EXIT*/


                /*" -1009- MOVE HOST-VALOR-ADIANTAMENTO TO LV11-VALOR-ADIANTAMENTO */
                _.Move(HOST_VALOR_ADIANTAMENTO, W.LV11.LV11_VALOR_ADIANTAMENTO);

                /*" -1010- IF HOST-VALOR-ADIANTAMENTO NOT EQUAL 0 */

                if (HOST_VALOR_ADIANTAMENTO != 0)
                {

                    /*" -1011- MOVE HOST-DATA-ADIANTAMENTO TO W-DATA-AAAA-MM-DD */
                    _.Move(HOST_DATA_ADIANTAMENTO, W.W_DATA_AAAA_MM_DD);

                    /*" -1012- MOVE W-DATA-AAAA-MM-DD-DD TO W-DATA-DD-MM-AAAA1-DD */
                    _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_DD);

                    /*" -1013- MOVE W-DATA-AAAA-MM-DD-MM TO W-DATA-DD-MM-AAAA1-MM */
                    _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_MM, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_MM);

                    /*" -1014- MOVE W-DATA-AAAA-MM-DD-AAAA TO W-DATA-DD-MM-AAAA1-AAAA */
                    _.Move(W.W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_AAAA, W.W_DATA_DD_MM_AAAA1.W_DATA_DD_MM_AAAA1_AAAA);

                    /*" -1015- MOVE W-DATA-DD-MM-AAAA1 TO LV11-DATA-ADIANTAMENTO */
                    _.Move(W.W_DATA_DD_MM_AAAA1, W.LV11.LV11_ADIANTAMENTO.LV11_DATA_ADIANTAMENTO);

                    /*" -1016- MOVE ' EM ' TO LV11-TEXTO-ADIANTAMENTO */
                    _.Move(" EM ", W.LV11.LV11_ADIANTAMENTO.LV11_TEXTO_ADIANTAMENTO);

                    /*" -1017- ELSE */
                }
                else
                {


                    /*" -1018- MOVE ALL '.' TO LV11-ADIANTAMENTO */
                    _.MoveAll(".", W.LV11.LV11_ADIANTAMENTO);

                    /*" -1020- END-IF */
                }


                /*" -1021- PERFORM R200-VALOR-DIFERENCA THRU R200-EXIT */

                R200_VALOR_DIFERENCA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


                /*" -1022- MOVE HOST-VALOR-DIFERENCA TO LV12-VALOR-DIFERENCA */
                _.Move(HOST_VALOR_DIFERENCA, W.LV12.LV12_VALOR_DIFERENCA);

                /*" -1023- IF HOST-VALOR-DIFERENCA < ZERO */

                if (HOST_VALOR_DIFERENCA < 00)
                {

                    /*" -1024- MOVE '(DEBITO)' TO LV12-CREDITO-DEBITO */
                    _.Move("(DEBITO)", W.LV12.LV12_CREDITO_DEBITO);

                    /*" -1025- MOVE 'DEBITO' TO LC18A-CREDITO-DEBITO */
                    _.Move("DEBITO", W.LC18A.LC18A_CREDITO_DEBITO);

                    /*" -1026- ELSE */
                }
                else
                {


                    /*" -1027- IF HOST-VALOR-DIFERENCA = ZERO */

                    if (HOST_VALOR_DIFERENCA == 00)
                    {

                        /*" -1028- MOVE '(S/ MOV.)' TO LV12-CREDITO-DEBITO */
                        _.Move("(S/ MOV.)", W.LV12.LV12_CREDITO_DEBITO);

                        /*" -1029- MOVE 'S/ MOV.' TO LC18A-CREDITO-DEBITO */
                        _.Move("S/ MOV.", W.LC18A.LC18A_CREDITO_DEBITO);

                        /*" -1030- ELSE */
                    }
                    else
                    {


                        /*" -1031- MOVE '(CREDITO)' TO LV12-CREDITO-DEBITO */
                        _.Move("(CREDITO)", W.LV12.LV12_CREDITO_DEBITO);

                        /*" -1033- MOVE 'CREDITO' TO LC18A-CREDITO-DEBITO. */
                        _.Move("CREDITO", W.LC18A.LC18A_CREDITO_DEBITO);
                    }

                }

            }


            /*" -1035- PERFORM R1000-IMPRIME-RECIBO THRU R1000-EXIT. */

            R1000_IMPRIME_RECIBO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


            /*" -1035- PERFORM R021-FETCH-PAGAMENTOS THRU R021-EXIT. */

            R021_FETCH_PAGAMENTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-ACESSA-OPERACAO-SICOV */
        private void R110_ACESSA_OPERACAO_SICOV(bool isPerform = false)
        {
            /*" -1043- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", W.WABEND.WNR_EXEC_SQL);

            /*" -1044- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1046- ADD 70 TO HOST-COD-OPERACAO. */
            HOST_COD_OPERACAO.Value = HOST_COD_OPERACAO + 70;

            /*" -1054- PERFORM R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1 */

            R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1();

            /*" -1057- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1058- DISPLAY 'SI0095B - ERRO ACESSO A OPERACAO DE SICOV (1)..' */
                _.Display($"SI0095B - ERRO ACESSO A OPERACAO DE SICOV (1)..");

                /*" -1059- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1060- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1061- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1061- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R110-ACESSA-OPERACAO-SICOV-DB-SELECT-1 */
        public void R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1()
        {
            /*" -1054- EXEC SQL SELECT COD_OPERACAO INTO :HOST-COD-OPERACAO-SICOV FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :HOST-COD-OPERACAO AND SIT_REGISTRO = '1' END-EXEC. */

            var r110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1 = new R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                HOST_COD_OPERACAO = HOST_COD_OPERACAO.ToString(),
            };

            var executed_1 = R110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1.Execute(r110_ACESSA_OPERACAO_SICOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COD_OPERACAO_SICOV, HOST_COD_OPERACAO_SICOV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-ACESSA-CONTA-MOVDEBCC */
        private void R120_ACESSA_CONTA_MOVDEBCC(bool isPerform = false)
        {
            /*" -1069- MOVE SINISHIS-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1070- MOVE ZEROS TO W-PRODUTO-OPERACAO. */
            _.Move(0, W.W_PRODUTO_OPERACAO);

            /*" -1072- MOVE SINISHIS-COD-PRODUTO TO W-PRODUTO-OPERACAO-PRODUTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, W.FILLER_129.W_PRODUTO_OPERACAO_PRODUTO);

            /*" -1073- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO-SICOV */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO_SICOV);

            /*" -1074- ADD 70 TO HOST-COD-OPERACAO-SICOV */
            HOST_COD_OPERACAO_SICOV.Value = HOST_COD_OPERACAO_SICOV + 70;

            /*" -1077- MOVE HOST-COD-OPERACAO-SICOV TO W-PRODUTO-OPERACAO-OPERACAO */
            _.Move(HOST_COD_OPERACAO_SICOV, W.FILLER_129.W_PRODUTO_OPERACAO_OPERACAO);

            /*" -1078- MOVE SINISHIS-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1079- MOVE W-PRODUTO-OPERACAO TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(W.W_PRODUTO_OPERACAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -1081- MOVE SINISHIS-OCORR-HISTORICO TO MOVDEBCE-NUM-PARCELA */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -1083- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", W.WABEND.WNR_EXEC_SQL);

            /*" -1105- PERFORM R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1 */

            R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1();

            /*" -1108- DISPLAY 'M.NUM_APOLICE       ' MOVDEBCE-NUM-APOLICE */
            _.Display($"M.NUM_APOLICE       {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

            /*" -1109- DISPLAY 'M.NUM_ENDOSSO       ' MOVDEBCE-NUM-ENDOSSO */
            _.Display($"M.NUM_ENDOSSO       {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

            /*" -1110- DISPLAY 'M.NUM_PARCELA       ' MOVDEBCE-NUM-PARCELA */
            _.Display($"M.NUM_PARCELA       {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

            /*" -1111- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1112- DISPLAY 'SI0095B - ERRO ACESSO MOVTO_DEBITOCC_CEF  (1)..' */
                _.Display($"SI0095B - ERRO ACESSO MOVTO_DEBITOCC_CEF  (1)..");

                /*" -1113- DISPLAY 'NUM_APOLICE        = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE        = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1114- DISPLAY 'NUM_ENDOSSO        = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO        = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1115- DISPLAY 'NUM_PARCELA        = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA        = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1116- DISPLAY 'SQLCODE            = ' SQLCODE */
                _.Display($"SQLCODE            = {DB.SQLCODE}");

                /*" -1116- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R120-ACESSA-CONTA-MOVDEBCC-DB-SELECT-1 */
        public void R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1()
        {
            /*" -1105- EXEC SQL SELECT M.COD_AGENCIA_DEB, M.OPER_CONTA_DEB, M.NUM_CONTA_DEB, M.DIG_CONTA_DEB, M.DATA_MOVIMENTO, M.DATA_VENCIMENTO INTO :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-DATA-MOVIMENTO, :MOVDEBCE-DATA-VENCIMENTO FROM SEGUROS.MOVTO_DEBITOCC_CEF M WHERE M.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND M.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND M.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND M.NSAS = (SELECT MAX(X.NSAS) FROM SEGUROS.MOVTO_DEBITOCC_CEF X WHERE X.NUM_APOLICE = M.NUM_APOLICE AND X.NUM_ENDOSSO = M.NUM_ENDOSSO AND X.NUM_PARCELA = M.NUM_PARCELA) END-EXEC. */

            var r120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1 = new R120_ACESSA_CONTA_MOVDEBCC_DB_SELECT_1_Query1()
            {
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
                _.Move(executed_1.MOVDEBCE_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-VALOR-APURADO */
        private void R130_VALOR_APURADO(bool isPerform = false)
        {
            /*" -1124- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", W.WABEND.WNR_EXEC_SQL);

            /*" -1125- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1127- ADD 180 TO HOST-COD-OPERACAO. */
            HOST_COD_OPERACAO.Value = HOST_COD_OPERACAO + 180;

            /*" -1136- PERFORM R130_VALOR_APURADO_DB_SELECT_1 */

            R130_VALOR_APURADO_DB_SELECT_1();

            /*" -1139- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1140- DISPLAY 'ERRO ACESSO A PRE-LIBERACAO ...................' */
                _.Display($"ERRO ACESSO A PRE-LIBERACAO ...................");

                /*" -1141- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1142- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1143- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1143- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R130-VALOR-APURADO-DB-SELECT-1 */
        public void R130_VALOR_APURADO_DB_SELECT_1()
        {
            /*" -1136- EXEC SQL SELECT VAL_OPERACAO, DATA_MOVIMENTO INTO :HOST-VALOR-APURADO, :HOST-DATA-VALOR-APURADO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :HOST-COD-OPERACAO END-EXEC. */

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
                _.Move(executed_1.HOST_DATA_VALOR_APURADO, HOST_DATA_VALOR_APURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R140-VALOR-FRANQUIA */
        private void R140_VALOR_FRANQUIA(bool isPerform = false)
        {
            /*" -1151- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", W.WABEND.WNR_EXEC_SQL);

            /*" -1158- PERFORM R140_VALOR_FRANQUIA_DB_SELECT_1 */

            R140_VALOR_FRANQUIA_DB_SELECT_1();

            /*" -1161- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1162- DISPLAY 'ERRO SELECT SINI_ABAT_LOT02 (FRANQUIA) ........' */
                _.Display($"ERRO SELECT SINI_ABAT_LOT02 (FRANQUIA) ........");

                /*" -1163- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1164- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1165- DISPLAY 'COD_RETENCAO       =   1' */
                _.Display($"COD_RETENCAO       =   1");

                /*" -1165- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R140-VALOR-FRANQUIA-DB-SELECT-1 */
        public void R140_VALOR_FRANQUIA_DB_SELECT_1()
        {
            /*" -1158- EXEC SQL SELECT VALUE(VALOR_RETENCAO * -1,0) INTO :HOST-VALOR-FRANQUIA FROM SEGUROS.SINI_LOT_ABAT02 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_RETENCAO = '1' END-EXEC. */

            var r140_VALOR_FRANQUIA_DB_SELECT_1_Query1 = new R140_VALOR_FRANQUIA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R140_VALOR_FRANQUIA_DB_SELECT_1_Query1.Execute(r140_VALOR_FRANQUIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_FRANQUIA, HOST_VALOR_FRANQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/

        [StopWatch]
        /*" R150-VALOR-REINTEG */
        private void R150_VALOR_REINTEG(bool isPerform = false)
        {
            /*" -1173- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", W.WABEND.WNR_EXEC_SQL);

            /*" -1180- PERFORM R150_VALOR_REINTEG_DB_SELECT_1 */

            R150_VALOR_REINTEG_DB_SELECT_1();

            /*" -1183- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1184- DISPLAY 'ERRO SELECT SINI_ABAT_LOT02 (REINTEGRACAO).....' */
                _.Display($"ERRO SELECT SINI_ABAT_LOT02 (REINTEGRACAO).....");

                /*" -1185- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1186- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1187- DISPLAY 'COD_RETENCAO       =   2' */
                _.Display($"COD_RETENCAO       =   2");

                /*" -1187- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R150-VALOR-REINTEG-DB-SELECT-1 */
        public void R150_VALOR_REINTEG_DB_SELECT_1()
        {
            /*" -1180- EXEC SQL SELECT VALUE(VALOR_RETENCAO * -1,0) INTO :HOST-VALOR-REINTEG FROM SEGUROS.SINI_LOT_ABAT02 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_RETENCAO = '2' END-EXEC. */

            var r150_VALOR_REINTEG_DB_SELECT_1_Query1 = new R150_VALOR_REINTEG_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R150_VALOR_REINTEG_DB_SELECT_1_Query1.Execute(r150_VALOR_REINTEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_REINTEG, HOST_VALOR_REINTEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/

        [StopWatch]
        /*" R160-VALOR-IOF-REINTEG */
        private void R160_VALOR_IOF_REINTEG(bool isPerform = false)
        {
            /*" -1195- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", W.WABEND.WNR_EXEC_SQL);

            /*" -1202- PERFORM R160_VALOR_IOF_REINTEG_DB_SELECT_1 */

            R160_VALOR_IOF_REINTEG_DB_SELECT_1();

            /*" -1205- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1206- DISPLAY 'ERRO SELECT SINI_ABAT_LOT02 (IOF REINTEG).......' */
                _.Display($"ERRO SELECT SINI_ABAT_LOT02 (IOF REINTEG).......");

                /*" -1207- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1208- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1209- DISPLAY 'COD_RETENCAO       =   3' */
                _.Display($"COD_RETENCAO       =   3");

                /*" -1209- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R160-VALOR-IOF-REINTEG-DB-SELECT-1 */
        public void R160_VALOR_IOF_REINTEG_DB_SELECT_1()
        {
            /*" -1202- EXEC SQL SELECT VALUE(VALOR_RETENCAO * -1,0) INTO :HOST-VALOR-IOF-REINTEG FROM SEGUROS.SINI_LOT_ABAT02 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_RETENCAO = '3' END-EXEC. */

            var r160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1 = new R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1.Execute(r160_VALOR_IOF_REINTEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_IOF_REINTEG, HOST_VALOR_IOF_REINTEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/

        [StopWatch]
        /*" R170-VALOR-AGRAV */
        private void R170_VALOR_AGRAV(bool isPerform = false)
        {
            /*" -1217- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", W.WABEND.WNR_EXEC_SQL);

            /*" -1224- PERFORM R170_VALOR_AGRAV_DB_SELECT_1 */

            R170_VALOR_AGRAV_DB_SELECT_1();

            /*" -1227- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1228- DISPLAY 'ERRO SELECT SINI_ABAT_LOT02 (AGRAV).............' */
                _.Display($"ERRO SELECT SINI_ABAT_LOT02 (AGRAV).............");

                /*" -1229- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1230- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1231- DISPLAY 'COD_RETENCAO       =   5' */
                _.Display($"COD_RETENCAO       =   5");

                /*" -1231- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R170-VALOR-AGRAV-DB-SELECT-1 */
        public void R170_VALOR_AGRAV_DB_SELECT_1()
        {
            /*" -1224- EXEC SQL SELECT VALUE(SUM(VALOR_RETENCAO * -1),0) INTO :HOST-VALOR-AGRAV FROM SEGUROS.SINI_LOT_ABAT02 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_RETENCAO = '5' END-EXEC. */

            var r170_VALOR_AGRAV_DB_SELECT_1_Query1 = new R170_VALOR_AGRAV_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R170_VALOR_AGRAV_DB_SELECT_1_Query1.Execute(r170_VALOR_AGRAV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_AGRAV, HOST_VALOR_AGRAV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

        [StopWatch]
        /*" R180-VALOR-IOF-AGRAV */
        private void R180_VALOR_IOF_AGRAV(bool isPerform = false)
        {
            /*" -1239- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", W.WABEND.WNR_EXEC_SQL);

            /*" -1246- PERFORM R180_VALOR_IOF_AGRAV_DB_SELECT_1 */

            R180_VALOR_IOF_AGRAV_DB_SELECT_1();

            /*" -1249- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1250- DISPLAY 'ERRO SELECT SINI_ABAT_LOT02 (IOF AGRAV).........' */
                _.Display($"ERRO SELECT SINI_ABAT_LOT02 (IOF AGRAV).........");

                /*" -1251- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1252- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1253- DISPLAY 'COD_RETENCAO       =   6' */
                _.Display($"COD_RETENCAO       =   6");

                /*" -1253- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R180-VALOR-IOF-AGRAV-DB-SELECT-1 */
        public void R180_VALOR_IOF_AGRAV_DB_SELECT_1()
        {
            /*" -1246- EXEC SQL SELECT VALUE(SUM(VALOR_RETENCAO * -1),0) INTO :HOST-VALOR-IOF-AGRAV FROM SEGUROS.SINI_LOT_ABAT02 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_RETENCAO = '6' END-EXEC. */

            var r180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1 = new R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1.Execute(r180_VALOR_IOF_AGRAV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_IOF_AGRAV, HOST_VALOR_IOF_AGRAV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R180_EXIT*/

        [StopWatch]
        /*" R190-VALOR-ADIANTAMENTO */
        private void R190_VALOR_ADIANTAMENTO(bool isPerform = false)
        {
            /*" -1261- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", W.WABEND.WNR_EXEC_SQL);

            /*" -1263- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1280- PERFORM R190_VALOR_ADIANTAMENTO_DB_SELECT_1 */

            R190_VALOR_ADIANTAMENTO_DB_SELECT_1();

            /*" -1283- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1284- DISPLAY 'ERRO ACESSO AO ADIANTAMENTO ...................' */
                _.Display($"ERRO ACESSO AO ADIANTAMENTO ...................");

                /*" -1285- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1286- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1287- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1287- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R190-VALOR-ADIANTAMENTO-DB-SELECT-1 */
        public void R190_VALOR_ADIANTAMENTO_DB_SELECT_1()
        {
            /*" -1280- EXEC SQL SELECT VALUE(B.VAL_OPERACAO * -1,0), B.DATA_MOVIMENTO INTO :HOST-VALOR-ADIANTAMENTO, :HOST-DATA-ADIANTAMENTO FROM SEGUROS.SINISTRO_HISTORICO B WHERE B.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.COD_OPERACAO = 1070 AND B.SIT_REGISTRO = '2' AND B.OCORR_HISTORICO = (SELECT DISTINCT A.OCORR_HISTORICO FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.COD_OPERACAO = 1050 AND A.SIT_REGISTRO = '0' ) END-EXEC. */

            var r190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1 = new R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1.Execute(r190_VALOR_ADIANTAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR_ADIANTAMENTO, HOST_VALOR_ADIANTAMENTO);
                _.Move(executed_1.HOST_DATA_ADIANTAMENTO, HOST_DATA_ADIANTAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R190_EXIT*/

        [StopWatch]
        /*" R200-VALOR-DIFERENCA */
        private void R200_VALOR_DIFERENCA(bool isPerform = false)
        {
            /*" -1295- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", W.WABEND.WNR_EXEC_SQL);

            /*" -1296- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1298- ADD 70 TO HOST-COD-OPERACAO. */
            HOST_COD_OPERACAO.Value = HOST_COD_OPERACAO + 70;

            /*" -1306- PERFORM R200_VALOR_DIFERENCA_DB_SELECT_1 */

            R200_VALOR_DIFERENCA_DB_SELECT_1();

            /*" -1309- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1310- DISPLAY 'ERRO ACESSO A DIFERENCA DE INDENIZACAO.........' */
                _.Display($"ERRO ACESSO A DIFERENCA DE INDENIZACAO.........");

                /*" -1311- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1312- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1313- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1313- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R200-VALOR-DIFERENCA-DB-SELECT-1 */
        public void R200_VALOR_DIFERENCA_DB_SELECT_1()
        {
            /*" -1306- EXEC SQL SELECT VAL_OPERACAO INTO :HOST-VALOR-DIFERENCA FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :HOST-COD-OPERACAO AND SIT_REGISTRO = '1' END-EXEC. */

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
        /*" R210-ENDERECO-TAB-LOTERICO01 */
        private void R210_ENDERECO_TAB_LOTERICO01(bool isPerform = false)
        {
            /*" -1321- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", W.WABEND.WNR_EXEC_SQL);

            /*" -1348- PERFORM R210_ENDERECO_TAB_LOTERICO01_DB_DECLARE_1 */

            R210_ENDERECO_TAB_LOTERICO01_DB_DECLARE_1();

            /*" -1352- PERFORM R210_ENDERECO_TAB_LOTERICO01_DB_OPEN_1 */

            R210_ENDERECO_TAB_LOTERICO01_DB_OPEN_1();

            /*" -1355- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1356- DISPLAY 'SI0095B - ERRO OPEN CURSOR LOTERICO' */
                _.Display($"SI0095B - ERRO OPEN CURSOR LOTERICO");

                /*" -1357- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1359- END-IF. */
            }


            /*" -1369- PERFORM R210_ENDERECO_TAB_LOTERICO01_DB_FETCH_1 */

            R210_ENDERECO_TAB_LOTERICO01_DB_FETCH_1();

            /*" -1372- IF SQLCODE NOT EQUAL ZERO AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1373- DISPLAY 'ERRO ACESSO AO ENDERECO (LOTERICO01)' */
                _.Display($"ERRO ACESSO AO ENDERECO (LOTERICO01)");

                /*" -1374- DISPLAY 'NUM_APOLICE        = ' SINISMES-NUM-APOLICE */
                _.Display($"NUM_APOLICE        = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1375- DISPLAY 'COD_LOT_FENAL      = ' SINILT01-COD-LOT-FENAL */
                _.Display($"COD_LOT_FENAL      = {SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_FENAL}");

                /*" -1376- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1377- DISPLAY 'OCORR_HISTORICO    = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO    = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1378- DISPLAY 'COD_OPERACAO       = ' HOST-COD-OPERACAO */
                _.Display($"COD_OPERACAO       = {HOST_COD_OPERACAO}");

                /*" -1379- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1381- END-IF. */
            }


            /*" -1383- PERFORM R210_ENDERECO_TAB_LOTERICO01_DB_CLOSE_1 */

            R210_ENDERECO_TAB_LOTERICO01_DB_CLOSE_1();

            /*" -1386- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1387- DISPLAY 'SI0095B - ERRO OPEN CLOSE LOTERICO' */
                _.Display($"SI0095B - ERRO OPEN CLOSE LOTERICO");

                /*" -1388- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1388- END-IF. */
            }


        }

        [StopWatch]
        /*" R210-ENDERECO-TAB-LOTERICO01-DB-OPEN-1 */
        public void R210_ENDERECO_TAB_LOTERICO01_DB_OPEN_1()
        {
            /*" -1352- EXEC SQL OPEN LOTERICO END-EXEC. */

            LOTERICO.Open();

        }

        [StopWatch]
        /*" R210-ENDERECO-TAB-LOTERICO01-DB-FETCH-1 */
        public void R210_ENDERECO_TAB_LOTERICO01_DB_FETCH_1()
        {
            /*" -1369- EXEC SQL FETCH LOTERICO INTO :LOTERI01-ENDERECO, :LOTERI01-COMPL-ENDERECO, :LOTERI01-BAIRRO, :LOTERI01-CEP, :LOTERI01-CIDADE, :LOTERI01-SIGLA-UF, :LOTERI01-AGENCIA, :LOTERI01-DTTERVIG END-EXEC. */

            if (LOTERICO.Fetch())
            {
                _.Move(LOTERICO.LOTERI01_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO);
                _.Move(LOTERICO.LOTERI01_COMPL_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_COMPL_ENDERECO);
                _.Move(LOTERICO.LOTERI01_BAIRRO, LOTERI01.DCLLOTERICO01.LOTERI01_BAIRRO);
                _.Move(LOTERICO.LOTERI01_CEP, LOTERI01.DCLLOTERICO01.LOTERI01_CEP);
                _.Move(LOTERICO.LOTERI01_CIDADE, LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE);
                _.Move(LOTERICO.LOTERI01_SIGLA_UF, LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF);
                _.Move(LOTERICO.LOTERI01_AGENCIA, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA);
                _.Move(LOTERICO.LOTERI01_DTTERVIG, LOTERI01.DCLLOTERICO01.LOTERI01_DTTERVIG);
            }

        }

        [StopWatch]
        /*" R210-ENDERECO-TAB-LOTERICO01-DB-CLOSE-1 */
        public void R210_ENDERECO_TAB_LOTERICO01_DB_CLOSE_1()
        {
            /*" -1383- EXEC SQL CLOSE LOTERICO END-EXEC. */

            LOTERICO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R220-BUSCA-DATA-AVISO */
        private void R220_BUSCA_DATA_AVISO(bool isPerform = false)
        {
            /*" -1397- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", W.WABEND.WNR_EXEC_SQL);

            /*" -1403- PERFORM R220_BUSCA_DATA_AVISO_DB_SELECT_1 */

            R220_BUSCA_DATA_AVISO_DB_SELECT_1();

            /*" -1406- IF SQLCODE NOT EQUAL ZERO AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1407- DISPLAY 'ERRO ACESSO A DATA AVISO.........' */
                _.Display($"ERRO ACESSO A DATA AVISO.........");

                /*" -1408- DISPLAY 'NUM_APOL_SINISTRO  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1409- DISPLAY 'COD_OPERACAO       = 101' */
                _.Display($"COD_OPERACAO       = 101");

                /*" -1410- GO TO M-999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1410- END-IF. */
            }


        }

        [StopWatch]
        /*" R220-BUSCA-DATA-AVISO-DB-SELECT-1 */
        public void R220_BUSCA_DATA_AVISO_DB_SELECT_1()
        {
            /*" -1403- EXEC SQL SELECT DATA_MOVIMENTO INTO :HOST-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 END-EXEC. */

            var r220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1 = new R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1.Execute(r220_BUSCA_DATA_AVISO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_MOVIMENTO, HOST_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R220_EXIT*/

        [StopWatch]
        /*" R1000-IMPRIME-RECIBO */
        private void R1000_IMPRIME_RECIBO(bool isPerform = false)
        {
            /*" -1418- WRITE REG-SI0090M1 FROM LCEG */
            _.Move(W.LCEG.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1419- WRITE REG-SI0090M1 FROM LCEGA */
            _.Move(W.LCEGA.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1420- WRITE REG-SI0090M1 FROM LCEGB1 */
            _.Move(W.LCEGB1.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1421- WRITE REG-SI0090M1 FROM LCEGB2 */
            _.Move(W.LCEGB2.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1422- WRITE REG-SI0090M1 FROM LCEGB3 */
            _.Move(W.LCEGB3.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1423- WRITE REG-SI0090M1 FROM LCEGB */
            _.Move(W.LCEGB.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1424- WRITE REG-SI0090M1 FROM LCEGE. */
            _.Move(W.LCEGE.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1425- WRITE REG-SI0090M1 FROM LCEGF. */
            _.Move(W.LCEGF.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1426- WRITE REG-SI0090M1 FROM LCEGC. */
            _.Move(W.LCEGC.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1428- WRITE REG-SI0090M1 FROM LCEGD. */
            _.Move(W.LCEGD.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1429- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1430- WRITE REG-SI0090M1 FROM LC01. */
            _.Move(W.LC01.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1431- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1432- WRITE REG-SI0090M1 FROM LC02. */
            _.Move(W.LC02.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1433- WRITE REG-SI0090M1 FROM LC00-BRANCO */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1434- WRITE REG-SI0090M1 FROM LC00-BRANCO */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1435- WRITE REG-SI0090M1 FROM LC03. */
            _.Move(W.LC03.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1436- WRITE REG-SI0090M1 FROM LC03A. */
            _.Move(W.LC03A.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1437- WRITE REG-SI0090M1 FROM LC03B. */
            _.Move(W.LC03B.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1438- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1439- WRITE REG-SI0090M1 FROM LC04. */
            _.Move(W.LC04.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1440- WRITE REG-SI0090M1 FROM LC05. */
            _.Move(W.LC05.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1441- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1442- WRITE REG-SI0090M1 FROM LC06. */
            _.Move(W.LC06.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1443- WRITE REG-SI0090M1 FROM LC07. */
            _.Move(W.LC07.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1444- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1445- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1446- WRITE REG-SI0090M1 FROM LC08. */
            _.Move(W.LC08.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1447- WRITE REG-SI0090M1 FROM LV01. */
            _.Move(W.LV01.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1448- WRITE REG-SI0090M1 FROM LV03. */
            _.Move(W.LV03.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1449- WRITE REG-SI0090M1 FROM LV02. */
            _.Move(W.LV02.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1450- WRITE REG-SI0090M1 FROM LV04. */
            _.Move(W.LV04.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1451- WRITE REG-SI0090M1 FROM LV05. */
            _.Move(W.LV05.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1452- WRITE REG-SI0090M1 FROM LV06. */
            _.Move(W.LV06.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1453- WRITE REG-SI0090M1 FROM LV07. */
            _.Move(W.LV07.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1454- WRITE REG-SI0090M1 FROM LV08. */
            _.Move(W.LV08.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1455- WRITE REG-SI0090M1 FROM LV09. */
            _.Move(W.LV09.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1456- WRITE REG-SI0090M1 FROM LV10. */
            _.Move(W.LV10.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1457- WRITE REG-SI0090M1 FROM LV11. */
            _.Move(W.LV11.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1460- WRITE REG-SI0090M1 FROM LV12. */
            _.Move(W.LV12.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1461- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1462- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1463- WRITE REG-SI0090M1 FROM LT01. */
            _.Move(W.LT01.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1464- WRITE REG-SI0090M1 FROM LT02. */
            _.Move(W.LT02.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1465- WRITE REG-SI0090M1 FROM LT03. */
            _.Move(W.LT03.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1466- WRITE REG-SI0090M1 FROM LT04. */
            _.Move(W.LT04.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1467- WRITE REG-SI0090M1 FROM LT05. */
            _.Move(W.LT05.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1468- WRITE REG-SI0090M1 FROM LT06. */
            _.Move(W.LT06.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1469- WRITE REG-SI0090M1 FROM LT07. */
            _.Move(W.LT07.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1470- WRITE REG-SI0090M1 FROM LT08. */
            _.Move(W.LT08.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1471- WRITE REG-SI0090M1 FROM LT09. */
            _.Move(W.LT09.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1472- WRITE REG-SI0090M1 FROM LT10. */
            _.Move(W.LT10.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1474- WRITE REG-SI0090M1 FROM LT11. */
            _.Move(W.LT11.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1475- IF SINISHIS-COD-OPERACAO EQUAL 1003 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 1003)
            {

                /*" -1476- MOVE 'TOTAL' TO LC16A-TIPO-PAGAMENTO */
                _.Move("TOTAL", W.LC16A.LC16A_TIPO_PAGAMENTO);

                /*" -1477- ELSE */
            }
            else
            {


                /*" -1478- MOVE 'COMPLEMENTAR' TO LC16A-TIPO-PAGAMENTO. */
                _.Move("COMPLEMENTAR", W.LC16A.LC16A_TIPO_PAGAMENTO);
            }


            /*" -1480- WRITE REG-SI0090M1 FROM LC16A. */
            _.Move(W.LC16A.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1481- IF SINISHIS-SIT-CONTABIL EQUAL '1' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "1")
            {

                /*" -1482- PERFORM R1010-ACESSA-CHEQUE THRU R1010-EXIT */

                R1010_ACESSA_CHEQUE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


                /*" -1483- WRITE REG-SI0090M1 FROM LC00-BRANCO */
                _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

                SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

                /*" -1484- WRITE REG-SI0090M1 FROM LC100 */
                _.Move(W.LC100.GetMoveValues(), REG_SI0090M1);

                SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

                /*" -1485- ELSE */
            }
            else
            {


                /*" -1486- IF SINISHIS-SIT-CONTABIL EQUAL '2' */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "2")
                {

                    /*" -1487- WRITE REG-SI0090M1 FROM LC00-BRANCO */
                    _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

                    SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

                    /*" -1488- WRITE REG-SI0090M1 FROM LC18A */
                    _.Move(W.LC18A.GetMoveValues(), REG_SI0090M1);

                    SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

                    /*" -1489- WRITE REG-SI0090M1 FROM LC19A */
                    _.Move(W.LC19A.GetMoveValues(), REG_SI0090M1);

                    SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

                    /*" -1490- ELSE */
                }
                else
                {


                    /*" -1492- DISPLAY 'SITUACAO CONTABIL DIFERENTE DE 1 E 2 ' SINISHIS-SIT-CONTABIL */
                    _.Display($"SITUACAO CONTABIL DIFERENTE DE 1 E 2 {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL}");

                    /*" -1494- GO TO M-999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1495- MOVE SPACES TO WTAB01 WTAB02. */
            _.Move("", W.WTAB01, W.WTAB02);

            /*" -1496- MOVE 'BRASILIA,' TO WTAB01. */
            _.Move("BRASILIA,", W.WTAB01);

            /*" -1497- MOVE 1 TO W-IND01 W-IND02 */
            _.Move(1, W.W_IND01, W.W_IND02);

            /*" -1500- PERFORM R1020-MONTA-DATA THRU R1020-EXIT UNTIL WTAB01-LETRA(W-IND01) EQUAL ' ' . */

            while (!(W.WTAB01.WTAB01_LETRA[W.W_IND01] == " "))
            {

                R1020_MONTA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }

            /*" -1501- MOVE SPACES TO WTAB01. */
            _.Move("", W.WTAB01);

            /*" -1502- MOVE SISTEMAS-DATULT-PROCESSAMEN(9:2) TO WTAB01. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(9, 2), W.WTAB01);

            /*" -1503- MOVE 1 TO W-IND01. */
            _.Move(1, W.W_IND01);

            /*" -1504- ADD 1 TO W-IND02. */
            W.W_IND02.Value = W.W_IND02 + 1;

            /*" -1507- PERFORM R1020-MONTA-DATA THRU R1020-EXIT UNTIL WTAB01-LETRA(W-IND01) EQUAL ' ' . */

            while (!(W.WTAB01.WTAB01_LETRA[W.W_IND01] == " "))
            {

                R1020_MONTA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }

            /*" -1508- MOVE SPACES TO WTAB01. */
            _.Move("", W.WTAB01);

            /*" -1509- MOVE 'DE' TO WTAB01. */
            _.Move("DE", W.WTAB01);

            /*" -1510- MOVE 1 TO W-IND01. */
            _.Move(1, W.W_IND01);

            /*" -1511- ADD 1 TO W-IND02. */
            W.W_IND02.Value = W.W_IND02 + 1;

            /*" -1514- PERFORM R1020-MONTA-DATA THRU R1020-EXIT UNTIL WTAB01-LETRA(W-IND01) EQUAL ' ' . */

            while (!(W.WTAB01.WTAB01_LETRA[W.W_IND01] == " "))
            {

                R1020_MONTA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }

            /*" -1515- MOVE SPACES TO WTAB01. */
            _.Move("", W.WTAB01);

            /*" -1516- MOVE SISTEMAS-DATULT-PROCESSAMEN(6:2) TO W-IND01. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(6, 2), W.W_IND01);

            /*" -1517- MOVE WTABMES(W-IND01) TO WTAB01. */
            _.Move(W.FILLER_143[W.W_IND01].WTABMES, W.WTAB01);

            /*" -1518- MOVE 1 TO W-IND01. */
            _.Move(1, W.W_IND01);

            /*" -1519- ADD 1 TO W-IND02. */
            W.W_IND02.Value = W.W_IND02 + 1;

            /*" -1522- PERFORM R1020-MONTA-DATA THRU R1020-EXIT UNTIL WTAB01-LETRA(W-IND01) EQUAL ' ' . */

            while (!(W.WTAB01.WTAB01_LETRA[W.W_IND01] == " "))
            {

                R1020_MONTA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }

            /*" -1523- MOVE SPACES TO WTAB01. */
            _.Move("", W.WTAB01);

            /*" -1524- MOVE 'DE' TO WTAB01. */
            _.Move("DE", W.WTAB01);

            /*" -1525- MOVE 1 TO W-IND01. */
            _.Move(1, W.W_IND01);

            /*" -1526- ADD 1 TO W-IND02. */
            W.W_IND02.Value = W.W_IND02 + 1;

            /*" -1529- PERFORM R1020-MONTA-DATA THRU R1020-EXIT UNTIL WTAB01-LETRA(W-IND01) EQUAL ' ' . */

            while (!(W.WTAB01.WTAB01_LETRA[W.W_IND01] == " "))
            {

                R1020_MONTA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }

            /*" -1530- MOVE SPACES TO WTAB01. */
            _.Move("", W.WTAB01);

            /*" -1531- MOVE SISTEMAS-DATULT-PROCESSAMEN(1:4) TO WTAB01. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(1, 4), W.WTAB01);

            /*" -1532- MOVE 1 TO W-IND01. */
            _.Move(1, W.W_IND01);

            /*" -1533- ADD 1 TO W-IND02. */
            W.W_IND02.Value = W.W_IND02 + 1;

            /*" -1536- PERFORM R1020-MONTA-DATA THRU R1020-EXIT UNTIL WTAB01-LETRA(W-IND01) EQUAL ' ' . */

            while (!(W.WTAB01.WTAB01_LETRA[W.W_IND01] == " "))
            {

                R1020_MONTA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }

            /*" -1537- MOVE WTAB02 TO LC58A-LOCAL-E-DATA. */
            _.Move(W.WTAB02, W.LC58A.LC58A_LOCAL_E_DATA);

            /*" -1538- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1539- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1540- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1541- WRITE REG-SI0090M1 FROM LC58A. */
            _.Move(W.LC58A.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1542- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1543- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1544- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1545- WRITE REG-SI0090M1 FROM LC00-BRANCO. */
            _.Move(W.LC00_BRANCO.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1546- WRITE REG-SI0090M1 FROM LC58B. */
            _.Move(W.LC58B.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1547- WRITE REG-SI0090M1 FROM LC58C. */
            _.Move(W.LC58C.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1548- WRITE REG-SI0090M1 FROM LC58D. */
            _.Move(W.LC58D.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

            /*" -1548- WRITE REG-SI0090M1 FROM LC58E. */
            _.Move(W.LC58E.GetMoveValues(), REG_SI0090M1);

            SI0090M1.Write(REG_SI0090M1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-ACESSA-CHEQUE */
        private void R1010_ACESSA_CHEQUE(bool isPerform = false)
        {
            /*" -1561- MOVE ZEROS TO LC100-CHQINT LC100-DIGINT LC100-BANCO LC100-AGENCIA LC100-NUMCHQ LC100-DIGCHQ. */
            _.Move(0, W.LC100.LC100_CHQINT, W.LC100.LC100_DIGINT, W.LC100.LC100_BANCO, W.LC100.LC100_AGENCIA, W.LC100.LC100_NUMCHQ, W.LC100.LC100_DIGCHQ);

            /*" -1563- MOVE SPACES TO LC100-SERCHQ. */
            _.Move("", W.LC100.LC100_SERCHQ);

            /*" -1564- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-NUMDOC. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W.W_NUMDOC);

            /*" -1566- MOVE W-NUMDOC TO CHEQUEMI-NUM-DOCUMENTO. */
            _.Move(W.W_NUMDOC, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO);

            /*" -1568- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", W.WABEND.WNR_EXEC_SQL);

            /*" -1589- PERFORM R1010_ACESSA_CHEQUE_DB_SELECT_1 */

            R1010_ACESSA_CHEQUE_DB_SELECT_1();

            /*" -1592- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1593- DISPLAY 'ERRO SELECT CHEQUES ............................' */
                _.Display($"ERRO SELECT CHEQUES ............................");

                /*" -1594- DISPLAY 'NUM_APOL_SINISTRO = ' CHEQUEMI-NUM-DOCUMENTO */
                _.Display($"NUM_APOL_SINISTRO = {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO}");

                /*" -1595- DISPLAY 'DATA_MOVIMENTO    = ' SISTEMAS-DATULT-PROCESSAMEN */
                _.Display($"DATA_MOVIMENTO    = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}");

                /*" -1597- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1598- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -1599- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO LC100-CHQINT */
                _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, W.LC100.LC100_CHQINT);

                /*" -1600- MOVE CHEQUEMI-DIG-CHEQUE-INTERNO TO LC100-DIGINT */
                _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO, W.LC100.LC100_DIGINT);

                /*" -1601- MOVE LOTECHEQ-COD-BANCO TO LC100-BANCO */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_COD_BANCO, W.LC100.LC100_BANCO);

                /*" -1603- MOVE LOTECHEQ-COD-AGENCIA TO LC100-AGENCIA LCEGB-DESTINATARIO */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_COD_AGENCIA, W.LC100.LC100_AGENCIA, W.LCEGB.LCEGB_DESTINATARIO);

                /*" -1604- MOVE LOTECHEQ-NUM-CHEQUE TO LC100-NUMCHQ */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE, W.LC100.LC100_NUMCHQ);

                /*" -1605- MOVE LOTECHEQ-SERIE-CHEQUE TO LC100-SERCHQ */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_SERIE_CHEQUE, W.LC100.LC100_SERCHQ);

                /*" -1605- MOVE LOTECHEQ-DIG-CHEQUE TO LC100-DIGCHQ. */
                _.Move(LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_DIG_CHEQUE, W.LC100.LC100_DIGCHQ);
            }


        }

        [StopWatch]
        /*" R1010-ACESSA-CHEQUE-DB-SELECT-1 */
        public void R1010_ACESSA_CHEQUE_DB_SELECT_1()
        {
            /*" -1589- EXEC SQL SELECT VALUE(A.NUM_CHEQUE_INTERNO,0), VALUE(A.DIG_CHEQUE_INTERNO,0), VALUE(B.COD_BANCO,0), VALUE(B.COD_AGENCIA,0), VALUE(B.NUM_CHEQUE,0), VALUE(B.SERIE_CHEQUE, ' ' ), VALUE(B.DIG_CHEQUE,0) INTO :CHEQUEMI-NUM-CHEQUE-INTERNO, :CHEQUEMI-DIG-CHEQUE-INTERNO, :LOTECHEQ-COD-BANCO, :LOTECHEQ-COD-AGENCIA, :LOTECHEQ-NUM-CHEQUE, :LOTECHEQ-SERIE-CHEQUE, :LOTECHEQ-DIG-CHEQUE FROM SEGUROS.CHEQUES_EMITIDOS A, SEGUROS.LOTE_CHEQUES B WHERE A.NUM_DOCUMENTO = :CHEQUEMI-NUM-DOCUMENTO AND A.DATA_MOVIMENTO = :SISTEMAS-DATULT-PROCESSAMEN AND B.NUM_CHEQUE_INTERNO = A.NUM_CHEQUE_INTERNO AND B.DIG_CHEQUE_INTERNO = A.DIG_CHEQUE_INTERNO END-EXEC. */

            var r1010_ACESSA_CHEQUE_DB_SELECT_1_Query1 = new R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATULT_PROCESSAMEN = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.ToString(),
                CHEQUEMI_NUM_DOCUMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO.ToString(),
            };

            var executed_1 = R1010_ACESSA_CHEQUE_DB_SELECT_1_Query1.Execute(r1010_ACESSA_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CHEQUEMI_NUM_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.CHEQUEMI_DIG_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO);
                _.Move(executed_1.LOTECHEQ_COD_BANCO, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_COD_BANCO);
                _.Move(executed_1.LOTECHEQ_COD_AGENCIA, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_COD_AGENCIA);
                _.Move(executed_1.LOTECHEQ_NUM_CHEQUE, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_NUM_CHEQUE);
                _.Move(executed_1.LOTECHEQ_SERIE_CHEQUE, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_SERIE_CHEQUE);
                _.Move(executed_1.LOTECHEQ_DIG_CHEQUE, LOTECHEQ.DCLLOTE_CHEQUES.LOTECHEQ_DIG_CHEQUE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1020-MONTA-DATA */
        private void R1020_MONTA_DATA(bool isPerform = false)
        {
            /*" -1612- MOVE WTAB01-LETRA(W-IND01) TO WTAB02-LETRA(W-IND02). */
            _.Move(W.WTAB01.WTAB01_LETRA[W.W_IND01], W.WTAB02.WTAB02_LETRA[W.W_IND02]);

            /*" -1612- ADD 1 TO W-IND01 W-IND02. */
            W.W_IND01.Value = W.W_IND01 + 1;
            W.W_IND02.Value = W.W_IND02 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1622- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

                /*" -1623- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], W.WABEND.WSQLCODE1);

                /*" -1624- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], W.WABEND.WSQLCODE2);

                /*" -1625- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, W.WSQLCODE3);
            }


            /*" -1627- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1628- CLOSE SI0090M1. */
            SI0090M1.Close();

            /*" -1628- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1630- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1630- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}