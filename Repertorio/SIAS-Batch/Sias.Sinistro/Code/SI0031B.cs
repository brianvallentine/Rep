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
using Sias.Sinistro.DB2.SI0031B;

namespace Code
{
    public class SI0031B
    {
        public bool IsCall { get; set; }

        public SI0031B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO HABITACIONAL               *      */
        /*"      *   SUBROTINA............... SI0031B                             *      */
        /*"      *   ANALISTA ............... PRODEXTER                           *      */
        /*"      *   PROGRAMADOR ............ PRODEXTER                           *      */
        /*"      *   DATA CODIFICACAO ....... DEZ / 2001                          *      */
        /*"      *   FUNCAO ................. CONTROLE DE REITERACAO AUTOMATICA   *      */
        /*"      *                            PARA DOCUMENTOS PENDENTES           *      */
        /*"      *   **********************************************************   *      */
        /*"      *   ALTERACAO : JEFFERSON EM 17/01/2007                          *      */
        /*"      *   ATENDENDO A SS1 1725. REITERACAO DAS CARTAS SOMENTE ATE A 3. *      */
        /*"      *   PROCURAR POR JF1701.                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 16/07/2008 - WELLINGTON VERAS (POLITEC                         *      */
        /*"      *              PROJETO FGV                                       *      */
        /*"      *              INIBIR O COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 20/07/2012 - BARDUCCO - ABEND CADMUS 72187                     *      */
        /*"      *              IGNORA A LEITURA DO R1200-00-LE-SINISTRO-FASE     *      */
        /*"      *              QDO.SIMOVSIN-NOME-PROCURADOR NOT EQUAL 'SPBSI091' *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 4   - DIOGO    - ABEND CADMUS 74078                     *      */
        /*"      *              IGNORA A LEITURA DO PROTOCOLO DE SINISTRO 9764630 *      */
        /*"      *                                           PROCURE POR V.4      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 6   - KATIA    - ABEND CADMUS 95059                     *      */
        /*"      *              CHAMAR A SUBROTINA PTACOM2S PARA CONSIDERAR       *      */
        /*"      *              SI_CHECKLIST_PARAM.COD_FASE = 2 OU 3              *      */
        /*"      *                                           PROCURE POR V.6      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 7   - FLAVIO LIMA    - ABENDs JAZZ INCIDE.406678, 407091*      */
        /*"      *                                                                *      */
        /*"      *              SQLCODE=-805 BIND DE SUBROTINAS.                  *      */
        /*"      *                                                                *      */
        /*"      *              ADICIONEI A ROTINA R0001-VER NOS RETORNOS DE SUB- *      */
        /*"      *              ROTINAS COM ERROS PARA DISPLAYS.                  *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.07     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 8   - HERVAL SOUZA   - ABENDs INCIDE. OPTI-1222 E       *      */
        /*"      *                               OPTI-1278.                       *      */
        /*"      *              DEVIDO A ERROS SISTEMATICOS NO SAMRT, IGNORAR     *      */
        /*"      *              REGISTRO SEM SI_MOVIMENTO_SINI.                   *      */
        /*"      *              CRIAR ACUMULADORES, RETIRAR DISPLAYS ACUMULAR E   *      */
        /*"      *              DAR UM RESUMO DOS ERROS NO FINAL.                 *      */
        /*"      *              EM: 2024-10-17                                    *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.08     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *-------------------------------------                                  */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          HOST-COUNT           PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-COD-FONTE                                 PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-NUM-PROTOCOLO-SINI                                 PIC S9(009)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_NUM_PROTOCOLO_SINI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          H-SIDOCACO-DAC-PROTOCOLO-SINI                                 PIC  X(001)   VALUE   SPACES.*/
        public StringBasis H_SIDOCACO_DAC_PROTOCOLO_SINI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          H-SIDOCACO-COD-DOCUMENTO                                 PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-NUM-OCORR-DOCACO                                 PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_NUM_OCORR_DOCACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-COD-PRODUTO                                 PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-COD-GRUPO-CAUSA                                 PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-COD-SUBGRUPO-CAUSA                                 PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          H-SIDOCACO-DATA-INIVIG-DOCPAR                                 PIC  X(010)   VALUE   SPACES.*/
        public StringBasis H_SIDOCACO_DATA_INIVIG_DOCPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          H-SIDOCACO-DATA-MOVTO-DOCACO                                 PIC  X(010)   VALUE   SPACES.*/
        public StringBasis H_SIDOCACO_DATA_MOVTO_DOCACO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          H-SIDOCACO-NUM-CARTA                                 PIC S9(009)   VALUE   +0 COMP.*/
        public IntBasis H_SIDOCACO_NUM_CARTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WS-FONTE-ANT         PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-PROTOCOLO-ANT     PIC S9(009)   VALUE   +0 COMP.*/
        public IntBasis WS_PROTOCOLO_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WS-DAC-ANT           PIC  X(001)   VALUE   SPACES.*/
        public StringBasis WS_DAC_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          WS-PRODUTO-ANT       PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis WS_PRODUTO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-TIPO-CARTA-ANT    PIC S9(004)   VALUE   +0 COMP.*/
        public IntBasis WS_TIPO_CARTA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          WS-CARTA-ANT         PIC S9(009)   VALUE   +0 COMP.*/
        public IntBasis WS_CARTA_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          WS-NOME.*/
        public SI0031B_WS_NOME WS_NOME { get; set; } = new SI0031B_WS_NOME();
        public class SI0031B_WS_NOME : VarBasis
        {
            /*"  05        WS-NOME-5            PIC  X(005)   VALUE   SPACES.*/
            public StringBasis WS_NOME_5 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05        FILLER               PIC  X(035)   VALUE   SPACES.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
            /*"01          AREA-DE-WORK.*/
        }
        public SI0031B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0031B_AREA_DE_WORK();
        public class SI0031B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-JOIN            PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_L_JOIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-I-SIDOCACO        PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_I_SIDOCACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-ERRO-MOV          PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_ERRO_MOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-DESPREZA-FASE     PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_DESPREZA_FASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-SEQ               PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_SEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-LVI               PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_LVI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-ACHOU             PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_ACHOU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-NAO-ACHOU         PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_NAO_ACHOU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-MEDICO            PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_MEDICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-CARTA             PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_CARTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-IGNORADO          PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_IGNORADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-SEM-DEST          PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_SEM_DEST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-TEMP-AUX          PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_TEMP_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        AC-TAB-TEMP          PIC S9(004)   COMP-5 VALUE +0.*/
            public IntBasis AC_TAB_TEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        WFIM-JOIN            PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_JOIN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-CARTA-DEST      PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_CARTA_DEST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-REITERA-LVI       PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WS_REITERA_LVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-SEM-MOV           PIC  X(003)   VALUE  'NAO'.*/
            public StringBasis WS_SEM_MOV { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"  05        WS-NUM-PROT-SINI-ANT PIC S9(009)   VALUE   +0 COMP.*/
            public IntBasis WS_NUM_PROT_SINI_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05        WDATA.*/
            public SI0031B_WDATA WDATA { get; set; } = new SI0031B_WDATA();
            public class SI0031B_WDATA : VarBasis
            {
                /*"    10      WDATA-ANO            PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER               PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-MES            PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER               PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-DIA            PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
            }
            public SI0031B_WABEND WABEND { get; set; } = new SI0031B_WABEND();
            public class SI0031B_WABEND : VarBasis
            {
                /*"    10      FILLER               PIC  X(010) VALUE           ' SI0031B'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0031B");
                /*"    10      FILLER               PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL         PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER               PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE             PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05      DIN.*/
            }
            public SI0031B_DIN DIN { get; set; } = new SI0031B_DIN();
            public class SI0031B_DIN : VarBasis
            {
                /*"    10    DIN-SISTEMA              PIC  X(002).*/
                public StringBasis DIN_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10    DIN-CANAL                PIC S9(004).*/
                public IntBasis DIN_CANAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
                /*"    10    DIN-PV                   PIC S9(004).*/
                public IntBasis DIN_PV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
                /*"    10    DIN-USUARIO              PIC  X(008).*/
                public StringBasis DIN_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    10    DIN-OPERACAO             PIC S9(004).*/
                public IntBasis DIN_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
                /*"  05      DOUT.*/
            }
            public SI0031B_DOUT DOUT { get; set; } = new SI0031B_DOUT();
            public class SI0031B_DOUT : VarBasis
            {
                /*"    10    DOUT-COD-RETORNO         PIC S9(004).*/
                public IntBasis DOUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
                /*"    10    DOUT-COD-RETORNO-SQL     PIC S9(004).*/
                public IntBasis DOUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
                /*"    10    DOUT-MENSAGEM            PIC X(070).*/
                public StringBasis DOUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"    10    DOUT-SQLERRMC            PIC X(070).*/
                public StringBasis DOUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"    10    DOUT-SQLSTATE            PIC X(005).*/
                public StringBasis DOUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"  05  PROGRAMA                       PIC X(040).*/
            }
            public StringBasis PROGRAMA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01          WS-SQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
        }
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        /*"01          WS-COD-RET               PIC  9(004)    VALUE ZEROS.*/
        public IntBasis WS_COD_RET { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01          IX1                  PIC  9(004).*/
        public IntBasis IX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"01          IX2                  PIC  9(004).*/
        public IntBasis IX2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        /*"01          TABELA-DADOS         PIC  X(1000)   VALUE SPACES.*/
        public StringBasis TABELA_DADOS { get; set; } = new StringBasis(new PIC("X", "1000", "X(1000)"), @"");
        /*"  05        TAB-DADOS            OCCURS         50 TIMES.*/
        public ListBasis<SI0031B_TAB_DADOS> TAB_DADOS { get; set; } = new ListBasis<SI0031B_TAB_DADOS>(50);
        public class SI0031B_TAB_DADOS : VarBasis
        {
            /*"    10      TAB-COD-DOCUMENTO    PIC S9(004)    COMP.*/
            public IntBasis TAB_COD_DOCUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      TAB-NUM-OCORR-DOCACO PIC S9(004)    COMP.*/
            public IntBasis TAB_NUM_OCORR_DOCACO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      TAB-COD-PRODUTO      PIC S9(004)    COMP.*/
            public IntBasis TAB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      TAB-COD-GRUPO-CAUSA  PIC S9(004)    COMP.*/
            public IntBasis TAB_COD_GRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      TAB-COD-SUBGRUPO-CAUSA   PIC S9(004)    COMP.*/
            public IntBasis TAB_COD_SUBGRUPO_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    10      TAB-DATA-INIVIG-DOCPAR   PIC  X(010).*/
            public StringBasis TAB_DATA_INIVIG_DOCPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }


        public Copies.LBWCT001 LBWCT001 { get; set; } = new Copies.LBWCT001();
        public Copies.LBWCT002 LBWCT002 { get; set; } = new Copies.LBWCT002();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GECARTA GECARTA { get; set; } = new Dclgens.GECARTA();
        public Dclgens.GECARTEX GECARTEX { get; set; } = new Dclgens.GECARTEX();
        public Dclgens.GECARACO GECARACO { get; set; } = new Dclgens.GECARACO();
        public Dclgens.GECARPAR GECARPAR { get; set; } = new Dclgens.GECARPAR();
        public Dclgens.GEDESTIN GEDESTIN { get; set; } = new Dclgens.GEDESTIN();
        public Dclgens.GEDESCLA GEDESCLA { get; set; } = new Dclgens.GEDESCLA();
        public Dclgens.GERECADE GERECADE { get; set; } = new Dclgens.GERECADE();
        public Dclgens.SIDOCACO SIDOCACO { get; set; } = new Dclgens.SIDOCACO();
        public Dclgens.SISINACO SISINACO { get; set; } = new Dclgens.SISINACO();
        public Dclgens.SISINFAS SISINFAS { get; set; } = new Dclgens.SISINFAS();
        public Dclgens.SIDOCPAR SIDOCPAR { get; set; } = new Dclgens.SIDOCPAR();
        public Dclgens.SIMOVSIN SIMOVSIN { get; set; } = new Dclgens.SIMOVSIN();
        public Dclgens.SIEVETIP SIEVETIP { get; set; } = new Dclgens.SIEVETIP();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.SIANAROD SIANAROD { get; set; } = new Dclgens.SIANAROD();
        public SI0031B_JOIN_1 JOIN_1 { get; set; } = new SI0031B_JOIN_1();
        public SI0031B_C01_SISINFAS C01_SISINFAS { get; set; } = new SI0031B_C01_SISINFAS();
        public SI0031B_CARDEST CARDEST { get; set; } = new SI0031B_CARDEST();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -224- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -224- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -225- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -226- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -226- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -234- PERFORM R000-00-INFORMES */

            R000_00_INFORMES_SECTION();

            /*" -236- PERFORM R0500-00-LE-SISTEMAS */

            R0500_00_LE_SISTEMAS_SECTION();

            /*" -237- PERFORM R0900-00-DECLARA-JOIN */

            R0900_00_DECLARA_JOIN_SECTION();

            /*" -239- PERFORM R0910-00-LE-JOIN */

            R0910_00_LE_JOIN_SECTION();

            /*" -240- PERFORM R1000-00-PROCESSA UNTIL WFIM-JOIN EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_JOIN == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -246- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -247- DISPLAY '*********************************' */
            _.Display($"*********************************");

            /*" -248- DISPLAY '***   SI0031B V8 - FIM NORMAL ***' */
            _.Display($"***   SI0031B V8 - FIM NORMAL ***");

            /*" -249- DISPLAY '*********************************' */
            _.Display($"*********************************");

            /*" -250- DISPLAY 'DOCUMENTOS PENDENTES LIDOS... ' AC-L-JOIN */
            _.Display($"DOCUMENTOS PENDENTES LIDOS... {AREA_DE_WORK.AC_L_JOIN}");

            /*" -251- DISPLAY 'DOCUMENTOS REITERADOS........ ' AC-I-SIDOCACO */
            _.Display($"DOCUMENTOS REITERADOS........ {AREA_DE_WORK.AC_I_SIDOCACO}");

            /*" -252- DISPLAY 'SEM MOVIMENTO_SINI........... ' AC-ERRO-MOV */
            _.Display($"SEM MOVIMENTO_SINI........... {AREA_DE_WORK.AC_ERRO_MOV}");

            /*" -253- DISPLAY 'DESPREZADA DEVIDO FASE....... ' AC-DESPREZA-FASE */
            _.Display($"DESPREZADA DEVIDO FASE....... {AREA_DE_WORK.AC_DESPREZA_FASE}");

            /*" -254- DISPLAY 'DESPREZADA DEVIDO SEQUENCIA.. ' AC-SEQ */
            _.Display($"DESPREZADA DEVIDO SEQUENCIA.. {AREA_DE_WORK.AC_SEQ}");

            /*" -255- DISPLAY 'DESPREZADA-LVI NAO-PENDENTE.. ' AC-LVI */
            _.Display($"DESPREZADA-LVI NAO-PENDENTE.. {AREA_DE_WORK.AC_LVI}");

            /*" -256- DISPLAY 'ACHEI........................ ' AC-ACHOU */
            _.Display($"ACHEI........................ {AREA_DE_WORK.AC_ACHOU}");

            /*" -257- DISPLAY 'NAO ACHEI.................... ' AC-NAO-ACHOU */
            _.Display($"NAO ACHEI.................... {AREA_DE_WORK.AC_NAO_ACHOU}");

            /*" -258- DISPLAY 'CARTA SEM DESTINATARIO....... ' AC-SEM-DEST */
            _.Display($"CARTA SEM DESTINATARIO....... {AREA_DE_WORK.AC_SEM_DEST}");

            /*" -259- DISPLAY 'PARECER MEDICO NAO REITERADO. ' AC-MEDICO */
            _.Display($"PARECER MEDICO NAO REITERADO. {AREA_DE_WORK.AC_MEDICO}");

            /*" -260- DISPLAY 'CARTA NAO ENVIADA............ ' AC-CARTA */
            _.Display($"CARTA NAO ENVIADA............ {AREA_DE_WORK.AC_CARTA}");

            /*" -261- DISPLAY 'SALVOU TAB TEMP PROTOC ESPEC. ' AC-TEMP-AUX */
            _.Display($"SALVOU TAB TEMP PROTOC ESPEC. {AREA_DE_WORK.AC_TEMP_AUX}");

            /*" -262- DISPLAY 'SALVOU NA TABELA TEMPORARIA.. ' AC-TAB-TEMP */
            _.Display($"SALVOU NA TABELA TEMPORARIA.. {AREA_DE_WORK.AC_TAB_TEMP}");

            /*" -265- DISPLAY 'DOCUMENTOS IGNORADOS......... ' AC-IGNORADO */
            _.Display($"DOCUMENTOS IGNORADOS......... {AREA_DE_WORK.AC_IGNORADO}");

            /*" -265- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -266- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R000-00-INFORMES-SECTION */
        private void R000_00_INFORMES_SECTION()
        {
            /*" -274- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -275- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -276- DISPLAY 'VERSAO: V.08' */
            _.Display($"VERSAO: V.08");

            /*" -277- DISPLAY 'PROGRAMA SI0031B EM EXECUCAO' */
            _.Display($"PROGRAMA SI0031B EM EXECUCAO");

            /*" -284- DISPLAY 'COMPILADO EM ' FUNCTION WHEN-COMPILED(7:2) '/' FUNCTION WHEN-COMPILED(5:2) '/' FUNCTION WHEN-COMPILED(1:4) ' AS ' FUNCTION WHEN-COMPILED(9:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) ' *' */

            $"COMPILADO EM FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)} *"
            .Display();

            /*" -285- DISPLAY '***************************************************' */
            _.Display($"***************************************************");

            /*" -292- DISPLAY '-->INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) '<--' */

            $"-->INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}<--"
            .Display();

            /*" -293- DISPLAY ' ' */
            _.Display($" ");

            /*" -293- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R000_99_EXIT*/

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-SECTION */
        private void R0500_00_LE_SISTEMAS_SECTION()
        {
            /*" -302- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -307- PERFORM R0500_00_LE_SISTEMAS_DB_SELECT_1 */

            R0500_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -311- DISPLAY 'SI0031B - PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT SISTEMAS");

                /*" -311- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0500_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -307- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
        /*" R0900-00-DECLARA-JOIN-SECTION */
        private void R0900_00_DECLARA_JOIN_SECTION()
        {
            /*" -324- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -361- PERFORM R0900_00_DECLARA_JOIN_DB_DECLARE_1 */

            R0900_00_DECLARA_JOIN_DB_DECLARE_1();

            /*" -363- PERFORM R0900_00_DECLARA_JOIN_DB_OPEN_1 */

            R0900_00_DECLARA_JOIN_DB_OPEN_1();

            /*" -366- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -367- DISPLAY 'SI0031B - PROBLEMAS NO OPEN JOIN ' */
                _.Display($"SI0031B - PROBLEMAS NO OPEN JOIN ");

                /*" -367- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-JOIN-DB-DECLARE-1 */
        public void R0900_00_DECLARA_JOIN_DB_DECLARE_1()
        {
            /*" -361- EXEC SQL DECLARE JOIN-1 CURSOR FOR SELECT A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.DAC_PROTOCOLO_SINI, A.COD_DOCUMENTO, A.NUM_OCORR_DOCACO, A.COD_PRODUTO, A.COD_GRUPO_CAUSA, A.COD_SUBGRUPO_CAUSA, A.DATA_INIVIG_DOCPAR, A.DATA_MOVTO_DOCACO, A.NUM_CARTA, B.COD_TIPO_CARTA FROM SEGUROS.SI_DOCUMENTO_ACOMP A, SEGUROS.SI_DOCUMENTO_PARAM B WHERE A.COD_PRODUTO = B.COD_PRODUTO AND A.COD_GRUPO_CAUSA = B.COD_GRUPO_CAUSA AND A.COD_SUBGRUPO_CAUSA = B.COD_SUBGRUPO_CAUSA AND A.COD_DOCUMENTO = B.COD_DOCUMENTO AND A.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR AND A.COD_EVENTO IN (2012, 2013) AND A.NUM_CARTA IS NOT NULL AND A.NUM_OCORR_DOCACO = (SELECT MAX(C.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP C WHERE C.COD_FONTE = A.COD_FONTE AND C.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI AND C.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI AND C.COD_DOCUMENTO = A.COD_DOCUMENTO) AND A.NUM_PROTOCOLO_SINI NOT IN (9479390,9480214,9479364,9480207,9482990, 9479813,9479811,9764630) ORDER BY A.COD_FONTE, A.NUM_PROTOCOLO_SINI, A.NUM_CARTA WITH UR END-EXEC. */
            JOIN_1 = new SI0031B_JOIN_1(false);
            string GetQuery_JOIN_1()
            {
                var query = @$"SELECT A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.DAC_PROTOCOLO_SINI
							, 
							A.COD_DOCUMENTO
							, 
							A.NUM_OCORR_DOCACO
							, 
							A.COD_PRODUTO
							, 
							A.COD_GRUPO_CAUSA
							, 
							A.COD_SUBGRUPO_CAUSA
							, 
							A.DATA_INIVIG_DOCPAR
							, 
							A.DATA_MOVTO_DOCACO
							, 
							A.NUM_CARTA
							, 
							B.COD_TIPO_CARTA 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP A
							, 
							SEGUROS.SI_DOCUMENTO_PARAM B 
							WHERE A.COD_PRODUTO = B.COD_PRODUTO 
							AND A.COD_GRUPO_CAUSA = B.COD_GRUPO_CAUSA 
							AND A.COD_SUBGRUPO_CAUSA = B.COD_SUBGRUPO_CAUSA 
							AND A.COD_DOCUMENTO = B.COD_DOCUMENTO 
							AND A.DATA_INIVIG_DOCPAR = B.DATA_INIVIG_DOCPAR 
							AND A.COD_EVENTO IN (2012
							, 2013) 
							AND A.NUM_CARTA IS NOT NULL 
							AND A.NUM_OCORR_DOCACO = 
							(SELECT MAX(C.NUM_OCORR_DOCACO) 
							FROM SEGUROS.SI_DOCUMENTO_ACOMP C 
							WHERE C.COD_FONTE = A.COD_FONTE 
							AND C.NUM_PROTOCOLO_SINI = A.NUM_PROTOCOLO_SINI 
							AND C.DAC_PROTOCOLO_SINI = A.DAC_PROTOCOLO_SINI 
							AND C.COD_DOCUMENTO = A.COD_DOCUMENTO) 
							AND A.NUM_PROTOCOLO_SINI NOT IN 
							(9479390
							,9480214
							,9479364
							,9480207
							,9482990
							, 
							9479813
							,9479811
							,9764630) 
							ORDER BY A.COD_FONTE
							, 
							A.NUM_PROTOCOLO_SINI
							, 
							A.NUM_CARTA";

                return query;
            }
            JOIN_1.GetQueryEvent += GetQuery_JOIN_1;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-JOIN-DB-OPEN-1 */
        public void R0900_00_DECLARA_JOIN_DB_OPEN_1()
        {
            /*" -363- EXEC SQL OPEN JOIN-1 END-EXEC. */

            JOIN_1.Open();

        }

        [StopWatch]
        /*" R1200-00-LE-SINISTRO-FASE-DB-DECLARE-1 */
        public void R1200_00_LE_SINISTRO_FASE_DB_DECLARE_1()
        {
            /*" -626- EXEC SQL DECLARE C01_SISINFAS CURSOR FOR SELECT COD_FASE, NUM_OCORR_SINIACO FROM SEGUROS.SI_SINISTRO_FASE WHERE COD_FONTE = :H-SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :H-SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :H-SIDOCACO-DAC-PROTOCOLO-SINI ORDER BY NUM_OCORR_SINIACO DESC, COD_FASE END-EXEC. */
            C01_SISINFAS = new SI0031B_C01_SISINFAS(true);
            string GetQuery_C01_SISINFAS()
            {
                var query = @$"SELECT COD_FASE
							, 
							NUM_OCORR_SINIACO 
							FROM SEGUROS.SI_SINISTRO_FASE 
							WHERE COD_FONTE = '{H_SIDOCACO_COD_FONTE}' 
							AND NUM_PROTOCOLO_SINI = 
							'{H_SIDOCACO_NUM_PROTOCOLO_SINI}' 
							AND DAC_PROTOCOLO_SINI = 
							'{H_SIDOCACO_DAC_PROTOCOLO_SINI}' 
							ORDER BY NUM_OCORR_SINIACO DESC
							, 
							COD_FASE";

                return query;
            }
            C01_SISINFAS.GetQueryEvent += GetQuery_C01_SISINFAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-JOIN-SECTION */
        private void R0910_00_LE_JOIN_SECTION()
        {
            /*" -377- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -390- PERFORM R0910_00_LE_JOIN_DB_FETCH_1 */

            R0910_00_LE_JOIN_DB_FETCH_1();

            /*" -393- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -394- ADD 1 TO AC-L-JOIN */
                AREA_DE_WORK.AC_L_JOIN.Value = AREA_DE_WORK.AC_L_JOIN + 1;

                /*" -395- ELSE */
            }
            else
            {


                /*" -396- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -397- MOVE 'S' TO WFIM-JOIN */
                    _.Move("S", AREA_DE_WORK.WFIM_JOIN);

                    /*" -397- PERFORM R0910_00_LE_JOIN_DB_CLOSE_1 */

                    R0910_00_LE_JOIN_DB_CLOSE_1();

                    /*" -399- IF SQLCODE NOT = ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -400- DISPLAY 'SI0031B - PROBLEMA NO CLOSE JOIN-1' */
                        _.Display($"SI0031B - PROBLEMA NO CLOSE JOIN-1");

                        /*" -401- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -402- END-IF */
                    }


                    /*" -403- ELSE */
                }
                else
                {


                    /*" -404- DISPLAY 'SI0031B - PROBLEMAS NO FETCH JOIN-1' */
                    _.Display($"SI0031B - PROBLEMAS NO FETCH JOIN-1");

                    /*" -405- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -406- END-IF */
                }


                /*" -408- END-IF. */
            }


            /*" -410- PERFORM R1100-00-LE-MOVIMENTO-SINI */

            R1100_00_LE_MOVIMENTO_SINI_SECTION();

            /*" -411- IF WS-SEM-MOV = 'SIM' */

            if (AREA_DE_WORK.WS_SEM_MOV == "SIM")
            {

                /*" -412- ADD 1 TO AC-ERRO-MOV */
                AREA_DE_WORK.AC_ERRO_MOV.Value = AREA_DE_WORK.AC_ERRO_MOV + 1;

                /*" -413- ADD 1 TO AC-IGNORADO */
                AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                /*" -414- GO TO R0910-00-LE-JOIN */
                new Task(() => R0910_00_LE_JOIN_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -414- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-LE-JOIN-DB-FETCH-1 */
        public void R0910_00_LE_JOIN_DB_FETCH_1()
        {
            /*" -390- EXEC SQL FETCH JOIN-1 INTO :H-SIDOCACO-COD-FONTE, :H-SIDOCACO-NUM-PROTOCOLO-SINI, :H-SIDOCACO-DAC-PROTOCOLO-SINI, :H-SIDOCACO-COD-DOCUMENTO, :H-SIDOCACO-NUM-OCORR-DOCACO, :H-SIDOCACO-COD-PRODUTO, :H-SIDOCACO-COD-GRUPO-CAUSA, :H-SIDOCACO-COD-SUBGRUPO-CAUSA, :H-SIDOCACO-DATA-INIVIG-DOCPAR, :H-SIDOCACO-DATA-MOVTO-DOCACO, :H-SIDOCACO-NUM-CARTA, :SIDOCPAR-COD-TIPO-CARTA END-EXEC. */

            if (JOIN_1.Fetch())
            {
                _.Move(JOIN_1.H_SIDOCACO_COD_FONTE, H_SIDOCACO_COD_FONTE);
                _.Move(JOIN_1.H_SIDOCACO_NUM_PROTOCOLO_SINI, H_SIDOCACO_NUM_PROTOCOLO_SINI);
                _.Move(JOIN_1.H_SIDOCACO_DAC_PROTOCOLO_SINI, H_SIDOCACO_DAC_PROTOCOLO_SINI);
                _.Move(JOIN_1.H_SIDOCACO_COD_DOCUMENTO, H_SIDOCACO_COD_DOCUMENTO);
                _.Move(JOIN_1.H_SIDOCACO_NUM_OCORR_DOCACO, H_SIDOCACO_NUM_OCORR_DOCACO);
                _.Move(JOIN_1.H_SIDOCACO_COD_PRODUTO, H_SIDOCACO_COD_PRODUTO);
                _.Move(JOIN_1.H_SIDOCACO_COD_GRUPO_CAUSA, H_SIDOCACO_COD_GRUPO_CAUSA);
                _.Move(JOIN_1.H_SIDOCACO_COD_SUBGRUPO_CAUSA, H_SIDOCACO_COD_SUBGRUPO_CAUSA);
                _.Move(JOIN_1.H_SIDOCACO_DATA_INIVIG_DOCPAR, H_SIDOCACO_DATA_INIVIG_DOCPAR);
                _.Move(JOIN_1.H_SIDOCACO_DATA_MOVTO_DOCACO, H_SIDOCACO_DATA_MOVTO_DOCACO);
                _.Move(JOIN_1.H_SIDOCACO_NUM_CARTA, H_SIDOCACO_NUM_CARTA);
                _.Move(JOIN_1.SIDOCPAR_COD_TIPO_CARTA, SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-JOIN-DB-CLOSE-1 */
        public void R0910_00_LE_JOIN_DB_CLOSE_1()
        {
            /*" -397- EXEC SQL CLOSE JOIN-1 END-EXEC */

            JOIN_1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -439- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -440- IF SIMOVSIN-NOME-PROCURADOR NOT EQUAL 'SPBSI091' */

            if (SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_PROCURADOR != "SPBSI091")
            {

                /*" -441- PERFORM R1200-00-LE-SINISTRO-FASE */

                R1200_00_LE_SINISTRO_FASE_SECTION();

                /*" -443- END-IF. */
            }


            /*" -445- MOVE H-SIDOCACO-COD-PRODUTO TO WS-PRODUTO-ANT */
            _.Move(H_SIDOCACO_COD_PRODUTO, WS_PRODUTO_ANT);

            /*" -448- MOVE SIDOCPAR-COD-TIPO-CARTA TO WS-TIPO-CARTA-ANT */
            _.Move(SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA, WS_TIPO_CARTA_ANT);

            /*" -449- MOVE H-SIDOCACO-COD-FONTE TO WS-FONTE-ANT */
            _.Move(H_SIDOCACO_COD_FONTE, WS_FONTE_ANT);

            /*" -451- MOVE H-SIDOCACO-NUM-PROTOCOLO-SINI TO WS-PROTOCOLO-ANT */
            _.Move(H_SIDOCACO_NUM_PROTOCOLO_SINI, WS_PROTOCOLO_ANT);

            /*" -454- MOVE H-SIDOCACO-DAC-PROTOCOLO-SINI TO WS-DAC-ANT */
            _.Move(H_SIDOCACO_DAC_PROTOCOLO_SINI, WS_DAC_ANT);

            /*" -461- PERFORM R2000-00-PROCESSA-SINISTRO UNTIL WFIM-JOIN NOT EQUAL SPACES OR H-SIDOCACO-COD-FONTE NOT EQUAL WS-FONTE-ANT OR H-SIDOCACO-NUM-PROTOCOLO-SINI NOT EQUAL WS-PROTOCOLO-ANT OR H-SIDOCACO-DAC-PROTOCOLO-SINI NOT EQUAL WS-DAC-ANT. */

            while (!(!AREA_DE_WORK.WFIM_JOIN.IsEmpty() || H_SIDOCACO_COD_FONTE != WS_FONTE_ANT || H_SIDOCACO_NUM_PROTOCOLO_SINI != WS_PROTOCOLO_ANT || H_SIDOCACO_DAC_PROTOCOLO_SINI != WS_DAC_ANT))
            {

                R2000_00_PROCESSA_SINISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1234-DEPURAR-SECTION */
        private void R1234_DEPURAR_SECTION()
        {
            /*" -491- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -492- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -493- DISPLAY '***ACHOU***' */
                    _.Display($"***ACHOU***");

                    /*" -495- IF H-SIDOCACO-NUM-PROTOCOLO-SINI NOT = WS-NUM-PROT-SINI-ANT */

                    if (H_SIDOCACO_NUM_PROTOCOLO_SINI != AREA_DE_WORK.WS_NUM_PROT_SINI_ANT)
                    {

                        /*" -496- ADD 1 TO AC-ACHOU */
                        AREA_DE_WORK.AC_ACHOU.Value = AREA_DE_WORK.AC_ACHOU + 1;

                        /*" -497- END-IF */
                    }


                    /*" -499- END-IF */
                }


                /*" -500- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -501- DISPLAY '***NAO ACHOU***' */
                    _.Display($"***NAO ACHOU***");

                    /*" -503- IF H-SIDOCACO-NUM-PROTOCOLO-SINI NOT = WS-NUM-PROT-SINI-ANT */

                    if (H_SIDOCACO_NUM_PROTOCOLO_SINI != AREA_DE_WORK.WS_NUM_PROT_SINI_ANT)
                    {

                        /*" -504- ADD 1 TO AC-NAO-ACHOU */
                        AREA_DE_WORK.AC_NAO_ACHOU.Value = AREA_DE_WORK.AC_NAO_ACHOU + 1;

                        /*" -505- END-IF */
                    }


                    /*" -507- END-IF */
                }


                /*" -510- MOVE H-SIDOCACO-NUM-PROTOCOLO-SINI TO WS-NUM-PROT-SINI-ANT */
                _.Move(H_SIDOCACO_NUM_PROTOCOLO_SINI, AREA_DE_WORK.WS_NUM_PROT_SINI_ANT);

                /*" -511- DISPLAY 'WNR-EXEC-SQL......: ' WNR-EXEC-SQL */
                _.Display($"WNR-EXEC-SQL......: {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -512- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -514- DISPLAY 'WSQLCODE..........: ' WSQLCODE */
                _.Display($"WSQLCODE..........: {AREA_DE_WORK.WABEND.WSQLCODE}");

                /*" -526- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-NUM-OCORR-DOCACO ' ' H-SIDOCACO-COD-PRODUTO ' ' H-SIDOCACO-COD-GRUPO-CAUSA ' ' H-SIDOCACO-COD-SUBGRUPO-CAUSA ' ' H-SIDOCACO-DATA-INIVIG-DOCPAR ' ' H-SIDOCACO-DATA-MOVTO-DOCACO ' ' H-SIDOCACO-NUM-CARTA ' ' SIDOCPAR-COD-TIPO-CARTA */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_NUM_OCORR_DOCACO} {H_SIDOCACO_COD_PRODUTO} {H_SIDOCACO_COD_GRUPO_CAUSA} {H_SIDOCACO_COD_SUBGRUPO_CAUSA} {H_SIDOCACO_DATA_INIVIG_DOCPAR} {H_SIDOCACO_DATA_MOVTO_DOCACO} {H_SIDOCACO_NUM_CARTA} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA}"
                .Display();

                /*" -526- END-IF */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/

        [StopWatch]
        /*" R0001-VER-SECTION */
        private void R0001_VER_SECTION()
        {
            /*" -540- INITIALIZE DIN DOUT REPLACING ALPHANUMERIC BY SPACES NUMERIC BY ZEROS. */
            _.Initialize(
                AREA_DE_WORK.DIN
                , AREA_DE_WORK.DOUT
            );

            /*" -542- MOVE ZEROS TO WS-COD-RET WS-SQLCODE */
            _.Move(0, WS_COD_RET, WS_SQLCODE);

            /*" -543- MOVE IN-SISTEMA TO DIN-SISTEMA */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA, AREA_DE_WORK.DIN.DIN_SISTEMA);

            /*" -544- MOVE IN-CANAL TO DIN-CANAL */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_CANAL, AREA_DE_WORK.DIN.DIN_CANAL);

            /*" -545- MOVE IN-PV TO DIN-PV */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_PV, AREA_DE_WORK.DIN.DIN_PV);

            /*" -546- MOVE IN-USUARIO TO DIN-USUARIO */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO, AREA_DE_WORK.DIN.DIN_USUARIO);

            /*" -548- MOVE IN-OPERACAO TO DIN-OPERACAO */
            _.Move(LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO, AREA_DE_WORK.DIN.DIN_OPERACAO);

            /*" -549- DISPLAY 'DIN-SISTEMA  = ' DIN-SISTEMA */
            _.Display($"DIN-SISTEMA  = {AREA_DE_WORK.DIN.DIN_SISTEMA}");

            /*" -550- DISPLAY 'DIN-CANAL    = ' DIN-CANAL */
            _.Display($"DIN-CANAL    = {AREA_DE_WORK.DIN.DIN_CANAL}");

            /*" -551- DISPLAY 'DIN-PV       = ' DIN-PV */
            _.Display($"DIN-PV       = {AREA_DE_WORK.DIN.DIN_PV}");

            /*" -552- DISPLAY 'DIN-USUARIO  = ' DIN-USUARIO */
            _.Display($"DIN-USUARIO  = {AREA_DE_WORK.DIN.DIN_USUARIO}");

            /*" -554- DISPLAY 'DIN-OPERACAO = ' DIN-OPERACAO */
            _.Display($"DIN-OPERACAO = {AREA_DE_WORK.DIN.DIN_OPERACAO}");

            /*" -556- MOVE OUT-COD-RETORNO TO DOUT-COD-RETORNO WS-COD-RET */
            _.Move(LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO, AREA_DE_WORK.DOUT.DOUT_COD_RETORNO, WS_COD_RET);

            /*" -558- MOVE OUT-COD-RETORNO-SQL TO DOUT-COD-RETORNO-SQL WS-SQLCODE */
            _.Move(LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL, AREA_DE_WORK.DOUT.DOUT_COD_RETORNO_SQL, WS_SQLCODE);

            /*" -559- MOVE OUT-MENSAGEM TO DOUT-MENSAGEM */
            _.Move(LBWCT002.PROTOCOLO_ENVIO.OUT_MENSAGEM, AREA_DE_WORK.DOUT.DOUT_MENSAGEM);

            /*" -560- MOVE OUT-SQLERRMC TO DOUT-SQLERRMC */
            _.Move(LBWCT002.PROTOCOLO_ENVIO.OUT_SQLERRMC, AREA_DE_WORK.DOUT.DOUT_SQLERRMC);

            /*" -562- MOVE OUT-SQLSTATE TO DOUT-SQLSTATE */
            _.Move(LBWCT002.PROTOCOLO_ENVIO.OUT_SQLSTATE, AREA_DE_WORK.DOUT.DOUT_SQLSTATE);

            /*" -564- DISPLAY 'DOUT-COD-RETORNO      = ' DOUT-COD-RETORNO '   -> ' WS-COD-RET */

            $"DOUT-COD-RETORNO      = {AREA_DE_WORK.DOUT.DOUT_COD_RETORNO}   -> {WS_COD_RET}"
            .Display();

            /*" -566- DISPLAY 'DOUT-COD-RETORNO-SQL  = ' DOUT-COD-RETORNO-SQL '   -> ' WS-SQLCODE */

            $"DOUT-COD-RETORNO-SQL  = {AREA_DE_WORK.DOUT.DOUT_COD_RETORNO_SQL}   -> {WS_SQLCODE}"
            .Display();

            /*" -567- DISPLAY 'DOUT-MENSAGEM         = ' DOUT-MENSAGEM */
            _.Display($"DOUT-MENSAGEM         = {AREA_DE_WORK.DOUT.DOUT_MENSAGEM}");

            /*" -568- DISPLAY 'DOUT-SQLERRMC         = ' DOUT-SQLERRMC */
            _.Display($"DOUT-SQLERRMC         = {AREA_DE_WORK.DOUT.DOUT_SQLERRMC}");

            /*" -568- DISPLAY 'DOUT-SQLSTATE         = ' DOUT-SQLSTATE. */
            _.Display($"DOUT-SQLSTATE         = {AREA_DE_WORK.DOUT.DOUT_SQLSTATE}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/

        [StopWatch]
        /*" R1100-00-LE-MOVIMENTO-SINI-SECTION */
        private void R1100_00_LE_MOVIMENTO_SINI_SECTION()
        {
            /*" -578- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -580- MOVE 'NAO' TO WS-SEM-MOV. */
            _.Move("NAO", AREA_DE_WORK.WS_SEM_MOV);

            /*" -593- PERFORM R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1 */

            R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1();

            /*" -598- PERFORM R1234-DEPURAR THRU R1234-99-SAIDA */

            R1234_DEPURAR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/


            /*" -599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -600- DISPLAY 'SI0031B - PROBLEMAS NO SELECT SI_MOVIMENTO_SINI' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT SI_MOVIMENTO_SINI");

                /*" -604- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -605- MOVE 'SIM' TO WS-SEM-MOV */
                _.Move("SIM", AREA_DE_WORK.WS_SEM_MOV);

                /*" -605- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-LE-MOVIMENTO-SINI-DB-SELECT-1 */
        public void R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1()
        {
            /*" -593- EXEC SQL SELECT COD_ESTIPULANTE, COD_GIAFI, NOME_PROCURADOR INTO :SIMOVSIN-COD-ESTIPULANTE, :SIMOVSIN-COD-GIAFI, :SIMOVSIN-NOME-PROCURADOR FROM SEGUROS.SI_MOVIMENTO_SINI WHERE COD_FONTE = :H-SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :H-SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :H-SIDOCACO-DAC-PROTOCOLO-SINI END-EXEC. */

            var r1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1 = new R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1()
            {
                H_SIDOCACO_NUM_PROTOCOLO_SINI = H_SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                H_SIDOCACO_DAC_PROTOCOLO_SINI = H_SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                H_SIDOCACO_COD_FONTE = H_SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1.Execute(r1100_00_LE_MOVIMENTO_SINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIMOVSIN_COD_ESTIPULANTE, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE);
                _.Move(executed_1.SIMOVSIN_COD_GIAFI, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_GIAFI);
                _.Move(executed_1.SIMOVSIN_NOME_PROCURADOR, SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_NOME_PROCURADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LE-SINISTRO-FASE-SECTION */
        private void R1200_00_LE_SINISTRO_FASE_SECTION()
        {
            /*" -615- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -626- PERFORM R1200_00_LE_SINISTRO_FASE_DB_DECLARE_1 */

            R1200_00_LE_SINISTRO_FASE_DB_DECLARE_1();

            /*" -628- PERFORM R1200_00_LE_SINISTRO_FASE_DB_OPEN_1 */

            R1200_00_LE_SINISTRO_FASE_DB_OPEN_1();

            /*" -632- PERFORM R1234-DEPURAR THRU R1234-99-SAIDA */

            R1234_DEPURAR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/


            /*" -633- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -634- DISPLAY 'SI0031B - PROBLEMAS NO OPEN SI_SINISTRO_FASE' */
                _.Display($"SI0031B - PROBLEMAS NO OPEN SI_SINISTRO_FASE");

                /*" -637- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -639- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -642- PERFORM R1200_00_LE_SINISTRO_FASE_DB_FETCH_1 */

            R1200_00_LE_SINISTRO_FASE_DB_FETCH_1();

            /*" -647- PERFORM R1234-DEPURAR THRU R1234-99-SAIDA */

            R1234_DEPURAR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/


            /*" -648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -649- DISPLAY 'SI0031B - PROBLEMAS NO FETCH SI_SINISTRO_FASE' */
                _.Display($"SI0031B - PROBLEMAS NO FETCH SI_SINISTRO_FASE");

                /*" -652- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -654- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -654- PERFORM R1200_00_LE_SINISTRO_FASE_DB_CLOSE_1 */

            R1200_00_LE_SINISTRO_FASE_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R1200-00-LE-SINISTRO-FASE-DB-OPEN-1 */
        public void R1200_00_LE_SINISTRO_FASE_DB_OPEN_1()
        {
            /*" -628- EXEC SQL OPEN C01_SISINFAS END-EXEC. */

            C01_SISINFAS.Open();

        }

        [StopWatch]
        /*" R4700-00-DECLARA-CARTA-DEST-DB-DECLARE-1 */
        public void R4700_00_DECLARA_CARTA_DEST_DB_DECLARE_1()
        {
            /*" -1815- EXEC SQL DECLARE CARDEST CURSOR FOR SELECT A.COD_DESTINATARIO, A.IND_DEST_PRINC, B.NOME_DESTINATARIO FROM SEGUROS.GE_REL_CARTA_DEST A, SEGUROS.GE_DESTINATARIO B WHERE A.NUM_CARTA = :WS-CARTA-ANT AND A.COD_DESTINATARIO = B.COD_DESTINATARIO END-EXEC. */
            CARDEST = new SI0031B_CARDEST(true);
            string GetQuery_CARDEST()
            {
                var query = @$"SELECT A.COD_DESTINATARIO
							, 
							A.IND_DEST_PRINC
							, 
							B.NOME_DESTINATARIO 
							FROM SEGUROS.GE_REL_CARTA_DEST A
							, 
							SEGUROS.GE_DESTINATARIO B 
							WHERE A.NUM_CARTA = '{WS_CARTA_ANT}' 
							AND A.COD_DESTINATARIO = B.COD_DESTINATARIO";

                return query;
            }
            CARDEST.GetQueryEvent += GetQuery_CARDEST;

        }

        [StopWatch]
        /*" R1200-00-LE-SINISTRO-FASE-DB-FETCH-1 */
        public void R1200_00_LE_SINISTRO_FASE_DB_FETCH_1()
        {
            /*" -642- EXEC SQL FETCH C01_SISINFAS INTO :SISINFAS-COD-FASE, :SISINFAS-NUM-OCORR-SINIACO END-EXEC. */

            if (C01_SISINFAS.Fetch())
            {
                _.Move(C01_SISINFAS.SISINFAS_COD_FASE, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE);
                _.Move(C01_SISINFAS.SISINFAS_NUM_OCORR_SINIACO, SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_NUM_OCORR_SINIACO);
            }

        }

        [StopWatch]
        /*" R1200-00-LE-SINISTRO-FASE-DB-CLOSE-1 */
        public void R1200_00_LE_SINISTRO_FASE_DB_CLOSE_1()
        {
            /*" -654- EXEC SQL CLOSE C01_SISINFAS END-EXEC. */

            C01_SISINFAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISTRO-SECTION */
        private void R2000_00_PROCESSA_SINISTRO_SECTION()
        {
            /*" -664- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -665- PERFORM R2100-00-LE-CARTA-PARAMETRO */

            R2100_00_LE_CARTA_PARAMETRO_SECTION();

            /*" -666- PERFORM R2200-00-LE-EVENTO-TIPO */

            R2200_00_LE_EVENTO_TIPO_SECTION();

            /*" -672- PERFORM R2300-00-LIMPA-TABELA */

            R2300_00_LIMPA_TABELA_SECTION();

            /*" -673- MOVE 'S' TO WS-REITERA-LVI */
            _.Move("S", AREA_DE_WORK.WS_REITERA_LVI);

            /*" -675- IF SIDOCPAR-COD-TIPO-CARTA EQUAL 3 */

            if (SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 3)
            {

                /*" -676- PERFORM R2400-00-VERIFICA-LVI */

                R2400_00_VERIFICA_LVI_SECTION();

                /*" -677- IF SIDOCACO-COD-EVENTO NOT EQUAL 2012 AND 2013 */

                if (!SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO.In("2012", "2013"))
                {

                    /*" -679- MOVE 'N' TO WS-REITERA-LVI. */
                    _.Move("N", AREA_DE_WORK.WS_REITERA_LVI);
                }

            }


            /*" -681- MOVE ZEROS TO IX1 */
            _.Move(0, IX1);

            /*" -683- MOVE H-SIDOCACO-NUM-CARTA TO WS-CARTA-ANT */
            _.Move(H_SIDOCACO_NUM_CARTA, WS_CARTA_ANT);

            /*" -694- PERFORM R3000-00-PROCESSA-CARTA UNTIL WFIM-JOIN NOT EQUAL SPACES OR H-SIDOCACO-COD-FONTE NOT EQUAL WS-FONTE-ANT OR H-SIDOCACO-NUM-PROTOCOLO-SINI NOT EQUAL WS-PROTOCOLO-ANT OR H-SIDOCACO-DAC-PROTOCOLO-SINI NOT EQUAL WS-DAC-ANT OR H-SIDOCACO-NUM-CARTA NOT EQUAL WS-CARTA-ANT */

            while (!(!AREA_DE_WORK.WFIM_JOIN.IsEmpty() || H_SIDOCACO_COD_FONTE != WS_FONTE_ANT || H_SIDOCACO_NUM_PROTOCOLO_SINI != WS_PROTOCOLO_ANT || H_SIDOCACO_DAC_PROTOCOLO_SINI != WS_DAC_ANT || H_SIDOCACO_NUM_CARTA != WS_CARTA_ANT))
            {

                R3000_00_PROCESSA_CARTA_SECTION();
            }

            /*" -695- IF IX1 GREATER ZEROS */

            if (IX1 > 00)
            {

                /*" -695- PERFORM R4000-00-GERA-REITERACAO. */

                R4000_00_GERA_REITERACAO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-CARTA-PARAMETRO-SECTION */
        private void R2100_00_LE_CARTA_PARAMETRO_SECTION()
        {
            /*" -705- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -715- PERFORM R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1 */

            R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1();

            /*" -720- PERFORM R1234-DEPURAR THRU R1234-99-SAIDA */

            R1234_DEPURAR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/


            /*" -721- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -722- DISPLAY 'SI0031B - PROBLEMAS NO SELECT GE_CARTA_PARAMETRO' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT GE_CARTA_PARAMETRO");

                /*" -725- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -731- DISPLAY ' ' SIDOCPAR-COD-TIPO-CARTA ' ' H-SIDOCACO-NUM-CARTA ' ' H-SIDOCACO-COD-PRODUTO ' ' SIMOVSIN-COD-ESTIPULANTE ' ' H-SIDOCACO-DATA-MOVTO-DOCACO ' ' SISTEMAS-DATA-MOV-ABERTO */

                $" {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA} {H_SIDOCACO_NUM_CARTA} {H_SIDOCACO_COD_PRODUTO} {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE} {H_SIDOCACO_DATA_MOVTO_DOCACO} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -731- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-CARTA-PARAMETRO-DB-SELECT-1 */
        public void R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1()
        {
            /*" -715- EXEC SQL SELECT DISTINCT PRAZO_REITERACAO INTO :GECARPAR-PRAZO-REITERACAO FROM SEGUROS.GE_CARTA_PARAMETRO WHERE COD_TIPO_CARTA = :SIDOCPAR-COD-TIPO-CARTA AND COD_PRODUTO = :H-SIDOCACO-COD-PRODUTO AND COD_CLIENTE = :SIMOVSIN-COD-ESTIPULANTE AND DATA_INIVIG_CARPAR <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIG_CARPAR >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY PRAZO_REITERACAO END-EXEC. */

            var r2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1 = new R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1()
            {
                SIMOVSIN_COD_ESTIPULANTE = SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SIDOCPAR_COD_TIPO_CARTA = SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA.ToString(),
                H_SIDOCACO_COD_PRODUTO = H_SIDOCACO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1.Execute(r2100_00_LE_CARTA_PARAMETRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARPAR_PRAZO_REITERACAO, GECARPAR.DCLGE_CARTA_PARAMETRO.GECARPAR_PRAZO_REITERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-LE-EVENTO-TIPO-SECTION */
        private void R2200_00_LE_EVENTO_TIPO_SECTION()
        {
            /*" -741- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -748- PERFORM R2200_00_LE_EVENTO_TIPO_DB_SELECT_1 */

            R2200_00_LE_EVENTO_TIPO_DB_SELECT_1();

            /*" -753- PERFORM R1234-DEPURAR THRU R1234-99-SAIDA */

            R1234_DEPURAR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/


            /*" -754- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -755- DISPLAY 'SI0031B - PROBLEMAS NO SELECT SI_EVENTO_TIPO' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT SI_EVENTO_TIPO");

                /*" -758- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -763- DISPLAY ' ' SIDOCPAR-COD-TIPO-CARTA ' ' H-SIDOCACO-NUM-CARTA ' ' H-SIDOCACO-COD-PRODUTO ' ' SIMOVSIN-COD-ESTIPULANTE ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                $" {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA} {H_SIDOCACO_NUM_CARTA} {H_SIDOCACO_COD_PRODUTO} {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                .Display();

                /*" -763- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-LE-EVENTO-TIPO-DB-SELECT-1 */
        public void R2200_00_LE_EVENTO_TIPO_DB_SELECT_1()
        {
            /*" -748- EXEC SQL SELECT COD_EVENTO, IND_SINISTRO_ACOMP INTO :SIEVETIP-COD-EVENTO, :SIEVETIP-IND-SINISTRO-ACOMP FROM SEGUROS.SI_EVENTO_TIPO WHERE COD_TIPO_CARTA = :SIDOCPAR-COD-TIPO-CARTA END-EXEC. */

            var r2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1 = new R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1()
            {
                SIDOCPAR_COD_TIPO_CARTA = SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA.ToString(),
            };

            var executed_1 = R2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1.Execute(r2200_00_LE_EVENTO_TIPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIEVETIP_COD_EVENTO, SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_COD_EVENTO);
                _.Move(executed_1.SIEVETIP_IND_SINISTRO_ACOMP, SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_IND_SINISTRO_ACOMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-LIMPA-TABELA-SECTION */
        private void R2300_00_LIMPA_TABELA_SECTION()
        {
            /*" -773- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -773- MOVE 1 TO IX1. */
            _.Move(1, IX1);

            /*" -0- FLUXCONTROL_PERFORM R2300_10_LOOP */

            R2300_10_LOOP();

        }

        [StopWatch]
        /*" R2300-10-LOOP */
        private void R2300_10_LOOP(bool isPerform = false)
        {
            /*" -778- IF IX1 NOT GREATER 50 */

            if (IX1 <= 50)
            {

                /*" -784- MOVE ZEROS TO TAB-COD-DOCUMENTO(IX1) TAB-NUM-OCORR-DOCACO(IX1) TAB-COD-PRODUTO(IX1) TAB-COD-GRUPO-CAUSA(IX1) TAB-COD-SUBGRUPO-CAUSA(IX1) */
                _.Move(0, TAB_DADOS[IX1].TAB_COD_DOCUMENTO, TAB_DADOS[IX1].TAB_NUM_OCORR_DOCACO, TAB_DADOS[IX1].TAB_COD_PRODUTO, TAB_DADOS[IX1].TAB_COD_GRUPO_CAUSA, TAB_DADOS[IX1].TAB_COD_SUBGRUPO_CAUSA);

                /*" -786- MOVE SPACES TO TAB-DATA-INIVIG-DOCPAR(IX1) */
                _.Move("", TAB_DADOS[IX1].TAB_DATA_INIVIG_DOCPAR);

                /*" -787- ADD 1 TO IX1 */
                IX1.Value = IX1 + 1;

                /*" -787- GO TO R2300-10-LOOP. */
                new Task(() => R2300_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-VERIFICA-LVI-SECTION */
        private void R2400_00_VERIFICA_LVI_SECTION()
        {
            /*" -797- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -814- PERFORM R2400_00_VERIFICA_LVI_DB_SELECT_1 */

            R2400_00_VERIFICA_LVI_DB_SELECT_1();

            /*" -817- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -818- DISPLAY 'SI0031B - PROBLEMAS NO SELECT SI_DOCUMENTO_ACOMP' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT SI_DOCUMENTO_ACOMP");

                /*" -821- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -821- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-VERIFICA-LVI-DB-SELECT-1 */
        public void R2400_00_VERIFICA_LVI_DB_SELECT_1()
        {
            /*" -814- EXEC SQL SELECT A.COD_EVENTO INTO :SIDOCACO-COD-EVENTO FROM SEGUROS.SI_DOCUMENTO_ACOMP A WHERE A.COD_FONTE = :H-SIDOCACO-COD-FONTE AND A.NUM_PROTOCOLO_SINI = :H-SIDOCACO-NUM-PROTOCOLO-SINI AND A.DAC_PROTOCOLO_SINI = :H-SIDOCACO-DAC-PROTOCOLO-SINI AND A.COD_DOCUMENTO = 27 AND A.NUM_OCORR_DOCACO = (SELECT MAX(B.NUM_OCORR_DOCACO) FROM SEGUROS.SI_DOCUMENTO_ACOMP B WHERE A.COD_FONTE = B.COD_FONTE AND A.NUM_PROTOCOLO_SINI = B.NUM_PROTOCOLO_SINI AND A.DAC_PROTOCOLO_SINI = B.DAC_PROTOCOLO_SINI AND A.COD_DOCUMENTO = B.COD_DOCUMENTO) END-EXEC. */

            var r2400_00_VERIFICA_LVI_DB_SELECT_1_Query1 = new R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1()
            {
                H_SIDOCACO_NUM_PROTOCOLO_SINI = H_SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                H_SIDOCACO_DAC_PROTOCOLO_SINI = H_SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                H_SIDOCACO_COD_FONTE = H_SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R2400_00_VERIFICA_LVI_DB_SELECT_1_Query1.Execute(r2400_00_VERIFICA_LVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIDOCACO_COD_EVENTO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-CARTA-SECTION */
        private void R3000_00_PROCESSA_CARTA_SECTION()
        {
            /*" -831- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -832- IF SISINFAS-COD-FASE EQUAL 3 OR 4 */

            if (SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE.In("3", "4"))
            {

                /*" -853- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

                if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
                {

                    /*" -854- DISPLAY 'DESPREZADA DEVIDO FASE: ' SISINFAS-COD-FASE */
                    _.Display($"DESPREZADA DEVIDO FASE: {SISINFAS.DCLSI_SINISTRO_FASE.SISINFAS_COD_FASE}");

                    /*" -856- ADD 1 TO AC-DESPREZA-FASE */
                    AREA_DE_WORK.AC_DESPREZA_FASE.Value = AREA_DE_WORK.AC_DESPREZA_FASE + 1;

                    /*" -868- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-NUM-OCORR-DOCACO ' ' H-SIDOCACO-COD-PRODUTO ' ' H-SIDOCACO-COD-GRUPO-CAUSA ' ' H-SIDOCACO-COD-SUBGRUPO-CAUSA ' ' H-SIDOCACO-DATA-INIVIG-DOCPAR ' ' H-SIDOCACO-DATA-MOVTO-DOCACO ' ' H-SIDOCACO-NUM-CARTA ' ' SIDOCPAR-COD-TIPO-CARTA */

                    $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_NUM_OCORR_DOCACO} {H_SIDOCACO_COD_PRODUTO} {H_SIDOCACO_COD_GRUPO_CAUSA} {H_SIDOCACO_COD_SUBGRUPO_CAUSA} {H_SIDOCACO_DATA_INIVIG_DOCPAR} {H_SIDOCACO_DATA_MOVTO_DOCACO} {H_SIDOCACO_NUM_CARTA} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA}"
                    .Display();

                    /*" -869- END-IF */
                }


                /*" -870- ADD 1 TO AC-IGNORADO */
                AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                /*" -881- GO TO R3000-10-LER. */

                R3000_10_LER(); //GOTO
                return;
            }


            /*" -883- IF H-SIDOCACO-COD-DOCUMENTO EQUAL 38 */

            if (H_SIDOCACO_COD_DOCUMENTO == 38)
            {

                /*" -884- PERFORM R3300-00-CONTA-SIDOCACO */

                R3300_00_CONTA_SIDOCACO_SECTION();

                /*" -885- IF HOST-COUNT NOT EQUAL 0 */

                if (HOST_COUNT != 0)
                {

                    /*" -886- ADD 1 TO AC-MEDICO */
                    AREA_DE_WORK.AC_MEDICO.Value = AREA_DE_WORK.AC_MEDICO + 1;

                    /*" -894- DISPLAY 'PARECER MEDICO NAO REITERADO...' ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIDOCPAR-COD-TIPO-CARTA ' ' H-SIDOCACO-NUM-CARTA ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                    $"PARECER MEDICO NAO REITERADO... {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA} {H_SIDOCACO_NUM_CARTA} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                    .Display();

                    /*" -895- ADD 1 TO AC-IGNORADO */
                    AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                    /*" -900- GO TO R3000-10-LER. */

                    R3000_10_LER(); //GOTO
                    return;
                }

            }


            /*" -902- PERFORM R3400-00-LE-CARTA-ACOMP */

            R3400_00_LE_CARTA_ACOMP_SECTION();

            /*" -905- IF SQLCODE EQUAL 100 OR GECARACO-COD-EVENTO EQUAL SIEVETIP-COD-EVENTO */

            if (DB.SQLCODE == 100 || GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_EVENTO == SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_COD_EVENTO)
            {

                /*" -911- DISPLAY 'CARTA NAO ENVIADA...' ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIDOCPAR-COD-TIPO-CARTA ' ' H-SIDOCACO-NUM-CARTA */

                $"CARTA NAO ENVIADA... {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA} {H_SIDOCACO_NUM_CARTA}"
                .Display();

                /*" -912- ADD 1 TO AC-CARTA */
                AREA_DE_WORK.AC_CARTA.Value = AREA_DE_WORK.AC_CARTA + 1;

                /*" -913- ADD 1 TO AC-IGNORADO */
                AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                /*" -915- GO TO R3000-10-LER. */

                R3000_10_LER(); //GOTO
                return;
            }


            /*" -916- IF WS-REITERA-LVI EQUAL 'N' */

            if (AREA_DE_WORK.WS_REITERA_LVI == "N")
            {

                /*" -924- DISPLAY 'REITERACAO DESPREZADA - LVI NAO-PENDENTE...' ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' SIDOCPAR-COD-TIPO-CARTA ' ' H-SIDOCACO-NUM-CARTA ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                $"REITERACAO DESPREZADA - LVI NAO-PENDENTE... {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA} {H_SIDOCACO_NUM_CARTA} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                .Display();

                /*" -925- ADD 1 TO AC-LVI */
                AREA_DE_WORK.AC_LVI.Value = AREA_DE_WORK.AC_LVI + 1;

                /*" -926- ADD 1 TO AC-IGNORADO */
                AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                /*" -937- GO TO R3000-10-LER. */

                R3000_10_LER(); //GOTO
                return;
            }


            /*" -938- MOVE 0 TO GECARTA-SEQ-CARTA-REITERA. */
            _.Move(0, GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA);

            /*" -939- IF SIDOCPAR-COD-TIPO-CARTA = 2 */

            if (SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2)
            {

                /*" -946- PERFORM R4210-00-TRAZ-SEQ-REITERA. */

                R4210_00_TRAZ_SEQ_REITERA_SECTION();
            }


            /*" -948- IF GECARTA-SEQ-CARTA-REITERA >= 4 AND SIDOCPAR-COD-TIPO-CARTA = 2 */

            if (GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA >= 4 && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2)
            {

                /*" -969- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

                if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
                {

                    /*" -970- DISPLAY 'DESPREZADA DEVIDO SEQUENCIA: ' */
                    _.Display($"DESPREZADA DEVIDO SEQUENCIA: ");

                    /*" -972- DISPLAY GECARTA-SEQ-CARTA-REITERA */
                    _.Display(GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA);

                    /*" -984- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-NUM-OCORR-DOCACO ' ' H-SIDOCACO-COD-PRODUTOV.08 ' ' H-SIDOCACO-COD-GRUPO-CAUSA ' ' H-SIDOCACO-COD-SUBGRUPO-CAUSA ' ' H-SIDOCACO-DATA-INIVIG-DOCPAR ' ' H-SIDOCACO-DATA-MOVTO-DOCACO ' ' H-SIDOCACO-NUM-CARTA ' ' SIDOCPAR-COD-TIPO-CARTA */

                    $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_NUM_OCORR_DOCACO} H-SIDOCACO-COD-PRODUTOV.08 {H_SIDOCACO_COD_GRUPO_CAUSA} {H_SIDOCACO_COD_SUBGRUPO_CAUSA} {H_SIDOCACO_DATA_INIVIG_DOCPAR} {H_SIDOCACO_DATA_MOVTO_DOCACO} {H_SIDOCACO_NUM_CARTA} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA}"
                    .Display();

                    /*" -985- ADD 1 TO AC-SEQ */
                    AREA_DE_WORK.AC_SEQ.Value = AREA_DE_WORK.AC_SEQ + 1;

                    /*" -987- END-IF */
                }


                /*" -988- ADD 1 TO AC-IGNORADO */
                AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                /*" -990- GO TO R3000-10-LER. */

                R3000_10_LER(); //GOTO
                return;
            }


            /*" -992- IF GECARPAR-PRAZO-REITERACAO NOT EQUAL ZEROS */

            if (GECARPAR.DCLGE_CARTA_PARAMETRO.GECARPAR_PRAZO_REITERACAO != 00)
            {

                /*" -993- PERFORM R3100-00-OBTEM-DIAS-DECORRIDOS */

                R3100_00_OBTEM_DIAS_DECORRIDOS_SECTION();

                /*" -995- IF GECARPAR-PRAZO-REITERACAO NOT GREATER HOST-COUNT */

                if (GECARPAR.DCLGE_CARTA_PARAMETRO.GECARPAR_PRAZO_REITERACAO <= HOST_COUNT)
                {

                    /*" -996- PERFORM R3200-00-SALVA-DOCUMENTO */

                    R3200_00_SALVA_DOCUMENTO_SECTION();

                    /*" -997- GO TO R3000-10-LER */

                    R3000_10_LER(); //GOTO
                    return;

                    /*" -998- END-IF */
                }


                /*" -1000- END-IF. */
            }


            /*" -1000- ADD 1 TO AC-IGNORADO. */
            AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LER */

            R3000_10_LER();

        }

        [StopWatch]
        /*" R3000-10-LER */
        private void R3000_10_LER(bool isPerform = false)
        {
            /*" -1004- PERFORM R0910-00-LE-JOIN. */

            R0910_00_LE_JOIN_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-OBTEM-DIAS-DECORRIDOS-SECTION */
        private void R3100_00_OBTEM_DIAS_DECORRIDOS_SECTION()
        {
            /*" -1016- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1023- PERFORM R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1 */

            R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1();

            /*" -1026- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1027- DISPLAY 'SI0031B - PROBLEMAS NO SELECT CALENDARIO' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT CALENDARIO");

                /*" -1030- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI}"
                .Display();

                /*" -1032- DISPLAY ' ' H-SIDOCACO-DATA-MOVTO-DOCACO ' ' SISTEMAS-DATA-MOV-ABERTO */

                $" {H_SIDOCACO_DATA_MOVTO_DOCACO} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -1032- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-OBTEM-DIAS-DECORRIDOS-DB-SELECT-1 */
        public void R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1()
        {
            /*" -1023- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :H-SIDOCACO-DATA-MOVTO-DOCACO AND DATA_CALENDARIO <= :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */

            var r3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1 = new R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1()
            {
                H_SIDOCACO_DATA_MOVTO_DOCACO = H_SIDOCACO_DATA_MOVTO_DOCACO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1.Execute(r3100_00_OBTEM_DIAS_DECORRIDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-SALVA-DOCUMENTO-SECTION */
        private void R3200_00_SALVA_DOCUMENTO_SECTION()
        {
            /*" -1042- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1062- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1063- DISPLAY 'SALVOU NA TABELA TEMPORARIA' */
                _.Display($"SALVOU NA TABELA TEMPORARIA");

                /*" -1065- DISPLAY 'WNR-EXEC-SQL......: ' WNR-EXEC-SQL */
                _.Display($"WNR-EXEC-SQL......: {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -1077- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-NUM-OCORR-DOCACO ' ' H-SIDOCACO-COD-PRODUTO ' ' H-SIDOCACO-COD-GRUPO-CAUSA ' ' H-SIDOCACO-COD-SUBGRUPO-CAUSA ' ' H-SIDOCACO-DATA-INIVIG-DOCPAR ' ' H-SIDOCACO-DATA-MOVTO-DOCACO ' ' H-SIDOCACO-NUM-CARTA ' ' SIDOCPAR-COD-TIPO-CARTA */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_NUM_OCORR_DOCACO} {H_SIDOCACO_COD_PRODUTO} {H_SIDOCACO_COD_GRUPO_CAUSA} {H_SIDOCACO_COD_SUBGRUPO_CAUSA} {H_SIDOCACO_DATA_INIVIG_DOCPAR} {H_SIDOCACO_DATA_MOVTO_DOCACO} {H_SIDOCACO_NUM_CARTA} {SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA}"
                .Display();

                /*" -1078- ADD 1 TO AC-TEMP-AUX */
                AREA_DE_WORK.AC_TEMP_AUX.Value = AREA_DE_WORK.AC_TEMP_AUX + 1;

                /*" -1080- END-IF */
            }


            /*" -1081- ADD 1 TO AC-TAB-TEMP */
            AREA_DE_WORK.AC_TAB_TEMP.Value = AREA_DE_WORK.AC_TAB_TEMP + 1;

            /*" -1083- ADD 1 TO IX1 */
            IX1.Value = IX1 + 1;

            /*" -1085- MOVE H-SIDOCACO-COD-DOCUMENTO TO TAB-COD-DOCUMENTO(IX1) */
            _.Move(H_SIDOCACO_COD_DOCUMENTO, TAB_DADOS[IX1].TAB_COD_DOCUMENTO);

            /*" -1087- MOVE H-SIDOCACO-NUM-OCORR-DOCACO TO TAB-NUM-OCORR-DOCACO(IX1) */
            _.Move(H_SIDOCACO_NUM_OCORR_DOCACO, TAB_DADOS[IX1].TAB_NUM_OCORR_DOCACO);

            /*" -1089- MOVE H-SIDOCACO-COD-PRODUTO TO TAB-COD-PRODUTO(IX1) */
            _.Move(H_SIDOCACO_COD_PRODUTO, TAB_DADOS[IX1].TAB_COD_PRODUTO);

            /*" -1091- MOVE H-SIDOCACO-COD-GRUPO-CAUSA TO TAB-COD-GRUPO-CAUSA(IX1) */
            _.Move(H_SIDOCACO_COD_GRUPO_CAUSA, TAB_DADOS[IX1].TAB_COD_GRUPO_CAUSA);

            /*" -1094- MOVE H-SIDOCACO-COD-SUBGRUPO-CAUSA TO TAB-COD-SUBGRUPO-CAUSA(IX1) */
            _.Move(H_SIDOCACO_COD_SUBGRUPO_CAUSA, TAB_DADOS[IX1].TAB_COD_SUBGRUPO_CAUSA);

            /*" -1096- MOVE H-SIDOCACO-DATA-INIVIG-DOCPAR TO TAB-DATA-INIVIG-DOCPAR(IX1). */
            _.Move(H_SIDOCACO_DATA_INIVIG_DOCPAR, TAB_DADOS[IX1].TAB_DATA_INIVIG_DOCPAR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-CONTA-SIDOCACO-SECTION */
        private void R3300_00_CONTA_SIDOCACO_SECTION()
        {
            /*" -1106- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1119- PERFORM R3300_00_CONTA_SIDOCACO_DB_SELECT_1 */

            R3300_00_CONTA_SIDOCACO_DB_SELECT_1();

            /*" -1122- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1123- DISPLAY 'SI0031B - PROBLEMAS NO COUNT SI_DOCUMENTO_ACOMP' */
                _.Display($"SI0031B - PROBLEMAS NO COUNT SI_DOCUMENTO_ACOMP");

                /*" -1128- DISPLAY ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' H-SIDOCACO-COD-DOCUMENTO ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                $" {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {H_SIDOCACO_COD_DOCUMENTO} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                .Display();

                /*" -1128- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3300-00-CONTA-SIDOCACO-DB-SELECT-1 */
        public void R3300_00_CONTA_SIDOCACO_DB_SELECT_1()
        {
            /*" -1119- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.SI_DOCUMENTO_ACOMP WHERE COD_FONTE = :H-SIDOCACO-COD-FONTE AND NUM_PROTOCOLO_SINI = :H-SIDOCACO-NUM-PROTOCOLO-SINI AND DAC_PROTOCOLO_SINI = :H-SIDOCACO-DAC-PROTOCOLO-SINI AND DATA_MOVTO_DOCACO > :H-SIDOCACO-DATA-MOVTO-DOCACO AND COD_DOCUMENTO IN (50, 17, 46, 42, 37) AND NUM_OCORR_DOCACO = 1 END-EXEC. */

            var r3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1 = new R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1()
            {
                H_SIDOCACO_NUM_PROTOCOLO_SINI = H_SIDOCACO_NUM_PROTOCOLO_SINI.ToString(),
                H_SIDOCACO_DAC_PROTOCOLO_SINI = H_SIDOCACO_DAC_PROTOCOLO_SINI.ToString(),
                H_SIDOCACO_DATA_MOVTO_DOCACO = H_SIDOCACO_DATA_MOVTO_DOCACO.ToString(),
                H_SIDOCACO_COD_FONTE = H_SIDOCACO_COD_FONTE.ToString(),
            };

            var executed_1 = R3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1.Execute(r3300_00_CONTA_SIDOCACO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-LE-CARTA-ACOMP-SECTION */
        private void R3400_00_LE_CARTA_ACOMP_SECTION()
        {
            /*" -1138- MOVE '340' TO WNR-EXEC-SQL. */
            _.Move("340", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1147- PERFORM R3400_00_LE_CARTA_ACOMP_DB_SELECT_1 */

            R3400_00_LE_CARTA_ACOMP_DB_SELECT_1();

            /*" -1152- PERFORM R1234-DEPURAR THRU R1234-99-SAIDA */

            R1234_DEPURAR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1234_99_SAIDA*/


            /*" -1153- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -1158- DISPLAY 'SI0031B - PROBLEMAS NO SELECT GE_CARTA_ACOMP' ' ' H-SIDOCACO-COD-FONTE ' ' H-SIDOCACO-NUM-PROTOCOLO-SINI ' ' H-SIDOCACO-DAC-PROTOCOLO-SINI ' ' WS-CARTA-ANT */

                $"SI0031B - PROBLEMAS NO SELECT GE_CARTA_ACOMP {H_SIDOCACO_COD_FONTE} {H_SIDOCACO_NUM_PROTOCOLO_SINI} {H_SIDOCACO_DAC_PROTOCOLO_SINI} {WS_CARTA_ANT}"
                .Display();

                /*" -1158- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3400-00-LE-CARTA-ACOMP-DB-SELECT-1 */
        public void R3400_00_LE_CARTA_ACOMP_DB_SELECT_1()
        {
            /*" -1147- EXEC SQL SELECT A.COD_EVENTO INTO :GECARACO-COD-EVENTO FROM SEGUROS.GE_CARTA_ACOMP A WHERE A.NUM_CARTA = :WS-CARTA-ANT AND A.NUM_OCORR_CARTACO = (SELECT MAX(B.NUM_OCORR_CARTACO) FROM SEGUROS.GE_CARTA_ACOMP B WHERE B.NUM_CARTA = :WS-CARTA-ANT) END-EXEC. */

            var r3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1 = new R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1()
            {
                WS_CARTA_ANT = WS_CARTA_ANT.ToString(),
            };

            var executed_1 = R3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1.Execute(r3400_00_LE_CARTA_ACOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARACO_COD_EVENTO, GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_EVENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-GERA-REITERACAO-SECTION */
        private void R4000_00_GERA_REITERACAO_SECTION()
        {
            /*" -1168- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1170- PERFORM R4050-00-LE-CARTA-DEST */

            R4050_00_LE_CARTA_DEST_SECTION();

            /*" -1171- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1177- DISPLAY 'CARTA SEM DESTINATARIO...' ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT */

                $"CARTA SEM DESTINATARIO... {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT}"
                .Display();

                /*" -1178- ADD 1 TO AC-SEM-DEST */
                AREA_DE_WORK.AC_SEM_DEST.Value = AREA_DE_WORK.AC_SEM_DEST + 1;

                /*" -1179- ADD 1 TO AC-IGNORADO */
                AREA_DE_WORK.AC_IGNORADO.Value = AREA_DE_WORK.AC_IGNORADO + 1;

                /*" -1181- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1186- PERFORM R4100-00-LE-CARTA */

            R4100_00_LE_CARTA_SECTION();

            /*" -1188- PERFORM R4150-00-LE-ANALISTA */

            R4150_00_LE_ANALISTA_SECTION();

            /*" -1189- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1191- IF GECARTA-COD-USUARIO NOT EQUAL SIANAROD-COD-USUARIO */

                if (GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO != SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO)
                {

                    /*" -1198- DISPLAY 'MUDOU ANALISTA DE ' GECARTA-COD-USUARIO ' PARA ' SIANAROD-COD-USUARIO ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT */

                    $"MUDOU ANALISTA DE {GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO} PARA {SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO} {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT}"
                    .Display();

                    /*" -1201- MOVE SIANAROD-COD-USUARIO TO GECARTA-COD-USUARIO. */
                    _.Move(SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO, GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO);
                }

            }


            /*" -1203- PERFORM R4200-00-LE-CARTA-TEXTO */

            R4200_00_LE_CARTA_TEXTO_SECTION();

            /*" -1204- PERFORM R4300-00-INCLUI-CARTA */

            R4300_00_INCLUI_CARTA_SECTION();

            /*" -1206- PERFORM R4400-00-INCLUI-CARTA-ACOMP */

            R4400_00_INCLUI_CARTA_ACOMP_SECTION();

            /*" -1208- IF SIEVETIP-IND-SINISTRO-ACOMP EQUAL 'S' */

            if (SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_IND_SINISTRO_ACOMP == "S")
            {

                /*" -1210- PERFORM R4500-00-INCLUI-SINISTRO-ACOMP. */

                R4500_00_INCLUI_SINISTRO_ACOMP_SECTION();
            }


            /*" -1212- IF GECARTEX-TEXTO-CARTA NOT EQUAL SPACES */

            if (!GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.IsEmpty())
            {

                /*" -1214- PERFORM R4600-00-INCLUI-CARTA-TEXTO. */

                R4600_00_INCLUI_CARTA_TEXTO_SECTION();
            }


            /*" -1216- MOVE SPACES TO WFIM-CARTA-DEST WS-NOME */
            _.Move("", AREA_DE_WORK.WFIM_CARTA_DEST, WS_NOME);

            /*" -1217- PERFORM R4700-00-DECLARA-CARTA-DEST. */

            R4700_00_DECLARA_CARTA_DEST_SECTION();

            /*" -1219- PERFORM R4800-00-LE-CARTA-DEST. */

            R4800_00_LE_CARTA_DEST_SECTION();

            /*" -1226- PERFORM R4900-00-INCLUI-CARTA-DEST UNTIL WFIM-CARTA-DEST EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CARTA_DEST == "S"))
            {

                R4900_00_INCLUI_CARTA_DEST_SECTION();
            }

            /*" -1227- IF WS-TIPO-CARTA-ANT EQUAL 2 */

            if (WS_TIPO_CARTA_ANT == 2)
            {

                /*" -1228- IF WS-NOME-5 EQUAL 'GIPRO' */

                if (WS_NOME.WS_NOME_5 == "GIPRO")
                {

                    /*" -1234- DISPLAY 'COPIA PARA GEHAB...' ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT */

                    $"COPIA PARA GEHAB... {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT}"
                    .Display();

                    /*" -1235- MOVE 304 TO GERECADE-COD-DESTINATARIO */
                    _.Move(304, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO);

                    /*" -1241- MOVE 'N' TO GERECADE-IND-DEST-PRINC */
                    _.Move("N", GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC);

                    /*" -1242- ELSE */
                }
                else
                {


                    /*" -1243- IF WS-NOME-5 EQUAL 'GITER' */

                    if (WS_NOME.WS_NOME_5 == "GITER")
                    {

                        /*" -1244- MOVE 306 TO GERECADE-COD-DESTINATARIO */
                        _.Move(306, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO);

                        /*" -1245- MOVE 'N' TO GERECADE-IND-DEST-PRINC */
                        _.Move("N", GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC);

                        /*" -1246- PERFORM R4950-00-CHAMA-PTDESTAS */

                        R4950_00_CHAMA_PTDESTAS_SECTION();

                        /*" -1247- END-IF */
                    }


                    /*" -1248- END-IF */
                }


                /*" -1250- END-IF. */
            }


            /*" -1250- PERFORM R5000-00-PROCESSA-DOCUMENTOS. */

            R5000_00_PROCESSA_DOCUMENTOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4050-00-LE-CARTA-DEST-SECTION */
        private void R4050_00_LE_CARTA_DEST_SECTION()
        {
            /*" -1260- MOVE '405' TO WNR-EXEC-SQL. */
            _.Move("405", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1266- PERFORM R4050_00_LE_CARTA_DEST_DB_SELECT_1 */

            R4050_00_LE_CARTA_DEST_DB_SELECT_1();

            /*" -1269- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1270- DISPLAY 'SI0031B - PROBLEMAS NO SELECT GE_REL_CARTA_DEST' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT GE_REL_CARTA_DEST");

                /*" -1275- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT}"
                .Display();

                /*" -1275- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4050-00-LE-CARTA-DEST-DB-SELECT-1 */
        public void R4050_00_LE_CARTA_DEST_DB_SELECT_1()
        {
            /*" -1266- EXEC SQL SELECT COD_DESTINATARIO INTO :GERECADE-COD-DESTINATARIO FROM SEGUROS.GE_REL_CARTA_DEST WHERE NUM_CARTA = :WS-CARTA-ANT AND IND_DEST_PRINC = 'S' END-EXEC. */

            var r4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1 = new R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1()
            {
                WS_CARTA_ANT = WS_CARTA_ANT.ToString(),
            };

            var executed_1 = R4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1.Execute(r4050_00_LE_CARTA_DEST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GERECADE_COD_DESTINATARIO, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-LE-CARTA-SECTION */
        private void R4100_00_LE_CARTA_SECTION()
        {
            /*" -1285- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1290- PERFORM R4100_00_LE_CARTA_DB_SELECT_1 */

            R4100_00_LE_CARTA_DB_SELECT_1();

            /*" -1293- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1294- DISPLAY 'SI0031B - PROBLEMAS NO SELECT GE_CARTA' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT GE_CARTA");

                /*" -1302- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT ' ' H-SIDOCACO-COD-PRODUTO ' ' SIMOVSIN-COD-ESTIPULANTE ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT} {H_SIDOCACO_COD_PRODUTO} {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                .Display();

                /*" -1302- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4100-00-LE-CARTA-DB-SELECT-1 */
        public void R4100_00_LE_CARTA_DB_SELECT_1()
        {
            /*" -1290- EXEC SQL SELECT COD_USUARIO INTO :GECARTA-COD-USUARIO FROM SEGUROS.GE_CARTA WHERE NUM_CARTA = :WS-CARTA-ANT END-EXEC. */

            var r4100_00_LE_CARTA_DB_SELECT_1_Query1 = new R4100_00_LE_CARTA_DB_SELECT_1_Query1()
            {
                WS_CARTA_ANT = WS_CARTA_ANT.ToString(),
            };

            var executed_1 = R4100_00_LE_CARTA_DB_SELECT_1_Query1.Execute(r4100_00_LE_CARTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARTA_COD_USUARIO, GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-LE-ANALISTA-SECTION */
        private void R4150_00_LE_ANALISTA_SECTION()
        {
            /*" -1312- MOVE '415' TO WNR-EXEC-SQL. */
            _.Move("415", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1319- PERFORM R4150_00_LE_ANALISTA_DB_SELECT_1 */

            R4150_00_LE_ANALISTA_DB_SELECT_1();

            /*" -1322- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1323- DISPLAY 'SI0031B - PROBLEMAS NO SELECT SI_ANALISTA_RODIZI' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT SI_ANALISTA_RODIZI");

                /*" -1331- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT ' ' H-SIDOCACO-COD-PRODUTO ' ' SIMOVSIN-COD-ESTIPULANTE ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT} {H_SIDOCACO_COD_PRODUTO} {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                .Display();

                /*" -1331- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4150-00-LE-ANALISTA-DB-SELECT-1 */
        public void R4150_00_LE_ANALISTA_DB_SELECT_1()
        {
            /*" -1319- EXEC SQL SELECT COD_USUARIO INTO :SIANAROD-COD-USUARIO FROM SEGUROS.SI_ANALISTA_RODIZI WHERE COD_FONTE = :WS-FONTE-ANT AND NUM_PROTOCOLO_SINI = :WS-PROTOCOLO-ANT AND DAC_PROTOCOLO_SINI = :WS-DAC-ANT END-EXEC. */

            var r4150_00_LE_ANALISTA_DB_SELECT_1_Query1 = new R4150_00_LE_ANALISTA_DB_SELECT_1_Query1()
            {
                WS_PROTOCOLO_ANT = WS_PROTOCOLO_ANT.ToString(),
                WS_FONTE_ANT = WS_FONTE_ANT.ToString(),
                WS_DAC_ANT = WS_DAC_ANT.ToString(),
            };

            var executed_1 = R4150_00_LE_ANALISTA_DB_SELECT_1_Query1.Execute(r4150_00_LE_ANALISTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIANAROD_COD_USUARIO, SIANAROD.DCLSI_ANALISTA_RODIZI.SIANAROD_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-LE-CARTA-TEXTO-SECTION */
        private void R4200_00_LE_CARTA_TEXTO_SECTION()
        {
            /*" -1341- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1342- MOVE 3200 TO GECARTEX-TEXTO-CARTA-LEN. */
            _.Move(3200, GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA.GECARTEX_TEXTO_CARTA_LEN);

            /*" -1344- MOVE SPACES TO GECARTEX-TEXTO-CARTA. */
            _.Move("", GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA);

            /*" -1349- PERFORM R4200_00_LE_CARTA_TEXTO_DB_SELECT_1 */

            R4200_00_LE_CARTA_TEXTO_DB_SELECT_1();

            /*" -1352- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1353- MOVE SPACES TO GECARTEX-TEXTO-CARTA */
                _.Move("", GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA);

                /*" -1354- ELSE */
            }
            else
            {


                /*" -1355- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1356- DISPLAY 'SI0031B - PROBLEMAS NO SELECT GE_CARTA_TEXTO' */
                    _.Display($"SI0031B - PROBLEMAS NO SELECT GE_CARTA_TEXTO");

                    /*" -1364- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT ' ' H-SIDOCACO-COD-PRODUTO ' ' SIMOVSIN-COD-ESTIPULANTE ' ' H-SIDOCACO-DATA-MOVTO-DOCACO */

                    $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT} {H_SIDOCACO_COD_PRODUTO} {SIMOVSIN.DCLSI_MOVIMENTO_SINI.SIMOVSIN_COD_ESTIPULANTE} {H_SIDOCACO_DATA_MOVTO_DOCACO}"
                    .Display();

                    /*" -1364- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R4200-00-LE-CARTA-TEXTO-DB-SELECT-1 */
        public void R4200_00_LE_CARTA_TEXTO_DB_SELECT_1()
        {
            /*" -1349- EXEC SQL SELECT TEXTO_CARTA INTO :GECARTEX-TEXTO-CARTA FROM SEGUROS.GE_CARTA_TEXTO WHERE NUM_CARTA = :WS-CARTA-ANT END-EXEC. */

            var r4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1 = new R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1()
            {
                WS_CARTA_ANT = WS_CARTA_ANT.ToString(),
            };

            var executed_1 = R4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1.Execute(r4200_00_LE_CARTA_TEXTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARTEX_TEXTO_CARTA, GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_TEXTO_CARTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4210-00-TRAZ-SEQ-REITERA-SECTION */
        private void R4210_00_TRAZ_SEQ_REITERA_SECTION()
        {
            /*" -1374- MOVE '4210' TO WNR-EXEC-SQL. */
            _.Move("4210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1380- PERFORM R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1 */

            R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1();

            /*" -1383- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -1384- DISPLAY 'SI0031B - PROBLEMAS NO SELECT GE_CARTA - 4210' */
                _.Display($"SI0031B - PROBLEMAS NO SELECT GE_CARTA - 4210");

                /*" -1385- DISPLAY ' ' WS-CARTA-ANT */
                _.Display($" {WS_CARTA_ANT}");

                /*" -1387- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1390- COMPUTE GECARTA-SEQ-CARTA-REITERA = GECARTA-SEQ-CARTA-REITERA + 1 */
            GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA.Value = GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA + 1;

            /*" -1391- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1391- MOVE 0 TO GECARTA-SEQ-CARTA-REITERA. */
                _.Move(0, GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA);
            }


        }

        [StopWatch]
        /*" R4210-00-TRAZ-SEQ-REITERA-DB-SELECT-1 */
        public void R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1()
        {
            /*" -1380- EXEC SQL SELECT SEQ_CARTA_REITERA INTO :GECARTA-SEQ-CARTA-REITERA FROM SEGUROS.GE_CARTA WHERE NUM_CARTA = :WS-CARTA-ANT END-EXEC. */

            var r4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1 = new R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1()
            {
                WS_CARTA_ANT = WS_CARTA_ANT.ToString(),
            };

            var executed_1 = R4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1.Execute(r4210_00_TRAZ_SEQ_REITERA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GECARTA_SEQ_CARTA_REITERA, GECARTA.DCLGE_CARTA.GECARTA_SEQ_CARTA_REITERA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4210_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INCLUI-CARTA-SECTION */
        private void R4300_00_INCLUI_CARTA_SECTION()
        {
            /*" -1401- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1402- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -1403- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -1405- MOVE 'SI0031B' TO IN-USUARIO */
            _.Move("SI0031B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -1407- MOVE WS-CARTA-ANT TO GECARTA-NUM-CARTA-REITERA */
            _.Move(WS_CARTA_ANT, GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA_REITERA);

            /*" -1428- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1429- MOVE 'PTCARTAS' TO PROGRAMA */
                _.Move("PTCARTAS", AREA_DE_WORK.PROGRAMA);

                /*" -1431- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1436- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-CARTA-ANT */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_CARTA_ANT}"
                .Display();

                /*" -1438- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1440- END-IF */
            }


            /*" -1444- CALL 'PTCARTAS' USING PROTOCOLO-RECEBIDO DCLGE-CARTA PROTOCOLO-ENVIO */
            _.Call("PTCARTAS", LBWCT001.PROTOCOLO_RECEBIDO, GECARTA.DCLGE_CARTA, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1465- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1466- MOVE 'PTCARTAS' TO PROGRAMA */
                _.Move("PTCARTAS", AREA_DE_WORK.PROGRAMA);

                /*" -1468- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1473- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-CARTA-ANT */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_CARTA_ANT}"
                .Display();

                /*" -1475- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1477- END-IF */
            }


            /*" -1478- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -1480- DISPLAY '*** PROBLEMAS NA SUBROTINA PTCARTAS ***' */
                _.Display($"*** PROBLEMAS NA SUBROTINA PTCARTAS ***");

                /*" -1484- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-CARTA-ANT */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_CARTA_ANT}"
                .Display();

                /*" -1485- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1485- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-INCLUI-CARTA-ACOMP-SECTION */
        private void R4400_00_INCLUI_CARTA_ACOMP_SECTION()
        {
            /*" -1495- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1496- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -1497- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -1499- MOVE 'SI0031B' TO IN-USUARIO */
            _.Move("SI0031B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -1501- MOVE GECARTA-NUM-CARTA TO GECARACO-NUM-CARTA */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA, GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA);

            /*" -1503- MOVE SIEVETIP-COD-EVENTO TO GECARACO-COD-EVENTO */
            _.Move(SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_COD_EVENTO, GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_EVENTO);

            /*" -1506- MOVE SISTEMAS-DATA-MOV-ABERTO TO GECARACO-DATA-MOVTO-CARTACO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GECARACO.DCLGE_CARTA_ACOMP.GECARACO_DATA_MOVTO_CARTACO);

            /*" -1509- MOVE GECARTA-COD-USUARIO TO GECARACO-COD-USUARIO */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO, GECARACO.DCLGE_CARTA_ACOMP.GECARACO_COD_USUARIO);

            /*" -1530- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1531- MOVE 'PTACOMPS' TO PROGRAMA */
                _.Move("PTACOMPS", AREA_DE_WORK.PROGRAMA);

                /*" -1533- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1538- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARACO-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA}"
                .Display();

                /*" -1540- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1542- END-IF */
            }


            /*" -1546- CALL 'PTACOMPS' USING PROTOCOLO-RECEBIDO DCLGE-CARTA-ACOMP PROTOCOLO-ENVIO */
            _.Call("PTACOMPS", LBWCT001.PROTOCOLO_RECEBIDO, GECARACO.DCLGE_CARTA_ACOMP, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1567- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1568- MOVE 'PTACOMPS' TO PROGRAMA */
                _.Move("PTACOMPS", AREA_DE_WORK.PROGRAMA);

                /*" -1571- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1576- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARACO-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA}"
                .Display();

                /*" -1578- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1580- END-IF */
            }


            /*" -1581- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -1583- DISPLAY '*** PROBLEMAS NA SUBROTINA PTACOMPS ***' */
                _.Display($"*** PROBLEMAS NA SUBROTINA PTACOMPS ***");

                /*" -1587- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARACO-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARACO.DCLGE_CARTA_ACOMP.GECARACO_NUM_CARTA}"
                .Display();

                /*" -1588- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1590- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1590- ADD 1 TO AC-I-SIDOCACO. */
            AREA_DE_WORK.AC_I_SIDOCACO.Value = AREA_DE_WORK.AC_I_SIDOCACO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-INCLUI-SINISTRO-ACOMP-SECTION */
        private void R4500_00_INCLUI_SINISTRO_ACOMP_SECTION()
        {
            /*" -1600- MOVE '450' TO WNR-EXEC-SQL. */
            _.Move("450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1601- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -1602- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -1604- MOVE 'SI0031B' TO IN-USUARIO */
            _.Move("SI0031B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -1606- MOVE WS-FONTE-ANT TO SISINACO-COD-FONTE */
            _.Move(WS_FONTE_ANT, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_FONTE);

            /*" -1608- MOVE WS-PROTOCOLO-ANT TO SISINACO-NUM-PROTOCOLO-SINI */
            _.Move(WS_PROTOCOLO_ANT, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_PROTOCOLO_SINI);

            /*" -1610- MOVE WS-DAC-ANT TO SISINACO-DAC-PROTOCOLO-SINI */
            _.Move(WS_DAC_ANT, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DAC_PROTOCOLO_SINI);

            /*" -1612- MOVE SIEVETIP-COD-EVENTO TO SISINACO-COD-EVENTO */
            _.Move(SIEVETIP.DCLSI_EVENTO_TIPO.SIEVETIP_COD_EVENTO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO);

            /*" -1615- MOVE SISTEMAS-DATA-MOV-ABERTO TO SISINACO-DATA-MOVTO-SINIACO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DATA_MOVTO_SINIACO);

            /*" -1617- MOVE SPACES TO SISINACO-DESCR-COMPLEMENTAR */
            _.Move("", SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_DESCR_COMPLEMENTAR);

            /*" -1619- MOVE GECARTA-COD-USUARIO TO SISINACO-COD-USUARIO */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_COD_USUARIO, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_USUARIO);

            /*" -1622- MOVE GECARTA-NUM-CARTA TO SISINACO-NUM-CARTA */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA, SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA);

            /*" -1643- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1644- MOVE 'PTACOMOS' TO PROGRAMA */
                _.Move("PTACOMOS", AREA_DE_WORK.PROGRAMA);

                /*" -1646- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1652- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' SISINACO-COD-EVENTO ' ' SISINACO-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA}"
                .Display();

                /*" -1654- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1656- END-IF */
            }


            /*" -1660- CALL 'PTACOMOS' USING PROTOCOLO-RECEBIDO DCLSI-SINISTRO-ACOMP PROTOCOLO-ENVIO */
            _.Call("PTACOMOS", LBWCT001.PROTOCOLO_RECEBIDO, SISINACO.DCLSI_SINISTRO_ACOMP, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1681- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1682- MOVE 'PTACOMOS' TO PROGRAMA */
                _.Move("PTACOMOS", AREA_DE_WORK.PROGRAMA);

                /*" -1684- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1690- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' SISINACO-COD-EVENTO ' ' SISINACO-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA}"
                .Display();

                /*" -1692- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1694- END-IF */
            }


            /*" -1695- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -1697- DISPLAY '*** PROBLEMAS NA SUBROTINA PTACOMOS ***' */
                _.Display($"*** PROBLEMAS NA SUBROTINA PTACOMOS ***");

                /*" -1702- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' SISINACO-COD-EVENTO ' ' SISINACO-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_COD_EVENTO} {SISINACO.DCLSI_SINISTRO_ACOMP.SISINACO_NUM_CARTA}"
                .Display();

                /*" -1703- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1703- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-INCLUI-CARTA-TEXTO-SECTION */
        private void R4600_00_INCLUI_CARTA_TEXTO_SECTION()
        {
            /*" -1713- MOVE '460' TO WNR-EXEC-SQL. */
            _.Move("460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1714- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -1715- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -1717- MOVE 'SI0031B' TO IN-USUARIO */
            _.Move("SI0031B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -1719- MOVE GECARTA-NUM-CARTA TO GECARTEX-NUM-CARTA */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA, GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA);

            /*" -1740- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1741- MOVE 'PTTEXTOS' TO PROGRAMA */
                _.Move("PTTEXTOS", AREA_DE_WORK.PROGRAMA);

                /*" -1743- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1748- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARTEX-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA}"
                .Display();

                /*" -1750- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1752- END-IF */
            }


            /*" -1756- CALL 'PTTEXTOS' USING PROTOCOLO-RECEBIDO DCLGE-CARTA-TEXTO PROTOCOLO-ENVIO */
            _.Call("PTTEXTOS", LBWCT001.PROTOCOLO_RECEBIDO, GECARTEX.DCLGE_CARTA_TEXTO, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1777- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1778- MOVE 'PTTEXTOS' TO PROGRAMA */
                _.Move("PTTEXTOS", AREA_DE_WORK.PROGRAMA);

                /*" -1780- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1785- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARTEX-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA}"
                .Display();

                /*" -1787- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1789- END-IF */
            }


            /*" -1790- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -1792- DISPLAY '*** PROBLEMAS NA SUBROTINA PTTEXTOS ***' */
                _.Display($"*** PROBLEMAS NA SUBROTINA PTTEXTOS ***");

                /*" -1796- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARTEX-NUM-CARTA */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARTEX.DCLGE_CARTA_TEXTO.GECARTEX_NUM_CARTA}"
                .Display();

                /*" -1797- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1797- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4700-00-DECLARA-CARTA-DEST-SECTION */
        private void R4700_00_DECLARA_CARTA_DEST_SECTION()
        {
            /*" -1807- MOVE '470' TO WNR-EXEC-SQL. */
            _.Move("470", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1815- PERFORM R4700_00_DECLARA_CARTA_DEST_DB_DECLARE_1 */

            R4700_00_DECLARA_CARTA_DEST_DB_DECLARE_1();

            /*" -1817- PERFORM R4700_00_DECLARA_CARTA_DEST_DB_OPEN_1 */

            R4700_00_DECLARA_CARTA_DEST_DB_OPEN_1();

            /*" -1820- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1821- DISPLAY 'SI0031B - PROBLEMAS NO OPEN GE_REL_CARTA_DEST' */
                _.Display($"SI0031B - PROBLEMAS NO OPEN GE_REL_CARTA_DEST");

                /*" -1826- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT}"
                .Display();

                /*" -1826- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4700-00-DECLARA-CARTA-DEST-DB-OPEN-1 */
        public void R4700_00_DECLARA_CARTA_DEST_DB_OPEN_1()
        {
            /*" -1817- EXEC SQL OPEN CARDEST END-EXEC. */

            CARDEST.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4700_99_SAIDA*/

        [StopWatch]
        /*" R4800-00-LE-CARTA-DEST-SECTION */
        private void R4800_00_LE_CARTA_DEST_SECTION()
        {
            /*" -1836- MOVE '480' TO WNR-EXEC-SQL. */
            _.Move("480", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1840- PERFORM R4800_00_LE_CARTA_DEST_DB_FETCH_1 */

            R4800_00_LE_CARTA_DEST_DB_FETCH_1();

            /*" -1843- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1844- MOVE 'S' TO WFIM-CARTA-DEST */
                _.Move("S", AREA_DE_WORK.WFIM_CARTA_DEST);

                /*" -1844- PERFORM R4800_00_LE_CARTA_DEST_DB_CLOSE_1 */

                R4800_00_LE_CARTA_DEST_DB_CLOSE_1();

                /*" -1846- ELSE */
            }
            else
            {


                /*" -1847- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1848- DISPLAY 'SI0031B - PROBLEMAS NO FETCH GE_REL_CARTA_DEST' */
                    _.Display($"SI0031B - PROBLEMAS NO FETCH GE_REL_CARTA_DEST");

                    /*" -1853- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' WS-TIPO-CARTA-ANT ' ' WS-CARTA-ANT */

                    $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {WS_TIPO_CARTA_ANT} {WS_CARTA_ANT}"
                    .Display();

                    /*" -1853- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R4800-00-LE-CARTA-DEST-DB-FETCH-1 */
        public void R4800_00_LE_CARTA_DEST_DB_FETCH_1()
        {
            /*" -1840- EXEC SQL FETCH CARDEST INTO :GERECADE-COD-DESTINATARIO, :GERECADE-IND-DEST-PRINC, :GEDESTIN-NOME-DESTINATARIO END-EXEC. */

            if (CARDEST.Fetch())
            {
                _.Move(CARDEST.GERECADE_COD_DESTINATARIO, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO);
                _.Move(CARDEST.GERECADE_IND_DEST_PRINC, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC);
                _.Move(CARDEST.GEDESTIN_NOME_DESTINATARIO, GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO);
            }

        }

        [StopWatch]
        /*" R4800-00-LE-CARTA-DEST-DB-CLOSE-1 */
        public void R4800_00_LE_CARTA_DEST_DB_CLOSE_1()
        {
            /*" -1844- EXEC SQL CLOSE CARDEST END-EXEC */

            CARDEST.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4800_99_SAIDA*/

        [StopWatch]
        /*" R4900-00-INCLUI-CARTA-DEST-SECTION */
        private void R4900_00_INCLUI_CARTA_DEST_SECTION()
        {
            /*" -1863- MOVE '490' TO WNR-EXEC-SQL. */
            _.Move("490", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1868- PERFORM R4950-00-CHAMA-PTDESTAS */

            R4950_00_CHAMA_PTDESTAS_SECTION();

            /*" -1871- IF WS-TIPO-CARTA-ANT EQUAL 2 AND GERECADE-IND-DEST-PRINC EQUAL 'S' */

            if (WS_TIPO_CARTA_ANT == 2 && GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC == "S")
            {

                /*" -1874- MOVE GEDESTIN-NOME-DESTINATARIO TO WS-NOME. */
                _.Move(GEDESTIN.DCLGE_DESTINATARIO.GEDESTIN_NOME_DESTINATARIO, WS_NOME);
            }


            /*" -1874- PERFORM R4800-00-LE-CARTA-DEST. */

            R4800_00_LE_CARTA_DEST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4900_99_SAIDA*/

        [StopWatch]
        /*" R4950-00-CHAMA-PTDESTAS-SECTION */
        private void R4950_00_CHAMA_PTDESTAS_SECTION()
        {
            /*" -1884- MOVE '495' TO WNR-EXEC-SQL. */
            _.Move("495", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1885- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -1886- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -1888- MOVE 'SI0031B' TO IN-USUARIO */
            _.Move("SI0031B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -1890- MOVE GECARTA-NUM-CARTA TO GERECADE-NUM-CARTA */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA, GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_NUM_CARTA);

            /*" -1911- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1912- MOVE 'PTDESTAS' TO PROGRAMA */
                _.Move("PTDESTAS", AREA_DE_WORK.PROGRAMA);

                /*" -1914- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1921- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GERECADE-NUM-CARTA ' ' GERECADE-COD-DESTINATARIO ' ' GERECADE-IND-DEST-PRINC */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_NUM_CARTA} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC}"
                .Display();

                /*" -1923- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1925- END-IF */
            }


            /*" -1929- CALL 'PTDESTAS' USING PROTOCOLO-RECEBIDO DCLGE-REL-CARTA-DEST PROTOCOLO-ENVIO. */
            _.Call("PTDESTAS", LBWCT001.PROTOCOLO_RECEBIDO, GERECADE.DCLGE_REL_CARTA_DEST, LBWCT002.PROTOCOLO_ENVIO);

            /*" -1950- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -1951- MOVE 'PTDESTAS' TO PROGRAMA */
                _.Move("PTDESTAS", AREA_DE_WORK.PROGRAMA);

                /*" -1953- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -1960- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GERECADE-NUM-CARTA ' ' GERECADE-COD-DESTINATARIO ' ' GERECADE-IND-DEST-PRINC */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_NUM_CARTA} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC}"
                .Display();

                /*" -1962- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1964- END-IF */
            }


            /*" -1966- IF OUT-COD-RETORNO NOT EQUAL ZEROS AND OUT-COD-RETORNO-SQL NOT EQUAL -803 */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00 && LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO_SQL != -803)
            {

                /*" -1968- DISPLAY '*** PROBLEMAS NA SUBROTINA PTDESTAS ***' */
                _.Display($"*** PROBLEMAS NA SUBROTINA PTDESTAS ***");

                /*" -1974- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GERECADE-NUM-CARTA ' ' GERECADE-COD-DESTINATARIO ' ' GERECADE-IND-DEST-PRINC */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_NUM_CARTA} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_COD_DESTINATARIO} {GERECADE.DCLGE_REL_CARTA_DEST.GERECADE_IND_DEST_PRINC}"
                .Display();

                /*" -1975- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -1976- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1976- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4950_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-PROCESSA-DOCUMENTOS-SECTION */
        private void R5000_00_PROCESSA_DOCUMENTOS_SECTION()
        {
            /*" -1986- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1986- MOVE 1 TO IX2. */
            _.Move(1, IX2);

            /*" -0- FLUXCONTROL_PERFORM R5000_10_LOOP */

            R5000_10_LOOP();

        }

        [StopWatch]
        /*" R5000-10-LOOP */
        private void R5000_10_LOOP(bool isPerform = false)
        {
            /*" -1991- IF IX2 NOT GREATER IX1 */

            if (IX2 <= IX1)
            {

                /*" -1993- MOVE TAB-COD-DOCUMENTO(IX2) TO SIDOCACO-COD-DOCUMENTO */
                _.Move(TAB_DADOS[IX2].TAB_COD_DOCUMENTO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO);

                /*" -1996- COMPUTE SIDOCACO-NUM-OCORR-DOCACO = TAB-NUM-OCORR-DOCACO(IX2) + 1 */
                SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_OCORR_DOCACO.Value = TAB_DADOS[IX2].TAB_NUM_OCORR_DOCACO.Value + 1;

                /*" -1998- MOVE TAB-COD-PRODUTO(IX2) TO SIDOCACO-COD-PRODUTO */
                _.Move(TAB_DADOS[IX2].TAB_COD_PRODUTO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_PRODUTO);

                /*" -2000- MOVE TAB-COD-GRUPO-CAUSA(IX2) TO SIDOCACO-COD-GRUPO-CAUSA */
                _.Move(TAB_DADOS[IX2].TAB_COD_GRUPO_CAUSA, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_GRUPO_CAUSA);

                /*" -2003- MOVE TAB-COD-SUBGRUPO-CAUSA(IX2) TO SIDOCACO-COD-SUBGRUPO-CAUSA */
                _.Move(TAB_DADOS[IX2].TAB_COD_SUBGRUPO_CAUSA, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_SUBGRUPO_CAUSA);

                /*" -2006- MOVE TAB-DATA-INIVIG-DOCPAR(IX2) TO SIDOCACO-DATA-INIVIG-DOCPAR */
                _.Move(TAB_DADOS[IX2].TAB_DATA_INIVIG_DOCPAR, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_INIVIG_DOCPAR);

                /*" -2007- PERFORM R5100-00-INCLUI-DOCTO-ACOMP */

                R5100_00_INCLUI_DOCTO_ACOMP_SECTION();

                /*" -2008- ADD 1 TO IX2 */
                IX2.Value = IX2 + 1;

                /*" -2008- GO TO R5000-10-LOOP. */
                new Task(() => R5000_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-INCLUI-DOCTO-ACOMP-SECTION */
        private void R5100_00_INCLUI_DOCTO_ACOMP_SECTION()
        {
            /*" -2018- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2019- MOVE 'SI' TO IN-SISTEMA */
            _.Move("SI", LBWCT001.PROTOCOLO_RECEBIDO.IN_SISTEMA);

            /*" -2020- MOVE 1 TO IN-OPERACAO */
            _.Move(1, LBWCT001.PROTOCOLO_RECEBIDO.IN_OPERACAO);

            /*" -2022- MOVE 'SI0031B' TO IN-USUARIO */
            _.Move("SI0031B", LBWCT001.PROTOCOLO_RECEBIDO.IN_USUARIO);

            /*" -2024- MOVE WS-FONTE-ANT TO SIDOCACO-COD-FONTE */
            _.Move(WS_FONTE_ANT, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_FONTE);

            /*" -2026- MOVE WS-PROTOCOLO-ANT TO SIDOCACO-NUM-PROTOCOLO-SINI */
            _.Move(WS_PROTOCOLO_ANT, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_PROTOCOLO_SINI);

            /*" -2028- MOVE WS-DAC-ANT TO SIDOCACO-DAC-PROTOCOLO-SINI */
            _.Move(WS_DAC_ANT, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DAC_PROTOCOLO_SINI);

            /*" -2030- MOVE 2013 TO SIDOCACO-COD-EVENTO */
            _.Move(2013, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_EVENTO);

            /*" -2033- MOVE SISTEMAS-DATA-MOV-ABERTO TO SIDOCACO-DATA-MOVTO-DOCACO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DATA_MOVTO_DOCACO);

            /*" -2035- MOVE ' ' TO SIDOCACO-DESCR-COMPLEMENTAR */
            _.Move(" ", SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_DESCR_COMPLEMENTAR);

            /*" -2037- MOVE GECARTA-NUM-CARTA TO SIDOCACO-NUM-CARTA */
            _.Move(GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA, SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_NUM_CARTA);

            /*" -2040- MOVE 'SI0031B' TO SIDOCACO-COD-USUARIO */
            _.Move("SI0031B", SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_USUARIO);

            /*" -2061- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -2062- MOVE 'PTACOM2S' TO PROGRAMA */
                _.Move("PTACOM2S", AREA_DE_WORK.PROGRAMA);

                /*" -2064- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -2070- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARTA-NUM-CARTA ' ' SIDOCACO-COD-DOCUMENTO */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO}"
                .Display();

                /*" -2072- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -2078- END-IF */
            }


            /*" -2082- CALL 'PTACOM2S' USING PROTOCOLO-RECEBIDO DCLSI-DOCUMENTO-ACOMP PROTOCOLO-ENVIO */
            _.Call("PTACOM2S", LBWCT001.PROTOCOLO_RECEBIDO, SIDOCACO.DCLSI_DOCUMENTO_ACOMP, LBWCT002.PROTOCOLO_ENVIO);

            /*" -2103- IF H-SIDOCACO-COD-FONTE = 10 AND H-SIDOCACO-DAC-PROTOCOLO-SINI = '0' AND SIDOCPAR-COD-TIPO-CARTA = 2 AND (H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792541 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792545 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792565 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792788 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792831 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792915 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792944 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792971 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791460 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9791558 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792886 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792912 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792910 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792872 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792890 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9792993 OR H-SIDOCACO-NUM-PROTOCOLO-SINI = 9793089) */

            if (H_SIDOCACO_COD_FONTE == 10 && H_SIDOCACO_DAC_PROTOCOLO_SINI == "0" && SIDOCPAR.DCLSI_DOCUMENTO_PARAM.SIDOCPAR_COD_TIPO_CARTA == 2 && (H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792541 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792545 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792565 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792788 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792831 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792915 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792944 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792971 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791460 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9791558 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792886 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792912 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792910 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792872 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792890 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9792993 || H_SIDOCACO_NUM_PROTOCOLO_SINI == 9793089))
            {

                /*" -2104- MOVE 'PTACOM2S' TO PROGRAMA */
                _.Move("PTACOM2S", AREA_DE_WORK.PROGRAMA);

                /*" -2106- DISPLAY 'VER PROGRAMA = ' PROGRAMA */
                _.Display($"VER PROGRAMA = {AREA_DE_WORK.PROGRAMA}");

                /*" -2112- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARTA-NUM-CARTA ' ' SIDOCACO-COD-DOCUMENTO */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO}"
                .Display();

                /*" -2114- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -2116- END-IF */
            }


            /*" -2117- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LBWCT002.PROTOCOLO_ENVIO.OUT_COD_RETORNO != 00)
            {

                /*" -2119- DISPLAY '*** PROBLEMAS NA SUBROTINA PTACOM2S ***' */
                _.Display($"*** PROBLEMAS NA SUBROTINA PTACOM2S ***");

                /*" -2124- DISPLAY ' ' WS-FONTE-ANT ' ' WS-PROTOCOLO-ANT ' ' WS-DAC-ANT ' ' GECARTA-NUM-CARTA ' ' SIDOCACO-COD-DOCUMENTO */

                $" {WS_FONTE_ANT} {WS_PROTOCOLO_ANT} {WS_DAC_ANT} {GECARTA.DCLGE_CARTA.GECARTA_NUM_CARTA} {SIDOCACO.DCLSI_DOCUMENTO_ACOMP.SIDOCACO_COD_DOCUMENTO}"
                .Display();

                /*" -2125- PERFORM R0001-VER THRU R0001-99-VER */

                R0001_VER_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_99_VER*/


                /*" -2125- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2135- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2137- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2137- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2141- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2142- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -2143- DISPLAY '***   SI0031B - CANCELADO  ***' */
            _.Display($"***   SI0031B - CANCELADO  ***");

            /*" -2145- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -2145- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}