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
using Sias.Bilhetes.DB2.BI0094B;

namespace Code
{
    public class BI0094B
    {
        public bool IsCall { get; set; }

        public BI0094B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ BILHETES                            *      */
        /*"      *   PROGRAMA ............... BI0094B                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  08/03/2016                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................. ATENDE CADMUS 96449 E               *      */
        /*"      *                                   CADMUS 123829.               *      */
        /*"      *                                                                *      */
        /*"      *   1) CANCELA BILHETES NAO EMITIDOS QUE NAO RECEBERAM PAGAMENTO *      */
        /*"      *                                                                *      */
        /*"      *      SITUACAO = 'T' - DECLINADO POR DECURSO DE PRAZO           *      */
        /*"      *                                                                *      */
        /*"      *   2) MUDA SITUACAO DE BILHETE QUANDO SUA VIGENCIA ESTA VENCIDA *      */
        /*"      *                                                                *      */
        /*"      *      SITUACAO = 'V' - ENCERRADO POR FIM DE VIGENCIA            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  * VERSAO 11 ..: DEMANDA 538808 - PRODUTOS AP BEM ESTAR NO CCA    *      */
        /*"      *               8533 - AP BEM ESTAR - PU (12 MESES)              *      */
        /*"      *               8534 - AP BEM ESTAR - PU (36 MESES)              *      */
        /*"      *               (ESTES 2 PRODUTOS SAO COPIAS DO 8528 E 8529,     *      */
        /*"      *                APENAS FORAM CRIADOS PARA ATENDER CANAL CCA)    *      */
        /*"      *                                                                *      */
        /*"      * EM 03/09/2024 - CANETTA              PROCURE POR V.11          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.10  *   VERSAO 10   - DEMANDA 575149 - APOIO +FUTURO (3729)          *      */
        /*"      *                                                                *      */
        /*"      *   28/06/2024  - CANETTA               PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *   VERSAO 09 - DEMANDA 538869 - CORRIGIR GRAVACAO DE DATA DE    *      */
        /*"      *               CANCELAMENTO NO UPDATE DA TABELA BILHETE         *      */
        /*"      *                                                                *      */
        /*"      * EM 02/02/2024 - ELIERMES OLIVEIRA    PROCURE POR V.09          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  *   VERSAO 08 - DEMANDA 489284 - PRODUTOS MEI                    *      */
        /*"      *               8530, 8531 E 8532                                *      */
        /*"      *                                                                *      */
        /*"      * EM 27/12/2023 - CANETTA              PROCURE POR V.08          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - DEMANDA 507447                                   *      */
        /*"      *                                                                *      */
        /*"      *   ALTERAR PRAZO DE CANCELAMENTO POR FALTA DE PAGAMENTO DE      *      */
        /*"      *   60 DIAS PARA 15 DIAS.                                        *      */
        /*"      *   DESPREZAR OS BILHETES NAO PASSIVEIS DE CANCELAMENTO QUE      *      */
        /*"      *   POSSUAM AS SITUACOES ABAIXO NO CURSOR V0BILHETE, VISANDO     *      */
        /*"      *   OTIMIZAR O PROCESSAMENTO.                                  *        */
        /*"      *   'X' - BILHETES DO RAMO(0,14,72), NAO PROCESSADOS PELO SIAS   *      */
        /*"      *   '*' - BILHETE NAO RENOVADO                                   *      */
        /*"      *   '6' - DEBITO JA ENVIADO                                      *      */
        /*"      *   '7' - NAO EMITIDO (RESTRICAO CONTA BANCARIA)                 *      */
        /*"      *   'V' - ENCERRADO POR FIM VIGENCIA                             *      */
        /*"      *   '1' - EM CRITICA                                             *      */
        /*"      *                                                                *      */
        /*"      *   SITUACAO 'T' - DECLINIO POR DECURSO DE PRAZO                 *      */
        /*"      *   PASSA A SER  - RECUSADO POR FALTA DE PAGAMENTO DA ADESAO     *      */
        /*"      *                                                                *      */
        /*"      *   SITUACAO '0' - PENDENTE A INTEGRAR                           *      */
        /*"      *   PASSA A SER  - AGUARDANDO PAGAMENTO DO VALOR DE ADESAO       *      */
        /*"      *                                                                *      */
        /*"      *   PASSAR A CANCELAR PROPOSTAS COM AS SITUACOES ABAIXO QUE      *      */
        /*"      *   ESTEJAM ENQUADRADOS NO PRAZO DE 15 DIAS.                     *      */
        /*"      *   SITUACAO '2' =  'FALTA RCAP'                                 *      */
        /*"      *   SITUACAO '3' =  'FALTA RCAP'                                 *      */
        /*"      *   SITUACAO 'L' =  'PENDENTE A INTEGRAR' (SAF)                  *      */
        /*"      *   SITUACAO 'C' =  'PENDENTE A INTEGRAR' (EXTRA REDE)           *      */
        /*"      *   SITUACAO 'E' =  'FALTA RCAP         ' (CRESCER)              *      */
        /*"      *   SITUACAO 'D' =  'PENDENTE A INTEGRAR' (CRESCER)              *      */
        /*"      *   SITUACAO 'F' =  'AGUARDANDO PAGAMENTO                        *      */
        /*"      *   OBS. ESSES CODIGOS DE SITUACAO FORAM UNIFICADOS E            *      */
        /*"      *        SUBSTITUIDOS POR '0'.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/09/2023 - BRICE HO         PROCURE POR V.07            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  *   VERSAO 06 - DEMANDA 323720 - ADICIONAR OS SEGUINTES BILHETES *      */
        /*"      *               PARA ENCERRAMENTO POR FIM DE VIGENCIA:           *      */
        /*"      *               8521 - CAIXA FACIL APOIO FAMILIA ( MENSAL )      *      */
        /*"      *               8528 - BILHETE AP BEM-ESTAR - PU (12 MESES)      *      */
        /*"      *               8529 - BILHETE AP BEM-ESTAR - PU (36 MESES)      *      */
        /*"      *                                                                *      */
        /*"      * EM 26/04/2022 - ELIERMES OLIVEIRA    PROCURE POR V.06          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.05  *    VERSAO 05 - INCIDENTE 349.453                               *      */
        /*"      *           ADICIONAR OS SEGUINTES CODIGOS DE PRODUTOS PARA      *      */
        /*"      *           ENCERRAMENTO POR FIM DE VIGENCIA:                    *      */
        /*"      *             - 3721 - MICROSSEGURO AMPARO        (JV1)          *      */
        /*"      *             - 3716 - MICROSSEGURO APOIO FAMILIA (CVP)          *      */
        /*"      *             - 3725 - MICROSSEGURO APOIO FAMILIA (JV1)          *      */
        /*"      *                                                                *      */
        /*"      *    EM 22/12/2021 - FRANK CARVALHO  PROCURE POR V.05            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.04  *    VERSAO 04 - JAZZ 267731                                     *      */
        /*"      *           EFETUAR O ENCERRAMENTO DE BILHETES DATA DE TERMINO   *      */
        /*"      *           DE VIGENCIA EXPIRADO. SELECAO POR PRODUTO ENDOSSO    *      */
        /*"      *                                                                *      */
        /*"      *    EM 15/01/2021 - CANETTA         PROCURE POR V.04            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *    VERSAO 03 -   IDENTIFICADO PELO JAZZ 232332 QUE BILHETES    *      */
        /*"      *    SEM RECEBIMENTO DE PAGAMENTO E J� SE PASSADOS OS 60 DIAS    *      */
        /*"      *    DA DATA DE QUITA��O N�O FORAM CANCELADOS, CORRE��O REALIZADA       */
        /*"      *    PARA ESSAS SITUA��ES.                                       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/05/2020 - FELIPE TOGAWA                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                    PROCURE POR V.03            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 -   HISTORIA 39684 - ADPTACAO REGRA CADMUS 123829  *      */
        /*"      *                 MELHORIA NA REGRA DE ACUMULO DE RISCO NO SIAS  *      */
        /*"      *                 PARA PRODUTO AMPARO                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/01/2019 - DANIEL MEDINA GOMIDE (MILLENIUM)             *      */
        /*"      *                                                                *      */
        /*"      *   * ADAPTADO PARA EXECUTAR PROCEDIMENTO DE EXPIRACAO (1 ANO)   *      */
        /*"      *     SITUACAO = 'V' - ENCERRADO POR FIM DE VIGENCIA             *      */
        /*"      *                                                                *      */
        /*"      *                                    PROCURE POR V.02            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   ALTERAR A SITUACAO DE 'P' - CANCELADO POR FALTA DE PAGAMENTO *      */
        /*"      *                    PARA 'T' - DECLINADO POR DECURSO DE PRAZO.  *      */
        /*"      *                                                                *      */
        /*"      *   ALTERACAO SOLICIDATA POR DEMANDA DE CONFORMIDADE.            *      */
        /*"      *   A SITUACAO 'P' SERA UTILIZADA PARA BILHETES COM PAGAMENTO    *      */
        /*"      *   MENSAL E QUE FORAM CANCELADOS POR INADIMPLENCIA DE 3 MESES.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2017 - FRANK CARVALHO      PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   VIND-NULL01                PIC S9(004)         COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WSHOST-DATA060             PIC  X(010).*/
        public StringBasis WSHOST_DATA060 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77   WS-FIM-EXPIRADOS           PIC  X(001)   VALUE 'N'.*/
        public StringBasis WS_FIM_EXPIRADOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77   WS-TOTAL-BILHETES          PIC S9(004)         COMP.*/
        public IntBasis WS_TOTAL_BILHETES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   WS-CONT-EXP-CANC           PIC S9(004)         COMP.*/
        public IntBasis WS_CONT_EXP_CANC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   OUT-COD-RETORNO            PIC  9(001).*/
        public IntBasis OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01  W.*/
        public BI0094B_W W { get; set; } = new BI0094B_W();
        public class BI0094B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-APOLICE              PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WTEM-CREDITO              PIC  X(001)         VALUE SPACES*/
            public StringBasis WTEM_CREDITO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WESTA-VENCIDA             PIC  X(001)         VALUE SPACES*/
            public StringBasis WESTA_VENCIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  LD-MOVIMENTO              PIC  9(009)         VALUE ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-APOLICE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_APOLICE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  DP-RCAPS                  PIC  9(009)         VALUE ZEROS.*/
            public IntBasis DP_RCAPS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  NT-BILHETE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  UP-BILHETE                PIC  9(009)         VALUE ZEROS.*/
            public IntBasis UP_BILHETE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI0094B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0094B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0094B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI0094B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(007).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"      10     LD-PARTE2          PIC  9(006).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  03         WS-SQLCODE         PIC  ---9.*/

                public _REDEF_BI0094B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"  03         WS-EXP-PRD-LID     PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_EXP_PRD_LID { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-EXP-PRD-UPD     PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_EXP_PRD_UPD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8144        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8144 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8145        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8145 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8146        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8146 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8147        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8147 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8148        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8148 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8149        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8149 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WS-ENC-8150        PIC S9(009)    VALUE +0 COMP-3.*/
            public IntBasis WS_ENC_8150 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0094B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0094B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0094B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0094B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_BI0094B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI0094B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0094B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0094B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0094B_FILLER_4 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public BI0094B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0094B_WTIME_DAYR();
                public class BI0094B_WTIME_DAYR : VarBasis
                {
                    /*"      10     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      10     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    05       WTIME-2PT3         PIC  X(001).*/

                    public BI0094B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_BI0094B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0094B_WS_TIME WS_TIME { get; set; } = new BI0094B_WS_TIME();
            public class BI0094B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          WABEND.*/
            }
        }
        public BI0094B_WABEND WABEND { get; set; } = new BI0094B_WABEND();
        public class BI0094B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' BI0094B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0094B  ");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();

        public BI0094B_V0BILHETE V0BILHETE { get; set; } = new BI0094B_V0BILHETE(true);
        string GetQuery_V0BILHETE()
        {
            var query = @$"SELECT NUM_BILHETE
							,NUM_APOLICE
							,OPC_COBERTURA
							,DATA_QUITACAO
							,VAL_RCAP
							,RAMO
							,SITUACAO
							,TIP_CANCELAMENTO
							,DATA_CANCELAMENTO
							FROM SEGUROS.BILHETE WHERE SITUACAO NOT IN ('T'
							,'P'
							,'8'
							,'9'
							,'R'
							, 'X'
							,'*'
							,'6'
							,'7'
							,'V'
							,'1') AND DATA_QUITACAO < '{WSHOST_DATA060}'";

            return query;
        }


        public BI0094B_C2_EXPIRADOS C2_EXPIRADOS { get; set; } = new BI0094B_C2_EXPIRADOS(false);
        string GetQuery_C2_EXPIRADOS()
        {
            var query = @$"SELECT B.NUM_BILHETE
							,B.NUM_APOLICE
							FROM SEGUROS.CONVERSAO_SICOB A
							, SEGUROS.BILHETE B
							, SEGUROS.ENDOSSOS D WHERE B.SITUACAO = '9' AND B.NUM_BILHETE = A.NUM_SICOB AND A.COD_PRODUTO_SIVPF IN (3701
							, 8105
							, 3721
							, 3716
							, 3725
							, 8521
							, 8528
							, 8529
							, 8530
							, 8531
							, 8532
							, 8533
							, 8534
							, 3709
							, 3729) AND D.NUM_APOLICE = B.NUM_APOLICE AND D.NUM_ENDOSSO = 0 AND D.DATA_TERVIGENCIA < CURRENT DATE";

            return query;
        }


        public BI0094B_C3_EXP_PRD C3_EXP_PRD { get; set; } = new BI0094B_C3_EXP_PRD(false);
        string GetQuery_C3_EXP_PRD()
        {
            var query = @$"SELECT B.NUM_BILHETE
							,E.COD_PRODUTO
							FROM SEGUROS.BILHETE B
							, SEGUROS.ENDOSSOS E WHERE B.SITUACAO = '9' AND E.NUM_APOLICE = B.NUM_APOLICE AND E.NUM_ENDOSSO = 0 AND E.COD_PRODUTO IN (8144
							, 8145
							, 8146
							, 8147
							, 8148
							, 8149
							, 8150) AND E.DATA_TERVIGENCIA < CURRENT DATE";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            V0BILHETE.GetQueryEvent += GetQuery_V0BILHETE;
            C2_EXPIRADOS.GetQueryEvent += GetQuery_C2_EXPIRADOS;
            C3_EXP_PRD.GetQueryEvent += GetQuery_C3_EXP_PRD;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -353- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -354- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -356- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -358- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -361- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -362- DISPLAY ' PROGRAMA EM EXECUCAO BI0094B     ' . */
            _.Display($" PROGRAMA EM EXECUCAO BI0094B     ");

            /*" -363- DISPLAY '                                  ' . */
            _.Display($"                                  ");

            /*" -368- DISPLAY ' VERSAO V.11 - DEMANDA 588808 ' . */
            _.Display($" VERSAO V.11 - DEMANDA 588808 ");

            /*" -369- DISPLAY ' COMPILACAO  - ' FUNCTION WHEN-COMPILED */

            $" COMPILACAO  - FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -371- DISPLAY '----------------------------------' . */
            _.Display($"----------------------------------");

            /*" -373- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -375- PERFORM R0200-00-SELECIONA-BILHETE. */

            R0200_00_SELECIONA_BILHETE_SECTION();

            /*" -376- DISPLAY ' ' */
            _.Display($" ");

            /*" -377- DISPLAY '---------* 3A PARTE (ENCERRAR) *-------------' */
            _.Display($"---------* 3A PARTE (ENCERRAR) *-------------");

            /*" -377- PERFORM R0400-00-ENCERRA-EXPI-PROD. */

            R0400_00_ENCERRA_EXPI_PROD_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -382- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -386- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -387- DISPLAY ' ' . */
            _.Display($" ");

            /*" -388- DISPLAY 'BI0094B - FIM NORMAL' . */
            _.Display($"BI0094B - FIM NORMAL");

            /*" -390- DISPLAY ' ' . */
            _.Display($" ");

            /*" -390- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -397- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WABEND.WNR_EXEC_SQL);

            /*" -399- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -399- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -410- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -418- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -421- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -422- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -424- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -425- DISPLAY ' ' . */
            _.Display($" ");

            /*" -427- DISPLAY 'DATA SISTEMA BI ................ ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA SISTEMA BI ................ {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -429- DISPLAY 'BILHETES COM DATA PAGTO ATE .... ' WSHOST-DATA060. */
            _.Display($"BILHETES COM DATA PAGTO ATE .... {WSHOST_DATA060}");

            /*" -429- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -418- EXEC SQL SELECT DATA_MOV_ABERTO ,(DATA_MOV_ABERTO - 15 DAYS) INTO :SISTEMAS-DATA-MOV-ABERTO ,:WSHOST-DATA060 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WSHOST_DATA060, WSHOST_DATA060);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECIONA-BILHETE-SECTION */
        private void R0200_00_SELECIONA_BILHETE_SECTION()
        {
            /*" -439- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -440- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -441- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -442- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -443- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -444- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -448- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -450- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -452- PERFORM R0210-00-OPEN-DECLINA. */

            R0210_00_OPEN_DECLINA_SECTION();

            /*" -454- PERFORM R0220-00-FETCH-DECLINA. */

            R0220_00_FETCH_DECLINA_SECTION();

            /*" -460- PERFORM R0250-00-PROCESSA-BILHETE UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0250_00_PROCESSA_BILHETE_SECTION();
            }

            /*" -462- PERFORM R0200_00_SELECIONA_BILHETE_DB_OPEN_1 */

            R0200_00_SELECIONA_BILHETE_DB_OPEN_1();

            /*" -465- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -466- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -467- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -468- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -469- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -471- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -472- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -473- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -475- DISPLAY 'R5105-00 - PROBLEMAS NO OPEN DO C2_EXPIRADOS' ' ' WSQLCODE */

                $"R5105-00 - PROBLEMAS NO OPEN DO C2_EXPIRADOS {WABEND.WSQLCODE}"
                .Display();

                /*" -476- MOVE 1 TO OUT-COD-RETORNO */
                _.Move(1, OUT_COD_RETORNO);

                /*" -477- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -478- ELSE */
            }
            else
            {


                /*" -479- PERFORM R5120-00-FETCH-EXPIRADOS */

                R5120_00_FETCH_EXPIRADOS_SECTION();

                /*" -481- IF WS-FIM-EXPIRADOS = 'S' */

                if (WS_FIM_EXPIRADOS == "S")
                {

                    /*" -482- MOVE ZEROS TO OUT-COD-RETORNO */
                    _.Move(0, OUT_COD_RETORNO);

                    /*" -484- ELSE */
                }
                else
                {


                    /*" -485- IF SQLCODE = 0 */

                    if (DB.SQLCODE == 0)
                    {

                        /*" -486- IF OUT-COD-RETORNO NOT EQUAL ZEROS */

                        if (OUT_COD_RETORNO != 00)
                        {

                            /*" -487- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -488- ELSE */
                        }
                        else
                        {


                            /*" -490- MOVE 'N' TO WS-FIM-EXPIRADOS */
                            _.Move("N", WS_FIM_EXPIRADOS);

                            /*" -494- PERFORM R5115-00-CANCELA-EXPIRADOS UNTIL WS-FIM-EXPIRADOS = 'S' OR OUT-COD-RETORNO NOT EQUAL ZEROS */

                            while (!(WS_FIM_EXPIRADOS == "S" || OUT_COD_RETORNO != 00))
                            {

                                R5115_00_CANCELA_EXPIRADOS_SECTION();
                            }

                            /*" -495- END-IF */
                        }


                        /*" -497- END-IF. */
                    }

                }

            }


            /*" -498- IF OUT-COD-RETORNO = 1 */

            if (OUT_COD_RETORNO == 1)
            {

                /*" -499- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -501- END-IF */
            }


            /*" -502- DISPLAY '---------* RESUMO DO PROCESSAMENTO *---------' */
            _.Display($"---------* RESUMO DO PROCESSAMENTO *---------");

            /*" -503- DISPLAY ' ' . */
            _.Display($" ");

            /*" -504- DISPLAY '---------* 1A PARTE (DECLINAR) *-------------' */
            _.Display($"---------* 1A PARTE (DECLINAR) *-------------");

            /*" -505- DISPLAY '  BILHETES A DECLINAR LIDOS.. ' LD-MOVIMENTO */
            _.Display($"  BILHETES A DECLINAR LIDOS.. {W.LD_MOVIMENTO}");

            /*" -506- DISPLAY ' ' . */
            _.Display($" ");

            /*" -507- DISPLAY '  APOLICES EMITIDA .......... ' DP-APOLICE */
            _.Display($"  APOLICES EMITIDA .......... {W.DP_APOLICE}");

            /*" -508- DISPLAY ' ' . */
            _.Display($" ");

            /*" -509- DISPLAY '  PROPOSTAS COM CREDITO ..... ' DP-RCAPS */
            _.Display($"  PROPOSTAS COM CREDITO ..... {W.DP_RCAPS}");

            /*" -510- DISPLAY ' ' . */
            _.Display($" ");

            /*" -511- DISPLAY '  BILHETES DECLINADOS ....... ' UP-BILHETE */
            _.Display($"  BILHETES DECLINADOS ....... {W.UP_BILHETE}");

            /*" -512- DISPLAY ' ' . */
            _.Display($" ");

            /*" -513- DISPLAY '---------* 2A PARTE (EXPIRAR)  *-------------' */
            _.Display($"---------* 2A PARTE (EXPIRAR)  *-------------");

            /*" -514- DISPLAY '  BILHETES A EXPIRAR  LIDOS.. ' WS-TOTAL-BILHETES */
            _.Display($"  BILHETES A EXPIRAR  LIDOS.. {WS_TOTAL_BILHETES}");

            /*" -515- DISPLAY ' ' . */
            _.Display($" ");

            /*" -516- DISPLAY '  BILHETES EXPIRADOS......... ' WS-CONT-EXP-CANC */
            _.Display($"  BILHETES EXPIRADOS......... {WS_CONT_EXP_CANC}");

            /*" -517- DISPLAY ' ' . */
            _.Display($" ");

            /*" -518- DISPLAY '  BILHETE COM FALHA UPDATE... ' NT-BILHETE */
            _.Display($"  BILHETE COM FALHA UPDATE... {W.NT_BILHETE}");

            /*" -520- DISPLAY ' ' . */
            _.Display($" ");

            /*" -522- PERFORM R0200_00_SELECIONA_BILHETE_DB_CLOSE_1 */

            R0200_00_SELECIONA_BILHETE_DB_CLOSE_1();

            /*" -524- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }

        [StopWatch]
        /*" R0200-00-SELECIONA-BILHETE-DB-OPEN-1 */
        public void R0200_00_SELECIONA_BILHETE_DB_OPEN_1()
        {
            /*" -462- EXEC SQL OPEN C2_EXPIRADOS END-EXEC */

            C2_EXPIRADOS.Open();
            Result = C2_EXPIRADOS.AllData;

        }

        [StopWatch]
        /*" R0200-00-SELECIONA-BILHETE-DB-CLOSE-1 */
        public void R0200_00_SELECIONA_BILHETE_DB_CLOSE_1()
        {
            /*" -522- EXEC SQL CLOSE C2_EXPIRADOS END-EXEC */

            C2_EXPIRADOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-OPEN-DECLINA-SECTION */
        private void R0210_00_OPEN_DECLINA_SECTION()
        {
            /*" -535- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -536- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), W.WS_TIME);

            /*" -537- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -538- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -539- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -540- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -541- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -541- PERFORM R0210_00_OPEN_DECLINA_DB_OPEN_1 */

            R0210_00_OPEN_DECLINA_DB_OPEN_1();

            /*" -546- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -547- DISPLAY 'R0210-00 - PROBLEMAS OPEN (V0BILHETE)    ' */
                _.Display($"R0210-00 - PROBLEMAS OPEN (V0BILHETE)    ");

                /*" -547- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-OPEN-DECLINA-DB-OPEN-1 */
        public void R0210_00_OPEN_DECLINA_DB_OPEN_1()
        {
            /*" -541- EXEC SQL OPEN V0BILHETE END-EXEC. */

            V0BILHETE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-FETCH-DECLINA-SECTION */
        private void R0220_00_FETCH_DECLINA_SECTION()
        {
            /*" -558- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WABEND.WNR_EXEC_SQL);

            /*" -568- PERFORM R0220_00_FETCH_DECLINA_DB_FETCH_1 */

            R0220_00_FETCH_DECLINA_DB_FETCH_1();

            /*" -571- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -571- PERFORM R0220_00_FETCH_DECLINA_DB_CLOSE_1 */

                R0220_00_FETCH_DECLINA_DB_CLOSE_1();

                /*" -573- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -575- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -576- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -577- DISPLAY 'R0220-00 - PROBLEMAS FETCH  (V0BILHETE)    ' */
                _.Display($"R0220-00 - PROBLEMAS FETCH  (V0BILHETE)    ");

                /*" -580- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -581- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -585- MOVE SISTEMAS-DATA-MOV-ABERTO TO BILHETE-DATA-CANCELAMENTO. */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
            }


            /*" -587- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

            /*" -589- MOVE LD-MOVIMENTO TO AC-LIDOS. */
            _.Move(W.LD_MOVIMENTO, W.AC_LIDOS);

            /*" -591- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 100000 */

            if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 100000)
            {

                /*" -592- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                /*" -593- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -594- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -595- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -596- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -597- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -599- DISPLAY 'BILHETES LIDOS     ' AC-LIDOS '    ' WTIME-DAYR */

                $"BILHETES LIDOS     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                .Display();

                /*" -600- MOVE ZEROS TO AC-LIDOS. */
                _.Move(0, W.AC_LIDOS);
            }


            /*" -600- ADD 1 TO LD-PARTE2. */
            W.FILLER_0.LD_PARTE2.Value = W.FILLER_0.LD_PARTE2 + 1;

        }

        [StopWatch]
        /*" R0220-00-FETCH-DECLINA-DB-FETCH-1 */
        public void R0220_00_FETCH_DECLINA_DB_FETCH_1()
        {
            /*" -568- EXEC SQL FETCH V0BILHETE INTO :BILHETE-NUM-BILHETE ,:BILHETE-NUM-APOLICE ,:BILHETE-OPC-COBERTURA ,:BILHETE-DATA-QUITACAO ,:BILHETE-VAL-RCAP ,:BILHETE-RAMO ,:BILHETE-SITUACAO ,:BILHETE-TIP-CANCELAMENTO ,:BILHETE-DATA-CANCELAMENTO:VIND-NULL01 END-EXEC. */

            if (V0BILHETE.Fetch())
            {
                _.Move(V0BILHETE.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(V0BILHETE.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(V0BILHETE.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(V0BILHETE.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(V0BILHETE.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(V0BILHETE.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(V0BILHETE.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(V0BILHETE.BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(V0BILHETE.BILHETE_DATA_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);
                _.Move(V0BILHETE.VIND_NULL01, VIND_NULL01);
            }

        }

        [StopWatch]
        /*" R0220-00-FETCH-DECLINA-DB-CLOSE-1 */
        public void R0220_00_FETCH_DECLINA_DB_CLOSE_1()
        {
            /*" -571- EXEC SQL CLOSE V0BILHETE END-EXEC */

            V0BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-PROCESSA-BILHETE-SECTION */
        private void R0250_00_PROCESSA_BILHETE_SECTION()
        {
            /*" -614- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -615- MOVE SPACES TO WTEM-APOLICE. */
            _.Move("", W.WTEM_APOLICE);

            /*" -618- MOVE BILHETE-NUM-BILHETE TO APOLICES-NUM-BILHETE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE);

            /*" -620- PERFORM R0260-00-SELECT-V0APOLICES. */

            R0260_00_SELECT_V0APOLICES_SECTION();

            /*" -621- IF WTEM-APOLICE EQUAL 'S' */

            if (W.WTEM_APOLICE == "S")
            {

                /*" -622- ADD 1 TO DP-APOLICE */
                W.DP_APOLICE.Value = W.DP_APOLICE + 1;

                /*" -628- GO TO R0250-90-LEITURA. */

                R0250_90_LEITURA(); //GOTO
                return;
            }


            /*" -629- MOVE SPACES TO WTEM-CREDITO. */
            _.Move("", W.WTEM_CREDITO);

            /*" -632- MOVE BILHETE-NUM-BILHETE TO RCAPS-NUM-TITULO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -634- PERFORM R0270-00-SELECT-V0RCAPS. */

            R0270_00_SELECT_V0RCAPS_SECTION();

            /*" -635- IF WTEM-CREDITO EQUAL 'S' */

            if (W.WTEM_CREDITO == "S")
            {

                /*" -636- ADD 1 TO DP-RCAPS */
                W.DP_RCAPS.Value = W.DP_RCAPS + 1;

                /*" -643- GO TO R0250-90-LEITURA. */

                R0250_90_LEITURA(); //GOTO
                return;
            }


            /*" -645- MOVE 'T' TO BILHETE-SITUACAO. */
            _.Move("T", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -647- MOVE '0' TO BILHETE-TIP-CANCELAMENTO. */
            _.Move("0", BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);

            /*" -648- ADD 1 TO UP-BILHETE. */
            W.UP_BILHETE.Value = W.UP_BILHETE + 1;

            /*" -649- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -649- PERFORM R2000-00-UPDATE-V0BILHETE. */

            R2000_00_UPDATE_V0BILHETE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0250_90_LEITURA */

            R0250_90_LEITURA();

        }

        [StopWatch]
        /*" R0250-90-LEITURA */
        private void R0250_90_LEITURA(bool isPerform = false)
        {
            /*" -654- PERFORM R0220-00-FETCH-DECLINA. */

            R0220_00_FETCH_DECLINA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-SELECT-V0APOLICES-SECTION */
        private void R0260_00_SELECT_V0APOLICES_SECTION()
        {
            /*" -665- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WABEND.WNR_EXEC_SQL);

            /*" -672- PERFORM R0260_00_SELECT_V0APOLICES_DB_SELECT_1 */

            R0260_00_SELECT_V0APOLICES_DB_SELECT_1();

            /*" -676- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -677- MOVE 'N' TO WTEM-APOLICE */
                _.Move("N", W.WTEM_APOLICE);

                /*" -678- ELSE */
            }
            else
            {


                /*" -679- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -680- DISPLAY 'R0260-00 - PROBLEMAS NO SELECT(APOLICES)' */
                    _.Display($"R0260-00 - PROBLEMAS NO SELECT(APOLICES)");

                    /*" -681- DISPLAY 'BILHETE = ' APOLICES-NUM-BILHETE */
                    _.Display($"BILHETE = {APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE}");

                    /*" -682- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -683- ELSE */
                }
                else
                {


                    /*" -683- MOVE 'S' TO WTEM-APOLICE. */
                    _.Move("S", W.WTEM_APOLICE);
                }

            }


        }

        [StopWatch]
        /*" R0260-00-SELECT-V0APOLICES-DB-SELECT-1 */
        public void R0260_00_SELECT_V0APOLICES_DB_SELECT_1()
        {
            /*" -672- EXEC SQL SELECT NUM_APOLICE INTO :APOLICES-NUM-APOLICE FROM SEGUROS.APOLICES WHERE NUM_BILHETE = :APOLICES-NUM-BILHETE FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1 = new R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_BILHETE = APOLICES.DCLAPOLICES.APOLICES_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1.Execute(r0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0270-00-SELECT-V0RCAPS-SECTION */
        private void R0270_00_SELECT_V0RCAPS_SECTION()
        {
            /*" -694- MOVE '0270' TO WNR-EXEC-SQL. */
            _.Move("0270", WABEND.WNR_EXEC_SQL);

            /*" -704- PERFORM R0270_00_SELECT_V0RCAPS_DB_SELECT_1 */

            R0270_00_SELECT_V0RCAPS_DB_SELECT_1();

            /*" -708- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -709- MOVE 'N' TO WTEM-CREDITO */
                _.Move("N", W.WTEM_CREDITO);

                /*" -710- ELSE */
            }
            else
            {


                /*" -711- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -712- DISPLAY 'R0270-00 - PROBLEMAS NO SELECT(RCAPS)   ' */
                    _.Display($"R0270-00 - PROBLEMAS NO SELECT(RCAPS)   ");

                    /*" -713- DISPLAY 'NUM-TITULO = ' RCAPS-NUM-TITULO */
                    _.Display($"NUM-TITULO = {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -714- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -715- ELSE */
                }
                else
                {


                    /*" -715- MOVE 'S' TO WTEM-CREDITO. */
                    _.Move("S", W.WTEM_CREDITO);
                }

            }


        }

        [StopWatch]
        /*" R0270-00-SELECT-V0RCAPS-DB-SELECT-1 */
        public void R0270_00_SELECT_V0RCAPS_DB_SELECT_1()
        {
            /*" -704- EXEC SQL SELECT SIT_REGISTRO ,COD_OPERACAO INTO :RCAPS-SIT-REGISTRO ,:RCAPS-COD-OPERACAO FROM SEGUROS.RCAPS WHERE NUM_TITULO = :RCAPS-NUM-TITULO AND SIT_REGISTRO = '0' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 = new R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1.Execute(r0270_00_SELECT_V0RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-V0BILHETE-SECTION */
        private void R2000_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -726- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -735- PERFORM R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -739- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -740- ADD 1 TO NT-BILHETE */
                W.NT_BILHETE.Value = W.NT_BILHETE + 1;

                /*" -741- ELSE */
            }
            else
            {


                /*" -742- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -743- DISPLAY 'R2000-00 - PROBLEMAS UPDATE (BILHETE)   ' */
                    _.Display($"R2000-00 - PROBLEMAS UPDATE (BILHETE)   ");

                    /*" -744- DISPLAY 'NUM-BILHETE = ' BILHETE-NUM-BILHETE */
                    _.Display($"NUM-BILHETE = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -744- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -735- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = :BILHETE-SITUACAO ,TIP_CANCELAMENTO = :BILHETE-TIP-CANCELAMENTO ,COD_USUARIO = 'BI0094B' ,DATA_CANCELAMENTO = :BILHETE-DATA-CANCELAMENTO:VIND-NULL01 ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC. */

            var r2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_DATA_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                BILHETE_TIP_CANCELAMENTO = BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO.ToString(),
                BILHETE_SITUACAO = BILHETE.DCLBILHETE.BILHETE_SITUACAO.ToString(),
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R5115-00-CANCELA-EXPIRADOS-SECTION */
        private void R5115_00_CANCELA_EXPIRADOS_SECTION()
        {
            /*" -755- MOVE '5115' TO WNR-EXEC-SQL */
            _.Move("5115", WABEND.WNR_EXEC_SQL);

            /*" -758- MOVE 'V' TO BILHETE-SITUACAO */
            _.Move("V", BILHETE.DCLBILHETE.BILHETE_SITUACAO);

            /*" -761- MOVE '4' TO BILHETE-TIP-CANCELAMENTO */
            _.Move("4", BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);

            /*" -762- MOVE SISTEMAS-DATA-MOV-ABERTO TO BILHETE-DATA-CANCELAMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, BILHETE.DCLBILHETE.BILHETE_DATA_CANCELAMENTO);

            /*" -764- MOVE ZEROS TO VIND-NULL01 */
            _.Move(0, VIND_NULL01);

            /*" -766- PERFORM R2000-00-UPDATE-V0BILHETE */

            R2000_00_UPDATE_V0BILHETE_SECTION();

            /*" -769- ADD 1 TO WS-CONT-EXP-CANC LD-PARTE2 */
            WS_CONT_EXP_CANC.Value = WS_CONT_EXP_CANC + 1;
            W.FILLER_0.LD_PARTE2.Value = W.FILLER_0.LD_PARTE2 + 1;

            /*" -770- PERFORM R5120-00-FETCH-EXPIRADOS */

            R5120_00_FETCH_EXPIRADOS_SECTION();

            /*" -770- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5115_99_SAIDA*/

        [StopWatch]
        /*" R5120-00-FETCH-EXPIRADOS-SECTION */
        private void R5120_00_FETCH_EXPIRADOS_SECTION()
        {
            /*" -780- MOVE '5120' TO WNR-EXEC-SQL */
            _.Move("5120", WABEND.WNR_EXEC_SQL);

            /*" -784- PERFORM R5120_00_FETCH_EXPIRADOS_DB_FETCH_1 */

            R5120_00_FETCH_EXPIRADOS_DB_FETCH_1();

            /*" -787- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -788- MOVE ZEROS TO OUT-COD-RETORNO */
                _.Move(0, OUT_COD_RETORNO);

                /*" -789- MOVE 'S' TO WS-FIM-EXPIRADOS */
                _.Move("S", WS_FIM_EXPIRADOS);

                /*" -790- GO TO R5120-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5120_99_SAIDA*/ //GOTO
                return;

                /*" -791- ELSE */
            }
            else
            {


                /*" -792- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -793- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                    /*" -795- DISPLAY 'R5110 - PROBLEMAS NO FETCH C2_EXPIRADOS' ' ' WSQLCODE */

                    $"R5110 - PROBLEMAS NO FETCH C2_EXPIRADOS {WABEND.WSQLCODE}"
                    .Display();

                    /*" -796- MOVE 1 TO OUT-COD-RETORNO */
                    _.Move(1, OUT_COD_RETORNO);

                    /*" -797- GO TO R5120-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5120_99_SAIDA*/ //GOTO
                    return;

                    /*" -798- ELSE */
                }
                else
                {


                    /*" -800- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 100000 */

                    if (W.FILLER_0.LD_PARTE2 == 00 || W.FILLER_0.LD_PARTE2 == 100000)
                    {

                        /*" -801- ACCEPT WS-TIME FROM TIME */
                        _.Move(_.AcceptDate("TIME"), W.WS_TIME);

                        /*" -802- MOVE WS-HH-TIME TO WTIME-HORA */
                        _.Move(W.WS_TIME.WS_HH_TIME, W.FILLER_4.WTIME_DAYR.WTIME_HORA);

                        /*" -803- MOVE '.' TO WTIME-2PT1 */
                        _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                        /*" -804- MOVE WS-MM-TIME TO WTIME-MINU */
                        _.Move(W.WS_TIME.WS_MM_TIME, W.FILLER_4.WTIME_DAYR.WTIME_MINU);

                        /*" -805- MOVE '.' TO WTIME-2PT2 */
                        _.Move(".", W.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                        /*" -806- MOVE WS-SS-TIME TO WTIME-SEGU */
                        _.Move(W.WS_TIME.WS_SS_TIME, W.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                        /*" -808- DISPLAY 'BILHETES LIDOS     ' AC-LIDOS '    ' WTIME-DAYR */

                        $"BILHETES LIDOS     {W.AC_LIDOS}    {W.FILLER_4.WTIME_DAYR}"
                        .Display();

                        /*" -809- MOVE 0 TO AC-LIDOS */
                        _.Move(0, W.AC_LIDOS);

                        /*" -810- END-IF */
                    }


                    /*" -811- END-IF */
                }


                /*" -812- END-IF */
            }


            /*" -813- ADD 1 TO LD-PARTE2 */
            W.FILLER_0.LD_PARTE2.Value = W.FILLER_0.LD_PARTE2 + 1;

            /*" -814- ADD 1 TO WS-TOTAL-BILHETES */
            WS_TOTAL_BILHETES.Value = WS_TOTAL_BILHETES + 1;

            /*" -814- . */

        }

        [StopWatch]
        /*" R5120-00-FETCH-EXPIRADOS-DB-FETCH-1 */
        public void R5120_00_FETCH_EXPIRADOS_DB_FETCH_1()
        {
            /*" -784- EXEC SQL FETCH C2_EXPIRADOS INTO :BILHETE-NUM-BILHETE , :BILHETE-NUM-APOLICE END-EXEC */

            if (C2_EXPIRADOS.Fetch())
            {
                _.Move(C2_EXPIRADOS.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(C2_EXPIRADOS.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5120_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-ENCERRA-EXPI-PROD-SECTION */
        private void R0400_00_ENCERRA_EXPI_PROD_SECTION()
        {
            /*" -825- MOVE '0400' TO WNR-EXEC-SQL */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -825- PERFORM R0400_00_ENCERRA_EXPI_PROD_DB_OPEN_1 */

            R0400_00_ENCERRA_EXPI_PROD_DB_OPEN_1();

            /*" -828- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -829- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, W.WS_SQLCODE);

                /*" -830- DISPLAY '***' */
                _.Display($"***");

                /*" -831- DISPLAY ' R0400-00-ENCERRA-EXPI-PROD' */
                _.Display($" R0400-00-ENCERRA-EXPI-PROD");

                /*" -832- DISPLAY ' ERRO OPEN CURSOR C3_EXP_PRD (' WS-SQLCODE ')' */

                $" ERRO OPEN CURSOR C3_EXP_PRD ({W.WS_SQLCODE})"
                .Display();

                /*" -833- DISPLAY '***' */
                _.Display($"***");

                /*" -834- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -837- END-IF */
            }


            /*" -841- PERFORM R0410-00-TRATA-EXPI-PROD UNTIL SQLCODE NOT EQUAL ZEROS */

            while (!(DB.SQLCODE != 00))
            {

                R0410_00_TRATA_EXPI_PROD_SECTION();
            }

            /*" -841- PERFORM R0400_00_ENCERRA_EXPI_PROD_DB_CLOSE_1 */

            R0400_00_ENCERRA_EXPI_PROD_DB_CLOSE_1();

            /*" -844- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -845- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, W.WS_SQLCODE);

                /*" -846- DISPLAY '***' */
                _.Display($"***");

                /*" -847- DISPLAY ' R0400-00-ENCERRA-EXPI-PROD' */
                _.Display($" R0400-00-ENCERRA-EXPI-PROD");

                /*" -848- DISPLAY ' ERRO CLO CURSOR C3_EXP_PRD (' WS-SQLCODE ')' */

                $" ERRO CLO CURSOR C3_EXP_PRD ({W.WS_SQLCODE})"
                .Display();

                /*" -849- DISPLAY '***' */
                _.Display($"***");

                /*" -850- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -852- END-IF */
            }


            /*" -853- DISPLAY '  BILHETES LIDOS ............ ' WS-EXP-PRD-LID */
            _.Display($"  BILHETES LIDOS ............ {W.WS_EXP_PRD_LID}");

            /*" -854- DISPLAY '  BILHETES ALTERADOS ........ ' WS-EXP-PRD-UPD */
            _.Display($"  BILHETES ALTERADOS ........ {W.WS_EXP_PRD_UPD}");

            /*" -855- DISPLAY '  BILHETES 8144 ENCERRADOS .. ' WS-ENC-8144 */
            _.Display($"  BILHETES 8144 ENCERRADOS .. {W.WS_ENC_8144}");

            /*" -856- DISPLAY '  BILHETES 8145 ENCERRADOS .. ' WS-ENC-8145 */
            _.Display($"  BILHETES 8145 ENCERRADOS .. {W.WS_ENC_8145}");

            /*" -857- DISPLAY '  BILHETES 8146 ENCERRADOS .. ' WS-ENC-8146 */
            _.Display($"  BILHETES 8146 ENCERRADOS .. {W.WS_ENC_8146}");

            /*" -858- DISPLAY '  BILHETES 8147 ENCERRADOS .. ' WS-ENC-8147 */
            _.Display($"  BILHETES 8147 ENCERRADOS .. {W.WS_ENC_8147}");

            /*" -859- DISPLAY '  BILHETES 8148 ENCERRADOS .. ' WS-ENC-8148 */
            _.Display($"  BILHETES 8148 ENCERRADOS .. {W.WS_ENC_8148}");

            /*" -860- DISPLAY '  BILHETES 8149 ENCERRADOS .. ' WS-ENC-8149 */
            _.Display($"  BILHETES 8149 ENCERRADOS .. {W.WS_ENC_8149}");

            /*" -861- DISPLAY '  BILHETES 8150 ENCERRADOS .. ' WS-ENC-8150 */
            _.Display($"  BILHETES 8150 ENCERRADOS .. {W.WS_ENC_8150}");

            /*" -863- DISPLAY '-----------------------------------------' */
            _.Display($"-----------------------------------------");

            /*" -863- . */

        }

        [StopWatch]
        /*" R0400-00-ENCERRA-EXPI-PROD-DB-OPEN-1 */
        public void R0400_00_ENCERRA_EXPI_PROD_DB_OPEN_1()
        {
            /*" -825- EXEC SQL OPEN C3_EXP_PRD END-EXEC */

            C3_EXP_PRD.Open();
            Result = C3_EXP_PRD.AllData;

        }

        [StopWatch]
        /*" R0400-00-ENCERRA-EXPI-PROD-DB-CLOSE-1 */
        public void R0400_00_ENCERRA_EXPI_PROD_DB_CLOSE_1()
        {
            /*" -841- EXEC SQL CLOSE C3_EXP_PRD END-EXEC */

            C3_EXP_PRD.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-TRATA-EXPI-PROD-SECTION */
        private void R0410_00_TRATA_EXPI_PROD_SECTION()
        {
            /*" -873- MOVE '0410' TO WNR-EXEC-SQL */
            _.Move("0410", WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM R0410_00_TRATA_EXPI_PROD_DB_FETCH_1 */

            R0410_00_TRATA_EXPI_PROD_DB_FETCH_1();

            /*" -879- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -880- ADD 001 TO WS-EXP-PRD-LID */
                W.WS_EXP_PRD_LID.Value = W.WS_EXP_PRD_LID + 001;

                /*" -881- ELSE */
            }
            else
            {


                /*" -882- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -883- GO TO R0410-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                    return;

                    /*" -884- ELSE */
                }
                else
                {


                    /*" -885- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, W.WS_SQLCODE);

                    /*" -886- DISPLAY '***' */
                    _.Display($"***");

                    /*" -887- DISPLAY ' R0410-00-TRATA-EXPI-PROD' */
                    _.Display($" R0410-00-TRATA-EXPI-PROD");

                    /*" -888- DISPLAY ' ERRO FETCH C3_EXP_PRD (' WS-SQLCODE ')' */

                    $" ERRO FETCH C3_EXP_PRD ({W.WS_SQLCODE})"
                    .Display();

                    /*" -889- DISPLAY '***' */
                    _.Display($"***");

                    /*" -890- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -891- END-IF */
                }


                /*" -894- END-IF */
            }


            /*" -902- PERFORM R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1 */

            R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1();

            /*" -905- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -906- ADD 001 TO WS-EXP-PRD-UPD */
                W.WS_EXP_PRD_UPD.Value = W.WS_EXP_PRD_UPD + 001;

                /*" -907- ELSE */
            }
            else
            {


                /*" -908- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, W.WS_SQLCODE);

                /*" -909- DISPLAY '***' */
                _.Display($"***");

                /*" -910- DISPLAY ' R0410-00-TRATA-EXPI-PROD' */
                _.Display($" R0410-00-TRATA-EXPI-PROD");

                /*" -911- DISPLAY ' ERRO UPD C3_EXP_PRD (' WS-SQLCODE ')' */

                $" ERRO UPD C3_EXP_PRD ({W.WS_SQLCODE})"
                .Display();

                /*" -912- DISPLAY ' BILHETE: ' BILHETE-NUM-BILHETE */
                _.Display($" BILHETE: {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -913- DISPLAY '***' */
                _.Display($"***");

                /*" -914- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -917- END-IF */
            }


            /*" -918- IF ENDOSSOS-COD-PRODUTO EQUAL 8144 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8144)
            {

                /*" -919- ADD 001 TO WS-ENC-8144 */
                W.WS_ENC_8144.Value = W.WS_ENC_8144 + 001;

                /*" -920- END-IF */
            }


            /*" -921- IF ENDOSSOS-COD-PRODUTO EQUAL 8145 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8145)
            {

                /*" -922- ADD 001 TO WS-ENC-8145 */
                W.WS_ENC_8145.Value = W.WS_ENC_8145 + 001;

                /*" -923- END-IF */
            }


            /*" -924- IF ENDOSSOS-COD-PRODUTO EQUAL 8146 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8146)
            {

                /*" -925- ADD 001 TO WS-ENC-8146 */
                W.WS_ENC_8146.Value = W.WS_ENC_8146 + 001;

                /*" -926- END-IF */
            }


            /*" -927- IF ENDOSSOS-COD-PRODUTO EQUAL 8147 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8147)
            {

                /*" -928- ADD 001 TO WS-ENC-8147 */
                W.WS_ENC_8147.Value = W.WS_ENC_8147 + 001;

                /*" -929- END-IF */
            }


            /*" -930- IF ENDOSSOS-COD-PRODUTO EQUAL 8148 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8148)
            {

                /*" -931- ADD 001 TO WS-ENC-8148 */
                W.WS_ENC_8148.Value = W.WS_ENC_8148 + 001;

                /*" -932- END-IF */
            }


            /*" -933- IF ENDOSSOS-COD-PRODUTO EQUAL 8149 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8149)
            {

                /*" -934- ADD 001 TO WS-ENC-8149 */
                W.WS_ENC_8149.Value = W.WS_ENC_8149 + 001;

                /*" -935- END-IF */
            }


            /*" -936- IF ENDOSSOS-COD-PRODUTO EQUAL 8150 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 8150)
            {

                /*" -937- ADD 001 TO WS-ENC-8150 */
                W.WS_ENC_8150.Value = W.WS_ENC_8150 + 001;

                /*" -939- END-IF */
            }


            /*" -939- . */

        }

        [StopWatch]
        /*" R0410-00-TRATA-EXPI-PROD-DB-FETCH-1 */
        public void R0410_00_TRATA_EXPI_PROD_DB_FETCH_1()
        {
            /*" -876- EXEC SQL FETCH C3_EXP_PRD INTO :BILHETE-NUM-BILHETE , :ENDOSSOS-COD-PRODUTO END-EXEC */

            if (C3_EXP_PRD.Fetch())
            {
                _.Move(C3_EXP_PRD.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(C3_EXP_PRD.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0410-00-TRATA-EXPI-PROD-DB-UPDATE-1 */
        public void R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1()
        {
            /*" -902- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = 'V' , TIP_CANCELAMENTO = '4' , COD_USUARIO = 'BI0094B' , DATA_CANCELAMENTO = CURRENT DATE , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE END-EXEC */

            var r0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1 = new R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1.Execute(r0410_00_TRATA_EXPI_PROD_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -947- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -948- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -949- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -951- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -951- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -955- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -955- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}