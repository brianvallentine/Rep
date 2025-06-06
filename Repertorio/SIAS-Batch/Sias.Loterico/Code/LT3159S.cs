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
using Sias.Loterico.DB2.LT3159S;

namespace Code
{
    public class LT3159S
    {
        public bool IsCall { get; set; }

        public LT3159S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  LOTERICOS                          *      */
        /*"      *   PROGRAMA ...............  LT3159S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  OLIVEIRA                           *      */
        /*"      *   PROGRAMADOR ............  OLIVEIRA                           *      */
        /*"      *   DATA CODIFICACAO .......  OUT/2010                           *      */
        /*"      *   VERSAO .................  PROCURE WS-VERSAO                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                   ATUALIZAR PARAMETROS GERAIS        *      */
        /*"      *                                                                       */
        /*"      *   COD_PROGRAMA  =  'SPBLTPRM'  - PARAMETROS GERAIS                    */
        /*"      *                                                                       */
        /*"      *   PARAM                  =  1 - CUSTO DE APOLICE                      */
        /*"      *                          =  2 - IOF                                   */
        /*"      *                          =  3 - COMISSAO  CORRETOR                    */
        /*"      *                          =  4 - COMISSAO BALCAO (2%)                  */
        /*"      *                          =  5 - COMISSAO INDICADOR                    */
        /*"      *                          =  6 - COFRE INTELIGENTE (10%)               */
        /*"      *                          =  7 - DESCONTO FIDELIDADE                   */
        /*"      *                          =  8 - DESCONTO BLINDAGEM                    */
        /*"      *                          =  9 - DESCONTO AGRUPE - B+4                 */
        /*"      *                          =  10- DESCONTO AGRUP COB - B+5              */
        /*"      *                          =  11- VALOR DO BOLETO                       */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *   COD_PROGRAMA  =  'SPBLTPRO' - PARAMETROS DA PROPOSTA RENOV.         */
        /*"      *                                 VIGENCIAS DA PROPOSTA RENOVACAO       */
        /*"      *                                 (PARAM_SMINT02 = ANO PROPOSTA)        */
        /*"      *                                                                       */
        /*"      * ------------- PARAMETROS VALIDOS PARA CADA ANO ---------------        */
        /*"      *                        =  51 - DATA INICIO VIGENCIA PROPOSTA          */
        /*"      *                        =  52 - DATA FIM VIGENCIA PROPOSTA             */
        /*"      *                        =  53 - DATA PROMOCAO DO BOLETO                */
        /*"      *                        =  54 - DATA MAXIMA PROMOCAO DO BOLETO         */
        /*"      *                        =  55 - DTINIVIG   INICIO DA SINISTRALI        */
        /*"      *                        =  56 - DTINIVIG   FIM  DA SINISTRALIDA        */
        /*"      *                        =  57 - DTINIVIG PARA CLASSE F                 */
        /*"      *                        =  58 - DATA INICIO PESQUISA                   */
        /*"      *                        =  59 - DATA VENC. 1.PCL PROMOCAO              */
        /*"      *                        =  60 - PERCENTUAL DA IMP.SEG                  */
        /*"      *                        =  61 - 'ENVIAR EMAIL'                         */
        /*"      * -------------- PARAMETROS VALIDOS ATE 31/12/9999 --------------       */
        /*"      *                        =  62 - 'DESATIVAR O SIMULADOR(PROPOSTAS       */
        /*"      *                        =  63 - 'DESATIVAR O SIMULADOR(ENDOSSOS)       */
        /*"      *                        =  64 - 'DESATIVAR IMPRESSAO  (APOLICE)        */
        /*"      *                        =  65 - 'DESATIVAR IMPRESSAO  (ENDOSSO)        */
        /*"      *                        =  66 - DATA PG BOL BONUS REN(DESC.EXP)        */
        /*"      *                        =  67 - VALOR ADICIONAL COBER                  */
        /*"      *                        =  68 - VARIAVEL DISPLAY (SIM/NAO)             */
        /*"      *                        =  69 - VLR MINIMO PARCELA PARA ENVIO SAP      */
        /*"      *                        =  70 - VLR MINIMO PREMIO LIQUIDO              */
        /*"      * ---------------------------------------------------------------       */
        /*"      *    OBS: PARA O CODIGOS 61,62,63,64,65,68                              */
        /*"      *         DEVE INFORMAR (SIM/NAO) NA VARIAVEL                           */
        /*"      *         LKIO-DESC-MENSAGEM (SIMULADOR) ---> PARAM_CHAR04              */
        /*"      * ---------------------------------------------------------------       */
        /*"      *                                                                       */
        /*"      *   OPERACAO             = '01' INCLUSAO                                */
        /*"      *                        = '02' ALTERACAO                               */
        /*"      *                        = '03' CONSULTA                                */
        /*"      *                        = '04' CONSULTA GERAL                          */
        /*"      *                        = '05' EXCLUSAO                                */
        /*"      *                        = '06' DUPLUCAR PARA O PRODUTO 1805            */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                 CORRESPONDENTES CAIXA AQUI                            */
        /*"      *----------------------------------------------------------------*      */
        /*"      *          SMINT03 (PARAM_SMINT03 = TIPO PARAMETRO)                     */
        /*"      *                                                                       */
        /*"      *          CODIGO          = '1' VALOR                                  */
        /*"      *                          = '2' DATA                                   */
        /*"      *                          = '3' TEXTO (SIM/NAO/EM BRANCO)              */
        /*"      * ---------------------------------------------------------------       */
        /*"      *          COD_PRODUTO (COD_PRODUTO  = PRODUTO)                         */
        /*"      *                                                                       */
        /*"      *          CODIGO          = '1803' = LOTERICO                          */
        /*"      *                          = '1805' = CORRESPONDENTE CAIXA AQUI         */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACOES:                                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * 06/01/2020 - CADMUS 179573 - FLAVIO DE LIMA SILVA              *      */
        /*"      *              ABEND CODE=0C7                                    *      */
        /*"      *              SOLUCAO: ALTERADO O COMANDO DOS BOOKLIB.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * 30/06/2016 - CADMUS 139270 - LISIANE BRAGANCA SOARES           *      */
        /*"      *              SIMULACAO DA RENOVACAO                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 WS-IND                             PIC  9(006) VALUE 0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"01 WS-VALOR                           PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01 WS-CONTADOR                        PIC S9(04)    COMP.*/
        public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-DTINIVIG-PROPOSTA               PIC  X(10) VALUE SPACES.*/
        public StringBasis WS_DTINIVIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DTINIVIG-PROPOSTA-R REDEFINES  WS-DTINIVIG-PROPOSTA.*/
        private _REDEF_LT3159S_WS_DTINIVIG_PROPOSTA_R _ws_dtinivig_proposta_r { get; set; }
        public _REDEF_LT3159S_WS_DTINIVIG_PROPOSTA_R WS_DTINIVIG_PROPOSTA_R
        {
            get { _ws_dtinivig_proposta_r = new _REDEF_LT3159S_WS_DTINIVIG_PROPOSTA_R(); _.Move(WS_DTINIVIG_PROPOSTA, _ws_dtinivig_proposta_r); VarBasis.RedefinePassValue(WS_DTINIVIG_PROPOSTA, _ws_dtinivig_proposta_r, WS_DTINIVIG_PROPOSTA); _ws_dtinivig_proposta_r.ValueChanged += () => { _.Move(_ws_dtinivig_proposta_r, WS_DTINIVIG_PROPOSTA); }; return _ws_dtinivig_proposta_r; }
            set { VarBasis.RedefinePassValue(value, _ws_dtinivig_proposta_r, WS_DTINIVIG_PROPOSTA); }
        }  //Redefines
        public class _REDEF_LT3159S_WS_DTINIVIG_PROPOSTA_R : VarBasis
        {
            /*"     05 WS-ANO-INI-PROPOSTA            PIC  9(04).*/
            public IntBasis WS_ANO_INI_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-MES-INI-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_MES_INI_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-DIA-INI-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_DIA_INI_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DTTERVIG-PROPOSTA               PIC  X(10) VALUE SPACES.*/

            public _REDEF_LT3159S_WS_DTINIVIG_PROPOSTA_R()
            {
                WS_ANO_INI_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_0.ValueChanged += OnValueChanged;
                WS_MES_INI_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                WS_DIA_INI_PROPOSTA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_DTTERVIG_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DTTERVIG-PROPOSTA-R REDEFINES  WS-DTTERVIG-PROPOSTA.*/
        private _REDEF_LT3159S_WS_DTTERVIG_PROPOSTA_R _ws_dttervig_proposta_r { get; set; }
        public _REDEF_LT3159S_WS_DTTERVIG_PROPOSTA_R WS_DTTERVIG_PROPOSTA_R
        {
            get { _ws_dttervig_proposta_r = new _REDEF_LT3159S_WS_DTTERVIG_PROPOSTA_R(); _.Move(WS_DTTERVIG_PROPOSTA, _ws_dttervig_proposta_r); VarBasis.RedefinePassValue(WS_DTTERVIG_PROPOSTA, _ws_dttervig_proposta_r, WS_DTTERVIG_PROPOSTA); _ws_dttervig_proposta_r.ValueChanged += () => { _.Move(_ws_dttervig_proposta_r, WS_DTTERVIG_PROPOSTA); }; return _ws_dttervig_proposta_r; }
            set { VarBasis.RedefinePassValue(value, _ws_dttervig_proposta_r, WS_DTTERVIG_PROPOSTA); }
        }  //Redefines
        public class _REDEF_LT3159S_WS_DTTERVIG_PROPOSTA_R : VarBasis
        {
            /*"     05 WS-ANO-TER-PROPOSTA            PIC  9(04).*/
            public IntBasis WS_ANO_TER_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-MES-TER-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_MES_TER_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 FILLER                         PIC  X(001).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     05 WS-DIA-TER-PROPOSTA            PIC  9(02).*/
            public IntBasis WS_DIA_TER_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DATA-AUX                        PIC  X(10) VALUE SPACES.*/

            public _REDEF_LT3159S_WS_DTTERVIG_PROPOSTA_R()
            {
                WS_ANO_TER_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                WS_MES_TER_PROPOSTA.ValueChanged += OnValueChanged;
                FILLER_3.ValueChanged += OnValueChanged;
                WS_DIA_TER_PROPOSTA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-DT-INIVIGENCIA                  PIC  X(10) VALUE SPACES.*/
        public StringBasis WS_DT_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  WS-VERSAO                          PIC  X(120) VALUE    'LT3159S-VERSAO: V6 - 23072013 - 10:11HS - CAD82475 - PARAMET    'ROS CCA       '.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3159S-VERSAO: V6 - 23072013 - 10:11HS - CAD82475 - PARAMET    ");
        /*"01  WS-VERSAO-5                        PIC  X(120) VALUE    'LT3159S-VERSAO: V5 - 11042013 - 08:30HS - CAD61050 - INCLUSA    'O PARAMERO 70 '.*/
        public StringBasis WS_VERSAO_5 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3159S-VERSAO: V5 - 11042013 - 08:30HS - CAD61050 - INCLUSA    ");
        /*"01  WS-VERSAO-4                        PIC  X(120) VALUE    'LT3159S-VERSAO: V4 - 05022013 - 18:05HS - CAD61050 - INCLUSA    'O PARAMERO 69 '.*/
        public StringBasis WS_VERSAO_4 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3159S-VERSAO: V4 - 05022013 - 18:05HS - CAD61050 - INCLUSA    ");
        /*"01  WS-VERSAO-3                        PIC  X(120) VALUE    'LT3159S-VERSAO: V3 - 11122012 - 08:47HS - CAD61050 - INCLUSA    'O PARAMERO 68 '.*/
        public StringBasis WS_VERSAO_3 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3159S-VERSAO: V3 - 11122012 - 08:47HS - CAD61050 - INCLUSA    ");
        /*"01  WS-VERSAO-2                        PIC  X(120) VALUE    'LT3159S-VERSAO: V2 - 05122012 - 19:51HS - CAD70419 - PARAMET    'RIZACAO-2013'.*/
        public StringBasis WS_VERSAO_2 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3159S-VERSAO: V2 - 05122012 - 19:51HS - CAD70419 - PARAMET    ");
        /*"01  WS-VERSAO-1                        PIC  X(120) VALUE    'LT3159S-VERSAO: V1 - 17112011 - 18:05HS - CAD61050 - RENOVAC    'AO-2012'.*/
        public StringBasis WS_VERSAO_1 { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3159S-VERSAO: V1 - 17112011 - 18:05HS - CAD61050 - RENOVAC    ");
        /*"01  WS-VERSAO-0                        PIC  X(60) VALUE    'LT3159S-VERSAO: V0 - 11112010 - 17:00HS  - CAD48411'.*/
        public StringBasis WS_VERSAO_0 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)"), @"LT3159S-VERSAO: V0 - 11112010 - 17:00HS  - CAD48411");
        /*"01  WS-DT-ENTRADA.*/
        public LT3159S_WS_DT_ENTRADA WS_DT_ENTRADA { get; set; } = new LT3159S_WS_DT_ENTRADA();
        public class LT3159S_WS_DT_ENTRADA : VarBasis
        {
            /*"     05 WS-AA-DATE                     PIC  9(04).*/
            public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 WS-MM-DATA                     PIC  9(02).*/
            public IntBasis WS_MM_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 WS-DD-DATE                     PIC  9(02).*/
            public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  WS-DATE-AUX1.*/
        }
        public LT3159S_WS_DATE_AUX1 WS_DATE_AUX1 { get; set; } = new LT3159S_WS_DATE_AUX1();
        public class LT3159S_WS_DATE_AUX1 : VarBasis
        {
            /*"     05 WS-AA-DATE                     PIC  9(04).*/
            public IntBasis WS_AA_DATE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"     05 FILLER                         PIC  X(001)  VALUE  '-'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05 WS-MM-DATA                     PIC  9(02).*/
            public IntBasis WS_MM_DATA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     05 FILLER                         PIC  X(001)  VALUE  '-'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05 WS-DD-DATE                     PIC  9(02).*/
            public IntBasis WS_DD_DATE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01 WS-DATA-ATUAL                 PIC  9(008).*/
        }
        public IntBasis WS_DATA_ATUAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
        /*"01 WS-DATA-ATUAL-R     REDEFINES WS-DATA-ATUAL.*/
        private _REDEF_LT3159S_WS_DATA_ATUAL_R _ws_data_atual_r { get; set; }
        public _REDEF_LT3159S_WS_DATA_ATUAL_R WS_DATA_ATUAL_R
        {
            get { _ws_data_atual_r = new _REDEF_LT3159S_WS_DATA_ATUAL_R(); _.Move(WS_DATA_ATUAL, _ws_data_atual_r); VarBasis.RedefinePassValue(WS_DATA_ATUAL, _ws_data_atual_r, WS_DATA_ATUAL); _ws_data_atual_r.ValueChanged += () => { _.Move(_ws_data_atual_r, WS_DATA_ATUAL); }; return _ws_data_atual_r; }
            set { VarBasis.RedefinePassValue(value, _ws_data_atual_r, WS_DATA_ATUAL); }
        }  //Redefines
        public class _REDEF_LT3159S_WS_DATA_ATUAL_R : VarBasis
        {
            /*"     05  WS-ANO-8                PIC  9(004).*/
            public IntBasis WS_ANO_8 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     05  WS-MES-8                PIC  9(002).*/
            public IntBasis WS_MES_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     05  WS-DIA-8                PIC  9(002).*/
            public IntBasis WS_DIA_8 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01  WS-DATA-ATUAL-DB2.*/

            public _REDEF_LT3159S_WS_DATA_ATUAL_R()
            {
                WS_ANO_8.ValueChanged += OnValueChanged;
                WS_MES_8.ValueChanged += OnValueChanged;
                WS_DIA_8.ValueChanged += OnValueChanged;
            }

        }
        public LT3159S_WS_DATA_ATUAL_DB2 WS_DATA_ATUAL_DB2 { get; set; } = new LT3159S_WS_DATA_ATUAL_DB2();
        public class LT3159S_WS_DATA_ATUAL_DB2 : VarBasis
        {
            /*"     05  WS-ANO-ATU-DB2          PIC  9(004)  VALUE  ZEROS.*/
            public IntBasis WS_ANO_ATU_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"     05  WS-HIF01-ATU            PIC  X(001)  VALUE  '-'.*/
            public StringBasis WS_HIF01_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05  WS-MES-ATU-DB2          PIC  9(002)  VALUE  ZEROS.*/
            public IntBasis WS_MES_ATU_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"     05  WS-HIF02-ATU            PIC  X(001)  VALUE  '-'.*/
            public StringBasis WS_HIF02_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"     05  WS-DIA-ATU-DB2          PIC  9(002)  VALUE  ZEROS.*/
            public IntBasis WS_DIA_ATU_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01  WS-DT-ATUAL-DB2            REDEFINES WS-DATA-ATUAL-DB2                                 PIC  X(010).*/
        }
        private _REDEF_StringBasis _ws_dt_atual_db2 { get; set; }
        public _REDEF_StringBasis WS_DT_ATUAL_DB2
        {
            get { _ws_dt_atual_db2 = new _REDEF_StringBasis(new PIC("X", "010", "X(010).")); ; _.Move(WS_DATA_ATUAL_DB2, _ws_dt_atual_db2); VarBasis.RedefinePassValue(WS_DATA_ATUAL_DB2, _ws_dt_atual_db2, WS_DATA_ATUAL_DB2); _ws_dt_atual_db2.ValueChanged += () => { _.Move(_ws_dt_atual_db2, WS_DATA_ATUAL_DB2); }; return _ws_dt_atual_db2; }
            set { VarBasis.RedefinePassValue(value, _ws_dt_atual_db2, WS_DATA_ATUAL_DB2); }
        }  //Redefines
        /*"01       TABELA-PARAM.*/
        public LT3159S_TABELA_PARAM TABELA_PARAM { get; set; } = new LT3159S_TABELA_PARAM();
        public class LT3159S_TABELA_PARAM : VarBasis
        {
            /*"   07     TAB-PARAM.*/
            public LT3159S_TAB_PARAM TAB_PARAM { get; set; } = new LT3159S_TAB_PARAM();
            public class LT3159S_TAB_PARAM : VarBasis
            {
                /*"     10   FIL001   PIC  X(030)  VALUE 'CUSTO DE APOLICE       '.*/
                public StringBasis FIL001 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"CUSTO DE APOLICE       ");
                /*"     10   FIL002   PIC  X(030)  VALUE 'VALOR DO IOF           '.*/
                public StringBasis FIL002 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VALOR DO IOF           ");
                /*"     10   FIL003   PIC  X(030)  VALUE 'COMISSAO DO CORRETOR   '.*/
                public StringBasis FIL003 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"COMISSAO DO CORRETOR   ");
                /*"     10   FIL004   PIC  X(030)  VALUE 'COMISSAO BALCAO        '.*/
                public StringBasis FIL004 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"COMISSAO BALCAO        ");
                /*"     10   FIL005   PIC  X(030)  VALUE 'COMISSAO DO INDICADOR  '.*/
                public StringBasis FIL005 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"COMISSAO DO INDICADOR  ");
                /*"     10   FIL006   PIC  X(030)  VALUE 'COFRE INTELIGENTE      '.*/
                public StringBasis FIL006 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"COFRE INTELIGENTE      ");
                /*"     10   FIL007   PIC  X(030)  VALUE 'DESCONTO FIDELIDADE    '.*/
                public StringBasis FIL007 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESCONTO FIDELIDADE    ");
                /*"     10   FIL008   PIC  X(030)  VALUE 'DESCONTO BLINDAGEM     '.*/
                public StringBasis FIL008 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESCONTO BLINDAGEM     ");
                /*"     10   FIL009   PIC  X(030)  VALUE 'DESCONTO AGRUP COB- B+4'.*/
                public StringBasis FIL009 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESCONTO AGRUP COB- B+4");
                /*"     10   FIL010   PIC  X(030)  VALUE 'DESCONTO AGRUP COB- B+5'.*/
                public StringBasis FIL010 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESCONTO AGRUP COB- B+5");
                /*"     10   FIL011   PIC  X(030)  VALUE 'VALOR DO BOLETO        '.*/
                public StringBasis FIL011 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VALOR DO BOLETO        ");
                /*"     10   FIL012   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL012 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL013   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL013 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL014   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL014 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL015   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL015 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL016   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL016 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL017   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL017 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL018   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL018 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL019   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL019 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL020   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL020 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL021   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL021 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL022   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL022 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL023   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL023 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL024   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL024 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL025   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL025 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL026   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL026 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL027   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL027 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL028   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL028 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL029   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL029 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL030   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL030 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL031   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL031 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL032   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL032 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL033   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL033 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL034   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL034 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL035   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL035 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL036   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL036 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL037   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL037 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL038   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL038 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL039   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL039 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL040   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL040 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL041   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL041 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL042   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL042 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL043   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL043 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL044   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL044 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL045   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL045 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL046   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL046 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL047   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL047 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL048   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL048 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL049   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL049 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL050   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL050 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL051   PIC  X(030)  VALUE 'DATA INIVIG PROPOSTA   '.*/
                public StringBasis FIL051 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA INIVIG PROPOSTA   ");
                /*"     10   FIL052   PIC  X(030)  VALUE 'DATA TERVIG PROPOSTA   '.*/
                public StringBasis FIL052 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA TERVIG PROPOSTA   ");
                /*"     10   FIL053   PIC  X(030)  VALUE 'DATA PROMOCAO DO BOLETO'.*/
                public StringBasis FIL053 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA PROMOCAO DO BOLETO");
                /*"     10   FIL054   PIC  X(030)  VALUE 'DATA MAX PROMOCAO BOLET'.*/
                public StringBasis FIL054 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA MAX PROMOCAO BOLET");
                /*"     10   FIL055   PIC  X(030)  VALUE 'DATA INIVIG SINISTROS  '.*/
                public StringBasis FIL055 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA INIVIG SINISTROS  ");
                /*"     10   FIL056   PIC  X(030)  VALUE 'DATA TERVIG SINISTROS  '.*/
                public StringBasis FIL056 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA TERVIG SINISTROS  ");
                /*"     10   FIL057   PIC  X(030)  VALUE 'DATA INIVIG CLASSE F   '.*/
                public StringBasis FIL057 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA INIVIG CLASSE F   ");
                /*"     10   FIL058   PIC  X(030)  VALUE 'DATA INICIO PESQUISA '.*/
                public StringBasis FIL058 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA INICIO PESQUISA ");
                /*"     10   FIL059   PIC  X(030)  VALUE 'DATA VENC. 1.PCL PARCEL'.*/
                public StringBasis FIL059 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DATA VENC. 1.PCL PARCEL");
                /*"     10   FIL060   PIC  X(030)  VALUE 'PERCENTUAL IMP.SEG   '.*/
                public StringBasis FIL060 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"PERCENTUAL IMP.SEG   ");
                /*"     10   FIL061   PIC  X(030)  VALUE 'ENVIAR EMAIL '.*/
                public StringBasis FIL061 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"ENVIAR EMAIL ");
                /*"     10   FIL062   PIC  X(030)  VALUE 'DESATIVAR SIMULADOR(PRO)'*/
                public StringBasis FIL062 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESATIVAR SIMULADOR(PRO)");
                /*"     10   FIL063   PIC  X(030)  VALUE 'DESATIVAR SIMULADOR(END)'*/
                public StringBasis FIL063 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESATIVAR SIMULADOR(END)");
                /*"     10   FIL064   PIC  X(030)  VALUE 'DESATIVAR IMPRESSAO-APO'.*/
                public StringBasis FIL064 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESATIVAR IMPRESSAO-APO");
                /*"     10   FIL065   PIC  X(030)  VALUE 'DESATIVAR IMPRESSAO-END'.*/
                public StringBasis FIL065 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DESATIVAR IMPRESSAO-END");
                /*"     10   FIL066   PIC  X(030)  VALUE 'DT PG BOLETO BONUS REN '.*/
                public StringBasis FIL066 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"DT PG BOLETO BONUS REN ");
                /*"     10   FIL067   PIC  X(030)  VALUE 'VALOR ADICIONAL COBER  '.*/
                public StringBasis FIL067 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VALOR ADICIONAL COBER  ");
                /*"     10   FIL068   PIC  X(030)  VALUE 'VARIAVEL DISPLAY       '.*/
                public StringBasis FIL068 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VARIAVEL DISPLAY       ");
                /*"     10   FIL069   PIC  X(030)  VALUE 'VALOR MINIMO ENVIO SAP '.*/
                public StringBasis FIL069 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VALOR MINIMO ENVIO SAP ");
                /*"     10   FIL070   PIC  X(030)  VALUE 'VALOR MINIMO PREMIO LIQ'.*/
                public StringBasis FIL070 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"VALOR MINIMO PREMIO LIQ");
                /*"     10   FIL071   PIC  X(030)  VALUE 'PERC. ADIANTAMENTO '.*/
                public StringBasis FIL071 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"PERC. ADIANTAMENTO ");
                /*"     10   FIL072   PIC  X(030)  VALUE 'QTD. REINTEGRACAO '.*/
                public StringBasis FIL072 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"QTD. REINTEGRACAO ");
                /*"     10   FIL073   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL073 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL074   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL074 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL075   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL075 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL076   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL076 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL077   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL077 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL078   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL078 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL079   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL079 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL080   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL080 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL081   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL081 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL082   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL082 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL083   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL083 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL084   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL084 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL085   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL085 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL086   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL086 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL087   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL087 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL088   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL088 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL089   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL089 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL090   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL090 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL091   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL091 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL092   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL092 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL093   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL093 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL094   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL094 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL095   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL095 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL096   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL096 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL097   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL097 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL098   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL098 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"     10   FIL099   PIC  X(030)  VALUE '                       '.*/
                public StringBasis FIL099 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"                       ");
                /*"   07 TAB-PARAM-R  REDEFINES  TAB-PARAM.*/
            }
            private _REDEF_LT3159S_TAB_PARAM_R _tab_param_r { get; set; }
            public _REDEF_LT3159S_TAB_PARAM_R TAB_PARAM_R
            {
                get { _tab_param_r = new _REDEF_LT3159S_TAB_PARAM_R(); _.Move(TAB_PARAM, _tab_param_r); VarBasis.RedefinePassValue(TAB_PARAM, _tab_param_r, TAB_PARAM); _tab_param_r.ValueChanged += () => { _.Move(_tab_param_r, TAB_PARAM); }; return _tab_param_r; }
                set { VarBasis.RedefinePassValue(value, _tab_param_r, TAB_PARAM); }
            }  //Redefines
            public class _REDEF_LT3159S_TAB_PARAM_R : VarBasis
            {
                /*"      10 TB-PARAM  OCCURS 99 TIMES.*/
                public ListBasis<LT3159S_TB_PARAM> TB_PARAM { get; set; } = new ListBasis<LT3159S_TB_PARAM>(99);
                public class LT3159S_TB_PARAM : VarBasis
                {
                    /*"         15 TB-NOME-PARAM         PIC  X(030).*/
                    public StringBasis TB_NOME_PARAM { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"01 WABEND.*/

                    public LT3159S_TB_PARAM()
                    {
                        TB_NOME_PARAM.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_LT3159S_TAB_PARAM_R()
                {
                    TB_PARAM.ValueChanged += OnValueChanged;
                }

            }
        }
        public LT3159S_WABEND WABEND { get; set; } = new LT3159S_WABEND();
        public class LT3159S_WABEND : VarBasis
        {
            /*"   05 FILLER                      PIC X(08) VALUE 'LT3159S'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"LT3159S");
            /*"   05 FILLER                      PIC X(25) VALUE      '*** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"*** ERRO EXEC SQL NUMERO ");
            /*"   05 WNR-EXEC-SQL                PIC X(04) VALUE SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"   05 FILLER                      PIC X(13) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
            /*"   05 WSQLCODE                    PIC ZZZZZ999-.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
        }


        public Copies.LBLT3159 LBLT3159 { get; set; } = new Copies.LBLT3159();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public LT3159S_LTSOLPAR1 LTSOLPAR1 { get; set; } = new LT3159S_LTSOLPAR1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(Copies.LBLT3159_LT3159S_AREA_PARAMETROS LBLT3159_LT3159S_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3159S_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3159.LT3159S_AREA_PARAMETROS = LBLT3159_LT3159S_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3159.LT3159S_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -320- INITIALIZE LT3159S-TABELA-SAIDA LT3159S-COD-RETORNO LT3159S-MSG-RETORNO */
            _.Initialize(
                LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA
                , LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO
                , LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO
            );

            /*" -322- PERFORM R0100-00-CRITICAR-PARAMETROS */

            R0100_00_CRITICAR_PARAMETROS_SECTION();

            /*" -324- PERFORM R1000-00-PROCESSA-LEITURA */

            R1000_00_PROCESSA_LEITURA_SECTION();

            /*" -324- PERFORM R0010-00-FINALIZAR. */

            R0010_00_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-FINALIZAR-SECTION */
        private void R0010_00_FINALIZAR_SECTION()
        {
            /*" -339- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-CRITICAR-PARAMETROS-SECTION */
        private void R0100_00_CRITICAR_PARAMETROS_SECTION()
        {
            /*" -357- DISPLAY 'LT3159S-TIPO OPERACAO=' LT3159S-OPERACAO ' PARAMETRO=' LT3159S-PARAM ' NOME=' LT3159S-NOME ' DTINIVIG=' LT3159S-DATA-INIVIGENCIA ' ANO-REN=' LT3159S-ANO-RENOVACAO ' PRODUTO=' LT3159S-COD-PRODUTO */

            $"LT3159S-TIPO OPERACAO={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO} PARAMETRO={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM} NOME={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME} DTINIVIG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA} ANO-REN={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_ANO_RENOVACAO} PRODUTO={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO}"
            .Display();

            /*" -358- MOVE 'SPBLTPRM' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("SPBLTPRM", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -359- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -362- MOVE LT3159S-PARAM TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -363- IF LT3159S-OPERACAO EQUAL SPACES */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO.IsEmpty())
            {

                /*" -365- MOVE 'LT3159S - CODIGO DA OPERACAO NAO INFORMADO' TO LT3159S-MSG-RETORNO */
                _.Move("LT3159S - CODIGO DA OPERACAO NAO INFORMADO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -366- MOVE 100 TO LT3159S-COD-RETORNO */
                _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -367- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -375- END-IF */
            }


            /*" -376- IF LT3159S-OPERACAO EQUAL '01' OR '02' OR '03' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO.In("01", "02", "03"))
            {

                /*" -377- IF LT3159S-PARAM < 1 OR > 99 */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM < 1 || LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM > 99)
                {

                    /*" -379- MOVE 'LT3159S - CODIGO DO PARAMETRO INVALIDO' TO LT3159S-MSG-RETORNO */
                    _.Move("LT3159S - CODIGO DO PARAMETRO INVALIDO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                    /*" -380- MOVE 100 TO LT3159S-COD-RETORNO */
                    _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                    /*" -381- PERFORM R0010-00-FINALIZAR */

                    R0010_00_FINALIZAR_SECTION();

                    /*" -382- END-IF */
                }


                /*" -405- END-IF. */
            }


            /*" -406- IF LT3159S-DATA-INIVIGENCIA EQUAL SPACES */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA.IsEmpty())
            {

                /*" -408- MOVE 'LT3159S - INICIO DE VIGENCIA NAO INFORMADA' TO LT3159S-MSG-RETORNO */
                _.Move("LT3159S - INICIO DE VIGENCIA NAO INFORMADA", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -409- MOVE 100 TO LT3159S-COD-RETORNO */
                _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -410- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -417- END-IF. */
            }


            /*" -434- MOVE LT3159S-DATA-INIVIGENCIA TO WS-DTINIVIG-PROPOSTA */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA, WS_DTINIVIG_PROPOSTA);

            /*" -435- IF LT3159S-OPERACAO EQUAL '3' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO == "3")
            {

                /*" -436- IF LT3159S-TIPO-PARAM NOT EQUAL 1 AND 2 AND 3 */

                if (!LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM.In("1", "2", "3"))
                {

                    /*" -438- MOVE 'LT3159S - TIPO DE PARAMETRO INVALIDO' TO LT3159S-MSG-RETORNO */
                    _.Move("LT3159S - TIPO DE PARAMETRO INVALIDO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                    /*" -439- MOVE 100 TO LT3159S-COD-RETORNO */
                    _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                    /*" -440- PERFORM R0010-00-FINALIZAR */

                    R0010_00_FINALIZAR_SECTION();

                    /*" -441- END-IF */
                }


                /*" -443- END-IF */
            }


            /*" -444- IF LT3159S-COD-PRODUTO EQUAL ZEROS */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO == 00)
            {

                /*" -446- MOVE 'LT3159S - PRODUTO NAO INFORMADO ' TO LT3159S-MSG-RETORNO */
                _.Move("LT3159S - PRODUTO NAO INFORMADO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -447- MOVE 100 TO LT3159S-COD-RETORNO */
                _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -448- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -448- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-LEITURA-SECTION */
        private void R1000_00_PROCESSA_LEITURA_SECTION()
        {
            /*" -459- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -460- MOVE 'SPBLTPRM' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("SPBLTPRM", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -461- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -462- MOVE 0 TO WSQLCODE */
            _.Move(0, WABEND.WSQLCODE);

            /*" -464- MOVE LT3159S-PARAM TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -468- MOVE LT3159S-DATA-INIVIGENCIA TO LTSOLPAR-PARAM-DATE01 WS-DTINIVIG-PROPOSTA */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01, WS_DTINIVIG_PROPOSTA);

            /*" -520- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -521- IF LT3159S-OPERACAO EQUAL '03' OR '04' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO.In("03", "04"))
            {

                /*" -522- MOVE LT3159S-DATA-INIVIGENCIA TO WS-DTINIVIG-PROPOSTA */
                _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA, WS_DTINIVIG_PROPOSTA);

                /*" -526- END-IF */
            }


            /*" -533- DISPLAY 'LT3159S-PARAM =' LT3159S-PARAM ' DTINIVIG=' LT3159S-DATA-INIVIGENCIA ' VALOR   =' LT3159S-VALOR ' OPERACAO = ' LT3159S-OPERACAO ' ANO-REN  = ' LT3159S-ANO-RENOVACAO ' MSG=' LT3159S-NOME */

            $"LT3159S-PARAM ={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM} DTINIVIG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA} VALOR   ={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR} OPERACAO = {LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO} ANO-REN  = {LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_ANO_RENOVACAO} MSG={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME}"
            .Display();

            /*" -534- IF LT3159S-TIPO-PARAM EQUAL 1 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 1)
            {

                /*" -535- MOVE LT3159S-VALOR TO LTSOLPAR-PARAM-INTG01 */
                _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

                /*" -536- COMPUTE LTSOLPAR-PARAM-INTG01 = LT3159S-VALOR * 100 */
                LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.Value = LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR * 100;

                /*" -537- MOVE ' ' TO LTSOLPAR-PARAM-DATE03 */
                _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

                /*" -538- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
                _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

                /*" -539- ELSE */
            }
            else
            {


                /*" -540- IF LT3159S-TIPO-PARAM EQUAL 2 */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 2)
                {

                    /*" -541- MOVE LT3159S-DATA-PARAM TO LTSOLPAR-PARAM-DATE03 */
                    _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_PARAM, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

                    /*" -542- MOVE ' ' TO LTSOLPAR-PARAM-CHAR04 */
                    _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

                    /*" -543- MOVE ZEROS TO LTSOLPAR-PARAM-INTG01 */
                    _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

                    /*" -544- ELSE */
                }
                else
                {


                    /*" -545- MOVE LT3159S-VALOR-TXT TO LTSOLPAR-PARAM-CHAR04 */
                    _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR_TXT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);

                    /*" -546- MOVE ' ' TO LTSOLPAR-PARAM-DATE03 */
                    _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

                    /*" -547- MOVE ZEROS TO LTSOLPAR-PARAM-INTG01 */
                    _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

                    /*" -548- END-IF */
                }


                /*" -550- END-IF */
            }


            /*" -551- IF LTSOLPAR-PARAM-SMINT01 EQUAL 1 OR 2 */

            if (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.In("1", "2"))
            {

                /*" -552- MOVE ZEROS TO LTSOLPAR-COD-PRODUTO */
                _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

                /*" -553- ELSE */
            }
            else
            {


                /*" -554- MOVE LT3159S-COD-PRODUTO TO LTSOLPAR-COD-PRODUTO */
                _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

                /*" -556- END-IF */
            }


            /*" -557- IF LT3159S-OPERACAO EQUAL '01' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO == "01")
            {

                /*" -558- PERFORM R1300-00-INCLUIR-PARAMETRO */

                R1300_00_INCLUIR_PARAMETRO_SECTION();

                /*" -560- END-IF */
            }


            /*" -561- IF LT3159S-OPERACAO EQUAL '02' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO == "02")
            {

                /*" -562- IF LT3159S-TIPO-PARAM EQUAL 1 */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 1)
                {

                    /*" -563- PERFORM R1400-00-ALTERAR-PARAMETRO-01 */

                    R1400_00_ALTERAR_PARAMETRO_01_SECTION();

                    /*" -565- END-IF */
                }


                /*" -566- IF LT3159S-TIPO-PARAM EQUAL 2 */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 2)
                {

                    /*" -567- PERFORM R1410-00-ALTERAR-PARAMETRO-02 */

                    R1410_00_ALTERAR_PARAMETRO_02_SECTION();

                    /*" -569- END-IF */
                }


                /*" -570- IF LT3159S-TIPO-PARAM EQUAL 3 */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 3)
                {

                    /*" -571- PERFORM R1420-00-ALTERAR-PARAMETRO-03 */

                    R1420_00_ALTERAR_PARAMETRO_03_SECTION();

                    /*" -572- END-IF */
                }


                /*" -574- END-IF */
            }


            /*" -575- IF LT3159S-OPERACAO EQUAL '03' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO == "03")
            {

                /*" -576- PERFORM R1200-00-CONSULTA */

                R1200_00_CONSULTA_SECTION();

                /*" -578- END-IF */
            }


            /*" -580- IF LT3159S-OPERACAO EQUAL '04' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO == "04")
            {

                /*" -581- IF LT3159S-NOME = 'SIMULACAO' */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME == "SIMULACAO")
                {

                    /*" -582- MOVE 'SPBLTSIMULAC' TO LTSOLPAR-COD-PROGRAMA */
                    _.Move("SPBLTSIMULAC", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

                    /*" -583- ELSE */
                }
                else
                {


                    /*" -584- MOVE 'SPBLTPRM' TO LTSOLPAR-COD-PROGRAMA */
                    _.Move("SPBLTPRM", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

                    /*" -586- END-IF */
                }


                /*" -587- PERFORM R1100-00-CONSULTA-GERAL */

                R1100_00_CONSULTA_GERAL_SECTION();

                /*" -589- END-IF */
            }


            /*" -590- IF LT3159S-OPERACAO EQUAL '05' */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_OPERACAO == "05")
            {

                /*" -591- PERFORM R1600-00-EXCLUIR-REG */

                R1600_00_EXCLUIR_REG_SECTION();

                /*" -591- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-CONSULTA-GERAL-SECTION */
        private void R1100_00_CONSULTA_GERAL_SECTION()
        {
            /*" -602- MOVE 0 TO LT3159S-PARAM */
            _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM);

            /*" -603- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND GREATER 99 */

            for (WS_IND.Value = 1; !(WS_IND > 99); WS_IND.Value += 1)
            {

                /*" -607- MOVE 0 TO LT3159S-TB-PARAM (WS-IND) LT3159S-TB-VALOR (WS-IND) LT3159S-TB-VALOR-DT (WS-IND) */
                _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_PARAM, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_VALOR, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_VALOR_DT);

                /*" -610- MOVE SPACES TO LT3159S-TB-NOME (WS-IND) LT3159S-TB-DTINIVIG (WS-IND) LT3159S-TB-DTTERVIG (WS-IND) */
                _.Move("", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_NOME, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_DTINIVIG, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_DTTERVIG);

                /*" -612- END-PERFORM */
            }

            /*" -629- PERFORM R1100_00_CONSULTA_GERAL_DB_DECLARE_1 */

            R1100_00_CONSULTA_GERAL_DB_DECLARE_1();

            /*" -631- PERFORM R1100_00_CONSULTA_GERAL_DB_OPEN_1 */

            R1100_00_CONSULTA_GERAL_DB_OPEN_1();

            /*" -634- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -635- DISPLAY 'LT3159S-ERRO OPEN CURSOR LTSOLPAR' */
                _.Display($"LT3159S-ERRO OPEN CURSOR LTSOLPAR");

                /*" -636- DISPLAY 'LT3159S-COD-PROGRAMA' LTSOLPAR-COD-PROGRAMA */
                _.Display($"LT3159S-COD-PROGRAMA{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA}");

                /*" -637- DISPLAY 'LT3159S-SIT-SOLICITACAO' LTSOLPAR-SIT-SOLICITACAO */
                _.Display($"LT3159S-SIT-SOLICITACAO{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO}");

                /*" -638- DISPLAY 'LT3159S-DTINIVIG ' WS-DTINIVIG-PROPOSTA */
                _.Display($"LT3159S-DTINIVIG {WS_DTINIVIG_PROPOSTA}");

                /*" -639- DISPLAY 'LT3159S-PRODUTO ' LTSOLPAR-COD-PRODUTO */
                _.Display($"LT3159S-PRODUTO {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO}");

                /*" -640- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -640- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1100_FETCH */

            R1100_FETCH();

        }

        [StopWatch]
        /*" R1100-00-CONSULTA-GERAL-DB-DECLARE-1 */
        public void R1100_00_CONSULTA_GERAL_DB_DECLARE_1()
        {
            /*" -629- EXEC SQL DECLARE LTSOLPAR1 CURSOR FOR SELECT PARAM_SMINT01 ,PARAM_SMINT03 ,PARAM_INTG01 ,PARAM_CHAR01 ,PARAM_CHAR04 ,PARAM_DATE01 ,PARAM_DATE02 ,PARAM_DATE03 FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA =:LTSOLPAR-COD-PROGRAMA AND SIT_SOLICITACAO =:LTSOLPAR-SIT-SOLICITACAO AND PARAM_SMINT01 > 0 AND :WS-DTINIVIG-PROPOSTA BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO IN ( 0 , :LTSOLPAR-COD-PRODUTO ) END-EXEC. */
            LTSOLPAR1 = new LT3159S_LTSOLPAR1(true);
            string GetQuery_LTSOLPAR1()
            {
                var query = @$"SELECT PARAM_SMINT01 
							,PARAM_SMINT03 
							,PARAM_INTG01 
							,PARAM_CHAR01 
							,PARAM_CHAR04 
							,PARAM_DATE01 
							,PARAM_DATE02 
							,PARAM_DATE03 
							FROM SEGUROS.LT_SOLICITA_PARAM 
							WHERE COD_PROGRAMA ='{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA}' 
							AND SIT_SOLICITACAO ='{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO}' 
							AND PARAM_SMINT01 > 0 
							AND '{WS_DTINIVIG_PROPOSTA}' BETWEEN PARAM_DATE01 
							AND PARAM_DATE02 
							AND COD_PRODUTO IN ( 0
							, '{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO}' )";

                return query;
            }
            LTSOLPAR1.GetQueryEvent += GetQuery_LTSOLPAR1;

        }

        [StopWatch]
        /*" R1100-00-CONSULTA-GERAL-DB-OPEN-1 */
        public void R1100_00_CONSULTA_GERAL_DB_OPEN_1()
        {
            /*" -631- EXEC SQL OPEN LTSOLPAR1 END-EXEC. */

            LTSOLPAR1.Open();

        }

        [StopWatch]
        /*" R1100-FETCH */
        private void R1100_FETCH(bool isPerform = false)
        {
            /*" -654- PERFORM R1100_FETCH_DB_FETCH_1 */

            R1100_FETCH_DB_FETCH_1();

            /*" -657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -658- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -658- PERFORM R1100_FETCH_DB_CLOSE_1 */

                    R1100_FETCH_DB_CLOSE_1();

                    /*" -660- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -661- ELSE */
                }
                else
                {


                    /*" -662- DISPLAY 'LT3159S-R1100-ERRO FETCH LT-SOLICITA-PARAM' */
                    _.Display($"LT3159S-R1100-ERRO FETCH LT-SOLICITA-PARAM");

                    /*" -663- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -664- END-IF */
                }


                /*" -666- END-IF */
            }


            /*" -667- MOVE LTSOLPAR-PARAM-SMINT01 TO WS-IND */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01, WS_IND);

            /*" -668- MOVE LTSOLPAR-PARAM-SMINT01 TO LT3159S-TB-PARAM (WS-IND) */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_PARAM);

            /*" -669- MOVE LTSOLPAR-PARAM-CHAR01 TO LT3159S-TB-NOME (WS-IND) */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_NOME);

            /*" -670- MOVE LTSOLPAR-PARAM-DATE01 TO LT3159S-TB-DTINIVIG (WS-IND) */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_DTINIVIG);

            /*" -671- MOVE LTSOLPAR-PARAM-DATE02 TO LT3159S-TB-DTTERVIG (WS-IND) */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_DTTERVIG);

            /*" -673- MOVE LTSOLPAR-PARAM-DATE03 TO LT3159S-TB-VALOR-DT (WS-IND) */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_VALOR_DT);

            /*" -674- IF LTSOLPAR-PARAM-SMINT03 EQUAL 3 */

            if (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03 == 3)
            {

                /*" -675- MOVE LTSOLPAR-PARAM-CHAR04 TO LT3159S-TB-VALOR-DT (WS-IND) */
                _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_VALOR_DT);

                /*" -677- END-IF */
            }


            /*" -679- COMPUTE WS-VALOR ROUNDED = LTSOLPAR-PARAM-INTG01/100. */
            WS_VALOR.Value = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01 / 100f;

            /*" -681- MOVE WS-VALOR TO LT3159S-TB-VALOR (WS-IND) */
            _.Move(WS_VALOR, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TABELA_SAIDA.LT3159S_TAB_SAIDA[WS_IND].LT3159S_TB_VALOR);

            /*" -681- GO TO R1100-FETCH. */
            new Task(() => R1100_FETCH()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1100-FETCH-DB-FETCH-1 */
        public void R1100_FETCH_DB_FETCH_1()
        {
            /*" -654- EXEC SQL FETCH LTSOLPAR1 INTO :LTSOLPAR-PARAM-SMINT01 ,:LTSOLPAR-PARAM-SMINT03 ,:LTSOLPAR-PARAM-INTG01 ,:LTSOLPAR-PARAM-CHAR01 ,:LTSOLPAR-PARAM-CHAR04 ,:LTSOLPAR-PARAM-DATE01 ,:LTSOLPAR-PARAM-DATE02 ,:LTSOLPAR-PARAM-DATE03 END-EXEC */

            if (LTSOLPAR1.Fetch())
            {
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_SMINT01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_SMINT03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_INTG01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_CHAR01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_CHAR04, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_DATE01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_DATE02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);
                _.Move(LTSOLPAR1.LTSOLPAR_PARAM_DATE03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);
            }

        }

        [StopWatch]
        /*" R1100-FETCH-DB-CLOSE-1 */
        public void R1100_FETCH_DB_CLOSE_1()
        {
            /*" -658- EXEC SQL CLOSE LTSOLPAR1 END-EXEC */

            LTSOLPAR1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-CONSULTA-SECTION */
        private void R1200_00_CONSULTA_SECTION()
        {
            /*" -694- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WABEND.WNR_EXEC_SQL);

            /*" -711- PERFORM R1200_00_CONSULTA_DB_SELECT_1 */

            R1200_00_CONSULTA_DB_SELECT_1();

            /*" -713- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -715- MOVE 'R1200-PARAMETRO NAO ENCONTRADO' TO LT3159S-MSG-RETORNO */
                _.Move("R1200-PARAMETRO NAO ENCONTRADO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -716- MOVE 1200 TO LT3159S-COD-RETORNO */
                _.Move(1200, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -717- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -718- DISPLAY 'LT3159S-R1200-DTINIVIG=' WS-DTINIVIG-PROPOSTA */
                _.Display($"LT3159S-R1200-DTINIVIG={WS_DTINIVIG_PROPOSTA}");

                /*" -719- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -720- ELSE */
            }
            else
            {


                /*" -727- DISPLAY 'LT3159S-' 'LTSOLPAR-PARAM-INTG01= ' LTSOLPAR-PARAM-INTG01 'LTSOLPAR-PARAM-DATE01= ' LTSOLPAR-PARAM-DATE01 'LTSOLPAR-PARAM-DATE02= ' LTSOLPAR-PARAM-DATE02 'LTSOLPAR-PARAM-DATE03= ' LTSOLPAR-PARAM-DATE03 'LTSOLPAR-PARAM-CHAR01= ' LTSOLPAR-PARAM-CHAR01 'LTSOLPAR-PARAM-CHAR04= ' LTSOLPAR-PARAM-CHAR04 */

                $"LT3159S-LTSOLPAR-PARAM-INTG01= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01}LTSOLPAR-PARAM-DATE01= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}LTSOLPAR-PARAM-DATE02= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02}LTSOLPAR-PARAM-DATE03= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03}LTSOLPAR-PARAM-CHAR01= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01}LTSOLPAR-PARAM-CHAR04= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04}"
                .Display();

                /*" -729- END-IF */
            }


            /*" -730- IF LT3159S-TIPO-PARAM EQUAL 1 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 1)
            {

                /*" -731- COMPUTE WS-VALOR ROUNDED = LTSOLPAR-PARAM-INTG01/100 */
                WS_VALOR.Value = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01 / 100f;

                /*" -732- MOVE WS-VALOR TO LT3159S-VALOR */
                _.Move(WS_VALOR, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR);

                /*" -733- END-IF */
            }


            /*" -734- IF LT3159S-TIPO-PARAM EQUAL 2 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 2)
            {

                /*" -735- MOVE LTSOLPAR-PARAM-DATE03 TO LT3159S-VALOR-DT */
                _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR_DT);

                /*" -736- END-IF */
            }


            /*" -737- IF LT3159S-TIPO-PARAM EQUAL 3 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 3)
            {

                /*" -738- MOVE LTSOLPAR-PARAM-CHAR04 TO LT3159S-VALOR-TXT */
                _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR_TXT);

                /*" -740- END-IF */
            }


            /*" -741- MOVE LTSOLPAR-PARAM-CHAR01 TO LT3159S-NOME */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_NOME);

            /*" -742- MOVE LTSOLPAR-PARAM-DATE01 TO LT3159S-DATA-INIVIGENCIA */
            _.Move(LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA);

            /*" -742- . */

        }

        [StopWatch]
        /*" R1200-00-CONSULTA-DB-SELECT-1 */
        public void R1200_00_CONSULTA_DB_SELECT_1()
        {
            /*" -711- EXEC SQL SELECT PARAM_INTG01,PARAM_DATE01, PARAM_DATE02,PARAM_DATE03, PARAM_CHAR01,PARAM_CHAR04 INTO :LTSOLPAR-PARAM-INTG01 ,:LTSOLPAR-PARAM-DATE01 ,:LTSOLPAR-PARAM-DATE02 ,:LTSOLPAR-PARAM-DATE03 ,:LTSOLPAR-PARAM-CHAR01 ,:LTSOLPAR-PARAM-CHAR04 FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :WS-DTINIVIG-PROPOSTA BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1200_00_CONSULTA_DB_SELECT_1_Query1 = new R1200_00_CONSULTA_DB_SELECT_1_Query1()
            {
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                WS_DTINIVIG_PROPOSTA = WS_DTINIVIG_PROPOSTA.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1200_00_CONSULTA_DB_SELECT_1_Query1.Execute(r1200_00_CONSULTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTSOLPAR_PARAM_INTG01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);
                _.Move(executed_1.LTSOLPAR_PARAM_DATE01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);
                _.Move(executed_1.LTSOLPAR_PARAM_DATE02, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);
                _.Move(executed_1.LTSOLPAR_PARAM_DATE03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);
                _.Move(executed_1.LTSOLPAR_PARAM_CHAR01, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);
                _.Move(executed_1.LTSOLPAR_PARAM_CHAR04, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-CONSULTA-COUNT-SECTION */
        private void R1210_00_CONSULTA_COUNT_SECTION()
        {
            /*" -750- MOVE 'R1210' TO WNR-EXEC-SQL. */
            _.Move("R1210", WABEND.WNR_EXEC_SQL);

            /*" -752- MOVE 0 TO WS-CONTADOR */
            _.Move(0, WS_CONTADOR);

            /*" -761- PERFORM R1210_00_CONSULTA_COUNT_DB_SELECT_1 */

            R1210_00_CONSULTA_COUNT_DB_SELECT_1();

            /*" -763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -765- MOVE 'R1210-ERRO COUNT PARAMETRO      ' TO LT3159S-MSG-RETORNO */
                _.Move("R1210-ERRO COUNT PARAMETRO      ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -766- MOVE 1200 TO LT3159S-COD-RETORNO */
                _.Move(1200, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -767- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -768- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -770- END-IF */
            }


            /*" -770- . */

        }

        [StopWatch]
        /*" R1210-00-CONSULTA-COUNT-DB-SELECT-1 */
        public void R1210_00_CONSULTA_COUNT_DB_SELECT_1()
        {
            /*" -761- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :WS-DTINIVIG-PROPOSTA BETWEEN PARAM_DATE01 AND PARAM_DATE02 END-EXEC */

            var r1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1 = new R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1()
            {
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                WS_DTINIVIG_PROPOSTA = WS_DTINIVIG_PROPOSTA.ToString(),
            };

            var executed_1 = R1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1.Execute(r1210_00_CONSULTA_COUNT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, WS_CONTADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-SELECT-COUNT-DTINIVIG-SECTION */
        private void R1220_00_SELECT_COUNT_DTINIVIG_SECTION()
        {
            /*" -778- MOVE 'R1220' TO WNR-EXEC-SQL. */
            _.Move("R1220", WABEND.WNR_EXEC_SQL);

            /*" -780- MOVE 0 TO WS-CONTADOR */
            _.Move(0, WS_CONTADOR);

            /*" -788- PERFORM R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1 */

            R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1();

            /*" -790- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -792- MOVE 'R1220-ERRO COUNT PARAMETRO      ' TO LT3159S-MSG-RETORNO */
                _.Move("R1220-ERRO COUNT PARAMETRO      ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -793- MOVE 1200 TO LT3159S-COD-RETORNO */
                _.Move(1200, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -794- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -795- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -797- END-IF */
            }


            /*" -797- . */

        }

        [StopWatch]
        /*" R1220-00-SELECT-COUNT-DTINIVIG-DB-SELECT-1 */
        public void R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1()
        {
            /*" -788- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND PARAM_DATE01 = :WS-DTINIVIG-PROPOSTA END-EXEC */

            var r1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1 = new R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1()
            {
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                WS_DTINIVIG_PROPOSTA = WS_DTINIVIG_PROPOSTA.ToString(),
            };

            var executed_1 = R1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1.Execute(r1220_00_SELECT_COUNT_DTINIVIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, WS_CONTADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-INCLUIR-PARAMETRO-SECTION */
        private void R1300_00_INCLUIR_PARAMETRO_SECTION()
        {
            /*" -806- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -807- PERFORM R1220-00-SELECT-COUNT-DTINIVIG */

            R1220_00_SELECT_COUNT_DTINIVIG_SECTION();

            /*" -808- IF WS-CONTADOR GREATER ZEROS */

            if (WS_CONTADOR > 00)
            {

                /*" -810- MOVE 'LT3159S - PARAMETRO JA CADASTRADO' TO LT3159S-MSG-RETORNO */
                _.Move("LT3159S - PARAMETRO JA CADASTRADO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -811- MOVE 100 TO LT3159S-COD-RETORNO */
                _.Move(100, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -812- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -814- END-IF. */
            }


            /*" -815- IF LTSOLPAR-PARAM-SMINT01 EQUAL 1 OR 2 */

            if (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.In("1", "2"))
            {

                /*" -816- MOVE ZEROS TO LTSOLPAR-COD-PRODUTO */
                _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

                /*" -817- ELSE */
            }
            else
            {


                /*" -818- MOVE LT3159S-COD-PRODUTO TO LTSOLPAR-COD-PRODUTO */
                _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_PRODUTO, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

                /*" -820- END-IF */
            }


            /*" -821- MOVE 'SPBLTPRM' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("SPBLTPRM", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -822- MOVE 0 TO LTSOLPAR-TIPO-SOLICITACAO */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO);

            /*" -823- MOVE 'LT3159S' TO LTSOLPAR-COD-USUARIO */
            _.Move("LT3159S", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO);

            /*" -824- MOVE '9999-12-31' TO LTSOLPAR-DATA-PREV-PROC */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC);

            /*" -826- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -827- MOVE WS-DTINIVIG-PROPOSTA TO LTSOLPAR-PARAM-DATE01 */
            _.Move(WS_DTINIVIG_PROPOSTA, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -828- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE02 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02);

            /*" -831- MOVE '9999-12-31' TO LTSOLPAR-PARAM-DATE03 */
            _.Move("9999-12-31", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -833- MOVE LT3159S-TIPO-PARAM TO LTSOLPAR-PARAM-SMINT03 */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03);

            /*" -834- MOVE 0 TO LTSOLPAR-PARAM-INTG02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02);

            /*" -835- MOVE 0 TO LTSOLPAR-PARAM-INTG03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03);

            /*" -836- MOVE 0 TO LTSOLPAR-PARAM-DEC01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01);

            /*" -837- MOVE 0 TO LTSOLPAR-PARAM-DEC02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02);

            /*" -838- MOVE 0 TO LTSOLPAR-PARAM-DEC03 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03);

            /*" -839- MOVE 0 TO LTSOLPAR-PARAM-FLOAT01 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01);

            /*" -840- MOVE 0 TO LTSOLPAR-PARAM-FLOAT02 */
            _.Move(0, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02);

            /*" -842- MOVE TB-NOME-PARAM(LT3159S-PARAM) TO LTSOLPAR-PARAM-CHAR01 */
            _.Move(TABELA_PARAM.TAB_PARAM_R.TB_PARAM[LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_PARAM].TB_NOME_PARAM, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01);

            /*" -843- MOVE ' ' TO LTSOLPAR-PARAM-CHAR02 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02);

            /*" -845- MOVE ' ' TO LTSOLPAR-PARAM-CHAR03 */
            _.Move(" ", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

            /*" -846- IF LT3159S-TIPO-PARAM EQUAL 1 */

            if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 1)
            {

                /*" -847- MOVE LT3159S-VALOR TO LTSOLPAR-PARAM-INTG01 */
                _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01);

                /*" -848- ELSE */
            }
            else
            {


                /*" -849- IF LT3159S-TIPO-PARAM EQUAL 2 */

                if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 2)
                {

                    /*" -851- MOVE LT3159S-DATA-PARAM TO LTSOLPAR-PARAM-DATE03 */
                    _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_PARAM, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

                    /*" -852- ELSE */
                }
                else
                {


                    /*" -853- IF LT3159S-TIPO-PARAM EQUAL 3 */

                    if (LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_TIPO_PARAM == 3)
                    {

                        /*" -855- MOVE LT3159S-VALOR-TXT TO LTSOLPAR-PARAM-CHAR03 */
                        _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_VALOR_TXT, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03);

                        /*" -856- END-IF */
                    }


                    /*" -857- END-IF */
                }


                /*" -859- END-IF */
            }


            /*" -864- PERFORM R1305-00-INSERT */

            R1305_00_INSERT_SECTION();

            /*" -868- PERFORM R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1 */

            R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1();

            /*" -871- IF SQLCODE NOT EQUAL TO ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -872- MOVE 1300 TO LT3159S-COD-RETORNO */
                _.Move(1300, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -874- MOVE 'R1300-ERRO SUBT DIAS DTINIVIG-PROPOSTA' TO LT3159S-MSG-RETORNO */
                _.Move("R1300-ERRO SUBT DIAS DTINIVIG-PROPOSTA", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -875- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -877- END-IF */
            }


            /*" -887- PERFORM R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2 */

            R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2();

            /*" -890- IF WS-CONTADOR EQUAL ZEROS */

            if (WS_CONTADOR == 00)
            {

                /*" -892- MOVE 'R1300-PARAMETRO ANTERIOR NAO CADASTRADO' TO LT3159S-MSG-RETORNO */
                _.Move("R1300-PARAMETRO ANTERIOR NAO CADASTRADO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -893- MOVE 0 TO LT3159S-COD-RETORNO */
                _.Move(0, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -894- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -895- DISPLAY 'LT3159S-R1300-000-WSQLCODE: ' WSQLCODE */
                _.Display($"LT3159S-R1300-000-WSQLCODE: {WABEND.WSQLCODE}");

                /*" -896- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -898- END-IF */
            }


            /*" -907- PERFORM R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1 */

            R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1();

            /*" -910- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -912- MOVE 'R1300-ERRO UPDATE PARAMETRO ' TO LT3159S-MSG-RETORNO */
                _.Move("R1300-ERRO UPDATE PARAMETRO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -913- MOVE 1300 TO LT3159S-COD-RETORNO */
                _.Move(1300, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -914- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -915- DISPLAY 'LT3159S-R1300-000-WSQLCODE ' WSQLCODE */
                _.Display($"LT3159S-R1300-000-WSQLCODE {WABEND.WSQLCODE}");

                /*" -916- DISPLAY 'LT3159S-R1300-DATA-AUX ' WS-DATA-AUX */
                _.Display($"LT3159S-R1300-DATA-AUX {WS_DATA_AUX}");

                /*" -917- DISPLAY 'LT3159S-R1300-SMINT01  ' LTSOLPAR-PARAM-SMINT01 */
                _.Display($"LT3159S-R1300-SMINT01  {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

                /*" -918- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -919- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -920- END-IF */
            }


            /*" -920- . */

        }

        [StopWatch]
        /*" R1300-00-INCLUIR-PARAMETRO-DB-SELECT-1 */
        public void R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1()
        {
            /*" -868- EXEC SQL SELECT DATE(DAYS(:WS-DTINIVIG-PROPOSTA) - 1) INTO :WS-DATA-AUX FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var r1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1 = new R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1()
            {
                WS_DTINIVIG_PROPOSTA = WS_DTINIVIG_PROPOSTA.ToString(),
            };

            var executed_1 = R1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1.Execute(r1300_00_INCLUIR_PARAMETRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_AUX, WS_DATA_AUX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-INCLUIR-PARAMETRO-DB-UPDATE-1 */
        public void R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1()
        {
            /*" -907- EXEC SQL UPDATE SEGUROS.LT_SOLICITA_PARAM SET PARAM_DATE02 = :WS-DATA-AUX WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :WS-DATA-AUX BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1 = new R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1()
            {
                WS_DATA_AUX = WS_DATA_AUX.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            R1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1.Execute(r1300_00_INCLUIR_PARAMETRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1300-00-INCLUIR-PARAMETRO-DB-SELECT-2 */
        public void R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2()
        {
            /*" -887- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :WS-DATA-AUX BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1 = new R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1()
            {
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
                WS_DATA_AUX = WS_DATA_AUX.ToString(),
            };

            var executed_1 = R1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1.Execute(r1300_00_INCLUIR_PARAMETRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, WS_CONTADOR);
            }


        }

        [StopWatch]
        /*" R1305-00-INSERT-SECTION */
        private void R1305_00_INSERT_SECTION()
        {
            /*" -930- MOVE '1305' TO WNR-EXEC-SQL. */
            _.Move("1305", WABEND.WNR_EXEC_SQL);

            /*" -985- PERFORM R1305_00_INSERT_DB_INSERT_1 */

            R1305_00_INSERT_DB_INSERT_1();

            /*" -988- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -990- MOVE 'R1300-ERRO INSERT LT_SOLICITA_PARAM ' TO LT3159S-MSG-RETORNO */
                _.Move("R1300-ERRO INSERT LT_SOLICITA_PARAM ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -991- MOVE 1305 TO LT3159S-COD-RETORNO */
                _.Move(1305, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -992- DISPLAY 'COD-RETORNO  =' LT3159S-COD-RETORNO */
                _.Display($"COD-RETORNO  ={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO}");

                /*" -993- DISPLAY 'MSG-RETORNO  =' LT3159S-MSG-RETORNO */
                _.Display($"MSG-RETORNO  ={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO}");

                /*" -994- DISPLAY 'PARAM-DATE01 =' LTSOLPAR-PARAM-DATE01 */
                _.Display($"PARAM-DATE01 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}");

                /*" -995- DISPLAY 'PARAM-DATE02 =' LTSOLPAR-PARAM-DATE02 */
                _.Display($"PARAM-DATE02 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02}");

                /*" -996- DISPLAY 'PARAM-DATE03 =' LTSOLPAR-PARAM-DATE03 */
                _.Display($"PARAM-DATE03 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03}");

                /*" -997- DISPLAY 'PARAM-SMINT01=' LTSOLPAR-PARAM-SMINT01 */
                _.Display($"PARAM-SMINT01={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

                /*" -998- DISPLAY 'PARAM-SMINT02=' LTSOLPAR-PARAM-SMINT02 */
                _.Display($"PARAM-SMINT02={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02}");

                /*" -999- DISPLAY 'PARAM-SMINT03=' LTSOLPAR-PARAM-SMINT03 */
                _.Display($"PARAM-SMINT03={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03}");

                /*" -1000- DISPLAY 'PARAM-INTG01 =' LTSOLPAR-PARAM-INTG01 */
                _.Display($"PARAM-INTG01 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01}");

                /*" -1001- DISPLAY 'PARAM-INTG02 =' LTSOLPAR-PARAM-INTG02 */
                _.Display($"PARAM-INTG02 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02}");

                /*" -1002- DISPLAY 'PARAM-INTG03 =' LTSOLPAR-PARAM-INTG03 */
                _.Display($"PARAM-INTG03 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03}");

                /*" -1003- DISPLAY 'PARAM-DEC01  =' LTSOLPAR-PARAM-DEC01 */
                _.Display($"PARAM-DEC01  ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01}");

                /*" -1004- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1006- END-IF */
            }


            /*" -1007- DISPLAY 'LT3159S-R1305-INCLUSAO DE PARAMETRO COM SUCESSO' */
            _.Display($"LT3159S-R1305-INCLUSAO DE PARAMETRO COM SUCESSO");

            /*" -1008- DISPLAY 'PARAM-DATE01 =' LTSOLPAR-PARAM-DATE01 */
            _.Display($"PARAM-DATE01 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}");

            /*" -1009- DISPLAY 'PARAM-DATE02 =' LTSOLPAR-PARAM-DATE02 */
            _.Display($"PARAM-DATE02 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02}");

            /*" -1010- DISPLAY 'PARAM-DATE03 =' LTSOLPAR-PARAM-DATE03 */
            _.Display($"PARAM-DATE03 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03}");

            /*" -1011- DISPLAY 'PARAM-SMINT01=' LTSOLPAR-PARAM-SMINT01 */
            _.Display($"PARAM-SMINT01={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

            /*" -1012- DISPLAY 'PARAM-SMINT02=' LTSOLPAR-PARAM-SMINT02 */
            _.Display($"PARAM-SMINT02={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02}");

            /*" -1013- DISPLAY 'PARAM-SMINT03=' LTSOLPAR-PARAM-SMINT03 */
            _.Display($"PARAM-SMINT03={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03}");

            /*" -1014- DISPLAY 'PARAM-INTG01 =' LTSOLPAR-PARAM-INTG01 */
            _.Display($"PARAM-INTG01 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01}");

            /*" -1015- DISPLAY 'PARAM-INTG02 =' LTSOLPAR-PARAM-INTG02 */
            _.Display($"PARAM-INTG02 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02}");

            /*" -1016- DISPLAY 'PARAM-INTG03 =' LTSOLPAR-PARAM-INTG03 */
            _.Display($"PARAM-INTG03 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03}");

            /*" -1017- DISPLAY 'PARAM-CHAR04 =' LTSOLPAR-PARAM-CHAR04 */
            _.Display($"PARAM-CHAR04 ={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04}");

            /*" -1017- . */

        }

        [StopWatch]
        /*" R1305-00-INSERT-DB-INSERT-1 */
        public void R1305_00_INSERT_DB_INSERT_1()
        {
            /*" -985- EXEC SQL INSERT INTO SEGUROS.LT_SOLICITA_PARAM (COD_PRODUTO , COD_CLIENTE , COD_PROGRAMA , TIPO_SOLICITACAO, DATA_SOLICITACAO, COD_USUARIO , DATA_PREV_PROC , SIT_SOLICITACAO , TSTMP_SITUACAO , PARAM_DATE01 , PARAM_DATE02 , PARAM_DATE03 , PARAM_SMINT01 , PARAM_SMINT02 , PARAM_SMINT03 , PARAM_INTG01 , PARAM_INTG02 , PARAM_INTG03 , PARAM_DEC01 , PARAM_DEC02 , PARAM_DEC03 , PARAM_FLOAT01 , PARAM_FLOAT02 , PARAM_CHAR01 , PARAM_CHAR02 , PARAM_CHAR03 , PARAM_CHAR04) VALUES (:LTSOLPAR-COD-PRODUTO , :LTSOLPAR-COD-CLIENTE , :LTSOLPAR-COD-PROGRAMA , :LTSOLPAR-TIPO-SOLICITACAO , CURRENT DATE , :LTSOLPAR-COD-USUARIO , :LTSOLPAR-DATA-PREV-PROC , :LTSOLPAR-SIT-SOLICITACAO , CURRENT TIMESTAMP , :LTSOLPAR-PARAM-DATE01 , :LTSOLPAR-PARAM-DATE02 , :LTSOLPAR-PARAM-DATE03 , :LTSOLPAR-PARAM-SMINT01 , :LTSOLPAR-PARAM-SMINT02 , :LTSOLPAR-PARAM-SMINT03 , :LTSOLPAR-PARAM-INTG01 , :LTSOLPAR-PARAM-INTG02 , :LTSOLPAR-PARAM-INTG03 , :LTSOLPAR-PARAM-DEC01 , :LTSOLPAR-PARAM-DEC02 , :LTSOLPAR-PARAM-DEC03 , :LTSOLPAR-PARAM-FLOAT01 , :LTSOLPAR-PARAM-FLOAT02 , :LTSOLPAR-PARAM-CHAR01 , :LTSOLPAR-PARAM-CHAR02 , :LTSOLPAR-PARAM-CHAR03 , :LTSOLPAR-PARAM-CHAR04) END-EXEC. */

            var r1305_00_INSERT_DB_INSERT_1_Insert1 = new R1305_00_INSERT_DB_INSERT_1_Insert1()
            {
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
                LTSOLPAR_COD_CLIENTE = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_TIPO_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO.ToString(),
                LTSOLPAR_COD_USUARIO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO.ToString(),
                LTSOLPAR_DATA_PREV_PROC = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_PARAM_DATE02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02.ToString(),
                LTSOLPAR_PARAM_DATE03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_PARAM_SMINT02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02.ToString(),
                LTSOLPAR_PARAM_SMINT03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03.ToString(),
                LTSOLPAR_PARAM_INTG01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.ToString(),
                LTSOLPAR_PARAM_INTG02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02.ToString(),
                LTSOLPAR_PARAM_INTG03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03.ToString(),
                LTSOLPAR_PARAM_DEC01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01.ToString(),
                LTSOLPAR_PARAM_DEC02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02.ToString(),
                LTSOLPAR_PARAM_DEC03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03.ToString(),
                LTSOLPAR_PARAM_FLOAT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01.ToString(),
                LTSOLPAR_PARAM_FLOAT02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02.ToString(),
                LTSOLPAR_PARAM_CHAR01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01.ToString(),
                LTSOLPAR_PARAM_CHAR02 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02.ToString(),
                LTSOLPAR_PARAM_CHAR03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03.ToString(),
                LTSOLPAR_PARAM_CHAR04 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04.ToString(),
            };

            R1305_00_INSERT_DB_INSERT_1_Insert1.Execute(r1305_00_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1305_99_SAIDA*/

        [StopWatch]
        /*" R1310-00-UPDATE-PARAMETRO-SECTION */
        private void R1310_00_UPDATE_PARAMETRO_SECTION()
        {
            /*" -1035- PERFORM R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1 */

            R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1();

            /*" -1037- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1039- MOVE 'R1310-ERRO UPDATE PARAMETRO ' TO LT3159S-MSG-RETORNO */
                _.Move("R1310-ERRO UPDATE PARAMETRO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1040- MOVE 1310 TO LT3159S-COD-RETORNO */
                _.Move(1310, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1041- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1042- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1043- DISPLAY 'DTINIVIG ' WS-DTINIVIG-PROPOSTA */
                _.Display($"DTINIVIG {WS_DTINIVIG_PROPOSTA}");

                /*" -1044- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1045- END-IF */
            }


            /*" -1047- MOVE 'R1310-PARAMETRO ATUALIZADO ' TO LT3159S-MSG-RETORNO */
            _.Move("R1310-PARAMETRO ATUALIZADO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

            /*" -1047- . */

        }

        [StopWatch]
        /*" R1310-00-UPDATE-PARAMETRO-DB-UPDATE-1 */
        public void R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1()
        {
            /*" -1035- EXEC SQL UPDATE SEGUROS.LT_SOLICITA_PARAM SET PARAM_CHAR04 = :LTSOLPAR-PARAM-CHAR04 ,PARAM_INTG01 = :LTSOLPAR-PARAM-INTG01 ,PARAM_DATE03 = :LTSOLPAR-PARAM-DATE03 WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :WS-DTINIVIG-PROPOSTA BETWEEN PARAM_DATE01 AND PARAM_DATE02 END-EXEC */

            var r1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1 = new R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1()
            {
                LTSOLPAR_PARAM_CHAR04 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04.ToString(),
                LTSOLPAR_PARAM_INTG01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.ToString(),
                LTSOLPAR_PARAM_DATE03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                WS_DTINIVIG_PROPOSTA = WS_DTINIVIG_PROPOSTA.ToString(),
            };

            R1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1.Execute(r1310_00_UPDATE_PARAMETRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1310_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-ALTERAR-PARAMETRO-01-SECTION */
        private void R1400_00_ALTERAR_PARAMETRO_01_SECTION()
        {
            /*" -1058- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -1067- PERFORM R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1 */

            R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1();

            /*" -1070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1072- MOVE 'R1400-ERRO UPDATE PARAMETRO ' TO LT3159S-MSG-RETORNO */
                _.Move("R1400-ERRO UPDATE PARAMETRO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1073- MOVE 1400 TO LT3159S-COD-RETORNO */
                _.Move(1400, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1074- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1075- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1076- DISPLAY 'VALOR=' LTSOLPAR-PARAM-INTG01 */
                _.Display($"VALOR={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01}");

                /*" -1077- DISPLAY 'DATA=' LTSOLPAR-PARAM-DATE01 */
                _.Display($"DATA={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}");

                /*" -1078- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1079- END-IF */
            }


            /*" -1079- . */

        }

        [StopWatch]
        /*" R1400-00-ALTERAR-PARAMETRO-01-DB-UPDATE-1 */
        public void R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1()
        {
            /*" -1067- EXEC SQL UPDATE SEGUROS.LT_SOLICITA_PARAM SET PARAM_INTG01 = :LTSOLPAR-PARAM-INTG01 WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1 = new R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1()
            {
                LTSOLPAR_PARAM_INTG01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            R1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1.Execute(r1400_00_ALTERAR_PARAMETRO_01_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-ALTERAR-PARAMETRO-02-SECTION */
        private void R1410_00_ALTERAR_PARAMETRO_02_SECTION()
        {
            /*" -1089- MOVE '1410' TO WNR-EXEC-SQL. */
            _.Move("1410", WABEND.WNR_EXEC_SQL);

            /*" -1098- PERFORM R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1 */

            R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1();

            /*" -1101- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1103- MOVE 'R1410-ERRO UPDATE PARAMETRO ' TO LT3159S-MSG-RETORNO */
                _.Move("R1410-ERRO UPDATE PARAMETRO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1104- MOVE 1410 TO LT3159S-COD-RETORNO */
                _.Move(1410, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1105- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -1106- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1107- DISPLAY 'VALOR=' LTSOLPAR-PARAM-INTG01 */
                _.Display($"VALOR={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01}");

                /*" -1108- DISPLAY 'DATA=' LTSOLPAR-PARAM-DATE01 */
                _.Display($"DATA={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}");

                /*" -1109- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1110- END-IF */
            }


            /*" -1110- . */

        }

        [StopWatch]
        /*" R1410-00-ALTERAR-PARAMETRO-02-DB-UPDATE-1 */
        public void R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1()
        {
            /*" -1098- EXEC SQL UPDATE SEGUROS.LT_SOLICITA_PARAM SET PARAM_DATE03 = :LTSOLPAR-PARAM-DATE03 WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1 = new R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1()
            {
                LTSOLPAR_PARAM_DATE03 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            R1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1.Execute(r1410_00_ALTERAR_PARAMETRO_02_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-ALTERAR-PARAMETRO-03-SECTION */
        private void R1420_00_ALTERAR_PARAMETRO_03_SECTION()
        {
            /*" -1120- MOVE '1420' TO WNR-EXEC-SQL. */
            _.Move("1420", WABEND.WNR_EXEC_SQL);

            /*" -1129- PERFORM R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1 */

            R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1();

            /*" -1132- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1134- MOVE 'R1420-ERRO UPDATE PARAMETRO ' TO LT3159S-MSG-RETORNO */
                _.Move("R1420-ERRO UPDATE PARAMETRO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1135- MOVE 1420 TO LT3159S-COD-RETORNO */
                _.Move(1420, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1136- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1137- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1138- DISPLAY 'VALOR=' LTSOLPAR-PARAM-INTG01 */
                _.Display($"VALOR={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01}");

                /*" -1139- DISPLAY 'DATA=' LTSOLPAR-PARAM-DATE01 */
                _.Display($"DATA={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}");

                /*" -1140- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1141- END-IF */
            }


            /*" -1141- . */

        }

        [StopWatch]
        /*" R1420-00-ALTERAR-PARAMETRO-03-DB-UPDATE-1 */
        public void R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1()
        {
            /*" -1129- EXEC SQL UPDATE SEGUROS.LT_SOLICITA_PARAM SET PARAM_CHAR04 = :LTSOLPAR-PARAM-CHAR04 WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1 = new R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1()
            {
                LTSOLPAR_PARAM_CHAR04 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR04.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            R1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1.Execute(r1420_00_ALTERAR_PARAMETRO_03_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PESQ-DATA-SIST-SECTION */
        private void R1500_00_PESQ_DATA_SIST_SECTION()
        {
            /*" -1150- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -1151- MOVE FUNCTION CURRENT-DATE(1:8) TO WS-DATA-ATUAL. */
            _.Move(_.CurrentDate(0, 8), WS_DATA_ATUAL);

            /*" -1152- MOVE WS-ANO-8 TO WS-ANO-ATU-DB2. */
            _.Move(WS_DATA_ATUAL_R.WS_ANO_8, WS_DATA_ATUAL_DB2.WS_ANO_ATU_DB2);

            /*" -1153- MOVE WS-MES-8 TO WS-MES-ATU-DB2. */
            _.Move(WS_DATA_ATUAL_R.WS_MES_8, WS_DATA_ATUAL_DB2.WS_MES_ATU_DB2);

            /*" -1154- MOVE WS-DIA-8 TO WS-DIA-ATU-DB2. */
            _.Move(WS_DATA_ATUAL_R.WS_DIA_8, WS_DATA_ATUAL_DB2.WS_DIA_ATU_DB2);

            /*" -1156- MOVE WS-DATA-ATUAL-DB2 TO WS-DATA-AUX. */
            _.Move(WS_DATA_ATUAL_DB2, WS_DATA_AUX);

            /*" -1157- MOVE LT3159S-DATA-INIVIGENCIA TO WS-DT-ENTRADA. */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA, WS_DT_ENTRADA);

            /*" -1160- MOVE LT3159S-DATA-INIVIGENCIA TO WS-DT-INIVIGENCIA */
            _.Move(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA, WS_DT_INIVIGENCIA);

            /*" -1162- MOVE CORR WS-DT-ENTRADA TO WS-DATE-AUX1. */
            _.MoveCorr(WS_DT_ENTRADA, WS_DATE_AUX1);

            /*" -1165- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO. */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -1167- MOVE 0 TO WS-CONTADOR */
            _.Move(0, WS_CONTADOR);

            /*" -1177- PERFORM R1500_00_PESQ_DATA_SIST_DB_SELECT_1 */

            R1500_00_PESQ_DATA_SIST_DB_SELECT_1();

            /*" -1180- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1182- DISPLAY 'R1500-000-WSQLCODE        =' WSQLCODE */
            _.Display($"R1500-000-WSQLCODE        ={WABEND.WSQLCODE}");

            /*" -1183- IF WS-CONTADOR GREATER ZEROS */

            if (WS_CONTADOR > 00)
            {

                /*" -1187- STRING 'DATA INICIO VIGENCIA, JA EXISTE' ' - DATA INIVIG = ' LT3159S-DATA-INIVIGENCIA ' - DATA ATUAL= ' WS-DATA-ATUAL-DB2 DELIMITED BY SIZE INTO LT3159S-MSG-RETORNO */
                #region STRING
                var spl1 = "DATA INICIO VIGENCIA, JA EXISTE" + " - DATA INIVIG = " + LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA.GetMoveValues();
                spl1 += " - DATA ATUAL= ";
                var spl2 = WS_DATA_ATUAL_DB2.GetMoveValues();
                var results3 = spl1 + spl2;
                _.Move(results3, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);
                #endregion

                /*" -1188- MOVE 1500 TO LT3159S-COD-RETORNO */
                _.Move(1500, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1189- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1190- DISPLAY 'LTSOLPAR-COD-PRO=' LTSOLPAR-COD-PROGRAMA */
                _.Display($"LTSOLPAR-COD-PRO={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA}");

                /*" -1191- DISPLAY 'LTSOLPAR-PARAM-S=' LTSOLPAR-PARAM-SMINT01 */
                _.Display($"LTSOLPAR-PARAM-S={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

                /*" -1192- DISPLAY 'LTSOLPAR-SIT-SOL=' LTSOLPAR-SIT-SOLICITACAO */
                _.Display($"LTSOLPAR-SIT-SOL={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO}");

                /*" -1193- DISPLAY 'LT3159S-DATA-INI=' LT3159S-DATA-INIVIGENCIA */
                _.Display($"LT3159S-DATA-INI={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA}");

                /*" -1194- DISPLAY 'WSQLCODE        =' WSQLCODE */
                _.Display($"WSQLCODE        ={WABEND.WSQLCODE}");

                /*" -1195- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1196- ELSE */
            }
            else
            {


                /*" -1197- DISPLAY 'R1500-NAO ENCONTRADO NESTA DATA INIVIG' */
                _.Display($"R1500-NAO ENCONTRADO NESTA DATA INIVIG");

                /*" -1198- DISPLAY 'LTSOLPAR-COD-PRO=' LTSOLPAR-COD-PROGRAMA */
                _.Display($"LTSOLPAR-COD-PRO={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA}");

                /*" -1199- DISPLAY 'LTSOLPAR-PARAM-S=' LTSOLPAR-PARAM-SMINT01 */
                _.Display($"LTSOLPAR-PARAM-S={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

                /*" -1200- DISPLAY 'LTSOLPAR-SIT-SOL=' LTSOLPAR-SIT-SOLICITACAO */
                _.Display($"LTSOLPAR-SIT-SOL={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO}");

                /*" -1201- DISPLAY 'LT3159S-DATA-INI=' LT3159S-DATA-INIVIGENCIA */
                _.Display($"LT3159S-DATA-INI={LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_DATA_INIVIGENCIA}");

                /*" -1202- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1203- DISPLAY 'WSQLCODE        =' WSQLCODE */
                _.Display($"WSQLCODE        ={WABEND.WSQLCODE}");

                /*" -1205- END-IF. */
            }


            /*" -1210- PERFORM R1500_00_PESQ_DATA_SIST_DB_SELECT_2 */

            R1500_00_PESQ_DATA_SIST_DB_SELECT_2();

            /*" -1213- IF SQLCODE NOT EQUAL TO ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1214- MOVE 1500 TO LT3159S-COD-RETORNO */
                _.Move(1500, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1217- STRING 'R1500-ERRO DATA VIGENCIA - 1 ' ' - DATA ATUAL = ' WS-DATA-ATUAL-DB2 DELIMITED BY SIZE INTO LT3159S-MSG-RETORNO */
                #region STRING
                var spl3 = "R1500-ERRO DATA VIGENCIA - 1 " + " - DATA ATUAL = " + WS_DATA_ATUAL_DB2.GetMoveValues();
                _.Move(spl3, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);
                #endregion

                /*" -1218- MOVE 1500 TO LT3159S-COD-RETORNO */
                _.Move(1500, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1219- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1220- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1222- END-IF */
            }


            /*" -1224- MOVE ZEROS TO WS-CONTADOR */
            _.Move(0, WS_CONTADOR);

            /*" -1233- PERFORM R1500_00_PESQ_DATA_SIST_DB_SELECT_3 */

            R1500_00_PESQ_DATA_SIST_DB_SELECT_3();

            /*" -1236- IF WS-CONTADOR GREATER ZEROS */

            if (WS_CONTADOR > 00)
            {

                /*" -1239- STRING 'DATA FIM DE VIGENCIA, JA EXISTE' ' - DATA ATUAL= ' WS-DATA-ATUAL-DB2 DELIMITED BY SIZE INTO LT3159S-MSG-RETORNO */
                #region STRING
                var spl4 = "DATA FIM DE VIGENCIA, JA EXISTE" + " - DATA ATUAL= " + WS_DATA_ATUAL_DB2.GetMoveValues();
                _.Move(spl4, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);
                #endregion

                /*" -1240- MOVE 1500 TO LT3159S-COD-RETORNO */
                _.Move(1500, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1241- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1242- DISPLAY 'LTSOLPAR-COD-PRO=' LTSOLPAR-COD-PROGRAMA */
                _.Display($"LTSOLPAR-COD-PRO={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA}");

                /*" -1243- DISPLAY 'LTSOLPAR-PARAM-S=' LTSOLPAR-PARAM-SMINT01 */
                _.Display($"LTSOLPAR-PARAM-S={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

                /*" -1244- DISPLAY 'LTSOLPAR-SIT-SOL=' LTSOLPAR-SIT-SOLICITACAO */
                _.Display($"LTSOLPAR-SIT-SOL={LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO}");

                /*" -1245- DISPLAY 'LT3159S-DATA-INI=' WS-DATA-AUX */
                _.Display($"LT3159S-DATA-INI={WS_DATA_AUX}");

                /*" -1246- DISPLAY 'WSQLCODE        =' WSQLCODE */
                _.Display($"WSQLCODE        ={WABEND.WSQLCODE}");

                /*" -1247- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1248- END-IF. */
            }


            /*" -1248- . */

        }

        [StopWatch]
        /*" R1500-00-PESQ-DATA-SIST-DB-SELECT-1 */
        public void R1500_00_PESQ_DATA_SIST_DB_SELECT_1()
        {
            /*" -1177- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND PARAM_DATE01 = :WS-DT-INIVIGENCIA WITH UR END-EXEC */

            var r1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1 = new R1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1()
            {
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                WS_DT_INIVIGENCIA = WS_DT_INIVIGENCIA.ToString(),
            };

            var executed_1 = R1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1.Execute(r1500_00_PESQ_DATA_SIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, WS_CONTADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PESQ-DATA-SIST-DB-SELECT-2 */
        public void R1500_00_PESQ_DATA_SIST_DB_SELECT_2()
        {
            /*" -1210- EXEC SQL SELECT DATE(DAYS(:WS-DT-INIVIGENCIA) -1) INTO :WS-DATA-AUX FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var r1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1 = new R1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1()
            {
                WS_DT_INIVIGENCIA = WS_DT_INIVIGENCIA.ToString(),
            };

            var executed_1 = R1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1.Execute(r1500_00_PESQ_DATA_SIST_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_AUX, WS_DATA_AUX);
            }


        }

        [StopWatch]
        /*" R1600-00-EXCLUIR-REG-SECTION */
        private void R1600_00_EXCLUIR_REG_SECTION()
        {
            /*" -1257- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -1265- PERFORM R1600_00_EXCLUIR_REG_DB_DELETE_1 */

            R1600_00_EXCLUIR_REG_DB_DELETE_1();

            /*" -1268- IF SQLCODE NOT EQUAL ZEROS AND +100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -1270- MOVE 'R1600-ERRO DELETE PARAMETRO ' TO LT3159S-MSG-RETORNO */
                _.Move("R1600-ERRO DELETE PARAMETRO ", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1271- MOVE 1600 TO LT3159S-COD-RETORNO */
                _.Move(1600, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1272- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -1273- DISPLAY LT3159S-MSG-RETORNO */
                _.Display(LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1274- DISPLAY 'DATE01= ' LTSOLPAR-PARAM-DATE01 */
                _.Display($"DATE01= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01}");

                /*" -1275- DISPLAY 'SMINT01= ' LTSOLPAR-PARAM-SMINT01 */
                _.Display($"SMINT01= {LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01}");

                /*" -1276- PERFORM R0010-00-FINALIZAR */

                R0010_00_FINALIZAR_SECTION();

                /*" -1278- END-IF */
            }


            /*" -1279- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1281- MOVE 'NAO EXISTE O PARAMETRO SELECIONADO' TO LT3159S-MSG-RETORNO */
                _.Move("NAO EXISTE O PARAMETRO SELECIONADO", LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_MSG_RETORNO);

                /*" -1282- MOVE 1600 TO LT3159S-COD-RETORNO */
                _.Move(1600, LBLT3159.LT3159S_AREA_PARAMETROS.LT3159S_COD_RETORNO);

                /*" -1283- END-IF */
            }


            /*" -1283- . */

        }

        [StopWatch]
        /*" R1600-00-EXCLUIR-REG-DB-DELETE-1 */
        public void R1600_00_EXCLUIR_REG_DB_DELETE_1()
        {
            /*" -1265- EXEC SQL DELETE FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC */

            var r1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1 = new R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1()
            {
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            R1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1.Execute(r1600_00_EXCLUIR_REG_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" R1500-00-PESQ-DATA-SIST-DB-SELECT-3 */
        public void R1500_00_PESQ_DATA_SIST_DB_SELECT_3()
        {
            /*" -1233- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND SIT_SOLICITACAO = :LTSOLPAR-SIT-SOLICITACAO AND PARAM_DATE02 = :WS-DATA-AUX WITH UR END-EXEC */

            var r1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1 = new R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1()
            {
                LTSOLPAR_SIT_SOLICITACAO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.ToString(),
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                WS_DATA_AUX = WS_DATA_AUX.ToString(),
            };

            var executed_1 = R1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1.Execute(r1500_00_PESQ_DATA_SIST_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, WS_CONTADOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1293- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1295- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1295- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1297- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1301- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1301- GOBACK. */

            throw new GoBack();

        }
    }
}