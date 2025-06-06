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
using Sias.PessoaFisica.DB2.PF0770B;

namespace Code
{
    public class PF0770B
    {
        public bool IsCall { get; set; }

        public PF0770B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ PF                                  *      */
        /*"      *   PROGRAMA ............... PF0770B                             *      */
        /*"      *   ANALISE................. LUIZ CARLOS / LUCIA VIEIRA          *      */
        /*"      *   FUNCAO ................. GERAR NUMERO DE PROPOSTAS AO SIGPF  *      */
        /*"      *                            IMPEDINDO DUPLICIDADE               *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO: 23/06/2008      SSI 22137                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.02   - RETIRA E MELHORA DISPLAYS               SSI 22137     *      */
        /*"      *        - NAO TRATAR  PROPOSTAS QUE JA ESTAO NO SIGPF           *      */
        /*"      *        11/08/2008   LUCIA VIEIRA    PROCURAR POR V.02          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.01   PASSA A SELECIONAR  A  ORIGEM_PROPOSTA - SSI 22137      *      */
        /*"      *                                                                *      */
        /*"      *        01/07/2008   LUCIA VIEIRA    PROCURAR POR V.01          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_0641_ENTR { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis ARQ_0641_ENTR
        {
            get
            {
                _.Move(REG_0641_ENTR, _ARQ_0641_ENTR); VarBasis.RedefinePassValue(REG_0641_ENTR, _ARQ_0641_ENTR, REG_0641_ENTR); return _ARQ_0641_ENTR;
            }
        }
        public FileBasis _ARQ_0641_SAIDA { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis ARQ_0641_SAIDA
        {
            get
            {
                _.Move(REG_0641_SAIDA, _ARQ_0641_SAIDA); VarBasis.RedefinePassValue(REG_0641_SAIDA, _ARQ_0641_SAIDA, REG_0641_SAIDA); return _ARQ_0641_SAIDA;
            }
        }
        /*"01   REG-0641-ENTR.*/
        public PF0770B_REG_0641_ENTR REG_0641_ENTR { get; set; } = new PF0770B_REG_0641_ENTR();
        public class PF0770B_REG_0641_ENTR : VarBasis
        {
            /*"  03 TP-REG-0641                   PIC X(0001).*/
            public StringBasis TP_REG_0641 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"  03 PROPOSTA-0641                 PIC 9(0014).*/
            public IntBasis PROPOSTA_0641 { get; set; } = new IntBasis(new PIC("9", "14", "9(0014)."));
            /*"  03 FILLER                        PIC X(0285).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "285", "X(0285)."), @"");
            /*"01   REG-0641-SAIDA.*/
        }
        public PF0770B_REG_0641_SAIDA REG_0641_SAIDA { get; set; } = new PF0770B_REG_0641_SAIDA();
        public class PF0770B_REG_0641_SAIDA : VarBasis
        {
            /*"  03 FILLER                        PIC X(0001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(0001)."), @"");
            /*"  03 PROPOSTA-0641-ALT             PIC X(0014).*/
            public StringBasis PROPOSTA_0641_ALT { get; set; } = new StringBasis(new PIC("X", "14", "X(0014)."), @"");
            /*"  03 FILLER                        PIC X(0285).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "285", "X(0285)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  AC-0641-LIDO                   PIC 9(007)      VALUE ZEROS.*/
        public IntBasis AC_0641_LIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  AC-0641-GRAV                   PIC 9(007)      VALUE ZEROS.*/
        public IntBasis AC_0641_GRAV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77  WS-FIM-0641                    PIC X(001)      VALUE 'N'.*/
        public StringBasis WS_FIM_0641 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  WS-PROPOSTA                    PIC 9(014)      VALUE ZEROS.*/
        public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"01  NUM-PROPOSTA-WS                 PIC 9(14).*/
        public IntBasis NUM_PROPOSTA_WS { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
        /*"01  FILLER REDEFINES   NUM-PROPOSTA-WS.*/
        private _REDEF_PF0770B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_PF0770B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_PF0770B_FILLER_3(); _.Move(NUM_PROPOSTA_WS, _filler_3); VarBasis.RedefinePassValue(NUM_PROPOSTA_WS, _filler_3, NUM_PROPOSTA_WS); _filler_3.ValueChanged += () => { _.Move(_filler_3, NUM_PROPOSTA_WS); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, NUM_PROPOSTA_WS); }
        }  //Redefines
        public class _REDEF_PF0770B_FILLER_3 : VarBasis
        {
            /*"    05  POSICAO-1                   PIC 9(01).*/
            public IntBasis POSICAO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05  NUM-PROP-WS                 PIC 9(13).*/
            public IntBasis NUM_PROP_WS { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"01   NUM-PROPOSTA-WS-ALT            PIC 9(14).*/

            public _REDEF_PF0770B_FILLER_3()
            {
                POSICAO_1.ValueChanged += OnValueChanged;
                NUM_PROP_WS.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis NUM_PROPOSTA_WS_ALT { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
        /*"01  FILLER REDEFINES   NUM-PROPOSTA-WS-ALT.*/
        private _REDEF_PF0770B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_PF0770B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_PF0770B_FILLER_4(); _.Move(NUM_PROPOSTA_WS_ALT, _filler_4); VarBasis.RedefinePassValue(NUM_PROPOSTA_WS_ALT, _filler_4, NUM_PROPOSTA_WS_ALT); _filler_4.ValueChanged += () => { _.Move(_filler_4, NUM_PROPOSTA_WS_ALT); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, NUM_PROPOSTA_WS_ALT); }
        }  //Redefines
        public class _REDEF_PF0770B_FILLER_4 : VarBasis
        {
            /*"    05  NUM-PROP-WS-ALT             PIC 9(13).*/
            public IntBasis NUM_PROP_WS_ALT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05  DV-PROP-WS-ALT              PIC 9(01).*/
            public IntBasis DV_PROP_WS_ALT { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));

            public _REDEF_PF0770B_FILLER_4()
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
        public dynamic Execute(string ARQ_0641_ENTR_FILE_NAME_P, string ARQ_0641_SAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQ_0641_ENTR.SetFile(ARQ_0641_ENTR_FILE_NAME_P);
                ARQ_0641_SAIDA.SetFile(ARQ_0641_SAIDA_FILE_NAME_P);

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
            /*" -100- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -101- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -102- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -108- PERFORM 0100-00-ABRE-ARQVS-0641. */

            M_0100_00_ABRE_ARQVS_0641_SECTION();

            /*" -109- PERFORM 0150-00-LE-0641. */

            M_0150_00_LE_0641_SECTION();

            /*" -110- IF WS-FIM-0641 EQUAL 'S' */

            if (WS_FIM_0641 == "S")
            {

                /*" -111- DISPLAY '** PF0770B - ARQUIVO ENTRADA VAZIO' */
                _.Display($"** PF0770B - ARQUIVO ENTRADA VAZIO");

                /*" -112- DISPLAY '** NAO HA PROPOSTAS A PROCESSAR' */
                _.Display($"** NAO HA PROPOSTAS A PROCESSAR");

                /*" -113- GO TO 0000-10-SEGUE */

                M_0000_10_SEGUE(); //GOTO
                return;

                /*" -115- END-IF. */
            }


            /*" -116- PERFORM 0200-00-TRATA-0641 UNTIL WS-FIM-0641 EQUAL 'S' . */

            while (!(WS_FIM_0641 == "S"))
            {

                M_0200_00_TRATA_0641_SECTION();
            }

        }

        [StopWatch]
        /*" M-0000-10-SEGUE */
        private void M_0000_10_SEGUE(bool isPerform = false)
        {
            /*" -120- CLOSE ARQ-0641-ENTR ARQ-0641-SAIDA. */
            ARQ_0641_ENTR.Close();
            ARQ_0641_SAIDA.Close();

        }

        [StopWatch]
        /*" M-000-15-PARA-PROCESSO */
        private void M_000_15_PARA_PROCESSO(bool isPerform = false)
        {
            /*" -125- PERFORM 0900-00-FINALIZA. */

            M_0900_00_FINALIZA_SECTION();

            /*" -125- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0100-00-ABRE-ARQVS-0641-SECTION */
        private void M_0100_00_ABRE_ARQVS_0641_SECTION()
        {
            /*" -131- OPEN INPUT ARQ-0641-ENTR. */
            ARQ_0641_ENTR.Open(REG_0641_ENTR);

            /*" -131- OPEN OUTPUT ARQ-0641-SAIDA. */
            ARQ_0641_SAIDA.Open(REG_0641_SAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_99_EXIT*/

        [StopWatch]
        /*" M-0150-00-LE-0641-SECTION */
        private void M_0150_00_LE_0641_SECTION()
        {
            /*" -140- READ ARQ-0641-ENTR AT END */
            try
            {
                ARQ_0641_ENTR.Read(() =>
                {

                    /*" -142- MOVE 'S' TO WS-FIM-0641 */
                    _.Move("S", WS_FIM_0641);

                    /*" -144- GO TO 0150-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0150_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ARQ_0641_ENTR.Value, REG_0641_ENTR);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -144- ADD 1 TO AC-0641-LIDO. */
            AC_0641_LIDO.Value = AC_0641_LIDO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0150_99_SAIDA*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0160_99_SAIDA*/

        [StopWatch]
        /*" M-0200-00-TRATA-0641-SECTION */
        private void M_0200_00_TRATA_0641_SECTION()
        {
            /*" -155- IF TP-REG-0641 EQUAL 'H' OR TP-REG-0641 EQUAL 'T' */

            if (REG_0641_ENTR.TP_REG_0641 == "H" || REG_0641_ENTR.TP_REG_0641 == "T")
            {

                /*" -156- MOVE REG-0641-ENTR TO REG-0641-SAIDA */
                _.Move(ARQ_0641_ENTR?.Value, REG_0641_SAIDA);

                /*" -157- GO TO 0200-10-GRAVA-0641 */

                M_0200_10_GRAVA_0641(); //GOTO
                return;

                /*" -159- END-IF. */
            }


            /*" -160- MOVE PROPOSTA-0641 TO WS-PROPOSTA. */
            _.Move(REG_0641_ENTR.PROPOSTA_0641, WS_PROPOSTA);

            /*" -162- PERFORM 0300-00-TESTA-NUM-PROPOSTA. */

            M_0300_00_TESTA_NUM_PROPOSTA_SECTION();

            /*" -163- MOVE REG-0641-ENTR TO REG-0641-SAIDA. */
            _.Move(ARQ_0641_ENTR?.Value, REG_0641_SAIDA);

            /*" -163- MOVE WS-PROPOSTA TO PROPOSTA-0641-ALT. */
            _.Move(WS_PROPOSTA, REG_0641_SAIDA.PROPOSTA_0641_ALT);

            /*" -0- FLUXCONTROL_PERFORM M_0200_10_GRAVA_0641 */

            M_0200_10_GRAVA_0641();

        }

        [StopWatch]
        /*" M-0200-10-GRAVA-0641 */
        private void M_0200_10_GRAVA_0641(bool isPerform = false)
        {
            /*" -167- WRITE REG-0641-SAIDA. */
            ARQ_0641_SAIDA.Write(REG_0641_SAIDA.GetMoveValues().ToString());

            /*" -169- ADD 1 TO AC-0641-GRAV. */
            AC_0641_GRAV.Value = AC_0641_GRAV + 1;

            /*" -169- PERFORM 0150-00-LE-0641. */

            M_0150_00_LE_0641_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0200_99_SAIDA*/

        [StopWatch]
        /*" M-0300-00-TESTA-NUM-PROPOSTA-SECTION */
        private void M_0300_00_TESTA_NUM_PROPOSTA_SECTION()
        {
            /*" -184- IF WS-PROPOSTA EQUAL 00010021049266 OR EQUAL 00010021092182 OR EQUAL 00010021273040 OR EQUAL 00010021287629 OR EQUAL 00010021359265 OR EQUAL 00010021362448 */

            if (WS_PROPOSTA.In("00010021049266", "00010021092182", "00010021273040", "00010021287629", "00010021359265", "00010021362448"))
            {

                /*" -185- GO TO 0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/ //GOTO
                return;

                /*" -187- END-IF. */
            }


            /*" -189- MOVE WS-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(WS_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -195- PERFORM M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1 */

            M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1();

            /*" -200- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -201- GO TO 0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/ //GOTO
                return;

                /*" -204- END-IF. */
            }


            /*" -205- IF PROPOFID-ORIGEM-PROPOSTA NOT EQUAL 6 */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA != 6)
            {

                /*" -206- GO TO 0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0300_99_SAIDA*/ //GOTO
                return;

                /*" -208- END-IF. */
            }


            /*" -212- IF (WS-PROPOSTA NOT LESS 100000000000 AND NOT GREATER 199999999999 ) OR ( WS-PROPOSTA NOT LESS 10000000000 AND NOT GREATER 19999999999) */

            if ((WS_PROPOSTA >= 100000000000 && WS_PROPOSTA <= 199999999999) || (WS_PROPOSTA >= 10000000000 && WS_PROPOSTA <= 19999999999))
            {

                /*" -213- MOVE WS-PROPOSTA TO NUM-PROPOSTA-WS */
                _.Move(WS_PROPOSTA, NUM_PROPOSTA_WS);

                /*" -214- MOVE NUM-PROP-WS TO NUM-PROP-WS-ALT */
                _.Move(FILLER_3.NUM_PROP_WS, FILLER_4.NUM_PROP_WS_ALT);

                /*" -217- MOVE ZERO TO DV-PROP-WS-ALT */
                _.Move(0, FILLER_4.DV_PROP_WS_ALT);

                /*" -218- MOVE NUM-PROPOSTA-WS-ALT TO WS-PROPOSTA */
                _.Move(NUM_PROPOSTA_WS_ALT, WS_PROPOSTA);

                /*" -218- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0300-00-TESTA-NUM-PROPOSTA-DB-SELECT-1 */
        public void M_0300_00_TESTA_NUM_PROPOSTA_DB_SELECT_1()
        {
            /*" -195- EXEC SQL SELECT ORIGEM_PROPOSTA INTO :PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

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
            /*" -226- DISPLAY ' ' . */
            _.Display($" ");

            /*" -227- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -228- DISPLAY '*  TERMINO NORMAL DO PROGRAMA PF0770B   *' . */
            _.Display($"*  TERMINO NORMAL DO PROGRAMA PF0770B   *");

            /*" -229- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -230- DISPLAY ' ' . */
            _.Display($" ");

            /*" -231- DISPLAY 'REG. LIDOS    0641      = ' AC-0641-LIDO. */
            _.Display($"REG. LIDOS    0641      = {AC_0641_LIDO}");

            /*" -231- DISPLAY 'REG. GRAVADOS 0641      = ' AC-0641-GRAV. */
            _.Display($"REG. GRAVADOS 0641      = {AC_0641_GRAV}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0900_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -242- DISPLAY ' ' . */
            _.Display($" ");

            /*" -243- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -244- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA PF0770B  *' . */
            _.Display($"*  TERMINO ANORMAL DO PROGRAMA PF0770B  *");

            /*" -245- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' . */
            _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

            /*" -246- DISPLAY ' ' . */
            _.Display($" ");

            /*" -247- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -247- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}