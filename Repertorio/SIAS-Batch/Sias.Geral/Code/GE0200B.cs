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
using Sias.Geral.DB2.GE0200B;

namespace Code
{
    public class GE0200B
    {
        public bool IsCall { get; set; }

        public GE0200B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  DIRECIONADORES ( PROJETO ABC )     *      */
        /*"      *   PROGRAMA ...............  GE0200B                            *      */
        /*"      *   ANALISTA ...............  PRODEXTER (MARCEL)                 *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER (VANDO)                  *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO / 2002                    *      */
        /*"      *   FUNCAO .................  FORMATAR ARQUIVO COM AS INFORMA-   *      */
        /*"      *                             COES OBTIDAS NO MES                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * BARAN 11/12/2002 INCLUI O CAMPO CD_ORIGEM                      *      */
        /*"      *                                           PROCURAR BR122002    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"LG0504* ALTERA LAYOUT A PEDIDO DO RODRIGO EM 25/03/2004               *       */
        /*"      * - ALTERAR CODIGO DA EMPRESA PARA 3 DIGITOS                    *       */
        /*"      *   ALTERADO POR LIGIA - 26/05/2004  - PROCURAR LG0504          **      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                           BOOK                 ACESSO   *      */
        /*"      * ----------------------------------------------------- -------- *      */
        /*"      * SISTEMAS                         SISTEMAS             INPUT    *      */
        /*"      * GE_ACOMP_DIRECIONA               GEACODIR             INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ARQUIVO_DIRECIONA { get; set; } = new FileBasis(new PIC("X", "85", "X(85)"));

        public FileBasis ARQUIVO_DIRECIONA
        {
            get
            {
                _.Move(DIRECI_REGISTRO, _ARQUIVO_DIRECIONA); VarBasis.RedefinePassValue(DIRECI_REGISTRO, _ARQUIVO_DIRECIONA, DIRECI_REGISTRO); return _ARQUIVO_DIRECIONA;
            }
        }
        /*"01              DIRECI-REGISTRO    PIC  X(085).*/
        public StringBasis DIRECI_REGISTRO { get; set; } = new StringBasis(new PIC("X", "85", "X(085)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77           SISTEMAS-DATA-INICIO  PIC  X(010)  VALUE  SPACES.*/
        public StringBasis SISTEMAS_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77           SISTEMAS-DATA-FINAL   PIC  X(010)  VALUE  SPACES.*/
        public StringBasis SISTEMAS_DATA_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01           AREA-DE-WORK.*/
        public GE0200B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0200B_AREA_DE_WORK();
        public class GE0200B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WFIM-GEACODIR       PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_GEACODIR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-CT-SELEC         PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_SELEC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-CT-GRAVA         PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WDATA-DB2.*/
            public GE0200B_WDATA_DB2 WDATA_DB2 { get; set; } = new GE0200B_WDATA_DB2();
            public class GE0200B_WDATA_DB2 : VarBasis
            {
                /*"    10       WANO-DB2            PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WMES-DB2            PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WMES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIA-DB2            PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-ACCEPT.*/
            }
            public GE0200B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new GE0200B_WS_DATA_ACCEPT();
            public class GE0200B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10       WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-HORA-ACCEPT.*/
            }
            public GE0200B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new GE0200B_WS_HORA_ACCEPT();
            public class GE0200B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10       WS-HOR-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-MIN-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WS-SEG-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-CURR.*/
            }
            public GE0200B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new GE0200B_WS_DATA_CURR();
            public class GE0200B_WS_DATA_CURR : VarBasis
            {
                /*"    10       WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-HORA-CURR.*/
            }
            public GE0200B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new GE0200B_WS_HORA_CURR();
            public class GE0200B_WS_HORA_CURR : VarBasis
            {
                /*"    10       WS-HOR-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MIN-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-SEG-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-DB2.*/
            }
            public GE0200B_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new GE0200B_WS_DATA_DB2();
            public class GE0200B_WS_DATA_DB2 : VarBasis
            {
                /*"    10       WS-ANO-DB2          PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-MES-DB2          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WS-DIA-DB2          PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDIREC-CABECALHO.*/
            }
            public GE0200B_WDIREC_CABECALHO WDIREC_CABECALHO { get; set; } = new GE0200B_WDIREC_CABECALHO();
            public class GE0200B_WDIREC_CABECALHO : VarBasis
            {
                /*"    10       FILLER            PIC  X(085) VALUE            'CD-PER;CD-EMP;CD-VOLUME;CD-VLDET;CD-FIL;CD-CEN;CD-RA            'MO;CD-PRODUTO;VALOR;CD-ORIGEM    '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)"), @"CD_PER;CD_EMP;CD_VOLUME;CD_VLDET;CD_FIL;CD_CEN;CD_RA            ");
                /*"  05         WDIREC-REGISTRO.*/
            }
            public GE0200B_WDIREC_REGISTRO WDIREC_REGISTRO { get; set; } = new GE0200B_WDIREC_REGISTRO();
            public class GE0200B_WDIREC_REGISTRO : VarBasis
            {
                /*"    10       WDIREC-CD-PER-AA  PIC  9(004) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_PER_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDIREC-HIFEN      PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_HIFEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-PER-MM  PIC  9(002) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_PER_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WDIREC-SEPA-01    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-EMP     PIC  9(003) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_EMP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    10       WDIREC-SEPA-02    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-DIREC   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_DIREC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDIREC-SEPA-03    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-TPAPOL  PIC  9(001) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_TPAPOL { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"    10       WDIREC-SEPA-04    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-FIL     PIC  9(004) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_FIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDIREC-SEPA-05    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-CEN     PIC  9(005) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_CEN { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    10       WDIREC-SEPA-06    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-RAMO    PIC  9(004) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDIREC-SEPA-07    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-PROD    PIC  9(004) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_PROD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDIREC-SEPA-08    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-VALOR   PIC  9(009) VALUE  ZEROS.*/
                public IntBasis WDIREC_CD_VALOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    10       WDIREC-SEPA-09    PIC  X(001) VALUE  SPACES.*/
                public StringBasis WDIREC_SEPA_09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDIREC-CD-ORIGEM  PIC  9(001) VALUE  0.*/
                public IntBasis WDIREC_CD_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05       TABELA-MESES.*/
            }
            public GE0200B_TABELA_MESES TABELA_MESES { get; set; } = new GE0200B_TABELA_MESES();
            public class GE0200B_TABELA_MESES : VarBasis
            {
                /*"    10     FILLER              PIC  X(009) VALUE 'JANEIRO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JANEIRO");
                /*"    10     FILLER              PIC  X(009) VALUE 'FEVEREIRO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
                /*"    10     FILLER              PIC  X(009) VALUE 'MARCO'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MARCO");
                /*"    10     FILLER              PIC  X(009) VALUE 'ABRIL'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"ABRIL");
                /*"    10     FILLER              PIC  X(009) VALUE 'MAIO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"MAIO");
                /*"    10     FILLER              PIC  X(009) VALUE 'JUNHO'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JUNHO");
                /*"    10     FILLER              PIC  X(009) VALUE 'JULHO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"JULHO");
                /*"    10     FILLER              PIC  X(009) VALUE 'AGOSTO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AGOSTO");
                /*"    10     FILLER              PIC  X(009) VALUE 'SETEMBRO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SETEMBRO");
                /*"    10     FILLER              PIC  X(009) VALUE 'OUTUBRO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"OUTUBRO");
                /*"    10     FILLER              PIC  X(009) VALUE 'NOVEMBRO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"NOVEMBRO");
                /*"    10     FILLER              PIC  X(009) VALUE 'DEZEMBRO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DEZEMBRO");
                /*"  05       TAB-MES             REDEFINES   TABELA-MESES                               OCCURS      12                               PIC  X(009).*/
            }
            private _REDEF_StringBasis _tab_mes { get; set; }
            public _REDEF_StringBasis TAB_MES
            {
                get { _tab_mes = new _REDEF_StringBasis(new PIC("X", "009", "X(009).")); ; _.Move(TABELA_MESES, _tab_mes); VarBasis.RedefinePassValue(TABELA_MESES, _tab_mes, TABELA_MESES); _tab_mes.ValueChanged += () => { _.Move(_tab_mes, TABELA_MESES); }; return _tab_mes; }
                set { VarBasis.RedefinePassValue(value, _tab_mes, TABELA_MESES); }
            }  //Redefines
            /*"  05        WABEND.*/
            public GE0200B_WABEND WABEND { get; set; } = new GE0200B_WABEND();
            public class GE0200B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC X(010) VALUE           ' GE0200B'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0200B");
                /*"    10      FILLER              PIC X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GEACODIR GEACODIR { get; set; } = new Dclgens.GEACODIR();
        public GE0200B_C01_GEACODIR C01_GEACODIR { get; set; } = new GE0200B_C01_GEACODIR();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQUIVO_DIRECIONA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQUIVO_DIRECIONA.SetFile(ARQUIVO_DIRECIONA_FILE_NAME_P);

                /*" -211- MOVE '0001' TO WNR-EXEC-SQL. */
                _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -211- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -212- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -213- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -216- PERFORM R0100-00-PROCESSO-INICIAL */

                R0100_00_PROCESSO_INICIAL_SECTION();

                /*" -217- PERFORM R1000-00-PROCESSO-PRINCIPAL */

                R1000_00_PROCESSO_PRINCIPAL_SECTION();

                /*" -219- PERFORM R0200-00-PROCESSO-FINAL */

                R0200_00_PROCESSO_FINAL_SECTION();

                /*" -219- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0100-00-PROCESSO-INICIAL-SECTION */
        private void R0100_00_PROCESSO_INICIAL_SECTION()
        {
            /*" -229- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -230- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -231- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -232- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -233- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -234- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -236- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -237- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -238- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -239- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -240- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -242- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -244- DISPLAY 'GE0200B - Inicio de Execucao ' WS-DATA-CURR ' - ' WS-HORA-CURR */

            $"GE0200B - Inicio de Execucao {AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR}"
            .Display();

            /*" -246- DISPLAY '   ' . */
            _.Display($"   ");

            /*" -246- OPEN OUTPUT ARQUIVO-DIRECIONA. */
            ARQUIVO_DIRECIONA.Open(DIRECI_REGISTRO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-PROCESSO-FINAL-SECTION */
        private void R0200_00_PROCESSO_FINAL_SECTION()
        {
            /*" -259- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -260- DISPLAY '+-----------------------------------+' */
            _.Display($"+-----------------------------------+");

            /*" -262- DISPLAY '| Referencia : ' TAB-MES(WS-MES-DB2) ' de ' WS-ANO-DB2 '    |' */

            $"| Referencia : TAB-MES(WS-MES-DB2) de {AREA_DE_WORK.WS_DATA_DB2.WS_ANO_DB2}    |"
            .Display();

            /*" -263- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -264- IF WS-CT-SELEC GREATER ZEROS */

            if (AREA_DE_WORK.WS_CT_SELEC > 00)
            {

                /*" -265- DISPLAY '| Documentos Lidos         ' WS-CT-SELEC '  |' */

                $"| Documentos Lidos         {AREA_DE_WORK.WS_CT_SELEC}  |"
                .Display();

                /*" -266- DISPLAY '| Documentos Gravados      ' WS-CT-GRAVA '  |' */

                $"| Documentos Gravados      {AREA_DE_WORK.WS_CT_GRAVA}  |"
                .Display();

                /*" -267- DISPLAY '+-----------------------------------+' */
                _.Display($"+-----------------------------------+");

                /*" -268- ELSE */
            }
            else
            {


                /*" -269- DISPLAY '| Nao houve movimentacao no periodo |' */
                _.Display($"| Nao houve movimentacao no periodo |");

                /*" -271- DISPLAY '+-----------------------------------+' . */
                _.Display($"+-----------------------------------+");
            }


            /*" -272- MOVE '00/00/0000' TO WS-DATA-CURR */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -273- ACCEPT WS-DATA-ACCEPT FROM DATE */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -274- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -275- MOVE WS-MES-ACCEPT TO WS-MES-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -276- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -278- ADD 2000 TO WS-ANO-CURR */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -279- MOVE '00:00:00' TO WS-HORA-CURR */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -280- ACCEPT WS-HORA-ACCEPT FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -281- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -282- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -284- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -286- CLOSE ARQUIVO-DIRECIONA. */
            ARQUIVO_DIRECIONA.Close();

            /*" -287- DISPLAY '   ' */
            _.Display($"   ");

            /*" -288- DISPLAY 'GE0200B - Final de Execucao  ' WS-DATA-CURR ' - ' WS-HORA-CURR. */

            $"GE0200B - Final de Execucao  {AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R1000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -301- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -302- PERFORM R1100-00-SELECT-SISTEMAS */

            R1100_00_SELECT_SISTEMAS_SECTION();

            /*" -304- WRITE DIRECI-REGISTRO FROM WDIREC-CABECALHO. */
            _.Move(AREA_DE_WORK.WDIREC_CABECALHO.GetMoveValues(), DIRECI_REGISTRO);

            ARQUIVO_DIRECIONA.Write(DIRECI_REGISTRO.GetMoveValues().ToString());

            /*" -305- MOVE SPACES TO WFIM-GEACODIR */
            _.Move("", AREA_DE_WORK.WFIM_GEACODIR);

            /*" -306- PERFORM R1200-00-DECLARE-GEACODIR */

            R1200_00_DECLARE_GEACODIR_SECTION();

            /*" -307- PERFORM R1210-00-FETCH-GEACODIR */

            R1210_00_FETCH_GEACODIR_SECTION();

            /*" -308- PERFORM R1300-00-PROCESSA-GEACODIR UNTIL WFIM-GEACODIR NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_GEACODIR.IsEmpty()))
            {

                R1300_00_PROCESSA_GEACODIR_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SISTEMAS-SECTION */
        private void R1100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -321- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -326- PERFORM R1100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R1100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -329- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -330- DISPLAY 'R1100 - PROBLEMAS SELECT SISTEMAS (RG)' */
                _.Display($"R1100 - PROBLEMAS SELECT SISTEMAS (RG)");

                /*" -332- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -333- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-DB2 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_DB2);

            /*" -334- MOVE WS-DATA-DB2 TO SISTEMAS-DATA-FINAL */
            _.Move(AREA_DE_WORK.WS_DATA_DB2, SISTEMAS_DATA_FINAL);

            /*" -335- MOVE 01 TO WS-DIA-DB2 */
            _.Move(01, AREA_DE_WORK.WS_DATA_DB2.WS_DIA_DB2);

            /*" -335- MOVE WS-DATA-DB2 TO SISTEMAS-DATA-INICIO. */
            _.Move(AREA_DE_WORK.WS_DATA_DB2, SISTEMAS_DATA_INICIO);

        }

        [StopWatch]
        /*" R1100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R1100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -326- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'RG' END-EXEC. */

            var r1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-DECLARE-GEACODIR-SECTION */
        private void R1200_00_DECLARE_GEACODIR_SECTION()
        {
            /*" -348- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -371- PERFORM R1200_00_DECLARE_GEACODIR_DB_DECLARE_1 */

            R1200_00_DECLARE_GEACODIR_DB_DECLARE_1();

            /*" -373- PERFORM R1200_00_DECLARE_GEACODIR_DB_OPEN_1 */

            R1200_00_DECLARE_GEACODIR_DB_OPEN_1();

            /*" -375- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -376- DISPLAY 'R1200 - PROBLEMAS OPEN CURSOR GEACODIR' */
                _.Display($"R1200 - PROBLEMAS OPEN CURSOR GEACODIR");

                /*" -376- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-DECLARE-GEACODIR-DB-DECLARE-1 */
        public void R1200_00_DECLARE_GEACODIR_DB_DECLARE_1()
        {
            /*" -371- EXEC SQL DECLARE C01_GEACODIR CURSOR FOR SELECT DTH_REFERENCIA , COD_EMPRESA , COD_TIPO_MOVIMENTO , COD_FONTE , RAMO_EMISSOR , COD_MODALIDADE , COD_PRODUTO , NUM_CENTRO_CUSTO , IND_EVENTO , QTD_APURADA , NOM_PROGRAMA , COD_USUARIO FROM SEGUROS.GE_ACOMP_DIRECIONA WHERE DTH_REFERENCIA >= :SISTEMAS-DATA-INICIO AND DTH_REFERENCIA <= :SISTEMAS-DATA-FINAL ORDER BY COD_EMPRESA , COD_TIPO_MOVIMENTO , COD_FONTE , RAMO_EMISSOR , COD_MODALIDADE , COD_PRODUTO , NUM_CENTRO_CUSTO END-EXEC. */
            C01_GEACODIR = new GE0200B_C01_GEACODIR(true);
            string GetQuery_C01_GEACODIR()
            {
                var query = @$"SELECT DTH_REFERENCIA
							, 
							COD_EMPRESA
							, 
							COD_TIPO_MOVIMENTO
							, 
							COD_FONTE
							, 
							RAMO_EMISSOR
							, 
							COD_MODALIDADE
							, 
							COD_PRODUTO
							, 
							NUM_CENTRO_CUSTO
							, 
							IND_EVENTO
							, 
							QTD_APURADA
							, 
							NOM_PROGRAMA
							, 
							COD_USUARIO 
							FROM SEGUROS.GE_ACOMP_DIRECIONA 
							WHERE DTH_REFERENCIA >= '{SISTEMAS_DATA_INICIO}' 
							AND DTH_REFERENCIA <= '{SISTEMAS_DATA_FINAL}' 
							ORDER BY COD_EMPRESA
							, 
							COD_TIPO_MOVIMENTO
							, 
							COD_FONTE
							, 
							RAMO_EMISSOR
							, 
							COD_MODALIDADE
							, 
							COD_PRODUTO
							, 
							NUM_CENTRO_CUSTO";

                return query;
            }
            C01_GEACODIR.GetQueryEvent += GetQuery_C01_GEACODIR;

        }

        [StopWatch]
        /*" R1200-00-DECLARE-GEACODIR-DB-OPEN-1 */
        public void R1200_00_DECLARE_GEACODIR_DB_OPEN_1()
        {
            /*" -373- EXEC SQL OPEN C01_GEACODIR END-EXEC. */

            C01_GEACODIR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-FETCH-GEACODIR-SECTION */
        private void R1210_00_FETCH_GEACODIR_SECTION()
        {
            /*" -389- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -402- PERFORM R1210_00_FETCH_GEACODIR_DB_FETCH_1 */

            R1210_00_FETCH_GEACODIR_DB_FETCH_1();

            /*" -405- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -406- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -407- MOVE '*' TO WFIM-GEACODIR */
                    _.Move("*", AREA_DE_WORK.WFIM_GEACODIR);

                    /*" -407- PERFORM R1210_00_FETCH_GEACODIR_DB_CLOSE_1 */

                    R1210_00_FETCH_GEACODIR_DB_CLOSE_1();

                    /*" -409- GO TO R1210-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                    return;

                    /*" -410- ELSE */
                }
                else
                {


                    /*" -420- DISPLAY 'R1210 - PROBLEMAS FETCH CURSOR GEACODIR ... ' ' ' GEACODIR-DTH-REFERENCIA ' ' GEACODIR-COD-EMPRESA ' ' GEACODIR-COD-TIPO-MOVIMENTO ' ' GEACODIR-COD-FONTE ' ' GEACODIR-RAMO-EMISSOR ' ' GEACODIR-COD-MODALIDADE ' ' GEACODIR-COD-PRODUTO ' ' GEACODIR-NUM-CENTRO-CUSTO ' ' GEACODIR-IND-EVENTO */

                    $"R1210 - PROBLEMAS FETCH CURSOR GEACODIR ...  {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_DTH_REFERENCIA} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_EMPRESA} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_TIPO_MOVIMENTO} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_FONTE} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_RAMO_EMISSOR} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_MODALIDADE} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_PRODUTO} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_NUM_CENTRO_CUSTO} {GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_IND_EVENTO}"
                    .Display();

                    /*" -422- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -422- ADD 1 TO WS-CT-SELEC. */
            AREA_DE_WORK.WS_CT_SELEC.Value = AREA_DE_WORK.WS_CT_SELEC + 1;

        }

        [StopWatch]
        /*" R1210-00-FETCH-GEACODIR-DB-FETCH-1 */
        public void R1210_00_FETCH_GEACODIR_DB_FETCH_1()
        {
            /*" -402- EXEC SQL FETCH C01_GEACODIR INTO :GEACODIR-DTH-REFERENCIA , :GEACODIR-COD-EMPRESA , :GEACODIR-COD-TIPO-MOVIMENTO , :GEACODIR-COD-FONTE , :GEACODIR-RAMO-EMISSOR , :GEACODIR-COD-MODALIDADE , :GEACODIR-COD-PRODUTO , :GEACODIR-NUM-CENTRO-CUSTO , :GEACODIR-IND-EVENTO , :GEACODIR-QTD-APURADA , :GEACODIR-NOM-PROGRAMA , :GEACODIR-COD-USUARIO END-EXEC. */

            if (C01_GEACODIR.Fetch())
            {
                _.Move(C01_GEACODIR.GEACODIR_DTH_REFERENCIA, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_DTH_REFERENCIA);
                _.Move(C01_GEACODIR.GEACODIR_COD_EMPRESA, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_EMPRESA);
                _.Move(C01_GEACODIR.GEACODIR_COD_TIPO_MOVIMENTO, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_TIPO_MOVIMENTO);
                _.Move(C01_GEACODIR.GEACODIR_COD_FONTE, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_FONTE);
                _.Move(C01_GEACODIR.GEACODIR_RAMO_EMISSOR, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_RAMO_EMISSOR);
                _.Move(C01_GEACODIR.GEACODIR_COD_MODALIDADE, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_MODALIDADE);
                _.Move(C01_GEACODIR.GEACODIR_COD_PRODUTO, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_PRODUTO);
                _.Move(C01_GEACODIR.GEACODIR_NUM_CENTRO_CUSTO, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_NUM_CENTRO_CUSTO);
                _.Move(C01_GEACODIR.GEACODIR_IND_EVENTO, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_IND_EVENTO);
                _.Move(C01_GEACODIR.GEACODIR_QTD_APURADA, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_QTD_APURADA);
                _.Move(C01_GEACODIR.GEACODIR_NOM_PROGRAMA, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_NOM_PROGRAMA);
                _.Move(C01_GEACODIR.GEACODIR_COD_USUARIO, GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R1210-00-FETCH-GEACODIR-DB-CLOSE-1 */
        public void R1210_00_FETCH_GEACODIR_DB_CLOSE_1()
        {
            /*" -407- EXEC SQL CLOSE C01_GEACODIR END-EXEC */

            C01_GEACODIR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-GEACODIR-SECTION */
        private void R1300_00_PROCESSA_GEACODIR_SECTION()
        {
            /*" -435- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -436- MOVE SPACES TO WDIREC-REGISTRO */
            _.Move("", AREA_DE_WORK.WDIREC_REGISTRO);

            /*" -437- MOVE '_' TO WDIREC-HIFEN */
            _.Move("_", AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_HIFEN);

            /*" -443- MOVE ';' TO WDIREC-SEPA-01 WDIREC-SEPA-02 WDIREC-SEPA-03 WDIREC-SEPA-04 WDIREC-SEPA-05 WDIREC-SEPA-06 WDIREC-SEPA-07 WDIREC-SEPA-08 WDIREC-SEPA-09 */
            _.Move(";", AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_01, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_02, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_03, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_04, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_05, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_06, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_07, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_08, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_SEPA_09);

            /*" -444- MOVE GEACODIR-DTH-REFERENCIA TO WDATA-DB2 */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_DTH_REFERENCIA, AREA_DE_WORK.WDATA_DB2);

            /*" -445- MOVE WMES-DB2 TO WDIREC-CD-PER-MM */
            _.Move(AREA_DE_WORK.WDATA_DB2.WMES_DB2, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_PER_MM);

            /*" -447- MOVE WANO-DB2 TO WDIREC-CD-PER-AA */
            _.Move(AREA_DE_WORK.WDATA_DB2.WANO_DB2, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_PER_AA);

            /*" -448- MOVE GEACODIR-COD-EMPRESA TO WDIREC-CD-EMP */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_EMPRESA, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_EMP);

            /*" -450- MOVE GEACODIR-COD-TIPO-MOVIMENTO TO WDIREC-CD-DIREC */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_TIPO_MOVIMENTO, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_DIREC);

            /*" -451- MOVE GEACODIR-IND-EVENTO TO WDIREC-CD-TPAPOL */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_IND_EVENTO, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_TPAPOL);

            /*" -452- MOVE GEACODIR-COD-FONTE TO WDIREC-CD-FIL */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_FONTE, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_FIL);

            /*" -454- MOVE GEACODIR-NUM-CENTRO-CUSTO TO WDIREC-CD-CEN */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_NUM_CENTRO_CUSTO, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_CEN);

            /*" -455- MOVE GEACODIR-RAMO-EMISSOR TO WDIREC-CD-RAMO */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_RAMO_EMISSOR, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_RAMO);

            /*" -456- MOVE GEACODIR-COD-PRODUTO TO WDIREC-CD-PROD */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_COD_PRODUTO, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_PROD);

            /*" -457- MOVE GEACODIR-QTD-APURADA TO WDIREC-CD-VALOR */
            _.Move(GEACODIR.DCLGE_ACOMP_DIRECIONA.GEACODIR_QTD_APURADA, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_VALOR);

            /*" -459- MOVE 0 TO WDIREC-CD-ORIGEM */
            _.Move(0, AREA_DE_WORK.WDIREC_REGISTRO.WDIREC_CD_ORIGEM);

            /*" -461- WRITE DIRECI-REGISTRO FROM WDIREC-REGISTRO */
            _.Move(AREA_DE_WORK.WDIREC_REGISTRO.GetMoveValues(), DIRECI_REGISTRO);

            ARQUIVO_DIRECIONA.Write(DIRECI_REGISTRO.GetMoveValues().ToString());

            /*" -461- PERFORM R1210-00-FETCH-GEACODIR. */

            R1210_00_FETCH_GEACODIR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -476- CLOSE ARQUIVO-DIRECIONA. */
            ARQUIVO_DIRECIONA.Close();

            /*" -478- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -480- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -480- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -482- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -486- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -486- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}