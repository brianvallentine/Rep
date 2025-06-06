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
using Sias.Cosseguro.DB2.AC0003B;

namespace Code
{
    public class AC0003B
    {
        public bool IsCall { get; set; }

        public AC0003B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *---------------------------------                                      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA ................  ADMINISTRACAO DE COSSEGURO           *      */
        /*"      * PROGRAMA ...............  AC0003B                              *      */
        /*"      * ANALISTA/PROGRAMADOR ...  GILSON                               *      */
        /*"      * DATA CODIFICACAO .......  OUTUBRO / 2003                       *      */
        /*"      * FUNCAO .................  GERAR NUMEROS DE ORDEM DE COSSEGURO  *      */
        /*"      *                           CEDIDO PARA OS ENDOSSOS DE CANCELA-  *      */
        /*"      *                           -MENTO E REATIVACAO GERADOS NA TABELA*      */
        /*"      *                           V0HISTOPARC (END CANC - OPER 400/500)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                    DCLGEN                      ACESSO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                  SISTEMAS                    INPUT    *      */
        /*"      * PARCELA_HISTORICO         PARCEHIS                    INPUT    *      */
        /*"      * APOLICES                  APOLICES                    INPUT    *      */
        /*"      * ENDOSSOS                  ENDOSSOS                    INPUT    *      */
        /*"      * APOLICE COSSEGURADORA     APOLCOSS                    INPUT    *      */
        /*"      * NUMERO COSSEGURO          NUMERCOS                    I-O      *      */
        /*"      * ORDEM COSSEGURO CEDIDO    ORDEMCOS                    OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR/GERAR O NUM ORDEM  *      */
        /*"      *              CEDIDO POR EMPRESAS DO GCS DO ORGAO EMISSOR 0300  *      */
        /*"      * 21/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR O PROGRAMA PARA TRATAR/GERAR O NUM ORDEM  *      */
        /*"      *              CEDIDO POR EMPRESAS DO GCS DO ORGAO EMISSOR 0100  *      */
        /*"      *              E 110                                             *      */
        /*"      * 24/05/2024 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 588496 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          VIND-COD-EMPR       PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-DATA-CURR     PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-TIPO-ENDS     PIC  X(001)    VALUE SPACES.*/
        public StringBasis WHOST_TIPO_ENDS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          WHOST-QTDE-CONG     PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_CONG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          AREA-DE-WORK.*/
        public AC0003B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0003B_AREA_DE_WORK();
        public class AC0003B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WFIM-PARCEHIS       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PARCEHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-APOLCOSS       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_APOLCOSS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-L-PARCEHIS       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-L-ENDOSSOS       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-L-APOLCOSS       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_APOLCOSS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-L-NUMERCOS       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_NUMERCOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-NUMERCOS       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_NUMERCOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-I-ORDEMCOS       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_ORDEMCOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-NUM-ORDEM        PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WS_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05        WS-NUM-ORDEM-R      REDEFINES      WS-NUM-ORDEM.*/
            private _REDEF_AC0003B_WS_NUM_ORDEM_R _ws_num_ordem_r { get; set; }
            public _REDEF_AC0003B_WS_NUM_ORDEM_R WS_NUM_ORDEM_R
            {
                get { _ws_num_ordem_r = new _REDEF_AC0003B_WS_NUM_ORDEM_R(); _.Move(WS_NUM_ORDEM, _ws_num_ordem_r); VarBasis.RedefinePassValue(WS_NUM_ORDEM, _ws_num_ordem_r, WS_NUM_ORDEM); _ws_num_ordem_r.ValueChanged += () => { _.Move(_ws_num_ordem_r, WS_NUM_ORDEM); }; return _ws_num_ordem_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_ordem_r, WS_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_AC0003B_WS_NUM_ORDEM_R : VarBasis
            {
                /*"    10      WS-ORD-CONGE        PIC  9(004).*/
                public IntBasis WS_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-ORD-ORGAO        PIC  9(003).*/
                public IntBasis WS_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WS-ORD-SEQUE        PIC  9(007).*/
                public IntBasis WS_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"01          WABEND.*/

                public _REDEF_AC0003B_WS_NUM_ORDEM_R()
                {
                    WS_ORD_CONGE.ValueChanged += OnValueChanged;
                    WS_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WS_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
        }
        public AC0003B_WABEND WABEND { get; set; } = new AC0003B_WABEND();
        public class AC0003B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(007)     VALUE 'AC0003B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"AC0003B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZZ999- VALUE  ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.NUMERCOS NUMERCOS { get; set; } = new Dclgens.NUMERCOS();
        public Dclgens.ORDEMCOS ORDEMCOS { get; set; } = new Dclgens.ORDEMCOS();
        public AC0003B_C01_PARCEHIS C01_PARCEHIS { get; set; } = new AC0003B_C01_PARCEHIS();
        public AC0003B_C01_APOLCOSS C01_APOLCOSS { get; set; } = new AC0003B_C01_APOLCOSS();
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
            /*" -150- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -151- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -154- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -157- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -161- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -163- PERFORM R0300-00-DECLARE-PARCEHIS. */

            R0300_00_DECLARE_PARCEHIS_SECTION();

            /*" -165- PERFORM R0400-00-FETCH-PARCEHIS. */

            R0400_00_FETCH_PARCEHIS_SECTION();

            /*" -166- PERFORM R0500-00-PROCESSA-DOCUMENTO UNTIL WFIM-PARCEHIS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty()))
            {

                R0500_00_PROCESSA_DOCUMENTO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -171- DISPLAY '+----------+ AC0003B - RESUMO +----------+' . */
            _.Display($"+----------+ AC0003B - RESUMO +----------+");

            /*" -172- DISPLAY '| DOCUMENTOS LIDOS                       |' . */
            _.Display($"| DOCUMENTOS LIDOS                       |");

            /*" -174- DISPLAY '| .HISTORICO DE PARCELA ' AC-L-PARCEHIS '          |' */

            $"| .HISTORICO DE PARCELA {AREA_DE_WORK.AC_L_PARCEHIS}          |"
            .Display();

            /*" -176- DISPLAY '| .ENDOSSOS             ' AC-L-ENDOSSOS '          |' */

            $"| .ENDOSSOS             {AREA_DE_WORK.AC_L_ENDOSSOS}          |"
            .Display();

            /*" -178- DISPLAY '| .APOLICES COSSEGURO   ' AC-L-APOLCOSS '          |' */

            $"| .APOLICES COSSEGURO   {AREA_DE_WORK.AC_L_APOLCOSS}          |"
            .Display();

            /*" -180- DISPLAY '| .NUMERO COSSEGURO     ' AC-L-NUMERCOS '          |' */

            $"| .NUMERO COSSEGURO     {AREA_DE_WORK.AC_L_NUMERCOS}          |"
            .Display();

            /*" -181- DISPLAY '|                                        |' */
            _.Display($"|                                        |");

            /*" -182- DISPLAY '| DOCUMENTOS ALTERADOS                   |' */
            _.Display($"| DOCUMENTOS ALTERADOS                   |");

            /*" -184- DISPLAY '| .NUMERO COSSEGURO     ' AC-U-NUMERCOS '          |' */

            $"| .NUMERO COSSEGURO     {AREA_DE_WORK.AC_U_NUMERCOS}          |"
            .Display();

            /*" -185- DISPLAY '|                                        |' */
            _.Display($"|                                        |");

            /*" -186- DISPLAY '| DOCUMENTOS GRAVADOS                    |' */
            _.Display($"| DOCUMENTOS GRAVADOS                    |");

            /*" -188- DISPLAY '| .ORDEM COSSEGURO      ' AC-I-ORDEMCOS '          |' */

            $"| .ORDEM COSSEGURO      {AREA_DE_WORK.AC_I_ORDEMCOS}          |"
            .Display();

            /*" -190- DISPLAY '+---------------------------------------+' . */
            _.Display($"+---------------------------------------+");

            /*" -192- DISPLAY '*---*  AC0003B  -  TERMINO NORMAL  *---*' . */
            _.Display($"*---*  AC0003B  -  TERMINO NORMAL  *---*");

            /*" -192- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -196- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -196- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -209- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -216- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -219- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -220- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS (AC)' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS (AC)");

                /*" -221- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -222- ELSE */
            }
            else
            {


                /*" -222- DISPLAY 'DATA DO MOVIMENTO - ' SISTEMAS-DATA-MOV-ABERTO. */
                _.Display($"DATA DO MOVIMENTO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -216- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-CURR FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'AC' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_CURR, WHOST_DATA_CURR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-PARCEHIS-SECTION */
        private void R0300_00_DECLARE_PARCEHIS_SECTION()
        {
            /*" -235- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -258- PERFORM R0300_00_DECLARE_PARCEHIS_DB_DECLARE_1 */

            R0300_00_DECLARE_PARCEHIS_DB_DECLARE_1();

            /*" -260- PERFORM R0300_00_DECLARE_PARCEHIS_DB_OPEN_1 */

            R0300_00_DECLARE_PARCEHIS_DB_OPEN_1();

            /*" -263- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -264- DISPLAY 'R0300 - ERRO NO DECLARE DA PARCELA-HISTORICO' */
                _.Display($"R0300 - ERRO NO DECLARE DA PARCELA-HISTORICO");

                /*" -265- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -266- ELSE */
            }
            else
            {


                /*" -266- MOVE SPACES TO WFIM-PARCEHIS. */
                _.Move("", AREA_DE_WORK.WFIM_PARCEHIS);
            }


        }

        [StopWatch]
        /*" R0300-00-DECLARE-PARCEHIS-DB-DECLARE-1 */
        public void R0300_00_DECLARE_PARCEHIS_DB_DECLARE_1()
        {
            /*" -258- EXEC SQL DECLARE C01_PARCEHIS CURSOR FOR SELECT A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO, A.COD_OPERACAO, A.DATA_MOVIMENTO, A.ENDOS_CANCELA, B.ORGAO_EMISSOR, B.RAMO_EMISSOR, B.TIPO_SEGURO FROM SEGUROS.PARCELA_HISTORICO A, SEGUROS.APOLICES B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.COD_OPERACAO BETWEEN 0400 AND 0599 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.ORGAO_EMISSOR IN (0010,0100,0110,0300) AND B.TIPO_SEGURO = '1' ORDER BY A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.OCORR_HISTORICO END-EXEC. */
            C01_PARCEHIS = new AC0003B_C01_PARCEHIS(true);
            string GetQuery_C01_PARCEHIS()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							A.DATA_MOVIMENTO
							, 
							A.ENDOS_CANCELA
							, 
							B.ORGAO_EMISSOR
							, 
							B.RAMO_EMISSOR
							, 
							B.TIPO_SEGURO 
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.APOLICES B 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.COD_OPERACAO BETWEEN 0400 AND 0599 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.ORGAO_EMISSOR IN (0010
							,0100
							,0110
							,0300) 
							AND B.TIPO_SEGURO = '1' 
							ORDER BY A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO";

                return query;
            }
            C01_PARCEHIS.GetQueryEvent += GetQuery_C01_PARCEHIS;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-PARCEHIS-DB-OPEN-1 */
        public void R0300_00_DECLARE_PARCEHIS_DB_OPEN_1()
        {
            /*" -260- EXEC SQL OPEN C01_PARCEHIS END-EXEC. */

            C01_PARCEHIS.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-APOLCOSS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_APOLCOSS_DB_DECLARE_1()
        {
            /*" -463- EXEC SQL DECLARE C01_APOLCOSS CURSOR FOR SELECT NUM_APOLICE, COD_COSSEGURADORA, DATA_INIVIGENCIA, DATA_TERVIGENCIA FROM SEGUROS.APOL_COSSEGURADORA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA ORDER BY NUM_APOLICE, COD_COSSEGURADORA, DATA_INIVIGENCIA END-EXEC. */
            C01_APOLCOSS = new AC0003B_C01_APOLCOSS(true);
            string GetQuery_C01_APOLCOSS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_COSSEGURADORA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA 
							FROM SEGUROS.APOL_COSSEGURADORA 
							WHERE NUM_APOLICE = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}' 
							AND DATA_INIVIGENCIA <= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							AND DATA_TERVIGENCIA >= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							ORDER BY 
							NUM_APOLICE
							, 
							COD_COSSEGURADORA
							, 
							DATA_INIVIGENCIA";

                return query;
            }
            C01_APOLCOSS.GetQueryEvent += GetQuery_C01_APOLCOSS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-FETCH-PARCEHIS-SECTION */
        private void R0400_00_FETCH_PARCEHIS_SECTION()
        {
            /*" -279- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -290- PERFORM R0400_00_FETCH_PARCEHIS_DB_FETCH_1 */

            R0400_00_FETCH_PARCEHIS_DB_FETCH_1();

            /*" -293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -294- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -295- MOVE 'S' TO WFIM-PARCEHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_PARCEHIS);

                    /*" -295- PERFORM R0400_00_FETCH_PARCEHIS_DB_CLOSE_1 */

                    R0400_00_FETCH_PARCEHIS_DB_CLOSE_1();

                    /*" -297- ELSE */
                }
                else
                {


                    /*" -298- DISPLAY 'R0400 - ERRO NO FETCH DA PARCELA-HISTORICO' */
                    _.Display($"R0400 - ERRO NO FETCH DA PARCELA-HISTORICO");

                    /*" -299- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -300- ELSE */
                }

            }
            else
            {


                /*" -301- IF PARCEHIS-ENDOS-CANCELA = ZEROS */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA == 00)
                {

                    /*" -302- DISPLAY 'R0400 - ENDS MOVTO INVALIDO PARA DOCUMENTO' */
                    _.Display($"R0400 - ENDS MOVTO INVALIDO PARA DOCUMENTO");

                    /*" -303- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -304- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -305- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -306- DISPLAY 'OC HIST  - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OC HIST  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -307- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -308- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -309- DISPLAY 'ENDS MOV - ' PARCEHIS-ENDOS-CANCELA */
                    _.Display($"ENDS MOV - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                    /*" -310- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -311- ELSE */
                }
                else
                {


                    /*" -311- ADD 1 TO AC-L-PARCEHIS. */
                    AREA_DE_WORK.AC_L_PARCEHIS.Value = AREA_DE_WORK.AC_L_PARCEHIS + 1;
                }

            }


        }

        [StopWatch]
        /*" R0400-00-FETCH-PARCEHIS-DB-FETCH-1 */
        public void R0400_00_FETCH_PARCEHIS_DB_FETCH_1()
        {
            /*" -290- EXEC SQL FETCH C01_PARCEHIS INTO :PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-COD-OPERACAO , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-ENDOS-CANCELA , :APOLICES-ORGAO-EMISSOR , :APOLICES-RAMO-EMISSOR , :APOLICES-TIPO-SEGURO END-EXEC. */

            if (C01_PARCEHIS.Fetch())
            {
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C01_PARCEHIS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(C01_PARCEHIS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(C01_PARCEHIS.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
                _.Move(C01_PARCEHIS.PARCEHIS_ENDOS_CANCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);
                _.Move(C01_PARCEHIS.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(C01_PARCEHIS.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
                _.Move(C01_PARCEHIS.APOLICES_TIPO_SEGURO, APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO);
            }

        }

        [StopWatch]
        /*" R0400-00-FETCH-PARCEHIS-DB-CLOSE-1 */
        public void R0400_00_FETCH_PARCEHIS_DB_CLOSE_1()
        {
            /*" -295- EXEC SQL CLOSE C01_PARCEHIS END-EXEC */

            C01_PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-DOCUMENTO-SECTION */
        private void R0500_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -326- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -328- MOVE SPACES TO WHOST-TIPO-ENDS. */
            _.Move("", WHOST_TIPO_ENDS);

            /*" -330- IF PARCEHIS-COD-OPERACAO > 0399 AND PARCEHIS-COD-OPERACAO < 0500 */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO > 0399 && PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO < 0500)
            {

                /*" -331- PERFORM R0600-00-VERIFICA-TIPO-ENDS */

                R0600_00_VERIFICA_TIPO_ENDS_SECTION();

                /*" -333- IF WHOST-TIPO-ENDS = '5' NEXT SENTENCE */

                if (WHOST_TIPO_ENDS == "5")
                {

                    /*" -334- ELSE */
                }
                else
                {


                    /*" -335- PERFORM R0700-00-PROCESSA-ENDOSSO */

                    R0700_00_PROCESSA_ENDOSSO_SECTION();

                    /*" -336- ELSE */
                }

            }
            else
            {


                /*" -340- PERFORM R0700-00-PROCESSA-ENDOSSO. */

                R0700_00_PROCESSA_ENDOSSO_SECTION();
            }


            /*" -340- PERFORM R0400-00-FETCH-PARCEHIS. */

            R0400_00_FETCH_PARCEHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-VERIFICA-TIPO-ENDS-SECTION */
        private void R0600_00_VERIFICA_TIPO_ENDS_SECTION()
        {
            /*" -353- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -359- PERFORM R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1 */

            R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1();

            /*" -362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -363- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -364- MOVE SPACES TO WHOST-TIPO-ENDS */
                    _.Move("", WHOST_TIPO_ENDS);

                    /*" -365- ELSE */
                }
                else
                {


                    /*" -366- DISPLAY 'R0600 - ERRO NO SELECT DA ENDOSSOS' */
                    _.Display($"R0600 - ERRO NO SELECT DA ENDOSSOS");

                    /*" -367- DISPLAY 'APOLICE - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -368- DISPLAY 'ENDOSSO - ' PARCEHIS-ENDOS-CANCELA */
                    _.Display($"ENDOSSO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                    /*" -369- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -370- ELSE */
                }

            }
            else
            {


                /*" -372- IF WHOST-TIPO-ENDS = '5' NEXT SENTENCE */

                if (WHOST_TIPO_ENDS == "5")
                {

                    /*" -373- ELSE */
                }
                else
                {


                    /*" -374- DISPLAY 'R0600 - TIPO DE ENDOSSO INVALIDO P/ DOCTO' */
                    _.Display($"R0600 - TIPO DE ENDOSSO INVALIDO P/ DOCTO");

                    /*" -375- DISPLAY 'APOLICE - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -376- DISPLAY 'ENDOSSO - ' PARCEHIS-ENDOS-CANCELA */
                    _.Display($"ENDOSSO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                    /*" -376- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-VERIFICA-TIPO-ENDS-DB-SELECT-1 */
        public void R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1()
        {
            /*" -359- EXEC SQL SELECT TIPO_ENDOSSO INTO :WHOST-TIPO-ENDS FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-ENDOS-CANCELA END-EXEC. */

            var r0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1 = new R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1()
            {
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1.Execute(r0600_00_VERIFICA_TIPO_ENDS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_TIPO_ENDS, WHOST_TIPO_ENDS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-ENDOSSO-SECTION */
        private void R0700_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -389- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -391- PERFORM R0800-00-SELECT-ENDOSSOS. */

            R0800_00_SELECT_ENDOSSOS_SECTION();

            /*" -393- PERFORM R0900-00-DECLARE-APOLCOSS. */

            R0900_00_DECLARE_APOLCOSS_SECTION();

            /*" -395- PERFORM R0950-00-FETCH-APOLCOSS. */

            R0950_00_FETCH_APOLCOSS_SECTION();

            /*" -396- IF WFIM-APOLCOSS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_APOLCOSS.IsEmpty())
            {

                /*" -397- MOVE ZEROS TO WHOST-QTDE-CONG */
                _.Move(0, WHOST_QTDE_CONG);

                /*" -398- PERFORM R1000-00-VERIFICA-COSSEGURO */

                R1000_00_VERIFICA_COSSEGURO_SECTION();

                /*" -399- ELSE */
            }
            else
            {


                /*" -400- PERFORM R1100-00-PROCESSA-APOLCOSS UNTIL WFIM-APOLCOSS NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_APOLCOSS.IsEmpty()))
                {

                    R1100_00_PROCESSA_APOLCOSS_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-ENDOSSOS-SECTION */
        private void R0800_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -413- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -429- PERFORM R0800_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0800_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -432- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -433- DISPLAY 'R0800 - ERRO NO SELECT DA ENDOSSOS' */
                _.Display($"R0800 - ERRO NO SELECT DA ENDOSSOS");

                /*" -434- DISPLAY 'APOLICE - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -435- DISPLAY 'ENDOSSO - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -436- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -437- ELSE */
            }
            else
            {


                /*" -437- ADD 1 TO AC-L-ENDOSSOS. */
                AREA_DE_WORK.AC_L_ENDOSSOS.Value = AREA_DE_WORK.AC_L_ENDOSSOS + 1;
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0800_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -429- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , TIPO_ENDOSSO , SIT_REGISTRO INTO :ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-DATA-INIVIGENCIA , :ENDOSSOS-DATA-TERVIGENCIA , :ENDOSSOS-TIPO-ENDOSSO , :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

            var r0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-APOLCOSS-SECTION */
        private void R0900_00_DECLARE_APOLCOSS_SECTION()
        {
            /*" -450- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -463- PERFORM R0900_00_DECLARE_APOLCOSS_DB_DECLARE_1 */

            R0900_00_DECLARE_APOLCOSS_DB_DECLARE_1();

            /*" -465- PERFORM R0900_00_DECLARE_APOLCOSS_DB_OPEN_1 */

            R0900_00_DECLARE_APOLCOSS_DB_OPEN_1();

            /*" -468- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -469- DISPLAY 'R0900 - ERRO NO DECLARE DA APOL-COSSEGURADORA' */
                _.Display($"R0900 - ERRO NO DECLARE DA APOL-COSSEGURADORA");

                /*" -470- DISPLAY 'APOLICE - ' ENDOSSOS-NUM-APOLICE */
                _.Display($"APOLICE - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -471- DISPLAY 'ENDOSSO - ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -472- DISPLAY 'INI VIG - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIG - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -473- DISPLAY 'END MOV - ' PARCEHIS-ENDOS-CANCELA */
                _.Display($"END MOV - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                /*" -474- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -475- ELSE */
            }
            else
            {


                /*" -475- MOVE SPACES TO WFIM-APOLCOSS. */
                _.Move("", AREA_DE_WORK.WFIM_APOLCOSS);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-APOLCOSS-DB-OPEN-1 */
        public void R0900_00_DECLARE_APOLCOSS_DB_OPEN_1()
        {
            /*" -465- EXEC SQL OPEN C01_APOLCOSS END-EXEC. */

            C01_APOLCOSS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-APOLCOSS-SECTION */
        private void R0950_00_FETCH_APOLCOSS_SECTION()
        {
            /*" -488- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WABEND.WNR_EXEC_SQL);

            /*" -493- PERFORM R0950_00_FETCH_APOLCOSS_DB_FETCH_1 */

            R0950_00_FETCH_APOLCOSS_DB_FETCH_1();

            /*" -496- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -497- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -498- MOVE 'S' TO WFIM-APOLCOSS */
                    _.Move("S", AREA_DE_WORK.WFIM_APOLCOSS);

                    /*" -498- PERFORM R0950_00_FETCH_APOLCOSS_DB_CLOSE_1 */

                    R0950_00_FETCH_APOLCOSS_DB_CLOSE_1();

                    /*" -500- ELSE */
                }
                else
                {


                    /*" -501- DISPLAY 'R0950 - ERRO NO FETCH DA APOL-COSSEGURADORA' */
                    _.Display($"R0950 - ERRO NO FETCH DA APOL-COSSEGURADORA");

                    /*" -502- DISPLAY 'APOLICE - ' ENDOSSOS-NUM-APOLICE */
                    _.Display($"APOLICE - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -503- DISPLAY 'ENDOSSO - ' ENDOSSOS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                    /*" -504- DISPLAY 'INI VIG - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIG - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -505- DISPLAY 'END MOV - ' PARCEHIS-ENDOS-CANCELA */
                    _.Display($"END MOV - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                    /*" -506- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -507- ELSE */
                }

            }
            else
            {


                /*" -507- ADD 1 TO AC-L-APOLCOSS. */
                AREA_DE_WORK.AC_L_APOLCOSS.Value = AREA_DE_WORK.AC_L_APOLCOSS + 1;
            }


        }

        [StopWatch]
        /*" R0950-00-FETCH-APOLCOSS-DB-FETCH-1 */
        public void R0950_00_FETCH_APOLCOSS_DB_FETCH_1()
        {
            /*" -493- EXEC SQL FETCH C01_APOLCOSS INTO :APOLCOSS-NUM-APOLICE, :APOLCOSS-COD-COSSEGURADORA, :APOLCOSS-DATA-INIVIGENCIA, :APOLCOSS-DATA-TERVIGENCIA END-EXEC. */

            if (C01_APOLCOSS.Fetch())
            {
                _.Move(C01_APOLCOSS.APOLCOSS_NUM_APOLICE, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_NUM_APOLICE);
                _.Move(C01_APOLCOSS.APOLCOSS_COD_COSSEGURADORA, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA);
                _.Move(C01_APOLCOSS.APOLCOSS_DATA_INIVIGENCIA, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_DATA_INIVIGENCIA);
                _.Move(C01_APOLCOSS.APOLCOSS_DATA_TERVIGENCIA, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_DATA_TERVIGENCIA);
            }

        }

        [StopWatch]
        /*" R0950-00-FETCH-APOLCOSS-DB-CLOSE-1 */
        public void R0950_00_FETCH_APOLCOSS_DB_CLOSE_1()
        {
            /*" -498- EXEC SQL CLOSE C01_APOLCOSS END-EXEC */

            C01_APOLCOSS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-VERIFICA-COSSEGURO-SECTION */
        private void R1000_00_VERIFICA_COSSEGURO_SECTION()
        {
            /*" -520- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -526- PERFORM R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1 */

            R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1();

            /*" -529- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -530- DISPLAY 'R1000 - ERRO NO SELECT DA ORDEM-COSSEGCED' */
                _.Display($"R1000 - ERRO NO SELECT DA ORDEM-COSSEGCED");

                /*" -531- DISPLAY 'APOLICE - ' ENDOSSOS-NUM-APOLICE */
                _.Display($"APOLICE - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -532- DISPLAY 'ENDOSSO - ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -533- DISPLAY 'INI VIG - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIG - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -534- DISPLAY 'END MOV - ' PARCEHIS-ENDOS-CANCELA */
                _.Display($"END MOV - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                /*" -535- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -536- ELSE */
            }
            else
            {


                /*" -537- IF WHOST-QTDE-CONG > ZEROS */

                if (WHOST_QTDE_CONG > 00)
                {

                    /*" -538- DISPLAY 'R1000 - EXISTE COSSEGURO PARA O DOCUMENTO' */
                    _.Display($"R1000 - EXISTE COSSEGURO PARA O DOCUMENTO");

                    /*" -539- DISPLAY 'APOLICE - ' ENDOSSOS-NUM-APOLICE */
                    _.Display($"APOLICE - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -540- DISPLAY 'ENDOSSO - ' ENDOSSOS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                    /*" -541- DISPLAY 'INI VIG - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIG - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -542- DISPLAY 'END MOV - ' PARCEHIS-ENDOS-CANCELA */
                    _.Display($"END MOV - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                    /*" -542- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1000-00-VERIFICA-COSSEGURO-DB-SELECT-1 */
        public void R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1()
        {
            /*" -526- EXEC SQL SELECT COUNT(*) INTO :WHOST-QTDE-CONG FROM SEGUROS.ORDEM_COSSEGCED WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO END-EXEC. */

            var r1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1 = new R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1.Execute(r1000_00_VERIFICA_COSSEGURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_CONG, WHOST_QTDE_CONG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-APOLCOSS-SECTION */
        private void R1100_00_PROCESSA_APOLCOSS_SECTION()
        {
            /*" -555- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -557- MOVE ZEROS TO ORDEMCOS-ORDEM-CEDIDO. */
            _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);

            /*" -559- PERFORM R1200-00-SELECT-ORDEM-COSCED. */

            R1200_00_SELECT_ORDEM_COSCED_SECTION();

            /*" -560- IF ORDEMCOS-ORDEM-CEDIDO > ZEROS */

            if (ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO > 00)
            {

                /*" -562- GO TO R1100-90-LER-APOLCOSS. */

                R1100_90_LER_APOLCOSS(); //GOTO
                return;
            }


            /*" -564- PERFORM R1300-00-SELECT-NUMERCOS. */

            R1300_00_SELECT_NUMERCOS_SECTION();

            /*" -565- MOVE PARCEHIS-NUM-APOLICE TO ORDEMCOS-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE);

            /*" -567- MOVE PARCEHIS-ENDOS-CANCELA TO ORDEMCOS-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO);

            /*" -570- MOVE APOLCOSS-COD-COSSEGURADORA TO ORDEMCOS-COD-COSSEGURADORA. */
            _.Move(APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA);

            /*" -571- MOVE ZEROS TO WS-NUM-ORDEM. */
            _.Move(0, AREA_DE_WORK.WS_NUM_ORDEM);

            /*" -572- MOVE APOLCOSS-COD-COSSEGURADORA TO WS-ORD-CONGE. */
            _.Move(APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA, AREA_DE_WORK.WS_NUM_ORDEM_R.WS_ORD_CONGE);

            /*" -574- MOVE APOLICES-ORGAO-EMISSOR TO WS-ORD-ORGAO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR, AREA_DE_WORK.WS_NUM_ORDEM_R.WS_ORD_ORGAO);

            /*" -575- ADD +1 TO NUMERCOS-SEQ-ORD-CEDIDO. */
            NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO.Value = NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO + +1;

            /*" -577- MOVE NUMERCOS-SEQ-ORD-CEDIDO TO WS-ORD-SEQUE. */
            _.Move(NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO, AREA_DE_WORK.WS_NUM_ORDEM_R.WS_ORD_SEQUE);

            /*" -579- MOVE WS-NUM-ORDEM TO ORDEMCOS-ORDEM-CEDIDO. */
            _.Move(AREA_DE_WORK.WS_NUM_ORDEM, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);

            /*" -580- MOVE ZEROS TO ORDEMCOS-COD-EMPRESA. */
            _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_EMPRESA);

            /*" -582- MOVE +1 TO VIND-COD-EMPR. */
            _.Move(+1, VIND_COD_EMPR);

            /*" -584- PERFORM R1400-00-INSERT-ORDEMCOS. */

            R1400_00_INSERT_ORDEMCOS_SECTION();

            /*" -584- PERFORM R1500-00-UPDATE-NUMERCOS. */

            R1500_00_UPDATE_NUMERCOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1100_90_LER_APOLCOSS */

            R1100_90_LER_APOLCOSS();

        }

        [StopWatch]
        /*" R1100-90-LER-APOLCOSS */
        private void R1100_90_LER_APOLCOSS(bool isPerform = false)
        {
            /*" -588- PERFORM R0950-00-FETCH-APOLCOSS. */

            R0950_00_FETCH_APOLCOSS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-ORDEM-COSCED-SECTION */
        private void R1200_00_SELECT_ORDEM_COSCED_SECTION()
        {
            /*" -601- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -614- PERFORM R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1 */

            R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1();

            /*" -617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -618- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -619- MOVE ZEROS TO ORDEMCOS-NUM-APOLICE */
                    _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE);

                    /*" -620- MOVE ZEROS TO ORDEMCOS-NUM-ENDOSSO */
                    _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO);

                    /*" -621- MOVE ZEROS TO ORDEMCOS-COD-COSSEGURADORA */
                    _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA);

                    /*" -622- MOVE ZEROS TO ORDEMCOS-ORDEM-CEDIDO */
                    _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);

                    /*" -623- ELSE */
                }
                else
                {


                    /*" -624- DISPLAY 'R1200 - ERRO NO SELECT DA ORDEM-COSSEGCED' */
                    _.Display($"R1200 - ERRO NO SELECT DA ORDEM-COSSEGCED");

                    /*" -625- DISPLAY 'APOLICE - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -626- DISPLAY 'END MOV - ' PARCEHIS-ENDOS-CANCELA */
                    _.Display($"END MOV - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA}");

                    /*" -627- DISPLAY 'ENDOSSO - ' ENDOSSOS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                    /*" -628- DISPLAY 'INI VIG - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIG - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -628- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-ORDEM-COSCED-DB-SELECT-1 */
        public void R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1()
        {
            /*" -614- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, COD_COSSEGURADORA, ORDEM_CEDIDO INTO :ORDEMCOS-NUM-APOLICE, :ORDEMCOS-NUM-ENDOSSO, :ORDEMCOS-COD-COSSEGURADORA, :ORDEMCOS-ORDEM-CEDIDO FROM SEGUROS.ORDEM_COSSEGCED WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-ENDOS-CANCELA AND COD_COSSEGURADORA = :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            var r1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1 = new R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1()
            {
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_ORDEM_COSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ORDEMCOS_NUM_APOLICE, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE);
                _.Move(executed_1.ORDEMCOS_NUM_ENDOSSO, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO);
                _.Move(executed_1.ORDEMCOS_COD_COSSEGURADORA, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA);
                _.Move(executed_1.ORDEMCOS_ORDEM_CEDIDO, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-NUMERCOS-SECTION */
        private void R1300_00_SELECT_NUMERCOS_SECTION()
        {
            /*" -641- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -649- PERFORM R1300_00_SELECT_NUMERCOS_DB_SELECT_1 */

            R1300_00_SELECT_NUMERCOS_DB_SELECT_1();

            /*" -652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -653- DISPLAY 'R1300 - ERRO NO SELECT DA NUMERO-COSSEGURO' */
                _.Display($"R1300 - ERRO NO SELECT DA NUMERO-COSSEGURO");

                /*" -654- DISPLAY 'ORGAO EMI - ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO EMI - {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -655- DISPLAY 'CONGENERE - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"CONGENERE - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -656- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -657- ELSE */
            }
            else
            {


                /*" -657- ADD 1 TO AC-L-NUMERCOS. */
                AREA_DE_WORK.AC_L_NUMERCOS.Value = AREA_DE_WORK.AC_L_NUMERCOS + 1;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-NUMERCOS-DB-SELECT-1 */
        public void R1300_00_SELECT_NUMERCOS_DB_SELECT_1()
        {
            /*" -649- EXEC SQL SELECT ORGAO_EMISSOR, SEQ_ORD_CEDIDO INTO :NUMERCOS-ORGAO-EMISSOR, :NUMERCOS-SEQ-ORD-CEDIDO FROM SEGUROS.NUMERO_COSSEGURO WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND COD_CONGENERE = :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            var r1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1 = new R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1()
            {
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
            };

            var executed_1 = R1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_NUMERCOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMERCOS_ORGAO_EMISSOR, NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_ORGAO_EMISSOR);
                _.Move(executed_1.NUMERCOS_SEQ_ORD_CEDIDO, NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-INSERT-ORDEMCOS-SECTION */
        private void R1400_00_INSERT_ORDEMCOS_SECTION()
        {
            /*" -670- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -678- PERFORM R1400_00_INSERT_ORDEMCOS_DB_INSERT_1 */

            R1400_00_INSERT_ORDEMCOS_DB_INSERT_1();

            /*" -681- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -682- DISPLAY 'R1400 - ERRO NO INSERT DA ORDEM-COSSEGCED' */
                _.Display($"R1400 - ERRO NO INSERT DA ORDEM-COSSEGCED");

                /*" -683- DISPLAY 'APOLICE   - ' ORDEMCOS-NUM-APOLICE */
                _.Display($"APOLICE   - {ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE}");

                /*" -684- DISPLAY 'ENDOSSO   - ' ORDEMCOS-NUM-ENDOSSO */
                _.Display($"ENDOSSO   - {ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO}");

                /*" -685- DISPLAY 'CONGENERE - ' ORDEMCOS-COD-COSSEGURADORA */
                _.Display($"CONGENERE - {ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA}");

                /*" -686- DISPLAY 'NRO ORDEM - ' ORDEMCOS-ORDEM-CEDIDO */
                _.Display($"NRO ORDEM - {ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO}");

                /*" -687- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -688- ELSE */
            }
            else
            {


                /*" -688- ADD 1 TO AC-I-ORDEMCOS. */
                AREA_DE_WORK.AC_I_ORDEMCOS.Value = AREA_DE_WORK.AC_I_ORDEMCOS + 1;
            }


        }

        [StopWatch]
        /*" R1400-00-INSERT-ORDEMCOS-DB-INSERT-1 */
        public void R1400_00_INSERT_ORDEMCOS_DB_INSERT_1()
        {
            /*" -678- EXEC SQL INSERT INTO SEGUROS.ORDEM_COSSEGCED VALUES (:ORDEMCOS-NUM-APOLICE , :ORDEMCOS-NUM-ENDOSSO , :ORDEMCOS-COD-COSSEGURADORA , :ORDEMCOS-ORDEM-CEDIDO , :ORDEMCOS-COD-EMPRESA:VIND-COD-EMPR , CURRENT TIMESTAMP) END-EXEC. */

            var r1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1 = new R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1()
            {
                ORDEMCOS_NUM_APOLICE = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE.ToString(),
                ORDEMCOS_NUM_ENDOSSO = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO.ToString(),
                ORDEMCOS_COD_COSSEGURADORA = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA.ToString(),
                ORDEMCOS_ORDEM_CEDIDO = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO.ToString(),
                ORDEMCOS_COD_EMPRESA = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_EMPRESA.ToString(),
                VIND_COD_EMPR = VIND_COD_EMPR.ToString(),
            };

            R1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1.Execute(r1400_00_INSERT_ORDEMCOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-UPDATE-NUMERCOS-SECTION */
        private void R1500_00_UPDATE_NUMERCOS_SECTION()
        {
            /*" -701- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -707- PERFORM R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1 */

            R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1();

            /*" -710- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -711- DISPLAY 'R1500 - ERRO NO UPDATE DA NUMERO-COSSEGURO' */
                _.Display($"R1500 - ERRO NO UPDATE DA NUMERO-COSSEGURO");

                /*" -712- DISPLAY 'ORGAO EMI - ' APOLICES-ORGAO-EMISSOR */
                _.Display($"ORGAO EMI - {APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR}");

                /*" -713- DISPLAY 'CONGENERE - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"CONGENERE - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -714- DISPLAY 'NRO ORDEM - ' NUMERCOS-SEQ-ORD-CEDIDO */
                _.Display($"NRO ORDEM - {NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO}");

                /*" -715- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -716- ELSE */
            }
            else
            {


                /*" -716- ADD 1 TO AC-U-NUMERCOS. */
                AREA_DE_WORK.AC_U_NUMERCOS.Value = AREA_DE_WORK.AC_U_NUMERCOS + 1;
            }


        }

        [StopWatch]
        /*" R1500-00-UPDATE-NUMERCOS-DB-UPDATE-1 */
        public void R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1()
        {
            /*" -707- EXEC SQL UPDATE SEGUROS.NUMERO_COSSEGURO SET SEQ_ORD_CEDIDO = :NUMERCOS-SEQ-ORD-CEDIDO , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO_EMISSOR = :APOLICES-ORGAO-EMISSOR AND COD_CONGENERE = :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            var r1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1 = new R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1()
            {
                NUMERCOS_SEQ_ORD_CEDIDO = NUMERCOS.DCLNUMERO_COSSEGURO.NUMERCOS_SEQ_ORD_CEDIDO.ToString(),
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                APOLICES_ORGAO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR.ToString(),
            };

            R1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1.Execute(r1500_00_UPDATE_NUMERCOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -731- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -733- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -733- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -737- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -737- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}