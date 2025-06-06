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
using Sias.VidaAzul.DB2.VA3437B;

namespace Code
{
    public class VA3437B
    {
        public bool IsCall { get; set; }

        public VA3437B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    OBJETIVO DO PROGRAMA                               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  EMITE CERTIFICADOS DAS APOLICES PESSOA FISICA NO PADRAO FAC.  *      */
        /*"      *                                                                *      */
        /*"      *  COLUNAS SETADAS NA TABELA V0RELATORIOS:                       *      */
        /*"      *                                                                *      */
        /*"      *  OPERACAO = 6 (INDICA A EMISSAO DE COMUNICADO DE ADESAO - A5)  *      */
        /*"      *  OPERACAO = 2 (INDICA A EMISSAO DE 2a VIA COMUNICADO    - A4)  *      */
        /*"      *  NRPARCEL = 2 (INDICA O ENVIO PARA O SEGURADO)                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                 ARQUIVOS GERADOS PELO PROGRAMA                 *      */
        /*"      *                                                                       */
        /*"      * RVA3437B : CERTIFICADOS ENVIADOS � GR�FICA                     *      */
        /*"      * IMP3437B : CERTIFICADOS COM TIPO DE ENVIO IMPRESSO             *      */
        /*"      * PDF3437B : CERTIFICADOS COM TIPO DE ENVIO PDF                  *      */
        /*"      * FVA3437B : ESTATISTICA DO PROCESSAMENTO (SYSOUT)               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                         MANUTEN��ES                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.40  *  VERSAO 40  - JAZZ   582106                                    *      */
        /*"      *             - META 2024 - INCORPORACAO DA EMPRESA XS2 PELA     *      */
        /*"      *               CVP.                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/05/2024 - TERCIO CARVALHO                              *      */
        /*"      *   EM 24/07/2024 - SERGIO LORETO                                *      */
        /*"      *                                       PROCURE POR V.40         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.39  *  VERSAO 39  - DEMANDA 578503 / TAREFA 583605                   *      */
        /*"      *    - 3 CAMPOS DE NOME SOCIAL ADICIONADOS NO FINAL DOS ARQUIVOS:*      */
        /*"      *      => SEGURADO_SOCIAL, DESTINATARIO_SOCIAL, CLIENTE_SOCIAL   *      */
        /*"      *                                                                *      */
        /*"      *    UTILIDADE:                                                  *      */
        /*"      *    . SE SEGURADO_SOCIAL, DESTINATARIO_SOCIAL, CLIENTE_SOCIAL   *      */
        /*"      *    ESTIVEREM PREENCHIDOS NO ARQUIVO, O CCM DEVERA UTILIZA-LOS  *      */
        /*"      *    NA COMUNICACAO AO CLIENTE, CASO CONTRARIO, CONTINUAR COM OS *      */
        /*"      *    CAMPOS: SEGURADO, DESTINATARIO E CLIENTE.                   *      */
        /*"      *                                                                       */
        /*"      *  EM 22/04/2024 - ANSELMO SOUSA                                 *      */
        /*"      *                                        PROCURE POR V.39        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.38  *VERSAO V.38-DEMANDA 281754-KINKAS 29/03/2021-ESTIPULANTE FENAE  *      */
        /*"JV137 *----------------------------------------------------------------*      */
        /*"JV137 *VERSAO 37: JV1 DEMANDA 264263 - KINKAS 09/11/2020               *      */
        /*"JV137 *           AJUSTA MONTAGEM STARTDBM                                    */
        /*"JV137 *           - PROCURAR POR JV137                                 *      */
        /*"JV136#*----------------------------------------------------------------*      */
        /*"JV136#*VERSAO 36: JV1 DEMANDA 264263 - KINKAS 09/11/2020               *      */
        /*"JV136#*           AJUSTA TIPO DO FORMULARIO NO CABECALHO               *      */
        /*"JV136#*           - PROCURAR POR JV136                                 *      */
        /*"JV135#*----------------------------------------------------------------*      */
        /*"JV135#*VERSAO 35: JV1 DEMANDA 262179 - KINKAS 28/10/2020               *      */
        /*"JV135#*           TROCA REFERENCIAS PRODUTOS JV1 POR JVPRDXXXX         *      */
        /*"JV135#*           - PROCURAR POR JV135                                 *      */
        /*"JV135#*----------------------------------------------------------------*      */
        /*"JV134#*VERSAO 34: JV1 DEMANDA 259990 - KINKAS 10/09/2020               *      */
        /*"JV134#*           INCLUI/EXCLUI APOLICES E PRODUTOS JV1                *      */
        /*"JV134#*           - PROCURAR POR JV134                                 *      */
        /*"JV134#*----------------------------------------------------------------*      */
        /*"JV133 *VERSAO 33: JV1 DEMANDA 256312 - KINKAS 10/09/2020                      */
        /*"JV133 *           ALTERA FORMULARIOS PARA EMPRESA 11 - JV1                    */
        /*"JV133 *           - PROCURAR POR JV133                                        */
        /*"JV133 *-----------------------------------------------------------------      */
        /*"      *  VERSAO 32 - INCIDENTE 220977                                  *      */
        /*"      *              OCORRENCIA DE FALHA NO.178753 EM 10/10/2019.      *      */
        /*"      *              -811 NO ACESSO HIS_COBER_PROPOST.                 *      */
        /*"      *                                                                *      */
        /*"      *  EM 11/10/2019 - BRICE HO.                                     *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 31 - HISTORIA 205663.                                  *      */
        /*"      *              EXCLUSAO DA ASSISTENCIA SEGURA-PRECO A PARTIR DE  *      */
        /*"      *              01/10/2019 PARA VIDA MULHER E VIDA MULTIPREMIADO. *      */
        /*"      *                                                                *      */
        /*"      *  EM 25/09/2019 - BRICE HO.                                     *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 30 - HISTORIA 202562.                                  *      */
        /*"      *              INCLUSAO DE CAMPOS NO ARQUIVO VA3437B1.CIF        *      */
        /*"      *              PARA ATENDER PROJETO COMPASS.                     *      */
        /*"      *              HISTORIA 198120.                                  *      */
        /*"      *              ADEQUAR TAMANHO DAS VARIAVEIS DE TRABALHO DO      *      */
        /*"      *              CAMPO SUBGRUPO (SMALLINT ASSUME ATE 32767).       *      */
        /*"      *                                                                *      */
        /*"      *  EM 06/06/2019 - BRICE HO.                                     *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 29 - HISTORIA 175442                                   *      */
        /*"      *            - ERRO NA APRESENTACAO DA COBERTURA SEGURA-PRECO    *      */
        /*"      *            - ADEQUAR AS REGRAS SEGURA PRECO CONFORME HISTORIA  *      */
        /*"      *              163419.                                           *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *  EM 23/05/2019 - BRICE HO.                                     *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 28 - CAD 150.235                                       *      */
        /*"      *            - INCLUIR GERACAO DO VA82 QUE ERA GERADO NO MODULO  *      */
        /*"      *              VA4437B QUE FOI DESATIVADO.                       *      */
        /*"      *                                                                *      */
        /*"      *  EM 09/05/2017 - LUIGI CONTE                                   *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 27 - CAD 146.446                                       *      */
        /*"      *            - NAO GERAR MAIS FORMULARIO VA54, SERA GERADO PELO  *      */
        /*"      *              PGM VA5437B, COM CIRCULAR SUSEP 491               *      */
        /*"      *                                                                *      */
        /*"      *  EM 20/04/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *-----------------------------------------------------------------      */
        /*"      *  VERSAO 26 - CAD 148.799                                       *      */
        /*"      *            - ALTERAR O NOME DA COBERTURA 22 PARA "COBERTURA DE *      */
        /*"      *              DOEN�AS CR�NICAS GRAVES EM EST�GIO AVAN�ADO" PARA *      */
        /*"      *              APOLICE 109300000559.                             *      */
        /*"      *            - EXCLUIR COBERTURA 24 E INCLUIR COBERTURA 86 PARA  *      */
        /*"      *              HOMOLOGACAO E 44 PARA PRODU��O PARA SUBGRUPOS     *      */
        /*"      *              01, 02, 06, 08, 10, 12, 14, 16 e 18 DA APOLICE    *      */
        /*"      *              109300000559.                                     *      */
        /*"      *                                                                *      */
        /*"      *  EM 10/04/2017 - ELIERMES OLIVEIRA                             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - CAD 143.008 - ABEND                              *      */
        /*"      *                                                                *      */
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
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.21        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 20 - CAD 130.404                                       *      */
        /*"      *            - ALTERAR PARA GERAR FORMULARIO VA54 PARA PRODUTOS  *      */
        /*"      *              "PARA APROVEITAR A VIDA", APENAS QUANDO DO PEDIDO *      */
        /*"      *              DE SEGUNDA VIA PELO ATALHO 04.10.02                      */
        /*"      *            - ALTERAR TAMANHO DA VARIAVEL DE SORTEIO PARA SUPOR-*      */
        /*"      *              TAR O TEXTO "N�O CONTEMPLA"                       *      */
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
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 18 - CAD 122.275                                     *      */
        /*"      *                CAD 117.796                                     *      */
        /*"      *                                                                *      */
        /*"      *              - DESATIVAR AUXILIO ALIMENTACAO NO SIAS           *      */
        /*"      *                                                                *      */
        /*"      *    EM 16/11/2015 - MARCUS VALERIO   (ALTRAN)                   *      */
        /*"      *                    MAURO R. DA CRUZ (ALTRAN)                   *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    VERSAO 17 -   NSGD - CADMUS 103659.                                */
        /*"      *                - NOVA SOLUCAO DE GESTAO DE DEPOSITOS                  */
        /*"      *                                                                       */
        /*"      *    EM 08/07/2015 - COREON                                             */
        /*"      *                                                                       */
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
        /*"      *                  TURAS E ASSISTENCIAS NO ARQUIVO DE SAIDA.     *      */
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
        /*"      *             - GERA O ARQUIVO VA3437B2 COM AS ESTATISTICAS DO   *      */
        /*"      *               PROCESSAMENTO (SYSOUT)                           *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVA3437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis RVA3437B
        {
            get
            {
                _.Move(RVA3437B_RECORD, _RVA3437B); VarBasis.RedefinePassValue(RVA3437B_RECORD, _RVA3437B, RVA3437B_RECORD); return _RVA3437B;
            }
        }
        public FileBasis _IMP3437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis IMP3437B
        {
            get
            {
                _.Move(IMP3437B_RECORD, _IMP3437B); VarBasis.RedefinePassValue(IMP3437B_RECORD, _IMP3437B, IMP3437B_RECORD); return _IMP3437B;
            }
        }
        public FileBasis _PDF3437B { get; set; } = new FileBasis(new PIC("X", "4500", "X(4500)"));

        public FileBasis PDF3437B
        {
            get
            {
                _.Move(PDF3437B_RECORD, _PDF3437B); VarBasis.RedefinePassValue(PDF3437B_RECORD, _PDF3437B, PDF3437B_RECORD); return _PDF3437B;
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
        public FileBasis _FVA3437B { get; set; } = new FileBasis(new PIC("X", "80", "X(80)"));

        public FileBasis FVA3437B
        {
            get
            {
                _.Move(FVA3437B_RECORD, _FVA3437B); VarBasis.RedefinePassValue(FVA3437B_RECORD, _FVA3437B, FVA3437B_RECORD); return _FVA3437B;
            }
        }
        public SortBasis<VA3437B_REG_SVA3437B> SVA3437B { get; set; } = new SortBasis<VA3437B_REG_SVA3437B>(new VA3437B_REG_SVA3437B());
        /*"01  RVA3437B-RECORD           PIC X(4500).*/
        public StringBasis RVA3437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  IMP3437B-RECORD           PIC X(4500).*/
        public StringBasis IMP3437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  PDF3437B-RECORD           PIC X(4500).*/
        public StringBasis PDF3437B_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  VDHTML01-RECORD           PIC X(4500).*/
        public StringBasis VDHTML01_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  VDHTML09-RECORD           PIC X(4500).*/
        public StringBasis VDHTML09_RECORD { get; set; } = new StringBasis(new PIC("X", "4500", "X(4500)."), @"");
        /*"01  FVA3437B-RECORD           PIC X(80).*/
        public StringBasis FVA3437B_RECORD { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
        /*"01  REG-SVA3437B.*/
        public VA3437B_REG_SVA3437B REG_SVA3437B { get; set; } = new VA3437B_REG_SVA3437B();
        public class VA3437B_REG_SVA3437B : VarBasis
        {
            /*"    05 SVA-TP-ARQSAIDA        PIC X(014).*/
            public StringBasis SVA_TP_ARQSAIDA { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"    05 SVA-CEP-G              PIC 9(010).*/
            public IntBasis SVA_CEP_G { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05 SVA-NUM-CEP.*/
            public VA3437B_SVA_NUM_CEP SVA_NUM_CEP { get; set; } = new VA3437B_SVA_NUM_CEP();
            public class VA3437B_SVA_NUM_CEP : VarBasis
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
            /*"    05 SVA-NRSORTE OCCURS 5 TIMES PIC 9(009).*/
            public ListBasis<IntBasis, Int64> SVA_NRSORTE { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "9", "9(009)."), 5);
            /*"    05 SVA-COD-SUSEP          PIC X(025).*/
            public StringBasis SVA_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    05 SVA-COD-SUSEPCAP       PIC X(025).*/
            public StringBasis SVA_COD_SUSEPCAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    05 SVA-FORMULARIO         PIC X(008).*/
            public StringBasis SVA_FORMULARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 SVA-DDD                PIC 9(002).*/
            public IntBasis SVA_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 SVA-TELEFONE           PIC 9(009).*/
            public IntBasis SVA_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 SVA-TELEX              PIC 9(009).*/
            public IntBasis SVA_TELEX { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05 SVA-COD-EMPRESA        PIC 9(004).*/
            public IntBasis SVA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-DATA-TERVIG-PREMIO       PIC  X(010).*/
        public StringBasis WHOST_DATA_TERVIG_PREMIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-OCOREND                  PIC S9(004) COMP.*/
        public IntBasis WHOST_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W77-MES                        PIC  9(002).*/
        public IntBasis W77_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"77  ENDOSSOS-DATA-TERVIGENCIA-1    PIC  X(010).*/
        public StringBasis ENDOSSOS_DATA_TERVIGENCIA_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-1     PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SISTEMAS-DATA-MOV-ABERTO-15D   PIC  X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_15D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WINDC                          PIC S9(004) COMP.*/
        public IntBasis WINDC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WPI                            PIC S9(004) COMP.*/
        public IntBasis WPI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  I1                             PIC S9(004) COMP.*/
        public IntBasis I1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  I2                             PIC S9(004) COMP.*/
        public IntBasis I2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WACHOU-UNIC                    PIC  X(001) VALUE SPACES.*/
        public StringBasis WACHOU_UNIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  WS-TEM-SEGPRECO                PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_TEM_SEGPRECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
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

        /*"77  FILLER                         PIC X(001) VALUE SPACES.*/

        public SelectorBasis FILLER_1 { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88  W88-IMPRIME-CONTROLES-OK                VALUE '0'. */
							new SelectorItemBasis("W88_IMPRIME_CONTROLES_OK", "0"),
							/*" 88  W88-IMPRIME-CONTROLES-NOK               VALUE '0'. */
							new SelectorItemBasis("W88_IMPRIME_CONTROLES_NOK", "0")
                }
        };

        /*"77  W88-PRODUTO-VIDA               PIC 9(004) VALUE ZEROS.*/
        public IntBasis W88_PRODUTO_VIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"77    WS-COD-PRODUTO               PIC S9(004)  COMP-5  VALUE 0.*/
        public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WS-COD-PRODUTO-ED            PIC -9999.*/
        public IntBasis WS_COD_PRODUTO_ED { get; set; } = new IntBasis(new PIC("9", "4", "-9999."));
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
        /*"77  WS-COD-CBO          PIC S9(09)     COMP.*/
        public IntBasis WS_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  WS-COBERTURA        PIC  X(065)           VALUE SPACES.*/
        public StringBasis WS_COBERTURA { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"");
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
        /*"77  FCPROSUS-COD-PROCESSO-SUSEP        PIC X(25).*/
        public StringBasis FCPROSUS_COD_PROCESSO_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
        /*"77  FCPROSUS-NUM-PLANO  PIC S9(4) USAGE COMP.*/
        public IntBasis FCPROSUS_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  V1SIST-MESREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_MESREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1SIST-ANOREFER     PIC S9(004) COMP.*/
        public IntBasis V1SIST_ANOREFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77                WS-IMP-ADIANT-CDG                                      PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WS_IMP_ADIANT_CDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
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
        /*"01  AREA-DE-WORK.*/
        public VA3437B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA3437B_AREA_DE_WORK();
        public class VA3437B_AREA_DE_WORK : VarBasis
        {
            /*"    05            WS-SIT-PRODUTO     PIC  9(001)  VALUE 0.*/

            public SelectorBasis WS_SIT_PRODUTO { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88          WS-PROD-RUNON                   VALUE 1. */
							new SelectorItemBasis("WS_PROD_RUNON", "1"),
							/*" 88          WS-PROD-RUNOFF                  VALUE 2. */
							new SelectorItemBasis("WS_PROD_RUNOFF", "2")
                }
            };

            /*"    05            WS-NRSORTEIO-ANT  PIC S9(9) COMP VALUE ZEROS.*/
            public IntBasis WS_NRSORTEIO_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"    05            WS-DTNASC         PIC X(010).*/
            public StringBasis WS_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            WS-DTNASC-R       REDEFINES                  WS-DTNASC.*/
            private _REDEF_VA3437B_WS_DTNASC_R _ws_dtnasc_r { get; set; }
            public _REDEF_VA3437B_WS_DTNASC_R WS_DTNASC_R
            {
                get { _ws_dtnasc_r = new _REDEF_VA3437B_WS_DTNASC_R(); _.Move(WS_DTNASC, _ws_dtnasc_r); VarBasis.RedefinePassValue(WS_DTNASC, _ws_dtnasc_r, WS_DTNASC); _ws_dtnasc_r.ValueChanged += () => { _.Move(_ws_dtnasc_r, WS_DTNASC); }; return _ws_dtnasc_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtnasc_r, WS_DTNASC); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_DTNASC_R : VarBasis
            {
                /*"     10           WS-ANO-DTNASC     PIC 9(004).*/
                public IntBasis WS_ANO_DTNASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-MES-DTNASC     PIC 9(002).*/
                public IntBasis WS_MES_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-DIA-DTNASC     PIC 9(002).*/
                public IntBasis WS_DIA_DTNASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-DTMOVABE       PIC X(010).*/

                public _REDEF_VA3437B_WS_DTNASC_R()
                {
                    WS_ANO_DTNASC.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_MES_DTNASC.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_DIA_DTNASC.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05            WS-DTMOVABE-R     REDEFINES                  WS-DTMOVABE.*/
            private _REDEF_VA3437B_WS_DTMOVABE_R _ws_dtmovabe_r { get; set; }
            public _REDEF_VA3437B_WS_DTMOVABE_R WS_DTMOVABE_R
            {
                get { _ws_dtmovabe_r = new _REDEF_VA3437B_WS_DTMOVABE_R(); _.Move(WS_DTMOVABE, _ws_dtmovabe_r); VarBasis.RedefinePassValue(WS_DTMOVABE, _ws_dtmovabe_r, WS_DTMOVABE); _ws_dtmovabe_r.ValueChanged += () => { _.Move(_ws_dtmovabe_r, WS_DTMOVABE); }; return _ws_dtmovabe_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dtmovabe_r, WS_DTMOVABE); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_DTMOVABE_R : VarBasis
            {
                /*"     10           WS-ANO-DTMOVABE   PIC 9(004).*/
                public IntBasis WS_ANO_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-MES-DTMOVABE   PIC 9(002).*/
                public IntBasis WS_MES_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10           FILLER            PIC X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10           WS-DIA-DTMOVABE   PIC 9(002).*/
                public IntBasis WS_DIA_DTMOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-IDADE          PIC 9(004).*/

                public _REDEF_VA3437B_WS_DTMOVABE_R()
                {
                    WS_ANO_DTMOVABE.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_MES_DTMOVABE.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_DIA_DTMOVABE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-NRTITFDCAP     PIC 9(012).*/
            public IntBasis WS_NRTITFDCAP { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05            WS-NRSORTE        PIC 9(009).*/
            public IntBasis WS_NRSORTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05  WS-VALORES-AX.*/
            public VA3437B_WS_VALORES_AX WS_VALORES_AX { get; set; } = new VA3437B_WS_VALORES_AX();
            public class VA3437B_WS_VALORES_AX : VarBasis
            {
                /*"     10           WS-VALOR-9          PIC S9(11)V99.*/
                public DoubleBasis WS_VALOR_9 { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V99."), 2);
                /*"     10           WS-VALOR-INT        PIC Z9.*/
                public IntBasis WS_VALOR_INT { get; set; } = new IntBasis(new PIC("9", "2", "Z9."));
                /*"     10           WS-VALOR-INT-X      PIC X(10).*/
                public StringBasis WS_VALOR_INT_X { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10           WS-VALOR            PIC ZZ.ZZZ.ZZZ,ZZ.*/
                public StringBasis WS_VALOR { get; set; } = new StringBasis(new PIC("X", "0", "ZZ.ZZZ.ZZZVZZ."), @"");
                /*"    05  WS-COBER-DESC                 PIC X(45).*/
            }
            public StringBasis WS_COBER_DESC { get; set; } = new StringBasis(new PIC("X", "45", "X(45)."), @"");
            /*"    05            WS-LC09-JDE         PIC X(008).*/
            public StringBasis WS_LC09_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05            LC01-LINHA01.*/
            public VA3437B_LC01_LINHA01 LC01_LINHA01 { get; set; } = new VA3437B_LC01_LINHA01();
            public class VA3437B_LC01_LINHA01 : VarBasis
            {
                /*"      10          FILLER               PIC X(002) VALUE '%!'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"%!");
                /*"    05            LC08-LINHA08.*/
            }
            public VA3437B_LC08_LINHA08 LC08_LINHA08 { get; set; } = new VA3437B_LC08_LINHA08();
            public class VA3437B_LC08_LINHA08 : VarBasis
            {
                /*"      10          LC08-FILLER       PIC X(070) VALUE    '(|) SETDBSEP'.*/
                public StringBasis LC08_FILLER { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"(|) SETDBSEP");
                /*"    05            LC09-LINHA09      PIC X(030).*/
            }
            public StringBasis LC09_LINHA09 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05            LC10-LINHA10.*/
            public VA3437B_LC10_LINHA10 LC10_LINHA10 { get; set; } = new VA3437B_LC10_LINHA10();
            public class VA3437B_LC10_LINHA10 : VarBasis
            {
                /*"      10         FILLER              PIC X(051) VALUE     'ESTIPULANTE|APOLICE|NUM-CERTIF|DT-VIG|SEGURADO|CPF|'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ESTIPULANTE|APOLICE|NUM_CERTIF|DT_VIG|SEGURADO|CPF|");
                /*"      10         FILLER              PIC X(051) VALUE     'CAPIT1|CAPIT2|CAPIT3|CAPIT4|CAPIT5|CAPIT6|CAPIT7|CA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"CAPIT1|CAPIT2|CAPIT3|CAPIT4|CAPIT5|CAPIT6|CAPIT7|CA");
                /*"      10         FILLER              PIC X(051) VALUE     'PIT8|CAPIT9|CAPIT10|CAPIT11|CAPIT12|CAPIT13|CAPIT14'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"PIT8|CAPIT9|CAPIT10|CAPIT11|CAPIT12|CAPIT13|CAPIT14");
                /*"      10         FILLER              PIC X(051) VALUE     '|CAPIT15|CAPIT16|CAPIT17|CAPIT18|CAPIT19|CAPIT20|DT'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"|CAPIT15|CAPIT16|CAPIT17|CAPIT18|CAPIT19|CAPIT20|DT");
                /*"      10         FILLER              PIC X(014) VALUE     '-CAPIT|CONTA-D'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"_CAPIT|CONTA_D");
                /*"      10         FILLER              PIC X(051) VALUE     'EBITO|CUSTO|DIA-COB|BENEF1|PARENT1|PART1|BENEF2|PAR'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"EBITO|CUSTO|DIA_COB|BENEF1|PARENT1|PART1|BENEF2|PAR");
                /*"      10         FILLER              PIC X(051) VALUE     'ENT2|PART2|BENEF3|PARENT3|PART3|BENEF4|PARENT4|PART'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ENT2|PART2|BENEF3|PARENT3|PART3|BENEF4|PARENT4|PART");
                /*"      10         FILLER              PIC X(051) VALUE     '4|BENEF5|PARENT5|PART5|DTPOSTAGEM|NUMOBJETO|DESTINA'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"4|BENEF5|PARENT5|PART5|DTPOSTAGEM|NUMOBJETO|DESTINA");
                /*"      10         FILLER              PIC X(051) VALUE     'TARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"TARIO|ENDERECO|BAIRRO|CIDADE|UF|CEP|REMETENTE|REMET");
                /*"      10         FILLER              PIC X(051) VALUE     '-ENDERECO|REMET-BAIRRO|REMET-CIDADE|REMET-UF|CODIGO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_ENDERECO|REMET_BAIRRO|REMET_CIDADE|REMET_UF|CODIGO");
                /*"      10         FILLER              PIC X(051) VALUE     '-CIF|POSTNET|REMET-CEP|N-CUSTO|DATADIA|CLIENTE|DT-V'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_CIF|POSTNET|REMET_CEP|N_CUSTO|DATADIA|CLIENTE|DT_V");
                /*"      10         FILLER              PIC X(051) VALUE     'IG1|DT-VIG2|TEXTO|EMAIL|OPCAO-PAG|IDADE|ID-SEXO|REN'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IG1|DT_VIG2|TEXTO|EMAIL|OPCAO_PAG|IDADE|ID_SEXO|REN");
                /*"      10         FILLER              PIC X(051) VALUE     'DA-IND|RENDA-FAM|COD-PRODUTO|NOME-PRODUTO|OPCAO-CON'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DA_IND|RENDA_FAM|COD_PRODUTO|NOME_PRODUTO|OPCAO_CON");
                /*"      10         FILLER              PIC X(051) VALUE     'JUGE|FORM-CAMP|SORTE1|SORTE2|SORTE3|SORTE4|SORTE5|D'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"JUGE|FORM_CAMP|SORTE1|SORTE2|SORTE3|SORTE4|SORTE5|D");
                /*"      10         FILLER              PIC X(030) VALUE     'AT-NASC|COD-SUSEP|COD-SUSEPCAP'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"AT_NASC|COD_SUSEP|COD_SUSEPCAP");
                /*"      10         FILLER              PIC X(025) VALUE     '|DDD-CELULAR|VALOR-PREMIO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"|DDD_CELULAR|VALOR_PREMIO");
                /*"      10         FILLER              PIC X(051) VALUE     '|SEGURADO-SOCIAL|DESTINATARIO-SOCIAL|CLIENTE-SOCIAL'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"|SEGURADO_SOCIAL|DESTINATARIO_SOCIAL|CLIENTE_SOCIAL");
                /*"   05            LC10-LINHTML.*/
                public VA3437B_LC10_LINHTML LC10_LINHTML { get; set; } = new VA3437B_LC10_LINHTML();
                public class VA3437B_LC10_LINHTML : VarBasis
                {
                    /*"      10         FILLER              PIC X(051) VALUE     'ESTIPULANTE;APOLICE;NUM-CERTIF;DT-VIG;SEGURADO;CPF;'.*/
                    public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ESTIPULANTE;APOLICE;NUM_CERTIF;DT_VIG;SEGURADO;CPF;");
                    /*"      10         FILLER              PIC X(051) VALUE     'CAPIT1;CAPIT2;CAPIT3;CAPIT4;CAPIT5;CAPIT6;CAPIT7;CA'.*/
                    public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"CAPIT1;CAPIT2;CAPIT3;CAPIT4;CAPIT5;CAPIT6;CAPIT7;CA");
                    /*"      10         FILLER              PIC X(051) VALUE     'PIT8;CAPIT9;CAPIT10;CAPIT11;CAPIT12;CAPIT13;CAPIT14'.*/
                    public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"PIT8;CAPIT9;CAPIT10;CAPIT11;CAPIT12;CAPIT13;CAPIT14");
                    /*"      10         FILLER              PIC X(051) VALUE     ';CAPIT15;CAPIT16;CAPIT17;CAPIT18;CAPIT19;CAPIT20;DT'.*/
                    public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @";CAPIT15;CAPIT16;CAPIT17;CAPIT18;CAPIT19;CAPIT20;DT");
                    /*"      10         FILLER              PIC X(014) VALUE     '-CAPIT;CONTA-D'.*/
                    public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"_CAPIT;CONTA_D");
                    /*"      10         FILLER              PIC X(051) VALUE     'EBITO;CUSTO;DIA-COB;BENEF1;PARENT1;PART1;BENEF2;PAR'.*/
                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"EBITO;CUSTO;DIA_COB;BENEF1;PARENT1;PART1;BENEF2;PAR");
                    /*"      10         FILLER              PIC X(051) VALUE     'ENT2;PART2;BENEF3;PARENT3;PART3;BENEF4;PARENT4;PART'.*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"ENT2;PART2;BENEF3;PARENT3;PART3;BENEF4;PARENT4;PART");
                    /*"      10         FILLER              PIC X(051) VALUE     '4;BENEF5;PARENT5;PART5;DTPOSTAGEM;NUMOBJETO;DESTINA'.*/
                    public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"4;BENEF5;PARENT5;PART5;DTPOSTAGEM;NUMOBJETO;DESTINA");
                    /*"      10         FILLER              PIC X(051) VALUE     'TARIO;ENDERECO;BAIRRO;CIDADE;UF;CEP;REMETENTE;REMET'.*/
                    public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"TARIO;ENDERECO;BAIRRO;CIDADE;UF;CEP;REMETENTE;REMET");
                    /*"      10         FILLER              PIC X(051) VALUE     '-ENDERECO;REMET-BAIRRO;REMET-CIDADE;REMET-UF;CODIGO'.*/
                    public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_ENDERECO;REMET_BAIRRO;REMET_CIDADE;REMET_UF;CODIGO");
                    /*"      10         FILLER              PIC X(051) VALUE     '-CIF;POSTNET;REMET-CEP;N-CUSTO;DATADIA;CLIENTE;DT-V'.*/
                    public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"_CIF;POSTNET;REMET_CEP;N_CUSTO;DATADIA;CLIENTE;DT_V");
                    /*"      10         FILLER              PIC X(051) VALUE     'IG1;DT-VIG2;TEXTO;EMAIL;OPCAO-PAG;IDADE;ID-SEXO;REN'.*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"IG1;DT_VIG2;TEXTO;EMAIL;OPCAO_PAG;IDADE;ID_SEXO;REN");
                    /*"      10         FILLER              PIC X(051) VALUE     'DA-IND;RENDA-FAM;COD-PRODUTO;NOME-PRODUTO;OPCAO-CON'.*/
                    public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DA_IND;RENDA_FAM;COD_PRODUTO;NOME_PRODUTO;OPCAO_CON");
                    /*"      10         FILLER              PIC X(051) VALUE     'JUGE;FORM-CAMP;SORTE1;SORTE2;SORTE3;SORTE4;SORTE5;D'.*/
                    public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"JUGE;FORM_CAMP;SORTE1;SORTE2;SORTE3;SORTE4;SORTE5;D");
                    /*"      10         FILLER              PIC X(030) VALUE     'AT-NASC;COD-SUSEP;COD-SUSEPCAP'.*/
                    public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"AT_NASC;COD_SUSEP;COD_SUSEPCAP");
                    /*"      10         FILLER              PIC X(025) VALUE     ';DDD-CELULAR;VALOR-PREMIO'.*/
                    public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @";DDD_CELULAR;VALOR_PREMIO");
                    /*"      10         FILLER              PIC X(051) VALUE     ';SEGURADO-SOCIAL;DESTINATARIO-SOCIAL;CLIENTE-SOCIAL'.*/
                    public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @";SEGURADO_SOCIAL;DESTINATARIO_SOCIAL;CLIENTE_SOCIAL");
                    /*"    05            LC11-LINHA11.*/
                }
            }
            public VA3437B_LC11_LINHA11 LC11_LINHA11 { get; set; } = new VA3437B_LC11_LINHA11();
            public class VA3437B_LC11_LINHA11 : VarBasis
            {
                /*"       10         LC11-ESTIPULANTE    PIC X(040).*/
                public StringBasis LC11_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-APOLICE        PIC ZZZZZZZZZZZZZ.*/
                public StringBasis LC11_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCERTIF       PIC ZZZZZZZZZZZZZZZ.*/
                public StringBasis LC11_NRCERTIF { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZZZ."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCERTIF       PIC 9(001).*/
                public IntBasis LC11_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTINIVIG       PIC X(010).*/
                public StringBasis LC11_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO     PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NRCPF          PIC 999.999.999.*/
                public IntBasis LC11_NRCPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-DVCPF          PIC 9(002).*/
                public IntBasis LC11_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COBERTURAS.*/
                public VA3437B_LC11_COBERTURAS LC11_COBERTURAS { get; set; } = new VA3437B_LC11_COBERTURAS();
                public class VA3437B_LC11_COBERTURAS : VarBasis
                {
                    /*"         15       LC11-COBER-OCC OCCURS 20 TIMES.*/
                    public ListBasis<VA3437B_LC11_COBER_OCC> LC11_COBER_OCC { get; set; } = new ListBasis<VA3437B_LC11_COBER_OCC>(20);
                    public class VA3437B_LC11_COBER_OCC : VarBasis
                    {
                        /*"           20     LC11-STRING1        PIC X(065) VALUE SPACES.*/
                        public StringBasis LC11_STRING1 { get; set; } = new StringBasis(new PIC("X", "65", "X(065)"), @"");
                        /*"           20     LC11-VALORA         PIC X(013).*/
                        public StringBasis LC11_VALORA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                        /*"           20     LC11-DELIMIT-00     PIC X(001).*/
                        public StringBasis LC11_DELIMIT_00 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-DTALTCAP       PIC X(010).*/
                    }
                }
                public StringBasis LC11_DTALTCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAOPAG       PIC X(035) VALUE SPACES.*/
                public StringBasis LC11_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"       10         LC11-OPCAOPAG-R     REDEFINES                  LC11-OPCAOPAG.*/
                private _REDEF_VA3437B_LC11_OPCAOPAG_R _lc11_opcaopag_r { get; set; }
                public _REDEF_VA3437B_LC11_OPCAOPAG_R LC11_OPCAOPAG_R
                {
                    get { _lc11_opcaopag_r = new _REDEF_VA3437B_LC11_OPCAOPAG_R(); _.Move(LC11_OPCAOPAG, _lc11_opcaopag_r); VarBasis.RedefinePassValue(LC11_OPCAOPAG, _lc11_opcaopag_r, LC11_OPCAOPAG); _lc11_opcaopag_r.ValueChanged += () => { _.Move(_lc11_opcaopag_r, LC11_OPCAOPAG); }; return _lc11_opcaopag_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_opcaopag_r, LC11_OPCAOPAG); }
                }  //Redefines
                public class _REDEF_VA3437B_LC11_OPCAOPAG_R : VarBasis
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
                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                    public _REDEF_VA3437B_LC11_OPCAOPAG_R()
                    {
                        LC11_AGECTADEB.ValueChanged += OnValueChanged;
                        LC11_PONTO1.ValueChanged += OnValueChanged;
                        LC11_OPRCTADEB.ValueChanged += OnValueChanged;
                        LC11_PONTO2.ValueChanged += OnValueChanged;
                        LC11_NUMCTADEB.ValueChanged += OnValueChanged;
                        LC11_TRACO.ValueChanged += OnValueChanged;
                        LC11_DIGCTADEB.ValueChanged += OnValueChanged;
                        FILLER_50.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NCUSTO1        PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_NCUSTO1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         LC11-VLPREMIO       PIC ZZZZZ9,99.*/
                public DoubleBasis LC11_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DIA-DEB        PIC 9(002).*/
                public IntBasis LC11_DIA_DEB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10         LC11-DIA-DEB-R REDEFINES LC11-DIA-DEB.*/
                private _REDEF_VA3437B_LC11_DIA_DEB_R _lc11_dia_deb_r { get; set; }
                public _REDEF_VA3437B_LC11_DIA_DEB_R LC11_DIA_DEB_R
                {
                    get { _lc11_dia_deb_r = new _REDEF_VA3437B_LC11_DIA_DEB_R(); _.Move(LC11_DIA_DEB, _lc11_dia_deb_r); VarBasis.RedefinePassValue(LC11_DIA_DEB, _lc11_dia_deb_r, LC11_DIA_DEB); _lc11_dia_deb_r.ValueChanged += () => { _.Move(_lc11_dia_deb_r, LC11_DIA_DEB); }; return _lc11_dia_deb_r; }
                    set { VarBasis.RedefinePassValue(value, _lc11_dia_deb_r, LC11_DIA_DEB); }
                }  //Redefines
                public class _REDEF_VA3437B_LC11_DIA_DEB_R : VarBasis
                {
                    /*"         15       LC11-DIA-DEB-ALFA   PIC X(002).*/
                    public StringBasis LC11_DIA_DEB_ALFA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                    public _REDEF_VA3437B_LC11_DIA_DEB_R()
                    {
                        LC11_DIA_DEB_ALFA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BENEFICIARIOS.*/
                public VA3437B_LC11_BENEFICIARIOS LC11_BENEFICIARIOS { get; set; } = new VA3437B_LC11_BENEFICIARIOS();
                public class VA3437B_LC11_BENEFICIARIOS : VarBasis
                {
                    /*"         15       LC11-BENEF-OCC OCCURS 5 TIMES.*/
                    public ListBasis<VA3437B_LC11_BENEF_OCC> LC11_BENEF_OCC { get; set; } = new ListBasis<VA3437B_LC11_BENEF_OCC>(5);
                    public class VA3437B_LC11_BENEF_OCC : VarBasis
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
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEQUENCIA      PIC X(007).*/
                public StringBasis LC11_SEQUENCIA { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END PIC X(040).*/
                public StringBasis LC11_NOME_RAZAO_END { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO       PIC X(072).*/
                public StringBasis LC11_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO         PIC X(072).*/
                public StringBasis LC11_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE         PIC X(072).*/
                public StringBasis LC11_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF             PIC X(002).*/
                public StringBasis LC11_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP            PIC 99999.*/
                public IntBasis LC11_CEP { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL      PIC 999.*/
                public IntBasis LC11_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         FILLER              PIC X(014) VALUE                 'CAIXA SEGUROS'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CAIXA SEGUROS");
                /*"       10         LC11-REMETENTE-G.*/
                public VA3437B_LC11_REMETENTE_G LC11_REMETENTE_G { get; set; } = new VA3437B_LC11_REMETENTE_G();
                public class VA3437B_LC11_REMETENTE_G : VarBasis
                {
                    /*"         15       LC11-REMETENTE-S    PIC X(007).*/
                    public StringBasis LC11_REMETENTE_S { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                    /*"         15       LC11-REMETENTE      PIC X(024).*/
                    public StringBasis LC11_REMETENTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
                    /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                }
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-ENDERECO-REM   PIC X(040).*/
                public StringBasis LC11_ENDERECO_REM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-BAIRRO-REM     PIC X(020).*/
                public StringBasis LC11_BAIRRO_REM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CIDADE-REM     PIC X(020).*/
                public StringBasis LC11_CIDADE_REM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-UF-REM         PIC X(002).*/
                public StringBasis LC11_UF_REM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         CODIGO-CIF          PIC X(034) VALUE ALL '@'.*/
                public StringBasis CODIGO_CIF { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         POSTNET             PIC X(011) VALUE ALL '#'.*/
                public StringBasis POSTNET { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"ALL");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CEP-REM        PIC 99999.*/
                public IntBasis LC11_CEP_REM { get; set; } = new IntBasis(new PIC("9", "5", "99999."));
                /*"       10         FILLER              PIC X(001) VALUE '-'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"       10         LC11-CEP-COMPL-REM  PIC 999.*/
                public IntBasis LC11_CEP_COMPL_REM { get; set; } = new IntBasis(new PIC("9", "3", "999."));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NCUSTO         PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_NCUSTO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DATADIA        PIC X(010) VALUE SPACES.*/
                public StringBasis LC11_DATADIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE        PIC X(090) VALUE SPACES.*/
                public StringBasis LC11_CLIENTE { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVIG-PRIN     PIC X(060) VALUE SPACES.*/
                public StringBasis LC11_DTVIG_PRIN { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-DTVIG-DEPE     PIC X(060) VALUE SPACES.*/
                public StringBasis LC11_DTVIG_DEPE { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-TEXTO          PIC X(090) VALUE SPACES.*/
                public StringBasis LC11_TEXTO { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-EMAIL          PIC X(050) VALUE SPACES.*/
                public StringBasis LC11_EMAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAO-PAG      PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_OPCAO_PAG { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-IDADE          PIC 9(003) VALUE ZEROS.*/
                public IntBasis LC11_IDADE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SEXO           PIC X(001) VALUE SPACES.*/
                public StringBasis LC11_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-RENDA-IND      PIC 9(002) VALUE ZEROS.*/
                public IntBasis LC11_RENDA_IND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-RENDA-FAM      PIC X(002) VALUE ZEROS.*/
                public StringBasis LC11_RENDA_FAM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-PRODUTO    PIC 9(004) VALUE ZEROS.*/
                public IntBasis LC11_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-PRODUTO   PIC X(030) VALUE SPACES.*/
                public StringBasis LC11_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-OPCAO-CONJ     PIC X(015) VALUE SPACES.*/
                public StringBasis LC11_OPCAO_CONJ { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-FORM-CAMP      PIC X(050) VALUE SPACES.*/
                public StringBasis LC11_FORM_CAMP { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-SORTE.*/
                public VA3437B_LC11_SORTE LC11_SORTE { get; set; } = new VA3437B_LC11_SORTE();
                public class VA3437B_LC11_SORTE : VarBasis
                {
                    /*"         15       LC11-SORTE1         OCCURS 5 TIMES.*/
                    public ListBasis<VA3437B_LC11_SORTE1> LC11_SORTE1 { get; set; } = new ListBasis<VA3437B_LC11_SORTE1>(5);
                    public class VA3437B_LC11_SORTE1 : VarBasis
                    {
                        /*"           20     LC11-NRSORTE        PIC X(015) VALUE SPACES.*/
                        public StringBasis LC11_NRSORTE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                        /*"           20     LC11-NRSORTE-S      PIC X(001).*/
                        public StringBasis LC11_NRSORTE_S { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         LC11-DAT-NASC       PIC X(010) VALUE SPACES.*/
                    }
                }
                public StringBasis LC11_DAT_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-SUSEP      PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-COD-SUSEPCAP   PIC X(025) VALUE SPACES.*/
                public StringBasis LC11_COD_SUSEPCAP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CELULAR.*/
                public VA3437B_LC11_CELULAR LC11_CELULAR { get; set; } = new VA3437B_LC11_CELULAR();
                public class VA3437B_LC11_CELULAR : VarBasis
                {
                    /*"         15       LC11-DDD            PIC 9(002).*/
                    public IntBasis LC11_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"         15       LC11-TELEFONE       PIC 9(009).*/
                    public IntBasis LC11_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"         15       FILLER   REDEFINES  LC11-TELEFONE.*/
                    private _REDEF_VA3437B_FILLER_92 _filler_92 { get; set; }
                    public _REDEF_VA3437B_FILLER_92 FILLER_92
                    {
                        get { _filler_92 = new _REDEF_VA3437B_FILLER_92(); _.Move(LC11_TELEFONE, _filler_92); VarBasis.RedefinePassValue(LC11_TELEFONE, _filler_92, LC11_TELEFONE); _filler_92.ValueChanged += () => { _.Move(_filler_92, LC11_TELEFONE); }; return _filler_92; }
                        set { VarBasis.RedefinePassValue(value, _filler_92, LC11_TELEFONE); }
                    }  //Redefines
                    public class _REDEF_VA3437B_FILLER_92 : VarBasis
                    {
                        /*"           20     LC11-NEXTEL         PIC 9(008).*/
                        public IntBasis LC11_NEXTEL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                        /*"           20     FILLER              PIC X(001).*/
                        public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"       10         FILLER              PIC X(001) VALUE '|'.*/

                        public _REDEF_VA3437B_FILLER_92()
                        {
                            LC11_NEXTEL.ValueChanged += OnValueChanged;
                            FILLER_93.ValueChanged += OnValueChanged;
                        }

                    }
                }
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-VLPREMIO2      PIC ZZZZZ9,99.*/
                public DoubleBasis LC11_VLPREMIO2 { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZZZ9V99."), 2);
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-SOC PIC X(100).*/
                public StringBasis LC11_NOME_RAZAO_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-NOME-RAZAO-END-SOC PIC X(100).*/
                public StringBasis LC11_NOME_RAZAO_END_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"       10         FILLER              PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"       10         LC11-CLIENTE-SOC    PIC X(100) VALUE SPACES.*/
                public StringBasis LC11_CLIENTE_SOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"    05            LC12-LINHA12.*/
            }
            public VA3437B_LC12_LINHA12 LC12_LINHA12 { get; set; } = new VA3437B_LC12_LINHA12();
            public class VA3437B_LC12_LINHA12 : VarBasis
            {
                /*"      10          LC12-FILLER          PIC X(005) VALUE    '%%EOF'.*/
                public StringBasis LC12_FILLER { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"%%EOF");
                /*"    05            AC-PAGINA           PIC 9(003) VALUE ZEROS.*/
            }
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"    05            WS-CAR-CONJUGE      PIC 9(003)V99                                                 VALUE ZEROS.*/
            public DoubleBasis WS_CAR_CONJUGE { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
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
            /*"    05            WS-JDE-ANT          PIC X(030) VALUE ALL '*'.*/
            public StringBasis WS_JDE_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"ALL");
            /*"    05            WS-OPER-ANT         PIC 9(004).*/
            public IntBasis WS_OPER_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05            WS-TP-ARQSAIDA-ANT  PIC X(014) VALUE ' '.*/
            public StringBasis WS_TP_ARQSAIDA_ANT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" ");
            /*"    05            WS-CEP-G-ANT        PIC 9(010).*/
            public IntBasis WS_CEP_G_ANT { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"    05            WS-NOME-COR-ANT.*/
            public VA3437B_WS_NOME_COR_ANT WS_NOME_COR_ANT { get; set; } = new VA3437B_WS_NOME_COR_ANT();
            public class VA3437B_WS_NOME_COR_ANT : VarBasis
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
            public VA3437B_DEST_NUM_CEP DEST_NUM_CEP { get; set; } = new VA3437B_DEST_NUM_CEP();
            public class VA3437B_DEST_NUM_CEP : VarBasis
            {
                /*"      15          DEST-CEP            PIC 9(005) VALUE ZEROS.*/
                public IntBasis DEST_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"      15          DEST-CEP-COMPL      PIC 9(003) VALUE ZEROS.*/
                public IntBasis DEST_CEP_COMPL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    05            WS-CPF              PIC 9(015).*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            WS-CPF-R            REDEFINES                  WS-CPF.*/
            private _REDEF_VA3437B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_VA3437B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_VA3437B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_CPF_R : VarBasis
            {
                /*"      10          WS-NRCPF            PIC 9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10          WS-DVCPF            PIC 9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WS-CERTIF           PIC 9(015).*/

                public _REDEF_VA3437B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05            WS-CERTIF-R         REDEFINES                  WS-CERTIF.*/
            private _REDEF_VA3437B_WS_CERTIF_R _ws_certif_r { get; set; }
            public _REDEF_VA3437B_WS_CERTIF_R WS_CERTIF_R
            {
                get { _ws_certif_r = new _REDEF_VA3437B_WS_CERTIF_R(); _.Move(WS_CERTIF, _ws_certif_r); VarBasis.RedefinePassValue(WS_CERTIF, _ws_certif_r, WS_CERTIF); _ws_certif_r.ValueChanged += () => { _.Move(_ws_certif_r, WS_CERTIF); }; return _ws_certif_r; }
                set { VarBasis.RedefinePassValue(value, _ws_certif_r, WS_CERTIF); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_CERTIF_R : VarBasis
            {
                /*"      10          WS-NRCERTIF         PIC 9(014).*/
                public IntBasis WS_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"      10          WS-DVCERTIF         PIC 9(001).*/
                public IntBasis WS_DVCERTIF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05            WS-DATA-SQL.*/

                public _REDEF_VA3437B_WS_CERTIF_R()
                {
                    WS_NRCERTIF.ValueChanged += OnValueChanged;
                    WS_DVCERTIF.ValueChanged += OnValueChanged;
                }

            }
            public VA3437B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VA3437B_WS_DATA_SQL();
            public class VA3437B_WS_DATA_SQL : VarBasis
            {
                /*"      10          WS-SEC-ANO          PIC 9(004) VALUE ZEROS.*/
                public IntBasis WS_SEC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"      10          WS-SEC-ANO-R        REDEFINES                  WS-SEC-ANO.*/
                private _REDEF_VA3437B_WS_SEC_ANO_R _ws_sec_ano_r { get; set; }
                public _REDEF_VA3437B_WS_SEC_ANO_R WS_SEC_ANO_R
                {
                    get { _ws_sec_ano_r = new _REDEF_VA3437B_WS_SEC_ANO_R(); _.Move(WS_SEC_ANO, _ws_sec_ano_r); VarBasis.RedefinePassValue(WS_SEC_ANO, _ws_sec_ano_r, WS_SEC_ANO); _ws_sec_ano_r.ValueChanged += () => { _.Move(_ws_sec_ano_r, WS_SEC_ANO); }; return _ws_sec_ano_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_sec_ano_r, WS_SEC_ANO); }
                }  //Redefines
                public class _REDEF_VA3437B_WS_SEC_ANO_R : VarBasis
                {
                    /*"        15        WS-ANO-SQL          PIC 9(004).*/
                    public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10          FILLER              PIC X(001).*/

                    public _REDEF_VA3437B_WS_SEC_ANO_R()
                    {
                        WS_ANO_SQL.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-SQL          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-DIA-SQL          PIC 9(002) VALUE ZEROS.*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05            WS-DATA-I.*/
            }
            public VA3437B_WS_DATA_I WS_DATA_I { get; set; } = new VA3437B_WS_DATA_I();
            public class VA3437B_WS_DATA_I : VarBasis
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
                private _REDEF_VA3437B_WS_SEC_ANO_IR _ws_sec_ano_ir { get; set; }
                public _REDEF_VA3437B_WS_SEC_ANO_IR WS_SEC_ANO_IR
                {
                    get { _ws_sec_ano_ir = new _REDEF_VA3437B_WS_SEC_ANO_IR(); _.Move(WS_SEC_ANO_I, _ws_sec_ano_ir); VarBasis.RedefinePassValue(WS_SEC_ANO_I, _ws_sec_ano_ir, WS_SEC_ANO_I); _ws_sec_ano_ir.ValueChanged += () => { _.Move(_ws_sec_ano_ir, WS_SEC_ANO_I); }; return _ws_sec_ano_ir; }
                    set { VarBasis.RedefinePassValue(value, _ws_sec_ano_ir, WS_SEC_ANO_I); }
                }  //Redefines
                public class _REDEF_VA3437B_WS_SEC_ANO_IR : VarBasis
                {
                    /*"        15        WS-ANO-I            PIC 9(004).*/
                    public IntBasis WS_ANO_I { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05            WS-DATA-SEG.*/

                    public _REDEF_VA3437B_WS_SEC_ANO_IR()
                    {
                        WS_ANO_I.ValueChanged += OnValueChanged;
                    }

                }
            }
            public VA3437B_WS_DATA_SEG WS_DATA_SEG { get; set; } = new VA3437B_WS_DATA_SEG();
            public class VA3437B_WS_DATA_SEG : VarBasis
            {
                /*"      10          WS-STRING1          PIC X(020) VALUE SPACES.*/
                public StringBasis WS_STRING1 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"      10          WS-DTINIVIG.*/
                public VA3437B_WS_DTINIVIG WS_DTINIVIG { get; set; } = new VA3437B_WS_DTINIVIG();
                public class VA3437B_WS_DTINIVIG : VarBasis
                {
                    /*"        15        WS-DIA-INI          PIC X(002).*/
                    public StringBasis WS_DIA_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA1           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-MES-INI          PIC X(002).*/
                    public StringBasis WS_MES_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA2           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-ANO-INI          PIC X(004).*/
                    public StringBasis WS_ANO_INI { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      10          WS-FIL-A            PIC X(003) VALUE ' A '.*/
                }
                public StringBasis WS_FIL_A { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"      10          WS-DTTERVIG.*/
                public VA3437B_WS_DTTERVIG WS_DTTERVIG { get; set; } = new VA3437B_WS_DTTERVIG();
                public class VA3437B_WS_DTTERVIG : VarBasis
                {
                    /*"        15        WS-DIA-TER          PIC X(002).*/
                    public StringBasis WS_DIA_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA3           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-MES-TER          PIC X(002).*/
                    public StringBasis WS_MES_TER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"        15        WS-BARRA4           PIC X(001) VALUE '/'.*/
                    public StringBasis WS_BARRA4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"        15        WS-ANO-TER          PIC X(004).*/
                    public StringBasis WS_ANO_TER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"      10          WS-STRING2          PIC X(003) VALUE '(*)'.*/
                }
                public StringBasis WS_STRING2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"(*)");
                /*"    05            WS-DATA-INV.*/
            }
            public VA3437B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA3437B_WS_DATA_INV();
            public class VA3437B_WS_DATA_INV : VarBasis
            {
                /*"      10          WS-ANO-INV          PIC 9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-MES-INV          PIC 9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          FILLER              PIC X(001).*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10          WS-DIA-INV          PIC 9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05            WHORA-CURR          PIC X(008) VALUE SPACES.*/
            }
            public StringBasis WHORA_CURR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05            WS-NUM-CEP-AUX      PIC 9(008).*/
            public IntBasis WS_NUM_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05            WS-NUM-CEP-AUX-R    REDEFINES                  WS-NUM-CEP-AUX.*/
            private _REDEF_VA3437B_WS_NUM_CEP_AUX_R _ws_num_cep_aux_r { get; set; }
            public _REDEF_VA3437B_WS_NUM_CEP_AUX_R WS_NUM_CEP_AUX_R
            {
                get { _ws_num_cep_aux_r = new _REDEF_VA3437B_WS_NUM_CEP_AUX_R(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); _ws_num_cep_aux_r.ValueChanged += () => { _.Move(_ws_num_cep_aux_r, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_NUM_CEP_AUX_R : VarBasis
            {
                /*"      10          WS-CEP-AUX          PIC 9(005).*/
                public IntBasis WS_CEP_AUX { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10          WS-CEP-COMPL-AUX    PIC 9(003).*/
                public IntBasis WS_CEP_COMPL_AUX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05            WS-NUM-CEP-AUX-R1   REDEFINES                  WS-NUM-CEP-AUX.*/

                public _REDEF_VA3437B_WS_NUM_CEP_AUX_R()
                {
                    WS_CEP_AUX.ValueChanged += OnValueChanged;
                    WS_CEP_COMPL_AUX.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA3437B_WS_NUM_CEP_AUX_R1 _ws_num_cep_aux_r1 { get; set; }
            public _REDEF_VA3437B_WS_NUM_CEP_AUX_R1 WS_NUM_CEP_AUX_R1
            {
                get { _ws_num_cep_aux_r1 = new _REDEF_VA3437B_WS_NUM_CEP_AUX_R1(); _.Move(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1); VarBasis.RedefinePassValue(WS_NUM_CEP_AUX, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); _ws_num_cep_aux_r1.ValueChanged += () => { _.Move(_ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }; return _ws_num_cep_aux_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_num_cep_aux_r1, WS_NUM_CEP_AUX); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_NUM_CEP_AUX_R1 : VarBasis
            {
                /*"      10          WS-CEP-COMPL-AUX1   PIC 9(003).*/
                public IntBasis WS_CEP_COMPL_AUX1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          WS-CEP-AUX1         PIC 9(005).*/
                public IntBasis WS_CEP_AUX1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05            WS-TIP-FONE         PIC 9(001).*/

                public _REDEF_VA3437B_WS_NUM_CEP_AUX_R1()
                {
                    WS_CEP_COMPL_AUX1.ValueChanged += OnValueChanged;
                    WS_CEP_AUX1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TIP_FONE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05            WS-NUM-FONE         PIC 9(009).*/
            public IntBasis WS_NUM_FONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    05            FILLER              REDEFINES                  WS-NUM-FONE.*/
            private _REDEF_VA3437B_FILLER_102 _filler_102 { get; set; }
            public _REDEF_VA3437B_FILLER_102 FILLER_102
            {
                get { _filler_102 = new _REDEF_VA3437B_FILLER_102(); _.Move(WS_NUM_FONE, _filler_102); VarBasis.RedefinePassValue(WS_NUM_FONE, _filler_102, WS_NUM_FONE); _filler_102.ValueChanged += () => { _.Move(_filler_102, WS_NUM_FONE); }; return _filler_102; }
                set { VarBasis.RedefinePassValue(value, _filler_102, WS_NUM_FONE); }
            }  //Redefines
            public class _REDEF_VA3437B_FILLER_102 : VarBasis
            {
                /*"      10          WS-NUM-FONE-P1      PIC 9(002).*/
                public IntBasis WS_NUM_FONE_P1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10          WS-NUM-FONE-P2      PIC 9(007).*/
                public IntBasis WS_NUM_FONE_P2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    05            FILLER              REDEFINES                  WS-NUM-FONE.*/

                public _REDEF_VA3437B_FILLER_102()
                {
                    WS_NUM_FONE_P1.ValueChanged += OnValueChanged;
                    WS_NUM_FONE_P2.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VA3437B_FILLER_103 _filler_103 { get; set; }
            public _REDEF_VA3437B_FILLER_103 FILLER_103
            {
                get { _filler_103 = new _REDEF_VA3437B_FILLER_103(); _.Move(WS_NUM_FONE, _filler_103); VarBasis.RedefinePassValue(WS_NUM_FONE, _filler_103, WS_NUM_FONE); _filler_103.ValueChanged += () => { _.Move(_filler_103, WS_NUM_FONE); }; return _filler_103; }
                set { VarBasis.RedefinePassValue(value, _filler_103, WS_NUM_FONE); }
            }  //Redefines
            public class _REDEF_VA3437B_FILLER_103 : VarBasis
            {
                /*"      10          WS-NUM-FONE-P3      PIC 9(003).*/
                public IntBasis WS_NUM_FONE_P3 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10          WS-NUM-FONE-P4      PIC 9(006).*/
                public IntBasis WS_NUM_FONE_P4 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05            WS-FONE1-OK         PIC X(001).*/

                public _REDEF_VA3437B_FILLER_103()
                {
                    WS_NUM_FONE_P3.ValueChanged += OnValueChanged;
                    WS_NUM_FONE_P4.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_FONE1_OK { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05            WS-FONE2-OK         PIC X(001).*/
            public StringBasis WS_FONE2_OK { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        WS-JDE-GER.*/
            public VA3437B_WS_JDE_GER WS_JDE_GER { get; set; } = new VA3437B_WS_JDE_GER();
            public class VA3437B_WS_JDE_GER : VarBasis
            {
                /*"        15        WS-JDE               PIC X(008).*/
                public StringBasis WS_JDE { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05        WS-CHAVE            PIC  X(023).*/
            }
            public StringBasis WS_CHAVE { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
            /*"    05        WS-CHAVE-R          REDEFINES              WS-CHAVE.*/
            private _REDEF_VA3437B_WS_CHAVE_R _ws_chave_r { get; set; }
            public _REDEF_VA3437B_WS_CHAVE_R WS_CHAVE_R
            {
                get { _ws_chave_r = new _REDEF_VA3437B_WS_CHAVE_R(); _.Move(WS_CHAVE, _ws_chave_r); VarBasis.RedefinePassValue(WS_CHAVE, _ws_chave_r, WS_CHAVE); _ws_chave_r.ValueChanged += () => { _.Move(_ws_chave_r, WS_CHAVE); }; return _ws_chave_r; }
                set { VarBasis.RedefinePassValue(value, _ws_chave_r, WS_CHAVE); }
            }  //Redefines
            public class _REDEF_VA3437B_WS_CHAVE_R : VarBasis
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

                public _REDEF_VA3437B_WS_CHAVE_R()
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
            /*"    05            AC-GRAVA-VA82       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VA82 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            /*"    05            AC-DESPR-VA54       PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_VA54 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05            AC-DESPR-VIDA10     PIC 9(006) VALUE ZEROS.*/
            public IntBasis AC_DESPR_VIDA10 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
            public VA3437B_LK_PROSOMU1 LK_PROSOMU1 { get; set; } = new VA3437B_LK_PROSOMU1();
            public class VA3437B_LK_PROSOMU1 : VarBasis
            {
                /*"      10          LK-DATA-SOM         PIC 9(008).*/
                public IntBasis LK_DATA_SOM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10          LK-DATA-SOM-R       REDEFINES                  LK-DATA-SOM.*/
                private _REDEF_VA3437B_LK_DATA_SOM_R _lk_data_som_r { get; set; }
                public _REDEF_VA3437B_LK_DATA_SOM_R LK_DATA_SOM_R
                {
                    get { _lk_data_som_r = new _REDEF_VA3437B_LK_DATA_SOM_R(); _.Move(LK_DATA_SOM, _lk_data_som_r); VarBasis.RedefinePassValue(LK_DATA_SOM, _lk_data_som_r, LK_DATA_SOM); _lk_data_som_r.ValueChanged += () => { _.Move(_lk_data_som_r, LK_DATA_SOM); }; return _lk_data_som_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_som_r, LK_DATA_SOM); }
                }  //Redefines
                public class _REDEF_VA3437B_LK_DATA_SOM_R : VarBasis
                {
                    /*"        15        LK-DIA-SOM          PIC 9(002).*/
                    public IntBasis LK_DIA_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-MES-SOM          PIC 9(002).*/
                    public IntBasis LK_MES_SOM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-ANO-SOM          PIC 9(004).*/
                    public IntBasis LK_ANO_SOM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      10          LK-QTDIAS           PIC S9(005) COMP-3                                                  VALUE +1.*/

                    public _REDEF_VA3437B_LK_DATA_SOM_R()
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
                private _REDEF_VA3437B_LK_DATA_CALC_R _lk_data_calc_r { get; set; }
                public _REDEF_VA3437B_LK_DATA_CALC_R LK_DATA_CALC_R
                {
                    get { _lk_data_calc_r = new _REDEF_VA3437B_LK_DATA_CALC_R(); _.Move(LK_DATA_CALC, _lk_data_calc_r); VarBasis.RedefinePassValue(LK_DATA_CALC, _lk_data_calc_r, LK_DATA_CALC); _lk_data_calc_r.ValueChanged += () => { _.Move(_lk_data_calc_r, LK_DATA_CALC); }; return _lk_data_calc_r; }
                    set { VarBasis.RedefinePassValue(value, _lk_data_calc_r, LK_DATA_CALC); }
                }  //Redefines
                public class _REDEF_VA3437B_LK_DATA_CALC_R : VarBasis
                {
                    /*"        15        LK-DIA-CALC         PIC 9(002).*/
                    public IntBasis LK_DIA_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-MES-CALC         PIC 9(002).*/
                    public IntBasis LK_MES_CALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        15        LK-ANO-CALC         PIC 9(004).*/
                    public IntBasis LK_ANO_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01                PARAMETROS.*/

                    public _REDEF_VA3437B_LK_DATA_CALC_R()
                    {
                        LK_DIA_CALC.ValueChanged += OnValueChanged;
                        LK_MES_CALC.ValueChanged += OnValueChanged;
                        LK_ANO_CALC.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public VA3437B_PARAMETROS PARAMETROS { get; set; } = new VA3437B_PARAMETROS();
        public class VA3437B_PARAMETROS : VarBasis
        {
            /*"  05              LK-APOLICE          PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05              LK-SUBGRUPO         PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05              LK-IDADE            PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05              LK-NASCIMENTO.*/
            public VA3437B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VA3437B_LK_NASCIMENTO();
            public class VA3437B_LK_NASCIMENTO : VarBasis
            {
                /*"     10           LK-DATA-NASCIMENTO  PIC 9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05              LK-SALARIO          PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-MORTE-NATURAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-MORTE-ACIDENTAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-INV-PERMANENTE                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-INV-POR-ACIDENTE                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-ASS-MEDICA                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-DIARIA-HOSPITALAR                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-COBT-DIARIA-INTERNACAO                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-MORTE-NATURAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-MORTE-ACIDENTAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-INV-PERMANENTE                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-ASS-MEDICA                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-DIARIA-HOSPITALAR                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PURO-DIARIA-INTERNACAO                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PREM-MORTE-NATURAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PREM-ACIDENTES-PESSOAIS                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-PREM-TOTAL                                      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05            LK-RETURN-CODE      PIC S9(003) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    05            LK-MENSAGEM         PIC  X(077).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(077)."), @"");
            /*"01                TAB-FILIAL.*/
        }
        public VA3437B_TAB_FILIAL TAB_FILIAL { get; set; } = new VA3437B_TAB_FILIAL();
        public class VA3437B_TAB_FILIAL : VarBasis
        {
            /*"    05            FILLER              OCCURS  99  TIMES.*/
            public ListBasis<VA3437B_FILLER_104> FILLER_104 { get; set; } = new ListBasis<VA3437B_FILLER_104>(99);
            public class VA3437B_FILLER_104 : VarBasis
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
        public VA3437B_TABELA_CEP TABELA_CEP { get; set; } = new VA3437B_TABELA_CEP();
        public class VA3437B_TABELA_CEP : VarBasis
        {
            /*"    05            CEP                 OCCURS  2000 TIMES.*/
            public ListBasis<VA3437B_CEP> CEP { get; set; } = new ListBasis<VA3437B_CEP>(2000);
            public class VA3437B_CEP : VarBasis
            {
                /*"      10          TAB-FX-CEP-G        PIC 9(004).*/
                public IntBasis TAB_FX_CEP_G { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10          TAB-FAIXAS.*/
                public VA3437B_TAB_FAIXAS TAB_FAIXAS { get; set; } = new VA3437B_TAB_FAIXAS();
                public class VA3437B_TAB_FAIXAS : VarBasis
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
        public VA3437B_TABELA_MSG TABELA_MSG { get; set; } = new VA3437B_TABELA_MSG();
        public class VA3437B_TABELA_MSG : VarBasis
        {
            /*"    05        TAB-MSG             OCCURS 2000  TIMES.*/
            public ListBasis<VA3437B_TAB_MSG> TAB_MSG { get; set; } = new ListBasis<VA3437B_TAB_MSG>(2000);
            public class VA3437B_TAB_MSG : VarBasis
            {
                /*"      10      TABJ-CHAVE          PIC  X(023).*/
                public StringBasis TABJ_CHAVE { get; set; } = new StringBasis(new PIC("X", "23", "X(023)."), @"");
                /*"      10      TABJ-CHAVE-R        REDEFINES              TABJ-CHAVE.*/
                private _REDEF_VA3437B_TABJ_CHAVE_R _tabj_chave_r { get; set; }
                public _REDEF_VA3437B_TABJ_CHAVE_R TABJ_CHAVE_R
                {
                    get { _tabj_chave_r = new _REDEF_VA3437B_TABJ_CHAVE_R(); _.Move(TABJ_CHAVE, _tabj_chave_r); VarBasis.RedefinePassValue(TABJ_CHAVE, _tabj_chave_r, TABJ_CHAVE); _tabj_chave_r.ValueChanged += () => { _.Move(_tabj_chave_r, TABJ_CHAVE); }; return _tabj_chave_r; }
                    set { VarBasis.RedefinePassValue(value, _tabj_chave_r, TABJ_CHAVE); }
                }  //Redefines
                public class _REDEF_VA3437B_TABJ_CHAVE_R : VarBasis
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

                    public _REDEF_VA3437B_TABJ_CHAVE_R()
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
        public VA3437B_TAB_QTD_DIG_COMBINACAO TAB_QTD_DIG_COMBINACAO { get; set; } = new VA3437B_TAB_QTD_DIG_COMBINACAO();
        public class VA3437B_TAB_QTD_DIG_COMBINACAO : VarBasis
        {
            /*"    05        TAB-COMB            OCCURS  1000 TIMES.*/
            public ListBasis<VA3437B_TAB_COMB> TAB_COMB { get; set; } = new ListBasis<VA3437B_TAB_COMB>(1000);
            public class VA3437B_TAB_COMB : VarBasis
            {
                /*"      10      TAB-QTD-DIG         PIC  9(001).*/
                public IntBasis TAB_QTD_DIG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01                TB99.*/
            }
        }
        public VA3437B_TB99 TB99 { get; set; } = new VA3437B_TB99();
        public class VA3437B_TB99 : VarBasis
        {
            /*"    03            TB99-CONT           OCCURS  100  TIMES.*/
            public ListBasis<VA3437B_TB99_CONT> TB99_CONT { get; set; } = new ListBasis<VA3437B_TB99_CONT>(100);
            public class VA3437B_TB99_CONT : VarBasis
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
        public VA3437B_TABELA_NOMES TABELA_NOMES { get; set; } = new VA3437B_TABELA_NOMES();
        public class VA3437B_TABELA_NOMES : VarBasis
        {
            /*"    05            TAB-NOMES.*/
            public VA3437B_TAB_NOMES TAB_NOMES { get; set; } = new VA3437B_TAB_NOMES();
            public class VA3437B_TAB_NOMES : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES-R         REDEFINES  TAB-NOMES.*/
            }
            private _REDEF_VA3437B_TAB_NOMES_R _tab_nomes_r { get; set; }
            public _REDEF_VA3437B_TAB_NOMES_R TAB_NOMES_R
            {
                get { _tab_nomes_r = new _REDEF_VA3437B_TAB_NOMES_R(); _.Move(TAB_NOMES, _tab_nomes_r); VarBasis.RedefinePassValue(TAB_NOMES, _tab_nomes_r, TAB_NOMES); _tab_nomes_r.ValueChanged += () => { _.Move(_tab_nomes_r, TAB_NOMES); }; return _tab_nomes_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_r, TAB_NOMES); }
            }  //Redefines
            public class _REDEF_VA3437B_TAB_NOMES_R : VarBasis
            {
                /*"      10          TAB-NOME            OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES1.*/

                public _REDEF_VA3437B_TAB_NOMES_R()
                {
                    TAB_NOME.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA3437B_TABELA_NOMES1 TABELA_NOMES1 { get; set; } = new VA3437B_TABELA_NOMES1();
        public class VA3437B_TABELA_NOMES1 : VarBasis
        {
            /*"    05            TAB-NOMES1.*/
            public VA3437B_TAB_NOMES1 TAB_NOMES1 { get; set; } = new VA3437B_TAB_NOMES1();
            public class VA3437B_TAB_NOMES1 : VarBasis
            {
                /*"      10          FILLER              PIC X(040).*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05            TAB-NOMES1-R        REDEFINES  TAB-NOMES1.*/
            }
            private _REDEF_VA3437B_TAB_NOMES1_R _tab_nomes1_r { get; set; }
            public _REDEF_VA3437B_TAB_NOMES1_R TAB_NOMES1_R
            {
                get { _tab_nomes1_r = new _REDEF_VA3437B_TAB_NOMES1_R(); _.Move(TAB_NOMES1, _tab_nomes1_r); VarBasis.RedefinePassValue(TAB_NOMES1, _tab_nomes1_r, TAB_NOMES1); _tab_nomes1_r.ValueChanged += () => { _.Move(_tab_nomes1_r, TAB_NOMES1); }; return _tab_nomes1_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_r, TAB_NOMES1); }
            }  //Redefines
            public class _REDEF_VA3437B_TAB_NOMES1_R : VarBasis
            {
                /*"      10          TAB-NOME1           OCCURS  40  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 40);
                /*"01                TABELA-NOMES-SOC.*/

                public _REDEF_VA3437B_TAB_NOMES1_R()
                {
                    TAB_NOME1.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA3437B_TABELA_NOMES_SOC TABELA_NOMES_SOC { get; set; } = new VA3437B_TABELA_NOMES_SOC();
        public class VA3437B_TABELA_NOMES_SOC : VarBasis
        {
            /*"    05            TAB-NOMES-SOC.*/
            public VA3437B_TAB_NOMES_SOC TAB_NOMES_SOC { get; set; } = new VA3437B_TAB_NOMES_SOC();
            public class VA3437B_TAB_NOMES_SOC : VarBasis
            {
                /*"      10          FILLER              PIC X(100).*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    05            TAB-NOMES-SOC-R     REDEFINES  TAB-NOMES-SOC.*/
            }
            private _REDEF_VA3437B_TAB_NOMES_SOC_R _tab_nomes_soc_r { get; set; }
            public _REDEF_VA3437B_TAB_NOMES_SOC_R TAB_NOMES_SOC_R
            {
                get { _tab_nomes_soc_r = new _REDEF_VA3437B_TAB_NOMES_SOC_R(); _.Move(TAB_NOMES_SOC, _tab_nomes_soc_r); VarBasis.RedefinePassValue(TAB_NOMES_SOC, _tab_nomes_soc_r, TAB_NOMES_SOC); _tab_nomes_soc_r.ValueChanged += () => { _.Move(_tab_nomes_soc_r, TAB_NOMES_SOC); }; return _tab_nomes_soc_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes_soc_r, TAB_NOMES_SOC); }
            }  //Redefines
            public class _REDEF_VA3437B_TAB_NOMES_SOC_R : VarBasis
            {
                /*"      10          TAB-NOME-SOC        OCCURS 100  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME_SOC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 100);
                /*"01                TABELA-NOMES1-SOC.*/

                public _REDEF_VA3437B_TAB_NOMES_SOC_R()
                {
                    TAB_NOME_SOC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA3437B_TABELA_NOMES1_SOC TABELA_NOMES1_SOC { get; set; } = new VA3437B_TABELA_NOMES1_SOC();
        public class VA3437B_TABELA_NOMES1_SOC : VarBasis
        {
            /*"    05            TAB-NOMES1-SOC.*/
            public VA3437B_TAB_NOMES1_SOC TAB_NOMES1_SOC { get; set; } = new VA3437B_TAB_NOMES1_SOC();
            public class VA3437B_TAB_NOMES1_SOC : VarBasis
            {
                /*"      10          FILLER              PIC X(100).*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
                /*"    05            TAB-NOMES1-SOC-R    REDEFINES  TAB-NOMES1-SOC.*/
            }
            private _REDEF_VA3437B_TAB_NOMES1_SOC_R _tab_nomes1_soc_r { get; set; }
            public _REDEF_VA3437B_TAB_NOMES1_SOC_R TAB_NOMES1_SOC_R
            {
                get { _tab_nomes1_soc_r = new _REDEF_VA3437B_TAB_NOMES1_SOC_R(); _.Move(TAB_NOMES1_SOC, _tab_nomes1_soc_r); VarBasis.RedefinePassValue(TAB_NOMES1_SOC, _tab_nomes1_soc_r, TAB_NOMES1_SOC); _tab_nomes1_soc_r.ValueChanged += () => { _.Move(_tab_nomes1_soc_r, TAB_NOMES1_SOC); }; return _tab_nomes1_soc_r; }
                set { VarBasis.RedefinePassValue(value, _tab_nomes1_soc_r, TAB_NOMES1_SOC); }
            }  //Redefines
            public class _REDEF_VA3437B_TAB_NOMES1_SOC_R : VarBasis
            {
                /*"      10          TAB-NOME1-SOC       OCCURS 100  TIMES                                      PIC X(001).*/
                public ListBasis<StringBasis, string> TAB_NOME1_SOC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)."), 100);
                /*"01                TABELA-COBER.*/

                public _REDEF_VA3437B_TAB_NOMES1_SOC_R()
                {
                    TAB_NOME1_SOC.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA3437B_TABELA_COBER TABELA_COBER { get; set; } = new VA3437B_TABELA_COBER();
        public class VA3437B_TABELA_COBER : VarBasis
        {
            /*"    05            TAB-COBER.*/
            public VA3437B_TAB_COBER TAB_COBER { get; set; } = new VA3437B_TAB_COBER();
            public class VA3437B_TAB_COBER : VarBasis
            {
                /*"      10          FILLER              PIC X(045)  VALUE                 'COBERTURA DOEN�A GRAVE..................: R$ '*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"COBERTURA DOEN�A GRAVE..................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'SERVI�O ASSIST�NCIA FUNERAL.............: R$ '*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SERVI�O ASSIST�NCIA FUNERAL.............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ADIANTAMENTO AUXILIO FUNERAL(AT�).......: R$ '*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ADIANTAMENTO AUXILIO FUNERAL(AT�).......: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'CESTA BASICA............................: R$ '*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"CESTA BASICA............................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'AUX�LIO ALIMENTA��O.....................: R$ '*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"AUX�LIO ALIMENTA��O.....................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DOEN�AS CONGENITAS GRAVES...............: R$ '*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DOEN�AS CONGENITAS GRAVES...............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'INDENIZA��O RESCIS�O TRABALHISTA........: R$ '*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"INDENIZA��O RESCIS�O TRABALHISTA........: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DESEMPREGO INVOLUNTARIO.................: R$ '*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DESEMPREGO INVOLUNTARIO.................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'PERDA DE RENDA (AUTONOMO)...............: R$ '*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"PERDA DE RENDA (AUTONOMO)...............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'REMISS�O PR�MIO DESEMPREGO INVOLUNTARIO '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"REMISS�O PR�MIO DESEMPREGO INVOLUNTARIO ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DIAGNOSTICO DE CANCER...................: R$ '*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DIAGNOSTICO DE CANCER...................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'SERVI�O ASSIST�NCIA VIAGEM..............: R$ '*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"SERVI�O ASSIST�NCIA VIAGEM..............: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'EXTRAVIO DE BAGAGEM.....................: R$ '*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"EXTRAVIO DE BAGAGEM.....................: R$ ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'REMISS�O PR�MIO DIAGNOSTICO C�NCER      '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"REMISS�O PR�MIO DIAGNOSTICO C�NCER      ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'REMISS�O PR�MIO INDENIZA��O CDG         '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"REMISS�O PR�MIO INDENIZA��O CDG         ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ASSIST�NCIA FARMACIA                    '.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ASSIST�NCIA FARMACIA                    ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ASSIST�NCIA RESIDENCIAL                 '.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ASSIST�NCIA RESIDENCIAL                 ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ASSIST�NCIA VIAGEM                      '.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ASSIST�NCIA VIAGEM                      ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'ORIENTA��O NUTRICIONAL                  '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"ORIENTA��O NUTRICIONAL                  ");
                /*"      10          FILLER              PIC X(045)  VALUE                 'PAGAMENTO ANTECIPADO ESPECIAL POR DOENCA'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"PAGAMENTO ANTECIPADO ESPECIAL POR DOENCA");
                /*"      10          FILLER              PIC X(045)  VALUE                 'DESP MÉDICO HOSPITALAR ODONTOLÓGICA ATÉ:'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"DESP MÉDICO HOSPITALAR ODONTOLÓGICA ATÉ:");
                /*"    05            TAB-COBER-R         REDEFINES                  TAB-COBER.*/
            }
            private _REDEF_VA3437B_TAB_COBER_R _tab_cober_r { get; set; }
            public _REDEF_VA3437B_TAB_COBER_R TAB_COBER_R
            {
                get { _tab_cober_r = new _REDEF_VA3437B_TAB_COBER_R(); _.Move(TAB_COBER, _tab_cober_r); VarBasis.RedefinePassValue(TAB_COBER, _tab_cober_r, TAB_COBER); _tab_cober_r.ValueChanged += () => { _.Move(_tab_cober_r, TAB_COBER); }; return _tab_cober_r; }
                set { VarBasis.RedefinePassValue(value, _tab_cober_r, TAB_COBER); }
            }  //Redefines
            public class _REDEF_VA3437B_TAB_COBER_R : VarBasis
            {
                /*"      10          TAB-COBER-DESCR     OCCURS  21  TIMES                                      PIC X(045).*/
                public ListBasis<StringBasis, string> TAB_COBER_DESCR { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "45", "X(045)."), 21);
                /*"01                TABELA-MESES.*/

                public _REDEF_VA3437B_TAB_COBER_R()
                {
                    TAB_COBER_DESCR.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA3437B_TABELA_MESES TABELA_MESES { get; set; } = new VA3437B_TABELA_MESES();
        public class VA3437B_TABELA_MESES : VarBasis
        {
            /*"    05            TAB-MESES.*/
            public VA3437B_TAB_MESES TAB_MESES { get; set; } = new VA3437B_TAB_MESES();
            public class VA3437B_TAB_MESES : VarBasis
            {
                /*"      10          FILLER           PIC X(009) VALUE '  Janeiro'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  Janeiro");
                /*"      10          FILLER           PIC X(009) VALUE 'Fevereiro'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"Fevereiro");
                /*"      10          FILLER           PIC X(009) VALUE '    Mar�o'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Mar�o");
                /*"      10          FILLER           PIC X(009) VALUE '    Abril'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Abril");
                /*"      10          FILLER           PIC X(009) VALUE '     Maio'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     Maio");
                /*"      10          FILLER           PIC X(009) VALUE '    Junho'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Junho");
                /*"      10          FILLER           PIC X(009) VALUE '    Julho'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    Julho");
                /*"      10          FILLER           PIC X(009) VALUE '   Agosto'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   Agosto");
                /*"      10          FILLER           PIC X(009) VALUE ' Setembro'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Setembro");
                /*"      10          FILLER           PIC X(009) VALUE '  Outubro'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  Outubro");
                /*"      10          FILLER           PIC X(009) VALUE ' Novembro'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Novembro");
                /*"      10          FILLER           PIC X(009) VALUE ' Dezembro'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" Dezembro");
                /*"    05            TAB-MESES-R         REDEFINES                  TAB-MESES.*/
            }
            private _REDEF_VA3437B_TAB_MESES_R _tab_meses_r { get; set; }
            public _REDEF_VA3437B_TAB_MESES_R TAB_MESES_R
            {
                get { _tab_meses_r = new _REDEF_VA3437B_TAB_MESES_R(); _.Move(TAB_MESES, _tab_meses_r); VarBasis.RedefinePassValue(TAB_MESES, _tab_meses_r, TAB_MESES); _tab_meses_r.ValueChanged += () => { _.Move(_tab_meses_r, TAB_MESES); }; return _tab_meses_r; }
                set { VarBasis.RedefinePassValue(value, _tab_meses_r, TAB_MESES); }
            }  //Redefines
            public class _REDEF_VA3437B_TAB_MESES_R : VarBasis
            {
                /*"      10          TAB-MES             OCCURS  12  TIMES                                      PIC X(009).*/
                public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
                /*"01                WABEND.*/

                public _REDEF_VA3437B_TAB_MESES_R()
                {
                    TAB_MES.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA3437B_WABEND WABEND { get; set; } = new VA3437B_WABEND();
        public class VA3437B_WABEND : VarBasis
        {
            /*"      05          FILLER              PIC X(010) VALUE                 ' VA3437B'.*/
            public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA3437B");
            /*"      05          FILLER              PIC X(026) VALUE                 ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"      05          WNR-EXEC-SQL        PIC X(004) VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"      05          FILLER              PIC X(013) VALUE                 ' *** SQLCODE '.*/
            public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"      05          WSQLCODE            PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  LK-PARAMETROS.*/
        }
        public VA3437B_LK_PARAMETROS LK_PARAMETROS { get; set; } = new VA3437B_LK_PARAMETROS();
        public class VA3437B_LK_PARAMETROS : VarBasis
        {
            /*"  04  FILLER                  PIC X(002).*/
            public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  04  LK-OPERACAO             PIC X(008).*/

            public SelectorBasis LK_OPERACAO { get; set; } = new SelectorBasis("008")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88  LK-COMMIT                 VALUE 'COMMIT  '. */
							new SelectorItemBasis("LK_COMMIT", "COMMIT "),
							/*" 88  LK-ROLLBACK               VALUE 'ROLLBACK'. */
							new SelectorItemBasis("LK_ROLLBACK", "ROLLBACK")
                }
            };

            /*"  04  FILLER                  PIC X(001).*/
            public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  04  LK-DT-PROCESSAMENTO     PIC X(010).*/
            public StringBasis LK_DT_PROCESSAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  04  FILLER                  PIC X(001).*/
            public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        }


        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.VGCOBSUB VGCOBSUB { get; set; } = new Dclgens.VGCOBSUB();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
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
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA3437B_CFAIXACEP CFAIXACEP { get; set; } = new VA3437B_CFAIXACEP();
        public VA3437B_CMSG CMSG { get; set; } = new VA3437B_CMSG();
        public VA3437B_CFCPLANO CFCPLANO { get; set; } = new VA3437B_CFCPLANO();
        public VA3437B_V1AGENCEF V1AGENCEF { get; set; } = new VA3437B_V1AGENCEF();
        public VA3437B_CRELAT CRELAT { get; set; } = new VA3437B_CRELAT();
        public VA3437B_CTITFEDCA CTITFEDCA { get; set; } = new VA3437B_CTITFEDCA();
        public VA3437B_COBER COBER { get; set; } = new VA3437B_COBER();
        public VA3437B_V0BENEF V0BENEF { get; set; } = new VA3437B_V0BENEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA3437B_LK_PARAMETROS VA3437B_LK_PARAMETROS_P, string RVA3437B_FILE_NAME_P, string SVA3437B_FILE_NAME_P, string FVA3437B_FILE_NAME_P, string IMP3437B_FILE_NAME_P, string PDF3437B_FILE_NAME_P, string VDHTML01_FILE_NAME_P, string VDHTML09_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LK_PARAMETROS*/
        {
            try
            {
                this.LK_PARAMETROS = VA3437B_LK_PARAMETROS_P;
                RVA3437B.SetFile(RVA3437B_FILE_NAME_P);
                SVA3437B.SetFile(SVA3437B_FILE_NAME_P);
                FVA3437B.SetFile(FVA3437B_FILE_NAME_P);
                IMP3437B.SetFile(IMP3437B_FILE_NAME_P);
                PDF3437B.SetFile(PDF3437B_FILE_NAME_P);
                VDHTML01.SetFile(VDHTML01_FILE_NAME_P);
                VDHTML09.SetFile(VDHTML09_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1407- DISPLAY ' ' */
            _.Display($" ");

            /*" -1409- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1419- DISPLAY 'PROGRAMA VA3437B-VERSAO V.40 ' '- DEMANDA 582106 - 13/08/2024.' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) '-' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"PROGRAMA VA3437B-VERSAO V.40 - DEMANDA 582106 - 13/08/2024.FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)}-FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -1421- DISPLAY '---------------------------------------------------' '---------------------------------------------------' */
            _.Display($"------------------------------------------------------------------------------------------------------");

            /*" -1422- DISPLAY ' ' */
            _.Display($" ");

            /*" -1429- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1430- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -1431- DISPLAY 'PARAMETRO INFORMADO <' LK-OPERACAO '>' */

            $"PARAMETRO INFORMADO <{LK_PARAMETROS.LK_OPERACAO}>"
            .Display();

            /*" -1432- DISPLAY '          DATA      <' LK-DT-PROCESSAMENTO '>' */

            $"          DATA      <{LK_PARAMETROS.LK_DT_PROCESSAMENTO}>"
            .Display();

            /*" -1434- DISPLAY '------------------------------------------------' . */
            _.Display($"------------------------------------------------");

            /*" -1435- IF LK-COMMIT OR LK-ROLLBACK */

            if (LK_PARAMETROS.LK_OPERACAO["LK_COMMIT"] || LK_PARAMETROS.LK_OPERACAO["LK_ROLLBACK"])
            {

                /*" -1436- CONTINUE */

                /*" -1437- ELSE */
            }
            else
            {


                /*" -1439- DISPLAY '==> PARAMETROS COM ERRO. INFORME <COMMIT > OU < 'ROLLBACK> => ' LK-OPERACAO */

                $"==> PARAMETROS COM ERRO. INFORME <COMMIT > OU < ROLLBACK>=>{LK_PARAMETROS.LK_OPERACAO}"
                .Display();

                /*" -1440- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -1441- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1443- END-IF */
            }


            /*" -1444- IF LK-DT-PROCESSAMENTO EQUAL LOW-VALUES */

            if (LK_PARAMETROS.LK_DT_PROCESSAMENTO.IsLowValues())
            {

                /*" -1445- MOVE SPACES TO LK-DT-PROCESSAMENTO */
                _.Move("", LK_PARAMETROS.LK_DT_PROCESSAMENTO);

                /*" -1447- END-IF. */
            }


            /*" -1449- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -1450- IF WFIM-SISTEMAS NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMAS.IsEmpty())
            {

                /*" -1451- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -1453- END-IF */
            }


            /*" -1456- INITIALIZE TAB-FILIAL TAB-QTD-DIG-COMBINACAO */
            _.Initialize(
                TAB_FILIAL
                , TAB_QTD_DIG_COMBINACAO
            );

            /*" -1458- PERFORM R0500-00-DECLARE-AGENCCEF */

            R0500_00_DECLARE_AGENCCEF_SECTION();

            /*" -1460- PERFORM R0510-00-FETCH-AGENCCEF */

            R0510_00_FETCH_AGENCCEF_SECTION();

            /*" -1461- IF WFIM-AGENCCEF NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_AGENCCEF.IsEmpty())
            {

                /*" -1462- DISPLAY 'R0000 - PROBLEMA NO FETCH DA AGENCCEF ' */
                _.Display($"R0000 - PROBLEMA NO FETCH DA AGENCCEF ");

                /*" -1463- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1465- END-IF */
            }


            /*" -1467- PERFORM R0520-00-CARREGA-FILIAL UNTIL WFIM-AGENCCEF = 'S' */

            while (!(AREA_DE_WORK.WFIM_AGENCCEF == "S"))
            {

                R0520_00_CARREGA_FILIAL_SECTION();
            }

            /*" -1469- PERFORM R0900-00-DECLARE-RELATORI */

            R0900_00_DECLARE_RELATORI_SECTION();

            /*" -1471- PERFORM R0910-00-FETCH-RELATORI */

            R0910_00_FETCH_RELATORI_SECTION();

            /*" -1472- IF WFIM-RELATORI = 'S' */

            if (AREA_DE_WORK.WFIM_RELATORI == "S")
            {

                /*" -1473- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -1474- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1475- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1477- END-IF */
            }


            /*" -1479- PERFORM R0200-00-CARREGA-FAIXACEP */

            R0200_00_CARREGA_FAIXACEP_SECTION();

            /*" -1481- PERFORM R0300-00-CARREGA-COBMENVG */

            R0300_00_CARREGA_COBMENVG_SECTION();

            /*" -1491- PERFORM R0400-00-CARREGA-FCPLANO */

            R0400_00_CARREGA_FCPLANO_SECTION();

            /*" -1500- SORT SVA3437B ON ASCENDING KEY SVA-TP-ARQSAIDA SVA-CODRELAT SVA-NRAPOLICE SVA-CODSUBES SVA-CEP-G SVA-NUM-CEP INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-IMPRIME THRU R0020-FIM. */
            SORT_RETURN.Value = SVA3437B.Sort("SVA-TP-ARQSAIDA,SVA-CODRELAT,SVA-NRAPOLICE,SVA-CODSUBES,SVA-CEP-G,SVA-NUM-CEP", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_IMPRIME_SECTION());

            /*" -1503- IF SORT-RETURN NOT = ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1504- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1508- DISPLAY '--> VA3437B ERRO NA ROTINA DE SORT AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"--> VA3437B ERRO NA ROTINA DE SORT AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -1509- DISPLAY '--> VA3437B SORT-RETURN < ' SORT-RETURN '>' */

                $"--> VA3437B SORT-RETURN < {SORT_RETURN}>"
                .Display();

                /*" -1510- DISPLAY ' ' */
                _.Display($" ");

                /*" -1511- DISPLAY 'LIDOS CRELAT..... : ' AC-L-RELATORI */
                _.Display($"LIDOS CRELAT..... : {AREA_DE_WORK.AC_L_RELATORI}");

                /*" -1512- DISPLAY ' ' */
                _.Display($" ");

                /*" -1513- DISPLAY 'DESP VA54........ : ' AC-DESPR-VA54 */
                _.Display($"DESP VA54........ : {AREA_DE_WORK.AC_DESPR_VA54}");

                /*" -1514- DISPLAY 'DESP VIDA10.(VA54): ' AC-DESPR-VIDA10 */
                _.Display($"DESP VIDA10.(VA54): {AREA_DE_WORK.AC_DESPR_VIDA10}");

                /*" -1515- DISPLAY 'DESP V0COBERPRO   : ' AC-DESPR-COBERPRO */
                _.Display($"DESP V0COBERPRO   : {AREA_DE_WORK.AC_DESPR_COBERPRO}");

                /*" -1516- DISPLAY 'DESP TITULO S/VIG : ' AC-DESPR-TITULO */
                _.Display($"DESP TITULO S/VIG : {AREA_DE_WORK.AC_DESPR_TITULO}");

                /*" -1517- DISPLAY 'DESP CERTIF...... : ' AC-DESPR-CERTIF */
                _.Display($"DESP CERTIF...... : {AREA_DE_WORK.AC_DESPR_CERTIF}");

                /*" -1518- DISPLAY 'DESP DUPLIC...... : ' AC-DESPR-DUPLIC */
                _.Display($"DESP DUPLIC...... : {AREA_DE_WORK.AC_DESPR_DUPLIC}");

                /*" -1519- DISPLAY 'DESP V0SEGURAVG   : ' AC-DESPR-SEGURAVG */
                _.Display($"DESP V0SEGURAVG   : {AREA_DE_WORK.AC_DESPR_SEGURAVG}");

                /*" -1520- DISPLAY 'DESP V0OPCAOPAGVA : ' AC-DESPR-OPCAOPAG */
                _.Display($"DESP V0OPCAOPAGVA : {AREA_DE_WORK.AC_DESPR_OPCAOPAG}");

                /*" -1521- DISPLAY 'DESP V0CLIENTE    : ' AC-DESPR-CLIENTE */
                _.Display($"DESP V0CLIENTE    : {AREA_DE_WORK.AC_DESPR_CLIENTE}");

                /*" -1522- DISPLAY 'DESP V0ENDERECO   : ' AC-DESPR-ENDERECO */
                _.Display($"DESP V0ENDERECO   : {AREA_DE_WORK.AC_DESPR_ENDERECO}");

                /*" -1523- DISPLAY ' ' */
                _.Display($" ");

                /*" -1524- DISPLAY '--> GRAVADO SORT..: ' AC-GRAV-SORT */
                _.Display($"--> GRAVADO SORT..: {AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -1525- DISPLAY '--> APOLICE   ....: ' WHOST-NRAPOLICE */
                _.Display($"--> APOLICE   ....: {WHOST_NRAPOLICE}");

                /*" -1526- DISPLAY '--> SUBGRUPO  ....: ' WHOST-CODSUBES */
                _.Display($"--> SUBGRUPO  ....: {WHOST_CODSUBES}");

                /*" -1527- DISPLAY '--> IMPRESSOS ....: ' AC-IMPRESSOS */
                _.Display($"--> IMPRESSOS ....: {AREA_DE_WORK.AC_IMPRESSOS}");

                /*" -1528- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1529- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -1530- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -1530- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1537- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1539- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1540- MOVE ALL '-' TO FVA3437B-RECORD */
            _.MoveAll("-", FVA3437B_RECORD);

            /*" -1542- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1543- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1544- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1546- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1547- MOVE 'ESTATISTICAS DO PROCESSAMENTO' TO FVA3437B-RECORD */
            _.Move("ESTATISTICAS DO PROCESSAMENTO", FVA3437B_RECORD);

            /*" -1548- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1550- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1551- MOVE '-----------------------------' TO FVA3437B-RECORD */
            _.Move("-----------------------------", FVA3437B_RECORD);

            /*" -1552- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1554- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1559- STRING 'LIDOS V0RELATORIOS       ' AC-L-RELATORI DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl1 = "LIDOS V0RELATORIOS " + AREA_DE_WORK.AC_L_RELATORI.GetMoveValues();
            _.Move(spl1, FVA3437B_RECORD);
            #endregion

            /*" -1560- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1562- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1567- STRING 'CERTIFICADOS IMPRESSOS   ' AC-IMPRESSOS DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl2 = "CERTIFICADOS IMPRESSOS " + AREA_DE_WORK.AC_IMPRESSOS.GetMoveValues();
            _.Move(spl2, FVA3437B_RECORD);
            #endregion

            /*" -1568- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1570- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1575- STRING 'DESPREZADOS CANCELAMEN   ' AC-DESPR-CANCEL DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl3 = "DESPREZADOS CANCELAMEN " + AREA_DE_WORK.AC_DESPR_CANCEL.GetMoveValues();
            _.Move(spl3, FVA3437B_RECORD);
            #endregion

            /*" -1576- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1578- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1583- STRING 'DESPREZADOS V0SEGURAVG   ' AC-DESPR-SEGURAVG DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl4 = "DESPREZADOS V0SEGURAVG " + AREA_DE_WORK.AC_DESPR_SEGURAVG.GetMoveValues();
            _.Move(spl4, FVA3437B_RECORD);
            #endregion

            /*" -1584- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1586- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1591- STRING 'DESPREZADOS V0OPCAOPAGVA ' AC-DESPR-OPCAOPAG DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl5 = "DESPREZADOS V0OPCAOPAGVA " + AREA_DE_WORK.AC_DESPR_OPCAOPAG.GetMoveValues();
            _.Move(spl5, FVA3437B_RECORD);
            #endregion

            /*" -1592- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1594- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1599- STRING 'DESPREZADOS V0CLIENTE    ' AC-DESPR-CLIENTE DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl6 = "DESPREZADOS V0CLIENTE " + AREA_DE_WORK.AC_DESPR_CLIENTE.GetMoveValues();
            _.Move(spl6, FVA3437B_RECORD);
            #endregion

            /*" -1600- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1602- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1607- STRING 'DESPREZADOS V0ENDERECO   ' AC-DESPR-ENDERECO DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl7 = "DESPREZADOS V0ENDERECO " + AREA_DE_WORK.AC_DESPR_ENDERECO.GetMoveValues();
            _.Move(spl7, FVA3437B_RECORD);
            #endregion

            /*" -1608- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1610- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1615- STRING 'DESPREZADOS V0COBERPRO   ' AC-DESPR-COBERPRO DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl8 = "DESPREZADOS V0COBERPRO " + AREA_DE_WORK.AC_DESPR_COBERPRO.GetMoveValues();
            _.Move(spl8, FVA3437B_RECORD);
            #endregion

            /*" -1620- STRING 'TITULO SEM INICIO E FIM DE VIGNCIA ' AC-DESPR-TITULO DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl9 = "TITULO SEM INICIO E FIM DE VIGNCIA " + AREA_DE_WORK.AC_DESPR_TITULO.GetMoveValues();
            _.Move(spl9, FVA3437B_RECORD);
            #endregion

            /*" -1621- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1622- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1624- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1625- MOVE 'SORT' TO FVA3437B-RECORD */
            _.Move("SORT", FVA3437B_RECORD);

            /*" -1626- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1628- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1629- MOVE '----' TO FVA3437B-RECORD */
            _.Move("----", FVA3437B_RECORD);

            /*" -1630- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1631- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1632- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1634- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1639- STRING 'DESPREZADOS V0COBERAPOL  ' AC-DESPR-APOLICOB DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl10 = "DESPREZADOS V0COBERAPOL " + AREA_DE_WORK.AC_DESPR_APOLICOB.GetMoveValues();
            _.Move(spl10, FVA3437B_RECORD);
            #endregion

            /*" -1640- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1642- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1647- STRING 'DESPREZADOS V0HISTSEGVG  ' AC-DESPR-SEGVGAPH DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl11 = "DESPREZADOS V0HISTSEGVG " + AREA_DE_WORK.AC_DESPR_SEGVGAPH.GetMoveValues();
            _.Move(spl11, FVA3437B_RECORD);
            #endregion

            /*" -1648- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1650- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1655- STRING 'DESPREZADOS V0COTACAO    ' AC-DESPR-MOEDACOT DELIMITED BY SIZE INTO FVA3437B-RECORD END-STRING */
            #region STRING
            var spl12 = "DESPREZADOS V0COTACAO " + AREA_DE_WORK.AC_DESPR_MOEDACOT.GetMoveValues();
            _.Move(spl12, FVA3437B_RECORD);
            #endregion

            /*" -1656- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1658- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -1659- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1660- MOVE '*** VA3437B - TERMINO NORMAL ***' TO FVA3437B-RECORD */
            _.Move("*** VA3437B - TERMINO NORMAL ***", FVA3437B_RECORD);

            /*" -1662- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -1664- PERFORM R9000-00-CLOSE-ARQUIVOS */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -1666- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1667- IF LK-COMMIT */

            if (LK_PARAMETROS.LK_OPERACAO["LK_COMMIT"])
            {

                /*" -1667- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1669- DISPLAY ' ' */
                _.Display($" ");

                /*" -1670- DISPLAY '==> COMMIT EXECUTADO POR PARAMETRO' */
                _.Display($"==> COMMIT EXECUTADO POR PARAMETRO");

                /*" -1671- ELSE */
            }
            else
            {


                /*" -1671- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1673- DISPLAY ' ' */
                _.Display($" ");

                /*" -1674- DISPLAY '==> ROLLBACK EXECUTADO POR PARAMETRO' */
                _.Display($"==> ROLLBACK EXECUTADO POR PARAMETRO");

                /*" -1676- END-IF */
            }


            /*" -1677- DISPLAY ' ' */
            _.Display($" ");

            /*" -1678- DISPLAY '-----------------------------' */
            _.Display($"-----------------------------");

            /*" -1679- DISPLAY 'ESTATISTICAS DO PROCESSAMENTO' */
            _.Display($"ESTATISTICAS DO PROCESSAMENTO");

            /*" -1680- DISPLAY '-----------------------------' */
            _.Display($"-----------------------------");

            /*" -1681- DISPLAY 'LIDOS V0RELATORIOS         ' AC-L-RELATORI. */
            _.Display($"LIDOS V0RELATORIOS         {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -1682- DISPLAY 'CERTIFICADOS IMPRESSOS     ' AC-IMPRESSOS. */
            _.Display($"CERTIFICADOS IMPRESSOS     {AREA_DE_WORK.AC_IMPRESSOS}");

            /*" -1683- DISPLAY 'VA33 IMPRESSOS             ' AC-GRAVA-VA33. */
            _.Display($"VA33 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA33}");

            /*" -1684- DISPLAY 'VA44 IMPRESSOS             ' AC-GRAVA-VA44. */
            _.Display($"VA44 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA44}");

            /*" -1685- DISPLAY 'VA54 IMPRESSOS             ' AC-GRAVA-VA54. */
            _.Display($"VA54 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA54}");

            /*" -1686- DISPLAY 'VA82 IMPRESSOS             ' AC-GRAVA-VA82. */
            _.Display($"VA82 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA82}");

            /*" -1687- DISPLAY 'VA83 IMPRESSOS             ' AC-GRAVA-VA83. */
            _.Display($"VA83 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VA83}");

            /*" -1688- DISPLAY 'VD08 IMPRESSOS             ' AC-GRAVA-VD08. */
            _.Display($"VD08 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VD08}");

            /*" -1690- DISPLAY 'VD09 IMPRESSOS             ' AC-GRAVA-VD09. */
            _.Display($"VD09 IMPRESSOS             {AREA_DE_WORK.AC_GRAVA_VD09}");

            /*" -1691- DISPLAY 'VIDA07 IMPRESSOS (VA33)  = ' AC-GRAVA-VIDA07. */
            _.Display($"VIDA07 IMPRESSOS (VA33)  = {AREA_DE_WORK.AC_GRAVA_VIDA07}");

            /*" -1693- DISPLAY 'VIDA05 IMPRESSOS (VA44,VA82,VA83) = ' AC-GRAVA-VIDA05. */
            _.Display($"VIDA05 IMPRESSOS (VA44,VA82,VA83) = {AREA_DE_WORK.AC_GRAVA_VIDA05}");

            /*" -1694- DISPLAY 'VIDA10 IMPRESSOS (VA54)  = ' AC-GRAVA-VIDA10. */
            _.Display($"VIDA10 IMPRESSOS (VA54)  = {AREA_DE_WORK.AC_GRAVA_VIDA10}");

            /*" -1695- DISPLAY 'VIDA17 IMPRESSOS (VD08)  = ' AC-GRAVA-VIDA17. */
            _.Display($"VIDA17 IMPRESSOS (VD08)  = {AREA_DE_WORK.AC_GRAVA_VIDA17}");

            /*" -1697- DISPLAY 'VIDA18 IMPRESSOS (VD09)  = ' AC-GRAVA-VIDA18. */
            _.Display($"VIDA18 IMPRESSOS (VD09)  = {AREA_DE_WORK.AC_GRAVA_VIDA18}");

            /*" -1698- DISPLAY 'DESPREZADOS CANCELAMENTO   ' AC-DESPR-CANCEL. */
            _.Display($"DESPREZADOS CANCELAMENTO   {AREA_DE_WORK.AC_DESPR_CANCEL}");

            /*" -1699- DISPLAY 'DESPREZADOS V0SEGURAVG     ' AC-DESPR-SEGURAVG. */
            _.Display($"DESPREZADOS V0SEGURAVG     {AREA_DE_WORK.AC_DESPR_SEGURAVG}");

            /*" -1700- DISPLAY 'DESPREZADOS V0OPCAOPAGVA   ' AC-DESPR-OPCAOPAG. */
            _.Display($"DESPREZADOS V0OPCAOPAGVA   {AREA_DE_WORK.AC_DESPR_OPCAOPAG}");

            /*" -1701- DISPLAY 'DESPREZADOS V0CLIENTE      ' AC-DESPR-CLIENTE. */
            _.Display($"DESPREZADOS V0CLIENTE      {AREA_DE_WORK.AC_DESPR_CLIENTE}");

            /*" -1702- DISPLAY 'DESPREZADOS V0ENDERECO     ' AC-DESPR-ENDERECO. */
            _.Display($"DESPREZADOS V0ENDERECO     {AREA_DE_WORK.AC_DESPR_ENDERECO}");

            /*" -1703- DISPLAY 'DESPREZADOS V0COBERPRO     ' AC-DESPR-COBERPRO. */
            _.Display($"DESPREZADOS V0COBERPRO     {AREA_DE_WORK.AC_DESPR_COBERPRO}");

            /*" -1704- DISPLAY 'DESPREZADOS TITULO S/VIGEN ' AC-DESPR-TITULO. */
            _.Display($"DESPREZADOS TITULO S/VIGEN {AREA_DE_WORK.AC_DESPR_TITULO}");

            /*" -1705- DISPLAY 'DESP VA54................. ' AC-DESPR-VA54 */
            _.Display($"DESP VA54................. {AREA_DE_WORK.AC_DESPR_VA54}");

            /*" -1706- DISPLAY 'DESP VIDA10. (VA54)....... ' AC-DESPR-VIDA10 */
            _.Display($"DESP VIDA10. (VA54)....... {AREA_DE_WORK.AC_DESPR_VIDA10}");

            /*" -1707- DISPLAY 'DESP CERTIF............... ' AC-DESPR-CERTIF. */
            _.Display($"DESP CERTIF............... {AREA_DE_WORK.AC_DESPR_CERTIF}");

            /*" -1708- DISPLAY 'DESP DUPLIC............... ' AC-DESPR-DUPLIC. */
            _.Display($"DESP DUPLIC............... {AREA_DE_WORK.AC_DESPR_DUPLIC}");

            /*" -1709- DISPLAY ' ' */
            _.Display($" ");

            /*" -1710- DISPLAY 'SORT' */
            _.Display($"SORT");

            /*" -1711- DISPLAY '----' */
            _.Display($"----");

            /*" -1712- DISPLAY 'DESPREZADOS V0COBERAPOL    ' AC-DESPR-APOLICOB. */
            _.Display($"DESPREZADOS V0COBERAPOL    {AREA_DE_WORK.AC_DESPR_APOLICOB}");

            /*" -1713- DISPLAY 'DESPREZADOS V0HISTSEGVG    ' AC-DESPR-SEGVGAPH. */
            _.Display($"DESPREZADOS V0HISTSEGVG    {AREA_DE_WORK.AC_DESPR_SEGVGAPH}");

            /*" -1714- DISPLAY 'DESPREZADOS V0COTACAO      ' AC-DESPR-MOEDACOT. */
            _.Display($"DESPREZADOS V0COTACAO      {AREA_DE_WORK.AC_DESPR_MOEDACOT}");

            /*" -1715- DISPLAY ' ' */
            _.Display($" ");

            /*" -1716- DISPLAY '*** VA3437B - TERMINO NORMAL ***' */
            _.Display($"*** VA3437B - TERMINO NORMAL ***");

            /*" -1718- DISPLAY ' ' */
            _.Display($" ");

            /*" -1726- DISPLAY 'ENCERROU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"ENCERROU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1726- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -1735- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-RELATORI = 'S' . */

            while (!(AREA_DE_WORK.WFIM_RELATORI == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-IMPRIME-SECTION */
        private void R0020_00_IMPRIME_SECTION()
        {
            /*" -1746- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -1748- MOVE ZEROS TO WIND */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -1750- PERFORM R2300-00-LE-SORT */

            R2300_00_LE_SORT_SECTION();

            /*" -1750- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT = 'S' . */

            while (!(AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -1761- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -1762- IF LK-DT-PROCESSAMENTO EQUAL '0001-01-01' OR SPACES */

            if (LK_PARAMETROS.LK_DT_PROCESSAMENTO.In("0001-01-01", string.Empty))
            {

                /*" -1776- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

                R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

                /*" -1778- ELSE */
            }
            else
            {


                /*" -1792- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_2 */

                R0100_00_SELECT_SISTEMAS_DB_SELECT_2();

                /*" -1795- END-IF */
            }


            /*" -1796- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1797- DISPLAY 'R0100 - SISTEMA FI NAO ESTA CADASTRADO' */
                _.Display($"R0100 - SISTEMA FI NAO ESTA CADASTRADO");

                /*" -1798- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                /*" -1799- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -1801- END-IF. */
            }


            /*" -1802- IF SQLCODE NOT EQUAL +0 */

            if (DB.SQLCODE != +0)
            {

                /*" -1803- IF SQLCODE EQUAL -180 */

                if (DB.SQLCODE == -180)
                {

                    /*" -1804- DISPLAY 'R0100 - DATA PARAMETRO INVALIDA ' SQLCODE */
                    _.Display($"R0100 - DATA PARAMETRO INVALIDA {DB.SQLCODE}");

                    /*" -1805- MOVE '0001-01-01' TO LK-DT-PROCESSAMENTO */
                    _.Move("0001-01-01", LK_PARAMETROS.LK_DT_PROCESSAMENTO);

                    /*" -1806- GO TO R0100-00-SELECT-SISTEMAS */
                    new Task(() => R0100_00_SELECT_SISTEMAS_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1807- ELSE */
                }
                else
                {


                    /*" -1808- DISPLAY 'VA3437B-ERRO SELECT SISTEMAS FI ' SQLCODE */
                    _.Display($"VA3437B-ERRO SELECT SISTEMAS FI {DB.SQLCODE}");

                    /*" -1809- MOVE 'S' TO WFIM-SISTEMAS */
                    _.Move("S", AREA_DE_WORK.WFIM_SISTEMAS);

                    /*" -1810- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1811- END-IF */
                }


                /*" -1813- END-IF. */
            }


            /*" -1814- DISPLAY 'VA3437B-DT MOV ABERTO = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"VA3437B-DT MOV ABERTO = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1817- DISPLAY 'VA3437B-SELECIONA RELATORIOS A PARTIR DE ' SISTEMAS-DATA-MOV-ABERTO-15D */
            _.Display($"VA3437B-SELECIONA RELATORIOS A PARTIR DE {SISTEMAS_DATA_MOV_ABERTO_15D}");

            /*" -1820- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO LC11-DATADIA (1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 1, 2);

            /*" -1823- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO LC11-DATADIA (4:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 4, 2);

            /*" -1826- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO LC11-DATADIA (7:4). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 7, 4);

            /*" -1828- MOVE '/' TO LC11-DATADIA(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 6, 1);

            /*" -1828- MOVE '/' TO LC11-DATADIA(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DATADIA, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -1776- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO - 1 YEAR, DATA_MOV_ABERTO - 15 DAYS, MONTH(DATA_MOV_ABERTO), YEAR(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1, :SISTEMAS-DATA-MOV-ABERTO-15D, :V1SIST-MESREFER, :V1SIST-ANOREFER FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC */

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
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-2 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_2()
        {
            /*" -1792- EXEC SQL SELECT DATE(:LK-DT-PROCESSAMENTO), DATE(:LK-DT-PROCESSAMENTO) - 1 YEAR, DATE(:LK-DT-PROCESSAMENTO) - 15 DAYS, MONTH(DATE(:LK-DT-PROCESSAMENTO)), YEAR(DATE(:LK-DT-PROCESSAMENTO)) INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO-1, :SISTEMAS-DATA-MOV-ABERTO-15D, :V1SIST-MESREFER, :V1SIST-ANOREFER FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1()
            {
                LK_DT_PROCESSAMENTO = LK_PARAMETROS.LK_DT_PROCESSAMENTO.ToString(),
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_1);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_15D, SISTEMAS_DATA_MOV_ABERTO_15D);
                _.Move(executed_1.V1SIST_MESREFER, V1SIST_MESREFER);
                _.Move(executed_1.V1SIST_ANOREFER, V1SIST_ANOREFER);
            }


        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-SECTION */
        private void R0200_00_CARREGA_FAIXACEP_SECTION()
        {
            /*" -1840- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -1854- PERFORM R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1 */

            R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1();

            /*" -1857- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1858- DISPLAY 'R0200 - ERRO DECLARE CURSOR CFAIXACEP' */
                _.Display($"R0200 - ERRO DECLARE CURSOR CFAIXACEP");

                /*" -1859- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -1861- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1861- PERFORM R0200_00_CARREGA_FAIXACEP_DB_OPEN_1 */

            R0200_00_CARREGA_FAIXACEP_DB_OPEN_1();

            /*" -1864- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1865- DISPLAY 'R0200 - ERRO OPEN CURSOR CFAIXACEP' */
                _.Display($"R0200 - ERRO OPEN CURSOR CFAIXACEP");

                /*" -1866- DISPLAY '          SQLCODE = ' SQLCODE */
                _.Display($"          SQLCODE = {DB.SQLCODE}");

                /*" -1867- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1869- END-IF. */
            }


            /*" -1870- PERFORM R0210-00-FETCH-FAIXACEP UNTIL WFIM-FAIXACEP EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FAIXACEP == "S"))
            {

                R0210_00_FETCH_FAIXACEP_SECTION();
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-FAIXACEP-DB-DECLARE-1 */
        public void R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1()
        {
            /*" -1854- EXEC SQL DECLARE CFAIXACEP CURSOR FOR SELECT FAIXA, CEP_INICIAL, CEP_FINAL, DESCRICAO_FAIXA, CENTRALIZADOR FROM SEGUROS.GE_FAIXA_CEP WHERE DATA_INIVIGENCIA <= :SISTEMAS-DATA-MOV-ABERTO AND DATA_TERVIGENCIA >= :SISTEMAS-DATA-MOV-ABERTO ORDER BY FAIXA WITH UR END-EXEC. */
            CFAIXACEP = new VA3437B_CFAIXACEP(true);
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
            /*" -1861- EXEC SQL OPEN CFAIXACEP END-EXEC. */

            CFAIXACEP.Open();

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-DECLARE-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_DECLARE_1()
        {
            /*" -1933- EXEC SQL DECLARE CMSG CURSOR FOR SELECT NUM_APOLICE, CODSUBES, COD_OPERACAO, JDE, JDL, IDFORM FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM IN ( 'A4' , 'A5' ) AND COD_OPERACAO IN ( 2, 6, 10 ) ORDER BY 1,2,3 WITH UR END-EXEC. */
            CMSG = new VA3437B_CMSG(false);
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
            /*" -1882- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", WABEND.WNR_EXEC_SQL);

            /*" -1889- PERFORM R0210_00_FETCH_FAIXACEP_DB_FETCH_1 */

            R0210_00_FETCH_FAIXACEP_DB_FETCH_1();

            /*" -1892- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1893- MOVE 'S' TO WFIM-FAIXACEP */
                _.Move("S", AREA_DE_WORK.WFIM_FAIXACEP);

                /*" -1893- PERFORM R0210_00_FETCH_FAIXACEP_DB_CLOSE_1 */

                R0210_00_FETCH_FAIXACEP_DB_CLOSE_1();

                /*" -1897- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1899- MOVE GEFAICEP-FAIXA TO TAB-FX-CEP-G (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FX_CEP_G);

            /*" -1901- MOVE GEFAICEP-CEP-INICIAL TO TAB-FX-INI (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_INICIAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_INI);

            /*" -1903- MOVE GEFAICEP-CEP-FINAL TO TAB-FX-FIM (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CEP_FINAL, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_FIM);

            /*" -1905- MOVE GEFAICEP-DESCRICAO-FAIXA TO TAB-FX-NOME (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_DESCRICAO_FAIXA, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_NOME);

            /*" -1908- MOVE GEFAICEP-CENTRALIZADOR TO TAB-FX-CENTR (GEFAICEP-FAIXA). */
            _.Move(GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_CENTRALIZADOR, TABELA_CEP.CEP[GEFAICEP.DCLGE_FAIXA_CEP.GEFAICEP_FAIXA].TAB_FAIXAS.TAB_FX_CENTR);

            /*" -1908- GO TO R0210-00-FETCH-FAIXACEP. */
            new Task(() => R0210_00_FETCH_FAIXACEP_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-00-FETCH-FAIXACEP-DB-FETCH-1 */
        public void R0210_00_FETCH_FAIXACEP_DB_FETCH_1()
        {
            /*" -1889- EXEC SQL FETCH CFAIXACEP INTO :GEFAICEP-FAIXA, :GEFAICEP-CEP-INICIAL, :GEFAICEP-CEP-FINAL, :GEFAICEP-DESCRICAO-FAIXA, :GEFAICEP-CENTRALIZADOR END-EXEC. */

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
            /*" -1893- EXEC SQL CLOSE CFAIXACEP END-EXEC */

            CFAIXACEP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-SECTION */
        private void R0300_00_CARREGA_COBMENVG_SECTION()
        {
            /*" -1920- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WABEND.WNR_EXEC_SQL);

            /*" -1933- PERFORM R0300_00_CARREGA_COBMENVG_DB_DECLARE_1 */

            R0300_00_CARREGA_COBMENVG_DB_DECLARE_1();

            /*" -1936- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1937- DISPLAY 'R0300 - ERRO DECLARE CURSOR CMSG' */
                _.Display($"R0300 - ERRO DECLARE CURSOR CMSG");

                /*" -1938- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -1940- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1940- PERFORM R0300_00_CARREGA_COBMENVG_DB_OPEN_1 */

            R0300_00_CARREGA_COBMENVG_DB_OPEN_1();

            /*" -1943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1944- DISPLAY 'R0300 - ERRO OPEN CURSOR CMSG' */
                _.Display($"R0300 - ERRO OPEN CURSOR CMSG");

                /*" -1945- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -1947- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1948- PERFORM R0310-00-FETCH-COBMENVG UNTIL WFIM-COBMENVG EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_COBMENVG == "S"))
            {

                R0310_00_FETCH_COBMENVG_SECTION();
            }

        }

        [StopWatch]
        /*" R0300-00-CARREGA-COBMENVG-DB-OPEN-1 */
        public void R0300_00_CARREGA_COBMENVG_DB_OPEN_1()
        {
            /*" -1940- EXEC SQL OPEN CMSG END-EXEC. */

            CMSG.Open();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-DB-DECLARE-1 */
        public void R0400_00_CARREGA_FCPLANO_DB_DECLARE_1()
        {
            /*" -2015- EXEC SQL DECLARE CFCPLANO CURSOR FOR SELECT NUM_PLANO, QTD_DIG_COMBINACAO FROM FDRCAP.FC_PLANO WHERE NUM_PLANO > 0 ORDER BY NUM_PLANO WITH UR END-EXEC. */
            CFCPLANO = new VA3437B_CFCPLANO(false);
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
            /*" -1960- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", WABEND.WNR_EXEC_SQL);

            /*" -1968- PERFORM R0310_00_FETCH_COBMENVG_DB_FETCH_1 */

            R0310_00_FETCH_COBMENVG_DB_FETCH_1();

            /*" -1971- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1972- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", AREA_DE_WORK.WFIM_COBMENVG);

                /*" -1972- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_1 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_1();

                /*" -1975- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1977- ADD 1 TO WINDM. */
            AREA_DE_WORK.WINDM.Value = AREA_DE_WORK.WINDM + 1;

            /*" -1978- IF WINDM > 2000 */

            if (AREA_DE_WORK.WINDM > 2000)
            {

                /*" -1979- MOVE 2000 TO WINDM */
                _.Move(2000, AREA_DE_WORK.WINDM);

                /*" -1980- MOVE 'S' TO WFIM-COBMENVG */
                _.Move("S", AREA_DE_WORK.WFIM_COBMENVG);

                /*" -1980- PERFORM R0310_00_FETCH_COBMENVG_DB_CLOSE_2 */

                R0310_00_FETCH_COBMENVG_DB_CLOSE_2();

                /*" -1983- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1985- MOVE COBMENVG-NUM-APOLICE TO TABJ-APOLICE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_APOLICE);

            /*" -1987- MOVE COBMENVG-CODSUBES TO TABJ-CODSUBES (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODSUBES);

            /*" -1989- MOVE COBMENVG-COD-OPERACAO TO TABJ-CODOPER (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_CODOPER);

            /*" -1991- MOVE COBMENVG-JDE TO TABJ-JDE (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDE);

            /*" -1993- MOVE COBMENVG-JDL TO TABJ-JDL (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_JDL);

            /*" -1996- MOVE COBMENVG-IDFORM TO TABJ-IDFORM (WINDM). */
            _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM, TABELA_MSG.TAB_MSG[AREA_DE_WORK.WINDM].TABJ_CHAVE_R.TABJ_IDFORM);

            /*" -1996- GO TO R0310-00-FETCH-COBMENVG. */
            new Task(() => R0310_00_FETCH_COBMENVG_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-FETCH-1 */
        public void R0310_00_FETCH_COBMENVG_DB_FETCH_1()
        {
            /*" -1968- EXEC SQL FETCH CMSG INTO :COBMENVG-NUM-APOLICE, :COBMENVG-CODSUBES, :COBMENVG-COD-OPERACAO, :COBMENVG-JDE, :COBMENVG-JDL, :COBMENVG-IDFORM END-EXEC. */

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
            /*" -1972- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-COBMENVG-DB-CLOSE-2 */
        public void R0310_00_FETCH_COBMENVG_DB_CLOSE_2()
        {
            /*" -1980- EXEC SQL CLOSE CMSG END-EXEC */

            CMSG.Close();

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-SECTION */
        private void R0400_00_CARREGA_FCPLANO_SECTION()
        {
            /*" -2007- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -2015- PERFORM R0400_00_CARREGA_FCPLANO_DB_DECLARE_1 */

            R0400_00_CARREGA_FCPLANO_DB_DECLARE_1();

            /*" -2018- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2019- DISPLAY 'R0400 - ERRO DECLARE CURSOR CFCPLANO' */
                _.Display($"R0400 - ERRO DECLARE CURSOR CFCPLANO");

                /*" -2020- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2022- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2022- PERFORM R0400_00_CARREGA_FCPLANO_DB_OPEN_1 */

            R0400_00_CARREGA_FCPLANO_DB_OPEN_1();

            /*" -2025- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2026- DISPLAY 'R0400 - ERRO OPEN CURSOR CFCPLANO ' */
                _.Display($"R0400 - ERRO OPEN CURSOR CFCPLANO ");

                /*" -2027- DISPLAY 'SLQCODE = ' SQLCODE */
                _.Display($"SLQCODE = {DB.SQLCODE}");

                /*" -2029- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2030- PERFORM R0410-00-FETCH-FCPLANO UNTIL WFIM-FCPLANO EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_FCPLANO == "S"))
            {

                R0410_00_FETCH_FCPLANO_SECTION();
            }

        }

        [StopWatch]
        /*" R0400-00-CARREGA-FCPLANO-DB-OPEN-1 */
        public void R0400_00_CARREGA_FCPLANO_DB_OPEN_1()
        {
            /*" -2022- EXEC SQL OPEN CFCPLANO END-EXEC. */

            CFCPLANO.Open();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-DECLARE-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1()
        {
            /*" -2082- EXEC SQL DECLARE V1AGENCEF CURSOR FOR SELECT COD_FONTE, NOME_FONTE, ENDERECO, BAIRRO, CIDADE, CEP, SIGLA_UF FROM SEGUROS.FONTES WHERE COD_FONTE < 99 ORDER BY COD_FONTE WITH UR END-EXEC. */
            V1AGENCEF = new VA3437B_V1AGENCEF(false);
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
            /*" -2042- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", WABEND.WNR_EXEC_SQL);

            /*" -2046- PERFORM R0410_00_FETCH_FCPLANO_DB_FETCH_1 */

            R0410_00_FETCH_FCPLANO_DB_FETCH_1();

            /*" -2049- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2050- MOVE 'S' TO WFIM-FCPLANO */
                _.Move("S", AREA_DE_WORK.WFIM_FCPLANO);

                /*" -2050- PERFORM R0410_00_FETCH_FCPLANO_DB_CLOSE_1 */

                R0410_00_FETCH_FCPLANO_DB_CLOSE_1();

                /*" -2053- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2056- MOVE FCPLANO-QTD-DIG-COMBINACAO TO TAB-QTD-DIG (FCPLANO-NUM-PLANO). */
            _.Move(FCPLANO.DCLFC_PLANO.FCPLANO_QTD_DIG_COMBINACAO, TAB_QTD_DIG_COMBINACAO.TAB_COMB[FCPLANO.DCLFC_PLANO.FCPLANO_NUM_PLANO].TAB_QTD_DIG);

            /*" -2056- GO TO R0410-00-FETCH-FCPLANO. */
            new Task(() => R0410_00_FETCH_FCPLANO_SECTION()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0410-00-FETCH-FCPLANO-DB-FETCH-1 */
        public void R0410_00_FETCH_FCPLANO_DB_FETCH_1()
        {
            /*" -2046- EXEC SQL FETCH CFCPLANO INTO :FCPLANO-NUM-PLANO, :FCPLANO-QTD-DIG-COMBINACAO END-EXEC. */

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
            /*" -2050- EXEC SQL CLOSE CFCPLANO END-EXEC */

            CFCPLANO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-SECTION */
        private void R0500_00_DECLARE_AGENCCEF_SECTION()
        {
            /*" -2068- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -2082- PERFORM R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1 */

            R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1();

            /*" -2085- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2086- DISPLAY 'R0500 - ERRO DECLARE CURSOR V1AGENCEF' */
                _.Display($"R0500 - ERRO DECLARE CURSOR V1AGENCEF");

                /*" -2087- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2089- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2089- PERFORM R0500_00_DECLARE_AGENCCEF_DB_OPEN_1 */

            R0500_00_DECLARE_AGENCCEF_DB_OPEN_1();

            /*" -2092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2093- DISPLAY 'R0500 - ERRO OPEN CURSOR V1AGENCEF' */
                _.Display($"R0500 - ERRO OPEN CURSOR V1AGENCEF");

                /*" -2094- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -2094- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-AGENCCEF-DB-OPEN-1 */
        public void R0500_00_DECLARE_AGENCCEF_DB_OPEN_1()
        {
            /*" -2089- EXEC SQL OPEN V1AGENCEF END-EXEC. */

            V1AGENCEF.Open();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-DECLARE-1 */
        public void R0900_00_DECLARE_RELATORI_DB_DECLARE_1()
        {
            /*" -2208- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT A.COD_OPERACAO, A.COD_USUARIO, A.COD_RELATORIO, A.NUM_PARCELA, A.TIMESTAMP, B.DATA_QUITACAO, B.NUM_APOLICE, B.COD_SUBGRUPO, B.NUM_CERTIFICADO, B.COD_PRODUTO, B.COD_CLIENTE, B.OCOREND, B.IDE_SEXO, B.SIT_REGISTRO, B.AGE_COBRANCA, B.COD_FONTE, B.IDADE, B.OCORR_HISTORICO, B.FAIXA_RENDA_IND, B.FAIXA_RENDA_FAM, C.CODRELAT, C.PERI_PAGAMENTO , D.COD_EMPRESA FROM SEGUROS.RELATORIOS A, SEGUROS.PROPOSTAS_VA B, SEGUROS.PRODUTOS_VG C , SEGUROS.PRODUTO D WHERE A.SIT_REGISTRO = '0' AND A.COD_OPERACAO IN (2, 6, 10) AND A.NUM_PARCELA = 2 AND A.DATA_SOLICITACAO > :SISTEMAS-DATA-MOV-ABERTO-15D AND B.SIT_REGISTRO <> '2' AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.RAMO <> 77 AND D.COD_PRODUTO = B.COD_PRODUTO ORDER BY B.NUM_CERTIFICADO, A.DATA_SOLICITACAO WITH UR END-EXEC. */
            CRELAT = new VA3437B_CRELAT(true);
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
							C.CODRELAT
							, 
							C.PERI_PAGAMENTO 
							, D.COD_EMPRESA 
							FROM SEGUROS.RELATORIOS A
							, 
							SEGUROS.PROPOSTAS_VA B
							, 
							SEGUROS.PRODUTOS_VG C 
							, SEGUROS.PRODUTO D 
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
							AND D.COD_PRODUTO = B.COD_PRODUTO 
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
            /*" -2106- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", WABEND.WNR_EXEC_SQL);

            /*" -2115- PERFORM R0510_00_FETCH_AGENCCEF_DB_FETCH_1 */

            R0510_00_FETCH_AGENCCEF_DB_FETCH_1();

            /*" -2118- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2119- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2120- MOVE 'S' TO WFIM-AGENCCEF */
                    _.Move("S", AREA_DE_WORK.WFIM_AGENCCEF);

                    /*" -2120- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_1 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_1();

                    /*" -2122- ELSE */
                }
                else
                {


                    /*" -2122- PERFORM R0510_00_FETCH_AGENCCEF_DB_CLOSE_2 */

                    R0510_00_FETCH_AGENCCEF_DB_CLOSE_2();

                    /*" -2124- DISPLAY 'R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..' */
                    _.Display($"R0510 - (PROBLEMAS NO FETCH AGENCCEF) ..");

                    /*" -2125- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -2125- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-FETCH-1 */
        public void R0510_00_FETCH_AGENCCEF_DB_FETCH_1()
        {
            /*" -2115- EXEC SQL FETCH V1AGENCEF INTO :MALHACEF-COD-FONTE, :FONTES-NOME-FONTE, :FONTES-ENDERECO, :FONTES-BAIRRO, :FONTES-CIDADE, :FONTES-CEP, :FONTES-SIGLA-UF END-EXEC. */

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
            /*" -2120- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-AGENCCEF-DB-CLOSE-2 */
        public void R0510_00_FETCH_AGENCCEF_DB_CLOSE_2()
        {
            /*" -2122- EXEC SQL CLOSE V1AGENCEF END-EXEC */

            V1AGENCEF.Close();

        }

        [StopWatch]
        /*" R0520-00-CARREGA-FILIAL-SECTION */
        private void R0520_00_CARREGA_FILIAL_SECTION()
        {
            /*" -2137- MOVE '0520' TO WNR-EXEC-SQL. */
            _.Move("0520", WABEND.WNR_EXEC_SQL);

            /*" -2139- MOVE MALHACEF-COD-FONTE TO IDX-IND1. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, AREA_DE_WORK.IDX_IND1);

            /*" -2141- MOVE MALHACEF-COD-FONTE TO TAB-FONTE (IDX-IND1) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_FONTE);

            /*" -2143- MOVE FONTES-NOME-FONTE TO TAB-NOMEFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_NOMEFTE);

            /*" -2145- MOVE FONTES-ENDERECO TO TAB-ENDERFTE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_ENDERECO, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_ENDERFTE);

            /*" -2147- MOVE FONTES-BAIRRO TO TAB-BAIRRO (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_BAIRRO, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_BAIRRO);

            /*" -2149- MOVE FONTES-CIDADE TO TAB-CIDADE (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CIDADE, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_CIDADE);

            /*" -2151- MOVE FONTES-CEP TO TAB-CEP (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_CEP, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_CEP);

            /*" -2154- MOVE FONTES-SIGLA-UF TO TAB-UF (IDX-IND1) */
            _.Move(FONTES.DCLFONTES.FONTES_SIGLA_UF, TAB_FILIAL.FILLER_104[AREA_DE_WORK.IDX_IND1].TAB_UF);

            /*" -2154- PERFORM R0510-00-FETCH-AGENCCEF. */

            R0510_00_FETCH_AGENCCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-SECTION */
        private void R0900_00_DECLARE_RELATORI_SECTION()
        {
            /*" -2166- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -2208- PERFORM R0900_00_DECLARE_RELATORI_DB_DECLARE_1 */

            R0900_00_DECLARE_RELATORI_DB_DECLARE_1();

            /*" -2211- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2212- DISPLAY 'R0900 - ERRO DECLARE CURSOR CRELAT' */
                _.Display($"R0900 - ERRO DECLARE CURSOR CRELAT");

                /*" -2213- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2220- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2220- PERFORM R0900_00_DECLARE_RELATORI_DB_OPEN_1 */

            R0900_00_DECLARE_RELATORI_DB_OPEN_1();

            /*" -2223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2224- DISPLAY 'R0900 - ERRO OPEN CURSOR CRELAT ' */
                _.Display($"R0900 - ERRO OPEN CURSOR CRELAT ");

                /*" -2225- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2226- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2226- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-RELATORI-DB-OPEN-1 */
        public void R0900_00_DECLARE_RELATORI_DB_OPEN_1()
        {
            /*" -2220- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-DB-DECLARE-1 */
        public void R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1()
        {
            /*" -2742- EXEC SQL DECLARE CTITFEDCA CURSOR FOR SELECT NRTITFDCAP, NRSORTEIO FROM SEGUROS.TITULOS_FED_CAP_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA > :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */
            CTITFEDCA = new VA3437B_CTITFEDCA(true);
            string GetQuery_CTITFEDCA()
            {
                var query = @$"SELECT NRTITFDCAP
							, 
							NRSORTEIO 
							FROM SEGUROS.TITULOS_FED_CAP_VA 
							WHERE NUM_CERTIFICADO = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}' 
							AND DATA_TERVIGENCIA > '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            CTITFEDCA.GetQueryEvent += GetQuery_CTITFEDCA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-SECTION */
        private void R0910_00_FETCH_RELATORI_SECTION()
        {
            /*" -2243- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -2268- PERFORM R0910_00_FETCH_RELATORI_DB_FETCH_1 */

            R0910_00_FETCH_RELATORI_DB_FETCH_1();

            /*" -2272- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2273- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -2275- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2275- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_1 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_1();

                /*" -2278- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2281- ADD 1 TO AC-L-RELATORI AC-CONTA AC-LIDOS. */
            AREA_DE_WORK.AC_L_RELATORI.Value = AREA_DE_WORK.AC_L_RELATORI + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

            /*" -2282- IF AC-LIDOS < 101 */

            if (AREA_DE_WORK.AC_LIDOS < 101)
            {

                /*" -2299- DISPLAY 'FETCH CRELAT (' AC-L-RELATORI '):' ' COD-OPERACAO=' RELATORI-COD-OPERACAO ' COD-USUARIO=' RELATORI-COD-USUARIO ' COD-RELATORIO=' RELATORI-COD-RELATORIO ' NUM-PARCELA=' RELATORI-NUM-PARCELA ' TIMESTAMP=' RELATORI-TIMESTAMP ' DATA-QUITACAO=' PROPOVA-DATA-QUITACAO ' NUM-APOLICE=' PROPOVA-NUM-APOLICE ' COD-SUBGRUPO=' PROPOVA-COD-SUBGRUPO ' NUM-CERTIFICADO=' PROPOVA-NUM-CERTIFICADO ' COD-PRODUTO=' PROPOVA-COD-PRODUTO ' COD-CLIENTE=' PROPOVA-COD-CLIENTE ' OCOREND=' PROPOVA-OCOREND ' COD-FONTE=' PROPOVA-COD-FONTE ' OCORR-HISTORICO=' PROPOVA-OCORR-HISTORICO ' CODRELAT=' PRODUVG-CODRELAT ' COD-EMPRESA=' PRODUTO-COD-EMPRESA */

                $"FETCH CRELAT ({AREA_DE_WORK.AC_L_RELATORI}): COD-OPERACAO={RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO} COD-USUARIO={RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO} COD-RELATORIO={RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO} NUM-PARCELA={RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA} TIMESTAMP={RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP} DATA-QUITACAO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO} NUM-APOLICE={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE} COD-SUBGRUPO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO} NUM-CERTIFICADO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} COD-PRODUTO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO} COD-CLIENTE={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE} OCOREND={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND} COD-FONTE={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE} OCORR-HISTORICO={PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO} CODRELAT={PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT} COD-EMPRESA={PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA}"
                .Display();

                /*" -2311- END-IF */
            }


            /*" -2313- MOVE PROPOVA-NUM-CERTIFICADO TO WS-CERTIFICADO-ATU. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_CERTIFICADO_ATU);

            /*" -2314- IF VIND-RENDA-IND LESS +0 */

            if (VIND_RENDA_IND < +0)
            {

                /*" -2317- MOVE ZEROS TO PROPOVA-FAIXA-RENDA-IND PROPOVA-FAIXA-RENDA-FAM */
                _.Move(0, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);

                /*" -2319- END-IF. */
            }


            /*" -2320- IF AC-LIDOS EQUAL 200000 */

            if (AREA_DE_WORK.AC_LIDOS == 200000)
            {

                /*" -2321- DISPLAY 'GRAVADO SORT..:' AC-GRAV-SORT */
                _.Display($"GRAVADO SORT..:{AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -2322- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -2324- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2324- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_2 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_2();

                /*" -2326- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -2328- END-IF. */
            }


            /*" -2329- IF AC-GRAV-SORT EQUAL 40000 */

            if (AREA_DE_WORK.AC_GRAV_SORT == 40000)
            {

                /*" -2330- DISPLAY 'GRAVADO SORT..:' AC-GRAV-SORT */
                _.Display($"GRAVADO SORT..:{AREA_DE_WORK.AC_GRAV_SORT}");

                /*" -2331- MOVE 'S' TO WFIM-RELATORI */
                _.Move("S", AREA_DE_WORK.WFIM_RELATORI);

                /*" -2333- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, AREA_DE_WORK.AC_CONTA, AREA_DE_WORK.AC_LIDOS);

                /*" -2333- PERFORM R0910_00_FETCH_RELATORI_DB_CLOSE_3 */

                R0910_00_FETCH_RELATORI_DB_CLOSE_3();

                /*" -2335- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -2337- END-IF. */
            }


            /*" -2337- MOVE PROPOVA-COD-PRODUTO TO W88-PRODUTO-VIDA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, W88_PRODUTO_VIDA);

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-FETCH-1 */
        public void R0910_00_FETCH_RELATORI_DB_FETCH_1()
        {
            /*" -2268- EXEC SQL FETCH CRELAT INTO :RELATORI-COD-OPERACAO, :RELATORI-COD-USUARIO, :RELATORI-COD-RELATORIO, :RELATORI-NUM-PARCELA, :RELATORI-TIMESTAMP, :PROPOVA-DATA-QUITACAO, :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-PRODUTO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCOREND, :PROPOVA-IDE-SEXO, :PROPOVA-SIT-REGISTRO, :PROPOVA-AGE-COBRANCA, :PROPOVA-COD-FONTE, :PROPOVA-IDADE, :PROPOVA-OCORR-HISTORICO, :PROPOVA-FAIXA-RENDA-IND:VIND-RENDA-IND, :PROPOVA-FAIXA-RENDA-FAM:VIND-RENDA-FAM, :PRODUVG-CODRELAT, :PRODUVG-PERI-PAGAMENTO , :PRODUTO-COD-EMPRESA END-EXEC. */

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
                _.Move(CRELAT.PRODUVG_CODRELAT, PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT);
                _.Move(CRELAT.PRODUVG_PERI_PAGAMENTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);
                _.Move(CRELAT.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-1 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_1()
        {
            /*" -2275- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-RELATORI-DB-CLOSE-2 */
        public void R0910_00_FETCH_RELATORI_DB_CLOSE_2()
        {
            /*" -2324- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -2350- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -2351- INITIALIZE REG-SVA3437B. */
            _.Initialize(
                REG_SVA3437B
            );

            /*" -2352- IF WS-CERTIFICADO-A EQUAL PROPOVA-NUM-CERTIFICADO */

            if (WS_CERTIFICADO_A == PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO)
            {

                /*" -2353- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2355- END-IF. */
            }


            /*" -2357- MOVE PROPOVA-NUM-CERTIFICADO TO WS-CERTIFICADO-A */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, WS_CERTIFICADO_A);

            /*" -2358- MOVE PROPOVA-NUM-APOLICE TO WS-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);

            /*" -2359- MOVE PROPOVA-COD-SUBGRUPO TO WS-CODSUBES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);

            /*" -2362- MOVE RELATORI-COD-OPERACAO TO WHOST-CODOPER WS-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, WHOST_CODOPER);
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);


            /*" -2363- IF (RELATORI-COD-USUARIO EQUAL 'VA0118B' ) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO == "VA0118B"))
            {

                /*" -2364- MOVE 'A5' TO WS-IDFORM */
                _.Move("A5", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -2365- MOVE 6 TO COBMENVG-COD-OPERACAO */
                _.Move(6, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                /*" -2366- ELSE */
            }
            else
            {


                /*" -2367- IF (RELATORI-COD-USUARIO EQUAL 'VA0130B' ) */

                if ((RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO == "VA0130B"))
                {

                    /*" -2368- MOVE 'A4' TO WS-IDFORM */
                    _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                    /*" -2369- MOVE 10 TO COBMENVG-COD-OPERACAO */
                    _.Move(10, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                    /*" -2370- ELSE */
                }
                else
                {


                    /*" -2371- MOVE 'A4' TO WS-IDFORM */
                    _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                    /*" -2372- MOVE 2 TO COBMENVG-COD-OPERACAO */
                    _.Move(2, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                    /*" -2373- END-IF */
                }


                /*" -2375- END-IF. */
            }


            /*" -2376- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -2378- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -2385- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -2386- IF (WS-JDE EQUAL 'VA54' ) */

            if ((AREA_DE_WORK.WS_JDE_GER.WS_JDE == "VA54"))
            {

                /*" -2387- ADD 1 TO AC-DESPR-VA54 */
                AREA_DE_WORK.AC_DESPR_VA54.Value = AREA_DE_WORK.AC_DESPR_VA54 + 1;

                /*" -2388- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2390- END-IF */
            }


            /*" -2391- IF (WS-JDE EQUAL 'VIDA10' ) */

            if ((AREA_DE_WORK.WS_JDE_GER.WS_JDE == "VIDA10"))
            {

                /*" -2392- ADD 1 TO AC-DESPR-VIDA10 */
                AREA_DE_WORK.AC_DESPR_VIDA10.Value = AREA_DE_WORK.AC_DESPR_VIDA10 + 1;

                /*" -2393- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2395- END-IF */
            }


            /*" -2397- PERFORM R1400-00-SELECT-HISCOBPR */

            R1400_00_SELECT_HISCOBPR_SECTION();

            /*" -2398- IF WTEM-HISCOBPR EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_HISCOBPR == "N")
            {

                /*" -2399- ADD 1 TO AC-DESPR-COBERPRO */
                AREA_DE_WORK.AC_DESPR_COBERPRO.Value = AREA_DE_WORK.AC_DESPR_COBERPRO + 1;

                /*" -2400- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2402- END-IF */
            }


            /*" -2404- MOVE WS-JDE TO SVA-FORMULARIO */
            _.Move(AREA_DE_WORK.WS_JDE_GER.WS_JDE, REG_SVA3437B.SVA_FORMULARIO);

            /*" -2405- PERFORM R1120-00-DECLARE-TITFEDCA */

            R1120_00_DECLARE_TITFEDCA_SECTION();

            /*" -2407- PERFORM R1130-00-FETCH-TITFEDCA */

            R1130_00_FETCH_TITFEDCA_SECTION();

            /*" -2409- IF WFIM-TITFEDCA EQUAL 'S' AND HISCOBPR-VAL-CUSTO-CAPITALI GREATER ZEROS */

            if (AREA_DE_WORK.WFIM_TITFEDCA == "S" && HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VAL_CUSTO_CAPITALI > 00)
            {

                /*" -2410- ADD 1 TO AC-DESPR-TITULO */
                AREA_DE_WORK.AC_DESPR_TITULO.Value = AREA_DE_WORK.AC_DESPR_TITULO + 1;

                /*" -2411- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2413- END-IF */
            }


            /*" -2415- PERFORM R1140-00-PROCESSA-TITFEDCA UNTIL WFIM-TITFEDCA = 'S' */

            while (!(AREA_DE_WORK.WFIM_TITFEDCA == "S"))
            {

                R1140_00_PROCESSA_TITFEDCA_SECTION();
            }

            /*" -2416- IF WS-CERTIFICADO-ATU NOT = WS-CERTIFICADO-ANT */

            if (WS_CERTIFICADO_ATU != WS_CERTIFICADO_ANT)
            {

                /*" -2417- MOVE WS-CERTIFICADO-ATU TO WS-CERTIFICADO-ANT */
                _.Move(WS_CERTIFICADO_ATU, WS_CERTIFICADO_ANT);

                /*" -2418- ELSE */
            }
            else
            {


                /*" -2419- ADD 1 TO AC-DESPR-CERTIF */
                AREA_DE_WORK.AC_DESPR_CERTIF.Value = AREA_DE_WORK.AC_DESPR_CERTIF + 1;

                /*" -2420- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -2422- END-IF */
            }


            /*" -2424- MOVE ZEROS TO WS-DUPLICADO. */
            _.Move(0, WS_DUPLICADO);

            /*" -2425- IF RELATORI-COD-RELATORIO EQUAL PRODUVG-CODRELAT */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO == PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT)
            {

                /*" -2438- PERFORM R1000_00_PROCESSA_INPUT_DB_SELECT_1 */

                R1000_00_PROCESSA_INPUT_DB_SELECT_1();

                /*" -2441- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2442- MOVE ZEROS TO WS-DUPLICADO */
                    _.Move(0, WS_DUPLICADO);

                    /*" -2443- END-IF */
                }


                /*" -2445- END-IF */
            }


            /*" -2446- IF WS-DUPLICADO GREATER ZEROS */

            if (WS_DUPLICADO > 00)
            {

                /*" -2447- ADD 1 TO AC-DESPR-DUPLIC */
                AREA_DE_WORK.AC_DESPR_DUPLIC.Value = AREA_DE_WORK.AC_DESPR_DUPLIC + 1;

                /*" -2449- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2451- PERFORM R1010-00-SELECT-SEGURVGA. */

            R1010_00_SELECT_SEGURVGA_SECTION();

            /*" -2452- IF WTEM-SEGURVGA EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_SEGURVGA == "N")
            {

                /*" -2453- ADD 1 TO AC-DESPR-SEGURAVG */
                AREA_DE_WORK.AC_DESPR_SEGURAVG.Value = AREA_DE_WORK.AC_DESPR_SEGURAVG + 1;

                /*" -2455- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2457- PERFORM R1100-00-SELECT-OPCPAGVI. */

            R1100_00_SELECT_OPCPAGVI_SECTION();

            /*" -2458- IF WTEM-OPCPAGVI EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_OPCPAGVI == "N")
            {

                /*" -2459- ADD 1 TO AC-DESPR-OPCAOPAG */
                AREA_DE_WORK.AC_DESPR_OPCAOPAG.Value = AREA_DE_WORK.AC_DESPR_OPCAOPAG + 1;

                /*" -2461- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2463- PERFORM R1200-00-SELECT-CLIENTES. */

            R1200_00_SELECT_CLIENTES_SECTION();

            /*" -2464- IF WTEM-CLIENTES EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CLIENTES == "N")
            {

                /*" -2465- ADD 1 TO AC-DESPR-CLIENTE */
                AREA_DE_WORK.AC_DESPR_CLIENTE.Value = AREA_DE_WORK.AC_DESPR_CLIENTE + 1;

                /*" -2467- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -2469- PERFORM R1210-00-SELECT-EMAIL. */

            R1210_00_SELECT_EMAIL_SECTION();

            /*" -2471- MOVE PROPOVA-OCOREND TO WHOST-OCOREND. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND, WHOST_OCOREND);

            /*" -2473- PERFORM R1300-00-SELECT-ENDERECO. */

            R1300_00_SELECT_ENDERECO_SECTION();

            /*" -2475- IF WTEM-ENDERECO EQUAL 'S' NEXT SENTENCE */

            if (AREA_DE_WORK.WTEM_ENDERECO == "S")
            {

                /*" -2476- ELSE */
            }
            else
            {


                /*" -2477- MOVE SEGURVGA-OCORR-ENDERECO TO WHOST-OCOREND */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO, WHOST_OCOREND);

                /*" -2479- PERFORM R1300-00-SELECT-ENDERECO */

                R1300_00_SELECT_ENDERECO_SECTION();

                /*" -2481- IF WTEM-ENDERECO EQUAL 'S' NEXT SENTENCE */

                if (AREA_DE_WORK.WTEM_ENDERECO == "S")
                {

                    /*" -2482- ELSE */
                }
                else
                {


                    /*" -2483- ADD 1 TO AC-DESPR-ENDERECO */
                    AREA_DE_WORK.AC_DESPR_ENDERECO.Value = AREA_DE_WORK.AC_DESPR_ENDERECO + 1;

                    /*" -2484- GO TO R1000-10-NEXT */

                    R1000_10_NEXT(); //GOTO
                    return;

                    /*" -2485- END-IF */
                }


                /*" -2487- END-IF */
            }


            /*" -2489- PERFORM R1500-00-SELECT-AGENCCEF. */

            R1500_00_SELECT_AGENCCEF_SECTION();

            /*" -2491- PERFORM R1600-00-SELECT-APOLICE. */

            R1600_00_SELECT_APOLICE_SECTION();

            /*" -2495- PERFORM R1640-00-SELECT-ENDOSSOS. */

            R1640_00_SELECT_ENDOSSOS_SECTION();

            /*" -2497- MOVE PROPOVA-DATA-QUITACAO TO SVA-DTQUIT. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_SVA3437B.SVA_DTQUIT);

            /*" -2498- MOVE ZEROS TO SVA-PLANO. */
            _.Move(0, REG_SVA3437B.SVA_PLANO);

            /*" -2500- MOVE APOLICES-COD-CLIENTE TO SVA-CODCLIEN. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, REG_SVA3437B.SVA_CODCLIEN);

            /*" -2502- MOVE APOLICES-RAMO-EMISSOR TO SVA-RAMO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, REG_SVA3437B.SVA_RAMO);

            /*" -2503- MOVE MALHACEF-COD-FONTE TO SVA-FONTE. */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, REG_SVA3437B.SVA_FONTE);

            /*" -2505- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NRCERTIF. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_SVA3437B.SVA_NRCERTIF);

            /*" -2506- MOVE PROPOVA-IDE-SEXO TO SVA-IDSEXO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDE_SEXO, REG_SVA3437B.SVA_IDSEXO);

            /*" -2508- MOVE SEGURVGA-DATA-INIVIGENCIA TO SVA-DTINIVIG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA, REG_SVA3437B.SVA_DTINIVIG);

            /*" -2509- MOVE PROPOVA-NUM-APOLICE TO SVA-NRAPOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, REG_SVA3437B.SVA_NRAPOLICE);

            /*" -2511- MOVE PROPOVA-COD-SUBGRUPO TO SVA-CODSUBES. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, REG_SVA3437B.SVA_CODSUBES);

            /*" -2513- MOVE PROPOVA-FAIXA-RENDA-IND TO SVA-RENDA-IND */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, REG_SVA3437B.SVA_RENDA_IND);

            /*" -2515- MOVE PROPOVA-FAIXA-RENDA-FAM TO SVA-RENDA-FAM */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, REG_SVA3437B.SVA_RENDA_FAM);

            /*" -2517- MOVE PRODUVG-CODRELAT TO SVA-CODRELAT. */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_CODRELAT, REG_SVA3437B.SVA_CODRELAT);

            /*" -2520- MOVE RELATORI-COD-RELATORIO TO SVA-CODRELATVG. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO, REG_SVA3437B.SVA_CODRELATVG);

            /*" -2521- MOVE SEGURVGA-NUM-ITEM TO SVA-NUM-ITEM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, REG_SVA3437B.SVA_NUM_ITEM);

            /*" -2523- MOVE SEGURVGA-OCORR-HISTORICO TO SVA-OCORHIST. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, REG_SVA3437B.SVA_OCORHIST);

            /*" -2525- MOVE HISCOBPR-DATA-INIVIGENCIA TO SVA-DTMOVTO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, REG_SVA3437B.SVA_DTMOVTO);

            /*" -2527- MOVE RELATORI-COD-OPERACAO TO SVA-CODOPER */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, REG_SVA3437B.SVA_CODOPER);

            /*" -2529- MOVE RELATORI-COD-USUARIO TO SVA-CODUSU. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO, REG_SVA3437B.SVA_CODUSU);

            /*" -2531- MOVE PROPOVA-SIT-REGISTRO TO SVA-SITPROP. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO, REG_SVA3437B.SVA_SITPROP);

            /*" -2533- MOVE SEGURVGA-SIT-REGISTRO TO SVA-SITSEG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO, REG_SVA3437B.SVA_SITSEG);

            /*" -2534- MOVE HISCOBPR-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, REG_SVA3437B.SVA_VLPREMIO);

            /*" -2535- MOVE HISCOBPR-IMPSEGCDG TO SVA-IMPSEGCDG. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPSEGCDG, REG_SVA3437B.SVA_IMPSEGCDG);

            /*" -2536- MOVE OPCPAGVI-DIA-DEBITO TO SVA-DIA-DEBITO */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, REG_SVA3437B.SVA_DIA_DEBITO);

            /*" -2537- MOVE CLIENTES-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SVA3437B.SVA_NOME_RAZAO);

            /*" -2538- MOVE CLIENTES-CGCCPF TO SVA-CPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SVA3437B.SVA_CPF);

            /*" -2540- MOVE CLIENTES-DATA-NASCIMENTO TO SVA-DTNASC */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, REG_SVA3437B.SVA_DTNASC);

            /*" -2541- MOVE CLIENEMA-EMAIL TO SVA-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, REG_SVA3437B.SVA_EMAIL);

            /*" -2543- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAO-PAG */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA3437B.SVA_OPCAO_PAG);

            /*" -2546- MOVE PRODUVG-PERI-PAGAMENTO TO SVA-PERI-PAGAMENTO */
            _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO, REG_SVA3437B.SVA_PERI_PAGAMENTO);

            /*" -2548- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2550- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO SVA-AGECTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, REG_SVA3437B.SVA_AGECTADEB);

                /*" -2552- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO SVA-OPRCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, REG_SVA3437B.SVA_OPRCTADEB);

                /*" -2554- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO SVA-NUMCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, REG_SVA3437B.SVA_NUMCTADEB);

                /*" -2556- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO SVA-DIGCTADEB */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, REG_SVA3437B.SVA_DIGCTADEB);

                /*" -2557- ELSE */
            }
            else
            {


                /*" -2561- MOVE ZEROS TO SVA-AGECTADEB SVA-OPRCTADEB SVA-NUMCTADEB SVA-DIGCTADEB */
                _.Move(0, REG_SVA3437B.SVA_AGECTADEB, REG_SVA3437B.SVA_OPRCTADEB, REG_SVA3437B.SVA_NUMCTADEB, REG_SVA3437B.SVA_DIGCTADEB);

                /*" -2563- END-IF */
            }


            /*" -2566- MOVE ENDOSSOS-DATA-TERVIGENCIA TO SVA-DTTERVIG. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, REG_SVA3437B.SVA_DTTERVIG);

            /*" -2569- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA-1 NEXT SENTENCE */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS_DATA_TERVIGENCIA_1)
            {

                /*" -2570- ELSE */
            }
            else
            {


                /*" -2572- IF WHOST-DATA-TERVIG-PREMIO (6:2) < ENDOSSOS-DATA-TERVIGENCIA-1 (6:2) */

                if (WHOST_DATA_TERVIG_PREMIO.Substring(6, 2) < ENDOSSOS_DATA_TERVIGENCIA_1.Substring(6, 2))
                {

                    /*" -2574- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2575- ELSE */
                }
                else
                {


                    /*" -2577- MOVE SISTEMAS-DATA-MOV-ABERTO-1 (1:4) TO WHOST-DATA-TERVIG-PREMIO (1:4) */
                    _.MoveAtPosition(SISTEMAS_DATA_MOV_ABERTO_1.Substring(1, 4), WHOST_DATA_TERVIG_PREMIO, 1, 4);

                    /*" -2578- END-IF */
                }


                /*" -2580- END-IF. */
            }


            /*" -2581- IF WHOST-DATA-TERVIG-PREMIO > ENDOSSOS-DATA-TERVIGENCIA */

            if (WHOST_DATA_TERVIG_PREMIO > ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA)
            {

                /*" -2582- MOVE '*' TO SVA-IND-VIGENCIA */
                _.Move("*", REG_SVA3437B.SVA_IND_VIGENCIA);

                /*" -2583- ELSE */
            }
            else
            {


                /*" -2584- MOVE ' ' TO SVA-IND-VIGENCIA */
                _.Move(" ", REG_SVA3437B.SVA_IND_VIGENCIA);

                /*" -2586- END-IF */
            }


            /*" -2588- MOVE OPCPAGVI-OPCAO-PAGAMENTO TO SVA-OPCAOPAG. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO, REG_SVA3437B.SVA_OPCAOPAG);

            /*" -2589- MOVE ENDERECO-ENDERECO TO SVA-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, REG_SVA3437B.SVA_ENDERECO);

            /*" -2590- MOVE ENDERECO-BAIRRO TO SVA-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, REG_SVA3437B.SVA_BAIRRO);

            /*" -2591- MOVE ENDERECO-CIDADE TO SVA-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, REG_SVA3437B.SVA_CIDADE);

            /*" -2592- MOVE ENDERECO-SIGLA-UF TO SVA-UF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, REG_SVA3437B.SVA_UF);

            /*" -2594- MOVE ENDERECO-CEP TO WS-NUM-CEP-AUX. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -2595- MOVE PROPOVA-COD-PRODUTO TO SVA-PRODUTO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, REG_SVA3437B.SVA_PRODUTO);

            /*" -2597- MOVE PRODUTO-COD-EMPRESA TO SVA-COD-EMPRESA */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA, REG_SVA3437B.SVA_COD_EMPRESA);

            /*" -2598- IF WS-CEP-COMPL-AUX1 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1 == 00)
            {

                /*" -2599- MOVE WS-CEP-COMPL-AUX1 TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_COMPL_AUX1, REG_SVA3437B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2600- MOVE WS-CEP-AUX1 TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R1.WS_CEP_AUX1, REG_SVA3437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2601- ELSE */
            }
            else
            {


                /*" -2602- MOVE WS-CEP-AUX TO SVA-CEP */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_AUX, REG_SVA3437B.SVA_NUM_CEP.SVA_CEP);

                /*" -2603- MOVE WS-CEP-COMPL-AUX TO SVA-CEP-COMPL */
                _.Move(AREA_DE_WORK.WS_NUM_CEP_AUX_R.WS_CEP_COMPL_AUX, REG_SVA3437B.SVA_NUM_CEP.SVA_CEP_COMPL);

                /*" -2605- END-IF */
            }


            /*" -2606- IF ENDERECO-CEP EQUAL ZEROS */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP == 00)
            {

                /*" -2607- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA3437B.SVA_CEP_G);

                /*" -2608- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA3437B.SVA_NOME_CORREIO);

                /*" -2609- ELSE */
            }
            else
            {


                /*" -2610- PERFORM R1900-00-LOCALIZA-CEP */

                R1900_00_LOCALIZA_CEP_SECTION();

                /*" -2612- END-IF */
            }


            /*" -2613- MOVE ENDERECO-DDD TO SVA-DDD */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, REG_SVA3437B.SVA_DDD);

            /*" -2614- MOVE ENDERECO-TELEFONE TO SVA-TELEFONE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, REG_SVA3437B.SVA_TELEFONE);

            /*" -2616- MOVE ENDERECO-TELEX TO SVA-TELEX */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEX, REG_SVA3437B.SVA_TELEX);

            /*" -2618- PERFORM R9200-00-PESQUISA-FORMULARIO. */

            R9200_00_PESQUISA_FORMULARIO_SECTION();

            /*" -2620- RELEASE REG-SVA3437B. */
            SVA3437B.Release(REG_SVA3437B);

            /*" -2620- ADD 1 TO AC-GRAV-SORT. */
            AREA_DE_WORK.AC_GRAV_SORT.Value = AREA_DE_WORK.AC_GRAV_SORT + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-DB-SELECT-1 */
        public void R1000_00_PROCESSA_INPUT_DB_SELECT_1()
        {
            /*" -2438- EXEC SQL SELECT VALUE(COUNT(*), 0) INTO :WS-DUPLICADO FROM SEGUROS.RELATORIOS WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_OPERACAO = :RELATORI-COD-OPERACAO AND NUM_PARCELA = :RELATORI-NUM-PARCELA AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO-15D AND SIT_REGISTRO = '0' AND TIMESTAMP < :RELATORI-TIMESTAMP WITH UR END-EXEC */

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
            /*" -2333- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -2624- PERFORM R0910-00-FETCH-RELATORI. */

            R0910_00_FETCH_RELATORI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-SECTION */
        private void R1010_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -2636- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", WABEND.WNR_EXEC_SQL);

            /*" -2638- MOVE 'S' TO WTEM-SEGURVGA */
            _.Move("S", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -2660- PERFORM R1010_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1010_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -2663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2664- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2665- MOVE 'N' TO WTEM-SEGURVGA */
                    _.Move("N", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -2666- ELSE */
                }
                else
                {


                    /*" -2668- DISPLAY '*** VA3437B PROBLEMAS ACESSO SEGURADOS_VGAP ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA3437B PROBLEMAS ACESSO SEGURADOS_VGAP {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2669- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2670- END-IF */
                }


                /*" -2670- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1010_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -2660- EXEC SQL SELECT SIT_REGISTRO, COD_CLIENTE, DATA_INIVIGENCIA, DATA_INIVIGENCIA + :PRODUVG-PERI-PAGAMENTO MONTHS, COD_SUBGRUPO, OCORR_ENDERECO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-DATA-INIVIGENCIA, :WHOST-DATA-TERVIG-PREMIO, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC */

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
        /*" R1100-00-SELECT-OPCPAGVI-SECTION */
        private void R1100_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -2682- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -2684- MOVE 'S' TO WTEM-OPCPAGVI. */
            _.Move("S", AREA_DE_WORK.WTEM_OPCPAGVI);

            /*" -2702- PERFORM R1100_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1100_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -2705- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2706- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2707- MOVE 'N' TO WTEM-OPCPAGVI */
                    _.Move("N", AREA_DE_WORK.WTEM_OPCPAGVI);

                    /*" -2708- ELSE */
                }
                else
                {


                    /*" -2709- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -2710- MOVE 'N' TO WTEM-OPCPAGVI */
                        _.Move("N", AREA_DE_WORK.WTEM_OPCPAGVI);

                        /*" -2711- ELSE */
                    }
                    else
                    {


                        /*" -2713- DISPLAY 'VA3437B PROBLEMAS NO ACESSO A V0OPCAOPAG ' PROPOVA-NUM-CERTIFICADO */
                        _.Display($"VA3437B PROBLEMAS NO ACESSO A V0OPCAOPAG {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                        /*" -2714- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2715- END-IF */
                    }


                    /*" -2716- END-IF */
                }


                /*" -2716- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R1100_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -2702- EXEC SQL SELECT OPCAO_PAGAMENTO, DIA_DEBITO, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-DIA-DEBITO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB, :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB, :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-SECTION */
        private void R1120_00_DECLARE_TITFEDCA_SECTION()
        {
            /*" -2727- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", WABEND.WNR_EXEC_SQL);

            /*" -2728- MOVE 'N' TO WFIM-TITFEDCA */
            _.Move("N", AREA_DE_WORK.WFIM_TITFEDCA);

            /*" -2735- MOVE ZEROS TO WINDC SVA-NRSORTE(1) SVA-NRSORTE(2) SVA-NRSORTE(3) SVA-NRSORTE(4) SVA-NRSORTE(5) */
            _.Move(0, WINDC, REG_SVA3437B.SVA_NRSORTE[1], REG_SVA3437B.SVA_NRSORTE[2], REG_SVA3437B.SVA_NRSORTE[3], REG_SVA3437B.SVA_NRSORTE[4], REG_SVA3437B.SVA_NRSORTE[5]);

            /*" -2742- PERFORM R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1 */

            R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1();

            /*" -2745- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2746- DISPLAY 'VA3437B - ERRO DECLARE CURSOR CTITFEDCA' */
                _.Display($"VA3437B - ERRO DECLARE CURSOR CTITFEDCA");

                /*" -2747- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2749- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2749- PERFORM R1120_00_DECLARE_TITFEDCA_DB_OPEN_1 */

            R1120_00_DECLARE_TITFEDCA_DB_OPEN_1();

            /*" -2752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2753- DISPLAY 'VA3437B - ERRO OPEN CURSOR CTITFEDCA ' */
                _.Display($"VA3437B - ERRO OPEN CURSOR CTITFEDCA ");

                /*" -2754- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -2755- DISPLAY 'CERTIF  = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIF  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2755- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-DECLARE-TITFEDCA-DB-OPEN-1 */
        public void R1120_00_DECLARE_TITFEDCA_DB_OPEN_1()
        {
            /*" -2749- EXEC SQL OPEN CTITFEDCA END-EXEC. */

            CTITFEDCA.Open();

        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-DB-DECLARE-1 */
        public void R2210_00_IMP_CAPITAIS_DB_DECLARE_1()
        {
            /*" -4492- EXEC SQL DECLARE COBER CURSOR FOR SELECT CASE WHEN (T1.COD_COBERTURA = 22 AND T1.DATA_INIVIGENCIA >= :WHOST-DTQUIT) THEN 01 ELSE T1.COD_COBERTURA END , T1.IMP_SEGURADA_IX , T1.DATA_INIVIGENCIA FROM SEGUROS.VG_COBERTURAS_SUBG T1 LEFT JOIN SEGUROS.VG_COBER_SUBG_HIST T2 ON (T2.NUM_APOLICE = T1.NUM_APOLICE AND T2.COD_SUBGRUPO = T1.COD_SUBGRUPO AND T2.COD_COBERTURA = T1.COD_COBERTURA) WHERE T1.NUM_APOLICE = :WHOST-NRAPOLICE AND T1.COD_SUBGRUPO = :WHOST-CODSUBES AND T1.COD_COBERTURA <> 12 AND ((T1.SIT_COBERTURA = '0' ) OR (T1.SIT_COBERTURA = '1' AND T1.NUM_APOLICE = T2.NUM_APOLICE AND T1.COD_SUBGRUPO = T2.COD_SUBGRUPO AND T1.COD_COBERTURA = T2.COD_COBERTURA AND T2.DATA_TERVIGENCIA > :WHOST-DTQUIT AND T2.DATA_TERVIGENCIA = (SELECT MAX(T3.DATA_TERVIGENCIA) FROM SEGUROS.VG_COBER_SUBG_HIST T3 WHERE T3.NUM_APOLICE = T1.NUM_APOLICE AND T3.COD_COBERTURA = T1.COD_COBERTURA AND T3.COD_SUBGRUPO = T1.COD_SUBGRUPO AND T3.DATA_TERVIGENCIA <> '9999-12-31' ) AND NOT EXISTS (SELECT T4.COD_COBERTURA FROM SEGUROS.VG_COBER_SUBG_HIST T4 WHERE T4.NUM_APOLICE = T1.NUM_APOLICE AND T4.COD_SUBGRUPO = T1.COD_SUBGRUPO AND T4.COD_COBERTURA = 22 AND T1.COD_COBERTURA = 01 AND ((T4.DATA_TERVIGENCIA = '9999-12-31' ) OR (T4.DATA_TERVIGENCIA >= T2.DATA_TERVIGENCIA))))) WITH UR END-EXEC. */
            COBER = new VA3437B_COBER(true);
            string GetQuery_COBER()
            {
                var query = @$"SELECT CASE WHEN (T1.COD_COBERTURA = 22 
							AND T1.DATA_INIVIGENCIA >= '{WHOST_DTQUIT}') 
							THEN 01 
							ELSE T1.COD_COBERTURA 
							END 
							, T1.IMP_SEGURADA_IX 
							, T1.DATA_INIVIGENCIA 
							FROM SEGUROS.VG_COBERTURAS_SUBG T1 
							LEFT
							JOIN SEGUROS.VG_COBER_SUBG_HIST T2 
							ON (T2.NUM_APOLICE = T1.NUM_APOLICE 
							AND T2.COD_SUBGRUPO = T1.COD_SUBGRUPO 
							AND T2.COD_COBERTURA = T1.COD_COBERTURA) 
							WHERE T1.NUM_APOLICE = '{WHOST_NRAPOLICE}' 
							AND T1.COD_SUBGRUPO = '{WHOST_CODSUBES}' 
							AND T1.COD_COBERTURA <> 12 
							AND ((T1.SIT_COBERTURA = '0' ) 
							OR (T1.SIT_COBERTURA = '1' 
							AND T1.NUM_APOLICE = T2.NUM_APOLICE 
							AND T1.COD_SUBGRUPO = T2.COD_SUBGRUPO 
							AND T1.COD_COBERTURA = T2.COD_COBERTURA 
							AND T2.DATA_TERVIGENCIA > '{WHOST_DTQUIT}' 
							AND T2.DATA_TERVIGENCIA = 
							(SELECT MAX(T3.DATA_TERVIGENCIA) 
							FROM SEGUROS.VG_COBER_SUBG_HIST T3 
							WHERE T3.NUM_APOLICE = T1.NUM_APOLICE 
							AND T3.COD_COBERTURA = T1.COD_COBERTURA 
							AND T3.COD_SUBGRUPO = T1.COD_SUBGRUPO 
							AND T3.DATA_TERVIGENCIA <> '9999-12-31' ) 
							AND NOT EXISTS 
							(SELECT T4.COD_COBERTURA 
							FROM SEGUROS.VG_COBER_SUBG_HIST T4 
							WHERE T4.NUM_APOLICE = 
							T1.NUM_APOLICE 
							AND T4.COD_SUBGRUPO = 
							T1.COD_SUBGRUPO 
							AND T4.COD_COBERTURA = 22 
							AND T1.COD_COBERTURA = 01 
							AND ((T4.DATA_TERVIGENCIA = 
							'9999-12-31' ) 
							OR (T4.DATA_TERVIGENCIA >= 
							T2.DATA_TERVIGENCIA)))))";

                return query;
            }
            COBER.GetQueryEvent += GetQuery_COBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-SECTION */
        private void R1130_00_FETCH_TITFEDCA_SECTION()
        {
            /*" -2767- MOVE '1130' TO WNR-EXEC-SQL. */
            _.Move("1130", WABEND.WNR_EXEC_SQL);

            /*" -2769- MOVE 'N' TO WFIM-TITFEDCA */
            _.Move("N", AREA_DE_WORK.WFIM_TITFEDCA);

            /*" -2772- PERFORM R1130_00_FETCH_TITFEDCA_DB_FETCH_1 */

            R1130_00_FETCH_TITFEDCA_DB_FETCH_1();

            /*" -2775- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2776- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2777- MOVE 'S' TO WFIM-TITFEDCA */
                    _.Move("S", AREA_DE_WORK.WFIM_TITFEDCA);

                    /*" -2777- PERFORM R1130_00_FETCH_TITFEDCA_DB_CLOSE_1 */

                    R1130_00_FETCH_TITFEDCA_DB_CLOSE_1();

                    /*" -2779- ELSE */
                }
                else
                {


                    /*" -2781- DISPLAY '*** VA3437B PROBLEMAS NO FETCH CTITFEDCA     ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA3437B PROBLEMAS NO FETCH CTITFEDCA     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2781- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1130-00-FETCH-TITFEDCA-DB-FETCH-1 */
        public void R1130_00_FETCH_TITFEDCA_DB_FETCH_1()
        {
            /*" -2772- EXEC SQL FETCH CTITFEDCA INTO :TITFEDCA-NRTITFDCAP, :TITFEDCA-NRSORTEIO END-EXEC. */

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
            /*" -2777- EXEC SQL CLOSE CTITFEDCA END-EXEC */

            CTITFEDCA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-PROCESSA-TITFEDCA-SECTION */
        private void R1140_00_PROCESSA_TITFEDCA_SECTION()
        {
            /*" -2793- MOVE '1140' TO WNR-EXEC-SQL. */
            _.Move("1140", WABEND.WNR_EXEC_SQL);

            /*" -2794- MOVE TITFEDCA-NRTITFDCAP TO WS-NRTITFDCAP */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRTITFDCAP, AREA_DE_WORK.WS_NRTITFDCAP);

            /*" -2797- MOVE WS-NRTITFDCAP(1:3) TO SVA-NUM-PLANO FCPROSUS-NUM-PLANO */
            _.Move(AREA_DE_WORK.WS_NRTITFDCAP.Substring(1, 3), REG_SVA3437B.SVA_NUM_PLANO, FCPROSUS_NUM_PLANO);

            /*" -2798- PERFORM R1145-00-SELECT-PROC-SUSEP-CAP */

            R1145_00_SELECT_PROC_SUSEP_CAP_SECTION();

            /*" -2800- MOVE FCPROSUS-COD-PROCESSO-SUSEP TO SVA-COD-SUSEPCAP */
            _.Move(FCPROSUS_COD_PROCESSO_SUSEP, REG_SVA3437B.SVA_COD_SUSEPCAP);

            /*" -2801- IF (TITFEDCA-NRSORTEIO NOT EQUAL WS-NRSORTEIO-ANT) */

            if ((TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO != AREA_DE_WORK.WS_NRSORTEIO_ANT))
            {

                /*" -2802- ADD 1 TO WINDC */
                WINDC.Value = WINDC + 1;

                /*" -2803- MOVE TITFEDCA-NRSORTEIO TO SVA-NRSORTE(WINDC) */
                _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO, REG_SVA3437B.SVA_NRSORTE[WINDC]);

                /*" -2805- END-IF */
            }


            /*" -2807- MOVE TITFEDCA-NRSORTEIO TO WS-NRSORTEIO-ANT */
            _.Move(TITFEDCA.DCLTITULOS_FED_CAP_VA.TITFEDCA_NRSORTEIO, AREA_DE_WORK.WS_NRSORTEIO_ANT);

            /*" -2807- PERFORM R1130-00-FETCH-TITFEDCA. */

            R1130_00_FETCH_TITFEDCA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1145-00-SELECT-PROC-SUSEP-CAP-SECTION */
        private void R1145_00_SELECT_PROC_SUSEP_CAP_SECTION()
        {
            /*" -2819- MOVE '1145' TO WNR-EXEC-SQL. */
            _.Move("1145", WABEND.WNR_EXEC_SQL);

            /*" -2825- PERFORM R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1 */

            R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1();

            /*" -2828- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2830- DISPLAY '*** VA3437B PROBLEMAS ACESSO PROC SUSEP CAP ' FCPROSUS-NUM-PLANO */
                _.Display($"*** VA3437B PROBLEMAS ACESSO PROC SUSEP CAP {FCPROSUS_NUM_PLANO}");

                /*" -2831- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2832- END-IF. */
            }


        }

        [StopWatch]
        /*" R1145-00-SELECT-PROC-SUSEP-CAP-DB-SELECT-1 */
        public void R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1()
        {
            /*" -2825- EXEC SQL SELECT VALUE(COD_PROCESSO_SUSEP, '********************' ) INTO :FCPROSUS-COD-PROCESSO-SUSEP FROM FDRCAP.FC_PROCESSO_SUSEP WHERE NUM_PLANO= :FCPROSUS-NUM-PLANO WITH UR END-EXEC. */

            var r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1 = new R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1()
            {
                FCPROSUS_NUM_PLANO = FCPROSUS_NUM_PLANO.ToString(),
            };

            var executed_1 = R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1.Execute(r1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCPROSUS_COD_PROCESSO_SUSEP, FCPROSUS_COD_PROCESSO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1145_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-SECTION */
        private void R1200_00_SELECT_CLIENTES_SECTION()
        {
            /*" -2843- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -2845- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -2857- PERFORM R1200_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1200_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -2860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2861- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2862- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -2863- ELSE */
                }
                else
                {


                    /*" -2865- DISPLAY '*** VA3437B PROBLEMAS NO ACESSO A CLIENTES   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA3437B PROBLEMAS NO ACESSO A CLIENTES   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2867- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2868- IF VIND-SEXO LESS 0 */

            if (VIND_SEXO < 0)
            {

                /*" -2871- MOVE ' ' TO CLIENTES-IDE-SEXO. */
                _.Move(" ", CLIENTES.DCLCLIENTES.CLIENTES_IDE_SEXO);
            }


            /*" -2872- IF VIND-DTNASC LESS +0 */

            if (VIND_DTNASC < +0)
            {

                /*" -2874- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -2874- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1200_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -2857- EXEC SQL SELECT NOME_RAZAO, CGCCPF, IDE_SEXO, DATA_NASCIMENTO INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-IDE-SEXO:VIND-SEXO, :CLIENTES-DATA-NASCIMENTO:VIND-DTNASC FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

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
        /*" R1210-00-SELECT-EMAIL-SECTION */
        private void R1210_00_SELECT_EMAIL_SECTION()
        {
            /*" -2886- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", WABEND.WNR_EXEC_SQL);

            /*" -2892- PERFORM R1210_00_SELECT_EMAIL_DB_SELECT_1 */

            R1210_00_SELECT_EMAIL_DB_SELECT_1();

            /*" -2895- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2896- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2897- MOVE SPACES TO CLIENEMA-EMAIL */
                    _.Move("", CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);

                    /*" -2898- ELSE */
                }
                else
                {


                    /*" -2900- DISPLAY '*** VA3437B PROBLEMAS NO ACESSO CLIENTE_EMAIL' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA3437B PROBLEMAS NO ACESSO CLIENTE_EMAIL{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2900- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-EMAIL-DB-SELECT-1 */
        public void R1210_00_SELECT_EMAIL_DB_SELECT_1()
        {
            /*" -2892- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

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
            /*" -2912- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -2914- MOVE 'S' TO WTEM-ENDERECO. */
            _.Move("S", AREA_DE_WORK.WTEM_ENDERECO);

            /*" -2937- PERFORM R1300_00_SELECT_ENDERECO_DB_SELECT_1 */

            R1300_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -2940- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2941- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2942- MOVE 'N' TO WTEM-ENDERECO */
                    _.Move("N", AREA_DE_WORK.WTEM_ENDERECO);

                    /*" -2943- ELSE */
                }
                else
                {


                    /*" -2945- DISPLAY '*** VA3437B PROBLEMAS NO ACESSO A ENDERECOS' PROPOVA-NUM-CERTIFICADO ' ' SEGURVGA-COD-CLIENTE */

                    $"*** VA3437B PROBLEMAS NO ACESSO A ENDERECOS{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE}"
                    .Display();

                    /*" -2945- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void R1300_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -2937- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP ,DDD ,TELEFONE ,TELEX INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP ,:ENDERECO-DDD ,:ENDERECO-TELEFONE ,:ENDERECO-TELEX FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE AND OCORR_ENDERECO = :WHOST-OCOREND WITH UR END-EXEC. */

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
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-SECTION */
        private void R1400_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2957- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -2959- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -2985- PERFORM R1400_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1400_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2988- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2989- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2990- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -2991- ELSE */
                }
                else
                {


                    /*" -2993- DISPLAY 'VA3437B PROBLEMAS ACESSO HIS_COBER_PROPOST ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"VA3437B PROBLEMAS ACESSO HIS_COBER_PROPOST {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2993- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1400_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2985- EXEC SQL SELECT DATA_INIVIGENCIA, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPSEGCDG, VLPREMIO, VAL_CUSTO_CAPITALI INTO :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-COD-OPERACAO, :HISCOBPR-OPCAO-COBERTURA, :HISCOBPR-IMP-MORNATU, :HISCOBPR-IMPSEGCDG, :HISCOBPR-VLPREMIO, :HISCOBPR-VAL-CUSTO-CAPITALI FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND OCORR_HISTORICO = ( SELECT MAX(OCORR_HISTORICO) FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO ) WITH UR END-EXEC. */

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
            /*" -3005- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -3015- PERFORM R1500_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R1500_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -3018- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3019- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3020- MOVE PROPOVA-COD-FONTE TO MALHACEF-COD-FONTE */
                    _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);

                    /*" -3021- ELSE */
                }
                else
                {


                    /*" -3022- DISPLAY 'R1500 - PROBLEMAS SELECT AGENCIAS_CEF ' */
                    _.Display($"R1500 - PROBLEMAS SELECT AGENCIAS_CEF ");

                    /*" -3023- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -3024- DISPLAY 'AGE COBR- ' PROPOVA-AGE-COBRANCA */
                    _.Display($"AGE COBR- {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA}");

                    /*" -3024- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R1500_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -3015- EXEC SQL SELECT B.COD_FONTE INTO :MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND A.COD_AGENCIA = :PROPOVA-AGE-COBRANCA WITH UR END-EXEC. */

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
            /*" -3036- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -3045- PERFORM R1600_00_SELECT_APOLICE_DB_SELECT_1 */

            R1600_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -3048- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3049- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3050- DISPLAY 'APOLICE NAO CADASTRADA ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE NAO CADASTRADA {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -3051- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3052- ELSE */
                }
                else
                {


                    /*" -3054- DISPLAY 'R1600 - PROBLEMAS SELECT APOLICES  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1600 - PROBLEMAS SELECT APOLICES  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -3054- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R1600_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -3045- EXEC SQL SELECT COD_CLIENTE, RAMO_EMISSOR INTO :APOLICES-COD-CLIENTE, :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE WITH UR END-EXEC. */

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
            /*" -3066- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", WABEND.WNR_EXEC_SQL);

            /*" -3076- PERFORM R1640_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R1640_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -3079- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3080- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3081- DISPLAY 'ENDOSSO NAO CADASTRAD0 ' PROPOVA-NUM-APOLICE */
                    _.Display($"ENDOSSO NAO CADASTRAD0 {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -3082- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3083- ELSE */
                }
                else
                {


                    /*" -3085- DISPLAY 'R1640 - PROBLEMAS SELECT ENDOSSOS  ..' SQLCODE ' ' PROPOVA-NUM-APOLICE */

                    $"R1640 - PROBLEMAS SELECT ENDOSSOS  ..{DB.SQLCODE} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                    .Display();

                    /*" -3085- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1640-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R1640_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -3076- EXEC SQL SELECT DATA_TERVIGENCIA, DATA_TERVIGENCIA - 1 YEAR INTO :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA-1 FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC. */

            var r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r1640_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA_1, ENDOSSOS_DATA_TERVIGENCIA_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-CONDITEC-SECTION */
        private void R1800_00_SELECT_CONDITEC_SECTION()
        {
            /*" -3097- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -3099- MOVE 'S' TO WTEM-CONDITEC. */
            _.Move("S", AREA_DE_WORK.WTEM_CONDITEC);

            /*" -3116- PERFORM R1800_00_SELECT_CONDITEC_DB_SELECT_1 */

            R1800_00_SELECT_CONDITEC_DB_SELECT_1();

            /*" -3119- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3120- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3121- MOVE 'N' TO WTEM-CONDITEC */
                    _.Move("N", AREA_DE_WORK.WTEM_CONDITEC);

                    /*" -3122- MOVE ZEROS TO WS-CAR-CONJUGE */
                    _.Move(0, AREA_DE_WORK.WS_CAR_CONJUGE);

                    /*" -3123- GO TO R1800-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/ //GOTO
                    return;

                    /*" -3124- ELSE */
                }
                else
                {


                    /*" -3125- DISPLAY 'VA3437B - NAO ENCONTRADO NA CONDITEC ' */
                    _.Display($"VA3437B - NAO ENCONTRADO NA CONDITEC ");

                    /*" -3126- DISPLAY 'APOLICE  ' WHOST-NRAPOLICE */
                    _.Display($"APOLICE  {WHOST_NRAPOLICE}");

                    /*" -3127- DISPLAY 'SUBGRUPO ' WHOST-CODSUBES */
                    _.Display($"SUBGRUPO {WHOST_CODSUBES}");

                    /*" -3129- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3132- MOVE CONDITEC-CARREGA-CONJUGE TO WS-CAR-CONJUGE. */
            _.Move(CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE, AREA_DE_WORK.WS_CAR_CONJUGE);

            /*" -3134- COMPUTE WS-CAR-CONJUGE = WS-CAR-CONJUGE / 100. */
            AREA_DE_WORK.WS_CAR_CONJUGE.Value = AREA_DE_WORK.WS_CAR_CONJUGE / 100f;

        }

        [StopWatch]
        /*" R1800-00-SELECT-CONDITEC-DB-SELECT-1 */
        public void R1800_00_SELECT_CONDITEC_DB_SELECT_1()
        {
            /*" -3116- EXEC SQL SELECT CARREGA_CONJUGE, GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDITEC-CARREGA-CONJUGE, :CONDITEC-GARAN-ADIC-IEA, :CONDITEC-GARAN-ADIC-IPA, :CONDITEC-GARAN-ADIC-IPD, :CONDITEC-GARAN-ADIC-HD FROM SEGUROS.CONDICOES_TECNICAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES WITH UR END-EXEC. */

            var r1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1 = new R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1()
            {
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
            };

            var executed_1 = R1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_CONDITEC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDITEC_CARREGA_CONJUGE, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IEA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IEA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPA, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPA);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_IPD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_IPD);
                _.Move(executed_1.CONDITEC_GARAN_ADIC_HD, CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_GARAN_ADIC_HD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-LOCALIZA-CEP-SECTION */
        private void R1900_00_LOCALIZA_CEP_SECTION()
        {
            /*" -3146- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -3146- MOVE 1 TO WIND. */
            _.Move(1, AREA_DE_WORK.WIND);

            /*" -0- FLUXCONTROL_PERFORM R1900_10_LOOP */

            R1900_10_LOOP();

        }

        [StopWatch]
        /*" R1900-10-LOOP */
        private void R1900_10_LOOP(bool isPerform = false)
        {
            /*" -3154- IF WIND GREATER 2000 */

            if (AREA_DE_WORK.WIND > 2000)
            {

                /*" -3155- MOVE 01 TO SVA-CEP-G */
                _.Move(01, REG_SVA3437B.SVA_CEP_G);

                /*" -3156- MOVE TAB-FAIXAS (01) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[01].TAB_FAIXAS, REG_SVA3437B.SVA_NOME_CORREIO);

                /*" -3158- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3159- MOVE TAB-FX-FIM (WIND) TO WS-SUP. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_SUP);

            /*" -3161- MOVE TAB-FX-INI (WIND) TO WS-INF. */
            _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_INF);

            /*" -3162- ADD 1 TO WS-SUP. */
            AREA_DE_WORK.WS_SUP.Value = AREA_DE_WORK.WS_SUP + 1;

            /*" -3164- SUBTRACT 1 FROM WS-INF. */
            AREA_DE_WORK.WS_INF.Value = AREA_DE_WORK.WS_INF - 1;

            /*" -3166- IF ENDERECO-CEP GREATER WS-INF AND ENDERECO-CEP LESS WS-SUP */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP > AREA_DE_WORK.WS_INF && ENDERECO.DCLENDERECOS.ENDERECO_CEP < AREA_DE_WORK.WS_SUP)
            {

                /*" -3167- MOVE TAB-FX-CEP-G (WIND) TO SVA-CEP-G */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FX_CEP_G, REG_SVA3437B.SVA_CEP_G);

                /*" -3168- MOVE TAB-FAIXAS (WIND) TO SVA-NOME-CORREIO */
                _.Move(TABELA_CEP.CEP[AREA_DE_WORK.WIND].TAB_FAIXAS, REG_SVA3437B.SVA_NOME_CORREIO);

                /*" -3169- ELSE */
            }
            else
            {


                /*" -3170- ADD 1 TO WIND */
                AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

                /*" -3170- GO TO R1900-10-LOOP. */
                new Task(() => R1900_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1950-00-PRIMEIRO-NOME-SECTION */
        private void R1950_00_PRIMEIRO_NOME_SECTION()
        {
            /*" -3182- MOVE '1950' TO WNR-EXEC-SQL. */
            _.Move("1950", WABEND.WNR_EXEC_SQL);

            /*" -3182- MOVE 1 TO WIND-N. */
            _.Move(1, AREA_DE_WORK.WIND_N);

            /*" -0- FLUXCONTROL_PERFORM R1950_10_LOOP */

            R1950_10_LOOP();

        }

        [StopWatch]
        /*" R1950-10-LOOP */
        private void R1950_10_LOOP(bool isPerform = false)
        {
            /*" -3187- IF WIND-N GREATER 40 */

            if (AREA_DE_WORK.WIND_N > 40)
            {

                /*" -3188- DISPLAY '*** VA3437B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA3437B TAB NOMES ESTOURADA ");

                /*" -3190- GO TO R1950-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3192- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 1 */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] == string.Empty && AREA_DE_WORK.WIND_N == 1)
            {

                /*" -3193- ADD 1 TO WIND-N */
                AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                /*" -3194- GO TO R1950-10-LOOP */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3195- ELSE */
            }
            else
            {


                /*" -3198- IF TAB-NOME (WIND-N) EQUAL SPACES AND WIND-N EQUAL 2 */

                if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] == string.Empty && AREA_DE_WORK.WIND_N == 2)
                {

                    /*" -3199- ADD 1 TO WIND-N */
                    AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                    /*" -3201- GO TO R1950-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -3202- IF TAB-NOME (WIND-N) NOT EQUAL SPACES */

            if (TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N] != string.Empty)
            {

                /*" -3203- MOVE TAB-NOME (WIND-N) TO TAB-NOME1 (WIND-N) */
                _.Move(TABELA_NOMES.TAB_NOMES_R.TAB_NOME[AREA_DE_WORK.WIND_N], TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[AREA_DE_WORK.WIND_N]);

                /*" -3204- ADD 1 TO WIND-N */
                AREA_DE_WORK.WIND_N.Value = AREA_DE_WORK.WIND_N + 1;

                /*" -3206- GO TO R1950-10-LOOP. */
                new Task(() => R1950_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -3206- MOVE ',' TO TAB-NOME1 (WIND-N). */
            _.Move(",", TABELA_NOMES1.TAB_NOMES1_R.TAB_NOME1[AREA_DE_WORK.WIND_N]);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1950_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -3218- MOVE '2000' TO WNR-EXEC-SQL */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -3221- MOVE SVA-TP-ARQSAIDA TO WS-TP-ARQSAIDA-ANT WS-TIPO-ARQ-SAIDA */
            _.Move(REG_SVA3437B.SVA_TP_ARQSAIDA, AREA_DE_WORK.WS_TP_ARQSAIDA_ANT, WS_TIPO_ARQ_SAIDA);

            /*" -3225- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE-ANT COBMENVG-NUM-APOLICE WHOST-NRAPOLICE */
            _.Move(REG_SVA3437B.SVA_NRAPOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE, WHOST_NRAPOLICE);

            /*" -3229- MOVE SVA-CODSUBES TO WS-CODSUBES-ANT COBMENVG-CODSUBES WHOST-CODSUBES */
            _.Move(REG_SVA3437B.SVA_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES, WHOST_CODSUBES);

            /*" -3231- MOVE SVA-DTQUIT TO WHOST-DTQUIT */
            _.Move(REG_SVA3437B.SVA_DTQUIT, WHOST_DTQUIT);

            /*" -3233- PERFORM R2710-00-SELECT-ESTIP */

            R2710_00_SELECT_ESTIP_SECTION();

            /*" -3235- MOVE CLIENTES-NOME-RAZAO TO LC11-ESTIPULANTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_ESTIPULANTE);

            /*" -3237- PERFORM R2715-00-SELECT-SUBESTIP */

            R2715_00_SELECT_SUBESTIP_SECTION();

            /*" -3241- MOVE CLIENTES-NOME-RAZAO TO LC11-ESTIPULANTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_ESTIPULANTE);

            /*" -3242- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SQL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3243- MOVE WS-ANO-SQL TO LK-ANO-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC);

            /*" -3244- MOVE WS-MES-SQL TO LK-MES-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC);

            /*" -3246- MOVE WS-DIA-SQL TO LK-DIA-CALC */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC);

            /*" -3248- PERFORM R2920-00-CALC-DIAS-UTEIS */

            R2920_00_CALC_DIAS_UTEIS_SECTION();

            /*" -3249- MOVE LK-DIA-CALC TO WS-DIA-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_DIA_CALC, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3250- MOVE LK-MES-CALC TO WS-MES-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_MES_CALC, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3251- MOVE LK-ANO-CALC TO WS-ANO-I */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC_R.LK_ANO_CALC, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3254- MOVE '/' TO FILLERB1 FILLERB2. */
            _.Move("/", AREA_DE_WORK.WS_DATA_I.FILLERB1, AREA_DE_WORK.WS_DATA_I.FILLERB2);

            /*" -3256- MOVE WS-DATA-I TO LC11-DTPOSTAGEM. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTPOSTAGEM);

            /*" -3258- PERFORM R2910-00-OBTEM-NUMERACAO */

            R2910_00_OBTEM_NUMERACAO_SECTION();

            /*" -3260- PERFORM R2700-00-SELECT-PRODUVG */

            R2700_00_SELECT_PRODUVG_SECTION();

            /*" -3261- PERFORM R2760-00-SELECT-PRODUTO */

            R2760_00_SELECT_PRODUTO_SECTION();

            /*" -3262- MOVE SPACES TO LC11-COD-SUSEP */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEP);

            /*" -3263- MOVE PRODUTO-NUM-PROCESSO-SUSEP TO LC11-COD-SUSEP */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEP);

            /*" -3265- MOVE PRODUTO-DESCR-PRODUTO TO LC11-NOME-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_PRODUTO);

            /*" -3266- MOVE SPACES TO LC11-COD-SUSEPCAP */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEPCAP);

            /*" -3268- MOVE SVA-COD-SUSEPCAP TO LC11-COD-SUSEPCAP */
            _.Move(REG_SVA3437B.SVA_COD_SUSEPCAP, AREA_DE_WORK.LC11_LINHA11.LC11_COD_SUSEPCAP);

            /*" -3272- PERFORM R2010-00-PROCESSA-PRODUTO UNTIL SVA-TP-ARQSAIDA NOT EQUAL WS-TP-ARQSAIDA-ANT OR SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA3437B.SVA_TP_ARQSAIDA != AREA_DE_WORK.WS_TP_ARQSAIDA_ANT || REG_SVA3437B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVA3437B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_SECTION()
        {
            /*" -3284- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", WABEND.WNR_EXEC_SQL);

            /*" -3285- MOVE SVA-CEP-G TO WS-CEP-G-ANT. */
            _.Move(REG_SVA3437B.SVA_CEP_G, AREA_DE_WORK.WS_CEP_G_ANT);

            /*" -3286- MOVE SVA-NOME-CORREIO TO WS-NOME-COR-ANT. */
            _.Move(REG_SVA3437B.SVA_NOME_CORREIO, AREA_DE_WORK.WS_NOME_COR_ANT);

            /*" -3289- MOVE ZEROS TO WS-CONTR-AMAR WS-CONTR-OBJ. */
            _.Move(0, AREA_DE_WORK.WS_CONTR_AMAR, AREA_DE_WORK.WS_CONTR_OBJ);

            /*" -3291- MOVE TAB-FX-INI (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVA3437B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_INI, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3294- MOVE TAB-FX-FIM (SVA-CEP-G) TO WS-NUM-CEP-AUX. */
            _.Move(TABELA_CEP.CEP[REG_SVA3437B.SVA_CEP_G].TAB_FAIXAS.TAB_FX_FIM, AREA_DE_WORK.WS_NUM_CEP_AUX);

            /*" -3299- PERFORM R2100-00-PROCESSA-CEP UNTIL SVA-TP-ARQSAIDA NOT EQUAL WS-TP-ARQSAIDA-ANT OR SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SVA3437B.SVA_TP_ARQSAIDA != AREA_DE_WORK.WS_TP_ARQSAIDA_ANT || REG_SVA3437B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVA3437B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVA3437B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_CEP_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-CEP-SECTION */
        private void R2100_00_PROCESSA_CEP_SECTION()
        {
            /*" -3311- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -3317- MOVE ZEROS TO AC-CONTA1 AC-QTD-OBJ WS-CONTR-200. */
            _.Move(0, AREA_DE_WORK.AC_CONTA1, AREA_DE_WORK.AC_QTD_OBJ, AREA_DE_WORK.WS_CONTR_200);

            /*" -3319- MOVE SVA-NRAPOLICE TO WS-NUM-APOLICE. */
            _.Move(REG_SVA3437B.SVA_NRAPOLICE, AREA_DE_WORK.WS_CHAVE_R.WS_NUM_APOLICE);

            /*" -3320- MOVE SVA-CODSUBES TO WS-CODSUBES. */
            _.Move(REG_SVA3437B.SVA_CODSUBES, AREA_DE_WORK.WS_CHAVE_R.WS_CODSUBES);

            /*" -3324- MOVE SVA-CODOPER TO WS-OPER-ANT WHOST-CODOPER WS-CODOPER */
            _.Move(REG_SVA3437B.SVA_CODOPER, AREA_DE_WORK.WS_OPER_ANT, WHOST_CODOPER, AREA_DE_WORK.WS_CHAVE_R.WS_CODOPER);

            /*" -3325- IF (SVA-CODUSU EQUAL 'VA0118B' ) */

            if ((REG_SVA3437B.SVA_CODUSU == "VA0118B"))
            {

                /*" -3326- MOVE 'A5' TO WS-IDFORM */
                _.Move("A5", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                /*" -3327- MOVE 6 TO COBMENVG-COD-OPERACAO */
                _.Move(6, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                /*" -3328- ELSE */
            }
            else
            {


                /*" -3329- IF (SVA-CODUSU EQUAL 'VA0130B' ) */

                if ((REG_SVA3437B.SVA_CODUSU == "VA0130B"))
                {

                    /*" -3330- MOVE 'A4' TO WS-IDFORM */
                    _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                    /*" -3331- MOVE 10 TO COBMENVG-COD-OPERACAO */
                    _.Move(10, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                    /*" -3332- ELSE */
                }
                else
                {


                    /*" -3333- MOVE 'A4' TO WS-IDFORM */
                    _.Move("A4", AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM);

                    /*" -3334- MOVE 2 TO COBMENVG-COD-OPERACAO */
                    _.Move(2, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO);

                    /*" -3335- END-IF */
                }


                /*" -3337- END-IF. */
            }


            /*" -3338- MOVE 1 TO INF. */
            _.Move(1, AREA_DE_WORK.INF);

            /*" -3340- MOVE WINDM TO SUP. */
            _.Move(AREA_DE_WORK.WINDM, AREA_DE_WORK.SUP);

            /*" -3343- MOVE SVA-PRODUTO TO W88-PRODUTO-VIDA WS-COD-PRODUTO WS-COD-PRODUTO-ED. */
            _.Move(REG_SVA3437B.SVA_PRODUTO, W88_PRODUTO_VIDA, WS_COD_PRODUTO, WS_COD_PRODUTO_ED);

            /*" -3344- INITIALIZE WS-SIT-PRODUTO */
            _.Initialize(
                AREA_DE_WORK.WS_SIT_PRODUTO
            );

            /*" -3346- PERFORM R2320-PRODUTO-RUNOFF */

            R2320_PRODUTO_RUNOFF_SECTION();

            /*" -3348- PERFORM R2310-00-IDENTIFICA-MSG. */

            R2310_00_IDENTIFICA_MSG_SECTION();

            /*" -3350- MOVE SVA-NRCERTIF TO WS-SALVA-CERTIF */
            _.Move(REG_SVA3437B.SVA_NRCERTIF, AREA_DE_WORK.WS_SALVA_CERTIF);

            /*" -3351- SET W88-IMPRIME-CONTROLES-OK TO TRUE */
            FILLER_1["W88_IMPRIME_CONTROLES_OK"] = true;

            /*" -3353- SET W88-IMPRESSAO-NOK TO TRUE */
            FILLER_0["W88_IMPRESSAO_NOK"] = true;

            /*" -3360- PERFORM R2200-00-PROCESSA-FAC UNTIL SVA-TP-ARQSAIDA NOT EQUAL WS-TP-ARQSAIDA-ANT OR SVA-NRAPOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR SVA-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR SVA-CEP-G NOT EQUAL WS-CEP-G-ANT OR WFIM-SORT EQUAL 'S' OR AC-CONTA1 > 199 OR SVA-CODOPER NOT EQUAL WS-OPER-ANT. */

            while (!(REG_SVA3437B.SVA_TP_ARQSAIDA != AREA_DE_WORK.WS_TP_ARQSAIDA_ANT || REG_SVA3437B.SVA_NRAPOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || REG_SVA3437B.SVA_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || REG_SVA3437B.SVA_CEP_G != AREA_DE_WORK.WS_CEP_G_ANT || AREA_DE_WORK.WFIM_SORT == "S" || AREA_DE_WORK.AC_CONTA1 > 199 || REG_SVA3437B.SVA_CODOPER != AREA_DE_WORK.WS_OPER_ANT))
            {

                R2200_00_PROCESSA_FAC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-SECTION */
        private void R2200_00_PROCESSA_FAC_SECTION()
        {
            /*" -3372- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -3373- MOVE SVA-DTQUIT TO WHOST-DTQUIT */
            _.Move(REG_SVA3437B.SVA_DTQUIT, WHOST_DTQUIT);

            /*" -3374- MOVE SVA-NRAPOLICE TO LC11-APOLICE */
            _.Move(REG_SVA3437B.SVA_NRAPOLICE, AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE);

            /*" -3375- MOVE SVA-RENDA-IND TO LC11-RENDA-IND */
            _.Move(REG_SVA3437B.SVA_RENDA_IND, AREA_DE_WORK.LC11_LINHA11.LC11_RENDA_IND);

            /*" -3376- MOVE SVA-RENDA-FAM TO LC11-RENDA-FAM */
            _.Move(REG_SVA3437B.SVA_RENDA_FAM, AREA_DE_WORK.LC11_LINHA11.LC11_RENDA_FAM);

            /*" -3377- MOVE SVA-EMAIL TO LC11-EMAIL */
            _.Move(REG_SVA3437B.SVA_EMAIL, AREA_DE_WORK.LC11_LINHA11.LC11_EMAIL);

            /*" -3378- MOVE SVA-IDSEXO TO LC11-SEXO */
            _.Move(REG_SVA3437B.SVA_IDSEXO, AREA_DE_WORK.LC11_LINHA11.LC11_SEXO);

            /*" -3379- MOVE SVA-PRODUTO TO LC11-COD-PRODUTO */
            _.Move(REG_SVA3437B.SVA_PRODUTO, AREA_DE_WORK.LC11_LINHA11.LC11_COD_PRODUTO);

            /*" -3380- IF SVA-OPCAO-PAG EQUAL '1' OR '2' */

            if (REG_SVA3437B.SVA_OPCAO_PAG.In("1", "2"))
            {

                /*" -3381- MOVE 'DEBITO EM CONTA' TO LC11-OPCAO-PAG */
                _.Move("DEBITO EM CONTA", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                /*" -3382- ELSE */
            }
            else
            {


                /*" -3383- IF SVA-OPCAO-PAG EQUAL '2' */

                if (REG_SVA3437B.SVA_OPCAO_PAG == "2")
                {

                    /*" -3384- MOVE 'BOLETO' TO LC11-OPCAO-PAG */
                    _.Move("BOLETO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                    /*" -3385- ELSE */
                }
                else
                {


                    /*" -3386- IF SVA-OPCAO-PAG EQUAL '3' */

                    if (REG_SVA3437B.SVA_OPCAO_PAG == "3")
                    {

                        /*" -3387- MOVE 'CARTAO DE CREDITO' TO LC11-OPCAO-PAG */
                        _.Move("CARTAO DE CREDITO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);

                        /*" -3388- ELSE */
                    }
                    else
                    {


                        /*" -3390- MOVE 'OUTROS' TO LC11-OPCAO-PAG. */
                        _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_PAG);
                    }

                }

            }


            /*" -3392- INITIALIZE LC11-SORTE */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_SORTE
            );

            /*" -3400- MOVE SPACES TO LC11-NRSORTE(1) LC11-NRSORTE(2) LC11-NRSORTE(3) LC11-NRSORTE(4) LC11-NRSORTE(5) LC11-DAT-NASC. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[1].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[2].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[3].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[4].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[5].LC11_NRSORTE, AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC);

            /*" -3407- IF W88-PRODUTO-VIDA = 9314 OR JVPRD9314 OR 9328 OR JVPRD9328 OR 9334 OR JVPRD9334 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9703 OR 9705 */

            if (W88_PRODUTO_VIDA.In("9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9703", "9705"))
            {

                /*" -3408- MOVE ZEROS TO I1 */
                _.Move(0, I1);

                /*" -3409- PERFORM UNTIL I1 GREATER 4 */

                while (!(I1 > 4))
                {

                    /*" -3411- ADD 1 TO I1 */
                    I1.Value = I1 + 1;

                    /*" -3412- IF (I1 EQUAL 1) */

                    if ((I1 == 1))
                    {

                        /*" -3413- MOVE 'N�O CONTEMPLA' TO LC11-NRSORTE(I1) */
                        _.Move("N�O CONTEMPLA", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE);

                        /*" -3415- END-IF */
                    }


                    /*" -3416- MOVE '|' TO LC11-NRSORTE-S(I1) */
                    _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE_S);

                    /*" -3417- END-PERFORM */
                }

                /*" -3418- ELSE */
            }
            else
            {


                /*" -3419- IF (SVA-NUM-PLANO GREATER ZEROS) */

                if ((REG_SVA3437B.SVA_NUM_PLANO > 00))
                {

                    /*" -3420- MOVE TAB-QTD-DIG(SVA-NUM-PLANO) TO I2 */
                    _.Move(TAB_QTD_DIG_COMBINACAO.TAB_COMB[REG_SVA3437B.SVA_NUM_PLANO].TAB_QTD_DIG, I2);

                    /*" -3423- SUBTRACT TAB-QTD-DIG(SVA-NUM-PLANO) FROM 9 GIVING WPI */
                    WPI.Value = 9 - TAB_QTD_DIG_COMBINACAO.TAB_COMB[REG_SVA3437B.SVA_NUM_PLANO].TAB_QTD_DIG;

                    /*" -3424- ADD 1 TO WPI */
                    WPI.Value = WPI + 1;

                    /*" -3426- MOVE 1 TO I1 */
                    _.Move(1, I1);

                    /*" -3427- PERFORM UNTIL I1 GREATER 4 */

                    while (!(I1 > 4))
                    {

                        /*" -3428- IF SVA-NRSORTE(I1) GREATER ZEROS */

                        if (REG_SVA3437B.SVA_NRSORTE[I1] > 00)
                        {

                            /*" -3429- MOVE SVA-NRSORTE(I1) TO WS-NRSORTE */
                            _.Move(REG_SVA3437B.SVA_NRSORTE[I1], AREA_DE_WORK.WS_NRSORTE);

                            /*" -3430- MOVE WS-NRSORTE(WPI:I2) TO LC11-NRSORTE(I1) */
                            _.Move(AREA_DE_WORK.WS_NRSORTE.Substring(WPI, I2), AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE);

                            /*" -3431- ELSE */
                        }
                        else
                        {


                            /*" -3432- MOVE 6 TO I1 */
                            _.Move(6, I1);

                            /*" -3433- END-IF */
                        }


                        /*" -3434- ADD 1 TO I1 */
                        I1.Value = I1 + 1;

                        /*" -3435- END-PERFORM */
                    }

                    /*" -3437- END-IF */
                }


                /*" -3438- MOVE ZEROS TO I1 */
                _.Move(0, I1);

                /*" -3439- PERFORM UNTIL I1 GREATER 4 */

                while (!(I1 > 4))
                {

                    /*" -3440- ADD 1 TO I1 */
                    I1.Value = I1 + 1;

                    /*" -3441- MOVE '|' TO LC11-NRSORTE-S(I1) */
                    _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_SORTE.LC11_SORTE1[I1].LC11_NRSORTE_S);

                    /*" -3442- END-PERFORM */
                }

                /*" -3444- END-IF. */
            }


            /*" -3445- MOVE SVA-DTNASC TO WS-DTNASC */
            _.Move(REG_SVA3437B.SVA_DTNASC, AREA_DE_WORK.WS_DTNASC);

            /*" -3448- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DTMOVABE */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DTMOVABE);

            /*" -3452- SUBTRACT WS-ANO-DTNASC FROM WS-ANO-DTMOVABE GIVING WS-IDADE */
            AREA_DE_WORK.WS_IDADE.Value = AREA_DE_WORK.WS_DTMOVABE_R.WS_ANO_DTMOVABE - AREA_DE_WORK.WS_DTNASC_R.WS_ANO_DTNASC;

            /*" -3454- IF WS-MES-DTNASC LESS OR EQUAL WS-ANO-DTMOVABE */

            if (AREA_DE_WORK.WS_DTNASC_R.WS_MES_DTNASC <= AREA_DE_WORK.WS_DTMOVABE_R.WS_ANO_DTMOVABE)
            {

                /*" -3456- ADD 1 TO WS-IDADE. */
                AREA_DE_WORK.WS_IDADE.Value = AREA_DE_WORK.WS_IDADE + 1;
            }


            /*" -3457- MOVE WS-IDADE TO LC11-IDADE. */
            _.Move(AREA_DE_WORK.WS_IDADE, AREA_DE_WORK.LC11_LINHA11.LC11_IDADE);

            /*" -3458- MOVE SVA-DTNASC(1:4) TO LC11-DAT-NASC(7:4) */
            _.MoveAtPosition(REG_SVA3437B.SVA_DTNASC.Substring(1, 4), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 7, 4);

            /*" -3459- MOVE '/' TO LC11-DAT-NASC(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 3, 1);

            /*" -3460- MOVE SVA-DTNASC(6:2) TO LC11-DAT-NASC(4:2) */
            _.MoveAtPosition(REG_SVA3437B.SVA_DTNASC.Substring(6, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 4, 2);

            /*" -3461- MOVE '/' TO LC11-DAT-NASC(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 6, 1);

            /*" -3463- MOVE SVA-DTNASC(9:2) TO LC11-DAT-NASC(1:2) */
            _.MoveAtPosition(REG_SVA3437B.SVA_DTNASC.Substring(9, 2), AREA_DE_WORK.LC11_LINHA11.LC11_DAT_NASC, 1, 2);

            /*" -3470- MOVE SVA-NRCERTIF TO WS-CERTIF WHOST-NRCERTIF */
            _.Move(REG_SVA3437B.SVA_NRCERTIF, AREA_DE_WORK.WS_CERTIF, WHOST_NRCERTIF);

            /*" -3471- IF (SVA-SITSEG NOT EQUAL '0' ) */

            if ((REG_SVA3437B.SVA_SITSEG != "0"))
            {

                /*" -3472- MOVE SVA-CODUSU TO WHOST-CODUSU */
                _.Move(REG_SVA3437B.SVA_CODUSU, WHOST_CODUSU);

                /*" -3474- PERFORM R2205-00-SELECT-USUARIOS */

                R2205_00_SELECT_USUARIOS_SECTION();

                /*" -3475- IF (WTEM-USUARIOS EQUAL 'N' ) */

                if ((AREA_DE_WORK.WTEM_USUARIOS == "N"))
                {

                    /*" -3476- ADD 1 TO AC-DESPR-CANCEL */
                    AREA_DE_WORK.AC_DESPR_CANCEL.Value = AREA_DE_WORK.AC_DESPR_CANCEL + 1;

                    /*" -3477- GO TO R2200-35-ATU-RELATORI */

                    R2200_35_ATU_RELATORI(); //GOTO
                    return;

                    /*" -3478- END-IF */
                }


                /*" -3482- END-IF. */
            }


            /*" -3484- MOVE SVA-TIPOSEGU TO WHOST-TIPOSEGU */
            _.Move(REG_SVA3437B.SVA_TIPOSEGU, WHOST_TIPOSEGU);

            /*" -3485- MOVE WS-NRCERTIF TO LC11-NRCERTIF */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_NRCERTIF, AREA_DE_WORK.LC11_LINHA11.LC11_NRCERTIF);

            /*" -3486- MOVE WS-DVCERTIF TO LC11-DVCERTIF */
            _.Move(AREA_DE_WORK.WS_CERTIF_R.WS_DVCERTIF, AREA_DE_WORK.LC11_LINHA11.LC11_DVCERTIF);

            /*" -3487- MOVE SVA-DTINIVIG TO WS-DATA-SQL */
            _.Move(REG_SVA3437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_SQL);

            /*" -3488- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -3489- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -3490- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -3494- MOVE WS-DATA-I TO LC11-DTINIVIG. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTINIVIG);

            /*" -3498- MOVE SPACES TO TABELA-NOMES TABELA-NOMES1 LC11-CLIENTE. */
            _.Move("", TABELA_NOMES, TABELA_NOMES1, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);

            /*" -3502- MOVE SPACES TO TABELA-NOMES-SOC TABELA-NOMES1-SOC LC11-CLIENTE-SOC. */
            _.Move("", TABELA_NOMES_SOC, TABELA_NOMES1_SOC, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

            /*" -3504- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO TAB-NOMES. */
            _.Move(REG_SVA3437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO, TABELA_NOMES.TAB_NOMES);

            /*" -3506- PERFORM R1950-00-PRIMEIRO-NOME. */

            R1950_00_PRIMEIRO_NOME_SECTION();

            /*" -3508- PERFORM R4000-00-BUSCA-NOM-SOCIAL. */

            R4000_00_BUSCA_NOM_SOCIAL_SECTION();

            /*" -3511- MOVE LC11-NOME-RAZAO-SOC TO TAB-NOMES-SOC TAB-NOMES1-SOC */
            _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC, TABELA_NOMES_SOC.TAB_NOMES_SOC, TABELA_NOMES1_SOC.TAB_NOMES1_SOC);

            /*" -3513- PERFORM R4100-00-PRIMEIRO-NOME-SOCIAL. */

            R4100_00_PRIMEIRO_NOME_SOCIAL_SECTION();

            /*" -3518- MOVE TABELA-NOMES1-SOC TO LC11-CLIENTE-SOC */
            _.Move(TABELA_NOMES1_SOC, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

            /*" -3519- IF SVA-IDSEXO = 'F' */

            if (REG_SVA3437B.SVA_IDSEXO == "F")
            {

                /*" -3520- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                #region STRING
                var spl13 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                _.Move(spl13, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                #endregion

                /*" -3521- ELSE */
            }
            else
            {


                /*" -3522- IF SVA-IDSEXO = 'M' */

                if (REG_SVA3437B.SVA_IDSEXO == "M")
                {

                    /*" -3524- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                    #region STRING
                    var spl14 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl14, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                    #endregion

                    /*" -3525- ELSE */
                }
                else
                {


                    /*" -3527- STRING ' ' TAB-NOMES1 DELIMITED BY '  ' INTO LC11-CLIENTE */
                    #region STRING
                    var spl15 = " " + TABELA_NOMES1.TAB_NOMES1.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl15, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE);
                    #endregion

                    /*" -3528- END-IF */
                }


                /*" -3530- END-IF */
            }


            /*" -3531- MOVE SVA-CPF TO WS-CPF */
            _.Move(REG_SVA3437B.SVA_CPF, AREA_DE_WORK.WS_CPF);

            /*" -3532- MOVE WS-NRCPF TO LC11-NRCPF */
            _.Move(AREA_DE_WORK.WS_CPF_R.WS_NRCPF, AREA_DE_WORK.LC11_LINHA11.LC11_NRCPF);

            /*" -3536- MOVE WS-DVCPF TO LC11-DVCPF. */
            _.Move(AREA_DE_WORK.WS_CPF_R.WS_DVCPF, AREA_DE_WORK.LC11_LINHA11.LC11_DVCPF);

            /*" -3537- IF SVA-IDSEXO = 'F' */

            if (REG_SVA3437B.SVA_IDSEXO == "F")
            {

                /*" -3539- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                #region STRING
                var spl16 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                _.Move(spl16, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                #endregion

                /*" -3540- ELSE */
            }
            else
            {


                /*" -3541- IF SVA-IDSEXO = 'M' */

                if (REG_SVA3437B.SVA_IDSEXO == "M")
                {

                    /*" -3543- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                    #region STRING
                    var spl17 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl17, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                    #endregion

                    /*" -3544- ELSE */
                }
                else
                {


                    /*" -3546- STRING ' ' TAB-NOMES1-SOC DELIMITED BY '  ' INTO LC11-CLIENTE-SOC */
                    #region STRING
                    var spl18 = " " + TABELA_NOMES1_SOC.TAB_NOMES1_SOC.GetMoveValues().Split("  ").FirstOrDefault();
                    _.Move(spl18, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);
                    #endregion

                    /*" -3547- END-IF */
                }


                /*" -3554- END-IF */
            }


            /*" -3576- MOVE ZEROS TO LK-APOLICE LK-SUBGRUPO LK-IDADE LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE */
            _.Move(0, PARAMETROS.LK_APOLICE, PARAMETROS.LK_SUBGRUPO, PARAMETROS.LK_IDADE, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE);

            /*" -3580- MOVE SPACES TO LK-NASCIMENTO LK-MENSAGEM. */
            _.Move("", PARAMETROS.LK_NASCIMENTO, PARAMETROS.LK_MENSAGEM);

            /*" -3581- MOVE SVA-NRAPOLICE TO LK-APOLICE. */
            _.Move(REG_SVA3437B.SVA_NRAPOLICE, PARAMETROS.LK_APOLICE);

            /*" -3583- MOVE SVA-CODSUBES TO LK-SUBGRUPO. */
            _.Move(REG_SVA3437B.SVA_CODSUBES, PARAMETROS.LK_SUBGRUPO);

            /*" -3586- MOVE '220A' TO WNR-EXEC-SQL. */
            _.Move("220A", WABEND.WNR_EXEC_SQL);

            /*" -3588- PERFORM R2800-00-SELECT-SEGURVGA. */

            R2800_00_SELECT_SEGURVGA_SECTION();

            /*" -3590- MOVE '220B' TO WNR-EXEC-SQL. */
            _.Move("220B", WABEND.WNR_EXEC_SQL);

            /*" -3602- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_1 */

            R2200_00_PROCESSA_FAC_DB_SELECT_1();

            /*" -3605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3606- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3607- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AREA_DE_WORK.AC_DESPR_SEGVGAPH.Value = AREA_DE_WORK.AC_DESPR_SEGVGAPH + 1;

                    /*" -3608- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -3609- ELSE */
                }
                else
                {


                    /*" -3611- DISPLAY 'ERRO ACESSO SEGURADOSVGAP_HIST ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO SEGURADOSVGAP_HIST {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3612- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3613- ADD 1 TO AC-DESPR-SEGVGAPH */
                    AREA_DE_WORK.AC_DESPR_SEGVGAPH.Value = AREA_DE_WORK.AC_DESPR_SEGVGAPH + 1;

                    /*" -3615- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3616- IF VIND-CODMOEDA-I < 0 */

            if (VIND_CODMOEDA_I < 0)
            {

                /*" -3619- MOVE 17 TO SEGVGAPH-COD-MOEDA-PRM. */
                _.Move(17, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM);
            }


            /*" -3622- MOVE '220C' TO WNR-EXEC-SQL. */
            _.Move("220C", WABEND.WNR_EXEC_SQL);

            /*" -3633- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_2 */

            R2200_00_PROCESSA_FAC_DB_SELECT_2();

            /*" -3636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3637- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3638- ADD 1 TO AC-DESPR-MOEDACOT */
                    AREA_DE_WORK.AC_DESPR_MOEDACOT.Value = AREA_DE_WORK.AC_DESPR_MOEDACOT + 1;

                    /*" -3639- GO TO R2200-40-NEXT */

                    R2200_40_NEXT(); //GOTO
                    return;

                    /*" -3640- ELSE */
                }
                else
                {


                    /*" -3644- DISPLAY 'ERRO ACESSO MOEDAS_COTACAO     ' SQLCODE ' ' SEGVGAPH-COD-MOEDA-PRM ' ' SEGVGAPH-DATA-MOVIMENTO ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO MOEDAS_COTACAO     {DB.SQLCODE} {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM} {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3645- ADD 1 TO AC-DESPR-MOEDACOT */
                    AREA_DE_WORK.AC_DESPR_MOEDACOT.Value = AREA_DE_WORK.AC_DESPR_MOEDACOT + 1;

                    /*" -3647- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3649- PERFORM R2230-00-SELECT-APOLICE. */

            R2230_00_SELECT_APOLICE_SECTION();

            /*" -3652- MOVE '220D' TO WNR-EXEC-SQL. */
            _.Move("220D", WABEND.WNR_EXEC_SQL);

            /*" -3668- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_3 */

            R2200_00_PROCESSA_FAC_DB_SELECT_3();

            /*" -3671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3672- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3676- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VG APOLICOB-PRM-TARIFARIO-VG APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_VG, APOLICOB_PRM_TARIFARIO_VG, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3677- ELSE */
                }
                else
                {


                    /*" -3679- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS 77/93' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS 77/93{DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3680- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3681- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3683- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3688- COMPUTE APOLICOB-IMP-SEGURADA-VG = APOLICOB-IMP-SEGURADA-VG * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_VG.Value = APOLICOB_IMP_SEGURADA_VG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3693- COMPUTE APOLICOB-PRM-TARIFARIO-VG = APOLICOB-PRM-TARIFARIO-VG * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_PRM_TARIFARIO_VG.Value = APOLICOB_PRM_TARIFARIO_VG * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3696- MOVE '220E' TO WNR-EXEC-SQL. */
            _.Move("220E", WABEND.WNR_EXEC_SQL);

            /*" -3712- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_4 */

            R2200_00_PROCESSA_FAC_DB_SELECT_4();

            /*" -3715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3716- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3720- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AP APOLICOB-PRM-TARIFARIO-AP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AP, APOLICOB_PRM_TARIFARIO_AP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3721- ELSE */
                }
                else
                {


                    /*" -3724- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-01 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-01 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3725- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3726- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3728- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3733- COMPUTE APOLICOB-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-AP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_AP.Value = APOLICOB_IMP_SEGURADA_AP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3738- COMPUTE APOLICOB-PRM-TARIFARIO-AP = APOLICOB-PRM-TARIFARIO-AP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_PRM_TARIFARIO_AP.Value = APOLICOB_PRM_TARIFARIO_AP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3739- IF SVA-VLPREMIO EQUAL ZEROS */

            if (REG_SVA3437B.SVA_VLPREMIO == 00)
            {

                /*" -3743- COMPUTE SVA-VLPREMIO = APOLICOB-PRM-TARIFARIO-VG + APOLICOB-PRM-TARIFARIO-AP. */
                REG_SVA3437B.SVA_VLPREMIO.Value = APOLICOB_PRM_TARIFARIO_VG + APOLICOB_PRM_TARIFARIO_AP;
            }


            /*" -3746- MOVE '220F' TO WNR-EXEC-SQL. */
            _.Move("220F", WABEND.WNR_EXEC_SQL);

            /*" -3760- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_5 */

            R2200_00_PROCESSA_FAC_DB_SELECT_5();

            /*" -3763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3764- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3767- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-IP APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_IP, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3768- ELSE */
                }
                else
                {


                    /*" -3771- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-02 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-02 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3772- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3773- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3775- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3780- COMPUTE APOLICOB-IMP-SEGURADA-IP = APOLICOB-IMP-SEGURADA-IP * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_IP.Value = APOLICOB_IMP_SEGURADA_IP * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3783- MOVE '220G' TO WNR-EXEC-SQL. */
            _.Move("220G", WABEND.WNR_EXEC_SQL);

            /*" -3797- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_6 */

            R2200_00_PROCESSA_FAC_DB_SELECT_6();

            /*" -3800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3801- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3804- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-AMDS APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_AMDS, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3805- ELSE */
                }
                else
                {


                    /*" -3808- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-03 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-03 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3809- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3810- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3812- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3817- COMPUTE APOLICOB-IMP-SEGURADA-AMDS = APOLICOB-IMP-SEGURADA-AMDS * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_AMDS.Value = APOLICOB_IMP_SEGURADA_AMDS * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3820- MOVE '220H' TO WNR-EXEC-SQL. */
            _.Move("220H", WABEND.WNR_EXEC_SQL);

            /*" -3834- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_7 */

            R2200_00_PROCESSA_FAC_DB_SELECT_7();

            /*" -3837- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3838- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3841- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-DH APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_DH, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3842- ELSE */
                }
                else
                {


                    /*" -3845- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-04 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-04 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3846- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3847- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3849- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3854- COMPUTE APOLICOB-IMP-SEGURADA-DH = APOLICOB-IMP-SEGURADA-DH * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_DH.Value = APOLICOB_IMP_SEGURADA_DH * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3857- MOVE '220I' TO WNR-EXEC-SQL. */
            _.Move("220I", WABEND.WNR_EXEC_SQL);

            /*" -3871- PERFORM R2200_00_PROCESSA_FAC_DB_SELECT_8 */

            R2200_00_PROCESSA_FAC_DB_SELECT_8();

            /*" -3874- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3875- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3878- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-DIT APOLICOB-FATOR-MULTIPLICA */
                    _.Move(0, APOLICOB_IMP_SEGURADA_DIT, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);

                    /*" -3879- ELSE */
                }
                else
                {


                    /*" -3882- DISPLAY 'ERRO ACESSO APOLICE_COBERTURAS AP 81-05 ' SQLCODE ' ' WHOST-NRAPOLICE ' ' SEGURVGA-NUM-ITEM */

                    $"ERRO ACESSO APOLICE_COBERTURAS AP 81-05 {DB.SQLCODE} {WHOST_NRAPOLICE} {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}"
                    .Display();

                    /*" -3883- DISPLAY 'CERTIFICADO NAO EMITIDO ' SVA-NRCERTIF */
                    _.Display($"CERTIFICADO NAO EMITIDO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -3884- ADD 1 TO AC-DESPR-APOLICOB */
                    AREA_DE_WORK.AC_DESPR_APOLICOB.Value = AREA_DE_WORK.AC_DESPR_APOLICOB + 1;

                    /*" -3886- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3893- COMPUTE APOLICOB-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-DIT * MOEDACOT-VAL-COMPRA * APOLICOB-FATOR-MULTIPLICA. */
            APOLICOB_IMP_SEGURADA_DIT.Value = APOLICOB_IMP_SEGURADA_DIT * MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA * APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA;

            /*" -3895- MOVE APOLICOB-IMP-SEGURADA-VG TO LK-PURO-MORTE-NATURAL */
            _.Move(APOLICOB_IMP_SEGURADA_VG, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -3897- MOVE APOLICOB-IMP-SEGURADA-AP TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(APOLICOB_IMP_SEGURADA_AP, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -3899- MOVE APOLICOB-IMP-SEGURADA-IP TO LK-PURO-INV-PERMANENTE */
            _.Move(APOLICOB_IMP_SEGURADA_IP, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -3901- MOVE APOLICOB-IMP-SEGURADA-AMDS TO LK-PURO-ASS-MEDICA */
            _.Move(APOLICOB_IMP_SEGURADA_AMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -3903- MOVE APOLICOB-IMP-SEGURADA-DH TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(APOLICOB_IMP_SEGURADA_DH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -3906- MOVE APOLICOB-IMP-SEGURADA-DIT TO LK-PURO-DIARIA-INTERNACAO */
            _.Move(APOLICOB_IMP_SEGURADA_DIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -3908- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -3909- MOVE LK-RETURN-CODE TO WS-RETURN-CODE. */
            _.Move(PARAMETROS.LK_RETURN_CODE, WS_RETURN_CODE);

            /*" -3911- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -3912- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -3913- DISPLAY 'ERRO SUBROTINA VG0710S ' */
                _.Display($"ERRO SUBROTINA VG0710S ");

                /*" -3914- DISPLAY 'MENSAGEM ' LK-MENSAGEM */
                _.Display($"MENSAGEM {PARAMETROS.LK_MENSAGEM}");

                /*" -3915- DISPLAY 'ERRO     ' LK-RETURN-CODE */
                _.Display($"ERRO     {PARAMETROS.LK_RETURN_CODE}");

                /*" -3916- DISPLAY 'ERRO     ' WS-RETURN-CODE-M */
                _.Display($"ERRO     {WS_RETURN_CODE_M}");

                /*" -3917- DISPLAY 'APOLICE  ' SVA-NRAPOLICE */
                _.Display($"APOLICE  {REG_SVA3437B.SVA_NRAPOLICE}");

                /*" -3918- DISPLAY 'CODSUBES ' SVA-CODSUBES */
                _.Display($"CODSUBES {REG_SVA3437B.SVA_CODSUBES}");

                /*" -3919- DISPLAY 'CERTIF   ' WHOST-NRCERTIF */
                _.Display($"CERTIF   {WHOST_NRCERTIF}");

                /*" -3923- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3925- MOVE LK-COBT-MORTE-NATURAL TO APOLICOB-IMP-SEGURADA-VG */
            _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, APOLICOB_IMP_SEGURADA_VG);

            /*" -3927- MOVE LK-COBT-MORTE-ACIDENTAL TO APOLICOB-IMP-SEGURADA-AP */
            _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, APOLICOB_IMP_SEGURADA_AP);

            /*" -3929- MOVE LK-COBT-INV-PERMANENTE TO APOLICOB-IMP-SEGURADA-IP */
            _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, APOLICOB_IMP_SEGURADA_IP);

            /*" -3931- MOVE LK-COBT-INV-POR-ACIDENTE TO APOLICOB-IMP-SEGURADA-IPA */
            _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, APOLICOB_IMP_SEGURADA_IPA);

            /*" -3933- MOVE LK-COBT-ASS-MEDICA TO APOLICOB-IMP-SEGURADA-AMDS */
            _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, APOLICOB_IMP_SEGURADA_AMDS);

            /*" -3935- MOVE LK-COBT-DIARIA-HOSPITALAR TO APOLICOB-IMP-SEGURADA-DH */
            _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, APOLICOB_IMP_SEGURADA_DH);

            /*" -3938- MOVE LK-COBT-DIARIA-INTERNACAO TO APOLICOB-IMP-SEGURADA-DIT. */
            _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, APOLICOB_IMP_SEGURADA_DIT);

            /*" -3944- MOVE SEGVGAPH-DATA-MOVIMENTO TO SVA-DTMOVTO. */
            _.Move(SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO, REG_SVA3437B.SVA_DTMOVTO);

            /*" -3945- IF LC09-LINHA09 NOT EQUAL WS-JDE-ANT */

            if (AREA_DE_WORK.LC09_LINHA09 != AREA_DE_WORK.WS_JDE_ANT)
            {

                /*" -3946- IF WS-CONTROLE EQUAL 1 */

                if (AREA_DE_WORK.WS_CONTROLE == 1)
                {

                    /*" -3948- MOVE ZEROS TO WS-CONTROLE */
                    _.Move(0, AREA_DE_WORK.WS_CONTROLE);

                    /*" -3949- MOVE LC09-LINHA09 TO WS-JDE-ANT */
                    _.Move(AREA_DE_WORK.LC09_LINHA09, AREA_DE_WORK.WS_JDE_ANT);

                    /*" -3951- ELSE */
                }
                else
                {


                    /*" -3952- MOVE LC09-LINHA09 TO WS-JDE-ANT */
                    _.Move(AREA_DE_WORK.LC09_LINHA09, AREA_DE_WORK.WS_JDE_ANT);

                    /*" -3953- END-IF */
                }


                /*" -3954- ELSE */
            }
            else
            {


                /*" -3955- IF WS-CONTROLE EQUAL 1 */

                if (AREA_DE_WORK.WS_CONTROLE == 1)
                {

                    /*" -3956- MOVE ZEROS TO WS-CONTROLE */
                    _.Move(0, AREA_DE_WORK.WS_CONTROLE);

                    /*" -3957- END-IF */
                }


                /*" -3959- END-IF. */
            }


            /*" -3960- INITIALIZE WS-LC09-JDE */
            _.Initialize(
                AREA_DE_WORK.WS_LC09_JDE
            );

            /*" -3964- STRING LC09-LINHA09(2:10) DELIMITED BY '.' INTO WS-LC09-JDE */
            #region STRING
            var spl19 = AREA_DE_WORK.LC09_LINHA09.Substring(2, 10).GetMoveValues().Split(".").FirstOrDefault();
            _.Move(spl19, AREA_DE_WORK.WS_LC09_JDE);
            #endregion

            /*" -3965- EVALUATE WS-LC09-JDE */
            switch (AREA_DE_WORK.WS_LC09_JDE.Value.Trim())
            {

                /*" -3966- WHEN 'va33' */
                case "va33":

                    /*" -3967- ADD 1 TO AC-GRAVA-VA33 */
                    AREA_DE_WORK.AC_GRAVA_VA33.Value = AREA_DE_WORK.AC_GRAVA_VA33 + 1;

                    /*" -3968- WHEN 'VIDA07' */
                    break;
                case "VIDA07":

                /*" -3969- WHEN 'vida07' */
                case "vida07":

                    /*" -3970- ADD 1 TO AC-GRAVA-VIDA07 */
                    AREA_DE_WORK.AC_GRAVA_VIDA07.Value = AREA_DE_WORK.AC_GRAVA_VIDA07 + 1;

                    /*" -3971- WHEN 'va44' */
                    break;
                case "va44":

                    /*" -3972- ADD 1 TO AC-GRAVA-VA44 */
                    AREA_DE_WORK.AC_GRAVA_VA44.Value = AREA_DE_WORK.AC_GRAVA_VA44 + 1;

                    /*" -3973- WHEN 'VIDA05' */
                    break;
                case "VIDA05":

                /*" -3974- WHEN 'vida05' */
                case "vida05":

                    /*" -3975- ADD 1 TO AC-GRAVA-VIDA05 */
                    AREA_DE_WORK.AC_GRAVA_VIDA05.Value = AREA_DE_WORK.AC_GRAVA_VIDA05 + 1;

                    /*" -3976- WHEN 'va54' */
                    break;
                case "va54":

                    /*" -3977- ADD 1 TO AC-GRAVA-VA54 */
                    AREA_DE_WORK.AC_GRAVA_VA54.Value = AREA_DE_WORK.AC_GRAVA_VA54 + 1;

                    /*" -3978- WHEN 'VIDA10' */
                    break;
                case "VIDA10":

                /*" -3979- WHEN 'vida10' */
                case "vida10":

                    /*" -3980- ADD 1 TO AC-GRAVA-VIDA10 */
                    AREA_DE_WORK.AC_GRAVA_VIDA10.Value = AREA_DE_WORK.AC_GRAVA_VIDA10 + 1;

                    /*" -3981- WHEN 'va82' */
                    break;
                case "va82":

                    /*" -3985- ADD 1 TO AC-GRAVA-VA82 */
                    AREA_DE_WORK.AC_GRAVA_VA82.Value = AREA_DE_WORK.AC_GRAVA_VA82 + 1;

                    /*" -3986- WHEN 'va83' */
                    break;
                case "va83":

                    /*" -3990- ADD 1 TO AC-GRAVA-VA83 */
                    AREA_DE_WORK.AC_GRAVA_VA83.Value = AREA_DE_WORK.AC_GRAVA_VA83 + 1;

                    /*" -3991- WHEN 'vd08' */
                    break;
                case "vd08":

                    /*" -3992- ADD 1 TO AC-GRAVA-VD08 */
                    AREA_DE_WORK.AC_GRAVA_VD08.Value = AREA_DE_WORK.AC_GRAVA_VD08 + 1;

                    /*" -3993- WHEN 'VIDA17' */
                    break;
                case "VIDA17":

                /*" -3994- WHEN 'vida17' */
                case "vida17":

                    /*" -3995- ADD 1 TO AC-GRAVA-VIDA17 */
                    AREA_DE_WORK.AC_GRAVA_VIDA17.Value = AREA_DE_WORK.AC_GRAVA_VIDA17 + 1;

                    /*" -3996- WHEN 'vd09' */
                    break;
                case "vd09":

                    /*" -3997- ADD 1 TO AC-GRAVA-VD09 */
                    AREA_DE_WORK.AC_GRAVA_VD09.Value = AREA_DE_WORK.AC_GRAVA_VD09 + 1;

                    /*" -3998- WHEN 'VIDA18' */
                    break;
                case "VIDA18":

                /*" -3999- WHEN 'vida18' */
                case "vida18":

                    /*" -4000- ADD 1 TO AC-GRAVA-VIDA18 */
                    AREA_DE_WORK.AC_GRAVA_VIDA18.Value = AREA_DE_WORK.AC_GRAVA_VIDA18 + 1;

                    /*" -4002- END-EVALUATE. */
                    break;
            }


            /*" -4004- PERFORM R2210-00-IMP-CAPITAIS. */

            R2210_00_IMP_CAPITAIS_SECTION();

            /*" -4005- MOVE SVA-DTMOVTO TO WS-DATA-SQL */
            _.Move(REG_SVA3437B.SVA_DTMOVTO, AREA_DE_WORK.WS_DATA_SQL);

            /*" -4006- MOVE WS-ANO-SQL TO WS-ANO-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_SEC_ANO_R.WS_ANO_SQL, AREA_DE_WORK.WS_DATA_I.WS_SEC_ANO_IR.WS_ANO_I);

            /*" -4007- MOVE WS-MES-SQL TO WS-MES-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_MES_SQL, AREA_DE_WORK.WS_DATA_I.WS_MES_I);

            /*" -4008- MOVE WS-DIA-SQL TO WS-DIA-I */
            _.Move(AREA_DE_WORK.WS_DATA_SQL.WS_DIA_SQL, AREA_DE_WORK.WS_DATA_I.WS_DIA_I);

            /*" -4010- MOVE WS-DATA-I TO LC11-DTALTCAP. */
            _.Move(AREA_DE_WORK.WS_DATA_I, AREA_DE_WORK.LC11_LINHA11.LC11_DTALTCAP);

            /*" -4012- MOVE SPACES TO LC11-OPCAOPAG. */
            _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

            /*" -4013- IF SVA-OPCAOPAG EQUAL '1' OR '2' */

            if (REG_SVA3437B.SVA_OPCAOPAG.In("1", "2"))
            {

                /*" -4014- MOVE SVA-AGECTADEB TO LC11-AGECTADEB */
                _.Move(REG_SVA3437B.SVA_AGECTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_AGECTADEB);

                /*" -4015- MOVE SVA-OPRCTADEB TO LC11-OPRCTADEB */
                _.Move(REG_SVA3437B.SVA_OPRCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_OPRCTADEB);

                /*" -4016- MOVE SVA-NUMCTADEB TO LC11-NUMCTADEB */
                _.Move(REG_SVA3437B.SVA_NUMCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_NUMCTADEB);

                /*" -4017- MOVE SVA-DIGCTADEB TO LC11-DIGCTADEB */
                _.Move(REG_SVA3437B.SVA_DIGCTADEB, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_DIGCTADEB);

                /*" -4019- MOVE '.' TO LC11-PONTO1 LC11-PONTO2 */
                _.Move(".", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_PONTO1, AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_PONTO2);

                /*" -4020- MOVE '-' TO LC11-TRACO */
                _.Move("-", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG_R.LC11_TRACO);

                /*" -4021- ELSE */
            }
            else
            {


                /*" -4022- IF SVA-OPCAOPAG EQUAL '3' */

                if (REG_SVA3437B.SVA_OPCAOPAG == "3")
                {

                    /*" -4024- MOVE 'BOLETO DE COBRANCA BANCARIA' TO LC11-OPCAOPAG */
                    _.Move("BOLETO DE COBRANCA BANCARIA", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

                    /*" -4025- ELSE */
                }
                else
                {


                    /*" -4026- IF SVA-OPCAOPAG EQUAL '4' */

                    if (REG_SVA3437B.SVA_OPCAOPAG == "4")
                    {

                        /*" -4028- MOVE 'DESCONTO EM FOLHA DE PAGTO ' TO LC11-OPCAOPAG */
                        _.Move("DESCONTO EM FOLHA DE PAGTO ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

                        /*" -4029- ELSE */
                    }
                    else
                    {


                        /*" -4030- IF SVA-OPCAOPAG EQUAL '5' */

                        if (REG_SVA3437B.SVA_OPCAOPAG == "5")
                        {

                            /*" -4032- MOVE 'CARTAO DE CREDITO          ' TO LC11-OPCAOPAG */
                            _.Move("CARTAO DE CREDITO          ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);

                            /*" -4033- ELSE */
                        }
                        else
                        {


                            /*" -4036- MOVE '  ************************ ' TO LC11-OPCAOPAG. */
                            _.Move("  ************************ ", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAOPAG);
                        }

                    }

                }

            }


            /*" -4037- IF SVA-PERI-PAGAMENTO EQUAL 1 */

            if (REG_SVA3437B.SVA_PERI_PAGAMENTO == 1)
            {

                /*" -4039- MOVE 'MENSAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                _.Move("MENSAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                /*" -4040- ELSE */
            }
            else
            {


                /*" -4041- IF SVA-PERI-PAGAMENTO EQUAL 2 */

                if (REG_SVA3437B.SVA_PERI_PAGAMENTO == 2)
                {

                    /*" -4043- MOVE 'BIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                    _.Move("BIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                    /*" -4044- ELSE */
                }
                else
                {


                    /*" -4045- IF SVA-PERI-PAGAMENTO EQUAL 3 */

                    if (REG_SVA3437B.SVA_PERI_PAGAMENTO == 3)
                    {

                        /*" -4047- MOVE 'TRIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                        _.Move("TRIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                        /*" -4048- ELSE */
                    }
                    else
                    {


                        /*" -4049- IF SVA-PERI-PAGAMENTO EQUAL 4 */

                        if (REG_SVA3437B.SVA_PERI_PAGAMENTO == 4)
                        {

                            /*" -4051- MOVE 'QUADRIMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                            _.Move("QUADRIMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                            /*" -4052- ELSE */
                        }
                        else
                        {


                            /*" -4053- IF SVA-PERI-PAGAMENTO EQUAL 6 */

                            if (REG_SVA3437B.SVA_PERI_PAGAMENTO == 6)
                            {

                                /*" -4055- MOVE 'SEMESTRAL' TO LC11-NCUSTO LC11-NCUSTO1 */
                                _.Move("SEMESTRAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);

                                /*" -4056- ELSE */
                            }
                            else
                            {


                                /*" -4057- IF SVA-PERI-PAGAMENTO EQUAL 12 */

                                if (REG_SVA3437B.SVA_PERI_PAGAMENTO == 12)
                                {

                                    /*" -4060- MOVE 'ANUAL' TO LC11-NCUSTO LC11-NCUSTO1. */
                                    _.Move("ANUAL", AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO, AREA_DE_WORK.LC11_LINHA11.LC11_NCUSTO1);
                                }

                            }

                        }

                    }

                }

            }


            /*" -4061- MOVE SVA-VLPREMIO TO LC11-VLPREMIO. */
            _.Move(REG_SVA3437B.SVA_VLPREMIO, AREA_DE_WORK.LC11_LINHA11.LC11_VLPREMIO);

            /*" -4063- MOVE SVA-VLPREMIO TO LC11-VLPREMIO2. */
            _.Move(REG_SVA3437B.SVA_VLPREMIO, AREA_DE_WORK.LC11_LINHA11.LC11_VLPREMIO2);

            /*" -4064- IF SVA-DIA-DEBITO GREATER ZEROS */

            if (REG_SVA3437B.SVA_DIA_DEBITO > 00)
            {

                /*" -4065- MOVE SVA-DIA-DEBITO TO LC11-DIA-DEB */
                _.Move(REG_SVA3437B.SVA_DIA_DEBITO, AREA_DE_WORK.LC11_LINHA11.LC11_DIA_DEB);

                /*" -4066- ELSE */
            }
            else
            {


                /*" -4069- MOVE '**' TO LC11-DIA-DEB-ALFA. */
                _.Move("**", AREA_DE_WORK.LC11_LINHA11.LC11_DIA_DEB_R.LC11_DIA_DEB_ALFA);
            }


            /*" -4070- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVA3437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -4073- MOVE '(*) RESPEITADO O PERIODO CORREPONDENTE AO PREMIO PAGO' TO LC11-TEXTO */
                _.Move("(*) RESPEITADO O PERIODO CORREPONDENTE AO PREMIO PAGO", AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

                /*" -4074- ELSE */
            }
            else
            {


                /*" -4075- MOVE SPACES TO LC11-TEXTO */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_TEXTO);

                /*" -4077- END-IF. */
            }


            /*" -4079- MOVE 'SEG. PRINCIPAL: ' TO WS-STRING1 */
            _.Move("SEG. PRINCIPAL: ", AREA_DE_WORK.WS_DATA_SEG.WS_STRING1);

            /*" -4080- MOVE SVA-DTINIVIG TO WS-DATA-INV */
            _.Move(REG_SVA3437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -4081- MOVE WS-DIA-INV TO WS-DIA-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

            /*" -4082- MOVE WS-MES-INV TO WS-MES-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

            /*" -4083- MOVE WS-ANO-INV TO WS-ANO-INI */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

            /*" -4085- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

            /*" -4086- MOVE ' A ' TO WS-FIL-A */
            _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_FIL_A);

            /*" -4087- MOVE SVA-DTTERVIG TO WS-DATA-INV */
            _.Move(REG_SVA3437B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

            /*" -4088- MOVE WS-DIA-INV TO WS-DIA-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

            /*" -4089- MOVE WS-MES-INV TO WS-MES-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

            /*" -4090- MOVE WS-ANO-INV TO WS-ANO-TER */
            _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

            /*" -4093- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
            _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

            /*" -4094- IF SVA-IND-VIGENCIA EQUAL '*' */

            if (REG_SVA3437B.SVA_IND_VIGENCIA == "*")
            {

                /*" -4095- MOVE '(*)' TO WS-STRING2 */
                _.Move("(*)", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -4096- ELSE */
            }
            else
            {


                /*" -4097- MOVE SPACES TO WS-STRING2 */
                _.Move("", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -4099- END-IF. */
            }


            /*" -4101- MOVE WS-DATA-SEG TO LC11-DTVIG-PRIN */
            _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_PRIN);

            /*" -4103- IF CONDITEC-CARREGA-CONJUGE NOT EQUAL ZEROS */

            if (CONDITEC.DCLCONDICOES_TECNICAS.CONDITEC_CARREGA_CONJUGE != 00)
            {

                /*" -4105- MOVE 'SEG. DEPENDENTE:' TO WS-STRING1 */
                _.Move("SEG. DEPENDENTE:", AREA_DE_WORK.WS_DATA_SEG.WS_STRING1);

                /*" -4106- MOVE SVA-DTINIVIG TO WS-DATA-INV */
                _.Move(REG_SVA3437B.SVA_DTINIVIG, AREA_DE_WORK.WS_DATA_INV);

                /*" -4107- MOVE WS-DIA-INV TO WS-DIA-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_DIA_INI);

                /*" -4108- MOVE WS-MES-INV TO WS-MES-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_MES_INI);

                /*" -4109- MOVE WS-ANO-INV TO WS-ANO-INI */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_ANO_INI);

                /*" -4111- MOVE '/' TO WS-BARRA1 WS-BARRA2 */
                _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA1, AREA_DE_WORK.WS_DATA_SEG.WS_DTINIVIG.WS_BARRA2);

                /*" -4112- MOVE ' A ' TO WS-FIL-A */
                _.Move(" A ", AREA_DE_WORK.WS_DATA_SEG.WS_FIL_A);

                /*" -4113- MOVE SVA-DTTERVIG TO WS-DATA-INV */
                _.Move(REG_SVA3437B.SVA_DTTERVIG, AREA_DE_WORK.WS_DATA_INV);

                /*" -4114- MOVE WS-DIA-INV TO WS-DIA-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_DIA_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_DIA_TER);

                /*" -4115- MOVE WS-MES-INV TO WS-MES-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_MES_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_MES_TER);

                /*" -4116- MOVE WS-ANO-INV TO WS-ANO-TER */
                _.Move(AREA_DE_WORK.WS_DATA_INV.WS_ANO_INV, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_ANO_TER);

                /*" -4118- MOVE '/' TO WS-BARRA3 WS-BARRA4 */
                _.Move("/", AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA3, AREA_DE_WORK.WS_DATA_SEG.WS_DTTERVIG.WS_BARRA4);

                /*" -4119- MOVE SPACES TO WS-STRING2 */
                _.Move("", AREA_DE_WORK.WS_DATA_SEG.WS_STRING2);

                /*" -4120- MOVE WS-DATA-SEG TO LC11-DTVIG-DEPE */
                _.Move(AREA_DE_WORK.WS_DATA_SEG, AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_DEPE);

                /*" -4121- ELSE */
            }
            else
            {


                /*" -4122- MOVE SPACES TO LC11-DTVIG-DEPE */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_DTVIG_DEPE);

                /*" -4124- END-IF. */
            }


            /*" -4134- IF (SVA-DDD LESS 11) OR (SVA-DDD EQUAL 20 OR 23 OR 25 OR 26 OR 29 OR 30 OR 36 OR 39 OR 40 OR 50 OR 52 OR 56 OR 57 OR 58 OR 59 OR 60 OR 70 OR 72 OR 76 OR 78 OR 80 OR 90) */

            if ((REG_SVA3437B.SVA_DDD < 11) || (REG_SVA3437B.SVA_DDD.In("20", "23", "25", "26", "29", "30", "36", "39", "40", "50", "52", "56", "57", "58", "59", "60", "70", "72", "76", "78", "80", "90")))
            {

                /*" -4135- MOVE SPACES TO LC11-CELULAR */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR);

                /*" -4136- ELSE */
            }
            else
            {


                /*" -4138- IF SVA-TELEFONE EQUAL ZEROS AND SVA-TELEX EQUAL ZEROS */

                if (REG_SVA3437B.SVA_TELEFONE == 00 && REG_SVA3437B.SVA_TELEX == 00)
                {

                    /*" -4139- MOVE SPACES TO LC11-CELULAR */
                    _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR);

                    /*" -4140- ELSE */
                }
                else
                {


                    /*" -4141- MOVE 'N' TO WS-FONE1-OK */
                    _.Move("N", AREA_DE_WORK.WS_FONE1_OK);

                    /*" -4142- MOVE 'N' TO WS-FONE2-OK */
                    _.Move("N", AREA_DE_WORK.WS_FONE2_OK);

                    /*" -4143- IF SVA-TELEFONE GREATER ZEROS */

                    if (REG_SVA3437B.SVA_TELEFONE > 00)
                    {

                        /*" -4144- MOVE 1 TO WS-TIP-FONE */
                        _.Move(1, AREA_DE_WORK.WS_TIP_FONE);

                        /*" -4145- MOVE SVA-TELEFONE TO WS-NUM-FONE */
                        _.Move(REG_SVA3437B.SVA_TELEFONE, AREA_DE_WORK.WS_NUM_FONE);

                        /*" -4146- PERFORM R2250-00-VALIDA-TELEFONE */

                        R2250_00_VALIDA_TELEFONE_SECTION();

                        /*" -4147- IF WS-FONE1-OK EQUAL 'S' */

                        if (AREA_DE_WORK.WS_FONE1_OK == "S")
                        {

                            /*" -4148- MOVE WS-NUM-FONE TO SVA-TELEFONE */
                            _.Move(AREA_DE_WORK.WS_NUM_FONE, REG_SVA3437B.SVA_TELEFONE);

                            /*" -4149- END-IF */
                        }


                        /*" -4150- END-IF */
                    }


                    /*" -4151- IF SVA-TELEX GREATER ZEROS */

                    if (REG_SVA3437B.SVA_TELEX > 00)
                    {

                        /*" -4152- MOVE 2 TO WS-TIP-FONE */
                        _.Move(2, AREA_DE_WORK.WS_TIP_FONE);

                        /*" -4153- MOVE SVA-TELEX TO WS-NUM-FONE */
                        _.Move(REG_SVA3437B.SVA_TELEX, AREA_DE_WORK.WS_NUM_FONE);

                        /*" -4154- PERFORM R2250-00-VALIDA-TELEFONE */

                        R2250_00_VALIDA_TELEFONE_SECTION();

                        /*" -4155- IF WS-FONE2-OK EQUAL 'S' */

                        if (AREA_DE_WORK.WS_FONE2_OK == "S")
                        {

                            /*" -4156- MOVE WS-NUM-FONE TO SVA-TELEX */
                            _.Move(AREA_DE_WORK.WS_NUM_FONE, REG_SVA3437B.SVA_TELEX);

                            /*" -4157- END-IF */
                        }


                        /*" -4158- END-IF */
                    }


                    /*" -4159- MOVE SPACES TO LC11-CELULAR */
                    _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR);

                    /*" -4160- IF WS-FONE1-OK EQUAL 'S' */

                    if (AREA_DE_WORK.WS_FONE1_OK == "S")
                    {

                        /*" -4161- MOVE SVA-DDD TO LC11-DDD */
                        _.Move(REG_SVA3437B.SVA_DDD, AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR.LC11_DDD);

                        /*" -4162- MOVE SVA-TELEFONE TO WS-NUM-FONE */
                        _.Move(REG_SVA3437B.SVA_TELEFONE, AREA_DE_WORK.WS_NUM_FONE);

                        /*" -4163- IF WS-NUM-FONE-P1 EQUAL 07 */

                        if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1 == 07)
                        {

                            /*" -4164- MOVE SVA-TELEFONE TO LC11-NEXTEL */
                            _.Move(REG_SVA3437B.SVA_TELEFONE, AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR.FILLER_92.LC11_NEXTEL);

                            /*" -4165- ELSE */
                        }
                        else
                        {


                            /*" -4166- MOVE SVA-TELEFONE TO LC11-TELEFONE */
                            _.Move(REG_SVA3437B.SVA_TELEFONE, AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR.LC11_TELEFONE);

                            /*" -4167- END-IF */
                        }


                        /*" -4168- ELSE */
                    }
                    else
                    {


                        /*" -4169- IF WS-FONE2-OK EQUAL 'S' */

                        if (AREA_DE_WORK.WS_FONE2_OK == "S")
                        {

                            /*" -4170- MOVE SVA-DDD TO LC11-DDD */
                            _.Move(REG_SVA3437B.SVA_DDD, AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR.LC11_DDD);

                            /*" -4171- MOVE SVA-TELEX TO WS-NUM-FONE */
                            _.Move(REG_SVA3437B.SVA_TELEX, AREA_DE_WORK.WS_NUM_FONE);

                            /*" -4172- IF WS-NUM-FONE-P1 EQUAL 07 */

                            if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1 == 07)
                            {

                                /*" -4173- MOVE SVA-TELEX TO LC11-NEXTEL */
                                _.Move(REG_SVA3437B.SVA_TELEX, AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR.FILLER_92.LC11_NEXTEL);

                                /*" -4174- ELSE */
                            }
                            else
                            {


                                /*" -4175- MOVE SVA-TELEX TO LC11-TELEFONE */
                                _.Move(REG_SVA3437B.SVA_TELEX, AREA_DE_WORK.LC11_LINHA11.LC11_CELULAR.LC11_TELEFONE);

                                /*" -4176- END-IF */
                            }


                            /*" -4177- END-IF */
                        }


                        /*" -4178- END-IF */
                    }


                    /*" -4179- END-IF */
                }


                /*" -4181- END-IF. */
            }


            /*" -4183- INITIALIZE LC11-BENEFICIARIOS */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS
            );

            /*" -4199- MOVE '|' TO LC11-DELIMIT-01 (1) LC11-DELIMIT-01 (2) LC11-DELIMIT-01 (3) LC11-DELIMIT-01 (4) LC11-DELIMIT-01 (5) LC11-DELIMIT-02 (1) LC11-DELIMIT-02 (2) LC11-DELIMIT-02 (3) LC11-DELIMIT-02 (4) LC11-DELIMIT-02 (5) LC11-DELIMIT-03 (1) LC11-DELIMIT-03 (2) LC11-DELIMIT-03 (3) LC11-DELIMIT-03 (4) LC11-DELIMIT-03 (5). */
            _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_01, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_02, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[2].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[3].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[4].LC11_DELIMIT_03, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[5].LC11_DELIMIT_03);

            /*" -4203- PERFORM R2400-00-BENEFICIARIOS. */

            R2400_00_BENEFICIARIOS_SECTION();

            /*" -4204- IF (WIND-99 EQUAL ZEROS) */

            if ((AREA_DE_WORK.WIND_99 == 00))
            {

                /*" -4205- MOVE 'HERDEIROS LEGAIS' TO LC11-NOME-BENEF(1) */
                _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_NOME_BENEF);

                /*" -4206- MOVE 'OUTROS' TO LC11-PARENTESCO(1) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARENTESCO);

                /*" -4208- MOVE 100 TO LC11-PARTICIP (1) */
                _.Move(100, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARTICIP);

                /*" -4209- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO-END */
                _.Move(REG_SVA3437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

                /*" -4210- MOVE SVA-ENDERECO TO LC11-ENDERECO */
                _.Move(REG_SVA3437B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

                /*" -4211- MOVE SVA-CIDADE TO LC11-CIDADE */
                _.Move(REG_SVA3437B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

                /*" -4212- MOVE SVA-BAIRRO TO LC11-BAIRRO */
                _.Move(REG_SVA3437B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

                /*" -4213- MOVE SVA-UF TO LC11-UF */
                _.Move(REG_SVA3437B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

                /*" -4214- MOVE SVA-CEP TO LC11-CEP */
                _.Move(REG_SVA3437B.SVA_NUM_CEP.SVA_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

                /*" -4216- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL */
                _.Move(REG_SVA3437B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

                /*" -4218- PERFORM R2650-00-BUSCA-FONTE */

                R2650_00_BUSCA_FONTE_SECTION();

                /*" -4221- ADD 1 TO WS-SEQ AC-QTD-OBJ AC-CONTA1 */
                AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
                AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
                AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

                /*" -4222- MOVE WS-SEQ TO WED-SEQ */
                _.Move(AREA_DE_WORK.WS_SEQ, WED_SEQ);

                /*" -4224- MOVE WED-SEQ TO LC11-SEQUENCIA */
                _.Move(WED_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

                /*" -4225- IF WS-CONTR-OBJ EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
                {

                    /*" -4226- MOVE 1 TO WS-CONTR-OBJ */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                    /*" -4228- END-IF */
                }


                /*" -4229- IF WS-CONTR-200 EQUAL ZEROS */

                if (AREA_DE_WORK.WS_CONTR_200 == 00)
                {

                    /*" -4230- MOVE 1 TO WS-CONTR-200 */
                    _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                    /*" -4231- MOVE WS-SEQ TO WS-SEQ-INICIAL */
                    _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);

                    /*" -4233- END-IF */
                }


                /*" -4235- MOVE ZEROS TO WS-SALVA-CERTIF */
                _.Move(0, AREA_DE_WORK.WS_SALVA_CERTIF);

                /*" -4236- IF W88-IMPRIME-CONTROLES-OK */

                if (FILLER_1["W88_IMPRIME_CONTROLES_OK"])
                {

                    /*" -4237- MOVE 10 TO WS-LINHAS-UNIC */
                    _.Move(10, WS_LINHAS_UNIC);

                    /*" -4239- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                    R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                    /*" -4240- SET W88-IMPRIME-CONTROLES-NOK TO TRUE */
                    FILLER_1["W88_IMPRIME_CONTROLES_NOK"] = true;

                    /*" -4242- END-IF */
                }


                /*" -4243- MOVE 11 TO WS-LINHAS-UNIC */
                _.Move(11, WS_LINHAS_UNIC);

                /*" -4245- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                /*" -4246- MOVE 12 TO WS-LINHAS-UNIC */
                _.Move(12, WS_LINHAS_UNIC);

                /*" -4248- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                /*" -4249- ADD 1 TO AC-IMPRESSOS */
                AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

                /*" -4253- SET W88-IMPRESSAO-OK TO TRUE */
                FILLER_0["W88_IMPRESSAO_OK"] = true;

                /*" -4254- MOVE LC11-APOLICE TO FVA3437B-RECORD */
                _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE, FVA3437B_RECORD);

                /*" -4255- WRITE FVA3437B-RECORD */
                FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

                /*" -4256- MOVE SPACES TO FVA3437B-RECORD */
                _.Move("", FVA3437B_RECORD);

                /*" -4257- ELSE */
            }
            else
            {


                /*" -4258- PERFORM R2220-00-IMP-BENEFICIARIOS */

                R2220_00_IMP_BENEFICIARIOS_SECTION();

                /*" -4258- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2200_35_ATU_RELATORI */

            R2200_35_ATU_RELATORI();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-1 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_1()
        {
            /*" -3602- EXEC SQL SELECT DATA_MOVIMENTO, COD_OPERACAO, COD_MOEDA_PRM INTO :SEGVGAPH-DATA-MOVIMENTO, :SEGVGAPH-COD-OPERACAO, :SEGVGAPH-COD-MOEDA-PRM:VIND-CODMOEDA-I FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_1_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_DATA_MOVIMENTO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO);
                _.Move(executed_1.SEGVGAPH_COD_OPERACAO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_OPERACAO);
                _.Move(executed_1.SEGVGAPH_COD_MOEDA_PRM, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM);
                _.Move(executed_1.VIND_CODMOEDA_I, VIND_CODMOEDA_I);
            }


        }

        [StopWatch]
        /*" R2200-35-ATU-RELATORI */
        private void R2200_35_ATU_RELATORI(bool isPerform = false)
        {
            /*" -4263- MOVE SVA-CODRELATVG TO WHOST-CODRELAT. */
            _.Move(REG_SVA3437B.SVA_CODRELATVG, WHOST_CODRELAT);

            /*" -4263- PERFORM R2500-00-UPDATE-RELATORI. */

            R2500_00_UPDATE_RELATORI_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-2 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_2()
        {
            /*" -3633- EXEC SQL SELECT VAL_COMPRA INTO :MOEDACOT-VAL-COMPRA FROM SEGUROS.MOEDAS_COTACAO WHERE COD_MOEDA = :SEGVGAPH-COD-MOEDA-PRM AND DATA_INIVIGENCIA <= :SEGVGAPH-DATA-MOVIMENTO AND DATA_TERVIGENCIA >= :SEGVGAPH-DATA-MOVIMENTO WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1()
            {
                SEGVGAPH_DATA_MOVIMENTO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO.ToString(),
                SEGVGAPH_COD_MOEDA_PRM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_COD_MOEDA_PRM.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_2_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDACOT_VAL_COMPRA, MOEDACOT.DCLMOEDAS_COTACAO.MOEDACOT_VAL_COMPRA);
            }


        }

        [StopWatch]
        /*" R2200-40-NEXT */
        private void R2200_40_NEXT(bool isPerform = false)
        {
            /*" -4269- PERFORM R2300-00-LE-SORT. */

            R2300_00_LE_SORT_SECTION();

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-3 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_3()
        {
            /*" -3668- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-VG, :APOLICOB-PRM-TARIFARIO-VG, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (77,93) AND COD_COBERTURA = 11 WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_3_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_3_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_VG, APOLICOB_IMP_SEGURADA_VG);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VG, APOLICOB_PRM_TARIFARIO_VG);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-4 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_4()
        {
            /*" -3712- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-AP, :APOLICOB-PRM-TARIFARIO-AP, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 01 WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_4_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_4_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_AP, APOLICOB_IMP_SEGURADA_AP);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_AP, APOLICOB_PRM_TARIFARIO_AP);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-SECTION */
        private void R2205_00_SELECT_USUARIOS_SECTION()
        {
            /*" -4281- MOVE '2205' TO WNR-EXEC-SQL. */
            _.Move("2205", WABEND.WNR_EXEC_SQL);

            /*" -4283- MOVE 'S' TO WTEM-USUARIOS. */
            _.Move("S", AREA_DE_WORK.WTEM_USUARIOS);

            /*" -4288- PERFORM R2205_00_SELECT_USUARIOS_DB_SELECT_1 */

            R2205_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -4291- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4292- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4293- MOVE 'N' TO WTEM-USUARIOS */
                    _.Move("N", AREA_DE_WORK.WTEM_USUARIOS);

                    /*" -4294- ELSE */
                }
                else
                {


                    /*" -4296- DISPLAY '*** VA3437B PROBLEMAS NO ACESSO A USUARIOS   ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"*** VA3437B PROBLEMAS NO ACESSO A USUARIOS   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -4296- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2205-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R2205_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -4288- EXEC SQL SELECT COD_USUARIO INTO :USUARIOS-COD-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :WHOST-CODUSU END-EXEC. */

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

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-5 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_5()
        {
            /*" -3760- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-IP, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 02 WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_5_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_5_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_IP, APOLICOB_IMP_SEGURADA_IP);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-6 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_6()
        {
            /*" -3797- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-AMDS, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 03 WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_6_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_6_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_AMDS, APOLICOB_IMP_SEGURADA_AMDS);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-SECTION */
        private void R2210_00_IMP_CAPITAIS_SECTION()
        {
            /*" -4308- MOVE '2210' TO WNR-EXEC-SQL. */
            _.Move("2210", WABEND.WNR_EXEC_SQL);

            /*" -4310- INITIALIZE LC11-COBERTURAS. */
            _.Initialize(
                AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS
            );

            /*" -4322- MOVE '|' TO LC11-DELIMIT-00 (1) LC11-DELIMIT-00 (11) LC11-DELIMIT-00 (2) LC11-DELIMIT-00 (12) LC11-DELIMIT-00 (3) LC11-DELIMIT-00 (13) LC11-DELIMIT-00 (4) LC11-DELIMIT-00 (14) LC11-DELIMIT-00 (5) LC11-DELIMIT-00 (15) LC11-DELIMIT-00 (6) LC11-DELIMIT-00 (16) LC11-DELIMIT-00 (7) LC11-DELIMIT-00 (17) LC11-DELIMIT-00 (8) LC11-DELIMIT-00 (18) LC11-DELIMIT-00 (9) LC11-DELIMIT-00 (19) LC11-DELIMIT-00 (10) LC11-DELIMIT-00 (20) */
            _.Move("|", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[1].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[11].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[2].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[12].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[3].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[13].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[4].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[14].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[5].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[15].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[6].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[16].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[7].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[17].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[8].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[18].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[9].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[19].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[10].LC11_DELIMIT_00, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[20].LC11_DELIMIT_00);

            /*" -4325- MOVE ZEROS TO CONTROLA-IMP W77-IND. */
            _.Move(0, AREA_DE_WORK.CONTROLA_IMP, W77_IND);

            /*" -4326- PERFORM R1800-00-SELECT-CONDITEC */

            R1800_00_SELECT_CONDITEC_SECTION();

            /*" -4328- MOVE WS-CAR-CONJUGE TO WS-PCTCONJUGE */
            _.Move(AREA_DE_WORK.WS_CAR_CONJUGE, WS_PCTCONJUGE);

            /*" -4329- MOVE ZEROES TO WS-IMPCONJUGE. */
            _.Move(0, WS_IMPCONJUGE);

            /*" -4330- IF WS-PCTCONJUGE > ZEROES */

            if (WS_PCTCONJUGE > 00)
            {

                /*" -4336- COMPUTE WS-IMPCONJUGE = APOLICOB-IMP-SEGURADA-VG * WS-PCTCONJUGE. */
                WS_IMPCONJUGE.Value = APOLICOB_IMP_SEGURADA_VG * WS_PCTCONJUGE;
            }


            /*" -4338- IF APOLICOB-IMP-SEGURADA-VG > ZEROS */

            if (APOLICOB_IMP_SEGURADA_VG > 00)
            {

                /*" -4339- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4341- MOVE 'MORTE CAUSAS NATURAIS E ACIDENTAIS.:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("MORTE CAUSAS NATURAIS E ACIDENTAIS.:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4343- MOVE APOLICOB-IMP-SEGURADA-VG TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_VG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4345- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4351- COMPUTE WS-IMP-SEGURADA-AP = APOLICOB-IMP-SEGURADA-AP - APOLICOB-IMP-SEGURADA-VG. */
            WS_IMP_SEGURADA_AP.Value = APOLICOB_IMP_SEGURADA_AP - APOLICOB_IMP_SEGURADA_VG;

            /*" -4352- IF WS-IMP-SEGURADA-AP > ZEROS */

            if (WS_IMP_SEGURADA_AP > 00)
            {

                /*" -4353- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4354- IF SVA-RAMO EQUAL 81 OR 82 */

                if (REG_SVA3437B.SVA_RAMO.In("81", "82"))
                {

                    /*" -4356- MOVE 'MORTE ACIDENTAL....................:  R$   ' TO LC11-STRING1 (W77-IND) */
                    _.Move("MORTE ACIDENTAL....................:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                    /*" -4357- ELSE */
                }
                else
                {


                    /*" -4359- MOVE 'INDENIZ. ESPEC. POR MORTE ACIDENTAL:  R$   ' TO LC11-STRING1 (W77-IND) */
                    _.Move("INDENIZ. ESPEC. POR MORTE ACIDENTAL:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                    /*" -4360- END-IF */
                }


                /*" -4362- MOVE WS-IMP-SEGURADA-AP TO WS-VALOR */
                _.Move(WS_IMP_SEGURADA_AP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4364- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4365- IF APOLICOB-IMP-SEGURADA-IP > ZEROS */

            if (APOLICOB_IMP_SEGURADA_IP > 00)
            {

                /*" -4366- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4368- MOVE 'INVALIDEZ PERMANENTE ACIDENTE(AT�).:  R$  ' TO LC11-STRING1 (W77-IND) */
                _.Move("INVALIDEZ PERMANENTE ACIDENTE(AT�).:  R$  ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4370- MOVE APOLICOB-IMP-SEGURADA-IP TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_IP, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4372- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4374- IF APOLICOB-IMP-SEGURADA-IPA > ZEROS */

            if (APOLICOB_IMP_SEGURADA_IPA > 00)
            {

                /*" -4375- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4377- MOVE 'INVALIDEZ PERMANENTE POR DOEN�A....:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("INVALIDEZ PERMANENTE POR DOEN�A....:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4379- MOVE APOLICOB-IMP-SEGURADA-IPA TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_IPA, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4390- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4391- IF WS-IMPCONJUGE > ZEROS */

            if (WS_IMPCONJUGE > 00)
            {

                /*" -4392- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4394- MOVE 'MORTE DO CONJUGE...................:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("MORTE DO CONJUGE...................:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4396- MOVE WS-IMPCONJUGE TO WS-VALOR */
                _.Move(WS_IMPCONJUGE, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4398- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4399- IF APOLICOB-IMP-SEGURADA-AMDS > ZEROS */

            if (APOLICOB_IMP_SEGURADA_AMDS > 00)
            {

                /*" -4400- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4402- MOVE 'ASSIST�NCIA MEDICA.................:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("ASSIST�NCIA MEDICA.................:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4404- MOVE APOLICOB-IMP-SEGURADA-AMDS TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_AMDS, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4406- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4407- IF APOLICOB-IMP-SEGURADA-DH > ZEROS */

            if (APOLICOB_IMP_SEGURADA_DH > 00)
            {

                /*" -4408- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4410- MOVE 'DIARIA HOSPITALAR..................:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("DIARIA HOSPITALAR..................:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4412- MOVE APOLICOB-IMP-SEGURADA-DH TO WS-VALOR */
                _.Move(APOLICOB_IMP_SEGURADA_DH, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4414- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4416- IF APOLICOB-IMP-SEGURADA-DIT > ZEROES */

            if (APOLICOB_IMP_SEGURADA_DIT > 00)
            {

                /*" -4417- PERFORM R2750-00-SELECT-HISCOBPR */

                R2750_00_SELECT_HISCOBPR_SECTION();

                /*" -4418- IF HISCOBPR-QTMDIT EQUAL ZEROES */

                if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT == 00)
                {

                    /*" -4419- MOVE 15 TO HISCOBPR-QTMDIT */
                    _.Move(15, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);

                    /*" -4420- END-IF */
                }


                /*" -4424- COMPUTE WS-IMP-SEGURADA-DIT = APOLICOB-IMP-SEGURADA-DIT / HISCOBPR-QTMDIT. */
                WS_IMP_SEGURADA_DIT.Value = APOLICOB_IMP_SEGURADA_DIT / HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT;
            }


            /*" -4426- IF APOLICOB-IMP-SEGURADA-DIT > ZEROS */

            if (APOLICOB_IMP_SEGURADA_DIT > 00)
            {

                /*" -4427- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4429- MOVE 'DIARIA INCAPACIDADE TEMPORARIA.....:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("DIARIA INCAPACIDADE TEMPORARIA.....:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4431- MOVE WS-IMP-SEGURADA-DIT TO WS-VALOR */
                _.Move(WS_IMP_SEGURADA_DIT, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4433- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4434- IF WHOST-NRAPOLICE EQUAL 109300000567 */

            if (WHOST_NRAPOLICE == 109300000567)
            {

                /*" -4436- COMPUTE WS-IMP-ADIANT-CDG = APOLICOB-IMP-SEGURADA-VG * 0,5 */
                WS_IMP_ADIANT_CDG.Value = APOLICOB_IMP_SEGURADA_VG * 0.5;

                /*" -4437- ADD 1 TO W77-IND */
                W77_IND.Value = W77_IND + 1;

                /*" -4439- MOVE 'ADIANTAMENTO DOEN�A GRAVE .........:  R$   ' TO LC11-STRING1 (W77-IND) */
                _.Move("ADIANTAMENTO DOEN�A GRAVE .........:  R$   ", AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1);

                /*" -4441- MOVE WS-IMP-ADIANT-CDG TO WS-VALOR */
                _.Move(WS_IMP_ADIANT_CDG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4443- MOVE WS-VALOR TO LC11-VALORA (W77-IND). */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);
            }


            /*" -4446- MOVE '2111' TO WNR-EXEC-SQL. */
            _.Move("2111", WABEND.WNR_EXEC_SQL);

            /*" -4448- MOVE 'N' TO WFIM-COBER. */
            _.Move("N", AREA_DE_WORK.WFIM_COBER);

            /*" -4492- PERFORM R2210_00_IMP_CAPITAIS_DB_DECLARE_1 */

            R2210_00_IMP_CAPITAIS_DB_DECLARE_1();

            /*" -4495- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4496- DISPLAY 'VA3437B - ERRO DECLARE CURSOR COBER' */
                _.Display($"VA3437B - ERRO DECLARE CURSOR COBER");

                /*" -4497- DISPLAY 'SQLCODE  = ' SQLCODE */
                _.Display($"SQLCODE  = {DB.SQLCODE}");

                /*" -4498- DISPLAY 'APOLICE  = ' WHOST-NRAPOLICE */
                _.Display($"APOLICE  = {WHOST_NRAPOLICE}");

                /*" -4499- DISPLAY 'SUBGRUPO = ' WHOST-CODSUBES */
                _.Display($"SUBGRUPO = {WHOST_CODSUBES}");

                /*" -4501- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4501- PERFORM R2210_00_IMP_CAPITAIS_DB_OPEN_1 */

            R2210_00_IMP_CAPITAIS_DB_OPEN_1();

            /*" -4504- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4505- DISPLAY 'VA3437B - ERRO OPEN CURSOR COBER ' */
                _.Display($"VA3437B - ERRO OPEN CURSOR COBER ");

                /*" -4506- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -4508- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4510- PERFORM R2215-00-FETCH-COBER. */

            R2215_00_FETCH_COBER_SECTION();

            /*" -4511- IF WFIM-COBER EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_COBER == "S")
            {

                /*" -4511- GO TO R2210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R2210_10_ACESSORIAS */

            R2210_10_ACESSORIAS();

        }

        [StopWatch]
        /*" R2210-00-IMP-CAPITAIS-DB-OPEN-1 */
        public void R2210_00_IMP_CAPITAIS_DB_OPEN_1()
        {
            /*" -4501- EXEC SQL OPEN COBER END-EXEC. */

            COBER.Open();

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-DECLARE-1 */
        public void R2400_00_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -5091- EXEC SQL DECLARE V0BENEF CURSOR FOR SELECT NOME_BENEFICIARIO, GRAU_PARENTESCO, PCT_PART_BENEFICIA FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_TERVIGENCIA IN ( '1999-12-31' , '9999-12-31' ) WITH UR END-EXEC. */
            V0BENEF = new VA3437B_V0BENEF(true);
            string GetQuery_V0BENEF()
            {
                var query = @$"SELECT NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA 
							FROM SEGUROS.BENEFICIARIOS 
							WHERE NUM_CERTIFICADO = '{WHOST_NRCERTIF}' 
							AND DATA_TERVIGENCIA IN 
							( '1999-12-31'
							, '9999-12-31' )";

                return query;
            }
            V0BENEF.GetQueryEvent += GetQuery_V0BENEF;

        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-7 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_7()
        {
            /*" -3834- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-DH, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 04 WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_7_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_7_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_DH, APOLICOB_IMP_SEGURADA_DH);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2210-10-ACESSORIAS */
        private void R2210_10_ACESSORIAS(bool isPerform = false)
        {
            /*" -4522- IF VGCOBSUB-COD-COBERTURA EQUAL 31 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 31)
            {

                /*" -4523- MOVE 'N' TO WS-TEM-SEGPRECO */
                _.Move("N", WS_TEM_SEGPRECO);

                /*" -4524- PERFORM R3000-00-VERIF-SEGURA-PRECO */

                R3000_00_VERIF_SEGURA_PRECO_SECTION();

                /*" -4526- IF WS-TEM-SEGPRECO EQUAL 'N' */

                if (WS_TEM_SEGPRECO == "N")
                {

                    /*" -4527- GO TO R2210-30-FETCH */

                    R2210_30_FETCH(); //GOTO
                    return;

                    /*" -4528- END-IF */
                }


                /*" -4530- END-IF. */
            }


            /*" -4537- ADD 1 TO W77-IND */
            W77_IND.Value = W77_IND + 1;

            /*" -4538- IF (VGCOBSUB-COD-COBERTURA EQUAL 11) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 11))
            {

                /*" -4539- MOVE '.: R$' TO WS-COBERTURA(40:5) */
                _.MoveAtPosition(".: R$", WS_COBERTURA, 40, 5);

                /*" -4541- END-IF. */
            }


            /*" -4542- IF VGCOBSUB-COD-COBERTURA EQUAL 005 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 005)
            {

                /*" -4543- MOVE TAB-COBER-DESCR(05) TO WS-COBERTURA */
                _.Move(TABELA_COBER.TAB_COBER_R.TAB_COBER_DESCR[05], WS_COBERTURA);

                /*" -4546- END-IF. */
            }


            /*" -4549- MOVE WS-COBERTURA TO LC11-STRING1 (W77-IND) WS-COBER-DESC. */
            _.Move(WS_COBERTURA, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_STRING1, AREA_DE_WORK.WS_COBER_DESC);

            /*" -4551- MOVE SPACES TO WS-VALOR-INT-X */
            _.Move("", AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X);

            /*" -4553- IF WS-COBER-DESC(1:8) = 'REMISSAO' OR WS-COBER-DESC(1:8) = 'REMISS�O' */

            if (AREA_DE_WORK.WS_COBER_DESC.Substring(1, 8) == "REMISSAO" || AREA_DE_WORK.WS_COBER_DESC.Substring(1, 8) == "REMISS�O")
            {

                /*" -4555- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR-INT */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT);

                /*" -4558- STRING '(' WS-VALOR-INT ' MESES) ' DELIMITED BY '  ' INTO WS-VALOR-INT-X */
                #region STRING
                var spl20 = "(" + AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT.GetMoveValues().Split("  ").FirstOrDefault();
                spl20 += " MESES) ";
                _.Move(spl20, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X);
                #endregion

                /*" -4559- ELSE */
            }
            else
            {


                /*" -4561- MOVE VGCOBSUB-IMP-SEGURADA-IX TO WS-VALOR */
                _.Move(VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4563- END-IF */
            }


            /*" -4566- IF VGCOBSUB-COD-COBERTURA EQUAL 01 OR VGCOBSUB-COD-COBERTURA EQUAL 22 AND SVA-IMPSEGCDG GREATER ZEROS */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 01 || VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 22 && REG_SVA3437B.SVA_IMPSEGCDG > 00)
            {

                /*" -4567- MOVE SVA-IMPSEGCDG TO WS-VALOR */
                _.Move(REG_SVA3437B.SVA_IMPSEGCDG, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4570- END-IF */
            }


            /*" -4575- IF VGCOBSUB-COD-COBERTURA EQUAL 02 OR 16 OR 17 OR 18 OR 19 OR 20 OR 25 OR 31 OR 44 OR 75 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.In("02", "16", "17", "18", "19", "20", "25", "31", "44", "75"))
            {

                /*" -4576- MOVE ZEROS TO WS-VALOR */
                _.Move(0, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                /*" -4580- END-IF */
            }


            /*" -4581- IF VGCOBSUB-COD-COBERTURA EQUAL 11 */

            if (VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 11)
            {

                /*" -4583- COMPUTE WS-VALOR-9 = APOLICOB-IMP-SEGURADA-VG / 2 */
                AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9.Value = APOLICOB_IMP_SEGURADA_VG / 2f;

                /*" -4584- IF WS-VALOR-9 > 50000 */

                if (AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9 > 50000)
                {

                    /*" -4585- MOVE 50000 TO WS-VALOR */
                    _.Move(50000, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -4586- ELSE */
                }
                else
                {


                    /*" -4587- MOVE WS-VALOR-9 TO WS-VALOR */
                    _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_9, AREA_DE_WORK.WS_VALORES_AX.WS_VALOR);

                    /*" -4588- END-IF */
                }


                /*" -4590- END-IF. */
            }


            /*" -4591- IF WS-VALOR-INT-X EQUAL SPACES */

            if (AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X.IsEmpty())
            {

                /*" -4592- MOVE WS-VALOR TO LC11-VALORA (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);

                /*" -4593- ELSE */
            }
            else
            {


                /*" -4594- MOVE WS-VALOR-INT-X TO LC11-VALORA (W77-IND) */
                _.Move(AREA_DE_WORK.WS_VALORES_AX.WS_VALOR_INT_X, AREA_DE_WORK.LC11_LINHA11.LC11_COBERTURAS.LC11_COBER_OCC[W77_IND].LC11_VALORA);

                /*" -4594- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-PROCESSA-FAC-DB-SELECT-8 */
        public void R2200_00_PROCESSA_FAC_DB_SELECT_8()
        {
            /*" -3871- EXEC SQL SELECT IMP_SEGURADA_IX, FATOR_MULTIPLICA INTO :APOLICOB-IMP-SEGURADA-DIT, :APOLICOB-FATOR-MULTIPLICA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, 82) AND COD_COBERTURA = 05 WITH UR END-EXEC. */

            var r2200_00_PROCESSA_FAC_DB_SELECT_8_Query1 = new R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                WHOST_NRAPOLICE = WHOST_NRAPOLICE.ToString(),
            };

            var executed_1 = R2200_00_PROCESSA_FAC_DB_SELECT_8_Query1.Execute(r2200_00_PROCESSA_FAC_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_DIT, APOLICOB_IMP_SEGURADA_DIT);
                _.Move(executed_1.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" R2210-30-FETCH */
        private void R2210_30_FETCH(bool isPerform = false)
        {
            /*" -4600- PERFORM R2215-00-FETCH-COBER. */

            R2215_00_FETCH_COBER_SECTION();

            /*" -4601- IF WFIM-COBER EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_COBER == "S")
            {

                /*" -4602- GO TO R2210-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/ //GOTO
                return;

                /*" -4603- ELSE */
            }
            else
            {


                /*" -4603- GO TO R2210-10-ACESSORIAS. */

                R2210_10_ACESSORIAS(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2215-00-FETCH-COBER-SECTION */
        private void R2215_00_FETCH_COBER_SECTION()
        {
            /*" -4615- MOVE '2215' TO WNR-EXEC-SQL. */
            _.Move("2215", WABEND.WNR_EXEC_SQL);

            /*" -4617- MOVE SPACES TO WS-COBERTURA. */
            _.Move("", WS_COBERTURA);

            /*" -4622- PERFORM R2215_00_FETCH_COBER_DB_FETCH_1 */

            R2215_00_FETCH_COBER_DB_FETCH_1();

            /*" -4625- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4626- MOVE 'S' TO WFIM-COBER */
                _.Move("S", AREA_DE_WORK.WFIM_COBER);

                /*" -4626- PERFORM R2215_00_FETCH_COBER_DB_CLOSE_1 */

                R2215_00_FETCH_COBER_DB_CLOSE_1();

                /*" -4635- GO TO R2215-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4638- MOVE '2215-I' TO WNR-EXEC-SQL. */
            _.Move("2215-I", WABEND.WNR_EXEC_SQL);

            /*" -4644- PERFORM R2215_00_FETCH_COBER_DB_SELECT_1 */

            R2215_00_FETCH_COBER_DB_SELECT_1();

            /*" -4647- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4648- DISPLAY 'R2215 - PROBLEMAS NO ACESSO A VG_ACESSORIO' */
                _.Display($"R2215 - PROBLEMAS NO ACESSO A VG_ACESSORIO");

                /*" -4649- DISPLAY 'NUM_ACESSORIO ' VGCOBSUB-COD-COBERTURA */
                _.Display($"NUM_ACESSORIO {VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA}");

                /*" -4650- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4652- END-IF. */
            }


            /*" -4653- IF (VGCOBSUB-COD-COBERTURA EQUAL 22) */

            if ((VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA == 22))
            {

                /*" -4656- IF (WHOST-NRAPOLICE EQUAL 109300000559 OR 3009300000559 OR 3009300001559) */

                if ((WHOST_NRAPOLICE.In("109300000559", "3009300000559", "3009300001559")))
                {

                    /*" -4658- MOVE 'COBERTURA DE DOEN�AS CR�NICAS GRAVES EM EST�GIOAVAN�ADO.: R$' TO WS-COBERTURA */
                    _.Move("COBERTURA DE DOEN�AS CR�NICAS GRAVES EM EST�GIOAVAN�ADO.: R$", WS_COBERTURA);

                    /*" -4659- END-IF */
                }


                /*" -4659- END-IF. */
            }


        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-FETCH-1 */
        public void R2215_00_FETCH_COBER_DB_FETCH_1()
        {
            /*" -4622- EXEC SQL FETCH COBER INTO :VGCOBSUB-COD-COBERTURA, :VGCOBSUB-IMP-SEGURADA-IX, :VGCOBSUB-DATA-INIVIGENCIA END-EXEC. */

            if (COBER.Fetch())
            {
                _.Move(COBER.VGCOBSUB_COD_COBERTURA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA);
                _.Move(COBER.VGCOBSUB_IMP_SEGURADA_IX, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_IMP_SEGURADA_IX);
                _.Move(COBER.VGCOBSUB_DATA_INIVIGENCIA, VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_DATA_INIVIGENCIA);
            }

        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-CLOSE-1 */
        public void R2215_00_FETCH_COBER_DB_CLOSE_1()
        {
            /*" -4626- EXEC SQL CLOSE COBER END-EXEC */

            COBER.Close();

        }

        [StopWatch]
        /*" R2215-00-FETCH-COBER-DB-SELECT-1 */
        public void R2215_00_FETCH_COBER_DB_SELECT_1()
        {
            /*" -4644- EXEC SQL SELECT DES_ACESSORIO INTO :WS-COBERTURA FROM SEGUROS.VG_ACESSORIO WHERE NUM_ACESSORIO = :VGCOBSUB-COD-COBERTURA WITH UR END-EXEC. */

            var r2215_00_FETCH_COBER_DB_SELECT_1_Query1 = new R2215_00_FETCH_COBER_DB_SELECT_1_Query1()
            {
                VGCOBSUB_COD_COBERTURA = VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.ToString(),
            };

            var executed_1 = R2215_00_FETCH_COBER_DB_SELECT_1_Query1.Execute(r2215_00_FETCH_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COBERTURA, WS_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2215_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-IMP-BENEFICIARIOS-SECTION */
        private void R2220_00_IMP_BENEFICIARIOS_SECTION()
        {
            /*" -4671- MOVE '2220' TO WNR-EXEC-SQL. */
            _.Move("2220", WABEND.WNR_EXEC_SQL);

            /*" -4672- MOVE ZEROS TO WIND-88 */
            _.Move(0, AREA_DE_WORK.WIND_88);

            /*" -4673- MOVE 'N' TO WFIM-TABELA WPRIM-LINHA. */
            _.Move("N", AREA_DE_WORK.WFIM_TABELA, AREA_DE_WORK.WPRIM_LINHA);

            /*" -0- FLUXCONTROL_PERFORM R2220_10_INI_CERTIFICADO */

            R2220_10_INI_CERTIFICADO();

        }

        [StopWatch]
        /*" R2220-10-INI-CERTIFICADO */
        private void R2220_10_INI_CERTIFICADO(bool isPerform = false)
        {
            /*" -4678- MOVE ZEROS TO WIND-77 */
            _.Move(0, AREA_DE_WORK.WIND_77);

            /*" -4682- ADD 1 TO WS-SEQ AC-QTD-OBJ AC-CONTA1 */
            AREA_DE_WORK.WS_SEQ.Value = AREA_DE_WORK.WS_SEQ + 1;
            AREA_DE_WORK.AC_QTD_OBJ.Value = AREA_DE_WORK.AC_QTD_OBJ + 1;
            AREA_DE_WORK.AC_CONTA1.Value = AREA_DE_WORK.AC_CONTA1 + 1;

            /*" -4683- MOVE WS-SEQ TO WED-SEQ */
            _.Move(AREA_DE_WORK.WS_SEQ, WED_SEQ);

            /*" -4685- MOVE WED-SEQ TO LC11-SEQUENCIA */
            _.Move(WED_SEQ, AREA_DE_WORK.LC11_LINHA11.LC11_SEQUENCIA);

            /*" -4686- IF WS-CONTR-OBJ EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_OBJ == 00)
            {

                /*" -4687- MOVE 1 TO WS-CONTR-OBJ */
                _.Move(1, AREA_DE_WORK.WS_CONTR_OBJ);

                /*" -4689- END-IF. */
            }


            /*" -4690- IF WS-CONTR-200 EQUAL ZEROS */

            if (AREA_DE_WORK.WS_CONTR_200 == 00)
            {

                /*" -4691- MOVE 1 TO WS-CONTR-200 */
                _.Move(1, AREA_DE_WORK.WS_CONTR_200);

                /*" -4693- MOVE WS-SEQ TO WS-SEQ-INICIAL. */
                _.Move(AREA_DE_WORK.WS_SEQ, AREA_DE_WORK.WS_SEQ_INICIAL);
            }


            /*" -4694- IF WIND-88 > 4 */

            if (AREA_DE_WORK.WIND_88 > 4)
            {

                /*" -4694- PERFORM R2210-00-IMP-CAPITAIS. */

                R2210_00_IMP_CAPITAIS_SECTION();
            }


        }

        [StopWatch]
        /*" R2220-20-BENEFICIARIOS */
        private void R2220_20_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -4706- ADD 1 TO WIND-77 WIND-88. */
            AREA_DE_WORK.WIND_77.Value = AREA_DE_WORK.WIND_77 + 1;
            AREA_DE_WORK.WIND_88.Value = AREA_DE_WORK.WIND_88 + 1;

            /*" -4707- IF WIND-88 > WIND-99 */

            if (AREA_DE_WORK.WIND_88 > AREA_DE_WORK.WIND_99)
            {

                /*" -4708- MOVE 'S' TO WFIM-TABELA */
                _.Move("S", AREA_DE_WORK.WFIM_TABELA);

                /*" -4710- GO TO R2220-30-ENDERECO. */

                R2220_30_ENDERECO(); //GOTO
                return;
            }


            /*" -4712- IF WIND-88 = 1 OR WPRIM-LINHA = 'S' */

            if (AREA_DE_WORK.WIND_88 == 1 || AREA_DE_WORK.WPRIM_LINHA == "S")
            {

                /*" -4713- MOVE 'N' TO WPRIM-LINHA */
                _.Move("N", AREA_DE_WORK.WPRIM_LINHA);

                /*" -4714- ELSE */
            }
            else
            {


                /*" -4716- DIVIDE WIND-88 BY 5 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
                _.Divide(AREA_DE_WORK.WIND_88, 5, AREA_DE_WORK.WS_QUOCIENTE, AREA_DE_WORK.WS_RESTO);

                /*" -4718- IF WS-RESTO = 1 AND WPRIM-LINHA = 'N' */

                if (AREA_DE_WORK.WS_RESTO == 1 && AREA_DE_WORK.WPRIM_LINHA == "N")
                {

                    /*" -4719- MOVE 'N' TO WFIM-TABELA */
                    _.Move("N", AREA_DE_WORK.WFIM_TABELA);

                    /*" -4720- MOVE 'S' TO WPRIM-LINHA */
                    _.Move("S", AREA_DE_WORK.WPRIM_LINHA);

                    /*" -4722- GO TO R2220-30-ENDERECO. */

                    R2220_30_ENDERECO(); //GOTO
                    return;
                }

            }


            /*" -4723- IF (TB99-NOME-BENEF(WIND-88) EQUAL 'HERDEIROS LEGAIS' ) */

            if ((TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_NOME_BENEF == "HERDEIROS LEGAIS"))
            {

                /*" -4724- MOVE 'OUTROS' TO LC11-PARENTESCO(WIND-77) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARENTESCO);

                /*" -4725- ELSE */
            }
            else
            {


                /*" -4727- MOVE TB99-PARENTESCO(WIND-88) TO LC11-PARENTESCO(WIND-77) */
                _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_PARENTESCO, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARENTESCO);

                /*" -4729- END-IF. */
            }


            /*" -4731- MOVE TB99-NOME-BENEF (WIND-88) TO LC11-NOME-BENEF (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_NOME_BENEF, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_NOME_BENEF);

            /*" -4734- MOVE TB99-PARTICIP (WIND-88) TO LC11-PARTICIP (WIND-77). */
            _.Move(TB99.TB99_CONT[AREA_DE_WORK.WIND_88].TB99_PARTICIP, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[AREA_DE_WORK.WIND_77].LC11_PARTICIP);

            /*" -4734- GO TO R2220-20-BENEFICIARIOS. */
            new Task(() => R2220_20_BENEFICIARIOS()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R2220-30-ENDERECO */
        private void R2220_30_ENDERECO(bool isPerform = false)
        {
            /*" -4739- MOVE SVA-NOME-RAZAO TO LC11-NOME-RAZAO-END */
            _.Move(REG_SVA3437B.SVA_NOME_RAZAO, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END);

            /*" -4740- MOVE SVA-ENDERECO TO LC11-ENDERECO. */
            _.Move(REG_SVA3437B.SVA_ENDERECO, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO);

            /*" -4741- MOVE SVA-CIDADE TO LC11-CIDADE. */
            _.Move(REG_SVA3437B.SVA_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE);

            /*" -4742- MOVE SVA-BAIRRO TO LC11-BAIRRO. */
            _.Move(REG_SVA3437B.SVA_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO);

            /*" -4743- MOVE SVA-UF TO LC11-UF. */
            _.Move(REG_SVA3437B.SVA_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF);

            /*" -4744- MOVE SVA-NUM-CEP TO LC11-CEP. */
            _.Move(REG_SVA3437B.SVA_NUM_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP);

            /*" -4746- MOVE SVA-CEP-COMPL TO LC11-CEP-COMPL. */
            _.Move(REG_SVA3437B.SVA_NUM_CEP.SVA_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL);

            /*" -4748- PERFORM R2650-00-BUSCA-FONTE. */

            R2650_00_BUSCA_FONTE_SECTION();

            /*" -4750- MOVE ZEROS TO WS-SALVA-CERTIF */
            _.Move(0, AREA_DE_WORK.WS_SALVA_CERTIF);

            /*" -4751- IF W88-IMPRIME-CONTROLES-OK */

            if (FILLER_1["W88_IMPRIME_CONTROLES_OK"])
            {

                /*" -4752- MOVE 10 TO WS-LINHAS-UNIC */
                _.Move(10, WS_LINHAS_UNIC);

                /*" -4754- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

                R9155_00_GRAVA_LINHAS_UNIC_SECTION();

                /*" -4755- SET W88-IMPRIME-CONTROLES-NOK TO TRUE */
                FILLER_1["W88_IMPRIME_CONTROLES_NOK"] = true;

                /*" -4757- END-IF */
            }


            /*" -4758- MOVE 11 TO WS-LINHAS-UNIC */
            _.Move(11, WS_LINHAS_UNIC);

            /*" -4760- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

            R9155_00_GRAVA_LINHAS_UNIC_SECTION();

            /*" -4761- MOVE 12 TO WS-LINHAS-UNIC */
            _.Move(12, WS_LINHAS_UNIC);

            /*" -4763- PERFORM R9155-00-GRAVA-LINHAS-UNIC */

            R9155_00_GRAVA_LINHAS_UNIC_SECTION();

            /*" -4764- ADD 1 TO AC-IMPRESSOS */
            AREA_DE_WORK.AC_IMPRESSOS.Value = AREA_DE_WORK.AC_IMPRESSOS + 1;

            /*" -4768- SET W88-IMPRESSAO-OK TO TRUE */
            FILLER_0["W88_IMPRESSAO_OK"] = true;

            /*" -4769- MOVE LC11-APOLICE TO FVA3437B-RECORD */
            _.Move(AREA_DE_WORK.LC11_LINHA11.LC11_APOLICE, FVA3437B_RECORD);

            /*" -4770- WRITE FVA3437B-RECORD */
            FVA3437B.Write(FVA3437B_RECORD.GetMoveValues().ToString());

            /*" -4772- MOVE SPACES TO FVA3437B-RECORD */
            _.Move("", FVA3437B_RECORD);

            /*" -4773- IF WFIM-TABELA NOT = 'S' */

            if (AREA_DE_WORK.WFIM_TABELA != "S")
            {

                /*" -4774- SUBTRACT 1 FROM WIND-88 */
                AREA_DE_WORK.WIND_88.Value = AREA_DE_WORK.WIND_88 - 1;

                /*" -4775- GO TO R2220-10-INI-CERTIFICADO */

                R2220_10_INI_CERTIFICADO(); //GOTO
                return;

                /*" -4775- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-SELECT-APOLICE-SECTION */
        private void R2230_00_SELECT_APOLICE_SECTION()
        {
            /*" -4787- MOVE '2230' TO WNR-EXEC-SQL. */
            _.Move("2230", WABEND.WNR_EXEC_SQL);

            /*" -4792- PERFORM R2230_00_SELECT_APOLICE_DB_SELECT_1 */

            R2230_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -4795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4797- DISPLAY '*** VA3437B PROBLEMAS ACESSO APOLICES ' WHOST-NRAPOLICE */
                _.Display($"*** VA3437B PROBLEMAS ACESSO APOLICES {WHOST_NRAPOLICE}");

                /*" -4798- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2230-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R2230_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -4792- EXEC SQL SELECT COD_MODALIDADE INTO :APOLICES-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :WHOST-NRAPOLICE END-EXEC. */

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
        /*" R2250-00-VALIDA-TELEFONE-SECTION */
        private void R2250_00_VALIDA_TELEFONE_SECTION()
        {
            /*" -4809- IF WS-NUM-FONE LESS 1000 */

            if (AREA_DE_WORK.WS_NUM_FONE < 1000)
            {

                /*" -4810- GO TO R2250-90-FONE-INVALIDO */

                R2250_90_FONE_INVALIDO(); //GOTO
                return;

                /*" -4812- END-IF. */
            }


            /*" -4822- IF WS-NUM-FONE-P2 EQUAL 0000000 OR 1111111 OR 2222222 OR 3333333 OR 4444444 OR 5555555 OR 6666666 OR 7777777 OR 8888888 OR 9999999 */

            if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P2.In("0000000", "1111111", "2222222", "3333333", "4444444", "5555555", "6666666", "7777777", "8888888", "9999999"))
            {

                /*" -4823- GO TO R2250-90-FONE-INVALIDO */

                R2250_90_FONE_INVALIDO(); //GOTO
                return;

                /*" -4825- END-IF. */
            }


            /*" -4828- IF (WS-NUM-FONE-P3 EQUAL 070 OR 077 OR 078 OR 079) AND WS-NUM-FONE-P4 GREATER ZEROS */

            if ((AREA_DE_WORK.FILLER_103.WS_NUM_FONE_P3.In("070", "077", "078", "079")) && AREA_DE_WORK.FILLER_103.WS_NUM_FONE_P4 > 00)
            {

                /*" -4829- IF WS-TIP-FONE EQUAL 1 */

                if (AREA_DE_WORK.WS_TIP_FONE == 1)
                {

                    /*" -4830- MOVE 'S' TO WS-FONE1-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE1_OK);

                    /*" -4831- ELSE */
                }
                else
                {


                    /*" -4832- MOVE 'S' TO WS-FONE2-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE2_OK);

                    /*" -4833- END-IF */
                }


                /*" -4834- GO TO R2250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                return;

                /*" -4836- END-IF. */
            }


            /*" -4839- IF WS-NUM-FONE-P1 EQUAL 10 AND WS-NUM-FONE-P2 GREATER ZEROS */

            if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1 == 10 && AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P2 > 00)
            {

                /*" -4840- IF WS-TIP-FONE EQUAL 1 */

                if (AREA_DE_WORK.WS_TIP_FONE == 1)
                {

                    /*" -4841- MOVE 'S' TO WS-FONE1-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE1_OK);

                    /*" -4842- ELSE */
                }
                else
                {


                    /*" -4843- MOVE 'S' TO WS-FONE2-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE2_OK);

                    /*" -4844- END-IF */
                }


                /*" -4845- GO TO R2250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                return;

                /*" -4847- END-IF. */
            }


            /*" -4851- IF WS-NUM-FONE-P1 NOT LESS 91 AND WS-NUM-FONE-P1 NOT GREATER 99 AND WS-NUM-FONE-P2 GREATER ZEROS */

            if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1 >= 91 && AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1 <= 99 && AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P2 > 00)
            {

                /*" -4852- IF WS-TIP-FONE EQUAL 1 */

                if (AREA_DE_WORK.WS_TIP_FONE == 1)
                {

                    /*" -4853- MOVE 'S' TO WS-FONE1-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE1_OK);

                    /*" -4854- ELSE */
                }
                else
                {


                    /*" -4855- MOVE 'S' TO WS-FONE2-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE2_OK);

                    /*" -4856- END-IF */
                }


                /*" -4857- GO TO R2250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                return;

                /*" -4859- END-IF. */
            }


            /*" -4861- IF WS-NUM-FONE-P1 EQUAL 02 OR 03 OR 04 OR 05 */

            if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1.In("02", "03", "04", "05"))
            {

                /*" -4862- GO TO R2250-90-FONE-INVALIDO */

                R2250_90_FONE_INVALIDO(); //GOTO
                return;

                /*" -4864- END-IF. */
            }


            /*" -4868- IF WS-NUM-FONE-P1 EQUAL (06 OR 07 OR 08 OR 09) AND WS-NUM-FONE-P2 GREATER ZEROS */

            if (AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1.In("06", "07", "08", "09") && AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P2 > 00)
            {

                /*" -4869- COMPUTE WS-NUM-FONE-P1 = WS-NUM-FONE-P1 + 90 */
                AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1.Value = AREA_DE_WORK.FILLER_102.WS_NUM_FONE_P1 + 90;

                /*" -4870- IF WS-TIP-FONE EQUAL 1 */

                if (AREA_DE_WORK.WS_TIP_FONE == 1)
                {

                    /*" -4871- MOVE 'S' TO WS-FONE1-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE1_OK);

                    /*" -4872- ELSE */
                }
                else
                {


                    /*" -4873- MOVE 'S' TO WS-FONE2-OK */
                    _.Move("S", AREA_DE_WORK.WS_FONE2_OK);

                    /*" -4874- END-IF */
                }


                /*" -4875- GO TO R2250-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                return;

                /*" -4875- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R2250_90_FONE_INVALIDO */

            R2250_90_FONE_INVALIDO();

        }

        [StopWatch]
        /*" R2250-90-FONE-INVALIDO */
        private void R2250_90_FONE_INVALIDO(bool isPerform = false)
        {
            /*" -4880- IF WS-TIP-FONE EQUAL 1 */

            if (AREA_DE_WORK.WS_TIP_FONE == 1)
            {

                /*" -4881- MOVE 'N' TO WS-FONE1-OK */
                _.Move("N", AREA_DE_WORK.WS_FONE1_OK);

                /*" -4882- ELSE */
            }
            else
            {


                /*" -4883- MOVE 'N' TO WS-FONE2-OK */
                _.Move("N", AREA_DE_WORK.WS_FONE2_OK);

                /*" -4883- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-LE-SORT-SECTION */
        private void R2300_00_LE_SORT_SECTION()
        {
            /*" -4895- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -4897- RETURN SVA3437B AT END */
            try
            {
                SVA3437B.Return(REG_SVA3437B, () =>
                {

                    /*" -4898- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", AREA_DE_WORK.WFIM_SORT);

                    /*" -4900- GO TO R2300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -4904- ADD 1 TO AC-LIDOS AC-LIDOS-SORT AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_LIDOS_SORT.Value = AREA_DE_WORK.AC_LIDOS_SORT + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -4904- MOVE SVA-COD-EMPRESA TO PRODUTO-COD-EMPRESA. */
            _.Move(REG_SVA3437B.SVA_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2310-00-IDENTIFICA-MSG-SECTION */
        private void R2310_00_IDENTIFICA_MSG_SECTION()
        {
            /*" -4913- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", WABEND.WNR_EXEC_SQL);

            /*" -4914- IF (INF > SUP) */

            if ((AREA_DE_WORK.INF > AREA_DE_WORK.SUP))
            {

                /*" -4915- MOVE 'N' TO WTEM-MULTIMSG */
                _.Move("N", AREA_DE_WORK.WTEM_MULTIMSG);

                /*" -4916- ELSE */
            }
            else
            {


                /*" -4917- COMPUTE WS-IND = (SUP + INF) / 2 */
                AREA_DE_WORK.WS_IND.Value = (AREA_DE_WORK.SUP + AREA_DE_WORK.INF) / 2;

                /*" -4918- IF (WS-CHAVE < TABJ-CHAVE(WS-IND)) */

                if ((AREA_DE_WORK.WS_CHAVE < TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE))
                {

                    /*" -4919- COMPUTE SUP = WS-IND - 1 */
                    AREA_DE_WORK.SUP.Value = AREA_DE_WORK.WS_IND - 1;

                    /*" -4920- GO TO R2310-00-IDENTIFICA-MSG */
                    new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4921- ELSE */
                }
                else
                {


                    /*" -4922- IF (WS-CHAVE > TABJ-CHAVE(WS-IND)) */

                    if ((AREA_DE_WORK.WS_CHAVE > TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_CHAVE))
                    {

                        /*" -4923- COMPUTE INF = WS-IND + 1 */
                        AREA_DE_WORK.INF.Value = AREA_DE_WORK.WS_IND + 1;

                        /*" -4924- GO TO R2310-00-IDENTIFICA-MSG */
                        new Task(() => R2310_00_IDENTIFICA_MSG_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -4925- ELSE */
                    }
                    else
                    {


                        /*" -4926- MOVE 'S' TO WTEM-MULTIMSG */
                        _.Move("S", AREA_DE_WORK.WTEM_MULTIMSG);

                        /*" -4927- END-IF */
                    }


                    /*" -4928- END-IF */
                }


                /*" -4930- END-IF. */
            }


            /*" -4931- IF (WTEM-MULTIMSG EQUAL 'S' ) */

            if ((AREA_DE_WORK.WTEM_MULTIMSG == "S"))
            {

                /*" -4934- MOVE TABJ-JDE (WS-IND) TO WS-JDE */
                _.Move(TABELA_MSG.TAB_MSG[AREA_DE_WORK.WS_IND].TABJ_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -4935- ELSE */
            }
            else
            {


                /*" -4936- PERFORM R2315-00-SELECT-V0MULTIMENS */

                R2315_00_SELECT_V0MULTIMENS_SECTION();

                /*" -4939- MOVE COBMENVG-JDE TO WS-JDE */
                _.Move(COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -4941- END-IF. */
            }


            /*" -4943- MOVE SPACES TO LC09-LINHA09 WS-LC09-JDE */
            _.Move("", AREA_DE_WORK.LC09_LINHA09, AREA_DE_WORK.WS_LC09_JDE);

            /*" -4948- STRING '(' FUNCTION LOWER-CASE(WS-JDE) DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LINHA09 */
            #region STRING
            var spl21 = "(" + AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower().Split(" ").FirstOrDefault() + ".DBM".ToString().ToLower() + ") STARTDBM";
            spl21 += "(";
            spl21 += AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower();
            spl21 += ".DBM".ToString().ToLower();
            spl21 += ") STARTDBM";
            _.Move(spl21, AREA_DE_WORK.LC09_LINHA09);
            #endregion

            /*" -4949- IF AC-LIDOS < 101 */

            if (AREA_DE_WORK.AC_LIDOS < 101)
            {

                /*" -4950- DISPLAY '==>ALTERA FORMULARIO<=======' */
                _.Display($"==>ALTERA FORMULARIO<=======");

                /*" -4954- DISPLAY 'COD-OPERACAO=' COBMENVG-COD-OPERACAO ' PRODUTO=' W88-PRODUTO-VIDA ' EMPRESA=' PRODUTO-COD-EMPRESA ' COBMENVG-JDE=' COBMENVG-JDE ' WS-JDE=' WS-JDE */

                $"COD-OPERACAO={COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO} PRODUTO={W88_PRODUTO_VIDA} EMPRESA={PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA} COBMENVG-JDE={COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE} WS-JDE={AREA_DE_WORK.WS_JDE_GER.WS_JDE}"
                .Display();

                /*" -4957- END-IF. */
            }


            /*" -4988- IF W88-PRODUTO-VIDA = 0917 OR 9304 OR 9307 OR 9309 OR 9310 OR JVPRD9310 OR 9312 OR 9314 OR JVPRD9314 OR 9318 OR 9319 OR 9320 OR JVPRD9320 OR 9321 OR JVPRD9321 OR 9327 OR JVPRD9327 OR 9328 OR JVPRD9328 OR 9332 OR JVPRD9332 OR 9333 OR 9334 OR JVPRD9334 OR 9351 OR JVPRD9351 OR 9352 OR JVPRD9352 OR 9353 OR JVPRD9353 OR 9356 OR JVPRD9356 OR 9357 OR JVPRD9357 OR 9358 OR JVPRD9358 OR 9359 OR JVPRD9359 OR 9360 OR JVPRD9360 OR 9361 OR JVPRD9361 OR 9701 OR 9702 OR 9703 OR 9704 OR 9705 OR 9707 */

            if (W88_PRODUTO_VIDA.In("0917", "9304", "9307", "9309", "9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString(), "9312", "9314", JVBKINCL.JV_PRODUTOS.JVPRD9314.ToString(), "9318", "9319", "9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), "9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), "9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9332", JVBKINCL.JV_PRODUTOS.JVPRD9332.ToString(), "9333", "9334", JVBKINCL.JV_PRODUTOS.JVPRD9334.ToString(), "9351", JVBKINCL.JV_PRODUTOS.JVPRD9351.ToString(), "9352", JVBKINCL.JV_PRODUTOS.JVPRD9352.ToString(), "9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9358", JVBKINCL.JV_PRODUTOS.JVPRD9358.ToString(), "9359", JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), "9360", JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString(), "9361", JVBKINCL.JV_PRODUTOS.JVPRD9361.ToString(), "9701", "9702", "9703", "9704", "9705", "9707"))
            {

                /*" -4989- IF COBMENVG-COD-OPERACAO EQUAL 2 */

                if (COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_COD_OPERACAO == 2)
                {

                    /*" -4990- MOVE 'VA54' TO WS-LC09-JDE */
                    _.Move("VA54", AREA_DE_WORK.WS_LC09_JDE);

                    /*" -4991- END-IF */
                }


                /*" -4992- ELSE */
            }
            else
            {


                /*" -4993- MOVE 'VA54' TO WS-LC09-JDE */
                _.Move("VA54", AREA_DE_WORK.WS_LC09_JDE);

                /*" -4995- END-IF. */
            }


            /*" -4996- IF WS-LC09-JDE = 'VA54' */

            if (AREA_DE_WORK.WS_LC09_JDE == "VA54")
            {

                /*" -4999- MOVE 'VA54' TO COBMENVG-JDE WS-JDE */
                _.Move("VA54", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                /*" -5000- IF WS-PROD-RUNON */

                if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                {

                    /*" -5002- MOVE 'VIDA10' TO COBMENVG-JDE WS-JDE */
                    _.Move("VIDA10", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE, AREA_DE_WORK.WS_JDE_GER.WS_JDE);

                    /*" -5003- END-IF */
                }


                /*" -5006- MOVE 'VA' TO COBMENVG-JDL */
                _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                /*" -5007- MOVE SPACES TO LC09-LINHA09 */
                _.Move("", AREA_DE_WORK.LC09_LINHA09);

                /*" -5011- STRING '(' FUNCTION LOWER-CASE(WS-JDE) DELIMITED BY ' ' FUNCTION LOWER-CASE( '.DBM' ) ') STARTDBM' DELIMITED BY SIZE INTO LC09-LINHA09 */
                #region STRING
                var spl22 = "(" + AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower().Split(" ").FirstOrDefault() + ".DBM".ToString().ToLower() + ") STARTDBM";
                spl22 += "(";
                spl22 += AREA_DE_WORK.WS_JDE_GER.WS_JDE.ToString().ToLower();
                spl22 += ".DBM".ToString().ToLower();
                spl22 += ") STARTDBM";
                _.Move(spl22, AREA_DE_WORK.LC09_LINHA09);
                #endregion

                /*" -5011- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-SECTION */
        private void R2315_00_SELECT_V0MULTIMENS_SECTION()
        {
            /*" -5022- MOVE '2315' TO WNR-EXEC-SQL */
            _.Move("2315", WABEND.WNR_EXEC_SQL);

            /*" -5024- MOVE WS-IDFORM TO COBMENVG-IDFORM. */
            _.Move(AREA_DE_WORK.WS_CHAVE_R.WS_IDFORM, COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_IDFORM);

            /*" -5035- PERFORM R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1 */

            R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1();

            /*" -5038- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -5039- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -5041- MOVE 'VA44' TO COBMENVG-JDE */
                    _.Move("VA44", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                    /*" -5042- IF WS-PROD-RUNON */

                    if (AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"])
                    {

                        /*" -5043- MOVE 'VIDA05' TO COBMENVG-JDE */
                        _.Move("VIDA05", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDE);

                        /*" -5044- END-IF */
                    }


                    /*" -5045- MOVE 'VA' TO COBMENVG-JDL */
                    _.Move("VA", COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_JDL);

                    /*" -5046- ELSE */
                }
                else
                {


                    /*" -5047- DISPLAY 'R2315 - NAO ENCONTRADO COBRANCA_MENS_VGAP ' */
                    _.Display($"R2315 - NAO ENCONTRADO COBRANCA_MENS_VGAP ");

                    /*" -5048- DISPLAY 'APOLICE     => ' COBMENVG-NUM-APOLICE */
                    _.Display($"APOLICE     => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_NUM_APOLICE}");

                    /*" -5049- DISPLAY 'SUBGRUPO    => ' COBMENVG-CODSUBES */
                    _.Display($"SUBGRUPO    => {COBMENVG.DCLCOBRANCA_MENS_VGAP.COBMENVG_CODSUBES}");

                    /*" -5050- DISPLAY 'OPERACAO    => ' WHOST-CODOPER */
                    _.Display($"OPERACAO    => {WHOST_CODOPER}");

                    /*" -5051- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5052- END-IF */
                }


                /*" -5052- END-IF. */
            }


        }

        [StopWatch]
        /*" R2315-00-SELECT-V0MULTIMENS-DB-SELECT-1 */
        public void R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1()
        {
            /*" -5035- EXEC SQL SELECT JDE, JDL INTO :COBMENVG-JDE, :COBMENVG-JDL FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = :COBMENVG-IDFORM AND NUM_APOLICE = :COBMENVG-NUM-APOLICE AND CODSUBES = :COBMENVG-CODSUBES AND COD_OPERACAO = :COBMENVG-COD-OPERACAO WITH UR END-EXEC. */

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
            /*" -5060- SET WS-IND-PROD TO 1 */
            JVBKINCL.WS_IND_PROD.Value = 1;

            /*" -5062- SEARCH CVPPROD AT END */
            void SearchAtEnd0()
            {

                /*" -5063- SET WS-PROD-RUNON TO TRUE */
                AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNON"] = true;

                /*" -5064- WHEN CVPPROD(WS-IND-PROD) EQUAL WS-COD-PRODUTO */
            };

            var mustSearchAtEnd0 = true;
            for (; JVBKINCL.WS_IND_PROD < JVBKINCL.CVP_PRODUTO.CVPPROD.Items.Count; JVBKINCL.WS_IND_PROD.Value++)
            {

                if (JVBKINCL.CVP_PRODUTO.CVPPROD[JVBKINCL.WS_IND_PROD] == WS_COD_PRODUTO)
                {

                    mustSearchAtEnd0 = false;

                    /*" -5065- SET WS-PROD-RUNOFF TO TRUE */
                    AREA_DE_WORK.WS_SIT_PRODUTO["WS_PROD_RUNOFF"] = true;

                    /*" -5067- END-SEARCH */

                    /*" -5067- END-SEARCH. */
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
            /*" -5078- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WABEND.WNR_EXEC_SQL);

            /*" -5079- MOVE 'N' TO WFIM-BENEFICIA. */
            _.Move("N", AREA_DE_WORK.WFIM_BENEFICIA);

            /*" -5081- MOVE ZEROS TO WIND-99. */
            _.Move(0, AREA_DE_WORK.WIND_99);

            /*" -5091- PERFORM R2400_00_BENEFICIARIOS_DB_DECLARE_1 */

            R2400_00_BENEFICIARIOS_DB_DECLARE_1();

            /*" -5094- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5095- DISPLAY 'VA3437B - ERRO DECLARE CURSOR V0BENEF' */
                _.Display($"VA3437B - ERRO DECLARE CURSOR V0BENEF");

                /*" -5096- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -5098- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5098- PERFORM R2400_00_BENEFICIARIOS_DB_OPEN_1 */

            R2400_00_BENEFICIARIOS_DB_OPEN_1();

            /*" -5101- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5102- DISPLAY 'VA3437B - ERRO OPEN CURSOR V0BENEF' */
                _.Display($"VA3437B - ERRO OPEN CURSOR V0BENEF");

                /*" -5103- DISPLAY 'SQLCODE = ' SQLCODE */
                _.Display($"SQLCODE = {DB.SQLCODE}");

                /*" -5105- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5106- PERFORM R2410-00-FETCH-V0BENEF UNTIL WFIM-BENEFICIA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_BENEFICIA == "S"))
            {

                R2410_00_FETCH_V0BENEF_SECTION();
            }

        }

        [StopWatch]
        /*" R2400-00-BENEFICIARIOS-DB-OPEN-1 */
        public void R2400_00_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -5098- EXEC SQL OPEN V0BENEF END-EXEC. */

            V0BENEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-SECTION */
        private void R2410_00_FETCH_V0BENEF_SECTION()
        {
            /*" -5118- MOVE '2410' TO WNR-EXEC-SQL. */
            _.Move("2410", WABEND.WNR_EXEC_SQL);

            /*" -5123- PERFORM R2410_00_FETCH_V0BENEF_DB_FETCH_1 */

            R2410_00_FETCH_V0BENEF_DB_FETCH_1();

            /*" -5126- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5127- MOVE 'S' TO WFIM-BENEFICIA */
                _.Move("S", AREA_DE_WORK.WFIM_BENEFICIA);

                /*" -5127- PERFORM R2410_00_FETCH_V0BENEF_DB_CLOSE_1 */

                R2410_00_FETCH_V0BENEF_DB_CLOSE_1();

                /*" -5129- MOVE 'HERDEIROS LEGAIS' TO LC11-NOME-BENEF(1) */
                _.Move("HERDEIROS LEGAIS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_NOME_BENEF);

                /*" -5130- MOVE 'OUTROS' TO LC11-PARENTESCO(1) */
                _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARENTESCO);

                /*" -5131- MOVE 100 TO LC11-PARTICIP (1) */
                _.Move(100, AREA_DE_WORK.LC11_LINHA11.LC11_BENEFICIARIOS.LC11_BENEF_OCC[1].LC11_PARTICIP);

                /*" -5133- GO TO R2410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5135- ADD 1 TO WIND-99. */
            AREA_DE_WORK.WIND_99.Value = AREA_DE_WORK.WIND_99 + 1;

            /*" -5137- MOVE BENEFICI-NOME-BENEFICIARIO TO TB99-NOME-BENEF (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_NOME_BENEF);

            /*" -5139- MOVE BENEFICI-GRAU-PARENTESCO TO TB99-PARENTESCO (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_PARENTESCO);

            /*" -5140- MOVE BENEFICI-PCT-PART-BENEFICIA TO TB99-PARTICIP (WIND-99). */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, TB99.TB99_CONT[AREA_DE_WORK.WIND_99].TB99_PARTICIP);

        }

        [StopWatch]
        /*" R2410-00-FETCH-V0BENEF-DB-FETCH-1 */
        public void R2410_00_FETCH_V0BENEF_DB_FETCH_1()
        {
            /*" -5123- EXEC SQL FETCH V0BENEF INTO :BENEFICI-NOME-BENEFICIARIO, :BENEFICI-GRAU-PARENTESCO, :BENEFICI-PCT-PART-BENEFICIA END-EXEC. */

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
            /*" -5127- EXEC SQL CLOSE V0BENEF END-EXEC */

            V0BENEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-SECTION */
        private void R2500_00_UPDATE_RELATORI_SECTION()
        {
            /*" -5152- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -5161- PERFORM R2500_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2500_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -5164- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -5164- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2500_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -5161- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_RELATORIO = :WHOST-CODRELAT AND SIT_REGISTRO = '0' AND COD_OPERACAO IN (2,6,10) AND NUM_PARCELA = 2 AND NUM_CERTIFICADO = :WHOST-NRCERTIF END-EXEC. */

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
            /*" -5176- MOVE '2650' TO WNR-EXEC-SQL */
            _.Move("2650", WABEND.WNR_EXEC_SQL);

            /*" -5177- IF SVA-FONTE EQUAL 10 */

            if (REG_SVA3437B.SVA_FONTE == 10)
            {

                /*" -5178- MOVE 'MATRIZ' TO LC11-REMETENTE-G */
                _.Move("MATRIZ", AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G);

                /*" -5179- ELSE */
            }
            else
            {


                /*" -5180- MOVE 'FILIAL' TO LC11-REMETENTE-S */
                _.Move("FILIAL", AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G.LC11_REMETENTE_S);

                /*" -5183- MOVE TAB-NOMEFTE (SVA-FONTE) TO LC11-REMETENTE. */
                _.Move(TAB_FILIAL.FILLER_104[REG_SVA3437B.SVA_FONTE].TAB_NOMEFTE, AREA_DE_WORK.LC11_LINHA11.LC11_REMETENTE_G.LC11_REMETENTE);
            }


            /*" -5185- MOVE TAB-ENDERFTE(SVA-FONTE) TO LC11-ENDERECO-REM */
            _.Move(TAB_FILIAL.FILLER_104[REG_SVA3437B.SVA_FONTE].TAB_ENDERFTE, AREA_DE_WORK.LC11_LINHA11.LC11_ENDERECO_REM);

            /*" -5187- MOVE TAB-BAIRRO (SVA-FONTE) TO LC11-BAIRRO-REM */
            _.Move(TAB_FILIAL.FILLER_104[REG_SVA3437B.SVA_FONTE].TAB_BAIRRO, AREA_DE_WORK.LC11_LINHA11.LC11_BAIRRO_REM);

            /*" -5189- MOVE TAB-CIDADE (SVA-FONTE) TO LC11-CIDADE-REM */
            _.Move(TAB_FILIAL.FILLER_104[REG_SVA3437B.SVA_FONTE].TAB_CIDADE, AREA_DE_WORK.LC11_LINHA11.LC11_CIDADE_REM);

            /*" -5191- MOVE TAB-UF (SVA-FONTE) TO LC11-UF-REM */
            _.Move(TAB_FILIAL.FILLER_104[REG_SVA3437B.SVA_FONTE].TAB_UF, AREA_DE_WORK.LC11_LINHA11.LC11_UF_REM);

            /*" -5193- MOVE TAB-CEP (SVA-FONTE) TO DEST-NUM-CEP */
            _.Move(TAB_FILIAL.FILLER_104[REG_SVA3437B.SVA_FONTE].TAB_CEP, AREA_DE_WORK.DEST_NUM_CEP);

            /*" -5194- MOVE DEST-CEP TO LC11-CEP-REM */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_REM);

            /*" -5194- MOVE DEST-CEP-COMPL TO LC11-CEP-COMPL-REM. */
            _.Move(AREA_DE_WORK.DEST_NUM_CEP.DEST_CEP_COMPL, AREA_DE_WORK.LC11_LINHA11.LC11_CEP_COMPL_REM);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2650_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-PRODUVG-SECTION */
        private void R2700_00_SELECT_PRODUVG_SECTION()
        {
            /*" -5206- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -5215- PERFORM R2700_00_SELECT_PRODUVG_DB_SELECT_1 */

            R2700_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -5218- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5219- DISPLAY 'R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ' */
                _.Display($"R2700 - PROBLEMAS NO ACESSO A PRODUTOS_VG ");

                /*" -5221- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                .Display();

                /*" -5221- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R2700_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -5215- EXEC SQL SELECT NOME_PRODUTO, COD_PRODUTO INTO :PRODUVG-NOME-PRODUTO, :PRODUVG-COD-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES WITH UR END-EXEC. */

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
            /*" -5233- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", WABEND.WNR_EXEC_SQL);

            /*" -5241- PERFORM R2710_00_SELECT_ESTIP_DB_SELECT_1 */

            R2710_00_SELECT_ESTIP_DB_SELECT_1();

            /*" -5244- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5245- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5246- MOVE SPACES TO CLIENTES-NOME-RAZAO */
                    _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                    /*" -5247- ELSE */
                }
                else
                {


                    /*" -5248- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A CLIENTES ' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A CLIENTES ");

                    /*" -5250- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -5250- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2710-00-SELECT-ESTIP-DB-SELECT-1 */
        public void R2710_00_SELECT_ESTIP_DB_SELECT_1()
        {
            /*" -5241- EXEC SQL SELECT B.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.APOLICES A, SEGUROS.CLIENTES B WHERE A.NUM_APOLICE = :WHOST-NRAPOLICE AND B.COD_CLIENTE = A.COD_CLIENTE WITH UR END-EXEC. */

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
            /*" -5262- MOVE '2715' TO WNR-EXEC-SQL. */
            _.Move("2715", WABEND.WNR_EXEC_SQL);

            /*" -5269- PERFORM R2715_00_SELECT_SUBESTIP_DB_SELECT_1 */

            R2715_00_SELECT_SUBESTIP_DB_SELECT_1();

            /*" -5272- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5273- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5274- MOVE SPACES TO SUBGVGAP-OPCAO-CONJUGE */
                    _.Move("", SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);

                    /*" -5275- ELSE */
                }
                else
                {


                    /*" -5276- DISPLAY 'R2710 - PROBLEMAS NO ACESSO A SUBGVGAP    ' */
                    _.Display($"R2710 - PROBLEMAS NO ACESSO A SUBGVGAP    ");

                    /*" -5278- DISPLAY 'NUM_APOLICE - ' WHOST-NRAPOLICE ' ' 'COD_SUBGRUPO- ' WHOST-CODSUBES */

                    $"NUM_APOLICE - {WHOST_NRAPOLICE} COD_SUBGRUPO- {WHOST_CODSUBES}"
                    .Display();

                    /*" -5280- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5281- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '1' */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "1")
            {

                /*" -5282- MOVE 'OPCIONAL' TO LC11-OPCAO-CONJ */
                _.Move("OPCIONAL", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                /*" -5283- ELSE */
            }
            else
            {


                /*" -5284- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '2' */

                if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "2")
                {

                    /*" -5285- MOVE 'OBRIGATORIO' TO LC11-OPCAO-CONJ */
                    _.Move("OBRIGATORIO", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                    /*" -5286- ELSE */
                }
                else
                {


                    /*" -5287- IF SUBGVGAP-OPCAO-CONJUGE EQUAL '3' */

                    if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE == "3")
                    {

                        /*" -5288- MOVE 'SEM CONJUGE' TO LC11-OPCAO-CONJ */
                        _.Move("SEM CONJUGE", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);

                        /*" -5289- ELSE */
                    }
                    else
                    {


                        /*" -5289- MOVE 'OUTROS' TO LC11-OPCAO-CONJ. */
                        _.Move("OUTROS", AREA_DE_WORK.LC11_LINHA11.LC11_OPCAO_CONJ);
                    }

                }

            }


        }

        [StopWatch]
        /*" R2715-00-SELECT-SUBESTIP-DB-SELECT-1 */
        public void R2715_00_SELECT_SUBESTIP_DB_SELECT_1()
        {
            /*" -5269- EXEC SQL SELECT OPCAO_CONJUGE INTO :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :WHOST-NRAPOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES WITH UR END-EXEC. */

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
            /*" -5301- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", WABEND.WNR_EXEC_SQL);

            /*" -5303- MOVE 'S' TO WTEM-HISCOBPR. */
            _.Move("S", AREA_DE_WORK.WTEM_HISCOBPR);

            /*" -5313- PERFORM R2750_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R2750_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -5316- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5317- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5318- MOVE 'N' TO WTEM-HISCOBPR */
                    _.Move("N", AREA_DE_WORK.WTEM_HISCOBPR);

                    /*" -5320- MOVE ZEROS TO HISCOBPR-QTMDIT VIND-QTMDIT */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT, VIND_QTMDIT);

                    /*" -5321- ELSE */
                }
                else
                {


                    /*" -5323- DISPLAY '*** VA3437B PROBLEMAS ACESSO HIS_COBER_PROPOST' WHOST-NRCERTIF */
                    _.Display($"*** VA3437B PROBLEMAS ACESSO HIS_COBER_PROPOST{WHOST_NRCERTIF}");

                    /*" -5325- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5326- IF VIND-QTMDIT LESS ZEROES */

            if (VIND_QTMDIT < 00)
            {

                /*" -5326- MOVE ZEROES TO HISCOBPR-QTMDIT. */
                _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_QTMDIT);
            }


        }

        [StopWatch]
        /*" R2750-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R2750_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -5313- EXEC SQL SELECT QTMDIT INTO :HISCOBPR-QTMDIT:VIND-QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND DATA_INIVIGENCIA <= CURRENT DATE AND DATA_TERVIGENCIA >= CURRENT DATE WITH UR END-EXEC. */

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
            /*" -5338- MOVE '2760' TO WNR-EXEC-SQL. */
            _.Move("2760", WABEND.WNR_EXEC_SQL);

            /*" -5348- PERFORM R2760_00_SELECT_PRODUTO_DB_SELECT_1 */

            R2760_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -5351- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5352- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5353- MOVE SPACES TO PRODUTO-NUM-PROCESSO-SUSEP */
                    _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_NUM_PROCESSO_SUSEP);

                    /*" -5354- ELSE */
                }
                else
                {


                    /*" -5356- DISPLAY '*** VA3437B PROBLEMAS ACESSO A PRODUTO ' WHOST-NRCERTIF ' ' */

                    $"*** VA3437B PROBLEMAS ACESSO A PRODUTO {WHOST_NRCERTIF} "
                    .Display();

                    /*" -5357- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2760-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R2760_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -5348- EXEC SQL SELECT DESCR_PRODUTO, COD_PRODUTO, NUM_PROCESSO_SUSEP INTO :PRODUTO-DESCR-PRODUTO, :PRODUTO-COD-PRODUTO, :PRODUTO-NUM-PROCESSO-SUSEP FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :PRODUVG-COD-PRODUTO WITH UR END-EXEC. */

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
            /*" -5368- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -5381- PERFORM R2800_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R2800_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -5384- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5385- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5387- DISPLAY '*** VA3437B DESPREZADO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VA3437B DESPREZADO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -5388- ELSE */
                }
                else
                {


                    /*" -5390- DISPLAY '*** VA3437B PROBLEMAS ACESSO SEGURADOS_VGAP ' WHOST-NRCERTIF */
                    _.Display($"*** VA3437B PROBLEMAS ACESSO SEGURADOS_VGAP {WHOST_NRCERTIF}");

                    /*" -5390- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R2800_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -5381- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

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
            /*" -5402- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WABEND.WNR_EXEC_SQL);

            /*" -5410- PERFORM R2910_00_OBTEM_NUMERACAO_DB_SELECT_1 */

            R2910_00_OBTEM_NUMERACAO_DB_SELECT_1();

            /*" -5413- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5414- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5416- MOVE ZEROS TO RELATORI-NUM-COPIAS */
                    _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

                    /*" -5417- ELSE */
                }
                else
                {


                    /*" -5418- DISPLAY 'R2910 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R2910 - PROBLEMAS SELECT RELATORIOS");

                    /*" -5420- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5421- IF VIND-NRCOPIAS LESS ZEROS */

            if (VIND_NRCOPIAS < 00)
            {

                /*" -5422- MOVE ZEROS TO RELATORI-NUM-COPIAS. */
                _.Move(0, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R2910_10_INCLUI_RELATORIO */

            R2910_10_INCLUI_RELATORIO();

        }

        [StopWatch]
        /*" R2910-00-OBTEM-NUMERACAO-DB-SELECT-1 */
        public void R2910_00_OBTEM_NUMERACAO_DB_SELECT_1()
        {
            /*" -5410- EXEC SQL SELECT MAX(NUM_COPIAS) INTO :RELATORI-NUM-COPIAS:VIND-NRCOPIAS FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CARTAECT' AND MES_REFERENCIA = :V1SIST-MESREFER AND ANO_REFERENCIA = :V1SIST-ANOREFER WITH UR END-EXEC. */

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
            /*" -5429- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", WABEND.WNR_EXEC_SQL);

            /*" -5432- ADD 1 TO RELATORI-NUM-COPIAS. */
            RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.Value = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS + 1;

            /*" -5475- PERFORM R2910_10_INCLUI_RELATORIO_DB_INSERT_1 */

            R2910_10_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -5478- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -5479- DISPLAY 'R2910 - (REGISTRO DUPLICADO) ... ' */
                _.Display($"R2910 - (REGISTRO DUPLICADO) ... ");

                /*" -5481- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5482- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5483- DISPLAY 'R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R2910 - (PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -5485- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5485- ADD 1 TO AC-I-RELATORI. */
            AREA_DE_WORK.AC_I_RELATORI.Value = AREA_DE_WORK.AC_I_RELATORI + 1;

        }

        [StopWatch]
        /*" R2910-10-INCLUI-RELATORIO-DB-INSERT-1 */
        public void R2910_10_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -5475- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'EM0600B' , :SISTEMAS-DATA-MOV-ABERTO, 'EM' , 'CARTAECT' , :RELATORI-NUM-COPIAS, 0, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOV-ABERTO, :V1SIST-MESREFER, :V1SIST-ANOREFER, 0, 0, 0, 0, 0, 0, :WHOST-NRAPOLICE, 0, 0, 0, 0, :WHOST-CODSUBES, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -5497- MOVE '2920' TO WNR-EXEC-SQL. */
            _.Move("2920", WABEND.WNR_EXEC_SQL);

            /*" -5498- MOVE LK-DATA-CALC TO LK-DATA-SOM. */
            _.Move(AREA_DE_WORK.LK_PROSOMU1.LK_DATA_CALC, AREA_DE_WORK.LK_PROSOMU1.LK_DATA_SOM);

            /*" -5499- MOVE 3 TO LK-QTDIAS. */
            _.Move(3, AREA_DE_WORK.LK_PROSOMU1.LK_QTDIAS);

            /*" -5499- CALL 'PROSOCU1' USING LK-PROSOMU1. */
            _.Call("PROSOCU1", AREA_DE_WORK.LK_PROSOMU1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-VERIF-SEGURA-PRECO-SECTION */
        private void R3000_00_VERIF_SEGURA_PRECO_SECTION()
        {
            /*" -5516- IF SVA-DTQUIT LESS '2012-11-26' */

            if (REG_SVA3437B.SVA_DTQUIT < "2012-11-26")
            {

                /*" -5517- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -5525- END-IF. */
            }


            /*" -5527- IF SISTEMAS-DATA-MOV-ABERTO LESS '2019-09-26' */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < "2019-09-26")
            {

                /*" -5528- CONTINUE */

                /*" -5529- ELSE */
            }
            else
            {


                /*" -5540- IF SVA-PRODUTO EQUAL 9327 OR JVPRD9327 OR 9328 OR JVPRD9328 OR 9356 OR JVPRD9356 OR 9357 OR JVPRD9357 OR 9320 OR JVPRD9320 OR 9321 OR JVPRD9321 OR 9359 OR JVPRD9359 OR 9360 OR JVPRD9360 */

                if (REG_SVA3437B.SVA_PRODUTO.In("9327", JVBKINCL.JV_PRODUTOS.JVPRD9327.ToString(), "9328", JVBKINCL.JV_PRODUTOS.JVPRD9328.ToString(), "9356", JVBKINCL.JV_PRODUTOS.JVPRD9356.ToString(), "9357", JVBKINCL.JV_PRODUTOS.JVPRD9357.ToString(), "9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString(), "9321", JVBKINCL.JV_PRODUTOS.JVPRD9321.ToString(), "9359", JVBKINCL.JV_PRODUTOS.JVPRD9359.ToString(), "9360", JVBKINCL.JV_PRODUTOS.JVPRD9360.ToString()))
                {

                    /*" -5541- GO TO R3000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                    return;

                    /*" -5542- END-IF */
                }


                /*" -5546- END-IF. */
            }


            /*" -5548- IF (SVA-PRODUTO EQUAL 9353 OR JVPRD9353) AND SVA-DTQUIT GREATER '2018-09-30' */

            if ((REG_SVA3437B.SVA_PRODUTO.In("9353", JVBKINCL.JV_PRODUTOS.JVPRD9353.ToString())) && REG_SVA3437B.SVA_DTQUIT > "2018-09-30")
            {

                /*" -5549- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -5553- END-IF. */
            }


            /*" -5554- IF SVA-PRODUTO EQUAL 9310 OR JVPRD9310 */

            if (REG_SVA3437B.SVA_PRODUTO.In("9310", JVBKINCL.JV_PRODUTOS.JVPRD9310.ToString()))
            {

                /*" -5555- MOVE 'S' TO WS-TEM-SEGPRECO */
                _.Move("S", WS_TEM_SEGPRECO);

                /*" -5556- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -5559- END-IF. */
            }


            /*" -5569- IF (SVA-NRAPOLICE EQUAL 109300000680 AND (SVA-CODSUBES EQUAL 1 OR 2)) OR (SVA-NRAPOLICE EQUAL 109300001553 AND SVA-CODSUBES EQUAL 1 ) OR (SVA-NRAPOLICE EQUAL 109300001553 AND SVA-CODSUBES EQUAL 2 ) */

            if ((REG_SVA3437B.SVA_NRAPOLICE == 109300000680 && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || (REG_SVA3437B.SVA_NRAPOLICE == 109300001553 && REG_SVA3437B.SVA_CODSUBES == 1) || (REG_SVA3437B.SVA_NRAPOLICE == 109300001553 && REG_SVA3437B.SVA_CODSUBES == 2))
            {

                /*" -5570- MOVE 'S' TO WS-TEM-SEGPRECO */
                _.Move("S", WS_TEM_SEGPRECO);

                /*" -5571- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -5577- END-IF. */
            }


            /*" -5650- IF (SVA-NRAPOLICE EQUAL 109300002001 AND (SVA-CODSUBES EQUAL 1 OR 2)) OR ((SVA-NRAPOLICE EQUAL 109300002002 OR 3009300002002 OR 3009300012002) AND (SVA-CODSUBES EQUAL 3 OR 4)) OR ((SVA-NRAPOLICE EQUAL 109300002002 OR 3009300002002 OR 3009300012002) AND (SVA-CODSUBES EQUAL 1 OR 2)) OR (SVA-NRAPOLICE EQUAL 109300001966 AND (SVA-CODSUBES EQUAL 1 OR 2)) OR ((SVA-NRAPOLICE EQUAL 109300001970 OR 3009300001970 OR 3009300011970) AND (SVA-CODSUBES EQUAL 3 OR 4)) OR ((SVA-NRAPOLICE EQUAL 109300001970 OR 3009300001970 OR 3009300011970) AND (SVA-CODSUBES EQUAL 1 OR 2)) OR (SVA-NRAPOLICE EQUAL 109300002004 AND (SVA-CODSUBES EQUAL 1 OR 2)) OR ((SVA-NRAPOLICE EQUAL 109300002005 OR 3009300002005 OR 3009300012005) AND (SVA-CODSUBES EQUAL 3 OR 4)) OR (SVA-NRAPOLICE EQUAL 109300002007 AND (SVA-CODSUBES EQUAL 1 OR 2)) OR ((SVA-NRAPOLICE EQUAL 109300002008 OR 3009300002008 OR 3009300012008) AND (SVA-CODSUBES EQUAL 3 OR 4)) OR ((SVA-NRAPOLICE EQUAL 109300002008 OR 3009300002008 OR 3009300012008) AND (SVA-CODSUBES EQUAL 1 OR 2)) OR (SVA-NRAPOLICE EQUAL 109300001976 AND (SVA-CODSUBES EQUAL 1 OR 2)) OR ((SVA-NRAPOLICE EQUAL 109300001977 OR 3009300001977 OR 3009300011977) AND (SVA-CODSUBES EQUAL 1 OR 2)) OR ((SVA-NRAPOLICE EQUAL 109300001977 OR 3009300001977 OR 3009300011977) AND (SVA-CODSUBES EQUAL 3 OR 4)) */

            if ((REG_SVA3437B.SVA_NRAPOLICE == 109300002001 && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300002002", "3009300002002", "3009300012002")) && (REG_SVA3437B.SVA_CODSUBES.In("3", "4"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300002002", "3009300002002", "3009300012002")) && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || (REG_SVA3437B.SVA_NRAPOLICE == 109300001966 && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300001970", "3009300001970", "3009300011970")) && (REG_SVA3437B.SVA_CODSUBES.In("3", "4"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300001970", "3009300001970", "3009300011970")) && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || (REG_SVA3437B.SVA_NRAPOLICE == 109300002004 && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300002005", "3009300002005", "3009300012005")) && (REG_SVA3437B.SVA_CODSUBES.In("3", "4"))) || (REG_SVA3437B.SVA_NRAPOLICE == 109300002007 && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300002008", "3009300002008", "3009300012008")) && (REG_SVA3437B.SVA_CODSUBES.In("3", "4"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300002008", "3009300002008", "3009300012008")) && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || (REG_SVA3437B.SVA_NRAPOLICE == 109300001976 && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300001977", "3009300001977", "3009300011977")) && (REG_SVA3437B.SVA_CODSUBES.In("1", "2"))) || ((REG_SVA3437B.SVA_NRAPOLICE.In("109300001977", "3009300001977", "3009300011977")) && (REG_SVA3437B.SVA_CODSUBES.In("3", "4"))))
            {

                /*" -5652- PERFORM R3100-00-BUSCA-PROFISSAO */

                R3100_00_BUSCA_PROFISSAO_SECTION();

                /*" -5657- EVALUATE WS-COD-CBO */
                switch (WS_COD_CBO.Value)
                {

                    /*" -5658- WHEN    004 */
                    case 004:

                        /*" -5659- WHEN    009 */
                        break;
                    case 009:

                    /*" -5660- WHEN    128 */
                    case 128:

                        /*" -5661- WHEN    134 */
                        break;
                    case 134:

                    /*" -5662- WHEN    135 */
                    case 135:

                        /*" -5663- WHEN    142 */
                        break;
                    case 142:

                    /*" -5664- WHEN    143 */
                    case 143:

                        /*" -5665- WHEN    294 */
                        break;
                    case 294:

                    /*" -5666- WHEN    995 */
                    case 995:

                        /*" -5667- WHEN 187753 */
                        break;
                    case 187753:

                    /*" -5668- WHEN 531800 */
                    case 531800:

                        /*" -5669- IF SISTEMAS-DATA-MOV-ABERTO LESS '2018-10-01' */

                        if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < "2018-10-01")
                        {

                            /*" -5670- MOVE 'S' TO WS-TEM-SEGPRECO */
                            _.Move("S", WS_TEM_SEGPRECO);

                            /*" -5675- END-IF */
                        }


                        /*" -5676- WHEN    201 */
                        break;
                    case 201:

                    /*" -5677- WHEN    203 */
                    case 203:

                        /*" -5678- WHEN    205 */
                        break;
                    case 205:

                    /*" -5679- WHEN    211 */
                    case 211:

                        /*" -5680- WHEN    212 */
                        break;
                    case 212:

                    /*" -5681- WHEN    213 */
                    case 213:

                        /*" -5682- WHEN    214 */
                        break;
                    case 214:

                    /*" -5683- WHEN    293 */
                    case 293:

                        /*" -5684- WHEN    295 */
                        break;
                    case 295:

                    /*" -5685- WHEN    296 */
                    case 296:

                        /*" -5686- WHEN    297 */
                        break;
                    case 297:

                    /*" -5687- WHEN    298 */
                    case 298:

                        /*" -5688- WHEN    395 */
                        break;
                    case 395:

                    /*" -5689- WHEN    921 */
                    case 921:

                        /*" -5690- WHEN    922 */
                        break;
                    case 922:

                    /*" -5691- WHEN    981 */
                    case 981:

                        /*" -5692- WHEN    982 */
                        break;
                    case 982:

                    /*" -5693- WHEN    994 */
                    case 994:

                        /*" -5694- WHEN    131 */
                        break;
                    case 131:

                    /*" -5695- WHEN 518729 */
                    case 518729:

                        /*" -5696- MOVE 'S' TO WS-TEM-SEGPRECO */
                        _.Move("S", WS_TEM_SEGPRECO);

                        /*" -5697- END-EVALUATE */
                        break;
                }


                /*" -5697- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-BUSCA-PROFISSAO-SECTION */
        private void R3100_00_BUSCA_PROFISSAO_SECTION()
        {
            /*" -5707- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -5715- PERFORM R3100_00_BUSCA_PROFISSAO_DB_SELECT_1 */

            R3100_00_BUSCA_PROFISSAO_DB_SELECT_1();

            /*" -5718- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5719- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5720- PERFORM R3200-00-BUSCA-PF-CBO */

                    R3200_00_BUSCA_PF_CBO_SECTION();

                    /*" -5721- ELSE */
                }
                else
                {


                    /*" -5723- DISPLAY 'R3100 - ERRO SELECT BUSCA PROFISSAO ' SVA-NRCERTIF */
                    _.Display($"R3100 - ERRO SELECT BUSCA PROFISSAO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -5724- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5725- END-IF */
                }


                /*" -5725- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-BUSCA-PROFISSAO-DB-SELECT-1 */
        public void R3100_00_BUSCA_PROFISSAO_DB_SELECT_1()
        {
            /*" -5715- EXEC SQL SELECT B.COD_CBO INTO :WS-COD-CBO FROM SEGUROS.PROPOSTA_FIDELIZ A ,SEGUROS.PESSOA_FISICA B WHERE A.NUM_PROPOSTA_SIVPF = :WHOST-NRCERTIF AND B.COD_PESSOA = A.COD_PESSOA WITH UR END-EXEC. */

            var r3100_00_BUSCA_PROFISSAO_DB_SELECT_1_Query1 = new R3100_00_BUSCA_PROFISSAO_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R3100_00_BUSCA_PROFISSAO_DB_SELECT_1_Query1.Execute(r3100_00_BUSCA_PROFISSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_CBO, WS_COD_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-BUSCA-PF-CBO-SECTION */
        private void R3200_00_BUSCA_PF_CBO_SECTION()
        {
            /*" -5735- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -5741- PERFORM R3200_00_BUSCA_PF_CBO_DB_SELECT_1 */

            R3200_00_BUSCA_PF_CBO_DB_SELECT_1();

            /*" -5744- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5745- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5746- MOVE ZEROS TO WS-COD-CBO */
                    _.Move(0, WS_COD_CBO);

                    /*" -5747- ELSE */
                }
                else
                {


                    /*" -5749- DISPLAY 'R3200 - ERRO SELECT PF_CBO ' SVA-NRCERTIF */
                    _.Display($"R3200 - ERRO SELECT PF_CBO {REG_SVA3437B.SVA_NRCERTIF}");

                    /*" -5750- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5751- END-IF */
                }


                /*" -5751- END-IF. */
            }


        }

        [StopWatch]
        /*" R3200-00-BUSCA-PF-CBO-DB-SELECT-1 */
        public void R3200_00_BUSCA_PF_CBO_DB_SELECT_1()
        {
            /*" -5741- EXEC SQL SELECT COD_CBO INTO :WS-COD-CBO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :WHOST-NRCERTIF WITH UR END-EXEC. */

            var r3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1 = new R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1()
            {
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1.Execute(r3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_CBO, WS_COD_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-BUSCA-NOM-SOCIAL-SECTION */
        private void R4000_00_BUSCA_NOM_SOCIAL_SECTION()
        {
            /*" -5762- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WABEND.WNR_EXEC_SQL);

            /*" -5784- INITIALIZE LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
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

            /*" -5785- MOVE 'N' TO LK-GE053-E-TRACE */
            _.Move("N", SPGE053W.LK_GE053_E_TRACE);

            /*" -5786- MOVE 'VA' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("VA", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -5787- MOVE 2 TO LK-GE053-E-IND-OPERACAO */
            _.Move(2, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -5789- MOVE SVA-CPF TO LK-GE053-I-NUM-CPF */
            _.Move(REG_SVA3437B.SVA_CPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -5811- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE */
            _.Call("SPBGE053", SPGE053W);

            /*" -5813- . */

            /*" -5814- MOVE LK-GE053-SQLCODE TO WS-RETURN-CODE. */
            _.Move(SPGE053W.LK_GE053_SQLCODE, WS_RETURN_CODE);

            /*" -5816- MOVE WS-RETURN-CODE TO WS-RETURN-CODE-M. */
            _.Move(WS_RETURN_CODE, WS_RETURN_CODE_M);

            /*" -5818- IF (LK-GE053-SQLCODE NOT EQUAL ZEROS) AND (LK-GE053-SQLCODE NOT EQUAL 100) */

            if ((SPGE053W.LK_GE053_SQLCODE != 00) && (SPGE053W.LK_GE053_SQLCODE != 100))
            {

                /*" -5819- DISPLAY 'ERRO SUBROTINA SPBGE053' */
                _.Display($"ERRO SUBROTINA SPBGE053");

                /*" -5820- DISPLAY 'LK-GE053-MENSAGEM      ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM      {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -5821- DISPLAY 'LK-GE053-SQLCODE       ' LK-GE053-SQLCODE */
                _.Display($"LK-GE053-SQLCODE       {SPGE053W.LK_GE053_SQLCODE}");

                /*" -5822- DISPLAY 'LK-GE053-E-IDE-SISTEMA ' LK-GE053-E-TRACE */
                _.Display($"LK-GE053-E-IDE-SISTEMA {SPGE053W.LK_GE053_E_TRACE}");

                /*" -5823- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IDE-SISTEMA */
                _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

                /*" -5824- DISPLAY 'LK-GE053-E-TRACE       ' LK-GE053-E-IND-OPERACAO */
                _.Display($"LK-GE053-E-TRACE       {SPGE053W.LK_GE053_E_IND_OPERACAO}");

                /*" -5825- DISPLAY 'LK-GE053-I-NUM-CPF     ' LK-GE053-I-NUM-CPF */
                _.Display($"LK-GE053-I-NUM-CPF     {SPGE053W.LK_GE053_I_NUM_CPF}");

                /*" -5826- DISPLAY 'ERRO INESPERADO SUBROTINA SPBGE053' */
                _.Display($"ERRO INESPERADO SUBROTINA SPBGE053");

                /*" -5827- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -5829- END-IF */
            }


            /*" -5830- IF LK-GE053-I-NOM-SOCIAL NOT EQUAL SPACES */

            if (!SPGE053W.LK_GE053_I_NOM_SOCIAL.IsEmpty())
            {

                /*" -5831- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-NOME-RAZAO-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC);

                /*" -5832- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-NOME-RAZAO-END-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END_SOC);

                /*" -5833- MOVE LK-GE053-I-NOM-SOCIAL TO LC11-CLIENTE-SOC */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

                /*" -5834- ELSE */
            }
            else
            {


                /*" -5835- MOVE SPACES TO LC11-NOME-RAZAO-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_SOC);

                /*" -5836- MOVE SPACES TO LC11-NOME-RAZAO-END-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_NOME_RAZAO_END_SOC);

                /*" -5837- MOVE SPACES TO LC11-CLIENTE-SOC */
                _.Move("", AREA_DE_WORK.LC11_LINHA11.LC11_CLIENTE_SOC);

                /*" -5839- END-IF */
            }


            /*" -5840- DISPLAY 'LK-GE053-E-TRACE        ' LK-GE053-E-TRACE */
            _.Display($"LK-GE053-E-TRACE        {SPGE053W.LK_GE053_E_TRACE}");

            /*" -5841- DISPLAY 'LK-GE053-E-IDE-SISTEMA  ' LK-GE053-E-IDE-SISTEMA */
            _.Display($"LK-GE053-E-IDE-SISTEMA  {SPGE053W.LK_GE053_E_IDE_SISTEMA}");

            /*" -5842- DISPLAY 'LK-GE053-E-IND-OPERACAO ' LK-GE053-E-IND-OPERACAO */
            _.Display($"LK-GE053-E-IND-OPERACAO {SPGE053W.LK_GE053_E_IND_OPERACAO}");

            /*" -5843- DISPLAY 'LK-GE053-I-NUM-CPF      ' LK-GE053-I-NUM-CPF */
            _.Display($"LK-GE053-I-NUM-CPF      {SPGE053W.LK_GE053_I_NUM_CPF}");

            /*" -5844- DISPLAY 'LK-GE053-I-NOM-SOCIAL   ' LK-GE053-I-NOM-SOCIAL */
            _.Display($"LK-GE053-I-NOM-SOCIAL   {SPGE053W.LK_GE053_I_NOM_SOCIAL}");

            /*" -5845- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-PRIMEIRO-NOME-SOCIAL-SECTION */
        private void R4100_00_PRIMEIRO_NOME_SOCIAL_SECTION()
        {
            /*" -5856- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WABEND.WNR_EXEC_SQL);

            /*" -5857- MOVE 1 TO WIND-N-S. */
            _.Move(1, AREA_DE_WORK.WIND_N_S);

            /*" -0- FLUXCONTROL_PERFORM R4100_10_LOOP */

            R4100_10_LOOP();

        }

        [StopWatch]
        /*" R4100-10-LOOP */
        private void R4100_10_LOOP(bool isPerform = false)
        {
            /*" -5861- IF WIND-N-S GREATER 100 */

            if (AREA_DE_WORK.WIND_N_S > 100)
            {

                /*" -5862- DISPLAY '*** VA3437B TAB NOMES ESTOURADA ' */
                _.Display($"*** VA3437B TAB NOMES ESTOURADA ");

                /*" -5863- GO TO R4100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/ //GOTO
                return;

                /*" -5865- END-IF */
            }


            /*" -5867- IF (TAB-NOME-SOC(WIND-N-S) EQUAL SPACES) AND (WIND-N-S EQUAL 1) */

            if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] == string.Empty) && (AREA_DE_WORK.WIND_N_S == 1))
            {

                /*" -5868- ADD 1 TO WIND-N-S */
                AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                /*" -5869- GO TO R4100-10-LOOP */
                new Task(() => R4100_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5870- ELSE */
            }
            else
            {


                /*" -5873- IF (TAB-NOME-SOC(WIND-N-S) EQUAL SPACES) AND (WIND-N-S EQUAL 2) */

                if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] == string.Empty) && (AREA_DE_WORK.WIND_N_S == 2))
                {

                    /*" -5874- ADD 1 TO WIND-N-S */
                    AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                    /*" -5875- GO TO R4100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/ //GOTO
                    return;

                    /*" -5876- END-IF */
                }


                /*" -5878- END-IF */
            }


            /*" -5879- IF (TAB-NOME-SOC(WIND-N-S) NOT EQUAL SPACES) */

            if ((TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S] != string.Empty))
            {

                /*" -5880- MOVE TAB-NOME-SOC (WIND-N-S) TO TAB-NOME1-SOC(WIND-N-S) */
                _.Move(TABELA_NOMES_SOC.TAB_NOMES_SOC_R.TAB_NOME_SOC[AREA_DE_WORK.WIND_N_S], TABELA_NOMES1_SOC.TAB_NOMES1_SOC_R.TAB_NOME1_SOC[AREA_DE_WORK.WIND_N_S]);

                /*" -5881- ADD 1 TO WIND-N-S */
                AREA_DE_WORK.WIND_N_S.Value = AREA_DE_WORK.WIND_N_S + 1;

                /*" -5882- GO TO R4100-10-LOOP */
                new Task(() => R4100_10_LOOP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -5884- END-IF */
            }


            /*" -5886- MOVE ',' TO TAB-NOME1-SOC(WIND-N-S) */
            _.Move(",", TABELA_NOMES1_SOC.TAB_NOMES1_SOC_R.TAB_NOME1_SOC[AREA_DE_WORK.WIND_N_S]);

            /*" -5888- MOVE SPACES TO TABELA-NOMES1-SOC(WIND-N-S + 1:100 - WIND-N-S) */
            _.MoveAtPosition("", TABELA_NOMES1_SOC, AREA_DE_WORK.WIND_N_S + 1, 100 - AREA_DE_WORK.WIND_N_S);

            /*" -5889- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -5900- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", WABEND.WNR_EXEC_SQL);

            /*" -5905- OPEN OUTPUT RVA3437B FVA3437B IMP3437B PDF3437B VDHTML01 VDHTML09. */
            RVA3437B.Open(RVA3437B_RECORD);
            FVA3437B.Open(FVA3437B_RECORD);
            IMP3437B.Open(IMP3437B_RECORD);
            PDF3437B.Open(PDF3437B_RECORD);
            VDHTML01.Open(VDHTML01_RECORD);
            VDHTML09.Open(VDHTML09_RECORD);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -5916- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", WABEND.WNR_EXEC_SQL);

            /*" -5921- CLOSE RVA3437B FVA3437B IMP3437B PDF3437B VDHTML01 VDHTML09. */
            RVA3437B.Close();
            FVA3437B.Close();
            IMP3437B.Close();
            PDF3437B.Close();
            VDHTML01.Close();
            VDHTML09.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9155-00-GRAVA-LINHAS-UNIC-SECTION */
        private void R9155_00_GRAVA_LINHAS_UNIC_SECTION()
        {
            /*" -5931- IF (WS-LINHAS-UNIC = 10) */

            if ((WS_LINHAS_UNIC == 10))
            {

                /*" -5932- WRITE RVA3437B-RECORD FROM LC01-LINHA01 */
                _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), RVA3437B_RECORD);

                RVA3437B.Write(RVA3437B_RECORD.GetMoveValues().ToString());

                /*" -5933- WRITE RVA3437B-RECORD FROM LC08-LINHA08 */
                _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), RVA3437B_RECORD);

                RVA3437B.Write(RVA3437B_RECORD.GetMoveValues().ToString());

                /*" -5934- WRITE RVA3437B-RECORD FROM LC09-LINHA09 */
                _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), RVA3437B_RECORD);

                RVA3437B.Write(RVA3437B_RECORD.GetMoveValues().ToString());

                /*" -5936- WRITE RVA3437B-RECORD FROM LC10-LINHA10 */
                _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), RVA3437B_RECORD);

                RVA3437B.Write(RVA3437B_RECORD.GetMoveValues().ToString());

                /*" -5937- EVALUATE WS-TIPO-ARQ-SAIDA */
                switch (WS_TIPO_ARQ_SAIDA.Value.Trim())
                {

                    /*" -5938- WHEN 'I' */
                    case "I":

                        /*" -5939- WRITE IMP3437B-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), IMP3437B_RECORD);

                        IMP3437B.Write(IMP3437B_RECORD.GetMoveValues().ToString());

                        /*" -5940- WRITE IMP3437B-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), IMP3437B_RECORD);

                        IMP3437B.Write(IMP3437B_RECORD.GetMoveValues().ToString());

                        /*" -5941- WRITE IMP3437B-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), IMP3437B_RECORD);

                        IMP3437B.Write(IMP3437B_RECORD.GetMoveValues().ToString());

                        /*" -5942- WRITE IMP3437B-RECORD FROM LC10-LINHA10 */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), IMP3437B_RECORD);

                        IMP3437B.Write(IMP3437B_RECORD.GetMoveValues().ToString());

                        /*" -5943- WHEN 'P' */
                        break;
                    case "P":

                        /*" -5944- WRITE PDF3437B-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), PDF3437B_RECORD);

                        PDF3437B.Write(PDF3437B_RECORD.GetMoveValues().ToString());

                        /*" -5945- WRITE PDF3437B-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), PDF3437B_RECORD);

                        PDF3437B.Write(PDF3437B_RECORD.GetMoveValues().ToString());

                        /*" -5946- WRITE PDF3437B-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), PDF3437B_RECORD);

                        PDF3437B.Write(PDF3437B_RECORD.GetMoveValues().ToString());

                        /*" -5947- WRITE PDF3437B-RECORD FROM LC10-LINHA10 */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.GetMoveValues(), PDF3437B_RECORD);

                        PDF3437B.Write(PDF3437B_RECORD.GetMoveValues().ToString());

                        /*" -5948- WHEN 'VDHTML01' */
                        break;
                    case "VDHTML01":

                    /*" -5949- WHEN 'VIDA05E' */
                    case "VIDA05E":

                        /*" -5950- WRITE VDHTML01-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5951- WRITE VDHTML01-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5952- WRITE VDHTML01-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5953- WRITE VDHTML01-RECORD FROM LC10-LINHTML */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.LC10_LINHTML.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5954- WHEN 'VDHTML09' */
                        break;
                    case "VDHTML09":

                    /*" -5955- WHEN 'VIDA012E' */
                    case "VIDA012E":

                        /*" -5956- WRITE VDHTML09-RECORD FROM LC01-LINHA01 */
                        _.Move(AREA_DE_WORK.LC01_LINHA01.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5957- WRITE VDHTML09-RECORD FROM LC08-LINHA08 */
                        _.Move(AREA_DE_WORK.LC08_LINHA08.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5958- WRITE VDHTML09-RECORD FROM LC09-LINHA09 */
                        _.Move(AREA_DE_WORK.LC09_LINHA09.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5959- WRITE VDHTML09-RECORD FROM LC10-LINHTML */
                        _.Move(AREA_DE_WORK.LC10_LINHA10.LC10_LINHTML.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5960- END-EVALUATE */
                        break;
                }


                /*" -5962- END-IF */
            }


            /*" -5963- IF (WS-LINHAS-UNIC = 11) */

            if ((WS_LINHAS_UNIC == 11))
            {

                /*" -5965- WRITE RVA3437B-RECORD FROM LC11-LINHA11 */
                _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), RVA3437B_RECORD);

                RVA3437B.Write(RVA3437B_RECORD.GetMoveValues().ToString());

                /*" -5966- EVALUATE WS-TIPO-ARQ-SAIDA */
                switch (WS_TIPO_ARQ_SAIDA.Value.Trim())
                {

                    /*" -5967- WHEN 'I' */
                    case "I":

                        /*" -5968- WRITE IMP3437B-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), IMP3437B_RECORD);

                        IMP3437B.Write(IMP3437B_RECORD.GetMoveValues().ToString());

                        /*" -5969- WHEN 'P' */
                        break;
                    case "P":

                        /*" -5970- WRITE PDF3437B-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), PDF3437B_RECORD);

                        PDF3437B.Write(PDF3437B_RECORD.GetMoveValues().ToString());

                        /*" -5971- WHEN 'VDHTML01' */
                        break;
                    case "VDHTML01":

                    /*" -5972- WHEN 'VIDA05E' */
                    case "VIDA05E":

                        /*" -5973- INSPECT LC11-LINHA11 REPLACING ALL ';' BY ' ' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", " ");

                        /*" -5974- INSPECT LC11-LINHA11 REPLACING ALL '|' BY ';' */
                        AREA_DE_WORK.LC11_LINHA11.Replace("|", ";");

                        /*" -5975- WRITE VDHTML01-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5976- INSPECT LC11-LINHA11 REPLACING ALL ';' BY '|' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", "|");

                        /*" -5977- WHEN 'VDHTML09' */
                        break;
                    case "VDHTML09":

                    /*" -5978- WHEN 'VIDA012E' */
                    case "VIDA012E":

                        /*" -5979- INSPECT LC11-LINHA11 REPLACING ALL ';' BY ' ' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", " ");

                        /*" -5980- INSPECT LC11-LINHA11 REPLACING ALL '|' BY ';' */
                        AREA_DE_WORK.LC11_LINHA11.Replace("|", ";");

                        /*" -5981- WRITE VDHTML09-RECORD FROM LC11-LINHA11 */
                        _.Move(AREA_DE_WORK.LC11_LINHA11.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -5982- INSPECT LC11-LINHA11 REPLACING ALL ';' BY '|' */
                        AREA_DE_WORK.LC11_LINHA11.Replace(";", "|");

                        /*" -5983- END-EVALUATE */
                        break;
                }


                /*" -5985- END-IF. */
            }


            /*" -5986- IF (WS-LINHAS-UNIC = 12) */

            if ((WS_LINHAS_UNIC == 12))
            {

                /*" -5988- WRITE RVA3437B-RECORD FROM LC12-LINHA12 */
                _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), RVA3437B_RECORD);

                RVA3437B.Write(RVA3437B_RECORD.GetMoveValues().ToString());

                /*" -5989- EVALUATE WS-TIPO-ARQ-SAIDA */
                switch (WS_TIPO_ARQ_SAIDA.Value.Trim())
                {

                    /*" -5990- WHEN 'I' */
                    case "I":

                        /*" -5991- WRITE IMP3437B-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), IMP3437B_RECORD);

                        IMP3437B.Write(IMP3437B_RECORD.GetMoveValues().ToString());

                        /*" -5992- WHEN 'P' */
                        break;
                    case "P":

                        /*" -5993- WRITE PDF3437B-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), PDF3437B_RECORD);

                        PDF3437B.Write(PDF3437B_RECORD.GetMoveValues().ToString());

                        /*" -5994- WHEN 'VDHTML01' */
                        break;
                    case "VDHTML01":

                    /*" -5995- WHEN 'VIDA05E' */
                    case "VIDA05E":

                        /*" -5996- WRITE VDHTML01-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), VDHTML01_RECORD);

                        VDHTML01.Write(VDHTML01_RECORD.GetMoveValues().ToString());

                        /*" -5997- WHEN 'VDHTML09' */
                        break;
                    case "VDHTML09":

                    /*" -5998- WHEN 'VIDA012E' */
                    case "VIDA012E":

                        /*" -5999- WRITE VDHTML09-RECORD FROM LC12-LINHA12 */
                        _.Move(AREA_DE_WORK.LC12_LINHA12.GetMoveValues(), VDHTML09_RECORD);

                        VDHTML09.Write(VDHTML09_RECORD.GetMoveValues().ToString());

                        /*" -6000- END-EVALUATE */
                        break;
                }


                /*" -6001- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9155_99_SAIDA*/

        [StopWatch]
        /*" R9200-00-PESQUISA-FORMULARIO-SECTION */
        private void R9200_00_PESQUISA_FORMULARIO_SECTION()
        {
            /*" -6011- MOVE '9200' TO WNR-EXEC-SQL. */
            _.Move("9200", WABEND.WNR_EXEC_SQL);

            /*" -6012- MOVE SVA-PRODUTO TO RELATORI-COD-PLANO */
            _.Move(REG_SVA3437B.SVA_PRODUTO, RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO);

            /*" -6013- MOVE SVA-FORMULARIO TO RELATORI-COD-RELATORIO */
            _.Move(REG_SVA3437B.SVA_FORMULARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -6014- MOVE SPACES TO RELATORI-TIPO-CORRECAO */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO);

            /*" -6016- MOVE SPACES TO RELATORI-NUM-APOL-LIDER */
            _.Move("", RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER);

            /*" -6028- PERFORM R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1 */

            R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1();

            /*" -6031- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6032- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6033- MOVE 'GERAL' TO SVA-TP-ARQSAIDA */
                    _.Move("GERAL", REG_SVA3437B.SVA_TP_ARQSAIDA);

                    /*" -6034- GO TO R9200-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9200_FIM*/ //GOTO
                    return;

                    /*" -6035- ELSE */
                }
                else
                {


                    /*" -6036- DISPLAY 'R9200 - PROBLEMAS SELECT RELATORIOS' */
                    _.Display($"R9200 - PROBLEMAS SELECT RELATORIOS");

                    /*" -6037- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6038- END-IF */
                }


                /*" -6040- END-IF */
            }


            /*" -6041- IF (RELATORI-NUM-APOL-LIDER EQUAL SPACES) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.IsEmpty()))
            {

                /*" -6042- MOVE RELATORI-TIPO-CORRECAO TO SVA-TP-ARQSAIDA */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO, REG_SVA3437B.SVA_TP_ARQSAIDA);

                /*" -6043- ELSE */
            }
            else
            {


                /*" -6044- IF (CLIENEMA-EMAIL NOT EQUAL SPACES) */

                if ((!CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL.IsEmpty()))
                {

                    /*" -6045- MOVE RELATORI-NUM-APOL-LIDER TO SVA-TP-ARQSAIDA */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER, REG_SVA3437B.SVA_TP_ARQSAIDA);

                    /*" -6046- ELSE */
                }
                else
                {


                    /*" -6047- MOVE RELATORI-TIPO-CORRECAO TO SVA-TP-ARQSAIDA */
                    _.Move(RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO, REG_SVA3437B.SVA_TP_ARQSAIDA);

                    /*" -6048- END-IF */
                }


                /*" -6050- END-IF. */
            }


            /*" -6051- IF (SVA-CODOPER EQUAL '2' ) */

            if ((REG_SVA3437B.SVA_CODOPER == "2"))
            {

                /*" -6052- MOVE 'P' TO SVA-TP-ARQSAIDA */
                _.Move("P", REG_SVA3437B.SVA_TP_ARQSAIDA);

                /*" -6052- END-IF. */
            }


        }

        [StopWatch]
        /*" R9200-00-PESQUISA-FORMULARIO-DB-SELECT-1 */
        public void R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1()
        {
            /*" -6028- EXEC SQL SELECT TIPO_CORRECAO , NUM_APOL_LIDER INTO :RELATORI-TIPO-CORRECAO , :RELATORI-NUM-APOL-LIDER FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'VG' AND NUM_APOLICE = 9999999999999 AND COD_SUBGRUPO = 9999 AND COD_RELATORIO = :RELATORI-COD-RELATORIO AND COD_PLANO = :RELATORI-COD-PLANO WITH UR END-EXEC */

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
            /*" -6064- MOVE '9800' TO WNR-EXEC-SQL. */
            _.Move("9800", WABEND.WNR_EXEC_SQL);

            /*" -6065- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -6066- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6067- DISPLAY '*   VA3437B - EMITE CERTIFICADO            *' */
            _.Display($"*   VA3437B - EMITE CERTIFICADO            *");

            /*" -6068- DISPLAY '*   -------   -----------------            *' */
            _.Display($"*   -------   -----------------            *");

            /*" -6069- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6070- DISPLAY '*             NAO EXISTEM CERTIFICADOS A   *' */
            _.Display($"*             NAO EXISTEM CERTIFICADOS A   *");

            /*" -6071- DISPLAY '*             SEREM EMITIDOS.              *' */
            _.Display($"*             SEREM EMITIDOS.              *");

            /*" -6072- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -6072- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -6083- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -6084- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -6085- DISPLAY '*** VA3437B - LIDOS         ' AC-LIDOS. */
            _.Display($"*** VA3437B - LIDOS         {AREA_DE_WORK.AC_LIDOS}");

            /*" -6087- DISPLAY '*** VA3437B - CERTIFICADO   ' PROPOVA-NUM-CERTIFICADO. */
            _.Display($"*** VA3437B - CERTIFICADO   {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -6089- DISPLAY '*** VA3437B - CERTIFICADO-W ' WHOST-NRCERTIF. */
            _.Display($"*** VA3437B - CERTIFICADO-W {WHOST_NRCERTIF}");

            /*" -6089- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -6091- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -6095- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -6095- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}