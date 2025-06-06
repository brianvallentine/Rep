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
using Sias.Loterico.DB2.LT2118S;

namespace Code
{
    public class LT2118S
    {
        public bool IsCall { get; set; }

        public LT2118S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA  ...............  LOTERICOS                          *      */
        /*"      *   PROGRAMA ...............  LT2118S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  EDUARDO (PRODEXTER)                *      */
        /*"      *   PROGRAMADOR ............  ABNER   (PRODEXTER)                *      */
        /*"      *   DATA CODIFICACAO .......  FEVEREIRO / 2004                   *      */
        /*"      *   VERSAO .................  V.6 - 25092021 23:50HS JAZZ-313768 *      */
        /*"      *   VERSAO .................  V.5 - 24062021 08:14HS             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                 CALCULA O PREMIO PRO-RATA OU PRAZO   *      */
        /*"      *                           CURTO PARA A PROPOSTA DE ENDOSSO     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01       HOST-COUNT                    PIC S9(004)       COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WS-IND                        PIC S9(004)       COMP.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WTEM-APOLICES                 PIC  X(001) VALUE SPACES.*/
        public StringBasis WTEM_APOLICES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01       WS-DISPLAY                    PIC  X(001) VALUE 'S'   .*/
        public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
        /*"01       WS-VERSAO                     PIC  X(120) VALUE        'LT2118S - VERSAO: V.6 - 25092021 23:50HS - INCLUSAO DE        'NOVOS CAMPOS           '.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT2118S - VERSAO: V.6 - 25092021 23:50HS - INCLUSAO DE        ");
        /*"01       WS-VERSAO-V5                  PIC  X(120) VALUE        'LT2118S - VERSAO: V5 - 24062021 08:14HS  - AJUSTE QTD PC        'L PARA VIGENCIA PLURI  '.*/
        public StringBasis WS_VERSAO_V5 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT2118S - VERSAO: V5 - 24062021 08:14HS  - AJUSTE QTD PC        ");
        /*"01       WS-VERSAO-V4                  PIC  X(120) VALUE        'LT2118S - VERSAO: V4 - 12022021 04:57HS  - AJUSTE QTD PC        'L PARA VIGENCIA PLURI  '.*/
        public StringBasis WS_VERSAO_V4 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT2118S - VERSAO: V4 - 12022021 04:57HS  - AJUSTE QTD PC        ");
        /*"01       WS-VERSAO-V3                  PIC  X(120) VALUE        'LT2118S - VERSAO: V3 - 11042013 08:35HS  - AJUSTE DESCON        'TOS DO PREMIO LIQUIDO  '.*/
        public StringBasis WS_VERSAO_V3 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT2118S - VERSAO: V3 - 11042013 08:35HS  - AJUSTE DESCON        ");
        /*"01       WS-VERSAO-V2                  PIC  X(120) VALUE        'LT2118S - VERSAO: V2 - 24112011 07:14HS  - CAD61050  -        'REN 2012  '.*/
        public StringBasis WS_VERSAO_V2 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT2118S - VERSAO: V2 - 24112011 07:14HS  - CAD61050  -        ");
        /*"01       WS-VERSAO-V1                  PIC  X(120) VALUE        'LT2118S - VERSAO: V1 - 08042011 17:38HS  - CAD52889        'INCLUIDO - DESCONTO COFRE '.*/
        public StringBasis WS_VERSAO_V1 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT2118S - VERSAO: V1 - 08042011 17:38HS  - CAD52889        ");
        /*"01       WS-VERSAO-V0                  PIC  X(060) VALUE        'LT2118S - VERSAO: V0 -17062010 10:35HS'.*/
        public StringBasis WS_VERSAO_V0 { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"LT2118S - VERSAO: V0 -17062010 10:35HS");
        /*"01       WS-PCT-DESCONTOS              PIC S9(003)V9999  COMP-3.*/
        public DoubleBasis WS_PCT_DESCONTOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"01       WS-VAL-JUROS-TOT              PIC S9(013)V99    COMP-3.*/
        public DoubleBasis WS_VAL_JUROS_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       WS-PRM-TARIFARIO-TOTAL        PIC S9(013)V99    COMP-3.*/
        public DoubleBasis WS_PRM_TARIFARIO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       WS-PRM-TARIFARIO-1PCL         PIC S9(013)V99    COMP-3.*/
        public DoubleBasis WS_PRM_TARIFARIO_1PCL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       WS-CUSTO-EMISSAO-1            PIC S9(010)V9999  COMP-3.*/
        public DoubleBasis WS_CUSTO_EMISSAO_1 { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9999"), 4);
        /*"01       WS-MSG-PARCELAS.*/
        public LT2118S_WS_MSG_PARCELAS WS_MSG_PARCELAS { get; set; } = new LT2118S_WS_MSG_PARCELAS();
        public class LT2118S_WS_MSG_PARCELAS : VarBasis
        {
            /*"  05     FILLER           PIC  X(054)  VALUE 'QTDE DE PARCELAS IN        'FORMADA SUPERA O MAXIMO PERMITIDO: '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"QTDE DE PARCELAS IN        ");
            /*"  05     WS-QTD-PARCELAS  PIC  99.*/
            public IntBasis WS_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"01       WS-DATA-DB2.*/
        }
        public LT2118S_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new LT2118S_WS_DATA_DB2();
        public class LT2118S_WS_DATA_DB2 : VarBasis
        {
            /*"  05     WS-ANO-DB2       PIC  9(004)          VALUE ZEROS.*/
            public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     FILLER           PIC  X(001)          VALUE '-'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     WS-MES-DB2       PIC  9(002)          VALUE ZEROS.*/
            public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     FILLER           PIC  X(001)          VALUE '-'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     WS-DIA-DB2       PIC  9(002)          VALUE ZEROS.*/
            public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01       WS-DATA-DMA.*/
        }
        public LT2118S_WS_DATA_DMA WS_DATA_DMA { get; set; } = new LT2118S_WS_DATA_DMA();
        public class LT2118S_WS_DATA_DMA : VarBasis
        {
            /*"  05     WS-DIA-DMA       PIC  9(002)          VALUE ZEROS.*/
            public IntBasis WS_DIA_DMA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     WS-MES-DMA       PIC  9(002)          VALUE ZEROS.*/
            public IntBasis WS_MES_DMA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     WS-ANO-DMA       PIC  9(004)          VALUE ZEROS.*/
            public IntBasis WS_ANO_DMA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01       WS-DATA-AUX      PIC  X(010)          VALUE SPACES.*/
        }
        public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01       WS-DATA-BASE     PIC  X(010)          VALUE SPACES.*/
        public StringBasis WS_DATA_BASE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01       WS-INTEIRO       PIC  9(004)          VALUE ZEROS.*/
        public IntBasis WS_INTEIRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01       WS-RESTO         PIC  9(004)          VALUE ZEROS.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01       WS-DIA-BASE      PIC  9(002)          VALUE ZEROS.*/
        public IntBasis WS_DIA_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01       WS-ULTIMO-DIA    PIC  9(002)          VALUE ZEROS.*/
        public IntBasis WS_ULTIMO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01       TAB-FATOR-MENSAL.*/
        public LT2118S_TAB_FATOR_MENSAL TAB_FATOR_MENSAL { get; set; } = new LT2118S_TAB_FATOR_MENSAL();
        public class LT2118S_TAB_FATOR_MENSAL : VarBasis
        {
            /*"  05     FILLER           PIC  X(012)       VALUE '011367628000'*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"011367628000");
            /*"  05     FILLER           PIC  X(012)       VALUE '005853431000'*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"005853431000");
            /*"  05     FILLER           PIC  X(012)       VALUE '003940985000'*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"003940985000");
            /*"  05     FILLER           PIC  X(012)       VALUE '002970395000'*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"002970395000");
            /*"  05     FILLER           PIC  X(012)       VALUE '002383388000'*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"002383388000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001990099000'*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001990099000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001708218000'*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001708218000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001496281000'*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001496281000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001331128000'*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001331128000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001198809000'*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001198809000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001090417000'*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001090417000");
            /*"  05     FILLER           PIC  X(012)       VALUE '001000000000'*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"001000000000");
            /*"01       FILLER           REDEFINES         TAB-FATOR-MENSAL.*/
        }
        private _REDEF_LT2118S_FILLER_15 _filler_15 { get; set; }
        public _REDEF_LT2118S_FILLER_15 FILLER_15
        {
            get { _filler_15 = new _REDEF_LT2118S_FILLER_15(); _.Move(TAB_FATOR_MENSAL, _filler_15); VarBasis.RedefinePassValue(TAB_FATOR_MENSAL, _filler_15, TAB_FATOR_MENSAL); _filler_15.ValueChanged += () => { _.Move(_filler_15, TAB_FATOR_MENSAL); }; return _filler_15; }
            set { VarBasis.RedefinePassValue(value, _filler_15, TAB_FATOR_MENSAL); }
        }  //Redefines
        public class _REDEF_LT2118S_FILLER_15 : VarBasis
        {
            /*"  05     TAB-FATOR        PIC  9(003)V9(9)  OCCURS 12 TIMES.*/
            public ListBasis<DoubleBasis, double> TAB_FATOR { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "3", "9(003)V9(9)"), 12);
            /*"01       WABEND.*/

            public _REDEF_LT2118S_FILLER_15()
            {
                TAB_FATOR.ValueChanged += OnValueChanged;
            }

        }
        public LT2118S_WABEND WABEND { get; set; } = new LT2118S_WABEND();
        public class LT2118S_WABEND : VarBasis
        {
            /*"  05     FILLER                        PIC  X(008)  VALUE                                                      'LT2118S '*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LT2118S ");
            /*"  05     FILLER                        PIC  X(025)  VALUE                                     '*** ERRO EXEC SQL NUMERO '*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL                  PIC  X(004)  VALUE SPACES*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05     FILLER                        PIC  X(013)  VALUE                                                 ' *** SQLCODE '*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE                      PIC  ZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
            /*"01       WAREA-PROSOCU1.*/
        }
        public LT2118S_WAREA_PROSOCU1 WAREA_PROSOCU1 { get; set; } = new LT2118S_WAREA_PROSOCU1();
        public class LT2118S_WAREA_PROSOCU1 : VarBasis
        {
            /*"  05     WAREA-DATA-E.*/
            public LT2118S_WAREA_DATA_E WAREA_DATA_E { get; set; } = new LT2118S_WAREA_DATA_E();
            public class LT2118S_WAREA_DATA_E : VarBasis
            {
                /*"    10   WAREA-DIA-E      PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WAREA_DIA_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10   WAREA-MES-E      PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WAREA_MES_E { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10   WAREA-ANO-E      PIC  9(004)          VALUE ZEROS.*/
                public IntBasis WAREA_ANO_E { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05     WAREA-QTD-DIAS   PIC S9(005)  COMP-3  VALUE ZEROS.*/
            }
            public IntBasis WAREA_QTD_DIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  05     WAREA-DATA-S.*/
            public LT2118S_WAREA_DATA_S WAREA_DATA_S { get; set; } = new LT2118S_WAREA_DATA_S();
            public class LT2118S_WAREA_DATA_S : VarBasis
            {
                /*"    10   WAREA-DIA-S      PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WAREA_DIA_S { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10   WAREA-MES-S      PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WAREA_MES_S { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10   WAREA-ANO-S      PIC  9(004)          VALUE ZEROS.*/
                public IntBasis WAREA_ANO_S { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"01       EM0925W099.*/
            }
        }
        public LT2118S_EM0925W099 EM0925W099 { get; set; } = new LT2118S_EM0925W099();
        public class LT2118S_EM0925W099 : VarBasis
        {
            /*"  05     EM0925-DATA01    PIC  9(008).*/
            public IntBasis EM0925_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05     EM0925-DATA02    PIC  9(008).*/
            public IntBasis EM0925_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05     EM0925-QTMES     PIC  S9(005)    COMP-3.*/
            public IntBasis EM0925_QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }


        public Copies.LBLT3250 LBLT3250 { get; set; } = new Copies.LBLT3250();
        public Copies.LBLT2118 LBLT2118 { get; set; } = new Copies.LBLT2118();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT2118_LT2118S_AREA_PARAMETROS LBLT2118_LT2118S_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT2118S_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT2118.LT2118S_AREA_PARAMETROS = LBLT2118_LT2118S_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT2118.LT2118S_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -174- MOVE LT2118S-CUSTO-EMISSAO-1 TO WS-CUSTO-EMISSAO-1 */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1, WS_CUSTO_EMISSAO_1);

            /*" -177- INITIALIZE LT2118S-SAIDA-PARCELA1 LT2118S-SAIDA-PARCELAN LT2118S-SAIDA-ERRO */
            _.Initialize(
                LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1
                , LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN
                , LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO
            );

            /*" -179- MOVE WS-CUSTO-EMISSAO-1 TO LT2118S-CUSTO-EMISSAO-1 */
            _.Move(WS_CUSTO_EMISSAO_1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1);

            /*" -181- PERFORM R1000-00-CONSISTE-PARAMETRO */

            R1000_00_CONSISTE_PARAMETRO_SECTION();

            /*" -182- IF LT2118S-COD-RETORNO EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO == 00)
            {

                /*" -183- PERFORM R2000-00-PROCESSA-CALCULO */

                R2000_00_PROCESSA_CALCULO_SECTION();

                /*" -185- END-IF */
            }


            /*" -186- PERFORM R0100-00-FINALIZAR */

            R0100_00_FINALIZAR_SECTION();

            /*" -186- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-FINALIZAR-SECTION */
        private void R0100_00_FINALIZAR_SECTION()
        {
            /*" -194- IF WS-DISPLAY EQUAL 'S' */

            if (WS_DISPLAY == "S")
            {

                /*" -195- DISPLAY WS-VERSAO(1:50) */
                _.Display(WS_VERSAO.Substring(1, 50));

                /*" -201- DISPLAY 'COD-MOV:' LT2118S-COD-MOVIMENTO ' APOL:' LT2118S-NUM-APOLICE ' INIVIG:' LT2118S-DATA-INIVIGENCIA ' QTDPCL:' LT2118S-QTD-PARCELAS ' TIPO-CALC:' LT2118S-TIPO-CALCULO ' ISENTAC:' LT2118S-ISENTA-CUSTO */

                $"COD-MOV:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO} APOL:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE} INIVIG:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA} QTDPCL:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS} TIPO-CALC:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_TIPO_CALCULO} ISENTAC:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO}"
                .Display();

                /*" -204- DISPLAY 'PRMTARTOT:' LT2118S-PRM-TARIFARIO-TOTAL ' TOT-DESC:' LT2118S-VL-DESCONTO-TOTAL ' PRM-LIQ :' LT2118S-PRM-LIQUIDO */

                $"PRMTARTOT:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL} TOT-DESC:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_VL_DESCONTO_TOTAL} PRM-LIQ :{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_PRM_LIQUIDO}"
                .Display();

                /*" -213- DISPLAY 'DESC-AGRUP:' LT2118S-DESC-AGRUP ' DESC-EXP :' LT2118S-DESC-EXP ' DESC-EXP-I:' LT2118S-DESC-EXP-INFO ' DESC-FIDEL:' LT2118S-DESC-FIDEL ' ESC-FIDEL-I:' LT2118S-DESC-FIDEL-INFO ' DESC-COFRE:' LT2118S-DESC-COFRE ' DESC-BLIND:' LT2118S-DESC-BLINDAGEM */

                $"DESC-AGRUP:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_AGRUP} DESC-EXP :{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_EXP} DESC-EXP-I:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_EXP_INFO} DESC-FIDEL:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_FIDEL} ESC-FIDEL-I:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_FIDEL_INFO} DESC-COFRE:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_COFRE} DESC-BLIND:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_BLINDAGEM}"
                .Display();

                /*" -220- DISPLAY 'PRMTAR1:' LT2118S-PRM-TARIFARIO-1PCL ' TAR-1=' LT2118S-PRM-TARIFARIO-1 ' LIQ-1=' LT2118S-PRM-LIQUIDO-1 ' JUR-1=' LT2118S-ADICIONAL-FRACIO-1 ' CUS-1=' LT2118S-CUSTO-EMISSAO-1 ' IOF-1=' LT2118S-VAL-IOCC-1 ' TOT-1=' LT2118S-PRM-TOTAL-1 */

                $"PRMTAR1:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL} TAR-1={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1} LIQ-1={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1} JUR-1={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1} CUS-1={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1} IOF-1={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_VAL_IOCC_1} TOT-1={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TOTAL_1}"
                .Display();

                /*" -226- DISPLAY 'PRMTAR-N=' LT2118S-PRM-TARIFARIO-N ' LIQ-N=' LT2118S-PRM-LIQUIDO-N ' JUR-N=' LT2118S-ADICIONAL-FRACIO-N ' CUS-N=' LT2118S-CUSTO-EMISSAO-N ' IOF-N=' LT2118S-VAL-IOCC-N ' TOT-N=' LT2118S-PRM-TOTAL-N */

                $"PRMTAR-N={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TARIFARIO_N} LIQ-N={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_LIQUIDO_N} JUR-N={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_ADICIONAL_FRACIO_N} CUS-N={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_CUSTO_EMISSAO_N} IOF-N={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_VAL_IOCC_N} TOT-N={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TOTAL_N}"
                .Display();

                /*" -228- DISPLAY 'RET=' LT2118S-COD-RETORNO 'MSG=' LT2118S-MSG-RETORNO */

                $"RET={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO}MSG={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO}"
                .Display();

                /*" -230- END-IF */
            }


            /*" -231- GOBACK */

            throw new GoBack();

            /*" -231- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-CONSISTE-PARAMETRO-SECTION */
        private void R1000_00_CONSISTE_PARAMETRO_SECTION()
        {
            /*" -239- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -241- IF LT2118S-COD-MOVIMENTO NOT EQUAL 'A' AND 'C' AND 'T' */

            if (!LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO.In("A", "C", "T"))
            {

                /*" -243- MOVE 'LT2118S - CODIGO DO MOVIMENTO INVALIDO' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - CODIGO DO MOVIMENTO INVALIDO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -244- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -245- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -247- END-IF */
            }


            /*" -248- IF LT2118S-NUM-APOLICE EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE == 00)
            {

                /*" -250- MOVE 'LT2118S - NUMERO DA APOLICE NAO INFORMADO' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - NUMERO DA APOLICE NAO INFORMADO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -251- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -252- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -254- END-IF */
            }


            /*" -255- IF LT2118S-NUM-CLASSE EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_CLASSE == 00)
            {

                /*" -257- MOVE 'LT2118S - CLASSE DE ADESAO NAO INFORMADA' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - CLASSE DE ADESAO NAO INFORMADA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -258- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -259- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -261- END-IF */
            }


            /*" -262- IF LT2118S-IND-REGIAO EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_IND_REGIAO == 00)
            {

                /*" -264- MOVE 'LT2118S - COD REGIAO NAO INFORMADO' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - COD REGIAO NAO INFORMADO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -265- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -266- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -271- END-IF */
            }


            /*" -272- IF LT2118S-TIPO-CALCULO NOT EQUAL 0 AND 1 */

            if (!LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_TIPO_CALCULO.In("0", "1"))
            {

                /*" -274- MOVE 'LT2118S - TIPO DE CALCULO INFORMADO' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - TIPO DE CALCULO INFORMADO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -275- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -276- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -278- END-IF */
            }


            /*" -280- IF LT2118S-DATA-INIVIGENCIA EQUAL SPACES */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA.IsEmpty())
            {

                /*" -282- MOVE 'LT2118S - INICIO DE VIGENCIA DO ENDOSSO NAO INFORMADO' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - INICIO DE VIGENCIA DO ENDOSSO NAO INFORMADO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -283- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -284- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -288- END-IF */
            }


            /*" -289- IF LT2118S-QTD-PARCELAS EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS == 00)
            {

                /*" -291- MOVE 'LT2118S - QTDE DE PARCELAS NAO INFORMADA' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - QTDE DE PARCELAS NAO INFORMADA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -292- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -293- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -295- END-IF */
            }


            /*" -296- IF LT2118S-ISENTA-CUSTO NOT = 'S' AND 'N' */

            if (!LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO.In("S", "N"))
            {

                /*" -299- MOVE 'LT2118S - INDICADOR DE ISENCAO DE CUSTODEVE SER S OU N' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - INDICADOR DE ISENCAO DE CUSTODEVE SER S OU N", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -300- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -301- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -303- END-IF */
            }


            /*" -304- MOVE LT2118S-NUM-APOLICE TO APOLICES-NUM-APOLICE */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -309- PERFORM R1100-00-LE-APOLICES */

            R1100_00_LE_APOLICES_SECTION();

            /*" -311- IF WTEM-APOLICES EQUAL 'N' OR ENDOSSOS-SIT-REGISTRO EQUAL '2' */

            if (WTEM_APOLICES == "N" || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO == "2")
            {

                /*" -313- MOVE 'LT21118S - APOLICE NAO CADASTRADA OU CANCELADA' TO LT2118S-MSG-RETORNO */
                _.Move("LT21118S - APOLICE NAO CADASTRADA OU CANCELADA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -314- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -315- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -320- END-IF */
            }


            /*" -321- PERFORM R1110-00-CONSISTIR-QTDTERVIG */

            R1110_00_CONSISTIR_QTDTERVIG_SECTION();

            /*" -322- IF LT2118S-COD-RETORNO GREATER THAN ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO > 00)
            {

                /*" -323- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -328- END-IF */
            }


            /*" -330- IF APOLICES-COD-PRODUTO NOT EQUAL 1803 AND 1805 */

            if (!APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.In("1803", "1805"))
            {

                /*" -332- MOVE 'LT2118S - APOLICE NAO PERTENCE AO PRODUTO DO LOTERICO OU CCA' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - APOLICE NAO PERTENCE AO PRODUTO DO LOTERICO OU CCA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -333- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -334- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -339- END-IF */
            }


            /*" -342- IF LT2118S-DATA-INIVIGENCIA GREATER ENDOSSOS-DATA-TERVIGENCIA */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -345- MOVE 'LT2118S - INICIO DE VIGENCIA DO MOVIMENTO NAO PODE SER SUPERIOR AO FIM DE VIGENCIA DA APOLICE' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - INICIO DE VIGENCIA DO MOVIMENTO NAO PODE SER SUPERIOR AO FIM DE VIGENCIA DA APOLICE", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -346- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -347- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -349- END-IF */
            }


            /*" -354- PERFORM R1200-00-LE-ULTIMO-ENDOSSO */

            R1200_00_LE_ULTIMO_ENDOSSO_SECTION();

            /*" -357- IF LT2118S-DATA-INIVIGENCIA NOT GREATER ENDOSSOS-DATA-INIVIGENCIA */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA <= ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA)
            {

                /*" -359- MOVE 'INICIO DE VIGENCIA DEVE SER SUPERIOR AO DO ULTIMOENDOSSO ' TO LT2118S-MSG-RETORNO */
                _.Move("INICIO DE VIGENCIA DEVE SER SUPERIOR AO DO ULTIMOENDOSSO ", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -360- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -361- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -372- END-IF */
            }


            /*" -373- IF LT2118S-COD-MOVIMENTO EQUAL 'A' */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO == "A")
            {

                /*" -376- IF LT2118S-PRM-TARIFARIO-TOTAL GREATER ZEROS */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL > 00)
                {

                    /*" -377- IF LT2118S-QTD-PARCELAS GREATER 50 */

                    if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS > 50)
                    {

                        /*" -380- MOVE 'LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 50 PARA ENDOSSOS DE COBRANCA' TO LT2118S-MSG-RETORNO */
                        _.Move("LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 50 PARA ENDOSSOS DE COBRANCA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                        /*" -381- MOVE 1 TO LT2118S-COD-RETORNO */
                        _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                        /*" -382- PERFORM R0100-00-FINALIZAR */

                        R0100_00_FINALIZAR_SECTION();

                        /*" -383- END-IF */
                    }


                    /*" -384- ELSE */
                }
                else
                {


                    /*" -386- IF LT2118S-PRM-TARIFARIO-TOTAL LESS ZEROS */

                    if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL < 00)
                    {

                        /*" -387- IF LT2118S-QTD-PARCELAS GREATER 50 */

                        if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS > 50)
                        {

                            /*" -390- MOVE 'LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 50 PARA ENDOSSOS DE RESTITUICAO' TO LT2118S-MSG-RETORNO */
                            _.Move("LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 50 PARA ENDOSSOS DE RESTITUICAO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                            /*" -391- MOVE 1 TO LT2118S-COD-RETORNO */
                            _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                            /*" -392- PERFORM R0100-00-FINALIZAR */

                            R0100_00_FINALIZAR_SECTION();

                            /*" -393- END-IF */
                        }


                        /*" -394- ELSE */
                    }
                    else
                    {


                        /*" -395- IF LT2118S-QTD-PARCELAS NOT EQUAL 1 */

                        if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS != 1)
                        {

                            /*" -398- MOVE 'LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 1 PARA ENDOSSOS SEM MOVIMENTO' TO LT2118S-MSG-RETORNO */
                            _.Move("LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 1 PARA ENDOSSOS SEM MOVIMENTO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                            /*" -399- MOVE 1 TO LT2118S-COD-RETORNO */
                            _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                            /*" -400- PERFORM R0100-00-FINALIZAR */

                            R0100_00_FINALIZAR_SECTION();

                            /*" -401- END-IF */
                        }


                        /*" -402- ELSE */
                    }

                }

            }
            else
            {


                /*" -403- IF LT2118S-QTD-PARCELAS NOT EQUAL 1 */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS != 1)
                {

                    /*" -406- MOVE 'LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 1 PARA CANCELAMENTO OU TRANSFERENCIA' TO LT2118S-MSG-RETORNO */
                    _.Move("LT2118S - QTDE DE PARCELAS NAO PODE SER SUPERIORA 1 PARA CANCELAMENTO OU TRANSFERENCIA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -407- MOVE 1 TO LT2118S-COD-RETORNO */
                    _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -412- PERFORM R0100-00-FINALIZAR . */

                    R0100_00_FINALIZAR_SECTION();
                }

            }


            /*" -413- IF LT2118S-COD-MOVIMENTO EQUAL 'A' */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO == "A")
            {

                /*" -416- IF LT2118S-ISENTA-CUSTO EQUAL 'N' AND LT2118S-PRM-TARIFARIO-TOTAL LESS THAN ZEROS */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO == "N" && LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL < 00)
                {

                    /*" -419- MOVE 'LT2118S - INDICADOR DE ISENCAO DE CUSTO INVALIDOPARA ENDOSSOS DE RESTITUICAO OU SEM MOVIMENTO' TO LT2118S-MSG-RETORNO */
                    _.Move("LT2118S - INDICADOR DE ISENCAO DE CUSTO INVALIDOPARA ENDOSSOS DE RESTITUICAO OU SEM MOVIMENTO", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -420- MOVE 1 TO LT2118S-COD-RETORNO */
                    _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -421- PERFORM R0100-00-FINALIZAR */

                    R0100_00_FINALIZAR_SECTION();

                    /*" -422- END-IF */
                }


                /*" -423- ELSE */
            }
            else
            {


                /*" -424- IF LT2118S-ISENTA-CUSTO EQUAL 'N' */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO == "N")
                {

                    /*" -427- MOVE 'LT2118S - INDICADOR DE ISENCAO DE CUSTO INVALIDOPARA MOVIMENTOS DE CANCELAMENTO OU TRANSFERENCIA' TO LT2118S-MSG-RETORNO */
                    _.Move("LT2118S - INDICADOR DE ISENCAO DE CUSTO INVALIDOPARA MOVIMENTOS DE CANCELAMENTO OU TRANSFERENCIA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -428- MOVE 1 TO LT2118S-COD-RETORNO */
                    _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -429- PERFORM R0100-00-FINALIZAR . */

                    R0100_00_FINALIZAR_SECTION();
                }

            }


            /*" -429- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-APOLICES-SECTION */
        private void R1100_00_LE_APOLICES_SECTION()
        {
            /*" -439- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WABEND.WNR_EXEC_SQL);

            /*" -453- PERFORM R1100_00_LE_APOLICES_DB_SELECT_1 */

            R1100_00_LE_APOLICES_DB_SELECT_1();

            /*" -456- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -457- MOVE 'N' TO WTEM-APOLICES */
                _.Move("N", WTEM_APOLICES);

                /*" -458- ELSE */
            }
            else
            {


                /*" -459- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -461- MOVE 'LT2118S - PROBLEMAS NO SELECT APOLICES/ENDOSSOS' TO LT2118S-MSG-RETORNO */
                    _.Move("LT2118S - PROBLEMAS NO SELECT APOLICES/ENDOSSOS", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -462- MOVE 01 TO LT2118S-COD-RETORNO */
                    _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -462- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1100-00-LE-APOLICES-DB-SELECT-1 */
        public void R1100_00_LE_APOLICES_DB_SELECT_1()
        {
            /*" -453- EXEC SQL SELECT A.COD_PRODUTO, B.SIT_REGISTRO, B.DATA_TERVIGENCIA, A.PCT_IOCC INTO :APOLICES-COD-PRODUTO, :ENDOSSOS-SIT-REGISTRO, :ENDOSSOS-DATA-TERVIGENCIA, :APOLICES-PCT-IOCC FROM SEGUROS.APOLICES A, SEGUROS.ENDOSSOS B WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE AND B.NUM_ENDOSSO = 0 AND A.NUM_APOLICE = B.NUM_APOLICE END-EXEC. */

            var r1100_00_LE_APOLICES_DB_SELECT_1_Query1 = new R1100_00_LE_APOLICES_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1100_00_LE_APOLICES_DB_SELECT_1_Query1.Execute(r1100_00_LE_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.APOLICES_PCT_IOCC, APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-CONSISTIR-QTDTERVIG-SECTION */
        private void R1110_00_CONSISTIR_QTDTERVIG_SECTION()
        {
            /*" -473- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", WABEND.WNR_EXEC_SQL);

            /*" -484- MOVE LT2118S-DATA-INIVIGENCIA TO WS-DATA-AUX. */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA, WS_DATA_AUX);

            /*" -489- PERFORM R1110_00_CONSISTIR_QTDTERVIG_DB_SELECT_1 */

            R1110_00_CONSISTIR_QTDTERVIG_DB_SELECT_1();

            /*" -494- IF SQLCODE NOT EQUAL TO ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -496- MOVE 'LT2118S - R1100- ERRO SOMAR DATA ' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - R1100- ERRO SOMAR DATA ", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -497- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -499- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -500- IF WS-DATA-AUX > ENDOSSOS-DATA-TERVIGENCIA */

            if (WS_DATA_AUX > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -501- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -503- MOVE 'LT2118S - QTD DE PARCELAS SUPERIOR A PERMITIDA PARA VIGENCIA DA APOLICE ' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - QTD DE PARCELAS SUPERIOR A PERMITIDA PARA VIGENCIA DA APOLICE ", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -504- DISPLAY LT2118S-MSG-RETORNO */
                _.Display(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -508- DISPLAY ' LT2118S-APO =' LT2118S-NUM-APOLICE ' DTTERAPO=' ENDOSSOS-DATA-TERVIGENCIA ' DTINIMOV=' LT2118S-DATA-INIVIGENCIA ' DTTERMOV=' WS-DATA-AUX ' QTD=' LT2118S-QTD-PARCELAS. */

                $" LT2118S-APO ={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE} DTTERAPO={ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA} DTINIMOV={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA} DTTERMOV={WS_DATA_AUX} QTD={LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS}"
                .Display();
            }


        }

        [StopWatch]
        /*" R1110-00-CONSISTIR-QTDTERVIG-DB-SELECT-1 */
        public void R1110_00_CONSISTIR_QTDTERVIG_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT DATE(:WS-DATA-AUX) + :LT2118S-QTD-PARCELAS MONTHS + 7 DAYS INTO :WS-DATA-AUX FROM SYSIBM.SYSDUMMY1 END-EXEC */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:WS-DATA-AUX) + :LT2118S-QTD-PARCELAS MONTHS
            /*--+ 7 DAYS
            /*--INTO :WS-DATA-AUX
            /*--FROM SYSIBM.SYSDUMMY1
            /*--END-EXEC
            /*-- */

            _.Move(WS_DATA_AUX.ToDateTime().ToString(_.CurrentDateFormat), WS_DATA_AUX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-LE-ULTIMO-ENDOSSO-SECTION */
        private void R1200_00_LE_ULTIMO_ENDOSSO_SECTION()
        {
            /*" -518- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WABEND.WNR_EXEC_SQL);

            /*" -524- PERFORM R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1 */

            R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1();

            /*" -527- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -529- MOVE 'LT2118S - PROBLEMAS NO MAX ENDOSSOS' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - PROBLEMAS NO MAX ENDOSSOS", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -530- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -530- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-LE-ULTIMO-ENDOSSO-DB-SELECT-1 */
        public void R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1()
        {
            /*" -524- EXEC SQL SELECT MAX(DATA_INIVIGENCIA) INTO :ENDOSSOS-DATA-INIVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE AND SIT_REGISTRO IN ( '0' , '1' ) END-EXEC. */

            var r1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1 = new R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1.Execute(r1200_00_LE_ULTIMO_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-OBTER-COEFICIENTES-SECTION */
        private void R1300_00_OBTER_COEFICIENTES_SECTION()
        {
            /*" -547- MOVE LT2118S-NUM-CLASSE TO LT3250-NUM-CLASSE */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_CLASSE, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_NUM_CLASSE);

            /*" -548- MOVE LT2118S-IND-REGIAO TO LT3250-COD-REGIAO */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_IND_REGIAO, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_REGIAO);

            /*" -550- MOVE LT2118S-DATA-INIVIGENCIA TO LT3250-DTINIVIG */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG);

            /*" -551- MOVE SPACES TO LT3250-DTTERVIG */
            _.Move("", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTTERVIG);

            /*" -552- MOVE ZEROS TO LT3250-COD-RETORNO */
            _.Move(0, LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO);

            /*" -554- MOVE SPACES TO LT3250-MENSAGEM */
            _.Move("", LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM);

            /*" -556- CALL 'LT3250S' USING LT3250-AREA-PARAMETROS. */
            _.Call("LT3250S", LBLT3250.LT3250_AREA_PARAMETROS);

            /*" -557- IF LT3250-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO != 00)
            {

                /*" -558- MOVE 1 TO LT2118S-COD-RETORNO */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -559- MOVE LT3250-MENSAGEM TO LT2118S-MSG-RETORNO */
                _.Move(LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -561- DISPLAY 'R1300-ERRO CALL LT3250S COD=' LT3250-COD-RETORNO '/' LT3250-MENSAGEM */

                $"R1300-ERRO CALL LT3250S COD={LBLT3250.LT3250_AREA_PARAMETROS.LT3250_COD_RETORNO}/{LBLT3250.LT3250_AREA_PARAMETROS.LT3250_MENSAGEM}"
                .Display();

                /*" -562- PERFORM R0100-00-FINALIZAR */

                R0100_00_FINALIZAR_SECTION();

                /*" -563- END-IF */
            }


            /*" -563- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-CALCULO-SECTION */
        private void R2000_00_PROCESSA_CALCULO_SECTION()
        {
            /*" -572- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -590- PERFORM R2100-00-LE-SISTEMAS */

            R2100_00_LE_SISTEMAS_SECTION();

            /*" -593- IF LT2118S-COD-MOVIMENTO EQUAL 'C' OR 'T' OR LT2118S-PRM-TARIFARIO-TOTAL NOT LESS ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO.In("C", "T") || LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL >= 00)
            {

                /*" -594- PERFORM R2200-00-CALCULA-DATAS */

                R2200_00_CALCULA_DATAS_SECTION();

                /*" -595- PERFORM R2300-00-CALCULA-MESES */

                R2300_00_CALCULA_MESES_SECTION();

                /*" -596- ELSE */
            }
            else
            {


                /*" -597- PERFORM R2400-00-VERIFICA-APOLICE */

                R2400_00_VERIFICA_APOLICE_SECTION();

                /*" -599- END-IF */
            }


            /*" -600- IF LT2118S-COD-RETORNO EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO == 00)
            {

                /*" -601- PERFORM R1300-00-OBTER-COEFICIENTES */

                R1300_00_OBTER_COEFICIENTES_SECTION();

                /*" -602- PERFORM R2500-00-CALCULA-PARCELAS */

                R2500_00_CALCULA_PARCELAS_SECTION();

                /*" -603- END-IF */
            }


            /*" -603- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-SISTEMAS-SECTION */
        private void R2100_00_LE_SISTEMAS_SECTION()
        {
            /*" -613- MOVE 'R2100' TO WNR-EXEC-SQL. */
            _.Move("R2100", WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R2100_00_LE_SISTEMAS_DB_SELECT_1 */

            R2100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -623- MOVE 'LT2118S - PROBLEMAS NO SELECT SISTEMAS' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - PROBLEMAS NO SELECT SISTEMAS", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -624- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -624- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R2100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -618- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' END-EXEC. */

            var r2100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R2100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R2100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r2100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-CALCULA-DATAS-SECTION */
        private void R2200_00_CALCULA_DATAS_SECTION()
        {
            /*" -635- MOVE 'R2200' TO WNR-EXEC-SQL. */
            _.Move("R2200", WABEND.WNR_EXEC_SQL);

            /*" -636- MOVE SPACES TO WAREA-PROSOCU1 */
            _.Move("", WAREA_PROSOCU1);

            /*" -638- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-DB2 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_DATA_DB2);

            /*" -639- MOVE 7 TO WAREA-QTD-DIAS */
            _.Move(7, WAREA_PROSOCU1.WAREA_QTD_DIAS);

            /*" -643- PERFORM R2210-00-SOMA-DATA */

            R2210_00_SOMA_DATA_SECTION();

            /*" -647- MOVE WS-DIA-DB2 TO WS-DIA-BASE */
            _.Move(WS_DATA_DB2.WS_DIA_DB2, WS_DIA_BASE);

            /*" -651- PERFORM R2220-00-SOMA-1-MES */

            R2220_00_SOMA_1_MES_SECTION();

            /*" -655- PERFORM R2230-00-VERIFICA-ULTIMO-DIA */

            R2230_00_VERIFICA_ULTIMO_DIA_SECTION();

            /*" -659- MOVE WS-DATA-DB2 TO WS-DATA-BASE */
            _.Move(WS_DATA_DB2, WS_DATA_BASE);

            /*" -662- MOVE ENDOSSOS-DATA-TERVIGENCIA TO WS-DATA-DB2 */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WS_DATA_DB2);

            /*" -663- IF WS-DIA-BASE GREATER WS-DIA-DB2 */

            if (WS_DIA_BASE > WS_DATA_DB2.WS_DIA_DB2)
            {

                /*" -664- MOVE WS-DIA-BASE TO WS-DIA-DB2 */
                _.Move(WS_DIA_BASE, WS_DATA_DB2.WS_DIA_DB2);

                /*" -665- SUBTRACT 1 FROM WS-MES-DB2 */
                WS_DATA_DB2.WS_MES_DB2.Value = WS_DATA_DB2.WS_MES_DB2 - 1;

                /*" -666- IF WS-MES-DB2 EQUAL ZEROS */

                if (WS_DATA_DB2.WS_MES_DB2 == 00)
                {

                    /*" -667- MOVE 12 TO WS-MES-DB2 */
                    _.Move(12, WS_DATA_DB2.WS_MES_DB2);

                    /*" -668- SUBTRACT 1 FROM WS-ANO-DB2 */
                    WS_DATA_DB2.WS_ANO_DB2.Value = WS_DATA_DB2.WS_ANO_DB2 - 1;

                    /*" -669- END-IF */
                }


                /*" -670- ELSE */
            }
            else
            {


                /*" -670- MOVE WS-DIA-BASE TO WS-DIA-DB2. */
                _.Move(WS_DIA_BASE, WS_DATA_DB2.WS_DIA_DB2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SOMA-DATA-SECTION */
        private void R2210_00_SOMA_DATA_SECTION()
        {
            /*" -681- MOVE 'R2210-00' TO WNR-EXEC-SQL. */
            _.Move("R2210-00", WABEND.WNR_EXEC_SQL);

            /*" -682- MOVE WS-ANO-DB2 TO WAREA-ANO-E */
            _.Move(WS_DATA_DB2.WS_ANO_DB2, WAREA_PROSOCU1.WAREA_DATA_E.WAREA_ANO_E);

            /*" -683- MOVE WS-MES-DB2 TO WAREA-MES-E */
            _.Move(WS_DATA_DB2.WS_MES_DB2, WAREA_PROSOCU1.WAREA_DATA_E.WAREA_MES_E);

            /*" -685- MOVE WS-DIA-DB2 TO WAREA-DIA-E */
            _.Move(WS_DATA_DB2.WS_DIA_DB2, WAREA_PROSOCU1.WAREA_DATA_E.WAREA_DIA_E);

            /*" -687- CALL 'PROSOCU1' USING WAREA-PROSOCU1 */
            _.Call("PROSOCU1", WAREA_PROSOCU1);

            /*" -688- IF WAREA-DATA-E EQUAL 99999999 */

            if (WAREA_PROSOCU1.WAREA_DATA_E == 99999999)
            {

                /*" -689- DISPLAY ' ' WAREA-PROSOCU1 */
                _.Display($" {WAREA_PROSOCU1}");

                /*" -691- MOVE 'LT2118S - PROBLEMAS NA CHAMADA DA PROSOCU1' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - PROBLEMAS NA CHAMADA DA PROSOCU1", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -692- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -694- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -695- MOVE WAREA-ANO-S TO WS-ANO-DB2 */
            _.Move(WAREA_PROSOCU1.WAREA_DATA_S.WAREA_ANO_S, WS_DATA_DB2.WS_ANO_DB2);

            /*" -696- MOVE WAREA-MES-S TO WS-MES-DB2 */
            _.Move(WAREA_PROSOCU1.WAREA_DATA_S.WAREA_MES_S, WS_DATA_DB2.WS_MES_DB2);

            /*" -697- MOVE WAREA-DIA-S TO WS-DIA-DB2. */
            _.Move(WAREA_PROSOCU1.WAREA_DATA_S.WAREA_DIA_S, WS_DATA_DB2.WS_DIA_DB2);

            /*" -697- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-SOMA-1-MES-SECTION */
        private void R2220_00_SOMA_1_MES_SECTION()
        {
            /*" -709- MOVE 'R2220-00' TO WNR-EXEC-SQL. */
            _.Move("R2220-00", WABEND.WNR_EXEC_SQL);

            /*" -711- ADD 1 TO WS-MES-DB2 */
            WS_DATA_DB2.WS_MES_DB2.Value = WS_DATA_DB2.WS_MES_DB2 + 1;

            /*" -712- IF WS-MES-DB2 GREATER 12 */

            if (WS_DATA_DB2.WS_MES_DB2 > 12)
            {

                /*" -713- MOVE 1 TO WS-MES-DB2 */
                _.Move(1, WS_DATA_DB2.WS_MES_DB2);

                /*" -714- ADD 1 TO WS-ANO-DB2 */
                WS_DATA_DB2.WS_ANO_DB2.Value = WS_DATA_DB2.WS_ANO_DB2 + 1;

                /*" -715- END-IF */
            }


            /*" -715- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-VERIFICA-ULTIMO-DIA-SECTION */
        private void R2230_00_VERIFICA_ULTIMO_DIA_SECTION()
        {
            /*" -727- MOVE 'R2230-00' TO WNR-EXEC-SQL. */
            _.Move("R2230-00", WABEND.WNR_EXEC_SQL);

            /*" -729- IF WS-MES-DB2 EQUAL 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (WS_DATA_DB2.WS_MES_DB2.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -730- MOVE 31 TO WS-ULTIMO-DIA */
                _.Move(31, WS_ULTIMO_DIA);

                /*" -731- ELSE */
            }
            else
            {


                /*" -732- IF WS-MES-DB2 EQUAL 4 OR 6 OR 9 OR 11 */

                if (WS_DATA_DB2.WS_MES_DB2.In("4", "6", "9", "11"))
                {

                    /*" -733- MOVE 30 TO WS-ULTIMO-DIA */
                    _.Move(30, WS_ULTIMO_DIA);

                    /*" -734- ELSE */
                }
                else
                {


                    /*" -737- DIVIDE WS-ANO-DB2 BY 4 GIVING WS-INTEIRO REMAINDER WS-RESTO */
                    _.Divide(WS_DATA_DB2.WS_ANO_DB2, 4, WS_INTEIRO, WS_RESTO);

                    /*" -738- IF WS-RESTO EQUAL ZEROS */

                    if (WS_RESTO == 00)
                    {

                        /*" -739- MOVE 29 TO WS-ULTIMO-DIA */
                        _.Move(29, WS_ULTIMO_DIA);

                        /*" -740- ELSE */
                    }
                    else
                    {


                        /*" -744- MOVE 28 TO WS-ULTIMO-DIA. */
                        _.Move(28, WS_ULTIMO_DIA);
                    }

                }

            }


            /*" -745- IF WS-DIA-DB2 GREATER WS-ULTIMO-DIA */

            if (WS_DATA_DB2.WS_DIA_DB2 > WS_ULTIMO_DIA)
            {

                /*" -746- MOVE WS-ULTIMO-DIA TO WS-DIA-DB2 */
                _.Move(WS_ULTIMO_DIA, WS_DATA_DB2.WS_DIA_DB2);

                /*" -747- END-IF */
            }


            /*" -747- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-CALCULA-MESES-SECTION */
        private void R2300_00_CALCULA_MESES_SECTION()
        {
            /*" -761- MOVE 'R2300-00' TO WNR-EXEC-SQL. */
            _.Move("R2300-00", WABEND.WNR_EXEC_SQL);

            /*" -762- MOVE WS-DIA-DB2 TO WS-DIA-DMA */
            _.Move(WS_DATA_DB2.WS_DIA_DB2, WS_DATA_DMA.WS_DIA_DMA);

            /*" -763- MOVE WS-MES-DB2 TO WS-MES-DMA */
            _.Move(WS_DATA_DB2.WS_MES_DB2, WS_DATA_DMA.WS_MES_DMA);

            /*" -764- MOVE WS-ANO-DB2 TO WS-ANO-DMA */
            _.Move(WS_DATA_DB2.WS_ANO_DB2, WS_DATA_DMA.WS_ANO_DMA);

            /*" -766- MOVE WS-DATA-DMA TO EM0925-DATA02 */
            _.Move(WS_DATA_DMA, EM0925W099.EM0925_DATA02);

            /*" -767- MOVE WS-DATA-BASE TO WS-DATA-DB2 */
            _.Move(WS_DATA_BASE, WS_DATA_DB2);

            /*" -768- MOVE WS-DIA-DB2 TO WS-DIA-DMA */
            _.Move(WS_DATA_DB2.WS_DIA_DB2, WS_DATA_DMA.WS_DIA_DMA);

            /*" -769- MOVE WS-MES-DB2 TO WS-MES-DMA */
            _.Move(WS_DATA_DB2.WS_MES_DB2, WS_DATA_DMA.WS_MES_DMA);

            /*" -770- MOVE WS-ANO-DB2 TO WS-ANO-DMA */
            _.Move(WS_DATA_DB2.WS_ANO_DB2, WS_DATA_DMA.WS_ANO_DMA);

            /*" -772- MOVE WS-DATA-DMA TO EM0925-DATA01 */
            _.Move(WS_DATA_DMA, EM0925W099.EM0925_DATA01);

            /*" -774- MOVE ZEROS TO EM0925-QTMES */
            _.Move(0, EM0925W099.EM0925_QTMES);

            /*" -776- CALL 'EM0925S' USING EM0925W099. */
            _.Call("EM0925S", EM0925W099);

            /*" -777- IF EM0925-QTMES LESS LT2118S-QTD-PARCELAS */

            if (EM0925W099.EM0925_QTMES < LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS)
            {

                /*" -778- MOVE EM0925-QTMES TO WS-QTD-PARCELAS */
                _.Move(EM0925W099.EM0925_QTMES, WS_MSG_PARCELAS.WS_QTD_PARCELAS);

                /*" -779- MOVE WS-MSG-PARCELAS TO LT2118S-MSG-RETORNO */
                _.Move(WS_MSG_PARCELAS, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -780- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -781- GO TO R2300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                return;

                /*" -782- END-IF */
            }


            /*" -782- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-VERIFICA-APOLICE-SECTION */
        private void R2400_00_VERIFICA_APOLICE_SECTION()
        {
            /*" -794- MOVE 'R2400' TO WNR-EXEC-SQL. */
            _.Move("R2400", WABEND.WNR_EXEC_SQL);

            /*" -799- PERFORM R2410-00-CONTA-PARCELAS */

            R2410_00_CONTA_PARCELAS_SECTION();

            /*" -800- IF HOST-COUNT EQUAL ZEROS */

            if (HOST_COUNT == 00)
            {

                /*" -801- MOVE 1 TO HOST-COUNT */
                _.Move(1, HOST_COUNT);

                /*" -803- END-IF. */
            }


            /*" -804- IF HOST-COUNT LESS LT2118S-QTD-PARCELAS */

            if (HOST_COUNT < LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS)
            {

                /*" -806- IF LT2118S-PRM-TARIFARIO-TOTAL < ZEROS */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL < 00)
                {

                    /*" -807- MOVE HOST-COUNT TO LT2118S-QTD-PARCELAS */
                    _.Move(HOST_COUNT, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS);

                    /*" -808- MOVE WS-MSG-PARCELAS TO LT2118S-MSG-RETORNO */
                    _.Move(WS_MSG_PARCELAS, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -809- MOVE 01 TO LT2118S-COD-RETORNO */
                    _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -810- GO TO R2400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                    return;

                    /*" -811- END-IF */
                }


                /*" -812- END-IF. */
            }


            /*" -812- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-CONTA-PARCELAS-SECTION */
        private void R2410_00_CONTA_PARCELAS_SECTION()
        {
            /*" -821- MOVE 'R2410' TO WNR-EXEC-SQL. */
            _.Move("R2410", WABEND.WNR_EXEC_SQL);

            /*" -834- PERFORM R2410_00_CONTA_PARCELAS_DB_SELECT_1 */

            R2410_00_CONTA_PARCELAS_DB_SELECT_1();

            /*" -837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -839- MOVE 'LT2118S - PROBLEMAS NO COUNT PARCELAS' TO LT2118S-MSG-RETORNO */
                _.Move("LT2118S - PROBLEMAS NO COUNT PARCELAS", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                /*" -840- MOVE 01 TO LT2118S-COD-RETORNO */
                _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                /*" -840- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2410-00-CONTA-PARCELAS-DB-SELECT-1 */
        public void R2410_00_CONTA_PARCELAS_DB_SELECT_1()
        {
            /*" -834- EXEC SQL SELECT COUNT(*) INTO :HOST-COUNT FROM SEGUROS.PARCELAS A, SEGUROS.PARCELA_HISTORICO B WHERE A.NUM_APOLICE = :APOLICES-NUM-APOLICE AND A.NUM_ENDOSSO = 0 AND A.SIT_REGISTRO = '0' AND B.COD_OPERACAO = 101 AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA END-EXEC. */

            var r2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1 = new R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1.Execute(r2410_00_CONTA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-CALCULA-PARCELAS-SECTION */
        private void R2500_00_CALCULA_PARCELAS_SECTION()
        {
            /*" -850- MOVE 'R2500-00' TO WNR-EXEC-SQL. */
            _.Move("R2500-00", WABEND.WNR_EXEC_SQL);

            /*" -855- MOVE 0 TO WS-VAL-JUROS-TOT */
            _.Move(0, WS_VAL_JUROS_TOT);

            /*" -857- IF LT2118S-COD-MOVIMENTO EQUAL 'A' */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO == "A")
            {

                /*" -858- PERFORM R2610-00-VERIFICA-ALTERACAO */

                R2610_00_VERIFICA_ALTERACAO_SECTION();

                /*" -859- PERFORM R2600-00-APLICAR-DESCONTOS */

                R2600_00_APLICAR_DESCONTOS_SECTION();

                /*" -864- END-IF */
            }


            /*" -866- IF LT2118S-COD-MOVIMENTO EQUAL 'A' AND LT2118S-PRM-TARIFARIO-TOTAL GREATER ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO == "A" && LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL > 00)
            {

                /*" -868- IF LT2118S-PRM-TARIFARIO-TOTAL LESS 200 AND LT2118S-QTD-PARCELAS GREATER 1 */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL < 200 && LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS > 1)
                {

                    /*" -871- MOVE 'LT2118S - PREMIO LIQUIDO TOTAL INFERIOR A R$ 200- QUANTIDADE DE PARCELAS INVALIDA' TO LT2118S-MSG-RETORNO */
                    _.Move("LT2118S - PREMIO LIQUIDO TOTAL INFERIOR A R$ 200- QUANTIDADE DE PARCELAS INVALIDA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -872- MOVE 01 TO LT2118S-COD-RETORNO */
                    _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -873- GO TO R2500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/ //GOTO
                    return;

                    /*" -874- END-IF */
                }


                /*" -893- END-IF */
            }


            /*" -895- DISPLAY ' LT2118S-LT2118S-QTD-PARCELAS:' LT2118S-QTD-PARCELAS */
            _.Display($" LT2118S-LT2118S-QTD-PARCELAS:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS}");

            /*" -898- MOVE LT2118S-PRM-TARIFARIO-TOTAL TO WS-PRM-TARIFARIO-TOTAL */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL, WS_PRM_TARIFARIO_TOTAL);

            /*" -900- IF LT2118S-PRM-TARIFARIO-TOTAL LESS ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL < 00)
            {

                /*" -902- COMPUTE WS-PRM-TARIFARIO-TOTAL = WS-PRM-TARIFARIO-TOTAL * -1 */
                WS_PRM_TARIFARIO_TOTAL.Value = WS_PRM_TARIFARIO_TOTAL * -1;

                /*" -908- END-IF */
            }


            /*" -916- COMPUTE LT2118S-PRM-TARIFARIO-1 ROUNDED = WS-PRM-TARIFARIO-TOTAL / LT2118S-QTD-PARCELAS */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1.Value = WS_PRM_TARIFARIO_TOTAL / LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS;

            /*" -919- IF LT2118S-COD-MOVIMENTO EQUAL 'A' AND LT2118S-PRM-TARIFARIO-TOTAL GREATER ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO == "A" && LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL > 00)
            {

                /*" -922- IF LT2118S-PRM-TARIFARIO-1 LESS 100 AND LT2118S-QTD-PARCELAS GREATER 1 */

                if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1 < 100 && LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS > 1)
                {

                    /*" -925- MOVE 'LT2118S - PREMIO LIQUIDO MENSAL INFERIOR A R$ 100 - QUANTIDADE DE PARCELAS INVALIDA' TO LT2118S-MSG-RETORNO */
                    _.Move("LT2118S - PREMIO LIQUIDO MENSAL INFERIOR A R$ 100 - QUANTIDADE DE PARCELAS INVALIDA", LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO);

                    /*" -926- MOVE 01 TO LT2118S-COD-RETORNO */
                    _.Move(01, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO);

                    /*" -927- MOVE 0 TO LT2118S-PRM-TARIFARIO-1 */
                    _.Move(0, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1);

                    /*" -928- GO TO R2500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/ //GOTO
                    return;

                    /*" -929- END-IF */
                }


                /*" -935- END-IF. */
            }


            /*" -941- MOVE LT2118S-PRM-TARIFARIO-1 TO LT2118S-PRM-LIQUIDO-1 */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1);

            /*" -942- IF LT2118S-ISENTA-CUSTO = 'S' */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO == "S")
            {

                /*" -943- MOVE ZEROS TO LT2118S-CUSTO-EMISSAO-1 */
                _.Move(0, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1);

                /*" -979- END-IF */
            }


            /*" -987- COMPUTE LT2118S-ADICIONAL-FRACIO-1 ROUNDED = WS-VAL-JUROS-TOT / LT2118S-QTD-PARCELAS */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1.Value = WS_VAL_JUROS_TOT / LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS;

            /*" -990- IF LT2118S-COD-MOVIMENTO EQUAL 'C' OR 'T' OR LT2118S-PRM-TARIFARIO-TOTAL NOT GREATER ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO.In("C", "T") || LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL <= 00)
            {

                /*" -994- MOVE ZEROS TO APOLICES-PCT-IOCC. */
                _.Move(0, APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC);
            }


            /*" -1003- COMPUTE LT2118S-VAL-IOCC-1 ROUNDED = (LT2118S-PRM-LIQUIDO-1 + LT2118S-CUSTO-EMISSAO-1 + LT2118S-ADICIONAL-FRACIO-1) * APOLICES-PCT-IOCC / 100. */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_VAL_IOCC_1.Value = (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1 + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1 + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1) * APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC / 100f;

            /*" -1004- IF LT2118S-QTD-PARCELAS > 1 */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS > 1)
            {

                /*" -1006- MOVE LT2118S-PRM-TARIFARIO-1 TO LT2118S-PRM-TARIFARIO-N */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TARIFARIO_N);

                /*" -1008- MOVE LT2118S-PRM-LIQUIDO-1 TO LT2118S-PRM-LIQUIDO-N */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_LIQUIDO_N);

                /*" -1009- MOVE ZEROS TO LT2118S-CUSTO-EMISSAO-N */
                _.Move(0, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_CUSTO_EMISSAO_N);

                /*" -1011- MOVE LT2118S-ADICIONAL-FRACIO-1 TO LT2118S-ADICIONAL-FRACIO-N */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_ADICIONAL_FRACIO_N);

                /*" -1015- END-IF */
            }


            /*" -1024- COMPUTE LT2118S-VAL-IOCC-N ROUNDED = (LT2118S-PRM-LIQUIDO-N + LT2118S-CUSTO-EMISSAO-N + LT2118S-ADICIONAL-FRACIO-N) * APOLICES-PCT-IOCC / 100. */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_VAL_IOCC_N.Value = (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_LIQUIDO_N + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_CUSTO_EMISSAO_N + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_ADICIONAL_FRACIO_N) * APOLICES.DCLAPOLICES.APOLICES_PCT_IOCC / 100f;

            /*" -1030- COMPUTE LT2118S-PRM-TOTAL-1 = LT2118S-PRM-LIQUIDO-1 + LT2118S-CUSTO-EMISSAO-1 + LT2118S-ADICIONAL-FRACIO-1 + LT2118S-VAL-IOCC-1 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TOTAL_1.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1 + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1 + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1 + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_VAL_IOCC_1;

            /*" -1037- COMPUTE LT2118S-PRM-TOTAL-N = LT2118S-PRM-LIQUIDO-N + LT2118S-CUSTO-EMISSAO-N + LT2118S-ADICIONAL-FRACIO-N + LT2118S-VAL-IOCC-N. */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TOTAL_N.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_LIQUIDO_N + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_CUSTO_EMISSAO_N + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_ADICIONAL_FRACIO_N + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_VAL_IOCC_N;

            /*" -1040- DISPLAY 'LT2118S-R2500-FINAL' ' PRM-TOTAL-1:' LT2118S-PRM-TOTAL-1 ' PRM-TOTAL-N:' LT2118S-PRM-TOTAL-N */

            $"LT2118S-R2500-FINAL PRM-TOTAL-1:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TOTAL_1} PRM-TOTAL-N:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TOTAL_N}"
            .Display();

            /*" -1040- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-APLICAR-DESCONTOS-SECTION */
        private void R2600_00_APLICAR_DESCONTOS_SECTION()
        {
            /*" -1056- DISPLAY 'R2600-LT2118S APLICANDO DESCONTOS' ' PRM-TAR-INICIAL:' LT2118S-PRM-TARIFARIO-TOTAL */

            $"R2600-LT2118S APLICANDO DESCONTOS PRM-TAR-INICIAL:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL}"
            .Display();

            /*" -1062- COMPUTE WS-PCT-DESCONTOS = LT2118S-PCT-DESC-AGRUP + LT2118S-PCT-DESC-EXP + LT2118S-PCT-DESC-FIDEL + LT2118S-PCT-DESC-COFRE + LT2118S-PCT-DESC-BLINDAGEM */
            WS_PCT_DESCONTOS.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_AGRUP + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_EXP + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_FIDEL + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_COFRE + LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_BLINDAGEM;

            /*" -1063- IF WS-PCT-DESCONTOS GREATER 50 */

            if (WS_PCT_DESCONTOS > 50)
            {

                /*" -1064- MOVE 50 TO WS-PCT-DESCONTOS */
                _.Move(50, WS_PCT_DESCONTOS);

                /*" -1067- END-IF */
            }


            /*" -1068- DISPLAY 'COD-LOTERICO :' LTMVPROP-COD-EXT-SEGURADO */
            _.Display($"COD-LOTERICO :{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}");

            /*" -1069- DISPLAY 'TIPO ENDOSSO :' LTMVPROP-IND-TIPO-ENDOSSO */
            _.Display($"TIPO ENDOSSO :{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_ENDOSSO}");

            /*" -1070- DISPLAY 'VALOR PREMIO :' LTMVPROP-VAL-PREMIO */
            _.Display($"VALOR PREMIO :{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VAL_PREMIO}");

            /*" -1071- DISPLAY 'PRM-TAR-TOTAL:' LT2118S-PRM-TARIFARIO-TOTAL */
            _.Display($"PRM-TAR-TOTAL:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL}");

            /*" -1072- DISPLAY 'PCT-DESCONTOS:' WS-PCT-DESCONTOS */
            _.Display($"PCT-DESCONTOS:{WS_PCT_DESCONTOS}");

            /*" -1074- DISPLAY 'QTD-PARCELAS :' LT2118S-QTD-PARCELAS */
            _.Display($"QTD-PARCELAS :{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS}");

            /*" -1076- IF LTMVPROP-VAL-PREMIO < ZEROS AND (LTMVPROP-IND-TIPO-ENDOSSO EQUAL 700 OR 504) */

            if (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VAL_PREMIO < 00 && (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_ENDOSSO.In("700", "504")))
            {

                /*" -1077- MOVE ZEROS TO WS-PCT-DESCONTOS */
                _.Move(0, WS_PCT_DESCONTOS);

                /*" -1078- DISPLAY 'R2600-LT2118S DESCONTO ZERADO TENDO:700/504' */
                _.Display($"R2600-LT2118S DESCONTO ZERADO TENDO:700/504");

                /*" -1081- END-IF */
            }


            /*" -1086- COMPUTE LT2118S-PRM-TARIFARIO-TOTAL = LT2118S-PRM-TARIFARIO-TOTAL - (LT2118S-PRM-TARIFARIO-TOTAL * WS-PCT-DESCONTOS / 100). */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL - (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * WS_PCT_DESCONTOS / 100f);

            /*" -1090- DISPLAY 'PRM-TAR-TOTAL COM DESCONTOS:' LT2118S-PRM-TARIFARIO-TOTAL */
            _.Display($"PRM-TAR-TOTAL COM DESCONTOS:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL}");

            /*" -1094- COMPUTE LT2118S-VL-DESCONTO-TOTAL = LT2118S-PRM-TARIFARIO-TOTAL * WS-PCT-DESCONTOS / 100. */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_VL_DESCONTO_TOTAL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * WS_PCT_DESCONTOS / 100f;

            /*" -1102- COMPUTE LT2118S-PRM-LIQUIDO = LT2118S-PRM-TARIFARIO-TOTAL - LT2118S-VL-DESCONTO-TOTAL */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_PRM_LIQUIDO.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL - LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_VL_DESCONTO_TOTAL;

            /*" -1107- MOVE LT2118S-QTD-PARCELAS TO WS-IND */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS, WS_IND);

            /*" -1115- COMPUTE WS-VAL-JUROS-TOT ROUNDED = ( LT2118S-PRM-TARIFARIO-TOTAL * LT3250-PCT-COEFICIENTE(WS-IND) * LT2118S-QTD-PARCELAS ) - LT2118S-PRM-TARIFARIO-TOTAL */
            WS_VAL_JUROS_TOT.Value = (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT3250.LT3250_AREA_PARAMETROS.LT3250_TAB_COEFICIENTES.LT3250_PERCENT_COEFICIENTES[WS_IND].LT3250_PCT_COEFICIENTE.Value * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS) - LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL;

            /*" -1116- IF WS-VAL-JUROS-TOT < 0,5 */

            if (WS_VAL_JUROS_TOT < 0.5)
            {

                /*" -1117- MOVE ZEROS TO WS-VAL-JUROS-TOT */
                _.Move(0, WS_VAL_JUROS_TOT);

                /*" -1119- END-IF */
            }


            /*" -1146- DISPLAY 'R2600-PRM-TAR-TOT:' LT2118S-PRM-TARIFARIO-TOTAL ' PCT-DESC-TOT:' WS-PCT-DESCONTOS ' VAL-JUROS-TOT:' WS-VAL-JUROS-TOT */

            $"R2600-PRM-TAR-TOT:{LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL} PCT-DESC-TOT:{WS_PCT_DESCONTOS} VAL-JUROS-TOT:{WS_VAL_JUROS_TOT}"
            .Display();

            /*" -1149- COMPUTE LT2118S-DESC-AGRUP = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-AGRUP / 100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_AGRUP.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_AGRUP / 100f;

            /*" -1152- COMPUTE LT2118S-DESC-EXP = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-EXP / 100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_EXP.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_EXP / 100f;

            /*" -1155- COMPUTE LT2118S-DESC-EXP-INFO = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-EXP-INFO/100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_EXP_INFO.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_PCT_DESC_EXP_INFO / 100f;

            /*" -1158- COMPUTE LT2118S-DESC-FIDEL = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-FIDEL / 100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_FIDEL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_FIDEL / 100f;

            /*" -1161- COMPUTE LT2118S-DESC-FIDEL-INFO = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-FIDEL-INFO / 100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_FIDEL_INFO.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_PCT_DESC_FIDEL_INFO / 100f;

            /*" -1164- COMPUTE LT2118S-DESC-COFRE = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-COFRE / 100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_COFRE.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_COFRE / 100f;

            /*" -1226- COMPUTE LT2118S-DESC-BLINDAGEM = LT2118S-PRM-TARIFARIO-TOTAL * LT2118S-PCT-DESC-BLINDAGEM / 100 */
            LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_DESC_BLINDAGEM.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_BLINDAGEM / 100f;

            /*" -1226- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-VERIFICA-ALTERACAO-SECTION */
        private void R2610_00_VERIFICA_ALTERACAO_SECTION()
        {
            /*" -1235- INITIALIZE DCLLT-MOV-PROPOSTA */
            _.Initialize(
                LTMVPROP.DCLLT_MOV_PROPOSTA
            );

            /*" -1236- MOVE LT2118S-NUM-APOLICE TO LTMVPROP-NUM-APOLICE */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE);

            /*" -1238- MOVE LT2118S-DATA-INIVIGENCIA TO LTMVPROP-DT-INIVIG-PROPOSTA */
            _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA);

            /*" -1262- PERFORM R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1 */

            R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1();

            /*" -1265- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1266- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1267- MOVE 0 TO LTMVPROP-VAL-PREMIO */
                    _.Move(0, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VAL_PREMIO);

                    /*" -1268- MOVE 0 TO LTMVPROP-IND-TIPO-ENDOSSO */
                    _.Move(0, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_ENDOSSO);

                    /*" -1269- ELSE */
                }
                else
                {


                    /*" -1272- DISPLAY 'ERRO SELECT LT_MOV_PROPOSTA' ' ' LTMVPROP-NUM-APOLICE ' ' LTMVPROP-DT-INIVIG-PROPOSTA */

                    $"ERRO SELECT LT_MOV_PROPOSTA {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE} {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA}"
                    .Display();

                    /*" -1273- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1274- END-IF */
                }


                /*" -1274- END-IF. */
            }


        }

        [StopWatch]
        /*" R2610-00-VERIFICA-ALTERACAO-DB-SELECT-1 */
        public void R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1()
        {
            /*" -1262- EXEC SQL SELECT COD_PRODUTO, COD_EXT_ESTIP, COD_EXT_SEGURADO, DATA_MOVIMENTO, HORA_MOVIMENTO, COD_MOVIMENTO, VAL_PREMIO, IND_TIPO_ENDOSSO INTO :LTMVPROP-COD-PRODUTO, :LTMVPROP-COD-EXT-ESTIP, :LTMVPROP-COD-EXT-SEGURADO, :LTMVPROP-DATA-MOVIMENTO, :LTMVPROP-HORA-MOVIMENTO, :LTMVPROP-COD-MOVIMENTO, :LTMVPROP-VAL-PREMIO, :LTMVPROP-IND-TIPO-ENDOSSO FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :LTMVPROP-NUM-APOLICE AND DT_INIVIG_PROPOSTA = :LTMVPROP-DT-INIVIG-PROPOSTA AND COD_MOVIMENTO IN ( 'A' , 'C' ) AND SIT_MOVIMENTO = '1' WITH UR END-EXEC. */

            var r2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1 = new R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1()
            {
                LTMVPROP_DT_INIVIG_PROPOSTA = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA.ToString(),
                LTMVPROP_NUM_APOLICE = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1.Execute(r2610_00_VERIFICA_ALTERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_COD_PRODUTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PRODUTO);
                _.Move(executed_1.LTMVPROP_COD_EXT_ESTIP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_ESTIP);
                _.Move(executed_1.LTMVPROP_COD_EXT_SEGURADO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO);
                _.Move(executed_1.LTMVPROP_DATA_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_HORA_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_COD_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_VAL_PREMIO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VAL_PREMIO);
                _.Move(executed_1.LTMVPROP_IND_TIPO_ENDOSSO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_ENDOSSO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1285- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1287- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1287- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1289- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1293- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1293- GOBACK. */

            throw new GoBack();

        }
    }
}