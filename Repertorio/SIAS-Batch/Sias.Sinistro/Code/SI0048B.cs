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
using Sias.Sinistro.DB2.SI0048B;

namespace Code
{
    public class SI0048B
    {
        public bool IsCall { get; set; }

        public SI0048B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   SUBROTINA............... SI0048B                             *      */
        /*"      *   ANALISTA ............... AMARALINE                           *      */
        /*"      *   PROGRAMADOR ............ AMARALINE                           *      */
        /*"      *   DATA CODIFICACAO ....... DEZ / 2008                          *      */
        /*"      *   FUNCAO ................. RELATORIO DE SINISTROS PENDENTES -  *      */
        /*"      *                            RESERVA TECNICA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 22/12/08 - Amaraline - Cad.18369                               *      */
        /*"      *            Criar relat�rio di�rio para disponibilizar as       *      */
        /*"      *            informa��es da reserva tecnica.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16/10/2010 - CAD 47494/2010 - CIRCULAR 395:           *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/10/2010 - MARCELO NEVES (TE41729)   PROCURAR: C395     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        public FileBasis _SI0048B1 { get; set; } = new FileBasis(new PIC("X", "215", "X(215)"));

        public FileBasis SI0048B1
        {
            get
            {
                _.Move(REG_SI0048B1, _SI0048B1); VarBasis.RedefinePassValue(REG_SI0048B1, _SI0048B1, REG_SI0048B1); return _SI0048B1;
            }
        }
        /*"01          REG-SI0048B1         PIC  X(215).*/
        public StringBasis REG_SI0048B1 { get; set; } = new StringBasis(new PIC("X", "215", "X(215)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01        HOST-DATA-AVISO      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis HOST_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        WS-CURRENT-DATE      PIC  X(010)   VALUE   SPACES.*/
        public StringBasis WS_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01        WS-COD-USUARIO-ANT   PIC  X(008)   VALUE   SPACES.*/
        public StringBasis WS_COD_USUARIO_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01        WS-QTDE-DIAS-PENDENTE PIC S9(009) COMP VALUE ZEROS.*/
        public IntBasis WS_QTDE_DIAS_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01        WS-VALOR-PENDENTE    PIC S9(013)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis WS_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01        WS-VALOR-AVISADO     PIC S9(013)V99 COMP-3 VALUE ZEROS*/
        public DoubleBasis WS_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01        AREA-DE-WORK.*/
        public SI0048B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0048B_AREA_DE_WORK();
        public class SI0048B_AREA_DE_WORK : VarBasis
        {
            /*"  05      AC-L-LISTA           PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_L_LISTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      AC-I-SI0048B1        PIC  9(006)   VALUE   ZEROS.*/
            public IntBasis AC_I_SI0048B1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      WFIM-LISTA           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_LISTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-RELATORI        PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_RELATORI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WABEND.*/
            public SI0048B_WABEND WABEND { get; set; } = new SI0048B_WABEND();
            public class SI0048B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0048B'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0048B");
                /*"    10      FILLER               PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL         PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER               PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE             PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01       LC01.*/
            }
        }
        public SI0048B_LC01 LC01 { get; set; } = new SI0048B_LC01();
        public class SI0048B_LC01 : VarBasis
        {
            /*"  05     LC01-PRODUTO    PIC  X(007) VALUE 'Produto'.*/
            public StringBasis LC01_PRODUTO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"Produto");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-SINISTRO   PIC  X(008) VALUE 'Sinistro'.*/
            public StringBasis LC01_SINISTRO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"Sinistro");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-DT-AVISO   PIC  X(013) VALUE 'Data do Aviso'.*/
            public StringBasis LC01_DT_AVISO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"Data do Aviso");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-DT-COMUN   PIC  X(018) VALUE 'Data do Comunicado'.*/
            public StringBasis LC01_DT_COMUN { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"Data do Comunicado");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-DT-ATUAL   PIC  X(010) VALUE 'Data Atual'.*/
            public StringBasis LC01_DT_ATUAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"Data Atual");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-GR-CAUSA   PIC  X(011) VALUE 'Grupo Causa'.*/
            public StringBasis LC01_GR_CAUSA { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"Grupo Causa");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-CAUSA-SIN  PIC  X(017) VALUE 'Causa do Sinistro'.*/
            public StringBasis LC01_CAUSA_SIN { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"Causa do Sinistro");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-DESC-CAUSA PIC  X(018) VALUE 'Descri��o da Causa'.*/
            public StringBasis LC01_DESC_CAUSA { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"Descri��o da Causa");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-SEGURADO   PIC  X(008) VALUE 'Segurado'.*/
            public StringBasis LC01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"Segurado");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-NUM-CONTR  PIC  X(018) VALUE 'N�mero do Contrato'.*/
            public StringBasis LC01_NUM_CONTR { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"N�mero do Contrato");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-VL-AVISADO PIC  X(013) VALUE 'Valor Avisado'.*/
            public StringBasis LC01_VL_AVISADO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"Valor Avisado");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-VL-PENDENTE PIC X(014) VALUE 'Valor Pendente'.*/
            public StringBasis LC01_VL_PENDENTE { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"Valor Pendente");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-QTD-PENDENTES                PIC X(028) VALUE 'Quantidade de Dias Pendentes'.*/
            public StringBasis LC01_QTD_PENDENTES { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"Quantidade de Dias Pendentes");
            /*"  05     FILLER          PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          LD01.*/
        }
        public SI0048B_LD01 LD01 { get; set; } = new SI0048B_LD01();
        public class SI0048B_LD01 : VarBasis
        {
            /*"  05        LD01-PRODUTO         PIC  9(005) VALUE ZEROS.*/
            public IntBasis LD01_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-SINISTRO        PIC  9(013) VALUE ZEROS.*/
            public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-DT-AVISO        PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DT_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-DT-COMUNICADO   PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DT_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-DT-ATUAL        PIC  X(010) VALUE SPACES.*/
            public StringBasis LD01_DT_ATUAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-GR-CAUSA        PIC  X(020) VALUE SPACES.*/
            public StringBasis LD01_GR_CAUSA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-CAUSA-SIN       PIC  9(005) VALUE ZEROS.*/
            public IntBasis LD01_CAUSA_SIN { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-DESC-CAUSA      PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_DESC_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-SEGURADO        PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-NUM-CONTRATO    PIC  9(010) VALUE ZEROS.*/
            public IntBasis LD01_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-VL-AVISADO      PIC -99999999999,99 VALUE ZEROS*/
            public DoubleBasis LD01_VL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "11", "-99999999999V99"), 2);
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-VL-PENDENTE     PIC -99999999999,99 VALUE ZEROS*/
            public DoubleBasis LD01_VL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "11", "-99999999999V99"), 2);
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05        LD01-QTD-PENDENTES   PIC  9(009) VALUE ZEROS.*/
            public IntBasis LD01_QTD_PENDENTES { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        FILLER               PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINIPENH SINIPENH { get; set; } = new Dclgens.SINIPENH();
        public Dclgens.MOVSINIH MOVSINIH { get; set; } = new Dclgens.MOVSINIH();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public SI0048B_LISTA LISTA { get; set; } = new SI0048B_LISTA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0048B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0048B1.SetFile(SI0048B1_FILE_NAME_P);

                /*" -183- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -183- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -184- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -185- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -187- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -188- DISPLAY '*****  PROGRAMA SI0048B EM EXECUCAO *****' */
                _.Display($"*****  PROGRAMA SI0048B EM EXECUCAO *****");

                /*" -189- DISPLAY '*****  VERSAO: 16/10/2010 AS 14H55  *****' */
                _.Display($"*****  VERSAO: 16/10/2010 AS 14H55  *****");

                /*" -190- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -191- DISPLAY ' ' */
                _.Display($" ");

                /*" -192- DISPLAY '*****  RELATORIO DE ACOMPANHAMENTO *****' */
                _.Display($"*****  RELATORIO DE ACOMPANHAMENTO *****");

                /*" -193- DISPLAY '*******  DAS  RESERVAS TECNICAS  *******' */
                _.Display($"*******  DAS  RESERVAS TECNICAS  *******");

                /*" -195- DISPLAY ' ' */
                _.Display($" ");

                /*" -202- DISPLAY '*** INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

                $"*** INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
                .Display();

                /*" -202- DISPLAY ' ' . */
                _.Display($" ");

                /*" -202- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -210- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -212- OPEN OUTPUT SI0048B1 */
            SI0048B1.Open(REG_SI0048B1);

            /*" -214- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -216- PERFORM R0600-00-LE-RELATORIOS */

            R0600_00_LE_RELATORIOS_SECTION();

            /*" -217- IF WFIM-RELATORI EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -218- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -219- DISPLAY '* NAO HOUVE SOLICITACAO PARA O RELATORIO *' */
                _.Display($"* NAO HOUVE SOLICITACAO PARA O RELATORIO *");

                /*" -220- DISPLAY '******************************************' */
                _.Display($"******************************************");

                /*" -221- DISPLAY ' ' */
                _.Display($" ");

                /*" -223- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -225- PERFORM R1900-00-GRAVA-CAB-SI0048B1. */

            R1900_00_GRAVA_CAB_SI0048B1_SECTION();

            /*" -227- PERFORM R0900-00-DECLARA-LISTA */

            R0900_00_DECLARA_LISTA_SECTION();

            /*" -230- PERFORM R0910-00-LE-LISTA UNTIL WFIM-LISTA EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_LISTA == "S"))
            {

                R0910_00_LE_LISTA_SECTION();
            }

            /*" -230- PERFORM R0700-00-ALTERA-RELATORIOS. */

            R0700_00_ALTERA_RELATORIOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -236- CLOSE SI0048B1 */
            SI0048B1.Close();

            /*" -238- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -239- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -240- DISPLAY '***   SI0048B - FIM NORMAL ***' */
            _.Display($"***   SI0048B - FIM NORMAL ***");

            /*" -241- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -242- DISPLAY 'LIDOS SINISTROS PENDENTES    - ' AC-L-LISTA */
            _.Display($"LIDOS SINISTROS PENDENTES    - {AREA_DE_WORK.AC_L_LISTA}");

            /*" -244- DISPLAY 'GRAVADOS SI0048B1 (c/ cabe�) - ' AC-I-SI0048B1 */
            _.Display($"GRAVADOS SI0048B1 (c/ cabe�) - {AREA_DE_WORK.AC_I_SI0048B1}");

            /*" -244- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -247- DISPLAY ' ' . */
            _.Display($" ");

            /*" -254- DISPLAY '*** TERMINOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) ' ***' */

            $"*** TERMINOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss} ***"
            .Display();

            /*" -256- DISPLAY ' ' . */
            _.Display($" ");

            /*" -256- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -264- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -270- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -273- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -274- DISPLAY 'SI0048B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -274- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -270- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

            var r0500_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0500_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0500_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-SECTION */
        private void R0600_00_LE_RELATORIOS_SECTION()
        {
            /*" -284- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -293- PERFORM R0600_00_LE_RELATORIOS_DB_SELECT_1 */

            R0600_00_LE_RELATORIOS_DB_SELECT_1();

            /*" -296- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -297- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -298- ELSE */
            }
            else
            {


                /*" -299- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -300- DISPLAY 'SI0048B - PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"SI0048B - PROBLEMAS NO SELECT RELATORIOS");

                    /*" -300- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORIOS-DB-SELECT-1 */
        public void R0600_00_LE_RELATORIOS_DB_SELECT_1()
        {
            /*" -293- EXEC SQL SELECT COD_USUARIO INTO :RELATORI-COD-USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0048B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' WITH UR END-EXEC. */

            var r0600_00_LE_RELATORIOS_DB_SELECT_1_Query1 = new R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0600_00_LE_RELATORIOS_DB_SELECT_1_Query1.Execute(r0600_00_LE_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-SECTION */
        private void R0700_00_ALTERA_RELATORIOS_SECTION()
        {
            /*" -310- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -317- PERFORM R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1 */

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1();

            /*" -320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -321- DISPLAY 'SI0048B - PROBLEMAS NO UPDATE RELATORIOS' */
                _.Display($"SI0048B - PROBLEMAS NO UPDATE RELATORIOS");

                /*" -321- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-ALTERA-RELATORIOS-DB-UPDATE-1 */
        public void R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1()
        {
            /*" -317- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0048B' AND IDE_SISTEMA = 'SI' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC. */

            var r0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1 = new R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1.Execute(r0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-SECTION */
        private void R0900_00_DECLARA_LISTA_SECTION()
        {
            /*" -337- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -374- PERFORM R0900_00_DECLARA_LISTA_DB_DECLARE_1 */

            R0900_00_DECLARA_LISTA_DB_DECLARE_1();

            /*" -377- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -378- DISPLAY 'SI0048B - NAO EXISTEM SINISTROS PENDENTES' */
                _.Display($"SI0048B - NAO EXISTEM SINISTROS PENDENTES");

                /*" -379- DISPLAY 'COD-OPERACAO = ' GESISFUO-COD-OPERACAO */
                _.Display($"COD-OPERACAO = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO}");

                /*" -380- DISPLAY 'IDE-SISTEMA  = ' GESISFUO-IDE-SISTEMA */
                _.Display($"IDE-SISTEMA  = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                /*" -381- GO TO R0000-90-ENCERRA */

                R0000_90_ENCERRA(); //GOTO
                return;

                /*" -382- ELSE */
            }
            else
            {


                /*" -383- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -384- DISPLAY 'SI0048B - PROBLEMAS NO SELECT LISTA ' */
                    _.Display($"SI0048B - PROBLEMAS NO SELECT LISTA ");

                    /*" -385- DISPLAY 'COD-OPERACAO = ' GESISFUO-COD-OPERACAO */
                    _.Display($"COD-OPERACAO = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO}");

                    /*" -386- DISPLAY 'IDE-SISTEMA  = ' GESISFUO-IDE-SISTEMA */
                    _.Display($"IDE-SISTEMA  = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                    /*" -387- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -388- END-IF */
                }


                /*" -390- END-IF. */
            }


            /*" -390- PERFORM R0900_00_DECLARA_LISTA_DB_OPEN_1 */

            R0900_00_DECLARA_LISTA_DB_OPEN_1();

            /*" -393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -395- DISPLAY 'SI0048B - PROBLEMAS NO OPEN LISTA ' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"SI0048B - PROBLEMAS NO OPEN LISTA  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -395- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-DECLARE-1 */
        public void R0900_00_DECLARA_LISTA_DB_DECLARE_1()
        {
            /*" -374- EXEC SQL DECLARE LISTA CURSOR FOR SELECT DISTINCT H.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE ((H.NUM_APOL_SINISTRO BETWEEN 0104000000000 AND 0104099999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0104500000000 AND 0104599999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0104800000000 AND 0104899999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0106000000000 AND 0106099999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0106100000000 AND 0106199999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0106500000000 AND 0106599999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0106600000000 AND 0106699999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0106800000000 AND 0106899999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0107000000000 AND 0107099999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0107500000000 AND 0107599999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0107700000000 AND 0107799999999) OR (H.NUM_APOL_SINISTRO BETWEEN 0109300000000 AND 0109399999999)) AND B.IDE_SISTEMA = 'SI' AND H.COD_OPERACAO = B.COD_OPERACAO AND B.COD_FUNCAO IN (1,7,11) AND B.TIPO_ENDOSSO = '9' AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA GROUP BY H.NUM_APOL_SINISTRO HAVING VALUE(SUM(H.VAL_OPERACAO * B.NUM_FATOR), 0) > 0 ORDER BY H.NUM_APOL_SINISTRO WITH UR END-EXEC. */
            LISTA = new SI0048B_LISTA(false);
            string GetQuery_LISTA()
            {
                var query = @$"SELECT DISTINCT H.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER B 
							WHERE ((H.NUM_APOL_SINISTRO BETWEEN 
							0104000000000 AND 0104099999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0104500000000 AND 0104599999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0104800000000 AND 0104899999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0106000000000 AND 0106099999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0106100000000 AND 0106199999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0106500000000 AND 0106599999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0106600000000 AND 0106699999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0106800000000 AND 0106899999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0107000000000 AND 0107099999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0107500000000 AND 0107599999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0107700000000 AND 0107799999999) OR 
							(H.NUM_APOL_SINISTRO BETWEEN 
							0109300000000 AND 0109399999999)) 
							AND B.IDE_SISTEMA = 'SI' 
							AND H.COD_OPERACAO = B.COD_OPERACAO 
							AND B.COD_FUNCAO IN (1
							,7
							,11) 
							AND B.TIPO_ENDOSSO = '9' 
							AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA 
							GROUP BY H.NUM_APOL_SINISTRO 
							HAVING VALUE(SUM(H.VAL_OPERACAO * B.NUM_FATOR)
							, 0) > 0 
							ORDER BY H.NUM_APOL_SINISTRO";

                return query;
            }
            LISTA.GetQueryEvent += GetQuery_LISTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-LISTA-DB-OPEN-1 */
        public void R0900_00_DECLARA_LISTA_DB_OPEN_1()
        {
            /*" -390- EXEC SQL OPEN LISTA END-EXEC. */

            LISTA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-LISTA-SECTION */
        private void R0910_00_LE_LISTA_SECTION()
        {
            /*" -405- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -407- PERFORM R0910_00_LE_LISTA_DB_FETCH_1 */

            R0910_00_LE_LISTA_DB_FETCH_1();

            /*" -410- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -411- ADD 1 TO AC-L-LISTA */
                AREA_DE_WORK.AC_L_LISTA.Value = AREA_DE_WORK.AC_L_LISTA + 1;

                /*" -412- PERFORM R1000-00-BUSCA-SINISMES */

                R1000_00_BUSCA_SINISMES_SECTION();

                /*" -413- PERFORM R1100-00-BUSCA-SINISCAU */

                R1100_00_BUSCA_SINISCAU_SECTION();

                /*" -414- PERFORM R1200-00-BUSCA-DATAS */

                R1200_00_BUSCA_DATAS_SECTION();

                /*" -415- PERFORM R1300-00-BUSCA-VL-PENDENTE */

                R1300_00_BUSCA_VL_PENDENTE_SECTION();

                /*" -416- PERFORM R1400-00-BUSCA-VL-AVISADO */

                R1400_00_BUSCA_VL_AVISADO_SECTION();

                /*" -419- IF SINISMES-RAMO EQUAL 48 OR 60 OR 66 OR 68 OR 70 OR 77 OR 93 OR 61 OR 65 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("48", "60", "66", "68", "70", "77", "93", "61", "65"))
                {

                    /*" -420- PERFORM R2100-00-TRAZ-NOM-TERC-FAV */

                    R2100_00_TRAZ_NOM_TERC_FAV_SECTION();

                    /*" -422- ELSE */
                }
                else
                {


                    /*" -423- IF SINISMES-RAMO EQUAL 40 OR 45 OR 75 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("40", "45", "75"))
                    {

                        /*" -424- PERFORM R1600-00-BUSCA-SEGURADO */

                        R1600_00_BUSCA_SEGURADO_SECTION();

                        /*" -425- ELSE */
                    }
                    else
                    {


                        /*" -426- MOVE SPACES TO LD01-SEGURADO */
                        _.Move("", LD01.LD01_SEGURADO);

                        /*" -427- MOVE 0 TO LD01-NUM-CONTRATO */
                        _.Move(0, LD01.LD01_NUM_CONTRATO);

                        /*" -428- END-IF */
                    }


                    /*" -429- END-IF */
                }


                /*" -430- PERFORM R1800-00-GRAVA-SI0048B1 */

                R1800_00_GRAVA_SI0048B1_SECTION();

                /*" -431- ELSE */
            }
            else
            {


                /*" -432- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -433- MOVE 'S' TO WFIM-LISTA */
                    _.Move("S", AREA_DE_WORK.WFIM_LISTA);

                    /*" -433- PERFORM R0910_00_LE_LISTA_DB_CLOSE_1 */

                    R0910_00_LE_LISTA_DB_CLOSE_1();

                    /*" -435- ELSE */
                }
                else
                {


                    /*" -437- DISPLAY 'SI0048B - PROBLEMAS NO FETCH LISTA ' ' ' SINISHIS-NUM-APOL-SINISTRO */

                    $"SI0048B - PROBLEMAS NO FETCH LISTA  {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                    .Display();

                    /*" -438- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -439- END-IF */
                }


                /*" -439- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-FETCH-1 */
        public void R0910_00_LE_LISTA_DB_FETCH_1()
        {
            /*" -407- EXEC SQL FETCH LISTA INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (LISTA.Fetch())
            {
                _.Move(LISTA.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-LISTA-DB-CLOSE-1 */
        public void R0910_00_LE_LISTA_DB_CLOSE_1()
        {
            /*" -433- EXEC SQL CLOSE LISTA END-EXEC */

            LISTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-BUSCA-SINISMES-SECTION */
        private void R1000_00_BUSCA_SINISMES_SECTION()
        {
            /*" -449- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -463- PERFORM R1000_00_BUSCA_SINISMES_DB_SELECT_1 */

            R1000_00_BUSCA_SINISMES_DB_SELECT_1();

            /*" -466- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -467- MOVE SINISMES-COD-PRODUTO TO LD01-PRODUTO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, LD01.LD01_PRODUTO);

                /*" -468- MOVE SINISMES-NUM-APOL-SINISTRO TO LD01-SINISTRO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LD01.LD01_SINISTRO);

                /*" -469- MOVE SINISMES-DATA-COMUNICADO TO LD01-DT-COMUNICADO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, LD01.LD01_DT_COMUNICADO);

                /*" -470- MOVE SINISMES-COD-CAUSA TO LD01-CAUSA-SIN */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, LD01.LD01_CAUSA_SIN);

                /*" -471- ELSE */
            }
            else
            {


                /*" -472- DISPLAY 'SI0048B - PROBLEMAS NO SELECT SINISMES' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT SINISMES");

                /*" -473- DISPLAY 'NUM-APOL-SIN = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SIN = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -474- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -474- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-BUSCA-SINISMES-DB-SELECT-1 */
        public void R1000_00_BUSCA_SINISMES_DB_SELECT_1()
        {
            /*" -463- EXEC SQL SELECT COD_PRODUTO, NUM_APOL_SINISTRO, DATA_COMUNICADO, COD_CAUSA, RAMO INTO :SINISMES-COD-PRODUTO, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-DATA-COMUNICADO, :SINISMES-COD-CAUSA, :SINISMES-RAMO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1 = new R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1.Execute(r1000_00_BUSCA_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(executed_1.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(executed_1.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(executed_1.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-BUSCA-SINISCAU-SECTION */
        private void R1100_00_BUSCA_SINISCAU_SECTION()
        {
            /*" -484- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -493- PERFORM R1100_00_BUSCA_SINISCAU_DB_SELECT_1 */

            R1100_00_BUSCA_SINISCAU_DB_SELECT_1();

            /*" -496- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -497- MOVE SINISCAU-GRUPO-CAUSAS TO LD01-GR-CAUSA */
                _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS, LD01.LD01_GR_CAUSA);

                /*" -498- MOVE SINISCAU-DESCR-CAUSA TO LD01-DESC-CAUSA */
                _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, LD01.LD01_DESC_CAUSA);

                /*" -499- ELSE */
            }
            else
            {


                /*" -500- DISPLAY 'SI0048B - PROBLEMAS NO SELECT SINISCAU' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT SINISCAU");

                /*" -501- DISPLAY 'COD-CAUSA = ' SINISMES-COD-CAUSA */
                _.Display($"COD-CAUSA = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -502- DISPLAY 'RAMO      = ' SINISMES-RAMO */
                _.Display($"RAMO      = {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -503- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -503- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-BUSCA-SINISCAU-DB-SELECT-1 */
        public void R1100_00_BUSCA_SINISCAU_DB_SELECT_1()
        {
            /*" -493- EXEC SQL SELECT GRUPO_CAUSAS, DESCR_CAUSA INTO :SINISCAU-GRUPO-CAUSAS, :SINISCAU-DESCR-CAUSA FROM SEGUROS.SINISTRO_CAUSA WHERE COD_CAUSA = :SINISMES-COD-CAUSA AND RAMO_EMISSOR = :SINISMES-RAMO WITH UR END-EXEC. */

            var r1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1 = new R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1()
            {
                SINISMES_COD_CAUSA = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA.ToString(),
                SINISMES_RAMO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.ToString(),
            };

            var executed_1 = R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1.Execute(r1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
                _.Move(executed_1.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-BUSCA-DATAS-SECTION */
        private void R1200_00_BUSCA_DATAS_SECTION()
        {
            /*" -513- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -524- PERFORM R1200_00_BUSCA_DATAS_DB_SELECT_1 */

            R1200_00_BUSCA_DATAS_DB_SELECT_1();

            /*" -527- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -528- MOVE SINISHIS-DATA-MOVIMENTO TO LD01-DT-AVISO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, LD01.LD01_DT_AVISO);

                /*" -529- MOVE WS-QTDE-DIAS-PENDENTE TO LD01-QTD-PENDENTES */
                _.Move(WS_QTDE_DIAS_PENDENTE, LD01.LD01_QTD_PENDENTES);

                /*" -530- ELSE */
            }
            else
            {


                /*" -531- DISPLAY 'SI0048B - PROBLEMAS NO SELECT DATAS' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT DATAS");

                /*" -532- DISPLAY 'NUM-APOL-SIN = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SIN = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -533- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -534- END-IF. */
            }


            /*" -534- MOVE WS-CURRENT-DATE TO LD01-DT-ATUAL. */
            _.Move(WS_CURRENT_DATE, LD01.LD01_DT_ATUAL);

        }

        [StopWatch]
        /*" R1200-00-BUSCA-DATAS-DB-SELECT-1 */
        public void R1200_00_BUSCA_DATAS_DB_SELECT_1()
        {
            /*" -524- EXEC SQL SELECT H.DATA_MOVIMENTO, CURRENT_DATE, DAYS(CURRENT_DATE) - DAYS(H.DATA_MOVIMENTO) INTO :SINISHIS-DATA-MOVIMENTO, :WS-CURRENT-DATE, :WS-QTDE-DIAS-PENDENTE FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 101 WITH UR END-EXEC. */

            var r1200_00_BUSCA_DATAS_DB_SELECT_1_Query1 = new R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1200_00_BUSCA_DATAS_DB_SELECT_1_Query1.Execute(r1200_00_BUSCA_DATAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(executed_1.WS_CURRENT_DATE, WS_CURRENT_DATE);
                _.Move(executed_1.WS_QTDE_DIAS_PENDENTE, WS_QTDE_DIAS_PENDENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-BUSCA-VL-PENDENTE-SECTION */
        private void R1300_00_BUSCA_VL_PENDENTE_SECTION()
        {
            /*" -544- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -556- PERFORM R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1 */

            R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1();

            /*" -559- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -561- MOVE WS-VALOR-PENDENTE TO LD01-VL-PENDENTE */
                _.Move(WS_VALOR_PENDENTE, LD01.LD01_VL_PENDENTE);

                /*" -562- ELSE */
            }
            else
            {


                /*" -563- DISPLAY 'SI0048B - PROBLEMAS NO SELECT VAL-PENDENTE' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT VAL-PENDENTE");

                /*" -564- DISPLAY 'NUM-APOL-SIN = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SIN = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -565- DISPLAY 'COD-OPERACAO = ' GESISFUO-COD-OPERACAO */
                _.Display($"COD-OPERACAO = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO}");

                /*" -566- DISPLAY 'IDE-SISTEMA  = ' GESISFUO-IDE-SISTEMA */
                _.Display($"IDE-SISTEMA  = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_IDE_SISTEMA}");

                /*" -567- DISPLAY 'VALOR-PENDEN = ' WS-VALOR-PENDENTE */
                _.Display($"VALOR-PENDEN = {WS_VALOR_PENDENTE}");

                /*" -568- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -568- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-BUSCA-VL-PENDENTE-DB-SELECT-1 */
        public void R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1()
        {
            /*" -556- EXEC SQL SELECT VALUE(SUM(H.VAL_OPERACAO * B.NUM_FATOR), 0) INTO :WS-VALOR-PENDENTE FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.IDE_SISTEMA = 'SI' AND H.COD_OPERACAO = B.COD_OPERACAO AND B.COD_FUNCAO IN (1,7,11) AND B.TIPO_ENDOSSO = '9' AND B.IDE_SISTEMA_OPER = B.IDE_SISTEMA WITH UR END-EXEC. */

            var r1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1 = new R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1.Execute(r1300_00_BUSCA_VL_PENDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VALOR_PENDENTE, WS_VALOR_PENDENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-BUSCA-VL-AVISADO-SECTION */
        private void R1400_00_BUSCA_VL_AVISADO_SECTION()
        {
            /*" -578- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -590- PERFORM R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1 */

            R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1();

            /*" -593- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -594- MOVE SINISHIS-VAL-OPERACAO TO LD01-VL-AVISADO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD01.LD01_VL_AVISADO);

                /*" -595- ELSE */
            }
            else
            {


                /*" -596- DISPLAY 'SI0048B - PROBLEMAS NO SELECT VAL-AVISADO' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT VAL-AVISADO");

                /*" -597- DISPLAY 'NUM-APOL-SIN  = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SIN  = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -598- DISPLAY 'COD-OPERACAO  = ' GESISFUO-COD-OPERACAO */
                _.Display($"COD-OPERACAO  = {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_OPERACAO}");

                /*" -599- DISPLAY 'VALOR-AVISADO = ' WS-VALOR-AVISADO */
                _.Display($"VALOR-AVISADO = {WS_VALOR_AVISADO}");

                /*" -600- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -600- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-BUSCA-VL-AVISADO-DB-SELECT-1 */
        public void R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1()
        {
            /*" -590- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR), 0.00) INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.IDE_SISTEMA = 'SI' AND A.COD_OPERACAO = B.COD_OPERACAO AND B.COD_FUNCAO IN (3,9,13) AND B.TIPO_ENDOSSO = '9' AND B.IDE_SISTEMA_OPER = 'SI' WITH UR END-EXEC. */

            var r1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1 = new R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1.Execute(r1400_00_BUSCA_VL_AVISADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-TRAZ-NOM-TERC-FAV-SECTION */
        private void R2100_00_TRAZ_NOM_TERC_FAV_SECTION()
        {
            /*" -610- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -612- IF SINISMES-COD-PRODUTO = 4800 OR 4802 OR 4803 OR 4805 OR 4807 OR 4809 OR 4810 OR 4899 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("4800", "4802", "4803", "4805", "4807", "4809", "4810", "4899"))
            {

                /*" -613- PERFORM R2200-00-TRAZ-NOM-CREDITO */

                R2200_00_TRAZ_NOM_CREDITO_SECTION();

                /*" -615- END-IF. */
            }


            /*" -616- IF SINISMES-COD-PRODUTO = 9301 OR 9302 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("9301", "9302"))
            {

                /*" -617- PERFORM R2300-00-TRAZ-NOM-PENHOR-CE */

                R2300_00_TRAZ_NOM_PENHOR_CE_SECTION();

                /*" -618- PERFORM R2310-00-TRAZ-CTR-PENHOR-CE */

                R2310_00_TRAZ_CTR_PENHOR_CE_SECTION();

                /*" -621- END-IF. */
            }


            /*" -623- IF (SINISMES-RAMO = 68 OR 61 OR 65) OR (SINISMES-COD-PRODUTO = 4801 OR 4812 OR 7001) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("68", "61", "65")) || (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.In("4801", "4812", "7001")))
            {

                /*" -624- PERFORM R2400-00-TRAZ-NOM-HAB-MATCON */

                R2400_00_TRAZ_NOM_HAB_MATCON_SECTION();

                /*" -626- END-IF. */
            }


            /*" -627- IF SINISMES-RAMO = 66 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
            {

                /*" -628- PERFORM R2500-00-TRAZ-NOM-HIPOTECARIO */

                R2500_00_TRAZ_NOM_HIPOTECARIO_SECTION();

                /*" -628- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-TRAZ-NOM-CREDITO-SECTION */
        private void R2200_00_TRAZ_NOM_CREDITO_SECTION()
        {
            /*" -639- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -653- PERFORM R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1 */

            R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1();

            /*" -656- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -658- DISPLAY 'R2200-ERRO NO ACESSO A SINISTRO_CRED_INT' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                $"R2200-ERRO NO ACESSO A SINISTRO_CRED_INT SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -659- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -661- END-IF. */
            }


            /*" -663- MOVE SINCREIN-NUM-CONTRATO TO LD01-NUM-CONTRATO. */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO, LD01.LD01_NUM_CONTRATO);

            /*" -664- PERFORM R2210-00-ACESSA-APOLICRE. */

            R2210_00_ACESSA_APOLICRE_SECTION();

            /*" -665- IF APOLICRE-PROPRIET = SPACES */

            if (APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET.IsEmpty())
            {

                /*" -666- MOVE CLIENTES-NOME-RAZAO TO LD01-SEGURADO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_SEGURADO);

                /*" -667- ELSE */
            }
            else
            {


                /*" -668- MOVE APOLICRE-PROPRIET TO LD01-SEGURADO */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, LD01.LD01_SEGURADO);

                /*" -668- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-TRAZ-NOM-CREDITO-DB-SELECT-1 */
        public void R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1()
        {
            /*" -653- EXEC SQL SELECT COD_SUREG, COD_AGENCIA, COD_OPERACAO, NUM_CONTRATO, CONTRATO_DIGITO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1 = new R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1.Execute(r2200_00_TRAZ_NOM_CREDITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-ACESSA-APOLICRE-SECTION */
        private void R2210_00_ACESSA_APOLICRE_SECTION()
        {
            /*" -679- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -707- PERFORM R2210_00_ACESSA_APOLICRE_DB_SELECT_1 */

            R2210_00_ACESSA_APOLICRE_DB_SELECT_1();

            /*" -710- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -711- MOVE SPACES TO APOLICRE-PROPRIET */
                _.Move("", APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);

                /*" -712- MOVE SPACES TO APOLICRE-TIPO-PESSOA */
                _.Move("", APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_TIPO_PESSOA);

                /*" -713- PERFORM R2220-00-ACESSA-SINIITEM */

                R2220_00_ACESSA_SINIITEM_SECTION();

                /*" -714- PERFORM R2230-00-ACESSA-CLIENTES */

                R2230_00_ACESSA_CLIENTES_SECTION();

                /*" -715- GO TO R2210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;

                /*" -717- END-IF. */
            }


            /*" -718- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -724- DISPLAY 'R2210-ERRO NO ACESSO A APOLICE_CREDITO' ' SUREG   : ' SINCREIN-COD-SUREG ' AGENCIA : ' SINCREIN-COD-AGENCIA ' OPERACAO: ' SINCREIN-COD-OPERACAO ' CONTRATO: ' SINCREIN-NUM-CONTRATO ' DIGITO  : ' SINCREIN-CONTRATO-DIGITO */

                $"R2210-ERRO NO ACESSO A APOLICE_CREDITO SUREG   : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG} AGENCIA : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA} OPERACAO: {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO} CONTRATO: {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO} DIGITO  : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO}"
                .Display();

                /*" -725- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -725- END-IF. */
            }


        }

        [StopWatch]
        /*" R2210-00-ACESSA-APOLICRE-DB-SELECT-1 */
        public void R2210_00_ACESSA_APOLICRE_DB_SELECT_1()
        {
            /*" -707- EXEC SQL SELECT PROPRIET, TIPO_PESSOA, CGCCPF, NUM_FATURA, DATA_INIVIGENCIA INTO :APOLICRE-PROPRIET, :APOLICRE-TIPO-PESSOA, :APOLICRE-CGCCPF, :APOLICRE-NUM-FATURA, :APOLICRE-DATA-INIVIGENCIA FROM SEGUROS.APOLICE_CREDITO WHERE COD_SUREG = :SINCREIN-COD-SUREG AND COD_AGENCIA = :SINCREIN-COD-AGENCIA AND COD_OPERACAO = :SINCREIN-COD-OPERACAO AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO AND SITUACAO IN ( '1' , 'A' , 'B' , 'S' , '3' ) AND TIMESTAMP = (SELECT MAX(TIMESTAMP) FROM SEGUROS.APOLICE_CREDITO WHERE COD_SUREG = :SINCREIN-COD-SUREG AND COD_AGENCIA = :SINCREIN-COD-AGENCIA AND COD_OPERACAO = :SINCREIN-COD-OPERACAO AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO AND SITUACAO IN ( '1' , 'A' , 'B' , 'S' , '3' )) WITH UR END-EXEC. */

            var r2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1 = new R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1()
            {
                SINCREIN_CONTRATO_DIGITO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO.ToString(),
                SINCREIN_COD_OPERACAO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.ToString(),
                SINCREIN_NUM_CONTRATO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO.ToString(),
                SINCREIN_COD_AGENCIA = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA.ToString(),
                SINCREIN_COD_SUREG = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG.ToString(),
            };

            var executed_1 = R2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1.Execute(r2210_00_ACESSA_APOLICRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
                _.Move(executed_1.APOLICRE_TIPO_PESSOA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_TIPO_PESSOA);
                _.Move(executed_1.APOLICRE_CGCCPF, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
                _.Move(executed_1.APOLICRE_NUM_FATURA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_NUM_FATURA);
                _.Move(executed_1.APOLICRE_DATA_INIVIGENCIA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-ACESSA-SINIITEM-SECTION */
        private void R2220_00_ACESSA_SINIITEM_SECTION()
        {
            /*" -736- MOVE '2220' TO WNR-EXEC-SQL. */
            _.Move("2220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -742- PERFORM R2220_00_ACESSA_SINIITEM_DB_SELECT_1 */

            R2220_00_ACESSA_SINIITEM_DB_SELECT_1();

            /*" -745- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -747- DISPLAY 'R2220-ERRO NO ACESSO A SINISTRO_ITEM' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                $"R2220-ERRO NO ACESSO A SINISTRO_ITEM SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -748- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -748- END-IF. */
            }


        }

        [StopWatch]
        /*" R2220-00-ACESSA-SINIITEM-DB-SELECT-1 */
        public void R2220_00_ACESSA_SINIITEM_DB_SELECT_1()
        {
            /*" -742- EXEC SQL SELECT COD_CLIENTE INTO :SINIITEM-COD-CLIENTE FROM SEGUROS.SINISTRO_ITEM WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1 = new R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1.Execute(r2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIITEM_COD_CLIENTE, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-ACESSA-CLIENTES-SECTION */
        private void R2230_00_ACESSA_CLIENTES_SECTION()
        {
            /*" -759- MOVE '2230' TO WNR-EXEC-SQL. */
            _.Move("2230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -771- PERFORM R2230_00_ACESSA_CLIENTES_DB_SELECT_1 */

            R2230_00_ACESSA_CLIENTES_DB_SELECT_1();

            /*" -774- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -777- DISPLAY 'R2230-ERRO NO ACESSO A CLIENTES' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO ' COD CLIE: ' SINIITEM-COD-CLIENTE */

                $"R2230-ERRO NO ACESSO A CLIENTES SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO} COD CLIE: {SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE}"
                .Display();

                /*" -778- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -778- END-IF. */
            }


        }

        [StopWatch]
        /*" R2230-00-ACESSA-CLIENTES-DB-SELECT-1 */
        public void R2230_00_ACESSA_CLIENTES_DB_SELECT_1()
        {
            /*" -771- EXEC SQL SELECT NOME_RAZAO, TIPO_PESSOA, CGCCPF, VALUE(DATA_NASCIMENTO,DATE( '0001-01-01' )) INTO :CLIENTES-NOME-RAZAO, :APOLICRE-TIPO-PESSOA, :CLIENTES-CGCCPF, :CLIENTES-DATA-NASCIMENTO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE WITH UR END-EXEC. */

            var r2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1 = new R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1()
            {
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1.Execute(r2230_00_ACESSA_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.APOLICRE_TIPO_PESSOA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-TRAZ-NOM-PENHOR-CE-SECTION */
        private void R2300_00_TRAZ_NOM_PENHOR_CE_SECTION()
        {
            /*" -789- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -807- PERFORM R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1 */

            R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1();

            /*" -810- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -812- DISPLAY 'R2300-ERRO NO ACESSO JOIN SINISMES X SEGURVGA' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                $"R2300-ERRO NO ACESSO JOIN SINISMES X SEGURVGA SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -813- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -815- END-IF. */
            }


            /*" -815- MOVE CLIENTES-NOME-RAZAO TO LD01-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_SEGURADO);

        }

        [StopWatch]
        /*" R2300-00-TRAZ-NOM-PENHOR-CE-DB-SELECT-1 */
        public void R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1()
        {
            /*" -807- EXEC SQL SELECT C.NOME_RAZAO, C.TIPO_PESSOA, C.CGCCPF, VALUE(C.DATA_NASCIMENTO,DATE( '0001-01-01' )) INTO :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF, :CLIENTES-DATA-NASCIMENTO FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.SINISTRO_MESTRE B, SEGUROS.CLIENTES C WHERE B.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND A.COD_CLIENTE = C.COD_CLIENTE WITH UR END-EXEC. */

            var r2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1 = new R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1.Execute(r2300_00_TRAZ_NOM_PENHOR_CE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-TRAZ-CTR-PENHOR-CE-SECTION */
        private void R2310_00_TRAZ_CTR_PENHOR_CE_SECTION()
        {
            /*" -826- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -832- PERFORM R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1 */

            R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1();

            /*" -835- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -836- MOVE 0 TO LD01-NUM-CONTRATO */
                _.Move(0, LD01.LD01_NUM_CONTRATO);

                /*" -837- ELSE */
            }
            else
            {


                /*" -838- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -840- DISPLAY 'R2310-ERRO NO ACESSO A SINI_PENHOR01' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                    $"R2310-ERRO NO ACESSO A SINI_PENHOR01 SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                    .Display();

                    /*" -841- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -842- END-IF */
                }


                /*" -844- END-IF. */
            }


            /*" -844- MOVE SINIPENH-NUM-CONTRATO TO LD01-NUM-CONTRATO. */
            _.Move(SINIPENH.DCLSINI_PENHOR01.SINIPENH_NUM_CONTRATO, LD01.LD01_NUM_CONTRATO);

        }

        [StopWatch]
        /*" R2310-00-TRAZ-CTR-PENHOR-CE-DB-SELECT-1 */
        public void R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1()
        {
            /*" -832- EXEC SQL SELECT VALUE(NUM_CONTRATO,0) INTO :SINIPENH-NUM-CONTRATO FROM SEGUROS.SINI_PENHOR01 WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1 = new R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1.Execute(r2310_00_TRAZ_CTR_PENHOR_CE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIPENH_NUM_CONTRATO, SINIPENH.DCLSINI_PENHOR01.SINIPENH_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-TRAZ-NOM-HAB-MATCON-SECTION */
        private void R2400_00_TRAZ_NOM_HAB_MATCON_SECTION()
        {
            /*" -855- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -871- PERFORM R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1 */

            R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1();

            /*" -874- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -876- DISPLAY 'R2400-ERRO NO ACESSO DA SINISTRO_HABIT01' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                $"R2400-ERRO NO ACESSO DA SINISTRO_HABIT01 SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -877- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -879- END-IF. */
            }


            /*" -880- MOVE SINIHAB1-NUM-CONTRATO TO LD01-NUM-CONTRATO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, LD01.LD01_NUM_CONTRATO);

            /*" -880- MOVE SINIHAB1-NOME-SEGURADO TO LD01-SEGURADO. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, LD01.LD01_SEGURADO);

        }

        [StopWatch]
        /*" R2400-00-TRAZ-NOM-HAB-MATCON-DB-SELECT-1 */
        public void R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1()
        {
            /*" -871- EXEC SQL SELECT OPERACAO, PONTO_VENDA, NUM_CONTRATO, CGCCPF, NOME_SEGURADO, DATA_NASC INTO :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO, :SINIHAB1-CGCCPF, :SINIHAB1-NOME-SEGURADO, :SINIHAB1-DATA-NASC FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1 = new R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1.Execute(r2400_00_TRAZ_NOM_HAB_MATCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
                _.Move(executed_1.SINIHAB1_CGCCPF, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF);
                _.Move(executed_1.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
                _.Move(executed_1.SINIHAB1_DATA_NASC, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_DATA_NASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-TRAZ-NOM-HIPOTECARIO-SECTION */
        private void R2500_00_TRAZ_NOM_HIPOTECARIO_SECTION()
        {
            /*" -891- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -913- PERFORM R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1 */

            R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1();

            /*" -916- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -918- DISPLAY 'R2500-ERRO NO ACESSO DA MOVSINISTRO_HABIT' ' SINISTRO: ' SINISMES-NUM-APOL-SINISTRO */

                $"R2500-ERRO NO ACESSO DA MOVSINISTRO_HABIT SINISTRO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}"
                .Display();

                /*" -919- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -921- END-IF. */
            }


            /*" -922- MOVE MOVSINIH-NOME-SEGURADO TO LD01-SEGURADO. */
            _.Move(MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NOME_SEGURADO, LD01.LD01_SEGURADO);

            /*" -922- MOVE MOVSINIH-NUM-CONTRATO-CEF TO LD01-NUM-CONTRATO. */
            _.Move(MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NUM_CONTRATO_CEF, LD01.LD01_NUM_CONTRATO);

        }

        [StopWatch]
        /*" R2500-00-TRAZ-NOM-HIPOTECARIO-DB-SELECT-1 */
        public void R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1()
        {
            /*" -913- EXEC SQL SELECT NOME_SEGURADO, CGCCPF, DTH_NASCIMENTO, NUM_CONTRATO_CEF, MATR_AGENTE, COD_COBERTURA, TSTP_SITUACAO INTO :MOVSINIH-NOME-SEGURADO, :MOVSINIH-CGCCPF, :MOVSINIH-DTH-NASCIMENTO, :MOVSINIH-NUM-CONTRATO-CEF, :MOVSINIH-MATR-AGENTE, :MOVSINIH-COD-COBERTURA, :MOVSINIH-TSTP-SITUACAO FROM SEGUROS.MOVSINISTRO_HABIT B WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND TSTP_SITUACAO = (SELECT MAX(A.TSTP_SITUACAO) FROM SEGUROS.MOVSINISTRO_HABIT A WHERE A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO) WITH UR END-EXEC. */

            var r2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1 = new R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1.Execute(r2500_00_TRAZ_NOM_HIPOTECARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVSINIH_NOME_SEGURADO, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NOME_SEGURADO);
                _.Move(executed_1.MOVSINIH_CGCCPF, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_CGCCPF);
                _.Move(executed_1.MOVSINIH_DTH_NASCIMENTO, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_DTH_NASCIMENTO);
                _.Move(executed_1.MOVSINIH_NUM_CONTRATO_CEF, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NUM_CONTRATO_CEF);
                _.Move(executed_1.MOVSINIH_MATR_AGENTE, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_MATR_AGENTE);
                _.Move(executed_1.MOVSINIH_COD_COBERTURA, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_COD_COBERTURA);
                _.Move(executed_1.MOVSINIH_TSTP_SITUACAO, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_TSTP_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-BUSCA-SEGURADO-SECTION */
        private void R1600_00_BUSCA_SEGURADO_SECTION()
        {
            /*" -933- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -942- PERFORM R1600_00_BUSCA_SEGURADO_DB_SELECT_1 */

            R1600_00_BUSCA_SEGURADO_DB_SELECT_1();

            /*" -945- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -946- PERFORM R1700-00-BUSCA-NOM-SEGURADO */

                R1700_00_BUSCA_NOM_SEGURADO_SECTION();

                /*" -947- ELSE */
            }
            else
            {


                /*" -948- DISPLAY 'SI0048B - PROBLEMAS NO SELECT SINIITEM' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT SINIITEM");

                /*" -949- DISPLAY 'NUM-APOL-SIN = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM-APOL-SIN = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -950- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -950- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-BUSCA-SEGURADO-DB-SELECT-1 */
        public void R1600_00_BUSCA_SEGURADO_DB_SELECT_1()
        {
            /*" -942- EXEC SQL SELECT COD_CLIENTE INTO :SINIITEM-COD-CLIENTE FROM SEGUROS.SINISTRO_ITEM WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1 = new R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1.Execute(r1600_00_BUSCA_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIITEM_COD_CLIENTE, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-BUSCA-NOM-SEGURADO-SECTION */
        private void R1700_00_BUSCA_NOM_SEGURADO_SECTION()
        {
            /*" -960- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -969- PERFORM R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1 */

            R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1();

            /*" -972- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -973- MOVE CLIENTES-NOME-RAZAO TO LD01-SEGURADO */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_SEGURADO);

                /*" -974- MOVE 0 TO LD01-NUM-CONTRATO */
                _.Move(0, LD01.LD01_NUM_CONTRATO);

                /*" -975- ELSE */
            }
            else
            {


                /*" -976- DISPLAY 'SI0048B - PROBLEMAS NO SELECT CLIENTES' */
                _.Display($"SI0048B - PROBLEMAS NO SELECT CLIENTES");

                /*" -977- DISPLAY 'COD-CLIENTE = ' SINIITEM-COD-CLIENTE */
                _.Display($"COD-CLIENTE = {SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE}");

                /*" -978- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -978- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-BUSCA-NOM-SEGURADO-DB-SELECT-1 */
        public void R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1()
        {
            /*" -969- EXEC SQL SELECT NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE WITH UR END-EXEC. */

            var r1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1 = new R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1()
            {
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1.Execute(r1700_00_BUSCA_NOM_SEGURADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-GRAVA-SI0048B1-SECTION */
        private void R1800_00_GRAVA_SI0048B1_SECTION()
        {
            /*" -988- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -989- WRITE REG-SI0048B1 FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SI0048B1);

            SI0048B1.Write(REG_SI0048B1.GetMoveValues().ToString());

            /*" -989- ADD 1 TO AC-I-SI0048B1. */
            AREA_DE_WORK.AC_I_SI0048B1.Value = AREA_DE_WORK.AC_I_SI0048B1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-GRAVA-CAB-SI0048B1-SECTION */
        private void R1900_00_GRAVA_CAB_SI0048B1_SECTION()
        {
            /*" -1000- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1001- WRITE REG-SI0048B1 FROM LC01. */
            _.Move(LC01.GetMoveValues(), REG_SI0048B1);

            SI0048B1.Write(REG_SI0048B1.GetMoveValues().ToString());

            /*" -1001- ADD 1 TO AC-I-SI0048B1. */
            AREA_DE_WORK.AC_I_SI0048B1.Value = AREA_DE_WORK.AC_I_SI0048B1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1011- CLOSE SI0048B1 */
            SI0048B1.Close();

            /*" -1012- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1014- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1016- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1016- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1019- DISPLAY '*****************************' */
            _.Display($"*****************************");

            /*" -1020- DISPLAY '***  SI0048B - CANCELADO  ***' */
            _.Display($"***  SI0048B - CANCELADO  ***");

            /*" -1021- DISPLAY '*****************************' */
            _.Display($"*****************************");

            /*" -1022- DISPLAY 'LIDOS SINISTROS PENDENTES    - ' AC-L-LISTA */
            _.Display($"LIDOS SINISTROS PENDENTES    - {AREA_DE_WORK.AC_L_LISTA}");

            /*" -1024- DISPLAY 'GRAVADOS SI0048B1 (c/ cabe�) - ' AC-I-SI0048B1 */
            _.Display($"GRAVADOS SI0048B1 (c/ cabe�) - {AREA_DE_WORK.AC_I_SI0048B1}");

            /*" -1024- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}