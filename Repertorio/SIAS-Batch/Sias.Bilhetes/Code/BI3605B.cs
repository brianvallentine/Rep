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
using Sias.Bilhetes.DB2.BI3605B;

namespace Code
{
    public class BI3605B
    {
        public bool IsCall { get; set; }

        public BI3605B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA STATUS DE VIDA/BILHETE PARA     *      */
        /*"      *                           SYSTEM CRED.                         *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO.....  TERCIO FREITAS.                    *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  BI3605B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  30/08/2010.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ATUALIZACOES.                                                *      */
        /*"      *   ------------                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * VERSAO 05 - DEMANDA 402.982                                    *      */
        /*"      *           - SUBSTITUIR CONSULTA DA TABELA BILHETE_ERROS        *      */
        /*"      *             PELA NA NOVA TABELA VG_CRITICA_PROPOSTA            *      */
        /*"      *                                                                *      */
        /*"      * EM 14/02/2023 - ELIERMES OLIVEIRA                              *      */
        /*"      *                                        PROCURE POR V.05        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 85.727                                       *      */
        /*"      *             - AJUSTE  PARA CORRGIR O STATUS DO BILHETE         *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/09/2013 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  03 - CADMUS 58.198                                     *      */
        /*"      * PROJETO SYSTEM CRED    EDER TOLENTINO / FAST COMPUTER          *      */
        /*"      *                                                                *      */
        /*"      * 29/06/2011   FLUXO DE RETORNO DE ARQUIVOS PARA OS PARCEIROS DE *      */
        /*"      *              CANAL EXTRA REDE                                  *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR: V.03                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  02 - CADMUS 53.577                                     *      */
        /*"      * PROJETO SYSTEM CRED          EDIVALDO / FAST COMPUTER          *      */
        /*"      *                                                                *      */
        /*"      * 11/03/2011   AJUSTES NO PROCESSO DE RETENCAO SYSTEM CRED:      *      */
        /*"      *              CONTEMPLAR O MOTIVO DO CANCELAMENTO E UTILIZAR AS *      */
        /*"      *              DEMAIS ALTERACOES DA PROPOSTA COMO EVENTO DE      *      */
        /*"      *              ENDOSSO. REGISTRO ALTERADO.                       *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR: V.02                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  01 - CAD00002                                          *      */
        /*"      * PROJETO ATM                  EDIVALDO/ FAST COMPUTER           *      */
        /*"      *                                                                *      */
        /*"      * 22/09/2010   ADEQUAR O PROGRAMA PARA TRATAR PROPOSTAS QUE NAO  *      */
        /*"      *              TEM NA TABELA SEGUROS.CONVERSAO_SICOB             *      */
        /*"      *                                                                *      */
        /*"      * PROCURAR POR: V.01                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15 -                                                    *      */
        /*"      * SOLICITACAO VIA ...CADMUS 43617                                *      */
        /*"      * 30/08/2010 PROCURE POR V.00 - TERCIO FREITAS                   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_STA { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA, REG_STA_SASSE); return _MOVTO_STA;
            }
        }
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  PARAMETROS.*/
        public BI3605B_PARAMETROS PARAMETROS { get; set; } = new BI3605B_PARAMETROS();
        public class BI3605B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public BI3605B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new BI3605B_LK_NASCIMENTO();
            public class BI3605B_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                PIC S9(03) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01  DATA-LIB-STA-PEN                 PIC  X(010).*/
        }
        public StringBasis DATA_LIB_STA_PEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-CONVERSI                      PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_CONVERSI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WS-PROC-CAN                      PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_PROC_CAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WAREA-AUXILIAR.*/
        public BI3605B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new BI3605B_WAREA_AUXILIAR();
        public class BI3605B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  WS-DESPREZA-STATUS            PIC X(003)  VALUE SPACES.*/
            public StringBasis WS_DESPREZA_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WS-TEM-HIST-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis WS_TEM_HIST_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WS-QTDBIL                     PIC S9(004)    COMP.*/
            public IntBasis WS_QTDBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  W-FIM-MOVTO-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-COB             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-ERROS-VDZ               PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_ERROS_VDZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-ERROS           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_ERROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-TIME                        PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05  W-TIME-EDIT                   PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-CONTROLE                    PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-REG-BIL-AP                  PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_REG_BIL_AP { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-PRM-LIQ                     PIC  9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05  W-QTD-LD-TIPO-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-ABEND-CTR                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_ABEND_CTR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-VIDA                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_VIDA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-AP                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_AP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-RD                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_RD { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-BILHETE-LIDO                PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_BILHETE_LIDO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_BI3605B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI3605B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI3605B_FILLER_0(); _.Move(W_COD_COBERTURA, _filler_0); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_0, W_COD_COBERTURA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_COD_COBERTURA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_BI3605B_FILLER_0 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_BI3605B_FILLER_0()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  WDTA-TERVG-CALC               PIC X(010)  VALUE SPACES.*/
            public StringBasis WDTA_TERVG_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_BI3605B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI3605B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI3605B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_BI3605B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_BI3605B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_BI3605B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_BI3605B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_BI3605B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_BI3605B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_BI3605B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_BI3605B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_BI3605B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_BI3605B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_BI3605B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_BI3605B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_BI3605B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_BI3605B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_BI3605B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_BI3605B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 W-RCAP                         PIC  9(001) VALUE ZERO.*/

                public _REDEF_BI3605B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_RCAP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-NORMAL                             VALUE 1. */
							new SelectorItemBasis("RCAP_NORMAL", "1"),
							/*" 88 RCAP-ERRO                               VALUE 2. */
							new SelectorItemBasis("RCAP_ERRO", "2")
                }
            };

            /*"    05  W-NUM-PROPOSTA-NOVA           PIC  9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_BI3605B_CANAL _canal { get; set; }
            public _REDEF_BI3605B_CANAL CANAL
            {
                get { _canal = new _REDEF_BI3605B_CANAL(); _.Move(W_NUM_PROPOSTA_NOVA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _canal, W_NUM_PROPOSTA_NOVA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA_NOVA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_BI3605B_CANAL : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC  9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC  9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NUM-PROPOSTA                PIC  9(014).*/

                public _REDEF_BI3605B_CANAL()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_BI3605B_CANAL_0 _canal_0 { get; set; }
            public _REDEF_BI3605B_CANAL_0 CANAL_0
            {
                get { _canal_0 = new _REDEF_BI3605B_CANAL_0(); _.Move(W_NUM_PROPOSTA, _canal_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal_0, W_NUM_PROPOSTA); _canal_0.ValueChanged += () => { _.Move(_canal_0, W_NUM_PROPOSTA); }; return _canal_0; }
                set { VarBasis.RedefinePassValue(value, _canal_0, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_BI3605B_CANAL_0 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC  9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-GRAFICA                VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_GRAFICA", "0"),
							/*" 88 CANAL-VENDA-CEF                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                  VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR               VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                    VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                  VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET               VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET               VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8"),
							/*" 88 CANAL-CORRESP-NEGOCIAL             VALUE 9. */
							new SelectorItemBasis("CANAL_CORRESP_NEGOCIAL", "9")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05 W-TEM-ERRO-SEG-VDZ             PIC  9(001) VALUE ZERO.*/

                public _REDEF_BI3605B_CANAL_0()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_TEM_ERRO_SEG_VDZ { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-ERRO-SEG-VDZ                        VALUE 1. */
							new SelectorItemBasis("TEM_ERRO_SEG_VDZ", "1")
                }
            };

            /*"    05 W-PENDENCIA-PROPOSTA           PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PENDENCIA_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 AGUARDANDO-PRP-FISICA                   VALUE 1. */
							new SelectorItemBasis("AGUARDANDO_PRP_FISICA", "1")
                }
            };

            /*"    05 W-TEM-ERRO-BILHETE             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_ERRO_BILHETE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-ERRO-SEG-BIL                        VALUE 1. */
							new SelectorItemBasis("TEM_ERRO_SEG_BIL", "1")
                }
            };

            /*"    05 W-TEM-COBERTURA-BILHETE        PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_COBERTURA_BILHETE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-COBERTURA-BILHETE                   VALUE 1. */
							new SelectorItemBasis("TEM_COBERTURA_BILHETE", "1")
                }
            };

            /*"    05 W-TEM-COBERPROPVA              PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_COBERPROPVA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NAO-TEM-COBERPROPVA                     VALUE 1. */
							new SelectorItemBasis("NAO_TEM_COBERPROPVA", "1")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 FEDERALPREV                             VALUE 2. */
							new SelectorItemBasis("FEDERALPREV", "2"),
							/*" 88 FEDERALCAP                              VALUE 3. */
							new SelectorItemBasis("FEDERALCAP", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE88                               VALUE 4. */
							new SelectorItemBasis("BILHETE88", "4")
                }
            };

            /*"    05 W-PRODUTO                      PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_PRODUTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MULTIPREMIADO                           VALUE 01. */
							new SelectorItemBasis("MULTIPREMIADO", "01"),
							/*" 88 FEDPREV                                 VALUE 02. */
							new SelectorItemBasis("FEDPREV", "02"),
							/*" 88 FEDECAP                                 VALUE 03. */
							new SelectorItemBasis("FEDECAP", "03"),
							/*" 88 EXECUTIVO                               VALUE 04. */
							new SelectorItemBasis("EXECUTIVO", "04"),
							/*" 88 FEDPREV-CRESCER                         VALUE 05. */
							new SelectorItemBasis("FEDPREV_CRESCER", "05"),
							/*" 88 FEDPREV-PGTO-UNICO                      VALUE 06. */
							new SelectorItemBasis("FEDPREV_PGTO_UNICO", "06"),
							/*" 88 SENIOR                                  VALUE 07. */
							new SelectorItemBasis("SENIOR", "07"),
							/*" 88 FEDPREV-ECONOMIARIO                     VALUE 08. */
							new SelectorItemBasis("FEDPREV_ECONOMIARIO", "08"),
							/*" 88 BILHETE-AP                              VALUE 09. */
							new SelectorItemBasis("BILHETE_AP", "09"),
							/*" 88 BILHETE-RD                              VALUE 10. */
							new SelectorItemBasis("BILHETE_RD", "10"),
							/*" 88 VIDA-DA-GENTE                           VALUE 11. */
							new SelectorItemBasis("VIDA_DA_GENTE", "11"),
							/*" 88 MULTIPREMIADO-SUPER                     VALUE 13. */
							new SelectorItemBasis("MULTIPREMIADO_SUPER", "13"),
							/*" 88 VIDAZUL-EMPRESARIAL                     VALUE 15. */
							new SelectorItemBasis("VIDAZUL_EMPRESARIAL", "15"),
							/*" 88 VIDAZUL-EMPRESARIAL-SUPER               VALUE 16. */
							new SelectorItemBasis("VIDAZUL_EMPRESARIAL_SUPER", "16")
                }
            };

            /*"    05 W-TP-MOVIMENTO                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TP_MOVIMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MOVTO-AVULSO                            VALUE 1. */
							new SelectorItemBasis("MOVTO_AVULSO", "1"),
							/*" 88 MOVTO-ADESAO                            VALUE 2. */
							new SelectorItemBasis("MOVTO_ADESAO", "2")
                }
            };

            /*"01  W-VINDICADORAS.*/
        }
        public BI3605B_W_VINDICADORAS W_VINDICADORAS { get; set; } = new BI3605B_W_VINDICADORAS();
        public class BI3605B_W_VINDICADORAS : VarBasis
        {
            /*"    05 VIND-DT-RCAP                   PIC S9(004) COMP  VALUE +0*/
            public IntBasis VIND_DT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01      REG-HEADER-STA.*/
        }
        public BI3605B_REG_HEADER_STA REG_HEADER_STA { get; set; } = new BI3605B_REG_HEADER_STA();
        public class BI3605B_REG_HEADER_STA : VarBasis
        {
            /*"     10  RH-TIPO-REG                 PIC  X(001).*/
            public StringBasis RH_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  RH-NOME-EMPRESA             PIC  X(008).*/
            public StringBasis RH_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  RH-DATA-GERACAO             PIC  9(008).*/
            public IntBasis RH_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RH-SIST-ORIGEM              PIC  9(001).*/
            public IntBasis RH_SIST_ORIGEM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  RH-SIST-DESTINO             PIC  9(001).*/
            public IntBasis RH_SIST_DESTINO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10  RH-NSAS                     PIC  9(006).*/
            public IntBasis RH_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10  FILLER                      PIC  X(075).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)."), @"");
            /*"01      REG-STA-QUOTA.*/
        }
        public BI3605B_REG_STA_QUOTA REG_STA_QUOTA { get; set; } = new BI3605B_REG_STA_QUOTA();
        public class BI3605B_REG_STA_QUOTA : VarBasis
        {
            /*"     10  R0-TIPO-REG                 PIC  X(001).*/
            public StringBasis R0_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R0-VAL-QUOTA                PIC  9(007)V9(08).*/
            public DoubleBasis R0_VAL_QUOTA { get; set; } = new DoubleBasis(new PIC("9", "7", "9(007)V9(08)."), 8);
            /*"     10  FILLER                      PIC  X(084).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)."), @"");
            /*"01      REG-STA-PROPOSTA.*/
        }
        public BI3605B_REG_STA_PROPOSTA REG_STA_PROPOSTA { get; set; } = new BI3605B_REG_STA_PROPOSTA();
        public class BI3605B_REG_STA_PROPOSTA : VarBasis
        {
            /*"     10  R1-TIPO-REG                 PIC  X(001).*/
            public StringBasis R1_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  R1-NUM-PROPOSTA             PIC  9(014).*/
            public IntBasis R1_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"     10  R1-SIT-PROPOSTA             PIC  X(003).*/
            public StringBasis R1_SIT_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"     10  R1-SIT-COBRANCA             PIC  X(003).*/
            public StringBasis R1_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"     10  R1-SIT-MOTIVO               PIC  9(004).*/
            public IntBasis R1_SIT_MOTIVO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10  R1-DATA-SITUACAO            PIC  9(008).*/
            public IntBasis R1_DATA_SITUACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  R1-VALOR-ATRIBUTO           PIC  X(055).*/
            public StringBasis R1_VALOR_ATRIBUTO { get; set; } = new StringBasis(new PIC("X", "55", "X(055)."), @"");
            /*"     10  R1-NSAS                     PIC  9(006).*/
            public IntBasis R1_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10  R1-NSL                      PIC  9(006).*/
            public IntBasis R1_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01      REG-TRAILLER-STA.*/
        }
        public BI3605B_REG_TRAILLER_STA REG_TRAILLER_STA { get; set; } = new BI3605B_REG_TRAILLER_STA();
        public class BI3605B_REG_TRAILLER_STA : VarBasis
        {
            /*"     10  RT-TIPO-REG                  PIC  X(001).*/
            public StringBasis RT_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"     10  RT-NOME-EMPRESA              PIC  X(008).*/
            public StringBasis RT_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"     10  RT-QTDE-TIPO-1               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-2               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-3               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-4               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-5               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-6               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-7               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-8               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-9               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TIPO-0               PIC  9(008).*/
            public IntBasis RT_QTDE_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  RT-QTDE-TOTAL                PIC  9(008).*/
            public IntBasis RT_QTDE_TOTAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10  FILLER                       PIC  X(003).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"01  WABEND.*/
        }
        public BI3605B_WABEND WABEND { get; set; } = new BI3605B_WABEND();
        public class BI3605B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'BI3605B  '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"BI3605B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10      LOCALIZA-ABEND-1.*/
            public BI3605B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new BI3605B_LOCALIZA_ABEND_1();
            public class BI3605B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        15    FILLER                 PIC  X(012)   VALUE              'PARAGRAFO = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        15    PARAGRAFO              PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"      10      LOCALIZA-ABEND-2.*/
            }
            public BI3605B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new BI3605B_LOCALIZA_ABEND_2();
            public class BI3605B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"        15    FILLER                 PIC  X(012)   VALUE              'COMANDO   = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        15    COMANDO                PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public BI3605B_WS_HORAS WS_HORAS { get; set; } = new BI3605B_WS_HORAS();
        public class BI3605B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_BI3605B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_BI3605B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_BI3605B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_BI3605B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_BI3605B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_BI3605B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_BI3605B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_BI3605B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_BI3605B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_BI3605B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public BI3605B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new BI3605B_TOTAIS_ROT();
        public class BI3605B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<BI3605B_FILLER_14> FILLER_14 { get; set; } = new ListBasis<BI3605B_FILLER_14>(50);
            public class BI3605B_FILLER_14 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.IDENTREL IDENTREL { get; set; } = new Dclgens.IDENTREL();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.ERROSBIL ERROSBIL { get; set; } = new Dclgens.ERROSBIL();
        public Dclgens.CODERRBI CODERRBI { get; set; } = new Dclgens.CODERRBI();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.ERROVDAZ ERROVDAZ { get; set; } = new Dclgens.ERROVDAZ();
        public BI3605B_CBILHETE CBILHETE { get; set; } = new BI3605B_CBILHETE();
        public BI3605B_BILHETE_ERROS BILHETE_ERROS { get; set; } = new BI3605B_BILHETE_ERROS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA.SetFile(MOVTO_STA_FILE_NAME_P);

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
            /*" -571- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -573- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -575- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -578- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -579- DISPLAY 'PROGRAMA EM EXECUCAO BI3605B   ' */
            _.Display($"PROGRAMA EM EXECUCAO BI3605B   ");

            /*" -585- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -586- DISPLAY 'VERSAO V.05 402.982 14/02/2023 ' */
            _.Display($"VERSAO V.05 402.982 14/02/2023 ");

            /*" -587- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -589- DISPLAY ' ' . */
            _.Display($" ");

            /*" -591- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -592- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -594- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -597- DISPLAY '** BI3605B ** INICIO PROCESSAMENTO - HORA....  ' W-TIME-EDIT. */
            _.Display($"** BI3605B ** INICIO PROCESSAMENTO - HORA....  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -599- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -601- PERFORM R0006-00-OBTER-RELATORI. */

            R0006_00_OBTER_RELATORI_SECTION();

            /*" -603- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -605- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -607- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -609- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -611- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -614- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -616- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -618- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -620- PERFORM R0870-00-GERAR-TOTAIS. */

            R0870_00_GERAR_TOTAIS_SECTION();

            /*" -624- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -625- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -627- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -630- DISPLAY '** BI3605B ** FIM    PROCESSAMENTO - HORA....  ' W-TIME-EDIT. */
            _.Display($"** BI3605B ** FIM    PROCESSAMENTO - HORA....  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -630- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -638- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -640- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -642- MOVE 'BI' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("BI", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -647- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -650- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -651- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -652- DISPLAY '          ERRO SELECT SISTEMAS          ' */
                _.Display($"          ERRO SELECT SISTEMAS          ");

                /*" -654- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -655- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -657- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -660- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -662- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -664- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -667- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -669- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -647- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0006-00-OBTER-RELATORI-SECTION */
        private void R0006_00_OBTER_RELATORI_SECTION()
        {
            /*" -679- MOVE 'R0006-00-OBTER-RELATORI' TO PARAGRAFO. */
            _.Move("R0006-00-OBTER-RELATORI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -681- MOVE 'SELECT SEGUROS.RELATORI' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -685- MOVE 'BI3605B' TO RELATORI-COD-USUARIO RELATORI-COD-RELATORIO. */
            _.Move("BI3605B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -691- PERFORM R0006_00_OBTER_RELATORI_DB_SELECT_1 */

            R0006_00_OBTER_RELATORI_DB_SELECT_1();

            /*" -694- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -695- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -696- DISPLAY '          ERRO SELECT RELATORIOS        ' */
                _.Display($"          ERRO SELECT RELATORIOS        ");

                /*" -698- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -699- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -701- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -703- MOVE 'UPDATE SEGUROS.RELATORI' TO COMANDO. */
            _.Move("UPDATE SEGUROS.RELATORI", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -708- PERFORM R0006_00_OBTER_RELATORI_DB_UPDATE_1 */

            R0006_00_OBTER_RELATORI_DB_UPDATE_1();

            /*" -711- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -712- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -713- DISPLAY '          ERRO UPDATE RELATORIOS        ' */
                _.Display($"          ERRO UPDATE RELATORIOS        ");

                /*" -715- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -716- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -716- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0006-00-OBTER-RELATORI-DB-SELECT-1 */
        public void R0006_00_OBTER_RELATORI_DB_SELECT_1()
        {
            /*" -691- EXEC SQL SELECT DATA_SOLICITACAO + 1 DAY INTO :RELATORI-DATA-SOLICITACAO FROM SEGUROS.RELATORIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND COD_RELATORIO = :RELATORI-COD-RELATORIO END-EXEC. */

            var r0006_00_OBTER_RELATORI_DB_SELECT_1_Query1 = new R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            var executed_1 = R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1.Execute(r0006_00_OBTER_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
            }


        }

        [StopWatch]
        /*" R0006-00-OBTER-RELATORI-DB-UPDATE-1 */
        public void R0006_00_OBTER_RELATORI_DB_UPDATE_1()
        {
            /*" -708- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO WHERE COD_USUARIO = :RELATORI-COD-USUARIO AND COD_RELATORIO = :RELATORI-COD-RELATORIO END-EXEC. */

            var r0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1 = new R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1.Execute(r0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0006_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -726- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -728- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -728- OPEN OUTPUT MOVTO-STA. */
            MOVTO_STA.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -738- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -740- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -743- MOVE 'STASCRED' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASCRED", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -746- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -754- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -757- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -758- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -759- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -761- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -762- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -764- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -767- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -769- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -769- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -754- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -779- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -783- MOVE 'DECLARE CBILHETE       ' TO COMANDO. */
            _.Move("DECLARE CBILHETE       ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -796- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -799- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -802- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -803- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -804- DISPLAY '          ERRO OPEN CURSOR PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO OPEN CURSOR PROPOSTA-FIDELIZ");

                /*" -806- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -807- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -807- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -796- EXEC SQL DECLARE CBILHETE CURSOR FOR SELECT NUM_BILHETE, SITUACAO, SIT_SINISTRO, NUM_APOLICE FROM SEGUROS.BILHETE WHERE SITUACAO IN ( 'F' , '7' , '8' ) AND DATE(TIMESTAMP) BETWEEN :RELATORI-DATA-SOLICITACAO AND :SISTEMAS-DATA-MOV-ABERTO END-EXEC. */
            CBILHETE = new BI3605B_CBILHETE(true);
            string GetQuery_CBILHETE()
            {
                var query = @$"SELECT NUM_BILHETE
							, 
							SITUACAO
							, 
							SIT_SINISTRO
							, 
							NUM_APOLICE 
							FROM SEGUROS.BILHETE 
							WHERE SITUACAO IN ( 'F'
							, '7'
							, '8' ) 
							AND DATE(TIMESTAMP) 
							BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}' 
							AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            CBILHETE.GetQueryEvent += GetQuery_CBILHETE;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -799- EXEC SQL OPEN CBILHETE END-EXEC. */

            CBILHETE.Open();

        }

        [StopWatch]
        /*" R0188-00-SEL-BILHETE-ERROS-DB-DECLARE-1 */
        public void R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1()
        {
            /*" -1078- EXEC SQL DECLARE BILHETE-ERROS CURSOR FOR SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA, B.COD_ERRO_SIVPF FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :BILHETE-NUM-BILHETE AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' ORDER BY A.COD_MSG_CRITICA WITH UR END-EXEC. */
            BILHETE_ERROS = new BI3605B_BILHETE_ERROS(true);
            string GetQuery_BILHETE_ERROS()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.COD_MSG_CRITICA
							, 
							B.COD_ERRO_SIVPF 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA <> '3' 
							ORDER BY A.COD_MSG_CRITICA";

                return query;
            }
            BILHETE_ERROS.GetQueryEvent += GetQuery_BILHETE_ERROS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -814- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -817- MOVE 'FETCH CBILHETE        ' TO COMANDO. */
            _.Move("FETCH CBILHETE        ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -823- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -826- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -827- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -828- MOVE 'FIM' TO W-FIM-MOVTO-FIDELIZ */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                    /*" -828- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -830- ELSE */
                }
                else
                {


                    /*" -831- DISPLAY 'BI3605B - FIM ANORMAL' */
                    _.Display($"BI3605B - FIM ANORMAL");

                    /*" -832- DISPLAY '          ERRO FETCH CURSOR PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO FETCH CURSOR PROPOSTA-FIDELIZ");

                    /*" -834- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -835- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -836- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -838- ELSE */
                }

            }
            else
            {


                /*" -841- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -842- IF W-CONTROLE > 9999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 9999)
                {

                    /*" -843- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -844- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -845- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -847- DISPLAY '** BI3605B ** TOTAL LIDO ..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** BI3605B ** TOTAL LIDO ..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -852- END-IF */
                }


                /*" -860- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
                WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -823- EXEC SQL FETCH CBILHETE INTO :BILHETE-NUM-BILHETE, :BILHETE-SITUACAO, :BILHETE-SIT-SINISTRO, :BILHETE-NUM-APOLICE END-EXEC. */

            if (CBILHETE.Fetch())
            {
                _.Move(CBILHETE.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(CBILHETE.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(CBILHETE.BILHETE_SIT_SINISTRO, BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO);
                _.Move(CBILHETE.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -828- EXEC SQL CLOSE CBILHETE END-EXEC */

            CBILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -875- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -878- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -880- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", REG_HEADER_STA);

            /*" -883- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", REG_HEADER_STA.RH_TIPO_REG);

            /*" -886- MOVE 'STASCRED' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASCRED", REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -887- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -888- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -890- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -893- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -896- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -899- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -902- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, REG_HEADER_STA.RH_NSAS);

            /*" -902- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -913- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -916- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -917- PERFORM R0180-00-SELECT-CONVERSI. */

            R0180_00_SELECT_CONVERSI_SECTION();

            /*" -918- IF WS-CONVERSI EQUAL 'N' */

            if (WS_CONVERSI == "N")
            {

                /*" -919- GO TO R0150-LER */

                R0150_LER(); //GOTO
                return;

                /*" -921- END-IF. */
            }


            /*" -921- PERFORM R0186-00-MOTIVO-ERRO-BI. */

            R0186_00_MOTIVO_ERRO_BI_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0150_LER */

            R0150_LER();

        }

        [StopWatch]
        /*" R0150-LER */
        private void R0150_LER(bool isPerform = false)
        {
            /*" -925- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0180-00-SELECT-CONVERSI-SECTION */
        private void R0180_00_SELECT_CONVERSI_SECTION()
        {
            /*" -935- MOVE 'R0180-00-SELECT-CONVERSI  ' TO PARAGRAFO. */
            _.Move("R0180-00-SELECT-CONVERSI  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -937- MOVE 'SELECT CONVERSI         ' TO COMANDO. */
            _.Move("SELECT CONVERSI         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -940- MOVE 'S' TO WS-CONVERSI. */
            _.Move("S", WS_CONVERSI);

            /*" -945- PERFORM R0180_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0180_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -948- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -949- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -950- IF BILHETE-SITUACAO EQUAL 'F' */

                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "F")
                    {

                        /*" -951- PERFORM R0200-00-UPD-BILHETE */

                        R0200_00_UPD_BILHETE_SECTION();

                        /*" -952- END-IF */
                    }


                    /*" -953- MOVE 'N' TO WS-CONVERSI */
                    _.Move("N", WS_CONVERSI);

                    /*" -954- ELSE */
                }
                else
                {


                    /*" -955- DISPLAY 'BI3605B - FIM ANORMAL' */
                    _.Display($"BI3605B - FIM ANORMAL");

                    /*" -956- DISPLAY '          ERRO SELECT CONVERSAO_SICOB    ' */
                    _.Display($"          ERRO SELECT CONVERSAO_SICOB    ");

                    /*" -958- DISPLAY '          COD-ERRO................ ' CODERRBI-COD-ERRO */
                    _.Display($"          COD-ERRO................ {CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO}");

                    /*" -960- DISPLAY '          SQLCODE................. ' SQLCODE */
                    _.Display($"          SQLCODE................. {DB.SQLCODE}");

                    /*" -961- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -962- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -963- END-IF */
                }


                /*" -963- END-IF. */
            }


        }

        [StopWatch]
        /*" R0180-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0180_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -945- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :CONVERSI-NUM-PROPOSTA-SIVPF FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :BILHETE-NUM-BILHETE END-EXEC. */

            var r0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVERSI_NUM_PROPOSTA_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/

        [StopWatch]
        /*" R0181-00-SELECT-FIDELIZ-SECTION */
        private void R0181_00_SELECT_FIDELIZ_SECTION()
        {
            /*" -973- MOVE 'R0181-00-SELECT-FIDELIZ ' TO PARAGRAFO. */
            _.Move("R0181-00-SELECT-FIDELIZ ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -977- MOVE 'SELECT FIDELIZ          ' TO COMANDO. */
            _.Move("SELECT FIDELIZ          ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -978- MOVE ZEROS TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);

            /*" -980- MOVE SPACES TO WS-PROC-CAN. */
            _.Move("", WS_PROC_CAN);

            /*" -985- PERFORM R0181_00_SELECT_FIDELIZ_DB_SELECT_1 */

            R0181_00_SELECT_FIDELIZ_DB_SELECT_1();

            /*" -988- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -989- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -990- MOVE ZEROS TO ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ */
                    _.Move(0, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);

                    /*" -991- MOVE 'N' TO WS-PROC-CAN */
                    _.Move("N", WS_PROC_CAN);

                    /*" -992- ELSE */
                }
                else
                {


                    /*" -993- DISPLAY 'BI3605B - FIM ANORMAL' */
                    _.Display($"BI3605B - FIM ANORMAL");

                    /*" -994- DISPLAY '          ERRO SELECT PROPOSTA_FIDELIZ   ' */
                    _.Display($"          ERRO SELECT PROPOSTA_FIDELIZ   ");

                    /*" -996- DISPLAY '          PROPOSTA ............... ' CONVERSI-NUM-PROPOSTA-SIVPF */
                    _.Display($"          PROPOSTA ............... {CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF}");

                    /*" -998- DISPLAY '          SQLCODE................. ' SQLCODE */
                    _.Display($"          SQLCODE................. {DB.SQLCODE}");

                    /*" -999- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1000- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1001- END-IF */
                }


                /*" -1002- ELSE */
            }
            else
            {


                /*" -1004- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ NOT EQUAL 1001 AND 1002 */

                if (!PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("1001", "1002"))
                {

                    /*" -1005- MOVE 'N' TO WS-PROC-CAN */
                    _.Move("N", WS_PROC_CAN);

                    /*" -1006- END-IF */
                }


                /*" -1006- END-IF. */
            }


        }

        [StopWatch]
        /*" R0181-00-SELECT-FIDELIZ-DB-SELECT-1 */
        public void R0181_00_SELECT_FIDELIZ_DB_SELECT_1()
        {
            /*" -985- EXEC SQL SELECT ORIGEM_PROPOSTA INTO :ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :CONVERSI-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1 = new R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1()
            {
                CONVERSI_NUM_PROPOSTA_SIVPF = CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1.Execute(r0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0181_SAIDA*/

        [StopWatch]
        /*" R0186-00-MOTIVO-ERRO-BI-SECTION */
        private void R0186_00_MOTIVO_ERRO_BI_SECTION()
        {
            /*" -1018- MOVE 'R0186-00-MOTIVO-ERRO-BI' TO PARAGRAFO. */
            _.Move("R0186-00-MOTIVO-ERRO-BI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1020- MOVE 'NAO' TO W-FIM-BILHETE-ERROS. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_BILHETE_ERROS);

            /*" -1022- MOVE 1 TO W-RCAP. */
            _.Move(1, WAREA_AUXILIAR.W_RCAP);

            /*" -1024- MOVE 0 TO W-TEM-ERRO-BILHETE. */
            _.Move(0, WAREA_AUXILIAR.W_TEM_ERRO_BILHETE);

            /*" -1025- IF BILHETE-SITUACAO EQUAL 'F' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "F")
            {

                /*" -1027- PERFORM R0188-00-SEL-BILHETE-ERROS */

                R0188_00_SEL_BILHETE_ERROS_SECTION();

                /*" -1029- PERFORM R0189-00-LER-BILHETE-ERROS */

                R0189_00_LER_BILHETE_ERROS_SECTION();

                /*" -1031- PERFORM R0189-10-TRATAR-ERROS-BILHETE UNTIL W-FIM-BILHETE-ERROS EQUAL 'FIM' */

                while (!(WAREA_AUXILIAR.W_FIM_BILHETE_ERROS == "FIM"))
                {

                    R0189_10_TRATAR_ERROS_BILHETE_SECTION();
                }

                /*" -1032- ELSE */
            }
            else
            {


                /*" -1033- PERFORM R0181-00-SELECT-FIDELIZ */

                R0181_00_SELECT_FIDELIZ_SECTION();

                /*" -1034- IF WS-PROC-CAN NOT EQUAL SPACES */

                if (!WS_PROC_CAN.IsEmpty())
                {

                    /*" -1035- GO TO R0186-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0186_SAIDA*/ //GOTO
                    return;

                    /*" -1036- END-IF */
                }


                /*" -1037- PERFORM R0190-00-GERAR-REGISTRO-TP1 */

                R0190_00_GERAR_REGISTRO_TP1_SECTION();

                /*" -1037- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0186_SAIDA*/

        [StopWatch]
        /*" R0188-00-SEL-BILHETE-ERROS-SECTION */
        private void R0188_00_SEL_BILHETE_ERROS_SECTION()
        {
            /*" -1047- MOVE 'R0188-00-SEL-BILHETE-ERROS' TO PARAGRAFO. */
            _.Move("R0188-00-SEL-BILHETE-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1065- MOVE 'DECLARE BILHETE-ERROS' TO COMANDO. */
            _.Move("DECLARE BILHETE-ERROS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1078- PERFORM R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1 */

            R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1();

            /*" -1080- PERFORM R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1 */

            R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0188-00-SEL-BILHETE-ERROS-DB-OPEN-1 */
        public void R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1()
        {
            /*" -1080- EXEC SQL OPEN BILHETE-ERROS END-EXEC. */

            BILHETE_ERROS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0188_SAIDA*/

        [StopWatch]
        /*" R0189-00-LER-BILHETE-ERROS-SECTION */
        private void R0189_00_LER_BILHETE_ERROS_SECTION()
        {
            /*" -1090- MOVE 'R0189-00-LER-BILHETE-ERROS' TO PARAGRAFO. */
            _.Move("R0189-00-LER-BILHETE-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1093- MOVE 'FETCH BILHETE-ERROS' TO COMANDO. */
            _.Move("FETCH BILHETE-ERROS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1098- PERFORM R0189_00_LER_BILHETE_ERROS_DB_FETCH_1 */

            R0189_00_LER_BILHETE_ERROS_DB_FETCH_1();

            /*" -1101- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1102- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1103- MOVE 'FIM' TO W-FIM-BILHETE-ERROS */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_ERROS);

                    /*" -1103- PERFORM R0189_00_LER_BILHETE_ERROS_DB_CLOSE_1 */

                    R0189_00_LER_BILHETE_ERROS_DB_CLOSE_1();

                    /*" -1105- ELSE */
                }
                else
                {


                    /*" -1106- DISPLAY 'BI3605B - FIM ANORMAL' */
                    _.Display($"BI3605B - FIM ANORMAL");

                    /*" -1107- DISPLAY '          ERRO FETCH CURSOR BILHETE-ERROS' */
                    _.Display($"          ERRO FETCH CURSOR BILHETE-ERROS");

                    /*" -1109- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1110- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1110- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0189-00-LER-BILHETE-ERROS-DB-FETCH-1 */
        public void R0189_00_LER_BILHETE_ERROS_DB_FETCH_1()
        {
            /*" -1098- EXEC SQL FETCH BILHETE-ERROS INTO :ERROSBIL-NUM-BILHETE, :ERROSBIL-COD-ERRO, :CODERRBI-COD-ERRO-SIVPF END-EXEC. */

            if (BILHETE_ERROS.Fetch())
            {
                _.Move(BILHETE_ERROS.ERROSBIL_NUM_BILHETE, ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_NUM_BILHETE);
                _.Move(BILHETE_ERROS.ERROSBIL_COD_ERRO, ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_COD_ERRO);
                _.Move(BILHETE_ERROS.CODERRBI_COD_ERRO_SIVPF, CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO_SIVPF);
            }

        }

        [StopWatch]
        /*" R0189-00-LER-BILHETE-ERROS-DB-CLOSE-1 */
        public void R0189_00_LER_BILHETE_ERROS_DB_CLOSE_1()
        {
            /*" -1103- EXEC SQL CLOSE BILHETE-ERROS END-EXEC */

            BILHETE_ERROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0189_SAIDA*/

        [StopWatch]
        /*" R0189-10-TRATAR-ERROS-BILHETE-SECTION */
        private void R0189_10_TRATAR_ERROS_BILHETE_SECTION()
        {
            /*" -1117- MOVE 'R0189-10-TRATAR-ERROS-BILHETE' TO PARAGRAFO. */
            _.Move("R0189-10-TRATAR-ERROS-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1120- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1122- PERFORM R0190-00-GERAR-REGISTRO-TP1. */

            R0190_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -1122- PERFORM R0189-00-LER-BILHETE-ERROS. */

            R0189_00_LER_BILHETE_ERROS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0189_10_SAIDA*/

        [StopWatch]
        /*" R0190-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0190_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -1167- MOVE 'R0190-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0190-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1170- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1172- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", REG_STA_PROPOSTA);

            /*" -1175- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -1178- MOVE CONVERSI-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_NUM_PROPOSTA_SIVPF, REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -1179- IF BILHETE-SITUACAO EQUAL 'F' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "F")
            {

                /*" -1181- MOVE 'PEN' TO R1-SIT-PROPOSTA */
                _.Move("PEN", REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

                /*" -1183- MOVE 'PAG' TO R1-SIT-COBRANCA */
                _.Move("PAG", REG_STA_PROPOSTA.R1_SIT_COBRANCA);

                /*" -1185- MOVE CODERRBI-COD-ERRO-SIVPF TO R1-SIT-MOTIVO */
                _.Move(CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO_SIVPF, REG_STA_PROPOSTA.R1_SIT_MOTIVO);

                /*" -1186- ELSE */
            }
            else
            {


                /*" -1188- MOVE 'CAN' TO R1-SIT-PROPOSTA */
                _.Move("CAN", REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

                /*" -1189- PERFORM R0220-00-VERIFICA-CANCEL */

                R0220_00_VERIFICA_CANCEL_SECTION();

                /*" -1197- END-IF. */
            }


            /*" -1200- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -1201- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1202- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1204- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1207- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -1210- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, REG_STA_PROPOSTA.R1_NSAS);

            /*" -1212- ADD 1 TO W-QTD-LD-TIPO-1, W-ABEND-CTR. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;
            WAREA_AUXILIAR.W_ABEND_CTR.Value = WAREA_AUXILIAR.W_ABEND_CTR + 1;

            /*" -1215- MOVE W-QTD-LD-TIPO-1 TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, REG_STA_PROPOSTA.R1_NSL);

            /*" -1217- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -1218- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0200-00-UPD-BILHETE-SECTION */
        private void R0200_00_UPD_BILHETE_SECTION()
        {
            /*" -1227- MOVE 'R0200-00-UPD-BILHETE' TO PARAGRAFO. */
            _.Move("R0200-00-UPD-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1229- MOVE 'UPDATE SEGUROS.BILHETE' TO COMANDO. */
            _.Move("UPDATE SEGUROS.BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1231- MOVE '*' TO BILHETE-SITUACAO. */
            _.Move("*", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -1235- PERFORM R0200_00_UPD_BILHETE_DB_UPDATE_1 */

            R0200_00_UPD_BILHETE_DB_UPDATE_1();

            /*" -1238- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1239- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -1240- DISPLAY '          ERRO UPDATE BILHETE           ' */
                _.Display($"          ERRO UPDATE BILHETE           ");

                /*" -1242- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1243- DISPLAY 'BILHETE : ' BILHETE-NUM-BILHETE */
                _.Display($"BILHETE : {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -1244- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1245- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1245- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-UPD-BILHETE-DB-UPDATE-1 */
        public void R0200_00_UPD_BILHETE_DB_UPDATE_1()
        {
            /*" -1235- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = :BILHETE-SITUACAO WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r0200_00_UPD_BILHETE_DB_UPDATE_1_Update1 = new R0200_00_UPD_BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R0200_00_UPD_BILHETE_DB_UPDATE_1_Update1.Execute(r0200_00_UPD_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0220-00-VERIFICA-CANCEL-SECTION */
        private void R0220_00_VERIFICA_CANCEL_SECTION()
        {
            /*" -1255- MOVE 'R0220-00-VERIFICA-CANCEL' TO PARAGRAFO. */
            _.Move("R0220-00-VERIFICA-CANCEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1261- MOVE 'VERIFICA CANCEL' TO COMANDO. */
            _.Move("VERIFICA CANCEL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1263- MOVE 401 TO R1-SIT-MOTIVO. */
            _.Move(401, REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -1264- IF BILHETE-SIT-SINISTRO EQUAL '1' */

            if (BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO == "1")
            {

                /*" -1265- MOVE 402 TO R1-SIT-MOTIVO */
                _.Move(402, REG_STA_PROPOSTA.R1_SIT_MOTIVO);

                /*" -1267- GO TO R0220-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/ //GOTO
                return;
            }


            /*" -1268- IF BILHETE-SITUACAO EQUAL '7' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "7")
            {

                /*" -1269- MOVE 403 TO R1-SIT-MOTIVO */
                _.Move(403, REG_STA_PROPOSTA.R1_SIT_MOTIVO);

                /*" -1271- GO TO R0220-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/ //GOTO
                return;
            }


            /*" -1273- MOVE ZEROS TO WS-QTDBIL. */
            _.Move(0, WAREA_AUXILIAR.WS_QTDBIL);

            /*" -1280- PERFORM R0220_00_VERIFICA_CANCEL_DB_SELECT_1 */

            R0220_00_VERIFICA_CANCEL_DB_SELECT_1();

            /*" -1283- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1284- DISPLAY 'BI3605B - PROBLEMAS SELECT V1MOVDEBCC_CEF ' */
                _.Display($"BI3605B - PROBLEMAS SELECT V1MOVDEBCC_CEF ");

                /*" -1285- DISPLAY 'APOLICE ' BILHETE-NUM-APOLICE */
                _.Display($"APOLICE {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

                /*" -1286- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1287- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1289- END-IF. */
            }


            /*" -1290- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1297- PERFORM R0220_00_VERIFICA_CANCEL_DB_SELECT_2 */

                R0220_00_VERIFICA_CANCEL_DB_SELECT_2();

                /*" -1300- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1301- DISPLAY 'BI3605B - PROBLEMAS SELECT V1MOVDEBCC_CEF ' */
                    _.Display($"BI3605B - PROBLEMAS SELECT V1MOVDEBCC_CEF ");

                    /*" -1302- DISPLAY 'BILHETE ' BILHETE-NUM-BILHETE */
                    _.Display($"BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -1303- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1304- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1305- END-IF */
                }


                /*" -1307- END-IF. */
            }


            /*" -1308- IF WS-QTDBIL GREATER 2 */

            if (WAREA_AUXILIAR.WS_QTDBIL > 2)
            {

                /*" -1308- MOVE 403 TO R1-SIT-MOTIVO. */
                _.Move(403, REG_STA_PROPOSTA.R1_SIT_MOTIVO);
            }


        }

        [StopWatch]
        /*" R0220-00-VERIFICA-CANCEL-DB-SELECT-1 */
        public void R0220_00_VERIFICA_CANCEL_DB_SELECT_1()
        {
            /*" -1280- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-QTDBIL FROM SEGUROS.V1MOVDEBCC_CEF WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE AND SIT_COBRANCA = '3' WITH UR END-EXEC. */

            var r0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1 = new R0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1.Execute(r0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTDBIL, WAREA_AUXILIAR.WS_QTDBIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/

        [StopWatch]
        /*" R0220-00-VERIFICA-CANCEL-DB-SELECT-2 */
        public void R0220_00_VERIFICA_CANCEL_DB_SELECT_2()
        {
            /*" -1297- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-QTDBIL FROM SEGUROS.V1MOVDEBCC_CEF WHERE NUM_APOLICE = :BILHETE-NUM-BILHETE AND SIT_COBRANCA = '3' WITH UR END-EXEC */

            var r0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1 = new R0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1.Execute(r0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTDBIL, WAREA_AUXILIAR.WS_QTDBIL);
            }


        }

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -1318- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1321- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1323- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", REG_TRAILLER_STA);

            /*" -1326- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -1329- MOVE 'STASCRED' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASCRED", REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -1332- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -1335- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -1338- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -1341- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -1344- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -1347- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -1350- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -1353- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -1356- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -1367- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = REG_TRAILLER_STA.RT_QTDE_TIPO_1 + REG_TRAILLER_STA.RT_QTDE_TIPO_2 + REG_TRAILLER_STA.RT_QTDE_TIPO_3 + REG_TRAILLER_STA.RT_QTDE_TIPO_4 + REG_TRAILLER_STA.RT_QTDE_TIPO_5 + REG_TRAILLER_STA.RT_QTDE_TIPO_6 + REG_TRAILLER_STA.RT_QTDE_TIPO_7 + REG_TRAILLER_STA.RT_QTDE_TIPO_8 + REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -1367- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -1381- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1384- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1387- MOVE 'STASCRED' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASCRED", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -1390- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -1394- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -1398- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -1406- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -1409- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1410- DISPLAY 'BI3605B - FIM ANORMAL' */
                _.Display($"BI3605B - FIM ANORMAL");

                /*" -1411- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -1413- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -1415- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -1417- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -1419- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -1422- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1424- MOVE SPACES TO W-FIM-MOVTO-FIDELIZ */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                /*" -1425- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1425- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -1406- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0870-00-GERAR-TOTAIS-SECTION */
        private void R0870_00_GERAR_TOTAIS_SECTION()
        {
            /*" -1436- MOVE 'R0870-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1439- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1449- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;

            /*" -1450- DISPLAY 'BI3605B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"BI3605B - TOTAIS DO PROCESSAMENTO");

            /*" -1451- DISPLAY '          TOTAL  REGISTROS LIDOS... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS... {WAREA_AUXILIAR.W_NSL}");

            /*" -1452- DISPLAY '          TOTAL  REGISTROS VIDA.... ' W-LIDO-VIDA */
            _.Display($"          TOTAL  REGISTROS VIDA.... {WAREA_AUXILIAR.W_LIDO_VIDA}");

            /*" -1453- DISPLAY '          TOTAL  BILHETE   AP...... ' W-LIDO-BIL-AP */
            _.Display($"          TOTAL  BILHETE   AP...... {WAREA_AUXILIAR.W_LIDO_BIL_AP}");

            /*" -1454- DISPLAY '          TOTAL  BILHETE   RD...... ' W-LIDO-BIL-RD */
            _.Display($"          TOTAL  BILHETE   RD...... {WAREA_AUXILIAR.W_LIDO_BIL_RD}");

            /*" -1455- DISPLAY ' ' */
            _.Display($" ");

            /*" -1456- DISPLAY '          TOTAL  GERADO ARQ. STATUS ' */
            _.Display($"          TOTAL  GERADO ARQ. STATUS ");

            /*" -1458- DISPLAY '          TOTAL  REGISTROS TP-1.... ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -1460- DISPLAY '          TOTAL  REGISTROS TP-2.... ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -1462- DISPLAY '          TOTAL  REGISTROS TP-3.... ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -1464- DISPLAY '          TOTAL  REGISTROS TP-4.... ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -1465- DISPLAY '          TOTAL  REGISTROS GERADOS. ' W-TOT-GERADO-STA. */
            _.Display($"          TOTAL  REGISTROS GERADOS. {WAREA_AUXILIAR.W_TOT_GERADO_STA}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -1473- CLOSE MOVTO-STA. */
            MOVTO_STA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -1480- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1480- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -1483- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -1484- IF SII < 33 */

            if (WS_HORAS.SII < 33)
            {

                /*" -1485- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_14[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -1487- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_14[WS_HORAS.SII]}"
                .Display();

                /*" -1488- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1488- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -1500- DISPLAY ' ' */
            _.Display($" ");

            /*" -1501- IF W-FIM-MOVTO-FIDELIZ = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -1502- DISPLAY 'BI3605B - FIM NORMAL' */
                _.Display($"BI3605B - FIM NORMAL");

                /*" -1504- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1505- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1505- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1509- ELSE */
            }
            else
            {


                /*" -1510- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -1511- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

                /*" -1512- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

                /*" -1513- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -1515- DISPLAY '*** BI3605B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** BI3605B *** ROLLBACK EM ANDAMENTO ...");

                /*" -1517- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -1517- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1521- MOVE 09 TO RETURN-CODE. */
                _.Move(09, RETURN_CODE);
            }


            /*" -1521- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}