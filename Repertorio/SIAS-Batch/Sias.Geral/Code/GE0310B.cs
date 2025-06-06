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
using Sias.Geral.DB2.GE0310B;

namespace Code
{
    public class GE0310B
    {
        public bool IsCall { get; set; }

        public GE0310B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  GE0310B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  DOUGLAS ARAUJO                     *      */
        /*"      *   PROGRAMADOR ............  DOUGLAS ARAUJO                     *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO / 2017                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   SUB-ROTINA PARA CRITICAS DOS DADOS RECEBIDOS DO REINF        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - HIST 181.018                                     *      */
        /*"      *             - AJUSTES NA WORKING.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/05/2019 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR JV.01        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESFAZER INVERSAO DE DATA REALIZADA EM 19-10-2018 *      */
        /*"      *            - ESTE PROGRAMA EH CHAMADO PELAS ROTINAS:           *      */
        /*"      *              SI0233B, SPBSI004, SPBSI053, SPBSI054             *      */
        /*"      *            - O PROGRAMA SI0233B RECEBE A DATA DD.MM.AAAA E NELE*      */
        /*"      *              FOI COLOCADO A ALTERACAO PARA ALTERAR PARA        *      */
        /*"      *              AAAA-MM-DD                                        *      */
        /*"      * 06-03-2019 - HUSNI ALI HUSNI -                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - HIST 190.214                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/02/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INVERTER A DATA DE ENTRADA WS-DATA-EMIS PARA      *      */
        /*"      *              CORRIGIR ERRO DE CRITICA                          *      */
        /*"      * 19-10-2018 - WELLINGTON FRANCISO - TE39902 PROCURAR POR 176278 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01   WS-DATA-ATUAL             PIC  X(010) VALUE SPACES.*/
        public StringBasis WS_DATA_ATUAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01   WS-DATA-ATUAL-INV         PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_DATA_ATUAL_INV { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01   WS-DATA-EMIS-INV          PIC  X(008) VALUE SPACES.*/
        public StringBasis WS_DATA_EMIS_INV { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01           AREA-DE-WORK.*/
        public GE0310B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0310B_AREA_DE_WORK();
        public class GE0310B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WSL-COD-PRODUTO   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WSL_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WSL-NUM-APOLICE   PIC  9(015)    VALUE ZEROS.*/
            public IntBasis WSL_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"01  REGISTRO-WORKING-ENTRADA.*/
        }
        public GE0310B_REGISTRO_WORKING_ENTRADA REGISTRO_WORKING_ENTRADA { get; set; } = new GE0310B_REGISTRO_WORKING_ENTRADA();
        public class GE0310B_REGISTRO_WORKING_ENTRADA : VarBasis
        {
            /*"    05 WS-PROGRAMA                        PIC  X(08).*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 WS-PASSO                           PIC  X(01).*/
            public StringBasis WS_PASSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-NUM-APOLICE                     PIC  9(17).*/
            public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "17", "9(17)."));
            /*"    05 WS-COD-PRODUTO                     PIC  9(05).*/
            public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 WS-OPC-PAG                         PIC  X(01).*/
            public StringBasis WS_OPC_PAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-BANCO                           PIC  9(03).*/
            public IntBasis WS_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 WS-AGENCIA                         PIC  9(04).*/
            public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-CONTA                           PIC  9(12).*/
            public IntBasis WS_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 WS-DIGITO                          PIC  9(01).*/
            public IntBasis WS_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 WS-COD-OPER                        PIC  9(03).*/
            public IntBasis WS_COD_OPER { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 WS-TIP-CONTA                       PIC  9(02).*/
            public IntBasis WS_TIP_CONTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DESC-CONTA                      PIC  X(15).*/
            public StringBasis WS_DESC_CONTA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 WS-TIPO-PES                        PIC  X(01).*/
            public StringBasis WS_TIPO_PES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-COD-USER                        PIC  X(08).*/
            public StringBasis WS_COD_USER { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 WS-NOME-USER                       PIC  X(40).*/
            public StringBasis WS_NOME_USER { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 WS-COD-LOTE                        PIC  9(02).*/
            public IntBasis WS_COD_LOTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DESC-LOTE                       PIC  X(07).*/
            public StringBasis WS_DESC_LOTE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
            /*"    05 WS-FONTE                           PIC  9(02).*/
            public IntBasis WS_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DEPTO-DEST                      PIC  X(08).*/
            public StringBasis WS_DEPTO_DEST { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 WS-TIPO-DOC-FISC                   PIC  9(02).*/
            public IntBasis WS_TIPO_DOC_FISC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DESC-DOC-FISC                   PIC  X(11).*/
            public StringBasis WS_DESC_DOC_FISC { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
            /*"    05 WS-NUM-DOC-FISC                    PIC  9(06).*/
            public IntBasis WS_NUM_DOC_FISC { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 WS-SERIE-DOC-FISC                  PIC  X(04).*/
            public StringBasis WS_SERIE_DOC_FISC { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05 WS-DATA-EMIS                       PIC  X(10).*/
            public StringBasis WS_DATA_EMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 WS-VALOR-DOC-FISC                  PIC  9(09)V9(02).*/
            public DoubleBasis WS_VALOR_DOC_FISC { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V9(02)."), 2);
            /*"    05   WS-CNPJ-CONTR                    PIC  9(14).*/
            public IntBasis WS_CNPJ_CONTR { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05   FILLER                 REDEFINES WS-CNPJ-CONTR.*/
            private _REDEF_GE0310B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_GE0310B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_GE0310B_FILLER_0(); _.Move(WS_CNPJ_CONTR, _filler_0); VarBasis.RedefinePassValue(WS_CNPJ_CONTR, _filler_0, WS_CNPJ_CONTR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_CNPJ_CONTR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_CNPJ_CONTR); }
            }  //Redefines
            public class _REDEF_GE0310B_FILLER_0 : VarBasis
            {
                /*"     10  WS-CNPJ-CONTR-08                 PIC  9(08).*/
                public IntBasis WS_CNPJ_CONTR_08 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"     10  FILLER                           PIC  9(06).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"    05 WS-QTDE-LANC                       PIC  9(09).*/

                public _REDEF_GE0310B_FILLER_0()
                {
                    WS_CNPJ_CONTR_08.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_QTDE_LANC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 WS-VALOR-TOTAL-LOTE                PIC  9(09)V9(02).*/
            public DoubleBasis WS_VALOR_TOTAL_LOTE { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V9(02)."), 2);
            /*"    05 WS-OPCAO-LOTE                      PIC  X(01).*/
            public StringBasis WS_OPCAO_LOTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-TIPO-PAGTO                      PIC  9(04).*/
            public IntBasis WS_TIPO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-DESC-PAGTO                      PIC  X(30).*/
            public StringBasis WS_DESC_PAGTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 WS-ISENTO-IMP                      PIC  X(01).*/
            public StringBasis WS_ISENTO_IMP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-CODIGO-IMP                      PIC  9(02).*/
            public IntBasis WS_CODIGO_IMP { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 WS-DESC-IMP                        PIC  X(30).*/
            public StringBasis WS_DESC_IMP { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 WS-NUM-PROC-ISEN                   PIC  X(21).*/
            public StringBasis WS_NUM_PROC_ISEN { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 WS-VLR-NAO-RET                     PIC  9(09)V9(02).*/
            public DoubleBasis WS_VLR_NAO_RET { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V9(02)."), 2);
            /*"    05 WS-ALIQUOTA-INSS                   PIC  9(02)V9(01).*/
            public DoubleBasis WS_ALIQUOTA_INSS { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V9(01)."), 1);
            /*"    05 FILLER REDEFINES WS-ALIQUOTA-INSS.*/
            private _REDEF_GE0310B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_GE0310B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_GE0310B_FILLER_2(); _.Move(WS_ALIQUOTA_INSS, _filler_2); VarBasis.RedefinePassValue(WS_ALIQUOTA_INSS, _filler_2, WS_ALIQUOTA_INSS); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_ALIQUOTA_INSS); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WS_ALIQUOTA_INSS); }
            }  //Redefines
            public class _REDEF_GE0310B_FILLER_2 : VarBasis
            {
                /*"     10 WS-ALIQUOTA-INSS-A                PIC  X(3).*/
                public StringBasis WS_ALIQUOTA_INSS_A { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
                /*"    05 WS-CODIGO-INSS                     PIC  9(04).*/

                public _REDEF_GE0310B_FILLER_2()
                {
                    WS_ALIQUOTA_INSS_A.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CODIGO_INSS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 WS-DESC-INSS                       PIC  X(30).*/
            public StringBasis WS_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 WS-TIPO-PES-FORN                   PIC  X(01).*/
            public StringBasis WS_TIPO_PES_FORN { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 WS-IND-DESC-INSS                   PIC  X(01).*/
            public StringBasis WS_IND_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"01  WS-JV1-PROGRAMA                    PIC  X(008) VALUE SPACES.*/
        }
        public StringBasis WS_JV1_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  WS-JV1.*/
        public GE0310B_WS_JV1 WS_JV1 { get; set; } = new GE0310B_WS_JV1();
        public class GE0310B_WS_JV1 : VarBasis
        {
            /*"    05   WS-CNPJ-EMPR                     PIC  9(14).*/
            public IntBasis WS_CNPJ_EMPR { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05   FILLER                 REDEFINES WS-CNPJ-EMPR.*/
            private _REDEF_GE0310B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_GE0310B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_GE0310B_FILLER_3(); _.Move(WS_CNPJ_EMPR, _filler_3); VarBasis.RedefinePassValue(WS_CNPJ_EMPR, _filler_3, WS_CNPJ_EMPR); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_CNPJ_EMPR); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WS_CNPJ_EMPR); }
            }  //Redefines
            public class _REDEF_GE0310B_FILLER_3 : VarBasis
            {
                /*"     10  WS-CNPJ-EMPR-08                  PIC  9(08).*/
                public IntBasis WS_CNPJ_EMPR_08 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"     10  FILLER                           PIC  9(06).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"01  W-WORK.*/

                public _REDEF_GE0310B_FILLER_3()
                {
                    WS_CNPJ_EMPR_08.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
        }
        public GE0310B_W_WORK W_WORK { get; set; } = new GE0310B_W_WORK();
        public class GE0310B_W_WORK : VarBasis
        {
            /*"   05       WDATA-AUX.*/
            public GE0310B_WDATA_AUX WDATA_AUX { get; set; } = new GE0310B_WDATA_AUX();
            public class GE0310B_WDATA_AUX : VarBasis
            {
                /*"     10     WDAT-AUX-ANO         PIC  9(004).*/
                public IntBasis WDAT_AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     FILLER               PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WDAT-AUX-MES         PIC  9(002).*/
                public IntBasis WDAT_AUX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER               PIC  X(001)    VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WDAT-AUX-DIA         PIC  9(002).*/
                public IntBasis WDAT_AUX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          WABEND.*/
            }
        }
        public GE0310B_WABEND WABEND { get; set; } = new GE0310B_WABEND();
        public class GE0310B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' GE0310B'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0310B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REGISTRO-LINKAGE.*/
        }
        public GE0310B_REGISTRO_LINKAGE REGISTRO_LINKAGE { get; set; } = new GE0310B_REGISTRO_LINKAGE();
        public class GE0310B_REGISTRO_LINKAGE : VarBasis
        {
            /*"    05 LK-PROGRAMA                        PIC  X(08).*/
            public StringBasis LK_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-PASSO                           PIC  X(01).*/
            public StringBasis LK_PASSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-NUM-APOLICE                     PIC  9(17).*/
            public IntBasis LK_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "17", "9(17)."));
            /*"    05 LK-COD-PRODUTO                     PIC  9(05).*/
            public IntBasis LK_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-OPC-PAG                         PIC  X(01).*/
            public StringBasis LK_OPC_PAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-BANCO                           PIC  9(03).*/
            public IntBasis LK_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 LK-AGENCIA                         PIC  9(04).*/
            public IntBasis LK_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 LK-CONTA                           PIC  9(12).*/
            public IntBasis LK_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 LK-DIGITO                          PIC  9(01).*/
            public IntBasis LK_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"    05 LK-COD-OPER                        PIC  9(03).*/
            public IntBasis LK_COD_OPER { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05 LK-TIP-CONTA                       PIC  9(02).*/
            public IntBasis LK_TIP_CONTA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-DESC-CONTA                      PIC  X(15).*/
            public StringBasis LK_DESC_CONTA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-TIPO-PES                        PIC  X(01).*/
            public StringBasis LK_TIPO_PES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-COD-USER                        PIC  X(08).*/
            public StringBasis LK_COD_USER { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-NOME-USER                       PIC  X(40).*/
            public StringBasis LK_NOME_USER { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-COD-LOTE                        PIC  9(02).*/
            public IntBasis LK_COD_LOTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-DESC-LOTE                       PIC  X(07).*/
            public StringBasis LK_DESC_LOTE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
            /*"    05 LK-FONTE                           PIC  9(02).*/
            public IntBasis LK_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-DEPTO-DEST                      PIC  X(08).*/
            public StringBasis LK_DEPTO_DEST { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-TIPO-DOC-FISC                   PIC  9(02).*/
            public IntBasis LK_TIPO_DOC_FISC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-DESC-DOC-FISC                   PIC  X(11).*/
            public StringBasis LK_DESC_DOC_FISC { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
            /*"    05 LK-NUM-DOC-FISC                    PIC  9(06).*/
            public IntBasis LK_NUM_DOC_FISC { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"    05 LK-SERIE-DOC-FISC                  PIC  X(04).*/
            public StringBasis LK_SERIE_DOC_FISC { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05 LK-DATA-EMIS                       PIC  X(10).*/
            public StringBasis LK_DATA_EMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 LK-VALOR-DOC-FISC                  PIC  9(09)V9(02).*/
            public DoubleBasis LK_VALOR_DOC_FISC { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V9(02)."), 2);
            /*"    05 LK-CNPJ-CONTR                      PIC  9(14).*/
            public IntBasis LK_CNPJ_CONTR { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05 LK-QTDE-LANC                       PIC  9(09).*/
            public IntBasis LK_QTDE_LANC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 LK-VALOR-TOTAL-LOTE                PIC  9(09)V9(02).*/
            public DoubleBasis LK_VALOR_TOTAL_LOTE { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V9(02)."), 2);
            /*"    05 LK-OPCAO-LOTE                      PIC  X(01).*/
            public StringBasis LK_OPCAO_LOTE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-TIPO-PAGTO                      PIC  9(04).*/
            public IntBasis LK_TIPO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 LK-DESC-PAGTO                      PIC  X(30).*/
            public StringBasis LK_DESC_PAGTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 LK-ISENTO-IMP                      PIC  X(01).*/
            public StringBasis LK_ISENTO_IMP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-CODIGO-IMP                      PIC  9(02).*/
            public IntBasis LK_CODIGO_IMP { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-DESC-IMP                        PIC  X(30).*/
            public StringBasis LK_DESC_IMP { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 LK-NUM-PROC-ISEN                   PIC  X(21).*/
            public StringBasis LK_NUM_PROC_ISEN { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
            /*"    05 LK-VLR-NAO-RET                     PIC  9(09)V9(02).*/
            public DoubleBasis LK_VLR_NAO_RET { get; set; } = new DoubleBasis(new PIC("9", "9", "9(09)V9(02)."), 2);
            /*"    05 LK-ALIQUOTA-INSS                   PIC  9(02)V9(01).*/
            public DoubleBasis LK_ALIQUOTA_INSS { get; set; } = new DoubleBasis(new PIC("9", "2", "9(02)V9(01)."), 1);
            /*"    05 LK-CODIGO-INSS                     PIC  9(04).*/
            public IntBasis LK_CODIGO_INSS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 LK-DESC-INSS                       PIC  X(30).*/
            public StringBasis LK_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 LK-TIPO-PES-FORN                   PIC  X(01).*/
            public StringBasis LK_TIPO_PES_FORN { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-IND-DESC-INSS                   PIC  X(01).*/
            public StringBasis LK_IND_DESC_INSS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAIDA-COD-RETORNO               PIC  X(01).*/
            public StringBasis LK_SAIDA_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAIDA-MENSAGEM.*/
            public GE0310B_LK_SAIDA_MENSAGEM LK_SAIDA_MENSAGEM { get; set; } = new GE0310B_LK_SAIDA_MENSAGEM();
            public class GE0310B_LK_SAIDA_MENSAGEM : VarBasis
            {
                /*"       10 LK-SAIDA-SQLCODE                PIC   -ZZ9.*/
                public IntBasis LK_SAIDA_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-SAIDA-MENSAGEM-RETORNO       PIC  X(75).*/
                public StringBasis LK_SAIDA_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Copies.GEJVW002 GEJVW002 { get; set; } = new Copies.GEJVW002();
        public Copies.GEJVWCNT GEJVWCNT { get; set; } = new Copies.GEJVWCNT();
        public Dclgens.GE612 GE612 { get; set; } = new Dclgens.GE612();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0310B_REGISTRO_LINKAGE GE0310B_REGISTRO_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE*/
        {
            try
            {
                this.REGISTRO_LINKAGE = GE0310B_REGISTRO_LINKAGE_P;

                /*" -437- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -439- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -441- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -444- MOVE 'GE0310B' TO LK-GEJVW002-NOM-PROG-ORIGEM */
                _.Move("GE0310B", GEJVW002.LK_GEJVW002_NOM_PROG_ORIGEM);

                /*" -445- MOVE 'BATCH' TO LK-GEJVW002-COD-USUARIO-ORIGEM */
                _.Move("BATCH", GEJVW002.LK_GEJVW002_COD_USUARIO_ORIGEM);

                /*" -445- MOVE 'GEJVS002' TO WS-JV1-PROGRAMA. */
                _.Move("GEJVS002", WS_JV1_PROGRAMA);

                /*" -446- CALL WS-JV1-PROGRAMA USING LK-GEJVW002-NOM-PROG-ORIGEM LK-GEJVW002-COD-USUARIO-ORIGEM LK-GEJVW002-SIAS-NUM-EMP LK-GEJVW002-SIAS-DTA-INI LK-GEJVW002-SIAS-COD-LIDER LK-GEJVW002-SIAS-COD-CGCCPF LK-GEJVW002-SIAS-COD-EMP-CAP LK-GEJVW002-PREV-NUM-EMP LK-GEJVW002-PREV-DTA-INI LK-GEJVW002-PREV-COD-LIDER LK-GEJVW002-PREV-COD-CGCCPF LK-GEJVW002-PREV-COD-EMP-CAP LK-GEJVW002-JV-NUM-EMP LK-GEJVW002-JV-DTA-INI LK-GEJVW002-JV-COD-LIDER LK-GEJVW002-JV-COD-CGCCPF LK-GEJVW002-JV-COD-EMP-CAP LK-GEJVWCNT-IND-ERRO LK-GEJVWCNT-MENSAGEM-RETORNO LK-GEJVWCNT-NOME-TABELA LK-GEJVWCNT-SQLCODE LK-GEJVWCNT-SQLERRMC. */
                _.Call(WS_JV1_PROGRAMA, GEJVW002, GEJVWCNT);

                /*" -447- IF LK-GEJVWCNT-IND-ERRO NOT = 0 */

                if (GEJVWCNT.LK_GEJVWCNT_IND_ERRO != 0)
                {

                    /*" -448- DISPLAY 'IND ERRO    = ' LK-GEJVWCNT-IND-ERRO */
                    _.Display($"IND ERRO    = {GEJVWCNT.LK_GEJVWCNT_IND_ERRO}");

                    /*" -449- DISPLAY 'MENSAGEM    = ' LK-GEJVWCNT-MENSAGEM-RETORNO */
                    _.Display($"MENSAGEM    = {GEJVWCNT.LK_GEJVWCNT_MENSAGEM_RETORNO}");

                    /*" -450- DISPLAY 'TABELA      = ' LK-GEJVWCNT-NOME-TABELA */
                    _.Display($"TABELA      = {GEJVWCNT.LK_GEJVWCNT_NOME_TABELA}");

                    /*" -451- DISPLAY 'SQLCODE     = ' LK-GEJVWCNT-SQLCODE */
                    _.Display($"SQLCODE     = {GEJVWCNT.LK_GEJVWCNT_SQLCODE}");

                    /*" -452- MOVE LK-GEJVWCNT-SQLCODE TO WSQLCODE */
                    _.Move(GEJVWCNT.LK_GEJVWCNT_SQLCODE, WABEND.WSQLCODE);

                    /*" -453- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return Result;

                    /*" -466- END-IF */
                }


                /*" -468- INITIALIZE REGISTRO-WORKING-ENTRADA. */
                _.Initialize(
                    REGISTRO_WORKING_ENTRADA
                );

                /*" -513- MOVE REGISTRO-LINKAGE TO REGISTRO-WORKING-ENTRADA. */
                _.Move(REGISTRO_LINKAGE, REGISTRO_WORKING_ENTRADA);

                /*" -514- MOVE 0 TO LK-SAIDA-SQLCODE */
                _.Move(0, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_SQLCODE);

                /*" -515- MOVE '0' TO LK-SAIDA-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -517- MOVE '     ' TO LK-SAIDA-MENSAGEM. */
                _.Move("     ", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM);

                /*" -519- PERFORM Execute_DB_SET_1 */

                Execute_DB_SET_1();

                /*" -521- IF SQLCODE NOT = 000 */

                if (DB.SQLCODE != 000)
                {

                    /*" -522- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -526- STRING 'GE0310B - ERRO NO SET WS-DATA-ATUAL.' '/' SQLERRMC DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                    #region STRING
                    var spl1 = "GE0310B - ERRO NO SET WS-DATA-ATUAL." + "/" + DB.SQLERRMC.GetMoveValues();
                    _.Move(spl1, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                    #endregion

                    /*" -527- MOVE SQLCODE TO LK-SAIDA-SQLCODE */
                    _.Move(DB.SQLCODE, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_SQLCODE);

                    /*" -528- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return Result;

                    /*" -530- END-IF */
                }


                /*" -532- PERFORM R0020-CRITICA-LINKAGE THRU R0020-EXIT. */

                R0020_CRITICA_LINKAGE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -533- MOVE '0' TO LK-SAIDA-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -535- MOVE 'EXECUCAO COM SUCESSO' TO LK-SAIDA-MENSAGEM. */
                _.Move("EXECUCAO COM SUCESSO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM);

                /*" -535- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SET-1 */
        public void Execute_DB_SET_1()
        {
            /*" -519- EXEC SQL SET :WS-DATA-ATUAL = CURRENT DATE END-EXEC. */
            _.Move(_.CurrentDate(), WS_DATA_ATUAL);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0020-CRITICA-LINKAGE */
        private void R0020_CRITICA_LINKAGE(bool isPerform = false)
        {
            /*" -542- IF WS-PROGRAMA EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_PROGRAMA.IsEmpty())
            {

                /*" -543- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -546- MOVE 'GE0310B - NOME DO PROGRAMA CHAMADOR INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - NOME DO PROGRAMA CHAMADOR INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -547- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -549- END-IF. */
            }


            /*" -550- IF WS-PASSO EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_PASSO.IsEmpty())
            {

                /*" -551- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -554- MOVE 'GE0310B - FUNCAO INVALIDA' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - FUNCAO INVALIDA", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -555- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -557- END-IF. */
            }


            /*" -559- IF WS-NUM-APOLICE = 0 AND WS-COD-PRODUTO = 0 */

            if (REGISTRO_WORKING_ENTRADA.WS_NUM_APOLICE == 0 && REGISTRO_WORKING_ENTRADA.WS_COD_PRODUTO == 0)
            {

                /*" -560- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -563- MOVE 'GE0310B - INFORMA NUMERO DA APOLICE OU O CODIGO DO PRODUTO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - INFORMA NUMERO DA APOLICE OU O CODIGO DO PRODUTO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -564- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -566- END-IF */
            }


            /*" -567- IF WS-COD-PRODUTO > 0 */

            if (REGISTRO_WORKING_ENTRADA.WS_COD_PRODUTO > 0)
            {

                /*" -568- PERFORM R0030-PESQUISAR-PRODUTO THRU R0030-EXIT */

                R0030_PESQUISAR_PRODUTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_EXIT*/


                /*" -569- ELSE */
            }
            else
            {


                /*" -570- PERFORM R0040-PESQUISAR-APOLICE THRU R0040-EXIT */

                R0040_PESQUISAR_APOLICE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_EXIT*/


                /*" -572- END-IF */
            }


            /*" -573- IF WS-OPC-PAG EQUAL '1' OR '2' */

            if (REGISTRO_WORKING_ENTRADA.WS_OPC_PAG.In("1", "2"))
            {

                /*" -574- CONTINUE */

                /*" -575- ELSE */
            }
            else
            {


                /*" -576- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -579- MOVE 'GE0310B - TIPO DE PAGAMENTO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - TIPO DE PAGAMENTO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -580- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -582- END-IF. */
            }


            /*" -583- IF WS-OPC-PAG EQUAL '2' */

            if (REGISTRO_WORKING_ENTRADA.WS_OPC_PAG == "2")
            {

                /*" -584- IF WS-BANCO EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_BANCO == 00)
                {

                    /*" -585- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -588- MOVE 'GE0310B - CODIGO DO BANCO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - CODIGO DO BANCO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -589- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -591- END-IF */
                }


                /*" -592- IF WS-AGENCIA EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_AGENCIA == 00)
                {

                    /*" -593- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -596- MOVE 'GE0310B - CODIGO DA AGENCIA INVALIDA' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - CODIGO DA AGENCIA INVALIDA", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -597- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -599- END-IF */
                }


                /*" -600- IF WS-CONTA EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_CONTA == 00)
                {

                    /*" -601- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -604- MOVE 'GE0310B - CONTA INVALIDA' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - CONTA INVALIDA", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -605- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -614- END-IF */
                }


                /*" -649- END-IF. */
            }


            /*" -650- IF WS-COD-USER EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_COD_USER.IsEmpty())
            {

                /*" -651- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -654- MOVE 'GE0310B - USUARIO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - USUARIO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -655- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -657- END-IF. */
            }


            /*" -658- IF WS-NOME-USER EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_NOME_USER.IsEmpty())
            {

                /*" -659- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -662- MOVE 'GE0310B - NOME USUARIO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - NOME USUARIO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -663- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -665- END-IF. */
            }


            /*" -666- IF WS-COD-LOTE NOT EQUAL 10 */

            if (REGISTRO_WORKING_ENTRADA.WS_COD_LOTE != 10)
            {

                /*" -667- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -670- MOVE 'GE0310B - CODIGO DO LOTE INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - CODIGO DO LOTE INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -671- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -673- END-IF. */
            }


            /*" -674- IF WS-DESC-LOTE EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_DESC_LOTE.IsEmpty())
            {

                /*" -675- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -678- MOVE 'GE0310B - DESCRICAO DO LOTE INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - DESCRICAO DO LOTE INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -679- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -681- END-IF. */
            }


            /*" -682- IF WS-FONTE NOT EQUAL 10 */

            if (REGISTRO_WORKING_ENTRADA.WS_FONTE != 10)
            {

                /*" -683- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -686- MOVE 'GE0310B - FONTE INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - FONTE INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -687- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -689- END-IF. */
            }


            /*" -690- IF WS-DEPTO-DEST EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_DEPTO_DEST.IsEmpty())
            {

                /*" -691- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -694- MOVE 'GE0310B - DEPARTAMENTO DESTINO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - DEPARTAMENTO DESTINO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -695- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -697- END-IF. */
            }


            /*" -698- IF WS-TIPO-DOC-FISC EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_TIPO_DOC_FISC == 00)
            {

                /*" -699- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -702- MOVE 'GE0310B - TIPO DOCUMENTO FISCAL INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - TIPO DOCUMENTO FISCAL INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -703- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -705- END-IF. */
            }


            /*" -706- IF WS-DESC-DOC-FISC EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_DESC_DOC_FISC.IsEmpty())
            {

                /*" -707- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -710- MOVE 'GE0310B - DESCRICAO DO DOCUMENTO FISCAL INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - DESCRICAO DO DOCUMENTO FISCAL INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -711- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -713- END-IF. */
            }


            /*" -714- IF WS-VLR-NAO-RET GREATER WS-VALOR-DOC-FISC */

            if (REGISTRO_WORKING_ENTRADA.WS_VLR_NAO_RET > REGISTRO_WORKING_ENTRADA.WS_VALOR_DOC_FISC)
            {

                /*" -715- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -718- MOVE 'GE0310B - VALOR NAO RET MAIOR QUE VALOR DOC FISCAL' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - VALOR NAO RET MAIOR QUE VALOR DOC FISCAL", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -719- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -721- END-IF. */
            }


            /*" -722- IF WS-NUM-DOC-FISC EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_NUM_DOC_FISC == 00)
            {

                /*" -723- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -726- MOVE 'GE0310B - NUMERO DOCUMENTO FISCAL INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - NUMERO DOCUMENTO FISCAL INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -727- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -729- END-IF. */
            }


            /*" -730- IF WS-SERIE-DOC-FISC EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_SERIE_DOC_FISC.IsEmpty())
            {

                /*" -731- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -734- MOVE 'GE0310B - SERIE DOCUMENTO FISCAL INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - SERIE DOCUMENTO FISCAL INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -735- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -737- END-IF. */
            }


            /*" -738- IF WS-DATA-EMIS EQUAL SPACES */

            if (REGISTRO_WORKING_ENTRADA.WS_DATA_EMIS.IsEmpty())
            {

                /*" -739- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -742- MOVE 'GE0310B - DATA DE EMISSAO INVALIDA' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - DATA DE EMISSAO INVALIDA", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -743- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -749- END-IF. */
            }


            /*" -752- IF WS-DATA-EMIS GREATER WS-DATA-ATUAL */

            if (REGISTRO_WORKING_ENTRADA.WS_DATA_EMIS > WS_DATA_ATUAL)
            {

                /*" -753- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -756- MOVE 'GE0310B - DATA DE EMISSAO MAIOR QUE DATA ATUAL' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - DATA DE EMISSAO MAIOR QUE DATA ATUAL", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -757- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -759- END-IF. */
            }


            /*" -760- IF WS-VALOR-DOC-FISC EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_VALOR_DOC_FISC == 00)
            {

                /*" -761- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -764- MOVE 'GE0310B - VALOR DOCUMENTO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - VALOR DOCUMENTO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -765- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -767- END-IF. */
            }


            /*" -768- IF WS-CNPJ-CONTR EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_CNPJ_CONTR == 00)
            {

                /*" -769- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -772- MOVE 'GE0310B - CNPJ IGUAL A ZEROS' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - CNPJ IGUAL A ZEROS", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -773- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -775- END-IF. */
            }


            /*" -776-  EVALUATE WS-CNPJ-CONTR  */

            /*" -777-  WHEN LK-GEJVW002-PREV-COD-CGCCPF  */

            /*" -778-  WHEN LK-GEJVW002-JV-COD-CGCCPF  */

            /*" -779-  WHEN 34020354000110  */

            /*" -780-  WHEN 34020354000209  */

            /*" -781-  WHEN 34020354000381  */

            /*" -782-  WHEN 34020354000462  */

            /*" -783-  WHEN 34020354000543  */

            /*" -784-  WHEN 34020354000624  */

            /*" -785-  WHEN 34020354000896  */

            /*" -786-  WHEN 34020354001000  */

            /*" -787-  WHEN 34020354001272  */

            /*" -788-  WHEN 34020354001434  */

            /*" -789-  WHEN 34020354003135  */

            /*" -790-  WHEN 34020354003569  */

            /*" -791-  WHEN 34020354003720  */

            /*" -792-  WHEN 34020354003801  */

            /*" -793-  WHEN 34020354003992  */

            /*" -794-  WHEN 34020354004107  */

            /*" -795-  WHEN 34020354003054  */

            /*" -796-  WHEN 34020354004700  */

            /*" -797-  WHEN 34020354004298  */

            /*" -797- IF   WS-CNPJ-CONTR EQUALS LK-GEJVW002-PREV-COD-CGCCPF  OR  LK-GEJVW002-JV-COD-CGCCPF   OR  34020354000110   OR  34020354000209   OR  34020354000381   OR  34020354000462   OR  34020354000543   OR  34020354000624   OR  34020354000896   OR  34020354001000   OR  34020354001272   OR  34020354001434   OR  34020354003135   OR  34020354003569   OR  34020354003720   OR  34020354003801   OR  34020354003992   OR  34020354004107   OR  34020354003054   OR  34020354004700 OR  34020354004298 */

            if (REGISTRO_WORKING_ENTRADA.WS_CNPJ_CONTR.In(GEJVW002.LK_GEJVW002_PREV_COD_CGCCPF.ToString(), GEJVW002.LK_GEJVW002_JV_COD_CGCCPF.ToString(), "34020354000110", "34020354000209", "34020354000381", "34020354000462", "34020354000543", "34020354000624", "34020354000896", "34020354001000", "34020354001272", "34020354001434", "34020354003135", "34020354003569", "34020354003720", "34020354003801", "34020354003992", "34020354004107", "34020354003054", "34020354004700", "34020354004298"))
            {

                /*" -798- CONTINUE */

                /*" -799-  WHEN OTHER  */

                /*" -799- ELSE */
            }
            else
            {


                /*" -801- MOVE 'GE0310B - CNPJ INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - CNPJ INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -802- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -804-  END-EVALUATE.  */

                /*" -804- END-IF. */
            }


            /*" -805- MOVE PARAMGER-COD-CGCCPF TO WS-CNPJ-EMPR */
            _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF, WS_JV1.WS_CNPJ_EMPR);

            /*" -806- IF WS-CNPJ-CONTR-08 NOT = WS-CNPJ-EMPR-08 */

            if (REGISTRO_WORKING_ENTRADA.FILLER_0.WS_CNPJ_CONTR_08 != WS_JV1.FILLER_3.WS_CNPJ_EMPR_08)
            {

                /*" -808- MOVE 'GE0310B - CNPJ INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - CNPJ INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -809- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -811- END-IF. */
            }


            /*" -812- IF WS-QTDE-LANC EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_QTDE_LANC == 00)
            {

                /*" -813- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -816- MOVE 'GE0310B - QUANTIDADE DE LANCAMENTOS INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - QUANTIDADE DE LANCAMENTOS INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -817- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -819- END-IF. */
            }


            /*" -820- IF WS-VALOR-TOTAL-LOTE EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_VALOR_TOTAL_LOTE == 00)
            {

                /*" -821- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -824- MOVE 'GE0310B - VALOR TOTAL DO LOTE INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - VALOR TOTAL DO LOTE INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -825- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -827- END-IF. */
            }


            /*" -829- IF WS-OPCAO-LOTE NOT EQUAL 'A' AND 'V' AND 'R' AND 'J' AND 'S' */

            if (!REGISTRO_WORKING_ENTRADA.WS_OPCAO_LOTE.In("A", "V", "R", "J", "S"))
            {

                /*" -830- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -833- MOVE 'GE0310B - OPCAO INVALIDA' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - OPCAO INVALIDA", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -834- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -836- END-IF. */
            }


            /*" -837- IF WS-TIPO-PAGTO EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_TIPO_PAGTO == 00)
            {

                /*" -838- CONTINUE */

                /*" -839- ELSE */
            }
            else
            {


                /*" -840- IF WS-DESC-PAGTO EQUAL SPACES */

                if (REGISTRO_WORKING_ENTRADA.WS_DESC_PAGTO.IsEmpty())
                {

                    /*" -841- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -844- MOVE 'GE0310B - DESCRICAO PAGAMENTO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - DESCRICAO PAGAMENTO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -845- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -846- END-IF */
                }


                /*" -848- END-IF. */
            }


            /*" -849- IF WS-ISENTO-IMP NOT EQUAL 'S' AND 'N' */

            if (!REGISTRO_WORKING_ENTRADA.WS_ISENTO_IMP.In("S", "N"))
            {

                /*" -850- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -853- MOVE 'GE0310B - CODIGO ISENTO IMPOSTO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - CODIGO ISENTO IMPOSTO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -854- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -856- END-IF. */
            }


            /*" -857- IF WS-TIPO-PES-FORN EQUAL 'F' */

            if (REGISTRO_WORKING_ENTRADA.WS_TIPO_PES_FORN == "F")
            {

                /*" -858- IF WS-ISENTO-IMP EQUAL 'N' */

                if (REGISTRO_WORKING_ENTRADA.WS_ISENTO_IMP == "N")
                {

                    /*" -860- IF WS-NUM-PROC-ISEN EQUAL SPACES AND WS-VLR-NAO-RET EQUAL ZEROS */

                    if (REGISTRO_WORKING_ENTRADA.WS_NUM_PROC_ISEN.IsEmpty() && REGISTRO_WORKING_ENTRADA.WS_VLR_NAO_RET == 00)
                    {

                        /*" -861- CONTINUE */

                        /*" -862- ELSE */
                    }
                    else
                    {


                        /*" -863- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                        /*" -866- MOVE 'GE0310B - NUMERO PROCESSO E/OU VALOR NAO RETIDO INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                        _.Move("GE0310B - NUMERO PROCESSO E/OU VALOR NAO RETIDO INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                        /*" -867- GO TO R0999-ROTINA-RETORNO */

                        R0999_ROTINA_RETORNO(); //GOTO
                        return;

                        /*" -868- END-IF */
                    }


                    /*" -869- ELSE */
                }
                else
                {


                    /*" -870- IF WS-CODIGO-IMP EQUAL 1 OR 10 */

                    if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP.In("1", "10"))
                    {

                        /*" -871- CONTINUE */

                        /*" -872- ELSE */
                    }
                    else
                    {


                        /*" -873- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                        /*" -876- MOVE 'GE0310B- ISENCAO IMPOSTO INVALIDO. PRESTADOR DESCONTA INSS' TO LK-SAIDA-MENSAGEM-RETORNO */
                        _.Move("GE0310B- ISENCAO IMPOSTO INVALIDO. PRESTADOR DESCONTA INSS", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                        /*" -877- GO TO R0999-ROTINA-RETORNO */

                        R0999_ROTINA_RETORNO(); //GOTO
                        return;

                        /*" -878- END-IF */
                    }


                    /*" -879- END-IF */
                }


                /*" -881- END-IF. */
            }


            /*" -882- IF WS-ISENTO-IMP EQUAL 'S' */

            if (REGISTRO_WORKING_ENTRADA.WS_ISENTO_IMP == "S")
            {

                /*" -883- IF WS-CODIGO-IMP EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP == 00)
                {

                    /*" -884- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -887- MOVE 'GE0310B - CODIGO DO IMPOSTO DEVE SER PREENCHIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - CODIGO DO IMPOSTO DEVE SER PREENCHIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -888- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -889- END-IF */
                }


                /*" -890- IF WS-NUM-PROC-ISEN EQUAL SPACES */

                if (REGISTRO_WORKING_ENTRADA.WS_NUM_PROC_ISEN.IsEmpty())
                {

                    /*" -891- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -894- MOVE 'GE0310B - NUMERO PROCESSO DEVE SER PREENCHIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - NUMERO PROCESSO DEVE SER PREENCHIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -895- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -896- END-IF */
                }


                /*" -897- IF WS-VLR-NAO-RET EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_VLR_NAO_RET == 00)
                {

                    /*" -898- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -901- MOVE 'GE0310B - VALOR NAO RETIDO DEVE SER PREENCHIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - VALOR NAO RETIDO DEVE SER PREENCHIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -902- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -903- END-IF */
                }


                /*" -905- END-IF. */
            }


            /*" -906- IF WS-IND-DESC-INSS EQUAL 'N' OR 'S' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS.In("N", "S"))
            {

                /*" -907- CONTINUE */

                /*" -908- ELSE */
            }
            else
            {


                /*" -909- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -912- MOVE 'GE0310B - INDICADOR DE INSS DO FORNECEDOR DEVE SER S OU N' TO LK-SAIDA-MENSAGEM-RETORNO */
                _.Move("GE0310B - INDICADOR DE INSS DO FORNECEDOR DEVE SER S OU N", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                /*" -913- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -915- END-IF. */
            }


            /*" -916- IF WS-IND-DESC-INSS EQUAL 'N' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS == "N")
            {

                /*" -917- IF WS-CODIGO-IMP EQUAL 1 OR 10 */

                if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP.In("1", "10"))
                {

                    /*" -918- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -921- MOVE 'GE0310B - FORNECEDOR NAO PODE SER ISENTO DE INSS' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - FORNECEDOR NAO PODE SER ISENTO DE INSS", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -922- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -923- END-IF */
                }


                /*" -925- END-IF. */
            }


            /*" -926- IF WS-CODIGO-IMP EQUAL 1 OR 10 */

            if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP.In("1", "10"))
            {

                /*" -927- IF WS-ALIQUOTA-INSS NOT EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_ALIQUOTA_INSS != 00)
                {

                    /*" -928- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -931- MOVE 'GE0310B - ALIQUOTA DEVE SER ZEROS PARA O ' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - ALIQUOTA DEVE SER ZEROS PARA O ", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -932- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -933- END-IF */
                }


                /*" -935- END-IF. */
            }


            /*" -936- IF WS-IND-DESC-INSS EQUAL 'S' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS == "S")
            {

                /*" -937- IF WS-CODIGO-IMP EQUAL 1 OR 10 */

                if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP.In("1", "10"))
                {

                    /*" -939- IF WS-ALIQUOTA-INSS NOT EQUAL ZEROS */

                    if (REGISTRO_WORKING_ENTRADA.WS_ALIQUOTA_INSS != 00)
                    {

                        /*" -940- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                        /*" -943- MOVE 'GE0310B - ALIQUOTA DEVE SER ZEROS' TO LK-SAIDA-MENSAGEM-RETORNO */
                        _.Move("GE0310B - ALIQUOTA DEVE SER ZEROS", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                        /*" -944- GO TO R0999-ROTINA-RETORNO */

                        R0999_ROTINA_RETORNO(); //GOTO
                        return;

                        /*" -945- ELSE */
                    }
                    else
                    {


                        /*" -946- GO TO R0020-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/ //GOTO
                        return;

                        /*" -947- END-IF */
                    }


                    /*" -948- ELSE */
                }
                else
                {


                    /*" -949- IF WS-TIPO-PES-FORN EQUAL 'J' */

                    if (REGISTRO_WORKING_ENTRADA.WS_TIPO_PES_FORN == "J")
                    {

                        /*" -950- IF WS-ALIQUOTA-INSS NOT EQUAL 3,5 AND 11 */

                        if (!REGISTRO_WORKING_ENTRADA.WS_ALIQUOTA_INSS.In("3.5", "11"))
                        {

                            /*" -951- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                            _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                            /*" -954- MOVE 'GE0310B - ALIQUOTA DEVE SER 3,5% OU 11%' TO LK-SAIDA-MENSAGEM-RETORNO */
                            _.Move("GE0310B - ALIQUOTA DEVE SER 3,5% OU 11%", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                            /*" -955- GO TO R0999-ROTINA-RETORNO */

                            R0999_ROTINA_RETORNO(); //GOTO
                            return;

                            /*" -956- END-IF */
                        }


                        /*" -957- END-IF */
                    }


                    /*" -958- END-IF */
                }


                /*" -960- END-IF. */
            }


            /*" -961- IF WS-IND-DESC-INSS EQUAL 'S' OR 'N' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS.In("S", "N"))
            {

                /*" -962- IF WS-CODIGO-IMP EQUAL 1 OR 10 */

                if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP.In("1", "10"))
                {

                    /*" -964- IF WS-ALIQUOTA-INSS NOT EQUAL ZEROS */

                    if (REGISTRO_WORKING_ENTRADA.WS_ALIQUOTA_INSS != 00)
                    {

                        /*" -965- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                        /*" -970- STRING 'GE0310B - ALIQUOTA DEVE SER ZEROS' '/DESC INSS = ' WS-IND-DESC-INSS '/ALIQ INSS = ' WS-ALIQUOTA-INSS-A '/COD IMP   = ' WS-CODIGO-IMP DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                        #region STRING
                        var spl2 = "GE0310B - ALIQUOTA DEVE SER ZEROS" + "/DESC INSS = " + REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS.GetMoveValues();
                        spl2 += "/ALIQ INSS = ";
                        var spl3 = REGISTRO_WORKING_ENTRADA.FILLER_2.WS_ALIQUOTA_INSS_A.GetMoveValues();
                        spl3 += "/COD IMP = ";
                        var spl4 = REGISTRO_WORKING_ENTRADA.WS_CODIGO_IMP.GetMoveValues();
                        var results5 = spl2 + spl3 + spl4;
                        _.Move(results5, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                        #endregion

                        /*" -971- GO TO R0999-ROTINA-RETORNO */

                        R0999_ROTINA_RETORNO(); //GOTO
                        return;

                        /*" -972- ELSE */
                    }
                    else
                    {


                        /*" -973- GO TO R0020-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/ //GOTO
                        return;

                        /*" -974- END-IF */
                    }


                    /*" -975- END-IF */
                }


                /*" -977- END-IF. */
            }


            /*" -978- IF WS-IND-DESC-INSS EQUAL 'S' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS == "S")
            {

                /*" -979- IF WS-TIPO-PES-FORN EQUAL 'J' */

                if (REGISTRO_WORKING_ENTRADA.WS_TIPO_PES_FORN == "J")
                {

                    /*" -980- IF WS-ALIQUOTA-INSS EQUAL ZEROS */

                    if (REGISTRO_WORKING_ENTRADA.WS_ALIQUOTA_INSS == 00)
                    {

                        /*" -981- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                        _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                        /*" -984- MOVE 'GE0310B - ALIQUOTA DEVE SER DIFERENTE DE ZEROS' TO LK-SAIDA-MENSAGEM-RETORNO */
                        _.Move("GE0310B - ALIQUOTA DEVE SER DIFERENTE DE ZEROS", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                        /*" -985- GO TO R0999-ROTINA-RETORNO */

                        R0999_ROTINA_RETORNO(); //GOTO
                        return;

                        /*" -986- END-IF */
                    }


                    /*" -987- END-IF */
                }


                /*" -989- END-IF. */
            }


            /*" -990- IF WS-IND-DESC-INSS EQUAL 'N' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS == "N")
            {

                /*" -991- IF WS-ALIQUOTA-INSS GREATER ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_ALIQUOTA_INSS > 00)
                {

                    /*" -992- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -996- STRING 'GE0310B - ALIQUOTA DEVE SER ZEROS' '/DESC INSS = ' WS-IND-DESC-INSS '/ALIQ INSS = ' WS-ALIQUOTA-INSS-A DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                    #region STRING
                    var spl5 = "GE0310B - ALIQUOTA DEVE SER ZEROS" + "/DESC INSS = " + REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS.GetMoveValues();
                    spl5 += "/ALIQ INSS = ";
                    var spl6 = REGISTRO_WORKING_ENTRADA.FILLER_2.WS_ALIQUOTA_INSS_A.GetMoveValues();
                    var results7 = spl5 + spl6;
                    _.Move(results7, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                    #endregion

                    /*" -997- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -998- END-IF */
                }


                /*" -1021- END-IF. */
            }


            /*" -1022- IF WS-CODIGO-INSS NOT EQUAL ZEROS */

            if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_INSS != 00)
            {

                /*" -1023- PERFORM RT-SELECT-TP-SERV THRU R0002-EXIT */

                RT_SELECT_TP_SERV(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0002_EXIT*/


                /*" -1025- END-IF. */
            }


            /*" -1026- IF WS-IND-DESC-INSS EQUAL 'S' */

            if (REGISTRO_WORKING_ENTRADA.WS_IND_DESC_INSS == "S")
            {

                /*" -1027- IF WS-CODIGO-INSS EQUAL ZEROS */

                if (REGISTRO_WORKING_ENTRADA.WS_CODIGO_INSS == 00)
                {

                    /*" -1028- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -1031- MOVE 'GE0310B - CODIGO DO INSS INVALIDO' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - CODIGO DO INSS INVALIDO", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -1032- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -1033- END-IF */
                }


                /*" -1033- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/

        [StopWatch]
        /*" R0030-PESQUISAR-PRODUTO */
        private void R0030_PESQUISAR_PRODUTO(bool isPerform = false)
        {
            /*" -1064- MOVE WS-COD-PRODUTO TO PRODUTO-COD-PRODUTO WSL-COD-PRODUTO. */
            _.Move(REGISTRO_WORKING_ENTRADA.WS_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, AREA_DE_WORK.WSL_COD_PRODUTO);

            /*" -1073- PERFORM R0030_PESQUISAR_PRODUTO_DB_SELECT_1 */

            R0030_PESQUISAR_PRODUTO_DB_SELECT_1();

            /*" -1076- IF NOT ( SQLCODE = 000 OR 100 ) */

            if (!(DB.SQLCODE.In("000", "100")))
            {

                /*" -1077- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -1079- MOVE SQLCODE TO WSL-SQLCODE LK-SAIDA-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_SQLCODE);

                /*" -1082- STRING 'GE0310B - ERRO NO SELECT DE PRODUTO - SQLCODE = ' WSL-SQLCODE DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                #region STRING
                var spl7 = "GE0310B - ERRO NO SELECT DE PRODUTO - SQLCODE = " + AREA_DE_WORK.WSL_SQLCODE.GetMoveValues();
                _.Move(spl7, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                #endregion

                /*" -1083- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -1085- END-IF */
            }


            /*" -1086- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1087- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -1090- STRING 'GE0310B - PRODUTO INFORMADO NAO CADASTRADO = ' WSL-COD-PRODUTO DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                #region STRING
                var spl8 = "GE0310B - PRODUTO INFORMADO NAO CADASTRADO = " + AREA_DE_WORK.WSL_COD_PRODUTO.GetMoveValues();
                _.Move(spl8, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                #endregion

                /*" -1091- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -1091- END-IF. */
            }


        }

        [StopWatch]
        /*" R0030-PESQUISAR-PRODUTO-DB-SELECT-1 */
        public void R0030_PESQUISAR_PRODUTO_DB_SELECT_1()
        {
            /*" -1073- EXEC SQL SELECT PROD.COD_EMPRESA ,PRMG.COD_CGCCPF INTO :PRODUTO-COD-EMPRESA ,:PARAMGER-COD-CGCCPF FROM SEGUROS.PRODUTO PROD ,SEGUROS.PARAMETROS_GERAIS PRMG WHERE PROD.COD_PRODUTO = :PRODUTO-COD-PRODUTO AND PROD.COD_EMPRESA = PRMG.COD_EMPRESA END-EXEC. */

            var r0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1 = new R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1.Execute(r0030_PESQUISAR_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PARAMGER_COD_CGCCPF, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_EXIT*/

        [StopWatch]
        /*" R0040-PESQUISAR-APOLICE */
        private void R0040_PESQUISAR_APOLICE(bool isPerform = false)
        {
            /*" -1100- MOVE WS-NUM-APOLICE TO APOLICES-NUM-APOLICE WSL-NUM-APOLICE. */
            _.Move(REGISTRO_WORKING_ENTRADA.WS_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE, AREA_DE_WORK.WSL_NUM_APOLICE);

            /*" -1111- PERFORM R0040_PESQUISAR_APOLICE_DB_SELECT_1 */

            R0040_PESQUISAR_APOLICE_DB_SELECT_1();

            /*" -1114- IF NOT ( SQLCODE = 000 OR 100 ) */

            if (!(DB.SQLCODE.In("000", "100")))
            {

                /*" -1115- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -1117- MOVE SQLCODE TO WSL-SQLCODE LK-SAIDA-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_SQLCODE);

                /*" -1120- STRING 'GE0310B - ERRO NO SELECT DE APOLICES - SQLCODE = ' WSL-SQLCODE DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                #region STRING
                var spl9 = "GE0310B - ERRO NO SELECT DE APOLICES - SQLCODE = " + AREA_DE_WORK.WSL_SQLCODE.GetMoveValues();
                _.Move(spl9, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                #endregion

                /*" -1121- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -1123- END-IF */
            }


            /*" -1124- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1125- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                /*" -1128- STRING 'GE0310B - APOLICE INFORMADO NAO CADASTRADA = ' WSL-NUM-APOLICE DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                #region STRING
                var spl10 = "GE0310B - APOLICE INFORMADO NAO CADASTRADA = " + AREA_DE_WORK.WSL_NUM_APOLICE.GetMoveValues();
                _.Move(spl10, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                #endregion

                /*" -1129- GO TO R0999-ROTINA-RETORNO */

                R0999_ROTINA_RETORNO(); //GOTO
                return;

                /*" -1129- END-IF. */
            }


        }

        [StopWatch]
        /*" R0040-PESQUISAR-APOLICE-DB-SELECT-1 */
        public void R0040_PESQUISAR_APOLICE_DB_SELECT_1()
        {
            /*" -1111- EXEC SQL SELECT PROD.COD_EMPRESA ,PRMG.COD_CGCCPF INTO :PRODUTO-COD-EMPRESA ,:PARAMGER-COD-CGCCPF FROM SEGUROS.APOLICES APOL ,SEGUROS.PRODUTO PROD ,SEGUROS.PARAMETROS_GERAIS PRMG WHERE APOL.NUM_APOLICE = :APOLICES-NUM-APOLICE AND APOL.COD_PRODUTO = PROD.COD_PRODUTO AND PROD.COD_EMPRESA = PRMG.COD_EMPRESA END-EXEC. */

            var r0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1 = new R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1.Execute(r0040_PESQUISAR_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PARAMGER_COD_CGCCPF, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_EXIT*/

        [StopWatch]
        /*" RT-SELECT-TP-SERV */
        private void RT_SELECT_TP_SERV(bool isPerform = false)
        {
            /*" -1138- MOVE WS-CODIGO-INSS TO GE612-SEQ-TP-SERVICO-INSS. */
            _.Move(REGISTRO_WORKING_ENTRADA.WS_CODIGO_INSS, GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS);

            /*" -1144- PERFORM RT_SELECT_TP_SERV_DB_SELECT_1 */

            RT_SELECT_TP_SERV_DB_SELECT_1();

            /*" -1147- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1148- CONTINUE */

                /*" -1149- ELSE */
            }
            else
            {


                /*" -1150- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1151- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -1154- MOVE 'GE0310B - TIPO DE SERVICO NAO EXISTENTE' TO LK-SAIDA-MENSAGEM-RETORNO */
                    _.Move("GE0310B - TIPO DE SERVICO NAO EXISTENTE", REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);

                    /*" -1155- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -1156- ELSE */
                }
                else
                {


                    /*" -1157- MOVE '1' TO LK-SAIDA-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE.LK_SAIDA_COD_RETORNO);

                    /*" -1159- MOVE SQLCODE TO WSL-SQLCODE LK-SAIDA-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_SQLCODE);

                    /*" -1163- STRING 'GE0310B - ERRO NO SELECT DE SERVICOS - SQLCODE= ' WSL-SQLCODE DELIMITED BY SIZE INTO LK-SAIDA-MENSAGEM-RETORNO */
                    #region STRING
                    var spl11 = "GE0310B - ERRO NO SELECT DE SERVICOS - SQLCODE= " + AREA_DE_WORK.WSL_SQLCODE.GetMoveValues();
                    _.Move(spl11, REGISTRO_LINKAGE.LK_SAIDA_MENSAGEM.LK_SAIDA_MENSAGEM_RETORNO);
                    #endregion

                    /*" -1164- GO TO R0999-ROTINA-RETORNO */

                    R0999_ROTINA_RETORNO(); //GOTO
                    return;

                    /*" -1165- END-IF */
                }


                /*" -1165- END-IF. */
            }


        }

        [StopWatch]
        /*" RT-SELECT-TP-SERV-DB-SELECT-1 */
        public void RT_SELECT_TP_SERV_DB_SELECT_1()
        {
            /*" -1144- EXEC SQL SELECT SEQ_TP_SERVICO_INSS INTO :GE612-SEQ-TP-SERVICO-INSS FROM SIUS.GE_TP_SERVICO_INSS WHERE SEQ_TP_SERVICO_INSS = :GE612-SEQ-TP-SERVICO-INSS END-EXEC. */

            var rT_SELECT_TP_SERV_DB_SELECT_1_Query1 = new RT_SELECT_TP_SERV_DB_SELECT_1_Query1()
            {
                GE612_SEQ_TP_SERVICO_INSS = GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS.ToString(),
            };

            var executed_1 = RT_SELECT_TP_SERV_DB_SELECT_1_Query1.Execute(rT_SELECT_TP_SERV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE612_SEQ_TP_SERVICO_INSS, GE612.DCLGE_TP_SERVICO_INSS.GE612_SEQ_TP_SERVICO_INSS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0002_EXIT*/

        [StopWatch]
        /*" R0999-ROTINA-RETORNO */
        private void R0999_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -1171- MOVE SQLCODE TO WSL-SQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

            /*" -1174- DISPLAY 'GE0310B - R0999 - ' WSL-SQLCODE ' / ' SQLERRMC. */

            $"GE0310B - R0999 - {AREA_DE_WORK.WSL_SQLCODE} / {DB.SQLERRMC}"
            .Display();

            /*" -1174- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/
    }
}