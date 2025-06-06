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
using Sias.Bilhetes.DB2.BI2002B;

namespace Code
{
    public class BI2002B
    {
        public bool IsCall { get; set; }

        public BI2002B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI2002B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  29/05/2018                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  - BAIXA APOLICES PARA REGISTROS    *      */
        /*"      *   CADASTRADOS NA TABELA SEGUROS.MOVIMENTO_COBRANCA COM         *      */
        /*"      *   TIPO_MOVIMENTO = 'B'.                                        *      */
        /*"      *   UM BOLETO PARA DIVERSAS PARCELAS.                            *      */
        /*"      *                                                                *      */
        /*"      *                               HISTORIA 26310.                  *      */
        /*"      *                               TAREFA   28990.                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public BI2002B_W W { get; set; } = new BI2002B_W();
        public class BI2002B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMCOB             PIC  X(001)       VALUE 'N'.*/
            public StringBasis WFIM_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-CBCONDEV             PIC  X(001)       VALUE 'N'.*/
            public StringBasis WFIM_CBCONDEV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-MOVIMCOB               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis LD_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  LD-CBCONDEV               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis LD_CBCONDEV { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-MOVIMCOB               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_MOVIMCOB { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-CBCONDEV               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_CBCONDEV { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-PARCEHIS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-PARCELAS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RCAPS                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-RCAPCOMP               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-AVISOSAL               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis UP_AVISOSAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-PARCEHIS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis NT_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-PARCELAS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis NT_PARCELAS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-RCAPS                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis NT_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-RCAPCOMP               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis NT_RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-AVISOSAL               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis NT_AVISOSAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  SE-RCAPS                  PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis SE_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  SE-PARCEHIS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis SE_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  IN-PARCEHIS               PIC  9(009)       VALUE  ZEROS.*/
            public IntBasis IN_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI2002B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI2002B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI2002B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI2002B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI2002B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI2002B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI2002B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI2002B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI2002B_FILLER_1 : VarBasis
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

                public _REDEF_BI2002B_FILLER_1()
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
            private _REDEF_BI2002B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI2002B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI2002B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI2002B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI2002B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI2002B_WTIME_DAYR();
                public class BI2002B_WTIME_DAYR : VarBasis
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

                    public BI2002B_WTIME_DAYR()
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

                public _REDEF_BI2002B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI2002B_WS_TIME WS_TIME { get; set; } = new BI2002B_WS_TIME();
            public class BI2002B_WS_TIME : VarBasis
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
            public BI2002B_WABEND WABEND { get; set; } = new BI2002B_WABEND();
            public class BI2002B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI2002B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI2002B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public BI2002B_V0MOVIMCOB V0MOVIMCOB { get; set; } = new BI2002B_V0MOVIMCOB();
        public BI2002B_V0CBCONDEV V0CBCONDEV { get; set; } = new BI2002B_V0CBCONDEV();
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
            /*" -143- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -144- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -146- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -148- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -151- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -152- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -153- DISPLAY 'PROGRAMA EM EXECUCAO BI2002B      ' */
            _.Display($"PROGRAMA EM EXECUCAO BI2002B      ");

            /*" -154- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -155- DISPLAY 'VERSAO V.00 - 29/05/2018          ' */
            _.Display($"VERSAO V.00 - 29/05/2018          ");

            /*" -156- DISPLAY '                                  ' */
            _.Display($"                                  ");

            /*" -157- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -160- DISPLAY ' ' . */
            _.Display($" ");

            /*" -162- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -165- PERFORM R0190-00-TRATA-MOVIMCOB. */

            R0190_00_TRATA_MOVIMCOB_SECTION();

            /*" -166- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -167- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -168- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -169- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -170- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -171- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -171- DISPLAY 'FIM    BI2002B    ' WTIME-DAYR. */
            _.Display($"FIM    BI2002B    {W.FILLER_4.WTIME_DAYR}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -176- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -180- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -181- DISPLAY ' ' */
            _.Display($" ");

            /*" -182- DISPLAY 'BI2002B - FIM NORMAL' */
            _.Display($"BI2002B - FIM NORMAL");

            /*" -185- DISPLAY ' ' */
            _.Display($" ");

            /*" -185- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -194- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", W.WABEND.WNR_EXEC_SQL);

            /*" -195- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -196- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -197- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -198- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -199- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -200- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -203- DISPLAY 'INICIO BI2002B    ' WTIME-DAYR. */
            _.Display($"INICIO BI2002B    {W.FILLER_4.WTIME_DAYR}");

            /*" -206- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -207- DISPLAY ' ' . */
            _.Display($" ");

            /*" -209- DISPLAY 'DATA DE MOVIMENTO ..... ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DE MOVIMENTO ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -212- DISPLAY ' ' . */
            _.Display($" ");

            /*" -212- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -225- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -232- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -236- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -237- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -237- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -232- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0190-00-TRATA-MOVIMCOB-SECTION */
        private void R0190_00_TRATA_MOVIMCOB_SECTION()
        {
            /*" -250- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", W.WABEND.WNR_EXEC_SQL);

            /*" -251- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -252- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -253- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -254- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -255- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -256- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -259- DISPLAY 'DECLARE MOVIMCOB  ' WTIME-DAYR. */
            _.Display($"DECLARE MOVIMCOB  {W.FILLER_4.WTIME_DAYR}");

            /*" -261- MOVE SPACES TO WFIM-MOVIMCOB. */
            _.Move("", W.WFIM_MOVIMCOB);

            /*" -262- PERFORM R0200-00-DECLARE-MOVIMCOB. */

            R0200_00_DECLARE_MOVIMCOB_SECTION();

            /*" -264- PERFORM R0210-00-FETCH-MOVIMCOB. */

            R0210_00_FETCH_MOVIMCOB_SECTION();

            /*" -268- PERFORM R0220-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMCOB NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMCOB.IsEmpty()))
            {

                R0220_00_PROCESSA_MOVIMCOB_SECTION();
            }

            /*" -268- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -271- DISPLAY ' ' . */
            _.Display($" ");

            /*" -272- DISPLAY 'LIDOS  MOVIMCOB ............ ' LD-MOVIMCOB */
            _.Display($"LIDOS  MOVIMCOB ............ {W.LD_MOVIMCOB}");

            /*" -273- DISPLAY 'ALTERA MOVIMCOB ............ ' UP-MOVIMCOB */
            _.Display($"ALTERA MOVIMCOB ............ {W.UP_MOVIMCOB}");

            /*" -274- DISPLAY ' ' . */
            _.Display($" ");

            /*" -275- DISPLAY 'LIDOS  CBCONDEV ............ ' LD-CBCONDEV */
            _.Display($"LIDOS  CBCONDEV ............ {W.LD_CBCONDEV}");

            /*" -276- DISPLAY 'ALTERA CBCONDEV ............ ' UP-CBCONDEV */
            _.Display($"ALTERA CBCONDEV ............ {W.UP_CBCONDEV}");

            /*" -277- DISPLAY ' ' . */
            _.Display($" ");

            /*" -278- DISPLAY 'SEM    PARCEHIS............. ' NT-PARCEHIS */
            _.Display($"SEM    PARCEHIS............. {W.NT_PARCEHIS}");

            /*" -279- DISPLAY 'ALTERA PARCEHIS ............ ' UP-PARCEHIS */
            _.Display($"ALTERA PARCEHIS ............ {W.UP_PARCEHIS}");

            /*" -280- DISPLAY ' ' . */
            _.Display($" ");

            /*" -281- DISPLAY 'SEM    PARCELAS............. ' NT-PARCELAS */
            _.Display($"SEM    PARCELAS............. {W.NT_PARCELAS}");

            /*" -282- DISPLAY 'ALTERA PARCELAS ............ ' UP-PARCELAS */
            _.Display($"ALTERA PARCELAS ............ {W.UP_PARCELAS}");

            /*" -283- DISPLAY ' ' . */
            _.Display($" ");

            /*" -284- DISPLAY 'NAO    RCAPS ............... ' SE-RCAPS */
            _.Display($"NAO    RCAPS ............... {W.SE_RCAPS}");

            /*" -285- DISPLAY 'SEM    RCAPS ............... ' NT-RCAPS */
            _.Display($"SEM    RCAPS ............... {W.NT_RCAPS}");

            /*" -286- DISPLAY 'ALTERA RCAPS ............... ' UP-RCAPS */
            _.Display($"ALTERA RCAPS ............... {W.UP_RCAPS}");

            /*" -287- DISPLAY ' ' . */
            _.Display($" ");

            /*" -288- DISPLAY 'SEM    RCAPCOMP ............ ' NT-RCAPCOMP */
            _.Display($"SEM    RCAPCOMP ............ {W.NT_RCAPCOMP}");

            /*" -289- DISPLAY 'ALTERA RCAPCOMP ............ ' UP-RCAPCOMP */
            _.Display($"ALTERA RCAPCOMP ............ {W.UP_RCAPCOMP}");

            /*" -290- DISPLAY ' ' . */
            _.Display($" ");

            /*" -291- DISPLAY 'SEM    AVISOSAL ............ ' NT-AVISOSAL */
            _.Display($"SEM    AVISOSAL ............ {W.NT_AVISOSAL}");

            /*" -292- DISPLAY 'ALTERA AVISOSAL ............ ' UP-AVISOSAL */
            _.Display($"ALTERA AVISOSAL ............ {W.UP_AVISOSAL}");

            /*" -293- DISPLAY ' ' . */
            _.Display($" ");

            /*" -294- DISPLAY 'NAO    PARCEHIS............. ' SE-PARCEHIS */
            _.Display($"NAO    PARCEHIS............. {W.SE_PARCEHIS}");

            /*" -295- DISPLAY 'INSERT PARCEHIS............. ' IN-PARCEHIS */
            _.Display($"INSERT PARCEHIS............. {W.IN_PARCEHIS}");

            /*" -295- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-MOVIMCOB-SECTION */
        private void R0200_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -308- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -325- PERFORM R0200_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R0200_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -327- PERFORM R0200_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R0200_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -330- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -331- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (MOVIMCOB)   ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (MOVIMCOB)   ");

                /*" -334- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -335- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -336- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -337- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -338- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -339- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -340- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -340- DISPLAY 'FETCH   MOVIMCOB  ' WTIME-DAYR. */
            _.Display($"FETCH   MOVIMCOB  {W.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R0200-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R0200_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -325- EXEC SQL DECLARE V0MOVIMCOB CURSOR WITH HOLD FOR SELECT COD_BANCO ,COD_AGENCIA ,NUM_AVISO ,DATA_MOVIMENTO ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,VAL_TITULO ,SIT_REGISTRO ,TIPO_MOVIMENTO ,NUM_NOSSO_TITULO FROM SEGUROS.MOVIMENTO_COBRANCA WHERE TIPO_MOVIMENTO = 'B' AND SIT_REGISTRO = ' ' FOR UPDATE OF SIT_REGISTRO END-EXEC. */
            V0MOVIMCOB = new BI2002B_V0MOVIMCOB(false);
            string GetQuery_V0MOVIMCOB()
            {
                var query = @$"SELECT COD_BANCO 
							,COD_AGENCIA 
							,NUM_AVISO 
							,DATA_MOVIMENTO 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,VAL_TITULO 
							,SIT_REGISTRO 
							,TIPO_MOVIMENTO 
							,NUM_NOSSO_TITULO 
							FROM SEGUROS.MOVIMENTO_COBRANCA 
							WHERE TIPO_MOVIMENTO = 'B' 
							AND SIT_REGISTRO = ' '";

                return query;
            }
            V0MOVIMCOB.GetQueryEvent += GetQuery_V0MOVIMCOB;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R0200_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -327- EXEC SQL OPEN V0MOVIMCOB END-EXEC. */

            V0MOVIMCOB.Open();

        }

        [StopWatch]
        /*" R0300-00-DECLARE-CBCONDEV-DB-DECLARE-1 */
        public void R0300_00_DECLARE_CBCONDEV_DB_DECLARE_1()
        {
            /*" -485- EXEC SQL DECLARE V0CBCONDEV CURSOR WITH HOLD FOR SELECT NUM_TITULO ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_MATRICULA ,COD_PRODUTO ,SIT_REGISTRO ,VAL_TITULO FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE COD_EMPRESA = 0 AND TIPO_MOVIMENTO = 'A' AND NUM_CHEQUE_INTERNO = 1 AND DIG_CHEQUE_INTERNO = 0 AND NUM_CERTIFICADO = :CBCONDEV-NUM-CERTIFICADO AND SIT_REGISTRO = '1' FOR UPDATE OF SIT_REGISTRO END-EXEC. */
            V0CBCONDEV = new BI2002B_V0CBCONDEV(false);
            string GetQuery_V0CBCONDEV()
            {
                var query = @$"SELECT NUM_TITULO 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,NUM_CERTIFICADO 
							,NUM_MATRICULA 
							,COD_PRODUTO 
							,SIT_REGISTRO 
							,VAL_TITULO 
							FROM SEGUROS.CB_CONTR_DEVPREMIO 
							WHERE COD_EMPRESA = 0 
							AND TIPO_MOVIMENTO = 'A' 
							AND NUM_CHEQUE_INTERNO = 1 
							AND DIG_CHEQUE_INTERNO = 0 
							AND NUM_CERTIFICADO = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO} 
							AND SIT_REGISTRO = '1'";

                return query;
            }
            V0CBCONDEV.GetQueryEvent += GetQuery_V0CBCONDEV;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-MOVIMCOB-SECTION */
        private void R0210_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -353- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -365- PERFORM R0210_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R0210_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -369- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -369- PERFORM R0210_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                R0210_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                /*" -371- MOVE 'S' TO WFIM-MOVIMCOB */
                _.Move("S", W.WFIM_MOVIMCOB);

                /*" -373- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -374- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -379- DISPLAY 'R0210-00 - PROBLEMAS FETCH (MOVIMCOB)     ' ' APOLICE    ' MOVIMCOB-NUM-APOLICE ' ENDOSSO    ' MOVIMCOB-NUM-ENDOSSO ' PARCELA    ' MOVIMCOB-NUM-PARCELA ' TITULO     ' MOVIMCOB-NUM-NOSSO-TITULO */

                $"R0210-00 - PROBLEMAS FETCH (MOVIMCOB)      APOLICE    {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE} ENDOSSO    {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO} PARCELA    {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA} TITULO     {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                .Display();

                /*" -382- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -384- ADD 1 TO LD-MOVIMCOB. */
            W.LD_MOVIMCOB.Value = W.LD_MOVIMCOB + 1;

            /*" -386- MOVE LD-MOVIMCOB TO AC-LIDOS. */
            _.Move(W.LD_MOVIMCOB, W.AC_LIDOS);

            /*" -388- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -389- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -390- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -391- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -392- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -393- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -394- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -395- DISPLAY 'LIDOS MOVIMCOB     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS MOVIMCOB     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0210-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R0210_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -365- EXEC SQL FETCH V0MOVIMCOB INTO :MOVIMCOB-COD-BANCO ,:MOVIMCOB-COD-AGENCIA ,:MOVIMCOB-NUM-AVISO ,:MOVIMCOB-DATA-MOVIMENTO ,:MOVIMCOB-NUM-APOLICE ,:MOVIMCOB-NUM-ENDOSSO ,:MOVIMCOB-NUM-PARCELA ,:MOVIMCOB-VAL-TITULO ,:MOVIMCOB-SIT-REGISTRO ,:MOVIMCOB-TIPO-MOVIMENTO ,:MOVIMCOB-NUM-NOSSO-TITULO END-EXEC. */

            if (V0MOVIMCOB.Fetch())
            {
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(V0MOVIMCOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(V0MOVIMCOB.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(V0MOVIMCOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(V0MOVIMCOB.MOVIMCOB_SIT_REGISTRO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_SIT_REGISTRO);
                _.Move(V0MOVIMCOB.MOVIMCOB_TIPO_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_TIPO_MOVIMENTO);
                _.Move(V0MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R0210_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -369- EXEC SQL CLOSE V0MOVIMCOB END-EXEC */

            V0MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-MOVIMCOB-SECTION */
        private void R0220_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -408- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -411- MOVE MOVIMCOB-NUM-NOSSO-TITULO TO CBCONDEV-NUM-CERTIFICADO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -413- MOVE SPACES TO WFIM-CBCONDEV. */
            _.Move("", W.WFIM_CBCONDEV);

            /*" -414- PERFORM R0300-00-DECLARE-CBCONDEV. */

            R0300_00_DECLARE_CBCONDEV_SECTION();

            /*" -416- PERFORM R0310-00-FETCH-CBCONDEV. */

            R0310_00_FETCH_CBCONDEV_SECTION();

            /*" -420- PERFORM R0320-00-PROCESSA-CBCONDEV UNTIL WFIM-CBCONDEV NOT EQUAL SPACES. */

            while (!(!W.WFIM_CBCONDEV.IsEmpty()))
            {

                R0320_00_PROCESSA_CBCONDEV_SECTION();
            }

            /*" -420- PERFORM R0250-00-UPDATE-MOVIMCOB. */

            R0250_00_UPDATE_MOVIMCOB_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0220_90_LEITURA */

            R0220_90_LEITURA();

        }

        [StopWatch]
        /*" R0220-90-LEITURA */
        private void R0220_90_LEITURA(bool isPerform = false)
        {
            /*" -425- PERFORM R0210-00-FETCH-MOVIMCOB. */

            R0210_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-UPDATE-MOVIMCOB-SECTION */
        private void R0250_00_UPDATE_MOVIMCOB_SECTION()
        {
            /*" -437- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", W.WABEND.WNR_EXEC_SQL);

            /*" -442- PERFORM R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1 */

            R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1();

            /*" -446- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -451- DISPLAY 'R0250-00 - PROBLEMAS NO UPDATE(MOVIMCOB) ' ' APOLICE    ' MOVIMCOB-NUM-APOLICE ' ENDOSSO    ' MOVIMCOB-NUM-ENDOSSO ' PARCELA    ' MOVIMCOB-NUM-PARCELA ' TITULO     ' MOVIMCOB-NUM-NOSSO-TITULO */

                $"R0250-00 - PROBLEMAS NO UPDATE(MOVIMCOB)  APOLICE    {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE} ENDOSSO    {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO} PARCELA    {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA} TITULO     {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO}"
                .Display();

                /*" -452- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -453- ELSE */
            }
            else
            {


                /*" -453- ADD 1 TO UP-MOVIMCOB. */
                W.UP_MOVIMCOB.Value = W.UP_MOVIMCOB + 1;
            }


        }

        [StopWatch]
        /*" R0250-00-UPDATE-MOVIMCOB-DB-UPDATE-1 */
        public void R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1()
        {
            /*" -442- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET SIT_REGISTRO = '1' WHERE CURRENT OF V0MOVIMCOB END-EXEC. */

            var r0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 = new R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1(V0MOVIMCOB)
            {
            };

            R0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1.Execute(r0250_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-CBCONDEV-SECTION */
        private void R0300_00_DECLARE_CBCONDEV_SECTION()
        {
            /*" -466- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -485- PERFORM R0300_00_DECLARE_CBCONDEV_DB_DECLARE_1 */

            R0300_00_DECLARE_CBCONDEV_DB_DECLARE_1();

            /*" -487- PERFORM R0300_00_DECLARE_CBCONDEV_DB_OPEN_1 */

            R0300_00_DECLARE_CBCONDEV_DB_OPEN_1();

            /*" -490- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -491- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (CBCONDEV)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (CBCONDEV)   ");

                /*" -494- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -495- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -496- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -497- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -498- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -499- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -500- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -500- DISPLAY 'FETCH   CBCONDEV  ' WTIME-DAYR. */
            _.Display($"FETCH   CBCONDEV  {W.FILLER_4.WTIME_DAYR}");

        }

        [StopWatch]
        /*" R0300-00-DECLARE-CBCONDEV-DB-OPEN-1 */
        public void R0300_00_DECLARE_CBCONDEV_DB_OPEN_1()
        {
            /*" -487- EXEC SQL OPEN V0CBCONDEV END-EXEC. */

            V0CBCONDEV.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-CBCONDEV-SECTION */
        private void R0310_00_FETCH_CBCONDEV_SECTION()
        {
            /*" -513- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -523- PERFORM R0310_00_FETCH_CBCONDEV_DB_FETCH_1 */

            R0310_00_FETCH_CBCONDEV_DB_FETCH_1();

            /*" -527- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -527- PERFORM R0310_00_FETCH_CBCONDEV_DB_CLOSE_1 */

                R0310_00_FETCH_CBCONDEV_DB_CLOSE_1();

                /*" -529- MOVE 'S' TO WFIM-CBCONDEV */
                _.Move("S", W.WFIM_CBCONDEV);

                /*" -531- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -532- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -536- DISPLAY 'R0310-00 - PROBLEMAS FETCH (CBCONDEV)     ' ' APOLICE    ' CBCONDEV-NUM-APOLICE ' ENDOSSO    ' CBCONDEV-NUM-ENDOSSO ' PARCELA    ' CBCONDEV-NUM-PARCELA */

                $"R0310-00 - PROBLEMAS FETCH (CBCONDEV)      APOLICE    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE} ENDOSSO    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO} PARCELA    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}"
                .Display();

                /*" -539- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -541- ADD 1 TO LD-CBCONDEV. */
            W.LD_CBCONDEV.Value = W.LD_CBCONDEV + 1;

            /*" -543- MOVE LD-CBCONDEV TO AC-LIDOS. */
            _.Move(W.LD_CBCONDEV, W.AC_LIDOS);

            /*" -545- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -546- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -547- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -548- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -549- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -550- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -551- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -552- DISPLAY 'LIDOS CBCONDEV     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS CBCONDEV     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0310-00-FETCH-CBCONDEV-DB-FETCH-1 */
        public void R0310_00_FETCH_CBCONDEV_DB_FETCH_1()
        {
            /*" -523- EXEC SQL FETCH V0CBCONDEV INTO :CBCONDEV-NUM-TITULO ,:CBCONDEV-NUM-APOLICE ,:CBCONDEV-NUM-ENDOSSO ,:CBCONDEV-NUM-PARCELA ,:CBCONDEV-NUM-CERTIFICADO ,:CBCONDEV-NUM-MATRICULA ,:CBCONDEV-COD-PRODUTO ,:CBCONDEV-SIT-REGISTRO ,:CBCONDEV-VAL-TITULO END-EXEC. */

            if (V0CBCONDEV.Fetch())
            {
                _.Move(V0CBCONDEV.CBCONDEV_NUM_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_APOLICE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_ENDOSSO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_PARCELA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_CERTIFICADO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);
                _.Move(V0CBCONDEV.CBCONDEV_NUM_MATRICULA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA);
                _.Move(V0CBCONDEV.CBCONDEV_COD_PRODUTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO);
                _.Move(V0CBCONDEV.CBCONDEV_SIT_REGISTRO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);
                _.Move(V0CBCONDEV.CBCONDEV_VAL_TITULO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-CBCONDEV-DB-CLOSE-1 */
        public void R0310_00_FETCH_CBCONDEV_DB_CLOSE_1()
        {
            /*" -527- EXEC SQL CLOSE V0CBCONDEV END-EXEC */

            V0CBCONDEV.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-CBCONDEV-SECTION */
        private void R0320_00_PROCESSA_CBCONDEV_SECTION()
        {
            /*" -565- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", W.WABEND.WNR_EXEC_SQL);

            /*" -568- PERFORM R0450-00-UPDATE-CBCONDEV. */

            R0450_00_UPDATE_CBCONDEV_SECTION();

            /*" -569- IF CBCONDEV-NUM-ENDOSSO EQUAL 1 */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO == 1)
            {

                /*" -570- PERFORM R0500-00-UPDATE-PARCEHIS */

                R0500_00_UPDATE_PARCEHIS_SECTION();

                /*" -571- PERFORM R0510-00-UPDATE-PARCELAS */

                R0510_00_UPDATE_PARCELAS_SECTION();

                /*" -572- PERFORM R0520-00-SELECT-RCAPS */

                R0520_00_SELECT_RCAPS_SECTION();

                /*" -573- ELSE */
            }
            else
            {


                /*" -576- PERFORM R0600-00-SELECT-PARCEHIS. */

                R0600_00_SELECT_PARCEHIS_SECTION();
            }


            /*" -576- PERFORM R1000-00-UPDATE-AVISOSAL. */

            R1000_00_UPDATE_AVISOSAL_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_90_LEITURA */

            R0320_90_LEITURA();

        }

        [StopWatch]
        /*" R0320-90-LEITURA */
        private void R0320_90_LEITURA(bool isPerform = false)
        {
            /*" -581- PERFORM R0310-00-FETCH-CBCONDEV. */

            R0310_00_FETCH_CBCONDEV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-UPDATE-CBCONDEV-SECTION */
        private void R0450_00_UPDATE_CBCONDEV_SECTION()
        {
            /*" -593- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1 */

            R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1();

            /*" -602- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -603- DISPLAY 'R0450-00 - PROBLEMAS NO UPDATE(CBCONDEV) ' */
                _.Display($"R0450-00 - PROBLEMAS NO UPDATE(CBCONDEV) ");

                /*" -606- DISPLAY ' APOLICE = ' CBCONDEV-NUM-APOLICE ' ENDOSSO = ' CBCONDEV-NUM-ENDOSSO ' PARCELA = ' CBCONDEV-NUM-PARCELA */

                $" APOLICE = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE} ENDOSSO = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO} PARCELA = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}"
                .Display();

                /*" -607- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -608- ELSE */
            }
            else
            {


                /*" -608- ADD 1 TO UP-CBCONDEV. */
                W.UP_CBCONDEV.Value = W.UP_CBCONDEV + 1;
            }


        }

        [StopWatch]
        /*" R0450-00-UPDATE-CBCONDEV-DB-UPDATE-1 */
        public void R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1()
        {
            /*" -598- EXEC SQL UPDATE SEGUROS.CB_CONTR_DEVPREMIO SET SIT_REGISTRO = '2' WHERE CURRENT OF V0CBCONDEV END-EXEC. */

            var r0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1 = new R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1(V0CBCONDEV)
            {
                CBCONDEV_NUM_CERTIFICADO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO.ToString(),
            };

            R0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1.Execute(r0450_00_UPDATE_CBCONDEV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-UPDATE-PARCEHIS-SECTION */
        private void R0500_00_UPDATE_PARCEHIS_SECTION()
        {
            /*" -621- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", W.WABEND.WNR_EXEC_SQL);

            /*" -625- MOVE 2 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(2, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -635- PERFORM R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1 */

            R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1();

            /*" -639- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -640- ADD 1 TO NT-PARCEHIS */
                W.NT_PARCEHIS.Value = W.NT_PARCEHIS + 1;

                /*" -641- ELSE */
            }
            else
            {


                /*" -642- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -643- DISPLAY 'R0500-00 - PROBLEMAS NO UPDATE(PARCEHIS) ' */
                    _.Display($"R0500-00 - PROBLEMAS NO UPDATE(PARCEHIS) ");

                    /*" -646- DISPLAY ' APOLICE = ' CBCONDEV-NUM-APOLICE ' ENDOSSO = ' CBCONDEV-NUM-ENDOSSO ' PARCELA = ' CBCONDEV-NUM-PARCELA */

                    $" APOLICE = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE} ENDOSSO = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO} PARCELA = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}"
                    .Display();

                    /*" -647- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -648- ELSE */
                }
                else
                {


                    /*" -648- ADD 1 TO UP-PARCEHIS. */
                    W.UP_PARCEHIS.Value = W.UP_PARCEHIS + 1;
                }

            }


        }

        [StopWatch]
        /*" R0500-00-UPDATE-PARCEHIS-DB-UPDATE-1 */
        public void R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1()
        {
            /*" -635- EXEC SQL UPDATE SEGUROS.PARCELA_HISTORICO SET BCO_COBRANCA = :MOVIMCOB-COD-BANCO ,AGE_COBRANCA = :MOVIMCOB-COD-AGENCIA ,NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO WHERE NUM_APOLICE = :CBCONDEV-NUM-APOLICE AND NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO AND NUM_PARCELA = :CBCONDEV-NUM-PARCELA AND OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO END-EXEC. */

            var r0500_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1 = new R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
            };

            R0500_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1.Execute(r0500_00_UPDATE_PARCEHIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-UPDATE-PARCELAS-SECTION */
        private void R0510_00_UPDATE_PARCELAS_SECTION()
        {
            /*" -661- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", W.WABEND.WNR_EXEC_SQL);

            /*" -669- PERFORM R0510_00_UPDATE_PARCELAS_DB_UPDATE_1 */

            R0510_00_UPDATE_PARCELAS_DB_UPDATE_1();

            /*" -673- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -674- ADD 1 TO NT-PARCELAS */
                W.NT_PARCELAS.Value = W.NT_PARCELAS + 1;

                /*" -675- ELSE */
            }
            else
            {


                /*" -676- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -677- DISPLAY 'R0510-00 - PROBLEMAS NO UPDATE(PARCELAS) ' */
                    _.Display($"R0510-00 - PROBLEMAS NO UPDATE(PARCELAS) ");

                    /*" -680- DISPLAY ' APOLICE = ' CBCONDEV-NUM-APOLICE ' ENDOSSO = ' CBCONDEV-NUM-ENDOSSO ' PARCELA = ' CBCONDEV-NUM-PARCELA */

                    $" APOLICE = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE} ENDOSSO = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO} PARCELA = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}"
                    .Display();

                    /*" -681- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -682- ELSE */
                }
                else
                {


                    /*" -682- ADD 1 TO UP-PARCELAS. */
                    W.UP_PARCELAS.Value = W.UP_PARCELAS + 1;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-UPDATE-PARCELAS-DB-UPDATE-1 */
        public void R0510_00_UPDATE_PARCELAS_DB_UPDATE_1()
        {
            /*" -669- EXEC SQL UPDATE SEGUROS.PARCELAS SET OCORR_HISTORICO = :PARCEHIS-OCORR-HISTORICO ,SIT_REGISTRO = '1' WHERE NUM_APOLICE = :CBCONDEV-NUM-APOLICE AND NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO AND NUM_PARCELA = :CBCONDEV-NUM-PARCELA END-EXEC. */

            var r0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1 = new R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1()
            {
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
            };

            R0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1.Execute(r0510_00_UPDATE_PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0520-00-SELECT-RCAPS-SECTION */
        private void R0520_00_SELECT_RCAPS_SECTION()
        {
            /*" -694- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", W.WABEND.WNR_EXEC_SQL);

            /*" -702- PERFORM R0520_00_SELECT_RCAPS_DB_SELECT_1 */

            R0520_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -706- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -707- ADD 1 TO SE-RCAPS */
                W.SE_RCAPS.Value = W.SE_RCAPS + 1;

                /*" -708- ELSE */
            }
            else
            {


                /*" -709- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -710- DISPLAY ' TITULO  = ' CBCONDEV-NUM-TITULO */
                    _.Display($" TITULO  = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO}");

                    /*" -711- DISPLAY 'R0520-00 - PROBLEMAS NO SELECT(RCAPS)    ' */
                    _.Display($"R0520-00 - PROBLEMAS NO SELECT(RCAPS)    ");

                    /*" -712- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -713- ELSE */
                }
                else
                {


                    /*" -714- PERFORM R0540-00-UPDATE-RCAPS */

                    R0540_00_UPDATE_RCAPS_SECTION();

                    /*" -714- PERFORM R0550-00-UPDATE-RCAPCOMP. */

                    R0550_00_UPDATE_RCAPCOMP_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0520-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R0520_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -702- EXEC SQL SELECT COD_FONTE ,NUM_RCAP INTO :RCAPS-COD-FONTE ,:RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_TITULO = :CBCONDEV-NUM-TITULO WITH UR END-EXEC. */

            var r0520_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                CBCONDEV_NUM_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO.ToString(),
            };

            var executed_1 = R0520_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r0520_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0540-00-UPDATE-RCAPS-SECTION */
        private void R0540_00_UPDATE_RCAPS_SECTION()
        {
            /*" -727- MOVE '0540' TO WNR-EXEC-SQL. */
            _.Move("0540", W.WABEND.WNR_EXEC_SQL);

            /*" -736- PERFORM R0540_00_UPDATE_RCAPS_DB_UPDATE_1 */

            R0540_00_UPDATE_RCAPS_DB_UPDATE_1();

            /*" -740- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -741- ADD 1 TO NT-RCAPS */
                W.NT_RCAPS.Value = W.NT_RCAPS + 1;

                /*" -742- ELSE */
            }
            else
            {


                /*" -743- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -744- DISPLAY 'R0540-00 - PROBLEMAS NO UPDATE(RCAPS)    ' */
                    _.Display($"R0540-00 - PROBLEMAS NO UPDATE(RCAPS)    ");

                    /*" -746- DISPLAY ' FONTE   = ' RCAPS-COD-FONTE ' RCAP    = ' RCAPS-NUM-RCAP */

                    $" FONTE   = {RCAPS.DCLRCAPS.RCAPS_COD_FONTE} RCAP    = {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}"
                    .Display();

                    /*" -747- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -748- ELSE */
                }
                else
                {


                    /*" -748- ADD 1 TO UP-RCAPS. */
                    W.UP_RCAPS.Value = W.UP_RCAPS + 1;
                }

            }


        }

        [StopWatch]
        /*" R0540-00-UPDATE-RCAPS-DB-UPDATE-1 */
        public void R0540_00_UPDATE_RCAPS_DB_UPDATE_1()
        {
            /*" -736- EXEC SQL UPDATE SEGUROS.RCAPS SET NUM_APOLICE = :CBCONDEV-NUM-APOLICE ,NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO ,NUM_PARCELA = :CBCONDEV-NUM-PARCELA ,CODIGO_PRODUTO = :CBCONDEV-COD-PRODUTO WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP END-EXEC. */

            var r0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1 = new R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1()
            {
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
                CBCONDEV_COD_PRODUTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            R0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1.Execute(r0540_00_UPDATE_RCAPS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0540_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-UPDATE-RCAPCOMP-SECTION */
        private void R0550_00_UPDATE_RCAPCOMP_SECTION()
        {
            /*" -761- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", W.WABEND.WNR_EXEC_SQL);

            /*" -769- PERFORM R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1 */

            R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1();

            /*" -773- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -774- ADD 1 TO NT-RCAPCOMP */
                W.NT_RCAPCOMP.Value = W.NT_RCAPCOMP + 1;

                /*" -775- ELSE */
            }
            else
            {


                /*" -776- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -777- DISPLAY 'R0550-00 - PROBLEMAS NO UPDATE(RCAPCOMP) ' */
                    _.Display($"R0550-00 - PROBLEMAS NO UPDATE(RCAPCOMP) ");

                    /*" -779- DISPLAY ' FONTE   = ' RCAPS-COD-FONTE ' RCAP    = ' RCAPS-NUM-RCAP */

                    $" FONTE   = {RCAPS.DCLRCAPS.RCAPS_COD_FONTE} RCAP    = {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}"
                    .Display();

                    /*" -780- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -781- ELSE */
                }
                else
                {


                    /*" -781- ADD 1 TO UP-RCAPCOMP. */
                    W.UP_RCAPCOMP.Value = W.UP_RCAPCOMP + 1;
                }

            }


        }

        [StopWatch]
        /*" R0550-00-UPDATE-RCAPCOMP-DB-UPDATE-1 */
        public void R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1()
        {
            /*" -769- EXEC SQL UPDATE SEGUROS.RCAP_COMPLEMENTAR SET BCO_AVISO = :MOVIMCOB-COD-BANCO ,AGE_AVISO = :MOVIMCOB-COD-AGENCIA ,NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO WHERE COD_FONTE = :RCAPS-COD-FONTE AND NUM_RCAP = :RCAPS-NUM-RCAP END-EXEC. */

            var r0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1 = new R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            R0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1.Execute(r0550_00_UPDATE_RCAPCOMP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-PARCEHIS-SECTION */
        private void R0600_00_SELECT_PARCEHIS_SECTION()
        {
            /*" -793- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", W.WABEND.WNR_EXEC_SQL);

            /*" -841- PERFORM R0600_00_SELECT_PARCEHIS_DB_SELECT_1 */

            R0600_00_SELECT_PARCEHIS_DB_SELECT_1();

            /*" -845- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -846- ADD 1 TO SE-PARCEHIS */
                W.SE_PARCEHIS.Value = W.SE_PARCEHIS + 1;

                /*" -847- ELSE */
            }
            else
            {


                /*" -848- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -849- DISPLAY ' TITULO  = ' CBCONDEV-NUM-TITULO */
                    _.Display($" TITULO  = {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO}");

                    /*" -850- DISPLAY 'R0600-00 - PROBLEMAS NO SELECT(PARCEHIS) ' */
                    _.Display($"R0600-00 - PROBLEMAS NO SELECT(PARCEHIS) ");

                    /*" -851- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -852- ELSE */
                }
                else
                {


                    /*" -853- PERFORM R0610-00-INSERT-PARCEHIS */

                    R0610_00_INSERT_PARCEHIS_SECTION();

                    /*" -853- PERFORM R0510-00-UPDATE-PARCELAS. */

                    R0510_00_UPDATE_PARCELAS_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-PARCEHIS-DB-SELECT-1 */
        public void R0600_00_SELECT_PARCEHIS_DB_SELECT_1()
        {
            /*" -841- EXEC SQL SELECT B.NUM_APOLICE ,B.NUM_ENDOSSO ,B.NUM_PARCELA ,B.DAC_PARCELA ,B.OCORR_HISTORICO ,B.PRM_TARIFARIO ,B.VAL_DESCONTO ,B.PRM_LIQUIDO ,B.ADICIONAL_FRACIO ,B.VAL_CUSTO_EMISSAO ,B.VAL_IOCC ,B.PRM_TOTAL ,B.VAL_OPERACAO ,B.DATA_VENCIMENTO ,B.ENDOS_CANCELA ,B.SIT_CONTABIL ,B.RENUM_DOCUMENTO ,B.COD_EMPRESA INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-ENDOS-CANCELA ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-RENUM-DOCUMENTO ,:PARCEHIS-COD-EMPRESA:VIND-NULL02 FROM SEGUROS.PARCELAS A ,SEGUROS.PARCELA_HISTORICO B WHERE A.NUM_APOLICE = :CBCONDEV-NUM-APOLICE AND A.NUM_ENDOSSO = :CBCONDEV-NUM-ENDOSSO AND A.NUM_PARCELA = :CBCONDEV-NUM-PARCELA AND A.SIT_REGISTRO = '0' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.OCORR_HISTORICO = B.OCORR_HISTORICO WITH UR END-EXEC. */

            var r0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1 = new R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1()
            {
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_PARCEHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(executed_1.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(executed_1.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(executed_1.PARCEHIS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);
                _.Move(executed_1.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(executed_1.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(executed_1.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(executed_1.PARCEHIS_PRM_LIQUIDO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);
                _.Move(executed_1.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(executed_1.PARCEHIS_VAL_CUSTO_EMISSAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.PARCEHIS_VAL_IOCC, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);
                _.Move(executed_1.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(executed_1.PARCEHIS_VAL_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                _.Move(executed_1.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(executed_1.PARCEHIS_ENDOS_CANCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);
                _.Move(executed_1.PARCEHIS_SIT_CONTABIL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);
                _.Move(executed_1.PARCEHIS_RENUM_DOCUMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);
                _.Move(executed_1.PARCEHIS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);
                _.Move(executed_1.VIND_NULL02, VIND_NULL02);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-INSERT-PARCEHIS-SECTION */
        private void R0610_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -866- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", W.WABEND.WNR_EXEC_SQL);

            /*" -868- MOVE 201 TO PARCEHIS-COD-OPERACAO. */
            _.Move(201, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -870- ADD 1 TO PARCEHIS-OCORR-HISTORICO. */
            PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO + 1;

            /*" -872- MOVE MOVIMCOB-COD-BANCO TO PARCEHIS-BCO-COBRANCA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -874- MOVE MOVIMCOB-COD-AGENCIA TO PARCEHIS-AGE-COBRANCA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -876- MOVE MOVIMCOB-NUM-AVISO TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -878- MOVE MOVIMCOB-DATA-MOVIMENTO TO PARCEHIS-DATA-QUITACAO. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -881- MOVE 'BI2002B' TO PARCEHIS-COD-USUARIO. */
            _.Move("BI2002B", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -884- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -941- PERFORM R0610_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R0610_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -946- DISPLAY 'R0610-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R0610-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -947- DISPLAY ' APOLICE        =' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE        ={PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -948- DISPLAY ' ENDOSSO        =' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO        ={PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -949- DISPLAY ' PARCELA        =' PARCEHIS-NUM-PARCELA */
                _.Display($" PARCELA        ={PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -950- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -951- ELSE */
            }
            else
            {


                /*" -951- ADD 1 TO IN-PARCEHIS. */
                W.IN_PARCEHIS.Value = W.IN_PARCEHIS + 1;
            }


        }

        [StopWatch]
        /*" R0610-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R0610_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -941- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,DATA_MOVIMENTO ,COD_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,VAL_OPERACAO ,DATA_VENCIMENTO ,BCO_COBRANCA ,AGE_COBRANCA ,NUM_AVISO_CREDITO ,ENDOS_CANCELA ,SIT_CONTABIL ,COD_USUARIO ,RENUM_DOCUMENTO ,DATA_QUITACAO ,COD_EMPRESA ,TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-DATA-MOVIMENTO ,:PARCEHIS-COD-OPERACAO , CURRENT TIME ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA ,:PARCEHIS-NUM-AVISO-CREDITO ,:PARCEHIS-ENDOS-CANCELA ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-COD-USUARIO ,:PARCEHIS-RENUM-DOCUMENTO ,:PARCEHIS-DATA-QUITACAO:VIND-NULL01 ,:PARCEHIS-COD-EMPRESA:VIND-NULL02 , CURRENT TIMESTAMP) END-EXEC. */

            var r0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r0610_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-UPDATE-AVISOSAL-SECTION */
        private void R1000_00_UPDATE_AVISOSAL_SECTION()
        {
            /*" -964- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -972- PERFORM R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1 */

            R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1();

            /*" -976- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -977- ADD 1 TO NT-AVISOSAL */
                W.NT_AVISOSAL.Value = W.NT_AVISOSAL + 1;

                /*" -978- ELSE */
            }
            else
            {


                /*" -979- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -980- DISPLAY 'R1000-00 - PROBLEMAS NO UPDATE(AVISOSAL) ' */
                    _.Display($"R1000-00 - PROBLEMAS NO UPDATE(AVISOSAL) ");

                    /*" -983- DISPLAY ' BANCO   = ' MOVIMCOB-COD-BANCO ' AGENCIA = ' MOVIMCOB-COD-AGENCIA ' AVISO   = ' MOVIMCOB-NUM-AVISO */

                    $" BANCO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO} AGENCIA = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA} AVISO   = {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO}"
                    .Display();

                    /*" -984- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -985- ELSE */
                }
                else
                {


                    /*" -985- ADD 1 TO UP-AVISOSAL. */
                    W.UP_AVISOSAL.Value = W.UP_AVISOSAL + 1;
                }

            }


        }

        [StopWatch]
        /*" R1000-00-UPDATE-AVISOSAL-DB-UPDATE-1 */
        public void R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1()
        {
            /*" -972- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = (SALDO_ATUAL - :CBCONDEV-VAL-TITULO) WHERE BCO_AVISO = :MOVIMCOB-COD-BANCO AND AGE_AVISO = :MOVIMCOB-COD-AGENCIA AND NUM_AVISO_CREDITO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1 = new R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1()
            {
                CBCONDEV_VAL_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO.ToString(),
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            R1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1.Execute(r1000_00_UPDATE_AVISOSAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -996- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -997- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -998- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -1000- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -1000- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1004- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1004- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}