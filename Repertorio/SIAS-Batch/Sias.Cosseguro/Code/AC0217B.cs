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
using Sias.Cosseguro.DB2.AC0217B;

namespace Code
{
    public class AC0217B
    {
        public bool IsCall { get; set; }

        public AC0217B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------                                       */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0217B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CARLOS ALBERTO                     *      */
        /*"      *   PROGRAMADOR ............  HERVAL SOUZA                       *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO/2005                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  ATUALIZAR DB DE COSSEGURO          *      */
        /*"      *                            (SINISTROS) AJUSTE DE CENTAVOS      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            SISTEMAS            INPUT  *      */
        /*"      * HISTORICO DE SINISTROS              SINISHIS            INPUT  *      */
        /*"      * HISTORICO DE COSSEGURO (SINISTRO)   COSHISSI            I-O    *      */
        /*"      * GE_SIS_FUN_OPER                     GESISFUO            INPUT  *      */
        /*"      * GE_SINISTRO_ANALITICO               GE396               INPUT  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ARQUIVO                                               ACESSO   *      */
        /*"      *--------------------------------------------------------------- *      */
        /*"      * ACOCORR                                               OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACOES:                                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 03/02/2006:                              PROCURAR POR: HS0206  *      */
        /*"      *    - SE EXISTIR ESTORNO DA OPERACAO, IGNORAR PARA EFEITO DE    *      */
        /*"      *         AJUSTE.                                                *      */
        /*"      *    - ALTERAR TODOS OS VALORES DO OCOR-HIST, QUANDO DO AJUSTE   *      */
        /*"      *         RAZAO: SAO VALORES DEPENDENTES...                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 13/11/2009:                              PROCURAR POR: HS0911  *      */
        /*"      *    - ALTERAR VALOR MAXIMO DE CENTAVOS NO AJUSTE.               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 21/06/2013:                              PROCURAR POR: RL2106  *      */
        /*"      * CADMUS:DIASIAS                                                 *      */
        /*"      *    - SUBSTITUICAO DOS ACESSOS NA TABELA SINISTROS_ANALIT PELO  *      */
        /*"      *      ACESSO NA TABELA GE_SINISTRO_ANALITICO (GE396).           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO  - AUMENTAR O RESIDUO DA PREVISAO PARA 0,10          *      */
        /*"      *              R1500-00...                                       *      */
        /*"      * 03/06/2016 - WELLINGTON VERAS  TE39902     CADMUS 137206       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO  - AUMENTAR O RESIDUO DA PREVISAO PARA 0,15          *      */
        /*"      *              R1500-00...                                       *      */
        /*"      * 22/09/2016 - WELLINGTON VERAS  TE39902     CADMUS 142332       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO  - AUMENTAR O RESIDUO DA PREVISAO PARA 0,20          *      */
        /*"      *              R1500-00...                                       *      */
        /*"      * 20/03/2017 - WELLINGTON VERAS  TE39902     CADMUS 149178       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO  - AUMENTAR O TAMANHO DA COLUNA COD-TIP-OPER INTEGER *      */
        /*"      *              S9(004) PARA S9(009)                              *      */
        /*"      * 14/11/2017 - WELLINGTON VERAS  TE39902     CADMUS 154896       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - TRATAR AS NOVAS OPERACAOES JUDICIAIS DO SINISTRO  *      */
        /*"      *              8218, 8282 E AS RESPECTIVAS ASSOCIADAS DO AC E RE *      */
        /*"      * 23/05/2018 - GILSON PINTO DA SILVA             CADMUS - 159804 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ACOCORR { get; set; } = new FileBasis(new PIC("X", "203", "X(203)"));

        public FileBasis ACOCORR
        {
            get
            {
                _.Move(REG_ACOCORR, _ACOCORR); VarBasis.RedefinePassValue(REG_ACOCORR, _ACOCORR, REG_ACOCORR); return _ACOCORR;
            }
        }
        /*"01          REG-ACOCORR          PIC  X(203).*/
        public StringBasis REG_ACOCORR { get; set; } = new StringBasis(new PIC("X", "203", "X(203)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          PENDENTE-SINISTRO   PIC S9(013)V99     USAGE COMP-3.*/
        public DoubleBasis PENDENTE_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          PENDENTE-COSSEG     PIC S9(013)V99     USAGE COMP-3.*/
        public DoubleBasis PENDENTE_COSSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          VALOR-AJUSTADO      PIC S9(013)V99     USAGE COMP-3.*/
        public DoubleBasis VALOR_AJUSTADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          DATA-TAPA-TEC       PIC  X(010)        VALUE SPACES.*/
        public StringBasis DATA_TAPA_TEC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01              WS-OCORR.*/
        public AC0217B_WS_OCORR WS_OCORR { get; set; } = new AC0217B_WS_OCORR();
        public class AC0217B_WS_OCORR : VarBasis
        {
            /*"      05        OC-PENDENTE        PIC  X(030)     VALUE ZEROS.*/
            public StringBasis OC_PENDENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-NUM-SINISTRO    PIC  9(013)     VALUE ZEROS.*/
            public IntBasis OC_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-CONGENERE       PIC  9(005)     VALUE ZEROS.*/
            public IntBasis OC_CONGENERE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-COD-OPER        PIC  9(004)     VALUE ZEROS.*/
            public IntBasis OC_COD_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-OCOR-HIST       PIC  9(004)     VALUE ZEROS.*/
            public IntBasis OC_OCOR_HIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-DT-MOVTO        PIC  X(010)     VALUE ZEROS.*/
            public StringBasis OC_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-TIPO-OPER       PIC  9(009)     VALUE ZEROS.*/
            public IntBasis OC_TIPO_OPER { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-NUM-FATOR       PIC -9(001)     VALUE ZEROS.*/
            public IntBasis OC_NUM_FATOR { get; set; } = new IntBasis(new PIC("-9", "1", "-9(001)"));
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-VAL-OPER        PIC -Z(012)9,99 VALUE ZEROS.*/
            public DoubleBasis OC_VAL_OPER { get; set; } = new DoubleBasis(new PIC("-S9", "13", "-Z(012)9V99"), 2);
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-RESIDUO         PIC -Z(012)9,99 VALUE ZEROS.*/
            public DoubleBasis OC_RESIDUO { get; set; } = new DoubleBasis(new PIC("-S9", "13", "-Z(012)9V99"), 2);
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        OC-VAL-AJUST       PIC -Z(012)9,99 VALUE ZEROS.*/
            public DoubleBasis OC_VAL_AJUST { get; set; } = new DoubleBasis(new PIC("-S9", "13", "-Z(012)9V99"), 2);
            /*"      05        FILLER             PIC  X(001)     VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"      05        FILLER             PIC  X(069)     VALUE ' '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)"), @" ");
            /*"01          WS-LAN-ANT.*/
        }
        public AC0217B_WS_LAN_ANT WS_LAN_ANT { get; set; } = new AC0217B_WS_LAN_ANT();
        public class AC0217B_WS_LAN_ANT : VarBasis
        {
            /*"      05    SINISTRO-ANT        PIC S9(013)V     USAGE COMP-3                                                 VALUE ZEROS.*/
            public DoubleBasis SINISTRO_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
            /*"      05    FUNCAO-ANT          PIC  9(002).*/
            public IntBasis FUNCAO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05    CONGENERE-ANT       PIC S9(004)      USAGE COMP.*/
            public IntBasis CONGENERE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      05    COD-OPER-ANT        PIC S9(004)      USAGE COMP.*/
            public IntBasis COD_OPER_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      05    OCOR-HIS-ANT        PIC S9(004)      USAGE COMP.*/
            public IntBasis OCOR_HIS_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      05    DT-MOVTO-ANT        PIC  X(010).*/
            public StringBasis DT_MOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"      05    NUM-FATOR-ANT       PIC S9(004)      USAGE COMP.*/
            public IntBasis NUM_FATOR_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      05    VAL-OPER-ANT        PIC S9(013)V99   USAGE COMP-3.*/
            public DoubleBasis VAL_OPER_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      05    OCOR-HIS-CANC       PIC S9(004)      USAGE COMP                                                 VALUE  ZEROS.*/
            public IntBasis OCOR_HIS_CANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      05    SINISTRO-CANC       PIC S9(013)V     USAGE COMP-3                                                 VALUE  ZEROS.*/
            public DoubleBasis SINISTRO_CANC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
            /*"      05    CONGENERE-CANC      PIC S9(004)      USAGE COMP                                                 VALUE  ZEROS.*/
            public IntBasis CONGENERE_CANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01          AREA-DE-WORK.*/
        }
        public AC0217B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0217B_AREA_DE_WORK();
        public class AC0217B_AREA_DE_WORK : VarBasis
        {
            /*"  05        AC-L-SINISTRO       PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-L-COSSEGURO      PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_L_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-U-COSSEGURO      PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_U_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        AC-G-OCORRENCIA     PIC  9(007)  VALUE ZEROS.*/
            public IntBasis AC_G_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WFIM-COSSEGURO      PIC  X(003)  VALUE SPACES.*/
            public StringBasis WFIM_COSSEGURO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_AC0217B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_AC0217B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_AC0217B_FILLER_12(); _.Move(WDATA_REL, _filler_12); VarBasis.RedefinePassValue(WDATA_REL, _filler_12, WDATA_REL); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_REL); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_REL); }
            }  //Redefines
            public class _REDEF_AC0217B_FILLER_12 : VarBasis
            {
                /*"    10      WDAT-REL-ANO        PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-SQL           PIC  X(010)  VALUE SPACES.*/

                public _REDEF_AC0217B_FILLER_12()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES    WDATA-SQL.*/
            private _REDEF_AC0217B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_AC0217B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_AC0217B_FILLER_15(); _.Move(WDATA_SQL, _filler_15); VarBasis.RedefinePassValue(WDATA_SQL, _filler_15, WDATA_SQL); _filler_15.ValueChanged += () => { _.Move(_filler_15, WDATA_SQL); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_AC0217B_FILLER_15 : VarBasis
            {
                /*"    10      WDATA-SQL-ANO       PIC  9(004).*/
                public IntBasis WDATA_SQL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-SQL-MES       PIC  9(002).*/
                public IntBasis WDATA_SQL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-SQL-DIA       PIC  9(002).*/
                public IntBasis WDATA_SQL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDAT-REL-LIT.*/

                public _REDEF_AC0217B_FILLER_15()
                {
                    WDATA_SQL_ANO.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                    WDATA_SQL_MES.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    WDATA_SQL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public AC0217B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new AC0217B_WDAT_REL_LIT();
            public class AC0217B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-ANO        PIC  9(004)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WHORA-ACCEPT.*/
            }
            public AC0217B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0217B_WHORA_ACCEPT();
            public class AC0217B_WHORA_ACCEPT : VarBasis
            {
                /*"    10      WHH-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WMM-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WSS-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WCC-ACCEPT          PIC  9(002)  VALUE  ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01          WABEND.*/
            }
        }
        public AC0217B_WABEND WABEND { get; set; } = new AC0217B_WABEND();
        public class AC0217B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)    VALUE           ' AC0217B'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0217B");
            /*"  05        FILLER              PIC  X(026)    VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(003)    VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05        FILLER              PIC  X(013)    VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.COSHISSI COSHISSI { get; set; } = new Dclgens.COSHISSI();
        public Dclgens.GE396 GE396 { get; set; } = new Dclgens.GE396();
        public AC0217B_COSSEGURO COSSEGURO { get; set; } = new AC0217B_COSSEGURO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ACOCORR_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ACOCORR.SetFile(ACOCORR_FILE_NAME_P);

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
            /*" -268- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -269- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -272- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -275- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -279- OPEN OUTPUT ACOCORR. */
            ACOCORR.Open(REG_ACOCORR);

            /*" -288- MOVE ZEROS TO COSHISSI-NUM-SINISTRO GESISFUO-COD-FUNCAO COSHISSI-COD-CONGENERE COSHISSI-COD-OPERACAO COSHISSI-OCORR-HISTORICO COSHISSI-VAL-OPERACAO GESISFUO-NUM-FATOR OCOR-HIS-CANC. */
            _.Move(0, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_VAL_OPERACAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR, WS_LAN_ANT.OCOR_HIS_CANC);

            /*" -290- MOVE SPACES TO COSHISSI-DATA-MOVIMENTO. */
            _.Move("", COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO);

            /*" -292- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -294- PERFORM R8800-00-PREPARA-OCORR. */

            R8800_00_PREPARA_OCORR_SECTION();

            /*" -296- PERFORM R0900-00-DECLARE-COSSEGURO. */

            R0900_00_DECLARE_COSSEGURO_SECTION();

            /*" -298- PERFORM R0950-00-FETCH-COSSEGURO. */

            R0950_00_FETCH_COSSEGURO_SECTION();

            /*" -299- MOVE COSHISSI-NUM-SINISTRO TO SINISTRO-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO, WS_LAN_ANT.SINISTRO_ANT);

            /*" -300- MOVE GESISFUO-COD-FUNCAO TO FUNCAO-ANT. */
            _.Move(GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO, WS_LAN_ANT.FUNCAO_ANT);

            /*" -301- MOVE COSHISSI-COD-CONGENERE TO CONGENERE-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE, WS_LAN_ANT.CONGENERE_ANT);

            /*" -302- MOVE COSHISSI-COD-OPERACAO TO COD-OPER-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO, WS_LAN_ANT.COD_OPER_ANT);

            /*" -303- MOVE COSHISSI-OCORR-HISTORICO TO OCOR-HIS-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO, WS_LAN_ANT.OCOR_HIS_ANT);

            /*" -304- MOVE COSHISSI-DATA-MOVIMENTO TO DT-MOVTO-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO, WS_LAN_ANT.DT_MOVTO_ANT);

            /*" -305- MOVE COSHISSI-VAL-OPERACAO TO VAL-OPER-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_VAL_OPERACAO, WS_LAN_ANT.VAL_OPER_ANT);

            /*" -307- MOVE GESISFUO-NUM-FATOR TO NUM-FATOR-ANT. */
            _.Move(GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR, WS_LAN_ANT.NUM_FATOR_ANT);

            /*" -308- IF WFIM-COSSEGURO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_COSSEGURO.IsEmpty())
            {

                /*" -309- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -310- ELSE */
            }
            else
            {


                /*" -311- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-COSSEGURO NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_COSSEGURO.IsEmpty()))
                {

                    R1000_00_PROCESSA_REGISTRO_SECTION();
                }
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -317- CLOSE ACOCORR. */
            ACOCORR.Close();

            /*" -318- DISPLAY 'SINISTROS LIDOS        - ' AC-L-SINISTRO. */
            _.Display($"SINISTROS LIDOS        - {AREA_DE_WORK.AC_L_SINISTRO}");

            /*" -319- DISPLAY 'COSSEGUROS LIDOS       - ' AC-L-COSSEGURO. */
            _.Display($"COSSEGUROS LIDOS       - {AREA_DE_WORK.AC_L_COSSEGURO}");

            /*" -320- DISPLAY 'COSSEGUROS ATUALIZADOS - ' AC-U-COSSEGURO. */
            _.Display($"COSSEGUROS ATUALIZADOS - {AREA_DE_WORK.AC_U_COSSEGURO}");

            /*" -322- DISPLAY 'OCORRENCIAS GRAVADAS   - ' AC-G-OCORRENCIA. */
            _.Display($"OCORRENCIAS GRAVADAS   - {AREA_DE_WORK.AC_G_OCORRENCIA}");

            /*" -322- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -326- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -326- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -339- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -344- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -347- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -348- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS ' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS ");

                /*" -349- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -350- ELSE */
            }
            else
            {


                /*" -351- DISPLAY 'DATA DO SISTEMA AC - ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA DO SISTEMA AC - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -351- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -344- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'AC' END-EXEC. */

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
        /*" R0900-00-DECLARE-COSSEGURO-SECTION */
        private void R0900_00_DECLARE_COSSEGURO_SECTION()
        {
            /*" -376- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -403- PERFORM R0900_00_DECLARE_COSSEGURO_DB_DECLARE_1 */

            R0900_00_DECLARE_COSSEGURO_DB_DECLARE_1();

            /*" -405- PERFORM R0900_00_DECLARE_COSSEGURO_DB_OPEN_1 */

            R0900_00_DECLARE_COSSEGURO_DB_OPEN_1();

            /*" -408- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -409- DISPLAY 'R0900 - ERRO NO DECLARE DA COSSEGURO ' */
                _.Display($"R0900 - ERRO NO DECLARE DA COSSEGURO ");

                /*" -410- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -411- ELSE */
            }
            else
            {


                /*" -411- MOVE SPACES TO WFIM-COSSEGURO. */
                _.Move("", AREA_DE_WORK.WFIM_COSSEGURO);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-COSSEGURO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_COSSEGURO_DB_DECLARE_1()
        {
            /*" -403- EXEC SQL DECLARE COSSEGURO CURSOR FOR SELECT A.NUM_SINISTRO, B.COD_FUNCAO, A.COD_CONGENERE, A.OCORR_HISTORICO, A.COD_OPERACAO, A.VAL_OPERACAO, A.TIPO_SEGURO, A.DATA_MOVIMENTO, B.NUM_FATOR FROM SEGUROS.COSSEGURO_HIST_SIN A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.VAL_OPERACAO <> 0 AND A.TIPO_SEGURO = '1' AND A.SIT_LIBRECUP = '0' AND A.SIT_REGISTRO = '0' AND B.COD_OPERACAO = A.COD_OPERACAO AND B.COD_FUNCAO IN (01,07,11) AND B.IDE_SISTEMA = 'SI' AND B.IDE_SISTEMA_OPER = 'SI' ORDER BY A.NUM_SINISTRO, B.COD_FUNCAO, A.COD_CONGENERE, A.OCORR_HISTORICO, A.COD_OPERACAO DESC END-EXEC. */
            COSSEGURO = new AC0217B_COSSEGURO(true);
            string GetQuery_COSSEGURO()
            {
                var query = @$"SELECT A.NUM_SINISTRO
							, 
							B.COD_FUNCAO
							, 
							A.COD_CONGENERE
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO
							, 
							A.VAL_OPERACAO
							, 
							A.TIPO_SEGURO
							, 
							A.DATA_MOVIMENTO
							, 
							B.NUM_FATOR 
							FROM SEGUROS.COSSEGURO_HIST_SIN A
							, 
							SEGUROS.GE_SIS_FUNCAO_OPER B 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.VAL_OPERACAO <> 0 
							AND A.TIPO_SEGURO = '1' 
							AND A.SIT_LIBRECUP = '0' 
							AND A.SIT_REGISTRO = '0' 
							AND B.COD_OPERACAO = A.COD_OPERACAO 
							AND B.COD_FUNCAO IN (01
							,07
							,11) 
							AND B.IDE_SISTEMA = 'SI' 
							AND B.IDE_SISTEMA_OPER = 'SI' 
							ORDER BY A.NUM_SINISTRO
							, 
							B.COD_FUNCAO
							, 
							A.COD_CONGENERE
							, 
							A.OCORR_HISTORICO
							, 
							A.COD_OPERACAO DESC";

                return query;
            }
            COSSEGURO.GetQueryEvent += GetQuery_COSSEGURO;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-COSSEGURO-DB-OPEN-1 */
        public void R0900_00_DECLARE_COSSEGURO_DB_OPEN_1()
        {
            /*" -405- EXEC SQL OPEN COSSEGURO END-EXEC. */

            COSSEGURO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-00-FETCH-COSSEGURO-SECTION */
        private void R0950_00_FETCH_COSSEGURO_SECTION()
        {
            /*" -424- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", WABEND.WNR_EXEC_SQL);

            /*" -425- MOVE COSHISSI-NUM-SINISTRO TO SINISTRO-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO, WS_LAN_ANT.SINISTRO_ANT);

            /*" -426- MOVE GESISFUO-COD-FUNCAO TO FUNCAO-ANT. */
            _.Move(GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO, WS_LAN_ANT.FUNCAO_ANT);

            /*" -427- MOVE COSHISSI-COD-CONGENERE TO CONGENERE-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE, WS_LAN_ANT.CONGENERE_ANT);

            /*" -428- MOVE COSHISSI-COD-OPERACAO TO COD-OPER-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO, WS_LAN_ANT.COD_OPER_ANT);

            /*" -429- MOVE COSHISSI-OCORR-HISTORICO TO OCOR-HIS-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO, WS_LAN_ANT.OCOR_HIS_ANT);

            /*" -430- MOVE COSHISSI-DATA-MOVIMENTO TO DT-MOVTO-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO, WS_LAN_ANT.DT_MOVTO_ANT);

            /*" -431- MOVE COSHISSI-VAL-OPERACAO TO VAL-OPER-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_VAL_OPERACAO, WS_LAN_ANT.VAL_OPER_ANT);

            /*" -431- MOVE GESISFUO-NUM-FATOR TO NUM-FATOR-ANT. */
            _.Move(GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR, WS_LAN_ANT.NUM_FATOR_ANT);

            /*" -0- FLUXCONTROL_PERFORM R0950_10_NEW_FETCH */

            R0950_10_NEW_FETCH();

        }

        [StopWatch]
        /*" R0950-10-NEW-FETCH */
        private void R0950_10_NEW_FETCH(bool isPerform = false)
        {
            /*" -446- PERFORM R0950_10_NEW_FETCH_DB_FETCH_1 */

            R0950_10_NEW_FETCH_DB_FETCH_1();

            /*" -449- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -450- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -451- MOVE 'S' TO WFIM-COSSEGURO */
                    _.Move("S", AREA_DE_WORK.WFIM_COSSEGURO);

                    /*" -451- PERFORM R0950_10_NEW_FETCH_DB_CLOSE_1 */

                    R0950_10_NEW_FETCH_DB_CLOSE_1();

                    /*" -453- GO TO R0950-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                    return;

                    /*" -454- ELSE */
                }
                else
                {


                    /*" -455- DISPLAY 'R0950 - ERRO NO FETCH DA COSSEGURO ' */
                    _.Display($"R0950 - ERRO NO FETCH DA COSSEGURO ");

                    /*" -457- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -458- IF COSHISSI-NUM-SINISTRO NOT = SINISTRO-ANT */

            if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO != WS_LAN_ANT.SINISTRO_ANT)
            {

                /*" -459- ADD 1 TO AC-L-SINISTRO */
                AREA_DE_WORK.AC_L_SINISTRO.Value = AREA_DE_WORK.AC_L_SINISTRO + 1;

                /*" -463- END-IF. */
            }


            /*" -465- IF COSHISSI-COD-OPERACAO EQUAL 1050 OR 8280 OR 8281 OR COSHISSI-COD-OPERACAO EQUAL 8282 */

            if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO.In("1050", "8280", "8281") || COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO == 8282)
            {

                /*" -466- MOVE COSHISSI-NUM-SINISTRO TO SINISTRO-CANC */
                _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO, WS_LAN_ANT.SINISTRO_CANC);

                /*" -467- MOVE COSHISSI-COD-CONGENERE TO CONGENERE-CANC */
                _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE, WS_LAN_ANT.CONGENERE_CANC);

                /*" -468- MOVE COSHISSI-OCORR-HISTORICO TO OCOR-HIS-CANC */
                _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO, WS_LAN_ANT.OCOR_HIS_CANC);

                /*" -469- GO TO R0950-10-NEW-FETCH */
                new Task(() => R0950_10_NEW_FETCH()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -473- END-IF. */
            }


            /*" -476- IF (COSHISSI-NUM-SINISTRO = SINISTRO-CANC) AND (COSHISSI-COD-CONGENERE = CONGENERE-CANC) AND (COSHISSI-OCORR-HISTORICO = OCOR-HIS-CANC) */

            if ((COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO == WS_LAN_ANT.SINISTRO_CANC) && (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE == WS_LAN_ANT.CONGENERE_CANC) && (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO == WS_LAN_ANT.OCOR_HIS_CANC))
            {

                /*" -477- GO TO R0950-10-NEW-FETCH */
                new Task(() => R0950_10_NEW_FETCH()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -479- END-IF. */
            }


            /*" -483- MOVE ZEROS TO OCOR-HIS-CANC SINISTRO-CANC CONGENERE-CANC. */
            _.Move(0, WS_LAN_ANT.OCOR_HIS_CANC, WS_LAN_ANT.SINISTRO_CANC, WS_LAN_ANT.CONGENERE_CANC);

            /*" -483- ADD 1 TO AC-L-COSSEGURO. */
            AREA_DE_WORK.AC_L_COSSEGURO.Value = AREA_DE_WORK.AC_L_COSSEGURO + 1;

        }

        [StopWatch]
        /*" R0950-10-NEW-FETCH-DB-FETCH-1 */
        public void R0950_10_NEW_FETCH_DB_FETCH_1()
        {
            /*" -446- EXEC SQL FETCH COSSEGURO INTO :COSHISSI-NUM-SINISTRO, :GESISFUO-COD-FUNCAO, :COSHISSI-COD-CONGENERE, :COSHISSI-OCORR-HISTORICO, :COSHISSI-COD-OPERACAO, :COSHISSI-VAL-OPERACAO, :COSHISSI-TIPO-SEGURO, :COSHISSI-DATA-MOVIMENTO, :GESISFUO-NUM-FATOR END-EXEC. */

            if (COSSEGURO.Fetch())
            {
                _.Move(COSSEGURO.COSHISSI_NUM_SINISTRO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO);
                _.Move(COSSEGURO.GESISFUO_COD_FUNCAO, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO);
                _.Move(COSSEGURO.COSHISSI_COD_CONGENERE, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE);
                _.Move(COSSEGURO.COSHISSI_OCORR_HISTORICO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO);
                _.Move(COSSEGURO.COSHISSI_COD_OPERACAO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO);
                _.Move(COSSEGURO.COSHISSI_VAL_OPERACAO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_VAL_OPERACAO);
                _.Move(COSSEGURO.COSHISSI_TIPO_SEGURO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO);
                _.Move(COSSEGURO.COSHISSI_DATA_MOVIMENTO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO);
                _.Move(COSSEGURO.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
            }

        }

        [StopWatch]
        /*" R0950-10-NEW-FETCH-DB-CLOSE-1 */
        public void R0950_10_NEW_FETCH_DB_CLOSE_1()
        {
            /*" -451- EXEC SQL CLOSE COSSEGURO END-EXEC */

            COSSEGURO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -496- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -497- MOVE COSHISSI-NUM-SINISTRO TO SINISTRO-ANT. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO, WS_LAN_ANT.SINISTRO_ANT);

            /*" -501- MOVE GESISFUO-COD-FUNCAO TO FUNCAO-ANT. */
            _.Move(GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO, WS_LAN_ANT.FUNCAO_ANT);

            /*" -505- PERFORM R1100-00-PENDENTE-HISTORICO. */

            R1100_00_PENDENTE_HISTORICO_SECTION();

            /*" -506- IF PENDENTE-SINISTRO NOT = ZEROS */

            if (PENDENTE_SINISTRO != 00)
            {

                /*" -510- PERFORM R0950-00-FETCH-COSSEGURO UNTIL COSHISSI-NUM-SINISTRO NOT = SINISTRO-ANT OR GESISFUO-COD-FUNCAO NOT = FUNCAO-ANT OR WFIM-COSSEGURO NOT = SPACES */

                while (!(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO != WS_LAN_ANT.SINISTRO_ANT || GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO != WS_LAN_ANT.FUNCAO_ANT || !AREA_DE_WORK.WFIM_COSSEGURO.IsEmpty()))
                {

                    R0950_00_FETCH_COSSEGURO_SECTION();
                }

                /*" -511- GO TO R1000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                return;

                /*" -519- END-IF. */
            }


            /*" -523- PERFORM R1200-00-PENDENTE-01-2006. */

            R1200_00_PENDENTE_01_2006_SECTION();

            /*" -533- PERFORM UNTIL COSHISSI-NUM-SINISTRO NOT = SINISTRO-ANT OR GESISFUO-COD-FUNCAO NOT = FUNCAO-ANT OR WFIM-COSSEGURO NOT = SPACES */

            while (!(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO != WS_LAN_ANT.SINISTRO_ANT || GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO != WS_LAN_ANT.FUNCAO_ANT || !AREA_DE_WORK.WFIM_COSSEGURO.IsEmpty()))
            {

                /*" -534- IF GE396-VLR-COSSEGURO NOT = ZEROS */

                if (GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO != 00)
                {

                    /*" -535- PERFORM R1300-00-PENDENTE-COSSEG-01 */

                    R1300_00_PENDENTE_COSSEG_01_SECTION();

                    /*" -536- ELSE */
                }
                else
                {


                    /*" -537- PERFORM R1400-00-PENDENTE-COSSEG-02 */

                    R1400_00_PENDENTE_COSSEG_02_SECTION();

                    /*" -541- END-IF */
                }


                /*" -543- MOVE COSHISSI-COD-CONGENERE TO CONGENERE-ANT */
                _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE, WS_LAN_ANT.CONGENERE_ANT);

                /*" -551- PERFORM R0950-00-FETCH-COSSEGURO UNTIL COSHISSI-NUM-SINISTRO NOT = SINISTRO-ANT OR GESISFUO-COD-FUNCAO NOT = FUNCAO-ANT OR COSHISSI-COD-CONGENERE NOT = CONGENERE-ANT OR WFIM-COSSEGURO NOT = SPACES */

                while (!(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO != WS_LAN_ANT.SINISTRO_ANT || GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO != WS_LAN_ANT.FUNCAO_ANT || COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE != WS_LAN_ANT.CONGENERE_ANT || !AREA_DE_WORK.WFIM_COSSEGURO.IsEmpty()))
                {

                    R0950_00_FETCH_COSSEGURO_SECTION();
                }

                /*" -552- IF PENDENTE-COSSEG NOT = ZEROS */

                if (PENDENTE_COSSEG != 00)
                {

                    /*" -553- PERFORM R1500-00-UPDATE-COSSEGURO */

                    R1500_00_UPDATE_COSSEGURO_SECTION();

                    /*" -558- END-IF */
                }


                /*" -558- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PENDENTE-HISTORICO-SECTION */
        private void R1100_00_PENDENTE_HISTORICO_SECTION()
        {
            /*" -571- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WABEND.WNR_EXEC_SQL);

            /*" -583- PERFORM R1100_00_PENDENTE_HISTORICO_DB_SELECT_1 */

            R1100_00_PENDENTE_HISTORICO_DB_SELECT_1();

            /*" -586- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -587- DISPLAY 'R1100 - ERRO NO SELECT DA SINISTRO-HISTORICO' */
                _.Display($"R1100 - ERRO NO SELECT DA SINISTRO-HISTORICO");

                /*" -588- DISPLAY 'SINISTRO - ' COSHISSI-NUM-SINISTRO */
                _.Display($"SINISTRO - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -589- DISPLAY 'FUNCAO   - ' GESISFUO-COD-FUNCAO */
                _.Display($"FUNCAO   - {GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO}");

                /*" -589- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-PENDENTE-HISTORICO-DB-SELECT-1 */
        public void R1100_00_PENDENTE_HISTORICO_DB_SELECT_1()
        {
            /*" -583- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR),+0) INTO :PENDENTE-SINISTRO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.NUM_APOL_SINISTRO = :COSHISSI-NUM-SINISTRO AND A.DATA_MOVIMENTO BETWEEN '1993-01-01' AND :SISTEMAS-DATA-MOV-ABERTO AND B.COD_OPERACAO = A.COD_OPERACAO AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND B.IDE_SISTEMA = 'SI' AND B.IDE_SISTEMA_OPER = 'SI' END-EXEC. */

            var r1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1 = new R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
            };

            var executed_1 = R1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1.Execute(r1100_00_PENDENTE_HISTORICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PENDENTE_SINISTRO, PENDENTE_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PENDENTE-01-2006-SECTION */
        private void R1200_00_PENDENTE_01_2006_SECTION()
        {
            /*" -604- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -605- IF GESISFUO-COD-FUNCAO = 1 */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO == 1)
            {

                /*" -606- MOVE '0' TO GE396-IND-TIPO-MOVTO */
                _.Move("0", GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO);

                /*" -607- IF COSHISSI-TIPO-SEGURO = '0' */

                if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO == "0")
                {

                    /*" -608- MOVE 2090 TO GE396-COD-TIPO-OPER */
                    _.Move(2090, GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER);

                    /*" -609- ELSE */
                }
                else
                {


                    /*" -610- MOVE 2190 TO GE396-COD-TIPO-OPER */
                    _.Move(2190, GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER);

                    /*" -611- END-IF */
                }


                /*" -613- END-IF. */
            }


            /*" -614- IF GESISFUO-COD-FUNCAO = 7 */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO == 7)
            {

                /*" -615- MOVE '3' TO GE396-IND-TIPO-MOVTO */
                _.Move("3", GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO);

                /*" -616- IF COSHISSI-TIPO-SEGURO = '0' */

                if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO == "0")
                {

                    /*" -617- MOVE 2893 TO GE396-COD-TIPO-OPER */
                    _.Move(2893, GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER);

                    /*" -618- ELSE */
                }
                else
                {


                    /*" -619- MOVE 2890 TO GE396-COD-TIPO-OPER */
                    _.Move(2890, GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER);

                    /*" -620- END-IF */
                }


                /*" -622- END-IF. */
            }


            /*" -623- IF GESISFUO-COD-FUNCAO = 11 */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO == 11)
            {

                /*" -624- MOVE '4' TO GE396-IND-TIPO-MOVTO */
                _.Move("4", GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO);

                /*" -625- IF COSHISSI-TIPO-SEGURO = '0' */

                if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO == "0")
                {

                    /*" -626- MOVE 2894 TO GE396-COD-TIPO-OPER */
                    _.Move(2894, GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER);

                    /*" -627- ELSE */
                }
                else
                {


                    /*" -628- MOVE 2891 TO GE396-COD-TIPO-OPER */
                    _.Move(2891, GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER);

                    /*" -629- END-IF */
                }


                /*" -631- END-IF. */
            }


            /*" -635- MOVE '1993-01-01' TO DATA-TAPA-TEC. */
            _.Move("1993-01-01", DATA_TAPA_TEC);

            /*" -645- PERFORM R1200_00_PENDENTE_01_2006_DB_SELECT_1 */

            R1200_00_PENDENTE_01_2006_DB_SELECT_1();

            /*" -648- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -649- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -650- DISPLAY 'R1200A- ERRO NO SELECT DA GE-SINISTRO-ANALIT' */
                    _.Display($"R1200A- ERRO NO SELECT DA GE-SINISTRO-ANALIT");

                    /*" -651- DISPLAY 'SINISTRO  - ' COSHISSI-NUM-SINISTRO */
                    _.Display($"SINISTRO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                    /*" -652- DISPLAY 'TIPO MOVTO- ' GE396-IND-TIPO-MOVTO */
                    _.Display($"TIPO MOVTO- {GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO}");

                    /*" -653- DISPLAY 'TIPO OPER - ' GE396-COD-TIPO-OPER */
                    _.Display($"TIPO OPER - {GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER}");

                    /*" -654- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -655- ELSE */
                }
                else
                {


                    /*" -656- MOVE ZEROS TO GE396-VLR-COSSEGURO */
                    _.Move(0, GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO);

                    /*" -657- MOVE '2006-02-01' TO DATA-TAPA-TEC */
                    _.Move("2006-02-01", DATA_TAPA_TEC);

                    /*" -658- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -659- END-IF */
                }


                /*" -663- END-IF. */
            }


            /*" -673- PERFORM R1200_00_PENDENTE_01_2006_DB_SELECT_2 */

            R1200_00_PENDENTE_01_2006_DB_SELECT_2();

            /*" -676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -678- DISPLAY 'R1200B- ERRO NO SELECT DA GE-SINISTRO-ANALIT' */
                    _.Display($"R1200B- ERRO NO SELECT DA GE-SINISTRO-ANALIT");

                    /*" -679- DISPLAY 'SINISTRO  - ' COSHISSI-NUM-SINISTRO */
                    _.Display($"SINISTRO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                    /*" -680- DISPLAY 'TIPO MOVTO- ' GE396-IND-TIPO-MOVTO */
                    _.Display($"TIPO MOVTO- {GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO}");

                    /*" -681- DISPLAY 'TIPO OPER - ' GE396-COD-TIPO-OPER */
                    _.Display($"TIPO OPER - {GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER}");

                    /*" -682- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -683- ELSE */
                }
                else
                {


                    /*" -684- MOVE ZEROS TO GE396-VLR-COSSEGURO */
                    _.Move(0, GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO);

                    /*" -685- MOVE '2006-01-01' TO DATA-TAPA-TEC */
                    _.Move("2006-01-01", DATA_TAPA_TEC);

                    /*" -686- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -687- END-IF */
                }


                /*" -691- END-IF. */
            }


            /*" -701- PERFORM R1200_00_PENDENTE_01_2006_DB_SELECT_3 */

            R1200_00_PENDENTE_01_2006_DB_SELECT_3();

            /*" -704- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -705- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -706- DISPLAY 'R1200C- ERRO NO SELECT DA GE-SINISTRO-ANALIT' */
                    _.Display($"R1200C- ERRO NO SELECT DA GE-SINISTRO-ANALIT");

                    /*" -707- DISPLAY 'SINISTRO  - ' COSHISSI-NUM-SINISTRO */
                    _.Display($"SINISTRO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                    /*" -708- DISPLAY 'TIPO MOVTO- ' GE396-IND-TIPO-MOVTO */
                    _.Display($"TIPO MOVTO- {GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO}");

                    /*" -709- DISPLAY 'TIPO OPER - ' GE396-COD-TIPO-OPER */
                    _.Display($"TIPO OPER - {GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER}");

                    /*" -710- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -711- ELSE */
                }
                else
                {


                    /*" -712- MOVE ZEROS TO GE396-VLR-COSSEGURO */
                    _.Move(0, GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO);

                    /*" -713- MOVE '2005-12-01' TO DATA-TAPA-TEC */
                    _.Move("2005-12-01", DATA_TAPA_TEC);

                    /*" -714- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -715- END-IF */
                }


                /*" -715- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-PENDENTE-01-2006-DB-SELECT-1 */
        public void R1200_00_PENDENTE_01_2006_DB_SELECT_1()
        {
            /*" -645- EXEC SQL SELECT VLR_COSSEGURO INTO :GE396-VLR-COSSEGURO FROM SEGUROS.GE_SINISTRO_ANALITICO WHERE NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND NUM_ANO_REFER = 2006 AND NUM_MES_REFER = 01 AND NUM_DIA_REFER = 31 AND IND_TIPO_MOVTO = :GE396-IND-TIPO-MOVTO AND COD_TIPO_OPER = :GE396-COD-TIPO-OPER END-EXEC. */

            var r1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1 = new R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1()
            {
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                GE396_IND_TIPO_MOVTO = GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO.ToString(),
                GE396_COD_TIPO_OPER = GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER.ToString(),
            };

            var executed_1 = R1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1.Execute(r1200_00_PENDENTE_01_2006_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE396_VLR_COSSEGURO, GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PENDENTE-01-2006-DB-SELECT-2 */
        public void R1200_00_PENDENTE_01_2006_DB_SELECT_2()
        {
            /*" -673- EXEC SQL SELECT VLR_COSSEGURO INTO :GE396-VLR-COSSEGURO FROM SEGUROS.GE_SINISTRO_ANALITICO WHERE NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND NUM_ANO_REFER = 2005 AND NUM_MES_REFER = 12 AND NUM_DIA_REFER = 31 AND IND_TIPO_MOVTO = :GE396-IND-TIPO-MOVTO AND COD_TIPO_OPER = :GE396-COD-TIPO-OPER END-EXEC. */

            var r1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1 = new R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1()
            {
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                GE396_IND_TIPO_MOVTO = GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO.ToString(),
                GE396_COD_TIPO_OPER = GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER.ToString(),
            };

            var executed_1 = R1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1.Execute(r1200_00_PENDENTE_01_2006_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE396_VLR_COSSEGURO, GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO);
            }


        }

        [StopWatch]
        /*" R1300-00-PENDENTE-COSSEG-01-SECTION */
        private void R1300_00_PENDENTE_COSSEG_01_SECTION()
        {
            /*" -731- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -733- MOVE ZEROS TO PENDENTE-COSSEG. */
            _.Move(0, PENDENTE_COSSEG);

            /*" -746- PERFORM R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1 */

            R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1();

            /*" -749- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -750- DISPLAY 'R1300 - ERRO NO SELECT DA COSSEGURO-HIST-SIN' */
                _.Display($"R1300 - ERRO NO SELECT DA COSSEGURO-HIST-SIN");

                /*" -751- DISPLAY 'SINISTRO- ' COSHISSI-NUM-SINISTRO */
                _.Display($"SINISTRO- {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -752- DISPLAY 'CONGENER- ' COSHISSI-COD-CONGENERE */
                _.Display($"CONGENER- {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE}");

                /*" -752- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-PENDENTE-COSSEG-01-DB-SELECT-1 */
        public void R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1()
        {
            /*" -746- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR),+0) INTO :PENDENTE-COSSEG FROM SEGUROS.COSSEGURO_HIST_SIN A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND A.COD_CONGENERE = :COSHISSI-COD-CONGENERE AND A.DATA_MOVIMENTO <= :SISTEMAS-DATA-MOV-ABERTO AND B.COD_OPERACAO = A.COD_OPERACAO AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND B.IDE_SISTEMA = 'SI' AND B.IDE_SISTEMA_OPER = 'SI' AND A.TIPO_SEGURO = '1' END-EXEC. */

            var r1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1 = new R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                COSHISSI_COD_CONGENERE = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE.ToString(),
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
            };

            var executed_1 = R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1.Execute(r1300_00_PENDENTE_COSSEG_01_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PENDENTE_COSSEG, PENDENTE_COSSEG);
            }


        }

        [StopWatch]
        /*" R1200-00-PENDENTE-01-2006-DB-SELECT-3 */
        public void R1200_00_PENDENTE_01_2006_DB_SELECT_3()
        {
            /*" -701- EXEC SQL SELECT VLR_COSSEGURO INTO :GE396-VLR-COSSEGURO FROM SEGUROS.GE_SINISTRO_ANALITICO WHERE NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND NUM_ANO_REFER = 2005 AND NUM_MES_REFER = 11 AND NUM_DIA_REFER = 30 AND IND_TIPO_MOVTO = :GE396-IND-TIPO-MOVTO AND COD_TIPO_OPER = :GE396-COD-TIPO-OPER END-EXEC. */

            var r1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1 = new R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1()
            {
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                GE396_IND_TIPO_MOVTO = GE396.DCLGE_SINISTRO_ANALITICO.GE396_IND_TIPO_MOVTO.ToString(),
                GE396_COD_TIPO_OPER = GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER.ToString(),
            };

            var executed_1 = R1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1.Execute(r1200_00_PENDENTE_01_2006_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE396_VLR_COSSEGURO, GE396.DCLGE_SINISTRO_ANALITICO.GE396_VLR_COSSEGURO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-PENDENTE-COSSEG-02-SECTION */
        private void R1400_00_PENDENTE_COSSEG_02_SECTION()
        {
            /*" -765- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WABEND.WNR_EXEC_SQL);

            /*" -767- MOVE ZEROS TO PENDENTE-COSSEG. */
            _.Move(0, PENDENTE_COSSEG);

            /*" -781- PERFORM R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1 */

            R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1();

            /*" -784- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -785- DISPLAY 'R1400 - ERRO NO SELECT DA COSSEGURO-HIST-SIN' */
                _.Display($"R1400 - ERRO NO SELECT DA COSSEGURO-HIST-SIN");

                /*" -786- DISPLAY 'SINISTRO- ' COSHISSI-NUM-SINISTRO */
                _.Display($"SINISTRO- {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -787- DISPLAY 'CONGENER- ' COSHISSI-COD-CONGENERE */
                _.Display($"CONGENER- {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE}");

                /*" -787- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-00-PENDENTE-COSSEG-02-DB-SELECT-1 */
        public void R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1()
        {
            /*" -781- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO * B.NUM_FATOR),+0) INTO :PENDENTE-COSSEG FROM SEGUROS.COSSEGURO_HIST_SIN A, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE A.NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND A.COD_CONGENERE = :COSHISSI-COD-CONGENERE AND A.DATA_MOVIMENTO BETWEEN :DATA-TAPA-TEC AND :SISTEMAS-DATA-MOV-ABERTO AND B.COD_OPERACAO = A.COD_OPERACAO AND B.COD_FUNCAO = :GESISFUO-COD-FUNCAO AND B.IDE_SISTEMA = 'SI' AND B.IDE_SISTEMA_OPER = 'SI' AND A.TIPO_SEGURO = '1' END-EXEC. */

            var r1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1 = new R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                COSHISSI_COD_CONGENERE = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE.ToString(),
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                GESISFUO_COD_FUNCAO = GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_COD_FUNCAO.ToString(),
                DATA_TAPA_TEC = DATA_TAPA_TEC.ToString(),
            };

            var executed_1 = R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1.Execute(r1400_00_PENDENTE_COSSEG_02_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PENDENTE_COSSEG, PENDENTE_COSSEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-UPDATE-COSSEGURO-SECTION */
        private void R1500_00_UPDATE_COSSEGURO_SECTION()
        {
            /*" -802- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -816- MOVE ZEROS TO VALOR-AJUSTADO. */
            _.Move(0, VALOR_AJUSTADO);

            /*" -818- IF PENDENTE-COSSEG > +0,20 OR PENDENTE-COSSEG < -0,20 */

            if (PENDENTE_COSSEG > +0.20 || PENDENTE_COSSEG < -0.20)
            {

                /*" -819- DISPLAY 'R1500 - RESIDUO SUPERIOR A PREVISAO ' */
                _.Display($"R1500 - RESIDUO SUPERIOR A PREVISAO ");

                /*" -820- DISPLAY 'SINISTRO- ' SINISTRO-ANT */
                _.Display($"SINISTRO- {WS_LAN_ANT.SINISTRO_ANT}");

                /*" -821- DISPLAY 'CONGENER- ' CONGENERE-ANT */
                _.Display($"CONGENER- {WS_LAN_ANT.CONGENERE_ANT}");

                /*" -822- DISPLAY 'TP OPER - ' GE396-COD-TIPO-OPER */
                _.Display($"TP OPER - {GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER}");

                /*" -823- DISPLAY 'RESIDUO - ' PENDENTE-COSSEG */
                _.Display($"RESIDUO - {PENDENTE_COSSEG}");

                /*" -824- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -826- END-IF. */
            }


            /*" -831- COMPUTE VALOR-AJUSTADO = VAL-OPER-ANT - (PENDENTE-COSSEG * NUM-FATOR-ANT). */
            VALOR_AJUSTADO.Value = WS_LAN_ANT.VAL_OPER_ANT - (PENDENTE_COSSEG * WS_LAN_ANT.NUM_FATOR_ANT);

            /*" -832- IF VALOR-AJUSTADO < ZEROS */

            if (VALOR_AJUSTADO < 00)
            {

                /*" -833- DISPLAY 'R1500 - RESIDUO SUPERIOR AO LANCAMENTO ' */
                _.Display($"R1500 - RESIDUO SUPERIOR AO LANCAMENTO ");

                /*" -834- DISPLAY 'SINISTRO- ' SINISTRO-ANT */
                _.Display($"SINISTRO- {WS_LAN_ANT.SINISTRO_ANT}");

                /*" -835- DISPLAY 'CONGENER- ' CONGENERE-ANT */
                _.Display($"CONGENER- {WS_LAN_ANT.CONGENERE_ANT}");

                /*" -836- DISPLAY 'TP OPER - ' GE396-COD-TIPO-OPER */
                _.Display($"TP OPER - {GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER}");

                /*" -837- DISPLAY 'VL AJUST- ' VALOR-AJUSTADO */
                _.Display($"VL AJUST- {VALOR_AJUSTADO}");

                /*" -838- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -840- END-IF. */
            }


            /*" -852- PERFORM R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1 */

            R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1();

            /*" -855- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -856- DISPLAY 'R1500 - ERRO NO UPDATE DA COSSEGURO-HIST-SIN' */
                _.Display($"R1500 - ERRO NO UPDATE DA COSSEGURO-HIST-SIN");

                /*" -857- DISPLAY 'SINISTRO - ' SINISTRO-ANT */
                _.Display($"SINISTRO - {WS_LAN_ANT.SINISTRO_ANT}");

                /*" -858- DISPLAY 'CONGENER - ' CONGENERE-ANT */
                _.Display($"CONGENER - {WS_LAN_ANT.CONGENERE_ANT}");

                /*" -859- DISPLAY 'OCOR HIS - ' OCOR-HIS-ANT */
                _.Display($"OCOR HIS - {WS_LAN_ANT.OCOR_HIS_ANT}");

                /*" -860- DISPLAY 'OPERACAO - ' COD-OPER-ANT */
                _.Display($"OPERACAO - {WS_LAN_ANT.COD_OPER_ANT}");

                /*" -861- DISPLAY 'DT MOVTO - ' DT-MOVTO-ANT */
                _.Display($"DT MOVTO - {WS_LAN_ANT.DT_MOVTO_ANT}");

                /*" -862- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -863- ELSE */
            }
            else
            {


                /*" -865- ADD 1 TO AC-U-COSSEGURO. */
                AREA_DE_WORK.AC_U_COSSEGURO.Value = AREA_DE_WORK.AC_U_COSSEGURO + 1;
            }


            /*" -865- PERFORM R8900-00-LISTA. */

            R8900_00_LISTA_SECTION();

        }

        [StopWatch]
        /*" R1500-00-UPDATE-COSSEGURO-DB-UPDATE-1 */
        public void R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1()
        {
            /*" -852- EXEC SQL UPDATE SEGUROS.COSSEGURO_HIST_SIN SET VAL_OPERACAO = :VALOR-AJUSTADO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_SINISTRO = :SINISTRO-ANT AND COD_CONGENERE = :CONGENERE-ANT AND OCORR_HISTORICO = :OCOR-HIS-ANT AND COD_OPERACAO = :COD-OPER-ANT AND DATA_MOVIMENTO = :DT-MOVTO-ANT AND TIPO_SEGURO = '1' AND SIT_REGISTRO = '0' AND SIT_LIBRECUP = '0' END-EXEC. */

            var r1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1 = new R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1()
            {
                VALOR_AJUSTADO = VALOR_AJUSTADO.ToString(),
                CONGENERE_ANT = WS_LAN_ANT.CONGENERE_ANT.ToString(),
                SINISTRO_ANT = WS_LAN_ANT.SINISTRO_ANT.ToString(),
                OCOR_HIS_ANT = WS_LAN_ANT.OCOR_HIS_ANT.ToString(),
                COD_OPER_ANT = WS_LAN_ANT.COD_OPER_ANT.ToString(),
                DT_MOVTO_ANT = WS_LAN_ANT.DT_MOVTO_ANT.ToString(),
            };

            R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1.Execute(r1500_00_UPDATE_COSSEGURO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R8800-00-PREPARA-OCORR-SECTION */
        private void R8800_00_PREPARA_OCORR_SECTION()
        {
            /*" -878- MOVE '880' TO WNR-EXEC-SQL. */
            _.Move("880", WABEND.WNR_EXEC_SQL);

            /*" -881- MOVE 'AC0217B- COSSEGURO AJUSTADO;' TO REG-ACOCORR. */
            _.Move("AC0217B- COSSEGURO AJUSTADO;", REG_ACOCORR);

            /*" -883- WRITE REG-ACOCORR. */
            ACOCORR.Write(REG_ACOCORR.GetMoveValues().ToString());

            /*" -885- ADD 1 TO AC-G-OCORRENCIA. */
            AREA_DE_WORK.AC_G_OCORRENCIA.Value = AREA_DE_WORK.AC_G_OCORRENCIA + 1;

            /*" -888- STRING 'REFERENCIA : ; ' SISTEMAS-DATA-MOV-ABERTO ';' DELIMITED BY SIZE INTO REG-ACOCORR. */
            #region STRING
            var spl1 = "REFERENCIA : ; " + SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.GetMoveValues();
            spl1 += ";";
            _.Move(spl1, REG_ACOCORR);
            #endregion

            /*" -890- WRITE REG-ACOCORR. */
            ACOCORR.Write(REG_ACOCORR.GetMoveValues().ToString());

            /*" -892- ADD 1 TO AC-G-OCORRENCIA. */
            AREA_DE_WORK.AC_G_OCORRENCIA.Value = AREA_DE_WORK.AC_G_OCORRENCIA + 1;

            /*" -894- MOVE SPACES TO REG-ACOCORR. */
            _.Move("", REG_ACOCORR);

            /*" -900- STRING 'PENDENTE;SINISTRO;CONGEN;COD OPER;OCOR HIST;' 'DT MOVTO;TIPO OPER;FATOR;VAL COSSEG;' 'RESIDUO;VAL AJUSTADO;' DELIMITED BY SIZE INTO REG-ACOCORR. */
            #region STRING
            var spl2 = "PENDENTE;SINISTRO;CONGEN;COD OPER;OCOR HIST;" + "DT MOVTO;TIPO OPER;FATOR;VAL COSSEG;" + "RESIDUO;VAL AJUSTADO;";
            _.Move(spl2, REG_ACOCORR);
            #endregion

            /*" -902- WRITE REG-ACOCORR. */
            ACOCORR.Write(REG_ACOCORR.GetMoveValues().ToString());

            /*" -902- ADD 1 TO AC-G-OCORRENCIA. */
            AREA_DE_WORK.AC_G_OCORRENCIA.Value = AREA_DE_WORK.AC_G_OCORRENCIA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" R8900-00-LISTA-SECTION */
        private void R8900_00_LISTA_SECTION()
        {
            /*" -915- MOVE '890' TO WNR-EXEC-SQL. */
            _.Move("890", WABEND.WNR_EXEC_SQL);

            /*" -916- IF FUNCAO-ANT = 1 */

            if (WS_LAN_ANT.FUNCAO_ANT == 1)
            {

                /*" -918- MOVE '2090/2190-PENDENTE NORMAL' TO OC-PENDENTE. */
                _.Move("2090/2190-PENDENTE NORMAL", WS_OCORR.OC_PENDENTE);
            }


            /*" -919- IF FUNCAO-ANT = 7 */

            if (WS_LAN_ANT.FUNCAO_ANT == 7)
            {

                /*" -921- MOVE '2890/2893-PENDENTE JUDICIAL' TO OC-PENDENTE. */
                _.Move("2890/2893-PENDENTE JUDICIAL", WS_OCORR.OC_PENDENTE);
            }


            /*" -922- IF FUNCAO-ANT = 11 */

            if (WS_LAN_ANT.FUNCAO_ANT == 11)
            {

                /*" -925- MOVE '2891/2894-PENDENTE SUCUMBENCIA' TO OC-PENDENTE. */
                _.Move("2891/2894-PENDENTE SUCUMBENCIA", WS_OCORR.OC_PENDENTE);
            }


            /*" -926- MOVE SINISTRO-ANT TO OC-NUM-SINISTRO. */
            _.Move(WS_LAN_ANT.SINISTRO_ANT, WS_OCORR.OC_NUM_SINISTRO);

            /*" -927- MOVE CONGENERE-ANT TO OC-CONGENERE. */
            _.Move(WS_LAN_ANT.CONGENERE_ANT, WS_OCORR.OC_CONGENERE);

            /*" -928- MOVE COD-OPER-ANT TO OC-COD-OPER. */
            _.Move(WS_LAN_ANT.COD_OPER_ANT, WS_OCORR.OC_COD_OPER);

            /*" -929- MOVE GE396-COD-TIPO-OPER TO OC-TIPO-OPER. */
            _.Move(GE396.DCLGE_SINISTRO_ANALITICO.GE396_COD_TIPO_OPER, WS_OCORR.OC_TIPO_OPER);

            /*" -930- MOVE OCOR-HIS-ANT TO OC-OCOR-HIST. */
            _.Move(WS_LAN_ANT.OCOR_HIS_ANT, WS_OCORR.OC_OCOR_HIST);

            /*" -931- MOVE DT-MOVTO-ANT TO OC-DT-MOVTO. */
            _.Move(WS_LAN_ANT.DT_MOVTO_ANT, WS_OCORR.OC_DT_MOVTO);

            /*" -932- MOVE NUM-FATOR-ANT TO OC-NUM-FATOR. */
            _.Move(WS_LAN_ANT.NUM_FATOR_ANT, WS_OCORR.OC_NUM_FATOR);

            /*" -933- MOVE VAL-OPER-ANT TO OC-VAL-OPER. */
            _.Move(WS_LAN_ANT.VAL_OPER_ANT, WS_OCORR.OC_VAL_OPER);

            /*" -934- MOVE PENDENTE-COSSEG TO OC-RESIDUO. */
            _.Move(PENDENTE_COSSEG, WS_OCORR.OC_RESIDUO);

            /*" -936- MOVE VALOR-AJUSTADO TO OC-VAL-AJUST. */
            _.Move(VALOR_AJUSTADO, WS_OCORR.OC_VAL_AJUST);

            /*" -938- WRITE REG-ACOCORR FROM WS-OCORR. */
            _.Move(WS_OCORR.GetMoveValues(), REG_ACOCORR);

            ACOCORR.Write(REG_ACOCORR.GetMoveValues().ToString());

            /*" -938- ADD 1 TO AC-G-OCORRENCIA. */
            AREA_DE_WORK.AC_G_OCORRENCIA.Value = AREA_DE_WORK.AC_G_OCORRENCIA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8900_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -953- MOVE '990' TO WNR-EXEC-SQL. */
            _.Move("990", WABEND.WNR_EXEC_SQL);

            /*" -955- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_REL);

            /*" -956- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA. */
            _.Move(AREA_DE_WORK.FILLER_12.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -957- MOVE WDAT-REL-MES TO WDAT-LIT-MES. */
            _.Move(AREA_DE_WORK.FILLER_12.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -959- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO. */
            _.Move(AREA_DE_WORK.FILLER_12.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -960- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -961- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -962- DISPLAY '*   AC0217B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0217B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -963- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -964- DISPLAY '*               S I N I S T R O S          *' . */
            _.Display($"*               S I N I S T R O S          *");

            /*" -965- DISPLAY '*               ----------------           *' . */
            _.Display($"*               ----------------           *");

            /*" -966- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -967- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA    *' . */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA    *");

            /*" -969- DISPLAY '*              ' WDAT-REL-LIT '                    *' . */

            $"*              {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -970- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -970- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -985- CLOSE ACOCORR. */
            ACOCORR.Close();

            /*" -987- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -989- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -989- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -993- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -993- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}