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
using Sias.PessoaFisica.DB2.PF0717B;

namespace Code
{
    public class PF0717B
    {
        public bool IsCall { get; set; }

        public PF0717B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA STATUS DE CANCELAMENTO O NOVO   *      */
        /*"      *                           EMPRESARIAL AO SIGPF. VIDA           *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS.                         *      */
        /*"      *   PROGRAMA .............  PF0717B                              *      */
        /*"      *   DATA .................  23/11/2004.                          *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA                          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03                                                      *      */
        /*"      *            INCLUI NOVO SELECT NO CURSOR PRINCIPAL UTILIZANDO   *      */
        /*"      *            NOVAS REGRAS PARA ATENDER A DEMANDA 64430           *      */
        /*"      *            -----                                               *      */
        /*"      * 06/12/2011 PROCURE POR 64430 - REGINALDO SILVA                 *      */
        /*"      *            SOLICITADO POR LUIZ CARLOS CONCEICAO                *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 02                                                      *      */
        /*"      *            INCLUI NOVO SELECT NO CURSOR PRINCIPAL UTILIZANDO   *      */
        /*"      *            UNION  PARA ATENDER PROPOSTAS VIDA EMPRESARIAL ANUAL*      */
        /*"      *            -----                                               *      */
        /*"      * 17/06/2008 PROCURE POR V.02 - LUCIA VIEIRA                     *      */
        /*"      ******************************************************************      */
        /*"      * VERSAO 01                                                      *      */
        /*"      *            DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.01 - MAURICIO LINKE.                  *      */
        /*"      ******************************************************************      */
        /*"1     **********************                                                  */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_STA_SASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_SASSE
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA_SASSE); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA_SASSE, REG_STA_SASSE); return _MOVTO_STA_SASSE;
            }
        }
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-DATA-REFERENCIA            PIC X(010).*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WAREA-AUXILIAR.*/
        public PF0717B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0717B_WAREA_AUXILIAR();
        public class PF0717B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-TERMO             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_TERMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-DESPREZADO                  PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-NSAS                        PIC 9(006).*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(008).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-CONTROLE                    PIC 9(006).*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0717B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0717B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0717B_FILLER_0(); _.Move(W_DATA_TRABALHO, _filler_0); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_0, W_DATA_TRABALHO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DATA_TRABALHO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0717B_FILLER_0 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0717B_FILLER_0()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0717B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0717B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0717B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0717B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_PF0717B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0717B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0717B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0717B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0717B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_PF0717B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0717B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0717B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0717B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0717B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W-HISTORICO                    PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0717B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_HISTORICO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 HISTORICO-CADASTRADO                    VALUE 1. */
							new SelectorItemBasis("HISTORICO_CADASTRADO", "1"),
							/*" 88 HISTORICO-NAO-CADASTRADO                VALUE 2. */
							new SelectorItemBasis("HISTORICO_NAO_CADASTRADO", "2")
                }
            };

            /*"01  WABEND*/
        }
        public PF0717B_WABEND WABEND { get; set; } = new PF0717B_WABEND();
        public class PF0717B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0717B_FILLER_1 FILLER_1 { get; set; } = new PF0717B_FILLER_1();
            public class PF0717B_FILLER_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0717B  '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0717B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0717B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0717B_LOCALIZA_ABEND_1();
            public class PF0717B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0717B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0717B_LOCALIZA_ABEND_2();
            public class PF0717B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF200 LBFPF200 { get; set; } = new Copies.LBFPF200();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0717B_TERMO_ADESAO TERMO_ADESAO { get; set; } = new PF0717B_TERMO_ADESAO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -203- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -204- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -205- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -208- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -209- DISPLAY '*               PROGRAMA PF0717B               *' . */
            _.Display($"*               PROGRAMA PF0717B               *");

            /*" -210- DISPLAY '* GERA STATUS DE CANCELAMENTO DO NOVO VIDA EMP *' . */
            _.Display($"* GERA STATUS DE CANCELAMENTO DO NOVO VIDA EMP *");

            /*" -211- DISPLAY '*           VERSAO:  04 - 29/11/2013           *' . */
            _.Display($"*           VERSAO:  04 - 29/11/2013           *");

            /*" -212- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -221- DISPLAY '*  PF0717B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0717B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -223- PERFORM R0005-00-INICIALIZAR. */

            R0005_00_INICIALIZAR_SECTION();

            /*" -225- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -227- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -229- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

            /*" -230- IF W-FIM-MOVTO-TERMO EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -231- DISPLAY '*----------------------------------------*' */
                _.Display($"*----------------------------------------*");

                /*" -232- DISPLAY '* PF0717B - TERMINO NORMAL, NAO HOUVE    *' */
                _.Display($"* PF0717B - TERMINO NORMAL, NAO HOUVE    *");

                /*" -233- DISPLAY '*           MOVIMENTO NA DATA SOLICITADA *' */
                _.Display($"*           MOVIMENTO NA DATA SOLICITADA *");

                /*" -234- DISPLAY '*----------------------------------------*' */
                _.Display($"*----------------------------------------*");

                /*" -235- PERFORM R1100-00-GERAR-TOTAIS */

                R1100_00_GERAR_TOTAIS_SECTION();

                /*" -236- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -238- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -240- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -243- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-TERMO EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -245- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -247- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -249- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -251- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -251- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-INICIALIZAR-SECTION */
        private void R0005_00_INICIALIZAR_SECTION()
        {
            /*" -259- MOVE 'R0005-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0005-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -261- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -263- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -271- PERFORM R0005_00_INICIALIZAR_DB_SELECT_1 */

            R0005_00_INICIALIZAR_DB_SELECT_1();

            /*" -276- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -278- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -280- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -283- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -287- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -290- DISPLAY '*  PF0717B - DATA PROCESSAMENTO...' W-DTMOVABE-I1. */
            _.Display($"*  PF0717B - DATA PROCESSAMENTO...{WAREA_AUXILIAR.W_DTMOVABE_I1}");

            /*" -292- INITIALIZE REG-TRAILLER-STA. */
            _.Initialize(
                LBFCT011.REG_TRAILLER_STA
            );

            /*" -292- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }

        [StopWatch]
        /*" R0005-00-INICIALIZAR-DB-SELECT-1 */
        public void R0005_00_INICIALIZAR_DB_SELECT_1()
        {
            /*" -271- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_INICIALIZAR_DB_SELECT_1_Query1 = new R0005_00_INICIALIZAR_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_INICIALIZAR_DB_SELECT_1_Query1.Execute(r0005_00_INICIALIZAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REFERENCIA, WHOST_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -302- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -304- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -307- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -311- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -320- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -323- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -324- DISPLAY 'PF0717B - FIM ANORMAL' */
                _.Display($"PF0717B - FIM ANORMAL");

                /*" -325- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -327- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -328- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -330- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -333- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -335- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -335- MOVE W-NSAS TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -320- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -345- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -347- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -348- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -350- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -353- DISPLAY '** PF0717B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** PF0717B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -354- MOVE 109300000672 TO TERMOADE-NUM-APOLICE */
            _.Move(109300000672, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);

            /*" -355- MOVE '2' TO TERMOADE-SITUACAO */
            _.Move("2", TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO);

            /*" -357- MOVE '4' TO PROPOVA-SIT-REGISTRO */
            _.Move("4", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

            /*" -415- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -417- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -420- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -422- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -424- DISPLAY '** PF0717B ** FIM    DECLARE V0MOVIMENTO...  ' W-TIME-EDIT */
            _.Display($"** PF0717B ** FIM    DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -424- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -415- EXEC SQL DECLARE TERMO-ADESAO CURSOR FOR SELECT B.NUM_TERMO , B.NUM_APOLICE , B.COD_SUBGRUPO , DATE(B.TIMESTAMP) , C.NUM_PARCELA , D.SIT_PROPOSTA , D.NUM_PROPOSTA_SIVPF , D.NUM_IDENTIFICACAO , D.COD_EMPRESA_SIVPF , D.COD_PRODUTO_SIVPF FROM SEGUROS.PRODUTOS_VG A, SEGUROS.TERMO_ADESAO B, SEGUROS.PROPOSTAS_VA C, SEGUROS.PROPOSTA_FIDELIZ D WHERE A.ORIG_PRODU IN ( 'EMPRE' , 'GLOBAL' ) AND A.COD_SUBGRUPO > 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.SITUACAO = :TERMOADE-SITUACAO AND D.NUM_SICOB = B.NUM_TERMO AND C.NUM_CERTIFICADO = D.NUM_PROPOSTA_SIVPF AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.SIT_REGISTRO = :PROPOVA-SIT-REGISTRO AND DATE(C.TIMESTAMP) >= :SISTEMAS-DATA-MOV-ABERTO UNION SELECT B.NUM_TERMO , B.NUM_APOLICE , B.COD_SUBGRUPO , DATE(B.TIMESTAMP) , C.NUM_PARCELA , D.SIT_PROPOSTA , D.NUM_PROPOSTA_SIVPF , D.NUM_IDENTIFICACAO , D.COD_EMPRESA_SIVPF , D.COD_PRODUTO_SIVPF FROM SEGUROS.PRODUTOS_VG A, SEGUROS.TERMO_ADESAO B, SEGUROS.PROPOSTAS_VA C, SEGUROS.PROPOSTA_FIDELIZ D WHERE A.ORIG_PRODU IN ( 'EMPRE' , 'GLOBAL' ) AND A.COD_SUBGRUPO > 0 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.SITUACAO = :TERMOADE-SITUACAO AND D.NUM_SICOB = B.NUM_TERMO AND C.NUM_CERTIFICADO = D.NUM_SICOB AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.SIT_REGISTRO = :PROPOVA-SIT-REGISTRO AND DATE(C.TIMESTAMP) >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY 1 , 3 WITH UR END-EXEC. */
            TERMO_ADESAO = new PF0717B_TERMO_ADESAO(true);
            string GetQuery_TERMO_ADESAO()
            {
                var query = @$"SELECT B.NUM_TERMO
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							DATE(B.TIMESTAMP)
							, 
							C.NUM_PARCELA
							, 
							D.SIT_PROPOSTA
							, 
							D.NUM_PROPOSTA_SIVPF
							, 
							D.NUM_IDENTIFICACAO
							, 
							D.COD_EMPRESA_SIVPF
							, 
							D.COD_PRODUTO_SIVPF 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.TERMO_ADESAO B
							, 
							SEGUROS.PROPOSTAS_VA C
							, 
							SEGUROS.PROPOSTA_FIDELIZ D 
							WHERE A.ORIG_PRODU IN ( 'EMPRE'
							, 'GLOBAL' ) 
							AND A.COD_SUBGRUPO > 0 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.SITUACAO = '{TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO}' 
							AND D.NUM_SICOB = B.NUM_TERMO 
							AND C.NUM_CERTIFICADO = D.NUM_PROPOSTA_SIVPF 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.SIT_REGISTRO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}' 
							AND DATE(C.TIMESTAMP) >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							UNION 
							SELECT B.NUM_TERMO
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							DATE(B.TIMESTAMP)
							, 
							C.NUM_PARCELA
							, 
							D.SIT_PROPOSTA
							, 
							D.NUM_PROPOSTA_SIVPF
							, 
							D.NUM_IDENTIFICACAO
							, 
							D.COD_EMPRESA_SIVPF
							, 
							D.COD_PRODUTO_SIVPF 
							FROM SEGUROS.PRODUTOS_VG A
							, 
							SEGUROS.TERMO_ADESAO B
							, 
							SEGUROS.PROPOSTAS_VA C
							, 
							SEGUROS.PROPOSTA_FIDELIZ D 
							WHERE A.ORIG_PRODU IN ( 'EMPRE'
							, 'GLOBAL' ) 
							AND A.COD_SUBGRUPO > 0 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND B.SITUACAO = '{TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO}' 
							AND D.NUM_SICOB = B.NUM_TERMO 
							AND C.NUM_CERTIFICADO = D.NUM_SICOB 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.SIT_REGISTRO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}' 
							AND DATE(C.TIMESTAMP) >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY 1
							, 3";

                return query;
            }
            TERMO_ADESAO.GetQueryEvent += GetQuery_TERMO_ADESAO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -417- EXEC SQL OPEN TERMO-ADESAO END-EXEC. */

            TERMO_ADESAO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -434- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -436- MOVE 'FETCH TERMO-ADESAO' TO COMANDO. */
            _.Move("FETCH TERMO-ADESAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -448- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -451- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -452- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -453- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                    /*" -453- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -455- ELSE */
                }
                else
                {


                    /*" -456- DISPLAY 'PF0717B - FIM ANORMAL' */
                    _.Display($"PF0717B - FIM ANORMAL");

                    /*" -458- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -459- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -460- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -462- ELSE */
                }

            }
            else
            {


                /*" -465- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -466- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -467- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -468- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -469- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -470- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -472- DISPLAY '** PF0717B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0717B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -472- DISPLAY ' ' . */
                    _.Display($" ");
                }

            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -448- EXEC SQL FETCH TERMO-ADESAO INTO :TERMOADE-NUM-TERMO , :TERMOADE-NUM-APOLICE , :TERMOADE-COD-SUBGRUPO , :PROPOVA-DATA-MOVIMENTO , :PROPOVA-NUM-PARCELA , :PROPOFID-SIT-PROPOSTA , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF END-EXEC. */

            if (TERMO_ADESAO.Fetch())
            {
                _.Move(TERMO_ADESAO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(TERMO_ADESAO.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(TERMO_ADESAO.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
                _.Move(TERMO_ADESAO.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(TERMO_ADESAO.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(TERMO_ADESAO.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(TERMO_ADESAO.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(TERMO_ADESAO.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(TERMO_ADESAO.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -453- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -482- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -484- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -487- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -490- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -493- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -494- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -495- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -496- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -499- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -502- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -505- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -505- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -515- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -517- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -520- INITIALIZE REG-STA-PROPOSTA REG-PGTO-SASSE */
            _.Initialize(
                LBFCT011.REG_STA_PROPOSTA
                , LBFCT016.REG_PGTO_SASSE
            );

            /*" -522- PERFORM R0290-00-DEFINIR-SIT-MOTIVO */

            R0290_00_DEFINIR_SIT_MOTIVO_SECTION();

            /*" -524- PERFORM R0580-00-LER-HIST-FIDELIZ */

            R0580_00_LER_HIST_FIDELIZ_SECTION();

            /*" -525- IF HISTORICO-CADASTRADO */

            if (WAREA_AUXILIAR.W_HISTORICO["HISTORICO_CADASTRADO"])
            {

                /*" -526- ADD 1 TO W-DESPREZADO */
                WAREA_AUXILIAR.W_DESPREZADO.Value = WAREA_AUXILIAR.W_DESPREZADO + 1;

                /*" -528- DISPLAY 'PF0717B - MOVIMENTO GERADO ANTERIORMENTE ====> ' TERMOADE-NUM-TERMO '  ' PROPOFID-NUM-PROPOSTA-SIVPF */

                $"PF0717B - MOVIMENTO GERADO ANTERIORMENTE ====> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -530- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -531- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

            R0800_00_STATUS_REGISTRO_TP1_SECTION();

            /*" -532- PERFORM R0950-00-STATUS-REGISTRO-TP4 */

            R0950_00_STATUS_REGISTRO_TP4_SECTION();

            /*" -533- PERFORM R3390-GERA-HIST-FIDELIZACAO */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

            /*" -533- PERFORM R3400-00-ATUALIZA-PROPOSTA. */

            R3400_00_ATUALIZA_PROPOSTA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -538- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
            {

                /*" -538- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0290-00-DEFINIR-SIT-MOTIVO-SECTION */
        private void R0290_00_DEFINIR_SIT_MOTIVO_SECTION()
        {
            /*" -547- MOVE 'R0290-00-DEFINIR-SIT-MOTIVO' TO PARAGRAFO. */
            _.Move("R0290-00-DEFINIR-SIT-MOTIVO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -549- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -551- MOVE 'CAN' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move("CAN", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -553- MOVE 'SUS' TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move("SUS", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -553- MOVE 209 TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(209, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_SAIDA*/

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-SECTION */
        private void R0580_00_LER_HIST_FIDELIZ_SECTION()
        {
            /*" -563- MOVE 'R0580-00-LER-HIST-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0580-00-LER-HIST-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -565- MOVE 'SELECT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -568- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -571- MOVE R1-SIT-PROPOSTA OF REG-STA-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -574- MOVE R1-SIT-MOTIVO OF REG-STA-PROPOSTA TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -577- MOVE PROPOVA-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -590- PERFORM R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1 */

            R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1();

            /*" -593- IF SQLCODE NOT EQUAL 00 AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -594- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -595- MOVE 2 TO W-HISTORICO */
                    _.Move(2, WAREA_AUXILIAR.W_HISTORICO);

                    /*" -596- ELSE */
                }
                else
                {


                    /*" -597- DISPLAY 'PF0717B - FIM ANORMAL' */
                    _.Display($"PF0717B - FIM ANORMAL");

                    /*" -598- DISPLAY '          ERRO ACESSO HIST-PROP-FIDELIZ' */
                    _.Display($"          ERRO ACESSO HIST-PROP-FIDELIZ");

                    /*" -600- DISPLAY '          NUMERO DA PROPOSTA.. ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO DA PROPOSTA.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -602- DISPLAY '          SQLCODE............. ' SQLCODE */
                    _.Display($"          SQLCODE............. {DB.SQLCODE}");

                    /*" -603- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -604- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -605- ELSE */
                }

            }
            else
            {


                /*" -605- MOVE 1 TO W-HISTORICO. */
                _.Move(1, WAREA_AUXILIAR.W_HISTORICO);
            }


        }

        [StopWatch]
        /*" R0580-00-LER-HIST-FIDELIZ-DB-SELECT-1 */
        public void R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1()
        {
            /*" -590- EXEC SQL SELECT NUM_IDENTIFICACAO INTO :PROPFIDH-NUM-IDENTIFICACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND DATA_SITUACAO = :PROPFIDH-DATA-SITUACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF WITH UR END-EXEC. */

            var r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1 = new R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1.Execute(r0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0800-00-STATUS-REGISTRO-TP1-SECTION */
        private void R0800_00_STATUS_REGISTRO_TP1_SECTION()
        {
            /*" -616- MOVE 'R0800-00-STATUS-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0800-00-STATUS-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -619- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -622- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -625- MOVE PROPOVA-DATA-MOVIMENTO TO W-DATA-SQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -626- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -627- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -629- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -632- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -634- ADD 1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + 1;

            /*" -637- MOVE RH-NSAS OF REG-HEADER-STA TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -640- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -640- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0950-00-STATUS-REGISTRO-TP4-SECTION */
        private void R0950_00_STATUS_REGISTRO_TP4_SECTION()
        {
            /*" -651- MOVE 'R0990-00-STATUS-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0990-00-STATUS-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -654- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -657- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -660- MOVE PROPOVA-DATA-MOVIMENTO TO W-DATA-SQL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -661- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_0.W_DIA_TRABALHO);

            /*" -662- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_0.W_MES_TRABALHO);

            /*" -664- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_0.W_ANO_TRABALHO);

            /*" -667- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -670- MOVE PROPOVA-NUM-PARCELA TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS);

            /*" -673- MOVE 999999 TO R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(999999, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -675- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -675- ADD 1 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -685- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -687- MOVE 'WRITE REG-TRAILLER - STATUS' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -689- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -692- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -695- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -706- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 OF REG-TRAILLER-STA + RT-QTDE-TIPO-2 OF REG-TRAILLER-STA + RT-QTDE-TIPO-3 OF REG-TRAILLER-STA + RT-QTDE-TIPO-4 OF REG-TRAILLER-STA + RT-QTDE-TIPO-5 OF REG-TRAILLER-STA + RT-QTDE-TIPO-6 OF REG-TRAILLER-STA + RT-QTDE-TIPO-7 OF REG-TRAILLER-STA + RT-QTDE-TIPO-8 OF REG-TRAILLER-STA + RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -706- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -716- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -718- MOVE 'INSERT ARQUIVOS-SIVPF - STATUS' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -721- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -724- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -728- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -731- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -734- MOVE RT-QTDE-TOTAL OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -742- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -745- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -746- DISPLAY 'PF0717B - FIM ANORMAL' */
                _.Display($"PF0717B - FIM ANORMAL");

                /*" -747- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -749- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -751- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -753- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -755- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -757- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -758- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -758- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -742- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -769- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -771- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -772- DISPLAY 'PF0717B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0717B - TOTAIS DO PROCESSAMENTO");

            /*" -773- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -775- DISPLAY '          TOTAL  DESPREZADO................ ' W-DESPREZADO */
            _.Display($"          TOTAL  DESPREZADO................ {WAREA_AUXILIAR.W_DESPREZADO}");

            /*" -776- DISPLAY '          TOTAL  GERADO ARQUIVO STATUS..... ' RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Display($"          TOTAL  GERADO ARQUIVO STATUS..... {LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -785- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -787- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -790- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -793- MOVE PROPOVA-DATA-MOVIMENTO TO PROPFIDH-DATA-SITUACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -796- MOVE RH-NSAS OF REG-HEADER-STA TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -799- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO PROPFIDH-NSL. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -802- MOVE R1-SIT-PROPOSTA OF REG-STA-PROPOSTA TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -805- MOVE R4-SIT-COBRANCA OF REG-PGTO-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -809- MOVE R1-SIT-MOTIVO OF REG-STA-PROPOSTA TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -812- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -815- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -826- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -829- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -830- DISPLAY 'PF0717B - FIM ANORMAL' */
                _.Display($"PF0717B - FIM ANORMAL");

                /*" -831- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -834- DISPLAY '          PROPOSTA / IDENTIFICACAO ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' PROPOFID-NUM-IDENTIFICACAO */

                $"          PROPOSTA / IDENTIFICACAO {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}"
                .Display();

                /*" -836- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -837- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -837- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -826- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_COD_EMPRESA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF.ToString(),
                PROPFIDH_COD_PRODUTO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF.ToString(),
            };

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3390_SAIDA*/

        [StopWatch]
        /*" R3400-00-ATUALIZA-PROPOSTA-SECTION */
        private void R3400_00_ATUALIZA_PROPOSTA_SECTION()
        {
            /*" -847- MOVE 'R3400-00-ATUALIZA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3400-00-ATUALIZA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -849- MOVE 'UPDATE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -850- MOVE 'PF0717B' TO PROPOFID-COD-USUARIO. */
            _.Move("PF0717B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -854- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO. */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -855- MOVE PROPFIDH-NSL TO PROPOFID-NSL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -856- MOVE PROPFIDH-NSAS-SIVPF TO PROPOFID-NSAS-SIVPF. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -858- MOVE PROPFIDH-SIT-PROPOSTA TO PROPOFID-SIT-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -867- PERFORM R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1 */

            R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1();

            /*" -870- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -871- DISPLAY 'PF0717B - FIM ANORMAL' */
                _.Display($"PF0717B - FIM ANORMAL");

                /*" -872- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -874- DISPLAY '          PROPOSTA................... ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          PROPOSTA................... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -876- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -877- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -877- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3400-00-ATUALIZA-PROPOSTA-DB-UPDATE-1 */
        public void R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -867- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET NSAS_SIVPF = :PROPOFID-NSAS-SIVPF, NSL = :PROPOFID-NSL, SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA, COD_USUARIO = :PROPOFID-COD-USUARIO, SITUACAO_ENVIO = :PROPOFID-SITUACAO-ENVIO WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1 = new R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1.Execute(r3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -886- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -897- DISPLAY ' ' */
            _.Display($" ");

            /*" -898- IF W-FIM-MOVTO-TERMO = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -899- DISPLAY 'PF0717B - FIM NORMAL' */
                _.Display($"PF0717B - FIM NORMAL");

                /*" -900- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -901- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -901- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -903- ELSE */
            }
            else
            {


                /*" -904- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_1.WSQLCODE);

                /*" -905- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_1.WSQLERRD1);

                /*" -906- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_1.WSQLERRD2);

                /*" -907- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -908- DISPLAY '*** PF0717B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0717B *** ROLLBACK EM ANDAMENTO ...");

                /*" -909- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -909- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -912- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -912- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}