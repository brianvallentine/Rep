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
using Sias.Sinistro.DB2.SI0888B;

namespace Code
{
    public class SI0888B
    {
        public bool IsCall { get; set; }

        public SI0888B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *************************                                               */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0888B                             *      */
        /*"      *   ANALISTA ............... ALEXIS VEAS ITURRIAGA               *      */
        /*"      *   PROGRAMADOR ............ ALEXIS VEAS ITURRIAGA               *      */
        /*"      *   DATA CODIFICACAO ....... MAI / 2004                          *      */
        /*"      *   FUNCAO ................. GERA ARQUIVO COM OS SINISTROS       *      */
        /*"      *                            ESTORNADOS NO DIA.                  *      */
        /*"      *                                                                *      */
        /*"      *   NIVEL 001 A 010 - 12/09/2006 - ALEXIS VEAS ITURRIAGA         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * 04/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO     *      */
        /*"      * E GE_SIS_FUNCAO_OPER                                           *      */
        /*"      ******************************************************************      */
        /*"      * 11/09/2006 - ALEXIS                                            *      */
        /*"      * NA OPCAO DE SICOV QUANDO NAO ACHA O CARTAO MOVE 999999999 PARA *      */
        /*"      * O NUMERO DO DOCUMENTO.                                         *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      * 07/03/2008 - VIVIANE                                           *      */
        /*"      * INCLUSAO DOS CAMPOS CO-USUARIO E SOMATORIO ESTORNOS DO MES     *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      * ALTERADO POR: Diogo Matheus  - CPMBraxis                       *      */
        /*"      * EM: 08/04/2009 - CADMUS 22215                                  *      */
        /*"      * Gerar relatorio para os sinistros que possuem a situacao conta-*      */
        /*"      * bil igual a "7" (SIACC).                                       *      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      * ALTERADO POR: ALCIONE ARAUJO - STEFANINI                       *      */
        /*"      * EM: 22/07/2009 - CADMUS 27320                                  *      */
        /*"      * CORRECAO DE ABEND - SQLCODE -911                               *      */
        /*"      *                                             PROCURAR POR: V.05 *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 25/08/2010 15:45             CADMUS 46603  CELIA SILVA  *      */
        /*"      ******************************************************************      */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _ARQESTOR { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis ARQESTOR
        {
            get
            {
                _.Move(RARQESTOR, _ARQESTOR); VarBasis.RedefinePassValue(RARQESTOR, _ARQESTOR, RARQESTOR); return _ARQESTOR;
            }
        }
        /*"01 RARQESTOR                   PIC X(200).*/
        public StringBasis RARQESTOR { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 WK-INICIO-WORKING.*/
        public SI0888B_WK_INICIO_WORKING WK_INICIO_WORKING { get; set; } = new SI0888B_WK_INICIO_WORKING();
        public class SI0888B_WK_INICIO_WORKING : VarBasis
        {
            /*"   03 FILLER                    PIC X(25)     VALUE      '*** INICIO DA WORKING ***'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"*** INICIO DA WORKING ***");
            /*"   03 W-DATA.*/
            public SI0888B_W_DATA W_DATA { get; set; } = new SI0888B_W_DATA();
            public class SI0888B_W_DATA : VarBasis
            {
                /*"      06 W-ANO                 PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      06 FILLER                PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      06 W-MES                 PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      06 FILLER                PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      06 W-DIA                 PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"   03 W-FORMATA-DATA.*/
            }
            public SI0888B_W_FORMATA_DATA W_FORMATA_DATA { get; set; } = new SI0888B_W_FORMATA_DATA();
            public class SI0888B_W_FORMATA_DATA : VarBasis
            {
                /*"      06 W-FORMATA-DIA          PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_FORMATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      06 FILLER                 PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      06 W-FORMATA-MES          PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_FORMATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"      06 FILLER                 PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      06 W-FORMATA-ANO          PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_FORMATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"   03 CA-DATA-MOVIMENTO.*/
            }
            public SI0888B_CA_DATA_MOVIMENTO CA_DATA_MOVIMENTO { get; set; } = new SI0888B_CA_DATA_MOVIMENTO();
            public class SI0888B_CA_DATA_MOVIMENTO : VarBasis
            {
                /*"      06 CA-DIA-MOVIMENTO       PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_DIA_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"      06 BARRA-1                PIC X(1)      VALUE '/'.*/
                public StringBasis BARRA_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      06 CA-MES-MOVIMENTO       PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_MES_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"      06 BARRA-2                PIC X(1)      VALUE '/'.*/
                public StringBasis BARRA_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      06 CA-ANO-MOVIMENTO       PIC 9(4)      VALUE ZEROS.*/
                public IntBasis CA_ANO_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                /*"   03 CA-DATA-MOV-ABERTO.*/
            }
            public SI0888B_CA_DATA_MOV_ABERTO CA_DATA_MOV_ABERTO { get; set; } = new SI0888B_CA_DATA_MOV_ABERTO();
            public class SI0888B_CA_DATA_MOV_ABERTO : VarBasis
            {
                /*"      06 CA-ANO-MOVIMENTO       PIC 9(4)      VALUE ZEROS.*/
                public IntBasis CA_ANO_MOVIMENTO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                /*"      06 HIFEN-1                PIC X(1)      VALUE SPACES.*/
                public StringBasis HIFEN_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
                /*"      06 CA-MES-MOVIMENTO       PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_MES_MOVIMENTO_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"      06 HIFEN-2                PIC X(1)      VALUE SPACES.*/
                public StringBasis HIFEN_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"");
                /*"      06 CA-DIA-MOVIMENTO       PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_DIA_MOVIMENTO_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"   03 CA-DATA-PROCESS.*/
            }
            public SI0888B_CA_DATA_PROCESS CA_DATA_PROCESS { get; set; } = new SI0888B_CA_DATA_PROCESS();
            public class SI0888B_CA_DATA_PROCESS : VarBasis
            {
                /*"      06 CA-DIA-SISTEMA         PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_DIA_SISTEMA { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"      06 BARRA-1                PIC X(1)      VALUE '/'.*/
                public StringBasis BARRA_1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      06 CA-MES-SISTEMA         PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_MES_SISTEMA { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"      06 BARRA-2                PIC X(1)      VALUE '/'.*/
                public StringBasis BARRA_2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)"), @"/");
                /*"      06 CA-ANO-SISTEMA         PIC 9(4)      VALUE ZEROS.*/
                public IntBasis CA_ANO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                /*"   03 CA-DATA-SISTEMA.*/
            }
            public SI0888B_CA_DATA_SISTEMA CA_DATA_SISTEMA { get; set; } = new SI0888B_CA_DATA_SISTEMA();
            public class SI0888B_CA_DATA_SISTEMA : VarBasis
            {
                /*"      06 CA-ANO-SISTEMA         PIC 9(4)      VALUE ZEROS.*/
                public IntBasis CA_ANO_SISTEMA_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
                /*"      06 CA-MES-SISTEMA         PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_MES_SISTEMA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"      06 CA-DIA-SISTEMA         PIC 9(2)      VALUE ZEROS.*/
                public IntBasis CA_DIA_SISTEMA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(2)"));
                /*"   03 CT-REG-SAIDA             PIC 9(7)      VALUE ZEROS.*/
            }
            public IntBasis CT_REG_SAIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"   03 CT-GRAV-RAMO             PIC 9(7)      VALUE ZEROS.*/
            public IntBasis CT_GRAV_RAMO { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"   03 CT-LIDOS                 PIC 9(7)      VALUE ZEROS.*/
            public IntBasis CT_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"   03 CT-LINHA                 PIC 9(3)      VALUE 90.*/
            public IntBasis CT_LINHA { get; set; } = new IntBasis(new PIC("9", "3", "9(3)"), 90);
            /*"   03 CT-PAGINA                PIC 9(5)      VALUE ZEROS.*/
            public IntBasis CT_PAGINA { get; set; } = new IntBasis(new PIC("9", "5", "9(5)"));
            /*"   03 HOST-VAL-OPERACAO        PIC S9(15)V99 VALUE ZEROS COMP-3.*/
            public DoubleBasis HOST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"   03 AC-VALOR-RAMO            PIC S9(15)V99 VALUE ZEROS COMP-3.*/
            public DoubleBasis AC_VALOR_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"   03 AC-VALOR-TOTAL           PIC S9(15)V99 VALUE ZEROS COMP-3.*/
            public DoubleBasis AC_VALOR_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"   03 AC-QTDE-RAMO             PIC 9(05)     VALUE ZEROS COMP-3.*/
            public IntBasis AC_QTDE_RAMO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"   03 AC-QTDE-TOTAL            PIC 9(05)     VALUE ZEROS COMP-3.*/
            public IntBasis AC_QTDE_TOTAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"   03 HOST-MOV-INICIAL         PIC X(10)     VALUE ZEROS.*/
            public StringBasis HOST_MOV_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   03 HOST-DTH-ULT-DIA-MES     PIC X(10)     VALUE ZEROS.*/
            public StringBasis HOST_DTH_ULT_DIA_MES { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   03 HOST-ANO-MOV-ABERTO      PIC S9(04) COMP.*/
            public IntBasis HOST_ANO_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   03 HOST-MES-MOV-ABERTO      PIC S9(04) COMP.*/
            public IntBasis HOST_MES_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   03 AT-CR-ESTORNO                          VALUE LOW-VALUE.*/
            public SI0888B_AT_CR_ESTORNO AT_CR_ESTORNO { get; set; } = new SI0888B_AT_CR_ESTORNO();
            public class SI0888B_AT_CR_ESTORNO : VarBasis
            {
                /*"      06 AT-SIT-CONTABIL       PIC X.*/
                public StringBasis AT_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                /*"      06 AT-RAMO               PIC 9(04).*/
                public IntBasis AT_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"   03 AN-CR-ESTORNO                          VALUE LOW-VALUE.*/
            }
            public SI0888B_AN_CR_ESTORNO AN_CR_ESTORNO { get; set; } = new SI0888B_AN_CR_ESTORNO();
            public class SI0888B_AN_CR_ESTORNO : VarBasis
            {
                /*"      06 AN-SIT-CONTABIL       PIC X.*/
                public StringBasis AN_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                /*"      06 AN-RAMO               PIC 9(04).*/
                public IntBasis AN_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"   03 I-PRODUTO                PIC 9(05)     VALUE ZEROS COMP-3.*/
            }
            public IntBasis I_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"   03 QBAT-CR-ESTORNO          PIC X(05)     VALUE LOW-VALUE.*/
            public StringBasis QBAT_CR_ESTORNO { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"   03 TB-PRODUTOS.*/
            public SI0888B_TB_PRODUTOS TB_PRODUTOS { get; set; } = new SI0888B_TB_PRODUTOS();
            public class SI0888B_TB_PRODUTOS : VarBasis
            {
                /*"      06 E-PRODUTOS OCCURS 9999 TIMES.*/
                public ListBasis<SI0888B_E_PRODUTOS> E_PRODUTOS { get; set; } = new ListBasis<SI0888B_E_PRODUTOS>(9999);
                public class SI0888B_E_PRODUTOS : VarBasis
                {
                    /*"         09 E-QTDE-PRODUTO     PIC 9(05)     VALUE ZEROS COMP-3.*/
                    public IntBasis E_QTDE_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                    /*"         09 E-VALOR-PRODUTO    PIC S9(13)V99 VALUE ZEROS COMP-3.*/
                    public DoubleBasis E_VALOR_PRODUTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                    /*"   03 NL-NUM-CHEQUE-INTERNO    PIC S9(04)    VALUE ZEROS COMP.*/
                }
            }
            public IntBasis NL_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   03 LC-ARQESTOR-01.*/
            public SI0888B_LC_ARQESTOR_01 LC_ARQESTOR_01 { get; set; } = new SI0888B_LC_ARQESTOR_01();
            public class SI0888B_LC_ARQESTOR_01 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(13)     VALUE          'CAIXA SEGUROS'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CAIXA SEGUROS");
                /*"      06 FILLER                PIC X(104)    VALUE ' '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "104", "X(104)"), @" ");
                /*"      06 FILLER                PIC X(09)     VALUE 'PAGINA.: '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PAGINA.: ");
                /*"      06 LC-PAGINA             PIC ZZZZ9.*/
                public IntBasis LC_PAGINA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"   03 LC-ARQESTOR-02.*/
            }
            public SI0888B_LC_ARQESTOR_02 LC_ARQESTOR_02 { get; set; } = new SI0888B_LC_ARQESTOR_02();
            public class SI0888B_LC_ARQESTOR_02 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(23)     VALUE          'SOMATORIO DOS SINISTROS'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"SOMATORIO DOS SINISTROS");
                /*"      06 FILLER                PIC X(16) VALUE          ' NO PERIODO DE: '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @" NO PERIODO DE: ");
                /*"      06 DATA-INICIAL          PIC X(10) VALUE SPACES.*/
                public StringBasis DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"      06 FILLER                PIC X(03) VALUE ' A '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" A ");
                /*"      06 DATA-FIM              PIC X(10) VALUE SPACES.*/
                public StringBasis DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"   03 LC-ARQESTOR-03.*/
            }
            public SI0888B_LC_ARQESTOR_03 LC_ARQESTOR_03 { get; set; } = new SI0888B_LC_ARQESTOR_03();
            public class SI0888B_LC_ARQESTOR_03 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(38)     VALUE          'RELACAO DE ESTORNOS DE INDENIZACAO EM '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"RELACAO DE ESTORNOS DE INDENIZACAO EM ");
                /*"      06 LC03-DATA-MOV         PIC X(10)     VALUE ZEROS.*/
                public StringBasis LC03_DATA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 LC-ARQESTOR-04.*/
            }
            public SI0888B_LC_ARQESTOR_04 LC_ARQESTOR_04 { get; set; } = new SI0888B_LC_ARQESTOR_04();
            public class SI0888B_LC_ARQESTOR_04 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(25)     VALUE          'PROGRAMA GERADOR: SI0888B'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"PROGRAMA GERADOR: SI0888B");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(13)     VALUE          'EXECUTADO EM '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"EXECUTADO EM ");
                /*"      06 LC04-DATA-EXECUCAO    PIC X(10)     VALUE SPACES.*/
                public StringBasis LC04_DATA_EXECUCAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 LC-ARQESTOR-05.*/
            }
            public SI0888B_LC_ARQESTOR_05 LC_ARQESTOR_05 { get; set; } = new SI0888B_LC_ARQESTOR_05();
            public class SI0888B_LC_ARQESTOR_05 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(13)     VALUE 'SINISTRO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"SINISTRO");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(04)     VALUE 'PRD.'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"PRD.");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(40)     VALUE          'DESCRICAO DO PRODUTO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"DESCRICAO DO PRODUTO");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(40)     VALUE          'NOME DO SEGURADO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"NOME DO SEGURADO");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(13)     VALUE          'VALOR ESTORNO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"VALOR ESTORNO");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LC-TIPO-ESTORNO-05    PIC X(09)     VALUE SPACES.*/
                public StringBasis LC_TIPO_ESTORNO_05 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(07)     VALUE          'USUARIO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 LC-ARQESTOR-06.*/
            }
            public SI0888B_LC_ARQESTOR_06 LC_ARQESTOR_06 { get; set; } = new SI0888B_LC_ARQESTOR_06();
            public class SI0888B_LC_ARQESTOR_06 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(199)    VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "199", "X(199)"), @"");
                /*"   03 LC-ARQESTOR-07.*/
            }
            public SI0888B_LC_ARQESTOR_07 LC_ARQESTOR_07 { get; set; } = new SI0888B_LC_ARQESTOR_07();
            public class SI0888B_LC_ARQESTOR_07 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(50)     VALUE          '*** NAO TEM MOVIMENTO DE ESTORNO PARA ESTA DATA = '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"*** NAO TEM MOVIMENTO DE ESTORNO PARA ESTA DATA = ");
                /*"      06 LC07-DATA-MOV         PIC X(10)     VALUE ZEROS.*/
                public StringBasis LC07_DATA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"   03 LD-ARQESTOR-01.*/
            }
            public SI0888B_LD_ARQESTOR_01 LD_ARQESTOR_01 { get; set; } = new SI0888B_LD_ARQESTOR_01();
            public class SI0888B_LD_ARQESTOR_01 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-NUM-SINISTRO       PIC 9(13)     VALUE ZEROS.*/
                public IntBasis LD_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-COD-PRODUTO        PIC 9(04)     VALUE ZEROS.*/
                public IntBasis LD_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-DESCR-PRODUTO      PIC X(40)     VALUE SPACES.*/
                public StringBasis LD_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-NOME-SEGURADO      PIC X(40)     VALUE SPACES.*/
                public StringBasis LD_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      06 LD-VALOR-OPERACAO     PIC ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD_VALOR_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-NUMERO-DOCUMENTO   PIC 9(09)     VALUE ZEROS.*/
                public IntBasis LD_NUMERO_DOCUMENTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-COD-USUARIO        PIC X(08)     VALUE SPACES.*/
                public StringBasis LD_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 LT-ARQESTOR-01.*/
            }
            public SI0888B_LT_ARQESTOR_01 LT_ARQESTOR_01 { get; set; } = new SI0888B_LT_ARQESTOR_01();
            public class SI0888B_LT_ARQESTOR_01 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(31)     VALUE          'TOTAL DE ESTORNOS DO PRODUTO = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"TOTAL DE ESTORNOS DO PRODUTO = ");
                /*"      06 LT-PRODUTO-01         PIC 9(04)     VALUE ZEROS.*/
                public IntBasis LT_PRODUTO_01 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      06 FILLER                PIC X(14)     VALUE          ' QUANTIDADE = '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @" QUANTIDADE = ");
                /*"      06 LT-QTDE-PRD-01        PIC ZZZ.ZZ9.*/
                public IntBasis LT_QTDE_PRD_01 { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      06 FILLER                PIC X(09)     VALUE ' VALOR = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" VALOR = ");
                /*"      06 LT-VALOR-PRD-01       PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT_VALOR_PRD_01 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 LT-ARQESTOR-02.*/
            }
            public SI0888B_LT_ARQESTOR_02 LT_ARQESTOR_02 { get; set; } = new SI0888B_LT_ARQESTOR_02();
            public class SI0888B_LT_ARQESTOR_02 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(31)     VALUE          'TOTAL DE ESTORNOS DO RAMO    = '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"TOTAL DE ESTORNOS DO RAMO    = ");
                /*"      06 LT-RAMO-02            PIC ZZ99.*/
                public IntBasis LT_RAMO_02 { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
                /*"      06 FILLER                PIC X(14)     VALUE          ' QUANTIDADE = '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @" QUANTIDADE = ");
                /*"      06 LT-QTDE-RAMO-02       PIC ZZZ.ZZ9.*/
                public IntBasis LT_QTDE_RAMO_02 { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      06 FILLER                PIC X(09)     VALUE ' VALOR = '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" VALOR = ");
                /*"      06 LT-VALOR-RAMO-02      PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT_VALOR_RAMO_02 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"   03 LT-ARQESTOR-03.*/
            }
            public SI0888B_LT_ARQESTOR_03 LT_ARQESTOR_03 { get; set; } = new SI0888B_LT_ARQESTOR_03();
            public class SI0888B_LT_ARQESTOR_03 : VarBasis
            {
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 FILLER                PIC X(49)     VALUE          'TOTAL DE ESTORNOS                   QUANTIDADE = '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "49", "X(49)"), @"TOTAL DE ESTORNOS                   QUANTIDADE = ");
                /*"      06 LT-QTDE-TOTAL-03      PIC ZZZ.ZZ9.*/
                public IntBasis LT_QTDE_TOTAL_03 { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"      06 FILLER                PIC X(09)     VALUE ' VALOR = '.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @" VALOR = ");
                /*"      06 LT-VALOR-TOTAL-03     PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT_VALOR_TOTAL_03 { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 LT-ARQESTOR-04.*/
            }
            public SI0888B_LT_ARQESTOR_04 LT_ARQESTOR_04 { get; set; } = new SI0888B_LT_ARQESTOR_04();
            public class SI0888B_LT_ARQESTOR_04 : VarBasis
            {
                /*"      06 FILLER                PIC X(32)     VALUE          ' SOMATORIO DOS ESTORNO DO MES = '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)"), @" SOMATORIO DOS ESTORNO DO MES = ");
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"      06 LD-SOMA-VAL-OPER      PIC Z.ZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD_SOMA_VAL_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "Z.ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"      06 FILLER                PIC X(01)     VALUE ' '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"   03 M-ABEND1.*/
            }
            public SI0888B_M_ABEND1 M_ABEND1 { get; set; } = new SI0888B_M_ABEND1();
            public class SI0888B_M_ABEND1 : VarBasis
            {
                /*"      06 FILLER                PIC X(07)     VALUE 'SI0888B'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI0888B");
                /*"      06 FILLER                PIC X(28)     VALUE          ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"      06 M-NR-EXEC-SQL         PIC X(03)     VALUE '000'.*/
                public StringBasis M_NR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
                /*"      06 FILLER                PIC X(17)     VALUE          ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
                /*"      06 M-PARAGRAFO           PIC X(30)     VALUE SPACES.*/
                public StringBasis M_PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"   03 M-ABEND2.*/
            }
            public SI0888B_M_ABEND2 M_ABEND2 { get; set; } = new SI0888B_M_ABEND2();
            public class SI0888B_M_ABEND2 : VarBasis
            {
                /*"      06 FILLER                PIC X(11)     VALUE          ' SQLCODE = '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" SQLCODE = ");
                /*"      06 M-SQLCODE             PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis M_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      06 FILLER                PIC X(12)     VALUE          ' SQLCODE1 = '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SQLCODE1 = ");
                /*"      06 M-SQLCODE1            PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis M_SQLCODE1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"      06 FILLER                PIC  X(12) VALUE          ' SQLCODE2 = '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @" SQLCODE2 = ");
                /*"      06 M-SQLCODE2            PIC ZZZZZ999- VALUE ZEROS.*/
                public IntBasis M_SQLCODE2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.ABEND ABEND { get; set; } = new Dclgens.ABEND();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.AGTABCH1 AGTABCH1 { get; set; } = new Dclgens.AGTABCH1();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.SINIPENH SINIPENH { get; set; } = new Dclgens.SINIPENH();

        public SI0888B_CR_ESTORNO CR_ESTORNO { get; set; } = new SI0888B_CR_ESTORNO(true);
        string GetQuery_CR_ESTORNO()
        {
            var query = @$"SELECT M.RAMO
							, H.NUM_APOL_SINISTRO
							, M.COD_PRODUTO
							, H.NUM_APOLICE
							, H.COD_USUARIO
							, H.VAL_OPERACAO
							, H.OCORR_HISTORICO
							, H.SIT_CONTABIL
							, H.COD_OPERACAO
							, O.IDE_SISTEMA
							, O.COD_FUNCAO
							, O.IDE_SISTEMA_OPER
							FROM SEGUROS.SINISTRO_HISTORICO H
							, SEGUROS.SINISTRO_MESTRE M
							, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.SIT_CONTABIL IN ('1'
							, '2'
							, '5'
							, '7') AND O.IDE_SISTEMA_OPER = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER AND H.COD_USUARIO <> 'RESSARC' AND H.NOM_PROGRAMA <> 'SI0211B' AND O.COD_FUNCAO IN (2
							, 5
							, 6
							, 8
							, 12
							, 15
							, 16
							, 17
							, 20
							, 21
							, 22
							, 24
							, 25) AND O.NUM_FATOR = -1 AND O.TIPO_ENDOSSO = '9' ORDER BY H.SIT_CONTABIL
							, M.RAMO
							, H.COD_PRODUTO
							, H.NUM_APOL_SINISTRO";

            return query;
        }


        public SI0888B_CR_APOLICRE CR_APOLICRE { get; set; } = new SI0888B_CR_APOLICRE(true);
        string GetQuery_CR_APOLICRE()
        {
            var query = @$"SELECT PROPRIET
							, DATA_INIVIGENCIA
							FROM SEGUROS.APOLICE_CREDITO WHERE COD_SUREG = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG}' AND COD_AGENCIA = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA}' AND COD_OPERACAO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}' AND NUM_CONTRATO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO}' AND CONTRATO_DIGITO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO}' ORDER BY DATA_INIVIGENCIA";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQESTOR_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQESTOR.SetFile(ARQESTOR_FILE_NAME_P);
                InitializeGetQuery();

                /*" -516- DISPLAY '*** SI0888B - INICIO DE PROCESSAMENTO ***' */
                _.Display($"*** SI0888B - INICIO DE PROCESSAMENTO ***");

                /*" -518- DISPLAY '*** VERSAO 25/08/2010 15:45 ***' */
                _.Display($"*** VERSAO 25/08/2010 15:45 ***");

                /*" -520- INITIALIZE TB-PRODUTOS. */
                _.Initialize(
                    WK_INICIO_WORKING.TB_PRODUTOS
                );

                /*" -522- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -526- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -530- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -534- OPEN OUTPUT ARQESTOR. */
                ARQESTOR.Open(RARQESTOR);

                /*" -536- PERFORM R10-PROCESSA-DATA THRU R10-FIM. */

                R10_PROCESSA_DATA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/


                /*" -538- PERFORM R20-GRAVA-HEADER THRU R20-FIM. */

                R20_GRAVA_HEADER(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/


                /*" -540- PERFORM R30-PRINCIPAL THRU R30-FIM. */

                R30_PRINCIPAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R30_FIM*/


                /*" -541- IF CT-LIDOS EQUAL ZEROS */

                if (WK_INICIO_WORKING.CT_LIDOS == 00)
                {

                    /*" -542- WRITE RARQESTOR FROM LC-ARQESTOR-07 */
                    _.Move(WK_INICIO_WORKING.LC_ARQESTOR_07.GetMoveValues(), RARQESTOR);

                    ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

                    /*" -544- END-IF. */
                }


                /*" -546- CLOSE ARQESTOR. */
                ARQESTOR.Close();

                /*" -547- DISPLAY 'REGISTROS LIDOS    = ' CT-LIDOS. */
                _.Display($"REGISTROS LIDOS    = {WK_INICIO_WORKING.CT_LIDOS}");

                /*" -548- DISPLAY 'REGISTROS GRAVADOS = ' CT-REG-SAIDA. */
                _.Display($"REGISTROS GRAVADOS = {WK_INICIO_WORKING.CT_REG_SAIDA}");

                /*" -550- DISPLAY '*** SI0888B - FIM NORMAL DE PROCESSAMENTO ***' */
                _.Display($"*** SI0888B - FIM NORMAL DE PROCESSAMENTO ***");

                /*" -550- STOP RUN. */

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
            CR_ESTORNO.GetQueryEvent += GetQuery_CR_ESTORNO;
            CR_APOLICRE.GetQueryEvent += GetQuery_CR_APOLICRE;
        }

        [StopWatch]
        /*" R10-PROCESSA-DATA */
        private void R10_PROCESSA_DATA(bool isPerform = false)
        {
            /*" -560- MOVE '001' TO M-NR-EXEC-SQL. */
            _.Move("001", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -571- PERFORM R10_PROCESSA_DATA_DB_SELECT_1 */

            R10_PROCESSA_DATA_DB_SELECT_1();

            /*" -579- MOVE HOST-ANO-MOV-ABERTO TO W-ANO */
            _.Move(WK_INICIO_WORKING.HOST_ANO_MOV_ABERTO, WK_INICIO_WORKING.W_DATA.W_ANO);

            /*" -580- MOVE HOST-MES-MOV-ABERTO TO W-MES */
            _.Move(WK_INICIO_WORKING.HOST_MES_MOV_ABERTO, WK_INICIO_WORKING.W_DATA.W_MES);

            /*" -581- MOVE 01 TO W-DIA */
            _.Move(01, WK_INICIO_WORKING.W_DATA.W_DIA);

            /*" -582- MOVE W-DATA TO HOST-MOV-INICIAL */
            _.Move(WK_INICIO_WORKING.W_DATA, WK_INICIO_WORKING.HOST_MOV_INICIAL);

            /*" -583- MOVE HOST-MOV-INICIAL(9:2) TO W-FORMATA-DIA. */
            _.Move(WK_INICIO_WORKING.HOST_MOV_INICIAL.Substring(9, 2), WK_INICIO_WORKING.W_FORMATA_DATA.W_FORMATA_DIA);

            /*" -584- MOVE HOST-MOV-INICIAL(6:2) TO W-FORMATA-MES. */
            _.Move(WK_INICIO_WORKING.HOST_MOV_INICIAL.Substring(6, 2), WK_INICIO_WORKING.W_FORMATA_DATA.W_FORMATA_MES);

            /*" -585- MOVE HOST-MOV-INICIAL(1:4) TO W-FORMATA-ANO. */
            _.Move(WK_INICIO_WORKING.HOST_MOV_INICIAL.Substring(1, 4), WK_INICIO_WORKING.W_FORMATA_DATA.W_FORMATA_ANO);

            /*" -586- MOVE W-FORMATA-DATA TO DATA-INICIAL. */
            _.Move(WK_INICIO_WORKING.W_FORMATA_DATA, WK_INICIO_WORKING.LC_ARQESTOR_02.DATA_INICIAL);

            /*" -588- PERFORM R340-CALENDARIO THRU R340-FIM */

            R340_CALENDARIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R340_FIM*/


            /*" -589- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -590- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -591- DISPLAY 'SI0888B - FALTA REGISTRO SISTEMAS' */
                    _.Display($"SI0888B - FALTA REGISTRO SISTEMAS");

                    /*" -592- ELSE */
                }
                else
                {


                    /*" -593- DISPLAY 'SI0888B - ERRO ACESSO TABELA SISTEMAS' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SISTEMAS");

                    /*" -594- END-IF */
                }


                /*" -595- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -597- END-IF. */
            }


            /*" -598- MOVE SISTEMAS-DATA-MOV-ABERTO TO CA-DATA-MOV-ABERTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WK_INICIO_WORKING.CA_DATA_MOV_ABERTO);

            /*" -599- MOVE CORR CA-DATA-MOV-ABERTO TO CA-DATA-MOVIMENTO. */
            _.MoveCorr(WK_INICIO_WORKING.CA_DATA_MOV_ABERTO, WK_INICIO_WORKING.CA_DATA_MOVIMENTO);

            /*" -600- MOVE CA-DATA-MOVIMENTO TO LC03-DATA-MOV. */
            _.Move(WK_INICIO_WORKING.CA_DATA_MOVIMENTO, WK_INICIO_WORKING.LC_ARQESTOR_03.LC03_DATA_MOV);

            /*" -601- MOVE CA-DATA-MOVIMENTO TO LC07-DATA-MOV. */
            _.Move(WK_INICIO_WORKING.CA_DATA_MOVIMENTO, WK_INICIO_WORKING.LC_ARQESTOR_07.LC07_DATA_MOV);

            /*" -602- MOVE FUNCTION CURRENT-DATE(1:8) TO CA-DATA-SISTEMA. */
            _.Move(_.CurrentDate(0, 8), WK_INICIO_WORKING.CA_DATA_SISTEMA);

            /*" -603- MOVE CORR CA-DATA-SISTEMA TO CA-DATA-PROCESS. */
            _.MoveCorr(WK_INICIO_WORKING.CA_DATA_SISTEMA, WK_INICIO_WORKING.CA_DATA_PROCESS);

            /*" -603- MOVE CA-DATA-PROCESS TO LC04-DATA-EXECUCAO. */
            _.Move(WK_INICIO_WORKING.CA_DATA_PROCESS, WK_INICIO_WORKING.LC_ARQESTOR_04.LC04_DATA_EXECUCAO);

        }

        [StopWatch]
        /*" R10-PROCESSA-DATA-DB-SELECT-1 */
        public void R10_PROCESSA_DATA_DB_SELECT_1()
        {
            /*" -571- EXEC SQL SELECT DATA_MOV_ABERTO, MONTH(DATA_MOV_ABERTO) AS MES , YEAR(DATA_MOV_ABERTO) AS ANO , DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-MES-MOV-ABERTO, :HOST-ANO-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r10_PROCESSA_DATA_DB_SELECT_1_Query1 = new R10_PROCESSA_DATA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R10_PROCESSA_DATA_DB_SELECT_1_Query1.Execute(r10_PROCESSA_DATA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_MES_MOV_ABERTO, WK_INICIO_WORKING.HOST_MES_MOV_ABERTO);
                _.Move(executed_1.HOST_ANO_MOV_ABERTO, WK_INICIO_WORKING.HOST_ANO_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10_FIM*/

        [StopWatch]
        /*" R20-GRAVA-HEADER */
        private void R20_GRAVA_HEADER(bool isPerform = false)
        {
            /*" -616- MOVE '%!' TO RARQESTOR. */
            _.Move("%!", RARQESTOR);

            /*" -616- MOVE '(l200.jdt) STARTLM' TO RARQESTOR. */
            _.Move("(l200.jdt) STARTLM", RARQESTOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20_FIM*/

        [StopWatch]
        /*" R30-PRINCIPAL */
        private void R30_PRINCIPAL(bool isPerform = false)
        {
            /*" -630- PERFORM R300-OPEN-CR-ESTORNO THRU R300-FIM. */

            R300_OPEN_CR_ESTORNO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_FIM*/


            /*" -633- PERFORM R310-LE-CR-ESTORNO THRU R310-FIM UNTIL QBAT-CR-ESTORNO EQUAL HIGH-VALUE. */

            while (!(WK_INICIO_WORKING.QBAT_CR_ESTORNO.IsHighValues))
            {

                R310_LE_CR_ESTORNO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/

            }

            /*" -633- PERFORM R320-CLOSE-CR-ESTORNO THRU R320-FIM. */

            R320_CLOSE_CR_ESTORNO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R30_FIM*/

        [StopWatch]
        /*" R300-OPEN-CR-ESTORNO */
        private void R300_OPEN_CR_ESTORNO(bool isPerform = false)
        {
            /*" -646- MOVE '002' TO M-NR-EXEC-SQL. */
            _.Move("002", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -648- PERFORM R300_OPEN_CR_ESTORNO_DB_OPEN_1 */

            R300_OPEN_CR_ESTORNO_DB_OPEN_1();

            /*" -651- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -652- DISPLAY '*** SI0888B - ERRO NO OPEN CR_ESTORNO ***' */
                _.Display($"*** SI0888B - ERRO NO OPEN CR_ESTORNO ***");

                /*" -653- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -653- END-IF. */
            }


        }

        [StopWatch]
        /*" R300-OPEN-CR-ESTORNO-DB-OPEN-1 */
        public void R300_OPEN_CR_ESTORNO_DB_OPEN_1()
        {
            /*" -648- EXEC SQL OPEN CR_ESTORNO END-EXEC. */

            CR_ESTORNO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_FIM*/

        [StopWatch]
        /*" R310-LE-CR-ESTORNO */
        private void R310_LE_CR_ESTORNO(bool isPerform = false)
        {
            /*" -665- MOVE '003' TO M-NR-EXEC-SQL. */
            _.Move("003", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -667- MOVE AT-CR-ESTORNO TO AN-CR-ESTORNO. */
            _.Move(WK_INICIO_WORKING.AT_CR_ESTORNO, WK_INICIO_WORKING.AN_CR_ESTORNO);

            /*" -682- PERFORM R310_LE_CR_ESTORNO_DB_FETCH_1 */

            R310_LE_CR_ESTORNO_DB_FETCH_1();

            /*" -685- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -686- MOVE HIGH-VALUE TO QBAT-CR-ESTORNO */

                WK_INICIO_WORKING.QBAT_CR_ESTORNO.IsHighValues = true;

                /*" -687- MOVE HIGH-VALUE TO AT-CR-ESTORNO */

                WK_INICIO_WORKING.AT_CR_ESTORNO.IsHighValues = true;

                /*" -688- PERFORM R3150-IMPRIME-TOTAL THRU R3150-FIM */

                R3150_IMPRIME_TOTAL(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_FIM*/


                /*" -689- GO TO R310-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/ //GOTO
                return;

                /*" -691- END-IF. */
            }


            /*" -692- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -693- DISPLAY 'SI0888B - ERRO NO FETCH CR_ESTORNO' */
                _.Display($"SI0888B - ERRO NO FETCH CR_ESTORNO");

                /*" -694- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -696- END-IF. */
            }


            /*" -698- MOVE SINISMES-COD-PRODUTO TO LD-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_COD_PRODUTO);

            /*" -699- IF SINISMES-COD-PRODUTO EQUAL 4801 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == 4801)
            {

                /*" -700- IF SINISHIS-COD-OPERACAO EQUAL 4292 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4292)
                {

                    /*" -701- GO TO R310-LE-CR-ESTORNO */
                    new Task(() => R310_LE_CR_ESTORNO()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -702- END-IF */
                }


                /*" -704- END-IF. */
            }


            /*" -706- ADD 1 TO CT-LIDOS. */
            WK_INICIO_WORKING.CT_LIDOS.Value = WK_INICIO_WORKING.CT_LIDOS + 1;

            /*" -707- MOVE SINISMES-RAMO TO AT-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, WK_INICIO_WORKING.AT_CR_ESTORNO.AT_RAMO);

            /*" -708- MOVE SINISHIS-SIT-CONTABIL TO AT-SIT-CONTABIL. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL, WK_INICIO_WORKING.AT_CR_ESTORNO.AT_SIT_CONTABIL);

            /*" -709- IF AN-CR-ESTORNO NOT EQUAL AT-CR-ESTORNO */

            if (WK_INICIO_WORKING.AN_CR_ESTORNO != WK_INICIO_WORKING.AT_CR_ESTORNO)
            {

                /*" -710- IF AN-CR-ESTORNO EQUAL SPACES */

                if (WK_INICIO_WORKING.AN_CR_ESTORNO.IsEmpty())
                {

                    /*" -711- MOVE AT-CR-ESTORNO TO AN-CR-ESTORNO */
                    _.Move(WK_INICIO_WORKING.AT_CR_ESTORNO, WK_INICIO_WORKING.AN_CR_ESTORNO);

                    /*" -712- ELSE */
                }
                else
                {


                    /*" -713- PERFORM R3150-IMPRIME-TOTAL THRU R3150-FIM */

                    R3150_IMPRIME_TOTAL(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_FIM*/


                    /*" -714- END-IF */
                }


                /*" -716- END-IF. */
            }


            /*" -718- PERFORM R3100-BUSCA-SEGURADO THRU R3100-FIM. */

            R3100_BUSCA_SEGURADO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/


            /*" -720- PERFORM R3110-PROC-PAGAMENTO THRU R3110-FIM */

            R3110_PROC_PAGAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_FIM*/


            /*" -721- PERFORM R3120-BUSCA-PRODUTO THRU R3120-FIM */

            R3120_BUSCA_PRODUTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_FIM*/


            /*" -721- PERFORM R3130-GRAVA-ARQESTOR THRU R3130-FIM. */

            R3130_GRAVA_ARQESTOR(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_FIM*/


        }

        [StopWatch]
        /*" R310-LE-CR-ESTORNO-DB-FETCH-1 */
        public void R310_LE_CR_ESTORNO_DB_FETCH_1()
        {
            /*" -682- EXEC SQL FETCH CR_ESTORNO INTO :SINISMES-RAMO, :SINISHIS-NUM-APOL-SINISTRO, :SINISMES-COD-PRODUTO, :SINISHIS-NUM-APOLICE, :SINISHIS-COD-USUARIO, :SINISHIS-VAL-OPERACAO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-SIT-CONTABIL, :SINISHIS-COD-OPERACAO, :GESISFUO-IDE-SISTEMA, :GESISFUO-COD-FUNCAO, :GESISFUO-IDE-SISTEMA-OPER END-EXEC. */

            if (CR_ESTORNO.Fetch())
            {
                _.Move(CR_ESTORNO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(CR_ESTORNO.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(CR_ESTORNO.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(CR_ESTORNO.SINISHIS_NUM_APOLICE, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE);
                _.Move(CR_ESTORNO.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(CR_ESTORNO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(CR_ESTORNO.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(CR_ESTORNO.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(CR_ESTORNO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(CR_ESTORNO.GESISFUO_IDE_SISTEMA, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA);
                _.Move(CR_ESTORNO.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(CR_ESTORNO.GESISFUO_IDE_SISTEMA_OPER, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_FIM*/

        [StopWatch]
        /*" R3100-BUSCA-SEGURADO */
        private void R3100_BUSCA_SEGURADO(bool isPerform = false)
        {
            /*" -734- MOVE SPACES TO LD-NOME-SEGURADO. */
            _.Move("", WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO);

            /*" -736- PERFORM R31000-SEGURADO-HABIT THRU R31000-FIM. */

            R31000_SEGURADO_HABIT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31000_FIM*/


            /*" -737- IF LD-NOME-SEGURADO NOT EQUAL SPACES */

            if (!WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO.IsEmpty())
            {

                /*" -738- GO TO R3100-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/ //GOTO
                return;

                /*" -740- END-IF. */
            }


            /*" -742- PERFORM R31010-SEGURADO-CREDINT THRU R31010-FIM. */

            R31010_SEGURADO_CREDINT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/


            /*" -743- IF LD-NOME-SEGURADO NOT EQUAL SPACES */

            if (!WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO.IsEmpty())
            {

                /*" -744- GO TO R3100-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/ //GOTO
                return;

                /*" -746- END-IF. */
            }


            /*" -746- PERFORM R31020-SEGURADO-OUTROS THRU R31020-FIM. */

            R31020_SEGURADO_OUTROS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31020_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_FIM*/

        [StopWatch]
        /*" R31000-SEGURADO-HABIT */
        private void R31000_SEGURADO_HABIT(bool isPerform = false)
        {
            /*" -759- MOVE '004' TO M-NR-EXEC-SQL. */
            _.Move("004", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -766- PERFORM R31000_SEGURADO_HABIT_DB_SELECT_1 */

            R31000_SEGURADO_HABIT_DB_SELECT_1();

            /*" -769- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -770- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -771- MOVE SPACES TO SINIHAB1-NOME-SEGURADO */
                    _.Move("", SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);

                    /*" -772- ELSE */
                }
                else
                {


                    /*" -773- DISPLAY 'SI0888B - ERRO ACESSO SINISTRO_HABIT01' */
                    _.Display($"SI0888B - ERRO ACESSO SINISTRO_HABIT01");

                    /*" -774- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -775- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -776- END-IF */
                }


                /*" -778- END-IF. */
            }


            /*" -778- MOVE SINIHAB1-NOME-SEGURADO TO LD-NOME-SEGURADO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO);

        }

        [StopWatch]
        /*" R31000-SEGURADO-HABIT-DB-SELECT-1 */
        public void R31000_SEGURADO_HABIT_DB_SELECT_1()
        {
            /*" -766- EXEC SQL SELECT NOME_SEGURADO INTO :SINIHAB1-NOME-SEGURADO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r31000_SEGURADO_HABIT_DB_SELECT_1_Query1 = new R31000_SEGURADO_HABIT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R31000_SEGURADO_HABIT_DB_SELECT_1_Query1.Execute(r31000_SEGURADO_HABIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31000_FIM*/

        [StopWatch]
        /*" R31010-SEGURADO-CREDINT */
        private void R31010_SEGURADO_CREDINT(bool isPerform = false)
        {
            /*" -791- MOVE '005' TO M-NR-EXEC-SQL. */
            _.Move("005", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -804- PERFORM R31010_SEGURADO_CREDINT_DB_SELECT_1 */

            R31010_SEGURADO_CREDINT_DB_SELECT_1();

            /*" -807- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -808- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -809- GO TO R31010-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/ //GOTO
                    return;

                    /*" -810- ELSE */
                }
                else
                {


                    /*" -811- DISPLAY 'SI0888B - ERRO ACESSO SINISTRO_CRED_INT' */
                    _.Display($"SI0888B - ERRO ACESSO SINISTRO_CRED_INT");

                    /*" -812- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -813- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -814- END-IF */
                }


                /*" -816- END-IF. */
            }


            /*" -818- MOVE '006' TO M-NR-EXEC-SQL. */
            _.Move("006", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -820- PERFORM R31010_SEGURADO_CREDINT_DB_OPEN_1 */

            R31010_SEGURADO_CREDINT_DB_OPEN_1();

            /*" -823- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -824- DISPLAY 'SI0888B - ERRO OPEN CR_APOLICRE' */
                _.Display($"SI0888B - ERRO OPEN CR_APOLICRE");

                /*" -825- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -827- END-IF. */
            }


            /*" -831- PERFORM R31010_SEGURADO_CREDINT_DB_FETCH_1 */

            R31010_SEGURADO_CREDINT_DB_FETCH_1();

            /*" -834- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -835- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -836- MOVE SPACES TO APOLICRE-PROPRIET */
                    _.Move("", APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);

                    /*" -837- ELSE */
                }
                else
                {


                    /*" -838- DISPLAY 'SI0827B - ERRO NO FETCH CR_APOLICRE' */
                    _.Display($"SI0827B - ERRO NO FETCH CR_APOLICRE");

                    /*" -839- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -840- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -841- END-IF */
                }


                /*" -843- END-IF. */
            }


            /*" -845- PERFORM R31010_SEGURADO_CREDINT_DB_CLOSE_1 */

            R31010_SEGURADO_CREDINT_DB_CLOSE_1();

            /*" -848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -849- DISPLAY 'SI0888B - ERRO CLOSE CR_APOLICRE' */
                _.Display($"SI0888B - ERRO CLOSE CR_APOLICRE");

                /*" -850- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -851- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -853- END-IF. */
            }


            /*" -853- MOVE APOLICRE-PROPRIET TO LD-NOME-SEGURADO. */
            _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO);

        }

        [StopWatch]
        /*" R31010-SEGURADO-CREDINT-DB-SELECT-1 */
        public void R31010_SEGURADO_CREDINT_DB_SELECT_1()
        {
            /*" -804- EXEC SQL SELECT COD_SUREG, COD_AGENCIA, COD_OPERACAO, NUM_CONTRATO, CONTRATO_DIGITO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r31010_SEGURADO_CREDINT_DB_SELECT_1_Query1 = new R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R31010_SEGURADO_CREDINT_DB_SELECT_1_Query1.Execute(r31010_SEGURADO_CREDINT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
            }


        }

        [StopWatch]
        /*" R31010-SEGURADO-CREDINT-DB-OPEN-1 */
        public void R31010_SEGURADO_CREDINT_DB_OPEN_1()
        {
            /*" -820- EXEC SQL OPEN CR_APOLICRE END-EXEC. */

            CR_APOLICRE.Open();

        }

        [StopWatch]
        /*" R31010-SEGURADO-CREDINT-DB-FETCH-1 */
        public void R31010_SEGURADO_CREDINT_DB_FETCH_1()
        {
            /*" -831- EXEC SQL FETCH CR_APOLICRE INTO :APOLICRE-PROPRIET, :APOLICRE-DATA-INIVIGENCIA END-EXEC. */

            if (CR_APOLICRE.Fetch())
            {
                _.Move(CR_APOLICRE.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
                _.Move(CR_APOLICRE.APOLICRE_DATA_INIVIGENCIA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_DATA_INIVIGENCIA);
            }

        }

        [StopWatch]
        /*" R31010-SEGURADO-CREDINT-DB-CLOSE-1 */
        public void R31010_SEGURADO_CREDINT_DB_CLOSE_1()
        {
            /*" -845- EXEC SQL CLOSE CR_APOLICRE END-EXEC. */

            CR_APOLICRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31010_FIM*/

        [StopWatch]
        /*" R31020-SEGURADO-OUTROS */
        private void R31020_SEGURADO_OUTROS(bool isPerform = false)
        {
            /*" -866- MOVE ZEROS TO CLIENTES-COD-CLIENTE. */
            _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -868- PERFORM R310200-SEGURADO-ITEM THRU R310200-FIM. */

            R310200_SEGURADO_ITEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R310200_FIM*/


            /*" -869- IF CLIENTES-COD-CLIENTE EQUAL ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE == 00)
            {

                /*" -870- PERFORM R310210-SEGURADO-APOLICE THRU R310210-FIM */

                R310210_SEGURADO_APOLICE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310210_FIM*/


                /*" -872- END-IF. */
            }


            /*" -873- IF CLIENTES-COD-CLIENTE EQUAL ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE == 00)
            {

                /*" -874- MOVE SPACES TO LD-NOME-SEGURADO */
                _.Move("", WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO);

                /*" -875- GO TO R31020-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31020_FIM*/ //GOTO
                return;

                /*" -877- END-IF. */
            }


            /*" -879- MOVE '007' TO M-NR-EXEC-SQL. */
            _.Move("007", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -884- PERFORM R31020_SEGURADO_OUTROS_DB_SELECT_1 */

            R31020_SEGURADO_OUTROS_DB_SELECT_1();

            /*" -887- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -888- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -889- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -890- ELSE */
                }
                else
                {


                    /*" -891- DISPLAY 'SI0888B - ERRO ACESSO CLIENTES' */
                    _.Display($"SI0888B - ERRO ACESSO CLIENTES");

                    /*" -892- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -893- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -894- END-IF */
                }


                /*" -896- END-IF. */
            }


            /*" -896- MOVE CLIENTES-NOME-RAZAO TO LD-NOME-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO);

        }

        [StopWatch]
        /*" R31020-SEGURADO-OUTROS-DB-SELECT-1 */
        public void R31020_SEGURADO_OUTROS_DB_SELECT_1()
        {
            /*" -884- EXEC SQL SELECT NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r31020_SEGURADO_OUTROS_DB_SELECT_1_Query1 = new R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R31020_SEGURADO_OUTROS_DB_SELECT_1_Query1.Execute(r31020_SEGURADO_OUTROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31020_FIM*/

        [StopWatch]
        /*" R310200-SEGURADO-ITEM */
        private void R310200_SEGURADO_ITEM(bool isPerform = false)
        {
            /*" -909- MOVE '008' TO M-NR-EXEC-SQL. */
            _.Move("008", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -914- PERFORM R310200_SEGURADO_ITEM_DB_SELECT_1 */

            R310200_SEGURADO_ITEM_DB_SELECT_1();

            /*" -917- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -918- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -919- MOVE ZEROS TO SINIITEM-COD-CLIENTE */
                    _.Move(0, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);

                    /*" -920- ELSE */
                }
                else
                {


                    /*" -921- DISPLAY 'SI0888B - ERRO ACESSO SINISTRO_ITEM' */
                    _.Display($"SI0888B - ERRO ACESSO SINISTRO_ITEM");

                    /*" -922- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -923- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -924- END-IF */
                }


                /*" -926- END-IF. */
            }


            /*" -926- MOVE SINIITEM-COD-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

        }

        [StopWatch]
        /*" R310200-SEGURADO-ITEM-DB-SELECT-1 */
        public void R310200_SEGURADO_ITEM_DB_SELECT_1()
        {
            /*" -914- EXEC SQL SELECT COD_CLIENTE INTO :SINIITEM-COD-CLIENTE FROM SEGUROS.SINISTRO_ITEM WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r310200_SEGURADO_ITEM_DB_SELECT_1_Query1 = new R310200_SEGURADO_ITEM_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R310200_SEGURADO_ITEM_DB_SELECT_1_Query1.Execute(r310200_SEGURADO_ITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIITEM_COD_CLIENTE, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310200_FIM*/

        [StopWatch]
        /*" R310210-SEGURADO-APOLICE */
        private void R310210_SEGURADO_APOLICE(bool isPerform = false)
        {
            /*" -939- MOVE '009' TO M-NR-EXEC-SQL. */
            _.Move("009", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -944- PERFORM R310210_SEGURADO_APOLICE_DB_SELECT_1 */

            R310210_SEGURADO_APOLICE_DB_SELECT_1();

            /*" -947- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -948- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -949- MOVE ZEROS TO APOLICES-COD-CLIENTE */
                    _.Move(0, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);

                    /*" -950- ELSE */
                }
                else
                {


                    /*" -951- DISPLAY 'SI0888B - ERRO ACESSO APOLICES' */
                    _.Display($"SI0888B - ERRO ACESSO APOLICES");

                    /*" -952- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -953- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -954- END-IF */
                }


                /*" -956- END-IF. */
            }


            /*" -956- MOVE APOLICES-COD-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

        }

        [StopWatch]
        /*" R310210-SEGURADO-APOLICE-DB-SELECT-1 */
        public void R310210_SEGURADO_APOLICE_DB_SELECT_1()
        {
            /*" -944- EXEC SQL SELECT COD_CLIENTE INTO :APOLICES-COD-CLIENTE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SINISHIS-NUM-APOLICE END-EXEC. */

            var r310210_SEGURADO_APOLICE_DB_SELECT_1_Query1 = new R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOLICE = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R310210_SEGURADO_APOLICE_DB_SELECT_1_Query1.Execute(r310210_SEGURADO_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310210_FIM*/

        [StopWatch]
        /*" R3110-PROC-PAGAMENTO */
        private void R3110_PROC_PAGAMENTO(bool isPerform = false)
        {
            /*" -969- PERFORM R31100-LE-SINISHIS THRU R31100-FIM. */

            R31100_LE_SINISHIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31100_FIM*/


            /*" -970- IF SINISHIS-SIT-CONTABIL EQUAL '5' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "5")
            {

                /*" -971- PERFORM R31110-PROC-AGENCIA THRU R31110-FIM */

                R31110_PROC_AGENCIA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31110_FIM*/


                /*" -973- END-IF. */
            }


            /*" -974- IF SINISHIS-SIT-CONTABIL EQUAL '1' */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "1")
            {

                /*" -975- MOVE 'N.CHQ.INT' TO LC-TIPO-ESTORNO-05 */
                _.Move("N.CHQ.INT", WK_INICIO_WORKING.LC_ARQESTOR_05.LC_TIPO_ESTORNO_05);

                /*" -976- PERFORM R31120-PROC-CHEQUE THRU R31120-FIM */

                R31120_PROC_CHEQUE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31120_FIM*/


                /*" -977- ELSE */
            }
            else
            {


                /*" -979- IF SINISHIS-SIT-CONTABIL EQUAL '5' OR SINISHIS-SIT-CONTABIL EQUAL '7' */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "5" || SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "7")
                {

                    /*" -980- MOVE 'N. SIVAT ' TO LC-TIPO-ESTORNO-05 */
                    _.Move("N. SIVAT ", WK_INICIO_WORKING.LC_ARQESTOR_05.LC_TIPO_ESTORNO_05);

                    /*" -981- PERFORM R31130-PROC-SIVAT THRU R31130-FIM */

                    R31130_PROC_SIVAT(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R31130_FIM*/


                    /*" -982- ELSE */
                }
                else
                {


                    /*" -983- IF SINISHIS-SIT-CONTABIL EQUAL '2' */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "2")
                    {

                        /*" -984- MOVE 'N. SICOV ' TO LC-TIPO-ESTORNO-05 */
                        _.Move("N. SICOV ", WK_INICIO_WORKING.LC_ARQESTOR_05.LC_TIPO_ESTORNO_05);

                        /*" -985- PERFORM R31140-PROC-SICOV THRU R31140-FIM */

                        R31140_PROC_SICOV(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31140_FIM*/


                        /*" -986- ELSE */
                    }
                    else
                    {


                        /*" -987- MOVE ZEROS TO LD-NUMERO-DOCUMENTO */
                        _.Move(0, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

                        /*" -988- END-IF */
                    }


                    /*" -989- END-IF */
                }


                /*" -991- END-IF. */
            }


            /*" -991- PERFORM R31150-LE-AGTABCH1 THRU R31150-FIM. */

            R31150_LE_AGTABCH1(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R31150_FIM*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_FIM*/

        [StopWatch]
        /*" R31100-LE-SINISHIS */
        private void R31100_LE_SINISHIS(bool isPerform = false)
        {
            /*" -1004- MOVE '010' TO M-NR-EXEC-SQL. */
            _.Move("010", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1028- PERFORM R31100_LE_SINISHIS_DB_SELECT_1 */

            R31100_LE_SINISHIS_DB_SELECT_1();

            /*" -1031- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1032- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1033- DISPLAY 'SI0888B - SINISTRO HISTORICO NAO ENCONTRADO' */
                    _.Display($"SI0888B - SINISTRO HISTORICO NAO ENCONTRADO");

                    /*" -1034- ELSE */
                }
                else
                {


                    /*" -1036- DISPLAY 'SI0888B - ERRO ACESSO TABELA SINISTRO_HISTORICO' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SINISTRO_HISTORICO");

                    /*" -1037- END-IF */
                }


                /*" -1038- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1039- DISPLAY 'OCORR_HISTORICO   = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO   = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1040- DISPLAY 'IDE_SISTEMA       = ' GESISFUO-IDE-SISTEMA */
                _.Display($"IDE_SISTEMA       = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                /*" -1041- DISPLAY 'COD_FUNCAO        = ' GESISFUO-COD-FUNCAO */
                _.Display($"COD_FUNCAO        = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO}");

                /*" -1042- DISPLAY 'IDE_SISTEMA_OPER  = ' GESISFUO-IDE-SISTEMA-OPER */
                _.Display($"IDE_SISTEMA_OPER  = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER}");

                /*" -1043- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1043- END-IF. */
            }


        }

        [StopWatch]
        /*" R31100-LE-SINISHIS-DB-SELECT-1 */
        public void R31100_LE_SINISHIS_DB_SELECT_1()
        {
            /*" -1028- EXEC SQL SELECT H.COD_OPERACAO, H.SIT_CONTABIL, H.DATA_MOVIMENTO, O.DES_OPERACAO INTO :SINISHIS-COD-OPERACAO, :SINISHIS-SIT-CONTABIL, :SINISHIS-DATA-MOVIMENTO, :GEOPERAC-DES-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O, SEGUROS.GE_SIS_FUNCAO_OPER F WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = O.COD_OPERACAO AND F.IDE_SISTEMA = :GESISFUO-IDE-SISTEMA AND F.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND F.IDE_SISTEMA_OPER = :GESISFUO-IDE-SISTEMA-OPER AND F.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND F.COD_OPERACAO = O.COD_OPERACAO AND F.NUM_FATOR = 1 AND F.TIPO_ENDOSSO = '9' END-EXEC. */

            var r31100_LE_SINISHIS_DB_SELECT_1_Query1 = new R31100_LE_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                GESISFUO_IDE_SISTEMA_OPER = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA_OPER.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                GESISFUO_IDE_SISTEMA = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
            };

            var executed_1 = R31100_LE_SINISHIS_DB_SELECT_1_Query1.Execute(r31100_LE_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31100_FIM*/

        [StopWatch]
        /*" R31110-PROC-AGENCIA */
        private void R31110_PROC_AGENCIA(bool isPerform = false)
        {
            /*" -1056- MOVE '011' TO M-NR-EXEC-SQL. */
            _.Move("011", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1063- PERFORM R31110_PROC_AGENCIA_DB_SELECT_1 */

            R31110_PROC_AGENCIA_DB_SELECT_1();

            /*" -1066- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1067- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1069- DISPLAY 'SI0888B - ERRO ACESSO TABELA SINISTRO_CRED_INT' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SINISTRO_CRED_INT");

                    /*" -1071- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1072- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1073- END-IF */
                }


                /*" -1075- END-IF. */
            }


            /*" -1076- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1077- IF SINCREIN-COD-AGENCIA EQUAL 630 */

                if (SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA == 630)
                {

                    /*" -1078- MOVE '1' TO SINISHIS-SIT-CONTABIL */
                    _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                    /*" -1079- END-IF */
                }


                /*" -1080- GO TO R31110-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31110_FIM*/ //GOTO
                return;

                /*" -1082- END-IF. */
            }


            /*" -1084- MOVE '012' TO M-NR-EXEC-SQL. */
            _.Move("012", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1091- PERFORM R31110_PROC_AGENCIA_DB_SELECT_2 */

            R31110_PROC_AGENCIA_DB_SELECT_2();

            /*" -1094- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1095- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1097- DISPLAY 'SI0888B - ERRO ACESSO TABELA SINISTRO_HABIT01' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SINISTRO_HABIT01");

                    /*" -1099- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1100- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1101- END-IF */
                }


                /*" -1103- END-IF. */
            }


            /*" -1104- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1105- IF SINIHAB1-PONTO-VENDA EQUAL 630 */

                if (SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA == 630)
                {

                    /*" -1106- MOVE '1' TO SINISHIS-SIT-CONTABIL */
                    _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                    /*" -1107- END-IF */
                }


                /*" -1109- END-IF. */
            }


            /*" -1111- MOVE '012' TO M-NR-EXEC-SQL. */
            _.Move("012", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1118- PERFORM R31110_PROC_AGENCIA_DB_SELECT_3 */

            R31110_PROC_AGENCIA_DB_SELECT_3();

            /*" -1121- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1122- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1124- DISPLAY 'SI0888B - ERRO ACESSO TABELA SINI_PENHOR01' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SINI_PENHOR01");

                    /*" -1126- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1127- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1128- END-IF */
                }


                /*" -1130- END-IF. */
            }


            /*" -1131- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1132- IF SINIPENH-COD-AGENCIA EQUAL 630 */

                if (SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA == 630)
                {

                    /*" -1133- MOVE '1' TO SINISHIS-SIT-CONTABIL */
                    _.Move("1", SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);

                    /*" -1134- END-IF */
                }


                /*" -1134- END-IF. */
            }


        }

        [StopWatch]
        /*" R31110-PROC-AGENCIA-DB-SELECT-1 */
        public void R31110_PROC_AGENCIA_DB_SELECT_1()
        {
            /*" -1063- EXEC SQL SELECT COD_AGENCIA INTO :SINCREIN-COD-AGENCIA FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r31110_PROC_AGENCIA_DB_SELECT_1_Query1 = new R31110_PROC_AGENCIA_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R31110_PROC_AGENCIA_DB_SELECT_1_Query1.Execute(r31110_PROC_AGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31110_FIM*/

        [StopWatch]
        /*" R31110-PROC-AGENCIA-DB-SELECT-2 */
        public void R31110_PROC_AGENCIA_DB_SELECT_2()
        {
            /*" -1091- EXEC SQL SELECT PONTO_VENDA INTO :SINIHAB1-PONTO-VENDA FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r31110_PROC_AGENCIA_DB_SELECT_2_Query1 = new R31110_PROC_AGENCIA_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R31110_PROC_AGENCIA_DB_SELECT_2_Query1.Execute(r31110_PROC_AGENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
            }


        }

        [StopWatch]
        /*" R31120-PROC-CHEQUE */
        private void R31120_PROC_CHEQUE(bool isPerform = false)
        {
            /*" -1146- MOVE SINISHIS-NUM-APOL-SINISTRO TO SISINCHE-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO);

            /*" -1147- MOVE SINISHIS-COD-OPERACAO TO SISINCHE-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO);

            /*" -1148- MOVE SINISHIS-OCORR-HISTORICO TO SISINCHE-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO);

            /*" -1150- MOVE '013' TO M-NR-EXEC-SQL. */
            _.Move("013", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1159- PERFORM R31120_PROC_CHEQUE_DB_SELECT_1 */

            R31120_PROC_CHEQUE_DB_SELECT_1();

            /*" -1162- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1163- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1164- IF SINISHIS-COD-OPERACAO EQUAL 1009 OR 2010 OR 3010 */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1009", "2010", "3010"))
                    {

                        /*" -1165- MOVE ZEROS TO SISINCHE-NUM-CHEQUE-INTERNO */
                        _.Move(0, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);

                        /*" -1166- ELSE */
                    }
                    else
                    {


                        /*" -1167- MOVE 999999999 TO SISINCHE-NUM-CHEQUE-INTERNO */
                        _.Move(999999999, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);

                        /*" -1168- END-IF */
                    }


                    /*" -1169- ELSE */
                }
                else
                {


                    /*" -1170- DISPLAY 'SI0888B - ERRO ACESSO TABELA SI_SINI_CHEQUE' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SI_SINI_CHEQUE");

                    /*" -1172- DISPLAY 'NUM_APOL_SINISTRO = ' SISINCHE-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO = {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO}");

                    /*" -1174- DISPLAY 'OCORR_HISTORICO   = ' SISINCHE-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO   = {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO}");

                    /*" -1176- DISPLAY 'COD_OPERACAO      = ' SISINCHE-COD-OPERACAO */
                    _.Display($"COD_OPERACAO      = {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO}");

                    /*" -1177- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1178- END-IF */
                }


                /*" -1180- END-IF. */
            }


            /*" -1181- IF NL-NUM-CHEQUE-INTERNO EQUAL -1 */

            if (WK_INICIO_WORKING.NL_NUM_CHEQUE_INTERNO == -1)
            {

                /*" -1182- MOVE ZEROS TO SISINCHE-NUM-CHEQUE-INTERNO */
                _.Move(0, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);

                /*" -1184- END-IF. */
            }


            /*" -1184- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO LD-NUMERO-DOCUMENTO. */
            _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

        }

        [StopWatch]
        /*" R31120-PROC-CHEQUE-DB-SELECT-1 */
        public void R31120_PROC_CHEQUE_DB_SELECT_1()
        {
            /*" -1159- EXEC SQL SELECT NUM_CHEQUE_INTERNO INTO :SISINCHE-NUM-CHEQUE-INTERNO:NL-NUM-CHEQUE-INTERNO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SISINCHE-NUM-APOL-SINISTRO AND COD_OPERACAO = :SISINCHE-COD-OPERACAO AND OCORR_HISTORICO = :SISINCHE-OCORR-HISTORICO END-EXEC. */

            var r31120_PROC_CHEQUE_DB_SELECT_1_Query1 = new R31120_PROC_CHEQUE_DB_SELECT_1_Query1()
            {
                SISINCHE_NUM_APOL_SINISTRO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO.ToString(),
                SISINCHE_OCORR_HISTORICO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO.ToString(),
                SISINCHE_COD_OPERACAO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO.ToString(),
            };

            var executed_1 = R31120_PROC_CHEQUE_DB_SELECT_1_Query1.Execute(r31120_PROC_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.NL_NUM_CHEQUE_INTERNO, WK_INICIO_WORKING.NL_NUM_CHEQUE_INTERNO);
            }


        }

        [StopWatch]
        /*" R31110-PROC-AGENCIA-DB-SELECT-3 */
        public void R31110_PROC_AGENCIA_DB_SELECT_3()
        {
            /*" -1118- EXEC SQL SELECT COD_AGENCIA INTO :SINIPENH-COD-AGENCIA FROM SEGUROS.SINI_PENHOR01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r31110_PROC_AGENCIA_DB_SELECT_3_Query1 = new R31110_PROC_AGENCIA_DB_SELECT_3_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R31110_PROC_AGENCIA_DB_SELECT_3_Query1.Execute(r31110_PROC_AGENCIA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIPENH_COD_AGENCIA, SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31120_FIM*/

        [StopWatch]
        /*" R31130-PROC-SIVAT */
        private void R31130_PROC_SIVAT(bool isPerform = false)
        {
            /*" -1196- MOVE SINISHIS-NUM-APOL-SINISTRO TO RALCHEDO-NUMDOC-NUM01. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01);

            /*" -1197- MOVE SINISHIS-OCORR-HISTORICO TO RALCHEDO-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO);

            /*" -1199- MOVE '014' TO M-NR-EXEC-SQL. */
            _.Move("014", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1207- PERFORM R31130_PROC_SIVAT_DB_SELECT_1 */

            R31130_PROC_SIVAT_DB_SELECT_1();

            /*" -1210- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1212- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1213- MOVE ZEROS TO LD-NUMERO-DOCUMENTO */
                    _.Move(0, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

                    /*" -1217- GO TO R31130-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R31130_FIM*/ //GOTO
                    return;

                    /*" -1218- ELSE */
                }
                else
                {


                    /*" -1220- DISPLAY 'SI0888B - ERRO ACESSO TABELA RALACAO_CHEQUE_DOCTO' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA RALACAO_CHEQUE_DOCTO");

                    /*" -1221- END-IF */
                }


                /*" -1222- DISPLAY 'NUMDOC_NUM01     = ' RALCHEDO-NUMDOC-NUM01 */
                _.Display($"NUMDOC_NUM01     = {RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01}");

                /*" -1223- DISPLAY 'OCORR_HISTORICO  = ' RALCHEDO-OCORR-HISTORICO */
                _.Display($"OCORR_HISTORICO  = {RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO}");

                /*" -1224- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1226- END-IF. */
            }


            /*" -1226- MOVE RALCHEDO-NUMERO-SIVAT TO LD-NUMERO-DOCUMENTO. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

        }

        [StopWatch]
        /*" R31130-PROC-SIVAT-DB-SELECT-1 */
        public void R31130_PROC_SIVAT_DB_SELECT_1()
        {
            /*" -1207- EXEC SQL SELECT NUMERO_SIVAT INTO :RALCHEDO-NUMERO-SIVAT FROM SEGUROS.RALACAO_CHEQ_DOCTO WHERE NUMDOC_NUM01 = :RALCHEDO-NUMDOC-NUM01 AND OCORR_HISTORICO = :RALCHEDO-OCORR-HISTORICO END-EXEC. */

            var r31130_PROC_SIVAT_DB_SELECT_1_Query1 = new R31130_PROC_SIVAT_DB_SELECT_1_Query1()
            {
                RALCHEDO_OCORR_HISTORICO = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_OCORR_HISTORICO.ToString(),
                RALCHEDO_NUMDOC_NUM01 = RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMDOC_NUM01.ToString(),
            };

            var executed_1 = R31130_PROC_SIVAT_DB_SELECT_1_Query1.Execute(r31130_PROC_SIVAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RALCHEDO_NUMERO_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31130_FIM*/

        [StopWatch]
        /*" R31140-PROC-SICOV */
        private void R31140_PROC_SICOV(bool isPerform = false)
        {
            /*" -1238- MOVE SINISHIS-NUM-APOL-SINISTRO TO MOVDEBCE-NUM-APOLICE. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1239- MOVE SINISHIS-OCORR-HISTORICO TO MOVDEBCE-NUM-PARCELA. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -1241- MOVE '015' TO M-NR-EXEC-SQL. */
            _.Move("015", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1256- PERFORM R31140_PROC_SICOV_DB_SELECT_1 */

            R31140_PROC_SICOV_DB_SELECT_1();

            /*" -1259- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1260- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1261- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO */
                    _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

                    /*" -1262- ELSE */
                }
                else
                {


                    /*" -1264- DISPLAY 'SI0888B - ERRO ACESSO TABELA MOVTO_DEBITOCC_CEF' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA MOVTO_DEBITOCC_CEF");

                    /*" -1265- DISPLAY 'NUM_APOLICE  = ' MOVDEBCE-NUM-APOLICE */
                    _.Display($"NUM_APOLICE  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                    /*" -1266- DISPLAY 'NUM_ENDOSSO  = ' MOVDEBCE-NUM-ENDOSSO */
                    _.Display($"NUM_ENDOSSO  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                    /*" -1267- DISPLAY 'NUM_PARCELA  = ' MOVDEBCE-NUM-PARCELA */
                    _.Display($"NUM_PARCELA  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                    /*" -1268- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1269- END-IF */
                }


                /*" -1271- END-IF. */
            }


            /*" -1272- IF MOVDEBCE-NUM-CARTAO NOT EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO != 00)
            {

                /*" -1273- MOVE MOVDEBCE-NUM-CARTAO TO LD-NUMERO-DOCUMENTO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

                /*" -1274- GO TO R31140-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31140_FIM*/ //GOTO
                return;

                /*" -1276- END-IF. */
            }


            /*" -1277- MOVE SINISHIS-NUM-APOL-SINISTRO TO SISINCHE-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO);

            /*" -1278- MOVE SINISHIS-COD-OPERACAO TO SISINCHE-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO);

            /*" -1279- MOVE SINISHIS-OCORR-HISTORICO TO SISINCHE-OCORR-HISTORICO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO);

            /*" -1281- MOVE '016' TO M-NR-EXEC-SQL. */
            _.Move("016", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1290- PERFORM R31140_PROC_SICOV_DB_SELECT_2 */

            R31140_PROC_SICOV_DB_SELECT_2();

            /*" -1293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1294- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1296- MOVE 999999999 TO SISINCHE-NUM-CHEQUE-INTERNO */
                    _.Move(999999999, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);

                    /*" -1297- ELSE */
                }
                else
                {


                    /*" -1298- DISPLAY 'SI0888B - ERRO ACESSO TABELA SI_SINI_CHEQUE' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA SI_SINI_CHEQUE");

                    /*" -1300- DISPLAY 'NUM_APOL_SINISTRO = ' SISINCHE-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO = {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO}");

                    /*" -1301- DISPLAY 'OCORR_HISTORICO   = ' SISINCHE-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO   = {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO}");

                    /*" -1302- DISPLAY 'COD_OPERACAO      = ' SISINCHE-COD-OPERACAO */
                    _.Display($"COD_OPERACAO      = {SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO}");

                    /*" -1303- GO TO G999-ROT-ERRO */

                    G999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1304- END-IF */
                }


                /*" -1306- END-IF. */
            }


            /*" -1308- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO MOVDEBCE-NUM-APOLICE. */
            _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1309- IF SISINCHE-NUM-CHEQUE-INTERNO EQUAL 999999999 */

            if (SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO == 999999999)
            {

                /*" -1310- MOVE MOVDEBCE-NUM-CARTAO TO LD-NUMERO-DOCUMENTO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

                /*" -1311- GO TO R31140-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31140_FIM*/ //GOTO
                return;

                /*" -1313- END-IF. */
            }


            /*" -1315- MOVE '017' TO M-NR-EXEC-SQL. */
            _.Move("017", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1331- PERFORM R31140_PROC_SICOV_DB_SELECT_3 */

            R31140_PROC_SICOV_DB_SELECT_3();

            /*" -1334- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1335- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1336- DISPLAY 'SI0888B - CARTAO NAO ENCONTRADO' */
                    _.Display($"SI0888B - CARTAO NAO ENCONTRADO");

                    /*" -1337- END-IF */
                }


                /*" -1338- DISPLAY 'SI0888B - ERRO ACESSO TABELA MOVTO_DEBITOCC_CEF' */
                _.Display($"SI0888B - ERRO ACESSO TABELA MOVTO_DEBITOCC_CEF");

                /*" -1339- DISPLAY 'NUM_APOLICE  = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1340- DISPLAY 'NUM_ENDOSSO  = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1341- DISPLAY 'NUM_PARCELA  = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1342- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1344- END-IF. */
            }


            /*" -1344- MOVE MOVDEBCE-NUM-CARTAO TO LD-NUMERO-DOCUMENTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUMERO_DOCUMENTO);

        }

        [StopWatch]
        /*" R31140-PROC-SICOV-DB-SELECT-1 */
        public void R31140_PROC_SICOV_DB_SELECT_1()
        {
            /*" -1256- EXEC SQL SELECT VALUE(NUM_CARTAO,1) INTO :MOVDEBCE-NUM-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND TIMESTAMP = (SELECT MAX(TIMESTAMP) FROM SEGUROS.MOVTO_DEBITOCC_CEF D WHERE D.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND D.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND (NUM_CARTAO <> 0 OR NUM_CARTAO IS NULL)) WITH UR END-EXEC. */

            var r31140_PROC_SICOV_DB_SELECT_1_Query1 = new R31140_PROC_SICOV_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R31140_PROC_SICOV_DB_SELECT_1_Query1.Execute(r31140_PROC_SICOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31140_FIM*/

        [StopWatch]
        /*" R31140-PROC-SICOV-DB-SELECT-2 */
        public void R31140_PROC_SICOV_DB_SELECT_2()
        {
            /*" -1290- EXEC SQL SELECT NUM_CHEQUE_INTERNO INTO :SISINCHE-NUM-CHEQUE-INTERNO:NL-NUM-CHEQUE-INTERNO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SISINCHE-NUM-APOL-SINISTRO AND COD_OPERACAO = :SISINCHE-COD-OPERACAO AND OCORR_HISTORICO = :SISINCHE-OCORR-HISTORICO END-EXEC. */

            var r31140_PROC_SICOV_DB_SELECT_2_Query1 = new R31140_PROC_SICOV_DB_SELECT_2_Query1()
            {
                SISINCHE_NUM_APOL_SINISTRO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_APOL_SINISTRO.ToString(),
                SISINCHE_OCORR_HISTORICO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_OCORR_HISTORICO.ToString(),
                SISINCHE_COD_OPERACAO = SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_COD_OPERACAO.ToString(),
            };

            var executed_1 = R31140_PROC_SICOV_DB_SELECT_2_Query1.Execute(r31140_PROC_SICOV_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.NL_NUM_CHEQUE_INTERNO, WK_INICIO_WORKING.NL_NUM_CHEQUE_INTERNO);
            }


        }

        [StopWatch]
        /*" R31150-LE-AGTABCH1 */
        private void R31150_LE_AGTABCH1(bool isPerform = false)
        {
            /*" -1356- MOVE 2 TO AGTABCH1-IDTAB. */
            _.Move(2, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB);

            /*" -1357- MOVE SINISHIS-SIT-CONTABIL TO AGTABCH1-CODIGO-CH1. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1);

            /*" -1359- MOVE '018' TO M-NR-EXEC-SQL. */
            _.Move("018", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1367- PERFORM R31150_LE_AGTABCH1_DB_SELECT_1 */

            R31150_LE_AGTABCH1_DB_SELECT_1();

            /*" -1370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1371- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1372- DISPLAY 'SI0888B - DESCRICAO CONTABIL NAO ENCONTRADA' */
                    _.Display($"SI0888B - DESCRICAO CONTABIL NAO ENCONTRADA");

                    /*" -1373- ELSE */
                }
                else
                {


                    /*" -1375- DISPLAY 'SI0888B - ERRO ACESSO TABELA AGRUPA_TABELAS_CH1' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA AGRUPA_TABELAS_CH1");

                    /*" -1376- END-IF */
                }


                /*" -1377- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1378- DISPLAY 'IDTAB      = ' AGTABCH1-IDTAB */
                _.Display($"IDTAB      = {AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB}");

                /*" -1379- DISPLAY 'CODIGO_CH1 = ' AGTABCH1-CODIGO-CH1 */
                _.Display($"CODIGO_CH1 = {AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1}");

                /*" -1380- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1380- END-IF. */
            }


        }

        [StopWatch]
        /*" R31150-LE-AGTABCH1-DB-SELECT-1 */
        public void R31150_LE_AGTABCH1_DB_SELECT_1()
        {
            /*" -1367- EXEC SQL SELECT DESCRICAO INTO :AGTABCH1-DESCRICAO FROM SEGUROS.AGRUPA_TABELAS_CH1 WHERE IDTAB = :AGTABCH1-IDTAB AND CODIGO_CH1 = :AGTABCH1-CODIGO-CH1 END-EXEC. */

            var r31150_LE_AGTABCH1_DB_SELECT_1_Query1 = new R31150_LE_AGTABCH1_DB_SELECT_1_Query1()
            {
                AGTABCH1_CODIGO_CH1 = AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_CODIGO_CH1.ToString(),
                AGTABCH1_IDTAB = AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_IDTAB.ToString(),
            };

            var executed_1 = R31150_LE_AGTABCH1_DB_SELECT_1_Query1.Execute(r31150_LE_AGTABCH1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGTABCH1_DESCRICAO, AGTABCH1.DCLAGRUPA_TABELAS_CH1.AGTABCH1_DESCRICAO);
            }


        }

        [StopWatch]
        /*" R31140-PROC-SICOV-DB-SELECT-3 */
        public void R31140_PROC_SICOV_DB_SELECT_3()
        {
            /*" -1331- EXEC SQL SELECT NUM_CARTAO INTO :MOVDEBCE-NUM-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_PARCELA = 0 AND NUM_ENDOSSO = 0 AND TIMESTAMP = (SELECT MAX(TIMESTAMP) FROM SEGUROS.MOVTO_DEBITOCC_CEF D WHERE D.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND D.NUM_PARCELA = 0 AND D.NUM_ENDOSSO = 0 AND NUM_CARTAO <> 0 ) END-EXEC. */

            var r31140_PROC_SICOV_DB_SELECT_3_Query1 = new R31140_PROC_SICOV_DB_SELECT_3_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R31140_PROC_SICOV_DB_SELECT_3_Query1.Execute(r31140_PROC_SICOV_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31150_FIM*/

        [StopWatch]
        /*" R3120-BUSCA-PRODUTO */
        private void R3120_BUSCA_PRODUTO(bool isPerform = false)
        {
            /*" -1394- MOVE SINISMES-COD-PRODUTO TO PRODUTO-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -1396- MOVE '019' TO M-NR-EXEC-SQL. */
            _.Move("019", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1403- PERFORM R3120_BUSCA_PRODUTO_DB_SELECT_1 */

            R3120_BUSCA_PRODUTO_DB_SELECT_1();

            /*" -1406- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1407- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1408- DISPLAY 'SI0888B - DESCRICAO PRODUTO NAO ENCONTRADA' */
                    _.Display($"SI0888B - DESCRICAO PRODUTO NAO ENCONTRADA");

                    /*" -1409- ELSE */
                }
                else
                {


                    /*" -1411- DISPLAY 'SI0888B - ERRO ACESSO TABELA AGRUPA_TABELAS_CH1' */
                    _.Display($"SI0888B - ERRO ACESSO TABELA AGRUPA_TABELAS_CH1");

                    /*" -1412- END-IF */
                }


                /*" -1413- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1414- DISPLAY 'PRODUTO    = ' PRODUTO-COD-PRODUTO */
                _.Display($"PRODUTO    = {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -1415- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1417- END-IF. */
            }


            /*" -1417- MOVE PRODUTO-DESCR-PRODUTO TO LD-DESCR-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_DESCR_PRODUTO);

        }

        [StopWatch]
        /*" R3120-BUSCA-PRODUTO-DB-SELECT-1 */
        public void R3120_BUSCA_PRODUTO_DB_SELECT_1()
        {
            /*" -1403- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO END-EXEC. */

            var r3120_BUSCA_PRODUTO_DB_SELECT_1_Query1 = new R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R3120_BUSCA_PRODUTO_DB_SELECT_1_Query1.Execute(r3120_BUSCA_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_FIM*/

        [StopWatch]
        /*" R3130-GRAVA-ARQESTOR */
        private void R3130_GRAVA_ARQESTOR(bool isPerform = false)
        {
            /*" -1430- ADD 1 TO CT-LINHA. */
            WK_INICIO_WORKING.CT_LINHA.Value = WK_INICIO_WORKING.CT_LINHA + 1;

            /*" -1431- IF CT-LINHA GREATER 56 */

            if (WK_INICIO_WORKING.CT_LINHA > 56)
            {

                /*" -1432- PERFORM R3140-IMPRIME-CABEC THRU R3140-FIM */

                R3140_IMPRIME_CABEC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_FIM*/


                /*" -1434- END-IF. */
            }


            /*" -1436- INSPECT LD-NOME-SEGURADO CONVERTING ';' TO ' ' . */
            WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO.Value = System.Text.RegularExpressions.Regex.Replace(WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NOME_SEGURADO, @"';'", @"' '");

            /*" -1437- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD-NUM-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_NUM_SINISTRO);

            /*" -1438- MOVE SINISHIS-VAL-OPERACAO TO LD-VALOR-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_VALOR_OPERACAO);

            /*" -1439- MOVE SINISHIS-COD-USUARIO TO LD-COD-USUARIO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, WK_INICIO_WORKING.LD_ARQESTOR_01.LD_COD_USUARIO);

            /*" -1441- MOVE SINISMES-COD-PRODUTO TO I-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, WK_INICIO_WORKING.I_PRODUTO);

            /*" -1442- ADD SINISHIS-VAL-OPERACAO TO E-VALOR-PRODUTO(I-PRODUTO). */
            WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_VALOR_PRODUTO.Value = WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_VALOR_PRODUTO + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

            /*" -1443- ADD 1 TO E-QTDE-PRODUTO(I-PRODUTO). */
            WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_QTDE_PRODUTO.Value = WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_QTDE_PRODUTO + 1;

            /*" -1445- ADD 1 TO CT-REG-SAIDA. */
            WK_INICIO_WORKING.CT_REG_SAIDA.Value = WK_INICIO_WORKING.CT_REG_SAIDA + 1;

            /*" -1445- WRITE RARQESTOR FROM LD-ARQESTOR-01. */
            _.Move(WK_INICIO_WORKING.LD_ARQESTOR_01.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_FIM*/

        [StopWatch]
        /*" R3140-IMPRIME-CABEC */
        private void R3140_IMPRIME_CABEC(bool isPerform = false)
        {
            /*" -1458- ADD 1 TO CT-PAGINA. */
            WK_INICIO_WORKING.CT_PAGINA.Value = WK_INICIO_WORKING.CT_PAGINA + 1;

            /*" -1460- MOVE CT-PAGINA TO LC-PAGINA. */
            _.Move(WK_INICIO_WORKING.CT_PAGINA, WK_INICIO_WORKING.LC_ARQESTOR_01.LC_PAGINA);

            /*" -1461- WRITE RARQESTOR FROM LC-ARQESTOR-01. */
            _.Move(WK_INICIO_WORKING.LC_ARQESTOR_01.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1462- WRITE RARQESTOR FROM LC-ARQESTOR-02. */
            _.Move(WK_INICIO_WORKING.LC_ARQESTOR_02.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1464- WRITE RARQESTOR FROM LC-ARQESTOR-03. */
            _.Move(WK_INICIO_WORKING.LC_ARQESTOR_03.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1465- WRITE RARQESTOR FROM LC-ARQESTOR-04. */
            _.Move(WK_INICIO_WORKING.LC_ARQESTOR_04.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1466- WRITE RARQESTOR FROM LC-ARQESTOR-05. */
            _.Move(WK_INICIO_WORKING.LC_ARQESTOR_05.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1468- WRITE RARQESTOR FROM LC-ARQESTOR-06. */
            _.Move(WK_INICIO_WORKING.LC_ARQESTOR_06.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1468- MOVE 7 TO CT-LINHA. */
            _.Move(7, WK_INICIO_WORKING.CT_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_FIM*/

        [StopWatch]
        /*" R3150-IMPRIME-TOTAL */
        private void R3150_IMPRIME_TOTAL(bool isPerform = false)
        {
            /*" -1481- ADD 1 TO CT-LINHA. */
            WK_INICIO_WORKING.CT_LINHA.Value = WK_INICIO_WORKING.CT_LINHA + 1;

            /*" -1482- IF CT-LINHA GREATER 56 */

            if (WK_INICIO_WORKING.CT_LINHA > 56)
            {

                /*" -1483- PERFORM R3140-IMPRIME-CABEC THRU R3140-FIM */

                R3140_IMPRIME_CABEC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_FIM*/


                /*" -1484- ELSE */
            }
            else
            {


                /*" -1485- WRITE RARQESTOR FROM LC-ARQESTOR-06 */
                _.Move(WK_INICIO_WORKING.LC_ARQESTOR_06.GetMoveValues(), RARQESTOR);

                ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

                /*" -1486- ADD 1 TO CT-LINHA */
                WK_INICIO_WORKING.CT_LINHA.Value = WK_INICIO_WORKING.CT_LINHA + 1;

                /*" -1488- END-IF. */
            }


            /*" -1492- PERFORM R31500-IMPRIME-TOT-PRD THRU R31500-FIM VARYING I-PRODUTO FROM 1 BY 1 UNTIL I-PRODUTO GREATER 9999. */

            for (WK_INICIO_WORKING.I_PRODUTO.Value = 1; !(WK_INICIO_WORKING.I_PRODUTO > 9999); WK_INICIO_WORKING.I_PRODUTO.Value += 1)
            {

                R31500_IMPRIME_TOT_PRD(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31500_FIM*/

            }

            /*" -1493- MOVE AN-RAMO TO LT-RAMO-02. */
            _.Move(WK_INICIO_WORKING.AN_CR_ESTORNO.AN_RAMO, WK_INICIO_WORKING.LT_ARQESTOR_02.LT_RAMO_02);

            /*" -1494- MOVE AC-QTDE-RAMO TO LT-QTDE-RAMO-02. */
            _.Move(WK_INICIO_WORKING.AC_QTDE_RAMO, WK_INICIO_WORKING.LT_ARQESTOR_02.LT_QTDE_RAMO_02);

            /*" -1495- MOVE AC-VALOR-RAMO TO LT-VALOR-RAMO-02. */
            _.Move(WK_INICIO_WORKING.AC_VALOR_RAMO, WK_INICIO_WORKING.LT_ARQESTOR_02.LT_VALOR_RAMO_02);

            /*" -1496- MOVE ZEROS TO AC-QTDE-RAMO. */
            _.Move(0, WK_INICIO_WORKING.AC_QTDE_RAMO);

            /*" -1498- MOVE ZEROS TO AC-VALOR-RAMO. */
            _.Move(0, WK_INICIO_WORKING.AC_VALOR_RAMO);

            /*" -1500- ADD 1 TO CT-LINHA. */
            WK_INICIO_WORKING.CT_LINHA.Value = WK_INICIO_WORKING.CT_LINHA + 1;

            /*" -1501- IF CT-LINHA GREATER 56 */

            if (WK_INICIO_WORKING.CT_LINHA > 56)
            {

                /*" -1502- PERFORM R3140-IMPRIME-CABEC THRU R3140-FIM */

                R3140_IMPRIME_CABEC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_FIM*/


                /*" -1504- END-IF. */
            }


            /*" -1506- WRITE RARQESTOR FROM LT-ARQESTOR-02. */
            _.Move(WK_INICIO_WORKING.LT_ARQESTOR_02.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

            /*" -1507- IF AT-SIT-CONTABIL NOT EQUAL AN-SIT-CONTABIL */

            if (WK_INICIO_WORKING.AT_CR_ESTORNO.AT_SIT_CONTABIL != WK_INICIO_WORKING.AN_CR_ESTORNO.AN_SIT_CONTABIL)
            {

                /*" -1508- MOVE AC-QTDE-TOTAL TO LT-QTDE-TOTAL-03 */
                _.Move(WK_INICIO_WORKING.AC_QTDE_TOTAL, WK_INICIO_WORKING.LT_ARQESTOR_03.LT_QTDE_TOTAL_03);

                /*" -1509- MOVE AC-VALOR-TOTAL TO LT-VALOR-TOTAL-03 */
                _.Move(WK_INICIO_WORKING.AC_VALOR_TOTAL, WK_INICIO_WORKING.LT_ARQESTOR_03.LT_VALOR_TOTAL_03);

                /*" -1510- WRITE RARQESTOR FROM LT-ARQESTOR-03 */
                _.Move(WK_INICIO_WORKING.LT_ARQESTOR_03.GetMoveValues(), RARQESTOR);

                ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

                /*" -1511- PERFORM R330-BUSCA-SOMATORIO THRU R330-FIM */

                R330_BUSCA_SOMATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R330_FIM*/


                /*" -1512- WRITE RARQESTOR FROM LT-ARQESTOR-04 */
                _.Move(WK_INICIO_WORKING.LT_ARQESTOR_04.GetMoveValues(), RARQESTOR);

                ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

                /*" -1513- MOVE ZEROS TO AC-QTDE-TOTAL */
                _.Move(0, WK_INICIO_WORKING.AC_QTDE_TOTAL);

                /*" -1514- MOVE ZEROS TO AC-VALOR-TOTAL */
                _.Move(0, WK_INICIO_WORKING.AC_VALOR_TOTAL);

                /*" -1516- END-IF. */
            }


            /*" -1518- MOVE 90 TO CT-LINHA. */
            _.Move(90, WK_INICIO_WORKING.CT_LINHA);

            /*" -1518- INITIALIZE TB-PRODUTOS. */
            _.Initialize(
                WK_INICIO_WORKING.TB_PRODUTOS
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_FIM*/

        [StopWatch]
        /*" R31500-IMPRIME-TOT-PRD */
        private void R31500_IMPRIME_TOT_PRD(bool isPerform = false)
        {
            /*" -1530- IF E-VALOR-PRODUTO(I-PRODUTO) EQUAL ZEROS */

            if (WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_VALOR_PRODUTO == 00)
            {

                /*" -1531- GO TO R31500-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R31500_FIM*/ //GOTO
                return;

                /*" -1533- END-IF. */
            }


            /*" -1535- ADD 1 TO CT-LINHA. */
            WK_INICIO_WORKING.CT_LINHA.Value = WK_INICIO_WORKING.CT_LINHA + 1;

            /*" -1536- IF CT-LINHA GREATER 56 */

            if (WK_INICIO_WORKING.CT_LINHA > 56)
            {

                /*" -1537- PERFORM R3140-IMPRIME-CABEC THRU R3140-FIM */

                R3140_IMPRIME_CABEC(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_FIM*/


                /*" -1539- END-IF. */
            }


            /*" -1540- MOVE I-PRODUTO TO LT-PRODUTO-01. */
            _.Move(WK_INICIO_WORKING.I_PRODUTO, WK_INICIO_WORKING.LT_ARQESTOR_01.LT_PRODUTO_01);

            /*" -1541- MOVE E-QTDE-PRODUTO(I-PRODUTO) TO LT-QTDE-PRD-01. */
            _.Move(WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_QTDE_PRODUTO, WK_INICIO_WORKING.LT_ARQESTOR_01.LT_QTDE_PRD_01);

            /*" -1543- MOVE E-VALOR-PRODUTO(I-PRODUTO) TO LT-VALOR-PRD-01. */
            _.Move(WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_VALOR_PRODUTO, WK_INICIO_WORKING.LT_ARQESTOR_01.LT_VALOR_PRD_01);

            /*" -1544- ADD E-QTDE-PRODUTO(I-PRODUTO) TO AC-QTDE-RAMO. */
            WK_INICIO_WORKING.AC_QTDE_RAMO.Value = WK_INICIO_WORKING.AC_QTDE_RAMO + WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_QTDE_PRODUTO;

            /*" -1545- ADD E-VALOR-PRODUTO(I-PRODUTO) TO AC-VALOR-RAMO. */
            WK_INICIO_WORKING.AC_VALOR_RAMO.Value = WK_INICIO_WORKING.AC_VALOR_RAMO + WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_VALOR_PRODUTO;

            /*" -1546- ADD E-QTDE-PRODUTO(I-PRODUTO) TO AC-QTDE-TOTAL. */
            WK_INICIO_WORKING.AC_QTDE_TOTAL.Value = WK_INICIO_WORKING.AC_QTDE_TOTAL + WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_QTDE_PRODUTO;

            /*" -1548- ADD E-VALOR-PRODUTO(I-PRODUTO) TO AC-VALOR-TOTAL. */
            WK_INICIO_WORKING.AC_VALOR_TOTAL.Value = WK_INICIO_WORKING.AC_VALOR_TOTAL + WK_INICIO_WORKING.TB_PRODUTOS.E_PRODUTOS[WK_INICIO_WORKING.I_PRODUTO].E_VALOR_PRODUTO;

            /*" -1548- WRITE RARQESTOR FROM LT-ARQESTOR-01. */
            _.Move(WK_INICIO_WORKING.LT_ARQESTOR_01.GetMoveValues(), RARQESTOR);

            ARQESTOR.Write(RARQESTOR.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R31500_FIM*/

        [StopWatch]
        /*" R320-CLOSE-CR-ESTORNO */
        private void R320_CLOSE_CR_ESTORNO(bool isPerform = false)
        {
            /*" -1561- MOVE '020' TO M-NR-EXEC-SQL. */
            _.Move("020", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1563- PERFORM R320_CLOSE_CR_ESTORNO_DB_CLOSE_1 */

            R320_CLOSE_CR_ESTORNO_DB_CLOSE_1();

            /*" -1566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1567- DISPLAY '*** SI0888B - ERRO NO CLOSE CR_ESTORNO ***' */
                _.Display($"*** SI0888B - ERRO NO CLOSE CR_ESTORNO ***");

                /*" -1568- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1570- END-IF. */
            }


            /*" -1570- MOVE '%%EOF' TO RARQESTOR. */
            _.Move("%%EOF", RARQESTOR);

        }

        [StopWatch]
        /*" R320-CLOSE-CR-ESTORNO-DB-CLOSE-1 */
        public void R320_CLOSE_CR_ESTORNO_DB_CLOSE_1()
        {
            /*" -1563- EXEC SQL CLOSE CR_ESTORNO END-EXEC. */

            CR_ESTORNO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_FIM*/

        [StopWatch]
        /*" R330-BUSCA-SOMATORIO */
        private void R330_BUSCA_SOMATORIO(bool isPerform = false)
        {
            /*" -1582- MOVE '330' TO M-NR-EXEC-SQL. */
            _.Move("330", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1602- PERFORM R330_BUSCA_SOMATORIO_DB_SELECT_1 */

            R330_BUSCA_SOMATORIO_DB_SELECT_1();

            /*" -1605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1606- DISPLAY '*** SI0888B - N�O EXISTE SOMATORIO *****' */
                _.Display($"*** SI0888B - N�O EXISTE SOMATORIO *****");

                /*" -1607- GO TO G999-ROT-ERRO */

                G999_ROT_ERRO(); //GOTO
                return;

                /*" -1609- END-IF. */
            }


            /*" -1609- MOVE HOST-VAL-OPERACAO TO LD-SOMA-VAL-OPER. */
            _.Move(WK_INICIO_WORKING.HOST_VAL_OPERACAO, WK_INICIO_WORKING.LT_ARQESTOR_04.LD_SOMA_VAL_OPER);

        }

        [StopWatch]
        /*" R330-BUSCA-SOMATORIO-DB-SELECT-1 */
        public void R330_BUSCA_SOMATORIO_DB_SELECT_1()
        {
            /*" -1602- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.GE_SIS_FUNCAO_OPER O WHERE H.DATA_MOVIMENTO BETWEEN :HOST-MOV-INICIAL AND :HOST-DTH-ULT-DIA-MES AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.SIT_CONTABIL IN ( '1' , '2' , '5' , '7' ) AND O.IDE_SISTEMA_OPER = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IDE_SISTEMA = O.IDE_SISTEMA_OPER AND H.COD_USUARIO <> 'RESSARC' AND H.NOM_PROGRAMA <> 'SI0211B' AND O.COD_FUNCAO IN (24, 25) AND O.NUM_FATOR = -1 AND O.TIPO_ENDOSSO = '9' WITH UR END-EXEC. */

            var r330_BUSCA_SOMATORIO_DB_SELECT_1_Query1 = new R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1()
            {
                HOST_DTH_ULT_DIA_MES = WK_INICIO_WORKING.HOST_DTH_ULT_DIA_MES.ToString(),
                HOST_MOV_INICIAL = WK_INICIO_WORKING.HOST_MOV_INICIAL.ToString(),
            };

            var executed_1 = R330_BUSCA_SOMATORIO_DB_SELECT_1_Query1.Execute(r330_BUSCA_SOMATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_OPERACAO, WK_INICIO_WORKING.HOST_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R330_FIM*/

        [StopWatch]
        /*" R340-CALENDARIO */
        private void R340_CALENDARIO(bool isPerform = false)
        {
            /*" -1624- MOVE '340' TO M-NR-EXEC-SQL. */
            _.Move("340", WK_INICIO_WORKING.M_ABEND1.M_NR_EXEC_SQL);

            /*" -1631- PERFORM R340_CALENDARIO_DB_SELECT_1 */

            R340_CALENDARIO_DB_SELECT_1();

            /*" -1634- MOVE HOST-DTH-ULT-DIA-MES(9:2) TO W-FORMATA-DIA. */
            _.Move(WK_INICIO_WORKING.HOST_DTH_ULT_DIA_MES.Substring(9, 2), WK_INICIO_WORKING.W_FORMATA_DATA.W_FORMATA_DIA);

            /*" -1635- MOVE HOST-DTH-ULT-DIA-MES(6:2) TO W-FORMATA-MES. */
            _.Move(WK_INICIO_WORKING.HOST_DTH_ULT_DIA_MES.Substring(6, 2), WK_INICIO_WORKING.W_FORMATA_DATA.W_FORMATA_MES);

            /*" -1636- MOVE HOST-DTH-ULT-DIA-MES(1:4) TO W-FORMATA-ANO. */
            _.Move(WK_INICIO_WORKING.HOST_DTH_ULT_DIA_MES.Substring(1, 4), WK_INICIO_WORKING.W_FORMATA_DATA.W_FORMATA_ANO);

            /*" -1636- MOVE W-FORMATA-DATA TO DATA-FIM. */
            _.Move(WK_INICIO_WORKING.W_FORMATA_DATA, WK_INICIO_WORKING.LC_ARQESTOR_02.DATA_FIM);

        }

        [StopWatch]
        /*" R340-CALENDARIO-DB-SELECT-1 */
        public void R340_CALENDARIO_DB_SELECT_1()
        {
            /*" -1631- EXEC SQL SELECT DTH_ULT_DIA_MES INTO :HOST-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r340_CALENDARIO_DB_SELECT_1_Query1 = new R340_CALENDARIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R340_CALENDARIO_DB_SELECT_1_Query1.Execute(r340_CALENDARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DTH_ULT_DIA_MES, WK_INICIO_WORKING.HOST_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R340_FIM*/

        [StopWatch]
        /*" G999-ROT-ERRO */
        private void G999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1647- MOVE SQLCODE TO M-SQLCODE */
            _.Move(DB.SQLCODE, WK_INICIO_WORKING.M_ABEND2.M_SQLCODE);

            /*" -1648- MOVE SQLERRD(1) TO M-SQLCODE1 */
            _.Move(DB.SQLERRD[1], WK_INICIO_WORKING.M_ABEND2.M_SQLCODE1);

            /*" -1650- MOVE SQLERRD(2) TO M-SQLCODE2 */
            _.Move(DB.SQLERRD[2], WK_INICIO_WORKING.M_ABEND2.M_SQLCODE2);

            /*" -1651- DISPLAY M-ABEND1. */
            _.Display(WK_INICIO_WORKING.M_ABEND1);

            /*" -1653- DISPLAY M-ABEND2. */
            _.Display(WK_INICIO_WORKING.M_ABEND2);

            /*" -1655- CLOSE ARQESTOR. */
            ARQESTOR.Close();

            /*" -1656- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1656- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}