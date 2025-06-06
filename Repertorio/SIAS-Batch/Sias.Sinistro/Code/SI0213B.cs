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
using Sias.Sinistro.DB2.SI0213B;

namespace Code
{
    public class SI0213B
    {
        public bool IsCall { get; set; }

        public SI0213B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0213B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PRODEXTER                          *      */
        /*"      *   PROGRAMADOR ............  PRODEXTER                          *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO/2004                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  INCLUI LANCAMENTO DE PAGAMENTO DE  *      */
        /*"      *                             REPASSE/HONORARIO DE RESSARCIMENTO *      */
        /*"      *                             POR CAPA DE LOTE                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   M A N U T E N C A O - O R D E M  D E C R E S C E N T E       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  * 14/06/2021 - HERVAL SOUZA                                      *      */
        /*"      *            - ALTERAR REGRA DE CREDITO EM CONTA PARA QUALQUER   *      */
        /*"      *              BANCO, N�O MAIS S� CEF.                           *      */
        /*"      *            - DEMANDA: 291.671                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  * 15/03/2018 - RILDO SICO - PROJETO REINF                        *      */
        /*"      *            - ALTERACAO PARA GERAR RECIBO DE PAGAMENTO SOMENTE  *      */
        /*"      *              NO DIA 5, N�O MAIS NO DIA 20.                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  * 15/03/2014 - ROGERIO LANZA AUGUSTO - CAD73898                  *      */
        /*"      *            - INCLUSAO DA COLUNA COD_PROCESSO_JURID NO INSERT DA*      */
        /*"      *              TABELA SINISTRO_LANCLOTE1.                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.07  * 02/08/2011 - HEIDER COELHO -                                          */
        /*"      *            - AJUSTE DE PERFORMANCE A PEDIDO DO FORONI          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  * 13/10/2009 - HEIDER COELHO - CADMUS 30855                             */
        /*"      *            - INCLUIR O SIT_REGISTRO <> '2' NO DECLARE PRINCIPAL*      */
        /*"      *            - AJUSTE DO DECLARE PRINCIPAL PARA SELECIONAR OS    *      */
        /*"      *              MOVIMENTOS DE REEMISS�O DE REPASSE                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.05  * 27/07/2009 - CONTRASTE - GEORGES DA MATA CLAESSEN              *      */
        /*"      *            - OS LOTES DE MATCON VOLTARAM A SER INCLUIDOS COM   *      */
        /*"      *              SITUACAO = '3': LOTE LIBERADO PARA PAGAMENTO      *      */
        /*"      *              A CEF.                                            *      */
        /*"      *            - PAGAMENTO DE REPASSE NAO TEM RELATORIO DE         *      */
        /*"      *              CONFERENCIA QUE DEVA SER APROVADO PELA TESOURARIA *      */
        /*"      *              CONFORME V.03                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * 14/04/2009 - CONTRASTE - GEORGES DA MATA CLAESSEN              *      */
        /*"      *            - OS LOTES DE MATCON SERAO INCLUIDOS COM A SITUACAO *      */
        /*"      *              'K' PARA EVITAR SEU ENVIO PARA A CEF. AGORA OS    *      */
        /*"      *              LOTES DE REPASSE DE RESSARCIMENTO SAO APROVADOS   *      */
        /*"      *              AUTOMATICAMENTE. A SITUACAO = 'K' SERA REMOVIDA   *      */
        /*"      *              PROVAVELMENTE EM 29/05/2009.                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * 09/04/2009 - CONTRASTE - GEORGES DA MATA CLAESSEN              *      */
        /*"      *            - A ETAPA DE EMISSAO DE RELATORIO PARA CONFERENCIA  *      */
        /*"      *              FOI ABOLIDA DO PROCESSO DE GERACAO DA CAPA DE LOTE*      */
        /*"      *              DEVIDO A ISTO, A CAPA DE LOTE SERA GERADA         *      */
        /*"      *              DE FORMA A SER LIDA PELO PROGRAMA SI0114B         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * 01/03/2009 - CONTRASTE - GEORGES MATA CLAESSEN                 *      */
        /*"      *              O PAGAMENTO DE REPASSE DE CREDITO SERA INCLUIDO   *      */
        /*"      *              EM UM LOTE SEPARADO                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO PELA FAST COMPUTER EM 09/2008                        *      */
        /*"      * DEMANDA DA GEFAB/CAIXA SEGUROS                                 *      */
        /*"      * MUDAR A CODIGO_CH1 = '5' PARA CODIGO_CH1 = '7' DA TABELA       *      */
        /*"      * SINISTRO_CAPALOTE1 PARA O FAVORECIDO = 891733                  *      */
        /*"      * SSI/CADMUS = 13008                                             *      */
        /*"      * PROCURAR POR V.01                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 07/04/2005 - PRODEXTER -                                       *      */
        /*"      *              SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI         *      */
        /*"      *              GE_OPERACAO.                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 03/05/2005 - PRODEXTER - EDUARDO                               *      */
        /*"      *              PROCESSAMENTO DIARIO DOS REPASSES                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 14/06/2005 - PRODEXTER - EDUARDO                               *      */
        /*"      *              PROCESSAMENTO DOS REPASSES GERADOS POR REEMISSAO  *      */
        /*"      *              DE SIVAT                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19/01/2006 - PRODEXTER - EDUARDO                               *      */
        /*"      *              TRATA, TAMBEM, AS LIBERACOES DE HONORARIO COM     *      */
        /*"      *              DATA DE PAGAMENTO ANTERIOR A 15/09/2004           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 22/02/2006 - PRODEXTER - EDUARDO                               *      */
        /*"      *              DESPREZA LANCAMENTOS DE HONORARIO PARA A          *      */
        /*"      *              CAIXA SEGUROS                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _SI0213B1 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SI0213B1
        {
            get
            {
                _.Move(REG_SI0213B1, _SI0213B1); VarBasis.RedefinePassValue(REG_SI0213B1, _SI0213B1, REG_SI0213B1); return _SI0213B1;
            }
        }
        /*"01       REG-SI0213B1           PIC X(300).*/
        public StringBasis REG_SI0213B1 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  I-DT-LIBERA-PAGTO          PIC S9(004) COMP VALUE -1.*/
        public IntBasis I_DT_LIBERA_PAGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77  I-DT-PAGAMENTO             PIC S9(004) COMP VALUE -1.*/
        public IntBasis I_DT_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"01       HOST-DATA-CORRENTE     PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  HOST-DATA-SISTEMA-MENOS-60DIAS  PIC X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_SISTEMA_MENOS_60DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01       HOST-DATA-ANTES-DE-05-E-20                                PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_DATA_ANTES_DE_05_E_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01       HOST-DATA-PENULT-DIA-MES                                PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_DATA_PENULT_DIA_MES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01       HOST-DATA-PROX-DIA-UTIL                                PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_DATA_PROX_DIA_UTIL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01       HOST-DIA-MOV-ABERTO    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_DIA_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-MES-MOV-ABERTO    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_MES_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-ANO-MOV-ABERTO    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_ANO_MOV_ABERTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-COD-OPERACAO-PAG  PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_COD_OPERACAO_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       HOST-VAL-RECEBIDO      PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis HOST_VAL_RECEBIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-VAL-RECEBIDO-EST  PIC S9(013)V99 VALUE +0 COMP-3.*/
        public DoubleBasis HOST_VAL_RECEBIDO_EST { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       HOST-COUNT-REPASSE     PIC S9(004) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT_REPASSE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       WS-COD-PREST-SERVICO   PIC S9(009) VALUE +0 COMP.*/
        public IntBasis WS_COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01       WS-NUM-APOL-SINISTRO   PIC S9(013) VALUE +0 COMP-3.*/
        public IntBasis WS_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01       WFIM-SINISHIS          PIC  X(003) VALUE SPACES.*/
        public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       WTEM-PAGAMENTO         PIC  X(003) VALUE SPACES.*/
        public StringBasis WTEM_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       WTEM-PROCESSAMENTO     PIC  X(003) VALUE SPACES.*/
        public StringBasis WTEM_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       WTEM-SOLICITACAO       PIC  X(003) VALUE SPACES.*/
        public StringBasis WTEM_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       WTEM-SINCREIN          PIC  X(003) VALUE SPACES.*/
        public StringBasis WTEM_SINCREIN { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       WTEM-SINIHAB1          PIC  X(003) VALUE SPACES.*/
        public StringBasis WTEM_SINIHAB1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01       W-DATA-PRE-LIB-REPASSE PIC  X(010) VALUE SPACES.*/
        public StringBasis W_DATA_PRE_LIB_REPASSE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01       W-SELECAO-REPASSE      PIC  X(030) VALUE SPACES.*/
        public StringBasis W_SELECAO_REPASSE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"01       AC-L-SINISHIS          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_L_SINISHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISCAP          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-I-SINISLAN          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_I_SINISLAN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       AC-U-SINISCAP          PIC  9(009) VALUE ZEROS.*/
        public IntBasis AC_U_SINISCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"01       W-SIT-CONTABIL-ANT     PIC  X(001) VALUE SPACE.*/
        public StringBasis W_SIT_CONTABIL_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  W-DATA-AAAA-MM-DD.*/
        public SI0213B_W_DATA_AAAA_MM_DD W_DATA_AAAA_MM_DD { get; set; } = new SI0213B_W_DATA_AAAA_MM_DD();
        public class SI0213B_W_DATA_AAAA_MM_DD : VarBasis
        {
            /*"  05 W-DATA-AAAA-MM-DD-AAAA     PIC  9(004) VALUE ZEROS.*/
            public IntBasis W_DATA_AAAA_MM_DD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05 W-DATA-AAAA-MM-DD-FILLER1  PIC  X(001) VALUE '-'.*/
            public StringBasis W_DATA_AAAA_MM_DD_FILLER1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05 W-DATA-AAAA-MM-DD-MM       PIC  9(002) VALUE ZEROS.*/
            public IntBasis W_DATA_AAAA_MM_DD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 W-DATA-AAAA-MM-DD-FILLER2  PIC  X(001) VALUE '-'.*/
            public StringBasis W_DATA_AAAA_MM_DD_FILLER2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05 W-DATA-AAAA-MM-DD-DD       PIC  9(002) VALUE ZEROS.*/
            public IntBasis W_DATA_AAAA_MM_DD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01       DB2-DATA.*/
        }
        public SI0213B_DB2_DATA DB2_DATA { get; set; } = new SI0213B_DB2_DATA();
        public class SI0213B_DB2_DATA : VarBasis
        {
            /*"  05     DB2-ANO                PIC  9(004) VALUE ZEROS.*/
            public IntBasis DB2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05     FILLER                 PIC  X(001) VALUE SPACE.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     DB2-MES                PIC  9(002) VALUE ZEROS.*/
            public IntBasis DB2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     FILLER                 PIC  X(001) VALUE SPACE.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05     DB2-DIA                PIC  9(002) VALUE ZEROS.*/
            public IntBasis DB2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01       EDIT-DATA.*/
        }
        public SI0213B_EDIT_DATA EDIT_DATA { get; set; } = new SI0213B_EDIT_DATA();
        public class SI0213B_EDIT_DATA : VarBasis
        {
            /*"  05     EDIT-DIA               PIC  9(002) VALUE ZEROS.*/
            public IntBasis EDIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     FILLER                 PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05     EDIT-MES               PIC  9(002) VALUE ZEROS.*/
            public IntBasis EDIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05     FILLER                 PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05     EDIT-ANO               PIC  9(004) VALUE ZEROS.*/
            public IntBasis EDIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01       WS-DIA                 PIC  9(002) VALUE ZEROS.*/
        }
        public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01       WS-DIA-PROX            PIC  9(002) VALUE ZEROS.*/
        public IntBasis WS_DIA_PROX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"01       WS-CGCCPF              PIC  9(015) VALUE ZEROS.*/
        public IntBasis WS_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"01       WS-CGC                 REDEFINES   WS-CGCCPF.*/
        private _REDEF_SI0213B_WS_CGC _ws_cgc { get; set; }
        public _REDEF_SI0213B_WS_CGC WS_CGC
        {
            get { _ws_cgc = new _REDEF_SI0213B_WS_CGC(); _.Move(WS_CGCCPF, _ws_cgc); VarBasis.RedefinePassValue(WS_CGCCPF, _ws_cgc, WS_CGCCPF); _ws_cgc.ValueChanged += () => { _.Move(_ws_cgc, WS_CGCCPF); }; return _ws_cgc; }
            set { VarBasis.RedefinePassValue(value, _ws_cgc, WS_CGCCPF); }
        }  //Redefines
        public class _REDEF_SI0213B_WS_CGC : VarBasis
        {
            /*"  05     WS-CGC-NUM             PIC  9(009).*/
            public IntBasis WS_CGC_NUM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05     WS-CGC-FIL             PIC  9(004).*/
            public IntBasis WS_CGC_FIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05     WS-CGC-DIG             PIC  9(002).*/
            public IntBasis WS_CGC_DIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01       WS-CPF                 REDEFINES   WS-CGCCPF.*/

            public _REDEF_SI0213B_WS_CGC()
            {
                WS_CGC_NUM.ValueChanged += OnValueChanged;
                WS_CGC_FIL.ValueChanged += OnValueChanged;
                WS_CGC_DIG.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_SI0213B_WS_CPF _ws_cpf { get; set; }
        public _REDEF_SI0213B_WS_CPF WS_CPF
        {
            get { _ws_cpf = new _REDEF_SI0213B_WS_CPF(); _.Move(WS_CGCCPF, _ws_cpf); VarBasis.RedefinePassValue(WS_CGCCPF, _ws_cpf, WS_CGCCPF); _ws_cpf.ValueChanged += () => { _.Move(_ws_cpf, WS_CGCCPF); }; return _ws_cpf; }
            set { VarBasis.RedefinePassValue(value, _ws_cpf, WS_CGCCPF); }
        }  //Redefines
        public class _REDEF_SI0213B_WS_CPF : VarBasis
        {
            /*"  05     WS-CPF-FIL             PIC  9(004).*/
            public IntBasis WS_CPF_FIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05     WS-CPF-NUM             PIC  9(009).*/
            public IntBasis WS_CPF_NUM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05     WS-CPF-DIG             PIC  9(002).*/
            public IntBasis WS_CPF_DIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01       EDIT-CGC.*/

            public _REDEF_SI0213B_WS_CPF()
            {
                WS_CPF_FIL.ValueChanged += OnValueChanged;
                WS_CPF_NUM.ValueChanged += OnValueChanged;
                WS_CPF_DIG.ValueChanged += OnValueChanged;
            }

        }
        public SI0213B_EDIT_CGC EDIT_CGC { get; set; } = new SI0213B_EDIT_CGC();
        public class SI0213B_EDIT_CGC : VarBasis
        {
            /*"  05     EDIT-CGC-NUM           PIC  ZZZ.999.999.*/
            public IntBasis EDIT_CGC_NUM { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.999.999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"  05     EDIT-CGC-FIL           PIC  9999.*/
            public IntBasis EDIT_CGC_FIL { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     EDIT-CGC-DIG           PIC  99.*/
            public IntBasis EDIT_CGC_DIG { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"01       EDIT-CPF.*/
        }
        public SI0213B_EDIT_CPF EDIT_CPF { get; set; } = new SI0213B_EDIT_CPF();
        public class SI0213B_EDIT_CPF : VarBasis
        {
            /*"  05     EDIT-CPF-NUM           PIC  ZZZ.999.999.*/
            public IntBasis EDIT_CPF_NUM { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.999.999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     EDIT-CPF-DIG           PIC  9(002).*/
            public IntBasis EDIT_CPF_DIG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01       HABIT-CONTRATO.*/
        }
        public SI0213B_HABIT_CONTRATO HABIT_CONTRATO { get; set; } = new SI0213B_HABIT_CONTRATO();
        public class SI0213B_HABIT_CONTRATO : VarBasis
        {
            /*"  05     FILLER                 PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05     HABIT-OPERACAO         PIC  9.*/
            public IntBasis HABIT_OPERACAO { get; set; } = new IntBasis(new PIC("9", "1", "9."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     HABIT-PONTO-VENDA      PIC  9999.*/
            public IntBasis HABIT_PONTO_VENDA { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     HABIT-NUM-CONTRATO     PIC  99999999.*/
            public IntBasis HABIT_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
            /*"01       CREINT-CONTRATO.*/
        }
        public SI0213B_CREINT_CONTRATO CREINT_CONTRATO { get; set; } = new SI0213B_CREINT_CONTRATO();
        public class SI0213B_CREINT_CONTRATO : VarBasis
        {
            /*"  05     FILLER                 PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05     CREINT-COD-SUREG       PIC  99.*/
            public IntBasis CREINT_COD_SUREG { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     CREINT-COD-AGENCIA     PIC  9999.*/
            public IntBasis CREINT_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     CREINT-COD-OPERACAO    PIC  999.*/
            public IntBasis CREINT_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     CREINT-NUM-CONTRATO    PIC  999999.*/
            public IntBasis CREINT_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
            /*"  05     FILLER                 PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"  05     CREINT-CONTRATO-DIG    PIC  99.*/
            public IntBasis CREINT_CONTRATO_DIG { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"01       LC01.*/
        }
        public SI0213B_LC01 LC01 { get; set; } = new SI0213B_LC01();
        public class SI0213B_LC01 : VarBasis
        {
            /*"  05     LC01-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC01_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-TIPO-REGISTRO     PIC  X(001) VALUE 'C'.*/
            public StringBasis LC01_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-RELATORIO         PIC  X(010) VALUE         'SI0213B - '.*/
            public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0213B - ");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC01-EMPRESA           PIC  X(040) VALUE  SPACES.*/
            public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01       LC02.*/
        }
        public SI0213B_LC02 LC02 { get; set; } = new SI0213B_LC02();
        public class SI0213B_LC02 : VarBasis
        {
            /*"  05     LC02-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC02_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC02-TIPO-REGISTRO     PIC  X(001) VALUE 'C'.*/
            public StringBasis LC02_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(019) VALUE         'DATA SISTEMA (SI): '.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DATA SISTEMA (SI): ");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC02-DATA-SISTEMA      PIC  X(010) VALUE SPACES.*/
            public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01       LC03.*/
        }
        public SI0213B_LC03 LC03 { get; set; } = new SI0213B_LC03();
        public class SI0213B_LC03 : VarBasis
        {
            /*"  05     LC03-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC03_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC03-TIPO-REGISTRO     PIC  X(001) VALUE 'C'.*/
            public StringBasis LC03_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(015) VALUE         'DATA CORRENTE: '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA CORRENTE: ");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC03-DATA-CORRENTE     PIC  X(010) VALUE SPACES.*/
            public StringBasis LC03_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01       LC04.*/
        }
        public SI0213B_LC04 LC04 { get; set; } = new SI0213B_LC04();
        public class SI0213B_LC04 : VarBasis
        {
            /*"  05     LC04-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC04_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC04-TIPO-REGISTRO     PIC  X(001) VALUE 'C'.*/
            public StringBasis LC04_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(079) VALUE         'RELATORIO DE PROCESSAMENTO - LANCAMENTOS DE REPASSE/HON         'ORARIOS DE RESSARCIMENTO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "79", "X(079)"), @"RELATORIO DE PROCESSAMENTO - LANCAMENTOS DE REPASSE/HON         ");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01       LC05.*/
        }
        public SI0213B_LC05 LC05 { get; set; } = new SI0213B_LC05();
        public class SI0213B_LC05 : VarBasis
        {
            /*"  05     LC05-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC05_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC05-TIPO-REGISTRO     PIC  X(001) VALUE 'C'.*/
            public StringBasis LC05_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(005) VALUE         'FONTE'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(004) VALUE         'LOTE'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"LOTE");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(010) VALUE         'FAVORECIDO'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"FAVORECIDO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(004) VALUE         'NOME'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"NOME");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(007) VALUE         'CGC/CPF'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CGC/CPF");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(008) VALUE         'SINISTRO'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SINISTRO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(008) VALUE         'CONTRATO'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CONTRATO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(008) VALUE         'SEGURADO'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SEGURADO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(006) VALUE         'ACORDO'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ACORDO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(007) VALUE         'PARCELA'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(014) VALUE         'VALOR RECEBIDO'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"VALOR RECEBIDO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(012) VALUE         'VALOR DEVIDO'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"VALOR DEVIDO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(017) VALUE         'TIPO DE PAGAMENTO'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"TIPO DE PAGAMENTO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01       LC00-NAO-TEVE-MOVIMENTO.*/
        }
        public SI0213B_LC00_NAO_TEVE_MOVIMENTO LC00_NAO_TEVE_MOVIMENTO { get; set; } = new SI0213B_LC00_NAO_TEVE_MOVIMENTO();
        public class SI0213B_LC00_NAO_TEVE_MOVIMENTO : VarBasis
        {
            /*"  05     LC00-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC00_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC00-TIPO-REGISTRO     PIC  X(001) VALUE 'C'.*/
            public StringBasis LC00_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"C");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(077) VALUE         'NENHUMA PRE-LIBERACAO DE REPASSE/HONORARIO FOI SELECION         'ADA PARA PROCESSAMENTO'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"NENHUMA PRE-LIBERACAO DE REPASSE/HONORARIO FOI SELECION         ");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01       LC99-FIM.*/
        }
        public SI0213B_LC99_FIM LC99_FIM { get; set; } = new SI0213B_LC99_FIM();
        public class SI0213B_LC99_FIM : VarBasis
        {
            /*"  05     LC99-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LC99_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LC99-TIPO-REGISTRO     PIC  X(001) VALUE 'F'.*/
            public StringBasis LC99_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"F");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     FILLER                 PIC  X(014) VALUE         'FIM DE ARQUIVO'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"FIM DE ARQUIVO");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01       LD01.*/
        }
        public SI0213B_LD01 LD01 { get; set; } = new SI0213B_LD01();
        public class SI0213B_LD01 : VarBasis
        {
            /*"  05     LD01-TIPO-ARQUIVO      PIC  X(002) VALUE '02'.*/
            public StringBasis LD01_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"02");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-TIPO-REGISTRO     PIC  X(001) VALUE 'D'.*/
            public StringBasis LD01_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"D");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-COD-FONTE         PIC  ZZ99.*/
            public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99."));
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NUM-LOTE          PIC  ZZZZZZZZ9.*/
            public IntBasis LD01_NUM_LOTE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-COD-PREST-SERVICO PIC  ZZZZZZZZ9.*/
            public IntBasis LD01_COD_PREST_SERVICO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NOME-FORNECEDOR   PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_FORNECEDOR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-CGCCPF            PIC  X(019) VALUE SPACES.*/
            public StringBasis LD01_CGCCPF { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NUM-APOL-SINISTRO PIC  Z999999999999.*/
            public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "Z999999999999."));
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NUM-CONTRATO      PIC  X(023) VALUE SPACES.*/
            public StringBasis LD01_NUM_CONTRATO { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NOME-SEGURADO     PIC  X(040) VALUE SPACES.*/
            public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NUM-RESSARC       PIC  ZZZZZZZZ9.*/
            public IntBasis LD01_NUM_RESSARC { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-NUM-PARCELA       PIC  ZZZZZZZZ9.*/
            public IntBasis LD01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-VAL-RECEBIDO      PIC  ---.---.--9,99.*/
            public DoubleBasis LD01_VAL_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-VAL-DEVIDO        PIC  ---.---.--9,99.*/
            public DoubleBasis LD01_VAL_DEVIDO { get; set; } = new DoubleBasis(new PIC("9", "9", "---.---.--9V99."), 2);
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05     LD01-TIPO-PAGTO        PIC  X(020) VALUE SPACES.*/
            public StringBasis LD01_TIPO_PAGTO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05     FILLER                 PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01      WS-DATA-AUX-COMP.*/
        }
        public SI0213B_WS_DATA_AUX_COMP WS_DATA_AUX_COMP { get; set; } = new SI0213B_WS_DATA_AUX_COMP();
        public class SI0213B_WS_DATA_AUX_COMP : VarBasis
        {
            /*"   05       WS-WHEN-COMPILED    PIC  X(021)      VALUE SPACES.*/
            public StringBasis WS_WHEN_COMPILED { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"   05       FILLER              REDEFINES WS-WHEN-COMPILED.*/
            private _REDEF_SI0213B_FILLER_83 _filler_83 { get; set; }
            public _REDEF_SI0213B_FILLER_83 FILLER_83
            {
                get { _filler_83 = new _REDEF_SI0213B_FILLER_83(); _.Move(WS_WHEN_COMPILED, _filler_83); VarBasis.RedefinePassValue(WS_WHEN_COMPILED, _filler_83, WS_WHEN_COMPILED); _filler_83.ValueChanged += () => { _.Move(_filler_83, WS_WHEN_COMPILED); }; return _filler_83; }
                set { VarBasis.RedefinePassValue(value, _filler_83, WS_WHEN_COMPILED); }
            }  //Redefines
            public class _REDEF_SI0213B_FILLER_83 : VarBasis
            {
                /*"    10      WS-WHEN-ANO         PIC  9(004).*/
                public IntBasis WS_WHEN_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-WHEN-MES         PIC  9(002).*/
                public IntBasis WS_WHEN_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-DIA         PIC  9(002).*/
                public IntBasis WS_WHEN_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-HORA        PIC  9(002).*/
                public IntBasis WS_WHEN_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-MIN         PIC  9(002).*/
                public IntBasis WS_WHEN_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-SEG         PIC  9(002).*/
                public IntBasis WS_WHEN_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-DECSEG      PIC  9(002).*/
                public IntBasis WS_WHEN_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-GREEN       PIC  X(001).*/
                public StringBasis WS_WHEN_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-WHEN-GHORA       PIC  9(002).*/
                public IntBasis WS_WHEN_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-WHEN-GMIN        PIC  9(002).*/
                public IntBasis WS_WHEN_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05       WS-COMPILED-EDIT    PIC  X(022)      VALUE SPACES.*/

                public _REDEF_SI0213B_FILLER_83()
                {
                    WS_WHEN_ANO.ValueChanged += OnValueChanged;
                    WS_WHEN_MES.ValueChanged += OnValueChanged;
                    WS_WHEN_DIA.ValueChanged += OnValueChanged;
                    WS_WHEN_HORA.ValueChanged += OnValueChanged;
                    WS_WHEN_MIN.ValueChanged += OnValueChanged;
                    WS_WHEN_SEG.ValueChanged += OnValueChanged;
                    WS_WHEN_DECSEG.ValueChanged += OnValueChanged;
                    WS_WHEN_GREEN.ValueChanged += OnValueChanged;
                    WS_WHEN_GHORA.ValueChanged += OnValueChanged;
                    WS_WHEN_GMIN.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_COMPILED_EDIT { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
            /*"01       WABEND.*/
        }
        public SI0213B_WABEND WABEND { get; set; } = new SI0213B_WABEND();
        public class SI0213B_WABEND : VarBasis
        {
            /*"  05     FILLER                 PIC  X(010) VALUE        ' SI0213B'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0213B");
            /*"  05     FILLER                 PIC  X(026) VALUE        ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05     WNR-EXEC-SQL           PIC  X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05     FILLER                 PIC  X(013) VALUE        ' *** SQLCODE '.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05     WSQLCODE               PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SINNUMLO SINNUMLO { get; set; } = new Dclgens.SINNUMLO();
        public Dclgens.SINISCAP SINISCAP { get; set; } = new Dclgens.SINISCAP();
        public Dclgens.SINISLAN SINISLAN { get; set; } = new Dclgens.SINISLAN();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SI111 SI111 { get; set; } = new Dclgens.SI111();
        public Dclgens.SI112 SI112 { get; set; } = new Dclgens.SI112();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.FIPADOFI FIPADOFI { get; set; } = new Dclgens.FIPADOFI();
        public SI0213B_C01_SINISHIS C01_SINISHIS { get; set; } = new SI0213B_C01_SINISHIS();
        public SI0213B_SINISHIS2 SINISHIS2 { get; set; } = new SI0213B_SINISHIS2();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SI0213B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SI0213B1.SetFile(SI0213B1_FILE_NAME_P);

                /*" -422- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -423- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -424- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -424- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -432- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -434- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
            _.Move(_.WhenCompiled(), WS_DATA_AUX_COMP.WS_WHEN_COMPILED);

            /*" -442- STRING WS-WHEN-DIA '/' WS-WHEN-MES '/' WS-WHEN-ANO ' AS ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
            #region STRING
            var spl1 = WS_DATA_AUX_COMP.FILLER_83.WS_WHEN_DIA.GetMoveValues();
            spl1 += "/";
            var spl2 = WS_DATA_AUX_COMP.FILLER_83.WS_WHEN_MES.GetMoveValues();
            spl2 += "/";
            var spl3 = WS_DATA_AUX_COMP.FILLER_83.WS_WHEN_ANO.GetMoveValues();
            spl3 += " AS ";
            var spl4 = WS_DATA_AUX_COMP.FILLER_83.WS_WHEN_HORA.GetMoveValues();
            spl4 += ":";
            var spl5 = WS_DATA_AUX_COMP.FILLER_83.WS_WHEN_MIN.GetMoveValues();
            spl5 += ":";
            var spl6 = WS_DATA_AUX_COMP.FILLER_83.WS_WHEN_SEG.GetMoveValues();
            var results7 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6;
            _.Move(results7, WS_DATA_AUX_COMP.WS_COMPILED_EDIT);
            #endregion

            /*" -444- DISPLAY '*========================================================*' */
            _.Display($"*========================================================*");

            /*" -446- DISPLAY '* SI0213B.: V.09  EM: 14-06-2021. TAREFA: 291.671' '        *' */
            _.Display($"* SI0213B.: V.09  EM: 14-06-2021. TAREFA: 291.671        *");

            /*" -448- DISPLAY '* Catalogacao...: ' WS-COMPILED-EDIT '                 *' */

            $"* Catalogacao...: {WS_DATA_AUX_COMP.WS_COMPILED_EDIT}                 *"
            .Display();

            /*" -456- DISPLAY '* Execucao......: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) '                 *' */

            $"* Execucao......: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}                 *"
            .Display();

            /*" -459- DISPLAY '*========================================================*' */
            _.Display($"*========================================================*");

            /*" -461- OPEN OUTPUT SI0213B1 */
            SI0213B1.Open(REG_SI0213B1);

            /*" -462- PERFORM R0100-00-LE-SISTEMAS */

            R0100_00_LE_SISTEMAS_SECTION();

            /*" -463- PERFORM R0200-00-LE-PROXIMO-DIA-UTIL */

            R0200_00_LE_PROXIMO_DIA_UTIL_SECTION();

            /*" -465- PERFORM R0250-00-LE-PENULT-DIA-MES */

            R0250_00_LE_PENULT_DIA_MES_SECTION();

            /*" -467- DISPLAY 'DATA DO PROCESSAMENTO (SI)        -' ' ' SISTEMAS-DATA-MOV-ABERTO */

            $"DATA DO PROCESSAMENTO (SI)        - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -469- DISPLAY 'DATA DO PROXIMO DIA UTIL          -' ' ' HOST-DATA-PROX-DIA-UTIL */

            $"DATA DO PROXIMO DIA UTIL          - {HOST_DATA_PROX_DIA_UTIL}"
            .Display();

            /*" -472- DISPLAY 'DATA DO PENULTIMO DIA UTIL DO MES -' ' ' HOST-DATA-PENULT-DIA-MES */

            $"DATA DO PENULTIMO DIA UTIL DO MES - {HOST_DATA_PENULT_DIA_MES}"
            .Display();

            /*" -473- PERFORM R0300-00-LE-EMPRESAS */

            R0300_00_LE_EMPRESAS_SECTION();

            /*" -475- PERFORM R0400-00-MONTA-CABECALHO */

            R0400_00_MONTA_CABECALHO_SECTION();

            /*" -477- MOVE 'NAO' TO WTEM-PROCESSAMENTO WTEM-SOLICITACAO */
            _.Move("NAO", WTEM_PROCESSAMENTO, WTEM_SOLICITACAO);

            /*" -479- MOVE ZEROS TO HOST-COUNT-REPASSE */
            _.Move(0, HOST_COUNT_REPASSE);

            /*" -480- PERFORM R0500-00-VERIFICA-DATA */

            R0500_00_VERIFICA_DATA_SECTION();

            /*" -484- DISPLAY 'WTEM-PROCESSAMENTO = ' WTEM-PROCESSAMENTO */
            _.Display($"WTEM-PROCESSAMENTO = {WTEM_PROCESSAMENTO}");

            /*" -485- IF WTEM-PROCESSAMENTO EQUAL 'SIM' */

            if (WTEM_PROCESSAMENTO == "SIM")
            {

                /*" -487- MOVE SISTEMAS-DATA-MOV-ABERTO TO CALENDAR-DATA-CALENDARIO. */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


            /*" -493- DISPLAY 'PROCESS. SERA PELA DATA_MOV_ABERTO ' WTEM-PROCESSAMENTO. */
            _.Display($"PROCESS. SERA PELA DATA_MOV_ABERTO {WTEM_PROCESSAMENTO}");

            /*" -494- IF WTEM-PROCESSAMENTO EQUAL 'NAO' */

            if (WTEM_PROCESSAMENTO == "NAO")
            {

                /*" -501- PERFORM R0600-00-LE-RELATORI. */

                R0600_00_LE_RELATORI_SECTION();
            }


            /*" -505- DISPLAY 'PROCESS. SERA PELA RELATORIOS      ' WTEM-SOLICITACAO ' DATA DA RELATORIOS ' RELATORI-PERI-INICIAL */

            $"PROCESS. SERA PELA RELATORIOS      {WTEM_SOLICITACAO} DATA DA RELATORIOS {RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}"
            .Display();

            /*" -507- IF (WTEM-SOLICITACAO EQUAL 'SIM' ) AND (RELATORI-PERI-INICIAL NOT EQUAL '0001-01-01' ) */

            if ((WTEM_SOLICITACAO == "SIM") && (RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL != "0001-01-01"))
            {

                /*" -509- MOVE RELATORI-PERI-INICIAL TO CALENDAR-DATA-CALENDARIO. */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


            /*" -511- IF WTEM-PROCESSAMENTO EQUAL 'NAO' AND WTEM-SOLICITACAO EQUAL 'NAO' */

            if (WTEM_PROCESSAMENTO == "NAO" && WTEM_SOLICITACAO == "NAO")
            {

                /*" -512- MOVE SISTEMAS-DATA-MOV-ABERTO TO CALENDAR-DATA-CALENDARIO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -514- END-IF. */
            }


            /*" -516- PERFORM R0700-00-LE-CALENDAR. */

            R0700_00_LE_CALENDAR_SECTION();

            /*" -521- IF (WTEM-PROCESSAMENTO = 'NAO' ) AND (WTEM-SOLICITACAO = 'NAO' ) OR ( (WTEM-SOLICITACAO EQUAL 'SIM' ) AND (RELATORI-PERI-INICIAL NOT EQUAL '0001-01-01' ) ) */

            if ((WTEM_PROCESSAMENTO == "NAO") && (WTEM_SOLICITACAO == "NAO") || ((WTEM_SOLICITACAO == "SIM") && (RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL != "0001-01-01")))
            {

                /*" -522- MOVE SISTEMAS-DATA-MOV-ABERTO TO CALENDAR-DATA-CALENDARIO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

                /*" -524- END-IF. */
            }


            /*" -531- DISPLAY 'DATA DO PROCESSAMENTO (- 60 DIAS) -' ' ' CALENDAR-DATA-CALENDARIO. */

            $"DATA DO PROCESSAMENTO (- 60 DIAS) - {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}"
            .Display();

            /*" -533- IF (WTEM-PROCESSAMENTO = 'NAO' ) AND (WTEM-SOLICITACAO = 'NAO' ) */

            if ((WTEM_PROCESSAMENTO == "NAO") && (WTEM_SOLICITACAO == "NAO"))
            {

                /*" -534- MOVE 4290 TO SINISHIS-COD-OPERACAO */
                _.Move(4290, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -535- MOVE 4291 TO HOST-COD-OPERACAO-PAG */
                _.Move(4291, HOST_COD_OPERACAO_PAG);

                /*" -536- PERFORM R0650-00-CONTA-REPASSE */

                R0650_00_CONTA_REPASSE_SECTION();

                /*" -542- END-IF. */
            }


            /*" -545- IF (WTEM-PROCESSAMENTO = 'NAO' ) AND (WTEM-SOLICITACAO = 'NAO' ) AND (HOST-COUNT-REPASSE = 0) */

            if ((WTEM_PROCESSAMENTO == "NAO") && (WTEM_SOLICITACAO == "NAO") && (HOST_COUNT_REPASSE == 0))
            {

                /*" -546- GO TO R0000-20-REEMISSAO-REPASSE */

                R0000_20_REEMISSAO_REPASSE(); //GOTO
                return;

                /*" -552- END-IF. */
            }


            /*" -555- IF (WTEM-PROCESSAMENTO = 'NAO' ) AND (WTEM-SOLICITACAO = 'NAO' ) AND (HOST-COUNT-REPASSE NOT = 0) */

            if ((WTEM_PROCESSAMENTO == "NAO") && (WTEM_SOLICITACAO == "NAO") && (HOST_COUNT_REPASSE != 0))
            {

                /*" -556- GO TO R0000-10-REPASSE */

                R0000_10_REPASSE(); //GOTO
                return;

                /*" -560- END-IF. */
            }


            /*" -561- MOVE 'NAO' TO WFIM-SINISHIS */
            _.Move("NAO", WFIM_SINISHIS);

            /*" -562- MOVE ZEROS TO WS-NUM-APOL-SINISTRO */
            _.Move(0, WS_NUM_APOL_SINISTRO);

            /*" -563- MOVE 4260 TO SINISHIS-COD-OPERACAO */
            _.Move(4260, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -571- MOVE 4280 TO HOST-COD-OPERACAO-PAG */
            _.Move(4280, HOST_COD_OPERACAO_PAG);

            /*" -572- PERFORM R0900-00-DECLARA-SINISHIS */

            R0900_00_DECLARA_SINISHIS_SECTION();

            /*" -574- PERFORM R0910-00-LE-SINISHIS */

            R0910_00_LE_SINISHIS_SECTION();

            /*" -575- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS EQUAL 'SIM' . */

            while (!(WFIM_SINISHIS == "SIM"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_10_REPASSE */

            R0000_10_REPASSE();

        }

        [StopWatch]
        /*" R0000-10-REPASSE */
        private void R0000_10_REPASSE(bool isPerform = false)
        {
            /*" -588- MOVE SPACE TO W-SIT-CONTABIL-ANT */
            _.Move("", W_SIT_CONTABIL_ANT);

            /*" -589- MOVE 'NAO' TO WFIM-SINISHIS */
            _.Move("NAO", WFIM_SINISHIS);

            /*" -590- MOVE 'SIM' TO W-SELECAO-REPASSE. */
            _.Move("SIM", W_SELECAO_REPASSE);

            /*" -591- MOVE ZEROS TO WS-NUM-APOL-SINISTRO */
            _.Move(0, WS_NUM_APOL_SINISTRO);

            /*" -592- MOVE 4290 TO SINISHIS-COD-OPERACAO */
            _.Move(4290, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -594- MOVE 4291 TO HOST-COD-OPERACAO-PAG */
            _.Move(4291, HOST_COD_OPERACAO_PAG);

            /*" -596- MOVE '2004-09-15' TO W-DATA-PRE-LIB-REPASSE. */
            _.Move("2004-09-15", W_DATA_PRE_LIB_REPASSE);

            /*" -597- PERFORM R0900-00-DECLARA-SINISHIS */

            R0900_00_DECLARA_SINISHIS_SECTION();

            /*" -599- PERFORM R0910-00-LE-SINISHIS */

            R0910_00_LE_SINISHIS_SECTION();

            /*" -602- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS = 'SIM' . */

            while (!(WFIM_SINISHIS == "SIM"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

            /*" -602- MOVE 'NAO' TO W-SELECAO-REPASSE. */
            _.Move("NAO", W_SELECAO_REPASSE);

        }

        [StopWatch]
        /*" R0000-20-REEMISSAO-REPASSE */
        private void R0000_20_REEMISSAO_REPASSE(bool isPerform = false)
        {
            /*" -610- MOVE SPACE TO W-SIT-CONTABIL-ANT */
            _.Move("", W_SIT_CONTABIL_ANT);

            /*" -611- MOVE 'NAO' TO WFIM-SINISHIS */
            _.Move("NAO", WFIM_SINISHIS);

            /*" -612- MOVE ZEROS TO WS-NUM-APOL-SINISTRO */
            _.Move(0, WS_NUM_APOL_SINISTRO);

            /*" -613- MOVE 4290 TO SINISHIS-COD-OPERACAO */
            _.Move(4290, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -614- MOVE 4291 TO HOST-COD-OPERACAO-PAG */
            _.Move(4291, HOST_COD_OPERACAO_PAG);

            /*" -615- PERFORM R2900-00-DECLARA-SINISHIS */

            R2900_00_DECLARA_SINISHIS_SECTION();

            /*" -622- PERFORM R2910-00-LE-SINISHIS */

            R2910_00_LE_SINISHIS_SECTION();

            /*" -626- IF (WTEM-PROCESSAMENTO = 'NAO' ) AND (WTEM-SOLICITACAO = 'NAO' ) AND (HOST-COUNT-REPASSE = 0 ) AND (WFIM-SINISHIS = 'SIM' ) */

            if ((WTEM_PROCESSAMENTO == "NAO") && (WTEM_SOLICITACAO == "NAO") && (HOST_COUNT_REPASSE == 0) && (WFIM_SINISHIS == "SIM"))
            {

                /*" -627- WRITE REG-SI0213B1 FROM LC00-NAO-TEVE-MOVIMENTO */
                _.Move(LC00_NAO_TEVE_MOVIMENTO.GetMoveValues(), REG_SI0213B1);

                SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

                /*" -628- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -630- END-IF. */
            }


            /*" -631- PERFORM R3000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS = 'SIM' . */

            while (!(WFIM_SINISHIS == "SIM"))
            {

                R3000_00_PROCESSA_SINISHIS_SECTION();
            }

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -637- PERFORM R0800-00-EXCLUI-RELATORI */

            R0800_00_EXCLUI_RELATORI_SECTION();

            /*" -638- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -639- DISPLAY '*    SI0213B - FIM NORMAL    *' */
            _.Display($"*    SI0213B - FIM NORMAL    *");

            /*" -640- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -641- DISPLAY 'LIDOS     SINISHIS - ' AC-L-SINISHIS */
            _.Display($"LIDOS     SINISHIS - {AC_L_SINISHIS}");

            /*" -642- DISPLAY 'INSERIDOS SINISCAP - ' AC-I-SINISCAP */
            _.Display($"INSERIDOS SINISCAP - {AC_I_SINISCAP}");

            /*" -643- DISPLAY '          SINISLAN - ' AC-I-SINISLAN */
            _.Display($"          SINISLAN - {AC_I_SINISLAN}");

            /*" -645- DISPLAY 'ALTERADOS SINISCAP - ' AC-U-SINISCAP */
            _.Display($"ALTERADOS SINISCAP - {AC_U_SINISCAP}");

            /*" -647- WRITE REG-SI0213B1 FROM LC99-FIM */
            _.Move(LC99_FIM.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -649- CLOSE SI0213B1 */
            SI0213B1.Close();

            /*" -651- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -651- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -654- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-SECTION */
        private void R0100_00_LE_SISTEMAS_SECTION()
        {
            /*" -662- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -677- PERFORM R0100_00_LE_SISTEMAS_DB_SELECT_1 */

            R0100_00_LE_SISTEMAS_DB_SELECT_1();

            /*" -680- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -681- DISPLAY 'PROBLEMAS NO SELECT SISTEMAS' */
                _.Display($"PROBLEMAS NO SELECT SISTEMAS");

                /*" -681- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-LE-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -677- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE, DAY(DATA_MOV_ABERTO), MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO), DATA_MOV_ABERTO - 2 MONTHS INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-DATA-CORRENTE, :HOST-DIA-MOV-ABERTO, :HOST-MES-MOV-ABERTO, :HOST-ANO-MOV-ABERTO, :HOST-DATA-SISTEMA-MENOS-60DIAS FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
                _.Move(executed_1.HOST_DIA_MOV_ABERTO, HOST_DIA_MOV_ABERTO);
                _.Move(executed_1.HOST_MES_MOV_ABERTO, HOST_MES_MOV_ABERTO);
                _.Move(executed_1.HOST_ANO_MOV_ABERTO, HOST_ANO_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_SISTEMA_MENOS_60DIAS, HOST_DATA_SISTEMA_MENOS_60DIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-LE-PROXIMO-DIA-UTIL-SECTION */
        private void R0200_00_LE_PROXIMO_DIA_UTIL_SECTION()
        {
            /*" -697- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -704- PERFORM R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1 */

            R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1();

            /*" -709- IF SQLCODE NOT EQUAL ZEROS OR HOST-DATA-PROX-DIA-UTIL EQUAL '0001-01-01' */

            if (DB.SQLCODE != 00 || HOST_DATA_PROX_DIA_UTIL == "0001-01-01")
            {

                /*" -711- DISPLAY 'PROBLEMAS NO SELECT MIN CALENDARIO' ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"PROBLEMAS NO SELECT MIN CALENDARIO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -711- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-LE-PROXIMO-DIA-UTIL-DB-SELECT-1 */
        public void R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1()
        {
            /*" -704- EXEC SQL SELECT VALUE(MIN(DATA_CALENDARIO), '0001-01-01' ) INTO :HOST-DATA-PROX-DIA-UTIL FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :SISTEMAS-DATA-MOV-ABERTO AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO <> 'N' END-EXEC. */

            var r0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1 = new R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1.Execute(r0200_00_LE_PROXIMO_DIA_UTIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_PROX_DIA_UTIL, HOST_DATA_PROX_DIA_UTIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-LE-PENULT-DIA-MES-SECTION */
        private void R0250_00_LE_PENULT_DIA_MES_SECTION()
        {
            /*" -721- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WABEND.WNR_EXEC_SQL);

            /*" -736- PERFORM R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1 */

            R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1();

            /*" -741- IF SQLCODE NOT EQUAL ZEROS OR HOST-DATA-PENULT-DIA-MES EQUAL '0001-01-01' */

            if (DB.SQLCODE != 00 || HOST_DATA_PENULT_DIA_MES == "0001-01-01")
            {

                /*" -745- DISPLAY 'PROBLEMAS NO SELECT MAX CALENDARIO' ' ' SISTEMAS-DATA-MOV-ABERTO ' ' HOST-ANO-MOV-ABERTO ' ' HOST-MES-MOV-ABERTO */

                $"PROBLEMAS NO SELECT MAX CALENDARIO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO} {HOST_ANO_MOV_ABERTO} {HOST_MES_MOV_ABERTO}"
                .Display();

                /*" -745- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0250-00-LE-PENULT-DIA-MES-DB-SELECT-1 */
        public void R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1()
        {
            /*" -736- EXEC SQL SELECT VALUE(MAX(A.DATA_CALENDARIO), '0001-01-01' ) INTO :HOST-DATA-PENULT-DIA-MES FROM SEGUROS.CALENDARIO A WHERE YEAR(A.DATA_CALENDARIO) = :HOST-ANO-MOV-ABERTO AND MONTH(A.DATA_CALENDARIO) = :HOST-MES-MOV-ABERTO AND A.DIA_SEMANA NOT IN ( 'S' , 'D' ) AND A.FERIADO <> 'N' AND A.DATA_CALENDARIO < (SELECT MAX(B.DATA_CALENDARIO) FROM SEGUROS.CALENDARIO B WHERE YEAR(B.DATA_CALENDARIO) = :HOST-ANO-MOV-ABERTO AND MONTH(B.DATA_CALENDARIO) = :HOST-MES-MOV-ABERTO AND B.DIA_SEMANA NOT IN ( 'S' , 'D' ) AND B.FERIADO <> 'N' ) END-EXEC. */

            var r0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1 = new R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1()
            {
                HOST_ANO_MOV_ABERTO = HOST_ANO_MOV_ABERTO.ToString(),
                HOST_MES_MOV_ABERTO = HOST_MES_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1.Execute(r0250_00_LE_PENULT_DIA_MES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_PENULT_DIA_MES, HOST_DATA_PENULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LE-EMPRESAS-SECTION */
        private void R0300_00_LE_EMPRESAS_SECTION()
        {
            /*" -755- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -760- PERFORM R0300_00_LE_EMPRESAS_DB_SELECT_1 */

            R0300_00_LE_EMPRESAS_DB_SELECT_1();

            /*" -763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -764- DISPLAY 'PROBLEMAS NO SELECT EMPRESAS' */
                _.Display($"PROBLEMAS NO SELECT EMPRESAS");

                /*" -764- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0300-00-LE-EMPRESAS-DB-SELECT-1 */
        public void R0300_00_LE_EMPRESAS_DB_SELECT_1()
        {
            /*" -760- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0300_00_LE_EMPRESAS_DB_SELECT_1_Query1 = new R0300_00_LE_EMPRESAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0300_00_LE_EMPRESAS_DB_SELECT_1_Query1.Execute(r0300_00_LE_EMPRESAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-MONTA-CABECALHO-SECTION */
        private void R0400_00_MONTA_CABECALHO_SECTION()
        {
            /*" -774- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -777- MOVE EMPRESAS-NOME-EMPRESA TO LC01-EMPRESA */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, LC01.LC01_EMPRESA);

            /*" -779- MOVE SISTEMAS-DATA-MOV-ABERTO TO DB2-DATA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, DB2_DATA);

            /*" -780- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(DB2_DATA.DB2_DIA, EDIT_DATA.EDIT_DIA);

            /*" -781- MOVE DB2-MES TO EDIT-MES */
            _.Move(DB2_DATA.DB2_MES, EDIT_DATA.EDIT_MES);

            /*" -782- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(DB2_DATA.DB2_ANO, EDIT_DATA.EDIT_ANO);

            /*" -784- MOVE EDIT-DATA TO LC02-DATA-SISTEMA */
            _.Move(EDIT_DATA, LC02.LC02_DATA_SISTEMA);

            /*" -786- MOVE HOST-DATA-CORRENTE TO DB2-DATA */
            _.Move(HOST_DATA_CORRENTE, DB2_DATA);

            /*" -787- MOVE DB2-DIA TO EDIT-DIA */
            _.Move(DB2_DATA.DB2_DIA, EDIT_DATA.EDIT_DIA);

            /*" -788- MOVE DB2-MES TO EDIT-MES */
            _.Move(DB2_DATA.DB2_MES, EDIT_DATA.EDIT_MES);

            /*" -789- MOVE DB2-ANO TO EDIT-ANO */
            _.Move(DB2_DATA.DB2_ANO, EDIT_DATA.EDIT_ANO);

            /*" -791- MOVE EDIT-DATA TO LC03-DATA-CORRENTE */
            _.Move(EDIT_DATA, LC03.LC03_DATA_CORRENTE);

            /*" -792- WRITE REG-SI0213B1 FROM LC01 */
            _.Move(LC01.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -793- WRITE REG-SI0213B1 FROM LC02 */
            _.Move(LC02.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -794- WRITE REG-SI0213B1 FROM LC03 */
            _.Move(LC03.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -794- WRITE REG-SI0213B1 FROM LC04. */
            _.Move(LC04.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-VERIFICA-DATA-SECTION */
        private void R0500_00_VERIFICA_DATA_SECTION()
        {
            /*" -839- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -843- MOVE 'NAO' TO WTEM-PROCESSAMENTO */
            _.Move("NAO", WTEM_PROCESSAMENTO);

            /*" -844- IF SISTEMAS-DATA-MOV-ABERTO EQUAL '2007-12-21' */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO == "2007-12-21")
            {

                /*" -845- MOVE 'SIM' TO WTEM-PROCESSAMENTO */
                _.Move("SIM", WTEM_PROCESSAMENTO);

                /*" -848- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -849- IF HOST-DIA-MOV-ABERTO EQUAL 05 */

            if (HOST_DIA_MOV_ABERTO == 05)
            {

                /*" -850- MOVE 'SIM' TO WTEM-PROCESSAMENTO */
                _.Move("SIM", WTEM_PROCESSAMENTO);

                /*" -855- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -857- MOVE '-' TO W-DATA-AAAA-MM-DD-FILLER1 W-DATA-AAAA-MM-DD-FILLER2. */
            _.Move("-", W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_FILLER1, W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_FILLER2);

            /*" -859- MOVE SISTEMAS-DATA-MOV-ABERTO TO W-DATA-AAAA-MM-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W_DATA_AAAA_MM_DD);

            /*" -861- IF W-DATA-AAAA-MM-DD-DD EQUAL 27 OR 28 OR 29 OR 30 OR 31 OR 01 OR 02 OR 03 OR 04 */

            if (W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD.In("27", "28", "29", "30", "31", "01", "02", "03", "04"))
            {

                /*" -862- MOVE 05 TO W-DATA-AAAA-MM-DD-DD */
                _.Move(05, W_DATA_AAAA_MM_DD.W_DATA_AAAA_MM_DD_DD);

                /*" -867- ELSE */
            }
            else
            {


                /*" -868- MOVE 'NAO' TO WTEM-PROCESSAMENTO */
                _.Move("NAO", WTEM_PROCESSAMENTO);

                /*" -870- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -872- MOVE W-DATA-AAAA-MM-DD TO CALENDAR-DATA-CALENDARIO */
            _.Move(W_DATA_AAAA_MM_DD, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -879- PERFORM R0500_00_VERIFICA_DATA_DB_SELECT_1 */

            R0500_00_VERIFICA_DATA_DB_SELECT_1();

            /*" -883- IF (SQLCODE NOT EQUAL ZEROS) OR (HOST-DATA-ANTES-DE-05-E-20 EQUAL '0001-01-01' ) */

            if ((DB.SQLCODE != 00) || (HOST_DATA_ANTES_DE_05_E_20 == "0001-01-01"))
            {

                /*" -887- DISPLAY 'PROBLEMAS NO SELECT MAX CALENDARIO' ' ' SISTEMAS-DATA-MOV-ABERTO ' ' HOST-ANO-MOV-ABERTO ' ' HOST-MES-MOV-ABERTO */

                $"PROBLEMAS NO SELECT MAX CALENDARIO {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO} {HOST_ANO_MOV_ABERTO} {HOST_MES_MOV_ABERTO}"
                .Display();

                /*" -889- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -890- IF SISTEMAS-DATA-MOV-ABERTO EQUAL HOST-DATA-ANTES-DE-05-E-20 */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO == HOST_DATA_ANTES_DE_05_E_20)
            {

                /*" -891- MOVE 'SIM' TO WTEM-PROCESSAMENTO */
                _.Move("SIM", WTEM_PROCESSAMENTO);

                /*" -891- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-VERIFICA-DATA-DB-SELECT-1 */
        public void R0500_00_VERIFICA_DATA_DB_SELECT_1()
        {
            /*" -879- EXEC SQL SELECT VALUE(MAX(A.DATA_CALENDARIO), '0001-01-01' ) INTO :HOST-DATA-ANTES-DE-05-E-20 FROM SEGUROS.CALENDARIO A WHERE A.DATA_CALENDARIO <= :CALENDAR-DATA-CALENDARIO AND A.DIA_SEMANA NOT IN ( 'S' , 'D' ) AND A.FERIADO <> 'N' END-EXEC. */

            var r0500_00_VERIFICA_DATA_DB_SELECT_1_Query1 = new R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0500_00_VERIFICA_DATA_DB_SELECT_1_Query1.Execute(r0500_00_VERIFICA_DATA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_DATA_ANTES_DE_05_E_20, HOST_DATA_ANTES_DE_05_E_20);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-LE-RELATORI-SECTION */
        private void R0600_00_LE_RELATORI_SECTION()
        {
            /*" -901- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -906- PERFORM R0600_00_LE_RELATORI_DB_SELECT_1 */

            R0600_00_LE_RELATORI_DB_SELECT_1();

            /*" -909- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -910- MOVE 'SIM' TO WTEM-SOLICITACAO */
                _.Move("SIM", WTEM_SOLICITACAO);

                /*" -911- ELSE */
            }
            else
            {


                /*" -912- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -913- DISPLAY 'PROBLEMAS NO SELECT RELATORIOS' */
                    _.Display($"PROBLEMAS NO SELECT RELATORIOS");

                    /*" -913- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0600-00-LE-RELATORI-DB-SELECT-1 */
        public void R0600_00_LE_RELATORI_DB_SELECT_1()
        {
            /*" -906- EXEC SQL SELECT PERI_INICIAL INTO :RELATORI-PERI-INICIAL FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0213B1' END-EXEC. */

            var r0600_00_LE_RELATORI_DB_SELECT_1_Query1 = new R0600_00_LE_RELATORI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0600_00_LE_RELATORI_DB_SELECT_1_Query1.Execute(r0600_00_LE_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-CONTA-REPASSE-SECTION */
        private void R0650_00_CONTA_REPASSE_SECTION()
        {
            /*" -923- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", WABEND.WNR_EXEC_SQL);

            /*" -966- PERFORM R0650_00_CONTA_REPASSE_DB_SELECT_1 */

            R0650_00_CONTA_REPASSE_DB_SELECT_1();

            /*" -969- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -972- DISPLAY 'PROBLEMAS NO COUNT SI_RESSARC_PARCELA' ' ' SINISHIS-COD-OPERACAO ' ' HOST-COD-OPERACAO-PAG */

                $"PROBLEMAS NO COUNT SI_RESSARC_PARCELA {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {HOST_COD_OPERACAO_PAG}"
                .Display();

                /*" -972- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0650-00-CONTA-REPASSE-DB-SELECT-1 */
        public void R0650_00_CONTA_REPASSE_DB_SELECT_1()
        {
            /*" -966- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :HOST-COUNT-REPASSE FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.FORNECEDORES F WHERE H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND F.TIPO_REGISTRO = '4' AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = P.OCORR_HISTORICO AND H.COD_OPERACAO = P.COD_OPERACAO AND H.DATA_MOVIMENTO >= :HOST-DATA-SISTEMA-MENOS-60DIAS AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR AND NOT EXISTS (SELECT W.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO W WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND W.OCORR_HISTORICO = H.OCORR_HISTORICO AND W.COD_OPERACAO = :HOST-COD-OPERACAO-PAG) AND EXISTS (SELECT Z.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO Z WHERE Z.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND Z.OCORR_HISTORICO = H.OCORR_HISTORICO AND Z.COD_OPERACAO = 4100) AND NOT EXISTS (SELECT T.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO T WHERE T.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND T.OCORR_HISTORICO = H.OCORR_HISTORICO AND T.COD_OPERACAO = 4120) AND NOT EXISTS (SELECT Y.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_LANCLOTE1 Y, SEGUROS.SINISTRO_CAPALOTE1 V WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO AND Y.COD_OPERACAO = H.COD_OPERACAO AND V.COD_FONTE = Y.COD_FONTE AND V.NUM_LOTE = Y.NUM_LOTE AND V.SITUACAO_LOTE <> 'C' ) END-EXEC. */

            var r0650_00_CONTA_REPASSE_DB_SELECT_1_Query1 = new R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1()
            {
                HOST_DATA_SISTEMA_MENOS_60DIAS = HOST_DATA_SISTEMA_MENOS_60DIAS.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                HOST_COD_OPERACAO_PAG = HOST_COD_OPERACAO_PAG.ToString(),
            };

            var executed_1 = R0650_00_CONTA_REPASSE_DB_SELECT_1_Query1.Execute(r0650_00_CONTA_REPASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT_REPASSE, HOST_COUNT_REPASSE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-LE-CALENDAR-SECTION */
        private void R0700_00_LE_CALENDAR_SECTION()
        {
            /*" -982- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -987- PERFORM R0700_00_LE_CALENDAR_DB_SELECT_1 */

            R0700_00_LE_CALENDAR_DB_SELECT_1();

            /*" -990- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -991- DISPLAY 'PROBLEMAS NO SELECT CALENDARIO' */
                _.Display($"PROBLEMAS NO SELECT CALENDARIO");

                /*" -991- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-LE-CALENDAR-DB-SELECT-1 */
        public void R0700_00_LE_CALENDAR_DB_SELECT_1()
        {
            /*" -987- EXEC SQL SELECT (DATA_CALENDARIO - 60 DAYS) INTO :CALENDAR-DATA-CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO END-EXEC. */

            var r0700_00_LE_CALENDAR_DB_SELECT_1_Query1 = new R0700_00_LE_CALENDAR_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = R0700_00_LE_CALENDAR_DB_SELECT_1_Query1.Execute(r0700_00_LE_CALENDAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-EXCLUI-RELATORI-SECTION */
        private void R0800_00_EXCLUI_RELATORI_SECTION()
        {
            /*" -1001- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -1004- PERFORM R0800_00_EXCLUI_RELATORI_DB_DELETE_1 */

            R0800_00_EXCLUI_RELATORI_DB_DELETE_1();

            /*" -1007- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1008- DISPLAY 'PROBLEMAS NO DELETE RELATORIOS' */
                _.Display($"PROBLEMAS NO DELETE RELATORIOS");

                /*" -1008- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0800-00-EXCLUI-RELATORI-DB-DELETE-1 */
        public void R0800_00_EXCLUI_RELATORI_DB_DELETE_1()
        {
            /*" -1004- EXEC SQL DELETE FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0213B1' END-EXEC. */

            var r0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1 = new R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1()
            {
            };

            R0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1.Execute(r0800_00_EXCLUI_RELATORI_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARA-SINISHIS-SECTION */
        private void R0900_00_DECLARA_SINISHIS_SECTION()
        {
            /*" -1018- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -1104- PERFORM R0900_00_DECLARA_SINISHIS_DB_DECLARE_1 */

            R0900_00_DECLARA_SINISHIS_DB_DECLARE_1();

            /*" -1106- PERFORM R0900_00_DECLARA_SINISHIS_DB_OPEN_1 */

            R0900_00_DECLARA_SINISHIS_DB_OPEN_1();

            /*" -1109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1110- DISPLAY 'PROBLEMAS NO OPEN SINISTRO_HISTORICO' */
                _.Display($"PROBLEMAS NO OPEN SINISTRO_HISTORICO");

                /*" -1110- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARA-SINISHIS-DB-DECLARE-1 */
        public void R0900_00_DECLARA_SINISHIS_DB_DECLARE_1()
        {
            /*" -1104- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT H.COD_PREST_SERVICO, H.SIT_CONTABIL, H.DATA_MOVIMENTO, H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO, P.NUM_RESSARC, P.SEQ_RESSARC, P.NUM_PARCELA, H.VAL_OPERACAO, F.NOME_FORNECEDOR, F.CGCCPF, F.TIPO_PESSOA, VALUE(F.COD_BANCO, 0), VALUE(F.COD_AGENCIA, 0), VALUE(F.NUM_CTA_CORRENTE, 0) FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.FORNECEDORES F WHERE H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND F.TIPO_REGISTRO = '4' AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = P.OCORR_HISTORICO AND H.COD_OPERACAO = P.COD_OPERACAO AND H.DATA_MOVIMENTO >= :HOST-DATA-SISTEMA-MENOS-60DIAS AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR AND H.SIT_REGISTRO <> '2' AND H.COD_PREST_SERVICO <> 2288714 AND NOT EXISTS (SELECT W.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO W WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND W.OCORR_HISTORICO = H.OCORR_HISTORICO AND W.COD_OPERACAO = :HOST-COD-OPERACAO-PAG) AND EXISTS ( SELECT YY.OCORR_HISTORICO FROM SEGUROS.SI_RESSARC_PARCELA YY WHERE YY.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND YY.NUM_RESSARC = P.NUM_RESSARC AND YY.NUM_PARCELA = P.NUM_PARCELA AND YY.COD_OPERACAO = 4100 AND NOT EXISTS (SELECT 1 FROM SEGUROS.SI_RESSARC_PARCELA ABC WHERE ABC.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND ABC.OCORR_HISTORICO = YY.OCORR_HISTORICO AND ABC.COD_OPERACAO = 4120) ) AND NOT EXISTS (SELECT Y.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_LANCLOTE1 Y, SEGUROS.SINISTRO_CAPALOTE1 V WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO AND Y.COD_OPERACAO = H.COD_OPERACAO AND V.COD_FONTE = Y.COD_FONTE AND V.NUM_LOTE = Y.NUM_LOTE AND V.SITUACAO_LOTE <> 'C' ) ORDER BY H.SIT_CONTABIL, H.COD_PREST_SERVICO, H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO END-EXEC. */
            C01_SINISHIS = new SI0213B_C01_SINISHIS(true);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT H.COD_PREST_SERVICO
							, 
							H.SIT_CONTABIL
							, 
							H.DATA_MOVIMENTO
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO
							, 
							P.NUM_RESSARC
							, 
							P.SEQ_RESSARC
							, 
							P.NUM_PARCELA
							, 
							H.VAL_OPERACAO
							, 
							F.NOME_FORNECEDOR
							, 
							F.CGCCPF
							, 
							F.TIPO_PESSOA
							, 
							VALUE(F.COD_BANCO
							, 0)
							, 
							VALUE(F.COD_AGENCIA
							, 0)
							, 
							VALUE(F.NUM_CTA_CORRENTE
							, 0) 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SI_RESSARC_PARCELA P
							, 
							SEGUROS.FORNECEDORES F 
							WHERE H.COD_OPERACAO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}' 
							AND F.TIPO_REGISTRO = '4' 
							AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO 
							AND H.OCORR_HISTORICO = P.OCORR_HISTORICO 
							AND H.COD_OPERACAO = P.COD_OPERACAO 
							AND H.DATA_MOVIMENTO >= '{HOST_DATA_SISTEMA_MENOS_60DIAS}' 
							AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR 
							AND H.SIT_REGISTRO <> '2' 
							AND H.COD_PREST_SERVICO <> 2288714 
							AND NOT EXISTS 
							(SELECT W.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO W 
							WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND W.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND W.COD_OPERACAO = '{HOST_COD_OPERACAO_PAG}') 
							AND EXISTS ( 
							SELECT YY.OCORR_HISTORICO 
							FROM SEGUROS.SI_RESSARC_PARCELA YY 
							WHERE YY.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND YY.NUM_RESSARC = P.NUM_RESSARC 
							AND YY.NUM_PARCELA = P.NUM_PARCELA 
							AND YY.COD_OPERACAO = 4100 
							AND NOT EXISTS 
							(SELECT 1 
							FROM SEGUROS.SI_RESSARC_PARCELA ABC 
							WHERE ABC.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND ABC.OCORR_HISTORICO = YY.OCORR_HISTORICO 
							AND ABC.COD_OPERACAO = 4120) 
							) 
							AND NOT EXISTS 
							(SELECT Y.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_LANCLOTE1 Y
							, 
							SEGUROS.SINISTRO_CAPALOTE1 V 
							WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND Y.COD_OPERACAO = H.COD_OPERACAO 
							AND V.COD_FONTE = Y.COD_FONTE 
							AND V.NUM_LOTE = Y.NUM_LOTE 
							AND V.SITUACAO_LOTE <> 'C' ) 
							ORDER BY H.SIT_CONTABIL
							, 
							H.COD_PREST_SERVICO
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO";

                return query;
            }
            C01_SINISHIS.GetQueryEvent += GetQuery_C01_SINISHIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARA-SINISHIS-DB-OPEN-1 */
        public void R0900_00_DECLARA_SINISHIS_DB_OPEN_1()
        {
            /*" -1106- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R2900-00-DECLARA-SINISHIS-DB-DECLARE-1 */
        public void R2900_00_DECLARA_SINISHIS_DB_DECLARE_1()
        {
            /*" -2044- EXEC SQL DECLARE SINISHIS2 CURSOR FOR SELECT H.COD_PREST_SERVICO, H.SIT_CONTABIL, H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO, P.NUM_RESSARC, P.SEQ_RESSARC, P.NUM_PARCELA, H.VAL_OPERACAO, F.NOME_FORNECEDOR, F.CGCCPF, F.TIPO_PESSOA, VALUE(F.COD_BANCO, 0), VALUE(F.COD_AGENCIA, 0), VALUE(F.NUM_CTA_CORRENTE, 0) FROM SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SI_RESSARC_PARCELA P, SEGUROS.FORNECEDORES F WHERE H.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND F.TIPO_REGISTRO = '4' AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO AND H.OCORR_HISTORICO = P.OCORR_HISTORICO AND H.COD_OPERACAO = P.COD_OPERACAO AND P.DTH_PAGAMENTO >= '2004-09-15' AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR AND H.NOM_PROGRAMA = 'SI1051S' AND NOT EXISTS (SELECT W.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO W WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND W.OCORR_HISTORICO = H.OCORR_HISTORICO AND W.COD_OPERACAO = :HOST-COD-OPERACAO-PAG) AND NOT EXISTS (SELECT Z.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO Z WHERE Z.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND Z.OCORR_HISTORICO = H.OCORR_HISTORICO AND Z.COD_OPERACAO = 4100) AND NOT EXISTS (SELECT T.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO T WHERE T.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND T.OCORR_HISTORICO = H.OCORR_HISTORICO AND T.COD_OPERACAO = 4120) AND NOT EXISTS (SELECT Y.NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_LANCLOTE1 Y, SEGUROS.SINISTRO_CAPALOTE1 V WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO AND Y.COD_OPERACAO = H.COD_OPERACAO AND V.COD_FONTE = Y.COD_FONTE AND V.NUM_LOTE = Y.NUM_LOTE AND V.SITUACAO_LOTE <> 'C' ) ORDER BY H.SIT_CONTABIL, H.COD_PREST_SERVICO, H.NUM_APOL_SINISTRO, H.OCORR_HISTORICO, H.COD_OPERACAO END-EXEC. */
            SINISHIS2 = new SI0213B_SINISHIS2(true);
            string GetQuery_SINISHIS2()
            {
                var query = @$"SELECT H.COD_PREST_SERVICO
							, 
							H.SIT_CONTABIL
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO
							, 
							P.NUM_RESSARC
							, 
							P.SEQ_RESSARC
							, 
							P.NUM_PARCELA
							, 
							H.VAL_OPERACAO
							, 
							F.NOME_FORNECEDOR
							, 
							F.CGCCPF
							, 
							F.TIPO_PESSOA
							, 
							VALUE(F.COD_BANCO
							, 0)
							, 
							VALUE(F.COD_AGENCIA
							, 0)
							, 
							VALUE(F.NUM_CTA_CORRENTE
							, 0) 
							FROM SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SI_RESSARC_PARCELA P
							, 
							SEGUROS.FORNECEDORES F 
							WHERE H.COD_OPERACAO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}' 
							AND F.TIPO_REGISTRO = '4' 
							AND H.NUM_APOL_SINISTRO = P.NUM_APOL_SINISTRO 
							AND H.OCORR_HISTORICO = P.OCORR_HISTORICO 
							AND H.COD_OPERACAO = P.COD_OPERACAO 
							AND P.DTH_PAGAMENTO >= '2004-09-15' 
							AND H.COD_PREST_SERVICO = F.COD_FORNECEDOR 
							AND H.NOM_PROGRAMA = 'SI1051S' 
							AND NOT EXISTS 
							(SELECT W.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO W 
							WHERE W.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND W.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND W.COD_OPERACAO = 
							'{HOST_COD_OPERACAO_PAG}') 
							AND NOT EXISTS 
							(SELECT Z.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO Z 
							WHERE Z.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND Z.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND Z.COD_OPERACAO = 4100) 
							AND NOT EXISTS 
							(SELECT T.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO T 
							WHERE T.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND T.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND T.COD_OPERACAO = 4120) 
							AND NOT EXISTS 
							(SELECT Y.NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_LANCLOTE1 Y
							, 
							SEGUROS.SINISTRO_CAPALOTE1 V 
							WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO 
							AND Y.COD_OPERACAO = H.COD_OPERACAO 
							AND V.COD_FONTE = Y.COD_FONTE 
							AND V.NUM_LOTE = Y.NUM_LOTE 
							AND V.SITUACAO_LOTE <> 'C' ) 
							ORDER BY H.SIT_CONTABIL
							, 
							H.COD_PREST_SERVICO
							, 
							H.NUM_APOL_SINISTRO
							, 
							H.OCORR_HISTORICO
							, 
							H.COD_OPERACAO";

                return query;
            }
            SINISHIS2.GetQueryEvent += GetQuery_SINISHIS2;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-SINISHIS-SECTION */
        private void R0910_00_LE_SINISHIS_SECTION()
        {
            /*" -1120- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -1137- PERFORM R0910_00_LE_SINISHIS_DB_FETCH_1 */

            R0910_00_LE_SINISHIS_DB_FETCH_1();

            /*" -1140- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -1141- IF (W-SIT-CONTABIL-ANT = SPACE) */

                if ((W_SIT_CONTABIL_ANT == " "))
                {

                    /*" -1142- MOVE SINISHIS-SIT-CONTABIL TO W-SIT-CONTABIL-ANT */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL, W_SIT_CONTABIL_ANT);

                    /*" -1143- END-IF */
                }


                /*" -1144- ADD 1 TO AC-L-SINISHIS */
                AC_L_SINISHIS.Value = AC_L_SINISHIS + 1;

                /*" -1145- ELSE */
            }
            else
            {


                /*" -1146- IF (SQLCODE = 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -1147- MOVE 'SIM' TO WFIM-SINISHIS */
                    _.Move("SIM", WFIM_SINISHIS);

                    /*" -1147- PERFORM R0910_00_LE_SINISHIS_DB_CLOSE_1 */

                    R0910_00_LE_SINISHIS_DB_CLOSE_1();

                    /*" -1149- ELSE */
                }
                else
                {


                    /*" -1150- DISPLAY 'PROBLEMAS NO FETCH SINISTRO_HISTORICO' */
                    _.Display($"PROBLEMAS NO FETCH SINISTRO_HISTORICO");

                    /*" -1151- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1152- END-IF */
                }


                /*" -1156- END-IF. */
            }


            /*" -1159- IF (W-SELECAO-REPASSE EQUAL 'SIM' ) AND (SINISHIS-COD-OPERACAO EQUAL 4290) AND (SINISHIS-DATA-MOVIMENTO LESS W-DATA-PRE-LIB-REPASSE) */

            if ((W_SELECAO_REPASSE == "SIM") && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4290) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO < W_DATA_PRE_LIB_REPASSE))
            {

                /*" -1160- GO TO R0910-00-LE-SINISHIS */
                new Task(() => R0910_00_LE_SINISHIS_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1160- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-LE-SINISHIS-DB-FETCH-1 */
        public void R0910_00_LE_SINISHIS_DB_FETCH_1()
        {
            /*" -1137- EXEC SQL FETCH C01_SINISHIS INTO :SINISHIS-COD-PREST-SERVICO, :SINISHIS-SIT-CONTABIL, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SINISHIS-VAL-OPERACAO, :FORNECED-NOME-FORNECEDOR, :FORNECED-CGCCPF, :FORNECED-TIPO-PESSOA, :FORNECED-COD-BANCO, :FORNECED-COD-AGENCIA, :FORNECED-NUM-CTA-CORRENTE END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(C01_SINISHIS.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(C01_SINISHIS.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(C01_SINISHIS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(C01_SINISHIS.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(C01_SINISHIS.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(C01_SINISHIS.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(C01_SINISHIS.SI111_SEQ_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC);
                _.Move(C01_SINISHIS.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(C01_SINISHIS.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(C01_SINISHIS.FORNECED_NOME_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR);
                _.Move(C01_SINISHIS.FORNECED_CGCCPF, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);
                _.Move(C01_SINISHIS.FORNECED_TIPO_PESSOA, FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA);
                _.Move(C01_SINISHIS.FORNECED_COD_BANCO, FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO);
                _.Move(C01_SINISHIS.FORNECED_COD_AGENCIA, FORNECED.DCLFORNECEDORES.FORNECED_COD_AGENCIA);
                _.Move(C01_SINISHIS.FORNECED_NUM_CTA_CORRENTE, FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE);
            }

        }

        [StopWatch]
        /*" R0910-00-LE-SINISHIS-DB-CLOSE-1 */
        public void R0910_00_LE_SINISHIS_DB_CLOSE_1()
        {
            /*" -1147- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -1172- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -1175- MOVE SINISHIS-COD-PREST-SERVICO TO WS-COD-PREST-SERVICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, WS_COD_PREST_SERVICO);

            /*" -1177- PERFORM R1100-00-GERA-DOC-FISCAL */

            R1100_00_GERA_DOC_FISCAL_SECTION();

            /*" -1178- MOVE 'SI0213B' TO SINISCAP-COD-USUARIO */
            _.Move("SI0213B", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_USUARIO);

            /*" -1180- PERFORM R1200-00-GERA-LOTE */

            R1200_00_GERA_LOTE_SECTION();

            /*" -1182- WRITE REG-SI0213B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -1192- PERFORM R2000-00-PROCESSA-FORNECEDOR UNTIL WFIM-SINISHIS = 'SIM' OR SINISHIS-COD-PREST-SERVICO NOT = WS-COD-PREST-SERVICO OR ( SINISHIS-SIT-CONTABIL NOT = W-SIT-CONTABIL-ANT AND (W-SIT-CONTABIL-ANT = 1) AND (SINISHIS-COD-OPERACAO = 4290) ) */

            while (!(WFIM_SINISHIS == "SIM" || SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO != WS_COD_PREST_SERVICO || (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL != W_SIT_CONTABIL_ANT && (W_SIT_CONTABIL_ANT == 1) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4290))))
            {

                R2000_00_PROCESSA_FORNECEDOR_SECTION();
            }

            /*" -1194- MOVE SINISHIS-SIT-CONTABIL TO W-SIT-CONTABIL-ANT. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL, W_SIT_CONTABIL_ANT);

            /*" -1194- PERFORM R1300-00-ALTERA-SINISCAP. */

            R1300_00_ALTERA_SINISCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERA-DOC-FISCAL-SECTION */
        private void R1100_00_GERA_DOC_FISCAL_SECTION()
        {
            /*" -1204- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -1206- PERFORM R1110-00-MAX-FIPADOFI */

            R1110_00_MAX_FIPADOFI_SECTION();

            /*" -1208- ADD 1 TO FIPADOFI-NUM-DOCF-INTERNO */
            FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO.Value = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO + 1;

            /*" -1209- MOVE 10 TO FIPADOFI-COD-FONTE-LANC */
            _.Move(10, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_FONTE_LANC);

            /*" -1210- MOVE 7 TO FIPADOFI-IDTAB-FORNECEDOR */
            _.Move(7, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_IDTAB_FORNECEDOR);

            /*" -1211- MOVE '4' TO FIPADOFI-COD-CH1-FORNECEDOR */
            _.Move("4", FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_CH1_FORNECEDOR);

            /*" -1212- MOVE 8 TO FIPADOFI-IDTAB-DOC-FISCAL */
            _.Move(8, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_IDTAB_DOC_FISCAL);

            /*" -1213- MOVE '1' TO FIPADOFI-COD-CH1-DOC-FISCAL */
            _.Move("1", FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_CH1_DOC_FISCAL);

            /*" -1214- MOVE '4' TO FIPADOFI-TIPO-MOVIMENTO */
            _.Move("4", FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_TIPO_MOVIMENTO);

            /*" -1215- MOVE ZEROS TO FIPADOFI-COD-EMPRESA */
            _.Move(0, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_EMPRESA);

            /*" -1216- MOVE ZEROS TO FIPADOFI-NUM-DOC-FISCAL */
            _.Move(0, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL);

            /*" -1219- MOVE ' ' TO FIPADOFI-SERIE-DOC-FISCAL */
            _.Move(" ", FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL);

            /*" -1219- PERFORM R1120-00-INCLUI-FIPADOFI. */

            R1120_00_INCLUI_FIPADOFI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-MAX-FIPADOFI-SECTION */
        private void R1110_00_MAX_FIPADOFI_SECTION()
        {
            /*" -1229- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", WABEND.WNR_EXEC_SQL);

            /*" -1233- PERFORM R1110_00_MAX_FIPADOFI_DB_SELECT_1 */

            R1110_00_MAX_FIPADOFI_DB_SELECT_1();

            /*" -1236- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1241- DISPLAY 'PROBLEMAS NO MAX FI_PAGA_DOC_FISCAL' ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' FIPADOFI-NUM-DOCF-INTERNO */

                $"PROBLEMAS NO MAX FI_PAGA_DOC_FISCAL {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO}"
                .Display();

                /*" -1241- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1110-00-MAX-FIPADOFI-DB-SELECT-1 */
        public void R1110_00_MAX_FIPADOFI_DB_SELECT_1()
        {
            /*" -1233- EXEC SQL SELECT VALUE(MAX(NUM_DOCF_INTERNO),0) INTO :FIPADOFI-NUM-DOCF-INTERNO FROM SEGUROS.FI_PAGA_DOC_FISCAL END-EXEC */

            var r1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1 = new R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1.Execute(r1110_00_MAX_FIPADOFI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FIPADOFI_NUM_DOCF_INTERNO, FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-INCLUI-FIPADOFI-SECTION */
        private void R1120_00_INCLUI_FIPADOFI_SECTION()
        {
            /*" -1250- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", WABEND.WNR_EXEC_SQL);

            /*" -1285- PERFORM R1120_00_INCLUI_FIPADOFI_DB_INSERT_1 */

            R1120_00_INCLUI_FIPADOFI_DB_INSERT_1();

            /*" -1288- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1294- DISPLAY 'PROBLEMAS NO INSERT FI_PAGA_DOC_FISCAL' ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' FIPADOFI-NUM-DOCF-INTERNO */

                $"PROBLEMAS NO INSERT FI_PAGA_DOC_FISCAL {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO}"
                .Display();

                /*" -1294- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-INCLUI-FIPADOFI-DB-INSERT-1 */
        public void R1120_00_INCLUI_FIPADOFI_DB_INSERT_1()
        {
            /*" -1285- EXEC SQL INSERT INTO SEGUROS.FI_PAGA_DOC_FISCAL (NUM_DOCF_INTERNO, IDTAB_FORNECEDOR, COD_CH1_FORNECEDOR, COD_FORNECEDOR, IDTAB_DOC_FISCAL, COD_CH1_DOC_FISCAL, COD_FONTE_LANC, TIPO_MOVIMENTO, COD_EMPRESA, NUM_CHEQUE_INTERNO, NUM_DOC_FISCAL, SERIE_DOC_FISCAL, DATA_EMISSAO_DOC, CGCCPF, DATA_MOVIMENTO, TIMESTAMP) VALUES (:FIPADOFI-NUM-DOCF-INTERNO, :FIPADOFI-IDTAB-FORNECEDOR, :FIPADOFI-COD-CH1-FORNECEDOR, :SINISHIS-COD-PREST-SERVICO, :FIPADOFI-IDTAB-DOC-FISCAL, :FIPADOFI-COD-CH1-DOC-FISCAL, :FIPADOFI-COD-FONTE-LANC, :FIPADOFI-TIPO-MOVIMENTO, :FIPADOFI-COD-EMPRESA, NULL, :FIPADOFI-NUM-DOC-FISCAL, :FIPADOFI-SERIE-DOC-FISCAL, NULL, :FORNECED-CGCCPF, :SISTEMAS-DATA-MOV-ABERTO, CURRENT TIMESTAMP) END-EXEC. */

            var r1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1 = new R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1()
            {
                FIPADOFI_NUM_DOCF_INTERNO = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO.ToString(),
                FIPADOFI_IDTAB_FORNECEDOR = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_IDTAB_FORNECEDOR.ToString(),
                FIPADOFI_COD_CH1_FORNECEDOR = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_CH1_FORNECEDOR.ToString(),
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
                FIPADOFI_IDTAB_DOC_FISCAL = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_IDTAB_DOC_FISCAL.ToString(),
                FIPADOFI_COD_CH1_DOC_FISCAL = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_CH1_DOC_FISCAL.ToString(),
                FIPADOFI_COD_FONTE_LANC = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_FONTE_LANC.ToString(),
                FIPADOFI_TIPO_MOVIMENTO = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_TIPO_MOVIMENTO.ToString(),
                FIPADOFI_COD_EMPRESA = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_COD_EMPRESA.ToString(),
                FIPADOFI_NUM_DOC_FISCAL = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOC_FISCAL.ToString(),
                FIPADOFI_SERIE_DOC_FISCAL = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_SERIE_DOC_FISCAL.ToString(),
                FORNECED_CGCCPF = FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1.Execute(r1120_00_INCLUI_FIPADOFI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GERA-LOTE-SECTION */
        private void R1200_00_GERA_LOTE_SECTION()
        {
            /*" -1304- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -1305- MOVE 10 TO SINNUMLO-COD-FONTE */
            _.Move(10, SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE);

            /*" -1307- PERFORM R1210-00-LE-SINNUMLO */

            R1210_00_LE_SINNUMLO_SECTION();

            /*" -1308- IF (SINNUMLO-NUM-LOTE = 0) */

            if ((SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE == 0))
            {

                /*" -1309- MOVE 1 TO SINNUMLO-NUM-LOTE */
                _.Move(1, SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE);

                /*" -1310- PERFORM R1220-00-INCLUI-SINNUMLO */

                R1220_00_INCLUI_SINNUMLO_SECTION();

                /*" -1311- ELSE */
            }
            else
            {


                /*" -1312- ADD 1 TO SINNUMLO-NUM-LOTE */
                SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE.Value = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE + 1;

                /*" -1313- PERFORM R1230-00-ALTERA-SINNUMLO */

                R1230_00_ALTERA_SINNUMLO_SECTION();

                /*" -1317- END-IF. */
            }


            /*" -1319- MOVE ZEROS TO SINISCAP-QTD-LANCAMENTO SINISCAP-VAL-TOT-LANCA */
            _.Move(0, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA);

            /*" -1320- MOVE 'GERSA' TO SINISCAP-NOME-DEPTO */
            _.Move("GERSA", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NOME_DEPTO);

            /*" -1321- MOVE 10 TO SINISCAP-COD-FONTE-DEST */
            _.Move(10, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_FONTE_DEST);

            /*" -1331- MOVE 2 TO SINISCAP-IDTAB */
            _.Move(2, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IDTAB);

            /*" -1334- IF (SINISHIS-COD-PREST-SERVICO = 891733) */

            if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO == 891733))
            {

                /*" -1335- IF (SINISHIS-SIT-CONTABIL = '1' ) */

                if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL == "1"))
                {

                    /*" -1336- MOVE '1' TO SINISCAP-CODIGO-CH1 */
                    _.Move("1", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1);

                    /*" -1337- ELSE */
                }
                else
                {


                    /*" -1338- MOVE '7' TO SINISCAP-CODIGO-CH1 */
                    _.Move("7", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1);

                    /*" -1339- END-IF */
                }


                /*" -1341- ELSE */
            }
            else
            {


                /*" -1344- IF (FORNECED-COD-BANCO NOT = 0) AND (FORNECED-COD-AGENCIA NOT = 0) AND (FORNECED-NUM-CTA-CORRENTE NOT = 0) */

                if ((FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO != 0) && (FORNECED.DCLFORNECEDORES.FORNECED_COD_AGENCIA != 0) && (FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE != 0))
                {

                    /*" -1345- MOVE '2' TO SINISCAP-CODIGO-CH1 */
                    _.Move("2", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1);

                    /*" -1346- ELSE */
                }
                else
                {


                    /*" -1347- MOVE '1' TO SINISCAP-CODIGO-CH1 */
                    _.Move("1", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1);

                    /*" -1348- END-IF */
                }


                /*" -1351- END-IF. */
            }


            /*" -1360- MOVE 3 TO SINISCAP-COD-SISTEMA-ORIGEM */
            _.Move(3, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SISTEMA_ORIGEM);

            /*" -1363- IF (SINISHIS-COD-OPERACAO = 4290) */

            if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4290))
            {

                /*" -1364- MOVE '3' TO SINISCAP-SITUACAO-LOTE */
                _.Move("3", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_SITUACAO_LOTE);

                /*" -1365- MOVE 0 TO I-DT-LIBERA-PAGTO */
                _.Move(0, I_DT_LIBERA_PAGTO);

                /*" -1366- MOVE 0 TO I-DT-PAGAMENTO */
                _.Move(0, I_DT_PAGAMENTO);

                /*" -1387- MOVE SISTEMAS-DATA-MOV-ABERTO TO SINISCAP-DT-LIBERA-PAGTO SINISCAP-DT-PAGAMENTO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_DT_LIBERA_PAGTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_DT_PAGAMENTO);

                /*" -1389- ELSE */
            }
            else
            {


                /*" -1390- MOVE '1' TO SINISCAP-SITUACAO-LOTE */
                _.Move("1", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_SITUACAO_LOTE);

                /*" -1392- MOVE SPACES TO SINISCAP-DT-LIBERA-PAGTO SINISCAP-DT-PAGAMENTO */
                _.Move("", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_DT_LIBERA_PAGTO, SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_DT_PAGAMENTO);

                /*" -1393- MOVE -1 TO I-DT-LIBERA-PAGTO */
                _.Move(-1, I_DT_LIBERA_PAGTO);

                /*" -1394- MOVE -1 TO I-DT-PAGAMENTO */
                _.Move(-1, I_DT_PAGAMENTO);

                /*" -1396- END-IF. */
            }


            /*" -1396- PERFORM R1240-00-INCLUI-SINISCAP. */

            R1240_00_INCLUI_SINISCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-LE-SINNUMLO-SECTION */
        private void R1210_00_LE_SINNUMLO_SECTION()
        {
            /*" -1406- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -1413- PERFORM R1210_00_LE_SINNUMLO_DB_SELECT_1 */

            R1210_00_LE_SINNUMLO_DB_SELECT_1();

            /*" -1416- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1417- MOVE ZEROS TO SINNUMLO-NUM-LOTE */
                _.Move(0, SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE);

                /*" -1418- ELSE */
            }
            else
            {


                /*" -1419- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1424- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_NUM_LOTE' ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                    $"PROBLEMAS NO SELECT SINISTRO_NUM_LOTE {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                    .Display();

                    /*" -1424- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-00-LE-SINNUMLO-DB-SELECT-1 */
        public void R1210_00_LE_SINNUMLO_DB_SELECT_1()
        {
            /*" -1413- EXEC SQL SELECT NUM_LOTE, TIMESTAMP INTO :SINNUMLO-NUM-LOTE, :SINNUMLO-TIMESTAMP FROM SEGUROS.SINISTRO_NUM_LOTE WHERE COD_FONTE = :SINNUMLO-COD-FONTE END-EXEC */

            var r1210_00_LE_SINNUMLO_DB_SELECT_1_Query1 = new R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1()
            {
                SINNUMLO_COD_FONTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE.ToString(),
            };

            var executed_1 = R1210_00_LE_SINNUMLO_DB_SELECT_1_Query1.Execute(r1210_00_LE_SINNUMLO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINNUMLO_NUM_LOTE, SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE);
                _.Move(executed_1.SINNUMLO_TIMESTAMP, SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-INCLUI-SINNUMLO-SECTION */
        private void R1220_00_INCLUI_SINNUMLO_SECTION()
        {
            /*" -1434- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", WABEND.WNR_EXEC_SQL);

            /*" -1442- PERFORM R1220_00_INCLUI_SINNUMLO_DB_INSERT_1 */

            R1220_00_INCLUI_SINNUMLO_DB_INSERT_1();

            /*" -1445- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1452- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_NUM_LOTE' ' ' SINNUMLO-COD-FONTE ' ' SINNUMLO-NUM-LOTE ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO INSERT SINISTRO_NUM_LOTE {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE} {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1452- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1220-00-INCLUI-SINNUMLO-DB-INSERT-1 */
        public void R1220_00_INCLUI_SINNUMLO_DB_INSERT_1()
        {
            /*" -1442- EXEC SQL INSERT INTO SEGUROS.SINISTRO_NUM_LOTE (COD_FONTE, NUM_LOTE, TIMESTAMP) VALUES (:SINNUMLO-COD-FONTE, :SINNUMLO-NUM-LOTE, CURRENT TIMESTAMP) END-EXEC. */

            var r1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1 = new R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1()
            {
                SINNUMLO_COD_FONTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE.ToString(),
                SINNUMLO_NUM_LOTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE.ToString(),
            };

            R1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1.Execute(r1220_00_INCLUI_SINNUMLO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-ALTERA-SINNUMLO-SECTION */
        private void R1230_00_ALTERA_SINNUMLO_SECTION()
        {
            /*" -1462- MOVE '1230' TO WNR-EXEC-SQL. */
            _.Move("1230", WABEND.WNR_EXEC_SQL);

            /*" -1468- PERFORM R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1 */

            R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1();

            /*" -1471- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1478- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_NUM_LOTE' ' ' SINNUMLO-COD-FONTE ' ' SINNUMLO-NUM-LOTE ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO UPDATE SINISTRO_NUM_LOTE {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE} {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1478- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1230-00-ALTERA-SINNUMLO-DB-UPDATE-1 */
        public void R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1()
        {
            /*" -1468- EXEC SQL UPDATE SEGUROS.SINISTRO_NUM_LOTE SET NUM_LOTE = :SINNUMLO-NUM-LOTE, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SINNUMLO-COD-FONTE AND TIMESTAMP = :SINNUMLO-TIMESTAMP END-EXEC */

            var r1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1 = new R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1()
            {
                SINNUMLO_NUM_LOTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE.ToString(),
                SINNUMLO_COD_FONTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE.ToString(),
                SINNUMLO_TIMESTAMP = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_TIMESTAMP.ToString(),
            };

            R1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1.Execute(r1230_00_ALTERA_SINNUMLO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/

        [StopWatch]
        /*" R1240-00-INCLUI-SINISCAP-SECTION */
        private void R1240_00_INCLUI_SINISCAP_SECTION()
        {
            /*" -1488- MOVE '1240' TO WNR-EXEC-SQL. */
            _.Move("1240", WABEND.WNR_EXEC_SQL);

            /*" -1536- PERFORM R1240_00_INCLUI_SINISCAP_DB_INSERT_1 */

            R1240_00_INCLUI_SINISCAP_DB_INSERT_1();

            /*" -1539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1546- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_NUM_LOTE' ' ' SINNUMLO-COD-FONTE ' ' SINNUMLO-NUM-LOTE ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO INSERT SINISTRO_NUM_LOTE {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE} {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1548- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1549- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1557- DISPLAY 'INSERIDA A CAPA DE LOTE ' ' ' SINNUMLO-COD-FONTE ' ' SINNUMLO-NUM-LOTE ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NOME-FAVORECIDO ' QTD ' SINISCAP-QTD-LANCAMENTO ' VAL ' SINISCAP-VAL-TOT-LANCA. */

                $"INSERIDA A CAPA DE LOTE  {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE} {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO} QTD {SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO} VAL {SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA}"
                .Display();
            }


            /*" -1557- ADD 1 TO AC-I-SINISCAP. */
            AC_I_SINISCAP.Value = AC_I_SINISCAP + 1;

        }

        [StopWatch]
        /*" R1240-00-INCLUI-SINISCAP-DB-INSERT-1 */
        public void R1240_00_INCLUI_SINISCAP_DB_INSERT_1()
        {
            /*" -1536- EXEC SQL INSERT INTO SEGUROS.SINISTRO_CAPALOTE1 (COD_FONTE, NUM_LOTE, COD_PREST_SERVICO, NUM_CHEQUE_INTERNO, DIG_CHEQUE_INTERNO, QTD_LANCAMENTO, VAL_TOT_LANCA, DT_ABERTURA, DT_FECHAMENTO, DT_LIBERA_PAGTO, DT_PAGAMENTO, DT_CANCELA_LOTE, SITUACAO_LOTE, COD_MOEDA, COD_USUARIO, TIMESTAMP, NOME_DEPTO, COD_FONTE_DEST, IDTAB, CODIGO_CH1, NUM_DOCF_INTERNO, COD_PRODUTO, COD_SISTEMA_ORIGEM) VALUES (:SINNUMLO-COD-FONTE, :SINNUMLO-NUM-LOTE, :SINISHIS-COD-PREST-SERVICO, 0, 0, :SINISCAP-QTD-LANCAMENTO, :SINISCAP-VAL-TOT-LANCA, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SINISCAP-DT-LIBERA-PAGTO :I-DT-LIBERA-PAGTO, :SINISCAP-DT-PAGAMENTO :I-DT-PAGAMENTO, NULL, :SINISCAP-SITUACAO-LOTE, 0, :SINISCAP-COD-USUARIO, CURRENT TIMESTAMP, :SINISCAP-NOME-DEPTO, :SINISCAP-COD-FONTE-DEST, :SINISCAP-IDTAB, :SINISCAP-CODIGO-CH1, :FIPADOFI-NUM-DOCF-INTERNO, NULL, :SINISCAP-COD-SISTEMA-ORIGEM) END-EXEC. */

            var r1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1 = new R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1()
            {
                SINNUMLO_COD_FONTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE.ToString(),
                SINNUMLO_NUM_LOTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE.ToString(),
                SINISHIS_COD_PREST_SERVICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO.ToString(),
                SINISCAP_QTD_LANCAMENTO = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO.ToString(),
                SINISCAP_VAL_TOT_LANCA = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                SINISCAP_DT_LIBERA_PAGTO = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_DT_LIBERA_PAGTO.ToString(),
                I_DT_LIBERA_PAGTO = I_DT_LIBERA_PAGTO.ToString(),
                SINISCAP_DT_PAGAMENTO = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_DT_PAGAMENTO.ToString(),
                I_DT_PAGAMENTO = I_DT_PAGAMENTO.ToString(),
                SINISCAP_SITUACAO_LOTE = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_SITUACAO_LOTE.ToString(),
                SINISCAP_COD_USUARIO = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_USUARIO.ToString(),
                SINISCAP_NOME_DEPTO = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_NOME_DEPTO.ToString(),
                SINISCAP_COD_FONTE_DEST = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_FONTE_DEST.ToString(),
                SINISCAP_IDTAB = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_IDTAB.ToString(),
                SINISCAP_CODIGO_CH1 = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1.ToString(),
                FIPADOFI_NUM_DOCF_INTERNO = FIPADOFI.DCLFI_PAGA_DOC_FISCAL.FIPADOFI_NUM_DOCF_INTERNO.ToString(),
                SINISCAP_COD_SISTEMA_ORIGEM = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_SISTEMA_ORIGEM.ToString(),
            };

            R1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1.Execute(r1240_00_INCLUI_SINISCAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-ALTERA-SINISCAP-SECTION */
        private void R1300_00_ALTERA_SINISCAP_SECTION()
        {
            /*" -1567- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -1574- PERFORM R1300_00_ALTERA_SINISCAP_DB_UPDATE_1 */

            R1300_00_ALTERA_SINISCAP_DB_UPDATE_1();

            /*" -1577- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1578- ADD SQLERRD(3) TO AC-U-SINISCAP */
                AC_U_SINISCAP.Value = AC_U_SINISCAP + DB.SQLERRD[3];

                /*" -1579- ELSE */
            }
            else
            {


                /*" -1580- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1587- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_CAPALOTE1' ' ' SINNUMLO-COD-FONTE ' ' SINNUMLO-NUM-LOTE ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                    $"PROBLEMAS NO UPDATE SINISTRO_CAPALOTE1 {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE} {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                    .Display();

                    /*" -1587- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-ALTERA-SINISCAP-DB-UPDATE-1 */
        public void R1300_00_ALTERA_SINISCAP_DB_UPDATE_1()
        {
            /*" -1574- EXEC SQL UPDATE SEGUROS.SINISTRO_CAPALOTE1 SET QTD_LANCAMENTO = :SINISCAP-QTD-LANCAMENTO, VAL_TOT_LANCA = :SINISCAP-VAL-TOT-LANCA, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SINNUMLO-COD-FONTE AND NUM_LOTE = :SINNUMLO-NUM-LOTE END-EXEC */

            var r1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1 = new R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1()
            {
                SINISCAP_QTD_LANCAMENTO = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO.ToString(),
                SINISCAP_VAL_TOT_LANCA = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA.ToString(),
                SINNUMLO_COD_FONTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE.ToString(),
                SINNUMLO_NUM_LOTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE.ToString(),
            };

            R1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1.Execute(r1300_00_ALTERA_SINISCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-FORNECEDOR-SECTION */
        private void R2000_00_PROCESSA_FORNECEDOR_SECTION()
        {
            /*" -1604- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1605- MOVE 'NAO' TO WTEM-PAGAMENTO */
            _.Move("NAO", WTEM_PAGAMENTO);

            /*" -1607- PERFORM R2100-00-LE-SINISHIS */

            R2100_00_LE_SINISHIS_SECTION();

            /*" -1608- IF (WTEM-PAGAMENTO = 'SIM' ) */

            if ((WTEM_PAGAMENTO == "SIM"))
            {

                /*" -1609- GO TO R2000-10-LER */

                R2000_10_LER(); //GOTO
                return;

                /*" -1614- END-IF. */
            }


            /*" -1616- IF (SINISHIS-NUM-APOL-SINISTRO NOT = WS-NUM-APOL-SINISTRO) */

            if ((SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO != WS_NUM_APOL_SINISTRO))
            {

                /*" -1618- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-NUM-APOL-SINISTRO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, WS_NUM_APOL_SINISTRO);

                /*" -1620- MOVE 'NAO' TO WTEM-SINCREIN WTEM-SINIHAB1 */
                _.Move("NAO", WTEM_SINCREIN, WTEM_SINIHAB1);

                /*" -1622- PERFORM R2600-00-LE-SINCREIN */

                R2600_00_LE_SINCREIN_SECTION();

                /*" -1623- IF (WTEM-SINCREIN = 'NAO' ) */

                if ((WTEM_SINCREIN == "NAO"))
                {

                    /*" -1624- PERFORM R2700-00-LE-SINIHAB1 */

                    R2700_00_LE_SINIHAB1_SECTION();

                    /*" -1625- END-IF */
                }


                /*" -1630- END-IF. */
            }


            /*" -1632- PERFORM R2200-00-INCLUI-SINISLAN */

            R2200_00_INCLUI_SINISLAN_SECTION();

            /*" -1633- ADD 1 TO SINISCAP-QTD-LANCAMENTO */
            SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO.Value = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO + 1;

            /*" -1639- ADD SINISHIS-VAL-OPERACAO TO SINISCAP-VAL-TOT-LANCA */
            SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA.Value = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

            /*" -1641- IF SINISHIS-SIT-CONTABIL NOT EQUAL SINISCAP-CODIGO-CH1 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL != SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1)
            {

                /*" -1644- MOVE SINISCAP-CODIGO-CH1 TO SINISHIS-SIT-CONTABIL. */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
            }


            /*" -1648- PERFORM R2300-00-ALTERA-SINISHIS */

            R2300_00_ALTERA_SINISHIS_SECTION();

            /*" -1652- PERFORM R2400-00-LE-SINIITEM */

            R2400_00_LE_SINIITEM_SECTION();

            /*" -1656- PERFORM R2500-00-LE-SINISHIS */

            R2500_00_LE_SINISHIS_SECTION();

            /*" -1658- MOVE SINNUMLO-COD-FONTE TO LD01-COD-FONTE */
            _.Move(SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -1660- MOVE SINNUMLO-NUM-LOTE TO LD01-NUM-LOTE */
            _.Move(SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE, LD01.LD01_NUM_LOTE);

            /*" -1662- MOVE SINISHIS-COD-PREST-SERVICO TO LD01-COD-PREST-SERVICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, LD01.LD01_COD_PREST_SERVICO);

            /*" -1665- MOVE FORNECED-NOME-FORNECEDOR TO LD01-NOME-FORNECEDOR */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, LD01.LD01_NOME_FORNECEDOR);

            /*" -1667- MOVE FORNECED-CGCCPF TO WS-CGCCPF */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, WS_CGCCPF);

            /*" -1669- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -1670- MOVE WS-CPF-NUM TO EDIT-CPF-NUM */
                _.Move(WS_CPF.WS_CPF_NUM, EDIT_CPF.EDIT_CPF_NUM);

                /*" -1671- MOVE WS-CPF-DIG TO EDIT-CPF-DIG */
                _.Move(WS_CPF.WS_CPF_DIG, EDIT_CPF.EDIT_CPF_DIG);

                /*" -1672- MOVE EDIT-CPF TO LD01-CGCCPF */
                _.Move(EDIT_CPF, LD01.LD01_CGCCPF);

                /*" -1673- ELSE */
            }
            else
            {


                /*" -1674- MOVE WS-CGC-NUM TO EDIT-CGC-NUM */
                _.Move(WS_CGC.WS_CGC_NUM, EDIT_CGC.EDIT_CGC_NUM);

                /*" -1675- MOVE WS-CGC-FIL TO EDIT-CGC-FIL */
                _.Move(WS_CGC.WS_CGC_FIL, EDIT_CGC.EDIT_CGC_FIL);

                /*" -1676- MOVE WS-CGC-DIG TO EDIT-CGC-DIG */
                _.Move(WS_CGC.WS_CGC_DIG, EDIT_CGC.EDIT_CGC_DIG);

                /*" -1678- MOVE EDIT-CGC TO LD01-CGCCPF. */
                _.Move(EDIT_CGC, LD01.LD01_CGCCPF);
            }


            /*" -1680- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LD01.LD01_NUM_APOL_SINISTRO);

            /*" -1682- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_NOME_SEGURADO);

            /*" -1684- MOVE SI111-NUM-RESSARC TO LD01-NUM-RESSARC */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC, LD01.LD01_NUM_RESSARC);

            /*" -1686- MOVE SI111-NUM-PARCELA TO LD01-NUM-PARCELA */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, LD01.LD01_NUM_PARCELA);

            /*" -1688- MOVE HOST-VAL-RECEBIDO TO LD01-VAL-RECEBIDO */
            _.Move(HOST_VAL_RECEBIDO, LD01.LD01_VAL_RECEBIDO);

            /*" -1691- MOVE SINISHIS-VAL-OPERACAO TO LD01-VAL-DEVIDO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD01.LD01_VAL_DEVIDO);

            /*" -1696- MOVE 'BAIXA DE PARCELA' TO LD01-TIPO-PAGTO */
            _.Move("BAIXA DE PARCELA", LD01.LD01_TIPO_PAGTO);

            /*" -1697- IF WTEM-SINCREIN EQUAL 'SIM' */

            if (WTEM_SINCREIN == "SIM")
            {

                /*" -1699- MOVE SINCREIN-COD-SUREG TO CREINT-COD-SUREG */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG, CREINT_CONTRATO.CREINT_COD_SUREG);

                /*" -1701- MOVE SINCREIN-COD-AGENCIA TO CREINT-COD-AGENCIA */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA, CREINT_CONTRATO.CREINT_COD_AGENCIA);

                /*" -1703- MOVE SINCREIN-COD-OPERACAO TO CREINT-COD-OPERACAO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO, CREINT_CONTRATO.CREINT_COD_OPERACAO);

                /*" -1705- MOVE SINCREIN-NUM-CONTRATO TO CREINT-NUM-CONTRATO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO, CREINT_CONTRATO.CREINT_NUM_CONTRATO);

                /*" -1707- MOVE SINCREIN-CONTRATO-DIGITO TO CREINT-CONTRATO-DIG */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO, CREINT_CONTRATO.CREINT_CONTRATO_DIG);

                /*" -1708- MOVE CREINT-CONTRATO TO LD01-NUM-CONTRATO */
                _.Move(CREINT_CONTRATO, LD01.LD01_NUM_CONTRATO);

                /*" -1709- ELSE */
            }
            else
            {


                /*" -1710- IF WTEM-SINIHAB1 EQUAL 'SIM' */

                if (WTEM_SINIHAB1 == "SIM")
                {

                    /*" -1712- MOVE SINIHAB1-OPERACAO TO HABIT-OPERACAO */
                    _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, HABIT_CONTRATO.HABIT_OPERACAO);

                    /*" -1714- MOVE SINIHAB1-PONTO-VENDA TO HABIT-PONTO-VENDA */
                    _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, HABIT_CONTRATO.HABIT_PONTO_VENDA);

                    /*" -1716- MOVE SINIHAB1-NUM-CONTRATO TO HABIT-NUM-CONTRATO */
                    _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, HABIT_CONTRATO.HABIT_NUM_CONTRATO);

                    /*" -1717- MOVE HABIT-CONTRATO TO LD01-NUM-CONTRATO */
                    _.Move(HABIT_CONTRATO, LD01.LD01_NUM_CONTRATO);

                    /*" -1718- ELSE */
                }
                else
                {


                    /*" -1720- MOVE SPACES TO LD01-NUM-CONTRATO. */
                    _.Move("", LD01.LD01_NUM_CONTRATO);
                }

            }


            /*" -1720- WRITE REG-SI0213B1 FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R2000_10_LER */

            R2000_10_LER();

        }

        [StopWatch]
        /*" R2000-10-LER */
        private void R2000_10_LER(bool isPerform = false)
        {
            /*" -1724- PERFORM R0910-00-LE-SINISHIS. */

            R0910_00_LE_SINISHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-LE-SINISHIS-SECTION */
        private void R2100_00_LE_SINISHIS_SECTION()
        {
            /*" -1734- MOVE '2100' TO WNR-EXEC-SQL */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1750- PERFORM R2100_00_LE_SINISHIS_DB_SELECT_1 */

            R2100_00_LE_SINISHIS_DB_SELECT_1();

            /*" -1753- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1754- MOVE 'SIM' TO WTEM-PAGAMENTO */
                _.Move("SIM", WTEM_PAGAMENTO);

                /*" -1755- ELSE */
            }
            else
            {


                /*" -1756- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1760- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                    $"PROBLEMAS NO SELECT SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                    .Display();

                    /*" -1760- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2100-00-LE-SINISHIS-DB-SELECT-1 */
        public void R2100_00_LE_SINISHIS_DB_SELECT_1()
        {
            /*" -1750- EXEC SQL SELECT A.OCORR_HISTORICO INTO :SINISHIS-OCORR-HISTORICO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.GE_OPERACAO B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND B.IDE_SISTEMA = 'SI' AND A.COD_OPERACAO = B.COD_OPERACAO AND B.FUNCAO_OPERACAO IN ( 'RSREP' , 'RSHOP' ) AND B.IND_TIPO_FUNCAO = (SELECT C.IND_TIPO_FUNCAO FROM SEGUROS.GE_OPERACAO C WHERE C.COD_OPERACAO = :SINISHIS-COD-OPERACAO AND C.IDE_SISTEMA = 'SI' ) END-EXEC */

            var r2100_00_LE_SINISHIS_DB_SELECT_1_Query1 = new R2100_00_LE_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R2100_00_LE_SINISHIS_DB_SELECT_1_Query1.Execute(r2100_00_LE_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-INCLUI-SINISLAN-SECTION */
        private void R2200_00_INCLUI_SINISLAN_SECTION()
        {
            /*" -1770- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1792- PERFORM R2200_00_INCLUI_SINISLAN_DB_INSERT_1 */

            R2200_00_INCLUI_SINISLAN_DB_INSERT_1();

            /*" -1795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1802- DISPLAY 'PROBLEMAS NO INSERT SINISTRO_LANCLOTE1' ' ' SINNUMLO-COD-FONTE ' ' SINNUMLO-NUM-LOTE ' ' SINISHIS-COD-PREST-SERVICO ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO INSERT SINISTRO_LANCLOTE1 {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE} {SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1804- ADD 1 TO AC-I-SINISLAN. */
            AC_I_SINISLAN.Value = AC_I_SINISLAN + 1;

        }

        [StopWatch]
        /*" R2200-00-INCLUI-SINISLAN-DB-INSERT-1 */
        public void R2200_00_INCLUI_SINISLAN_DB_INSERT_1()
        {
            /*" -1792- EXEC SQL INSERT INTO SEGUROS.SINISTRO_LANCLOTE1 (COD_FONTE, NUM_LOTE, NUM_APOL_SINISTRO, OCORR_HISTORICO, COD_OPERACAO, VAL_OPERACAO, DATA_MOVIMENTO, COD_USUARIO, TIMESTAMP, COD_PROCESSO_JURID) VALUES (:SINNUMLO-COD-FONTE, :SINNUMLO-NUM-LOTE, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SINISHIS-VAL-OPERACAO, :SISTEMAS-DATA-MOV-ABERTO, 'SI0213B' , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1 = new R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1()
            {
                SINNUMLO_COD_FONTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE.ToString(),
                SINNUMLO_NUM_LOTE = SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
                SINISHIS_VAL_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1.Execute(r2200_00_INCLUI_SINISLAN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-ALTERA-SINISHIS-SECTION */
        private void R2300_00_ALTERA_SINISHIS_SECTION()
        {
            /*" -1814- MOVE '2300' TO WNR-EXEC-SQL */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -1821- PERFORM R2300_00_ALTERA_SINISHIS_DB_UPDATE_1 */

            R2300_00_ALTERA_SINISHIS_DB_UPDATE_1();

            /*" -1824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1828- DISPLAY 'PROBLEMAS NO UPDATE SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO UPDATE SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1828- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-ALTERA-SINISHIS-DB-UPDATE-1 */
        public void R2300_00_ALTERA_SINISHIS_DB_UPDATE_1()
        {
            /*" -1821- EXEC SQL UPDATE SEGUROS.SINISTRO_HISTORICO SET SIT_CONTABIL = :SINISHIS-SIT-CONTABIL, SIT_REGISTRO = '1' WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC */

            var r2300_00_ALTERA_SINISHIS_DB_UPDATE_1_Update1 = new R2300_00_ALTERA_SINISHIS_DB_UPDATE_1_Update1()
            {
                SINISHIS_SIT_CONTABIL = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL.ToString(),
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            R2300_00_ALTERA_SINISHIS_DB_UPDATE_1_Update1.Execute(r2300_00_ALTERA_SINISHIS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SINIITEM-SECTION */
        private void R2400_00_LE_SINIITEM_SECTION()
        {
            /*" -1838- MOVE '2400' TO WNR-EXEC-SQL */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -1846- PERFORM R2400_00_LE_SINIITEM_DB_SELECT_1 */

            R2400_00_LE_SINIITEM_DB_SELECT_1();

            /*" -1849- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1851- MOVE 'SEGURADO NAO IDENTIFICADO' TO CLIENTES-NOME-RAZAO */
                _.Move("SEGURADO NAO IDENTIFICADO", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1852- ELSE */
            }
            else
            {


                /*" -1853- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1857- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_ITEM/CLIENTES' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                    $"PROBLEMAS NO SELECT SINISTRO_ITEM/CLIENTES {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                    .Display();

                    /*" -1857- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2400-00-LE-SINIITEM-DB-SELECT-1 */
        public void R2400_00_LE_SINIITEM_DB_SELECT_1()
        {
            /*" -1846- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.SINISTRO_ITEM A, SEGUROS.CLIENTES B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.COD_CLIENTE = B.COD_CLIENTE END-EXEC */

            var r2400_00_LE_SINIITEM_DB_SELECT_1_Query1 = new R2400_00_LE_SINIITEM_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2400_00_LE_SINIITEM_DB_SELECT_1_Query1.Execute(r2400_00_LE_SINIITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-LE-SINISHIS-SECTION */
        private void R2500_00_LE_SINISHIS_SECTION()
        {
            /*" -1872- MOVE '2500' TO WNR-EXEC-SQL */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1880- PERFORM R2500_00_LE_SINISHIS_DB_SELECT_1 */

            R2500_00_LE_SINISHIS_DB_SELECT_1();

            /*" -1883- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1887- DISPLAY 'PROBLEMAS NO SUM (1) SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO SUM (1) SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1889- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1897- PERFORM R2500_00_LE_SINISHIS_DB_SELECT_2 */

            R2500_00_LE_SINISHIS_DB_SELECT_2();

            /*" -1900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1904- DISPLAY 'PROBLEMAS NO SUM (2) SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO SUM (2) SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -1906- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1907- COMPUTE HOST-VAL-RECEBIDO = HOST-VAL-RECEBIDO - HOST-VAL-RECEBIDO-EST. */
            HOST_VAL_RECEBIDO.Value = HOST_VAL_RECEBIDO - HOST_VAL_RECEBIDO_EST;

        }

        [StopWatch]
        /*" R2500-00-LE-SINISHIS-DB-SELECT-1 */
        public void R2500_00_LE_SINISHIS_DB_SELECT_1()
        {
            /*" -1880- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO), 0) INTO :HOST-VAL-RECEBIDO FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND A.COD_OPERACAO IN (4101, 4102) END-EXEC */

            var r2500_00_LE_SINISHIS_DB_SELECT_1_Query1 = new R2500_00_LE_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2500_00_LE_SINISHIS_DB_SELECT_1_Query1.Execute(r2500_00_LE_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_RECEBIDO, HOST_VAL_RECEBIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-LE-SINISHIS-DB-SELECT-2 */
        public void R2500_00_LE_SINISHIS_DB_SELECT_2()
        {
            /*" -1897- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO), 0) INTO :HOST-VAL-RECEBIDO-EST FROM SEGUROS.SINISTRO_HISTORICO A WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND A.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND A.COD_OPERACAO IN (4121, 4122) END-EXEC */

            var r2500_00_LE_SINISHIS_DB_SELECT_2_Query1 = new R2500_00_LE_SINISHIS_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2500_00_LE_SINISHIS_DB_SELECT_2_Query1.Execute(r2500_00_LE_SINISHIS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_RECEBIDO_EST, HOST_VAL_RECEBIDO_EST);
            }


        }

        [StopWatch]
        /*" R2600-00-LE-SINCREIN-SECTION */
        private void R2600_00_LE_SINCREIN_SECTION()
        {
            /*" -1917- MOVE '2600' TO WNR-EXEC-SQL */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -1930- PERFORM R2600_00_LE_SINCREIN_DB_SELECT_1 */

            R2600_00_LE_SINCREIN_DB_SELECT_1();

            /*" -1933- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1934- MOVE 'SIM' TO WTEM-SINCREIN */
                _.Move("SIM", WTEM_SINCREIN);

                /*" -1935- ELSE */
            }
            else
            {


                /*" -1936- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1940- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_CRED_INT' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                    $"PROBLEMAS NO SELECT SINISTRO_CRED_INT {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                    .Display();

                    /*" -1940- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2600-00-LE-SINCREIN-DB-SELECT-1 */
        public void R2600_00_LE_SINCREIN_DB_SELECT_1()
        {
            /*" -1930- EXEC SQL SELECT COD_SUREG, COD_AGENCIA, COD_OPERACAO, NUM_CONTRATO, CONTRATO_DIGITO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC */

            var r2600_00_LE_SINCREIN_DB_SELECT_1_Query1 = new R2600_00_LE_SINCREIN_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2600_00_LE_SINCREIN_DB_SELECT_1_Query1.Execute(r2600_00_LE_SINCREIN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-LE-SINIHAB1-SECTION */
        private void R2700_00_LE_SINIHAB1_SECTION()
        {
            /*" -1950- MOVE '2700' TO WNR-EXEC-SQL */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -1959- PERFORM R2700_00_LE_SINIHAB1_DB_SELECT_1 */

            R2700_00_LE_SINIHAB1_DB_SELECT_1();

            /*" -1962- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1963- MOVE 'SIM' TO WTEM-SINIHAB1 */
                _.Move("SIM", WTEM_SINIHAB1);

                /*" -1964- ELSE */
            }
            else
            {


                /*" -1965- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1969- DISPLAY 'PROBLEMAS NO SELECT SINISTRO_HABIT01' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                    $"PROBLEMAS NO SELECT SINISTRO_HABIT01 {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                    .Display();

                    /*" -1969- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2700-00-LE-SINIHAB1-DB-SELECT-1 */
        public void R2700_00_LE_SINIHAB1_DB_SELECT_1()
        {
            /*" -1959- EXEC SQL SELECT OPERACAO, PONTO_VENDA, NUM_CONTRATO INTO :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC */

            var r2700_00_LE_SINIHAB1_DB_SELECT_1_Query1 = new R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2700_00_LE_SINIHAB1_DB_SELECT_1_Query1.Execute(r2700_00_LE_SINIHAB1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-DECLARA-SINISHIS-SECTION */
        private void R2900_00_DECLARA_SINISHIS_SECTION()
        {
            /*" -1983- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WABEND.WNR_EXEC_SQL);

            /*" -2044- PERFORM R2900_00_DECLARA_SINISHIS_DB_DECLARE_1 */

            R2900_00_DECLARA_SINISHIS_DB_DECLARE_1();

            /*" -2046- PERFORM R2900_00_DECLARA_SINISHIS_DB_OPEN_1 */

            R2900_00_DECLARA_SINISHIS_DB_OPEN_1();

            /*" -2049- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2050- DISPLAY 'PROBLEMAS NO OPEN SINISTRO_HISTORICO' */
                _.Display($"PROBLEMAS NO OPEN SINISTRO_HISTORICO");

                /*" -2050- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2900-00-DECLARA-SINISHIS-DB-OPEN-1 */
        public void R2900_00_DECLARA_SINISHIS_DB_OPEN_1()
        {
            /*" -2046- EXEC SQL OPEN SINISHIS2 END-EXEC. */

            SINISHIS2.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-LE-SINISHIS-SECTION */
        private void R2910_00_LE_SINISHIS_SECTION()
        {
            /*" -2060- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WABEND.WNR_EXEC_SQL);

            /*" -2076- PERFORM R2910_00_LE_SINISHIS_DB_FETCH_1 */

            R2910_00_LE_SINISHIS_DB_FETCH_1();

            /*" -2079- IF (SQLCODE = 0) */

            if ((DB.SQLCODE == 0))
            {

                /*" -2080- IF (W-SIT-CONTABIL-ANT = SPACE) */

                if ((W_SIT_CONTABIL_ANT == " "))
                {

                    /*" -2081- MOVE SINISHIS-SIT-CONTABIL TO W-SIT-CONTABIL-ANT */
                    _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL, W_SIT_CONTABIL_ANT);

                    /*" -2082- END-IF */
                }


                /*" -2083- ADD 1 TO AC-L-SINISHIS */
                AC_L_SINISHIS.Value = AC_L_SINISHIS + 1;

                /*" -2084- ELSE */
            }
            else
            {


                /*" -2085- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2086- MOVE 'SIM' TO WFIM-SINISHIS */
                    _.Move("SIM", WFIM_SINISHIS);

                    /*" -2086- PERFORM R2910_00_LE_SINISHIS_DB_CLOSE_1 */

                    R2910_00_LE_SINISHIS_DB_CLOSE_1();

                    /*" -2088- ELSE */
                }
                else
                {


                    /*" -2089- DISPLAY 'PROBLEMAS NO FETCH SINISTRO_HISTORICO' */
                    _.Display($"PROBLEMAS NO FETCH SINISTRO_HISTORICO");

                    /*" -2089- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2910-00-LE-SINISHIS-DB-FETCH-1 */
        public void R2910_00_LE_SINISHIS_DB_FETCH_1()
        {
            /*" -2076- EXEC SQL FETCH SINISHIS2 INTO :SINISHIS-COD-PREST-SERVICO, :SINISHIS-SIT-CONTABIL, :SINISHIS-NUM-APOL-SINISTRO, :SINISHIS-OCORR-HISTORICO, :SINISHIS-COD-OPERACAO, :SI111-NUM-RESSARC, :SI111-SEQ-RESSARC, :SI111-NUM-PARCELA, :SINISHIS-VAL-OPERACAO, :FORNECED-NOME-FORNECEDOR, :FORNECED-CGCCPF, :FORNECED-TIPO-PESSOA, :FORNECED-COD-BANCO, :FORNECED-COD-AGENCIA, :FORNECED-NUM-CTA-CORRENTE END-EXEC. */

            if (SINISHIS2.Fetch())
            {
                _.Move(SINISHIS2.SINISHIS_COD_PREST_SERVICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO);
                _.Move(SINISHIS2.SINISHIS_SIT_CONTABIL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
                _.Move(SINISHIS2.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(SINISHIS2.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(SINISHIS2.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(SINISHIS2.SI111_NUM_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC);
                _.Move(SINISHIS2.SI111_SEQ_RESSARC, SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC);
                _.Move(SINISHIS2.SI111_NUM_PARCELA, SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA);
                _.Move(SINISHIS2.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISHIS2.FORNECED_NOME_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR);
                _.Move(SINISHIS2.FORNECED_CGCCPF, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);
                _.Move(SINISHIS2.FORNECED_TIPO_PESSOA, FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA);
                _.Move(SINISHIS2.FORNECED_COD_BANCO, FORNECED.DCLFORNECEDORES.FORNECED_COD_BANCO);
                _.Move(SINISHIS2.FORNECED_COD_AGENCIA, FORNECED.DCLFORNECEDORES.FORNECED_COD_AGENCIA);
                _.Move(SINISHIS2.FORNECED_NUM_CTA_CORRENTE, FORNECED.DCLFORNECEDORES.FORNECED_NUM_CTA_CORRENTE);
            }

        }

        [StopWatch]
        /*" R2910-00-LE-SINISHIS-DB-CLOSE-1 */
        public void R2910_00_LE_SINISHIS_DB_CLOSE_1()
        {
            /*" -2086- EXEC SQL CLOSE SINISHIS2 END-EXEC */

            SINISHIS2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-SINISHIS-SECTION */
        private void R3000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -2099- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -2102- MOVE SINISHIS-COD-PREST-SERVICO TO WS-COD-PREST-SERVICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, WS_COD_PREST_SERVICO);

            /*" -2104- PERFORM R1100-00-GERA-DOC-FISCAL */

            R1100_00_GERA_DOC_FISCAL_SECTION();

            /*" -2105- MOVE 'SI0213R' TO SINISCAP-COD-USUARIO */
            _.Move("SI0213R", SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_COD_USUARIO);

            /*" -2107- PERFORM R1200-00-GERA-LOTE */

            R1200_00_GERA_LOTE_SECTION();

            /*" -2113- WRITE REG-SI0213B1 FROM LC05 */
            _.Move(LC05.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -2120- PERFORM R4000-00-PROCESSA-FORNECEDOR UNTIL WFIM-SINISHIS = 'SIM' OR SINISHIS-COD-PREST-SERVICO NOT = WS-COD-PREST-SERVICO OR ( SINISHIS-SIT-CONTABIL NOT = W-SIT-CONTABIL-ANT AND (W-SIT-CONTABIL-ANT = 1) AND (SINISHIS-COD-OPERACAO = 4290) ) */

            while (!(WFIM_SINISHIS == "SIM" || SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO != WS_COD_PREST_SERVICO || (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL != W_SIT_CONTABIL_ANT && (W_SIT_CONTABIL_ANT == 1) && (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 4290))))
            {

                R4000_00_PROCESSA_FORNECEDOR_SECTION();
            }

            /*" -2120- PERFORM R1300-00-ALTERA-SINISCAP. */

            R1300_00_ALTERA_SINISCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-PROCESSA-FORNECEDOR-SECTION */
        private void R4000_00_PROCESSA_FORNECEDOR_SECTION()
        {
            /*" -2137- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -2138- MOVE 'NAO' TO WTEM-PAGAMENTO */
            _.Move("NAO", WTEM_PAGAMENTO);

            /*" -2140- PERFORM R2100-00-LE-SINISHIS */

            R2100_00_LE_SINISHIS_SECTION();

            /*" -2141- IF WTEM-PAGAMENTO EQUAL 'SIM' */

            if (WTEM_PAGAMENTO == "SIM")
            {

                /*" -2146- GO TO R4000-10-LER. */

                R4000_10_LER(); //GOTO
                return;
            }


            /*" -2148- IF SINISHIS-NUM-APOL-SINISTRO NOT EQUAL WS-NUM-APOL-SINISTRO */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO != WS_NUM_APOL_SINISTRO)
            {

                /*" -2150- MOVE SINISHIS-NUM-APOL-SINISTRO TO WS-NUM-APOL-SINISTRO */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, WS_NUM_APOL_SINISTRO);

                /*" -2152- MOVE 'NAO' TO WTEM-SINCREIN WTEM-SINIHAB1 */
                _.Move("NAO", WTEM_SINCREIN, WTEM_SINIHAB1);

                /*" -2154- PERFORM R2600-00-LE-SINCREIN */

                R2600_00_LE_SINCREIN_SECTION();

                /*" -2155- IF (WTEM-SINCREIN = 'NAO' ) */

                if ((WTEM_SINCREIN == "NAO"))
                {

                    /*" -2156- PERFORM R2700-00-LE-SINIHAB1 */

                    R2700_00_LE_SINIHAB1_SECTION();

                    /*" -2161- END-IF. */
                }

            }


            /*" -2163- PERFORM R2200-00-INCLUI-SINISLAN */

            R2200_00_INCLUI_SINISLAN_SECTION();

            /*" -2164- ADD 1 TO SINISCAP-QTD-LANCAMENTO */
            SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO.Value = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_QTD_LANCAMENTO + 1;

            /*" -2169- ADD SINISHIS-VAL-OPERACAO TO SINISCAP-VAL-TOT-LANCA */
            SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA.Value = SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_VAL_TOT_LANCA + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

            /*" -2171- IF SINISHIS-SIT-CONTABIL NOT EQUAL SINISCAP-CODIGO-CH1 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL != SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1)
            {

                /*" -2174- MOVE SINISCAP-CODIGO-CH1 TO SINISHIS-SIT-CONTABIL. */
                _.Move(SINISCAP.DCLSINISTRO_CAPALOTE1.SINISCAP_CODIGO_CH1, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_SIT_CONTABIL);
            }


            /*" -2178- PERFORM R2300-00-ALTERA-SINISHIS */

            R2300_00_ALTERA_SINISHIS_SECTION();

            /*" -2182- PERFORM R2400-00-LE-SINIITEM */

            R2400_00_LE_SINIITEM_SECTION();

            /*" -2186- PERFORM R4500-00-LE-SINISHIS */

            R4500_00_LE_SINISHIS_SECTION();

            /*" -2188- MOVE SINNUMLO-COD-FONTE TO LD01-COD-FONTE */
            _.Move(SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -2190- MOVE SINNUMLO-NUM-LOTE TO LD01-NUM-LOTE */
            _.Move(SINNUMLO.DCLSINISTRO_NUM_LOTE.SINNUMLO_NUM_LOTE, LD01.LD01_NUM_LOTE);

            /*" -2192- MOVE SINISHIS-COD-PREST-SERVICO TO LD01-COD-PREST-SERVICO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PREST_SERVICO, LD01.LD01_COD_PREST_SERVICO);

            /*" -2195- MOVE FORNECED-NOME-FORNECEDOR TO LD01-NOME-FORNECEDOR */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR, LD01.LD01_NOME_FORNECEDOR);

            /*" -2197- MOVE FORNECED-CGCCPF TO WS-CGCCPF */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, WS_CGCCPF);

            /*" -2199- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -2200- MOVE WS-CPF-NUM TO EDIT-CPF-NUM */
                _.Move(WS_CPF.WS_CPF_NUM, EDIT_CPF.EDIT_CPF_NUM);

                /*" -2201- MOVE WS-CPF-DIG TO EDIT-CPF-DIG */
                _.Move(WS_CPF.WS_CPF_DIG, EDIT_CPF.EDIT_CPF_DIG);

                /*" -2202- MOVE EDIT-CPF TO LD01-CGCCPF */
                _.Move(EDIT_CPF, LD01.LD01_CGCCPF);

                /*" -2203- ELSE */
            }
            else
            {


                /*" -2204- MOVE WS-CGC-NUM TO EDIT-CGC-NUM */
                _.Move(WS_CGC.WS_CGC_NUM, EDIT_CGC.EDIT_CGC_NUM);

                /*" -2205- MOVE WS-CGC-FIL TO EDIT-CGC-FIL */
                _.Move(WS_CGC.WS_CGC_FIL, EDIT_CGC.EDIT_CGC_FIL);

                /*" -2206- MOVE WS-CGC-DIG TO EDIT-CGC-DIG */
                _.Move(WS_CGC.WS_CGC_DIG, EDIT_CGC.EDIT_CGC_DIG);

                /*" -2208- MOVE EDIT-CGC TO LD01-CGCCPF. */
                _.Move(EDIT_CGC, LD01.LD01_CGCCPF);
            }


            /*" -2210- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LD01.LD01_NUM_APOL_SINISTRO);

            /*" -2212- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_NOME_SEGURADO);

            /*" -2214- MOVE SI111-NUM-RESSARC TO LD01-NUM-RESSARC */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC, LD01.LD01_NUM_RESSARC);

            /*" -2216- MOVE SI111-NUM-PARCELA TO LD01-NUM-PARCELA */
            _.Move(SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA, LD01.LD01_NUM_PARCELA);

            /*" -2218- MOVE HOST-VAL-RECEBIDO TO LD01-VAL-RECEBIDO */
            _.Move(HOST_VAL_RECEBIDO, LD01.LD01_VAL_RECEBIDO);

            /*" -2221- MOVE SINISHIS-VAL-OPERACAO TO LD01-VAL-DEVIDO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD01.LD01_VAL_DEVIDO);

            /*" -2226- MOVE 'REENVIO DE PAGAMENTO' TO LD01-TIPO-PAGTO */
            _.Move("REENVIO DE PAGAMENTO", LD01.LD01_TIPO_PAGTO);

            /*" -2227- IF WTEM-SINCREIN EQUAL 'SIM' */

            if (WTEM_SINCREIN == "SIM")
            {

                /*" -2229- MOVE SINCREIN-COD-SUREG TO CREINT-COD-SUREG */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG, CREINT_CONTRATO.CREINT_COD_SUREG);

                /*" -2231- MOVE SINCREIN-COD-AGENCIA TO CREINT-COD-AGENCIA */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA, CREINT_CONTRATO.CREINT_COD_AGENCIA);

                /*" -2233- MOVE SINCREIN-COD-OPERACAO TO CREINT-COD-OPERACAO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO, CREINT_CONTRATO.CREINT_COD_OPERACAO);

                /*" -2235- MOVE SINCREIN-NUM-CONTRATO TO CREINT-NUM-CONTRATO */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO, CREINT_CONTRATO.CREINT_NUM_CONTRATO);

                /*" -2237- MOVE SINCREIN-CONTRATO-DIGITO TO CREINT-CONTRATO-DIG */
                _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO, CREINT_CONTRATO.CREINT_CONTRATO_DIG);

                /*" -2238- MOVE CREINT-CONTRATO TO LD01-NUM-CONTRATO */
                _.Move(CREINT_CONTRATO, LD01.LD01_NUM_CONTRATO);

                /*" -2239- ELSE */
            }
            else
            {


                /*" -2240- IF WTEM-SINIHAB1 EQUAL 'SIM' */

                if (WTEM_SINIHAB1 == "SIM")
                {

                    /*" -2242- MOVE SINIHAB1-OPERACAO TO HABIT-OPERACAO */
                    _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO, HABIT_CONTRATO.HABIT_OPERACAO);

                    /*" -2244- MOVE SINIHAB1-PONTO-VENDA TO HABIT-PONTO-VENDA */
                    _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA, HABIT_CONTRATO.HABIT_PONTO_VENDA);

                    /*" -2246- MOVE SINIHAB1-NUM-CONTRATO TO HABIT-NUM-CONTRATO */
                    _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO, HABIT_CONTRATO.HABIT_NUM_CONTRATO);

                    /*" -2247- MOVE HABIT-CONTRATO TO LD01-NUM-CONTRATO */
                    _.Move(HABIT_CONTRATO, LD01.LD01_NUM_CONTRATO);

                    /*" -2248- ELSE */
                }
                else
                {


                    /*" -2250- MOVE SPACES TO LD01-NUM-CONTRATO. */
                    _.Move("", LD01.LD01_NUM_CONTRATO);
                }

            }


            /*" -2250- WRITE REG-SI0213B1 FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SI0213B1);

            SI0213B1.Write(REG_SI0213B1.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R4000_10_LER */

            R4000_10_LER();

        }

        [StopWatch]
        /*" R4000-10-LER */
        private void R4000_10_LER(bool isPerform = false)
        {
            /*" -2254- PERFORM R2910-00-LE-SINISHIS. */

            R2910_00_LE_SINISHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-LE-SINISHIS-SECTION */
        private void R4500_00_LE_SINISHIS_SECTION()
        {
            /*" -2269- MOVE '4500' TO WNR-EXEC-SQL */
            _.Move("4500", WABEND.WNR_EXEC_SQL);

            /*" -2284- PERFORM R4500_00_LE_SINISHIS_DB_SELECT_1 */

            R4500_00_LE_SINISHIS_DB_SELECT_1();

            /*" -2287- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2294- DISPLAY 'PROBLEMAS NO SUM (1) SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO ' ' SI111-NUM-RESSARC ' ' SI111-SEQ-RESSARC ' ' SI111-NUM-PARCELA */

                $"PROBLEMAS NO SUM (1) SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC} {SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA}"
                .Display();

                /*" -2296- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2311- PERFORM R4500_00_LE_SINISHIS_DB_SELECT_2 */

            R4500_00_LE_SINISHIS_DB_SELECT_2();

            /*" -2314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2318- DISPLAY 'PROBLEMAS NO SUM (2) SINISTRO_HISTORICO' ' ' SINISHIS-NUM-APOL-SINISTRO ' ' SINISHIS-OCORR-HISTORICO ' ' SINISHIS-COD-OPERACAO */

                $"PROBLEMAS NO SUM (2) SINISTRO_HISTORICO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO} {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}"
                .Display();

                /*" -2320- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2321- COMPUTE HOST-VAL-RECEBIDO = HOST-VAL-RECEBIDO - HOST-VAL-RECEBIDO-EST. */
            HOST_VAL_RECEBIDO.Value = HOST_VAL_RECEBIDO - HOST_VAL_RECEBIDO_EST;

        }

        [StopWatch]
        /*" R4500-00-LE-SINISHIS-DB-SELECT-1 */
        public void R4500_00_LE_SINISHIS_DB_SELECT_1()
        {
            /*" -2284- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO), 0) INTO :HOST-VAL-RECEBIDO FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.SI_RESSARC_PARCELA B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.NUM_RESSARC = :SI111-NUM-RESSARC AND B.SEQ_RESSARC = :SI111-SEQ-RESSARC AND B.NUM_PARCELA = :SI111-NUM-PARCELA AND A.COD_OPERACAO IN (4101, 4102) AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = B.OCORR_HISTORICO AND A.COD_OPERACAO = B.COD_OPERACAO END-EXEC */

            var r4500_00_LE_SINISHIS_DB_SELECT_1_Query1 = new R4500_00_LE_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SI111_NUM_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC.ToString(),
                SI111_SEQ_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC.ToString(),
                SI111_NUM_PARCELA = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA.ToString(),
            };

            var executed_1 = R4500_00_LE_SINISHIS_DB_SELECT_1_Query1.Execute(r4500_00_LE_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_RECEBIDO, HOST_VAL_RECEBIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-LE-SINISHIS-DB-SELECT-2 */
        public void R4500_00_LE_SINISHIS_DB_SELECT_2()
        {
            /*" -2311- EXEC SQL SELECT VALUE(SUM(A.VAL_OPERACAO), 0) INTO :HOST-VAL-RECEBIDO-EST FROM SEGUROS.SINISTRO_HISTORICO A, SEGUROS.SI_RESSARC_PARCELA B WHERE A.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND B.NUM_RESSARC = :SI111-NUM-RESSARC AND B.SEQ_RESSARC = :SI111-SEQ-RESSARC AND B.NUM_PARCELA = :SI111-NUM-PARCELA AND A.COD_OPERACAO IN (4121, 4122) AND A.NUM_APOL_SINISTRO = B.NUM_APOL_SINISTRO AND A.OCORR_HISTORICO = B.OCORR_HISTORICO AND A.COD_OPERACAO = B.COD_OPERACAO END-EXEC */

            var r4500_00_LE_SINISHIS_DB_SELECT_2_Query1 = new R4500_00_LE_SINISHIS_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SI111_NUM_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_RESSARC.ToString(),
                SI111_SEQ_RESSARC = SI111.DCLSI_RESSARC_PARCELA.SI111_SEQ_RESSARC.ToString(),
                SI111_NUM_PARCELA = SI111.DCLSI_RESSARC_PARCELA.SI111_NUM_PARCELA.ToString(),
            };

            var executed_1 = R4500_00_LE_SINISHIS_DB_SELECT_2_Query1.Execute(r4500_00_LE_SINISHIS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_VAL_RECEBIDO_EST, HOST_VAL_RECEBIDO_EST);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2335- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2337- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -2338- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -2339- DISPLAY '*    SI0213B - CANCELADO     *' */
            _.Display($"*    SI0213B - CANCELADO     *");

            /*" -2341- DISPLAY '******************************' */
            _.Display($"******************************");

            /*" -2341- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2345- CLOSE SI0213B1 */
            SI0213B1.Close();

            /*" -2347- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2347- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}