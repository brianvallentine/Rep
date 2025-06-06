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
using Sias.Emissao.DB2.EM1139B;

namespace Code
{
    public class EM1139B
    {
        public bool IsCall { get; set; }

        public EM1139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EM                                 *      */
        /*"      *   PROGRAMA ...............  EM1139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  26/08/2013                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  - INSERE DADOS NA TABELAS:         *      */
        /*"      *   GE397 - SEGUROS.GE_ENDOS_COSSEG_COBER                        *      */
        /*"      *   GE398 - SEGUROS.GE_PCT_PART_COBER                            *      */
        /*"      *   FATURAS EMITIDAS PELO PROGRAMA VG0139B COM COBERTURAS DIT    *      */
        /*"      *   RAMO_COBERTURA  =  90                                        *      */
        /*"      *   COD_COBERTURA   =  05                                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                   ALTERACOES                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.01        -   CLOVIS                             *      */
        /*"      *  CADMUS...: EMAIL                                              *      */
        /*"      *  DATA ....: 05/06/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  ASSUNTO: PERCENTUAIS DE COSSEGURO CEDIDO POR COBERTURA DIT    *      */
        /*"      *           DA PREVISUL.                                         *      */
        /*"      *                                                                *      */
        /*"      *  DE: CASTELANO RIBEIRO DOS SANTOS                              *      */
        /*"      *  ENVIADA EM: QUARTA-FEIRA, 4 DE JUNHO DE 2014 11:30            *      */
        /*"      *                                                                *      */
        /*"      *  PARA A COBERTURA DIT TEREMOS AS SEGUINTES PREMISSAS:          *      */
        /*"      *  1. A PREVISUL TER� 95% DE PERCENTUAL DE PARTICIPA��O NO       *      */
        /*"      *     RISCO/COBERTURA.                                           *      */
        /*"      *  2. A CAIXA SEGUROS TER� 5% DE PERCENTUAL DE PARTICIPA��O NO   *      */
        /*"      *     RISCO/COBERTURA.                                           *      */
        /*"      *     A COMISS�O DE COSSEGURO SER� MANTIDA EM 5%.                *      */
        /*"      *                                                                *      */
        /*"      *  DE: CASTELANO RIBEIRO DOS SANTOS                              *      */
        /*"      *  ENVIADA EM: QUINTA-FEIRA, 5 DE JUNHO DE 2014 12:02            *      */
        /*"      *                                                                *      */
        /*"      *  GILSON                                                        *      */
        /*"      *  VAMOS CONSIDERAR A DATA DE 06/06.                             *      */
        /*"      *  CINTIA/ALCIR                                                  *      */
        /*"      *  FAVOR REGISTRAR A DEMANDA.                                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           AREA-DE-WORK.*/
        public EM1139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM1139B_AREA_DE_WORK();
        public class EM1139B_AREA_DE_WORK : VarBasis
        {
            /*"  03         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-V0PARCEHIS     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_V0PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         IN-GE397          PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_GE397 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         IN-GE398          PIC  9(009)         VALUE ZEROS.*/
            public IntBasis IN_GE398 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_EM1139B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM1139B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM1139B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_EM1139B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(003).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_EM1139B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_EM1139B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM1139B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM1139B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM1139B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_EM1139B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_EM1139B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_EM1139B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_EM1139B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_EM1139B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public EM1139B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM1139B_WTIME_DAYR();
                public class EM1139B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public EM1139B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_EM1139B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public EM1139B_WS_TIME WS_TIME { get; set; } = new EM1139B_WS_TIME();
            public class EM1139B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/
            }
            public EM1139B_WABEND WABEND { get; set; } = new EM1139B_WABEND();
            public class EM1139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM1139B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM1139B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LD99-ABEND.*/
            }
        }
        public EM1139B_LD99_ABEND LD99_ABEND { get; set; } = new EM1139B_LD99_ABEND();
        public class EM1139B_LD99_ABEND : VarBasis
        {
            /*"      10    FILLER              PIC  X(050) VALUE           ' REINICIAR JOB NO PROXIMO STEP               '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" REINICIAR JOB NO PROXIMO STEP               ");
            /*"      10    FILLER              PIC  X(050) VALUE           ' QUANDO SQLCODE IGUAL (-911) RESTART MESMO STEP '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" QUANDO SQLCODE IGUAL (-911) RESTART MESMO STEP ");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.ORDEMCOS ORDEMCOS { get; set; } = new Dclgens.ORDEMCOS();
        public Dclgens.GE397 GE397 { get; set; } = new Dclgens.GE397();
        public Dclgens.GE398 GE398 { get; set; } = new Dclgens.GE398();
        public EM1139B_V0PARCEHIS V0PARCEHIS { get; set; } = new EM1139B_V0PARCEHIS();
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
            /*" -161- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -164- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -167- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -173- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -176- PERFORM R0290-00-TRATA-PARCEHIS. */

            R0290_00_TRATA_PARCEHIS_SECTION();

            /*" -177- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -178- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -179- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -180- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -181- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -182- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -182- DISPLAY 'FIM    EM1139B    ' WTIME-DAYR. */
            _.Display($"FIM    EM1139B    {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -187- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -192- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -193- DISPLAY ' ' . */
            _.Display($" ");

            /*" -194- DISPLAY 'EM1139B - FIM NORMAL' . */
            _.Display($"EM1139B - FIM NORMAL");

            /*" -197- DISPLAY ' ' . */
            _.Display($" ");

            /*" -197- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -210- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -211- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -212- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -213- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -214- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -215- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -216- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -219- DISPLAY 'INICIO EM1139B    ' WTIME-DAYR. */
            _.Display($"INICIO EM1139B    {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -222- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -223- DISPLAY '                    ' . */
            _.Display($"                    ");

            /*" -224- DISPLAY 'DATA SISTEMA CB ... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA SISTEMA CB ... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -227- DISPLAY '                    ' . */
            _.Display($"                    ");

            /*" -227- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -239- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -245- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -250- DISPLAY 'EM1139B - SISTEMA CB NAO ESTA CADASTRADO' */
                _.Display($"EM1139B - SISTEMA CB NAO ESTA CADASTRADO");

                /*" -250- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -245- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0290-00-TRATA-PARCEHIS-SECTION */
        private void R0290_00_TRATA_PARCEHIS_SECTION()
        {
            /*" -263- MOVE '0290' TO WNR-EXEC-SQL. */
            _.Move("0290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -264- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -265- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -266- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -267- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -268- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -269- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -272- DISPLAY 'DECLARE PARCEHIS  ' WTIME-DAYR. */
            _.Display($"DECLARE PARCEHIS  {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

            /*" -274- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -275- PERFORM R0300-00-DECLARE-V0PARCEHIS. */

            R0300_00_DECLARE_V0PARCEHIS_SECTION();

            /*" -277- PERFORM R0310-00-FETCH-V0PARCEHIS. */

            R0310_00_FETCH_V0PARCEHIS_SECTION();

            /*" -281- PERFORM R0350-00-PROCESSA-V0PARCEHIS UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_V0PARCEHIS_SECTION();
            }

            /*" -281- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -285- DISPLAY ' ' . */
            _.Display($" ");

            /*" -286- DISPLAY 'LIDOS PARCEHIS ............. ' LD-V0PARCEHIS */
            _.Display($"LIDOS PARCEHIS ............. {AREA_DE_WORK.LD_V0PARCEHIS}");

            /*" -287- DISPLAY ' ' */
            _.Display($" ");

            /*" -288- DISPLAY 'INCLUIDOS GE397 ............ ' IN-GE397. */
            _.Display($"INCLUIDOS GE397 ............ {AREA_DE_WORK.IN_GE397}");

            /*" -289- DISPLAY 'INCLUIDOS GE398 ............ ' IN-GE398. */
            _.Display($"INCLUIDOS GE398 ............ {AREA_DE_WORK.IN_GE398}");

            /*" -289- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0290_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0PARCEHIS-SECTION */
        private void R0300_00_DECLARE_V0PARCEHIS_SECTION()
        {
            /*" -302- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -304- MOVE 90 TO APOLICOB-RAMO-COBERTURA. */
            _.Move(90, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

            /*" -308- MOVE 05 TO APOLICOB-COD-COBERTURA. */
            _.Move(05, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

            /*" -348- PERFORM R0300_00_DECLARE_V0PARCEHIS_DB_DECLARE_1 */

            R0300_00_DECLARE_V0PARCEHIS_DB_DECLARE_1();

            /*" -350- PERFORM R0300_00_DECLARE_V0PARCEHIS_DB_OPEN_1 */

            R0300_00_DECLARE_V0PARCEHIS_DB_OPEN_1();

            /*" -353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -354- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (V0PARCEHIS) ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (V0PARCEHIS) ");

                /*" -357- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -358- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -359- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -360- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -361- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -362- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -363- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -363- DISPLAY 'FETCH   PARCEHIS  ' WTIME-DAYR. */
            _.Display($"FETCH   PARCEHIS  {AREA_DE_WORK.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0PARCEHIS-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0PARCEHIS_DB_DECLARE_1()
        {
            /*" -348- EXEC SQL DECLARE V0PARCEHIS CURSOR WITH HOLD FOR SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.COD_COSSEGURADORA , B.RAMO_COBERTURA , B.COD_COBERTURA , B.IMP_SEGURADA_VAR , B.PRM_TARIFARIO_VAR , C.DATA_MOVIMENTO , E.DATA_INIVIGENCIA , D.PCT_COM_COSSEGURO FROM SEGUROS.ORDEM_COSSEGCED A, SEGUROS.APOLICE_COBERTURAS B, SEGUROS.PARCELA_HISTORICO C, SEGUROS.APOL_COSSEGURADORA D, SEGUROS.ENDOSSOS E WHERE C.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND C.COD_OPERACAO BETWEEN 200 AND 299 AND C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.NUM_APOLICE = E.NUM_APOLICE AND C.NUM_ENDOSSO = E.NUM_ENDOSSO AND B.NUM_APOLICE = C.NUM_APOLICE AND B.NUM_ENDOSSO = C.NUM_ENDOSSO AND B.NUM_ITEM = 0 AND B.COD_COBERTURA = :APOLICOB-COD-COBERTURA AND B.RAMO_COBERTURA = :APOLICOB-RAMO-COBERTURA AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_APOLICE = E.NUM_APOLICE AND B.NUM_ENDOSSO = E.NUM_ENDOSSO AND D.NUM_APOLICE = A.NUM_APOLICE AND D.COD_COSSEGURADORA = A.COD_COSSEGURADORA AND D.NUM_APOLICE = B.NUM_APOLICE AND D.NUM_APOLICE = C.NUM_APOLICE AND D.NUM_APOLICE = E.NUM_APOLICE AND D.DATA_INIVIGENCIA <= E.DATA_INIVIGENCIA AND D.DATA_TERVIGENCIA >= E.DATA_INIVIGENCIA WITH UR END-EXEC. */
            V0PARCEHIS = new EM1139B_V0PARCEHIS(true);
            string GetQuery_V0PARCEHIS()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.COD_COSSEGURADORA
							, 
							B.RAMO_COBERTURA
							, 
							B.COD_COBERTURA
							, 
							B.IMP_SEGURADA_VAR
							, 
							B.PRM_TARIFARIO_VAR
							, 
							C.DATA_MOVIMENTO
							, 
							E.DATA_INIVIGENCIA
							, 
							D.PCT_COM_COSSEGURO 
							FROM SEGUROS.ORDEM_COSSEGCED A
							, 
							SEGUROS.APOLICE_COBERTURAS B
							, 
							SEGUROS.PARCELA_HISTORICO C
							, 
							SEGUROS.APOL_COSSEGURADORA D
							, 
							SEGUROS.ENDOSSOS E 
							WHERE C.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND C.COD_OPERACAO BETWEEN 200 AND 299 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND C.NUM_APOLICE = E.NUM_APOLICE 
							AND C.NUM_ENDOSSO = E.NUM_ENDOSSO 
							AND B.NUM_APOLICE = C.NUM_APOLICE 
							AND B.NUM_ENDOSSO = C.NUM_ENDOSSO 
							AND B.NUM_ITEM = 0 
							AND B.COD_COBERTURA = '{APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}' 
							AND B.RAMO_COBERTURA = '{APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_APOLICE = E.NUM_APOLICE 
							AND B.NUM_ENDOSSO = E.NUM_ENDOSSO 
							AND D.NUM_APOLICE = A.NUM_APOLICE 
							AND D.COD_COSSEGURADORA = A.COD_COSSEGURADORA 
							AND D.NUM_APOLICE = B.NUM_APOLICE 
							AND D.NUM_APOLICE = C.NUM_APOLICE 
							AND D.NUM_APOLICE = E.NUM_APOLICE 
							AND D.DATA_INIVIGENCIA <= E.DATA_INIVIGENCIA 
							AND D.DATA_TERVIGENCIA >= E.DATA_INIVIGENCIA";

                return query;
            }
            V0PARCEHIS.GetQueryEvent += GetQuery_V0PARCEHIS;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0PARCEHIS-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0PARCEHIS_DB_OPEN_1()
        {
            /*" -350- EXEC SQL OPEN V0PARCEHIS END-EXEC. */

            V0PARCEHIS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0PARCEHIS-SECTION */
        private void R0310_00_FETCH_V0PARCEHIS_SECTION()
        {
            /*" -376- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -387- PERFORM R0310_00_FETCH_V0PARCEHIS_DB_FETCH_1 */

            R0310_00_FETCH_V0PARCEHIS_DB_FETCH_1();

            /*" -391- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -391- PERFORM R0310_00_FETCH_V0PARCEHIS_DB_CLOSE_1 */

                R0310_00_FETCH_V0PARCEHIS_DB_CLOSE_1();

                /*" -393- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -395- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -396- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -397- DISPLAY 'R0310-00 - PROBLEMAS FETCH (V0PARCEHIS)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH (V0PARCEHIS)   ");

                /*" -400- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -402- ADD 1 TO LD-V0PARCEHIS. */
            AREA_DE_WORK.LD_V0PARCEHIS.Value = AREA_DE_WORK.LD_V0PARCEHIS + 1;

            /*" -404- MOVE LD-V0PARCEHIS TO AC-LIDOS. */
            _.Move(AREA_DE_WORK.LD_V0PARCEHIS, AREA_DE_WORK.AC_LIDOS);

            /*" -406- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (AREA_DE_WORK.FILLER_0.LD_PARTE2 == 00 || AREA_DE_WORK.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -407- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -408- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -409- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -410- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -411- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -412- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -413- DISPLAY 'LIDOS PARCEHIS     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS PARCEHIS     {AREA_DE_WORK.AC_LIDOS}    {AREA_DE_WORK.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-V0PARCEHIS-DB-FETCH-1 */
        public void R0310_00_FETCH_V0PARCEHIS_DB_FETCH_1()
        {
            /*" -387- EXEC SQL FETCH V0PARCEHIS INTO :ORDEMCOS-NUM-APOLICE , :ORDEMCOS-NUM-ENDOSSO , :ORDEMCOS-COD-COSSEGURADORA , :APOLICOB-RAMO-COBERTURA , :APOLICOB-COD-COBERTURA , :APOLICOB-IMP-SEGURADA-VAR , :APOLICOB-PRM-TARIFARIO-VAR , :PARCEHIS-DATA-MOVIMENTO , :ENDOSSOS-DATA-INIVIGENCIA , :APOLCOSS-PCT-COM-COSSEGURO END-EXEC. */

            if (V0PARCEHIS.Fetch())
            {
                _.Move(V0PARCEHIS.ORDEMCOS_NUM_APOLICE, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE);
                _.Move(V0PARCEHIS.ORDEMCOS_NUM_ENDOSSO, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO);
                _.Move(V0PARCEHIS.ORDEMCOS_COD_COSSEGURADORA, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA);
                _.Move(V0PARCEHIS.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(V0PARCEHIS.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(V0PARCEHIS.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(V0PARCEHIS.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
                _.Move(V0PARCEHIS.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
                _.Move(V0PARCEHIS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(V0PARCEHIS.APOLCOSS_PCT_COM_COSSEGURO, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_COM_COSSEGURO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0PARCEHIS-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0PARCEHIS_DB_CLOSE_1()
        {
            /*" -391- EXEC SQL CLOSE V0PARCEHIS END-EXEC */

            V0PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-V0PARCEHIS-SECTION */
        private void R0350_00_PROCESSA_V0PARCEHIS_SECTION()
        {
            /*" -426- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -428- MOVE ORDEMCOS-NUM-APOLICE TO GE397-NUM-APOLICE. */
            _.Move(ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NUM_APOLICE);

            /*" -430- MOVE ORDEMCOS-NUM-ENDOSSO TO GE397-NUM-ENDOSSO. */
            _.Move(ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NUM_ENDOSSO);

            /*" -432- MOVE APOLICOB-RAMO-COBERTURA TO GE397-COD-RAMO-COBER. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER);

            /*" -434- MOVE APOLICOB-COD-COBERTURA TO GE397-COD-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_COBERTURA);

            /*" -436- MOVE APOLICOB-IMP-SEGURADA-VAR TO GE397-VLR-IMP-SEGUR-VAR. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_IMP_SEGUR_VAR);

            /*" -438- MOVE APOLICOB-PRM-TARIFARIO-VAR TO GE397-VLR-PREMIO-TARIF-VAR. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_PREMIO_TARIF_VAR);

            /*" -442- MOVE 'EM1139B' TO GE397-NOM-PROGRAMA. */
            _.Move("EM1139B", GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NOM_PROGRAMA);

            /*" -445- PERFORM R0510-00-INSERT-GE397. */

            R0510_00_INSERT_GE397_SECTION();

            /*" -447- MOVE ORDEMCOS-NUM-APOLICE TO GE398-NUM-APOLICE. */
            _.Move(ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_NUM_APOLICE);

            /*" -449- MOVE ORDEMCOS-NUM-ENDOSSO TO GE398-NUM-ENDOSSO. */
            _.Move(ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_NUM_ENDOSSO);

            /*" -451- MOVE APOLICOB-RAMO-COBERTURA TO GE398-COD-RAMO-COBER. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_RAMO_COBER);

            /*" -453- MOVE APOLICOB-COD-COBERTURA TO GE398-COD-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_COBERTURA);

            /*" -455- MOVE ORDEMCOS-COD-COSSEGURADORA TO GE398-COD-COSSEGURADORA. */
            _.Move(ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_COSSEGURADORA);

            /*" -457- MOVE 100 TO GE398-PCT-PARTIC-COBER. */
            _.Move(100, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_PARTIC_COBER);

            /*" -459- MOVE APOLCOSS-PCT-COM-COSSEGURO TO GE398-PCT-COMCOS-COBER. */
            _.Move(APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_PCT_COM_COSSEGURO, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_COMCOS_COBER);

            /*" -462- MOVE 'EM1139B' TO GE398-NOM-PROGRAMA. */
            _.Move("EM1139B", GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_NOM_PROGRAMA);

            /*" -463- IF ENDOSSOS-DATA-INIVIGENCIA GREATER '2014-06-05' */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2014-06-05")
            {

                /*" -467- MOVE 95 TO GE398-PCT-PARTIC-COBER. */
                _.Move(95, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_PARTIC_COBER);
            }


            /*" -467- PERFORM R0520-00-INSERT-GE398. */

            R0520_00_INSERT_GE398_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -472- PERFORM R0310-00-FETCH-V0PARCEHIS. */

            R0310_00_FETCH_V0PARCEHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-INSERT-GE397-SECTION */
        private void R0510_00_INSERT_GE397_SECTION()
        {
            /*" -484- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -503- PERFORM R0510_00_INSERT_GE397_DB_INSERT_1 */

            R0510_00_INSERT_GE397_DB_INSERT_1();

            /*" -507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -508- DISPLAY 'R0510-00 - PROBLEMAS NO INSERT(GE397   )   ' */
                _.Display($"R0510-00 - PROBLEMAS NO INSERT(GE397   )   ");

                /*" -511- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -511- ADD 1 TO IN-GE397. */
            AREA_DE_WORK.IN_GE397.Value = AREA_DE_WORK.IN_GE397 + 1;

        }

        [StopWatch]
        /*" R0510-00-INSERT-GE397-DB-INSERT-1 */
        public void R0510_00_INSERT_GE397_DB_INSERT_1()
        {
            /*" -503- EXEC SQL INSERT INTO SEGUROS.GE_ENDOS_COSSEG_COBER (NUM_APOLICE ,NUM_ENDOSSO ,COD_RAMO_COBER ,COD_COBERTURA ,VLR_IMP_SEGUR_VAR ,VLR_PREMIO_TARIF_VAR ,NOM_PROGRAMA ,DTH_CADASTRAMENTO) VALUES (:GE397-NUM-APOLICE ,:GE397-NUM-ENDOSSO ,:GE397-COD-RAMO-COBER ,:GE397-COD-COBERTURA ,:GE397-VLR-IMP-SEGUR-VAR ,:GE397-VLR-PREMIO-TARIF-VAR ,:GE397-NOM-PROGRAMA , CURRENT TIMESTAMP) END-EXEC. */

            var r0510_00_INSERT_GE397_DB_INSERT_1_Insert1 = new R0510_00_INSERT_GE397_DB_INSERT_1_Insert1()
            {
                GE397_NUM_APOLICE = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NUM_APOLICE.ToString(),
                GE397_NUM_ENDOSSO = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NUM_ENDOSSO.ToString(),
                GE397_COD_RAMO_COBER = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER.ToString(),
                GE397_COD_COBERTURA = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_COBERTURA.ToString(),
                GE397_VLR_IMP_SEGUR_VAR = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_IMP_SEGUR_VAR.ToString(),
                GE397_VLR_PREMIO_TARIF_VAR = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_PREMIO_TARIF_VAR.ToString(),
                GE397_NOM_PROGRAMA = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NOM_PROGRAMA.ToString(),
            };

            R0510_00_INSERT_GE397_DB_INSERT_1_Insert1.Execute(r0510_00_INSERT_GE397_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-INSERT-GE398-SECTION */
        private void R0520_00_INSERT_GE398_SECTION()
        {
            /*" -524- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -545- PERFORM R0520_00_INSERT_GE398_DB_INSERT_1 */

            R0520_00_INSERT_GE398_DB_INSERT_1();

            /*" -549- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -550- DISPLAY 'R0520-00 - PROBLEMAS NO INSERT(GE398   )   ' */
                _.Display($"R0520-00 - PROBLEMAS NO INSERT(GE398   )   ");

                /*" -553- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -553- ADD 1 TO IN-GE398. */
            AREA_DE_WORK.IN_GE398.Value = AREA_DE_WORK.IN_GE398 + 1;

        }

        [StopWatch]
        /*" R0520-00-INSERT-GE398-DB-INSERT-1 */
        public void R0520_00_INSERT_GE398_DB_INSERT_1()
        {
            /*" -545- EXEC SQL INSERT INTO SEGUROS.GE_ENDOS_PCT_PART_COBER (NUM_APOLICE ,NUM_ENDOSSO ,COD_RAMO_COBER ,COD_COBERTURA ,COD_COSSEGURADORA ,PCT_PARTIC_COBER ,PCT_COMCOS_COBER ,NOM_PROGRAMA ,DTH_CADASTRAMENTO) VALUES (:GE398-NUM-APOLICE ,:GE398-NUM-ENDOSSO ,:GE398-COD-RAMO-COBER ,:GE398-COD-COBERTURA ,:GE398-COD-COSSEGURADORA ,:GE398-PCT-PARTIC-COBER ,:GE398-PCT-COMCOS-COBER ,:GE398-NOM-PROGRAMA , CURRENT TIMESTAMP) END-EXEC. */

            var r0520_00_INSERT_GE398_DB_INSERT_1_Insert1 = new R0520_00_INSERT_GE398_DB_INSERT_1_Insert1()
            {
                GE398_NUM_APOLICE = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_NUM_APOLICE.ToString(),
                GE398_NUM_ENDOSSO = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_NUM_ENDOSSO.ToString(),
                GE398_COD_RAMO_COBER = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_RAMO_COBER.ToString(),
                GE398_COD_COBERTURA = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_COBERTURA.ToString(),
                GE398_COD_COSSEGURADORA = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_COSSEGURADORA.ToString(),
                GE398_PCT_PARTIC_COBER = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_PARTIC_COBER.ToString(),
                GE398_PCT_COMCOS_COBER = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_COMCOS_COBER.ToString(),
                GE398_NOM_PROGRAMA = GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_NOM_PROGRAMA.ToString(),
            };

            R0520_00_INSERT_GE398_DB_INSERT_1_Insert1.Execute(r0520_00_INSERT_GE398_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -565- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -567- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -570- DISPLAY LD99-ABEND. */
            _.Display(LD99_ABEND);

            /*" -570- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -574- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -575- DISPLAY ' ' */
            _.Display($" ");

            /*" -576- DISPLAY 'EM1139B - FIM COM ERRO     ' . */
            _.Display($"EM1139B - FIM COM ERRO     ");

            /*" -578- DISPLAY ' ' . */
            _.Display($" ");

            /*" -578- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}