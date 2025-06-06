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
using Sias.PessoaFisica.DB2.PF0771B;

namespace Code
{
    public class PF0771B
    {
        public bool IsCall { get; set; }

        public PF0771B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ PF                                  *      */
        /*"      *   PROGRAMA ............... PF0771B                             *      */
        /*"      *   ANALISE................. LUIZ CARLOS / LUCIA VIEIRA          *      */
        /*"      *   FUNCAO ................. GERAR NUMERO DE PROPOSTAS AO SIGPF  *      */
        /*"      *                            IMPEDINDO DUPLICIDADE               *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO: 23/06/2008        SSI 22137                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.02   - RETIRA E MELHORA DISPLAYS               SSI 22137     *      */
        /*"      *        - NAO TRATAR  PROPOSTAS QUE JA ESTAO NO SIGPF           *      */
        /*"      *        11/08/2008   LUCIA VIEIRA    PROCURAR POR V.02          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.01   PASSA A SELECIONAR  A  ORIGEM_PROPOSTA                  *      */
        /*"      *                                                                *      */
        /*"      *        01/07/2008   LUCIA VIEIRA    PROCURAR POR V.01          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_0711_ENTR { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis ARQ_0711_ENTR
        {
            get
            {
                _.Move(REG_0711_ENTR, _ARQ_0711_ENTR); VarBasis.RedefinePassValue(REG_0711_ENTR, _ARQ_0711_ENTR, REG_0711_ENTR); return _ARQ_0711_ENTR;
            }
        }
        public FileBasis _ARQ_0711_SAIDA { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis ARQ_0711_SAIDA
        {
            get
            {
                _.Move(REG_0711_SAIDA, _ARQ_0711_SAIDA); VarBasis.RedefinePassValue(REG_0711_SAIDA, _ARQ_0711_SAIDA, REG_0711_SAIDA); return _ARQ_0711_SAIDA;
            }
        }
        /*"01   REG-0711-ENTR.*/
        public PF0771B_REG_0711_ENTR REG_0711_ENTR { get; set; } = new PF0771B_REG_0711_ENTR();
        public class PF0771B_REG_0711_ENTR : VarBasis
        {
            /*"  03 TP-REG-0711                   PIC X(0001).*/
            public StringBasis TP_REG_0711 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"  03 PROPOSTA-0711                 PIC 9(0014).*/
            public IntBasis PROPOSTA_0711 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
            /*"  03 FILLER                        PIC X(0085).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "85", "X(0085)."), @"");
            /*"01   REG-0711-SAIDA.*/
        }
        public PF0771B_REG_0711_SAIDA REG_0711_SAIDA { get; set; } = new PF0771B_REG_0711_SAIDA();
        public class PF0771B_REG_0711_SAIDA : VarBasis
        {
            /*"  03 FILLER                        PIC X(0001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"  03 PROPOSTA-0711-ALT             PIC X(0014).*/
            public StringBasis PROPOSTA_0711_ALT { get; set; } = new StringBasis(new PIC("X", "14", "X(0014)."), @"");
            /*"  03 FILLER                        PIC X(0085).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "85", "X(0085)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  AC-0711-LIDO                   PIC 9(007)      VALUE ZEROS.*/
        public IntBasis AC_0711_LIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  AC-0711-GRAV                   PIC 9(007)      VALUE ZEROS.*/
        public IntBasis AC_0711_GRAV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  WS-FIM-0711                    PIC X(001)      VALUE 'N'.*/
        public StringBasis WS_FIM_0711 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-PROPOSTA                    PIC 9(014)      VALUE ZEROS.*/
        public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"01  NUM-PROPOSTA-WS                 PIC 9(14).*/
        public IntBasis NUM_PROPOSTA_WS { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
        /*"01  FILLER REDEFINES   NUM-PROPOSTA-WS.*/
        private _REDEF_PF0771B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_PF0771B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_PF0771B_FILLER_3(); _.Move(NUM_PROPOSTA_WS, _filler_3); VarBasis.RedefinePassValue(NUM_PROPOSTA_WS, _filler_3, NUM_PROPOSTA_WS); _filler_3.ValueChanged += () => { _.Move(_filler_3, NUM_PROPOSTA_WS); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, NUM_PROPOSTA_WS); }
        }  //Redefines
        public class _REDEF_PF0771B_FILLER_3 : VarBasis
        {
            /*"    05  POSICAO-1                   PIC 9(01).*/
            public IntBasis POSICAO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05  NUM-PROP-WS                 PIC 9(13).*/
            public IntBasis NUM_PROP_WS { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"01   NUM-PROPOSTA-WS-ALT            PIC 9(14).*/

            public _REDEF_PF0771B_FILLER_3()
            {
                POSICAO_1.ValueChanged += OnValueChanged;
                NUM_PROP_WS.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis NUM_PROPOSTA_WS_ALT { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
        /*"01  FILLER REDEFINES   NUM-PROPOSTA-WS-ALT.*/
        private _REDEF_PF0771B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_PF0771B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_PF0771B_FILLER_4(); _.Move(NUM_PROPOSTA_WS_ALT, _filler_4); VarBasis.RedefinePassValue(NUM_PROPOSTA_WS_ALT, _filler_4, NUM_PROPOSTA_WS_ALT); _filler_4.ValueChanged += () => { _.Move(_filler_4, NUM_PROPOSTA_WS_ALT); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, NUM_PROPOSTA_WS_ALT); }
        }  //Redefines
        public class _REDEF_PF0771B_FILLER_4 : VarBasis
        {
            /*"    05  NUM-PROP-WS-ALT             PIC 9(13).*/
            public IntBasis NUM_PROP_WS_ALT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05  DV-PROP-WS-ALT              PIC 9(01).*/
            public IntBasis DV_PROP_WS_ALT { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));

            public _REDEF_PF0771B_FILLER_4()
            {
                NUM_PROP_WS_ALT.ValueChanged += OnValueChanged;
                DV_PROP_WS_ALT.ValueChanged += OnValueChanged;
            }

        }


        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQ_0711_ENTR_FILE_NAME_P, string ARQ_0711_SAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQ_0711_ENTR.SetFile(ARQ_0711_ENTR_FILE_NAME_P);
                ARQ_0711_SAIDA.SetFile(ARQ_0711_SAIDA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-00-INICIO */

                M_0000_00_INICIO();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-00-INICIO */
        private void M_0000_00_INICIO(bool isPerform = false)
        {
            /*" -97- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -98- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -99- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -105- PERFORM 0110-00-ABRE-ARQVS-0711. */

            M_0110_00_ABRE_ARQVS_0711_SECTION();

            /*" -106- PERFORM 0160-00-LE-0711. */

            M_0160_00_LE_0711_SECTION();

            /*" -107- IF WS-FIM-0711 EQUAL 'S' */

            if (WS_FIM_0711 == "S")
            {

                /*" -108- DISPLAY '** PF0771B - ARQUIVO ENTRADA VAZIO' */
                _.Display($"** PF0771B - ARQUIVO ENTRADA VAZIO");

                /*" -109- DISPLAY '** NAO HA STATUS A PROCESSAR' */
                _.Display($"** NAO HA STATUS A PROCESSAR");

                /*" -110- GO TO 000-15-PARA-PROCESSO */

                M_000_15_PARA_PROCESSO(); //GOTO
                return;

                /*" -112- END-IF. */
            }


            /*" -113- PERFORM 0210-00-TRATA-0711 UNTIL WS-FIM-0711 EQUAL 'S' . */

            while (!(WS_FIM_0711 == "S"))
            {

                M_0210_00_TRATA_0711_SECTION();
            }

        }

        [StopWatch]
        /*" M-000-15-PARA-PROCESSO */
        private void M_000_15_PARA_PROCESSO(bool isPerform = false)
        {
            /*" -117- PERFORM 0900-00-FINALIZA. */

            M_0900_00_FINALIZA_SECTION();

            /*" -117- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0110-00-ABRE-ARQVS-0711-SECTION */
        private void M_0110_00_ABRE_ARQVS_0711_SECTION()
        {
            /*" -124- OPEN INPUT ARQ-0711-ENTR. */
            ARQ_0711_ENTR.Open(REG_0711_ENTR);

            /*" -124- OPEN OUTPUT ARQ-0711-SAIDA. */
            ARQ_0711_SAIDA.Open(REG_0711_SAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_99_EXIT*/

        [StopWatch]
        /*" M-0160-00-LE-0711-SECTION */
        private void M_0160_00_LE_0711_SECTION()
        {
            /*" -133- READ ARQ-0711-ENTR AT END */
            try
            {
                ARQ_0711_ENTR.Read(() =>
                {

                    /*" -135- MOVE 'S' TO WS-FIM-0711 */
                    _.Move("S", WS_FIM_0711);

                    /*" -137- GO TO 0160-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0160_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ARQ_0711_ENTR.Value, REG_0711_ENTR);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -137- ADD 1 TO AC-0711-LIDO. */
            AC_0711_LIDO.Value = AC_0711_LIDO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0160_99_SAIDA*/

        [StopWatch]
        /*" M-0210-00-TRATA-0711-SECTION */
        private void M_0210_00_TRATA_0711_SECTION()
        {
            /*" -147- IF TP-REG-0711 EQUAL 'H' OR TP-REG-0711 EQUAL 'T' */

            if (REG_0711_ENTR.TP_REG_0711 == "H" || REG_0711_ENTR.TP_REG_0711 == "T")
            {

                /*" -148- MOVE REG-0711-ENTR TO REG-0711-SAIDA */
                _.Move(ARQ_0711_ENTR?.Value, REG_0711_SAIDA);

                /*" -149- GO TO 0210-10-GRAVA-0711 */

                M_0210_10_GRAVA_0711(); //GOTO
                return;

                /*" -151- END-IF. */
            }


            /*" -152- MOVE PROPOSTA-0711 TO WS-PROPOSTA. */
            _.Move(REG_0711_ENTR.PROPOSTA_0711, WS_PROPOSTA);

            /*" -154- PERFORM 0300-00-TESTA-NUM-PROPOSTA. */

            M_0300_00_TESTA_NUM_PROPOSTA_SECTION();

            /*" -155- MOVE REG-0711-ENTR TO REG-0711-SAIDA. */
            _.Move(ARQ_0711_ENTR?.Value, REG_0711_SAIDA);

            /*" -155- MOVE WS-PROPOSTA TO PROPOSTA-0711-ALT. */
            _.Move(WS_PROPOSTA, REG_0711_SAIDA.PROPOSTA_0711_ALT);

            /*" -0- FLUXCONTROL_PERFORM M_0210_10_GRAVA_0711 */

            M_0210_10_GRAVA_0711();

        }

        [StopWatch]
        /*" M-0210-10-GRAVA-0711 */
        private void M_0210_10_GRAVA_0711(bool isPerform = false)
        {
            /*" -159- WRITE REG-0711-SAIDA. */
            ARQ_0711_SAIDA.Write(REG_0711_SAIDA.GetMoveValues().ToString());

            /*" -161- ADD 1 TO AC-0711-GRAV. */
            AC_0711_GRAV.Value = AC_0711_GRAV + 1;

            /*" -161- PERFORM 0160-00-LE-0711. */

            M_0160_00_LE_0711_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0210_99_SAIDA*/

        [StopWatch]
        /*" M-0300-00-TESTA-NUM-PROPOSTA-SECTION */
        private void M_0300_00_TESTA_NUM_PROPOSTA_SECTION()
        {
            /*" -175- IF WS-PROPOSTA EQUAL 00010021049266 OR EQUAL 00010021092182 OR EQUAL 00010021273040 OR EQUAL 00010021287629 OR EQUAL 00010021359265 OR EQUAL 00010021362448 */

            if (WS_PROPOSTA.In("00010021049266", "00010021092182", "00010021273040", "00010021287629", "00010021359265", "00010021362448"))
            {

                /*" -176- GO TO 0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/ //GOTO
                return;

                /*" -178- END-IF. */
            }


            /*" -180- MOVE WS-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(WS_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -186- PERFORM M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1 */

            M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1();

            /*" -191- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -192- GO TO 0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/ //GOTO
                return;

                /*" -195- END-IF. */
            }


            /*" -196- IF PROPOFID-ORIGEM-PROPOSTA NOT EQUAL 6 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 6)
            {

                /*" -197- GO TO 0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/ //GOTO
                return;

                /*" -199- END-IF. */
            }


            /*" -203- IF (WS-PROPOSTA NOT LESS 100000000000 AND NOT GREATER 199999999999 ) OR ( WS-PROPOSTA NOT LESS 10000000000 AND NOT GREATER 19999999999) */

            if ((WS_PROPOSTA >= 100000000000 && WS_PROPOSTA <= 199999999999) || (WS_PROPOSTA >= 10000000000 && WS_PROPOSTA <= 19999999999))
            {

                /*" -204- MOVE WS-PROPOSTA TO NUM-PROPOSTA-WS */
                _.Move(WS_PROPOSTA, NUM_PROPOSTA_WS);

                /*" -205- MOVE NUM-PROP-WS TO NUM-PROP-WS-ALT */
                _.Move(FILLER_3.NUM_PROP_WS, FILLER_4.NUM_PROP_WS_ALT);

                /*" -208- MOVE ZERO TO DV-PROP-WS-ALT */
                _.Move(0, FILLER_4.DV_PROP_WS_ALT);

                /*" -209- MOVE NUM-PROPOSTA-WS-ALT TO WS-PROPOSTA */
                _.Move(NUM_PROPOSTA_WS_ALT, WS_PROPOSTA);

                /*" -209- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0300-00-TESTA-NUM-PROPOSTA-DB-SELECT-1 */
        public void M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1()
        {
            /*" -186- EXEC SQL SELECT ORIGEM_PROPOSTA INTO :PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var m_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1 = new M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/

        [StopWatch]
        /*" M-0900-00-FINALIZA-SECTION */
        private void M_0900_00_FINALIZA_SECTION()
        {
            /*" -219- CLOSE ARQ-0711-ENTR ARQ-0711-SAIDA. */
            ARQ_0711_ENTR.Close();
            ARQ_0711_SAIDA.Close();

            /*" -220- DISPLAY ' ' . */
            _.Display($" ");

            /*" -221- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -222- DISPLAY '*  TERMINO NORMAL DO PROGRAMA PF0771B   *' . */
            _.Display($"*  TERMINO NORMAL DO PROGRAMA PF0771B   *");

            /*" -223- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -224- DISPLAY ' ' . */
            _.Display($" ");

            /*" -225- DISPLAY 'REG. LIDOS    0711      = ' AC-0711-LIDO. */
            _.Display($"REG. LIDOS    0711      = {AC_0711_LIDO}");

            /*" -225- DISPLAY 'REG. GRAVADOS 0711      = ' AC-0711-GRAV. */
            _.Display($"REG. GRAVADOS 0711      = {AC_0711_GRAV}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -236- DISPLAY ' ' . */
            _.Display($" ");

            /*" -237- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -238- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA PF0771B  *' . */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA PF0771B  *");

            /*" -239- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -240- DISPLAY ' ' . */
            _.Display($" ");

            /*" -241- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -241- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}