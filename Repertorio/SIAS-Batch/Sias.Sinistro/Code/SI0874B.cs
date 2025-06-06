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
using Sias.Sinistro.DB2.SI0874B;

namespace Code
{
    public class SI0874B
    {
        public bool IsCall { get; set; }

        public SI0874B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * SISTEMA   : SINISTRO                                        //      */
        /*"      * PROGRAMA  : SI0874B                                         //      */
        /*"      * OBJETIVO  : GERACAO DE ANALITICO DE MOVIMENT. DE SINISTRO   //      */
        /*"      *             SEMANAL/MENSAL A SER DISPONIBILIZADO NA INTERNET//      */
        /*"      *                                                             //      */
        /*"      * ANALISTA :  ALEXIS E SANDRA                                         */
        /*"      * PROGRAMADOR : SANDRA                                                */
        /*"      * DATA                 :    MAIO / 2003                       //      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      * 19/04/2005 - PRODEXTER                                       *      */
        /*"      * SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO E *      */
        /*"      * GE_SIS_FUNCAO_OPER                                           *      */
        /*"      *////////////////////////////////////////////////////////////*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 17/07/2008 - WELLINGTON VERAS (POLITEC                         *      */
        /*"      *              PROJETO FGV                                       *      */
        /*"      *              INIBIR O COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  19/10/2010 - CADIMUS 47494/2010 - CIRCULAR 395:               *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZA��O DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZA��O DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR P�BLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SER�O CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONS�RCIO.              *      */
        /*"      *                                                                *      */
        /*"      *               MARCELO NEVES (TE41729)   PROCURAR: C395         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_ANAL { get; set; } = new FileBasis(new PIC("X", "800", "X(800)"));

        public FileBasis ARQ_ANAL
        {
            get
            {
                _.Move(REG_ARQ_ANAL, _ARQ_ANAL); VarBasis.RedefinePassValue(REG_ARQ_ANAL, _ARQ_ANAL, REG_ARQ_ANAL); return _ARQ_ANAL;
            }
        }
        /*"01  REG-ARQ-ANAL                 PIC X(800).*/
        public StringBasis REG_ARQ_ANAL { get; set; } = new StringBasis(new PIC("X", "800", "X(800)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-DATA-MOVIMENTO         PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-DATA-ESTORNO           PIC  X(10)    VALUE SPACES.*/
        public StringBasis HOST_DATA_ESTORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-QTDE                   PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis HOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-CONT-PROC-JURID        PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis HOST_CONT_PROC_JURID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COD-CAUSA              PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis HOST_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-COD-OPERACAO           PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis HOST_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-QTD-PENDENTE           PIC S9(13)    COMP-3 VALUE 0.*/
        public IntBasis HOST_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-VLR-PENDENTE           PIC S9(11)V99 COMP-3 VALUE 0.*/
        public DoubleBasis HOST_VLR_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  HOST-VLR-PAGO               PIC S9(11)V99 COMP-3 VALUE 0.*/
        public DoubleBasis HOST_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  HOST-VLR-AVISADO            PIC S9(11)V99 COMP-3 VALUE 0.*/
        public DoubleBasis HOST_VLR_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  HOST-VAL-OPERACAO           PIC S9(11)V99 COMP-3 VALUE 0.*/
        public DoubleBasis HOST_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  HOST-NUM-APOLICE            PIC S9(13)    COMP-3 VALUE 0.*/
        public IntBasis HOST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-COD-CLIENTE            PIC S9(09)    COMP   VALUE 0.*/
        public IntBasis HOST_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HOST-COUNT                  PIC S9(09)    COMP   VALUE 0.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  W-GDA-DATA-INICIO           PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_GDA_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-DATA-AVISO            PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_GDA_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-DATA-COMUNICADO       PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_GDA_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-DATA-OCORRENCIA       PIC  X(10)    VALUE SPACES.*/
        public StringBasis W_GDA_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-RAMO                  PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-COD-CAUSA             PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-COD-FONTE             PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-COD-RAMO              PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_COD_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-COD-PRODUTO           PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-RAMO-ANT              PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_RAMO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-PROD-ANT              PIC  9(04)    VALUE  0.*/
        public IntBasis W_GDA_PROD_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-APOL-ANT              PIC  9(13)    VALUE  0.*/
        public IntBasis W_GDA_APOL_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-GDA-SINI-ANT              PIC  9(13)    VALUE  0.*/
        public IntBasis W_GDA_SINI_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-GDA-FONT-ANT              PIC  9(13)    VALUE  0.*/
        public IntBasis W_GDA_FONT_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-GDA-GRUP-ANT              PIC  X(20)    VALUE  SPACES.*/
        public StringBasis W_GDA_GRUP_ANT { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
        /*"77  W-QTD-DIAS                  PIC  9(04)    VALUE  0.*/
        public IntBasis W_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-GDA-SINISTRO              PIC  9(13)    VALUE  0.*/
        public IntBasis W_GDA_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-ACUM-VAL-AVISADO          PIC S9(13)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_ACUM_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-ACUM-VAL-PAGO             PIC S9(13)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_ACUM_VAL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-ACUM-VAL-PENDENTE         PIC S9(13)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_ACUM_VAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-ACUM-VAL-CANCELADO        PIC S9(13)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_ACUM_VAL_CANCELADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  W-GDA-QTD-AVISADO           PIC  9(13)           VALUE  0.*/
        public IntBasis W_GDA_QTD_AVISADO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-GDA-QTD-PAGO              PIC  9(13)           VALUE  0.*/
        public IntBasis W_GDA_QTD_PAGO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-GDA-QTD-PENDENTE          PIC  9(13)           VALUE  0.*/
        public IntBasis W_GDA_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-GDA-QTD-CANCELADO         PIC  9(13)           VALUE  0.*/
        public IntBasis W_GDA_QTD_CANCELADO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-QTD-SIN-AVISADOS          PIC  9(13)           VALUE  0.*/
        public IntBasis W_QTD_SIN_AVISADOS { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-VLR-SIN-AVISADOS          PIC S9(11)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_VLR_SIN_AVISADOS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  W-QTD-SIN-CANCELADOS        PIC  9(13)           VALUE  0.*/
        public IntBasis W_QTD_SIN_CANCELADOS { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-VLR-SIN-CANCELADOS        PIC S9(11)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_VLR_SIN_CANCELADOS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  W-QTD-SIN-PAGOS             PIC  9(13)           VALUE  0.*/
        public IntBasis W_QTD_SIN_PAGOS { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-VLR-SIN-PAGOS             PIC S9(11)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_VLR_SIN_PAGOS { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  W-QTD-SIN-PENDENTE          PIC  9(13)           VALUE  0.*/
        public IntBasis W_QTD_SIN_PENDENTE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77  W-VLR-SIN-PENDENTE          PIC S9(11)V99 COMP-3 VALUE  0.*/
        public DoubleBasis W_VLR_SIN_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99"), 2);
        /*"77  W-SBS-TAB                   PIC  9(04)  VALUE  0.*/
        public IntBasis W_SBS_TAB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-SBS2-TAB                  PIC  9(04)  VALUE  0.*/
        public IntBasis W_SBS2_TAB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-IND-TAB                   PIC  9(04)  VALUE  0.*/
        public IntBasis W_IND_TAB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-CHAVE-JA-LEU-CLIENTE           PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_JA_LEU_CLIENTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-CHAVE-ESTORNO-APOS-DTMOVABE    PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_ESTORNO_APOS_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-CHAVE-APOLICE-EH-BILHETE       PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_APOLICE_EH_BILHETE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-CHAVE-APOLICE-EH-AUTO          PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_CHAVE_APOLICE_EH_AUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-GRAVOU                         PIC  X(03)  VALUE  'NAO'.*/
        public StringBasis W_GRAVOU { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"01 INICIO-WORK.*/
        public SI0874B_INICIO_WORK INICIO_WORK { get; set; } = new SI0874B_INICIO_WORK();
        public class SI0874B_INICIO_WORK : VarBasis
        {
            /*"    03 W-IND-FIM-CTRAB               PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_CTRAB { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-FIM-RESUMO              PIC X(03) VALUE 'NAO'.*/
            public StringBasis W_IND_FIM_RESUMO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 WFIM-CURSOR-RETENCOES          PIC X(03) VALUE 'NAO'.*/
            public StringBasis WFIM_CURSOR_RETENCOES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03            WSQLCODE3          PIC S9(09) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03 W-CONTA-LIDOS                 PIC 9(07) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    03 W-CONTA-LIDOS1                PIC 9(07) VALUE ZEROS.*/
            public IntBasis W_CONTA_LIDOS1 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    03 W-DATA-AMD-10.*/
            public SI0874B_W_DATA_AMD_10 W_DATA_AMD_10 { get; set; } = new SI0874B_W_DATA_AMD_10();
            public class SI0874B_W_DATA_AMD_10 : VarBasis
            {
                /*"       05 W-DATA-ANO-10               PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_ANO_10 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-MES-10               PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_MES_10 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-DIA-10               PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_DIA_10 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03 W-DATA-AMD-08A                 PIC 9(08) VALUE ZEROS.*/
            }
            public IntBasis W_DATA_AMD_08A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03 FILLER REDEFINES W-DATA-AMD-08A.*/
            private _REDEF_SI0874B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_SI0874B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_SI0874B_FILLER_2(); _.Move(W_DATA_AMD_08A, _filler_2); VarBasis.RedefinePassValue(W_DATA_AMD_08A, _filler_2, W_DATA_AMD_08A); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_AMD_08A); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_AMD_08A); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_2 : VarBasis
            {
                /*"       05 W-DATA-ANO-08A              PIC 9(04).*/
                public IntBasis W_DATA_ANO_08A { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 W-DATA-MES-08A              PIC 9(02).*/
                public IntBasis W_DATA_MES_08A { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-DATA-DIA-08A              PIC 9(02).*/
                public IntBasis W_DATA_DIA_08A { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 W-DATA-AMD-08B                 PIC 9(08) VALUE ZEROS.*/

                public _REDEF_SI0874B_FILLER_2()
                {
                    W_DATA_ANO_08A.ValueChanged += OnValueChanged;
                    W_DATA_MES_08A.ValueChanged += OnValueChanged;
                    W_DATA_DIA_08A.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_AMD_08B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03 FILLER REDEFINES W-DATA-AMD-08B.*/
            private _REDEF_SI0874B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_SI0874B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_SI0874B_FILLER_3(); _.Move(W_DATA_AMD_08B, _filler_3); VarBasis.RedefinePassValue(W_DATA_AMD_08B, _filler_3, W_DATA_AMD_08B); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_DATA_AMD_08B); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_DATA_AMD_08B); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_3 : VarBasis
            {
                /*"       05 W-DATA-ANO-08B              PIC 9(04).*/
                public IntBasis W_DATA_ANO_08B { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 W-DATA-MES-08B              PIC 9(02).*/
                public IntBasis W_DATA_MES_08B { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-DATA-DIA-08B              PIC 9(02).*/
                public IntBasis W_DATA_DIA_08B { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 W-DATA-DMA-08A                     PIC 9(08) VALUE ZEROS.*/

                public _REDEF_SI0874B_FILLER_3()
                {
                    W_DATA_ANO_08B.ValueChanged += OnValueChanged;
                    W_DATA_MES_08B.ValueChanged += OnValueChanged;
                    W_DATA_DIA_08B.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_DMA_08A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03 FILLER REDEFINES W-DATA-DMA-08A.*/
            private _REDEF_SI0874B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_SI0874B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_SI0874B_FILLER_4(); _.Move(W_DATA_DMA_08A, _filler_4); VarBasis.RedefinePassValue(W_DATA_DMA_08A, _filler_4, W_DATA_DMA_08A); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_DATA_DMA_08A); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_DATA_DMA_08A); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_4 : VarBasis
            {
                /*"       05 W-DATA-DD-08A              PIC 9(02).*/
                public IntBasis W_DATA_DD_08A { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-DATA-MM-08A              PIC 9(02).*/
                public IntBasis W_DATA_MM_08A { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-DATA-AA-08A              PIC 9(04).*/
                public IntBasis W_DATA_AA_08A { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03 W-DATA-DMA-08B                     PIC 9(08) VALUE ZEROS.*/

                public _REDEF_SI0874B_FILLER_4()
                {
                    W_DATA_DD_08A.ValueChanged += OnValueChanged;
                    W_DATA_MM_08A.ValueChanged += OnValueChanged;
                    W_DATA_AA_08A.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_DMA_08B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03 FILLER REDEFINES W-DATA-DMA-08B.*/
            private _REDEF_SI0874B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_SI0874B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_SI0874B_FILLER_5(); _.Move(W_DATA_DMA_08B, _filler_5); VarBasis.RedefinePassValue(W_DATA_DMA_08B, _filler_5, W_DATA_DMA_08B); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_DATA_DMA_08B); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_DATA_DMA_08B); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_5 : VarBasis
            {
                /*"       05 W-DATA-DD-08B              PIC 9(02).*/
                public IntBasis W_DATA_DD_08B { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-DATA-MM-08B              PIC 9(02).*/
                public IntBasis W_DATA_MM_08B { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-DATA-AA-08B              PIC 9(04).*/
                public IntBasis W_DATA_AA_08B { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    03 W-DATA-AMD.*/

                public _REDEF_SI0874B_FILLER_5()
                {
                    W_DATA_DD_08B.ValueChanged += OnValueChanged;
                    W_DATA_MM_08B.ValueChanged += OnValueChanged;
                    W_DATA_AA_08B.ValueChanged += OnValueChanged;
                }

            }
            public SI0874B_W_DATA_AMD W_DATA_AMD { get; set; } = new SI0874B_W_DATA_AMD();
            public class SI0874B_W_DATA_AMD : VarBasis
            {
                /*"       05 W-DATA-AMD-ANO              PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AMD_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-AMD-MES              PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AMD_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       05 FILLER                      PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"       05 W-DATA-AMD-DIA              PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AMD_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    03 W-DATA-AVISO                   PIC X(10) VALUE SPACES.*/
            }
            public StringBasis W_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER REDEFINES W-DATA-AVISO.*/
            private _REDEF_SI0874B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_SI0874B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_SI0874B_FILLER_8(); _.Move(W_DATA_AVISO, _filler_8); VarBasis.RedefinePassValue(W_DATA_AVISO, _filler_8, W_DATA_AVISO); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_DATA_AVISO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_DATA_AVISO); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_8 : VarBasis
            {
                /*"       05 W-DATA-AV-AA                PIC 9(04).*/
                public IntBasis W_DATA_AV_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                      PIC X(01).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 W-DATA-AV-MM                PIC 9(02).*/
                public IntBasis W_DATA_AV_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                      PIC X(01).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 W-DATA-AV-DD                PIC 9(02).*/
                public IntBasis W_DATA_AV_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 W-DATA-AVISO01                 PIC X(10) VALUE SPACES.*/

                public _REDEF_SI0874B_FILLER_8()
                {
                    W_DATA_AV_AA.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    W_DATA_AV_MM.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    W_DATA_AV_DD.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_AVISO01 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER REDEFINES W-DATA-AVISO01.*/
            private _REDEF_SI0874B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_SI0874B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_SI0874B_FILLER_11(); _.Move(W_DATA_AVISO01, _filler_11); VarBasis.RedefinePassValue(W_DATA_AVISO01, _filler_11, W_DATA_AVISO01); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_DATA_AVISO01); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W_DATA_AVISO01); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_11 : VarBasis
            {
                /*"       05 W-DATA-AV-AA01              PIC 9(04).*/
                public IntBasis W_DATA_AV_AA01 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                      PIC X(01).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 W-DATA-AV-MM01              PIC 9(02).*/
                public IntBasis W_DATA_AV_MM01 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                      PIC X(01).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 W-DATA-AV-DD01              PIC 9(02).*/
                public IntBasis W_DATA_AV_DD01 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    03 W-DATA-AVISO02                 PIC X(10) VALUE SPACES.*/

                public _REDEF_SI0874B_FILLER_11()
                {
                    W_DATA_AV_AA01.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    W_DATA_AV_MM01.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    W_DATA_AV_DD01.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_AVISO02 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER REDEFINES W-DATA-AVISO02.*/
            private _REDEF_SI0874B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_SI0874B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_SI0874B_FILLER_14(); _.Move(W_DATA_AVISO02, _filler_14); VarBasis.RedefinePassValue(W_DATA_AVISO02, _filler_14, W_DATA_AVISO02); _filler_14.ValueChanged += () => { _.Move(_filler_14, W_DATA_AVISO02); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, W_DATA_AVISO02); }
            }  //Redefines
            public class _REDEF_SI0874B_FILLER_14 : VarBasis
            {
                /*"       05 W-DATA-AV-AA02              PIC 9(04).*/
                public IntBasis W_DATA_AV_AA02 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       05 FILLER                      PIC X(01).*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 W-DATA-AV-MM02              PIC 9(02).*/
                public IntBasis W_DATA_AV_MM02 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 FILLER                      PIC X(01).*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       05 W-DATA-AV-DD02              PIC 9(02).*/
                public IntBasis W_DATA_AV_DD02 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"01 W-SINIHAB1-CONTRATO.*/

                public _REDEF_SI0874B_FILLER_14()
                {
                    W_DATA_AV_AA02.ValueChanged += OnValueChanged;
                    FILLER_15.ValueChanged += OnValueChanged;
                    W_DATA_AV_MM02.ValueChanged += OnValueChanged;
                    FILLER_16.ValueChanged += OnValueChanged;
                    W_DATA_AV_DD02.ValueChanged += OnValueChanged;
                }

            }
        }
        public SI0874B_W_SINIHAB1_CONTRATO W_SINIHAB1_CONTRATO { get; set; } = new SI0874B_W_SINIHAB1_CONTRATO();
        public class SI0874B_W_SINIHAB1_CONTRATO : VarBasis
        {
            /*"   03 FILLER                          PIC 9(06) VALUE 0.*/
            public IntBasis FILLER_17 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"   03 W-SINIHAB1-OPERACAO             PIC 9(01) VALUE 0.*/
            public IntBasis W_SINIHAB1_OPERACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINIHAB1-PONTO-VENDA          PIC 9(04) VALUE 0.*/
            public IntBasis W_SINIHAB1_PONTO_VENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINIHAB1-NUM-CONTRATO         PIC 9(08) VALUE 0.*/
            public IntBasis W_SINIHAB1_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"01 W-SINCREIN-CONTRATO.*/
        }
        public SI0874B_W_SINCREIN_CONTRATO W_SINCREIN_CONTRATO { get; set; } = new SI0874B_W_SINCREIN_CONTRATO();
        public class SI0874B_W_SINCREIN_CONTRATO : VarBasis
        {
            /*"   03 W-SINCREIN-COD-SUREG            PIC 9(02) VALUE 0.*/
            public IntBasis W_SINCREIN_COD_SUREG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINCREIN-COD-AGENCIA          PIC 9(04) VALUE 0.*/
            public IntBasis W_SINCREIN_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINCREIN-COD-OPERACAO         PIC 9(03) VALUE 0.*/
            public IntBasis W_SINCREIN_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINCREIN-NUM-CONTRATO         PIC 9(08) VALUE 0.*/
            public IntBasis W_SINCREIN_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINCREIN-CONTRATO-DIGITO      PIC 9(02) VALUE 0.*/
            public IntBasis W_SINCREIN_CONTRATO_DIGITO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"01 W-SINIPENH-CONTRATO.*/
        }
        public SI0874B_W_SINIPENH_CONTRATO W_SINIPENH_CONTRATO { get; set; } = new SI0874B_W_SINIPENH_CONTRATO();
        public class SI0874B_W_SINIPENH_CONTRATO : VarBasis
        {
            /*"   03 FILLER                          PIC 9(06) VALUE 0.*/
            public IntBasis FILLER_24 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"   03 W-SINIPENH-COD-AGENCIA          PIC 9(04) VALUE 0.*/
            public IntBasis W_SINIPENH_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINIPENH-NUM-CONTRATO         PIC 9(08) VALUE 0.*/
            public IntBasis W_SINIPENH_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"   03 FILLER                          PIC X(01) VALUE '-'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"   03 W-SINIPENH-DV-CONTRATO          PIC X(01) VALUE SPACE.*/
            public StringBasis W_SINIPENH_DV_CONTRATO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"01 W-GDA-SIVAT                        PIC X(11) VALUE SPACES.*/
        }
        public StringBasis W_GDA_SIVAT { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
        /*"01 FILLER REDEFINES W-GDA-SIVAT.*/
        private _REDEF_SI0874B_FILLER_27 _filler_27 { get; set; }
        public _REDEF_SI0874B_FILLER_27 FILLER_27
        {
            get { _filler_27 = new _REDEF_SI0874B_FILLER_27(); _.Move(W_GDA_SIVAT, _filler_27); VarBasis.RedefinePassValue(W_GDA_SIVAT, _filler_27, W_GDA_SIVAT); _filler_27.ValueChanged += () => { _.Move(_filler_27, W_GDA_SIVAT); }; return _filler_27; }
            set { VarBasis.RedefinePassValue(value, _filler_27, W_GDA_SIVAT); }
        }  //Redefines
        public class _REDEF_SI0874B_FILLER_27 : VarBasis
        {
            /*"   03 W-GDA-NUM-SIVAT                 PIC 9(09).*/
            public IntBasis W_GDA_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   03 W-GDA-TRACO                     PIC X(01).*/
            public StringBasis W_GDA_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   03 W-GDA-DV-SIVAT                  PIC X(01).*/
            public StringBasis W_GDA_DV_SIVAT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"01  ANAL.*/

            public _REDEF_SI0874B_FILLER_27()
            {
                W_GDA_NUM_SIVAT.ValueChanged += OnValueChanged;
                W_GDA_TRACO.ValueChanged += OnValueChanged;
                W_GDA_DV_SIVAT.ValueChanged += OnValueChanged;
            }

        }
        public SI0874B_ANAL ANAL { get; set; } = new SI0874B_ANAL();
        public class SI0874B_ANAL : VarBasis
        {
            /*"    03 ANAL-FONTE              PIC  --9.*/
            public IntBasis ANAL_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "--9."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-RAMO               PIC 9(02) VALUE 0.*/
            public IntBasis ANAL_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NOME-RAMO          PIC X(40) VALUE SPACES.*/
            public StringBasis ANAL_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-COD-PRODUTO        PIC 9(04) VALUE 0.*/
            public IntBasis ANAL_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NOME-PRODUTO       PIC X(40) VALUE SPACES.*/
            public StringBasis ANAL_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NUM-APOLICE        PIC 9(13) VALUE 0.*/
            public IntBasis ANAL_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NUM-SINISTRO       PIC 9(13) VALUE 0.*/
            public IntBasis ANAL_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-CAUSA-SINISTRO     PIC X(40) VALUE SPACES.*/
            public StringBasis ANAL_CAUSA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-GRUPO-CAUSAS       PIC X(20) VALUE SPACES.*/
            public StringBasis ANAL_GRUPO_CAUSAS { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-SEGURADO           PIC X(40) VALUE SPACES.*/
            public StringBasis ANAL_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-CGCCPF             PIC 9(15) VALUE 0.*/
            public IntBasis ANAL_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NUM-CONTRATO       PIC X(23) VALUE SPACES.*/
            public StringBasis ANAL_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-MAT-ORIGEM         PIC X(06) VALUE SPACES.*/
            public StringBasis ANAL_MAT_ORIGEM { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NUM-MATRICULA      PIC 9(09) VALUE ZEROS.*/
            public IntBasis ANAL_NUM_MATRICULA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-CHEQUE-INTERNO     PIC 9(09) VALUE ZEROS.*/
            public IntBasis ANAL_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NUM-SIVAT          PIC X(11) VALUE SPACES.*/
            public StringBasis ANAL_NUM_SIVAT { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-SIVAT         PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_SIVAT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-STATUS             PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_STATUS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-CODIGO-OPERACAO    PIC 9(05) VALUE ZEROS.*/
            public IntBasis ANAL_CODIGO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DESCRICAO-OPERACAO PIC X(40) VALUE SPACES.*/
            public StringBasis ANAL_DESCRICAO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NOME-FAVORECIDO    PIC X(40) VALUE SPACES.*/
            public StringBasis ANAL_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-COD-FAVORECIDO     PIC 9(09) VALUE ZEROS.*/
            public IntBasis ANAL_COD_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-CGCCPF-FAVORECIDO  PIC 9(14) VALUE ZEROS.*/
            public IntBasis ANAL_CGCCPF_FAVORECIDO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-USUARIO-LANCAMENTO PIC X(08) VALUE SPACES.*/
            public StringBasis ANAL_USUARIO_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-AREA-LANCAMENTO    PIC X(20) VALUE SPACES.*/
            public StringBasis ANAL_AREA_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DEPART-USUARIO     PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DEPART_USUARIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-NUM-IRB            PIC 9(11) VALUE 0.*/
            public IntBasis ANAL_NUM_IRB { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-OCORRENCIA    PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-COMUNICADO    PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-TEM-PROC-JURI      PIC X(03) VALUE SPACES.*/
            public StringBasis ANAL_TEM_PROC_JURI { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-LANCAMENTO    PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-PAGAMENTO     PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-VLR-AVISADO        PIC ------------9.99.*/
            public IntBasis ANAL_VLR_AVISADO { get; set; } = new IntBasis(new PIC("9", "15", "------------9.99."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-VLR-OPERACAO       PIC ------------9.99.*/
            public IntBasis ANAL_VLR_OPERACAO { get; set; } = new IntBasis(new PIC("9", "15", "------------9.99."));
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-PREVISTA-PAG  PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_PREVISTA_PAG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-PERIODICIDADE      PIC X(01) VALUE SPACES.*/
            public StringBasis ANAL_PERIODICIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    03 ANAL-DATA-GERACAO       PIC X(10) VALUE SPACES.*/
            public StringBasis ANAL_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    03 FILLER                  PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01          WABEND1.*/
        }
        public SI0874B_WABEND1 WABEND1 { get; set; } = new SI0874B_WABEND1();
        public class SI0874B_WABEND1 : VarBasis
        {
            /*"    05      FILLER              PIC  X(10) VALUE           ' SI0874B'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" SI0874B");
            /*"    05      FILLER              PIC  X(28) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(03) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"000");
            /*"    05      FILLER              PIC  X(17) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @" *** PARAGRAFO = ");
            /*"    05      WPARAGRAFO          PIC  X(30) VALUE SPACES.*/
            public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
            /*"01          WABEND2.*/
        }
        public SI0874B_WABEND2 WABEND2 { get; set; } = new SI0874B_WABEND2();
        public class SI0874B_WABEND2 : VarBasis
        {
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(14) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01          LK-LINK-PERIODICIDADE.*/
        }
        public SI0874B_LK_LINK_PERIODICIDADE LK_LINK_PERIODICIDADE { get; set; } = new SI0874B_LK_LINK_PERIODICIDADE();
        public class SI0874B_LK_LINK_PERIODICIDADE : VarBasis
        {
            /*"  03        LK-TAMANHO-PARM     PIC  S9(04) COMP.*/
            public IntBasis LK_TAMANHO_PARM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03        LK-PERIODO          PIC   X(01).*/
            public StringBasis LK_PERIODO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.RAMOS RAMOS { get; set; } = new Dclgens.RAMOS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SITRATEM SITRATEM { get; set; } = new Dclgens.SITRATEM();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.SINISAUT SINISAUT { get; set; } = new Dclgens.SINISAUT();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.SINISACO SINISACO { get; set; } = new Dclgens.SINISACO();
        public Dclgens.CODIGOPE CODIGOPE { get; set; } = new Dclgens.CODIGOPE();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.SINIPENH SINIPENH { get; set; } = new Dclgens.SINIPENH();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.SIEPEMHB SIEPEMHB { get; set; } = new Dclgens.SIEPEMHB();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.SINIPLAN SINIPLAN { get; set; } = new Dclgens.SINIPLAN();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.SIPROJUD SIPROJUD { get; set; } = new Dclgens.SIPROJUD();
        public SI0874B_CTRAB CTRAB { get; set; } = new SI0874B_CTRAB();
        public SI0874B_APOLICE_CREDITO_C APOLICE_CREDITO_C { get; set; } = new SI0874B_APOLICE_CREDITO_C();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI0874B_LK_LINK_PERIODICIDADE SI0874B_LK_LINK_PERIODICIDADE_P, string ARQ_ANAL_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_LINK_PERIODICIDADE*/
        {
            try
            {
                this.LK_LINK_PERIODICIDADE = SI0874B_LK_LINK_PERIODICIDADE_P;
                ARQ_ANAL.SetFile(ARQ_ANAL_FILE_NAME_P);

                /*" -499- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -500- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -501- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -506- OPEN OUTPUT ARQ-ANAL. */
                ARQ_ANAL.Open(REG_ARQ_ANAL);

                /*" -508- PERFORM R010-LE-SISTEMA THRU R010-EXIT. */

                R010_LE_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -509- MOVE 'NAO' TO W-IND-FIM-CTRAB. */
                _.Move("NAO", INICIO_WORK.W_IND_FIM_CTRAB);

                /*" -510- DISPLAY 'LK-PERIODO ' LK-PERIODO. */
                _.Display($"LK-PERIODO {LK_LINK_PERIODICIDADE.LK_PERIODO}");

                /*" -512- PERFORM R030-DECLARE-CTRAB THRU R030-EXIT. */

                R030_DECLARE_CTRAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


                /*" -514- PERFORM R031-FETCH-CTRAB THRU R031-EXIT. */

                R031_FETCH_CTRAB(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


                /*" -515- IF W-IND-FIM-CTRAB EQUAL 'SIM' */

                if (INICIO_WORK.W_IND_FIM_CTRAB == "SIM")
                {

                    /*" -516- DISPLAY 'SI0874B  - NAO HA MOVIMENTACAO DE SINISTRO' */
                    _.Display($"SI0874B  - NAO HA MOVIMENTACAO DE SINISTRO");

                    /*" -522- GO TO 000-900-FIM. */

                    M_000_900_FIM(); //GOTO
                    return Result;
                }


                /*" -523- PERFORM R100-PROCESSA-CTRAB THRU R100-EXIT UNTIL W-IND-FIM-CTRAB EQUAL 'SIM' . */

                while (!(INICIO_WORK.W_IND_FIM_CTRAB == "SIM"))
                {

                    R100_PROCESSA_CTRAB(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -523- FLUXCONTROL_PERFORM M-000-900-FIM */

                M_000_900_FIM();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_LINK_PERIODICIDADE, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -530- CLOSE ARQ-ANAL. */
            ARQ_ANAL.Close();

            /*" -531- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -532- DISPLAY 'SI0874B         *** FIM NORMAL ***' . */
            _.Display($"SI0874B         *** FIM NORMAL ***");

            /*" -532- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-LE-SISTEMA */
        private void R010_LE_SISTEMA(bool isPerform = false)
        {
            /*" -540- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", WABEND1.WNR_EXEC_SQL);

            /*" -542- MOVE 'R010-LE-SISTEMA' TO WPARAGRAFO. */
            _.Move("R010-LE-SISTEMA", WABEND1.WPARAGRAFO);

            /*" -549- PERFORM R010_LE_SISTEMA_DB_SELECT_1 */

            R010_LE_SISTEMA_DB_SELECT_1();

            /*" -551- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -552- DISPLAY 'ERRO SELECT - SISTEMAS....................' */
                _.Display($"ERRO SELECT - SISTEMAS....................");

                /*" -554- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -555- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -556- DISPLAY '* PROGRAMA SI0874B                              *' */
            _.Display($"* PROGRAMA SI0874B                              *");

            /*" -557- DISPLAY '*************************************************' */
            _.Display($"*************************************************");

            /*" -558- DISPLAY ' ' . */
            _.Display($" ");

            /*" -559- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -564- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) SISTEMAS-DATA-MOV-ABERTO(8:1) SISTEMAS-DATA-MOV-ABERTO(6:2) SISTEMAS-DATA-MOV-ABERTO(5:1) SISTEMAS-DATA-MOV-ABERTO(1:4) '' . */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -565- DISPLAY ' ' . */
            _.Display($" ");

            /*" -566- DISPLAY 'DATA DO ULTIMO PROCESSAMENTO(SI)' . */
            _.Display($"DATA DO ULTIMO PROCESSAMENTO(SI)");

            /*" -571- DISPLAY SISTEMAS-DATULT-PROCESSAMEN(9:2) SISTEMAS-DATULT-PROCESSAMEN(8:1) SISTEMAS-DATULT-PROCESSAMEN(6:2) SISTEMAS-DATULT-PROCESSAMEN(5:1) SISTEMAS-DATULT-PROCESSAMEN(1:4) '' . */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(9, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(8, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(6, 2)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(5, 1)}{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN.Substring(1, 4)}"
            .Display();

            /*" -574- DISPLAY ' ' . */
            _.Display($" ");

            /*" -575- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AMD. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, INICIO_WORK.W_DATA_AMD);

            /*" -576- MOVE 01 TO W-DATA-AMD-DIA. */
            _.Move(01, INICIO_WORK.W_DATA_AMD.W_DATA_AMD_DIA);

            /*" -578- MOVE W-DATA-AMD TO W-GDA-DATA-INICIO. */
            _.Move(INICIO_WORK.W_DATA_AMD, W_GDA_DATA_INICIO);

            /*" -579- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", WABEND1.WNR_EXEC_SQL);

            /*" -581- MOVE 'R010-LE-SISTEMA' TO WPARAGRAFO. */
            _.Move("R010-LE-SISTEMA", WABEND1.WPARAGRAFO);

            /*" -589- PERFORM R010_LE_SISTEMA_DB_SELECT_2 */

            R010_LE_SISTEMA_DB_SELECT_2();

            /*" -592- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -593- DISPLAY 'ERRO NO CALCULO DA SEMANA DE REFERENCIA..' */
                _.Display($"ERRO NO CALCULO DA SEMANA DE REFERENCIA..");

                /*" -595- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -595- MOVE HOST-QTDE TO SITRATEM-DTH-SEMANA-REF. */
            _.Move(HOST_QTDE, SITRATEM.DCLSI_TRAB_TEMP01.SITRATEM_DTH_SEMANA_REF);

        }

        [StopWatch]
        /*" R010-LE-SISTEMA-DB-SELECT-1 */
        public void R010_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -549- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_LE_SISTEMA_DB_SELECT_1_Query1 = new R010_LE_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMA_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R010-LE-SISTEMA-DB-SELECT-2 */
        public void R010_LE_SISTEMA_DB_SELECT_2()
        {
            /*" -589- EXEC SQL SELECT COUNT(*) INTO :HOST-QTDE FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO BETWEEN :W-GDA-DATA-INICIO AND :SISTEMAS-DATA-MOV-ABERTO AND ((DIA_SEMANA = '6' ) OR (DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO)) END-EXEC. */

            var r010_LE_SISTEMA_DB_SELECT_2_Query1 = new R010_LE_SISTEMA_DB_SELECT_2_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                W_GDA_DATA_INICIO = W_GDA_DATA_INICIO.ToString(),
            };

            var executed_1 = R010_LE_SISTEMA_DB_SELECT_2_Query1.Execute(r010_LE_SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_QTDE, HOST_QTDE);
            }


        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB */
        private void R030_DECLARE_CTRAB(bool isPerform = false)
        {
            /*" -603- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", WABEND1.WNR_EXEC_SQL);

            /*" -605- MOVE 'R030-DECLARE-CTRAB' TO WPARAGRAFO. */
            _.Move("R030-DECLARE-CTRAB", WABEND1.WPARAGRAFO);

            /*" -657- PERFORM R030_DECLARE_CTRAB_DB_DECLARE_1 */

            R030_DECLARE_CTRAB_DB_DECLARE_1();

            /*" -662- PERFORM R030_DECLARE_CTRAB_DB_OPEN_1 */

            R030_DECLARE_CTRAB_DB_OPEN_1();

            /*" -665- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -666- DISPLAY 'ERRO NA ABERTURA DO CURSOR PRINCIPAL ....' */
                _.Display($"ERRO NA ABERTURA DO CURSOR PRINCIPAL ....");

                /*" -666- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-DECLARE-1 */
        public void R030_DECLARE_CTRAB_DB_DECLARE_1()
        {
            /*" -657- EXEC SQL DECLARE CTRAB CURSOR FOR SELECT H.NUM_APOL_SINISTRO, P.FUNCAO_OPERACAO, P.DES_OPERACAO, M.NUM_APOLICE, M.RAMO, M.COD_PRODUTO, M.COD_CAUSA, M.COD_FONTE, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, M.NUM_ENDOSSO, M.COD_SUBGRUPO, M.NUM_CERTIFICADO, M.TIPO_SEGURADO, M.NUM_PROTOCOLO_SINI, M.NUM_IRB, H.SIT_REGISTRO, H.DATA_MOVIMENTO, H.HORA_OPERACAO, H.COD_OPERACAO, H.OCORR_HISTORICO, H.VAL_OPERACAO, H.DATA_LIM_CORRECAO, H.COD_USUARIO, H.NOME_FAVORECIDO, H.COD_PREST_SERVICO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_MESTRE M, SEGUROS.GE_OPERACAO P WHERE H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO BETWEEN :W-GDA-DATA-INICIO AND :SISTEMAS-DATA-MOV-ABERTO AND P.FUNCAO_OPERACAO IN ( 'JPDES' , 'JPHON' , 'DMOV' , 'HMOV' , 'JBDES' , 'JBHON' , 'DPAG' , 'HPAG' , 'JEDES' , 'JEHON' , 'DEST' , 'HEST' ) AND H.COD_OPERACAO = P.COD_OPERACAO AND P.IDE_SISTEMA = 'SI' AND H.NUM_APOL_SINISTRO NOT IN (104800054601, 104800054611, 104800054614, 104800054615, 104800054616, 104800054617, 104800054618, 104800054683, 104800054684, 104800054685, 104800066217, 104800068820, 104800068823, 104800068917, 104800069083, 104800069085, 104800070833) ORDER BY H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.DATA_MOVIMENTO, H.COD_OPERACAO WITH UR END-EXEC. */
            CTRAB = new SI0874B_CTRAB(true);
            string GetQuery_CTRAB()
            {
                var query = @$"SELECT H.NUM_APOL_SINISTRO
							, 
							P.FUNCAO_OPERACAO
							, 
							P.DES_OPERACAO
							, 
							M.NUM_APOLICE
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_CAUSA
							, 
							M.COD_FONTE
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							M.NUM_ENDOSSO
							, 
							M.COD_SUBGRUPO
							, 
							M.NUM_CERTIFICADO
							, 
							M.TIPO_SEGURADO
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_IRB
							, 
							H.SIT_REGISTRO
							, 
							H.DATA_MOVIMENTO
							, 
							H.HORA_OPERACAO
							, 
							H.COD_OPERACAO
							, 
							H.OCORR_HISTORICO
							, 
							H.VAL_OPERACAO
							, 
							H.DATA_LIM_CORRECAO
							, 
							H.COD_USUARIO
							, 
							H.NOME_FAVORECIDO
							, 
							H.COD_PREST_SERVICO 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.GE_OPERACAO P 
							WHERE H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO BETWEEN '{W_GDA_DATA_INICIO}' AND 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND P.FUNCAO_OPERACAO IN ( 'JPDES'
							, 'JPHON'
							, 
							'DMOV'
							, 'HMOV'
							, 
							'JBDES'
							, 'JBHON'
							, 
							'DPAG'
							, 'HPAG'
							, 
							'JEDES'
							, 'JEHON'
							, 
							'DEST'
							, 'HEST' ) 
							AND H.COD_OPERACAO = P.COD_OPERACAO 
							AND P.IDE_SISTEMA = 'SI' 
							AND H.NUM_APOL_SINISTRO NOT IN 
							(104800054601
							, 104800054611
							, 104800054614
							, 104800054615
							, 
							104800054616
							, 104800054617
							, 104800054618
							, 104800054683
							, 
							104800054684
							, 104800054685
							, 104800066217
							, 104800068820
							, 
							104800068823
							, 104800068917
							, 104800069083
							, 104800069085
							, 
							104800070833) 
							ORDER BY H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.DATA_MOVIMENTO
							, 
							H.COD_OPERACAO";

                return query;
            }
            CTRAB.GetQueryEvent += GetQuery_CTRAB;

        }

        [StopWatch]
        /*" R030-DECLARE-CTRAB-DB-OPEN-1 */
        public void R030_DECLARE_CTRAB_DB_OPEN_1()
        {
            /*" -662- EXEC SQL OPEN CTRAB END-EXEC. */

            CTRAB.Open();

        }

        [StopWatch]
        /*" R940-ACESSO-SINCREDINT-DB-DECLARE-1 */
        public void R940_ACESSO_SINCREDINT_DB_DECLARE_1()
        {
            /*" -1272- EXEC SQL DECLARE APOLICE-CREDITO-C CURSOR FOR SELECT PROPRIET, CGCCPF FROM SEGUROS.APOLICE_CREDITO WHERE COD_SUREG = :SINCREIN-COD-SUREG AND COD_AGENCIA = :SINCREIN-COD-AGENCIA AND COD_OPERACAO = :SINCREIN-COD-OPERACAO AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO AND SITUACAO = :SINCREIN-SIT-REGISTRO WITH UR END-EXEC. */
            APOLICE_CREDITO_C = new SI0874B_APOLICE_CREDITO_C(true);
            string GetQuery_APOLICE_CREDITO_C()
            {
                var query = @$"SELECT PROPRIET
							, 
							CGCCPF 
							FROM SEGUROS.APOLICE_CREDITO 
							WHERE COD_SUREG = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG}' 
							AND COD_AGENCIA = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA}' 
							AND COD_OPERACAO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}' 
							AND NUM_CONTRATO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO}' 
							AND CONTRATO_DIGITO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO}' 
							AND SITUACAO = '{SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO}'";

                return query;
            }
            APOLICE_CREDITO_C.GetQueryEvent += GetQuery_APOLICE_CREDITO_C;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R031-FETCH-CTRAB */
        private void R031_FETCH_CTRAB(bool isPerform = false)
        {
            /*" -675- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", WABEND1.WNR_EXEC_SQL);

            /*" -677- MOVE 'R031-FETCH-CTRAB' TO WPARAGRAFO. */
            _.Move("R031-FETCH-CTRAB", WABEND1.WPARAGRAFO);

            /*" -704- PERFORM R031_FETCH_CTRAB_DB_FETCH_1 */

            R031_FETCH_CTRAB_DB_FETCH_1();

            /*" -707- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -708- ADD 1 TO W-CONTA-LIDOS */
                INICIO_WORK.W_CONTA_LIDOS.Value = INICIO_WORK.W_CONTA_LIDOS + 1;

                /*" -709- IF W-CONTA-LIDOS EQUAL 10000 */

                if (INICIO_WORK.W_CONTA_LIDOS == 10000)
                {

                    /*" -710- ADD W-CONTA-LIDOS TO W-CONTA-LIDOS1 */
                    INICIO_WORK.W_CONTA_LIDOS1.Value = INICIO_WORK.W_CONTA_LIDOS1 + INICIO_WORK.W_CONTA_LIDOS;

                    /*" -711- DISPLAY 'LIDOS ATE AGORA = ' W-CONTA-LIDOS1 */
                    _.Display($"LIDOS ATE AGORA = {INICIO_WORK.W_CONTA_LIDOS1}");

                    /*" -713- MOVE 0 TO W-CONTA-LIDOS. */
                    _.Move(0, INICIO_WORK.W_CONTA_LIDOS);
                }

            }


            /*" -714- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -715- DISPLAY 'ERRO FETCH DO CURSOR PRINCIPAL ........' */
                _.Display($"ERRO FETCH DO CURSOR PRINCIPAL ........");

                /*" -716- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -717- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -718- DISPLAY 'RAMO     : ' SINISMES-RAMO */
                _.Display($"RAMO     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -719- DISPLAY 'PRODUTO  : ' SINISMES-COD-PRODUTO */
                _.Display($"PRODUTO  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -720- DISPLAY 'COD CAUSA: ' SINISMES-COD-CAUSA */
                _.Display($"COD CAUSA: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -721- DISPLAY 'COD FONTE: ' SINISMES-COD-FONTE */
                _.Display($"COD FONTE: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -723- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -724- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -724- PERFORM R031_FETCH_CTRAB_DB_CLOSE_1 */

                R031_FETCH_CTRAB_DB_CLOSE_1();

                /*" -737- MOVE 'SIM' TO W-IND-FIM-CTRAB. */
                _.Move("SIM", INICIO_WORK.W_IND_FIM_CTRAB);
            }


            /*" -738- IF SINISMES-DATA-OCORRENCIA < '1900-01-01' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA < "1900-01-01")
            {

                /*" -739- MOVE '1900-01-01' TO SINISMES-DATA-OCORRENCIA */
                _.Move("1900-01-01", SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);

                /*" -741- END-IF. */
            }


            /*" -742- IF SINISMES-DATA-COMUNICADO < '1900-01-01' */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO < "1900-01-01")
            {

                /*" -743- MOVE '1900-01-01' TO SINISMES-DATA-COMUNICADO */
                _.Move("1900-01-01", SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);

                /*" -743- END-IF. */
            }


        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-FETCH-1 */
        public void R031_FETCH_CTRAB_DB_FETCH_1()
        {
            /*" -704- EXEC SQL FETCH CTRAB INTO :SINISHIS-NUM-APOL-SINISTRO, :GEOPERAC-FUNCAO-OPERACAO, :GEOPERAC-DES-OPERACAO, :SINISMES-NUM-APOLICE, :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-COD-CAUSA, :SINISMES-COD-FONTE, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-COMUNICADO, :SINISMES-NUM-ENDOSSO, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISMES-TIPO-SEGURADO, :SINISMES-NUM-PROTOCOLO-SINI, :SINISMES-NUM-IRB, :SINISHIS-SIT-REGISTRO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-HORA-OPERACAO, :SINISHIS-COD-OPERACAO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-VAL-OPERACAO, :SINISHIS-DATA-LIM-CORRECAO, :SINISHIS-COD-USUARIO, :SINISHIS-NOME-FAVORECIDO, :SINISHIS-COD-PREST-SERVICO END-EXEC. */

            if (CTRAB.Fetch())
            {
                _.Move(CTRAB.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(CTRAB.GEOPERAC_FUNCAO_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO);
                _.Move(CTRAB.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(CTRAB.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(CTRAB.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(CTRAB.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(CTRAB.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(CTRAB.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(CTRAB.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CTRAB.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(CTRAB.SINISMES_NUM_ENDOSSO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO);
                _.Move(CTRAB.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(CTRAB.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(CTRAB.SINISMES_TIPO_SEGURADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO);
                _.Move(CTRAB.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(CTRAB.SINISMES_NUM_IRB, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB);
                _.Move(CTRAB.SINISHIS_SIT_REGISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO);
                _.Move(CTRAB.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(CTRAB.SINISHIS_HORA_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_HORA_OPERACAO);
                _.Move(CTRAB.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(CTRAB.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(CTRAB.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(CTRAB.SINISHIS_DATA_LIM_CORRECAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO);
                _.Move(CTRAB.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(CTRAB.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
                _.Move(CTRAB.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
            }

        }

        [StopWatch]
        /*" R031-FETCH-CTRAB-DB-CLOSE-1 */
        public void R031_FETCH_CTRAB_DB_CLOSE_1()
        {
            /*" -724- EXEC SQL CLOSE CTRAB END-EXEC */

            CTRAB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-CTRAB */
        private void R100_PROCESSA_CTRAB(bool isPerform = false)
        {
            /*" -751- INITIALIZE ANAL. */
            _.Initialize(
                ANAL
            );

            /*" -754- MOVE 'NAO' TO W-CHAVE-JA-LEU-CLIENTE. */
            _.Move("NAO", W_CHAVE_JA_LEU_CLIENTE);

            /*" -756- IF SINISMES-RAMO NOT EQUAL W-GDA-RAMO OR SINISMES-COD-CAUSA NOT EQUAL W-GDA-COD-CAUSA */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != W_GDA_RAMO || SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA != W_GDA_COD_CAUSA)
            {

                /*" -757- MOVE SINISMES-RAMO TO W-GDA-RAMO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, W_GDA_RAMO);

                /*" -758- MOVE SINISMES-COD-CAUSA TO W-GDA-COD-CAUSA */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, W_GDA_COD_CAUSA);

                /*" -761- PERFORM R400-BUSCA-GRUPO-CAUSAS THRU R400-EXIT. */

                R400_BUSCA_GRUPO_CAUSAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

            }


            /*" -771- MOVE ZEROS TO W-GDA-QTD-AVISADO W-ACUM-VAL-AVISADO W-GDA-QTD-CANCELADO W-ACUM-VAL-CANCELADO W-GDA-QTD-PAGO W-ACUM-VAL-PAGO. */
            _.Move(0, W_GDA_QTD_AVISADO, W_ACUM_VAL_AVISADO, W_GDA_QTD_CANCELADO, W_ACUM_VAL_CANCELADO, W_GDA_QTD_PAGO, W_ACUM_VAL_PAGO);

            /*" -773- MOVE SINISHIS-NUM-APOL-SINISTRO TO W-GDA-SINI-ANT */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, W_GDA_SINI_ANT);

            /*" -775- PERFORM R110-CALCULA-VALORES THRU R110-EXIT UNTIL SINISHIS-NUM-APOL-SINISTRO NOT EQUAL W-GDA-SINI-ANT OR W-IND-FIM-CTRAB EQUAL 'SIM' . */

            while (!(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO != W_GDA_SINI_ANT || INICIO_WORK.W_IND_FIM_CTRAB == "SIM"))
            {

                R110_CALCULA_VALORES(true);

                R110_NOVA_LEITURA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-CALCULA-VALORES */
        private void R110_CALCULA_VALORES(bool isPerform = false)
        {
            /*" -783- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", WABEND1.WNR_EXEC_SQL);

            /*" -788- MOVE 'R110-CALCULA-VALORES' TO WPARAGRAFO. */
            _.Move("R110-CALCULA-VALORES", WABEND1.WPARAGRAFO);

            /*" -790- PERFORM R120-LE-GESISFUO THRU R120-EXIT. */

            R120_LE_GESISFUO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


            /*" -794- IF GEOPERAC-FUNCAO-OPERACAO = ( 'JPDES' OR 'JPHON' OR 'JEDES' OR 'JEHON' OR 'HMOV' OR 'DMOV' ) */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JPDES", "JPHON", "JEDES", "JEHON", "HMOV", "DMOV"))
            {

                /*" -795- MOVE GEOPERAC-DES-OPERACAO TO ANAL-DESCRICAO-OPERACAO */
                _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO, ANAL.ANAL_DESCRICAO_OPERACAO);

                /*" -796- MOVE SINISHIS-COD-USUARIO TO ANAL-USUARIO-LANCAMENTO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, ANAL.ANAL_USUARIO_LANCAMENTO);

                /*" -797- MOVE SINISHIS-COD-OPERACAO TO ANAL-CODIGO-OPERACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, ANAL.ANAL_CODIGO_OPERACAO);

                /*" -799- MOVE SINISHIS-DATA-MOVIMENTO TO ANAL-DATA-LANCAMENTO. */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, ANAL.ANAL_DATA_LANCAMENTO);
            }


            /*" -800- IF SINISHIS-COD-OPERACAO >= 2000 AND <= 4000 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO >= 2000 && SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO <= 4000)
            {

                /*" -801- MOVE 'SEGUROS' TO ANAL-AREA-LANCAMENTO */
                _.Move("SEGUROS", ANAL.ANAL_AREA_LANCAMENTO);

                /*" -802- ELSE */
            }
            else
            {


                /*" -803- IF SINISHIS-COD-OPERACAO >= 6000 AND <= 7000 */

                if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO >= 6000 && SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO <= 7000)
                {

                    /*" -804- MOVE 'SALVADOS' TO ANAL-AREA-LANCAMENTO */
                    _.Move("SALVADOS", ANAL.ANAL_AREA_LANCAMENTO);

                    /*" -805- ELSE */
                }
                else
                {


                    /*" -806- IF SINISHIS-COD-OPERACAO >= 8000 */

                    if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO >= 8000)
                    {

                        /*" -807- MOVE 'JURIDICOS' TO ANAL-AREA-LANCAMENTO. */
                        _.Move("JURIDICOS", ANAL.ANAL_AREA_LANCAMENTO);
                    }

                }

            }


            /*" -808- IF SINISHIS-SIT-REGISTRO = 0 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_REGISTRO == 0)
            {

                /*" -809- MOVE 'PENDENTE' TO ANAL-STATUS */
                _.Move("PENDENTE", ANAL.ANAL_STATUS);

                /*" -810- PERFORM R300-GRAVA-REG-ANALITICO THRU R300-EXIT */

                R300_GRAVA_REG_ANALITICO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                /*" -811- GO TO R110-NOVA-LEITURA. */

                R110_NOVA_LEITURA(); //GOTO
                return;
            }


            /*" -814- IF GEOPERAC-FUNCAO-OPERACAO = ( 'JBDES' OR 'JBHON' OR 'DPAG' OR 'HPAG' ) */

            if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JBDES", "JBHON", "DPAG", "HPAG"))
            {

                /*" -815- MOVE 'SIM' TO W-GRAVOU */
                _.Move("SIM", W_GRAVOU);

                /*" -816- MOVE 'PAGO' TO ANAL-STATUS */
                _.Move("PAGO", ANAL.ANAL_STATUS);

                /*" -817- PERFORM R300-GRAVA-REG-ANALITICO THRU R300-EXIT */

                R300_GRAVA_REG_ANALITICO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/


                /*" -818- ELSE */
            }
            else
            {


                /*" -821- IF GEOPERAC-FUNCAO-OPERACAO = ( 'JEDES' OR 'JEHON' OR 'DEST' OR 'HEST' ) */

                if (GEOPERAC.DCLGE_OPERACAO.GEOPERAC_FUNCAO_OPERACAO.In("JEDES", "JEHON", "DEST", "HEST"))
                {

                    /*" -822- MOVE 'ESTORNADO' TO ANAL-STATUS */
                    _.Move("ESTORNADO", ANAL.ANAL_STATUS);

                    /*" -823- MOVE 'SIM' TO W-GRAVOU */
                    _.Move("SIM", W_GRAVOU);

                    /*" -823- PERFORM R300-GRAVA-REG-ANALITICO THRU R300-EXIT. */

                    R300_GRAVA_REG_ANALITICO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

                }

            }


        }

        [StopWatch]
        /*" R110-NOVA-LEITURA */
        private void R110_NOVA_LEITURA(bool isPerform = false)
        {
            /*" -827- PERFORM R031-FETCH-CTRAB THRU R031-EXIT. */

            R031_FETCH_CTRAB(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-LE-GESISFUO */
        private void R120_LE_GESISFUO(bool isPerform = false)
        {
            /*" -835- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", WABEND1.WNR_EXEC_SQL);

            /*" -837- MOVE 'R120-LE-GESISFUO' TO WPARAGRAFO. */
            _.Move("R120-LE-GESISFUO", WABEND1.WPARAGRAFO);

            /*" -850- PERFORM R120_LE_GESISFUO_DB_SELECT_1 */

            R120_LE_GESISFUO_DB_SELECT_1();

            /*" -853- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -854- MOVE ZEROS TO GESISFUO-NUM-FATOR */
                _.Move(0, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);

                /*" -855- ELSE */
            }
            else
            {


                /*" -856- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -857- DISPLAY 'ERRO NO SELECT DA GE_SIS_FUNCAO_OPER....' */
                    _.Display($"ERRO NO SELECT DA GE_SIS_FUNCAO_OPER....");

                    /*" -858- DISPLAY ' ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -859- DISPLAY ' ' SINISHIS-OCORR-HISTORICO */
                    _.Display($" {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                    /*" -860- DISPLAY ' ' SINISHIS-COD-OPERACAO */
                    _.Display($" {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                    /*" -860- GO TO M-999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R120-LE-GESISFUO-DB-SELECT-1 */
        public void R120_LE_GESISFUO_DB_SELECT_1()
        {
            /*" -850- EXEC SQL SELECT NUM_FATOR INTO :GESISFUO-NUM-FATOR FROM SEGUROS.GE_SIS_FUNCAO_OPER WHERE IDE_SISTEMA = 'SI' AND COD_FUNCAO IN (5, 6, 15, 16) AND IDE_SISTEMA_OPER = IDE_SISTEMA AND COD_OPERACAO = :SINISHIS-COD-OPERACAO AND TIPO_ENDOSSO = '9' END-EXEC. */

            var r120_LE_GESISFUO_DB_SELECT_1_Query1 = new R120_LE_GESISFUO_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R120_LE_GESISFUO_DB_SELECT_1_Query1.Execute(r120_LE_GESISFUO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GESISFUO_NUM_FATOR, GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R300-GRAVA-REG-ANALITICO */
        private void R300_GRAVA_REG_ANALITICO(bool isPerform = false)
        {
            /*" -869- PERFORM R312-PESQUISA-VAL-AVISADO THRU R312-EXIT. */

            R312_PESQUISA_VAL_AVISADO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R312_EXIT*/


            /*" -870- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -871- MOVE HOST-VLR-AVISADO TO ANAL-VLR-AVISADO. */
                _.Move(HOST_VLR_AVISADO, ANAL.ANAL_VLR_AVISADO);
            }


            /*" -872- IF ANAL-CODIGO-OPERACAO EQUAL ZEROS */

            if (ANAL.ANAL_CODIGO_OPERACAO == 00)
            {

                /*" -873- PERFORM R310-PESQUISA-OPERACAO THRU R310-EXIT */

                R310_PESQUISA_OPERACAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/


                /*" -874- MOVE GEOPERAC-DES-OPERACAO TO ANAL-DESCRICAO-OPERACAO */
                _.Move(GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO, ANAL.ANAL_DESCRICAO_OPERACAO);

                /*" -875- MOVE SINISHIS-COD-OPERACAO TO ANAL-CODIGO-OPERACAO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, ANAL.ANAL_CODIGO_OPERACAO);

                /*" -876- MOVE SINISHIS-COD-USUARIO TO ANAL-USUARIO-LANCAMENTO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, ANAL.ANAL_USUARIO_LANCAMENTO);

                /*" -877- MOVE SINISHIS-DATA-MOVIMENTO TO ANAL-DATA-LANCAMENTO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, ANAL.ANAL_DATA_LANCAMENTO);

                /*" -878- END-IF */
            }


            /*" -879- PERFORM R311-PESQUISA-PROC-JURIDICO THRU R311-EXIT. */

            R311_PESQUISA_PROC_JURIDICO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R311_EXIT*/


            /*" -880- IF HOST-CONT-PROC-JURID = 0 */

            if (HOST_CONT_PROC_JURID == 0)
            {

                /*" -881- MOVE 'NAO' TO ANAL-TEM-PROC-JURI */
                _.Move("NAO", ANAL.ANAL_TEM_PROC_JURI);

                /*" -882- ELSE */
            }
            else
            {


                /*" -883- MOVE 'SIM' TO ANAL-TEM-PROC-JURI */
                _.Move("SIM", ANAL.ANAL_TEM_PROC_JURI);

                /*" -884- END-IF */
            }


            /*" -885- MOVE LK-PERIODO TO ANAL-PERIODICIDADE. */
            _.Move(LK_LINK_PERIODICIDADE.LK_PERIODO, ANAL.ANAL_PERIODICIDADE);

            /*" -886- MOVE SISTEMAS-DATA-MOV-ABERTO TO ANAL-DATA-GERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ANAL.ANAL_DATA_GERACAO);

            /*" -887- MOVE ANAL-USUARIO-LANCAMENTO TO SINISHIS-COD-USUARIO. */
            _.Move(ANAL.ANAL_USUARIO_LANCAMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);

            /*" -888- PERFORM R1900-BUSCA-DEPARTAMENTO THRU R1900-EXIT. */

            R1900_BUSCA_DEPARTAMENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/


            /*" -889- MOVE USUARIOS-DEPARTAMENTO TO ANAL-DEPART-USUARIO. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_DEPARTAMENTO, ANAL.ANAL_DEPART_USUARIO);

            /*" -890- MOVE SINISMES-COD-FONTE TO ANAL-FONTE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, ANAL.ANAL_FONTE);

            /*" -891- MOVE SINISMES-DATA-OCORRENCIA TO ANAL-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, ANAL.ANAL_DATA_OCORRENCIA);

            /*" -892- MOVE SINISMES-DATA-COMUNICADO TO ANAL-DATA-COMUNICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, ANAL.ANAL_DATA_COMUNICADO);

            /*" -893- MOVE SINISMES-NUM-IRB TO ANAL-NUM-IRB. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_IRB, ANAL.ANAL_NUM_IRB);

            /*" -894- MOVE SINISHIS-NOME-FAVORECIDO TO ANAL-NOME-FAVORECIDO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, ANAL.ANAL_NOME_FAVORECIDO);

            /*" -895- MOVE SINISHIS-COD-PREST-SERVICO TO ANAL-COD-FAVORECIDO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, ANAL.ANAL_COD_FAVORECIDO);

            /*" -896- MOVE SINISHIS-DATA-MOVIMENTO TO ANAL-DATA-PAGAMENTO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO, ANAL.ANAL_DATA_PAGAMENTO);

            /*" -897- MOVE SINISHIS-DATA-LIM-CORRECAO TO ANAL-DATA-PREVISTA-PAG. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO, ANAL.ANAL_DATA_PREVISTA_PAG);

            /*" -898- MOVE SINISHIS-VAL-OPERACAO TO ANAL-VLR-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, ANAL.ANAL_VLR_OPERACAO);

            /*" -899- PERFORM R400-PESQUISA-FORNECEDORES. */

            R400_PESQUISA_FORNECEDORES(true);

            /*" -900- MOVE FORNECED-CGCCPF TO ANAL-CGCCPF-FAVORECIDO. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, ANAL.ANAL_CGCCPF_FAVORECIDO);

            /*" -901- MOVE SINISMES-RAMO TO ANAL-RAMO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, ANAL.ANAL_RAMO);

            /*" -902- IF SINISMES-RAMO NOT EQUAL W-GDA-RAMO-ANT */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != W_GDA_RAMO_ANT)
            {

                /*" -903- MOVE SINISMES-RAMO TO W-GDA-RAMO-ANT */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, W_GDA_RAMO_ANT);

                /*" -905- PERFORM R600-BUSCA-NOME-RAMO THRU R600-EXIT. */

                R600_BUSCA_NOME_RAMO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R600_EXIT*/

            }


            /*" -906- MOVE RAMOS-NOME-RAMO TO ANAL-NOME-RAMO. */
            _.Move(RAMOS.DCLRAMOS.RAMOS_NOME_RAMO, ANAL.ANAL_NOME_RAMO);

            /*" -907- MOVE SINISMES-NUM-APOLICE TO ANAL-NUM-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, ANAL.ANAL_NUM_APOLICE);

            /*" -908- MOVE SINISMES-COD-PRODUTO TO ANAL-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, ANAL.ANAL_COD_PRODUTO);

            /*" -909- IF SINISMES-COD-PRODUTO NOT EQUAL W-GDA-PROD-ANT */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO != W_GDA_PROD_ANT)
            {

                /*" -910- MOVE SINISMES-COD-PRODUTO TO W-GDA-PROD-ANT */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, W_GDA_PROD_ANT);

                /*" -912- PERFORM R700-BUSCA-NOME-PRODUTO THRU R700-EXIT. */

                R700_BUSCA_NOME_PRODUTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/

            }


            /*" -913- MOVE PRODUTO-DESCR-PRODUTO TO ANAL-NOME-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, ANAL.ANAL_NOME_PRODUTO);

            /*" -915- MOVE SINISHIS-NUM-APOL-SINISTRO TO ANAL-NUM-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, ANAL.ANAL_NUM_SINISTRO);

            /*" -916- MOVE SINISCAU-DESCR-CAUSA TO ANAL-CAUSA-SINISTRO. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, ANAL.ANAL_CAUSA_SINISTRO);

            /*" -918- MOVE SINISCAU-GRUPO-CAUSAS TO ANAL-GRUPO-CAUSAS. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS, ANAL.ANAL_GRUPO_CAUSAS);

            /*" -919- IF W-CHAVE-JA-LEU-CLIENTE EQUAL 'NAO' */

            if (W_CHAVE_JA_LEU_CLIENTE == "NAO")
            {

                /*" -920- PERFORM R1000-ROTINA-BUSCA-CLIENTE THRU R1000-EXIT */

                R1000_ROTINA_BUSCA_CLIENTE(true);

                R1000_LE_CLIENTE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


                /*" -925- MOVE 'SIM' TO W-CHAVE-JA-LEU-CLIENTE. */
                _.Move("SIM", W_CHAVE_JA_LEU_CLIENTE);
            }


            /*" -927- IF (SINISMES-RAMO EQUAL 66 OR 68 OR 61 OR 65) AND GESISFUO-NUM-FATOR = 1 */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("66", "68", "61", "65")) && GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR == 1)
            {

                /*" -928- PERFORM R1700-BUSCA-AGENTE THRU R1700-EXIT */

                R1700_BUSCA_AGENTE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_EXIT*/


                /*" -930- IF SIEPEMHB-COD-SUBESTIP-EMIS NOT EQUAL 0 OR SIEPEMHB-COD-AGENTE-EMIS NOT EQUAL 0 */

                if (SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_SUBESTIP_EMIS != 0 || SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_AGENTE_EMIS != 0)
                {

                    /*" -932- MOVE 'AGENTE' TO ANAL-MAT-ORIGEM */
                    _.Move("AGENTE", ANAL.ANAL_MAT_ORIGEM);

                    /*" -933- IF SINISMES-RAMO EQUAL 68 OR 61 OR 65 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In("68", "61", "65"))
                    {

                        /*" -934- MOVE SIEPEMHB-COD-SUBESTIP-EMIS TO ANAL-NUM-MATRICULA */
                        _.Move(SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_SUBESTIP_EMIS, ANAL.ANAL_NUM_MATRICULA);

                        /*" -935- ELSE */
                    }
                    else
                    {


                        /*" -936- IF SINISMES-RAMO EQUAL 66 */

                        if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 66)
                        {

                            /*" -937- MOVE SIEPEMHB-COD-AGENTE-EMIS TO ANAL-NUM-MATRICULA */
                            _.Move(SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_AGENTE_EMIS, ANAL.ANAL_NUM_MATRICULA);

                            /*" -938- END-IF */
                        }


                        /*" -939- ELSE */
                    }

                }
                else
                {


                    /*" -940- MOVE SPACES TO ANAL-MAT-ORIGEM */
                    _.Move("", ANAL.ANAL_MAT_ORIGEM);

                    /*" -941- MOVE 0 TO ANAL-NUM-MATRICULA */
                    _.Move(0, ANAL.ANAL_NUM_MATRICULA);

                    /*" -942- ELSE */
                }

            }
            else
            {


                /*" -943- MOVE SPACES TO ANAL-MAT-ORIGEM */
                _.Move("", ANAL.ANAL_MAT_ORIGEM);

                /*" -947- MOVE 0 TO ANAL-NUM-MATRICULA. */
                _.Move(0, ANAL.ANAL_NUM_MATRICULA);
            }


            /*" -948- IF GESISFUO-NUM-FATOR = 1 */

            if (GESISFUO.DCLGE_SIS_FUNCAO_OPER.GESISFUO_NUM_FATOR == 1)
            {

                /*" -949- PERFORM R1800-BUSCA-CHEQUE-INTERNO THRU R1800-EXIT */

                R1800_BUSCA_CHEQUE_INTERNO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_EXIT*/


                /*" -950- IF SISINCHE-NUM-CHEQUE-INTERNO NOT EQUAL 0 */

                if (SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO != 0)
                {

                    /*" -951- MOVE SISINCHE-NUM-CHEQUE-INTERNO TO ANAL-CHEQUE-INTERNO */
                    _.Move(SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO, ANAL.ANAL_CHEQUE_INTERNO);

                    /*" -952- ELSE */
                }
                else
                {


                    /*" -953- IF RALCHEDO-NUM-CHEQUE-INTERNO NOT EQUAL 0 */

                    if (RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO != 0)
                    {

                        /*" -954- MOVE RALCHEDO-NUM-CHEQUE-INTERNO TO ANAL-CHEQUE-INTERNO */
                        _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO, ANAL.ANAL_CHEQUE_INTERNO);

                        /*" -955- ELSE */
                    }
                    else
                    {


                        /*" -956- MOVE 0 TO ANAL-CHEQUE-INTERNO */
                        _.Move(0, ANAL.ANAL_CHEQUE_INTERNO);

                        /*" -957- END-IF */
                    }


                    /*" -958- END-IF */
                }


                /*" -959- IF RALCHEDO-NUMERO-SIVAT NOT EQUAL 0 */

                if (RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT != 0)
                {

                    /*" -960- MOVE RALCHEDO-NUMERO-SIVAT TO W-GDA-NUM-SIVAT */
                    _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT, FILLER_27.W_GDA_NUM_SIVAT);

                    /*" -961- MOVE '-' TO W-GDA-TRACO */
                    _.Move("-", FILLER_27.W_GDA_TRACO);

                    /*" -962- MOVE RALCHEDO-DV-SIVAT TO W-GDA-DV-SIVAT */
                    _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DV_SIVAT, FILLER_27.W_GDA_DV_SIVAT);

                    /*" -963- MOVE W-GDA-SIVAT TO ANAL-NUM-SIVAT */
                    _.Move(W_GDA_SIVAT, ANAL.ANAL_NUM_SIVAT);

                    /*" -966- MOVE RALCHEDO-DATA-SIVAT TO ANAL-DATA-SIVAT. */
                    _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT, ANAL.ANAL_DATA_SIVAT);
                }

            }


            /*" -967- MOVE SINISMES-DATA-OCORRENCIA TO ANAL-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, ANAL.ANAL_DATA_OCORRENCIA);

            /*" -972- MOVE SINISMES-DATA-COMUNICADO TO ANAL-DATA-COMUNICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, ANAL.ANAL_DATA_COMUNICADO);

            /*" -972- WRITE REG-ARQ-ANAL FROM ANAL. */
            _.Move(ANAL.GetMoveValues(), REG_ARQ_ANAL);

            ARQ_ANAL.Write(REG_ARQ_ANAL.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R310-PESQUISA-OPERACAO */
        private void R310_PESQUISA_OPERACAO(bool isPerform = false)
        {
            /*" -980- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", WABEND1.WNR_EXEC_SQL);

            /*" -982- MOVE 'R310-PESQUISA-OPERACAO' TO WPARAGRAFO. */
            _.Move("R310-PESQUISA-OPERACAO", WABEND1.WPARAGRAFO);

            /*" -999- PERFORM R310_PESQUISA_OPERACAO_DB_SELECT_1 */

            R310_PESQUISA_OPERACAO_DB_SELECT_1();

            /*" -1002- IF SQLCODE < ZERO */

            if (DB.SQLCODE < 00)
            {

                /*" -1003- DISPLAY 'SI0874B - PESQUISA COD OPERACAO' */
                _.Display($"SI0874B - PESQUISA COD OPERACAO");

                /*" -1004- DISPLAY 'SINISTRO  : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1005- DISPLAY 'APOLICE   : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE   : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1006- DISPLAY 'RAMO      : ' SINISMES-RAMO */
                _.Display($"RAMO      : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1007- DISPLAY 'CAUSA     : ' SINISMES-COD-CAUSA */
                _.Display($"CAUSA     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -1008- DISPLAY 'COD FORNEC: ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD FORNEC: {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1010- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1011- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1011- MOVE ALL '*' TO GEOPERAC-DES-OPERACAO. */
                _.MoveAll("*", GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
            }


        }

        [StopWatch]
        /*" R310-PESQUISA-OPERACAO-DB-SELECT-1 */
        public void R310_PESQUISA_OPERACAO_DB_SELECT_1()
        {
            /*" -999- EXEC SQL SELECT H.COD_OPERACAO, P.DES_OPERACAO, H.COD_USUARIO, H.DATA_MOVIMENTO INTO :SINISHIS-COD-OPERACAO, :GEOPERAC-DES-OPERACAO, :SINISHIS-COD-USUARIO, :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO P WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND P.IDE_SISTEMA = 'SI' AND P.COD_OPERACAO = H.COD_OPERACAO END-EXEC. */

            var r310_PESQUISA_OPERACAO_DB_SELECT_1_Query1 = new R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R310_PESQUISA_OPERACAO_DB_SELECT_1_Query1.Execute(r310_PESQUISA_OPERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.GEOPERAC_DES_OPERACAO, GEOPERAC.DCLGE_OPERACAO.GEOPERAC_DES_OPERACAO);
                _.Move(executed_1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R310_EXIT*/

        [StopWatch]
        /*" R311-PESQUISA-PROC-JURIDICO */
        private void R311_PESQUISA_PROC_JURIDICO(bool isPerform = false)
        {
            /*" -1018- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", WABEND1.WNR_EXEC_SQL);

            /*" -1020- MOVE 'R311-PESQUISA-PROC-JURIDICO' TO WPARAGRAFO. */
            _.Move("R311-PESQUISA-PROC-JURIDICO", WABEND1.WPARAGRAFO);

            /*" -1026- PERFORM R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1 */

            R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1();

            /*" -1028- IF SQLCODE < ZERO */

            if (DB.SQLCODE < 00)
            {

                /*" -1029- DISPLAY 'SI0874B - PESQUISA COD PROC-JURID' */
                _.Display($"SI0874B - PESQUISA COD PROC-JURID");

                /*" -1030- DISPLAY 'SINISTRO  : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1031- DISPLAY 'APOLICE   : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE   : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1032- DISPLAY 'RAMO      : ' SINISMES-RAMO */
                _.Display($"RAMO      : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1033- DISPLAY 'CAUSA     : ' SINISMES-COD-CAUSA */
                _.Display($"CAUSA     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -1034- DISPLAY 'COD FORNEC: ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD FORNEC: {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1034- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R311-PESQUISA-PROC-JURIDICO-DB-SELECT-1 */
        public void R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1()
        {
            /*" -1026- EXEC SQL SELECT COUNT(*) INTO :HOST-CONT-PROC-JURID FROM SEGUROS.SI_PROCESSO_JURID WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1 = new R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1.Execute(r311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_CONT_PROC_JURID, HOST_CONT_PROC_JURID);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R311_EXIT*/

        [StopWatch]
        /*" R312-PESQUISA-VAL-AVISADO */
        private void R312_PESQUISA_VAL_AVISADO(bool isPerform = false)
        {
            /*" -1040- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", WABEND1.WNR_EXEC_SQL);

            /*" -1042- MOVE 'R312-PESQUISA-VAL-AVISADO' TO WPARAGRAFO. */
            _.Move("R312-PESQUISA-VAL-AVISADO", WABEND1.WPARAGRAFO);

            /*" -1049- PERFORM R312_PESQUISA_VAL_AVISADO_DB_SELECT_1 */

            R312_PESQUISA_VAL_AVISADO_DB_SELECT_1();

            /*" -1051- IF SQLCODE < ZERO */

            if (DB.SQLCODE < 00)
            {

                /*" -1052- DISPLAY 'SI0874B - PESQUISA COD OPERACAO' */
                _.Display($"SI0874B - PESQUISA COD OPERACAO");

                /*" -1053- DISPLAY 'SINISTRO  : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1054- DISPLAY 'APOLICE   : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE   : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1055- DISPLAY 'RAMO      : ' SINISMES-RAMO */
                _.Display($"RAMO      : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1056- DISPLAY 'CAUSA     : ' SINISMES-COD-CAUSA */
                _.Display($"CAUSA     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -1057- DISPLAY 'COD FORNEC: ' SINISHIS-COD-PREST-SERVICO */
                _.Display($"COD FORNEC: {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                /*" -1057- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R312-PESQUISA-VAL-AVISADO-DB-SELECT-1 */
        public void R312_PESQUISA_VAL_AVISADO_DB_SELECT_1()
        {
            /*" -1049- EXEC SQL SELECT SUM(VAL_OPERACAO) INTO :HOST-VLR-AVISADO FROM SEGUROS.SINISTRO_HISTORICO H WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND H.COD_OPERACAO = 101 END-EXEC. */

            var r312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1 = new R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1.Execute(r312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VLR_AVISADO, HOST_VLR_AVISADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R312_EXIT*/

        [StopWatch]
        /*" R400-PESQUISA-FORNECEDORES */
        private void R400_PESQUISA_FORNECEDORES(bool isPerform = false)
        {
            /*" -1067- PERFORM R400_PESQUISA_FORNECEDORES_DB_SELECT_1 */

            R400_PESQUISA_FORNECEDORES_DB_SELECT_1();

            /*" -1070- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1071- MOVE ZEROS TO FORNECED-CGCCPF */
                _.Move(0, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);

                /*" -1072- ELSE */
            }
            else
            {


                /*" -1073- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1074- DISPLAY 'SI0874B - PESQUISA FORNECEDORE' */
                    _.Display($"SI0874B - PESQUISA FORNECEDORE");

                    /*" -1075- DISPLAY 'SINISTRO  : ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO  : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1076- DISPLAY 'APOLICE   : ' SINISMES-NUM-APOLICE */
                    _.Display($"APOLICE   : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                    /*" -1077- DISPLAY 'RAMO      : ' SINISMES-RAMO */
                    _.Display($"RAMO      : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                    /*" -1078- DISPLAY 'CAUSA     : ' SINISMES-COD-CAUSA */
                    _.Display($"CAUSA     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                    /*" -1079- DISPLAY 'COD FORNEC: ' SINISHIS-COD-PREST-SERVICO */
                    _.Display($"COD FORNEC: {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO}");

                    /*" -1079- GO TO M-999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R400-PESQUISA-FORNECEDORES-DB-SELECT-1 */
        public void R400_PESQUISA_FORNECEDORES_DB_SELECT_1()
        {
            /*" -1067- EXEC SQL SELECT CGCCPF INTO :FORNECED-CGCCPF FROM SEGUROS.FORNECEDORES WHERE COD_FORNECEDOR = :SINISHIS-COD-PREST-SERVICO END-EXEC. */

            var r400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1 = new R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
            };

            var executed_1 = R400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1.Execute(r400_PESQUISA_FORNECEDORES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FORNECED_CGCCPF, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);
            }


        }

        [StopWatch]
        /*" R400-BUSCA-GRUPO-CAUSAS */
        private void R400_BUSCA_GRUPO_CAUSAS(bool isPerform = false)
        {
            /*" -1086- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND1.WNR_EXEC_SQL);

            /*" -1088- MOVE 'R400-BUSCA-GRUPO-CAUSAS' TO WPARAGRAFO. */
            _.Move("R400-BUSCA-GRUPO-CAUSAS", WABEND1.WPARAGRAFO);

            /*" -1089- IF SINISMES-RAMO NOT EQUAL 53 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO != 53)
            {

                /*" -1090- MOVE SINISMES-COD-CAUSA TO HOST-COD-CAUSA */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, HOST_COD_CAUSA);

                /*" -1091- ELSE */
            }
            else
            {


                /*" -1092- IF SINISMES-COD-CAUSA = 1 */

                if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 1)
                {

                    /*" -1093- MOVE 51 TO HOST-COD-CAUSA */
                    _.Move(51, HOST_COD_CAUSA);

                    /*" -1094- ELSE */
                }
                else
                {


                    /*" -1095- IF SINISMES-COD-CAUSA = 2 */

                    if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 2)
                    {

                        /*" -1096- MOVE 52 TO HOST-COD-CAUSA */
                        _.Move(52, HOST_COD_CAUSA);

                        /*" -1097- ELSE */
                    }
                    else
                    {


                        /*" -1098- IF SINISMES-COD-CAUSA = 3 */

                        if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == 3)
                        {

                            /*" -1099- MOVE 53 TO HOST-COD-CAUSA */
                            _.Move(53, HOST_COD_CAUSA);

                            /*" -1100- ELSE */
                        }
                        else
                        {


                            /*" -1102- MOVE SINISMES-COD-CAUSA TO HOST-COD-CAUSA. */
                            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, HOST_COD_CAUSA);
                        }

                    }

                }

            }


            /*" -1111- PERFORM R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1 */

            R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1();

            /*" -1114- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1115- DISPLAY 'SI0874B - ERRO NA BUSCA DA CAUSA DO SINISTRO...' */
                _.Display($"SI0874B - ERRO NA BUSCA DA CAUSA DO SINISTRO...");

                /*" -1116- DISPLAY 'SINISTRO  : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO  : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1117- DISPLAY 'APOLICE   : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE   : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1118- DISPLAY 'RAMO      : ' SINISMES-RAMO */
                _.Display($"RAMO      : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1119- DISPLAY 'CAUSA     : ' SINISMES-COD-CAUSA */
                _.Display($"CAUSA     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA}");

                /*" -1120- DISPLAY 'HOST CAUSA: ' HOST-COD-CAUSA */
                _.Display($"HOST CAUSA: {HOST_COD_CAUSA}");

                /*" -1120- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R400-BUSCA-GRUPO-CAUSAS-DB-SELECT-1 */
        public void R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1()
        {
            /*" -1111- EXEC SQL SELECT DESCR_CAUSA, GRUPO_CAUSAS INTO :SINISCAU-DESCR-CAUSA, :SINISCAU-GRUPO-CAUSAS FROM SEGUROS.SINISTRO_CAUSA WHERE RAMO_EMISSOR = :SINISMES-RAMO AND COD_CAUSA = :HOST-COD-CAUSA END-EXEC. */

            var r400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1 = new R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1()
            {
                HOST_COD_CAUSA = HOST_COD_CAUSA.ToString(),
                SINISMES_RAMO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.ToString(),
            };

            var executed_1 = R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1.Execute(r400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(executed_1.SINISCAU_GRUPO_CAUSAS, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_GRUPO_CAUSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

        [StopWatch]
        /*" R600-BUSCA-NOME-RAMO */
        private void R600_BUSCA_NOME_RAMO(bool isPerform = false)
        {
            /*" -1130- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WABEND1.WNR_EXEC_SQL);

            /*" -1132- MOVE 'R600-BUSCA-NOME-RAMO' TO WPARAGRAFO. */
            _.Move("R600-BUSCA-NOME-RAMO", WABEND1.WPARAGRAFO);

            /*" -1139- PERFORM R600_BUSCA_NOME_RAMO_DB_SELECT_1 */

            R600_BUSCA_NOME_RAMO_DB_SELECT_1();

            /*" -1143- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1144- DISPLAY 'SI0874B - ERRO NA BUSCA DA DESCR DO RAMO...' */
                _.Display($"SI0874B - ERRO NA BUSCA DA DESCR DO RAMO...");

                /*" -1145- DISPLAY 'RAMO     : ' SINISMES-RAMO */
                _.Display($"RAMO     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1146- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1147- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1149- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1150- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1150- MOVE ALL '*' TO RAMOS-NOME-RAMO. */
                _.MoveAll("*", RAMOS.DCLRAMOS.RAMOS_NOME_RAMO);
            }


        }

        [StopWatch]
        /*" R600-BUSCA-NOME-RAMO-DB-SELECT-1 */
        public void R600_BUSCA_NOME_RAMO_DB_SELECT_1()
        {
            /*" -1139- EXEC SQL SELECT NOME_RAMO INTO :RAMOS-NOME-RAMO FROM SEGUROS.RAMOS WHERE RAMO_EMISSOR = :SINISMES-RAMO AND COD_MODALIDADE = 0 WITH UR END-EXEC. */

            var r600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1 = new R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1()
            {
                SINISMES_RAMO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.ToString(),
            };

            var executed_1 = R600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1.Execute(r600_BUSCA_NOME_RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOS_NOME_RAMO, RAMOS.DCLRAMOS.RAMOS_NOME_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R600_EXIT*/

        [StopWatch]
        /*" R700-BUSCA-NOME-PRODUTO */
        private void R700_BUSCA_NOME_PRODUTO(bool isPerform = false)
        {
            /*" -1158- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", WABEND1.WNR_EXEC_SQL);

            /*" -1160- MOVE 'R700-BUSCA-NOME-PRODUTO' TO WPARAGRAFO. */
            _.Move("R700-BUSCA-NOME-PRODUTO", WABEND1.WPARAGRAFO);

            /*" -1166- PERFORM R700_BUSCA_NOME_PRODUTO_DB_SELECT_1 */

            R700_BUSCA_NOME_PRODUTO_DB_SELECT_1();

            /*" -1170- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1171- DISPLAY 'SI0874B - ERRO NA BUSCA DA DESCR DO PRODUTO' */
                _.Display($"SI0874B - ERRO NA BUSCA DA DESCR DO PRODUTO");

                /*" -1172- DISPLAY 'PRODUTO  : ' SINISMES-COD-PRODUTO */
                _.Display($"PRODUTO  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -1173- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1174- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1176- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1177- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1177- MOVE ALL '*' TO PRODUTO-DESCR-PRODUTO. */
                _.MoveAll("*", PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }

        [StopWatch]
        /*" R700-BUSCA-NOME-PRODUTO-DB-SELECT-1 */
        public void R700_BUSCA_NOME_PRODUTO_DB_SELECT_1()
        {
            /*" -1166- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :SINISMES-COD-PRODUTO WITH UR END-EXEC. */

            var r700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1 = new R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1()
            {
                SINISMES_COD_PRODUTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.ToString(),
            };

            var executed_1 = R700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1.Execute(r700_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/

        [StopWatch]
        /*" R920-ACESSO-SINI-HABIT */
        private void R920_ACESSO_SINI_HABIT(bool isPerform = false)
        {
            /*" -1186- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", WABEND1.WNR_EXEC_SQL);

            /*" -1188- MOVE 'R920-ACESSO-SINI-HABIT' TO WPARAGRAFO. */
            _.Move("R920-ACESSO-SINI-HABIT", WABEND1.WPARAGRAFO);

            /*" -1202- PERFORM R920_ACESSO_SINI_HABIT_DB_SELECT_1 */

            R920_ACESSO_SINI_HABIT_DB_SELECT_1();

            /*" -1205- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1206- MOVE 99999999999999 TO SINIHAB1-CGCCPF */
                _.Move(99999999999999, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF);

                /*" -1207- MOVE ALL '*' TO SINIHAB1-NOME-SEGURADO */
                _.MoveAll("*", SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);

                /*" -1208- MOVE 9 TO SINIHAB1-OPERACAO */
                _.Move(9, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);

                /*" -1209- MOVE 9999 TO SINIHAB1-PONTO-VENDA */
                _.Move(9999, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);

                /*" -1211- MOVE 9999999 TO SINIHAB1-NUM-CONTRATO. */
                _.Move(9999999, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
            }


            /*" -1213- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1214- DISPLAY 'SI0874B - ERRO NO ACESSO A SINISTRO_HABIT01' */
                _.Display($"SI0874B - ERRO NO ACESSO A SINISTRO_HABIT01");

                /*" -1215- DISPLAY 'SINISTRO      : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1216- DISPLAY 'APOLICE       : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE       : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1216- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R920-ACESSO-SINI-HABIT-DB-SELECT-1 */
        public void R920_ACESSO_SINI_HABIT_DB_SELECT_1()
        {
            /*" -1202- EXEC SQL SELECT CGCCPF, NOME_SEGURADO, OPERACAO, PONTO_VENDA, NUM_CONTRATO INTO :SINIHAB1-CGCCPF, :SINIHAB1-NOME-SEGURADO, :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1 = new R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1.Execute(r920_ACESSO_SINI_HABIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_CGCCPF, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF);
                _.Move(executed_1.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R920_EXIT*/

        [StopWatch]
        /*" R940-ACESSO-SINCREDINT */
        private void R940_ACESSO_SINCREDINT(bool isPerform = false)
        {
            /*" -1224- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", WABEND1.WNR_EXEC_SQL);

            /*" -1226- MOVE 'R940-ACESSO-SINCREDINT' TO WPARAGRAFO. */
            _.Move("R940-ACESSO-SINCREDINT", WABEND1.WPARAGRAFO);

            /*" -1242- PERFORM R940_ACESSO_SINCREDINT_DB_SELECT_1 */

            R940_ACESSO_SINCREDINT_DB_SELECT_1();

            /*" -1246- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1247- DISPLAY 'SI0874B - ERRO NO ACESSO A SINI_CRED_INT' */
                _.Display($"SI0874B - ERRO NO ACESSO A SINI_CRED_INT");

                /*" -1248- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1250- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1251- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1254- GO TO R940-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R940_EXIT*/ //GOTO
                return;
            }


            /*" -1255- IF SINISHIS-COD-OPERACAO EQUAL 107 OR 108 OR 117 OR 118 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("107", "108", "117", "118"))
            {

                /*" -1256- MOVE '1' TO SINCREIN-SIT-REGISTRO */
                _.Move("1", SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO);

                /*" -1257- ELSE */
            }
            else
            {


                /*" -1258- MOVE '3' TO SINCREIN-SIT-REGISTRO */
                _.Move("3", SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO);

                /*" -1259- END-IF. */
            }


            /*" -1260- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", WABEND1.WNR_EXEC_SQL);

            /*" -1272- PERFORM R940_ACESSO_SINCREDINT_DB_DECLARE_1 */

            R940_ACESSO_SINCREDINT_DB_DECLARE_1();

            /*" -1277- PERFORM R940_ACESSO_SINCREDINT_DB_OPEN_1 */

            R940_ACESSO_SINCREDINT_DB_OPEN_1();

            /*" -1280- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1282- GO TO R10010199-MENSAGEM-LOCK. */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;
            }


            /*" -1286- PERFORM R940_ACESSO_SINCREDINT_DB_FETCH_1 */

            R940_ACESSO_SINCREDINT_DB_FETCH_1();

            /*" -1289- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1290- DISPLAY 'SI0874B - ERRO NO FETCH APOLICE_CREDITO' */
                _.Display($"SI0874B - ERRO NO FETCH APOLICE_CREDITO");

                /*" -1291- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1292- DISPLAY 'COD SUREG    : ' SINCREIN-COD-SUREG */
                _.Display($"COD SUREG    : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG}");

                /*" -1293- DISPLAY 'COD AGENCIA  : ' SINCREIN-COD-AGENCIA */
                _.Display($"COD AGENCIA  : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA}");

                /*" -1294- DISPLAY 'COD OPERACAO : ' SINCREIN-COD-OPERACAO */
                _.Display($"COD OPERACAO : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}");

                /*" -1295- DISPLAY 'NUM CONTRATO : ' SINCREIN-NUM-CONTRATO */
                _.Display($"NUM CONTRATO : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO}");

                /*" -1296- DISPLAY 'DV CONTRATO  : ' SINCREIN-CONTRATO-DIGITO */
                _.Display($"DV CONTRATO  : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO}");

                /*" -1297- DISPLAY 'SITUACAO     : ' SINCREIN-SIT-REGISTRO */
                _.Display($"SITUACAO     : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO}");

                /*" -1298- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1299- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -1300- MOVE ALL '*' TO APOLICRE-PROPRIET */
                _.MoveAll("*", APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);

                /*" -1301- MOVE ZEROS TO APOLICRE-CGCCPF */
                _.Move(0, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);

                /*" -1302- MOVE ZEROS TO SQLCODE. */
                _.Move(0, DB.SQLCODE);
            }


            /*" -1304- PERFORM R940_ACESSO_SINCREDINT_DB_CLOSE_1 */

            R940_ACESSO_SINCREDINT_DB_CLOSE_1();

            /*" -1307- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1308- DISPLAY 'SI0874B - ERRO NO CLOSE APOLICE_CREDITO' */
                _.Display($"SI0874B - ERRO NO CLOSE APOLICE_CREDITO");

                /*" -1309- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1310- DISPLAY 'COD SUREG    : ' SINCREIN-COD-SUREG */
                _.Display($"COD SUREG    : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG}");

                /*" -1311- DISPLAY 'COD AGENCIA  : ' SINCREIN-COD-AGENCIA */
                _.Display($"COD AGENCIA  : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA}");

                /*" -1312- DISPLAY 'COD OPERACAO : ' SINCREIN-COD-OPERACAO */
                _.Display($"COD OPERACAO : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO}");

                /*" -1313- DISPLAY 'NUM CONTRATO : ' SINCREIN-NUM-CONTRATO */
                _.Display($"NUM CONTRATO : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO}");

                /*" -1314- DISPLAY 'DV CONTRATO  : ' SINCREIN-CONTRATO-DIGITO */
                _.Display($"DV CONTRATO  : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO}");

                /*" -1315- DISPLAY 'SITUACAO     : ' SINCREIN-SIT-REGISTRO */
                _.Display($"SITUACAO     : {SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO}");

                /*" -1315- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R940-ACESSO-SINCREDINT-DB-SELECT-1 */
        public void R940_ACESSO_SINCREDINT_DB_SELECT_1()
        {
            /*" -1242- EXEC SQL SELECT COD_SUREG, COD_AGENCIA, COD_OPERACAO, NUM_CONTRATO, CONTRATO_DIGITO, SIT_REGISTRO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO, :SINCREIN-SIT-REGISTRO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r940_ACESSO_SINCREDINT_DB_SELECT_1_Query1 = new R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R940_ACESSO_SINCREDINT_DB_SELECT_1_Query1.Execute(r940_ACESSO_SINCREDINT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
                _.Move(executed_1.SINCREIN_SIT_REGISTRO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_SIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" R940-ACESSO-SINCREDINT-DB-OPEN-1 */
        public void R940_ACESSO_SINCREDINT_DB_OPEN_1()
        {
            /*" -1277- EXEC SQL OPEN APOLICE-CREDITO-C END-EXEC. */

            APOLICE_CREDITO_C.Open();

        }

        [StopWatch]
        /*" R940-ACESSO-SINCREDINT-DB-FETCH-1 */
        public void R940_ACESSO_SINCREDINT_DB_FETCH_1()
        {
            /*" -1286- EXEC SQL FETCH APOLICE-CREDITO-C INTO :APOLICRE-PROPRIET, :APOLICRE-CGCCPF END-EXEC. */

            if (APOLICE_CREDITO_C.Fetch())
            {
                _.Move(APOLICE_CREDITO_C.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
                _.Move(APOLICE_CREDITO_C.APOLICRE_CGCCPF, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
            }

        }

        [StopWatch]
        /*" R940-ACESSO-SINCREDINT-DB-CLOSE-1 */
        public void R940_ACESSO_SINCREDINT_DB_CLOSE_1()
        {
            /*" -1304- EXEC SQL CLOSE APOLICE-CREDITO-C END-EXEC. */

            APOLICE_CREDITO_C.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R940_EXIT*/

        [StopWatch]
        /*" R960-ACESSO-SINI-PENHOR */
        private void R960_ACESSO_SINI_PENHOR(bool isPerform = false)
        {
            /*" -1324- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", WABEND1.WNR_EXEC_SQL);

            /*" -1334- PERFORM R960_ACESSO_SINI_PENHOR_DB_SELECT_1 */

            R960_ACESSO_SINI_PENHOR_DB_SELECT_1();

            /*" -1338- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1339- DISPLAY 'SI0874B - ERRO NO ACESSO A APOLICE_CREDITO' */
                _.Display($"SI0874B - ERRO NO ACESSO A APOLICE_CREDITO");

                /*" -1340- DISPLAY 'SINISTRO     : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO     : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1342- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1343- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -1344- MOVE ALL '*' TO APOLICRE-PROPRIET */
                _.MoveAll("*", APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);

                /*" -1344- MOVE ZEROS TO APOLICRE-CGCCPF. */
                _.Move(0, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
            }


        }

        [StopWatch]
        /*" R960-ACESSO-SINI-PENHOR-DB-SELECT-1 */
        public void R960_ACESSO_SINI_PENHOR_DB_SELECT_1()
        {
            /*" -1334- EXEC SQL SELECT COD_AGENCIA, NUM_CONTRATO, DV_CONTRATO INTO :SINIPENH-COD-AGENCIA, :SINIPENH-NUM-CONTRATO, :SINIPENH-DV-CONTRATO FROM SEGUROS.SINI_PENHOR01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1 = new R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1.Execute(r960_ACESSO_SINI_PENHOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIPENH_COD_AGENCIA, SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA);
                _.Move(executed_1.SINIPENH_NUM_CONTRATO, SINIPENH.DCLSINI_PENHOR01.SINIPENH_NUM_CONTRATO);
                _.Move(executed_1.SINIPENH_DV_CONTRATO, SINIPENH.DCLSINI_PENHOR01.SINIPENH_DV_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R960_EXIT*/

        [StopWatch]
        /*" R1000-ROTINA-BUSCA-CLIENTE */
        private void R1000_ROTINA_BUSCA_CLIENTE(bool isPerform = false)
        {
            /*" -1355- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", WABEND1.WNR_EXEC_SQL);

            /*" -1361- PERFORM R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1 */

            R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1();

            /*" -1364- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -1365- DISPLAY 'SI0873B - ERRO SELECT APOLICES' */
                _.Display($"SI0873B - ERRO SELECT APOLICES");

                /*" -1367- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1369- MOVE 'NAO' TO W-CHAVE-APOLICE-EH-AUTO. */
            _.Move("NAO", W_CHAVE_APOLICE_EH_AUTO);

            /*" -1370- IF APOLICES-RAMO-EMISSOR EQUAL 31 OR 53 */

            if (APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.In("31", "53"))
            {

                /*" -1374- MOVE 'SIM' TO W-CHAVE-APOLICE-EH-AUTO. */
                _.Move("SIM", W_CHAVE_APOLICE_EH_AUTO);
            }


            /*" -1376- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", WABEND1.WNR_EXEC_SQL);

            /*" -1382- PERFORM R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2 */

            R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2();

            /*" -1385- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1386- DISPLAY 'SI0873B - ERRO SELECT BILHETE' */
                _.Display($"SI0873B - ERRO SELECT BILHETE");

                /*" -1388- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1389- IF HOST-COUNT EQUAL 0 */

            if (HOST_COUNT == 0)
            {

                /*" -1390- MOVE 'NAO' TO W-CHAVE-APOLICE-EH-BILHETE */
                _.Move("NAO", W_CHAVE_APOLICE_EH_BILHETE);

                /*" -1391- ELSE */
            }
            else
            {


                /*" -1395- MOVE 'SIM' TO W-CHAVE-APOLICE-EH-BILHETE. */
                _.Move("SIM", W_CHAVE_APOLICE_EH_BILHETE);
            }


            /*" -1397- IF SINISMES-NUM-APOLICE >= 0900000000000 AND SINISMES-NUM-APOLICE <= 0909999999999 */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE >= 0900000000000 && SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE <= 0909999999999)
            {

                /*" -1398- PERFORM R1010-ACESSO-APOLICE THRU R1010-EXIT */

                R1010_ACESSO_APOLICE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


                /*" -1400- GO TO R1000-LE-CLIENTE. */

                R1000_LE_CLIENTE(); //GOTO
                return;
            }


            /*" -1401- IF W-CHAVE-APOLICE-EH-AUTO EQUAL 'SIM' */

            if (W_CHAVE_APOLICE_EH_AUTO == "SIM")
            {

                /*" -1402- PERFORM R1200-ACESSO-SINISTRO-AUTO THRU R1200-EXIT */

                R1200_ACESSO_SINISTRO_AUTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


                /*" -1403- MOVE APOLIAUT-COD-CLIENTE TO HOST-COD-CLIENTE */
                _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE, HOST_COD_CLIENTE);

                /*" -1405- GO TO R1000-LE-CLIENTE. */

                R1000_LE_CLIENTE(); //GOTO
                return;
            }


            /*" -1407- PERFORM R1100-ACESSO-PARAMRAMO THRU R1100-EXIT. */

            R1100_ACESSO_PARAMRAMO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/


            /*" -1415- IF (SINISMES-RAMO EQUAL PARAMRAM-RAMO-VG OR PARAMRAM-RAMO-VGAPC) OR (SINISMES-RAMO EQUAL PARAMRAM-RAMO-AP AND W-CHAVE-APOLICE-EH-BILHETE EQUAL 'NAO' ) OR (SINISMES-RAMO EQUAL 81 AND W-CHAVE-APOLICE-EH-AUTO EQUAL 'NAO' ) */

            if ((SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.In(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG.ToString(), PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC.ToString())) || (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP && W_CHAVE_APOLICE_EH_BILHETE == "NAO") || (SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == 81 && W_CHAVE_APOLICE_EH_AUTO == "NAO"))
            {

                /*" -1416- PERFORM R1300-ACESSO-SINISTRO-VIDA THRU R1300-EXIT */

                R1300_ACESSO_SINISTRO_VIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/


                /*" -1417- MOVE SEGURVGA-COD-CLIENTE TO HOST-COD-CLIENTE */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, HOST_COD_CLIENTE);

                /*" -1418- PERFORM R960-ACESSO-SINI-PENHOR THRU R960-EXIT */

                R960_ACESSO_SINI_PENHOR(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R960_EXIT*/


                /*" -1419- IF SQLCODE EQUAL 0 */

                if (DB.SQLCODE == 0)
                {

                    /*" -1420- MOVE SINIPENH-COD-AGENCIA TO W-SINIPENH-COD-AGENCIA */
                    _.Move(SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA, W_SINIPENH_CONTRATO.W_SINIPENH_COD_AGENCIA);

                    /*" -1421- MOVE SINIPENH-NUM-CONTRATO TO W-SINIPENH-NUM-CONTRATO */
                    _.Move(SINIPENH.DCLSINI_PENHOR01.SINIPENH_NUM_CONTRATO, W_SINIPENH_CONTRATO.W_SINIPENH_NUM_CONTRATO);

                    /*" -1422- MOVE SINIPENH-DV-CONTRATO TO W-SINIPENH-DV-CONTRATO */
                    _.Move(SINIPENH.DCLSINI_PENHOR01.SINIPENH_DV_CONTRATO, W_SINIPENH_CONTRATO.W_SINIPENH_DV_CONTRATO);

                    /*" -1423- MOVE W-SINIPENH-CONTRATO TO ANAL-NUM-CONTRATO */
                    _.Move(W_SINIPENH_CONTRATO, ANAL.ANAL_NUM_CONTRATO);

                    /*" -1424- END-IF */
                }


                /*" -1426- GO TO R1000-LE-CLIENTE. */

                R1000_LE_CLIENTE(); //GOTO
                return;
            }


            /*" -1427- PERFORM R920-ACESSO-SINI-HABIT THRU R920-EXIT. */

            R920_ACESSO_SINI_HABIT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R920_EXIT*/


            /*" -1428- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1429- MOVE SINIHAB1-CGCCPF TO ANAL-CGCCPF */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF, ANAL.ANAL_CGCCPF);

                /*" -1430- MOVE SINIHAB1-NOME-SEGURADO TO ANAL-SEGURADO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, ANAL.ANAL_SEGURADO);

                /*" -1431- MOVE SINIHAB1-OPERACAO TO W-SINIHAB1-OPERACAO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, W_SINIHAB1_CONTRATO.W_SINIHAB1_OPERACAO);

                /*" -1432- MOVE SINIHAB1-PONTO-VENDA TO W-SINIHAB1-PONTO-VENDA */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, W_SINIHAB1_CONTRATO.W_SINIHAB1_PONTO_VENDA);

                /*" -1433- MOVE SINIHAB1-NUM-CONTRATO TO W-SINIHAB1-NUM-CONTRATO */
                _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, W_SINIHAB1_CONTRATO.W_SINIHAB1_NUM_CONTRATO);

                /*" -1434- MOVE W-SINIHAB1-CONTRATO TO ANAL-NUM-CONTRATO */
                _.Move(W_SINIHAB1_CONTRATO, ANAL.ANAL_NUM_CONTRATO);

                /*" -1436- GO TO R1000-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/ //GOTO
                return;
            }


            /*" -1437- PERFORM R940-ACESSO-SINCREDINT THRU R940-EXIT. */

            R940_ACESSO_SINCREDINT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R940_EXIT*/


            /*" -1438- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1439- MOVE APOLICRE-CGCCPF TO ANAL-CGCCPF */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF, ANAL.ANAL_CGCCPF);

                /*" -1440- MOVE APOLICRE-PROPRIET TO ANAL-SEGURADO */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, ANAL.ANAL_SEGURADO);

                /*" -1441- MOVE SINCREIN-COD-SUREG TO W-SINCREIN-COD-SUREG */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG, W_SINCREIN_CONTRATO.W_SINCREIN_COD_SUREG);

                /*" -1442- MOVE SINCREIN-COD-AGENCIA TO W-SINCREIN-COD-AGENCIA */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA, W_SINCREIN_CONTRATO.W_SINCREIN_COD_AGENCIA);

                /*" -1443- MOVE SINCREIN-COD-OPERACAO TO W-SINCREIN-COD-OPERACAO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO, W_SINCREIN_CONTRATO.W_SINCREIN_COD_OPERACAO);

                /*" -1444- MOVE SINCREIN-NUM-CONTRATO TO W-SINCREIN-NUM-CONTRATO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO, W_SINCREIN_CONTRATO.W_SINCREIN_NUM_CONTRATO);

                /*" -1446- MOVE SINCREIN-CONTRATO-DIGITO TO W-SINCREIN-CONTRATO-DIGITO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO, W_SINCREIN_CONTRATO.W_SINCREIN_CONTRATO_DIGITO);

                /*" -1447- MOVE W-SINCREIN-CONTRATO TO ANAL-NUM-CONTRATO */
                _.Move(W_SINCREIN_CONTRATO, ANAL.ANAL_NUM_CONTRATO);

                /*" -1449- GO TO R1000-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/ //GOTO
                return;
            }


            /*" -1449- PERFORM R1500-ACESSO-SINISTRO-ITEM THRU R1500-EXIT. */

            R1500_ACESSO_SINISTRO_ITEM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/


        }

        [StopWatch]
        /*" R1000-ROTINA-BUSCA-CLIENTE-DB-SELECT-1 */
        public void R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1()
        {
            /*" -1361- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE WITH UR END-EXEC. */

            var r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1 = new R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1.Execute(r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }

        [StopWatch]
        /*" R1000-LE-CLIENTE */
        private void R1000_LE_CLIENTE(bool isPerform = false)
        {
            /*" -1454- PERFORM R1600-ACESSO-CLIENTES THRU R1600-EXIT. */

            R1600_ACESSO_CLIENTES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/


            /*" -1455- MOVE CLIENTES-NOME-RAZAO TO ANAL-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, ANAL.ANAL_SEGURADO);

            /*" -1455- MOVE CLIENTES-CGCCPF TO ANAL-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, ANAL.ANAL_CGCCPF);

        }

        [StopWatch]
        /*" R1000-ROTINA-BUSCA-CLIENTE-DB-SELECT-2 */
        public void R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2()
        {
            /*" -1382- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.BILHETE WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE WITH UR END-EXEC. */

            var r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1 = new R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1.Execute(r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-ACESSO-APOLICE */
        private void R1010_ACESSO_APOLICE(bool isPerform = false)
        {
            /*" -1464- MOVE '019' TO WNR-EXEC-SQL. */
            _.Move("019", WABEND1.WNR_EXEC_SQL);

            /*" -1470- PERFORM R1010_ACESSO_APOLICE_DB_SELECT_1 */

            R1010_ACESSO_APOLICE_DB_SELECT_1();

            /*" -1473- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1474- DISPLAY 'SI0874B - ERRO NO ACESSO A APOLICES' */
                _.Display($"SI0874B - ERRO NO ACESSO A APOLICES");

                /*" -1475- DISPLAY 'SINISTRO      : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1476- DISPLAY 'APOLICE       : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE       : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1478- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1479- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1479- MOVE APOLICES-COD-CLIENTE TO HOST-COD-CLIENTE. */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, HOST_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R1010-ACESSO-APOLICE-DB-SELECT-1 */
        public void R1010_ACESSO_APOLICE_DB_SELECT_1()
        {
            /*" -1470- EXEC SQL SELECT COD_CLIENTE INTO :APOLICES-COD-CLIENTE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE WITH UR END-EXEC. */

            var r1010_ACESSO_APOLICE_DB_SELECT_1_Query1 = new R1010_ACESSO_APOLICE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1010_ACESSO_APOLICE_DB_SELECT_1_Query1.Execute(r1010_ACESSO_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1100-ACESSO-PARAMRAMO */
        private void R1100_ACESSO_PARAMRAMO(bool isPerform = false)
        {
            /*" -1488- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND1.WNR_EXEC_SQL);

            /*" -1494- PERFORM R1100_ACESSO_PARAMRAMO_DB_SELECT_1 */

            R1100_ACESSO_PARAMRAMO_DB_SELECT_1();

            /*" -1497- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1498- DISPLAY 'SI0874B - ERRO NO ACESSO A V0PARAMRAMO' */
                _.Display($"SI0874B - ERRO NO ACESSO A V0PARAMRAMO");

                /*" -1498- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-ACESSO-PARAMRAMO-DB-SELECT-1 */
        public void R1100_ACESSO_PARAMRAMO_DB_SELECT_1()
        {
            /*" -1494- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP FROM SEGUROS.PARAMETROS_RAMOS WITH UR END-EXEC. */

            var r1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1 = new R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1.Execute(r1100_ACESSO_PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VGAPC, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC);
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_EXIT*/

        [StopWatch]
        /*" R1200-ACESSO-SINISTRO-AUTO */
        private void R1200_ACESSO_SINISTRO_AUTO(bool isPerform = false)
        {
            /*" -1507- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", WABEND1.WNR_EXEC_SQL);

            /*" -1513- PERFORM R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1 */

            R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1();

            /*" -1516- IF SQLCODE < ZERO */

            if (DB.SQLCODE < 00)
            {

                /*" -1517- DISPLAY 'SI0874B - ERRO NO ACESSO A SINISTRO_AUTO1' */
                _.Display($"SI0874B - ERRO NO ACESSO A SINISTRO_AUTO1");

                /*" -1518- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1520- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1522- MOVE '022' TO WNR-EXEC-SQL. */
            _.Move("022", WABEND1.WNR_EXEC_SQL);

            /*" -1530- PERFORM R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2 */

            R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2();

            /*" -1533- IF SQLCODE < ZERO */

            if (DB.SQLCODE < 00)
            {

                /*" -1534- DISPLAY 'SI0874B - ERRO NO ACESSO A AUTOAPOL' */
                _.Display($"SI0874B - ERRO NO ACESSO A AUTOAPOL");

                /*" -1535- DISPLAY 'APOLICE     : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1536- DISPLAY 'NUM ENDOSSO : ' SINISMES-NUM-ENDOSSO */
                _.Display($"NUM ENDOSSO : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO}");

                /*" -1537- DISPLAY 'NUM ITEM    : ' SINISAUT-NUM-ITEM */
                _.Display($"NUM ITEM    : {SINISAUT.DCLSINISTRO_AUTO1.SINISAUT_NUM_ITEM}");

                /*" -1537- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-ACESSO-SINISTRO-AUTO-DB-SELECT-1 */
        public void R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1()
        {
            /*" -1513- EXEC SQL SELECT NUM_ITEM INTO :SINISAUT-NUM-ITEM FROM SEGUROS.SINISTRO_AUTO1 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1 = new R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1.Execute(r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISAUT_NUM_ITEM, SINISAUT.DCLSINISTRO_AUTO1.SINISAUT_NUM_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

        [StopWatch]
        /*" R1200-ACESSO-SINISTRO-AUTO-DB-SELECT-2 */
        public void R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2()
        {
            /*" -1530- EXEC SQL SELECT COD_CLIENTE INTO :APOLIAUT-COD-CLIENTE FROM SEGUROS.APOLICE_AUTO WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE AND NUM_ENDOSSO = :SINISMES-NUM-ENDOSSO AND NUM_ITEM = :SINISAUT-NUM-ITEM WITH UR END-EXEC. */

            var r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1 = new R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
                SINISMES_NUM_ENDOSSO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_ENDOSSO.ToString(),
                SINISAUT_NUM_ITEM = SINISAUT.DCLSINISTRO_AUTO1.SINISAUT_NUM_ITEM.ToString(),
            };

            var executed_1 = R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1.Execute(r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLIAUT_COD_CLIENTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R1300-ACESSO-SINISTRO-VIDA */
        private void R1300_ACESSO_SINISTRO_VIDA(bool isPerform = false)
        {
            /*" -1546- MOVE '023' TO WNR-EXEC-SQL. */
            _.Move("023", WABEND1.WNR_EXEC_SQL);

            /*" -1555- PERFORM R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1 */

            R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1();

            /*" -1558- IF SQLCODE < ZEROS */

            if (DB.SQLCODE < 00)
            {

                /*" -1559- DISPLAY 'SI0874B - ERRO NO ACESSO A SEGURADOS_VGAP' */
                _.Display($"SI0874B - ERRO NO ACESSO A SEGURADOS_VGAP");

                /*" -1560- DISPLAY 'NUM APOLICE     : ' SINISMES-NUM-APOLICE */
                _.Display($"NUM APOLICE     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1561- DISPLAY 'NUM SINISTRO    : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"NUM SINISTRO    : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1562- DISPLAY 'COD SUBGRUPO    : ' SINISMES-COD-SUBGRUPO */
                _.Display($"COD SUBGRUPO    : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                /*" -1563- DISPLAY 'NUM CERTIFICADO : ' SINISMES-NUM-CERTIFICADO */
                _.Display($"NUM CERTIFICADO : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO}");

                /*" -1564- DISPLAY 'TIPO SEGURADO   : 1' */
                _.Display($"TIPO SEGURADO   : 1");

                /*" -1564- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-ACESSO-SINISTRO-VIDA-DB-SELECT-1 */
        public void R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1()
        {
            /*" -1555- EXEC SQL SELECT COD_CLIENTE INTO :SEGURVGA-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE AND COD_SUBGRUPO = :SINISMES-COD-SUBGRUPO AND NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1 = new R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
                SINISMES_COD_SUBGRUPO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO.ToString(),
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1.Execute(r1300_ACESSO_SINISTRO_VIDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/

        [StopWatch]
        /*" R1500-ACESSO-SINISTRO-ITEM */
        private void R1500_ACESSO_SINISTRO_ITEM(bool isPerform = false)
        {
            /*" -1574- MOVE '024' TO WNR-EXEC-SQL. */
            _.Move("024", WABEND1.WNR_EXEC_SQL);

            /*" -1581- PERFORM R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1 */

            R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1();

            /*" -1588- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1589- DISPLAY 'SI0874B - ERRO NO ACESSO A SINISTRO_ITEM' */
                _.Display($"SI0874B - ERRO NO ACESSO A SINISTRO_ITEM");

                /*" -1590- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1592- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1593- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1594- MOVE SINIITEM-COD-CLIENTE TO HOST-COD-CLIENTE */
                _.Move(SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE, HOST_COD_CLIENTE);

                /*" -1596- GO TO R1500-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/ //GOTO
                return;
            }


            /*" -1598- MOVE '025' TO WNR-EXEC-SQL. */
            _.Move("025", WABEND1.WNR_EXEC_SQL);

            /*" -1604- PERFORM R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2 */

            R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2();

            /*" -1608- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1609- DISPLAY 'SI0874B - ERRO NO ACESSO A APOLICES' */
                _.Display($"SI0874B - ERRO NO ACESSO A APOLICES");

                /*" -1610- DISPLAY 'SINISTRO      : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1611- DISPLAY 'APOLICE       : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE       : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1613- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1614- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1615- MOVE APOLICES-COD-CLIENTE TO HOST-COD-CLIENTE */
                _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, HOST_COD_CLIENTE);

                /*" -1615- GO TO R1500-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1500-ACESSO-SINISTRO-ITEM-DB-SELECT-1 */
        public void R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1()
        {
            /*" -1581- EXEC SQL SELECT NUM_APOL_SINISTRO, COD_CLIENTE INTO :SINIITEM-NUM-APOL-SINISTRO, :SINIITEM-COD-CLIENTE FROM SEGUROS.SINISTRO_ITEM WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1 = new R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1.Execute(r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIITEM_NUM_APOL_SINISTRO, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINIITEM_COD_CLIENTE, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_EXIT*/

        [StopWatch]
        /*" R1500-ACESSO-SINISTRO-ITEM-DB-SELECT-2 */
        public void R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2()
        {
            /*" -1604- EXEC SQL SELECT COD_CLIENTE INTO :APOLICES-COD-CLIENTE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE WITH UR END-EXEC. */

            var r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1 = new R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1()
            {
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1.Execute(r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
            }


        }

        [StopWatch]
        /*" R1600-ACESSO-CLIENTES */
        private void R1600_ACESSO_CLIENTES(bool isPerform = false)
        {
            /*" -1624- MOVE '026' TO WNR-EXEC-SQL. */
            _.Move("026", WABEND1.WNR_EXEC_SQL);

            /*" -1630- PERFORM R1600_ACESSO_CLIENTES_DB_SELECT_1 */

            R1600_ACESSO_CLIENTES_DB_SELECT_1();

            /*" -1633- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1634- DISPLAY 'SI0874B - ERRO NO ACESSO A TABELA CLIENTES' */
                _.Display($"SI0874B - ERRO NO ACESSO A TABELA CLIENTES");

                /*" -1635- DISPLAY 'COD CLIENTE   : ' HOST-COD-CLIENTE */
                _.Display($"COD CLIENTE   : {HOST_COD_CLIENTE}");

                /*" -1636- DISPLAY 'SINISTRO      : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO      : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1638- DISPLAY 'APOLICE       : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE       : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1639- MOVE 'NAO ENCONTRADO ' TO CLIENTES-NOME-RAZAO */
                _.Move("NAO ENCONTRADO ", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1639- MOVE 9999999999 TO CLIENTES-CGCCPF. */
                _.Move(9999999999, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R1600-ACESSO-CLIENTES-DB-SELECT-1 */
        public void R1600_ACESSO_CLIENTES_DB_SELECT_1()
        {
            /*" -1630- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :HOST-COD-CLIENTE WITH UR END-EXEC. */

            var r1600_ACESSO_CLIENTES_DB_SELECT_1_Query1 = new R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1()
            {
                HOST_COD_CLIENTE = HOST_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1600_ACESSO_CLIENTES_DB_SELECT_1_Query1.Execute(r1600_ACESSO_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_EXIT*/

        [StopWatch]
        /*" R1700-BUSCA-AGENTE */
        private void R1700_BUSCA_AGENTE(bool isPerform = false)
        {
            /*" -1648- MOVE '027' TO WNR-EXEC-SQL. */
            _.Move("027", WABEND1.WNR_EXEC_SQL);

            /*" -1650- MOVE SINISHIS-COD-OPERACAO TO HOST-COD-OPERACAO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, HOST_COD_OPERACAO);

            /*" -1658- PERFORM R1700_BUSCA_AGENTE_DB_SELECT_1 */

            R1700_BUSCA_AGENTE_DB_SELECT_1();

            /*" -1666- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1667- MOVE 0 TO SIEPEMHB-COD-SUBESTIP-EMIS */
                _.Move(0, SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_SUBESTIP_EMIS);

                /*" -1667- MOVE 0 TO SIEPEMHB-COD-AGENTE-EMIS. */
                _.Move(0, SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_AGENTE_EMIS);
            }


        }

        [StopWatch]
        /*" R1700-BUSCA-AGENTE-DB-SELECT-1 */
        public void R1700_BUSCA_AGENTE_DB_SELECT_1()
        {
            /*" -1658- EXEC SQL SELECT COD_SUBESTIP_EMIS, COD_AGENTE_EMIS INTO :SIEPEMHB-COD-SUBESTIP-EMIS, :SIEPEMHB-COD-AGENTE-EMIS FROM SEGUROS.SI_ESTIP_EMIS_HAB WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WITH UR END-EXEC. */

            var r1700_BUSCA_AGENTE_DB_SELECT_1_Query1 = new R1700_BUSCA_AGENTE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1700_BUSCA_AGENTE_DB_SELECT_1_Query1.Execute(r1700_BUSCA_AGENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIEPEMHB_COD_SUBESTIP_EMIS, SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_SUBESTIP_EMIS);
                _.Move(executed_1.SIEPEMHB_COD_AGENTE_EMIS, SIEPEMHB.DCLSI_ESTIP_EMIS_HAB.SIEPEMHB_COD_AGENTE_EMIS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_EXIT*/

        [StopWatch]
        /*" R1800-BUSCA-CHEQUE-INTERNO */
        private void R1800_BUSCA_CHEQUE_INTERNO(bool isPerform = false)
        {
            /*" -1676- MOVE '028' TO WNR-EXEC-SQL. */
            _.Move("028", WABEND1.WNR_EXEC_SQL);

            /*" -1683- PERFORM R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1 */

            R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1();

            /*" -1686- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1687- DISPLAY 'SI0874B - ERRO NO ACESSO A TAB SI_SINI_CHEQUE' */
                _.Display($"SI0874B - ERRO NO ACESSO A TAB SI_SINI_CHEQUE");

                /*" -1688- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1690- DISPLAY 'OCORHIST = ' SINISHIS-OCORR-HISTORICO */
                _.Display($"OCORHIST = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                /*" -1692- MOVE 0 TO SISINCHE-NUM-CHEQUE-INTERNO. */
                _.Move(0, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
            }


            /*" -1692- PERFORM R1810-BUSCA-SIVAT THRU R1810-EXIT. */

            R1810_BUSCA_SIVAT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_EXIT*/


        }

        [StopWatch]
        /*" R1800-BUSCA-CHEQUE-INTERNO-DB-SELECT-1 */
        public void R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1()
        {
            /*" -1683- EXEC SQL SELECT NUM_CHEQUE_INTERNO INTO :SISINCHE-NUM-CHEQUE-INTERNO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WITH UR END-EXEC. */

            var r1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1 = new R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1.Execute(r1800_BUSCA_CHEQUE_INTERNO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISINCHE_NUM_CHEQUE_INTERNO, SISINCHE.DCLSI_SINI_CHEQUE.SISINCHE_NUM_CHEQUE_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_EXIT*/

        [StopWatch]
        /*" R1810-BUSCA-SIVAT */
        private void R1810_BUSCA_SIVAT(bool isPerform = false)
        {
            /*" -1701- MOVE '029' TO WNR-EXEC-SQL. */
            _.Move("029", WABEND1.WNR_EXEC_SQL);

            /*" -1714- PERFORM R1810_BUSCA_SIVAT_DB_SELECT_1 */

            R1810_BUSCA_SIVAT_DB_SELECT_1();

            /*" -1721- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1722- MOVE 0 TO RALCHEDO-NUMERO-SIVAT */
                _.Move(0, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);

                /*" -1723- MOVE SPACE TO RALCHEDO-DV-SIVAT */
                _.Move("", RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DV_SIVAT);

                /*" -1723- MOVE SPACES TO RALCHEDO-DATA-SIVAT. */
                _.Move("", RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT);
            }


        }

        [StopWatch]
        /*" R1810-BUSCA-SIVAT-DB-SELECT-1 */
        public void R1810_BUSCA_SIVAT_DB_SELECT_1()
        {
            /*" -1714- EXEC SQL SELECT NUM_CHEQUE_INTERNO, NUMERO_SIVAT, DV_SIVAT, DATA_SIVAT INTO :RALCHEDO-NUM-CHEQUE-INTERNO, :RALCHEDO-NUMERO-SIVAT, :RALCHEDO-DV-SIVAT, :RALCHEDO-DATA-SIVAT FROM SEGUROS.RALACAO_CHEQ_DOCTO WHERE NUMDOC_NUM01 = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WITH UR END-EXEC. */

            var r1810_BUSCA_SIVAT_DB_SELECT_1_Query1 = new R1810_BUSCA_SIVAT_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1810_BUSCA_SIVAT_DB_SELECT_1_Query1.Execute(r1810_BUSCA_SIVAT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RALCHEDO_NUM_CHEQUE_INTERNO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.RALCHEDO_NUMERO_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUMERO_SIVAT);
                _.Move(executed_1.RALCHEDO_DV_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DV_SIVAT);
                _.Move(executed_1.RALCHEDO_DATA_SIVAT, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_DATA_SIVAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_EXIT*/

        [StopWatch]
        /*" R1900-BUSCA-DEPARTAMENTO */
        private void R1900_BUSCA_DEPARTAMENTO(bool isPerform = false)
        {
            /*" -1735- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND1.WNR_EXEC_SQL);

            /*" -1741- PERFORM R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1 */

            R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1();

            /*" -1744- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1745- MOVE SPACES TO USUARIOS-DEPARTAMENTO */
                _.Move("", USUARIOS.DCLUSUARIOS.USUARIOS_DEPARTAMENTO);

                /*" -1746- ELSE */
            }
            else
            {


                /*" -1747- IF SQLCODE < ZEROS */

                if (DB.SQLCODE < 00)
                {

                    /*" -1748- DISPLAY 'SI0874B - ERRO NO ACESSO A TAB USUARIOS' */
                    _.Display($"SI0874B - ERRO NO ACESSO A TAB USUARIOS");

                    /*" -1749- DISPLAY 'SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1750- DISPLAY 'OCORHIST = ' SINISHIS-OCORR-HISTORICO */
                    _.Display($"OCORHIST = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                    /*" -1751- DISPLAY 'CODUSUAR = ' SINISHIS-COD-USUARIO */
                    _.Display($"CODUSUAR = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO}");

                    /*" -1751- MOVE SPACES TO USUARIOS-DEPARTAMENTO. */
                    _.Move("", USUARIOS.DCLUSUARIOS.USUARIOS_DEPARTAMENTO);
                }

            }


        }

        [StopWatch]
        /*" R1900-BUSCA-DEPARTAMENTO-DB-SELECT-1 */
        public void R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1()
        {
            /*" -1741- EXEC SQL SELECT DEPARTAMENTO INTO :USUARIOS-DEPARTAMENTO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SINISHIS-COD-USUARIO WITH UR END-EXEC. */

            var r1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1 = new R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
            };

            var executed_1 = R1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1.Execute(r1900_BUSCA_DEPARTAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_DEPARTAMENTO, USUARIOS.DCLUSUARIOS.USUARIOS_DEPARTAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_EXIT*/

        [StopWatch]
        /*" R2230-BUSCA-NOME-PRODUTO */
        private void R2230_BUSCA_NOME_PRODUTO(bool isPerform = false)
        {
            /*" -1765- MOVE '031' TO WNR-EXEC-SQL. */
            _.Move("031", WABEND1.WNR_EXEC_SQL);

            /*" -1771- PERFORM R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1 */

            R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1();

            /*" -1775- IF (SQLCODE NOT EQUAL ZERO) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -1776- DISPLAY 'SI0874B - ERRO NA BUSCA DA DESCR DO PRODUTO' */
                _.Display($"SI0874B - ERRO NA BUSCA DA DESCR DO PRODUTO");

                /*" -1777- DISPLAY 'PRODUTO  = ' SITRATEM-COD-PRODUTO */
                _.Display($"PRODUTO  = {SITRATEM.DCLSI_TRAB_TEMP01.SITRATEM_COD_PRODUTO}");

                /*" -1778- DISPLAY 'SINISTRO : ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO : {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -1779- DISPLAY 'APOLICE  : ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1781- GO TO M-999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1782- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1782- MOVE ALL '*' TO PRODUTO-DESCR-PRODUTO. */
                _.MoveAll("*", PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }

        [StopWatch]
        /*" R2230-BUSCA-NOME-PRODUTO-DB-SELECT-1 */
        public void R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1()
        {
            /*" -1771- EXEC SQL SELECT DESCR_PRODUTO INTO :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :SITRATEM-COD-PRODUTO WITH UR END-EXEC. */

            var r2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1 = new R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1()
            {
                SITRATEM_COD_PRODUTO = SITRATEM.DCLSI_TRAB_TEMP01.SITRATEM_COD_PRODUTO.ToString(),
            };

            var executed_1 = R2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1.Execute(r2230_BUSCA_NOME_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -1791- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1792- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

                /*" -1793- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND2.WSQLCODE1);

                /*" -1794- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND2.WSQLCODE2);

                /*" -1795- MOVE SQLCODE TO WSQLCODE3. */
                _.Move(DB.SQLCODE, INICIO_WORK.WSQLCODE3);
            }


            /*" -1796- DISPLAY WABEND1. */
            _.Display(WABEND1);

            /*" -1798- DISPLAY WABEND2. */
            _.Display(WABEND2);

            /*" -1799- CLOSE ARQ-ANAL. */
            ARQ_ANAL.Close();

            /*" -1799- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1801- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1801- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -1809- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND2.WSQLCODE);

            /*" -1812- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -1815- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -1818- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      A T E N C A O       S R.   O P E R A D O R         *WITHNOADVANCING"
            .Display();

            /*" -1821- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*      -------------       ----------------------         *WITHNOADVANCING"
            .Display();

            /*" -1824- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1827- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                   PROGRAMA ABENDADO                     *WITHNOADVANCING"
            .Display();

            /*" -1830- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                 PROVAVELMENTE POR LOCK                  *WITHNOADVANCING"
            .Display();

            /*" -1833- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE WITH NO ADVANCING. */

            $"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *WITHNOADVANCING"
            .Display();

            /*" -1836- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE WITH NO ADVANCING. */

            $"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *WITHNOADVANCING"
            .Display();

            /*" -1839- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1842- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE WITH NO ADVANCING. */

            $"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *WITHNOADVANCING"
            .Display();

            /*" -1845- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1848- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1851- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE WITH NO ADVANCING. */

            $"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}WITHNOADVANCING"
            .Display();

            /*" -1854- DISPLAY '*                                                         *' UPON CONSOLE WITH NO ADVANCING. */

            $"*                                                         *WITHNOADVANCING"
            .Display();

            /*" -1860- DISPLAY '***********************************************************' UPON CONSOLE WITH NO ADVANCING. */

            $"***********************************************************WITHNOADVANCING"
            .Display();

            /*" -1862- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1864- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1866- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1868- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1870- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1872- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1874- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1876- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1878- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1880- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1882- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1884- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1886- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1888- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1890- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {WABEND2.WSQLCODE}");

            /*" -1892- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1892- GO TO 999-999-ROT-ERRO. */

            M_999_999_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}