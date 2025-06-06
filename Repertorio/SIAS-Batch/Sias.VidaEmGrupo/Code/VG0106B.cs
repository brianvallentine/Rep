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
using Sias.VidaEmGrupo.DB2.VG0106B;

namespace Code
{
    public class VG0106B
    {
        public bool IsCall { get; set; }

        public VG0106B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MANOEL MESSIAS DE SOUZA            *      */
        /*"      *   PROGRAMADOR ............  MANOEL MESSIAS DE SOUZA            *      */
        /*"      *   DATA CODIFICACAO .......  ABRIL/2000                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZA A DATA DE REFERENCIA DA   *      */
        /*"      *                             TABELA V0FATURCONT                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * FATURAS                             V1FATURAS         INPUT    *      */
        /*"      * CONTROLE FATURAS                    V1FATURCONT       I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  28/07/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77           WHOST-DTREFER          PIC  X(010).*/
        public StringBasis WHOST_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V1FATR-NUM-FATUR       PIC S9(009)     COMP.*/
        public IntBasis V1FATR_NUM_FATUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77           V1FATR-CODOPER         PIC S9(004)     COMP.*/
        public IntBasis V1FATR_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V0SUBG-PERI-FATUR      PIC S9(004)     COMP.*/
        public IntBasis V0SUBG_PERI_FATUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1FATC-NUM-APOL        PIC S9(013)     COMP-3.*/
        public IntBasis V1FATC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77           V1FATC-COD-SUBG        PIC S9(004)     COMP.*/
        public IntBasis V1FATC_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           V1FATC-DATA-REFER      PIC  X(010).*/
        public StringBasis V1FATC_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           V0SOLI-SITUACAO        PIC  X(001).*/
        public StringBasis V0SOLI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01                AREA-DE-WORK.*/
        public VG0106B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0106B_AREA_DE_WORK();
        public class VG0106B_AREA_DE_WORK : VarBasis
        {
            /*" 05               WS-DTBASE.*/
            public VG0106B_WS_DTBASE WS_DTBASE { get; set; } = new VG0106B_WS_DTBASE();
            public class VG0106B_WS_DTBASE : VarBasis
            {
                /*"   10             WS-AABASE         PIC  9(004).*/
                public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10             FILLER            PIC  X(001)     VALUE  '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10             WS-MMBASE         PIC  9(002).*/
                public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10             FILLER            PIC  X(001)     VALUE  '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10             WS-DDBASE         PIC  9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05               WDATA-REFER.*/
            }
            public VG0106B_WDATA_REFER WDATA_REFER { get; set; } = new VG0106B_WDATA_REFER();
            public class VG0106B_WDATA_REFER : VarBasis
            {
                /*"   10             WREF-ANO          PIC  9(004).*/
                public IntBasis WREF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10             FILLER            PIC  X(001)     VALUE  '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10             WREF-MES          PIC  9(002).*/
                public IntBasis WREF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10             FILLER            PIC  X(001)     VALUE  '-'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10             WREF-DIA          PIC  9(002).*/
                public IntBasis WREF_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05              WNUM-FATURA       PIC  9(006)     VALUE ZEROS.*/
                public IntBasis WNUM_FATURA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"  05              FILLER            REDEFINES       WNUM-FATURA.*/
                private _REDEF_VG0106B_FILLER_4 _filler_4 { get; set; }
                public _REDEF_VG0106B_FILLER_4 FILLER_4
                {
                    get { _filler_4 = new _REDEF_VG0106B_FILLER_4(); _.Move(WNUM_FATURA, _filler_4); VarBasis.RedefinePassValue(WNUM_FATURA, _filler_4, WNUM_FATURA); _filler_4.ValueChanged += () => { _.Move(_filler_4, WNUM_FATURA); }; return _filler_4; }
                    set { VarBasis.RedefinePassValue(value, _filler_4, WNUM_FATURA); }
                }  //Redefines
                public class _REDEF_VG0106B_FILLER_4 : VarBasis
                {
                    /*"    10            WFAT-ANO          PIC  9(004).*/
                    public IntBasis WFAT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10            WFAT-MES          PIC  9(002).*/
                    public IntBasis WFAT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05              WANO              PIC  9(002)     VALUE ZEROS.*/

                    public _REDEF_VG0106B_FILLER_4()
                    {
                        WFAT_ANO.ValueChanged += OnValueChanged;
                        WFAT_MES.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05              WFIM-V1FATURCONT  PIC  X(001)     VALUE SPACES*/
                public StringBasis WFIM_V1FATURCONT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"  05              AC-L-V1FATURCONT  PIC  9(004)     VALUE ZEROS.*/
                public IntBasis AC_L_V1FATURCONT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05              AC-S-V1FATURAS    PIC  9(004)     VALUE ZEROS.*/
                public IntBasis AC_S_V1FATURAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05              AC-A-V0FATURCONT  PIC  9(004)     VALUE ZEROS.*/
                public IntBasis AC_A_V0FATURCONT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05              WABEND.*/
                public VG0106B_WABEND WABEND { get; set; } = new VG0106B_WABEND();
                public class VG0106B_WABEND : VarBasis
                {
                    /*"    10            FILLER            PIC X(010)      VALUE                ' VG0106B'.*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0106B");
                    /*"    10            FILLER            PIC X(026)      VALUE                ' *** ERRO EXEC SQL NUMERO '.*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                    /*"    10            WNR-EXEC-SQL      PIC X(003)      VALUE '000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                    /*"    10            FILLER            PIC X(013)      VALUE                ' *** SQLCODE '.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"    10            WSQLCODE          PIC ZZZZZ999-   VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                }
            }
        }


        public VG0106B_V1FATURCONT V1FATURCONT { get; set; } = new VG0106B_V1FATURCONT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -149- MOVE '010' TO WNR-EXEC-SQL. */
                _.Move("010", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

                /*" -150- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -153- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -156- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -156- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -165- MOVE SPACES TO WFIM-V1FATURCONT */
            _.Move("", AREA_DE_WORK.WDATA_REFER.WFIM_V1FATURCONT);

            /*" -167- PERFORM R0900-00-DECLA-V1FATURCONT. */

            R0900_00_DECLA_V1FATURCONT_SECTION();

            /*" -168- PERFORM R0910-00-FETCH-V1FATURCONT */

            R0910_00_FETCH_V1FATURCONT_SECTION();

            /*" -169- IF WFIM-V1FATURCONT NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WDATA_REFER.WFIM_V1FATURCONT.IsEmpty())
            {

                /*" -171- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -174- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1FATURCONT NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WDATA_REFER.WFIM_V1FATURCONT.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -174- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -178- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -179- DISPLAY 'CONTROLE FATURAS LIDAS   ' AC-L-V1FATURCONT */
            _.Display($"CONTROLE FATURAS LIDAS   {AREA_DE_WORK.WDATA_REFER.AC_L_V1FATURCONT}");

            /*" -180- DISPLAY 'DOCUMENTOS SELECIONADOS  ' */
            _.Display($"DOCUMENTOS SELECIONADOS  ");

            /*" -181- DISPLAY ' . FATURAS               ' AC-S-V1FATURAS */
            _.Display($" . FATURAS               {AREA_DE_WORK.WDATA_REFER.AC_S_V1FATURAS}");

            /*" -182- DISPLAY 'DOCUMENTOS ATUALIZADOS   ' */
            _.Display($"DOCUMENTOS ATUALIZADOS   ");

            /*" -182- DISPLAY ' . CONTROLE FATURAS      ' AC-A-V0FATURCONT. */
            _.Display($" . CONTROLE FATURAS      {AREA_DE_WORK.WDATA_REFER.AC_A_V0FATURCONT}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -188- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -188- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLA-V1FATURCONT-SECTION */
        private void R0900_00_DECLA_V1FATURCONT_SECTION()
        {
            /*" -201- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -208- PERFORM R0900_00_DECLA_V1FATURCONT_DB_DECLARE_1 */

            R0900_00_DECLA_V1FATURCONT_DB_DECLARE_1();

            /*" -210- PERFORM R0900_00_DECLA_V1FATURCONT_DB_OPEN_1 */

            R0900_00_DECLA_V1FATURCONT_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLA-V1FATURCONT-DB-DECLARE-1 */
        public void R0900_00_DECLA_V1FATURCONT_DB_DECLARE_1()
        {
            /*" -208- EXEC SQL DECLARE V1FATURCONT CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , DATA_REFERENCIA FROM SEGUROS.V1FATURCONT ORDER BY NUM_APOLICE, COD_SUBGRUPO END-EXEC. */
            V1FATURCONT = new VG0106B_V1FATURCONT(false);
            string GetQuery_V1FATURCONT()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							DATA_REFERENCIA 
							FROM SEGUROS.V1FATURCONT 
							ORDER BY NUM_APOLICE
							, 
							COD_SUBGRUPO";

                return query;
            }
            V1FATURCONT.GetQueryEvent += GetQuery_V1FATURCONT;

        }

        [StopWatch]
        /*" R0900-00-DECLA-V1FATURCONT-DB-OPEN-1 */
        public void R0900_00_DECLA_V1FATURCONT_DB_OPEN_1()
        {
            /*" -210- EXEC SQL OPEN V1FATURCONT END-EXEC. */

            V1FATURCONT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1FATURCONT-SECTION */
        private void R0910_00_FETCH_V1FATURCONT_SECTION()
        {
            /*" -223- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -227- PERFORM R0910_00_FETCH_V1FATURCONT_DB_FETCH_1 */

            R0910_00_FETCH_V1FATURCONT_DB_FETCH_1();

            /*" -230- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -231- MOVE 'S' TO WFIM-V1FATURCONT */
                _.Move("S", AREA_DE_WORK.WDATA_REFER.WFIM_V1FATURCONT);

                /*" -231- PERFORM R0910_00_FETCH_V1FATURCONT_DB_CLOSE_1 */

                R0910_00_FETCH_V1FATURCONT_DB_CLOSE_1();

                /*" -234- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -234- ADD +1 TO AC-L-V1FATURCONT. */
            AREA_DE_WORK.WDATA_REFER.AC_L_V1FATURCONT.Value = AREA_DE_WORK.WDATA_REFER.AC_L_V1FATURCONT + +1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1FATURCONT-DB-FETCH-1 */
        public void R0910_00_FETCH_V1FATURCONT_DB_FETCH_1()
        {
            /*" -227- EXEC SQL FETCH V1FATURCONT INTO :V1FATC-NUM-APOL , :V1FATC-COD-SUBG , :V1FATC-DATA-REFER END-EXEC. */

            if (V1FATURCONT.Fetch())
            {
                _.Move(V1FATURCONT.V1FATC_NUM_APOL, V1FATC_NUM_APOL);
                _.Move(V1FATURCONT.V1FATC_COD_SUBG, V1FATC_COD_SUBG);
                _.Move(V1FATURCONT.V1FATC_DATA_REFER, V1FATC_DATA_REFER);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1FATURCONT-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1FATURCONT_DB_CLOSE_1()
        {
            /*" -231- EXEC SQL CLOSE V1FATURCONT END-EXEC */

            V1FATURCONT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -247- MOVE V1FATC-DATA-REFER TO WDATA-REFER. */
            _.Move(V1FATC_DATA_REFER, AREA_DE_WORK.WDATA_REFER);

            /*" -251- IF (V1FATC-NUM-APOL EQUAL 97010000889) AND (V1FATC-COD-SUBG EQUAL 1 OR 1948 OR 1949 OR 1950 OR 1951 OR 2910) */

            if ((V1FATC_NUM_APOL == 97010000889) && (V1FATC_COD_SUBG.In("1", "1948", "1949", "1950", "1951", "2910")))
            {

                /*" -252- PERFORM R1200-00-SELECT-V0FATURASFIL */

                R1200_00_SELECT_V0FATURASFIL_SECTION();

                /*" -255- IF V1FATR-NUM-FATUR EQUAL ZEROS */

                if (V1FATR_NUM_FATUR == 00)
                {

                    /*" -256- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -257- ELSE */
                }
                else
                {


                    /*" -258- ADD +1 TO AC-S-V1FATURAS */
                    AREA_DE_WORK.WDATA_REFER.AC_S_V1FATURAS.Value = AREA_DE_WORK.WDATA_REFER.AC_S_V1FATURAS + +1;

                    /*" -259- PERFORM R1250-00-SELECT-V0FATURASFIL */

                    R1250_00_SELECT_V0FATURASFIL_SECTION();

                    /*" -260- ELSE */
                }

            }
            else
            {


                /*" -261- PERFORM R1100-00-SELECT-V1FATURAS */

                R1100_00_SELECT_V1FATURAS_SECTION();

                /*" -264- IF V1FATR-NUM-FATUR EQUAL ZEROS */

                if (V1FATR_NUM_FATUR == 00)
                {

                    /*" -265- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -266- ELSE */
                }
                else
                {


                    /*" -267- ADD +1 TO AC-S-V1FATURAS */
                    AREA_DE_WORK.WDATA_REFER.AC_S_V1FATURAS.Value = AREA_DE_WORK.WDATA_REFER.AC_S_V1FATURAS + +1;

                    /*" -269- PERFORM R1150-00-SELECT-V1FATURAS. */

                    R1150_00_SELECT_V1FATURAS_SECTION();
                }

            }


            /*" -271- PERFORM R1500-00-SELECT-V0SOLICITA. */

            R1500_00_SELECT_V0SOLICITA_SECTION();

            /*" -272- IF V0SOLI-SITUACAO EQUAL '0' */

            if (V0SOLI_SITUACAO == "0")
            {

                /*" -274- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -276- PERFORM R1300-00-SELECT-V0SUBGRUPO. */

            R1300_00_SELECT_V0SUBGRUPO_SECTION();

            /*" -277- MOVE V1FATR-NUM-FATUR TO WNUM-FATURA. */
            _.Move(V1FATR_NUM_FATUR, AREA_DE_WORK.WDATA_REFER.WNUM_FATURA);

            /*" -278- MOVE WFAT-ANO TO WS-AABASE. */
            _.Move(AREA_DE_WORK.WDATA_REFER.FILLER_4.WFAT_ANO, AREA_DE_WORK.WS_DTBASE.WS_AABASE);

            /*" -279- MOVE WFAT-MES TO WS-MMBASE. */
            _.Move(AREA_DE_WORK.WDATA_REFER.FILLER_4.WFAT_MES, AREA_DE_WORK.WS_DTBASE.WS_MMBASE);

            /*" -283- MOVE WREF-DIA TO WS-DDBASE. */
            _.Move(AREA_DE_WORK.WDATA_REFER.WREF_DIA, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

            /*" -284- IF V1FATR-CODOPER GREATER +100 */

            if (V1FATR_CODOPER > +100)
            {

                /*" -286- COMPUTE WS-MMBASE = WS-MMBASE + V0SUBG-PERI-FATUR */
                AREA_DE_WORK.WS_DTBASE.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_MMBASE + V0SUBG_PERI_FATUR;

                /*" -287- IF WS-MMBASE GREATER 12 */

                if (AREA_DE_WORK.WS_DTBASE.WS_MMBASE > 12)
                {

                    /*" -288- COMPUTE WS-MMBASE = WS-MMBASE - 12 */
                    AREA_DE_WORK.WS_DTBASE.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_MMBASE - 12;

                    /*" -290- COMPUTE WS-AABASE = WS-AABASE + 1. */
                    AREA_DE_WORK.WS_DTBASE.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_AABASE + 1;
                }

            }


            /*" -291- IF WS-DDBASE GREATER 30 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 30)
            {

                /*" -293- IF WS-MMBASE EQUAL 04 OR 06 OR 09 OR 11 */

                if (AREA_DE_WORK.WS_DTBASE.WS_MMBASE.In("04", "06", "09", "11"))
                {

                    /*" -295- MOVE 30 TO WS-DDBASE. */
                    _.Move(30, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);
                }

            }


            /*" -297- IF WS-MMBASE EQUAL 02 AND WS-DDBASE GREATER 28 */

            if (AREA_DE_WORK.WS_DTBASE.WS_MMBASE == 02 && AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 28)
            {

                /*" -298- MOVE WS-AABASE TO WANO */
                _.Move(AREA_DE_WORK.WS_DTBASE.WS_AABASE, AREA_DE_WORK.WDATA_REFER.WANO);

                /*" -299- IF WS-AABASE EQUAL ((WANO / 4) * 4) */

                if (AREA_DE_WORK.WS_DTBASE.WS_AABASE == (AREA_DE_WORK.WDATA_REFER.WANO / 4 * 4))
                {

                    /*" -300- MOVE 29 TO WS-DDBASE */
                    _.Move(29, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -301- ELSE */
                }
                else
                {


                    /*" -307- MOVE 28 TO WS-DDBASE. */
                    _.Move(28, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);
                }

            }


            /*" -308- MOVE WS-DTBASE TO WHOST-DTREFER */
            _.Move(AREA_DE_WORK.WS_DTBASE, WHOST_DTREFER);

            /*" -308- PERFORM R1400-00-UPDATE-V1FATURCONT. */

            R1400_00_UPDATE_V1FATURCONT_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -312- PERFORM R0910-00-FETCH-V1FATURCONT. */

            R0910_00_FETCH_V1FATURCONT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1FATURAS-SECTION */
        private void R1100_00_SELECT_V1FATURAS_SECTION()
        {
            /*" -325- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -333- PERFORM R1100_00_SELECT_V1FATURAS_DB_SELECT_1 */

            R1100_00_SELECT_V1FATURAS_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1100-00-SELECT-V1FATURAS-DB-SELECT-1 */
        public void R1100_00_SELECT_V1FATURAS_DB_SELECT_1()
        {
            /*" -333- EXEC SQL SELECT VALUE(MAX(NUM_FATURA),0) INTO :V1FATR-NUM-FATUR FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG AND SIT_REGISTRO = '0' END-EXEC. */

            var r1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1()
            {
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1FATURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_NUM_FATUR, V1FATR_NUM_FATUR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-V1FATURAS-SECTION */
        private void R1150_00_SELECT_V1FATURAS_SECTION()
        {
            /*" -346- MOVE '115' TO WNR-EXEC-SQL. */
            _.Move("115", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -353- PERFORM R1150_00_SELECT_V1FATURAS_DB_SELECT_1 */

            R1150_00_SELECT_V1FATURAS_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1150-00-SELECT-V1FATURAS-DB-SELECT-1 */
        public void R1150_00_SELECT_V1FATURAS_DB_SELECT_1()
        {
            /*" -353- EXEC SQL SELECT COD_OPERACAO INTO :V1FATR-CODOPER FROM SEGUROS.V1FATURAS WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG AND NUM_FATURA = :V1FATR-NUM-FATUR END-EXEC. */

            var r1150_00_SELECT_V1FATURAS_DB_SELECT_1_Query1 = new R1150_00_SELECT_V1FATURAS_DB_SELECT_1_Query1()
            {
                V1FATR_NUM_FATUR = V1FATR_NUM_FATUR.ToString(),
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            var executed_1 = R1150_00_SELECT_V1FATURAS_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_V1FATURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_CODOPER, V1FATR_CODOPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0FATURASFIL-SECTION */
        private void R1200_00_SELECT_V0FATURASFIL_SECTION()
        {
            /*" -366- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -374- PERFORM R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1 */

            R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1200-00-SELECT-V0FATURASFIL-DB-SELECT-1 */
        public void R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1()
        {
            /*" -374- EXEC SQL SELECT VALUE(MAX(NUM_FATURA),0) INTO :V1FATR-NUM-FATUR FROM SEGUROS.V0FATURASFIL WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG AND SIT_REGISTRO = '0' END-EXEC. */

            var r1200_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1()
            {
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_NUM_FATUR, V1FATR_NUM_FATUR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-V0FATURASFIL-SECTION */
        private void R1250_00_SELECT_V0FATURASFIL_SECTION()
        {
            /*" -387- MOVE '125' TO WNR-EXEC-SQL. */
            _.Move("125", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -394- PERFORM R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1 */

            R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1250-00-SELECT-V0FATURASFIL-DB-SELECT-1 */
        public void R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1()
        {
            /*" -394- EXEC SQL SELECT COD_OPERACAO INTO :V1FATR-CODOPER FROM SEGUROS.V0FATURASFIL WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG AND NUM_FATURA = :V1FATR-NUM-FATUR END-EXEC. */

            var r1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1 = new R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1()
            {
                V1FATR_NUM_FATUR = V1FATR_NUM_FATUR.ToString(),
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            var executed_1 = R1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1.Execute(r1250_00_SELECT_V0FATURASFIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FATR_CODOPER, V1FATR_CODOPER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0SUBGRUPO-SECTION */
        private void R1300_00_SELECT_V0SUBGRUPO_SECTION()
        {
            /*" -407- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -413- PERFORM R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1 */

            R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1300-00-SELECT-V0SUBGRUPO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1()
        {
            /*" -413- EXEC SQL SELECT PERI_FATURAMENTO INTO :V0SUBG-PERI-FATUR FROM SEGUROS.V0SUBGRUPO WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG END-EXEC. */

            var r1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1()
            {
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_PERI_FATUR, V0SUBG_PERI_FATUR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-UPDATE-V1FATURCONT-SECTION */
        private void R1400_00_UPDATE_V1FATURCONT_SECTION()
        {
            /*" -426- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -431- PERFORM R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1 */

            R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1();

            /*" -434- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -437- DISPLAY 'R1400-00 (PROBLEMAS UPDATE V0FATURCONT) ' ' ' V1FATC-NUM-APOL ' ' V1FATC-COD-SUBG ' ' WHOST-DTREFER */

                $"R1400-00 (PROBLEMAS UPDATE V0FATURCONT)  {V1FATC_NUM_APOL} {V1FATC_COD_SUBG} {WHOST_DTREFER}"
                .Display();

                /*" -439- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -439- ADD +1 TO AC-A-V0FATURCONT. */
            AREA_DE_WORK.WDATA_REFER.AC_A_V0FATURCONT.Value = AREA_DE_WORK.WDATA_REFER.AC_A_V0FATURCONT + +1;

        }

        [StopWatch]
        /*" R1400-00-UPDATE-V1FATURCONT-DB-UPDATE-1 */
        public void R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1()
        {
            /*" -431- EXEC SQL UPDATE SEGUROS.V0FATURCONT SET DATA_REFERENCIA = :WHOST-DTREFER WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG END-EXEC. */

            var r1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1 = new R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1()
            {
                WHOST_DTREFER = WHOST_DTREFER.ToString(),
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            R1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1.Execute(r1400_00_UPDATE_V1FATURCONT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-V0SOLICITA-SECTION */
        private void R1500_00_SELECT_V0SOLICITA_SECTION()
        {
            /*" -452- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", AREA_DE_WORK.WDATA_REFER.WABEND.WNR_EXEC_SQL);

            /*" -459- PERFORM R1500_00_SELECT_V0SOLICITA_DB_SELECT_1 */

            R1500_00_SELECT_V0SOLICITA_DB_SELECT_1();

        }

        [StopWatch]
        /*" R1500-00-SELECT-V0SOLICITA-DB-SELECT-1 */
        public void R1500_00_SELECT_V0SOLICITA_DB_SELECT_1()
        {
            /*" -459- EXEC SQL SELECT SIT_REGISTRO INTO :V0SOLI-SITUACAO FROM SEGUROS.V0SOLICITAFAT WHERE NUM_APOLICE = :V1FATC-NUM-APOL AND COD_SUBGRUPO = :V1FATC-COD-SUBG AND NUM_FATURA = :V1FATR-NUM-FATUR END-EXEC. */

            var r1500_00_SELECT_V0SOLICITA_DB_SELECT_1_Query1 = new R1500_00_SELECT_V0SOLICITA_DB_SELECT_1_Query1()
            {
                V1FATR_NUM_FATUR = V1FATR_NUM_FATUR.ToString(),
                V1FATC_NUM_APOL = V1FATC_NUM_APOL.ToString(),
                V1FATC_COD_SUBG = V1FATC_COD_SUBG.ToString(),
            };

            var executed_1 = R1500_00_SELECT_V0SOLICITA_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_V0SOLICITA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SOLI_SITUACAO, V0SOLI_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -473- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WDATA_REFER.WABEND.WSQLCODE);

            /*" -475- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WDATA_REFER.WABEND);

            /*" -475- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -477- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -481- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -481- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}