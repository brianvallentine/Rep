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
using Sias.VidaAzul.DB2.VA0139B;

namespace Code
{
    public class VA0139B
    {
        public bool IsCall { get; set; }

        public VA0139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL MULTIPREMIADO/GLOBAL/FENAM *      */
        /*"      *   PROGRAMA ...............  VA0139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    HISTORICO DE ALTERACOES                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - INCIDENTE 212.290 - CADMUS 175.782               *      */
        /*"      *               CORRIGIR LOOPING DO PROGRAMA QUE CHAMAVA A SAIDA *      */
        /*"      *               DO PARAGRAFO SEM LER O PROXIMO REGISTRO OU FINA- *      */
        /*"      *               LIZAR O PROCESSAMENTO.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/08/2019 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - PROJETO CARTAO DE CREDITO CIELO                  *      */
        /*"      *               ALTERAR A FORMA DE FATURAMENTO DO SIAS, COM A    *      */
        /*"      *               OPCAO DE PAGAMENTO CARTAO DE CREDITO, SURGIU A   *      */
        /*"      *               NECESSIDADE DE QUE O ENDOSSO DE FATURAMENTO SEJA *      */
        /*"      *               GERADO POR CERTIFICADO E NAO MAIS POR APOLICE.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/05/2019 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.25         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - HIST 181.584                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - LIBERA FATURAS DE COBRANCA PARA ADESAO DESDE     *      */
        /*"      *               QUE NAO EXISTA SOLICITACAO DE DEVOLUCAO.         *      */
        /*"      *             - LIBERA FATURAS DE RESTITUICAO PARA ADESAO DESDE  *      */
        /*"      *               QUE EXISTA FATURAS DE COBRANCA EMITIDAS.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/11/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - LIBERA FATURAS DE CERTIFICADOS CANCELADOS        *      */
        /*"      *               PARA DEMAIS PARCELAS.                            *      */
        /*"      *             - PRIMEIRA PARCELA FICA PENDENTE PARA ANALISE      *      */
        /*"      *               CONFORME ALTERACAO EFETUADA NA  V.19 E V.20,     *      */
        /*"      *               EVITANDO PAGAMENTO DE COMISSAO P/ CERTIFICADOS   *      */
        /*"      *               DECLINADOS PELA SEGURADORA.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.22    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - CADMUS 154.956                                   *      */
        /*"      *             - DESCONSIDERAR MODALIDADE NA CONSULTA DE COBERTURA*      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.21    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - INIBE EMISSAO DE FATURAS COM SITUACAO 4          *      */
        /*"      *             - CANCELADA APOS ACEITACAO                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.20    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - CADMUS 152.341                                   *      */
        /*"      *                                                                *      */
        /*"      *             - FATURAR PARCELAS PAGAS APENAS PARA APOLICES EMITI*      */
        /*"      *               DAS, EVITANDO PAGAMENTO DE COMISSAO P/ CERTIFICA-*      */
        /*"      *               DOS DECLINADOS PELA SEGURADORA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/07/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.19    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 18                                                          */
        /*"      * MOTIVO  : RETIRAR DO PROCESSAMENTO APOLICES: 103701139293             */
        /*"      *                                              103701139296             */
        /*"      * CADMUS  : 135497                                                      */
        /*"      * DATA    : 28/04/2016                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.18                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 17                                                          */
        /*"      * MOTIVO  : RETIRAR ALTERACOES DO RAMO 37                               */
        /*"      * CADMUS  : 134942                                                      */
        /*"      * DATA    : 12/04/2016                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.17                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 16                                                          */
        /*"      * MOTIVO  : ABEND NO PGM RV0100B DA ROTINA (JPRVD01). FALTA DE          */
        /*"      *           REGISTRO NA TABELA V0COBERAPOL PARA O RAMO 37               */
        /*"      * CADMUS  : 134942                                                      */
        /*"      * DATA    : 07/04/2016                                                  */
        /*"      * NOME    : DIOGO MATHEUS                                               */
        /*"      * MARCADOR: V.16                                                        */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CAD 128.716 ABEND                                *      */
        /*"      *             - DEMORA NO PROGRAMA DEVIDO A UM LOOP AO TENTAR    *      */
        /*"      *               INCLUIR NA TABELA DE ENDOSSOS. SEMPRE OCORRE ERRO*      */
        /*"      *               803 AO TENTAR INCLUIR E O PROGRAMA FICA EM LOOP  *      */
        /*"      *               BUSCANDO UM NUMERO DE PROPOSTA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/01/2016 - CLAUDETE RADEL/KINKAS                        *      */
        /*"      *                                            PROCURE POR V.15    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CAD 126.986                                      *      */
        /*"      *             - CORRECAO DE ABEND, QUANDO DA SOMA DE PREMIO VG+AP*      */
        /*"      *               RESULTA EM ZERO, OCORRE DIVISAO POR ZERO E ABENDA*      */
        /*"      *               O PROGRAMA. FEITO CRITICA PARA NAO PROCESSAR ESTE*      */
        /*"      *               CASO.                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/12/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 -                                                  *      */
        /*"      *             - ESPECIFICACAO NO V00N/2014 DE 01/08/2014         *      */
        /*"      *               INCLUSAO DE RESSEGURO - VIDA DA GENTE            *      */
        /*"      *                                                                *      */
        /*"      *               CAPTURA O CAMPO MODALIDADE DA TABELA APOLICES    *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/08/2014 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.13    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 12 - CAD 95.972                                       *      */
        /*"      *             - ATENDIMENTO DA CIRC-SUSEP 360:                   *      */
        /*"      *               DATA DA PROPOSTA NAO PODE SER MAIOR QUE A DATA   *      */
        /*"      *               DE INICIO DE VIGENCIA NA TABELA DE ENDOSSOS      *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                            PROCURE POR V.12    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.11    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10                                                    *      */
        /*"      *             - CAD  SEMCAD - AJUSTE PARA CORRIGIR APOLICES      *      */
        /*"      *               NAO FATURADAS.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/08/2013 - HERVAL SOUZA                                 *      */
        /*"      *                                          PROCURE POR V.10      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09                                                    *      */
        /*"      *             - CAD  80.793 - AJUSTE PARA CORRIGIR DIFERENCA     *      */
        /*"      *               NO PERCENTUAL DE COBERTURA.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/04/2013 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.09      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08                                                    *      */
        /*"      *             - CAD 201.081 - AJUSTE PARA DISTRIBUIR O IOF       *      */
        /*"      *               PARA CADA RAMO ENCONTRADO.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/07/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.08      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07                                                    *      */
        /*"      *             - CAD 55571 - AJUSTE NO PROGRAMA PARA ENQUADRA O   *      */
        /*"      *               ENDOSSO NO PRODUTO CORRETO.                      *      */
        /*"      *               LABEL R0910-00-FETCH-PROPOVA                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/04/2011 - RILDO SICO             PROCURE POR V.07      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06                                                    *      */
        /*"      *             - CAD 201.020                                      *      */
        /*"      *               AJUSTE NA GERACAO DA APOLICE_COBERTURAS          *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/02/2011 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05                                                    *      */
        /*"      *             - CAD 48.762                                       *      */
        /*"      *               CIRCULAR SUSEP 395                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/11/2010 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04                                                    *      */
        /*"      *             - CAD 36.597                                       *      */
        /*"      *               OTIMIZACAO DO PROGRAMA POR CAUSAR GRANDE IMPACTO *      */
        /*"      *               NA DIARIA EM MOMENTO CRITICO                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/02/2010 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CAD 36.283                                       *      */
        /*"      *                                                                *      */
        /*"      *                 -ATIVAR DISPLAYS PARA MAPEAR O PROCESSAMENTO.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/01/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.03             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 10/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 13.809/2008                                  *      */
        /*"      *               INICIALIZA A VARIALVEL                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/08/2008 - TERCIO (FAST COMPUTER)   PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   22/09/2006                FAST COMPUTER                      *      */
        /*"      *                             PASSA CONSIDERAR APENAS AS         *      */
        /*"      *                             SITUACOES DA PROPOSTAS_VA          *      */
        /*"      *                                                                *      */
        /*"      *                                       0 - AGUARDA INTEGRACAO   *      */
        /*"      *                                       1 - EM CRITICA           *      */
        /*"      *                                       9 - AGUARDA PROPOSTA FIS *      */
        /*"      *                                                                *      */
        /*"      *                             PARA ELIMINAR NAO CONFORMIDADE     *      */
        /*"      *                             NA BAIXA DE RCAP                   *      */
        /*"      *                                                                *      */
        /*"      *                             PROCURE POR V.01.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   24/08/2006                FAST COMPUTER                      *      */
        /*"      *                             PASSA A APROPRIAR O CODIGO DE      *      */
        /*"      *                             PRODUTO DA PRODUTOS_VG;            *      */
        /*"      *                                                                *      */
        /*"      *                             PASSA A APROPRIAR RCAPS SOMENTE    *      */
        /*"      *                             PARA PROPOSTAS EMITIDAS OU         *      */
        /*"      *                             NAO ACEITAS;                       *      */
        /*"      *                                                                *      */
        /*"      *                             DESFEITA TAMBEM A ALTERACAO        *      */
        /*"      *                             DE 27/01/2006 POR NAO TER          *      */
        /*"      *                             SORTIDO O EFEITO ESPERADO          *      */
        /*"      *                             PROCURE POR FC0608.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   27/01/2006                TERCIO CARVALHO                    *      */
        /*"      *                             PASSA A APROPRIAR RCAPS SOMENTE    *      */
        /*"      *                             PARA PROPOSTAS EMITIDAS            *      */
        /*"      *                             PROCURE POR TL0601.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   28/11/2005                TERCIO CARVALHO                    *      */
        /*"      *                             PASSA A GERAR ENDOSSOS DE RESTI-   *      */
        /*"      *                             TUICAO PARA ELIMINAR PROBLEMA NA   *      */
        /*"      *                             GERACAO DO QUADRO 272 DA FIP PARA  *      */
        /*"      *                             A SUSEP.                           *      */
        /*"      *                             PROCURE TL0511.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   31/05/2003                TERCIO CARVALHO                    *      */
        /*"      *                             NAO PERMITE O PROCESSAMENTO DE     *      */
        /*"      *                             SUBGRUPO IGUAL A ZERO.             *      */
        /*"      *                             PROCURE POR TL0305.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   02/08/2002                FREDERICO / MESSIAS                *      */
        /*"      *                             CORRECAO NO CALCULO DOS PERCENTUAIS*      */
        /*"      *                             DE COBERTURA E PREMIOS DO RAMO 81  *      */
        /*"      *                             PARA EVITAR A GERACAO DE PREMIOS/CO*      */
        /*"      *                             BETURAS NEGATIVOS PARA A DIT.      *      */
        /*"      *                             PROCURE POR MF0208.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   03/12/2001                TERCIO CARVALHO                    *      */
        /*"      *                             PASSA A NAO MAIS BAIXAR O RCAP     *      */
        /*"      *                             QUE SERA BAIXADO QUANDO DA EMISSAO *      */
        /*"      *                             DA PROPOSTA PELO VA0118B.          *      */
        /*"      *                             PROCURE POR TL0112.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   01/12/2001                TERCIO CARVALHO                    *      */
        /*"      *                             PASSA A NAO MAIS ABENDAR QUANDO    *      */
        /*"      *                             ENCONTRA APOLICE EXPIRADA          *      */
        /*"      *                             PROCURE POR TL0112.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   06/06/2001                MESSIAS / FREDERICO                *      */
        /*"      *                             PASSA A TRATAR O ERRO -811 NA LEI- *      */
        /*"      *                             TURA DA V0RCAPCOMP.                *      */
        /*"      *                             PROCURE POR MM0601.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   17/04/2000                TERCIO                             *      */
        /*"      *                             PASSA A RECUPERAR O NUMERO DO RCAP *      */
        /*"      *                             A PARTIR DA CONVERSAO_SICOB PARA   *      */
        /*"      *                             PROPOSTAS ORIUNDAS DO SIVPF.       *      */
        /*"      *                             PROCURE POR TL0004.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   07/01/1999                FONSECA                            *      */
        /*"      *                             O PROGRAMA NAO ESTAVA BAIXANDO OS  *      */
        /*"      *                             RCAP S DO FEDERAL PLUS.            *      */
        /*"      *                             PROCURE POR AF0001.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   06/12/1999                FONSECA                            *      */
        /*"      *                             PASSA A INCLUIR NA V0EMISDIARIA A  *      */
        /*"      *                             SOLICITACAO DE EMISSAO DA ESPECI-  *      */
        /*"      *                             FICACAO DE COSSEGURO PARA CADA     *      */
        /*"      *                             ENDOSSO EMITIDO/COSSEGURADORA.     *      */
        /*"      *                             PROCURE POR AF9912.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   11/08/1999                FONSECA                            *      */
        /*"      *                             TRATA A ESTRUTURA DE COBRANCA DO   *      */
        /*"      *                             FEDERAL PLUS E CONTABILIZA A       *      */
        /*"      *                             COBERTURA DE REEMBOLSO POR TRANS-  *      */
        /*"      *                             PLANTE DE ORGAOS NO RAMO 86,       *      */
        /*"      *                             SUBTRAINDO O PREMIO DO RAMO VG     *      */
        /*"      *                             PROCURE AF9908.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   24/06/1999                TERCIO                             *      */
        /*"      *                             NAO UTILIZA MAIS CODIGO PRODUTO.   *      */
        /*"      *                             PROCURE TL9906.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   23/11/1998                CLOVIS                             *      */
        /*"      *                             ALTERA V0AVISOS_SALDOS.            *      */
        /*"      *                             PROCURE CL9811.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   09/10/1998                TERCIO                             *      */
        /*"      *                             CONVERTE FONTE 0 PARA FONTE 5      *      */
        /*"      *                             PARA QUE NAO SEJA GERADO ENDOSSO   *      */
        /*"      *                             NA FONTE 0, CAUSANDO PROBLEMAS     *      */
        /*"      *                             PARA A CONTABILIDADE.              *      */
        /*"      *                             PROCURE TL9810.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  10/11/1997                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO HISTORICO DE           *      */
        /*"      *                             CONTABILIZACAO DE PARCELAS         *      */
        /*"      *                             (V0HISTCONTABILVA), GERA O ENDOSSO *      */
        /*"      *                             CORRESPONDENTE PARA REGISTRAR A    *      */
        /*"      *                             EMISSAO E A COBRANCA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * HISTORICO CONTABIL DE PARCELAS VA   V0HISTCONTABILVA  I-O      *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           I-O      *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * APOLICE COSSEGURO                   V1APOLCOSCED      INPUT    *      */
        /*"      * PARCELAS                            V0PARCELA         OUTPUT   *      */
        /*"      * HISTORICO DE PARCELAS               V0HISTOPARC       OUTPUT   *      */
        /*"      * COBERTURA APOLICES                  V0COBERAPOL       OUTPUT   *      */
        /*"      * ORDEM COSSEGURO CEDIDO              V0ORDECOSCED      OUTPUT   *      */
        /*"      * NUMERACAO GERAL                     V0NUMERO_AES      I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public SortBasis<VA0139B_REG_SVA0139B> SVA0139B { get; set; } = new SortBasis<VA0139B_REG_SVA0139B>(new VA0139B_REG_SVA0139B());
        /*"01            REG-SVA0139B.*/
        public VA0139B_REG_SVA0139B REG_SVA0139B { get; set; } = new VA0139B_REG_SVA0139B();
        public class VA0139B_REG_SVA0139B : VarBasis
        {
            /*"    05        SVA-SITUACAO        PIC  X(001).*/
            public StringBasis SVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-SITUACAO-P      PIC  X(001).*/
            public StringBasis SVA_SITUACAO_P { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-NUM-APOLICE     PIC S9(013)    COMP-3.*/
            public IntBasis SVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        SVA-CODSUBES        PIC S9(004)    COMP.*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-FONTE           PIC S9(004)    COMP.*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-PRMVG           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-PRMAP           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-CODOPER         PIC S9(004)    COMP.*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-NRCERTIF        PIC S9(015)    COMP-3.*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        SVA-NRPARCEL        PIC S9(004)    COMP.*/
            public IntBasis SVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-NRTIT           PIC S9(013)    COMP-3.*/
            public IntBasis SVA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        SVA-OCORHIST        PIC S9(004)    COMP.*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-DTMOVTO         PIC  X(010).*/
            public StringBasis SVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-ESTR-COBR       PIC  X(010).*/
            public StringBasis SVA_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-CODPRODU        PIC S9(004)    COMP.*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-IMPMORNATU      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-IMPMORACID      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-IMPINVPERM      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-IMPAMDS         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-IMPDH           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-IMPDIT          PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-PRMDIT          PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"01              V1RIND-RAMO           PIC S9(004)      COMP.*/
        public IntBasis V1RIND_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              V1RIND-DTINIVIG       PIC  X(010).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              V1RIND-PCIOF          PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01              WS-DTRENOVA           PIC X(010).*/
        public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              WS-DTINIVIG           PIC X(010).*/
        public StringBasis WS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              WS-TIME               PIC X(008).*/
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01              WS-IND                PIC S9(004) COMP.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              WS-IND1               PIC S9(004) COMP.*/
        public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              WS-ACUM-IND           PIC S9(003)V99.*/
        public DoubleBasis WS_ACUM_IND { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99."), 2);
        /*"01              WS-ACUM-PRM           PIC S9(013)V99.*/
        public DoubleBasis WS_ACUM_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
        /*"01              WS-ACUM-IOF           PIC S9(13)V99   COMP-3.*/
        public DoubleBasis WS_ACUM_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01              WS-IOF-RAMO           PIC S9(13)V99   COMP-3.*/
        public DoubleBasis WS_IOF_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01         VIND-DATARCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-DTQITBCO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-DTVENCTO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-VLCUSEMI       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-CFPREFIX       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-SITUACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         WHOST-NRCERTIF-ANT   PIC S9(15) COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01         WHOST-CODSUBES       PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01         WHOST-COUNT          PIC S9(09) COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01         NUM-SICOB           PIC S9(15) COMP-3.*/
        public IntBasis NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-CODUSU               PIC X(8).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  V0RELA-DATA-SOLICITACAO     PIC X(10).*/
        public StringBasis V0RELA_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-IDSISTEM             PIC X(2).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"01  V0RELA-CODRELAT             PIC X(8).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  V0RELA-NRCOPIAS             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-QUANTIDADE           PIC S9(04) COMP.*/
        public IntBasis V0RELA_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PERI-INICIAL         PIC X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-PERI-FINAL           PIC X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-DATA-REFERENCIA      PIC X(10).*/
        public StringBasis V0RELA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-MES-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-ANO-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-ORGAO                PIC S9(04) COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-MODALIDA             PIC S9(04) COMP.*/
        public IntBasis V0RELA_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CONGENER             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NRCERTIF             PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-NRTIT                PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-CODSUBES             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-COD-PLANO            PIC S9(04) COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-OCORHIST             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-APOLIDER             PIC X(15).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-ENDOSLID             PIC X(15).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-NUM-PARC-LIDER       PIC S9(04) COMP.*/
        public IntBasis V0RELA_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NUM-SINISTRO         PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis V0RELA_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-NUM-ORDEM            PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-CODUNIMO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CORRECAO             PIC X(1).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-SITUACAO             PIC X(1).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-PREVIA-DEFINITIVA    PIC X(1).*/
        public StringBasis V0RELA_PREVIA_DEFINITIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-ANAL-RESUMO          PIC X(1).*/
        public StringBasis V0RELA_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-PERI-RENOVACAO       PIC S9(04) COMP.*/
        public IntBasis V0RELA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PCT-AUMENTO          PIC S9(3)V9(2) COMP-3.*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"01  V0RELA-TIMESTAMP            PIC X(26).*/
        public StringBasis V0RELA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HCTB-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0HCTB-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HCTB-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HCTB-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-OPCAO-COBER  PIC S9(004)               COMP.*/
        public IntBasis V0HCTB_OPCAO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0HCTB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0HCTB-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0HCTB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0HCTB-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-SITUACAO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HCTB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0HCTB-DTMOVTO      PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCTB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCTB-NRENDOS      PIC S9(009)      COMP.*/
        public IntBasis V0HCTB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PROP-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-SITUACAO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0APOL-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-MODALIDA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-ORGAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-IDADE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-OPCAO-COBER  PIC  X(001).*/
        public StringBasis V0PROP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0COND-IEA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPD          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0PLAN-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0PLAN-IPRMDIT      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PLAN_IPRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PLAN-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAMDS      PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPDH        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-PRMDIT-I     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CBPR_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0CBPR-IMPCDG       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAA        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAAF       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPADE       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPADE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1FONT-PROPAUTOM    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V1COSP-CONGENER     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-NUM-APOLICE  PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0ENDO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0ENDO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-NRENDOS-COB  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS_COB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-NRENDOS-RES  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS_RES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-DATPRO       PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DT-LIBER     PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DTEMIS       PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-VLRCAP       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0ENDO-BCORCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-AGERCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-DACRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-IDRCAP       PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-DACCOBR      PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-CDFRACIO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-PCENTRAD     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"01         V0ENDO-PCADICIO     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"01         V0ENDO-PRESTA1      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTPRESTA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTITENS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-CODTXT       PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01         V0ENDO-CDACEITA     PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-MOEDA-IMP    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-MOEDA-PRM    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-COD-USUAR    PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0ENDO-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-SITUACAO     PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-DATARCAP     PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-ISENTA-CST   PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ENDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0ENDO-DTVENCTO     PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-CFPREFIX     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"01         V0ENDO-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0ENDO-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0RCAP-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NOME         PIC  X(040).*/
        public StringBasis V0RCAP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01         V0RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-VALPRI       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0RCAP_VALPRI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0RCAP-DTCADAST     PIC  X(010).*/
        public StringBasis V0RCAP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0RCAP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0RCAP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0RCAP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0RCAP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0RCAP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V2RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V2RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-NRRCAPCO     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-HORAOPER     PIC  X(008).*/
        public StringBasis V1RCAC_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V1RCAC-DTMOVTO      PIC  X(010).*/
        public StringBasis V1RCAC_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITUACAO     PIC  X(001).*/
        public StringBasis V1RCAC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-BCOAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-AGEAVISO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1RCAC-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAC_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAC-DATARCAP     PIC  X(010).*/
        public StringBasis V1RCAC_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-DTCADAST     PIC  X(010).*/
        public StringBasis V1RCAC_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1RCAC-SITCONTB     PIC  X(001).*/
        public StringBasis V1RCAC_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V1RCAC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1RCAC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1RCAC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1NCOS-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-NRORDEM      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-DACPARC      PIC  X(001).*/
        public StringBasis V0PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PARC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-VAL-DES-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNPRLIQ     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNADFRA     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNCUSTO     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNIOF       PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNTOTAL     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-QTDDOC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PARC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0PARC-SIT-COBR     PIC  X(001).*/
        public StringBasis V0PARC_SIT_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-PRM-TARIFA   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VAL-DESCON   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VAL_DESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPRMLIQ     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLADIFRA     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLIOCC       PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPRMTOT     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPREMIO     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-COD-USUAR    PIC  X(008).*/
        public StringBasis V0HISP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0HISP-RNUDOC       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0HISP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0SEGVG-DTINIVIG    PIC  X(010).*/
        public StringBasis V0SEGVG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0SEGVG-DTRENOVA    PIC  X(010).*/
        public StringBasis V0SEGVG_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0SEGVG-DTRENOVA-IND PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0SEGVG_DTRENOVA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0COBA-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-COD-COBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0COBA-PCT-COBERT   PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"01         V0COBA-FATOR-MULT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0COBA-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0COBA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0COBA-SITUACAO     PIC  X(001)       VALUE '0'.*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"01         WS-QTD-SIT-INVAL    PIC  9(008)   VALUE ZEROS.*/
        public IntBasis WS_QTD_SIT_INVAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01         V0ORDC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0ORDC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ORDC-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ORDC-ORDEM-CED    PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_ORDEM_CED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0ORDC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ORDC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ORDC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0PRVG-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PRVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PRVG-CODPRODU     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0PRVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PRVF-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PRVF_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0EDIA-CODRELAT            PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0EDIA-NUM-APOL            PIC S9(013)               COMP-3.*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0EDIA-NRENDOS             PIC S9(009)               COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0EDIA-NRPARCEL            PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-DTMOVTO             PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0EDIA-ORGAO               PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-RAMO                PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-FONTE               PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-CONGENER            PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-CODCORR             PIC S9(009)               COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0EDIA-SITUACAO            PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  REGISTRO-LINKAGE-GE0510S.*/
        public VA0139B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VA0139B_REGISTRO_LINKAGE_GE0510S();
        public class VA0139B_REGISTRO_LINKAGE_GE0510S : VarBasis
        {
            /*"    10 LK-GE510-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"    10 LK-GE510-COD-SUBGRUPO      PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-NUM-CERTIFICADO   PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis LK_GE510_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE510-COD-MODALIDADE    PIC S9(04) USAGE COMP.*/
            public IntBasis LK_GE510_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE510-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE510_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE510-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE510_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE510-MENSAGEM.*/
            public VA0139B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VA0139B_LK_GE510_MENSAGEM();
            public class VA0139B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01         TABELA-RAMO.*/
            }
        }
        public VA0139B_TABELA_RAMO TABELA_RAMO { get; set; } = new VA0139B_TABELA_RAMO();
        public class VA0139B_TABELA_RAMO : VarBasis
        {
            /*"  05       FILLER               OCCURS 100 TIMES.*/
            public ListBasis<VA0139B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VA0139B_FILLER_1>(100);
            public class VA0139B_FILLER_1 : VarBasis
            {
                /*"    10     TB-RAMO-VALOR-IS     PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    10     TB-RAMO-VALOR-PRM    PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"01         TABELA-RAMO-R.*/
            }
        }
        public VA0139B_TABELA_RAMO_R TABELA_RAMO_R { get; set; } = new VA0139B_TABELA_RAMO_R();
        public class VA0139B_TABELA_RAMO_R : VarBasis
        {
            /*"  05       FILLER               OCCURS 100 TIMES.*/
            public ListBasis<VA0139B_FILLER_2> FILLER_2 { get; set; } = new ListBasis<VA0139B_FILLER_2>(100);
            public class VA0139B_FILLER_2 : VarBasis
            {
                /*"    10     TB-RAMO-VALOR-IS-R   PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_IS_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    10     TB-RAMO-VALOR-PRM-R  PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_PRM_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"01         TABELA-ULTIMOS-DIAS.*/
            }
        }
        public VA0139B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA0139B_TABELA_ULTIMOS_DIAS();
        public class VA0139B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VA0139B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VA0139B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VA0139B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VA0139B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VA0139B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA0139B_TAB_DIA_MESES>(12);
            public class VA0139B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VA0139B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VA0139B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VA0139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0139B_AREA_DE_WORK();
        public class VA0139B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VA0139B_WS_DTBASE WS_DTBASE { get; set; } = new VA0139B_WS_DTBASE();
            public class VA0139B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VA0139B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VA0139B_WS_DTBASE_AM();
                public class VA0139B_WS_DTBASE_AM : VarBasis
                {
                    /*"     15         WS-AABASE             PIC 9(004).*/
                    public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMBASE             PIC 9(002).*/
                    public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDBASE             PIC 9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DTFATUR.*/
            }
            public VA0139B_WS_DTFATUR WS_DTFATUR { get; set; } = new VA0139B_WS_DTFATUR();
            public class VA0139B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VA0139B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VA0139B_WS_DTFATUR_AM();
                public class VA0139B_WS_DTFATUR_AM : VarBasis
                {
                    /*"     15         WS-AAFATUR            PIC 9(004).*/
                    public IntBasis WS_AAFATUR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMFATUR            PIC 9(002).*/
                    public IntBasis WS_MMFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDFATUR            PIC 9(002).*/
                public IntBasis WS_DDFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DIA                PIC 9(002).*/
            }
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         AC-FATURA                PIC X(001)  VALUE SPACES.*/
            public StringBasis AC_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PROPOVA             PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0HISTCONTABILVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAP              PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-RAMO-COMP           PIC X(003)  VALUE SPACES.*/
            public StringBasis WTEM_RAMO_COMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WTEM-VG082               PIC X(003)  VALUE SPACES.*/
            public StringBasis WTEM_VG082 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WTEM-RAMO-CONJ           PIC X(003)  VALUE SPACES.*/
            public StringBasis WTEM_RAMO_CONJ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WTEM-V0RCAP              PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-CONVERSAO           PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_CONVERSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0PROPOSTAVA        PIC 9(001)  VALUE 0.*/
            public IntBasis WFIM_V0PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WTEM-HISCOBPR            PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-PRODUVG             PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_PRODUVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-APOLICE-ANT      PIC S9(13)    VALUE +0 COMP-3.*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-SUBGRUPO-ANT     PIC S9(04)    VALUE +0 COMP.*/
            public IntBasis WS_SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NUM-APOLICE-ANT  PIC S9(13)    VALUE +0 COMP-3.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-CODSUBES-ANT     PIC S9(04)    VALUE +0 COMP.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-FONTE-ANT        PIC S9(04)    VALUE +0 COMP.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-PRMVG            PIC ---------------9,99.*/
            public DoubleBasis WS_PRMVG { get; set; } = new DoubleBasis(new PIC("9", "16", "---------------9V99."), 2);
            /*"  05         WS-PRMAP            PIC ---------------9,99.*/
            public DoubleBasis WS_PRMAP { get; set; } = new DoubleBasis(new PIC("9", "16", "---------------9V99."), 2);
            /*"  05         WS-IND-IOF          PIC S9(01)V9(4) VALUE +0 COMP-3*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"  05         WS-VLIOCC           PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-VG        PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-AP        PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-DIT       PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-RTO       PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT       PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-VG    PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-AP    PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-DIT   PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-RTO   PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PREMIO-LIQ       PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PREMIO-LIQ-R     PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PREMIO_LIQ_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-AP       PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-AP-R     PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_AP_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-VG       PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-VG-R     PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_VG_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-DIT      PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-DIT-R    PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_DIT_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-RTO      PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-RTO-R    PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_RTO_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-IMPRTO           PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_IMPRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRMRTO           PIC S9(13)V99  VALUE +0 COMP-3.*/
            public DoubleBasis WS_PRMRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_VA0139B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VA0139B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VA0139B_FILLER_8(); _.Move(WWORK_NUM_ORDEM, _filler_8); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_8, WWORK_NUM_ORDEM); _filler_8.ValueChanged += () => { _.Move(_filler_8, WWORK_NUM_ORDEM); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VA0139B_FILLER_8 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VA0139B_FILLER_8()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VA0139B_WWORK_DATA WWORK_DATA { get; set; } = new VA0139B_WWORK_DATA();
            public class VA0139B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-DIA         PIC  9(002).*/
                public IntBasis WWORK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/
            }
            public VA0139B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VA0139B_WDATA_SISTEMA();
            public class VA0139B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WS-DATE.*/
            }
            public VA0139B_WS_DATE WS_DATE { get; set; } = new VA0139B_WS_DATE();
            public class VA0139B_WS_DATE : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public VA0139B_WDATA_CABEC WDATA_CABEC { get; set; } = new VA0139B_WDATA_CABEC();
            public class VA0139B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05   AC-PRMTOTAL            PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            }
            public DoubleBasis AC_PRMTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMVG               PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMVG-R             PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMVG_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMVG-AUX           PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMVG_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMAP               PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMAP-R             PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMAP_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMAP-AUX           PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMAP_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMDIT              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMDIT-R            PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMDIT_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMDIT-AUX          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMDIT_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMRTO              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMRTO-R            PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMRTO_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PRMRTO-AUX          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PRMRTO_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PREMIO-CDGCA-CONJ   PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PREMIO_CDGCA_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PREMIO-ADE-CONJ     PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PREMIO_ADE_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PREMIO-AA-CONJ      PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PREMIO_AA_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PREMIO-VG-CONJ      PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PREMIO_VG_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-PREMIO-AP-CONJ      PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_PREMIO_AP_CONJ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPCDG              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPAA               PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPAA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPADE              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPADE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPAAF              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPAAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPMORNATU          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPMORNATU-R        PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPMORNATU_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPMORNATU-AUX      PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPMORNATU_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPMORACID          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPMORACID-R        PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPMORACID_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPMORACID-AUX      PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPMORACID_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPINVPERM          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPINVPERM-R        PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPINVPERM_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPINVPERM-AUX      PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPINVPERM_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPAMDS             PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPAMDS-R           PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPAMDS_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPAMDS-AUX         PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPAMDS_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPDH               PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPDH-R             PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPDH_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPDH-AUX           PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPDH_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPDIT              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPDIT-R            PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPDIT_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPDIT-AUX          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPDIT_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPRTO              PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPRTO-R            PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPRTO_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05   AC-IMPRTO-AUX          PIC S9(013)V99 COMP-3 VALUE ZEROES*/
            public DoubleBasis AC_IMPRTO_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-CONTA                PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-TOTAL-ENDOSSO        PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_TOTAL_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-L-ENDOSSO            PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_L_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-L-SORT               PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_L_SORT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-L-V0HISTCONT         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTCONT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0ENDOSSO          PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0RCAPCOMP         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0ORDECOSCED       PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0EMISDIARIA       PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0PARCELA          PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0HISTOPARC        PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0COBERAPOL        PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0RCAP             PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0RCAPCOMP         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0NUMERAES         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERAES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0FONTE            PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FONTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0HISTCONTABILVA   PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0HISTCONTABILVA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0NUMERO-COSSEGURO PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERO_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05        WABEND.*/
            public VA0139B_WABEND WABEND { get; set; } = new VA0139B_WABEND();
            public class VA0139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VA0139B '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA0139B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.GE292 GE292 { get; set; } = new Dclgens.GE292();
        public Dclgens.VG081 VG081 { get; set; } = new Dclgens.VG081();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public VA0139B_CHISTCTBL CHISTCTBL { get; set; } = new VA0139B_CHISTCTBL();
        public VA0139B_CPROPOVA CPROPOVA { get; set; } = new VA0139B_CPROPOVA();
        public VA0139B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VA0139B_V1RCAPCOMP();
        public VA0139B_CVGHISTCONT CVGHISTCONT { get; set; } = new VA0139B_CVGHISTCONT();
        public VA0139B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new VA0139B_V1APOLCOSCED();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVA0139B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVA0139B.SetFile(SVA0139B_FILE_NAME_P);

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
            /*" -974- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -977- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -980- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -983- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -985- DISPLAY 'VA0139B - GERA ENDOSSO DO HISTORICO DE CONTABILIZACA 'O DE PARCELAS' */

            $"VA0139B - GERA ENDOSSO DO HISTORICO DE CONTABILIZACA {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_TIMESTAMP}DEPARCELAS"
            .Display();

            /*" -986- DISPLAY '          PARA REGISTRAR A EMISSAO E COBRANCA   ' */
            _.Display($"          PARA REGISTRAR A EMISSAO E COBRANCA   ");

            /*" -987- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -991- DISPLAY 'VERSAO 26: ' FUNCTION WHEN-COMPILED ' - INC-212.290' */

            $"VERSAO 26: FUNCTION{_.WhenCompiled()} - INC-212.290"
            .Display();

            /*" -992- DISPLAY ' ' */
            _.Display($" ");

            /*" -999- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1000- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1002- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1004- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1011- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -1014- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1016- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1017- MOVE V1SIST-DTMOVABE TO WWORK-DATA. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WWORK_DATA);

            /*" -1018- MOVE 01 TO WWORK-DIA. */
            _.Move(01, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -1020- MOVE WWORK-DATA TO V0ENDO-DTINIVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTINIVIG);

            /*" -1021- MOVE TAB-DIA-MES(WWORK-MES) TO WWORK-DIA. */
            _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WWORK_DATA.WWORK_MES].TAB_DIA_MES, AREA_DE_WORK.WWORK_DATA.WWORK_DIA);

            /*" -1023- MOVE WWORK-DATA TO V0ENDO-DTTERVIG. */
            _.Move(AREA_DE_WORK.WWORK_DATA, V0ENDO_DTTERVIG);

            /*" -1026- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1031- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -1035- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1037- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1038- DISPLAY 'DATA SISTEMA "EM": ' V1SIST-DTMOVABE. */

            $"DATA SISTEMA EM: {V1SIST_DTMOVABE}"
            .Display();

            /*" -1039- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

            /*" -1040- DISPLAY 'INICIO VIGENCIA  : ' V0ENDO-DTINIVIG. */
            _.Display($"INICIO VIGENCIA  : {V0ENDO_DTINIVIG}");

            /*" -1043- DISPLAY 'TERMINO VIGENCIA : ' V0ENDO-DTTERVIG. */
            _.Display($"TERMINO VIGENCIA : {V0ENDO_DTTERVIG}");

            /*" -1068- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -1074- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1074- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -1078- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1081- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1083- PERFORM R0810-00-FETCH-HISCONPA. */

            R0810_00_FETCH_HISCONPA_SECTION();

            /*" -1084- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
            {

                /*" -1086- DISPLAY 'VA0139B - NENHUMA COBRANCA ENCONTRADA' */
                _.Display($"VA0139B - NENHUMA COBRANCA ENCONTRADA");

                /*" -1088- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1090- MOVE +600000 TO SORT-FILE-SIZE. */
            _.Move(+600000, SORT_FILE_SIZE);

            /*" -1097- SORT SVA0139B ON ASCENDING KEY SVA-SITUACAO SVA-NUM-APOLICE SVA-CODSUBES SVA-FONTE INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-OUTPUT THRU R0020-FIM. */
            SVA0139B.Sort("SVA-SITUACAO,SVA-NUM-APOLICE,SVA-CODSUBES,SVA-FONTE", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_OUTPUT_SECTION());

            /*" -1102- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1105- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1105- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1111- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1112- MOVE 'VA0139B' TO V0RELA-CODUSU */
            _.Move("VA0139B", V0RELA_CODUSU);

            /*" -1113- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -1114- MOVE 'VA' TO V0RELA-IDSISTEM */
            _.Move("VA", V0RELA_IDSISTEM);

            /*" -1115- MOVE 'VA0417B' TO V0RELA-CODRELAT */
            _.Move("VA0417B", V0RELA_CODRELAT);

            /*" -1116- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -1117- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -1118- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -1119- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -1120- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -1121- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -1122- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -1123- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -1124- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -1125- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -1126- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -1127- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -1128- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -1129- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -1130- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -1131- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -1132- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -1133- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -1134- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -1135- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -1136- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -1137- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -1138- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -1139- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -1140- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -1141- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -1142- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -1143- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -1144- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -1145- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -1146- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -1147- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -1148- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -1149- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -1150- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -1152- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -1155- MOVE ZEROS TO WHOST-COUNT. */
            _.Move(0, WHOST_COUNT);

            /*" -1162- PERFORM R0000_00_PRINCIPAL_DB_SELECT_3 */

            R0000_00_PRINCIPAL_DB_SELECT_3();

            /*" -1166- IF WHOST-COUNT NOT EQUAL ZEROS */

            if (WHOST_COUNT != 00)
            {

                /*" -1169- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1212- PERFORM R0000_00_PRINCIPAL_DB_INSERT_1 */

            R0000_00_PRINCIPAL_DB_INSERT_1();

            /*" -1216- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -1217- DISPLAY 'B0300-10 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B0300-10 (REGISTRO DUPLICADO) ... ");

                /*" -1219- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1220- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1221- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -1221- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1011- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1228- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1229- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1231- DISPLAY '*--------  VA0139B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VA0139B - FIM NORMAL  --------*");

            /*" -1231- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -1068- EXEC SQL DECLARE CHISTCTBL CURSOR FOR SELECT A.SITUACAO, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.PRMVG, A.PRMAP, A.CODOPER, A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.OCOORHIST, A.DTMOVTO FROM SEGUROS.V0HISTCONTABILVA A, SEGUROS.V0PROPOSTAVA B WHERE A.DTFATUR IS NULL AND A.SITUACAO IN ( '0' , '3' ) AND A.NUM_APOLICE > +0 AND A.CODSUBES > +0 AND A.NUM_APOLICE <> 103701139293 AND A.NUM_APOLICE <> 103701139296 AND B.NRCERTIF = A.NRCERTIF AND B.SITUACAO IN ( '3' , '4' , '6' ) ORDER BY A.NUM_APOLICE , A.CODSUBES, A.NRCERTIF END-EXEC. */
            CHISTCTBL = new VA0139B_CHISTCTBL(false);
            string GetQuery_CHISTCTBL()
            {
                var query = @$"SELECT A.SITUACAO
							, 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.FONTE
							, 
							A.PRMVG
							, 
							A.PRMAP
							, 
							A.CODOPER
							, 
							A.NRCERTIF
							, 
							A.NRPARCEL
							, 
							A.NRTIT
							, 
							A.OCOORHIST
							, 
							A.DTMOVTO 
							FROM SEGUROS.V0HISTCONTABILVA A
							, 
							SEGUROS.V0PROPOSTAVA B 
							WHERE A.DTFATUR IS NULL 
							AND A.SITUACAO IN ( '0'
							, '3' ) 
							AND A.NUM_APOLICE > +0 
							AND A.CODSUBES > +0 
							AND A.NUM_APOLICE <> 103701139293 
							AND A.NUM_APOLICE <> 103701139296 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.SITUACAO IN ( '3'
							, '4'
							, '6' ) 
							ORDER BY A.NUM_APOLICE
							, A.CODSUBES
							, A.NRCERTIF";

                return query;
            }
            CHISTCTBL.GetQueryEvent += GetQuery_CHISTCTBL;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -1074- EXEC SQL OPEN CHISTCTBL END-EXEC. */

            CHISTCTBL.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -1362- EXEC SQL DECLARE CPROPOVA CURSOR FOR SELECT SITUACAO, OCORHIST FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :V0HCTB-NRCERTIF END-EXEC. */
            CPROPOVA = new VA0139B_CPROPOVA(true);
            string GetQuery_CPROPOVA()
            {
                var query = @$"SELECT SITUACAO
							, 
							OCORHIST 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE NRCERTIF = '{V0HCTB_NRCERTIF}'";

                return query;
            }
            CPROPOVA.GetQueryEvent += GetQuery_CPROPOVA;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -1031- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-INSERT-1 */
        public void R0000_00_PRINCIPAL_DB_INSERT_1()
        {
            /*" -1212- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r0000_00_PRINCIPAL_DB_INSERT_1_Insert1 = new R0000_00_PRINCIPAL_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DATA_SOLICITACAO = V0RELA_DATA_SOLICITACAO.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QUANTIDADE = V0RELA_QUANTIDADE.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFERENCIA = V0RELA_DATA_REFERENCIA.ToString(),
                V0RELA_MES_REFERENCIA = V0RELA_MES_REFERENCIA.ToString(),
                V0RELA_ANO_REFERENCIA = V0RELA_ANO_REFERENCIA.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALIDA = V0RELA_MODALIDA.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOLICE = V0RELA_NUM_APOLICE.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOLIDER = V0RELA_APOLIDER.ToString(),
                V0RELA_ENDOSLID = V0RELA_ENDOSLID.ToString(),
                V0RELA_NUM_PARC_LIDER = V0RELA_NUM_PARC_LIDER.ToString(),
                V0RELA_NUM_SINISTRO = V0RELA_NUM_SINISTRO.ToString(),
                V0RELA_NUM_SINI_LIDER = V0RELA_NUM_SINI_LIDER.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PREVIA_DEFINITIVA = V0RELA_PREVIA_DEFINITIVA.ToString(),
                V0RELA_ANAL_RESUMO = V0RELA_ANAL_RESUMO.ToString(),
                V0RELA_COD_EMPRESA = V0RELA_COD_EMPRESA.ToString(),
                V0RELA_PERI_RENOVACAO = V0RELA_PERI_RENOVACAO.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
            };

            R0000_00_PRINCIPAL_DB_INSERT_1_Insert1.Execute(r0000_00_PRINCIPAL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-3 */
        public void R0000_00_PRINCIPAL_DB_SELECT_3()
        {
            /*" -1162- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-COUNT FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA0417B' AND SITUACAO = '0' END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_3_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_3_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1244- PERFORM R0030-00-PROCESSA-INPUT UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R0030_00_PROCESSA_INPUT_SECTION();
            }

            /*" -1244- MOVE ZEROS TO AC-CONTA. */
            _.Move(0, AREA_DE_WORK.AC_CONTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-OUTPUT-SECTION */
        private void R0020_00_OUTPUT_SECTION()
        {
            /*" -1255- MOVE SPACES TO WFIM-V0HISTCONTABILVA. */
            _.Move("", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

            /*" -1257- PERFORM R0920-00-LEITURA-SVA0139B. */

            R0920_00_LEITURA_SVA0139B_SECTION();

            /*" -1258- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0030-00-PROCESSA-INPUT-SECTION */
        private void R0030_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1271- MOVE 'N' TO WFIM-PROPOVA */
            _.Move("N", AREA_DE_WORK.WFIM_PROPOVA);

            /*" -1272- PERFORM R0900-00-DECLARE-CURSOR */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -1273- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -1276- PERFORM R0035-00-PROCESSA-PROPOVA UNTIL WFIM-PROPOVA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_PROPOVA == "S"))
            {

                R0035_00_PROCESSA_PROPOVA_SECTION();
            }

            /*" -1276- PERFORM R0810-00-FETCH-HISCONPA. */

            R0810_00_FETCH_HISCONPA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_FIM*/

        [StopWatch]
        /*" R0035-00-PROCESSA-PROPOVA-SECTION */
        private void R0035_00_PROCESSA_PROPOVA_SECTION()
        {
            /*" -1285- MOVE V0HCTB-SITUACAO TO SVA-SITUACAO */
            _.Move(V0HCTB_SITUACAO, REG_SVA0139B.SVA_SITUACAO);

            /*" -1286- MOVE V0PROP-SITUACAO TO SVA-SITUACAO-P */
            _.Move(V0PROP_SITUACAO, REG_SVA0139B.SVA_SITUACAO_P);

            /*" -1287- MOVE V0HCTB-NUM-APOLICE TO SVA-NUM-APOLICE */
            _.Move(V0HCTB_NUM_APOLICE, REG_SVA0139B.SVA_NUM_APOLICE);

            /*" -1288- MOVE V0HCTB-CODSUBES TO SVA-CODSUBES */
            _.Move(V0HCTB_CODSUBES, REG_SVA0139B.SVA_CODSUBES);

            /*" -1289- MOVE V0HCTB-FONTE TO SVA-FONTE */
            _.Move(V0HCTB_FONTE, REG_SVA0139B.SVA_FONTE);

            /*" -1290- MOVE V0HCTB-PRMVG TO SVA-PRMVG */
            _.Move(V0HCTB_PRMVG, REG_SVA0139B.SVA_PRMVG);

            /*" -1291- MOVE V0HCTB-PRMAP TO SVA-PRMAP */
            _.Move(V0HCTB_PRMAP, REG_SVA0139B.SVA_PRMAP);

            /*" -1292- MOVE V0HCTB-CODOPER TO SVA-CODOPER */
            _.Move(V0HCTB_CODOPER, REG_SVA0139B.SVA_CODOPER);

            /*" -1293- MOVE V0HCTB-NRCERTIF TO SVA-NRCERTIF */
            _.Move(V0HCTB_NRCERTIF, REG_SVA0139B.SVA_NRCERTIF);

            /*" -1294- MOVE V0HCTB-NRPARCEL TO SVA-NRPARCEL */
            _.Move(V0HCTB_NRPARCEL, REG_SVA0139B.SVA_NRPARCEL);

            /*" -1295- MOVE V0HCTB-NRTIT TO SVA-NRTIT */
            _.Move(V0HCTB_NRTIT, REG_SVA0139B.SVA_NRTIT);

            /*" -1296- MOVE V0HCTB-OCORHIST TO SVA-OCORHIST */
            _.Move(V0HCTB_OCORHIST, REG_SVA0139B.SVA_OCORHIST);

            /*" -1297- MOVE V0HCTB-DTMOVTO TO SVA-DTMOVTO */
            _.Move(V0HCTB_DTMOVTO, REG_SVA0139B.SVA_DTMOVTO);

            /*" -1298- MOVE V0PRVG-ESTR-COBR TO SVA-ESTR-COBR */
            _.Move(V0PRVG_ESTR_COBR, REG_SVA0139B.SVA_ESTR_COBR);

            /*" -1299- MOVE V0PRVG-CODPRODU TO SVA-CODPRODU */
            _.Move(V0PRVG_CODPRODU, REG_SVA0139B.SVA_CODPRODU);

            /*" -1300- MOVE V0CBPR-IMPMORNATU TO SVA-IMPMORNATU */
            _.Move(V0CBPR_IMPMORNATU, REG_SVA0139B.SVA_IMPMORNATU);

            /*" -1301- MOVE V0CBPR-IMPMORACID TO SVA-IMPMORACID */
            _.Move(V0CBPR_IMPMORACID, REG_SVA0139B.SVA_IMPMORACID);

            /*" -1302- MOVE V0CBPR-IMPINVPERM TO SVA-IMPINVPERM */
            _.Move(V0CBPR_IMPINVPERM, REG_SVA0139B.SVA_IMPINVPERM);

            /*" -1303- MOVE V0CBPR-IMPAMDS TO SVA-IMPAMDS */
            _.Move(V0CBPR_IMPAMDS, REG_SVA0139B.SVA_IMPAMDS);

            /*" -1304- MOVE V0CBPR-IMPDH TO SVA-IMPDH */
            _.Move(V0CBPR_IMPDH, REG_SVA0139B.SVA_IMPDH);

            /*" -1305- MOVE V0CBPR-IMPDIT TO SVA-IMPDIT */
            _.Move(V0CBPR_IMPDIT, REG_SVA0139B.SVA_IMPDIT);

            /*" -1307- MOVE V0CBPR-PRMDIT TO SVA-PRMDIT */
            _.Move(V0CBPR_PRMDIT, REG_SVA0139B.SVA_PRMDIT);

            /*" -1309- RELEASE REG-SVA0139B. */
            SVA0139B.Release(REG_SVA0139B);

            /*" -1309- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_FIM*/

        [StopWatch]
        /*" R0810-00-FETCH-HISCONPA-SECTION */
        private void R0810_00_FETCH_HISCONPA_SECTION()
        {
            /*" -1322- MOVE '0810' TO WNR-EXEC-SQL. */
            _.Move("0810", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1335- PERFORM R0810_00_FETCH_HISCONPA_DB_FETCH_1 */

            R0810_00_FETCH_HISCONPA_DB_FETCH_1();

            /*" -1339- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1340- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1340- PERFORM R0810_00_FETCH_HISCONPA_DB_CLOSE_1 */

                    R0810_00_FETCH_HISCONPA_DB_CLOSE_1();

                    /*" -1342- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -1343- MOVE ZEROS TO AC-CONTA */
                    _.Move(0, AREA_DE_WORK.AC_CONTA);

                    /*" -1344- GO TO R0810-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0810_99_SAIDA*/ //GOTO
                    return;

                    /*" -1345- ELSE */
                }
                else
                {


                    /*" -1345- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0810-00-FETCH-HISCONPA-DB-FETCH-1 */
        public void R0810_00_FETCH_HISCONPA_DB_FETCH_1()
        {
            /*" -1335- EXEC SQL FETCH CHISTCTBL INTO :V0HCTB-SITUACAO , :V0HCTB-NUM-APOLICE , :V0HCTB-CODSUBES , :V0HCTB-FONTE , :V0HCTB-PRMVG , :V0HCTB-PRMAP , :V0HCTB-CODOPER , :V0HCTB-NRCERTIF , :V0HCTB-NRPARCEL , :V0HCTB-NRTIT , :V0HCTB-OCORHIST , :V0HCTB-DTMOVTO END-EXEC. */

            if (CHISTCTBL.Fetch())
            {
                _.Move(CHISTCTBL.V0HCTB_SITUACAO, V0HCTB_SITUACAO);
                _.Move(CHISTCTBL.V0HCTB_NUM_APOLICE, V0HCTB_NUM_APOLICE);
                _.Move(CHISTCTBL.V0HCTB_CODSUBES, V0HCTB_CODSUBES);
                _.Move(CHISTCTBL.V0HCTB_FONTE, V0HCTB_FONTE);
                _.Move(CHISTCTBL.V0HCTB_PRMVG, V0HCTB_PRMVG);
                _.Move(CHISTCTBL.V0HCTB_PRMAP, V0HCTB_PRMAP);
                _.Move(CHISTCTBL.V0HCTB_CODOPER, V0HCTB_CODOPER);
                _.Move(CHISTCTBL.V0HCTB_NRCERTIF, V0HCTB_NRCERTIF);
                _.Move(CHISTCTBL.V0HCTB_NRPARCEL, V0HCTB_NRPARCEL);
                _.Move(CHISTCTBL.V0HCTB_NRTIT, V0HCTB_NRTIT);
                _.Move(CHISTCTBL.V0HCTB_OCORHIST, V0HCTB_OCORHIST);
                _.Move(CHISTCTBL.V0HCTB_DTMOVTO, V0HCTB_DTMOVTO);
            }

        }

        [StopWatch]
        /*" R0810-00-FETCH-HISCONPA-DB-CLOSE-1 */
        public void R0810_00_FETCH_HISCONPA_DB_CLOSE_1()
        {
            /*" -1340- EXEC SQL CLOSE CHISTCTBL END-EXEC */

            CHISTCTBL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0810_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -1356- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1362- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -1366- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1366- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -1366- EXEC SQL OPEN CPROPOVA END-EXEC. */

            CPROPOVA.Open();

        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -3169- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */
            V1RCAPCOMP = new VA0139B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT FONTE
							, 
							NRRCAP
							, 
							NRRCAPCO
							, 
							OPERACAO
							, 
							DTMOVTO
							, 
							HORAOPER
							, 
							SITUACAO
							, 
							BCOAVISO
							, 
							AGEAVISO
							, 
							NRAVISO
							, 
							VLRCAP
							, 
							DATARCAP
							, 
							DTCADAST
							, 
							SITCONTB 
							FROM SEGUROS.V1RCAPCOMP 
							WHERE FONTE = '{V0RCAP_FONTE}' 
							AND NRRCAP = '{V0RCAP_NRRCAP}' 
							AND OPERACAO >= 100 
							AND OPERACAO <= 199 
							AND SITUACAO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -1379- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1382- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -1386- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1387- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1387- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                    R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                    /*" -1389- MOVE 'S' TO WFIM-PROPOVA */
                    _.Move("S", AREA_DE_WORK.WFIM_PROPOVA);

                    /*" -1390- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1391- ELSE */
                }
                else
                {


                    /*" -1393- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1394- IF V0CBPR-PRMDIT-I LESS ZEROS */

            if (V0CBPR_PRMDIT_I < 00)
            {

                /*" -1396- MOVE ZEROS TO V0CBPR-PRMDIT. */
                _.Move(0, V0CBPR_PRMDIT);
            }


            /*" -1399- ADD 1 TO AC-L-V0HISTCONT AC-CONTA. */
            AREA_DE_WORK.AC_L_V0HISTCONT.Value = AREA_DE_WORK.AC_L_V0HISTCONT + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -1400- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -1401- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1402- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1406- DISPLAY 'LIDOS HISCONPA ... ' AC-L-V0HISTCONT ' ' V0HCTB-NRCERTIF ' ' WS-TIME */

                $"LIDOS HISCONPA ... {AREA_DE_WORK.AC_L_V0HISTCONT} {V0HCTB_NRCERTIF} {WS_TIME}"
                .Display();

                /*" -1408- END-IF. */
            }


            /*" -1409- IF V0HCTB-FONTE EQUAL ZEROS */

            if (V0HCTB_FONTE == 00)
            {

                /*" -1411- MOVE 5 TO V0HCTB-FONTE. */
                _.Move(5, V0HCTB_FONTE);
            }


            /*" -1412- IF V0HCTB-DTMOVTO GREATER V1SIST-DTMOVABE */

            if (V0HCTB_DTMOVTO > V1SIST_DTMOVABE)
            {

                /*" -1415- GO TO R0910-00-FETCH-PROPOVA. */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1417- PERFORM R0915-00-SELECT-HISCOBPR. */

            R0915_00_SELECT_HISCOBPR_SECTION();

            /*" -1418- IF WTEM-HISCOBPR EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_HISCOBPR == "N")
            {

                /*" -1421- GO TO R0910-00-FETCH-PROPOVA. */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1423- IF V0HCTB-NUM-APOLICE NOT EQUAL WS-APOLICE-ANT OR V0HCTB-CODSUBES NOT EQUAL WS-SUBGRUPO-ANT */

            if (V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_APOLICE_ANT || V0HCTB_CODSUBES != AREA_DE_WORK.WS_SUBGRUPO_ANT)
            {

                /*" -1424- MOVE V0HCTB-NUM-APOLICE TO WS-APOLICE-ANT */
                _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_APOLICE_ANT);

                /*" -1425- MOVE V0HCTB-CODSUBES TO WS-SUBGRUPO-ANT */
                _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_SUBGRUPO_ANT);

                /*" -1426- PERFORM R0916-00-SELECT-PRODUVG */

                R0916_00_SELECT_PRODUVG_SECTION();

                /*" -1428- END-IF */
            }


            /*" -1429- IF WTEM-PRODUVG EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_PRODUVG == "N")
            {

                /*" -1430- GO TO R0910-00-FETCH-PROPOVA */
                new Task(() => R0910_00_FETCH_PROPOVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1430- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -1382- EXEC SQL FETCH CPROPOVA INTO :V0PROP-SITUACAO , :V0PROP-OCORHIST END-EXEC. */

            if (CPROPOVA.Fetch())
            {
                _.Move(CPROPOVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPOVA.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -1387- EXEC SQL CLOSE CPROPOVA END-EXEC */

            CPROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0915-00-SELECT-HISCOBPR-SECTION */
        private void R0915_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1442- MOVE '0915' TO WNR-EXEC-SQL. */
            _.Move("0915", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1444- MOVE 'S' TO WTEM-HISCOBPR */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -1462- PERFORM R0915_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R0915_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1465- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1466- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1467- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -1468- ELSE */
                }
                else
                {


                    /*" -1469- DISPLAY 'R0915-00 - FALHA NA CONSULTA V0COBERPROPVA' */
                    _.Display($"R0915-00 - FALHA NA CONSULTA V0COBERPROPVA");

                    /*" -1470- DISPLAY 'NRCERTIF      = ' V0HCTB-NRCERTIF */
                    _.Display($"NRCERTIF      = {V0HCTB_NRCERTIF}");

                    /*" -1471- DISPLAY 'OCORHIST      = ' V0PROP-OCORHIST */
                    _.Display($"OCORHIST      = {V0PROP_OCORHIST}");

                    /*" -1472- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1473- END-IF */
                }


                /*" -1473- END-IF. */
            }


        }

        [StopWatch]
        /*" R0915-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R0915_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1462- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, PRMDIT INTO :V0CBPR-IMPMORNATU , :V0CBPR-IMPMORACID , :V0CBPR-IMPINVPERM , :V0CBPR-IMPAMDS , :V0CBPR-IMPDH , :V0CBPR-IMPDIT , :V0CBPR-PRMDIT:V0CBPR-PRMDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r0915_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CBPR_IMPMORNATU, V0CBPR_IMPMORNATU);
                _.Move(executed_1.V0CBPR_IMPMORACID, V0CBPR_IMPMORACID);
                _.Move(executed_1.V0CBPR_IMPINVPERM, V0CBPR_IMPINVPERM);
                _.Move(executed_1.V0CBPR_IMPAMDS, V0CBPR_IMPAMDS);
                _.Move(executed_1.V0CBPR_IMPDH, V0CBPR_IMPDH);
                _.Move(executed_1.V0CBPR_IMPDIT, V0CBPR_IMPDIT);
                _.Move(executed_1.V0CBPR_PRMDIT, V0CBPR_PRMDIT);
                _.Move(executed_1.V0CBPR_PRMDIT_I, V0CBPR_PRMDIT_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0915_99_SAIDA*/

        [StopWatch]
        /*" R0916-00-SELECT-PRODUVG-SECTION */
        private void R0916_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1485- MOVE '0916' TO WNR-EXEC-SQL. */
            _.Move("0916", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1487- MOVE 'S' TO WTEM-PRODUVG */
            _.Move("S", AREA_DE_WORK.WTEM_PRODUVG);

            /*" -1502- PERFORM R0916_00_SELECT_PRODUVG_DB_SELECT_1 */

            R0916_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1505- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1506- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1507- MOVE 'N' TO WTEM-PRODUVG */
                    _.Move("N", AREA_DE_WORK.WTEM_PRODUVG);

                    /*" -1508- ELSE */
                }
                else
                {


                    /*" -1509- DISPLAY 'R0916-00 - FALHA NA CONSULTA V0PRODUTOSVG' */
                    _.Display($"R0916-00 - FALHA NA CONSULTA V0PRODUTOSVG");

                    /*" -1510- DISPLAY 'NUM_APOLICE   = ' V0HCTB-NUM-APOLICE */
                    _.Display($"NUM_APOLICE   = {V0HCTB_NUM_APOLICE}");

                    /*" -1511- DISPLAY 'CODSUBES      = ' V0HCTB-CODSUBES */
                    _.Display($"CODSUBES      = {V0HCTB_CODSUBES}");

                    /*" -1512- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1513- END-IF */
                }


                /*" -1513- END-IF. */
            }


        }

        [StopWatch]
        /*" R0916-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R0916_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1502- EXEC SQL SELECT ESTR_COBR, CODPRODU INTO :V0PRVG-ESTR-COBR , :V0PRVG-CODPRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND CODSUBES = :V0HCTB-CODSUBES AND DIA_FATURA = 31 AND ESTR_COBR IN ( 'MULT' , 'FEDERAL' ) AND ORIG_PRODU NOT IN ( 'EMPRE' , 'ESPEC' , 'ESPE1' , 'ESPE2' , 'ESPE3' , 'ESPE4' , 'ESPE5' , 'ESPE6' , 'GLOBAL' ) END-EXEC. */

            var r0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0HCTB_CODSUBES = V0HCTB_CODSUBES.ToString(),
            };

            var executed_1 = R0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r0916_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRVG_ESTR_COBR, V0PRVG_ESTR_COBR);
                _.Move(executed_1.V0PRVG_CODPRODU, V0PRVG_CODPRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0916_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-LEITURA-SVA0139B-SECTION */
        private void R0920_00_LEITURA_SVA0139B_SECTION()
        {
            /*" -1524- RETURN SVA0139B AT END */
            try
            {
                SVA0139B.Return(REG_SVA0139B, () =>
                {

                    /*" -1525- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -1528- GO TO R0920-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1529- MOVE SVA-SITUACAO TO V0HCTB-SITUACAO */
            _.Move(REG_SVA0139B.SVA_SITUACAO, V0HCTB_SITUACAO);

            /*" -1530- MOVE SVA-SITUACAO-P TO V0PROP-SITUACAO */
            _.Move(REG_SVA0139B.SVA_SITUACAO_P, V0PROP_SITUACAO);

            /*" -1531- MOVE SVA-NUM-APOLICE TO V0HCTB-NUM-APOLICE */
            _.Move(REG_SVA0139B.SVA_NUM_APOLICE, V0HCTB_NUM_APOLICE);

            /*" -1532- MOVE SVA-CODSUBES TO V0HCTB-CODSUBES */
            _.Move(REG_SVA0139B.SVA_CODSUBES, V0HCTB_CODSUBES);

            /*" -1533- MOVE SVA-FONTE TO V0HCTB-FONTE */
            _.Move(REG_SVA0139B.SVA_FONTE, V0HCTB_FONTE);

            /*" -1534- MOVE SVA-PRMVG TO V0HCTB-PRMVG */
            _.Move(REG_SVA0139B.SVA_PRMVG, V0HCTB_PRMVG);

            /*" -1535- MOVE SVA-PRMAP TO V0HCTB-PRMAP */
            _.Move(REG_SVA0139B.SVA_PRMAP, V0HCTB_PRMAP);

            /*" -1536- MOVE SVA-CODOPER TO V0HCTB-CODOPER */
            _.Move(REG_SVA0139B.SVA_CODOPER, V0HCTB_CODOPER);

            /*" -1537- MOVE SVA-NRCERTIF TO V0HCTB-NRCERTIF */
            _.Move(REG_SVA0139B.SVA_NRCERTIF, V0HCTB_NRCERTIF);

            /*" -1538- MOVE SVA-NRPARCEL TO V0HCTB-NRPARCEL */
            _.Move(REG_SVA0139B.SVA_NRPARCEL, V0HCTB_NRPARCEL);

            /*" -1539- MOVE SVA-NRTIT TO V0HCTB-NRTIT */
            _.Move(REG_SVA0139B.SVA_NRTIT, V0HCTB_NRTIT);

            /*" -1540- MOVE SVA-OCORHIST TO V0HCTB-OCORHIST */
            _.Move(REG_SVA0139B.SVA_OCORHIST, V0HCTB_OCORHIST);

            /*" -1541- MOVE SVA-DTMOVTO TO V0HCTB-DTMOVTO */
            _.Move(REG_SVA0139B.SVA_DTMOVTO, V0HCTB_DTMOVTO);

            /*" -1542- MOVE SVA-ESTR-COBR TO V0PRVG-ESTR-COBR */
            _.Move(REG_SVA0139B.SVA_ESTR_COBR, V0PRVG_ESTR_COBR);

            /*" -1543- MOVE SVA-CODPRODU TO V0PRVG-CODPRODU */
            _.Move(REG_SVA0139B.SVA_CODPRODU, V0PRVG_CODPRODU);

            /*" -1544- MOVE SVA-IMPMORNATU TO V0CBPR-IMPMORNATU */
            _.Move(REG_SVA0139B.SVA_IMPMORNATU, V0CBPR_IMPMORNATU);

            /*" -1545- MOVE SVA-IMPMORACID TO V0CBPR-IMPMORACID */
            _.Move(REG_SVA0139B.SVA_IMPMORACID, V0CBPR_IMPMORACID);

            /*" -1546- MOVE SVA-IMPINVPERM TO V0CBPR-IMPINVPERM */
            _.Move(REG_SVA0139B.SVA_IMPINVPERM, V0CBPR_IMPINVPERM);

            /*" -1547- MOVE SVA-IMPAMDS TO V0CBPR-IMPAMDS */
            _.Move(REG_SVA0139B.SVA_IMPAMDS, V0CBPR_IMPAMDS);

            /*" -1548- MOVE SVA-IMPDH TO V0CBPR-IMPDH */
            _.Move(REG_SVA0139B.SVA_IMPDH, V0CBPR_IMPDH);

            /*" -1549- MOVE SVA-IMPDIT TO V0CBPR-IMPDIT */
            _.Move(REG_SVA0139B.SVA_IMPDIT, V0CBPR_IMPDIT);

            /*" -1551- MOVE SVA-PRMDIT TO V0CBPR-PRMDIT. */
            _.Move(REG_SVA0139B.SVA_PRMDIT, V0CBPR_PRMDIT);

            /*" -1553- ADD 1 TO AC-L-SORT AC-CONTA. */
            AREA_DE_WORK.AC_L_SORT.Value = AREA_DE_WORK.AC_L_SORT + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -1554- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -1555- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1556- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1560- DISPLAY 'LIDOS SORT ....... ' AC-L-SORT ' ' V0HCTB-NRCERTIF ' ' WS-TIME */

                $"LIDOS SORT ....... {AREA_DE_WORK.AC_L_SORT} {V0HCTB_NRCERTIF} {WS_TIME}"
                .Display();

                /*" -1570- END-IF. */
            }


            /*" -1571- IF V0PROP-SITUACAO EQUAL '4' */

            if (V0PROP_SITUACAO == "4")
            {

                /*" -1573- IF V0HCTB-NRPARCEL GREATER 1 NEXT SENTENCE */

                if (V0HCTB_NRPARCEL > 1)
                {

                    /*" -1574- ELSE */
                }
                else
                {


                    /*" -1575- PERFORM R0930-00-SELECT-HCTBVA */

                    R0930_00_SELECT_HCTBVA_SECTION();

                    /*" -1576- IF AC-FATURA NOT EQUAL 'S' */

                    if (AREA_DE_WORK.AC_FATURA != "S")
                    {

                        /*" -1577- ADD 1 TO WS-QTD-SIT-INVAL */
                        WS_QTD_SIT_INVAL.Value = WS_QTD_SIT_INVAL + 1;

                        /*" -1577- GO TO R0920-00-LEITURA-SVA0139B. */
                        new Task(() => R0920_00_LEITURA_SVA0139B_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R0930-00-SELECT-HCTBVA-SECTION */
        private void R0930_00_SELECT_HCTBVA_SECTION()
        {
            /*" -1587- MOVE '0930' TO WNR-EXEC-SQL. */
            _.Move("0930", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1593- MOVE 'S' TO AC-FATURA. */
            _.Move("S", AREA_DE_WORK.AC_FATURA);

            /*" -1595- IF V0HCTB-CODOPER GREATER 199 AND V0HCTB-CODOPER LESS 300 */

            if (V0HCTB_CODOPER > 199 && V0HCTB_CODOPER < 300)
            {

                /*" -1596- PERFORM R0940-00-SELECT-HCTBVA */

                R0940_00_SELECT_HCTBVA_SECTION();

                /*" -1602- GO TO R0930-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1604- IF V0HCTB-CODOPER LESS 500 AND V0HCTB-CODOPER GREATER 599 */

            if (V0HCTB_CODOPER < 500 && V0HCTB_CODOPER > 599)
            {

                /*" -1607- GO TO R0930-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1617- PERFORM R0930_00_SELECT_HCTBVA_DB_SELECT_1 */

            R0930_00_SELECT_HCTBVA_DB_SELECT_1();

            /*" -1621- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1622- MOVE 'N' TO AC-FATURA */
                _.Move("N", AREA_DE_WORK.AC_FATURA);

                /*" -1623- ELSE */
            }
            else
            {


                /*" -1624- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1625- MOVE 'S' TO AC-FATURA */
                    _.Move("S", AREA_DE_WORK.AC_FATURA);

                    /*" -1626- ELSE */
                }
                else
                {


                    /*" -1627- DISPLAY 'R0930-00-SELECT-HCTBVA - ESTORNO ' */
                    _.Display($"R0930-00-SELECT-HCTBVA - ESTORNO ");

                    /*" -1627- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0930-00-SELECT-HCTBVA-DB-SELECT-1 */
        public void R0930_00_SELECT_HCTBVA_DB_SELECT_1()
        {
            /*" -1617- EXEC SQL SELECT NRENDOS INTO :V0HCTB-NRENDOS FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND CODOPER BETWEEN 200 AND 299 AND NRENDOS > 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1 = new R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1.Execute(r0930_00_SELECT_HCTBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_NRENDOS, V0HCTB_NRENDOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/

        [StopWatch]
        /*" R0940-00-SELECT-HCTBVA-SECTION */
        private void R0940_00_SELECT_HCTBVA_SECTION()
        {
            /*" -1640- MOVE '0940' TO WNR-EXEC-SQL. */
            _.Move("0940", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1649- PERFORM R0940_00_SELECT_HCTBVA_DB_SELECT_1 */

            R0940_00_SELECT_HCTBVA_DB_SELECT_1();

            /*" -1653- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1654- MOVE 'S' TO AC-FATURA */
                _.Move("S", AREA_DE_WORK.AC_FATURA);

                /*" -1655- ELSE */
            }
            else
            {


                /*" -1656- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1657- MOVE 'N' TO AC-FATURA */
                    _.Move("N", AREA_DE_WORK.AC_FATURA);

                    /*" -1658- ELSE */
                }
                else
                {


                    /*" -1659- DISPLAY 'R0940-00-SELECT-HCTBVA - ESTORNO ' */
                    _.Display($"R0940-00-SELECT-HCTBVA - ESTORNO ");

                    /*" -1659- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0940-00-SELECT-HCTBVA-DB-SELECT-1 */
        public void R0940_00_SELECT_HCTBVA_DB_SELECT_1()
        {
            /*" -1649- EXEC SQL SELECT NRENDOS INTO :V0HCTB-NRENDOS FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND CODOPER BETWEEN 500 AND 599 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1 = new R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1.Execute(r0940_00_SELECT_HCTBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_NRENDOS, V0HCTB_NRENDOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0940_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1672- MOVE V0HCTB-NUM-APOLICE TO WS-NUM-APOLICE-ANT V0ENDO-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0ENDO_NUM_APOLICE);

            /*" -1674- MOVE V0HCTB-CODSUBES TO WS-CODSUBES-ANT V0ENDO-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0ENDO_CODSUBES);

            /*" -1676- MOVE V0HCTB-FONTE TO WS-FONTE-ANT V0ENDO-FONTE. */
            _.Move(V0HCTB_FONTE, AREA_DE_WORK.WS_FONTE_ANT, V0ENDO_FONTE);

            /*" -1679- MOVE V0PRVG-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0PRVG_CODPRODU, V0ENDO_CODPRODU);

            /*" -1681- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1692- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -1696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1698- DISPLAY 'PROBLEMAS NO ACESSO A V0APOLICE ' V0HCTB-NUM-APOLICE */
                _.Display($"PROBLEMAS NO ACESSO A V0APOLICE {V0HCTB_NUM_APOLICE}");

                /*" -1700- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1702- PERFORM R7777-CONS-MODALIDADE-APOL. */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -1704- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1711- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -1715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1716- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1718- DISPLAY '*** VA0139B - SOLICITAR PRORROGACAO DA APOLICE ' V0HCTB-NUM-APOLICE ' ' V0ENDO-DTINIVIG */

                    $"*** VA0139B - SOLICITAR PRORROGACAO DA APOLICE {V0HCTB_NUM_APOLICE} {V0ENDO_DTINIVIG}"
                    .Display();

                    /*" -1721- PERFORM R0920-00-LEITURA-SVA0139B UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

                    while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT))
                    {

                        R0920_00_LEITURA_SVA0139B_SECTION();
                    }

                    /*" -1722- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

                    if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
                    {

                        /*" -1723- GO TO R1000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;

                        /*" -1724- ELSE */
                    }
                    else
                    {


                        /*" -1725- GO TO R1000-00-PROCESSA-REGISTRO */
                        new Task(() => R1000_00_PROCESSA_REGISTRO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1726- END-IF */
                    }


                    /*" -1727- ELSE */
                }
                else
                {


                    /*" -1728- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1729- END-IF */
                }


                /*" -1731- END-IF */
            }


            /*" -1733- MOVE '1003' TO WNR-EXEC-SQL. */
            _.Move("1003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1743- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -1747- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1749- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1751- MOVE '1005' TO WNR-EXEC-SQL. */
            _.Move("1005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1760- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

            /*" -1764- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1766- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1767- ADD 1 TO V0ENDO-NRENDOS-COB */
            V0ENDO_NRENDOS_COB.Value = V0ENDO_NRENDOS_COB + 1;

            /*" -1791- ADD 1 TO V0ENDO-NRENDOS-RES */
            V0ENDO_NRENDOS_RES.Value = V0ENDO_NRENDOS_RES + 1;

            /*" -1805- MOVE +0 TO AC-PRMVG AC-PRMVG-R AC-PRMAP AC-PRMAP-R AC-PRMRTO AC-PRMRTO-R AC-PRMDIT AC-PRMDIT-R WS-VLIOCC-TOT WS-VLIOCC-TOT-AP WS-VLIOCC-TOT-VG WS-VLIOCC-TOT-DIT WS-VLIOCC-TOT-RTO. */
            _.Move(+0, AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMVG_R, AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.AC_PRMAP_R, AREA_DE_WORK.AC_PRMRTO, AREA_DE_WORK.AC_PRMRTO_R, AREA_DE_WORK.AC_PRMDIT, AREA_DE_WORK.AC_PRMDIT_R, AREA_DE_WORK.WS_VLIOCC_TOT, AREA_DE_WORK.WS_VLIOCC_TOT_AP, AREA_DE_WORK.WS_VLIOCC_TOT_VG, AREA_DE_WORK.WS_VLIOCC_TOT_DIT, AREA_DE_WORK.WS_VLIOCC_TOT_RTO);

            /*" -1820- MOVE +0 TO AC-IMPMORNATU AC-IMPMORNATU-R AC-IMPMORACID AC-IMPMORACID-R AC-IMPINVPERM AC-IMPINVPERM-R AC-IMPAMDS AC-IMPAMDS-R AC-IMPDH AC-IMPDH-R AC-IMPDIT AC-IMPDIT-R AC-IMPRTO AC-IMPRTO-R. */
            _.Move(+0, AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORNATU_R, AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPMORACID_R, AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPINVPERM_R, AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPAMDS_R, AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDH_R, AREA_DE_WORK.AC_IMPDIT, AREA_DE_WORK.AC_IMPDIT_R, AREA_DE_WORK.AC_IMPRTO, AREA_DE_WORK.AC_IMPRTO_R);

            /*" -1823- INITIALIZE TABELA-RAMO TABELA-RAMO-R. */
            _.Initialize(
                TABELA_RAMO
                , TABELA_RAMO_R
            );

            /*" -1824- MOVE '1011' TO WNR-EXEC-SQL. */
            _.Move("1011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1826- MOVE 'SIM' TO WTEM-RAMO-CONJ. */
            _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_CONJ);

            /*" -1832- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -1836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1837- IF SQLCODE NOT EQUAL 100 AND -811 */

                if (!DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1838- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1839- ELSE */
                }
                else
                {


                    /*" -1840- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1841- MOVE 'NAO' TO WTEM-RAMO-CONJ */
                        _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_CONJ);

                        /*" -1842- END-IF */
                    }


                    /*" -1843- END-IF */
                }


                /*" -1845- END-IF. */
            }


            /*" -1846- IF V0HCTB-CODOPER = 1000 */

            if (V0HCTB_CODOPER == 1000)
            {

                /*" -1847- GO TO R1000-00-NEXT */

                R1000_00_NEXT(); //GOTO
                return;

                /*" -1849- END-IF */
            }


            /*" -1855- PERFORM R1100-00-ACUMULA-PREMIO */

            R1100_00_ACUMULA_PREMIO_SECTION();

            /*" -1857- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -1858- PERFORM R1420-00-VERIFICA-OPCAO-PAGTO */

                R1420_00_VERIFICA_OPCAO_PAGTO_SECTION();

                /*" -1860- END-IF */
            }


            /*" -1863- COMPUTE AC-PRMTOTAL = (AC-PRMVG + AC-PRMVG-R + AC-PRMAP + AC-PRMAP-R). */
            AREA_DE_WORK.AC_PRMTOTAL.Value = (AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMVG_R + AREA_DE_WORK.AC_PRMAP + AREA_DE_WORK.AC_PRMAP_R);

            /*" -1864- IF (AC-PRMTOTAL NOT > ZEROS) */

            if ((AREA_DE_WORK.AC_PRMTOTAL <= 00))
            {

                /*" -1865- DISPLAY ' ' */
                _.Display($" ");

                /*" -1866- DISPLAY 'SOMATORIO DE PREMIO VG+AP NAO MAIOR QUE ZEROS' */
                _.Display($"SOMATORIO DE PREMIO VG+AP NAO MAIOR QUE ZEROS");

                /*" -1867- DISPLAY 'ENDOSSO NAO GERADO ' */
                _.Display($"ENDOSSO NAO GERADO ");

                /*" -1868- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -1869- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -1870- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -1871- DISPLAY 'PREMIO VG ' AC-PRMVG */
                _.Display($"PREMIO VG {AREA_DE_WORK.AC_PRMVG}");

                /*" -1872- DISPLAY 'PREMIO VGR' AC-PRMVG-R */
                _.Display($"PREMIO VGR{AREA_DE_WORK.AC_PRMVG_R}");

                /*" -1873- DISPLAY 'PREMIO AP ' AC-PRMAP */
                _.Display($"PREMIO AP {AREA_DE_WORK.AC_PRMAP}");

                /*" -1874- DISPLAY 'PREMIO APR' AC-PRMAP-R */
                _.Display($"PREMIO APR{AREA_DE_WORK.AC_PRMAP_R}");

                /*" -1876- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -1877- GO TO R1000-00-NEXT */

                R1000_00_NEXT(); //GOTO
                return;

                /*" -1879- END-IF. */
            }


            /*" -1882- IF (V0APOL-RAMO EQUAL 93 OR 77) AND AC-PRMVG EQUAL ZEROES AND AC-PRMVG-R EQUAL ZEROES */

            if ((V0APOL_RAMO.In("93", "77")) && AREA_DE_WORK.AC_PRMVG == 00 && AREA_DE_WORK.AC_PRMVG_R == 00)
            {

                /*" -1883- DISPLAY ' ' */
                _.Display($" ");

                /*" -1884- DISPLAY 'PREMIO ZERADO - ENDOSSO NAO GERADO ' */
                _.Display($"PREMIO ZERADO - ENDOSSO NAO GERADO ");

                /*" -1885- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -1886- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -1887- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -1888- DISPLAY 'PREMIO VG ' AC-PRMVG */
                _.Display($"PREMIO VG {AREA_DE_WORK.AC_PRMVG}");

                /*" -1890- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -1891- GO TO R1000-00-NEXT */

                R1000_00_NEXT(); //GOTO
                return;

                /*" -1893- END-IF */
            }


            /*" -1896- IF (V0APOL-RAMO EQUAL 81 OR 82) AND AC-PRMAP EQUAL ZEROES AND AC-PRMAP-R EQUAL ZEROES */

            if ((V0APOL_RAMO.In("81", "82")) && AREA_DE_WORK.AC_PRMAP == 00 && AREA_DE_WORK.AC_PRMAP_R == 00)
            {

                /*" -1897- DISPLAY ' ' */
                _.Display($" ");

                /*" -1898- DISPLAY 'PREMIO ZERADO - ENDOSSO NAO GERADO ' */
                _.Display($"PREMIO ZERADO - ENDOSSO NAO GERADO ");

                /*" -1899- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                /*" -1900- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                /*" -1901- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                /*" -1902- DISPLAY 'PREMIO AP ' AC-PRMAP */
                _.Display($"PREMIO AP {AREA_DE_WORK.AC_PRMAP}");

                /*" -1904- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                /*" -1905- GO TO R1000-00-NEXT */

                R1000_00_NEXT(); //GOTO
                return;

                /*" -1907- END-IF */
            }


            /*" -1908- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -1909- IF AC-IMPMORACID GREATER ZEROS */

                if (AREA_DE_WORK.AC_IMPMORACID > 00)
                {

                    /*" -1910- IF AC-IMPMORNATU GREATER ZEROS */

                    if (AREA_DE_WORK.AC_IMPMORNATU > 00)
                    {

                        /*" -1911- MOVE AC-IMPMORNATU TO AC-IMPMORACID */
                        _.Move(AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORACID);

                        /*" -1912- END-IF */
                    }


                    /*" -1913- IF V0COND-IPA GREATER ZEROES */

                    if (V0COND_IPA > 00)
                    {

                        /*" -1915- COMPUTE AC-IMPINVPERM = (AC-IMPMORNATU * V0COND-IPA / 100) */
                        AREA_DE_WORK.AC_IMPINVPERM.Value = (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IPA / 100f);

                        /*" -1916- ELSE */
                    }
                    else
                    {


                        /*" -1917- IF V0COND-IPD GREATER ZEROES */

                        if (V0COND_IPD > 00)
                        {

                            /*" -1919- COMPUTE AC-IMPINVPERM = (AC-IMPMORNATU * V0COND-IPD / 100) */
                            AREA_DE_WORK.AC_IMPINVPERM.Value = (AREA_DE_WORK.AC_IMPMORNATU * V0COND_IPD / 100f);

                            /*" -1920- END-IF */
                        }


                        /*" -1921- END-IF */
                    }


                    /*" -1922- END-IF */
                }


                /*" -1923- IF AC-IMPMORACID-R GREATER ZEROS */

                if (AREA_DE_WORK.AC_IMPMORACID_R > 00)
                {

                    /*" -1924- IF AC-IMPMORNATU GREATER ZEROS */

                    if (AREA_DE_WORK.AC_IMPMORNATU > 00)
                    {

                        /*" -1925- MOVE AC-IMPMORNATU-R TO AC-IMPMORACID-R */
                        _.Move(AREA_DE_WORK.AC_IMPMORNATU_R, AREA_DE_WORK.AC_IMPMORACID_R);

                        /*" -1926- IF V0COND-IPA GREATER ZEROES */

                        if (V0COND_IPA > 00)
                        {

                            /*" -1929- COMPUTE AC-IMPINVPERM-R = (AC-IMPMORNATU-R * V0COND-IPA / 100) */
                            AREA_DE_WORK.AC_IMPINVPERM_R.Value = (AREA_DE_WORK.AC_IMPMORNATU_R * V0COND_IPA / 100f);

                            /*" -1930- ELSE */
                        }
                        else
                        {


                            /*" -1931- IF V0COND-IPD GREATER ZEROES */

                            if (V0COND_IPD > 00)
                            {

                                /*" -1933- COMPUTE AC-IMPINVPERM-R = (AC-IMPMORNATU-R * V0COND-IPD / 100) */
                                AREA_DE_WORK.AC_IMPINVPERM_R.Value = (AREA_DE_WORK.AC_IMPMORNATU_R * V0COND_IPD / 100f);

                                /*" -1934- END-IF */
                            }


                            /*" -1935- END-IF */
                        }


                        /*" -1936- END-IF */
                    }


                    /*" -1939- END-IF */
                }


                /*" -1942- IF (WS-NUM-APOLICE-ANT = 97010000889) AND (WS-CODSUBES-ANT = 1950 OR 1951) NEXT SENTENCE */

                if ((AREA_DE_WORK.WS_NUM_APOLICE_ANT == 97010000889) && (AREA_DE_WORK.WS_CODSUBES_ANT.In("1950", "1951")))
                {

                    /*" -1943- ELSE */
                }
                else
                {


                    /*" -1947- IF (AC-IMPMORACID EQUAL ZEROES AND AC-IMPINVPERM EQUAL ZEROES ) AND (AC-IMPMORACID-R EQUAL ZEROES AND AC-IMPINVPERM-R EQUAL ZEROES ) */

                    if ((AREA_DE_WORK.AC_IMPMORACID == 00 && AREA_DE_WORK.AC_IMPINVPERM == 00) && (AREA_DE_WORK.AC_IMPMORACID_R == 00 && AREA_DE_WORK.AC_IMPINVPERM_R == 00))
                    {

                        /*" -1948- DISPLAY ' ' */
                        _.Display($" ");

                        /*" -1949- DISPLAY 'IS ZERADA - ENDOSSO NAO GERADO ' */
                        _.Display($"IS ZERADA - ENDOSSO NAO GERADO ");

                        /*" -1950- DISPLAY 'APOLICE   ' WS-NUM-APOLICE-ANT */
                        _.Display($"APOLICE   {AREA_DE_WORK.WS_NUM_APOLICE_ANT}");

                        /*" -1951- DISPLAY 'SUBGRUPO  ' WS-CODSUBES-ANT */
                        _.Display($"SUBGRUPO  {AREA_DE_WORK.WS_CODSUBES_ANT}");

                        /*" -1952- DISPLAY 'FONTE     ' WS-FONTE-ANT */
                        _.Display($"FONTE     {AREA_DE_WORK.WS_FONTE_ANT}");

                        /*" -1953- DISPLAY 'ENDOSSO   ' V0ENDO-NRENDOS */
                        _.Display($"ENDOSSO   {V0ENDO_NRENDOS}");

                        /*" -1954- DISPLAY 'IS MA     ' AC-IMPMORACID */
                        _.Display($"IS MA     {AREA_DE_WORK.AC_IMPMORACID}");

                        /*" -1955- DISPLAY 'IS IP     ' AC-IMPINVPERM */
                        _.Display($"IS IP     {AREA_DE_WORK.AC_IMPINVPERM}");

                        /*" -1956- DISPLAY 'IS MA -R  ' AC-IMPMORACID-R */
                        _.Display($"IS MA -R  {AREA_DE_WORK.AC_IMPMORACID_R}");

                        /*" -1958- DISPLAY 'IS IP -R  ' AC-IMPINVPERM-R */
                        _.Display($"IS IP -R  {AREA_DE_WORK.AC_IMPINVPERM_R}");

                        /*" -1959- GO TO R1000-00-NEXT */

                        R1000_00_NEXT(); //GOTO
                        return;

                        /*" -1960- END-IF */
                    }


                    /*" -1961- END-IF */
                }


                /*" -1963- END-IF */
            }


            /*" -1965- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1970- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_6 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_6();

            /*" -1974- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1975- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1977- DISPLAY '*** VA0139B - FONTE NAO CADASTRADA ' V0ENDO-FONTE */
                    _.Display($"*** VA0139B - FONTE NAO CADASTRADA {V0ENDO_FONTE}");

                    /*" -1980- PERFORM R0920-00-LEITURA-SVA0139B UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT */

                    while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT))
                    {

                        R0920_00_LEITURA_SVA0139B_SECTION();
                    }

                    /*" -1981- IF WFIM-V0HISTCONTABILVA NOT EQUAL SPACES */

                    if (!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty())
                    {

                        /*" -1982- GO TO R1000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                        return;

                        /*" -1983- ELSE */
                    }
                    else
                    {


                        /*" -1984- GO TO R1000-00-PROCESSA-REGISTRO */
                        new Task(() => R1000_00_PROCESSA_REGISTRO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1985- END-IF */
                    }


                    /*" -1986- ELSE */
                }
                else
                {


                    /*" -1987- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1988- END-IF */
                }


                /*" -1990- END-IF */
            }


            /*" -1994- IF AC-PRMVG GREATER ZEROES OR AC-PRMAP GREATER ZEROES OR AC-PRMRTO GREATER ZEROES OR AC-PRMDIT GREATER ZEROES */

            if (AREA_DE_WORK.AC_PRMVG > 00 || AREA_DE_WORK.AC_PRMAP > 00 || AREA_DE_WORK.AC_PRMRTO > 00 || AREA_DE_WORK.AC_PRMDIT > 00)
            {

                /*" -1995- MOVE AC-PRMVG TO AC-PRMVG-AUX */
                _.Move(AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMVG_AUX);

                /*" -1996- MOVE AC-PRMAP TO AC-PRMAP-AUX */
                _.Move(AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.AC_PRMAP_AUX);

                /*" -1997- MOVE AC-PRMRTO TO AC-PRMRTO-AUX */
                _.Move(AREA_DE_WORK.AC_PRMRTO, AREA_DE_WORK.AC_PRMRTO_AUX);

                /*" -1998- MOVE AC-PRMDIT TO AC-PRMDIT-AUX */
                _.Move(AREA_DE_WORK.AC_PRMDIT, AREA_DE_WORK.AC_PRMDIT_AUX);

                /*" -1999- MOVE AC-IMPMORNATU TO AC-IMPMORNATU-AUX */
                _.Move(AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORNATU_AUX);

                /*" -2000- MOVE AC-IMPMORACID TO AC-IMPMORACID-AUX */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPMORACID_AUX);

                /*" -2001- MOVE AC-IMPINVPERM TO AC-IMPINVPERM-AUX */
                _.Move(AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPINVPERM_AUX);

                /*" -2002- MOVE AC-IMPAMDS TO AC-IMPAMDS-AUX */
                _.Move(AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPAMDS_AUX);

                /*" -2003- MOVE AC-IMPDH TO AC-IMPDH-AUX */
                _.Move(AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDH_AUX);

                /*" -2004- MOVE AC-IMPDIT TO AC-IMPDIT-AUX */
                _.Move(AREA_DE_WORK.AC_IMPDIT, AREA_DE_WORK.AC_IMPDIT_AUX);

                /*" -2005- MOVE AC-IMPRTO TO AC-IMPRTO-AUX */
                _.Move(AREA_DE_WORK.AC_IMPRTO, AREA_DE_WORK.AC_IMPRTO_AUX);

                /*" -2006- MOVE '1' TO V0ENDO-TIPO-ENDO */
                _.Move("1", V0ENDO_TIPO_ENDO);

                /*" -2007- MOVE V0ENDO-NRENDOS-COB TO V0ENDO-NRENDOS */
                _.Move(V0ENDO_NRENDOS_COB, V0ENDO_NRENDOS);

                /*" -2008- PERFORM R1010-00-PROCESSA-ENDOSSO */

                R1010_00_PROCESSA_ENDOSSO_SECTION();

                /*" -2010- END-IF */
            }


            /*" -2014- IF AC-PRMVG-R GREATER ZEROES OR AC-PRMAP-R GREATER ZEROES OR AC-PRMRTO-R GREATER ZEROES OR AC-PRMDIT-R GREATER ZEROES */

            if (AREA_DE_WORK.AC_PRMVG_R > 00 || AREA_DE_WORK.AC_PRMAP_R > 00 || AREA_DE_WORK.AC_PRMRTO_R > 00 || AREA_DE_WORK.AC_PRMDIT_R > 00)
            {

                /*" -2015- MOVE AC-PRMVG-R TO AC-PRMVG-AUX */
                _.Move(AREA_DE_WORK.AC_PRMVG_R, AREA_DE_WORK.AC_PRMVG_AUX);

                /*" -2016- MOVE AC-PRMAP-R TO AC-PRMAP-AUX */
                _.Move(AREA_DE_WORK.AC_PRMAP_R, AREA_DE_WORK.AC_PRMAP_AUX);

                /*" -2017- MOVE AC-PRMRTO-R TO AC-PRMRTO-AUX */
                _.Move(AREA_DE_WORK.AC_PRMRTO_R, AREA_DE_WORK.AC_PRMRTO_AUX);

                /*" -2018- MOVE AC-PRMDIT-R TO AC-PRMDIT-AUX */
                _.Move(AREA_DE_WORK.AC_PRMDIT_R, AREA_DE_WORK.AC_PRMDIT_AUX);

                /*" -2019- MOVE ZEROS TO WS-VLIOCC-TOT */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_TOT);

                /*" -2020- MOVE ZEROS TO WS-VLIOCC-TOT-AP */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_TOT_AP);

                /*" -2021- MOVE ZEROS TO WS-VLIOCC-TOT-VG */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_TOT_VG);

                /*" -2022- MOVE ZEROS TO WS-VLIOCC-TOT-DIT */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_TOT_DIT);

                /*" -2023- MOVE ZEROS TO WS-VLIOCC-TOT-RTO */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_TOT_RTO);

                /*" -2024- MOVE AC-IMPMORNATU-R TO AC-IMPMORNATU-AUX */
                _.Move(AREA_DE_WORK.AC_IMPMORNATU_R, AREA_DE_WORK.AC_IMPMORNATU_AUX);

                /*" -2025- MOVE AC-IMPMORACID-R TO AC-IMPMORACID-AUX */
                _.Move(AREA_DE_WORK.AC_IMPMORACID_R, AREA_DE_WORK.AC_IMPMORACID_AUX);

                /*" -2026- MOVE AC-IMPINVPERM-R TO AC-IMPINVPERM-AUX */
                _.Move(AREA_DE_WORK.AC_IMPINVPERM_R, AREA_DE_WORK.AC_IMPINVPERM_AUX);

                /*" -2027- MOVE AC-IMPAMDS-R TO AC-IMPAMDS-AUX */
                _.Move(AREA_DE_WORK.AC_IMPAMDS_R, AREA_DE_WORK.AC_IMPAMDS_AUX);

                /*" -2028- MOVE AC-IMPDH-R TO AC-IMPDH-AUX */
                _.Move(AREA_DE_WORK.AC_IMPDH_R, AREA_DE_WORK.AC_IMPDH_AUX);

                /*" -2029- MOVE AC-IMPDIT-R TO AC-IMPDIT-AUX */
                _.Move(AREA_DE_WORK.AC_IMPDIT_R, AREA_DE_WORK.AC_IMPDIT_AUX);

                /*" -2030- MOVE AC-IMPRTO-R TO AC-IMPRTO-AUX */
                _.Move(AREA_DE_WORK.AC_IMPRTO_R, AREA_DE_WORK.AC_IMPRTO_AUX);

                /*" -2031- MOVE '3' TO V0ENDO-TIPO-ENDO */
                _.Move("3", V0ENDO_TIPO_ENDO);

                /*" -2032- MOVE V0ENDO-NRENDOS-RES TO V0ENDO-NRENDOS */
                _.Move(V0ENDO_NRENDOS_RES, V0ENDO_NRENDOS);

                /*" -2033- PERFORM R1010-00-PROCESSA-ENDOSSO */

                R1010_00_PROCESSA_ENDOSSO_SECTION();

                /*" -2036- END-IF */
            }


            /*" -2038- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2045- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -2049- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2051- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2054- ADD 1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + 1;

            /*" -2056- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2066- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2();

            /*" -2070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2072- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2074- ADD +1 TO AC-U-V0HISTCONTABILVA. */
            AREA_DE_WORK.AC_U_V0HISTCONTABILVA.Value = AREA_DE_WORK.AC_U_V0HISTCONTABILVA + +1;

            /*" -2076- IF V0HCTB-SITUACAO EQUAL '0' AND V0HCTB-NRPARCEL EQUAL 1 */

            if (V0HCTB_SITUACAO == "0" && V0HCTB_NRPARCEL == 1)
            {

                /*" -2077- PERFORM R1110-00-VERIFICA-RCAP */

                R1110_00_VERIFICA_RCAP_SECTION();

                /*" -2080- END-IF */
            }


            /*" -2080- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2085- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2085- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_00_NEXT */

            R1000_00_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1692- EXEC SQL SELECT RAMO, CODPRODU, MODALIDA, ORGAO INTO :V0APOL-RAMO, :V0APOL-CODPRODU, :V0APOL-MODALIDA, :V0APOL-ORGAO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(executed_1.V0APOL_CODPRODU, V0APOL_CODPRODU);
                _.Move(executed_1.V0APOL_MODALIDA, V0APOL_MODALIDA);
                _.Move(executed_1.V0APOL_ORGAO, V0APOL_ORGAO);
            }


        }

        [StopWatch]
        /*" R1000-00-NEXT */
        private void R1000_00_NEXT(bool isPerform = false)
        {
            /*" -2089- PERFORM R0920-00-LEITURA-SVA0139B. */

            R0920_00_LEITURA_SVA0139B_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -1711- EXEC SQL SELECT CODSUBES INTO :WHOST-CODSUBES FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 AND DTTERVIG > :V0ENDO-DTINIVIG END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODSUBES, WHOST_CODSUBES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1743- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD INTO :V0COND-IEA, :V0COND-IPA, :V0COND-IPD FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND COD_SUBGRUPO = :V0ENDO-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COND_IEA, V0COND_IEA);
                _.Move(executed_1.V0COND_IPA, V0COND_IPA);
                _.Move(executed_1.V0COND_IPD, V0COND_IPD);
            }


        }

        [StopWatch]
        /*" R1010-00-PROCESSA-ENDOSSO-SECTION */
        private void R1010_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -2102- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -2104- PERFORM R1020-00-VERIFICA-ENDOSSO. */

            R1020_00_VERIFICA_ENDOSSO_SECTION();

            /*" -2105- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -2106- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -2107- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -2109- MOVE V0ENDO-DTINIVIG TO V0ENDO-DATPRO. */
            _.Move(V0ENDO_DTINIVIG, V0ENDO_DATPRO);

            /*" -2113- MOVE 0 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR V0ENDO-AGERCAP V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_BCORCAP, V0ENDO_BCOCOBR, V0ENDO_AGERCAP, V0ENDO_AGECOBR);

            /*" -2115- MOVE '0' TO V0ENDO-DACCOBR. */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -2117- MOVE 0 TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);

            /*" -2118- MOVE ' ' TO V0ENDO-DACRCAP. */
            _.Move(" ", V0ENDO_DACRCAP);

            /*" -2119- MOVE ' ' TO V0ENDO-IDRCAP. */
            _.Move(" ", V0ENDO_IDRCAP);

            /*" -2120- MOVE SPACES TO V0ENDO-DATARCAP */
            _.Move("", V0ENDO_DATARCAP);

            /*" -2122- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -2123- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -2124- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -2125- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -2126- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -2127- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -2128- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -2129- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -2130- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -2132- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -2135- MOVE 1 TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(1, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -2137- MOVE 'VA0139B' TO V0ENDO-COD-USUAR. */
            _.Move("VA0139B", V0ENDO_COD_USUAR);

            /*" -2139- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -2140- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
            {

                /*" -2141- MOVE '0' TO V0ENDO-SITUACAO */
                _.Move("0", V0ENDO_SITUACAO);

                /*" -2142- ELSE */
            }
            else
            {


                /*" -2143- MOVE '1' TO V0ENDO-SITUACAO */
                _.Move("1", V0ENDO_SITUACAO);

                /*" -2146- END-IF */
            }


            /*" -2147- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -2148- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -2149- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2150- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -2152- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -2153- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -2156- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -2158- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2248- PERFORM R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1 */

            R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1();

            /*" -2251- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2252- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2253- IF V0ENDO-NRPROPOS NOT EQUAL ZEROS */

                    if (V0ENDO_NRPROPOS != 00)
                    {

                        /*" -2258- DISPLAY 'APOL ' V0ENDO-NUM-APOLICE ' SUBG ' V0ENDO-CODSUBES ' ENDO ' V0ENDO-NRENDOS ' FONT ' V0ENDO-FONTE ' NRPR ' V0ENDO-NRPROPOS */

                        $"APOL {V0ENDO_NUM_APOLICE} SUBG {V0ENDO_CODSUBES} ENDO {V0ENDO_NRENDOS} FONT {V0ENDO_FONTE} NRPR {V0ENDO_NRPROPOS}"
                        .Display();

                        /*" -2259- GO TO R1010-00-PROCESSA-ENDOSSO */
                        new Task(() => R1010_00_PROCESSA_ENDOSSO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -2260- ELSE */
                    }
                    else
                    {


                        /*" -2261- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2262- ELSE */
                    }

                }
                else
                {


                    /*" -2264- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2266- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -2268- MOVE '1026' TO WNR-EXEC-SQL. */
            _.Move("1026", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2272- PERFORM R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1 */

            R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1();

            /*" -2276- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2278- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2280- ADD 1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + 1;

            /*" -2282- PERFORM R1300-00-GRAVA-COSSEGURO. */

            R1300_00_GRAVA_COSSEGURO_SECTION();

            /*" -2283- MOVE V0ENDO-NUM-APOLICE TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0PARC_NUM_APOL);

            /*" -2284- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -2286- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -2287- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -2288- MOVE V0ENDO-FONTE TO V0PARC-FONTE */
            _.Move(V0ENDO_FONTE, V0PARC_FONTE);

            /*" -2289- MOVE 0 TO V0PARC-NRTIT */
            _.Move(0, V0PARC_NRTIT);

            /*" -2290- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -2292- COMPUTE V0PARC-OTNTOTAL = AC-PRMVG-AUX + AC-PRMAP-AUX */
            V0PARC_OTNTOTAL.Value = AREA_DE_WORK.AC_PRMVG_AUX + AREA_DE_WORK.AC_PRMAP_AUX;

            /*" -2293- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -2295- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -2298- COMPUTE V0PARC-OTNPRLIQ ROUNDED = V0PARC-OTNTOTAL - WS-VLIOCC-TOT */
            V0PARC_OTNPRLIQ.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -2300- MOVE V0PARC-OTNPRLIQ TO V0PARC-PRM-TAR-IX. */
            _.Move(V0PARC_OTNPRLIQ, V0PARC_PRM_TAR_IX);

            /*" -2302- MOVE WS-VLIOCC-TOT TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VLIOCC_TOT, V0PARC_OTNIOF);

            /*" -2303- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -2304- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
            {

                /*" -2305- MOVE '0' TO V0PARC-SITUACAO */
                _.Move("0", V0PARC_SITUACAO);

                /*" -2306- MOVE 1 TO V0PARC-OCORHIST */
                _.Move(1, V0PARC_OCORHIST);

                /*" -2307- ELSE */
            }
            else
            {


                /*" -2308- MOVE '1' TO V0PARC-SITUACAO */
                _.Move("1", V0PARC_SITUACAO);

                /*" -2309- MOVE 2 TO V0PARC-OCORHIST */
                _.Move(2, V0PARC_OCORHIST);

                /*" -2310- END-IF */
            }


            /*" -2312- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -2314- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2335- PERFORM R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2 */

            R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2();

            /*" -2339- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2341- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2343- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -2348- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -2349- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
            {

                /*" -2350- CONTINUE */

                /*" -2351- ELSE */
            }
            else
            {


                /*" -2352- PERFORM R1500-00-GRAVA-OPERACAO-BAIXA */

                R1500_00_GRAVA_OPERACAO_BAIXA_SECTION();

                /*" -2354- END-IF */
            }


            /*" -2355- MOVE V0ENDO-NUM-APOLICE TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0COBA_NUM_APOL);

            /*" -2356- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -2357- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -2358- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -2359- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -2360- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -2362- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -2363- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -2364- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -2366- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -2367- IF V0APOL-RAMO = 81 OR 97 OR 82 */

            if (V0APOL_RAMO.In("81", "97", "82"))
            {

                /*" -2368- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -2369- MOVE 82 TO V0COBA-RAMOFR */
                    _.Move(82, V0COBA_RAMOFR);

                    /*" -2370- ELSE */
                }
                else
                {


                    /*" -2371- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -2372- END-IF */
                }


                /*" -2373- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                /*" -2374- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -2376- MOVE AC-IMPMORACID-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -2377- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -2382- COMPUTE V0PARC-OTNPRLIQ = (AC-PRMVG-AUX + AC-PRMAP-AUX) - (WS-VLIOCC-TOT-VG + WS-VLIOCC-TOT-AP) */
                    V0PARC_OTNPRLIQ.Value = (AREA_DE_WORK.AC_PRMVG_AUX + AREA_DE_WORK.AC_PRMAP_AUX) - (AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_TOT_AP);

                    /*" -2385- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMAP-AUX - WS-VLIOCC-TOT-AP */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMAP_AUX - AREA_DE_WORK.WS_VLIOCC_TOT_AP;

                    /*" -2386- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2388- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -2389- ELSE */
                }
                else
                {


                    /*" -2391- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2392- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -2393- END-IF */
                }


                /*" -2395- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -2396- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -2397- IF AC-PRMDIT-AUX GREATER 0 */

                if (AREA_DE_WORK.AC_PRMDIT_AUX > 0)
                {

                    /*" -2401- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0COBA-PRM-TAR-IX - AC-PRMDIT-AUX + WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.AC_PRMDIT_AUX + AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -2402- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2404- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -2405- END-IF */
                }


                /*" -2407- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -2408- IF AC-IMPINVPERM-AUX GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPINVPERM_AUX > 00)
                {

                    /*" -2410- MOVE AC-IMPINVPERM-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPINVPERM_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -2413- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR V0COBA-PCT-COBERT */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR, V0COBA_PCT_COBERT);

                    /*" -2414- MOVE 2 TO V0COBA-COD-COBER */
                    _.Move(2, V0COBA_COD_COBER);

                    /*" -2415- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -2417- END-IF */
                }


                /*" -2418- IF AC-IMPAMDS-AUX GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPAMDS_AUX > 00)
                {

                    /*" -2420- MOVE AC-IMPAMDS-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPAMDS_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -2422- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2423- MOVE 3 TO V0COBA-COD-COBER */
                    _.Move(3, V0COBA_COD_COBER);

                    /*" -2424- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -2426- END-IF */
                }


                /*" -2427- IF AC-IMPDH-AUX GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDH_AUX > 00)
                {

                    /*" -2429- MOVE AC-IMPDH-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDH_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -2431- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2432- MOVE 4 TO V0COBA-COD-COBER */
                    _.Move(4, V0COBA_COD_COBER);

                    /*" -2433- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -2435- END-IF */
                }


                /*" -2436- IF AC-IMPDIT-AUX GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDIT_AUX > 00)
                {

                    /*" -2438- MOVE AC-IMPDIT-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDIT_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -2441- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMDIT-AUX - WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMDIT_AUX - AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -2442- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2443- MOVE 5 TO V0COBA-COD-COBER */
                    _.Move(5, V0COBA_COD_COBER);

                    /*" -2445- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -2447- PERFORM R1600-00-INSERT-V0COBERAPOL. */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();
                }

            }


            /*" -2448- IF V0APOL-RAMO = 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -2449- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -2450- MOVE 93 TO V0COBA-RAMOFR */
                    _.Move(93, V0COBA_RAMOFR);

                    /*" -2451- ELSE */
                }
                else
                {


                    /*" -2452- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -2453- END-IF */
                }


                /*" -2454- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                /*" -2455- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -2457- MOVE AC-IMPMORNATU-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORNATU_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -2459- COMPUTE AC-PRMVG-AUX = AC-PRMVG-AUX - AC-PRMRTO-AUX */
                AREA_DE_WORK.AC_PRMVG_AUX.Value = AREA_DE_WORK.AC_PRMVG_AUX - AREA_DE_WORK.AC_PRMRTO_AUX;

                /*" -2462- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-TOT-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                /*" -2463- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -2465- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMVG-AUX - WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMVG_AUX - AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -2466- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -2468- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -2469- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -2470- MOVE 11 TO V0COBA-COD-COBER */
                    _.Move(11, V0COBA_COD_COBER);

                    /*" -2471- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -2472- ELSE */
                }
                else
                {


                    /*" -2473- IF AC-IMPRTO-AUX GREATER 0 */

                    if (AREA_DE_WORK.AC_IMPRTO_AUX > 0)
                    {

                        /*" -2476- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMRTO-AUX + WS-VLIOCC-TOT-RTO */
                        V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMRTO_AUX + AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                        /*" -2477- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -2479- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -2480- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -2481- MOVE 11 TO V0COBA-COD-COBER */
                        _.Move(11, V0COBA_COD_COBER);

                        /*" -2482- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -2483- ELSE */
                    }
                    else
                    {


                        /*" -2484- IF V0ENDO-TIPO-ENDO EQUAL '1' */

                        if (V0ENDO_TIPO_ENDO == "1")
                        {

                            /*" -2485- MOVE 99 TO WS-IND1 */
                            _.Move(99, WS_IND1);

                            /*" -2487- PERFORM UNTIL WS-IND1 EQUAL ZEROS OR TB-RAMO-VALOR-PRM(WS-IND1) GREATER ZEROS */

                            while (!(WS_IND1 == 00 || TABELA_RAMO.FILLER_1[WS_IND1].TB_RAMO_VALOR_PRM > 00))
                            {

                                /*" -2488- SUBTRACT 1 FROM WS-IND1 */
                                WS_IND1.Value = WS_IND1 - 1;

                                /*" -2489- END-PERFORM */
                            }

                            /*" -2494- MOVE ZEROS TO WS-IND WS-ACUM-IND WS-ACUM-PRM WS-ACUM-IOF WS-IOF-RAMO */
                            _.Move(0, WS_IND, WS_ACUM_IND, WS_ACUM_PRM, WS_ACUM_IOF, WS_IOF_RAMO);

                            /*" -2495- MOVE 'NAO' TO WTEM-RAMO-COMP */
                            _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_COMP);

                            /*" -2496- PERFORM UNTIL WS-IND GREATER 99 */

                            while (!(WS_IND > 99))
                            {

                                /*" -2497- ADD 1 TO WS-IND */
                                WS_IND.Value = WS_IND + 1;

                                /*" -2498- IF TB-RAMO-VALOR-PRM(WS-IND) GREATER ZEROS */

                                if (TABELA_RAMO.FILLER_1[WS_IND].TB_RAMO_VALOR_PRM > 00)
                                {

                                    /*" -2499- MOVE 'SIM' TO WTEM-RAMO-COMP */
                                    _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_COMP);

                                    /*" -2500- MOVE WS-IND TO V0COBA-RAMOFR */
                                    _.Move(WS_IND, V0COBA_RAMOFR);

                                    /*" -2503- MOVE TB-RAMO-VALOR-PRM(WS-IND) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                                    _.Move(TABELA_RAMO.FILLER_1[WS_IND].TB_RAMO_VALOR_PRM, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                                    /*" -2505- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                                    /*" -2507- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF * V0COBA-PCT-COBERT / 100 */
                                    WS_IOF_RAMO.Value = V0PARC_OTNIOF * V0COBA_PCT_COBERT / 100f;

                                    /*" -2508- IF WS-IND EQUAL WS-IND1 */

                                    if (WS_IND == WS_IND1)
                                    {

                                        /*" -2510- COMPUTE V0COBA-PCT-COBERT = 100 - WS-ACUM-IND */
                                        V0COBA_PCT_COBERT.Value = 100 - WS_ACUM_IND;

                                        /*" -2512- COMPUTE V0COBA-PRM-TAR-IX = V0PARC-OTNTOTAL - WS-ACUM-PRM */
                                        V0COBA_PRM_TAR_IX.Value = V0PARC_OTNTOTAL - WS_ACUM_PRM;

                                        /*" -2514- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF - WS-ACUM-IOF */
                                        WS_IOF_RAMO.Value = V0PARC_OTNIOF - WS_ACUM_IOF;

                                        /*" -2516- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                                        V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - WS_IOF_RAMO;

                                        /*" -2518- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                                        /*" -2519- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2520- ADD V0COBA-PCT-COBERT TO WS-ACUM-IND */
                                        WS_ACUM_IND.Value = WS_ACUM_IND + V0COBA_PCT_COBERT;

                                        /*" -2521- ADD V0COBA-PRM-TAR-IX TO WS-ACUM-PRM */
                                        WS_ACUM_PRM.Value = WS_ACUM_PRM + V0COBA_PRM_TAR_IX;

                                        /*" -2522- ADD WS-IOF-RAMO TO WS-ACUM-IOF */
                                        WS_ACUM_IOF.Value = WS_ACUM_IOF + WS_IOF_RAMO;

                                        /*" -2524- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                                        V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - WS_IOF_RAMO;

                                        /*" -2526- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                                        /*" -2528- END-IF */
                                    }


                                    /*" -2529- PERFORM R1600-00-INSERT-V0COBERAPOL */

                                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                                    /*" -2530- IF WS-IND EQUAL 93 */

                                    if (WS_IND == 93)
                                    {

                                        /*" -2531- MOVE 11 TO V0COBA-COD-COBER */
                                        _.Move(11, V0COBA_COD_COBER);

                                        /*" -2532- PERFORM R1600-00-INSERT-V0COBERAPOL */

                                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                                        /*" -2533- END-IF */
                                    }


                                    /*" -2534- END-IF */
                                }


                                /*" -2535- END-PERFORM */
                            }

                            /*" -2536- ELSE */
                        }
                        else
                        {


                            /*" -2537- MOVE 99 TO WS-IND1 */
                            _.Move(99, WS_IND1);

                            /*" -2539- PERFORM UNTIL WS-IND1 EQUAL ZEROS OR TB-RAMO-VALOR-PRM-R (WS-IND1) GREATER ZEROS */

                            while (!(WS_IND1 == 00 || TABELA_RAMO_R.FILLER_2[WS_IND1].TB_RAMO_VALOR_PRM_R > 00))
                            {

                                /*" -2540- SUBTRACT 1 FROM WS-IND1 */
                                WS_IND1.Value = WS_IND1 - 1;

                                /*" -2541- END-PERFORM */
                            }

                            /*" -2545- MOVE ZEROS TO WS-IND WS-ACUM-IND WS-ACUM-PRM WS-ACUM-IOF */
                            _.Move(0, WS_IND, WS_ACUM_IND, WS_ACUM_PRM, WS_ACUM_IOF);

                            /*" -2546- MOVE 'NAO' TO WTEM-RAMO-COMP */
                            _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_COMP);

                            /*" -2547- PERFORM UNTIL WS-IND GREATER 99 */

                            while (!(WS_IND > 99))
                            {

                                /*" -2548- ADD 1 TO WS-IND */
                                WS_IND.Value = WS_IND + 1;

                                /*" -2549- IF TB-RAMO-VALOR-PRM-R (WS-IND) GREATER ZEROS */

                                if (TABELA_RAMO_R.FILLER_2[WS_IND].TB_RAMO_VALOR_PRM_R > 00)
                                {

                                    /*" -2550- MOVE 'SIM' TO WTEM-RAMO-COMP */
                                    _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_COMP);

                                    /*" -2551- MOVE WS-IND TO V0COBA-RAMOFR */
                                    _.Move(WS_IND, V0COBA_RAMOFR);

                                    /*" -2554- MOVE TB-RAMO-VALOR-PRM-R (WS-IND) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                                    _.Move(TABELA_RAMO_R.FILLER_2[WS_IND].TB_RAMO_VALOR_PRM_R, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                                    /*" -2556- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                                    /*" -2558- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF * V0COBA-PCT-COBERT / 100 */
                                    WS_IOF_RAMO.Value = V0PARC_OTNIOF * V0COBA_PCT_COBERT / 100f;

                                    /*" -2559- IF WS-IND EQUAL WS-IND1 */

                                    if (WS_IND == WS_IND1)
                                    {

                                        /*" -2561- COMPUTE V0COBA-PCT-COBERT = 100 - WS-ACUM-IND */
                                        V0COBA_PCT_COBERT.Value = 100 - WS_ACUM_IND;

                                        /*" -2563- COMPUTE V0COBA-PRM-TAR-IX = V0PARC-OTNTOTAL - WS-ACUM-PRM */
                                        V0COBA_PRM_TAR_IX.Value = V0PARC_OTNTOTAL - WS_ACUM_PRM;

                                        /*" -2565- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF - WS-ACUM-IOF */
                                        WS_IOF_RAMO.Value = V0PARC_OTNIOF - WS_ACUM_IOF;

                                        /*" -2567- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                                        V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - WS_IOF_RAMO;

                                        /*" -2569- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                                        /*" -2570- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2571- ADD V0COBA-PCT-COBERT TO WS-ACUM-IND */
                                        WS_ACUM_IND.Value = WS_ACUM_IND + V0COBA_PCT_COBERT;

                                        /*" -2572- ADD V0COBA-PRM-TAR-IX TO WS-ACUM-PRM */
                                        WS_ACUM_PRM.Value = WS_ACUM_PRM + V0COBA_PRM_TAR_IX;

                                        /*" -2573- ADD WS-IOF-RAMO TO WS-ACUM-IOF */
                                        WS_ACUM_IOF.Value = WS_ACUM_IOF + WS_IOF_RAMO;

                                        /*" -2575- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                                        V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - WS_IOF_RAMO;

                                        /*" -2577- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                                        /*" -2579- END-IF */
                                    }


                                    /*" -2580- PERFORM R1600-00-INSERT-V0COBERAPOL */

                                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                                    /*" -2581- IF WS-IND EQUAL 93 */

                                    if (WS_IND == 93)
                                    {

                                        /*" -2582- MOVE 11 TO V0COBA-COD-COBER */
                                        _.Move(11, V0COBA_COD_COBER);

                                        /*" -2583- PERFORM R1600-00-INSERT-V0COBERAPOL */

                                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                                        /*" -2584- END-IF */
                                    }


                                    /*" -2585- END-IF */
                                }


                                /*" -2586- END-PERFORM */
                            }

                            /*" -2587- END-IF */
                        }


                        /*" -2588- IF WTEM-RAMO-COMP EQUAL 'NAO' */

                        if (AREA_DE_WORK.WTEM_RAMO_COMP == "NAO")
                        {

                            /*" -2590- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                            _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                            /*" -2591- MOVE 100 TO V0COBA-PCT-COBERT */
                            _.Move(100, V0COBA_PCT_COBERT);

                            /*" -2592- PERFORM R1600-00-INSERT-V0COBERAPOL */

                            R1600_00_INSERT_V0COBERAPOL_SECTION();

                            /*" -2593- MOVE 11 TO V0COBA-COD-COBER */
                            _.Move(11, V0COBA_COD_COBER);

                            /*" -2594- PERFORM R1600-00-INSERT-V0COBERAPOL */

                            R1600_00_INSERT_V0COBERAPOL_SECTION();

                            /*" -2595- END-IF */
                        }


                        /*" -2596- END-IF */
                    }


                    /*" -2598- END-IF */
                }


                /*" -2599- IF V0PRVG-ESTR-COBR = 'FEDERAL' */

                if (V0PRVG_ESTR_COBR == "FEDERAL")
                {

                    /*" -2600- IF AC-IMPRTO-AUX GREATER 0 */

                    if (AREA_DE_WORK.AC_IMPRTO_AUX > 0)
                    {

                        /*" -2601- MOVE 86 TO V0COBA-RAMOFR */
                        _.Move(86, V0COBA_RAMOFR);

                        /*" -2602- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                        _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                        /*" -2603- MOVE 0 TO V0COBA-COD-COBER */
                        _.Move(0, V0COBA_COD_COBER);

                        /*" -2605- MOVE AC-IMPRTO-AUX TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                        _.Move(AREA_DE_WORK.AC_IMPRTO_AUX, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                        /*" -2607- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMRTO-AUX - WS-VLIOCC-TOT-RTO */
                        V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMRTO_AUX - AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                        /*" -2608- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -2610- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -2612- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -2613- MOVE 1 TO V0COBA-COD-COBER */
                        _.Move(1, V0COBA_COD_COBER);

                        /*" -2614- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -2615- END-IF */
                    }


                    /*" -2616- END-IF */
                }


                /*" -2616- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-PROCESSA-ENDOSSO-DB-INSERT-1 */
        public void R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1()
        {
            /*" -2248- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOLICE, :V0ENDO-NRENDOS, :V0ENDO-CODSUBES, :V0ENDO-FONTE, :V0ENDO-NRPROPOS, :V0ENDO-DATPRO, :V0ENDO-DT-LIBER, :V0ENDO-DTEMIS, :V0ENDO-NRRCAP, :V0ENDO-VLRCAP, :V0ENDO-BCORCAP, :V0ENDO-AGERCAP, :V0ENDO-DACRCAP, :V0ENDO-IDRCAP, :V0ENDO-BCOCOBR, :V0ENDO-AGECOBR, :V0ENDO-DACCOBR, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-CDFRACIO, :V0ENDO-PCENTRAD, :V0ENDO-PCADICIO, :V0ENDO-PRESTA1, :V0ENDO-QTPARCEL, :V0ENDO-QTPRESTA, :V0ENDO-QTITENS, :V0ENDO-CODTXT, :V0ENDO-CDACEITA, :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO, :V0ENDO-DATARCAP:VIND-DATARCAP, :V0ENDO-COD-EMPRESA, :V0ENDO-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:VIND-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI:VIND-VLCUSEMI, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

            var r1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1 = new R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_DATPRO = V0ENDO_DATPRO.ToString(),
                V0ENDO_DT_LIBER = V0ENDO_DT_LIBER.ToString(),
                V0ENDO_DTEMIS = V0ENDO_DTEMIS.ToString(),
                V0ENDO_NRRCAP = V0ENDO_NRRCAP.ToString(),
                V0ENDO_VLRCAP = V0ENDO_VLRCAP.ToString(),
                V0ENDO_BCORCAP = V0ENDO_BCORCAP.ToString(),
                V0ENDO_AGERCAP = V0ENDO_AGERCAP.ToString(),
                V0ENDO_DACRCAP = V0ENDO_DACRCAP.ToString(),
                V0ENDO_IDRCAP = V0ENDO_IDRCAP.ToString(),
                V0ENDO_BCOCOBR = V0ENDO_BCOCOBR.ToString(),
                V0ENDO_AGECOBR = V0ENDO_AGECOBR.ToString(),
                V0ENDO_DACCOBR = V0ENDO_DACCOBR.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V0ENDO_PCENTRAD = V0ENDO_PCENTRAD.ToString(),
                V0ENDO_PCADICIO = V0ENDO_PCADICIO.ToString(),
                V0ENDO_PRESTA1 = V0ENDO_PRESTA1.ToString(),
                V0ENDO_QTPARCEL = V0ENDO_QTPARCEL.ToString(),
                V0ENDO_QTPRESTA = V0ENDO_QTPRESTA.ToString(),
                V0ENDO_QTITENS = V0ENDO_QTITENS.ToString(),
                V0ENDO_CODTXT = V0ENDO_CODTXT.ToString(),
                V0ENDO_CDACEITA = V0ENDO_CDACEITA.ToString(),
                V0ENDO_MOEDA_IMP = V0ENDO_MOEDA_IMP.ToString(),
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_TIPO_ENDO = V0ENDO_TIPO_ENDO.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                V0ENDO_ISENTA_CST = V0ENDO_ISENTA_CST.ToString(),
                V0ENDO_DTVENCTO = V0ENDO_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0ENDO_CFPREFIX = V0ENDO_CFPREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                V0ENDO_VLCUSEMI = V0ENDO_VLCUSEMI.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1.Execute(r1010_00_PROCESSA_ENDOSSO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1010-00-PROCESSA-ENDOSSO-DB-UPDATE-1 */
        public void R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1()
        {
            /*" -2272- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1 = new R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1.Execute(r1010_00_PROCESSA_ENDOSSO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -2045- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS-COB , ENDOSRES = :V0ENDO-NRENDOS-RES WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS_COB = V0ENDO_NRENDOS_COB.ToString(),
                V0ENDO_NRENDOS_RES = V0ENDO_NRENDOS_RES.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1010-00-PROCESSA-ENDOSSO-DB-INSERT-2 */
        public void R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2()
        {
            /*" -2335- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1 = new R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1()
            {
                V0PARC_NUM_APOL = V0PARC_NUM_APOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_DACPARC = V0PARC_DACPARC.ToString(),
                V0PARC_FONTE = V0PARC_FONTE.ToString(),
                V0PARC_NRTIT = V0PARC_NRTIT.ToString(),
                V0PARC_PRM_TAR_IX = V0PARC_PRM_TAR_IX.ToString(),
                V0PARC_VAL_DES_IX = V0PARC_VAL_DES_IX.ToString(),
                V0PARC_OTNPRLIQ = V0PARC_OTNPRLIQ.ToString(),
                V0PARC_OTNADFRA = V0PARC_OTNADFRA.ToString(),
                V0PARC_OTNCUSTO = V0PARC_OTNCUSTO.ToString(),
                V0PARC_OTNIOF = V0PARC_OTNIOF.ToString(),
                V0PARC_OTNTOTAL = V0PARC_OTNTOTAL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0PARC_QTDDOC = V0PARC_QTDDOC.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_COD_EMPRESA = V0PARC_COD_EMPRESA.ToString(),
            };

            R1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1.Execute(r1010_00_PROCESSA_ENDOSSO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1760- EXEC SQL SELECT ENDOSCOB , ENDOSRES INTO :V0ENDO-NRENDOS-COB , :V0ENDO-NRENDOS-RES FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRENDOS_COB, V0ENDO_NRENDOS_COB);
                _.Move(executed_1.V0ENDO_NRENDOS_RES, V0ENDO_NRENDOS_RES);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2()
        {
            /*" -2066- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' , NRENDOS = :V0ENDO-NRENDOS, DTFATUR = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
                V0HCTB_OCORHIST = V0HCTB_OCORHIST.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -1832- EXEC SQL SELECT COD_GRUPO_SUSEP INTO :VG080-COD-GRUPO-SUSEP FROM SEGUROS.VG_PARAM_RAMO_CONJ WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND COD_SUBGRUPO = :V0ENDO-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG080_COD_GRUPO_SUSEP, VG080.DCLVG_PARAM_RAMO_CONJ.VG080_COD_GRUPO_SUSEP);
            }


        }

        [StopWatch]
        /*" R1020-00-VERIFICA-ENDOSSO-SECTION */
        private void R1020_00_VERIFICA_ENDOSSO_SECTION()
        {
            /*" -2626- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2632- PERFORM R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1 */

            R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1();

            /*" -2636- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2638- ADD 1 TO AC-TOTAL-ENDOSSO AC-L-ENDOSSO */
                AREA_DE_WORK.AC_TOTAL_ENDOSSO.Value = AREA_DE_WORK.AC_TOTAL_ENDOSSO + 1;
                AREA_DE_WORK.AC_L_ENDOSSO.Value = AREA_DE_WORK.AC_L_ENDOSSO + 1;

                /*" -2639- IF AC-TOTAL-ENDOSSO GREATER 499 */

                if (AREA_DE_WORK.AC_TOTAL_ENDOSSO > 499)
                {

                    /*" -2640- DISPLAY '(PROPOSTA DUPLICADA NA ENDOSSO)... ' */
                    _.Display($"(PROPOSTA DUPLICADA NA ENDOSSO)... ");

                    /*" -2641- DISPLAY ' FONTE    - ' V0ENDO-FONTE */
                    _.Display($" FONTE    - {V0ENDO_FONTE}");

                    /*" -2642- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                    _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                    /*" -2644- DISPLAY ' QTD ENDOSSOS LIDOS PARA A FONTE/PROPOSTA: ' AC-L-ENDOSSO */
                    _.Display($" QTD ENDOSSOS LIDOS PARA A FONTE/PROPOSTA: {AREA_DE_WORK.AC_L_ENDOSSO}");

                    /*" -2645- MOVE ZEROS TO AC-TOTAL-ENDOSSO */
                    _.Move(0, AREA_DE_WORK.AC_TOTAL_ENDOSSO);

                    /*" -2646- END-IF */
                }


                /*" -2647- IF AC-L-ENDOSSO GREATER 4999 */

                if (AREA_DE_WORK.AC_L_ENDOSSO > 4999)
                {

                    /*" -2648- DISPLAY 'BUSCA MUITO LONGA NA ENDOSSOS' */
                    _.Display($"BUSCA MUITO LONGA NA ENDOSSOS");

                    /*" -2649- DISPLAY ' FONTE    - ' V0ENDO-FONTE */
                    _.Display($" FONTE    - {V0ENDO_FONTE}");

                    /*" -2650- DISPLAY ' PROPOSTA - ' V1FONT-PROPAUTOM */
                    _.Display($" PROPOSTA - {V1FONT_PROPAUTOM}");

                    /*" -2651- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2652- END-IF */
                }


                /*" -2653- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1 */
                V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

                /*" -2654- GO TO R1020-00-VERIFICA-ENDOSSO */
                new Task(() => R1020_00_VERIFICA_ENDOSSO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -2655- ELSE */
            }
            else
            {


                /*" -2656- IF SQLCODE NOT EQUAL ZEROES AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2657- DISPLAY 'R1020-00 (ERRO - SELECT V0ENDOSSO)... ' */
                    _.Display($"R1020-00 (ERRO - SELECT V0ENDOSSO)... ");

                    /*" -2658- DISPLAY 'FONTE    - ' V0ENDO-FONTE */
                    _.Display($"FONTE    - {V0ENDO_FONTE}");

                    /*" -2659- DISPLAY 'PROPOSTA - ' V1FONT-PROPAUTOM */
                    _.Display($"PROPOSTA - {V1FONT_PROPAUTOM}");

                    /*" -2660- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2661- END-IF */
                }


                /*" -2661- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-VERIFICA-ENDOSSO-DB-SELECT-1 */
        public void R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1()
        {
            /*" -2632- EXEC SQL SELECT NRPROPOS INTO :V0ENDO-NRPROPOS FROM SEGUROS.V0ENDOSSO WHERE FONTE = :V0ENDO-FONTE AND NRPROPOS = :V1FONT-PROPAUTOM END-EXEC. */

            var r1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1 = new R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1.Execute(r1020_00_VERIFICA_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRPROPOS, V0ENDO_NRPROPOS);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-6 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_6()
        {
            /*" -1970- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1()
            {
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-SECTION */
        private void R1100_00_ACUMULA_PREMIO_SECTION()
        {
            /*" -2674- MOVE 'S' TO WTEM-CONVERSAO. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSAO);

            /*" -2676- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2678- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -2679- MOVE V0ENDO-NRENDOS-COB TO V0ENDO-NRENDOS */
                _.Move(V0ENDO_NRENDOS_COB, V0ENDO_NRENDOS);

                /*" -2680- PERFORM R1105-00-ACESSA-V1RAMOIND */

                R1105_00_ACESSA_V1RAMOIND_SECTION();

                /*" -2684- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
                AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

                /*" -2687- COMPUTE WS-PREMIO-LIQ ROUNDED = (V0HCTB-PRMVG + V0HCTB-PRMAP) / WS-IND-IOF */
                AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP) / AREA_DE_WORK.WS_IND_IOF;

                /*" -2690- COMPUTE WS-VLIOCC = V0HCTB-PRMVG + V0HCTB-PRMAP - WS-PREMIO-LIQ */
                AREA_DE_WORK.WS_VLIOCC.Value = V0HCTB_PRMVG + V0HCTB_PRMAP - AREA_DE_WORK.WS_PREMIO_LIQ;

                /*" -2692- COMPUTE WS-PRM-LIQ-AP ROUNDED = V0HCTB-PRMAP / WS-IND-IOF */
                AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP / AREA_DE_WORK.WS_IND_IOF;

                /*" -2694- COMPUTE WS-VLIOCC-AP = V0HCTB-PRMAP - WS-PRM-LIQ-AP */
                AREA_DE_WORK.WS_VLIOCC_AP.Value = V0HCTB_PRMAP - AREA_DE_WORK.WS_PRM_LIQ_AP;

                /*" -2696- COMPUTE WS-PRM-LIQ-VG ROUNDED = V0HCTB-PRMVG / WS-IND-IOF */
                AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG / AREA_DE_WORK.WS_IND_IOF;

                /*" -2698- COMPUTE WS-VLIOCC-VG = V0HCTB-PRMVG - WS-PRM-LIQ-VG */
                AREA_DE_WORK.WS_VLIOCC_VG.Value = V0HCTB_PRMVG - AREA_DE_WORK.WS_PRM_LIQ_VG;

                /*" -2699- IF V0PRVG-ESTR-COBR = 'FEDERAL' */

                if (V0PRVG_ESTR_COBR == "FEDERAL")
                {

                    /*" -2700- PERFORM R1109-00-CALCULA-RTO */

                    R1109_00_CALCULA_RTO_SECTION();

                    /*" -2701- ELSE */
                }
                else
                {


                    /*" -2703- MOVE 0 TO WS-PRMRTO WS-VLIOCC-RTO */
                    _.Move(0, AREA_DE_WORK.WS_PRMRTO, AREA_DE_WORK.WS_VLIOCC_RTO);

                    /*" -2704- END-IF */
                }


                /*" -2705- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT + WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT + AREA_DE_WORK.WS_VLIOCC;

                /*" -2706- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP + WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP + AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -2707- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG + WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -2709- COMPUTE WS-VLIOCC-TOT-RTO = WS-VLIOCC-TOT-RTO + WS-VLIOCC-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_RTO.Value = AREA_DE_WORK.WS_VLIOCC_TOT_RTO + AREA_DE_WORK.WS_VLIOCC_RTO;

                /*" -2710- COMPUTE AC-PRMVG = AC-PRMVG + V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG + V0HCTB_PRMVG;

                /*" -2711- COMPUTE AC-PRMAP = AC-PRMAP + V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP + V0HCTB_PRMAP;

                /*" -2712- COMPUTE AC-PRMRTO = AC-PRMRTO + WS-PRMRTO */
                AREA_DE_WORK.AC_PRMRTO.Value = AREA_DE_WORK.AC_PRMRTO + AREA_DE_WORK.WS_PRMRTO;

                /*" -2713- IF WTEM-RAMO-CONJ EQUAL 'SIM' */

                if (AREA_DE_WORK.WTEM_RAMO_CONJ == "SIM")
                {

                    /*" -2714- PERFORM R1130-00-ACUMULA-CONJ */

                    R1130_00_ACUMULA_CONJ_SECTION();

                    /*" -2715- END-IF */
                }


                /*" -2716- IF V0HCTB-NRCERTIF NOT EQUAL WHOST-NRCERTIF-ANT */

                if (V0HCTB_NRCERTIF != WHOST_NRCERTIF_ANT)
                {

                    /*" -2717- COMPUTE AC-IMPMORNATU = AC-IMPMORNATU + V0CBPR-IMPMORNATU */
                    AREA_DE_WORK.AC_IMPMORNATU.Value = AREA_DE_WORK.AC_IMPMORNATU + V0CBPR_IMPMORNATU;

                    /*" -2718- COMPUTE AC-IMPMORACID = AC-IMPMORACID + V0CBPR-IMPMORACID */
                    AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID + V0CBPR_IMPMORACID;

                    /*" -2719- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM + V0CBPR-IMPINVPERM */
                    AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM + V0CBPR_IMPINVPERM;

                    /*" -2720- COMPUTE AC-IMPAMDS = AC-IMPAMDS + V0CBPR-IMPAMDS */
                    AREA_DE_WORK.AC_IMPAMDS.Value = AREA_DE_WORK.AC_IMPAMDS + V0CBPR_IMPAMDS;

                    /*" -2721- COMPUTE AC-IMPDH = AC-IMPDH + V0CBPR-IMPDH */
                    AREA_DE_WORK.AC_IMPDH.Value = AREA_DE_WORK.AC_IMPDH + V0CBPR_IMPDH;

                    /*" -2722- COMPUTE AC-IMPDIT = AC-IMPDIT + V0CBPR-IMPDIT */
                    AREA_DE_WORK.AC_IMPDIT.Value = AREA_DE_WORK.AC_IMPDIT + V0CBPR_IMPDIT;

                    /*" -2723- COMPUTE AC-IMPCDG = AC-IMPCDG + V0CBPR-IMPCDG */
                    AREA_DE_WORK.AC_IMPCDG.Value = AREA_DE_WORK.AC_IMPCDG + V0CBPR_IMPCDG;

                    /*" -2724- COMPUTE AC-IMPAA = AC-IMPAA + V0CBPR-IMPAA */
                    AREA_DE_WORK.AC_IMPAA.Value = AREA_DE_WORK.AC_IMPAA + V0CBPR_IMPAA;

                    /*" -2725- COMPUTE AC-IMPAAF = AC-IMPAAF + V0CBPR-IMPAAF */
                    AREA_DE_WORK.AC_IMPAAF.Value = AREA_DE_WORK.AC_IMPAAF + V0CBPR_IMPAAF;

                    /*" -2726- COMPUTE AC-IMPADE = AC-IMPADE + V0CBPR-IMPADE */
                    AREA_DE_WORK.AC_IMPADE.Value = AREA_DE_WORK.AC_IMPADE + V0CBPR_IMPADE;

                    /*" -2727- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

                    if (V0CBPR_IMPDIT != 00)
                    {

                        /*" -2728- PERFORM R1220-00-LE-PREMIO-DIT */

                        R1220_00_LE_PREMIO_DIT_SECTION();

                        /*" -2729- END-IF */
                    }


                    /*" -2730- IF V0PRVG-ESTR-COBR = 'FEDERAL' */

                    if (V0PRVG_ESTR_COBR == "FEDERAL")
                    {

                        /*" -2731- COMPUTE WS-IMPRTO = V0CBPR-IMPMORNATU * 0,2 */
                        AREA_DE_WORK.WS_IMPRTO.Value = V0CBPR_IMPMORNATU * 0.2;

                        /*" -2732- COMPUTE AC-IMPRTO = AC-IMPRTO + WS-IMPRTO */
                        AREA_DE_WORK.AC_IMPRTO.Value = AREA_DE_WORK.AC_IMPRTO + AREA_DE_WORK.WS_IMPRTO;

                        /*" -2733- END-IF */
                    }


                    /*" -2734- END-IF */
                }


                /*" -2735- ELSE */
            }
            else
            {


                /*" -2736- IF V0PRVG-ESTR-COBR = 'FEDERAL' */

                if (V0PRVG_ESTR_COBR == "FEDERAL")
                {

                    /*" -2737- PERFORM R1109-00-CALCULA-RTO */

                    R1109_00_CALCULA_RTO_SECTION();

                    /*" -2738- ELSE */
                }
                else
                {


                    /*" -2740- MOVE 0 TO WS-PRMRTO WS-VLIOCC-RTO */
                    _.Move(0, AREA_DE_WORK.WS_PRMRTO, AREA_DE_WORK.WS_VLIOCC_RTO);

                    /*" -2741- END-IF */
                }


                /*" -2742- MOVE V0ENDO-NRENDOS-RES TO V0ENDO-NRENDOS */
                _.Move(V0ENDO_NRENDOS_RES, V0ENDO_NRENDOS);

                /*" -2744- COMPUTE AC-PRMVG-R = AC-PRMVG-R + V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG_R.Value = AREA_DE_WORK.AC_PRMVG_R + V0HCTB_PRMVG;

                /*" -2746- COMPUTE AC-PRMAP-R = AC-PRMAP-R + V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP_R.Value = AREA_DE_WORK.AC_PRMAP_R + V0HCTB_PRMAP;

                /*" -2748- COMPUTE AC-PRMRTO-R = AC-PRMRTO-R + WS-PRMRTO */
                AREA_DE_WORK.AC_PRMRTO_R.Value = AREA_DE_WORK.AC_PRMRTO_R + AREA_DE_WORK.WS_PRMRTO;

                /*" -2749- IF WTEM-RAMO-CONJ EQUAL 'SIM' */

                if (AREA_DE_WORK.WTEM_RAMO_CONJ == "SIM")
                {

                    /*" -2750- PERFORM R1130-00-ACUMULA-CONJ */

                    R1130_00_ACUMULA_CONJ_SECTION();

                    /*" -2751- END-IF */
                }


                /*" -2753- COMPUTE AC-IMPMORNATU-R = AC-IMPMORNATU-R + V0CBPR-IMPMORNATU */
                AREA_DE_WORK.AC_IMPMORNATU_R.Value = AREA_DE_WORK.AC_IMPMORNATU_R + V0CBPR_IMPMORNATU;

                /*" -2755- COMPUTE AC-IMPMORACID-R = AC-IMPMORACID-R + V0CBPR-IMPMORACID */
                AREA_DE_WORK.AC_IMPMORACID_R.Value = AREA_DE_WORK.AC_IMPMORACID_R + V0CBPR_IMPMORACID;

                /*" -2757- COMPUTE AC-IMPINVPERM-R = AC-IMPINVPERM-R + V0CBPR-IMPINVPERM */
                AREA_DE_WORK.AC_IMPINVPERM_R.Value = AREA_DE_WORK.AC_IMPINVPERM_R + V0CBPR_IMPINVPERM;

                /*" -2759- COMPUTE AC-IMPAMDS-R = AC-IMPAMDS-R + V0CBPR-IMPAMDS */
                AREA_DE_WORK.AC_IMPAMDS_R.Value = AREA_DE_WORK.AC_IMPAMDS_R + V0CBPR_IMPAMDS;

                /*" -2761- COMPUTE AC-IMPDH-R = AC-IMPDH-R + V0CBPR-IMPDH */
                AREA_DE_WORK.AC_IMPDH_R.Value = AREA_DE_WORK.AC_IMPDH_R + V0CBPR_IMPDH;

                /*" -2763- COMPUTE AC-IMPDIT-R = AC-IMPDIT-R + V0CBPR-IMPDIT */
                AREA_DE_WORK.AC_IMPDIT_R.Value = AREA_DE_WORK.AC_IMPDIT_R + V0CBPR_IMPDIT;

                /*" -2764- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

                if (V0CBPR_IMPDIT != 00)
                {

                    /*" -2765- PERFORM R1225-00-LE-PREMIO-DIT */

                    R1225_00_LE_PREMIO_DIT_SECTION();

                    /*" -2766- END-IF */
                }


                /*" -2767- IF V0PRVG-ESTR-COBR = 'FEDERAL' */

                if (V0PRVG_ESTR_COBR == "FEDERAL")
                {

                    /*" -2768- COMPUTE WS-IMPRTO = V0CBPR-IMPMORNATU * 0,2 */
                    AREA_DE_WORK.WS_IMPRTO.Value = V0CBPR_IMPMORNATU * 0.2;

                    /*" -2769- COMPUTE AC-IMPRTO-R = AC-IMPRTO-R + WS-IMPRTO */
                    AREA_DE_WORK.AC_IMPRTO_R.Value = AREA_DE_WORK.AC_IMPRTO_R + AREA_DE_WORK.WS_IMPRTO;

                    /*" -2770- END-IF */
                }


                /*" -2772- END-IF */
            }


            /*" -2772- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-SECTION */
        private void R1102_00_SELECT_RCAP_SECTION()
        {
            /*" -2812- MOVE '1102' TO WNR-EXEC-SQL. */
            _.Move("1102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2815- MOVE 'S' TO WTEM-V0RCAP. */
            _.Move("S", AREA_DE_WORK.WTEM_V0RCAP);

            /*" -2822- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_1 */

            R1102_00_SELECT_RCAP_DB_SELECT_1();

            /*" -2826- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2827- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2828- MOVE 'N' TO WTEM-V0RCAP */
                    _.Move("N", AREA_DE_WORK.WTEM_V0RCAP);

                    /*" -2830- GO TO R1102-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2832- MOVE '11A2' TO WNR-EXEC-SQL. */
            _.Move("11A2", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2847- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_2 */

            R1102_00_SELECT_RCAP_DB_SELECT_2();

            /*" -2851- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2852- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2853- MOVE '11A3' TO WNR-EXEC-SQL */
                    _.Move("11A3", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2869- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_3 */

                    R1102_00_SELECT_RCAP_DB_SELECT_3();

                    /*" -2872- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2873- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -2874- DISPLAY 'FONTE  - ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                            $"FONTE  - {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                            .Display();

                            /*" -2875- DISPLAY 'OPERACAO 100-199 NOT FOUND - 100 ' */
                            _.Display($"OPERACAO 100-199 NOT FOUND - 100 ");

                            /*" -2876- DISPLAY 'PULADO - NAO PROCESSADO          ' */
                            _.Display($"PULADO - NAO PROCESSADO          ");

                            /*" -2877- MOVE 'N' TO WTEM-V0RCAP */
                            _.Move("N", AREA_DE_WORK.WTEM_V0RCAP);

                            /*" -2878- GO TO R1102-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/ //GOTO
                            return;

                            /*" -2879- ELSE */
                        }
                        else
                        {


                            /*" -2880- DISPLAY 'FONTE  - ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                            $"FONTE  - {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                            .Display();

                            /*" -2881- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -2882- END-IF */
                        }


                        /*" -2883- END-IF */
                    }


                    /*" -2884- ELSE */
                }
                else
                {


                    /*" -2884- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-1 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_1()
        {
            /*" -2822- EXEC SQL SELECT FONTE, NRRCAP INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT END-EXEC. */

            var r1102_00_SELECT_RCAP_DB_SELECT_1_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_1_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-2 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_2()
        {
            /*" -2847- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 END-EXEC. */

            var r1102_00_SELECT_RCAP_DB_SELECT_2_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_2_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R1103-00-CALCULA-DTINIVIG-SECTION */
        private void R1103_00_CALCULA_DTINIVIG_SECTION()
        {
            /*" -2892- MOVE WS-DTRENOVA TO WS-DTBASE */
            _.Move(WS_DTRENOVA, AREA_DE_WORK.WS_DTBASE);

            /*" -2894- MOVE 01 TO WS-DIA. */
            _.Move(01, AREA_DE_WORK.WS_DIA);

            /*" -2895- IF WS-DTFATUR GREATER WS-DTBASE */

            if (AREA_DE_WORK.WS_DTFATUR > AREA_DE_WORK.WS_DTBASE)
            {

                /*" -2895- GO TO R1103-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1103_10_DIMINUI_UM_ANO */

            R1103_10_DIMINUI_UM_ANO();

        }

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-3 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_3()
        {
            /*" -2869- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND SITUACAO = '0' AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 END-EXEC */

            var r1102_00_SELECT_RCAP_DB_SELECT_3_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_3_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_3_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R1103-10-DIMINUI-UM-ANO */
        private void R1103_10_DIMINUI_UM_ANO(bool isPerform = false)
        {
            /*" -2900- COMPUTE WS-AABASE = WS-AABASE - 1 */
            AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE - 1;

            /*" -2902- COMPUTE WS-DDBASE = WS-DDBASE + WS-DIA */
            AREA_DE_WORK.WS_DTBASE.WS_DDBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DDBASE + AREA_DE_WORK.WS_DIA;

            /*" -2904- IF WS-MMBASE EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -2905- IF WS-DDBASE GREATER 31 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 31)
                {

                    /*" -2906- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -2907- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -2908- END-IF */
                }


                /*" -2910- END-IF */
            }


            /*" -2911- IF WS-MMBASE EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.In("04", "06", "09", "11"))
            {

                /*" -2912- IF WS-DDBASE GREATER 30 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 30)
                {

                    /*" -2913- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -2914- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -2915- END-IF */
                }


                /*" -2917- END-IF */
            }


            /*" -2918- IF WS-MMBASE EQUAL 02 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE == 02)
            {

                /*" -2919- IF WS-DDBASE GREATER 28 */

                if (AREA_DE_WORK.WS_DTBASE.WS_DDBASE > 28)
                {

                    /*" -2920- MOVE 01 TO WS-DDBASE */
                    _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DDBASE);

                    /*" -2921- COMPUTE WS-MMBASE = WS-MMBASE + 1 */
                    AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE + 1;

                    /*" -2922- END-IF */
                }


                /*" -2924- END-IF */
            }


            /*" -2925- IF WS-MMBASE GREATER 12 */

            if (AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE > 12)
            {

                /*" -2926- MOVE 01 TO WS-MMBASE */
                _.Move(01, AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_MMBASE);

                /*" -2927- COMPUTE WS-AABASE = WS-AABASE + 1 */
                AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE.Value = AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM.WS_AABASE + 1;

                /*" -2929- END-IF */
            }


            /*" -2930- IF WS-DTFATUR-AM LESS WS-DTBASE-AM */

            if (AREA_DE_WORK.WS_DTFATUR.WS_DTFATUR_AM < AREA_DE_WORK.WS_DTBASE.WS_DTBASE_AM)
            {

                /*" -2931- IF WS-DTBASE NOT GREATER V0SEGVG-DTINIVIG */

                if (AREA_DE_WORK.WS_DTBASE <= V0SEGVG_DTINIVIG)
                {

                    /*" -2932- MOVE V0SEGVG-DTINIVIG TO WS-DTBASE */
                    _.Move(V0SEGVG_DTINIVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -2933- ELSE */
                }
                else
                {


                    /*" -2934- MOVE ZEROS TO WS-DIA */
                    _.Move(0, AREA_DE_WORK.WS_DIA);

                    /*" -2934- GO TO R1103-10-DIMINUI-UM-ANO. */
                    new Task(() => R1103_10_DIMINUI_UM_ANO()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1103_99_SAIDA*/

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-SECTION */
        private void R1105_00_ACESSA_V1RAMOIND_SECTION()
        {
            /*" -2946- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2947- MOVE V0APOL-RAMO TO V1RIND-RAMO */
            _.Move(V0APOL_RAMO, V1RIND_RAMO);

            /*" -2950- MOVE V0ENDO-DTINIVIG TO V1RIND-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V1RIND_DTINIVIG);

            /*" -2957- PERFORM R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1 */

            R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();

            /*" -2961- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2962- DISPLAY 'PROBLEMA NO ACESSAO V1RAMOIND' */
                _.Display($"PROBLEMA NO ACESSAO V1RAMOIND");

                /*" -2962- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-DB-SELECT-1 */
        public void R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1()
        {
            /*" -2957- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1RIND-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG END-EXEC. */

            var r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 = new R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1()
            {
                V1RIND_DTINIVIG = V1RIND_DTINIVIG.ToString(),
                V1RIND_RAMO = V1RIND_RAMO.ToString(),
            };

            var executed_1 = R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1.Execute(r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_99_SAIDA*/

        [StopWatch]
        /*" R1107-00-ACESSA-V0PROPOSTAVF-SECTION */
        private void R1107_00_ACESSA_V0PROPOSTAVF_SECTION()
        {
            /*" -2973- MOVE 'R1107' TO WNR-EXEC-SQL. */
            _.Move("R1107", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2978- PERFORM R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1 */

            R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1();

            /*" -2982- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2983- DISPLAY 'PROBLEMA NO ACESSO A V0PROPOSTAVF' */
                _.Display($"PROBLEMA NO ACESSO A V0PROPOSTAVF");

                /*" -2983- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1107-00-ACESSA-V0PROPOSTAVF-DB-SELECT-1 */
        public void R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1()
        {
            /*" -2978- EXEC SQL SELECT NRTIT INTO :V0PRVF-NRTIT FROM SEGUROS.V0PROPOSTAVF WHERE NRCERTIF = :V0HCTB-NRCERTIF END-EXEC. */

            var r1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1 = new R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            var executed_1 = R1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1.Execute(r1107_00_ACESSA_V0PROPOSTAVF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRVF_NRTIT, V0PRVF_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1107_99_SAIDA*/

        [StopWatch]
        /*" R1109-00-CALCULA-RTO-SECTION */
        private void R1109_00_CALCULA_RTO_SECTION()
        {
            /*" -2994- MOVE 'R1109' TO WNR-EXEC-SQL. */
            _.Move("R1109", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3001- PERFORM R1109_00_CALCULA_RTO_DB_SELECT_1 */

            R1109_00_CALCULA_RTO_DB_SELECT_1();

            /*" -3005- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3006- DISPLAY 'PROBLEMA NO ACESSO A V0COBERPROPVA' */
                _.Display($"PROBLEMA NO ACESSO A V0COBERPROPVA");

                /*" -3008- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3009- COMPUTE WS-IMPRTO = V0CBPR-IMPMORNATU * 0,2. */
            AREA_DE_WORK.WS_IMPRTO.Value = V0CBPR_IMPMORNATU * 0.2;

            /*" -3011- COMPUTE WS-PRMRTO ROUNDED = (WS-IMPRTO * 0,0058) / 1000. */
            AREA_DE_WORK.WS_PRMRTO.Value = (AREA_DE_WORK.WS_IMPRTO * 0.0058) / 1000f;

            /*" -3013- COMPUTE WS-PRM-LIQ-RTO ROUNDED = WS-PRMRTO / WS-IND-IOF. */
            AREA_DE_WORK.WS_PRM_LIQ_RTO.Value = AREA_DE_WORK.WS_PRMRTO / AREA_DE_WORK.WS_IND_IOF;

            /*" -3014- COMPUTE WS-VLIOCC-RTO = WS-PRMRTO - WS-PRM-LIQ-RTO. */
            AREA_DE_WORK.WS_VLIOCC_RTO.Value = AREA_DE_WORK.WS_PRMRTO - AREA_DE_WORK.WS_PRM_LIQ_RTO;

        }

        [StopWatch]
        /*" R1109-00-CALCULA-RTO-DB-SELECT-1 */
        public void R1109_00_CALCULA_RTO_DB_SELECT_1()
        {
            /*" -3001- EXEC SQL SELECT IMPMORNATU INTO :V0CBPR-IMPMORNATU FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTINIVIG <= :V0ENDO-DTTERVIG AND DTTERVIG >= :V0ENDO-DTTERVIG END-EXEC. */

            var r1109_00_CALCULA_RTO_DB_SELECT_1_Query1 = new R1109_00_CALCULA_RTO_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
            };

            var executed_1 = R1109_00_CALCULA_RTO_DB_SELECT_1_Query1.Execute(r1109_00_CALCULA_RTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CBPR_IMPMORNATU, V0CBPR_IMPMORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1109_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-SECTION */
        private void R1110_00_VERIFICA_RCAP_SECTION()
        {
            /*" -3024- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -3026- MOVE 'S' TO WTEM-CONVERSAO. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSAO);

            /*" -3031- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_1 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_1();

            /*" -3035- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3036- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3037- MOVE 'N' TO WTEM-CONVERSAO */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSAO);

                    /*" -3038- ELSE */
                }
                else
                {


                    /*" -3040- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3041- IF V0PRVG-ESTR-COBR EQUAL 'MULT' */

            if (V0PRVG_ESTR_COBR == "MULT")
            {

                /*" -3042- IF WTEM-CONVERSAO EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_CONVERSAO == "S")
                {

                    /*" -3043- MOVE NUM-SICOB TO V0RCAP-NRTIT */
                    _.Move(NUM_SICOB, V0RCAP_NRTIT);

                    /*" -3044- ELSE */
                }
                else
                {


                    /*" -3045- MOVE V0HCTB-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0HCTB_NRCERTIF, V0RCAP_NRTIT);

                    /*" -3046- END-IF */
                }


                /*" -3047- ELSE */
            }
            else
            {


                /*" -3048- IF V0PRVG-ESTR-COBR EQUAL 'FEDERAL' */

                if (V0PRVG_ESTR_COBR == "FEDERAL")
                {

                    /*" -3049- PERFORM R1107-00-ACESSA-V0PROPOSTAVF */

                    R1107_00_ACESSA_V0PROPOSTAVF_SECTION();

                    /*" -3050- MOVE V0PRVF-NRTIT TO V0RCAP-NRTIT */
                    _.Move(V0PRVF_NRTIT, V0RCAP_NRTIT);

                    /*" -3051- ELSE */
                }
                else
                {


                    /*" -3053- DISPLAY 'ESTRUTURA DE COBRANCA DESCONHECIDA ' V0PRVG-ESTR-COBR */
                    _.Display($"ESTRUTURA DE COBRANCA DESCONHECIDA {V0PRVG_ESTR_COBR}");

                    /*" -3056- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3058- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3070- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_2 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_2();

            /*" -3074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3075- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3076- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -3077- ELSE */
                }
                else
                {


                    /*" -3079- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3080- IF V0RCAP-SITUACAO EQUAL '1' */

            if (V0RCAP_SITUACAO == "1")
            {

                /*" -3081- MOVE '1110' TO WNR-EXEC-SQL */
                _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3087- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_1 */

                R1110_00_VERIFICA_RCAP_DB_UPDATE_1();

                /*" -3089- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3091- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3093- MOVE '1113' TO WNR-EXEC-SQL. */
            _.Move("1113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3109- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_3 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_3();

            /*" -3113- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3115- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3117- PERFORM R1120-00-BAIXA-RCAP. */

            R1120_00_BAIXA_RCAP_SECTION();

            /*" -3119- MOVE '1115' TO WNR-EXEC-SQL. */
            _.Move("1115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3129- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_2 */

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2();

            /*" -3133- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3135- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3135- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-1 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -3031- EXEC SQL SELECT NUM_SICOB INTO :NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0HCTB-NRCERTIF END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-UPDATE-1 */
        public void R1110_00_VERIFICA_RCAP_DB_UPDATE_1()
        {
            /*" -3087- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRENDOS = :V0ENDO-NRENDOS, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-2 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -3070- EXEC SQL SELECT FONTE, NRRCAP, SITUACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V0RCAP-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO IN ( '0' , '1' ) END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1120-00-BAIXA-RCAP-SECTION */
        private void R1120_00_BAIXA_RCAP_SECTION()
        {
            /*" -3144- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1120_10_DECLARE_V0RCAPCOMP */

            R1120_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-UPDATE-2 */
        public void R1110_00_VERIFICA_RCAP_DB_UPDATE_2()
        {
            /*" -3129- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0ENDO-NUM-APOLICE, NRENDOS = :V0ENDO-NRENDOS, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-3 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_3()
        {
            /*" -3109- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP */
        private void R1120_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3169- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -3172- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -3176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3176- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -3172- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R1130-10-DECLARE-VGHISTCONT-DB-DECLARE-1 */
        public void R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1()
        {
            /*" -3317- EXEC SQL DECLARE CVGHISTCONT CURSOR FOR SELECT NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO FROM SEGUROS.VG_HIST_CONT_COBER WHERE NUM_CERTIFICADO = :V0HCTB-NRCERTIF AND NUM_PARCELA = :V0HCTB-NRPARCEL AND NUM_TITULO = :V0HCTB-NRTIT AND OCORR_HISTORICO = :V0HCTB-OCORHIST END-EXEC. */
            CVGHISTCONT = new VA0139B_CVGHISTCONT(true);
            string GetQuery_CVGHISTCONT()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_PARCELA
							, 
							NUM_TITULO
							, 
							OCORR_HISTORICO
							, 
							COD_GRUPO_SUSEP
							, 
							RAMO_EMISSOR
							, 
							COD_MODALIDADE
							, 
							COD_COBERTURA
							, 
							VLR_PREMIO_RAMO
							, 
							COD_USUARIO
							, 
							DTH_ATUALIZACAO 
							FROM SEGUROS.VG_HIST_CONT_COBER 
							WHERE NUM_CERTIFICADO = '{V0HCTB_NRCERTIF}' 
							AND NUM_PARCELA = '{V0HCTB_NRPARCEL}' 
							AND NUM_TITULO = '{V0HCTB_NRTIT}' 
							AND OCORR_HISTORICO = '{V0HCTB_OCORHIST}'";

                return query;
            }
            CVGHISTCONT.GetQueryEvent += GetQuery_CVGHISTCONT;

        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP */
        private void R1120_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3183- MOVE '1121' TO WNR-EXEC-SQL. */
            _.Move("1121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3198- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -3202- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3203- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3203- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -3205- GO TO R1120-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/ //GOTO
                    return;

                    /*" -3206- ELSE */
                }
                else
                {


                    /*" -3206- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -3198- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.V1RCAC_FONTE, V1RCAC_FONTE);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAP, V1RCAC_NRRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_NRRCAPCO, V1RCAC_NRRCAPCO);
                _.Move(V1RCAPCOMP.V1RCAC_OPERACAO, V1RCAC_OPERACAO);
                _.Move(V1RCAPCOMP.V1RCAC_DTMOVTO, V1RCAC_DTMOVTO);
                _.Move(V1RCAPCOMP.V1RCAC_HORAOPER, V1RCAC_HORAOPER);
                _.Move(V1RCAPCOMP.V1RCAC_SITUACAO, V1RCAC_SITUACAO);
                _.Move(V1RCAPCOMP.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(V1RCAPCOMP.V1RCAC_VLRCAP, V1RCAC_VLRCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
                _.Move(V1RCAPCOMP.V1RCAC_DTCADAST, V1RCAC_DTCADAST);
                _.Move(V1RCAPCOMP.V1RCAC_SITCONTB, V1RCAC_SITCONTB);
            }

        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -3203- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP */
        private void R1120_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3212- MOVE '1122' TO WNR-EXEC-SQL. */
            _.Move("1122", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3222- PERFORM R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -3226- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3228- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3228- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -3222- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP */
        private void R1120_40_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3234- MOVE '1123' TO WNR-EXEC-SQL. */
            _.Move("1123", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3235- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -3236- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -3239- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -3257- PERFORM R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -3261- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3263- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3263- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -3257- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , CURRENT TIME, :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
                V1RCAC_SITUACAO = V1RCAC_SITUACAO.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_DATARCAP = V1RCAC_DATARCAP.ToString(),
                V1RCAC_DTCADAST = V1RCAC_DTCADAST.ToString(),
                V1RCAC_SITCONTB = V1RCAC_SITCONTB.ToString(),
                V1RCAC_COD_EMPRESA = V1RCAC_COD_EMPRESA.ToString(),
            };

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO */
        private void R1120_50_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -3271- MOVE '1124' TO WNR-EXEC-SQL. */
            _.Move("1124", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3278- PERFORM R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -3283- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3286- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3286- GO TO R1120-20-FETCH-V0RCAPCOMP. */

            R1120_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -3278- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-ACUMULA-CONJ-SECTION */
        private void R1130_00_ACUMULA_CONJ_SECTION()
        {
            /*" -3296- MOVE '1130' TO WNR-EXEC-SQL. */
            _.Move("1130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3296- MOVE 'NAO' TO WTEM-VG082. */
            _.Move("NAO", AREA_DE_WORK.WTEM_VG082);

            /*" -0- FLUXCONTROL_PERFORM R1130_10_DECLARE_VGHISTCONT */

            R1130_10_DECLARE_VGHISTCONT();

        }

        [StopWatch]
        /*" R1130-10-DECLARE-VGHISTCONT */
        private void R1130_10_DECLARE_VGHISTCONT(bool isPerform = false)
        {
            /*" -3317- PERFORM R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1 */

            R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1();

            /*" -3320- PERFORM R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1 */

            R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1();

            /*" -3324- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3324- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1130-10-DECLARE-VGHISTCONT-DB-OPEN-1 */
        public void R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1()
        {
            /*" -3320- EXEC SQL OPEN CVGHISTCONT END-EXEC. */

            CVGHISTCONT.Open();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-DECLARE-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1()
        {
            /*" -3484- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT DISTINCT CODCOSS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND DTINIVIG <= :V0ENDO-DTEMIS AND DTTERVIG >= :V0ENDO-DTEMIS ORDER BY CODCOSS END-EXEC. */
            V1APOLCOSCED = new VA0139B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT DISTINCT CODCOSS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V0ENDO_NUM_APOLICE}' 
							AND DTINIVIG <= '{V0ENDO_DTEMIS}' 
							AND DTTERVIG >= '{V0ENDO_DTEMIS}' 
							ORDER BY CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }

        [StopWatch]
        /*" R1130-20-FETCH-VGHISTCONT */
        private void R1130_20_FETCH_VGHISTCONT(bool isPerform = false)
        {
            /*" -3332- MOVE '1121' TO WNR-EXEC-SQL. */
            _.Move("1121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3344- PERFORM R1130_20_FETCH_VGHISTCONT_DB_FETCH_1 */

            R1130_20_FETCH_VGHISTCONT_DB_FETCH_1();

            /*" -3348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3349- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3349- PERFORM R1130_20_FETCH_VGHISTCONT_DB_CLOSE_1 */

                    R1130_20_FETCH_VGHISTCONT_DB_CLOSE_1();

                    /*" -3351- IF WTEM-VG082 EQUAL 'NAO' */

                    if (AREA_DE_WORK.WTEM_VG082 == "NAO")
                    {

                        /*" -3353- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

                        if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
                        {

                            /*" -3356- ADD V0HCTB-PRMVG V0HCTB-PRMAP TO TB-RAMO-VALOR-PRM (V0APOL-RAMO) */
                            TABELA_RAMO.FILLER_1[V0APOL_RAMO].TB_RAMO_VALOR_PRM.Value = TABELA_RAMO.FILLER_1[V0APOL_RAMO].TB_RAMO_VALOR_PRM + V0HCTB_PRMAP;

                            /*" -3357- ELSE */
                        }
                        else
                        {


                            /*" -3360- ADD V0HCTB-PRMVG V0HCTB-PRMAP TO TB-RAMO-VALOR-PRM-R (V0APOL-RAMO) */
                            TABELA_RAMO_R.FILLER_2[V0APOL_RAMO].TB_RAMO_VALOR_PRM_R.Value = TABELA_RAMO_R.FILLER_2[V0APOL_RAMO].TB_RAMO_VALOR_PRM_R + V0HCTB_PRMAP;

                            /*" -3361- END-IF */
                        }


                        /*" -3362- END-IF */
                    }


                    /*" -3363- GO TO R1130-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/ //GOTO
                    return;

                    /*" -3364- ELSE */
                }
                else
                {


                    /*" -3366- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3368- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -3370- ADD VG082-VLR-PREMIO-RAMO TO TB-RAMO-VALOR-PRM (VG082-RAMO-EMISSOR) */
                TABELA_RAMO.FILLER_1[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM.Value = TABELA_RAMO.FILLER_1[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM + VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO;

                /*" -3371- ELSE */
            }
            else
            {


                /*" -3373- ADD VG082-VLR-PREMIO-RAMO TO TB-RAMO-VALOR-PRM-R (VG082-RAMO-EMISSOR) */
                TABELA_RAMO_R.FILLER_2[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM_R.Value = TABELA_RAMO_R.FILLER_2[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM_R + VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO;

                /*" -3375- END-IF. */
            }


            /*" -3377- MOVE 'SIM' TO WTEM-VG082. */
            _.Move("SIM", AREA_DE_WORK.WTEM_VG082);

            /*" -3377- GO TO R1130-20-FETCH-VGHISTCONT. */
            new Task(() => R1130_20_FETCH_VGHISTCONT()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1130-20-FETCH-VGHISTCONT-DB-FETCH-1 */
        public void R1130_20_FETCH_VGHISTCONT_DB_FETCH_1()
        {
            /*" -3344- EXEC SQL FETCH CVGHISTCONT INTO :VG082-NUM-CERTIFICADO , :VG082-NUM-PARCELA , :VG082-NUM-TITULO , :VG082-OCORR-HISTORICO , :VG082-COD-GRUPO-SUSEP , :VG082-RAMO-EMISSOR , :VG082-COD-MODALIDADE , :VG082-COD-COBERTURA , :VG082-VLR-PREMIO-RAMO , :VG082-COD-USUARIO , :VG082-DTH-ATUALIZACAO END-EXEC. */

            if (CVGHISTCONT.Fetch())
            {
                _.Move(CVGHISTCONT.VG082_NUM_CERTIFICADO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO);
                _.Move(CVGHISTCONT.VG082_NUM_PARCELA, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA);
                _.Move(CVGHISTCONT.VG082_NUM_TITULO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO);
                _.Move(CVGHISTCONT.VG082_OCORR_HISTORICO, VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO);
                _.Move(CVGHISTCONT.VG082_COD_GRUPO_SUSEP, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_GRUPO_SUSEP);
                _.Move(CVGHISTCONT.VG082_RAMO_EMISSOR, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);
                _.Move(CVGHISTCONT.VG082_COD_MODALIDADE, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE);
                _.Move(CVGHISTCONT.VG082_COD_COBERTURA, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA);
                _.Move(CVGHISTCONT.VG082_VLR_PREMIO_RAMO, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);
                _.Move(CVGHISTCONT.VG082_COD_USUARIO, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_USUARIO);
                _.Move(CVGHISTCONT.VG082_DTH_ATUALIZACAO, VG082.DCLVG_HIST_CONT_COBER.VG082_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" R1130-20-FETCH-VGHISTCONT-DB-CLOSE-1 */
        public void R1130_20_FETCH_VGHISTCONT_DB_CLOSE_1()
        {
            /*" -3349- EXEC SQL CLOSE CVGHISTCONT END-EXEC */

            CVGHISTCONT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-SECTION */
        private void R1220_00_LE_PREMIO_DIT_SECTION()
        {
            /*" -3389- MOVE V0CBPR-PRMDIT TO V0PLAN-PRMDIT. */
            _.Move(V0CBPR_PRMDIT, V0PLAN_PRMDIT);

            /*" -3392- MOVE '1222' TO WNR-EXEC-SQL. */
            _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3400- PERFORM R1220_00_LE_PREMIO_DIT_DB_SELECT_1 */

            R1220_00_LE_PREMIO_DIT_DB_SELECT_1();

            /*" -3404- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3405- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3406- MOVE V0PROP-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0PROP_NRCERTIF, V0RCAP_NRTIT);

                    /*" -3407- PERFORM R1102-00-SELECT-RCAP */

                    R1102_00_SELECT_RCAP_SECTION();

                    /*" -3408- MOVE V1RCAC-DATARCAP TO WS-DTBASE */
                    _.Move(V1RCAC_DATARCAP, AREA_DE_WORK.WS_DTBASE);

                    /*" -3409- ELSE */
                }
                else
                {


                    /*" -3410- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3411- ELSE */
                }

            }
            else
            {


                /*" -3412- IF V0SEGVG-DTRENOVA-IND LESS ZEROS */

                if (V0SEGVG_DTRENOVA_IND < 00)
                {

                    /*" -3413- MOVE V0SEGVG-DTINIVIG TO WS-DTBASE */
                    _.Move(V0SEGVG_DTINIVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -3414- ELSE */
                }
                else
                {


                    /*" -3415- MOVE V0SEGVG-DTRENOVA TO WS-DTRENOVA */
                    _.Move(V0SEGVG_DTRENOVA, WS_DTRENOVA);

                    /*" -3416- MOVE V0ENDO-DTINIVIG TO WS-DTFATUR */
                    _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WS_DTFATUR);

                    /*" -3418- PERFORM R1103-00-CALCULA-DTINIVIG. */

                    R1103_00_CALCULA_DTINIVIG_SECTION();
                }

            }


            /*" -3420- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -3421- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -3423- COMPUTE WS-PRM-LIQ-DIT ROUNDED = V0PLAN-PRMDIT / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_DIT.Value = V0PLAN_PRMDIT / AREA_DE_WORK.WS_IND_IOF;

            /*" -3425- COMPUTE WS-VLIOCC-DIT = V0PLAN-PRMDIT - WS-PRM-LIQ-DIT */
            AREA_DE_WORK.WS_VLIOCC_DIT.Value = V0PLAN_PRMDIT - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -3426- ADD V0PLAN-PRMDIT TO AC-PRMDIT. */
            AREA_DE_WORK.AC_PRMDIT.Value = AREA_DE_WORK.AC_PRMDIT + V0PLAN_PRMDIT;

            /*" -3427- COMPUTE WS-VLIOCC-TOT-DIT = WS-VLIOCC-TOT-DIT + WS-VLIOCC-DIT. */
            AREA_DE_WORK.WS_VLIOCC_TOT_DIT.Value = AREA_DE_WORK.WS_VLIOCC_TOT_DIT + AREA_DE_WORK.WS_VLIOCC_DIT;

        }

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-DB-SELECT-1 */
        public void R1220_00_LE_PREMIO_DIT_DB_SELECT_1()
        {
            /*" -3400- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_ADMISSAO INTO :V0SEGVG-DTINIVIG, :V0SEGVG-DTRENOVA:V0SEGVG-DTRENOVA-IND FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 = new R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1.Execute(r1220_00_LE_PREMIO_DIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGVG_DTINIVIG, V0SEGVG_DTINIVIG);
                _.Move(executed_1.V0SEGVG_DTRENOVA, V0SEGVG_DTRENOVA);
                _.Move(executed_1.V0SEGVG_DTRENOVA_IND, V0SEGVG_DTRENOVA_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1225-00-LE-PREMIO-DIT-SECTION */
        private void R1225_00_LE_PREMIO_DIT_SECTION()
        {
            /*" -3438- MOVE V0CBPR-PRMDIT TO V0PLAN-PRMDIT. */
            _.Move(V0CBPR_PRMDIT, V0PLAN_PRMDIT);

            /*" -3441- MOVE '1222' TO WNR-EXEC-SQL. */
            _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3449- PERFORM R1225_00_LE_PREMIO_DIT_DB_SELECT_1 */

            R1225_00_LE_PREMIO_DIT_DB_SELECT_1();

            /*" -3453- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3454- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3455- MOVE V0PROP-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0PROP_NRCERTIF, V0RCAP_NRTIT);

                    /*" -3456- PERFORM R1102-00-SELECT-RCAP */

                    R1102_00_SELECT_RCAP_SECTION();

                    /*" -3457- MOVE V1RCAC-DATARCAP TO WS-DTBASE */
                    _.Move(V1RCAC_DATARCAP, AREA_DE_WORK.WS_DTBASE);

                    /*" -3458- ELSE */
                }
                else
                {


                    /*" -3459- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3460- ELSE */
                }

            }
            else
            {


                /*" -3461- IF V0SEGVG-DTRENOVA-IND LESS ZEROS */

                if (V0SEGVG_DTRENOVA_IND < 00)
                {

                    /*" -3462- MOVE V0SEGVG-DTINIVIG TO WS-DTBASE */
                    _.Move(V0SEGVG_DTINIVIG, AREA_DE_WORK.WS_DTBASE);

                    /*" -3463- ELSE */
                }
                else
                {


                    /*" -3464- MOVE V0SEGVG-DTRENOVA TO WS-DTRENOVA */
                    _.Move(V0SEGVG_DTRENOVA, WS_DTRENOVA);

                    /*" -3465- MOVE V0ENDO-DTINIVIG TO WS-DTFATUR */
                    _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WS_DTFATUR);

                    /*" -3467- PERFORM R1103-00-CALCULA-DTINIVIG. */

                    R1103_00_CALCULA_DTINIVIG_SECTION();
                }

            }


            /*" -3467- ADD V0PLAN-PRMDIT TO AC-PRMDIT-R. */
            AREA_DE_WORK.AC_PRMDIT_R.Value = AREA_DE_WORK.AC_PRMDIT_R + V0PLAN_PRMDIT;

        }

        [StopWatch]
        /*" R1225-00-LE-PREMIO-DIT-DB-SELECT-1 */
        public void R1225_00_LE_PREMIO_DIT_DB_SELECT_1()
        {
            /*" -3449- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_ADMISSAO INTO :V0SEGVG-DTINIVIG, :V0SEGVG-DTRENOVA:V0SEGVG-DTRENOVA-IND FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1 = new R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1.Execute(r1225_00_LE_PREMIO_DIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGVG_DTINIVIG, V0SEGVG_DTINIVIG);
                _.Move(executed_1.V0SEGVG_DTRENOVA, V0SEGVG_DTRENOVA);
                _.Move(executed_1.V0SEGVG_DTRENOVA_IND, V0SEGVG_DTRENOVA_IND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1225_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-SECTION */
        private void R1300_00_GRAVA_COSSEGURO_SECTION()
        {
            /*" -3484- PERFORM R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1 */

            R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1();

            /*" -3488- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3488- PERFORM R1300_00_GRAVA_COSSEGURO_DB_OPEN_1 */

            R1300_00_GRAVA_COSSEGURO_DB_OPEN_1();

            /*" -3492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3492- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_10_FETCH_V1APOLCOSCED */

            R1300_10_FETCH_V1APOLCOSCED();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-OPEN-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_OPEN_1()
        {
            /*" -3488- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED */
        private void R1300_10_FETCH_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -3500- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3502- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -3505- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3506- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3506- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -3508- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -3509- ELSE */
                }
                else
                {


                    /*" -3512- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3514- MOVE '1303' TO WNR-EXEC-SQL. */
            _.Move("1303", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3515- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -3516- MOVE V0ENDO-NUM-APOLICE TO V0ORDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0ORDC_NUM_APOL);

            /*" -3517- MOVE V0ENDO-NRENDOS TO V0ORDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0ORDC_NRENDOS);

            /*" -3520- MOVE V1COSP-CONGENER TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V1COSP_CONGENER, V0ORDC_CODCOSS);
            _.Move(V1COSP_CONGENER, AREA_DE_WORK.FILLER_8.WWORK_ORD_CONGE);


            /*" -3522- MOVE V0APOL-ORGAO TO WWORK-ORD-ORGAO. */
            _.Move(V0APOL_ORGAO, AREA_DE_WORK.FILLER_8.WWORK_ORD_ORGAO);

            /*" -3524- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -3526- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -3532- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1();

            /*" -3536- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3538- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3540- MOVE '2288' TO WNR-EXEC-SQL. */
            _.Move("2288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3542- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -3544- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_8.WWORK_ORD_SEQUE);

            /*" -3546- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -3554- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1();

            /*" -3557- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3559- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3561- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -3566- MOVE '1304' TO WNR-EXEC-SQL. */
            _.Move("1304", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3572- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1();

            /*" -3576- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3578- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3580- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

            /*" -3581- MOVE 'EM0103B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0103B1", V0EDIA_CODRELAT);

            /*" -3582- MOVE V0ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -3583- MOVE V0ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -3584- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -3585- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -3586- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -3587- MOVE V0APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(V0APOL_RAMO, V0EDIA_RAMO);

            /*" -3588- MOVE ZEROS TO V0EDIA-FONTE. */
            _.Move(0, V0EDIA_FONTE);

            /*" -3589- MOVE V1COSP-CONGENER TO V0EDIA-CONGENER. */
            _.Move(V1COSP_CONGENER, V0EDIA_CONGENER);

            /*" -3591- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -3593- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -3594- MOVE V0ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(V0ENDO_FONTE, V0EDIA_FONTE);

            /*" -3595- MOVE 'EM0105B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0105B1", V0EDIA_CODRELAT);

            /*" -3597- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -3597- GO TO R1300-10-FETCH-V1APOLCOSCED. */
            new Task(() => R1300_10_FETCH_V1APOLCOSCED()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -3502- EXEC SQL FETCH V1APOLCOSCED INTO :V1COSP-CONGENER END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1COSP_CONGENER, V1COSP_CONGENER);
            }

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -3506- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-SELECT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -3532- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1 = new R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1()
            {
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            var executed_1 = R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NCOS_NRORDEM, V1NCOS_NRORDEM);
            }


        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-INSERT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1()
        {
            /*" -3554- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1 = new R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0ORDC_NUM_APOL = V0ORDC_NUM_APOL.ToString(),
                V0ORDC_NRENDOS = V0ORDC_NRENDOS.ToString(),
                V0ORDC_CODCOSS = V0ORDC_CODCOSS.ToString(),
                V0ORDC_ORDEM_CED = V0ORDC_ORDEM_CED.ToString(),
                V0ORDC_COD_EMPRESA = V0ORDC_COD_EMPRESA.ToString(),
            };

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-UPDATE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1()
        {
            /*" -3572- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 = new R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1()
            {
                V1NCOS_NRORDEM = V1NCOS_NRORDEM.ToString(),
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-V0HISTOPARC-SECTION */
        private void R1400_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -3608- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3609- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -3611- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -3612- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3613- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3614- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3616- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3618- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3619- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3620- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3621- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3622- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3623- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3624- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3626- COMPUTE V0HISP-VLIOCC = V0HISP-VLPRMTOT - V0HISP-VLPRMLIQ */
            V0HISP_VLIOCC.Value = V0HISP_VLPRMTOT - V0HISP_VLPRMLIQ;

            /*" -3627- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3628- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3629- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3630- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -3631- MOVE ZEROS TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3632- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3633- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3634- MOVE 'VA0139B' TO V0HISP-COD-USUAR */
            _.Move("VA0139B", V0HISP_COD_USUAR);

            /*" -3636- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3638- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3640- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3640- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-VERIFICA-OPCAO-PAGTO-SECTION */
        private void R1420_00_VERIFICA_OPCAO_PAGTO_SECTION()
        {
            /*" -3652- MOVE '1420' TO WNR-EXEC-SQL */
            _.Move("1420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3654- INITIALIZE DCLOPCAO-PAG-VIDAZUL */
            _.Initialize(
                OPCPAGVI.DCLOPCAO_PAG_VIDAZUL
            );

            /*" -3656- MOVE V0HCTB-NRCERTIF TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(V0HCTB_NRCERTIF, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -3662- PERFORM R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1 */

            R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1();

            /*" -3665- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3666- DISPLAY 'R1420-00 - FALHA NA CONSULTA OPCAO_PAG_VIDAZUL' */
                _.Display($"R1420-00 - FALHA NA CONSULTA OPCAO_PAG_VIDAZUL");

                /*" -3667- DISPLAY 'NUM_CERTIFICADO = ' OPCPAGVI-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                /*" -3668- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3670- END-IF */
            }


            /*" -3670- . */

        }

        [StopWatch]
        /*" R1420-00-VERIFICA-OPCAO-PAGTO-DB-SELECT-1 */
        public void R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1()
        {
            /*" -3662- EXEC SQL SELECT OPCAO_PAGAMENTO INTO :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC */

            var r1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1 = new R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1.Execute(r1420_00_VERIFICA_OPCAO_PAGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-SECTION */
        private void R1450_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3682- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3711- PERFORM R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3717- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3717- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3711- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TARIFA = V0HISP_PRM_TARIFA.ToString(),
                V0HISP_VAL_DESCON = V0HISP_VAL_DESCON.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUAR = V0HISP_COD_USUAR.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R1500_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -3728- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -3729- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -3731- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3732- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3733- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3735- MOVE 0221 TO V0HISP-OPERACAO */
            _.Move(0221, V0HISP_OPERACAO);

            /*" -3737- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3738- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3739- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3740- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3741- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3742- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3743- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3745- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3746- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -3747- MOVE V1SIST-DTMOVACB TO V0HISP-DTVENCTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTVENCTO);

            /*" -3748- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3749- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -3750- MOVE 0 TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3751- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3752- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3753- MOVE 'VA0139B' TO V0HISP-COD-USUAR */
            _.Move("VA0139B", V0HISP_COD_USUAR);

            /*" -3755- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3756- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3758- MOVE V1SIST-DTMOVACB TO V0HISP-DTQITBCO. */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTQITBCO);

            /*" -3760- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3760- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-SECTION */
        private void R1600_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -3772- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3792- PERFORM R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -3796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3798- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3798- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -3792- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1 = new R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_IMP_SEG_IX = V0COBA_IMP_SEG_IX.ToString(),
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_IMP_SEG_VR = V0COBA_IMP_SEG_VR.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_FATOR_MULT = V0COBA_FATOR_MULT.ToString(),
                V0COBA_DATA_INIVI = V0COBA_DATA_INIVI.ToString(),
                V0COBA_DATA_TERVI = V0COBA_DATA_TERVI.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
                V0COBA_SITUACAO = V0COBA_SITUACAO.ToString(),
                VIND_SITUACAO = VIND_SITUACAO.ToString(),
            };

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-SECTION */
        private void R1700_INCLUI_V0EMISDIARIA_SECTION()
        {
            /*" -3809- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3824- PERFORM R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -3827- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3828- DISPLAY 'R1700-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"R1700-00 (REGISTRO DUPLICADO) ... ");

                /*" -3830- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3832- DISPLAY 'R1700-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1700-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -3834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3834- ADD 1 TO AC-I-V0EMISDIARIA. */
            AREA_DE_WORK.AC_I_V0EMISDIARIA.Value = AREA_DE_WORK.AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -3824- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , NULL , CURRENT TIMESTAMP) END-EXEC. */

            var r1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1()
            {
                V0EDIA_CODRELAT = V0EDIA_CODRELAT.ToString(),
                V0EDIA_NUM_APOL = V0EDIA_NUM_APOL.ToString(),
                V0EDIA_NRENDOS = V0EDIA_NRENDOS.ToString(),
                V0EDIA_NRPARCEL = V0EDIA_NRPARCEL.ToString(),
                V0EDIA_DTMOVTO = V0EDIA_DTMOVTO.ToString(),
                V0EDIA_ORGAO = V0EDIA_ORGAO.ToString(),
                V0EDIA_RAMO = V0EDIA_RAMO.ToString(),
                V0EDIA_FONTE = V0EDIA_FONTE.ToString(),
                V0EDIA_CONGENER = V0EDIA_CONGENER.ToString(),
                V0EDIA_CODCORR = V0EDIA_CODCORR.ToString(),
                V0EDIA_SITUACAO = V0EDIA_SITUACAO.ToString(),
            };

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -3846- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -3847- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -3848- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -3850- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -3851- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -3852- DISPLAY 'LIDOS  V0HISTCONTABILVA  ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS  V0HISTCONTABILVA  {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -3853- DISPLAY 'INSERT V0ENDOSSO         ' AC-I-V0ENDOSSO. */
            _.Display($"INSERT V0ENDOSSO         {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -3854- DISPLAY 'INSERT V0RCAPCOMP        ' AC-I-V0RCAPCOMP. */
            _.Display($"INSERT V0RCAPCOMP        {AREA_DE_WORK.AC_I_V0RCAPCOMP}");

            /*" -3855- DISPLAY 'INSERT V0ORDECOSCED      ' AC-I-V0ORDECOSCED. */
            _.Display($"INSERT V0ORDECOSCED      {AREA_DE_WORK.AC_I_V0ORDECOSCED}");

            /*" -3856- DISPLAY 'INSERT V0EMISDIARIA      ' AC-I-V0EMISDIARIA. */
            _.Display($"INSERT V0EMISDIARIA      {AREA_DE_WORK.AC_I_V0EMISDIARIA}");

            /*" -3857- DISPLAY 'INSERT V0PARCELA         ' AC-I-V0PARCELA. */
            _.Display($"INSERT V0PARCELA         {AREA_DE_WORK.AC_I_V0PARCELA}");

            /*" -3858- DISPLAY 'INSERT V0HISTOPARC       ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC       {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -3859- DISPLAY 'INSERT V0COBERAPOL       ' AC-I-V0COBERAPOL. */
            _.Display($"INSERT V0COBERAPOL       {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -3860- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -3861- DISPLAY 'UPDATE V0RCAP            ' AC-U-V0RCAP. */
            _.Display($"UPDATE V0RCAP            {AREA_DE_WORK.AC_U_V0RCAP}");

            /*" -3862- DISPLAY 'UPDATE V0RCAPCOMP        ' AC-U-V0RCAPCOMP. */
            _.Display($"UPDATE V0RCAPCOMP        {AREA_DE_WORK.AC_U_V0RCAPCOMP}");

            /*" -3863- DISPLAY 'UPDATE V0NUMEROAES       ' AC-U-V0NUMERAES. */
            _.Display($"UPDATE V0NUMEROAES       {AREA_DE_WORK.AC_U_V0NUMERAES}");

            /*" -3864- DISPLAY 'UPDATE V0FONTE           ' AC-U-V0FONTE. */
            _.Display($"UPDATE V0FONTE           {AREA_DE_WORK.AC_U_V0FONTE}");

            /*" -3865- DISPLAY 'UPDATE V0HISTCONTABILVA  ' AC-U-V0HISTCONTABILVA. */
            _.Display($"UPDATE V0HISTCONTABILVA  {AREA_DE_WORK.AC_U_V0HISTCONTABILVA}");

            /*" -3866- DISPLAY 'UPDATE V0NUMERO-COSSEGURO' AC-U-V0NUMERO-COSSEGURO. */
            _.Display($"UPDATE V0NUMERO-COSSEGURO{AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO}");

            /*" -3867- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -3868- DISPLAY 'ERRO SITUACAO CERTIFIC.  ' WS-QTD-SIT-INVAL. */
            _.Display($"ERRO SITUACAO CERTIFIC.  {WS_QTD_SIT_INVAL}");

            /*" -3868- DISPLAY '------------------------------------------' . */
            _.Display($"------------------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -3878- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3880- INITIALIZE REGISTRO-LINKAGE-GE0510S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -3881- MOVE V0HCTB-NUM-APOLICE TO LK-GE510-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -3883- MOVE V0HCTB-CODSUBES TO LK-GE510-COD-SUBGRUPO */
            _.Move(V0HCTB_CODSUBES, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -3885- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S. */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -3886- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -3887- MOVE LK-GE510-COD-MODALIDADE TO V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, V0APOL_MODALIDA);

                /*" -3888- ELSE */
            }
            else
            {


                /*" -3889- DISPLAY ' ' */
                _.Display($" ");

                /*" -3890- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3891- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -3892- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -3893- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3894- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -3895- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -3896- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -3897- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -3898- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -3899- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -3900- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -3901- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3902- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3902- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -3916- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -3917- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -3918- DISPLAY 'APOLICE     ' V0HCTB-NUM-APOLICE */
            _.Display($"APOLICE     {V0HCTB_NUM_APOLICE}");

            /*" -3919- DISPLAY 'SUBGRUPO    ' V0ENDO-CODSUBES */
            _.Display($"SUBGRUPO    {V0ENDO_CODSUBES}");

            /*" -3920- DISPLAY 'CERTIFICADO ' V0HCTB-NRCERTIF */
            _.Display($"CERTIFICADO {V0HCTB_NRCERTIF}");

            /*" -3921- DISPLAY 'NROENDO     ' V0ENDO-NRENDOS */
            _.Display($"NROENDO     {V0ENDO_NRENDOS}");

            /*" -3922- DISPLAY 'FONTE       ' V0ENDO-FONTE */
            _.Display($"FONTE       {V0ENDO_FONTE}");

            /*" -3923- DISPLAY 'NROPROP     ' V0ENDO-NRPROPOS */
            _.Display($"NROPROP     {V0ENDO_NRPROPOS}");

            /*" -3924- DISPLAY 'PRODUTO     ' V0PROP-CODPRODU */
            _.Display($"PRODUTO     {V0PROP_CODPRODU}");

            /*" -3925- DISPLAY 'DTTERVIG    ' V0ENDO-DTTERVIG */
            _.Display($"DTTERVIG    {V0ENDO_DTTERVIG}");

            /*" -3926- DISPLAY 'VALOR       ' V0CBPR-IMPDIT */
            _.Display($"VALOR       {V0CBPR_IMPDIT}");

            /*" -3928- DISPLAY 'LIDOS       ' AC-L-V0HISTCONT */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -3930- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -3930- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -3933- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3938- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -3938- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}