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
using Sias.Geral.DB2.GE0853S;

namespace Code
{
    public class GE0853S
    {
        public bool IsCall { get; set; }

        public GE0853S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA .............  VIDAZUL EMPRESA GLOBAL/MULTIPREM      *      */
        /*"      *   PROGRAMA ............  GE0853S                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ............  TERCIO                                *      */
        /*"      *   PROGRAMADOR .........  TERCIO                                *      */
        /*"      *   DATA CODIFICACAO ....  27/11/1997                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..............  SUBROTINA QUE SUBSTITUI O VA0851B PARA*      */
        /*"      *                          GERAR AS PARCELAS EM ATRASO OU        *      */
        /*"      *                          CANCELAR O CERTIFICADO EM ATRASO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43 - INCIDENTE 231.852                                *      */
        /*"      *               CORRIGIR COBRANCA DE PARCELAS ATRASADAS DA OPCAO *      */
        /*"      *               DE PAGAMENTO CARTAO DE CREDITO.                  *      */
        /*"      *               ERRO -803 - R1320-INSERT-MOVTO-DEBITOCC-VA0853B  *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/01/2020 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.43    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 42 - HISTORIA 11.173                                  *      */
        /*"      *             - CORRECAO PARA GERACAO DE PARCELAS EM ATRASO QUAN-*      */
        /*"      *               OPCAO-PAG FOR DEBITO EM CONTA E CARTAO           *      */
        /*"      *             - RETIRADA DE MONITORAMENTO DE TEMPO DE PROCESSAMEN*      */
        /*"      *               TO PARA MELHOR ENTENDIMENTO DO PROGRAMA.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/02/2018 - ELIERMES                                     *      */
        /*"      *                                            PROCURE POR V.42    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41 - CADMUS 156.871                                   *      */
        /*"      *             - AJUSTE GERACAO PARCELAS EM ATRASO                *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/01/2018 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.41    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40 - CADMUS 157.448                                   *      */
        /*"      *             - TENTATIVA DE AJUSTE NO CANCELAMENTO DE           *      */
        /*"      *               CERTIFICADO, CONFORME EXEMPLO ANEXO ENVIADO NO   *      */
        /*"      *               CADMUS. CERTIFICADO 81695110015734 - CANCELADO   *      */
        /*"      *               INDEVIDAMENT                                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/01/2018 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.40    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39 - CADMUS 157.262                                   *      */
        /*"      *             - INSERIR MARCADOR DE IMPRESSAO DE BOLETO NA COLUNA*      */
        /*"      *               COD-DEVOLUCAO=7966 DA TABELA COBER_HIST_VIDAZUL  *      */
        /*"      *               QUE SERÁ PEGA PELO VA0267B P/ GERAR BOLETO SIGCB *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/01/2018 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.39    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38 - CADMUS 155.307                                   *      */
        /*"      *             - SOMAR QUANTIDADE DE SITUACAO QUE SAIRAM SEM      *      */
        /*"      *               GERAR PARCELA PARA MONITORAMENTO DE PROCESSAMENTO*      */
        /*"      *                                                                *      */
        /*"      *   EM 13/11/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.38    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37 - CADMUS 155.307                                   *      */
        /*"      *             - ALTERAR SITUACAO DA PROPOSTAS_VA PARA CANCELADO  *      */
        /*"      *               QUANDO CERTIFICADO FOR CANCELADO POR FALTA DE    *      */
        /*"      *               PAGAMENTO, PARA N�O GERACAO DE PARCELA INDEVIDA        */
        /*"      *               PELO VA0853B.                                    *      */
        /*"      *             - SELECIONAR APENAS AS PARCELAS ATRASADAS COM MESMO*      */
        /*"      *               NUM-PARCELA GRAVADO NA PROPOSTAS_VA, EVITANDO QUE*      */
        /*"      *               O ESTE PGM SELECIONE PARCELAS ANTERIORES.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/11/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.37    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - CADMUS 154.956                                   *      */
        /*"      *             - DESCONSIDERAR MODALIDADE NA CONSULTA DE COBERTURA*      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.36    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35 - CAD 154.678                                      *      */
        /*"      *             - TRATAR APENAS PARCELAS ATRASADAS ATUAIS          *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.35  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34 - CAD 150.293                                      *      */
        /*"      *             - CONSIDERAR A OPCAO-PAG APENAS DA TABELA          *      */
        /*"      *               OPCAO_PAG_VIDAZUL.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/04/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.34  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33   - FGV-2                                          *      */
        /*"      *               - INCLUIR O MONITORAMENTO NO PROGRAMA PARA IDEN- *      */
        /*"      *                 TIFICAR OS PONTOS DE DEMORA.                   *      */
        /*"      *   EM 18/04/2017 - KINKAS                                       *      */
        /*"      *                                       PROCURE POR MONIT/V.33   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32   - CADMUS 140.778                                 *      */
        /*"      *               - ANTECIPAR EM 03 DIAS A GERACAO DA PARCELA PARA *      */
        /*"      *                 SOLICITAR NN AO SAP POR MEIO DE ARQ-A (EM8100B)*      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31   - CADMUS 140.778                                 *      */
        /*"      *               - ANTECIPAR EM 02 DIAS A GERACAO DA PARCELA PARA *      */
        /*"      *                 SOLICITAR NN AO SAP POR MEIO DE ARQ-A (EM8100B)*      */
        /*"      *   EM 12/12/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30 - CAD 114.834                                      *      */
        /*"      *             - PASSA A REALIZAR CANCELAMENTO DE PARCELAS COM    *      */
        /*"      *               OPCAO_PAG = 5-CARTAO DE CREDITO, VINDO  A  CANCE-*      */
        /*"      *               LAR OS CERTIFICADOS QUE POSSUAM MAIS DE DUAS PAR-*      */
        /*"      *               CELAS PENDENTES DE RECEBIMENTO.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/03/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.30  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29  -  ABEND - CADMUS 125726                          *      */
        /*"      *              -  CORRECAO NA CONTAGEM DE PARCELAS ATRASADAS DA  *      */
        /*"      *                 V.27, EVITANDO O LOOP DO PROGRAMA              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                           PROCURE POR V.29     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28  -  CADMUS 123766.                                 *      */
        /*"      *              -  CORRECAO DO ERRO QUE ESTAVA IMPEDINDO DE GERAR *      */
        /*"      *                 NOVAS PARCELAS QUANDO HAVIA ALGUMA PARCELA AN- *      */
        /*"      *                 TERIOR PENDENTE.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/10/2015 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27  -  CADMUS 123261                                  *      */
        /*"      *              -  CORRECAO DE CONTAGEM DE PARCELAS PENDENTES COM *      */
        /*"      *                 OPCAO DE PAGAMENTO IGUAL A BOLETO              *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/10/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/06/2015 - COREON                                       *      */
        /*"      *                                       PROCURE POR V.26         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25                                                    *      */
        /*"      *             - CAD 113.766                                      *      */
        /*"      *             ------------ I M P O R T A N T E ----------------  *      */
        /*"      *             - CURSOR DO PROGRAMA FOI ALTERADO PARA NAO MAIS    *      */
        /*"      *               TRATAR INADIPLENCIA DE COBRANCAS QUE POSSUEM     *      */
        /*"      *               OPCAO DE PAGAMENTO CARTAO DE CREDITO. AS MESMAS  *      */
        /*"      *               SAO COBRADAS PELO PROGRAMA VA0853B.              *      */
        /*"      *             -------------------------------------------------  *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/05/2015 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                              PROCURE POR V.25  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24                                                    *      */
        /*"      *             - ABEND 114.356                                    *      */
        /*"      *             - INSERIR WITH UR NO CURSOR, PARA PROCESSAR REGIS- *      */
        /*"      *               TROS E NAO FICAR PARADO EM MAQUINA.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/05/2015 - FRANK CARVALHO (INDRA COMPANY)               *      */
        /*"      *                                              PROCURE POR V.24  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23                                                    *      */
        /*"      *             - CAD 106.797                                      *      */
        /*"      *             - RETIRAR ERRO QUANDO NAO ENCONTRAR DIFERENCA DE   *      */
        /*"      *               PARCELA                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.23  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22                                                    *      */
        /*"      *             - CAD 106.432                                      *      */
        /*"      *             - INSERIR DISPLAY NOS ERROS CRITICOS PARA FACILITAR*      */
        /*"      *               CORRECAO                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/11/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.22  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21                                                    *      */
        /*"      *             - CAD  94.968                                      *      */
        /*"      *             - RETIRAR SOMATORIO DE VLCUSTCAP AO PREMIO-VG      *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.21  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20                                                    *      */
        /*"      *             - CAD 102.406                                      *      */
        /*"      *             - RETIRAR CANCELAMENTO DE APOLICES EMPRESARIAIS  E *      */
        /*"      *               GLOBAIS, QUE PASSARÁ A SER CANCELADO PELO VG0852B*      */
        /*"      *                                                                *      */
        /*"      *   EM 05/11/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                              PROCURE POR V.20  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19                                                    *      */
        /*"      *             - CAD 101.217                                      *      */
        /*"      *             - RESSEGURO                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/08/2014 - LUIZ GUSTAVO DE OLIVEIRA                     *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.19  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18                                                    *      */
        /*"      *             - CAD 101.808                                      *      */
        /*"      *             - ZERA VALORES DE IMPORTANCIA SEGURADA CASO NAO    *      */
        /*"      *               ENCONTRADO REGISTRO NA V0COBERAPOL               *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.18  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 17                                                    *      */
        /*"      *             - CAD 100.904                                      *      */
        /*"      *             - CORRECAO DE ABEND OCORRE POR N�O ENCONTRAR PARCEL      */
        /*"      *               COM SITUACAO DIFERENTE DE '1' E '2'              *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/07/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.17  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16                                                    *      */
        /*"      *             - CAD 97.240                                       *      */
        /*"      *             - CORRECAO DA CONTAGEM DE PARCELAS EM ATRASO PARA  *      */
        /*"      *               CANCELAMENTO DE CERTIFICADOS                     *      */
        /*"      *             - ALTERACAO DA SITUACAO SELECIONADA NO CURSOR POIS *      */
        /*"      *               NAO ESTAVA PEGANDO SITUACAO COM LOW-VALUES X'00' *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/07/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.16  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15                                                    *      */
        /*"      *             - CAD  76.202                                      *      */
        /*"      *               CORRIGIR CANCELAMENTO DE EMPRE/GLOBAL COM 2      *      */
        /*"      *               PARCELAS ATRASADAS                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/01/2013 - CLAUDIO FREITAS     (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.15  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14                                                    *      */
        /*"      *             - CAD  61.239                                      *      */
        /*"      *                    TRATAR DATAS DE VENCIMENTO EM DIA 31 PARA   *      */
        /*"      *                    CORRIGIR O ABEND SQLCODE -811               *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/08/2011 - ALESSANDRO G. RAMOS (FAST COMPUTER)          *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.14             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13                                                    *      */
        /*"      *             - CAD  201.122                                     *      */
        /*"      *               INSERIR COLUNAS NA CLAUSULA INSERT DAS TABELAS   *      */
        /*"      *               HIST_LANC_CTA OU V0HISTCONTAVA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2011 - LOPES          (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.13             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12  - CAD 49.195                                      *      */
        /*"      *                AJUSTE NA CRITICA DE PREMIO AP OU PREMIO VG     *      */
        /*"      *                NEGATIVOS.                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/10/2010 - TERCIO FREITAS  - FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.12    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11  - CAD 38.578                                      *      */
        /*"      *                ALTERACAO PARA BUSCAR O NUMERO DO TITULO NA     *      */
        /*"      *                TABELA SEGUROS.CEDENTE PARA DEBITOS EM CONTA    *      */
        /*"      *                CORRENTE.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/03/2010 - EDIVALDO GOMES  - FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *                                PROCURE POR V.11                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10  - CRITICA CALCULO PERCENTUAL.                     *      */
        /*"      *              - CAD 30.428                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/09/2009 - CESAR DALAZUANA - FAST COMPUTER              *      */
        /*"      *                                                                *      */
        /*"      *                               .PROCURE POR V.10                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09  - CORRECAO DO ABEND OCORRIDO SQLCODE = -811       *      */
        /*"      *              NA TABELA V0COBERPROPVA                           *      */
        /*"      *              - CAD 28.651                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/08/2009 - MARCO PAIVA - FAST COMPUTER                  *      */
        /*"      *                                                                *      */
        /*"      *                               .PROCURE POR V.09                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08                                                    *      */
        /*"      *             - ABEND SQLCODE -811                               *      */
        /*"      *             - CAD 27.095                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/07/2009 - LEANDRO CORTES -FAST COMPUTER                *      */
        /*"      *                                                                *      */
        /*"      *                               .PROCURE POR V.08                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07                                                    *      */
        /*"      *             - CAD 10.205                                       *      */
        /*"      *               CANCELAMENTO EMPRESARIAL NA TERCEIRA COBRANCA    *      */
        /*"      *               EM ATRASO.                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 15.403                                       *      */
        /*"      *               CANCELAMENTO INDEVIDO DE PROPOSTAS               *      */
        /*"      *               CUJA SITUACAO DA PARCELA NA HIST_LANC_CTA        *      */
        /*"      *               ESTA PENDENTE DE ENVIO PARA CAIXA.               *      */
        /*"      *                                                                *      */
        /*"      *             - CAD 15.452                                       *      */
        /*"      *               CANCELAMENTO INDEVIDO DE SEGUROS                 *      */
        /*"      *               CUJA SITUACAO DA PARCELA NA HIST_LANC_CTA        *      */
        /*"      *               ESTA PENDENTE DE ENVIO PARA CAIXA.               *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/10/2008 - FAST COMPUTER            PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    PROJETO FGV  (POLITEC)  WELLINGTON VERAS  -  TE39902        *      */
        /*"      *                                                                *      */
        /*"      * 16/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      * 18/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      * 27/10/2008   INIBIR O COMANDO DISPLAY               - WV1008   *      */
        /*"      * 27/10/2008   INCLUIR WITH UR NO COMANDO SELECT      - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06                                                    *      */
        /*"      *             - CAD 13.762                                       *      */
        /*"      *               REVISAO DO PRODUTOS DE PAGAMENTO UNICO           *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/09/2008 - FAST COMPUTER            PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   14/03/2007        CORRECAO DO ABEND SQLCODE = 100            *      */
        /*"      *                     OCORRIDO  NO UPDATE V0HISTCONTAVA          *      */
        /*"      *                            LUCIA VIEIRA       (V.05)           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   29/09/2006        CORRECAO DO ABEND SQLCODE = 100            *      */
        /*"      *                     OCORRIDO NO SEGUROS.V0PARCELVA             *      */
        /*"      *                            MARCO ANTONIO      (V.04)           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   13/09/2006        CORRECAO DO ABEND SQLCODE = -811           *      */
        /*"      *                     OCORRIDO NO SEGUROS.V0HISTCONTAVA          *      */
        /*"      *                            MARCO ANTONIO      (V.03)           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   08/09/2006        CORRECAO DO ABEND SQLCODE = 100            *      */
        /*"      *                     OCORRIDO NO SEGUROS.V0FATURCONT.           *      */
        /*"      *                            MARCO ANTONIO      (V.02)           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   04/09/2006               FILTRA EMPRESA GLOBAL               *      */
        /*"      *                                     FAST COMPUTER      (V.01)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   10/11/2005               DESPREZA OS REGISTROS DAS APOLICES  *      */
        /*"      *                            ESPECIFICA ONDE O CAMPO ORIG_PRODU  *      */
        /*"      *                            FOR 'ESPE1' OU 'ESPE2' OR 'ESPE3'   *      */
        /*"      *                                     TERCIO CARVALHO    (TC1011)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   11/08/2003                EVITAR A GERACAO DE PARCELAS PARA  *      */
        /*"      *                             O EXECUTIVO A PEDIDO DO CESAR/SANY *      */
        /*"      *                             EM FUNCAO DE MALA DIRETA DE ADESAO *      */
        /*"      *                                       FREDERICO FONSECA(FF0803)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   07/08/2002                EVITAR A GERACAO DE MAIS DE UM RE- *      */
        /*"      *                             GISTRO PARA O MESMO SUBGRUPO NA TA-*      */
        /*"      *                             BELA V0RELATORIOS.                 *      */
        /*"      *                                       MANOEL MESSIAS   (MM0708)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   18/07/2002                GERA SOLICITACAO DE CANCELAMENTO   *      */
        /*"      *                             DO EMPRESARIAL PARA O PROGRAMA     *      */
        /*"      *                             VE0030B.                           *      */
        /*"      *                                       MANOEL MESSIAS   (MM0702)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   05/06/2002                AO INVES DE TRATAR POR SUBGRUPO    *      */
        /*"      *                             PARA CANCELAMENTO SUM RIO PASSA A  *      */
        /*"      *                             TRATAR POR PERIODO DE PAGAMENTO    *      */
        /*"      *                             DIFERENTE DE 1.                    *      */
        /*"      *                                       TERCIO CARVALHO  (TL0206)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   25/02/2002                DESPREZA OS REGISTROS DAS APOLICES *      */
        /*"      *                             ESPECIFICA E EMPRESARIAL, ONDE, O  *      */
        /*"      *                             CAMPO ORIG_PRODU FOR 'EMPRE' OU    *      */
        /*"      *                             'ESPEC'                            *      */
        /*"      *                                       MESSIAS          (MM0202)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   14/05/2001                O PROGRAMA PASSA A NAO MAIS        *      */
        /*"      *                             ATUALIZAR A SITUACAO DA PROPOSTA_VA*      */
        /*"      *                             PARA CANCELADA CENTRALIZANDO A     *      */
        /*"      *                             ATUALIZACAO NO VG0030B             *      */
        /*"      *                                       TERCIO/MESSIAS   (TL0105)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   31/10/2000                O PROGRAMA NAO GERA MAIS PARCELAS  *      */
        /*"      *                             DE CAPITALIZACAO PARA A ICATU DOS  *      */
        /*"      *                             TITULOS QUE FORAM MIGRADOS PARA A  *      */
        /*"      *                             CAIXA CAPITALIZACAO.               *      */
        /*"      *                                         FRED/MESSIAS   (MM1000)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   14/03/2000                PASSA A COMMITAR REGISTRO A REGIS- *      */
        /*"      *                             TRO.                               *      */
        /*"      *                                               MESSIAS  (MM1403)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   09/09/1999                PARA OS PRODUTOS QUE OFERECEM CAPI-*      */
        /*"      *                             TALIZACAO, SERA GERADA CONCOMITAN- *      */
        /*"      *                             TEMENTE AA PARCELA DE COBRANCA, A  *      */
        /*"      *                             PARCELA DE CAPITALIZACAO.          *      */
        /*"      *                                               MESSIAS  (MM0909)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   01/09/1999                EVITA PROCESSAR SEGURADO, CUJO, AR-*      */
        /*"      *                             QUIVO DE RETORNO DE COBRANCA NAO   *      */
        /*"      *                             TENHA SIDO EXECUTADO. EVITA ASSIM, *      */
        /*"      *                             COLOCAR O MESMO, INDEVIDAMENTE EM  *      */
        /*"      *                             ATRASO.                            *      */
        /*"      *                                               MESSIAS  (MM0109)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   19/07/1999                PASSA A TRATAR SITUACAO 2 E 4      *      */
        /*"      *                             DA V0PROPOSTAVA                    *      */
        /*"      *                                               TERCIO   (TL9907)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   24/06/1999                PASSA A NAO MAIS TRATRA PRODUTO    *      */
        /*"      *                                               TERCIO   (TL9906)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   17/03/1999                PARA O SEGURADO QUE PAGA COM DEBITO*      */
        /*"      *                             EM CONTA, NAO MUDAR PARA CARNE. PRE*      */
        /*"      *                             PARADO PARA AS DUAS MODALIDADES DE *      */
        /*"      *                             PAGAMENTO: DEBITO E CARNE.         *      */
        /*"      *                                               MESSIAS  (MM0399)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   16/09/1998                NAO TRATA O PRODUTO 9300 - FEDERAL *      */
        /*"      *                             VIDA, QUE SERA TRATADO PELO PGM    *      */
        /*"      *                             VF0851B                            *      */
        /*"      *                                               FONSECA  (AF9809)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   26/06/1998                NAO TRATA POR ENQUANTO A COBRANCA  *      */
        /*"      *                             DO SAUDE - PADV, ATE TERMINAR A    *      */
        /*"      *                             IMPLANTACAO DA ROTINA              *      */
        /*"      *                                               FONSECA  (AF9806)*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   07/04/1998                POR SOLICITACAO DO HESPANHOL,      *      */
        /*"      *                             DEIXA DE EXISTIR A COBRANCA DA     *      */
        /*"      *                             PRIMEIRA PARCELA EM ATRASO, EM     *      */
        /*"      *                             FUNCAO DO PRAZO APERTADO.          *      */
        /*"      *                             A PRIMEIRA EH COBRADA JUNTAMENTE   *      */
        /*"      *                             COM A SEGUNDA, NO VENCIMENTO       *      */
        /*"      *                             DESSA ULTIMA.                      *      */
        /*"      *                                               FONSECA  (AF01)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   26/12/1997                CORRIGIDO O PROBLEMA PARA O INSERT *      */
        /*"      *                             DA VA0DIFPARCELVA PARA A TERCEIRA  *      */
        /*"      *                             PARCELA EM ATRASO. FOI FEITO UM    *      */
        /*"      *                             INCREMENTO NA WHOST-CODOPER.       *      */
        /*"      *                                                 TERCIO (TL01)  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * PROPOSTAS VA                        V0PROPOSTAVA      INPUT    *      */
        /*"      * COBERTURAS PROPOSTA VA              V0COBERPROPVA     INPUT    *      */
        /*"      * PARCELAS VA                         V0PARCELVA        I-O      *      */
        /*"      * HISTORICO DEBITO CONTA VA           V0HISTCONTAVA     OUTPUT   *      */
        /*"      * HISTORICO COBRANCA VA               V0HISTCOBVA       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77         VIND-LOT-EMP-SEG      PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_LOT_EMP_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NSAS             PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NRPARCEL         PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTMOVTO          PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-SAF          PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TEM-CDG          PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ESTR-COBR        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ORIG-PRODU       PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-AGECTADEB        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-OPRCTADEB        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUMCTADEB        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DIGCTADEB        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-NUM-PARC-AT        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WS_NUM_PARC_AT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCTA-NSL            PIC S9(009)    USAGE COMP.*/
        public IntBasis V0HCTA_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WS-NUM-TITULO-AT      PIC S9(013)    VALUE +0 COMP-3.*/
        public IntBasis WS_NUM_TITULO_AT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WS-MSG-RETORNO        PIC  X(075)    VALUE SPACES.*/
        public StringBasis WS_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"");
        /*"77         MOVDEBCE-DTCREDITO    PIC  X(010)    VALUE SPACES.*/
        public StringBasis MOVDEBCE_DTCREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         WHOST-SIT-REGISTRO    PIC  X(001)    VALUE SPACES.*/
        public StringBasis WHOST_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         WHOST-NRTIT           PIC S9(013)    VALUE +0 COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-DT-VENC-PARC    PIC  X(010)    VALUE SPACES.*/
        public StringBasis WHOST_DT_VENC_PARC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77         WHOST-VL-PRM-TOTAL    PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-ATRZ     PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_ATRZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-PAGO     PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-ATU      PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-TOT-PAGO PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_TOT_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-PAGO     PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_PAGO_0 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-SOMA     PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_SOMA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-VL-PRM-1PARC    PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VL_PRM_1PARC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-DTVENCTO        PIC  X(010).*/
        public StringBasis WHOST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-COUNT-PEN       PIC S9(009)    COMP   VALUE +0.*/
        public IntBasis WHOST_COUNT_PEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-NRPARCEL        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRPARCEL-1      PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_NRPARCEL_1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-PARCELCAP       PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_PARCELCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-CODOPER         PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-CODOPER1        PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis WHOST_CODOPER1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-COUNT-DEB       PIC S9(009)    COMP   VALUE +0.*/
        public IntBasis WHOST_COUNT_DEB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         WHOST-VLPREMIO        PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMVG           PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         WHOST-PRMAP           PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HOST-CERTIF-VALIDO  PIC S9(015)    COMP-3 VALUE +0.*/
        public IntBasis V0HOST_CERTIF_VALIDO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-NRCERTIF        PIC S9(015)    COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-VLPREMIO-ATR    PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis WHOST_VLPREMIO_ATR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DESCON-PERC           PIC S9(003)V9999 COMP-3.*/
        public DoubleBasis DESCON_PERC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"77         DESCON-PRMVG          PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DESCON-PRMAP          PIC S9(013)V99 COMP-3 VALUE +0.*/
        public DoubleBasis DESCON_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DESCON-NRPARCEL       PIC S9(004)    COMP   VALUE +0.*/
        public IntBasis DESCON_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-VE  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_VE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-CN  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_CN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1SIST-DTVENFIM-1Y  PIC  X(010).*/
        public StringBasis V1SIST_DTVENFIM_1Y { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CONT-DATCEF       PIC  X(010).*/
        public StringBasis V0CONT_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISC-NRCERTIF     PIC S9(015) COMP-3.*/
        public IntBasis V0HISC_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0HISC-NRPARCEL     PIC S9(004) COMP.*/
        public IntBasis V0HISC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISC-CODOPER      PIC S9(004) COMP.*/
        public IntBasis V0HISC_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISC-OCORHIST     PIC S9(004) COMP.*/
        public IntBasis V0HISC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISC-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISC-DTVENCTO-30  PIC  X(010).*/
        public StringBasis V0HISC_DTVENCTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISC-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0HISC_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISC-VLPRMTOT     PIC S9(013)V99 COMP-3.*/
        public DoubleBasis V0HISC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0HISC-SITUACAO     PIC  X(001).*/
        public StringBasis V0HISC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0HISC-NRTITCOMP    PIC S9(013) COMP-3.*/
        public IntBasis V0HISC_NRTITCOMP { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISC-NRTIT        PIC S9(013) COMP-3.*/
        public IntBasis V0HISC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HCOB-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HCTA-NSAS         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCTA-OCORHISTCTA  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTA_OCORHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HCTA-SITUACAO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77         V0BANC-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0CONV-CODCONV      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-DTADMISSAO   PIC  X(010).*/
        public StringBasis V0PROP_DTADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-QTDPARATZ    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRPRIPARATZ  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_NRPRIPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0PROP-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-NRMATRFUN    PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0PROP-INRMATRFUN   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0PROP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0PROP-OPCAOCAP     PIC S9(004)               COMP.*/
        public IntBasis V0PROP_OPCAOCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PROP-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PROP_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-ORIG-PRODU   PIC  X(010).*/
        public StringBasis V0PROP_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PROP-TEM-SAF      PIC  X(001).*/
        public StringBasis V0PROP_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-TEM-CDG      PIC  X(001).*/
        public StringBasis V0PROP_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-COBERADIC    PIC  X(001).*/
        public StringBasis V0PROP_COBERADIC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-CUSTOCAP     PIC  X(001).*/
        public StringBasis V0PROP_CUSTOCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0PROP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-NUM-PARCELA      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-NUM-PARCELA-PEND PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_NUM_PARCELA_PEND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-NUM-PARCELA-ATRD PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_NUM_PARCELA_ATRD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-QT-PARCELAS      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_QT_PARCELAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-QT-PARCELAS-ATZ  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_QT_PARCELAS_ATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-QT-PARCELAS-PAGA PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_QT_PARCELAS_PAGA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-CONTA-PAGOS      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WS_CONTA_PAGOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NUM-PARCELA-I PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_PARCELA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NUM-PARCELA-F PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_PARCELA_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPCAOPAG     PIC  X(001).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-AGECTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-OPRCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0OPCP-NUMCTADEB    PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0OPCP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0OPCP-DIGCTADEB    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77         V0COBA-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-PRMVG        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PRMAP        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0SEGU-TPINCLUS     PIC  X(001).*/
        public StringBasis V0SEGU_TPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0SEGU-AGENCIADOR   PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGU_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGU-ITEM         PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0SEGU_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0SEGU-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0SEGU_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0SEGU-LOT-EMP-SEGURADO PIC X(030).*/
        public StringBasis V0SEGU_LOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77         V0FATC-DTREF        PIC  X(010).*/
        public StringBasis V0FATC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0PARC-PRMTOTANT    PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0PARC-DTVENCTO     PIC  X(010).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V2PARC-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2PARC-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         GUARDA-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis GUARDA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         GUARDA-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis GUARDA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         GUARDA-PRMTOT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis GUARDA_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         GUARDA-PERC-VG      PIC S9(003)V9(4) VALUE +0 COMP-3.*/
        public DoubleBasis GUARDA_PERC_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77         GUARDA-PERC-AP      PIC S9(003)V9(4) VALUE +0 COMP-3.*/
        public DoubleBasis GUARDA_PERC_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77         DEVIDO-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis DEVIDO_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         DEVIDO-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis DEVIDO_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-NRPARCELDIF  PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_NRPARCELDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0DIFP-VLPRMTOT     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V2DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V2DIFP-PRMDIFVG     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-PRMDIFAP     PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-NRPARCDIF    PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V2DIFP_NRPARCDIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V2DIFP-DTVENCTO     PIC  X(010).*/
        public StringBasis V2DIFP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V2DIFP-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2DIFP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V2DIFP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V2DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V2DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V3DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V3DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V4DIFP-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V4DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RCDG-DTREFER      PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RCDG-SITUACAO     PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0CDGC-VLCUSTCDG    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0RSAF-DTREFER      PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77         V0RSAF-SITUACAO     PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77         V0SAFC-VLCUSTSAF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77         V0MOVF-COUNT        PIC S9(009)      COMP.*/
        public IntBasis V0MOVF_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FONT-PROPAUTOM    PIC S9(009)      COMP.*/
        public IntBasis V0FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MOVI-DTMOVTO      PIC  X(010).*/
        public StringBasis V0MOVI_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0MOVI-COUNT        PIC S9(009) COMP.*/
        public IntBasis V0MOVI_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0RELA-CODRELAT     PIC  X(008).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0RELA-QTDPARATZ    PIC S9(004) COMP.*/
        public IntBasis V0RELA_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0RELA-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  FILLER.*/
        public GE0853S_FILLER_0 FILLER_0 { get; set; } = new GE0853S_FILLER_0();
        public class GE0853S_FILLER_0 : VarBasis
        {
            /*"    03 W01-I                   PIC 9(009).*/
            public IntBasis W01_I { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 W01-R-AUX REDEFINES W01-I                                PIC 9(009).*/
            private _REDEF_IntBasis _w01_r_aux { get; set; }
            public _REDEF_IntBasis W01_R_AUX
            {
                get { _w01_r_aux = new _REDEF_IntBasis(new PIC("9", "009", "9(009).")); ; _.Move(W01_I, _w01_r_aux); VarBasis.RedefinePassValue(W01_I, _w01_r_aux, W01_I); _w01_r_aux.ValueChanged += () => { _.Move(_w01_r_aux, W01_I); }; return _w01_r_aux; }
                set { VarBasis.RedefinePassValue(value, _w01_r_aux, W01_I); }
            }  //Redefines
            /*"    03 W01-FETCH-I             PIC 9(003).*/
            public IntBasis W01_FETCH_I { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"    03 W01-SEG-FETCH-ANT       PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_FETCH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-SEG-INI             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_INI { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-SEG-FIN             PIC S9(08)V9(4).*/
            public DoubleBasis W01_SEG_FIN { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)."), 4);
            /*"    03 W01-QTD-ACC-OK          PIC 9(008).*/
            public IntBasis W01_QTD_ACC_OK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 W01-QTD-ACC-NOK         PIC 9(008).*/
            public IntBasis W01_QTD_ACC_NOK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03 W01-TOT-ACC-OK-ED       PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_OK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*"    03 W01-TOT-ACC-NOK-ED      PIC ZZ.ZZZ.ZZ9.*/
            public IntBasis W01_TOT_ACC_NOK_ED { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
            /*"    03 W01-TOT-TIME-ED         PIC ZZZ.ZZ9,9999-.*/
            public DoubleBasis W01_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
            /*"    03      W01-CURRENT-DATE.*/
            public GE0853S_W01_CURRENT_DATE W01_CURRENT_DATE { get; set; } = new GE0853S_W01_CURRENT_DATE();
            public class GE0853S_W01_CURRENT_DATE : VarBasis
            {
                /*"      10    W01-CDTE-ANO       PIC  9(004).*/
                public IntBasis W01_CDTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    W01-CDTE-MES       PIC  9(002).*/
                public IntBasis W01_CDTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-DIA       PIC  9(002).*/
                public IntBasis W01_CDTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-HORA      PIC  9(002).*/
                public IntBasis W01_CDTE_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-MIN       PIC  9(002).*/
                public IntBasis W01_CDTE_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-SEG       PIC  9(002).*/
                public IntBasis W01_CDTE_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-DECSEG    PIC  9(002).*/
                public IntBasis W01_CDTE_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-GREEN     PIC  X(001).*/
                public StringBasis W01_CDTE_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    W01-CDTE-GHORA     PIC  9(002).*/
                public IntBasis W01_CDTE_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    W01-CDTE-GMIN      PIC  9(002).*/
                public IntBasis W01_CDTE_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W01-LIM-OCOR            PIC 9(009)      VALUE  146.*/
            }
            public IntBasis W01_LIM_OCOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 146);
            /*"    03 W01-TABELA-TOTAIS.*/
            public GE0853S_W01_TABELA_TOTAIS W01_TABELA_TOTAIS { get; set; } = new GE0853S_W01_TABELA_TOTAIS();
            public class GE0853S_W01_TABELA_TOTAIS : VarBasis
            {
                /*"       05 W01-TOT-ACC-OK       PIC 9(008)      OCCURS 146.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_OK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 146);
                /*"       05 W01-TOT-ACC-NOK      PIC 9(008)      OCCURS 146.*/
                public ListBasis<IntBasis, Int64> W01_TOT_ACC_NOK { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "8", "9(008)"), 146);
                /*"       05 W01-TOT-TIME         PIC S9(08)V9(4) OCCURS 146.*/
                public ListBasis<DoubleBasis, double> W01_TOT_TIME { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V9(4)"), 146);
                /*"    03 W01-TABELA-TEXTO.*/
            }
            public GE0853S_W01_TABELA_TEXTO W01_TABELA_TEXTO { get; set; } = new GE0853S_W01_TABELA_TEXTO();
            public class GE0853S_W01_TABELA_TEXTO : VarBasis
            {
                /*"       05 W01-TAB-TEXTO                        OCCURS 146.*/
                public ListBasis<GE0853S_W01_TAB_TEXTO> W01_TAB_TEXTO { get; set; } = new ListBasis<GE0853S_W01_TAB_TEXTO>(146);
                public class GE0853S_W01_TAB_TEXTO : VarBasis
                {
                    /*"          10 W01-ORDEM         PIC X(002).*/
                    public StringBasis W01_ORDEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"          10 W01-TEXTO         PIC X(034).*/
                    public StringBasis W01_TEXTO { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                    /*"01  WS-TIME                     PIC  X(008).*/
                }
            }
        }
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  WS-TIME-HMS                 PIC  X(008).*/
        public StringBasis WS_TIME_HMS { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_GE0853S_FILLER_1 _filler_1 { get; set; }
        public _REDEF_GE0853S_FILLER_1 FILLER_1
        {
            get { _filler_1 = new _REDEF_GE0853S_FILLER_1(); _.Move(W_NUMR_TITULO, _filler_1); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_1, W_NUMR_TITULO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_NUMR_TITULO); }; return _filler_1; }
            set { VarBasis.RedefinePassValue(value, _filler_1, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_GE0853S_FILLER_1 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_GE0853S_FILLER_1()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public GE0853S_DPARM01X DPARM01X { get; set; } = new GE0853S_DPARM01X();
        public class GE0853S_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_GE0853S_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_GE0853S_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_GE0853S_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_GE0853S_DPARM01_R : VarBasis
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

                public _REDEF_GE0853S_DPARM01_R()
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
            /*"01           AREA-DE-WORK.*/
        }
        public GE0853S_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0853S_AREA_DE_WORK();
        public class GE0853S_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-EMPR-NCANC   PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_EMPR_NCANC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-SOL-CANC     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_SOL_CANC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-PARC-ANT   PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_PARC_ANT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-PARC-ANT1Y PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_PARC_ANT1Y { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         QTD-CANCEL        PIC  9(002)       VALUE  ZEROS.*/
            public IntBasis QTD_CANCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WACC-COMMIT       PIC  9(004)       VALUE  ZEROS.*/
            public IntBasis WACC_COMMIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WS-QTD-SIT-01     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_01 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-02     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_02 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-03     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_03 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-04     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_04 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-05     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_05 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-06     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_06 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-07     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_07 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-08     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_08 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-09     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_09 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-10     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_10 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-11     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_11 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-QTD-SIT-12     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WS_QTD_SIT_12 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WFIM-CHISTCB    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CHISTCB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFPAR    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CDIFANT    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CDIFANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-CPARCAT    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CPARCAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-PROXIMA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_PROXIMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-PENDENTE   PIC X(001)  VALUE 'N'.*/
            public StringBasis WTEM_PENDENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05         WTEM-ERRO       PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-PULO       PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_PULO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WS-FLAG-PROX      PIC  X(001) VALUE 'N'.*/
            public StringBasis WS_FLAG_PROX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05         NRCERTIF-ANT1     PIC  9(015) VALUE ZEROES.*/
            public IntBasis NRCERTIF_ANT1 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         NRCERTIF-ANT      PIC  9(015) VALUE ZEROES.*/
            public IntBasis NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05         NRPARCEL-ANT      PIC  9(004) VALUE ZEROES.*/
            public IntBasis NRPARCEL_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05         WDATA-SISTEMA-AUX.*/
            public GE0853S_WDATA_SISTEMA_AUX WDATA_SISTEMA_AUX { get; set; } = new GE0853S_WDATA_SISTEMA_AUX();
            public class GE0853S_WDATA_SISTEMA_AUX : VarBasis
            {
                /*"    10       WDATA-AUX-ANO     PIC  9(004).*/
                public IntBasis WDATA_AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-AUX-MES     PIC  9(002).*/
                public IntBasis WDATA_AUX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-AUX-DIA     PIC  9(002).*/
                public IntBasis WDATA_AUX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/
            }
            public GE0853S_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new GE0853S_WDATA_SISTEMA();
            public class GE0853S_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  9(004).*/
                public IntBasis WDATA_SIS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  9(002).*/
                public IntBasis WDATA_SIS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  9(002).*/
                public IntBasis WDATA_SIS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WDATA-MINVEN.*/
            }
            public GE0853S_WDATA_MINVEN WDATA_MINVEN { get; set; } = new GE0853S_WDATA_MINVEN();
            public class GE0853S_WDATA_MINVEN : VarBasis
            {
                /*"    10        WDATA-SAVEN      PIC 9(004).*/
                public IntBasis WDATA_SAVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        WDATA-SAVEN-R    REDEFINES              WDATA-SAVEN.*/
                private _REDEF_GE0853S_WDATA_SAVEN_R _wdata_saven_r { get; set; }
                public _REDEF_GE0853S_WDATA_SAVEN_R WDATA_SAVEN_R
                {
                    get { _wdata_saven_r = new _REDEF_GE0853S_WDATA_SAVEN_R(); _.Move(WDATA_SAVEN, _wdata_saven_r); VarBasis.RedefinePassValue(WDATA_SAVEN, _wdata_saven_r, WDATA_SAVEN); _wdata_saven_r.ValueChanged += () => { _.Move(_wdata_saven_r, WDATA_SAVEN); }; return _wdata_saven_r; }
                    set { VarBasis.RedefinePassValue(value, _wdata_saven_r, WDATA_SAVEN); }
                }  //Redefines
                public class _REDEF_GE0853S_WDATA_SAVEN_R : VarBasis
                {
                    /*"      15      WDATA-AAVEN      PIC 9(004).*/
                    public IntBasis WDATA_AAVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10        WDATA-T1VEN      PIC X(001).*/

                    public _REDEF_GE0853S_WDATA_SAVEN_R()
                    {
                        WDATA_AAVEN.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WDATA_T1VEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-MMVEN      PIC 9(002).*/
                public IntBasis WDATA_MMVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        WDATA-T2VEN      PIC X(001).*/
                public StringBasis WDATA_T2VEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-DDVEN      PIC 9(002).*/
                public IntBasis WDATA_DDVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WDATA-CORRENTE   PIC X(010).*/
            }
            public StringBasis WDATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05          WS-NSAS          PIC 9(005).*/
            public IntBasis WS_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05          WS-PAGO          PIC X(001).*/
            public StringBasis WS_PAGO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05          WDATA-MINATR.*/
            public GE0853S_WDATA_MINATR WDATA_MINATR { get; set; } = new GE0853S_WDATA_MINATR();
            public class GE0853S_WDATA_MINATR : VarBasis
            {
                /*"    10        WDATA-SAATR      PIC 9(004).*/
                public IntBasis WDATA_SAATR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        WDATA-SAATR-R    REDEFINES              WDATA-SAATR.*/
                private _REDEF_GE0853S_WDATA_SAATR_R _wdata_saatr_r { get; set; }
                public _REDEF_GE0853S_WDATA_SAATR_R WDATA_SAATR_R
                {
                    get { _wdata_saatr_r = new _REDEF_GE0853S_WDATA_SAATR_R(); _.Move(WDATA_SAATR, _wdata_saatr_r); VarBasis.RedefinePassValue(WDATA_SAATR, _wdata_saatr_r, WDATA_SAATR); _wdata_saatr_r.ValueChanged += () => { _.Move(_wdata_saatr_r, WDATA_SAATR); }; return _wdata_saatr_r; }
                    set { VarBasis.RedefinePassValue(value, _wdata_saatr_r, WDATA_SAATR); }
                }  //Redefines
                public class _REDEF_GE0853S_WDATA_SAATR_R : VarBasis
                {
                    /*"      15      WDATA-AAATR      PIC 9(004).*/
                    public IntBasis WDATA_AAATR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10        WDATA-T1ATR      PIC X(001).*/

                    public _REDEF_GE0853S_WDATA_SAATR_R()
                    {
                        WDATA_AAATR.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WDATA_T1ATR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-MMATR      PIC 9(002).*/
                public IntBasis WDATA_MMATR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10        WDATA-T2ATR      PIC X(001).*/
                public StringBasis WDATA_T2ATR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10        WDATA-DDATR      PIC 9(002).*/
                public IntBasis WDATA_DDATR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05          WIND-DATA        PIC 9(002).*/
            }
            public IntBasis WIND_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05   PARM-PROSOMU1.*/
            public GE0853S_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new GE0853S_PARM_PROSOMU1();
            public class GE0853S_PARM_PROSOMU1 : VarBasis
            {
                /*"    10   SU1-DATA1.*/
                public GE0853S_SU1_DATA1 SU1_DATA1 { get; set; } = new GE0853S_SU1_DATA1();
                public class GE0853S_SU1_DATA1 : VarBasis
                {
                    /*"      15   SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    10   SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"    10   SU1-DATA2.*/
                public GE0853S_SU1_DATA2 SU1_DATA2 { get; set; } = new GE0853S_SU1_DATA2();
                public class GE0853S_SU1_DATA2 : VarBasis
                {
                    /*"      15   SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"      15   SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"  05   WTAB-DATAS-UTEIS.*/
                }
            }
            public GE0853S_WTAB_DATAS_UTEIS WTAB_DATAS_UTEIS { get; set; } = new GE0853S_WTAB_DATAS_UTEIS();
            public class GE0853S_WTAB_DATAS_UTEIS : VarBasis
            {
                /*"    10 WTAB-DATATR OCCURS 15         PIC X(010).*/
                public ListBasis<StringBasis, string> WTAB_DATATR { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "10", "X(010)."), 15);
                /*"  05        WABEND.*/
            }
            public GE0853S_WABEND WABEND { get; set; } = new GE0853S_WABEND();
            public class GE0853S_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'GE0853S '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"GE0853S ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(005) VALUE '00001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05  WS-RESULT             PIC  9(006)    VALUE   ZEROS.*/
                public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05  AUX-ANO   PIC  9(004)    VALUE   ZEROS.*/
                public IntBasis AUX_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05  FILLER    REDEFINES      AUX-ANO.*/
                private _REDEF_GE0853S_FILLER_9 _filler_9 { get; set; }
                public _REDEF_GE0853S_FILLER_9 FILLER_9
                {
                    get { _filler_9 = new _REDEF_GE0853S_FILLER_9(); _.Move(AUX_ANO, _filler_9); VarBasis.RedefinePassValue(AUX_ANO, _filler_9, AUX_ANO); _filler_9.ValueChanged += () => { _.Move(_filler_9, AUX_ANO); }; return _filler_9; }
                    set { VarBasis.RedefinePassValue(value, _filler_9, AUX_ANO); }
                }  //Redefines
                public class _REDEF_GE0853S_FILLER_9 : VarBasis
                {
                    /*"          10 AUX-ANO1           PIC  9(002).*/
                    public IntBasis AUX_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"          10 AUX-ANO2           PIC  9(002).*/
                    public IntBasis AUX_ANO2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"01  REGISTRO-LINKAGE-GE0853S.*/

                    public _REDEF_GE0853S_FILLER_9()
                    {
                        AUX_ANO1.ValueChanged += OnValueChanged;
                        AUX_ANO2.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public GE0853S_REGISTRO_LINKAGE_GE0853S REGISTRO_LINKAGE_GE0853S { get; set; } = new GE0853S_REGISTRO_LINKAGE_GE0853S();
        public class GE0853S_REGISTRO_LINKAGE_GE0853S : VarBasis
        {
            /*"    10 LK-GE853-NUM-CERTIFICADO   PIC S9(15)V COMP-3.*/
            public DoubleBasis LK_GE853_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"    10 LK-GE853-NUM-PARCELA       PIC S9(04)  COMP.*/
            public IntBasis LK_GE853_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE853-VLR-PREMIO        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_GE853_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10 LK-GE853-SIT-CERTIFICADO   PIC  X(01).*/
            public StringBasis LK_GE853_SIT_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE853-SIT-PARCELA       PIC  X(01).*/
            public StringBasis LK_GE853_SIT_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE853-OPC-PAG-PARCELA   PIC S9(04)  COMP.*/
            public IntBasis LK_GE853_OPC_PAG_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE853-DT-CORRENTE       PIC  X(10).*/
            public StringBasis LK_GE853_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-DT-CORRENTE-18D   PIC  X(10).*/
            public StringBasis LK_GE853_DT_CORRENTE_18D { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-DT-MOVIMENTO      PIC  X(10).*/
            public StringBasis LK_GE853_DT_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-DT-MOVIMENTO-1Y   PIC  X(10).*/
            public StringBasis LK_GE853_DT_MOVIMENTO_1Y { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-COD-REJEICAO      PIC  X(10).*/
            public StringBasis LK_GE853_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    10 LK-GE853-COD-RETORNO       PIC  X(01).*/
            public StringBasis LK_GE853_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    10 LK-GE853-NUM-ERRO          PIC  S9(04)  COMP.*/
            public IntBasis LK_GE853_NUM_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    10 LK-GE853-MENSAGEM.*/
            public GE0853S_LK_GE853_MENSAGEM LK_GE853_MENSAGEM { get; set; } = new GE0853S_LK_GE853_MENSAGEM();
            public class GE0853S_LK_GE853_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE853-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE853_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE853-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE853_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public GE0853S_CDIFPAR CDIFPAR { get; set; } = new GE0853S_CDIFPAR();
        public GE0853S_CDIFANT CDIFANT { get; set; } = new GE0853S_CDIFANT();
        public GE0853S_CPARCAT CPARCAT { get; set; } = new GE0853S_CPARCAT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0853S_REGISTRO_LINKAGE_GE0853S GE0853S_REGISTRO_LINKAGE_GE0853S_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_GE0853S*/
        {
            try
            {
                this.REGISTRO_LINKAGE_GE0853S = GE0853S_REGISTRO_LINKAGE_GE0853S_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_GE0853S };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1016- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1017- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1018- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1040- MOVE '20000' TO WNR-EXEC-SQL. */
            _.Move("20000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1041- MOVE LK-GE853-DT-CORRENTE TO V1SIST-DTVENFIM-VE */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE, V1SIST_DTVENFIM_VE);

            /*" -1042- MOVE LK-GE853-DT-CORRENTE-18D TO V1SIST-DTVENFIM-CN */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE_18D, V1SIST_DTVENFIM_CN);

            /*" -1043- MOVE LK-GE853-DT-MOVIMENTO TO V1SIST-DTMOVABE */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_MOVIMENTO, V1SIST_DTMOVABE);

            /*" -1045- MOVE LK-GE853-DT-MOVIMENTO-1Y TO V1SIST-DTVENFIM-1Y */
            _.Move(REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_MOVIMENTO_1Y, V1SIST_DTVENFIM_1Y);

            /*" -1046- MOVE SPACES TO LK-GE853-COD-REJEICAO */
            _.Move("", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_REJEICAO);

            /*" -1047- MOVE SPACES TO LK-GE853-COD-RETORNO */
            _.Move("", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

            /*" -1049- MOVE SPACES TO LK-GE853-MSG-RETORNO WS-MSG-RETORNO */
            _.Move("", REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_MSG_RETORNO, WS_MSG_RETORNO);

            /*" -1051- MOVE ZEROS TO LK-GE853-SQLCODE */
            _.Move(0, REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_SQLCODE);

            /*" -1170- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -1173- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1174- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -1175- MOVE 'E' TO LK-GE853-COD-RETORNO */
                    _.Move("E", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1176- MOVE '20001' TO WNR-EXEC-SQL */
                    _.Move("20001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1177- MOVE 301 TO LK-GE853-NUM-ERRO */
                    _.Move(301, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                    /*" -1179- MOVE 'NENHUMA PARCELA EM ATRASO A PROCESSAR' TO WS-MSG-RETORNO */
                    _.Move("NENHUMA PARCELA EM ATRASO A PROCESSAR", WS_MSG_RETORNO);

                    /*" -1180- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1181- ELSE */
                }
                else
                {


                    /*" -1182- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1183- MOVE '20002' TO WNR-EXEC-SQL */
                    _.Move("20002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1185- MOVE 'ERRO NA CONSULTA DO CURSOR PRINCIPAL' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DO CURSOR PRINCIPAL", WS_MSG_RETORNO);

                    /*" -1186- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1187- END-IF */
                }


                /*" -1189- END-IF. */
            }


            /*" -1190- MOVE V0PROP-SITUACAO TO LK-GE853-SIT-CERTIFICADO */
            _.Move(V0PROP_SITUACAO, REGISTRO_LINKAGE_GE0853S.LK_GE853_SIT_CERTIFICADO);

            /*" -1191- MOVE V0HISC-DTVENCTO TO LK-GE853-DT-CORRENTE */
            _.Move(V0HISC_DTVENCTO, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE);

            /*" -1192- MOVE V0PARC-VLPRMTOT TO LK-GE853-VLR-PREMIO */
            _.Move(V0PARC_VLPRMTOT, REGISTRO_LINKAGE_GE0853S.LK_GE853_VLR_PREMIO);

            /*" -1193- MOVE V0HISC-SITUACAO TO LK-GE853-SIT-PARCELA */
            _.Move(V0HISC_SITUACAO, REGISTRO_LINKAGE_GE0853S.LK_GE853_SIT_PARCELA);

            /*" -1203- MOVE V0HISC-OPCAOPAG TO LK-GE853-OPC-PAG-PARCELA */
            _.Move(V0HISC_OPCAOPAG, REGISTRO_LINKAGE_GE0853S.LK_GE853_OPC_PAG_PARCELA);

            /*" -1205- PERFORM R1000-00-PROCESSA-PARC-ATRZD. */

            R1000_00_PROCESSA_PARC_ATRZD_SECTION();

            /*" -1210- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_1 */

            R0000_00_PRINCIPAL_DB_UPDATE_1();

            /*" -1213- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1214- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1215- MOVE '20003' TO WNR-EXEC-SQL */
                _.Move("20003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1217- MOVE 'ERRO NA ALTERACAO DA TABELA V0BANCO' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0BANCO", WS_MSG_RETORNO);

                /*" -1218- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1220- END-IF. */
            }


            /*" -1225- PERFORM R0000_00_PRINCIPAL_DB_UPDATE_2 */

            R0000_00_PRINCIPAL_DB_UPDATE_2();

            /*" -1228- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1229- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1230- MOVE '20004' TO WNR-EXEC-SQL */
                _.Move("20004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1232- MOVE 'ERRO NA ALTERACAO DA TABELA CEDENTE' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA CEDENTE", WS_MSG_RETORNO);

                /*" -1233- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1235- END-IF. */
            }


            /*" -1237- MOVE 'S' TO LK-GE853-COD-RETORNO */
            _.Move("S", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

            /*" -1238- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -1239- MOVE '20000' TO WNR-EXEC-SQL */
                _.Move("20000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1240- MOVE 313 TO LK-GE853-NUM-ERRO */
                _.Move(313, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1242- MOVE 'BOLETO DE PARCELA INADIMPLENTE GERADO COM SUCESSO' TO WS-MSG-RETORNO */
                _.Move("BOLETO DE PARCELA INADIMPLENTE GERADO COM SUCESSO", WS_MSG_RETORNO);

                /*" -1243- ELSE */
            }
            else
            {


                /*" -1244- MOVE '21000' TO WNR-EXEC-SQL */
                _.Move("21000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1245- MOVE 331 TO LK-GE853-NUM-ERRO */
                _.Move(331, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1247- MOVE 'PARCELA INADIMPLENTE RECOMANDADA P/ DEBITO CONTA' TO WS-MSG-RETORNO */
                _.Move("PARCELA INADIMPLENTE RECOMANDADA P/ DEBITO CONTA", WS_MSG_RETORNO);

                /*" -1249- END-IF */
            }


            /*" -1249- GO TO R9999-00-FINALIZA-ROT. */

            R9999_00_FINALIZA_ROT_SECTION(); //GOTO
            return;

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1170- EXEC SQL SELECT A.NRCERTIF, A.NRPARCEL, A.NRTIT, A.CODOPER, A.DTVENCTO, A.DTVENCTO + 30 DAYS, A.OPCAOPAG, A.VLPRMTOT, A.SITUACAO, A.OCORHIST, A.NRTITCOMP, B.NRCERTIF, B.FONTE, B.NUM_APOLICE, B.CODSUBES, B.CODPRODU, B.CODCLIEN, B.NRPARCE, B.SITUACAO, B.DTQITBCO, B.DTVENCTO, B.DTPROXVEN, B.NRPRIPARATZ, B.QTDPARATZ, VALUE(B.NUM_MATRICULA, 0), VALUE(B.DATA_ADMISSAO, '2001-01-01' ), B.TIMESTAMP, C.PERIPGTO, C.OPCAOCAP, VALUE(C.ESTR_COBR, ' ' ), VALUE(C.ORIG_PRODU, ' ' ), VALUE(C.TEM_SAF, ' ' ), VALUE(C.TEM_CDG, ' ' ), C.COBERADIC_PREMIO, C.CUSTOCAP_TOTAL, D.PERIPGTO, D.OPCAOPAG, VALUE(D.AGECTADEB, 0), VALUE(D.OPRCTADEB, 0), VALUE(D.NUMCTADEB, 0), VALUE(D.DIGCTADEB, 0), E.PRMVG + E.PRMAP - E.VLMULTA, E.PRMVG, E.PRMAP, E.DTVENCTO, E.OCORHIST, VALUE(E.SITUACAO, ' ' ) INTO :V0HISC-NRCERTIF, :V0HISC-NRPARCEL, :V0HISC-NRTIT, :V0HISC-CODOPER, :V0HISC-DTVENCTO, :V0HISC-DTVENCTO-30, :V0HISC-OPCAOPAG, :V0HISC-VLPRMTOT, :V0HISC-SITUACAO, :V0HISC-OCORHIST, :V0HISC-NRTITCOMP, :V0PROP-NRCERTIF, :V0PROP-FONTE, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-CODPRODU, :V0PROP-CODCLIEN, :V0PROP-NRPARCEL, :V0PROP-SITUACAO, :V0PROP-DTQITBCO, :V0PROP-DTVENCTO, :V0PROP-DTPROXVEN, :V0PROP-NRPRIPARATZ, :V0PROP-QTDPARATZ, :V0PROP-NRMATRFUN, :V0PROP-DTADMISSAO, :V0PROP-TIMESTAMP, :V0PROP-PERIPGTO, :V0PROP-OPCAOCAP, :V0PROP-ESTR-COBR, :V0PROP-ORIG-PRODU, :V0PROP-TEM-SAF, :V0PROP-TEM-CDG, :V0PROP-COBERADIC, :V0PROP-CUSTOCAP, :V0OPCP-PERIPGTO, :V0OPCP-OPCAOPAG, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0PARC-VLPRMTOT, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-DTVENCTO, :V0PARC-OCORHIST, :V0PARC-SITUACAO FROM SEGUROS.V0HISTCOBVA A, SEGUROS.V0PARCELVA E, SEGUROS.V0PROPOSTAVA B, SEGUROS.V0PRODUTOSVG C, SEGUROS.V0OPCAOPAGVA D WHERE A.NRCERTIF = :LK-GE853-NUM-CERTIFICADO AND A.NRPARCEL = :LK-GE853-NUM-PARCELA AND E.NRCERTIF = :LK-GE853-NUM-CERTIFICADO AND E.NRPARCEL = :LK-GE853-NUM-PARCELA AND E.SITUACAO IN ( ' ' , '0' , X'00' ) AND B.NRCERTIF = A.NRCERTIF AND B.SITUACAO NOT IN ( '2' , '4' ) AND B.DTPROXVEN <> '9999-12-31' AND D.NRCERTIF = B.NRCERTIF AND D.DTINIVIG <= B.DTPROXVEN AND D.DTTERVIG >= B.DTPROXVEN AND C.NUM_APOLICE = B.NUM_APOLICE AND C.CODSUBES = B.CODSUBES AND C.ESTR_COBR = 'MULT' AND C.ORIG_PRODU NOT IN ( 'ESPEC' , 'EMPRE' , 'GLOBAL' , 'ESPE1' , 'ESPE2' , 'ESPE3' ) ORDER BY A.NRCERTIF, A.NRPARCEL, A.NRTIT FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
                LK_GE853_NUM_CERTIFICADO = REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_CERTIFICADO.ToString(),
                LK_GE853_NUM_PARCELA = REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HISC_NRCERTIF, V0HISC_NRCERTIF);
                _.Move(executed_1.V0HISC_NRPARCEL, V0HISC_NRPARCEL);
                _.Move(executed_1.V0HISC_NRTIT, V0HISC_NRTIT);
                _.Move(executed_1.V0HISC_CODOPER, V0HISC_CODOPER);
                _.Move(executed_1.V0HISC_DTVENCTO, V0HISC_DTVENCTO);
                _.Move(executed_1.V0HISC_DTVENCTO_30, V0HISC_DTVENCTO_30);
                _.Move(executed_1.V0HISC_OPCAOPAG, V0HISC_OPCAOPAG);
                _.Move(executed_1.V0HISC_VLPRMTOT, V0HISC_VLPRMTOT);
                _.Move(executed_1.V0HISC_SITUACAO, V0HISC_SITUACAO);
                _.Move(executed_1.V0HISC_OCORHIST, V0HISC_OCORHIST);
                _.Move(executed_1.V0HISC_NRTITCOMP, V0HISC_NRTITCOMP);
                _.Move(executed_1.V0PROP_NRCERTIF, V0PROP_NRCERTIF);
                _.Move(executed_1.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(executed_1.V0PROP_NUM_APOLICE, V0PROP_NUM_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(executed_1.V0PROP_NRPARCEL, V0PROP_NRPARCEL);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(executed_1.V0PROP_DTVENCTO, V0PROP_DTVENCTO);
                _.Move(executed_1.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(executed_1.V0PROP_NRPRIPARATZ, V0PROP_NRPRIPARATZ);
                _.Move(executed_1.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(executed_1.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(executed_1.V0PROP_DTADMISSAO, V0PROP_DTADMISSAO);
                _.Move(executed_1.V0PROP_TIMESTAMP, V0PROP_TIMESTAMP);
                _.Move(executed_1.V0PROP_PERIPGTO, V0PROP_PERIPGTO);
                _.Move(executed_1.V0PROP_OPCAOCAP, V0PROP_OPCAOCAP);
                _.Move(executed_1.V0PROP_ESTR_COBR, V0PROP_ESTR_COBR);
                _.Move(executed_1.V0PROP_ORIG_PRODU, V0PROP_ORIG_PRODU);
                _.Move(executed_1.V0PROP_TEM_SAF, V0PROP_TEM_SAF);
                _.Move(executed_1.V0PROP_TEM_CDG, V0PROP_TEM_CDG);
                _.Move(executed_1.V0PROP_COBERADIC, V0PROP_COBERADIC);
                _.Move(executed_1.V0PROP_CUSTOCAP, V0PROP_CUSTOCAP);
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
                _.Move(executed_1.V0OPCP_OPCAOPAG, V0OPCP_OPCAOPAG);
                _.Move(executed_1.V0OPCP_AGECTADEB, V0OPCP_AGECTADEB);
                _.Move(executed_1.V0OPCP_OPRCTADEB, V0OPCP_OPRCTADEB);
                _.Move(executed_1.V0OPCP_NUMCTADEB, V0OPCP_NUMCTADEB);
                _.Move(executed_1.V0OPCP_DIGCTADEB, V0OPCP_DIGCTADEB);
                _.Move(executed_1.V0PARC_VLPRMTOT, V0PARC_VLPRMTOT);
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
                _.Move(executed_1.V0PARC_OCORHIST, V0PARC_OCORHIST);
                _.Move(executed_1.V0PARC_SITUACAO, V0PARC_SITUACAO);
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-1 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -1210- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_UPDATE_1_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_1_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-UPDATE-2 */
        public void R0000_00_PRINCIPAL_DB_UPDATE_2()
        {
            /*" -1225- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CEDENTE = 36 END-EXEC. */

            var r0000_00_PRINCIPAL_DB_UPDATE_2_Update1 = new R0000_00_PRINCIPAL_DB_UPDATE_2_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
            };

            R0000_00_PRINCIPAL_DB_UPDATE_2_Update1.Execute(r0000_00_PRINCIPAL_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-PARC-ATRZD-SECTION */
        private void R1000_00_PROCESSA_PARC_ATRZD_SECTION()
        {
            /*" -1261- MOVE '22000' TO WNR-EXEC-SQL. */
            _.Move("22000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1262- IF (V0HISC-DTVENCTO > V1SIST-DTVENFIM-CN) */

            if ((V0HISC_DTVENCTO > V1SIST_DTVENFIM_CN))
            {

                /*" -1263- MOVE 'I' TO LK-GE853-COD-RETORNO */
                _.Move("I", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1264- MOVE '22001' TO WNR-EXEC-SQL */
                _.Move("22001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1265- MOVE 314 TO LK-GE853-NUM-ERRO */
                _.Move(314, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1267- MOVE 'AGUARDANDO VENCIMENTO LIMITE DA PARCEL. ATRASADA' TO WS-MSG-RETORNO */
                _.Move("AGUARDANDO VENCIMENTO LIMITE DA PARCEL. ATRASADA", WS_MSG_RETORNO);

                /*" -1268- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1270- END-IF. */
            }


            /*" -1276- PERFORM R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1 */

            R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1();

            /*" -1279- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1280- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1281- MOVE '22002' TO WNR-EXEC-SQL */
                _.Move("22002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1283- MOVE 'ERRO NA CONSULTA DA TABELA V0BANCO ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0BANCO ", WS_MSG_RETORNO);

                /*" -1284- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1286- END-IF. */
            }


            /*" -1288- MOVE V0BANC-NRTIT TO W-NUMR-TITULO. */
            _.Move(V0BANC_NRTIT, W_NUMR_TITULO);

            /*" -1294- PERFORM R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2 */

            R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2();

            /*" -1297- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1298- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1299- MOVE '22003' TO WNR-EXEC-SQL */
                _.Move("22003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1301- MOVE 'ERRO NA CONSULTA DA TABELA CEDENTE ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA CEDENTE ", WS_MSG_RETORNO);

                /*" -1302- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1304- END-IF. */
            }


            /*" -1307- IF (V0PROP-NUM-APOLICE = 93010000890) AND (V0PROP-CODSUBES NOT = 17 ) AND (V0PROP-DTPROXVEN > '2001-09-30' ) */

            if ((V0PROP_NUM_APOLICE == 93010000890) && (V0PROP_CODSUBES != 17) && (V0PROP_DTPROXVEN > "2001-09-30"))
            {

                /*" -1308- MOVE 'I' TO LK-GE853-COD-RETORNO */
                _.Move("I", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1309- MOVE '22004' TO WNR-EXEC-SQL */
                _.Move("22004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1310- MOVE 315 TO LK-GE853-NUM-ERRO */
                _.Move(315, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1312- MOVE 'APOLICE/SUBGRUPO NAO PROCESSA PARCELA ATRASADAS ' TO WS-MSG-RETORNO */
                _.Move("APOLICE/SUBGRUPO NAO PROCESSA PARCELA ATRASADAS ", WS_MSG_RETORNO);

                /*" -1313- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1315- END-IF. */
            }


            /*" -1316- IF (V0PROP-SITUACAO = '8' ) */

            if ((V0PROP_SITUACAO == "8"))
            {

                /*" -1317- PERFORM R1050-00-CANCELA-PROPOSTA */

                R1050_00_CANCELA_PROPOSTA_SECTION();

                /*" -1318- MOVE 'C' TO LK-GE853-COD-RETORNO */
                _.Move("C", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1319- MOVE '22005' TO WNR-EXEC-SQL */
                _.Move("22005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1320- MOVE 316 TO LK-GE853-NUM-ERRO */
                _.Move(316, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1322- MOVE 'CERTIFICADO CANCELADO - SITUACAO PROPOSTA = 8 ' TO WS-MSG-RETORNO */
                _.Move("CERTIFICADO CANCELADO - SITUACAO PROPOSTA = 8 ", WS_MSG_RETORNO);

                /*" -1323- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1328- END-IF. */
            }


            /*" -1329- IF (V0OPCP-OPCAOPAG EQUAL '4' ) */

            if ((V0OPCP_OPCAOPAG == "4"))
            {

                /*" -1330- MOVE 'I' TO LK-GE853-COD-RETORNO */
                _.Move("I", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1331- MOVE '22006' TO WNR-EXEC-SQL */
                _.Move("22006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1332- MOVE 317 TO LK-GE853-NUM-ERRO */
                _.Move(317, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1334- MOVE 'CERTIF. NAO GERA PARC. ATRASADA - OPCAO-PAG = 4' TO WS-MSG-RETORNO */
                _.Move("CERTIF. NAO GERA PARC. ATRASADA - OPCAO-PAG = 4", WS_MSG_RETORNO);

                /*" -1335- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1340- END-IF. */
            }


            /*" -1342- IF (V0OPCP-PERIPGTO EQUAL 01) AND (V0HISC-DTVENCTO < V1SIST-DTVENFIM-1Y) */

            if ((V0OPCP_PERIPGTO == 01) && (V0HISC_DTVENCTO < V1SIST_DTVENFIM_1Y))
            {

                /*" -1343- PERFORM R1051-00-CANCELA-PARCELA */

                R1051_00_CANCELA_PARCELA_SECTION();

                /*" -1344- MOVE 'E' TO LK-GE853-COD-RETORNO */
                _.Move("E", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1345- MOVE '22007' TO WNR-EXEC-SQL */
                _.Move("22007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1346- MOVE 318 TO LK-GE853-NUM-ERRO */
                _.Move(318, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1348- MOVE 'PARC CANCELADA - DT-VENCIMENTO < QUE 1 ANO ' TO WS-MSG-RETORNO */
                _.Move("PARC CANCELADA - DT-VENCIMENTO < QUE 1 ANO ", WS_MSG_RETORNO);

                /*" -1349- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1351- END-IF */
            }


            /*" -1353- IF (V0OPCP-OPCAOPAG EQUAL '3' ) AND (V0HISC-OPCAOPAG EQUAL '1' OR '2' ) */

            if ((V0OPCP_OPCAOPAG == "3") && (V0HISC_OPCAOPAG.In("1", "2")))
            {

                /*" -1354- PERFORM R8110-00-ACERTA-OPCAOPAG */

                R8110_00_ACERTA_OPCAOPAG_SECTION();

                /*" -1355- MOVE 'E' TO LK-GE853-COD-RETORNO */
                _.Move("E", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1356- MOVE '22008' TO WNR-EXEC-SQL */
                _.Move("22008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1357- MOVE 319 TO LK-GE853-NUM-ERRO */
                _.Move(319, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1359- MOVE 'OPCAO-PAG DIVERGENTE - GEROU DIFERENCA PARC ' TO WS-MSG-RETORNO */
                _.Move("OPCAO-PAG DIVERGENTE - GEROU DIFERENCA PARC ", WS_MSG_RETORNO);

                /*" -1360- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1366- END-IF. */
            }


            /*" -1368- IF (V0HISC-NRPARCEL < V0PROP-NRPARCEL) AND (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0HISC_NRPARCEL < V0PROP_NRPARCEL) && (V0OPCP_OPCAOPAG == "3"))
            {

                /*" -1369- PERFORM R1051-00-CANCELA-PARCELA */

                R1051_00_CANCELA_PARCELA_SECTION();

                /*" -1370- MOVE 'E' TO LK-GE853-COD-RETORNO */
                _.Move("E", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1371- MOVE '22009' TO WNR-EXEC-SQL */
                _.Move("22009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1372- MOVE 320 TO LK-GE853-NUM-ERRO */
                _.Move(320, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1374- MOVE 'PARC CANCELADA-BOLETO C/ PARC ANTERIOR ATRASADA' TO WS-MSG-RETORNO */
                _.Move("PARC CANCELADA-BOLETO C/ PARC ANTERIOR ATRASADA", WS_MSG_RETORNO);

                /*" -1375- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1377- END-IF */
            }


            /*" -1378- IF (V0PARC-SITUACAO EQUAL '1' ) */

            if ((V0PARC_SITUACAO == "1"))
            {

                /*" -1379- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1380- MOVE '22014' TO WNR-EXEC-SQL */
                _.Move("22014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1382- MOVE 'PARCELA C/ SITUACAO PAGA NA V0PARCELVA ' TO WS-MSG-RETORNO */
                _.Move("PARCELA C/ SITUACAO PAGA NA V0PARCELVA ", WS_MSG_RETORNO);

                /*" -1383- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1385- END-IF. */
            }


            /*" -1386- MOVE V0PARC-PRMVG TO GUARDA-PRMVG. */
            _.Move(V0PARC_PRMVG, GUARDA_PRMVG);

            /*" -1388- MOVE V0PARC-PRMAP TO GUARDA-PRMAP. */
            _.Move(V0PARC_PRMAP, GUARDA_PRMAP);

            /*" -1390- COMPUTE GUARDA-PRMTOT = GUARDA-PRMVG + GUARDA-PRMAP. */
            GUARDA_PRMTOT.Value = GUARDA_PRMVG + GUARDA_PRMAP;

            /*" -1391- IF (GUARDA-PRMTOT EQUAL ZEROS) */

            if ((GUARDA_PRMTOT == 00))
            {

                /*" -1392- MOVE 'E' TO LK-GE853-COD-RETORNO */
                _.Move("E", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1393- MOVE '22015' TO WNR-EXEC-SQL */
                _.Move("22015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1394- MOVE 322 TO LK-GE853-NUM-ERRO */
                _.Move(322, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1396- MOVE 'CERT. DESPREZADO - PREMIO TOTAL DA PARC. ZERADO ' TO WS-MSG-RETORNO */
                _.Move("CERT. DESPREZADO - PREMIO TOTAL DA PARC. ZERADO ", WS_MSG_RETORNO);

                /*" -1397- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1399- END-IF. */
            }


            /*" -1400- COMPUTE GUARDA-PERC-VG = (100 * GUARDA-PRMVG) / GUARDA-PRMTOT */
            GUARDA_PERC_VG.Value = (100 * GUARDA_PRMVG) / GUARDA_PRMTOT;

            /*" -1405- COMPUTE GUARDA-PERC-AP = 100 - GUARDA-PERC-VG. */
            GUARDA_PERC_AP.Value = 100 - GUARDA_PERC_VG;

            /*" -1406- MOVE V0PARC-PRMVG TO V2PARC-PRMVG. */
            _.Move(V0PARC_PRMVG, V2PARC_PRMVG);

            /*" -1411- MOVE V0PARC-PRMAP TO V2PARC-PRMAP. */
            _.Move(V0PARC_PRMAP, V2PARC_PRMAP);

            /*" -1413- MOVE 0 TO V0MOVI-COUNT */
            _.Move(0, V0MOVI_COUNT);

            /*" -1423- PERFORM R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3 */

            R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3();

            /*" -1426- IF (V0MOVI-COUNT GREATER ZEROS) */

            if ((V0MOVI_COUNT > 00))
            {

                /*" -1427- PERFORM R6000-00-CANCELA-SEGURO */

                R6000_00_CANCELA_SEGURO_SECTION();

                /*" -1428- MOVE 'C' TO LK-GE853-COD-RETORNO */
                _.Move("C", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1429- MOVE '22016' TO WNR-EXEC-SQL */
                _.Move("22016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1430- MOVE 323 TO LK-GE853-NUM-ERRO */
                _.Move(323, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1432- MOVE 'CERT. DESPREZADO-J� POSSUI MOVIMENTO CANCELAMENTO' TO WS-MSG-RETORNO */
                _.Move("CERT. DESPREZADO-J� POSSUI MOVIMENTO CANCELAMENTO", WS_MSG_RETORNO);

                /*" -1433- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1439- END-IF. */
            }


            /*" -1440- IF (V0OPCP-OPCAOPAG EQUAL '5' ) */

            if ((V0OPCP_OPCAOPAG == "5"))
            {

                /*" -1441- PERFORM R8170-00-CONTA-PEND-CCRED */

                R8170_00_CONTA_PEND_CCRED_SECTION();

                /*" -1442- ELSE */
            }
            else
            {


                /*" -1443- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

                if ((V0OPCP_OPCAOPAG == "3"))
                {

                    /*" -1444- PERFORM R8155-00-CONTA-PEND-BOLETO */

                    R8155_00_CONTA_PEND_BOLETO_SECTION();

                    /*" -1445- ELSE */
                }
                else
                {


                    /*" -1446- PERFORM R8150-00-CONTA-PEND-CONTA */

                    R8150_00_CONTA_PEND_CONTA_SECTION();

                    /*" -1447- END-IF */
                }


                /*" -1455- END-IF. */
            }


            /*" -1456- IF (V0OPCP-OPCAOPAG EQUAL '5' ) */

            if ((V0OPCP_OPCAOPAG == "5"))
            {

                /*" -1457- IF (V0PROP-QTDPARATZ > 2) */

                if ((V0PROP_QTDPARATZ > 2))
                {

                    /*" -1458- PERFORM R6000-00-CANCELA-SEGURO */

                    R6000_00_CANCELA_SEGURO_SECTION();

                    /*" -1459- MOVE 'C' TO LK-GE853-COD-RETORNO */
                    _.Move("C", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1460- MOVE '22017' TO WNR-EXEC-SQL */
                    _.Move("22017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1461- MOVE 324 TO LK-GE853-NUM-ERRO */
                    _.Move(324, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                    /*" -1463- MOVE 'CERT. CANCELADO - COM MAIS DE 2 PARC ATRASADAS ' TO WS-MSG-RETORNO */
                    _.Move("CERT. CANCELADO - COM MAIS DE 2 PARC ATRASADAS ", WS_MSG_RETORNO);

                    /*" -1464- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1465- END-IF */
                }


                /*" -1466- MOVE 'I' TO LK-GE853-COD-RETORNO */
                _.Move("I", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1467- MOVE '22018' TO WNR-EXEC-SQL */
                _.Move("22018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1468- MOVE 325 TO LK-GE853-NUM-ERRO */
                _.Move(325, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -1470- MOVE 'PARCELA COM DEBITO EM CARTAO CREDITO ATRASADA' TO WS-MSG-RETORNO */
                _.Move("PARCELA COM DEBITO EM CARTAO CREDITO ATRASADA", WS_MSG_RETORNO);

                /*" -1471- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1476- END-IF. */
            }


            /*" -1477- IF (V0OPCP-PERIPGTO > 01) */

            if ((V0OPCP_PERIPGTO > 01))
            {

                /*" -1478- IF (V0PROP-QTDPARATZ > 0) */

                if ((V0PROP_QTDPARATZ > 0))
                {

                    /*" -1479- PERFORM R6000-00-CANCELA-SEGURO */

                    R6000_00_CANCELA_SEGURO_SECTION();

                    /*" -1480- MOVE 'C' TO LK-GE853-COD-RETORNO */
                    _.Move("C", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1481- MOVE '22018' TO WNR-EXEC-SQL */
                    _.Move("22018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1482- MOVE 326 TO LK-GE853-NUM-ERRO */
                    _.Move(326, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                    /*" -1484- MOVE 'CERT. CANCELADO - PARCELAS ANUAIS ATRASADAS' TO WS-MSG-RETORNO */
                    _.Move("CERT. CANCELADO - PARCELAS ANUAIS ATRASADAS", WS_MSG_RETORNO);

                    /*" -1485- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1486- END-IF */
                }


                /*" -1491- END-IF */
            }


            /*" -1492- IF (V0PROP-QTDPARATZ EQUAL 0 OR 1) */

            if ((V0PROP_QTDPARATZ.In("0", "1")))
            {

                /*" -1493- PERFORM R3000-00-TRATA-1A-2A-PARCELA */

                R3000_00_TRATA_1A_2A_PARCELA_SECTION();

                /*" -1494- ELSE */
            }
            else
            {


                /*" -1495- IF (V0PROP-QTDPARATZ EQUAL 2) */

                if ((V0PROP_QTDPARATZ == 2))
                {

                    /*" -1496- PERFORM R4000-00-TRATA-3APARCELA */

                    R4000_00_TRATA_3APARCELA_SECTION();

                    /*" -1497- ELSE */
                }
                else
                {


                    /*" -1498- PERFORM R6000-00-CANCELA-SEGURO */

                    R6000_00_CANCELA_SEGURO_SECTION();

                    /*" -1499- MOVE 'C' TO LK-GE853-COD-RETORNO */
                    _.Move("C", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1500- MOVE '22019' TO WNR-EXEC-SQL */
                    _.Move("22019", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1501- MOVE 324 TO LK-GE853-NUM-ERRO */
                    _.Move(324, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                    /*" -1503- MOVE 'CERT. CANCELADO - COM MAIS DE 2 PARC ATRASADAS' TO WS-MSG-RETORNO */
                    _.Move("CERT. CANCELADO - COM MAIS DE 2 PARC ATRASADAS", WS_MSG_RETORNO);

                    /*" -1504- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1505- END-IF */
                }


                /*" -1505- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-PARC-ATRZD-DB-SELECT-1 */
        public void R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1()
        {
            /*" -1276- EXEC SQL SELECT NRTIT INTO :V0BANC-NRTIT FROM SEGUROS.V0BANCO WHERE BANCO = 104 WITH UR END-EXEC. */

            var r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1 = new R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1.Execute(r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0BANC_NRTIT, V0BANC_NRTIT);
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1514- PERFORM R1000_90_LEITURA_DB_UPDATE_1 */

            R1000_90_LEITURA_DB_UPDATE_1();

            /*" -1517- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1518- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1519- MOVE '20020' TO WNR-EXEC-SQL */
                _.Move("20020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1521- MOVE 'ERRO NA ALTERACAO DA TABELA V0BANCO' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0BANCO", WS_MSG_RETORNO);

                /*" -1522- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1524- END-IF */
            }


            /*" -1529- PERFORM R1000_90_LEITURA_DB_UPDATE_2 */

            R1000_90_LEITURA_DB_UPDATE_2();

            /*" -1532- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1533- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1534- MOVE '22021' TO WNR-EXEC-SQL */
                _.Move("22021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1536- MOVE 'ERRO NA ALTERACAO DA TABELA CEDENTE' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA CEDENTE", WS_MSG_RETORNO);

                /*" -1537- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1538- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA-DB-UPDATE-1 */
        public void R1000_90_LEITURA_DB_UPDATE_1()
        {
            /*" -1514- EXEC SQL UPDATE SEGUROS.V0BANCO SET NRTIT = :V0BANC-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE BANCO = 104 END-EXEC */

            var r1000_90_LEITURA_DB_UPDATE_1_Update1 = new R1000_90_LEITURA_DB_UPDATE_1_Update1()
            {
                V0BANC_NRTIT = V0BANC_NRTIT.ToString(),
            };

            R1000_90_LEITURA_DB_UPDATE_1_Update1.Execute(r1000_90_LEITURA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-PARC-ATRZD-DB-SELECT-2 */
        public void R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2()
        {
            /*" -1294- EXEC SQL SELECT NUM_TITULO INTO :CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 36 WITH UR END-EXEC. */

            var r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2_Query1 = new R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2_Query1.Execute(r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R1000-90-LEITURA-DB-UPDATE-2 */
        public void R1000_90_LEITURA_DB_UPDATE_2()
        {
            /*" -1529- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CEDENTE = 36 END-EXEC */

            var r1000_90_LEITURA_DB_UPDATE_2_Update1 = new R1000_90_LEITURA_DB_UPDATE_2_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
            };

            R1000_90_LEITURA_DB_UPDATE_2_Update1.Execute(r1000_90_LEITURA_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-PARC-ATRZD-DB-SELECT-3 */
        public void R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3()
        {
            /*" -1423- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :V0MOVI-COUNT FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' AND DATA_INCLUSAO IS NULL AND DATA_AVERBACAO IS NOT NULL AND COD_OPERACAO BETWEEN 400 AND 499 WITH UR END-EXEC. */

            var r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1 = new R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1.Execute(r1000_00_PROCESSA_PARC_ATRZD_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVI_COUNT, V0MOVI_COUNT);
            }


        }

        [StopWatch]
        /*" R1050-00-CANCELA-PROPOSTA-SECTION */
        private void R1050_00_CANCELA_PROPOSTA_SECTION()
        {
            /*" -1550- MOVE '21050' TO WNR-EXEC-SQL. */
            _.Move("21050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1552- PERFORM R1051-00-CANCELA-PARCELA */

            R1051_00_CANCELA_PARCELA_SECTION();

            /*" -1560- PERFORM R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1 */

            R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1();

            /*" -1563- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1564- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1565- MOVE '21051' TO WNR-EXEC-SQL */
                _.Move("21051", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1567- MOVE 'ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA", WS_MSG_RETORNO);

                /*" -1568- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1568- END-IF. */
            }


        }

        [StopWatch]
        /*" R1050-00-CANCELA-PROPOSTA-DB-UPDATE-1 */
        public void R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -1560- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '2' , CODOPER = 403, CODUSU = 'GE0853S' , DTMOVTO = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF END-EXEC. */

            var r1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 = new R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1.Execute(r1050_00_CANCELA_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1051-00-CANCELA-PARCELA-SECTION */
        private void R1051_00_CANCELA_PARCELA_SECTION()
        {
            /*" -1579- MOVE '21051' TO WNR-EXEC-SQL. */
            _.Move("21051", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1586- PERFORM R1051_00_CANCELA_PARCELA_DB_UPDATE_1 */

            R1051_00_CANCELA_PARCELA_DB_UPDATE_1();

            /*" -1589- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1590- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1591- MOVE '21052' TO WNR-EXEC-SQL */
                _.Move("21052", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1593- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -1594- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1596- END-IF. */
            }


            /*" -1602- PERFORM R1051_00_CANCELA_PARCELA_DB_UPDATE_2 */

            R1051_00_CANCELA_PARCELA_DB_UPDATE_2();

            /*" -1605- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1606- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1607- MOVE '21053' TO WNR-EXEC-SQL */
                _.Move("21053", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1609- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                /*" -1610- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1612- END-IF. */
            }


            /*" -1620- PERFORM R1051_00_CANCELA_PARCELA_DB_UPDATE_3 */

            R1051_00_CANCELA_PARCELA_DB_UPDATE_3();

            /*" -1623- IF (SQLCODE NOT EQUAL ZEROES AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1624- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1625- MOVE '21054' TO WNR-EXEC-SQL */
                _.Move("21054", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1627- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCONTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCONTAVA", WS_MSG_RETORNO);

                /*" -1628- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1628- END-IF. */
            }


        }

        [StopWatch]
        /*" R1051-00-CANCELA-PARCELA-DB-UPDATE-1 */
        public void R1051_00_CANCELA_PARCELA_DB_UPDATE_1()
        {
            /*" -1586- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' , TIMESTAMP = CURRENT_TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND SITUACAO IN ( ' ' , '0' ) END-EXEC. */

            var r1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1 = new R1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1.Execute(r1051_00_CANCELA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1051_99_SAIDA*/

        [StopWatch]
        /*" R1051-00-CANCELA-PARCELA-DB-UPDATE-2 */
        public void R1051_00_CANCELA_PARCELA_DB_UPDATE_2()
        {
            /*" -1602- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND SITUACAO IN ( ' ' , '0' , '5' , X'00' ) END-EXEC. */

            var r1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1 = new R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1.Execute(r1051_00_CANCELA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1100-00-TRATA-V0DIFPARCELVA-SECTION */
        private void R1100_00_TRATA_V0DIFPARCELVA_SECTION()
        {
            /*" -1642- MOVE '21100' TO WNR-EXEC-SQL. */
            _.Move("21100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1654- PERFORM R1100_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1 */

            R1100_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1();

            /*" -1658- MOVE '21101' TO WNR-EXEC-SQL. */
            _.Move("21101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1658- PERFORM R1100_00_TRATA_V0DIFPARCELVA_DB_OPEN_1 */

            R1100_00_TRATA_V0DIFPARCELVA_DB_OPEN_1();

            /*" -1661- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1662- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1663- MOVE '21102' TO WNR-EXEC-SQL */
                _.Move("21102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1665- MOVE 'ERRO NA CONSULTA DO CURSOR CDIFPAR ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DO CURSOR CDIFPAR ", WS_MSG_RETORNO);

                /*" -1666- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1670- END-IF. */
            }


            /*" -1671- MOVE SPACES TO WFIM-CDIFPAR */
            _.Move("", AREA_DE_WORK.WFIM_CDIFPAR);

            /*" -1672- MOVE V0PARC-VLPRMTOT TO WHOST-VLPREMIO. */
            _.Move(V0PARC_VLPRMTOT, WHOST_VLPREMIO);

            /*" -1673- MOVE V0PARC-PRMVG TO WHOST-PRMVG. */
            _.Move(V0PARC_PRMVG, WHOST_PRMVG);

            /*" -1675- MOVE V0PARC-PRMAP TO WHOST-PRMAP. */
            _.Move(V0PARC_PRMAP, WHOST_PRMAP);

            /*" -1677- PERFORM R1110-00-FETCH-CDIFPAR. */

            R1110_00_FETCH_CDIFPAR_SECTION();

            /*" -1678- IF (WFIM-CDIFPAR NOT EQUAL SPACES) */

            if ((!AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty()))
            {

                /*" -1679- GO TO R1100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;

                /*" -1679- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1100_10_LOOP_CDIFPAR */

            R1100_10_LOOP_CDIFPAR();

        }

        [StopWatch]
        /*" R1100-00-TRATA-V0DIFPARCELVA-DB-DECLARE-1 */
        public void R1100_00_TRATA_V0DIFPARCELVA_DB_DECLARE_1()
        {
            /*" -1654- EXEC SQL DECLARE CDIFPAR CURSOR FOR SELECT NRPARCEL, NRPARCELDIF, CODOPER, PRMDIFVG + PRMDIFAP, PRMDIFVG, PRMDIFAP FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND SITUACAO = ' ' ORDER BY NRPARCEL, NRPARCELDIF, CODOPER END-EXEC. */
            CDIFPAR = new GE0853S_CDIFPAR(true);
            string GetQuery_CDIFPAR()
            {
                var query = @$"SELECT NRPARCEL
							, 
							NRPARCELDIF
							, 
							CODOPER
							, 
							PRMDIFVG + PRMDIFAP
							, 
							PRMDIFVG
							, 
							PRMDIFAP 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0HISC_NRCERTIF}' 
							AND SITUACAO = ' ' 
							ORDER BY NRPARCEL
							, NRPARCELDIF
							, CODOPER";

                return query;
            }
            CDIFPAR.GetQueryEvent += GetQuery_CDIFPAR;

        }

        [StopWatch]
        /*" R1100-00-TRATA-V0DIFPARCELVA-DB-OPEN-1 */
        public void R1100_00_TRATA_V0DIFPARCELVA_DB_OPEN_1()
        {
            /*" -1658- EXEC SQL OPEN CDIFPAR END-EXEC. */

            CDIFPAR.Open();

        }

        [StopWatch]
        /*" R4000-00-TRATA-3APARCELA-DB-DECLARE-1 */
        public void R4000_00_TRATA_3APARCELA_DB_DECLARE_1()
        {
            /*" -2066- EXEC SQL DECLARE CDIFANT CURSOR FOR SELECT NRPARCELDIF, PRMDIFVG, PRMDIFAP, CODOPER FROM SEGUROS.V0DIFPARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC. */
            CDIFANT = new GE0853S_CDIFANT(true);
            string GetQuery_CDIFANT()
            {
                var query = @$"SELECT NRPARCELDIF
							, 
							PRMDIFVG
							, 
							PRMDIFAP
							, 
							CODOPER 
							FROM SEGUROS.V0DIFPARCELVA 
							WHERE NRCERTIF = '{V0HISC_NRCERTIF}' 
							AND NRPARCEL = '{V0HISC_NRPARCEL}'";

                return query;
            }
            CDIFANT.GetQueryEvent += GetQuery_CDIFANT;

        }

        [StopWatch]
        /*" R1051-00-CANCELA-PARCELA-DB-UPDATE-3 */
        public void R1051_00_CANCELA_PARCELA_DB_UPDATE_3()
        {
            /*" -1620- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' , TIMESTAMP = CURRENT_TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND TIPLANC = '1' AND SITUACAO IN ( ' ' , '0' ) END-EXEC. */

            var r1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1 = new R1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1.Execute(r1051_00_CANCELA_PARCELA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1100-10-LOOP-CDIFPAR */
        private void R1100_10_LOOP_CDIFPAR(bool isPerform = false)
        {
            /*" -1685- IF (V0DIFP-CODOPER > 599) AND (V0DIFP-CODOPER < 700) */

            if ((V0DIFP_CODOPER > 599) && (V0DIFP_CODOPER < 700))
            {

                /*" -1686- COMPUTE WHOST-PRMVG = WHOST-PRMVG - V0DIFP-PRMDIFVG */
                WHOST_PRMVG.Value = WHOST_PRMVG - V0DIFP_PRMDIFVG;

                /*" -1687- COMPUTE WHOST-PRMAP = WHOST-PRMAP - V0DIFP-PRMDIFAP */
                WHOST_PRMAP.Value = WHOST_PRMAP - V0DIFP_PRMDIFAP;

                /*" -1688- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP */
                WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;

                /*" -1695- ELSE */
            }
            else
            {


                /*" -1697- IF (V0DIFP-CODOPER > 399) AND (V0DIFP-CODOPER < 500) */

                if ((V0DIFP_CODOPER > 399) && (V0DIFP_CODOPER < 500))
                {

                    /*" -1698- IF (V0HISC-NRPARCEL EQUAL NRPARCEL-ANT) */

                    if ((V0HISC_NRPARCEL == AREA_DE_WORK.NRPARCEL_ANT))
                    {

                        /*" -1699- COMPUTE WHOST-PRMVG = WHOST-PRMVG + V0DIFP-PRMDIFVG */
                        WHOST_PRMVG.Value = WHOST_PRMVG + V0DIFP_PRMDIFVG;

                        /*" -1700- COMPUTE WHOST-PRMAP = WHOST-PRMAP + V0DIFP-PRMDIFAP */
                        WHOST_PRMAP.Value = WHOST_PRMAP + V0DIFP_PRMDIFAP;

                        /*" -1701- COMPUTE WHOST-VLPREMIO = WHOST-PRMVG + WHOST-PRMAP */
                        WHOST_VLPREMIO.Value = WHOST_PRMVG + WHOST_PRMAP;

                        /*" -1702- ELSE */
                    }
                    else
                    {


                        /*" -1703- PERFORM R1112-00-UPDT-DIFPARCEL-SIT */

                        R1112_00_UPDT_DIFPARCEL_SIT_SECTION();

                        /*" -1704- GO TO R1100-20-LE-CDIFPAR */

                        R1100_20_LE_CDIFPAR(); //GOTO
                        return;

                        /*" -1705- END-IF */
                    }


                    /*" -1706- ELSE */
                }
                else
                {


                    /*" -1707- PERFORM R1112-00-UPDT-DIFPARCEL-SIT */

                    R1112_00_UPDT_DIFPARCEL_SIT_SECTION();

                    /*" -1708- GO TO R1100-20-LE-CDIFPAR */

                    R1100_20_LE_CDIFPAR(); //GOTO
                    return;

                    /*" -1709- END-IF */
                }


                /*" -1711- END-IF. */
            }


            /*" -1713- MOVE V0DIFP-CODOPER TO V3DIFP-CODOPER. */
            _.Move(V0DIFP_CODOPER, V3DIFP_CODOPER);

            /*" -1713- PERFORM R1111-00-UPDT-DIFPARCEL-COMPL. */

            R1111_00_UPDT_DIFPARCEL_COMPL_SECTION();

        }

        [StopWatch]
        /*" R1100-20-LE-CDIFPAR */
        private void R1100_20_LE_CDIFPAR(bool isPerform = false)
        {
            /*" -1719- PERFORM R1110-00-FETCH-CDIFPAR. */

            R1110_00_FETCH_CDIFPAR_SECTION();

            /*" -1720- IF (WFIM-CDIFPAR EQUAL SPACES) */

            if ((AREA_DE_WORK.WFIM_CDIFPAR.IsEmpty()))
            {

                /*" -1721- GO TO R1100-10-LOOP-CDIFPAR */

                R1100_10_LOOP_CDIFPAR(); //GOTO
                return;

                /*" -1721- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-CDIFPAR-SECTION */
        private void R1110_00_FETCH_CDIFPAR_SECTION()
        {
            /*" -1733- MOVE '21110' TO WNR-EXEC-SQL. */
            _.Move("21110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1740- PERFORM R1110_00_FETCH_CDIFPAR_DB_FETCH_1 */

            R1110_00_FETCH_CDIFPAR_DB_FETCH_1();

            /*" -1743- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1744- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -1744- PERFORM R1110_00_FETCH_CDIFPAR_DB_CLOSE_1 */

                    R1110_00_FETCH_CDIFPAR_DB_CLOSE_1();

                    /*" -1746- MOVE 'S' TO WFIM-CDIFPAR */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFPAR);

                    /*" -1747- ELSE */
                }
                else
                {


                    /*" -1748- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1749- MOVE '21111' TO WNR-EXEC-SQL */
                    _.Move("21111", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1751- MOVE 'ERRO NA ABERTURA DO CURSOR CDIFPAR ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ABERTURA DO CURSOR CDIFPAR ", WS_MSG_RETORNO);

                    /*" -1752- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1753- END-IF */
                }


                /*" -1753- END-IF. */
            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-CDIFPAR-DB-FETCH-1 */
        public void R1110_00_FETCH_CDIFPAR_DB_FETCH_1()
        {
            /*" -1740- EXEC SQL FETCH CDIFPAR INTO :V0DIFP-NRPARCEL, :V0DIFP-NRPARCELDIF, :V0DIFP-CODOPER, :V0DIFP-VLPRMTOT, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP END-EXEC. */

            if (CDIFPAR.Fetch())
            {
                _.Move(CDIFPAR.V0DIFP_NRPARCEL, V0DIFP_NRPARCEL);
                _.Move(CDIFPAR.V0DIFP_NRPARCELDIF, V0DIFP_NRPARCELDIF);
                _.Move(CDIFPAR.V0DIFP_CODOPER, V0DIFP_CODOPER);
                _.Move(CDIFPAR.V0DIFP_VLPRMTOT, V0DIFP_VLPRMTOT);
                _.Move(CDIFPAR.V0DIFP_PRMDIFVG, V0DIFP_PRMDIFVG);
                _.Move(CDIFPAR.V0DIFP_PRMDIFAP, V0DIFP_PRMDIFAP);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-CDIFPAR-DB-CLOSE-1 */
        public void R1110_00_FETCH_CDIFPAR_DB_CLOSE_1()
        {
            /*" -1744- EXEC SQL CLOSE CDIFPAR END-EXEC */

            CDIFPAR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1111-00-UPDT-DIFPARCEL-COMPL-SECTION */
        private void R1111_00_UPDT_DIFPARCEL_COMPL_SECTION()
        {
            /*" -1765- MOVE '21111' TO WNR-EXEC-SQL. */
            _.Move("21111", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1777- PERFORM R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1 */

            R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1();

            /*" -1786- IF (SQLCODE EQUAL -803) */

            if ((DB.SQLCODE == -803))
            {

                /*" -1787- DISPLAY 'ERRO AO ATUALIZAR A TABELA V0DIFPARCELVA: ' */
                _.Display($"ERRO AO ATUALIZAR A TABELA V0DIFPARCELVA: ");

                /*" -1788- DISPLAY 'V0HISC-NRCERTIF = ' V0HISC-NRCERTIF */
                _.Display($"V0HISC-NRCERTIF = {V0HISC_NRCERTIF}");

                /*" -1789- DISPLAY 'V0DIFP-NRPARCEL = ' V0DIFP-NRPARCEL */
                _.Display($"V0DIFP-NRPARCEL = {V0DIFP_NRPARCEL}");

                /*" -1790- DISPLAY 'V0DIFP-NRPARCELDIF = ' V0DIFP-NRPARCELDIF */
                _.Display($"V0DIFP-NRPARCELDIF = {V0DIFP_NRPARCELDIF}");

                /*" -1791- DISPLAY 'V0HISC-NRPARCEL = ' V0HISC-NRPARCEL */
                _.Display($"V0HISC-NRPARCEL = {V0HISC_NRPARCEL}");

                /*" -1792- DISPLAY 'V0DIFP-CODOPER  = ' V0DIFP-CODOPER */
                _.Display($"V0DIFP-CODOPER  = {V0DIFP_CODOPER}");

                /*" -1793- DISPLAY 'V0DIFP-VLPRMTOT = ' V0DIFP-VLPRMTOT */
                _.Display($"V0DIFP-VLPRMTOT = {V0DIFP_VLPRMTOT}");

                /*" -1794- DISPLAY 'V0DIFP-PRMDIFVG = ' V0DIFP-PRMDIFVG */
                _.Display($"V0DIFP-PRMDIFVG = {V0DIFP_PRMDIFVG}");

                /*" -1795- DISPLAY 'V0DIFP-PRMDIFAP = ' V0DIFP-PRMDIFAP */
                _.Display($"V0DIFP-PRMDIFAP = {V0DIFP_PRMDIFAP}");

                /*" -1796- DISPLAY 'V3DIFP-CODOPER  = ' V3DIFP-CODOPER */
                _.Display($"V3DIFP-CODOPER  = {V3DIFP_CODOPER}");

                /*" -1797- DISPLAY 'V0PARC-PRMVG    = ' V0PARC-PRMVG */
                _.Display($"V0PARC-PRMVG    = {V0PARC_PRMVG}");

                /*" -1798- DISPLAY 'V0PARC-PRMAP    = ' V0PARC-PRMAP */
                _.Display($"V0PARC-PRMAP    = {V0PARC_PRMAP}");

                /*" -1799- DISPLAY ' ' */
                _.Display($" ");

                /*" -1800- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1801- MOVE '21112' TO WNR-EXEC-SQL */
                _.Move("21112", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1803- MOVE 'ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                /*" -1804- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1805- ELSE */
            }
            else
            {


                /*" -1806- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

                if ((!DB.SQLCODE.In("00", "+100")))
                {

                    /*" -1807- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -1808- MOVE '21113' TO WNR-EXEC-SQL */
                    _.Move("21113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1810- MOVE 'ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                    /*" -1811- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -1812- END-IF */
                }


                /*" -1812- END-IF. */
            }


        }

        [StopWatch]
        /*" R1111-00-UPDT-DIFPARCEL-COMPL-DB-UPDATE-1 */
        public void R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1()
        {
            /*" -1777- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0HISC-NRPARCEL, CODOPER = :V3DIFP-CODOPER, PRMDEVVG = :V0PARC-PRMVG, PRMDEVAP = :V0PARC-PRMAP, SITUACAO = '1' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0DIFP-NRPARCEL AND NRPARCELDIF = :V0DIFP-NRPARCELDIF AND CODOPER = :V0DIFP-CODOPER AND SITUACAO = ' ' END-EXEC. */

            var r1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1 = new R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1()
            {
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V3DIFP_CODOPER = V3DIFP_CODOPER.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0DIFP_NRPARCELDIF = V0DIFP_NRPARCELDIF.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
            };

            R1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1.Execute(r1111_00_UPDT_DIFPARCEL_COMPL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1111_99_SAIDA*/

        [StopWatch]
        /*" R1112-00-UPDT-DIFPARCEL-SIT-SECTION */
        private void R1112_00_UPDT_DIFPARCEL_SIT_SECTION()
        {
            /*" -1824- MOVE '21114' TO WNR-EXEC-SQL. */
            _.Move("21114", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1832- PERFORM R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1 */

            R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1();

            /*" -1835- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1836- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1837- MOVE '21115' TO WNR-EXEC-SQL */
                _.Move("21115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1839- MOVE 'ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                /*" -1840- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1841- END-IF. */
            }


        }

        [StopWatch]
        /*" R1112-00-UPDT-DIFPARCEL-SIT-DB-UPDATE-1 */
        public void R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1()
        {
            /*" -1832- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0DIFP-NRPARCEL AND NRPARCELDIF = :V0DIFP-NRPARCELDIF AND CODOPER = :V0DIFP-CODOPER AND SITUACAO = ' ' END-EXEC. */

            var r1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1 = new R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1()
            {
                V0DIFP_NRPARCELDIF = V0DIFP_NRPARCELDIF.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
                V0DIFP_CODOPER = V0DIFP_CODOPER.ToString(),
            };

            R1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1.Execute(r1112_00_UPDT_DIFPARCEL_SIT_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1112_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDT-SIT-SUSPENSA-SECTION */
        private void R2000_00_UPDT_SIT_SUSPENSA_SECTION()
        {
            /*" -1851- MOVE '22000' TO WNR-EXEC-SQL. */
            _.Move("22000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1858- PERFORM R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1 */

            R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1();

            /*" -1861- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1862- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1863- MOVE '22001' TO WNR-EXEC-SQL */
                _.Move("22001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1865- MOVE 'ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA ", WS_MSG_RETORNO);

                /*" -1866- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1866- END-IF. */
            }


        }

        [StopWatch]
        /*" R2000-00-UPDT-SIT-SUSPENSA-DB-UPDATE-1 */
        public void R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1()
        {
            /*" -1858- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '6' , NRPRIPARATZ = :V0HISC-NRPARCEL, QTDPARATZ = 1, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF END-EXEC. */

            var r2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1 = new R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1()
            {
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1.Execute(r2000_00_UPDT_SIT_SUSPENSA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TRATA-1A-2A-PARCELA-SECTION */
        private void R3000_00_TRATA_1A_2A_PARCELA_SECTION()
        {
            /*" -1878- MOVE '23000' TO WNR-EXEC-SQL. */
            _.Move("23000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1880- PERFORM R2000-00-UPDT-SIT-SUSPENSA */

            R2000_00_UPDT_SIT_SUSPENSA_SECTION();

            /*" -1882- COMPUTE V0PROP-QTDPARATZ = V0PROP-QTDPARATZ + 1 */
            V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ + 1;

            /*" -1889- MOVE 122 TO WHOST-CODOPER. */
            _.Move(122, WHOST_CODOPER);

            /*" -1890- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -1891- PERFORM R5500-00-GERA-ATRASADAS */

                R5500_00_GERA_ATRASADAS_SECTION();

                /*" -1892- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -1893- ELSE */
            }
            else
            {


                /*" -1894- PERFORM R5000-00-GERA-PROXIMA */

                R5000_00_GERA_PROXIMA_SECTION();

                /*" -1896- END-IF. */
            }


            /*" -1897- IF (WTEM-PROXIMA EQUAL 'N' ) */

            if ((AREA_DE_WORK.WTEM_PROXIMA == "N"))
            {

                /*" -1898- GO TO R3000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;

                /*" -1904- END-IF. */
            }


            /*" -1911- PERFORM R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1 */

            R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1();

            /*" -1914- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1915- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1916- MOVE '23001' TO WNR-EXEC-SQL */
                _.Move("23001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1918- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA ", WS_MSG_RETORNO);

                /*" -1919- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1921- END-IF. */
            }


            /*" -1923- MOVE 121 TO WHOST-CODOPER. */
            _.Move(121, WHOST_CODOPER);

            /*" -1924- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -1925- MOVE V0PROP-NRPARCEL TO WHOST-NRPARCEL-1 */
                _.Move(V0PROP_NRPARCEL, WHOST_NRPARCEL_1);

                /*" -1926- ELSE */
            }
            else
            {


                /*" -1927- MOVE V0HISC-NRPARCEL TO WHOST-NRPARCEL-1 */
                _.Move(V0HISC_NRPARCEL, WHOST_NRPARCEL_1);

                /*" -1929- END-IF. */
            }


            /*" -1944- PERFORM R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1 */

            R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1();

            /*" -1947- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -1948- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1949- MOVE '23002' TO WNR-EXEC-SQL */
                _.Move("23002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1951- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ", WS_MSG_RETORNO);

                /*" -1952- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1954- END-IF. */
            }


            /*" -1956- MOVE 122 TO WHOST-CODOPER. */
            _.Move(122, WHOST_CODOPER);

            /*" -1971- PERFORM R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2 */

            R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2();

            /*" -1974- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -1975- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -1976- MOVE '23003' TO WNR-EXEC-SQL */
                _.Move("23003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1978- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ", WS_MSG_RETORNO);

                /*" -1979- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -1981- END-IF. */
            }


            /*" -1982- MOVE 'VA0431B' TO V0RELA-CODRELAT. */
            _.Move("VA0431B", V0RELA_CODRELAT);

            /*" -1984- MOVE 1 TO V0RELA-QTDPARATZ. */
            _.Move(1, V0RELA_QTDPARATZ);

            /*" -1984- PERFORM R4500-00-SOLIC-RELAT. */

            R4500_00_SOLIC_RELAT_SECTION();

        }

        [StopWatch]
        /*" R3000-00-TRATA-1A-2A-PARCELA-DB-SELECT-1 */
        public void R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1()
        {
            /*" -1911- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL WITH UR END-EXEC. */

            var r3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1 = new R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            var executed_1 = R3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1.Execute(r3000_00_TRATA_1A_2A_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R3000-00-TRATA-1A-2A-PARCELA-DB-INSERT-1 */
        public void R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1()
        {
            /*" -1944- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, :WHOST-NRPARCEL-1, :V0HISC-NRPARCEL, :WHOST-CODOPER, :V0PARC-DTVENCTO, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, 0, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, '1' ) END-EXEC */

            var r3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1 = new R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                WHOST_NRPARCEL_1 = WHOST_NRPARCEL_1.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
            };

            R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1.Execute(r3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TRATA-1A-2A-PARCELA-DB-INSERT-2 */
        public void R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2()
        {
            /*" -1971- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-NRPARCEL, :WHOST-CODOPER, :V0PROP-DTVENCTO, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, 0, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, '1' ) END-EXEC. */

            var r3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1 = new R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
            };

            R3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1.Execute(r3000_00_TRATA_1A_2A_PARCELA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R4000-00-TRATA-3APARCELA-SECTION */
        private void R4000_00_TRATA_3APARCELA_SECTION()
        {
            /*" -1996- MOVE '24000' TO WNR-EXEC-SQL. */
            _.Move("24000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1998- PERFORM R2000-00-UPDT-SIT-SUSPENSA */

            R2000_00_UPDT_SIT_SUSPENSA_SECTION();

            /*" -2000- MOVE 123 TO WHOST-CODOPER. */
            _.Move(123, WHOST_CODOPER);

            /*" -2007- MOVE WHOST-CODOPER TO WHOST-CODOPER1. */
            _.Move(WHOST_CODOPER, WHOST_CODOPER1);

            /*" -2008- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -2009- PERFORM R5500-00-GERA-ATRASADAS */

                R5500_00_GERA_ATRASADAS_SECTION();

                /*" -2010- GO TO R4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;

                /*" -2011- ELSE */
            }
            else
            {


                /*" -2012- PERFORM R5000-00-GERA-PROXIMA */

                R5000_00_GERA_PROXIMA_SECTION();

                /*" -2014- END-IF. */
            }


            /*" -2015- IF (WTEM-PROXIMA EQUAL 'N' ) */

            if ((AREA_DE_WORK.WTEM_PROXIMA == "N"))
            {

                /*" -2016- GO TO R4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;

                /*" -2021- END-IF. */
            }


            /*" -2022- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -2037- PERFORM R4000_00_TRATA_3APARCELA_DB_INSERT_1 */

                R4000_00_TRATA_3APARCELA_DB_INSERT_1();

                /*" -2040- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

                if ((!DB.SQLCODE.In("00", "-803")))
                {

                    /*" -2041- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2042- MOVE '24001' TO WNR-EXEC-SQL */
                    _.Move("24001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2044- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ", WS_MSG_RETORNO);

                    /*" -2045- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2047- END-IF */
                }


                /*" -2048- MOVE 'VA0431B' TO V0RELA-CODRELAT */
                _.Move("VA0431B", V0RELA_CODRELAT);

                /*" -2050- MOVE 2 TO V0RELA-QTDPARATZ */
                _.Move(2, V0RELA_QTDPARATZ);

                /*" -2051- PERFORM R4500-00-SOLIC-RELAT */

                R4500_00_SOLIC_RELAT_SECTION();

                /*" -2052- GO TO R4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;

                /*" -2057- END-IF. */
            }


            /*" -2066- PERFORM R4000_00_TRATA_3APARCELA_DB_DECLARE_1 */

            R4000_00_TRATA_3APARCELA_DB_DECLARE_1();

            /*" -2068- PERFORM R4000_00_TRATA_3APARCELA_DB_OPEN_1 */

            R4000_00_TRATA_3APARCELA_DB_OPEN_1();

            /*" -2071- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2072- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2073- MOVE '24002' TO WNR-EXEC-SQL */
                _.Move("24002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2075- MOVE 'ERRO NA ABERTURA DO CURSOR CDIFANT' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ABERTURA DO CURSOR CDIFANT", WS_MSG_RETORNO);

                /*" -2076- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2078- END-IF. */
            }


            /*" -2080- MOVE SPACES TO WFIM-CDIFANT. */
            _.Move("", AREA_DE_WORK.WFIM_CDIFANT);

            /*" -2082- PERFORM R4100-00-FETCH-CDIFANT. */

            R4100_00_FETCH_CDIFANT_SECTION();

            /*" -2083- IF (WFIM-CDIFANT NOT EQUAL SPACES) */

            if ((!AREA_DE_WORK.WFIM_CDIFANT.IsEmpty()))
            {

                /*" -2083- PERFORM R4000_00_TRATA_3APARCELA_DB_CLOSE_1 */

                R4000_00_TRATA_3APARCELA_DB_CLOSE_1();

                /*" -2086- GO TO R4000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;

                /*" -2086- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R4000_10_LOOP_CDIFANT */

            R4000_10_LOOP_CDIFANT();

        }

        [StopWatch]
        /*" R4000-00-TRATA-3APARCELA-DB-INSERT-1 */
        public void R4000_00_TRATA_3APARCELA_DB_INSERT_1()
        {
            /*" -2037- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-NRPARCEL, :WHOST-CODOPER1, :V0PROP-DTVENCTO, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, 0, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, '1' ) END-EXEC */

            var r4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1 = new R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_CODOPER1 = WHOST_CODOPER1.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
            };

            R4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1.Execute(r4000_00_TRATA_3APARCELA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R4000-00-TRATA-3APARCELA-DB-OPEN-1 */
        public void R4000_00_TRATA_3APARCELA_DB_OPEN_1()
        {
            /*" -2068- EXEC SQL OPEN CDIFANT END-EXEC. */

            CDIFANT.Open();

        }

        [StopWatch]
        /*" R8170-00-CONTA-PEND-CCRED-DB-DECLARE-1 */
        public void R8170_00_CONTA_PEND_CCRED_DB_DECLARE_1()
        {
            /*" -4712- EXEC SQL DECLARE CPARCAT CURSOR FOR SELECT NUM_PARCELA, NUM_TITULO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF AND NUM_PARCELA BETWEEN :WHOST-NUM-PARCELA-I AND :WHOST-NUM-PARCELA-F AND DATA_VENCIMENTO <= :V1SIST-DTVENFIM-CN AND SIT_REGISTRO IN ( ' ' , '0' , X'00' ) ORDER BY NUM_PARCELA WITH UR END-EXEC. */
            CPARCAT = new GE0853S_CPARCAT(true);
            string GetQuery_CPARCAT()
            {
                var query = @$"SELECT NUM_PARCELA
							, 
							NUM_TITULO 
							FROM SEGUROS.COBER_HIST_VIDAZUL 
							WHERE NUM_CERTIFICADO = '{V0HISC_NRCERTIF}' 
							AND NUM_PARCELA BETWEEN '{WHOST_NUM_PARCELA_I}' 
							AND '{WHOST_NUM_PARCELA_F}' 
							AND DATA_VENCIMENTO <= '{V1SIST_DTVENFIM_CN}' 
							AND SIT_REGISTRO IN ( ' '
							, '0'
							, X'00' ) 
							ORDER BY NUM_PARCELA";

                return query;
            }
            CPARCAT.GetQueryEvent += GetQuery_CPARCAT;

        }

        [StopWatch]
        /*" R4000-00-TRATA-3APARCELA-DB-CLOSE-1 */
        public void R4000_00_TRATA_3APARCELA_DB_CLOSE_1()
        {
            /*" -2083- EXEC SQL CLOSE CDIFANT END-EXEC */

            CDIFANT.Close();

        }

        [StopWatch]
        /*" R4000-10-LOOP-CDIFANT */
        private void R4000_10_LOOP_CDIFANT(bool isPerform = false)
        {
            /*" -2092- IF (V2DIFP-CODOPER NOT LESS 400) AND (V2DIFP-CODOPER NOT GREATER 499) */

            if ((V2DIFP_CODOPER >= 400) && (V2DIFP_CODOPER <= 499))
            {

                /*" -2093- GO TO R4000-20-LE-CDIFANT */

                R4000_20_LE_CDIFANT(); //GOTO
                return;

                /*" -2095- END-IF. */
            }


            /*" -2097- IF (V2DIFP-CODOPER NOT LESS 600) AND (V2DIFP-CODOPER NOT GREATER 699) */

            if ((V2DIFP_CODOPER >= 600) && (V2DIFP_CODOPER <= 699))
            {

                /*" -2098- GO TO R4000-20-LE-CDIFANT */

                R4000_20_LE_CDIFANT(); //GOTO
                return;

                /*" -2100- END-IF. */
            }


            /*" -2107- PERFORM R4000_10_LOOP_CDIFANT_DB_SELECT_1 */

            R4000_10_LOOP_CDIFANT_DB_SELECT_1();

            /*" -2110- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2111- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2112- MOVE '24003' TO WNR-EXEC-SQL */
                _.Move("24003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2114- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -2115- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2117- END-IF. */
            }


            /*" -2132- PERFORM R4000_10_LOOP_CDIFANT_DB_INSERT_1 */

            R4000_10_LOOP_CDIFANT_DB_INSERT_1();

            /*" -2135- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2136- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2137- MOVE '24004' TO WNR-EXEC-SQL */
                _.Move("24004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2139- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ", WS_MSG_RETORNO);

                /*" -2140- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2140- END-IF. */
            }


        }

        [StopWatch]
        /*" R4000-10-LOOP-CDIFANT-DB-SELECT-1 */
        public void R4000_10_LOOP_CDIFANT_DB_SELECT_1()
        {
            /*" -2107- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V2DIFP-NRPARCDIF WITH UR END-EXEC. */

            var r4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1 = new R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1()
            {
                V2DIFP_NRPARCDIF = V2DIFP_NRPARCDIF.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1.Execute(r4000_10_LOOP_CDIFANT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R4000-10-LOOP-CDIFANT-DB-INSERT-1 */
        public void R4000_10_LOOP_CDIFANT_DB_INSERT_1()
        {
            /*" -2132- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, :V0PROP-NRPARCEL, :V2DIFP-NRPARCDIF, :V2DIFP-CODOPER, :V0PARC-DTVENCTO, :V2DIFP-PRMVG, :V2DIFP-PRMAP, 0, 0, :V2DIFP-PRMVG, :V2DIFP-PRMAP, 0, '1' ) END-EXEC. */

            var r4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1 = new R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V2DIFP_NRPARCDIF = V2DIFP_NRPARCDIF.ToString(),
                V2DIFP_CODOPER = V2DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V2DIFP_PRMVG = V2DIFP_PRMVG.ToString(),
                V2DIFP_PRMAP = V2DIFP_PRMAP.ToString(),
            };

            R4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1.Execute(r4000_10_LOOP_CDIFANT_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R4000-20-LE-CDIFANT */
        private void R4000_20_LE_CDIFANT(bool isPerform = false)
        {
            /*" -2146- PERFORM R4100-00-FETCH-CDIFANT. */

            R4100_00_FETCH_CDIFANT_SECTION();

            /*" -2147- IF (WFIM-CDIFANT EQUAL SPACES) */

            if ((AREA_DE_WORK.WFIM_CDIFANT.IsEmpty()))
            {

                /*" -2148- GO TO R4000-10-LOOP-CDIFANT */

                R4000_10_LOOP_CDIFANT(); //GOTO
                return;

                /*" -2150- END-IF. */
            }


            /*" -2150- PERFORM R4000_20_LE_CDIFANT_DB_CLOSE_1 */

            R4000_20_LE_CDIFANT_DB_CLOSE_1();

            /*" -2153- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2154- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2155- MOVE '24005' TO WNR-EXEC-SQL */
                _.Move("24005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2157- MOVE 'ERRO NO FECHAMENTO DO CURSOR CDIFANT' TO WS-MSG-RETORNO */
                _.Move("ERRO NO FECHAMENTO DO CURSOR CDIFANT", WS_MSG_RETORNO);

                /*" -2158- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2160- END-IF. */
            }


            /*" -2175- PERFORM R4000_20_LE_CDIFANT_DB_INSERT_1 */

            R4000_20_LE_CDIFANT_DB_INSERT_1();

            /*" -2178- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2179- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2180- MOVE '24006' TO WNR-EXEC-SQL */
                _.Move("24006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2182- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA ", WS_MSG_RETORNO);

                /*" -2183- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2185- END-IF. */
            }


            /*" -2186- MOVE 'VA0431B' TO V0RELA-CODRELAT. */
            _.Move("VA0431B", V0RELA_CODRELAT);

            /*" -2188- MOVE 2 TO V0RELA-QTDPARATZ. */
            _.Move(2, V0RELA_QTDPARATZ);

            /*" -2188- PERFORM R4500-00-SOLIC-RELAT. */

            R4500_00_SOLIC_RELAT_SECTION();

        }

        [StopWatch]
        /*" R4000-20-LE-CDIFANT-DB-CLOSE-1 */
        public void R4000_20_LE_CDIFANT_DB_CLOSE_1()
        {
            /*" -2150- EXEC SQL CLOSE CDIFANT END-EXEC. */

            CDIFANT.Close();

        }

        [StopWatch]
        /*" R4000-20-LE-CDIFANT-DB-INSERT-1 */
        public void R4000_20_LE_CDIFANT_DB_INSERT_1()
        {
            /*" -2175- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-NRPARCEL, :WHOST-CODOPER1, :V0PROP-DTVENCTO, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, 0, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, '1' ) END-EXEC. */

            var r4000_20_LE_CDIFANT_DB_INSERT_1_Insert1 = new R4000_20_LE_CDIFANT_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_CODOPER1 = WHOST_CODOPER1.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
            };

            R4000_20_LE_CDIFANT_DB_INSERT_1_Insert1.Execute(r4000_20_LE_CDIFANT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-FETCH-CDIFANT-SECTION */
        private void R4100_00_FETCH_CDIFANT_SECTION()
        {
            /*" -2200- MOVE '24100' TO WNR-EXEC-SQL. */
            _.Move("24100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2205- PERFORM R4100_00_FETCH_CDIFANT_DB_FETCH_1 */

            R4100_00_FETCH_CDIFANT_DB_FETCH_1();

            /*" -2208- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2209- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -2210- MOVE 'S' TO WFIM-CDIFANT */
                    _.Move("S", AREA_DE_WORK.WFIM_CDIFANT);

                    /*" -2211- ELSE */
                }
                else
                {


                    /*" -2212- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2213- MOVE '24101' TO WNR-EXEC-SQL */
                    _.Move("24101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2215- MOVE 'ERRO NA CONSULTA DO CURSOR CDIFANT ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DO CURSOR CDIFANT ", WS_MSG_RETORNO);

                    /*" -2216- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2217- END-IF */
                }


                /*" -2217- END-IF. */
            }


        }

        [StopWatch]
        /*" R4100-00-FETCH-CDIFANT-DB-FETCH-1 */
        public void R4100_00_FETCH_CDIFANT_DB_FETCH_1()
        {
            /*" -2205- EXEC SQL FETCH CDIFANT INTO :V2DIFP-NRPARCDIF, :V2DIFP-PRMVG, :V2DIFP-PRMAP, :V2DIFP-CODOPER END-EXEC. */

            if (CDIFANT.Fetch())
            {
                _.Move(CDIFANT.V2DIFP_NRPARCDIF, V2DIFP_NRPARCDIF);
                _.Move(CDIFANT.V2DIFP_PRMVG, V2DIFP_PRMVG);
                _.Move(CDIFANT.V2DIFP_PRMAP, V2DIFP_PRMAP);
                _.Move(CDIFANT.V2DIFP_CODOPER, V2DIFP_CODOPER);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-SOLIC-RELAT-SECTION */
        private void R4500_00_SOLIC_RELAT_SECTION()
        {
            /*" -2231- MOVE '24500' TO WNR-EXEC-SQL. */
            _.Move("24500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2274- PERFORM R4500_00_SOLIC_RELAT_DB_INSERT_1 */

            R4500_00_SOLIC_RELAT_DB_INSERT_1();

            /*" -2277- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -2278- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2279- MOVE '24501' TO WNR-EXEC-SQL */
                _.Move("24501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2281- MOVE 'ERRO NA INCLUSAO DA TABELA RELATORIOS ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA RELATORIOS ", WS_MSG_RETORNO);

                /*" -2282- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2282- END-IF. */
            }


        }

        [StopWatch]
        /*" R4500-00-SOLIC-RELAT-DB-INSERT-1 */
        public void R4500_00_SOLIC_RELAT_DB_INSERT_1()
        {
            /*" -2274- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'GE0853S' , CURRENT DATE, 'VA' , :V0RELA-CODRELAT, 0, :V0RELA-QTDPARATZ, CURRENT DATE, CURRENT DATE, :V0HISC-DTVENCTO, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0HISC-NRPARCEL, :V0HISC-NRCERTIF, :V0HISC-NRTIT, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var r4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1 = new R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1()
            {
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_QTDPARATZ = V0RELA_QTDPARATZ.ToString(),
                V0HISC_DTVENCTO = V0HISC_DTVENCTO.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRTIT = V0HISC_NRTIT.ToString(),
            };

            R4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1.Execute(r4500_00_SOLIC_RELAT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_00_SAIDA*/

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-SECTION */
        private void R5000_00_GERA_PROXIMA_SECTION()
        {
            /*" -2294- ADD 1 TO V0PROP-QTDPARATZ. */
            V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ + 1;

            /*" -2297- MOVE '25000' TO WNR-EXEC-SQL. */
            _.Move("25000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2317- PERFORM R5000_00_GERA_PROXIMA_DB_SELECT_1 */

            R5000_00_GERA_PROXIMA_DB_SELECT_1();

            /*" -2320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2321- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -2340- PERFORM R5000_00_GERA_PROXIMA_DB_SELECT_2 */

                    R5000_00_GERA_PROXIMA_DB_SELECT_2();

                    /*" -2343- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2344- MOVE 'F' TO LK-GE853-COD-RETORNO */
                        _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                        /*" -2345- MOVE '25001' TO WNR-EXEC-SQL */
                        _.Move("25001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -2347- MOVE 'ERRO NA CONSULTA DA TABELA V0COBERPROPVA' TO WS-MSG-RETORNO */
                        _.Move("ERRO NA CONSULTA DA TABELA V0COBERPROPVA", WS_MSG_RETORNO);

                        /*" -2348- GO TO R9999-00-FINALIZA-ROT */

                        R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                        return;

                        /*" -2349- END-IF */
                    }


                    /*" -2350- ELSE */
                }
                else
                {


                    /*" -2351- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2352- MOVE '25002' TO WNR-EXEC-SQL */
                    _.Move("25002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2354- MOVE 'ERRO NA CONSULTA DA TABELA V0COBERPROPVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0COBERPROPVA", WS_MSG_RETORNO);

                    /*" -2355- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2356- END-IF */
                }


                /*" -2358- END-IF. */
            }


            /*" -2359- IF (V0COBP-IVLCUSTAUXF LESS ZEROS) */

            if ((V0COBP_IVLCUSTAUXF < 00))
            {

                /*" -2360- MOVE 0 TO V0COBP-VLCUSTAUXF */
                _.Move(0, V0COBP_VLCUSTAUXF);

                /*" -2362- END-IF. */
            }


            /*" -2363- IF (V0PROP-OPCAOCAP = 1) */

            if ((V0PROP_OPCAOCAP == 1))
            {

                /*" -2365- COMPUTE V0COBP-VLCUSTCAP = V0COBP-VLCUSTCAP * V0COBP-QTTITCAP */
                V0COBP_VLCUSTCAP.Value = V0COBP_VLCUSTCAP * V0COBP_QTTITCAP;

                /*" -2366- COMPUTE V0COBP-VLCUSTCAP = 1,28 * V0COBP-QTTITCAP */
                V0COBP_VLCUSTCAP.Value = 1.28 * V0COBP_QTTITCAP;

                /*" -2368- END-IF. */
            }


            /*" -2370- COMPUTE DESCON-NRPARCEL = V0PROP-NRPARCEL + 1. */
            DESCON_NRPARCEL.Value = V0PROP_NRPARCEL + 1;

            /*" -2378- MOVE ZEROS TO DESCON-PRMVG DESCON-PRMAP DESCON-PERC. */
            _.Move(0, DESCON_PRMVG, DESCON_PRMAP, DESCON_PERC);

            /*" -2388- PERFORM R5000_00_GERA_PROXIMA_DB_SELECT_3 */

            R5000_00_GERA_PROXIMA_DB_SELECT_3();

            /*" -2391- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2392- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2393- MOVE '25003' TO WNR-EXEC-SQL */
                _.Move("25003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2395- MOVE 'ERRO NA CONSULTA DA TABELA VG_PARCELAS_DESCON ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA VG_PARCELAS_DESCON ", WS_MSG_RETORNO);

                /*" -2396- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2397- ELSE */
            }
            else
            {


                /*" -2398- IF (DESCON-PERC > ZEROS) */

                if ((DESCON_PERC > 00))
                {

                    /*" -2399- COMPUTE DESCON-PRMVG = V0COBP-PRMVG * DESCON-PERC */
                    DESCON_PRMVG.Value = V0COBP_PRMVG * DESCON_PERC;

                    /*" -2400- COMPUTE DESCON-PRMAP = V0COBP-PRMAP * DESCON-PERC */
                    DESCON_PRMAP.Value = V0COBP_PRMAP * DESCON_PERC;

                    /*" -2403- IF (DESCON-PRMVG > ZEROS) OR (DESCON-PRMAP < ZEROS) */

                    if ((DESCON_PRMVG > 00) || (DESCON_PRMAP < 00))
                    {

                        /*" -2418- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_1 */

                        R5000_00_GERA_PROXIMA_DB_INSERT_1();

                        /*" -2421- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                        if (!DB.SQLCODE.In("00", "-803"))
                        {

                            /*" -2422- MOVE 'F' TO LK-GE853-COD-RETORNO */
                            _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                            /*" -2423- MOVE '25004' TO WNR-EXEC-SQL */
                            _.Move("25004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                            /*" -2425- MOVE 'ERRO NA INCLUSAO DA TABELA DIFPARCELVA' TO WS-MSG-RETORNO */
                            _.Move("ERRO NA INCLUSAO DA TABELA DIFPARCELVA", WS_MSG_RETORNO);

                            /*" -2426- GO TO R9999-00-FINALIZA-ROT */

                            R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                            return;

                            /*" -2427- END-IF */
                        }


                        /*" -2428- END-IF */
                    }


                    /*" -2429- END-IF */
                }


                /*" -2434- END-IF. */
            }


            /*" -2439- PERFORM R1100-00-TRATA-V0DIFPARCELVA. */

            R1100_00_TRATA_V0DIFPARCELVA_SECTION();

            /*" -2447- MOVE WHOST-VLPREMIO TO WHOST-VLPREMIO-ATR. */
            _.Move(WHOST_VLPREMIO, WHOST_VLPREMIO_ATR);

            /*" -2449- MOVE 'N' TO WTEM-PROXIMA. */
            _.Move("N", AREA_DE_WORK.WTEM_PROXIMA);

            /*" -2451- IF (WHOST-VLPREMIO EQUAL ZEROES) OR (WHOST-VLPREMIO < ZEROES) */

            if ((WHOST_VLPREMIO == 00) || (WHOST_VLPREMIO < 00))
            {

                /*" -2452- MOVE V0HISC-NRPARCEL TO V2DIFP-NRPARCEL */
                _.Move(V0HISC_NRPARCEL, V2DIFP_NRPARCEL);

                /*" -2453- PERFORM R7000-00-QUITA-ATRASADA */

                R7000_00_QUITA_ATRASADA_SECTION();

                /*" -2454- IF WTEM-PENDENTE EQUAL 'N' */

                if (AREA_DE_WORK.WTEM_PENDENTE == "N")
                {

                    /*" -2455- GO TO R5000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/ //GOTO
                    return;

                    /*" -2456- END-IF */
                }


                /*" -2458- END-IF. */
            }


            /*" -2459- MOVE 'S' TO WTEM-PROXIMA. */
            _.Move("S", AREA_DE_WORK.WTEM_PROXIMA);

            /*" -2464- MOVE 'N' TO WTEM-PENDENTE. */
            _.Move("N", AREA_DE_WORK.WTEM_PENDENTE);

            /*" -2465- COMPUTE V0PROP-NRPARCEL = V0PROP-NRPARCEL + 1. */
            V0PROP_NRPARCEL.Value = V0PROP_NRPARCEL + 1;

            /*" -2467- COMPUTE WHOST-PARCELCAP = V0PROP-NRPARCEL - 1. */
            WHOST_PARCELCAP.Value = V0PROP_NRPARCEL - 1;

            /*" -2473- MOVE V0PROP-DTPROXVEN TO V0PROP-DTVENCTO V0PARC-DTVENCTO V0HCOB-DTVENCTO. */
            _.Move(V0PROP_DTPROXVEN, V0PROP_DTVENCTO, V0PARC_DTVENCTO, V0HCOB_DTVENCTO);

            /*" -2474- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -2476- COMPUTE V0PARC-VLPRMTOT = WHOST-VLPREMIO + V0COBP-VLPREMIO */
                V0PARC_VLPRMTOT.Value = WHOST_VLPREMIO + V0COBP_VLPREMIO;

                /*" -2477- COMPUTE V0PARC-PRMVG = WHOST-PRMVG + V0COBP-PRMVG */
                V0PARC_PRMVG.Value = WHOST_PRMVG + V0COBP_PRMVG;

                /*" -2478- COMPUTE V0PARC-PRMAP = WHOST-PRMAP + V0COBP-PRMAP */
                V0PARC_PRMAP.Value = WHOST_PRMAP + V0COBP_PRMAP;

                /*" -2480- END-IF. */
            }


            /*" -2481- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -2499- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_2 */

                R5000_00_GERA_PROXIMA_DB_INSERT_2();

                /*" -2502- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -2503- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2504- MOVE '25006' TO WNR-EXEC-SQL */
                    _.Move("25006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2506- MOVE 'ERRO NA INCLUSAO DA TABELA V0PARCELVA ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0PARCELVA ", WS_MSG_RETORNO);

                    /*" -2507- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2509- END-IF */
                }


                /*" -2511- ELSE */
            }
            else
            {


                /*" -2527- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_3 */

                R5000_00_GERA_PROXIMA_DB_INSERT_3();

                /*" -2530- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -2531- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2532- MOVE '25007' TO WNR-EXEC-SQL */
                    _.Move("25007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2534- MOVE 'ERRO NA INCLUSAO DA TABELA V0PARCELVA ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0PARCELVA ", WS_MSG_RETORNO);

                    /*" -2535- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2536- END-IF */
                }


                /*" -2538- END-IF. */
            }


            /*" -2542- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

            /*" -2543- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -2550- PERFORM R5000_00_GERA_PROXIMA_DB_SELECT_4 */

                R5000_00_GERA_PROXIMA_DB_SELECT_4();

                /*" -2553- IF SQLCODE NOT EQUAL ZEROES AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -2554- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2555- MOVE '25008' TO WNR-EXEC-SQL */
                    _.Move("25008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2557- MOVE 'ERRO NA CONSULTA DA TABELA V0CONVENIOSVG ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0CONVENIOSVG ", WS_MSG_RETORNO);

                    /*" -2558- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2560- END-IF */
                }


                /*" -2604- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_4 */

                R5000_00_GERA_PROXIMA_DB_INSERT_4();

                /*" -2607- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -2608- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2609- MOVE '25009' TO WNR-EXEC-SQL */
                    _.Move("25009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2611- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCONTAVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCONTAVA", WS_MSG_RETORNO);

                    /*" -2612- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2613- END-IF */
                }


                /*" -2615- END-IF. */
            }


            /*" -2616- MOVE V0PROP-DTPROXVEN TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -2618- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -2619- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -2620- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -2621- COMPUTE WDATA-SIS-ANO = WDATA-SIS-ANO + 1 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;

                /*" -2623- END-IF. */
            }


            /*" -2624- IF WDATA-SIS-DIA > 30 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA > 30)
            {

                /*" -2625- MOVE 30 TO WDATA-SIS-DIA */
                _.Move(30, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                /*" -2627- END-IF */
            }


            /*" -2628- IF WDATA-SIS-MES = 2 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES == 2)
            {

                /*" -2629- IF WDATA-SIS-DIA > 28 */

                if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA > 28)
                {

                    /*" -2630- MOVE 28 TO WDATA-SIS-DIA */
                    _.Move(28, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

                    /*" -2631- END-IF */
                }


                /*" -2633- END-IF */
            }


            /*" -2637- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

            /*" -2638- IF V0OPCP-OPCAOPAG EQUAL '1' OR '2' OR '5' */

            if (V0OPCP_OPCAOPAG.In("1", "2", "5"))
            {

                /*" -2639- ADD 1 TO CEDENTE-NUM-TITULO */
                CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.Value = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO + 1;

                /*" -2640- MOVE CEDENTE-NUM-TITULO TO WHOST-NRTIT */
                _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WHOST_NRTIT);

                /*" -2642- ELSE */
            }
            else
            {


                /*" -2644- ADD 1 TO WTITL-SEQUENCIA */
                FILLER_1.WTITL_SEQUENCIA.Value = FILLER_1.WTITL_SEQUENCIA + 1;

                /*" -2647- MOVE WTITL-SEQUENCIA TO DPARM01 */
                _.Move(FILLER_1.WTITL_SEQUENCIA, DPARM01X.DPARM01);

                /*" -2649- CALL 'PROTIT01' USING DPARM01X */
                _.Call("PROTIT01", DPARM01X);

                /*" -2650- IF DPARM01-RC NOT EQUAL +0 */

                if (DPARM01X.DPARM01_RC != +0)
                {

                    /*" -2651- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2652- MOVE '25010' TO WNR-EXEC-SQL */
                    _.Move("25010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2654- MOVE 'ERRO NA CHAMADA DA SUBROTINA PROTIT01 ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CHAMADA DA SUBROTINA PROTIT01 ", WS_MSG_RETORNO);

                    /*" -2655- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2656- END-IF */
                }


                /*" -2658- MOVE DPARM01-D1 TO WTITL-DIGITO */
                _.Move(DPARM01X.DPARM01_D1, FILLER_1.WTITL_DIGITO);

                /*" -2660- MOVE W-NUMR-TITULO TO V0BANC-NRTIT WHOST-NRTIT */
                _.Move(W_NUMR_TITULO, V0BANC_NRTIT, WHOST_NRTIT);

                /*" -2662- END-IF. */
            }


            /*" -2663- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -2668- PERFORM R5000_00_GERA_PROXIMA_DB_UPDATE_1 */

                R5000_00_GERA_PROXIMA_DB_UPDATE_1();

                /*" -2671- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2672- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2673- MOVE '25011' TO WNR-EXEC-SQL */
                    _.Move("25011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2675- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                    /*" -2676- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2677- END-IF */
                }


                /*" -2679- END-IF. */
            }


            /*" -2680- IF (V0HCOB-DTVENCTO < V1SIST-DTVENFIM-VE) */

            if ((V0HCOB_DTVENCTO < V1SIST_DTVENFIM_VE))
            {

                /*" -2681- MOVE V1SIST-DTVENFIM-VE TO V0HCOB-DTVENCTO */
                _.Move(V1SIST_DTVENFIM_VE, V0HCOB_DTVENCTO);

                /*" -2683- END-IF. */
            }


            /*" -2684- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -2686- MOVE '5' TO V0HISC-SITUACAO */
                _.Move("5", V0HISC_SITUACAO);

                /*" -2692- PERFORM R5000_00_GERA_PROXIMA_DB_UPDATE_2 */

                R5000_00_GERA_PROXIMA_DB_UPDATE_2();

                /*" -2695- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2696- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2697- MOVE '25012' TO WNR-EXEC-SQL */
                    _.Move("25012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2699- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -2700- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2701- END-IF */
                }


                /*" -2702- ELSE */
            }
            else
            {


                /*" -2704- MOVE '0' TO V0HISC-SITUACAO */
                _.Move("0", V0HISC_SITUACAO);

                /*" -2711- PERFORM R5000_00_GERA_PROXIMA_DB_UPDATE_3 */

                R5000_00_GERA_PROXIMA_DB_UPDATE_3();

                /*" -2714- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2715- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2716- MOVE '25013' TO WNR-EXEC-SQL */
                    _.Move("25013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2718- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -2719- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2720- END-IF */
                }


                /*" -2722- END-IF. */
            }


            /*" -2723- MOVE V0PROP-NRPARCEL TO LK-GE853-NUM-PARCELA */
            _.Move(V0PROP_NRPARCEL, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_PARCELA);

            /*" -2724- MOVE V0HCOB-DTVENCTO TO LK-GE853-DT-CORRENTE */
            _.Move(V0HCOB_DTVENCTO, REGISTRO_LINKAGE_GE0853S.LK_GE853_DT_CORRENTE);

            /*" -2725- MOVE V0PARC-VLPRMTOT TO LK-GE853-VLR-PREMIO */
            _.Move(V0PARC_VLPRMTOT, REGISTRO_LINKAGE_GE0853S.LK_GE853_VLR_PREMIO);

            /*" -2726- MOVE V0HISC-SITUACAO TO LK-GE853-SIT-PARCELA */
            _.Move(V0HISC_SITUACAO, REGISTRO_LINKAGE_GE0853S.LK_GE853_SIT_PARCELA);

            /*" -2728- MOVE V0OPCP-OPCAOPAG TO LK-GE853-OPC-PAG-PARCELA */
            _.Move(V0OPCP_OPCAOPAG, REGISTRO_LINKAGE_GE0853S.LK_GE853_OPC_PAG_PARCELA);

            /*" -2729- IF (V0OPCP-OPCAOPAG EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG == "3"))
            {

                /*" -2751- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_5 */

                R5000_00_GERA_PROXIMA_DB_INSERT_5();

                /*" -2754- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -2755- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2756- MOVE '25014' TO WNR-EXEC-SQL */
                    _.Move("25014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2758- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -2759- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2761- END-IF */
                }


                /*" -2763- ELSE */
            }
            else
            {


                /*" -2785- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_6 */

                R5000_00_GERA_PROXIMA_DB_INSERT_6();

                /*" -2788- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -2789- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -2790- MOVE '25015' TO WNR-EXEC-SQL */
                    _.Move("25015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -2792- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -2793- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -2794- END-IF */
                }


                /*" -2796- END-IF. */
            }


            /*" -2797- IF (V0OPCP-OPCAOPAG NOT EQUAL '3' ) */

            if ((V0OPCP_OPCAOPAG != "3"))
            {

                /*" -2799- PERFORM R5010-00-OCORHIST */

                R5010_00_OCORHIST_SECTION();

                /*" -2843- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_7 */

                R5000_00_GERA_PROXIMA_DB_INSERT_7();

                /*" -2846- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2847- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                    if (!DB.SQLCODE.In("00", "-803"))
                    {

                        /*" -2848- MOVE 'F' TO LK-GE853-COD-RETORNO */
                        _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                        /*" -2849- MOVE '25016' TO WNR-EXEC-SQL */
                        _.Move("25016", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -2851- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                        _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                        /*" -2852- GO TO R9999-00-FINALIZA-ROT */

                        R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                        return;

                        /*" -2854- END-IF */
                    }


                    /*" -2860- PERFORM R5000_00_GERA_PROXIMA_DB_UPDATE_4 */

                    R5000_00_GERA_PROXIMA_DB_UPDATE_4();

                    /*" -2863- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2864- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -2866- DISPLAY ' *** R5040 - ' ' PARCELA NAO ENCONTRADA EM V0HISTCONTAVA' */
                            _.Display($" *** R5040 -  PARCELA NAO ENCONTRADA EM V0HISTCONTAVA");

                            /*" -2869- DISPLAY 'CERTIF: ' V0HISC-NRCERTIF '  ' 'PARCEL: ' V0HISC-NRPARCEL '  ' 'OCORR. <  ' V0PARC-OCORHIST */

                            $"CERTIF: {V0HISC_NRCERTIF}  PARCEL: {V0HISC_NRPARCEL}  OCORR. <  {V0PARC_OCORHIST}"
                            .Display();

                            /*" -2870- ELSE */
                        }
                        else
                        {


                            /*" -2871- MOVE 'F' TO LK-GE853-COD-RETORNO */
                            _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                            /*" -2872- MOVE '25017' TO WNR-EXEC-SQL */
                            _.Move("25017", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                            /*" -2874- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                            _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                            /*" -2875- GO TO R9999-00-FINALIZA-ROT */

                            R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                            return;

                            /*" -2876- END-IF */
                        }


                        /*" -2877- END-IF */
                    }


                    /*" -2878- END-IF */
                }


                /*" -2882- END-IF. */
            }


            /*" -2890- PERFORM R5000_00_GERA_PROXIMA_DB_UPDATE_5 */

            R5000_00_GERA_PROXIMA_DB_UPDATE_5();

            /*" -2893- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2894- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2895- MOVE '25018' TO WNR-EXEC-SQL */
                _.Move("25018", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2897- MOVE 'ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA", WS_MSG_RETORNO);

                /*" -2898- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2900- END-IF. */
            }


            /*" -2906- PERFORM R5000_00_GERA_PROXIMA_DB_SELECT_5 */

            R5000_00_GERA_PROXIMA_DB_SELECT_5();

            /*" -2909- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2910- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2911- MOVE '25019' TO WNR-EXEC-SQL */
                _.Move("25019", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2913- MOVE 'ERRO NA CONSULTA DA TABELA V0MOVFDCAPVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0MOVFDCAPVA", WS_MSG_RETORNO);

                /*" -2914- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2916- END-IF. */
            }


            /*" -2917- IF V0MOVF-COUNT = ZEROES */

            if (V0MOVF_COUNT == 00)
            {

                /*" -2921- IF (V0PROP-NUM-APOLICE EQUAL 97010000889) AND (V0PROP-CODSUBES EQUAL 1 OR 1948 OR 1951) AND (V0COBP-VLCUSTCAP > ZEROES) */

                if ((V0PROP_NUM_APOLICE == 97010000889) && (V0PROP_CODSUBES.In("1", "1948", "1951")) && (V0COBP_VLCUSTCAP > 00))
                {

                    /*" -2933- PERFORM R5000_00_GERA_PROXIMA_DB_INSERT_8 */

                    R5000_00_GERA_PROXIMA_DB_INSERT_8();

                    /*" -2936- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2938- IF SQLCODE EQUAL -803 NEXT SENTENCE */

                        if (DB.SQLCODE == -803)
                        {

                            /*" -2939- ELSE */
                        }
                        else
                        {


                            /*" -2940- MOVE 'F' TO LK-GE853-COD-RETORNO */
                            _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                            /*" -2941- MOVE '25020' TO WNR-EXEC-SQL */
                            _.Move("25020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                            /*" -2943- MOVE 'ERRO NA INCLUSAO DA TABELA V0PARCELCAPVG' TO WS-MSG-RETORNO */
                            _.Move("ERRO NA INCLUSAO DA TABELA V0PARCELCAPVG", WS_MSG_RETORNO);

                            /*" -2944- GO TO R9999-00-FINALIZA-ROT */

                            R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                            return;

                            /*" -2945- END-IF */
                        }


                        /*" -2946- END-IF */
                    }


                    /*" -2947- END-IF */
                }


                /*" -2947- END-IF. */
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-SELECT-1 */
        public void R5000_00_GERA_PROXIMA_DB_SELECT_1()
        {
            /*" -2317- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLCUSTCAP, VLCUSTCDG, VLCUSTAUXF INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-QTTITCAP, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN WITH UR END-EXEC. */

            var r5000_00_GERA_PROXIMA_DB_SELECT_1_Query1 = new R5000_00_GERA_PROXIMA_DB_SELECT_1_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R5000_00_GERA_PROXIMA_DB_SELECT_1_Query1.Execute(r5000_00_GERA_PROXIMA_DB_SELECT_1_Query1);
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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-SELECT-2 */
        public void R5000_00_GERA_PROXIMA_DB_SELECT_2()
        {
            /*" -2340- EXEC SQL SELECT VLPREMIO, PRMVG, PRMAP, QTTITCAP, VLCUSTCAP, VLCUSTCDG, VLCUSTAUXF INTO :V0COBP-VLPREMIO, :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-QTTITCAP, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-IVLCUSTAUXF FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTTERVIG = '9999-12-31' WITH UR END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_SELECT_2_Query1 = new R5000_00_GERA_PROXIMA_DB_SELECT_2_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R5000_00_GERA_PROXIMA_DB_SELECT_2_Query1.Execute(r5000_00_GERA_PROXIMA_DB_SELECT_2_Query1);
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
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-1 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_1()
        {
            /*" -2418- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0PROP-NRCERTIF, :DESCON-NRPARCEL, :DESCON-NRPARCEL, 680, :V0PROP-DTPROXVEN, 0.00, 0.00, 0.00, 0.00, :DESCON-PRMVG, :DESCON-PRMAP, 0.00, ' ' ) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                DESCON_NRPARCEL = DESCON_NRPARCEL.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                DESCON_PRMVG = DESCON_PRMVG.ToString(),
                DESCON_PRMAP = DESCON_PRMAP.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R5010-00-OCORHIST-SECTION */
        private void R5010_00_OCORHIST_SECTION()
        {
            /*" -2958- MOVE '25010' TO WNR-EXEC-SQL. */
            _.Move("25010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2965- PERFORM R5010_00_OCORHIST_DB_SELECT_1 */

            R5010_00_OCORHIST_DB_SELECT_1();

            /*" -2968- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2969- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2970- MOVE '25011' TO WNR-EXEC-SQL */
                _.Move("25011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2972- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -2973- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2973- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R5010_10_OCORHIST */

            R5010_10_OCORHIST();

        }

        [StopWatch]
        /*" R5010-00-OCORHIST-DB-SELECT-1 */
        public void R5010_00_OCORHIST_DB_SELECT_1()
        {
            /*" -2965- EXEC SQL SELECT OCORHIST INTO :V0PARC-OCORHIST FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL WITH UR END-EXEC. */

            var r5010_00_OCORHIST_DB_SELECT_1_Query1 = new R5010_00_OCORHIST_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            var executed_1 = R5010_00_OCORHIST_DB_SELECT_1_Query1.Execute(r5010_00_OCORHIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_OCORHIST, V0PARC_OCORHIST);
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-2 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_2()
        {
            /*" -2499- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, :V0COBP-PRMVG, :V0COBP-PRMAP, 0, :V0OPCP-OPCAOPAG, ' ' , 1, CURRENT TIMESTAMP) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_2_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_2_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_2_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-SELECT-3 */
        public void R5000_00_GERA_PROXIMA_DB_SELECT_3()
        {
            /*" -2388- EXEC SQL SELECT PCT_PARCELA_DESC INTO :DESCON-PERC FROM SEGUROS.VG_PARCELAS_DESCON WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES AND NUM_PARCELA_DESC = :DESCON-NRPARCEL AND DT_INIVIG_PARCDESC <= :V0PROP-DTADMISSAO AND DT_TERVIG_PARCDESC >= :V0PROP-DTADMISSAO WITH UR END-EXEC. */

            var r5000_00_GERA_PROXIMA_DB_SELECT_3_Query1 = new R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_DTADMISSAO = V0PROP_DTADMISSAO.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                DESCON_NRPARCEL = DESCON_NRPARCEL.ToString(),
            };

            var executed_1 = R5000_00_GERA_PROXIMA_DB_SELECT_3_Query1.Execute(r5000_00_GERA_PROXIMA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DESCON_PERC, DESCON_PERC);
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-3 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_3()
        {
            /*" -2527- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, :V0PARC-PRMVG, :V0PARC-PRMAP, 0, :V0OPCP-OPCAOPAG, ' ' , 0, CURRENT TIMESTAMP) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-UPDATE-1 */
        public void R5000_00_GERA_PROXIMA_DB_UPDATE_1()
        {
            /*" -2668- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1 = new R5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1.Execute(r5000_00_GERA_PROXIMA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R5010-10-OCORHIST */
        private void R5010_10_OCORHIST(bool isPerform = false)
        {
            /*" -2979- COMPUTE V0PARC-OCORHIST = V0PARC-OCORHIST + 1. */
            V0PARC_OCORHIST.Value = V0PARC_OCORHIST + 1;

            /*" -2986- PERFORM R5010_10_OCORHIST_DB_UPDATE_1 */

            R5010_10_OCORHIST_DB_UPDATE_1();

            /*" -2989- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2990- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -2991- MOVE '25012' TO WNR-EXEC-SQL */
                _.Move("25012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -2993- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -2994- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -2996- END-IF. */
            }


            /*" -3004- PERFORM R5010_10_OCORHIST_DB_SELECT_1 */

            R5010_10_OCORHIST_DB_SELECT_1();

            /*" -3007- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3008- GO TO R5010-10-OCORHIST */
                new Task(() => R5010_10_OCORHIST()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3008- END-IF. */
            }


        }

        [StopWatch]
        /*" R5010-10-OCORHIST-DB-UPDATE-1 */
        public void R5010_10_OCORHIST_DB_UPDATE_1()
        {
            /*" -2986- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :WHOST-PRMVG, PRMAP = :WHOST-PRMAP, OCORHIST = :V0PARC-OCORHIST WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC. */

            var r5010_10_OCORHIST_DB_UPDATE_1_Update1 = new R5010_10_OCORHIST_DB_UPDATE_1_Update1()
            {
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R5010_10_OCORHIST_DB_UPDATE_1_Update1.Execute(r5010_10_OCORHIST_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R5010-10-OCORHIST-DB-SELECT-1 */
        public void R5010_10_OCORHIST_DB_SELECT_1()
        {
            /*" -3004- EXEC SQL SELECT NRCERTIF INTO :WHOST-NRCERTIF FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND OCORRHISTCTA = :V0PARC-OCORHIST WITH UR END-EXEC. */

            var r5010_10_OCORHIST_DB_SELECT_1_Query1 = new R5010_10_OCORHIST_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            var executed_1 = R5010_10_OCORHIST_DB_SELECT_1_Query1.Execute(r5010_10_OCORHIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRCERTIF, WHOST_NRCERTIF);
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-UPDATE-2 */
        public void R5000_00_GERA_PROXIMA_DB_UPDATE_2()
        {
            /*" -2692- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '2' , NRTITCOMP = :WHOST-NRTIT WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1 = new R5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1()
            {
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1.Execute(r5000_00_GERA_PROXIMA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-SELECT-4 */
        public void R5000_00_GERA_PROXIMA_DB_SELECT_4()
        {
            /*" -2550- EXEC SQL SELECT COD_SEGURO INTO :V0CONV-CODCONV FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES WITH UR END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_SELECT_4_Query1 = new R5000_00_GERA_PROXIMA_DB_SELECT_4_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R5000_00_GERA_PROXIMA_DB_SELECT_4_Query1.Execute(r5000_00_GERA_PROXIMA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-UPDATE-3 */
        public void R5000_00_GERA_PROXIMA_DB_UPDATE_3()
        {
            /*" -2711- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET DTVENCTO = :V0HCOB-DTVENCTO, VLPRMTOT = :WHOST-VLPREMIO, SITUACAO = '0' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_UPDATE_3_Update1 = new R5000_00_GERA_PROXIMA_DB_UPDATE_3_Update1()
            {
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                WHOST_VLPREMIO = WHOST_VLPREMIO.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_UPDATE_3_Update1.Execute(r5000_00_GERA_PROXIMA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-4 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_4()
        {
            /*" -2604- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, 1, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0PROP-DTVENCTO, :V0COBP-VLPREMIO, '0' , '1' , CURRENT TIMESTAMP, 0, :V0CONV-CODCONV, NULL, NULL, NULL, NULL, NULL, 0) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0COBP_VLPREMIO = V0COBP_VLPREMIO.ToString(),
                V0CONV_CODCONV = V0CONV_CODCONV.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_4_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5010_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-5 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_5()
        {
            /*" -2751- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :WHOST-NRTIT, :V0HCOB-DTVENCTO, :V0PARC-VLPRMTOT, :V0OPCP-OPCAOPAG, :V0HISC-SITUACAO, :WHOST-CODOPER, 0, 7996, 0, 0, 0, 0) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0PARC_VLPRMTOT = V0PARC_VLPRMTOT.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HISC_SITUACAO = V0HISC_SITUACAO.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_5_Insert1);

        }

        [StopWatch]
        /*" R5500-00-GERA-ATRASADAS-SECTION */
        private void R5500_00_GERA_ATRASADAS_SECTION()
        {
            /*" -3024- MOVE '25500' TO WNR-EXEC-SQL. */
            _.Move("25500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3025- IF (WTEM-PENDENTE NOT EQUAL 'S' ) */

            if ((AREA_DE_WORK.WTEM_PENDENTE != "S"))
            {

                /*" -3026- MOVE 'N' TO WTEM-PENDENTE */
                _.Move("N", AREA_DE_WORK.WTEM_PENDENTE);

                /*" -3028- END-IF. */
            }


            /*" -3036- PERFORM R1100-00-TRATA-V0DIFPARCELVA. */

            R1100_00_TRATA_V0DIFPARCELVA_SECTION();

            /*" -3038- IF (WHOST-VLPREMIO EQUAL ZEROES) OR (WHOST-VLPREMIO < ZEROES) */

            if ((WHOST_VLPREMIO == 00) || (WHOST_VLPREMIO < 00))
            {

                /*" -3039- MOVE V0HISC-NRPARCEL TO V2DIFP-NRPARCEL */
                _.Move(V0HISC_NRPARCEL, V2DIFP_NRPARCEL);

                /*" -3040- PERFORM R7000-00-QUITA-ATRASADA */

                R7000_00_QUITA_ATRASADA_SECTION();

                /*" -3041- GO TO R5500-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/ //GOTO
                return;

                /*" -3042- ELSE */
            }
            else
            {


                /*" -3044- IF (WHOST-VLPREMIO < V0PARC-VLPRMTOT) */

                if ((WHOST_VLPREMIO < V0PARC_VLPRMTOT))
                {

                    /*" -3050- PERFORM R5500_00_GERA_ATRASADAS_DB_UPDATE_1 */

                    R5500_00_GERA_ATRASADAS_DB_UPDATE_1();

                    /*" -3053- IF SQLCODE NOT EQUAL ZEROS AND 100 */

                    if (!DB.SQLCODE.In("00", "100"))
                    {

                        /*" -3054- MOVE 'F' TO LK-GE853-COD-RETORNO */
                        _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                        /*" -3055- MOVE '25501' TO WNR-EXEC-SQL */
                        _.Move("25501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3057- MOVE 'ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                        _.Move("ERRO NA ALTERACAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                        /*" -3058- GO TO R9999-00-FINALIZA-ROT */

                        R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                        return;

                        /*" -3059- END-IF */
                    }


                    /*" -3060- END-IF */
                }


                /*" -3067- END-IF. */
            }


            /*" -3070- MOVE V0PROP-DTPROXVEN TO V0PROP-DTVENCTO V0PARC-DTVENCTO V0HCOB-DTVENCTO. */
            _.Move(V0PROP_DTPROXVEN, V0PROP_DTVENCTO, V0PARC_DTVENCTO, V0HCOB_DTVENCTO);

            /*" -0- FLUXCONTROL_PERFORM R5540_10_OCORHIST */

            R5540_10_OCORHIST();

        }

        [StopWatch]
        /*" R5500-00-GERA-ATRASADAS-DB-UPDATE-1 */
        public void R5500_00_GERA_ATRASADAS_DB_UPDATE_1()
        {
            /*" -3050- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V0HISC-NRPARCEL, SITUACAO = '1' WHERE NRCERTIF = :V0HISC-NRCERTIF AND SITUACAO = ' ' END-EXEC */

            var r5500_00_GERA_ATRASADAS_DB_UPDATE_1_Update1 = new R5500_00_GERA_ATRASADAS_DB_UPDATE_1_Update1()
            {
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R5500_00_GERA_ATRASADAS_DB_UPDATE_1_Update1.Execute(r5500_00_GERA_ATRASADAS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-UPDATE-4 */
        public void R5000_00_GERA_PROXIMA_DB_UPDATE_4()
        {
            /*" -2860- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND OCORRHISTCTA < :V0PARC-OCORHIST END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1 = new R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1.Execute(r5000_00_GERA_PROXIMA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-6 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_6()
        {
            /*" -2785- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :WHOST-NRTIT, :V0HCOB-DTVENCTO, :V0COBP-VLPREMIO, :V0OPCP-OPCAOPAG, :V0HISC-SITUACAO, :WHOST-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_6_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_6_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0COBP_VLPREMIO = V0COBP_VLPREMIO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0HISC_SITUACAO = V0HISC_SITUACAO.ToString(),
                WHOST_CODOPER = WHOST_CODOPER.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_6_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_6_Insert1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-UPDATE-5 */
        public void R5000_00_GERA_PROXIMA_DB_UPDATE_5()
        {
            /*" -2890- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET DTVENCTO = :V0PROP-DTVENCTO, DTPROXVEN = :V0PROP-DTPROXVEN, NRPARCE = :V0PROP-NRPARCEL, QTDPARATZ = :V0PROP-QTDPARATZ, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF END-EXEC. */

            var r5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1 = new R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1.Execute(r5000_00_GERA_PROXIMA_DB_UPDATE_5_Update1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-SELECT-5 */
        public void R5000_00_GERA_PROXIMA_DB_SELECT_5()
        {
            /*" -2906- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :V0MOVF-COUNT FROM SEGUROS.V0MOVFDCAPVA WHERE NRCERTIF = :V0PROP-NRCERTIF WITH UR END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_SELECT_5_Query1 = new R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R5000_00_GERA_PROXIMA_DB_SELECT_5_Query1.Execute(r5000_00_GERA_PROXIMA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVF_COUNT, V0MOVF_COUNT);
            }


        }

        [StopWatch]
        /*" R5540-10-OCORHIST */
        private void R5540_10_OCORHIST(bool isPerform = false)
        {
            /*" -3080- MOVE '25540' TO WNR-EXEC-SQL. */
            _.Move("25540", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3082- COMPUTE V0PARC-OCORHIST = V0PARC-OCORHIST + 1. */
            V0PARC_OCORHIST.Value = V0PARC_OCORHIST + 1;

            /*" -3089- PERFORM R5540_10_OCORHIST_DB_UPDATE_1 */

            R5540_10_OCORHIST_DB_UPDATE_1();

            /*" -3092- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3093- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3094- MOVE '25541' TO WNR-EXEC-SQL */
                _.Move("25541", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3096- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -3097- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3099- END-IF. */
            }


            /*" -3107- PERFORM R5540_10_OCORHIST_DB_SELECT_1 */

            R5540_10_OCORHIST_DB_SELECT_1();

            /*" -3110- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3111- GO TO R5540-10-OCORHIST */
                new Task(() => R5540_10_OCORHIST()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -3113- END-IF. */
            }


            /*" -3114- IF (V0HCOB-DTVENCTO < V1SIST-DTVENFIM-VE) */

            if ((V0HCOB_DTVENCTO < V1SIST_DTVENFIM_VE))
            {

                /*" -3115- MOVE V1SIST-DTVENFIM-VE TO V0HCOB-DTVENCTO */
                _.Move(V1SIST_DTVENFIM_VE, V0HCOB_DTVENCTO);

                /*" -3117- END-IF. */
            }


            /*" -3124- PERFORM R5540_10_OCORHIST_DB_UPDATE_2 */

            R5540_10_OCORHIST_DB_UPDATE_2();

            /*" -3127- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3128- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3129- MOVE '25542' TO WNR-EXEC-SQL */
                _.Move("25542", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3131- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                /*" -3132- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3137- END-IF. */
            }


            /*" -3144- PERFORM R5540_10_OCORHIST_DB_SELECT_2 */

            R5540_10_OCORHIST_DB_SELECT_2();

            /*" -3147- IF (SQLCODE NOT EQUAL ZEROES) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3148- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3149- MOVE '25543' TO WNR-EXEC-SQL */
                _.Move("25543", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3151- MOVE 'ERRO NA CONSULTA DA TABELA V0CONVENIOSVG' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0CONVENIOSVG", WS_MSG_RETORNO);

                /*" -3152- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3156- END-IF. */
            }


            /*" -3199- PERFORM R5540_10_OCORHIST_DB_INSERT_1 */

            R5540_10_OCORHIST_DB_INSERT_1();

            /*" -3202- IF (SQLCODE NOT EQUAL ZEROES AND -803) */

            if ((!DB.SQLCODE.In("00", "-803")))
            {

                /*" -3203- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3204- MOVE '25544' TO WNR-EXEC-SQL */
                _.Move("25544", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3206- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCONTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCONTAVA", WS_MSG_RETORNO);

                /*" -3207- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3209- END-IF. */
            }


            /*" -3215- PERFORM R5540_10_OCORHIST_DB_UPDATE_3 */

            R5540_10_OCORHIST_DB_UPDATE_3();

            /*" -3218- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3219- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3220- MOVE '25545' TO WNR-EXEC-SQL */
                _.Move("25545", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3222- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCONTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCONTAVA", WS_MSG_RETORNO);

                /*" -3223- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3225- END-IF. */
            }


            /*" -3226- MOVE 'S' TO WTEM-PENDENTE. */
            _.Move("S", AREA_DE_WORK.WTEM_PENDENTE);

        }

        [StopWatch]
        /*" R5540-10-OCORHIST-DB-UPDATE-1 */
        public void R5540_10_OCORHIST_DB_UPDATE_1()
        {
            /*" -3089- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET PRMVG = :WHOST-PRMVG, PRMAP = :WHOST-PRMAP, OCORHIST = :V0PARC-OCORHIST WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC. */

            var r5540_10_OCORHIST_DB_UPDATE_1_Update1 = new R5540_10_OCORHIST_DB_UPDATE_1_Update1()
            {
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R5540_10_OCORHIST_DB_UPDATE_1_Update1.Execute(r5540_10_OCORHIST_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R5540-10-OCORHIST-DB-SELECT-1 */
        public void R5540_10_OCORHIST_DB_SELECT_1()
        {
            /*" -3107- EXEC SQL SELECT NRCERTIF INTO :WHOST-NRCERTIF FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND OCORRHISTCTA = :V0PARC-OCORHIST WITH UR END-EXEC. */

            var r5540_10_OCORHIST_DB_SELECT_1_Query1 = new R5540_10_OCORHIST_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            var executed_1 = R5540_10_OCORHIST_DB_SELECT_1_Query1.Execute(r5540_10_OCORHIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRCERTIF, WHOST_NRCERTIF);
            }


        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-7 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_7()
        {
            /*" -2843- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0HISC-NRCERTIF, :V0HISC-NRPARCEL, :V0PARC-OCORHIST, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HCOB-DTVENCTO, :WHOST-VLPREMIO-ATR, '0' , '1' , CURRENT TIMESTAMP, 0, :V0CONV-CODCONV, NULL, NULL, NULL, NULL, NULL, 0) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_7_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_7_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                WHOST_VLPREMIO_ATR = WHOST_VLPREMIO_ATR.ToString(),
                V0CONV_CODCONV = V0CONV_CODCONV.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_7_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_7_Insert1);

        }

        [StopWatch]
        /*" R5540-10-OCORHIST-DB-UPDATE-2 */
        public void R5540_10_OCORHIST_DB_UPDATE_2()
        {
            /*" -3124- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET DTVENCTO = :V0HCOB-DTVENCTO, VLPRMTOT = :WHOST-VLPREMIO, SITUACAO = '0' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC. */

            var r5540_10_OCORHIST_DB_UPDATE_2_Update1 = new R5540_10_OCORHIST_DB_UPDATE_2_Update1()
            {
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                WHOST_VLPREMIO = WHOST_VLPREMIO.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R5540_10_OCORHIST_DB_UPDATE_2_Update1.Execute(r5540_10_OCORHIST_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R5540-10-OCORHIST-DB-INSERT-1 */
        public void R5540_10_OCORHIST_DB_INSERT_1()
        {
            /*" -3199- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:V0HISC-NRCERTIF, :V0HISC-NRPARCEL, :V0PARC-OCORHIST, :V0OPCP-AGECTADEB, :V0OPCP-OPRCTADEB, :V0OPCP-NUMCTADEB, :V0OPCP-DIGCTADEB, :V0HCOB-DTVENCTO, :WHOST-VLPREMIO, '0' , '1' , CURRENT TIMESTAMP, 0, :V0CONV-CODCONV, NULL, NULL, NULL, NULL, NULL, 0) END-EXEC. */

            var r5540_10_OCORHIST_DB_INSERT_1_Insert1 = new R5540_10_OCORHIST_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0OPCP_AGECTADEB = V0OPCP_AGECTADEB.ToString(),
                V0OPCP_OPRCTADEB = V0OPCP_OPRCTADEB.ToString(),
                V0OPCP_NUMCTADEB = V0OPCP_NUMCTADEB.ToString(),
                V0OPCP_DIGCTADEB = V0OPCP_DIGCTADEB.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                WHOST_VLPREMIO = WHOST_VLPREMIO.ToString(),
                V0CONV_CODCONV = V0CONV_CODCONV.ToString(),
            };

            R5540_10_OCORHIST_DB_INSERT_1_Insert1.Execute(r5540_10_OCORHIST_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R5540-10-OCORHIST-DB-SELECT-2 */
        public void R5540_10_OCORHIST_DB_SELECT_2()
        {
            /*" -3144- EXEC SQL SELECT COD_SEGURO INTO :V0CONV-CODCONV FROM SEGUROS.V0CONVENIOSVG WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND CODSUBES = :V0PROP-CODSUBES WITH UR END-EXEC. */

            var r5540_10_OCORHIST_DB_SELECT_2_Query1 = new R5540_10_OCORHIST_DB_SELECT_2_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R5540_10_OCORHIST_DB_SELECT_2_Query1.Execute(r5540_10_OCORHIST_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R5540-10-OCORHIST-DB-UPDATE-3 */
        public void R5540_10_OCORHIST_DB_UPDATE_3()
        {
            /*" -3215- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND OCORRHISTCTA < :V0PARC-OCORHIST END-EXEC. */

            var r5540_10_OCORHIST_DB_UPDATE_3_Update1 = new R5540_10_OCORHIST_DB_UPDATE_3_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
            };

            R5540_10_OCORHIST_DB_UPDATE_3_Update1.Execute(r5540_10_OCORHIST_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R5000-00-GERA-PROXIMA-DB-INSERT-8 */
        public void R5000_00_GERA_PROXIMA_DB_INSERT_8()
        {
            /*" -2933- EXEC SQL INSERT INTO SEGUROS.V0PARCELCAPVG VALUES (:V0HISC-NRCERTIF, :WHOST-PARCELCAP, :V0PARC-DTVENCTO, :V0COBP-VLCUSTCAP, :V0COBP-VLCUSTCAP, '3' , '0' , 0, 0, CURRENT TIMESTAMP) END-EXEC */

            var r5000_00_GERA_PROXIMA_DB_INSERT_8_Insert1 = new R5000_00_GERA_PROXIMA_DB_INSERT_8_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                WHOST_PARCELCAP = WHOST_PARCELCAP.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0COBP_VLCUSTCAP = V0COBP_VLCUSTCAP.ToString(),
            };

            R5000_00_GERA_PROXIMA_DB_INSERT_8_Insert1.Execute(r5000_00_GERA_PROXIMA_DB_INSERT_8_Insert1);

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-SECTION */
        private void R6000_00_CANCELA_SEGURO_SECTION()
        {
            /*" -3237- MOVE '26000' TO WNR-EXEC-SQL. */
            _.Move("26000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3240- MOVE 'N' TO WS-FLAG-PROX */
            _.Move("N", AREA_DE_WORK.WS_FLAG_PROX);

            /*" -3255- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_1 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_1();

            /*" -3258- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3259- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3260- MOVE '26001' TO WNR-EXEC-SQL */
                _.Move("26001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3262- MOVE 'ERRO NA CONSULTA DA TABELA V0SEGURAVG' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0SEGURAVG", WS_MSG_RETORNO);

                /*" -3263- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3269- END-IF. */
            }


            /*" -3271- MOVE ZEROS TO QTD-CANCEL. */
            _.Move(0, AREA_DE_WORK.QTD_CANCEL);

            /*" -3280- PERFORM R1100-00-TRATA-V0DIFPARCELVA. */

            R1100_00_TRATA_V0DIFPARCELVA_SECTION();

            /*" -3282- IF WHOST-VLPREMIO EQUAL ZEROES OR WHOST-VLPREMIO LESS ZEROES */

            if (WHOST_VLPREMIO == 00 || WHOST_VLPREMIO < 00)
            {

                /*" -3283- MOVE V0HISC-NRPARCEL TO V2DIFP-NRPARCEL */
                _.Move(V0HISC_NRPARCEL, V2DIFP_NRPARCEL);

                /*" -3284- PERFORM R7000-00-QUITA-ATRASADA */

                R7000_00_QUITA_ATRASADA_SECTION();

                /*" -3285- GO TO R6000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/ //GOTO
                return;

                /*" -3285- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R6000_10_CANCEL */

            R6000_10_CANCEL();

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-1 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_1()
        {
            /*" -3255- EXEC SQL SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, LOT_EMP_SEGURADO INTO :V0SEGU-TPINCLUS, :V0SEGU-AGENCIADOR, :V0SEGU-ITEM, :V0SEGU-OCORHIST, :V0SEGU-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEG FROM SEGUROS.V0SEGURAVG WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SEGU_TPINCLUS, V0SEGU_TPINCLUS);
                _.Move(executed_1.V0SEGU_AGENCIADOR, V0SEGU_AGENCIADOR);
                _.Move(executed_1.V0SEGU_ITEM, V0SEGU_ITEM);
                _.Move(executed_1.V0SEGU_OCORHIST, V0SEGU_OCORHIST);
                _.Move(executed_1.V0SEGU_LOT_EMP_SEGURADO, V0SEGU_LOT_EMP_SEGURADO);
                _.Move(executed_1.VIND_LOT_EMP_SEG, VIND_LOT_EMP_SEG);
            }


        }

        [StopWatch]
        /*" R6000-10-CANCEL */
        private void R6000_10_CANCEL(bool isPerform = false)
        {
            /*" -3292- ADD 1 TO V0HISC-OCORHIST. */
            V0HISC_OCORHIST.Value = V0HISC_OCORHIST + 1;

            /*" -3298- PERFORM R6000_10_CANCEL_DB_UPDATE_1 */

            R6000_10_CANCEL_DB_UPDATE_1();

            /*" -3301- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3302- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3303- MOVE '26002' TO WNR-EXEC-SQL */
                _.Move("26002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3305- MOVE 'ERRO NA ALTERACAO DA TABELA PROPOSTA_VA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA PROPOSTA_VA", WS_MSG_RETORNO);

                /*" -3306- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3308- END-IF. */
            }


            /*" -3310- MOVE '4' TO LK-GE853-SIT-CERTIFICADO. */
            _.Move("4", REGISTRO_LINKAGE_GE0853S.LK_GE853_SIT_CERTIFICADO);

            /*" -3316- PERFORM R6000_10_CANCEL_DB_UPDATE_2 */

            R6000_10_CANCEL_DB_UPDATE_2();

            /*" -3319- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -3320- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3321- MOVE '26003' TO WNR-EXEC-SQL */
                _.Move("26003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3323- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                /*" -3324- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3326- END-IF. */
            }


            /*" -3332- PERFORM R6000_10_CANCEL_DB_UPDATE_3 */

            R6000_10_CANCEL_DB_UPDATE_3();

            /*" -3335- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -3336- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3337- MOVE '26004' TO WNR-EXEC-SQL */
                _.Move("26004", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3339- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -3340- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3342- END-IF. */
            }


            /*" -3348- PERFORM R6000_10_CANCEL_DB_UPDATE_4 */

            R6000_10_CANCEL_DB_UPDATE_4();

            /*" -3351- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -3352- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3353- MOVE '26005' TO WNR-EXEC-SQL */
                _.Move("26005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3355- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCONTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCONTAVA", WS_MSG_RETORNO);

                /*" -3356- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3362- END-IF. */
            }


            /*" -3369- PERFORM R6000_10_CANCEL_DB_SELECT_1 */

            R6000_10_CANCEL_DB_SELECT_1();

            /*" -3372- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -3373- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3374- MOVE '26006' TO WNR-EXEC-SQL */
                _.Move("26006", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3376- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -3377- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3386- END-IF. */
            }


            /*" -3388- MOVE '0' TO WS-PAGO. */
            _.Move("0", AREA_DE_WORK.WS_PAGO);

            /*" -3389- IF VIND-NRPARCEL LESS 0 */

            if (VIND_NRPARCEL < 0)
            {

                /*" -3391- MOVE '1' TO WS-PAGO */
                _.Move("1", AREA_DE_WORK.WS_PAGO);

                /*" -3397- PERFORM R6000_10_CANCEL_DB_SELECT_2 */

                R6000_10_CANCEL_DB_SELECT_2();

                /*" -3400- IF VIND-NRPARCEL LESS 0 */

                if (VIND_NRPARCEL < 0)
                {

                    /*" -3401- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3402- MOVE '26007' TO WNR-EXEC-SQL */
                    _.Move("26007", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3404- MOVE 'PARCELA NAO EXISTE NA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                    _.Move("PARCELA NAO EXISTE NA TABELA V0PARCELVA", WS_MSG_RETORNO);

                    /*" -3405- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3406- END-IF */
                }


                /*" -3408- END-IF */
            }


            /*" -3409- IF WS-PAGO EQUAL '0' */

            if (AREA_DE_WORK.WS_PAGO == "0")
            {

                /*" -3416- PERFORM R6000_10_CANCEL_DB_SELECT_3 */

                R6000_10_CANCEL_DB_SELECT_3();

                /*" -3419- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -3420- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3421- MOVE '26008' TO WNR-EXEC-SQL */
                    _.Move("26008", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3423- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                    /*" -3424- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3425- END-IF */
                }


                /*" -3426- ELSE */
            }
            else
            {


                /*" -3433- PERFORM R6000_10_CANCEL_DB_SELECT_4 */

                R6000_10_CANCEL_DB_SELECT_4();

                /*" -3436- IF (SQLCODE NOT EQUAL ZEROS) */

                if ((DB.SQLCODE != 00))
                {

                    /*" -3437- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3438- MOVE '26009' TO WNR-EXEC-SQL */
                    _.Move("26009", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3440- MOVE 'ERRO NA CONSULTA DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                    /*" -3441- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3442- END-IF */
                }


                /*" -3444- END-IF */
            }


            /*" -3454- PERFORM R6000_10_CANCEL_DB_SELECT_5 */

            R6000_10_CANCEL_DB_SELECT_5();

            /*" -3457- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3458- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3459- MOVE '26010' TO WNR-EXEC-SQL */
                _.Move("26010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3461- MOVE 'ERRO NA CONSULTA DA TABELA V0COBERPROPVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0COBERPROPVA", WS_MSG_RETORNO);

                /*" -3462- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3468- END-IF. */
            }


            /*" -3469- MOVE 'VA0432B' TO V0RELA-CODRELAT. */
            _.Move("VA0432B", V0RELA_CODRELAT);

            /*" -3470- MOVE 0 TO V0RELA-QTDPARATZ. */
            _.Move(0, V0RELA_QTDPARATZ);

            /*" -3476- PERFORM R4500-00-SOLIC-RELAT. */

            R4500_00_SOLIC_RELAT_SECTION();

            /*" -3482- PERFORM R6000_10_CANCEL_DB_SELECT_6 */

            R6000_10_CANCEL_DB_SELECT_6();

            /*" -3485- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3486- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3487- MOVE '26011' TO WNR-EXEC-SQL */
                _.Move("26011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3489- MOVE 'ERRO NA CONSULTA DA TABELA V0FONTE' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0FONTE", WS_MSG_RETORNO);

                /*" -3490- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3492- END-IF. */
            }


            /*" -3497- COMPUTE V0FONT-PROPAUTOM = V0FONT-PROPAUTOM + 1. */
            V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

            /*" -3504- PERFORM R6000_10_CANCEL_DB_SELECT_7 */

            R6000_10_CANCEL_DB_SELECT_7();

            /*" -3507- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3514- PERFORM R6000_10_CANCEL_DB_SELECT_8 */

                R6000_10_CANCEL_DB_SELECT_8();

                /*" -3517- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3518- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -3519- MOVE V1SIST-DTMOVABE TO WDATA-SISTEMA-AUX */
                        _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_SISTEMA_AUX);

                        /*" -3520- MOVE 1 TO WDATA-AUX-DIA */
                        _.Move(1, AREA_DE_WORK.WDATA_SISTEMA_AUX.WDATA_AUX_DIA);

                        /*" -3521- MOVE WDATA-SISTEMA-AUX TO V0FATC-DTREF */
                        _.Move(AREA_DE_WORK.WDATA_SISTEMA_AUX, V0FATC_DTREF);

                        /*" -3522- ELSE */
                    }
                    else
                    {


                        /*" -3523- MOVE 'F' TO LK-GE853-COD-RETORNO */
                        _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                        /*" -3524- MOVE '26012' TO WNR-EXEC-SQL */
                        _.Move("26012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -3526- MOVE 'ERRO NA CONSULTA DA TABELA V0FATURCONT' TO WS-MSG-RETORNO */
                        _.Move("ERRO NA CONSULTA DA TABELA V0FATURCONT", WS_MSG_RETORNO);

                        /*" -3527- GO TO R9999-00-FINALIZA-ROT */

                        R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                        return;

                        /*" -3528- END-IF */
                    }


                    /*" -3529- END-IF */
                }


                /*" -3539- END-IF. */
            }


            /*" -3553- PERFORM R6000_10_CANCEL_DB_SELECT_9 */

            R6000_10_CANCEL_DB_SELECT_9();

            /*" -3556- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3558- MOVE ZEROS TO V0COBA-IMPMORNATU V0COBA-PRMVG */
                _.Move(0, V0COBA_IMPMORNATU, V0COBA_PRMVG);

                /*" -3560- END-IF. */
            }


            /*" -3574- PERFORM R6000_10_CANCEL_DB_SELECT_10 */

            R6000_10_CANCEL_DB_SELECT_10();

            /*" -3577- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3579- MOVE ZEROS TO V0COBA-IMPMORACID V0COBA-PRMAP */
                _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);

                /*" -3581- END-IF */
            }


            /*" -3593- PERFORM R6000_10_CANCEL_DB_SELECT_11 */

            R6000_10_CANCEL_DB_SELECT_11();

            /*" -3596- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3597- MOVE 0 TO V0COBA-IMPINVPERM */
                _.Move(0, V0COBA_IMPINVPERM);

                /*" -3599- END-IF */
            }


            /*" -3611- PERFORM R6000_10_CANCEL_DB_SELECT_12 */

            R6000_10_CANCEL_DB_SELECT_12();

            /*" -3614- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3615- MOVE 0 TO V0COBA-IMPDIT */
                _.Move(0, V0COBA_IMPDIT);

                /*" -3615- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-UPDATE-1 */
        public void R6000_10_CANCEL_DB_UPDATE_1()
        {
            /*" -3298- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '4' , COD_USUARIO = 'VA0853B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF END-EXEC. */

            var r6000_10_CANCEL_DB_UPDATE_1_Update1 = new R6000_10_CANCEL_DB_UPDATE_1_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R6000_10_CANCEL_DB_UPDATE_1_Update1.Execute(r6000_10_CANCEL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6000-20-PROPAUTOM */
        private void R6000_20_PROPAUTOM(bool isPerform = false)
        {
            /*" -3699- PERFORM R6000_20_PROPAUTOM_DB_INSERT_1 */

            R6000_20_PROPAUTOM_DB_INSERT_1();

            /*" -3702- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3703- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -3704- ADD 1 TO V0FONT-PROPAUTOM */
                    V0FONT_PROPAUTOM.Value = V0FONT_PROPAUTOM + 1;

                    /*" -3705- GO TO R6000-20-PROPAUTOM */
                    new Task(() => R6000_20_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3706- ELSE */
                }
                else
                {


                    /*" -3707- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3708- MOVE '26013' TO WNR-EXEC-SQL */
                    _.Move("26013", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3710- MOVE 'ERRO NA INCLUSAO DA TABELA  V0MOVIMENTO' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA  V0MOVIMENTO", WS_MSG_RETORNO);

                    /*" -3711- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3712- END-IF */
                }


                /*" -3714- END-IF. */
            }


            /*" -3719- PERFORM R6000_20_PROPAUTOM_DB_UPDATE_1 */

            R6000_20_PROPAUTOM_DB_UPDATE_1();

            /*" -3722- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3723- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3724- MOVE '26014' TO WNR-EXEC-SQL */
                _.Move("26014", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3726- MOVE 'ERRO NA ALTERACAO DA TABELA V0FONTE' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0FONTE", WS_MSG_RETORNO);

                /*" -3727- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3727- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-20-PROPAUTOM-DB-INSERT-1 */
        public void R6000_20_PROPAUTOM_DB_INSERT_1()
        {
            /*" -3699- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0FONT-PROPAUTOM, '1' , :V0PROP-NRCERTIF, ' ' , :V0SEGU-TPINCLUS, :V0PROP-CODCLIEN, :V0SEGU-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :V0OPCP-PERIPGTO, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, 0, ' ' , :V0PROP-NRMATRFUN, 0, ' ' , 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, 403, CURRENT DATE, 0, '1' , 'GE0853S' , CURRENT DATE, NULL, NULL, NULL, NULL, :V0FATC-DTREF, :V0MOVI-DTMOVTO, NULL, :V0SEGU-LOT-EMP-SEGURADO:VIND-LOT-EMP-SEG) END-EXEC. */

            var r6000_20_PROPAUTOM_DB_INSERT_1_Insert1 = new R6000_20_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0SEGU_TPINCLUS = V0SEGU_TPINCLUS.ToString(),
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0SEGU_AGENCIADOR = V0SEGU_AGENCIADOR.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0COBA_IMPMORNATU = V0COBA_IMPMORNATU.ToString(),
                V0COBA_IMPMORACID = V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = V0COBA_IMPDIT.ToString(),
                V0COBA_PRMVG = V0COBA_PRMVG.ToString(),
                V0COBA_PRMAP = V0COBA_PRMAP.ToString(),
                V0FATC_DTREF = V0FATC_DTREF.ToString(),
                V0MOVI_DTMOVTO = V0MOVI_DTMOVTO.ToString(),
                V0SEGU_LOT_EMP_SEGURADO = V0SEGU_LOT_EMP_SEGURADO.ToString(),
                VIND_LOT_EMP_SEG = VIND_LOT_EMP_SEG.ToString(),
            };

            R6000_20_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r6000_20_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R6000-20-PROPAUTOM-DB-UPDATE-1 */
        public void R6000_20_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -3719- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V0FONT-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0PROP-FONTE END-EXEC. */

            var r6000_20_PROPAUTOM_DB_UPDATE_1_Update1 = new R6000_20_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                V0FONT_PROPAUTOM = V0FONT_PROPAUTOM.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
            };

            R6000_20_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r6000_20_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-UPDATE-2 */
        public void R6000_10_CANCEL_DB_UPDATE_2()
        {
            /*" -3316- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '2' , OCORHIST = :V0HISC-OCORHIST WHERE NRCERTIF = :V0HISC-NRCERTIF AND SITUACAO NOT IN ( '1' , '2' ) END-EXEC. */

            var r6000_10_CANCEL_DB_UPDATE_2_Update1 = new R6000_10_CANCEL_DB_UPDATE_2_Update1()
            {
                V0HISC_OCORHIST = V0HISC_OCORHIST.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R6000_10_CANCEL_DB_UPDATE_2_Update1.Execute(r6000_10_CANCEL_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-1 */
        public void R6000_10_CANCEL_DB_SELECT_1()
        {
            /*" -3369- EXEC SQL SELECT MAX(NRPARCEL) INTO :WHOST-NRPARCEL:VIND-NRPARCEL FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND SITUACAO IN ( '1' , '9' ) WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_1_Query1 = new R6000_10_CANCEL_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_1_Query1.Execute(r6000_10_CANCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRPARCEL, WHOST_NRPARCEL);
                _.Move(executed_1.VIND_NRPARCEL, VIND_NRPARCEL);
            }


        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-UPDATE-3 */
        public void R6000_10_CANCEL_DB_UPDATE_3()
        {
            /*" -3332- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF AND SITUACAO NOT IN ( '1' , '2' ) END-EXEC. */

            var r6000_10_CANCEL_DB_UPDATE_3_Update1 = new R6000_10_CANCEL_DB_UPDATE_3_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R6000_10_CANCEL_DB_UPDATE_3_Update1.Execute(r6000_10_CANCEL_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-2 */
        public void R6000_10_CANCEL_DB_SELECT_2()
        {
            /*" -3397- EXEC SQL SELECT MIN(NRPARCEL) INTO :WHOST-NRPARCEL:VIND-NRPARCEL FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF WITH UR END-EXEC */

            var r6000_10_CANCEL_DB_SELECT_2_Query1 = new R6000_10_CANCEL_DB_SELECT_2_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_2_Query1.Execute(r6000_10_CANCEL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_NRPARCEL, WHOST_NRPARCEL);
                _.Move(executed_1.VIND_NRPARCEL, VIND_NRPARCEL);
            }


        }

        [StopWatch]
        /*" R6100-00-SELECT-APOLICE-SECTION */
        private void R6100_00_SELECT_APOLICE_SECTION()
        {
            /*" -3740- MOVE '26100' TO WNR-EXEC-SQL. */
            _.Move("26100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3746- PERFORM R6100_00_SELECT_APOLICE_DB_SELECT_1 */

            R6100_00_SELECT_APOLICE_DB_SELECT_1();

            /*" -3749- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3750- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3751- MOVE '26101' TO WNR-EXEC-SQL */
                _.Move("26101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3753- MOVE 'ERRO NA CONSULTA DA TABELA  APOLICES' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA  APOLICES", WS_MSG_RETORNO);

                /*" -3754- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3755- END-IF. */
            }


        }

        [StopWatch]
        /*" R6100-00-SELECT-APOLICE-DB-SELECT-1 */
        public void R6100_00_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -3746- EXEC SQL SELECT COD_MODALIDADE INTO :APOLICES-COD-MODALIDADE FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE WITH UR END-EXEC. */

            var r6100_00_SELECT_APOLICE_DB_SELECT_1_Query1 = new R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6100_00_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(r6100_00_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_MODALIDADE, APOLICES.DCLAPOLICES.APOLICES_COD_MODALIDADE);
            }


        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-3 */
        public void R6000_10_CANCEL_DB_SELECT_3()
        {
            /*" -3416- EXEC SQL SELECT DTVENCTO + :V0OPCP-PERIPGTO MONTHS INTO :V0MOVI-DTMOVTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL WITH UR END-EXEC */

            var r6000_10_CANCEL_DB_SELECT_3_Query1 = new R6000_10_CANCEL_DB_SELECT_3_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_3_Query1.Execute(r6000_10_CANCEL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVI_DTMOVTO, V0MOVI_DTMOVTO);
            }


        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-UPDATE-4 */
        public void R6000_10_CANCEL_DB_UPDATE_4()
        {
            /*" -3348- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND TIPLANC = '1' AND SITUACAO IN ( ' ' , '0' , X'00' ) END-EXEC. */

            var r6000_10_CANCEL_DB_UPDATE_4_Update1 = new R6000_10_CANCEL_DB_UPDATE_4_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R6000_10_CANCEL_DB_UPDATE_4_Update1.Execute(r6000_10_CANCEL_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-4 */
        public void R6000_10_CANCEL_DB_SELECT_4()
        {
            /*" -3433- EXEC SQL SELECT DTVENCTO INTO :V0MOVI-DTMOVTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :WHOST-NRPARCEL WITH UR END-EXEC */

            var r6000_10_CANCEL_DB_SELECT_4_Query1 = new R6000_10_CANCEL_DB_SELECT_4_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_4_Query1.Execute(r6000_10_CANCEL_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MOVI_DTMOVTO, V0MOVI_DTMOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-5 */
        public void R6000_10_CANCEL_DB_SELECT_5()
        {
            /*" -3454- EXEC SQL SELECT PRMVG, PRMAP INTO :V0COBP-PRMVG, :V0COBP-PRMAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0PROP-NRCERTIF AND DTINIVIG <= :V0PROP-DTPROXVEN AND DTTERVIG >= :V0PROP-DTPROXVEN WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_5_Query1 = new R6000_10_CANCEL_DB_SELECT_5_Query1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_5_Query1.Execute(r6000_10_CANCEL_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
            }


        }

        [StopWatch]
        /*" R7000-00-QUITA-ATRASADA-SECTION */
        private void R7000_00_QUITA_ATRASADA_SECTION()
        {
            /*" -3768- MOVE '27000' TO WNR-EXEC-SQL. */
            _.Move("27000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3774- PERFORM R7000_00_QUITA_ATRASADA_DB_UPDATE_1 */

            R7000_00_QUITA_ATRASADA_DB_UPDATE_1();

            /*" -3777- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3778- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3779- MOVE '27001' TO WNR-EXEC-SQL */
                _.Move("27001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3781- MOVE 'ERRO NA ALTERACAO DA TABELA CHISTCB' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA CHISTCB", WS_MSG_RETORNO);

                /*" -3782- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3784- END-IF. */
            }


            /*" -3792- PERFORM R7000_00_QUITA_ATRASADA_DB_UPDATE_2 */

            R7000_00_QUITA_ATRASADA_DB_UPDATE_2();

            /*" -3795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3796- DISPLAY 'R7000-00 (ERRO - UPDATE V0PARCELVA)' */
                _.Display($"R7000-00 (ERRO - UPDATE V0PARCELVA)");

                /*" -3797- DISPLAY 'CERTIF: ' V0HISC-NRCERTIF ' ' V2DIFP-NRPARCEL */

                $"CERTIF: {V0HISC_NRCERTIF} {V2DIFP_NRPARCEL}"
                .Display();

                /*" -3798- MOVE 'S' TO WTEM-ERRO */
                _.Move("S", AREA_DE_WORK.WTEM_ERRO);

                /*" -3799- GO TO R7000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;

                /*" -3801- END-IF. */
            }


            /*" -3807- PERFORM R7000_00_QUITA_ATRASADA_DB_UPDATE_3 */

            R7000_00_QUITA_ATRASADA_DB_UPDATE_3();

            /*" -3810- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3811- DISPLAY 'R7000-00 (ERRO - UPDATE V0DIFPARCELVA)' */
                _.Display($"R7000-00 (ERRO - UPDATE V0DIFPARCELVA)");

                /*" -3814- DISPLAY 'CERTIF: ' V0HISC-NRCERTIF ' PARCEL: ' V2DIFP-NRPARCEL ' VENCTO: ' V0PARC-DTVENCTO */

                $"CERTIF: {V0HISC_NRCERTIF} PARCEL: {V2DIFP_NRPARCEL} VENCTO: {V0PARC_DTVENCTO}"
                .Display();

                /*" -3815- MOVE 'S' TO WTEM-ERRO */
                _.Move("S", AREA_DE_WORK.WTEM_ERRO);

                /*" -3816- GO TO R7000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;

                /*" -3818- END-IF. */
            }


            /*" -3819- IF WHOST-VLPREMIO LESS ZEROES */

            if (WHOST_VLPREMIO < 00)
            {

                /*" -3820- IF WHOST-PRMVG LESS ZEROES */

                if (WHOST_PRMVG < 00)
                {

                    /*" -3821- COMPUTE WHOST-PRMVG = WHOST-PRMVG * -1 */
                    WHOST_PRMVG.Value = WHOST_PRMVG * -1;

                    /*" -3822- END-IF */
                }


                /*" -3823- IF WHOST-PRMAP LESS ZEROES */

                if (WHOST_PRMAP < 00)
                {

                    /*" -3824- COMPUTE WHOST-PRMAP = WHOST-PRMAP * -1 */
                    WHOST_PRMAP.Value = WHOST_PRMAP * -1;

                    /*" -3826- END-IF */
                }


                /*" -3841- PERFORM R7000_00_QUITA_ATRASADA_DB_INSERT_1 */

                R7000_00_QUITA_ATRASADA_DB_INSERT_1();

                /*" -3844- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -3845- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3846- MOVE '27002' TO WNR-EXEC-SQL */
                    _.Move("27002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3848- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                    /*" -3849- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3850- END-IF */
                }


                /*" -3852- END-IF. */
            }


            /*" -3856- PERFORM R7000_00_QUITA_ATRASADA_DB_UPDATE_4 */

            R7000_00_QUITA_ATRASADA_DB_UPDATE_4();

            /*" -3859- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -3860- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3861- MOVE '27003' TO WNR-EXEC-SQL */
                _.Move("27003", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3863- MOVE 'ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA", WS_MSG_RETORNO);

                /*" -3864- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3866- END-IF */
            }


            /*" -3866- PERFORM R7700-00-VERIFICA-REPASSES. */

            R7700_00_VERIFICA_REPASSES_SECTION();

        }

        [StopWatch]
        /*" R7000-00-QUITA-ATRASADA-DB-UPDATE-1 */
        public void R7000_00_QUITA_ATRASADA_DB_UPDATE_1()
        {
            /*" -3774- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '1' , VLPRMTOT = 0 WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC. */

            var r7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1 = new R7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1.Execute(r7000_00_QUITA_ATRASADA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-6 */
        public void R6000_10_CANCEL_DB_SELECT_6()
        {
            /*" -3482- EXEC SQL SELECT PROPAUTOM INTO :V0FONT-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :V0PROP-FONTE WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_6_Query1 = new R6000_10_CANCEL_DB_SELECT_6_Query1()
            {
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_6_Query1.Execute(r6000_10_CANCEL_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FONT_PROPAUTOM, V0FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R7000-00-QUITA-ATRASADA-DB-UPDATE-2 */
        public void R7000_00_QUITA_ATRASADA_DB_UPDATE_2()
        {
            /*" -3792- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '1' , PRMVG = 0, PRMAP = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V2DIFP-NRPARCEL END-EXEC. */

            var r7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1 = new R7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V2DIFP_NRPARCEL = V2DIFP_NRPARCEL.ToString(),
            };

            R7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1.Execute(r7000_00_QUITA_ATRASADA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R7000-00-QUITA-ATRASADA-DB-INSERT-1 */
        public void R7000_00_QUITA_ATRASADA_DB_INSERT_1()
        {
            /*" -3841- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, 9999, :V0PROP-NRPARCEL, 601, :V0PROP-DTVENCTO, 0.00, 0.00, 0.00, 0.00, :WHOST-PRMVG, :WHOST-PRMAP, 0.00, ' ' ) END-EXEC */

            var r7000_00_QUITA_ATRASADA_DB_INSERT_1_Insert1 = new R7000_00_QUITA_ATRASADA_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
            };

            R7000_00_QUITA_ATRASADA_DB_INSERT_1_Insert1.Execute(r7000_00_QUITA_ATRASADA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-QUITA-ATRASADA-DB-UPDATE-3 */
        public void R7000_00_QUITA_ATRASADA_DB_UPDATE_3()
        {
            /*" -3807- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET NRPARCEL = :V2DIFP-NRPARCEL, SITUACAO = '1' WHERE NRCERTIF = :V0HISC-NRCERTIF AND SITUACAO = ' ' END-EXEC. */

            var r7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1 = new R7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1()
            {
                V2DIFP_NRPARCEL = V2DIFP_NRPARCEL.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1.Execute(r7000_00_QUITA_ATRASADA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-7 */
        public void R6000_10_CANCEL_DB_SELECT_7()
        {
            /*" -3504- EXEC SQL SELECT DATA_REFERENCIA INTO :V0FATC-DTREF FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = :V0PROP-CODSUBES WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_7_Query1 = new R6000_10_CANCEL_DB_SELECT_7_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_7_Query1.Execute(r6000_10_CANCEL_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FATC_DTREF, V0FATC_DTREF);
            }


        }

        [StopWatch]
        /*" R7000-00-QUITA-ATRASADA-DB-UPDATE-4 */
        public void R7000_00_QUITA_ATRASADA_DB_UPDATE_4()
        {
            /*" -3856- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = QTDPARATZ - 1 WHERE NRCERTIF = :V0HISC-NRCERTIF END-EXEC. */

            var r7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1 = new R7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1.Execute(r7000_00_QUITA_ATRASADA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-SECTION */
        private void R7500_00_QUITA_PROXIMA_SECTION()
        {
            /*" -3883- MOVE '27500' TO WNR-EXEC-SQL. */
            _.Move("27500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3895- PERFORM R7500_00_QUITA_PROXIMA_DB_INSERT_1 */

            R7500_00_QUITA_PROXIMA_DB_INSERT_1();

            /*" -3898- IF SQLCODE NOT EQUAL ZEROES AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -3899- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -3900- MOVE '27501' TO WNR-EXEC-SQL */
                _.Move("27501", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3902- MOVE 'ERRO NA INCLUSAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                /*" -3903- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -3905- END-IF. */
            }


            /*" -3907- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

            /*" -3908- MOVE V0PROP-DTPROXVEN TO WDATA-SISTEMA. */
            _.Move(V0PROP_DTPROXVEN, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -3910- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -3911- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -3912- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -3913- COMPUTE WDATA-SIS-ANO = WDATA-SIS-ANO + 1 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;

                /*" -3915- END-IF. */
            }


            /*" -3920- MOVE WDATA-SISTEMA TO V0PROP-DTPROXVEN. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0PROP_DTPROXVEN);

            /*" -3921- IF (V0OPCP-OPCAOPAG EQUAL '1' OR '2' OR '5' ) */

            if ((V0OPCP_OPCAOPAG.In("1", "2", "5")))
            {

                /*" -3922- ADD 1 TO CEDENTE-NUM-TITULO */
                CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.Value = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO + 1;

                /*" -3923- MOVE CEDENTE-NUM-TITULO TO WHOST-NRTIT */
                _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WHOST_NRTIT);

                /*" -3924- ELSE */
            }
            else
            {


                /*" -3926- ADD 1 TO WTITL-SEQUENCIA */
                FILLER_1.WTITL_SEQUENCIA.Value = FILLER_1.WTITL_SEQUENCIA + 1;

                /*" -3928- MOVE WTITL-SEQUENCIA TO DPARM01 */
                _.Move(FILLER_1.WTITL_SEQUENCIA, DPARM01X.DPARM01);

                /*" -3930- CALL 'PROTIT01' USING DPARM01X */
                _.Call("PROTIT01", DPARM01X);

                /*" -3931- IF DPARM01-RC NOT EQUAL +0 */

                if (DPARM01X.DPARM01_RC != +0)
                {

                    /*" -3932- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3933- MOVE '27502' TO WNR-EXEC-SQL */
                    _.Move("27502", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3935- MOVE 'ERRO NA CHAMADA DA SUBROTINA PROTIT01' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CHAMADA DA SUBROTINA PROTIT01", WS_MSG_RETORNO);

                    /*" -3936- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3938- END-IF */
                }


                /*" -3940- MOVE DPARM01-D1 TO WTITL-DIGITO */
                _.Move(DPARM01X.DPARM01_D1, FILLER_1.WTITL_DIGITO);

                /*" -3942- MOVE W-NUMR-TITULO TO V0BANC-NRTIT WHOST-NRTIT */
                _.Move(W_NUMR_TITULO, V0BANC_NRTIT, WHOST_NRTIT);

                /*" -3949- END-IF. */
            }


            /*" -3950- IF V0OPCP-OPCAOPAG EQUAL '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -3955- PERFORM R7500_00_QUITA_PROXIMA_DB_UPDATE_1 */

                R7500_00_QUITA_PROXIMA_DB_UPDATE_1();

                /*" -3958- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -3959- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3960- MOVE '27503' TO WNR-EXEC-SQL */
                    _.Move("27503", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3962- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                    /*" -3963- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3965- END-IF */
                }


                /*" -3972- PERFORM R7500_00_QUITA_PROXIMA_DB_UPDATE_2 */

                R7500_00_QUITA_PROXIMA_DB_UPDATE_2();

                /*" -3975- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3976- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -3977- MOVE '27504' TO WNR-EXEC-SQL */
                    _.Move("27504", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -3979- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -3980- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -3982- END-IF */
                }


                /*" -4001- PERFORM R7500_00_QUITA_PROXIMA_DB_INSERT_2 */

                R7500_00_QUITA_PROXIMA_DB_INSERT_2();

                /*" -4004- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -4005- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -4006- MOVE '27505' TO WNR-EXEC-SQL */
                    _.Move("27505", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4008- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -4009- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -4010- END-IF */
                }


                /*" -4012- END-IF. */
            }


            /*" -4013- IF WHOST-VLPREMIO LESS ZEROES */

            if (WHOST_VLPREMIO < 00)
            {

                /*" -4014- IF WHOST-PRMVG LESS ZEROES */

                if (WHOST_PRMVG < 00)
                {

                    /*" -4015- COMPUTE WHOST-PRMVG = WHOST-PRMVG * -1 */
                    WHOST_PRMVG.Value = WHOST_PRMVG * -1;

                    /*" -4017- END-IF */
                }


                /*" -4018- IF WHOST-PRMAP LESS ZEROES */

                if (WHOST_PRMAP < 00)
                {

                    /*" -4019- COMPUTE WHOST-PRMAP = WHOST-PRMAP * -1 */
                    WHOST_PRMAP.Value = WHOST_PRMAP * -1;

                    /*" -4021- END-IF */
                }


                /*" -4036- PERFORM R7500_00_QUITA_PROXIMA_DB_INSERT_3 */

                R7500_00_QUITA_PROXIMA_DB_INSERT_3();

                /*" -4039- IF SQLCODE NOT EQUAL ZEROES AND -803 */

                if (!DB.SQLCODE.In("00", "-803"))
                {

                    /*" -4040- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -4041- MOVE '27506' TO WNR-EXEC-SQL */
                    _.Move("27506", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4043- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                    /*" -4044- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -4045- END-IF */
                }


                /*" -4050- END-IF. */
            }


            /*" -4057- PERFORM R7500_00_QUITA_PROXIMA_DB_UPDATE_3 */

            R7500_00_QUITA_PROXIMA_DB_UPDATE_3();

            /*" -4060- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4061- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4062- MOVE '27507' TO WNR-EXEC-SQL */
                _.Move("27507", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4064- MOVE 'ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA ALTERACAO DA TABELA V0PROPOSTAVA", WS_MSG_RETORNO);

                /*" -4065- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4067- END-IF. */
            }


            /*" -4069- MOVE V0PROP-NRPARCEL TO V2DIFP-NRPARCEL. */
            _.Move(V0PROP_NRPARCEL, V2DIFP_NRPARCEL);

            /*" -4069- PERFORM R7700-00-VERIFICA-REPASSES. */

            R7700_00_VERIFICA_REPASSES_SECTION();

        }

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-DB-INSERT-1 */
        public void R7500_00_QUITA_PROXIMA_DB_INSERT_1()
        {
            /*" -3895- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :V0PROP-DTVENCTO, 0, 0, 0, :V0OPCP-OPCAOPAG, '1' , 0, CURRENT TIMESTAMP) END-EXEC. */

            var r7500_00_QUITA_PROXIMA_DB_INSERT_1_Insert1 = new R7500_00_QUITA_PROXIMA_DB_INSERT_1_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
            };

            R7500_00_QUITA_PROXIMA_DB_INSERT_1_Insert1.Execute(r7500_00_QUITA_PROXIMA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-DB-UPDATE-1 */
        public void R7500_00_QUITA_PROXIMA_DB_UPDATE_1()
        {
            /*" -3955- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC */

            var r7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1 = new R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1.Execute(r7500_00_QUITA_PROXIMA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-8 */
        public void R6000_10_CANCEL_DB_SELECT_8()
        {
            /*" -3514- EXEC SQL SELECT DATA_REFERENCIA INTO :V0FATC-DTREF FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND COD_SUBGRUPO = 0 WITH UR END-EXEC */

            var r6000_10_CANCEL_DB_SELECT_8_Query1 = new R6000_10_CANCEL_DB_SELECT_8_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_8_Query1.Execute(r6000_10_CANCEL_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0FATC_DTREF, V0FATC_DTREF);
            }


        }

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-DB-UPDATE-2 */
        public void R7500_00_QUITA_PROXIMA_DB_UPDATE_2()
        {
            /*" -3972- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '2' , NRTITCOMP = :WHOST-NRTIT WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL END-EXEC */

            var r7500_00_QUITA_PROXIMA_DB_UPDATE_2_Update1 = new R7500_00_QUITA_PROXIMA_DB_UPDATE_2_Update1()
            {
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R7500_00_QUITA_PROXIMA_DB_UPDATE_2_Update1.Execute(r7500_00_QUITA_PROXIMA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-DB-INSERT-2 */
        public void R7500_00_QUITA_PROXIMA_DB_INSERT_2()
        {
            /*" -4001- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:V0PROP-NRCERTIF, :V0PROP-NRPARCEL, :WHOST-NRTIT, :V0PROP-DTVENCTO, 0, :V0OPCP-OPCAOPAG, '1' , 115, 0, 0, 0, 0, 0, 0) END-EXEC */

            var r7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1 = new R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1()
            {
                V0PROP_NRCERTIF = V0PROP_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                WHOST_NRTIT = WHOST_NRTIT.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
            };

            R7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1.Execute(r7500_00_QUITA_PROXIMA_DB_INSERT_2_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7500_99_SAIDA*/

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-DB-INSERT-3 */
        public void R7500_00_QUITA_PROXIMA_DB_INSERT_3()
        {
            /*" -4036- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, 9999, :V0PROP-NRPARCEL, 601, :V0PROP-DTVENCTO, 0.00, 0.00, 0.00, 0.00, :WHOST-PRMVG, :WHOST-PRMAP, 0.00, ' ' ) END-EXEC */

            var r7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1 = new R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                WHOST_PRMVG = WHOST_PRMVG.ToString(),
                WHOST_PRMAP = WHOST_PRMAP.ToString(),
            };

            R7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1.Execute(r7500_00_QUITA_PROXIMA_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" R7500-00-QUITA-PROXIMA-DB-UPDATE-3 */
        public void R7500_00_QUITA_PROXIMA_DB_UPDATE_3()
        {
            /*" -4057- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET DTVENCTO = :V0PROP-DTVENCTO, DTPROXVEN = :V0PROP-DTPROXVEN, NRPARCE = :V0PROP-NRPARCEL, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HISC-NRCERTIF END-EXEC. */

            var r7500_00_QUITA_PROXIMA_DB_UPDATE_3_Update1 = new R7500_00_QUITA_PROXIMA_DB_UPDATE_3_Update1()
            {
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                V0PROP_DTVENCTO = V0PROP_DTVENCTO.ToString(),
                V0PROP_NRPARCEL = V0PROP_NRPARCEL.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            R7500_00_QUITA_PROXIMA_DB_UPDATE_3_Update1.Execute(r7500_00_QUITA_PROXIMA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-9 */
        public void R6000_10_CANCEL_DB_SELECT_9()
        {
            /*" -3553- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR = 93 AND MODALIFR >= 0 AND COD_COBERTURA = 11 WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_9_Query1 = new R6000_10_CANCEL_DB_SELECT_9_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_9_Query1.Execute(r6000_10_CANCEL_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, V0COBA_PRMVG);
            }


        }

        [StopWatch]
        /*" R7700-00-VERIFICA-REPASSES-SECTION */
        private void R7700_00_VERIFICA_REPASSES_SECTION()
        {
            /*" -4080- MOVE '27700' TO WNR-EXEC-SQL. */
            _.Move("27700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4087- PERFORM R7700_00_VERIFICA_REPASSES_DB_SELECT_1 */

            R7700_00_VERIFICA_REPASSES_DB_SELECT_1();

            /*" -4090- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4091- PERFORM R8000-00-REPASSA-CDG */

                R8000_00_REPASSA_CDG_SECTION();

                /*" -4093- END-IF. */
            }


            /*" -4100- PERFORM R7700_00_VERIFICA_REPASSES_DB_SELECT_2 */

            R7700_00_VERIFICA_REPASSES_DB_SELECT_2();

            /*" -4103- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4104- PERFORM R8100-00-REPASSA-SAF */

                R8100_00_REPASSA_SAF_SECTION();

                /*" -4104- END-IF. */
            }


        }

        [StopWatch]
        /*" R7700-00-VERIFICA-REPASSES-DB-SELECT-1 */
        public void R7700_00_VERIFICA_REPASSES_DB_SELECT_1()
        {
            /*" -4087- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var r7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1 = new R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1.Execute(r7700_00_VERIFICA_REPASSES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-10 */
        public void R6000_10_CANCEL_DB_SELECT_10()
        {
            /*" -3574- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81,82) AND MODALIFR >= 0 AND COD_COBERTURA = 1 WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_10_Query1 = new R6000_10_CANCEL_DB_SELECT_10_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_10_Query1.Execute(r6000_10_CANCEL_DB_SELECT_10_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }

        [StopWatch]
        /*" R7700-00-VERIFICA-REPASSES-DB-SELECT-2 */
        public void R7700_00_VERIFICA_REPASSES_DB_SELECT_2()
        {
            /*" -4100- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var r7700_00_VERIFICA_REPASSES_DB_SELECT_2_Query1 = new R7700_00_VERIFICA_REPASSES_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R7700_00_VERIFICA_REPASSES_DB_SELECT_2_Query1.Execute(r7700_00_VERIFICA_REPASSES_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7700_99_SAIDA*/

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-11 */
        public void R6000_10_CANCEL_DB_SELECT_11()
        {
            /*" -3593- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, 82) AND MODALIFR >= 0 AND COD_COBERTURA = 2 WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_11_Query1 = new R6000_10_CANCEL_DB_SELECT_11_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_11_Query1.Execute(r6000_10_CANCEL_DB_SELECT_11_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }

        [StopWatch]
        /*" R8000-00-REPASSA-CDG-SECTION */
        private void R8000_00_REPASSA_CDG_SECTION()
        {
            /*" -4119- MOVE '28000' TO WNR-EXEC-SQL. */
            _.Move("28000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4120- MOVE V0PARC-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -4121- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -4123- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -4124- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -4125- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -4126- ADD 1 TO WDATA-SIS-ANO. */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;
            }


            /*" -4128- MOVE WDATA-SISTEMA TO V0RCDG-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RCDG_DTREFER);

            /*" -4135- PERFORM R8000_00_REPASSA_CDG_DB_SELECT_1 */

            R8000_00_REPASSA_CDG_DB_SELECT_1();

            /*" -4138- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4139- GO TO R8000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;

                /*" -4141- END-IF. */
            }


            /*" -4151- PERFORM R8000_00_REPASSA_CDG_DB_INSERT_1 */

            R8000_00_REPASSA_CDG_DB_INSERT_1();

            /*" -4155- IF SQLCODE EQUAL 0 OR -803 NEXT SENTENCE */

            if (DB.SQLCODE.In("0", "-803"))
            {

                /*" -4156- ELSE */
            }
            else
            {


                /*" -4157- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4158- MOVE '28001' TO WNR-EXEC-SQL */
                _.Move("28001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4160- MOVE 'ERRO NA INCLUSAO DA TABELA V0REPASSECDG' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0REPASSECDG", WS_MSG_RETORNO);

                /*" -4161- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4161- END-IF. */
            }


        }

        [StopWatch]
        /*" R8000-00-REPASSA-CDG-DB-SELECT-1 */
        public void R8000_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -4135- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE NRCERTIF = :V0HISC-NRCERTIF AND DTREFER = :V0RCDG-DTREFER WITH UR END-EXEC. */

            var r8000_00_REPASSA_CDG_DB_SELECT_1_Query1 = new R8000_00_REPASSA_CDG_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
            };

            var executed_1 = R8000_00_REPASSA_CDG_DB_SELECT_1_Query1.Execute(r8000_00_REPASSA_CDG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCDG_SITUACAO, V0RCDG_SITUACAO);
            }


        }

        [StopWatch]
        /*" R8000-00-REPASSA-CDG-DB-INSERT-1 */
        public void R8000_00_REPASSA_CDG_DB_INSERT_1()
        {
            /*" -4151- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HISC-NRCERTIF, :V2DIFP-NRPARCEL, '0' , :V1SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

            var r8000_00_REPASSA_CDG_DB_INSERT_1_Insert1 = new R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RCDG_DTREFER = V0RCDG_DTREFER.ToString(),
                V0CDGC_VLCUSTCDG = V0CDGC_VLCUSTCDG.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V2DIFP_NRPARCEL = V2DIFP_NRPARCEL.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            R8000_00_REPASSA_CDG_DB_INSERT_1_Insert1.Execute(r8000_00_REPASSA_CDG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R6000-10-CANCEL-DB-SELECT-12 */
        public void R6000_10_CANCEL_DB_SELECT_12()
        {
            /*" -3611- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0PROP-NUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :V0SEGU-ITEM AND OCORHIST = :V0SEGU-OCORHIST AND RAMOFR IN (81, 82) AND MODALIFR >= 0 AND COD_COBERTURA = 5 WITH UR END-EXEC. */

            var r6000_10_CANCEL_DB_SELECT_12_Query1 = new R6000_10_CANCEL_DB_SELECT_12_Query1()
            {
                V0PROP_NUM_APOLICE = V0PROP_NUM_APOLICE.ToString(),
                V0SEGU_OCORHIST = V0SEGU_OCORHIST.ToString(),
                V0SEGU_ITEM = V0SEGU_ITEM.ToString(),
            };

            var executed_1 = R6000_10_CANCEL_DB_SELECT_12_Query1.Execute(r6000_10_CANCEL_DB_SELECT_12_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8100-00-REPASSA-SAF-SECTION */
        private void R8100_00_REPASSA_SAF_SECTION()
        {
            /*" -4175- MOVE '28100' TO WNR-EXEC-SQL. */
            _.Move("28100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4176- MOVE V0PARC-DTVENCTO TO WDATA-SISTEMA. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WDATA_SISTEMA);

            /*" -4177- MOVE 01 TO WDATA-SIS-DIA. */
            _.Move(01, AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_DIA);

            /*" -4179- ADD V0OPCP-PERIPGTO TO WDATA-SIS-MES. */
            AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES + V0OPCP_PERIPGTO;

            /*" -4180- IF WDATA-SIS-MES > 12 */

            if (AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES > 12)
            {

                /*" -4181- COMPUTE WDATA-SIS-MES = WDATA-SIS-MES - 12 */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_MES - 12;

                /*" -4182- ADD 1 TO WDATA-SIS-ANO */
                AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO.Value = AREA_DE_WORK.WDATA_SISTEMA.WDATA_SIS_ANO + 1;

                /*" -4184- END-IF. */
            }


            /*" -4186- MOVE WDATA-SISTEMA TO V0RSAF-DTREFER. */
            _.Move(AREA_DE_WORK.WDATA_SISTEMA, V0RSAF_DTREFER);

            /*" -4194- PERFORM R8100_00_REPASSA_SAF_DB_SELECT_1 */

            R8100_00_REPASSA_SAF_DB_SELECT_1();

            /*" -4197- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -4198- GO TO R8100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/ //GOTO
                return;

                /*" -4200- END-IF. */
            }


            /*" -4216- PERFORM R8100_00_REPASSA_SAF_DB_INSERT_1 */

            R8100_00_REPASSA_SAF_DB_INSERT_1();

            /*" -4220- IF SQLCODE EQUAL 0 OR -803 NEXT SENTENCE */

            if (DB.SQLCODE.In("0", "-803"))
            {

                /*" -4221- ELSE */
            }
            else
            {


                /*" -4222- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4223- MOVE '28101' TO WNR-EXEC-SQL */
                _.Move("28101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4225- MOVE 'ERRO NA INCLUSAO DA TABELA V0HISTREPSAF' TO WS-MSG-RETORNO */
                _.Move("ERRO NA INCLUSAO DA TABELA V0HISTREPSAF", WS_MSG_RETORNO);

                /*" -4226- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4226- END-IF. */
            }


        }

        [StopWatch]
        /*" R8100-00-REPASSA-SAF-DB-SELECT-1 */
        public void R8100_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -4194- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE NRCERTIF = :V0HISC-NRCERTIF AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 WITH UR END-EXEC. */

            var r8100_00_REPASSA_SAF_DB_SELECT_1_Query1 = new R8100_00_REPASSA_SAF_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
            };

            var executed_1 = R8100_00_REPASSA_SAF_DB_SELECT_1_Query1.Execute(r8100_00_REPASSA_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF_SITUACAO, V0RSAF_SITUACAO);
            }


        }

        [StopWatch]
        /*" R8100-00-REPASSA-SAF-DB-INSERT-1 */
        public void R8100_00_REPASSA_SAF_DB_INSERT_1()
        {
            /*" -4216- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HISC-NRCERTIF, :V2DIFP-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 1100, '0' , '0' , 0, 0, 'GE0853S' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

            var r8100_00_REPASSA_SAF_DB_INSERT_1_Insert1 = new R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0RSAF_DTREFER = V0RSAF_DTREFER.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V2DIFP_NRPARCEL = V2DIFP_NRPARCEL.ToString(),
                V0PROP_NRMATRFUN = V0PROP_NRMATRFUN.ToString(),
                V0SAFC_VLCUSTSAF = V0SAFC_VLCUSTSAF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            R8100_00_REPASSA_SAF_DB_INSERT_1_Insert1.Execute(r8100_00_REPASSA_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8100_99_SAIDA*/

        [StopWatch]
        /*" R8105-00-ACERTA-PARCELA-SECTION */
        private void R8105_00_ACERTA_PARCELA_SECTION()
        {
            /*" -4237- MOVE '28105' TO WNR-EXEC-SQL. */
            _.Move("28105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4244- PERFORM R8105_00_ACERTA_PARCELA_DB_SELECT_1 */

            R8105_00_ACERTA_PARCELA_DB_SELECT_1();

            /*" -4247- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4248- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4249- MOVE '28106' TO WNR-EXEC-SQL */
                _.Move("28106", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4251- MOVE 'ERRO NA CONSULTA DA TABELA V0HISTCONTAVA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V0HISTCONTAVA", WS_MSG_RETORNO);

                /*" -4252- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4254- END-IF. */
            }


            /*" -4255- IF WHOST-COUNT-DEB GREATER ZEROS */

            if (WHOST_COUNT_DEB > 00)
            {

                /*" -4256- MOVE 'N' TO WTEM-PULO */
                _.Move("N", AREA_DE_WORK.WTEM_PULO);

                /*" -4257- GO TO R8105-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8105_99_SAIDA*/ //GOTO
                return;

                /*" -4259- END-IF. */
            }


            /*" -4265- PERFORM R8105_00_ACERTA_PARCELA_DB_UPDATE_1 */

            R8105_00_ACERTA_PARCELA_DB_UPDATE_1();

            /*" -4268- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4269- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4270- MOVE 'N' TO WTEM-PULO */
                    _.Move("N", AREA_DE_WORK.WTEM_PULO);

                    /*" -4271- GO TO R8105-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8105_99_SAIDA*/ //GOTO
                    return;

                    /*" -4272- ELSE */
                }
                else
                {


                    /*" -4273- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -4274- MOVE '28107' TO WNR-EXEC-SQL */
                    _.Move("28107", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4276- MOVE 'ERRO NA ALTERACAO DA TABELA V0PARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0PARCELVA", WS_MSG_RETORNO);

                    /*" -4277- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -4278- END-IF */
                }


                /*" -4280- END-IF. */
            }


            /*" -4286- PERFORM R8105_00_ACERTA_PARCELA_DB_UPDATE_2 */

            R8105_00_ACERTA_PARCELA_DB_UPDATE_2();

            /*" -4289- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4290- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4291- MOVE 'N' TO WTEM-PULO */
                    _.Move("N", AREA_DE_WORK.WTEM_PULO);

                    /*" -4292- GO TO R8105-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R8105_99_SAIDA*/ //GOTO
                    return;

                    /*" -4293- ELSE */
                }
                else
                {


                    /*" -4294- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -4295- MOVE '28108' TO WNR-EXEC-SQL */
                    _.Move("28108", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4297- MOVE 'ERRO NA ALTERACAO DA TABELA V0HISTCOBVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA ALTERACAO DA TABELA V0HISTCOBVA", WS_MSG_RETORNO);

                    /*" -4298- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -4299- END-IF */
                }


                /*" -4301- END-IF. */
            }


            /*" -4301- MOVE 'S' TO WTEM-PULO. */
            _.Move("S", AREA_DE_WORK.WTEM_PULO);

        }

        [StopWatch]
        /*" R8105-00-ACERTA-PARCELA-DB-SELECT-1 */
        public void R8105_00_ACERTA_PARCELA_DB_SELECT_1()
        {
            /*" -4244- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-COUNT-DEB FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL WITH UR END-EXEC. */

            var r8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1 = new R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            var executed_1 = R8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1.Execute(r8105_00_ACERTA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT_DEB, WHOST_COUNT_DEB);
            }


        }

        [StopWatch]
        /*" R8105-00-ACERTA-PARCELA-DB-UPDATE-1 */
        public void R8105_00_ACERTA_PARCELA_DB_UPDATE_1()
        {
            /*" -4265- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND SITUACAO IN ( ' ' , '0' ) END-EXEC. */

            var r8105_00_ACERTA_PARCELA_DB_UPDATE_1_Update1 = new R8105_00_ACERTA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R8105_00_ACERTA_PARCELA_DB_UPDATE_1_Update1.Execute(r8105_00_ACERTA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8105_99_SAIDA*/

        [StopWatch]
        /*" R8105-00-ACERTA-PARCELA-DB-UPDATE-2 */
        public void R8105_00_ACERTA_PARCELA_DB_UPDATE_2()
        {
            /*" -4286- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :V0HISC-NRPARCEL AND SITUACAO IN ( ' ' , '0' , '5' ) END-EXEC. */

            var r8105_00_ACERTA_PARCELA_DB_UPDATE_2_Update1 = new R8105_00_ACERTA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
            };

            R8105_00_ACERTA_PARCELA_DB_UPDATE_2_Update1.Execute(r8105_00_ACERTA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R8110-00-ACERTA-OPCAOPAG-SECTION */
        private void R8110_00_ACERTA_OPCAOPAG_SECTION()
        {
            /*" -4315- MOVE '28110' TO WNR-EXEC-SQL. */
            _.Move("28110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4317- PERFORM R1051-00-CANCELA-PARCELA */

            R1051_00_CANCELA_PARCELA_SECTION();

            /*" -4320- COMPUTE DEVIDO-PRMVG = (GUARDA-PERC-VG * V0HISC-VLPRMTOT) / 100. */
            DEVIDO_PRMVG.Value = (GUARDA_PERC_VG * V0HISC_VLPRMTOT) / 100f;

            /*" -4322- COMPUTE DEVIDO-PRMAP = V0HISC-VLPRMTOT - DEVIDO-PRMVG. */
            DEVIDO_PRMAP.Value = V0HISC_VLPRMTOT - DEVIDO_PRMVG;

            /*" -4323- IF (DEVIDO-PRMVG < ZEROS) OR (DEVIDO-PRMAP < ZEROS) */

            if ((DEVIDO_PRMVG < 00) || (DEVIDO_PRMAP < 00))
            {

                /*" -4327- DISPLAY ' DEVIDOS NEGATIVOS ' V0HISC-NRCERTIF ' ' V0HISC-NRPARCEL ' ' V0HISC-VLPRMTOT ' ' GUARDA-PERC-VG */

                $" DEVIDOS NEGATIVOS {V0HISC_NRCERTIF} {V0HISC_NRPARCEL} {V0HISC_VLPRMTOT} {GUARDA_PERC_VG}"
                .Display();

                /*" -4328- GO TO R8110-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/ //GOTO
                return;

                /*" -4330- END-IF. */
            }


            /*" -4330- MOVE 430 TO V4DIFP-CODOPER. */
            _.Move(430, V4DIFP_CODOPER);

            /*" -0- FLUXCONTROL_PERFORM R8110_10_ACERTA_OPCAOPAG */

            R8110_10_ACERTA_OPCAOPAG();

        }

        [StopWatch]
        /*" R8110-10-ACERTA-OPCAOPAG */
        private void R8110_10_ACERTA_OPCAOPAG(bool isPerform = false)
        {
            /*" -4349- PERFORM R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1 */

            R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1();

            /*" -4352- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -4353- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -4354- COMPUTE V4DIFP-CODOPER = V4DIFP-CODOPER + 1 */
                    V4DIFP_CODOPER.Value = V4DIFP_CODOPER + 1;

                    /*" -4355- GO TO R8110-10-ACERTA-OPCAOPAG */
                    new Task(() => R8110_10_ACERTA_OPCAOPAG()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -4356- ELSE */
                }
                else
                {


                    /*" -4357- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -4358- MOVE '81101' TO WNR-EXEC-SQL */
                    _.Move("81101", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4360- MOVE 'ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA INCLUSAO DA TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                    /*" -4361- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -4362- END-IF */
                }


                /*" -4362- END-IF. */
            }


        }

        [StopWatch]
        /*" R8110-10-ACERTA-OPCAOPAG-DB-INSERT-1 */
        public void R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1()
        {
            /*" -4349- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, 9999, :V0HISC-NRPARCEL, :V4DIFP-CODOPER, :V0PARC-DTVENCTO, :DEVIDO-PRMVG, :DEVIDO-PRMAP, 0, 0, :DEVIDO-PRMVG, :DEVIDO-PRMAP, 0, ' ' ) END-EXEC. */

            var r8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1 = new R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                V0HISC_NRPARCEL = V0HISC_NRPARCEL.ToString(),
                V4DIFP_CODOPER = V4DIFP_CODOPER.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                DEVIDO_PRMVG = DEVIDO_PRMVG.ToString(),
                DEVIDO_PRMAP = DEVIDO_PRMAP.ToString(),
            };

            R8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1.Execute(r8110_10_ACERTA_OPCAOPAG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8110_99_SAIDA*/

        [StopWatch]
        /*" R8150-00-CONTA-PEND-CONTA-SECTION */
        private void R8150_00_CONTA_PEND_CONTA_SECTION()
        {
            /*" -4373- MOVE '28150' TO WNR-EXEC-SQL. */
            _.Move("28150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4375- PERFORM R8160-00-MAX-PARCELA */

            R8160_00_MAX_PARCELA_SECTION();

            /*" -4376- MOVE WS-NUM-PARCELA TO WHOST-NUM-PARCELA-F */
            _.Move(WS_NUM_PARCELA, WHOST_NUM_PARCELA_F);

            /*" -4378- COMPUTE WHOST-NUM-PARCELA-I = WS-NUM-PARCELA - 2 */
            WHOST_NUM_PARCELA_I.Value = WS_NUM_PARCELA - 2;

            /*" -4379- IF (WHOST-NUM-PARCELA-I < 1) */

            if ((WHOST_NUM_PARCELA_I < 1))
            {

                /*" -4380- MOVE 1 TO WHOST-NUM-PARCELA-I */
                _.Move(1, WHOST_NUM_PARCELA_I);

                /*" -4382- END-IF */
            }


            /*" -4392- PERFORM R8150_00_CONTA_PEND_CONTA_DB_SELECT_1 */

            R8150_00_CONTA_PEND_CONTA_DB_SELECT_1();

            /*" -4395- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -4396- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4397- MOVE '28151' TO WNR-EXEC-SQL */
                _.Move("28151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4399- MOVE 'ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL", WS_MSG_RETORNO);

                /*" -4400- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4402- END-IF. */
            }


            /*" -4403- MOVE WS-QT-PARCELAS TO V0PROP-QTDPARATZ. */
            _.Move(WS_QT_PARCELAS, V0PROP_QTDPARATZ);

        }

        [StopWatch]
        /*" R8150-00-CONTA-PEND-CONTA-DB-SELECT-1 */
        public void R8150_00_CONTA_PEND_CONTA_DB_SELECT_1()
        {
            /*" -4392- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-QT-PARCELAS FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF AND NUM_PARCELA BETWEEN :WHOST-NUM-PARCELA-I AND :WHOST-NUM-PARCELA-F AND DATA_VENCIMENTO <= :V1SIST-DTVENFIM-CN AND SIT_REGISTRO IN ( ' ' , '0' , X'00' ) WITH UR END-EXEC. */

            var r8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1 = new R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1()
            {
                WHOST_NUM_PARCELA_I = WHOST_NUM_PARCELA_I.ToString(),
                WHOST_NUM_PARCELA_F = WHOST_NUM_PARCELA_F.ToString(),
                V1SIST_DTVENFIM_CN = V1SIST_DTVENFIM_CN.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1.Execute(r8150_00_CONTA_PEND_CONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_PARCELAS, WS_QT_PARCELAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8150_99_SAIDA*/

        [StopWatch]
        /*" R8155-00-CONTA-PEND-BOLETO-SECTION */
        private void R8155_00_CONTA_PEND_BOLETO_SECTION()
        {
            /*" -4413- MOVE '28155' TO WNR-EXEC-SQL. */
            _.Move("28155", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4416- MOVE ZEROS TO WHOST-VL-PRM-TOTAL WHOST-VL-PRM-1PARC WHOST-VL-PRM-TOT-PAGO */
            _.Move(0, WHOST_VL_PRM_TOTAL, WHOST_VL_PRM_1PARC, WHOST_VL_PRM_TOT_PAGO);

            /*" -4417- MOVE ZEROS TO WHOST-VL-PRM-ATU. */
            _.Move(0, WHOST_VL_PRM_ATU);

            /*" -4418- MOVE ZEROS TO WS-QT-PARCELAS-ATZ */
            _.Move(0, WS_QT_PARCELAS_ATZ);

            /*" -4420- MOVE ZEROS TO WS-QT-PARCELAS-PAGA. */
            _.Move(0, WS_QT_PARCELAS_PAGA);

            /*" -4421- PERFORM R8160-00-MAX-PARCELA */

            R8160_00_MAX_PARCELA_SECTION();

            /*" -4423- MOVE WS-NUM-PARCELA TO WHOST-NUM-PARCELA-F */
            _.Move(WS_NUM_PARCELA, WHOST_NUM_PARCELA_F);

            /*" -4425- PERFORM R8161-00-SELECIONA-VL-PARC */

            R8161_00_SELECIONA_VL_PARC_SECTION();

            /*" -4427- IF (WHOST-SIT-REGISTRO NOT EQUAL '1' ) AND (WHOST-VL-PRM-TOTAL > ZEROS) */

            if ((WHOST_SIT_REGISTRO != "1") && (WHOST_VL_PRM_TOTAL > 00))
            {

                /*" -4428- MOVE WHOST-VL-PRM-TOTAL TO WHOST-VL-PRM-ATU */
                _.Move(WHOST_VL_PRM_TOTAL, WHOST_VL_PRM_ATU);

                /*" -4430- MOVE ZEROS TO WS-QT-PARCELAS */
                _.Move(0, WS_QT_PARCELAS);

                /*" -4433- PERFORM R8162-00-CALCULA-QT-PARC-BOL UNTIL WHOST-VL-PRM-ATU <= ZEROS */

                while (!(WHOST_VL_PRM_ATU <= 00))
                {

                    R8162_00_CALCULA_QT_PARC_BOL_SECTION();
                }

                /*" -4435- MOVE WS-QT-PARCELAS TO WS-QT-PARCELAS-ATZ */
                _.Move(WS_QT_PARCELAS, WS_QT_PARCELAS_ATZ);

                /*" -4436- IF (WS-QT-PARCELAS-ATZ > 1) */

                if ((WS_QT_PARCELAS_ATZ > 1))
                {

                    /*" -4437- MOVE WS-NUM-PARCELA TO WS-NUM-PARCELA-ATRD */
                    _.Move(WS_NUM_PARCELA, WS_NUM_PARCELA_ATRD);

                    /*" -4438- IF (WS-QT-PARCELAS-ATZ > 2) */

                    if ((WS_QT_PARCELAS_ATZ > 2))
                    {

                        /*" -4439- PERFORM R8163-00-CALCULA-QT-PARC-ATRD 2 TIMES */

                        for (int i = 0; i < 2; i++)
                        {

                            R8163_00_CALCULA_QT_PARC_ATRD_SECTION();

                        }

                        /*" -4440- ELSE */
                    }
                    else
                    {


                        /*" -4441- PERFORM R8163-00-CALCULA-QT-PARC-ATRD */

                        R8163_00_CALCULA_QT_PARC_ATRD_SECTION();

                        /*" -4442- END-IF */
                    }


                    /*" -4443- END-IF */
                }


                /*" -4445- END-IF. */
            }


            /*" -4447- COMPUTE V0PROP-QTDPARATZ = WS-QT-PARCELAS-ATZ - WS-QT-PARCELAS-PAGA. */
            V0PROP_QTDPARATZ.Value = WS_QT_PARCELAS_ATZ - WS_QT_PARCELAS_PAGA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8155_99_SAIDA*/

        [StopWatch]
        /*" R8160-00-MAX-PARCELA-SECTION */
        private void R8160_00_MAX_PARCELA_SECTION()
        {
            /*" -4457- MOVE '28160' TO WNR-EXEC-SQL. */
            _.Move("28160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4463- PERFORM R8160_00_MAX_PARCELA_DB_SELECT_1 */

            R8160_00_MAX_PARCELA_DB_SELECT_1();

            /*" -4466- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -4467- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4468- MOVE '28161' TO WNR-EXEC-SQL */
                _.Move("28161", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4470- MOVE 'ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL", WS_MSG_RETORNO);

                /*" -4471- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4473- END-IF. */
            }


            /*" -4474- MOVE WS-NUM-PARCELA TO V0PROP-NRPARCEL. */
            _.Move(WS_NUM_PARCELA, V0PROP_NRPARCEL);

        }

        [StopWatch]
        /*" R8160-00-MAX-PARCELA-DB-SELECT-1 */
        public void R8160_00_MAX_PARCELA_DB_SELECT_1()
        {
            /*" -4463- EXEC SQL SELECT VALUE(MAX(NUM_PARCELA),0) INTO :WS-NUM-PARCELA FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF WITH UR END-EXEC. */

            var r8160_00_MAX_PARCELA_DB_SELECT_1_Query1 = new R8160_00_MAX_PARCELA_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R8160_00_MAX_PARCELA_DB_SELECT_1_Query1.Execute(r8160_00_MAX_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PARCELA, WS_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8160_99_SAIDA*/

        [StopWatch]
        /*" R8161-00-SELECIONA-VL-PARC-SECTION */
        private void R8161_00_SELECIONA_VL_PARC_SECTION()
        {
            /*" -4485- MOVE '28162' TO WNR-EXEC-SQL. */
            _.Move("28162", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4486- MOVE ZEROS TO WHOST-VL-PRM-TOTAL */
            _.Move(0, WHOST_VL_PRM_TOTAL);

            /*" -4487- MOVE '1900-01-01' TO WHOST-DT-VENC-PARC */
            _.Move("1900-01-01", WHOST_DT_VENC_PARC);

            /*" -4489- MOVE ' ' TO WHOST-SIT-REGISTRO */
            _.Move(" ", WHOST_SIT_REGISTRO);

            /*" -4500- PERFORM R8161_00_SELECIONA_VL_PARC_DB_SELECT_1 */

            R8161_00_SELECIONA_VL_PARC_DB_SELECT_1();

            /*" -4503- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -4504- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4505- MOVE '28163' TO WNR-EXEC-SQL */
                _.Move("28163", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4507- MOVE 'ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL", WS_MSG_RETORNO);

                /*" -4508- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4509- END-IF. */
            }


        }

        [StopWatch]
        /*" R8161-00-SELECIONA-VL-PARC-DB-SELECT-1 */
        public void R8161_00_SELECIONA_VL_PARC_DB_SELECT_1()
        {
            /*" -4500- EXEC SQL SELECT DATA_VENCIMENTO, PRM_TOTAL, SIT_REGISTRO INTO :WHOST-DT-VENC-PARC, :WHOST-VL-PRM-TOTAL, :WHOST-SIT-REGISTRO FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF AND NUM_PARCELA = :WHOST-NUM-PARCELA-F WITH UR END-EXEC. */

            var r8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1 = new R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1()
            {
                WHOST_NUM_PARCELA_F = WHOST_NUM_PARCELA_F.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1.Execute(r8161_00_SELECIONA_VL_PARC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DT_VENC_PARC, WHOST_DT_VENC_PARC);
                _.Move(executed_1.WHOST_VL_PRM_TOTAL, WHOST_VL_PRM_TOTAL);
                _.Move(executed_1.WHOST_SIT_REGISTRO, WHOST_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8161_99_SAIDA*/

        [StopWatch]
        /*" R8162-00-CALCULA-QT-PARC-BOL-SECTION */
        private void R8162_00_CALCULA_QT_PARC_BOL_SECTION()
        {
            /*" -4520- MOVE '28164' TO WNR-EXEC-SQL. */
            _.Move("28164", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4521- IF (WHOST-VL-PRM-ATU > ZEROS) */

            if ((WHOST_VL_PRM_ATU > 00))
            {

                /*" -4522- ADD 1 TO WS-QT-PARCELAS */
                WS_QT_PARCELAS.Value = WS_QT_PARCELAS + 1;

                /*" -4523- ELSE */
            }
            else
            {


                /*" -4524- MOVE ZEROS TO WHOST-VL-PRM-ATU */
                _.Move(0, WHOST_VL_PRM_ATU);

                /*" -4525- GO TO R8162-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8162_99_SAIDA*/ //GOTO
                return;

                /*" -4527- END-IF */
            }


            /*" -4528- IF (WS-QT-PARCELAS > 3) */

            if ((WS_QT_PARCELAS > 3))
            {

                /*" -4529- MOVE ZEROS TO WHOST-VL-PRM-ATU */
                _.Move(0, WHOST_VL_PRM_ATU);

                /*" -4530- GO TO R8162-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8162_99_SAIDA*/ //GOTO
                return;

                /*" -4532- END-IF */
            }


            /*" -4540- PERFORM R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1 */

            R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1();

            /*" -4543- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4544- DISPLAY 'R8165-00CALCULA-VL-3PARC .....' */
                _.Display($"R8165-00CALCULA-VL-3PARC .....");

                /*" -4545- DISPLAY 'NRCERTIF.....  ' V0HISC-NRCERTIF */
                _.Display($"NRCERTIF.....  {V0HISC_NRCERTIF}");

                /*" -4546- DISPLAY 'DATA_VIGEN...  ' WHOST-DT-VENC-PARC */
                _.Display($"DATA_VIGEN...  {WHOST_DT_VENC_PARC}");

                /*" -4547- DISPLAY 'SQLCODE......  ' SQLCODE */
                _.Display($"SQLCODE......  {DB.SQLCODE}");

                /*" -4548- MOVE ZEROS TO WHOST-VL-PRM-ATU */
                _.Move(0, WHOST_VL_PRM_ATU);

                /*" -4549- GO TO R8162-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8162_99_SAIDA*/ //GOTO
                return;

                /*" -4551- END-IF. */
            }


            /*" -4552- IF (WHOST-VL-PRM-1PARC NOT > ZEROS) */

            if ((WHOST_VL_PRM_1PARC <= 00))
            {

                /*" -4553- DISPLAY 'ERRO-R8165-00CALCULA-VL-3PARC .....' */
                _.Display($"ERRO-R8165-00CALCULA-VL-3PARC .....");

                /*" -4554- DISPLAY 'NRCERTIF....... ' V0HISC-NRCERTIF */
                _.Display($"NRCERTIF....... {V0HISC_NRCERTIF}");

                /*" -4555- DISPLAY 'DT-VENC-PARC... ' WHOST-DT-VENC-PARC */
                _.Display($"DT-VENC-PARC... {WHOST_DT_VENC_PARC}");

                /*" -4556- DISPLAY 'SQLCODE........ ' SQLCODE */
                _.Display($"SQLCODE........ {DB.SQLCODE}");

                /*" -4557- DISPLAY 'VL-PRM-1PARC... ' WHOST-VL-PRM-1PARC */
                _.Display($"VL-PRM-1PARC... {WHOST_VL_PRM_1PARC}");

                /*" -4558- MOVE ZEROS TO WHOST-VL-PRM-ATU */
                _.Move(0, WHOST_VL_PRM_ATU);

                /*" -4559- GO TO R8162-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8162_99_SAIDA*/ //GOTO
                return;

                /*" -4561- END-IF. */
            }


            /*" -4564- COMPUTE WHOST-VL-PRM-ATU = WHOST-VL-PRM-ATU - WHOST-VL-PRM-1PARC */
            WHOST_VL_PRM_ATU.Value = WHOST_VL_PRM_ATU - WHOST_VL_PRM_1PARC;

            /*" -4570- PERFORM R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2 */

            R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2();

            /*" -4573- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4575- DISPLAY 'ERRO NA CONSULTA DA TABELA V1SISTEMA ' WHOST-DT-VENC-PARC */
                _.Display($"ERRO NA CONSULTA DA TABELA V1SISTEMA {WHOST_DT_VENC_PARC}");

                /*" -4576- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4577- MOVE '28165' TO WNR-EXEC-SQL */
                _.Move("28165", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4579- MOVE 'ERRO NA CONSULTA DA TABELA V1SISTEMA' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA V1SISTEMA", WS_MSG_RETORNO);

                /*" -4580- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4581- END-IF. */
            }


        }

        [StopWatch]
        /*" R8162-00-CALCULA-QT-PARC-BOL-DB-SELECT-1 */
        public void R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1()
        {
            /*" -4540- EXEC SQL SELECT VALUE(MAX(VLPREMIO), 0) INTO :WHOST-VL-PRM-1PARC FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF AND DATA_INIVIGENCIA <= :WHOST-DT-VENC-PARC AND DATA_TERVIGENCIA >= :WHOST-DT-VENC-PARC WITH UR END-EXEC. */

            var r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1 = new R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1()
            {
                WHOST_DT_VENC_PARC = WHOST_DT_VENC_PARC.ToString(),
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1.Execute(r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_VL_PRM_1PARC, WHOST_VL_PRM_1PARC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8162_99_SAIDA*/

        [StopWatch]
        /*" R8162-00-CALCULA-QT-PARC-BOL-DB-SELECT-2 */
        public void R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2()
        {
            /*" -4570- EXEC SQL SELECT DATE(:WHOST-DT-VENC-PARC) - 1 MONTH INTO :WHOST-DT-VENC-PARC FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC */

            var r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1 = new R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1()
            {
                WHOST_DT_VENC_PARC = WHOST_DT_VENC_PARC.ToString(),
            };

            var executed_1 = R8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1.Execute(r8162_00_CALCULA_QT_PARC_BOL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DT_VENC_PARC, WHOST_DT_VENC_PARC);
            }


        }

        [StopWatch]
        /*" R8163-00-CALCULA-QT-PARC-ATRD-SECTION */
        private void R8163_00_CALCULA_QT_PARC_ATRD_SECTION()
        {
            /*" -4591- MOVE '28166' TO WNR-EXEC-SQL. */
            _.Move("28166", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4593- COMPUTE WHOST-NUM-PARCELA-F = WS-NUM-PARCELA-ATRD - 1 */
            WHOST_NUM_PARCELA_F.Value = WS_NUM_PARCELA_ATRD - 1;

            /*" -4595- PERFORM R8161-00-SELECIONA-VL-PARC */

            R8161_00_SELECIONA_VL_PARC_SECTION();

            /*" -4597- IF (WHOST-SIT-REGISTRO EQUAL '1' ) AND (WHOST-VL-PRM-TOTAL > ZEROS) */

            if ((WHOST_SIT_REGISTRO == "1") && (WHOST_VL_PRM_TOTAL > 00))
            {

                /*" -4598- MOVE WHOST-VL-PRM-TOTAL TO WHOST-VL-PRM-ATU */
                _.Move(WHOST_VL_PRM_TOTAL, WHOST_VL_PRM_ATU);

                /*" -4600- MOVE ZEROS TO WS-QT-PARCELAS */
                _.Move(0, WS_QT_PARCELAS);

                /*" -4603- PERFORM R8162-00-CALCULA-QT-PARC-BOL UNTIL WHOST-VL-PRM-ATU <= ZEROS */

                while (!(WHOST_VL_PRM_ATU <= 00))
                {

                    R8162_00_CALCULA_QT_PARC_BOL_SECTION();
                }

                /*" -4605- COMPUTE WS-QT-PARCELAS-PAGA = WS-QT-PARCELAS-PAGA + WS-QT-PARCELAS */
                WS_QT_PARCELAS_PAGA.Value = WS_QT_PARCELAS_PAGA + WS_QT_PARCELAS;

                /*" -4607- MOVE WHOST-VL-PRM-TOTAL TO WHOST-VL-PRM-TOT-PAGO */
                _.Move(WHOST_VL_PRM_TOTAL, WHOST_VL_PRM_TOT_PAGO);

                /*" -4608- IF (WHOST-VL-PRM-TOT-PAGO > ZEROS) */

                if ((WHOST_VL_PRM_TOT_PAGO > 00))
                {

                    /*" -4610- COMPUTE DESCON-PRMVG = (WHOST-VL-PRM-TOT-PAGO * GUARDA-PERC-VG) / 100 */
                    DESCON_PRMVG.Value = (WHOST_VL_PRM_TOT_PAGO * GUARDA_PERC_VG) / 100f;

                    /*" -4613- COMPUTE DESCON-PRMAP = WHOST-VL-PRM-TOT-PAGO - DESCON-PRMVG */
                    DESCON_PRMAP.Value = WHOST_VL_PRM_TOT_PAGO - DESCON_PRMVG;

                    /*" -4628- PERFORM R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1 */

                    R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1();

                    /*" -4631- IF (SQLCODE NOT EQUAL ZEROES) */

                    if ((DB.SQLCODE != 00))
                    {

                        /*" -4632- IF (SQLCODE EQUAL -803) */

                        if ((DB.SQLCODE == -803))
                        {

                            /*" -4635- DISPLAY 'R8155-ERRO-803-INSERT DIFPARCELVA' ' CERTIF. : ' V0HISC-NRCERTIF ' PARCELA : ' WS-NUM-PARCELA */

                            $"R8155-ERRO-803-INSERT DIFPARCELVA CERTIF. : {V0HISC_NRCERTIF} PARCELA : {WS_NUM_PARCELA}"
                            .Display();

                            /*" -4636- ELSE */
                        }
                        else
                        {


                            /*" -4637- MOVE 'F' TO LK-GE853-COD-RETORNO */
                            _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                            /*" -4638- MOVE '28167' TO WNR-EXEC-SQL */
                            _.Move("28167", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                            /*" -4640- MOVE 'ERRO NA INCLUSAO TABELA V0DIFPARCELVA' TO WS-MSG-RETORNO */
                            _.Move("ERRO NA INCLUSAO TABELA V0DIFPARCELVA", WS_MSG_RETORNO);

                            /*" -4641- GO TO R9999-00-FINALIZA-ROT */

                            R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                            return;

                            /*" -4642- END-IF */
                        }


                        /*" -4643- END-IF */
                    }


                    /*" -4644- END-IF */
                }


                /*" -4646- END-IF. */
            }


            /*" -4647- MOVE WHOST-NUM-PARCELA-F TO WS-NUM-PARCELA-ATRD. */
            _.Move(WHOST_NUM_PARCELA_F, WS_NUM_PARCELA_ATRD);

        }

        [StopWatch]
        /*" R8163-00-CALCULA-QT-PARC-ATRD-DB-INSERT-1 */
        public void R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1()
        {
            /*" -4628- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HISC-NRCERTIF, :WS-NUM-PARCELA-ATRD, :WHOST-NUM-PARCELA-F, 682, :V0PROP-DTPROXVEN, 0.00, 0.00, 0.00, 0.00, :DESCON-PRMVG, :DESCON-PRMAP, 0.00, ' ' ) END-EXEC */

            var r8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1 = new R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                WS_NUM_PARCELA_ATRD = WS_NUM_PARCELA_ATRD.ToString(),
                WHOST_NUM_PARCELA_F = WHOST_NUM_PARCELA_F.ToString(),
                V0PROP_DTPROXVEN = V0PROP_DTPROXVEN.ToString(),
                DESCON_PRMVG = DESCON_PRMVG.ToString(),
                DESCON_PRMAP = DESCON_PRMAP.ToString(),
            };

            R8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1.Execute(r8163_00_CALCULA_QT_PARC_ATRD_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8163_99_SAIDA*/

        [StopWatch]
        /*" R8164-00-MIN-PARCELA-PEND-SECTION */
        private void R8164_00_MIN_PARCELA_PEND_SECTION()
        {
            /*" -4657- MOVE '28164' TO WNR-EXEC-SQL */
            _.Move("28164", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4664- PERFORM R8164_00_MIN_PARCELA_PEND_DB_SELECT_1 */

            R8164_00_MIN_PARCELA_PEND_DB_SELECT_1();

            /*" -4667- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -4668- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4669- MOVE '28164' TO WNR-EXEC-SQL */
                _.Move("28164", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4671- MOVE 'ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA COBER_HIST_VIDAZUL", WS_MSG_RETORNO);

                /*" -4672- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4674- END-IF */
            }


            /*" -4674- . */

        }

        [StopWatch]
        /*" R8164-00-MIN-PARCELA-PEND-DB-SELECT-1 */
        public void R8164_00_MIN_PARCELA_PEND_DB_SELECT_1()
        {
            /*" -4664- EXEC SQL SELECT VALUE(MIN(NUM_PARCELA),0) INTO :WS-NUM-PARCELA-PEND FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :V0HISC-NRCERTIF AND SIT_REGISTRO IN ( ' ' , '0' , X'00' ) WITH UR END-EXEC */

            var r8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1 = new R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
            };

            var executed_1 = R8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1.Execute(r8164_00_MIN_PARCELA_PEND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_PARCELA_PEND, WS_NUM_PARCELA_PEND);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8164_99_SAIDA*/

        [StopWatch]
        /*" R8170-00-CONTA-PEND-CCRED-SECTION */
        private void R8170_00_CONTA_PEND_CCRED_SECTION()
        {
            /*" -4685- MOVE '28170' TO WNR-EXEC-SQL */
            _.Move("28170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4686- MOVE ZEROS TO WS-QT-PARCELAS */
            _.Move(0, WS_QT_PARCELAS);

            /*" -4687- MOVE 'N' TO WFIM-CPARCAT */
            _.Move("N", AREA_DE_WORK.WFIM_CPARCAT);

            /*" -4689- PERFORM R8160-00-MAX-PARCELA */

            R8160_00_MAX_PARCELA_SECTION();

            /*" -4691- MOVE WS-NUM-PARCELA TO WHOST-NUM-PARCELA-F */
            _.Move(WS_NUM_PARCELA, WHOST_NUM_PARCELA_F);

            /*" -4694- PERFORM R8164-00-MIN-PARCELA-PEND */

            R8164_00_MIN_PARCELA_PEND_SECTION();

            /*" -4700- MOVE WS-NUM-PARCELA-PEND TO WHOST-NUM-PARCELA-I */
            _.Move(WS_NUM_PARCELA_PEND, WHOST_NUM_PARCELA_I);

            /*" -4712- PERFORM R8170_00_CONTA_PEND_CCRED_DB_DECLARE_1 */

            R8170_00_CONTA_PEND_CCRED_DB_DECLARE_1();

            /*" -4714- PERFORM R8170_00_CONTA_PEND_CCRED_DB_OPEN_1 */

            R8170_00_CONTA_PEND_CCRED_DB_OPEN_1();

            /*" -4717- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4718- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4719- MOVE '28171' TO WNR-EXEC-SQL */
                _.Move("28171", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4721- MOVE 'ERRO NA CONSULTA DO CURSOR CPARCAT' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DO CURSOR CPARCAT", WS_MSG_RETORNO);

                /*" -4722- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4724- END-IF. */
            }


            /*" -4726- PERFORM R8171-00-FETCH-CPARCAT. */

            R8171_00_FETCH_CPARCAT_SECTION();

            /*" -4729- PERFORM R8175-00-CONTAR-PARC-AT UNTIL WFIM-CPARCAT EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_CPARCAT == "S"))
            {

                R8175_00_CONTAR_PARC_AT_SECTION();
            }

            /*" -4730- MOVE WS-QT-PARCELAS TO V0PROP-QTDPARATZ. */
            _.Move(WS_QT_PARCELAS, V0PROP_QTDPARATZ);

        }

        [StopWatch]
        /*" R8170-00-CONTA-PEND-CCRED-DB-OPEN-1 */
        public void R8170_00_CONTA_PEND_CCRED_DB_OPEN_1()
        {
            /*" -4714- EXEC SQL OPEN CPARCAT END-EXEC. */

            CPARCAT.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8170_99_SAIDA*/

        [StopWatch]
        /*" R8171-00-FETCH-CPARCAT-SECTION */
        private void R8171_00_FETCH_CPARCAT_SECTION()
        {
            /*" -4740- MOVE '28172' TO WNR-EXEC-SQL. */
            _.Move("28172", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4743- PERFORM R8171_00_FETCH_CPARCAT_DB_FETCH_1 */

            R8171_00_FETCH_CPARCAT_DB_FETCH_1();

            /*" -4746- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -4747- IF (SQLCODE EQUAL 100) */

                if ((DB.SQLCODE == 100))
                {

                    /*" -4747- PERFORM R8171_00_FETCH_CPARCAT_DB_CLOSE_1 */

                    R8171_00_FETCH_CPARCAT_DB_CLOSE_1();

                    /*" -4749- MOVE 'S' TO WFIM-CPARCAT */
                    _.Move("S", AREA_DE_WORK.WFIM_CPARCAT);

                    /*" -4750- ELSE */
                }
                else
                {


                    /*" -4751- MOVE 'F' TO LK-GE853-COD-RETORNO */
                    _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                    /*" -4752- MOVE '28173' TO WNR-EXEC-SQL */
                    _.Move("28173", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -4754- MOVE 'ERRO NA CONSULTA DO CURSOR CPARCAT ' TO WS-MSG-RETORNO */
                    _.Move("ERRO NA CONSULTA DO CURSOR CPARCAT ", WS_MSG_RETORNO);

                    /*" -4755- GO TO R9999-00-FINALIZA-ROT */

                    R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                    return;

                    /*" -4756- END-IF */
                }


                /*" -4756- END-IF. */
            }


        }

        [StopWatch]
        /*" R8171-00-FETCH-CPARCAT-DB-FETCH-1 */
        public void R8171_00_FETCH_CPARCAT_DB_FETCH_1()
        {
            /*" -4743- EXEC SQL FETCH CPARCAT INTO :WS-NUM-PARC-AT, :WS-NUM-TITULO-AT END-EXEC. */

            if (CPARCAT.Fetch())
            {
                _.Move(CPARCAT.WS_NUM_PARC_AT, WS_NUM_PARC_AT);
                _.Move(CPARCAT.WS_NUM_TITULO_AT, WS_NUM_TITULO_AT);
            }

        }

        [StopWatch]
        /*" R8171-00-FETCH-CPARCAT-DB-CLOSE-1 */
        public void R8171_00_FETCH_CPARCAT_DB_CLOSE_1()
        {
            /*" -4747- EXEC SQL CLOSE CPARCAT END-EXEC */

            CPARCAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8171_99_SAIDA*/

        [StopWatch]
        /*" R8175-00-CONTAR-PARC-AT-SECTION */
        private void R8175_00_CONTAR_PARC_AT_SECTION()
        {
            /*" -4767- MOVE '28175' TO WNR-EXEC-SQL. */
            _.Move("28175", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4782- PERFORM R8175_00_CONTAR_PARC_AT_DB_SELECT_1 */

            R8175_00_CONTAR_PARC_AT_DB_SELECT_1();

            /*" -4785-  EVALUATE SQLCODE  */

            /*" -4786-  WHEN ZEROS  */

            /*" -4786- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -4787- IF (V0HCTA-SITUACAO EQUAL ' ' OR '2' ) */

                if ((V0HCTA_SITUACAO.In(" ", "2")))
                {

                    /*" -4788- ADD 1 TO WS-QT-PARCELAS */
                    WS_QT_PARCELAS.Value = WS_QT_PARCELAS + 1;

                    /*" -4789- ELSE */
                }
                else
                {


                    /*" -4797- PERFORM R8175_00_CONTAR_PARC_AT_DB_SELECT_2 */

                    R8175_00_CONTAR_PARC_AT_DB_SELECT_2();

                    /*" -4800- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

                    if ((!DB.SQLCODE.In("00", "+100")))
                    {

                        /*" -4801- MOVE 'F' TO LK-GE853-COD-RETORNO */
                        _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                        /*" -4802- MOVE '28176' TO WNR-EXEC-SQL */
                        _.Move("28176", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                        /*" -4804- MOVE 'ERRO NA CONSULTA DA TABELA MOVDEBCC_CEF' TO WS-MSG-RETORNO */
                        _.Move("ERRO NA CONSULTA DA TABELA MOVDEBCC_CEF", WS_MSG_RETORNO);

                        /*" -4805- GO TO R9999-00-FINALIZA-ROT */

                        R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                        return;

                        /*" -4807- END-IF */
                    }


                    /*" -4808- IF (MOVDEBCE-DTCREDITO EQUAL '0001-01-01' ) */

                    if ((MOVDEBCE_DTCREDITO == "0001-01-01"))
                    {

                        /*" -4809- ADD 1 TO WS-QT-PARCELAS */
                        WS_QT_PARCELAS.Value = WS_QT_PARCELAS + 1;

                        /*" -4810- END-IF */
                    }


                    /*" -4811- END-IF */
                }


                /*" -4812-  WHEN +100  */

                /*" -4812- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -4813- CONTINUE */

                /*" -4814-  WHEN OTHER  */

                /*" -4814- ELSE */
            }
            else
            {


                /*" -4815- MOVE 'F' TO LK-GE853-COD-RETORNO */
                _.Move("F", REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO);

                /*" -4816- MOVE '28177' TO WNR-EXEC-SQL */
                _.Move("28177", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -4818- MOVE 'ERRO NA CONSULTA DA TABELA MOVDEBCC_CEF ' TO WS-MSG-RETORNO */
                _.Move("ERRO NA CONSULTA DA TABELA MOVDEBCC_CEF ", WS_MSG_RETORNO);

                /*" -4819- GO TO R9999-00-FINALIZA-ROT */

                R9999_00_FINALIZA_ROT_SECTION(); //GOTO
                return;

                /*" -4821-  END-EVALUATE.  */

                /*" -4821- END-IF. */
            }


            /*" -4822- PERFORM R8171-00-FETCH-CPARCAT. */

            R8171_00_FETCH_CPARCAT_SECTION();

        }

        [StopWatch]
        /*" R8175-00-CONTAR-PARC-AT-DB-SELECT-1 */
        public void R8175_00_CONTAR_PARC_AT_DB_SELECT_1()
        {
            /*" -4782- EXEC SQL SELECT VALUE(NSAS, 0) , VALUE(NSL, 0) , SITUACAO INTO :V0HCTA-NSAS , :V0HCTA-NSL , :V0HCTA-SITUACAO FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HISC-NRCERTIF AND NRPARCEL = :WS-NUM-PARC-AT AND SITUACAO IN ( '3' , ' ' , '2' ) AND TIPLANC = '1' ORDER BY SITUACAO DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var r8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1 = new R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1()
            {
                V0HISC_NRCERTIF = V0HISC_NRCERTIF.ToString(),
                WS_NUM_PARC_AT = WS_NUM_PARC_AT.ToString(),
            };

            var executed_1 = R8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1.Execute(r8175_00_CONTAR_PARC_AT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(executed_1.V0HCTA_NSL, V0HCTA_NSL);
                _.Move(executed_1.V0HCTA_SITUACAO, V0HCTA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8175_99_SAIDA*/

        [StopWatch]
        /*" R8175-00-CONTAR-PARC-AT-DB-SELECT-2 */
        public void R8175_00_CONTAR_PARC_AT_DB_SELECT_2()
        {
            /*" -4797- EXEC SQL SELECT VALUE(DTCREDITO, '0001-01-01' ) INTO :MOVDEBCE-DTCREDITO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :WS-NUM-TITULO-AT AND NUM_PARCELA = :WS-NUM-PARC-AT AND NUM_REQUISICAO = :V0HCTA-NSL WITH UR END-EXEC */

            var r8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1 = new R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1()
            {
                WS_NUM_TITULO_AT = WS_NUM_TITULO_AT.ToString(),
                WS_NUM_PARC_AT = WS_NUM_PARC_AT.ToString(),
                V0HCTA_NSL = V0HCTA_NSL.ToString(),
            };

            var executed_1 = R8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1.Execute(r8175_00_CONTAR_PARC_AT_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_DTCREDITO, MOVDEBCE_DTCREDITO);
            }


        }

        [StopWatch]
        /*" R9999-00-FINALIZA-ROT-SECTION */
        private void R9999_00_FINALIZA_ROT_SECTION()
        {
            /*" -4832- MOVE SQLCODE TO LK-GE853-SQLCODE */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_SQLCODE);

            /*" -4833- MOVE WS-MSG-RETORNO TO LK-GE853-MSG-RETORNO */
            _.Move(WS_MSG_RETORNO, REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_MSG_RETORNO);

            /*" -4835- MOVE WNR-EXEC-SQL TO LK-GE853-COD-REJEICAO */
            _.Move(AREA_DE_WORK.WABEND.WNR_EXEC_SQL, REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_REJEICAO);

            /*" -4836- IF (LK-GE853-COD-RETORNO EQUAL 'F' ) */

            if ((REGISTRO_LINKAGE_GE0853S.LK_GE853_COD_RETORNO == "F"))
            {

                /*" -4837- MOVE 399 TO LK-GE853-NUM-ERRO */
                _.Move(399, REGISTRO_LINKAGE_GE0853S.LK_GE853_NUM_ERRO);

                /*" -4839- END-IF */
            }


            /*" -4840- IF (WS-MSG-RETORNO NOT EQUAL SPACES) */

            if ((!WS_MSG_RETORNO.IsEmpty()))
            {

                /*" -4844- STRING WNR-EXEC-SQL '-' WS-MSG-RETORNO DELIMITED BY SIZE INTO LK-GE853-MSG-RETORNO END-STRING */
                #region STRING
                var spl1 = AREA_DE_WORK.WABEND.WNR_EXEC_SQL.GetMoveValues();
                spl1 += "-";
                var spl2 = WS_MSG_RETORNO.GetMoveValues();
                var results3 = spl1 + spl2;
                _.Move(results3, REGISTRO_LINKAGE_GE0853S.LK_GE853_MENSAGEM.LK_GE853_MSG_RETORNO);
                #endregion

                /*" -4846- END-IF. */
            }


            /*" -4846- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}