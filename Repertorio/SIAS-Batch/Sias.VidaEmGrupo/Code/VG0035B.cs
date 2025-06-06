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
using Sias.VidaEmGrupo.DB2.VG0035B;

namespace Code
{
    public class VG0035B
    {
        public bool IsCall { get; set; }

        public VG0035B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ MULTIRISCO                          *      */
        /*"      *   PROGRAMA ............... VG0035B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SOLICITACAO ............ CAD 80.084                          *      */
        /*"      *   ANALISTA    ............ TERCIO CARVALHO (FAST COMPUTER)     *      */
        /*"      *   PROGRAMADOR ............ TERCIO CARVALHO (FAST COMPUTER)     *      */
        /*"      *   DATA CODIFICACAO ....... MARCO / 2013                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................. GERA SOLICITACAO DE CANCELAMENTO    *      */
        /*"      *                            PARA SEGUROS NAO CANCELADOS         *      */
        /*"      *                            POR FALHA SPBSC060.                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 02  -  CAD 80.084                                       *      */
        /*"      *                                                                *      */
        /*"      *          ACEITAR DIGITO ZERO PARA A CONTA RESTITUICAO          *      */
        /*"      *                                                                *      */
        /*"      *      EM  19/03/2013  - BRICE / MAURO                           *      */
        /*"      *                                                                *      */
        /*"      *                                     PROCURE POR V.02           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 01  -  CAD 80.084                                       *      */
        /*"      *                                                                *      */
        /*"      *          ACEITAR PARCELAS DIFERENTE DE 1                       *      */
        /*"      *                                                                *      */
        /*"      *      EM  15/03/2013  - TERCIO CARVALHO                         *      */
        /*"      *                                                                *      */
        /*"      *                                     PROCURE POR V.01           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _DVG0035B { get; set; } = new FileBasis(new PIC("X", "220", "X(220)"));

        public FileBasis DVG0035B
        {
            get
            {
                _.Move(REG_DVG0035B, _DVG0035B); VarBasis.RedefinePassValue(REG_DVG0035B, _DVG0035B, REG_DVG0035B); return _DVG0035B;
            }
        }
        /*"01          REG-DVG0035B        PIC X(220).*/
        public StringBasis REG_DVG0035B { get; set; } = new StringBasis(new PIC("X", "220", "X(220)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  VIND-DATA-AVERBACAO       PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-ADMISSAO        PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-INCLUSAO        PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-NASCIMENTO      PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-FATURA          PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-REFERENCIA      PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-MOVIMENTO       PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-EMPRESA          PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-LOT-EMP-SEGURA       PIC S9(004) COMP VALUE +0.*/
        public IntBasis VIND_LOT_EMP_SEGURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  AREA-DE-WORK.*/
        public VG0035B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0035B_AREA_DE_WORK();
        public class VG0035B_AREA_DE_WORK : VarBasis
        {
            /*"   05       WFIM-PROPOVA        PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WTEM-HISCOBPR       PIC  X(03)     VALUE  'SIM'.*/
            public StringBasis WTEM_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"   05       WTEM-PRODUVG        PIC  X(03)     VALUE  'SIM'.*/
            public StringBasis WTEM_PRODUVG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"   05       WTEM-CLIENTES       PIC  X(03)     VALUE  'SIM'.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"   05       WTEM-OPCPAGVI       PIC  X(03)     VALUE  'SIM'.*/
            public StringBasis WTEM_OPCPAGVI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"   05       WTEM-MOVIMVGA       PIC  X(03)     VALUE  'SIM'.*/
            public StringBasis WTEM_MOVIMVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"SIM");
            /*"   05       WS-NULL             PIC S9(04)     COMP VALUE ZEROS.*/
            public IntBasis WS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05       AC-LIDOS            PIC  9(09)     VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-CANCELADOS       PIC  9(09)     VALUE ZEROS.*/
            public IntBasis AC_CANCELADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WABEND.*/
            public VG0035B_WABEND WABEND { get; set; } = new VG0035B_WABEND();
            public class VG0035B_WABEND : VarBasis
            {
                /*"     10     FILLER              PIC  X(010)    VALUE             'VG0035B'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0035B");
                /*"     10     FILLER              PIC  X(026)    VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"     10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"     10     FILLER              PIC  X(013)    VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"   05      CB01.*/
            }
            public VG0035B_CB01 CB01 { get; set; } = new VG0035B_CB01();
            public class VG0035B_CB01 : VarBasis
            {
                /*"     10    FILLER                PIC  X(10)    VALUE 'VG0035B'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VG0035B");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(60)    VALUE          'OCORRENCIA NOS CANCELAMENTOS PRIMEIRO NIVEL'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"OCORRENCIA NOS CANCELAMENTOS PRIMEIRO NIVEL");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)    VALUE 'DATA:'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA:");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    CB01-DATA             PIC  X(10).*/
                public StringBasis CB01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"   05      CB02.*/
            }
            public VG0035B_CB02 CB02 { get; set; } = new VG0035B_CB02();
            public class VG0035B_CB02 : VarBasis
            {
                /*"     10    FILLER                PIC  X(14)    VALUE          'CODIGO PRODUTO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CODIGO PRODUTO");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(17)    VALUE          'DESCRICAO PRODUTO'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"DESCRICAO PRODUTO");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(11)    VALUE          'CERTIFICADO'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(08)    VALUE          'SEGURADO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(03)    VALUE          'CPF'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(13)    VALUE          'DATA PROPOSTA'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DATA PROPOSTA");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(08)    VALUE          'VALOR IS'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"VALOR IS");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(12)    VALUE          'VALOR PREMIO'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VALOR PREMIO");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(12)    VALUE          'OBSERVACAO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"OBSERVACAO");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"   05      LD01.*/
            }
            public VG0035B_LD01 LD01 { get; set; } = new VG0035B_LD01();
            public class VG0035B_LD01 : VarBasis
            {
                /*"     10    LD01-COD-PRODUTO      PIC  9(04).*/
                public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-NOM-PRODUTO      PIC  X(40).*/
                public StringBasis LD01_NOM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-NUM-CERTIFICADO  PIC  9(15).*/
                public IntBasis LD01_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-NOM-CLIENTE      PIC  X(40).*/
                public StringBasis LD01_NOM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-CGCCPF           PIC 9(11).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-DTH-PROPOSTA     PIC  X(10).*/
                public StringBasis LD01_DTH_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-VLR-IS           PIC  999999999999,99.*/
                public DoubleBasis LD01_VLR_IS { get; set; } = new DoubleBasis(new PIC("9", "12", "999999999999V99."), 2);
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-VLR-PREMIO       PIC  9999999999999,99.*/
                public DoubleBasis LD01_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD01-OBSERVACAO       PIC  X(50).*/
                public StringBasis LD01_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"     10    FILLER                PIC  X(01)    VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            }
        }


        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public VG0035B_PROPOSTA PROPOSTA { get; set; } = new VG0035B_PROPOSTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string DVG0035B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                DVG0035B.SetFile(DVG0035B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -247- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -250- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -253- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -255- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -266- MOVE 'R000' TO WNR-EXEC-SQL. */
            _.Move("R000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -267- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -268- DISPLAY 'PROGRAMA EM EXECUCAO VG0035B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO VG0035B   ");

            /*" -269- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -272- DISPLAY 'VERSAO V.02  80.084 19/03/2013 ' . */
            _.Display($"VERSAO V.02  80.084 19/03/2013 ");

            /*" -273- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -276- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -278- PERFORM R0120-SISTEMAS. */

            R0120_SISTEMAS_SECTION();

            /*" -280- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -282- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -283- IF WFIM-PROPOVA EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_PROPOVA == "S")
            {

                /*" -284- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -285- DISPLAY 'NAO EXISTE MOVIMENTO PARA ESTA DATA' */
                _.Display($"NAO EXISTE MOVIMENTO PARA ESTA DATA");

                /*" -286- DISPLAY '*** VG0035B - TERMINO NORMAL ***' */
                _.Display($"*** VG0035B - TERMINO NORMAL ***");

                /*" -288- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -290- OPEN OUTPUT DVG0035B. */
            DVG0035B.Open(REG_DVG0035B);

            /*" -291- WRITE REG-DVG0035B FROM CB01. */
            _.Move(AREA_DE_WORK.CB01.GetMoveValues(), REG_DVG0035B);

            DVG0035B.Write(REG_DVG0035B.GetMoveValues().ToString());

            /*" -293- WRITE REG-DVG0035B FROM CB02. */
            _.Move(AREA_DE_WORK.CB02.GetMoveValues(), REG_DVG0035B);

            DVG0035B.Write(REG_DVG0035B.GetMoveValues().ToString());

            /*" -294- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-PROPOVA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_PROPOVA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -300- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -300- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -304- DISPLAY '*** VG0035B - ' . */
            _.Display($"*** VG0035B - ");

            /*" -305- DISPLAY 'LIDOS PROPOVA ------>' AC-LIDOS. */
            _.Display($"LIDOS PROPOVA ------>{AREA_DE_WORK.AC_LIDOS}");

            /*" -306- DISPLAY 'GRAVADOS SAIDA ----->' AC-GRAVADOS. */
            _.Display($"GRAVADOS SAIDA ----->{AREA_DE_WORK.AC_GRAVADOS}");

            /*" -308- DISPLAY 'CANCELADOS --------->' AC-CANCELADOS. */
            _.Display($"CANCELADOS --------->{AREA_DE_WORK.AC_CANCELADOS}");

            /*" -310- CLOSE DVG0035B. */
            DVG0035B.Close();

            /*" -312- DISPLAY '*** VG0035B - TERMINO NORMAL ***' . */
            _.Display($"*** VG0035B - TERMINO NORMAL ***");

            /*" -312- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0120-SISTEMAS-SECTION */
        private void R0120_SISTEMAS_SECTION()
        {
            /*" -326- MOVE 'R012' TO WNR-EXEC-SQL. */
            _.Move("R012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -331- PERFORM R0120_SISTEMAS_DB_SELECT_1 */

            R0120_SISTEMAS_DB_SELECT_1();

            /*" -335- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO CB01-DATA (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.CB01.CB01_DATA, 1, 2);

            /*" -337- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO CB01-DATA (4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.CB01.CB01_DATA, 4, 2);

            /*" -339- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO CB01-DATA (7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.CB01.CB01_DATA, 7, 4);

            /*" -341- MOVE '/' TO CB01-DATA (3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CB01.CB01_DATA, 3, 1);

            /*" -342- MOVE '/' TO CB01-DATA (6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.CB01.CB01_DATA, 6, 1);

        }

        [StopWatch]
        /*" R0120-SISTEMAS-DB-SELECT-1 */
        public void R0120_SISTEMAS_DB_SELECT_1()
        {
            /*" -331- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' END-EXEC. */

            var r0120_SISTEMAS_DB_SELECT_1_Query1 = new R0120_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_SISTEMAS_DB_SELECT_1_Query1.Execute(r0120_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -357- MOVE 'R090' TO WNR-EXEC-SQL. */
            _.Move("R090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -419- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -421- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -419- EXEC SQL DECLARE PROPOSTA CURSOR FOR SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO , B.COD_CLIENTE , B.DATA_QUITACAO , B.COD_FONTE, A.COD_USUARIO FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B WHERE A.COD_RELATORIO = 'VA0469B' AND A.NUM_TITULO = 0 AND A.QUANTIDADE <> 0 AND A.MES_REFERENCIA <> 0 AND A.ANO_REFERENCIA <> 0 AND A.COD_PRODUTOR <> 0 AND A.ORGAO_EMISSOR >= 0 AND A.COD_USUARIO NOT IN ( 'VA0458B' , 'VA0601B' , 'VA0055B' , 'VA1601B' ) AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.SIT_REGISTRO = '3' AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO , B.COD_CLIENTE , B.DATA_QUITACAO , B.COD_FONTE, A.COD_USUARIO FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B WHERE A.COD_RELATORIO = 'VA0469B' AND A.NUM_TITULO = 0 AND A.QUANTIDADE = 0 AND A.MES_REFERENCIA = 0 AND A.ANO_REFERENCIA = 0 AND A.COD_PRODUTOR = 0 AND A.ORGAO_EMISSOR = 0 AND A.COD_USUARIO NOT IN ( 'VA0458B' , 'VA0601B' , 'VA0055B' , 'VA1601B' ) AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.SIT_REGISTRO = '3' AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 UNION SELECT B.NUM_APOLICE , B.COD_SUBGRUPO , B.NUM_CERTIFICADO , B.COD_CLIENTE , B.DATA_QUITACAO , B.COD_FONTE, A.COD_USUARIO FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B WHERE A.COD_RELATORIO = 'VA0469B' AND A.COD_CONGENERE = 1000 AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.SIT_REGISTRO = '3' WITH UR END-EXEC. */
            PROPOSTA = new VG0035B_PROPOSTA(false);
            string GetQuery_PROPOSTA()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.COD_CLIENTE
							, 
							B.DATA_QUITACAO
							, 
							B.COD_FONTE
							, 
							A.COD_USUARIO 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B 
							WHERE A.COD_RELATORIO = 'VA0469B' 
							AND A.NUM_TITULO = 0 
							AND A.QUANTIDADE <> 0 
							AND A.MES_REFERENCIA <> 0 
							AND A.ANO_REFERENCIA <> 0 
							AND A.COD_PRODUTOR <> 0 
							AND A.ORGAO_EMISSOR >= 0 
							AND A.COD_USUARIO NOT IN ( 'VA0458B'
							, 'VA0601B'
							, 
							'VA0055B'
							, 'VA1601B' ) 
							AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND B.SIT_REGISTRO = '3' 
							AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 
							UNION 
							SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.COD_CLIENTE
							, 
							B.DATA_QUITACAO
							, 
							B.COD_FONTE
							, 
							A.COD_USUARIO 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B 
							WHERE A.COD_RELATORIO = 'VA0469B' 
							AND A.NUM_TITULO = 0 
							AND A.QUANTIDADE = 0 
							AND A.MES_REFERENCIA = 0 
							AND A.ANO_REFERENCIA = 0 
							AND A.COD_PRODUTOR = 0 
							AND A.ORGAO_EMISSOR = 0 
							AND A.COD_USUARIO NOT IN ( 'VA0458B'
							, 'VA0601B'
							, 
							'VA0055B'
							, 'VA1601B' ) 
							AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND B.SIT_REGISTRO = '3' 
							AND B.COD_PRODUTO NOT BETWEEN 7700 AND 7799 
							UNION 
							SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.COD_CLIENTE
							, 
							B.DATA_QUITACAO
							, 
							B.COD_FONTE
							, 
							A.COD_USUARIO 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B 
							WHERE A.COD_RELATORIO = 'VA0469B' 
							AND A.COD_CONGENERE = 1000 
							AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO 
							AND B.SIT_REGISTRO = '3'";

                return query;
            }
            PROPOSTA.GetQueryEvent += GetQuery_PROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -421- EXEC SQL OPEN PROPOSTA END-EXEC. */

            PROPOSTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-SECTION */
        private void R0910_00_FETCH_CURSOR_SECTION()
        {
            /*" -436- MOVE 'R091' TO WNR-EXEC-SQL. */
            _.Move("R091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -446- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -449- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -450- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -451- MOVE 'S' TO WFIM-PROPOVA */
                    _.Move("S", AREA_DE_WORK.WFIM_PROPOVA);

                    /*" -451- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -453- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -454- ELSE */
                }
                else
                {


                    /*" -455- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -456- END-IF */
                }


                /*" -458- END-IF. */
            }


            /*" -458- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -446- EXEC SQL FETCH PROPOSTA INTO :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-CLIENTE, :PROPOVA-DATA-QUITACAO, :PROPOVA-COD-FONTE, :RELATORI-COD-USUARIO END-EXEC. */

            if (PROPOSTA.Fetch())
            {
                _.Move(PROPOSTA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(PROPOSTA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(PROPOSTA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(PROPOSTA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(PROPOSTA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(PROPOSTA.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(PROPOSTA.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -451- EXEC SQL CLOSE PROPOSTA END-EXEC */

            PROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -474- MOVE 'R100' TO WNR-EXEC-SQL. */
            _.Move("R100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -476- PERFORM R1200-00-SELECT-PRODUVG. */

            R1200_00_SELECT_PRODUVG_SECTION();

            /*" -477- IF WTEM-PRODUVG NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PRODUVG != "SIM")
            {

                /*" -478- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -480- END-IF. */
            }


            /*" -481- IF PRODUVG-ORIG-PRODU EQUAL 'GLOBAL' OR 'ESPEC' OR 'EMPRE' */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU.In("GLOBAL", "ESPEC", "EMPRE"))
            {

                /*" -482- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -484- END-IF. */
            }


            /*" -486- PERFORM R1300-00-SELECT-CLIENTES. */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -487- IF WTEM-CLIENTES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_CLIENTES != "SIM")
            {

                /*" -488- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -490- END-IF. */
            }


            /*" -492- PERFORM R1400-00-SELECT-HISCOBPR. */

            R1400_00_SELECT_HISCOBPR_SECTION();

            /*" -493- IF WTEM-HISCOBPR NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_HISCOBPR != "SIM")
            {

                /*" -494- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -496- END-IF. */
            }


            /*" -499- MOVE PRODUVG-COD-PRODUTO TO LD01-COD-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, AREA_DE_WORK.LD01.LD01_COD_PRODUTO);

            /*" -502- MOVE PRODUVG-NOME-PRODUTO TO LD01-NOM-PRODUTO. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, AREA_DE_WORK.LD01.LD01_NOM_PRODUTO);

            /*" -505- MOVE PROPOVA-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, AREA_DE_WORK.LD01.LD01_NUM_CERTIFICADO);

            /*" -508- MOVE CLIENTES-NOME-RAZAO TO LD01-NOM-CLIENTE. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOM_CLIENTE);

            /*" -511- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.LD01.LD01_CGCCPF);

            /*" -514- MOVE PROPOVA-DATA-QUITACAO(1:4) TO LD01-DTH-PROPOSTA(7:4). */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(1, 4), AREA_DE_WORK.LD01.LD01_DTH_PROPOSTA, 7, 4);

            /*" -517- MOVE '/' TO LD01-DTH-PROPOSTA(3:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.LD01.LD01_DTH_PROPOSTA, 3, 1);

            /*" -520- MOVE PROPOVA-DATA-QUITACAO(6:2) TO LD01-DTH-PROPOSTA(4:2). */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(6, 2), AREA_DE_WORK.LD01.LD01_DTH_PROPOSTA, 4, 2);

            /*" -523- MOVE '/' TO LD01-DTH-PROPOSTA(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.LD01.LD01_DTH_PROPOSTA, 6, 1);

            /*" -526- MOVE PROPOVA-DATA-QUITACAO(9:2) TO LD01-DTH-PROPOSTA(1:2). */
            _.MoveAtPosition(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.Substring(9, 2), AREA_DE_WORK.LD01.LD01_DTH_PROPOSTA, 1, 2);

            /*" -529- MOVE HISCOBPR-VLPREMIO TO LD01-VLR-PREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, AREA_DE_WORK.LD01.LD01_VLR_PREMIO);

            /*" -532- MOVE HISCOBPR-IMP-MORNATU TO LD01-VLR-IS. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, AREA_DE_WORK.LD01.LD01_VLR_IS);

            /*" -534- PERFORM R1500-00-SELECT-MOVIMVGA. */

            R1500_00_SELECT_MOVIMVGA_SECTION();

            /*" -535- IF WTEM-MOVIMVGA EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_MOVIMVGA == "SIM")
            {

                /*" -537- MOVE 'EXISTE MOVIMENTO PENDENTE    ' TO LD01-OBSERVACAO */
                _.Move("EXISTE MOVIMENTO PENDENTE    ", AREA_DE_WORK.LD01.LD01_OBSERVACAO);

                /*" -538- ELSE */
            }
            else
            {


                /*" -539- PERFORM R1600-00-SELECT-MOVIMVGA */

                R1600_00_SELECT_MOVIMVGA_SECTION();

                /*" -540- IF WTEM-MOVIMVGA NOT EQUAL 'SIM' */

                if (AREA_DE_WORK.WTEM_MOVIMVGA != "SIM")
                {

                    /*" -542- MOVE 'PROBLEMA NO ACESSO A MOVIMVGA    ' TO LD01-OBSERVACAO */
                    _.Move("PROBLEMA NO ACESSO A MOVIMVGA    ", AREA_DE_WORK.LD01.LD01_OBSERVACAO);

                    /*" -543- ELSE */
                }
                else
                {


                    /*" -544- PERFORM R1800-00-SELECT-FONTES */

                    R1800_00_SELECT_FONTES_SECTION();

                    /*" -545- PERFORM R1700-00-INSERT-MOVIMVGA */

                    R1700_00_INSERT_MOVIMVGA_SECTION();

                    /*" -547- MOVE 'CERTIFICADO CANCELADO COM SUCESSO' TO LD01-OBSERVACAO */
                    _.Move("CERTIFICADO CANCELADO COM SUCESSO", AREA_DE_WORK.LD01.LD01_OBSERVACAO);

                    /*" -548- END-IF */
                }


                /*" -550- END-IF. */
            }


            /*" -552- WRITE REG-DVG0035B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_DVG0035B);

            DVG0035B.Write(REG_DVG0035B.GetMoveValues().ToString());

            /*" -552- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -556- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-PRODUVG-SECTION */
        private void R1200_00_SELECT_PRODUVG_SECTION()
        {
            /*" -569- MOVE 'R120' TO WNR-EXEC-SQL. */
            _.Move("R120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -573- MOVE 'SIM' TO WTEM-PRODUVG. */
            _.Move("SIM", AREA_DE_WORK.WTEM_PRODUVG);

            /*" -575- INITIALIZE DCLPRODUTOS-VG. */
            _.Initialize(
                PRODUVG.DCLPRODUTOS_VG
            );

            /*" -589- PERFORM R1200_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1200_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -593- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -594- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -595- MOVE 'NAO' TO WTEM-PRODUVG */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PRODUVG);

                    /*" -596- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -597- ELSE */
                }
                else
                {


                    /*" -598- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -599- END-IF */
                }


                /*" -599- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1200_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -589- EXEC SQL SELECT COD_PRODUTO, NOME_PRODUTO, ORIG_PRODU INTO :PRODUVG-COD-PRODUTO, :PRODUVG-NOME-PRODUTO, :PRODUVG-ORIG-PRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(executed_1.PRODUVG_ORIG_PRODU, PRODUVG.DCLPRODUTOS_VG.PRODUVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-SECTION */
        private void R1300_00_SELECT_CLIENTES_SECTION()
        {
            /*" -612- MOVE 'R130' TO WNR-EXEC-SQL. */
            _.Move("R130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -616- MOVE 'SIM' TO WTEM-CLIENTES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -618- INITIALIZE DCLCLIENTES. */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -630- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -633- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -634- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -635- MOVE 'NAO' TO WTEM-CLIENTES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -636- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -637- ELSE */
                }
                else
                {


                    /*" -638- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -639- END-IF */
                }


                /*" -639- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -630- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE END-EXEC. */

            var r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-SECTION */
        private void R1400_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -652- MOVE 'R140' TO WNR-EXEC-SQL. */
            _.Move("R140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -656- MOVE 'SIM' TO WTEM-HISCOBPR. */
            _.Move("SIM", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -658- INITIALIZE DCLHIS-COBER-PROPOST. */
            _.Initialize(
                HISCOBPR.DCLHIS_COBER_PROPOST
            );

            /*" -671- PERFORM R1400_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1400_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -675- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -676- MOVE 'NAO' TO WTEM-HISCOBPR */
                    _.Move("NAO", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -677- GO TO R1400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/ //GOTO
                    return;

                    /*" -678- ELSE */
                }
                else
                {


                    /*" -679- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -680- END-IF */
                }


                /*" -680- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1400_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -671- EXEC SQL SELECT VLPREMIO, IMP_MORNATU INTO :HISCOBPR-VLPREMIO, :HISCOBPR-IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-MOVIMVGA-SECTION */
        private void R1500_00_SELECT_MOVIMVGA_SECTION()
        {
            /*" -693- MOVE 'R150' TO WNR-EXEC-SQL. */
            _.Move("R150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -698- MOVE 'SIM' TO WTEM-MOVIMVGA. */
            _.Move("SIM", AREA_DE_WORK.WTEM_MOVIMVGA);

            /*" -858- PERFORM R1500_00_SELECT_MOVIMVGA_DB_SELECT_1 */

            R1500_00_SELECT_MOVIMVGA_DB_SELECT_1();

            /*" -861- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -862- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -863- MOVE 'NAO' TO WTEM-MOVIMVGA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_MOVIMVGA);

                    /*" -864- GO TO R1500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                    return;

                    /*" -865- ELSE */
                }
                else
                {


                    /*" -866- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -867- END-IF */
                }


                /*" -867- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-MOVIMVGA-DB-SELECT-1 */
        public void R1500_00_SELECT_MOVIMVGA_DB_SELECT_1()
        {
            /*" -858- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO INTO :MOVIMVGA-NUM-APOLICE , :MOVIMVGA-COD-SUBGRUPO , :MOVIMVGA-COD-FONTE , :MOVIMVGA-NUM-PROPOSTA , :MOVIMVGA-TIPO-SEGURADO , :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-DAC-CERTIFICADO , :MOVIMVGA-TIPO-INCLUSAO , :MOVIMVGA-COD-CLIENTE , :MOVIMVGA-COD-AGENCIADOR , :MOVIMVGA-COD-CORRETOR , :MOVIMVGA-COD-PLANOVGAP , :MOVIMVGA-COD-PLANOAP , :MOVIMVGA-FAIXA , :MOVIMVGA-AUTOR-AUM-AUTOMAT, :MOVIMVGA-TIPO-BENEFICIARIO, :MOVIMVGA-PERI-PAGAMENTO , :MOVIMVGA-PERI-RENOVACAO , :MOVIMVGA-COD-OCUPACAO , :MOVIMVGA-ESTADO-CIVIL , :MOVIMVGA-IDE-SEXO , :MOVIMVGA-COD-PROFISSAO , :MOVIMVGA-NATURALIDADE , :MOVIMVGA-OCORR-ENDERECO , :MOVIMVGA-OCORR-END-COBRAN , :MOVIMVGA-BCO-COBRANCA , :MOVIMVGA-AGE-COBRANCA , :MOVIMVGA-DAC-COBRANCA , :MOVIMVGA-NUM-MATRICULA , :MOVIMVGA-NUM-CTA-CORRENTE , :MOVIMVGA-DAC-CTA-CORRENTE , :MOVIMVGA-VAL-SALARIO , :MOVIMVGA-TIPO-SALARIO , :MOVIMVGA-TIPO-PLANO , :MOVIMVGA-PCT-CONJUGE-VG , :MOVIMVGA-PCT-CONJUGE-AP , :MOVIMVGA-QTD-SAL-MORNATU , :MOVIMVGA-QTD-SAL-MORACID , :MOVIMVGA-QTD-SAL-INVPERM , :MOVIMVGA-TAXA-AP-MORACID , :MOVIMVGA-TAXA-AP-INVPERM , :MOVIMVGA-TAXA-AP-AMDS , :MOVIMVGA-TAXA-AP-DH , :MOVIMVGA-TAXA-AP-DIT , :MOVIMVGA-TAXA-VG , :MOVIMVGA-IMP-MORNATU-ANT , :MOVIMVGA-IMP-MORNATU-ATU , :MOVIMVGA-IMP-MORACID-ANT , :MOVIMVGA-IMP-MORACID-ATU , :MOVIMVGA-IMP-INVPERM-ANT , :MOVIMVGA-IMP-INVPERM-ATU , :MOVIMVGA-IMP-AMDS-ANT , :MOVIMVGA-IMP-AMDS-ATU , :MOVIMVGA-IMP-DH-ANT , :MOVIMVGA-IMP-DH-ATU , :MOVIMVGA-IMP-DIT-ANT , :MOVIMVGA-IMP-DIT-ATU , :MOVIMVGA-PRM-VG-ANT , :MOVIMVGA-PRM-VG-ATU , :MOVIMVGA-PRM-AP-ANT , :MOVIMVGA-PRM-AP-ATU , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-DATA-OPERACAO , :MOVIMVGA-COD-SUBGRUPO-TRANS, :MOVIMVGA-SIT-REGISTRO , :MOVIMVGA-COD-USUARIO , :MOVIMVGA-DATA-AVERBACAO :VIND-DATA-AVERBACAO, :MOVIMVGA-DATA-ADMISSAO :VIND-DATA-ADMISSAO, :MOVIMVGA-DATA-INCLUSAO :VIND-DATA-INCLUSAO, :MOVIMVGA-DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, :MOVIMVGA-DATA-FATURA :VIND-DATA-FATURA, :MOVIMVGA-DATA-REFERENCIA :VIND-DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO :VIND-DATA-MOVIMENTO, :MOVIMVGA-COD-EMPRESA :VIND-COD-EMPRESA, :MOVIMVGA-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEGURA FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INCLUSAO IS NULL ORDER BY DATA_INCLUSAO DESC FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1 = new R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);
                _.Move(executed_1.MOVIMVGA_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);
                _.Move(executed_1.MOVIMVGA_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);
                _.Move(executed_1.MOVIMVGA_NUM_PROPOSTA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);
                _.Move(executed_1.MOVIMVGA_TIPO_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);
                _.Move(executed_1.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_DAC_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_TIPO_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);
                _.Move(executed_1.MOVIMVGA_COD_CLIENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);
                _.Move(executed_1.MOVIMVGA_COD_AGENCIADOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);
                _.Move(executed_1.MOVIMVGA_COD_CORRETOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);
                _.Move(executed_1.MOVIMVGA_COD_PLANOVGAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);
                _.Move(executed_1.MOVIMVGA_COD_PLANOAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);
                _.Move(executed_1.MOVIMVGA_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);
                _.Move(executed_1.MOVIMVGA_AUTOR_AUM_AUTOMAT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);
                _.Move(executed_1.MOVIMVGA_TIPO_BENEFICIARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);
                _.Move(executed_1.MOVIMVGA_PERI_PAGAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);
                _.Move(executed_1.MOVIMVGA_PERI_RENOVACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);
                _.Move(executed_1.MOVIMVGA_COD_OCUPACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);
                _.Move(executed_1.MOVIMVGA_ESTADO_CIVIL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);
                _.Move(executed_1.MOVIMVGA_IDE_SEXO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);
                _.Move(executed_1.MOVIMVGA_COD_PROFISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);
                _.Move(executed_1.MOVIMVGA_NATURALIDADE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);
                _.Move(executed_1.MOVIMVGA_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);
                _.Move(executed_1.MOVIMVGA_OCORR_END_COBRAN, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);
                _.Move(executed_1.MOVIMVGA_BCO_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);
                _.Move(executed_1.MOVIMVGA_AGE_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);
                _.Move(executed_1.MOVIMVGA_DAC_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);
                _.Move(executed_1.MOVIMVGA_NUM_MATRICULA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);
                _.Move(executed_1.MOVIMVGA_NUM_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);
                _.Move(executed_1.MOVIMVGA_DAC_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);
                _.Move(executed_1.MOVIMVGA_VAL_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);
                _.Move(executed_1.MOVIMVGA_TIPO_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);
                _.Move(executed_1.MOVIMVGA_TIPO_PLANO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);
                _.Move(executed_1.MOVIMVGA_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);
                _.Move(executed_1.MOVIMVGA_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);
                _.Move(executed_1.MOVIMVGA_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);
                _.Move(executed_1.MOVIMVGA_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);
                _.Move(executed_1.MOVIMVGA_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);
                _.Move(executed_1.MOVIMVGA_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);
                _.Move(executed_1.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_MORNATU_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_MORACID_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_INVPERM_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_AMDS_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_DIT_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);
                _.Move(executed_1.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);
                _.Move(executed_1.MOVIMVGA_PRM_VG_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);
                _.Move(executed_1.MOVIMVGA_PRM_AP_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);
                _.Move(executed_1.MOVIMVGA_PRM_AP_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(executed_1.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
                _.Move(executed_1.MOVIMVGA_COD_SUBGRUPO_TRANS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);
                _.Move(executed_1.MOVIMVGA_SIT_REGISTRO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);
                _.Move(executed_1.MOVIMVGA_COD_USUARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);
                _.Move(executed_1.MOVIMVGA_DATA_AVERBACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);
                _.Move(executed_1.VIND_DATA_AVERBACAO, VIND_DATA_AVERBACAO);
                _.Move(executed_1.MOVIMVGA_DATA_ADMISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);
                _.Move(executed_1.VIND_DATA_ADMISSAO, VIND_DATA_ADMISSAO);
                _.Move(executed_1.MOVIMVGA_DATA_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);
                _.Move(executed_1.VIND_DATA_INCLUSAO, VIND_DATA_INCLUSAO);
                _.Move(executed_1.MOVIMVGA_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DATA_NASCIMENTO, VIND_DATA_NASCIMENTO);
                _.Move(executed_1.MOVIMVGA_DATA_FATURA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA);
                _.Move(executed_1.VIND_DATA_FATURA, VIND_DATA_FATURA);
                _.Move(executed_1.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);
                _.Move(executed_1.VIND_DATA_REFERENCIA, VIND_DATA_REFERENCIA);
                _.Move(executed_1.MOVIMVGA_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);
                _.Move(executed_1.VIND_DATA_MOVIMENTO, VIND_DATA_MOVIMENTO);
                _.Move(executed_1.MOVIMVGA_COD_EMPRESA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA);
                _.Move(executed_1.VIND_COD_EMPRESA, VIND_COD_EMPRESA);
                _.Move(executed_1.MOVIMVGA_LOT_EMP_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);
                _.Move(executed_1.VIND_LOT_EMP_SEGURA, VIND_LOT_EMP_SEGURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-MOVIMVGA-SECTION */
        private void R1600_00_SELECT_MOVIMVGA_SECTION()
        {
            /*" -880- MOVE 'R160' TO WNR-EXEC-SQL. */
            _.Move("R160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -885- MOVE 'SIM' TO WTEM-MOVIMVGA. */
            _.Move("SIM", AREA_DE_WORK.WTEM_MOVIMVGA);

            /*" -1045- PERFORM R1600_00_SELECT_MOVIMVGA_DB_SELECT_1 */

            R1600_00_SELECT_MOVIMVGA_DB_SELECT_1();

            /*" -1048- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1049- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1050- MOVE 'NAO' TO WTEM-MOVIMVGA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_MOVIMVGA);

                    /*" -1051- GO TO R1600-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/ //GOTO
                    return;

                    /*" -1052- ELSE */
                }
                else
                {


                    /*" -1053- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1054- END-IF */
                }


                /*" -1054- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-MOVIMVGA-DB-SELECT-1 */
        public void R1600_00_SELECT_MOVIMVGA_DB_SELECT_1()
        {
            /*" -1045- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO INTO :MOVIMVGA-NUM-APOLICE , :MOVIMVGA-COD-SUBGRUPO , :MOVIMVGA-COD-FONTE , :MOVIMVGA-NUM-PROPOSTA , :MOVIMVGA-TIPO-SEGURADO , :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-DAC-CERTIFICADO , :MOVIMVGA-TIPO-INCLUSAO , :MOVIMVGA-COD-CLIENTE , :MOVIMVGA-COD-AGENCIADOR , :MOVIMVGA-COD-CORRETOR , :MOVIMVGA-COD-PLANOVGAP , :MOVIMVGA-COD-PLANOAP , :MOVIMVGA-FAIXA , :MOVIMVGA-AUTOR-AUM-AUTOMAT, :MOVIMVGA-TIPO-BENEFICIARIO, :MOVIMVGA-PERI-PAGAMENTO , :MOVIMVGA-PERI-RENOVACAO , :MOVIMVGA-COD-OCUPACAO , :MOVIMVGA-ESTADO-CIVIL , :MOVIMVGA-IDE-SEXO , :MOVIMVGA-COD-PROFISSAO , :MOVIMVGA-NATURALIDADE , :MOVIMVGA-OCORR-ENDERECO , :MOVIMVGA-OCORR-END-COBRAN , :MOVIMVGA-BCO-COBRANCA , :MOVIMVGA-AGE-COBRANCA , :MOVIMVGA-DAC-COBRANCA , :MOVIMVGA-NUM-MATRICULA , :MOVIMVGA-NUM-CTA-CORRENTE , :MOVIMVGA-DAC-CTA-CORRENTE , :MOVIMVGA-VAL-SALARIO , :MOVIMVGA-TIPO-SALARIO , :MOVIMVGA-TIPO-PLANO , :MOVIMVGA-PCT-CONJUGE-VG , :MOVIMVGA-PCT-CONJUGE-AP , :MOVIMVGA-QTD-SAL-MORNATU , :MOVIMVGA-QTD-SAL-MORACID , :MOVIMVGA-QTD-SAL-INVPERM , :MOVIMVGA-TAXA-AP-MORACID , :MOVIMVGA-TAXA-AP-INVPERM , :MOVIMVGA-TAXA-AP-AMDS , :MOVIMVGA-TAXA-AP-DH , :MOVIMVGA-TAXA-AP-DIT , :MOVIMVGA-TAXA-VG , :MOVIMVGA-IMP-MORNATU-ANT , :MOVIMVGA-IMP-MORNATU-ATU , :MOVIMVGA-IMP-MORACID-ANT , :MOVIMVGA-IMP-MORACID-ATU , :MOVIMVGA-IMP-INVPERM-ANT , :MOVIMVGA-IMP-INVPERM-ATU , :MOVIMVGA-IMP-AMDS-ANT , :MOVIMVGA-IMP-AMDS-ATU , :MOVIMVGA-IMP-DH-ANT , :MOVIMVGA-IMP-DH-ATU , :MOVIMVGA-IMP-DIT-ANT , :MOVIMVGA-IMP-DIT-ATU , :MOVIMVGA-PRM-VG-ANT , :MOVIMVGA-PRM-VG-ATU , :MOVIMVGA-PRM-AP-ANT , :MOVIMVGA-PRM-AP-ATU , :MOVIMVGA-COD-OPERACAO , :MOVIMVGA-DATA-OPERACAO , :MOVIMVGA-COD-SUBGRUPO-TRANS, :MOVIMVGA-SIT-REGISTRO , :MOVIMVGA-COD-USUARIO , :MOVIMVGA-DATA-AVERBACAO :VIND-DATA-AVERBACAO, :MOVIMVGA-DATA-ADMISSAO :VIND-DATA-ADMISSAO, :MOVIMVGA-DATA-INCLUSAO :VIND-DATA-INCLUSAO, :MOVIMVGA-DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, :MOVIMVGA-DATA-FATURA :VIND-DATA-FATURA, :MOVIMVGA-DATA-REFERENCIA :VIND-DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO :VIND-DATA-MOVIMENTO, :MOVIMVGA-COD-EMPRESA :VIND-COD-EMPRESA, :MOVIMVGA-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEGURA FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INCLUSAO IS NOT NULL ORDER BY DATA_INCLUSAO DESC FETCH FIRST 1 ROW ONLY END-EXEC. */

            var r1600_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1 = new R1600_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_MOVIMVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);
                _.Move(executed_1.MOVIMVGA_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);
                _.Move(executed_1.MOVIMVGA_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);
                _.Move(executed_1.MOVIMVGA_NUM_PROPOSTA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);
                _.Move(executed_1.MOVIMVGA_TIPO_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);
                _.Move(executed_1.MOVIMVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_DAC_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);
                _.Move(executed_1.MOVIMVGA_TIPO_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);
                _.Move(executed_1.MOVIMVGA_COD_CLIENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);
                _.Move(executed_1.MOVIMVGA_COD_AGENCIADOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);
                _.Move(executed_1.MOVIMVGA_COD_CORRETOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);
                _.Move(executed_1.MOVIMVGA_COD_PLANOVGAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);
                _.Move(executed_1.MOVIMVGA_COD_PLANOAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);
                _.Move(executed_1.MOVIMVGA_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);
                _.Move(executed_1.MOVIMVGA_AUTOR_AUM_AUTOMAT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);
                _.Move(executed_1.MOVIMVGA_TIPO_BENEFICIARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);
                _.Move(executed_1.MOVIMVGA_PERI_PAGAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);
                _.Move(executed_1.MOVIMVGA_PERI_RENOVACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);
                _.Move(executed_1.MOVIMVGA_COD_OCUPACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);
                _.Move(executed_1.MOVIMVGA_ESTADO_CIVIL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);
                _.Move(executed_1.MOVIMVGA_IDE_SEXO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);
                _.Move(executed_1.MOVIMVGA_COD_PROFISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);
                _.Move(executed_1.MOVIMVGA_NATURALIDADE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);
                _.Move(executed_1.MOVIMVGA_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);
                _.Move(executed_1.MOVIMVGA_OCORR_END_COBRAN, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);
                _.Move(executed_1.MOVIMVGA_BCO_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);
                _.Move(executed_1.MOVIMVGA_AGE_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);
                _.Move(executed_1.MOVIMVGA_DAC_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);
                _.Move(executed_1.MOVIMVGA_NUM_MATRICULA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);
                _.Move(executed_1.MOVIMVGA_NUM_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);
                _.Move(executed_1.MOVIMVGA_DAC_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);
                _.Move(executed_1.MOVIMVGA_VAL_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);
                _.Move(executed_1.MOVIMVGA_TIPO_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);
                _.Move(executed_1.MOVIMVGA_TIPO_PLANO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);
                _.Move(executed_1.MOVIMVGA_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);
                _.Move(executed_1.MOVIMVGA_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);
                _.Move(executed_1.MOVIMVGA_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);
                _.Move(executed_1.MOVIMVGA_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);
                _.Move(executed_1.MOVIMVGA_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);
                _.Move(executed_1.MOVIMVGA_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);
                _.Move(executed_1.MOVIMVGA_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);
                _.Move(executed_1.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_MORNATU_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_MORACID_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_INVPERM_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_AMDS_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_DH_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);
                _.Move(executed_1.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);
                _.Move(executed_1.MOVIMVGA_IMP_DIT_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);
                _.Move(executed_1.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);
                _.Move(executed_1.MOVIMVGA_PRM_VG_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);
                _.Move(executed_1.MOVIMVGA_PRM_AP_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);
                _.Move(executed_1.MOVIMVGA_PRM_AP_ATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
                _.Move(executed_1.MOVIMVGA_DATA_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);
                _.Move(executed_1.MOVIMVGA_COD_SUBGRUPO_TRANS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);
                _.Move(executed_1.MOVIMVGA_SIT_REGISTRO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);
                _.Move(executed_1.MOVIMVGA_COD_USUARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);
                _.Move(executed_1.MOVIMVGA_DATA_AVERBACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);
                _.Move(executed_1.VIND_DATA_AVERBACAO, VIND_DATA_AVERBACAO);
                _.Move(executed_1.MOVIMVGA_DATA_ADMISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);
                _.Move(executed_1.VIND_DATA_ADMISSAO, VIND_DATA_ADMISSAO);
                _.Move(executed_1.MOVIMVGA_DATA_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);
                _.Move(executed_1.VIND_DATA_INCLUSAO, VIND_DATA_INCLUSAO);
                _.Move(executed_1.MOVIMVGA_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DATA_NASCIMENTO, VIND_DATA_NASCIMENTO);
                _.Move(executed_1.MOVIMVGA_DATA_FATURA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA);
                _.Move(executed_1.VIND_DATA_FATURA, VIND_DATA_FATURA);
                _.Move(executed_1.MOVIMVGA_DATA_REFERENCIA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);
                _.Move(executed_1.VIND_DATA_REFERENCIA, VIND_DATA_REFERENCIA);
                _.Move(executed_1.MOVIMVGA_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);
                _.Move(executed_1.VIND_DATA_MOVIMENTO, VIND_DATA_MOVIMENTO);
                _.Move(executed_1.MOVIMVGA_COD_EMPRESA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA);
                _.Move(executed_1.VIND_COD_EMPRESA, VIND_COD_EMPRESA);
                _.Move(executed_1.MOVIMVGA_LOT_EMP_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);
                _.Move(executed_1.VIND_LOT_EMP_SEGURA, VIND_LOT_EMP_SEGURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-INSERT-MOVIMVGA-SECTION */
        private void R1700_00_INSERT_MOVIMVGA_SECTION()
        {
            /*" -1067- MOVE 'R170' TO WNR-EXEC-SQL. */
            _.Move("R170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1072- MOVE 'SIM' TO WTEM-MOVIMVGA. */
            _.Move("SIM", AREA_DE_WORK.WTEM_MOVIMVGA);

            /*" -1229- PERFORM R1700_00_INSERT_MOVIMVGA_DB_INSERT_1 */

            R1700_00_INSERT_MOVIMVGA_DB_INSERT_1();

            /*" -1232- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1233- IF SQLCODE = -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1234- PERFORM R1800-00-SELECT-FONTES */

                    R1800_00_SELECT_FONTES_SECTION();

                    /*" -1235- GO TO R1700-00-INSERT-MOVIMVGA */
                    new Task(() => R1700_00_INSERT_MOVIMVGA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1236- ELSE */
                }
                else
                {


                    /*" -1237- DISPLAY 'PROBLEMAS NO INSERT DA MOVIMVGA' */
                    _.Display($"PROBLEMAS NO INSERT DA MOVIMVGA");

                    /*" -1238- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1240- END-IF. */
                }

            }


            /*" -1240- ADD 1 TO AC-CANCELADOS. */
            AREA_DE_WORK.AC_CANCELADOS.Value = AREA_DE_WORK.AC_CANCELADOS + 1;

        }

        [StopWatch]
        /*" R1700-00-INSERT-MOVIMVGA-DB-INSERT-1 */
        public void R1700_00_INSERT_MOVIMVGA_DB_INSERT_1()
        {
            /*" -1229- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO ) VALUES ( :MOVIMVGA-NUM-APOLICE , :MOVIMVGA-COD-SUBGRUPO , :MOVIMVGA-COD-FONTE , :FONTES-ULT-PROP-AUTOMAT , :MOVIMVGA-TIPO-SEGURADO , :MOVIMVGA-NUM-CERTIFICADO , :MOVIMVGA-DAC-CERTIFICADO , :MOVIMVGA-TIPO-INCLUSAO , :MOVIMVGA-COD-CLIENTE , :MOVIMVGA-COD-AGENCIADOR , :MOVIMVGA-COD-CORRETOR , :MOVIMVGA-COD-PLANOVGAP , :MOVIMVGA-COD-PLANOAP , :MOVIMVGA-FAIXA , :MOVIMVGA-AUTOR-AUM-AUTOMAT, :MOVIMVGA-TIPO-BENEFICIARIO, :MOVIMVGA-PERI-PAGAMENTO , :MOVIMVGA-PERI-RENOVACAO , :MOVIMVGA-COD-OCUPACAO , :MOVIMVGA-ESTADO-CIVIL , :MOVIMVGA-IDE-SEXO , :MOVIMVGA-COD-PROFISSAO , :MOVIMVGA-NATURALIDADE , :MOVIMVGA-OCORR-ENDERECO , :MOVIMVGA-OCORR-END-COBRAN , :MOVIMVGA-BCO-COBRANCA , :MOVIMVGA-AGE-COBRANCA , :MOVIMVGA-DAC-COBRANCA , :MOVIMVGA-NUM-MATRICULA , :MOVIMVGA-NUM-CTA-CORRENTE , :MOVIMVGA-DAC-CTA-CORRENTE , :MOVIMVGA-VAL-SALARIO , :MOVIMVGA-TIPO-SALARIO , :MOVIMVGA-TIPO-PLANO , :MOVIMVGA-PCT-CONJUGE-VG , :MOVIMVGA-PCT-CONJUGE-AP , :MOVIMVGA-QTD-SAL-MORNATU , :MOVIMVGA-QTD-SAL-MORACID , :MOVIMVGA-QTD-SAL-INVPERM , :MOVIMVGA-TAXA-AP-MORACID , :MOVIMVGA-TAXA-AP-INVPERM , :MOVIMVGA-TAXA-AP-AMDS , :MOVIMVGA-TAXA-AP-DH , :MOVIMVGA-TAXA-AP-DIT , :MOVIMVGA-TAXA-VG , :MOVIMVGA-IMP-MORNATU-ANT , :MOVIMVGA-IMP-MORNATU-ATU , :MOVIMVGA-IMP-MORACID-ANT , :MOVIMVGA-IMP-MORACID-ATU , :MOVIMVGA-IMP-INVPERM-ANT , :MOVIMVGA-IMP-INVPERM-ATU , :MOVIMVGA-IMP-AMDS-ANT , :MOVIMVGA-IMP-AMDS-ATU , :MOVIMVGA-IMP-DH-ANT , :MOVIMVGA-IMP-DH-ATU , :MOVIMVGA-IMP-DIT-ANT , :MOVIMVGA-IMP-DIT-ATU , :MOVIMVGA-PRM-VG-ANT , :MOVIMVGA-PRM-VG-ATU , :MOVIMVGA-PRM-AP-ANT , :MOVIMVGA-PRM-AP-ATU , 401 , :SISTEMAS-DATA-MOV-ABERTO , :MOVIMVGA-COD-SUBGRUPO-TRANS, :MOVIMVGA-SIT-REGISTRO , :RELATORI-COD-USUARIO , :SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-AVERBACAO, :MOVIMVGA-DATA-ADMISSAO :VIND-DATA-ADMISSAO, NULL , :MOVIMVGA-DATA-NASCIMENTO :VIND-DATA-NASCIMENTO, :SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-FATURA, :SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-REFERENCIA, :SISTEMAS-DATA-MOV-ABERTO :VIND-DATA-MOVIMENTO, :MOVIMVGA-COD-EMPRESA :VIND-COD-EMPRESA, :MOVIMVGA-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEGURA ) END-EXEC. */

            var r1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1 = new R1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1()
            {
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
                MOVIMVGA_COD_SUBGRUPO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.ToString(),
                MOVIMVGA_COD_FONTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                MOVIMVGA_TIPO_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO.ToString(),
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
                MOVIMVGA_DAC_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO.ToString(),
                MOVIMVGA_TIPO_INCLUSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO.ToString(),
                MOVIMVGA_COD_CLIENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE.ToString(),
                MOVIMVGA_COD_AGENCIADOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_COD_CORRETOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR.ToString(),
                MOVIMVGA_COD_PLANOVGAP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP.ToString(),
                MOVIMVGA_COD_PLANOAP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP.ToString(),
                MOVIMVGA_FAIXA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA.ToString(),
                MOVIMVGA_AUTOR_AUM_AUTOMAT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT.ToString(),
                MOVIMVGA_TIPO_BENEFICIARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO.ToString(),
                MOVIMVGA_PERI_PAGAMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO.ToString(),
                MOVIMVGA_PERI_RENOVACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO.ToString(),
                MOVIMVGA_COD_OCUPACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO.ToString(),
                MOVIMVGA_ESTADO_CIVIL = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL.ToString(),
                MOVIMVGA_IDE_SEXO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO.ToString(),
                MOVIMVGA_COD_PROFISSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO.ToString(),
                MOVIMVGA_NATURALIDADE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE.ToString(),
                MOVIMVGA_OCORR_ENDERECO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO.ToString(),
                MOVIMVGA_OCORR_END_COBRAN = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN.ToString(),
                MOVIMVGA_BCO_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA.ToString(),
                MOVIMVGA_AGE_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA.ToString(),
                MOVIMVGA_DAC_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA.ToString(),
                MOVIMVGA_NUM_MATRICULA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA.ToString(),
                MOVIMVGA_NUM_CTA_CORRENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE.ToString(),
                MOVIMVGA_DAC_CTA_CORRENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE.ToString(),
                MOVIMVGA_VAL_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO.ToString(),
                MOVIMVGA_TIPO_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO.ToString(),
                MOVIMVGA_TIPO_PLANO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO.ToString(),
                MOVIMVGA_PCT_CONJUGE_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG.ToString(),
                MOVIMVGA_PCT_CONJUGE_AP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP.ToString(),
                MOVIMVGA_QTD_SAL_MORNATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU.ToString(),
                MOVIMVGA_QTD_SAL_MORACID = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID.ToString(),
                MOVIMVGA_QTD_SAL_INVPERM = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM.ToString(),
                MOVIMVGA_TAXA_AP_MORACID = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID.ToString(),
                MOVIMVGA_TAXA_AP_INVPERM = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM.ToString(),
                MOVIMVGA_TAXA_AP_AMDS = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS.ToString(),
                MOVIMVGA_TAXA_AP_DH = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH.ToString(),
                MOVIMVGA_TAXA_AP_DIT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT.ToString(),
                MOVIMVGA_TAXA_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG.ToString(),
                MOVIMVGA_IMP_MORNATU_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT.ToString(),
                MOVIMVGA_IMP_MORNATU_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.ToString(),
                MOVIMVGA_IMP_MORACID_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT.ToString(),
                MOVIMVGA_IMP_MORACID_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.ToString(),
                MOVIMVGA_IMP_INVPERM_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT.ToString(),
                MOVIMVGA_IMP_INVPERM_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.ToString(),
                MOVIMVGA_IMP_AMDS_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT.ToString(),
                MOVIMVGA_IMP_AMDS_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU.ToString(),
                MOVIMVGA_IMP_DH_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT.ToString(),
                MOVIMVGA_IMP_DH_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU.ToString(),
                MOVIMVGA_IMP_DIT_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT.ToString(),
                MOVIMVGA_IMP_DIT_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU.ToString(),
                MOVIMVGA_PRM_VG_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT.ToString(),
                MOVIMVGA_PRM_VG_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.ToString(),
                MOVIMVGA_PRM_AP_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT.ToString(),
                MOVIMVGA_PRM_AP_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVIMVGA_COD_SUBGRUPO_TRANS = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS.ToString(),
                MOVIMVGA_SIT_REGISTRO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                VIND_DATA_AVERBACAO = VIND_DATA_AVERBACAO.ToString(),
                MOVIMVGA_DATA_ADMISSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO.ToString(),
                VIND_DATA_ADMISSAO = VIND_DATA_ADMISSAO.ToString(),
                MOVIMVGA_DATA_NASCIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.ToString(),
                VIND_DATA_NASCIMENTO = VIND_DATA_NASCIMENTO.ToString(),
                VIND_DATA_FATURA = VIND_DATA_FATURA.ToString(),
                VIND_DATA_REFERENCIA = VIND_DATA_REFERENCIA.ToString(),
                VIND_DATA_MOVIMENTO = VIND_DATA_MOVIMENTO.ToString(),
                MOVIMVGA_COD_EMPRESA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                MOVIMVGA_LOT_EMP_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO.ToString(),
                VIND_LOT_EMP_SEGURA = VIND_LOT_EMP_SEGURA.ToString(),
            };

            R1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1.Execute(r1700_00_INSERT_MOVIMVGA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-FONTES-SECTION */
        private void R1800_00_SELECT_FONTES_SECTION()
        {
            /*" -1253- MOVE 'R180' TO WNR-EXEC-SQL. */
            _.Move("R180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1257- PERFORM R1800_00_SELECT_FONTES_DB_UPDATE_1 */

            R1800_00_SELECT_FONTES_DB_UPDATE_1();

            /*" -1260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1264- MOVE 'R181' TO WNR-EXEC-SQL. */
            _.Move("R181", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1270- PERFORM R1800_00_SELECT_FONTES_DB_SELECT_1 */

            R1800_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1273- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1274- DISPLAY 'PROBLEMAS NO SELECT FONTE      ' */
                _.Display($"PROBLEMAS NO SELECT FONTE      ");

                /*" -1275- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1275- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-FONTES-DB-UPDATE-1 */
        public void R1800_00_SELECT_FONTES_DB_UPDATE_1()
        {
            /*" -1257- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = ULT_PROP_AUTOMAT + 1 WHERE COD_FONTE = :PROPOVA-COD-FONTE END-EXEC. */

            var r1800_00_SELECT_FONTES_DB_UPDATE_1_Update1 = new R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1()
            {
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
            };

            R1800_00_SELECT_FONTES_DB_UPDATE_1_Update1.Execute(r1800_00_SELECT_FONTES_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1800-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1800_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1270- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :PROPOVA-COD-FONTE WITH UR END-EXEC. */

            var r1800_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R1800_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_FONTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE.ToString(),
            };

            var executed_1 = R1800_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1291- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1293- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1293- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1295- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1299- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1299- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}