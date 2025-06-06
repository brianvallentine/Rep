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
using Sias.Geral.DB2.GE0510S;

namespace Code
{
    public class GE0510S
    {
        public bool IsCall { get; set; }

        public GE0510S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDA VA E VG                       *      */
        /*"      *   PROGRAMA ...............  GE0510S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  ELIERMES OLIVEIRA                  *      */
        /*"      *   PROGRAMADOR ............  ELIERMES OLIVEIRA                  *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO  2017                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO: SUB-ROTINA QUE RECUPERA A MODALIDADE DE UMA APOLICE, *      */
        /*"      *           SUBGRUPO/CERTIFICADO DOS PRODUTOS DE VIDA VA E VG    *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS VIDA - 154.956                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                   HISTORICO DE ALTERACAO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM DD/MM/AAAA -                                  V.01        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"77   HOST-TIMESTAMP             PIC  X(026) VALUE SPACES.*/
        public StringBasis HOST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77   HOST-SI-DATA-MOV-ABERTO    PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-SI-CURRENT-DATE       PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-DATE          PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-TIME          PIC  X(008) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77   HOST-NUM-IMOVEL            PIC S9(005) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77   WS-COD-PRODUTO             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   HOST-NUM-CEP               PIC S9(008) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"77   HOST-COUNT                 PIC S9(009) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01   AREA-DE-WORK.*/
        public GE0510S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0510S_AREA_DE_WORK();
        public class GE0510S_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE                   PIC 9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05  WS-DATA-AUX                   PIC X(010) VALUE SPACES.*/
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05  WS-NN-TITULO-AUX              PIC 9(018).*/
            public IntBasis WS_NN_TITULO_AUX { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"  05  WS-NN-TITULO-AUX-R  REDEFINES WS-NN-TITULO-AUX.*/
            private _REDEF_GE0510S_WS_NN_TITULO_AUX_R _ws_nn_titulo_aux_r { get; set; }
            public _REDEF_GE0510S_WS_NN_TITULO_AUX_R WS_NN_TITULO_AUX_R
            {
                get { _ws_nn_titulo_aux_r = new _REDEF_GE0510S_WS_NN_TITULO_AUX_R(); _.Move(WS_NN_TITULO_AUX, _ws_nn_titulo_aux_r); VarBasis.RedefinePassValue(WS_NN_TITULO_AUX, _ws_nn_titulo_aux_r, WS_NN_TITULO_AUX); _ws_nn_titulo_aux_r.ValueChanged += () => { _.Move(_ws_nn_titulo_aux_r, WS_NN_TITULO_AUX); }; return _ws_nn_titulo_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_nn_titulo_aux_r, WS_NN_TITULO_AUX); }
            }  //Redefines
            public class _REDEF_GE0510S_WS_NN_TITULO_AUX_R : VarBasis
            {
                /*"       10 FILLER                     PIC 9(002).*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 WS-NUM-TITULO-AUX          PIC 9(015).*/
                public IntBasis WS_NUM_TITULO_AUX { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 FILLER                     PIC 9(001).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WHORA-CURR.*/

                public _REDEF_GE0510S_WS_NN_TITULO_AUX_R()
                {
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_NUM_TITULO_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public GE0510S_WHORA_CURR WHORA_CURR { get; set; } = new GE0510S_WHORA_CURR();
            public class GE0510S_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORAS.*/
            }
            public GE0510S_WHORAS WHORAS { get; set; } = new GE0510S_WHORAS();
            public class GE0510S_WHORAS : VarBasis
            {
                /*"    10       WHORAS-HH         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-MM         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-SS         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-CC         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WMONTA-DATA       PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WMONTA_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05         FILLER            REDEFINES      WMONTA-DATA.*/
            private _REDEF_GE0510S_FILLER_2 _filler_2 { get; set; }
            public _REDEF_GE0510S_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_GE0510S_FILLER_2(); _.Move(WMONTA_DATA, _filler_2); VarBasis.RedefinePassValue(WMONTA_DATA, _filler_2, WMONTA_DATA); _filler_2.ValueChanged += () => { _.Move(_filler_2, WMONTA_DATA); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WMONTA_DATA); }
            }  //Redefines
            public class _REDEF_GE0510S_FILLER_2 : VarBasis
            {
                /*"    10       WDATA-DIA         PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-MES         PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-ANO         PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-EDICAO                 PIC Z.ZZ9.*/

                public _REDEF_GE0510S_FILLER_2()
                {
                    WDATA_DIA.ValueChanged += OnValueChanged;
                    WDATA_MES.ValueChanged += OnValueChanged;
                    WDATA_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "4", "Z.ZZ9."));
            /*"  05  W-EDICAO-QTD             PIC Z.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO_QTD { get; set; } = new IntBasis(new PIC("9", "7", "Z.ZZZ.ZZ9."));
            /*"  05  W-EDICAO-VALOR-1         PIC Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO_VALOR_1 { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"01          WABEND.*/
        }
        public GE0510S_WABEND WABEND { get; set; } = new GE0510S_WABEND();
        public class GE0510S_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' GE0510S'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0510S");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REGISTRO-LINKAGE-GE0510S.*/
        }
        public GE0510S_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new GE0510S_REGISTRO_LINKAGE_GE0510S();
        public class GE0510S_REGISTRO_LINKAGE_GE0510S : VarBasis
        {
            /*"    10 LK-GE510-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    10 LK-GE510-COD-SUBGRUPO      PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE510-COD-MODALIDADE    PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE510_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE510-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE510_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE510-MENSAGEM.*/
            public GE0510S_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new GE0510S_LK_GE510_MENSAGEM();
            public class GE0510S_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0510S_REGISTRO_LINKAGE_GE0510S GE0510S_REGISTRO_LINKAGE_GE0510S_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_GE0510S*/
        {
            try
            {
                this.REGISTRO_LINKAGE_GE0510S = GE0510S_REGISTRO_LINKAGE_GE0510S_P;

                /*" -142- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -143- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -144- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -147- MOVE 0 TO LK-GE510-SQLCODE */
                _.Move(0, REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE);

                /*" -148- MOVE '0' TO LK-GE510-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO);

                /*" -149- MOVE SPACES TO LK-GE510-MSG-RETORNO. */
                _.Move("", REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_MSG_RETORNO);

                /*" -151- MOVE 0 TO LK-GE510-COD-MODALIDADE. */
                _.Move(0, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE);

                /*" -153- IF (LK-GE510-NUM-CERTIFICADO > ZEROS) OR (LK-GE510-NUM-APOLICE > ZEROS) */

                if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO > 00) || (REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE > 00))
                {

                    /*" -154- PERFORM R0020-PROCESSAR-LINKAGE */

                    R0020_PROCESSAR_LINKAGE_SECTION();

                    /*" -156- END-IF. */
                }


                /*" -157- MOVE '0' TO LK-GE510-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO);

                /*" -159- MOVE 'EXECUTADO COM SUCESSO' TO LK-GE510-MSG-RETORNO. */
                _.Move("EXECUTADO COM SUCESSO", REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_MSG_RETORNO);

                /*" -159- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_GE0510S };
            return Result;
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0020-PROCESSAR-LINKAGE-SECTION */
        private void R0020_PROCESSAR_LINKAGE_SECTION()
        {
            /*" -170- IF (LK-GE510-NUM-APOLICE > ZEROS) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE > 00))
            {

                /*" -171- PERFORM R0300-SELECT-PRODUTO */

                R0300_SELECT_PRODUTO_SECTION();

                /*" -172- ELSE */
            }
            else
            {


                /*" -173- PERFORM R0200-SELECT-APOL-PRODUTO */

                R0200_SELECT_APOL_PRODUTO_SECTION();

                /*" -175- END-IF. */
            }


            /*" -176- IF (LK-GE510-NUM-APOLICE > ZEROS) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE > 00))
            {

                /*" -177- PERFORM R0100-SELECT-MODALIDADE */

                R0100_SELECT_MODALIDADE_SECTION();

                /*" -177- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/

        [StopWatch]
        /*" R0100-SELECT-MODALIDADE-SECTION */
        private void R0100_SELECT_MODALIDADE_SECTION()
        {
            /*" -193- PERFORM R0100_SELECT_MODALIDADE_DB_SELECT_1 */

            R0100_SELECT_MODALIDADE_DB_SELECT_1();

            /*" -196- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -198- DISPLAY 'R0100-ERRO SELECT MODALIDADE APOLICES ' LK-GE510-NUM-APOLICE */
                _.Display($"R0100-ERRO SELECT MODALIDADE APOLICES {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -200- MOVE 'GE0510S-R0100 SELECT MODALIDADE APOLICES ' TO LK-GE510-MSG-RETORNO */
                _.Move("GE0510S-R0100 SELECT MODALIDADE APOLICES ", REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_MSG_RETORNO);

                /*" -201- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -201- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-SELECT-MODALIDADE-DB-SELECT-1 */
        public void R0100_SELECT_MODALIDADE_DB_SELECT_1()
        {
            /*" -193- EXEC SQL SELECT COD_MODALIDADE INTO :LK-GE510-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :LK-GE510-NUM-APOLICE WITH UR END-EXEC. */

            var r0100_SELECT_MODALIDADE_DB_SELECT_1_Query1 = new R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1()
            {
                LK_GE510_NUM_APOLICE = REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0100_SELECT_MODALIDADE_DB_SELECT_1_Query1.Execute(r0100_SELECT_MODALIDADE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_GE510_COD_MODALIDADE, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_EXIT*/

        [StopWatch]
        /*" R0200-SELECT-APOL-PRODUTO-SECTION */
        private void R0200_SELECT_APOL_PRODUTO_SECTION()
        {
            /*" -212- MOVE ZEROS TO WS-COD-PRODUTO */
            _.Move(0, WS_COD_PRODUTO);

            /*" -214- MOVE ZEROS TO LK-GE510-NUM-APOLICE */
            _.Move(0, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -222- PERFORM R0200_SELECT_APOL_PRODUTO_DB_SELECT_1 */

            R0200_SELECT_APOL_PRODUTO_DB_SELECT_1();

            /*" -225- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -227- DISPLAY 'R0200-ERRO SELECT APOLICE PROPOSTAS_VA' LK-GE510-NUM-APOLICE */
                _.Display($"R0200-ERRO SELECT APOLICE PROPOSTAS_VA{REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -229- MOVE 'GE0510S-R0200 ERRO SELECT APOLICE PROPOSTAS_VA ' TO LK-GE510-MSG-RETORNO */
                _.Move("GE0510S-R0200 ERRO SELECT APOLICE PROPOSTAS_VA ", REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_MSG_RETORNO);

                /*" -230- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -230- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-SELECT-APOL-PRODUTO-DB-SELECT-1 */
        public void R0200_SELECT_APOL_PRODUTO_DB_SELECT_1()
        {
            /*" -222- EXEC SQL SELECT NUM_APOLICE, COD_PRODUTO INTO :LK-GE510-NUM-APOLICE, :WS-COD-PRODUTO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :LK-GE510-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1 = new R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1()
            {
                LK_GE510_NUM_CERTIFICADO = REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1.Execute(r0200_SELECT_APOL_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LK_GE510_NUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);
                _.Move(executed_1.WS_COD_PRODUTO, WS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_EXIT*/

        [StopWatch]
        /*" R0300-SELECT-PRODUTO-SECTION */
        private void R0300_SELECT_PRODUTO_SECTION()
        {
            /*" -242- MOVE ZEROS TO WS-COD-PRODUTO */
            _.Move(0, WS_COD_PRODUTO);

            /*" -249- PERFORM R0300_SELECT_PRODUTO_DB_SELECT_1 */

            R0300_SELECT_PRODUTO_DB_SELECT_1();

            /*" -252- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -254- DISPLAY 'R0300-ERRO SELECT COD-PRODUTO PRODUTOS_VG' LK-GE510-NUM-APOLICE */
                _.Display($"R0300-ERRO SELECT COD-PRODUTO PRODUTOS_VG{REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -256- MOVE 'GE0510S-R0300-ERRO SELECT COD-PRODUTO PRODUTOS_VG' TO LK-GE510-MSG-RETORNO */
                _.Move("GE0510S-R0300-ERRO SELECT COD-PRODUTO PRODUTOS_VG", REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_MSG_RETORNO);

                /*" -257- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -257- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-SELECT-PRODUTO-DB-SELECT-1 */
        public void R0300_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -249- EXEC SQL SELECT COD_PRODUTO INTO :WS-COD-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :LK-GE510-NUM-APOLICE AND COD_SUBGRUPO = :LK-GE510-COD-SUBGRUPO WITH UR END-EXEC. */

            var r0300_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R0300_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                LK_GE510_COD_SUBGRUPO = REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO.ToString(),
                LK_GE510_NUM_APOLICE = REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0300_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r0300_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_PRODUTO, WS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_EXIT*/

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO-SECTION */
        private void RXXXX_ROTINA_RETORNO_SECTION()
        {
            /*" -272- MOVE SQLCODE TO LK-GE510-SQLCODE */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE);

            /*" -272- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -283- MOVE '1' TO LK-GE510-COD-RETORNO */
            _.Move("1", REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO);

            /*" -285- MOVE SQLCODE TO WSQLCODE LK-GE510-SQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE, REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE);

            /*" -286- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -287- DISPLAY '*   SUB-ROTINA GE0510S - TERMINO ANORMAL        *' */
            _.Display($"*   SUB-ROTINA GE0510S - TERMINO ANORMAL        *");

            /*" -288- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -289- DISPLAY '* ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *' */
            _.Display($"* ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *");

            /*" -290- DISPLAY '* INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *' */
            _.Display($"* INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *");

            /*" -291- DISPLAY '*                                               *' */
            _.Display($"*                                               *");

            /*" -292- DISPLAY '* ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO   *' */
            _.Display($"* ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO   *");

            /*" -293- DISPLAY '* MENSAGEM -> ' LK-GE510-MSG-RETORNO */
            _.Display($"* MENSAGEM -> {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_MSG_RETORNO}");

            /*" -294- DISPLAY '* SQLERRMC -> ' SQLERRMC */
            _.Display($"* SQLERRMC -> {DB.SQLERRMC}");

            /*" -295- DISPLAY '* SQLCODE  -> ' LK-GE510-SQLCODE */
            _.Display($"* SQLCODE  -> {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

            /*" -296- DISPLAY '* APOLICE  -> ' LK-GE510-NUM-APOLICE */
            _.Display($"* APOLICE  -> {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

            /*" -297- DISPLAY '* SUBGRUPO -> ' LK-GE510-COD-SUBGRUPO */
            _.Display($"* SUBGRUPO -> {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

            /*" -298- DISPLAY '* CERTIF.  -> ' LK-GE510-NUM-CERTIFICADO */
            _.Display($"* CERTIF.  -> {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

            /*" -299- DISPLAY '*' WABEND '*' */

            $"*{WABEND}*"
            .Display();

            /*" -301- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -301- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}