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
using Sias.Bilhetes.DB2.BI0070B;

namespace Code
{
    public class BI0070B
    {
        public bool IsCall { get; set; }

        public BI0070B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERA PROXIMA PARCELA DE BILHETE E  *      */
        /*"      *                             EFETUA AUMENTO PELO IPCA NO ANIVER *      */
        /*"      *                             SARIO.                             *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FAST COMPUTER (EDIVALDO GOMES)     *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  BI0070B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  19/08/2010                         *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS .................  45.765                             *      */
        /*"      *                                                                *      */
        /*"      *   GERA PARCELAS PARA BILHETES VENDIDOS PELA SYSTEM CRED        *      */
        /*"      *                                                                *      */
        /*"      *   CORRIGE OS PREMIOS DOS BILHETES VENDIDOS PELA SYSTEM CRED    *      */
        /*"      *   PELA VARIACAO ACUMULADA DO IPCA NOS ULTIMOS DOZE MESES.      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                     A L T E R A C A O                          *      */
        /*"      ******************************************************************      */
        /*"V.29  *  VERSAO 29  - DEMANDA 455.132                                  *      */
        /*"      *             - FAZ GRAVACAO DE CAMPOS NUM_CERTIFICADO E COD_IDLG*      */
        /*"      *               NA MOVTO_DEBITOCC_CEF                            *      */
        /*"      *                                                                *      */
        /*"      *  EM 17/02/2023 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                        PROCURE POR V.29        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.28  *    VERSAO 28 - HISTORIA 261651                                 *      */
        /*"      *    A PARTIR DO ARQUIVO ENVIADO PELA BU FOI CADASTRADA AS       *      */
        /*"      *    PROPOSTAS NA TABELA SEGUROS.RELATORIOS PARA CADASTRAR       *      */
        /*"      *    O CORRETOR 25160 - COLLEGE BRASIL EM VEZ DE                 *      */
        /*"      *    25151 - FONTES CORRET CONFORME ORIGEM DA PROPOSTA.          *      */
        /*"      *                                                                *      */
        /*"      *    EM 15/10/2020 - CLOVIS                                      *      */
        /*"      *                                        PROCURE POR V.28        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.27  *   VERSAO 27 - TAREFA 245621                                    *      */
        /*"      *             - CALCULAR VALOR DE IOF E PARCELA COM DUAS CASAS   *      */
        /*"      *               DECIMAIS NO MOMENTO DE CARGA DAS PARCELAS        *      */
        /*"      *                                                                *      */
        /*"      *  22/05/2020 - HUSNI ALI HUSNI                                  *      */
        /*"      *                                        PROCURE POR V.27        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *    VERSAO 26 - HISTORIA 218637                                 *      */
        /*"      *                                                                *      */
        /*"      *    EM 07/02/2020 - CLOVIS                                      *      */
        /*"      *                                        PROCURE POR V.26        *      */
        /*"      *                                                                *      */
        /*"      *    Demanda V.1 218637                                          *      */
        /*"      *                                                                *      */
        /*"      *    Corretiva - Pagamento de comiss�o divergente (RO e SIGDC) + *      */
        /*"      *                Corretagem enviada em dobro � Wiz               *      */
        /*"      *                                                                *      */
        /*"      *    FSIMAE_EVOGEPES_013-_2012__-_Regras_de_Comissionamento_e_   *      */
        /*"      *    Valores_de_Pr�mios_Extra_Rede_1086255_1091043.D200130       *      */
        /*"      *                                                                *      */
        /*"      *    Especifica��o n� 013/2012                                   *      */
        /*"      *    Regras Comiss�o e Valores de Pr�mios - Produtos_Extra Rede  *      */
        /*"      *    Vers�o 1.0                                                  *      */
        /*"      *    18.05.2012 1.0 Regras de Comiss�o e Valores de Pr�mios -    *      */
        /*"      *    Produtos_Extra Rede                 Cintia Fernandes        *      */
        /*"      *                                                                *      */
        /*"      *    1. Objetivo da Demanda                                      *      */
        /*"      *    1.1 Esta demanda tem por objetivo alterar as regras de      *      */
        /*"      *        comissionamento e as regras de valores de pr�mios dos   *      */
        /*"      *        produtos Extra Rede.                                    *      */
        /*"      *                                                                *      */
        /*"      *    2. Premissas                                                *      */
        /*"      *    2.1 Est�o ocorrendo diverg�ncias no pagamento da comiss�o   *      */
        /*"      *        da segunda e terceira parcela para o corretor 24295 -   *      */
        /*"      *        SYSTEN CRED.                                            *      */
        /*"      *    2.2.No produto 8124 a corretagem de 25% est� sendo paga em  *      */
        /*"      *        todas as parcelas.                                      *      */
        /*"      *                                                                *      */
        /*"      *    3. Regras da Comiss�o                                       *      */
        /*"      *    3.1 O produto F�cil Plano Odonto (8124 e 8132) possui a     *      */
        /*"      *        seguinte grade de remunera��o:                          *      */
        /*"      *                                                                *      */
        /*"      *    -  Agenciamento: 100% da 1� parcela;                        *      */
        /*"      *    -  Corretagem: 25% de todas as parcelas.                    *      */
        /*"      *                                                                *      */
        /*"      *    3.2 Para os produtos 8115 - 8116 - 8117 - 8118 e 8125 a     *      */
        /*"      *        regra � a seguinte:                                     *      */
        /*"      *                                                                *      */
        /*"      *    -  Agenciamento: 60% da 1� parcela, 2� parcela e 3� parcela;*      */
        /*"      *    -  Agenciamento: 30%- das parcelas 13,14,25,26,37,38,49,50  *      */
        /*"      *    -  Corretagem: 40% de todas as parcelas.                    *      */
        /*"      *                                                                *      */
        /*"      *    3.3 Para os produtos 8124, 8125 e 8132 a regra � a seguinte *      */
        /*"      *        para a segunda e terceira  parcela.                     *      */
        /*"      *                                                                *      */
        /*"      *    Comiss�o de agenciamento:                                   *      */
        /*"      *    Produtor = 24295          Percentual = 70%                  *      */
        /*"      *                                                                *      */
        /*"      *    3.4  A seguir seguem as regras de comissionamento           *      */
        /*"      *        (agenciamento/corretagem) para os produtos -            *      */
        /*"      *         Crednew/Backeseg - corretor 24317.                     *      */
        /*"      *                                                                *      */
        /*"      *    Parcela de ades�o                                           *      */
        /*"      *    Produto 8124 - F�CIL PLANO ODONTO                           *      */
        /*"      *    Produtor = 24317          Percentual = 70%                  *      */
        /*"      *                                                                *      */
        /*"      *    Demais produtos 8119, 8120, 8121, 8122 e 8123:              *      */
        /*"      *    Comiss�o de agenciamento:                                   *      */
        /*"      *    Produtor = 24317          Percentual = 70%                  *      */
        /*"      *                                                                *      */
        /*"      *    PARCELAS 13, 14,  25, 26, 37, 38,  49,  50                  *      */
        /*"      *    Comiss�o de agenciamento:                                   *      */
        /*"      *    Produtor = 24317          Percentual = 30%                  *      */
        /*"      *                                                                *      */
        /*"      *    Respons�vel pela Especifica��o - GEPES                      *      */
        /*"      *    Data / Assinatura                                           *      */
        /*"      *    18/05/2012                                                  *      */
        /*"      *    CINTIA FERNANDES DE SOUSA                                   *      */
        /*"      *    GER�NCIA DE PRODUTOS DE PESSOAS - GEPES                     *      */
        /*"      *    CASTELANO RIBEIRO DOS SANTOS                                *      */
        /*"      *    DIRETORIA DE VIDA - DIRVI                                   *      */
        /*"      *    ROSANA TECHINA SALSANO                                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - INICIDENTE 230677                                *      */
        /*"      *               OCORRENCIA DE FALHA N� 179737                    *      */
        /*"      *               -310 NO INSERT APOLICE_CORRETOR AO GERAR PARCELA *      */
        /*"      *               49 DO BILHETE 95488796705 ORIGEM 1012.           *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2020 - BRICE HO                                     *      */
        /*"      *                                        PROCURE POR V.25        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2019 - CLOVIS                                       *      */
        /*"      *   PROGRAMA REMANEJADO DE ACORDO COM REGRAS ATUAIS.             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 23 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 181375.                                *      */
        /*"=     *    EM 14/01/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  SISTEMA-DTMOVABE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-CURRENT                  PIC  X(010).*/
        public StringBasis SISTEMA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-DTMAXALTIPCA             PIC  X(010).*/
        public StringBasis SISTEMA_DTMAXALTIPCA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-DTTERCOT                 PIC  X(010).*/
        public StringBasis SISTEMA_DTTERCOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-DTINICOT                 PIC  X(010).*/
        public StringBasis SISTEMA_DTINICOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-DTMOV01M                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOV01M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-DTMOV10D                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOV10D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMA-DTMOV20D                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOV20D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-COUNT                      PIC S9(015)          COMP-3*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NUM-ENDOSSO                PIC S9(009)          COMP.*/
        public IntBasis WHOST_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VIND-NULL01                      PIC S9(004)          COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NULL02                      PIC S9(004)          COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIADEBITO                   PIC S9(004)          COMP.*/
        public IntBasis VIND_DIADEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-AGENCIA                     PIC S9(004)          COMP.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPERACAO                    PIC S9(004)          COMP.*/
        public IntBasis VIND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NUMCONTA                    PIC S9(004)          COMP.*/
        public IntBasis VIND_NUMCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIGCONTA                    PIC S9(004)          COMP.*/
        public IntBasis VIND_DIGCONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTENVIO                     PIC S9(004)          COMP.*/
        public IntBasis VIND_DTENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTRETORNO                   PIC S9(004)          COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CODRETORNO                  PIC S9(004)          COMP.*/
        public IntBasis VIND_CODRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-USUARIO                     PIC S9(004)          COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-REQUISICAO                  PIC S9(004)          COMP.*/
        public IntBasis VIND_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NUMCARTAO                   PIC S9(004)          COMP.*/
        public IntBasis VIND_NUMCARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SEQUENCIA                   PIC S9(004)          COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NUM-LOTE                    PIC S9(004)          COMP.*/
        public IntBasis VIND_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTCREDITO                   PIC S9(004)          COMP.*/
        public IntBasis VIND_DTCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-STATUS                      PIC S9(004)          COMP.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VLCREDITO                   PIC S9(004)          COMP.*/
        public IntBasis VIND_VLCREDITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DATA-RCAP                   PIC S9(004)          COMP.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COD-EMPRESA                 PIC S9(004)          COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-TIPO-CORRECAO               PIC S9(004)          COMP.*/
        public IntBasis VIND_TIPO_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-ISENTA-CUSTO                PIC S9(004)          COMP.*/
        public IntBasis VIND_ISENTA_CUSTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-COEF-PREFIX                 PIC S9(004)          COMP.*/
        public IntBasis VIND_COEF_PREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-VAL-CUSTO                   PIC S9(004)          COMP.*/
        public IntBasis VIND_VAL_CUSTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTVENCTO                    PIC S9(004)          COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-AGEDEB                      PIC S9(004)          COMP.*/
        public IntBasis VIND_AGEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPEDEB                      PIC S9(004)          COMP.*/
        public IntBasis VIND_OPEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NUMDEB                      PIC S9(004)          COMP.*/
        public IntBasis VIND_NUMDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIGDEB                      PIC S9(004)          COMP.*/
        public IntBasis VIND_DIGDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-CARTAO                      PIC S9(004)          COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIADEB                      PIC S9(004)          COMP.*/
        public IntBasis VIND_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CODEMP                      PIC S9(004)          COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WIND                             PIC S9(004)          COMP.*/
        public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WIND2                            PIC S9(004)          COMP.*/
        public IntBasis WIND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WIND3                            PIC S9(004)          COMP.*/
        public IntBasis WIND3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WSGER00-DATA-INIVIGENCIA         PIC  X(010).*/
        public StringBasis WSGER00_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WSGER00-DATA-TERVIGENCIA         PIC  X(010).*/
        public StringBasis WSGER00_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WSGER00-DATA-CORRETOR            PIC  X(010).*/
        public StringBasis WSGER00_DATA_CORRETOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MOVDEBCE-DATA-PROXVEN            PIC  X(010).*/
        public StringBasis MOVDEBCE_DATA_PROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-WORK-AREAS.*/
        public BI0070B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new BI0070B_WS_WORK_AREAS();
        public class BI0070B_WS_WORK_AREAS : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)         VALUE SPACES*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-PROCESSA-INDICE        PIC  X(003)         VALUE SPACES*/
            public StringBasis WS_PROCESSA_INDICE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  WS-TEM-BILHETE            PIC  X(001)         VALUE SPACES*/
            public StringBasis WS_TEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WIND-1                    PIC  9(003)         VALUE ZEROS.*/
            public IntBasis WIND_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  03  LD-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ENDOSSOS               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-APOLICOB               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_APOLICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-PARCELAS               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-SITUACAO               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_SITUACAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-APOLCOBR               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_APOLCOBR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-IPCA                   PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_IPCA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-CONTROLE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-APOLICOR               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_APOLICOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-ENDOSSOS               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-RELATORI               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis AC_RELATORI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-IPCA-ACUM              PIC S9(009)V9(9) COMP-3  VALUE 0*/
            public DoubleBasis WS_IPCA_ACUM { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(009)V9(9)"), 9);
            /*"  03  WS-IPCA-ACUM-DISPLAY      PIC ------.--9,999999999.*/
            public DoubleBasis WS_IPCA_ACUM_DISPLAY { get; set; } = new DoubleBasis(new PIC("9", "9", "------.--9V999999999."), 9);
            /*"  03  WHOST-PRM                 PIC S9(013)V9(2) COMP-3  VALUE 0*/
            public DoubleBasis WHOST_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  03  WS-PRM-TOTAL-IX           PIC S9(013)V9(2) COMP-3  VALUE 0*/
            public DoubleBasis WS_PRM_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  03  WS-VAL-IOCC-IX            PIC S9(013)V9(2) COMP-3  VALUE 0*/
            public DoubleBasis WS_VAL_IOCC_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
            /*"  03         W01DTSQL.*/
            public BI0070B_W01DTSQL W01DTSQL { get; set; } = new BI0070B_W01DTSQL();
            public class BI0070B_W01DTSQL : VarBasis
            {
                /*"      10     W01AASQL           PIC  9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     W01T1SQL           PIC  X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     W01MMSQL           PIC  9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     W01T2SQL           PIC  X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     W01DDSQL           PIC  9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         AC-LIDOS           PIC  9(013)    VALUE   ZEROS.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  03         FILLER             REDEFINES      AC-LIDOS.*/
            private _REDEF_BI0070B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0070B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0070B_FILLER_0(); _.Move(AC_LIDOS, _filler_0); VarBasis.RedefinePassValue(AC_LIDOS, _filler_0, AC_LIDOS); _filler_0.ValueChanged += () => { _.Move(_filler_0, AC_LIDOS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, AC_LIDOS); }
            }  //Redefines
            public class _REDEF_BI0070B_FILLER_0 : VarBasis
            {
                /*"      10     LD-PARTE1          PIC  9(009).*/
                public IntBasis LD_PARTE1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10     LD-PARTE2          PIC  9(004).*/
                public IntBasis LD_PARTE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0070B_FILLER_0()
                {
                    LD_PARTE1.ValueChanged += OnValueChanged;
                    LD_PARTE2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0070B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0070B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0070B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0070B_FILLER_1 : VarBasis
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

                public _REDEF_BI0070B_FILLER_1()
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
            private _REDEF_BI0070B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0070B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0070B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0070B_FILLER_4 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI0070B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0070B_WTIME_DAYR();
                public class BI0070B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA         PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1         PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU         PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2         PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU         PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3         PIC  X(001).*/

                    public BI0070B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE         PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03         WS-TIME.*/

                public _REDEF_BI0070B_FILLER_4()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0070B_WS_TIME WS_TIME { get; set; } = new BI0070B_WS_TIME();
            public class BI0070B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/
            }
            public BI0070B_WABEND WABEND { get; set; } = new BI0070B_WABEND();
            public class BI0070B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' BI0070B  '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0070B  ");
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
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRMC = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRMC = ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE    SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01  WS-TABELAS.*/
            }
        }
        public BI0070B_WS_TABELAS WS_TABELAS { get; set; } = new BI0070B_WS_TABELAS();
        public class BI0070B_WS_TABELAS : VarBasis
        {
            /*"    03       TABELA-IPCA.*/
            public BI0070B_TABELA_IPCA TABELA_IPCA { get; set; } = new BI0070B_TABELA_IPCA();
            public class BI0070B_TABELA_IPCA : VarBasis
            {
                /*"      05     FILLER            OCCURS 300 TIMES.*/
                public ListBasis<BI0070B_FILLER_11> FILLER_11 { get; set; } = new ListBasis<BI0070B_FILLER_11>(300);
                public class BI0070B_FILLER_11 : VarBasis
                {
                    /*"        10   TB-DATA-IPCA      PIC  9(006).*/
                    public IntBasis TB_DATA_IPCA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"        10   TB-DATA-IPCA-R REDEFINES TB-DATA-IPCA.*/
                    private _REDEF_BI0070B_TB_DATA_IPCA_R _tb_data_ipca_r { get; set; }
                    public _REDEF_BI0070B_TB_DATA_IPCA_R TB_DATA_IPCA_R
                    {
                        get { _tb_data_ipca_r = new _REDEF_BI0070B_TB_DATA_IPCA_R(); _.Move(TB_DATA_IPCA, _tb_data_ipca_r); VarBasis.RedefinePassValue(TB_DATA_IPCA, _tb_data_ipca_r, TB_DATA_IPCA); _tb_data_ipca_r.ValueChanged += () => { _.Move(_tb_data_ipca_r, TB_DATA_IPCA); }; return _tb_data_ipca_r; }
                        set { VarBasis.RedefinePassValue(value, _tb_data_ipca_r, TB_DATA_IPCA); }
                    }  //Redefines
                    public class _REDEF_BI0070B_TB_DATA_IPCA_R : VarBasis
                    {
                        /*"          15 TB-ANO-IPCA       PIC  9(004).*/
                        public IntBasis TB_ANO_IPCA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"          15 TB-MES-IPCA       PIC  9(002).*/
                        public IntBasis TB_MES_IPCA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        10   TB-VAL-IPCA       PIC S9(006)V9(9)  COMP-3.*/

                        public _REDEF_BI0070B_TB_DATA_IPCA_R()
                        {
                            TB_ANO_IPCA.ValueChanged += OnValueChanged;
                            TB_MES_IPCA.ValueChanged += OnValueChanged;
                        }

                    }
                    public DoubleBasis TB_VAL_IPCA { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
                }
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public BI0070B_V0COTACAO V0COTACAO { get; set; } = new BI0070B_V0COTACAO();
        public BI0070B_V0MOVDEBCE V0MOVDEBCE { get; set; } = new BI0070B_V0MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -351- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -352- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -354- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -356- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -359- DISPLAY ' ' */
            _.Display($" ");

            /*" -361- DISPLAY '================================================' '================================================' */
            _.Display($"================================================================================================");

            /*" -362- DISPLAY '          PROGRAMA EM EXECUCAO BI0070B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO BI0070B          ");

            /*" -364- DISPLAY 'VERSAO V.29 - DEMANDA 455.132 - ' FUNCTION WHEN-COMPILED */

            $"VERSAO V.29 - DEMANDA 455.132 - FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -366- DISPLAY '================================================' '================================================' */
            _.Display($"================================================================================================");

            /*" -367- DISPLAY ' ' */
            _.Display($" ");

            /*" -374- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -375- DISPLAY ' ' */
            _.Display($" ");

            /*" -378- . */

            /*" -381- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -381- PERFORM R0200-00-SELECIONA. */

            R0200_00_SELECIONA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -386- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -390- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -391- DISPLAY ' ' . */
            _.Display($" ");

            /*" -392- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -393- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -394- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -395- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -396- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -397- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -398- DISPLAY 'BI0070B - FIM NORMAL' WTIME-DAYR. */
            _.Display($"BI0070B - FIM NORMAL{WS_WORK_AREAS.FILLER_4.WTIME_DAYR}");

            /*" -401- DISPLAY ' ' . */
            _.Display($" ");

            /*" -401- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -410- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -411- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -412- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -413- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -414- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -415- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -416- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -419- DISPLAY 'INICIO BI0070B    ' WTIME-DAYR. */
            _.Display($"INICIO BI0070B    {WS_WORK_AREAS.FILLER_4.WTIME_DAYR}");

            /*" -422- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -425- PERFORM R0110-00-SELECT-COTACAO. */

            R0110_00_SELECT_COTACAO_SECTION();

            /*" -426- DISPLAY ' ' . */
            _.Display($" ");

            /*" -428- DISPLAY 'DATA DE MOVIMENTO ............... ' SISTEMA-DTMOVABE */
            _.Display($"DATA DE MOVIMENTO ............... {SISTEMA_DTMOVABE}");

            /*" -430- DISPLAY 'CURRENT DATE .................... ' SISTEMA-CURRENT */
            _.Display($"CURRENT DATE .................... {SISTEMA_CURRENT}");

            /*" -432- DISPLAY 'DATA INICIO COTA ................ ' SISTEMA-DTINICOT */
            _.Display($"DATA INICIO COTA ................ {SISTEMA_DTINICOT}");

            /*" -434- DISPLAY 'DATA TERMINO COTA ............... ' SISTEMA-DTTERCOT */
            _.Display($"DATA TERMINO COTA ............... {SISTEMA_DTTERCOT}");

            /*" -436- DISPLAY 'DATA DE MOVIMENTO + 01 MES ...... ' SISTEMA-DTMOV01M */
            _.Display($"DATA DE MOVIMENTO + 01 MES ...... {SISTEMA_DTMOV01M}");

            /*" -438- DISPLAY 'DATA DE MOVIMENTO + 20 DIAS ..... ' SISTEMA-DTMOV20D */
            _.Display($"DATA DE MOVIMENTO + 20 DIAS ..... {SISTEMA_DTMOV20D}");

            /*" -440- DISPLAY 'DATA DE MOVIMENTO + 10 DIAS ..... ' SISTEMA-DTMOV10D */
            _.Display($"DATA DE MOVIMENTO + 10 DIAS ..... {SISTEMA_DTMOV10D}");

            /*" -443- DISPLAY ' ' . */
            _.Display($" ");

            /*" -445- PERFORM R0120-00-CARGA-INDICE. */

            R0120_00_CARGA_INDICE_SECTION();

            /*" -446- MOVE WS-IPCA-ACUM TO WS-IPCA-ACUM-DISPLAY. */
            _.Move(WS_WORK_AREAS.WS_IPCA_ACUM, WS_WORK_AREAS.WS_IPCA_ACUM_DISPLAY);

            /*" -449- DISPLAY '*** BI0070B *** IPCA  ACUMULADO NO PERIODO ' WS-IPCA-ACUM-DISPLAY '%' . */

            $"*** BI0070B *** IPCA  ACUMULADO NO PERIODO WS-IPCA-ACUM-%"
            .Display();

            /*" -451- PERFORM R0155-00-CRITICA-INDICE. */

            R0155_00_CRITICA_INDICE_SECTION();

            /*" -452- IF WS-PROCESSA-INDICE EQUAL 'NAO' */

            if (WS_WORK_AREAS.WS_PROCESSA_INDICE == "NAO")
            {

                /*" -455- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -455- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -468- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -487- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -491- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -492- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -492- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -487- EXEC SQL SELECT DATA_MOV_ABERTO ,CURRENT DATE ,DATA_MOV_ABERTO - 1 MONTH ,DATA_MOV_ABERTO - 12 MONTH ,DATA_MOV_ABERTO + 1 MONTH ,DATA_MOV_ABERTO + 20 DAYS ,DATA_MOV_ABERTO + 10 DAYS INTO :SISTEMA-DTMOVABE ,:SISTEMA-CURRENT ,:SISTEMA-DTTERCOT ,:SISTEMA-DTINICOT ,:SISTEMA-DTMOV01M ,:SISTEMA-DTMOV20D ,:SISTEMA-DTMOV10D FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRENT, SISTEMA_CURRENT);
                _.Move(executed_1.SISTEMA_DTTERCOT, SISTEMA_DTTERCOT);
                _.Move(executed_1.SISTEMA_DTINICOT, SISTEMA_DTINICOT);
                _.Move(executed_1.SISTEMA_DTMOV01M, SISTEMA_DTMOV01M);
                _.Move(executed_1.SISTEMA_DTMOV20D, SISTEMA_DTMOV20D);
                _.Move(executed_1.SISTEMA_DTMOV10D, SISTEMA_DTMOV10D);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-SELECT-COTACAO-SECTION */
        private void R0110_00_SELECT_COTACAO_SECTION()
        {
            /*" -505- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -506- MOVE SISTEMA-DTTERCOT TO W01DTSQL. */
            _.Move(SISTEMA_DTTERCOT, WS_WORK_AREAS.W01DTSQL);

            /*" -507- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -510- MOVE W01DTSQL TO SISTEMA-DTTERCOT. */
            _.Move(WS_WORK_AREAS.W01DTSQL, SISTEMA_DTTERCOT);

            /*" -517- PERFORM R0110_00_SELECT_COTACAO_DB_SELECT_1 */

            R0110_00_SELECT_COTACAO_DB_SELECT_1();

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY 'R0110-00 - PROBLEMAS NO SELECT(COTACAO)' */
                _.Display($"R0110-00 - PROBLEMAS NO SELECT(COTACAO)");

                /*" -524- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -525- IF VIND-NULL01 LESS ZEROS */

            if (VIND_NULL01 < 00)
            {

                /*" -529- MOVE ZEROS TO WHOST-COUNT. */
                _.Move(0, WHOST_COUNT);
            }


            /*" -530- IF WHOST-COUNT EQUAL ZEROS */

            if (WHOST_COUNT == 00)
            {

                /*" -531- DISPLAY ' ' */
                _.Display($" ");

                /*" -532- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -533- DISPLAY '* DATA TERMINO VIGENCIA-COTACAO ' SISTEMA-DTTERCOT */
                _.Display($"* DATA TERMINO VIGENCIA-COTACAO {SISTEMA_DTTERCOT}");

                /*" -534- DISPLAY '* DATA INICIO VIGENCIA-COTA��O  ' SISTEMA-DTINICOT */
                _.Display($"* DATA INICIO VIGENCIA-COTA��O  {SISTEMA_DTINICOT}");

                /*" -535- DISPLAY '* QUANTIDADE MESES COTA��O      ' WHOST-COUNT */
                _.Display($"* QUANTIDADE MESES COTA��O      {WHOST_COUNT}");

                /*" -536- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -537- DISPLAY ' ' */
                _.Display($" ");

                /*" -538- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -539- DISPLAY '**                                             **' */
                _.Display($"**                                             **");

                /*" -540- DISPLAY '* ENVIA E-MAIL PARA PEDIDOR CADASTRO DE COTACAO.*' */
                _.Display($"* ENVIA E-MAIL PARA PEDIDOR CADASTRO DE COTACAO.*");

                /*" -541- DISPLAY '**                                             **' */
                _.Display($"**                                             **");

                /*" -542- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -543- DISPLAY ' ' */
                _.Display($" ");

                /*" -546- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -547- MOVE SISTEMA-DTMOVABE(9:2) TO W01DDSQL. */
            _.Move(SISTEMA_DTMOVABE.Substring(9, 2), WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -548- MOVE SISTEMA-DTMOVABE(6:2) TO W01MMSQL. */
            _.Move(SISTEMA_DTMOVABE.Substring(6, 2), WS_WORK_AREAS.W01DTSQL.W01MMSQL);

            /*" -548- MOVE SISTEMA-DTMOVABE(1:4) TO W01AASQL. */
            _.Move(SISTEMA_DTMOVABE.Substring(1, 4), WS_WORK_AREAS.W01DTSQL.W01AASQL);

        }

        [StopWatch]
        /*" R0110-00-SELECT-COTACAO-DB-SELECT-1 */
        public void R0110_00_SELECT_COTACAO_DB_SELECT_1()
        {
            /*" -517- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT:VIND-NULL01 FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = 28 AND DATA_INIVIGENCIA >= :SISTEMA-DTINICOT WITH UR END-EXEC. */

            var r0110_00_SELECT_COTACAO_DB_SELECT_1_Query1 = new R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1()
            {
                SISTEMA_DTINICOT = SISTEMA_DTINICOT.ToString(),
            };

            var executed_1 = R0110_00_SELECT_COTACAO_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_COTACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-CARGA-INDICE-SECTION */
        private void R0120_00_CARGA_INDICE_SECTION()
        {
            /*" -561- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -563- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", WS_WORK_AREAS.WFIM_MOVIMENTO);

            /*" -564- PERFORM R0130-00-DECLARE-V0COTACAO. */

            R0130_00_DECLARE_V0COTACAO_SECTION();

            /*" -566- PERFORM R0135-00-FETCH-V0COTACAO. */

            R0135_00_FETCH_V0COTACAO_SECTION();

            /*" -567- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -568- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -569- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -570- DISPLAY '* ENVIA E-MAIL PARA PEDIDOR CADASTRO DE COTACAO.*' */
                _.Display($"* ENVIA E-MAIL PARA PEDIDOR CADASTRO DE COTACAO.*");

                /*" -571- DISPLAY '*                                               *' */
                _.Display($"*                                               *");

                /*" -572- DISPLAY '*-----------------------------------------------*' */
                _.Display($"*-----------------------------------------------*");

                /*" -573- DISPLAY ' ' */
                _.Display($" ");

                /*" -576- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -577- MOVE 1 TO WIND-1. */
            _.Move(1, WS_WORK_AREAS.WIND_1);

            /*" -579- MOVE MOEDACOT-DATA-INIVIGENCIA TO W01DTSQL. */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, WS_WORK_AREAS.W01DTSQL);

            /*" -581- MOVE W01MMSQL TO TB-MES-IPCA(WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_TABELAS.TABELA_IPCA.FILLER_11[WS_WORK_AREAS.WIND_1].TB_DATA_IPCA_R.TB_MES_IPCA);

            /*" -584- MOVE W01AASQL TO TB-ANO-IPCA(WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_TABELAS.TABELA_IPCA.FILLER_11[WS_WORK_AREAS.WIND_1].TB_DATA_IPCA_R.TB_ANO_IPCA);

            /*" -585- IF MOEDACOT-VAL-VENDA NOT GREATER ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA <= 00)
            {

                /*" -588- MOVE 0 TO MOEDACOT-VAL-VENDA. */
                _.Move(0, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }


            /*" -593- MOVE MOEDACOT-VAL-VENDA TO TB-VAL-IPCA(WIND-1) WS-IPCA-ACUM. */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, WS_TABELAS.TABELA_IPCA.FILLER_11[WS_WORK_AREAS.WIND_1].TB_VAL_IPCA, WS_WORK_AREAS.WS_IPCA_ACUM);

            /*" -594- PERFORM R0140-00-CARGA-V0COTACAO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0140_00_CARGA_V0COTACAO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-DECLARE-V0COTACAO-SECTION */
        private void R0130_00_DECLARE_V0COTACAO_SECTION()
        {
            /*" -607- MOVE '0130' TO WNR-EXEC-SQL. */
            _.Move("0130", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -616- PERFORM R0130_00_DECLARE_V0COTACAO_DB_DECLARE_1 */

            R0130_00_DECLARE_V0COTACAO_DB_DECLARE_1();

            /*" -618- PERFORM R0130_00_DECLARE_V0COTACAO_DB_OPEN_1 */

            R0130_00_DECLARE_V0COTACAO_DB_OPEN_1();

            /*" -622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -623- DISPLAY 'R0130-00 - PROBLEMAS NO DECLARE(COTACAO)' */
                _.Display($"R0130-00 - PROBLEMAS NO DECLARE(COTACAO)");

                /*" -623- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-00-DECLARE-V0COTACAO-DB-DECLARE-1 */
        public void R0130_00_DECLARE_V0COTACAO_DB_DECLARE_1()
        {
            /*" -616- EXEC SQL DECLARE V0COTACAO CURSOR FOR SELECT DATA_INIVIGENCIA ,VAL_VENDA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = 28 AND DATA_INIVIGENCIA >= :SISTEMA-DTINICOT ORDER BY 1 WITH UR END-EXEC. */
            V0COTACAO = new BI0070B_V0COTACAO(true);
            string GetQuery_V0COTACAO()
            {
                var query = @$"SELECT DATA_INIVIGENCIA 
							,VAL_VENDA 
							FROM SEGUROS.MOEDAS_COTACAO 
							WHERE COD_MOEDA = 28 
							AND DATA_INIVIGENCIA >= '{SISTEMA_DTINICOT}' 
							ORDER BY 1";

                return query;
            }
            V0COTACAO.GetQueryEvent += GetQuery_V0COTACAO;

        }

        [StopWatch]
        /*" R0130-00-DECLARE-V0COTACAO-DB-OPEN-1 */
        public void R0130_00_DECLARE_V0COTACAO_DB_OPEN_1()
        {
            /*" -618- EXEC SQL OPEN V0COTACAO END-EXEC. */

            V0COTACAO.Open();

        }

        [StopWatch]
        /*" R0210-00-DECLARE-MOVDEBCE-DB-DECLARE-1 */
        public void R0210_00_DECLARE_MOVDEBCE_DB_DECLARE_1()
        {
            /*" -814- EXEC SQL DECLARE V0MOVDEBCE CURSOR WITH HOLD FOR SELECT COD_EMPRESA ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO_COBRANCA ,DATA_VENCIMENTO ,DATA_VENCIMENTO + 1 MONTH ,VALOR_DEBITO ,DATA_MOVIMENTO ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DATA_ENVIO ,DATA_RETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA = '6' AND COD_CONVENIO = 102837 AND DATA_VENCIMENTO BETWEEN :SISTEMA-DTTERCOT AND :SISTEMA-DTMOV20D END-EXEC. */
            V0MOVDEBCE = new BI0070B_V0MOVDEBCE(true);
            string GetQuery_V0MOVDEBCE()
            {
                var query = @$"SELECT COD_EMPRESA 
							,NUM_APOLICE 
							,NUM_ENDOSSO 
							,NUM_PARCELA 
							,SITUACAO_COBRANCA 
							,DATA_VENCIMENTO 
							,DATA_VENCIMENTO + 1 MONTH 
							,VALOR_DEBITO 
							,DATA_MOVIMENTO 
							,DIA_DEBITO 
							,COD_AGENCIA_DEB 
							,OPER_CONTA_DEB 
							,NUM_CONTA_DEB 
							,DIG_CONTA_DEB 
							,COD_CONVENIO 
							,DATA_ENVIO 
							,DATA_RETORNO 
							,COD_RETORNO_CEF 
							,NSAS 
							,COD_USUARIO 
							,NUM_REQUISICAO 
							,NUM_CARTAO 
							,SEQUENCIA 
							,NUM_LOTE 
							,DTCREDITO 
							,STATUS_CARTAO 
							,VLR_CREDITO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE SITUACAO_COBRANCA = '6' 
							AND COD_CONVENIO = 102837 
							AND DATA_VENCIMENTO BETWEEN '{SISTEMA_DTTERCOT}' 
							AND '{SISTEMA_DTMOV20D}'";

                return query;
            }
            V0MOVDEBCE.GetQueryEvent += GetQuery_V0MOVDEBCE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0135-00-FETCH-V0COTACAO-SECTION */
        private void R0135_00_FETCH_V0COTACAO_SECTION()
        {
            /*" -636- MOVE '0135' TO WNR-EXEC-SQL. */
            _.Move("0135", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -639- PERFORM R0135_00_FETCH_V0COTACAO_DB_FETCH_1 */

            R0135_00_FETCH_V0COTACAO_DB_FETCH_1();

            /*" -642- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -643- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WS_WORK_AREAS.WFIM_MOVIMENTO);

                /*" -643- PERFORM R0135_00_FETCH_V0COTACAO_DB_CLOSE_1 */

                R0135_00_FETCH_V0COTACAO_DB_CLOSE_1();

                /*" -645- ELSE */
            }
            else
            {


                /*" -646- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -647- DISPLAY 'R0130-00 - PROBLEMAS NO DECLARE(COTACAO)' */
                    _.Display($"R0130-00 - PROBLEMAS NO DECLARE(COTACAO)");

                    /*" -647- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0135-00-FETCH-V0COTACAO-DB-FETCH-1 */
        public void R0135_00_FETCH_V0COTACAO_DB_FETCH_1()
        {
            /*" -639- EXEC SQL FETCH V0COTACAO INTO :MOEDACOT-DATA-INIVIGENCIA ,:MOEDACOT-VAL-VENDA END-EXEC. */

            if (V0COTACAO.Fetch())
            {
                _.Move(V0COTACAO.MOEDACOT_DATA_INIVIGENCIA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA);
                _.Move(V0COTACAO.MOEDACOT_VAL_VENDA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }

        }

        [StopWatch]
        /*" R0135-00-FETCH-V0COTACAO-DB-CLOSE-1 */
        public void R0135_00_FETCH_V0COTACAO_DB_CLOSE_1()
        {
            /*" -643- EXEC SQL CLOSE V0COTACAO END-EXEC */

            V0COTACAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-CARGA-V0COTACAO-SECTION */
        private void R0140_00_CARGA_V0COTACAO_SECTION()
        {
            /*" -660- MOVE '0140' TO WNR-EXEC-SQL. */
            _.Move("0140", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -662- ADD 1 TO WIND-1. */
            WS_WORK_AREAS.WIND_1.Value = WS_WORK_AREAS.WIND_1 + 1;

            /*" -663- IF WIND-1 GREATER 300 */

            if (WS_WORK_AREAS.WIND_1 > 300)
            {

                /*" -664- DISPLAY '*** BI0070B ESTOURO TAB. INTERNA TB-IPCA ' */
                _.Display($"*** BI0070B ESTOURO TAB. INTERNA TB-IPCA ");

                /*" -666- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -668- MOVE MOEDACOT-DATA-INIVIGENCIA TO W01DTSQL. */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA, WS_WORK_AREAS.W01DTSQL);

            /*" -669- MOVE W01MMSQL TO TB-MES-IPCA(WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01MMSQL, WS_TABELAS.TABELA_IPCA.FILLER_11[WS_WORK_AREAS.WIND_1].TB_DATA_IPCA_R.TB_MES_IPCA);

            /*" -671- MOVE W01AASQL TO TB-ANO-IPCA(WIND-1). */
            _.Move(WS_WORK_AREAS.W01DTSQL.W01AASQL, WS_TABELAS.TABELA_IPCA.FILLER_11[WS_WORK_AREAS.WIND_1].TB_DATA_IPCA_R.TB_ANO_IPCA);

            /*" -672- IF MOEDACOT-VAL-VENDA LESS ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA < 00)
            {

                /*" -674- MOVE 0 TO MOEDACOT-VAL-VENDA. */
                _.Move(0, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA);
            }


            /*" -676- MOVE MOEDACOT-VAL-VENDA TO TB-VAL-IPCA(WIND-1). */
            _.Move(MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA, WS_TABELAS.TABELA_IPCA.FILLER_11[WS_WORK_AREAS.WIND_1].TB_VAL_IPCA);

            /*" -677- IF MOEDACOT-VAL-VENDA EQUAL ZEROS */

            if (MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA == 00)
            {

                /*" -680- DISPLAY 'INDICE ZERADO OU NEGATIVO - DESPREZADO...' ' DTINIVIG  ...' MOEDACOT-DATA-INIVIGENCIA ' VAL-VENDA ...' MOEDACOT-VAL-VENDA */

                $"INDICE ZERADO OU NEGATIVO - DESPREZADO... DTINIVIG  ...{MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_DATA_INIVIGENCIA} VAL-VENDA ...{MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA}"
                .Display();

                /*" -683- GO TO R0140-90-LEITURA. */

                R0140_90_LEITURA(); //GOTO
                return;
            }


            /*" -685- COMPUTE WS-IPCA-ACUM = (((MOEDACOT-VAL-VENDA / 100 + 1) * (WS-IPCA-ACUM / 100 + 1) - 1 ) * 100). */
            WS_WORK_AREAS.WS_IPCA_ACUM.Value = (((MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_VENDA / 100f + 1) * (WS_WORK_AREAS.WS_IPCA_ACUM / 100f + 1) - 1) * 100);

            /*" -0- FLUXCONTROL_PERFORM R0140_90_LEITURA */

            R0140_90_LEITURA();

        }

        [StopWatch]
        /*" R0140-90-LEITURA */
        private void R0140_90_LEITURA(bool isPerform = false)
        {
            /*" -690- PERFORM R0135-00-FETCH-V0COTACAO. */

            R0135_00_FETCH_V0COTACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0155-00-CRITICA-INDICE-SECTION */
        private void R0155_00_CRITICA_INDICE_SECTION()
        {
            /*" -702- MOVE '0155' TO WNR-EXEC-SQL. */
            _.Move("0155", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -705- MOVE 'SIM' TO WS-PROCESSA-INDICE. */
            _.Move("SIM", WS_WORK_AREAS.WS_PROCESSA_INDICE);

            /*" -708- COMPUTE WS-IPCA-ACUM ROUNDED EQUAL (WS-IPCA-ACUM / 100). */
            WS_WORK_AREAS.WS_IPCA_ACUM.Value = (WS_WORK_AREAS.WS_IPCA_ACUM / 100f);

            /*" -709- IF WS-IPCA-ACUM NOT GREATER ZEROS */

            if (WS_WORK_AREAS.WS_IPCA_ACUM <= 00)
            {

                /*" -710- DISPLAY 'NAO HA AJUSTE PARA O PERIODO- IPCA ZERADO ' */
                _.Display($"NAO HA AJUSTE PARA O PERIODO- IPCA ZERADO ");

                /*" -711- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -714- MOVE 'NAO' TO WS-PROCESSA-INDICE. */
                _.Move("NAO", WS_WORK_AREAS.WS_PROCESSA_INDICE);
            }


            /*" -716- ADD 1 TO WS-IPCA-ACUM. */
            WS_WORK_AREAS.WS_IPCA_ACUM.Value = WS_WORK_AREAS.WS_IPCA_ACUM + 1;

            /*" -717- MOVE WS-IPCA-ACUM TO WS-IPCA-ACUM-DISPLAY */
            _.Move(WS_WORK_AREAS.WS_IPCA_ACUM, WS_WORK_AREAS.WS_IPCA_ACUM_DISPLAY);

            /*" -718- DISPLAY '*** BI0070B *** FATOR PARA CORRECAO        ' WS-IPCA-ACUM-DISPLAY. */
            _.Display($"*** BI0070B *** FATOR PARA CORRECAO        {WS_WORK_AREAS.WS_IPCA_ACUM_DISPLAY}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0155_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECIONA-SECTION */
        private void R0200_00_SELECIONA_SECTION()
        {
            /*" -731- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -732- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

            /*" -733- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -734- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -735- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -736- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -737- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -740- DISPLAY 'LEITURA MOVDEBCE  ' WTIME-DAYR. */
            _.Display($"LEITURA MOVDEBCE  {WS_WORK_AREAS.FILLER_4.WTIME_DAYR}");

            /*" -742- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", WS_WORK_AREAS.WFIM_MOVIMENTO);

            /*" -744- PERFORM R0210-00-DECLARE-MOVDEBCE. */

            R0210_00_DECLARE_MOVDEBCE_SECTION();

            /*" -746- PERFORM R0220-00-FETCH-MOVDEBCE. */

            R0220_00_FETCH_MOVDEBCE_SECTION();

            /*" -750- PERFORM R0230-00-PROCESSA-MOVDEBCE UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!WS_WORK_AREAS.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0230_00_PROCESSA_MOVDEBCE_SECTION();
            }

            /*" -751- DISPLAY ' ' . */
            _.Display($" ");

            /*" -752- DISPLAY 'LIDOS MOVDEBCE ............. ' LD-MOVDEBCE. */
            _.Display($"LIDOS MOVDEBCE ............. {WS_WORK_AREAS.LD_MOVDEBCE}");

            /*" -753- DISPLAY 'DESPREZA BILHETE ........... ' DP-BILHETE. */
            _.Display($"DESPREZA BILHETE ........... {WS_WORK_AREAS.DP_BILHETE}");

            /*" -754- DISPLAY 'DESPREZA SITUACAO .......... ' DP-SITUACAO. */
            _.Display($"DESPREZA SITUACAO .......... {WS_WORK_AREAS.DP_SITUACAO}");

            /*" -755- DISPLAY 'DESPREZA APOLCOBR .......... ' DP-APOLCOBR. */
            _.Display($"DESPREZA APOLCOBR .......... {WS_WORK_AREAS.DP_APOLCOBR}");

            /*" -756- DISPLAY 'DESPREZA ENDOSSOS .......... ' DP-ENDOSSOS. */
            _.Display($"DESPREZA ENDOSSOS .......... {WS_WORK_AREAS.DP_ENDOSSOS}");

            /*" -757- DISPLAY 'DESPREZA APOLICOB .......... ' DP-APOLICOB. */
            _.Display($"DESPREZA APOLICOB .......... {WS_WORK_AREAS.DP_APOLICOB}");

            /*" -758- DISPLAY 'DESPREZA PARCELAS .......... ' DP-PARCELAS. */
            _.Display($"DESPREZA PARCELAS .......... {WS_WORK_AREAS.DP_PARCELAS}");

            /*" -759- DISPLAY ' ' . */
            _.Display($" ");

            /*" -760- DISPLAY 'INSERT ENDOSSOS ............ ' AC-ENDOSSOS. */
            _.Display($"INSERT ENDOSSOS ............ {WS_WORK_AREAS.AC_ENDOSSOS}");

            /*" -761- DISPLAY 'INSERT APOLICOR ............ ' AC-APOLICOR. */
            _.Display($"INSERT APOLICOR ............ {WS_WORK_AREAS.AC_APOLICOR}");

            /*" -762- DISPLAY 'INSERT MOVDEBCE ............ ' AC-MOVDEBCE. */
            _.Display($"INSERT MOVDEBCE ............ {WS_WORK_AREAS.AC_MOVDEBCE}");

            /*" -763- DISPLAY 'INSERT RELATORI ............ ' AC-RELATORI. */
            _.Display($"INSERT RELATORI ............ {WS_WORK_AREAS.AC_RELATORI}");

            /*" -764- DISPLAY ' ' . */
            _.Display($" ");

            /*" -765- DISPLAY 'CORRECOES PELO IPCA ........ ' AC-IPCA. */
            _.Display($"CORRECOES PELO IPCA ........ {WS_WORK_AREAS.AC_IPCA}");

            /*" -767- DISPLAY ' ' . */
            _.Display($" ");

            /*" -767- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-DECLARE-MOVDEBCE-SECTION */
        private void R0210_00_DECLARE_MOVDEBCE_SECTION()
        {
            /*" -780- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -814- PERFORM R0210_00_DECLARE_MOVDEBCE_DB_DECLARE_1 */

            R0210_00_DECLARE_MOVDEBCE_DB_DECLARE_1();

            /*" -817- PERFORM R0210_00_DECLARE_MOVDEBCE_DB_OPEN_1 */

            R0210_00_DECLARE_MOVDEBCE_DB_OPEN_1();

            /*" -821- DISPLAY '                                  ' . */
            _.Display($"                                  ");

            /*" -822- DISPLAY '*** BI0070B *** ABRINDO CURSOR CMDEBCC' . */
            _.Display($"*** BI0070B *** ABRINDO CURSOR CMDEBCC");

            /*" -825- DISPLAY '                PERIODO: DE ' SISTEMA-DTTERCOT ' ATE ' SISTEMA-DTMOV20D. */

            $"                PERIODO: DE {SISTEMA_DTTERCOT} ATE {SISTEMA_DTMOV20D}"
            .Display();

            /*" -828- DISPLAY '                                  ' . */
            _.Display($"                                  ");

            /*" -829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -830- DISPLAY 'R0210-00 - PROBLEMAS NO DECLARE(MOVDEBCE)' */
                _.Display($"R0210-00 - PROBLEMAS NO DECLARE(MOVDEBCE)");

                /*" -830- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-DECLARE-MOVDEBCE-DB-OPEN-1 */
        public void R0210_00_DECLARE_MOVDEBCE_DB_OPEN_1()
        {
            /*" -817- EXEC SQL OPEN V0MOVDEBCE END-EXEC. */

            V0MOVDEBCE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-FETCH-MOVDEBCE-SECTION */
        private void R0220_00_FETCH_MOVDEBCE_SECTION()
        {
            /*" -843- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -871- PERFORM R0220_00_FETCH_MOVDEBCE_DB_FETCH_1 */

            R0220_00_FETCH_MOVDEBCE_DB_FETCH_1();

            /*" -875- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -876- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WS_WORK_AREAS.WFIM_MOVIMENTO);

                /*" -876- PERFORM R0220_00_FETCH_MOVDEBCE_DB_CLOSE_1 */

                R0220_00_FETCH_MOVDEBCE_DB_CLOSE_1();

                /*" -879- GO TO R0220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -880- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -881- DISPLAY 'R0220-00 - PROBLEMAS NO FETCH(MOVDEBCE)' */
                _.Display($"R0220-00 - PROBLEMAS NO FETCH(MOVDEBCE)");

                /*" -884- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -886- ADD 1 TO LD-MOVDEBCE. */
            WS_WORK_AREAS.LD_MOVDEBCE.Value = WS_WORK_AREAS.LD_MOVDEBCE + 1;

            /*" -888- MOVE LD-MOVDEBCE TO AC-LIDOS. */
            _.Move(WS_WORK_AREAS.LD_MOVDEBCE, WS_WORK_AREAS.AC_LIDOS);

            /*" -890- IF LD-PARTE2 EQUAL ZEROS OR LD-PARTE2 EQUAL 5000 */

            if (WS_WORK_AREAS.FILLER_0.LD_PARTE2 == 00 || WS_WORK_AREAS.FILLER_0.LD_PARTE2 == 5000)
            {

                /*" -891- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_WORK_AREAS.WS_TIME);

                /*" -892- MOVE WS-HH-TIME TO WTIME-HORA */
                _.Move(WS_WORK_AREAS.WS_TIME.WS_HH_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_HORA);

                /*" -893- MOVE '.' TO WTIME-2PT1 */
                _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT1);

                /*" -894- MOVE WS-MM-TIME TO WTIME-MINU */
                _.Move(WS_WORK_AREAS.WS_TIME.WS_MM_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_MINU);

                /*" -895- MOVE '.' TO WTIME-2PT2 */
                _.Move(".", WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_2PT2);

                /*" -896- MOVE WS-SS-TIME TO WTIME-SEGU */
                _.Move(WS_WORK_AREAS.WS_TIME.WS_SS_TIME, WS_WORK_AREAS.FILLER_4.WTIME_DAYR.WTIME_SEGU);

                /*" -897- DISPLAY 'LIDOS MOVDEBCE     ' AC-LIDOS '    ' WTIME-DAYR. */

                $"LIDOS MOVDEBCE     {WS_WORK_AREAS.AC_LIDOS}    {WS_WORK_AREAS.FILLER_4.WTIME_DAYR}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0220-00-FETCH-MOVDEBCE-DB-FETCH-1 */
        public void R0220_00_FETCH_MOVDEBCE_DB_FETCH_1()
        {
            /*" -871- EXEC SQL FETCH V0MOVDEBCE INTO :MOVDEBCE-COD-EMPRESA ,:MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-DATA-PROXVEN ,:MOVDEBCE-VALOR-DEBITO ,:MOVDEBCE-DATA-MOVIMENTO ,:MOVDEBCE-DIA-DEBITO :VIND-DIADEBITO ,:MOVDEBCE-COD-AGENCIA-DEB :VIND-AGENCIA ,:MOVDEBCE-OPER-CONTA-DEB :VIND-OPERACAO ,:MOVDEBCE-NUM-CONTA-DEB :VIND-NUMCONTA ,:MOVDEBCE-DIG-CONTA-DEB :VIND-DIGCONTA ,:MOVDEBCE-COD-CONVENIO ,:MOVDEBCE-DATA-ENVIO :VIND-DTENVIO ,:MOVDEBCE-DATA-RETORNO :VIND-DTRETORNO ,:MOVDEBCE-COD-RETORNO-CEF :VIND-CODRETORNO ,:MOVDEBCE-NSAS ,:MOVDEBCE-COD-USUARIO :VIND-USUARIO ,:MOVDEBCE-NUM-REQUISICAO :VIND-REQUISICAO ,:MOVDEBCE-NUM-CARTAO :VIND-NUMCARTAO ,:MOVDEBCE-SEQUENCIA :VIND-SEQUENCIA ,:MOVDEBCE-NUM-LOTE :VIND-NUM-LOTE ,:MOVDEBCE-DTCREDITO :VIND-DTCREDITO ,:MOVDEBCE-STATUS-CARTAO :VIND-STATUS ,:MOVDEBCE-VLR-CREDITO :VIND-VLCREDITO END-EXEC. */

            if (V0MOVDEBCE.Fetch())
            {
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_EMPRESA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(V0MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_PROXVEN, MOVDEBCE_DATA_PROXVEN);
                _.Move(V0MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);
                _.Move(V0MOVDEBCE.VIND_DIADEBITO, VIND_DIADEBITO);
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(V0MOVDEBCE.VIND_AGENCIA, VIND_AGENCIA);
                _.Move(V0MOVDEBCE.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(V0MOVDEBCE.VIND_OPERACAO, VIND_OPERACAO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(V0MOVDEBCE.VIND_NUMCONTA, VIND_NUMCONTA);
                _.Move(V0MOVDEBCE.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(V0MOVDEBCE.VIND_DIGCONTA, VIND_DIGCONTA);
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO);
                _.Move(V0MOVDEBCE.VIND_DTENVIO, VIND_DTENVIO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_RETORNO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);
                _.Move(V0MOVDEBCE.VIND_DTRETORNO, VIND_DTRETORNO);
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
                _.Move(V0MOVDEBCE.VIND_CODRETORNO, VIND_CODRETORNO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_USUARIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);
                _.Move(V0MOVDEBCE.VIND_USUARIO, VIND_USUARIO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(V0MOVDEBCE.VIND_REQUISICAO, VIND_REQUISICAO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(V0MOVDEBCE.VIND_NUMCARTAO, VIND_NUMCARTAO);
                _.Move(V0MOVDEBCE.MOVDEBCE_SEQUENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);
                _.Move(V0MOVDEBCE.VIND_SEQUENCIA, VIND_SEQUENCIA);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_LOTE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE);
                _.Move(V0MOVDEBCE.VIND_NUM_LOTE, VIND_NUM_LOTE);
                _.Move(V0MOVDEBCE.MOVDEBCE_DTCREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO);
                _.Move(V0MOVDEBCE.VIND_DTCREDITO, VIND_DTCREDITO);
                _.Move(V0MOVDEBCE.MOVDEBCE_STATUS_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);
                _.Move(V0MOVDEBCE.VIND_STATUS, VIND_STATUS);
                _.Move(V0MOVDEBCE.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(V0MOVDEBCE.VIND_VLCREDITO, VIND_VLCREDITO);
            }

        }

        [StopWatch]
        /*" R0220-00-FETCH-MOVDEBCE-DB-CLOSE-1 */
        public void R0220_00_FETCH_MOVDEBCE_DB_CLOSE_1()
        {
            /*" -876- EXEC SQL CLOSE V0MOVDEBCE END-EXEC */

            V0MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-PROCESSA-MOVDEBCE-SECTION */
        private void R0230_00_PROCESSA_MOVDEBCE_SECTION()
        {
            /*" -910- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -912- PERFORM R0240-00-SELECT-BILHETE. */

            R0240_00_SELECT_BILHETE_SECTION();

            /*" -913- IF WS-TEM-BILHETE EQUAL 'N' */

            if (WS_WORK_AREAS.WS_TEM_BILHETE == "N")
            {

                /*" -914- ADD 1 TO DP-BILHETE */
                WS_WORK_AREAS.DP_BILHETE.Value = WS_WORK_AREAS.DP_BILHETE + 1;

                /*" -916- GO TO R0230-90-LEITURA. */

                R0230_90_LEITURA(); //GOTO
                return;
            }


            /*" -917- IF BILHETE-SITUACAO NOT EQUAL '9' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO != "9")
            {

                /*" -918- ADD 1 TO DP-SITUACAO */
                WS_WORK_AREAS.DP_SITUACAO.Value = WS_WORK_AREAS.DP_SITUACAO + 1;

                /*" -919- PERFORM R0500-00-UPDATE-MOVDEBCE */

                R0500_00_UPDATE_MOVDEBCE_SECTION();

                /*" -922- GO TO R0230-90-LEITURA. */

                R0230_90_LEITURA(); //GOTO
                return;
            }


            /*" -925- PERFORM R0250-00-SELECT-RAMOCOMP. */

            R0250_00_SELECT_RAMOCOMP_SECTION();

            /*" -927- PERFORM R0260-00-SELECT-APOLCOBR. */

            R0260_00_SELECT_APOLCOBR_SECTION();

            /*" -928- IF WS-TEM-BILHETE EQUAL 'N' */

            if (WS_WORK_AREAS.WS_TEM_BILHETE == "N")
            {

                /*" -929- ADD 1 TO DP-APOLCOBR */
                WS_WORK_AREAS.DP_APOLCOBR.Value = WS_WORK_AREAS.DP_APOLCOBR + 1;

                /*" -932- GO TO R0230-90-LEITURA. */

                R0230_90_LEITURA(); //GOTO
                return;
            }


            /*" -938- PERFORM R0280-00-SELECT-PROPOFID. */

            R0280_00_SELECT_PROPOFID_SECTION();

            /*" -941- COMPUTE WHOST-NUM-ENDOSSO EQUAL (MOVDEBCE-NUM-ENDOSSO - 1). */
            WHOST_NUM_ENDOSSO.Value = (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO - 1);

            /*" -943- PERFORM R0600-00-SELECT-ENDOSSOS. */

            R0600_00_SELECT_ENDOSSOS_SECTION();

            /*" -944- IF WS-TEM-BILHETE EQUAL 'N' */

            if (WS_WORK_AREAS.WS_TEM_BILHETE == "N")
            {

                /*" -945- ADD 1 TO DP-ENDOSSOS */
                WS_WORK_AREAS.DP_ENDOSSOS.Value = WS_WORK_AREAS.DP_ENDOSSOS + 1;

                /*" -951- GO TO R0230-90-LEITURA. */

                R0230_90_LEITURA(); //GOTO
                return;
            }


            /*" -957- PERFORM R0620-00-PESQUISA-FATURAS. */

            R0620_00_PESQUISA_FATURAS_SECTION();

            /*" -957- PERFORM R3000-00-PROXIMA-PARCELA. */

            R3000_00_PROXIMA_PARCELA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0230_90_LEITURA */

            R0230_90_LEITURA();

        }

        [StopWatch]
        /*" R0230-90-LEITURA */
        private void R0230_90_LEITURA(bool isPerform = false)
        {
            /*" -962- PERFORM R0220-00-FETCH-MOVDEBCE. */

            R0220_00_FETCH_MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECT-BILHETE-SECTION */
        private void R0240_00_SELECT_BILHETE_SECTION()
        {
            /*" -973- MOVE '0240' TO WNR-EXEC-SQL. */
            _.Move("0240", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -975- MOVE MOVDEBCE-NUM-ENDOSSO TO WIND2. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, WIND2);

            /*" -977- COMPUTE WIND EQUAL MOVDEBCE-NUM-ENDOSSO - 1. */
            WIND.Value = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO - 1;

            /*" -980- COMPUTE WIND3 EQUAL MOVDEBCE-NUM-ENDOSSO + 1. */
            WIND3.Value = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO + 1;

            /*" -996- PERFORM R0240_00_SELECT_BILHETE_DB_SELECT_1 */

            R0240_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -1000- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1001- MOVE 'N' TO WS-TEM-BILHETE */
                _.Move("N", WS_WORK_AREAS.WS_TEM_BILHETE);

                /*" -1002- ELSE */
            }
            else
            {


                /*" -1003- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1005- DISPLAY 'R0240-00 - PROBLEMAS NO SELECT(BILHETE)' ' APOLICE  ' MOVDEBCE-NUM-APOLICE */

                    $"R0240-00 - PROBLEMAS NO SELECT(BILHETE) APOLICE  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}"
                    .Display();

                    /*" -1006- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1007- ELSE */
                }
                else
                {


                    /*" -1007- MOVE 'S' TO WS-TEM-BILHETE. */
                    _.Move("S", WS_WORK_AREAS.WS_TEM_BILHETE);
                }

            }


        }

        [StopWatch]
        /*" R0240-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R0240_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -996- EXEC SQL SELECT NUM_BILHETE ,RAMO ,SITUACAO ,DATA_QUITACAO + :WIND MONTH + 1 DAY ,DATA_QUITACAO + :WIND2 MONTH ,DATA_QUITACAO + :WIND3 MONTH INTO :BILHETE-NUM-BILHETE ,:BILHETE-RAMO ,:BILHETE-SITUACAO ,:WSGER00-DATA-INIVIGENCIA ,:WSGER00-DATA-TERVIGENCIA ,:WSGER00-DATA-CORRETOR FROM SEGUROS.BILHETE WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE WITH UR END-EXEC. */

            var r0240_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                WIND2 = WIND2.ToString(),
                WIND3 = WIND3.ToString(),
                WIND = WIND.ToString(),
            };

            var executed_1 = R0240_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r0240_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(executed_1.WSGER00_DATA_INIVIGENCIA, WSGER00_DATA_INIVIGENCIA);
                _.Move(executed_1.WSGER00_DATA_TERVIGENCIA, WSGER00_DATA_TERVIGENCIA);
                _.Move(executed_1.WSGER00_DATA_CORRETOR, WSGER00_DATA_CORRETOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-SELECT-RAMOCOMP-SECTION */
        private void R0250_00_SELECT_RAMOCOMP_SECTION()
        {
            /*" -1020- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1028- PERFORM R0250_00_SELECT_RAMOCOMP_DB_SELECT_1 */

            R0250_00_SELECT_RAMOCOMP_DB_SELECT_1();

            /*" -1032- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1034- MOVE ZEROS TO RAMOCOMP-PCT-IOCC-RAMO */
                _.Move(0, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);

                /*" -1035- ELSE */
            }
            else
            {


                /*" -1036- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1038- DISPLAY 'R0250-00 - PROBLEMAS NO SELECT(RAMOCOMP)' ' RAMO   =   ' BILHETE-RAMO */

                    $"R0250-00 - PROBLEMAS NO SELECT(RAMOCOMP) RAMO   =   {BILHETE.DCLBILHETE.BILHETE_RAMO}"
                    .Display();

                    /*" -1038- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0250-00-SELECT-RAMOCOMP-DB-SELECT-1 */
        public void R0250_00_SELECT_RAMOCOMP_DB_SELECT_1()
        {
            /*" -1028- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :BILHETE-RAMO AND DATA_INIVIGENCIA <= :WSGER00-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :WSGER00-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1 = new R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1()
            {
                WSGER00_DATA_INIVIGENCIA = WSGER00_DATA_INIVIGENCIA.ToString(),
                BILHETE_RAMO = BILHETE.DCLBILHETE.BILHETE_RAMO.ToString(),
            };

            var executed_1 = R0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1.Execute(r0250_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-SELECT-APOLCOBR-SECTION */
        private void R0260_00_SELECT_APOLCOBR_SECTION()
        {
            /*" -1051- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1070- PERFORM R0260_00_SELECT_APOLCOBR_DB_SELECT_1 */

            R0260_00_SELECT_APOLCOBR_DB_SELECT_1();

            /*" -1074- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1075- MOVE 'N' TO WS-TEM-BILHETE */
                _.Move("N", WS_WORK_AREAS.WS_TEM_BILHETE);

                /*" -1078- GO TO R0260-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1079- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1081- DISPLAY 'R0260-00 - PROBLEMAS NO SELECT(APOLCOBR)' ' APOLICE  ' MOVDEBCE-NUM-APOLICE */

                $"R0260-00 - PROBLEMAS NO SELECT(APOLCOBR) APOLICE  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}"
                .Display();

                /*" -1084- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1087- MOVE 'S' TO WS-TEM-BILHETE. */
            _.Move("S", WS_WORK_AREAS.WS_TEM_BILHETE);

            /*" -1088- IF VIND-AGEDEB LESS ZEROS */

            if (VIND_AGEDEB < 00)
            {

                /*" -1091- MOVE ZEROS TO APOLCOBR-COD-AGENCIA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);
            }


            /*" -1092- IF VIND-OPEDEB LESS ZEROS */

            if (VIND_OPEDEB < 00)
            {

                /*" -1095- MOVE ZEROS TO APOLCOBR-OPER-CONTA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);
            }


            /*" -1096- IF VIND-NUMDEB LESS ZEROS */

            if (VIND_NUMDEB < 00)
            {

                /*" -1099- MOVE ZEROS TO APOLCOBR-NUM-CONTA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);
            }


            /*" -1100- IF VIND-DIGDEB LESS ZEROS */

            if (VIND_DIGDEB < 00)
            {

                /*" -1103- MOVE ZEROS TO APOLCOBR-DIG-CONTA-DEB. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);
            }


            /*" -1104- IF VIND-CARTAO LESS ZEROS */

            if (VIND_CARTAO < 00)
            {

                /*" -1107- MOVE ZEROS TO APOLCOBR-NUM-CARTAO. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);
            }


            /*" -1108- IF VIND-DIADEB LESS ZEROS */

            if (VIND_DIADEB < 00)
            {

                /*" -1109- MOVE ZEROS TO APOLCOBR-DIA-DEBITO. */
                _.Move(0, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO);
            }


        }

        [StopWatch]
        /*" R0260-00-SELECT-APOLCOBR-DB-SELECT-1 */
        public void R0260_00_SELECT_APOLCOBR_DB_SELECT_1()
        {
            /*" -1070- EXEC SQL SELECT COD_AGENCIA ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,NUM_CARTAO ,DIA_DEBITO INTO :APOLCOBR-COD-AGENCIA ,:APOLCOBR-COD-AGENCIA-DEB:VIND-AGEDEB ,:APOLCOBR-OPER-CONTA-DEB:VIND-OPEDEB ,:APOLCOBR-NUM-CONTA-DEB:VIND-NUMDEB ,:APOLCOBR-DIG-CONTA-DEB:VIND-DIGDEB ,:APOLCOBR-NUM-CARTAO:VIND-CARTAO ,:APOLCOBR-DIA-DEBITO:VIND-DIADEB FROM SEGUROS.APOLICE_COBRANCA WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1 = new R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1.Execute(r0260_00_SELECT_APOLCOBR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLCOBR_COD_AGENCIA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA);
                _.Move(executed_1.APOLCOBR_COD_AGENCIA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB);
                _.Move(executed_1.VIND_AGEDEB, VIND_AGEDEB);
                _.Move(executed_1.APOLCOBR_OPER_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB);
                _.Move(executed_1.VIND_OPEDEB, VIND_OPEDEB);
                _.Move(executed_1.APOLCOBR_NUM_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB);
                _.Move(executed_1.VIND_NUMDEB, VIND_NUMDEB);
                _.Move(executed_1.APOLCOBR_DIG_CONTA_DEB, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB);
                _.Move(executed_1.VIND_DIGDEB, VIND_DIGDEB);
                _.Move(executed_1.APOLCOBR_NUM_CARTAO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
                _.Move(executed_1.APOLCOBR_DIA_DEBITO, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO);
                _.Move(executed_1.VIND_DIADEB, VIND_DIADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0280-00-SELECT-PROPOFID-SECTION */
        private void R0280_00_SELECT_PROPOFID_SECTION()
        {
            /*" -1122- MOVE '0280' TO WNR-EXEC-SQL. */
            _.Move("0280", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1130- PERFORM R0280_00_SELECT_PROPOFID_DB_SELECT_1 */

            R0280_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -1134- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1137- MOVE ZEROS TO PROPOFID-NUM-PROPOSTA-SIVPF PROPOFID-ORIGEM-PROPOSTA */
                _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                /*" -1138- ELSE */
            }
            else
            {


                /*" -1139- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1142- DISPLAY 'R0280-00 - PROBLEMAS NO SELECT(PROPOFID)' ' APOLICE  ' MOVDEBCE-NUM-APOLICE ' BILHETE  ' BILHETE-NUM-BILHETE */

                    $"R0280-00 - PROBLEMAS NO SELECT(PROPOFID) APOLICE  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} BILHETE  {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}"
                    .Display();

                    /*" -1142- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0280-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R0280_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -1130- EXEC SQL SELECT NUM_PROPOSTA_SIVPF ,ORIGEM_PROPOSTA INTO :PROPOFID-NUM-PROPOSTA-SIVPF ,:PROPOFID-ORIGEM-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :BILHETE-NUM-BILHETE WITH UR END-EXEC. */

            var r0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r0280_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0280_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-UPDATE-MOVDEBCE-SECTION */
        private void R0500_00_UPDATE_MOVDEBCE_SECTION()
        {
            /*" -1155- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1164- PERFORM R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1 */

            R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1();

            /*" -1169- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1170- DISPLAY 'R0500-00 - PROBLEMAS UPDATE (MOVDEBCE) ' */
                _.Display($"R0500-00 - PROBLEMAS UPDATE (MOVDEBCE) ");

                /*" -1170- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-UPDATE-MOVDEBCE-DB-UPDATE-1 */
        public void R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1()
        {
            /*" -1164- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = 'A' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO END-EXEC. */

            var r0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 = new R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1.Execute(r0500_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-ENDOSSOS-SECTION */
        private void R0600_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1183- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1244- PERFORM R0600_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0600_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1248- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1249- MOVE 'N' TO WS-TEM-BILHETE */
                _.Move("N", WS_WORK_AREAS.WS_TEM_BILHETE);

                /*" -1250- ELSE */
            }
            else
            {


                /*" -1251- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1254- DISPLAY 'R0600-00 - PROBLEMAS NO SELECT(ENDOSSOS)' ' APOLICE ' MOVDEBCE-NUM-APOLICE ' ENDOSSO ' WHOST-NUM-ENDOSSO */

                    $"R0600-00 - PROBLEMAS NO SELECT(ENDOSSOS) APOLICE {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} ENDOSSO {WHOST_NUM_ENDOSSO}"
                    .Display();

                    /*" -1255- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1256- ELSE */
                }
                else
                {


                    /*" -1256- MOVE 'S' TO WS-TEM-BILHETE. */
                    _.Move("S", WS_WORK_AREAS.WS_TEM_BILHETE);
                }

            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0600_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1244- EXEC SQL SELECT NUM_APOLICE ,RAMO_EMISSOR ,COD_PRODUTO ,COD_SUBGRUPO ,COD_FONTE ,DATA_PROPOSTA ,DATA_LIBERACAO ,BCO_COBRANCA ,AGE_COBRANCA ,DAC_COBRANCA ,PLANO_SEGURO ,PCT_ENTRADA ,PCT_ADIC_FRACIO ,QTD_DIAS_PRIMEIRA ,QTD_PARCELAS ,QTD_PRESTACOES ,QTD_ITENS ,COD_TEXTO_PADRAO ,COD_ACEITACAO ,COD_MOEDA_IMP ,COD_MOEDA_PRM ,TIPO_ENDOSSO ,OCORR_ENDERECO ,COD_EMPRESA ,TIPO_CORRECAO ,ISENTA_CUSTO ,COEF_PREFIX ,VAL_CUSTO_EMISSAO INTO :ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-DATA-PROPOSTA ,:ENDOSSOS-DATA-LIBERACAO ,:ENDOSSOS-BCO-COBRANCA ,:ENDOSSOS-AGE-COBRANCA ,:ENDOSSOS-DAC-COBRANCA ,:ENDOSSOS-PLANO-SEGURO ,:ENDOSSOS-PCT-ENTRADA ,:ENDOSSOS-PCT-ADIC-FRACIO ,:ENDOSSOS-QTD-DIAS-PRIMEIRA ,:ENDOSSOS-QTD-PARCELAS ,:ENDOSSOS-QTD-PRESTACOES ,:ENDOSSOS-QTD-ITENS ,:ENDOSSOS-COD-TEXTO-PADRAO ,:ENDOSSOS-COD-ACEITACAO ,:ENDOSSOS-COD-MOEDA-IMP ,:ENDOSSOS-COD-MOEDA-PRM ,:ENDOSSOS-TIPO-ENDOSSO ,:ENDOSSOS-OCORR-ENDERECO ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                WHOST_NUM_ENDOSSO = WHOST_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_LIBERACAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO);
                _.Move(executed_1.ENDOSSOS_BCO_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA);
                _.Move(executed_1.ENDOSSOS_AGE_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);
                _.Move(executed_1.ENDOSSOS_DAC_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA);
                _.Move(executed_1.ENDOSSOS_PLANO_SEGURO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO);
                _.Move(executed_1.ENDOSSOS_PCT_ENTRADA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA);
                _.Move(executed_1.ENDOSSOS_PCT_ADIC_FRACIO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO);
                _.Move(executed_1.ENDOSSOS_QTD_DIAS_PRIMEIRA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA);
                _.Move(executed_1.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
                _.Move(executed_1.ENDOSSOS_QTD_PRESTACOES, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES);
                _.Move(executed_1.ENDOSSOS_QTD_ITENS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS);
                _.Move(executed_1.ENDOSSOS_COD_TEXTO_PADRAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO);
                _.Move(executed_1.ENDOSSOS_COD_ACEITACAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_IMP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_TIPO_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(executed_1.ENDOSSOS_COD_EMPRESA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA);
                _.Move(executed_1.VIND_COD_EMPRESA, VIND_COD_EMPRESA);
                _.Move(executed_1.ENDOSSOS_TIPO_CORRECAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO);
                _.Move(executed_1.VIND_TIPO_CORRECAO, VIND_TIPO_CORRECAO);
                _.Move(executed_1.ENDOSSOS_ISENTA_CUSTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO);
                _.Move(executed_1.VIND_ISENTA_CUSTO, VIND_ISENTA_CUSTO);
                _.Move(executed_1.ENDOSSOS_COEF_PREFIX, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX);
                _.Move(executed_1.VIND_COEF_PREFIX, VIND_COEF_PREFIX);
                _.Move(executed_1.ENDOSSOS_VAL_CUSTO_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO);
                _.Move(executed_1.VIND_VAL_CUSTO, VIND_VAL_CUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0620-00-PESQUISA-FATURAS-SECTION */
        private void R0620_00_PESQUISA_FATURAS_SECTION()
        {
            /*" -1269- MOVE '0620' TO WNR-EXEC-SQL. */
            _.Move("0620", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1270- IF MOVDEBCE-NUM-ENDOSSO LESS 14 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO < 14)
            {

                /*" -1272- MOVE 1 TO WHOST-NUM-ENDOSSO */
                _.Move(1, WHOST_NUM_ENDOSSO);

                /*" -1273- ELSE */
            }
            else
            {


                /*" -1274- IF MOVDEBCE-NUM-ENDOSSO LESS 26 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO < 26)
                {

                    /*" -1276- MOVE 13 TO WHOST-NUM-ENDOSSO */
                    _.Move(13, WHOST_NUM_ENDOSSO);

                    /*" -1277- ELSE */
                }
                else
                {


                    /*" -1278- IF MOVDEBCE-NUM-ENDOSSO LESS 38 */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO < 38)
                    {

                        /*" -1280- MOVE 25 TO WHOST-NUM-ENDOSSO */
                        _.Move(25, WHOST_NUM_ENDOSSO);

                        /*" -1281- ELSE */
                    }
                    else
                    {


                        /*" -1282- IF MOVDEBCE-NUM-ENDOSSO LESS 50 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO < 50)
                        {

                            /*" -1284- MOVE 37 TO WHOST-NUM-ENDOSSO */
                            _.Move(37, WHOST_NUM_ENDOSSO);

                            /*" -1285- ELSE */
                        }
                        else
                        {


                            /*" -1292- MOVE 49 TO WHOST-NUM-ENDOSSO. */
                            _.Move(49, WHOST_NUM_ENDOSSO);
                        }

                    }

                }

            }


            /*" -1294- PERFORM R0640-00-SELECT-APOLICOB. */

            R0640_00_SELECT_APOLICOB_SECTION();

            /*" -1295- IF WS-TEM-BILHETE EQUAL 'N' */

            if (WS_WORK_AREAS.WS_TEM_BILHETE == "N")
            {

                /*" -1296- ADD 1 TO DP-APOLICOB */
                WS_WORK_AREAS.DP_APOLICOB.Value = WS_WORK_AREAS.DP_APOLICOB + 1;

                /*" -1299- GO TO R0620-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1301- PERFORM R0660-00-SELECT-PARCELAS. */

            R0660_00_SELECT_PARCELAS_SECTION();

            /*" -1302- IF WS-TEM-BILHETE EQUAL 'N' */

            if (WS_WORK_AREAS.WS_TEM_BILHETE == "N")
            {

                /*" -1303- ADD 1 TO DP-PARCELAS */
                WS_WORK_AREAS.DP_PARCELAS.Value = WS_WORK_AREAS.DP_PARCELAS + 1;

                /*" -1306- GO TO R0620-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1310- IF MOVDEBCE-NUM-ENDOSSO EQUAL 13 OR 25 OR 37 OR 49 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.In("13", "25", "37", "49"))
            {

                /*" -1311- PERFORM R0700-00-CORRIGE-IPCA */

                R0700_00_CORRIGE_IPCA_SECTION();

                /*" -1312- PERFORM R1000-00-EMITE-ENDOSSO */

                R1000_00_EMITE_ENDOSSO_SECTION();

                /*" -1313- PERFORM R2000-00-MONTA-CORRETAGEM */

                R2000_00_MONTA_CORRETAGEM_SECTION();

                /*" -1314- PERFORM R4000-00-INSERT-RELATORI */

                R4000_00_INSERT_RELATORI_SECTION();

                /*" -1315- ELSE */
            }
            else
            {


                /*" -1315- PERFORM R1000-00-EMITE-ENDOSSO. */

                R1000_00_EMITE_ENDOSSO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0640-00-SELECT-APOLICOB-SECTION */
        private void R0640_00_SELECT_APOLICOB_SECTION()
        {
            /*" -1328- MOVE '0640' TO WNR-EXEC-SQL. */
            _.Move("0640", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1360- PERFORM R0640_00_SELECT_APOLICOB_DB_SELECT_1 */

            R0640_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -1364- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1365- MOVE 'N' TO WS-TEM-BILHETE */
                _.Move("N", WS_WORK_AREAS.WS_TEM_BILHETE);

                /*" -1366- ELSE */
            }
            else
            {


                /*" -1367- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1370- DISPLAY 'R0640-00 - PROBLEMAS NO SELECT(APOLICOB)' ' APOLICE ' MOVDEBCE-NUM-APOLICE ' ENDOSSO ' WHOST-NUM-ENDOSSO */

                    $"R0640-00 - PROBLEMAS NO SELECT(APOLICOB) APOLICE {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} ENDOSSO {WHOST_NUM_ENDOSSO}"
                    .Display();

                    /*" -1371- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1372- ELSE */
                }
                else
                {


                    /*" -1372- MOVE 'S' TO WS-TEM-BILHETE. */
                    _.Move("S", WS_WORK_AREAS.WS_TEM_BILHETE);
                }

            }


        }

        [StopWatch]
        /*" R0640-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R0640_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -1360- EXEC SQL SELECT NUM_APOLICE ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA INTO :APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ITEM ,:APOLICOB-OCORR-HISTORICO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PRM-TARIFARIO-VAR ,:APOLICOB-PCT-COBERTURA ,:APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA = 0 AND PCT_COBERTURA = 100 WITH UR END-EXEC. */

            var r0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                WHOST_NUM_ENDOSSO = WHOST_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r0640_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(executed_1.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);
                _.Move(executed_1.APOLICOB_OCORR_HISTORICO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(executed_1.APOLICOB_MODALI_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);
                _.Move(executed_1.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
                _.Move(executed_1.APOLICOB_PCT_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0640_99_SAIDA*/

        [StopWatch]
        /*" R0660-00-SELECT-PARCELAS-SECTION */
        private void R0660_00_SELECT_PARCELAS_SECTION()
        {
            /*" -1385- MOVE '0660' TO WNR-EXEC-SQL. */
            _.Move("0660", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1412- PERFORM R0660_00_SELECT_PARCELAS_DB_SELECT_1 */

            R0660_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -1416- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1417- MOVE 'N' TO WS-TEM-BILHETE */
                _.Move("N", WS_WORK_AREAS.WS_TEM_BILHETE);

                /*" -1418- ELSE */
            }
            else
            {


                /*" -1419- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1422- DISPLAY 'R0660-00 - PROBLEMAS NO SELECT(PARCELAS)' ' APOLICE ' MOVDEBCE-NUM-APOLICE ' ENDOSSO ' WHOST-NUM-ENDOSSO */

                    $"R0660-00 - PROBLEMAS NO SELECT(PARCELAS) APOLICE {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} ENDOSSO {WHOST_NUM_ENDOSSO}"
                    .Display();

                    /*" -1423- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1424- ELSE */
                }
                else
                {


                    /*" -1424- MOVE 'S' TO WS-TEM-BILHETE. */
                    _.Move("S", WS_WORK_AREAS.WS_TEM_BILHETE);
                }

            }


        }

        [StopWatch]
        /*" R0660-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R0660_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -1412- EXEC SQL SELECT NUM_APOLICE ,NUM_PARCELA ,DAC_PARCELA ,COD_FONTE ,PRM_TARIFARIO_IX ,VAL_DESCONTO_IX ,PRM_LIQUIDO_IX ,ADICIONAL_FRAC_IX ,VAL_CUSTO_EMIS_IX ,VAL_IOCC_IX ,PRM_TOTAL_IX INTO :PARCELAS-NUM-APOLICE ,:PARCELAS-NUM-PARCELA ,:PARCELAS-DAC-PARCELA ,:PARCELAS-COD-FONTE ,:PARCELAS-PRM-TARIFARIO-IX ,:PARCELAS-VAL-DESCONTO-IX ,:PARCELAS-PRM-LIQUIDO-IX ,:PARCELAS-ADICIONAL-FRAC-IX ,:PARCELAS-VAL-CUSTO-EMIS-IX ,:PARCELAS-VAL-IOCC-IX ,:PARCELAS-PRM-TOTAL-IX FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :WHOST-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                WHOST_NUM_ENDOSSO = WHOST_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r0660_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);
                _.Move(executed_1.PARCELAS_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);
                _.Move(executed_1.PARCELAS_DAC_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);
                _.Move(executed_1.PARCELAS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);
                _.Move(executed_1.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);
                _.Move(executed_1.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);
                _.Move(executed_1.PARCELAS_PRM_LIQUIDO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);
                _.Move(executed_1.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);
                _.Move(executed_1.PARCELAS_VAL_CUSTO_EMIS_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);
                _.Move(executed_1.PARCELAS_VAL_IOCC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);
                _.Move(executed_1.PARCELAS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-CORRIGE-IPCA-SECTION */
        private void R0700_00_CORRIGE_IPCA_SECTION()
        {
            /*" -1437- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1440- COMPUTE APOLICOB-IMP-SEGURADA-IX EQUAL APOLICOB-IMP-SEGURADA-IX * WS-IPCA-ACUM. */
            APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX * WS_WORK_AREAS.WS_IPCA_ACUM;

            /*" -1442- COMPUTE WHOST-PRM EQUAL APOLICOB-PRM-TARIFARIO-IX * WS-IPCA-ACUM. */
            WS_WORK_AREAS.WHOST_PRM.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * WS_WORK_AREAS.WS_IPCA_ACUM;

            /*" -1444- MOVE WHOST-PRM TO APOLICOB-PRM-TARIFARIO-IX. */
            _.Move(WS_WORK_AREAS.WHOST_PRM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);

            /*" -1447- COMPUTE APOLICOB-IMP-SEGURADA-VAR EQUAL APOLICOB-IMP-SEGURADA-VAR * WS-IPCA-ACUM. */
            APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR * WS_WORK_AREAS.WS_IPCA_ACUM;

            /*" -1449- COMPUTE WHOST-PRM EQUAL APOLICOB-PRM-TARIFARIO-VAR * WS-IPCA-ACUM. */
            WS_WORK_AREAS.WHOST_PRM.Value = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR * WS_WORK_AREAS.WS_IPCA_ACUM;

            /*" -1451- MOVE WHOST-PRM TO APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(WS_WORK_AREAS.WHOST_PRM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -1454- MOVE APOLICOB-PRM-TARIFARIO-VAR TO PARCELAS-PRM-TARIFARIO-IX PARCELAS-PRM-LIQUIDO-IX. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX);

            /*" -1459- MOVE ZEROS TO PARCELAS-VAL-DESCONTO-IX PARCELAS-ADICIONAL-FRAC-IX PARCELAS-VAL-CUSTO-EMIS-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX);

            /*" -1463- COMPUTE WS-VAL-IOCC-IX ROUNDED EQUAL PARCELAS-PRM-LIQUIDO-IX * RAMOCOMP-PCT-IOCC-RAMO / 100. */
            WS_WORK_AREAS.WS_VAL_IOCC_IX.Value = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX * RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f;

            /*" -1465- MOVE WS-VAL-IOCC-IX TO PARCELAS-VAL-IOCC-IX */
            _.Move(WS_WORK_AREAS.WS_VAL_IOCC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -1470- COMPUTE WS-PRM-TOTAL-IX EQUAL PARCELAS-PRM-LIQUIDO-IX + PARCELAS-ADICIONAL-FRAC-IX + PARCELAS-VAL-CUSTO-EMIS-IX + PARCELAS-VAL-IOCC-IX. */
            WS_WORK_AREAS.WS_PRM_TOTAL_IX.Value = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX + PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX + PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX + PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX;

            /*" -1472- MOVE WS-PRM-TOTAL-IX TO PARCELAS-PRM-TOTAL-IX */
            _.Move(WS_WORK_AREAS.WS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -1472- ADD 1 TO AC-IPCA. */
            WS_WORK_AREAS.AC_IPCA.Value = WS_WORK_AREAS.AC_IPCA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-EMITE-ENDOSSO-SECTION */
        private void R1000_00_EMITE_ENDOSSO_SECTION()
        {
            /*" -1488- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1494- PERFORM R1200-00-SELECT-FONTES. */

            R1200_00_SELECT_FONTES_SECTION();

            /*" -1496- MOVE MOVDEBCE-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -1498- MOVE FONTES-ULT-PROP-AUTOMAT TO ENDOSSOS-NUM-PROPOSTA. */
            _.Move(FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);

            /*" -1500- MOVE SISTEMA-DTMOVABE TO ENDOSSOS-DATA-EMISSAO. */
            _.Move(SISTEMA_DTMOVABE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);

            /*" -1505- MOVE ZEROS TO ENDOSSOS-NUM-RCAP ENDOSSOS-VAL-RCAP ENDOSSOS-BCO-RCAP ENDOSSOS-AGE-RCAP. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP);

            /*" -1508- MOVE '0' TO ENDOSSOS-DAC-RCAP ENDOSSOS-TIPO-RCAP. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP);

            /*" -1510- MOVE WSGER00-DATA-INIVIGENCIA TO ENDOSSOS-DATA-INIVIGENCIA. */
            _.Move(WSGER00_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);

            /*" -1512- MOVE WSGER00-DATA-TERVIGENCIA TO ENDOSSOS-DATA-TERVIGENCIA. */
            _.Move(WSGER00_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

            /*" -1514- MOVE 'BI0070B' TO ENDOSSOS-COD-USUARIO. */
            _.Move("BI0070B", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO);

            /*" -1516- MOVE '0' TO ENDOSSOS-SIT-REGISTRO. */
            _.Move("0", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);

            /*" -1518- MOVE SPACES TO ENDOSSOS-DATA-RCAP. */
            _.Move("", ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP);

            /*" -1520- MOVE MOVDEBCE-DATA-VENCIMENTO TO ENDOSSOS-DATA-VENCIMENTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO);

            /*" -1522- MOVE -1 TO VIND-DATA-RCAP. */
            _.Move(-1, VIND_DATA_RCAP);

            /*" -1526- MOVE ZEROS TO VIND-DTVENCTO. */
            _.Move(0, VIND_DTVENCTO);

            /*" -1532- PERFORM R1520-00-INSERT-ENDOSSOS. */

            R1520_00_INSERT_ENDOSSOS_SECTION();

            /*" -1534- MOVE ENDOSSOS-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -1536- MOVE ENDOSSOS-NUM-ENDOSSO TO PARCELAS-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

            /*" -1538- MOVE ZEROS TO PARCELAS-NUM-PARCELA. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -1540- MOVE '0' TO PARCELAS-DAC-PARCELA. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA);

            /*" -1542- MOVE ENDOSSOS-COD-FONTE TO PARCELAS-COD-FONTE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE);

            /*" -1544- MOVE ZEROS TO PARCELAS-NUM-TITULO. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO);

            /*" -1546- MOVE 1 TO PARCELAS-OCORR-HISTORICO. */
            _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO);

            /*" -1548- MOVE ZEROS TO PARCELAS-QTD-DOCUMENTOS. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);

            /*" -1550- MOVE '0' TO PARCELAS-SIT-REGISTRO. */
            _.Move("0", PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO);

            /*" -1552- MOVE ENDOSSOS-COD-EMPRESA TO PARCELAS-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA);

            /*" -1556- MOVE SPACES TO PARCELAS-SITUACAO-COBRANCA. */
            _.Move("", PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA);

            /*" -1557- MOVE ZEROS TO VIND-NULL01. */
            _.Move(0, VIND_NULL01);

            /*" -1559- MOVE -1 TO VIND-NULL02. */
            _.Move(-1, VIND_NULL02);

            /*" -1560- MOVE PARCELAS-VAL-IOCC-IX TO WS-VAL-IOCC-IX */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, WS_WORK_AREAS.WS_VAL_IOCC_IX);

            /*" -1562- MOVE PARCELAS-PRM-TOTAL-IX TO WS-PRM-TOTAL-IX */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, WS_WORK_AREAS.WS_PRM_TOTAL_IX);

            /*" -1563- MOVE WS-VAL-IOCC-IX TO PARCELAS-VAL-IOCC-IX */
            _.Move(WS_WORK_AREAS.WS_VAL_IOCC_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX);

            /*" -1565- MOVE WS-PRM-TOTAL-IX TO PARCELAS-PRM-TOTAL-IX */
            _.Move(WS_WORK_AREAS.WS_PRM_TOTAL_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX);

            /*" -1571- PERFORM R1530-00-INSERT-PARCELAS. */

            R1530_00_INSERT_PARCELAS_SECTION();

            /*" -1573- MOVE PARCELAS-NUM-APOLICE TO PARCEHIS-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);

            /*" -1575- MOVE PARCELAS-NUM-ENDOSSO TO PARCEHIS-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);

            /*" -1577- MOVE PARCELAS-NUM-PARCELA TO PARCEHIS-NUM-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);

            /*" -1579- MOVE PARCELAS-DAC-PARCELA TO PARCEHIS-DAC-PARCELA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA);

            /*" -1581- MOVE SISTEMA-DTMOVABE TO PARCEHIS-DATA-MOVIMENTO. */
            _.Move(SISTEMA_DTMOVABE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);

            /*" -1583- MOVE 101 TO PARCEHIS-COD-OPERACAO. */
            _.Move(101, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);

            /*" -1585- MOVE 1 TO PARCEHIS-OCORR-HISTORICO. */
            _.Move(1, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);

            /*" -1587- MOVE PARCELAS-PRM-TARIFARIO-IX TO PARCEHIS-PRM-TARIFARIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);

            /*" -1589- MOVE PARCELAS-VAL-DESCONTO-IX TO PARCEHIS-VAL-DESCONTO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);

            /*" -1591- MOVE PARCELAS-PRM-LIQUIDO-IX TO PARCEHIS-PRM-LIQUIDO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO);

            /*" -1593- MOVE PARCELAS-ADICIONAL-FRAC-IX TO PARCEHIS-ADICIONAL-FRACIO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);

            /*" -1595- MOVE PARCELAS-VAL-CUSTO-EMIS-IX TO PARCEHIS-VAL-CUSTO-EMISSAO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO);

            /*" -1597- MOVE PARCELAS-VAL-IOCC-IX TO PARCEHIS-VAL-IOCC. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC);

            /*" -1599- MOVE PARCELAS-PRM-TOTAL-IX TO PARCEHIS-PRM-TOTAL. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);

            /*" -1601- MOVE ZEROS TO PARCEHIS-VAL-OPERACAO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);

            /*" -1603- MOVE MOVDEBCE-DATA-VENCIMENTO TO PARCEHIS-DATA-VENCIMENTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);

            /*" -1605- MOVE ENDOSSOS-BCO-COBRANCA TO PARCEHIS-BCO-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA);

            /*" -1607- MOVE ENDOSSOS-AGE-COBRANCA TO PARCEHIS-AGE-COBRANCA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA);

            /*" -1609- MOVE ZEROS TO PARCEHIS-NUM-AVISO-CREDITO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO);

            /*" -1611- MOVE ZEROS TO PARCEHIS-ENDOS-CANCELA. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA);

            /*" -1613- MOVE '0' TO PARCEHIS-SIT-CONTABIL. */
            _.Move("0", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL);

            /*" -1615- MOVE ENDOSSOS-COD-USUARIO TO PARCEHIS-COD-USUARIO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO);

            /*" -1617- MOVE ZEROS TO PARCEHIS-RENUM-DOCUMENTO. */
            _.Move(0, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO);

            /*" -1619- MOVE SPACES TO PARCEHIS-DATA-QUITACAO. */
            _.Move("", PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);

            /*" -1622- MOVE PARCELAS-COD-EMPRESA TO PARCEHIS-COD-EMPRESA. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);

            /*" -1623- MOVE -1 TO VIND-NULL01. */
            _.Move(-1, VIND_NULL01);

            /*" -1626- MOVE ZEROS TO VIND-NULL02. */
            _.Move(0, VIND_NULL02);

            /*" -1632- PERFORM R1550-00-INSERT-PARCEHIS. */

            R1550_00_INSERT_PARCEHIS_SECTION();

            /*" -1634- MOVE PARCELAS-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -1636- MOVE PARCELAS-NUM-ENDOSSO TO APOLICOB-NUM-ENDOSSO. */
            _.Move(PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -1638- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOB-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -1640- MOVE ENDOSSOS-DATA-TERVIGENCIA TO APOLICOB-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);

            /*" -1642- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOB-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA);

            /*" -1645- MOVE '0' TO APOLICOB-SIT-REGISTRO. */
            _.Move("0", APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO);

            /*" -1649- MOVE ZEROS TO VIND-NULL01 VIND-NULL02. */
            _.Move(0, VIND_NULL01, VIND_NULL02);

            /*" -1652- PERFORM R1570-00-INSERT-APOLICOB. */

            R1570_00_INSERT_APOLICOB_SECTION();

            /*" -1655- PERFORM R1720-00-UPDATE-MOVDEBCE. */

            R1720_00_UPDATE_MOVDEBCE_SECTION();

            /*" -1655- PERFORM R1750-00-UPDATE-BILHETE. */

            R1750_00_UPDATE_BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-FONTES-SECTION */
        private void R1200_00_SELECT_FONTES_SECTION()
        {
            /*" -1668- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1676- PERFORM R1200_00_SELECT_FONTES_DB_SELECT_1 */

            R1200_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1680- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1681- DISPLAY 'R1200-00 - PROBLEMAS NO SELECT(FONTES)  ' */
                _.Display($"R1200-00 - PROBLEMAS NO SELECT(FONTES)  ");

                /*" -1682- DISPLAY ' FONTE        =  ' ENDOSSOS-COD-FONTE */
                _.Display($" FONTE        =  {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1685- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1689- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -1691- MOVE ZEROS TO AC-CONTROLE. */
            _.Move(0, WS_WORK_AREAS.AC_CONTROLE);

            /*" -1694- PERFORM R1210-00-SELECT-ENDOSSOS. */

            R1210_00_SELECT_ENDOSSOS_SECTION();

            /*" -1694- PERFORM R1250-00-UPDATE-FONTES. */

            R1250_00_UPDATE_FONTES_SECTION();

        }

        [StopWatch]
        /*" R1200-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1200_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1676- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :ENDOSSOS-COD-FONTE WITH UR END-EXEC. */

            var r1200_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R1200_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-ENDOSSOS-SECTION */
        private void R1210_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -1707- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1715- PERFORM R1210_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1210_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -1719- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1722- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1723- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1724- DISPLAY 'R1210-00 - PROBLEMAS NO SELECT(ENDOSSOS)' */
                _.Display($"R1210-00 - PROBLEMAS NO SELECT(ENDOSSOS)");

                /*" -1725- DISPLAY 'COD-FONTE        = ' ENDOSSOS-COD-FONTE */
                _.Display($"COD-FONTE        = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1726- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -1729- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1735- ADD 1 TO AC-CONTROLE. */
            WS_WORK_AREAS.AC_CONTROLE.Value = WS_WORK_AREAS.AC_CONTROLE + 1;

            /*" -1736- IF AC-CONTROLE GREATER 5000 */

            if (WS_WORK_AREAS.AC_CONTROLE > 5000)
            {

                /*" -1737- DISPLAY 'R1210-00 - PROPOSTA DUPLICIDADE ENDOSSOS' */
                _.Display($"R1210-00 - PROPOSTA DUPLICIDADE ENDOSSOS");

                /*" -1738- DISPLAY 'COD-FONTE        = ' ENDOSSOS-COD-FONTE */
                _.Display($"COD-FONTE        = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1739- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -1741- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1745- COMPUTE FONTES-ULT-PROP-AUTOMAT EQUAL (FONTES-ULT-PROP-AUTOMAT + 1). */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = (FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1);

            /*" -1745- GO TO R1210-00-SELECT-ENDOSSOS. */
            new Task(() => R1210_00_SELECT_ENDOSSOS_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1210-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1210_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -1715- EXEC SQL SELECT NUM_PROPOSTA INTO :ENDOSSOS-NUM-PROPOSTA FROM SEGUROS.ENDOSSOS WHERE COD_FONTE = :ENDOSSOS-COD-FONTE AND NUM_PROPOSTA = :FONTES-ULT-PROP-AUTOMAT WITH UR END-EXEC. */

            var r1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            var executed_1 = R1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-UPDATE-FONTES-SECTION */
        private void R1250_00_UPDATE_FONTES_SECTION()
        {
            /*" -1758- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1764- PERFORM R1250_00_UPDATE_FONTES_DB_UPDATE_1 */

            R1250_00_UPDATE_FONTES_DB_UPDATE_1();

            /*" -1767- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1768- DISPLAY 'R1250-00 - PROBLEMAS UPDATE (FONTES)      ' */
                _.Display($"R1250-00 - PROBLEMAS UPDATE (FONTES)      ");

                /*" -1769- DISPLAY 'COD-FONTE        = ' ENDOSSOS-COD-FONTE */
                _.Display($"COD-FONTE        = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1770- DISPLAY 'NUM_PROPOSTA     = ' FONTES-ULT-PROP-AUTOMAT */
                _.Display($"NUM_PROPOSTA     = {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}");

                /*" -1770- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1250-00-UPDATE-FONTES-DB-UPDATE-1 */
        public void R1250_00_UPDATE_FONTES_DB_UPDATE_1()
        {
            /*" -1764- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT WHERE COD_FONTE = :ENDOSSOS-COD-FONTE END-EXEC. */

            var r1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1 = new R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
            };

            R1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1.Execute(r1250_00_UPDATE_FONTES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1520-00-INSERT-ENDOSSOS-SECTION */
        private void R1520_00_INSERT_ENDOSSOS_SECTION()
        {
            /*" -1783- MOVE '1520' TO WNR-EXEC-SQL. */
            _.Move("1520", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1874- PERFORM R1520_00_INSERT_ENDOSSOS_DB_INSERT_1 */

            R1520_00_INSERT_ENDOSSOS_DB_INSERT_1();

            /*" -1878- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1879- DISPLAY 'R1520-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ' */
                _.Display($"R1520-00 - PROBLEMAS NO INSERT(ENDOSSOS)   ");

                /*" -1880- DISPLAY ' APOLICE    = ' ENDOSSOS-NUM-APOLICE */
                _.Display($" APOLICE    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                /*" -1881- DISPLAY ' ENDOSSO    = ' ENDOSSOS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                /*" -1884- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1884- ADD 1 TO AC-ENDOSSOS. */
            WS_WORK_AREAS.AC_ENDOSSOS.Value = WS_WORK_AREAS.AC_ENDOSSOS + 1;

        }

        [StopWatch]
        /*" R1520-00-INSERT-ENDOSSOS-DB-INSERT-1 */
        public void R1520_00_INSERT_ENDOSSOS_DB_INSERT_1()
        {
            /*" -1874- EXEC SQL INSERT INTO SEGUROS.ENDOSSOS (NUM_APOLICE ,NUM_ENDOSSO ,RAMO_EMISSOR ,COD_PRODUTO ,COD_SUBGRUPO ,COD_FONTE ,NUM_PROPOSTA ,DATA_PROPOSTA ,DATA_LIBERACAO ,DATA_EMISSAO ,NUM_RCAP ,VAL_RCAP ,BCO_RCAP ,AGE_RCAP ,DAC_RCAP ,TIPO_RCAP ,BCO_COBRANCA ,AGE_COBRANCA ,DAC_COBRANCA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,PLANO_SEGURO ,PCT_ENTRADA ,PCT_ADIC_FRACIO ,QTD_DIAS_PRIMEIRA ,QTD_PARCELAS ,QTD_PRESTACOES ,QTD_ITENS ,COD_TEXTO_PADRAO ,COD_ACEITACAO ,COD_MOEDA_IMP ,COD_MOEDA_PRM ,TIPO_ENDOSSO ,COD_USUARIO ,OCORR_ENDERECO ,SIT_REGISTRO ,DATA_RCAP ,COD_EMPRESA ,TIPO_CORRECAO ,ISENTA_CUSTO ,TIMESTAMP ,DATA_VENCIMENTO ,COEF_PREFIX ,VAL_CUSTO_EMISSAO) VALUES (:ENDOSSOS-NUM-APOLICE ,:ENDOSSOS-NUM-ENDOSSO ,:ENDOSSOS-RAMO-EMISSOR ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-COD-SUBGRUPO ,:ENDOSSOS-COD-FONTE ,:ENDOSSOS-NUM-PROPOSTA ,:ENDOSSOS-DATA-PROPOSTA ,:ENDOSSOS-DATA-LIBERACAO ,:ENDOSSOS-DATA-EMISSAO ,:ENDOSSOS-NUM-RCAP ,:ENDOSSOS-VAL-RCAP ,:ENDOSSOS-BCO-RCAP ,:ENDOSSOS-AGE-RCAP ,:ENDOSSOS-DAC-RCAP ,:ENDOSSOS-TIPO-RCAP ,:ENDOSSOS-BCO-COBRANCA ,:ENDOSSOS-AGE-COBRANCA ,:ENDOSSOS-DAC-COBRANCA ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:ENDOSSOS-PLANO-SEGURO ,:ENDOSSOS-PCT-ENTRADA ,:ENDOSSOS-PCT-ADIC-FRACIO ,:ENDOSSOS-QTD-DIAS-PRIMEIRA ,:ENDOSSOS-QTD-PARCELAS ,:ENDOSSOS-QTD-PRESTACOES ,:ENDOSSOS-QTD-ITENS ,:ENDOSSOS-COD-TEXTO-PADRAO ,:ENDOSSOS-COD-ACEITACAO ,:ENDOSSOS-COD-MOEDA-IMP ,:ENDOSSOS-COD-MOEDA-PRM ,:ENDOSSOS-TIPO-ENDOSSO ,:ENDOSSOS-COD-USUARIO ,:ENDOSSOS-OCORR-ENDERECO ,:ENDOSSOS-SIT-REGISTRO ,:ENDOSSOS-DATA-RCAP:VIND-DATA-RCAP ,:ENDOSSOS-COD-EMPRESA:VIND-COD-EMPRESA ,:ENDOSSOS-TIPO-CORRECAO:VIND-TIPO-CORRECAO ,:ENDOSSOS-ISENTA-CUSTO:VIND-ISENTA-CUSTO , CURRENT TIMESTAMP ,:ENDOSSOS-DATA-VENCIMENTO:VIND-DTVENCTO ,:ENDOSSOS-COEF-PREFIX:VIND-COEF-PREFIX ,:ENDOSSOS-VAL-CUSTO-EMISSAO:VIND-VAL-CUSTO) END-EXEC. */

            var r1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1 = new R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                ENDOSSOS_RAMO_EMISSOR = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR.ToString(),
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
                ENDOSSOS_COD_SUBGRUPO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO.ToString(),
                ENDOSSOS_COD_FONTE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE.ToString(),
                ENDOSSOS_NUM_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA.ToString(),
                ENDOSSOS_DATA_PROPOSTA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA.ToString(),
                ENDOSSOS_DATA_LIBERACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_LIBERACAO.ToString(),
                ENDOSSOS_DATA_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO.ToString(),
                ENDOSSOS_NUM_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP.ToString(),
                ENDOSSOS_VAL_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP.ToString(),
                ENDOSSOS_BCO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_RCAP.ToString(),
                ENDOSSOS_AGE_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_RCAP.ToString(),
                ENDOSSOS_DAC_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_RCAP.ToString(),
                ENDOSSOS_TIPO_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_RCAP.ToString(),
                ENDOSSOS_BCO_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_BCO_COBRANCA.ToString(),
                ENDOSSOS_AGE_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA.ToString(),
                ENDOSSOS_DAC_COBRANCA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DAC_COBRANCA.ToString(),
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
                ENDOSSOS_PLANO_SEGURO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PLANO_SEGURO.ToString(),
                ENDOSSOS_PCT_ENTRADA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ENTRADA.ToString(),
                ENDOSSOS_PCT_ADIC_FRACIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_PCT_ADIC_FRACIO.ToString(),
                ENDOSSOS_QTD_DIAS_PRIMEIRA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_DIAS_PRIMEIRA.ToString(),
                ENDOSSOS_QTD_PARCELAS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS.ToString(),
                ENDOSSOS_QTD_PRESTACOES = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PRESTACOES.ToString(),
                ENDOSSOS_QTD_ITENS = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_ITENS.ToString(),
                ENDOSSOS_COD_TEXTO_PADRAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_TEXTO_PADRAO.ToString(),
                ENDOSSOS_COD_ACEITACAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_ACEITACAO.ToString(),
                ENDOSSOS_COD_MOEDA_IMP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP.ToString(),
                ENDOSSOS_COD_MOEDA_PRM = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM.ToString(),
                ENDOSSOS_TIPO_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_ENDOSSO.ToString(),
                ENDOSSOS_COD_USUARIO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_USUARIO.ToString(),
                ENDOSSOS_OCORR_ENDERECO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO.ToString(),
                ENDOSSOS_SIT_REGISTRO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO.ToString(),
                ENDOSSOS_DATA_RCAP = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_RCAP.ToString(),
                VIND_DATA_RCAP = VIND_DATA_RCAP.ToString(),
                ENDOSSOS_COD_EMPRESA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA.ToString(),
                VIND_COD_EMPRESA = VIND_COD_EMPRESA.ToString(),
                ENDOSSOS_TIPO_CORRECAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_TIPO_CORRECAO.ToString(),
                VIND_TIPO_CORRECAO = VIND_TIPO_CORRECAO.ToString(),
                ENDOSSOS_ISENTA_CUSTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_ISENTA_CUSTO.ToString(),
                VIND_ISENTA_CUSTO = VIND_ISENTA_CUSTO.ToString(),
                ENDOSSOS_DATA_VENCIMENTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_VENCIMENTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                ENDOSSOS_COEF_PREFIX = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COEF_PREFIX.ToString(),
                VIND_COEF_PREFIX = VIND_COEF_PREFIX.ToString(),
                ENDOSSOS_VAL_CUSTO_EMISSAO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_CUSTO_EMISSAO.ToString(),
                VIND_VAL_CUSTO = VIND_VAL_CUSTO.ToString(),
            };

            R1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1.Execute(r1520_00_INSERT_ENDOSSOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1520_99_SAIDA*/

        [StopWatch]
        /*" R1530-00-INSERT-PARCELAS-SECTION */
        private void R1530_00_INSERT_PARCELAS_SECTION()
        {
            /*" -1897- MOVE '1530' TO WNR-EXEC-SQL. */
            _.Move("1530", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -1938- PERFORM R1530_00_INSERT_PARCELAS_DB_INSERT_1 */

            R1530_00_INSERT_PARCELAS_DB_INSERT_1();

            /*" -1942- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1943- DISPLAY 'R1530-00 - PROBLEMAS NO INSERT(PARCELAS)   ' */
                _.Display($"R1530-00 - PROBLEMAS NO INSERT(PARCELAS)   ");

                /*" -1944- DISPLAY ' APOLICE    = ' PARCELAS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -1945- DISPLAY ' ENDOSSO    = ' PARCELAS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}");

                /*" -1945- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1530-00-INSERT-PARCELAS-DB-INSERT-1 */
        public void R1530_00_INSERT_PARCELAS_DB_INSERT_1()
        {
            /*" -1938- EXEC SQL INSERT INTO SEGUROS.PARCELAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,COD_FONTE ,NUM_TITULO ,PRM_TARIFARIO_IX ,VAL_DESCONTO_IX ,PRM_LIQUIDO_IX ,ADICIONAL_FRAC_IX ,VAL_CUSTO_EMIS_IX ,VAL_IOCC_IX ,PRM_TOTAL_IX ,OCORR_HISTORICO ,QTD_DOCUMENTOS ,SIT_REGISTRO ,COD_EMPRESA ,TIMESTAMP ,SITUACAO_COBRANCA) VALUES (:PARCELAS-NUM-APOLICE ,:PARCELAS-NUM-ENDOSSO ,:PARCELAS-NUM-PARCELA ,:PARCELAS-DAC-PARCELA ,:PARCELAS-COD-FONTE ,:PARCELAS-NUM-TITULO ,:PARCELAS-PRM-TARIFARIO-IX ,:PARCELAS-VAL-DESCONTO-IX ,:PARCELAS-PRM-LIQUIDO-IX ,:PARCELAS-ADICIONAL-FRAC-IX ,:PARCELAS-VAL-CUSTO-EMIS-IX ,:PARCELAS-VAL-IOCC-IX ,:PARCELAS-PRM-TOTAL-IX ,:PARCELAS-OCORR-HISTORICO ,:PARCELAS-QTD-DOCUMENTOS ,:PARCELAS-SIT-REGISTRO ,:PARCELAS-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP ,:PARCELAS-SITUACAO-COBRANCA:VIND-NULL02) END-EXEC. */

            var r1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1 = new R1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_ENDOSSO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
                PARCELAS_DAC_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_DAC_PARCELA.ToString(),
                PARCELAS_COD_FONTE = PARCELAS.DCLPARCELAS.PARCELAS_COD_FONTE.ToString(),
                PARCELAS_NUM_TITULO = PARCELAS.DCLPARCELAS.PARCELAS_NUM_TITULO.ToString(),
                PARCELAS_PRM_TARIFARIO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX.ToString(),
                PARCELAS_VAL_DESCONTO_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX.ToString(),
                PARCELAS_PRM_LIQUIDO_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_LIQUIDO_IX.ToString(),
                PARCELAS_ADICIONAL_FRAC_IX = PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX.ToString(),
                PARCELAS_VAL_CUSTO_EMIS_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_CUSTO_EMIS_IX.ToString(),
                PARCELAS_VAL_IOCC_IX = PARCELAS.DCLPARCELAS.PARCELAS_VAL_IOCC_IX.ToString(),
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                PARCELAS_OCORR_HISTORICO = PARCELAS.DCLPARCELAS.PARCELAS_OCORR_HISTORICO.ToString(),
                PARCELAS_QTD_DOCUMENTOS = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.ToString(),
                PARCELAS_SIT_REGISTRO = PARCELAS.DCLPARCELAS.PARCELAS_SIT_REGISTRO.ToString(),
                PARCELAS_COD_EMPRESA = PARCELAS.DCLPARCELAS.PARCELAS_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                PARCELAS_SITUACAO_COBRANCA = PARCELAS.DCLPARCELAS.PARCELAS_SITUACAO_COBRANCA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1.Execute(r1530_00_INSERT_PARCELAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1530_99_SAIDA*/

        [StopWatch]
        /*" R1550-00-INSERT-PARCEHIS-SECTION */
        private void R1550_00_INSERT_PARCEHIS_SECTION()
        {
            /*" -1958- MOVE '1550' TO WNR-EXEC-SQL. */
            _.Move("1550", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2015- PERFORM R1550_00_INSERT_PARCEHIS_DB_INSERT_1 */

            R1550_00_INSERT_PARCEHIS_DB_INSERT_1();

            /*" -2019- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2020- DISPLAY 'R1550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ' */
                _.Display($"R1550-00 - PROBLEMAS NO INSERT(PARCEHIS)   ");

                /*" -2021- DISPLAY ' APOLICE    = ' PARCEHIS-NUM-APOLICE */
                _.Display($" APOLICE    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -2022- DISPLAY ' ENDOSSO    = ' PARCEHIS-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -2022- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1550-00-INSERT-PARCEHIS-DB-INSERT-1 */
        public void R1550_00_INSERT_PARCEHIS_DB_INSERT_1()
        {
            /*" -2015- EXEC SQL INSERT INTO SEGUROS.PARCELA_HISTORICO (NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DAC_PARCELA ,DATA_MOVIMENTO ,COD_OPERACAO ,HORA_OPERACAO ,OCORR_HISTORICO ,PRM_TARIFARIO ,VAL_DESCONTO ,PRM_LIQUIDO ,ADICIONAL_FRACIO ,VAL_CUSTO_EMISSAO ,VAL_IOCC ,PRM_TOTAL ,VAL_OPERACAO ,DATA_VENCIMENTO ,BCO_COBRANCA ,AGE_COBRANCA ,NUM_AVISO_CREDITO ,ENDOS_CANCELA ,SIT_CONTABIL ,COD_USUARIO ,RENUM_DOCUMENTO ,DATA_QUITACAO ,COD_EMPRESA ,TIMESTAMP) VALUES (:PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DAC-PARCELA ,:PARCEHIS-DATA-MOVIMENTO ,:PARCEHIS-COD-OPERACAO , CURRENT TIME ,:PARCEHIS-OCORR-HISTORICO ,:PARCEHIS-PRM-TARIFARIO ,:PARCEHIS-VAL-DESCONTO ,:PARCEHIS-PRM-LIQUIDO ,:PARCEHIS-ADICIONAL-FRACIO ,:PARCEHIS-VAL-CUSTO-EMISSAO ,:PARCEHIS-VAL-IOCC ,:PARCEHIS-PRM-TOTAL ,:PARCEHIS-VAL-OPERACAO ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-BCO-COBRANCA ,:PARCEHIS-AGE-COBRANCA ,:PARCEHIS-NUM-AVISO-CREDITO ,:PARCEHIS-ENDOS-CANCELA ,:PARCEHIS-SIT-CONTABIL ,:PARCEHIS-COD-USUARIO ,:PARCEHIS-RENUM-DOCUMENTO ,:PARCEHIS-DATA-QUITACAO:VIND-NULL01 ,:PARCEHIS-COD-EMPRESA:VIND-NULL02 , CURRENT TIMESTAMP) END-EXEC. */

            var r1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1 = new R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                PARCEHIS_DAC_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DAC_PARCELA.ToString(),
                PARCEHIS_DATA_MOVIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO.ToString(),
                PARCEHIS_COD_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO.ToString(),
                PARCEHIS_OCORR_HISTORICO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO.ToString(),
                PARCEHIS_PRM_TARIFARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO.ToString(),
                PARCEHIS_VAL_DESCONTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO.ToString(),
                PARCEHIS_PRM_LIQUIDO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_LIQUIDO.ToString(),
                PARCEHIS_ADICIONAL_FRACIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO.ToString(),
                PARCEHIS_VAL_CUSTO_EMISSAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_CUSTO_EMISSAO.ToString(),
                PARCEHIS_VAL_IOCC = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_IOCC.ToString(),
                PARCEHIS_PRM_TOTAL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL.ToString(),
                PARCEHIS_VAL_OPERACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO.ToString(),
                PARCEHIS_DATA_VENCIMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO.ToString(),
                PARCEHIS_BCO_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_BCO_COBRANCA.ToString(),
                PARCEHIS_AGE_COBRANCA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_AGE_COBRANCA.ToString(),
                PARCEHIS_NUM_AVISO_CREDITO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_AVISO_CREDITO.ToString(),
                PARCEHIS_ENDOS_CANCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ENDOS_CANCELA.ToString(),
                PARCEHIS_SIT_CONTABIL = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_SIT_CONTABIL.ToString(),
                PARCEHIS_COD_USUARIO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_USUARIO.ToString(),
                PARCEHIS_RENUM_DOCUMENTO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_RENUM_DOCUMENTO.ToString(),
                PARCEHIS_DATA_QUITACAO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                PARCEHIS_COD_EMPRESA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1.Execute(r1550_00_INSERT_PARCEHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1550_99_SAIDA*/

        [StopWatch]
        /*" R1570-00-INSERT-APOLICOB-SECTION */
        private void R1570_00_INSERT_APOLICOB_SECTION()
        {
            /*" -2035- MOVE '1570' TO WNR-EXEC-SQL. */
            _.Move("1570", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2074- PERFORM R1570_00_INSERT_APOLICOB_DB_INSERT_1 */

            R1570_00_INSERT_APOLICOB_DB_INSERT_1();

            /*" -2078- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2079- DISPLAY 'R1570-00 - PROBLEMAS NO INSERT(APOLICOB)   ' */
                _.Display($"R1570-00 - PROBLEMAS NO INSERT(APOLICOB)   ");

                /*" -2080- DISPLAY ' APOLICE    = ' APOLICOB-NUM-APOLICE */
                _.Display($" APOLICE    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -2081- DISPLAY ' ENDOSSO    = ' APOLICOB-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -2081- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1570-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R1570_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -2074- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE ,NUM_ENDOSSO ,NUM_ITEM ,OCORR_HISTORICO ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_COBERTURA ,IMP_SEGURADA_IX ,PRM_TARIFARIO_IX ,IMP_SEGURADA_VAR ,PRM_TARIFARIO_VAR ,PCT_COBERTURA ,FATOR_MULTIPLICA ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,COD_EMPRESA ,TIMESTAMP ,SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ENDOSSO ,:APOLICOB-NUM-ITEM ,:APOLICOB-OCORR-HISTORICO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-IMP-SEGURADA-VAR ,:APOLICOB-PRM-TARIFARIO-VAR ,:APOLICOB-PCT-COBERTURA ,:APOLICOB-FATOR-MULTIPLICA ,:APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA ,:APOLICOB-COD-EMPRESA:VIND-NULL01 , CURRENT TIMESTAMP ,:APOLICOB-SIT-REGISTRO:VIND-NULL02) END-EXEC. */

            var r1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_DATA_TERVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA.ToString(),
                APOLICOB_COD_EMPRESA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_EMPRESA.ToString(),
                VIND_NULL01 = VIND_NULL01.ToString(),
                APOLICOB_SIT_REGISTRO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_SIT_REGISTRO.ToString(),
                VIND_NULL02 = VIND_NULL02.ToString(),
            };

            R1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r1570_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1570_99_SAIDA*/

        [StopWatch]
        /*" R1720-00-UPDATE-MOVDEBCE-SECTION */
        private void R1720_00_UPDATE_MOVDEBCE_SECTION()
        {
            /*" -2094- MOVE '1720' TO WNR-EXEC-SQL. */
            _.Move("1720", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2095- IF APOLCOBR-COD-AGENCIA EQUAL 104 */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA == 104)
            {

                /*" -2099- MOVE 6114 TO MOVDEBCE-COD-CONVENIO. */
                _.Move(6114, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
            }


            /*" -2110- PERFORM R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1 */

            R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1();

            /*" -2115- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2116- DISPLAY 'R1720-00 - PROBLEMAS UPDATE (MOVDEBCE) ' */
                _.Display($"R1720-00 - PROBLEMAS UPDATE (MOVDEBCE) ");

                /*" -2116- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1720-00-UPDATE-MOVDEBCE-DB-UPDATE-1 */
        public void R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1()
        {
            /*" -2110- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = '0' ,VALOR_DEBITO = :PARCELAS-PRM-TOTAL-IX ,COD_CONVENIO = :MOVDEBCE-COD-CONVENIO WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND SITUACAO_COBRANCA = '6' AND COD_CONVENIO = 102837 END-EXEC. */

            var r1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1 = new R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1()
            {
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1.Execute(r1720_00_UPDATE_MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1720_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-UPDATE-BILHETE-SECTION */
        private void R1750_00_UPDATE_BILHETE_SECTION()
        {
            /*" -2129- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2134- PERFORM R1750_00_UPDATE_BILHETE_DB_UPDATE_1 */

            R1750_00_UPDATE_BILHETE_DB_UPDATE_1();

            /*" -2139- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2140- DISPLAY 'R1750-00 - PROBLEMAS UPDATE (BILHETE) ' */
                _.Display($"R1750-00 - PROBLEMAS UPDATE (BILHETE) ");

                /*" -2140- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1750-00-UPDATE-BILHETE-DB-UPDATE-1 */
        public void R1750_00_UPDATE_BILHETE_DB_UPDATE_1()
        {
            /*" -2134- EXEC SQL UPDATE SEGUROS.BILHETE SET VAL_RCAP = :PARCELAS-PRM-TOTAL-IX WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE END-EXEC. */

            var r1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1 = new R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1()
            {
                PARCELAS_PRM_TOTAL_IX = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TOTAL_IX.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            R1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1.Execute(r1750_00_UPDATE_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-MONTA-CORRETAGEM-SECTION */
        private void R2000_00_MONTA_CORRETAGEM_SECTION()
        {
            /*" -2153- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2155- MOVE MOVDEBCE-NUM-APOLICE TO APOLICOR-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -2157- MOVE APOLICOB-RAMO-COBERTURA TO APOLICOR-RAMO-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -2159- MOVE APOLICOB-MODALI-COBERTURA TO APOLICOR-MODALI-COBERTURA. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA);

            /*" -2161- MOVE ENDOSSOS-COD-SUBGRUPO TO APOLICOR-COD-SUBGRUPO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO);

            /*" -2163- MOVE ENDOSSOS-DATA-INIVIGENCIA TO APOLICOR-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA);

            /*" -2165- MOVE WSGER00-DATA-CORRETOR TO APOLICOR-DATA-TERVIGENCIA. */
            _.Move(WSGER00_DATA_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA);

            /*" -2167- MOVE 100 TO APOLICOR-PCT-PART-CORRETOR. */
            _.Move(100, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);

            /*" -2169- MOVE '2' TO APOLICOR-TIPO-COMISSAO. */
            _.Move("2", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO);

            /*" -2171- MOVE '1' TO APOLICOR-IND-CORRETOR-PRIN. */
            _.Move("1", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN);

            /*" -2173- MOVE ENDOSSOS-COD-EMPRESA TO APOLICOR-COD-EMPRESA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_EMPRESA, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_EMPRESA);

            /*" -2175- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -2178- MOVE 'BI0070B' TO APOLICOR-COD-USUARIO. */
            _.Move("BI0070B", APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO);

            /*" -2187- PERFORM R2010-00-SELECT-V0RELATORIOS. */

            R2010_00_SELECT_V0RELATORIOS_SECTION();

            /*" -2188- IF RELATORI-NUM-CERTIFICADO NOT EQUAL ZEROS */

            if (RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO != 00)
            {

                /*" -2190- MOVE 25160 TO APOLICOR-COD-CORRETOR */
                _.Move(25160, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

                /*" -2192- MOVE 40 TO APOLICOR-PCT-COM-CORRETOR */
                _.Move(40, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

                /*" -2199- ELSE */
            }
            else
            {


                /*" -2200- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1019 */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1019)
                {

                    /*" -2202- MOVE 25151 TO APOLICOR-COD-CORRETOR */
                    _.Move(25151, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

                    /*" -2204- MOVE 40 TO APOLICOR-PCT-COM-CORRETOR */
                    _.Move(40, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

                    /*" -2211- ELSE */
                }
                else
                {


                    /*" -2212- IF PROPOFID-ORIGEM-PROPOSTA EQUAL 1020 */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1020)
                    {

                        /*" -2214- MOVE 25160 TO APOLICOR-COD-CORRETOR */
                        _.Move(25160, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

                        /*" -2216- MOVE 40 TO APOLICOR-PCT-COM-CORRETOR */
                        _.Move(40, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

                        /*" -2223- ELSE */
                    }
                    else
                    {


                        /*" -2233- IF ENDOSSOS-COD-PRODUTO EQUAL 8114 OR 8115 OR 8116 OR 8117 OR 8118 OR JVPRD8114 OR JVPRD8115 OR JVPRD8116 OR JVPRD8117 OR JVPRD8118 */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8114", "8115", "8116", "8117", "8118", JVBKINCL.JV_PRODUTOS.JVPRD8114.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8115.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8116.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8117.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8118.ToString()))
                        {

                            /*" -2235- MOVE 24937 TO APOLICOR-COD-CORRETOR */
                            _.Move(24937, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

                            /*" -2237- MOVE 30 TO APOLICOR-PCT-COM-CORRETOR */
                            _.Move(30, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

                            /*" -2244- ELSE */
                        }
                        else
                        {


                            /*" -2254- IF ENDOSSOS-COD-PRODUTO EQUAL 8119 OR 8120 OR 8121 OR 8122 OR 8123 OR JVPRD8119 OR JVPRD8120 OR JVPRD8121 OR JVPRD8122 OR JVPRD8123 */

                            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8119", "8120", "8121", "8122", "8123", JVBKINCL.JV_PRODUTOS.JVPRD8119.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8120.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8121.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8122.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8123.ToString()))
                            {

                                /*" -2256- MOVE 24945 TO APOLICOR-COD-CORRETOR */
                                _.Move(24945, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);

                                /*" -2258- MOVE 40 TO APOLICOR-PCT-COM-CORRETOR */
                                _.Move(40, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

                                /*" -2260- MOVE 30 TO APOLICOR-PCT-COM-CORRETOR */
                                _.Move(30, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

                                /*" -2261- ELSE */
                            }
                            else
                            {


                                /*" -2263- GO TO R2000-99-SAIDA. */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -2263- PERFORM R2100-00-INSERT-APOLICOR. */

            R2100_00_INSERT_APOLICOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-SELECT-V0RELATORIOS-SECTION */
        private void R2010_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -2275- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2278- MOVE BILHETE-NUM-BILHETE TO RELATORI-NUM-TITULO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -2286- PERFORM R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -2289- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2291- MOVE ZEROS TO RELATORI-NUM-CERTIFICADO */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

                /*" -2292- ELSE */
            }
            else
            {


                /*" -2293- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2294- DISPLAY 'R2010-00 - PROBLEMAS NO SELECT(V0RELATORIOS)' */
                    _.Display($"R2010-00 - PROBLEMAS NO SELECT(V0RELATORIOS)");

                    /*" -2294- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2010-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -2286- EXEC SQL SELECT NUM_CERTIFICADO INTO :RELATORI-NUM-CERTIFICADO FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'CO' AND COD_RELATORIO = 'CO5021B1' AND NUM_TITULO = :RELATORI-NUM-TITULO WITH UR END-EXEC. */

            var r2010_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
            };

            var executed_1 = R2010_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r2010_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-INSERT-APOLICOR-SECTION */
        private void R2100_00_INSERT_APOLICOR_SECTION()
        {
            /*" -2307- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2338- PERFORM R2100_00_INSERT_APOLICOR_DB_INSERT_1 */

            R2100_00_INSERT_APOLICOR_DB_INSERT_1();

            /*" -2342- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2343- DISPLAY 'R2100-00 - PROBLEMAS NO INSERT(APOLICOR)   ' */
                _.Display($"R2100-00 - PROBLEMAS NO INSERT(APOLICOR)   ");

                /*" -2344- DISPLAY ' APOLICE    = ' APOLICOR-NUM-APOLICE */
                _.Display($" APOLICE    = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}");

                /*" -2345- DISPLAY ' MODALI     = ' APOLICOR-MODALI-COBERTURA */
                _.Display($" MODALI     = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA}");

                /*" -2346- DISPLAY ' CORRETOR   = ' APOLICOR-COD-CORRETOR */
                _.Display($" CORRETOR   = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR}");

                /*" -2347- DISPLAY ' SUBGRUPO   = ' APOLICOR-COD-SUBGRUPO */
                _.Display($" SUBGRUPO   = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO}");

                /*" -2348- DISPLAY ' DTINIVIG   = ' APOLICOR-DATA-INIVIGENCIA */
                _.Display($" DTINIVIG   = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA}");

                /*" -2349- DISPLAY ' DTTERVIG   = ' APOLICOR-DATA-TERVIGENCIA */
                _.Display($" DTTERVIG   = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA}");

                /*" -2350- DISPLAY ' PAR CORRE  = ' APOLICOR-PCT-PART-CORRETOR */
                _.Display($" PAR CORRE  = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR}");

                /*" -2351- DISPLAY ' COM CORRE  = ' APOLICOR-PCT-COM-CORRETOR */
                _.Display($" COM CORRE  = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR}");

                /*" -2352- DISPLAY ' TIPO       = ' APOLICOR-TIPO-COMISSAO */
                _.Display($" TIPO       = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO}");

                /*" -2353- DISPLAY ' IND-PRIN   = ' APOLICOR-IND-CORRETOR-PRIN */
                _.Display($" IND-PRIN   = {APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN}");

                /*" -2354- DISPLAY ' BILHETE    = ' BILHETE-NUM-BILHETE */
                _.Display($" BILHETE    = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2355- DISPLAY ' PRODUTO    = ' ENDOSSOS-COD-PRODUTO */
                _.Display($" PRODUTO    = {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO}");

                /*" -2356- DISPLAY ' ORIGEM     = ' PROPOFID-ORIGEM-PROPOSTA */
                _.Display($" ORIGEM     = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA}");

                /*" -2359- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2359- ADD 1 TO AC-APOLICOR. */
            WS_WORK_AREAS.AC_APOLICOR.Value = WS_WORK_AREAS.AC_APOLICOR + 1;

        }

        [StopWatch]
        /*" R2100-00-INSERT-APOLICOR-DB-INSERT-1 */
        public void R2100_00_INSERT_APOLICOR_DB_INSERT_1()
        {
            /*" -2338- EXEC SQL INSERT INTO SEGUROS.APOLICE_CORRETOR (NUM_APOLICE ,RAMO_COBERTURA ,MODALI_COBERTURA ,COD_CORRETOR ,COD_SUBGRUPO ,DATA_INIVIGENCIA ,DATA_TERVIGENCIA ,PCT_PART_CORRETOR ,PCT_COM_CORRETOR ,TIPO_COMISSAO ,IND_CORRETOR_PRIN ,COD_EMPRESA ,TIMESTAMP ,COD_USUARIO) VALUES (:APOLICOR-NUM-APOLICE ,:APOLICOR-RAMO-COBERTURA ,:APOLICOR-MODALI-COBERTURA ,:APOLICOR-COD-CORRETOR ,:APOLICOR-COD-SUBGRUPO ,:APOLICOR-DATA-INIVIGENCIA ,:APOLICOR-DATA-TERVIGENCIA ,:APOLICOR-PCT-PART-CORRETOR ,:APOLICOR-PCT-COM-CORRETOR ,:APOLICOR-TIPO-COMISSAO ,:APOLICOR-IND-CORRETOR-PRIN ,:APOLICOR-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP ,:APOLICOR-COD-USUARIO) END-EXEC. */

            var r2100_00_INSERT_APOLICOR_DB_INSERT_1_Insert1 = new R2100_00_INSERT_APOLICOR_DB_INSERT_1_Insert1()
            {
                APOLICOR_NUM_APOLICE = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE.ToString(),
                APOLICOR_RAMO_COBERTURA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA.ToString(),
                APOLICOR_MODALI_COBERTURA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_MODALI_COBERTURA.ToString(),
                APOLICOR_COD_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR.ToString(),
                APOLICOR_COD_SUBGRUPO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_SUBGRUPO.ToString(),
                APOLICOR_DATA_INIVIGENCIA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_INIVIGENCIA.ToString(),
                APOLICOR_DATA_TERVIGENCIA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_DATA_TERVIGENCIA.ToString(),
                APOLICOR_PCT_PART_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR.ToString(),
                APOLICOR_PCT_COM_CORRETOR = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR.ToString(),
                APOLICOR_TIPO_COMISSAO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_TIPO_COMISSAO.ToString(),
                APOLICOR_IND_CORRETOR_PRIN = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_IND_CORRETOR_PRIN.ToString(),
                APOLICOR_COD_EMPRESA = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                APOLICOR_COD_USUARIO = APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_USUARIO.ToString(),
            };

            R2100_00_INSERT_APOLICOR_DB_INSERT_1_Insert1.Execute(r2100_00_INSERT_APOLICOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROXIMA-PARCELA-SECTION */
        private void R3000_00_PROXIMA_PARCELA_SECTION()
        {
            /*" -2372- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2375- ADD 1 TO MOVDEBCE-NUM-ENDOSSO. */
            MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.Value = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO + 1;

            /*" -2376- IF MOVDEBCE-NUM-ENDOSSO GREATER 60 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO > 60)
            {

                /*" -2379- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2381- MOVE PARCEHIS-COD-EMPRESA TO MOVDEBCE-COD-EMPRESA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -2383- MOVE PARCEHIS-NUM-APOLICE TO MOVDEBCE-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -2385- MOVE PARCEHIS-NUM-PARCELA TO MOVDEBCE-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -2387- MOVE '6' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("6", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -2389- MOVE MOVDEBCE-DATA-PROXVEN TO MOVDEBCE-DATA-VENCIMENTO. */
            _.Move(MOVDEBCE_DATA_PROXVEN, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -2391- MOVE PARCEHIS-PRM-TOTAL TO MOVDEBCE-VALOR-DEBITO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -2393- MOVE PARCEHIS-DATA-MOVIMENTO TO MOVDEBCE-DATA-MOVIMENTO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -2396- MOVE APOLCOBR-DIA-DEBITO TO MOVDEBCE-DIA-DEBITO. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIA_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -2397- IF APOLCOBR-COD-AGENCIA EQUAL 104 */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA == 104)
            {

                /*" -2399- MOVE APOLCOBR-COD-AGENCIA-DEB TO MOVDEBCE-COD-AGENCIA-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

                /*" -2401- MOVE APOLCOBR-OPER-CONTA-DEB TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -2403- MOVE APOLCOBR-NUM-CONTA-DEB TO MOVDEBCE-NUM-CONTA-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

                /*" -2405- MOVE APOLCOBR-DIG-CONTA-DEB TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -2406- ELSE */
            }
            else
            {


                /*" -2412- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB MOVDEBCE-OPER-CONTA-DEB MOVDEBCE-NUM-CONTA-DEB MOVDEBCE-DIG-CONTA-DEB. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
            }


            /*" -2414- MOVE 102837 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(102837, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -2417- MOVE SPACES TO MOVDEBCE-DATA-ENVIO MOVDEBCE-DATA-RETORNO. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -2420- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF MOVDEBCE-NSAS. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -2422- MOVE 'BI0070B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("BI0070B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -2424- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -2427- MOVE APOLCOBR-NUM-CARTAO TO MOVDEBCE-NUM-CARTAO. */
            _.Move(APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

            /*" -2430- MOVE BILHETE-NUM-BILHETE TO MOVDEBCE-NUM-CERTIFICADO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO);

            /*" -2433- MOVE ZEROS TO MOVDEBCE-SEQUENCIA MOVDEBCE-NUM-LOTE. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE);

            /*" -2436- MOVE SPACES TO MOVDEBCE-DTCREDITO MOVDEBCE-STATUS-CARTAO. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);

            /*" -2439- MOVE ZEROS TO MOVDEBCE-VLR-CREDITO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);

            /*" -2448- MOVE ZEROS TO VIND-DIADEBITO VIND-AGENCIA VIND-OPERACAO VIND-NUMCONTA VIND-DIGCONTA VIND-NUMCARTAO VIND-USUARIO. */
            _.Move(0, VIND_DIADEBITO, VIND_AGENCIA, VIND_OPERACAO, VIND_NUMCONTA, VIND_DIGCONTA, VIND_NUMCARTAO, VIND_USUARIO);

            /*" -2460- MOVE -1 TO VIND-DTENVIO VIND-DTRETORNO VIND-CODRETORNO VIND-REQUISICAO VIND-SEQUENCIA VIND-NUM-LOTE VIND-DTCREDITO VIND-STATUS VIND-VLCREDITO. */
            _.Move(-1, VIND_DTENVIO, VIND_DTRETORNO, VIND_CODRETORNO, VIND_REQUISICAO, VIND_SEQUENCIA, VIND_NUM_LOTE, VIND_DTCREDITO, VIND_STATUS, VIND_VLCREDITO);

            /*" -2460- PERFORM R3100-00-INSERT-MOVDEBCE. */

            R3100_00_INSERT_MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-MOVDEBCE-SECTION */
        private void R3100_00_INSERT_MOVDEBCE_SECTION()
        {
            /*" -2473- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2532- PERFORM R3100_00_INSERT_MOVDEBCE_DB_INSERT_1 */

            R3100_00_INSERT_MOVDEBCE_DB_INSERT_1();

            /*" -2536- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2537- DISPLAY 'R3100-00 - PROBLEMAS NO INSERT(MOVDEBCE)   ' */
                _.Display($"R3100-00 - PROBLEMAS NO INSERT(MOVDEBCE)   ");

                /*" -2538- DISPLAY ' APOLICE    = ' MOVDEBCE-NUM-APOLICE */
                _.Display($" APOLICE    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -2539- DISPLAY ' ENDOSSO    = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2542- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2542- ADD 1 TO AC-MOVDEBCE. */
            WS_WORK_AREAS.AC_MOVDEBCE.Value = WS_WORK_AREAS.AC_MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R3100-00-INSERT-MOVDEBCE-DB-INSERT-1 */
        public void R3100_00_INSERT_MOVDEBCE_DB_INSERT_1()
        {
            /*" -2532- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF (COD_EMPRESA ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,SITUACAO_COBRANCA ,DATA_VENCIMENTO ,VALOR_DEBITO ,DATA_MOVIMENTO ,TIMESTAMP ,DIA_DEBITO ,COD_AGENCIA_DEB ,OPER_CONTA_DEB ,NUM_CONTA_DEB ,DIG_CONTA_DEB ,COD_CONVENIO ,DATA_ENVIO ,DATA_RETORNO ,COD_RETORNO_CEF ,NSAS ,COD_USUARIO ,NUM_REQUISICAO ,NUM_CARTAO ,SEQUENCIA ,NUM_LOTE ,DTCREDITO ,STATUS_CARTAO ,VLR_CREDITO ,NUM_CERTIFICADO) VALUES (:MOVDEBCE-COD-EMPRESA ,:MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-VALOR-DEBITO ,:MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP ,:MOVDEBCE-DIA-DEBITO :VIND-DIADEBITO ,:MOVDEBCE-COD-AGENCIA-DEB :VIND-AGENCIA ,:MOVDEBCE-OPER-CONTA-DEB :VIND-OPERACAO ,:MOVDEBCE-NUM-CONTA-DEB :VIND-NUMCONTA ,:MOVDEBCE-DIG-CONTA-DEB :VIND-DIGCONTA ,:MOVDEBCE-COD-CONVENIO ,:MOVDEBCE-DATA-ENVIO :VIND-DTENVIO ,:MOVDEBCE-DATA-RETORNO :VIND-DTRETORNO ,:MOVDEBCE-COD-RETORNO-CEF :VIND-CODRETORNO ,:MOVDEBCE-NSAS ,:MOVDEBCE-COD-USUARIO :VIND-USUARIO ,:MOVDEBCE-NUM-REQUISICAO :VIND-REQUISICAO ,:MOVDEBCE-NUM-CARTAO :VIND-NUMCARTAO ,:MOVDEBCE-SEQUENCIA :VIND-SEQUENCIA ,:MOVDEBCE-NUM-LOTE :VIND-NUM-LOTE ,:MOVDEBCE-DTCREDITO :VIND-DTCREDITO ,:MOVDEBCE-STATUS-CARTAO :VIND-STATUS ,:MOVDEBCE-VLR-CREDITO :VIND-VLCREDITO ,:MOVDEBCE-NUM-CERTIFICADO ) END-EXEC. */

            var r3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1 = new R3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                VIND_DIADEBITO = VIND_DIADEBITO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                VIND_AGENCIA = VIND_AGENCIA.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                VIND_OPERACAO = VIND_OPERACAO.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                VIND_NUMCONTA = VIND_NUMCONTA.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                VIND_DIGCONTA = VIND_DIGCONTA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_DATA_ENVIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.ToString(),
                VIND_DTENVIO = VIND_DTENVIO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRETORNO = VIND_CODRETORNO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                VIND_REQUISICAO = VIND_REQUISICAO.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                VIND_NUMCARTAO = VIND_NUMCARTAO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                VIND_NUM_LOTE = VIND_NUM_LOTE.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCREDITO = VIND_DTCREDITO.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLCREDITO = VIND_VLCREDITO.ToString(),
                MOVDEBCE_NUM_CERTIFICADO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CERTIFICADO.ToString(),
            };

            R3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_MOVDEBCE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-INSERT-RELATORI-SECTION */
        private void R4000_00_INSERT_RELATORI_SECTION()
        {
            /*" -2555- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WS_WORK_AREAS.WABEND.WNR_EXEC_SQL);

            /*" -2557- MOVE 'BI0070B1' TO RELATORI-COD-RELATORIO. */
            _.Move("BI0070B1", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -2559- MOVE MOVDEBCE-NUM-APOLICE TO RELATORI-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -2561- MOVE MOVDEBCE-NUM-ENDOSSO TO RELATORI-NUM-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);

            /*" -2563- MOVE ZEROS TO RELATORI-NUM-CERTIFICADO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -2565- MOVE BILHETE-NUM-BILHETE TO RELATORI-NUM-TITULO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -2568- MOVE 3 TO RELATORI-COD-OPERACAO. */
            _.Move(3, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

            /*" -2653- PERFORM R4000_00_INSERT_RELATORI_DB_INSERT_1 */

            R4000_00_INSERT_RELATORI_DB_INSERT_1();

            /*" -2657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2658- DISPLAY 'R4000-00 - PROBLEMAS NO INSERT(RELATORI)   ' */
                _.Display($"R4000-00 - PROBLEMAS NO INSERT(RELATORI)   ");

                /*" -2659- DISPLAY ' APOLICE    = ' RELATORI-NUM-APOLICE */
                _.Display($" APOLICE    = {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -2660- DISPLAY ' ENDOSSO    = ' RELATORI-NUM-ENDOSSO */
                _.Display($" ENDOSSO    = {RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO}");

                /*" -2663- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2663- ADD 1 TO AC-RELATORI. */
            WS_WORK_AREAS.AC_RELATORI.Value = WS_WORK_AREAS.AC_RELATORI + 1;

        }

        [StopWatch]
        /*" R4000-00-INSERT-RELATORI-DB-INSERT-1 */
        public void R4000_00_INSERT_RELATORI_DB_INSERT_1()
        {
            /*" -2653- EXEC SQL INSERT INTO SEGUROS.RELATORIOS (COD_USUARIO ,DATA_SOLICITACAO ,IDE_SISTEMA ,COD_RELATORIO ,NUM_COPIAS ,QUANTIDADE ,PERI_INICIAL ,PERI_FINAL ,DATA_REFERENCIA ,MES_REFERENCIA ,ANO_REFERENCIA ,ORGAO_EMISSOR ,COD_FONTE ,COD_PRODUTOR ,RAMO_EMISSOR ,COD_MODALIDADE ,COD_CONGENERE ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_CERTIFICADO ,NUM_TITULO ,COD_SUBGRUPO ,COD_OPERACAO ,COD_PLANO ,OCORR_HISTORICO ,NUM_APOL_LIDER ,ENDOS_LIDER ,NUM_PARC_LIDER ,NUM_SINISTRO ,NUM_SINI_LIDER ,NUM_ORDEM ,COD_MOEDA ,TIPO_CORRECAO ,SIT_REGISTRO ,IND_PREV_DEFINIT ,IND_ANAL_RESUMO ,COD_EMPRESA ,PERI_RENOVACAO ,PCT_AUMENTO ,TIMESTAMP) VALUES ( 'BI0070B' ,:SISTEMA-DTMOVABE , 'BI' ,:RELATORI-COD-RELATORIO ,0 ,0 ,:SISTEMA-DTMOVABE ,:SISTEMA-DTMOVABE ,:SISTEMA-DTMOVABE ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,:RELATORI-NUM-APOLICE ,:RELATORI-NUM-ENDOSSO ,0 ,:RELATORI-NUM-CERTIFICADO ,:RELATORI-NUM-TITULO ,0 ,:RELATORI-COD-OPERACAO ,0 ,0 , ' ' , ' ' ,0 ,0 , ' ' ,0 ,0 , ' ' , '0' , ' ' , ' ' ,NULL ,0 ,0 ,CURRENT TIMESTAMP) END-EXEC. */

            var r4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1 = new R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1()
            {
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
            };

            R4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1.Execute(r4000_00_INSERT_RELATORI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2674- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WABEND.WSQLCODE);

            /*" -2675- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], WS_WORK_AREAS.WABEND.WSQLERRD1);

            /*" -2676- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], WS_WORK_AREAS.WABEND.WSQLERRD2);

            /*" -2677- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WS_WORK_AREAS.WABEND.WSQLERRMC);

            /*" -2679- DISPLAY WABEND. */
            _.Display(WS_WORK_AREAS.WABEND);

            /*" -2679- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2683- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2683- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}