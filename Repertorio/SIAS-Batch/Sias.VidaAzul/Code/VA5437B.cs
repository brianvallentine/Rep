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
using Sias.VidaAzul.DB2.VA5437B;

namespace Code
{
    public class VA5437B
    {
        public bool IsCall { get; set; }

        public VA5437B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"TESTE#* IDENTIFICACAO ERRO                                                    */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EMITE CERTIFICADOS DAS APOLICES PESSOA FISICA NO PADRAO FAC.  *      */
        /*"      *                         FORMULARIO VA54                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *        COPIA DO VA3437B COM IMPLEMENTACAO DA CIRCULAR 491      *      */
        /*"      *        COPIA DO VA3437B COM IMPLEMENTACAO DA CIRCULAR 491      *      */
        /*"      *        COPIA DO VA3437B COM IMPLEMENTACAO DA CIRCULAR 491      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  COLUNAS SETADAS NA TABELA V0RELATORIOS:                       *      */
        /*"      *                                                                *      */
        /*"      *  OPERACAO = 6 (INDICA A EMISSAO DE COMUNICADO DE ADESAO - A5)  *      */
        /*"      *  OPERACAO = 2 (INDICA A EMISSAO DE 2a VIA COMUNICADO    - A4)  *      */
        /*"      *  NRPARCEL = 2 (INDICA O ENVIO PARA O SEGURADO)                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.40  *  VERSAO 40  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/09/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.40         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.39  *  VERSAO 39  - INCIDENTE 601.440                                *      */
        /*"      *             - ERRO 0C7 - CORRECAO DO VALOR DA VARIAVEL PARA    *      */
        /*"      *               EVITAR MOVIMENTACAO DE ALFA PARA NUMERICO.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2024 - FRANK CARVALHO/SERGIO LORETO                 *      */
        /*"      *                                       PROCURE POR V.39         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.38  *  VERSAO 38  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2024 - TERCIO CARVALHO/SERGIO LORETO                *      */
        /*"      *                                       PROCURE POR V.38         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.37  *  VERSAO 37  - DEMANDA 578503 / TAREFA 583609                   *      */
        /*"      *                                                                *      */
        /*"      *    - 3 CAMPOS DE NOME SOCIAL ADICIONADOS NO FINAL DOS ARQUIVOS:*      */
        /*"      *      => SEGURADO_SOCIAL, DESTINATARIO_SOCIAL, CLIENTE_SOCIAL   *      */
        /*"      *                                                                *      */
        /*"      *    UTILIDADE:                                                  *      */
        /*"      *    . SE SEGURADO_SOCIAL, DESTINATARIO_SOCIAL, CLIENTE_SOCIAL   *      */
        /*"      *    ESTIVEREM PREENCHIDOS NO ARQUIVO, O CCM DEVERA UTILIZA-LOS  *      */
        /*"      *    NA COMUNICACAO AO CLIENTE, CASO CONTRARIO, CONTINUAR COM OS *      */
        /*"      *    CAMPOS: SEGURADO, DESTINATARIO E CLIENTE.                   *      */
        /*"      *                                                                *      */
        /*"      *  EM 08/05/2024 - ANSELMO SOUSA                                 *      */
        /*"      *                                        PROCURE POR V.37        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.36  *   VERSAO 36 - DEMANDA 282482 - FOLHETERIA - XS2 VIDA E PREST.  *      */
        /*"      *               PASSAR A GRAVAR NO ARQUIVO IMP5437B FORM VIDA10  *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/03/2021 - CANETTA             PROCURE POR V.36         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                 ARQUIVOS GERADOS PELO PROGRAMA                 *      */
        /*"      *                                                                       */
        /*"      * RVA5437B : CERTIFICADOS ENVIADOS  GRFICA                     *      */
        /*"V.22  * IMP5437B : CERTIFICADOS COM TIPO DE ENVIO IMPRESSO             *      */
        /*"V.22  * PDF5437B : CERTIFICADOS COM TIPO DE ENVIO PDF                  *      */
        /*"      * FVA5437B : ESTATISTICA DO PROCESSAMENTO (SYSOUT)               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                         MANUTENES                            *      */
        /*"JV135#*----------------------------------------------------------------*      */
        /*"JV135#*VERSAO 35: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV135#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV135#*           - PROCURAR POR JV135                                 *      */
        /*"JV134 *-----------------------------------------------------------------      */
        /*"JV134 *VERSAO 34: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV134 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV134 *           - PROCURAR POR JV134                                        */
        /*"      *-----------------------------------------------------------------      */
        /*"      *   VERSAO 33 - HIST 206.622     TAREFA: 228.884                 *      */
        /*"      *             - RETIRAR FORMULARIOS CVP                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/01/2020 - HERVAL SOUZA                                 *      */
        /*"      *                                       PROCURE POR JV.01        *      */
        /*"      *----------------------------------------------------------------C      */
        /*"      *   VERSAO 32 - HIST 198.120                                     *      */
        /*"      *             - ADEQUAR TAMANHO DAS VARIAVEIS DE TRABALHO DO     *      */
        /*"      *               CAMPO SUBGRUPO (SMALLINT ASSUME ATE 32767).      *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/04/2019 - BRICE HO (ALTRAN)                            *      */
        /*"      *                                       PROCURE POR v.32         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31 - HIST 181.577                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 30 - CAD 154.904                                       *      */
        /*"      *            - CORRECAO DE ABEND +100 NO DECLARE DO CURSOR DE    *      */
        /*"      *              BENEFICIARIOS. RETIRAR TESTE DE SQLCODE APOS O    *      */
        /*"      *              DECLARE DE TODOS OS CURSORES DO PROGRAMA.         *      */
        /*"      *                                                                *      */
        /*"      *  EM 18/10/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 29 - CAD 152.055                                       *      */
        /*"      *            - ALTERAR FORMULARIO VA54 PARA AS VENDAS QUE FORAM  *      */
        /*"      *              REALIZADAS NA CAMPANHA DE PRODUTOS PU(PAGAMENTO   *      */
        /*"      *              UNICO) E QUE NAO POSSUEM CARENCIA.                *      */
        /*"      *                                                                *      */
        /*"      *  EM 05/07/2017 - FRANK CARVALHO                                *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 28 - CAD 146.446                                       *      */
        /*"      *            - GERAR APENAS O FORMULARIO VA54, OS DEMAIS SERO   *      */
        /*"      *              GERADOS NO VA3437B e VA4437B                      *      */
        /*"      *                                                                *      */
        /*"      *  EM 20/04/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - CAD 111.710                                      *      */
        /*"      *             - CHAMADA DE SUBROTINA VG0711S PARA DIVISAO DE     *      */
        /*"      *               PREMIO POR PERCENTUAIS DE COBERTURA CONFORME     *      */
        /*"      *               CIRCULAR 491 DA SUSEP. CASO NAO HAJA CADASTRAMENT*      */
        /*"      *               DA APOLICE, O PREMIO DEVE SER COLOCADO 100%      *      */
        /*"      *               NO RAMO PRINCIPAL E CALCULO DE IOF DO VALOR DO   *      */
        /*"      *               PREMIO INFORMADO NA SUBROTINA                    *      */
        /*"      *                                                                *      */
        /*"      *   22/04/2015 - ELIERMES OLIVEIRA                               *      */
        /*"      *                                              PROCURE POR V.27  *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 26 - CAD 148.799                                       *      */
        /*"      *            - ALTERAR O NOME DA COBERTURA 22 PARA "COBERTURA DE *      */
        /*"      *              DOENAS CRNICAS GRAVES EM ESTGIO AVANADO" PARA *      */
        /*"      *              APOLICE 109300000559.                             *      */
        /*"      *            - EXCLUIR COBERTURA 24 E INCLUIR COBERTURA 86 PARA  *      */
        /*"      *              HOMOLOGACAO E 44 PARA PRODUO PARA SUBGRUPOS     *      */
        /*"      *              01, 02, 06, 08, 10, 12, 14, 16 e 18 DA APOLICE    *      */
        /*"      *              109300000559.                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/04/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - CAD 143.008 - ABEND                              *      */
        /*"      * (MODIFICACAO OBSOLETA APS ENTRADA DA CIRCULAR 491 - ELIERMES) *      */
        /*"      *             - RETIRAR FILTRO POR COD_MODALIDADE NOS SELECTS NA *      */
        /*"      *               TABELA APOLICE_COBERTURAS.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/10/2016 - LUIGI CONTE                                  *      */
        /*"      *                                        PROCURE POR V.25        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - CAD 140.540                                      *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO UNIC - MODULO DE RETENCAO                *      */
        /*"      *             - INCLUSAO DO FORMULARIO VD08.                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2016 - LUIGI CONTE                                  *      */
        /*"      *                                        PROCURE POR V.24        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - CAD 119.494                                      *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO UNIC - MODULO DE RETENCAO                *      */
        /*"      *             - CORRECAO DE IMPRESSAO DE LINHAS INDEVIDAS  COM   *      */
        /*"      *               '%%EOF'                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/06/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.23        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - CAD 119.494                                      *      */
        /*"      *                                                                *      */
        /*"      *             - PROJETO UNIC - MODULO DE RETENCAO                *      */
        /*"      *             - INCLUSAO DOS FILTROS PARA AS OPCOES DE ENVIO     *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/01/2016 - RIBAMAR MARQUES                              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.22        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - CAD 122.604                                      *      */
        /*"      *                                                                *      */
        /*"      *             - IMPLEMENTAR A REGRA DE GERACAO DO RELATORIO VD09 *      */
        /*"      *               CARTA DE RENOVACAO.                              *      */
        /*"      *             - INCLUIR O CAMPO COD_SUSEPCAP.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 24/02/2016 - LUIGI CONTE                                  *      */
        /*"      *                                        PROCURE POR V.21        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 20 - CAD 130.404                                       *      */
        /*"      *            - ALTERAR PARA GERAR FORMULARIO VA54 PARA PRODUTOS  *      */
        /*"      *              "PARA APROVEITAR A VIDA", APENAS QUANDO DO PEDIDO *      */
        /*"      *              DE SEGUNDA VIA PELO ATALHO 04.10.02                      */
        /*"      *            - ALTERAR TAMANHO DA VARIAVEL DE SORTEIO PARA SUPOR-*      */
        /*"      *              TAR O TEXTO "NO CONTEMPLA"                       *      */
        /*"      *                                                                *      */
        /*"      *  EM 15/02/2016 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 19 - CAD 117.316                                       *      */
        /*"      *            - ALTERAR PARA GERAR FORMULARIO VA54 PARA PRODUTOS  *      */
        /*"      *              "PARA APROVEITAR A VIDA".                         *      */
        /*"      *            - INSERIR O DIZER "HERDEIROS LEGAIS" QUANDO NAO     *      */
        /*"      *              HOUVER BENEFICIARIOS CADASTRADOS, COM 100%.       *      */
        /*"      *            - INSERIR O DIZER "NAO CONTEMPLA" NO CAMPO SORTEIOS *      */
        /*"      *              PARA OS PRODUTOS 9328, 9334, 9357, 9358, 9314,    *      */
        /*"      *              9703 E 9705                                       *      */
        /*"      *                                                                *      */
        /*"      *  EM 04/11/2015 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 18 - CAD 122.275 E CAD 117.796                       *      */
        /*"      * (MODIFICACAO OBSOLETA APS ENTRADA DA CIRCULAR 491 - ELIERMES) *      */
        /*"      *                                                                *      */
        /*"      *              - DESATIVAR AUXILIO ALIMENTACAO NO SIAS           *      */
        /*"      *                                                                *      */
        /*"      *    EM 16/11/2015 - MARCUS VALERIO   (ALTRAN)                   *      */
        /*"      *                    MAURO R. DA CRUZ (ALTRAN)                   *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 17 -   NSGD - CADMUS 103659.                                */
        /*"      *                - NOVA SOLUCAO DE GESTAO DE DEPOSITOS                  */
        /*"      *                                                                       */
        /*"      *    EM 08/07/2015 - COREON                                             */
        /*"      *                                        PROCURE POR V.17               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CAD 110.125                                      *      */
        /*"      *             - ALTERACAO DO NOME-PRODUTO PARA PEGAR NA TABELA   *      */
        /*"      *               SEGUROS.PRODUTO                                  *      */
        /*"      *                                                                *      */
        /*"      *   11/03/2015 - ELIERMES OLIVEIRA                               *      */
        /*"      *                                              PROCURE POR V.16  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - 27/10/2014 THIAGO BLAIER / MAURO ROCHA           *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 100642 - ACERTA VALORES DE COBERTURA DA APOLICI 889   *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURAR POR V.15   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - 02/09/2014 MAURO ROCHA DA CRUZ                   *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 101217- RESSEGURO (ABEND)                             *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.14       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - 28/08/2014 LUIZ GUSTAVO DE OLIVEIRA              *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 101217- RESSEGURO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.13       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - 30/01/2014 TERCIO FREITAS                        *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 82426 - INCLUIR DATA DE NASCIMENTO E CODIGO SUSEP.    *      */
        /*"      *                  GERAR 2a VIA NO FORMULARIO VA54 PARA OS       *      */
        /*"      *                  PRODUTOS: 9356, 9359, 9357 E 9360             *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.12       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - 08/11/2013 TERCIO FREITAS                        *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 83623 - CORRECAO NA ROTINA DE IMPRESSAO DA COBERTURA  *      */
        /*"      *                  SAF PARA OS CERTIFICADOS PF.                  *      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 84924 - AJUSTE NA QUANTIDADE DE OCORRENCIA DAS COBER- *      */
        /*"      *                  TURAS E ASSISTENCIAS NO AQUIVO DE SAIDA.      *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.11       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - 18/06/2013 MAURO/CARLA - CADMUS 83298            *      */
        /*"      *                                                                *      */
        /*"      *               CORRECAO NA ROTINA DE IMPRESSAO DA COBERTURA     *      */
        /*"      *               SAF.INIBE VALOR DA COBERTURA 25 E 31.            *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.10       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - 29/02/2013 AUGUSTO ANASTACIO                     *      */
        /*"      *                                                                *      */
        /*"      *               CORRECAO NA ROTINA DE ENERECO PARA ENVIO DE      *      */
        /*"      *               CERTIFICADOS/CORRESPONDENCIAS PARA OS PRODUTOS   *      */
        /*"      *               VIDA.                                            *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.09       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - 07/06/2013 CARLA VILELA - CADMUS 83346           *      */
        /*"      *                                                                *      */
        /*"      *               ALTERAR O PARAGRAFO R1000-00-PROCESSA-INPUT      *      */
        /*"      *               PARA INCLUIR NO COUNT DA TABELA RELATORIOS A     *      */
        /*"      *               VERIFICACAO DE DATA SOLICITACAO > DATA MOVIMENTO *      */
        /*"      *               ABERTO - 15 DIAS E SITUACAO = 0.                 *      */
        /*"      *               AJUSTAR NUMERO DA SORTE ZERADO.                  *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.08       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - 28/02/2013 BRICE HO                              *      */
        /*"      *                                                                *      */
        /*"      *               INCLUIR 'WITH UR' NOS DECLARE CURSOR AFINS DE    *      */
        /*"      *               EVITAR CONCORRENCIAS NOS ACESSOS AS TABELAS      *      */
        /*"      *               DA CAPITALIZACAO.                                *      */
        /*"      *               PROVAVEL CAUSA DO ABEND SORT COM RC=16.          *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.07       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - 07/01/2013 BRICE HO                              *      */
        /*"      *                                                                *      */
        /*"      *               SELECIONAR SOLICITACOES DA RELATORIOS DOS        *      */
        /*"      *               ULTIMOS 15 DIAS EM FUNCAO DE UMA SITUACAO        *      */
        /*"      *               ANTERIOR QUE NAO ATUALIZOU SIT-REGISTRO NA       *      */
        /*"      *               TABELA RELATORIOS. SERAO PROCESSADOS SOLICI-     *      */
        /*"      *               TACOES A PARTIR DE 10/12/2012.                   *      */
        /*"      *               AJUSTES NOS CONTADORES DE CONTROLE.              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.06       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - 04/01/2013 BRICE HO                              *      */
        /*"      *                                                                *      */
        /*"      *             - OTIMIZACAO DO CURSOR CRELAT                      *      */
        /*"      *               SELECIONAR SOLICITACOES DA RELATORIOS DOS        *      */
        /*"      *               ULTIMOS 3 MESES.                                 *      */
        /*"      *               TRATAR ERRO DECLARE/OPEN DE CURSOR               *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.05       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - 03/01/2013 BRICE HO                              *      */
        /*"      *                                                                *      */
        /*"      *             - RETIRAR DISPLAY 'LIDOS V0RELAT'.                        */
        /*"      *               IDENTIFICAR ABEND SORT COM RC=16.                       */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.04       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - 28/12/2012 AUGUSTO ANASTACIO                     *      */
        /*"      *                                                                *      */
        /*"      *             - ALTERAR O RETURN-CODE DO SORT-RETURN             *      */
        /*"      *               DE 9 PARA 99.                                    *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.03       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - 10/12/2012 TERCIO FREITAS                        *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTAR IMPRESSAO DO NUMERO DA SORTE E           *      */
        /*"      *               UPDATE NA TABELA SEGUROS.RELATORIOS.             *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURAR POR V.02       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - 17/10/2012 BY BARDUCCO                           *      */
        /*"      *                                                                *      */
        /*"      *             - ACERTA QUEBRA DE FORMULARIO                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 00 - 20/09/2012 BY BARDUCCO                           *      */
        /*"      *                                                                *      */
        /*"      *             - REFORMULA ARQUIVO DE SAIDA. MANTEM SOMENTE A     *      */
        /*"      *               QUEBRA DE FORMULARIO E ELIMINA CARACTERES DE     *      */
        /*"      *               CONTROLE DE IMPRESSAO                            *      */
        /*"      *                                                                *      */
        /*"      *             - GERA O ARQUIVO VA5437B2 COM AS ESTATISTICAS DO   *      */
        /*"      *               PROCESSAMENTO (SYSOUT)                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RVA5437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RVA5437B
        {
            get
            {
                _.Move(RVA5437B_RECORD, _RVA5437B); VarBasis.RedefinePassValue(RVA5437B_RECORD, _RVA5437B, RVA5437B_RECORD); return _RVA5437B;
            }
        }
        public FileBasis _IMP5437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis IMP5437B
        {
            get
            {
                _.Move(IMP5437B_RECORD, _IMP5437B); VarBasis.RedefinePassValue(IMP5437B_RECORD, _IMP5437B, IMP5437B_RECORD); return _IMP5437B;
            }
        }
        public FileBasis _PDF5437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis PDF5437B
        {
            get
            {
                _.Move(PDF5437B_RECORD, _PDF5437B); VarBasis.RedefinePassValue(PDF5437B_RECORD, _PDF5437B, PDF5437B_RECORD); return _PDF5437B;
            }
        }
        public FileBasis _VDHTML01 { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis VDHTML01
        {
            get
            {
                _.Move(VDHTML01_RECORD, _VDHTML01); VarBasis.RedefinePassValue(VDHTML01_RECORD, _VDHTML01, VDHTML01_RECORD); return _VDHTML01;
            }
        }
        public FileBasis _VDHTML09 { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis VDHTML09
        {
            get
            {
                _.Move(VDHTML09_RECORD, _VDHTML09); VarBasis.RedefinePassValue(VDHTML09_RECORD, _VDHTML09, VDHTML09_RECORD); return _VDHTML09;
            }
        }
        public FileBasis _FVA5437B { get; set; } = new FileBasis(new PIC("X", "80", "X(80)"));

        public FileBasis FVA5437B
        {
            get
            {
                _.Move(FVA5437B_RECORD, _FVA5437B); VarBasis.RedefinePassValue(FVA5437B_RECORD, _FVA5437B, FVA5437B_RECORD); return _FVA5437B;
            }
        }
        public SortBasis<VA5437B_REG_SVA5437B> SVA5437B { get; set; } = new SortBasis<VA5437B_REG_SVA5437B>(new VA5437B_REG_SVA5437B());
        /*"01  RVA5437B-RECORD           PIC X(4500).*/
        public StringBasis RVA5437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  IMP5437B-RECORD           PIC X(4500).*/
        public StringBasis IMP5437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  PDF5437B-RECORD           PIC X(4500).*/
        public StringBasis PDF5437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  VDHTML01-RECORD           PIC X(4500).*/
        public StringBasis VDHTML01_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  VDHTML09-RECORD           PIC X(4500).*/
        public StringBasis VDHTML09_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  FVA5437B-RECORD           PIC X(80).*/
        public StringBasis FVA5437B_RECORD { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"01  REG-SVA5437B.*/
        public VA5437B_REG_SVA5437B REG_SVA5437B { get; set; } = new VA5437B_REG_SVA5437B();
        public class VA5437B_REG_SVA5437B : VarBasis
        {
            /*"    05 SVA-TP-ARQSAIDA        PIC X(014).*/
            public StringBasis SVA_TP_ARQSAIDA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"    05 SVA-CEP-G              PIC 9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05 SVA-NUM-CEP.*/
            public VA5437B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VA5437B_SVA_NUM_CEP();
            public class VA5437B_SVA_NUM_CEP : VarBasis
            {
                /*"       07 SVA-CEP             PIC 9(005).*/
                public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       07 SVA-CEP-COMPL       PIC 9(003).*/
                public IntBasis SVA_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05 SVA-CPF                PIC 9(011).*/
            }
            public IntBasis SVA_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"    05 SVA-NRCERTIF           PIC 9(015).*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05 SVA-TIPOSEGU           PIC X(001).*/
            public StringBasis SVA_TIPOSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-NRAPOLICE          PIC 9(013).*/
            public IntBasis SVA_NRAPOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05 SVA-CODSUBES           PIC 9(005).*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05 SVA-CODUSU             PIC X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 SVA-RAMO               PIC 9(004).*/
            public IntBasis SVA_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-CODRELAT           PIC X(006).*/
            public StringBasis SVA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"    05 SVA-CODRELATVG         PIC X(008).*/
            public StringBasis SVA_CODRELATVG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 SVA-NUM-ITEM           PIC 9(009).*/
            public IntBasis SVA_NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 SVA-CODCLIEN           PIC 9(009).*/
            public IntBasis SVA_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 SVA-OCORHIST           PIC 9(004).*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-DTINIVIG           PIC X(010).*/
            public StringBasis SVA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-DTMOVTO            PIC X(010).*/
            public StringBasis SVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-CODOPER            PIC 9(004).*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-IDFORM             PIC X(002).*/
            public StringBasis SVA_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 SVA-IMPSEGCDG          PIC 9(013)V99.*/
            public DoubleBasis SVA_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 SVA-VLPREMIO           PIC 9(013)V99.*/
            public DoubleBasis SVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 SVA-OPCAOPAG           PIC X(001).*/
            public StringBasis SVA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-AGECTADEB          PIC 9(004).*/
            public IntBasis SVA_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-OPRCTADEB          PIC 9(004).*/
            public IntBasis SVA_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-NUMCTADEB          PIC 9(012).*/
            public IntBasis SVA_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05 SVA-DIGCTADEB          PIC 9(001).*/
            public IntBasis SVA_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05 SVA-DIA-DEBITO         PIC 9(002).*/
            public IntBasis SVA_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 SVA-PLANO              PIC 9(004).*/
            public IntBasis SVA_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-ENDERECO           PIC X(072).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05 SVA-BAIRRO             PIC X(072).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05 SVA-CIDADE             PIC X(072).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    05 SVA-UF                 PIC X(002).*/
            public StringBasis SVA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 SVA-NOME-RAZAO         PIC X(040).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05 SVA-IDSEXO             PIC X(001).*/
            public StringBasis SVA_IDSEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-NOME-CORREIO       PIC X(046).*/
            public StringBasis SVA_NOME_CORREIO { get; set; } = new StringBasis(new PIC("X", "46", "X(046)."), @"");
            /*"    05 SVA-SITSEG             PIC X(001).*/
            public StringBasis SVA_SITSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-SITPROP            PIC X(001).*/
            public StringBasis SVA_SITPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-FONTE              PIC 9(004).*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-PERI-PAGAMENTO     PIC 9(004).*/
            public IntBasis SVA_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-DTTERVIG           PIC X(010).*/
            public StringBasis SVA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-IND-VIGENCIA       PIC X(001).*/
            public StringBasis SVA_IND_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-PRODUTO            PIC 9(004).*/
            public IntBasis SVA_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 SVA-DTQUIT             PIC X(010).*/
            public StringBasis SVA_DTQUIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-EMAIL              PIC X(040).*/
            public StringBasis SVA_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    05 SVA-NUM-PLANO          PIC 9(003).*/
            public IntBasis SVA_NUM_PLANO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    05 SVA-RENDA-IND          PIC 9(002).*/
            public IntBasis SVA_RENDA_IND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 SVA-RENDA-FAM          PIC 9(002).*/
            public IntBasis SVA_RENDA_FAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 SVA-OPCAO-PAG          PIC X(001).*/
            public StringBasis SVA_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SVA-DTNASC             PIC X(010).*/
            public StringBasis SVA_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-NRSORTE-RED        PIC X(045).*/
            public StringBasis SVA_NRSORTE_RED { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
            /*"    05 SVA-NRSORTE-S  REDEFINES SVA-NRSORTE-RED.*/
            private _REDEF_VA5437B_SVA_NRSORTE_S _sva_nrsorte_s { get; set; }
            public _REDEF_VA5437B_SVA_NRSORTE_S SVA_NRSORTE_S
            {
                get { _sva_nrsorte_s = new _REDEF_VA5437B_SVA_NRSORTE_S(); _.Move(SVA_NRSORTE_RED, _sva_nrsorte_s); VarBasis.RedefinePassValue(SVA_NRSORTE_RED, _sva_nrsorte_s, SVA_NRSORTE_RED); _sva_nrsorte_s.ValueChanged += () => { _.Move(_sva_nrsorte_s, SVA_NRSORTE_RED); }; return _sva_nrsorte_s; }
                set { VarBasis.RedefinePassValue(value, _sva_nrsorte_s, SVA_NRSORTE_RED); }
            }  //Redefines
            public class _REDEF_VA5437B_SVA_NRSORTE_S : VarBasis
            {
                /*"       10 SVA-NRSORTE OCCURS 5 TIMES PIC 9(009).*/
                public ListBasis<IntBasis, Int64> SVA_NRSORTE { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "9", "9(009)."), 5);
                /*"    05 SVA-COD-SUSEP          PIC X(025).*/

                public _REDEF_VA5437B_SVA_NRSORTE_S()
                {
                    SVA_NRSORTE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis SVA_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    05 SVA-DTINIVIG-APOL      PIC X(010).*/
            public StringBasis SVA_DTINIVIG_APOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-DTTERVIG-APOL      PIC X(010).*/
            public StringBasis SVA_DTTERVIG_APOL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-COD-SUSEP-CAP      PIC X(025).*/
            public StringBasis SVA_COD_SUSEP_CAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    05 SVA-DTPROXVEN          PIC X(010).*/
            public StringBasis SVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-DTINIVIG-OPCPAG    PIC X(010).*/
            public StringBasis SVA_DTINIVIG_OPCPAG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 SVA-JDE                PIC X(008).*/
            public StringBasis SVA_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 SVA-JDL                PIC X(002).*/
            public StringBasis SVA_JDL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05 SVA-DBM                PIC X(004).*/
            public StringBasis SVA_DBM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77  WHOST-DATA-TERVIG-PREMIO       PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIG_PREMIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-OCOREND                  PIC S9(004)   COMP.*/
        public IntBasis WHOST_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W77-MES                        PIC  9(002).*/
        public IntBasis W77_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"77  ENDOSSOS-DATA-TERVIGENCIA-1    PIC  X(010).*/
        public StringBasis ENDOSSOS_DATA_TERVIGENCIA_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1     PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-15D   PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_15D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WINDC                          PIC S9(004)   COMP.*/
        public IntBasis WINDC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WPI                            PIC S9(004)   COMP.*/
        public IntBasis WPI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  I1                             PIC S9(004)   COMP.*/
        public IntBasis I1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  I2                             PIC S9(004)   COMP.*/
        public IntBasis I2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-DATA-OPER-CORR-MONET        PIC  X(010).*/
        public StringBasis WS_DATA_OPER_CORR_MONET { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  I3                             PIC S9(004)   COMP.*/
        public IntBasis I3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WS-IMPRIME-CONTROLES-OK         PIC  9(001) VALUE 0.*/
        public IntBasis WS_IMPRIME_CONTROLES_OK { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77  FILLER                         PIC X(001) VALUE SPACES.*/

        public SelectorBasis FILLER_0 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88  W88-IMPRESSAO-OK                        VALUE '0'. */
							new SelectorItemBasis("W88_IMPRESSAO_OK", "0"),
							/*" 88  W88-IMPRESSAO-NOK                       VALUE '1'. */
							new SelectorItemBasis("W88_IMPRESSAO_NOK", "1")
                }
        };

        /*"77  W88-PRODUTO-VIDA               PIC 9(004) VALUE ZEROS.*/
        public IntBasis W88_PRODUTO_VIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77  VIND-CODMOEDA-I     PIC S9(004) COMP VALUE -1.*/
        public IntBasis VIND_CODMOEDA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77  VIND-NRCOPIAS       PIC S9(004) COMP VALUE -1.*/
        public IntBasis VIND_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), -1);
        /*"77  VIND-AGECTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-OPRCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-NUMCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DIGCTADEB      PIC S9(004) COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-QTMDIT         PIC S9(004) COMP.*/
        public IntBasis VIND_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-SEXO           PIC S9(004) COMP.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-RENDA-IND      PIC S9(004) COMP.*/
        public IntBasis VIND_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-RENDA-FAM      PIC S9(004) COMP.*/
        public IntBasis VIND_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VIND-DTNASC         PIC S9(004) COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-LINHAS-UNIC      PIC S9(004) COMP.*/
        public IntBasis WS_LINHAS_UNIC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-TIPO-ARQ-SAIDA   PIC  X(015) VALUE SPACES.*/
        public StringBasis WS_TIPO_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
        /*"77  WS-RETURN-CODE-M    PIC ----9.*/
        public IntBasis WS_RETURN_CODE_M { get; set; } = new IntBasis(new PIC("9", "5", "----9."));
        /*"77  W77-IND             PIC  9(005)           VALUE ZEROS.*/
        public IntBasis W77_IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
        /*"77  WS-PCTCONJUGE       PIC  9(003)V99        VALUE ZEROS.*/
        public DoubleBasis WS_PCTCONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
        /*"77  WS-RETURN-CODE      PIC S9(04)            VALUE +0.*/
        public IntBasis WS_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-DUPLICADO        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WS_DUPLICADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-CODSUBES      PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WHOST-CODOPER       PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-IMPCONJUGE       PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WS_IMPCONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WHOST-NRCERTIF      PIC S9(015)    COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WHOST-NRAPOLICE     PIC S9(013)    COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRAPOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WS-CERTIFICADO-ATU  PIC S9(15)     COMP-3 VALUE +0.*/
        public IntBasis WS_CERTIFICADO_ATU { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  WS-CERTIFICADO-ANT  PIC S9(15)     COMP-3 VALUE +0.*/
        public IntBasis WS_CERTIFICADO_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  WS-CERTIFICADO-A    PIC S9(15)     COMP-3 VALUE +0.*/
        public IntBasis WS_CERTIFICADO_A { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  WS-COBERTURA        PIC  X(045)           VALUE SPACES.*/
        public StringBasis WS_COBERTURA { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
        /*"77  WHOST-CODUSU        PIC  X(008)           VALUE SPACES.*/
        public StringBasis WHOST_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WHOST-TIPOSEGU      PIC  X(001)           VALUE SPACES.*/
        public StringBasis WHOST_TIPOSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  WHOST-CODRELAT      PIC  X(008)           VALUE SPACES.*/
        public StringBasis WHOST_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77  WED-SEQ             PIC  999.999.*/
        public IntBasis WED_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "999.999."));
        /*"77  WHOST-DTQUIT        PIC  X(010)           VALUE SPACES.*/
        public StringBasis WHOST_DTQUIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  V1SIST-MESREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SIST-ANOREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WS-IMP-SEGURADA-AP                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                WS-IMP-SEGURADA-DIT                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-VG                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-AP                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-IP                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-IPA                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_IPA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-AMDS                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-DH                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-IMP-SEGURADA-DIT                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis APOLICOB_IMP_SEGURADA_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77                APOLICOB-PRM-TARIFARIO-VG                                      PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77                APOLICOB-PRM-TARIFARIO-AP                                      PIC S9(10)V9(5) COMP-3.*/
        public DoubleBasis APOLICOB_PRM_TARIFARIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(5)"), 5);
        /*"77                WS-COD-PRODUTO      PIC S9(004) COMP-5 VALUE 0*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WS-COD-PRODUTO-ED   PIC  -9999.*/
        public IntBasis WS_COD_PRODUTO_ED { get; set; } = new IntBasis(new PIC("9", "4", "-9999."));
        /*"01  AREA-DE-WORK.*/
        public VA5437B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA5437B_AREA_DE_WORK();
        public class VA5437B_AREA_DE_WORK : VarBasis
        {
            /*"    05            WS-SIT-PRODUTO    PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88          WS-PROD-RUNON                  VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88          WS-PROD-RUNOFF                 VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"    05            WS-DTNASC         PIC X(010).*/
            public StringBasis WS_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            WS-DTNASC-R       REDEFINES                  WS-DTNASC.*/
            private _REDEF_VA5437B_WS_DTNASC_R _ws_dtnasc_r { get; set; }
            public _REDEF_VA5437B_WS_DTNASC_R WS_DTNASC_R
            {
                get { _ws_dtnasc_r = new _REDEF_VA5437B_WS_DTNASC_R(); _.Move(WS_DTNASC, _ws_dtnasc_r); VarBasis.RedefinePassValue(WS_DTNASC, _ws_dtnasc_r, WS_DTNASC); _ws_dtnasc_r.ValueChanged += () => { _.Move(_ws_dtnasc_r, WS_DTNASC); }; return _ws_dtnasc_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtnasc_r, WS_DTNASC); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_DTNASC_R : VarBasis
            {
                /*"     10           WS-ANO-DTNASC     PIC 9(004).*/
                public IntBasis WS_ANO_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-MES-DTNASC     PIC 9(002).*/
                public IntBasis WS_MES_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-DIA-DTNASC     PIC 9(002).*/
                public IntBasis WS_DIA_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-DTMOVABE       PIC X(010).*/

                public _REDEF_VA5437B_WS_DTNASC_R()
                {
                    WS_ANO_DTNASC.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_MES_DTNASC.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_DIA_DTNASC.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            WS-DTMOVABE-R     REDEFINES                  WS-DTMOVABE.*/
            private _REDEF_VA5437B_WS_DTMOVABE_R _ws_dtmovabe_r { get; set; }
            public _REDEF_VA5437B_WS_DTMOVABE_R WS_DTMOVABE_R
            {
                get { _ws_dtmovabe_r = new _REDEF_VA5437B_WS_DTMOVABE_R(); _.Move(WS_DTMOVABE, _ws_dtmovabe_r); VarBasis.RedefinePassValue(WS_DTMOVABE, _ws_dtmovabe_r, WS_DTMOVABE); _ws_dtmovabe_r.ValueChanged += () => { _.Move(_ws_dtmovabe_r, WS_DTMOVABE); }; return _ws_dtmovabe_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtmovabe_r, WS_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_DTMOVABE_R : VarBasis
            {
                /*"     10           WS-ANO-DTMOVABE   PIC 9(004).*/
                public IntBasis WS_ANO_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-MES-DTMOVABE   PIC 9(002).*/
                public IntBasis WS_MES_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-DIA-DTMOVABE   PIC 9(002).*/
                public IntBasis WS_DIA_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05   WS-IDADE                   PIC S9(009) COMP VALUE +0.*/

                public _REDEF_VA5437B_WS_DTMOVABE_R()
                {
                    WS_ANO_DTMOVABE.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_MES_DTMOVABE.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_DIA_DTMOVABE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05   WS-NRTITFDCAP              PIC 9(012).*/
            public IntBasis WS_NRTITFDCAP { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05   WS-NRSORTE                 PIC 9(009) VALUE ZEROS.*/
            public IntBasis WS_NRSORTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05   PROPOFID-DATA-PROPOSTA     PIC X(010) VALUE SPACES.*/
            public StringBasis PROPOFID_DATA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WS-VALORES-AX.*/
            public VA5437B_WS_VALORES_AX WS_VALORES_AX { get; set; } = new VA5437B_WS_VALORES_AX();
            public class VA5437B_WS_VALORES_AX : VarBasis
            {
                /*"     10           WS-VALOR-9          PIC S9(11)V99.*/
                public DoubleBasis WS_VALOR_9 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99."), 2);
                /*"     10           WS-VALOR-INT        PIC Z9.*/
                public IntBasis WS_VALOR_INT { get; set; } = new IntBasis(new PIC("9", "2", "Z9."));
                /*"     10           WS-VALOR-INT-X      PIC X(10).*/
                public StringBasis WS_VALOR_INT_X { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10           WS-VALOR            PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"     10           WS-VALOR-0          PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis WS_VALOR_0 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    05  WS-DIA-9                      PIC 9(02).*/
            }
            public IntBasis WS_DIA_9 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05  WS-DIA-X REDEFINES WS-DIA-9   PIC X(02).*/
            private _REDEF_StringBasis _ws_dia_x { get; set; }
            public _REDEF_StringBasis WS_DIA_X
            {
                get { _ws_dia_x = new _REDEF_StringBasis(new PIC("X", "02", "X(02).")); ; _.Move(WS_DIA_9, _ws_dia_x); VarBasis.RedefinePassValue(WS_DIA_9, _ws_dia_x, WS_DIA_9); _ws_dia_x.ValueChanged += () => { _.Move(_ws_dia_x, WS_DIA_9); }; return _ws_dia_x; }
                set { VarBasis.RedefinePassValue(value, _ws_dia_x, WS_DIA_9); }
            }  //Redefines
            /*"    05  WS-COBER-DESC                 PIC X(45).*/
            public StringBasis WS_COBER_DESC { get; set; } = new StringBasis(new PIC("X", "45", "X(45)."), @"");
            /*"    05            WS-LC09-JDE         PIC X(008).*/
            public StringBasis WS_LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05            LC01-LINHA01.*/
            public VA5437B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VA5437B_LC01_LINHA01();
            public class VA5437B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC08-LINHA08.*/
            }
            public VA5437B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VA5437B_LC08_LINHA08();
            public class VA5437B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER       PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09.*/
            }
            public VA5437B_LC09_LINHA09 LC09_LINHA09 { get; set; } = new VA5437B_LC09_LINHA09();
            public class VA5437B_LC09_LINHA09 : VarBasis
            {
                /*"      10          FILLER            PIC X(001) VALUE '('.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"(");
                /*"      10          LC09-FORM.*/
                public VA5437B_LC09_FORM LC09_FORM { get; set; } = new VA5437B_LC09_FORM();
                public class VA5437B_LC09_FORM : VarBasis
                {
                    /*"        15        LC09-JDE          PIC X(008).*/
                    public StringBasis LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"        15        FILLER            PIC X(001) VALUE '.'.*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                    /*"        15        FILLER            PIC X(003) VALUE 'dbm'.*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"dbm");
                    /*"      10          FILLER            PIC X(002) VALUE ')'.*/
                }
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @")");
                /*"      10          FILLER            PIC X(008) VALUE 'STARTDBM'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"STARTDBM");
                /*"    05            FILLER REDEFINES     LC09-LINHA09.*/
            }
            private _REDEF_VA5437B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VA5437B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VA5437B_FILLER_11(); _.Move(LC09_LINHA09, _filler_11); VarBasis.RedefinePassValue(LC09_LINHA09, _filler_11, LC09_LINHA09); _filler_11.ValueChanged += () => { _.Move(_filler_11, LC09_LINHA09); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, LC09_LINHA09); }
            }  //Redefines
            public class _REDEF_VA5437B_FILLER_11 : VarBasis
            {
                /*"      10          LC09-LIN09        PIC X(023).*/
                public StringBasis LC09_LIN09 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"    05            LC10-LINHA10.*/

                public _REDEF_VA5437B_FILLER_11()
                {
                    LC09_LIN09.ValueChanged += OnValueChanged;
                }

            }
            public VA5437B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VA5437B_LC10_LINHA10();
            public class VA5437B_LC10_LINHA10 : VarBasis
            {
                /*"      10         FILLER              PIC X(051) VALUE     'ESTIPULANTE|APOLICE|NUM-CERTIF|DT-VIG|SEGURADO|CPF|'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ESTIPULANTE|APOLICE|NUM_CERTIF|DT_VIG|SEGURADO|CPF|");
                /*"      10         FILLER              PIC X(050) VALUE     'COBER01|CAPIT01|DIVPRM01|COBER02|CAPIT02|DIVPRM02|'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER01|CAPIT01|DIVPRM01|COBER02|CAPIT02|DIVPRM02|");
                /*"      10         FILLER              PIC X(050) VALUE     'COBER03|CAPIT03|DIVPRM03|COBER04|CAPIT04|DIVPRM04|'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER03|CAPIT03|DIVPRM03|COBER04|CAPIT04|DIVPRM04|");
                /*"      10         FILLER              PIC X(050) VALUE     'COBER05|CAPIT05|DIVPRM05|COBER06|CAPIT06|DIVPRM06|'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER05|CAPIT05|DIVPRM05|COBER06|CAPIT06|DIVPRM06|");
                /*"      10         FILLER              PIC X(050) VALUE     'COBER07|CAPIT07|DIVPRM07|COBER08|CAPIT08|DIVPRM08|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER07|CAPIT07|DIVPRM07|COBER08|CAPIT08|DIVPRM08|");
                /*"      10         FILLER              PIC X(050) VALUE     'COBER09|CAPIT09|DIVPRM09|COBER10|CAPIT10|DIVPRM10|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER09|CAPIT09|DIVPRM09|COBER10|CAPIT10|DIVPRM10|");
                /*"      10         FILLER              PIC X(050) VALUE     'COBER11|CAPIT11|DIVPRM11|COBER12|CAPIT12|DIVPRM12|'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER11|CAPIT11|DIVPRM11|COBER12|CAPIT12|DIVPRM12|");
                /*"      10         FILLER              PIC X(025) VALUE     'COBER13|CAPIT13|DIVPRM13|'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COBER13|CAPIT13|DIVPRM13|");
                /*"      10         FILLER              PIC X(049) VALUE     'CAREN01|CAREN02|CAREN03|CAREN04|CAREN05|DT-CAPIT|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"CAREN01|CAREN02|CAREN03|CAREN04|CAREN05|DT_CAPIT|");
                /*"      10         FILLER              PIC X(013) VALUE     'CONTA-DEBITO|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CONTA_DEBITO|");
                /*"      10         FILLER              PIC X(045) VALUE     'CUSTO|DIA-COB|BENEF1|PARENT1|PART1|BENEF2|PAR'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"CUSTO|DIA_COB|BENEF1|PARENT1|PART1|BENEF2|PAR");
                /*"      10         FILLER              PIC X(051) VALUE     'ENT2|PART2|BENEF3|PARENT3|PART3|BENEF4|PARENT4|PART'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ENT2|PART2|BENEF3|PARENT3|PART3|BENEF4|PARENT4|PART");
                /*"      10         FILLER              PIC X(051) VALUE     '4|BENEF5|PARENT5|PART5|BENEF6|PARENT6|PART6|BENEF7|'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"4|BENEF5|PARENT5|PART5|BENEF6|PARENT6|PART6|BENEF7|");
                /*"      10         FILLER              PIC X(051) VALUE     'PARENT7|PART7|BENEF8|PARENT8|PART8|BENEF9|PARENT9|P'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"PARENT7|PART7|BENEF8|PARENT8|PART8|BENEF9|PARENT9|P");
                /*"      10         FILLER              PIC X(030) VALUE     'ART9|BENEF10|PARENT10|PART10|'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"ART9|BENEF10|PARENT10|PART10|");
                /*"      10         FILLER              PIC X(029) VALUE     'DTPOSTAGEM|NUMOBJETO|DESTINA'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"DTPOSTAGEM|NUMOBJETO|DESTINA");
                /*"      10         FILLER              PIC X(051) VALUE     'TARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"TARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET");
                /*"      10         FILLER              PIC X(051) VALUE     '-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-UF|CODIGO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_UF|CODIGO");
                /*"      10         FILLER              PIC X(051) VALUE     '-CIF|POSTNET|REMET-CEP|N-CUSTO|DATADIA|CLIENTE|DT-V'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_CIF|POSTNET|REMET_CEP|N_CUSTO|DATADIA|CLIENTE|DT_V");
                /*"      10         FILLER              PIC X(051) VALUE     'IG1|DT-VIG2|TEXTO|EMAIL|OPCAO-PAG|IDADE|ID-SEXO|REN'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IG1|DT_VIG2|TEXTO|EMAIL|OPCAO_PAG|IDADE|ID_SEXO|REN");
                /*"      10         FILLER              PIC X(051) VALUE     'DA-IND|RENDA-FAM|COD-PRODUTO|NOME-PRODUTO|OPCAO-CON'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DA_IND|RENDA_FAM|COD_PRODUTO|NOME_PRODUTO|OPCAO_CON");
                /*"      10         FILLER              PIC X(029) VALUE     'JUGE|FORM-CAMP|NUM-SORTEIOS|D'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"JUGE|FORM_CAMP|NUM_SORTEIOS|D");
                /*"      10         FILLER              PIC X(051) VALUE     'AT-NASC|COD-SUSEP|PREMIO-BRU|PREMIO-LIQ|IOF-PREMIO|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"AT_NASC|COD_SUSEP|PREMIO_BRU|PREMIO_LIQ|IOF_PREMIO|");
                /*"      10         FILLER              PIC X(045) VALUE     'DT-INIVIG|DT-EMISS|PERI-VIGAPOL|COD-SUSEPCAP|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DT_INIVIG|DT_EMISS|PERI_VIGAPOL|COD_SUSEPCAP|");
                /*"      10         FILLER              PIC X(051) VALUE     'SEGURADO-SOCIAL|DESTINATARIO-SOCIAL|CLIENTE-SOCIAL|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"SEGURADO_SOCIAL|DESTINATARIO_SOCIAL|CLIENTE_SOCIAL|");
                /*"     05            LC10-LINHTML.*/
                public VA5437B_LC10_LINHTML LC10_LINHTML { get; set; } = new VA5437B_LC10_LINHTML();
                public class VA5437B_LC10_LINHTML : VarBasis
                {
                    /*"      10         FILLER              PIC X(051) VALUE     'ESTIPULANTE;APOLICE;NUM-CERTIF;DT-VIG;SEGURADO;CPF;'.*/
                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ESTIPULANTE;APOLICE;NUM_CERTIF;DT_VIG;SEGURADO;CPF;");
                    /*"      10         FILLER              PIC X(050) VALUE     'COBER01;CAPIT01;DIVPRM01;COBER02;CAPIT02;DIVPRM02;'.*/
                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER01;CAPIT01;DIVPRM01;COBER02;CAPIT02;DIVPRM02;");
                    /*"      10         FILLER              PIC X(050) VALUE     'COBER03;CAPIT03;DIVPRM03;COBER04;CAPIT04;DIVPRM04;'.*/
                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER03;CAPIT03;DIVPRM03;COBER04;CAPIT04;DIVPRM04;");
                    /*"      10         FILLER              PIC X(050) VALUE     'COBER05;CAPIT05;DIVPRM05;COBER06;CAPIT06;DIVPRM06;'.*/
                    public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER05;CAPIT05;DIVPRM05;COBER06;CAPIT06;DIVPRM06;");
                    /*"      10         FILLER              PIC X(050) VALUE     'COBER07;CAPIT07;DIVPRM07;COBER08;CAPIT08;DIVPRM08;'.*/
                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER07;CAPIT07;DIVPRM07;COBER08;CAPIT08;DIVPRM08;");
                    /*"      10         FILLER              PIC X(050) VALUE     'COBER09;CAPIT09;DIVPRM09;COBER10;CAPIT10;DIVPRM10;'.*/
                    public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER09;CAPIT09;DIVPRM09;COBER10;CAPIT10;DIVPRM10;");
                    /*"      10         FILLER              PIC X(050) VALUE     'COBER11;CAPIT11;DIVPRM11;COBER12;CAPIT12;DIVPRM12;'.*/
                    public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"COBER11;CAPIT11;DIVPRM11;COBER12;CAPIT12;DIVPRM12;");
                    /*"      10         FILLER              PIC X(025) VALUE     'COBER13;CAPIT13;DIVPRM13;'.*/
                    public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COBER13;CAPIT13;DIVPRM13;");
                    /*"      10         FILLER              PIC X(049) VALUE     'CAREN01;CAREN02;CAREN03;CAREN04;CAREN05;DT-CAPIT;'.*/
                    public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"CAREN01;CAREN02;CAREN03;CAREN04;CAREN05;DT_CAPIT;");
                    /*"      10         FILLER              PIC X(013) VALUE     'CONTA-DEBITO;'.*/
                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"CONTA_DEBITO;");
                    /*"      10         FILLER              PIC X(045) VALUE     'CUSTO;DIA-COB;BENEF1;PARENT1;PART1;BENEF2;PAR'.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"CUSTO;DIA_COB;BENEF1;PARENT1;PART1;BENEF2;PAR");
                    /*"      10         FILLER              PIC X(051) VALUE     'ENT2;PART2;BENEF3;PARENT3;PART3;BENEF4;PARENT4;PART'.*/
                    public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ENT2;PART2;BENEF3;PARENT3;PART3;BENEF4;PARENT4;PART");
                    /*"      10         FILLER              PIC X(051) VALUE     '4;BENEF5;PARENT5;PART5;BENEF6;PARENT6;PART6;BENEF7;'.*/
                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"4;BENEF5;PARENT5;PART5;BENEF6;PARENT6;PART6;BENEF7;");
                    /*"      10         FILLER              PIC X(051) VALUE     'PARENT7;PART7;BENEF8;PARENT8;PART8;BENEF9;PARENT9;P'.*/
                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"PARENT7;PART7;BENEF8;PARENT8;PART8;BENEF9;PARENT9;P");
                    /*"      10         FILLER              PIC X(030) VALUE     'ART9;BENEF10;PARENT10;PART10;'.*/
                    public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"ART9;BENEF10;PARENT10;PART10;");
                    /*"      10         FILLER              PIC X(029) VALUE     'DTPOSTAGEM;NUMOBJETO;DESTINA'.*/
                    public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"DTPOSTAGEM;NUMOBJETO;DESTINA");
                    /*"      10         FILLER              PIC X(051) VALUE     'TARIO;ENDERECO;BAIRRO;CIDADE;UF;CEP;REMETENTE;REMET'.*/
                    public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"TARIO;ENDERECO;BAIRRO;CIDADE;UF;CEP;REMETENTE;REMET");
                    /*"      10         FILLER              PIC X(051) VALUE     '-ENDERECO;REMET-BAIRRO;REMET-CIDADE;REMET-UF;CODIGO'.*/
                    public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_ENDERECO;REMET_BAIRRO;REMET_CIDADE;REMET_UF;CODIGO");
                    /*"      10         FILLER              PIC X(051) VALUE     '-CIF;POSTNET;REMET-CEP;N-CUSTO;DATADIA;CLIENTE;DT-V'.*/
                    public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_CIF;POSTNET;REMET_CEP;N_CUSTO;DATADIA;CLIENTE;DT_V");
                    /*"      10         FILLER              PIC X(051) VALUE     'IG1;DT-VIG2;TEXTO;EMAIL;OPCAO-PAG;IDADE;ID-SEXO;REN'.*/
                    public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IG1;DT_VIG2;TEXTO;EMAIL;OPCAO_PAG;IDADE;ID_SEXO;REN");
                    /*"      10         FILLER              PIC X(051) VALUE     'DA-IND;RENDA-FAM;COD-PRODUTO;NOME-PRODUTO;OPCAO-CON'.*/
                    public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DA_IND;RENDA_FAM;COD_PRODUTO;NOME_PRODUTO;OPCAO_CON");
                    /*"      10         FILLER              PIC X(029) VALUE     'JUGE;FORM-CAMP;NUM-SORTEIOS;D'.*/
                    public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"JUGE;FORM_CAMP;NUM_SORTEIOS;D");
                    /*"      10         FILLER              PIC X(051) VALUE     'AT-NASC;COD-SUSEP;PREMIO-BRU;PREMIO-LIQ;IOF-PREMIO;'.*/
                    public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"AT_NASC;COD_SUSEP;PREMIO_BRU;PREMIO_LIQ;IOF_PREMIO;");
                    /*"      10         FILLER              PIC X(045) VALUE     'DT-INIVIG;DT-EMISS;PERI-VIGAPOL;COD-SUSEPCAP;'.*/
                    public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DT_INIVIG;DT_EMISS;PERI_VIGAPOL;COD_SUSEPCAP;");
                    /*"      10         FILLER              PIC X(051) VALUE     'SEGURADO-SOCIAL;DESTINATARIO-SOCIAL;CLIENTE-SOCIAL;'.*/
                    public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"SEGURADO_SOCIAL;DESTINATARIO_SOCIAL;CLIENTE_SOCIAL;");
                    /*"    05            LC11-LINHA11.*/
                }
            }
            public VA5437B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VA5437B_LC11_LINHA11();
            public class VA5437B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-ESTIPULANTE    PIC X(040).*/
                public StringBasis LC11_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-APOLICE        PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LC11_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCERTIF       PIC ZZZZZZZZZZZZZZZ.*/
                public StringBasis LC11_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCERTIF       PIC 9(001).*/
                public IntBasis LC11_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTINIVIG       PIC X(010).*/
                public StringBasis LC11_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO     PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCPF          PIC 999.999.999.*/
                public IntBasis LC11_NRCPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCPF          PIC 9(002).*/
                public IntBasis LC11_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COBERTURAS.*/
                public VA5437B_LC11_COBERTURAS LC11_COBERTURAS { get; set; } = new VA5437B_LC11_COBERTURAS();
                public class VA5437B_LC11_COBERTURAS : VarBasis
                {
                    /*"         15       LC11-COBER-OCC OCCURS 13 TIMES.*/
                    public ListBasis<VA5437B_LC11_COBER_OCC> LC11_COBER_OCC { get; set; } = new ListBasis<VA5437B_LC11_COBER_OCC>(13);
                    public class VA5437B_LC11_COBER_OCC : VarBasis
                    {
                        /*"           20     LC11-STRING1        PIC X(070) VALUE SPACES.*/
                        public StringBasis LC11_STRING1 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                        /*"           20     LC11-DELIMIT-04     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-VALORA         PIC X(013).*/
                        public StringBasis LC11_VALORA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                        /*"           20     LC11-DELIMIT-05     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-VLR-CUSTO-PREM PIC X(013).*/
                        public StringBasis LC11_VLR_CUSTO_PREM { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                        /*"           20     LC11-DELIMIT-06     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-CARENCIAS.*/
                    }
                }
                public VA5437B_LC11_CARENCIAS LC11_CARENCIAS { get; set; } = new VA5437B_LC11_CARENCIAS();
                public class VA5437B_LC11_CARENCIAS : VarBasis
                {
                    /*"         15       LC11-CAREN-OCC OCCURS 5 TIMES.*/
                    public ListBasis<VA5437B_LC11_CAREN_OCC> LC11_CAREN_OCC { get; set; } = new ListBasis<VA5437B_LC11_CAREN_OCC>(5);
                    public class VA5437B_LC11_CAREN_OCC : VarBasis
                    {
                        /*"           20     LC11-STR-CARENCIA   PIC X(100) VALUE SPACES.*/
                        public StringBasis LC11_STR_CARENCIA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                        /*"           20     LC11-DELIMIT-CAR    PIC X(001).*/
                        public StringBasis LC11_DELIMIT_CAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-DTALTCAP       PIC X(010).*/
                    }
                }
                public StringBasis LC11_DTALTCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAOPAG       PIC X(035) VALUE SPACES.*/
                public StringBasis LC11_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"       10         LC11-OPCAOPAG-R     REDEFINES                  LC11-OPCAOPAG.*/
                private _REDEF_VA5437B_LC11_OPCAOPAG_R _lc11_opcaopag_r { get; set; }
                public _REDEF_VA5437B_LC11_OPCAOPAG_R LC11_OPCAOPAG_R
                {
                    get { _lc11_opcaopag_r = new _REDEF_VA5437B_LC11_OPCAOPAG_R(); _.Move(LC11_OPCAOPAG, _lc11_opcaopag_r); VarBasis.RedefinePassValue(LC11_OPCAOPAG, _lc11_opcaopag_r, LC11_OPCAOPAG); _lc11_opcaopag_r.ValueChanged += () => { _.Move(_lc11_opcaopag_r, LC11_OPCAOPAG); }; return _lc11_opcaopag_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_opcaopag_r, LC11_OPCAOPAG); }
                }  //Redefines
                public class _REDEF_VA5437B_LC11_OPCAOPAG_R : VarBasis
                {
                    /*"         15       LC11-AGECTADEB      PIC 9(004).*/
                    public IntBasis LC11_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15       LC11-PONTO1         PIC X(001).*/
                    public StringBasis LC11_PONTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       LC11-OPRCTADEB      PIC 9(004).*/
                    public IntBasis LC11_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15       LC11-PONTO2         PIC X(001).*/
                    public StringBasis LC11_PONTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       LC11-NUMCTADEB      PIC 9(012).*/
                    public IntBasis LC11_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"         15       LC11-TRACO          PIC X(001).*/
                    public StringBasis LC11_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"         15       LC11-DIGCTADEB      PIC 9(001).*/
                    public IntBasis LC11_DIGCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"         15       FILLER              PIC X(011).*/
                    public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                    public _REDEF_VA5437B_LC11_OPCAOPAG_R()
                    {
                        LC11_AGECTADEB.ValueChanged += OnValueChanged;
                        LC11_PONTO1.ValueChanged += OnValueChanged;
                        LC11_OPRCTADEB.ValueChanged += OnValueChanged;
                        LC11_PONTO2.ValueChanged += OnValueChanged;
                        LC11_NUMCTADEB.ValueChanged += OnValueChanged;
                        LC11_TRACO.ValueChanged += OnValueChanged;
                        LC11_DIGCTADEB.ValueChanged += OnValueChanged;
                        FILLER_71.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NCUSTO1        PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_NCUSTO1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         LC11-VLPREMIO       PIC ZZZZZ9,99.*/
                public DoubleBasis LC11_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DIA-DEB        PIC 9(002).*/
                public IntBasis LC11_DIA_DEB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         LC11-DIA-DEB-R REDEFINES LC11-DIA-DEB.*/
                private _REDEF_VA5437B_LC11_DIA_DEB_R _lc11_dia_deb_r { get; set; }
                public _REDEF_VA5437B_LC11_DIA_DEB_R LC11_DIA_DEB_R
                {
                    get { _lc11_dia_deb_r = new _REDEF_VA5437B_LC11_DIA_DEB_R(); _.Move(LC11_DIA_DEB, _lc11_dia_deb_r); VarBasis.RedefinePassValue(LC11_DIA_DEB, _lc11_dia_deb_r, LC11_DIA_DEB); _lc11_dia_deb_r.ValueChanged += () => { _.Move(_lc11_dia_deb_r, LC11_DIA_DEB); }; return _lc11_dia_deb_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_dia_deb_r, LC11_DIA_DEB); }
                }  //Redefines
                public class _REDEF_VA5437B_LC11_DIA_DEB_R : VarBasis
                {
                    /*"         15       LC11-DIA-DEB-ALFA   PIC X(002).*/
                    public StringBasis LC11_DIA_DEB_ALFA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                    public _REDEF_VA5437B_LC11_DIA_DEB_R()
                    {
                        LC11_DIA_DEB_ALFA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BENEFICIARIOS.*/
                public VA5437B_LC11_BENEFICIARIOS LC11_BENEFICIARIOS { get; set; } = new VA5437B_LC11_BENEFICIARIOS();
                public class VA5437B_LC11_BENEFICIARIOS : VarBasis
                {
                    /*"         15       LC11-BENEF-OCC OCCURS 10 TIMES.*/
                    public ListBasis<VA5437B_LC11_BENEF_OCC> LC11_BENEF_OCC { get; set; } = new ListBasis<VA5437B_LC11_BENEF_OCC>(10);
                    public class VA5437B_LC11_BENEF_OCC : VarBasis
                    {
                        /*"           20     LC11-NOME-BENEF     PIC X(040).*/
                        public StringBasis LC11_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                        /*"           20     LC11-DELIMIT-01     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-PARENTESCO     PIC X(020).*/
                        public StringBasis LC11_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                        /*"           20     LC11-DELIMIT-02     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"           20     LC11-PARTICIP-X     PIC X(006).*/
                        public StringBasis LC11_PARTICIP_X { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                        /*"           20     LC11-PARTICIP       REDEFINES                  LC11-PARTICIP-X     PIC ZZ9,99.*/
                        private _REDEF_DoubleBasis _lc11_particip { get; set; }
                        public _REDEF_DoubleBasis LC11_PARTICIP
                        {
                            get { _lc11_particip = new _REDEF_DoubleBasis(new PIC("9", "ZZ9,99", "ZZ9V99."), 2); ; _.Move(LC11_PARTICIP_X, _lc11_particip); VarBasis.RedefinePassValue(LC11_PARTICIP_X, _lc11_particip, LC11_PARTICIP_X); _lc11_particip.ValueChanged += () => { _.Move(_lc11_particip, LC11_PARTICIP_X); }; return _lc11_particip; }
                            set { VarBasis.RedefinePassValue(value, _lc11_particip, LC11_PARTICIP_X); }
                        }  //Redefines
                        /*"           20     LC11-DELIMIT-03     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-DTPOSTAGEM     PIC X(010).*/
                    }
                }
                public StringBasis LC11_DTPOSTAGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEQUENCIA      PIC X(007).*/
                public StringBasis LC11_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO_END { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO       PIC X(072).*/
                public StringBasis LC11_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO         PIC X(072).*/
                public StringBasis LC11_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE         PIC X(072).*/
                public StringBasis LC11_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF             PIC X(002).*/
                public StringBasis LC11_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP            PIC 99999.*/
                public IntBasis LC11_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL      PIC 999.*/
                public IntBasis LC11_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         FILLER              PIC X(014) VALUE                 'CAIXA SEGUROS'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CAIXA SEGUROS");
                /*"       10         LC11-REMETENTE-G.*/
                public VA5437B_LC11_REMETENTE_G LC11_REMETENTE_G { get; set; } = new VA5437B_LC11_REMETENTE_G();
                public class VA5437B_LC11_REMETENTE_G : VarBasis
                {
                    /*"         15       LC11-REMETENTE-S    PIC X(007).*/
                    public StringBasis LC11_REMETENTE_S { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15       LC11-REMETENTE      PIC X(024).*/
                    public StringBasis LC11_REMETENTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-REM   PIC X(040).*/
                public StringBasis LC11_ENDERECO_REM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO-REM     PIC X(020).*/
                public StringBasis LC11_BAIRRO_REM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-REM     PIC X(020).*/
                public StringBasis LC11_CIDADE_REM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-REM         PIC X(002).*/
                public StringBasis LC11_UF_REM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         CODIGO-CIF          PIC X(034) VALUE ALL '@'.*/
                public StringBasis CODIGO_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         POSTNET             PIC X(011) VALUE ALL '#'.*/
                public StringBasis POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP-REM        PIC 99999.*/
                public IntBasis LC11_CEP_REM { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL-REM  PIC 999.*/
                public IntBasis LC11_CEP_COMPL_REM { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NCUSTO         PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_NCUSTO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DATADIA        PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DATADIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE        PIC X(090) VALUE SPACES.*/
                public StringBasis LC11_CLIENTE { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVIG-PRIN     PIC X(060) VALUE SPACES.*/
                public StringBasis LC11_DTVIG_PRIN { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVIG-DEPE     PIC X(060) VALUE SPACES.*/
                public StringBasis LC11_DTVIG_DEPE { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-TEXTO          PIC X(090) VALUE SPACES.*/
                public StringBasis LC11_TEXTO { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-EMAIL          PIC X(050) VALUE SPACES.*/
                public StringBasis LC11_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAO-PAG      PIC X(030) VALUE SPACES.*/
                public StringBasis LC11_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IDADE          PIC 9(003) VALUE ZEROS.*/
                public IntBasis LC11_IDADE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEXO           PIC X(001) VALUE SPACES.*/
                public StringBasis LC11_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-RENDA-IND      PIC 9(002) VALUE ZEROS.*/
                public IntBasis LC11_RENDA_IND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-RENDA-FAM      PIC X(002) VALUE ZEROS.*/
                public StringBasis LC11_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-PRODUTO    PIC 9(004) VALUE ZEROS.*/
                public IntBasis LC11_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-PRODUTO   PIC X(030) VALUE SPACES.*/
                public StringBasis LC11_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAO-CONJ     PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_OPCAO_CONJ { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-FORM-CAMP      PIC X(050) VALUE SPACES.*/
                public StringBasis LC11_FORM_CAMP { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRSORTE-RED    PIC X(050).*/
                public StringBasis LC11_NRSORTE_RED { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"       10         LC11-SORTE  REDEFINES LC11-NRSORTE-RED.*/
                private _REDEF_VA5437B_LC11_SORTE _lc11_sorte { get; set; }
                public _REDEF_VA5437B_LC11_SORTE LC11_SORTE
                {
                    get { _lc11_sorte = new _REDEF_VA5437B_LC11_SORTE(); _.Move(LC11_NRSORTE_RED, _lc11_sorte); VarBasis.RedefinePassValue(LC11_NRSORTE_RED, _lc11_sorte, LC11_NRSORTE_RED); _lc11_sorte.ValueChanged += () => { _.Move(_lc11_sorte, LC11_NRSORTE_RED); }; return _lc11_sorte; }
                    set { VarBasis.RedefinePassValue(value, _lc11_sorte, LC11_NRSORTE_RED); }
                }  //Redefines
                public class _REDEF_VA5437B_LC11_SORTE : VarBasis
                {
                    /*"         15       LC11-SORTE1         OCCURS 5 TIMES.*/
                    public ListBasis<VA5437B_LC11_SORTE1> LC11_SORTE1 { get; set; } = new ListBasis<VA5437B_LC11_SORTE1>(5);
                    public class VA5437B_LC11_SORTE1 : VarBasis
                    {
                        /*"           20     LC11-NRSORTE        PIC X(009).*/
                        public StringBasis LC11_NRSORTE { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                        /*"           20     LC11-NRSORTE-S      PIC X(001).*/
                        public StringBasis LC11_NRSORTE_S { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                        public VA5437B_LC11_SORTE1()
                        {
                            LC11_NRSORTE.ValueChanged += OnValueChanged;
                            LC11_NRSORTE_S.ValueChanged += OnValueChanged;
                        }

                    }

                    public _REDEF_VA5437B_LC11_SORTE()
                    {
                        LC11_SORTE1.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DAT-NASC       PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DAT_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-SUSEP      PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-PREMIO-BRU     PIC X(013).*/
                public StringBasis LC11_PREMIO_BRU { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-PREMIO-LIQ     PIC X(013).*/
                public StringBasis LC11_PREMIO_LIQ { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IOF-PREMIO     PIC X(013).*/
                public StringBasis LC11_IOF_PREMIO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DT-INI-VIG     PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DT_INI_VIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DT-EMISSAO     PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DT_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-PERI-VIG-APOL  PIC X(023) VALUE SPACES.*/
                public StringBasis LC11_PERI_VIG_APOL { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-SUSEPCAP   PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_COD_SUSEPCAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-SOC PIC X(100).*/
                public StringBasis LC11_NOME_RAZAO_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END-SOC PIC X(100).*/
                public StringBasis LC11_NOME_RAZAO_END_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE-SOC    PIC X(100) VALUE SPACES.*/
                public StringBasis LC11_CLIENTE_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    05            LC12-LINHA12.*/
            }
            public VA5437B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VA5437B_LC12_LINHA12();
            public class VA5437B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(005) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"%%EOF");
                /*"    05            WS-NRSORTEIO-ANT    PIC S9(9) COMP VALUE ZEROS*/
            }
            public IntBasis WS_NRSORTEIO_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05            AC-PAGINA           PIC 9(003) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05            AC-CONTA1           PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-QUOCIENTE        PIC 9(009) VALUE ZEROS.*/
            public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05            WS-RESTO            PIC 9(009) VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05            WS-SEQ              PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_SEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-SEQ-INICIAL      PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_SEQ_INICIAL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-QTD-OBJ          PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_QTD_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTROLE         PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTR-AMAR       PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_CONTR_AMAR { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTR-OBJ        PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_CONTR_OBJ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-CONTR-200        PIC 9(006) VALUE ZEROS.*/
            public IntBasis WS_CONTR_200 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-NUM-APOLICE-ANT  PIC 9(013).*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05            WS-CODSUBES-ANT     PIC 9(005).*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"    05            WS-JDE-TFORM    PIC X(008) VALUE SPACES.*/
            public StringBasis WS_JDE_TFORM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05            WS-JDE-ANT          PIC X(008)                                      VALUE '********'.*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"********");
            /*"    05            WS-OPER-ANT         PIC 9(004).*/
            public IntBasis WS_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-TP-ARQSAIDA-ANT  PIC X(014) VALUE ' '.*/
            public StringBasis WS_TP_ARQSAIDA_ANT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" ");
            /*"    05            WS-CEP-G-ANT        PIC 9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05            WS-NOME-COR-ANT.*/
            public VA5437B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VA5437B_WS_NOME_COR_ANT();
            public class VA5437B_WS_NOME_COR_ANT : VarBasis
            {
                /*"      10          WS-FAIXA1-ANT       PIC 9(008).*/
                public IntBasis WS_FAIXA1_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          WS-FAIXA2-ANT       PIC 9(008).*/
                public IntBasis WS_FAIXA2_ANT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          WS-NOME-ANT         PIC X(072).*/
                public StringBasis WS_NOME_ANT { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"    05            WS-INF              PIC 9(009).*/
            }
            public IntBasis WS_INF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            WS-SUP              PIC 9(009).*/
            public IntBasis WS_SUP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            WS-IND              PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WS-I                PIC  9(002).*/
            public IntBasis WS_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            WS-ICAR             PIC  9(002).*/
            public IntBasis WS_ICAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            WS-COD-RELAT-CAR    PIC  X(008) VALUE SPACES.*/
            public StringBasis WS_COD_RELAT_CAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05            WS-I-LIMP-CAR       PIC  9(002).*/
            public IntBasis WS_I_LIMP_CAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05            WS-FIM-TAB          PIC  X(001) VALUE ' '.*/
            public StringBasis WS_FIM_TAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05            WS-FIM-SORT         PIC  X(001) VALUE ' '.*/
            public StringBasis WS_FIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05            WS-SEQUENCIA        PIC  9(006) VALUE 0.*/
            public IntBasis WS_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-GRAVA-ARQ        PIC  9(006) VALUE 0.*/
            public IntBasis WS_GRAVA_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-REJEITA-SORT     PIC  9(006) VALUE 0.*/
            public IntBasis WS_REJEITA_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-LIDOS-ARQ        PIC  9(006) VALUE 0.*/
            public IntBasis WS_LIDOS_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-GRAVA-SORT       PIC  9(006) VALUE 0.*/
            public IntBasis WS_GRAVA_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WS-IND1             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WS-IND2             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WS-SALVA-CERTIF     PIC  9(015) COMP-3                                                  VALUE  0.*/
            public IntBasis WS_SALVA_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05            WIND                PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-N              PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_N { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-N-S            PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_N_S { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WINDM               PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WINDM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-77             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_77 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-88             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_88 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            WIND-99             PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis WIND_99 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            IDX-IND1            PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis IDX_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            CONTROLA-IMP        PIC S9(004) COMP                                                  VALUE +0.*/
            public IntBasis CONTROLA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05            INF                 PIC S9(009) COMP                                                  VALUE +0.*/
            public IntBasis INF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05            SUP                 PIC S9(009) COMP                                                  VALUE +0.*/
            public IntBasis SUP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05            DEST-NUM-CEP.*/
            public VA5437B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VA5437B_DEST_NUM_CEP();
            public class VA5437B_DEST_NUM_CEP : VarBasis
            {
                /*"      15          DEST-CEP            PIC 9(005) VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15          DEST-CEP-COMPL      PIC 9(003) VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05            WS-CPF              PIC 9(015).*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            WS-CPF-R            REDEFINES                  WS-CPF.*/
            private _REDEF_VA5437B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_VA5437B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_VA5437B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_CPF_R : VarBasis
            {
                /*"      10          WS-NRCPF            PIC 9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10          WS-DVCPF            PIC 9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-CERTIF           PIC 9(015).*/

                public _REDEF_VA5437B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            WS-CERTIF-R         REDEFINES                  WS-CERTIF.*/
            private _REDEF_VA5437B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VA5437B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VA5437B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_CERTIF_R : VarBasis
            {
                /*"      10          WS-NRCERTIF         PIC 9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10          WS-DVCERTIF         PIC 9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05            WS-DATA-SQL.*/

                public _REDEF_VA5437B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public VA5437B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA5437B_WS_DATA_SQL();
            public class VA5437B_WS_DATA_SQL : VarBasis
            {
                /*"      10          WS-SEC-ANO          PIC 9(004) VALUE ZEROS.*/
                public IntBasis WS_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          WS-SEC-ANO-R        REDEFINES                  WS-SEC-ANO.*/
                private _REDEF_VA5437B_WS_SEC_ANO_R _ws_sec_ano_r { get; set; }
                public _REDEF_VA5437B_WS_SEC_ANO_R WS_SEC_ANO_R
                {
                    get { _ws_sec_ano_r = new _REDEF_VA5437B_WS_SEC_ANO_R(); _.Move(WS_SEC_ANO, _ws_sec_ano_r); VarBasis.RedefinePassValue(WS_SEC_ANO, _ws_sec_ano_r, WS_SEC_ANO); _ws_sec_ano_r.ValueChanged += () => { _.Move(_ws_sec_ano_r, WS_SEC_ANO); }; return _ws_sec_ano_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_sec_ano_r, WS_SEC_ANO); }
                }  //Redefines
                public class _REDEF_VA5437B_WS_SEC_ANO_R : VarBasis
                {
                    /*"        15        WS-ANO-SQL          PIC 9(004).*/
                    public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10          FILLER              PIC X(001).*/

                    public _REDEF_VA5437B_WS_SEC_ANO_R()
                    {
                        WS_ANO_SQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-SQL          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-DIA-SQL          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05            WS-DATA-I.*/
            }
            public VA5437B_WS_DATA_I WS_DATA_I { get; set; } = new VA5437B_WS_DATA_I();
            public class VA5437B_WS_DATA_I : VarBasis
            {
                /*"      10          WS-DIA-I            PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_DIA_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLERB1            PIC X(001).*/
                public StringBasis FILLERB1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-I            PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_MES_I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLERB2            PIC X(001).*/
                public StringBasis FILLERB2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-SEC-ANO-I        PIC 9(004).*/
                public IntBasis WS_SEC_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          WS-SEC-ANO-IR       REDEFINES                  WS-SEC-ANO-I.*/
                private _REDEF_VA5437B_WS_SEC_ANO_IR _ws_sec_ano_ir { get; set; }
                public _REDEF_VA5437B_WS_SEC_ANO_IR WS_SEC_ANO_IR
                {
                    get { _ws_sec_ano_ir = new _REDEF_VA5437B_WS_SEC_ANO_IR(); _.Move(WS_SEC_ANO_I, _ws_sec_ano_ir); VarBasis.RedefinePassValue(WS_SEC_ANO_I, _ws_sec_ano_ir, WS_SEC_ANO_I); _ws_sec_ano_ir.ValueChanged += () => { _.Move(_ws_sec_ano_ir, WS_SEC_ANO_I); }; return _ws_sec_ano_ir; }
                    set { VarBasis.RedefinePassValue(value, _ws_sec_ano_ir, WS_SEC_ANO_I); }
                }  //Redefines
                public class _REDEF_VA5437B_WS_SEC_ANO_IR : VarBasis
                {
                    /*"        15        WS-ANO-I            PIC 9(004).*/
                    public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05            WS-DATA-SEG.*/

                    public _REDEF_VA5437B_WS_SEC_ANO_IR()
                    {
                        WS_ANO_I.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA5437B_WS_DATA_SEG WS_DATA_SEG { get; set; } = new VA5437B_WS_DATA_SEG();
            public class VA5437B_WS_DATA_SEG : VarBasis
            {
                /*"      07          WS-STRING1          PIC X(020) VALUE SPACES.*/
                public StringBasis WS_STRING1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      07          WS-PERI-VIGENCIA.*/
                public VA5437B_WS_PERI_VIGENCIA WS_PERI_VIGENCIA { get; set; } = new VA5437B_WS_PERI_VIGENCIA();
                public class VA5437B_WS_PERI_VIGENCIA : VarBasis
                {
                    /*"        10          WS-DTINIVIG.*/
                    public VA5437B_WS_DTINIVIG WS_DTINIVIG { get; set; } = new VA5437B_WS_DTINIVIG();
                    public class VA5437B_WS_DTINIVIG : VarBasis
                    {
                        /*"          15        WS-DIA-INI          PIC X(002).*/
                        public StringBasis WS_DIA_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"          15        WS-BARRA1           PIC X(001) VALUE '/'.*/
                        public StringBasis WS_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                        /*"          15        WS-MES-INI          PIC X(002).*/
                        public StringBasis WS_MES_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"          15        WS-BARRA2           PIC X(001) VALUE '/'.*/
                        public StringBasis WS_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                        /*"          15        WS-ANO-INI          PIC X(004).*/
                        public StringBasis WS_ANO_INI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                        /*"        10          WS-FIL-A            PIC X(003) VALUE ' A '.*/
                    }
                    public StringBasis WS_FIL_A { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                    /*"        10          WS-DTTERVIG.*/
                    public VA5437B_WS_DTTERVIG WS_DTTERVIG { get; set; } = new VA5437B_WS_DTTERVIG();
                    public class VA5437B_WS_DTTERVIG : VarBasis
                    {
                        /*"          15        WS-DIA-TER          PIC X(002).*/
                        public StringBasis WS_DIA_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"          15        WS-BARRA3           PIC X(001) VALUE '/'.*/
                        public StringBasis WS_BARRA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                        /*"          15        WS-MES-TER          PIC X(002).*/
                        public StringBasis WS_MES_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                        /*"          15        WS-BARRA4           PIC X(001) VALUE '/'.*/
                        public StringBasis WS_BARRA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                        /*"          15        WS-ANO-TER          PIC X(004).*/
                        public StringBasis WS_ANO_TER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                        /*"      07          WS-STRING2          PIC X(003) VALUE '(*)'.*/
                    }
                }
                public StringBasis WS_STRING2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(*)");
                /*"    05            WS-DATA-INV.*/
            }
            public VA5437B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA5437B_WS_DATA_INV();
            public class VA5437B_WS_DATA_INV : VarBasis
            {
                /*"      10          WS-ANO-INV          PIC 9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-INV          PIC 9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-DIA-INV          PIC 9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WHORA-CURR          PIC X(008) VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05            WS-NUM-CEP-AUX      PIC 9(008).*/
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05            WS-NUM-CEP-AUX-R    REDEFINES                  WS-NUM-CEP-AUX.*/
            private _REDEF_VA5437B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VA5437B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VA5437B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10          WS-CEP-AUX          PIC 9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          WS-CEP-COMPL-AUX    PIC 9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            WS-NUM-CEP-AUX-R1   REDEFINES                  WS-NUM-CEP-AUX.*/

                public _REDEF_VA5437B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA5437B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VA5437B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VA5437B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10          WS-CEP-COMPL-AUX1   PIC 9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          WS-CEP-AUX1         PIC 9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05        WS-JDE-GER.*/

                public _REDEF_VA5437B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public VA5437B_WS_JDE_GER WS_JDE_GER { get; set; } = new VA5437B_WS_JDE_GER();
            public class VA5437B_WS_JDE_GER : VarBasis
            {
                /*"        15        WS-JDE               PIC X(008).*/
                public StringBasis WS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05        WS-CHAVE            PIC  X(023).*/
            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VA5437B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VA5437B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VA5437B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VA5437B_WS_CHAVE_R : VarBasis
            {
                /*"      10      WS-NUM-APOLICE      PIC  9(013).*/
                public IntBasis WS_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-CODSUBES         PIC  9(005).*/
                public IntBasis WS_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CODOPER          PIC  9(003).*/
                public IntBasis WS_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      WS-IDFORM           PIC  X(002).*/
                public StringBasis WS_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05            AC-LIDOS            PIC 9(006) VALUE ZEROES.*/

                public _REDEF_VA5437B_WS_CHAVE_R()
                {
                    WS_NUM_APOLICE.ValueChanged += OnValueChanged;
                    WS_CODSUBES.ValueChanged += OnValueChanged;
                    WS_CODOPER.ValueChanged += OnValueChanged;
                    WS_IDFORM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-LIDOS-SORT       PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_LIDOS_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAV-SORT        PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_GRAV_SORT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-CONTA            PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-IMPRESSOS        PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-I-RELATORI       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_I_RELATORI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-L-RELATORI       PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_L_RELATORI { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CANCEL     PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_CANCEL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CODRELAT   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_CODRELAT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-MOEDACOT   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_MOEDACOT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-APOLICOB   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_APOLICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-SEGVGAPH   PIC 9(006) VALUE ZEROES.*/
            public IntBasis AC_DESPR_SEGVGAPH { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-SEGURAVG   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_SEGURAVG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-OPCAOPAG   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_OPCAOPAG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CLIENTE    PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_CLIENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-ENDERECO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-COBERPRO   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_COBERPRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-TITULO     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_TITULO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-PLANOVID   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_PLANOVID { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VA33       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VA33 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VA44       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VA44 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VA54       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VA54 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VA83       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VA83 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VD08       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VD08 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VD09       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VD09 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VIDA07     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VIDA07 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VIDA05     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VIDA05 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VIDA10     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VIDA10 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VIDA17     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VIDA17 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-GRAVA-VIDA18     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VIDA18 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-NOT-VA54   PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_NOT_VA54 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-CERTIF     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_CERTIF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-DUPLIC     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_DUPLIC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            WFIM-SISTEMAS       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-COBER          PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-BENEFICIA      PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_BENEFICIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-FAIXACEP       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_FAIXACEP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-RELATORI       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_RELATORI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-AGENCCEF       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_AGENCCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-COBMENVG       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_COBMENVG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-SORT           PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-TABELA         PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-TITFEDCA       PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_TITFEDCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WFIM-FCPLANO        PIC X(001) VALUE SPACES.*/
            public StringBasis WFIM_FCPLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-COBER-ESPOSA   PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_COBER_ESPOSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-ENDERECO       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-USUARIOS       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_USUARIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-CLIENTES       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-OPCPAGVI       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_OPCPAGVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-HISCOBPR       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_HISCOBPR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-SEGURVGA       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-MULTIMSG       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_MULTIMSG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-PLANOVID       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_PLANOVID { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-CONDITEC       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_CONDITEC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WTEM-PRODUVGE       PIC X(001) VALUE SPACES.*/
            public StringBasis WTEM_PRODUVGE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            WPRIM-LINHA         PIC X(001) VALUE SPACES.*/
            public StringBasis WPRIM_LINHA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05            LK-PROSOMU1.*/
            public VA5437B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VA5437B_LK_PROSOMU1();
            public class VA5437B_LK_PROSOMU1 : VarBasis
            {
                /*"      10          LK-DATA-SOM         PIC 9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          LK-DATA-SOM-R       REDEFINES                  LK-DATA-SOM.*/
                private _REDEF_VA5437B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VA5437B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VA5437B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VA5437B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15        LK-DIA-SOM          PIC 9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-MES-SOM          PIC 9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-ANO-SOM          PIC 9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10          LK-QTDIAS           PIC S9(005) COMP-3                                                  VALUE +1.*/

                    public _REDEF_VA5437B_LK_DATA_SOM_R()
                    {
                        LK_DIA_SOM.ValueChanged += OnValueChanged;
                        LK_MES_SOM.ValueChanged += OnValueChanged;
                        LK_ANO_SOM.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LK_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"      10          LK-DATA-CALC        PIC 9(008).*/
                public IntBasis LK_DATA_CALC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          LK-DATA-CALC-R      REDEFINES                  LK-DATA-CALC.*/
                private _REDEF_VA5437B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VA5437B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VA5437B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VA5437B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15        LK-DIA-CALC         PIC 9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-MES-CALC         PIC 9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-ANO-CALC         PIC 9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01  PARAMETROS-711.*/

                    public _REDEF_VA5437B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public VA5437B_PARAMETROS_711 PARAMETROS_711 { get; set; } = new VA5437B_PARAMETROS_711();
        public class VA5437B_PARAMETROS_711 : VarBasis
        {
            /*"    05 LK711-NUM-APOLICE                PIC S9(013)V COMP-3.*/
            public DoubleBasis LK711_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V"), 0);
            /*"    05 LK711-SUBGRUPO                   PIC S9(004)  COMP.*/
            public IntBasis LK711_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK711-CERTIFICADO                PIC S9(015)V COMP-3.*/
            public DoubleBasis LK711_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V"), 0);
            /*"    05 LK711-IDADE                      PIC S9(004)  COMP.*/
            public IntBasis LK711_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK711-NASCIMENTO.*/
            public VA5437B_LK711_NASCIMENTO LK711_NASCIMENTO { get; set; } = new VA5437B_LK711_NASCIMENTO();
            public class VA5437B_LK711_NASCIMENTO : VarBasis
            {
                /*"       10 LK711-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK711_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK711-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK711_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-VLR-PREMIO                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-DT-QUITACAO                PIC  X(010).*/
            public StringBasis LK711_DT_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05 LK711-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-IMP-CONJUGE           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_IMP_CONJUGE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-IMP-FILHO             PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_IMP_FILHO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-COBT-IMP-CDG               PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_COBT_IMP_CDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-IOF-PREMIO                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK711_IOF_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK711-QTD-OCORR                  PIC  9(002).*/
            public IntBasis LK711_QTD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 LK711-TAB-COB-PREMIO OCCURS 13 TIMES.*/
            public ListBasis<VA5437B_LK711_TAB_COB_PREMIO> LK711_TAB_COB_PREMIO { get; set; } = new ListBasis<VA5437B_LK711_TAB_COB_PREMIO>(13);
            public class VA5437B_LK711_TAB_COB_PREMIO : VarBasis
            {
                /*"       10 LK711-NOM-GRUPO-COBERTURA     PIC  X(050).*/
                public StringBasis LK711_NOM_GRUPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
                /*"       10 LK711-NUM-GARANTIA            PIC  9(003).*/
                public IntBasis LK711_NUM_GARANTIA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK711-NUM-GARANTIA-491        PIC  9(003).*/
                public IntBasis LK711_NUM_GARANTIA_491 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK711-DES-GARANTIA            PIC  X(070).*/
                public StringBasis LK711_DES_GARANTIA { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"       10 LK711-NUM-FAIXA-INICIAL       PIC  9(003).*/
                public IntBasis LK711_NUM_FAIXA_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK711-NUM-FAIXA-FINAL         PIC  9(003).*/
                public IntBasis LK711_NUM_FAIXA_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10 LK711-VLR-FAIXA-CS-INICIAL    PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK711_VLR_FAIXA_CS_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK711-VLR-FAIXA-CS-FINAL      PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK711_VLR_FAIXA_CS_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK711-PCT-COB-PREMIO          PIC S9(003)V99999 COMP-3*/
                public DoubleBasis LK711_PCT_COB_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99999"), 5);
                /*"       10 LK711-VLR-CAP-SEGURADO        PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK711_VLR_CAP_SEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK711-VLR-CAP-DESC            PIC  X(013).*/
                public StringBasis LK711_VLR_CAP_DESC { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"       10 LK711-VLR-PCT-PREMIO          PIC S9(013)V99 COMP-3.*/
                public DoubleBasis LK711_VLR_PCT_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"       10 LK711-NUM-COB-CARENCIA        PIC  9(002).*/
                public IntBasis LK711_NUM_COB_CARENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10 LK711-DES-COB-CARENCIA        PIC  X(200).*/
                public StringBasis LK711_DES_COB_CARENCIA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
                /*"       10 LK711-DES-MSG-HINT            PIC  X(800).*/
                public StringBasis LK711_DES_MSG_HINT { get; set; } = new StringBasis(new PIC("X", "800", "X(800)."), @"");
                /*"    05 LK711-RETURN-CODE                PIC S9(03) COMP-3.*/
            }
            public IntBasis LK711_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK711-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK711_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01                TAB-FILIAL.*/
        }
        public VA5437B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA5437B_TAB_FILIAL();
        public class VA5437B_TAB_FILIAL : VarBasis
        {
            /*"    05            FILLER              OCCURS  99  TIMES.*/
            public ListBasis<VA5437B_FILLER_127> FILLER_127 { get; set; } = new ListBasis<VA5437B_FILLER_127>(99);
            public class VA5437B_FILLER_127 : VarBasis
            {
                /*"      10          TAB-FONTE           PIC 9(004).*/
                public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          TAB-NOMEFTE         PIC X(040).*/
                public StringBasis TAB_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10          TAB-ENDERFTE        PIC X(040).*/
                public StringBasis TAB_ENDERFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10          TAB-BAIRRO          PIC X(020).*/
                public StringBasis TAB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10          TAB-CIDADE          PIC X(020).*/
                public StringBasis TAB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10          TAB-CEP             PIC 9(008).*/
                public IntBasis TAB_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          TAB-UF              PIC X(002).*/
                public StringBasis TAB_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"01                TABELA-CEP.*/
            }
        }
        public VA5437B_TABELA_CEP TABELA_CEP { get; set; } = new VA5437B_TABELA_CEP();
        public class VA5437B_TABELA_CEP : VarBasis
        {
            /*"    05            CEP                 OCCURS  2000 TIMES.*/
            public ListBasis<VA5437B_CEP> CEP { get; set; } = new ListBasis<VA5437B_CEP>(2000);
            public class VA5437B_CEP : VarBasis
            {
                /*"      10          TAB-FX-CEP-G        PIC 9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          TAB-FAIXAS.*/
                public VA5437B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VA5437B_TAB_FAIXAS();
                public class VA5437B_TAB_FAIXAS : VarBasis
                {
                    /*"        15        TAB-FX-INI          PIC 9(008).*/
                    public IntBasis TAB_FX_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15        TAB-FX-FIM          PIC 9(008).*/
                    public IntBasis TAB_FX_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"        15        TAB-FX-NOME         PIC X(072).*/
                    public StringBasis TAB_FX_NOME { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"        15        TAB-FX-CENTR        PIC X(072).*/
                    public StringBasis TAB_FX_CENTR { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                    /*"01            TABELA-MSG.*/
                }
            }
        }
        public VA5437B_TABELA_MSG TABELA_MSG { get; set; } = new VA5437B_TABELA_MSG();
        public class VA5437B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 3000  TIMES.*/
            public ListBasis<VA5437B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VA5437B_TAB_MSG>(3000);
            public class VA5437B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(023).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VA5437B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VA5437B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VA5437B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VA5437B_TABJ_CHAVE_R : VarBasis
                {
                    /*"        15    TABJ-APOLICE        PIC  9(013).*/
                    public IntBasis TABJ_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"        15    TABJ-CODSUBES       PIC  9(005).*/
                    public IntBasis TABJ_CODSUBES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"        15    TABJ-CODOPER        PIC  9(003).*/
                    public IntBasis TABJ_CODOPER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"        15    TABJ-IDFORM         PIC  X(002).*/
                    public StringBasis TABJ_IDFORM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      10      TABJ-JDE            PIC  X(008).*/

                    public _REDEF_VA5437B_TABJ_CHAVE_R()
                    {
                        TABJ_APOLICE.ValueChanged += OnValueChanged;
                        TABJ_CODSUBES.ValueChanged += OnValueChanged;
                        TABJ_CODOPER.ValueChanged += OnValueChanged;
                        TABJ_IDFORM.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis TABJ_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      10      TABJ-JDL            PIC  X(008).*/
                public StringBasis TABJ_JDL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"01            TAB-QTD-DIG-COMBINACAO.*/
            }
        }
        public VA5437B_TAB_QTD_DIG_COMBINACAO TAB_QTD_DIG_COMBINACAO { get; set; } = new VA5437B_TAB_QTD_DIG_COMBINACAO();
        public class VA5437B_TAB_QTD_DIG_COMBINACAO : VarBasis
        {
            /*"    05        TAB-COMB            OCCURS  1000 TIMES.*/
            public ListBasis<VA5437B_TAB_COMB> TAB_COMB { get; set; } = new ListBasis<VA5437B_TAB_COMB>(1000);
            public class VA5437B_TAB_COMB : VarBasis
            {
                /*"      10      TAB-QTD-DIG         PIC  9(001).*/
                public IntBasis TAB_QTD_DIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01                TB99.*/
            }
        }
        public VA5437B_TB99 TB99 { get; set; } = new VA5437B_TB99();
        public class VA5437B_TB99 : VarBasis
        {
            /*"    03            TB99-CONT           OCCURS  100  TIMES.*/
            public ListBasis<VA5437B_TB99_CONT> TB99_CONT { get; set; } = new ListBasis<VA5437B_TB99_CONT>(100);
            public class VA5437B_TB99_CONT : VarBasis
            {
                /*"       05         TB99-NOME-BENEF     PIC X(040).*/
                public StringBasis TB99_NOME_BENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       05         TB99-PARENTESCO     PIC X(010).*/
                public StringBasis TB99_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       05         TB99-PARTICIP       PIC 9(003)V99.*/
                public DoubleBasis TB99_PARTICIP { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"       05         TB99-DTINIVIG       PIC X(010).*/
                public StringBasis TB99_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       05         TB99-DTTERVIG       PIC X(010).*/
                public StringBasis TB99_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"01                TABELA-NOMES.*/
            }
        }
        public VA5437B_TABELA_NOMES TABELA_NOMES { get; set; } = new VA5437B_TABELA_NOMES();
        public class VA5437B_TABELA_NOMES : VarBasis
        {
            /*"    05            TAB-NOMES.*/
            public VA5437B_TAB_NOMES TAB_NOMES { get; set; } = new VA5437B_TAB_NOMES();
            public class VA5437B_TAB_NOMES : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES-R         REDEFINES  TAB-NOMES.*/
            }
            private _REDEF_VA5437B_TAB_NOMES_R _tab_nomes_r { get; set; }
            public _REDEF_VA5437B_TAB_NOMES_R TAB_NOMES_R
            {
                get { _tab_nomes_r = new _REDEF_VA5437B_TAB_NOMES_R(); _.Move(TAB_NOMES, _tab_nomes_r); VarBasis.RedefinePassValue(TAB_NOMES, _tab_nomes_r, TAB_NOMES); _tab_nomes_r.ValueChanged += () => { _.Move(_tab_nomes_r, TAB_NOMES); }; return _tab_nomes_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_r, TAB_NOMES); }
            }  //Redefines
            public class _REDEF_VA5437B_TAB_NOMES_R : VarBasis
            {
                /*"      10          TAB-NOME            OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES1.*/

                public _REDEF_VA5437B_TAB_NOMES_R()
                {
                    TAB_NOME.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA5437B_TABELA_NOMES1 TABELA_NOMES1 { get; set; } = new VA5437B_TABELA_NOMES1();
        public class VA5437B_TABELA_NOMES1 : VarBasis
        {
            /*"    05            TAB-NOMES1.*/
            public VA5437B_TAB_NOMES1 TAB_NOMES1 { get; set; } = new VA5437B_TAB_NOMES1();
            public class VA5437B_TAB_NOMES1 : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES1-R        REDEFINES  TAB-NOMES1.*/
            }
            private _REDEF_VA5437B_TAB_NOMES1_R _tab_nomes1_r { get; set; }
            public _REDEF_VA5437B_TAB_NOMES1_R TAB_NOMES1_R
            {
                get { _tab_nomes1_r = new _REDEF_VA5437B_TAB_NOMES1_R(); _.Move(TAB_NOMES1, _tab_nomes1_r); VarBasis.RedefinePassValue(TAB_NOMES1, _tab_nomes1_r, TAB_NOMES1); _tab_nomes1_r.ValueChanged += () => { _.Move(_tab_nomes1_r, TAB_NOMES1); }; return _tab_nomes1_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_r, TAB_NOMES1); }
            }  //Redefines
            public class _REDEF_VA5437B_TAB_NOMES1_R : VarBasis
            {
                /*"      10          TAB-NOME1           OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES-SOC.*/

                public _REDEF_VA5437B_TAB_NOMES1_R()
                {
                    TAB_NOME1.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA5437B_TABELA_NOMES_SOC TABELA_NOMES_SOC { get; set; } = new VA5437B_TABELA_NOMES_SOC();
        public class VA5437B_TABELA_NOMES_SOC : VarBasis
        {
            /*"    05            TAB-NOMES-SOC.*/
            public VA5437B_TAB_NOMES_SOC TAB_NOMES_SOC { get; set; } = new VA5437B_TAB_NOMES_SOC();
            public class VA5437B_TAB_NOMES_SOC : VarBasis
            {
                /*"      10          FILLER              PIC X(100).*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    05            TAB-NOMES-SOC-R     REDEFINES  TAB-NOMES-SOC.*/
            }
            private _REDEF_VA5437B_TAB_NOMES_SOC_R _tab_nomes_soc_r { get; set; }
            public _REDEF_VA5437B_TAB_NOMES_SOC_R TAB_NOMES_SOC_R
            {
                get { _tab_nomes_soc_r = new _REDEF_VA5437B_TAB_NOMES_SOC_R(); _.Move(TAB_NOMES_SOC, _tab_nomes_soc_r); VarBasis.RedefinePassValue(TAB_NOMES_SOC, _tab_nomes_soc_r, TAB_NOMES_SOC); _tab_nomes_soc_r.ValueChanged += () => { _.Move(_tab_nomes_soc_r, TAB_NOMES_SOC); }; return _tab_nomes_soc_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_soc_r, TAB_NOMES_SOC); }
            }  //Redefines
            public class _REDEF_VA5437B_TAB_NOMES_SOC_R : VarBasis
            {
                /*"      10          TAB-NOME-SOC        OCCURS 100  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME_SOC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 100);
                /*"01                TABELA-NOMES1-SOC.*/

                public _REDEF_VA5437B_TAB_NOMES_SOC_R()
                {
                    TAB_NOME_SOC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA5437B_TABELA_NOMES1_SOC TABELA_NOMES1_SOC { get; set; } = new VA5437B_TABELA_NOMES1_SOC();
        public class VA5437B_TABELA_NOMES1_SOC : VarBasis
        {
            /*"    05            TAB-NOMES1-SOC.*/
            public VA5437B_TAB_NOMES1_SOC TAB_NOMES1_SOC { get; set; } = new VA5437B_TAB_NOMES1_SOC();
            public class VA5437B_TAB_NOMES1_SOC : VarBasis
            {
                /*"      10          FILLER              PIC X(100).*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    05            TAB-NOMES1-SOC-R    REDEFINES  TAB-NOMES1-SOC.*/
            }
            private _REDEF_VA5437B_TAB_NOMES1_SOC_R _tab_nomes1_soc_r { get; set; }
            public _REDEF_VA5437B_TAB_NOMES1_SOC_R TAB_NOMES1_SOC_R
            {
                get { _tab_nomes1_soc_r = new _REDEF_VA5437B_TAB_NOMES1_SOC_R(); _.Move(TAB_NOMES1_SOC, _tab_nomes1_soc_r); VarBasis.RedefinePassValue(TAB_NOMES1_SOC, _tab_nomes1_soc_r, TAB_NOMES1_SOC); _tab_nomes1_soc_r.ValueChanged += () => { _.Move(_tab_nomes1_soc_r, TAB_NOMES1_SOC); }; return _tab_nomes1_soc_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_soc_r, TAB_NOMES1_SOC); }
            }  //Redefines
            public class _REDEF_VA5437B_TAB_NOMES1_SOC_R : VarBasis
            {
                /*"      10          TAB-NOME1-SOC       OCCURS 100  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1_SOC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 100);
                /*"01                TABELA-COBER.*/

                public _REDEF_VA5437B_TAB_NOMES1_SOC_R()
                {
                    TAB_NOME1_SOC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA5437B_TABELA_COBER TABELA_COBER { get; set; } = new VA5437B_TABELA_COBER();
        public class VA5437B_TABELA_COBER : VarBasis
        {
            /*"    05            TAB-COBER.*/
            public VA5437B_TAB_COBER TAB_COBER { get; set; } = new VA5437B_TAB_COBER();
            public class VA5437B_TAB_COBER : VarBasis
            {
                /*"      10          FILLER              PIC X(045)  VALUE                 'COBERTURA DOENA GRAVE..................: R$ '*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"COBERTURA DOENA GRAVE..................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'SERVIO ASSISTNCIA FUNERAL.............: R$ '*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SERVIO ASSISTNCIA FUNERAL.............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ADIANTAMENTO AUXLIO FUNERAL(AT).......: R$ '*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ADIANTAMENTO AUXLIO FUNERAL(AT).......: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'CESTA BSICA............................: R$ '*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"CESTA BSICA............................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'AUXLIO ALIMENTAO.....................: R$ '*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"AUXLIO ALIMENTAO.....................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DOENAS CONGNITAS GRAVES...............: R$ '*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DOENAS CONGNITAS GRAVES...............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'INDENIZAO RESCISO TRABALHISTA........: R$ '*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"INDENIZAO RESCISO TRABALHISTA........: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DESEMPREGO INVOLUNTRIO.................: R$ '*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DESEMPREGO INVOLUNTRIO.................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'PERDA DE RENDA (AUTNOMO)...............: R$ '*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"PERDA DE RENDA (AUTNOMO)...............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'REMISSO PRMIO DESEMPREGO INVOLUNTRIO '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"REMISSO PRMIO DESEMPREGO INVOLUNTRIO ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DIAGNSTICO DE CNCER...................: R$ '*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DIAGNSTICO DE CNCER...................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'SERVIO ASSISTNCIA VIAGEM..............: R$ '*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SERVIO ASSISTNCIA VIAGEM..............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'EXTRAVIO DE BAGAGEM.....................: R$ '*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"EXTRAVIO DE BAGAGEM.....................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'REMISSO PRMIO DIAGNSTICO CNCER      '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"REMISSO PRMIO DIAGNSTICO CNCER      ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'REMISSO PRMIO INDENIZAO CDG         '.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"REMISSO PRMIO INDENIZAO CDG         ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ASSISTNCIA FARMCIA                    '.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ASSISTNCIA FARMCIA                    ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ASSISTNCIA RESIDENCIAL                 '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ASSISTNCIA RESIDENCIAL                 ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ASSISTNCIA VIAGEM                      '.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ASSISTNCIA VIAGEM                      ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ORIENTAO NUTRICIONAL                  '.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ORIENTAO NUTRICIONAL                  ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'PAGAMENTO ANTECIPADO ESPECIAL POR DOENA'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"PAGAMENTO ANTECIPADO ESPECIAL POR DOENA");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DESP MDICO HOSPITALAR ODONTOLGICA AT:'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DESP MDICO HOSPITALAR ODONTOLGICA AT:");
                /*"    05            TAB-COBER-R         REDEFINES                  TAB-COBER.*/
            }
            private _REDEF_VA5437B_TAB_COBER_R _tab_cober_r { get; set; }
            public _REDEF_VA5437B_TAB_COBER_R TAB_COBER_R
            {
                get { _tab_cober_r = new _REDEF_VA5437B_TAB_COBER_R(); _.Move(TAB_COBER, _tab_cober_r); VarBasis.RedefinePassValue(TAB_COBER, _tab_cober_r, TAB_COBER); _tab_cober_r.ValueChanged += () => { _.Move(_tab_cober_r, TAB_COBER); }; return _tab_cober_r; }
                set { VarBasis.RedefinePassValue(value, _tab_cober_r, TAB_COBER); }
            }  //Redefines
            public class _REDEF_VA5437B_TAB_COBER_R : VarBasis
            {
                /*"      10          TAB-COBER-DESCR     OCCURS  21  TIMES                                      PIC X(045).*/
                public ListBasis<StringBasis, string> TAB_COBER_DESCR { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "45", "X(045)."), 21);
                /*"01                TABELA-MESES.*/

                public _REDEF_VA5437B_TAB_COBER_R()
                {
                    TAB_COBER_DESCR.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA5437B_TABELA_MESES TABELA_MESES { get; set; } = new VA5437B_TABELA_MESES();
        public class VA5437B_TABELA_MESES : VarBasis
        {
            /*"    05            TAB-MESES.*/
            public VA5437B_TAB_MESES TAB_MESES { get; set; } = new VA5437B_TAB_MESES();
            public class VA5437B_TAB_MESES : VarBasis
            {
                /*"      10          FILLER           PIC X(009) VALUE '  Janeiro'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  Janeiro");
                /*"      10          FILLER           PIC X(009) VALUE 'Fevereiro'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"Fevereiro");
                /*"      10          FILLER           PIC X(009) VALUE '    Maro'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Maro");
                /*"      10          FILLER           PIC X(009) VALUE '    Abril'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Abril");
                /*"      10          FILLER           PIC X(009) VALUE '     Maio'.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     Maio");
                /*"      10          FILLER           PIC X(009) VALUE '    Junho'.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Junho");
                /*"      10          FILLER           PIC X(009) VALUE '    Julho'.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Julho");
                /*"      10          FILLER           PIC X(009) VALUE '   Agosto'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   Agosto");
                /*"      10          FILLER           PIC X(009) VALUE ' Setembro'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Setembro");
                /*"      10          FILLER           PIC X(009) VALUE '  Outubro'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  Outubro");
                /*"      10          FILLER           PIC X(009) VALUE ' Novembro'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Novembro");
                /*"      10          FILLER           PIC X(009) VALUE ' Dezembro'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Dezembro");
                /*"    05            TAB-MESES-R         REDEFINES                  TAB-MESES.*/
            }
            private _REDEF_VA5437B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VA5437B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VA5437B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VA5437B_TAB_MESES_R : VarBasis
            {
                /*"      10          TAB-MES             OCCURS  12  TIMES                                      PIC X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01                WABEND.*/

                public _REDEF_VA5437B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA5437B_WABEND WABEND { get; set; } = new VA5437B_WABEND();
        public class VA5437B_WABEND : VarBasis
        {
            /*"      05          FILLER              PIC X(010) VALUE                 ' VA5437B'.*/
            public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA5437B");
            /*"      05          FILLER              PIC X(026) VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05          FILLER              PIC X(013) VALUE                 ' *** SQLCODE '.*/
            public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.FCPROSUS FCPROSUS { get; set; } = new Dclgens.FCPROSUS();
        public Dclgens.GEFAICEP GEFAICEP { get; set; } = new Dclgens.GEFAICEP();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.BENEFICI BENEFICI { get; set; } = new Dclgens.BENEFICI();
        public Dclgens.COBMENVG COBMENVG { get; set; } = new Dclgens.COBMENVG();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.MOEDACOT MOEDACOT { get; set; } = new Dclgens.MOEDACOT();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.PLANOVID PLANOVID { get; set; } = new Dclgens.PLANOVID();
        public Dclgens.CONDITEC CONDITEC { get; set; } = new Dclgens.CONDITEC();
        public Dclgens.TITFEDCA TITFEDCA { get; set; } = new Dclgens.TITFEDCA();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.FCPLANO FCPLANO { get; set; } = new Dclgens.FCPLANO();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA5437B_CFAIXACEP CFAIXACEP { get; set; } = new VA5437B_CFAIXACEP();
        public VA5437B_CMSG CMSG { get; set; } = new VA5437B_CMSG();
        public VA5437B_CFCPLANO CFCPLANO { get; set; } = new VA5437B_CFCPLANO();
        public VA5437B_V1AGENCEF V1AGENCEF { get; set; } = new VA5437B_V1AGENCEF();
        public VA5437B_CRELAT CRELAT { get; set; } = new VA5437B_CRELAT();
        public VA5437B_CTITFEDCA CTITFEDCA { get; set; } = new VA5437B_CTITFEDCA();
        public VA5437B_V0BENEF V0BENEF { get; set; } = new VA5437B_V0BENEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVA5437B_FILE_NAME_P, string SVA5437B_FILE_NAME_P, string FVA5437B_FILE_NAME_P, string IMP5437B_FILE_NAME_P, string PDF5437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVA5437B.SetFile(RVA5437B_FILE_NAME_P);
                SVA5437B.SetFile(SVA5437B_FILE_NAME_P);
                FVA5437B.SetFile(FVA5437B_FILE_NAME_P);
                IMP5437B.SetFile(IMP5437B_FILE_NAME_P);
                PDF5437B.SetFile(PDF5437B_FILE_NAME_P);
                VDHTML01.SetFile(VDHTML01_FILE_NAME_P);
                VDHTML09.SetFile(VDHTML09_FILE_NAME_P);

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
            /*" -1498- DISPLAY ' ' */
            _.Display($" ");

            /*" -1500- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1510- DISPLAY 'PROGRAMA VA5437B - VERSAO V.40 ' '- AJUSTE 582106 - 09/09/2024.' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA5437B - VERSAO V.40 - AJUSTE 582106 - 09/09/2024.FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1511- DISPLAY 'EMITE CERTIFICADOS DAS APOLICES PESSOA' */
            _.Display($"EMITE CERTIFICADOS DAS APOLICES PESSOA");

            /*" -1512- DISPLAY '    FISICA NO PADRAO FAC - FORMULARIO VA54      ' */
            _.Display($"    FISICA NO PADRAO FAC - FORMULARIO VA54      ");

            /*" -1514- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1515- DISPLAY ' ' */
            _.Display($" ");

            /*" -1521- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1522- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -1523- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1537- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1539- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1540- IF WFIM-SISTEMAS NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMAS.IsEmpty())
            {

                /*" -1541- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -1543- END-IF */
            }


            /*" -1546- INITIALIZE TAB-FILIAL TAB-QTD-DIG-COMBINACAO */
            _.Initialize(
                TAB_FILIAL
                , TAB_QTD_DIG_COMBINACAO
            );

            /*" -1548- PERFORM R0500-00-DECLARE-AGENCCEF */

            R0500_00_DECLARE_AGENCCEF_SECTION();

            /*" -1550- PERFORM R0510-00-FETCH-AGENCCEF */

            R0510_00_FETCH_AGENCCEF_SECTION();

            /*" -1551- IF WFIM-AGENCCEF NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_AGENCCEF.IsEmpty())
            {

                /*" -1552- DISPLAY 'R0000 - PROBLEMA NO FETCH DA AGENCCEF ' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA AGENCCEF ");

                /*" -1553- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1555- END-IF */
            }


            /*" -1557- PERFORM R0520-00-CARREGA-FILIAL UNTIL WFIM-AGENCCEF = 'S' */

            while (!(AREA_DE_WORK.WFIM_AGENCCEF == "S"))
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1559- PERFORM R0900-00-DECLARE-RELATORI */

            R0900_00_DECLARE_RELATORI_SECTION();

            /*" -1561- PERFORM R0910-00-FETCH-RELATORI */

            R0910_00_FETCH_RELATORI_SECTION();

            /*" -1562- IF WFIM-RELATORI = 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -1563- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1564- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1565- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1567- END-IF */
            }


            /*" -1569- PERFORM R0200-00-CARREGA-FAIXACEP */

            R0200_00_CARREGA_FAIXACEP_SECTION();

            /*" -1571- PERFORM R0300-00-CARREGA-COBMENVG */

            R0300_00_CARREGA_COBMENVG_SECTION();

            /*" -1573- PERFORM R0400-00-CARREGA-FCPLANO */

            R0400_00_CARREGA_FCPLANO_SECTION();

            /*" -1575- MOVE +200000 TO SORT-FILE-SIZE. */
            _.Move(+200000, SORT_FILE_SIZE);

            /*" -1585- SORT SVA5437B ON ASCENDING KEY SVA-JDE SVA-TP-ARQSAIDA SVA-CODRELAT SVA-NRAPOLICE SVA-CODSUBES SVA-CEP-G SVA-NUM-CEP INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SVA5437B.Sort("SVA-JDE,SVA-TP-ARQSAIDA,SVA-CODRELAT,SVA-NRAPOLICE,SVA-CODSUBES,SVA-CEP-G,SVA-NUM-CEP", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1588- IF SORT-RETURN NOT = ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1589- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1593- DISPLAY '--> VA5437B ERRO NA ROTINA DE SORT AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"--> VA5437B ERRO NA ROTINA DE SORT AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -1594- DISPLAY '--> VA5437B SORT-RETURN < ' SORT-RETURN '>' */

                $"--> VA5437B SORT-RETURN < {SORT_RETURN}>"
                .Display();

                /*" -1595- DISPLAY ' ' */
                _.Display($" ");

                /*" -1596- DISPLAY 'LIDOS CRELAT..... : ' AC-L-RELATORI */
                _.Display($"LIDOS CRELAT..... : {AREA_DE_WORK.AC_L_RELATORI}");

                /*" -1598- DISPLAY ' ' */
                _.Display($" ");

                /*" -1600- DISPLAY 'DESP FORM NAO VA54/VIDA10 : ' AC-DESPR-NOT-VA54 */
                _.Display($"DESP FORM NAO VA54/VIDA10 : {AREA_DE_WORK.AC_DESPR_NOT_VA54}");

                /*" -1601- DISPLAY 'DESP V0COBERPRO   : ' AC-DESPR-COBERPRO */
                _.Display($"DESP V0COBERPRO   : {AREA_DE_WORK.AC_DESPR_COBERPRO}");

                /*" -1602- DISPLAY 'DESP TITULO S/VIG : ' AC-DESPR-TITULO */
                _.Display($"DESP TITULO S/VIG : {AREA_DE_WORK.AC_DESPR_TITULO}");

                /*" -1603- DISPLAY 'DESP CERTIF...... : ' AC-DESPR-CERTIF */
                _.Display($"DESP CERTIF...... : {AREA_DE_WORK.AC_DESPR_CERTIF}");

                /*" -1604- DISPLAY 'DESP DUPLIC...... : ' AC-DESPR-DUPLIC */
                _.Display($"DESP DUPLIC...... : {AREA_DE_WORK.AC_DESPR_DUPLIC}");

                /*" -1605- DISPLAY 'DESP V0SEGURAVG   : ' AC-DESPR-SEGURAVG */
                _.Display($"DESP V0SEGURAVG   : {AREA_DE_WORK.AC_DESPR_SEGURAVG}");

                /*" -1606- DISPLAY 'DESP V0OPCAOPAGVA : ' AC-DESPR-OPCAOPAG */
                _.Display($"DESP V0OPCAOPAGVA : {AREA_DE_WORK.AC_DESPR_OPCAOPAG}");

                /*" -1607- DISPLAY 'DESP V0CLIENTE    : ' AC-DESPR-CLIENTE */
                _.Display($"DESP V0CLIENTE    : {AREA_DE_WORK.AC_DESPR_CLIENTE}");

                /*" -1608- DISPLAY 'DESP V0ENDERECO   : ' AC-DESPR-ENDERECO */
                _.Display($"DESP V0ENDERECO   : {AREA_DE_WORK.AC_DESPR_ENDERECO}");

                /*" -1609- DISPLAY ' ' */
                _.Display($" ");

                /*" -1610- DISPLAY '--> GRAVADO SORT..: ' AC-GRAV-SORT */
                _.Display($"--> GRAVADO SORT..: {AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -1611- DISPLAY '--> APOLICE   ....: ' WHOST-NRAPOLICE */
                _.Display($"--> APOLICE   ....: {WHOST_NRAPOLICE}");

                /*" -1612- DISPLAY '--> SUBGRUPO  ....: ' WHOST-CODSUBES */
                _.Display($"--> SUBGRUPO  ....: {WHOST_CODSUBES}");

                /*" -1613- DISPLAY '--> IMPRESSOS ....: ' AC-IMPRESSOS */
                _.Display($"--> IMPRESSOS ....: {AREA_DE_WORK.AC_IMPRESSOS}");

                /*" -1615- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1616- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -1617- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1617- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1624- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1626- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1627- MOVE ALL '-' TO FVA5437B-RECORD */
            _.MoveAll("-", FVA5437B_RECORD);

            /*" -1629- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1630- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1631- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1633- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1634- MOVE 'ESTATISTICAS DO PROCESSAMENTO' TO FVA5437B-RECORD */
            _.Move("ESTATISTICAS DO PROCESSAMENTO", FVA5437B_RECORD);

            /*" -1635- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1637- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1638- MOVE '-----------------------------' TO FVA5437B-RECORD */
            _.Move("-----------------------------", FVA5437B_RECORD);

            /*" -1639- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1641- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1646- STRING 'LIDOS V0RELATORIOS       ' AC-L-RELATORI DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl1 = "LIDOS V0RELATORIOS " + AREA_DE_WORK.AC_L_RELATORI.GetMoveValues();
            _.Move(spl1, FVA5437B_RECORD);
            #endregion

            /*" -1647- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1649- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1654- STRING 'CERTIFICADOS IMPRESSOS   ' AC-IMPRESSOS DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl2 = "CERTIFICADOS IMPRESSOS " + AREA_DE_WORK.AC_IMPRESSOS.GetMoveValues();
            _.Move(spl2, FVA5437B_RECORD);
            #endregion

            /*" -1655- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1657- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1662- STRING 'DESPREZADOS CANCELAMEN   ' AC-DESPR-CANCEL DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl3 = "DESPREZADOS CANCELAMEN " + AREA_DE_WORK.AC_DESPR_CANCEL.GetMoveValues();
            _.Move(spl3, FVA5437B_RECORD);
            #endregion

            /*" -1663- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1665- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1670- STRING 'DESPREZADOS V0SEGURAVG   ' AC-DESPR-SEGURAVG DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl4 = "DESPREZADOS V0SEGURAVG " + AREA_DE_WORK.AC_DESPR_SEGURAVG.GetMoveValues();
            _.Move(spl4, FVA5437B_RECORD);
            #endregion

            /*" -1671- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1673- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1678- STRING 'DESPREZADOS V0OPCAOPAGVA ' AC-DESPR-OPCAOPAG DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl5 = "DESPREZADOS V0OPCAOPAGVA " + AREA_DE_WORK.AC_DESPR_OPCAOPAG.GetMoveValues();
            _.Move(spl5, FVA5437B_RECORD);
            #endregion

            /*" -1679- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1681- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1686- STRING 'DESPREZADOS V0CLIENTE    ' AC-DESPR-CLIENTE DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl6 = "DESPREZADOS V0CLIENTE " + AREA_DE_WORK.AC_DESPR_CLIENTE.GetMoveValues();
            _.Move(spl6, FVA5437B_RECORD);
            #endregion

            /*" -1687- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1689- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1694- STRING 'DESPREZADOS V0ENDERECO   ' AC-DESPR-ENDERECO DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl7 = "DESPREZADOS V0ENDERECO " + AREA_DE_WORK.AC_DESPR_ENDERECO.GetMoveValues();
            _.Move(spl7, FVA5437B_RECORD);
            #endregion

            /*" -1695- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1697- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1702- STRING 'DESPREZADOS V0COBERPRO   ' AC-DESPR-COBERPRO DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl8 = "DESPREZADOS V0COBERPRO " + AREA_DE_WORK.AC_DESPR_COBERPRO.GetMoveValues();
            _.Move(spl8, FVA5437B_RECORD);
            #endregion

            /*" -1707- STRING 'TITULO SEM INICIO E FIM DE VIGNCIA ' AC-DESPR-TITULO DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl9 = "TITULO SEM INICIO E FIM DE VIGNCIA " + AREA_DE_WORK.AC_DESPR_TITULO.GetMoveValues();
            _.Move(spl9, FVA5437B_RECORD);
            #endregion

            /*" -1708- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1709- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1711- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1712- MOVE 'SORT' TO FVA5437B-RECORD */
            _.Move("SORT", FVA5437B_RECORD);

            /*" -1713- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1715- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1716- MOVE '----' TO FVA5437B-RECORD */
            _.Move("----", FVA5437B_RECORD);

            /*" -1717- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1718- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1719- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1721- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1726- STRING 'DESPREZADOS V0COBERAPOL  ' AC-DESPR-APOLICOB DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl10 = "DESPREZADOS V0COBERAPOL " + AREA_DE_WORK.AC_DESPR_APOLICOB.GetMoveValues();
            _.Move(spl10, FVA5437B_RECORD);
            #endregion

            /*" -1727- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1729- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1734- STRING 'DESPREZADOS V0HISTSEGVG  ' AC-DESPR-SEGVGAPH DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl11 = "DESPREZADOS V0HISTSEGVG " + AREA_DE_WORK.AC_DESPR_SEGVGAPH.GetMoveValues();
            _.Move(spl11, FVA5437B_RECORD);
            #endregion

            /*" -1735- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1737- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1742- STRING 'DESPREZADOS V0COTACAO    ' AC-DESPR-MOEDACOT DELIMITED BY SIZE INTO FVA5437B-RECORD END-STRING */
            #region STRING
            var spl12 = "DESPREZADOS V0COTACAO " + AREA_DE_WORK.AC_DESPR_MOEDACOT.GetMoveValues();
            _.Move(spl12, FVA5437B_RECORD);
            #endregion

            /*" -1743- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1745- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -1746- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1747- MOVE '*** VA5437B - TERMINO NORMAL ***' TO FVA5437B-RECORD */
            _.Move("*** VA5437B - TERMINO NORMAL ***", FVA5437B_RECORD);

            /*" -1749- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -1751- PERFORM R9000-00-CLOSE-ARQUIVOS */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -1753- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1754- DISPLAY ' ' */
            _.Display($" ");

            /*" -1755- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1756- DISPLAY 'ESTATISTICAS DE FINAL DE PROCESSAMENTO' */
            _.Display($"ESTATISTICAS DE FINAL DE PROCESSAMENTO");

            /*" -1757- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1758- DISPLAY 'LIDOS V0RELATORIOS         ' AC-L-RELATORI. */
            _.Display($"LIDOS V0RELATORIOS         {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -1759- DISPLAY 'CERTIFICADOS IMPRESSOS     ' AC-IMPRESSOS. */
            _.Display($"CERTIFICADOS IMPRESSOS     {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1760- DISPLAY 'VA33 IMPRESSOS             ' AC-GRAVA-VA33. */
            _.Display($"VA33 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA33}");

            /*" -1761- DISPLAY 'VA44 IMPRESSOS             ' AC-GRAVA-VA44. */
            _.Display($"VA44 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA44}");

            /*" -1762- DISPLAY 'VA54 IMPRESSOS             ' AC-GRAVA-VA54. */
            _.Display($"VA54 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA54}");

            /*" -1763- DISPLAY 'VA83 IMPRESSOS             ' AC-GRAVA-VA83. */
            _.Display($"VA83 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA83}");

            /*" -1764- DISPLAY 'VD08 IMPRESSOS             ' AC-GRAVA-VD08. */
            _.Display($"VD08 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VD08}");

            /*" -1765- DISPLAY 'VD09 IMPRESSOS             ' AC-GRAVA-VD09. */
            _.Display($"VD09 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VD09}");

            /*" -1766- DISPLAY 'VIDA07 IMPRESSOS (VA33)  = ' AC-GRAVA-VIDA07. */
            _.Display($"VIDA07 IMPRESSOS (VA33)  = {AREA_DE_WORK.AC_GRAVA_VIDA07}");

            /*" -1768- DISPLAY 'VIDA05 IMPRESSOS (VA44,VA83) = ' AC-GRAVA-VIDA05. */
            _.Display($"VIDA05 IMPRESSOS (VA44,VA83) = {AREA_DE_WORK.AC_GRAVA_VIDA05}");

            /*" -1769- DISPLAY 'VIDA10 IMPRESSOS (VA54)  = ' AC-GRAVA-VIDA10. */
            _.Display($"VIDA10 IMPRESSOS (VA54)  = {AREA_DE_WORK.AC_GRAVA_VIDA10}");

            /*" -1770- DISPLAY 'VIDA17 IMPRESSOS (VD08)  = ' AC-GRAVA-VIDA17. */
            _.Display($"VIDA17 IMPRESSOS (VD08)  = {AREA_DE_WORK.AC_GRAVA_VIDA17}");

            /*" -1771- DISPLAY 'VIDA18 IMPRESSOS (VD09)  = ' AC-GRAVA-VIDA18. */
            _.Display($"VIDA18 IMPRESSOS (VD09)  = {AREA_DE_WORK.AC_GRAVA_VIDA18}");

            /*" -1772- DISPLAY 'DESPREZADOS CANCELAMEN     ' AC-DESPR-CANCEL. */
            _.Display($"DESPREZADOS CANCELAMEN     {AREA_DE_WORK.AC_DESPR_CANCEL}");

            /*" -1773- DISPLAY 'DESPREZADOS V0SEGURAVG     ' AC-DESPR-SEGURAVG. */
            _.Display($"DESPREZADOS V0SEGURAVG     {AREA_DE_WORK.AC_DESPR_SEGURAVG}");

            /*" -1774- DISPLAY 'DESPREZADOS V0OPCAOPAGVA   ' AC-DESPR-OPCAOPAG. */
            _.Display($"DESPREZADOS V0OPCAOPAGVA   {AREA_DE_WORK.AC_DESPR_OPCAOPAG}");

            /*" -1775- DISPLAY 'DESPREZADOS V0CLIENTE      ' AC-DESPR-CLIENTE. */
            _.Display($"DESPREZADOS V0CLIENTE      {AREA_DE_WORK.AC_DESPR_CLIENTE}");

            /*" -1776- DISPLAY 'DESPREZADOS V0ENDERECO     ' AC-DESPR-ENDERECO. */
            _.Display($"DESPREZADOS V0ENDERECO     {AREA_DE_WORK.AC_DESPR_ENDERECO}");

            /*" -1777- DISPLAY 'DESPREZADOS V0COBERPRO     ' AC-DESPR-COBERPRO. */
            _.Display($"DESPREZADOS V0COBERPRO     {AREA_DE_WORK.AC_DESPR_COBERPRO}");

            /*" -1779- DISPLAY 'DESPREZADOS TITULO S/VIGEN ' AC-DESPR-TITULO. */
            _.Display($"DESPREZADOS TITULO S/VIGEN {AREA_DE_WORK.AC_DESPR_TITULO}");

            /*" -1781- DISPLAY 'DESP FORM NAO VA54/VIDA10 : ' AC-DESPR-NOT-VA54 */
            _.Display($"DESP FORM NAO VA54/VIDA10 : {AREA_DE_WORK.AC_DESPR_NOT_VA54}");

            /*" -1782- DISPLAY 'DESP CERTIF............... ' AC-DESPR-CERTIF */
            _.Display($"DESP CERTIF............... {AREA_DE_WORK.AC_DESPR_CERTIF}");

            /*" -1783- DISPLAY 'DESP DUPLIC............... ' AC-DESPR-DUPLIC */
            _.Display($"DESP DUPLIC............... {AREA_DE_WORK.AC_DESPR_DUPLIC}");

            /*" -1784- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1785- DISPLAY '                  SORT                     ' */
            _.Display($"                  SORT                     ");

            /*" -1786- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1787- DISPLAY 'DESPREZADOS V0COBERAPOL    ' AC-DESPR-APOLICOB. */
            _.Display($"DESPREZADOS V0COBERAPOL    {AREA_DE_WORK.AC_DESPR_APOLICOB}");

            /*" -1788- DISPLAY 'DESPREZADOS V0HISTSEGVG    ' AC-DESPR-SEGVGAPH. */
            _.Display($"DESPREZADOS V0HISTSEGVG    {AREA_DE_WORK.AC_DESPR_SEGVGAPH}");

            /*" -1789- DISPLAY 'DESPREZADOS V0COTACAO      ' AC-DESPR-MOEDACOT. */
            _.Display($"DESPREZADOS V0COTACAO      {AREA_DE_WORK.AC_DESPR_MOEDACOT}");

            /*" -1790- DISPLAY ' ' */
            _.Display($" ");

            /*" -1791- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1792- DISPLAY '*** VA5437B - TERMINO NORMAL ***' */
            _.Display($"*** VA5437B - TERMINO NORMAL ***");

            /*" -1794- DISPLAY '-------------------------------------------' */
            _.Display($"-------------------------------------------");

            /*" -1802- DISPLAY 'ENCERROU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"ENCERROU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1802- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1816- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1830- DISPLAY 'INICIO SORT-IP     AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"INICIO SORT-IP     AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1833- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-RELATORI = 'S' . */

            while (!(AREA_DE_WORK.WFIM_RELATORI == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -1834- DISPLAY 'LIDOS CURSOR CRELAT .... ' AC-L-RELATORI. */
            _.Display($"LIDOS CURSOR CRELAT .... {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -1837- DISPLAY 'FIM    SORT-IP     AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"FIM    SORT-IP     AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1851- DISPLAY 'INICIO SORT-OP     AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"INICIO SORT-OP     AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1853- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1855- MOVE ZEROS TO WIND */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -1857- PERFORM R2300-00-LE-SORT */

            R2300_00_LE_SORT_SECTION();

            /*" -1860- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT = 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -1864- DISPLAY 'FIM    SORT-OP     AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"FIM    SORT-OP     AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1864- DISPLAY 'LIDOS SORT = ' AC-LIDOS-SORT. */
            _.Display($"LIDOS SORT = {AREA_DE_WORK.AC_LIDOS_SORT}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1875- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1889- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -1892- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -1893- DISPLAY 'VA5437B - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"VA5437B - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1894- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                /*" -1895- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -1897- END-IF. */
            }


            /*" -1898- IF (SQLCODE NOT EQUAL +0 AND +100) */

            if ((!DB.SQLCODE.In("+0", "+100")))
            {

                /*" -1899- DISPLAY 'VA5437B-ERRO2 CALCULO DATA ENTRADA ' SQLCODE */
                _.Display($"VA5437B-ERRO2 CALCULO DATA ENTRADA {DB.SQLCODE}");

                /*" -1900- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                /*" -1901- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -1903- END-IF. */
            }


            /*" -1904- DISPLAY 'VA5437 - DT MOV ABERTO = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"VA5437 - DT MOV ABERTO = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1907- DISPLAY 'VA5437 - SELECIONA RELATORIOS A PARTIR DE ' SISTEMAS-DATA-MOV-ABERTO-15D */
            _.Display($"VA5437 - SELECIONA RELATORIOS A PARTIR DE {SISTEMAS_DATA_MOV_ABERTO_15D}");

            /*" -1910- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO LC11-DATADIA (1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 1, 2);

            /*" -1913- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO LC11-DATADIA (4:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 4, 2);

            /*" -1916- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO LC11-DATADIA (7:4). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 7, 4);

            /*" -1918- MOVE '/' TO LC11-DATADIA(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 6, 1);

            /*" -1918- MOVE '/' TO LC11-DATADIA(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1889- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 YEAR, DATA_MOV_ABERTO - 15 DAYS, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1, :SISTEMAS-DATA-MOV-ABERTO-15D, :V1SIST-MESREFER, :V1SIST-ANOREFER FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_1);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_15D, SISTEMAS_DATA_MOV_ABERTO_15D);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-SECTION */
        private void R0200_00_CARREGA_FAIXACEP_SECTION()
        {
            /*" -1929- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1943- PERFORM R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1();

            /*" -1952- PERFORM R0200_00_CARREGA_FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_FAIXACEP_DB_OPEN_1();

            /*" -1955- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1956- DISPLAY 'VA5437B - ERRO OPEN CURSOR CFAIXACEP' */
                _.Display($"VA5437B - ERRO OPEN CURSOR CFAIXACEP");

                /*" -1957- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -1958- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1960- END-IF. */
            }


            /*" -1961- PERFORM R0210-00-FETCH-FAIXACEP UNTIL WFIM-FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FAIXACEP == "S"))
            {

                R0210_00_FETCH_FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1()
        {
            /*" -1943- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA WITH UR END-EXEC. */
            CFAIXACEP = new VA5437B_CFAIXACEP(true);
            string GetQuery_CFAIXACEP()
            {
                var query = @$"SELECT FAIXA
							, 
							CEP_INICIAL
							, 
							CEP_FINAL
							, 
							DESCRICAO_FAIXA
							, 
							CENTRALIZADOR 
							FROM SEGUROS.GE_FAIXA_CEP 
							WHERE DATA_INIVIGENCIA <= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND DATA_TERVIGENCIA >= 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY FAIXA";

                return query;
            }
            CFAIXACEP.GetQueryEvent += GetQuery_CFAIXACEP;

        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-DB-OPEN-1 */
        public void R0200_00_CARREGA_FAIXACEP_DB_OPEN_1()
        {
            /*" -1952- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-DECLARE-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_DECLARE_1()
        {
            /*" -2022- EXEC SQL DECLARE CMSG CURSOR FOR SELECT NUM_APOLICE, CODSUBES, COD_OPERACAO, JDE, JDL, IDFORM FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM IN ( 'A4' , 'A5' ) AND COD_OPERACAO IN ( 2, 6, 10 ) ORDER BY 1,2,3 WITH UR END-EXEC. */
            CMSG = new VA5437B_CMSG(false);
            string GetQuery_CMSG()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							CODSUBES
							, 
							COD_OPERACAO
							, 
							JDE
							, 
							JDL
							, 
							IDFORM 
							FROM SEGUROS.COBRANCA_MENS_VGAP 
							WHERE IDFORM IN ( 'A4'
							, 'A5' ) 
							AND COD_OPERACAO IN ( 2
							, 6
							, 10 ) 
							ORDER BY 1
							,2
							,3";

                return query;
            }
            CMSG.GetQueryEvent += GetQuery_CMSG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-SECTION */
        private void R0210_00_FETCH_FAIXACEP_SECTION()
        {
            /*" -1972- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -1979- PERFORM R0210_00_FETCH_FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_FAIXACEP_DB_FETCH_1();

            /*" -1982- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1983- MOVE 'S' TO WFIM-FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_FAIXACEP);

                /*" -1983- PERFORM R0210_00_FETCH_FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_FAIXACEP_DB_CLOSE_1();

                /*" -1987- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1989- MOVE GEFAICEP-FAIXA TO TAB-FX-CEP-G (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FX_CEP_G);

            /*" -1991- MOVE GEFAICEP-CEP-INICIAL TO TAB-FX-INI (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1993- MOVE GEFAICEP-CEP-FINAL TO TAB-FX-FIM (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1995- MOVE GEFAICEP-DESCRICAO-FAIXA TO TAB-FX-NOME (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1998- MOVE GEFAICEP-CENTRALIZADOR TO TAB-FX-CENTR (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1998- GO TO R0210-00-FETCH-FAIXACEP. */
            new Task(() => R0210_00_FETCH_FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_FAIXACEP_DB_FETCH_1()
        {
            /*" -1979- EXEC SQL FETCH CFAIXACEP INTO :GEFAICEP-FAIXA, :GEFAICEP-CEP-INICIAL, :GEFAICEP-CEP-FINAL, :GEFAICEP-DESCRICAO-FAIXA, :GEFAICEP-CENTRALIZADOR END-EXEC. */

            if (CFAIXACEP.Fetch())
            {
                _.Move(CFAIXACEP.GEFAICEP_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA);
                _.Move(CFAIXACEP.GEFAICEP_CEP_INICIAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL);
                _.Move(CFAIXACEP.GEFAICEP_CEP_FINAL, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL);
                _.Move(CFAIXACEP.GEFAICEP_DESCRICAO_FAIXA, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA);
                _.Move(CFAIXACEP.GEFAICEP_CENTRALIZADOR, GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-DB-CLOSE-1 */
        public void R0210_00_FETCH_FAIXACEP_DB_CLOSE_1()
        {
            /*" -1983- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-SECTION */
        private void R0300_00_CARREGA_COBMENVG_SECTION()
        {
            /*" -2009- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -2022- PERFORM R0300_00_CARREGA_COBMENVG_DB_DECLARE_1 */

            R0300_00_CARREGA_COBMENVG_DB_DECLARE_1();

            /*" -2031- PERFORM R0300_00_CARREGA_COBMENVG_DB_OPEN_1 */

            R0300_00_CARREGA_COBMENVG_DB_OPEN_1();

            /*" -2034- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2035- DISPLAY 'VA5437B - ERRO OPEN CURSOR CMSG' */
                _.Display($"VA5437B - ERRO OPEN CURSOR CMSG");

                /*" -2036- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2038- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2039- PERFORM R0310-00-FETCH-COBMENVG UNTIL WFIM-COBMENVG EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_COBMENVG == "S"))
            {

                R0310_00_FETCH_COBMENVG_SECTION();
            }

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-OPEN-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_OPEN_1()
        {
            /*" -2031- EXEC SQL OPEN CMSG END-EXEC. */

            CMSG.Open();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-DB-DECLARE-1 */
        public void R0400_00_CARREGA_FCPLANO_DB_DECLARE_1()
        {
            /*" -2104- EXEC SQL DECLARE CFCPLANO CURSOR FOR SELECT NUM_PLANO, QTD_DIG_COMBINACAO FROM FDRCAP.FC_PLANO WHERE NUM_PLANO > 0 ORDER BY NUM_PLANO WITH UR END-EXEC. */
            CFCPLANO = new VA5437B_CFCPLANO(false);
            string GetQuery_CFCPLANO()
            {
                var query = @$"SELECT NUM_PLANO
							, 
							QTD_DIG_COMBINACAO 
							FROM FDRCAP.FC_PLANO 
							WHERE NUM_PLANO > 0 
							ORDER BY NUM_PLANO";

                return query;
            }
            CFCPLANO.GetQueryEvent += GetQuery_CFCPLANO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-SECTION */
        private void R0310_00_FETCH_COBMENVG_SECTION()
        {
            /*" -2050- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -2058- PERFORM R0310_00_FETCH_COBMENVG_DB_FETCH_1 */

            R0310_00_FETCH_COBMENVG_DB_FETCH_1();

            /*" -2061- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2062- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", AREA_DE_WORK.WFIM_COBMENVG);

                /*" -2062- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_1 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_1();

                /*" -2065- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2067- ADD 1 TO WINDM. */
            AREA_DE_WORK.WINDM.Value = AREA_DE_WORK.WINDM + 1;

            /*" -2068- IF WINDM > 3000 */

            if (AREA_DE_WORK.WINDM > 3000)
            {

                /*" -2069- MOVE 3000 TO WINDM */
                _.Move(3000, AREA_DE_WORK.WINDM);

                /*" -2070- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", AREA_DE_WORK.WFIM_COBMENVG);

                /*" -2070- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_2 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_2();

                /*" -2073- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2075- MOVE COBMENVG-NUM-APOLICE TO TABJ-APOLICE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_APOLICE);

            /*" -2077- MOVE COBMENVG-CODSUBES TO TABJ-CODSUBES (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODSUBES);

            /*" -2079- MOVE COBMENVG-COD-OPERACAO TO TABJ-CODOPER (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODOPER);

            /*" -2081- MOVE COBMENVG-JDE TO TABJ-JDE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDE);

            /*" -2083- MOVE COBMENVG-JDL TO TABJ-JDL (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDL);

            /*" -2086- MOVE COBMENVG-IDFORM TO TABJ-IDFORM (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_IDFORM);

            /*" -2086- GO TO R0310-00-FETCH-COBMENVG. */
            new Task(() => R0310_00_FETCH_COBMENVG_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-FETCH-1 */
        public void R0310_00_FETCH_COBMENVG_DB_FETCH_1()
        {
            /*" -2058- EXEC SQL FETCH CMSG INTO :COBMENVG-NUM-APOLICE, :COBMENVG-CODSUBES, :COBMENVG-COD-OPERACAO, :COBMENVG-JDE, :COBMENVG-JDL, :COBMENVG-IDFORM END-EXEC. */

            if (CMSG.Fetch())
            {
                _.Move(CMSG.COBMENVG_NUM_APOLICE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE);
                _.Move(CMSG.COBMENVG_CODSUBES, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES);
                _.Move(CMSG.COBMENVG_COD_OPERACAO, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);
                _.Move(CMSG.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
                _.Move(CMSG.COBMENVG_JDL, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);
                _.Move(CMSG.COBMENVG_IDFORM, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-1 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_1()
        {
            /*" -2062- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-2 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_2()
        {
            /*" -2070- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-SECTION */
        private void R0400_00_CARREGA_FCPLANO_SECTION()
        {
            /*" -2096- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -2104- PERFORM R0400_00_CARREGA_FCPLANO_DB_DECLARE_1 */

            R0400_00_CARREGA_FCPLANO_DB_DECLARE_1();

            /*" -2113- PERFORM R0400_00_CARREGA_FCPLANO_DB_OPEN_1 */

            R0400_00_CARREGA_FCPLANO_DB_OPEN_1();

            /*" -2116- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2117- DISPLAY 'VA5437B - ERRO OPEN CURSOR CFCPLANO ' */
                _.Display($"VA5437B - ERRO OPEN CURSOR CFCPLANO ");

                /*" -2118- DISPLAY 'SLQCODE = ' SQLCODE */
                _.Display($"SLQCODE = {DB.SQLCODE}");

                /*" -2120- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2121- PERFORM R0410-00-FETCH-FCPLANO UNTIL WFIM-FCPLANO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FCPLANO == "S"))
            {

                R0410_00_FETCH_FCPLANO_SECTION();
            }

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-DB-OPEN-1 */
        public void R0400_00_CARREGA_FCPLANO_DB_OPEN_1()
        {
            /*" -2113- EXEC SQL OPEN CFCPLANO END-EXEC. */

            CFCPLANO.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1()
        {
            /*" -2171- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT COD_FONTE, NOME_FONTE, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.FONTES WHERE COD_FONTE < 99 ORDER BY COD_FONTE WITH UR END-EXEC. */
            V1AGENCEF = new VA5437B_V1AGENCEF(false);
            string GetQuery_V1AGENCEF()
            {
                var query = @$"SELECT 
							COD_FONTE
							, 
							NOME_FONTE
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							CEP
							, 
							SIGLA_UF 
							FROM SEGUROS.FONTES 
							WHERE COD_FONTE < 99 
							ORDER BY COD_FONTE";

                return query;
            }
            V1AGENCEF.GetQueryEvent += GetQuery_V1AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-SECTION */
        private void R0410_00_FETCH_FCPLANO_SECTION()
        {
            /*" -2132- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WABEND.WNR_EXEC_SQL);

            /*" -2136- PERFORM R0410_00_FETCH_FCPLANO_DB_FETCH_1 */

            R0410_00_FETCH_FCPLANO_DB_FETCH_1();

            /*" -2139- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2140- MOVE 'S' TO WFIM-FCPLANO */
                _.Move("S", AREA_DE_WORK.WFIM_FCPLANO);

                /*" -2140- PERFORM R0410_00_FETCH_FCPLANO_DB_CLOSE_1 */

                R0410_00_FETCH_FCPLANO_DB_CLOSE_1();

                /*" -2143- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2146- MOVE FCPLANO-QTD-DIG-COMBINACAO TO TAB-QTD-DIG (FCPLANO-NUM-PLANO). */
            _.Move(FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO, TAB_QTD_DIG_COMBINACAO.TAB_COMB[FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO].TAB_QTD_DIG);

            /*" -2146- GO TO R0410-00-FETCH-FCPLANO. */
            new Task(() => R0410_00_FETCH_FCPLANO_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-DB-FETCH-1 */
        public void R0410_00_FETCH_FCPLANO_DB_FETCH_1()
        {
            /*" -2136- EXEC SQL FETCH CFCPLANO INTO :FCPLANO-NUM-PLANO, :FCPLANO-QTD-DIG-COMBINACAO END-EXEC. */

            if (CFCPLANO.Fetch())
            {
                _.Move(CFCPLANO.FCPLANO_NUM_PLANO, FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO);
                _.Move(CFCPLANO.FCPLANO_QTD_DIG_COMBINACAO, FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO);
            }

        }

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-DB-CLOSE-1 */
        public void R0410_00_FETCH_FCPLANO_DB_CLOSE_1()
        {
            /*" -2140- EXEC SQL CLOSE CFCPLANO END-EXEC */

            CFCPLANO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-SECTION */
        private void R0500_00_DECLARE_AGENCCEF_SECTION()
        {
            /*" -2157- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -2171- PERFORM R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1();

            /*" -2180- PERFORM R0500_00_DECLARE_AGENCCEF_DB_OPEN_1 */

            R0500_00_DECLARE_AGENCCEF_DB_OPEN_1();

            /*" -2183- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2184- DISPLAY 'R0500 - ERRO OPEN CURSOR V1AGENCEF' */
                _.Display($"R0500 - ERRO OPEN CURSOR V1AGENCEF");

                /*" -2185- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2185- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_OPEN_1()
        {
            /*" -2180- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R0900_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -2298- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT A.COD_OPERACAO, A.COD_USUARIO, A.COD_RELATORIO, A.NUM_PARCELA, A.TIMESTAMP, B.DATA_QUITACAO, B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_CERTIFICADO, B.COD_PRODUTO, B.COD_CLIENTE, B.OCOREND, B.IDE_SEXO, B.SIT_REGISTRO, B.AGE_COBRANCA, B.COD_FONTE, B.IDADE, B.OCORR_HISTORICO, B.FAIXA_RENDA_IND, B.FAIXA_RENDA_FAM, B.DTPROXVEN, C.CODRELAT, C.PERI_PAGAMENTO, VALUE(A.TIPO_CORRECAO, 'GERAL' ), D.COD_EMPRESA FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C, SEGUROS.PRODUTO D WHERE A.SIT_REGISTRO = '0' AND A.COD_OPERACAO IN (2, 6, 10) AND A.NUM_PARCELA = 2 AND A.DATA_SOLICITACAO > :SISTEMAS-DATA-MOV-ABERTO-15D AND B.SIT_REGISTRO <> '2' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.RAMO <> 77 AND B.COD_PRODUTO = D.COD_PRODUTO ORDER BY B.NUM_CERTIFICADO, A.DATA_SOLICITACAO WITH UR END-EXEC. */
            CRELAT = new VA5437B_CRELAT(true);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT A.COD_OPERACAO
							, 
							A.COD_USUARIO
							, 
							A.COD_RELATORIO
							, 
							A.NUM_PARCELA
							, 
							A.TIMESTAMP
							, 
							B.DATA_QUITACAO
							, 
							B.NUM_APOLICE
							, 
							B.COD_SUBGRUPO
							, 
							B.NUM_CERTIFICADO
							, 
							B.COD_PRODUTO
							, 
							B.COD_CLIENTE
							, 
							B.OCOREND
							, 
							B.IDE_SEXO
							, 
							B.SIT_REGISTRO
							, 
							B.AGE_COBRANCA
							, 
							B.COD_FONTE
							, 
							B.IDADE
							, 
							B.OCORR_HISTORICO
							, 
							B.FAIXA_RENDA_IND
							, 
							B.FAIXA_RENDA_FAM
							, 
							B.DTPROXVEN
							, 
							C.CODRELAT
							, 
							C.PERI_PAGAMENTO
							, 
							VALUE(A.TIPO_CORRECAO
							, 'GERAL' )
							, 
							D.COD_EMPRESA 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C
							, 
							SEGUROS.PRODUTO D 
							WHERE A.SIT_REGISTRO = '0' 
							AND A.COD_OPERACAO IN (2
							, 6
							, 10) 
							AND A.NUM_PARCELA = 2 
							AND A.DATA_SOLICITACAO > 
							'{SISTEMAS_DATA_MOV_ABERTO_15D}' 
							AND B.SIT_REGISTRO <> '2' 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.RAMO <> 77 
							AND B.COD_PRODUTO = D.COD_PRODUTO 
							ORDER BY B.NUM_CERTIFICADO
							, A.DATA_SOLICITACAO";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-SECTION */
        private void R0510_00_FETCH_AGENCCEF_SECTION()
        {
            /*" -2196- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -2205- PERFORM R0510_00_FETCH_AGENCCEF_DB_FETCH_1 */

            R0510_00_FETCH_AGENCCEF_DB_FETCH_1();

            /*" -2208- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2209- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2210- MOVE 'S' TO WFIM-AGENCCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_AGENCCEF);

                    /*" -2210- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_1();

                    /*" -2212- ELSE */
                }
                else
                {


                    /*" -2212- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_2();

                    /*" -2214- DISPLAY 'R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..");

                    /*" -2215- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2215- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_AGENCCEF_DB_FETCH_1()
        {
            /*" -2205- EXEC SQL FETCH V1AGENCEF INTO :MALHACEF-COD-FONTE, :FONTES-NOME-FONTE, :FONTES-ENDERECO, :FONTES-BAIRRO, :FONTES-CIDADE, :FONTES-CEP, :FONTES-SIGLA-UF END-EXEC. */

            if (V1AGENCEF.Fetch())
            {
                _.Move(V1AGENCEF.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
                _.Move(V1AGENCEF.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
                _.Move(V1AGENCEF.FONTES_ENDERECO, FONTES.DCLFONTES.FONTES_ENDERECO);
                _.Move(V1AGENCEF.FONTES_BAIRRO, FONTES.DCLFONTES.FONTES_BAIRRO);
                _.Move(V1AGENCEF.FONTES_CIDADE, FONTES.DCLFONTES.FONTES_CIDADE);
                _.Move(V1AGENCEF.FONTES_CEP, FONTES.DCLFONTES.FONTES_CEP);
                _.Move(V1AGENCEF.FONTES_SIGLA_UF, FONTES.DCLFONTES.FONTES_SIGLA_UF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-CLOSE-1 */
        public void R0510_00_FETCH_AGENCCEF_DB_CLOSE_1()
        {
            /*" -2210- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_AGENCCEF_DB_CLOSE_2()
        {
            /*" -2212- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -2226- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -2228- MOVE MALHACEF-COD-FONTE TO IDX-IND1. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, AREA_DE_WORK.IDX_IND1);

            /*" -2230- MOVE MALHACEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -2232- MOVE FONTES-NOME-FONTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -2234- MOVE FONTES-ENDERECO TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_ENDERECO, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -2236- MOVE FONTES-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_BAIRRO, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -2238- MOVE FONTES-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CIDADE, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -2240- MOVE FONTES-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CEP, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -2243- MOVE FONTES-SIGLA-UF TO TAB-UF (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_SIGLA_UF, TAB_FILIAL.FILLER_127[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -2243- PERFORM R0510-00-FETCH-AGENCCEF. */

            R0510_00_FETCH_AGENCCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-SECTION */
        private void R0900_00_DECLARE_RELATORI_SECTION()
        {
            /*" -2254- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -2298- PERFORM R0900_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R0900_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -2313- DISPLAY 'INICIO OPEN CRELAT AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"INICIO OPEN CRELAT AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -2313- PERFORM R0900_00_DECLARE_RELATORI_DB_OPEN_1 */

            R0900_00_DECLARE_RELATORI_DB_OPEN_1();

            /*" -2316- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2317- DISPLAY 'VA5437B - ERRO OPEN CURSOR CRELAT ' */
                _.Display($"VA5437B - ERRO OPEN CURSOR CRELAT ");

                /*" -2318- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2319- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2321- END-IF. */
            }


            /*" -2324- DISPLAY 'FIM    OPEN CRELAT AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"FIM    OPEN CRELAT AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R0900_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -2313- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-DB-DECLARE-1 */
        public void R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1()
        {
            /*" -2912- EXEC SQL DECLARE CTITFEDCA CURSOR FOR SELECT NRTITFDCAP, NRSORTEIO FROM SEGUROS.TITULOS_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA > :SISTEMAS-DATA-MOV-ABERTO ORDER BY NRSORTEIO, NRTITFDCAP WITH UR END-EXEC. */
            CTITFEDCA = new VA5437B_CTITFEDCA(true);
            string GetQuery_CTITFEDCA()
            {
                var query = @$"SELECT NRTITFDCAP
							, 
							NRSORTEIO 
							FROM SEGUROS.TITULOS_FED_CAP_VA 
							WHERE NUM_CERTIFICADO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA > '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY NRSORTEIO
							, NRTITFDCAP";

                return query;
            }
            CTITFEDCA.GetQueryEvent += GetQuery_CTITFEDCA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-SECTION */
        private void R0910_00_FETCH_RELATORI_SECTION()
        {
            /*" -2335- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -2362- PERFORM R0910_00_FETCH_RELATORI_DB_FETCH_1 */

            R0910_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -2365- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2366- DISPLAY 'GRAVADO SORT..:' AC-GRAV-SORT */
                _.Display($"GRAVADO SORT..:{AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -2367- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -2369- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2369- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_1 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -2372- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2375- ADD 1 TO AC-L-RELATORI AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_L_RELATORI.Value = AREA_DE_WORK.AC_L_RELATORI + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -2397- DISPLAY 'LEU: ' RELATORI-COD-OPERACAO RELATORI-COD-OPERACAO '/' RELATORI-COD-USUARIO '/' RELATORI-COD-RELATORIO '/' PROPOVA-NUM-APOLICE '/' PROPOVA-COD-SUBGRUPO '/' PROPOVA-NUM-CERTIFICADO '/' PROPOVA-COD-PRODUTO '/' PROPOVA-SIT-REGISTRO '/' RELATORI-TIPO-CORRECAO '/' PRODUTO-COD-EMPRESA */

            $"LEU: {RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO}{RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO}/{RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}/{RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO}/{RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO}/{PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA}"
            .Display();

            /*" -2399- MOVE PROPOVA-NUM-CERTIFICADO TO WS-CERTIFICADO-ATU. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_CERTIFICADO_ATU);

            /*" -2400- IF VIND-RENDA-IND LESS +0 */

            if (VIND_RENDA_IND < +0)
            {

                /*" -2403- MOVE ZEROS TO PROPOVA-FAIXA-RENDA-IND PROPOVA-FAIXA-RENDA-FAM */
                _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);

                /*" -2405- END-IF. */
            }


            /*" -2406- IF AC-LIDOS EQUAL 200000 */

            if (AREA_DE_WORK.AC_LIDOS == 200000)
            {

                /*" -2407- DISPLAY 'GRAVADO SORT..:' AC-GRAV-SORT */
                _.Display($"GRAVADO SORT..:{AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -2408- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -2410- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2410- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_2 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_2();

                /*" -2412- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -2414- END-IF. */
            }


            /*" -2415- IF AC-GRAV-SORT EQUAL 40000 */

            if (AREA_DE_WORK.AC_GRAV_SORT == 40000)
            {

                /*" -2416- DISPLAY 'GRAVADO SORT..:' AC-GRAV-SORT */
                _.Display($"GRAVADO SORT..:{AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -2417- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -2419- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2419- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_3 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_3();

                /*" -2421- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -2423- END-IF. */
            }


            /*" -2423- MOVE PROPOVA-COD-PRODUTO TO W88-PRODUTO-VIDA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, W88_PRODUTO_VIDA);

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -2362- EXEC SQL FETCH CRELAT INTO :RELATORI-COD-OPERACAO, :RELATORI-COD-USUARIO, :RELATORI-COD-RELATORIO, :RELATORI-NUM-PARCELA, :RELATORI-TIMESTAMP, :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-IDE-SEXO, :PROPOVA-SIT-REGISTRO, :PROPOVA-AGE-COBRANCA, :PROPOVA-COD-FONTE, :PROPOVA-IDADE, :PROPOVA-OCORR-HISTORICO, :PROPOVA-FAIXA-RENDA-IND:VIND-RENDA-IND, :PROPOVA-FAIXA-RENDA-FAM:VIND-RENDA-FAM, :PROPOVA-DTPROXVEN, :PRODUVG-CODRELAT, :PRODUVG-PERI-PAGAMENTO, :RELATORI-TIPO-CORRECAO, :PRODUTO-COD-EMPRESA END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(CRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(CRELAT.RELATORI_COD_RELATORIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);
                _.Move(CRELAT.RELATORI_NUM_PARCELA, RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA);
                _.Move(CRELAT.RELATORI_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);
                _.Move(CRELAT.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CRELAT.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CRELAT.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CRELAT.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CRELAT.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(CRELAT.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CRELAT.PROPOVA_OCOREND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND);
                _.Move(CRELAT.PROPOVA_IDE_SEXO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO);
                _.Move(CRELAT.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(CRELAT.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(CRELAT.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(CRELAT.PROPOVA_IDADE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE);
                _.Move(CRELAT.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CRELAT.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(CRELAT.VIND_RENDA_IND, VIND_RENDA_IND);
                _.Move(CRELAT.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(CRELAT.VIND_RENDA_FAM, VIND_RENDA_FAM);
                _.Move(CRELAT.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CRELAT.PRODUVG_CODRELAT, PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT);
                _.Move(CRELAT.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CRELAT.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(CRELAT.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -2369- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-2 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_2()
        {
            /*" -2410- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -2434- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -2435- IF (WS-CERTIFICADO-A EQUAL PROPOVA-NUM-CERTIFICADO) */

            if ((WS_CERTIFICADO_A == PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO))
            {

                /*" -2436- DISPLAY ' DESPREZA 03: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 03: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2437- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2439- END-IF. */
            }


            /*" -2441- MOVE PROPOVA-NUM-CERTIFICADO TO WS-CERTIFICADO-A */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_CERTIFICADO_A);

            /*" -2443- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE COBMENVG-NUM-APOLICE */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE);


            /*" -2445- MOVE PROPOVA-COD-SUBGRUPO TO WS-CODSUBES COBMENVG-CODSUBES */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES);


            /*" -2448- MOVE RELATORI-COD-OPERACAO TO WHOST-CODOPER WS-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, WHOST_CODOPER);
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);


            /*" -2449- IF (RELATORI-COD-USUARIO EQUAL 'VA0118B' ) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO == "VA0118B"))
            {

                /*" -2450- MOVE 'A5' TO WS-IDFORM */
                _.Move("A5", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -2451- MOVE 6 TO COBMENVG-COD-OPERACAO */
                _.Move(6, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                /*" -2452- ELSE */
            }
            else
            {


                /*" -2453- IF (RELATORI-COD-USUARIO EQUAL 'VA0130B' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO == "VA0130B"))
                {

                    /*" -2454- MOVE 'A4' TO WS-IDFORM */
                    _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                    /*" -2455- MOVE 10 TO COBMENVG-COD-OPERACAO */
                    _.Move(10, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                    /*" -2456- ELSE */
                }
                else
                {


                    /*" -2457- MOVE 'A4' TO WS-IDFORM */
                    _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                    /*" -2458- MOVE 2 TO COBMENVG-COD-OPERACAO */
                    _.Move(2, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                    /*" -2459- END-IF */
                }


                /*" -2461- END-IF. */
            }


            /*" -2462- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -2464- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -2468- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2469- IF NOT ( WS-JDE EQUAL 'VA54' OR 'VIDA10' ) */

            if (!(AREA_DE_WORK.WS_JDE_GER.WS_JDE.In("VA54", "VIDA10")))
            {

                /*" -2471- DISPLAY ' DESPREZA 04: ' PROPOVA-NUM-CERTIFICADO '/' WS-JDE */

                $" DESPREZA 04: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{AREA_DE_WORK.WS_JDE_GER.WS_JDE}"
                .Display();

                /*" -2472- ADD 1 TO AC-DESPR-NOT-VA54 */
                AREA_DE_WORK.AC_DESPR_NOT_VA54.Value = AREA_DE_WORK.AC_DESPR_NOT_VA54 + 1;

                /*" -2473- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2475- END-IF */
            }


            /*" -2476- MOVE WS-JDE TO SVA-JDE */
            _.Move(AREA_DE_WORK.WS_JDE_GER.WS_JDE, REG_SVA5437B.SVA_JDE);

            /*" -2478- MOVE COBMENVG-JDL TO SVA-JDL */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL, REG_SVA5437B.SVA_JDL);

            /*" -2480- MOVE 'DBM' TO SVA-DBM */
            _.Move("DBM", REG_SVA5437B.SVA_DBM);

            /*" -2482- PERFORM R1400-00-SELECT-HISCOBPR. */

            R1400_00_SELECT_HISCOBPR_SECTION();

            /*" -2483- IF (WTEM-HISCOBPR EQUAL 'N' ) */

            if ((AREA_DE_WORK.WTEM_HISCOBPR == "N"))
            {

                /*" -2484- DISPLAY ' DESPREZA 05: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 05: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2485- ADD 1 TO AC-DESPR-COBERPRO */
                AREA_DE_WORK.AC_DESPR_COBERPRO.Value = AREA_DE_WORK.AC_DESPR_COBERPRO + 1;

                /*" -2486- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2492- END-IF */
            }


            /*" -2501- IF (HISCOBPR-VAL-CUSTO-CAPITALI EQUAL ZEROS) OR (W88-PRODUTO-VIDA = 9314 OR JVPRD9314 OR 9328 OR JVPRD9328 OR 9334 OR JVPRD9334 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9703 OR 9705) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI == 00) || (W88_PRODUTO_VIDA.In("9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9703", "9705")))
            {

                /*" -2502- MOVE 'N�o contempla' TO SVA-NRSORTE-RED */
                _.Move("N�o contempla", REG_SVA5437B.SVA_NRSORTE_RED);

                /*" -2503- MOVE 'N�o se aplica' TO SVA-COD-SUSEP-CAP */
                _.Move("N�o se aplica", REG_SVA5437B.SVA_COD_SUSEP_CAP);

                /*" -2504- ELSE */
            }
            else
            {


                /*" -2505- PERFORM R1120-00-DECLARE-TITFEDCA */

                R1120_00_DECLARE_TITFEDCA_SECTION();

                /*" -2507- PERFORM R1130-00-FETCH-TITFEDCA */

                R1130_00_FETCH_TITFEDCA_SECTION();

                /*" -2508- IF (WFIM-TITFEDCA NOT EQUAL 'S' ) */

                if ((AREA_DE_WORK.WFIM_TITFEDCA != "S"))
                {

                    /*" -2510- PERFORM R1140-00-PROCESSA-TITFEDCA UNTIL WFIM-TITFEDCA = 'S' */

                    while (!(AREA_DE_WORK.WFIM_TITFEDCA == "S"))
                    {

                        R1140_00_PROCESSA_TITFEDCA_SECTION();
                    }

                    /*" -2511- END-IF */
                }


                /*" -2513- END-IF */
            }


            /*" -2514- IF WS-CERTIFICADO-ATU NOT = WS-CERTIFICADO-ANT */

            if (WS_CERTIFICADO_ATU != WS_CERTIFICADO_ANT)
            {

                /*" -2515- MOVE WS-CERTIFICADO-ATU TO WS-CERTIFICADO-ANT */
                _.Move(WS_CERTIFICADO_ATU, WS_CERTIFICADO_ANT);

                /*" -2516- ELSE */
            }
            else
            {


                /*" -2517- DISPLAY ' DESPREZA 06: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 06: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2518- ADD 1 TO AC-DESPR-CERTIF */
                AREA_DE_WORK.AC_DESPR_CERTIF.Value = AREA_DE_WORK.AC_DESPR_CERTIF + 1;

                /*" -2519- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2521- END-IF */
            }


            /*" -2523- MOVE ZEROS TO WS-DUPLICADO. */
            _.Move(0, WS_DUPLICADO);

            /*" -2526- IF RELATORI-COD-RELATORIO EQUAL PRODUVG-CODRELAT */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT)
            {

                /*" -2539- PERFORM R1000_00_PROCESSA_INPUT_DB_SELECT_1 */

                R1000_00_PROCESSA_INPUT_DB_SELECT_1();

                /*" -2542- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2543- MOVE ZEROS TO WS-DUPLICADO */
                    _.Move(0, WS_DUPLICADO);

                    /*" -2544- END-IF */
                }


                /*" -2546- END-IF */
            }


            /*" -2547- IF WS-DUPLICADO GREATER ZEROS */

            if (WS_DUPLICADO > 00)
            {

                /*" -2548- DISPLAY ' DESPREZA 07: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 07: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2549- ADD 1 TO AC-DESPR-DUPLIC */
                AREA_DE_WORK.AC_DESPR_DUPLIC.Value = AREA_DE_WORK.AC_DESPR_DUPLIC + 1;

                /*" -2551- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2553- PERFORM R1010-00-SELECT-SEGURVGA. */

            R1010_00_SELECT_SEGURVGA_SECTION();

            /*" -2554- IF WTEM-SEGURVGA EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_SEGURVGA == "N")
            {

                /*" -2555- DISPLAY ' DESPREZA 08: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 08: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2556- ADD 1 TO AC-DESPR-SEGURAVG */
                AREA_DE_WORK.AC_DESPR_SEGURAVG.Value = AREA_DE_WORK.AC_DESPR_SEGURAVG + 1;

                /*" -2558- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2560- PERFORM R1015-00-SELECT-SEGURVGA-HIST */

            R1015_00_SELECT_SEGURVGA_HIST_SECTION();

            /*" -2562- PERFORM R1100-00-SELECT-OPCPAGVI. */

            R1100_00_SELECT_OPCPAGVI_SECTION();

            /*" -2563- IF WTEM-OPCPAGVI EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_OPCPAGVI == "N")
            {

                /*" -2564- DISPLAY ' DESPREZA 09: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 09: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2565- ADD 1 TO AC-DESPR-OPCAOPAG */
                AREA_DE_WORK.AC_DESPR_OPCAOPAG.Value = AREA_DE_WORK.AC_DESPR_OPCAOPAG + 1;

                /*" -2567- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2569- PERFORM R1200-00-SELECT-CLIENTES. */

            R1200_00_SELECT_CLIENTES_SECTION();

            /*" -2570- IF WTEM-CLIENTES EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CLIENTES == "N")
            {

                /*" -2571- DISPLAY ' DESPREZA 10: ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" DESPREZA 10: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2572- ADD 1 TO AC-DESPR-CLIENTE */
                AREA_DE_WORK.AC_DESPR_CLIENTE.Value = AREA_DE_WORK.AC_DESPR_CLIENTE + 1;

                /*" -2574- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2576- PERFORM R1210-00-SELECT-EMAIL. */

            R1210_00_SELECT_EMAIL_SECTION();

            /*" -2578- MOVE PROPOVA-OCOREND TO WHOST-OCOREND. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND, WHOST_OCOREND);

            /*" -2585- PERFORM R1300-00-SELECT-ENDERECO. */

            R1300_00_SELECT_ENDERECO_SECTION();

            /*" -2587- IF WTEM-ENDERECO EQUAL 'S' NEXT SENTENCE */

            if (AREA_DE_WORK.WTEM_ENDERECO == "S")
            {

                /*" -2588- ELSE */
            }
            else
            {


                /*" -2589- MOVE SEGURVGA-OCORR-ENDERECO TO WHOST-OCOREND */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO, WHOST_OCOREND);

                /*" -2591- PERFORM R1300-00-SELECT-ENDERECO */

                R1300_00_SELECT_ENDERECO_SECTION();

                /*" -2593- IF WTEM-ENDERECO EQUAL 'S' NEXT SENTENCE */

                if (AREA_DE_WORK.WTEM_ENDERECO == "S")
                {

                    /*" -2594- ELSE ADD 1 TO AC-DESPR-ENDERECO */
                }
                else
                {


                    /*" -2595- DISPLAY ' DESPREZA 11: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($" DESPREZA 11: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2596- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2597- END-IF */
                }


                /*" -2599- END-IF */
            }


            /*" -2601- PERFORM R1500-00-SELECT-AGENCCEF. */

            R1500_00_SELECT_AGENCCEF_SECTION();

            /*" -2603- PERFORM R1600-00-SELECT-APOLICE. */

            R1600_00_SELECT_APOLICE_SECTION();

            /*" -2614- PERFORM R1640-00-SELECT-ENDOSSOS. */

            R1640_00_SELECT_ENDOSSOS_SECTION();

            /*" -2616- MOVE PROPOVA-DATA-QUITACAO TO SVA-DTQUIT. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVA5437B.SVA_DTQUIT);

            /*" -2617- MOVE ZEROS TO SVA-PLANO. */
            _.Move(0, REG_SVA5437B.SVA_PLANO);

            /*" -2619- MOVE APOLICES-RAMO-EMISSOR TO SVA-RAMO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, REG_SVA5437B.SVA_RAMO);

            /*" -2620- MOVE MALHACEF-COD-FONTE TO SVA-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, REG_SVA5437B.SVA_FONTE);

            /*" -2622- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA5437B.SVA_NRCERTIF);

            /*" -2623- MOVE PROPOVA-IDE-SEXO TO SVA-IDSEXO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO, REG_SVA5437B.SVA_IDSEXO);

            /*" -2625- MOVE SEGURVGA-DATA-INIVIGENCIA TO SVA-DTINIVIG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, REG_SVA5437B.SVA_DTINIVIG);

            /*" -2626- MOVE PROPOVA-NUM-APOLICE TO SVA-NRAPOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, REG_SVA5437B.SVA_NRAPOLICE);

            /*" -2628- MOVE PROPOVA-COD-SUBGRUPO TO SVA-CODSUBES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, REG_SVA5437B.SVA_CODSUBES);

            /*" -2630- MOVE PROPOVA-FAIXA-RENDA-IND TO SVA-RENDA-IND */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, REG_SVA5437B.SVA_RENDA_IND);

            /*" -2632- MOVE PROPOVA-FAIXA-RENDA-FAM TO SVA-RENDA-FAM */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, REG_SVA5437B.SVA_RENDA_FAM);

            /*" -2634- MOVE PRODUVG-CODRELAT TO SVA-CODRELAT. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT, REG_SVA5437B.SVA_CODRELAT);

            /*" -2636- MOVE RELATORI-COD-RELATORIO TO SVA-CODRELATVG. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO, REG_SVA5437B.SVA_CODRELATVG);

            /*" -2637- MOVE SEGURVGA-NUM-ITEM TO SVA-NUM-ITEM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, REG_SVA5437B.SVA_NUM_ITEM);

            /*" -2639- MOVE SEGURVGA-OCORR-HISTORICO TO SVA-OCORHIST. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, REG_SVA5437B.SVA_OCORHIST);

            /*" -2641- MOVE HISCOBPR-DATA-INIVIGENCIA TO SVA-DTMOVTO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, REG_SVA5437B.SVA_DTMOVTO);

            /*" -2643- MOVE RELATORI-COD-OPERACAO TO SVA-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, REG_SVA5437B.SVA_CODOPER);

            /*" -2645- MOVE RELATORI-COD-USUARIO TO SVA-CODUSU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SVA5437B.SVA_CODUSU);

            /*" -2647- MOVE PROPOVA-SIT-REGISTRO TO SVA-SITPROP. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO, REG_SVA5437B.SVA_SITPROP);

            /*" -2649- MOVE PROPOVA-DTPROXVEN TO SVA-DTPROXVEN */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN, REG_SVA5437B.SVA_DTPROXVEN);

            /*" -2650- MOVE SEGURVGA-SIT-REGISTRO TO SVA-SITSEG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO, REG_SVA5437B.SVA_SITSEG);

            /*" -2651- MOVE HISCOBPR-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVA5437B.SVA_VLPREMIO);

            /*" -2652- MOVE HISCOBPR-IMPSEGCDG TO SVA-IMPSEGCDG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, REG_SVA5437B.SVA_IMPSEGCDG);

            /*" -2653- MOVE OPCPAGVI-DIA-DEBITO TO SVA-DIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVA5437B.SVA_DIA_DEBITO);

            /*" -2654- MOVE CLIENTES-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SVA5437B.SVA_NOME_RAZAO);

            /*" -2655- MOVE CLIENTES-CGCCPF TO SVA-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SVA5437B.SVA_CPF);

            /*" -2657- MOVE CLIENTES-DATA-NASCIMENTO TO SVA-DTNASC WS-DTNASC */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, REG_SVA5437B.SVA_DTNASC, AREA_DE_WORK.WS_DTNASC);

            /*" -2659- MOVE PROPOVA-COD-CLIENTE TO SVA-CODCLIEN. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, REG_SVA5437B.SVA_CODCLIEN);

            /*" -2662- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DTMOVABE */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DTMOVABE);

            /*" -2669- PERFORM R1000_00_PROCESSA_INPUT_DB_SELECT_2 */

            R1000_00_PROCESSA_INPUT_DB_SELECT_2();

            /*" -2672- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2676- DISPLAY '*** VA5437B ERRO CALCULO DA IDADE  ' SVA-NRCERTIF ' - ' SISTEMAS-DATA-MOV-ABERTO ' - ' CLIENTES-DATA-NASCIMENTO */

                $"*** VA5437B ERRO CALCULO DA IDADE  {REG_SVA5437B.SVA_NRCERTIF} - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO} - {CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO}"
                .Display();

                /*" -2677- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2679- END-IF. */
            }


            /*" -2680- MOVE CLIENEMA-EMAIL TO SVA-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, REG_SVA5437B.SVA_EMAIL);

            /*" -2681- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAO-PAG */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA5437B.SVA_OPCAO_PAG);

            /*" -2682- MOVE OPCPAGVI-PERI-PAGAMENTO TO SVA-PERI-PAGAMENTO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, REG_SVA5437B.SVA_PERI_PAGAMENTO);

            /*" -2684- MOVE OPCPAGVI-DATA-INIVIGENCIA TO SVA-DTINIVIG-OPCPAG */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA, REG_SVA5437B.SVA_DTINIVIG_OPCPAG);

            /*" -2686- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2688- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-AGECTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVA5437B.SVA_AGECTADEB);

                /*" -2690- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-OPRCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVA5437B.SVA_OPRCTADEB);

                /*" -2692- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUMCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVA5437B.SVA_NUMCTADEB);

                /*" -2694- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIGCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVA5437B.SVA_DIGCTADEB);

                /*" -2695- ELSE */
            }
            else
            {


                /*" -2699- MOVE ZEROS TO SVA-AGECTADEB SVA-OPRCTADEB SVA-NUMCTADEB SVA-DIGCTADEB */
                _.Move(0, REG_SVA5437B.SVA_AGECTADEB, REG_SVA5437B.SVA_OPRCTADEB, REG_SVA5437B.SVA_NUMCTADEB, REG_SVA5437B.SVA_DIGCTADEB);

                /*" -2701- END-IF */
            }


            /*" -2703- MOVE ENDOSSOS-DATA-INIVIGENCIA TO SVA-DTINIVIG-APOL */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, REG_SVA5437B.SVA_DTINIVIG_APOL);

            /*" -2707- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SVA-DTTERVIG SVA-DTTERVIG-APOL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA5437B.SVA_DTTERVIG, REG_SVA5437B.SVA_DTTERVIG_APOL);

            /*" -2710- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA-1 NEXT SENTENCE */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS_DATA_TERVIGENCIA_1)
            {

                /*" -2711- ELSE */
            }
            else
            {


                /*" -2713- IF WHOST-DATA-TERVIG-PREMIO (6:2) < ENDOSSOS-DATA-TERVIGENCIA-1 (6:2) */

                if (WHOST_DATA_TERVIG_PREMIO.Substring(6, 2) < ENDOSSOS_DATA_TERVIGENCIA_1.Substring(6, 2))
                {

                    /*" -2715- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2716- ELSE */
                }
                else
                {


                    /*" -2718- MOVE SISTEMAS-DATA-MOV-ABERTO-1 (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS_DATA_MOV_ABERTO_1.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2719- END-IF */
                }


                /*" -2721- END-IF. */
            }


            /*" -2722- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -2723- MOVE '*' TO SVA-IND-VIGENCIA */
                _.Move("*", REG_SVA5437B.SVA_IND_VIGENCIA);

                /*" -2724- ELSE */
            }
            else
            {


                /*" -2725- MOVE ' ' TO SVA-IND-VIGENCIA */
                _.Move(" ", REG_SVA5437B.SVA_IND_VIGENCIA);

                /*" -2727- END-IF */
            }


            /*" -2729- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAOPAG. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA5437B.SVA_OPCAOPAG);

            /*" -2730- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SVA5437B.SVA_ENDERECO);

            /*" -2731- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SVA5437B.SVA_BAIRRO);

            /*" -2732- MOVE ENDERECO-CIDADE TO SVA-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SVA5437B.SVA_CIDADE);

            /*" -2733- MOVE ENDERECO-SIGLA-UF TO SVA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SVA5437B.SVA_UF);

            /*" -2735- MOVE ENDERECO-CEP TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2737- MOVE PROPOVA-COD-PRODUTO TO SVA-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, REG_SVA5437B.SVA_PRODUTO);

            /*" -2738- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -2739- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVA5437B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2740- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVA5437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2741- ELSE */
            }
            else
            {


                /*" -2742- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVA5437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2743- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVA5437B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2745- END-IF */
            }


            /*" -2746- IF ENDERECO-CEP EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
            {

                /*" -2747- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA5437B.SVA_CEP_G);

                /*" -2748- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA5437B.SVA_NOME_CORREIO);

                /*" -2749- ELSE */
            }
            else
            {


                /*" -2750- PERFORM R1900-00-LOCALIZA-CEP */

                R1900_00_LOCALIZA_CEP_SECTION();

                /*" -2752- END-IF */
            }


            /*" -2753- IF (RELATORI-TIPO-CORRECAO EQUAL SPACES) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.IsEmpty()))
            {

                /*" -2754- PERFORM R9200-00-PESQUISA-FORMULARIO */

                R9200_00_PESQUISA_FORMULARIO_SECTION();

                /*" -2755- ELSE */
            }
            else
            {


                /*" -2756- MOVE RELATORI-TIPO-CORRECAO TO SVA-TP-ARQSAIDA */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO, REG_SVA5437B.SVA_TP_ARQSAIDA);

                /*" -2758- END-IF */
            }


            /*" -2760- DISPLAY 'GRV SORT: ' SVA-TP-ARQSAIDA '/' SVA-NRCERTIF '/' SVA-JDE */

            $"GRV SORT: {REG_SVA5437B.SVA_TP_ARQSAIDA}/{REG_SVA5437B.SVA_NRCERTIF}/{REG_SVA5437B.SVA_JDE}"
            .Display();

            /*" -2762- RELEASE REG-SVA5437B. */
            SVA5437B.Release(REG_SVA5437B);

            /*" -2762- ADD 1 TO AC-GRAV-SORT. */
            AREA_DE_WORK.AC_GRAV_SORT.Value = AREA_DE_WORK.AC_GRAV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-DB-SELECT-1 */
        public void R1000_00_PROCESSA_INPUT_DB_SELECT_1()
        {
            /*" -2539- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-DUPLICADO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_OPERACAO = :RELATORI-COD-OPERACAO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO-15D AND SIT_REGISTRO = '0' AND TIMESTAMP < :RELATORI-TIMESTAMP WITH UR END-EXEC */

            var r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO_15D = SISTEMAS_DATA_MOV_ABERTO_15D.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_TIMESTAMP = RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_INPUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DUPLICADO, WS_DUPLICADO);
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-3 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_3()
        {
            /*" -2419- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-DB-SELECT-2 */
        public void R1000_00_PROCESSA_INPUT_DB_SELECT_2()
        {
            /*" -2669- EXEC SQL SELECT YEAR(CURRENT_DATE - DATE(:CLIENTES-DATA-NASCIMENTO)) INTO :WS-IDADE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1()
            {
                CLIENTES_DATA_NASCIMENTO = CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_INPUT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_IDADE, AREA_DE_WORK.WS_IDADE);
            }


        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -2766- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-SECTION */
        private void R1010_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -2776- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -2778- MOVE 'S' TO WTEM-SEGURVGA */
            _.Move("S", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -2800- PERFORM R1010_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1010_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -2803- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2804- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2805- MOVE 'N' TO WTEM-SEGURVGA */
                    _.Move("N", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -2806- ELSE */
                }
                else
                {


                    /*" -2808- DISPLAY '*** VA5437B PROBLEMAS ACESSO SEGURADOS_VGAP ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA5437B PROBLEMAS ACESSO SEGURADOS_VGAP {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2809- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2810- END-IF */
                }


                /*" -2810- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1010_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -2800- EXEC SQL SELECT SIT_REGISTRO, COD_CLIENTE, DATA_INIVIGENCIA, DATA_INIVIGENCIA + :PRODUVG-PERI-PAGAMENTO MONTHS, COD_SUBGRUPO, OCORR_ENDERECO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-DATA-INIVIGENCIA, :WHOST-DATA-TERVIG-PREMIO, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC */

            var r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
            };

            var executed_1 = R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(executed_1.WHOST_DATA_TERVIG_PREMIO, WHOST_DATA_TERVIG_PREMIO);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1015-00-SELECT-SEGURVGA-HIST-SECTION */
        private void R1015_00_SELECT_SEGURVGA_HIST_SECTION()
        {
            /*" -2821- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", WABEND.WNR_EXEC_SQL);

            /*" -2831- PERFORM R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1 */

            R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1();

            /*" -2834- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2836- DISPLAY '*** VA5437B PROBLEMAS ACESSO SEGURADOS_HIST ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"*** VA5437B PROBLEMAS ACESSO SEGURADOS_HIST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2837- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2837- END-IF. */
            }


        }

        [StopWatch]
        /*" R1015-00-SELECT-SEGURVGA-HIST-DB-SELECT-1 */
        public void R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1()
        {
            /*" -2831- EXEC SQL SELECT VALUE(MIN(DATA_OPERACAO), :SEGURVGA-DATA-INIVIGENCIA) INTO :SEGURVGA-DATA-INIVIGENCIA FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND COD_OPERACAO = 101 WITH UR END-EXEC */

            var r1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1 = new R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1()
            {
                SEGURVGA_DATA_INIVIGENCIA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1.Execute(r1015_00_SELECT_SEGURVGA_HIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1015_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-OPCPAGVI-SECTION */
        private void R1100_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -2848- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -2850- MOVE 'S' TO WTEM-OPCPAGVI. */
            _.Move("S", AREA_DE_WORK.WTEM_OPCPAGVI);

            /*" -2871- PERFORM R1100_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1100_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -2874- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2875- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2876- MOVE 'N' TO WTEM-OPCPAGVI */
                    _.Move("N", AREA_DE_WORK.WTEM_OPCPAGVI);

                    /*" -2877- ELSE */
                }
                else
                {


                    /*" -2878- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -2879- MOVE 'N' TO WTEM-OPCPAGVI */
                        _.Move("N", AREA_DE_WORK.WTEM_OPCPAGVI);

                        /*" -2880- ELSE */
                    }
                    else
                    {


                        /*" -2882- DISPLAY 'VA5437B PROBLEMAS NO ACESSO A V0OPCAOPAG ' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"VA5437B PROBLEMAS NO ACESSO A V0OPCAOPAG {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -2883- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2884- END-IF */
                    }


                    /*" -2885- END-IF */
                }


                /*" -2885- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R1100_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -2871- EXEC SQL SELECT OPCAO_PAGAMENTO, DIA_DEBITO, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, PERI_PAGAMENTO, DATA_INIVIGENCIA INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-DIA-DEBITO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB, :OPCPAGVI-PERI-PAGAMENTO, :OPCPAGVI-DATA-INIVIGENCIA FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DATA_INIVIGENCIA, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-SECTION */
        private void R1120_00_DECLARE_TITFEDCA_SECTION()
        {
            /*" -2896- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", WABEND.WNR_EXEC_SQL);

            /*" -2897- MOVE 'N' TO WFIM-TITFEDCA */
            _.Move("N", AREA_DE_WORK.WFIM_TITFEDCA);

            /*" -2904- MOVE ZEROS TO WINDC SVA-NRSORTE(1) SVA-NRSORTE(2) SVA-NRSORTE(3) SVA-NRSORTE(4) SVA-NRSORTE(5) */
            _.Move(0, WINDC);
            _.Move(0, REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[1]);
            _.Move(0, REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[2]);
            _.Move(0, REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[3]);
            _.Move(0, REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[4]);
            _.Move(0, REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[5]);


            /*" -2912- PERFORM R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1 */

            R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1();

            /*" -2921- PERFORM R1120_00_DECLARE_TITFEDCA_DB_OPEN_1 */

            R1120_00_DECLARE_TITFEDCA_DB_OPEN_1();

            /*" -2924- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2925- DISPLAY 'VA5437B - ERRO OPEN CURSOR CTITFEDCA ' */
                _.Display($"VA5437B - ERRO OPEN CURSOR CTITFEDCA ");

                /*" -2926- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2927- DISPLAY 'CERTIF  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIF  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2927- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-DB-OPEN-1 */
        public void R1120_00_DECLARE_TITFEDCA_DB_OPEN_1()
        {
            /*" -2921- EXEC SQL OPEN CTITFEDCA END-EXEC. */

            CTITFEDCA.Open();

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-DECLARE-1 */
        public void R2400_00_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -4645- EXEC SQL DECLARE V0BENEF CURSOR FOR SELECT NOME_BENEFICIARIO, GRAU_PARENTESCO, PCT_PART_BENEFICIA FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */
            V0BENEF = new VA5437B_V0BENEF(true);
            string GetQuery_V0BENEF()
            {
                var query = @$"SELECT NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA 
							FROM SEGUROS.BENEFICIARIOS 
							WHERE NUM_CERTIFICADO = '{WHOST_NRCERTIF}' 
							AND DATA_TERVIGENCIA IN ( '1999-12-31'
							, '9999-12-31' )";

                return query;
            }
            V0BENEF.GetQueryEvent += GetQuery_V0BENEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-SECTION */
        private void R1130_00_FETCH_TITFEDCA_SECTION()
        {
            /*" -2938- MOVE '1130' TO WNR-EXEC-SQL. */
            _.Move("1130", WABEND.WNR_EXEC_SQL);

            /*" -2940- MOVE 'N' TO WFIM-TITFEDCA */
            _.Move("N", AREA_DE_WORK.WFIM_TITFEDCA);

            /*" -2943- PERFORM R1130_00_FETCH_TITFEDCA_DB_FETCH_1 */

            R1130_00_FETCH_TITFEDCA_DB_FETCH_1();

            /*" -2946- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2947- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2948- MOVE 'S' TO WFIM-TITFEDCA */
                    _.Move("S", AREA_DE_WORK.WFIM_TITFEDCA);

                    /*" -2948- PERFORM R1130_00_FETCH_TITFEDCA_DB_CLOSE_1 */

                    R1130_00_FETCH_TITFEDCA_DB_CLOSE_1();

                    /*" -2950- ELSE */
                }
                else
                {


                    /*" -2952- DISPLAY '*** VA5437B PROBLEMAS NO FETCH CTITFEDCA     ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA5437B PROBLEMAS NO FETCH CTITFEDCA     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2952- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-DB-FETCH-1 */
        public void R1130_00_FETCH_TITFEDCA_DB_FETCH_1()
        {
            /*" -2943- EXEC SQL FETCH CTITFEDCA INTO :TITFEDCA-NRTITFDCAP, :TITFEDCA-NRSORTEIO END-EXEC. */

            if (CTITFEDCA.Fetch())
            {
                _.Move(CTITFEDCA.TITFEDCA_NRTITFDCAP, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP);
                _.Move(CTITFEDCA.TITFEDCA_NRSORTEIO, TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO);
            }

        }

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-DB-CLOSE-1 */
        public void R1130_00_FETCH_TITFEDCA_DB_CLOSE_1()
        {
            /*" -2948- EXEC SQL CLOSE CTITFEDCA END-EXEC */

            CTITFEDCA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-PROCESSA-TITFEDCA-SECTION */
        private void R1140_00_PROCESSA_TITFEDCA_SECTION()
        {
            /*" -2963- MOVE '1140' TO WNR-EXEC-SQL. */
            _.Move("1140", WABEND.WNR_EXEC_SQL);

            /*" -2964- MOVE TITFEDCA-NRTITFDCAP TO WS-NRTITFDCAP */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP, AREA_DE_WORK.WS_NRTITFDCAP);

            /*" -2967- MOVE WS-NRTITFDCAP(1:3) TO SVA-NUM-PLANO FCPROSUS-NUM-PLANO */
            _.Move(AREA_DE_WORK.WS_NRTITFDCAP.Substring(1, 3), REG_SVA5437B.SVA_NUM_PLANO, FCPROSUS.DCLFC_PROCESSO_SUSEP.FCPROSUS_NUM_PLANO);

            /*" -2968- PERFORM R1145-00-SELECT-PROC-SUSEP-CAP */

            R1145_00_SELECT_PROC_SUSEP_CAP_SECTION();

            /*" -2970- MOVE FCPROSUS-COD-PROCESSO-SUSEP TO SVA-COD-SUSEP-CAP */
            _.Move(FCPROSUS.DCLFC_PROCESSO_SUSEP.FCPROSUS_COD_PROCESSO_SUSEP, REG_SVA5437B.SVA_COD_SUSEP_CAP);

            /*" -2971- IF (TITFEDCA-NRSORTEIO NOT EQUAL WS-NRSORTEIO-ANT) */

            if ((TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO != AREA_DE_WORK.WS_NRSORTEIO_ANT))
            {

                /*" -2972- ADD 1 TO WINDC */
                WINDC.Value = WINDC + 1;

                /*" -2973- MOVE TITFEDCA-NRSORTEIO TO SVA-NRSORTE(WINDC) */
                _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO, REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[WINDC]);

                /*" -2975- END-IF */
            }


            /*" -2977- MOVE TITFEDCA-NRSORTEIO TO WS-NRSORTEIO-ANT */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO, AREA_DE_WORK.WS_NRSORTEIO_ANT);

            /*" -2977- PERFORM R1130-00-FETCH-TITFEDCA. */

            R1130_00_FETCH_TITFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1145-00-SELECT-PROC-SUSEP-CAP-SECTION */
        private void R1145_00_SELECT_PROC_SUSEP_CAP_SECTION()
        {
            /*" -2988- MOVE '1145' TO WNR-EXEC-SQL. */
            _.Move("1145", WABEND.WNR_EXEC_SQL);

            /*" -2994- PERFORM R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1 */

            R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1();

            /*" -2997- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2999- DISPLAY '*** VA5437B PROBLEMAS ACESSO PROC SUSEP CAP ' FCPROSUS-NUM-PLANO */
                _.Display($"*** VA5437B PROBLEMAS ACESSO PROC SUSEP CAP {FCPROSUS.DCLFC_PROCESSO_SUSEP.FCPROSUS_NUM_PLANO}");

                /*" -3000- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3001- END-IF. */
            }


        }

        [StopWatch]
        /*" R1145-00-SELECT-PROC-SUSEP-CAP-DB-SELECT-1 */
        public void R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1()
        {
            /*" -2994- EXEC SQL SELECT VALUE(COD_PROCESSO_SUSEP, '********************' ) INTO :FCPROSUS-COD-PROCESSO-SUSEP FROM FDRCAP.FC_PROCESSO_SUSEP WHERE NUM_PLANO = :FCPROSUS-NUM-PLANO WITH UR END-EXEC. */

            var r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 = new R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1()
            {
                FCPROSUS_NUM_PLANO = FCPROSUS.DCLFC_PROCESSO_SUSEP.FCPROSUS_NUM_PLANO.ToString(),
            };

            var executed_1 = R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1.Execute(r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCPROSUS_COD_PROCESSO_SUSEP, FCPROSUS.DCLFC_PROCESSO_SUSEP.FCPROSUS_COD_PROCESSO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1145_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-SECTION */
        private void R1200_00_SELECT_CLIENTES_SECTION()
        {
            /*" -3011- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -3013- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -3025- PERFORM R1200_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1200_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -3028- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3029- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3030- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -3031- ELSE */
                }
                else
                {


                    /*" -3033- DISPLAY '*** VA5437B PROBLEMAS NO ACESSO A CLIENTES   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA5437B PROBLEMAS NO ACESSO A CLIENTES   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3035- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3036- IF VIND-SEXO LESS 0 */

            if (VIND_SEXO < 0)
            {

                /*" -3039- MOVE ' ' TO CLIENTES-IDE-SEXO. */
                _.Move(" ", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


            /*" -3040- IF VIND-DTNASC LESS +0 */

            if (VIND_DTNASC < +0)
            {

                /*" -3042- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -3042- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1200_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -3025- EXEC SQL SELECT NOME_RAZAO, CGCCPF, IDE_SEXO, DATA_NASCIMENTO INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-IDE-SEXO:VIND-SEXO, :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

            var r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_IDE_SEXO, CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1250-00-CALCULA-IDADE-CLIENTE-SECTION */
        private void R1250_00_CALCULA_IDADE_CLIENTE_SECTION()
        {
            /*" -3054- MOVE '1250' TO WNR-EXEC-SQL. */
            _.Move("1250", WABEND.WNR_EXEC_SQL);

            /*" -3055- IF (SVA-PERI-PAGAMENTO EQUAL ZEROS) */

            if ((REG_SVA5437B.SVA_PERI_PAGAMENTO == 00))
            {

                /*" -3056- PERFORM R2051-00-SELECT-PROP-FIDELIZ-1 */

                R2051_00_SELECT_PROP_FIDELIZ_1_SECTION();

                /*" -3057- MOVE PROPOFID-DATA-PROPOSTA TO WS-DATA-OPER-CORR-MONET */
                _.Move(AREA_DE_WORK.PROPOFID_DATA_PROPOSTA, WS_DATA_OPER_CORR_MONET);

                /*" -3058- ELSE */
            }
            else
            {


                /*" -3060- PERFORM R1350-00-SELECT-CORREC-MONET */

                R1350_00_SELECT_CORREC_MONET_SECTION();

                /*" -3061- MOVE SVA-DTPROXVEN(9:2) TO WS-DIA-9 */
                _.Move(REG_SVA5437B.SVA_DTPROXVEN.Substring(9, 2), AREA_DE_WORK.WS_DIA_9);

                /*" -3063- MOVE WS-DIA-X TO WS-DATA-OPER-CORR-MONET(9:2) */
                _.MoveAtPosition(AREA_DE_WORK.WS_DIA_X, WS_DATA_OPER_CORR_MONET, 9, 2);

                /*" -3066- IF (WS-DIA-9 > 30) AND (WS-DATA-OPER-CORR-MONET(06:02) EQUAL '04' OR '06' OR '09' OR '11' ) */

                if ((AREA_DE_WORK.WS_DIA_9 > 30) && (WS_DATA_OPER_CORR_MONET.Substring(06, 02).In("04", "06", "09", "11")))
                {

                    /*" -3067- MOVE '30' TO WS-DATA-OPER-CORR-MONET(09:02) */
                    _.MoveAtPosition("30", WS_DATA_OPER_CORR_MONET, 9, 2);

                    /*" -3069- END-IF */
                }


                /*" -3071- IF (WS-DIA-9 > 28) AND (WS-DATA-OPER-CORR-MONET(06:02) EQUAL '02' ) */

                if ((AREA_DE_WORK.WS_DIA_9 > 28) && (WS_DATA_OPER_CORR_MONET.Substring(06, 02) == "02"))
                {

                    /*" -3072- MOVE '28' TO WS-DATA-OPER-CORR-MONET(09:02) */
                    _.MoveAtPosition("28", WS_DATA_OPER_CORR_MONET, 9, 2);

                    /*" -3073- END-IF */
                }


                /*" -3075- END-IF */
            }


            /*" -3077- MOVE SVA-CODCLIEN TO SEGURVGA-COD-CLIENTE */
            _.Move(REG_SVA5437B.SVA_CODCLIEN, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);

            /*" -3084- PERFORM R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1 */

            R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1();

            /*" -3087- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3089- DISPLAY '*** VA5437B PROBLEMAS NO ACESSO A CLIENTES   ' SEGURVGA-COD-CLIENTE */
                _.Display($"*** VA5437B PROBLEMAS NO ACESSO A CLIENTES   {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE}");

                /*" -3090- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3095- END-IF. */
            }


        }

        [StopWatch]
        /*" R1250-00-CALCULA-IDADE-CLIENTE-DB-SELECT-1 */
        public void R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1()
        {
            /*" -3084- EXEC SQL SELECT YEAR(DATE(:WS-DATA-OPER-CORR-MONET) - DATE(VALUE(DATA_NASCIMENTO, CURRENT_DATE))) INTO :WS-IDADE FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE WITH UR END-EXEC. */

            var r1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1 = new R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1()
            {
                WS_DATA_OPER_CORR_MONET = WS_DATA_OPER_CORR_MONET.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1.Execute(r1250_00_CALCULA_IDADE_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_IDADE, AREA_DE_WORK.WS_IDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1250_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-EMAIL-SECTION */
        private void R1210_00_SELECT_EMAIL_SECTION()
        {
            /*" -3105- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -3111- PERFORM R1210_00_SELECT_EMAIL_DB_SELECT_1 */

            R1210_00_SELECT_EMAIL_DB_SELECT_1();

            /*" -3114- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3115- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3116- MOVE SPACES TO CLIENEMA-EMAIL */
                    _.Move("", CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

                    /*" -3117- ELSE */
                }
                else
                {


                    /*" -3119- DISPLAY '*** VA5437B PROBLEMAS NO ACESSO CLIENTE_EMAIL' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA5437B PROBLEMAS NO ACESSO CLIENTE_EMAIL{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3119- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-EMAIL-DB-SELECT-1 */
        public void R1210_00_SELECT_EMAIL_DB_SELECT_1()
        {
            /*" -3111- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

            var r1210_00_SELECT_EMAIL_DB_SELECT_1_Query1 = new R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1210_00_SELECT_EMAIL_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-SECTION */
        private void R1300_00_SELECT_ENDERECO_SECTION()
        {
            /*" -3130- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -3132- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDERECO);

            /*" -3150- PERFORM R1300_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -3153- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3154- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3155- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                    /*" -3156- ELSE */
                }
                else
                {


                    /*" -3158- DISPLAY '*** VA5437B PROBLEMAS NO ACESSO A ENDERECOS' PROPOVA-NUM-CERTIFICADO ' ' SEGURVGA-COD-CLIENTE */

                    $"*** VA5437B PROBLEMAS NO ACESSO A ENDERECOS{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE}"
                    .Display();

                    /*" -3158- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -3150- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE AND OCORR_ENDERECO = :WHOST-OCOREND WITH UR END-EXEC. */

            var r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                WHOST_OCOREND = WHOST_OCOREND.ToString(),
            };

            var executed_1 = R1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1350-00-SELECT-CORREC-MONET-SECTION */
        private void R1350_00_SELECT_CORREC_MONET_SECTION()
        {
            /*" -3169- MOVE 'R1350' TO WNR-EXEC-SQL. */
            _.Move("R1350", WABEND.WNR_EXEC_SQL);

            /*" -3170- MOVE SVA-NRCERTIF TO PROPOVA-NUM-CERTIFICADO */
            _.Move(REG_SVA5437B.SVA_NRCERTIF, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -3171- MOVE SVA-PERI-PAGAMENTO TO OPCPAGVI-PERI-PAGAMENTO */
            _.Move(REG_SVA5437B.SVA_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);

            /*" -3173- MOVE SVA-DTINIVIG-OPCPAG TO OPCPAGVI-DATA-INIVIGENCIA */
            _.Move(REG_SVA5437B.SVA_DTINIVIG_OPCPAG, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA);

            /*" -3181- PERFORM R1350_00_SELECT_CORREC_MONET_DB_SELECT_1 */

            R1350_00_SELECT_CORREC_MONET_DB_SELECT_1();

            /*" -3184- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3185- DISPLAY 'R1350-ERRO NO R1350-00-CORREC-MONET ' */
                _.Display($"R1350-ERRO NO R1350-00-CORREC-MONET ");

                /*" -3186- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3186- END-IF. */
            }


        }

        [StopWatch]
        /*" R1350-00-SELECT-CORREC-MONET-DB-SELECT-1 */
        public void R1350_00_SELECT_CORREC_MONET_DB_SELECT_1()
        {
            /*" -3181- EXEC SQL SELECT VALUE(MAX(DATA_OPERACAO),:OPCPAGVI-DATA-INIVIGENCIA) + :OPCPAGVI-PERI-PAGAMENTO MONTH INTO :WS-DATA-OPER-CORR-MONET FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_OPERACAO IN (101, 895) WITH UR END-EXEC. */

            var r1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1 = new R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1()
            {
                OPCPAGVI_DATA_INIVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_INIVIGENCIA.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                OPCPAGVI_PERI_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO.ToString(),
            };

            var executed_1 = R1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1.Execute(r1350_00_SELECT_CORREC_MONET_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_OPER_CORR_MONET, WS_DATA_OPER_CORR_MONET);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1350_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-SECTION */
        private void R1400_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -3196- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -3198- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -3217- PERFORM R1400_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1400_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -3220- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3221- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3222- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -3223- ELSE */
                }
                else
                {


                    /*" -3225- DISPLAY 'VA5437B PROBLEMAS ACESSO HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"VA5437B PROBLEMAS ACESSO HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -3225- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1400_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -3217- EXEC SQL SELECT DATA_INIVIGENCIA, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPSEGCDG, VLPREMIO, VAL_CUSTO_CAPITALI INTO :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLPREMIO, :HISCOBPR-VAL-CUSTO-CAPITALI FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_COD_OPERACAO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_OPERACAO);
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(executed_1.HISCOBPR_IMPSEGCDG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_VAL_CUSTO_CAPITALI, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-SECTION */
        private void R1500_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -3236- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -3246- PERFORM R1500_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R1500_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -3249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3250- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3251- MOVE PROPOVA-COD-FONTE TO MALHACEF-COD-FONTE */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -3252- ELSE */
                }
                else
                {


                    /*" -3253- DISPLAY 'R1500 - PROBLEMAS SELECT AGENCIAS_CEF ' */
                    _.Display($"R1500 - PROBLEMAS SELECT AGENCIAS_CEF ");

                    /*" -3254- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -3255- DISPLAY 'AGE COBR- ' PROPOVA-AGE-COBRANCA */
                    _.Display($"AGE COBR- {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA}");

                    /*" -3255- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -3246- EXEC SQL SELECT B.COD_FONTE INTO :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :PROPOVA-AGE-COBRANCA WITH UR END-EXEC. */

            var r1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                PROPOVA_AGE_COBRANCA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA.ToString(),
            };

            var executed_1 = R1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-APOLICE-SECTION */
        private void R1600_00_SELECT_APOLICE_SECTION()
        {
            /*" -3266- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -3275- PERFORM R1600_00_SELECT_APOLICE_DB_SELECT_1 */

            R1600_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -3278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3279- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3280- DISPLAY 'APOLICE NAO CADASTRADA ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE NAO CADASTRADA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -3281- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3282- ELSE */
                }
                else
                {


                    /*" -3284- DISPLAY 'R1600 - PROBLEMAS SELECT APOLICES  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1600 - PROBLEMAS SELECT APOLICES  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -3284- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R1600_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -3275- EXEC SQL SELECT COD_CLIENTE, RAMO_EMISSOR INTO :APOLICES-COD-CLIENTE, :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE WITH UR END-EXEC. */

            var r1600_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1600_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1640-00-SELECT-ENDOSSOS-SECTION */
        private void R1640_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -3295- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", WABEND.WNR_EXEC_SQL);

            /*" -3306- PERFORM R1640_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1640_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -3309- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3310- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3311- DISPLAY 'ENDOSSO NAO CADASTRAD0 ' PROPOVA-NUM-APOLICE */
                    _.Display($"ENDOSSO NAO CADASTRAD0 {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -3312- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3313- ELSE */
                }
                else
                {


                    /*" -3315- DISPLAY 'R1640 - PROBLEMAS SELECT ENDOSSOS  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1640 - PROBLEMAS SELECT ENDOSSOS  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -3315- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1640-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1640_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -3306- EXEC SQL SELECT DATA_INIVIGENCIA, DATA_TERVIGENCIA, DATA_TERVIGENCIA - 1 YEAR INTO :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA-1 FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA_1, ENDOSSOS_DATA_TERVIGENCIA_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -3326- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -3326- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -3334- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -3335- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA5437B.SVA_CEP_G);

                /*" -3336- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA5437B.SVA_NOME_CORREIO);

                /*" -3338- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3339- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -3341- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -3342- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -3344- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -3346- IF ENDERECO-CEP GREATER WS-INF AND ENDERECO-CEP LESS WS-SUP */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP > AREA_DE_WORK.WS_INF && ENDERECO.DCLENDERECOS.ENDERECO_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -3347- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SVA5437B.SVA_CEP_G);

                /*" -3348- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SVA5437B.SVA_NOME_CORREIO);

                /*" -3349- ELSE */
            }
            else
            {


                /*" -3350- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -3350- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-PRIMEIRO-NOME-SECTION */
        private void R1950_00_PRIMEIRO_NOME_SECTION()
        {
            /*" -3361- MOVE '1950' TO WNR-EXEC-SQL. */
            _.Move("1950", WABEND.WNR_EXEC_SQL);

            /*" -3361- MOVE 1 TO WIND-N. */
            _.Move(1, AREA_DE_WORK.WIND_N);

            /*" -0- FLUXCONTROL_PERFORM R1950_10_LOOP */

            R1950_10_LOOP();

        }

        [StopWatch]
        /*" R1950-10-LOOP */
        private void R1950_10_LOOP(bool isPerform = false)
        {
            /*" -3367- IF WIND-N GREATER 40 */

            if (AREA_DE_WORK.WIND_N > 40)
            {

                /*" -3368- DISPLAY '*** VA5437B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA5437B TAB NOMES ESTOURADA ");

                /*" -3370- GO TO R1950-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3372- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 1 */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] == string.Empty && AREA_DE_WORK.WIND_N == 1)
            {

                /*" -3373- ADD 1 TO WIND-N */
                AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                /*" -3374- GO TO R1950-10-LOOP */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3375- ELSE */
            }
            else
            {


                /*" -3378- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 2 */

                if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] == string.Empty && AREA_DE_WORK.WIND_N == 2)
                {

                    /*" -3379- ADD 1 TO WIND-N */
                    AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                    /*" -3381- GO TO R1950-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3382- IF TAB-NOME (WIND-N) NOT EQUAL SPACES */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] != string.Empty)
            {

                /*" -3383- MOVE TAB-NOME (WIND-N) TO TAB-NOME1 (WIND-N) */
                _.Move(TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N], TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[AREA_DE_WORK.WIND_N]);

                /*" -3384- ADD 1 TO WIND-N */
                AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                /*" -3386- GO TO R1950-10-LOOP. */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3386- MOVE ',' TO TAB-NOME1 (WIND-N). */
            _.Move(",", TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[AREA_DE_WORK.WIND_N]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -3397- MOVE '2000' TO WNR-EXEC-SQL */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -3398- MOVE SVA-TP-ARQSAIDA TO WS-TP-ARQSAIDA-ANT */
            _.Move(REG_SVA5437B.SVA_TP_ARQSAIDA, AREA_DE_WORK.WS_TP_ARQSAIDA_ANT);

            /*" -3399- MOVE SVA-JDE TO WS-JDE-ANT */
            _.Move(REG_SVA5437B.SVA_JDE, AREA_DE_WORK.WS_JDE_ANT);

            /*" -3401- MOVE 1 TO WS-IMPRIME-CONTROLES-OK */
            _.Move(1, WS_IMPRIME_CONTROLES_OK);

            /*" -3402- MOVE SPACES TO LC09-LIN09 */
            _.Move("", AREA_DE_WORK.FILLER_11.LC09_LIN09);

            /*" -3404- MOVE FUNCTION LOWER-CASE(SVA-JDE) TO WS-JDE-TFORM */
            _.Move(REG_SVA5437B.SVA_JDE.ToString().ToLower(), AREA_DE_WORK.WS_JDE_TFORM);

            /*" -3431- STRING '(' WS-JDE-TFORM DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LIN09. */
            #region STRING
            var spl13 = "(" + AREA_DE_WORK.WS_JDE_TFORM.GetMoveValues().Split(" ").FirstOrDefault();
            spl13 += ".DBM".ToString().ToLower();
            spl13 += ") STARTDBM";
            spl13 += "(";
            var spl14 = AREA_DE_WORK.WS_JDE_TFORM.GetMoveValues();
            spl14 += ".DBM".ToString().ToLower();
            spl14 += ") STARTDBM";
            var results15 = spl13 + spl14;
            _.Move(results15, AREA_DE_WORK.FILLER_11.LC09_LIN09);
            #endregion

            /*" -3438- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-TP-ARQSAIDA NOT EQUAL WS-TP-ARQSAIDA-ANT OR SVA-JDE NOT EQUAL WS-JDE-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA5437B.SVA_TP_ARQSAIDA != AREA_DE_WORK.WS_TP_ARQSAIDA_ANT || REG_SVA5437B.SVA_JDE != AREA_DE_WORK.WS_JDE_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

            /*" -3439- MOVE 12 TO WS-LINHAS-UNIC */
            _.Move(12, WS_LINHAS_UNIC);

            /*" -3439- PERFORM R9155-00-GRAVA-LINHAS-UNIC. */

            R9155_00_GRAVA_LINHAS_UNIC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -3451- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", WABEND.WNR_EXEC_SQL);

            /*" -3454- MOVE SVA-TP-ARQSAIDA TO WS-TP-ARQSAIDA-ANT WS-TIPO-ARQ-SAIDA */
            _.Move(REG_SVA5437B.SVA_TP_ARQSAIDA, AREA_DE_WORK.WS_TP_ARQSAIDA_ANT, WS_TIPO_ARQ_SAIDA);

            /*" -3458- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT WHOST-NRAPOLICE */
            _.Move(REG_SVA5437B.SVA_NRAPOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, WHOST_NRAPOLICE);

            /*" -3461- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT WHOST-CODSUBES */
            _.Move(REG_SVA5437B.SVA_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, WHOST_CODSUBES);

            /*" -3463- MOVE SVA-DTQUIT TO WHOST-DTQUIT */
            _.Move(REG_SVA5437B.SVA_DTQUIT, WHOST_DTQUIT);

            /*" -3465- PERFORM R2710-00-SELECT-ESTIP */

            R2710_00_SELECT_ESTIP_SECTION();

            /*" -3467- MOVE CLIENTES-NOME-RAZAO TO LC11-ESTIPULANTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_ESTIPULANTE);

            /*" -3471- PERFORM R2715-00-SELECT-SUBESTIP */

            R2715_00_SELECT_SUBESTIP_SECTION();

            /*" -3472- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SQL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3473- MOVE WS-ANO-SQL TO LK-ANO-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -3474- MOVE WS-MES-SQL TO LK-MES-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -3476- MOVE WS-DIA-SQL TO LK-DIA-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

            /*" -3478- PERFORM R2920-00-CALC-DIAS-UTEIS */

            R2920_00_CALC_DIAS_UTEIS_SECTION();

            /*" -3479- MOVE LK-DIA-CALC TO WS-DIA-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3480- MOVE LK-MES-CALC TO WS-MES-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3481- MOVE LK-ANO-CALC TO WS-ANO-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3484- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -3486- MOVE WS-DATA-I TO LC11-DTPOSTAGEM. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTPOSTAGEM);

            /*" -3488- PERFORM R2910-00-OBTEM-NUMERACAO */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -3491- PERFORM R2700-00-SELECT-PRODUVG */

            R2700_00_SELECT_PRODUVG_SECTION();

            /*" -3492- PERFORM R2760-00-SELECT-PRODUTO */

            R2760_00_SELECT_PRODUTO_SECTION();

            /*" -3493- MOVE SPACES TO LC11-COD-SUSEP */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEP);

            /*" -3495- MOVE PRODUTO-NUM-PROCESSO-SUSEP TO LC11-COD-SUSEP */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEP);

            /*" -3501- MOVE PRODUTO-DESCR-PRODUTO TO LC11-NOME-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_PRODUTO);

            /*" -3502- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVA5437B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -3503- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVA5437B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -3506- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -3508- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVA5437B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3511- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVA5437B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3511- PERFORM R2100-00-PROCESSA-CEP. */

            R2100_00_PROCESSA_CEP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2051-00-SELECT-PROP-FIDELIZ-1-SECTION */
        private void R2051_00_SELECT_PROP_FIDELIZ_1_SECTION()
        {
            /*" -3529- MOVE '2051' TO WNR-EXEC-SQL. */
            _.Move("2051", WABEND.WNR_EXEC_SQL);

            /*" -3536- PERFORM R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1 */

            R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1();

            /*" -3539- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3540- DISPLAY 'R2051-ERRO CONSULTA TAB. PROPOSTA-FIDELIZ' */
                _.Display($"R2051-ERRO CONSULTA TAB. PROPOSTA-FIDELIZ");

                /*" -3541- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3542- ELSE */
            }
            else
            {


                /*" -3543- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -3544- PERFORM R2052-00-SELECT-PROP-FIDELIZ-2 */

                    R2052_00_SELECT_PROP_FIDELIZ_2_SECTION();

                    /*" -3545- END-IF */
                }


                /*" -3545- END-IF. */
            }


        }

        [StopWatch]
        /*" R2051-00-SELECT-PROP-FIDELIZ-1-DB-SELECT-1 */
        public void R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1()
        {
            /*" -3536- EXEC SQL SELECT VALUE(DATA_PROPOSTA, :SVA-DTQUIT) INTO :PROPOFID-DATA-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :WHOST-NRCERTIF FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1_Query1 = new R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                SVA_DTQUIT = REG_SVA5437B.SVA_DTQUIT.ToString(),
            };

            var executed_1 = R2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1_Query1.Execute(r2051_00_SELECT_PROP_FIDELIZ_1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, AREA_DE_WORK.PROPOFID_DATA_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2051_99_SAIDA*/

        [StopWatch]
        /*" R2052-00-SELECT-PROP-FIDELIZ-2-SECTION */
        private void R2052_00_SELECT_PROP_FIDELIZ_2_SECTION()
        {
            /*" -3556- MOVE '2052' TO WNR-EXEC-SQL. */
            _.Move("2052", WABEND.WNR_EXEC_SQL);

            /*" -3563- PERFORM R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1 */

            R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1();

            /*" -3566- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3567- DISPLAY 'R2052-ERRO CONSULTA TAB. PROPOSTA-FIDELIZ' */
                _.Display($"R2052-ERRO CONSULTA TAB. PROPOSTA-FIDELIZ");

                /*" -3568- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3568- END-IF. */
            }


        }

        [StopWatch]
        /*" R2052-00-SELECT-PROP-FIDELIZ-2-DB-SELECT-1 */
        public void R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1()
        {
            /*" -3563- EXEC SQL SELECT VALUE(DATA_PROPOSTA, :SVA-DTQUIT) INTO :PROPOFID-DATA-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :WHOST-NRCERTIF FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var r2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1 = new R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
                SVA_DTQUIT = REG_SVA5437B.SVA_DTQUIT.ToString(),
            };

            var executed_1 = R2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1.Execute(r2052_00_SELECT_PROP_FIDELIZ_2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, AREA_DE_WORK.PROPOFID_DATA_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2052_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -3579- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -3583- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -3584- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE. */
            _.Move(REG_SVA5437B.SVA_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);

            /*" -3585- MOVE SVA-CODSUBES TO WS-CODSUBES. */
            _.Move(REG_SVA5437B.SVA_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);

            /*" -3591- MOVE SVA-CODOPER TO WS-OPER-ANT WHOST-CODOPER WS-CODOPER */
            _.Move(REG_SVA5437B.SVA_CODOPER, AREA_DE_WORK.WS_OPER_ANT, WHOST_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);

            /*" -3594- MOVE SVA-PRODUTO TO W88-PRODUTO-VIDA WS-COD-PRODUTO-ED WS-COD-PRODUTO. */
            _.Move(REG_SVA5437B.SVA_PRODUTO, W88_PRODUTO_VIDA, WS_COD_PRODUTO_ED, WS_COD_PRODUTO);

            /*" -3595- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -3598- PERFORM R2320-PRODUTO-RUNOFF */

            R2320_PRODUTO_RUNOFF_SECTION();

            /*" -3600- MOVE SVA-NRCERTIF TO WS-SALVA-CERTIF */
            _.Move(REG_SVA5437B.SVA_NRCERTIF, AREA_DE_WORK.WS_SALVA_CERTIF);

            /*" -3600- PERFORM R2200-00-PROCESSA-FAC. */

            R2200_00_PROCESSA_FAC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -3627- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -3628- MOVE SVA-NRAPOLICE TO LC11-APOLICE */
            _.Move(REG_SVA5437B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE);

            /*" -3629- MOVE SVA-RENDA-IND TO LC11-RENDA-IND */
            _.Move(REG_SVA5437B.SVA_RENDA_IND, AREA_DE_WORK.LC11_LINHA11.LC11_RENDA_IND);

            /*" -3630- MOVE SVA-RENDA-FAM TO LC11-RENDA-FAM */
            _.Move(REG_SVA5437B.SVA_RENDA_FAM, AREA_DE_WORK.LC11_LINHA11.LC11_RENDA_FAM);

            /*" -3631- MOVE SVA-EMAIL TO LC11-EMAIL */
            _.Move(REG_SVA5437B.SVA_EMAIL, AREA_DE_WORK.LC11_LINHA11.LC11_EMAIL);

            /*" -3632- MOVE SVA-IDSEXO TO LC11-SEXO */
            _.Move(REG_SVA5437B.SVA_IDSEXO, AREA_DE_WORK.LC11_LINHA11.LC11_SEXO);

            /*" -3634- MOVE SVA-PRODUTO TO LC11-COD-PRODUTO */
            _.Move(REG_SVA5437B.SVA_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LC11_COD_PRODUTO);

            /*" -3636- MOVE SPACES TO LC11-COD-SUSEPCAP */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEPCAP);

            /*" -3638- INITIALIZE LC11-SORTE */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_SORTE
            );

            /*" -3639- IF (SVA-NRSORTE-RED EQUAL 'Nao contempla' OR 'Não contempla' ) */

            if ((REG_SVA5437B.SVA_NRSORTE_RED.In("Nao contempla", "Não contempla")))
            {

                /*" -3640- MOVE SVA-NRSORTE-RED TO LC11-NRSORTE-RED */
                _.Move(REG_SVA5437B.SVA_NRSORTE_RED, AREA_DE_WORK.LC11_LINHA11.LC11_NRSORTE_RED);

                /*" -3641- MOVE 'N�o se aplica' TO LC11-COD-SUSEPCAP */
                _.Move("N�o se aplica", AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEPCAP);

                /*" -3642- ELSE */
            }
            else
            {


                /*" -3643- MOVE SVA-COD-SUSEP-CAP TO LC11-COD-SUSEPCAP */
                _.Move(REG_SVA5437B.SVA_COD_SUSEP_CAP, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEPCAP);

                /*" -3649- MOVE SPACES TO LC11-NRSORTE(1) LC11-NRSORTE-S(1) LC11-NRSORTE(2) LC11-NRSORTE-S(2) LC11-NRSORTE(3) LC11-NRSORTE-S(3) LC11-NRSORTE(4) LC11-NRSORTE-S(4) LC11-NRSORTE(5) LC11-NRSORTE-S(5) */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[1].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[1].LC11_NRSORTE_S, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[2].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[2].LC11_NRSORTE_S, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[3].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[3].LC11_NRSORTE_S, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[4].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[4].LC11_NRSORTE_S, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[5].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[5].LC11_NRSORTE_S);

                /*" -3650- IF (SVA-NRSORTE-RED EQUAL SPACES) */

                if ((REG_SVA5437B.SVA_NRSORTE_RED.IsEmpty()))
                {

                    /*" -3651- MOVE 'N� de sorteio inativo' TO LC11-NRSORTE-RED */
                    _.Move("N� de sorteio inativo", AREA_DE_WORK.LC11_LINHA11.LC11_NRSORTE_RED);

                    /*" -3653- ELSE */
                }
                else
                {


                    /*" -3654- IF (SVA-NUM-PLANO GREATER ZEROS) */

                    if ((REG_SVA5437B.SVA_NUM_PLANO > 00))
                    {

                        /*" -3655- MOVE TAB-QTD-DIG(SVA-NUM-PLANO) TO I2 */
                        _.Move(TAB_QTD_DIG_COMBINACAO.TAB_COMB[REG_SVA5437B.SVA_NUM_PLANO].TAB_QTD_DIG, I2);

                        /*" -3657- SUBTRACT TAB-QTD-DIG(SVA-NUM-PLANO) FROM 9 GIVING WPI */
                        WPI.Value = 9 - TAB_QTD_DIG_COMBINACAO.TAB_COMB[REG_SVA5437B.SVA_NUM_PLANO].TAB_QTD_DIG;

                        /*" -3658- ADD 1 TO WPI */
                        WPI.Value = WPI + 1;

                        /*" -3660- MOVE 1 TO I1 */
                        _.Move(1, I1);

                        /*" -3661- PERFORM UNTIL I1 GREATER 5 */

                        while (!(I1 > 5))
                        {

                            /*" -3662- IF (SVA-NRSORTE(I1) GREATER ZEROS) */

                            if ((REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[I1] > 00))
                            {

                                /*" -3663- MOVE SVA-NRSORTE(I1) TO WS-NRSORTE */
                                _.Move(REG_SVA5437B.SVA_NRSORTE_S.SVA_NRSORTE[I1], AREA_DE_WORK.WS_NRSORTE);

                                /*" -3665- MOVE WS-NRSORTE(WPI:I2) TO LC11-NRSORTE(I1) */
                                _.Move(AREA_DE_WORK.WS_NRSORTE.Substring(WPI, I2), AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE);

                                /*" -3666- IF (I1 > 1) */

                                if ((I1 > 1))
                                {

                                    /*" -3667- COMPUTE I3 = I1 - 1 */
                                    I3.Value = I1 - 1;

                                    /*" -3668- MOVE '/' TO LC11-NRSORTE-S(I3) */
                                    _.Move("/", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I3].LC11_NRSORTE_S);

                                    /*" -3669- END-IF */
                                }


                                /*" -3670- ELSE */
                            }
                            else
                            {


                                /*" -3671- MOVE 6 TO I1 */
                                _.Move(6, I1);

                                /*" -3673- END-IF */
                            }


                            /*" -3674- ADD 1 TO I1 */
                            I1.Value = I1 + 1;

                            /*" -3675- END-PERFORM */
                        }

                        /*" -3676- END-IF */
                    }


                    /*" -3677- END-IF */
                }


                /*" -3679- END-IF. */
            }


            /*" -3681- MOVE SPACES TO LC11-DAT-NASC */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC);

            /*" -3682- MOVE WS-IDADE TO LC11-IDADE. */
            _.Move(AREA_DE_WORK.WS_IDADE, AREA_DE_WORK.LC11_LINHA11.LC11_IDADE);

            /*" -3683- MOVE SVA-DTNASC(1:4) TO LC11-DAT-NASC(7:4) */
            _.MoveAtPosition(REG_SVA5437B.SVA_DTNASC.Substring(1, 4), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 7, 4);

            /*" -3684- MOVE '/' TO LC11-DAT-NASC(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 3, 1);

            /*" -3685- MOVE SVA-DTNASC(6:2) TO LC11-DAT-NASC(4:2) */
            _.MoveAtPosition(REG_SVA5437B.SVA_DTNASC.Substring(6, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 4, 2);

            /*" -3686- MOVE '/' TO LC11-DAT-NASC(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 6, 1);

            /*" -3688- MOVE SVA-DTNASC(9:2) TO LC11-DAT-NASC(1:2) */
            _.MoveAtPosition(REG_SVA5437B.SVA_DTNASC.Substring(9, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 1, 2);

            /*" -3694- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF */
            _.Move(REG_SVA5437B.SVA_NRCERTIF, AREA_DE_WORK.WS_CERTIF, WHOST_NRCERTIF);

            /*" -3695- IF SVA-SITSEG NOT EQUAL '0' */

            if (REG_SVA5437B.SVA_SITSEG != "0")
            {

                /*" -3696- MOVE SVA-CODUSU TO WHOST-CODUSU */
                _.Move(REG_SVA5437B.SVA_CODUSU, WHOST_CODUSU);

                /*" -3697- PERFORM R2205-00-SELECT-USUARIOS */

                R2205_00_SELECT_USUARIOS_SECTION();

                /*" -3698- IF WTEM-USUARIOS EQUAL 'N' */

                if (AREA_DE_WORK.WTEM_USUARIOS == "N")
                {

                    /*" -3699- DISPLAY ' DESPREZA 01: ' SVA-NRCERTIF */
                    _.Display($" DESPREZA 01: {REG_SVA5437B.SVA_NRCERTIF}");

                    /*" -3700- ADD 1 TO AC-DESPR-CANCEL */
                    AREA_DE_WORK.AC_DESPR_CANCEL.Value = AREA_DE_WORK.AC_DESPR_CANCEL + 1;

                    /*" -3704- GO TO R2200-35-ATU-RELATORI. */

                    R2200_35_ATU_RELATORI(); //GOTO
                    return;
                }

            }


            /*" -3706- MOVE SVA-TIPOSEGU TO WHOST-TIPOSEGU */
            _.Move(REG_SVA5437B.SVA_TIPOSEGU, WHOST_TIPOSEGU);

            /*" -3707- MOVE WS-NRCERTIF TO LC11-NRCERTIF */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_NRCERTIF, AREA_DE_WORK.LC11_LINHA11.LC11_NRCERTIF);

            /*" -3708- MOVE WS-DVCERTIF TO LC11-DVCERTIF */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_DVCERTIF, AREA_DE_WORK.LC11_LINHA11.LC11_DVCERTIF);

            /*" -3709- MOVE SVA-DTINIVIG TO WS-DATA-SQL */
            _.Move(REG_SVA5437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3710- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3711- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3712- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3716- MOVE WS-DATA-I TO LC11-DTINIVIG. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTINIVIG);

            /*" -3720- MOVE SPACES TO TABELA-NOMES TABELA-NOMES1 LC11-CLIENTE. */
            _.Move("", TABELA_NOMES, TABELA_NOMES1, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);

            /*" -3724- MOVE SPACES TO TABELA-NOMES-SOC TABELA-NOMES1-SOC LC11-CLIENTE-SOC. */
            _.Move("", TABELA_NOMES_SOC, TABELA_NOMES1_SOC, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

            /*" -3726- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO TAB-NOMES. */
            _.Move(REG_SVA5437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO, TABELA_NOMES.TAB_NOMES);

            /*" -3728- PERFORM R1950-00-PRIMEIRO-NOME. */

            R1950_00_PRIMEIRO_NOME_SECTION();

            /*" -3730- PERFORM R4000-00-BUSCA-NOM-SOCIAL. */

            R4000_00_BUSCA_NOM_SOCIAL_SECTION();

            /*" -3733- MOVE LC11-NOME-RAZAO-SOC TO TAB-NOMES-SOC TAB-NOMES1-SOC */
            _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC, TABELA_NOMES_SOC.TAB_NOMES_SOC, TABELA_NOMES1_SOC.TAB_NOMES1_SOC);

            /*" -3735- PERFORM R4100-00-PRIMEIRO-NOME-SOCIAL. */

            R4100_00_PRIMEIRO_NOME_SOCIAL_SECTION();

            /*" -3740- MOVE TABELA-NOMES1-SOC TO LC11-CLIENTE-SOC */
            _.Move(TABELA_NOMES1_SOC, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

            /*" -3741- IF SVA-IDSEXO = 'F' */

            if (REG_SVA5437B.SVA_IDSEXO == "F")
            {

                /*" -3742- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                #region STRING
                var spl15 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                _.Move(spl15, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                #endregion

                /*" -3743- ELSE */
            }
            else
            {


                /*" -3744- IF SVA-IDSEXO = 'M' */

                if (REG_SVA5437B.SVA_IDSEXO == "M")
                {

                    /*" -3746- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                    #region STRING
                    var spl16 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl16, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                    #endregion

                    /*" -3747- ELSE */
                }
                else
                {


                    /*" -3749- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                    #region STRING
                    var spl17 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl17, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                    #endregion

                    /*" -3750- END-IF */
                }


                /*" -3752- END-IF */
            }


            /*" -3753- MOVE SVA-CPF TO WS-CPF */
            _.Move(REG_SVA5437B.SVA_CPF, AREA_DE_WORK.WS_CPF);

            /*" -3754- MOVE WS-NRCPF TO LC11-NRCPF */
            _.Move(AREA_DE_WORK.WS_CPF_R.WS_NRCPF, AREA_DE_WORK.LC11_LINHA11.LC11_NRCPF);

            /*" -3758- MOVE WS-DVCPF TO LC11-DVCPF. */
            _.Move(AREA_DE_WORK.WS_CPF_R.WS_DVCPF, AREA_DE_WORK.LC11_LINHA11.LC11_DVCPF);

            /*" -3759- IF SVA-IDSEXO = 'F' */

            if (REG_SVA5437B.SVA_IDSEXO == "F")
            {

                /*" -3761- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                #region STRING
                var spl18 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                _.Move(spl18, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                #endregion

                /*" -3762- ELSE */
            }
            else
            {


                /*" -3763- IF SVA-IDSEXO = 'M' */

                if (REG_SVA5437B.SVA_IDSEXO == "M")
                {

                    /*" -3765- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                    #region STRING
                    var spl19 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl19, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                    #endregion

                    /*" -3766- ELSE */
                }
                else
                {


                    /*" -3768- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                    #region STRING
                    var spl20 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl20, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                    #endregion

                    /*" -3769- END-IF */
                }


                /*" -3771- END-IF */
            }


            /*" -3773- PERFORM R2201-CHAMAR-SUBROTINA-VG0711S. */

            R2201_CHAMAR_SUBROTINA_VG0711S_SECTION();

            /*" -3774- IF (LK711-RETURN-CODE NOT EQUAL ZEROS) */

            if ((PARAMETROS_711.LK711_RETURN_CODE != 00))
            {

                /*" -3775- DISPLAY ' DESPREZA 02: ' SVA-NRCERTIF */
                _.Display($" DESPREZA 02: {REG_SVA5437B.SVA_NRCERTIF}");

                /*" -3776- GO TO R2200-40-NEXT */

                R2200_40_NEXT(); //GOTO
                return;

                /*" -3778- END-IF. */
            }


            /*" -3779- MOVE SVA-DTMOVTO TO WS-DATA-SQL */
            _.Move(REG_SVA5437B.SVA_DTMOVTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3780- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3781- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3782- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3784- MOVE WS-DATA-I TO LC11-DTALTCAP. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTALTCAP);

            /*" -3786- MOVE SPACES TO LC11-OPCAOPAG. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

            /*" -3787- EVALUATE SVA-JDE */
            switch (REG_SVA5437B.SVA_JDE.Value.Trim())
            {

                /*" -3790- WHEN 'VA33' */
                case "VA33":

                    /*" -3791- ADD 1 TO AC-GRAVA-VA33 */
                    AREA_DE_WORK.AC_GRAVA_VA33.Value = AREA_DE_WORK.AC_GRAVA_VA33 + 1;

                    /*" -3792- WHEN 'VIDA07' */
                    break;
                case "VIDA07":

                    /*" -3793- ADD 1 TO AC-GRAVA-VIDA07 */
                    AREA_DE_WORK.AC_GRAVA_VIDA07.Value = AREA_DE_WORK.AC_GRAVA_VIDA07 + 1;

                    /*" -3796- WHEN 'VA44' */
                    break;
                case "VA44":

                    /*" -3797- ADD 1 TO AC-GRAVA-VA44 */
                    AREA_DE_WORK.AC_GRAVA_VA44.Value = AREA_DE_WORK.AC_GRAVA_VA44 + 1;

                    /*" -3798- WHEN 'VIDA05' */
                    break;
                case "VIDA05":

                    /*" -3799- ADD 1 TO AC-GRAVA-VIDA05 */
                    AREA_DE_WORK.AC_GRAVA_VIDA05.Value = AREA_DE_WORK.AC_GRAVA_VIDA05 + 1;

                    /*" -3802- WHEN 'VA54' */
                    break;
                case "VA54":

                    /*" -3803- ADD 1 TO AC-GRAVA-VA54 */
                    AREA_DE_WORK.AC_GRAVA_VA54.Value = AREA_DE_WORK.AC_GRAVA_VA54 + 1;

                    /*" -3804- WHEN 'VIDA10' */
                    break;
                case "VIDA10":

                    /*" -3805- ADD 1 TO AC-GRAVA-VIDA10 */
                    AREA_DE_WORK.AC_GRAVA_VIDA10.Value = AREA_DE_WORK.AC_GRAVA_VIDA10 + 1;

                    /*" -3808- WHEN 'VA83' */
                    break;
                case "VA83":

                    /*" -3809- ADD 1 TO AC-GRAVA-VA83 */
                    AREA_DE_WORK.AC_GRAVA_VA83.Value = AREA_DE_WORK.AC_GRAVA_VA83 + 1;

                    /*" -3812- WHEN 'VD08' */
                    break;
                case "VD08":

                    /*" -3813- ADD 1 TO AC-GRAVA-VD08 */
                    AREA_DE_WORK.AC_GRAVA_VD08.Value = AREA_DE_WORK.AC_GRAVA_VD08 + 1;

                    /*" -3814- WHEN 'VIDA17' */
                    break;
                case "VIDA17":

                    /*" -3815- ADD 1 TO AC-GRAVA-VIDA17 */
                    AREA_DE_WORK.AC_GRAVA_VIDA17.Value = AREA_DE_WORK.AC_GRAVA_VIDA17 + 1;

                    /*" -3818- WHEN 'VD09' */
                    break;
                case "VD09":

                    /*" -3819- ADD 1 TO AC-GRAVA-VD09 */
                    AREA_DE_WORK.AC_GRAVA_VD09.Value = AREA_DE_WORK.AC_GRAVA_VD09 + 1;

                    /*" -3820- WHEN 'VIDA18' */
                    break;
                case "VIDA18":

                    /*" -3821- ADD 1 TO AC-GRAVA-VIDA18 */
                    AREA_DE_WORK.AC_GRAVA_VIDA18.Value = AREA_DE_WORK.AC_GRAVA_VIDA18 + 1;

                    /*" -3823- END-EVALUATE. */
                    break;
            }


            /*" -3824- EVALUATE SVA-OPCAOPAG */
            switch (REG_SVA5437B.SVA_OPCAOPAG.Value.Trim())
            {

                /*" -3825- WHEN '1' */
                case "1":

                    /*" -3826- WHEN '2' */
                    break;
                case "2":

                    /*" -3827- MOVE SVA-AGECTADEB TO LC11-AGECTADEB */
                    _.Move(REG_SVA5437B.SVA_AGECTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_AGECTADEB);

                    /*" -3828- MOVE SVA-OPRCTADEB TO LC11-OPRCTADEB */
                    _.Move(REG_SVA5437B.SVA_OPRCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_OPRCTADEB);

                    /*" -3829- MOVE SVA-NUMCTADEB TO LC11-NUMCTADEB */
                    _.Move(REG_SVA5437B.SVA_NUMCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_NUMCTADEB);

                    /*" -3830- MOVE SVA-DIGCTADEB TO LC11-DIGCTADEB */
                    _.Move(REG_SVA5437B.SVA_DIGCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_DIGCTADEB);

                    /*" -3832- MOVE '.' TO LC11-PONTO1 LC11-PONTO2 */
                    _.Move(".", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_PONTO1, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_PONTO2);

                    /*" -3833- MOVE '-' TO LC11-TRACO */
                    _.Move("-", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_TRACO);

                    /*" -3834- MOVE 'DÉBITO EM CONTA' TO LC11-OPCAO-PAG */
                    _.Move("DÉBITO EM CONTA", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -3835- WHEN '3' */
                    break;
                case "3":

                    /*" -3837- MOVE 'BOLETO DE COBRANÇA BANCÁRIA' TO LC11-OPCAOPAG LC11-OPCAO-PAG */
                    _.Move("BOLETO DE COBRANÇA BANCÁRIA", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -3838- WHEN '4' */
                    break;
                case "4":

                    /*" -3840- MOVE 'DESCONTO EM FOLHA DE PAGTO ' TO LC11-OPCAOPAG LC11-OPCAO-PAG */
                    _.Move("DESCONTO EM FOLHA DE PAGTO ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -3841- WHEN '5' */
                    break;
                case "5":

                    /*" -3843- MOVE 'CARTÃO DE CRÉDITO          ' TO LC11-OPCAOPAG LC11-OPCAO-PAG */
                    _.Move("CARTÃO DE CRÉDITO          ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -3844- WHEN OTHER */
                    break;
                default:

                    /*" -3846- MOVE '  ************************ ' TO LC11-OPCAOPAG LC11-OPCAO-PAG */
                    _.Move("  ************************ ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -3848- END-EVALUATE. */
                    break;
            }


            /*" -3849- EVALUATE SVA-PERI-PAGAMENTO */
            switch (REG_SVA5437B.SVA_PERI_PAGAMENTO.Value)
            {

                /*" -3850- WHEN 0 */
                case 0:

                    /*" -3852- MOVE 'ÚNICO' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("ÚNICO", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3853- WHEN 1 */
                    break;
                case 1:

                    /*" -3855- MOVE 'MENSAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("MENSAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3856- WHEN 2 */
                    break;
                case 2:

                    /*" -3858- MOVE 'BIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("BIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3859- WHEN 3 */
                    break;
                case 3:

                    /*" -3861- MOVE 'TRIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("TRIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3862- WHEN 4 */
                    break;
                case 4:

                    /*" -3864- MOVE 'QUADRIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("QUADRIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3865- WHEN 6 */
                    break;
                case 6:

                    /*" -3867- MOVE 'SEMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("SEMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3868- WHEN 12 */
                    break;
                case 12:

                    /*" -3870- MOVE 'ANUAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("ANUAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3871- WHEN 36 */
                    break;
                case 36:

                    /*" -3873- MOVE 'Á VISTA' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("Á VISTA", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3874- WHEN OTHER */
                    break;
                default:

                    /*" -3876- MOVE 'NÃO EXISTE' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("NÃO EXISTE", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -3878- END-EVALUATE. */
                    break;
            }


            /*" -3880- MOVE SVA-VLPREMIO TO LC11-VLPREMIO. */
            _.Move(REG_SVA5437B.SVA_VLPREMIO, AREA_DE_WORK.LC11_LINHA11.LC11_VLPREMIO);

            /*" -3881- IF SVA-DIA-DEBITO GREATER ZEROS */

            if (REG_SVA5437B.SVA_DIA_DEBITO > 00)
            {

                /*" -3882- MOVE SVA-DIA-DEBITO TO LC11-DIA-DEB */
                _.Move(REG_SVA5437B.SVA_DIA_DEBITO, AREA_DE_WORK.LC11_LINHA11.LC11_DIA_DEB);

                /*" -3883- ELSE */
            }
            else
            {


                /*" -3886- MOVE '**' TO LC11-DIA-DEB-ALFA. */
                _.Move("**", AREA_DE_WORK.LC11_LINHA11.LC11_DIA_DEB_R.LC11_DIA_DEB_ALFA);
            }


            /*" -3887- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVA5437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -3890- MOVE '(*) RESPEITADO O PERIODO CORREPONDENTE AO PREMIO PAGO' TO LC11-TEXTO */
                _.Move("(*) RESPEITADO O PERIODO CORREPONDENTE AO PREMIO PAGO", AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

                /*" -3891- ELSE */
            }
            else
            {


                /*" -3892- MOVE SPACES TO LC11-TEXTO */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

                /*" -3893- END-IF. */
            }


            /*" -3895- MOVE 'SEG. PRINCIPAL: ' TO WS-STRING1 */
            _.Move("SEG. PRINCIPAL: ", AREA_DE_WORK.WS_DATA_SEG.WS_STRING1);

            /*" -3896- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SVA5437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -3897- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_DIA_INI);

            /*" -3898- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_MES_INI);

            /*" -3899- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_ANO_INI);

            /*" -3901- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA2);

            /*" -3902- MOVE ' A ' TO WS-FIL-A */
            _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_FIL_A);

            /*" -3903- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SVA5437B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -3904- MOVE WS-DIA-INV TO WS-DIA-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_DIA_TER);

            /*" -3905- MOVE WS-MES-INV TO WS-MES-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_MES_TER);

            /*" -3906- MOVE WS-ANO-INV TO WS-ANO-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_ANO_TER);

            /*" -3909- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_BARRA4);

            /*" -3910- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVA5437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -3911- MOVE '(*)' TO WS-STRING2 */
                _.Move("(*)", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -3912- ELSE */
            }
            else
            {


                /*" -3913- MOVE SPACES TO WS-STRING2 */
                _.Move("", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -3915- END-IF. */
            }


            /*" -3917- MOVE WS-DATA-SEG TO LC11-DTVIG-PRIN */
            _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_PRIN);

            /*" -3919- MOVE WS-DTINIVIG TO LC11-DT-INI-VIG */
            _.Move(AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG, AREA_DE_WORK.LC11_LINHA11.LC11_DT_INI_VIG);

            /*" -3920- MOVE SVA-DTQUIT TO WS-DATA-INV */
            _.Move(REG_SVA5437B.SVA_DTQUIT, AREA_DE_WORK.WS_DATA_INV);

            /*" -3921- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_DIA_INI);

            /*" -3922- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_MES_INI);

            /*" -3923- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_ANO_INI);

            /*" -3925- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA2);

            /*" -3929- MOVE WS-DTINIVIG TO LC11-DT-EMISSAO */
            _.Move(AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG, AREA_DE_WORK.LC11_LINHA11.LC11_DT_EMISSAO);

            /*" -3930- MOVE SVA-DTINIVIG-APOL TO WS-DATA-INV */
            _.Move(REG_SVA5437B.SVA_DTINIVIG_APOL, AREA_DE_WORK.WS_DATA_INV);

            /*" -3931- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_DIA_INI);

            /*" -3932- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_MES_INI);

            /*" -3933- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_ANO_INI);

            /*" -3935- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA2);

            /*" -3936- MOVE ' A ' TO WS-FIL-A */
            _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_FIL_A);

            /*" -3937- MOVE SVA-DTTERVIG-APOL TO WS-DATA-INV */
            _.Move(REG_SVA5437B.SVA_DTTERVIG_APOL, AREA_DE_WORK.WS_DATA_INV);

            /*" -3938- MOVE WS-DIA-INV TO WS-DIA-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_DIA_TER);

            /*" -3939- MOVE WS-MES-INV TO WS-MES-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_MES_TER);

            /*" -3940- MOVE WS-ANO-INV TO WS-ANO-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_ANO_TER);

            /*" -3942- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_BARRA4);

            /*" -3944- MOVE WS-PERI-VIGENCIA TO LC11-PERI-VIG-APOL. */
            _.Move(AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA, AREA_DE_WORK.LC11_LINHA11.LC11_PERI_VIG_APOL);

            /*" -3945- IF (LK711-COBT-IMP-CONJUGE NOT EQUAL ZEROS) */

            if ((PARAMETROS_711.LK711_COBT_IMP_CONJUGE != 00))
            {

                /*" -3947- MOVE 'SEG. DEPENDENTE:' TO WS-STRING1 */
                _.Move("SEG. DEPENDENTE:", AREA_DE_WORK.WS_DATA_SEG.WS_STRING1);

                /*" -3948- MOVE SVA-DTINIVIG TO WS-DATA-INV */
                _.Move(REG_SVA5437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

                /*" -3949- MOVE WS-DIA-INV TO WS-DIA-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_DIA_INI);

                /*" -3950- MOVE WS-MES-INV TO WS-MES-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_MES_INI);

                /*" -3951- MOVE WS-ANO-INV TO WS-ANO-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_ANO_INI);

                /*" -3953- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
                _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTINIVIG.WS_BARRA2);

                /*" -3954- MOVE ' A ' TO WS-FIL-A */
                _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_FIL_A);

                /*" -3955- MOVE SVA-DTTERVIG TO WS-DATA-INV */
                _.Move(REG_SVA5437B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

                /*" -3956- MOVE WS-DIA-INV TO WS-DIA-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_DIA_TER);

                /*" -3957- MOVE WS-MES-INV TO WS-MES-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_MES_TER);

                /*" -3958- MOVE WS-ANO-INV TO WS-ANO-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_ANO_TER);

                /*" -3960- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
                _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_PERI_VIGENCIA.WS_DTTERVIG.WS_BARRA4);

                /*" -3961- MOVE SPACES TO WS-STRING2 */
                _.Move("", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -3962- MOVE WS-DATA-SEG TO LC11-DTVIG-DEPE */
                _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_DEPE);

                /*" -3963- ELSE */
            }
            else
            {


                /*" -3964- MOVE SPACES TO LC11-DTVIG-DEPE */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_DEPE);

                /*" -3966- END-IF */
            }


            /*" -3968- INITIALIZE LC11-BENEFICIARIOS */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS
            );

            /*" -3988- MOVE '|' TO LC11-DELIMIT-01 (1) LC11-DELIMIT-01(6) LC11-DELIMIT-01 (2) LC11-DELIMIT-01(7) LC11-DELIMIT-01 (3) LC11-DELIMIT-01(8) LC11-DELIMIT-01 (4) LC11-DELIMIT-01(9) LC11-DELIMIT-01 (5) LC11-DELIMIT-01(10) LC11-DELIMIT-02 (1) LC11-DELIMIT-02(6) LC11-DELIMIT-02 (2) LC11-DELIMIT-02(7) LC11-DELIMIT-02 (3) LC11-DELIMIT-02(8) LC11-DELIMIT-02 (4) LC11-DELIMIT-02(9) LC11-DELIMIT-02 (5) LC11-DELIMIT-02(10) LC11-DELIMIT-03 (1) LC11-DELIMIT-03(6) LC11-DELIMIT-03 (2) LC11-DELIMIT-03(7) LC11-DELIMIT-03 (3) LC11-DELIMIT-03(8) LC11-DELIMIT-03 (4) LC11-DELIMIT-03(9) LC11-DELIMIT-03 (5) LC11-DELIMIT-03(10). */
            _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[6].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[7].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[8].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[9].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[10].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[6].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[7].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[8].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[9].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[10].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[6].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[7].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[8].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[9].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[10].LC11_DELIMIT_03);

            /*" -3992- PERFORM R2400-00-BENEFICIARIOS. */

            R2400_00_BENEFICIARIOS_SECTION();

            /*" -3993- IF (WIND-99 EQUAL ZEROS) */

            if ((AREA_DE_WORK.WIND_99 == 00))
            {

                /*" -3994- MOVE 'HERDEIROS LEGAIS' TO LC11-NOME-BENEF(1) */
                _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_NOME_BENEF);

                /*" -3995- MOVE 'OUTROS' TO LC11-PARENTESCO(1) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARENTESCO);

                /*" -3997- MOVE 100 TO LC11-PARTICIP (1) */
                _.Move(100, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARTICIP);

                /*" -3998- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO-END */
                _.Move(REG_SVA5437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

                /*" -3999- MOVE SVA-ENDERECO TO LC11-ENDERECO */
                _.Move(REG_SVA5437B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

                /*" -4000- MOVE SVA-CIDADE TO LC11-CIDADE */
                _.Move(REG_SVA5437B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

                /*" -4001- MOVE SVA-BAIRRO TO LC11-BAIRRO */
                _.Move(REG_SVA5437B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

                /*" -4002- MOVE SVA-UF TO LC11-UF */
                _.Move(REG_SVA5437B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

                /*" -4003- MOVE SVA-CEP TO LC11-CEP */
                _.Move(REG_SVA5437B.SVA_NUM_CEP.SVA_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

                /*" -4005- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL */
                _.Move(REG_SVA5437B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

                /*" -4007- PERFORM R2650-00-BUSCA-FONTE */

                R2650_00_BUSCA_FONTE_SECTION();

                /*" -4010- ADD 1 TO WS-SEQ AC-QTD-OBJ AC-CONTA1 */
                AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
                AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
                AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

                /*" -4011- MOVE WS-SEQ TO WED-SEQ */
                _.Move(AREA_DE_WORK.WS_SEQ, WED_SEQ);

                /*" -4013- MOVE WED-SEQ TO LC11-SEQUENCIA */
                _.Move(WED_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

                /*" -4014- IF WS-CONTR-OBJ EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
                {

                    /*" -4015- MOVE 1 TO WS-CONTR-OBJ */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                    /*" -4017- END-IF */
                }


                /*" -4018- IF WS-CONTR-200 EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_200 == 00)
                {

                    /*" -4019- MOVE 1 TO WS-CONTR-200 */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                    /*" -4020- MOVE WS-SEQ TO WS-SEQ-INICIAL */
                    _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);

                    /*" -4022- END-IF */
                }


                /*" -4024- MOVE ZEROS TO WS-SALVA-CERTIF */
                _.Move(0, AREA_DE_WORK.WS_SALVA_CERTIF);

                /*" -4025- IF (WS-IMPRIME-CONTROLES-OK EQUAL 1) */

                if ((WS_IMPRIME_CONTROLES_OK == 1))
                {

                    /*" -4026- MOVE 10 TO WS-LINHAS-UNIC */
                    _.Move(10, WS_LINHAS_UNIC);

                    /*" -4028- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                    R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                    /*" -4029- MOVE ZEROS TO WS-IMPRIME-CONTROLES-OK */
                    _.Move(0, WS_IMPRIME_CONTROLES_OK);

                    /*" -4031- END-IF */
                }


                /*" -4032- MOVE 11 TO WS-LINHAS-UNIC */
                _.Move(11, WS_LINHAS_UNIC);

                /*" -4034- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                /*" -4035- ADD 1 TO AC-IMPRESSOS */
                AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

                /*" -4039- SET W88-IMPRESSAO-OK TO TRUE */
                FILLER_0["W88_IMPRESSAO_OK"] = true;

                /*" -4040- MOVE LC11-APOLICE TO FVA5437B-RECORD */
                _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE, FVA5437B_RECORD);

                /*" -4041- WRITE FVA5437B-RECORD */
                FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

                /*" -4042- MOVE SPACES TO FVA5437B-RECORD */
                _.Move("", FVA5437B_RECORD);

                /*" -4043- ELSE */
            }
            else
            {


                /*" -4044- PERFORM R2220-00-IMP-BENEFICIARIOS */

                R2220_00_IMP_BENEFICIARIOS_SECTION();

                /*" -4044- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2200_35_ATU_RELATORI */

            R2200_35_ATU_RELATORI();

        }

        [StopWatch]
        /*" R2200-35-ATU-RELATORI */
        private void R2200_35_ATU_RELATORI(bool isPerform = false)
        {
            /*" -4049- MOVE SVA-CODRELATVG TO WHOST-CODRELAT. */
            _.Move(REG_SVA5437B.SVA_CODRELATVG, WHOST_CODRELAT);

            /*" -4049- PERFORM R2500-00-UPDATE-RELATORI. */

            R2500_00_UPDATE_RELATORI_SECTION();

        }

        [StopWatch]
        /*" R2200-40-NEXT */
        private void R2200_40_NEXT(bool isPerform = false)
        {
            /*" -4055- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2201-CHAMAR-SUBROTINA-VG0711S-SECTION */
        private void R2201_CHAMAR_SUBROTINA_VG0711S_SECTION()
        {
            /*" -4066- MOVE '2201' TO WNR-EXEC-SQL. */
            _.Move("2201", WABEND.WNR_EXEC_SQL);

            /*" -4069- MOVE SVA-NRCERTIF TO LK711-CERTIFICADO WHOST-NRCERTIF */
            _.Move(REG_SVA5437B.SVA_NRCERTIF, PARAMETROS_711.LK711_CERTIFICADO, WHOST_NRCERTIF);

            /*" -4071- PERFORM R1250-00-CALCULA-IDADE-CLIENTE */

            R1250_00_CALCULA_IDADE_CLIENTE_SECTION();

            /*" -4072- MOVE SVA-NRAPOLICE TO LK711-NUM-APOLICE */
            _.Move(REG_SVA5437B.SVA_NRAPOLICE, PARAMETROS_711.LK711_NUM_APOLICE);

            /*" -4073- MOVE SVA-CODSUBES TO LK711-SUBGRUPO */
            _.Move(REG_SVA5437B.SVA_CODSUBES, PARAMETROS_711.LK711_SUBGRUPO);

            /*" -4074- MOVE SVA-DTQUIT TO LK711-DT-QUITACAO */
            _.Move(REG_SVA5437B.SVA_DTQUIT, PARAMETROS_711.LK711_DT_QUITACAO);

            /*" -4075- MOVE WS-IDADE TO LK711-IDADE */
            _.Move(AREA_DE_WORK.WS_IDADE, PARAMETROS_711.LK711_IDADE);

            /*" -4077- MOVE ZEROS TO LK711-SALARIO LK711-DATA-NASCIMENTO */
            _.Move(0, PARAMETROS_711.LK711_SALARIO, PARAMETROS_711.LK711_NASCIMENTO.LK711_DATA_NASCIMENTO);

            /*" -4095- MOVE SVA-VLPREMIO TO LK711-VLR-PREMIO */
            _.Move(REG_SVA5437B.SVA_VLPREMIO, PARAMETROS_711.LK711_VLR_PREMIO);

            /*" -4097- CALL 'VG0711S' USING PARAMETROS-711. */
            _.Call("VG0711S", PARAMETROS_711);

            /*" -4098- MOVE LK711-RETURN-CODE TO WS-RETURN-CODE. */
            _.Move(PARAMETROS_711.LK711_RETURN_CODE, WS_RETURN_CODE);

            /*" -4100- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -4101- IF (LK711-RETURN-CODE NOT EQUAL ZEROS) */

            if ((PARAMETROS_711.LK711_RETURN_CODE != 00))
            {

                /*" -4102- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -4103- DISPLAY '----- ERRO NA SUBROTINA VG0711S  ----' */
                _.Display($"----- ERRO NA SUBROTINA VG0711S  ----");

                /*" -4104- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -4105- DISPLAY 'MENSAGEM ' LK711-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS_711.LK711_MENSAGEM}");

                /*" -4106- DISPLAY 'ERRO     ' LK711-RETURN-CODE */
                _.Display($"ERRO     {PARAMETROS_711.LK711_RETURN_CODE}");

                /*" -4107- DISPLAY 'ERRO     ' WS-RETURN-CODE-M */
                _.Display($"ERRO     {WS_RETURN_CODE_M}");

                /*" -4108- DISPLAY 'APOLICE  ' SVA-NRAPOLICE */
                _.Display($"APOLICE  {REG_SVA5437B.SVA_NRAPOLICE}");

                /*" -4109- DISPLAY 'CODSUBES ' SVA-CODSUBES */
                _.Display($"CODSUBES {REG_SVA5437B.SVA_CODSUBES}");

                /*" -4110- DISPLAY 'CERTIF   ' WHOST-NRCERTIF */
                _.Display($"CERTIF   {WHOST_NRCERTIF}");

                /*" -4111- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -4112- DISPLAY '-----ENTRADA DA SUBROTINA VG0711S----' */
                _.Display($"-----ENTRADA DA SUBROTINA VG0711S----");

                /*" -4113- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -4114- DISPLAY 'NUM-APOLICE ' LK711-NUM-APOLICE */
                _.Display($"NUM-APOLICE {PARAMETROS_711.LK711_NUM_APOLICE}");

                /*" -4115- DISPLAY 'SUBGRUPO ' LK711-SUBGRUPO */
                _.Display($"SUBGRUPO {PARAMETROS_711.LK711_SUBGRUPO}");

                /*" -4116- DISPLAY 'CERTIFICADO ' LK711-CERTIFICADO */
                _.Display($"CERTIFICADO {PARAMETROS_711.LK711_CERTIFICADO}");

                /*" -4117- DISPLAY 'IDADE ' LK711-IDADE */
                _.Display($"IDADE {PARAMETROS_711.LK711_IDADE}");

                /*" -4118- DISPLAY 'NASC  ' WS-DTNASC */
                _.Display($"NASC  {AREA_DE_WORK.WS_DTNASC}");

                /*" -4119- DISPLAY 'MOVAB ' WS-DTMOVABE */
                _.Display($"MOVAB {AREA_DE_WORK.WS_DTMOVABE}");

                /*" -4120- DISPLAY 'NOME-RAZAO ' CLIENTES-NOME-RAZAO */
                _.Display($"NOME-RAZAO {CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO}");

                /*" -4121- DISPLAY 'DATA-NASCIMENTO ' LK711-DATA-NASCIMENTO */
                _.Display($"DATA-NASCIMENTO {PARAMETROS_711.LK711_NASCIMENTO.LK711_DATA_NASCIMENTO}");

                /*" -4122- DISPLAY 'SALARIO ' LK711-SALARIO */
                _.Display($"SALARIO {PARAMETROS_711.LK711_SALARIO}");

                /*" -4123- DISPLAY 'VLR-PREMIO ' LK711-VLR-PREMIO */
                _.Display($"VLR-PREMIO {PARAMETROS_711.LK711_VLR_PREMIO}");

                /*" -4124- DISPLAY 'DT-QUITACAO ' LK711-DT-QUITACAO */
                _.Display($"DT-QUITACAO {PARAMETROS_711.LK711_DT_QUITACAO}");

                /*" -4125- DISPLAY '-------------------------------------' */
                _.Display($"-------------------------------------");

                /*" -4126- GO TO R2201-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2201_99_SAIDA*/ //GOTO
                return;

                /*" -4128- END-IF. */
            }


            /*" -4130- MOVE 1 TO WS-I WS-ICAR. */
            _.Move(1, AREA_DE_WORK.WS_I, AREA_DE_WORK.WS_ICAR);

            /*" -4133- INITIALIZE LC11-COBERTURAS LC11-CARENCIAS. */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS
                , AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS
            );

            /*" -4134- MOVE SVA-VLPREMIO TO WS-VALOR-0 */
            _.Move(REG_SVA5437B.SVA_VLPREMIO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_0);

            /*" -4136- MOVE WS-VALOR-0 TO LC11-PREMIO-BRU */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_0, AREA_DE_WORK.LC11_LINHA11.LC11_PREMIO_BRU);

            /*" -4137- MOVE LK711-IOF-PREMIO TO WS-VALOR-0 */
            _.Move(PARAMETROS_711.LK711_IOF_PREMIO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_0);

            /*" -4139- MOVE WS-VALOR-0 TO LC11-IOF-PREMIO */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_0, AREA_DE_WORK.LC11_LINHA11.LC11_IOF_PREMIO);

            /*" -4141- COMPUTE WS-VALOR-9 = SVA-VLPREMIO - LK711-IOF-PREMIO */
            AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9.Value = REG_SVA5437B.SVA_VLPREMIO - PARAMETROS_711.LK711_IOF_PREMIO;

            /*" -4142- MOVE WS-VALOR-9 TO WS-VALOR-0 */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_0);

            /*" -4144- MOVE WS-VALOR-0 TO LC11-PREMIO-LIQ */
            _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_0, AREA_DE_WORK.LC11_LINHA11.LC11_PREMIO_LIQ);

            /*" -4151- PERFORM R2202-DESCARREGAR-TAB-SAIDA VARYING WS-I FROM 1 BY 1 UNTIL WS-I > 13. */

            for (AREA_DE_WORK.WS_I.Value = 1; !(AREA_DE_WORK.WS_I > 13); AREA_DE_WORK.WS_I.Value += 1)
            {

                R2202_DESCARREGAR_TAB_SAIDA_SECTION();
            }

            /*" -4197- PERFORM R2203-VERIFICA-CARENCIAS */

            R2203_VERIFICA_CARENCIAS_SECTION();

            /*" -4197- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2201_99_SAIDA*/

        [StopWatch]
        /*" R2202-DESCARREGAR-TAB-SAIDA-SECTION */
        private void R2202_DESCARREGAR_TAB_SAIDA_SECTION()
        {
            /*" -4206- IF (WS-I < 06) */

            if ((AREA_DE_WORK.WS_I < 06))
            {

                /*" -4207- MOVE '|' TO LC11-DELIMIT-CAR(WS-I) */
                _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS.LC11_CAREN_OCC[AREA_DE_WORK.WS_I].LC11_DELIMIT_CAR);

                /*" -4209- END-IF */
            }


            /*" -4213- MOVE '|' TO LC11-DELIMIT-04(WS-I) LC11-DELIMIT-05(WS-I) LC11-DELIMIT-06(WS-I) */
            _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_DELIMIT_04, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_DELIMIT_05, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_DELIMIT_06);

            /*" -4214- IF (LK711-DES-GARANTIA(WS-I) NOT EQUAL SPACES) */

            if ((PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_DES_GARANTIA != string.Empty))
            {

                /*" -4216- MOVE LK711-DES-GARANTIA(WS-I) TO LC11-STRING1 (WS-I) */
                _.Move(PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_DES_GARANTIA, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_STRING1);

                /*" -4217- IF (LK711-VLR-CAP-DESC (WS-I) NOT EQUAL SPACES) */

                if ((PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_VLR_CAP_DESC != string.Empty))
                {

                    /*" -4218- MOVE LK711-VLR-CAP-DESC(WS-I) TO LC11-VALORA(WS-I) */
                    _.Move(PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_VLR_CAP_DESC, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_VALORA);

                    /*" -4219- ELSE */
                }
                else
                {


                    /*" -4220- IF (LK711-VLR-CAP-SEGURADO(WS-I) > ZEROS) */

                    if ((PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_VLR_CAP_SEGURADO > 00))
                    {

                        /*" -4221- MOVE LK711-VLR-CAP-SEGURADO(WS-I) TO WS-VALOR */
                        _.Move(PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_VLR_CAP_SEGURADO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                        /*" -4222- MOVE WS-VALOR TO LC11-VALORA(WS-I) */
                        _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_VALORA);

                        /*" -4223- ELSE */
                    }
                    else
                    {


                        /*" -4224- MOVE '            -' TO LC11-VALORA(WS-I) */
                        _.Move("            -", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_VALORA);

                        /*" -4225- END-IF */
                    }


                    /*" -4227- END-IF */
                }


                /*" -4228- IF (LK711-VLR-PCT-PREMIO(WS-I) > ZEROS) */

                if ((PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_VLR_PCT_PREMIO > 00))
                {

                    /*" -4229- MOVE LK711-VLR-PCT-PREMIO(WS-I) TO WS-VALOR */
                    _.Move(PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_VLR_PCT_PREMIO, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -4230- MOVE WS-VALOR TO LC11-VLR-CUSTO-PREM(WS-I) */
                    _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_VLR_CUSTO_PREM);

                    /*" -4231- ELSE */
                }
                else
                {


                    /*" -4232- MOVE '            -' TO LC11-VLR-CUSTO-PREM(WS-I) */
                    _.Move("            -", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[AREA_DE_WORK.WS_I].LC11_VLR_CUSTO_PREM);

                    /*" -4234- END-IF */
                }


                /*" -4235- IF (LK711-NUM-COB-CARENCIA(WS-I) > ZEROS) */

                if ((PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_NUM_COB_CARENCIA > 00))
                {

                    /*" -4237- MOVE LK711-DES-COB-CARENCIA(WS-I) TO LC11-STR-CARENCIA(WS-ICAR) */
                    _.Move(PARAMETROS_711.LK711_TAB_COB_PREMIO[AREA_DE_WORK.WS_I].LK711_DES_COB_CARENCIA, AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS.LC11_CAREN_OCC[AREA_DE_WORK.WS_ICAR].LC11_STR_CARENCIA);

                    /*" -4238- ADD 1 TO WS-ICAR */
                    AREA_DE_WORK.WS_ICAR.Value = AREA_DE_WORK.WS_ICAR + 1;

                    /*" -4239- END-IF */
                }


                /*" -4239- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2202_99_SAIDA*/

        [StopWatch]
        /*" R2203-VERIFICA-CARENCIAS-SECTION */
        private void R2203_VERIFICA_CARENCIAS_SECTION()
        {
            /*" -4250- MOVE '2203' TO WNR-EXEC-SQL */
            _.Move("2203", WABEND.WNR_EXEC_SQL);

            /*" -4257- PERFORM R2203_VERIFICA_CARENCIAS_DB_SELECT_1 */

            R2203_VERIFICA_CARENCIAS_DB_SELECT_1();

            /*" -4260-  EVALUATE SQLCODE  */

            /*" -4261-  WHEN ZEROS  */

            /*" -4261- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4262- MOVE 1 TO WS-I-LIMP-CAR */
                _.Move(1, AREA_DE_WORK.WS_I_LIMP_CAR);

                /*" -4264- PERFORM R2204-LIMPAR-TAB-CARENCIA UNTIL WS-I-LIMP-CAR > 5 */

                while (!(AREA_DE_WORK.WS_I_LIMP_CAR > 5))
                {

                    R2204_LIMPAR_TAB_CARENCIA_SECTION();
                }

                /*" -4265-  WHEN +100  */

                /*" -4265- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4266- CONTINUE */

                /*" -4267-  WHEN OTHER  */

                /*" -4267- ELSE */
            }
            else
            {


                /*" -4268- DISPLAY '*** VA5437B - PROBLEMAS NO ACESSO A CARENCIA ***' */
                _.Display($"*** VA5437B - PROBLEMAS NO ACESSO A CARENCIA ***");

                /*" -4269- DISPLAY ' CERTIFICADO - ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" CERTIFICADO - {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -4270- DISPLAY ' SQLCODE     - ' SQLCODE */
                _.Display($" SQLCODE     - {DB.SQLCODE}");

                /*" -4271- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4273-  END-EVALUATE  */

                /*" -4273- END-IF */
            }


            /*" -4273- . */

        }

        [StopWatch]
        /*" R2203-VERIFICA-CARENCIAS-DB-SELECT-1 */
        public void R2203_VERIFICA_CARENCIAS_DB_SELECT_1()
        {
            /*" -4257- EXEC SQL SELECT COD_RELATORIO INTO :WS-COD-RELAT-CAR FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_RELATORIO = 'CARENCIA' WITH UR END-EXEC */

            var r2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1 = new R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1.Execute(r2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_RELAT_CAR, AREA_DE_WORK.WS_COD_RELAT_CAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2203_99_SAIDA*/

        [StopWatch]
        /*" R2204-LIMPAR-TAB-CARENCIA-SECTION */
        private void R2204_LIMPAR_TAB_CARENCIA_SECTION()
        {
            /*" -4283- IF (WS-I-LIMP-CAR < 6) */

            if ((AREA_DE_WORK.WS_I_LIMP_CAR < 6))
            {

                /*" -4284- MOVE '|' TO LC11-DELIMIT-CAR(WS-I-LIMP-CAR) */
                _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS.LC11_CAREN_OCC[AREA_DE_WORK.WS_I_LIMP_CAR].LC11_DELIMIT_CAR);

                /*" -4286- END-IF */
            }


            /*" -4287- IF WS-I-LIMP-CAR = 1 */

            if (AREA_DE_WORK.WS_I_LIMP_CAR == 1)
            {

                /*" -4288- MOVE SPACES TO LC11-STR-CARENCIA(WS-I-LIMP-CAR) */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS.LC11_CAREN_OCC[AREA_DE_WORK.WS_I_LIMP_CAR].LC11_STR_CARENCIA);

                /*" -4289- MOVE 'SEM CARENCIA' TO LC11-STR-CARENCIA(WS-I-LIMP-CAR) */
                _.Move("SEM CARENCIA", AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS.LC11_CAREN_OCC[AREA_DE_WORK.WS_I_LIMP_CAR].LC11_STR_CARENCIA);

                /*" -4290- ELSE */
            }
            else
            {


                /*" -4291- MOVE SPACES TO LC11-STR-CARENCIA(WS-I-LIMP-CAR) */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CARENCIAS.LC11_CAREN_OCC[AREA_DE_WORK.WS_I_LIMP_CAR].LC11_STR_CARENCIA);

                /*" -4293- END-IF */
            }


            /*" -4295- ADD 1 TO WS-I-LIMP-CAR */
            AREA_DE_WORK.WS_I_LIMP_CAR.Value = AREA_DE_WORK.WS_I_LIMP_CAR + 1;

            /*" -4295- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2204_99_SAIDA*/

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-SECTION */
        private void R2205_00_SELECT_USUARIOS_SECTION()
        {
            /*" -4306- MOVE '2205' TO WNR-EXEC-SQL. */
            _.Move("2205", WABEND.WNR_EXEC_SQL);

            /*" -4308- MOVE 'S' TO WTEM-USUARIOS. */
            _.Move("S", AREA_DE_WORK.WTEM_USUARIOS);

            /*" -4313- PERFORM R2205_00_SELECT_USUARIOS_DB_SELECT_1 */

            R2205_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -4316- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4317- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4318- MOVE 'N' TO WTEM-USUARIOS */
                    _.Move("N", AREA_DE_WORK.WTEM_USUARIOS);

                    /*" -4319- ELSE */
                }
                else
                {


                    /*" -4321- DISPLAY '*** VA5437B PROBLEMAS NO ACESSO A USUARIOS   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA5437B PROBLEMAS NO ACESSO A USUARIOS   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -4321- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R2205_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -4313- EXEC SQL SELECT COD_USUARIO INTO :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :WHOST-CODUSU END-EXEC. */

            var r2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1 = new R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1()
            {
                WHOST_CODUSU = WHOST_CODUSU.ToString(),
            };

            var executed_1 = R2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1.Execute(r2205_00_SELECT_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_COD_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-IMP-BENEFICIARIOS-SECTION */
        private void R2220_00_IMP_BENEFICIARIOS_SECTION()
        {
            /*" -4332- MOVE '2220' TO WNR-EXEC-SQL. */
            _.Move("2220", WABEND.WNR_EXEC_SQL);

            /*" -4333- MOVE ZEROS TO WIND-88 */
            _.Move(0, AREA_DE_WORK.WIND_88);

            /*" -4334- MOVE 'N' TO WFIM-TABELA WPRIM-LINHA. */
            _.Move("N", AREA_DE_WORK.WFIM_TABELA, AREA_DE_WORK.WPRIM_LINHA);

            /*" -0- FLUXCONTROL_PERFORM R2220_10_INI_CERTIFICADO */

            R2220_10_INI_CERTIFICADO();

        }

        [StopWatch]
        /*" R2220-10-INI-CERTIFICADO */
        private void R2220_10_INI_CERTIFICADO(bool isPerform = false)
        {
            /*" -4339- MOVE ZEROS TO WIND-77 */
            _.Move(0, AREA_DE_WORK.WIND_77);

            /*" -4343- ADD 1 TO WS-SEQ AC-QTD-OBJ AC-CONTA1 */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -4344- MOVE WS-SEQ TO WED-SEQ */
            _.Move(AREA_DE_WORK.WS_SEQ, WED_SEQ);

            /*" -4346- MOVE WED-SEQ TO LC11-SEQUENCIA */
            _.Move(WED_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

            /*" -4347- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -4348- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -4350- END-IF. */
            }


            /*" -4351- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -4352- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -4352- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);
            }


        }

        [StopWatch]
        /*" R2220-20-BENEFICIARIOS */
        private void R2220_20_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -4364- ADD 1 TO WIND-77 WIND-88. */
            AREA_DE_WORK.WIND_77.Value = AREA_DE_WORK.WIND_77 + 1;
            AREA_DE_WORK.WIND_88.Value = AREA_DE_WORK.WIND_88 + 1;

            /*" -4366- IF (WIND-88 > WIND-99) OR (WIND-88 > 10) */

            if ((AREA_DE_WORK.WIND_88 > AREA_DE_WORK.WIND_99) || (AREA_DE_WORK.WIND_88 > 10))
            {

                /*" -4367- MOVE 'S' TO WFIM-TABELA */
                _.Move("S", AREA_DE_WORK.WFIM_TABELA);

                /*" -4369- GO TO R2220-30-ENDERECO. */

                R2220_30_ENDERECO(); //GOTO
                return;
            }


            /*" -4371- IF WIND-88 = 1 OR WPRIM-LINHA = 'S' */

            if (AREA_DE_WORK.WIND_88 == 1 || AREA_DE_WORK.WPRIM_LINHA == "S")
            {

                /*" -4372- MOVE 'N' TO WPRIM-LINHA */
                _.Move("N", AREA_DE_WORK.WPRIM_LINHA);

                /*" -4373- ELSE */
            }
            else
            {


                /*" -4375- DIVIDE WIND-88 BY 10 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
                _.Divide(AREA_DE_WORK.WIND_88, 10, AREA_DE_WORK.WS_QUOCIENTE, AREA_DE_WORK.WS_RESTO);

                /*" -4377- IF WS-RESTO = 1 AND WPRIM-LINHA = 'N' */

                if (AREA_DE_WORK.WS_RESTO == 1 && AREA_DE_WORK.WPRIM_LINHA == "N")
                {

                    /*" -4378- MOVE 'N' TO WFIM-TABELA */
                    _.Move("N", AREA_DE_WORK.WFIM_TABELA);

                    /*" -4379- MOVE 'S' TO WPRIM-LINHA */
                    _.Move("S", AREA_DE_WORK.WPRIM_LINHA);

                    /*" -4381- GO TO R2220-30-ENDERECO. */

                    R2220_30_ENDERECO(); //GOTO
                    return;
                }

            }


            /*" -4383- MOVE TB99-NOME-BENEF (WIND-88) TO LC11-NOME-BENEF (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_NOME_BENEF, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_NOME_BENEF);

            /*" -4385- MOVE TB99-PARENTESCO (WIND-88) TO LC11-PARENTESCO (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_PARENTESCO, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARENTESCO);

            /*" -4388- MOVE TB99-PARTICIP (WIND-88) TO LC11-PARTICIP (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_PARTICIP, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARTICIP);

            /*" -4388- GO TO R2220-20-BENEFICIARIOS. */
            new Task(() => R2220_20_BENEFICIARIOS()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2220-30-ENDERECO */
        private void R2220_30_ENDERECO(bool isPerform = false)
        {
            /*" -4393- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO-END */
            _.Move(REG_SVA5437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

            /*" -4394- MOVE SVA-ENDERECO TO LC11-ENDERECO. */
            _.Move(REG_SVA5437B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

            /*" -4395- MOVE SVA-CIDADE TO LC11-CIDADE. */
            _.Move(REG_SVA5437B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

            /*" -4396- MOVE SVA-BAIRRO TO LC11-BAIRRO. */
            _.Move(REG_SVA5437B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

            /*" -4397- MOVE SVA-UF TO LC11-UF. */
            _.Move(REG_SVA5437B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

            /*" -4398- MOVE SVA-NUM-CEP TO LC11-CEP. */
            _.Move(REG_SVA5437B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

            /*" -4400- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL. */
            _.Move(REG_SVA5437B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

            /*" -4402- PERFORM R2650-00-BUSCA-FONTE. */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -4404- MOVE ZEROS TO WS-SALVA-CERTIF */
            _.Move(0, AREA_DE_WORK.WS_SALVA_CERTIF);

            /*" -4405- IF (WS-IMPRIME-CONTROLES-OK EQUAL 1) */

            if ((WS_IMPRIME_CONTROLES_OK == 1))
            {

                /*" -4406- MOVE 10 TO WS-LINHAS-UNIC */
                _.Move(10, WS_LINHAS_UNIC);

                /*" -4408- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                /*" -4409- MOVE ZEROS TO WS-IMPRIME-CONTROLES-OK */
                _.Move(0, WS_IMPRIME_CONTROLES_OK);

                /*" -4411- END-IF */
            }


            /*" -4412- MOVE 11 TO WS-LINHAS-UNIC */
            _.Move(11, WS_LINHAS_UNIC);

            /*" -4414- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

            R9155_00_GRAVA_LINHAS_UNIC_SECTION();

            /*" -4415- ADD 1 TO AC-IMPRESSOS */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -4419- SET W88-IMPRESSAO-OK TO TRUE */
            FILLER_0["W88_IMPRESSAO_OK"] = true;

            /*" -4420- MOVE LC11-APOLICE TO FVA5437B-RECORD */
            _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE, FVA5437B_RECORD);

            /*" -4421- WRITE FVA5437B-RECORD */
            FVA5437B.Write(FVA5437B_RECORD.GetMoveValues().ToString());

            /*" -4423- MOVE SPACES TO FVA5437B-RECORD */
            _.Move("", FVA5437B_RECORD);

            /*" -4424- IF WFIM-TABELA NOT = 'S' */

            if (AREA_DE_WORK.WFIM_TABELA != "S")
            {

                /*" -4425- SUBTRACT 1 FROM WIND-88 */
                AREA_DE_WORK.WIND_88.Value = AREA_DE_WORK.WIND_88 - 1;

                /*" -4426- GO TO R2220-10-INI-CERTIFICADO */

                R2220_10_INI_CERTIFICADO(); //GOTO
                return;

                /*" -4426- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-APOLICE-SECTION */
        private void R2230_00_SELECT_APOLICE_SECTION()
        {
            /*" -4436- MOVE '2230' TO WNR-EXEC-SQL. */
            _.Move("2230", WABEND.WNR_EXEC_SQL);

            /*" -4441- PERFORM R2230_00_SELECT_APOLICE_DB_SELECT_1 */

            R2230_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -4444- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4446- DISPLAY '*** VA5437B PROBLEMAS ACESSO APOLICES ' WHOST-NRAPOLICE */
                _.Display($"*** VA5437B PROBLEMAS ACESSO APOLICES {WHOST_NRAPOLICE}");

                /*" -4447- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2230-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R2230_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -4441- EXEC SQL SELECT COD_MODALIDADE INTO :APOLICES-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :WHOST-NRAPOLICE END-EXEC. */

            var r2230_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2230_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(r2230_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-LE-SORT-SECTION */
        private void R2300_00_LE_SORT_SECTION()
        {
            /*" -4457- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -4459- RETURN SVA5437B AT END */
            try
            {
                SVA5437B.Return(REG_SVA5437B, () =>
                {

                    /*" -4460- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -4462- GO TO R2300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -4464- ADD 1 TO AC-LIDOS AC-LIDOS-SORT AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_LIDOS_SORT.Value = AREA_DE_WORK.AC_LIDOS_SORT + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -4476- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", WABEND.WNR_EXEC_SQL);

            /*" -4477- IF (INF > SUP) */

            if ((AREA_DE_WORK.INF > AREA_DE_WORK.SUP))
            {

                /*" -4478- MOVE 'N' TO WTEM-MULTIMSG */
                _.Move("N", AREA_DE_WORK.WTEM_MULTIMSG);

                /*" -4479- ELSE */
            }
            else
            {


                /*" -4480- COMPUTE WS-IND = (SUP + INF) / 2 */
                AREA_DE_WORK.WS_IND.Value = (AREA_DE_WORK.SUP + AREA_DE_WORK.INF) / 2;

                /*" -4481- IF (WS-CHAVE < TABJ-CHAVE(WS-IND)) */

                if ((AREA_DE_WORK.WS_CHAVE < TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE))
                {

                    /*" -4482- COMPUTE SUP = WS-IND - 1 */
                    AREA_DE_WORK.SUP.Value = AREA_DE_WORK.WS_IND - 1;

                    /*" -4483- GO TO R2310-00-IDENTIFICA-MSG */
                    new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4484- ELSE */
                }
                else
                {


                    /*" -4485- IF (WS-CHAVE > TABJ-CHAVE(WS-IND)) */

                    if ((AREA_DE_WORK.WS_CHAVE > TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE))
                    {

                        /*" -4486- COMPUTE INF = WS-IND + 1 */
                        AREA_DE_WORK.INF.Value = AREA_DE_WORK.WS_IND + 1;

                        /*" -4487- GO TO R2310-00-IDENTIFICA-MSG */
                        new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -4488- ELSE */
                    }
                    else
                    {


                        /*" -4489- MOVE 'S' TO WTEM-MULTIMSG */
                        _.Move("S", AREA_DE_WORK.WTEM_MULTIMSG);

                        /*" -4490- END-IF */
                    }


                    /*" -4491- END-IF */
                }


                /*" -4493- END-IF. */
            }


            /*" -4494- MOVE W88-PRODUTO-VIDA TO WS-COD-PRODUTO. */
            _.Move(W88_PRODUTO_VIDA, WS_COD_PRODUTO);

            /*" -4495- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -4497- PERFORM R2320-PRODUTO-RUNOFF */

            R2320_PRODUTO_RUNOFF_SECTION();

            /*" -4498- IF (WTEM-MULTIMSG EQUAL 'S' ) */

            if ((AREA_DE_WORK.WTEM_MULTIMSG == "S"))
            {

                /*" -4500- MOVE TABJ-JDE (WS-IND) TO WS-JDE */
                _.Move(TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -4501- ELSE */
            }
            else
            {


                /*" -4502- PERFORM R2315-00-SELECT-V0MULTIMENS */

                R2315_00_SELECT_V0MULTIMENS_SECTION();

                /*" -4504- MOVE COBMENVG-JDE TO WS-JDE */
                _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -4506- END-IF. */
            }


            /*" -4509- INITIALIZE WS-LC09-JDE */
            _.Initialize(
                AREA_DE_WORK.WS_LC09_JDE
            );

            /*" -4540- IF W88-PRODUTO-VIDA = 0917 OR 9301 OR 9303 OR 9304 OR 9307 OR 9309 OR 9310 OR JVPRD9310 OR 9312 OR 9314 OR JVPRD9314 OR 9318 OR 9319 OR 9320 OR JVPRD9320 OR 9321 OR JVPRD9321 OR 9327 OR JVPRD9327 OR 9328 OR JVPRD9328 OR 9332 OR JVPRD9332 OR 9333 OR 9334 OR JVPRD9334 OR 9351 OR JVPRD9351 OR 9352 OR JVPRD9352 OR 9353 OR JVPRD9353 OR 9356 OR JVPRD9356 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9359 OR JVPRD9359 OR 9360 OR JVPRD9360 OR 9361 OR JVPRD9361 OR 9702 OR 9704 OR 9705 OR 9707 */

            if (W88_PRODUTO_VIDA.In("0917", "9301", "9303", "9304", "9307", "9309", "9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), "9312", "9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9318", "9319", "9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), "9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), "9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9332", JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), "9333", "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9351", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), "9352", JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), "9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9359", JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), "9360", JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), "9361", JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), "9702", "9704", "9705", "9707"))
            {

                /*" -4541- IF COBMENVG-COD-OPERACAO EQUAL 2 */

                if (COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO == 2)
                {

                    /*" -4542- MOVE 'VA54' TO WS-LC09-JDE */
                    _.Move("VA54", AREA_DE_WORK.WS_LC09_JDE);

                    /*" -4543- END-IF */
                }


                /*" -4544- ELSE */
            }
            else
            {


                /*" -4545- MOVE 'VA54' TO WS-LC09-JDE */
                _.Move("VA54", AREA_DE_WORK.WS_LC09_JDE);

                /*" -4547- END-IF. */
            }


            /*" -4550- IF WS-LC09-JDE = 'VA54' */

            if (AREA_DE_WORK.WS_LC09_JDE == "VA54")
            {

                /*" -4551- EVALUATE PRODUTO-COD-EMPRESA */
                switch (PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.Value)
                {

                    /*" -4552- WHEN 10 */
                    case 10:

                        /*" -4554- WHEN 11 */
                        break;
                    case 11:

                        /*" -4556- MOVE 'VA54' TO COBMENVG-JDE WS-JDE */
                        _.Move("VA54", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                        /*" -4558- IF WS-PROD-RUNON */

                        if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                        {

                            /*" -4559- MOVE 'VIDA10' TO COBMENVG-JDE WS-JDE */
                            _.Move("VIDA10", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                            /*" -4560- END-IF */
                        }


                        /*" -4561- WHEN OTHER */
                        break;
                    default:

                        /*" -4562- MOVE 'VA54' TO COBMENVG-JDE WS-JDE */
                        _.Move("VA54", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                        /*" -4563- END-EVALUATE */
                        break;
                }


                /*" -4566- MOVE 'VA' TO COBMENVG-JDL */
                _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                /*" -4566- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-SECTION */
        private void R2315_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -4577- MOVE '2315' TO WNR-EXEC-SQL */
            _.Move("2315", WABEND.WNR_EXEC_SQL);

            /*" -4579- MOVE WS-IDFORM TO COBMENVG-IDFORM. */
            _.Move(AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM);

            /*" -4590- PERFORM R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -4593- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4594- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -4596- MOVE 'VA44' TO COBMENVG-JDE */
                    _.Move("VA44", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                    /*" -4597- IF WS-PROD-RUNON */

                    if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                    {

                        /*" -4598- MOVE 'VIDA05' TO COBMENVG-JDE */
                        _.Move("VIDA05", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                        /*" -4599- END-IF */
                    }


                    /*" -4600- MOVE 'VA' TO COBMENVG-JDL */
                    _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                    /*" -4601- ELSE */
                }
                else
                {


                    /*" -4602- DISPLAY 'R2315 - NAO ENCONTRADO COBRANCA_MENS_VGAP ' */
                    _.Display($"R2315 - NAO ENCONTRADO COBRANCA_MENS_VGAP ");

                    /*" -4603- DISPLAY 'APOLICE     => ' COBMENVG-NUM-APOLICE */
                    _.Display($"APOLICE     => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE}");

                    /*" -4604- DISPLAY 'SUBGRUPO    => ' COBMENVG-CODSUBES */
                    _.Display($"SUBGRUPO    => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES}");

                    /*" -4605- DISPLAY 'OPERACAO    => ' WHOST-CODOPER */
                    _.Display($"OPERACAO    => {WHOST_CODOPER}");

                    /*" -4606- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4607- END-IF */
                }


                /*" -4607- END-IF. */
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -4590- EXEC SQL SELECT JDE, JDL INTO :COBMENVG-JDE, :COBMENVG-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = :COBMENVG-IDFORM AND NUM_APOLICE = :COBMENVG-NUM-APOLICE AND CODSUBES = :COBMENVG-CODSUBES AND COD_OPERACAO = :COBMENVG-COD-OPERACAO WITH UR END-EXEC. */

            var r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 = new R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1()
            {
                COBMENVG_COD_OPERACAO = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO.ToString(),
                COBMENVG_NUM_APOLICE = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE.ToString(),
                COBMENVG_CODSUBES = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES.ToString(),
                COBMENVG_IDFORM = COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM.ToString(),
            };

            var executed_1 = R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1.Execute(r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBMENVG_JDE, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);
                _.Move(executed_1.COBMENVG_JDL, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2315_99_SAIDA*/

        [StopWatch]
        /*" R2320-PRODUTO-RUNOFF-SECTION */
        private void R2320_PRODUTO_RUNOFF_SECTION()
        {
            /*" -4615- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -4617- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -4618- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -4619- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -4620- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -4622- END-SEARCH */

                    /*" -4622- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2320_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-SECTION */
        private void R2400_00_BENEFICIARIOS_SECTION()
        {
            /*" -4633- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -4634- MOVE 'N' TO WFIM-BENEFICIA. */
            _.Move("N", AREA_DE_WORK.WFIM_BENEFICIA);

            /*" -4636- MOVE ZEROS TO WIND-99. */
            _.Move(0, AREA_DE_WORK.WIND_99);

            /*" -4645- PERFORM R2400_00_BENEFICIARIOS_DB_DECLARE_1 */

            R2400_00_BENEFICIARIOS_DB_DECLARE_1();

            /*" -4654- PERFORM R2400_00_BENEFICIARIOS_DB_OPEN_1 */

            R2400_00_BENEFICIARIOS_DB_OPEN_1();

            /*" -4657- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4658- DISPLAY 'VA5437B - ERRO OPEN CURSOR V0BENEF' */
                _.Display($"VA5437B - ERRO OPEN CURSOR V0BENEF");

                /*" -4659- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -4660- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4662- END-IF. */
            }


            /*" -4663- PERFORM R2410-00-FETCH-V0BENEF UNTIL WFIM-BENEFICIA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_BENEFICIA == "S"))
            {

                R2410_00_FETCH_V0BENEF_SECTION();
            }

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-OPEN-1 */
        public void R2400_00_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -4654- EXEC SQL OPEN V0BENEF END-EXEC. */

            V0BENEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-SECTION */
        private void R2410_00_FETCH_V0BENEF_SECTION()
        {
            /*" -4674- MOVE '2410' TO WNR-EXEC-SQL. */
            _.Move("2410", WABEND.WNR_EXEC_SQL);

            /*" -4679- PERFORM R2410_00_FETCH_V0BENEF_DB_FETCH_1 */

            R2410_00_FETCH_V0BENEF_DB_FETCH_1();

            /*" -4682- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4683- MOVE 'S' TO WFIM-BENEFICIA */
                _.Move("S", AREA_DE_WORK.WFIM_BENEFICIA);

                /*" -4683- PERFORM R2410_00_FETCH_V0BENEF_DB_CLOSE_1 */

                R2410_00_FETCH_V0BENEF_DB_CLOSE_1();

                /*" -4685- MOVE 'HERDEIROS LEGAIS' TO LC11-NOME-BENEF(1) */
                _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_NOME_BENEF);

                /*" -4686- MOVE 'OUTROS' TO LC11-PARENTESCO(1) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARENTESCO);

                /*" -4687- MOVE 100 TO LC11-PARTICIP (1) */
                _.Move(100, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARTICIP);

                /*" -4689- GO TO R2410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4691- ADD 1 TO WIND-99. */
            AREA_DE_WORK.WIND_99.Value = AREA_DE_WORK.WIND_99 + 1;

            /*" -4693- MOVE BENEFICI-NOME-BENEFICIARIO TO TB99-NOME-BENEF (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_NOME_BENEF);

            /*" -4695- MOVE BENEFICI-GRAU-PARENTESCO TO TB99-PARENTESCO (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_PARENTESCO);

            /*" -4696- MOVE BENEFICI-PCT-PART-BENEFICIA TO TB99-PARTICIP (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_PARTICIP);

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-FETCH-1 */
        public void R2410_00_FETCH_V0BENEF_DB_FETCH_1()
        {
            /*" -4679- EXEC SQL FETCH V0BENEF INTO :BENEFICI-NOME-BENEFICIARIO, :BENEFICI-GRAU-PARENTESCO, :BENEFICI-PCT-PART-BENEFICIA END-EXEC. */

            if (V0BENEF.Fetch())
            {
                _.Move(V0BENEF.BENEFICI_NOME_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);
                _.Move(V0BENEF.BENEFICI_GRAU_PARENTESCO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO);
                _.Move(V0BENEF.BENEFICI_PCT_PART_BENEFICIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA);
            }

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-CLOSE-1 */
        public void R2410_00_FETCH_V0BENEF_DB_CLOSE_1()
        {
            /*" -4683- EXEC SQL CLOSE V0BENEF END-EXEC */

            V0BENEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-SECTION */
        private void R2500_00_UPDATE_RELATORI_SECTION()
        {
            /*" -4707- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -4718- PERFORM R2500_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -4721- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4721- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2500_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -4718- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = :WHOST-CODRELAT AND SIT_REGISTRO = '0' AND COD_OPERACAO IN (2,6,10) AND NUM_PARCELA = 2 AND NUM_CERTIFICADO = :WHOST-NRCERTIF END-EXEC. */

            var r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                WHOST_CODRELAT = WHOST_CODRELAT.ToString(),
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r2500_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2650-00-BUSCA-FONTE-SECTION */
        private void R2650_00_BUSCA_FONTE_SECTION()
        {
            /*" -4732- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -4733- IF SVA-FONTE EQUAL 10 */

            if (REG_SVA5437B.SVA_FONTE == 10)
            {

                /*" -4734- MOVE 'MATRIZ' TO LC11-REMETENTE-G */
                _.Move("MATRIZ", AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G);

                /*" -4735- ELSE */
            }
            else
            {


                /*" -4736- MOVE 'FILIAL' TO LC11-REMETENTE-S */
                _.Move("FILIAL", AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G.LC11_REMETENTE_S);

                /*" -4739- MOVE TAB-NOMEFTE (SVA-FONTE) TO LC11-REMETENTE. */
                _.Move(TAB_FILIAL.FILLER_127[REG_SVA5437B.SVA_FONTE].TAB_NOMEFTE, AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G.LC11_REMETENTE);
            }


            /*" -4741- MOVE TAB-ENDERFTE(SVA-FONTE) TO LC11-ENDERECO-REM */
            _.Move(TAB_FILIAL.FILLER_127[REG_SVA5437B.SVA_FONTE].TAB_ENDERFTE, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_REM);

            /*" -4743- MOVE TAB-BAIRRO (SVA-FONTE) TO LC11-BAIRRO-REM */
            _.Move(TAB_FILIAL.FILLER_127[REG_SVA5437B.SVA_FONTE].TAB_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO_REM);

            /*" -4745- MOVE TAB-CIDADE (SVA-FONTE) TO LC11-CIDADE-REM */
            _.Move(TAB_FILIAL.FILLER_127[REG_SVA5437B.SVA_FONTE].TAB_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_REM);

            /*" -4747- MOVE TAB-UF (SVA-FONTE) TO LC11-UF-REM */
            _.Move(TAB_FILIAL.FILLER_127[REG_SVA5437B.SVA_FONTE].TAB_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF_REM);

            /*" -4749- MOVE TAB-CEP (SVA-FONTE) TO DEST-NUM-CEP */
            _.Move(TAB_FILIAL.FILLER_127[REG_SVA5437B.SVA_FONTE].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

            /*" -4750- MOVE DEST-CEP TO LC11-CEP-REM */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_REM);

            /*" -4750- MOVE DEST-CEP-COMPL TO LC11-CEP-COMPL-REM. */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL_REM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-PRODUVG-SECTION */
        private void R2700_00_SELECT_PRODUVG_SECTION()
        {
            /*" -4761- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -4770- PERFORM R2700_00_SELECT_PRODUVG_DB_SELECT_1 */

            R2700_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -4773- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4774- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ' */
                _.Display($"R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ");

                /*" -4776- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                .Display();

                /*" -4776- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R2700_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -4770- EXEC SQL SELECT NOME_PRODUTO, COD_PRODUTO INTO :PRODUVG-NOME-PRODUTO, :PRODUVG-COD-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES WITH UR END-EXEC. */

            var r2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-SECTION */
        private void R2710_00_SELECT_ESTIP_SECTION()
        {
            /*" -4787- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WABEND.WNR_EXEC_SQL);

            /*" -4795- PERFORM R2710_00_SELECT_ESTIP_DB_SELECT_1 */

            R2710_00_SELECT_ESTIP_DB_SELECT_1();

            /*" -4798- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4799- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4800- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -4801- ELSE */
                }
                else
                {


                    /*" -4802- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A CLIENTES ' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A CLIENTES ");

                    /*" -4804- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -4804- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-DB-SELECT-1 */
        public void R2710_00_SELECT_ESTIP_DB_SELECT_1()
        {
            /*" -4795- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.APOLICES A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE AND B.COD_CLIENTE = A.COD_CLIENTE WITH UR END-EXEC. */

            var r2710_00_SELECT_ESTIP_DB_SELECT_1_Query1 = new R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2710_00_SELECT_ESTIP_DB_SELECT_1_Query1.Execute(r2710_00_SELECT_ESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2715-00-SELECT-SUBESTIP-SECTION */
        private void R2715_00_SELECT_SUBESTIP_SECTION()
        {
            /*" -4815- MOVE '2715' TO WNR-EXEC-SQL. */
            _.Move("2715", WABEND.WNR_EXEC_SQL);

            /*" -4822- PERFORM R2715_00_SELECT_SUBESTIP_DB_SELECT_1 */

            R2715_00_SELECT_SUBESTIP_DB_SELECT_1();

            /*" -4825- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4826- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4827- MOVE SPACES TO SUBGVGAP-OPCAO-CONJUGE */
                    _.Move("", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);

                    /*" -4828- ELSE */
                }
                else
                {


                    /*" -4829- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A SUBGVGAP    ' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A SUBGVGAP    ");

                    /*" -4831- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -4833- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4834- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '1' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "1")
            {

                /*" -4835- MOVE 'OPCIONAL' TO LC11-OPCAO-CONJ */
                _.Move("OPCIONAL", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                /*" -4836- ELSE */
            }
            else
            {


                /*" -4837- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '2' */

                if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "2")
                {

                    /*" -4838- MOVE 'OBRIGATORIO' TO LC11-OPCAO-CONJ */
                    _.Move("OBRIGATORIO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                    /*" -4839- ELSE */
                }
                else
                {


                    /*" -4840- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '3' */

                    if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "3")
                    {

                        /*" -4841- MOVE 'SEM CONJUGE' TO LC11-OPCAO-CONJ */
                        _.Move("SEM CONJUGE", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                        /*" -4842- ELSE */
                    }
                    else
                    {


                        /*" -4842- MOVE 'OUTROS' TO LC11-OPCAO-CONJ. */
                        _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);
                    }

                }

            }


        }

        [StopWatch]
        /*" R2715-00-SELECT-SUBESTIP-DB-SELECT-1 */
        public void R2715_00_SELECT_SUBESTIP_DB_SELECT_1()
        {
            /*" -4822- EXEC SQL SELECT OPCAO_CONJUGE INTO :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES WITH UR END-EXEC. */

            var r2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1 = new R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1.Execute(r2715_00_SELECT_SUBESTIP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2715_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-SECTION */
        private void R2750_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -4854- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WABEND.WNR_EXEC_SQL);

            /*" -4856- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -4866- PERFORM R2750_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R2750_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -4869- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4870- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4871- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -4873- MOVE ZEROS TO HISCOBPR-QTMDIT VIND-QTMDIT */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT, VIND_QTMDIT);

                    /*" -4874- ELSE */
                }
                else
                {


                    /*" -4876- DISPLAY '*** VA5437B PROBLEMAS ACESSO HIS_COBER_PROPOST' WHOST-NRCERTIF */
                    _.Display($"*** VA5437B PROBLEMAS ACESSO HIS_COBER_PROPOST{WHOST_NRCERTIF}");

                    /*" -4878- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4879- IF VIND-QTMDIT LESS ZEROES */

            if (VIND_QTMDIT < 00)
            {

                /*" -4879- MOVE ZEROES TO HISCOBPR-QTMDIT. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
            }


        }

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R2750_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -4866- EXEC SQL SELECT QTMDIT INTO :HISCOBPR-QTMDIT:VIND-QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE WITH UR END-EXEC. */

            var r2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_QTMDIT, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
                _.Move(executed_1.VIND_QTMDIT, VIND_QTMDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R2760-00-SELECT-PRODUTO-SECTION */
        private void R2760_00_SELECT_PRODUTO_SECTION()
        {
            /*" -4890- MOVE '2760' TO WNR-EXEC-SQL. */
            _.Move("2760", WABEND.WNR_EXEC_SQL);

            /*" -4900- PERFORM R2760_00_SELECT_PRODUTO_DB_SELECT_1 */

            R2760_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -4903- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4904- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4905- MOVE SPACES TO PRODUTO-NUM-PROCESSO-SUSEP */
                    _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);

                    /*" -4906- ELSE */
                }
                else
                {


                    /*" -4908- DISPLAY '*** VA5437B PROBLEMAS ACESSO A PRODUTO ' WHOST-NRCERTIF ' ' */

                    $"*** VA5437B PROBLEMAS ACESSO A PRODUTO {WHOST_NRCERTIF} "
                    .Display();

                    /*" -4909- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2760-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R2760_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -4900- EXEC SQL SELECT DESCR_PRODUTO, COD_PRODUTO, NUM_PROCESSO_SUSEP INTO :PRODUTO-DESCR-PRODUTO, :PRODUTO-COD-PRODUTO, :PRODUTO-NUM-PROCESSO-SUSEP FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUVG-COD-PRODUTO WITH UR END-EXEC. */

            var r2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
            };

            var executed_1 = R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_NUM_PROCESSO_SUSEP, PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2760_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-SEGURVGA-SECTION */
        private void R2800_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -4919- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -4932- PERFORM R2800_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R2800_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -4935- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4936- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4938- DISPLAY '*** VA5437B DESPREZADO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VA5437B DESPREZADO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -4939- ELSE */
                }
                else
                {


                    /*" -4941- DISPLAY '*** VA5437B PROBLEMAS ACESSO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VA5437B PROBLEMAS ACESSO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -4941- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R2800_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -4932- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-SECTION */
        private void R2910_00_OBTEM_NUMERACAO_SECTION()
        {
            /*" -4952- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WABEND.WNR_EXEC_SQL);

            /*" -4960- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -4963- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4964- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4966- MOVE ZEROS TO RELATORI-NUM-COPIAS */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                    /*" -4967- ELSE */
                }
                else
                {


                    /*" -4968- DISPLAY 'R2910 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT RELATORIOS");

                    /*" -4970- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4971- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -4972- MOVE ZEROS TO RELATORI-NUM-COPIAS. */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -4960- EXEC SQL SELECT MAX(NUM_COPIAS) INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER WITH UR END-EXEC. */

            var r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1 = new R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1()
            {
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
            };

            var executed_1 = R2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1.Execute(r2910_00_OBTEM_NUMERACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_NUM_COPIAS, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
                _.Move(executed_1.VIND_NRCOPIAS, VIND_NRCOPIAS);
            }


        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO */
        private void R2910_10_INCLUI_RELATORIO(bool isPerform = false)
        {
            /*" -4978- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -4981- ADD 1 TO RELATORI-NUM-COPIAS. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS + 1;

            /*" -5024- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -5027- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -5028- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -5030- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5031- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5032- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -5034- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5034- ADD 1 TO AC-I-RELATORI. */
            AREA_DE_WORK.AC_I_RELATORI.Value = AREA_DE_WORK.AC_I_RELATORI + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -5024- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'EM0600B' , :SISTEMAS-DATA-MOV-ABERTO, 'EM' , 'CARTAECT' , :RELATORI-NUM-COPIAS, 0, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                V1SIST_MESREFER = V1SIST_MESREFER.ToString(),
                V1SIST_ANOREFER = V1SIST_ANOREFER.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1.Execute(r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-00-CALC-DIAS-UTEIS-SECTION */
        private void R2920_00_CALC_DIAS_UTEIS_SECTION()
        {
            /*" -5045- MOVE '2920' TO WNR-EXEC-SQL. */
            _.Move("2920", WABEND.WNR_EXEC_SQL);

            /*" -5046- MOVE LK-DATA-CALC TO LK-DATA-SOM. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_SOM);

            /*" -5047- MOVE 3 TO LK-QTDIAS. */
            _.Move(3, AREA_DE_WORK.LK_PROSOMU1.LK_QTDIAS);

            /*" -5047- CALL 'PROSOCU1' USING LK-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.LK_PROSOMU1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-BUSCA-NOM-SOCIAL-SECTION */
        private void R4000_00_BUSCA_NOM_SOCIAL_SECTION()
        {
            /*" -5058- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -5080- INITIALIZE LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
            _.Initialize(
                SPGE053W.LK_GE053_E_TRACE
                , SPGE053W.LK_GE053_E_IDE_SISTEMA
                , SPGE053W.LK_GE053_E_IND_OPERACAO
                , SPGE053W.LK_GE053_I_NUM_CPF
                , SPGE053W.LK_GE053_I_DTH_OPERACAO
                , SPGE053W.LK_GE053_I_NOM_SOCIAL
                , SPGE053W.LK_GE053_I_IND_TIPO_ACAO
                , SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL
                , SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO
                , SPGE053W.LK_GE053_I_NUM_PROPOSTA
                , SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM
                , SPGE053W.LK_GE053_I_NUM_MATRICULA
                , SPGE053W.LK_GE053_I_NOM_PROGRAMA
                , SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO
                , SPGE053W.LK_GE053_IND_ERRO
                , SPGE053W.LK_GE053_ID_ERRO
                , SPGE053W.LK_GE053_MENSAGEM
                , SPGE053W.LK_GE053_NOM_TABELA
                , SPGE053W.LK_GE053_SQLCODE
                , SPGE053W.LK_GE053_SQLERRMC
                , SPGE053W.LK_GE053_SQLSTATE
            );

            /*" -5081- MOVE 'N' TO LK-GE053-E-TRACE */
            _.Move("N", SPGE053W.LK_GE053_E_TRACE);

            /*" -5082- MOVE 'VA' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("VA", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -5083- MOVE 2 TO LK-GE053-E-IND-OPERACAO */
            _.Move(2, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -5085- MOVE SVA-CPF TO LK-GE053-I-NUM-CPF */
            _.Move(REG_SVA5437B.SVA_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -5107- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
            _.Call("SPBGE053", SPGE053W);

            /*" -5109- . */

            /*" -5110- MOVE LK-GE053-SQLCODE TO WS-RETURN-CODE. */
            _.Move(SPGE053W.LK_GE053_SQLCODE, WS_RETURN_CODE);

            /*" -5112- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -5114- IF (LK-GE053-SQLCODE NOT EQUAL ZEROS) AND (LK-GE053-SQLCODE NOT EQUAL 100) */

            if ((SPGE053W.LK_GE053_SQLCODE != 00) && (SPGE053W.LK_GE053_SQLCODE != 100))
            {

                /*" -5115- DISPLAY 'ERRO SUBROTINA SPBGE053' */
                _.Display($"ERRO SUBROTINA SPBGE053");

                /*" -5116- DISPLAY 'LK-GE053-MENSAGEM      ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM      {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -5117- DISPLAY 'LK-GE053-SQLCODE       ' LK-GE053-SQLCODE */
                _.Display($"LK-GE053-SQLCODE       {SPGE053W.LK_GE053_SQLCODE}");

                /*" -5118- DISPLAY 'LK-GE053-E-IDE-SISTEMA ' LK-GE053-E-TRACE */
                _.Display($"LK-GE053-E-IDE-SISTEMA {SPGE053W.LK_GE053_E_TRACE}");

                /*" -5119- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IDE-SISTEMA */
                _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

                /*" -5120- DISPLAY 'LK-GE053-E-TRACE       ' LK-GE053-E-IND-OPERACAO */
                _.Display($"LK-GE053-E-TRACE       {SPGE053W.LK_GE053_E_IND_OPERACAO}");

                /*" -5121- DISPLAY 'LK-GE053-I-NUM-CPF     ' LK-GE053-I-NUM-CPF */
                _.Display($"LK-GE053-I-NUM-CPF     {SPGE053W.LK_GE053_I_NUM_CPF}");

                /*" -5122- DISPLAY 'ERRO INESPERADO SUBROTINA SPBGE053' */
                _.Display($"ERRO INESPERADO SUBROTINA SPBGE053");

                /*" -5123- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5125- END-IF */
            }


            /*" -5126- IF LK-GE053-I-NOM-SOCIAL NOT EQUAL SPACES */

            if (!SPGE053W.LK_GE053_I_NOM_SOCIAL.IsEmpty())
            {

                /*" -5127- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-NOME-RAZAO-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC);

                /*" -5128- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-NOME-RAZAO-END-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END_SOC);

                /*" -5129- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-CLIENTE-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

                /*" -5130- ELSE */
            }
            else
            {


                /*" -5131- MOVE SPACES TO LC11-NOME-RAZAO-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC);

                /*" -5132- MOVE SPACES TO LC11-NOME-RAZAO-END-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END_SOC);

                /*" -5133- MOVE SPACES TO LC11-CLIENTE-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

                /*" -5135- END-IF */
            }


            /*" -5136- DISPLAY 'LK-GE053-E-TRACE        ' LK-GE053-E-TRACE */
            _.Display($"LK-GE053-E-TRACE        {SPGE053W.LK_GE053_E_TRACE}");

            /*" -5137- DISPLAY 'LK-GE053-E-IDE-SISTEMA  ' LK-GE053-E-IDE-SISTEMA */
            _.Display($"LK-GE053-E-IDE-SISTEMA  {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

            /*" -5138- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IND-OPERACAO */
            _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IND_OPERACAO}");

            /*" -5139- DISPLAY 'LK-GE053-I-NUM-CPF      ' LK-GE053-I-NUM-CPF */
            _.Display($"LK-GE053-I-NUM-CPF      {SPGE053W.LK_GE053_I_NUM_CPF}");

            /*" -5140- DISPLAY 'LK-GE053-I-NOM-SOCIAL   ' LK-GE053-I-NOM-SOCIAL */
            _.Display($"LK-GE053-I-NOM-SOCIAL   {SPGE053W.LK_GE053_I_NOM_SOCIAL}");

            /*" -5141- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-PRIMEIRO-NOME-SOCIAL-SECTION */
        private void R4100_00_PRIMEIRO_NOME_SOCIAL_SECTION()
        {
            /*" -5152- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WABEND.WNR_EXEC_SQL);

            /*" -5153- MOVE 1 TO WIND-N-S. */
            _.Move(1, AREA_DE_WORK.WIND_N_S);

            /*" -0- FLUXCONTROL_PERFORM R4100_10_LOOP */

            R4100_10_LOOP();

        }

        [StopWatch]
        /*" R4100-10-LOOP */
        private void R4100_10_LOOP(bool isPerform = false)
        {
            /*" -5157- IF WIND-N-S GREATER 100 */

            if (AREA_DE_WORK.WIND_N_S > 100)
            {

                /*" -5158- DISPLAY '*** VA3437B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA3437B TAB NOMES ESTOURADA ");

                /*" -5159- GO TO R4100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/ //GOTO
                return;

                /*" -5161- END-IF */
            }


            /*" -5163- IF (TAB-NOME-SOC(WIND-N-S) EQUAL SPACES) AND (WIND-N-S EQUAL 1) */

            if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] == string.Empty) && (AREA_DE_WORK.WIND_N_S == 1))
            {

                /*" -5164- ADD 1 TO WIND-N-S */
                AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                /*" -5165- GO TO R4100-10-LOOP */
                new Task(() => R4100_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5166- ELSE */
            }
            else
            {


                /*" -5169- IF (TAB-NOME-SOC(WIND-N-S) EQUAL SPACES) AND (WIND-N-S EQUAL 2) */

                if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] == string.Empty) && (AREA_DE_WORK.WIND_N_S == 2))
                {

                    /*" -5170- ADD 1 TO WIND-N-S */
                    AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                    /*" -5171- GO TO R4100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/ //GOTO
                    return;

                    /*" -5172- END-IF */
                }


                /*" -5174- END-IF */
            }


            /*" -5175- IF (TAB-NOME-SOC(WIND-N-S) NOT EQUAL SPACES) */

            if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] != string.Empty))
            {

                /*" -5176- MOVE TAB-NOME-SOC (WIND-N-S) TO TAB-NOME1-SOC(WIND-N-S) */
                _.Move(TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S], TABELA_NOMES1_SOC.TAB_NOMES1_SOC_R.TAB_NOME1_SOC[AREA_DE_WORK.WIND_N_S]);

                /*" -5177- ADD 1 TO WIND-N-S */
                AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                /*" -5178- GO TO R4100-10-LOOP */
                new Task(() => R4100_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5180- END-IF */
            }


            /*" -5182- MOVE ',' TO TAB-NOME1-SOC(WIND-N-S) */
            _.Move(",", TABELA_NOMES1_SOC.TAB_NOMES1_SOC_R.TAB_NOME1_SOC[AREA_DE_WORK.WIND_N_S]);

            /*" -5184- MOVE SPACES TO TABELA-NOMES1-SOC(WIND-N-S + 1:100 - WIND-N-S) */
            _.MoveAtPosition("", TABELA_NOMES1_SOC, AREA_DE_WORK.WIND_N_S + 1, 100 - AREA_DE_WORK.WIND_N_S);

            /*" -5185- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -5195- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -5200- OPEN OUTPUT RVA5437B FVA5437B IMP5437B PDF5437B VDHTML01 VDHTML09. */
            RVA5437B.Open(RVA5437B_RECORD);
            FVA5437B.Open(FVA5437B_RECORD);
            IMP5437B.Open(IMP5437B_RECORD);
            PDF5437B.Open(PDF5437B_RECORD);
            VDHTML01.Open(VDHTML01_RECORD);
            VDHTML09.Open(VDHTML09_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -5211- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -5216- CLOSE RVA5437B FVA5437B IMP5437B PDF5437B VDHTML01 VDHTML09. */
            RVA5437B.Close();
            FVA5437B.Close();
            IMP5437B.Close();
            PDF5437B.Close();
            VDHTML01.Close();
            VDHTML09.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9155-00-GRAVA-LINHAS-UNIC-SECTION */
        private void R9155_00_GRAVA_LINHAS_UNIC_SECTION()
        {
            /*" -5227- IF (WS-LINHAS-UNIC = 10) */

            if ((WS_LINHAS_UNIC == 10))
            {

                /*" -5228- WRITE RVA5437B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA5437B_RECORD);

                RVA5437B.Write(RVA5437B_RECORD.GetMoveValues().ToString());

                /*" -5229- WRITE RVA5437B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA5437B_RECORD);

                RVA5437B.Write(RVA5437B_RECORD.GetMoveValues().ToString());

                /*" -5230- WRITE RVA5437B-RECORD FROM LC09-LINHA09 */
                _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA5437B_RECORD);

                RVA5437B.Write(RVA5437B_RECORD.GetMoveValues().ToString());

                /*" -5232- WRITE RVA5437B-RECORD FROM LC10-LINHA10 */
                _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA5437B_RECORD);

                RVA5437B.Write(RVA5437B_RECORD.GetMoveValues().ToString());

                /*" -5233- EVALUATE WS-TIPO-ARQ-SAIDA */
                switch (WS_TIPO_ARQ_SAIDA.Value.Trim())
                {

                    /*" -5234- WHEN 'I' */
                    case "I":

                        /*" -5235- WHEN 'GERAL' */
                        break;
                    case "GERAL":

                        /*" -5236- WRITE IMP5437B-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), IMP5437B_RECORD);

                        IMP5437B.Write(IMP5437B_RECORD.GetMoveValues().ToString());

                        /*" -5237- WRITE IMP5437B-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), IMP5437B_RECORD);

                        IMP5437B.Write(IMP5437B_RECORD.GetMoveValues().ToString());

                        /*" -5238- WRITE IMP5437B-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), IMP5437B_RECORD);

                        IMP5437B.Write(IMP5437B_RECORD.GetMoveValues().ToString());

                        /*" -5239- WRITE IMP5437B-RECORD FROM LC10-LINHA10 */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), IMP5437B_RECORD);

                        IMP5437B.Write(IMP5437B_RECORD.GetMoveValues().ToString());

                        /*" -5240- WHEN 'P' */
                        break;
                    case "P":

                        /*" -5241- WRITE PDF5437B-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), PDF5437B_RECORD);

                        PDF5437B.Write(PDF5437B_RECORD.GetMoveValues().ToString());

                        /*" -5242- WRITE PDF5437B-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), PDF5437B_RECORD);

                        PDF5437B.Write(PDF5437B_RECORD.GetMoveValues().ToString());

                        /*" -5243- WRITE PDF5437B-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), PDF5437B_RECORD);

                        PDF5437B.Write(PDF5437B_RECORD.GetMoveValues().ToString());

                        /*" -5244- WRITE PDF5437B-RECORD FROM LC10-LINHA10 */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), PDF5437B_RECORD);

                        PDF5437B.Write(PDF5437B_RECORD.GetMoveValues().ToString());

                        /*" -5245- WHEN 'VDHTML01' */
                        break;
                    case "VDHTML01":

                    /*" -5246- WHEN 'VIDA05E' */
                    case "VIDA05E":

                        /*" -5247- WRITE VDHTML01-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5248- WRITE VDHTML01-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5249- WRITE VDHTML01-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5250- WRITE VDHTML01-RECORD FROM LC10-LINHTML */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.LC10_LINHTML.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5251- WHEN 'VDHTML09' */
                        break;
                    case "VDHTML09":

                    /*" -5252- WHEN 'VIDA012E' */
                    case "VIDA012E":

                        /*" -5253- WRITE VDHTML09-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5254- WRITE VDHTML09-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5255- WRITE VDHTML09-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5256- WRITE VDHTML09-RECORD FROM LC10-LINHTML */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.LC10_LINHTML.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5257- END-EVALUATE */
                        break;
                }


                /*" -5259- END-IF */
            }


            /*" -5260- IF (WS-LINHAS-UNIC = 11) */

            if ((WS_LINHAS_UNIC == 11))
            {

                /*" -5262- WRITE RVA5437B-RECORD FROM LC11-LINHA11 */
                _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA5437B_RECORD);

                RVA5437B.Write(RVA5437B_RECORD.GetMoveValues().ToString());

                /*" -5263- EVALUATE WS-TIPO-ARQ-SAIDA */
                switch (WS_TIPO_ARQ_SAIDA.Value.Trim())
                {

                    /*" -5264- WHEN 'I' */
                    case "I":

                        /*" -5265- WHEN 'GERAL' */
                        break;
                    case "GERAL":

                        /*" -5266- WRITE IMP5437B-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), IMP5437B_RECORD);

                        IMP5437B.Write(IMP5437B_RECORD.GetMoveValues().ToString());

                        /*" -5267- WHEN 'P' */
                        break;
                    case "P":

                        /*" -5268- WRITE PDF5437B-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), PDF5437B_RECORD);

                        PDF5437B.Write(PDF5437B_RECORD.GetMoveValues().ToString());

                        /*" -5269- WHEN 'VDHTML01' */
                        break;
                    case "VDHTML01":

                    /*" -5270- WHEN 'VIDA05E' */
                    case "VIDA05E":

                        /*" -5271- INSPECT LC11-LINHA11 REPLACING ALL ';' BY ' ' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", " ");

                        /*" -5272- INSPECT LC11-LINHA11 REPLACING ALL '|' BY ';' */
                        AREA_DE_WORK.LC11_LINHA11.Replace("|", ";");

                        /*" -5273- WRITE VDHTML01-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5274- INSPECT LC11-LINHA11 REPLACING ALL ';' BY '|' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", "|");

                        /*" -5275- WHEN 'VDHTML09' */
                        break;
                    case "VDHTML09":

                    /*" -5276- WHEN 'VIDA012E' */
                    case "VIDA012E":

                        /*" -5277- INSPECT LC11-LINHA11 REPLACING ALL ';' BY ' ' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", " ");

                        /*" -5278- INSPECT LC11-LINHA11 REPLACING ALL '|' BY ';' */
                        AREA_DE_WORK.LC11_LINHA11.Replace("|", ";");

                        /*" -5279- WRITE VDHTML09-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5280- INSPECT LC11-LINHA11 REPLACING ALL ';' BY '|' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", "|");

                        /*" -5281- END-EVALUATE */
                        break;
                }


                /*" -5283- END-IF. */
            }


            /*" -5284- IF (WS-LINHAS-UNIC = 12) */

            if ((WS_LINHAS_UNIC == 12))
            {

                /*" -5286- WRITE RVA5437B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA5437B_RECORD);

                RVA5437B.Write(RVA5437B_RECORD.GetMoveValues().ToString());

                /*" -5287- EVALUATE WS-TIPO-ARQ-SAIDA */
                switch (WS_TIPO_ARQ_SAIDA.Value.Trim())
                {

                    /*" -5288- WHEN 'I' */
                    case "I":

                        /*" -5289- WHEN 'GERAL' */
                        break;
                    case "GERAL":

                        /*" -5290- WRITE IMP5437B-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), IMP5437B_RECORD);

                        IMP5437B.Write(IMP5437B_RECORD.GetMoveValues().ToString());

                        /*" -5291- WHEN 'P' */
                        break;
                    case "P":

                        /*" -5292- WRITE PDF5437B-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), PDF5437B_RECORD);

                        PDF5437B.Write(PDF5437B_RECORD.GetMoveValues().ToString());

                        /*" -5293- WHEN 'VDHTML01' */
                        break;
                    case "VDHTML01":

                    /*" -5294- WHEN 'VIDA05E' */
                    case "VIDA05E":

                        /*" -5295- WRITE VDHTML01-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5296- WHEN 'VDHTML09' */
                        break;
                    case "VDHTML09":

                    /*" -5297- WHEN 'VIDA012E' */
                    case "VIDA012E":

                        /*" -5298- WRITE VDHTML09-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5299- END-EVALUATE */
                        break;
                }


                /*" -5300- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9155_99_SAIDA*/

        [StopWatch]
        /*" R9200-00-PESQUISA-FORMULARIO-SECTION */
        private void R9200_00_PESQUISA_FORMULARIO_SECTION()
        {
            /*" -5311- MOVE '9200' TO WNR-EXEC-SQL. */
            _.Move("9200", WABEND.WNR_EXEC_SQL);

            /*" -5312- MOVE SVA-PRODUTO TO RELATORI-COD-PLANO */
            _.Move(REG_SVA5437B.SVA_PRODUTO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -5313- MOVE SVA-JDE TO RELATORI-COD-RELATORIO */
            _.Move(REG_SVA5437B.SVA_JDE, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -5314- MOVE SPACES TO RELATORI-TIPO-CORRECAO */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);

            /*" -5316- MOVE SPACES TO RELATORI-NUM-APOL-LIDER */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);

            /*" -5328- PERFORM R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1 */

            R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1();

            /*" -5331- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5332- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5333- MOVE 'GERAL' TO SVA-TP-ARQSAIDA */
                    _.Move("GERAL", REG_SVA5437B.SVA_TP_ARQSAIDA);

                    /*" -5334- GO TO R9200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_FIM*/ //GOTO
                    return;

                    /*" -5335- ELSE */
                }
                else
                {


                    /*" -5336- DISPLAY 'R9200 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R9200 - PROBLEMAS SELECT RELATORIOS");

                    /*" -5337- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5338- END-IF */
                }


                /*" -5340- END-IF */
            }


            /*" -5341- IF (RELATORI-NUM-APOL-LIDER EQUAL SPACES) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty()))
            {

                /*" -5342- MOVE RELATORI-TIPO-CORRECAO TO SVA-TP-ARQSAIDA */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO, REG_SVA5437B.SVA_TP_ARQSAIDA);

                /*" -5343- ELSE */
            }
            else
            {


                /*" -5344- IF (CLIENEMA-EMAIL NOT EQUAL SPACES) */

                if ((!CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL.IsEmpty()))
                {

                    /*" -5345- MOVE RELATORI-NUM-APOL-LIDER TO SVA-TP-ARQSAIDA */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, REG_SVA5437B.SVA_TP_ARQSAIDA);

                    /*" -5346- ELSE */
                }
                else
                {


                    /*" -5347- MOVE RELATORI-TIPO-CORRECAO TO SVA-TP-ARQSAIDA */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO, REG_SVA5437B.SVA_TP_ARQSAIDA);

                    /*" -5348- END-IF */
                }


                /*" -5350- END-IF. */
            }


            /*" -5351- IF (SVA-CODOPER EQUAL '2' ) */

            if ((REG_SVA5437B.SVA_CODOPER == "2"))
            {

                /*" -5352- MOVE 'P' TO SVA-TP-ARQSAIDA */
                _.Move("P", REG_SVA5437B.SVA_TP_ARQSAIDA);

                /*" -5353- END-IF. */
            }


        }

        [StopWatch]
        /*" R9200-00-PESQUISA-FORMULARIO-DB-SELECT-1 */
        public void R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1()
        {
            /*" -5328- EXEC SQL SELECT TIPO_CORRECAO , NUM_APOL_LIDER INTO :RELATORI-TIPO-CORRECAO , :RELATORI-NUM-APOL-LIDER FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VG' AND NUM_APOLICE = 9999999999999 AND COD_SUBGRUPO = 9999 AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_PLANO = :RELATORI-COD-PLANO WITH UR END-EXEC */

            var r9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1 = new R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
            };

            var executed_1 = R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1.Execute(r9200_00_PESQUISA_FORMULARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_TIPO_CORRECAO, RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);
                _.Move(executed_1.RELATORI_NUM_APOL_LIDER, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_FIM*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -5363- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -5364- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -5365- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5366- DISPLAY '*   VA5437B - EMITE CERTIFICADO            *' */
            _.Display($"*   VA5437B - EMITE CERTIFICADO            *");

            /*" -5367- DISPLAY '*   -------   -----------------            *' */
            _.Display($"*   -------   -----------------            *");

            /*" -5368- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5369- DISPLAY '*             NAO EXISTEM CERTIFICADOS A   *' */
            _.Display($"*             NAO EXISTEM CERTIFICADOS A   *");

            /*" -5370- DISPLAY '*             SEREM EMITIDOS.              *' */
            _.Display($"*             SEREM EMITIDOS.              *");

            /*" -5371- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -5371- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5382- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -5383- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -5384- DISPLAY '*** VA5437B - LIDOS         ' AC-LIDOS. */
            _.Display($"*** VA5437B - LIDOS         {AREA_DE_WORK.AC_LIDOS}");

            /*" -5386- DISPLAY '*** VA5437B - CERTIFICADO   ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"*** VA5437B - CERTIFICADO   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -5388- DISPLAY '*** VA5437B - CERTIFICADO-W ' WHOST-NRCERTIF. */
            _.Display($"*** VA5437B - CERTIFICADO-W {WHOST_NRCERTIF}");

            /*" -5388- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -5390- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5394- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -5394- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}