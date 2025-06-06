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
using Sias.Cobranca.DB2.CB0139B;

namespace Code
{
    public class CB0139B
    {
        public bool IsCall { get; set; }

        public CB0139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   COORDENADOR ............  CLOVIS                             *      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  12/12/2000                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA ARQUIVO FUNDO REGIONAL (CRP)  *      */
        /*"      *                             COM MOVIMENTO DIARIO PARA ENVIO    *      */
        /*"      *                             A C.E.F.                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                                              INPUT    *      */
        /*"      * EXTRATO_FUNDO_CEF                                     INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQCEF1 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis ARQCEF1
        {
            get
            {
                _.Move(REG_ARQCEF1, _ARQCEF1); VarBasis.RedefinePassValue(REG_ARQCEF1, _ARQCEF1, REG_ARQCEF1); return _ARQCEF1;
            }
        }
        public SortBasis<CB0139B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<CB0139B_REG_ARQSORT>(new CB0139B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public CB0139B_REG_ARQSORT REG_ARQSORT { get; set; } = new CB0139B_REG_ARQSORT();
        public class CB0139B_REG_ARQSORT : VarBasis
        {
            /*"  05      SOR-ESCCEF            PIC 9(004).*/
            public IntBasis SOR_ESCCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-ESCSAS            PIC 9(004).*/
            public IntBasis SOR_ESCSAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SOR-DTMOVTO           PIC X(010).*/
            public StringBasis SOR_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-DTOCORR           PIC X(010).*/
            public StringBasis SOR_DTOCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SOR-EMPRESA           PIC X(015).*/
            public StringBasis SOR_EMPRESA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      SOR-HISTORICO         PIC X(040).*/
            public StringBasis SOR_HISTORICO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      SOR-VALMOVTO          PIC 9(013)V99.*/
            public DoubleBasis SOR_VALMOVTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-TIPMOVTO          PIC X(001).*/
            public StringBasis SOR_TIPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-VALSALDO          PIC 9(013)V99.*/
            public DoubleBasis SOR_VALSALDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SOR-TIPSALDO          PIC X(001).*/
            public StringBasis SOR_TIPSALDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SOR-NRSEQ             PIC 9(009).*/
            public IntBasis SOR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"01        REG-ARQCEF1.*/
        }
        public CB0139B_REG_ARQCEF1 REG_ARQCEF1 { get; set; } = new CB0139B_REG_ARQCEF1();
        public class CB0139B_REG_ARQCEF1 : VarBasis
        {
            /*"  05      SAI-CODREG            PIC X(001).*/
            public StringBasis SAI_CODREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SAI-ESCCEF            PIC 9(004).*/
            public IntBasis SAI_ESCCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SAI-DTMOVTO           PIC X(010).*/
            public StringBasis SAI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SAI-DTOCORR           PIC X(010).*/
            public StringBasis SAI_DTOCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SAI-EMPRESA           PIC X(015).*/
            public StringBasis SAI_EMPRESA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      SAI-HISTORICO         PIC X(040).*/
            public StringBasis SAI_HISTORICO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      SAI-VALMOVTO          PIC 9(013)V99.*/
            public DoubleBasis SAI_VALMOVTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SAI-TIPMOVTO          PIC X(001).*/
            public StringBasis SAI_TIPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SAI-VALSALDO          PIC 9(013)V99.*/
            public DoubleBasis SAI_VALSALDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SAI-TIPSALDO          PIC X(001).*/
            public StringBasis SAI_TIPSALDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SAI-SEQUENCIA         PIC 9(008).*/
            public IntBasis SAI_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      FILLER                PIC X(030).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    VIND-SALDO                PIC S9(004)     COMP.*/
        public IntBasis VIND_SALDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALOR                PIC S9(004)     COMP.*/
        public IntBasis VIND_VALOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-AUX-WORK.*/
        public CB0139B_WS_AUX_WORK WS_AUX_WORK { get; set; } = new CB0139B_WS_AUX_WORK();
        public class CB0139B_WS_AUX_WORK : VarBasis
        {
            /*"  03  WFIM-V0EXTRATO            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WFIM_V0EXTRATO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  AC-LIDOS                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-GRAVADOS               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ATU-ESCCEF                PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis ATU_ESCCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  ANT-ESCCEF                PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis ANT_ESCCEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  WS-SALDO                  PIC S9(013)V99         COMP-3.*/
            public DoubleBasis WS_SALDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-VALOR                  PIC S9(013)V99         COMP-3.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  WS-SEQUENCIA              PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis WS_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03  WS-VALTOT                 PIC S9(013)V99         COMP-3.*/
            public DoubleBasis WS_VALTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03         WDATA-REL         PIC  X(010).*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0139B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_CB0139B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_CB0139B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0139B_FILLER_1 : VarBasis
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
                /*"  03        WABEND.*/

                public _REDEF_CB0139B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0139B_WABEND WABEND { get; set; } = new CB0139B_WABEND();
            public class CB0139B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB0139B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0139B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  WS-ARQUIVOS.*/
            }
        }
        public CB0139B_WS_ARQUIVOS WS_ARQUIVOS { get; set; } = new CB0139B_WS_ARQUIVOS();
        public class CB0139B_WS_ARQUIVOS : VarBasis
        {
            /*"  03      HED-ARQCEF1.*/
            public CB0139B_HED_ARQCEF1 HED_ARQCEF1 { get; set; } = new CB0139B_HED_ARQCEF1();
            public class CB0139B_HED_ARQCEF1 : VarBasis
            {
                /*"    05    HED-CODREG            PIC X(001).*/
                public StringBasis HED_CODREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05    HED-NOMARQ            PIC X(006).*/
                public StringBasis HED_NOMARQ { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"    05    HED-DTGRAVA.*/
                public CB0139B_HED_DTGRAVA HED_DTGRAVA { get; set; } = new CB0139B_HED_DTGRAVA();
                public class CB0139B_HED_DTGRAVA : VarBasis
                {
                    /*"      10  HED-DIA               PIC 9(002).*/
                    public IntBasis HED_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10  HED-MES               PIC 9(002).*/
                    public IntBasis HED_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10  HED-ANO               PIC 9(004).*/
                    public IntBasis HED_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05    FILLER                PIC X(135).*/
                }
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "135", "X(135)."), @"");
                /*"  03      TRA-ARQCEF1.*/
            }
            public CB0139B_TRA_ARQCEF1 TRA_ARQCEF1 { get; set; } = new CB0139B_TRA_ARQCEF1();
            public class CB0139B_TRA_ARQCEF1 : VarBasis
            {
                /*"    05    TRA-CODREG            PIC X(001).*/
                public StringBasis TRA_CODREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05    TRA-NOMARQ            PIC X(006).*/
                public StringBasis TRA_NOMARQ { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"    05    TRA-QTDREG            PIC 9(008).*/
                public IntBasis TRA_QTDREG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05    TRA-VALTOT            PIC 9(013)V99.*/
                public DoubleBasis TRA_VALTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05    FILLER                PIC X(120).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.EXTFUNCE EXTFUNCE { get; set; } = new Dclgens.EXTFUNCE();
        public CB0139B_V0EXTRATO V0EXTRATO { get; set; } = new CB0139B_V0EXTRATO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string ARQCEF1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                ARQCEF1.SetFile(ARQCEF1_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -273- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -274- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -276- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -278- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -284- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -294- SORT ARQSORT ON ASCENDING KEY SOR-ESCCEF SOR-DTMOVTO SOR-NRSEQ SOR-TIPMOVTO SOR-EMPRESA INPUT PROCEDURE R0400-00-INPUT-SORT THRU R0400-99-SAIDA OUTPUT PROCEDURE R0450-00-OUTPUT-SORT THRU R0450-99-SAIDA. */
            ARQSORT.Sort("SOR-ESCCEF,SOR-DTMOVTO,SOR-NRSEQ,SOR-TIPMOVTO,SOR-EMPRESA", () => R0400_00_INPUT_SORT_SECTION(), () => R0450_00_OUTPUT_SORT_SECTION());

            /*" -301- MOVE SPACES TO TRA-ARQCEF1 */
            _.Move("", WS_ARQUIVOS.TRA_ARQCEF1);

            /*" -302- MOVE 'T' TO TRA-CODREG */
            _.Move("T", WS_ARQUIVOS.TRA_ARQCEF1.TRA_CODREG);

            /*" -303- MOVE 'ARQCRP' TO TRA-NOMARQ */
            _.Move("ARQCRP", WS_ARQUIVOS.TRA_ARQCEF1.TRA_NOMARQ);

            /*" -304- ADD 2 TO WS-SEQUENCIA */
            WS_AUX_WORK.WS_SEQUENCIA.Value = WS_AUX_WORK.WS_SEQUENCIA + 2;

            /*" -305- MOVE WS-SEQUENCIA TO TRA-QTDREG */
            _.Move(WS_AUX_WORK.WS_SEQUENCIA, WS_ARQUIVOS.TRA_ARQCEF1.TRA_QTDREG);

            /*" -306- MOVE WS-VALTOT TO TRA-VALTOT */
            _.Move(WS_AUX_WORK.WS_VALTOT, WS_ARQUIVOS.TRA_ARQCEF1.TRA_VALTOT);

            /*" -307- WRITE REG-ARQCEF1 FROM TRA-ARQCEF1 */
            _.Move(WS_ARQUIVOS.TRA_ARQCEF1.GetMoveValues(), REG_ARQCEF1);

            ARQCEF1.Write(REG_ARQCEF1.GetMoveValues().ToString());

            /*" -307- ADD 1 TO AC-GRAVADOS. */
            WS_AUX_WORK.AC_GRAVADOS.Value = WS_AUX_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -312- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -316- CLOSE ARQCEF1. */
            ARQCEF1.Close();

            /*" -318- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -319- DISPLAY ' ' */
            _.Display($" ");

            /*" -320- DISPLAY 'CB0139B - FIM NORMAL' . */
            _.Display($"CB0139B - FIM NORMAL");

            /*" -321- DISPLAY ' ' */
            _.Display($" ");

            /*" -322- DISPLAY 'LIDOS EXTRATO-FUNDO ... ' AC-LIDOS */
            _.Display($"LIDOS EXTRATO-FUNDO ... {WS_AUX_WORK.AC_LIDOS}");

            /*" -323- DISPLAY 'REGISTROS GRAVADOS .... ' AC-GRAVADOS */
            _.Display($"REGISTROS GRAVADOS .... {WS_AUX_WORK.AC_GRAVADOS}");

            /*" -324- DISPLAY ' ' */
            _.Display($" ");

            /*" -325- DISPLAY 'CB0139B - FIM NORMAL' . */
            _.Display($"CB0139B - FIM NORMAL");

            /*" -328- DISPLAY ' ' */
            _.Display($" ");

            /*" -328- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -341- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -344- OPEN OUTPUT ARQCEF1. */
            ARQCEF1.Open(REG_ARQCEF1);

            /*" -346- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -352- PERFORM R0150-00-SELECT-V0RELATORIOS. */

            R0150_00_SELECT_V0RELATORIOS_SECTION();

            /*" -353- MOVE SPACES TO HED-ARQCEF1 */
            _.Move("", WS_ARQUIVOS.HED_ARQCEF1);

            /*" -354- MOVE 'H' TO HED-CODREG */
            _.Move("H", WS_ARQUIVOS.HED_ARQCEF1.HED_CODREG);

            /*" -355- MOVE 'ARQCRP' TO HED-NOMARQ */
            _.Move("ARQCRP", WS_ARQUIVOS.HED_ARQCEF1.HED_NOMARQ);

            /*" -357- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_AUX_WORK.WDATA_REL);

            /*" -358- MOVE WDAT-REL-DIA TO HED-DIA */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_DIA, WS_ARQUIVOS.HED_ARQCEF1.HED_DTGRAVA.HED_DIA);

            /*" -359- MOVE WDAT-REL-MES TO HED-MES */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_MES, WS_ARQUIVOS.HED_ARQCEF1.HED_DTGRAVA.HED_MES);

            /*" -360- MOVE WDAT-REL-ANO TO HED-ANO */
            _.Move(WS_AUX_WORK.FILLER_1.WDAT_REL_ANO, WS_ARQUIVOS.HED_ARQCEF1.HED_DTGRAVA.HED_ANO);

            /*" -361- WRITE REG-ARQCEF1 FROM HED-ARQCEF1 */
            _.Move(WS_ARQUIVOS.HED_ARQCEF1.GetMoveValues(), REG_ARQCEF1);

            ARQCEF1.Write(REG_ARQCEF1.GetMoveValues().ToString());

            /*" -363- ADD 1 TO AC-GRAVADOS. */
            WS_AUX_WORK.AC_GRAVADOS.Value = WS_AUX_WORK.AC_GRAVADOS + 1;

            /*" -367- MOVE ZEROS TO WS-SEQUENCIA WS-VALTOT. */
            _.Move(0, WS_AUX_WORK.WS_SEQUENCIA, WS_AUX_WORK.WS_VALTOT);

            /*" -369- IF SISTEMAS-DATA-MOV-ABERTO EQUAL RELATORI-DATA-REFERENCIA */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO == RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA)
            {

                /*" -371- MOVE RELATORI-PERI-INICIAL TO SISTEMAS-DATULT-PROCESSAMEN */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);

                /*" -372- ELSE */
            }
            else
            {


                /*" -381- MOVE SISTEMAS-DATA-MOV-ABERTO TO SISTEMAS-DATULT-PROCESSAMEN. */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


            /*" -381- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -393- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -398- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -401- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -402- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -402- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -398- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-SELECT-V0RELATORIOS-SECTION */
        private void R0150_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -414- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -422- PERFORM R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -426- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -427- DISPLAY 'R0150-00 - PROBLEMAS NO SELECT(V0RELATORIOS)' */
                _.Display($"R0150-00 - PROBLEMAS NO SELECT(V0RELATORIOS)");

                /*" -427- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -422- EXEC SQL SELECT PERI_INICIAL , DATA_REFERENCIA INTO :RELATORI-PERI-INICIAL , :RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'CO' AND COD_RELATORIO = 'CO0399B1' END-EXEC. */

            var r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0150_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-INPUT-SORT-SECTION */
        private void R0400_00_INPUT_SORT_SECTION()
        {
            /*" -439- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -441- MOVE SPACES TO WFIM-V0EXTRATO. */
            _.Move("", WS_AUX_WORK.WFIM_V0EXTRATO);

            /*" -443- PERFORM R0410-00-DECLARE-V0EXTRATO. */

            R0410_00_DECLARE_V0EXTRATO_SECTION();

            /*" -445- PERFORM R0420-00-FETCH-V0EXTRATO. */

            R0420_00_FETCH_V0EXTRATO_SECTION();

            /*" -446- PERFORM R0430-00-GRAVA-SORT UNTIL WFIM-V0EXTRATO NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_V0EXTRATO.IsEmpty()))
            {

                R0430_00_GRAVA_SORT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-DECLARE-V0EXTRATO-SECTION */
        private void R0410_00_DECLARE_V0EXTRATO_SECTION()
        {
            /*" -458- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -473- PERFORM R0410_00_DECLARE_V0EXTRATO_DB_DECLARE_1 */

            R0410_00_DECLARE_V0EXTRATO_DB_DECLARE_1();

            /*" -475- PERFORM R0410_00_DECLARE_V0EXTRATO_DB_OPEN_1 */

            R0410_00_DECLARE_V0EXTRATO_DB_OPEN_1();

            /*" -478- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -479- DISPLAY 'R0410-00 - PROBLEMAS DECLARE (EXTRATO_FUNDO_CEF)' */
                _.Display($"R0410-00 - PROBLEMAS DECLARE (EXTRATO_FUNDO_CEF)");

                /*" -479- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0410-00-DECLARE-V0EXTRATO-DB-DECLARE-1 */
        public void R0410_00_DECLARE_V0EXTRATO_DB_DECLARE_1()
        {
            /*" -473- EXEC SQL DECLARE V0EXTRATO CURSOR FOR SELECT COD_EMPRESA , COD_ESCNEG , DATA_MOVIMENTO , NRSEQ , TIPO_MOVIMENTO , VAL_MOVIMENTO , DATA_OCORRENCIA , DESC_OCORRENCIA , SALDO_ATUAL FROM SEGUROS.EXTRATO_FUNDO_CEF WHERE DATA_MOVIMENTO >= :SISTEMAS-DATULT-PROCESSAMEN AND DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO AND NUM_MATRICULA = 6000000 END-EXEC. */
            V0EXTRATO = new CB0139B_V0EXTRATO(true);
            string GetQuery_V0EXTRATO()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_ESCNEG
							, 
							DATA_MOVIMENTO
							, 
							NRSEQ
							, 
							TIPO_MOVIMENTO
							, 
							VAL_MOVIMENTO
							, 
							DATA_OCORRENCIA
							, 
							DESC_OCORRENCIA
							, 
							SALDO_ATUAL 
							FROM SEGUROS.EXTRATO_FUNDO_CEF 
							WHERE DATA_MOVIMENTO >= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}' 
							AND DATA_MOVIMENTO <= '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND NUM_MATRICULA = 6000000";

                return query;
            }
            V0EXTRATO.GetQueryEvent += GetQuery_V0EXTRATO;

        }

        [StopWatch]
        /*" R0410-00-DECLARE-V0EXTRATO-DB-OPEN-1 */
        public void R0410_00_DECLARE_V0EXTRATO_DB_OPEN_1()
        {
            /*" -475- EXEC SQL OPEN V0EXTRATO END-EXEC. */

            V0EXTRATO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-FETCH-V0EXTRATO-SECTION */
        private void R0420_00_FETCH_V0EXTRATO_SECTION()
        {
            /*" -491- MOVE '0420' TO WNR-EXEC-SQL. */
            _.Move("0420", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -501- PERFORM R0420_00_FETCH_V0EXTRATO_DB_FETCH_1 */

            R0420_00_FETCH_V0EXTRATO_DB_FETCH_1();

            /*" -504- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -504- PERFORM R0420_00_FETCH_V0EXTRATO_DB_CLOSE_1 */

                R0420_00_FETCH_V0EXTRATO_DB_CLOSE_1();

                /*" -506- MOVE 'S' TO WFIM-V0EXTRATO */
                _.Move("S", WS_AUX_WORK.WFIM_V0EXTRATO);

                /*" -508- GO TO R0420-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/ //GOTO
                return;
            }


            /*" -509- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -510- DISPLAY 'R0420-00 - PROBLEMAS FETCH (EXTRATO_FUNDO_CEF)' */
                _.Display($"R0420-00 - PROBLEMAS FETCH (EXTRATO_FUNDO_CEF)");

                /*" -512- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -513- IF VIND-SALDO LESS ZEROS */

            if (VIND_SALDO < 00)
            {

                /*" -517- MOVE ZEROS TO EXTFUNCE-SALDO-ATUAL. */
                _.Move(0, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_SALDO_ATUAL);
            }


            /*" -517- ADD 1 TO AC-LIDOS. */
            WS_AUX_WORK.AC_LIDOS.Value = WS_AUX_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0420-00-FETCH-V0EXTRATO-DB-FETCH-1 */
        public void R0420_00_FETCH_V0EXTRATO_DB_FETCH_1()
        {
            /*" -501- EXEC SQL FETCH V0EXTRATO INTO :EXTFUNCE-COD-EMPRESA , :EXTFUNCE-COD-ESCNEG , :EXTFUNCE-DATA-MOVIMENTO , :EXTFUNCE-NRSEQ , :EXTFUNCE-TIPO-MOVIMENTO , :EXTFUNCE-VAL-MOVIMENTO , :EXTFUNCE-DATA-OCORRENCIA , :EXTFUNCE-DESC-OCORRENCIA , :EXTFUNCE-SALDO-ATUAL:VIND-SALDO END-EXEC. */

            if (V0EXTRATO.Fetch())
            {
                _.Move(V0EXTRATO.EXTFUNCE_COD_EMPRESA, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_EMPRESA);
                _.Move(V0EXTRATO.EXTFUNCE_COD_ESCNEG, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_ESCNEG);
                _.Move(V0EXTRATO.EXTFUNCE_DATA_MOVIMENTO, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_DATA_MOVIMENTO);
                _.Move(V0EXTRATO.EXTFUNCE_NRSEQ, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_NRSEQ);
                _.Move(V0EXTRATO.EXTFUNCE_TIPO_MOVIMENTO, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_TIPO_MOVIMENTO);
                _.Move(V0EXTRATO.EXTFUNCE_VAL_MOVIMENTO, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_VAL_MOVIMENTO);
                _.Move(V0EXTRATO.EXTFUNCE_DATA_OCORRENCIA, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_DATA_OCORRENCIA);
                _.Move(V0EXTRATO.EXTFUNCE_DESC_OCORRENCIA, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_DESC_OCORRENCIA);
                _.Move(V0EXTRATO.EXTFUNCE_SALDO_ATUAL, EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_SALDO_ATUAL);
                _.Move(V0EXTRATO.VIND_SALDO, VIND_SALDO);
            }

        }

        [StopWatch]
        /*" R0420-00-FETCH-V0EXTRATO-DB-CLOSE-1 */
        public void R0420_00_FETCH_V0EXTRATO_DB_CLOSE_1()
        {
            /*" -504- EXEC SQL CLOSE V0EXTRATO END-EXEC */

            V0EXTRATO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0430-00-GRAVA-SORT-SECTION */
        private void R0430_00_GRAVA_SORT_SECTION()
        {
            /*" -530- MOVE '0430' TO WNR-EXEC-SQL. */
            _.Move("0430", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -532- MOVE EXTFUNCE-COD-ESCNEG TO SOR-ESCCEF. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_ESCNEG, REG_ARQSORT.SOR_ESCCEF);

            /*" -534- MOVE EXTFUNCE-COD-ESCNEG TO SOR-ESCSAS. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_ESCNEG, REG_ARQSORT.SOR_ESCSAS);

            /*" -536- MOVE EXTFUNCE-DATA-MOVIMENTO TO SOR-DTMOVTO. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_DATA_MOVIMENTO, REG_ARQSORT.SOR_DTMOVTO);

            /*" -538- MOVE EXTFUNCE-DATA-OCORRENCIA TO SOR-DTOCORR. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_DATA_OCORRENCIA, REG_ARQSORT.SOR_DTOCORR);

            /*" -540- MOVE EXTFUNCE-DESC-OCORRENCIA TO SOR-HISTORICO. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_DESC_OCORRENCIA, REG_ARQSORT.SOR_HISTORICO);

            /*" -542- MOVE EXTFUNCE-VAL-MOVIMENTO TO SOR-VALMOVTO. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_VAL_MOVIMENTO, REG_ARQSORT.SOR_VALMOVTO);

            /*" -544- MOVE EXTFUNCE-TIPO-MOVIMENTO TO SOR-TIPMOVTO. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_TIPO_MOVIMENTO, REG_ARQSORT.SOR_TIPMOVTO);

            /*" -547- MOVE EXTFUNCE-NRSEQ TO SOR-NRSEQ. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_NRSEQ, REG_ARQSORT.SOR_NRSEQ);

            /*" -548- IF EXTFUNCE-SALDO-ATUAL LESS ZEROS */

            if (EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_SALDO_ATUAL < 00)
            {

                /*" -549- MOVE 'D' TO SOR-TIPSALDO */
                _.Move("D", REG_ARQSORT.SOR_TIPSALDO);

                /*" -551- COMPUTE EXTFUNCE-SALDO-ATUAL EQUAL EXTFUNCE-SALDO-ATUAL * -1 */
                EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_SALDO_ATUAL.Value = EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_SALDO_ATUAL * -1;

                /*" -552- ELSE */
            }
            else
            {


                /*" -554- MOVE 'C' TO SOR-TIPSALDO. */
                _.Move("C", REG_ARQSORT.SOR_TIPSALDO);
            }


            /*" -558- MOVE EXTFUNCE-SALDO-ATUAL TO SOR-VALSALDO. */
            _.Move(EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_SALDO_ATUAL, REG_ARQSORT.SOR_VALSALDO);

            /*" -559- IF EXTFUNCE-COD-EMPRESA EQUAL 6098 */

            if (EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_EMPRESA == 6098)
            {

                /*" -560- MOVE 'FEDERALPREV    ' TO SOR-EMPRESA */
                _.Move("FEDERALPREV    ", REG_ARQSORT.SOR_EMPRESA);

                /*" -561- ELSE */
            }
            else
            {


                /*" -562- IF EXTFUNCE-COD-EMPRESA EQUAL 6093 */

                if (EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_EMPRESA == 6093)
                {

                    /*" -563- MOVE 'FEDERALCAP     ' TO SOR-EMPRESA */
                    _.Move("FEDERALCAP     ", REG_ARQSORT.SOR_EMPRESA);

                    /*" -564- ELSE */
                }
                else
                {


                    /*" -565- IF EXTFUNCE-COD-EMPRESA EQUAL 6109 */

                    if (EXTFUNCE.DCLEXTRATO_FUNDO_CEF.EXTFUNCE_COD_EMPRESA == 6109)
                    {

                        /*" -566- MOVE 'CVPREV         ' TO SOR-EMPRESA */
                        _.Move("CVPREV         ", REG_ARQSORT.SOR_EMPRESA);

                        /*" -567- ELSE */
                    }
                    else
                    {


                        /*" -570- MOVE 'CAIXA SEGUROS  ' TO SOR-EMPRESA. */
                        _.Move("CAIXA SEGUROS  ", REG_ARQSORT.SOR_EMPRESA);
                    }

                }

            }


            /*" -571- IF SOR-ESCCEF NOT EQUAL 9999 */

            if (REG_ARQSORT.SOR_ESCCEF != 9999)
            {

                /*" -571- RELEASE REG-ARQSORT. */
                ARQSORT.Release(REG_ARQSORT);
            }


            /*" -0- FLUXCONTROL_PERFORM R0430_90_LEITURA */

            R0430_90_LEITURA();

        }

        [StopWatch]
        /*" R0430-90-LEITURA */
        private void R0430_90_LEITURA(bool isPerform = false)
        {
            /*" -585- PERFORM R0420-00-FETCH-V0EXTRATO. */

            R0420_00_FETCH_V0EXTRATO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0430_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-OUTPUT-SORT-SECTION */
        private void R0450_00_OUTPUT_SORT_SECTION()
        {
            /*" -597- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -598- MOVE SPACES TO WFIM-SORT. */
            _.Move("", WS_AUX_WORK.WFIM_SORT);

            /*" -601- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

            /*" -602- IF WFIM-SORT NOT EQUAL SPACES */

            if (!WS_AUX_WORK.WFIM_SORT.IsEmpty())
            {

                /*" -605- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -606- PERFORM R0510-00-PROCESSA UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!WS_AUX_WORK.WFIM_SORT.IsEmpty()))
            {

                R0510_00_PROCESSA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-LE-ARQSORT-SECTION */
        private void R0500_00_LE_ARQSORT_SECTION()
        {
            /*" -618- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -620- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -621- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", WS_AUX_WORK.WFIM_SORT);

                    /*" -622- MOVE ZEROS TO ATU-ESCCEF */
                    _.Move(0, WS_AUX_WORK.ATU_ESCCEF);

                    /*" -625- GO TO R0500-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -625- MOVE SOR-ESCCEF TO ATU-ESCCEF. */
            _.Move(REG_ARQSORT.SOR_ESCCEF, WS_AUX_WORK.ATU_ESCCEF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-PROCESSA-SECTION */
        private void R0510_00_PROCESSA_SECTION()
        {
            /*" -641- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -642- MOVE ATU-ESCCEF TO ANT-ESCCEF. */
            _.Move(WS_AUX_WORK.ATU_ESCCEF, WS_AUX_WORK.ANT_ESCCEF);

            /*" -644- PERFORM R0550-00-PROCESSA-ESCNEG UNTIL ATU-ESCCEF NOT EQUAL ANT-ESCCEF OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(WS_AUX_WORK.ATU_ESCCEF != WS_AUX_WORK.ANT_ESCCEF || !WS_AUX_WORK.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_ESCNEG_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-ESCNEG-SECTION */
        private void R0550_00_PROCESSA_ESCNEG_SECTION()
        {
            /*" -725- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WS_AUX_WORK.WABEND.WNR_EXEC_SQL);

            /*" -726- MOVE SPACES TO REG-ARQCEF1 */
            _.Move("", REG_ARQCEF1);

            /*" -727- MOVE '1' TO SAI-CODREG */
            _.Move("1", REG_ARQCEF1.SAI_CODREG);

            /*" -728- MOVE SOR-ESCCEF TO SAI-ESCCEF */
            _.Move(REG_ARQSORT.SOR_ESCCEF, REG_ARQCEF1.SAI_ESCCEF);

            /*" -729- MOVE SOR-DTMOVTO TO SAI-DTMOVTO */
            _.Move(REG_ARQSORT.SOR_DTMOVTO, REG_ARQCEF1.SAI_DTMOVTO);

            /*" -730- MOVE SOR-DTOCORR TO SAI-DTOCORR */
            _.Move(REG_ARQSORT.SOR_DTOCORR, REG_ARQCEF1.SAI_DTOCORR);

            /*" -731- MOVE SOR-EMPRESA TO SAI-EMPRESA */
            _.Move(REG_ARQSORT.SOR_EMPRESA, REG_ARQCEF1.SAI_EMPRESA);

            /*" -732- MOVE SOR-HISTORICO TO SAI-HISTORICO */
            _.Move(REG_ARQSORT.SOR_HISTORICO, REG_ARQCEF1.SAI_HISTORICO);

            /*" -734- MOVE SOR-VALMOVTO TO SAI-VALMOVTO WS-VALOR */
            _.Move(REG_ARQSORT.SOR_VALMOVTO, REG_ARQCEF1.SAI_VALMOVTO, WS_AUX_WORK.WS_VALOR);

            /*" -735- MOVE SOR-TIPMOVTO TO SAI-TIPMOVTO */
            _.Move(REG_ARQSORT.SOR_TIPMOVTO, REG_ARQCEF1.SAI_TIPMOVTO);

            /*" -736- ADD 1 TO WS-SEQUENCIA */
            WS_AUX_WORK.WS_SEQUENCIA.Value = WS_AUX_WORK.WS_SEQUENCIA + 1;

            /*" -738- MOVE WS-SEQUENCIA TO SAI-SEQUENCIA. */
            _.Move(WS_AUX_WORK.WS_SEQUENCIA, REG_ARQCEF1.SAI_SEQUENCIA);

            /*" -739- MOVE SOR-VALSALDO TO SAI-VALSALDO */
            _.Move(REG_ARQSORT.SOR_VALSALDO, REG_ARQCEF1.SAI_VALSALDO);

            /*" -759- MOVE SOR-TIPSALDO TO SAI-TIPSALDO. */
            _.Move(REG_ARQSORT.SOR_TIPSALDO, REG_ARQCEF1.SAI_TIPSALDO);

            /*" -760- WRITE REG-ARQCEF1 */
            ARQCEF1.Write(REG_ARQCEF1.GetMoveValues().ToString());

            /*" -763- ADD 1 TO AC-GRAVADOS. */
            WS_AUX_WORK.AC_GRAVADOS.Value = WS_AUX_WORK.AC_GRAVADOS + 1;

            /*" -763- ADD SOR-VALMOVTO TO WS-VALTOT. */
            WS_AUX_WORK.WS_VALTOT.Value = WS_AUX_WORK.WS_VALTOT + REG_ARQSORT.SOR_VALMOVTO;

            /*" -0- FLUXCONTROL_PERFORM R0550_90_LEITURA */

            R0550_90_LEITURA();

        }

        [StopWatch]
        /*" R0550-90-LEITURA */
        private void R0550_90_LEITURA(bool isPerform = false)
        {
            /*" -768- PERFORM R0500-00-LE-ARQSORT. */

            R0500_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -778- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WS_AUX_WORK.WABEND.WSQLCODE);

            /*" -779- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WS_AUX_WORK.WABEND.WSQLERRD1);

            /*" -780- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WS_AUX_WORK.WABEND.WSQLERRD2);

            /*" -782- DISPLAY WABEND. */
            _.Display(WS_AUX_WORK.WABEND);

            /*" -784- CLOSE ARQCEF1. */
            ARQCEF1.Close();

            /*" -784- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -788- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -788- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}