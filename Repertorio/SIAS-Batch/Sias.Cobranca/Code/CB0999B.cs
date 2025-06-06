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
using Sias.Cobranca.DB2.CB0999B;

namespace Code
{
    public class CB0999B
    {
        public bool IsCall { get; set; }

        public CB0999B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0999B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  NOVEMBRO/1991                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  INSERIR NA TABELA V0RELATORIOS OS  *      */
        /*"      *                             PEDIDOS PARA EXECUCAO DOS          *      */
        /*"      *                             PROGRAMAS :                        *      */
        /*"      *                             . CB0100B                          *      */
        /*"      *                             . CB1000B                          *      */
        /*"      *                             . CB1005B                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            VIEW                 ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          V0SISTEMA            INPUT   *      */
        /*"      * RELATORIOS                        V0RELATORIOS         I-O     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACOES                                                   *      */
        /*"      *   EM 22.06.95 POR KITA (PROCAS) ......... PROCURE POR  KT001   *      */
        /*"      *   - INCLUSAO DA SOLICITACAO DO RELATORIO CB0100B               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EM JUN/2011 POR GILSON PINTO DA SILVA - PROCURAR GP0611       *      */
        /*"      *  - ALTERACAO PARA TRATAR O NOVO CONVENIO AUTO SAS - ORGAO 110  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"C74620*  ALTERACAO - DESLIGAMENTO DE ROTINAS E PROGRAMAS               *      */
        /*"      * 24/01/2013 - WELLINGTON VERAS (TE39902) - PROCURAR POR C74620  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-COD-EMPR       PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PERI-RENOV     PIC S9(004)                COMP.*/
        public IntBasis VIND_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PCT-AUMENTO    PIC S9(004)                COMP.*/
        public IntBasis VIND_PCT_AUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0SIST-DTMOVABE   PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-CODUSU       PIC  X(008).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0RELA-DT-SOLIC     PIC  X(010).*/
        public StringBasis V0RELA_DT_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-IDSISTEM     PIC  X(002).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0RELA-NRCOPIAS     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-QTDE         PIC S9(004)                COMP.*/
        public IntBasis V0RELA_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-PERI-INIC    PIC  X(010).*/
        public StringBasis V0RELA_PERI_INIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-PERI-FINAL   PIC  X(010).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-DATA-REFER   PIC  X(010).*/
        public StringBasis V0RELA_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0RELA-MES-REFER    PIC S9(004)                COMP.*/
        public IntBasis V0RELA_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-ANO-REFER    PIC S9(004)                COMP.*/
        public IntBasis V0RELA_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-ORGAO        PIC S9(004)                COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-CODPDT       PIC S9(009)                COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELA-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-MODALID      PIC S9(004)                COMP.*/
        public IntBasis V0RELA_MODALID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-CONGENER     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELA-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRCERTIF     PIC S9(015)                COMP-3*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0RELA-NRTIT        PIC S9(013)                COMP-3*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-COD-PLANO    PIC S9(004)                COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-APOL-LIDER   PIC  X(015).*/
        public StringBasis V0RELA_APOL_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0RELA-ENDS-LIDER   PIC  X(015).*/
        public StringBasis V0RELA_ENDS_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0RELA-NRPARC-LID   PIC S9(004)                COMP.*/
        public IntBasis V0RELA_NRPARC_LID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NUM-SINIST   PIC S9(013)                COMP-3*/
        public IntBasis V0RELA_NUM_SINIST { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-NSINI-LID    PIC  X(015).*/
        public StringBasis V0RELA_NSINI_LID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0RELA-NUM-ORDEM    PIC S9(015)                COMP-3*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0RELA-CODUNIMO     PIC S9(004)                COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-CORRECAO     PIC  X(001).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RELA-SITUACAO     PIC  X(001).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RELA-PRV-DEF      PIC  X(001).*/
        public StringBasis V0RELA_PRV_DEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RELA-ANAL-RESU    PIC  X(001).*/
        public StringBasis V0RELA_ANAL_RESU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RELA-COD-EMPR     PIC S9(009)                COMP.*/
        public IntBasis V0RELA_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELA-PERI-RENOV   PIC S9(004)                COMP.*/
        public IntBasis V0RELA_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-PCT-AUMENTO  PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"01           AREA-DE-WORK.*/
        public CB0999B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0999B_AREA_DE_WORK();
        public class CB0999B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WRESTO            PIC S9(003)    VALUE +0 COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05         WDATA-REF         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REF.*/
            private _REDEF_CB0999B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB0999B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB0999B_FILLER_0(); _.Move(WDATA_REF, _filler_0); VarBasis.RedefinePassValue(WDATA_REF, _filler_0, WDATA_REF); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REF); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REF); }
            }  //Redefines
            public class _REDEF_CB0999B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REF-ANO      PIC  9(004).*/
                public IntBasis WDAT_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REF-MES      PIC  9(002).*/
                public IntBasis WDAT_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REF-DIA      PIC  9(002).*/
                public IntBasis WDAT_REF_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WREFE-DATA-INI    PIC  X(010)    VALUE SPACES.*/

                public _REDEF_CB0999B_FILLER_0()
                {
                    WDAT_REF_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REF_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REF_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WREFE_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WREFE-DATA-INI.*/
            private _REDEF_CB0999B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_CB0999B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_CB0999B_FILLER_3(); _.Move(WREFE_DATA_INI, _filler_3); VarBasis.RedefinePassValue(WREFE_DATA_INI, _filler_3, WREFE_DATA_INI); _filler_3.ValueChanged += () => { _.Move(_filler_3, WREFE_DATA_INI); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WREFE_DATA_INI); }
            }  //Redefines
            public class _REDEF_CB0999B_FILLER_3 : VarBasis
            {
                /*"    10       WREFE-ANO-INI     PIC  9(004).*/
                public IntBasis WREFE_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WREFE-BR1-INI     PIC  X(001).*/
                public StringBasis WREFE_BR1_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREFE-MES-INI     PIC  9(002).*/
                public IntBasis WREFE_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WREFE-BR2-INI     PIC  X(001).*/
                public StringBasis WREFE_BR2_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREFE-DIA-INI     PIC  9(002).*/
                public IntBasis WREFE_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WREFE-DATA-TER    PIC  X(010)    VALUE SPACES.*/

                public _REDEF_CB0999B_FILLER_3()
                {
                    WREFE_ANO_INI.ValueChanged += OnValueChanged;
                    WREFE_BR1_INI.ValueChanged += OnValueChanged;
                    WREFE_MES_INI.ValueChanged += OnValueChanged;
                    WREFE_BR2_INI.ValueChanged += OnValueChanged;
                    WREFE_DIA_INI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WREFE_DATA_TER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WREFE-DATA-TER.*/
            private _REDEF_CB0999B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_CB0999B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_CB0999B_FILLER_4(); _.Move(WREFE_DATA_TER, _filler_4); VarBasis.RedefinePassValue(WREFE_DATA_TER, _filler_4, WREFE_DATA_TER); _filler_4.ValueChanged += () => { _.Move(_filler_4, WREFE_DATA_TER); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WREFE_DATA_TER); }
            }  //Redefines
            public class _REDEF_CB0999B_FILLER_4 : VarBasis
            {
                /*"    10       WREFE-ANO-TER     PIC  9(004).*/
                public IntBasis WREFE_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WREFE-BR1-TER     PIC  X(001).*/
                public StringBasis WREFE_BR1_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREFE-MES-TER     PIC  9(002).*/
                public IntBasis WREFE_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WREFE-BR2-TER     PIC  X(001).*/
                public StringBasis WREFE_BR2_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WREFE-DIA-TER     PIC  9(002).*/
                public IntBasis WREFE_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           WABEND.*/

                public _REDEF_CB0999B_FILLER_4()
                {
                    WREFE_ANO_TER.ValueChanged += OnValueChanged;
                    WREFE_BR1_TER.ValueChanged += OnValueChanged;
                    WREFE_MES_TER.ValueChanged += OnValueChanged;
                    WREFE_BR2_TER.ValueChanged += OnValueChanged;
                    WREFE_DIA_TER.ValueChanged += OnValueChanged;
                }

            }
        }
        public CB0999B_WABEND WABEND { get; set; } = new CB0999B_WABEND();
        public class CB0999B_WABEND : VarBasis
        {
            /*"  05         FILLER            PIC  X(010)     VALUE            ' CB0999B'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0999B");
            /*"  05         FILLER            PIC  X(026)     VALUE            ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05         WNR-EXEC-SQL      PIC  X(003)     VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05         FILLER            PIC  X(013)     VALUE            ' *** SQLCODE '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05         WSQLCODE          PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }

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
            /*" -208- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -209- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -212- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -215- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -219- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -221- PERFORM R0200-00-DELETE-V0RELATORIOS. */

            R0200_00_DELETE_V0RELATORIOS_SECTION();

            /*" -223- PERFORM R0300-00-MONTA-SOLIC-RELAT. */

            R0300_00_MONTA_SOLIC_RELAT_SECTION();

            /*" -225- PERFORM R0400-00-GRAVA-SOLIC-RELAT. */

            R0400_00_GRAVA_SOLIC_RELAT_SECTION();

            /*" -225- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -229- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -229- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -240- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -245- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -249- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA");

                /*" -250- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -251- ELSE */
            }
            else
            {


                /*" -253- DISPLAY 'DATA DO MOVIMENTO CB - ' V0SIST-DTMOVABE. */
                _.Display($"DATA DO MOVIMENTO CB - {V0SIST_DTMOVABE}");
            }


            /*" -255- MOVE V0SIST-DTMOVABE TO WDATA-REF. */
            _.Move(V0SIST_DTMOVABE, AREA_DE_WORK.WDATA_REF);

            /*" -256- IF WDAT-REF-MES = 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.FILLER_0.WDAT_REF_MES.In("04", "06", "09", "11"))
            {

                /*" -257- MOVE 30 TO WREFE-DIA-TER */
                _.Move(30, AREA_DE_WORK.FILLER_4.WREFE_DIA_TER);

                /*" -258- ELSE */
            }
            else
            {


                /*" -259- IF WDAT-REF-MES = 02 */

                if (AREA_DE_WORK.FILLER_0.WDAT_REF_MES == 02)
                {

                    /*" -261- COMPUTE WRESTO = WDAT-REF-ANO - (WDAT-REF-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.FILLER_0.WDAT_REF_ANO - (AREA_DE_WORK.FILLER_0.WDAT_REF_ANO / 4 * 4);

                    /*" -262- IF WRESTO = ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -263- MOVE 29 TO WREFE-DIA-TER */
                        _.Move(29, AREA_DE_WORK.FILLER_4.WREFE_DIA_TER);

                        /*" -264- ELSE */
                    }
                    else
                    {


                        /*" -265- MOVE 28 TO WREFE-DIA-TER */
                        _.Move(28, AREA_DE_WORK.FILLER_4.WREFE_DIA_TER);

                        /*" -266- ELSE */
                    }

                }
                else
                {


                    /*" -268- MOVE 31 TO WREFE-DIA-TER. */
                    _.Move(31, AREA_DE_WORK.FILLER_4.WREFE_DIA_TER);
                }

            }


            /*" -269- MOVE WDAT-REF-MES TO WREFE-MES-TER. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REF_MES, AREA_DE_WORK.FILLER_4.WREFE_MES_TER);

            /*" -271- MOVE WDAT-REF-ANO TO WREFE-ANO-TER. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REF_ANO, AREA_DE_WORK.FILLER_4.WREFE_ANO_TER);

            /*" -272- MOVE WREFE-DATA-TER TO WREFE-DATA-INI. */
            _.Move(AREA_DE_WORK.WREFE_DATA_TER, AREA_DE_WORK.WREFE_DATA_INI);

            /*" -274- MOVE 01 TO WREFE-DIA-INI. */
            _.Move(01, AREA_DE_WORK.FILLER_3.WREFE_DIA_INI);

            /*" -277- MOVE '-' TO WREFE-BR1-INI WREFE-BR2-INI WREFE-BR1-TER WREFE-BR2-TER. */
            _.Move("-", AREA_DE_WORK.FILLER_3.WREFE_BR1_INI);
            _.Move("-", AREA_DE_WORK.FILLER_3.WREFE_BR2_INI);
            _.Move("-", AREA_DE_WORK.FILLER_4.WREFE_BR1_TER);
            _.Move("-", AREA_DE_WORK.FILLER_4.WREFE_BR2_TER);


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -245- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DELETE-V0RELATORIOS-SECTION */
        private void R0200_00_DELETE_V0RELATORIOS_SECTION()
        {
            /*" -290- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -296- PERFORM R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1 */

            R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1();

            /*" -299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -301- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -302- ELSE */
                }
                else
                {


                    /*" -303- DISPLAY 'R0200 - ERRO NO DELETE DA V0RELATORIOS' */
                    _.Display($"R0200 - ERRO NO DELETE DA V0RELATORIOS");

                    /*" -303- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0200-00-DELETE-V0RELATORIOS-DB-DELETE-1 */
        public void R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -296- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'CB' AND CODRELAT IN ( 'CB0100B1' , 'CB1000B1' , 'CB1005B1' ) END-EXEC. */

            var r0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1 = new R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            R0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r0200_00_DELETE_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-MONTA-SOLIC-RELAT-SECTION */
        private void R0300_00_MONTA_SOLIC_RELAT_SECTION()
        {
            /*" -316- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -317- MOVE 'CB0999B ' TO V0RELA-CODUSU. */
            _.Move("CB0999B ", V0RELA_CODUSU);

            /*" -318- MOVE V0SIST-DTMOVABE TO V0RELA-DT-SOLIC. */
            _.Move(V0SIST_DTMOVABE, V0RELA_DT_SOLIC);

            /*" -320- MOVE 'CB' TO V0RELA-IDSISTEM. */
            _.Move("CB", V0RELA_IDSISTEM);

            /*" -322- MOVE SPACES TO V0RELA-CODRELAT. */
            _.Move("", V0RELA_CODRELAT);

            /*" -325- MOVE ZEROS TO V0RELA-NRCOPIAS V0RELA-QTDE. */
            _.Move(0, V0RELA_NRCOPIAS, V0RELA_QTDE);

            /*" -326- MOVE WREFE-DATA-INI TO V0RELA-PERI-INIC. */
            _.Move(AREA_DE_WORK.WREFE_DATA_INI, V0RELA_PERI_INIC);

            /*" -329- MOVE WREFE-DATA-TER TO V0RELA-PERI-FINAL V0RELA-DATA-REFER. */
            _.Move(AREA_DE_WORK.WREFE_DATA_TER, V0RELA_PERI_FINAL, V0RELA_DATA_REFER);

            /*" -330- MOVE WDAT-REF-MES TO V0RELA-MES-REFER. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REF_MES, V0RELA_MES_REFER);

            /*" -332- MOVE WDAT-REF-ANO TO V0RELA-ANO-REFER. */
            _.Move(AREA_DE_WORK.FILLER_0.WDAT_REF_ANO, V0RELA_ANO_REFER);

            /*" -348- MOVE ZEROS TO V0RELA-ORGAO V0RELA-FONTE V0RELA-CODPDT V0RELA-RAMO V0RELA-MODALID V0RELA-CONGENER V0RELA-NUM-APOL V0RELA-NRENDOS V0RELA-NRPARCEL V0RELA-NRCERTIF V0RELA-NRTIT V0RELA-CODSUBES V0RELA-OPERACAO V0RELA-COD-PLANO V0RELA-OCORHIST. */
            _.Move(0, V0RELA_ORGAO, V0RELA_FONTE, V0RELA_CODPDT, V0RELA_RAMO, V0RELA_MODALID, V0RELA_CONGENER, V0RELA_NUM_APOL, V0RELA_NRENDOS, V0RELA_NRPARCEL, V0RELA_NRCERTIF, V0RELA_NRTIT, V0RELA_CODSUBES, V0RELA_OPERACAO, V0RELA_COD_PLANO, V0RELA_OCORHIST);

            /*" -351- MOVE SPACES TO V0RELA-APOL-LIDER V0RELA-ENDS-LIDER. */
            _.Move("", V0RELA_APOL_LIDER, V0RELA_ENDS_LIDER);

            /*" -354- MOVE ZEROS TO V0RELA-NRPARC-LID V0RELA-NUM-SINIST. */
            _.Move(0, V0RELA_NRPARC_LID, V0RELA_NUM_SINIST);

            /*" -355- MOVE SPACES TO V0RELA-NSINI-LID. */
            _.Move("", V0RELA_NSINI_LID);

            /*" -358- MOVE ZEROS TO V0RELA-NUM-ORDEM V0RELA-CODUNIMO. */
            _.Move(0, V0RELA_NUM_ORDEM, V0RELA_CODUNIMO);

            /*" -359- MOVE SPACES TO V0RELA-CORRECAO. */
            _.Move("", V0RELA_CORRECAO);

            /*" -360- MOVE ZEROS TO V0RELA-SITUACAO. */
            _.Move(0, V0RELA_SITUACAO);

            /*" -361- MOVE SPACES TO V0RELA-PRV-DEF. */
            _.Move("", V0RELA_PRV_DEF);

            /*" -363- MOVE SPACES TO V0RELA-ANAL-RESU. */
            _.Move("", V0RELA_ANAL_RESU);

            /*" -367- MOVE ZEROS TO V0RELA-COD-EMPR V0RELA-PERI-RENOV V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_COD_EMPR, V0RELA_PERI_RENOV, V0RELA_PCT_AUMENTO);

            /*" -369- MOVE -1 TO VIND-COD-EMPR VIND-PERI-RENOV VIND-PCT-AUMENTO. */
            _.Move(-1, VIND_COD_EMPR, VIND_PERI_RENOV, VIND_PCT_AUMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-GRAVA-SOLIC-RELAT-SECTION */
        private void R0400_00_GRAVA_SOLIC_RELAT_SECTION()
        {
            /*" -382- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -383- MOVE 'CB0100B1' TO V0RELA-CODRELAT. */
            _.Move("CB0100B1", V0RELA_CODRELAT);

            /*" -385- PERFORM R0500-00-INSERT-V0RELATORIOS. */

            R0500_00_INSERT_V0RELATORIOS_SECTION();

            /*" -386- MOVE 'CB1000B1' TO V0RELA-CODRELAT. */
            _.Move("CB1000B1", V0RELA_CODRELAT);

            /*" -386- PERFORM R0500-00-INSERT-V0RELATORIOS. */

            R0500_00_INSERT_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-INSERT-V0RELATORIOS-SECTION */
        private void R0500_00_INSERT_V0RELATORIOS_SECTION()
        {
            /*" -427- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -470- PERFORM R0500_00_INSERT_V0RELATORIOS_DB_INSERT_1 */

            R0500_00_INSERT_V0RELATORIOS_DB_INSERT_1();

            /*" -473- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -474- DISPLAY 'R0500 - ERRO NO INSERT DA V0RELATORIOS' */
                _.Display($"R0500 - ERRO NO INSERT DA V0RELATORIOS");

                /*" -475- DISPLAY 'COD USU  - ' V0RELA-CODUSU */
                _.Display($"COD USU  - {V0RELA_CODUSU}");

                /*" -476- DISPLAY 'DT SOLIC - ' V0RELA-DT-SOLIC */
                _.Display($"DT SOLIC - {V0RELA_DT_SOLIC}");

                /*" -477- DISPLAY 'SISTEMA  - ' V0RELA-IDSISTEM */
                _.Display($"SISTEMA  - {V0RELA_IDSISTEM}");

                /*" -478- DISPLAY 'COD RELA - ' V0RELA-CODRELAT */
                _.Display($"COD RELA - {V0RELA_CODRELAT}");

                /*" -479- DISPLAY 'ORGAO    - ' V0RELA-ORGAO */
                _.Display($"ORGAO    - {V0RELA_ORGAO}");

                /*" -479- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-INSERT-V0RELATORIOS-DB-INSERT-1 */
        public void R0500_00_INSERT_V0RELATORIOS_DB_INSERT_1()
        {
            /*" -470- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU , :V0RELA-DT-SOLIC , :V0RELA-IDSISTEM , :V0RELA-CODRELAT , :V0RELA-NRCOPIAS , :V0RELA-QTDE , :V0RELA-PERI-INIC , :V0RELA-PERI-FINAL , :V0RELA-DATA-REFER , :V0RELA-MES-REFER , :V0RELA-ANO-REFER , :V0RELA-ORGAO , :V0RELA-FONTE , :V0RELA-CODPDT , :V0RELA-RAMO , :V0RELA-MODALID , :V0RELA-CONGENER , :V0RELA-NUM-APOL , :V0RELA-NRENDOS , :V0RELA-NRPARCEL , :V0RELA-NRCERTIF , :V0RELA-NRTIT , :V0RELA-CODSUBES , :V0RELA-OPERACAO , :V0RELA-COD-PLANO , :V0RELA-OCORHIST , :V0RELA-APOL-LIDER , :V0RELA-ENDS-LIDER , :V0RELA-NRPARC-LID , :V0RELA-NUM-SINIST , :V0RELA-NSINI-LID , :V0RELA-NUM-ORDEM , :V0RELA-CODUNIMO , :V0RELA-CORRECAO , :V0RELA-SITUACAO , :V0RELA-PRV-DEF , :V0RELA-ANAL-RESU , :V0RELA-COD-EMPR:VIND-COD-EMPR , :V0RELA-PERI-RENOV:VIND-PERI-RENOV , :V0RELA-PCT-AUMENTO:VIND-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r0500_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1 = new R0500_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DT_SOLIC = V0RELA_DT_SOLIC.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QTDE = V0RELA_QTDE.ToString(),
                V0RELA_PERI_INIC = V0RELA_PERI_INIC.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFER = V0RELA_DATA_REFER.ToString(),
                V0RELA_MES_REFER = V0RELA_MES_REFER.ToString(),
                V0RELA_ANO_REFER = V0RELA_ANO_REFER.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALID = V0RELA_MODALID.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOL = V0RELA_NUM_APOL.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOL_LIDER = V0RELA_APOL_LIDER.ToString(),
                V0RELA_ENDS_LIDER = V0RELA_ENDS_LIDER.ToString(),
                V0RELA_NRPARC_LID = V0RELA_NRPARC_LID.ToString(),
                V0RELA_NUM_SINIST = V0RELA_NUM_SINIST.ToString(),
                V0RELA_NSINI_LID = V0RELA_NSINI_LID.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PRV_DEF = V0RELA_PRV_DEF.ToString(),
                V0RELA_ANAL_RESU = V0RELA_ANAL_RESU.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
                VIND_COD_EMPR = VIND_COD_EMPR.ToString(),
                V0RELA_PERI_RENOV = V0RELA_PERI_RENOV.ToString(),
                VIND_PERI_RENOV = VIND_PERI_RENOV.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
                VIND_PCT_AUMENTO = VIND_PCT_AUMENTO.ToString(),
            };

            R0500_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1.Execute(r0500_00_INSERT_V0RELATORIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -494- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -496- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -496- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -500- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -500- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}