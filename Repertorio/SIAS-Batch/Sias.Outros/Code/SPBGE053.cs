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
using Sias.Outros.DB2.SPBGE053;

namespace Code
{
    public class SPBGE053
    {
        public bool IsCall { get; set; }

        public SPBGE053()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      * SISTEMA.........: SIAS                                         *      */
        /*"      * MODULO..........: GE                                           *      */
        /*"      * PROGRAMA........: SPBGE053                                     *      */
        /*"      * ANALISTA........: ROGER PIRES DOS SANTOS                       *      */
        /*"      * DATA............: 22/03/2024                                   *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * OBJETIVO........: ACOES DE MANUTENCAO DA TABELA DE NOME SOCIAL *      */
        /*"      *                   ( SEGUROS.GE_NOME_SOCIAL )                   *      */
        /*"      *                                                                *      */
        /*"      * DESCRICAO DAS ACOES                                            *      */
        /*"      *   COD - ACAO                                                   *      */
        /*"      *    1  - INCLUI                                                 *      */
        /*"      *    2  - CONSULTA                                               *      */
        /*"      *    3  - LISTA                                                  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                         V E R S O E S                          *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"V.02  *   VERSAO 02 - INCIDENTE 602039                                 *      */
        /*"      *             - RETIRAR DISPLAY QUANDO LK-GE053-E-TRACE = N      *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/09/2024 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * V.01    22/03/2024  ROGER PIRES DOS SANTOS                     *      */
        /*"      *         DESCRICAO:  IMPLANTACAO                                *      */
        /*"      *                                          PROCURE POR           *      */
        /*"      ******************************************************************      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01    WORK.*/
        public SPBGE053_WORK WORK { get; set; } = new SPBGE053_WORK();
        public class SPBGE053_WORK : VarBasis
        {
            /*"  05  WS-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05  WS-DATAS.*/
            public SPBGE053_WS_DATAS WS_DATAS { get; set; } = new SPBGE053_WS_DATAS();
            public class SPBGE053_WS_DATAS : VarBasis
            {
                /*"   10 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
                public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"   10 WS-CURRENT-TIMESTAMP           PIC  X(026) VALUE SPACES.*/
                public StringBasis WS_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"  05  WS-EDIT.*/
            }
            public SPBGE053_WS_EDIT WS_EDIT { get; set; } = new SPBGE053_WS_EDIT();
            public class SPBGE053_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 20 TIMES*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "15", "99999999999999-"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"   10 WS-TAXA                        PIC 9,99999-                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
                /*"  05  WS-ERRO.*/
            }
            public SPBGE053_WS_ERRO WS_ERRO { get; set; } = new SPBGE053_WS_ERRO();
            public class SPBGE053_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   10 WS-ID-ERRO                     PIC  9(003) VALUE 0.*/
                public IntBasis WS_ID_ERRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-SQLCODE                     PIC  ZZZZ9-.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZ9-."));
                /*"   10 WS-SQLERRMC                    PIC  X(076) VALUE SPACES.*/
                public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "76", "X(076)"), @"");
                /*"   10 WS-SQLSTATE                    PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   05 WS-AUXILIARES.*/
                public SPBGE053_WS_AUXILIARES WS_AUXILIARES { get; set; } = new SPBGE053_WS_AUXILIARES();
                public class SPBGE053_WS_AUXILIARES : VarBasis
                {
                    /*"      10 WS-DTH-OPERACAO-INI         PIC  X(026) VALUE SPACES.*/
                    public StringBasis WS_DTH_OPERACAO_INI { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                    /*"      10 WS-DTH-OPERACAO-FIM         PIC  X(026) VALUE SPACES.*/
                    public StringBasis WS_DTH_OPERACAO_FIM { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                    /*"      10 WS-COCIENTE                 PIC S9(005) COMP-3 VALUE 0.*/
                    public IntBasis WS_COCIENTE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                    /*"      10 WS-RESTO                    PIC S9(003) COMP-3 VALUE 0.*/
                    public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                    /*"      10 WS-DESC-DATA-HORA-NOK       PIC  X(012) VALUE SPACES.*/
                    public StringBasis WS_DESC_DATA_HORA_NOK { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                    /*"      10 WS-DATA-HORA                 PIC  X(001) VALUE 'S'.*/

                    public SelectorBasis WS_DATA_HORA { get; set; } = new SelectorBasis("001", "S")
                    {
                        Items = new List<SelectorItemBasis> {
                            /*" 88 WS-DATA-HORA-OK                       VALUE 'S'. */
							new SelectorItemBasis("WS_DATA_HORA_OK", "S"),
							/*" 88 WS-DATA-HORA-NOK                      VALUE 'N'. */
							new SelectorItemBasis("WS_DATA_HORA_NOK", "N")
                }
                    };

                    /*"      10 WS-BISSEXTO                 PIC  X(001) VALUE 'N'.*/

                    public SelectorBasis WS_BISSEXTO { get; set; } = new SelectorBasis("001", "N")
                    {
                        Items = new List<SelectorItemBasis> {
                            /*" 88 WS-BISSEXTO-NAO                      VALUE 'N'. */
							new SelectorItemBasis("WS_BISSEXTO_NAO", "N"),
							/*" 88 WS-BISSEXTO-SIM                      VALUE 'S'. */
							new SelectorItemBasis("WS_BISSEXTO_SIM", "S")
                }
                    };

                    /*"      10 WS-TIMESTAMP                PIC  X(026) VALUE SPACES.*/
                    public StringBasis WS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                    /*"      10 WS-TIMESTAMP-CAMPOS REDEFINES WS-TIMESTAMP.*/
                    private _REDEF_SPBGE053_WS_TIMESTAMP_CAMPOS _ws_timestamp_campos { get; set; }
                    public _REDEF_SPBGE053_WS_TIMESTAMP_CAMPOS WS_TIMESTAMP_CAMPOS
                    {
                        get { _ws_timestamp_campos = new _REDEF_SPBGE053_WS_TIMESTAMP_CAMPOS(); _.Move(WS_TIMESTAMP, _ws_timestamp_campos); VarBasis.RedefinePassValue(WS_TIMESTAMP, _ws_timestamp_campos, WS_TIMESTAMP); _ws_timestamp_campos.ValueChanged += () => { _.Move(_ws_timestamp_campos, WS_TIMESTAMP); }; return _ws_timestamp_campos; }
                        set { VarBasis.RedefinePassValue(value, _ws_timestamp_campos, WS_TIMESTAMP); }
                    }  //Redefines
                    public class _REDEF_SPBGE053_WS_TIMESTAMP_CAMPOS : VarBasis
                    {
                        /*"         15 WS-TIMESTAMP-ANO         PIC  9(004).*/
                        public IntBasis WS_TIMESTAMP_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"         15 FILLER                   PIC  X(001).*/
                        public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"         15 WS-TIMESTAMP-MES         PIC  9(002).*/
                        public IntBasis WS_TIMESTAMP_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"         15 FILLER                   PIC  X(001).*/
                        public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"         15 WS-TIMESTAMP-DIA         PIC  9(002).*/
                        public IntBasis WS_TIMESTAMP_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"         15 FILLER                   PIC  X(001).*/
                        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"         15 WS-TIMESTAMP-HOR         PIC  9(002).*/
                        public IntBasis WS_TIMESTAMP_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"         15 FILLER                   PIC  X(001).*/
                        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"         15 WS-TIMESTAMP-MIN         PIC  9(002).*/
                        public IntBasis WS_TIMESTAMP_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"         15 FILLER                   PIC  X(001).*/
                        public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"         15 WS-TIMESTAMP-SEG         PIC  9(002).*/
                        public IntBasis WS_TIMESTAMP_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"         15 FILLER                   PIC  X(001).*/
                        public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"         15 WS-TIMESTAMP-MIC         PIC  9(006).*/
                        public IntBasis WS_TIMESTAMP_MIC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                        /*"   05 CNT-CONTADORES.*/

                        public _REDEF_SPBGE053_WS_TIMESTAMP_CAMPOS()
                        {
                            WS_TIMESTAMP_ANO.ValueChanged += OnValueChanged;
                            FILLER_0.ValueChanged += OnValueChanged;
                            WS_TIMESTAMP_MES.ValueChanged += OnValueChanged;
                            FILLER_1.ValueChanged += OnValueChanged;
                            WS_TIMESTAMP_DIA.ValueChanged += OnValueChanged;
                            FILLER_2.ValueChanged += OnValueChanged;
                            WS_TIMESTAMP_HOR.ValueChanged += OnValueChanged;
                            FILLER_3.ValueChanged += OnValueChanged;
                            WS_TIMESTAMP_MIN.ValueChanged += OnValueChanged;
                            FILLER_4.ValueChanged += OnValueChanged;
                            WS_TIMESTAMP_SEG.ValueChanged += OnValueChanged;
                            FILLER_5.ValueChanged += OnValueChanged;
                            WS_TIMESTAMP_MIC.ValueChanged += OnValueChanged;
                        }

                    }
                }
                public SPBGE053_CNT_CONTADORES CNT_CONTADORES { get; set; } = new SPBGE053_CNT_CONTADORES();
                public class SPBGE053_CNT_CONTADORES : VarBasis
                {
                    /*"      10 CNT-REG-NOME-SOCIAL         PIC  9(003) VALUE ZERO.*/
                    public IntBasis CNT_REG_NOME_SOCIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                }
            }
        }


        public Copies.RSGEWSTR RSGEWSTR { get; set; } = new Copies.RSGEWSTR();
        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GE149 GE149 { get; set; } = new Dclgens.GE149();

        public SPBGE053_CSR_NOM_SOCIAL CSR_NOM_SOCIAL { get; set; } = new SPBGE053_CSR_NOM_SOCIAL(true);
        string GetQuery_CSR_NOM_SOCIAL()
        {
            var query = @$"SELECT NUM_CPF
							, DTH_OPERACAO
							, CASE IND_USA_NOME_SOCIAL WHEN 'S' THEN NOM_SOCIAL ELSE '' END
							, IND_TIPO_ACAO
							, IND_USA_NOME_SOCIAL
							, IFNULL( COD_TP_PES_NEGOCIO
							, 0 )
							, IFNULL( NUM_PROPOSTA
							, 0 )
							, COD_CANAL_ORIGEM
							, NUM_MATRICULA
							, NOM_PROGRAMA
							, DTH_CADASTRAMENTO
							FROM SEGUROS.GE_NOME_SOCIAL WHERE NUM_CPF = '{GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF}' ORDER BY DTH_CADASTRAMENTO DESC";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SPGE053W SPGE053W_P) //PROCEDURE DIVISION USING 
        /*LK_GE053_E_TRACE
        LK_GE053_E_IDE_SISTEMA
        LK_GE053_E_IND_OPERACAO
        LK_GE053_I_NUM_CPF
        LK_GE053_I_DTH_OPERACAO
        LK_GE053_I_NOM_SOCIAL
        LK_GE053_I_IND_TIPO_ACAO
        LK_GE053_I_IND_USA_NOME_SOCIAL
        LK_GE053_I_COD_TP_PES_NEGOCIO
        LK_GE053_I_NUM_PROPOSTA
        LK_GE053_I_COD_CANAL_ORIGEM
        LK_GE053_I_NUM_MATRICULA
        LK_GE053_I_NOM_PROGRAMA
        LK_GE053_I_DTH_CADASTRAMENTO
        LK_GE053_IND_ERRO
        LK_GE053_ID_ERRO
        LK_GE053_MENSAGEM
        LK_GE053_NOM_TABELA
        LK_GE053_SQLCODE
        LK_GE053_SQLERRMC
        LK_GE053_SQLSTATE
        */
        {
            try
            {
                this.SPGE053W = SPGE053W_P;
                InitializeGetQuery();

                /*" -209- PERFORM P1000-INICIALIZA. */

                P1000_INICIALIZA_SECTION();

                /*" -210- PERFORM P2000-PROCESSA. */

                P2000_PROCESSA_SECTION();

                /*" -212- PERFORM P3000-FINALIZA. */

                P3000_FINALIZA_SECTION();

                /*" -212- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            CSR_NOM_SOCIAL.GetQueryEvent += GetQuery_CSR_NOM_SOCIAL;
        }

        [StopWatch]
        /*" P1000-INICIALIZA-SECTION */
        private void P1000_INICIALIZA_SECTION()
        {
            /*" -219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -220- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -221- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -225- MOVE FUNCTION CURRENT-DATE(1:14) TO WS-C-DATE-CURRENT. */
            _.Move(_.CurrentDate(0, 14), WORK.WS_DATAS.WS_C_DATE_CURRENT);

            /*" -228- MOVE FUNCTION WHEN-COMPILED TO WS-C-DATE-COMPILED. */
            _.Move(_.WhenCompiled(), WORK.WS_DATAS.WS_C_DATE_COMPILED);

            /*" -234- MOVE ZERO TO WS-IND-ERRO WS-ID-ERRO WS-SQLCODE LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-SQLCODE. */
            _.Move(0, WORK.WS_ERRO.WS_IND_ERRO, WORK.WS_ERRO.WS_ID_ERRO, WORK.WS_ERRO.WS_SQLCODE, SPGE053W.LK_GE053_IND_ERRO, SPGE053W.LK_GE053_ID_ERRO, SPGE053W.LK_GE053_SQLCODE);

            /*" -245- MOVE SPACES TO WS-MENSAGEM WS-TABELA WS-SQLERRMC WS-SQLSTATE LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLERRMC LK-GE053-SQLSTATE. */
            _.Move("", WORK.WS_ERRO.WS_MENSAGEM, WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE, SPGE053W.LK_GE053_MENSAGEM, SPGE053W.LK_GE053_NOM_TABELA, SPGE053W.LK_GE053_SQLERRMC, SPGE053W.LK_GE053_SQLSTATE);

            /*" -248- PERFORM P1010-VERIFICAR-SISTEMA. */

            P1010_VERIFICAR_SISTEMA_SECTION();

            /*" -249- IF NOT ( LK-GE053-E-TRACE = 'S' OR = 'N' ) */

            if (!(SPGE053W.LK_GE053_E_TRACE.In("S", "N")))
            {

                /*" -250- MOVE 'N' TO LK-GE053-E-TRACE */
                _.Move("N", SPGE053W.LK_GE053_E_TRACE);

                /*" -252- END-IF */
            }


            /*" -253- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -254- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -255- DISPLAY '*            S P B G E 0 5 3                 *' */
                _.Display($"*            S P B G E 0 5 3                 *");

                /*" -256- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -263- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

                $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
                .Display();

                /*" -270- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

                $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
                .Display();

                /*" -274- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

                $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
                .Display();

                /*" -275- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -276- DISPLAY '*             DADOS DE ENTRADA               *' */
                _.Display($"*             DADOS DE ENTRADA               *");

                /*" -277- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -279- DISPLAY '* <TRACE.............. ' LK-GE053-E-TRACE '>' */

                $"* <TRACE.............. {SPGE053W.LK_GE053_E_TRACE}>"
                .Display();

                /*" -281- DISPLAY '* <IDE-SISTEMA........ ' LK-GE053-E-IDE-SISTEMA '>' */

                $"* <IDE-SISTEMA........ {SPGE053W.LK_GE053_E_IDE_SISTEMA}>"
                .Display();

                /*" -283- DISPLAY '* <IND-OPERACAO....... ' LK-GE053-E-IND-OPERACAO '>' */

                $"* <IND-OPERACAO....... {SPGE053W.LK_GE053_E_IND_OPERACAO}>"
                .Display();

                /*" -285- DISPLAY '* <NUM-CPF............ ' LK-GE053-I-NUM-CPF '>' */

                $"* <NUM-CPF............ {SPGE053W.LK_GE053_I_NUM_CPF}>"
                .Display();

                /*" -287- DISPLAY '* <DTH-OPERACAO....... ' LK-GE053-I-DTH-OPERACAO '>' */

                $"* <DTH-OPERACAO....... {SPGE053W.LK_GE053_I_DTH_OPERACAO}>"
                .Display();

                /*" -289- DISPLAY '* <NOM-SOCIAL......... ' LK-GE053-I-NOM-SOCIAL '>' */

                $"* <NOM-SOCIAL......... {SPGE053W.LK_GE053_I_NOM_SOCIAL}>"
                .Display();

                /*" -291- DISPLAY '* <IND-TIPO-ACAO...... ' LK-GE053-I-IND-TIPO-ACAO '>' */

                $"* <IND-TIPO-ACAO...... {SPGE053W.LK_GE053_I_IND_TIPO_ACAO}>"
                .Display();

                /*" -293- DISPLAY '* <IND-USA-NOME-SOCIAL ' LK-GE053-I-IND-USA-NOME-SOCIAL '>' */

                $"* <IND-USA-NOME-SOCIAL {SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL}>"
                .Display();

                /*" -295- DISPLAY '* <COD-TP-PES-NEGOCIO. ' LK-GE053-I-COD-TP-PES-NEGOCIO '>' */

                $"* <COD-TP-PES-NEGOCIO. {SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO}>"
                .Display();

                /*" -297- DISPLAY '* <NUM-PROPOSTA....... ' LK-GE053-I-NUM-PROPOSTA '>' */

                $"* <NUM-PROPOSTA....... {SPGE053W.LK_GE053_I_NUM_PROPOSTA}>"
                .Display();

                /*" -299- DISPLAY '* <COD-CANAL-ORIGEM... ' LK-GE053-I-COD-CANAL-ORIGEM '>' */

                $"* <COD-CANAL-ORIGEM... {SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM}>"
                .Display();

                /*" -301- DISPLAY '* <NUM-MATRICULA...... ' LK-GE053-I-NUM-MATRICULA '>' */

                $"* <NUM-MATRICULA...... {SPGE053W.LK_GE053_I_NUM_MATRICULA}>"
                .Display();

                /*" -301- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_99_EXIT*/

        [StopWatch]
        /*" P1010-VERIFICAR-SISTEMA-SECTION */
        private void P1010_VERIFICAR_SISTEMA_SECTION()
        {
            /*" -318- PERFORM P1010_VERIFICAR_SISTEMA_DB_SELECT_1 */

            P1010_VERIFICAR_SISTEMA_DB_SELECT_1();

            /*" -321- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -322- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -323- MOVE 1 TO WS-ID-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -327- STRING WS-SECTION ' - ERRO NO SELECT NA SEGUROS.SISTEMA.' '<SISTEMA=GE>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl1 += " - ERRO NO SELECT NA SEGUROS.SISTEMA.";
                spl1 += "<SISTEMA=GE>";
                _.Move(spl1, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -328- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -329- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -330- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -331- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -332- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -334- END-IF */
            }


            /*" -335- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -336- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -337- MOVE 2 TO WS-ID-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -341- STRING WS-SECTION ' - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.' '<SISTEMA=GE>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl2 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl2 += " - REGISTRO DE CONTROLE SISTEMA NAO CADASTRADO.";
                spl2 += "<SISTEMA=GE>";
                _.Move(spl2, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -342- MOVE 'SEGUROS.SISTEMAS' TO WS-TABELA */
                _.Move("SEGUROS.SISTEMAS", WORK.WS_ERRO.WS_TABELA);

                /*" -343- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -344- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -345- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -346- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -346- END-IF. */
            }


        }

        [StopWatch]
        /*" P1010-VERIFICAR-SISTEMA-DB-SELECT-1 */
        public void P1010_VERIFICAR_SISTEMA_DB_SELECT_1()
        {
            /*" -318- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'GE' WITH UR END-EXEC. */

            var p1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1 = new P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1.Execute(p1010_VERIFICAR_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1010_99_EXIT*/

        [StopWatch]
        /*" P2000-PROCESSA-SECTION */
        private void P2000_PROCESSA_SECTION()
        {
            /*" -356- MOVE 'P2000' TO WS-SECTION */
            _.Move("P2000", WORK.WS_ERRO.WS_SECTION);

            /*" -357- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -358- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -360- END-IF. */
            }


            /*" -361- EVALUATE LK-GE053-E-IND-OPERACAO */
            switch (SPGE053W.LK_GE053_E_IND_OPERACAO.Value)
            {

                /*" -362- WHEN 1 */
                case 1:

                    /*" -363- PERFORM P2010-VALIDA-INSERCAO */

                    P2010_VALIDA_INSERCAO_SECTION();

                    /*" -364- PERFORM P2020-INSERE-GE149 */

                    P2020_INSERE_GE149_SECTION();

                    /*" -365- WHEN 2 */
                    break;
                case 2:

                    /*" -366- PERFORM P2900-VALIDA-CHAVE */

                    P2900_VALIDA_CHAVE_SECTION();

                    /*" -367- PERFORM P2030-CONSULTA-GE149 */

                    P2030_CONSULTA_GE149_SECTION();

                    /*" -368- PERFORM P2031-MOVE-CONSULTA */

                    P2031_MOVE_CONSULTA_SECTION();

                    /*" -369- WHEN 3 */
                    break;
                case 3:

                    /*" -370- PERFORM P2060-LISTA-NOME-SOCIAL */

                    P2060_LISTA_NOME_SOCIAL_SECTION();

                    /*" -371- WHEN OTHER */
                    break;
                default:

                    /*" -372- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -373- MOVE 3 TO WS-ID-ERRO */
                    _.Move(3, WORK.WS_ERRO.WS_ID_ERRO);

                    /*" -374- MOVE LK-GE053-E-IND-OPERACAO TO WS-SMALLINT(01) */
                    _.Move(SPGE053W.LK_GE053_E_IND_OPERACAO, WORK.WS_EDIT.WS_SMALLINT[01]);

                    /*" -378- STRING WS-SECTION ' - TIPO DE ACAO INFORMADA INVALIDA.' '<TIPO_ACAO=' WS-SMALLINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl3 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl3 += " - TIPO DE ACAO INFORMADA INVALIDA.";
                    spl3 += "<TIPO_ACAO=";
                    var spl4 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                    spl4 += ">";
                    var results5 = spl3 + spl4;
                    _.Move(results5, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -381- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -382- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -383- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -383- END-EVALUATE. */
                    break;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_99_EXIT*/

        [StopWatch]
        /*" P2010-VALIDA-INSERCAO-SECTION */
        private void P2010_VALIDA_INSERCAO_SECTION()
        {
            /*" -395- MOVE 'P1020' TO WS-SECTION */
            _.Move("P1020", WORK.WS_ERRO.WS_SECTION);

            /*" -396- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -397- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -416- END-IF. */
            }


            /*" -417- IF LK-GE053-I-NUM-CPF LESS 1 */

            if (SPGE053W.LK_GE053_I_NUM_CPF < 1)
            {

                /*" -418- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -419- MOVE 5 TO WS-ID-ERRO */
                _.Move(5, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -420- MOVE LK-GE053-I-NUM-CPF TO WS-BIGINT(01) */
                _.Move(SPGE053W.LK_GE053_I_NUM_CPF, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -423- STRING WS-SECTION ' - CPF NAO INFORMADO.' '<CPF=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl5 += " - CPF NAO INFORMADO.";
                spl5 += "<CPF=";
                var spl6 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl6 += ">";
                var results7 = spl5 + spl6;
                _.Move(results7, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -426- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -427- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -428- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -430- END-IF. */
            }


            /*" -433- IF LK-GE053-I-DTH-OPERACAO EQUAL SPACES OR LK-GE053-I-DTH-OPERACAO EQUAL LOW-VALUES OR LK-GE053-I-DTH-OPERACAO EQUAL HIGH-VALUES */

            if (SPGE053W.LK_GE053_I_DTH_OPERACAO.IsEmpty() || SPGE053W.LK_GE053_I_DTH_OPERACAO.IsLowValues() || SPGE053W.LK_GE053_I_DTH_OPERACAO.IsHighValues)
            {

                /*" -434- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -435- MOVE 6 TO WS-ID-ERRO */
                _.Move(6, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -438- STRING WS-SECTION ' - DATA E HORA DE OPERACAO NAO INF.' '<DATA-HORA=' LK-GE053-I-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl7 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl7 += " - DATA E HORA DE OPERACAO NAO INF.";
                spl7 += "<DATA-HORA=";
                var spl8 = SPGE053W.LK_GE053_I_DTH_OPERACAO.GetMoveValues();
                spl8 += ">";
                var results9 = spl7 + spl8;
                _.Move(results9, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -441- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -442- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -443- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -445- END-IF. */
            }


            /*" -447- PERFORM P2011-VALIDA-TIMESTAMP. */

            P2011_VALIDA_TIMESTAMP_SECTION();

            /*" -452- IF LK-GE053-I-IND-TIPO-ACAO EQUAL ' ' OR LK-GE053-I-IND-TIPO-ACAO EQUAL 'I' OR LK-GE053-I-IND-TIPO-ACAO EQUAL 'A' OR LK-GE053-I-IND-TIPO-ACAO EQUAL 'E' */

            if (SPGE053W.LK_GE053_I_IND_TIPO_ACAO == " " || SPGE053W.LK_GE053_I_IND_TIPO_ACAO == "I" || SPGE053W.LK_GE053_I_IND_TIPO_ACAO == "A" || SPGE053W.LK_GE053_I_IND_TIPO_ACAO == "E")
            {

                /*" -454- CONTINUE */

                /*" -455- ELSE */
            }
            else
            {


                /*" -456- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -457- MOVE 7 TO WS-ID-ERRO */
                _.Move(7, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -460- STRING WS-SECTION ' - TIPO DA ACAO INVALIDA.' '<TIPO-ACAO=' LK-GE053-I-IND-TIPO-ACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl9 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl9 += " - TIPO DA ACAO INVALIDA.";
                spl9 += "<TIPO-ACAO=";
                var spl10 = SPGE053W.LK_GE053_I_IND_TIPO_ACAO.GetMoveValues();
                spl10 += ">";
                var results11 = spl9 + spl10;
                _.Move(results11, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -463- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -464- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -465- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -467- END-IF. */
            }


            /*" -470- IF LK-GE053-I-IND-USA-NOME-SOCIAL EQUAL 'S' OR LK-GE053-I-IND-USA-NOME-SOCIAL EQUAL 'N' */

            if (SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL == "S" || SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL == "N")
            {

                /*" -472- CONTINUE */

                /*" -473- ELSE */
            }
            else
            {


                /*" -474- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -475- MOVE 8 TO WS-ID-ERRO */
                _.Move(8, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -479- STRING WS-SECTION ' - USO DE NOME SOCIAL INVALIDO.' '<IND-USA-NOME-SOCIAL=' LK-GE053-I-IND-USA-NOME-SOCIAL '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl11 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl11 += " - USO DE NOME SOCIAL INVALIDO.";
                spl11 += "<IND-USA-NOME-SOCIAL=";
                var spl12 = SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL.GetMoveValues();
                spl12 += ">";
                var results13 = spl11 + spl12;
                _.Move(results13, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -482- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -483- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -484- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -486- END-IF. */
            }


            /*" -489- IF LK-GE053-I-NUM-PROPOSTA GREATER 0 OR LK-GE053-I-NUM-PROPOSTA EQUAL 0 */

            if (SPGE053W.LK_GE053_I_NUM_PROPOSTA > 0 || SPGE053W.LK_GE053_I_NUM_PROPOSTA == 0)
            {

                /*" -491- CONTINUE */

                /*" -493- ELSE */
            }
            else
            {


                /*" -494- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -495- MOVE 9 TO WS-ID-ERRO */
                _.Move(9, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -496- MOVE LK-GE053-I-NUM-PROPOSTA TO WS-BIGINT(01) */
                _.Move(SPGE053W.LK_GE053_I_NUM_PROPOSTA, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -499- STRING WS-SECTION ' - NUMERO DA PROPOSTA NAO INFORMADO.' '<NUM-PROPOSTA= ' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl13 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl13 += " - NUMERO DA PROPOSTA NAO INFORMADO.";
                spl13 += "<NUM-PROPOSTA= ";
                var spl14 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl14 += ">";
                var results15 = spl13 + spl14;
                _.Move(results15, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -502- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -503- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -504- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -506- END-IF. */
            }


            /*" -508- IF LK-GE053-I-COD-CANAL-ORIGEM EQUAL LOW-VALUES OR LK-GE053-I-COD-CANAL-ORIGEM EQUAL HIGH-VALUES */

            if (SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM.IsLowValues() || SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM.IsHighValues)
            {

                /*" -510- MOVE SPACES TO LK-GE053-I-COD-CANAL-ORIGEM */
                _.Move("", SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM);

                /*" -512- END-IF. */
            }


            /*" -514- IF LK-GE053-I-NUM-MATRICULA EQUAL LOW-VALUES OR LK-GE053-I-NUM-MATRICULA EQUAL HIGH-VALUES */

            if (SPGE053W.LK_GE053_I_NUM_MATRICULA.IsLowValues() || SPGE053W.LK_GE053_I_NUM_MATRICULA.IsHighValues)
            {

                /*" -515- MOVE SPACES TO LK-GE053-I-NUM-MATRICULA */
                _.Move("", SPGE053W.LK_GE053_I_NUM_MATRICULA);

                /*" -515- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2010_99_EXIT*/

        [StopWatch]
        /*" P2011-VALIDA-TIMESTAMP-SECTION */
        private void P2011_VALIDA_TIMESTAMP_SECTION()
        {
            /*" -527- MOVE 'P2011' TO WS-SECTION. */
            _.Move("P2011", WORK.WS_ERRO.WS_SECTION);

            /*" -528- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -529- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -531- END-IF. */
            }


            /*" -534- MOVE LK-GE053-I-DTH-OPERACAO TO WS-TIMESTAMP. */
            _.Move(SPGE053W.LK_GE053_I_DTH_OPERACAO, WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP);

            /*" -541- IF WS-TIMESTAMP-ANO NOT NUMERIC OR WS-TIMESTAMP-MES NOT NUMERIC OR WS-TIMESTAMP-DIA NOT NUMERIC OR WS-TIMESTAMP-HOR NOT NUMERIC OR WS-TIMESTAMP-MIN NOT NUMERIC OR WS-TIMESTAMP-SEG NOT NUMERIC OR WS-TIMESTAMP-MIC NOT NUMERIC */

            if (!WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_ANO.IsNumeric() || !WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES.IsNumeric() || !WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_DIA.IsNumeric() || !WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_HOR.IsNumeric() || !WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MIN.IsNumeric() || !WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_SEG.IsNumeric() || !WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MIC.IsNumeric())
            {

                /*" -542- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -543- MOVE 10 TO WS-ID-ERRO */
                _.Move(10, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -546- STRING WS-SECTION ' - DATA E HORA DE OPERACAO INVALIDA.' '<DATA-HORA=' LK-GE053-I-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl15 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl15 += " - DATA E HORA DE OPERACAO INVALIDA.";
                spl15 += "<DATA-HORA=";
                var spl16 = SPGE053W.LK_GE053_I_DTH_OPERACAO.GetMoveValues();
                spl16 += ">";
                var results17 = spl15 + spl16;
                _.Move(results17, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -549- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -550- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -551- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -554- END-IF. */
            }


            /*" -556- SET WS-DATA-HORA-OK TO TRUE. */
            WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_OK"] = true;

            /*" -557- IF WS-TIMESTAMP-ANO LESS 0 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_ANO < 0)
            {

                /*" -558- MOVE 'ANO' TO WS-DESC-DATA-HORA-NOK */
                _.Move("ANO", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -559- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -561- END-IF. */
            }


            /*" -562- IF WS-TIMESTAMP-MES LESS 1 OR WS-TIMESTAMP-MES GREATER 12 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES < 1 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES > 12)
            {

                /*" -563- MOVE 'MES' TO WS-DESC-DATA-HORA-NOK */
                _.Move("MES", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -564- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -566- END-IF. */
            }


            /*" -567- IF WS-TIMESTAMP-DIA LESS 1 OR WS-TIMESTAMP-DIA GREATER 31 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_DIA < 1 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_DIA > 31)
            {

                /*" -568- MOVE 'DIA' TO WS-DESC-DATA-HORA-NOK */
                _.Move("DIA", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -569- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -571- END-IF. */
            }


            /*" -572- IF WS-TIMESTAMP-HOR LESS 0 OR WS-TIMESTAMP-HOR GREATER 23 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_HOR < 0 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_HOR > 23)
            {

                /*" -573- MOVE 'HORA' TO WS-DESC-DATA-HORA-NOK */
                _.Move("HORA", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -574- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -576- END-IF. */
            }


            /*" -577- IF WS-TIMESTAMP-MIN LESS 0 OR WS-TIMESTAMP-MIN GREATER 59 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MIN < 0 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MIN > 59)
            {

                /*" -578- MOVE 'MINUTO' TO WS-DESC-DATA-HORA-NOK */
                _.Move("MINUTO", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -579- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -581- END-IF. */
            }


            /*" -582- IF WS-TIMESTAMP-SEG LESS 0 OR WS-TIMESTAMP-SEG GREATER 59 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_SEG < 0 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_SEG > 59)
            {

                /*" -583- MOVE 'SEGUNDO' TO WS-DESC-DATA-HORA-NOK */
                _.Move("SEGUNDO", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -584- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -586- END-IF. */
            }


            /*" -587- IF WS-TIMESTAMP-MIC LESS 0 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MIC < 0)
            {

                /*" -588- MOVE 'MICROSEGUNDO' TO WS-DESC-DATA-HORA-NOK */
                _.Move("MICROSEGUNDO", WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK);

                /*" -589- SET WS-DATA-HORA-NOK TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"] = true;

                /*" -591- END-IF. */
            }


            /*" -592- IF WS-DATA-HORA-NOK */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_DATA_HORA["WS_DATA_HORA_NOK"])
            {

                /*" -593- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -594- MOVE 11 TO WS-ID-ERRO */
                _.Move(11, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -598- STRING WS-SECTION ' - VALOR INVALIDO - ' WS-DESC-DATA-HORA-NOK '<DATA-HORA=' LK-GE053-I-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl17 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl17 += " - VALOR INVALIDO - ";
                var spl18 = WORK.WS_ERRO.WS_AUXILIARES.WS_DESC_DATA_HORA_NOK.GetMoveValues();
                spl18 += "<DATA-HORA=";
                var spl19 = SPGE053W.LK_GE053_I_DTH_OPERACAO.GetMoveValues();
                spl19 += ">";
                var results20 = spl17 + spl18 + spl19;
                _.Move(results20, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -601- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -602- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -603- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -606- END-IF. */
            }


            /*" -611- IF ( WS-TIMESTAMP-DIA EQUAL 31 AND ( WS-TIMESTAMP-MES EQUAL 04 OR WS-TIMESTAMP-MES EQUAL 06 OR WS-TIMESTAMP-MES EQUAL 09 OR WS-TIMESTAMP-MES EQUAL 11 ) ) */

            if ((WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_DIA == 31 && (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES == 04 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES == 06 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES == 09 || WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES == 11)))
            {

                /*" -612- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -613- MOVE 12 TO WS-ID-ERRO */
                _.Move(12, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -616- STRING WS-SECTION ' - DIA INVALIDO.' '<DATA-HORA=' LK-GE053-I-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl20 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl20 += " - DIA INVALIDO.";
                spl20 += "<DATA-HORA=";
                var spl21 = SPGE053W.LK_GE053_I_DTH_OPERACAO.GetMoveValues();
                spl21 += ">";
                var results22 = spl20 + spl21;
                _.Move(results22, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -619- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -620- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -621- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -624- END-IF. */
            }


            /*" -627- IF WS-TIMESTAMP-MES EQUAL 02 AND WS-TIMESTAMP-DIA GREATER 28 */

            if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_MES == 02 && WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_DIA > 28)
            {

                /*" -628- IF WS-TIMESTAMP-DIA GREATER 29 */

                if (WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_DIA > 29)
                {

                    /*" -629- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -630- MOVE 13 TO WS-ID-ERRO */
                    _.Move(13, WORK.WS_ERRO.WS_ID_ERRO);

                    /*" -633- STRING WS-SECTION ' - DIA INVALIDO.' '<DATA-HORA=' LK-GE053-I-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl22 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl22 += " - DIA INVALIDO.";
                    spl22 += "<DATA-HORA=";
                    var spl23 = SPGE053W.LK_GE053_I_DTH_OPERACAO.GetMoveValues();
                    spl23 += ">";
                    var results24 = spl22 + spl23;
                    _.Move(results24, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -636- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -637- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -638- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -640- END-IF */
                }


                /*" -642- SET WS-BISSEXTO-NAO TO TRUE */
                WORK.WS_ERRO.WS_AUXILIARES.WS_BISSEXTO["WS_BISSEXTO_NAO"] = true;

                /*" -645- DIVIDE WS-TIMESTAMP-ANO BY 4 GIVING WS-COCIENTE REMAINDER WS-RESTO */
                _.Divide(WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_ANO, 4, WORK.WS_ERRO.WS_AUXILIARES.WS_COCIENTE, WORK.WS_ERRO.WS_AUXILIARES.WS_RESTO);

                /*" -646- IF WS-RESTO EQUAL ZERO */

                if (WORK.WS_ERRO.WS_AUXILIARES.WS_RESTO == 00)
                {

                    /*" -649- DIVIDE WS-TIMESTAMP-ANO BY 100 GIVING WS-COCIENTE REMAINDER WS-RESTO */
                    _.Divide(WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_ANO, 100, WORK.WS_ERRO.WS_AUXILIARES.WS_COCIENTE, WORK.WS_ERRO.WS_AUXILIARES.WS_RESTO);

                    /*" -650- IF WS-RESTO EQUAL ZERO */

                    if (WORK.WS_ERRO.WS_AUXILIARES.WS_RESTO == 00)
                    {

                        /*" -653- DIVIDE WS-TIMESTAMP-ANO BY 400 GIVING WS-COCIENTE REMAINDER WS-RESTO */
                        _.Divide(WORK.WS_ERRO.WS_AUXILIARES.WS_TIMESTAMP_CAMPOS.WS_TIMESTAMP_ANO, 400, WORK.WS_ERRO.WS_AUXILIARES.WS_COCIENTE, WORK.WS_ERRO.WS_AUXILIARES.WS_RESTO);

                        /*" -654- IF WS-RESTO EQUAL ZERO */

                        if (WORK.WS_ERRO.WS_AUXILIARES.WS_RESTO == 00)
                        {

                            /*" -655- SET WS-BISSEXTO-SIM TO TRUE */
                            WORK.WS_ERRO.WS_AUXILIARES.WS_BISSEXTO["WS_BISSEXTO_SIM"] = true;

                            /*" -657- END-IF */
                        }


                        /*" -659- ELSE */
                    }
                    else
                    {


                        /*" -661- SET WS-BISSEXTO-SIM TO TRUE */
                        WORK.WS_ERRO.WS_AUXILIARES.WS_BISSEXTO["WS_BISSEXTO_SIM"] = true;

                        /*" -662- END-IF */
                    }


                    /*" -664- END-IF */
                }


                /*" -665- IF WS-BISSEXTO-NAO */

                if (WORK.WS_ERRO.WS_AUXILIARES.WS_BISSEXTO["WS_BISSEXTO_NAO"])
                {

                    /*" -666- MOVE 1 TO WS-IND-ERRO */
                    _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                    /*" -667- MOVE 14 TO WS-ID-ERRO */
                    _.Move(14, WORK.WS_ERRO.WS_ID_ERRO);

                    /*" -670- STRING WS-SECTION ' - ANO NAO BISSEXTO.' '<DATA-HORA=' LK-GE053-I-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl24 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl24 += " - ANO NAO BISSEXTO.";
                    spl24 += "<DATA-HORA=";
                    var spl25 = SPGE053W.LK_GE053_I_DTH_OPERACAO.GetMoveValues();
                    spl25 += ">";
                    var results26 = spl24 + spl25;
                    _.Move(results26, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -673- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                    _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                    /*" -674- MOVE 0 TO WS-SQLCODE */
                    _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                    /*" -675- GO TO P9999-ERRO */

                    P9999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -676- END-IF */
                }


                /*" -676- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2011_99_EXIT*/

        [StopWatch]
        /*" P2020-INSERE-GE149-SECTION */
        private void P2020_INSERE_GE149_SECTION()
        {
            /*" -688- MOVE 'P2020' TO WS-SECTION. */
            _.Move("P2020", WORK.WS_ERRO.WS_SECTION);

            /*" -689- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -690- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -692- END-IF. */
            }


            /*" -695- INITIALIZE DCLGE-NOME-SOCIAL REPLACING NUMERIC BY ZERO ALPHANUMERIC BY SPACE. */
            _.Initialize(
                GE149.DCLGE_NOME_SOCIAL
            );

            /*" -696- MOVE LK-GE053-I-NUM-CPF TO GE149-NUM-CPF. */
            _.Move(SPGE053W.LK_GE053_I_NUM_CPF, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF);

            /*" -698- MOVE LK-GE053-I-DTH-OPERACAO TO GE149-DTH-OPERACAO. */
            _.Move(SPGE053W.LK_GE053_I_DTH_OPERACAO, GE149.DCLGE_NOME_SOCIAL.GE149_DTH_OPERACAO);

            /*" -699- MOVE LK-GE053-I-IND-TIPO-ACAO TO GE149-IND-TIPO-ACAO. */
            _.Move(SPGE053W.LK_GE053_I_IND_TIPO_ACAO, GE149.DCLGE_NOME_SOCIAL.GE149_IND_TIPO_ACAO);

            /*" -701- MOVE LK-GE053-I-COD-TP-PES-NEGOCIO TO GE149-COD-TP-PES-NEGOCIO. */
            _.Move(SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO, GE149.DCLGE_NOME_SOCIAL.GE149_COD_TP_PES_NEGOCIO);

            /*" -702- MOVE LK-GE053-I-NUM-PROPOSTA TO GE149-NUM-PROPOSTA. */
            _.Move(SPGE053W.LK_GE053_I_NUM_PROPOSTA, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_PROPOSTA);

            /*" -704- MOVE LK-GE053-I-COD-CANAL-ORIGEM TO GE149-COD-CANAL-ORIGEM. */
            _.Move(SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM, GE149.DCLGE_NOME_SOCIAL.GE149_COD_CANAL_ORIGEM);

            /*" -705- MOVE LK-GE053-I-NUM-MATRICULA TO GE149-NUM-MATRICULA. */
            _.Move(SPGE053W.LK_GE053_I_NUM_MATRICULA, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_MATRICULA);

            /*" -708- MOVE 'SPBGE053' TO GE149-NOM-PROGRAMA. */
            _.Move("SPBGE053", GE149.DCLGE_NOME_SOCIAL.GE149_NOM_PROGRAMA);

            /*" -709- MOVE LK-GE053-I-NOM-SOCIAL TO GE149-NOM-SOCIAL-TEXT. */
            _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_TEXT);

            /*" -712- INSPECT FUNCTION REVERSE ( LK-GE053-I-NOM-SOCIAL ) TALLYING GE149-NOM-SOCIAL-LEN FOR LEADING SPACES. */
            GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_LEN.Value = SPGE053W.LK_GE053_I_NOM_SOCIAL.ToString().Reverse().TakeWhile(x => x == ' ').Count();

            /*" -716- SUBTRACT GE149-NOM-SOCIAL-LEN FROM 100 GIVING GE149-NOM-SOCIAL-LEN. */
            GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_LEN.Value = 100 - GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_LEN;

            /*" -718- IF LK-GE053-I-IND-TIPO-ACAO EQUAL 'E' OR LK-GE053-I-IND-USA-NOME-SOCIAL EQUAL 'N' */

            if (SPGE053W.LK_GE053_I_IND_TIPO_ACAO == "E" || SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL == "N")
            {

                /*" -719- MOVE 'N' TO GE149-IND-USA-NOME-SOCIAL */
                _.Move("N", GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL);

                /*" -720- ELSE */
            }
            else
            {


                /*" -721- MOVE 'S' TO GE149-IND-USA-NOME-SOCIAL */
                _.Move("S", GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL);

                /*" -723- END-IF. */
            }


            /*" -760- PERFORM P2020_INSERE_GE149_DB_INSERT_1 */

            P2020_INSERE_GE149_DB_INSERT_1();

            /*" -764- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -765- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -766- MOVE 15 TO WS-ID-ERRO */
                _.Move(15, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -767- MOVE GE149-NUM-CPF TO WS-BIGINT(01) */
                _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -768- MOVE GE149-COD-TP-PES-NEGOCIO TO WS-SMALLINT(01) */
                _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_COD_TP_PES_NEGOCIO, WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -770- MOVE GE149-NUM-PROPOSTA TO WS-SMALLINT(02) */
                _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_PROPOSTA, WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -784- STRING WS-SECTION ' - ERRO NO INSERT NA SEGUROS.GE_NOME_SOCIAL' '<CPF=' WS-BIGINT(01) '>' '<DATA/HORA=' GE149-DTH-OPERACAO '>' '<NOME-SOCIAL=' GE149-NOM-SOCIAL-TEXT '>' '<IND-TIP-ACAO=' GE149-IND-TIPO-ACAO '>' '<USA-NOME-SOCIAL=' GE149-IND-USA-NOME-SOCIAL '>' '<COD-TP-PES-NEGOCIO=' WS-SMALLINT(01) '>' '<NUM-PROPOSTA=' WS-SMALLINT(02) '>' '<COD-CANAL-ORIGEM=' GE149-COD-CANAL-ORIGEM '>' '<NUM-MATRICULA=' GE149-NUM-MATRICULA '>' '<NOM-PROGRAMA=' GE149-NOM-PROGRAMA '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl26 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl26 += " - ERRO NO INSERT NA SEGUROS.GE_NOME_SOCIAL";
                spl26 += "<CPF=";
                var spl27 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl27 += ">";
                spl27 += "<DATA/HORA=";
                var spl28 = GE149.DCLGE_NOME_SOCIAL.GE149_DTH_OPERACAO.GetMoveValues();
                spl28 += ">";
                spl28 += "<NOME-SOCIAL=";
                var spl29 = GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_TEXT.GetMoveValues();
                spl29 += ">";
                spl29 += "<IND-TIP-ACAO=";
                var spl30 = GE149.DCLGE_NOME_SOCIAL.GE149_IND_TIPO_ACAO.GetMoveValues();
                spl30 += ">";
                spl30 += "<USA-NOME-SOCIAL=";
                var spl31 = GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL.GetMoveValues();
                spl31 += ">";
                spl31 += "<COD-TP-PES-NEGOCIO=";
                var spl32 = WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl32 += ">";
                spl32 += "<NUM-PROPOSTA=";
                var spl33 = WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl33 += ">";
                spl33 += "<COD-CANAL-ORIGEM=";
                var spl34 = GE149.DCLGE_NOME_SOCIAL.GE149_COD_CANAL_ORIGEM.GetMoveValues();
                spl34 += ">";
                spl34 += "<NUM-MATRICULA=";
                var spl35 = GE149.DCLGE_NOME_SOCIAL.GE149_NUM_MATRICULA.GetMoveValues();
                spl35 += ">";
                spl35 += "<NOM-PROGRAMA=";
                var spl36 = GE149.DCLGE_NOME_SOCIAL.GE149_NOM_PROGRAMA.GetMoveValues();
                spl36 += ">";
                var results37 = spl26 + spl27 + spl28 + spl29 + spl30 + spl31 + spl32 + spl33 + spl34 + spl35 + spl36;
                _.Move(results37, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -785- MOVE 'SEGUROS.GE_NOME_SOCIAL' TO WS-TABELA */
                _.Move("SEGUROS.GE_NOME_SOCIAL", WORK.WS_ERRO.WS_TABELA);

                /*" -786- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -787- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -789- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -791- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -791- END-IF. */
            }


        }

        [StopWatch]
        /*" P2020-INSERE-GE149-DB-INSERT-1 */
        public void P2020_INSERE_GE149_DB_INSERT_1()
        {
            /*" -760- EXEC SQL INSERT INTO SEGUROS.GE_NOME_SOCIAL ( NUM_CPF , DTH_OPERACAO , NOM_SOCIAL , IND_TIPO_ACAO , IND_USA_NOME_SOCIAL , COD_TP_PES_NEGOCIO , NUM_PROPOSTA , COD_CANAL_ORIGEM , NUM_MATRICULA , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( :GE149-NUM-CPF , CASE :GE149-DTH-OPERACAO WHEN '0001-01-01-00.00.00.000000' THEN CURRENT TIMESTAMP ELSE :GE149-DTH-OPERACAO END , :GE149-NOM-SOCIAL , :GE149-IND-TIPO-ACAO , :GE149-IND-USA-NOME-SOCIAL , CASE :GE149-COD-TP-PES-NEGOCIO WHEN 0 THEN NULL ELSE :GE149-COD-TP-PES-NEGOCIO END , :GE149-NUM-PROPOSTA , :GE149-COD-CANAL-ORIGEM , :GE149-NUM-MATRICULA , :GE149-NOM-PROGRAMA , CURRENT TIMESTAMP ) END-EXEC. */

            var p2020_INSERE_GE149_DB_INSERT_1_Insert1 = new P2020_INSERE_GE149_DB_INSERT_1_Insert1()
            {
                GE149_NUM_CPF = GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF.ToString(),
                GE149_DTH_OPERACAO = GE149.DCLGE_NOME_SOCIAL.GE149_DTH_OPERACAO.ToString(),
                GE149_NOM_SOCIAL = GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.ToString(),
                GE149_IND_TIPO_ACAO = GE149.DCLGE_NOME_SOCIAL.GE149_IND_TIPO_ACAO.ToString(),
                GE149_IND_USA_NOME_SOCIAL = GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL.ToString(),
                GE149_COD_TP_PES_NEGOCIO = GE149.DCLGE_NOME_SOCIAL.GE149_COD_TP_PES_NEGOCIO.ToString(),
                GE149_NUM_PROPOSTA = GE149.DCLGE_NOME_SOCIAL.GE149_NUM_PROPOSTA.ToString(),
                GE149_COD_CANAL_ORIGEM = GE149.DCLGE_NOME_SOCIAL.GE149_COD_CANAL_ORIGEM.ToString(),
                GE149_NUM_MATRICULA = GE149.DCLGE_NOME_SOCIAL.GE149_NUM_MATRICULA.ToString(),
                GE149_NOM_PROGRAMA = GE149.DCLGE_NOME_SOCIAL.GE149_NOM_PROGRAMA.ToString(),
            };

            P2020_INSERE_GE149_DB_INSERT_1_Insert1.Execute(p2020_INSERE_GE149_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2020_99_EXIT*/

        [StopWatch]
        /*" P2030-CONSULTA-GE149-SECTION */
        private void P2030_CONSULTA_GE149_SECTION()
        {
            /*" -803- MOVE 'P2030' TO WS-SECTION. */
            _.Move("P2030", WORK.WS_ERRO.WS_SECTION);

            /*" -804- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -805- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -807- END-IF. */
            }


            /*" -810- INITIALIZE DCLGE-NOME-SOCIAL REPLACING NUMERIC BY ZERO ALPHANUMERIC BY SPACE. */
            _.Initialize(
                GE149.DCLGE_NOME_SOCIAL
            );

            /*" -812- MOVE LK-GE053-I-NUM-CPF TO GE149-NUM-CPF. */
            _.Move(SPGE053W.LK_GE053_I_NUM_CPF, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF);

            /*" -840- PERFORM P2030_CONSULTA_GE149_DB_SELECT_1 */

            P2030_CONSULTA_GE149_DB_SELECT_1();

            /*" -844- IF SQLCODE NOT EQUAL 0 AND SQLCODE NOT EQUAL +100 */

            if (DB.SQLCODE != 0 && DB.SQLCODE != +100)
            {

                /*" -845- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -846- MOVE 16 TO WS-ID-ERRO */
                _.Move(16, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -847- MOVE GE149-NUM-CPF TO WS-BIGINT(01) */
                _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -852- STRING WS-SECTION ' - ERRO NO SELECT DA TABELA SEGUROS.GE_NOME_SOCIAL' '<CPF=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl37 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl37 += " - ERRO NO SELECT DA TABELA SEGUROS.GE_NOME_SOCIAL";
                spl37 += "<CPF=";
                var spl38 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl38 += ">";
                var results39 = spl37 + spl38;
                _.Move(results39, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -853- MOVE 'SEGUROS.GE_NOME_SOCIAL' TO WS-TABELA */
                _.Move("SEGUROS.GE_NOME_SOCIAL", WORK.WS_ERRO.WS_TABELA);

                /*" -854- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -855- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -857- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -859- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -859- END-IF. */
            }


        }

        [StopWatch]
        /*" P2030-CONSULTA-GE149-DB-SELECT-1 */
        public void P2030_CONSULTA_GE149_DB_SELECT_1()
        {
            /*" -840- EXEC SQL SELECT NUM_CPF , DTH_OPERACAO , NOM_SOCIAL , IND_TIPO_ACAO , IND_USA_NOME_SOCIAL , IFNULL( COD_TP_PES_NEGOCIO , 0 ) , IFNULL( NUM_PROPOSTA , 0 ) , COD_CANAL_ORIGEM , NUM_MATRICULA , NOM_PROGRAMA , DTH_CADASTRAMENTO INTO :GE149-NUM-CPF , :GE149-DTH-OPERACAO , :GE149-NOM-SOCIAL , :GE149-IND-TIPO-ACAO , :GE149-IND-USA-NOME-SOCIAL , :GE149-COD-TP-PES-NEGOCIO , :GE149-NUM-PROPOSTA , :GE149-COD-CANAL-ORIGEM , :GE149-NUM-MATRICULA , :GE149-NOM-PROGRAMA , :GE149-DTH-CADASTRAMENTO FROM SEGUROS.GE_NOME_SOCIAL WHERE NUM_CPF = :GE149-NUM-CPF ORDER BY DTH_OPERACAO DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var p2030_CONSULTA_GE149_DB_SELECT_1_Query1 = new P2030_CONSULTA_GE149_DB_SELECT_1_Query1()
            {
                GE149_NUM_CPF = GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF.ToString(),
            };

            var executed_1 = P2030_CONSULTA_GE149_DB_SELECT_1_Query1.Execute(p2030_CONSULTA_GE149_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE149_NUM_CPF, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF);
                _.Move(executed_1.GE149_DTH_OPERACAO, GE149.DCLGE_NOME_SOCIAL.GE149_DTH_OPERACAO);
                _.Move(executed_1.GE149_NOM_SOCIAL, GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL);
                _.Move(executed_1.GE149_IND_TIPO_ACAO, GE149.DCLGE_NOME_SOCIAL.GE149_IND_TIPO_ACAO);
                _.Move(executed_1.GE149_IND_USA_NOME_SOCIAL, GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL);
                _.Move(executed_1.GE149_COD_TP_PES_NEGOCIO, GE149.DCLGE_NOME_SOCIAL.GE149_COD_TP_PES_NEGOCIO);
                _.Move(executed_1.GE149_NUM_PROPOSTA, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_PROPOSTA);
                _.Move(executed_1.GE149_COD_CANAL_ORIGEM, GE149.DCLGE_NOME_SOCIAL.GE149_COD_CANAL_ORIGEM);
                _.Move(executed_1.GE149_NUM_MATRICULA, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_MATRICULA);
                _.Move(executed_1.GE149_NOM_PROGRAMA, GE149.DCLGE_NOME_SOCIAL.GE149_NOM_PROGRAMA);
                _.Move(executed_1.GE149_DTH_CADASTRAMENTO, GE149.DCLGE_NOME_SOCIAL.GE149_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2030_99_EXIT*/

        [StopWatch]
        /*" P2031-MOVE-CONSULTA-SECTION */
        private void P2031_MOVE_CONSULTA_SECTION()
        {
            /*" -871- MOVE 'P2031' TO WS-SECTION. */
            _.Move("P2031", WORK.WS_ERRO.WS_SECTION);

            /*" -872- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -873- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -875- END-IF. */
            }


            /*" -877- MOVE GE149-NUM-CPF TO LK-GE053-I-NUM-CPF. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -879- MOVE GE149-DTH-OPERACAO TO LK-GE053-I-DTH-OPERACAO. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_DTH_OPERACAO, SPGE053W.LK_GE053_I_DTH_OPERACAO);

            /*" -881- MOVE GE149-NOM-SOCIAL-TEXT(1:GE149-NOM-SOCIAL-LEN) TO LK-GE053-I-NOM-SOCIAL. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_TEXT.Substring(1, GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_LEN), SPGE053W.LK_GE053_I_NOM_SOCIAL);

            /*" -883- MOVE GE149-IND-TIPO-ACAO TO LK-GE053-I-IND-TIPO-ACAO. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_IND_TIPO_ACAO, SPGE053W.LK_GE053_I_IND_TIPO_ACAO);

            /*" -885- MOVE GE149-IND-USA-NOME-SOCIAL TO LK-GE053-I-IND-USA-NOME-SOCIAL. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL, SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL);

            /*" -887- MOVE GE149-COD-TP-PES-NEGOCIO TO LK-GE053-I-COD-TP-PES-NEGOCIO. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_COD_TP_PES_NEGOCIO, SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO);

            /*" -889- MOVE GE149-NUM-PROPOSTA TO LK-GE053-I-NUM-PROPOSTA. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_PROPOSTA, SPGE053W.LK_GE053_I_NUM_PROPOSTA);

            /*" -891- MOVE GE149-COD-CANAL-ORIGEM TO LK-GE053-I-COD-CANAL-ORIGEM. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_COD_CANAL_ORIGEM, SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM);

            /*" -893- MOVE GE149-NUM-MATRICULA TO LK-GE053-I-NUM-MATRICULA. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_MATRICULA, SPGE053W.LK_GE053_I_NUM_MATRICULA);

            /*" -895- MOVE GE149-NOM-PROGRAMA TO LK-GE053-I-NOM-PROGRAMA. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NOM_PROGRAMA, SPGE053W.LK_GE053_I_NOM_PROGRAMA);

            /*" -899- MOVE GE149-DTH-CADASTRAMENTO TO LK-GE053-I-DTH-CADASTRAMENTO. */
            _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_DTH_CADASTRAMENTO, SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO);

            /*" -901- MOVE SPACES TO LK-GE053-I-NOM-SOCIAL */
            _.Move("", SPGE053W.LK_GE053_I_NOM_SOCIAL);

            /*" -902- IF GE149-IND-USA-NOME-SOCIAL EQUAL 'S' */

            if (GE149.DCLGE_NOME_SOCIAL.GE149_IND_USA_NOME_SOCIAL == "S")
            {

                /*" -904- MOVE GE149-NOM-SOCIAL-TEXT(1:GE149-NOM-SOCIAL-LEN) TO LK-GE053-I-NOM-SOCIAL */
                _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_TEXT.Substring(1, GE149.DCLGE_NOME_SOCIAL.GE149_NOM_SOCIAL.GE149_NOM_SOCIAL_LEN), SPGE053W.LK_GE053_I_NOM_SOCIAL);

                /*" -904- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2031_99_EXIT*/

        [StopWatch]
        /*" P2060-LISTA-NOME-SOCIAL-SECTION */
        private void P2060_LISTA_NOME_SOCIAL_SECTION()
        {
            /*" -916- MOVE 'P2031' TO WS-SECTION. */
            _.Move("P2031", WORK.WS_ERRO.WS_SECTION);

            /*" -917- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -918- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -920- END-IF. */
            }


            /*" -923- INITIALIZE DCLGE-NOME-SOCIAL REPLACING NUMERIC BY ZERO ALPHANUMERIC BY SPACE. */
            _.Initialize(
                GE149.DCLGE_NOME_SOCIAL
            );

            /*" -925- MOVE LK-GE053-I-NUM-CPF TO GE149-NUM-CPF. */
            _.Move(SPGE053W.LK_GE053_I_NUM_CPF, GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF);

            /*" -927- PERFORM P2060_LISTA_NOME_SOCIAL_DB_OPEN_1 */

            P2060_LISTA_NOME_SOCIAL_DB_OPEN_1();

            /*" -930- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -931- MOVE 2 TO WS-IND-ERRO */
                _.Move(2, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -932- MOVE 17 TO WS-ID-ERRO */
                _.Move(17, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -934- MOVE GE149-NUM-CPF TO WS-BIGINT(01) */
                _.Move(GE149.DCLGE_NOME_SOCIAL.GE149_NUM_CPF, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -935- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -939- STRING WS-SECTION ' - REGISTRO N�O LOCALIZADO.' '<CPF=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl39 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl39 += " - REGISTRO N�O LOCALIZADO.";
                    spl39 += "<CPF=";
                    var spl40 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                    spl40 += ">";
                    var results41 = spl39 + spl40;
                    _.Move(results41, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -940- ELSE */
                }
                else
                {


                    /*" -945- STRING WS-SECTION ' - ERRO AO ABRIR CURSOR CSR-NOME-SOCIAL' '<CPF=' WS-BIGINT(01) '>' '<DATA/HORA=' GE149-DTH-OPERACAO '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                    #region STRING
                    var spl41 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                    spl41 += " - ERRO AO ABRIR CURSOR CSR-NOME-SOCIAL";
                    spl41 += "<CPF=";
                    var spl42 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                    spl42 += ">";
                    spl42 += "<DATA/HORA=";
                    var spl43 = GE149.DCLGE_NOME_SOCIAL.GE149_DTH_OPERACAO.GetMoveValues();
                    spl43 += ">";
                    var results44 = spl41 + spl42 + spl43;
                    _.Move(results44, WORK.WS_ERRO.WS_MENSAGEM);
                    #endregion

                    /*" -947- END-IF */
                }


                /*" -948- MOVE 'SEGUROS.GE_NOME_SOCIAL' TO WS-TABELA */
                _.Move("SEGUROS.GE_NOME_SOCIAL", WORK.WS_ERRO.WS_TABELA);

                /*" -949- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WORK.WS_ERRO.WS_SQLCODE);

                /*" -950- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WORK.WS_ERRO.WS_SQLERRMC);

                /*" -952- MOVE SQLSTATE TO WS-SQLSTATE */
                _.Move(DB.SQLSTATE, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -954- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -954- END-IF. */
            }


        }

        [StopWatch]
        /*" P2060-LISTA-NOME-SOCIAL-DB-OPEN-1 */
        public void P2060_LISTA_NOME_SOCIAL_DB_OPEN_1()
        {
            /*" -927- EXEC SQL OPEN CSR-NOM-SOCIAL END-EXEC. */

            CSR_NOM_SOCIAL.Open();
            Result = CSR_NOM_SOCIAL.AllData;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2060_99_EXIT*/

        [StopWatch]
        /*" P2900-VALIDA-CHAVE-SECTION */
        private void P2900_VALIDA_CHAVE_SECTION()
        {
            /*" -966- MOVE 'P2090' TO WS-SECTION */
            _.Move("P2090", WORK.WS_ERRO.WS_SECTION);

            /*" -967- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -968- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -987- END-IF. */
            }


            /*" -988- IF LK-GE053-I-NUM-CPF LESS 1 */

            if (SPGE053W.LK_GE053_I_NUM_CPF < 1)
            {

                /*" -989- MOVE 1 TO WS-IND-ERRO */
                _.Move(1, WORK.WS_ERRO.WS_IND_ERRO);

                /*" -990- MOVE 19 TO WS-ID-ERRO */
                _.Move(19, WORK.WS_ERRO.WS_ID_ERRO);

                /*" -991- MOVE LK-GE053-I-NUM-CPF TO WS-BIGINT(01) */
                _.Move(SPGE053W.LK_GE053_I_NUM_CPF, WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -994- STRING WS-SECTION ' - CPF NAO INFORMADO.' '<CPF=' WS-BIGINT(01) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl44 = WORK.WS_ERRO.WS_SECTION.GetMoveValues();
                spl44 += " - CPF NAO INFORMADO.";
                spl44 += "<CPF=";
                var spl45 = WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl45 += ">";
                var results46 = spl44 + spl45;
                _.Move(results46, WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -997- MOVE SPACES TO WS-TABELA WS-SQLERRMC WS-SQLSTATE */
                _.Move("", WORK.WS_ERRO.WS_TABELA, WORK.WS_ERRO.WS_SQLERRMC, WORK.WS_ERRO.WS_SQLSTATE);

                /*" -998- MOVE 0 TO WS-SQLCODE */
                _.Move(0, WORK.WS_ERRO.WS_SQLCODE);

                /*" -999- GO TO P9999-ERRO */

                P9999_ERRO_SECTION(); //GOTO
                return;

                /*" -999- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2900_99_EXIT*/

        [StopWatch]
        /*" P3000-FINALIZA-SECTION */
        private void P3000_FINALIZA_SECTION()
        {
            /*" -1011- MOVE 'P3000' TO WS-SECTION */
            _.Move("P3000", WORK.WS_ERRO.WS_SECTION);

            /*" -1012- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -1013- DISPLAY WS-SECTION */
                _.Display(WORK.WS_ERRO.WS_SECTION);

                /*" -1015- END-IF. */
            }


            /*" -1019- MOVE 0 TO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-SQLCODE. */
            _.Move(0, SPGE053W.LK_GE053_IND_ERRO, SPGE053W.LK_GE053_ID_ERRO, SPGE053W.LK_GE053_SQLCODE);

            /*" -1023- MOVE SPACES TO LK-GE053-NOM-TABELA LK-GE053-SQLERRMC LK-GE053-SQLSTATE. */
            _.Move("", SPGE053W.LK_GE053_NOM_TABELA, SPGE053W.LK_GE053_SQLERRMC, SPGE053W.LK_GE053_SQLSTATE);

            /*" -1024- IF LK-GE053-E-TRACE = 'S' */

            if (SPGE053W.LK_GE053_E_TRACE == "S")
            {

                /*" -1027- MOVE 'OPERACAO SOLICITADA REALIZADA COM SUCESSO.' TO LK-GE053-MENSAGEM */
                _.Move("OPERACAO SOLICITADA REALIZADA COM SUCESSO.", SPGE053W.LK_GE053_MENSAGEM);

                /*" -1028- DISPLAY LK-GE053-MENSAGEM */
                _.Display(SPGE053W.LK_GE053_MENSAGEM);

                /*" -1029- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1030- DISPLAY '*          F I M   S P B G E 0 5 3           *' */
                _.Display($"*          F I M   S P B G E 0 5 3           *");

                /*" -1031- DISPLAY '**********************************************' */
                _.Display($"**********************************************");

                /*" -1031- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P3000_99_EXIT*/

        [StopWatch]
        /*" P9999-ERRO-SECTION */
        private void P9999_ERRO_SECTION()
        {
            /*" -1042- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1043- DISPLAY '*            S P B G E 0 5 3                 *' */
            _.Display($"*            S P B G E 0 5 3                 *");

            /*" -1044- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1051- DISPLAY '* DATA COMPILACAO..: ' WS-C-DATE-COMPILED(7:2) '/' WS-C-DATE-COMPILED(5:2) '/' WS-C-DATE-COMPILED(1:4) '-' WS-C-DATE-COMPILED(9:2) ':' WS-C-DATE-COMPILED(11:2) ':' WS-C-DATE-COMPILED(13:2) */

            $"* DATA COMPILACAO..: {WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_COMPILED.Substring(13, 2)}"
            .Display();

            /*" -1058- DISPLAY '* DATA EXECUCAO....: ' WS-C-DATE-CURRENT(7:2) '/' WS-C-DATE-CURRENT(5:2) '/' WS-C-DATE-CURRENT(1:4) '-' WS-C-DATE-CURRENT(9:2) ':' WS-C-DATE-CURRENT(11:2) ':' WS-C-DATE-CURRENT(13:2) */

            $"* DATA EXECUCAO....: {WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(7, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(5, 2)}/{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(1, 4)}-{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(9, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(11, 2)}:{WORK.WS_DATAS.WS_C_DATE_CURRENT.Substring(13, 2)}"
            .Display();

            /*" -1062- DISPLAY '* DATA SISTEMA.....: ' SISTEMAS-DATA-MOV-ABERTO(9:2) '/' SISTEMAS-DATA-MOV-ABERTO(6:2) '/' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"* DATA SISTEMA.....: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}/{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -1063- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1064- DISPLAY '*             DADOS DE ENTRADA               *' */
            _.Display($"*             DADOS DE ENTRADA               *");

            /*" -1065- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1067- DISPLAY '* <TRACE.............. ' LK-GE053-E-TRACE '>' */

            $"* <TRACE.............. {SPGE053W.LK_GE053_E_TRACE}>"
            .Display();

            /*" -1069- DISPLAY '* <IDE-SISTEMA........ ' LK-GE053-E-IDE-SISTEMA '>' */

            $"* <IDE-SISTEMA........ {SPGE053W.LK_GE053_E_IDE_SISTEMA}>"
            .Display();

            /*" -1071- DISPLAY '* <IND-OPERACAO....... ' LK-GE053-E-IND-OPERACAO '>' */

            $"* <IND-OPERACAO....... {SPGE053W.LK_GE053_E_IND_OPERACAO}>"
            .Display();

            /*" -1073- DISPLAY '* <NUM-CPF............ ' LK-GE053-I-NUM-CPF '>' */

            $"* <NUM-CPF............ {SPGE053W.LK_GE053_I_NUM_CPF}>"
            .Display();

            /*" -1075- DISPLAY '* <DTH-OPERACAO....... ' LK-GE053-I-DTH-OPERACAO '>' */

            $"* <DTH-OPERACAO....... {SPGE053W.LK_GE053_I_DTH_OPERACAO}>"
            .Display();

            /*" -1077- DISPLAY '* <NOM-SOCIAL......... ' LK-GE053-I-NOM-SOCIAL '>' */

            $"* <NOM-SOCIAL......... {SPGE053W.LK_GE053_I_NOM_SOCIAL}>"
            .Display();

            /*" -1079- DISPLAY '* <IND-TIPO-ACAO...... ' LK-GE053-I-IND-TIPO-ACAO '>' */

            $"* <IND-TIPO-ACAO...... {SPGE053W.LK_GE053_I_IND_TIPO_ACAO}>"
            .Display();

            /*" -1081- DISPLAY '* <IND-USA-NOME-SOCIAL ' LK-GE053-I-IND-USA-NOME-SOCIAL '>' */

            $"* <IND-USA-NOME-SOCIAL {SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL}>"
            .Display();

            /*" -1083- DISPLAY '* <COD-TP-PES-NEGOCIO. ' LK-GE053-I-COD-TP-PES-NEGOCIO '>' */

            $"* <COD-TP-PES-NEGOCIO. {SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO}>"
            .Display();

            /*" -1085- DISPLAY '* <NUM-PROPOSTA....... ' LK-GE053-I-NUM-PROPOSTA '>' */

            $"* <NUM-PROPOSTA....... {SPGE053W.LK_GE053_I_NUM_PROPOSTA}>"
            .Display();

            /*" -1087- DISPLAY '* <COD-CANAL-ORIGEM... ' LK-GE053-I-COD-CANAL-ORIGEM '>' */

            $"* <COD-CANAL-ORIGEM... {SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM}>"
            .Display();

            /*" -1089- DISPLAY '* <NUM-MATRICULA...... ' LK-GE053-I-NUM-MATRICULA '>' */

            $"* <NUM-MATRICULA...... {SPGE053W.LK_GE053_I_NUM_MATRICULA}>"
            .Display();

            /*" -1090- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1091- DISPLAY '*         E R R O    S P B G E 0 5 3         *' */
            _.Display($"*         E R R O    S P B G E 0 5 3         *");

            /*" -1092- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1093- DISPLAY '* SECTION..........: ' WS-SECTION */
            _.Display($"* SECTION..........: {WORK.WS_ERRO.WS_SECTION}");

            /*" -1094- DISPLAY '* IND ERRO.........: ' WS-IND-ERRO */
            _.Display($"* IND ERRO.........: {WORK.WS_ERRO.WS_IND_ERRO}");

            /*" -1095- DISPLAY '* ID ERRO..........: ' WS-ID-ERRO */
            _.Display($"* ID ERRO..........: {WORK.WS_ERRO.WS_ID_ERRO}");

            /*" -1096- DISPLAY '* TABELA...........: ' WS-TABELA */
            _.Display($"* TABELA...........: {WORK.WS_ERRO.WS_TABELA}");

            /*" -1097- DISPLAY '* MENSAGEM.........: ' WS-MENSAGEM */
            _.Display($"* MENSAGEM.........: {WORK.WS_ERRO.WS_MENSAGEM}");

            /*" -1098- DISPLAY '* SQLCODE..........: ' WS-SQLCODE */
            _.Display($"* SQLCODE..........: {WORK.WS_ERRO.WS_SQLCODE}");

            /*" -1099- DISPLAY '* SQLERRMC.........: ' WS-SQLERRMC */
            _.Display($"* SQLERRMC.........: {WORK.WS_ERRO.WS_SQLERRMC}");

            /*" -1100- DISPLAY '* SQLSTATE.........: ' WS-SQLSTATE */
            _.Display($"* SQLSTATE.........: {WORK.WS_ERRO.WS_SQLSTATE}");

            /*" -1102- DISPLAY '**********************************************' */
            _.Display($"**********************************************");

            /*" -1103- MOVE WS-IND-ERRO TO LK-GE053-IND-ERRO */
            _.Move(WORK.WS_ERRO.WS_IND_ERRO, SPGE053W.LK_GE053_IND_ERRO);

            /*" -1104- MOVE WS-ID-ERRO TO LK-GE053-ID-ERRO */
            _.Move(WORK.WS_ERRO.WS_ID_ERRO, SPGE053W.LK_GE053_ID_ERRO);

            /*" -1105- MOVE WS-MENSAGEM TO LK-GE053-MENSAGEM */
            _.Move(WORK.WS_ERRO.WS_MENSAGEM, SPGE053W.LK_GE053_MENSAGEM);

            /*" -1106- MOVE WS-TABELA TO LK-GE053-NOM-TABELA */
            _.Move(WORK.WS_ERRO.WS_TABELA, SPGE053W.LK_GE053_NOM_TABELA);

            /*" -1107- MOVE WS-SQLCODE TO LK-GE053-SQLCODE */
            _.Move(WORK.WS_ERRO.WS_SQLCODE, SPGE053W.LK_GE053_SQLCODE);

            /*" -1108- MOVE WS-SQLERRMC TO LK-GE053-SQLERRMC */
            _.Move(WORK.WS_ERRO.WS_SQLERRMC, SPGE053W.LK_GE053_SQLERRMC);

            /*" -1110- MOVE WS-SQLSTATE TO LK-GE053-SQLSTATE */
            _.Move(WORK.WS_ERRO.WS_SQLSTATE, SPGE053W.LK_GE053_SQLSTATE);

            /*" -1110- . */

            /*" -0- FLUXCONTROL_PERFORM P9999_99_EXIT */

            P9999_99_EXIT();

        }

        [StopWatch]
        /*" P9999-99-EXIT */
        private void P9999_99_EXIT(bool isPerform = false)
        {
            /*" -1113- GOBACK. */

            throw new GoBack();

        }
    }
}