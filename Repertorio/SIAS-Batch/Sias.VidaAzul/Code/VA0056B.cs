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
using Sias.VidaAzul.DB2.VA0056B;

namespace Code
{
    public class VA0056B
    {
        public bool IsCall { get; set; }

        public VA0056B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VA - VIDA                          *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VA0056B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO/2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  LIBERA PROPOSTAS QUE ESTAO         *      */
        /*"      *                             AGUARDANDO CRIVO A MAIS DE         *      */
        /*"      *                             TRES DIAS                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  *   VERSAO 12 - DEMANDA 402.982                                  *      */
        /*"      *             - DEIXAR CURSOR VG_CRITICA_PROPOSTA DEVOLVER O     *      */
        /*"      *               SEQ_CRITICA PARA PODER EXECUTAR A DELECAO LOGICA *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/03/2023 - HUNSI ALI HUSNI                              *      */
        /*"      *                                        PROCURE POR V.12        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *   VERSAO 11 - DEMANDA 402.982                                  *      */
        /*"      *             - RETIRAR GRAVACAO DE ERROS DA PROPOSTA DA TABELA  *      */
        /*"      *               ERROS_PROP_VIDAZUL                               *      */
        /*"      *             - GRAVAR ERROS DA PROPOSTA NA NOVA TABELA          *      */
        /*"      *               VG_CRITICA_PROPOSTA PARA POSTERIOR ANALISE DO    *      */
        /*"      *               GESTOR NO ATALHO 04.23                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.11        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.10  *   VERSAO 10 - DEMANDA 387.459                                  *      */
        /*"      *             - A VERSAO 09 GEROU IMPACTO NO AUTO COMPRA DE VIDA *      */
        /*"      *               E OS PROGRAMAS DE RETORNO DO CRIVO, DEVEM ENVIAR *      */
        /*"      *               ESTAS PROPOSTAS PARA SITUACAO '7' PARA GERAR A   *      */
        /*"      *               1A PARCELA.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/09/2022 - FRANK CARVALHO       PROCURE POR V.10        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   VERSAO 09 - DEMANDA 387.459                                  *      */
        /*"      *             - ALTERACAO PARA EMISSAO AUTOMATICA INDEPENDENTE   *      */
        /*"      *               DA MANEIRA QUE O CLIENTE ASSINOU, PARA PROPOSTAS *      */
        /*"      *               COM IS ATE 200 MIL REAIS.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2022 - FRANK CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.09        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - HIST.  272.172                                   *      */
        /*"      *               ALTERACAO DA REGRA DE ACEITACAO AUTOMATICA.      *      */
        /*"      *               PROPOSTAS SEM ERROS DEVEM AGUARDAR PROPOSTA      *      */
        /*"      *               FISICA INDEPENDENTE DO VALOR SEGURADO E DO       *      */
        /*"      *               CANAL DE VENDA.                                  *      */
        /*"      *               PROPOSTA ELETRONICA NAO AGUARDA PROPOSTA FISICA. *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/04/2021 - BRICE HO                                     *      */
        /*"      *                                         PROCURE POR V.08       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - HIST.   15.616                                   *      */
        /*"      *             - CORRIGIR CONTADOR DE ERROS POIS ESTAO EMITINDO   *      */
        /*"      *   PROPOSTAS COM ERROS QUE DEVERIAM CAIR PARA O OPERACIONAL.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/05/2018 - FRANK CARVALHO                               *      */
        /*"      *                                         PROCURE POR V.07       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - HIST.   13.055                                   *      */
        /*"      *               TRATAR ERRO 1803 E 1804 - ERRO DPS.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2018 - HERVAL SOUZA                                 *      */
        /*"      *                                         PROCURE POR V.06       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 152.475                                      *      */
        /*"      *               MANTER PROPOSTA EM CR�TICA QUANDO TIVER ERRO     *      */
        /*"      *               1876 - CONSULTA CRIVO N�O RETORNOU RESULTADO     *      */
        /*"      *   EM 18/08/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                   PROCURE POR V.05             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04   CAD 142.087 - ABEND                              *      */
        /*"      *                                                                *      */
        /*"      *       - PERMITIR O TRATAMENTO PARA OS CANAIS DE VENDA 2 E 3.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2016 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03   CAD 140.553 - DOCYOUSIGN                         *      */
        /*"      *                                                                *      */
        /*"      *       - ALTERAR CONTAGEM DE ERROS - PROPOSTA DIGITAIS NAO IRAO *      */
        /*"      *         CONTER O ERRO 1800.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2016 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02                                                    *      */
        /*"      *             - CAD 83.710                                       *      */
        /*"      *               PREVER TRATAMENTO PROPOSTAS AIC.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2013 - BRICE HO                 PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 13.762                                       *      */
        /*"      *               REVISAO DO PRODUTOS DE PAGAMENTO UNICO           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-COUNT                   PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-COUNT-ERRO-COMUN        PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT_ERRO_COMUN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-COUNT-1803-1804         PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_COUNT_1803_1804 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WHOST-IND-PROP-ELETRONICA     PIC  X(001)    VALUE 'N'.*/
        public StringBasis WHOST_IND_PROP_ELETRONICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-3    PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          FILLER.*/
        public VA0056B_FILLER_0 FILLER_0 { get; set; } = new VA0056B_FILLER_0();
        public class VA0056B_FILLER_0 : VarBasis
        {
            /*"  03        WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        AC-ERROS-QTDE       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_ERROS_QTDE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-DESPR            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_DESPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-U-PROPOVA        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_PROPOVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WFIM-CURSOR         PIC  X(003) VALUE SPACES.*/
            public StringBasis WFIM_CURSOR { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03        W-NUM-PROPOSTA      PIC  9(014).*/
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  03        CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_VA0056B_CANAL _canal { get; set; }
            public _REDEF_VA0056B_CANAL CANAL
            {
                get { _canal = new _REDEF_VA0056B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_VA0056B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                    VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                      VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                   VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                       VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                        VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                          VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                       VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-VENDA-AIC                      VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_AIC", "8")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    03      WABEND.*/
                public VA0056B_WABEND WABEND { get; set; } = new VA0056B_WABEND();
                public class VA0056B_WABEND : VarBasis
                {
                    /*"      05      FILLER              PIC  X(010) VALUE             ' VA0056B'.*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0056B");
                    /*"      05      FILLER              PIC  X(028) VALUE             ' *** ERRO  EXEC SQL  NUMERO '.*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                    /*"      05      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                    /*"      05      FILLER              PIC  X(017) VALUE             ' *** PARAGRAFO = '.*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                    /*"      05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                    public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE = '.*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                    /*"      05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE1= '.*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                    /*"      05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"      05      FILLER              PIC  X(014) VALUE             '    SQLCODE2= '.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                    /*"      05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                    /*"    03         WSQLERRO.*/

                    public VA0056B_WABEND()
                    {
                        FILLER_2.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                        WNR_EXEC_SQL.ValueChanged += OnValueChanged;
                        FILLER_4.ValueChanged += OnValueChanged;
                        PARAGRAFO.ValueChanged += OnValueChanged;
                        FILLER_5.ValueChanged += OnValueChanged;
                        WSQLCODE.ValueChanged += OnValueChanged;
                        FILLER_6.ValueChanged += OnValueChanged;
                        WSQLCODE1.ValueChanged += OnValueChanged;
                        FILLER_7.ValueChanged += OnValueChanged;
                        WSQLCODE2.ValueChanged += OnValueChanged;
                    }

                }
                public VA0056B_WSQLERRO WSQLERRO { get; set; } = new VA0056B_WSQLERRO();
                public class VA0056B_WSQLERRO : VarBasis
                {
                    /*"      05         FILLER               PIC  X(014) VALUE                ' *** SQLERRMC '.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      05         WSQLERRMC            PIC  X(070) VALUE  SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");

                    public VA0056B_WSQLERRO()
                    {
                        FILLER_8.ValueChanged += OnValueChanged;
                        WSQLERRMC.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA0056B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WABEND.ValueChanged += OnValueChanged;
                    WSQLERRO.ValueChanged += OnValueChanged;
                }

            }
        }


        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.ERPROPAZ ERPROPAZ { get; set; } = new Dclgens.ERPROPAZ();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.VG078 VG078 { get; set; } = new Dclgens.VG078();
        public VA0056B_CCURSOR CCURSOR { get; set; } = new VA0056B_CCURSOR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -226- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -227- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -230- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -233- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -236- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -237- DISPLAY '          PROGRAMA EM EXECUCAO VA0056B             ' */
            _.Display($"          PROGRAMA EM EXECUCAO VA0056B             ");

            /*" -238- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -239- DISPLAY 'LIBERA PROPOSTAS AGUARDANDO CRIVO A MAIS DE 3 DIAS' */
            _.Display($"LIBERA PROPOSTAS AGUARDANDO CRIVO A MAIS DE 3 DIAS");

            /*" -240- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -241- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -243- DISPLAY 'VERSAO V.11: ' FUNCTION WHEN-COMPILED ' - 402.982' */

            $"VERSAO V.11: FUNCTION{_.WhenCompiled()} - 402.982"
            .Display();

            /*" -244- DISPLAY ' ' */
            _.Display($" ");

            /*" -251- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -252- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -260- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -262- PERFORM R0100-00-SELECT-TSISTEMA. */

            R0100_00_SELECT_TSISTEMA_SECTION();

            /*" -264- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -266- PERFORM R0910-00-FETCH. */

            R0910_00_FETCH_SECTION();

            /*" -269- PERFORM R1000-00-PROCESSA-CGCCPF UNTIL WFIM-CURSOR EQUAL 'SIM' . */

            while (!(FILLER_0.WFIM_CURSOR == "SIM"))
            {

                R1000_00_PROCESSA_CGCCPF_SECTION();
            }

            /*" -271- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -271- PERFORM R9000-00-FINALIZA. */

            R9000_00_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-SECTION */
        private void R0100_00_SELECT_TSISTEMA_SECTION()
        {
            /*" -286- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -296- PERFORM R0100_00_SELECT_TSISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_TSISTEMA_DB_SELECT_1();

            /*" -299- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -300- DISPLAY 'VA0056B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VA0056B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -301- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -302- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -304- END-IF */
            }


            /*" -305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -306- DISPLAY 'VA0056B - ERRO NA LEITURA NA SISTEMAS  ' */
                _.Display($"VA0056B - ERRO NA LEITURA NA SISTEMAS  ");

                /*" -307- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -309- END-IF */
            }


            /*" -310- DISPLAY 'DATA MOVIMENTO ABERTO: ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA MOVIMENTO ABERTO: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -312- DISPLAY 'DATA QUITACAO LIMITE.: ' SISTEMAS-DATA-MOV-ABERTO-3 */
            _.Display($"DATA QUITACAO LIMITE.: {SISTEMAS_DATA_MOV_ABERTO_3}");

            /*" -312- . */

        }

        [StopWatch]
        /*" R0100-00-SELECT-TSISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_TSISTEMA_DB_SELECT_1()
        {
            /*" -296- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 3 DAYS INTO :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-ABERTO-3 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_3, SISTEMAS_DATA_MOV_ABERTO_3);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -325- MOVE 'R0900-00-DECLARE-CURSOR' TO PARAGRAFO. */
            _.Move("R0900-00-DECLARE-CURSOR", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -329- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -334- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -337- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -334- EXEC SQL DECLARE CCURSOR CURSOR FOR SELECT NUM_CERTIFICADO , DATA_QUITACAO FROM SEGUROS.PROPOSTAS_VA WHERE SIT_REGISTRO = 'E' END-EXEC. */
            CCURSOR = new VA0056B_CCURSOR(false);
            string GetQuery_CCURSOR()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							DATA_QUITACAO 
							FROM SEGUROS.PROPOSTAS_VA 
							WHERE SIT_REGISTRO = 'E'";

                return query;
            }
            CCURSOR.GetQueryEvent += GetQuery_CCURSOR;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -337- EXEC SQL OPEN CCURSOR END-EXEC. */

            CCURSOR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-SECTION */
        private void R0910_00_FETCH_SECTION()
        {
            /*" -350- MOVE 'R0910-00-FETCH' TO PARAGRAFO */
            _.Move("R0910-00-FETCH", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -354- MOVE '0910' TO WNR-EXEC-SQL */
            _.Move("0910", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -357- PERFORM R0910_00_FETCH_DB_FETCH_1 */

            R0910_00_FETCH_DB_FETCH_1();

            /*" -360- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -361- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -362- MOVE 'SIM' TO WFIM-CURSOR */
                    _.Move("SIM", FILLER_0.WFIM_CURSOR);

                    /*" -362- PERFORM R0910_00_FETCH_DB_CLOSE_1 */

                    R0910_00_FETCH_DB_CLOSE_1();

                    /*" -364- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -365- ELSE */
                }
                else
                {


                    /*" -366- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -367- END-IF */
                }


                /*" -369- END-IF */
            }


            /*" -372- ADD 1 TO AC-LIDOS AC-LIDOS-M */
            FILLER_0.AC_LIDOS.Value = FILLER_0.AC_LIDOS + 1;
            FILLER_0.AC_LIDOS_M.Value = FILLER_0.AC_LIDOS_M + 1;

            /*" -374- IF AC-LIDOS GREATER 999 */

            if (FILLER_0.AC_LIDOS > 999)
            {

                /*" -375- MOVE ZEROS TO AC-LIDOS */
                _.Move(0, FILLER_0.AC_LIDOS);

                /*" -376- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -377- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS-M ' ' WS-TIME */

                $"LIDOS MOVIMENTO   {FILLER_0.AC_LIDOS_M} {FILLER_0.WS_TIME}"
                .Display();

                /*" -379- END-IF */
            }


            /*" -382- IF PROPOVA-DATA-QUITACAO > SISTEMAS-DATA-MOV-ABERTO-3 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO > SISTEMAS_DATA_MOV_ABERTO_3)
            {

                /*" -383- ADD 1 TO AC-DESPR */
                FILLER_0.AC_DESPR.Value = FILLER_0.AC_DESPR + 1;

                /*" -384- GO TO R0910-00-FETCH */
                new Task(() => R0910_00_FETCH_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -386- END-IF */
            }


            /*" -389- MOVE PROPOVA-NUM-CERTIFICADO TO W-NUM-PROPOSTA */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, FILLER_0.W_NUM_PROPOSTA);

            /*" -389- . */

        }

        [StopWatch]
        /*" R0910-00-FETCH-DB-FETCH-1 */
        public void R0910_00_FETCH_DB_FETCH_1()
        {
            /*" -357- EXEC SQL FETCH CCURSOR INTO :PROPOVA-NUM-CERTIFICADO , :PROPOVA-DATA-QUITACAO END-EXEC */

            if (CCURSOR.Fetch())
            {
                _.Move(CCURSOR.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CCURSOR.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-DB-CLOSE-1 */
        public void R0910_00_FETCH_DB_CLOSE_1()
        {
            /*" -362- EXEC SQL CLOSE CCURSOR END-EXEC */

            CCURSOR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CGCCPF-SECTION */
        private void R1000_00_PROCESSA_CGCCPF_SECTION()
        {
            /*" -402- MOVE 'R1000-00-PROCESSA-CGCCPF  ' TO PARAGRAFO. */
            _.Move("R1000-00-PROCESSA-CGCCPF  ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -406- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -408- MOVE 'N' TO WHOST-IND-PROP-ELETRONICA */
            _.Move("N", WHOST_IND_PROP_ELETRONICA);

            /*" -411- PERFORM R1150-00-LE-PROPOSTA-FIDELIZ */

            R1150_00_LE_PROPOSTA_FIDELIZ_SECTION();

            /*" -413- PERFORM R1110-00-COUNT-VGCRITICA */

            R1110_00_COUNT_VGCRITICA_SECTION();

            /*" -425- PERFORM R1120-00-SELECT-HISCOBPR */

            R1120_00_SELECT_HISCOBPR_SECTION();

            /*" -426- IF WHOST-COUNT = 0 */

            if (WHOST_COUNT == 0)
            {

                /*" -428- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1009 OR 1010 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("1009", "1010"))
                {

                    /*" -429- MOVE '7' TO PROPOVA-SIT-REGISTRO */
                    _.Move("7", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                    /*" -430- ELSE */
                }
                else
                {


                    /*" -431- IF WHOST-IND-PROP-ELETRONICA = 'S' */

                    if (WHOST_IND_PROP_ELETRONICA == "S")
                    {

                        /*" -432- MOVE '0' TO PROPOVA-SIT-REGISTRO */
                        _.Move("0", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                        /*" -433- PERFORM R1200-00-DELETE-ERRPROVI-1876 */

                        R1200_00_DELETE_ERRPROVI_1876_SECTION();

                        /*" -434- ELSE */
                    }
                    else
                    {


                        /*" -435- IF HISCOBPR-IMP-MORNATU LESS 200000,00 */

                        if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU < 200000.00)
                        {

                            /*" -436- MOVE '0' TO PROPOVA-SIT-REGISTRO */
                            _.Move("0", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                            /*" -437- ELSE */
                        }
                        else
                        {


                            /*" -438- MOVE '9' TO PROPOVA-SIT-REGISTRO */
                            _.Move("9", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                            /*" -439- END-IF */
                        }


                        /*" -440- END-IF */
                    }


                    /*" -441- END-IF */
                }


                /*" -442- ELSE */
            }
            else
            {


                /*" -443- MOVE '9' TO PROPOVA-SIT-REGISTRO */
                _.Move("9", PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);

                /*" -487- END-IF. */
            }


            /*" -489- PERFORM R2000-00-UPDATE-PROPOVA */

            R2000_00_UPDATE_PROPOVA_SECTION();

            /*" -489- PERFORM R0910-00-FETCH. */

            R0910_00_FETCH_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-COUNT-VGCRITICA-SECTION */
        private void R1110_00_COUNT_VGCRITICA_SECTION()
        {
            /*" -579- MOVE 'R1110-00-COUNT-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R1110-00-COUNT-VGCRITICA  ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -599- MOVE '1110' TO WNR-EXEC-SQL */
            _.Move("1110", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -601- MOVE ZEROS TO WHOST-COUNT */
            _.Move(0, WHOST_COUNT);

            /*" -609- IF PROPOFID-IND-TP-PROPOSTA EQUAL 'C' OR 'D' OR 'E' OR 'S' OR 'V' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA.In("C", "D", "E", "S", "V"))
            {

                /*" -611- MOVE 'S' TO WHOST-IND-PROP-ELETRONICA */
                _.Move("S", WHOST_IND_PROP_ELETRONICA);

                /*" -622- PERFORM R1110_00_COUNT_VGCRITICA_DB_SELECT_1 */

                R1110_00_COUNT_VGCRITICA_DB_SELECT_1();

                /*" -624- ELSE */
            }
            else
            {


                /*" -635- PERFORM R1110_00_COUNT_VGCRITICA_DB_SELECT_2 */

                R1110_00_COUNT_VGCRITICA_DB_SELECT_2();

                /*" -638- END-IF. */
            }


            /*" -639- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -640- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -641- MOVE ZEROS TO WHOST-COUNT */
                    _.Move(0, WHOST_COUNT);

                    /*" -642- ELSE */
                }
                else
                {


                    /*" -643- DISPLAY 'FALHA NA CONSULTA TABELA VG_CRITICA_PROPOSTA' */
                    _.Display($"FALHA NA CONSULTA TABELA VG_CRITICA_PROPOSTA");

                    /*" -644- DISPLAY ' - NUM_CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($" - NUM_CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -645- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -646- END-IF */
                }


                /*" -647- END-IF */
            }


            /*" -647- . */

        }

        [StopWatch]
        /*" R1110-00-COUNT-VGCRITICA-DB-SELECT-1 */
        public void R1110_00_COUNT_VGCRITICA_DB_SELECT_1()
        {
            /*" -622- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.COD_MSG_CRITICA NOT IN (1800, 1876) AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' WITH UR END-EXEC */

            var r1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1 = new R1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1.Execute(r1110_00_COUNT_VGCRITICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-COUNT-VGCRITICA-DB-SELECT-2 */
        public void R1110_00_COUNT_VGCRITICA_DB_SELECT_2()
        {
            /*" -635- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.COD_MSG_CRITICA <> 1800 AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' WITH UR END-EXEC */

            var r1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1 = new R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1.Execute(r1110_00_COUNT_VGCRITICA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R1120-00-SELECT-HISCOBPR-SECTION */
        private void R1120_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -685- MOVE 'R1120-00-SELECT-HISCOBPR  ' TO PARAGRAFO. */
            _.Move("R1120-00-SELECT-HISCOBPR  ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -689- MOVE '1120' TO WNR-EXEC-SQL */
            _.Move("1120", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -695- PERFORM R1120_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1120_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -698- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -699- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -699- END-IF. */
            }


        }

        [StopWatch]
        /*" R1120-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1120_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -695- EXEC SQL SELECT IMP_MORNATU INTO :HISCOBPR-IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1120_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-LE-PROPOSTA-FIDELIZ-SECTION */
        private void R1150_00_LE_PROPOSTA_FIDELIZ_SECTION()
        {
            /*" -713- MOVE 'R1150-00-LE-PROPOSTA-FIDELIZ' TO PARAGRAFO. */
            _.Move("R1150-00-LE-PROPOSTA-FIDELIZ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -715- MOVE '1150' TO WNR-EXEC-SQL */
            _.Move("1150", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -722- PERFORM R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1 */

            R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1();

            /*" -725- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -726- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -727- ELSE */
            }
            else
            {


                /*" -728- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -729- MOVE ' ' TO PROPOFID-IND-TP-PROPOSTA */
                    _.Move(" ", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);

                    /*" -730- END-IF */
                }


                /*" -731- END-IF. */
            }


        }

        [StopWatch]
        /*" R1150-00-LE-PROPOSTA-FIDELIZ-DB-SELECT-1 */
        public void R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1()
        {
            /*" -722- EXEC SQL SELECT IFNULL(IND_TP_PROPOSTA, ' ' ) , ORIGEM_PROPOSTA INTO :PROPOFID-IND-TP-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1 = new R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1.Execute(r1150_00_LE_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_IND_TP_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TP_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-DELETE-ERRPROVI-1876-SECTION */
        private void R1200_00_DELETE_ERRPROVI_1876_SECTION()
        {
            /*" -744- MOVE 'R1200-00-DELETE-ERRPROVI-1876' TO PARAGRAFO. */
            _.Move("R1200-00-DELETE-ERRPROVI-1876", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -746- MOVE '1200' TO WNR-EXEC-SQL */
            _.Move("1200", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -748- MOVE 1876 TO COD-ERRO */
            _.Move(1876, ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO);

            /*" -761- PERFORM R2250-00-CONSULTA-VGCRITICA */

            R2250_00_CONSULTA_VGCRITICA_SECTION();

            /*" -763- MOVE '1201' TO WNR-EXEC-SQL */
            _.Move("1201", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -768- PERFORM R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1 */

            R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1();

            /*" -771- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -772- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -773- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-DELETE-ERRPROVI-1876-DB-DELETE-1 */
        public void R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1()
        {
            /*" -768- EXEC SQL DELETE FROM SEGUROS.VG_ANDAMENTO_PROP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_USUARIO = 'VA0055B' END-EXEC. */

            var r1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1 = new R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1.Execute(r1200_00_DELETE_ERRPROVI_1876_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-PROPOVA-SECTION */
        private void R2000_00_UPDATE_PROPOVA_SECTION()
        {
            /*" -785- MOVE 'R2000-00-UPDATE-PROPOVA   ' TO PARAGRAFO. */
            _.Move("R2000-00-UPDATE-PROPOVA   ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -790- MOVE '2000' TO WNR-EXEC-SQL */
            _.Move("2000", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -791- IF PROPOVA-SIT-REGISTRO EQUAL '0' OR '7' OR '9' */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.In("0", "7", "9"))
            {

                /*" -792- CONTINUE */

                /*" -793- ELSE */
            }
            else
            {


                /*" -794- DISPLAY 'VA0056B - PROPOVA-SIT-REGISTRO INVALIDO' */
                _.Display($"VA0056B - PROPOVA-SIT-REGISTRO INVALIDO");

                /*" -795- DISPLAY '          CANAL VENDA NAO PREVISTO' */
                _.Display($"          CANAL VENDA NAO PREVISTO");

                /*" -797- DISPLAY '          PROPOSTA = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"          PROPOSTA = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -798- MOVE ZEROS TO SQLCODE */
                _.Move(0, DB.SQLCODE);

                /*" -799- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -801- END-IF. */
            }


            /*" -807- PERFORM R2000_00_UPDATE_PROPOVA_DB_UPDATE_1 */

            R2000_00_UPDATE_PROPOVA_DB_UPDATE_1();

            /*" -810- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -811- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -813- END-IF. */
            }


            /*" -813- ADD 1 TO AC-U-PROPOVA. */
            FILLER_0.AC_U_PROPOVA.Value = FILLER_0.AC_U_PROPOVA + 1;

        }

        [StopWatch]
        /*" R2000-00-UPDATE-PROPOVA-DB-UPDATE-1 */
        public void R2000_00_UPDATE_PROPOVA_DB_UPDATE_1()
        {
            /*" -807- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = :PROPOVA-SIT-REGISTRO ,COD_USUARIO = 'VA0056B' ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1()
            {
                PROPOVA_SIT_REGISTRO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-CONSULTA-VGCRITICA-SECTION */
        private void R2250_00_CONSULTA_VGCRITICA_SECTION()
        {
            /*" -826- MOVE 'R2250-00-CONSULTA-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R2250-00-CONSULTA-VGCRITICA  ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -828- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -829- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -830- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -831- MOVE PROPOVA-NUM-CERTIFICADO TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -832- MOVE COD-ERRO TO LK-VG001-COD-MSG-CRITICA */
            _.Move(ERPROPAZ.DCLERROS_PROP_VIDAZUL.COD_ERRO, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -833- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -834- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -835- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -836- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -837- MOVE 'VA0055B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0055B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -838- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -840- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -842- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -843- IF LK-VG001-IND-ERRO = 0 */

            if (SPVG001W.LK_VG001_IND_ERRO == 0)
            {

                /*" -844- IF LK-VG001-S-NUM-CERTIFICADO > 0 */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 0)
                {

                    /*" -845- PERFORM R2300-00-DELETE-VGCRITICA */

                    R2300_00_DELETE_VGCRITICA_SECTION();

                    /*" -846- END-IF */
                }


                /*" -847- ELSE */
            }
            else
            {


                /*" -848- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -849- DISPLAY '* R2200 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2200 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -850- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -851- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -852- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -853- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -854- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -855- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -856- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -858- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -859- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -860- END-IF */
            }


            /*" -860- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-DELETE-VGCRITICA-SECTION */
        private void R2300_00_DELETE_VGCRITICA_SECTION()
        {
            /*" -872- MOVE 'R2300-00-DELETE-VGCRITICA  ' TO PARAGRAFO. */
            _.Move("R2300-00-DELETE-VGCRITICA  ", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -873- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -874- MOVE 03 TO LK-VG001-TIPO-ACAO */
            _.Move(03, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -875- MOVE LK-VG001-S-SEQ-CRITICA TO LK-VG001-SEQ-CRITICA */
            _.Move(SPVG001W.LK_VG001_S_SEQ_CRITICA, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -876- MOVE 'PF' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("PF", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -877- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -878- MOVE 'VA0056B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("VA0056B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -879- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -880- MOVE 'B' TO LK-VG001-STA-CRITICA */
            _.Move("B", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -881- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -884- MOVE 'EXCLUSAO LOGICA DE ERRO DA PROPOSTA ' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EXCLUSAO LOGICA DE ERRO DA PROPOSTA ", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -886- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -887- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -888- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -889- DISPLAY '* R2300 -  PROBLEMAS CALL SUBROTINA SPBVG001  *' */
                _.Display($"* R2300 -  PROBLEMAS CALL SUBROTINA SPBVG001  *");

                /*" -890- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -891- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -892- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -893- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -894- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -895- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -896- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -898- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -899- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -900- END-IF */
            }


            /*" -900- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -911- MOVE 'R9000-00-FINALIZA' TO PARAGRAFO. */
            _.Move("R9000-00-FINALIZA", FILLER_0.CANAL.WABEND.PARAGRAFO);

            /*" -915- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", FILLER_0.CANAL.WABEND.WNR_EXEC_SQL);

            /*" -916- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -917- DISPLAY 'PROGRAMA VA0056B ' */
            _.Display($"PROGRAMA VA0056B ");

            /*" -918- DISPLAY 'TOTAIS PARA CONTROLE ' */
            _.Display($"TOTAIS PARA CONTROLE ");

            /*" -919- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -920- DISPLAY 'LIDOS PROPOSTA_VA                   = ' AC-LIDOS-M */
            _.Display($"LIDOS PROPOSTA_VA                   = {FILLER_0.AC_LIDOS_M}");

            /*" -921- DISPLAY 'PROPOSTAS A MENOS 3DIAS             = ' AC-DESPR */
            _.Display($"PROPOSTAS A MENOS 3DIAS             = {FILLER_0.AC_DESPR}");

            /*" -922- DISPLAY 'ALTERADOS PROPOSTA_VA               = ' AC-U-PROPOVA */
            _.Display($"ALTERADOS PROPOSTA_VA               = {FILLER_0.AC_U_PROPOVA}");

            /*" -923- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -924- DISPLAY ' ' */
            _.Display($" ");

            /*" -925- IF RETURN-CODE EQUAL ZEROS */

            if (RETURN_CODE == 00)
            {

                /*" -926- DISPLAY ' *** VA0056B - FIM NORMAL ' */
                _.Display($" *** VA0056B - FIM NORMAL ");

                /*" -927- ELSE */
            }
            else
            {


                /*" -928- DISPLAY ' *** VA0056B - FIM ANORMAL ' */
                _.Display($" *** VA0056B - FIM ANORMAL ");

                /*" -930- END-IF. */
            }


            /*" -930- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -932- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -946- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -947- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.CANAL.WABEND.WSQLCODE);

                /*" -948- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.CANAL.WABEND.WSQLCODE1);

                /*" -949- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.CANAL.WABEND.WSQLCODE2);

                /*" -950- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -951- DISPLAY WABEND */
                _.Display(FILLER_0.CANAL.WABEND);

                /*" -952- MOVE SQLERRMC TO WSQLERRMC */
                _.Move(DB.SQLERRMC, FILLER_0.CANAL.WSQLERRO.WSQLERRMC);

                /*" -953- DISPLAY WSQLERRO */
                _.Display(FILLER_0.CANAL.WSQLERRO);

                /*" -954- DISPLAY SPACES */
                _.Display($"");

                /*" -955- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), FILLER_0.WS_TIME);

                /*" -957- DISPLAY 'LIDOS MOVIMENTO   ' AC-LIDOS ' ' WS-TIME. */

                $"LIDOS MOVIMENTO   {FILLER_0.AC_LIDOS} {FILLER_0.WS_TIME}"
                .Display();
            }


            /*" -959- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -963- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -967- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -967- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}