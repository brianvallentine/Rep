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
using Sias.Bilhetes.DB2.BI0075B;

namespace Code
{
    public class BI0075B
    {
        public bool IsCall { get; set; }

        public BI0075B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0075B   (VERSAO DO CB7114B)             */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST COMPUTER                      *      */
        /*"      *   PROGRAMADOR ............  FAST COMPUTER                      *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2010                        *      */
        /*"      *   CADMUS .................  45.765                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - FAZ SOLICITACAO DA BAIXA DE      *      */
        /*"      *                             PARCELAS DE BILHETES COM A         *      */
        /*"      *                             SYSTEM CRED.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * EMPRESAS                            V1EMPRESA         INPUT    *      */
        /*"      * MOVIMENTO DE DEBITO EM C/C          V1MOVDEBCC_CEF    INPUT    *      */
        /*"      * AVISOS DE CREDITO                   V0AVISOCRED       OUTPUT   *      */
        /*"      * SALDOS DE AVISOS DE CREDITO         V0AVISOS_SALDOS   OUTPUT   *      */
        /*"      * RCAPS                               V0RCAP            I-O      *      */
        /*"      * RCAP COMPLEMENTAR                   V0RCAPCOMP        OUTPUT   *      */
        /*"      * COMISSAO FENAE                      V0COMISSAO_FENAE  OUTPUT   *      */
        /*"      * VENDAS BILHETE                      V0VENDAS_BILHETE  OUTPUT   *      */
        /*"      * CONTROLE DESPESAS CEF               V0CONT_DESP_CEF   OUTPUT   *      */
        /*"      * COMISSAO ADIANTA                    V0ADIANTA         OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                          ALTERACAO                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  GILSON PINTO DA SILVA - 24/01/2024 *      */
        /*"      *   VERSAO 18               - INCLUIR A COLUNA STA_DEPOSITO_TER  *      */
        /*"      *                             NA TABELA AVISO_CREDITO PARA FAZER *      */
        /*"      *                             A CONCILIACAO DOS AVISOS DE CREDITO*      */
        /*"      *                             MANUAL COM O DEPOSITO DE TERCEIRO  *      */
        /*"      *                             (DT) NO MCP-ZE.                    *      */
        /*"      *                           - ESTA COLUNA ASSUME COMO DEFAULT O  *      */
        /*"      *                             DOMINIO 'P' (CREDITO NAO CONSUMIDO)*      */
        /*"      *                             E SOMENTE OS PROGRAMAS DO SISTEMA  *      */
        /*"      *                             "ZE" EH QUE ATUALIZARAO A MESMA.   *      */
        /*"      *                           - JAZZ - DEMANDA - 569880            *      */
        /*"      *                                    TAREFA  - 569478            *      */
        /*"      *                           - PROCURAR POR V.18                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  *  VERSAO 17  - DEMANDA 564.320                                  *      */
        /*"      *             - SUBSTITUIR A CHAMADA DA ROTINA FC0105S DA CAP    *      */
        /*"      *               PELA VG0105S                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/01/2024 - RAUL BASILI ROTTA                             *      */
        /*"      *                                        PROCURE POR V.17        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16   - HISTORIA 226662                                *      */
        /*"      *               - ALTERAR A APLICA��O PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (CVP/JV1) E SEUS PRODUTOS E PERMITIR   *      */
        /*"      *                 A PESQUISA DA EMPRESA CAP DO PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/04/2020 - HUSNI ALI HUSNI    PROCURE POR V.16          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15   - HISTORIA 196716                               *       */
        /*"      *               - ALTERAR A APLICA��O PARA TRATAMENTO DA NOVA    *      */
        /*"      *                 EMPRESA (JV1) E SEUS PRODUTOS.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2019 - LUIZ FERNANDO      PROCURE POR V.15          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - HISTORIA 178780                                  *      */
        /*"      *             - MUDANCAS DE PRODUTOS ACOPLADOS - CAP             *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2019 - RIBAMAR MARQUES (ALTRAN)                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 -   HIST�RIA JAZZ = 29581                          *      */
        /*"      *                                                                *      */
        /*"      *                 CORRIGIR O ABEND DA QUANTIDADE DE PRODUTOS EX- *      */
        /*"      *                 CEDIDOS NA TABELA DE PRODUTO.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/05/2018 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 -   HIST�RIA JAZZ = 10807/11931                    *      */
        /*"      *                 TAREFA JAZZ = 107.303 (JAZZ antigo)            *      */
        /*"      *                 CORRIGIR A ATUALIZACAO DO CAMPO                *      */
        /*"      *                 TIP_CANCELAMENTO DA TABELA BILHETE PARA O      *      */
        /*"      *                 DOMINIO '3' - CANCELAMENTO POR INADIMPLENCIA.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/03/2018 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/03/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.11         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CADMUS 108.585                                   *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRAR GRAVACAO DA TABELA V0COMISSOES.          *      */
        /*"      *             - A INCLUSAO � FEITA NO MOMENTO DA INTEGRACAO OU   *      */
        /*"      *   NA GERA��O DE DEMAIS PARCELAS.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 74.006/74007                                 *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE NO TAMANHO DA TABELA INTERNA DE PRODUTOS  *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/09/2012 - CLAUDIO FREITAS (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *           COMISSIONAMENTO MAIS ESTUDO                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/04/2012 - FAST COMPUTER - TERCIO CARVALHO              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - CAD 64.999                                       *      */
        /*"      *                                                                *      */
        /*"      *           ADAPTAR OS PROGRAMAS DE VIDA PARA UTILIZAREM A NOVA  *      */
        /*"      *           ROTINA DE COMPRA DA CAP QUE SOFREU ALTERACAO,        *      */
        /*"      *           MODIFICANDO A CHAMADA DA ROTINA FC0105B PARA FC0105S.*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/12/2011 - FAST COMPUTER - ROGERIO PEREIRA              *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 201.137 / 51.476                             *      */
        /*"      *               - KIT POS-VENDA                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2011 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 54.910                                       *      */
        /*"      *                                                                *      */
        /*"      *               - ALTERACAO DO PLANO DE CAPITALIZACAO DE 810     *      */
        /*"      *                 PARA 818                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/05/2011 - BRUNO RIBEIRO  (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 53.129                                       *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NO CAMPO NRAVISO AO INSERIR NA TABELA   *      */
        /*"      *                 SEGUROS.MOVIMENTO_COBRANCA.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 52.124                                       *      */
        /*"      *               - REVISAO DA OPERACAO.                           *      */
        /*"      *               - AJUSTE NO CODIGO DE CONVENIO MUDANDO DAS       *      */
        /*"      *                 SEIS ULTIMAS PARA AS SEIS PRIMEIRA POSICOES    *      */
        /*"      *                 EM FUNCAO DO SAP.                              *      */
        /*"      *               - AJUSTE DO CODIGO DA AGENCIA DO AVISO PARA 777  *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/01/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 51.788                                       *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTE NO TAMANHO DA TABELA INTERNA DE PRODUTOS  *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/12/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CAD-51.015                                       *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO RETENCAO DE CLIENTES - SYSTEM CRED       *      */
        /*"      *               IMPLEMENTACAO DE UM NOVO PRODUTO.                *      */
        /*"      *               - 8124 (FACIL PLANO 1 ODONTO).                   *      */
        /*"      *               - 8132 (FACIL PLANO 2 ODONTO).                   *      */
        /*"      *               - 8125 (VIDA AP + RD).                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/12/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77    VIND-NRAVISO              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-COD-EMPRESA          PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTLIBER              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBC              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODEMP               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ORDLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPSGU               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TIPSGU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-APOLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_APOLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ENDOSLID             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ENDOSLID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODLIDER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-FONTE                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRRCAP               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEQUENCIA            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUM-LOTE             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRTIT                PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRTIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRODU             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGECOBR              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRCERTIF             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMAPOL              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRENDOS              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRPARCEL             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RECUPERA             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_RECUPERA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-ACRESCIMO            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ACRESCIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRGER            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRMATRGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTGER            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VALADTGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGGER             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTPAGGER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTCANCEL             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NRMATRSUN            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NRMATRSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VALADTSUN            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VALADTSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTPAGSUN             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTPAGSUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TIPO                 PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TIPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTVENCTO             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NULL02               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DATSEL               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DATSEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CODPRP               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_CODPRP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMBIL               PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-VLVARMON             PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_VLVARMON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTQITBCO2            PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTQITBCO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-DTMOVTO              PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-QTDE               PIC S9(009)     COMP.*/
        public IntBasis WSHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    WSHOST-NUMSIV01           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-NUMSIV02           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV02 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    WSHOST-COUNT              PIC S9(009)     COMP.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1EMPR-COD-EMP      PIC S9(004)                COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1EMPR-NOM-EMP      PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0PARC-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0PARC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PARC-NUM-ENDOSSO          PIC S9(09) COMP.*/
        public IntBasis V0PARC_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARC-NUM-PARCELA          PIC S9(04) COMP.*/
        public IntBasis V0PARC_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PCHS-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0PCHS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0PCHS-NUM-ENDOSSO          PIC S9(09) COMP.*/
        public IntBasis V0PCHS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PCHS-NUM-PARCELA          PIC S9(04) COMP.*/
        public IntBasis V0PCHS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V1MVDB_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V1MVDB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V1MVDB-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V1MVDB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-NRENDOS1             PIC S9(09) COMP.*/
        public IntBasis V1MVDB_NRENDOS1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V1MVDB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-SIT-COBRANCA         PIC  X(01).*/
        public StringBasis V1MVDB_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1MVDB-DTVENCTO             PIC  X(10).*/
        public StringBasis V1MVDB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DTCREDITO            PIC  X(10).*/
        public StringBasis V1MVDB_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V1MVDB_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-VLR-DEBITO           PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1MVDB_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1MVDB-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V1MVDB_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V1MVDB_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1MVDB-DTMOVTO              PIC  X(10).*/
        public StringBasis V1MVDB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DTENVIO              PIC  X(10).*/
        public StringBasis V1MVDB_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-DTRETORNO            PIC  X(10).*/
        public StringBasis V1MVDB_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1MVDB-COD-RET-CEF          PIC S9(04) COMP.*/
        public IntBasis V1MVDB_COD_RET_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V1MVDB_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-VLR-CREDITO          PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V1MVDB_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  V1MVDB-SEQUENCIA            PIC S9(04)    COMP.*/
        public IntBasis V1MVDB_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1MVDB-NUM-LOTE             PIC S9(09)    COMP.*/
        public IntBasis V1MVDB_NUM_LOTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AVIS-BCOAVISO             PIC S9(04) COMP.*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AVIS-AGEAVISO             PIC S9(04) COMP.*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AVIS-NRAVISO              PIC S9(09) COMP.*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AVIS-NRSEQ                PIC S9(09) COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AVIS-DTMOVTO              PIC  X(10).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0AVIS-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AVIS-TIPAVI               PIC  X(01).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0AVIS-DTAVISO              PIC  X(10).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0AVIS-VLIOCC               PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVIS-VLDESPES             PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVIS-PRECED               PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVIS-VLPRMLIQ             PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVIS-VLPRMTOT             PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVIS-SITCONTB             PIC  X(01).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0AVIS-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0AVIS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AVIS-ORIGAVISO            PIC S9(04) COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AVIS-VALADT               PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVIS-SITDEPTER            PIC  X(01).*/
        public StringBasis V0AVIS_SITDEPTER { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0AVSD-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0AVSD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AVSD-BCOAVISO             PIC S9(04) COMP.*/
        public IntBasis V0AVSD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AVSD-AGEAVISO             PIC S9(04) COMP.*/
        public IntBasis V0AVSD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0AVSD-TIPSGU               PIC  X(01).*/
        public StringBasis V0AVSD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V0AVSD-NRAVISO              PIC S9(09) COMP.*/
        public IntBasis V0AVSD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0AVSD-DTAVISO              PIC  X(10).*/
        public StringBasis V0AVSD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0AVSD-DTMOVTO              PIC  X(10).*/
        public StringBasis V0AVSD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0AVSD-SDOATU               PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0AVSD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0AVSD-SITUACAO             PIC  X(01).*/
        public StringBasis V0AVSD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77    V0MCOB-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-CODMOV             PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_CODMOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-BANCO              PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-AGENCIA            PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-NUMFITA            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NUMFITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0MCOB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MCOB-DTQITBCO           PIC  X(010).*/
        public StringBasis V0MCOB_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0MCOB-NRTIT              PIC S9(013)     COMP-3.*/
        public IntBasis V0MCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MCOB-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0MCOB_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0MCOB-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0MCOB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0MCOB-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0MCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0MCOB-VALTIT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VALTIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-VALCDT             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0MCOB_VALCDT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0MCOB-SITUACAO           PIC  X(001).*/
        public StringBasis V0MCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0MCOB-NOME               PIC  X(040).*/
        public StringBasis V0MCOB_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77    V0MCOB-TIPOMOV            PIC  X(001).*/
        public StringBasis V0MCOB_TIPOMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-NUMAPOL            PIC S9(013)     COMP-3.*/
        public IntBasis V0FOLL_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0FOLL-NRENDOS            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-NRPARCEL           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DACPARC            PIC  X(001).*/
        public StringBasis V0FOLL_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-DTMOVTO            PIC  X(010).*/
        public StringBasis V0FOLL_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-HORAOPER           PIC  X(008).*/
        public StringBasis V0FOLL_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0FOLL-VLPREMIO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0FOLL_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0FOLL-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-CODBAIXA           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-CDERRO01           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO02           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO03           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO04           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO05           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-CDERRO06           PIC  X(001).*/
        public StringBasis V0FOLL_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITUACAO           PIC  X(001).*/
        public StringBasis V0FOLL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-SITCONTB           PIC  X(001).*/
        public StringBasis V0FOLL_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-OPERACAO           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-DTLIBER            PIC  X(010).*/
        public StringBasis V0FOLL_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-DTQITBCO           PIC  X(010).*/
        public StringBasis V0FOLL_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0FOLL-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0FOLL-ORDLIDER           PIC S9(015)     COMP-3.*/
        public IntBasis V0FOLL_ORDLIDER { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0FOLL-TIPSGU             PIC  X(001).*/
        public StringBasis V0FOLL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0FOLL-APOLIDER           PIC  X(015).*/
        public StringBasis V0FOLL_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-ENDOSLID           PIC  X(015).*/
        public StringBasis V0FOLL_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77    V0FOLL-CODLIDER           PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0FOLL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0FOLL-NRRCAP             PIC S9(009)     COMP.*/
        public IntBasis V0FOLL_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-ANOREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_ANOREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-MESREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_MESREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0DPCF-TIPOREG            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-SITUACAO           PIC  X(001).*/
        public StringBasis V0DPCF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-TIPOCOB            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0DPCF-DTMOVTO            PIC  X(010).*/
        public StringBasis V0DPCF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0DPCF-DTAVISO            PIC  X(010).*/
        public StringBasis V0DPCF_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0DPCF-QTDREG             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0DPCF-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLJUROS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0DPCF-VLMULTA            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BILH-NUMBIL             PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-FONTE              PIC S9(004)     COMP.*/
        public IntBasis V0BILH_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-AGECOBR            PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-RAMO               PIC S9(004)     COMP.*/
        public IntBasis V0BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-CODCLIEN           PIC S9(009)     COMP.*/
        public IntBasis V0BILH_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0BILH-NRMATRVEN          PIC S9(015)     COMP-3.*/
        public IntBasis V0BILH_NRMATRVEN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0BILH-AGECTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPRCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPRCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMCTAVEN          PIC S9(013)     COMP-3.*/
        public IntBasis V0BILH_NUMCTAVEN { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0BILH-DIGCTAVEN          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_DIGCTAVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-AGECTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPRCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-NUMCTADEB          PIC S9(013)     COMP-3.*/
        public IntBasis V0BILH_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0BILH-DIGCTADEB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-OPCAO-COB          PIC S9(004)     COMP.*/
        public IntBasis V0BILH_OPCAO_COB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0BILH-DTQITBCO           PIC  X(010).*/
        public StringBasis V0BILH_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-VLRCAP             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0BILH_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0BILH-DTVENDA            PIC  X(010).*/
        public StringBasis V0BILH_DTVENDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0BILH-SITUACAO           PIC  X(001).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0BILH-NUMAPOL            PIC S9(013)    VALUE +0   COMP-3*/
        public IntBasis V0BILH_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0PRFD-NUMPROPOSTA        PIC S9(15)V    COMP-3.*/
        public DoubleBasis V0PRFD_NUMPROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77    V0PRFD-NUMSICOB           PIC S9(15)V    COMP-3.*/
        public DoubleBasis V0PRFD_NUMSICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77    V0PRFD-CODPROD            PIC S9(4)      COMP.*/
        public IntBasis V0PRFD_CODPROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77    V0PRFD-ORIGEM-PROPOSTA    PIC S9(4)      COMP.*/
        public IntBasis V0PRFD_ORIGEM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77    V0COMI-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0COMI_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0COMI-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0COMI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COMI-NRCERTIF           PIC S9(015)    COMP-3.*/
        public IntBasis V0COMI_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0COMI-DIGCERT            PIC  X(001).*/
        public StringBasis V0COMI_DIGCERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0COMI-IDTPSEGU           PIC  X(001).*/
        public StringBasis V0COMI_IDTPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0COMI-NRPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-OPERACAO           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-CODPDT             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COMI-RAMOFR             PIC S9(004)    COMP.*/
        public IntBasis V0COMI_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-MODALIFR           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-OCORHIST           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-FONTE              PIC S9(004)    COMP.*/
        public IntBasis V0COMI_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-CODCLIEN           PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COMI-VLCOMIS            PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMI_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COMI-DATCLO             PIC  X(010).*/
        public StringBasis V0COMI_DATCLO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0COMI-NUMREC             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_NUMREC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COMI-VALBAS             PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMI_VALBAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COMI-TIPCOM             PIC  X(001).*/
        public StringBasis V0COMI_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0COMI-QTPARCEL           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-PCCOMCOR           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis V0COMI_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77    V0COMI-PCDESCON           PIC S9(003)V99 COMP-3.*/
        public DoubleBasis V0COMI_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77    V0COMI-CODSUBES           PIC S9(004)    COMP.*/
        public IntBasis V0COMI_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0COMI-HORAOPER           PIC  X(008).*/
        public StringBasis V0COMI_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77    V0COMI-DTMOVTO            PIC  X(010).*/
        public StringBasis V0COMI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0COMI-DATSEL             PIC  X(010).*/
        public StringBasis V0COMI_DATSEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0COMI-CODEMP             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COMI-CODPRP             PIC S9(009)    COMP.*/
        public IntBasis V0COMI_CODPRP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0COMI-NUMBIL             PIC S9(015)    COMP-3.*/
        public IntBasis V0COMI_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77    V0COMI-VLVARMON           PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0COMI_VLVARMON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77    V0COMI-DTQITBCO           PIC  X(010).*/
        public StringBasis V0COMI_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0COMI-COUNT              PIC S9(004)    COMP.*/
        public IntBasis V0COMI_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0APCB-NUMAPOL            PIC S9(013)    COMP-3.*/
        public IntBasis V0APCB_NUMAPOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77    V0APCB-NRENDOS            PIC S9(009)    COMP.*/
        public IntBasis V0APCB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0APCB-CODPROD            PIC S9(004)    COMP-3.*/
        public IntBasis V0APCB_CODPROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0APCB-NUMCARTAO          PIC S9(016)V   COMP-3.*/
        public DoubleBasis V0APCB_NUMCARTAO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(016)V"), 0);
        /*"77  V0CONV-NUMSICOB              PIC S9(15)V COMP-3.*/
        public DoubleBasis V0CONV_NUMSICOB { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  V0CONV-CODPRODU              PIC S9(04)  COMP.*/
        public IntBasis V0CONV_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01     LK-PLANO                PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-SERIE                PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TITULO               PIC S9(9)      USAGE COMP.*/
        public IntBasis LK_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01     LK-NUM-PROPOSTA         PIC S9(15)V    USAGE COMP-3.*/
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01     LK-QTD-TITULOS          PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-VLR-TITULO           PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"01     LK-PARCEIRO             PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_PARCEIRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-RAMO                 PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-COD-USUARIO          PIC  X(8).*/
        public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01     LK-NUM-NSA              PIC S9(4)      USAGE COMP.*/
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01     LK-TRACE                PIC X(009).*/

        public SelectorBasis LK_TRACE { get; set; } = new SelectorBasis("009")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88   LK-TRACE-ON             VALUE 'TRACE ON '. */
							new SelectorItemBasis("LK_TRACE_ON", "TRACE ON "),
							/*" 88   LK-TRACE-OFF            VALUE 'TRACE OFF'. */
							new SelectorItemBasis("LK_TRACE_OFF", "TRACE OFF")
                }
        };

        /*"01     LK-OUT-COD-RETORNO     PIC S9(004) COMP.*/
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-SQLCODE         PIC S9(004) COMP.*/
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01     LK-OUT-MENSAGEM        PIC X(070).*/
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLERRMC        PIC X(070).*/
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        /*"01     LK-OUT-SQLSTATE        PIC X(005).*/
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"01           AREA-DE-WORK.*/
        public BI0075B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0075B_AREA_DE_WORK();
        public class BI0075B_AREA_DE_WORK : VarBasis
        {
            /*"  05 W-ORIGEM-PROPOSTA                PIC 9(004).*/

            public SelectorBasis W_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("004")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ORIGEM-SIGPF                 VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88 ORIGEM-CAIXA-PREV            VALUE 02. */
							new SelectorItemBasis("ORIGEM_CAIXA_PREV", "02"),
							/*" 88 ORIGEM-SIGAT                 VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88 ORIGEM-SASSE                 VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88 ORIGEM-CAIXA-CAP             VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88 ORIGEM-MANUAL                VALUE 06. */
							new SelectorItemBasis("ORIGEM_MANUAL", "06"),
							/*" 88 ORIGEM-REMOTA                VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88 ORIGEM-INTRANET              VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88 ORIGEM-INTERNET              VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09"),
							/*" 88 ORIGEM-CORRET-VIT            VALUE 10. */
							new SelectorItemBasis("ORIGEM_CORRET_VIT", "10"),
							/*" 88 ORIGEM-FILIAL                VALUE 11. */
							new SelectorItemBasis("ORIGEM_FILIAL", "11"),
							/*" 88 ORIGEM-MARSH                 VALUE 12. */
							new SelectorItemBasis("ORIGEM_MARSH", "12"),
							/*" 88 ORIGEM-LOTERICO              VALUE 13. */
							new SelectorItemBasis("ORIGEM_LOTERICO", "13"),
							/*" 88 ORIGEM-CORRESPOND            VALUE 14. */
							new SelectorItemBasis("ORIGEM_CORRESPOND", "14"),
							/*" 88 ORIGEM-AIC                   VALUE 1000. */
							new SelectorItemBasis("ORIGEM_AIC", "1000"),
							/*" 88 ORIGEM-SYSTEMCRED            VALUE 1001. */
							new SelectorItemBasis("ORIGEM_SYSTEMCRED", "1001"),
							/*" 88 ORIGEM-GRUPOFIG              VALUE 1002. */
							new SelectorItemBasis("ORIGEM_GRUPOFIG", "1002"),
							/*" 88 ORIGEM-BRASSIST              VALUE 1003. */
							new SelectorItemBasis("ORIGEM_BRASSIST", "1003"),
							/*" 88 ORIGEM-PAR                   VALUE 1004. */
							new SelectorItemBasis("ORIGEM_PAR", "1004"),
							/*" 88 ORIGEM-ADMEDICAL             VALUE 1005. */
							new SelectorItemBasis("ORIGEM_ADMEDICAL", "1005"),
							/*" 88 ORIGEM-TRAY                  VALUE 1006. */
							new SelectorItemBasis("ORIGEM_TRAY", "1006"),
							/*" 88 ORIGEM-MESTUDO               VALUE 1007. */
							new SelectorItemBasis("ORIGEM_MESTUDO", "1007"),
							/*" 88 ORIGEM-VIDAX                 VALUE 1008. */
							new SelectorItemBasis("ORIGEM_VIDAX", "1008")
                }
            };

            /*"  05         WSL-SQLCODE       PIC  9(09)     VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05         AC-LINHAS         PIC  9(002)    VALUE 80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 80);
            /*"  05         AC-PAGINA         PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-LIDOS          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-RESTO          PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-RESULT         PIC  9(007)    VALUE ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WS-IND            PIC  9(003)    VALUE ZEROS.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05         WS-INDMAX         PIC  9(003)    VALUE ZEROS.*/
            public IntBasis WS_INDMAX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05         WS-CHAVE          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-QT-REJEITADOS  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_REJEITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-QT-APROVADOS   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_APROVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-QT-DEVOLVIDO   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_DEVOLVIDO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-QT-TOTAL       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_QT_TOTAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-VL-REJEITADOS  PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_REJEITADOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-APROVADOS   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_APROVADOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-DEVOLVIDO   PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_DEVOLVIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-FOLLOW      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_FOLLOW { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         AC-VL-TOTAL       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         WVLPENDEN         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis WVLPENDEN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05         WS-VLPRMTAR       PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLPRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WS-QTDBIL         PIC S9(004)    COMP.*/
            public IntBasis WS_QTDBIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WS-SUBS           PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WS-SUBS1          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WS-SUBS2          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AD-QTDEBIL        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AD_QTDEBIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AD-VLRABIL        PIC S9(013)V99 VALUE +0 COMP-3.*/
            public DoubleBasis AD_VLRABIL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         ZZ-VALADT         PIC ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis ZZ_VALADT { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"  05         AC-U-V0MOVDEBCC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0MOVDEBCC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-S-V0MOVDEBCC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_S_V0MOVDEBCC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-D-V0RCAP       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_D_V0RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0RCAP       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0RCAPCOMP   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-L-V1RCAP       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_L_V1RCAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0AVISOCRED  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0AVISOCRED { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0AVISOSAL   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0AVISOSAL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0FOLLOWUP   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FOLLOWUP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-MOVICOB        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_MOVICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-COMISSAO       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_COMISSAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-U-V0BILHETE    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_U_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0BILHETE    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0ENDOSSO    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0COMIFENAE  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0COMIFENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0PARCELAS   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0PARCHIST   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0PARCHIST { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-C-V0APOLCOBR   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_C_V0APOLCOBR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0COMIFENAE  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COMIFENAE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0VENDASBIL  PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0VENDASBIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0ADIANTA    PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0ADIANTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0FORMAREC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0FORMAREC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-V0HISTOREC   PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOREC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         AC-I-DESPESAS     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis AC_I_DESPESAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         LD-PRODUTO        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WFIM-V1EMPRESA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1EMPRESA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1MOVDEBCC   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1MOVDEBCC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1BILHETE    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-BILCOBER     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_BILCOBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PRODUTO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PARCELA      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-HEADER       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_HEADER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-TRAILLER     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_TRAILLER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-CONVERSI     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_CONVERSI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDUP-V0RCAP       PIC  X(001)    VALUE SPACES.*/
            public StringBasis WDUP_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-PROGRAMA       PIC  X(007)    VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
            /*"  05         WS-SQLCODE        PIC  ----9.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
            /*"  05         WS-CANCBIL        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_CANCBIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         TB-MENSAGENS.*/
            public BI0075B_TB_MENSAGENS TB_MENSAGENS { get; set; } = new BI0075B_TB_MENSAGENS();
            public class BI0075B_TB_MENSAGENS : VarBasis
            {
                /*"    10       FILLER            PIC  X(037)    VALUE            '01INSUFICIENCIA DE FUNDOS'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"01INSUFICIENCIA DE FUNDOS");
                /*"    10       FILLER            PIC  X(037)    VALUE            '02CARTAO CANCELADO'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"02CARTAO CANCELADO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '03SUBSTITUICAO CARTAO'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"03SUBSTITUICAO CARTAO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '04CARTAO INVALIDO'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"04CARTAO INVALIDO");
                /*"    10       FILLER            PIC  X(037)    VALUE            '97ESTORNO S/COB OU ERRO DUPLICIDADE'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"97ESTORNO S/COB OU ERRO DUPLICIDADE");
                /*"    10       FILLER            PIC  X(037)    VALUE            '98ESTORNO S/COB NO PROXIMO MES'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"98ESTORNO S/COB NO PROXIMO MES");
                /*"    10       FILLER            PIC  X(037)    VALUE            '99CANCELA SEGURO'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"99CANCELA SEGURO");
                /*"  05         TB-MENSAGENS-R    REDEFINES TB-MENSAGENS.*/
            }
            private _REDEF_BI0075B_TB_MENSAGENS_R _tb_mensagens_r { get; set; }
            public _REDEF_BI0075B_TB_MENSAGENS_R TB_MENSAGENS_R
            {
                get { _tb_mensagens_r = new _REDEF_BI0075B_TB_MENSAGENS_R(); _.Move(TB_MENSAGENS, _tb_mensagens_r); VarBasis.RedefinePassValue(TB_MENSAGENS, _tb_mensagens_r, TB_MENSAGENS); _tb_mensagens_r.ValueChanged += () => { _.Move(_tb_mensagens_r, TB_MENSAGENS); }; return _tb_mensagens_r; }
                set { VarBasis.RedefinePassValue(value, _tb_mensagens_r, TB_MENSAGENS); }
            }  //Redefines
            public class _REDEF_BI0075B_TB_MENSAGENS_R : VarBasis
            {
                /*"    10       FILLER            OCCURS 7  TIMES.*/
                public ListBasis<BI0075B_FILLER_7> FILLER_7 { get; set; } = new ListBasis<BI0075B_FILLER_7>(7);
                public class BI0075B_FILLER_7 : VarBasis
                {
                    /*"      15     TB-RETORNO        PIC  9(002).*/
                    public IntBasis TB_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     TB-MENSAGEM       PIC  X(035).*/
                    public StringBasis TB_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                    /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                    public BI0075B_FILLER_7()
                    {
                        TB_RETORNO.ValueChanged += OnValueChanged;
                        TB_MENSAGEM.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_BI0075B_TB_MENSAGENS_R()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_BI0075B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_BI0075B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_BI0075B_FILLER_8(); _.Move(WDATA_REL, _filler_8); VarBasis.RedefinePassValue(WDATA_REL, _filler_8, WDATA_REL); _filler_8.ValueChanged += () => { _.Move(_filler_8, WDATA_REL); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WDATA_REL); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_8 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SQL.*/

                public _REDEF_BI0075B_FILLER_8()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI0075B_WDATA_SQL WDATA_SQL { get; set; } = new BI0075B_WDATA_SQL();
            public class BI0075B_WDATA_SQL : VarBasis
            {
                /*"    10       WDAT-AA-SQL       PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_AA_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDAT-T1-SQL       PIC  X(001)    VALUE '-'.*/
                public StringBasis WDAT_T1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-MM-SQL       PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WDAT-T2-SQL       PIC  X(001)    VALUE '-'.*/
                public StringBasis WDAT_T2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WDAT-DD-SQL       PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_DD_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_BI0075B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_BI0075B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_BI0075B_FILLER_11(); _.Move(WDATA_CURR, _filler_11); VarBasis.RedefinePassValue(WDATA_CURR, _filler_11, WDATA_CURR); _filler_11.ValueChanged += () => { _.Move(_filler_11, WDATA_CURR); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_11 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-AMD-R.*/

                public _REDEF_BI0075B_FILLER_11()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public BI0075B_WDATA_AMD_R WDATA_AMD_R { get; set; } = new BI0075B_WDATA_AMD_R();
            public class BI0075B_WDATA_AMD_R : VarBasis
            {
                /*"    10       WDATA-AA-AMD      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_AMD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       WDATA-MM-AMD      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_AMD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WDATA-DD-AMD      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_AMD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-AMD         REDEFINES      WDATA-AMD-R                               PIC  9(008).*/
            }
            private _REDEF_IntBasis _wdata_amd { get; set; }
            public _REDEF_IntBasis WDATA_AMD
            {
                get { _wdata_amd = new _REDEF_IntBasis(new PIC("9", "008", "9(008).")); ; _.Move(WDATA_AMD_R, _wdata_amd); VarBasis.RedefinePassValue(WDATA_AMD_R, _wdata_amd, WDATA_AMD_R); _wdata_amd.ValueChanged += () => { _.Move(_wdata_amd, WDATA_AMD_R); }; return _wdata_amd; }
                set { VarBasis.RedefinePassValue(value, _wdata_amd, WDATA_AMD_R); }
            }  //Redefines
            /*"  05         WHORA-CURR.*/
            public BI0075B_WHORA_CURR WHORA_CURR { get; set; } = new BI0075B_WHORA_CURR();
            public class BI0075B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI0075B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI0075B_WDATA_CABEC();
            public class BI0075B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public BI0075B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI0075B_WHORA_CABEC();
            public class BI0075B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-HOST        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_HOST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-HOST.*/
            private _REDEF_BI0075B_FILLER_18 _filler_18 { get; set; }
            public _REDEF_BI0075B_FILLER_18 FILLER_18
            {
                get { _filler_18 = new _REDEF_BI0075B_FILLER_18(); _.Move(WDATA_HOST, _filler_18); VarBasis.RedefinePassValue(WDATA_HOST, _filler_18, WDATA_HOST); _filler_18.ValueChanged += () => { _.Move(_filler_18, WDATA_HOST); }; return _filler_18; }
                set { VarBasis.RedefinePassValue(value, _filler_18, WDATA_HOST); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_18 : VarBasis
            {
                /*"    10       WDATA-AA-HOST     PIC  9(004).*/
                public IntBasis WDATA_AA_HOST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-HOST     PIC  9(002).*/
                public IntBasis WDATA_MM_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-HOST     PIC  9(002).*/
                public IntBasis WDATA_DD_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WSSIST-DTMOVABE   PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0075B_FILLER_18()
                {
                    WDATA_AA_HOST.ValueChanged += OnValueChanged;
                    FILLER_19.ValueChanged += OnValueChanged;
                    WDATA_MM_HOST.ValueChanged += OnValueChanged;
                    FILLER_20.ValueChanged += OnValueChanged;
                    WDATA_DD_HOST.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WSSIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         WIDTCLIEMP        PIC  X(025)    VALUE SPACES.*/
            public StringBasis WIDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05         FILLER            REDEFINES      WIDTCLIEMP.*/
            private _REDEF_BI0075B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_BI0075B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_BI0075B_FILLER_21(); _.Move(WIDTCLIEMP, _filler_21); VarBasis.RedefinePassValue(WIDTCLIEMP, _filler_21, WIDTCLIEMP); _filler_21.ValueChanged += () => { _.Move(_filler_21, WIDTCLIEMP); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, WIDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_21 : VarBasis
            {
                /*"    10       WNUMBIL           PIC  9(015).*/
                public IntBasis WNUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER            PIC  X(010).*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05         WS-IDTCLIEMP      PIC  X(044)    VALUE SPACES.*/

                public _REDEF_BI0075B_FILLER_21()
                {
                    WNUMBIL.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "44", "X(044)"), @"");
            /*"  05         FILLER            REDEFINES      WS-IDTCLIEMP.*/
            private _REDEF_BI0075B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_BI0075B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_BI0075B_FILLER_23(); _.Move(WS_IDTCLIEMP, _filler_23); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_23, WS_IDTCLIEMP); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS_IDTCLIEMP); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WS_IDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_23 : VarBasis
            {
                /*"    10       FILLER            PIC  X(023).*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    10       WNUMPROP          PIC  9(013).*/
                public IntBasis WNUMPROP { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WNRPARCEL         PIC  9(004).*/
                public IntBasis WNRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(004).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WAPOLICE          PIC  9(013)    VALUE  ZEROS.*/

                public _REDEF_BI0075B_FILLER_23()
                {
                    FILLER_24.ValueChanged += OnValueChanged;
                    WNUMPROP.ValueChanged += OnValueChanged;
                    WNRPARCEL.ValueChanged += OnValueChanged;
                    FILLER_25.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WAPOLICE.*/
            private _REDEF_BI0075B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_BI0075B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_BI0075B_FILLER_26(); _.Move(WAPOLICE, _filler_26); VarBasis.RedefinePassValue(WAPOLICE, _filler_26, WAPOLICE); _filler_26.ValueChanged += () => { _.Move(_filler_26, WAPOLICE); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WAPOLICE); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_26 : VarBasis
            {
                /*"    10       WNUMAPOL          PIC  9(013).*/
                public IntBasis WNUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05         WS-NRTIT          PIC  9(014)    VALUE  ZEROS.*/

                public _REDEF_BI0075B_FILLER_26()
                {
                    WNUMAPOL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NRTIT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WS-NRTIT.*/
            private _REDEF_BI0075B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_BI0075B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_BI0075B_FILLER_27(); _.Move(WS_NRTIT, _filler_27); VarBasis.RedefinePassValue(WS_NRTIT, _filler_27, WS_NRTIT); _filler_27.ValueChanged += () => { _.Move(_filler_27, WS_NRTIT); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WS_NRTIT); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_27 : VarBasis
            {
                /*"    10       WS-NUMTIT         PIC  9(013).*/
                public IntBasis WS_NUMTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WS-DIGTIT         PIC  9(001).*/
                public IntBasis WS_DIGTIT { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WAGENCIA          PIC  X(004)    VALUE SPACES.*/

                public _REDEF_BI0075B_FILLER_27()
                {
                    WS_NUMTIT.ValueChanged += OnValueChanged;
                    WS_DIGTIT.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WAGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05         FILLER            REDEFINES      WAGENCIA.*/
            private _REDEF_BI0075B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_BI0075B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_BI0075B_FILLER_28(); _.Move(WAGENCIA, _filler_28); VarBasis.RedefinePassValue(WAGENCIA, _filler_28, WAGENCIA); _filler_28.ValueChanged += () => { _.Move(_filler_28, WAGENCIA); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WAGENCIA); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_28 : VarBasis
            {
                /*"    10       WAGEDEBITO        PIC  9(004).*/
                public IntBasis WAGEDEBITO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WNRAVISO          PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_BI0075B_FILLER_28()
                {
                    WAGEDEBITO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         FILLER            REDEFINES      WNRAVISO.*/
            private _REDEF_BI0075B_FILLER_29 _filler_29 { get; set; }
            public _REDEF_BI0075B_FILLER_29 FILLER_29
            {
                get { _filler_29 = new _REDEF_BI0075B_FILLER_29(); _.Move(WNRAVISO, _filler_29); VarBasis.RedefinePassValue(WNRAVISO, _filler_29, WNRAVISO); _filler_29.ValueChanged += () => { _.Move(_filler_29, WNRAVISO); }; return _filler_29; }
                set { VarBasis.RedefinePassValue(value, _filler_29, WNRAVISO); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_29 : VarBasis
            {
                /*"    10       WCONVENIOC        PIC  9(004).*/
                public IntBasis WCONVENIOC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WSEQUENCIA        PIC  9(005).*/
                public IntBasis WSEQUENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05         WCONVENIO         PIC  9(010)    VALUE ZEROS.*/

                public _REDEF_BI0075B_FILLER_29()
                {
                    WCONVENIOC.ValueChanged += OnValueChanged;
                    WSEQUENCIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WCONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"  05         WBILHETE          PIC  9(011)    VALUE ZEROS.*/
            public IntBasis WBILHETE { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  05         FILLER            REDEFINES      WBILHETE.*/
            private _REDEF_BI0075B_FILLER_30 _filler_30 { get; set; }
            public _REDEF_BI0075B_FILLER_30 FILLER_30
            {
                get { _filler_30 = new _REDEF_BI0075B_FILLER_30(); _.Move(WBILHETE, _filler_30); VarBasis.RedefinePassValue(WBILHETE, _filler_30, WBILHETE); _filler_30.ValueChanged += () => { _.Move(_filler_30, WBILHETE); }; return _filler_30; }
                set { VarBasis.RedefinePassValue(value, _filler_30, WBILHETE); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_30 : VarBasis
            {
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_31 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10       WNRRCAP           PIC  9(009).*/
                public IntBasis WNRRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10       FILLER            PIC  9(001).*/
                public IntBasis FILLER_32 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_BI0075B_FILLER_30()
                {
                    FILLER_31.ValueChanged += OnValueChanged;
                    WNRRCAP.ValueChanged += OnValueChanged;
                    FILLER_32.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_BI0075B_FILLER_33 _filler_33 { get; set; }
            public _REDEF_BI0075B_FILLER_33 FILLER_33
            {
                get { _filler_33 = new _REDEF_BI0075B_FILLER_33(); _.Move(WTIME_DAY, _filler_33); VarBasis.RedefinePassValue(WTIME_DAY, _filler_33, WTIME_DAY); _filler_33.ValueChanged += () => { _.Move(_filler_33, WTIME_DAY); }; return _filler_33; }
                set { VarBasis.RedefinePassValue(value, _filler_33, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_BI0075B_FILLER_33 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public BI0075B_WTIME_DAYR WTIME_DAYR { get; set; } = new BI0075B_WTIME_DAYR();
                public class BI0075B_WTIME_DAYR : VarBasis
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

                    public BI0075B_WTIME_DAYR()
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
                /*"  05         WS-TIME.*/

                public _REDEF_BI0075B_FILLER_33()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public BI0075B_WS_TIME WS_TIME { get; set; } = new BI0075B_WS_TIME();
            public class BI0075B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            LC01.*/
            }
            public BI0075B_LC01 LC01 { get; set; } = new BI0075B_LC01();
            public class BI0075B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'BI0075B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BI0075B");
                /*"    10          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public BI0075B_LC02 LC02 { get; set; } = new BI0075B_LC02();
            public class BI0075B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public BI0075B_LC03 LC03 { get; set; } = new BI0075B_LC03();
            public class BI0075B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(035) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    10          FILLER          PIC  X(047) VALUE               'RELATORIO DE OCORRENCIAS NO CONVENIO 1028370056'*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)"), @"RELATORIO DE OCORRENCIAS NO CONVENIO 1028370056");
                /*"    10          FILLER          PIC  X(003) VALUE 'EM '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"EM ");
                /*"    10          LC03-DATA       PIC  X(010).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(022) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public BI0075B_LC04 LC04 { get; set; } = new BI0075B_LC04();
            public class BI0075B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC06.*/
            }
            public BI0075B_LC06 LC06 { get; set; } = new BI0075B_LC06();
            public class BI0075B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(014) VALUE      'FITA RETORNO: '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"FITA RETORNO: ");
                /*"    10          LC06-FITA-RET   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LC06_FITA_RET { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER          PIC  X(114) VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "114", "X(114)"), @"");
                /*"  05            LC05.*/
            }
            public BI0075B_LC05 LC05 { get; set; } = new BI0075B_LC05();
            public class BI0075B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(006) VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10          FILLER          PIC  X(022)  VALUE               'BILHETE'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "22", "X(022)"), @"BILHETE");
                /*"    10          FILLER          PIC  X(010)  VALUE               'DT.VENC.'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT.VENC.");
                /*"    10          FILLER          PIC  X(010)  VALUE               'TIPO'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"TIPO");
                /*"    10          FILLER          PIC  X(015)  VALUE               'VALOR DEB/CRED'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VALOR DEB/CRED");
                /*"    10          FILLER          PIC  X(016)  VALUE               'VALOR PENDENTE'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"VALOR PENDENTE");
                /*"    10          FILLER          PIC  X(036)  VALUE               'MENSAGEM'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"MENSAGEM");
                /*"    10          FILLER          PIC  X(017)  VALUE               'FIT.ENV.'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"FIT.ENV.");
                /*"  05            LD01.*/
            }
            public BI0075B_LD01 LD01 { get; set; } = new BI0075B_LD01();
            public class BI0075B_LD01 : VarBasis
            {
                /*"    10          LD01-NUM-APOL   PIC  9(013).*/
                public IntBasis LD01_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NRENDOS    PIC  9(009) BLANK WHEN ZEROS.*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NRPARCEL   PIC  9(002) BLANK WHEN ZEROS.*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DTVENCTO   PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-TIPO       PIC  X(009).*/
                public StringBasis LD01_TIPO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLDEBITO   PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-VLPENDEN   PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLPENDEN { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-MENSAGEM   PIC  X(035).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
                /*"    10          FILLER          PIC  X(02) VALUE SPACES.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
                /*"    10          LD01-NSR        PIC  ZZZ99.*/
                public IntBasis LD01_NSR { get; set; } = new IntBasis(new PIC("9", "5", "ZZZ99."));
                /*"    10          FILLER          PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10          LD01-FOLLOW     PIC  X(008).*/
                public StringBasis LD01_FOLLOW { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  05            LD02.*/
            }
            public BI0075B_LD02 LD02 { get; set; } = new BI0075B_LD02();
            public class BI0075B_LD02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE ALL '*'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  05            LD03.*/
            }
            public BI0075B_LD03 LD03 { get; set; } = new BI0075B_LD03();
            public class BI0075B_LD03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10          FILLER          PIC  X(012) VALUE SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10          FILLER          PIC  X(021) VALUE 'BI0075B'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"BI0075B");
                /*"    10          FILLER          PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05            LD04.*/
            }
            public BI0075B_LD04 LD04 { get; set; } = new BI0075B_LD04();
            public class BI0075B_LD04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*  NAO HOUVE MOVIMENTO NESTA DATA  *'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*  NAO HOUVE MOVIMENTO NESTA DATA  *");
                /*"  05            LD05.*/
            }
            public BI0075B_LD05 LD05 { get; set; } = new BI0075B_LD05();
            public class BI0075B_LD05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*                                  *'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*                                  *");
                /*"  05            LT01.*/
            }
            public BI0075B_LT01 LT01 { get; set; } = new BI0075B_LT01();
            public class BI0075B_LT01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10          FILLER          PIC  X(018) VALUE               'TOTAL REJEITADOS  '.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"TOTAL REJEITADOS  ");
                /*"    10          LT01-VLDEBITO   PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    10          FILLER          PIC  X(070) VALUE SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"  05        WABEND.*/
            }
            public BI0075B_WABEND WABEND { get; set; } = new BI0075B_WABEND();
            public class BI0075B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0075B'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0075B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public BI0075B_LK_LINK LK_LINK { get; set; } = new BI0075B_LK_LINK();
        public class BI0075B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TIT              PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TIT { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01  AUX-TABELAS.*/
        }
        public BI0075B_AUX_TABELAS AUX_TABELAS { get; set; } = new BI0075B_AUX_TABELAS();
        public class BI0075B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public BI0075B_WTABG_VALORES WTABG_VALORES { get; set; } = new BI0075B_WTABG_VALORES();
            public class BI0075B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS      2000   TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<BI0075B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<BI0075B_WTABG_OCORREPRD>(2000);
                public class BI0075B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<BI0075B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<BI0075B_WTABG_OCORRETIP>(003);
                    public class BI0075B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<BI0075B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<BI0075B_WTABG_OCORRESIT>(002);
                        public class BI0075B_WTABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                            public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                            public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                        }
                    }
                }
            }
        }


        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.PARAMGER PARAMGER { get; set; } = new Dclgens.PARAMGER();
        public BI0075B_V0PRODUTO V0PRODUTO { get; set; } = new BI0075B_V0PRODUTO();
        public BI0075B_V0MOVDE V0MOVDE { get; set; } = new BI0075B_V0MOVDE();
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
            /*" -1012- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1015- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1018- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1021- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -1022- DISPLAY 'PROGRAMA EM EXECUCAO BI0075B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO BI0075B   ");

            /*" -1023- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -1042- DISPLAY 'VERSAO V.18 569880  24/01/2024 ' . */
            _.Display($"VERSAO V.18 569880  24/01/2024 ");

            /*" -1043- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -1045- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -1047- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1048- PERFORM R0900-00-DECLARE-V0MOVDEBCC. */

            R0900_00_DECLARE_V0MOVDEBCC_SECTION();

            /*" -1050- PERFORM R0910-00-LE-V0MOVDEBCC-CEF. */

            R0910_00_LE_V0MOVDEBCC_CEF_SECTION();

            /*" -1052- PERFORM R2100-00-MONTA-AVISOCRED. */

            R2100_00_MONTA_AVISOCRED_SECTION();

            /*" -1055- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1056- IF AC-LIDOS GREATER ZEROS */

            if (AREA_DE_WORK.AC_LIDOS > 00)
            {

                /*" -1058- PERFORM R2000-00-PROCESSA-FINAL. */

                R2000_00_PROCESSA_FINAL_SECTION();
            }


            /*" -1059- DISPLAY 'REGISTROS LIDOS ........... ' AC-LIDOS */
            _.Display($"REGISTROS LIDOS ........... {AREA_DE_WORK.AC_LIDOS}");

            /*" -1060- DISPLAY ' ' */
            _.Display($" ");

            /*" -1061- DISPLAY '** INSERIDOS **' */
            _.Display($"** INSERIDOS **");

            /*" -1062- DISPLAY ' ' */
            _.Display($" ");

            /*" -1063- DISPLAY ' V0AVISOCRED .............. ' AC-I-V0AVISOCRED */
            _.Display($" V0AVISOCRED .............. {AREA_DE_WORK.AC_I_V0AVISOCRED}");

            /*" -1064- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1065- DISPLAY ' V0AVISOS_SALDOS .......... ' AC-I-V0AVISOSAL */
            _.Display($" V0AVISOS_SALDOS .......... {AREA_DE_WORK.AC_I_V0AVISOSAL}");

            /*" -1066- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1067- DISPLAY ' V0FOLLOWUP ............... ' AC-I-V0FOLLOWUP */
            _.Display($" V0FOLLOWUP ............... {AREA_DE_WORK.AC_I_V0FOLLOWUP}");

            /*" -1068- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1069- DISPLAY ' V0MOVICOB ................ ' AC-MOVICOB */
            _.Display($" V0MOVICOB ................ {AREA_DE_WORK.AC_MOVICOB}");

            /*" -1070- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1071- DISPLAY ' V0COMISSAO ............... ' AC-COMISSAO */
            _.Display($" V0COMISSAO ............... {AREA_DE_WORK.AC_COMISSAO}");

            /*" -1072- DISPLAY ' ' */
            _.Display($" ");

            /*" -1073- DISPLAY ' ** ALTERADOS **' */
            _.Display($" ** ALTERADOS **");

            /*" -1074- DISPLAY ' ' */
            _.Display($" ");

            /*" -1075- DISPLAY ' V0MOVDEBCC_CEF ........... ' AC-U-V0MOVDEBCC. */
            _.Display($" V0MOVDEBCC_CEF ........... {AREA_DE_WORK.AC_U_V0MOVDEBCC}");

            /*" -1076- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1077- DISPLAY ' SUSPENDE DEMAIS PARCELAS . ' AC-S-V0MOVDEBCC. */
            _.Display($" SUSPENDE DEMAIS PARCELAS . {AREA_DE_WORK.AC_S_V0MOVDEBCC}");

            /*" -1078- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1079- DISPLAY ' BILHETES CANCELADOS ...... ' AC-C-V0BILHETE. */
            _.Display($" BILHETES CANCELADOS ...... {AREA_DE_WORK.AC_C_V0BILHETE}");

            /*" -1080- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1081- DISPLAY ' ENDOSSOS CANCELADOS ...... ' AC-C-V0ENDOSSO. */
            _.Display($" ENDOSSOS CANCELADOS ...... {AREA_DE_WORK.AC_C_V0ENDOSSO}");

            /*" -1082- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1083- DISPLAY ' PARCELAS CANCELADAS ...... ' AC-C-V0PARCELAS. */
            _.Display($" PARCELAS CANCELADAS ...... {AREA_DE_WORK.AC_C_V0PARCELAS}");

            /*" -1084- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1085- DISPLAY ' PARCELAS HIST CANCELADAS . ' AC-C-V0PARCHIST. */
            _.Display($" PARCELAS HIST CANCELADAS . {AREA_DE_WORK.AC_C_V0PARCHIST}");

            /*" -1086- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1087- DISPLAY ' APOLICE COBR ALTERADOS ... ' AC-C-V0APOLCOBR. */
            _.Display($" APOLICE COBR ALTERADOS ... {AREA_DE_WORK.AC_C_V0APOLCOBR}");

            /*" -1087- DISPLAY ' ' . */
            _.Display($" ");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1093- DISPLAY '*--- BI0075B   ' . */
            _.Display($"*--- BI0075B   ");

            /*" -1095- DISPLAY '   . FIM NORMAL' . */
            _.Display($"   . FIM NORMAL");

            /*" -1097- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1097- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1099- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -1110- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1112- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1117- PERFORM R0120-00-MONTA-EMPRESA. */

            R0120_00_MONTA_EMPRESA_SECTION();

            /*" -1118- SET WS-PRD TO 1. */
            WS_PRD.Value = 1;

            /*" -1121- MOVE ZEROS TO V0PROD-CODPRODU. */
            _.Move(0, V0PROD_CODPRODU);

            /*" -1123- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

            /*" -1124- MOVE 1 TO LD-PRODUTO */
            _.Move(1, AREA_DE_WORK.LD_PRODUTO);

            /*" -1125- MOVE SPACES TO WFIM-PRODUTO */
            _.Move("", AREA_DE_WORK.WFIM_PRODUTO);

            /*" -1127- PERFORM R0200-00-DECLARE-V0PRODUTO. */

            R0200_00_DECLARE_V0PRODUTO_SECTION();

            /*" -1130- PERFORM R0210-00-FETCH-V0PRODUTO UNTIL WFIM-PRODUTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PRODUTO.IsEmpty()))
            {

                R0210_00_FETCH_V0PRODUTO_SECTION();
            }

            /*" -1133- MOVE 9999 TO V0PROD-CODPRODU. */
            _.Move(9999, V0PROD_CODPRODU);

            /*" -1139- PERFORM R0220-00-MOVE-DADOS UNTIL WS-SUBS GREATER 2000. */

            while (!(AREA_DE_WORK.WS_SUBS > 2000))
            {

                R0220_00_MOVE_DADOS_SECTION();
            }

            /*" -1140- MOVE ZEROS TO WSHOST-QTDE. */
            _.Move(0, WSHOST_QTDE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1152- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1159- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1162- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1163- DISPLAY 'BI0075B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"BI0075B - SISTEMA NAO ESTA CADASTRADO");

                /*" -1165- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1166- MOVE V1SIST-DTCURRENT TO WDATA-CURR. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -1167- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1168- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1169- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1171- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -1172- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -1173- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -1174- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -1175- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -1177- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -1178- MOVE V1SIST-DTMOVABE TO WDATA-HOST. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_HOST);

            /*" -1179- MOVE WDATA-AA-HOST TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_18.WDATA_AA_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1180- MOVE WDATA-MM-HOST TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_18.WDATA_MM_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1181- MOVE WDATA-DD-HOST TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_18.WDATA_DD_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1183- MOVE WDATA-CABEC TO LC03-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -1184- MOVE WDATA-DD-CURR TO WDATA-DD-HOST. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_DD_CURR, AREA_DE_WORK.FILLER_18.WDATA_DD_HOST);

            /*" -1185- MOVE WDATA-MM-CURR TO WDATA-MM-HOST. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_MM_CURR, AREA_DE_WORK.FILLER_18.WDATA_MM_HOST);

            /*" -1186- MOVE WDATA-AA-CURR TO WDATA-AA-HOST. */
            _.Move(AREA_DE_WORK.FILLER_11.WDATA_AA_CURR, AREA_DE_WORK.FILLER_18.WDATA_AA_HOST);

            /*" -1186- MOVE WDATA-HOST TO WSSIST-DTMOVABE. */
            _.Move(AREA_DE_WORK.WDATA_HOST, AREA_DE_WORK.WSSIST_DTMOVABE);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1159- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'BI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-MONTA-EMPRESA-SECTION */
        private void R0120_00_MONTA_EMPRESA_SECTION()
        {
            /*" -1200- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1205- PERFORM R0120_00_MONTA_EMPRESA_DB_SELECT_1 */

            R0120_00_MONTA_EMPRESA_DB_SELECT_1();

            /*" -1208- MOVE V1EMPR-NOM-EMP TO LK-TIT */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TIT);

            /*" -1210- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -1211- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -1212- MOVE LK-TIT TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TIT, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -1213- ELSE */
            }
            else
            {


                /*" -1214- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -1214- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0120-00-MONTA-EMPRESA-DB-SELECT-1 */
        public void R0120_00_MONTA_EMPRESA_DB_SELECT_1()
        {
            /*" -1205- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 = new R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1.Execute(r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-SECTION */
        private void R0200_00_DECLARE_V0PRODUTO_SECTION()
        {
            /*" -1227- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1233- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1();

            /*" -1235- PERFORM R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1 */

            R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1();

            /*" -1238- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1239- DISPLAY 'R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ' */
                _.Display($"R0200-00 - PROBLEMAS DECLARE (V0PRODUTO) ");

                /*" -1239- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_DECLARE_1()
        {
            /*" -1233- EXEC SQL DECLARE V0PRODUTO CURSOR FOR SELECT CODPRODU FROM SEGUROS.V0PRODUTO WHERE COD_EMPRESA IN (0, 10, 11) ORDER BY CODPRODU END-EXEC. */
            V0PRODUTO = new BI0075B_V0PRODUTO(false);
            string GetQuery_V0PRODUTO()
            {
                var query = @$"SELECT CODPRODU 
							FROM SEGUROS.V0PRODUTO 
							WHERE COD_EMPRESA IN (0
							, 10
							, 11) 
							ORDER BY CODPRODU";

                return query;
            }
            V0PRODUTO.GetQueryEvent += GetQuery_V0PRODUTO;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V0PRODUTO-DB-OPEN-1 */
        public void R0200_00_DECLARE_V0PRODUTO_DB_OPEN_1()
        {
            /*" -1235- EXEC SQL OPEN V0PRODUTO END-EXEC. */

            V0PRODUTO.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0MOVDEBCC-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1()
        {
            /*" -1395- EXEC SQL DECLARE V0MOVDE CURSOR FOR SELECT A.COD_CONVENIO, A.DTVENCTO, A.DTCREDITO, A.VLR_DEBITO, A.VLR_CREDITO, A.NUM_APOLICE, A.NRENDOS, A.SEQUENCIA, A.NUM_LOTE FROM SEGUROS.V0MOVDEBCC_CEF A WHERE A.SIT_COBRANCA = 'P' AND A.COD_CONVENIO = 102837 AND A.DTCREDITO <= :V1SIST-DTMOVABE ORDER BY A.COD_CONVENIO, A.DTVENCTO , A.NUM_APOLICE END-EXEC. */
            V0MOVDE = new BI0075B_V0MOVDE(true);
            string GetQuery_V0MOVDE()
            {
                var query = @$"SELECT 
							A.COD_CONVENIO
							, 
							A.DTVENCTO
							, 
							A.DTCREDITO
							, 
							A.VLR_DEBITO
							, 
							A.VLR_CREDITO
							, 
							A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.SEQUENCIA
							, 
							A.NUM_LOTE 
							FROM SEGUROS.V0MOVDEBCC_CEF A 
							WHERE A.SIT_COBRANCA = 'P' 
							AND A.COD_CONVENIO = 102837 
							AND A.DTCREDITO <= '{V1SIST_DTMOVABE}' 
							ORDER BY A.COD_CONVENIO
							, 
							A.DTVENCTO
							, 
							A.NUM_APOLICE";

                return query;
            }
            V0MOVDE.GetQueryEvent += GetQuery_V0MOVDE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-SECTION */
        private void R0210_00_FETCH_V0PRODUTO_SECTION()
        {
            /*" -1251- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1253- PERFORM R0210_00_FETCH_V0PRODUTO_DB_FETCH_1 */

            R0210_00_FETCH_V0PRODUTO_DB_FETCH_1();

            /*" -1256- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1256- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1();

                /*" -1258- MOVE 'S' TO WFIM-PRODUTO */
                _.Move("S", AREA_DE_WORK.WFIM_PRODUTO);

                /*" -1260- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1261- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1262- DISPLAY 'R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ' */
                _.Display($"R0210-00 - PROBLEMAS FETCH (V0PRODUTO)   ");

                /*" -1264- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1268- ADD 1 TO LD-PRODUTO. */
            AREA_DE_WORK.LD_PRODUTO.Value = AREA_DE_WORK.LD_PRODUTO + 1;

            /*" -1269- IF LD-PRODUTO GREATER 2000 */

            if (AREA_DE_WORK.LD_PRODUTO > 2000)
            {

                /*" -1269- PERFORM R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2 */

                R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2();

                /*" -1271- DISPLAY 'R0210-00 - ESTOURO TABELA INTERNA PRODUTO' */
                _.Display($"R0210-00 - ESTOURO TABELA INTERNA PRODUTO");

                /*" -1273- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1273- PERFORM R0220-00-MOVE-DADOS. */

            R0220_00_MOVE_DADOS_SECTION();

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-FETCH-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_FETCH_1()
        {
            /*" -1253- EXEC SQL FETCH V0PRODUTO INTO :V0PROD-CODPRODU END-EXEC. */

            if (V0PRODUTO.Fetch())
            {
                _.Move(V0PRODUTO.V0PROD_CODPRODU, V0PROD_CODPRODU);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-1 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_1()
        {
            /*" -1256- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V0PRODUTO-DB-CLOSE-2 */
        public void R0210_00_FETCH_V0PRODUTO_DB_CLOSE_2()
        {
            /*" -1269- EXEC SQL CLOSE V0PRODUTO END-EXEC */

            V0PRODUTO.Close();

        }

        [StopWatch]
        /*" R0220-00-MOVE-DADOS-SECTION */
        private void R0220_00_MOVE_DADOS_SECTION()
        {
            /*" -1285- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1288- MOVE V0PROD-CODPRODU TO WTABG-CODPRODU(WS-PRD). */
            _.Move(V0PROD_CODPRODU, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU);

            /*" -1289- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -1291- PERFORM R0250-00-MOVE-TIPO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0250_00_MOVE_TIPO_SECTION();

            }

            /*" -1292- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

            /*" -1292- SET WS-SUBS TO WS-PRD. */
            AREA_DE_WORK.WS_SUBS.Value = WS_PRD;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-MOVE-TIPO-SECTION */
        private void R0250_00_MOVE_TIPO_SECTION()
        {
            /*" -1304- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1309- SET WS-SUBS1 TO WS-TIP. */
            AREA_DE_WORK.WS_SUBS1.Value = WS_TIP;

            /*" -1310- IF WS-SUBS1 EQUAL 1 */

            if (AREA_DE_WORK.WS_SUBS1 == 1)
            {

                /*" -1312- MOVE 'D' TO WTABG-TIPO(WS-PRD WS-TIP) */
                _.Move("D", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                /*" -1316- ELSE */
            }
            else
            {


                /*" -1317- IF WS-SUBS1 EQUAL 2 */

                if (AREA_DE_WORK.WS_SUBS1 == 2)
                {

                    /*" -1319- MOVE 'R' TO WTABG-TIPO(WS-PRD WS-TIP) */
                    _.Move("R", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);

                    /*" -1323- ELSE */
                }
                else
                {


                    /*" -1326- MOVE 'S' TO WTABG-TIPO(WS-PRD WS-TIP). */
                    _.Move("S", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO);
                }

            }


            /*" -1327- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -1329- PERFORM R0260-00-MOVE-SITUACAO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R0260_00_MOVE_SITUACAO_SECTION();

            }

            /*" -1329- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-MOVE-SITUACAO-SECTION */
        private void R0260_00_MOVE_SITUACAO_SECTION()
        {
            /*" -1342- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1350- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -1354- SET WS-SUBS2 TO WS-SIT. */
            AREA_DE_WORK.WS_SUBS2.Value = WS_SIT;

            /*" -1355- IF WS-SUBS2 EQUAL 1 */

            if (AREA_DE_WORK.WS_SUBS2 == 1)
            {

                /*" -1357- MOVE '0' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) */
                _.Move("0", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);

                /*" -1361- ELSE */
            }
            else
            {


                /*" -1364- MOVE '2' TO WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT). */
                _.Move("2", AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO);
            }


            /*" -1364- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0MOVDEBCC-SECTION */
        private void R0900_00_DECLARE_V0MOVDEBCC_SECTION()
        {
            /*" -1376- MOVE '090' TO WNR-EXEC-SQL */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1395- PERFORM R0900_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1 */

            R0900_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1();

            /*" -1397- PERFORM R0900_00_DECLARE_V0MOVDEBCC_DB_OPEN_1 */

            R0900_00_DECLARE_V0MOVDEBCC_DB_OPEN_1();

            /*" -1400- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1401- DISPLAY 'PROBLEMAS OPEN V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMAS OPEN V0MOVDEBCC_CEF ");

                /*" -1401- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0MOVDEBCC-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0MOVDEBCC_DB_OPEN_1()
        {
            /*" -1397- EXEC SQL OPEN V0MOVDE END-EXEC. */

            V0MOVDE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-LE-V0MOVDEBCC-CEF-SECTION */
        private void R0910_00_LE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1410- MOVE '910' TO WNR-EXEC-SQL. */
            _.Move("910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LE_MOVDEBCC */

            R0910_10_LE_MOVDEBCC();

        }

        [StopWatch]
        /*" R0910-10-LE-MOVDEBCC */
        private void R0910_10_LE_MOVDEBCC(bool isPerform = false)
        {
            /*" -1426- PERFORM R0910_10_LE_MOVDEBCC_DB_FETCH_1 */

            R0910_10_LE_MOVDEBCC_DB_FETCH_1();

            /*" -1429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1430- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1431- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -1431- PERFORM R0910_10_LE_MOVDEBCC_DB_CLOSE_1 */

                    R0910_10_LE_MOVDEBCC_DB_CLOSE_1();

                    /*" -1433- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1434- ELSE */
                }
                else
                {


                    /*" -1435- DISPLAY 'BI0075B - PROBLEMAS NO FETCH V0MVDE ' */
                    _.Display($"BI0075B - PROBLEMAS NO FETCH V0MVDE ");

                    /*" -1436- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1437- ELSE */
                }

            }
            else
            {


                /*" -1437- ADD 1 TO AC-LIDOS. */
                AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            }


        }

        [StopWatch]
        /*" R0910-10-LE-MOVDEBCC-DB-FETCH-1 */
        public void R0910_10_LE_MOVDEBCC_DB_FETCH_1()
        {
            /*" -1426- EXEC SQL FETCH V0MOVDE INTO :V1MVDB-COD-CONVENIO, :V1MVDB-DTVENCTO, :V1MVDB-DTCREDITO, :V1MVDB-VLR-DEBITO, :V1MVDB-VLR-CREDITO, :V1MVDB-NUM-APOLICE, :V1MVDB-NRENDOS, :V1MVDB-SEQUENCIA, :V1MVDB-NUM-LOTE END-EXEC. */

            if (V0MOVDE.Fetch())
            {
                _.Move(V0MOVDE.V1MVDB_COD_CONVENIO, V1MVDB_COD_CONVENIO);
                _.Move(V0MOVDE.V1MVDB_DTVENCTO, V1MVDB_DTVENCTO);
                _.Move(V0MOVDE.V1MVDB_DTCREDITO, V1MVDB_DTCREDITO);
                _.Move(V0MOVDE.V1MVDB_VLR_DEBITO, V1MVDB_VLR_DEBITO);
                _.Move(V0MOVDE.V1MVDB_VLR_CREDITO, V1MVDB_VLR_CREDITO);
                _.Move(V0MOVDE.V1MVDB_NUM_APOLICE, V1MVDB_NUM_APOLICE);
                _.Move(V0MOVDE.V1MVDB_NRENDOS, V1MVDB_NRENDOS);
                _.Move(V0MOVDE.V1MVDB_SEQUENCIA, V1MVDB_SEQUENCIA);
                _.Move(V0MOVDE.V1MVDB_NUM_LOTE, V1MVDB_NUM_LOTE);
            }

        }

        [StopWatch]
        /*" R0910-10-LE-MOVDEBCC-DB-CLOSE-1 */
        public void R0910_10_LE_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -1431- EXEC SQL CLOSE V0MOVDE END-EXEC */

            V0MOVDE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1452- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1453- MOVE V1MVDB-VLR-DEBITO TO WSHOST-VLPRMTOT. */
            _.Move(V1MVDB_VLR_DEBITO, WSHOST_VLPRMTOT);

            /*" -1458- MOVE ZEROS TO WSHOST-CODPRODU WSHOST-VLTARIFA WSHOST-VLBALCAO WSHOST-VLIOCC WSHOST-VLDESCON */
            _.Move(0, WSHOST_CODPRODU, WSHOST_VLTARIFA, WSHOST_VLBALCAO, WSHOST_VLIOCC, WSHOST_VLDESCON);

            /*" -1460- MOVE '0' TO WSHOST-SITUACAO. */
            _.Move("0", WSHOST_SITUACAO);

            /*" -1464- MOVE 0,80 TO WSHOST-VLTARIFA. */
            _.Move(0.80, WSHOST_VLTARIFA);

            /*" -1465- MOVE SPACES TO WFIM-V1BILHETE. */
            _.Move("", AREA_DE_WORK.WFIM_V1BILHETE);

            /*" -1467- MOVE V1MVDB-NUM-APOLICE TO V0BILH-NUMAPOL. */
            _.Move(V1MVDB_NUM_APOLICE, V0BILH_NUMAPOL);

            /*" -1469- PERFORM R1160-00-SELECT-V1BILHETE. */

            R1160_00_SELECT_V1BILHETE_SECTION();

            /*" -1470- IF WFIM-V1BILHETE NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1BILHETE.IsEmpty())
            {

                /*" -1472- GO TO R1000-50-SAIDA. */

                R1000_50_SAIDA(); //GOTO
                return;
            }


            /*" -1474- PERFORM R1170-00-SELECT-CONVERSI. */

            R1170_00_SELECT_CONVERSI_SECTION();

            /*" -1476- MOVE V0CONV-CODPRODU TO WSHOST-CODPRODU. */
            _.Move(V0CONV_CODPRODU, WSHOST_CODPRODU);

            /*" -1481- MOVE V0BILH-NUMAPOL TO WNUMAPOL V1MVDB-NUM-APOLICE. */
            _.Move(V0BILH_NUMAPOL, AREA_DE_WORK.FILLER_26.WNUMAPOL);
            _.Move(V0BILH_NUMAPOL, V1MVDB_NUM_APOLICE);


            /*" -1483- PERFORM R3400-00-MONTA-V0MOVICOB. */

            R3400_00_MONTA_V0MOVICOB_SECTION();

            /*" -1484- MOVE ZEROS TO WVLPENDEN. */
            _.Move(0, AREA_DE_WORK.WVLPENDEN);

            /*" -1488- MOVE ZEROS TO V1MVDB-COD-EMPRESA. */
            _.Move(0, V1MVDB_COD_EMPRESA);

            /*" -1489- PERFORM R4150-00-SELECT-BILCOBER. */

            R4150_00_SELECT_BILCOBER_SECTION();

            /*" -1493- PERFORM R3460-00-UPDATE-V0MOVDEBCC. */

            R3460_00_UPDATE_V0MOVDEBCC_SECTION();

            /*" -1495- PERFORM R3500-00-INSERT-V0MOVICOB. */

            R3500_00_INSERT_V0MOVICOB_SECTION();

            /*" -1496- IF V1MVDB-DTCREDITO GREATER '2011-01-07' */

            if (V1MVDB_DTCREDITO > "2011-01-07")
            {

                /*" -1498- COMPUTE AC-VL-APROVADOS = AC-VL-APROVADOS + V1MVDB-VLR-DEBITO */
                AREA_DE_WORK.AC_VL_APROVADOS.Value = AREA_DE_WORK.AC_VL_APROVADOS + V1MVDB_VLR_DEBITO;

                /*" -1498- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_50_SAIDA */

            R1000_50_SAIDA();

        }

        [StopWatch]
        /*" R1000-50-SAIDA */
        private void R1000_50_SAIDA(bool isPerform = false)
        {
            /*" -1504- PERFORM R8000-00-TRATA-DESPESAS. */

            R8000_00_TRATA_DESPESAS_SECTION();

            /*" -1504- PERFORM R0910-00-LE-V0MOVDEBCC-CEF. */

            R0910_00_LE_V0MOVDEBCC_CEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-SECTION */
        private void R1050_00_SELECT_CONVERSI_SECTION()
        {
            /*" -1516- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1517- MOVE ZEROS TO WS-NRTIT. */
            _.Move(0, AREA_DE_WORK.WS_NRTIT);

            /*" -1518- MOVE WNUMPROP TO WS-NUMTIT. */
            _.Move(AREA_DE_WORK.FILLER_23.WNUMPROP, AREA_DE_WORK.FILLER_27.WS_NUMTIT);

            /*" -1519- MOVE ZEROS TO WS-DIGTIT. */
            _.Move(0, AREA_DE_WORK.FILLER_27.WS_DIGTIT);

            /*" -1521- MOVE WS-NRTIT TO WSHOST-NUMSIV01. */
            _.Move(AREA_DE_WORK.WS_NRTIT, WSHOST_NUMSIV01);

            /*" -1522- MOVE 9 TO WS-DIGTIT. */
            _.Move(9, AREA_DE_WORK.FILLER_27.WS_DIGTIT);

            /*" -1524- MOVE WS-NRTIT TO WSHOST-NUMSIV02. */
            _.Move(AREA_DE_WORK.WS_NRTIT, WSHOST_NUMSIV02);

            /*" -1526- MOVE 'S' TO WTEM-CONVERSI. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSI);

            /*" -1541- PERFORM R1050_00_SELECT_CONVERSI_DB_SELECT_1 */

            R1050_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -1544- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1545- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1546- MOVE 'N' TO WTEM-CONVERSI */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSI);

                    /*" -1547- ELSE */
                }
                else
                {


                    /*" -1548- DISPLAY 'R1050-00 - PROBLEMAS ACESSO (PROPFID)' */
                    _.Display($"R1050-00 - PROBLEMAS ACESSO (PROPFID)");

                    /*" -1550- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1551- MOVE V0PRFD-ORIGEM-PROPOSTA TO W-ORIGEM-PROPOSTA. */
            _.Move(V0PRFD_ORIGEM_PROPOSTA, AREA_DE_WORK.W_ORIGEM_PROPOSTA);

        }

        [StopWatch]
        /*" R1050-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R1050_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -1541- EXEC SQL SELECT A.NUM_PROPOSTA_SIVPF , A.COD_PRODUTO_SIVPF , B.NUM_SICOB , B.ORIGEM_PROPOSTA INTO :V0PRFD-NUMPROPOSTA , :V0PRFD-CODPROD , :V0PRFD-NUMSICOB , :V0PRFD-ORIGEM-PROPOSTA FROM SEGUROS.CONVERSAO_SICOB A, SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_PROPOSTA_SIVPF >= :WSHOST-NUMSIV01 AND A.NUM_PROPOSTA_SIVPF <= :WSHOST-NUMSIV02 AND A.NUM_PROPOSTA_SIVPF = B.NUM_PROPOSTA_SIVPF WITH UR END-EXEC. */

            var r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
                WSHOST_NUMSIV02 = WSHOST_NUMSIV02.ToString(),
            };

            var executed_1 = R1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRFD_NUMPROPOSTA, V0PRFD_NUMPROPOSTA);
                _.Move(executed_1.V0PRFD_CODPROD, V0PRFD_CODPROD);
                _.Move(executed_1.V0PRFD_NUMSICOB, V0PRFD_NUMSICOB);
                _.Move(executed_1.V0PRFD_ORIGEM_PROPOSTA, V0PRFD_ORIGEM_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1160-00-SELECT-V1BILHETE-SECTION */
        private void R1160_00_SELECT_V1BILHETE_SECTION()
        {
            /*" -1563- MOVE '116' TO WNR-EXEC-SQL. */
            _.Move("116", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1596- PERFORM R1160_00_SELECT_V1BILHETE_DB_SELECT_1 */

            R1160_00_SELECT_V1BILHETE_DB_SELECT_1();

            /*" -1599- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1600- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1601- MOVE 'S' TO WFIM-V1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIM_V1BILHETE);

                    /*" -1602- ELSE */
                }
                else
                {


                    /*" -1603- DISPLAY 'BI0075B - PROBLEMAS SELECT V1BILHETE ' */
                    _.Display($"BI0075B - PROBLEMAS SELECT V1BILHETE ");

                    /*" -1604- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                    _.Display($"BILHETE {V0BILH_NUMBIL}");

                    /*" -1604- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1160-00-SELECT-V1BILHETE-DB-SELECT-1 */
        public void R1160_00_SELECT_V1BILHETE_DB_SELECT_1()
        {
            /*" -1596- EXEC SQL SELECT NUMBIL , NUM_APOLICE, CODCLIEN , AGECOBR , RAMO , OPC_COBERTURA, NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB INTO :V0BILH-NUMBIL , :V0BILH-NUMAPOL , :V0BILH-CODCLIEN , :V0BILH-AGECOBR , :V0BILH-RAMO , :V0BILH-OPCAO-COB , :V0BILH-NRMATRVEN , :V0BILH-AGECTAVEN , :V0BILH-OPRCTAVEN , :V0BILH-NUMCTAVEN , :V0BILH-DIGCTAVEN , :V0BILH-AGECTADEB , :V0BILH-OPRCTADEB , :V0BILH-NUMCTADEB , :V0BILH-DIGCTADEB FROM SEGUROS.V0BILHETE WHERE NUM_APOLICE = :V0BILH-NUMAPOL END-EXEC. */

            var r1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1 = new R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1()
            {
                V0BILH_NUMAPOL = V0BILH_NUMAPOL.ToString(),
            };

            var executed_1 = R1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1.Execute(r1160_00_SELECT_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BILH_NUMBIL, V0BILH_NUMBIL);
                _.Move(executed_1.V0BILH_NUMAPOL, V0BILH_NUMAPOL);
                _.Move(executed_1.V0BILH_CODCLIEN, V0BILH_CODCLIEN);
                _.Move(executed_1.V0BILH_AGECOBR, V0BILH_AGECOBR);
                _.Move(executed_1.V0BILH_RAMO, V0BILH_RAMO);
                _.Move(executed_1.V0BILH_OPCAO_COB, V0BILH_OPCAO_COB);
                _.Move(executed_1.V0BILH_NRMATRVEN, V0BILH_NRMATRVEN);
                _.Move(executed_1.V0BILH_AGECTAVEN, V0BILH_AGECTAVEN);
                _.Move(executed_1.V0BILH_OPRCTAVEN, V0BILH_OPRCTAVEN);
                _.Move(executed_1.V0BILH_NUMCTAVEN, V0BILH_NUMCTAVEN);
                _.Move(executed_1.V0BILH_DIGCTAVEN, V0BILH_DIGCTAVEN);
                _.Move(executed_1.V0BILH_AGECTADEB, V0BILH_AGECTADEB);
                _.Move(executed_1.V0BILH_OPRCTADEB, V0BILH_OPRCTADEB);
                _.Move(executed_1.V0BILH_NUMCTADEB, V0BILH_NUMCTADEB);
                _.Move(executed_1.V0BILH_DIGCTADEB, V0BILH_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1160_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-SELECT-CONVERSI-SECTION */
        private void R1170_00_SELECT_CONVERSI_SECTION()
        {
            /*" -1615- MOVE '1170' TO WNR-EXEC-SQL. */
            _.Move("1170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1617- MOVE V0BILH-NUMBIL TO V0CONV-NUMSICOB. */
            _.Move(V0BILH_NUMBIL, V0CONV_NUMSICOB);

            /*" -1623- PERFORM R1170_00_SELECT_CONVERSI_DB_SELECT_1 */

            R1170_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -1626- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1627- DISPLAY 'R1170-00 - PROBLEMAS ACESSO (CONVERSI)' */
                _.Display($"R1170-00 - PROBLEMAS ACESSO (CONVERSI)");

                /*" -1627- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1170-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R1170_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -1623- EXEC SQL SELECT COD_PRODUTO_SIVPF INTO :V0CONV-CODPRODU FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :V0CONV-NUMSICOB WITH UR END-EXEC. */

            var r1170_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R1170_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                V0CONV_NUMSICOB = V0CONV_NUMSICOB.ToString(),
            };

            var executed_1 = R1170_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r1170_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODPRODU, V0CONV_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/

        [StopWatch]
        /*" R1440-00-CANCELA-BILHETE-SECTION */
        private void R1440_00_CANCELA_BILHETE_SECTION()
        {
            /*" -1639- MOVE '144' TO WNR-EXEC-SQL. */
            _.Move("144", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1641- MOVE '8' TO V0BILH-SITUACAO. */
            _.Move("8", V0BILH_SITUACAO);

            /*" -1650- PERFORM R1440_00_CANCELA_BILHETE_DB_UPDATE_1 */

            R1440_00_CANCELA_BILHETE_DB_UPDATE_1();

            /*" -1653- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1653- ADD 1 TO AC-C-V0BILHETE. */
                AREA_DE_WORK.AC_C_V0BILHETE.Value = AREA_DE_WORK.AC_C_V0BILHETE + 1;
            }


        }

        [StopWatch]
        /*" R1440-00-CANCELA-BILHETE-DB-UPDATE-1 */
        public void R1440_00_CANCELA_BILHETE_DB_UPDATE_1()
        {
            /*" -1650- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, TIP_CANCELAMENTO = '3' , DTCANCEL = :V1SIST-DTMOVABE, COD_USUARIO = 'BI0075B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 = new R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1.Execute(r1440_00_CANCELA_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1440_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-UPDATE-V0MOVDEBCC-SECTION */
        private void R1450_00_UPDATE_V0MOVDEBCC_SECTION()
        {
            /*" -1665- MOVE '145' TO WNR-EXEC-SQL. */
            _.Move("145", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1667- MOVE '6' TO V1MVDB-SIT-COBRANCA. */
            _.Move("6", V1MVDB_SIT_COBRANCA);

            /*" -1674- PERFORM R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1 */

            R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1();

            /*" -1677- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1677- ADD 1 TO AC-S-V0MOVDEBCC. */
                AREA_DE_WORK.AC_S_V0MOVDEBCC.Value = AREA_DE_WORK.AC_S_V0MOVDEBCC + 1;
            }


        }

        [StopWatch]
        /*" R1450-00-UPDATE-V0MOVDEBCC-DB-UPDATE-1 */
        public void R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1()
        {
            /*" -1674- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = :V1MVDB-SIT-COBRANCA WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS > :V1MVDB-NRENDOS AND NRPARCEL = :V1MVDB-NRPARCEL AND COD_CONVENIO = :V1MVDB-COD-CONVENIO END-EXEC. */

            var r1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 = new R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1()
            {
                V1MVDB_SIT_COBRANCA = V1MVDB_SIT_COBRANCA.ToString(),
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRPARCEL = V1MVDB_NRPARCEL.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            R1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1.Execute(r1450_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1460-00-CANCELA-ENDOSSO-SECTION */
        private void R1460_00_CANCELA_ENDOSSO_SECTION()
        {
            /*" -1688- MOVE '146' TO WNR-EXEC-SQL. */
            _.Move("146", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1694- PERFORM R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1 */

            R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1();

            /*" -1697- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1698- DISPLAY 'R1460 - ERRO NO UPDATE DA V0ENDOSSO' */
                _.Display($"R1460 - ERRO NO UPDATE DA V0ENDOSSO");

                /*" -1699- DISPLAY 'APOLICE - ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE - {V1MVDB_NUM_APOLICE}");

                /*" -1700- DISPLAY 'ENDOSSO - ' V1MVDB-NRENDOS */
                _.Display($"ENDOSSO - {V1MVDB_NRENDOS}");

                /*" -1701- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1702- ELSE */
            }
            else
            {


                /*" -1702- ADD 1 TO AC-C-V0ENDOSSO. */
                AREA_DE_WORK.AC_C_V0ENDOSSO.Value = AREA_DE_WORK.AC_C_V0ENDOSSO + 1;
            }


        }

        [StopWatch]
        /*" R1460-00-CANCELA-ENDOSSO-DB-UPDATE-1 */
        public void R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1()
        {
            /*" -1694- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS = :V1MVDB-NRENDOS END-EXEC. */

            var r1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 = new R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1.Execute(r1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-FINAL-SECTION */
        private void R2000_00_PROCESSA_FINAL_SECTION()
        {
            /*" -1716- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1718- COMPUTE AC-QT-TOTAL = AC-QT-APROVADOS + AC-QT-REJEITADOS. */
            AREA_DE_WORK.AC_QT_TOTAL.Value = AREA_DE_WORK.AC_QT_APROVADOS + AREA_DE_WORK.AC_QT_REJEITADOS;

            /*" -1721- COMPUTE AC-VL-TOTAL = AC-VL-APROVADOS + AC-VL-REJEITADOS. */
            AREA_DE_WORK.AC_VL_TOTAL.Value = AREA_DE_WORK.AC_VL_APROVADOS + AREA_DE_WORK.AC_VL_REJEITADOS;

            /*" -1721- PERFORM R2050-00-TRATA-DEBCRE. */

            R2050_00_TRATA_DEBCRE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-TRATA-DEBCRE-SECTION */
        private void R2050_00_TRATA_DEBCRE_SECTION()
        {
            /*" -1735- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1738- COMPUTE V0AVIS-VLDESPES EQUAL AC-LIDOS * 0,00. */
            V0AVIS_VLDESPES.Value = AREA_DE_WORK.AC_LIDOS * 0.00;

            /*" -1740- COMPUTE V0AVIS-VLPRMTOT = AC-VL-APROVADOS. */
            V0AVIS_VLPRMTOT.Value = AREA_DE_WORK.AC_VL_APROVADOS;

            /*" -1743- COMPUTE V0AVIS-VLPRMLIQ EQUAL V0AVIS-VLPRMTOT - V0AVIS-VLDESPES. */
            V0AVIS_VLPRMLIQ.Value = V0AVIS_VLPRMTOT - V0AVIS_VLDESPES;

            /*" -1745- PERFORM R2200-00-INSERT-V0AVISOCRED. */

            R2200_00_INSERT_V0AVISOCRED_SECTION();

            /*" -1746- PERFORM R2300-00-MONTA-AVISOSALDO. */

            R2300_00_MONTA_AVISOSALDO_SECTION();

            /*" -1748- PERFORM R2400-00-INSERT-V0AVISOSALDO. */

            R2400_00_INSERT_V0AVISOSALDO_SECTION();

            /*" -1752- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -1752- PERFORM R8500-00-GRAVA-DESPESAS 2000 TIMES. */

            for (int i = 0; i < 2000; i++)
            {

                R8500_00_GRAVA_DESPESAS_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MONTA-AVISOCRED-SECTION */
        private void R2100_00_MONTA_AVISOCRED_SECTION()
        {
            /*" -1765- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1767- MOVE 104 TO V0AVIS-BCOAVISO. */
            _.Move(104, V0AVIS_BCOAVISO);

            /*" -1768- MOVE 9777 TO V0AVIS-AGEAVISO. */
            _.Move(9777, V0AVIS_AGEAVISO);

            /*" -1771- PERFORM R2110-00-SELECT-AVISOCRE */

            R2110_00_SELECT_AVISOCRE_SECTION();

            /*" -1772- MOVE 1 TO V0AVIS-NRSEQ. */
            _.Move(1, V0AVIS_NRSEQ);

            /*" -1773- MOVE V1SIST-DTMOVABE TO V0AVIS-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0AVIS_DTMOVTO);

            /*" -1774- MOVE 100 TO V0AVIS-OPERACAO. */
            _.Move(100, V0AVIS_OPERACAO);

            /*" -1776- MOVE 'C' TO V0AVIS-TIPAVI. */
            _.Move("C", V0AVIS_TIPAVI);

            /*" -1778- MOVE V1SIST-DTMOVABE TO V0AVIS-DTAVISO. */
            _.Move(V1SIST_DTMOVABE, V0AVIS_DTAVISO);

            /*" -1779- MOVE ZEROS TO V0AVIS-VLIOCC. */
            _.Move(0, V0AVIS_VLIOCC);

            /*" -1780- MOVE ZEROS TO V0AVIS-VLDESPES. */
            _.Move(0, V0AVIS_VLDESPES);

            /*" -1782- MOVE ZEROS TO V0AVIS-PRECED. */
            _.Move(0, V0AVIS_PRECED);

            /*" -1783- MOVE '0' TO V0AVIS-SITCONTB. */
            _.Move("0", V0AVIS_SITCONTB);

            /*" -1784- MOVE ZEROS TO V0AVIS-COD-EMPRESA */
            _.Move(0, V0AVIS_COD_EMPRESA);

            /*" -1785- MOVE 2 TO V0AVIS-ORIGAVISO. */
            _.Move(2, V0AVIS_ORIGAVISO);

            /*" -1787- MOVE ZEROS TO V0AVIS-VALADT. */
            _.Move(0, V0AVIS_VALADT);

            /*" -1787- MOVE 'P' TO V0AVIS-SITDEPTER. */
            _.Move("P", V0AVIS_SITDEPTER);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-SELECT-AVISOCRE-SECTION */
        private void R2110_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -1798- MOVE '2110' TO WNR-EXEC-SQL. */
            _.Move("2110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1807- PERFORM R2110_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R2110_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -1811- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1813- MOVE 902800001 TO V0AVIS-NRAVISO */
                _.Move(902800001, V0AVIS_NRAVISO);

                /*" -1814- ELSE */
            }
            else
            {


                /*" -1815- IF VIND-NRAVISO LESS ZEROS */

                if (VIND_NRAVISO < 00)
                {

                    /*" -1817- MOVE 902800001 TO V0AVIS-NRAVISO */
                    _.Move(902800001, V0AVIS_NRAVISO);

                    /*" -1818- ELSE */
                }
                else
                {


                    /*" -1825- ADD 1 TO V0AVIS-NRAVISO. */
                    V0AVIS_NRAVISO.Value = V0AVIS_NRAVISO + 1;
                }

            }


            /*" -1826- IF V0AVIS-NRAVISO GREATER 902899900 */

            if (V0AVIS_NRAVISO > 902899900)
            {

                /*" -1830- DISPLAY 'R2110-00 - ALERTA AVISO ESGOTANDO       ' 'BCOAVISO   ' V0AVIS-BCOAVISO 'AGEAVISO   ' V0AVIS-AGEAVISO 'NRAVISO    ' V0AVIS-NRAVISO */

                $"R2110-00 - ALERTA AVISO ESGOTANDO       BCOAVISO   {V0AVIS_BCOAVISO}AGEAVISO   {V0AVIS_AGEAVISO}NRAVISO    {V0AVIS_NRAVISO}"
                .Display();

                /*" -1831- ELSE */
            }
            else
            {


                /*" -1832- IF V0AVIS-NRAVISO GREATER 902899999 */

                if (V0AVIS_NRAVISO > 902899999)
                {

                    /*" -1836- DISPLAY 'R2110-00 -  AVISO ESGOTADO        ' 'BCOAVISO   ' V0AVIS-BCOAVISO 'AGEAVISO   ' V0AVIS-AGEAVISO 'NRAVISO    ' V0AVIS-NRAVISO */

                    $"R2110-00 -  AVISO ESGOTADO        BCOAVISO   {V0AVIS_BCOAVISO}AGEAVISO   {V0AVIS_AGEAVISO}NRAVISO    {V0AVIS_NRAVISO}"
                    .Display();

                    /*" -1836- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2110-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R2110_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -1807- EXEC SQL SELECT MAX(NUM_AVISO_CREDITO) INTO :V0AVIS-NRAVISO:VIND-NRAVISO FROM SEGUROS.AVISO_CREDITO WHERE BCO_AVISO = :V0AVIS-BCOAVISO AND AGE_AVISO = :V0AVIS-AGEAVISO AND NUM_AVISO_CREDITO >= 902800000 AND NUM_AVISO_CREDITO <= 902899998 WITH UR END-EXEC. */

            var r2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
            };

            var executed_1 = R2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r2110_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0AVIS_NRAVISO, V0AVIS_NRAVISO);
                _.Move(executed_1.VIND_NRAVISO, VIND_NRAVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-INSERT-V0AVISOCRED-SECTION */
        private void R2200_00_INSERT_V0AVISOCRED_SECTION()
        {
            /*" -1849- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1869- PERFORM R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1 */

            R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1();

            /*" -1872- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1873- DISPLAY 'BI0075B - PROBLEMAS INSERT V0AVISOCRED' */
                _.Display($"BI0075B - PROBLEMAS INSERT V0AVISOCRED");

                /*" -1874- DISPLAY 'BCOAVISO ' V0AVIS-BCOAVISO */
                _.Display($"BCOAVISO {V0AVIS_BCOAVISO}");

                /*" -1875- DISPLAY 'AGEAVISO ' V0AVIS-AGEAVISO */
                _.Display($"AGEAVISO {V0AVIS_AGEAVISO}");

                /*" -1876- DISPLAY 'NRAVISO  ' V0AVIS-NRAVISO */
                _.Display($"NRAVISO  {V0AVIS_NRAVISO}");

                /*" -1877- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1878- ELSE */
            }
            else
            {


                /*" -1878- ADD 1 TO AC-I-V0AVISOCRED. */
                AREA_DE_WORK.AC_I_V0AVISOCRED.Value = AREA_DE_WORK.AC_I_V0AVISOCRED + 1;
            }


        }

        [StopWatch]
        /*" R2200-00-INSERT-V0AVISOCRED-DB-INSERT-1 */
        public void R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1()
        {
            /*" -1869- EXEC SQL INSERT INTO SEGUROS.V0AVISOCRED VALUES (:V0AVIS-BCOAVISO , :V0AVIS-AGEAVISO , :V0AVIS-NRAVISO , :V0AVIS-NRSEQ , :V0AVIS-DTMOVTO , :V0AVIS-OPERACAO , :V0AVIS-TIPAVI , :V0AVIS-DTAVISO , :V0AVIS-VLIOCC , :V0AVIS-VLDESPES , :V0AVIS-PRECED , :V0AVIS-VLPRMLIQ , :V0AVIS-VLPRMTOT , :V0AVIS-SITCONTB , :V0AVIS-COD-EMPRESA , CURRENT TIMESTAMP , :V0AVIS-ORIGAVISO , :V0AVIS-VALADT , :V0AVIS-SITDEPTER) END-EXEC. */

            var r2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1 = new R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1()
            {
                V0AVIS_BCOAVISO = V0AVIS_BCOAVISO.ToString(),
                V0AVIS_AGEAVISO = V0AVIS_AGEAVISO.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V0AVIS_NRSEQ = V0AVIS_NRSEQ.ToString(),
                V0AVIS_DTMOVTO = V0AVIS_DTMOVTO.ToString(),
                V0AVIS_OPERACAO = V0AVIS_OPERACAO.ToString(),
                V0AVIS_TIPAVI = V0AVIS_TIPAVI.ToString(),
                V0AVIS_DTAVISO = V0AVIS_DTAVISO.ToString(),
                V0AVIS_VLIOCC = V0AVIS_VLIOCC.ToString(),
                V0AVIS_VLDESPES = V0AVIS_VLDESPES.ToString(),
                V0AVIS_PRECED = V0AVIS_PRECED.ToString(),
                V0AVIS_VLPRMLIQ = V0AVIS_VLPRMLIQ.ToString(),
                V0AVIS_VLPRMTOT = V0AVIS_VLPRMTOT.ToString(),
                V0AVIS_SITCONTB = V0AVIS_SITCONTB.ToString(),
                V0AVIS_COD_EMPRESA = V0AVIS_COD_EMPRESA.ToString(),
                V0AVIS_ORIGAVISO = V0AVIS_ORIGAVISO.ToString(),
                V0AVIS_VALADT = V0AVIS_VALADT.ToString(),
                V0AVIS_SITDEPTER = V0AVIS_SITDEPTER.ToString(),
            };

            R2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1.Execute(r2200_00_INSERT_V0AVISOCRED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-MONTA-AVISOSALDO-SECTION */
        private void R2300_00_MONTA_AVISOSALDO_SECTION()
        {
            /*" -1890- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1891- MOVE ZEROS TO V0AVSD-COD-EMPRESA */
            _.Move(0, V0AVSD_COD_EMPRESA);

            /*" -1892- MOVE V0AVIS-BCOAVISO TO V0AVSD-BCOAVISO. */
            _.Move(V0AVIS_BCOAVISO, V0AVSD_BCOAVISO);

            /*" -1893- MOVE V0AVIS-AGEAVISO TO V0AVSD-AGEAVISO. */
            _.Move(V0AVIS_AGEAVISO, V0AVSD_AGEAVISO);

            /*" -1894- MOVE V0AVIS-NRAVISO TO V0AVSD-NRAVISO. */
            _.Move(V0AVIS_NRAVISO, V0AVSD_NRAVISO);

            /*" -1896- MOVE '1' TO V0AVSD-TIPSGU. */
            _.Move("1", V0AVSD_TIPSGU);

            /*" -1898- MOVE V1SIST-DTMOVABE TO V0AVSD-DTAVISO. */
            _.Move(V1SIST_DTMOVABE, V0AVSD_DTAVISO);

            /*" -1899- MOVE V1SIST-DTMOVABE TO V0AVSD-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0AVSD_DTMOVTO);

            /*" -1900- MOVE V0AVIS-VLPRMTOT TO V0AVSD-SDOATU. */
            _.Move(V0AVIS_VLPRMTOT, V0AVSD_SDOATU);

            /*" -1902- MOVE '0' TO V0AVSD-SITUACAO. */
            _.Move("0", V0AVSD_SITUACAO);

            /*" -1903- IF V0AVIS-TIPAVI EQUAL 'D' */

            if (V0AVIS_TIPAVI == "D")
            {

                /*" -1903- MOVE ZEROS TO V0AVSD-SDOATU. */
                _.Move(0, V0AVSD_SDOATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-INSERT-V0AVISOSALDO-SECTION */
        private void R2400_00_INSERT_V0AVISOSALDO_SECTION()
        {
            /*" -1916- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1927- PERFORM R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1 */

            R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1();

            /*" -1930- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1931- DISPLAY 'BI0075B - PROBLEMAS INSERT V0AVISOSALDO' */
                _.Display($"BI0075B - PROBLEMAS INSERT V0AVISOSALDO");

                /*" -1932- DISPLAY 'BCOAVISO ' V0AVSD-BCOAVISO */
                _.Display($"BCOAVISO {V0AVSD_BCOAVISO}");

                /*" -1933- DISPLAY 'AGEAVISO ' V0AVSD-AGEAVISO */
                _.Display($"AGEAVISO {V0AVSD_AGEAVISO}");

                /*" -1934- DISPLAY 'NRAVISO  ' V0AVSD-NRAVISO */
                _.Display($"NRAVISO  {V0AVSD_NRAVISO}");

                /*" -1935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1936- ELSE */
            }
            else
            {


                /*" -1936- ADD 1 TO AC-I-V0AVISOSAL. */
                AREA_DE_WORK.AC_I_V0AVISOSAL.Value = AREA_DE_WORK.AC_I_V0AVISOSAL + 1;
            }


        }

        [StopWatch]
        /*" R2400-00-INSERT-V0AVISOSALDO-DB-INSERT-1 */
        public void R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1()
        {
            /*" -1927- EXEC SQL INSERT INTO SEGUROS.V0AVISOS_SALDOS VALUES(:V0AVSD-COD-EMPRESA , :V0AVSD-BCOAVISO , :V0AVSD-AGEAVISO , :V0AVSD-TIPSGU , :V0AVSD-NRAVISO , :V0AVSD-DTAVISO , :V0AVSD-DTMOVTO , :V0AVSD-SDOATU , :V0AVSD-SITUACAO , CURRENT TIMESTAMP) END-EXEC. */

            var r2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1 = new R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1()
            {
                V0AVSD_COD_EMPRESA = V0AVSD_COD_EMPRESA.ToString(),
                V0AVSD_BCOAVISO = V0AVSD_BCOAVISO.ToString(),
                V0AVSD_AGEAVISO = V0AVSD_AGEAVISO.ToString(),
                V0AVSD_TIPSGU = V0AVSD_TIPSGU.ToString(),
                V0AVSD_NRAVISO = V0AVSD_NRAVISO.ToString(),
                V0AVSD_DTAVISO = V0AVSD_DTAVISO.ToString(),
                V0AVSD_DTMOVTO = V0AVSD_DTMOVTO.ToString(),
                V0AVSD_SDOATU = V0AVSD_SDOATU.ToString(),
                V0AVSD_SITUACAO = V0AVSD_SITUACAO.ToString(),
            };

            R2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1.Execute(r2400_00_INSERT_V0AVISOSALDO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-MONTA-V0MOVICOB-SECTION */
        private void R3400_00_MONTA_V0MOVICOB_SECTION()
        {
            /*" -1947- MOVE '3400' TO WNR-EXEC-SQL. */
            _.Move("3400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1948- MOVE ZEROS TO V0MCOB-CODEMP */
            _.Move(0, V0MCOB_CODEMP);

            /*" -1949- MOVE ZEROS TO V0MCOB-CODMOV */
            _.Move(0, V0MCOB_CODMOV);

            /*" -1951- MOVE 104 TO V0MCOB-BANCO */
            _.Move(104, V0MCOB_BANCO);

            /*" -1952- MOVE 9777 TO V0MCOB-AGENCIA */
            _.Move(9777, V0MCOB_AGENCIA);

            /*" -1954- MOVE V0AVIS-NRAVISO TO V0MCOB-NRAVISO */
            _.Move(V0AVIS_NRAVISO, V0MCOB_NRAVISO);

            /*" -1955- MOVE V1MVDB-SEQUENCIA TO V0MCOB-NUMFITA */
            _.Move(V1MVDB_SEQUENCIA, V0MCOB_NUMFITA);

            /*" -1956- MOVE V1SIST-DTMOVABE TO V0MCOB-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0MCOB_DTMOVTO);

            /*" -1957- MOVE ZEROS TO V0MCOB-NRTIT */
            _.Move(0, V0MCOB_NRTIT);

            /*" -1958- MOVE V1MVDB-NUM-APOLICE TO V0MCOB-NUMAPOL */
            _.Move(V1MVDB_NUM_APOLICE, V0MCOB_NUMAPOL);

            /*" -1959- MOVE V1MVDB-NRENDOS TO V0MCOB-NRENDOS */
            _.Move(V1MVDB_NRENDOS, V0MCOB_NRENDOS);

            /*" -1960- MOVE V1MVDB-NRPARCEL TO V0MCOB-NRPARCEL */
            _.Move(V1MVDB_NRPARCEL, V0MCOB_NRPARCEL);

            /*" -1961- MOVE V1MVDB-VLR-DEBITO TO V0MCOB-VALTIT */
            _.Move(V1MVDB_VLR_DEBITO, V0MCOB_VALTIT);

            /*" -1962- MOVE ZEROS TO V0MCOB-VLIOCC */
            _.Move(0, V0MCOB_VLIOCC);

            /*" -1963- MOVE 0,80 TO V0MCOB-VALCDT */
            _.Move(0.80, V0MCOB_VALCDT);

            /*" -1964- MOVE SPACES TO V0MCOB-SITUACAO */
            _.Move("", V0MCOB_SITUACAO);

            /*" -1965- MOVE SPACES TO V0MCOB-NOME */
            _.Move("", V0MCOB_NOME);

            /*" -1967- MOVE '1' TO V0MCOB-TIPOMOV. */
            _.Move("1", V0MCOB_TIPOMOV);

            /*" -1970- COMPUTE V0MCOB-VALCDT EQUAL V0MCOB-VALTIT - V0MCOB-VALCDT. */
            V0MCOB_VALCDT.Value = V0MCOB_VALTIT - V0MCOB_VALCDT;

            /*" -1970- MOVE V1MVDB-DTCREDITO TO V0MCOB-DTQITBCO. */
            _.Move(V1MVDB_DTCREDITO, V0MCOB_DTQITBCO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3460-00-UPDATE-V0MOVDEBCC-SECTION */
        private void R3460_00_UPDATE_V0MOVDEBCC_SECTION()
        {
            /*" -1981- MOVE '3460' TO WNR-EXEC-SQL. */
            _.Move("3460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1983- MOVE '2' TO V1MVDB-SIT-COBRANCA. */
            _.Move("2", V1MVDB_SIT_COBRANCA);

            /*" -1992- PERFORM R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1 */

            R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1();

            /*" -1995- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1996- DISPLAY 'BI0075B - PROBLEMAS UPDATE V0MOVDEBCC_CEF' */
                _.Display($"BI0075B - PROBLEMAS UPDATE V0MOVDEBCC_CEF");

                /*" -1997- DISPLAY 'APOLICE ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE {V1MVDB_NUM_APOLICE}");

                /*" -1998- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1999- ELSE */
            }
            else
            {


                /*" -2075- ADD 1 TO AC-U-V0MOVDEBCC. */
                AREA_DE_WORK.AC_U_V0MOVDEBCC.Value = AREA_DE_WORK.AC_U_V0MOVDEBCC + 1;
            }


            /*" -2077- IF V0PRFD-CODPROD EQUAL 8124 OR 8132 NEXT SENTENCE */

            if (V0PRFD_CODPROD.In("8124", "8132"))
            {

                /*" -2078- ELSE */
            }
            else
            {


                /*" -2084- DIVIDE V1MVDB-NRENDOS BY 12 GIVING WS-RESULT REMAINDER WS-RESTO */
                _.Divide(V1MVDB_NRENDOS, 12, AREA_DE_WORK.WS_RESULT, AREA_DE_WORK.WS_RESTO);

                /*" -2086- IF WS-RESTO EQUAL 3 AND BILCOBER-VAL-MAX-COBER-BAS GREATER ZEROES */

                if (AREA_DE_WORK.WS_RESTO == 3 && BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS > 00)
                {

                    /*" -2086- PERFORM R4100-00-TRATA-FC0105S. */

                    R4100_00_TRATA_FC0105S_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3460-00-UPDATE-V0MOVDEBCC-DB-UPDATE-1 */
        public void R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1()
        {
            /*" -1992- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = :V1MVDB-SIT-COBRANCA, COD_USUARIO = 'BI0075B' , TIMESTAMP = CURRENT TIMESTAMP, NUM_LOTE = :V0AVIS-NRAVISO WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS = :V1MVDB-NRENDOS AND COD_CONVENIO = :V1MVDB-COD-CONVENIO END-EXEC. */

            var r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 = new R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1()
            {
                V1MVDB_SIT_COBRANCA = V1MVDB_SIT_COBRANCA.ToString(),
                V0AVIS_NRAVISO = V0AVIS_NRAVISO.ToString(),
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1.Execute(r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3460_99_SAIDA*/

        [StopWatch]
        /*" R3465-00-SELECT-V1MOVDEBCC-SECTION */
        private void R3465_00_SELECT_V1MOVDEBCC_SECTION()
        {
            /*" -2099- MOVE '3465' TO WNR-EXEC-SQL. */
            _.Move("3465", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2100- MOVE 'N' TO WS-CANCBIL. */
            _.Move("N", AREA_DE_WORK.WS_CANCBIL);

            /*" -2102- MOVE ZEROS TO WS-QTDBIL. */
            _.Move(0, AREA_DE_WORK.WS_QTDBIL);

            /*" -2111- PERFORM R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1 */

            R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1();

            /*" -2114- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2115- DISPLAY 'BI0075B - PROBLEMAS SELECT V1MOVDEBCC_CEF ' */
                _.Display($"BI0075B - PROBLEMAS SELECT V1MOVDEBCC_CEF ");

                /*" -2116- DISPLAY 'APOLICE ' V1MVDB-NUM-APOLICE */
                _.Display($"APOLICE {V1MVDB_NUM_APOLICE}");

                /*" -2118- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2119- IF WS-QTDBIL GREATER 2 */

            if (AREA_DE_WORK.WS_QTDBIL > 2)
            {

                /*" -2119- MOVE 'S' TO WS-CANCBIL. */
                _.Move("S", AREA_DE_WORK.WS_CANCBIL);
            }


        }

        [StopWatch]
        /*" R3465-00-SELECT-V1MOVDEBCC-DB-SELECT-1 */
        public void R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1()
        {
            /*" -2111- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-QTDBIL FROM SEGUROS.V1MOVDEBCC_CEF WHERE NUM_APOLICE = :V1MVDB-NUM-APOLICE AND NRENDOS <= :V1MVDB-NRENDOS AND COD_CONVENIO = :V1MVDB-COD-CONVENIO AND SIT_COBRANCA = '3' WITH UR END-EXEC. */

            var r3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1 = new R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1()
            {
                V1MVDB_COD_CONVENIO = V1MVDB_COD_CONVENIO.ToString(),
                V1MVDB_NUM_APOLICE = V1MVDB_NUM_APOLICE.ToString(),
                V1MVDB_NRENDOS = V1MVDB_NRENDOS.ToString(),
            };

            var executed_1 = R3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1.Execute(r3465_00_SELECT_V1MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTDBIL, AREA_DE_WORK.WS_QTDBIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3465_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-V0MOVICOB-SECTION */
        private void R3500_00_INSERT_V0MOVICOB_SECTION()
        {
            /*" -2131- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2173- PERFORM R3500_00_INSERT_V0MOVICOB_DB_INSERT_1 */

            R3500_00_INSERT_V0MOVICOB_DB_INSERT_1();

            /*" -2176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2177- DISPLAY 'R3500-00 - PROBLEMAS INSERT (V0MOVICOB)  ' */
                _.Display($"R3500-00 - PROBLEMAS INSERT (V0MOVICOB)  ");

                /*" -2179- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2179- ADD 1 TO AC-MOVICOB. */
            AREA_DE_WORK.AC_MOVICOB.Value = AREA_DE_WORK.AC_MOVICOB + 1;

        }

        [StopWatch]
        /*" R3500-00-INSERT-V0MOVICOB-DB-INSERT-1 */
        public void R3500_00_INSERT_V0MOVICOB_DB_INSERT_1()
        {
            /*" -2173- EXEC SQL INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES (:V0MCOB-CODEMP , :V0MCOB-CODMOV , :V0MCOB-BANCO , :V0MCOB-AGENCIA , :V0MCOB-NRAVISO , :V0MCOB-NUMFITA , :V0MCOB-DTMOVTO , :V0MCOB-DTQITBCO , :V0MCOB-NRTIT , :V0MCOB-NUMAPOL , :V0MCOB-NRENDOS , :V0MCOB-NRPARCEL , :V0MCOB-VALTIT , :V0MCOB-VLIOCC , :V0MCOB-VALCDT , :V0MCOB-SITUACAO , CURRENT TIMESTAMP , :V0MCOB-NOME , :V0MCOB-TIPOMOV , 0000000000000000 ) END-EXEC. */

            var r3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1 = new R3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1()
            {
                V0MCOB_CODEMP = V0MCOB_CODEMP.ToString(),
                V0MCOB_CODMOV = V0MCOB_CODMOV.ToString(),
                V0MCOB_BANCO = V0MCOB_BANCO.ToString(),
                V0MCOB_AGENCIA = V0MCOB_AGENCIA.ToString(),
                V0MCOB_NRAVISO = V0MCOB_NRAVISO.ToString(),
                V0MCOB_NUMFITA = V0MCOB_NUMFITA.ToString(),
                V0MCOB_DTMOVTO = V0MCOB_DTMOVTO.ToString(),
                V0MCOB_DTQITBCO = V0MCOB_DTQITBCO.ToString(),
                V0MCOB_NRTIT = V0MCOB_NRTIT.ToString(),
                V0MCOB_NUMAPOL = V0MCOB_NUMAPOL.ToString(),
                V0MCOB_NRENDOS = V0MCOB_NRENDOS.ToString(),
                V0MCOB_NRPARCEL = V0MCOB_NRPARCEL.ToString(),
                V0MCOB_VALTIT = V0MCOB_VALTIT.ToString(),
                V0MCOB_VLIOCC = V0MCOB_VLIOCC.ToString(),
                V0MCOB_VALCDT = V0MCOB_VALCDT.ToString(),
                V0MCOB_SITUACAO = V0MCOB_SITUACAO.ToString(),
                V0MCOB_NOME = V0MCOB_NOME.ToString(),
                V0MCOB_TIPOMOV = V0MCOB_TIPOMOV.ToString(),
            };

            R3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1.Execute(r3500_00_INSERT_V0MOVICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R4050-00-TRATA-COMISSAO-SECTION */
        private void R4050_00_TRATA_COMISSAO_SECTION()
        {
            /*" -2194- MOVE '4050' TO WNR-EXEC-SQL. */
            _.Move("4050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2196- MOVE 81 TO V0COMI-RAMOFR. */
            _.Move(81, V0COMI_RAMOFR);

            /*" -2197- MOVE V0BILH-NUMAPOL TO V0COMI-NUMAPOL. */
            _.Move(V0BILH_NUMAPOL, V0COMI_NUMAPOL);

            /*" -2198- MOVE V1MVDB-NRENDOS TO V0COMI-NRENDOS. */
            _.Move(V1MVDB_NRENDOS, V0COMI_NRENDOS);

            /*" -2200- MOVE V0BILH-NUMBIL TO V0COMI-NUMBIL. */
            _.Move(V0BILH_NUMBIL, V0COMI_NUMBIL);

            /*" -2202- COMPUTE V0COMI-VALBAS = V1MVDB-VLR-CREDITO. */
            V0COMI_VALBAS.Value = V1MVDB_VLR_CREDITO;

            /*" -2206- COMPUTE V0COMI-VLCOMIS = V0COMI-VALBAS * V0COMI-PCCOMCOR / 100. */
            V0COMI_VLCOMIS.Value = V0COMI_VALBAS * V0COMI_PCCOMCOR / 100f;

            /*" -2207- MOVE ZEROS TO V0COMI-NRCERTIF. */
            _.Move(0, V0COMI_NRCERTIF);

            /*" -2208- MOVE SPACES TO V0COMI-DIGCERT. */
            _.Move("", V0COMI_DIGCERT);

            /*" -2209- MOVE '1' TO V0COMI-IDTPSEGU. */
            _.Move("1", V0COMI_IDTPSEGU);

            /*" -2210- MOVE ZEROS TO V0COMI-NRPARCEL. */
            _.Move(0, V0COMI_NRPARCEL);

            /*" -2211- MOVE 1101 TO V0COMI-OPERACAO. */
            _.Move(1101, V0COMI_OPERACAO);

            /*" -2212- MOVE ZEROS TO V0COMI-MODALIFR. */
            _.Move(0, V0COMI_MODALIFR);

            /*" -2213- MOVE 1 TO V0COMI-OCORHIST. */
            _.Move(1, V0COMI_OCORHIST);

            /*" -2214- MOVE V0BILH-FONTE TO V0COMI-FONTE. */
            _.Move(V0BILH_FONTE, V0COMI_FONTE);

            /*" -2215- MOVE V0BILH-CODCLIEN TO V0COMI-CODCLIEN. */
            _.Move(V0BILH_CODCLIEN, V0COMI_CODCLIEN);

            /*" -2216- MOVE V1SIST-DTMOVABE TO V0COMI-DATCLO. */
            _.Move(V1SIST_DTMOVABE, V0COMI_DATCLO);

            /*" -2217- MOVE ZEROS TO V0COMI-NUMREC. */
            _.Move(0, V0COMI_NUMREC);

            /*" -2218- MOVE '1' TO V0COMI-TIPCOM. */
            _.Move("1", V0COMI_TIPCOM);

            /*" -2220- MOVE ZEROS TO V0COMI-QTPARCEL V0COMI-PCDESCON. */
            _.Move(0, V0COMI_QTPARCEL, V0COMI_PCDESCON);

            /*" -2221- MOVE ZEROS TO V0COMI-CODSUBES. */
            _.Move(0, V0COMI_CODSUBES);

            /*" -2222- MOVE V1SIST-DTMOVABE TO V0COMI-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0COMI_DTMOVTO);

            /*" -2223- MOVE V1SIST-DTMOVABE TO V0COMI-DATSEL. */
            _.Move(V1SIST_DTMOVABE, V0COMI_DATSEL);

            /*" -2226- MOVE ZEROS TO V0COMI-CODEMP V0COMI-CODPRP V0COMI-VLVARMON. */
            _.Move(0, V0COMI_CODEMP, V0COMI_CODPRP, V0COMI_VLVARMON);

            /*" -2228- MOVE V1SIST-DTMOVABE TO V0COMI-DTQITBCO. */
            _.Move(V1SIST_DTMOVABE, V0COMI_DTQITBCO);

            /*" -2229- MOVE -1 TO VIND-DTMOVTO. */
            _.Move(-1, VIND_DTMOVTO);

            /*" -2230- MOVE ZEROS TO VIND-DATSEL. */
            _.Move(0, VIND_DATSEL);

            /*" -2231- MOVE ZEROS TO VIND-CODEMP. */
            _.Move(0, VIND_CODEMP);

            /*" -2232- MOVE ZEROS TO VIND-NUMBIL. */
            _.Move(0, VIND_NUMBIL);

            /*" -2233- MOVE -1 TO VIND-CODPRP. */
            _.Move(-1, VIND_CODPRP);

            /*" -2234- MOVE -1 TO VIND-VLVARMON. */
            _.Move(-1, VIND_VLVARMON);

            /*" -2236- MOVE ZEROS TO VIND-DTQITBCO2. */
            _.Move(0, VIND_DTQITBCO2);

            /*" -2270- PERFORM R4050_00_TRATA_COMISSAO_DB_INSERT_1 */

            R4050_00_TRATA_COMISSAO_DB_INSERT_1();

            /*" -2274- IF SQLCODE EQUAL -803 NEXT SENTENCE */

            if (DB.SQLCODE == -803)
            {

                /*" -2275- ELSE */
            }
            else
            {


                /*" -2276- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2279- DISPLAY 'BI0075B - PROBLEMAS NO INSERT V0COMISSAO  ' V0BILH-NUMBIL ' ' V1MVDB-NRENDOS ' ' */

                    $"BI0075B - PROBLEMAS NO INSERT V0COMISSAO  {V0BILH_NUMBIL} {V1MVDB_NRENDOS} "
                    .Display();

                    /*" -2280- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2281- ELSE */
                }
                else
                {


                    /*" -2282- ADD 1 TO AC-COMISSAO */
                    AREA_DE_WORK.AC_COMISSAO.Value = AREA_DE_WORK.AC_COMISSAO + 1;

                    /*" -2283- END-IF */
                }


                /*" -2283- END-IF. */
            }


        }

        [StopWatch]
        /*" R4050-00-TRATA-COMISSAO-DB-INSERT-1 */
        public void R4050_00_TRATA_COMISSAO_DB_INSERT_1()
        {
            /*" -2270- EXEC SQL INSERT INTO SEGUROS.V0COMISSAO VALUES (:V0COMI-NUMAPOL , :V0COMI-NRENDOS , :V0COMI-NRCERTIF , :V0COMI-DIGCERT , :V0COMI-IDTPSEGU , :V0COMI-NRPARCEL , :V0COMI-OPERACAO , :V0COMI-CODPDT , :V0COMI-RAMOFR , :V0COMI-MODALIFR , :V0COMI-OCORHIST , :V0COMI-FONTE , :V0COMI-CODCLIEN , :V0COMI-VLCOMIS , :V0COMI-DATCLO , :V0COMI-NUMREC , :V0COMI-VALBAS , :V0COMI-TIPCOM , :V0COMI-QTPARCEL , :V0COMI-PCCOMCOR , :V0COMI-PCDESCON , :V0COMI-CODSUBES , CURRENT TIME , :V0COMI-DTMOVTO:VIND-DTMOVTO , :V0COMI-DATSEL:VIND-DATSEL , :V0COMI-CODEMP:VIND-CODEMP , :V0COMI-CODPRP:VIND-CODPRP , CURRENT TIMESTAMP , :V0COMI-NUMBIL:VIND-NUMBIL , :V0COMI-VLVARMON:VIND-VLVARMON , :V0COMI-DTQITBCO:VIND-DTQITBCO2) END-EXEC. */

            var r4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1 = new R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1()
            {
                V0COMI_NUMAPOL = V0COMI_NUMAPOL.ToString(),
                V0COMI_NRENDOS = V0COMI_NRENDOS.ToString(),
                V0COMI_NRCERTIF = V0COMI_NRCERTIF.ToString(),
                V0COMI_DIGCERT = V0COMI_DIGCERT.ToString(),
                V0COMI_IDTPSEGU = V0COMI_IDTPSEGU.ToString(),
                V0COMI_NRPARCEL = V0COMI_NRPARCEL.ToString(),
                V0COMI_OPERACAO = V0COMI_OPERACAO.ToString(),
                V0COMI_CODPDT = V0COMI_CODPDT.ToString(),
                V0COMI_RAMOFR = V0COMI_RAMOFR.ToString(),
                V0COMI_MODALIFR = V0COMI_MODALIFR.ToString(),
                V0COMI_OCORHIST = V0COMI_OCORHIST.ToString(),
                V0COMI_FONTE = V0COMI_FONTE.ToString(),
                V0COMI_CODCLIEN = V0COMI_CODCLIEN.ToString(),
                V0COMI_VLCOMIS = V0COMI_VLCOMIS.ToString(),
                V0COMI_DATCLO = V0COMI_DATCLO.ToString(),
                V0COMI_NUMREC = V0COMI_NUMREC.ToString(),
                V0COMI_VALBAS = V0COMI_VALBAS.ToString(),
                V0COMI_TIPCOM = V0COMI_TIPCOM.ToString(),
                V0COMI_QTPARCEL = V0COMI_QTPARCEL.ToString(),
                V0COMI_PCCOMCOR = V0COMI_PCCOMCOR.ToString(),
                V0COMI_PCDESCON = V0COMI_PCDESCON.ToString(),
                V0COMI_CODSUBES = V0COMI_CODSUBES.ToString(),
                V0COMI_DTMOVTO = V0COMI_DTMOVTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
                V0COMI_DATSEL = V0COMI_DATSEL.ToString(),
                VIND_DATSEL = VIND_DATSEL.ToString(),
                V0COMI_CODEMP = V0COMI_CODEMP.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                V0COMI_CODPRP = V0COMI_CODPRP.ToString(),
                VIND_CODPRP = VIND_CODPRP.ToString(),
                V0COMI_NUMBIL = V0COMI_NUMBIL.ToString(),
                VIND_NUMBIL = VIND_NUMBIL.ToString(),
                V0COMI_VLVARMON = V0COMI_VLVARMON.ToString(),
                VIND_VLVARMON = VIND_VLVARMON.ToString(),
                V0COMI_DTQITBCO = V0COMI_DTQITBCO.ToString(),
                VIND_DTQITBCO2 = VIND_DTQITBCO2.ToString(),
            };

            R4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1.Execute(r4050_00_TRATA_COMISSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4050_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-TRATA-FC0105S-SECTION */
        private void R4100_00_TRATA_FC0105S_SECTION()
        {
            /*" -2295- MOVE '1000' TO WNR-EXEC-SQL */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2297- PERFORM R4200-00-INSERT-MOVFEDCA. */

            R4200_00_INSERT_MOVFEDCA_SECTION();

            /*" -2299- PERFORM R4300-00-INSERT-COMFEDCA. */

            R4300_00_INSERT_COMFEDCA_SECTION();

            /*" -2299- PERFORM R4350-00-INSERT-RELATORIO. */

            R4350_00_INSERT_RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4150-00-SELECT-BILCOBER-SECTION */
        private void R4150_00_SELECT_BILCOBER_SECTION()
        {
            /*" -2311- MOVE 'R4150' TO WNR-EXEC-SQL. */
            _.Move("R4150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2313- INITIALIZE DCLBILHETE-COBERTURA. */
            _.Initialize(
                BILCOBER.DCLBILHETE_COBERTURA
            );

            /*" -2323- PERFORM R4150_00_SELECT_BILCOBER_DB_SELECT_1 */

            R4150_00_SELECT_BILCOBER_DB_SELECT_1();

            /*" -2326- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2327- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2328- MOVE ZEROS TO BILCOBER-VAL-MAX-COBER-BAS */
                    _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS);

                    /*" -2329- ELSE */
                }
                else
                {


                    /*" -2332- DISPLAY 'PROBLEMAS NO ACESSO A BILCOBER' V0BILH-NUMBIL ' ' V1MVDB-NRENDOS ' ' */

                    $"PROBLEMAS NO ACESSO A BILCOBER{V0BILH_NUMBIL} {V1MVDB_NRENDOS} "
                    .Display();

                    /*" -2333- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2334- END-IF */
                }


                /*" -2335- END-IF. */
            }


        }

        [StopWatch]
        /*" R4150-00-SELECT-BILCOBER-DB-SELECT-1 */
        public void R4150_00_SELECT_BILCOBER_DB_SELECT_1()
        {
            /*" -2323- EXEC SQL SELECT VAL_MAX_COBER_BAS INTO :BILCOBER-VAL-MAX-COBER-BAS FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = 999 AND COD_PRODUTO = :V0CONV-CODPRODU AND RAMO_COBERTURA = :V0BILH-RAMO AND MODALI_COBERTURA = 0 AND COD_OPCAO_PLANO = :V0BILH-OPCAO-COB AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1 = new R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1()
            {
                V0BILH_OPCAO_COB = V0BILH_OPCAO_COB.ToString(),
                V0CONV_CODPRODU = V0CONV_CODPRODU.ToString(),
                V0BILH_RAMO = V0BILH_RAMO.ToString(),
            };

            var executed_1 = R4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1.Execute(r4150_00_SELECT_BILCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILCOBER_VAL_MAX_COBER_BAS, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4150_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-INSERT-MOVFEDCA-SECTION */
        private void R4200_00_INSERT_MOVFEDCA_SECTION()
        {
            /*" -2348- MOVE '4200' TO WNR-EXEC-SQL. */
            _.Move("4200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2364- INITIALIZE LK-PLANO LK-SERIE LK-TITULO LK-NUM-PROPOSTA LK-QTD-TITULOS LK-VLR-TITULO LK-PARCEIRO LK-RAMO LK-COD-USUARIO LK-TRACE LK-OUT-COD-RETORNO LK-OUT-SQLCODE LK-OUT-MENSAGEM LK-OUT-SQLERRMC LK-OUT-SQLSTATE. */
            _.Initialize(
                LK_PLANO
                , LK_SERIE
                , LK_TITULO
                , LK_NUM_PROPOSTA
                , LK_QTD_TITULOS
                , LK_VLR_TITULO
                , LK_PARCEIRO
                , LK_RAMO
                , LK_COD_USUARIO
                , LK_TRACE
                , LK_OUT_COD_RETORNO
                , LK_OUT_SQLCODE
                , LK_OUT_MENSAGEM
                , LK_OUT_SQLERRMC
                , LK_OUT_SQLSTATE
            );

            /*" -2368- MOVE 858 TO LK-PLANO. */
            _.Move(858, LK_PLANO);

            /*" -2370- MOVE V0BILH-NUMBIL TO LK-NUM-PROPOSTA. */
            _.Move(V0BILH_NUMBIL, LK_NUM_PROPOSTA);

            /*" -2373- MOVE 1 TO LK-QTD-TITULOS. */
            _.Move(1, LK_QTD_TITULOS);

            /*" -2376- MOVE BILCOBER-VAL-MAX-COBER-BAS TO LK-VLR-TITULO. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_MAX_COBER_BAS, LK_VLR_TITULO);

            /*" -2378- MOVE 'BI0075B' TO LK-COD-USUARIO. */
            _.Move("BI0075B", LK_COD_USUARIO);

            /*" -2380- MOVE WSHOST-CODPRODU TO LK-RAMO PRODUTO-COD-PRODUTO. */
            _.Move(WSHOST_CODPRODU, LK_RAMO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

            /*" -2381- PERFORM R5000-00-SELECT-EMP-CAP. */

            R5000_00_SELECT_EMP_CAP_SECTION();

            /*" -2383- MOVE PARAMGER-COD-EMPRESA-CAP TO LK-PARCEIRO. */
            _.Move(PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP, LK_PARCEIRO);

            /*" -2385- MOVE 'TRACE OFF' TO LK-TRACE. */
            _.Move("TRACE OFF", LK_TRACE);

            /*" -2387- MOVE ZEROS TO LK-NUM-NSA. */
            _.Move(0, LK_NUM_NSA);

            /*" -2408- CALL 'VG0105S' USING LK-PLANO , LK-SERIE , LK-TITULO , LK-NUM-PROPOSTA , LK-QTD-TITULOS , LK-VLR-TITULO , LK-PARCEIRO , LK-RAMO , LK-COD-USUARIO , LK-NUM-NSA , LK-TRACE , LK-OUT-COD-RETORNO , LK-OUT-SQLCODE , LK-OUT-MENSAGEM , LK-OUT-SQLERRMC , LK-OUT-SQLSTATE. */
            _.Call("VG0105S", LK_PLANO, LK_SERIE, LK_TITULO, LK_NUM_PROPOSTA, LK_QTD_TITULOS, LK_VLR_TITULO, LK_PARCEIRO, LK_RAMO, LK_COD_USUARIO, LK_NUM_NSA, LK_TRACE, LK_OUT_COD_RETORNO, LK_OUT_SQLCODE, LK_OUT_MENSAGEM, LK_OUT_SQLERRMC, LK_OUT_SQLSTATE);

            /*" -2409- IF LK-OUT-COD-RETORNO NOT EQUAL ZEROS */

            if (LK_OUT_COD_RETORNO != 00)
            {

                /*" -2410- MOVE LK-OUT-SQLCODE TO WS-SQLCODE */
                _.Move(LK_OUT_SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -2419- DISPLAY 'PROBLEMAS NO ACESSO A VG0105S ' ' ' LK-NUM-PROPOSTA ' ' LK-OUT-COD-RETORNO ' ' WS-SQLCODE ' ' LK-OUT-MENSAGEM ' ' LK-OUT-SQLERRMC ' ' LK-OUT-SQLSTATE */

                $"PROBLEMAS NO ACESSO A VG0105S  {LK_NUM_PROPOSTA} {LK_OUT_COD_RETORNO} {AREA_DE_WORK.WS_SQLCODE} {LK_OUT_MENSAGEM} {LK_OUT_SQLERRMC} {LK_OUT_SQLSTATE}"
                .Display();

                /*" -2420- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2420- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-INSERT-COMFEDCA-SECTION */
        private void R4300_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -2432- MOVE '4300' TO WNR-EXEC-SQL. */
            _.Move("4300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2443- PERFORM R4300_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R4300_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -2446- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2447- DISPLAY 'R4300 - ERRO NO INSERT DA COMFEDCA' */
                _.Display($"R4300 - ERRO NO INSERT DA COMFEDCA");

                /*" -2448- DISPLAY 'BILHETE ' V0BILH-NUMBIL */
                _.Display($"BILHETE {V0BILH_NUMBIL}");

                /*" -2449- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2449- END-IF. */
            }


        }

        [StopWatch]
        /*" R4300-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R4300_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -2443- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO , SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES ( :V0BILH-NUMBIL , '0' , :V1SIST-DTMOVABE , CURRENT TIMESTAMP ) END-EXEC. */

            var r4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r4300_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4350-00-INSERT-RELATORIO-SECTION */
        private void R4350_00_INSERT_RELATORIO_SECTION()
        {
            /*" -2460- MOVE '4350' TO WNR-EXEC-SQL. */
            _.Move("4350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2461- MOVE 'BI0075B1' TO RELATORI-COD-RELATORIO. */
            _.Move("BI0075B1", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -2462- MOVE V0BILH-NUMAPOL TO RELATORI-NUM-APOLICE. */
            _.Move(V0BILH_NUMAPOL, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -2463- MOVE V1MVDB-NRENDOS TO RELATORI-NUM-ENDOSSO. */
            _.Move(V1MVDB_NRENDOS, RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO);

            /*" -2464- MOVE ZEROS TO RELATORI-NUM-CERTIFICADO. */
            _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -2465- MOVE V0BILH-NUMBIL TO RELATORI-NUM-TITULO. */
            _.Move(V0BILH_NUMBIL, RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO);

            /*" -2467- MOVE 3 TO RELATORI-COD-OPERACAO. */
            _.Move(3, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);

            /*" -2510- PERFORM R4350_00_INSERT_RELATORIO_DB_INSERT_1 */

            R4350_00_INSERT_RELATORIO_DB_INSERT_1();

            /*" -2513- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2514- DISPLAY 'R4350 - ERRO INSERT RELATORIOS..' */
                _.Display($"R4350 - ERRO INSERT RELATORIOS..");

                /*" -2515- DISPLAY 'NUMBIL:' V0BILH-NUMBIL */
                _.Display($"NUMBIL:{V0BILH_NUMBIL}");

                /*" -2515- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4350-00-INSERT-RELATORIO-DB-INSERT-1 */
        public void R4350_00_INSERT_RELATORIO_DB_INSERT_1()
        {
            /*" -2510- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'BI0075B' , CURRENT DATE , 'BI' , :RELATORI-COD-RELATORIO , 0 , 0 , CURRENT DATE , CURRENT DATE , CURRENT DATE , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , :RELATORI-NUM-APOLICE , :RELATORI-NUM-ENDOSSO , 0 , :RELATORI-NUM-CERTIFICADO , :RELATORI-NUM-TITULO , 0 , :RELATORI-COD-OPERACAO , 0 , 0 , ' ' , ' ' , 0 , 0 , ' ' , 0 , 0 , ' ' , '0' , ' ' , ' ' , NULL , 0 , 0 , CURRENT TIMESTAMP) END-EXEC. */

            var r4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 = new R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
            };

            R4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1.Execute(r4350_00_INSERT_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4350_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-SECTION */
        private void R5000_00_SELECT_EMP_CAP_SECTION()
        {
            /*" -2536- PERFORM R5000_00_SELECT_EMP_CAP_DB_SELECT_1 */

            R5000_00_SELECT_EMP_CAP_DB_SELECT_1();

            /*" -2539- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2540- DISPLAY 'R5000-00 (ERRO - SELECT PRODUTO )...' */
                _.Display($"R5000-00 (ERRO - SELECT PRODUTO )...");

                /*" -2541- DISPLAY 'PRODUTO: ' PRODUTO-COD-PRODUTO */
                _.Display($"PRODUTO: {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -2542- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5000-00-SELECT-EMP-CAP-DB-SELECT-1 */
        public void R5000_00_SELECT_EMP_CAP_DB_SELECT_1()
        {
            /*" -2536- EXEC SQL SELECT PR.COD_EMPRESA ,PG.COD_EMPRESA_CAP INTO :PRODUTO-COD-EMPRESA ,:PARAMGER-COD-EMPRESA-CAP FROM SEGUROS.PRODUTO PR, SEGUROS.PARAMETROS_GERAIS PG WHERE PR.COD_PRODUTO = :PRODUTO-COD-PRODUTO AND PR.COD_EMPRESA = PG.COD_EMPRESA END-EXEC. */

            var r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1 = new R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1()
            {
                PRODUTO_COD_PRODUTO = PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO.ToString(),
            };

            var executed_1 = R5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1.Execute(r5000_00_SELECT_EMP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PARAMGER_COD_EMPRESA_CAP, PARAMGER.DCLPARAMETROS_GERAIS.PARAMGER_COD_EMPRESA_CAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-DESPESAS-SECTION */
        private void R8000_00_TRATA_DESPESAS_SECTION()
        {
            /*" -2555- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2556- SET WS-PRD TO 1 */
            WS_PRD.Value = 1;

            /*" -2557- SEARCH WTABG-OCORREPRD */
            for (; WS_PRD < AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD.Items.Count; WS_PRD.Value++)
            {

                /*" -2559- WHEN WSHOST-CODPRODU EQUAL WTABG-CODPRODU(WS-PRD) */

                if (WSHOST_CODPRODU == AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU)
                {


                    /*" -2559- PERFORM R8050-00-VERIFICA-TIPO  END-SEARCH. */

                    R8050_00_VERIFICA_TIPO_SECTION();
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8050-00-VERIFICA-TIPO-SECTION */
        private void R8050_00_VERIFICA_TIPO_SECTION()
        {
            /*" -2576- MOVE '8050' TO WNR-EXEC-SQL. */
            _.Move("8050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2581- SET WS-TIP TO 1. */
            WS_TIP.Value = 1;

            /*" -2582- IF WSHOST-SITUACAO EQUAL '0' */

            if (WSHOST_SITUACAO == "0")
            {

                /*" -2583- SET WS-SIT TO 1 */
                WS_SIT.Value = 1;

                /*" -2587- ELSE */
            }
            else
            {


                /*" -2590- SET WS-SIT TO 2. */
                WS_SIT.Value = 2;
            }


            /*" -2593- ADD 1 TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE + 1;

            /*" -2596- ADD WSHOST-VLPRMTOT TO WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT + WSHOST_VLPRMTOT;

            /*" -2599- ADD WSHOST-VLTARIFA TO WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA + WSHOST_VLTARIFA;

            /*" -2602- ADD WSHOST-VLBALCAO TO WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO + WSHOST_VLBALCAO;

            /*" -2605- ADD WSHOST-VLIOCC TO WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC + WSHOST_VLIOCC;

            /*" -2606- ADD WSHOST-VLDESCON TO WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON.Value = AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON + WSHOST_VLDESCON;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8050_99_SAIDA*/

        [StopWatch]
        /*" R8500-00-GRAVA-DESPESAS-SECTION */
        private void R8500_00_GRAVA_DESPESAS_SECTION()
        {
            /*" -2619- MOVE '8500' TO WNR-EXEC-SQL. */
            _.Move("8500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2620- IF WTABG-CODPRODU(WS-PRD) EQUAL 9999 */

            if (AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU == 9999)
            {

                /*" -2621- SET WS-PRD UP BY 1 */
                WS_PRD.Value += 1;

                /*" -2624- GO TO R8500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2627- MOVE WTABG-CODPRODU(WS-PRD) TO V0DPCF-CODPRODU. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_CODPRODU, V0DPCF_CODPRODU);

            /*" -2628- MOVE ZEROS TO V0DPCF-CODEMP */
            _.Move(0, V0DPCF_CODEMP);

            /*" -2629- MOVE V0MCOB-BANCO TO V0DPCF-BCOAVISO */
            _.Move(V0MCOB_BANCO, V0DPCF_BCOAVISO);

            /*" -2630- MOVE V0MCOB-AGENCIA TO V0DPCF-AGEAVISO */
            _.Move(V0MCOB_AGENCIA, V0DPCF_AGEAVISO);

            /*" -2631- MOVE V1MVDB-NUM-LOTE TO V0DPCF-NRAVISO */
            _.Move(V1MVDB_NUM_LOTE, V0DPCF_NRAVISO);

            /*" -2632- MOVE '1' TO V0DPCF-TIPOCOB */
            _.Move("1", V0DPCF_TIPOCOB);

            /*" -2633- MOVE V0AVIS-DTMOVTO TO V0DPCF-DTMOVTO */
            _.Move(V0AVIS_DTMOVTO, V0DPCF_DTMOVTO);

            /*" -2634- MOVE V0AVIS-DTAVISO TO V0DPCF-DTAVISO */
            _.Move(V0AVIS_DTAVISO, V0DPCF_DTAVISO);

            /*" -2637- MOVE ZEROS TO V0DPCF-VLJUROS V0DPCF-VLMULTA. */
            _.Move(0, V0DPCF_VLJUROS, V0DPCF_VLMULTA);

            /*" -2638- MOVE V0AVIS-DTAVISO TO WDATA-REL */
            _.Move(V0AVIS_DTAVISO, AREA_DE_WORK.WDATA_REL);

            /*" -2639- MOVE WDAT-REL-ANO TO V0DPCF-ANOREF */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_ANO, V0DPCF_ANOREF);

            /*" -2642- MOVE WDAT-REL-MES TO V0DPCF-MESREF. */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_MES, V0DPCF_MESREF);

            /*" -2643- SET WS-TIP TO 1 */
            WS_TIP.Value = 1;

            /*" -2646- PERFORM R8550-00-GRAVA-TIPO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R8550_00_GRAVA_TIPO_SECTION();

            }

            /*" -2646- SET WS-PRD UP BY 1. */
            WS_PRD.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8500_99_SAIDA*/

        [StopWatch]
        /*" R8550-00-GRAVA-TIPO-SECTION */
        private void R8550_00_GRAVA_TIPO_SECTION()
        {
            /*" -2660- MOVE '8550' TO WNR-EXEC-SQL. */
            _.Move("8550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2664- MOVE WTABG-TIPO(WS-PRD WS-TIP) TO V0DPCF-TIPOREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_TIPO, V0DPCF_TIPOREG);

            /*" -2665- SET WS-SIT TO 1 */
            WS_SIT.Value = 1;

            /*" -2668- PERFORM R8600-00-GRAVA-REGISTRO 02 TIMES. */

            for (int i = 0; i < 2; i++)
            {

                R8600_00_GRAVA_REGISTRO_SECTION();

            }

            /*" -2668- SET WS-TIP UP BY 1. */
            WS_TIP.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8550_99_SAIDA*/

        [StopWatch]
        /*" R8600-00-GRAVA-REGISTRO-SECTION */
        private void R8600_00_GRAVA_REGISTRO_SECTION()
        {
            /*" -2682- MOVE '8600' TO WNR-EXEC-SQL. */
            _.Move("8600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2684- MOVE WTABG-SITUACAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-SITUACAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_SITUACAO, V0DPCF_SITUACAO);

            /*" -2686- MOVE WTABG-QTDE(WS-PRD WS-TIP WS-SIT) TO V0DPCF-QTDREG. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, V0DPCF_QTDREG);

            /*" -2688- MOVE WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLPRMTOT. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, V0DPCF_VLPRMTOT);

            /*" -2690- MOVE WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLTARIFA. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, V0DPCF_VLTARIFA);

            /*" -2692- MOVE WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLBALCAO. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, V0DPCF_VLBALCAO);

            /*" -2694- MOVE WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLIOCC. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, V0DPCF_VLIOCC);

            /*" -2701- MOVE WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT) TO V0DPCF-VLDESCON. */
            _.Move(AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON, V0DPCF_VLDESCON);

            /*" -2703- SET WS-SUBS TO WS-TIP. */
            AREA_DE_WORK.WS_SUBS.Value = WS_TIP;

            /*" -2704- IF WS-SUBS NOT EQUAL 3 */

            if (AREA_DE_WORK.WS_SUBS != 3)
            {

                /*" -2709- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT - V0DPCF-VLTARIFA - V0DPCF-VLBALCAO - V0DPCF-VLIOCC - V0DPCF-VLDESCON - V0DPCF-VLJUROS - V0DPCF-VLMULTA) */
                V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT - V0DPCF_VLTARIFA - V0DPCF_VLBALCAO - V0DPCF_VLIOCC - V0DPCF_VLDESCON - V0DPCF_VLJUROS - V0DPCF_VLMULTA);

                /*" -2710- ELSE */
            }
            else
            {


                /*" -2717- COMPUTE V0DPCF-VLPRMLIQ EQUAL (V0DPCF-VLPRMTOT + V0DPCF-VLTARIFA + V0DPCF-VLBALCAO + V0DPCF-VLIOCC + V0DPCF-VLDESCON + V0DPCF-VLJUROS + V0DPCF-VLMULTA). */
                V0DPCF_VLPRMLIQ.Value = (V0DPCF_VLPRMTOT + V0DPCF_VLTARIFA + V0DPCF_VLBALCAO + V0DPCF_VLIOCC + V0DPCF_VLDESCON + V0DPCF_VLJUROS + V0DPCF_VLMULTA);
            }


            /*" -2722- IF V0DPCF-QTDREG EQUAL ZEROS AND V0DPCF-VLPRMTOT EQUAL ZEROS AND V0DPCF-VLPRMLIQ EQUAL ZEROS AND V0DPCF-VLTARIFA EQUAL ZEROS AND V0DPCF-VLBALCAO EQUAL ZEROS */

            if (V0DPCF_QTDREG == 00 && V0DPCF_VLPRMTOT == 00 && V0DPCF_VLPRMLIQ == 00 && V0DPCF_VLTARIFA == 00 && V0DPCF_VLBALCAO == 00)
            {

                /*" -2723- SET WS-SIT UP BY 1 */
                WS_SIT.Value += 1;

                /*" -2726- GO TO R8600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2729- PERFORM R8700-00-INSERT-DESPESAS. */

            R8700_00_INSERT_DESPESAS_SECTION();

            /*" -2738- MOVE ZEROS TO WTABG-QTDE(WS-PRD WS-TIP WS-SIT) WTABG-VLPRMTOT(WS-PRD WS-TIP WS-SIT) WTABG-VLTARIFA(WS-PRD WS-TIP WS-SIT) WTABG-VLBALCAO(WS-PRD WS-TIP WS-SIT) WTABG-VLIOCC(WS-PRD WS-TIP WS-SIT) WTABG-VLDESCON(WS-PRD WS-TIP WS-SIT). */
            _.Move(0, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_QTDE, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLPRMTOT, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLTARIFA, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLBALCAO, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLIOCC, AUX_TABELAS.WTABG_VALORES.WTABG_OCORREPRD[WS_PRD].WTABG_OCORRETIP[WS_TIP].WTABG_OCORRESIT[WS_SIT].WTABG_VLDESCON);

            /*" -2738- SET WS-SIT UP BY 1. */
            WS_SIT.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8600_99_SAIDA*/

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-SECTION */
        private void R8700_00_INSERT_DESPESAS_SECTION()
        {
            /*" -2752- MOVE '8700' TO WNR-EXEC-SQL. */
            _.Move("8700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2754- SET WS-SUBS TO WS-TIP. */
            AREA_DE_WORK.WS_SUBS.Value = WS_TIP;

            /*" -2755- MOVE 'D' TO V0DPCF-TIPOREG */
            _.Move("D", V0DPCF_TIPOREG);

            /*" -2757- MOVE V0AVIS-NRAVISO TO V0DPCF-NRAVISO. */
            _.Move(V0AVIS_NRAVISO, V0DPCF_NRAVISO);

            /*" -2782- PERFORM R8700_00_INSERT_DESPESAS_DB_INSERT_1 */

            R8700_00_INSERT_DESPESAS_DB_INSERT_1();

            /*" -2786- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2787- DISPLAY 'R8700-00 - PROBLEMAS INSERT (DESPESAS)   ' */
                _.Display($"R8700-00 - PROBLEMAS INSERT (DESPESAS)   ");

                /*" -2788- DISPLAY 'ANOREF   ' V0DPCF-ANOREF */
                _.Display($"ANOREF   {V0DPCF_ANOREF}");

                /*" -2789- DISPLAY 'MESREF   ' V0DPCF-MESREF */
                _.Display($"MESREF   {V0DPCF_MESREF}");

                /*" -2790- DISPLAY 'BCOAVISO ' V0DPCF-BCOAVISO */
                _.Display($"BCOAVISO {V0DPCF_BCOAVISO}");

                /*" -2791- DISPLAY 'AGEAVISO ' V0DPCF-AGEAVISO */
                _.Display($"AGEAVISO {V0DPCF_AGEAVISO}");

                /*" -2792- DISPLAY 'NRAVISO  ' V0DPCF-NRAVISO */
                _.Display($"NRAVISO  {V0DPCF_NRAVISO}");

                /*" -2793- DISPLAY 'CODPRODU ' V0DPCF-CODPRODU */
                _.Display($"CODPRODU {V0DPCF_CODPRODU}");

                /*" -2794- DISPLAY 'DTMOVTO  ' V0DPCF-DTMOVTO */
                _.Display($"DTMOVTO  {V0DPCF_DTMOVTO}");

                /*" -2795- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2796- ELSE */
            }
            else
            {


                /*" -2796- ADD 1 TO AC-I-DESPESAS. */
                AREA_DE_WORK.AC_I_DESPESAS.Value = AREA_DE_WORK.AC_I_DESPESAS + 1;
            }


        }

        [StopWatch]
        /*" R8700-00-INSERT-DESPESAS-DB-INSERT-1 */
        public void R8700_00_INSERT_DESPESAS_DB_INSERT_1()
        {
            /*" -2782- EXEC SQL INSERT INTO SEGUROS.CONTROL_DESPES_CEF VALUES (:V0DPCF-CODEMP , :V0DPCF-ANOREF , :V0DPCF-MESREF , :V0DPCF-BCOAVISO , :V0DPCF-AGEAVISO , :V0DPCF-NRAVISO , :V0DPCF-CODPRODU , :V0DPCF-TIPOREG , :V0DPCF-SITUACAO , :V0DPCF-TIPOCOB , :V0DPCF-DTMOVTO , :V0DPCF-DTAVISO , :V0DPCF-QTDREG , :V0DPCF-VLPRMTOT , :V0DPCF-VLPRMLIQ , :V0DPCF-VLTARIFA , :V0DPCF-VLBALCAO , :V0DPCF-VLIOCC , :V0DPCF-VLDESCON , :V0DPCF-VLJUROS , :V0DPCF-VLMULTA , CURRENT TIMESTAMP) END-EXEC. */

            var r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1 = new R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1()
            {
                V0DPCF_CODEMP = V0DPCF_CODEMP.ToString(),
                V0DPCF_ANOREF = V0DPCF_ANOREF.ToString(),
                V0DPCF_MESREF = V0DPCF_MESREF.ToString(),
                V0DPCF_BCOAVISO = V0DPCF_BCOAVISO.ToString(),
                V0DPCF_AGEAVISO = V0DPCF_AGEAVISO.ToString(),
                V0DPCF_NRAVISO = V0DPCF_NRAVISO.ToString(),
                V0DPCF_CODPRODU = V0DPCF_CODPRODU.ToString(),
                V0DPCF_TIPOREG = V0DPCF_TIPOREG.ToString(),
                V0DPCF_SITUACAO = V0DPCF_SITUACAO.ToString(),
                V0DPCF_TIPOCOB = V0DPCF_TIPOCOB.ToString(),
                V0DPCF_DTMOVTO = V0DPCF_DTMOVTO.ToString(),
                V0DPCF_DTAVISO = V0DPCF_DTAVISO.ToString(),
                V0DPCF_QTDREG = V0DPCF_QTDREG.ToString(),
                V0DPCF_VLPRMTOT = V0DPCF_VLPRMTOT.ToString(),
                V0DPCF_VLPRMLIQ = V0DPCF_VLPRMLIQ.ToString(),
                V0DPCF_VLTARIFA = V0DPCF_VLTARIFA.ToString(),
                V0DPCF_VLBALCAO = V0DPCF_VLBALCAO.ToString(),
                V0DPCF_VLIOCC = V0DPCF_VLIOCC.ToString(),
                V0DPCF_VLDESCON = V0DPCF_VLDESCON.ToString(),
                V0DPCF_VLJUROS = V0DPCF_VLJUROS.ToString(),
                V0DPCF_VLMULTA = V0DPCF_VLMULTA.ToString(),
            };

            R8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1.Execute(r8700_00_INSERT_DESPESAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8700_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2807- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2809- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2809- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2811- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2815- MOVE 999 TO RETURN-CODE. */
            _.Move(999, RETURN_CODE);

            /*" -2815- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}