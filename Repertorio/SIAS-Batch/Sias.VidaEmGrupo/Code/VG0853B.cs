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
using Sias.VidaEmGrupo.DB2.VG0853B;

namespace Code
{
    public class VG0853B
    {
        public bool IsCall { get; set; }

        public VG0853B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDA EM GRUPO / EMPRESARIAL        *      */
        /*"      *   PROGRAMA ...............  VG0853B (VERSAO DO VA0853B)        *      */
        /*"      *                                     (26/12/2001 - FRED)        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  06/10/1997                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.53  *   VERSAO 53 - DE292735 - Empresarial Global - VIDA             *      */
        /*"      *               Permitir a gera��o da parcela atual somente      *      */
        /*"      *               quando houver o retorno da parcela anterior      *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/04/2023 - ROGER PIRES         PROCURE POR V.53         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.52  *   VERSAO 52 - DEMANDA 434877 - GERAR A SEGUNDA PARCELA COM     *      */
        /*"      *               O MESMO VALOR DA PRIMEIRA QUANDO AS VIDAS NAO    *      */
        /*"      *               TIVEREM CARGA INICIAL NA SEGURADOS-VGAP.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/05/2023 - TERCIO CARVALHO     PROCURE POR V.52         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.51  *   VERSAO 51 - ABEND 350981 - CORRECAO EM SECTION               *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/12/2021 - CANETTA             PROCURE POR V.51         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 50 - CAD 287.740                                      *      */
        /*"      *               DESABILITAR GERACAO DE PARCELAS DOS CERTIFICADOS *      */
        /*"      *               DA APOLICE 109300006385 (FRIGOL) A PARTIR DESTA  *      */
        /*"      *               DATA. O FATURAMENTO SERA MANUAL EM FUNCAO DA     *      */
        /*"      *               EMPRESA NAO CONSEGUIR INFORMAR A QTDE DE VIDAS   *      */
        /*"      *               DENTRO DO PRAZO.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/05/2021 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.50        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 49 - CAD 220.282                                      *      */
        /*"      *             - VOC - ADEQUACAO DA REGUA DE COBRANCA PARA DEBITO *      */
        /*"      *               EM CONTA. PASSA A GERAR A PARCELA COM 8 DIAS DE  *      */
        /*"      *               ANTECEDENCIA DO VENCIMENTO.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/12/2019 - TERCIO CARVALHO                              *      */
        /*"      *   EM 10/12/2019 - FRANK CARVALHO (TESTES INTEGRADOS)           *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.49        *      */
        /*"JV148 *----------------------------------------------------------------*      */
        /*"JV148 *VERSAO 48: JV1 DEMANDA 262179 - KINKAS 23/10/2020               *      */
        /*"JV148 *           EXCLUI APOLICES/PRODUTOS JV1 - FASE 2                *      */
        /*"JV148 *           - PROCURAR POR JV148                                 *      */
        /*"JV147 *----------------------------------------------------------------*      */
        /*"JV147 *VERSAO 47: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV147 *           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV147 *           - PROCURAR POR JV147                                 *      */
        /*"JV147 *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 46 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               O NUMERO DO CARTAO DE CREDITO FOI ALTERADO NA    *      */
        /*"      *               TABELA OPCAO_PAG_VIDAZUL PARA CHAR(16), POIS O   *      */
        /*"      *               NUMERO QUE O LEGADO RECEBE ESTA MASCARADO COM "*"*      */
        /*"      *                                                                *      */
        /*"      *   EM 05/08/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.46         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 45 - JAZZ 191626                                      *      */
        /*"      *             - PRODUTO CAP/PM                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/04/2019 - CANETTA                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 44 - HIST 181.584                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43 - CAD 146.366                                      *      */
        /*"      *             - RECOMANDAR VIA SAP PARA DEBITO EM CONTA DE ATE   *      */
        /*"      *               2 PARCELAS MENSAIS ANTERIORES A PARCELA GERADA,  *      */
        /*"      *               COM MESMA DATA-VENCIMENTO DA PARCELA GERADA PARA *      */
        /*"      *               OS PRODUTOS EMPRESARIAIS, QUANDO OCORRER RETORNO *      */
        /*"      *               DE INSUCESSO DE DEBITO POR QUALQUER MOTIVO.      *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.43        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 42   - CADMUS 140.778                                 *      */
        /*"      *               - RETORNO PARA GERACAO DE PARCELA COM 15 DIAS DE *      */
        /*"      *                 ANTECEDENCIA DA DATA-VENCIMENTO                *      */
        /*"      *   EM 12/02/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.42         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41   - CADMUS 140.778                                 *      */
        /*"      *               - ANTECIPAR EM 03 DIAS A GERACAO DA PARCELA PARA *      */
        /*"      *                 SOLICITAR NN AO SAP POR MEIO DE ARQ-A (EM8100B)*      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.41         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40   - CADMUS 140.778                                 *      */
        /*"      *               - ANTECIPAR EM 02 DIAS A GERACAO DA PARCELA PARA *      */
        /*"      *                 SOLICITAR NN AO SAP POR MEIO DE ARQ-A (EM8100B)*      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.40         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39 - CADMUS 119.208                                   *      */
        /*"      *             - PASSA A GERAR A PARCELA PARA A APOLICE           *      */
        /*"      *               109300002554 - CYRELA COM 23 DIAS DE             *      */
        /*"      *               ANTECEDENCIA.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/08/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.39        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38 - CAD 110376                                       *      */
        /*"      *   NAO PERMITIR A GERACAO DE PARCELAS QUANDO NAO HOUVER VIDAS   *      */
        /*"      *   ATIVAS PARA APOLICE ESPECIFICA                               *      */
        /*"      *   EM 18/06/2015 - ROGERIO LAMAS DE LIMA                        *      */
        /*"      *                                        PROCURE POR V.38        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37 - NSGD - CADMUS 103659.                            *      */
        /*"      *             - NOVA SOLUCAO DE GESTAO DE DEPOSITOS              *      */
        /*"      *                                                                *      */
        /*"      *    EM 09/07/2015 - COREON                                      *      */
        /*"      *                                        PROCURE POR V.37        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - CAD 98.586                                       *      */
        /*"      *             - CRIACAO DE RECOMANDO VIA SAP PARA DEBITO EM CONTA*      */
        /*"      *               DE ATE 2 PARCELAS MENSAIS ANTERIORES A PARCELA   *      */
        /*"      *               GERADA, COM MESMA DATA-VENCIMENTO DA GERADA, PARA*      */
        /*"      *               OS PRODUTOS 9311, 8203 E 9354, QUANDO RETORNO DE *      */
        /*"      *               INSUCESSO DE DEBITO POR "SALDO INSUFIENTE".      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.36        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35 - CAD 94.717                                       *      */
        /*"      *               NAO GERAR PARCELAS QUANDO ENCONTRAR MAIS DE DUAS *      */
        /*"      *               PARCELAS SEM PAGAMENTO QUANDO MENSAL E UMA PARC. *      */
        /*"      *               QUANDO NAO MENSAL                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/05/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.35             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34 - CAD 92.882                                       *      */
        /*"      *               GERAR PARCELA P/EMPRESARIAL GLOBAL ANTECIPADO    *      */
        /*"      *               QUE VENCEU OS 12 MESES E NAO FORAM MIGRADOS.     *      */
        /*"      *               9343 - VIDA EMPRESARIAL VG                       *      */
        /*"      *               8209 - VIDA EMPRESARIAL APC                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/05/2014 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.34             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33 - CAD 97.134                                       *      */
        /*"      *             CORRECAO DE DT-VENCIMENTO NA COBER-HIST-VIDAZUL    *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2014 - ELIERMES OLIVEIRA  (GESIN - VIDA)            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.33             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32 - CAD 92.606                                       *      */
        /*"      *             CONTROLE DE GERACAO DE PARCELA APARTIR DA VIGENCIA *      */
        /*"      *             RECUPERADA DA VG_VIGENCIA_FATURA                   *      */
        /*"      *                                                                *      */
        /*"      *             GERAR PARCELA VENCIDA COMO ATIVA PARA CYRELA       *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/02/2014 - ELIERMES OLIVEIRA  (GESIN - VIDA)            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.32             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31                                                    *      */
        /*"      *             - CAD 90.893                                       *      */
        /*"      *               RETIRADA DE MENSAGENS DESNECESSARIAS DO RELATORIO*      */
        /*"      *               ENVIADO A CAIXA.                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/12/2013 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.31             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30                                                    *      */
        /*"      *             - CAD 83.969                                       *      */
        /*"      *               REFAZER CRITICA DE SUBGRUPOS SEM VIDA ATIVA      *      */
        /*"      *               DEIXANDO GERAR PARCELAS COM VALOR ZERADO APENAS  *      */
        /*"      *               PARA CYRELA - APOLICE 109300002554               *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/08/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.30             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 29                                                    *      */
        /*"      *             - CAD 85.484                                       *      */
        /*"      *               GERACAO DE PARCELAS COM CONTROLE MANUAL DA BU    *      */
        /*"      *               QUANDO CADASTRADAS NA TABELA VG_VIGENCIA_FATURA  *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/07/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.29             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28                                                    *      */
        /*"      *             - CAD 83.969                                       *      */
        /*"      *               REFAZER CRITICA DE SUBGRUPOS SEM VIDA ATIVA      *      */
        /*"      *               DEIXANDO GERAR PARCELAS COM VALOR ZERADO         *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/07/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.28             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 27                                                    *      */
        /*"      *             - CAD 83.969                                       *      */
        /*"      *               RETIRADA DA CRITICA DE SUBGRUPOS SEM VIDA ATIVA  *      */
        /*"      *               DEIXANDO GERAR PARCELAS COM VALOR ZERADO         *      */
        /*"      *               RETORNO A VERSAO V.23                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.27             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26                                                    *      */
        /*"      *             - CAD 83.969                                       *      */
        /*"      *               CORRECAO PARA CRITICAR APENAS SUBGRUPOS DA       *      */
        /*"      *               CYRELA QUE NAO POSSUAM VIDAS ATIVAS              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.26             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25                                                    *      */
        /*"      *             - CAD 83.969                                       *      */
        /*"      *               CORRECAO PARA CRITICAR APENAS SUBGRUPOS QUE      *      */
        /*"      *               POSSUAM TIPO_FATURAMENTO = 2 E QUE NAO POSSUAM   *      */
        /*"      *               VIDAS ATIVAS                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/07/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.25             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24                                                    *      */
        /*"      *             - CAD 83.969                                       *      */
        /*"      *               CORRECAO PARA GERAR PARCELA APENAS PARA          *      */
        /*"      *               OS SUBGRUPOS QUE POSSUAM VIDAS ATIVAS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/06/2013 - ELIERMES OLIVEIRA (GESIN - VIDA)             *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.24             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23                                                    *      */
        /*"      *             - CAD 83.388                                       *      */
        /*"      *               PASSA A GERAR A PARCELA PARA A APOLICE           *      */
        /*"      *               109300002554 - CYRELA COM 18 DIAS DE             *      */
        /*"      *               ANTECEDENCIA.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/06/2013 - EDIVALDO GOMES    (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.23             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22                                                    *      */
        /*"      *             - CAD 82.700                                       *      */
        /*"      *               ALTERACAO PARA EVITAR ERRO NA GERACAO DE NUMEROS *      */
        /*"      *               DE TITULOS PARA O COD_CEDENTE = 36 DA TABELA     *      */
        /*"      *               SEGUROS.CEDENTE                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/05/2013 - TERCIO CARVALHO   (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.22             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21                                                    *      */
        /*"      *             - CAD 81.324                                       *      */
        /*"      *               ALTERACAO PARA EVITAR ERRO NA GERACAO DE NUMEROS *      */
        /*"      *               DE TITULOS PARA O COD_CEDENTE = 36 DA TABELA     *      */
        /*"      *               SEGUROS.CEDENTE                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/04/2013 - AUGUSTO ANASTACIO (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.21             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20                                                    *      */
        /*"      *             - CAD 80.598                                       *      */
        /*"      *               NAO SERA GERADA PARCELA DAS APOLICES 109300000635*      */
        /*"      *               E 107700000007 POR ESTE PROGRAMA MAIS. AS        *      */
        /*"      *               PARCELAS SERAO GERADAS PELOS PROGRAMAS VG9567B E *      */
        /*"      *               VG9568B COM A LEITURA DOS ARQUIVOS CONSORCIO.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2013 - JEFFERSON                                    *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.20             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19                                                    *      */
        /*"      *             - CAD 72.667                                       *      */
        /*"      *               SOMENTE GERA A PARCELA DA APOLICE 108210871143   *      */
        /*"      *               (REDE SIM) SE A FATURA (HIS_COBER_PROPOST)  DO   *      */
        /*"      *               MES ESTIVER GERADA PELO (VG1652B). ESTA GERA -   *      */
        /*"      *               CAO OCORRE NO FECHAMENTO MENSAL.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/10/2012 - LUIZ MARQUES   (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.19             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18                                                    *      */
        /*"      *             - CAD 68.997                                       *      */
        /*"      *               ACESSAR A HIS_COBER_PROPOST PELA DATA DO PROX.   *      */
        /*"      *               VENCIMENTO E NAO MAIS PELA OCORRENCIA DO HISTO-  *      */
        /*"      *               RICO, COM O OBJETIVO DE CORRIGIR OS VALORES DAS  *      */
        /*"      *               FATURAS.                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/08/2012 - LUIZ MARQUES   (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.18             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17                                                    *      */
        /*"      *             - CAD  201.122                                     *      */
        /*"      *               INSERIR COLUNAS NA CLAUSULA INSERT DAS TABELAS   *      */
        /*"      *               HIST_LANC_CTA OU V0HISTCONTAVA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.17             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16                                                    *      */
        /*"      *             - CAD 201.088                                      *      */
        /*"      *               ALTERACAO PARA CORRIGIR O TESTE DE SQLCODE       *      */
        /*"      *               INDEVIDO QUE ESTAVA IMPEDINDO A GERACAO DE       *      */
        /*"      *               PARCELAS, PARA PRODUTOS SEM REGISTRO NA TABELA   *      */
        /*"      *               CONVENIOS_VG.                                    *      */
        /*"      *               O SQLCODE ERA TESTADO ANTES DA ABERTURA DO       *      */
        /*"      *               CURSOR, FICANDO VICIADO PELO ACESSO ANTERIOR.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/06/2011 - EDIVALDO GOMES - FAST COMPUTER               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.16    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15                                                    *      */
        /*"      *             - CAD 53.986                                       *      */
        /*"      *               ALTERACAO PARA CORRIGIR ABEND SQLCODE 100        *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/03/2011 - MARCO PAIVA - FAST COMPUTER                  *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.15    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14                                                    *      */
        /*"      *             - CAD 38.578                                       *      */
        /*"      *               ALTERACAO PARA BUSCAR NUMERO DE TITULO NA TABELA *      */
        /*"      *               SEGUROS.CEDENTE PARA DEBITOS EM CONTA CORRENTE.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/03/2010 - EDIVALDO GOMES  - FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13                                                    *      */
        /*"      *             - CAD 37.991                                       *      */
        /*"      *               ALTERACAO PARA CORRIGIR ABEND SQLCODE 100        *      */
        /*"      *               NA TABELA V0OPCAOPAG.                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/02/2010 - TERCIO FREITAS  - FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.13    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12                                                    *      */
        /*"      *             - CAD 31.326                                       *      */
        /*"      *               ALTERACAO PARA NAO MAIS GRAVAR NA ROTINA DE ERRO *      */
        /*"      *               QUANDO O CLIENTE DA PROPOSTA_VA NAO FOR ENCONTRA-*      */
        /*"      *               DO NA V0SUBGRUPO.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2009 - CESAR DALAZUANA - FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.12    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11                                                    *      */
        /*"      *             - CAD 28.521                                       *      */
        /*"      *               CRIACAO DOS RELATORIOS DE ERRO NA ROTINA.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/08/2009 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.11    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10                                                    *      */
        /*"      *             - CAD 22.124                                       *      */
        /*"      *               CONCEDER DESCONTO DE 50% DO PREMIO NA SEGUNDA    *      */
        /*"      *               E TERCEIRA PARCELAS PARA O VIDA EMPRESA GLOBAL   *      */
        /*"      *               PARA PROPOSTAS ADQUIRIDAS ENTRE 01/03/2009       *      */
        /*"      *               E 31/12/2009.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/03/2009 - FAST COMPUTER (ROGERIO)  PROCURE POR V.10    *      */
        /*"      *                                 (ELISEU )                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   009 - 02/01/2009 - FAST COMPUTER                             *      */
        /*"      *                      PASSA A TRATAR O DESPONTEIRAMENTO         *      */
        /*"      *      ENTRE A SEGUROS.PROPOSTAS_VA E A                          *      */
        /*"      *              SEGUROS.HIS_COBER_PROPOST                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE  V.09           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   008 - 08/11/2007 - FAST COMPUTER                             *      */
        /*"      *                      PASSA A NAO MAIS PROCESSA AS APOLICES     *      */
        /*"      *      ESPECIFICAS (ORIG_PRODU=ESPEC). SERAO PROCESSADAS NO      *      */
        /*"      *      PROGRAMA VG3853B.                                         *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE  V.08           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   007 - 11/09/2007 - FAST COMPUTER                             *      */
        /*"      *                      ACRESCENTA NO SELECT (CURSOR CTERMO1)     *      */
        /*"      *      DA RELATORIOS  NA COD_RELAT O VE0030B                     *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE  V.07           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   006 - 08/08/2007 - FAST COMPUTER                             *      */
        /*"      *                      MIGRACAO PARA VIDA GLOBAL                 *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE  V.06           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   GERA PARCELAS DO NOVO FATURAMENTO                            *      */
        /*"      *                       * * * ATENCAO * * *                      *      */
        /*"      *   **** VERIFICAR SE A ALTERACAO EFETUADA NESTE PROGRAMA TERA   *      */
        /*"      *   **** QUE SER EXECUTADA TAMBEM NA SUBROTINA ON-LINE VG0853S.  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *             HISTORICO  DE  ALTERACOES                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  005 - 04/09/2006 - FAST COMPUTER         PROCURE POR V.05     *      */
        /*"      *   TRATA EMPRESA GLOBAL                                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  004 - 20/12/2005 - TERCIO CARVALHO       PROCURE POR TL0512   *      */
        /*"      *   NAO ACUMULA PARCELA                                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  003 - 19/05/2003 - MANOEL MESSIAS / FREDERICO FONSECA         *      */
        /*"      *   NAO ESTAVA GERANDO PARCELA, POIS, O RAMO 81 FOI MUDADO PARA  *      */
        /*"      * O RAMO 82, MAS, A CRITICA DOS RAMOS CONTINUAVA.                *      */
        /*"      *                                           PROCURE POR MM0503   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  002 - 19/07/2002 - MANOEL MESSIAS                             *      */
        /*"      *   SE O SEGURADO POSSUIR PARCELAS EM ATRASO, AS COLUNAS DA TABE *      */
        /*"      * LA V0PROPOSTAVA, NRPRIPARATZ E QTDPARATZ SERAO ATUALIZADAS.    *      */
        /*"      *                                           PROCURE POR MM0702   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  001 - 17/05/2002 - MANOEL MESSIAS                             *      */
        /*"      *   PARA AS APOLICES DOS PRODUTOS EMPRESARIAL E ESPECIFICA, SE A *      */
        /*"      * FORMA DE FATURAMENTO FOR MANUAL ('1') A PARCELA DE COBRANCA SE-*      */
        /*"      * GERADA CANCELADA ('2') PARA QUE O USUARIO INTERVENHA A QUALQUER*      */
        /*"      * MOMENTO PARA LIBERAR A COBRANCA DA PARCELA.                    *      */
        /*"      *                                           PROCURE POR MM0502   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  29/07/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  19/08/08   JANAINA NEVES SOUTO                     *      */
        /*"      *             CADMUS 13390 - ABEND (-803) - R1400-00                    */
        /*"      *                                  PROCURE POR  JNS0808          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PROPOSTAS VA                        CPROPVA           INPUT    *      */
        /*"      * COBERTURAS PROPOSTA VA              V0COBERPROPVA     INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     OUTPUT   *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _DSAIDA { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis DSAIDA
        {
            get
            {
                _.Move(RECORD_DSAIDA, _DSAIDA); VarBasis.RedefinePassValue(RECORD_DSAIDA, _DSAIDA, RECORD_DSAIDA); return _DSAIDA;
            }
        }
        public FileBasis _SSAIDA { get; set; } = new FileBasis(new PIC("X", "250", "X(250)"));

        public FileBasis SSAIDA
        {
            get
            {
                _.Move(RECORD_SSAIDA, _SSAIDA); VarBasis.RedefinePassValue(RECORD_SSAIDA, _SSAIDA, RECORD_SSAIDA); return _SSAIDA;
            }
        }
        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_SAIDA, _ARQSAIDA); VarBasis.RedefinePassValue(REG_SAIDA, _ARQSAIDA, REG_SAIDA); return _ARQSAIDA;
            }
        }
        /*"01            RECORD-DSAIDA       PIC X(200).*/
        public StringBasis RECORD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            RECORD-SSAIDA       PIC X(250).*/
        public StringBasis RECORD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");
        /*"01            REG-SAIDA           PIC X(0200).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "200", "X(0200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         WS-DESCONTO         PIC  X(001)      VALUE  SPACES.*/
        public StringBasis WS_DESCONTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         WS-DESPREZA         PIC  X(001)      VALUE  SPACES.*/
        public StringBasis WS_DESPREZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         WS-CNTRLE-VING-FAT  PIC  X(001)      VALUE  SPACES.*/
        public StringBasis WS_CNTRLE_VING_FAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         VIND-DTMOVTO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ESTR-COBR      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ORIG-PRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-SAF        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-IGPM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_TEM_IGPM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-STANTECIP      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_STANTECIP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-VLPREMIO-REL  PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WHOST_VLPREMIO_REL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-QT-VIDA-ATIVA PIC S9(009)    COMP   VALUE +0.*/
        public IntBasis WHOST_QT_VIDA_ATIVA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-RAMO         PIC S9(004)    COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MOVF-COUNT        PIC S9(009)    COMP.*/
        public IntBasis V0MOVF_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-MIN-DTPROXVEN PIC  X(010).*/
        public StringBasis WHOST_MIN_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-VLPREMIO      PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP         PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-NRPARCEL      PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-PARCELCAP     PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_PARCELCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         DESCON-PERC         PIC S9(003)V9999 COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"77         DESCON-PRMVG        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DESCON-PRMAP        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-NRTIT         PIC S9(013)     VALUE +0 COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WS-TIPO-MENSAGEM    PIC  X(001).*/
        public StringBasis WS_TIPO_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WS-MSG-DESCRICAO    PIC  X(080).*/
        public StringBasis WS_MSG_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
        /*"77         WHOST-VLPREMIO-W    PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG-W       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP-W       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP_W { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1SIST-DT-08        PIC  X(010).*/
        public StringBasis V1SIST_DT_08 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DT-15        PIC  X(010).*/
        public StringBasis V1SIST_DT_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DT-23-CYRELA PIC  X(010).*/
        public StringBasis V1SIST_DT_23_CYRELA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-DB  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_DB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTTERCOT     PIC  X(010).*/
        public StringBasis V1SIST_DTTERCOT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTMAXALTIGPM PIC  X(010).*/
        public StringBasis V1SIST_DTMAXALTIGPM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0BANC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0SEGV-NUM-ITEM     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGV_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGV-SITUACAO     PIC  X(001).*/
        public StringBasis V0SEGV_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COTA-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COTA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HIST-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HIST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HIST-DTMOVTO-1YEAR PIC  X(010).*/
        public StringBasis V0HIST_DTMOVTO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0SUBG-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0SUBG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0SUBG-TIPO-FATURA  PIC  X(001).*/
        public StringBasis V0SUBG_TIPO_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SUBG-SIT-REGISTRO PIC  X(001).*/
        public StringBasis V0SUBG_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SUBG-FORMA-FATURA PIC  X(001).*/
        public StringBasis V0SUBG_FORMA_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SUBG-PERI-FATURA  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0SUBG_PERI_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PROP-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL-NEW PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL_NEW { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTVENCTO-2M  PIC  X(010).*/
        public StringBasis V0PROP_DTVENCTO_2M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PROP-NRPRIPARATZ  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRMATRFUN    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-INRMATRFUN   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODUSU       PIC  X(008).*/
        public StringBasis V0PROP_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0PROP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0PROP-DTMINVEN     PIC  X(010).*/
        public StringBasis V0PROP_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO-1YEAR PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO_1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-DTADMISSAO   PIC  X(010).*/
        public StringBasis V0PROP_DTADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-STANTECIP    PIC  X(001).*/
        public StringBasis V0PROP_STANTECIP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0RCDG-DTREFER      PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RCDG-SITUACAO     PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0CDGC-VLCUSTCDG    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0PRDVG-ORIG-PRODU         PIC  X(10).*/
        public StringBasis V0PRDVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0PRDVG-ESTR-COBR          PIC  X(10).*/
        public StringBasis V0PRDVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0PRDVG-COBERADIC-PREMIO   PIC  X(01).*/
        public StringBasis V0PRDVG_COBERADIC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-CUSTOCAP-TOTAL     PIC  X(01).*/
        public StringBasis V0PRDVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-SAF            PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-TEM-IGPM           PIC  X(01).*/
        public StringBasis V0PRDVG_TEM_IGPM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0PRDVG-OPCAOCAP           PIC S9(004) COMP.*/
        public IntBasis V0PRDVG_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PRDVG-CODPRODAZ          PIC  X(003).*/
        public StringBasis V0PRDVG_CODPRODAZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0PRDVG-NOMPRODU           PIC  X(030).*/
        public StringBasis V0PRDVG_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77         V0RSAF-DTREFER      PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-SITUACAO     PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0RSAF-CODOPER      PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0SAFC-VLCUSTSAF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0OPCP-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-PERIPGTO-ANT PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-DIA-DEBITO   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-AGECTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPRCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-NUMCTADEB    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0OPCP-DIGCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDAGE       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDOPR       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDNUM       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-INDDIG       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-CARTAO-CRED  PIC  X(016)      VALUE SPACES.*/
        public StringBasis V0OPCP_CARTAO_CRED { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
        /*"77         V0OPCP-VINDCCRE     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_VINDCCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG      PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG-NEW  PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG_NEW { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG-NEW2 PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG_NEW2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG      PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTTERVIG-ORIG PIC  X(010).*/
        public StringBasis WHOST_DTTERVIG_ORIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG-PARC PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBP-VLPREMIO     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCAP    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTCDG    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-VLCUSTAUXF   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBP-IVLCUSTAUXF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-QTTITCAP     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         HISCOBPR-NUM-CERTIFICADO     PIC S9(15)       COMP-3.*/
        public IntBasis HISCOBPR_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77         HISCOBPR-OCORR-HISTORICO     PIC S9(4)        COMP.*/
        public IntBasis HISCOBPR_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         HISCOBPR-DATA-INIVIGENCIA    PIC X(10).*/
        public StringBasis HISCOBPR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         HISCOBPR-DATA-TERVIGENCIA    PIC X(10).*/
        public StringBasis HISCOBPR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         HISCOBPR-IMPSEGUR            PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-QUANT-VIDAS         PIC S9(9)        COMP.*/
        public IntBasis HISCOBPR_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77         HISCOBPR-IMPSEGIND           PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-COD-OPERACAO        PIC S9(4)        COMP.*/
        public IntBasis HISCOBPR_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         HISCOBPR-OPCAO-COBERTURA     PIC X(1).*/
        public StringBasis HISCOBPR_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77         HISCOBPR-IMP-MORNATU         PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPMORACID          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPINVPERM          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPAMDS             PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPDH               PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPDIT              PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VLPREMIO            PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-PRMVG               PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-PRMAP               PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-QTDE-TIT-CAPITALIZ  PIC S9(4)        COMP.*/
        public IntBasis HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77         HISCOBPR-VAL-TIT-CAPITALIZ   PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VAL-CUSTO-CAPITALI  PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPSEGCDG           PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VLCUSTCDG           PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-COD-USUARIO         PIC X(8).*/
        public StringBasis HISCOBPR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77         HISCOBPR-IMPSEGAUXF          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-IMPSEGAUXF-I        PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-VLCUSTAUXF          PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-VLCUSTAUXF-I        PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-PRMDIT              PIC S9(13)V9(2)  COMP-3.*/
        public DoubleBasis HISCOBPR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77         HISCOBPR-PRMDIT-I            PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-QTMDIT              PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         HISCOBPR-QTMDIT-I            PIC S9(04)       COMP.*/
        public IntBasis HISCOBPR_QTMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77         V0PARC-DTVENCTO-PAR PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO_PAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMTOTANT    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V3DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V3DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         HOST-CODCONV        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis HOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CODCONV      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CONV-CCRED        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HICB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HICB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HICB-SITUACAO     PIC  X(001).*/
        public StringBasis V0HICB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HICB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HICB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-CONT-PARC-AT     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_CONT_PARC_AT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-NUM-PARCELA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0RELA-DTVENCTO     PIC  X(010).*/
        public StringBasis V0RELA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HCTA-NSAS         PIC S9(004) COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCTA-SITUACAO     PIC  X(001).*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-CNTRLE-MNL      PIC  9(01)  VALUE ZEROS.*/
        public IntBasis WHOST_CNTRLE_MNL { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"01          REG-CABEC-01.*/
        public VG0853B_REG_CABEC_01 REG_CABEC_01 { get; set; } = new VG0853B_REG_CABEC_01();
        public class VG0853B_REG_CABEC_01 : VarBasis
        {
            /*"   10        FILLER              PIC  X(010) VALUE 'VG0853B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0853B");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(051) VALUE            'RELATORIO DE CERTIFICADOS DESPREZADOS'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"RELATORIO DE CERTIFICADOS DESPREZADOS");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(010) VALUE 'DATA:'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA:");
            /*"   10        REG-CABEC-01-DATA   PIC  X(010).*/
            public StringBasis REG_CABEC_01_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01          REG-CABEC-02.*/
        }
        public VG0853B_REG_CABEC_02 REG_CABEC_02 { get; set; } = new VG0853B_REG_CABEC_02();
        public class VG0853B_REG_CABEC_02 : VarBasis
        {
            /*"   10        FILLER              PIC  X(011) VALUE 'CERTIFICADO'*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"CERTIFICADO");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(007) VALUE 'PARCELA'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(015)                                 VALUE 'DATA VENCIMENTO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA VENCIMENTO");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(012)                                 VALUE 'VALOR PREMIO'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"VALOR PREMIO");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"   10        FILLER              PIC  X(009) VALUE 'DESCRICAO'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"DESCRICAO");
            /*"   10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01         REG-DET.*/
        }
        public VG0853B_REG_DET REG_DET { get; set; } = new VG0853B_REG_DET();
        public class VG0853B_REG_DET : VarBasis
        {
            /*"  10        REG-SAI-NRCERTIF    PIC  9(015).*/
            public IntBasis REG_SAI_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-NRPARCEL    PIC  9(005).*/
            public IntBasis REG_SAI_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-DT-VENC     PIC  X(010) VALUE SPACES.*/
            public StringBasis REG_SAI_DT_VENC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-PRM         PIC  9999999999999,99.*/
            public DoubleBasis REG_SAI_PRM { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  10        REG-SAI-DESCRICAO   PIC  X(050).*/
            public StringBasis REG_SAI_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"  10        FILLER              PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01  WTEM-TERMO-ANT              PIC   X(03)  VALUE  ' '.*/
        }
        public StringBasis WTEM_TERMO_ANT { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
        /*"01  TABELA-ULTIMOS-DIAS.*/
        public VG0853B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG0853B_TABELA_ULTIMOS_DIAS();
        public class VG0853B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 FILLER                   PIC  X(024)  VALUE                                '312831303130313130313031'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01  TAB-ULTIMOS-DIAS            REDEFINES                                TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG0853B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG0853B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG0853B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG0853B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"    05 TAB-DIA-MESES            OCCURS 12.*/
            public ListBasis<VG0853B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG0853B_TAB_DIA_MESES>(12);
            public class VG0853B_TAB_DIA_MESES : VarBasis
            {
                /*"      07 TAB-DIA-MES            PIC  9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  CONT-ATRASO                 PIC  9(005)   VALUE ZEROS.*/

                public VG0853B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0853B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis CONT_ATRASO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"01  PROX-PARCELA                PIC S9(004) COMP VALUE ZEROS.*/
        public IntBasis PROX_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  CHAVE-FIM                   PIC  X(001)   VALUE SPACES.*/
        public StringBasis CHAVE_FIM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  HOST-PARCELA-ATRASO         PIC S9(004) COMP VALUE ZEROS.*/
        public IntBasis HOST_PARCELA_ATRASO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-TIME                     PIC  X(008).*/
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  WS-TIME-HMS                 PIC  X(008).*/
        public StringBasis WS_TIME_HMS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  WPRI-PARCELA                PIC  9(001)   VALUE ZEROS.*/
        public IntBasis WPRI_PARCELA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  W-IGPM-CADASTRADO           PIC  X(001)   VALUE SPACES.*/
        public StringBasis W_IGPM_CADASTRADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VG0853B_FILLER_22 _filler_22 { get; set; }
        public _REDEF_VG0853B_FILLER_22 FILLER_22
        {
            get { _filler_22 = new _REDEF_VG0853B_FILLER_22(); _.Move(W_NUMR_TITULO, _filler_22); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_22, W_NUMR_TITULO); _filler_22.ValueChanged += () => { _.Move(_filler_22, W_NUMR_TITULO); }; return _filler_22; }
            set { VarBasis.RedefinePassValue(value, _filler_22, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VG0853B_FILLER_22 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_VG0853B_FILLER_22()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VG0853B_DPARM01X DPARM01X { get; set; } = new VG0853B_DPARM01X();
        public class VG0853B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VG0853B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VG0853B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VG0853B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VG0853B_DPARM01_R : VarBasis
            {
                /*"    10          DPARM01-1         PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-2         PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-3         PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-4         PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-5         PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-6         PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-7         PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-8         PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-9         PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10          DPARM01-10        PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05            DPARM01-D1        PIC  9(001).*/

                public _REDEF_VG0853B_DPARM01_R()
                {
                    DPARM01_1.ValueChanged += OnValueChanged;
                    DPARM01_2.ValueChanged += OnValueChanged;
                    DPARM01_3.ValueChanged += OnValueChanged;
                    DPARM01_4.ValueChanged += OnValueChanged;
                    DPARM01_5.ValueChanged += OnValueChanged;
                    DPARM01_6.ValueChanged += OnValueChanged;
                    DPARM01_7.ValueChanged += OnValueChanged;
                    DPARM01_8.ValueChanged += OnValueChanged;
                    DPARM01_9.ValueChanged += OnValueChanged;
                    DPARM01_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01       WDATA-SQL           PIC  X(010).*/
        }
        public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01       FILLER              REDEFINES    WDATA-SQL.*/
        private _REDEF_VG0853B_FILLER_23 _filler_23 { get; set; }
        public _REDEF_VG0853B_FILLER_23 FILLER_23
        {
            get { _filler_23 = new _REDEF_VG0853B_FILLER_23(); _.Move(WDATA_SQL, _filler_23); VarBasis.RedefinePassValue(WDATA_SQL, _filler_23, WDATA_SQL); _filler_23.ValueChanged += () => { _.Move(_filler_23, WDATA_SQL); }; return _filler_23; }
            set { VarBasis.RedefinePassValue(value, _filler_23, WDATA_SQL); }
        }  //Redefines
        public class _REDEF_VG0853B_FILLER_23 : VarBasis
        {
            /*"    10   WANO-SQL            PIC  9(004).*/
            public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10   FILLER              PIC  X(001).*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10   WMES-SQL            PIC  9(002).*/
            public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10   FILLER              PIC  X(001).*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10   WDIA-SQL            PIC  9(002).*/
            public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01           AREA-DE-WORK.*/

            public _REDEF_VG0853B_FILLER_23()
            {
                WANO_SQL.ValueChanged += OnValueChanged;
                FILLER_24.ValueChanged += OnValueChanged;
                WMES_SQL.ValueChanged += OnValueChanged;
                FILLER_25.ValueChanged += OnValueChanged;
                WDIA_SQL.ValueChanged += OnValueChanged;
            }

        }
        public VG0853B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0853B_AREA_DE_WORK();
        public class VG0853B_AREA_DE_WORK : VarBasis
        {
            /*"  05         N88-VERIFICA-OPCAOPAG        PIC  X(001)  VALUE '*'*/

            public SelectorBasis N88_VERIFICA_OPCAOPAG { get; set; } = new SelectorBasis("001", "*")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88       SIM-OPCAOPAG                 VALUE  'S'. */
							new SelectorItemBasis("SIM_OPCAOPAG", "S"),
							/*" 88       NAO-OPCAOPAG                 VALUE  'N'. */
							new SelectorItemBasis("NAO_OPCAOPAG", "N")
                }
            };

            /*"  05      HD-REG-DSAIDA.*/
            public VG0853B_HD_REG_DSAIDA HD_REG_DSAIDA { get; set; } = new VG0853B_HD_REG_DSAIDA();
            public class VG0853B_HD_REG_DSAIDA : VarBasis
            {
                /*"    10    HD-COD-PRO-DSAIDA   PIC  X(008)   VALUE 'VG0853B'.*/
                public StringBasis HD_COD_PRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0853B");
                /*"    10    HD-DES-REL-DSAIDA   PIC  X(050)   VALUE    'RELATORIO DE ERROS DE DADOS'.*/
                public StringBasis HD_DES_REL_DSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE DADOS");
                /*"    10    HD-DTA-SIS-DSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_DSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05      CB-REG-DSAIDA.*/
            }
            public VG0853B_CB_REG_DSAIDA CB_REG_DSAIDA { get; set; } = new VG0853B_CB_REG_DSAIDA();
            public class VG0853B_CB_REG_DSAIDA : VarBasis
            {
                /*"    10    FILLER              PIC  X(045)   VALUE    'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"    10    FILLER              PIC  X(042)   VALUE    'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"    10    FILLER              PIC  X(033)   VALUE    'DETALHAMENTO DO PROBLEMA OCORRIDO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO");
                /*"  05      LD-REG-DSAIDA.*/
            }
            public VG0853B_LD_REG_DSAIDA LD_REG_DSAIDA { get; set; } = new VG0853B_LD_REG_DSAIDA();
            public class VG0853B_LD_REG_DSAIDA : VarBasis
            {
                /*"    10    LD-NUM-APOL-DSAIDA         PIC 9(013).*/
                public IntBasis LD_NUM_APOL_DSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-SUBG-DSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_SUBG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-PROD-DSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_PROD_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NOM-PROD-DSAIDA         PIC X(030).*/
                public StringBasis LD_NOM_PROD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SUB-DSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SUB_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SEG-DSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SEG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-DES-ERRO-DSAIDA         PIC X(080).*/
                public StringBasis LD_DES_ERRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"  05      HD-REG-SSAIDA.*/
            }
            public VG0853B_HD_REG_SSAIDA HD_REG_SSAIDA { get; set; } = new VG0853B_HD_REG_SSAIDA();
            public class VG0853B_HD_REG_SSAIDA : VarBasis
            {
                /*"    10    HD-COD-PRO-SSAIDA   PIC  X(008)   VALUE 'VG0853B'.*/
                public StringBasis HD_COD_PRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0853B");
                /*"    10    HD-DES-REL-SSAIDA   PIC  X(050)   VALUE    'RELATORIO DE ERROS DE SISTEMAS'.*/
                public StringBasis HD_DES_REL_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE SISTEMAS");
                /*"    10    HD-DTA-SIS-SSAIDA   PIC  X(010)   VALUE SPACES.*/
                public StringBasis HD_DTA_SIS_SSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05      CB-REG-SSAIDA.*/
            }
            public VG0853B_CB_REG_SSAIDA CB_REG_SSAIDA { get; set; } = new VG0853B_CB_REG_SSAIDA();
            public class VG0853B_CB_REG_SSAIDA : VarBasis
            {
                /*"    10    FILLER              PIC  X(045)   VALUE    'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
                /*"    10    FILLER              PIC  X(042)   VALUE    'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
                /*"    10    FILLER              PIC  X(035)   VALUE    'CODIGO ERRO DB2;DESCRICAO ERRO DB2;'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"CODIGO ERRO DB2;DESCRICAO ERRO DB2;");
                /*"    10    FILLER              PIC  X(034)   VALUE    'DETALHAMENTO DO PROBLEMA OCORRIDO;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO;");
                /*"    10    FILLER              PIC  X(016)   VALUE    'PROGRAMA'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROGRAMA");
                /*"  05      LD-REG-SSAIDA.*/
            }
            public VG0853B_LD_REG_SSAIDA LD_REG_SSAIDA { get; set; } = new VG0853B_LD_REG_SSAIDA();
            public class VG0853B_LD_REG_SSAIDA : VarBasis
            {
                /*"    10    LD-NUM-APOL-SSAIDA         PIC 9(013).*/
                public IntBasis LD_NUM_APOL_SSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-SUBG-SSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_SUBG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-PROD-SSAIDA         PIC 9(004).*/
                public IntBasis LD_COD_PROD_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NOM-PROD-SSAIDA         PIC X(030).*/
                public StringBasis LD_NOM_PROD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SUB-SSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SUB_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NUM-CERT-SEG-SSAIDA     PIC 9(015).*/
                public IntBasis LD_NUM_CERT_SEG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-COD-ERRO-DB2-SSAIDA     PIC -9(004).*/
                public IntBasis LD_COD_ERRO_DB2_SSAIDA { get; set; } = new IntBasis(new PIC("-9", "4", "-9(004)."));
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-DES-ERRO-DB2-SSAIDA     PIC X(050).*/
                public StringBasis LD_DES_ERRO_DB2_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-DES-ERRO-SSAIDA         PIC X(050).*/
                public StringBasis LD_DES_ERRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"    10    FILLER                     PIC X(001)  VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    LD-NOM-PROG-SSAIDA        PIC X(008) VALUE 'VG0853B'.*/
                public StringBasis LD_NOM_PROG_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0853B");
                /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            }
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WANO-BISSEXTO     PIC  9(004).*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         WACC-COMMIT       PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         AC-ERRO-DADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis AC_ERRO_DADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         AC-ERRO-SISTEMA   PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis AC_ERRO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-CDEBANT    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDEBANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CPROPVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPROPVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WREGULARIZOU    PIC X(001)  VALUE SPACES.*/
            public StringBasis WREGULARIZOU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WNSAS           PIC 9(005).*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05         WDATA-SISTEMA.*/
            public VG0853B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VG0853B_WDATA_SISTEMA();
            public class VG0853B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-PRIMEIRA.*/
            }
            public VG0853B_WDATA_PRIMEIRA WDATA_PRIMEIRA { get; set; } = new VG0853B_WDATA_PRIMEIRA();
            public class VG0853B_WDATA_PRIMEIRA : VarBasis
            {
                /*"    10       WDATA-PRI-ANO     PIC  9(004).*/
                public IntBasis WDATA_PRI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-MES     PIC  9(002).*/
                public IntBasis WDATA_PRI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-PRI-DIA     PIC  9(002).*/
                public IntBasis WDATA_PRI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA.*/
            }
            public VG0853B_WDATA_VIGENCIA WDATA_VIGENCIA { get; set; } = new VG0853B_WDATA_VIGENCIA();
            public class VG0853B_WDATA_VIGENCIA : VarBasis
            {
                /*"    10       WDATA-VIG-ANO     PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES     PIC  9(002).*/
                public IntBasis WDATA_VIG_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA     PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VIGENCIA1.*/
            }
            public VG0853B_WDATA_VIGENCIA1 WDATA_VIGENCIA1 { get; set; } = new VG0853B_WDATA_VIGENCIA1();
            public class VG0853B_WDATA_VIGENCIA1 : VarBasis
            {
                /*"    10       WDATA-VIG-ANO1    PIC  9(004).*/
                public IntBasis WDATA_VIG_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-MES1    PIC  9(002).*/
                public IntBasis WDATA_VIG_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VIG-DIA1    PIC  9(002).*/
                public IntBasis WDATA_VIG_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-VENCIMENTO.*/
            }
            public VG0853B_WDATA_VENCIMENTO WDATA_VENCIMENTO { get; set; } = new VG0853B_WDATA_VENCIMENTO();
            public class VG0853B_WDATA_VENCIMENTO : VarBasis
            {
                /*"    10       WDATA-VCT-ANO     PIC  9(004).*/
                public IntBasis WDATA_VCT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-MES     PIC  9(002).*/
                public IntBasis WDATA_VCT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-VCT-DIA     PIC  9(002).*/
                public IntBasis WDATA_VCT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W01DTSQL.*/
            }
            public VG0853B_W01DTSQL W01DTSQL { get; set; } = new VG0853B_W01DTSQL();
            public class VG0853B_W01DTSQL : VarBasis
            {
                /*"    10       W01AASQL          PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W01T1SQL          PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01MMSQL          PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01T2SQL          PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W01DDSQL          PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W02DTSQL.*/
            }
            public VG0853B_W02DTSQL W02DTSQL { get; set; } = new VG0853B_W02DTSQL();
            public class VG0853B_W02DTSQL : VarBasis
            {
                /*"    10       W02AASQL          PIC 9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W02T1SQL          PIC X(001).*/
                public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W02MMSQL          PIC 9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02T2SQL          PIC X(001).*/
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W02DDSQL          PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         W03DTFAT.*/
            }
            public VG0853B_W03DTFAT W03DTFAT { get; set; } = new VG0853B_W03DTFAT();
            public class VG0853B_W03DTFAT : VarBasis
            {
                /*"    10       W03AAFAT          PIC 9(004).*/
                public IntBasis W03AAFAT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       W03T1FAT          PIC X(001).*/
                public StringBasis W03T1FAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W03MMFAT          PIC 9(002).*/
                public IntBasis W03MMFAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W03T2FAT          PIC X(001).*/
                public StringBasis W03T2FAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       W03DDFAT          PIC 9(002).*/
                public IntBasis W03DDFAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
            }
            public VG0853B_WABEND WABEND { get; set; } = new VG0853B_WABEND();
            public class VG0853B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG0853B '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0853B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01           GE0006S-LINKAGE.*/
            }
        }
        public VG0853B_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new VG0853B_GE0006S_LINKAGE();
        public class VG0853B_GE0006S_LINKAGE : VarBasis
        {
            /*"  05         GE0006S-DATA-DESTINO    PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0006S-QTDDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0006S-MENSAGEM        PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.VG083 VG083 { get; set; } = new Dclgens.VG083();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VG0853B_CPROPVA CPROPVA { get; set; } = new VG0853B_CPROPVA();
        public VG0853B_CATRASO CATRASO { get; set; } = new VG0853B_CATRASO();
        public VG0853B_CTERMO CTERMO { get; set; } = new VG0853B_CTERMO();
        public VG0853B_CTERMO1 CTERMO1 { get; set; } = new VG0853B_CTERMO1();
        public VG0853B_CDIFPAR CDIFPAR { get; set; } = new VG0853B_CDIFPAR();
        public VG0853B_CDEBANT CDEBANT { get; set; } = new VG0853B_CDEBANT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P, string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                DSAIDA.SetFile(DSAIDA_FILE_NAME_P);
                SSAIDA.SetFile(SSAIDA_FILE_NAME_P);
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);

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
            /*" -1101- DISPLAY ' ' */
            _.Display($" ");

            /*" -1103- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1110- DISPLAY 'PROGRAMA VG0853B - VERSAO V.53 - ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VG0853B - VERSAO V.53 - FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1112- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1113- DISPLAY ' ' */
            _.Display($" ");

            /*" -1120- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1122- DISPLAY ' ' */
            _.Display($" ");

            /*" -1124- MOVE '0001' TO WNR-EXEC-SQL. */
            _.Move("0001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1125- OPEN OUTPUT DSAIDA. */
            DSAIDA.Open(RECORD_DSAIDA);

            /*" -1126- OPEN OUTPUT SSAIDA. */
            SSAIDA.Open(RECORD_SSAIDA);

            /*" -1128- OPEN OUTPUT ARQSAIDA. */
            ARQSAIDA.Open(REG_SAIDA);

            /*" -1132- MOVE ZEROS TO V0PROP-NUM-APOLICE V0PROP-CODSUBES V0PROP-NRCERTIF V0PROP-CODPRODU. */
            _.Move(0, V0PROP_NUM_APOLICE, V0PROP_CODSUBES, V0PROP_NRCERTIF, V0PROP_CODPRODU);

            /*" -1135- MOVE SPACES TO V0PRDVG-NOMPRODU V0PROP-DTPROXVEN. */
            _.Move("", V0PRDVG_NOMPRODU, V0PROP_DTPROXVEN);

            /*" -1151- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -1154- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1155- DISPLAY 'ERRO SELECT V1SISTEMA VA' */
                _.Display($"ERRO SELECT V1SISTEMA VA");

                /*" -1156- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -1158- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1160- MOVE 'ERRO NO ACESSO A TABELA DE SISTEMAS - VG ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA DE SISTEMAS - VG ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1161- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA */
                _.Move(AREA_DE_WORK.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -1162- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA */
                _.Move(AREA_DE_WORK.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -1163- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA */
                _.Move(AREA_DE_WORK.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -1164- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA */
                _.Move(AREA_DE_WORK.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -1165- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -1167- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1168- MOVE V1SIST-DTMOVABE TO WDATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WDATA_SQL);

            /*" -1169- MOVE 8 TO GE0006S-QTDDIAS. */
            _.Move(8, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1170- PERFORM R0220-00-VALIDA-DIA-UTIL. */

            R0220_00_VALIDA_DIA_UTIL_SECTION();

            /*" -1172- MOVE WDATA-SQL TO V1SIST-DT-08. */
            _.Move(WDATA_SQL, V1SIST_DT_08);

            /*" -1173- MOVE V1SIST-DT-15 TO WDATA-SQL. */
            _.Move(V1SIST_DT_15, WDATA_SQL);

            /*" -1174- MOVE 1 TO GE0006S-QTDDIAS. */
            _.Move(1, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1175- PERFORM R0220-00-VALIDA-DIA-UTIL. */

            R0220_00_VALIDA_DIA_UTIL_SECTION();

            /*" -1177- MOVE WDATA-SQL TO V1SIST-DT-15. */
            _.Move(WDATA_SQL, V1SIST_DT_15);

            /*" -1178- MOVE V1SIST-DT-23-CYRELA TO WDATA-SQL. */
            _.Move(V1SIST_DT_23_CYRELA, WDATA_SQL);

            /*" -1179- MOVE 1 TO GE0006S-QTDDIAS. */
            _.Move(1, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -1180- PERFORM R0220-00-VALIDA-DIA-UTIL. */

            R0220_00_VALIDA_DIA_UTIL_SECTION();

            /*" -1182- MOVE WDATA-SQL TO V1SIST-DT-23-CYRELA. */
            _.Move(WDATA_SQL, V1SIST_DT_23_CYRELA);

            /*" -1183- DISPLAY '  ' */
            _.Display($"  ");

            /*" -1184- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -1185- DISPLAY 'V1SIST-DT-08        = ' V1SIST-DT-08 */
            _.Display($"V1SIST-DT-08        = {V1SIST_DT_08}");

            /*" -1186- DISPLAY 'V1SIST-DT-15        = ' V1SIST-DT-15 */
            _.Display($"V1SIST-DT-15        = {V1SIST_DT_15}");

            /*" -1187- DISPLAY 'V1SIST-DTVENFIM-DB  = ' V1SIST-DTVENFIM-DB */
            _.Display($"V1SIST-DTVENFIM-DB  = {V1SIST_DTVENFIM_DB}");

            /*" -1188- DISPLAY 'V1SIST-DT-23-CYRELA = ' V1SIST-DT-23-CYRELA */
            _.Display($"V1SIST-DT-23-CYRELA = {V1SIST_DT_23_CYRELA}");

            /*" -1189- DISPLAY 'V1SIST-DTMOVABE     = ' V1SIST-DTMOVABE */
            _.Display($"V1SIST-DTMOVABE     = {V1SIST_DTMOVABE}");

            /*" -1190- DISPLAY 'V1SIST-DTTERCOT     = ' V1SIST-DTTERCOT */
            _.Display($"V1SIST-DTTERCOT     = {V1SIST_DTTERCOT}");

            /*" -1191- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -1193- DISPLAY '  ' */
            _.Display($"  ");

            /*" -1195- MOVE V1SIST-DTMOVABE (9:2) TO REG-CABEC-01-DATA (1:2) */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(9, 2), REG_CABEC_01.REG_CABEC_01_DATA, 1, 2);

            /*" -1197- MOVE V1SIST-DTMOVABE (6:2) TO REG-CABEC-01-DATA (4:2) */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(6, 2), REG_CABEC_01.REG_CABEC_01_DATA, 4, 2);

            /*" -1199- MOVE V1SIST-DTMOVABE (1:4) TO REG-CABEC-01-DATA (7:4) */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(1, 4), REG_CABEC_01.REG_CABEC_01_DATA, 7, 4);

            /*" -1203- MOVE '/' TO REG-CABEC-01-DATA(6:1) */
            _.MoveAtPosition("/", REG_CABEC_01.REG_CABEC_01_DATA, 6, 1);

            /*" -1203- MOVE '/' TO REG-CABEC-01-DATA(3:1) */
            _.MoveAtPosition("/", REG_CABEC_01.REG_CABEC_01_DATA, 3, 1);

            /*" -1204- MOVE V1SIST-DTMOVABE(1:4) TO HD-DTA-SIS-DSAIDA(7:4). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(1, 4), AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 7, 4);

            /*" -1205- MOVE V1SIST-DTMOVABE(6:2) TO HD-DTA-SIS-DSAIDA(4:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(6, 2), AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 4, 2);

            /*" -1206- MOVE V1SIST-DTMOVABE(9:2) TO HD-DTA-SIS-DSAIDA(1:2). */
            _.MoveAtPosition(V1SIST_DTMOVABE.Substring(9, 2), AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 1, 2);

            /*" -1208- MOVE '/' TO HD-DTA-SIS-DSAIDA(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 6, 1);

            /*" -1208- MOVE '/' TO HD-DTA-SIS-DSAIDA(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 3, 1);

            /*" -1210- MOVE HD-DTA-SIS-DSAIDA TO HD-DTA-SIS-SSAIDA. */
            _.Move(AREA_DE_WORK.HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, AREA_DE_WORK.HD_REG_SSAIDA.HD_DTA_SIS_SSAIDA);

            /*" -1211- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA. */
            _.Move(AREA_DE_WORK.HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -1212- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA. */
            _.Move(AREA_DE_WORK.CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -1213- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA. */
            _.Move(AREA_DE_WORK.HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

            /*" -1215- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA. */
            _.Move(AREA_DE_WORK.CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

            /*" -1216- WRITE REG-SAIDA FROM REG-CABEC-01. */
            _.Move(REG_CABEC_01.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1223- WRITE REG-SAIDA FROM REG-CABEC-02. */
            _.Move(REG_CABEC_02.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1225- MOVE '0002' TO WNR-EXEC-SQL. */
            _.Move("0002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1226- MOVE V1SIST-DTTERCOT TO W01DTSQL. */
            _.Move(V1SIST_DTTERCOT, AREA_DE_WORK.W01DTSQL);

            /*" -1227- MOVE 01 TO W01DDSQL. */
            _.Move(01, AREA_DE_WORK.W01DTSQL.W01DDSQL);

            /*" -1233- MOVE W01DTSQL TO V1SIST-DTTERCOT. */
            _.Move(AREA_DE_WORK.W01DTSQL, V1SIST_DTTERCOT);

            /*" -1234- MOVE V1SIST-DTMOVABE TO W01DTSQL. */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.W01DTSQL);

            /*" -1235- MOVE 01 TO W01DDSQL. */
            _.Move(01, AREA_DE_WORK.W01DTSQL.W01DDSQL);

            /*" -1237- MOVE W01DTSQL TO V1SIST-DTMAXALTIGPM. */
            _.Move(AREA_DE_WORK.W01DTSQL, V1SIST_DTMAXALTIGPM);

            /*" -1239- MOVE '0003' TO WNR-EXEC-SQL. */
            _.Move("0003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1245- PERFORM R0000_00_PRINCIPAL_DB_SELECT_2 */

            R0000_00_PRINCIPAL_DB_SELECT_2();

            /*" -1248- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1249- MOVE 'S' TO W-IGPM-CADASTRADO */
                _.Move("S", W_IGPM_CADASTRADO);

                /*" -1250- ELSE */
            }
            else
            {


                /*" -1252- MOVE 'N' TO W-IGPM-CADASTRADO. */
                _.Move("N", W_IGPM_CADASTRADO);
            }


            /*" -1254- MOVE 'A003' TO WNR-EXEC-SQL. */
            _.Move("A003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1259- PERFORM R0000_00_PRINCIPAL_DB_SELECT_3 */

            R0000_00_PRINCIPAL_DB_SELECT_3();

            /*" -1263- MOVE 'B003' TO WNR-EXEC-SQL. */
            _.Move("B003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1325- PERFORM R0000_00_PRINCIPAL_DB_DECLARE_1 */

            R0000_00_PRINCIPAL_DB_DECLARE_1();

            /*" -1328- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1332- STRING WS-TIME(1:2) ':' WS-TIME(3:2) ':' WS-TIME(5:2) DELIMITED BY SIZE INTO WS-TIME-HMS END-STRING */
            #region STRING
            var spl1 = WS_TIME.Substring(1, 2).GetMoveValues();
            spl1 += ":";
            var spl2 = WS_TIME.Substring(3, 2).GetMoveValues();
            spl2 += ":";
            var spl3 = WS_TIME.Substring(5, 2).GetMoveValues();
            var results4 = spl1 + spl2 + spl3;
            _.Move(results4, WS_TIME_HMS);
            #endregion

            /*" -1334- DISPLAY 'INICIO OPEN CURSOR ' WS-TIME-HMS */
            _.Display($"INICIO OPEN CURSOR {WS_TIME_HMS}");

            /*" -1335- MOVE 'C003' TO WNR-EXEC-SQL. */
            _.Move("C003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1335- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -1338- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1339- DISPLAY 'PROBLEMAS NO OPEN (CPROPVA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CPROPVA   ) ... ");

                /*" -1340- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -1342- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1344- MOVE 'ERRO NA ABERTURA DO CURSOR DE PROPOSTAS - CPROPVA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ABERTURA DO CURSOR DE PROPOSTAS - CPROPVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1345- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -1347- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1348- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1352- STRING WS-TIME(1:2) ':' WS-TIME(3:2) ':' WS-TIME(5:2) DELIMITED BY SIZE INTO WS-TIME-HMS END-STRING */
            #region STRING
            var spl4 = WS_TIME.Substring(1, 2).GetMoveValues();
            spl4 += ":";
            var spl5 = WS_TIME.Substring(3, 2).GetMoveValues();
            spl5 += ":";
            var spl6 = WS_TIME.Substring(5, 2).GetMoveValues();
            var results7 = spl4 + spl5 + spl6;
            _.Move(results7, WS_TIME_HMS);
            #endregion

            /*" -1354- DISPLAY 'FIM    OPEN CURSOR ' WS-TIME-HMS */
            _.Display($"FIM    OPEN CURSOR {WS_TIME_HMS}");

            /*" -1356- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

            /*" -1357- IF WFIM-CPROPVA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty())
            {

                /*" -1359- DISPLAY '*** VG0853B *** NENHUMA PARCELA A PROCESSAR' */
                _.Display($"*** VG0853B *** NENHUMA PARCELA A PROCESSAR");

                /*" -1361- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1363- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1368- PERFORM R0000_00_PRINCIPAL_DB_SELECT_4 */

            R0000_00_PRINCIPAL_DB_SELECT_4();

            /*" -1371- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1372- DISPLAY 'BANCO NAO CADASTRADO (V0BANCO) 104 ' */
                _.Display($"BANCO NAO CADASTRADO (V0BANCO) 104 ");

                /*" -1373- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -1375- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1377- MOVE 'BANCO NAO CADASTRADO NA VIEW V0BANCO' TO LD-DES-ERRO-SSAIDA */
                _.Move("BANCO NAO CADASTRADO NA VIEW V0BANCO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1378- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -1380- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1381- MOVE V0BANC-NRTIT TO W-NUMR-TITULO. */
            _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

            /*" -1382- DISPLAY ' ' */
            _.Display($" ");

            /*" -1383- DISPLAY 'NUMERO BANCO TITULO <' W-NUMR-TITULO '>' */

            $"NUMERO BANCO TITULO <{W_NUMR_TITULO}>"
            .Display();

            /*" -1404- DISPLAY ' ' */
            _.Display($" ");

            /*" -1407- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CPROPVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CPROPVA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1409- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1414- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_1 */

            R0000_00_PRINCIPAL_DB_UPDATE_1();

            /*" -1417- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1418- DISPLAY 'R0000 - ERRO UPDATE V0BANCO 104' */
                _.Display($"R0000 - ERRO UPDATE V0BANCO 104");

                /*" -1419- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -1421- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1423- MOVE 'ERRO NO UPDATE DA VIEW V0BANCO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0BANCO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1424- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -1443- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1444- DISPLAY 'PROPOSTAS LIDAS ............ ' WACC-LIDOS. */
            _.Display($"PROPOSTAS LIDAS ............ {AREA_DE_WORK.WACC_LIDOS}");

            /*" -1446- DISPLAY 'PARCELAS GERADAS ........... ' WACC-GRAVADOS. */
            _.Display($"PARCELAS GERADAS ........... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -1449- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1449- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1151- EXEC SQL SELECT CURRENT DATE + 15 DAYS, DTMOVABE + 08 DAY , CURRENT DATE + 01 DAY , CURRENT DATE + 23 DAYS, DTMOVABE , DTMOVABE - 1 MONTH INTO :V1SIST-DT-15 , :V1SIST-DT-08 , :V1SIST-DTVENFIM-DB , :V1SIST-DT-23-CYRELA , :V1SIST-DTMOVABE , :V1SIST-DTTERCOT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DT_15, V1SIST_DT_15);
                _.Move(executed_1.V1SIST_DT_08, V1SIST_DT_08);
                _.Move(executed_1.V1SIST_DTVENFIM_DB, V1SIST_DTVENFIM_DB);
                _.Move(executed_1.V1SIST_DT_23_CYRELA, V1SIST_DT_23_CYRELA);
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTTERCOT, V1SIST_DTTERCOT);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1455- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1456- DISPLAY ' ' */
            _.Display($" ");

            /*" -1457- DISPLAY '*--------  VG0853B - FIM NORMAL  --------*' */
            _.Display($"*--------  VG0853B - FIM NORMAL  --------*");

            /*" -1458- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -1461- STRING WS-TIME(1:2) ':' WS-TIME(3:2) ':' WS-TIME(5:2) DELIMITED BY SIZE INTO WS-TIME-HMS END-STRING */
            #region STRING
            var spl7 = WS_TIME.Substring(1, 2).GetMoveValues();
            spl7 += ":";
            var spl8 = WS_TIME.Substring(3, 2).GetMoveValues();
            spl8 += ":";
            var spl9 = WS_TIME.Substring(5, 2).GetMoveValues();
            var results10 = spl7 + spl8 + spl9;
            _.Move(results10, WS_TIME_HMS);
            #endregion

            /*" -1463- DISPLAY 'REGISTROS PROCESSADOS ...... ' WACC-LIDOS '  EM  ' WS-TIME-HMS */

            $"REGISTROS PROCESSADOS ...... {AREA_DE_WORK.WACC_LIDOS}  EM  {WS_TIME_HMS}"
            .Display();

            /*" -1465- DISPLAY 'PARCELAS GERADAS ........... ' WACC-GRAVADOS. */
            _.Display($"PARCELAS GERADAS ........... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -1466- CLOSE DSAIDA. */
            DSAIDA.Close();

            /*" -1467- CLOSE SSAIDA. */
            SSAIDA.Close();

            /*" -1469- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

            /*" -1471- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (AREA_DE_WORK.AC_ERRO_DADOS > 00 && AREA_DE_WORK.AC_ERRO_SISTEMA > 00)
            {

                /*" -1472- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -1473- ELSE */
            }
            else
            {


                /*" -1474- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (AREA_DE_WORK.AC_ERRO_SISTEMA > 00)
                {

                    /*" -1475- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -1476- ELSE */
                }
                else
                {


                    /*" -1477- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (AREA_DE_WORK.AC_ERRO_DADOS > 00)
                    {

                        /*" -1479- MOVE 1 TO RETURN-CODE. */
                        _.Move(1, RETURN_CODE);
                    }

                }

            }


            /*" -1479- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-2 */
        public void R0000_00_PRINCIPAL_DB_SELECT_2()
        {
            /*" -1245- EXEC SQL SELECT DTINIVIG INTO :V0COTA-DTINIVIG FROM SEGUROS.V0COTACAO WHERE CODUNIMO = 23 AND DTINIVIG = :V1SIST-DTTERCOT END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_2_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_2_Query1()
            {
                V1SIST_DTTERCOT = V1SIST_DTTERCOT.ToString(),
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_2_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COTA_DTINIVIG, V0COTA_DTINIVIG);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-DECLARE-1 */
        public void R0000_00_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -1325- EXEC SQL DECLARE CPROPVA CURSOR WITH HOLD FOR SELECT NUM_APOLICE, CODSUBES, NRCERTIF, CODPRODU, CODCLIEN, NRPARCE, SITUACAO, DTQITBCO, DTVENCTO, DTPROXVEN, NRPRIPARATZ, QTDPARATZ, NUM_MATRICULA, TIMESTAMP, DTQITBCO + 1 MONTH, DTQITBCO + 1 YEAR, CODOPER, VALUE(DATA_ADMISSAO, DATE( '1900-01-01' )), STA_ANTECIPACAO, OCORHIST FROM SEGUROS.V0PROPOSTAVA WHERE DTPROXVEN BETWEEN :WHOST-MIN-DTPROXVEN AND :V1SIST-DT-23-CYRELA AND SITUACAO IN ( '3' , '6' ) AND NUM_APOLICE NOT IN (109300000635, 108208503665, 109300006385, 107700000007) AND CODPRODU IN (7701, 7703, 8203, :JVPRD8203, 8205, :JVPRD8205, 8206, :JVPRD8206, 8207, 8209, :JVPRD8209, 8214, :JVPRD8214, 8215, 8217, 8220, 8222, 8223, 8224, 8225, 8226, 8228, 8234, 9306, 9311, :JVPRD9311, 9313, 9315, 9316, 9322, 9323, 9324, 9325, 9326, 9329, :JVPRD9329, 9330, :JVPRD9330, 9331, 9343, :JVPRD9343, 9354, 9363, 9365, 9706, 9711, 9712, 9713, 9714, 9715 ) AND DTPROXVEN <> '9999-12-31' FOR UPDATE OF NRPARCE, SITUACAO, DTVENCTO, DTPROXVEN, NRPRIPARATZ, QTDPARATZ, OCORHIST, TIMESTAMP END-EXEC. */
            CPROPVA = new VG0853B_CPROPVA(true);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							NRCERTIF
							, 
							CODPRODU
							, 
							CODCLIEN
							, 
							NRPARCE
							, 
							SITUACAO
							, 
							DTQITBCO
							, 
							DTVENCTO
							, 
							DTPROXVEN
							, 
							NRPRIPARATZ
							, 
							QTDPARATZ
							, 
							NUM_MATRICULA
							, 
							TIMESTAMP
							, 
							DTQITBCO + 1 MONTH
							, 
							DTQITBCO + 1 YEAR
							, 
							CODOPER
							, 
							VALUE(DATA_ADMISSAO
							, DATE( '1900-01-01' ))
							, 
							STA_ANTECIPACAO
							, 
							OCORHIST 
							FROM SEGUROS.V0PROPOSTAVA 
							WHERE DTPROXVEN BETWEEN '{WHOST_MIN_DTPROXVEN}' 
							AND '{V1SIST_DT_23_CYRELA}' 
							AND SITUACAO IN ( '3'
							, '6' ) 
							AND NUM_APOLICE NOT IN (109300000635
							, 108208503665
							, 
							109300006385
							, 
							107700000007) 
							AND CODPRODU IN (7701
							, 7703
							, 
							8203
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8203}'
							, 
							8205
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8205}'
							, 
							8206
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8206}'
							, 
							8207
							, 
							8209
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}'
							, 
							8214
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8214}'
							, 
							8215
							, 8217
							, 8220
							, 
							8222
							, 8223
							, 8224
							, 8225
							, 8226
							, 
							8228
							, 8234
							, 
							9306
							, 
							9311
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9311}'
							, 
							9313
							, 9315
							, 9316
							, 9322
							, 
							9323
							, 9324
							, 9325
							, 9326
							, 
							9329
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9329}'
							, 
							9330
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9330}'
							, 
							9331
							, 
							9343
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9343}'
							, 
							9354
							, 
							9363
							, 9365
							, 
							9706
							, 9711
							, 9712
							, 9713
							, 
							9714
							, 9715 
							) 
							AND DTPROXVEN <> '9999-12-31'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -1335- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-DECLARE-1 */
        public void R1000_10_LEITURA_RAMO_DB_DECLARE_1()
        {
            /*" -2106- EXEC SQL DECLARE CATRASO CURSOR FOR SELECT NRPARCEL FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND SITUACAO IN ( ' ' , '0' , X'00' ) ORDER BY NRPARCEL END-EXEC. */
            CATRASO = new VG0853B_CATRASO(true);
            string GetQuery_CATRASO()
            {
                var query = @$"SELECT NRPARCEL 
							FROM SEGUROS.V0PARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND SITUACAO IN ( ' '
							, '0'
							, X'00' ) 
							ORDER BY NRPARCEL";

                return query;
            }
            CATRASO.GetQueryEvent += GetQuery_CATRASO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-1 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -1414- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_UPDATE_1_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_1_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-3 */
        public void R0000_00_PRINCIPAL_DB_SELECT_3()
        {
            /*" -1259- EXEC SQL SELECT VALUE(MIN(DTPROXVEN),DATE( '1999-12-31' )) INTO :WHOST-MIN-DTPROXVEN FROM SEGUROS.V0PROPOSTAVA WHERE SITUACAO IN ( '3' , '6' ) END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_3_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_3_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MIN_DTPROXVEN, WHOST_MIN_DTPROXVEN);
            }


        }

        [StopWatch]
        /*" R0220-00-VALIDA-DIA-UTIL-SECTION */
        private void R0220_00_VALIDA_DIA_UTIL_SECTION()
        {
            /*" -1491- MOVE 'R0220' TO WNR-EXEC-SQL. */
            _.Move("R0220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1493- MOVE WDATA-SQL TO GE0006S-DATA-DESTINO. */
            _.Move(WDATA_SQL, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -1495- MOVE SPACES TO GE0006S-MENSAGEM. */
            _.Move("", GE0006S_LINKAGE.GE0006S_MENSAGEM);

            /*" -1497- CALL 'GE0006S' USING GE0006S-LINKAGE. */
            _.Call("GE0006S", GE0006S_LINKAGE);

            /*" -1498- IF GE0006S-MENSAGEM EQUAL SPACES */

            if (GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty())
            {

                /*" -1499- MOVE GE0006S-DATA-DESTINO TO WDATA-SQL */
                _.Move(GE0006S_LINKAGE.GE0006S_DATA_DESTINO, WDATA_SQL);

                /*" -1500- ELSE */
            }
            else
            {


                /*" -1501- DISPLAY 'PROBLEMA NA ROTINA GE0006S' */
                _.Display($"PROBLEMA NA ROTINA GE0006S");

                /*" -1502- DISPLAY 'MENSAGEM -->' GE0006S-MENSAGEM */
                _.Display($"MENSAGEM -->{GE0006S_LINKAGE.GE0006S_MENSAGEM}");

                /*" -1503- MOVE 'F' TO WS-TIPO-MENSAGEM */
                _.Move("F", WS_TIPO_MENSAGEM);

                /*" -1504- MOVE '10221' TO WNR-EXEC-SQL */
                _.Move("10221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1506- MOVE 'PROBLEMA NA CHAMADA DA SUBROTINA GE0006S' TO WS-MSG-DESCRICAO */
                _.Move("PROBLEMA NA CHAMADA DA SUBROTINA GE0006S", WS_MSG_DESCRICAO);

                /*" -1507- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1507- END-IF. */
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-4 */
        public void R0000_00_PRINCIPAL_DB_SELECT_4()
        {
            /*" -1368- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_4_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_4_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_4_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-SECTION */
        private void R0910_00_FETCH_CPROPVA_SECTION()
        {
            /*" -1518- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1539- PERFORM R0910_00_FETCH_CPROPVA_DB_FETCH_1 */

            R0910_00_FETCH_CPROPVA_DB_FETCH_1();

            /*" -1542- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1543- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1543- PERFORM R0910_00_FETCH_CPROPVA_DB_CLOSE_1 */

                    R0910_00_FETCH_CPROPVA_DB_CLOSE_1();

                    /*" -1545- MOVE 'S' TO WFIM-CPROPVA */
                    _.Move("S", AREA_DE_WORK.WFIM_CPROPVA);

                    /*" -1546- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1547- ELSE */
                }
                else
                {


                    /*" -1548- DISPLAY 'R0910-00 (ERRO -  FETCH CPROPVA   )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CPROPVA   )...");

                    /*" -1549- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -1551- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1553- MOVE 'ERRO NO FETCH DO CURSOR DE PROPOSTAS - CPROPVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DE PROPOSTAS - CPROPVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1554- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -1556- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1557- IF V0PROP-INRMATRFUN LESS 0 */

            if (V0PROP_INRMATRFUN < 0)
            {

                /*" -1559- MOVE 0 TO V0PROP-NRMATRFUN. */
                _.Move(0, V0PROP_NRMATRFUN);
            }


            /*" -1562- IF V0PROP-CODPRODU EQUAL 9343 OR 8209 OR JVPROD(9343) OR JVPROD(8209) */

            if (V0PROP_CODPRODU.In("9343", "8209", JVBKINCL.FILLER.JVPROD[9343].ToString(), JVBKINCL.FILLER.JVPROD[8209].ToString()))
            {

                /*" -1563- IF VIND-STANTECIP LESS ZEROS */

                if (VIND_STANTECIP < 00)
                {

                    /*" -1564- MOVE SPACES TO V0PROP-STANTECIP */
                    _.Move("", V0PROP_STANTECIP);

                    /*" -1565- END-IF */
                }


                /*" -1567- END-IF. */
            }


            /*" -1568- ADD 1 TO WACC-LIDOS WACC-COMMIT. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;
            AREA_DE_WORK.WACC_COMMIT.Value = AREA_DE_WORK.WACC_COMMIT + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-FETCH-1 */
        public void R0910_00_FETCH_CPROPVA_DB_FETCH_1()
        {
            /*" -1539- EXEC SQL FETCH CPROPVA INTO :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-NRCERTIF, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-NRPRIPARATZ, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN, :V0PROP-TIMESTAMP, :V0PROP-DTMINVEN, :V0PROP-DTQITBCO-1YEAR, :V0PROP-CODOPER, :V0PROP-DTADMISSAO, :V0PROP-STANTECIP:VIND-STANTECIP, :V0PROP-OCORHIST END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(CPROPVA.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(CPROPVA.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(CPROPVA.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CPROPVA.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CPROPVA.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(CPROPVA.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CPROPVA.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CPROPVA.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(CPROPVA.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(CPROPVA.V0PROP_NRPRIPARATZ, V0PROP_NRPRIPARATZ);
                _.Move(CPROPVA.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(CPROPVA.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(CPROPVA.V0PROP_INRMATRFUN, V0PROP_INRMATRFUN);
                _.Move(CPROPVA.V0PROP_TIMESTAMP, V0PROP_TIMESTAMP);
                _.Move(CPROPVA.V0PROP_DTMINVEN, V0PROP_DTMINVEN);
                _.Move(CPROPVA.V0PROP_DTQITBCO_1YEAR, V0PROP_DTQITBCO_1YEAR);
                _.Move(CPROPVA.V0PROP_CODOPER, V0PROP_CODOPER);
                _.Move(CPROPVA.V0PROP_DTADMISSAO, V0PROP_DTADMISSAO);
                _.Move(CPROPVA.V0PROP_STANTECIP, V0PROP_STANTECIP);
                _.Move(CPROPVA.VIND_STANTECIP, VIND_STANTECIP);
                _.Move(CPROPVA.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CPROPVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_CPROPVA_DB_CLOSE_1()
        {
            /*" -1543- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1586- PERFORM R1100-00-LE-OPCAOPAG. */

            R1100_00_LE_OPCAOPAG_SECTION();

            /*" -1587- IF NAO-OPCAOPAG */

            if (AREA_DE_WORK.N88_VERIFICA_OPCAOPAG["NAO_OPCAOPAG"])
            {

                /*" -1588- GO TO R1000-91-NEXT */

                R1000_91_NEXT(); //GOTO
                return;

                /*" -1590- END-IF */
            }


            /*" -1592- IF (V0PROP-NUM-APOLICE EQUAL 109300002554) */

            if ((V0PROP_NUM_APOLICE == 109300002554))
            {

                /*" -1593- CONTINUE */

                /*" -1594- ELSE */
            }
            else
            {


                /*" -1596- IF V0PROP-CODPRODU EQUAL 8203 OR 9311 OR 9354 OR JVPROD(8203) OR JVPROD(9311) */

                if (V0PROP_CODPRODU.In("8203", "9311", "9354", JVBKINCL.FILLER.JVPROD[8203].ToString(), JVBKINCL.FILLER.JVPROD[9311].ToString()))
                {

                    /*" -1597- IF (V0PROP-DTPROXVEN > V1SIST-DT-15) */

                    if ((V0PROP_DTPROXVEN > V1SIST_DT_15))
                    {

                        /*" -1598- GO TO R1000-91-NEXT */

                        R1000_91_NEXT(); //GOTO
                        return;

                        /*" -1599- END-IF */
                    }


                    /*" -1600- ELSE */
                }
                else
                {


                    /*" -1601- IF V0OPCP-OPCAOPAG EQUAL '3' */

                    if (V0OPCP_OPCAOPAG == "3")
                    {

                        /*" -1602- IF (V0PROP-DTPROXVEN > V1SIST-DT-15) */

                        if ((V0PROP_DTPROXVEN > V1SIST_DT_15))
                        {

                            /*" -1603- GO TO R1000-91-NEXT */

                            R1000_91_NEXT(); //GOTO
                            return;

                            /*" -1604- END-IF */
                        }


                        /*" -1605- ELSE */
                    }
                    else
                    {


                        /*" -1606- IF (V0PROP-DTPROXVEN > V1SIST-DT-08) */

                        if ((V0PROP_DTPROXVEN > V1SIST_DT_08))
                        {

                            /*" -1607- GO TO R1000-91-NEXT */

                            R1000_91_NEXT(); //GOTO
                            return;

                            /*" -1608- END-IF */
                        }


                        /*" -1609- END-IF */
                    }


                    /*" -1610- END-IF */
                }


                /*" -1612- END-IF */
            }


            /*" -1619- PERFORM R6000-00-VERIFICA-CONTROLE-MNL */

            R6000_00_VERIFICA_CONTROLE_MNL_SECTION();

            /*" -1620- IF (WHOST-CNTRLE-MNL EQUAL 2) */

            if ((WHOST_CNTRLE_MNL == 2))
            {

                /*" -1621- GO TO R1000-91-NEXT */

                R1000_91_NEXT(); //GOTO
                return;

                /*" -1624- END-IF */
            }


            /*" -1629- PERFORM R5000-00-BUSCA-VLPREMIO */

            R5000_00_BUSCA_VLPREMIO_SECTION();

            /*" -1632- IF V0PROP-CODPRODU EQUAL 9343 OR 8209 OR JVPROD(9343) OR JVPROD(8209) */

            if (V0PROP_CODPRODU.In("9343", "8209", JVBKINCL.FILLER.JVPROD[9343].ToString(), JVBKINCL.FILLER.JVPROD[8209].ToString()))
            {

                /*" -1635- IF V0PROP-STANTECIP EQUAL 'N' NEXT SENTENCE */

                if (V0PROP_STANTECIP == "N")
                {

                    /*" -1636- ELSE */
                }
                else
                {


                    /*" -1637- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -1638- MOVE ZEROS TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(0, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1641- MOVE 'EMPRESARIAL ANTECIPADO VENCIDO E NAO MIGRADO' TO LD-DES-ERRO-SSAIDA REG-SAI-DESCRICAO */
                    _.Move("EMPRESARIAL ANTECIPADO VENCIDO E NAO MIGRADO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA, REG_DET.REG_SAI_DESCRICAO);

                    /*" -1642- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -1643- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -1644- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -1645- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -1646- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -1647- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1648- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -1649- END-IF */
                }


                /*" -1651- END-IF. */
            }


            /*" -1653- MOVE '100V' TO WNR-EXEC-SQL. */
            _.Move("100V", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1654- IF V0PROP-NUM-APOLICE = 108210871143 */

            if (V0PROP_NUM_APOLICE == 108210871143)
            {

                /*" -1655- MOVE V0PROP-DTPROXVEN TO W03DTFAT */
                _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.W03DTFAT);

                /*" -1656- MOVE 01 TO W03DDFAT */
                _.Move(01, AREA_DE_WORK.W03DTFAT.W03DDFAT);

                /*" -1657- MOVE W03DTFAT TO HISCOBPR-DATA-INIVIGENCIA */
                _.Move(AREA_DE_WORK.W03DTFAT, HISCOBPR_DATA_INIVIGENCIA);

                /*" -1663- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_1 */

                R1000_00_PROCESSA_REGISTRO_DB_SELECT_1();

                /*" -1665- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1666- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -1670- DISPLAY 'FATURA NAO GERADA PARA O PROX VCTO ----> ' ' ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES ' ' V0PROP-NRCERTIF */

                        $"FATURA NAO GERADA PARA O PROX VCTO ---->  {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES} {V0PROP_NRCERTIF}"
                        .Display();

                        /*" -1671- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -1673- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -1676- MOVE 'FATURA NAO GERADA REDE-SIM - PARCELA NAO GERADA ' TO LD-DES-ERRO-SSAIDA */
                        _.Move("FATURA NAO GERADA REDE-SIM - PARCELA NAO GERADA ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -1677- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -1678- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                        _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                        /*" -1679- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                        _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                        /*" -1681- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                        /*" -1683- MOVE 'ERRO ** NAO ENCONTRADO NA HISCOBPR       ' TO REG-SAI-DESCRICAO */
                        _.Move("ERRO ** NAO ENCONTRADO NA HISCOBPR       ", REG_DET.REG_SAI_DESCRICAO);

                        /*" -1684- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                        _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                        /*" -1685- WRITE REG-SAIDA FROM REG-DET */
                        _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                        ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                        /*" -1686- GO TO R1000-91-NEXT */

                        R1000_91_NEXT(); //GOTO
                        return;

                        /*" -1687- ELSE */
                    }
                    else
                    {


                        /*" -1688- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -1690- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -1692- MOVE 'ERRO NO ACESSO A TABELA HIS_COBER_PROPOST' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO NO ACESSO A TABELA HIS_COBER_PROPOST", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -1693- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -1694- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1695- END-IF */
                    }


                    /*" -1696- END-IF */
                }


                /*" -1698- END-IF. */
            }


            /*" -1700- MOVE '100W' TO WNR-EXEC-SQL. */
            _.Move("100W", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1702- MOVE SPACES TO V0PRDVG-NOMPRODU. */
            _.Move("", V0PRDVG_NOMPRODU);

            /*" -1708- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -1711- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1712- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1716- DISPLAY 'DESPRE SEGUROS.HIS_COBER_PROPOST ----> ' ' ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES ' ' V0PROP-NRCERTIF */

                    $"DESPRE SEGUROS.HIS_COBER_PROPOST ---->  {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES} {V0PROP_NRCERTIF}"
                    .Display();

                    /*" -1717- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -1719- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1721- MOVE 'REG. NAO ENCONTRADO NA TABELA HIS_COBER_PROPOST' TO LD-DES-ERRO-SSAIDA */
                    _.Move("REG. NAO ENCONTRADO NA TABELA HIS_COBER_PROPOST", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1722- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -1723- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -1724- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -1726- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -1728- MOVE 'ERRO ** NAO ENCONTRADO NA HISCOBPR IV    ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO ENCONTRADO NA HISCOBPR IV    ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -1729- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -1730- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1731- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -1732- ELSE */
                }
                else
                {


                    /*" -1733- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -1735- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1737- MOVE 'ERRO NO ACESSO A TABELA HIS_COBER_PROPOST' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A TABELA HIS_COBER_PROPOST", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1738- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -1740- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1742- MOVE '100Z' TO WNR-EXEC-SQL. */
            _.Move("100Z", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1757- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -1760- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1767- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1773- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_4 */

                    R1000_00_PROCESSA_REGISTRO_DB_SELECT_4();

                    /*" -1776- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1777- IF V0PRDVG-ORIG-PRODU EQUAL 'CEF DEB CC' */

                        if (V0PRDVG_ORIG_PRODU == "CEF DEB CC")
                        {

                            /*" -1778- GO TO R1000-90-LEITURA */

                            R1000_90_LEITURA(); //GOTO
                            return;

                            /*" -1779- ELSE */
                        }
                        else
                        {


                            /*" -1780- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                            _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                            /*" -1781- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                            _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                            /*" -1783- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                            _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                            /*" -1785- MOVE 'ERRO ** NAO ENCONTRADO NA SUBGVGAP       ' TO REG-SAI-DESCRICAO */
                            _.Move("ERRO ** NAO ENCONTRADO NA SUBGVGAP       ", REG_DET.REG_SAI_DESCRICAO);

                            /*" -1786- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                            _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                            /*" -1787- WRITE REG-SAIDA FROM REG-DET */
                            _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                            /*" -1788- GO TO R1000-90-LEITURA */

                            R1000_90_LEITURA(); //GOTO
                            return;

                            /*" -1789- END-IF */
                        }


                        /*" -1790- END-IF */
                    }


                    /*" -1791- ELSE */
                }
                else
                {


                    /*" -1792- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -1794- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1796- MOVE 'ERRO NO ACESSO A VIEW V0SUBGRUPO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V0SUBGRUPO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1797- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -1798- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1799- END-IF */
                }


                /*" -1801- END-IF */
            }


            /*" -1802- MOVE ' ' TO V0PRDVG-ESTR-COBR. */
            _.Move(" ", V0PRDVG_ESTR_COBR);

            /*" -1803- MOVE ' ' TO V0PRDVG-ORIG-PRODU. */
            _.Move(" ", V0PRDVG_ORIG_PRODU);

            /*" -1804- MOVE 'N' TO V0PRDVG-TEM-SAF. */
            _.Move("N", V0PRDVG_TEM_SAF);

            /*" -1806- MOVE 'N' TO V0PRDVG-TEM-IGPM. */
            _.Move("N", V0PRDVG_TEM_IGPM);

            /*" -1808- MOVE '100Y' TO WNR-EXEC-SQL. */
            _.Move("100Y", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1830- PERFORM R1000_00_PROCESSA_REGISTRO_DB_SELECT_5 */

            R1000_00_PROCESSA_REGISTRO_DB_SELECT_5();

            /*" -1833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1834- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -1836- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1838- MOVE 'ERRO NO ACESSO A VIEW V0PRODUTOSVG' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V0PRODUTOSVG", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1839- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -1840- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1841- DISPLAY 'APOLICE ...' V0PROP-NUM-APOLICE */
                    _.Display($"APOLICE ...{V0PROP_NUM_APOLICE}");

                    /*" -1842- DISPLAY 'SUBGRUPO...' V0PROP-CODSUBES */
                    _.Display($"SUBGRUPO...{V0PROP_CODSUBES}");

                    /*" -1843- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -1844- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -1845- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -1847- MOVE 'ERRO ** NAO ENCONTRADO NA PRODUVG        ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO ENCONTRADO NA PRODUVG        ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -1848- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -1849- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1850- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -1851- ELSE */
                }
                else
                {


                    /*" -1853- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1854- IF V0SUBG-SIT-REGISTRO EQUAL '2' */

            if (V0SUBG_SIT_REGISTRO == "2")
            {

                /*" -1855- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                /*" -1856- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                /*" -1857- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                /*" -1859- MOVE 'ALERTA ** SUBGRUPO CANCELADO               ' TO REG-SAI-DESCRICAO */
                _.Move("ALERTA ** SUBGRUPO CANCELADO               ", REG_DET.REG_SAI_DESCRICAO);

                /*" -1860- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                /*" -1861- WRITE REG-SAIDA FROM REG-DET */
                _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -1904- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -1905- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -1907- MOVE ' ' TO V0PRDVG-ESTR-COBR. */
                _.Move(" ", V0PRDVG_ESTR_COBR);
            }


            /*" -1908- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -1910- MOVE ' ' TO V0PRDVG-ORIG-PRODU. */
                _.Move(" ", V0PRDVG_ORIG_PRODU);
            }


            /*" -1911- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -1913- MOVE 'N' TO V0PRDVG-TEM-SAF. */
                _.Move("N", V0PRDVG_TEM_SAF);
            }


            /*" -1914- IF VIND-TEM-IGPM LESS 0 */

            if (VIND_TEM_IGPM < 0)
            {

                /*" -1916- MOVE 'N' TO V0PRDVG-TEM-IGPM. */
                _.Move("N", V0PRDVG_TEM_IGPM);
            }


            /*" -1919- IF (V0PRDVG-ORIG-PRODU NOT EQUAL 'ESPEC' AND 'EMPRE' AND 'ESPE1' AND 'ESPE2' AND 'ESPE3' AND 'GLOBAL' AND 'ESPEC1' AND 'ESPEC2' AND 'ESPEC3' ) */

            if ((!V0PRDVG_ORIG_PRODU.In("ESPEC", "EMPRE", "ESPE1", "ESPE2", "ESPE3", "GLOBAL", "ESPEC1", "ESPEC2", "ESPEC3")))
            {

                /*" -1920- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                /*" -1921- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                /*" -1922- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                /*" -1924- MOVE 'ALERTA ** DIVERGENCIA NA ORIGEM DO PRODUTO    ' TO REG-SAI-DESCRICAO */
                _.Move("ALERTA ** DIVERGENCIA NA ORIGEM DO PRODUTO    ", REG_DET.REG_SAI_DESCRICAO);

                /*" -1925- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                /*" -1926- WRITE REG-SAIDA FROM REG-DET */
                _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -1927- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -1938- END-IF. */
            }


            /*" -1939- IF V0PRDVG-ORIG-PRODU EQUAL 'ESPEC' */

            if (V0PRDVG_ORIG_PRODU == "ESPEC")
            {

                /*" -1941- IF V0SUBG-FORMA-FATURA EQUAL '2' NEXT SENTENCE */

                if (V0SUBG_FORMA_FATURA == "2")
                {

                    /*" -1942- ELSE */
                }
                else
                {


                    /*" -1943- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -1944- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -1945- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -1948- MOVE 'ALERTA** ORIG.PROD. ESPEC E FORMA DE FATURA MANUAL' TO REG-SAI-DESCRICAO */
                    _.Move("ALERTA** ORIG.PROD. ESPEC E FORMA DE FATURA MANUAL", REG_DET.REG_SAI_DESCRICAO);

                    /*" -1949- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -1950- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1952- GO TO R1000-90-LEITURA. */

                    R1000_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -1953- IF V0SUBG-TIPO-FATURA EQUAL '2' */

            if (V0SUBG_TIPO_FATURA == "2")
            {

                /*" -1954- IF V0PROP-CODSUBES = 0 */

                if (V0PROP_CODSUBES == 0)
                {

                    /*" -1955- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -1957- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1958- ELSE */
                }

            }
            else
            {


                /*" -1959- IF V0SUBG-TIPO-FATURA EQUAL '1' OR '3' */

                if (V0SUBG_TIPO_FATURA.In("1", "3"))
                {

                    /*" -1961- IF V0PROP-CODSUBES = 0 NEXT SENTENCE */

                    if (V0PROP_CODSUBES == 0)
                    {

                        /*" -1962- ELSE */
                    }
                    else
                    {


                        /*" -1963- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                        _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                        /*" -1964- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                        _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                        /*" -1965- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                        /*" -1967- MOVE 'ALERTA ** TIPO FATURA 1 E 3 SUBG <> 0' TO REG-SAI-DESCRICAO */
                        _.Move("ALERTA ** TIPO FATURA 1 E 3 SUBG <> 0", REG_DET.REG_SAI_DESCRICAO);

                        /*" -1968- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                        _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                        /*" -1969- WRITE REG-SAIDA FROM REG-DET */
                        _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                        ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                        /*" -1970- GO TO R1000-90-LEITURA */

                        R1000_90_LEITURA(); //GOTO
                        return;

                        /*" -1971- ELSE */
                    }

                }
                else
                {


                    /*" -1972- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -1973- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -1974- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -1976- MOVE 'ALERTA ** TIPO DE FATURAMENTO INVALIDO     ' TO REG-SAI-DESCRICAO */
                    _.Move("ALERTA ** TIPO DE FATURAMENTO INVALIDO     ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -1977- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -1978- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -1978- GO TO R1000-90-LEITURA. */

                    R1000_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_LEITURA_RAMO */

            R1000_10_LEITURA_RAMO();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1663- EXEC SQL SELECT OCORR_HISTORICO INTO :HISCOBPR-OCORR-HISTORICO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND DATA_INIVIGENCIA = :HISCOBPR-DATA-INIVIGENCIA END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR_DATA_INIVIGENCIA.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO */
        private void R1000_10_LEITURA_RAMO(bool isPerform = false)
        {
            /*" -1984- MOVE '100A' TO WNR-EXEC-SQL. */
            _.Move("100A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1989- PERFORM R1000_10_LEITURA_RAMO_DB_SELECT_1 */

            R1000_10_LEITURA_RAMO_DB_SELECT_1();

            /*" -1992- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1993- DISPLAY 'APOLICE  ' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE  {V0PROP_NUM_APOLICE}");

                /*" -1994- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -1996- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1998- MOVE 'ERRO NO ACESSO A VIEW V0APOLICE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V0APOLICE", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1999- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2000- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2001- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -2002- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -2003- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -2005- MOVE 'ERRO ** NAO ENCONTRADO NA APOLICES       ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO ENCONTRADO NA APOLICES       ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -2006- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -2007- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -2008- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -2009- ELSE */
                }
                else
                {


                    /*" -2011- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2013- MOVE '100B' TO WNR-EXEC-SQL. */
            _.Move("100B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2019- PERFORM R1000_10_LEITURA_RAMO_DB_SELECT_2 */

            R1000_10_LEITURA_RAMO_DB_SELECT_2();

            /*" -2022- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2023- DISPLAY 'ERRO ACESSO ENDOSSO ' */
                _.Display($"ERRO ACESSO ENDOSSO ");

                /*" -2024- DISPLAY 'APOLICE  ' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE  {V0PROP_NUM_APOLICE}");

                /*" -2025- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2027- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2029- MOVE 'ERRO NO ACESSO A VIEW V0ENDOSSO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V0ENDOSSO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2030- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2031- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2032- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -2033- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -2034- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -2036- MOVE 'ERRO ** NAO ENCONTRADO NA ENDOSSOS       ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO ENCONTRADO NA ENDOSSOS       ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -2037- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -2038- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -2039- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -2040- ELSE */
                }
                else
                {


                    /*" -2042- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2043- IF V0ENDO-DTTERVIG LESS V0PROP-DTPROXVEN */

            if (V0ENDO_DTTERVIG < V0PROP_DTPROXVEN)
            {

                /*" -2045- DISPLAY 'APOLICE COM VIGENCIA EXPIRADA - ' V0PROP-NUM-APOLICE */
                _.Display($"APOLICE COM VIGENCIA EXPIRADA - {V0PROP_NUM_APOLICE}");

                /*" -2046- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2048- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2050- MOVE 'APOLICE COM VIGENCIA EXPIRADA' TO LD-DES-ERRO-SSAIDA */
                _.Move("APOLICE COM VIGENCIA EXPIRADA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2051- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2052- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                /*" -2053- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                /*" -2054- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                /*" -2056- MOVE 'ALERTA ** APOLICE COM VIGENCIA EXPIRADA' TO REG-SAI-DESCRICAO */
                _.Move("ALERTA ** APOLICE COM VIGENCIA EXPIRADA", REG_DET.REG_SAI_DESCRICAO);

                /*" -2057- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                /*" -2058- WRITE REG-SAIDA FROM REG-DET */
                _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -2060- GO TO R1000-90-LEITURA. */

                R1000_90_LEITURA(); //GOTO
                return;
            }


            /*" -2062- MOVE V0PROP-DTQITBCO TO WDATA-PRIMEIRA. */
            _.Move(V0PROP_DTQITBCO, AREA_DE_WORK.WDATA_PRIMEIRA);

            /*" -2064- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2070- PERFORM R1000_10_LEITURA_RAMO_DB_SELECT_3 */

            R1000_10_LEITURA_RAMO_DB_SELECT_3();

            /*" -2073- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -2074- DISPLAY 'R1000-00 (ERRO - SELECT V0CONVENIOSVG)' */
                _.Display($"R1000-00 (ERRO - SELECT V0CONVENIOSVG)");

                /*" -2077- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'APOL...: ' V0PROP-NUM-APOLICE 'SUBGRUP: ' V0PROP-CODSUBES */

                $"CERTIF: {V0PROP_NRCERTIF}  APOL...: {V0PROP_NUM_APOLICE}SUBGRUP: {V0PROP_CODSUBES}"
                .Display();

                /*" -2078- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2079- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2081- MOVE 'ERRO NO ACESSO A VIEW V0CONVENIOSVG' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V0CONVENIOSVG", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2082- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2083- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2085- END-IF. */
            }


            /*" -2086- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -2087- MOVE 9019 TO V0CONV-CCRED */
                _.Move(9019, V0CONV_CCRED);

                /*" -2088- MOVE 6088 TO V0CONV-CODCONV */
                _.Move(6088, V0CONV_CODCONV);

                /*" -2090- END-IF. */
            }


            /*" -2092- MOVE V0PROP-DTPROXVEN TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -2095- MOVE ZEROS TO CONT-ATRASO PROX-PARCELA. */
            _.Move(0, CONT_ATRASO, PROX_PARCELA);

            /*" -2097- MOVE 'N' TO CHAVE-FIM. */
            _.Move("N", CHAVE_FIM);

            /*" -2099- MOVE '1011' TO WNR-EXEC-SQL. */
            _.Move("1011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2106- PERFORM R1000_10_LEITURA_RAMO_DB_DECLARE_1 */

            R1000_10_LEITURA_RAMO_DB_DECLARE_1();

            /*" -2110- PERFORM R1000_10_LEITURA_RAMO_DB_OPEN_1 */

            R1000_10_LEITURA_RAMO_DB_OPEN_1();

            /*" -2113- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2114- DISPLAY 'ERRO OPEN  PARCELA EM ATRASO' V0PROP-NRCERTIF */
                _.Display($"ERRO OPEN  PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                /*" -2115- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2116- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2118- MOVE 'ERRO NO ABERTURA DO CURSOR DE PARCELAS - CATRASO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ABERTURA DO CURSOR DE PARCELAS - CATRASO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2119- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2120- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2122- END-IF. */
            }


            /*" -2125- PERFORM R1000_10_LEITURA_RAMO_DB_FETCH_1 */

            R1000_10_LEITURA_RAMO_DB_FETCH_1();

            /*" -2128- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2129- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2129- PERFORM R1000_10_LEITURA_RAMO_DB_CLOSE_1 */

                    R1000_10_LEITURA_RAMO_DB_CLOSE_1();

                    /*" -2131- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2132- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -2134- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -2136- MOVE 'ERRO NO FECHAMENTO CURSOR PARCELAS - CATRASO' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO NO FECHAMENTO CURSOR PARCELAS - CATRASO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -2137- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -2138- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2139- END-IF */
                    }


                    /*" -2140- MOVE 'S' TO CHAVE-FIM */
                    _.Move("S", CHAVE_FIM);

                    /*" -2141- MOVE ZEROS TO CONT-ATRASO */
                    _.Move(0, CONT_ATRASO);

                    /*" -2142- MOVE ZEROS TO V0PROP-NRPRIPARATZ */
                    _.Move(0, V0PROP_NRPRIPARATZ);

                    /*" -2143- ELSE */
                }
                else
                {


                    /*" -2145- DISPLAY 'ERRO NA BUSCA DA PARCELA EM ATRASO' V0PROP-NRCERTIF */
                    _.Display($"ERRO NA BUSCA DA PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                    /*" -2146- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2148- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2150- MOVE 'ERRO NO FETCH DO CURSOR DE PARCELAS - CATRASO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DE PARCELAS - CATRASO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2151- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2152- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2153- ELSE */
                }

            }
            else
            {


                /*" -2154- MOVE HOST-PARCELA-ATRASO TO V0PROP-NRPRIPARATZ */
                _.Move(HOST_PARCELA_ATRASO, V0PROP_NRPRIPARATZ);

                /*" -2155- ADD 1 TO CONT-ATRASO */
                CONT_ATRASO.Value = CONT_ATRASO + 1;

                /*" -2156- COMPUTE PROX-PARCELA = HOST-PARCELA-ATRASO + 1 */
                PROX_PARCELA.Value = HOST_PARCELA_ATRASO + 1;

                /*" -2158- PERFORM R1010-00-FETCH-PARCELAS-ATRASO. */

                R1010_00_FETCH_PARCELAS_ATRASO_SECTION();
            }


            /*" -2161- PERFORM R1020-00-PROC-PARCELAS-ATRASO UNTIL CHAVE-FIM = 'S' OR CONT-ATRASO > 2. */

            while (!(CHAVE_FIM == "S" || CONT_ATRASO > 2))
            {

                R1020_00_PROC_PARCELAS_ATRASO_SECTION();
            }

            /*" -2163- MOVE CONT-ATRASO TO V0PROP-QTDPARATZ */
            _.Move(CONT_ATRASO, V0PROP_QTDPARATZ);

            /*" -2165- IF CONT-ATRASO > 2 AND CHAVE-FIM = 'N' */

            if (CONT_ATRASO > 2 && CHAVE_FIM == "N")
            {

                /*" -2165- PERFORM R1000_10_LEITURA_RAMO_DB_CLOSE_2 */

                R1000_10_LEITURA_RAMO_DB_CLOSE_2();

                /*" -2167- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2169- DISPLAY 'ERRO NO FECHAMENTO DO CURSOR CATRASO ' V0PROP-NRCERTIF */
                    _.Display($"ERRO NO FECHAMENTO DO CURSOR CATRASO {V0PROP_NRCERTIF}");

                    /*" -2170- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2172- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2174- MOVE 'ERRO FECHAMENTO CURSOR DE PARCELAS - CATRASO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO FECHAMENTO CURSOR DE PARCELAS - CATRASO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2175- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2176- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2177- END-IF */
                }


                /*" -2178- MOVE 'S' TO CHAVE-FIM */
                _.Move("S", CHAVE_FIM);

                /*" -2180- END-IF */
            }


            /*" -2183- MOVE SPACES TO WS-DESPREZA WS-CNTRLE-VING-FAT. */
            _.Move("", WS_DESPREZA, WS_CNTRLE_VING_FAT);

            /*" -2190- PERFORM R1200-00-GERA-PARCELAS UNTIL V0PROP-DTPROXVEN GREATER V1SIST-DT-23-CYRELA OR WS-CNTRLE-VING-FAT EQUAL 'S' OR WS-DESPREZA EQUAL 'S' . */

            while (!(V0PROP_DTPROXVEN > V1SIST_DT_23_CYRELA || WS_CNTRLE_VING_FAT == "S" || WS_DESPREZA == "S"))
            {

                R1200_00_GERA_PARCELAS_SECTION();
            }

            /*" -2191- IF (WS-DESPREZA EQUAL 'S' ) */

            if ((WS_DESPREZA == "S"))
            {

                /*" -2192- GO TO R1000-90-LEITURA */

                R1000_90_LEITURA(); //GOTO
                return;

                /*" -2194- END-IF. */
            }


            /*" -2201- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2203- IF (V0OPCP-OPCAOPAG EQUAL '1' OR '2' ) AND (V0OPCP-PERIPGTO EQUAL 1) */

            if ((V0OPCP_OPCAOPAG.In("1", "2")) && (V0OPCP_PERIPGTO == 1))
            {

                /*" -2207- IF (V0PROP-CODPRODU EQUAL 8203 OR 9311 OR 9354 OR JVPROD(8203) OR JVPROD(9311) ) AND (V0PROP-NUM-APOLICE NOT EQUAL 109300002554) */

                if ((V0PROP_CODPRODU.In("8203", "9311", "9354", JVBKINCL.FILLER.JVPROD[8203].ToString(), JVBKINCL.FILLER.JVPROD[9311].ToString())) && (V0PROP_NUM_APOLICE != 109300002554))
                {

                    /*" -2208- PERFORM R2000-00-RECOMANDAR-DEB-ANT */

                    R2000_00_RECOMANDAR_DEB_ANT_SECTION();

                    /*" -2213- END-IF */
                }


                /*" -2220- IF (V0PROP-CODPRODU EQUAL 8205 OR 8209 OR 9315 OR 9316 OR 9322 OR 9323 OR 9324 OR 9325 OR 9326 OR 9343 OR 9329 OR 9706 OR 9712 OR 9713 OR 9714 OR 9715 OR 9363 OR 9365 OR 8222 OR 8228 OR JVPROD(8205) OR JVPROD(8209) OR JVPROD(9343) OR JVPROD(9329) ) */

                if ((V0PROP_CODPRODU.In("8205", "8209", "9315", "9316", "9322", "9323", "9324", "9325", "9326", "9343", "9329", "9706", "9712", "9713", "9714", "9715", "9363", "9365", "8222", "8228", JVBKINCL.FILLER.JVPROD[8205].ToString(), JVBKINCL.FILLER.JVPROD[8209].ToString(), JVBKINCL.FILLER.JVPROD[9343].ToString(), JVBKINCL.FILLER.JVPROD[9329].ToString())))
                {

                    /*" -2221- PERFORM R2000-00-RECOMANDAR-DEB-ANT */

                    R2000_00_RECOMANDAR_DEB_ANT_SECTION();

                    /*" -2222- END-IF */
                }


                /*" -2225- END-IF */
            }


            /*" -2236- PERFORM R1000_10_LEITURA_RAMO_DB_UPDATE_1 */

            R1000_10_LEITURA_RAMO_DB_UPDATE_1();

            /*" -2239- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2240- DISPLAY 'R1000-00 (ERRO - UPDATE CPROPVA)' */
                _.Display($"R1000-00 (ERRO - UPDATE CPROPVA)");

                /*" -2241- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                /*" -2242- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2243- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2245- MOVE 'ERRO NO UPDATE DA VIEW V0PROPOSTAVA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA VIEW V0PROPOSTAVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2246- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2247- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2247- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-SELECT-1 */
        public void R1000_10_LEITURA_RAMO_DB_SELECT_1()
        {
            /*" -1989- EXEC SQL SELECT RAMO INTO :V0APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_SELECT_1_Query1 = new R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_10_LEITURA_RAMO_DB_SELECT_1_Query1.Execute(r1000_10_LEITURA_RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -1708- EXEC SQL SELECT OCORR_HISTORICO INTO :HISCOBPR-OCORR-HISTORICO FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND OCORR_HISTORICO = :V0PROP-OCORHIST END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR_OCORR_HISTORICO);
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-SELECT-2 */
        public void R1000_10_LEITURA_RAMO_DB_SELECT_2()
        {
            /*" -2019- EXEC SQL SELECT DTTERVIG INTO :V0ENDO-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_SELECT_2_Query1 = new R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1000_10_LEITURA_RAMO_DB_SELECT_2_Query1.Execute(r1000_10_LEITURA_RAMO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-OPEN-1 */
        public void R1000_10_LEITURA_RAMO_DB_OPEN_1()
        {
            /*" -2110- EXEC SQL OPEN CATRASO END-EXEC. */

            CATRASO.Open();

        }

        [StopWatch]
        /*" R1240-00-SELECT-MIGRACAO-DB-DECLARE-1 */
        public void R1240_00_SELECT_MIGRACAO_DB_DECLARE_1()
        {
            /*" -3313- EXEC SQL DECLARE CTERMO CURSOR FOR SELECT B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_TERMO FROM SEGUROS.CLIENTES A, SEGUROS.TERMO_ADESAO B WHERE A.CGCCPF = :CLIENTES-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.NUM_APOLICE IN (97010000889, 109300000672) AND B.SITUACAO = '0' END-EXEC. */
            CTERMO = new VG0853B_CTERMO(true);
            string GetQuery_CTERMO()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_TERMO 
							FROM SEGUROS.CLIENTES A
							, 
							SEGUROS.TERMO_ADESAO B 
							WHERE A.CGCCPF = '{CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}' 
							AND B.COD_CLIENTE = A.COD_CLIENTE 
							AND B.NUM_APOLICE IN (97010000889
							, 
							109300000672) 
							AND B.SITUACAO = '0'";

                return query;
            }
            CTERMO.GetQueryEvent += GetQuery_CTERMO;

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-FETCH-1 */
        public void R1000_10_LEITURA_RAMO_DB_FETCH_1()
        {
            /*" -2125- EXEC SQL FETCH CATRASO INTO :HOST-PARCELA-ATRASO END-EXEC. */

            if (CATRASO.Fetch())
            {
                _.Move(CATRASO.HOST_PARCELA_ATRASO, HOST_PARCELA_ATRASO);
            }

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-CLOSE-1 */
        public void R1000_10_LEITURA_RAMO_DB_CLOSE_1()
        {
            /*" -2129- EXEC SQL CLOSE CATRASO END-EXEC */

            CATRASO.Close();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -2252- IF (WACC-COMMIT GREATER 499) */

            if ((AREA_DE_WORK.WACC_COMMIT > 499))
            {

                /*" -2253- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -2256- STRING WS-TIME(1:2) ':' WS-TIME(3:2) ':' WS-TIME(5:2) DELIMITED BY SIZE INTO WS-TIME-HMS END-STRING */
                #region STRING
                var spl10 = WS_TIME.Substring(1, 2).GetMoveValues();
                spl10 += ":";
                var spl11 = WS_TIME.Substring(3, 2).GetMoveValues();
                spl11 += ":";
                var spl12 = WS_TIME.Substring(5, 2).GetMoveValues();
                var results13 = spl10 + spl11 + spl12;
                _.Move(results13, WS_TIME_HMS);
                #endregion

                /*" -2258- DISPLAY 'REGISTROS PROCESSADOS ......' WACC-LIDOS '  EM  ' WS-TIME-HMS */

                $"REGISTROS PROCESSADOS ......{AREA_DE_WORK.WACC_LIDOS}  EM  {WS_TIME_HMS}"
                .Display();

                /*" -2259- MOVE ZEROES TO WACC-COMMIT */
                _.Move(0, AREA_DE_WORK.WACC_COMMIT);

                /*" -2261- MOVE '105Y' TO WNR-EXEC-SQL */
                _.Move("105Y", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2266- PERFORM R1000_90_LEITURA_DB_UPDATE_1 */

                R1000_90_LEITURA_DB_UPDATE_1();

                /*" -2269- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -2270- DISPLAY 'R0000 - ERRO UPDATE V0BANCO 104' */
                    _.Display($"R0000 - ERRO UPDATE V0BANCO 104");

                    /*" -2271- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2272- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2274- MOVE 'ERRO NO UPDATE DA VIEW V0BANCO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO UPDATE DA VIEW V0BANCO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2275- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2276- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2278- END-IF */
                }


                /*" -2278- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2279- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA-DB-UPDATE-1 */
        public void R1000_90_LEITURA_DB_UPDATE_1()
        {
            /*" -2266- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC */

            var r1000_90_LEITURA_DB_UPDATE_1_Update1 = new R1000_90_LEITURA_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R1000_90_LEITURA_DB_UPDATE_1_Update1.Execute(r1000_90_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-UPDATE-1 */
        public void R1000_10_LEITURA_RAMO_DB_UPDATE_1()
        {
            /*" -2236- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET NRPARCE = :V0PROP-NRPARCEL, SITUACAO = :V0PROP-SITUACAO, DTVENCTO = :V0PROP-DTVENCTO, DTPROXVEN = :V0PROP-DTPROXVEN, NRPRIPARATZ = :V0PROP-NRPRIPARATZ, QTDPARATZ = :V0PROP-QTDPARATZ, OCORHIST = :V0PROP-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE CURRENT OF CPROPVA END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1 = new R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1(CPROPVA)
            {
                V0PROP_NRPRIPARATZ = V0PROP_NRPRIPARATZ.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_SITUACAO = V0PROP_SITUACAO.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                WHOST_MIN_DTPROXVEN = WHOST_MIN_DTPROXVEN.ToString(),
                V1SIST_DT_23_CYRELA = V1SIST_DT_23_CYRELA.ToString(),
                JVPRD8203 = JVBKINCL.JV_PRODUTOS.JVPRD8203.ToString(),
                JVPRD8205 = JVBKINCL.JV_PRODUTOS.JVPRD8205.ToString(),
                JVPRD8206 = JVBKINCL.JV_PRODUTOS.JVPRD8206.ToString(),
                JVPRD8209 = JVBKINCL.JV_PRODUTOS.JVPRD8209.ToString(),
                JVPRD8214 = JVBKINCL.JV_PRODUTOS.JVPRD8214.ToString(),
                JVPRD9311 = JVBKINCL.JV_PRODUTOS.JVPRD9311.ToString(),
                JVPRD9329 = JVBKINCL.JV_PRODUTOS.JVPRD9329.ToString(),
                JVPRD9330 = JVBKINCL.JV_PRODUTOS.JVPRD9330.ToString(),
                JVPRD9343 = JVBKINCL.JV_PRODUTOS.JVPRD9343.ToString(),
            };

            R1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1.Execute(r1000_10_LEITURA_RAMO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-CLOSE-2 */
        public void R1000_10_LEITURA_RAMO_DB_CLOSE_2()
        {
            /*" -2165- EXEC SQL CLOSE CATRASO END-EXEC */

            CATRASO.Close();

        }

        [StopWatch]
        /*" R1000-10-LEITURA-RAMO-DB-SELECT-3 */
        public void R1000_10_LEITURA_RAMO_DB_SELECT_3()
        {
            /*" -2070- EXEC SQL SELECT COD_SEGURO, COD_CONV_CARTAO INTO :V0CONV-CODCONV, :V0CONV-CCRED FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES END-EXEC. */

            var r1000_10_LEITURA_RAMO_DB_SELECT_3_Query1 = new R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_10_LEITURA_RAMO_DB_SELECT_3_Query1.Execute(r1000_10_LEITURA_RAMO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
                _.Move(executed_1.V0CONV_CCRED, V0CONV_CCRED);
            }


        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1757- EXEC SQL SELECT NUM_APOLICE, SIT_REGISTRO, TIPO_FATURAMENTO, FORMA_FATURAMENTO, PERI_FATURAMENTO INTO :V0SUBG-NUM-APOLICE, :V0SUBG-SIT-REGISTRO, :V0SUBG-TIPO-FATURA, :V0SUBG-FORMA-FATURA, :V0SUBG-PERI-FATURA FROM SEGUROS.V0SUBGRUPO WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SUBG_NUM_APOLICE, V0SUBG_NUM_APOLICE);
                _.Move(executed_1.V0SUBG_SIT_REGISTRO, V0SUBG_SIT_REGISTRO);
                _.Move(executed_1.V0SUBG_TIPO_FATURA, V0SUBG_TIPO_FATURA);
                _.Move(executed_1.V0SUBG_FORMA_FATURA, V0SUBG_FORMA_FATURA);
                _.Move(executed_1.V0SUBG_PERI_FATURA, V0SUBG_PERI_FATURA);
            }


        }

        [StopWatch]
        /*" R1000-91-NEXT */
        private void R1000_91_NEXT(bool isPerform = false)
        {
            /*" -2283- PERFORM R0910-00-FETCH-CPROPVA. */

            R0910_00_FETCH_CPROPVA_SECTION();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1773- EXEC SQL SELECT ORIG_PRODU INTO :V0PRDVG-ORIG-PRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRDVG_ORIG_PRODU, V0PRDVG_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-SELECT-5 */
        public void R1000_00_PROCESSA_REGISTRO_DB_SELECT_5()
        {
            /*" -1830- EXEC SQL SELECT ESTR_COBR, ORIG_PRODU, TEM_SAF, TEM_IGPM, CODPRODAZ, OPCAOCAP, COBERADIC_PREMIO, CUSTOCAP_TOTAL, NOMPRODU INTO :V0PRDVG-ESTR-COBR:VIND-ESTR-COBR, :V0PRDVG-ORIG-PRODU:VIND-ORIG-PRODU, :V0PRDVG-TEM-SAF:VIND-TEM-SAF, :V0PRDVG-TEM-IGPM:VIND-TEM-IGPM, :V0PRDVG-CODPRODAZ, :V0PRDVG-OPCAOCAP, :V0PRDVG-COBERADIC-PREMIO, :V0PRDVG-CUSTOCAP-TOTAL, :V0PRDVG-NOMPRODU FROM SEGUROS.V0PRODUTOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES END-EXEC. */

            var r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1 = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1.Execute(r1000_00_PROCESSA_REGISTRO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRDVG_ESTR_COBR, V0PRDVG_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.V0PRDVG_ORIG_PRODU, V0PRDVG_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
                _.Move(executed_1.V0PRDVG_TEM_SAF, V0PRDVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PRDVG_TEM_IGPM, V0PRDVG_TEM_IGPM);
                _.Move(executed_1.VIND_TEM_IGPM, VIND_TEM_IGPM);
                _.Move(executed_1.V0PRDVG_CODPRODAZ, V0PRDVG_CODPRODAZ);
                _.Move(executed_1.V0PRDVG_OPCAOCAP, V0PRDVG_OPCAOCAP);
                _.Move(executed_1.V0PRDVG_COBERADIC_PREMIO, V0PRDVG_COBERADIC_PREMIO);
                _.Move(executed_1.V0PRDVG_CUSTOCAP_TOTAL, V0PRDVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.V0PRDVG_NOMPRODU, V0PRDVG_NOMPRODU);
            }


        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-ATRASO-SECTION */
        private void R1010_00_FETCH_PARCELAS_ATRASO_SECTION()
        {
            /*" -2294- MOVE '101X' TO WNR-EXEC-SQL. */
            _.Move("101X", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2298- PERFORM R1010_00_FETCH_PARCELAS_ATRASO_DB_FETCH_1 */

            R1010_00_FETCH_PARCELAS_ATRASO_DB_FETCH_1();

            /*" -2301- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2302- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2302- PERFORM R1010_00_FETCH_PARCELAS_ATRASO_DB_CLOSE_1 */

                    R1010_00_FETCH_PARCELAS_ATRASO_DB_CLOSE_1();

                    /*" -2304- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2305- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -2307- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -2309- MOVE 'ERRO FECHAMENTO NO CURSOR DE PARCEL - CATRASO' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO FECHAMENTO NO CURSOR DE PARCEL - CATRASO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -2310- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -2311- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2312- END-IF */
                    }


                    /*" -2313- MOVE 'S' TO CHAVE-FIM */
                    _.Move("S", CHAVE_FIM);

                    /*" -2314- GO TO R1010-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/ //GOTO
                    return;

                    /*" -2315- ELSE */
                }
                else
                {


                    /*" -2317- DISPLAY 'ERRO NA BUSCA DA PARCELA EM ATRASO' V0PROP-NRCERTIF */
                    _.Display($"ERRO NA BUSCA DA PARCELA EM ATRASO{V0PROP_NRCERTIF}");

                    /*" -2318- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2320- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2322- MOVE 'ERRO NO FETCH DO CURSOR DE PARCELAS - CATRASO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR DE PARCELAS - CATRASO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2323- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2323- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-ATRASO-DB-FETCH-1 */
        public void R1010_00_FETCH_PARCELAS_ATRASO_DB_FETCH_1()
        {
            /*" -2298- EXEC SQL FETCH CATRASO INTO :HOST-PARCELA-ATRASO END-EXEC. */

            if (CATRASO.Fetch())
            {
                _.Move(CATRASO.HOST_PARCELA_ATRASO, HOST_PARCELA_ATRASO);
            }

        }

        [StopWatch]
        /*" R1010-00-FETCH-PARCELAS-ATRASO-DB-CLOSE-1 */
        public void R1010_00_FETCH_PARCELAS_ATRASO_DB_CLOSE_1()
        {
            /*" -2302- EXEC SQL CLOSE CATRASO END-EXEC */

            CATRASO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-PROC-PARCELAS-ATRASO-SECTION */
        private void R1020_00_PROC_PARCELAS_ATRASO_SECTION()
        {
            /*" -2334- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2335- IF HOST-PARCELA-ATRASO EQUAL PROX-PARCELA */

            if (HOST_PARCELA_ATRASO == PROX_PARCELA)
            {

                /*" -2336- ADD 1 TO CONT-ATRASO */
                CONT_ATRASO.Value = CONT_ATRASO + 1;

                /*" -2337- COMPUTE PROX-PARCELA = HOST-PARCELA-ATRASO + 1 */
                PROX_PARCELA.Value = HOST_PARCELA_ATRASO + 1;

                /*" -2338- ELSE */
            }
            else
            {


                /*" -2339- MOVE 1 TO CONT-ATRASO */
                _.Move(1, CONT_ATRASO);

                /*" -2340- MOVE HOST-PARCELA-ATRASO TO V0PROP-NRPRIPARATZ */
                _.Move(HOST_PARCELA_ATRASO, V0PROP_NRPRIPARATZ);

                /*" -2342- COMPUTE PROX-PARCELA = HOST-PARCELA-ATRASO + 1. */
                PROX_PARCELA.Value = HOST_PARCELA_ATRASO + 1;
            }


            /*" -2343- PERFORM R1010-00-FETCH-PARCELAS-ATRASO. */

            R1010_00_FETCH_PARCELAS_ATRASO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-LE-OPCAOPAG-SECTION */
        private void R1100_00_LE_OPCAOPAG_SECTION()
        {
            /*" -2350- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2352- MOVE 'S' TO N88-VERIFICA-OPCAOPAG */
            _.Move("S", AREA_DE_WORK.N88_VERIFICA_OPCAOPAG);

            /*" -2375- PERFORM R1100_00_LE_OPCAOPAG_DB_SELECT_1 */

            R1100_00_LE_OPCAOPAG_DB_SELECT_1();

            /*" -2378- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2379- DISPLAY 'R1100-00 (ERRO - SELECT V0OPCAOPAGVA)' */
                _.Display($"R1100-00 (ERRO - SELECT V0OPCAOPAGVA)");

                /*" -2381- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-DTPROXVEN */

                $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_DTPROXVEN}"
                .Display();

                /*" -2382- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2383- MOVE 'N' TO N88-VERIFICA-OPCAOPAG */
                    _.Move("N", AREA_DE_WORK.N88_VERIFICA_OPCAOPAG);

                    /*" -2384- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2386- MOVE 'OPCAO DE PAGAMENTO NAO ENCONTRADA' TO LD-DES-ERRO-DSAIDA */
                    _.Move("OPCAO DE PAGAMENTO NAO ENCONTRADA", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                    /*" -2387- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2388- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -2389- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -2390- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -2392- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -2394- MOVE 'ERRO ** NAO ENCONTRADO NA OPCPAGVI       ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO ENCONTRADO NA OPCPAGVI       ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -2395- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -2396- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -2397- GO TO R1100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                    return;

                    /*" -2398- ELSE */
                }
                else
                {


                    /*" -2399- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2401- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2403- MOVE 'ERRO NO ACESSO A VIEW V0OPCAOPAGVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A VIEW V0OPCAOPAGVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2404- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2406- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2407- IF V0OPCP-OPCAOPAG = '5' */

            if (V0OPCP_OPCAOPAG == "5")
            {

                /*" -2409- IF V0OPCP-VINDCCRE < ZEROS OR V0OPCP-CARTAO-CRED NOT NUMERIC */

                if (V0OPCP_VINDCCRE < 00 || !V0OPCP_CARTAO_CRED.IsNumeric())
                {

                    /*" -2410- MOVE ZEROS TO V0OPCP-CARTAO-CRED */
                    _.Move(0, V0OPCP_CARTAO_CRED);

                    /*" -2411- END-IF */
                }


                /*" -2411- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-LE-OPCAOPAG-DB-SELECT-1 */
        public void R1100_00_LE_OPCAOPAG_DB_SELECT_1()
        {
            /*" -2375- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO INTO :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIA-DEBITO, :V0OPCP-AGECTADEB:V0OPCP-INDAGE, :V0OPCP-OPRCTADEB:V0OPCP-INDOPR, :V0OPCP-NUMCTADEB:V0OPCP-INDNUM, :V0OPCP-DIGCTADEB:V0OPCP-INDDIG, :V0OPCP-CARTAO-CRED:V0OPCP-VINDCCRE FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN END-EXEC. */

            var r1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1 = new R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1.Execute(r1100_00_LE_OPCAOPAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_DIA_DEBITO, V0OPCP_DIA_DEBITO);
                _.Move(executed_1.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_INDAGE, V0OPCP_INDAGE);
                _.Move(executed_1.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_INDOPR, V0OPCP_INDOPR);
                _.Move(executed_1.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_INDNUM, V0OPCP_INDNUM);
                _.Move(executed_1.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0OPCP_INDDIG, V0OPCP_INDDIG);
                _.Move(executed_1.V0OPCP_CARTAO_CRED, V0OPCP_CARTAO_CRED);
                _.Move(executed_1.V0OPCP_VINDCCRE, V0OPCP_VINDCCRE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-SECTION */
        private void R1200_00_GERA_PARCELAS_SECTION()
        {
            /*" -2428- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2429- IF (WHOST-CNTRLE-MNL EQUAL 1) */

            if ((WHOST_CNTRLE_MNL == 1))
            {

                /*" -2431- MOVE V0PROP-DTVENCTO(9:2) TO VG083-DTA-INI-FATURA(9:2) */
                _.MoveAtPosition(V0PROP_DTVENCTO.Substring(9, 2), VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA, 9, 2);

                /*" -2432- IF (V0PROP-DTVENCTO > VG083-DTA-INI-FATURA) */

                if ((V0PROP_DTVENCTO > VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA))
                {

                    /*" -2433- MOVE 'S' TO WS-CNTRLE-VING-FAT */
                    _.Move("S", WS_CNTRLE_VING_FAT);

                    /*" -2434- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2435- END-IF */
                }


                /*" -2442- END-IF. */
            }


            /*" -2445- IF V0PRDVG-ORIG-PRODU EQUAL 'EMPRE' OR V0PRDVG-ORIG-PRODU EQUAL 'GLOBAL' */

            if (V0PRDVG_ORIG_PRODU == "EMPRE" || V0PRDVG_ORIG_PRODU == "GLOBAL")
            {

                /*" -2447- MOVE SPACE TO V0HCTA-SITUACAO */
                _.Move("", V0HCTA_SITUACAO);

                /*" -2449- PERFORM R1260-00-CONSULTA-SITUACAO */

                R1260_00_CONSULTA_SITUACAO_SECTION();

                /*" -2452- IF V0HCTA-SITUACAO EQUAL '3' OR V0HCTA-SITUACAO EQUAL 'A' */

                if (V0HCTA_SITUACAO == "3" || V0HCTA_SITUACAO == "A")
                {

                    /*" -2455- DISPLAY 'CERT. ' V0PROP-NRCERTIF ' - PARCELA ' V0PROP-NRPARCEL ' SEM RETORNO.' */

                    $"CERT. {V0PROP_NRCERTIF} - PARCELA {V0PROP_NRPARCEL} SEM RETORNO."
                    .Display();

                    /*" -2456- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2458- MOVE 'POSSUI PARCELA SEM RETORNO COBRANCA SICOV' TO LD-DES-ERRO-DSAIDA */
                    _.Move("POSSUI PARCELA SEM RETORNO COBRANCA SICOV", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                    /*" -2460- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2461- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -2462- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2464- END-IF */
                }


                /*" -2471- END-IF. */
            }


            /*" -2472- IF (V0PRDVG-ORIG-PRODU = 'ESPEC' ) */

            if ((V0PRDVG_ORIG_PRODU == "ESPEC"))
            {

                /*" -2473- IF (V0OPCP-PERIPGTO EQUAL 1) */

                if ((V0OPCP_PERIPGTO == 1))
                {

                    /*" -2474- COMPUTE WS-NUM-PARCELA = V0PROP-NRPARCEL - 2 */
                    WS_NUM_PARCELA.Value = V0PROP_NRPARCEL - 2;

                    /*" -2475- ELSE */
                }
                else
                {


                    /*" -2476- MOVE V0PROP-NRPARCEL TO WS-NUM-PARCELA */
                    _.Move(V0PROP_NRPARCEL, WS_NUM_PARCELA);

                    /*" -2478- END-IF */
                }


                /*" -2486- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_1 */

                R1200_00_GERA_PARCELAS_DB_SELECT_1();

                /*" -2489- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

                if ((!DB.SQLCODE.In("00", "+100")))
                {

                    /*" -2490- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2491- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2493- MOVE 'ERRO AO CONTAR PARCELA EM ATRASO ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO AO CONTAR PARCELA EM ATRASO ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2494- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2495- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2497- END-IF */
                }


                /*" -2499- IF ((WS-CONT-PARC-AT > 2) AND (V0OPCP-PERIPGTO = 1)) OR ((WS-CONT-PARC-AT > 0) AND (V0OPCP-PERIPGTO > 1)) */

                if (((WS_CONT_PARC_AT > 2) && (V0OPCP_PERIPGTO == 1)) || ((WS_CONT_PARC_AT > 0) && (V0OPCP_PERIPGTO > 1)))
                {

                    /*" -2502- DISPLAY 'CERTIF. COM PARC. ATRASO - NAO GERADA ' V0PROP-NRCERTIF ' ' WS-NUM-PARCELA ' ' V1SIST-DTMOVABE ' ' WS-CONT-PARC-AT */

                    $"CERTIF. COM PARC. ATRASO - NAO GERADA {V0PROP_NRCERTIF} {WS_NUM_PARCELA} {V1SIST_DTMOVABE} {WS_CONT_PARC_AT}"
                    .Display();

                    /*" -2503- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -2504- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2505- END-IF */
                }


                /*" -2508- END-IF. */
            }


            /*" -2509- IF (V0OPCP-PERIPGTO NOT EQUAL V0SUBG-PERI-FATURA) */

            if ((V0OPCP_PERIPGTO != V0SUBG_PERI_FATURA))
            {

                /*" -2513- DISPLAY 'DIVERGENCIA NO PERIODO DE PAGAMENTO ' ' ' V0PROP-NRCERTIF ' ' V0OPCP-PERIPGTO ' ' V0SUBG-PERI-FATURA */

                $"DIVERGENCIA NO PERIODO DE PAGAMENTO  {V0PROP_NRCERTIF} {V0OPCP_PERIPGTO} {V0SUBG_PERI_FATURA}"
                .Display();

                /*" -2514- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2515- MOVE 'DIVERGENCIA PERIODO DE PAGTO' TO LD-DES-ERRO-DSAIDA */
                _.Move("DIVERGENCIA PERIODO DE PAGTO", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                /*" -2516- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2517- MOVE 'S' TO WS-DESPREZA */
                _.Move("S", WS_DESPREZA);

                /*" -2518- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                /*" -2519- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                /*" -2520- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                /*" -2522- MOVE 'ALERTA ** PERIPGTO <> DA SUBGVGAP          ' TO REG-SAI-DESCRICAO */
                _.Move("ALERTA ** PERIPGTO <> DA SUBGVGAP          ", REG_DET.REG_SAI_DESCRICAO);

                /*" -2523- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                /*" -2524- WRITE REG-SAIDA FROM REG-DET */
                _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -2525- GO TO R1200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;

                /*" -2527- END-IF. */
            }


            /*" -2528- IF (V0OPCP-OPCAOPAG EQUAL '1' OR '2' ) */

            if ((V0OPCP_OPCAOPAG.In("1", "2")))
            {

                /*" -2529- MOVE ZEROS TO V0OPCP-CARTAO-CRED */
                _.Move(0, V0OPCP_CARTAO_CRED);

                /*" -2533- IF V0OPCP-INDAGE LESS ZEROES OR V0OPCP-INDOPR LESS ZEROES OR V0OPCP-INDNUM LESS ZEROES OR V0OPCP-INDDIG LESS ZEROES */

                if (V0OPCP_INDAGE < 00 || V0OPCP_INDOPR < 00 || V0OPCP_INDNUM < 00 || V0OPCP_INDDIG < 00)
                {

                    /*" -2535- DISPLAY 'SEGURADO NAO TEM CONTA PARA DEBITAR ' V0PROP-NRCERTIF */
                    _.Display($"SEGURADO NAO TEM CONTA PARA DEBITAR {V0PROP_NRCERTIF}");

                    /*" -2536- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2538- MOVE 'SEGURADO SEM CONTA PARA DEBITO' TO LD-DES-ERRO-DSAIDA */
                    _.Move("SEGURADO SEM CONTA PARA DEBITO", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                    /*" -2539- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2540- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -2541- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -2542- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -2543- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -2545- MOVE 'ALERTA ** OPCAOPAG IGUAL A 1 OU 2 E CTA ZERADA' TO REG-SAI-DESCRICAO */
                    _.Move("ALERTA ** OPCAOPAG IGUAL A 1 OU 2 E CTA ZERADA", REG_DET.REG_SAI_DESCRICAO);

                    /*" -2546- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -2547- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -2548- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2549- END-IF */
                }


                /*" -2550- END-IF. */
            }


            /*" -2552- IF (V0OPCP-OPCAOPAG EQUAL '5' ) */

            if ((V0OPCP_OPCAOPAG == "5"))
            {

                /*" -2553- IF (V0OPCP-CARTAO-CRED = ZEROS) */

                if ((V0OPCP_CARTAO_CRED == 00))
                {

                    /*" -2555- DISPLAY 'SEGURADO NAO TEM CARTAO PARA DEBITAR ' V0PROP-NRCERTIF */
                    _.Display($"SEGURADO NAO TEM CARTAO PARA DEBITAR {V0PROP_NRCERTIF}");

                    /*" -2556- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2558- MOVE 'SEGURADO SEM CARTAO PARA DEBITO' TO LD-DES-ERRO-DSAIDA */
                    _.Move("SEGURADO SEM CARTAO PARA DEBITO", AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

                    /*" -2559- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2560- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -2561- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -2562- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -2563- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -2565- MOVE 'ALERTA ** OPCAOPAG IGUAL A 5 E CARTAO ZERADO  ' TO REG-SAI-DESCRICAO */
                    _.Move("ALERTA ** OPCAOPAG IGUAL A 5 E CARTAO ZERADO  ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -2566- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -2567- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -2568- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2569- ELSE */
                }
                else
                {


                    /*" -2573- MOVE ZEROS TO V0OPCP-AGECTADEB V0OPCP-OPRCTADEB V0OPCP-NUMCTADEB V0OPCP-DIGCTADEB */
                    _.Move(0, V0OPCP_AGECTADEB, V0OPCP_OPRCTADEB, V0OPCP_NUMCTADEB, V0OPCP_DIGCTADEB);

                    /*" -2574- END-IF */
                }


                /*" -2576- END-IF. */
            }


            /*" -2577- IF (V0PROP-DTVENCTO GREATER V0PROP-DTPROXVEN) */

            if ((V0PROP_DTVENCTO > V0PROP_DTPROXVEN))
            {

                /*" -2578- MOVE '1ABC' TO WNR-EXEC-SQL */
                _.Move("1ABC", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2585- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_2 */

                R1200_00_GERA_PARCELAS_DB_SELECT_2();

                /*" -2588- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -2589- MOVE V0HICB-DTVENCTO TO V0PROP-DTVENCTO */
                    _.Move(V0HICB_DTVENCTO, V0PROP_DTVENCTO);

                    /*" -2590- ELSE */
                }
                else
                {


                    /*" -2592- DISPLAY ' ERRO ACESSO PARCELA CORRENTE - PARCELVA  ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL ' ' SQLCODE */

                    $" ERRO ACESSO PARCELA CORRENTE - PARCELVA  {V0PROP_NRCERTIF} {V0PROP_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -2593- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2595- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2597- MOVE 'ERRO ACESSO A VIEW V0PARCELVA - PARC CORRENTE' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO ACESSO A VIEW V0PARCELVA - PARC CORRENTE", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2598- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2599- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2600- MOVE 'S' TO WS-DESPREZA */
                        _.Move("S", WS_DESPREZA);

                        /*" -2601- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                        _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                        /*" -2602- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                        _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                        /*" -2603- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                        /*" -2605- MOVE 'ERRO ** NAO CADASTRADO NA PARCEVID     ' TO REG-SAI-DESCRICAO */
                        _.Move("ERRO ** NAO CADASTRADO NA PARCEVID     ", REG_DET.REG_SAI_DESCRICAO);

                        /*" -2606- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                        _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                        /*" -2607- WRITE REG-SAIDA FROM REG-DET */
                        _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                        ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                        /*" -2608- GO TO R1200-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                        return;

                        /*" -2609- ELSE */
                    }
                    else
                    {


                        /*" -2610- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2611- END-IF */
                    }


                    /*" -2612- END-IF */
                }


                /*" -2614- END-IF. */
            }


            /*" -2616- MOVE V0PROP-DTVENCTO TO WDATA-VIGENCIA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_VIGENCIA);

            /*" -2618- COMPUTE WDATA-VIG-MES = WDATA-VIG-MES + V0OPCP-PERIPGTO. */
            AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES + V0OPCP_PERIPGTO;

            /*" -2619- IF (WDATA-VIG-MES > 12) */

            if ((AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES > 12))
            {

                /*" -2620- COMPUTE WDATA-VIG-MES = WDATA-VIG-MES - 12 */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES - 12;

                /*" -2621- COMPUTE WDATA-VIG-ANO = WDATA-VIG-ANO + 1 */
                AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO.Value = AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_ANO + 1;

                /*" -2623- END-IF. */
            }


            /*" -2624- MOVE WDATA-VIGENCIA TO WDATA-VIGENCIA1. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA, AREA_DE_WORK.WDATA_VIGENCIA1);

            /*" -2626- MOVE V0OPCP-DIA-DEBITO TO WDATA-VIG-DIA1. */
            _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_VIGENCIA1.WDATA_VIG_DIA1);

            /*" -2627- IF (V0OPCP-DIA-DEBITO NOT LESS 31) */

            if ((V0OPCP_DIA_DEBITO >= 31))
            {

                /*" -2628- MOVE TAB-DIA-MES(WDATA-VIG-MES) TO WDATA-VIG-DIA */
                _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES].TAB_DIA_MES, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -2629- ELSE */
            }
            else
            {


                /*" -2630- MOVE V0OPCP-DIA-DEBITO TO WDATA-VIG-DIA */
                _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                /*" -2632- END-IF. */
            }


            /*" -2633- IF (V0OPCP-DIA-DEBITO NOT LESS 29) */

            if ((V0OPCP_DIA_DEBITO >= 29))
            {

                /*" -2634- IF (WDATA-VIG-MES EQUAL 02) */

                if ((AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_MES == 02))
                {

                    /*" -2635- MOVE 28 TO WDATA-VIG-DIA */
                    _.Move(28, AREA_DE_WORK.WDATA_VIGENCIA.WDATA_VIG_DIA);

                    /*" -2636- END-IF */
                }


                /*" -2638- END-IF. */
            }


            /*" -2641- MOVE WDATA-VIGENCIA TO V0COBP-DTINIVIG V0PROP-DTPROXVEN W02DTSQL. */
            _.Move(AREA_DE_WORK.WDATA_VIGENCIA, V0COBP_DTINIVIG, V0PROP_DTPROXVEN, AREA_DE_WORK.W02DTSQL);

            /*" -2642- MOVE 01 TO W02DDSQL. */
            _.Move(01, AREA_DE_WORK.W02DTSQL.W02DDSQL);

            /*" -2648- MOVE W02DTSQL TO WHOST-DTINIVIG-PARC. */
            _.Move(AREA_DE_WORK.W02DTSQL, WHOST_DTINIVIG_PARC);

            /*" -2656- IF WS-DESPREZA EQUAL 'S' */

            if (WS_DESPREZA == "S")
            {

                /*" -2657- GO TO R1200-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;

                /*" -2659- END-IF. */
            }


            /*" -2661- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2682- PERFORM R1200_00_GERA_PARCELAS_DB_SELECT_3 */

            R1200_00_GERA_PARCELAS_DB_SELECT_3();

            /*" -2685- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2686- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -2687- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2689- MOVE 'CERTIFICADO SEM COBERTURA PARA A PARCELA' TO LD-DES-ERRO-SSAIDA */
                _.Move("CERTIFICADO SEM COBERTURA PARA A PARCELA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2691- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -2692- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -2693- DISPLAY 'R1200-00-AUSENCIA DE COBERTURA P/ PARCELA ' */
                    _.Display($"R1200-00-AUSENCIA DE COBERTURA P/ PARCELA ");

                    /*" -2695- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW */

                    $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW}"
                    .Display();

                    /*" -2696- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -2697- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -2698- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -2700- MOVE 'ERRO ** NAO CADASTRADO NA HISCOBPR          ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO CADASTRADO NA HISCOBPR          ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -2701- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -2702- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -2703- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -2704- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -2705- ELSE */
                }
                else
                {


                    /*" -2706- IF (SQLCODE EQUAL -811) */

                    if ((DB.SQLCODE == -811))
                    {

                        /*" -2707- DISPLAY 'R1200-00-DUPLICIDADE COBERTURA P/ PARCELA ' */
                        _.Display($"R1200-00-DUPLICIDADE COBERTURA P/ PARCELA ");

                        /*" -2710- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW ' ' V0PROP-DTPROXVEN */

                        $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW} {V0PROP_DTPROXVEN}"
                        .Display();

                        /*" -2711- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                        _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                        /*" -2712- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                        _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                        /*" -2713- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                        /*" -2715- MOVE 'ERRO ** DUPLICADO NA HISCOBPR               ' TO REG-SAI-DESCRICAO */
                        _.Move("ERRO ** DUPLICADO NA HISCOBPR               ", REG_DET.REG_SAI_DESCRICAO);

                        /*" -2716- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                        _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                        /*" -2717- WRITE REG-SAIDA FROM REG-DET */
                        _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                        ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                        /*" -2718- MOVE 'S' TO WS-DESPREZA */
                        _.Move("S", WS_DESPREZA);

                        /*" -2719- GO TO R1200-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                        return;

                        /*" -2720- ELSE */
                    }
                    else
                    {


                        /*" -2721- DISPLAY 'R1200-00 (ERRO - SELECT V0COBERPROPVA)' */
                        _.Display($"R1200-00 (ERRO - SELECT V0COBERPROPVA)");

                        /*" -2724- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW ' ' V0PROP-DTPROXVEN */

                        $"CERTIF: {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW} {V0PROP_DTPROXVEN}"
                        .Display();

                        /*" -2725- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2726- END-IF */
                    }


                    /*" -2727- END-IF */
                }


                /*" -2727- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1200_10_GERA_PARCELAS */

            R1200_10_GERA_PARCELAS();

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-1 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_1()
        {
            /*" -2486- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-CONT-PARC-AT FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND NUM_PARCELA >= :WS-NUM-PARCELA AND DATA_VENCIMENTO <= :V1SIST-DTMOVABE AND SIT_REGISTRO IN ( ' ' , '0' ) END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                WS_NUM_PARCELA = WS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONT_PARC_AT, WS_CONT_PARC_AT);
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS */
        private void R1200_10_GERA_PARCELAS(bool isPerform = false)
        {
            /*" -2733- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2739- PERFORM R1200_10_GERA_PARCELAS_DB_SELECT_1 */

            R1200_10_GERA_PARCELAS_DB_SELECT_1();

            /*" -2742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2743- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2744- IF V0PROP-NRPARCEL = 0 */

                    if (V0PROP_NRPARCEL == 0)
                    {

                        /*" -2745- MOVE ZEROS TO V0PARC-PRMTOTANT */
                        _.Move(0, V0PARC_PRMTOTANT);

                        /*" -2746- ELSE */
                    }
                    else
                    {


                        /*" -2747- IF V0PROP-NRPARCEL > 0 */

                        if (V0PROP_NRPARCEL > 0)
                        {

                            /*" -2748- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL - 1 */
                            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL - 1;

                            /*" -2749- GO TO R1200-10-GERA-PARCELAS */
                            new Task(() => R1200_10_GERA_PARCELAS()).RunSynchronously(); //GOTO
                            return;//Recursividade detectada, cuidado...

                            /*" -2750- ELSE */
                        }
                        else
                        {


                            /*" -2751- DISPLAY 'R1200-00 (ERRO - SELECT V0PARCELVA)' */
                            _.Display($"R1200-00 (ERRO - SELECT V0PARCELVA)");

                            /*" -2753- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                            $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                            .Display();

                            /*" -2754- MOVE '9999-12-31' TO V0PROP-DTPROXVEN */
                            _.Move("9999-12-31", V0PROP_DTPROXVEN);

                            /*" -2755- GO TO R1200-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                            return;

                            /*" -2756- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -2757- DISPLAY 'R1200-00 (ERRO - SELECT V0PARCELVA)' */
                    _.Display($"R1200-00 (ERRO - SELECT V0PARCELVA)");

                    /*" -2759- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL */

                    $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL}"
                    .Display();

                    /*" -2760- MOVE '9999-12-31' TO V0PROP-DTPROXVEN */
                    _.Move("9999-12-31", V0PROP_DTPROXVEN);

                    /*" -2762- GO TO R1200-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2763- MOVE V0PROP-NRPARCEL TO V0RELA-NRPARCEL. */
            _.Move(V0PROP_NRPARCEL, V0RELA_NRPARCEL);

            /*" -2765- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL + 1. */
            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL + 1;

            /*" -2771- MOVE ZEROS TO DESCON-PRMVG DESCON-PRMAP. */
            _.Move(0, DESCON_PRMVG, DESCON_PRMAP);

            /*" -2773- MOVE '1290' TO WNR-EXEC-SQL. */
            _.Move("1290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2775- MOVE 'N' TO WS-DESCONTO */
            _.Move("N", WS_DESCONTO);

            /*" -2786- PERFORM R1200_10_GERA_PARCELAS_DB_SELECT_2 */

            R1200_10_GERA_PARCELAS_DB_SELECT_2();

            /*" -2789- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2790- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2791- MOVE 0,00 TO DESCON-PERC */
                    _.Move(0.00, DESCON_PERC);

                    /*" -2792- ELSE */
                }
                else
                {


                    /*" -2793- DISPLAY 'R1200-00 (ERRO - SELECT VG_PARCELAS_DESCON)' */
                    _.Display($"R1200-00 (ERRO - SELECT VG_PARCELAS_DESCON)");

                    /*" -2797- DISPLAY 'APOL  : ' V0PROP-NUM-APOLICE ' ' V0PROP-CODSUBES ' ' V0PROP-NRPARCEL ' ' V0PROP-DTADMISSAO */

                    $"APOL  : {V0PROP_NUM_APOLICE} {V0PROP_CODSUBES} {V0PROP_NRPARCEL} {V0PROP_DTADMISSAO}"
                    .Display();

                    /*" -2798- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2800- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2802- MOVE 'ERRO NO ACESSO A TABELA VG_PARCELAS_DESCON' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A TABELA VG_PARCELAS_DESCON", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2803- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2804- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2805- ELSE */
                }

            }
            else
            {


                /*" -2807- IF DESCON-PERC GREATER ZEROS */

                if (DESCON_PERC > 00)
                {

                    /*" -2809- MOVE 'S' TO WS-DESCONTO */
                    _.Move("S", WS_DESCONTO);

                    /*" -2810- COMPUTE DESCON-PRMVG = V0COBP-PRMVG * DESCON-PERC */
                    DESCON_PRMVG.Value = V0COBP_PRMVG * DESCON_PERC;

                    /*" -2812- COMPUTE DESCON-PRMAP = V0COBP-PRMAP * DESCON-PERC */
                    DESCON_PRMAP.Value = V0COBP_PRMAP * DESCON_PERC;

                    /*" -2814- IF DESCON-PRMVG GREATER ZEROS OR DESCON-PRMAP GREATER ZEROS */

                    if (DESCON_PRMVG > 00 || DESCON_PRMAP > 00)
                    {

                        /*" -2816- MOVE '1291' TO WNR-EXEC-SQL */
                        _.Move("1291", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -2831- PERFORM R1200_10_GERA_PARCELAS_DB_INSERT_1 */

                        R1200_10_GERA_PARCELAS_DB_INSERT_1();

                        /*" -2834- IF SQLCODE NOT EQUAL ZEROS */

                        if (DB.SQLCODE != 00)
                        {

                            /*" -2835- DISPLAY 'R1200-00 (ERRO - INSERT V0DIFPARCELVA)' */
                            _.Display($"R1200-00 (ERRO - INSERT V0DIFPARCELVA)");

                            /*" -2836- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                            _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                            /*" -2837- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                            _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                            /*" -2838- PERFORM R1800-00-LIMPA-REGISTROS */

                            R1800_00_LIMPA_REGISTROS_SECTION();

                            /*" -2840- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                            _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                            /*" -2842- MOVE 'ERRO NO INSERT DA VIEW V0DIFPARCELVA' TO LD-DES-ERRO-SSAIDA */
                            _.Move("ERRO NO INSERT DA VIEW V0DIFPARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                            /*" -2843- PERFORM R1850-00-GRAVA-REGISTROS */

                            R1850_00_GRAVA_REGISTROS_SECTION();

                            /*" -2845- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -2847- MOVE V0PROP-DTPROXVEN TO V0PROP-DTVENCTO. */
            _.Move(V0PROP_DTPROXVEN, V0PROP_DTVENCTO);

            /*" -2848- IF (V0OPCP-OPCAOPAG = '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -2849- MOVE 0 TO V0PARC-OCORHIST */
                _.Move(0, V0PARC_OCORHIST);

                /*" -2850- ELSE */
            }
            else
            {


                /*" -2851- MOVE 1 TO V0PARC-OCORHIST */
                _.Move(1, V0PARC_OCORHIST);

                /*" -2853- END-IF. */
            }


            /*" -2855- PERFORM R1500-00-TRATA-V0DIFPARCELVA. */

            R1500_00_TRATA_V0DIFPARCELVA_SECTION();

            /*" -2857- IF WS-DESCONTO EQUAL 'S' */

            if (WS_DESCONTO == "S")
            {

                /*" -2859- MOVE '122-A' TO WNR-EXEC-SQL */
                _.Move("122-A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2861- MOVE 'N' TO WS-DESCONTO */
                _.Move("N", WS_DESCONTO);

                /*" -2866- PERFORM R1200_10_GERA_PARCELAS_DB_UPDATE_1 */

                R1200_10_GERA_PARCELAS_DB_UPDATE_1();

                /*" -2869- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2870- DISPLAY 'R122A-00 (ERRO - UPDATE V0DIFPARCELVA)' */
                    _.Display($"R122A-00 (ERRO - UPDATE V0DIFPARCELVA)");

                    /*" -2871- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                    /*" -2872- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                    _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                    /*" -2873- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2875- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2877- MOVE 'ERRO NO UPDATE DA VIEW V0DIFPARCELVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO UPDATE DA VIEW V0DIFPARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2878- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2879- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2880- END-IF */
                }


                /*" -2888- END-IF. */
            }


            /*" -2889- IF WHOST-VLPREMIO EQUAL ZEROS */

            if (WHOST_VLPREMIO == 00)
            {

                /*" -2890- MOVE '1221' TO WNR-EXEC-SQL */
                _.Move("1221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2895- PERFORM R1200_10_GERA_PARCELAS_DB_UPDATE_2 */

                R1200_10_GERA_PARCELAS_DB_UPDATE_2();

                /*" -2898- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2899- DISPLAY 'R1221-00 (ERRO - UPDATE V0DIFPARCELVA)' */
                    _.Display($"R1221-00 (ERRO - UPDATE V0DIFPARCELVA)");

                    /*" -2900- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                    /*" -2901- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                    _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                    /*" -2902- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -2904- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2906- MOVE 'ERRO NO UPDATE DA VIEW V0DIFPARCELVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO UPDATE DA VIEW V0DIFPARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2907- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -2908- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2910- END-IF */
                }


                /*" -2911- MOVE '1' TO V0PARC-SITUACAO */
                _.Move("1", V0PARC_SITUACAO);

                /*" -2920- ELSE */
            }
            else
            {


                /*" -2921- IF WHOST-VLPREMIO LESS ZERO */

                if (WHOST_VLPREMIO < 00)
                {

                    /*" -2922- MOVE '1222' TO WNR-EXEC-SQL */
                    _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2927- PERFORM R1200_10_GERA_PARCELAS_DB_UPDATE_3 */

                    R1200_10_GERA_PARCELAS_DB_UPDATE_3();

                    /*" -2930- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -2931- DISPLAY 'R1222-00 (ERRO - UPDATE V0DIFPARCELVA)' */
                        _.Display($"R1222-00 (ERRO - UPDATE V0DIFPARCELVA)");

                        /*" -2932- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                        _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                        /*" -2933- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                        _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                        /*" -2934- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -2936- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -2938- MOVE 'ERRO NO UPDATE DA VIEW V0DIFPARCELVA' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO NO UPDATE DA VIEW V0DIFPARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -2939- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -2940- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2942- END-IF */
                    }


                    /*" -2944- MOVE '1223' TO WNR-EXEC-SQL */
                    _.Move("1223", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2945- IF WHOST-PRMVG LESS ZEROS */

                    if (WHOST_PRMVG < 00)
                    {

                        /*" -2946- COMPUTE WHOST-PRMVG = WHOST-PRMVG * -1 */
                        WHOST_PRMVG.Value = WHOST_PRMVG * -1;

                        /*" -2948- END-IF */
                    }


                    /*" -2949- IF WHOST-PRMAP LESS ZEROS */

                    if (WHOST_PRMAP < 00)
                    {

                        /*" -2950- COMPUTE WHOST-PRMAP = WHOST-PRMAP * -1 */
                        WHOST_PRMAP.Value = WHOST_PRMAP * -1;

                        /*" -2952- END-IF */
                    }


                    /*" -2967- PERFORM R1200_10_GERA_PARCELAS_DB_INSERT_2 */

                    R1200_10_GERA_PARCELAS_DB_INSERT_2();

                    /*" -2970- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2971- DISPLAY 'R1223-00 (ERRO - INSERT V0DIFPARCELVA)' */
                        _.Display($"R1223-00 (ERRO - INSERT V0DIFPARCELVA)");

                        /*" -2972- DISPLAY 'CERTIF. : ' V0PROP-NRCERTIF */
                        _.Display($"CERTIF. : {V0PROP_NRCERTIF}");

                        /*" -2973- DISPLAY 'PARCELA : ' V0PROP-NRPARCEL */
                        _.Display($"PARCELA : {V0PROP_NRPARCEL}");

                        /*" -2974- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -2976- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -2978- MOVE 'ERRO NO INSERT DA VIEW V0DIFPARCELVA' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO NO INSERT DA VIEW V0DIFPARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -2979- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -2980- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2982- END-IF */
                    }


                    /*" -2983- MOVE '1' TO V0PARC-SITUACAO */
                    _.Move("1", V0PARC_SITUACAO);

                    /*" -2992- ELSE */
                }
                else
                {


                    /*" -2996- MOVE ' ' TO V0PARC-SITUACAO. */
                    _.Move(" ", V0PARC_SITUACAO);
                }

            }


            /*" -2997- IF WHOST-VLPREMIO LESS ZERO */

            if (WHOST_VLPREMIO < 00)
            {

                /*" -3000- MOVE ZEROS TO WHOST-PRMVG-W WHOST-PRMAP-W WHOST-VLPREMIO-W */
                _.Move(0, WHOST_PRMVG_W, WHOST_PRMAP_W, WHOST_VLPREMIO_W);

                /*" -3001- ELSE */
            }
            else
            {


                /*" -3002- MOVE WHOST-PRMVG TO WHOST-PRMVG-W */
                _.Move(WHOST_PRMVG, WHOST_PRMVG_W);

                /*" -3003- MOVE WHOST-PRMAP TO WHOST-PRMAP-W */
                _.Move(WHOST_PRMAP, WHOST_PRMAP_W);

                /*" -3005- MOVE WHOST-VLPREMIO TO WHOST-VLPREMIO-W. */
                _.Move(WHOST_VLPREMIO, WHOST_VLPREMIO_W);
            }


            /*" -3009- IF WHOST-PRMVG-W EQUAL ZEROS AND WHOST-PRMAP-W EQUAL ZEROS AND WHOST-VLPREMIO-W EQUAL ZEROS */

            if (WHOST_PRMVG_W == 00 && WHOST_PRMAP_W == 00 && WHOST_VLPREMIO_W == 00)
            {

                /*" -3010- MOVE V0COBP-PRMVG TO WHOST-PRMVG-W */
                _.Move(V0COBP_PRMVG, WHOST_PRMVG_W);

                /*" -3011- MOVE V0COBP-PRMAP TO WHOST-PRMAP-W */
                _.Move(V0COBP_PRMAP, WHOST_PRMAP_W);

                /*" -3012- COMPUTE WHOST-VLPREMIO-W = WHOST-PRMAP-W + WHOST-PRMVG-W */
                WHOST_VLPREMIO_W.Value = WHOST_PRMAP_W + WHOST_PRMVG_W;

                /*" -3014- END-IF. */
            }


            /*" -3015- IF V0PRDVG-ORIG-PRODU = 'GLOBAL' */

            if (V0PRDVG_ORIG_PRODU == "GLOBAL")
            {

                /*" -3016- PERFORM R1220-00-SELECT-TERMOADE */

                R1220_00_SELECT_TERMOADE_SECTION();

                /*" -3017- IF WS-DESPREZA EQUAL 'S' */

                if (WS_DESPREZA == "S")
                {

                    /*" -3018- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -3019- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -3021- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -3023- MOVE 'ERRO ** NAO CADASTRADO NA TERMOADE          ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO CADASTRADO NA TERMOADE          ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -3024- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -3025- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -3026- GO TO R1200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;

                    /*" -3027- END-IF */
                }


                /*" -3029- IF TERMOADE-DATA-ADESAO > '2007-06-30' AND TERMOADE-DATA-ADESAO < '2007-10-15' */

                if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO > "2007-06-30" && TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO < "2007-10-15")
                {

                    /*" -3030- IF V0PROP-NRPARCEL EQUAL 2 OR 3 OR 4 OR 5 */

                    if (V0PROP_NRPARCEL.In("2", "3", "4", "5"))
                    {

                        /*" -3031- PERFORM R1230-00-SELECT-CLIENTE */

                        R1230_00_SELECT_CLIENTE_SECTION();

                        /*" -3032- IF WS-DESPREZA EQUAL 'S' */

                        if (WS_DESPREZA == "S")
                        {

                            /*" -3033- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                            _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                            /*" -3034- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                            _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                            /*" -3036- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                            _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                            /*" -3038- MOVE 'ERRO ** NAO CADASTRADO CLIENTES        ' TO REG-SAI-DESCRICAO */
                            _.Move("ERRO ** NAO CADASTRADO CLIENTES        ", REG_DET.REG_SAI_DESCRICAO);

                            /*" -3039- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                            _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                            /*" -3040- WRITE REG-SAIDA FROM REG-DET */
                            _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                            /*" -3041- GO TO R1200-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                            return;

                            /*" -3042- END-IF */
                        }


                        /*" -3043- PERFORM R1240-00-SELECT-MIGRACAO */

                        R1240_00_SELECT_MIGRACAO_SECTION();

                        /*" -3044- IF WTEM-TERMO-ANT EQUAL 'NAO' */

                        if (WTEM_TERMO_ANT == "NAO")
                        {

                            /*" -3045- PERFORM R1250-00-SELECT-MIGRACAO */

                            R1250_00_SELECT_MIGRACAO_SECTION();

                            /*" -3046- END-IF */
                        }


                        /*" -3047- IF WTEM-TERMO-ANT EQUAL 'SIM' */

                        if (WTEM_TERMO_ANT == "SIM")
                        {

                            /*" -3048- COMPUTE WHOST-PRMVG-W = WHOST-PRMVG-W * 0,5 */
                            WHOST_PRMVG_W.Value = WHOST_PRMVG_W * 0.5;

                            /*" -3049- COMPUTE WHOST-PRMAP-W = WHOST-PRMAP-W * 0,5 */
                            WHOST_PRMAP_W.Value = WHOST_PRMAP_W * 0.5;

                            /*" -3052- COMPUTE WHOST-VLPREMIO-W = WHOST-VLPREMIO-W * 0,5 */
                            WHOST_VLPREMIO_W.Value = WHOST_VLPREMIO_W * 0.5;

                            /*" -3053- END-IF */
                        }


                        /*" -3054- END-IF */
                    }


                    /*" -3055- END-IF */
                }


                /*" -3117- END-IF. */
            }


            /*" -3118- IF (V0PARC-SITUACAO EQUAL ' ' ) */

            if ((V0PARC_SITUACAO == " "))
            {

                /*" -3120- IF (V0PROP-DTVENCTO LESS V1SIST-DTMOVABE) AND (V0PROP-NUM-APOLICE NOT EQUAL 109300002554) */

                if ((V0PROP_DTVENCTO < V1SIST_DTMOVABE) && (V0PROP_NUM_APOLICE != 109300002554))
                {

                    /*" -3121- MOVE '2' TO V0PARC-SITUACAO */
                    _.Move("2", V0PARC_SITUACAO);

                    /*" -3122- END-IF */
                }


                /*" -3124- END-IF */
            }


            /*" -3126- MOVE '1224' TO WNR-EXEC-SQL. */
            _.Move("1224", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3138- PERFORM R1200_10_GERA_PARCELAS_DB_INSERT_3 */

            R1200_10_GERA_PARCELAS_DB_INSERT_3();

            /*" -3141- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3142- GO TO R1200-00-PROXIMA */

                R1200_00_PROXIMA(); //GOTO
                return;

                /*" -3144- END-IF. */
            }


            /*" -3146- MOVE V0PROP-DTVENCTO TO V0HICB-DTVENCTO. */
            _.Move(V0PROP_DTVENCTO, V0HICB_DTVENCTO);

            /*" -3147- IF V0PARC-SITUACAO EQUAL ' ' */

            if (V0PARC_SITUACAO == " ")
            {

                /*" -3148- IF V0OPCP-OPCAOPAG NOT EQUAL '3' AND '4' */

                if (!V0OPCP_OPCAOPAG.In("3", "4"))
                {

                    /*" -3149- IF V0PROP-DTVENCTO < V1SIST-DTVENFIM-DB */

                    if (V0PROP_DTVENCTO < V1SIST_DTVENFIM_DB)
                    {

                        /*" -3150- MOVE V1SIST-DTVENFIM-DB TO V0HICB-DTVENCTO */
                        _.Move(V1SIST_DTVENFIM_DB, V0HICB_DTVENCTO);

                        /*" -3151- END-IF */
                    }


                    /*" -3152- PERFORM R1300-00-GERA-DEBITO */

                    R1300_00_GERA_DEBITO_SECTION();

                    /*" -3153- END-IF */
                }


                /*" -3163- END-IF. */
            }


            /*" -3164- IF (WHOST-CNTRLE-MNL EQUAL 1) */

            if ((WHOST_CNTRLE_MNL == 1))
            {

                /*" -3165- MOVE VG083-DTA-VENC-FATURA TO V0HICB-DTVENCTO */
                _.Move(VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_VENC_FATURA, V0HICB_DTVENCTO);

                /*" -3168- END-IF */
            }


            /*" -3170- PERFORM R1400-00-GERA-HIST-COBRANCA. */

            R1400_00_GERA_HIST_COBRANCA_SECTION();

            /*" -3171- IF (V0PARC-SITUACAO EQUAL '2' ) */

            if ((V0PARC_SITUACAO == "2"))
            {

                /*" -3172- GO TO R1200-00-GRAVADOS */

                R1200_00_GRAVADOS(); //GOTO
                return;

                /*" -3174- END-IF. */
            }


            /*" -3175- IF (V0PARC-SITUACAO EQUAL '1' ) */

            if ((V0PARC_SITUACAO == "1"))
            {

                /*" -3176- PERFORM R1600-00-VERIFICA-REPASSE */

                R1600_00_VERIFICA_REPASSE_SECTION();

                /*" -3176- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-SELECT-1 */
        public void R1200_10_GERA_PARCELAS_DB_SELECT_1()
        {
            /*" -2739- EXEC SQL SELECT PRMVG + PRMAP - VLMULTA INTO :V0PARC-PRMTOTANT FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC. */

            var r1200_10_GERA_PARCELAS_DB_SELECT_1_Query1 = new R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1200_10_GERA_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_10_GERA_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMTOTANT, V0PARC_PRMTOTANT);
            }


        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-2 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_2()
        {
            /*" -2585- EXEC SQL SELECT DTVENCTO INTO :V0HICB-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL WITH UR END-EXEC */

            var r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_2_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HICB_DTVENCTO, V0HICB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-INSERT-1 */
        public void R1200_10_GERA_PARCELAS_DB_INSERT_1()
        {
            /*" -2831- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, 9999, :V0PROP-NRPARCEL, 680, :V0PROP-DTPROXVEN, 0.00, 0.00, 0.00, 0.00, :DESCON-PRMVG, :DESCON-PRMAP, 0.00, ' ' ) END-EXEC */

            var r1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1 = new R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                DESCON_PRMVG = DESCON_PRMVG.ToString(),
                DESCON_PRMAP = DESCON_PRMAP.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1.Execute(r1200_10_GERA_PARCELAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-UPDATE-1 */
        public void R1200_10_GERA_PARCELAS_DB_UPDATE_1()
        {
            /*" -2866- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC */

            var r1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1 = new R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1.Execute(r1200_10_GERA_PARCELAS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-SELECT-2 */
        public void R1200_10_GERA_PARCELAS_DB_SELECT_2()
        {
            /*" -2786- EXEC SQL SELECT PCT_PARCELA_DESC INTO :DESCON-PERC FROM SEGUROS.VG_PARCELAS_DESCON WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO IN (:V0PROP-CODSUBES, 0) AND NUM_PARCELA_DESC = :V0PROP-NRPARCEL AND DT_INIVIG_PARCDESC <= :V0PROP-DTQITBCO AND DT_TERVIG_PARCDESC >= :V0PROP-DTQITBCO END-EXEC. */

            var r1200_10_GERA_PARCELAS_DB_SELECT_2_Query1 = new R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTQITBCO = V0PROP_DTQITBCO.ToString(),
            };

            var executed_1 = R1200_10_GERA_PARCELAS_DB_SELECT_2_Query1.Execute(r1200_10_GERA_PARCELAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCON_PERC, DESCON_PERC);
            }


        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-UPDATE-2 */
        public void R1200_10_GERA_PARCELAS_DB_UPDATE_2()
        {
            /*" -2895- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC */

            var r1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1 = new R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1.Execute(r1200_10_GERA_PARCELAS_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1200-00-GRAVADOS */
        private void R1200_00_GRAVADOS(bool isPerform = false)
        {
            /*" -3179- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-INSERT-2 */
        public void R1200_10_GERA_PARCELAS_DB_INSERT_2()
        {
            /*" -2967- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, 9999, :V0PROP-NRPARCEL, 601, :V0PROP-DTVENCTO, 0.00, 0.00, 0.00, 0.00, :WHOST-PRMVG, :WHOST-PRMAP, 0.00, ' ' ) END-EXEC */

            var r1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1 = new R1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1.Execute(r1200_10_GERA_PARCELAS_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-UPDATE-3 */
        public void R1200_10_GERA_PARCELAS_DB_UPDATE_3()
        {
            /*" -2927- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL END-EXEC */

            var r1200_10_GERA_PARCELAS_DB_UPDATE_3_Update1 = new R1200_10_GERA_PARCELAS_DB_UPDATE_3_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_UPDATE_3_Update1.Execute(r1200_10_GERA_PARCELAS_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1200-10-GERA-PARCELAS-DB-INSERT-3 */
        public void R1200_10_GERA_PARCELAS_DB_INSERT_3()
        {
            /*" -3138- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, :WHOST-PRMVG-W, :WHOST-PRMAP-W, 0, :V0OPCP-OPCAOPAG, :V0PARC-SITUACAO, :V0PARC-OCORHIST, CURRENT TIMESTAMP) END-EXEC. */

            var r1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1 = new R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG_W = WHOST_PRMVG_W.ToString(),
                WHOST_PRMAP_W = WHOST_PRMAP_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            R1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1.Execute(r1200_10_GERA_PARCELAS_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R1200-00-GERA-PARCELAS-DB-SELECT-3 */
        public void R1200_00_GERA_PARCELAS_DB_SELECT_3()
        {
            /*" -2682- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLCUSTCAP, VLCUSTCDG, VLCUSTAUXF, CODOPER INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-QTTITCAP, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF, :V0COBP-CODOPER FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN END-EXEC. */

            var r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1 = new R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1200_00_GERA_PARCELAS_DB_SELECT_3_Query1.Execute(r1200_00_GERA_PARCELAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_IVLCUSTAUXF, V0COBP_IVLCUSTAUXF);
                _.Move(executed_1.V0COBP_CODOPER, V0COBP_CODOPER);
            }


        }

        [StopWatch]
        /*" R1200-00-PROXIMA */
        private void R1200_00_PROXIMA(bool isPerform = false)
        {
            /*" -3185- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -3187- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -3188- IF (WDATA-SIS-MES > 12) */

            if ((AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12))
            {

                /*" -3189- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -3190- COMPUTE WDATA-SIS-ANO = WDATA-SIS-ANO + 1 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;

                /*" -3192- END-IF. */
            }


            /*" -3193- IF (V0OPCP-DIA-DEBITO NOT LESS 31) */

            if ((V0OPCP_DIA_DEBITO >= 31))
            {

                /*" -3194- MOVE TAB-DIA-MES(WDATA-SIS-MES) TO WDATA-SIS-DIA */
                _.Move(TAB_ULTIMOS_DIAS.TAB_DIA_MESES[AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES].TAB_DIA_MES, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                /*" -3195- ELSE */
            }
            else
            {


                /*" -3196- MOVE V0OPCP-DIA-DEBITO TO WDATA-SIS-DIA */
                _.Move(V0OPCP_DIA_DEBITO, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                /*" -3198- END-IF. */
            }


            /*" -3199- IF (V0OPCP-DIA-DEBITO NOT LESS 29) */

            if ((V0OPCP_DIA_DEBITO >= 29))
            {

                /*" -3200- IF (WDATA-SIS-MES EQUAL 02) */

                if ((AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES == 02))
                {

                    /*" -3201- MOVE 28 TO WDATA-SIS-DIA */
                    _.Move(28, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                    /*" -3202- END-IF */
                }


                /*" -3204- END-IF. */
            }


            /*" -3204- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-SELECT-TERMOADE-SECTION */
        private void R1220_00_SELECT_TERMOADE_SECTION()
        {
            /*" -3215- MOVE '1220' TO WNR-EXEC-SQL. */
            _.Move("1220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3218- MOVE V0PROP-NRCERTIF TO TERMOADE-NUM-TERMO. */
            _.Move(V0PROP_NRCERTIF, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);

            /*" -3223- PERFORM R1220_00_SELECT_TERMOADE_DB_SELECT_1 */

            R1220_00_SELECT_TERMOADE_DB_SELECT_1();

            /*" -3226- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3227- DISPLAY 'R1220 - PROBLEMAS SELECT (TERMOADE)' */
                _.Display($"R1220 - PROBLEMAS SELECT (TERMOADE)");

                /*" -3228- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -3229- DISPLAY 'NRCERTIF  ' V0PROP-NRCERTIF */
                _.Display($"NRCERTIF  {V0PROP_NRCERTIF}");

                /*" -3230- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3232- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3234- MOVE 'ERRO NO ACESSO A TABELA TERMO_ADESAO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA TERMO_ADESAO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3235- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3236- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3245- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -3246- ELSE */
                }
                else
                {


                    /*" -3247- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3248- END-IF */
                }


                /*" -3248- END-IF. */
            }


        }

        [StopWatch]
        /*" R1220-00-SELECT-TERMOADE-DB-SELECT-1 */
        public void R1220_00_SELECT_TERMOADE_DB_SELECT_1()
        {
            /*" -3223- EXEC SQL SELECT DATA_ADESAO INTO :TERMOADE-DATA-ADESAO FROM SEGUROS.TERMO_ADESAO WHERE NUM_TERMO = :TERMOADE-NUM-TERMO END-EXEC. */

            var r1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1 = new R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1()
            {
                TERMOADE_NUM_TERMO = TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO.ToString(),
            };

            var executed_1 = R1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1.Execute(r1220_00_SELECT_TERMOADE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.TERMOADE_DATA_ADESAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1230-00-SELECT-CLIENTE-SECTION */
        private void R1230_00_SELECT_CLIENTE_SECTION()
        {
            /*" -3259- MOVE '1230' TO WNR-EXEC-SQL. */
            _.Move("1230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3264- PERFORM R1230_00_SELECT_CLIENTE_DB_SELECT_1 */

            R1230_00_SELECT_CLIENTE_DB_SELECT_1();

            /*" -3267- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3268- DISPLAY 'R1230 - PROBLEMAS SELECT (CLIENTE)' */
                _.Display($"R1230 - PROBLEMAS SELECT (CLIENTE)");

                /*" -3269- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -3270- DISPLAY 'CLIENTES  ' V0PROP-CODCLIEN */
                _.Display($"CLIENTES  {V0PROP_CODCLIEN}");

                /*" -3271- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3273- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3275- MOVE 'ERRO NO ACESSO A TABELA DE CLIENTES' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA DE CLIENTES", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3276- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3277- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3287- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -3288- ELSE */
                }
                else
                {


                    /*" -3289- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3290- END-IF */
                }


                /*" -3290- END-IF. */
            }


        }

        [StopWatch]
        /*" R1230-00-SELECT-CLIENTE-DB-SELECT-1 */
        public void R1230_00_SELECT_CLIENTE_DB_SELECT_1()
        {
            /*" -3264- EXEC SQL SELECT CGCCPF INTO :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :V0PROP-CODCLIEN END-EXEC. */

            var r1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1 = new R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1.Execute(r1230_00_SELECT_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1230_99_SAIDA*/

        [StopWatch]
        /*" R1240-00-SELECT-MIGRACAO-SECTION */
        private void R1240_00_SELECT_MIGRACAO_SECTION()
        {
            /*" -3300- MOVE '1240' TO WNR-EXEC-SQL. */
            _.Move("1240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3302- MOVE 'SIM' TO WTEM-TERMO-ANT. */
            _.Move("SIM", WTEM_TERMO_ANT);

            /*" -3313- PERFORM R1240_00_SELECT_MIGRACAO_DB_DECLARE_1 */

            R1240_00_SELECT_MIGRACAO_DB_DECLARE_1();

            /*" -3315- PERFORM R1240_00_SELECT_MIGRACAO_DB_OPEN_1 */

            R1240_00_SELECT_MIGRACAO_DB_OPEN_1();

            /*" -3318- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3319- DISPLAY 'R1240 - PROBLEMAS OPEN  (CTERMO  )' */
                _.Display($"R1240 - PROBLEMAS OPEN  (CTERMO  )");

                /*" -3320- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -3321- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3323- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3325- MOVE 'ERRO NA ABERTURA DO CURSOR CLIENTES/TERMO_ADESAO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ABERTURA DO CURSOR CLIENTES/TERMO_ADESAO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3326- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3327- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3329- END-IF. */
            }


            /*" -3334- PERFORM R1240_00_SELECT_MIGRACAO_DB_FETCH_1 */

            R1240_00_SELECT_MIGRACAO_DB_FETCH_1();

            /*" -3337- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3338- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3339- MOVE 'NAO' TO WTEM-TERMO-ANT */
                    _.Move("NAO", WTEM_TERMO_ANT);

                    /*" -3340- ELSE */
                }
                else
                {


                    /*" -3341- DISPLAY 'R1240 - PROBLEMAS FETCH (CTERMO ).' */
                    _.Display($"R1240 - PROBLEMAS FETCH (CTERMO ).");

                    /*" -3342- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -3343- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -3345- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3347- MOVE 'ERRO NO FETCH DO CURSOR CLIENTES/TERMO_ADESAO' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR CLIENTES/TERMO_ADESAO", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3348- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -3349- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3350- END-IF */
                }


                /*" -3352- END-IF. */
            }


            /*" -3352- PERFORM R1240_00_SELECT_MIGRACAO_DB_CLOSE_1 */

            R1240_00_SELECT_MIGRACAO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R1240-00-SELECT-MIGRACAO-DB-OPEN-1 */
        public void R1240_00_SELECT_MIGRACAO_DB_OPEN_1()
        {
            /*" -3315- EXEC SQL OPEN CTERMO END-EXEC. */

            CTERMO.Open();

        }

        [StopWatch]
        /*" R1250-00-SELECT-MIGRACAO-DB-DECLARE-1 */
        public void R1250_00_SELECT_MIGRACAO_DB_DECLARE_1()
        {
            /*" -3380- EXEC SQL DECLARE CTERMO1 CURSOR FOR SELECT B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_TERMO FROM SEGUROS.CLIENTES A, SEGUROS.TERMO_ADESAO B, SEGUROS.RELATORIOS C WHERE A.CGCCPF = :CLIENTES-CGCCPF AND B.COD_CLIENTE = A.COD_CLIENTE AND B.NUM_APOLICE IN (97010000889, 109300000672) AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.COD_RELATORIO IN ( 'VE0032B' , 'VE0030B' ) AND C.DATA_SOLICITACAO > '2007-06-30' END-EXEC. */
            CTERMO1 = new VG0853B_CTERMO1(true);
            string GetQuery_CTERMO1()
            {
                var query = @$"SELECT B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_TERMO 
							FROM SEGUROS.CLIENTES A
							, 
							SEGUROS.TERMO_ADESAO B
							, 
							SEGUROS.RELATORIOS C 
							WHERE A.CGCCPF = '{CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}' 
							AND B.COD_CLIENTE = A.COD_CLIENTE 
							AND B.NUM_APOLICE IN (97010000889
							, 
							109300000672) 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.COD_RELATORIO IN ( 'VE0032B'
							, 'VE0030B' ) 
							AND C.DATA_SOLICITACAO > '2007-06-30'";

                return query;
            }
            CTERMO1.GetQueryEvent += GetQuery_CTERMO1;

        }

        [StopWatch]
        /*" R1240-00-SELECT-MIGRACAO-DB-FETCH-1 */
        public void R1240_00_SELECT_MIGRACAO_DB_FETCH_1()
        {
            /*" -3334- EXEC SQL FETCH CTERMO INTO :TERMOADE-NUM-APOLICE , :TERMOADE-COD-SUBGRUPO , :TERMOADE-NUM-TERMO END-EXEC. */

            if (CTERMO.Fetch())
            {
                _.Move(CTERMO.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(CTERMO.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(CTERMO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
            }

        }

        [StopWatch]
        /*" R1240-00-SELECT-MIGRACAO-DB-CLOSE-1 */
        public void R1240_00_SELECT_MIGRACAO_DB_CLOSE_1()
        {
            /*" -3352- EXEC SQL CLOSE CTERMO END-EXEC. */

            CTERMO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1240_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-SELECT-MIGRACAO-SECTION */
        private void R1250_00_SELECT_MIGRACAO_SECTION()
        {
            /*" -3362- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3364- MOVE 'SIM' TO WTEM-TERMO-ANT. */
            _.Move("SIM", WTEM_TERMO_ANT);

            /*" -3380- PERFORM R1250_00_SELECT_MIGRACAO_DB_DECLARE_1 */

            R1250_00_SELECT_MIGRACAO_DB_DECLARE_1();

            /*" -3382- PERFORM R1250_00_SELECT_MIGRACAO_DB_OPEN_1 */

            R1250_00_SELECT_MIGRACAO_DB_OPEN_1();

            /*" -3385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3386- DISPLAY 'R1020 - PROBLEMAS OPEN    (CTERMO1   ) ..' */
                _.Display($"R1020 - PROBLEMAS OPEN    (CTERMO1   ) ..");

                /*" -3387- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -3388- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3390- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3392- MOVE 'ERRO NA ABERTURA DO CURSOR CLIENTES/TERMO_ADESAO/REL' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ABERTURA DO CURSOR CLIENTES/TERMO_ADESAO/REL", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3393- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3394- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3396- END-IF. */
            }


            /*" -3401- PERFORM R1250_00_SELECT_MIGRACAO_DB_FETCH_1 */

            R1250_00_SELECT_MIGRACAO_DB_FETCH_1();

            /*" -3404- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3405- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3406- MOVE 'NAO' TO WTEM-TERMO-ANT */
                    _.Move("NAO", WTEM_TERMO_ANT);

                    /*" -3407- ELSE */
                }
                else
                {


                    /*" -3408- DISPLAY 'R1240 - PROBLEMAS FETCH   (CTERMO1   ) ..' */
                    _.Display($"R1240 - PROBLEMAS FETCH   (CTERMO1   ) ..");

                    /*" -3409- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -3410- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -3412- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3414- MOVE 'ERRO FETCH DO CURSOR CLIENTES/TERMO_ADESAO/REL' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO FETCH DO CURSOR CLIENTES/TERMO_ADESAO/REL", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3415- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -3416- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3417- END-IF */
                }


                /*" -3419- END-IF. */
            }


            /*" -3419- PERFORM R1250_00_SELECT_MIGRACAO_DB_CLOSE_1 */

            R1250_00_SELECT_MIGRACAO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R1250-00-SELECT-MIGRACAO-DB-OPEN-1 */
        public void R1250_00_SELECT_MIGRACAO_DB_OPEN_1()
        {
            /*" -3382- EXEC SQL OPEN CTERMO1 END-EXEC. */

            CTERMO1.Open();

        }

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-DB-DECLARE-1 */
        public void R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1()
        {
            /*" -3659- EXEC SQL DECLARE CDIFPAR CURSOR FOR SELECT NRPARCEL, CODOPER, PRMDIFVG + PRMDIFAP, PRMDIFVG, PRMDIFAP FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTVENCTO <= :V0PROP-DTVENCTO AND SITUACAO = ' ' FOR UPDATE OF NRPARCEL, CODOPER END-EXEC. */
            CDIFPAR = new VG0853B_CDIFPAR(true);
            string GetQuery_CDIFPAR()
            {
                var query = @$"SELECT NRPARCEL
							, 
							CODOPER
							, 
							PRMDIFVG + PRMDIFAP
							, 
							PRMDIFVG
							, 
							PRMDIFAP 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0PROP_NRCERTIF}' 
							AND DTVENCTO <= '{V0PROP_DTVENCTO}' 
							AND SITUACAO = ' '";

                return query;
            }
            CDIFPAR.GetQueryEvent += GetQuery_CDIFPAR;

        }

        [StopWatch]
        /*" R1250-00-SELECT-MIGRACAO-DB-FETCH-1 */
        public void R1250_00_SELECT_MIGRACAO_DB_FETCH_1()
        {
            /*" -3401- EXEC SQL FETCH CTERMO1 INTO :TERMOADE-NUM-APOLICE , :TERMOADE-COD-SUBGRUPO , :TERMOADE-NUM-TERMO END-EXEC. */

            if (CTERMO1.Fetch())
            {
                _.Move(CTERMO1.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(CTERMO1.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(CTERMO1.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
            }

        }

        [StopWatch]
        /*" R1250-00-SELECT-MIGRACAO-DB-CLOSE-1 */
        public void R1250_00_SELECT_MIGRACAO_DB_CLOSE_1()
        {
            /*" -3419- EXEC SQL CLOSE CTERMO1 END-EXEC. */

            CTERMO1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1260-00-CONSULTA-SITUACAO-SECTION */
        private void R1260_00_CONSULTA_SITUACAO_SECTION()
        {
            /*" -3441- PERFORM R1260_00_CONSULTA_SITUACAO_DB_SELECT_1 */

            R1260_00_CONSULTA_SITUACAO_DB_SELECT_1();

            /*" -3444- IF ( SQLCODE NOT EQUAL ZEROS AND +100 ) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3445- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3446- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3448- MOVE 'ERRO NA CONSULTA DA HIST_LANC_CTA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA CONSULTA DA HIST_LANC_CTA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3449- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3450- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3450- END-IF. */
            }


        }

        [StopWatch]
        /*" R1260-00-CONSULTA-SITUACAO-DB-SELECT-1 */
        public void R1260_00_CONSULTA_SITUACAO_DB_SELECT_1()
        {
            /*" -3441- EXEC SQL SELECT T1.SIT_REGISTRO INTO :V0HCTA-SITUACAO FROM SEGUROS.HIST_LANC_CTA T1 WHERE T1.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND T1.NUM_PARCELA = :V0PROP-NRPARCEL AND T1.OCORR_HISTORICOCTA = ( SELECT MAX( OCORR_HISTORICOCTA ) FROM SEGUROS.HIST_LANC_CTA T2 WHERE T2.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND T2.NUM_PARCELA = :V0PROP-NRPARCEL ) END-EXEC. */

            var r1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1 = new R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            var executed_1 = R1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1.Execute(r1260_00_CONSULTA_SITUACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_SITUACAO, V0HCTA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1260_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-SECTION */
        private void R1300_00_GERA_DEBITO_SECTION()
        {
            /*" -3461- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' */

            if (V0OPCP_OPCAOPAG.In("1", "2"))
            {

                /*" -3462- MOVE V0CONV-CODCONV TO HOST-CODCONV */
                _.Move(V0CONV_CODCONV, HOST_CODCONV);

                /*" -3464- MOVE ZEROS TO V0OPCP-CARTAO-CRED. */
                _.Move(0, V0OPCP_CARTAO_CRED);
            }


            /*" -3465- IF V0OPCP-OPCAOPAG EQUAL '5' */

            if (V0OPCP_OPCAOPAG == "5")
            {

                /*" -3466- MOVE V0CONV-CCRED TO HOST-CODCONV */
                _.Move(V0CONV_CCRED, HOST_CODCONV);

                /*" -3472- MOVE ZEROS TO V0OPCP-CARTAO-CRED V0OPCP-AGECTADEB V0OPCP-OPRCTADEB V0OPCP-NUMCTADEB V0OPCP-DIGCTADEB. */
                _.Move(0, V0OPCP_CARTAO_CRED, V0OPCP_AGECTADEB, V0OPCP_OPRCTADEB, V0OPCP_NUMCTADEB, V0OPCP_DIGCTADEB);
            }


            /*" -3474- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3516- PERFORM R1300_00_GERA_DEBITO_DB_INSERT_1 */

            R1300_00_GERA_DEBITO_DB_INSERT_1();

        }

        [StopWatch]
        /*" R1300-00-GERA-DEBITO-DB-INSERT-1 */
        public void R1300_00_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -3516- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, 1, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HICB-DTVENCTO, :WHOST-VLPREMIO-W, '0' , '1' , CURRENT TIMESTAMP, 0, :HOST-CODCONV, NULL, NULL, NULL, NULL, 'VG0853B' , :V0OPCP-CARTAO-CRED) END-EXEC. */

            var r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1 = new R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                HOST_CODCONV = HOST_CODCONV.ToString(),
                V0OPCP_CARTAO_CRED = V0OPCP_CARTAO_CRED.ToString(),
            };

            R1300_00_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(r1300_00_GERA_DEBITO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-SECTION */
        private void R1400_00_GERA_HIST_COBRANCA_SECTION()
        {
            /*" -3525- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3527- MOVE '5' TO V0HICB-SITUACAO. */
            _.Move("5", V0HICB_SITUACAO);

            /*" -3529- MOVE 000 TO V0HICB-CODOPER. */
            _.Move(000, V0HICB_CODOPER);

            /*" -3530- IF V0PARC-SITUACAO EQUAL '1' */

            if (V0PARC_SITUACAO == "1")
            {

                /*" -3531- MOVE '1' TO V0HICB-SITUACAO */
                _.Move("1", V0HICB_SITUACAO);

                /*" -3533- MOVE 000 TO V0HICB-CODOPER. */
                _.Move(000, V0HICB_CODOPER);
            }


            /*" -3534- IF V0PARC-SITUACAO EQUAL '2' */

            if (V0PARC_SITUACAO == "2")
            {

                /*" -3535- MOVE '2' TO V0HICB-SITUACAO */
                _.Move("2", V0HICB_SITUACAO);

                /*" -3537- MOVE 000 TO V0HICB-CODOPER. */
                _.Move(000, V0HICB_CODOPER);
            }


            /*" -3538- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (V0OPCP_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -3539- PERFORM R1420-00-GERA-NUM-TITULO */

                R1420_00_GERA_NUM_TITULO_SECTION();

                /*" -3540- MOVE CEDENTE-NUM-TITULO TO WHOST-NRTIT */
                _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WHOST_NRTIT);

                /*" -3541- ELSE */
            }
            else
            {


                /*" -3543- ADD 1 TO WTITL-SEQUENCIA */
                FILLER_22.WTITL_SEQUENCIA.Value = FILLER_22.WTITL_SEQUENCIA + 1;

                /*" -3545- MOVE WTITL-SEQUENCIA TO DPARM01 */
                _.Move(FILLER_22.WTITL_SEQUENCIA, DPARM01X.DPARM01);

                /*" -3547- CALL 'PROTIT01' USING DPARM01X */
                _.Call("PROTIT01", DPARM01X);

                /*" -3548- IF DPARM01-RC NOT EQUAL +0 */

                if (DPARM01X.DPARM01_RC != +0)
                {

                    /*" -3549- DISPLAY 'ERRO CHAMADA PROTIT01' */
                    _.Display($"ERRO CHAMADA PROTIT01");

                    /*" -3550- DISPLAY 'CERTIFICADO     ' V0PROP-NRCERTIF */
                    _.Display($"CERTIFICADO     {V0PROP_NRCERTIF}");

                    /*" -3551- DISPLAY 'AREA            ' DPARM01X */
                    _.Display($"AREA            {DPARM01X}");

                    /*" -3552- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -3554- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3556- MOVE 'ERRO NA EXECUCAO DA SUB-ROTINA PROPTIT01' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA EXECUCAO DA SUB-ROTINA PROPTIT01", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3557- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -3558- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3559- END-IF */
                }


                /*" -3560- MOVE DPARM01-D1 TO WTITL-DIGITO */
                _.Move(DPARM01X.DPARM01_D1, FILLER_22.WTITL_DIGITO);

                /*" -3562- MOVE W-NUMR-TITULO TO V0BANC-NRTIT WHOST-NRTIT */
                _.Move(W_NUMR_TITULO, V0BANC_NRTIT, WHOST_NRTIT);

                /*" -3564- END-IF. */
            }


            /*" -3581- PERFORM R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1 */

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1();

            /*" -3584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3585- DISPLAY 'R1400-00 (ERRO - INSERT V0HISTCOBVA)' */
                _.Display($"R1400-00 (ERRO - INSERT V0HISTCOBVA)");

                /*" -3588- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF '  ' 'PARCEL: ' V0PROP-NRPARCEL ' ' 'NRTIT: ' WHOST-NRTIT */

                $"CERTIF: {V0PROP_NRCERTIF}  PARCEL: {V0PROP_NRPARCEL} NRTIT: {WHOST_NRTIT}"
                .Display();

                /*" -3589- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3591- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3593- MOVE 'ERRO NO INSERT DA VIEW V0HISTCOBVA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO INSERT DA VIEW V0HISTCOBVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3594- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3595- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3595- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-GERA-HIST-COBRANCA-DB-INSERT-1 */
        public void R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1()
        {
            /*" -3581- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :WHOST-NRTIT, :V0HICB-DTVENCTO, :WHOST-VLPREMIO-W, :V0OPCP-OPCAOPAG, :V0HICB-SITUACAO, :V0HICB-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1 = new R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
                V0HICB_DTVENCTO = V0HICB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_W = WHOST_VLPREMIO_W.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HICB_SITUACAO = V0HICB_SITUACAO.ToString(),
                V0HICB_CODOPER = V0HICB_CODOPER.ToString(),
            };

            R1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1.Execute(r1400_00_GERA_HIST_COBRANCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1420-00-GERA-NUM-TITULO-SECTION */
        private void R1420_00_GERA_NUM_TITULO_SECTION()
        {
            /*" -3605- MOVE '1420' TO WNR-EXEC-SQL. */
            _.Move("1420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3610- PERFORM R1420_00_GERA_NUM_TITULO_DB_UPDATE_1 */

            R1420_00_GERA_NUM_TITULO_DB_UPDATE_1();

            /*" -3613- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3614- DISPLAY 'R0000 - ERRO UPDATE SEGUROS.CEDENTE 36' */
                _.Display($"R0000 - ERRO UPDATE SEGUROS.CEDENTE 36");

                /*" -3615- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3617- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3619- MOVE 'ERRO NO UPDATE DA SEGUROS.CEDENTE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA SEGUROS.CEDENTE", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3620- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3622- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3627- PERFORM R1420_00_GERA_NUM_TITULO_DB_SELECT_1 */

            R1420_00_GERA_NUM_TITULO_DB_SELECT_1();

            /*" -3630- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3631- DISPLAY 'CEDENTE NAO CADASTRADO (CEDENTE) 36 ' */
                _.Display($"CEDENTE NAO CADASTRADO (CEDENTE) 36 ");

                /*" -3632- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3634- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3636- MOVE 'CEDENTE 36 NAO CADASTRADO NA TAB SEGUROS.CEDENTE' TO LD-DES-ERRO-SSAIDA */
                _.Move("CEDENTE 36 NAO CADASTRADO NA TAB SEGUROS.CEDENTE", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3637- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3638- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1420-00-GERA-NUM-TITULO-DB-UPDATE-1 */
        public void R1420_00_GERA_NUM_TITULO_DB_UPDATE_1()
        {
            /*" -3610- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = NUM_TITULO + 1, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CEDENTE = 36 END-EXEC. */

            var r1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1 = new R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1()
            {
            };

            R1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1.Execute(r1420_00_GERA_NUM_TITULO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1420-00-GERA-NUM-TITULO-DB-SELECT-1 */
        public void R1420_00_GERA_NUM_TITULO_DB_SELECT_1()
        {
            /*" -3627- EXEC SQL SELECT NUM_TITULO INTO :CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 36 END-EXEC. */

            var r1420_00_GERA_NUM_TITULO_DB_SELECT_1_Query1 = new R1420_00_GERA_NUM_TITULO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1420_00_GERA_NUM_TITULO_DB_SELECT_1_Query1.Execute(r1420_00_GERA_NUM_TITULO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1420_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-SECTION */
        private void R1500_00_TRATA_V0DIFPARCELVA_SECTION()
        {
            /*" -3659- PERFORM R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1 */

            R1500_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1();

            /*" -3663- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3663- PERFORM R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1 */

            R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1();

            /*" -3666- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3667- DISPLAY 'PROBLEMAS NO OPEN (CDIFPAR   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CDIFPAR   ) ... ");

                /*" -3668- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3670- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3672- MOVE 'ERRO NO ABERTURA DO CURSOR V0DIFPARCELVA - CDIFPAR' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ABERTURA DO CURSOR V0DIFPARCELVA - CDIFPAR", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3673- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3675- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3676- MOVE SPACES TO WFIM-CDIFPAR. */
            _.Move("", AREA_DE_WORK.WFIM_CDIFPAR);

            /*" -3677- MOVE V0COBP-VLPREMIO TO WHOST-VLPREMIO. */
            _.Move(V0COBP_VLPREMIO, WHOST_VLPREMIO);

            /*" -3678- MOVE V0COBP-PRMVG TO WHOST-PRMVG. */
            _.Move(V0COBP_PRMVG, WHOST_PRMVG);

            /*" -3680- MOVE V0COBP-PRMAP TO WHOST-PRMAP. */
            _.Move(V0COBP_PRMAP, WHOST_PRMAP);

            /*" -3682- PERFORM R1510-00-FETCH-CDIFPAR. */

            R1510_00_FETCH_CDIFPAR_SECTION();

            /*" -3683- IF WFIM-CDIFPAR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty())
            {

                /*" -3683- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1500_10_LOOP_CDIFPAR */

            R1500_10_LOOP_CDIFPAR();

        }

        [StopWatch]
        /*" R1500-00-TRATA-V0DIFPARCELVA-DB-OPEN-1 */
        public void R1500_00_TRATA_V0DIFPARCELVA_DB_OPEN_1()
        {
            /*" -3663- EXEC SQL OPEN CDIFPAR END-EXEC. */

            CDIFPAR.Open();

        }

        [StopWatch]
        /*" R2000-00-RECOMANDAR-DEB-ANT-DB-DECLARE-1 */
        public void R2000_00_RECOMANDAR_DEB_ANT_DB_DECLARE_1()
        {
            /*" -4527- EXEC SQL DECLARE CDEBANT CURSOR FOR SELECT C.NUM_CERTIFICADO, C.NUM_PARCELA, C.OCORR_HISTORICOCTA + 1, C.COD_AGENCIA_DEBITO, C.OPE_CONTA_DEBITO, C.NUM_CONTA_DEBITO, C.DIG_CONTA_DEBITO, C.DATA_VENCIMENTO, C.PRM_TOTAL, C.TIPLANC, C.OCORR_HISTORICO + 1, C.CODCONV, C.CODRET FROM SEGUROS.PARCELAS_VIDAZUL A, SEGUROS.COBER_HIST_VIDAZUL B, SEGUROS.HIST_LANC_CTA C WHERE A.NUM_CERTIFICADO = :V0PROP-NRCERTIF AND A.DATA_VENCIMENTO >= :V0PROP-DTVENCTO-2M AND A.DATA_VENCIMENTO < :V0PROP-DTVENCTO AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_PARCELA = B.NUM_PARCELA AND B.SIT_REGISTRO IN ( ' ' , '0' , X'00' ) AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND B.NUM_PARCELA = C.NUM_PARCELA AND C.OCORR_HISTORICOCTA = (SELECT MAX(T.OCORR_HISTORICOCTA) FROM SEGUROS.HIST_LANC_CTA T WHERE T.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND T.NUM_PARCELA = B.NUM_PARCELA) AND C.CODCONV = 6088 AND C.TIPLANC = '1' AND C.SIT_REGISTRO = ' ' AND C.CODRET <> 0 AND C.NUM_CARTAO_CREDITO = 0 END-EXEC. */
            CDEBANT = new VG0853B_CDEBANT(true);
            string GetQuery_CDEBANT()
            {
                var query = @$"SELECT C.NUM_CERTIFICADO
							, 
							C.NUM_PARCELA
							, 
							C.OCORR_HISTORICOCTA + 1
							, 
							C.COD_AGENCIA_DEBITO
							, 
							C.OPE_CONTA_DEBITO
							, 
							C.NUM_CONTA_DEBITO
							, 
							C.DIG_CONTA_DEBITO
							, 
							C.DATA_VENCIMENTO
							, 
							C.PRM_TOTAL
							, 
							C.TIPLANC
							, 
							C.OCORR_HISTORICO + 1
							, 
							C.CODCONV
							, 
							C.CODRET 
							FROM SEGUROS.PARCELAS_VIDAZUL A
							, 
							SEGUROS.COBER_HIST_VIDAZUL B
							, 
							SEGUROS.HIST_LANC_CTA C 
							WHERE A.NUM_CERTIFICADO = '{V0PROP_NRCERTIF}' 
							AND A.DATA_VENCIMENTO >= '{V0PROP_DTVENCTO_2M}' 
							AND A.DATA_VENCIMENTO < '{V0PROP_DTVENCTO}' 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND A.NUM_PARCELA = B.NUM_PARCELA 
							AND B.SIT_REGISTRO IN ( ' '
							, '0'
							, X'00' ) 
							AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO 
							AND B.NUM_PARCELA = C.NUM_PARCELA 
							AND C.OCORR_HISTORICOCTA = 
							(SELECT MAX(T.OCORR_HISTORICOCTA) 
							FROM SEGUROS.HIST_LANC_CTA T 
							WHERE T.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND T.NUM_PARCELA = B.NUM_PARCELA) 
							AND C.CODCONV = 6088 
							AND C.TIPLANC = '1' 
							AND C.SIT_REGISTRO = ' ' 
							AND C.CODRET <> 0 
							AND C.NUM_CARTAO_CREDITO = 0";

                return query;
            }
            CDEBANT.GetQueryEvent += GetQuery_CDEBANT;

        }

        [StopWatch]
        /*" R1500-10-LOOP-CDIFPAR */
        private void R1500_10_LOOP_CDIFPAR(bool isPerform = false)
        {
            /*" -3689- IF V0DIFP-CODOPER NOT LESS 600 AND V0DIFP-CODOPER NOT GREATER 699 */

            if (V0DIFP_CODOPER >= 600 && V0DIFP_CODOPER <= 699)
            {

                /*" -3690- COMPUTE WHOST-PRMVG = WHOST-PRMVG - V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG - V0DIFP_PRMDIFVG;

                /*" -3691- COMPUTE WHOST-PRMAP = WHOST-PRMAP - V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP - V0DIFP_PRMDIFAP;

                /*" -3693- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP. */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;
            }


            /*" -3695- IF V0DIFP-CODOPER NOT LESS 400 AND V0DIFP-CODOPER NOT GREATER 499 */

            if (V0DIFP_CODOPER >= 400 && V0DIFP_CODOPER <= 499)
            {

                /*" -3696- COMPUTE WHOST-PRMVG = WHOST-PRMVG + V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG + V0DIFP_PRMDIFVG;

                /*" -3697- COMPUTE WHOST-PRMAP = WHOST-PRMAP + V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP + V0DIFP_PRMDIFAP;

                /*" -3699- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP. */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;
            }


            /*" -3699- MOVE V0DIFP-CODOPER TO V3DIFP-CODOPER. */
            _.Move(V0DIFP_CODOPER, V3DIFP_CODOPER);

        }

        [StopWatch]
        /*" R1500-10-UPDATE */
        private void R1500_10_UPDATE(bool isPerform = false)
        {
            /*" -3706- MOVE '1501' TO WNR-EXEC-SQL. */
            _.Move("1501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3711- PERFORM R1500_10_UPDATE_DB_UPDATE_1 */

            R1500_10_UPDATE_DB_UPDATE_1();

            /*" -3714- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3715- COMPUTE V3DIFP-CODOPER = V0DIFP-CODOPER + 10 */
                V3DIFP_CODOPER.Value = V0DIFP_CODOPER + 10;

                /*" -3716- GO TO R1500-10-UPDATE */
                new Task(() => R1500_10_UPDATE()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3717- ELSE */
            }
            else
            {


                /*" -3718- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3719- DISPLAY 'R1500-00 (ERRO - UPDATE CDIFPAR   )' */
                    _.Display($"R1500-00 (ERRO - UPDATE CDIFPAR   )");

                    /*" -3720- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF */
                    _.Display($"CERTIF: {V0PROP_NRCERTIF}");

                    /*" -3721- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -3723- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3725- MOVE 'ERRO NO UPDATE DA VIEW V0DIFPARCELVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO UPDATE DA VIEW V0DIFPARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3726- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -3726- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-10-UPDATE-DB-UPDATE-1 */
        public void R1500_10_UPDATE_DB_UPDATE_1()
        {
            /*" -3711- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0PROP-NRPARCEL, CODOPER = :V3DIFP-CODOPER WHERE CURRENT OF CDIFPAR END-EXEC. */

            var r1500_10_UPDATE_DB_UPDATE_1_Update1 = new R1500_10_UPDATE_DB_UPDATE_1_Update1(CDIFPAR)
            {
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V3DIFP_CODOPER = V3DIFP_CODOPER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            R1500_10_UPDATE_DB_UPDATE_1_Update1.Execute(r1500_10_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1500-20-LE-CDIFPAR */
        private void R1500_20_LE_CDIFPAR(bool isPerform = false)
        {
            /*" -3733- PERFORM R1510-00-FETCH-CDIFPAR. */

            R1510_00_FETCH_CDIFPAR_SECTION();

            /*" -3735- IF WFIM-CDIFPAR NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty())
            {

                /*" -3736- ELSE */
            }
            else
            {


                /*" -3736- GO TO R1500-10-LOOP-CDIFPAR. */

                R1500_10_LOOP_CDIFPAR(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-SECTION */
        private void R1510_00_FETCH_CDIFPAR_SECTION()
        {
            /*" -3746- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3752- PERFORM R1510_00_FETCH_CDIFPAR_DB_FETCH_1 */

            R1510_00_FETCH_CDIFPAR_DB_FETCH_1();

            /*" -3755- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3756- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3756- PERFORM R1510_00_FETCH_CDIFPAR_DB_CLOSE_1 */

                    R1510_00_FETCH_CDIFPAR_DB_CLOSE_1();

                    /*" -3758- MOVE 'S' TO WFIM-CDIFPAR */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFPAR);

                    /*" -3759- ELSE */
                }
                else
                {


                    /*" -3760- DISPLAY 'R1510-00 (ERRO -  FETCH CDIFPAR   )...' */
                    _.Display($"R1510-00 (ERRO -  FETCH CDIFPAR   )...");

                    /*" -3761- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -3763- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3765- MOVE 'ERRO NO FETCH DO CURSOR V0DIFPARCELVA - CDIFPAR' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO FETCH DO CURSOR V0DIFPARCELVA - CDIFPAR", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3766- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -3766- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-DB-FETCH-1 */
        public void R1510_00_FETCH_CDIFPAR_DB_FETCH_1()
        {
            /*" -3752- EXEC SQL FETCH CDIFPAR INTO :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0DIFP-VLPRMTOT, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP END-EXEC. */

            if (CDIFPAR.Fetch())
            {
                _.Move(CDIFPAR.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CDIFPAR.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CDIFPAR.V0DIFP_VLPRMTOT, V0DIFP_VLPRMTOT);
                _.Move(CDIFPAR.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CDIFPAR.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
            }

        }

        [StopWatch]
        /*" R1510-00-FETCH-CDIFPAR-DB-CLOSE-1 */
        public void R1510_00_FETCH_CDIFPAR_DB_CLOSE_1()
        {
            /*" -3756- EXEC SQL CLOSE CDIFPAR END-EXEC */

            CDIFPAR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-SECTION */
        private void R1600_00_VERIFICA_REPASSE_SECTION()
        {
            /*" -3779- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3785- PERFORM R1600_00_VERIFICA_REPASSE_DB_UPDATE_1 */

            R1600_00_VERIFICA_REPASSE_DB_UPDATE_1();

            /*" -3789- MOVE '1602' TO WNR-EXEC-SQL. */
            _.Move("1602", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3795- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_1 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_1();

            /*" -3798- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3800- PERFORM R1650-00-REPASSA-CDG. */

                R1650_00_REPASSA_CDG_SECTION();
            }


            /*" -3802- MOVE '1604' TO WNR-EXEC-SQL. */
            _.Move("1604", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3808- PERFORM R1600_00_VERIFICA_REPASSE_DB_SELECT_2 */

            R1600_00_VERIFICA_REPASSE_DB_SELECT_2();

            /*" -3811- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3812- IF V0PRDVG-TEM-SAF = 'S' */

                if (V0PRDVG_TEM_SAF == "S")
                {

                    /*" -3812- PERFORM R1670-00-REPASSA-SAF. */

                    R1670_00_REPASSA_SAF_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-UPDATE-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_UPDATE_1()
        {
            /*" -3785- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PROP-NRPARCEL AND SITUACAO = ' ' END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1 = new R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
            };

            R1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1.Execute(r1600_00_VERIFICA_REPASSE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-1 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_1()
        {
            /*" -3795- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-VERIFICA-REPASSE-DB-SELECT-2 */
        public void R1600_00_VERIFICA_REPASSE_DB_SELECT_2()
        {
            /*" -3808- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' ) END-EXEC. */

            var r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 = new R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1.Execute(r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-SECTION */
        private void R1650_00_REPASSA_CDG_SECTION()
        {
            /*" -3822- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -3824- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -3825- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -3826- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -3827- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -3829- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -3831- MOVE WDATA-SISTEMA TO V0RCDG-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RCDG_DTREFER);

            /*" -3833- MOVE '1650' TO WNR-EXEC-SQL. */
            _.Move("1650", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3839- PERFORM R1650_00_REPASSA_CDG_DB_SELECT_1 */

            R1650_00_REPASSA_CDG_DB_SELECT_1();

            /*" -3842- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3844- GO TO R1650-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3846- MOVE '1652' TO WNR-EXEC-SQL. */
            _.Move("1652", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3856- PERFORM R1650_00_REPASSA_CDG_DB_INSERT_1 */

            R1650_00_REPASSA_CDG_DB_INSERT_1();

            /*" -3859- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3860- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3862- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3864- MOVE 'ERRO NO INSERT DA VIEW V0REPASSECDG' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO INSERT DA VIEW V0REPASSECDG", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3865- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3865- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1650_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -3839- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

            var r1650_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R1650_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R1650_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r1650_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1650-00-REPASSA-CDG-DB-INSERT-1 */
        public void R1650_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -3856- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, '0' , :V1SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r1650_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R1650_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r1650_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-SECTION */
        private void R1670_00_REPASSA_SAF_SECTION()
        {
            /*" -3874- MOVE V0PROP-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -3876- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -3877- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -3878- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -3879- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -3881- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -3883- MOVE WDATA-SISTEMA TO V0RSAF-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RSAF_DTREFER);

            /*" -3885- MOVE '1670' TO WNR-EXEC-SQL. */
            _.Move("1670", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3891- PERFORM R1670_00_REPASSA_SAF_DB_SELECT_1 */

            R1670_00_REPASSA_SAF_DB_SELECT_1();

            /*" -3894- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3896- GO TO R1670-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3897- IF WREGULARIZOU EQUAL 'S' */

            if (AREA_DE_WORK.WREGULARIZOU == "S")
            {

                /*" -3898- MOVE 501 TO V0RSAF-CODOPER */
                _.Move(501, V0RSAF_CODOPER);

                /*" -3900- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

                R1675_00_INSERT_V0HISTREPSAF_SECTION();
            }


            /*" -3901- MOVE 1100 TO V0RSAF-CODOPER. */
            _.Move(1100, V0RSAF_CODOPER);

            /*" -3901- PERFORM R1675-00-INSERT-V0HISTREPSAF. */

            R1675_00_INSERT_V0HISTREPSAF_SECTION();

        }

        [StopWatch]
        /*" R1670-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1670_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -3891- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER END-EXEC. */

            var r1670_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R1670_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R1670_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r1670_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1670_99_SAIDA*/

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-SECTION */
        private void R1675_00_INSERT_V0HISTREPSAF_SECTION()
        {
            /*" -3911- MOVE '1675' TO WNR-EXEC-SQL. */
            _.Move("1675", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3927- PERFORM R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1 */

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1();

            /*" -3930- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3931- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -3933- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3935- MOVE 'ERRO NO INSERT DA VIEW V0HISTREPSAF' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO INSERT DA VIEW V0HISTREPSAF", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3936- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -3936- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1675-00-INSERT-V0HISTREPSAF-DB-INSERT-1 */
        public void R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1()
        {
            /*" -3927- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, :V0RSAF-CODOPER, '0' , '0' , 0, 0, 'VG0853B' , CURRENT TIMESTAMP, :V0PROP-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1 = new R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0RSAF_CODOPER = V0RSAF_CODOPER.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1.Execute(r1675_00_INSERT_V0HISTREPSAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1675_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-GERA-COBERPROPVA-SECTION */
        private void R1700_00_GERA_COBERPROPVA_SECTION()
        {
            /*" -3946- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3946- COMPUTE V0PROP-NRPARCEL-NEW = V0PROP-NRPARCEL + 1. */
            V0PROP_NRPARCEL_NEW.Value = V0PROP_NRPARCEL + 1;

            /*" -0- FLUXCONTROL_PERFORM R1700_10_LOOP */

            R1700_10_LOOP();

        }

        [StopWatch]
        /*" R1700-10-LOOP */
        private void R1700_10_LOOP(bool isPerform = false)
        {
            /*" -3958- PERFORM R1700_10_LOOP_DB_SELECT_1 */

            R1700_10_LOOP_DB_SELECT_1();

            /*" -3961- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3962- GO TO R1700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;

                /*" -3963- ELSE */
            }
            else
            {


                /*" -3965- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3966- ELSE */
                }
                else
                {


                    /*" -3968- DISPLAY 'R1700 - ERRO ACESSO COBERPROPVA  ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-NRPARCEL-NEW */

                    $"R1700 - ERRO ACESSO COBERPROPVA  {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_NRPARCEL_NEW}"
                    .Display();

                    /*" -3969- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -3971- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3973- MOVE 'ERRO ACESSO A VIEW V0COBERPROPVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO ACESSO A VIEW V0COBERPROPVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3974- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -3976- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3978- MOVE '170A' TO WNR-EXEC-SQL. */
            _.Move("170A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3980- MOVE V0PROP-OCORHIST TO V0PARC-NRPARCEL. */
            _.Move(V0PROP_OCORHIST, V0PARC_NRPARCEL);

            /*" -3986- PERFORM R1700_10_LOOP_DB_SELECT_2 */

            R1700_10_LOOP_DB_SELECT_2();

            /*" -3989- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3990- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3991- IF V0PARC-NRPARCEL EQUAL V0PROP-NRPARCEL-NEW */

                    if (V0PARC_NRPARCEL == V0PROP_NRPARCEL_NEW)
                    {

                        /*" -3992- MOVE V0PROP-DTPROXVEN TO V0PARC-DTVENCTO-PAR */
                        _.Move(V0PROP_DTPROXVEN, V0PARC_DTVENCTO_PAR);

                        /*" -3993- ELSE */
                    }
                    else
                    {


                        /*" -3994- IF V0PROP-NRPARCEL > 1 */

                        if (V0PROP_NRPARCEL > 1)
                        {

                            /*" -3995- SUBTRACT 1 FROM V0PROP-NRPARCEL */
                            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL - 1;

                            /*" -3996- GO TO R1700-00-GERA-COBERPROPVA */

                            R1700_00_GERA_COBERPROPVA_SECTION(); //GOTO
                            return;

                            /*" -3997- ELSE */
                        }
                        else
                        {


                            /*" -3999- DISPLAY 'ERRO NA BUSCA DA PARCELA ' V0PROP-NRCERTIF ' ' V0PARC-NRPARCEL */

                            $"ERRO NA BUSCA DA PARCELA {V0PROP_NRCERTIF} {V0PARC_NRPARCEL}"
                            .Display();

                            /*" -4000- PERFORM R1800-00-LIMPA-REGISTROS */

                            R1800_00_LIMPA_REGISTROS_SECTION();

                            /*" -4002- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                            _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                            /*" -4004- MOVE 'ERRO NA BUSCA DA PARCELA - VIEW V0PARCELVA' TO LD-DES-ERRO-SSAIDA */
                            _.Move("ERRO NA BUSCA DA PARCELA - VIEW V0PARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                            /*" -4005- PERFORM R1850-00-GRAVA-REGISTROS */

                            R1850_00_GRAVA_REGISTROS_SECTION();

                            /*" -4006- MOVE 'S' TO WS-DESPREZA */
                            _.Move("S", WS_DESPREZA);

                            /*" -4007- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                            _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                            /*" -4008- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                            _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                            /*" -4009- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                            _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                            /*" -4011- MOVE 'ERRO ** ERRO NA BUSCA DA PARCELA         ' TO REG-SAI-DESCRICAO */
                            _.Move("ERRO ** ERRO NA BUSCA DA PARCELA         ", REG_DET.REG_SAI_DESCRICAO);

                            /*" -4012- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                            _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                            /*" -4013- WRITE REG-SAIDA FROM REG-DET */
                            _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                            /*" -4015- GO TO R1700-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                            return;

                            /*" -4016- ELSE */
                        }

                    }

                }
                else
                {


                    /*" -4018- DISPLAY 'ERRO NO SELECT DA PARCELA ' V0PROP-NRCERTIF ' ' V0PARC-NRPARCEL */

                    $"ERRO NO SELECT DA PARCELA {V0PROP_NRCERTIF} {V0PARC_NRPARCEL}"
                    .Display();

                    /*" -4019- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -4021- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -4023- MOVE 'ERRO NA ACESSO A VIEW V0PARCELVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA ACESSO A VIEW V0PARCELVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -4024- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -4026- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4028- MOVE '170B' TO WNR-EXEC-SQL. */
            _.Move("170B", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4037- PERFORM R1700_10_LOOP_DB_SELECT_3 */

            R1700_10_LOOP_DB_SELECT_3();

            /*" -4040- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4041- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4043- MOVE '170C' TO WNR-EXEC-SQL */
                    _.Move("170C", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4051- PERFORM R1700_10_LOOP_DB_SELECT_4 */

                    R1700_10_LOOP_DB_SELECT_4();

                    /*" -4054- END-IF */
                }


                /*" -4055- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4056- DISPLAY 'R1700-00 (ERRO - SELECT V0OPCAOPAGVA)' */
                    _.Display($"R1700-00 (ERRO - SELECT V0OPCAOPAGVA)");

                    /*" -4058- DISPLAY 'CERTIF: ' V0PROP-NRCERTIF ' ' V0PARC-DTVENCTO-PAR */

                    $"CERTIF: {V0PROP_NRCERTIF} {V0PARC_DTVENCTO_PAR}"
                    .Display();

                    /*" -4059- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -4061- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -4063- MOVE 'ERRO NA ACESSO A VIEW V0OPCAOPAGVA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA ACESSO A VIEW V0OPCAOPAGVA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -4064- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -4065- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -4066- MOVE 'S' TO WS-DESPREZA */
                        _.Move("S", WS_DESPREZA);

                        /*" -4067- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                        _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                        /*" -4068- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                        _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                        /*" -4069- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                        /*" -4071- MOVE 'ERRO ** NAO CADASTRADO NA OPCAOPAGVI II     ' TO REG-SAI-DESCRICAO */
                        _.Move("ERRO ** NAO CADASTRADO NA OPCAOPAGVI II     ", REG_DET.REG_SAI_DESCRICAO);

                        /*" -4072- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                        _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                        /*" -4073- WRITE REG-SAIDA FROM REG-DET */
                        _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                        ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                        /*" -4074- GO TO R1700-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                        return;

                        /*" -4075- ELSE */
                    }
                    else
                    {


                        /*" -4076- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -4077- END-IF */
                    }


                    /*" -4078- END-IF */
                }


                /*" -4081- END-IF. */
            }


            /*" -4083- MOVE '1701' TO WNR-EXEC-SQL. */
            _.Move("1701", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4103- PERFORM R1700_10_LOOP_DB_SELECT_5 */

            R1700_10_LOOP_DB_SELECT_5();

            /*" -4106- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4126- PERFORM R1700_10_LOOP_DB_SELECT_6 */

                R1700_10_LOOP_DB_SELECT_6();

                /*" -4129- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -4150- PERFORM R1700_10_LOOP_DB_SELECT_7 */

                    R1700_10_LOOP_DB_SELECT_7();

                    /*" -4153- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -4155- DISPLAY 'R1700 - CERTIFICADO/APOLICE SEM COBERTURAS ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                        $"R1700 - CERTIFICADO/APOLICE SEM COBERTURAS {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                        .Display();

                        /*" -4156- PERFORM R1800-00-LIMPA-REGISTROS */

                        R1800_00_LIMPA_REGISTROS_SECTION();

                        /*" -4158- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -4160- MOVE 'CERTIFICADO/APOLICE SEM COBERTURA' TO LD-DES-ERRO-SSAIDA */
                        _.Move("CERTIFICADO/APOLICE SEM COBERTURA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -4161- PERFORM R1850-00-GRAVA-REGISTROS */

                        R1850_00_GRAVA_REGISTROS_SECTION();

                        /*" -4162- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -4163- MOVE 'S' TO WS-DESPREZA */
                            _.Move("S", WS_DESPREZA);

                            /*" -4164- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                            _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                            /*" -4165- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                            _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                            /*" -4166- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                            _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                            /*" -4168- MOVE 'ERRO ** NAO CADASTRADO NA HISCOBPR II       ' TO REG-SAI-DESCRICAO */
                            _.Move("ERRO ** NAO CADASTRADO NA HISCOBPR II       ", REG_DET.REG_SAI_DESCRICAO);

                            /*" -4169- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                            _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                            /*" -4170- WRITE REG-SAIDA FROM REG-DET */
                            _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                            /*" -4171- GO TO R1700-99-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                            return;

                            /*" -4172- ELSE */
                        }
                        else
                        {


                            /*" -4174- GO TO R9999-00-ROT-ERRO. */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -4176- IF WHOST-DTTERVIG-ORIG EQUAL '9999-12-31' NEXT SENTENCE */

            if (WHOST_DTTERVIG_ORIG == "9999-12-31")
            {

                /*" -4177- ELSE */
            }
            else
            {


                /*" -4178- MOVE WHOST-DTTERVIG-ORIG TO WHOST-DTTERVIG */
                _.Move(WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG);

                /*" -4180- MOVE WHOST-DTINIVIG-NEW2 TO WHOST-DTINIVIG-NEW. */
                _.Move(WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW);
            }


            /*" -4182- MOVE '1702' TO WNR-EXEC-SQL. */
            _.Move("1702", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4248- PERFORM R1700_10_LOOP_DB_SELECT_8 */

            R1700_10_LOOP_DB_SELECT_8();

            /*" -4251- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4253- DISPLAY 'R1700 - CERTIFICADO/APOLICE SEM COBERTURA  ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                $"R1700 - CERTIFICADO/APOLICE SEM COBERTURA  {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                .Display();

                /*" -4254- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4256- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4258- MOVE 'CERTIFICADO/APOLICE SEM COBERTURA' TO LD-DES-ERRO-SSAIDA */
                _.Move("CERTIFICADO/APOLICE SEM COBERTURA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4259- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4260- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4261- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -4262- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                    _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                    /*" -4263- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                    _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                    /*" -4264- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                    _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                    /*" -4266- MOVE 'ERRO ** NAO CADASTRADO NA HISCOBPR III      ' TO REG-SAI-DESCRICAO */
                    _.Move("ERRO ** NAO CADASTRADO NA HISCOBPR III      ", REG_DET.REG_SAI_DESCRICAO);

                    /*" -4267- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                    _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                    /*" -4268- WRITE REG-SAIDA FROM REG-DET */
                    _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                    ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                    /*" -4269- GO TO R1700-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                    return;

                    /*" -4270- ELSE */
                }
                else
                {


                    /*" -4272- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4274- MOVE '1703' TO WNR-EXEC-SQL. */
            _.Move("1703", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4279- PERFORM R1700_10_LOOP_DB_UPDATE_1 */

            R1700_10_LOOP_DB_UPDATE_1();

            /*" -4282- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4284- DISPLAY 'R1700 - ERRO UPDATE ULTIMO OCORHIST ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                $"R1700 - ERRO UPDATE ULTIMO OCORHIST {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                .Display();

                /*" -4285- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4287- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4289- MOVE 'ERRO NO UPDATE DA TABELA HIS_COBER_PROPOST' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA TABELA HIS_COBER_PROPOST", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4290- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4292- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4294- MOVE '1704' TO WNR-EXEC-SQL. */
            _.Move("1704", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4296- COMPUTE V0PROP-OCORHIST = V0PROP-OCORHIST + 1. */
            V0PROP_OCORHIST.Value = V0PROP_OCORHIST + 1;

            /*" -4298- MOVE V0PROP-OCORHIST TO HISCOBPR-OCORR-HISTORICO. */
            _.Move(V0PROP_OCORHIST, HISCOBPR_OCORR_HISTORICO);

            /*" -4299- MOVE WHOST-DTINIVIG-NEW TO HISCOBPR-DATA-INIVIGENCIA. */
            _.Move(WHOST_DTINIVIG_NEW, HISCOBPR_DATA_INIVIGENCIA);

            /*" -4300- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA. */
            _.Move("9999-12-31", HISCOBPR_DATA_TERVIGENCIA);

            /*" -4301- MOVE 'VG0853B' TO HISCOBPR-COD-USUARIO. */
            _.Move("VG0853B", HISCOBPR_COD_USUARIO);

            /*" -4303- MOVE ZEROS TO HISCOBPR-COD-OPERACAO. */
            _.Move(0, HISCOBPR_COD_OPERACAO);

            /*" -4367- PERFORM R1700_10_LOOP_DB_INSERT_1 */

            R1700_10_LOOP_DB_INSERT_1();

            /*" -4371- IF SQLCODE NOT EQUAL ZEROES AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -4373- DISPLAY 'R1700 - ERRO INSERT NOVA COBERPROPVA       ' SQLCODE ' ' V0PROP-NRCERTIF ' ' V0PROP-OCORHIST */

                $"R1700 - ERRO INSERT NOVA COBERPROPVA       {DB.SQLCODE} {V0PROP_NRCERTIF} {V0PROP_OCORHIST}"
                .Display();

                /*" -4374- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4376- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4378- MOVE 'ERRO NO INSERT DA TABELA HIS_COBER_PROPOST' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO INSERT DA TABELA HIS_COBER_PROPOST", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4379- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4381- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4382- IF V0PROP-OCORHIST LESS V0PROP-NRPARCEL-NEW */

            if (V0PROP_OCORHIST < V0PROP_NRPARCEL_NEW)
            {

                /*" -4382- GO TO R1700-10-LOOP. */
                new Task(() => R1700_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-1 */
        public void R1700_10_LOOP_DB_SELECT_1()
        {
            /*" -3958- EXEC SQL SELECT DTINIVIG INTO :WHOST-DTINIVIG FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-NRPARCEL-NEW END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_1_Query1 = new R1700_10_LOOP_DB_SELECT_1_Query1()
            {
                V0PROP_NRPARCEL_NEW = V0PROP_NRPARCEL_NEW.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_1_Query1.Execute(r1700_10_LOOP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-2 */
        public void R1700_10_LOOP_DB_SELECT_2()
        {
            /*" -3986- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO-PAR FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND NRPARCEL = :V0PARC-NRPARCEL END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_2_Query1 = new R1700_10_LOOP_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_2_Query1.Execute(r1700_10_LOOP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO_PAR, V0PARC_DTVENCTO_PAR);
            }


        }

        [StopWatch]
        /*" R1800-00-LIMPA-REGISTROS-SECTION */
        private void R1800_00_LIMPA_REGISTROS_SECTION()
        {
            /*" -4396- MOVE ZEROS TO LD-NUM-APOL-SSAIDA LD-COD-SUBG-SSAIDA LD-COD-PROD-SSAIDA LD-NUM-CERT-SUB-SSAIDA LD-NUM-CERT-SEG-SSAIDA LD-COD-ERRO-DB2-SSAIDA. */
            _.Move(0, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

            /*" -4400- MOVE SPACES TO LD-NOM-PROD-SSAIDA LD-DES-ERRO-DB2-SSAIDA LD-DES-ERRO-SSAIDA. */
            _.Move("", AREA_DE_WORK.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_DB2_SSAIDA, AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

            /*" -4405- MOVE ZEROS TO LD-NUM-APOL-DSAIDA LD-COD-SUBG-DSAIDA LD-COD-PROD-DSAIDA LD-NUM-CERT-SUB-DSAIDA LD-NUM-CERT-SEG-DSAIDA. */
            _.Move(0, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

            /*" -4406- MOVE SPACES TO LD-NOM-PROD-DSAIDA LD-DES-ERRO-DSAIDA. */
            _.Move("", AREA_DE_WORK.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA, AREA_DE_WORK.LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-3 */
        public void R1700_10_LOOP_DB_SELECT_3()
        {
            /*" -4037- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO-ANT FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-PAR AND DTTERVIG >= :V0PARC-DTVENCTO-PAR END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_3_Query1 = new R1700_10_LOOP_DB_SELECT_3_Query1()
            {
                V0PARC_DTVENCTO_PAR = V0PARC_DTVENCTO_PAR.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_3_Query1.Execute(r1700_10_LOOP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO_ANT, V0OPCP_PERIPGTO_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-4 */
        public void R1700_10_LOOP_DB_SELECT_4()
        {
            /*" -4051- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO-ANT FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC */

            var r1700_10_LOOP_DB_SELECT_4_Query1 = new R1700_10_LOOP_DB_SELECT_4_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_4_Query1.Execute(r1700_10_LOOP_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO_ANT, V0OPCP_PERIPGTO_ANT);
            }


        }

        [StopWatch]
        /*" R1850-00-GRAVA-REGISTROS-SECTION */
        private void R1850_00_GRAVA_REGISTROS_SECTION()
        {
            /*" -4416- IF LD-DES-ERRO-SSAIDA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA.IsEmpty())
            {

                /*" -4418- MOVE V0PROP-NUM-APOLICE TO LD-NUM-APOL-SSAIDA */
                _.Move(V0PROP_NUM_APOLICE, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA);

                /*" -4420- MOVE V0PROP-CODSUBES TO LD-COD-SUBG-SSAIDA */
                _.Move(V0PROP_CODSUBES, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA);

                /*" -4423- MOVE V0PROP-CODPRODU TO LD-COD-PROD-SSAIDA */
                _.Move(V0PROP_CODPRODU, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_PROD_SSAIDA);

                /*" -4425- IF V0PROP-DTPROXVEN NOT EQUAL '9999-12-31' AND V0PROP-CODSUBES EQUAL ZEROS */

                if (V0PROP_DTPROXVEN != "9999-12-31" && V0PROP_CODSUBES == 00)
                {

                    /*" -4427- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SUB-SSAIDA */
                    _.Move(V0PROP_NRCERTIF, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA);

                    /*" -4428- ELSE */
                }
                else
                {


                    /*" -4430- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SEG-SSAIDA */
                    _.Move(V0PROP_NRCERTIF, AREA_DE_WORK.LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA);

                    /*" -4432- END-IF */
                }


                /*" -4434- MOVE V0PRDVG-NOMPRODU TO LD-NOM-PROD-SSAIDA */
                _.Move(V0PRDVG_NOMPRODU, AREA_DE_WORK.LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA);

                /*" -4435- WRITE RECORD-SSAIDA FROM LD-REG-SSAIDA */
                _.Move(AREA_DE_WORK.LD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -4436- ADD 1 TO AC-ERRO-SISTEMA */
                AREA_DE_WORK.AC_ERRO_SISTEMA.Value = AREA_DE_WORK.AC_ERRO_SISTEMA + 1;

                /*" -4437- ELSE */
            }
            else
            {


                /*" -4439- MOVE V0PROP-NUM-APOLICE TO LD-NUM-APOL-DSAIDA */
                _.Move(V0PROP_NUM_APOLICE, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA);

                /*" -4441- MOVE V0PROP-CODSUBES TO LD-COD-SUBG-DSAIDA */
                _.Move(V0PROP_CODSUBES, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA);

                /*" -4444- MOVE V0PROP-CODPRODU TO LD-COD-PROD-DSAIDA */
                _.Move(V0PROP_CODPRODU, AREA_DE_WORK.LD_REG_DSAIDA.LD_COD_PROD_DSAIDA);

                /*" -4446- IF V0PROP-DTPROXVEN NOT EQUAL '9999-12-31' AND V0PROP-CODSUBES EQUAL ZEROS */

                if (V0PROP_DTPROXVEN != "9999-12-31" && V0PROP_CODSUBES == 00)
                {

                    /*" -4448- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SUB-DSAIDA */
                    _.Move(V0PROP_NRCERTIF, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA);

                    /*" -4449- ELSE */
                }
                else
                {


                    /*" -4451- MOVE V0PROP-NRCERTIF TO LD-NUM-CERT-SEG-DSAIDA */
                    _.Move(V0PROP_NRCERTIF, AREA_DE_WORK.LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

                    /*" -4453- END-IF */
                }


                /*" -4455- MOVE V0PRDVG-NOMPRODU TO LD-NOM-PROD-DSAIDA */
                _.Move(V0PRDVG_NOMPRODU, AREA_DE_WORK.LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA);

                /*" -4456- WRITE RECORD-DSAIDA FROM LD-REG-DSAIDA */
                _.Move(AREA_DE_WORK.LD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -4457- ADD 1 TO AC-ERRO-DADOS */
                AREA_DE_WORK.AC_ERRO_DADOS.Value = AREA_DE_WORK.AC_ERRO_DADOS + 1;

                /*" -4457- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-UPDATE-1 */
        public void R1700_10_LOOP_DB_UPDATE_1()
        {
            /*" -4279- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = :WHOST-DTTERVIG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND OCORR_HISTORICO = :V0PROP-OCORHIST END-EXEC. */

            var r1700_10_LOOP_DB_UPDATE_1_Update1 = new R1700_10_LOOP_DB_UPDATE_1_Update1()
            {
                WHOST_DTTERVIG = WHOST_DTTERVIG.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            R1700_10_LOOP_DB_UPDATE_1_Update1.Execute(r1700_10_LOOP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-INSERT-1 */
        public void R1700_10_LOOP_DB_INSERT_1()
        {
            /*" -4367- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST ( NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) VALUES ( :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO , :HISCOBPR-OPCAO-COBERTURA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ , :HISCOBPR-VAL-TIT-CAPITALIZ , :HISCOBPR-VAL-CUSTO-CAPITALI , :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO , CURRENT TIMESTAMP , :HISCOBPR-IMPSEGAUXF :HISCOBPR-IMPSEGAUXF-I , :HISCOBPR-VLCUSTAUXF :HISCOBPR-VLCUSTAUXF-I , :HISCOBPR-PRMDIT :HISCOBPR-PRMDIT-I , :HISCOBPR-QTMDIT :HISCOBPR-QTMDIT-I) END-EXEC. */

            var r1700_10_LOOP_DB_INSERT_1_Insert1 = new R1700_10_LOOP_DB_INSERT_1_Insert1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR_NUM_CERTIFICADO.ToString(),
                HISCOBPR_OCORR_HISTORICO = HISCOBPR_OCORR_HISTORICO.ToString(),
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR_DATA_INIVIGENCIA.ToString(),
                HISCOBPR_DATA_TERVIGENCIA = HISCOBPR_DATA_TERVIGENCIA.ToString(),
                HISCOBPR_IMPSEGUR = HISCOBPR_IMPSEGUR.ToString(),
                HISCOBPR_QUANT_VIDAS = HISCOBPR_QUANT_VIDAS.ToString(),
                HISCOBPR_IMPSEGIND = HISCOBPR_IMPSEGIND.ToString(),
                HISCOBPR_COD_OPERACAO = HISCOBPR_COD_OPERACAO.ToString(),
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR_OPCAO_COBERTURA.ToString(),
                HISCOBPR_IMP_MORNATU = HISCOBPR_IMP_MORNATU.ToString(),
                HISCOBPR_IMPMORACID = HISCOBPR_IMPMORACID.ToString(),
                HISCOBPR_IMPINVPERM = HISCOBPR_IMPINVPERM.ToString(),
                HISCOBPR_IMPAMDS = HISCOBPR_IMPAMDS.ToString(),
                HISCOBPR_IMPDH = HISCOBPR_IMPDH.ToString(),
                HISCOBPR_IMPDIT = HISCOBPR_IMPDIT.ToString(),
                HISCOBPR_VLPREMIO = HISCOBPR_VLPREMIO.ToString(),
                HISCOBPR_PRMVG = HISCOBPR_PRMVG.ToString(),
                HISCOBPR_PRMAP = HISCOBPR_PRMAP.ToString(),
                HISCOBPR_QTDE_TIT_CAPITALIZ = HISCOBPR_QTDE_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_TIT_CAPITALIZ = HISCOBPR_VAL_TIT_CAPITALIZ.ToString(),
                HISCOBPR_VAL_CUSTO_CAPITALI = HISCOBPR_VAL_CUSTO_CAPITALI.ToString(),
                HISCOBPR_IMPSEGCDG = HISCOBPR_IMPSEGCDG.ToString(),
                HISCOBPR_VLCUSTCDG = HISCOBPR_VLCUSTCDG.ToString(),
                HISCOBPR_COD_USUARIO = HISCOBPR_COD_USUARIO.ToString(),
                HISCOBPR_IMPSEGAUXF = HISCOBPR_IMPSEGAUXF.ToString(),
                HISCOBPR_IMPSEGAUXF_I = HISCOBPR_IMPSEGAUXF_I.ToString(),
                HISCOBPR_VLCUSTAUXF = HISCOBPR_VLCUSTAUXF.ToString(),
                HISCOBPR_VLCUSTAUXF_I = HISCOBPR_VLCUSTAUXF_I.ToString(),
                HISCOBPR_PRMDIT = HISCOBPR_PRMDIT.ToString(),
                HISCOBPR_PRMDIT_I = HISCOBPR_PRMDIT_I.ToString(),
                HISCOBPR_QTMDIT = HISCOBPR_QTMDIT.ToString(),
                HISCOBPR_QTMDIT_I = HISCOBPR_QTMDIT_I.ToString(),
            };

            R1700_10_LOOP_DB_INSERT_1_Insert1.Execute(r1700_10_LOOP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-5 */
        public void R1700_10_LOOP_DB_SELECT_5()
        {
            /*" -4103- EXEC SQL SELECT DTINIVIG, DTTERVIG, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH, CASE WHEN DTTERVIG <> '9999-12-31' THEN (DTTERVIG + 1 DAY) ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH END INTO :WHOST-DTINIVIG, :WHOST-DTTERVIG-ORIG, :WHOST-DTTERVIG, :WHOST-DTINIVIG-NEW, :WHOST-DTINIVIG-NEW2 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_5_Query1 = new R1700_10_LOOP_DB_SELECT_5_Query1()
            {
                V0OPCP_PERIPGTO_ANT = V0OPCP_PERIPGTO_ANT.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_5_Query1.Execute(r1700_10_LOOP_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG_ORIG);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
                _.Move(executed_1.WHOST_DTINIVIG_NEW, WHOST_DTINIVIG_NEW);
                _.Move(executed_1.WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1850_99_SAIDA*/

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-6 */
        public void R1700_10_LOOP_DB_SELECT_6()
        {
            /*" -4126- EXEC SQL SELECT DTINIVIG, DTTERVIG, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH, CASE WHEN DTTERVIG <> '9999-12-31' THEN (DTTERVIG + 1 DAY) ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH END INTO :WHOST-DTINIVIG, :WHOST-DTTERVIG-ORIG, :WHOST-DTTERVIG, :WHOST-DTINIVIG-NEW, :WHOST-DTINIVIG-NEW2 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_6_Query1 = new R1700_10_LOOP_DB_SELECT_6_Query1()
            {
                V0OPCP_PERIPGTO_ANT = V0OPCP_PERIPGTO_ANT.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_6_Query1.Execute(r1700_10_LOOP_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG_ORIG);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
                _.Move(executed_1.WHOST_DTINIVIG_NEW, WHOST_DTINIVIG_NEW);
                _.Move(executed_1.WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW2);
            }


        }

        [StopWatch]
        /*" R2000-00-RECOMANDAR-DEB-ANT-SECTION */
        private void R2000_00_RECOMANDAR_DEB_ANT_SECTION()
        {
            /*" -4471- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4473- MOVE SPACES TO WFIM-CDEBANT */
            _.Move("", AREA_DE_WORK.WFIM_CDEBANT);

            /*" -4478- PERFORM R2000_00_RECOMANDAR_DEB_ANT_DB_SELECT_1 */

            R2000_00_RECOMANDAR_DEB_ANT_DB_SELECT_1();

            /*" -4481- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4482- DISPLAY 'PROBLEMAS CALCULO DTVENC - 2 MESES ' */
                _.Display($"PROBLEMAS CALCULO DTVENC - 2 MESES ");

                /*" -4483- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4484- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4486- MOVE 'ERRO CALCULO DTVENC - 2 MESES ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO CALCULO DTVENC - 2 MESES ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4487- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4488- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4490- END-IF. */
            }


            /*" -4527- PERFORM R2000_00_RECOMANDAR_DEB_ANT_DB_DECLARE_1 */

            R2000_00_RECOMANDAR_DEB_ANT_DB_DECLARE_1();

            /*" -4529- PERFORM R2000_00_RECOMANDAR_DEB_ANT_DB_OPEN_1 */

            R2000_00_RECOMANDAR_DEB_ANT_DB_OPEN_1();

            /*" -4532- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4533- DISPLAY 'PROBLEMAS NO OPEN CURSOR CDEBANT ' */
                _.Display($"PROBLEMAS NO OPEN CURSOR CDEBANT ");

                /*" -4534- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4535- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4537- MOVE 'ERRO NO ABERTURA CURSOR CDEBANT  ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ABERTURA CURSOR CDEBANT  ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4538- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4539- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4541- END-IF */
            }


            /*" -4543- PERFORM R2100-00-FETCH-CDEBANT. */

            R2100_00_FETCH_CDEBANT_SECTION();

            /*" -4545- PERFORM R2500-00-PROCESSA-DEB-ANTERIOR UNTIL WFIM-CDEBANT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CDEBANT == "S"))
            {

                R2500_00_PROCESSA_DEB_ANTERIOR_SECTION();
            }

        }

        [StopWatch]
        /*" R2000-00-RECOMANDAR-DEB-ANT-DB-SELECT-1 */
        public void R2000_00_RECOMANDAR_DEB_ANT_DB_SELECT_1()
        {
            /*" -4478- EXEC SQL SELECT DATE(:V0PROP-DTVENCTO) - 2 MONTHS INTO :V0PROP-DTVENCTO-2M FROM SYSIBM.SYSDUMMY1 WITH UR END-EXEC. */

            /*-- linha suprimida por comandos abaixo EXEC SQL
            /*--SELECT DATE(:V0PROP-DTVENCTO) - 2 MONTHS
            /*--INTO :V0PROP-DTVENCTO-2M
            /*--FROM SYSIBM.SYSDUMMY1
            /*--WITH UR
            /*--END-EXEC.
            /*-- */

            _.Move(V0PROP_DTVENCTO.ToDateTime().AddMonths(-2).ToString(_.CurrentDateFormat), V0PROP_DTVENCTO_2M);

        }

        [StopWatch]
        /*" R2000-00-RECOMANDAR-DEB-ANT-DB-OPEN-1 */
        public void R2000_00_RECOMANDAR_DEB_ANT_DB_OPEN_1()
        {
            /*" -4529- EXEC SQL OPEN CDEBANT END-EXEC. */

            CDEBANT.Open();

        }

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-7 */
        public void R1700_10_LOOP_DB_SELECT_7()
        {
            /*" -4150- EXEC SQL SELECT DTINIVIG, DTTERVIG, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH - 1 DAY, DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH, CASE WHEN DTTERVIG <> '9999-12-31' THEN (DTTERVIG + 1 DAY) ELSE DTINIVIG + :V0OPCP-PERIPGTO-ANT MONTH END INTO :WHOST-DTINIVIG, :WHOST-DTTERVIG-ORIG, :WHOST-DTTERVIG, :WHOST-DTINIVIG-NEW, :WHOST-DTINIVIG-NEW2 FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO-PAR AND DTTERVIG >= :V0PARC-DTVENCTO-PAR END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_7_Query1 = new R1700_10_LOOP_DB_SELECT_7_Query1()
            {
                V0PARC_DTVENCTO_PAR = V0PARC_DTVENCTO_PAR.ToString(),
                V0OPCP_PERIPGTO_ANT = V0OPCP_PERIPGTO_ANT.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_7_Query1.Execute(r1700_10_LOOP_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTTERVIG_ORIG, WHOST_DTTERVIG_ORIG);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
                _.Move(executed_1.WHOST_DTINIVIG_NEW, WHOST_DTINIVIG_NEW);
                _.Move(executed_1.WHOST_DTINIVIG_NEW2, WHOST_DTINIVIG_NEW2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R1700-10-LOOP-DB-SELECT-8 */
        public void R1700_10_LOOP_DB_SELECT_8()
        {
            /*" -4248- EXEC SQL SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ , VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI , IMPSEGCDG , VLCUSTCDG , COD_USUARIO , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMPSEGUR , :HISCOBPR-QUANT-VIDAS , :HISCOBPR-IMPSEGIND , :HISCOBPR-COD-OPERACAO , :HISCOBPR-OPCAO-COBERTURA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM , :HISCOBPR-IMPAMDS , :HISCOBPR-IMPDH , :HISCOBPR-IMPDIT , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-QTDE-TIT-CAPITALIZ , :HISCOBPR-VAL-TIT-CAPITALIZ , :HISCOBPR-VAL-CUSTO-CAPITALI , :HISCOBPR-IMPSEGCDG , :HISCOBPR-VLCUSTCDG , :HISCOBPR-COD-USUARIO , :HISCOBPR-IMPSEGAUXF :HISCOBPR-IMPSEGAUXF-I , :HISCOBPR-VLCUSTAUXF :HISCOBPR-VLCUSTAUXF-I , :HISCOBPR-PRMDIT :HISCOBPR-PRMDIT-I , :HISCOBPR-QTMDIT :HISCOBPR-QTMDIT-I FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND OCORR_HISTORICO = :V0PROP-OCORHIST END-EXEC. */

            var r1700_10_LOOP_DB_SELECT_8_Query1 = new R1700_10_LOOP_DB_SELECT_8_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = R1700_10_LOOP_DB_SELECT_8_Query1.Execute(r1700_10_LOOP_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_NUM_CERTIFICADO, HISCOBPR_NUM_CERTIFICADO);
                _.Move(executed_1.HISCOBPR_OCORR_HISTORICO, HISCOBPR_OCORR_HISTORICO);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR_DATA_TERVIGENCIA);
                _.Move(executed_1.HISCOBPR_IMPSEGUR, HISCOBPR_IMPSEGUR);
                _.Move(executed_1.HISCOBPR_QUANT_VIDAS, HISCOBPR_QUANT_VIDAS);
                _.Move(executed_1.HISCOBPR_IMPSEGIND, HISCOBPR_IMPSEGIND);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPMORACID, HISCOBPR_IMPMORACID);
                _.Move(executed_1.HISCOBPR_IMPINVPERM, HISCOBPR_IMPINVPERM);
                _.Move(executed_1.HISCOBPR_IMPAMDS, HISCOBPR_IMPAMDS);
                _.Move(executed_1.HISCOBPR_IMPDH, HISCOBPR_IMPDH);
                _.Move(executed_1.HISCOBPR_IMPDIT, HISCOBPR_IMPDIT);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_QTDE_TIT_CAPITALIZ, HISCOBPR_QTDE_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_TIT_CAPITALIZ, HISCOBPR_VAL_TIT_CAPITALIZ);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR_VAL_CUSTO_CAPITALI);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLCUSTCDG, HISCOBPR_VLCUSTCDG);
                _.Move(executed_1.HISCOBPR_COD_USUARIO, HISCOBPR_COD_USUARIO);
                _.Move(executed_1.HISCOBPR_IMPSEGAUXF, HISCOBPR_IMPSEGAUXF);
                _.Move(executed_1.HISCOBPR_IMPSEGAUXF_I, HISCOBPR_IMPSEGAUXF_I);
                _.Move(executed_1.HISCOBPR_VLCUSTAUXF, HISCOBPR_VLCUSTAUXF);
                _.Move(executed_1.HISCOBPR_VLCUSTAUXF_I, HISCOBPR_VLCUSTAUXF_I);
                _.Move(executed_1.HISCOBPR_PRMDIT, HISCOBPR_PRMDIT);
                _.Move(executed_1.HISCOBPR_PRMDIT_I, HISCOBPR_PRMDIT_I);
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR_QTMDIT);
                _.Move(executed_1.HISCOBPR_QTMDIT_I, HISCOBPR_QTMDIT_I);
            }


        }

        [StopWatch]
        /*" R2100-00-FETCH-CDEBANT-SECTION */
        private void R2100_00_FETCH_CDEBANT_SECTION()
        {
            /*" -4556- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4571- PERFORM R2100_00_FETCH_CDEBANT_DB_FETCH_1 */

            R2100_00_FETCH_CDEBANT_DB_FETCH_1();

            /*" -4574- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4575- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -4575- PERFORM R2100_00_FETCH_CDEBANT_DB_CLOSE_1 */

                    R2100_00_FETCH_CDEBANT_DB_CLOSE_1();

                    /*" -4577- MOVE 'S' TO WFIM-CDEBANT */
                    _.Move("S", AREA_DE_WORK.WFIM_CDEBANT);

                    /*" -4578- ELSE */
                }
                else
                {


                    /*" -4579- DISPLAY 'R2100-00 (ERRO - FETCH CDEBANT )...' */
                    _.Display($"R2100-00 (ERRO - FETCH CDEBANT )...");

                    /*" -4580- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -4581- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -4583- MOVE 'ERRO FETCH CURSOR HISLANCT - CDEBANT' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO FETCH CURSOR HISLANCT - CDEBANT", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -4584- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -4585- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4586- END-IF */
                }


                /*" -4587- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-FETCH-CDEBANT-DB-FETCH-1 */
        public void R2100_00_FETCH_CDEBANT_DB_FETCH_1()
        {
            /*" -4571- EXEC SQL FETCH CDEBANT INTO :HISLANCT-NUM-CERTIFICADO, :HISLANCT-NUM-PARCELA, :HISLANCT-OCORR-HISTORICOCTA, :HISLANCT-COD-AGENCIA-DEBITO, :HISLANCT-OPE-CONTA-DEBITO, :HISLANCT-NUM-CONTA-DEBITO, :HISLANCT-DIG-CONTA-DEBITO, :HISLANCT-DATA-VENCIMENTO, :HISLANCT-PRM-TOTAL, :HISLANCT-TIPLANC, :HISLANCT-OCORR-HISTORICO, :HISLANCT-CODCONV, :HISLANCT-CODRET END-EXEC. */

            if (CDEBANT.Fetch())
            {
                _.Move(CDEBANT.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(CDEBANT.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(CDEBANT.HISLANCT_OCORR_HISTORICOCTA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA);
                _.Move(CDEBANT.HISLANCT_COD_AGENCIA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO);
                _.Move(CDEBANT.HISLANCT_OPE_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO);
                _.Move(CDEBANT.HISLANCT_NUM_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO);
                _.Move(CDEBANT.HISLANCT_DIG_CONTA_DEBITO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO);
                _.Move(CDEBANT.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(CDEBANT.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(CDEBANT.HISLANCT_TIPLANC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);
                _.Move(CDEBANT.HISLANCT_OCORR_HISTORICO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO);
                _.Move(CDEBANT.HISLANCT_CODCONV, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);
                _.Move(CDEBANT.HISLANCT_CODRET, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);
            }

        }

        [StopWatch]
        /*" R2100-00-FETCH-CDEBANT-DB-CLOSE-1 */
        public void R2100_00_FETCH_CDEBANT_DB_CLOSE_1()
        {
            /*" -4575- EXEC SQL CLOSE CDEBANT END-EXEC */

            CDEBANT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-PROCESSA-DEB-ANTERIOR-SECTION */
        private void R2500_00_PROCESSA_DEB_ANTERIOR_SECTION()
        {
            /*" -4597- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4601- IF (V0PROP-CODPRODU EQUAL 9311 OR 8203 OR 9354 OR JVPROD(8203) OR JVPROD(9311) ) AND (HISLANCT-CODRET NOT EQUAL 1) */

            if ((V0PROP_CODPRODU.In("9311", "8203", "9354", JVBKINCL.FILLER.JVPROD[8203].ToString(), JVBKINCL.FILLER.JVPROD[9311].ToString())) && (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET != 1))
            {

                /*" -4607- DISPLAY 'NAO RECOMANDAR CODRET <> 1 -> ' ' ' HISLANCT-NUM-CERTIFICADO ' ' HISLANCT-NUM-PARCELA ' ' V0PROP-CODPRODU ' ' V0PROP-DTVENCTO-2M ' ' V0PROP-DTVENCTO */

                $"NAO RECOMANDAR CODRET <> 1 ->  {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO} {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA} {V0PROP_CODPRODU} {V0PROP_DTVENCTO_2M} {V0PROP_DTVENCTO}"
                .Display();

                /*" -4608- GO TO R2500-50-FETCH */

                R2500_50_FETCH(); //GOTO
                return;

                /*" -4610- END-IF */
            }


            /*" -4617- DISPLAY 'RECOMANDAR DEB.SAP -> ' ' ' HISLANCT-NUM-CERTIFICADO ' ' HISLANCT-NUM-PARCELA ' ' V0PROP-CODPRODU ' ' V0PROP-DTVENCTO-2M ' ' V0PROP-DTVENCTO */

            $"RECOMANDAR DEB.SAP ->  {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO} {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA} {V0PROP_CODPRODU} {V0PROP_DTVENCTO_2M} {V0PROP_DTVENCTO}"
            .Display();

            /*" -4659- PERFORM R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1 */

            R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1();

            /*" -4662- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4663- DISPLAY 'R2500-00 (ERRO - INSERT HIST_LANC_CTA) ' */
                _.Display($"R2500-00 (ERRO - INSERT HIST_LANC_CTA) ");

                /*" -4666- DISPLAY ' CERTIF: ' HISLANCT-NUM-CERTIFICADO ' PARCEL: ' HISLANCT-NUM-PARCELA ' OCORR: ' HISLANCT-OCORR-HISTORICOCTA */

                $" CERTIF: {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO} PARCEL: {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA} OCORR: {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA}"
                .Display();

                /*" -4667- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4668- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4670- MOVE 'ERRO INSERT DA TABLE HIST_LANC_CTA ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO INSERT DA TABLE HIST_LANC_CTA ", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4671- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4672- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4674- END-IF. */
            }


            /*" -4676- PERFORM R2600-00-UPDATE-COBERHISTVA. */

            R2600_00_UPDATE_COBERHISTVA_SECTION();

            /*" -4677- PERFORM R2700-00-UPDATE-HISTLANCCTA. */

            R2700_00_UPDATE_HISTLANCCTA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R2500_50_FETCH */

            R2500_50_FETCH();

        }

        [StopWatch]
        /*" R2500-00-PROCESSA-DEB-ANTERIOR-DB-INSERT-1 */
        public void R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1()
        {
            /*" -4659- EXEC SQL INSERT INTO SEGUROS.HIST_LANC_CTA (NUM_CERTIFICADO ,NUM_PARCELA ,OCORR_HISTORICOCTA ,COD_AGENCIA_DEBITO ,OPE_CONTA_DEBITO ,NUM_CONTA_DEBITO ,DIG_CONTA_DEBITO ,DATA_VENCIMENTO ,PRM_TOTAL ,SIT_REGISTRO ,TIPLANC ,TIMESTAMP ,OCORR_HISTORICO ,CODCONV ,NSAS ,NSL ,NSAC ,CODRET ,COD_USUARIO ,NUM_CARTAO_CREDITO ) VALUES (:HISLANCT-NUM-CERTIFICADO ,:HISLANCT-NUM-PARCELA ,:HISLANCT-OCORR-HISTORICOCTA ,:HISLANCT-COD-AGENCIA-DEBITO ,:HISLANCT-OPE-CONTA-DEBITO ,:HISLANCT-NUM-CONTA-DEBITO ,:HISLANCT-DIG-CONTA-DEBITO ,:V0PROP-DTVENCTO ,:HISLANCT-PRM-TOTAL , '0' , '1' ,CURRENT_TIMESTAMP ,:HISLANCT-OCORR-HISTORICO ,:HISLANCT-CODCONV ,NULL ,NULL ,NULL ,NULL , 'VG0853B' ,0) END-EXEC. */

            var r2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1 = new R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
                HISLANCT_OCORR_HISTORICOCTA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICOCTA.ToString(),
                HISLANCT_COD_AGENCIA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_COD_AGENCIA_DEBITO.ToString(),
                HISLANCT_OPE_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OPE_CONTA_DEBITO.ToString(),
                HISLANCT_NUM_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CONTA_DEBITO.ToString(),
                HISLANCT_DIG_CONTA_DEBITO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DIG_CONTA_DEBITO.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                HISLANCT_PRM_TOTAL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL.ToString(),
                HISLANCT_OCORR_HISTORICO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO.ToString(),
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
            };

            R2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1.Execute(r2500_00_PROCESSA_DEB_ANTERIOR_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2500-50-FETCH */
        private void R2500_50_FETCH(bool isPerform = false)
        {
            /*" -4681- PERFORM R2100-00-FETCH-CDEBANT. */

            R2100_00_FETCH_CDEBANT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-UPDATE-COBERHISTVA-SECTION */
        private void R2600_00_UPDATE_COBERHISTVA_SECTION()
        {
            /*" -4691- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4696- PERFORM R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1 */

            R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1();

            /*" -4699- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4700- DISPLAY 'R2600-00 (ERRO - UPDATE COBERHISTVA)' */
                _.Display($"R2600-00 (ERRO - UPDATE COBERHISTVA)");

                /*" -4703- DISPLAY 'CERTIF. : ' HISLANCT-NUM-CERTIFICADO ' PARCELA : ' HISLANCT-NUM-PARCELA ' OCORR : ' HISLANCT-OCORR-HISTORICO */

                $"CERTIF. : {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO} PARCELA : {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA} OCORR : {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO}"
                .Display();

                /*" -4704- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4705- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4707- MOVE 'ERRO NO UPDATE DA TABLE COBER-HIST-VIDAZUL' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA TABLE COBER-HIST-VIDAZUL", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4708- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4709- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4710- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-UPDATE-COBERHISTVA-DB-UPDATE-1 */
        public void R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1()
        {
            /*" -4696- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET OCORR_HISTORICO = :HISLANCT-OCORR-HISTORICO WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA END-EXEC */

            var r2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1_Update1 = new R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1_Update1()
            {
                HISLANCT_OCORR_HISTORICO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_OCORR_HISTORICO.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1_Update1.Execute(r2600_00_UPDATE_COBERHISTVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-UPDATE-HISTLANCCTA-SECTION */
        private void R2700_00_UPDATE_HISTLANCCTA_SECTION()
        {
            /*" -4720- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4730- PERFORM R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1 */

            R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1();

            /*" -4733- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4734- DISPLAY 'R2700-00 (ERRO - UPDATE HISTCONTCTA)' */
                _.Display($"R2700-00 (ERRO - UPDATE HISTCONTCTA)");

                /*" -4736- DISPLAY 'CERTIF. : ' HISLANCT-NUM-CERTIFICADO ' PARCELA : ' HISLANCT-NUM-PARCELA */

                $"CERTIF. : {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO} PARCELA : {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}"
                .Display();

                /*" -4737- PERFORM R1800-00-LIMPA-REGISTROS */

                R1800_00_LIMPA_REGISTROS_SECTION();

                /*" -4738- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -4740- MOVE 'ERRO NO UPDATE DA TABLE HIST-LANC-CTA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO UPDATE DA TABLE HIST-LANC-CTA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -4741- PERFORM R1850-00-GRAVA-REGISTROS */

                R1850_00_GRAVA_REGISTROS_SECTION();

                /*" -4742- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4743- END-IF. */
            }


        }

        [StopWatch]
        /*" R2700-00-UPDATE-HISTLANCCTA-DB-UPDATE-1 */
        public void R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1()
        {
            /*" -4730- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = '2' WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND CODCONV = 6088 AND TIPLANC = '1' AND SIT_REGISTRO = ' ' AND CODRET <> 0 END-EXEC */

            var r2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1 = new R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1.Execute(r2700_00_UPDATE_HISTLANCCTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-BUSCA-VLPREMIO-SECTION */
        private void R5000_00_BUSCA_VLPREMIO_SECTION()
        {
            /*" -4756- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4764- PERFORM R5000_00_BUSCA_VLPREMIO_DB_SELECT_1 */

            R5000_00_BUSCA_VLPREMIO_DB_SELECT_1();

            /*" -4768- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -811 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -811)
            {

                /*" -4769- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4770- MOVE '5002' TO WNR-EXEC-SQL */
                    _.Move("5002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4777- PERFORM R5000_00_BUSCA_VLPREMIO_DB_SELECT_2 */

                    R5000_00_BUSCA_VLPREMIO_DB_SELECT_2();

                    /*" -4781- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -811 */

                    if (DB.SQLCODE != 00 && DB.SQLCODE != -811)
                    {

                        /*" -4782- MOVE ZEROS TO WHOST-VLPREMIO-REL */
                        _.Move(0, WHOST_VLPREMIO_REL);

                        /*" -4783- END-IF */
                    }


                    /*" -4784- ELSE */
                }
                else
                {


                    /*" -4785- MOVE ZEROS TO WHOST-VLPREMIO-REL */
                    _.Move(0, WHOST_VLPREMIO_REL);

                    /*" -4786- END-IF */
                }


                /*" -4787- END-IF. */
            }


        }

        [StopWatch]
        /*" R5000-00-BUSCA-VLPREMIO-DB-SELECT-1 */
        public void R5000_00_BUSCA_VLPREMIO_DB_SELECT_1()
        {
            /*" -4764- EXEC SQL SELECT VLPREMIO INTO :WHOST-VLPREMIO-REL FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTVENCTO AND DTTERVIG >= :V0PROP-DTVENCTO WITH UR END-EXEC. */

            var r5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1 = new R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
            };

            var executed_1 = R5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1.Execute(r5000_00_BUSCA_VLPREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLPREMIO_REL, WHOST_VLPREMIO_REL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-BUSCA-VLPREMIO-DB-SELECT-2 */
        public void R5000_00_BUSCA_VLPREMIO_DB_SELECT_2()
        {
            /*" -4777- EXEC SQL SELECT VLPREMIO INTO :WHOST-VLPREMIO-REL FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC */

            var r5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1 = new R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1.Execute(r5000_00_BUSCA_VLPREMIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VLPREMIO_REL, WHOST_VLPREMIO_REL);
            }


        }

        [StopWatch]
        /*" R6000-00-VERIFICA-CONTROLE-MNL-SECTION */
        private void R6000_00_VERIFICA_CONTROLE_MNL_SECTION()
        {
            /*" -4803- MOVE '5100' TO WNR-EXEC-SQL. */
            _.Move("5100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4805- MOVE ZEROS TO WHOST-CNTRLE-MNL */
            _.Move(0, WHOST_CNTRLE_MNL);

            /*" -4826- PERFORM R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1 */

            R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1();

            /*" -4835- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4836- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -4837- PERFORM R1800-00-LIMPA-REGISTROS */

                    R1800_00_LIMPA_REGISTROS_SECTION();

                    /*" -4839- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -4841- MOVE 'ERRO NO ACESSO A TABELA VG_VIGENCIA_FATURA' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO A TABELA VG_VIGENCIA_FATURA", AREA_DE_WORK.LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -4842- PERFORM R1850-00-GRAVA-REGISTROS */

                    R1850_00_GRAVA_REGISTROS_SECTION();

                    /*" -4843- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4844- END-IF */
                }


                /*" -4845- ELSE */
            }
            else
            {


                /*" -4846- IF (VG083-IND-PROCESSAMENTO EQUAL 'PF' ) */

                if ((VG083.DCLVG_VIGENCIA_FATURA.VG083_IND_PROCESSAMENTO == "PF"))
                {

                    /*" -4847- MOVE 1 TO WHOST-CNTRLE-MNL */
                    _.Move(1, WHOST_CNTRLE_MNL);

                    /*" -4849- ELSE */
                }
                else
                {


                    /*" -4851- IF (VG083-IND-PROCESSAMENTO EQUAL 'NP' AND V0PROP-NUM-APOLICE NOT EQUAL 109300002554) */

                    if ((VG083.DCLVG_VIGENCIA_FATURA.VG083_IND_PROCESSAMENTO == "NP" && V0PROP_NUM_APOLICE != 109300002554))
                    {

                        /*" -4852- MOVE 2 TO WHOST-CNTRLE-MNL */
                        _.Move(2, WHOST_CNTRLE_MNL);

                        /*" -4853- MOVE V0PROP-NRCERTIF TO REG-SAI-NRCERTIF */
                        _.Move(V0PROP_NRCERTIF, REG_DET.REG_SAI_NRCERTIF);

                        /*" -4854- MOVE V0PROP-DTVENCTO TO REG-SAI-DT-VENC */
                        _.Move(V0PROP_DTVENCTO, REG_DET.REG_SAI_DT_VENC);

                        /*" -4856- MOVE V0PROP-NRPARCEL TO REG-SAI-NRPARCEL */
                        _.Move(V0PROP_NRPARCEL, REG_DET.REG_SAI_NRPARCEL);

                        /*" -4859- MOVE 'ALERTA** APOLICE NAO LIBERADA P/GERAR PARC PELA BU' TO REG-SAI-DESCRICAO */
                        _.Move("ALERTA** APOLICE NAO LIBERADA P/GERAR PARC PELA BU", REG_DET.REG_SAI_DESCRICAO);

                        /*" -4860- MOVE WHOST-VLPREMIO-REL TO REG-SAI-PRM */
                        _.Move(WHOST_VLPREMIO_REL, REG_DET.REG_SAI_PRM);

                        /*" -4861- WRITE REG-SAIDA FROM REG-DET */
                        _.Move(REG_DET.GetMoveValues(), REG_SAIDA);

                        ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                        /*" -4862- ELSE */
                    }
                    else
                    {


                        /*" -4864- IF (VG083-IND-PROCESSAMENTO EQUAL 'NP' AND V0PROP-NUM-APOLICE EQUAL 109300002554) */

                        if ((VG083.DCLVG_VIGENCIA_FATURA.VG083_IND_PROCESSAMENTO == "NP" && V0PROP_NUM_APOLICE == 109300002554))
                        {

                            /*" -4865- MOVE 2 TO WHOST-CNTRLE-MNL */
                            _.Move(2, WHOST_CNTRLE_MNL);

                            /*" -4866- END-IF */
                        }


                        /*" -4867- END-IF */
                    }


                    /*" -4868- END-IF */
                }


                /*" -4868- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-00-VERIFICA-CONTROLE-MNL-DB-SELECT-1 */
        public void R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1()
        {
            /*" -4826- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, SEQ_FATURAMENTO, DTA_INI_FATURA, DTA_VENC_FATURA + 18 DAYS, IND_PROCESSAMENTO INTO :VG083-NUM-APOLICE, :VG083-COD-SUBGRUPO, :VG083-SEQ-FATURAMENTO, :VG083-DTA-INI-FATURA, :VG083-DTA-VENC-FATURA, :VG083-IND-PROCESSAMENTO FROM SEGUROS.VG_VIGENCIA_FATURA WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = 0 AND SEQ_FATURAMENTO = (SELECT MAX(T1.SEQ_FATURAMENTO) FROM SEGUROS.VG_VIGENCIA_FATURA T1 WHERE T1.NUM_APOLICE = :V0PROP-NUM-APOLICE AND T1.COD_SUBGRUPO = 0) END-EXEC. */

            var r6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1 = new R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1.Execute(r6000_00_VERIFICA_CONTROLE_MNL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG083_NUM_APOLICE, VG083.DCLVG_VIGENCIA_FATURA.VG083_NUM_APOLICE);
                _.Move(executed_1.VG083_COD_SUBGRUPO, VG083.DCLVG_VIGENCIA_FATURA.VG083_COD_SUBGRUPO);
                _.Move(executed_1.VG083_SEQ_FATURAMENTO, VG083.DCLVG_VIGENCIA_FATURA.VG083_SEQ_FATURAMENTO);
                _.Move(executed_1.VG083_DTA_INI_FATURA, VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_INI_FATURA);
                _.Move(executed_1.VG083_DTA_VENC_FATURA, VG083.DCLVG_VIGENCIA_FATURA.VG083_DTA_VENC_FATURA);
                _.Move(executed_1.VG083_IND_PROCESSAMENTO, VG083.DCLVG_VIGENCIA_FATURA.VG083_IND_PROCESSAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4880- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -4881- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -4883- DISPLAY SQLERRMC '<' SQLERRMC '>' */

            $"{DB.SQLERRMC}<{DB.SQLERRMC}>"
            .Display();

            /*" -4883- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4887- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -4902- DISPLAY V0PROP-NRCERTIF ' ' V0PROP-DTVENCTO ' ' V0PROP-NRPARCEL */

            $"{V0PROP_NRCERTIF} {V0PROP_DTVENCTO} {V0PROP_NRPARCEL}"
            .Display();

            /*" -4903- CLOSE DSAIDA */
            DSAIDA.Close();

            /*" -4904- CLOSE SSAIDA. */
            SSAIDA.Close();

            /*" -4906- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

            /*" -4906- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}