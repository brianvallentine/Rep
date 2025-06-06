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
using Sias.Sinistro.DB2.SI0862B;

namespace Code
{
    public class SI0862B
    {
        public bool IsCall { get; set; }

        public SI0862B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0862B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  LUIS RICARDO                       *      */
        /*"      *   CRIACAO ................  20/03/2002.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERAR O ARQUIVO PARA GERA  O DE PLANILHA DE SI- *      */
        /*"      *    NISTRALIDADE DE LOTERICO A PARTIR DA APOLICE 0107100057625  *      */
        /*"      *    ORIGINADO DA DC5.SELLOT08                                   *      */
        /*"      *    SOLICITA  O FEITA PELO ON LINE 13-12-? (APLICA  O SI???A)   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 27/04/2005 - PRODEXTER                                         *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA                 *      */
        /*"      * GE_SIS_FUNCAO_OPER                                             *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "170", "X(170)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_ARQ_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_ARQ_SAIDA, _ARQ_SAIDA, REG_ARQ_SAIDA); return _ARQ_SAIDA;
            }
        }
        /*"01  REG-ARQ-SAIDA                  PIC X(170).*/
        public StringBasis REG_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "170", "X(170)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-DATA-INICIAL           PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-FINAL             PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-APOLICE                PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-VALOR                  PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-QTDE                   PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-PRODUTO-INICIAL        PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_PRODUTO_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-PRODUTO-FINAL          PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_PRODUTO_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-CODSUBES-INICIAL       PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_CODSUBES_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-CODSUBES-FINAL         PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_CODSUBES_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-RAMO-INICIAL           PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_RAMO_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-RAMO-FINAL             PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_RAMO_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-FONTE                  PIC S9(04) COMP   VALUE +0.*/
        public IntBasis HOST_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-QTD-PAGO               PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_QTD_PAGO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-VAL-PAGO               PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-QTD-PENDENTE           PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-VAL-PENDENTE           PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  AREA-DE-WORK.*/
        public SI0862B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0862B_AREA_DE_WORK();
        public class SI0862B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01  W-INICIO-WORK.*/
        }
        public SI0862B_W_INICIO_WORK W_INICIO_WORK { get; set; } = new SI0862B_W_INICIO_WORK();
        public class SI0862B_W_INICIO_WORK : VarBasis
        {
            /*"    03 W-FIM-RELATORIO                PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CHAVE-ARQ-SAIDA-JA-ABERTO    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ARQ_SAIDA_JA_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND                          PIC 9(03)  VALUE ZEROS.*/
            public IntBasis W_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"    03 W-CONTADOR-USUARIO             PIC 9(13)  VALUE ZEROS.*/
            public IntBasis W_CONTADOR_USUARIO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 W-CONTADOR-GERAL               PIC 9(13)  VALUE ZEROS.*/
            public IntBasis W_CONTADOR_GERAL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"01  FILLER.*/
        }
        public SI0862B_FILLER_0 FILLER_0 { get; set; } = new SI0862B_FILLER_0();
        public class SI0862B_FILLER_0 : VarBasis
        {
            /*"    05 WABEND.*/
            public SI0862B_WABEND WABEND { get; set; } = new SI0862B_WABEND();
            public class SI0862B_WABEND : VarBasis
            {
                /*"       10 FILLER                     PIC  X(009) VALUE          'SI0862B '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0862B ");
                /*"       10 FILLER                     PIC  X(035) VALUE          ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"       10 WNR-EXEC-SQL               PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       10 FILLER                     PIC  X(013) VALUE          ' *** SQLCODE '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       10 WSQLCODE                   PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  FILLER01.*/
            }
        }
        public SI0862B_FILLER01 FILLER01 { get; set; } = new SI0862B_FILLER01();
        public class SI0862B_FILLER01 : VarBasis
        {
            /*"  02 LD01.*/
            public SI0862B_LD01 LD01 { get; set; } = new SI0862B_LD01();
            public class SI0862B_LD01 : VarBasis
            {
                /*"    03 C01-SOLICITANTE           PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-SOLIC            PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-PROC             PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-APOLICE               PIC  9(13) VALUE 0.*/
                public IntBasis C01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-INICIAL          PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DATA-FINAL            PIC  X(10) VALUE SPACES.*/
                public StringBasis C01_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-NOME-COLUNA           PIC  X(01) VALUE SPACES.*/
                public StringBasis C01_NOME_COLUNA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-QTDE                  PIC  ------9.*/
                public IntBasis C01_QTDE { get; set; } = new IntBasis(new PIC("9", "7", "------9."));
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-VALOR                 PIC  ------------9,99.*/
                public DoubleBasis C01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 C01-DESCRICAO             PIC  X(40) VALUE SPACES.*/
                public StringBasis C01_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                    PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                    PIC  X(03) VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"  02 LC01.*/
            }
            public SI0862B_LC01 LC01 { get; set; } = new SI0862B_LC01();
            public class SI0862B_LC01 : VarBasis
            {
                /*"    03  FILLER                   PIC  X(19) VALUE        'NOME DO SOLICITANTE'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"NOME DO SOLICITANTE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(19) VALUE        'DATA DA SOLICITACAO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA DA SOLICITACAO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(21) VALUE        'DATA DO PROCESSAMENTO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA DO PROCESSAMENTO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(17) VALUE        'NUMERO DA APOLICE'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"NUMERO DA APOLICE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(15) VALUE        'PERIODO INICIAL'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"PERIODO INICIAL");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(13) VALUE        'PERIODO FINAL'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PERIODO FINAL");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(15) VALUE        'COLUNA DE DADOS'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"COLUNA DE DADOS");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(10) VALUE        'QUANTIDADE'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"QUANTIDADE");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(05) VALUE        'VALOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"VALOR");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(09) VALUE        'DESCRICAO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DESCRICAO");
                /*"    03  FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                   PIC  X(17) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"");
                /*"  02  LC02.*/
            }
            public SI0862B_LC02 LC02 { get; set; } = new SI0862B_LC02();
            public class SI0862B_LC02 : VarBasis
            {
                /*"    03  C02-IDENTIFICADOR        PIC  X(170) VALUE       'PROGRAMA GERADOR >>> SI0862B;'.*/
                public StringBasis C02_IDENTIFICADOR { get; set; } = new StringBasis(new PIC("X", "170", "X(170)"), @"PROGRAMA GERADOR >>> SI0862B;");
                /*"  02  LC03.*/
            }
            public SI0862B_LC03 LC03 { get; set; } = new SI0862B_LC03();
            public class SI0862B_LC03 : VarBasis
            {
                /*"    03  C03-FUNCAO               PIC  X(170) VALUE       'PLANILHA DE SINISTRALIDADE DE LOTERICO;'.*/
                public StringBasis C03_FUNCAO { get; set; } = new StringBasis(new PIC("X", "170", "X(170)"), @"PLANILHA DE SINISTRALIDADE DE LOTERICO;");
                /*"01  FILLER REDEFINES FILLER01.*/
            }
        }
        private _REDEF_SI0862B_FILLER_36 _filler_36 { get; set; }
        public _REDEF_SI0862B_FILLER_36 FILLER_36
        {
            get { _filler_36 = new _REDEF_SI0862B_FILLER_36(); _.Move(FILLER01, _filler_36); VarBasis.RedefinePassValue(FILLER01, _filler_36, FILLER01); _filler_36.ValueChanged += () => { _.Move(_filler_36, FILLER01); }; return _filler_36; }
            set { VarBasis.RedefinePassValue(value, _filler_36, FILLER01); }
        }  //Redefines
        public class _REDEF_SI0862B_FILLER_36 : VarBasis
        {
            /*"    03  C01-FILLER               PIC  X(170).*/
            public StringBasis C01_FILLER { get; set; } = new StringBasis(new PIC("X", "170", "X(170)."), @"");

            public _REDEF_SI0862B_FILLER_36()
            {
                C01_FILLER.ValueChanged += OnValueChanged;
            }

        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINLOAB2 SINLOAB2 { get; set; } = new Dclgens.SINLOAB2();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public SI0862B_RELATORIOS RELATORIOS { get; set; } = new SI0862B_RELATORIOS();
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

                /*" -213- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -214- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -215- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -218- OPEN OUTPUT ARQ-SAIDA. */
                ARQ_SAIDA.Open(REG_ARQ_SAIDA);

                /*" -220- MOVE 'SIM' TO W-CHAVE-ARQ-SAIDA-JA-ABERTO. */
                _.Move("SIM", W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO);

                /*" -222- PERFORM R010-SELECT-SISTEMA THRU R010-EXIT. */

                R010_SELECT_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -223- PERFORM R020-DECLARE-RELATORIO THRU R020-EXIT. */

                R020_DECLARE_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -224- MOVE 'NAO' TO W-FIM-RELATORIO. */
                _.Move("NAO", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -226- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

                R021_FETCH_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -227- IF W-FIM-RELATORIO EQUAL 'SIM' */

                if (W_INICIO_WORK.W_FIM_RELATORIO == "SIM")
                {

                    /*" -228- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -229- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -230- DISPLAY '       NADA SELECIONADO NA DATA DE HOJE         ' */
                    _.Display($"       NADA SELECIONADO NA DATA DE HOJE         ");

                    /*" -231- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -232- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -233- MOVE 'NAO HOUVE SOLICITACAO NA DATA DE HOJE' TO C01-FILLER */
                    _.Move("NAO HOUVE SOLICITACAO NA DATA DE HOJE", FILLER_36.C01_FILLER);

                    /*" -234- WRITE REG-ARQ-SAIDA FROM LC03 */
                    _.Move(FILLER01.LC03.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -235- WRITE REG-ARQ-SAIDA FROM LC02 */
                    _.Move(FILLER01.LC02.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -236- WRITE REG-ARQ-SAIDA FROM LD01 */
                    _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -238- GO TO 000-TERMINA. */

                    M_000_TERMINA(); //GOTO
                    return Result;
                }


                /*" -241- PERFORM R030-PROCESSA-RELATORIO THRU R030-EXIT UNTIL (W-FIM-RELATORIO EQUAL 'SIM' ). */

                while (!((W_INICIO_WORK.W_FIM_RELATORIO == "SIM")))
                {

                    R030_PROCESSA_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -243- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", FILLER_0.WABEND.WNR_EXEC_SQL);

                /*" -248- PERFORM Execute_DB_UPDATE_1 */

                Execute_DB_UPDATE_1();

                /*" -251- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -252- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -253- DISPLAY 'ERRO NO UPDATE RELATORIOS.......' */
                    _.Display($"ERRO NO UPDATE RELATORIOS.......");

                    /*" -254- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -254- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -254- FLUXCONTROL_PERFORM Execute-DB-UPDATE-1 */

                Execute_DB_UPDATE_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-UPDATE-1 */
        public void Execute_DB_UPDATE_1()
        {
            /*" -248- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0862B' AND SIT_REGISTRO = '0' END-EXEC. */

            var execute_DB_UPDATE_1_Update1 = new Execute_DB_UPDATE_1_Update1()
            {
            };

            Execute_DB_UPDATE_1_Update1.Execute(execute_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-000-TERMINA */
        private void M_000_TERMINA(bool isPerform = false)
        {
            /*" -259- DISPLAY '************************************' */
            _.Display($"************************************");

            /*" -260- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -261- DISPLAY '*   TERMINO NORMAL DO PROGRAMA     *' */
            _.Display($"*   TERMINO NORMAL DO PROGRAMA     *");

            /*" -262- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -263- DISPLAY '*            SI0862B               *' */
            _.Display($"*            SI0862B               *");

            /*" -264- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -264- DISPLAY '************************************' . */
            _.Display($"************************************");

        }

        [StopWatch]
        /*" M-000-FIM-PROGRAMA */
        private void M_000_FIM_PROGRAMA(bool isPerform = false)
        {
            /*" -269- CLOSE ARQ-SAIDA */
            ARQ_SAIDA.Close();

            /*" -270- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -270- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA */
        private void R010_SELECT_SISTEMA(bool isPerform = false)
        {
            /*" -276- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -281- PERFORM R010_SELECT_SISTEMA_DB_SELECT_1 */

            R010_SELECT_SISTEMA_DB_SELECT_1();

            /*" -284- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -285- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -286- DISPLAY 'ERRO NO ACESSO - SISTEMA .......' */
                _.Display($"ERRO NO ACESSO - SISTEMA .......");

                /*" -287- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -288- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -289- ELSE */
            }
            else
            {


                /*" -291- MOVE SISTEMAS-DATA-MOV-ABERTO(09:02) TO C01-DATA-PROC(01:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), FILLER01.LD01.C01_DATA_PROC, 1, 2);

                /*" -292- MOVE '/' TO C01-DATA-PROC(03:01) */
                _.MoveAtPosition("/", FILLER01.LD01.C01_DATA_PROC, 3, 1);

                /*" -294- MOVE SISTEMAS-DATA-MOV-ABERTO(06:02) TO C01-DATA-PROC(04:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), FILLER01.LD01.C01_DATA_PROC, 4, 2);

                /*" -295- MOVE '/' TO C01-DATA-PROC(06:01) */
                _.MoveAtPosition("/", FILLER01.LD01.C01_DATA_PROC, 6, 1);

                /*" -297- MOVE SISTEMAS-DATA-MOV-ABERTO(01:04) TO C01-DATA-PROC(07:04) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), FILLER01.LD01.C01_DATA_PROC, 7, 4);

                /*" -297- END-IF. */
            }


        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA-DB-SELECT-1 */
        public void R010_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -281- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r010_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R010_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r010_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-DECLARE-RELATORIO */
        private void R020_DECLARE_RELATORIO(bool isPerform = false)
        {
            /*" -306- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -319- PERFORM R020_DECLARE_RELATORIO_DB_DECLARE_1 */

            R020_DECLARE_RELATORIO_DB_DECLARE_1();

            /*" -321- PERFORM R020_DECLARE_RELATORIO_DB_OPEN_1 */

            R020_DECLARE_RELATORIO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-DECLARE-1 */
        public void R020_DECLARE_RELATORIO_DB_DECLARE_1()
        {
            /*" -319- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT COD_USUARIO, DATA_SOLICITACAO, PERI_INICIAL, PERI_FINAL, RAMO_EMISSOR, COD_SUBGRUPO, NUM_APOLICE, COD_FONTE FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0862B' AND SIT_REGISTRO = '0' END-EXEC */
            RELATORIOS = new SI0862B_RELATORIOS(false);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT COD_USUARIO
							, 
							DATA_SOLICITACAO
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							RAMO_EMISSOR
							, 
							COD_SUBGRUPO
							, 
							NUM_APOLICE
							, 
							COD_FONTE 
							FROM SEGUROS.RELATORIOS 
							WHERE IDE_SISTEMA = 'SI' 
							AND COD_RELATORIO = 'SI0862B' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-OPEN-1 */
        public void R020_DECLARE_RELATORIO_DB_OPEN_1()
        {
            /*" -321- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-RELATORIO */
        private void R021_FETCH_RELATORIO(bool isPerform = false)
        {
            /*" -330- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -339- PERFORM R021_FETCH_RELATORIO_DB_FETCH_1 */

            R021_FETCH_RELATORIO_DB_FETCH_1();

            /*" -342- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -343- MOVE 'SIM' TO W-FIM-RELATORIO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -343- PERFORM R021_FETCH_RELATORIO_DB_CLOSE_1 */

                R021_FETCH_RELATORIO_DB_CLOSE_1();

                /*" -346- GO TO R021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/ //GOTO
                return;
            }


            /*" -347- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -348- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -349- DISPLAY 'ERRO FETCH NA RELATORIOS...........' */
                _.Display($"ERRO FETCH NA RELATORIOS...........");

                /*" -350- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -352- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -353- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -358- PERFORM R021_FETCH_RELATORIO_DB_SELECT_1 */

            R021_FETCH_RELATORIO_DB_SELECT_1();

            /*" -360- MOVE HOST-APOLICE TO C01-APOLICE */
            _.Move(HOST_APOLICE, FILLER01.LD01.C01_APOLICE);

            /*" -361- MOVE HOST-DATA-INICIAL TO C01-DATA-INICIAL */
            _.Move(HOST_DATA_INICIAL, FILLER01.LD01.C01_DATA_INICIAL);

            /*" -362- MOVE HOST-DATA-FINAL TO C01-DATA-FINAL */
            _.Move(HOST_DATA_FINAL, FILLER01.LD01.C01_DATA_FINAL);

            /*" -363- MOVE USUARIOS-NOME-USUARIO TO C01-SOLICITANTE */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, FILLER01.LD01.C01_SOLICITANTE);

            /*" -363- MOVE RELATORI-DATA-SOLICITACAO TO C01-DATA-SOLIC. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, FILLER01.LD01.C01_DATA_SOLIC);

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-FETCH-1 */
        public void R021_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -339- EXEC SQL FETCH RELATORIOS INTO :RELATORI-COD-USUARIO, :RELATORI-DATA-SOLICITACAO, :HOST-DATA-INICIAL, :HOST-DATA-FINAL, :HOST-RAMO-INICIAL, :HOST-CODSUBES-INICIAL, :HOST-APOLICE, :HOST-PRODUTO-INICIAL END-EXEC */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(RELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(RELATORIOS.HOST_DATA_INICIAL, HOST_DATA_INICIAL);
                _.Move(RELATORIOS.HOST_DATA_FINAL, HOST_DATA_FINAL);
                _.Move(RELATORIOS.HOST_RAMO_INICIAL, HOST_RAMO_INICIAL);
                _.Move(RELATORIOS.HOST_CODSUBES_INICIAL, HOST_CODSUBES_INICIAL);
                _.Move(RELATORIOS.HOST_APOLICE, HOST_APOLICE);
                _.Move(RELATORIOS.HOST_PRODUTO_INICIAL, HOST_PRODUTO_INICIAL);
            }

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-CLOSE-1 */
        public void R021_FETCH_RELATORIO_DB_CLOSE_1()
        {
            /*" -343- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-SELECT-1 */
        public void R021_FETCH_RELATORIO_DB_SELECT_1()
        {
            /*" -358- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO END-EXEC. */

            var r021_FETCH_RELATORIO_DB_SELECT_1_Query1 = new R021_FETCH_RELATORIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            var executed_1 = R021_FETCH_RELATORIO_DB_SELECT_1_Query1.Execute(r021_FETCH_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R030-PROCESSA-RELATORIO */
        private void R030_PROCESSA_RELATORIO(bool isPerform = false)
        {
            /*" -371- WRITE REG-ARQ-SAIDA FROM LC03. */
            _.Move(FILLER01.LC03.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -372- WRITE REG-ARQ-SAIDA FROM LC02. */
            _.Move(FILLER01.LC02.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -373- WRITE REG-ARQ-SAIDA FROM LC01. */
            _.Move(FILLER01.LC01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -374- PERFORM R040-GRAVA-COLUNA-A THRU R040-EXIT. */

            R040_GRAVA_COLUNA_A(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


            /*" -375- PERFORM R050-GRAVA-COLUNA-B THRU R050-EXIT. */

            R050_GRAVA_COLUNA_B(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


            /*" -376- PERFORM R060-GRAVA-COLUNA-C THRU R060-EXIT. */

            R060_GRAVA_COLUNA_C(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/


            /*" -377- PERFORM R070-GRAVA-COLUNA-D THRU R070-EXIT. */

            R070_GRAVA_COLUNA_D(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/


            /*" -378- PERFORM R080-GRAVA-COLUNA-E THRU R080-EXIT. */

            R080_GRAVA_COLUNA_E(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/


            /*" -379- PERFORM R090-GRAVA-COLUNA-F THRU R090-EXIT. */

            R090_GRAVA_COLUNA_F(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R090_EXIT*/


            /*" -380- PERFORM R100-GRAVA-COLUNA-G THRU R100-EXIT. */

            R100_GRAVA_COLUNA_G(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/


            /*" -381- PERFORM R110-GRAVA-COLUNA-H THRU R110-EXIT. */

            R110_GRAVA_COLUNA_H(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -382- PERFORM R120-GRAVA-COLUNA-I THRU R120-EXIT. */

            R120_GRAVA_COLUNA_I(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


            /*" -383- PERFORM R130-GRAVA-COLUNA-J THRU R130-EXIT. */

            R130_GRAVA_COLUNA_J(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


            /*" -384- PERFORM R140-GRAVA-COLUNA-K THRU R140-EXIT. */

            R140_GRAVA_COLUNA_K(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/


            /*" -385- PERFORM R150-GRAVA-COLUNA-L THRU R150-EXIT. */

            R150_GRAVA_COLUNA_L(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/


            /*" -386- PERFORM R160-GRAVA-COLUNA-M THRU R160-EXIT. */

            R160_GRAVA_COLUNA_M(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/


            /*" -387- PERFORM R170-GRAVA-COLUNA-N THRU R170-EXIT. */

            R170_GRAVA_COLUNA_N(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/


            /*" -388- PERFORM R180-GRAVA-COLUNA-O THRU R180-EXIT. */

            R180_GRAVA_COLUNA_O(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R180_EXIT*/


            /*" -389- PERFORM R190-GRAVA-COLUNA-P THRU R190-EXIT. */

            R190_GRAVA_COLUNA_P(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R190_EXIT*/


            /*" -391- PERFORM R200-GRAVA-COLUNA-Q THRU R200-EXIT. */

            R200_GRAVA_COLUNA_Q(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -391- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

            R021_FETCH_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R040-GRAVA-COLUNA-A */
        private void R040_GRAVA_COLUNA_A(bool isPerform = false)
        {
            /*" -402- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -414- PERFORM R040_GRAVA_COLUNA_A_DB_SELECT_1 */

            R040_GRAVA_COLUNA_A_DB_SELECT_1();

            /*" -417- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -418- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -419- DISPLAY 'ERRO LEITURA COLUNA A..............' */
                _.Display($"ERRO LEITURA COLUNA A..............");

                /*" -420- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -421- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -422- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -423- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -425- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -426- MOVE 'A' TO C01-NOME-COLUNA. */
            _.Move("A", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -427- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -428- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -430- MOVE 'PREMIO RECEBIDO - REINTEGRACAO         ' TO C01-DESCRICAO. */
            _.Move("PREMIO RECEBIDO - REINTEGRACAO         ", FILLER01.LD01.C01_DESCRICAO);

            /*" -430- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R040-GRAVA-COLUNA-A-DB-SELECT-1 */
        public void R040_GRAVA_COLUNA_A_DB_SELECT_1()
        {
            /*" -414- EXEC SQL SELECT VALUE(SUM(SLA.VALOR_RETENCAO),0) INTO :HOST-VALOR FROM SEGUROS.SINI_LOT_ABAT02 SLA, SEGUROS.SINISTRO_HISTORICO H WHERE SLA.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND SLA.NUM_APOLICE = :HOST-APOLICE AND SLA.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SLA.OCORR_HISTORICO = H.OCORR_HISTORICO AND SLA.COD_OPERACAO = H.COD_OPERACAO AND SLA.COD_RETENCAO IN ( '2' , '5' ) END-EXEC. */

            var r040_GRAVA_COLUNA_A_DB_SELECT_1_Query1 = new R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R040_GRAVA_COLUNA_A_DB_SELECT_1_Query1.Execute(r040_GRAVA_COLUNA_A_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R050-GRAVA-COLUNA-B */
        private void R050_GRAVA_COLUNA_B(bool isPerform = false)
        {
            /*" -441- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -453- PERFORM R050_GRAVA_COLUNA_B_DB_SELECT_1 */

            R050_GRAVA_COLUNA_B_DB_SELECT_1();

            /*" -456- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -457- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -458- DISPLAY 'ERRO LEITURA COLUNA B..............' */
                _.Display($"ERRO LEITURA COLUNA B..............");

                /*" -459- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -460- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -461- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -462- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -464- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -465- MOVE 'B' TO C01-NOME-COLUNA. */
            _.Move("B", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -466- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -467- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -469- MOVE 'PREMIO RECEBIDO - IOF                  ' TO C01-DESCRICAO. */
            _.Move("PREMIO RECEBIDO - IOF                  ", FILLER01.LD01.C01_DESCRICAO);

            /*" -469- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R050-GRAVA-COLUNA-B-DB-SELECT-1 */
        public void R050_GRAVA_COLUNA_B_DB_SELECT_1()
        {
            /*" -453- EXEC SQL SELECT VALUE(SUM(SLA.VALOR_RETENCAO),0) INTO :HOST-VALOR FROM SEGUROS.SINI_LOT_ABAT02 SLA, SEGUROS.SINISTRO_HISTORICO H WHERE SLA.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND SLA.NUM_APOLICE = :HOST-APOLICE AND SLA.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SLA.OCORR_HISTORICO = H.OCORR_HISTORICO AND SLA.COD_OPERACAO = H.COD_OPERACAO AND SLA.COD_RETENCAO IN ( '3' , '6' ) END-EXEC. */

            var r050_GRAVA_COLUNA_B_DB_SELECT_1_Query1 = new R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1.Execute(r050_GRAVA_COLUNA_B_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R060-GRAVA-COLUNA-C */
        private void R060_GRAVA_COLUNA_C(bool isPerform = false)
        {
            /*" -481- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -496- PERFORM R060_GRAVA_COLUNA_C_DB_SELECT_1 */

            R060_GRAVA_COLUNA_C_DB_SELECT_1();

            /*" -499- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -500- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -501- DISPLAY 'ERRO LEITURA COLUNA C..............' */
                _.Display($"ERRO LEITURA COLUNA C..............");

                /*" -502- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -503- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -504- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -505- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -507- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -508- MOVE 'C' TO C01-NOME-COLUNA. */
            _.Move("C", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -509- MOVE 0 TO C01-VALOR. */
            _.Move(0, FILLER01.LD01.C01_VALOR);

            /*" -510- MOVE HOST-QTDE TO C01-QTDE. */
            _.Move(HOST_QTDE, FILLER01.LD01.C01_QTDE);

            /*" -512- MOVE 'SIN.INDEN.COB.VALORES - QTDE - INTERIOR' TO C01-DESCRICAO. */
            _.Move("SIN.INDEN.COB.VALORES - QTDE - INTERIOR", FILLER01.LD01.C01_DESCRICAO);

            /*" -512- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R060-GRAVA-COLUNA-C-DB-SELECT-1 */
        public void R060_GRAVA_COLUNA_C_DB_SELECT_1()
        {
            /*" -496- EXEC SQL SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0) INTO :HOST-QTDE FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND M.COD_CAUSA = 31 AND H.COD_OPERACAO IN (1003,1004) AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL END-EXEC. */

            var r060_GRAVA_COLUNA_C_DB_SELECT_1_Query1 = new R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R060_GRAVA_COLUNA_C_DB_SELECT_1_Query1.Execute(r060_GRAVA_COLUNA_C_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_QTDE, HOST_QTDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

        [StopWatch]
        /*" R070-GRAVA-COLUNA-D */
        private void R070_GRAVA_COLUNA_D(bool isPerform = false)
        {
            /*" -524- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -552- PERFORM R070_GRAVA_COLUNA_D_DB_SELECT_1 */

            R070_GRAVA_COLUNA_D_DB_SELECT_1();

            /*" -555- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -556- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -557- DISPLAY 'ERRO LEITURA COLUNA D..............' */
                _.Display($"ERRO LEITURA COLUNA D..............");

                /*" -558- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -559- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -560- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -561- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -563- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -564- MOVE 'D' TO C01-NOME-COLUNA. */
            _.Move("D", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -565- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -566- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -568- MOVE 'SIN.INDEN.COB.VALORES - $ - INTERIOR.' TO C01-DESCRICAO. */
            _.Move("SIN.INDEN.COB.VALORES - $ - INTERIOR.", FILLER01.LD01.C01_DESCRICAO);

            /*" -568- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R070-GRAVA-COLUNA-D-DB-SELECT-1 */
        public void R070_GRAVA_COLUNA_D_DB_SELECT_1()
        {
            /*" -552- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND M.COD_CAUSA = 31 AND H.COD_OPERACAO IN (1003,1004,1050) AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r070_GRAVA_COLUNA_D_DB_SELECT_1_Query1 = new R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R070_GRAVA_COLUNA_D_DB_SELECT_1_Query1.Execute(r070_GRAVA_COLUNA_D_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/

        [StopWatch]
        /*" R080-GRAVA-COLUNA-E */
        private void R080_GRAVA_COLUNA_E(bool isPerform = false)
        {
            /*" -580- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -595- PERFORM R080_GRAVA_COLUNA_E_DB_SELECT_1 */

            R080_GRAVA_COLUNA_E_DB_SELECT_1();

            /*" -598- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -599- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -600- DISPLAY 'ERRO LEITURA COLUNA E..............' */
                _.Display($"ERRO LEITURA COLUNA E..............");

                /*" -601- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -602- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -603- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -604- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -606- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -607- MOVE 'E' TO C01-NOME-COLUNA. */
            _.Move("E", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -608- MOVE 0 TO C01-VALOR. */
            _.Move(0, FILLER01.LD01.C01_VALOR);

            /*" -609- MOVE HOST-QTDE TO C01-QTDE. */
            _.Move(HOST_QTDE, FILLER01.LD01.C01_QTDE);

            /*" -611- MOVE 'COB.VALORES -QTD-TRANSITO-INDENIZADOS  ' TO C01-DESCRICAO. */
            _.Move("COB.VALORES -QTD-TRANSITO-INDENIZADOS  ", FILLER01.LD01.C01_DESCRICAO);

            /*" -611- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R080-GRAVA-COLUNA-E-DB-SELECT-1 */
        public void R080_GRAVA_COLUNA_E_DB_SELECT_1()
        {
            /*" -595- EXEC SQL SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0) INTO :HOST-QTDE FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND M.COD_CAUSA IN (14,44) AND H.COD_OPERACAO IN (1003,1004) AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL END-EXEC. */

            var r080_GRAVA_COLUNA_E_DB_SELECT_1_Query1 = new R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R080_GRAVA_COLUNA_E_DB_SELECT_1_Query1.Execute(r080_GRAVA_COLUNA_E_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_QTDE, HOST_QTDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/

        [StopWatch]
        /*" R090-GRAVA-COLUNA-F */
        private void R090_GRAVA_COLUNA_F(bool isPerform = false)
        {
            /*" -624- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -652- PERFORM R090_GRAVA_COLUNA_F_DB_SELECT_1 */

            R090_GRAVA_COLUNA_F_DB_SELECT_1();

            /*" -655- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -656- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -657- DISPLAY 'ERRO LEITURA COLUNA F..............' */
                _.Display($"ERRO LEITURA COLUNA F..............");

                /*" -658- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -659- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -660- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -661- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -663- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -664- MOVE 'F' TO C01-NOME-COLUNA. */
            _.Move("F", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -665- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -666- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -668- MOVE 'COB.VALORES- $ - TRANSITO - INDENIZADOS' TO C01-DESCRICAO. */
            _.Move("COB.VALORES- $ - TRANSITO - INDENIZADOS", FILLER01.LD01.C01_DESCRICAO);

            /*" -668- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R090-GRAVA-COLUNA-F-DB-SELECT-1 */
        public void R090_GRAVA_COLUNA_F_DB_SELECT_1()
        {
            /*" -652- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND M.COD_CAUSA IN (14,44) AND H.COD_OPERACAO IN (1003,1004,1050) AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r090_GRAVA_COLUNA_F_DB_SELECT_1_Query1 = new R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R090_GRAVA_COLUNA_F_DB_SELECT_1_Query1.Execute(r090_GRAVA_COLUNA_F_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R090_EXIT*/

        [StopWatch]
        /*" R100-GRAVA-COLUNA-G */
        private void R100_GRAVA_COLUNA_G(bool isPerform = false)
        {
            /*" -681- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -696- PERFORM R100_GRAVA_COLUNA_G_DB_SELECT_1 */

            R100_GRAVA_COLUNA_G_DB_SELECT_1();

            /*" -700- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -701- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -702- DISPLAY 'ERRO LEITURA COLUNA G..............' */
                _.Display($"ERRO LEITURA COLUNA G..............");

                /*" -703- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -704- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -705- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -706- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -708- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -709- MOVE 'G' TO C01-NOME-COLUNA. */
            _.Move("G", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -710- MOVE 0 TO C01-VALOR. */
            _.Move(0, FILLER01.LD01.C01_VALOR);

            /*" -711- MOVE HOST-QTDE TO C01-QTDE. */
            _.Move(HOST_QTDE, FILLER01.LD01.C01_QTDE);

            /*" -713- MOVE 'COB.VALORES-QTD-OUTRAS CAUSAS-INDENIZ. ' TO C01-DESCRICAO. */
            _.Move("COB.VALORES-QTD-OUTRAS CAUSAS-INDENIZ. ", FILLER01.LD01.C01_DESCRICAO);

            /*" -713- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R100-GRAVA-COLUNA-G-DB-SELECT-1 */
        public void R100_GRAVA_COLUNA_G_DB_SELECT_1()
        {
            /*" -696- EXEC SQL SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0) INTO :HOST-QTDE FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND M.COD_CAUSA NOT IN (31,14,44) AND H.COD_OPERACAO IN (1003,1004) AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL END-EXEC. */

            var r100_GRAVA_COLUNA_G_DB_SELECT_1_Query1 = new R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R100_GRAVA_COLUNA_G_DB_SELECT_1_Query1.Execute(r100_GRAVA_COLUNA_G_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_QTDE, HOST_QTDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-GRAVA-COLUNA-H */
        private void R110_GRAVA_COLUNA_H(bool isPerform = false)
        {
            /*" -725- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -753- PERFORM R110_GRAVA_COLUNA_H_DB_SELECT_1 */

            R110_GRAVA_COLUNA_H_DB_SELECT_1();

            /*" -756- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -757- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -758- DISPLAY 'ERRO LEITURA COLUNA H..............' */
                _.Display($"ERRO LEITURA COLUNA H..............");

                /*" -759- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -760- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -761- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -762- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -764- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -765- MOVE 'H' TO C01-NOME-COLUNA. */
            _.Move("H", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -766- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -767- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -769- MOVE 'COB.VALORES-$-OUTRAS CAUSAS-INDENIZADOS' TO C01-DESCRICAO. */
            _.Move("COB.VALORES-$-OUTRAS CAUSAS-INDENIZADOS", FILLER01.LD01.C01_DESCRICAO);

            /*" -769- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R110-GRAVA-COLUNA-H-DB-SELECT-1 */
        public void R110_GRAVA_COLUNA_H_DB_SELECT_1()
        {
            /*" -753- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND M.COD_CAUSA NOT IN (31,14,44) AND H.COD_OPERACAO IN (1003,1004,1050) AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r110_GRAVA_COLUNA_H_DB_SELECT_1_Query1 = new R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R110_GRAVA_COLUNA_H_DB_SELECT_1_Query1.Execute(r110_GRAVA_COLUNA_H_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-GRAVA-COLUNA-I */
        private void R120_GRAVA_COLUNA_I(bool isPerform = false)
        {
            /*" -781- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -795- PERFORM R120_GRAVA_COLUNA_I_DB_SELECT_1 */

            R120_GRAVA_COLUNA_I_DB_SELECT_1();

            /*" -798- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -799- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -800- DISPLAY 'ERRO LEITURA COLUNA I..............' */
                _.Display($"ERRO LEITURA COLUNA I..............");

                /*" -801- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -802- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -803- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -804- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -806- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -807- MOVE 'I' TO C01-NOME-COLUNA. */
            _.Move("I", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -808- MOVE 0 TO C01-VALOR. */
            _.Move(0, FILLER01.LD01.C01_VALOR);

            /*" -809- MOVE HOST-QTDE TO C01-QTDE. */
            _.Move(HOST_QTDE, FILLER01.LD01.C01_QTDE);

            /*" -811- MOVE 'COB.QUE NAO SAO DE VAL.- QTD - INDENIZ.' TO C01-DESCRICAO. */
            _.Move("COB.QUE NAO SAO DE VAL.- QTD - INDENIZ.", FILLER01.LD01.C01_DESCRICAO);

            /*" -811- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R120-GRAVA-COLUNA-I-DB-SELECT-1 */
        public void R120_GRAVA_COLUNA_I_DB_SELECT_1()
        {
            /*" -795- EXEC SQL SELECT VALUE(COUNT(DISTINCT M.NUM_APOL_SINISTRO),0) INTO :HOST-QTDE FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA <> 4 AND H.COD_OPERACAO IN (1003,1004) AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL END-EXEC. */

            var r120_GRAVA_COLUNA_I_DB_SELECT_1_Query1 = new R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R120_GRAVA_COLUNA_I_DB_SELECT_1_Query1.Execute(r120_GRAVA_COLUNA_I_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_QTDE, HOST_QTDE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-GRAVA-COLUNA-J */
        private void R130_GRAVA_COLUNA_J(bool isPerform = false)
        {
            /*" -823- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -850- PERFORM R130_GRAVA_COLUNA_J_DB_SELECT_1 */

            R130_GRAVA_COLUNA_J_DB_SELECT_1();

            /*" -853- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -854- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -855- DISPLAY 'ERRO LEITURA COLUNA J..............' */
                _.Display($"ERRO LEITURA COLUNA J..............");

                /*" -856- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -857- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -858- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -859- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -861- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -862- MOVE 'J' TO C01-NOME-COLUNA. */
            _.Move("J", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -863- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -864- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -866- MOVE 'COB.QUE NAO SAO VALORES -$- INDENIZADOS' TO C01-DESCRICAO. */
            _.Move("COB.QUE NAO SAO VALORES -$- INDENIZADOS", FILLER01.LD01.C01_DESCRICAO);

            /*" -866- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R130-GRAVA-COLUNA-J-DB-SELECT-1 */
        public void R130_GRAVA_COLUNA_J_DB_SELECT_1()
        {
            /*" -850- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA <> 4 AND H.COD_OPERACAO IN (1003,1004,1050) AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r130_GRAVA_COLUNA_J_DB_SELECT_1_Query1 = new R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R130_GRAVA_COLUNA_J_DB_SELECT_1_Query1.Execute(r130_GRAVA_COLUNA_J_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R140-GRAVA-COLUNA-K */
        private void R140_GRAVA_COLUNA_K(bool isPerform = false)
        {
            /*" -877- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -903- PERFORM R140_GRAVA_COLUNA_K_DB_SELECT_1 */

            R140_GRAVA_COLUNA_K_DB_SELECT_1();

            /*" -906- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -907- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -908- DISPLAY 'ERRO LEITURA COLUNA K..............' */
                _.Display($"ERRO LEITURA COLUNA K..............");

                /*" -909- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -910- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -911- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -912- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -914- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -915- MOVE 'K' TO C01-NOME-COLUNA. */
            _.Move("K", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -916- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -917- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -919- MOVE 'TOTAL DE SINISTROS INDENIZADOS         ' TO C01-DESCRICAO. */
            _.Move("TOTAL DE SINISTROS INDENIZADOS         ", FILLER01.LD01.C01_DESCRICAO);

            /*" -919- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R140-GRAVA-COLUNA-K-DB-SELECT-1 */
        public void R140_GRAVA_COLUNA_K_DB_SELECT_1()
        {
            /*" -903- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND H.COD_OPERACAO IN (1003,1004,1050) AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 2 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r140_GRAVA_COLUNA_K_DB_SELECT_1_Query1 = new R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R140_GRAVA_COLUNA_K_DB_SELECT_1_Query1.Execute(r140_GRAVA_COLUNA_K_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R140_EXIT*/

        [StopWatch]
        /*" R150-GRAVA-COLUNA-L */
        private void R150_GRAVA_COLUNA_L(bool isPerform = false)
        {
            /*" -931- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -957- PERFORM R150_GRAVA_COLUNA_L_DB_SELECT_1 */

            R150_GRAVA_COLUNA_L_DB_SELECT_1();

            /*" -960- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -961- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -962- DISPLAY 'ERRO LEITURA COLUNA L..............' */
                _.Display($"ERRO LEITURA COLUNA L..............");

                /*" -963- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -964- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -965- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -967- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -968- MOVE 'L' TO C01-NOME-COLUNA. */
            _.Move("L", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -969- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -970- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -972- MOVE 'SINISTRO PENDENTE - COBERTURA VALORES  ' TO C01-DESCRICAO. */
            _.Move("SINISTRO PENDENTE - COBERTURA VALORES  ", FILLER01.LD01.C01_DESCRICAO);

            /*" -972- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R150-GRAVA-COLUNA-L-DB-SELECT-1 */
        public void R150_GRAVA_COLUNA_L_DB_SELECT_1()
        {
            /*" -957- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 AND H.DATA_MOVIMENTO <= :HOST-DATA-FINAL AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 1 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r150_GRAVA_COLUNA_L_DB_SELECT_1_Query1 = new R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1()
            {
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R150_GRAVA_COLUNA_L_DB_SELECT_1_Query1.Execute(r150_GRAVA_COLUNA_L_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R150_EXIT*/

        [StopWatch]
        /*" R160-GRAVA-COLUNA-M */
        private void R160_GRAVA_COLUNA_M(bool isPerform = false)
        {
            /*" -985- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1011- PERFORM R160_GRAVA_COLUNA_M_DB_SELECT_1 */

            R160_GRAVA_COLUNA_M_DB_SELECT_1();

            /*" -1014- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1015- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1016- DISPLAY 'ERRO LEITURA COLUNA M..............' */
                _.Display($"ERRO LEITURA COLUNA M..............");

                /*" -1017- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -1018- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -1019- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1021- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1022- MOVE 'M' TO C01-NOME-COLUNA. */
            _.Move("M", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -1023- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -1024- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -1026- MOVE 'SINISTRO PENDENTE - OUTRAS COBERTURAS  ' TO C01-DESCRICAO. */
            _.Move("SINISTRO PENDENTE - OUTRAS COBERTURAS  ", FILLER01.LD01.C01_DESCRICAO);

            /*" -1026- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R160-GRAVA-COLUNA-M-DB-SELECT-1 */
        public void R160_GRAVA_COLUNA_M_DB_SELECT_1()
        {
            /*" -1011- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * O.NUM_FATOR),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINI_LOTERICO01 SL, SEGUROS.GE_SIS_FUNCAO_OPER O, SEGUROS.SINISTRO_HISTORICO H WHERE M.COD_PRODUTO = 7105 AND M.NUM_APOLICE = :HOST-APOLICE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND M.NUM_APOL_SINISTRO = SL.NUM_APOL_SINISTRO AND SL.COD_COBERTURA <> 4 AND H.DATA_MOVIMENTO <= :HOST-DATA-FINAL AND O.IDE_SISTEMA = 'SI' AND O.COD_FUNCAO = 1 AND O.IDE_SISTEMA_OPER = O.IDE_SISTEMA AND O.COD_OPERACAO = H.COD_OPERACAO AND O.TIPO_ENDOSSO = '9' AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1070) END-EXEC. */

            var r160_GRAVA_COLUNA_M_DB_SELECT_1_Query1 = new R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1()
            {
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R160_GRAVA_COLUNA_M_DB_SELECT_1_Query1.Execute(r160_GRAVA_COLUNA_M_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R160_EXIT*/

        [StopWatch]
        /*" R170-GRAVA-COLUNA-N */
        private void R170_GRAVA_COLUNA_N(bool isPerform = false)
        {
            /*" -1038- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1049- PERFORM R170_GRAVA_COLUNA_N_DB_SELECT_1 */

            R170_GRAVA_COLUNA_N_DB_SELECT_1();

            /*" -1052- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1053- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1054- DISPLAY 'ERRO LEITURA COLUNA N..............' */
                _.Display($"ERRO LEITURA COLUNA N..............");

                /*" -1055- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -1056- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -1057- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -1058- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1060- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1061- MOVE 'N' TO C01-NOME-COLUNA. */
            _.Move("N", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -1062- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -1063- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -1065- MOVE 'SINISTROS AVISADOS - COBERTURAS VALORES' TO C01-DESCRICAO. */
            _.Move("SINISTROS AVISADOS - COBERTURAS VALORES", FILLER01.LD01.C01_DESCRICAO);

            /*" -1065- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R170-GRAVA-COLUNA-N-DB-SELECT-1 */
        public void R170_GRAVA_COLUNA_N_DB_SELECT_1()
        {
            /*" -1049- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-VALOR FROM SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_HISTORICO H WHERE H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND H.COD_OPERACAO = 101 AND H.NUM_APOLICE = :HOST-APOLICE AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SL.COD_COBERTURA = 4 END-EXEC. */

            var r170_GRAVA_COLUNA_N_DB_SELECT_1_Query1 = new R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R170_GRAVA_COLUNA_N_DB_SELECT_1_Query1.Execute(r170_GRAVA_COLUNA_N_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R170_EXIT*/

        [StopWatch]
        /*" R180-GRAVA-COLUNA-O */
        private void R180_GRAVA_COLUNA_O(bool isPerform = false)
        {
            /*" -1078- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1089- PERFORM R180_GRAVA_COLUNA_O_DB_SELECT_1 */

            R180_GRAVA_COLUNA_O_DB_SELECT_1();

            /*" -1092- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1093- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1094- DISPLAY 'ERRO LEITURA COLUNA O..............' */
                _.Display($"ERRO LEITURA COLUNA O..............");

                /*" -1095- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -1096- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -1097- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -1098- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1100- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1101- MOVE 'O' TO C01-NOME-COLUNA. */
            _.Move("O", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -1102- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -1103- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -1105- MOVE 'SINISTROS AVISADOS - OUTRAS COBERTURAS ' TO C01-DESCRICAO. */
            _.Move("SINISTROS AVISADOS - OUTRAS COBERTURAS ", FILLER01.LD01.C01_DESCRICAO);

            /*" -1105- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R180-GRAVA-COLUNA-O-DB-SELECT-1 */
        public void R180_GRAVA_COLUNA_O_DB_SELECT_1()
        {
            /*" -1089- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-VALOR FROM SEGUROS.SINI_LOTERICO01 SL, SEGUROS.SINISTRO_HISTORICO H WHERE H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND H.COD_OPERACAO = 101 AND H.NUM_APOLICE = :HOST-APOLICE AND SL.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND SL.COD_COBERTURA <> 4 END-EXEC. */

            var r180_GRAVA_COLUNA_O_DB_SELECT_1_Query1 = new R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R180_GRAVA_COLUNA_O_DB_SELECT_1_Query1.Execute(r180_GRAVA_COLUNA_O_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R180_EXIT*/

        [StopWatch]
        /*" R190-GRAVA-COLUNA-P */
        private void R190_GRAVA_COLUNA_P(bool isPerform = false)
        {
            /*" -1117- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1126- PERFORM R190_GRAVA_COLUNA_P_DB_SELECT_1 */

            R190_GRAVA_COLUNA_P_DB_SELECT_1();

            /*" -1129- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1130- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1131- DISPLAY 'ERRO LEITURA COLUNA P..............' */
                _.Display($"ERRO LEITURA COLUNA P..............");

                /*" -1132- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -1133- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -1134- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -1135- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1137- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1138- MOVE 'P' TO C01-NOME-COLUNA. */
            _.Move("P", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -1139- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -1140- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -1142- MOVE 'ADIANTAMENTOS FINALIZADOS              ' TO C01-DESCRICAO. */
            _.Move("ADIANTAMENTOS FINALIZADOS              ", FILLER01.LD01.C01_DESCRICAO);

            /*" -1142- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R190-GRAVA-COLUNA-P-DB-SELECT-1 */
        public void R190_GRAVA_COLUNA_P_DB_SELECT_1()
        {
            /*" -1126- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.COD_PRODUTO = 7105 AND H.NUM_APOLICE = :HOST-APOLICE AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND H.COD_OPERACAO = 1070 END-EXEC. */

            var r190_GRAVA_COLUNA_P_DB_SELECT_1_Query1 = new R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R190_GRAVA_COLUNA_P_DB_SELECT_1_Query1.Execute(r190_GRAVA_COLUNA_P_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R190_EXIT*/

        [StopWatch]
        /*" R200-GRAVA-COLUNA-Q */
        private void R200_GRAVA_COLUNA_Q(bool isPerform = false)
        {
            /*" -1154- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1175- PERFORM R200_GRAVA_COLUNA_Q_DB_SELECT_1 */

            R200_GRAVA_COLUNA_Q_DB_SELECT_1();

            /*" -1178- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1179- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1180- DISPLAY 'ERRO LEITURA COLUNA Q..............' */
                _.Display($"ERRO LEITURA COLUNA Q..............");

                /*" -1181- DISPLAY 'NUM APOLICE : ' HOST-APOLICE */
                _.Display($"NUM APOLICE : {HOST_APOLICE}");

                /*" -1182- DISPLAY 'DATA INICIO : ' HOST-DATA-INICIAL */
                _.Display($"DATA INICIO : {HOST_DATA_INICIAL}");

                /*" -1183- DISPLAY 'DATA FIM    : ' HOST-DATA-FINAL */
                _.Display($"DATA FIM    : {HOST_DATA_FINAL}");

                /*" -1184- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1186- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1187- MOVE 'Q' TO C01-NOME-COLUNA. */
            _.Move("Q", FILLER01.LD01.C01_NOME_COLUNA);

            /*" -1188- MOVE 0 TO C01-QTDE. */
            _.Move(0, FILLER01.LD01.C01_QTDE);

            /*" -1189- MOVE HOST-VALOR TO C01-VALOR. */
            _.Move(HOST_VALOR, FILLER01.LD01.C01_VALOR);

            /*" -1191- MOVE 'ADIANTAMENTOS ESTORNADOS               ' TO C01-DESCRICAO. */
            _.Move("ADIANTAMENTOS ESTORNADOS               ", FILLER01.LD01.C01_DESCRICAO);

            /*" -1191- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R200-GRAVA-COLUNA-Q-DB-SELECT-1 */
        public void R200_GRAVA_COLUNA_Q_DB_SELECT_1()
        {
            /*" -1175- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO),0) INTO :HOST-VALOR FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.COD_PRODUTO = 7105 AND H.NUM_APOLICE = :HOST-APOLICE AND H.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL AND :HOST-DATA-FINAL AND H.COD_OPERACAO = 1070 AND EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.OCORR_HISTORICO = H.OCORR_HISTORICO AND S.COD_OPERACAO = 1050) AND NOT EXISTS (SELECT S.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO S WHERE S.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND S.COD_OPERACAO IN (1003,1004) AND S.SIT_REGISTRO <> '2' ) END-EXEC. */

            var r200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1 = new R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1()
            {
                HOST_DATA_INICIAL = HOST_DATA_INICIAL.ToString(),
                HOST_DATA_FINAL = HOST_DATA_FINAL.ToString(),
                HOST_APOLICE = HOST_APOLICE.ToString(),
            };

            var executed_1 = R200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1.Execute(r200_GRAVA_COLUNA_Q_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VALOR, HOST_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1203- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

            /*" -1204- IF W-CHAVE-ARQ-SAIDA-JA-ABERTO EQUAL 'SIM' */

            if (W_INICIO_WORK.W_CHAVE_ARQ_SAIDA_JA_ABERTO == "SIM")
            {

                /*" -1206- CLOSE ARQ-SAIDA. */
                ARQ_SAIDA.Close();
            }


            /*" -1208- DISPLAY WABEND */
            _.Display(FILLER_0.WABEND);

            /*" -1208- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -1210- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1214- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1214- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}