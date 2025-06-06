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
using Sias.VidaEmGrupo.DB2.VG0030B;

namespace Code
{
    public class VG0030B
    {
        public bool IsCall { get; set; }

        public VG0030B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *                      *** CANCELAMENTO ***                      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   FUNCAO .................  LE TABELA MOVIMENTO E INCLUI DADOS *      */
        /*"      *                             NAS TABELAS ..:V0COBERAPOL         *      */
        /*"      *                                            V0HISTSEGVG         *      */
        /*"      *                                            V0HISTCONTABILVA    *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  PROCAS                             *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0030B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  AGOSTO/ 91                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.31  *   VERSAO 31 - INCIDENTE 361865                                 *      */
        /*"      *                                                                *      */
        /*"      *             - CANCELADO POR EXCESSO DE TEMPO DE PROCESSAMENTO, *      */
        /*"      *               ANALISE DE LOOP NO PROGRAMA                      *      */
        /*"      *             - CALCULA A QUANTIDADE DE CERTIFICADOS A SEREM     *      */
        /*"      *               CANCELADOS E ALERTA PARA O TEMPO DE PROCESSAMENTO*      */
        /*"      *             - LIMITA O PROCESSAMENTO A 100.000 CERTIFICADOS POR*      */
        /*"      *               VEZ, PARA A DIARIA NAO FICAR COM TEMPO EXCEDIDO  *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/02/2022 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.30  *   VERSAO 30 - DEMANDA JAZZ 229040                              *      */
        /*"      *                                                                *      */
        /*"      *          CORRECAO NOS PROCEDIMENTOS DE INCLUSAO NA TABELA      *      */
        /*"      *          V0COBERAPOL (APOLICE_COBERTURA)                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/01/2020 - CANETTA                  PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 29 - DEMANDA - 225347 - ABEND 179203                  *      */
        /*"      *                                                                *      */
        /*"      *          PARA CASOS EM QUE O CANCELAMENTO OCORRE LOGO APOS     *      */
        /*"      *          O AUMENTO DE IGPM, AONDE EXISTE UMA LINHA NA COBERAPOL*      */
        /*"      *          E QUE A DATA DE TERMINO DE VIGENCIA E MENOR QUE A DATA*      */
        /*"      *          DE INICIO DE VIGENCIA.                                *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/12/2019 - CLAUDETE RADEL                               *      */
        /*"      *                                            PROCURE POR V.29    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28 - DEMANDA - 178.460                                *      */
        /*"      *                                                                *      */
        /*"      *          CORRIGIR ALGUMAS INCOSISTENCIAS NO CANCELAMENTO, ANA- *      */
        /*"      *          LISE INICIADA NA VERSAO 25.                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/12/2018 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 27 - INCIDENTE - HISTORIA 170535                      *      */
        /*"      *                                                                *      */
        /*"      *          OCORRENCIA DE FALHA 170535 - VIDA EM GRUPO            *      */
        /*"      *                                                                *      */
        /*"      *   VG0030B-PROBLEMAS SELECT PROPOSTAS_VA                        *      */
        /*"      *   NUMERO APOLICE ... 0108208874329                             *      */
        /*"      *   CODIGO SUBGRUPO M. 01489                                     *      */
        /*"      *   CODIGO SUBGRUPO W. 01489                                     *      */
        /*"      *   SQLCODE .......... 0000000811-                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/10/2018 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.27    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - INCIDENTE - HISTORIA 163122                      *      */
        /*"      *                                                                *      */
        /*"      *          OCORRENCIA DE FALHA 167736 - VIDA EM GRUPO            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/06/2018 - MARCUS VALERIO                               *      */
        /*"      *                                            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - HISTORIA 39.394                                  *      */
        /*"      *                                                                *      */
        /*"      *          VERIFICAR O TIPO DE SEGURO QUE ESTA SENDO CANCELADO E *      */
        /*"      *          PARA EMPRESARIAIS E APOLICES ESPECIFICAS RECUPERAR OS *      */
        /*"      *          VALORES VIGENTES NA TABELA APOLICE_COBERTURAS.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/06/2018 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.25    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - HISTORIA 26743                                   *      */
        /*"      *                                                                *      */
        /*"      *          TRATAR REGISTROS DA APOLICE 108208874329 COM VALORES  *      */
        /*"      *          DE PRM-VG-ATU E PRM-AP-ATU ZERADOS. ATUALMENTE OS     *      */
        /*"      *          CERTIFICADOS NAO ESTAO SENDO CANCELADOS POR CAUSA     *      */
        /*"      *          DESTA CONSICAO.                                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/05/2018 - RIBAMAR MARQUES                              *      */
        /*"      *                                            PROCURE POR V.24    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - OCORR�NCIA DE FALHA N� 163841                    *      */
        /*"      *   O PROGRAMA EXCEDEU O TEMPO LIMITE DE EXECUCAO.               *      */
        /*"      *                                                                *      */
        /*"      *             - PASSA ACESSAR TABELA NO CURSOR, AJUSTANDO        *      */
        /*"      *               ACESSO PELO MELHOR INDICE.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/05/2018 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.23    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22 - CADMUS 154.956                                   *      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.22    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - ABEND - CADMUS 139686                            *      */
        /*"      *             - CANCELADO POR EXCESSO DE TEMPO DE PROCESSAMENTO, *      */
        /*"      *               ANALISE DE LOOP NO PROGRAMA                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/07/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - ABEND - CADMUS 135496                            *      */
        /*"      *             - INCLUIR PONTONS DE CONTROLE PARA DESCOBRIR O     *      */
        /*"      *               PROBLEMA AO INCLUIR NA V0COBERAPOL.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/04/2016 - CLAUDETE RADEL                               *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - ABEND - CADMUS 125727                            *      */
        /*"      *             - CORRECAO PARA NAO SAIR PRA ERRO QUANDO NAO       *      */
        /*"      *               ENCONTRAR REGISTRO NA SEGURADOS_VGAP, FAZENDO    *      */
        /*"      *               CANCELAMENTO MAIS PRINCIPAIS TABELAS.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/11/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO EM 02-10-2014 - JONNY ANDERSON C.SARAIVA           *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NO CONTEUDO DO CAMPO VGMODALIFR              *      */
        /*"      *                                                                *      */
        /*"      *                                        PROCURE POR V.17        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 - CAD 97.240                                       *      */
        /*"      *             - PROCURAR NA MOVIMENTO POR OPERACAO MENOR QUE 800 *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/08/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.16  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 - CAD 101.808                                      *      */
        /*"      *             - CANCELA CERTIFICADO MESMO QUANDO NAO ENCONTRADO  *      */
        /*"      *               O REGISTRO NA V0COBERAPOL                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                              PROCURE POR V.15  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 14 - CADMUS 97.240                                    *      */
        /*"      *             - CORRECAO DE QUERY PARA NAO PEGAR MOVIMENTO JAH   *      */
        /*"      *               PROCESSADO NA V0MOVIMENTO) PARA O SEGURADO.      *      */
        /*"      *                                                                *      */
        /*"      *             - CONSULTA HIS_COBER_PROPOST PARA VALORES DE PREMIO*      */
        /*"      *               COM ZERO NA TABELA DE MOVIMENTO.                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/08/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.14    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 13 - CADMUS 78.536                                    *      */
        /*"      *               NAO PROCESSA CANCELAMENTOS SE HOUVER MOVIMENTO NA*      */
        /*"      *               MOVIMENTO_VGAP (V0MOVIMENTO) PARA O SEGURADO.    *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2013 - LUIZ MARQUES (FAST COMPUTER)                 *      */
        /*"      *                                            PROCURE POR V.13    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * CADMUS        : 24.762                                         *      */
        /*"      *                                                                *      */
        /*"      * DESCRICAO     : CORRIGIR SQLCODE -803 NA TABELA (V0HISTSEGVG)  *      */
        /*"      *                                                                *      */
        /*"      * DESENVOLVEDOR : LEANDRO CORTES (FAST COMPUTER)                 *      */
        /*"      *                                                                *      */
        /*"      *                                         PROCURE POR V.12       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 12/09/2008   INCLUIR CLAUS WITH UR NO COMANDO SELECT- WV0908   *      */
        /*"      * 16/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - SSI 13.933/2008                                  *      */
        /*"      *               RETIRADA DE APOLICES DE PRESTAMISTAS ATE QUE SEJA*      */
        /*"      *               CORRIGIDO O PROBLEMA DESTAS APOLICES.            *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/09/2008 - WANGER (FAST COMPUTER)   PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 19/08/94.                                       *      */
        /*"      *    MOTIVO     : DEVIDO A EXISTENCIA DE SEGUROS ANTIGO EM CRU-  *      */
        /*"      *                 ZEIROS REAIS, A CONVERSAO PARA REAL GEROU      *      */
        /*"      *                 VALORES MUITO PEQUENOS, E O SISTEMA CONSIDEROU *      */
        /*"      *                 COMO O VALOR DO PREMIO.                        *      */
        /*"      *    PROVIDENCIA : QUANDO O PREMIO FOR ZERO O PERCENTUAL SERA    *      */
        /*"      *                  IGUAL A ZEROS.                                *      */
        /*"      *                                  EDSON LUIZ NUNES GUIMARAES    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 13/03/98.                                       *      */
        /*"      *               . ATUALIZACAO DA SITUACAO DO SEGURADO NA NOVA    *      */
        /*"      *                 ESTRUTURA DO MULTIPREMIADO PARA A OPERACAO DE  *      */
        /*"      *                 CANCELAMENTO POR SINISTRO (402). TABELA ENVOL- *      */
        /*"      *                 VIDA: V0PROPOSTAVA.                            *      */
        /*"      *                                  FREDERICO FONSECA             *      */
        /*"      *                . PROCURAR POR FF01.                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 28/05/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 22/04/99.                                       *      */
        /*"      *               . INCLUSAO DO CANCELAMENTO NA TABELA DO MULTIPRE-*      */
        /*"      *                 MIADO V0HISTCONTABILVA.                        *      */
        /*"      *                                  MANOEL MESSIAS                *      */
        /*"      *                . PROCURAR POR MM0499                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 20/09/99.                                       *      */
        /*"      *               . ATUALIZACAO DA SITUACAO DO SEGURADO NA NOVA    *      */
        /*"      *                 ESTRUTURA DO MULTIPREMIADO PARA OS SEGURADOS   *      */
        /*"      *                 DO VIDAZUL. TABELA ENVOLVIDA: V0PROPOSTAVA.    *      */
        /*"      *                                  FREDERICO FONSECA             *      */
        /*"      *                . PROCURAR POR FF0999.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 06/04/00.                                       *      */
        /*"      *               . CANCELAMENTO DO SEGURADO NA TABELA DE CARENCIAS*      */
        /*"      *                 DO PRODUTO PREFERENCIAL VIDA, PARA OS SEGURADOS*      */
        /*"      *                 COM IDADE ENTRE 61 E 80 ANOS.                  *      */
        /*"      *                 TABELA ENVOLVIDA: CARENCIAS_VGAP.              *      */
        /*"      *               . ATUALIZA A PROPOSTAVA INDEPENDENTE DE SER A OPE*      */
        /*"      *                 RACAO 402.                                     *      */
        /*"      *                                  MANOEL MESSIAS                *      */
        /*"      *                . PROCURAR POR MM0400.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 12/04/00.                                       *      */
        /*"      *               . NO INSERT DA V0HISTCONTABILVA A COLUNA SITUACAO*      */
        /*"      *                 SERA SETADA PARA '0', AO INVES, DE ' ' (BRANCO)*      */
        /*"      *                 QUANDO INSERIA COM SITUACAO=' ', O PROGRAMA DE *      */
        /*"      *                 FATURAMENTO NAO PEGAVA ESSES CANCELAMENTOS.    *      */
        /*"      *                                  MANOEL MESSIAS                *      */
        /*"      *                . PROCURAR POR MM1200.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 13/04/06.                                       *      */
        /*"      *               . DESFAZER O CONTROLE DE OCORRENCIA DA APOLICE   *      */
        /*"      *                 DO CONSORCIO POIS ESTAVA DESPONTERANDO AS TABE-*      */
        /*"      *                 LAS.                                           *      */
        /*"      *                                  FAST COMPUTER                 *      */
        /*"      *                . PROCURAR POR FC0604.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    ALTERADO EM 17/11/06.                                       *      */
        /*"      *               . DESFAZER O CONTROLE DE OCORRENCIA DA APOLICE   *      */
        /*"      *                 DO CONSORCIO APOLICE 109300000635              *      */
        /*"      *                                                                *      */
        /*"      *                . PROCURAR POR LV0611.                          *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WS-TEM-SEGURADO            PIC  X(001)      VALUE 'N'.*/
        public StringBasis WS_TEM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77  MNUM-APOLICE               PIC S9(013)      COMP-3.*/
        public IntBasis MNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  MCOD-SUBGRUPO              PIC S9(004)      COMP.*/
        public IntBasis MCOD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-FONTE                 PIC S9(004)      COMP.*/
        public IntBasis MCOD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MNUM-PROPOSTA              PIC S9(009)      COMP.*/
        public IntBasis MNUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MTIPO-SEGURADO             PIC  X(001).*/
        public StringBasis MTIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0NUM-CERTIFICADO          PIC S9(015)      COMP-3.*/
        public IntBasis V0NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  MNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  MDAC-CERTIFICADO           PIC  X(001).*/
        public StringBasis MDAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MTIPO-INCLUSAO             PIC  X(001).*/
        public StringBasis MTIPO_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MCOD-CLIENTE               PIC S9(009)      COMP.*/
        public IntBasis MCOD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MCOD-AGENCIADOR            PIC S9(009)      COMP.*/
        public IntBasis MCOD_AGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MCOD-CORRETOR              PIC S9(009)      COMP.*/
        public IntBasis MCOD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MCOD-PLANOVGAP             PIC S9(004)      COMP.*/
        public IntBasis MCOD_PLANOVGAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-PLANOAP               PIC S9(004)      COMP.*/
        public IntBasis MCOD_PLANOAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MFAIXA                     PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MAUTOR-AUM-AUTOMAT         PIC  X(001).*/
        public StringBasis MAUTOR_AUM_AUTOMAT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MTIPO-BENEFICIARIO         PIC  X(001).*/
        public StringBasis MTIPO_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MPERI-PAGAMENTO            PIC S9(004)      COMP.*/
        public IntBasis MPERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MPERI-RENOVACAO            PIC S9(004)      COMP.*/
        public IntBasis MPERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MCOD-OCUPACAO              PIC  X(004).*/
        public StringBasis MCOD_OCUPACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
        /*"77  MESTADO-CIVIL              PIC  X(001).*/
        public StringBasis MESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MIDE-SEXO                  PIC  X(001).*/
        public StringBasis MIDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MCOD-PROFISSAO             PIC S9(004)      COMP.*/
        public IntBasis MCOD_PROFISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MNATURALIDADE              PIC  X(030).*/
        public StringBasis MNATURALIDADE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77  MOCORR-ENDERECO            PIC S9(004)      COMP.*/
        public IntBasis MOCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MOCORR-END-COBRAN          PIC S9(004)      COMP.*/
        public IntBasis MOCORR_END_COBRAN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MBCO-COBRANCA              PIC S9(004)      COMP.*/
        public IntBasis MBCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MAGE-COBRANCA              PIC S9(004)      COMP.*/
        public IntBasis MAGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MDAC-COBRANCA              PIC  X(001).*/
        public StringBasis MDAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MNUM-MATRICULA             PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  MNUM-CTA-CORRENTE          PIC S9(017)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"77  MDAC-CTA-CORRENTE          PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MVAL-SALARIO               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MVAL_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MTIPO-SALARIO              PIC  X(001).*/
        public StringBasis MTIPO_SALARIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MTIPO-PLANO                PIC  X(001).*/
        public StringBasis MTIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MPCT-CONJUGE-VG            PIC S9(003)V99   COMP-3.*/
        public DoubleBasis MPCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  MPCT-CONJUGE-AP            PIC S9(003)V99   COMP-3.*/
        public DoubleBasis MPCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  MQTD-SAL-MORNATU           PIC S9(004)      COMP.*/
        public IntBasis MQTD_SAL_MORNATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MQTD-SAL-MORACID           PIC S9(004)      COMP.*/
        public IntBasis MQTD_SAL_MORACID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MQTD-SAL-INVPERM           PIC S9(004)      COMP.*/
        public IntBasis MQTD_SAL_INVPERM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MTAXA-AP-MORACID           PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-INVPERM           PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-AMDS              PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-DH                PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-AP-DIT               PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MTAXA-VG                   PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"77  MIMP-MORNATU-ANT           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORNATU_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-MORNATU-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-MORACID-ANT           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORACID_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-MORACID-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-INVPERM-ANT           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_INVPERM_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-INVPERM-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-AMDS-ANT              PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_AMDS_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-AMDS-ATU              PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DH-ANT                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DH-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DIT-ANT               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DIT_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MIMP-DIT-ATU               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MIMP_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-VG-ANT                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_VG_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-VG-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-AP-ANT                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_AP_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MPRM-AP-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis MPRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  MCOD-OPERACAO              PIC S9(004)      COMP.*/
        public IntBasis MCOD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MDATA-OPERACAO             PIC  X(010).*/
        public StringBasis MDATA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  COD-SUBGRUPO-TRANS         PIC S9(004)      COMP.*/
        public IntBasis COD_SUBGRUPO_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MSIT-REGISTRO              PIC  X(001).*/
        public StringBasis MSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  MCOD-USUARIO               PIC  X(008).*/
        public StringBasis MCOD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  MDATA-AVERBACAO            PIC  X(010).*/
        public StringBasis MDATA_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-ADMISSAO             PIC  X(010).*/
        public StringBasis MDATA_ADMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-INCLUSAO             PIC  X(010).*/
        public StringBasis MDATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-NASCIMENTO           PIC  X(010).*/
        public StringBasis MDATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-FATURA               PIC  X(010).*/
        public StringBasis MDATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-REFERENCIA           PIC  X(010).*/
        public StringBasis MDATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-MOVIMENTO            PIC  X(010).*/
        public StringBasis MDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SDATA-MOVIMENTO            PIC  X(010).*/
        public StringBasis SDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MCOD-EMPRESA               PIC S9(009)      COMP.*/
        public IntBasis MCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0APOL-RAMO                PIC S9(004)      COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0APOL-MODALIDA            PIC S9(004)      COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WTIPO-FATURAMENTO          PIC  X(001)      VALUE SPACES.*/
        public StringBasis WTIPO_FATURAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77  WCOD-SUBGRUPO-EMP          PIC S9(004)      COMP.*/
        public IntBasis WCOD_SUBGRUPO_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis WNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  WSIT-REGISTRO              PIC  X(001).*/
        public StringBasis WSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WIMP-MORNATU-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WIMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WIMP-MORACID-ATU           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WIMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WPRM-VG-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WPRM_VG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WPRM-AP-ATU                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WPRM_AP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  WQUANT-VIDAS               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis WQUANT_VIDAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  SOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis SOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-ITEM                 PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SSIT-REGISTRO             PIC  X(001).*/
        public StringBasis SSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  DVLCRUZAD-IMP             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  DVLCRUZAD-PRM             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  V1SISTEMA-DTMOVABE        PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SISTEMA-DTMOVABE-1      PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1PAR-RAMO-VG             PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1PAR-RAMO-AP             PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1PAR-RAMO-PST            PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_PST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EN-COD-MOEDA-IMP        PIC S9(004)      COMP.*/
        public IntBasis V1EN_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EN-COD-MOEDA-PRM        PIC S9(004)      COMP.*/
        public IntBasis V1EN_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGNUM-APOLICE             PIC S9(013)      COMP-3.*/
        public IntBasis VGNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  VGNRENDOS                 PIC S9(009)      COMP.*/
        public IntBasis VGNRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VGNUM-ITEM                PIC S9(009)      COMP.*/
        public IntBasis VGNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VGOCORHIST                PIC S9(004)      COMP.*/
        public IntBasis VGOCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGRAMOFR                  PIC S9(004)      COMP.*/
        public IntBasis VGRAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGMODALIFR                PIC S9(004)      COMP.*/
        public IntBasis VGMODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGCOD-COBERTURA           PIC S9(004)      COMP.*/
        public IntBasis VGCOD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGIMP-SEGURADA-IX         PIC S9(013)V99   COMP-3.*/
        public DoubleBasis VGIMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  VGPRM-TARIFARIO-IX        PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis VGPRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  VGIMP-SEGURADA-VAR        PIC S9(013)V99   COMP-3.*/
        public DoubleBasis VGIMP_SEGURADA_VAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  PRM-TARIFARIO-VAR         PIC S9(010)V9(5) COMP-3.*/
        public DoubleBasis PRM_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  VGPCT-COBERTURA           PIC S9(003)V99   COMP-3.*/
        public DoubleBasis VGPCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  VGPCT-COBERTURA1          PIC S9(003)V99   COMP-3.*/
        public DoubleBasis VGPCT_COBERTURA1 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  VGPCT-COBERTURA2          PIC S9(003)V99   COMP-3.*/
        public DoubleBasis VGPCT_COBERTURA2 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  VGFATOR-MULTIPLICA        PIC S9(004)      COMP.*/
        public IntBasis VGFATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  VGDATA-INIVIGENCIA        PIC  X(010).*/
        public StringBasis VGDATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  VGDATA-TERVIGENCIA        PIC  X(010).*/
        public StringBasis VGDATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  VGCOD-SITUACAO            PIC  X(001).*/
        public StringBasis VGCOD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  VGCOD-SITUACAO-I          PIC  S9(004)      COMP.*/
        public IntBasis VGCOD_SITUACAO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  MAX-OCORR-HIST            PIC  S9(004)      COMP.*/
        public IntBasis MAX_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  DATA-INIVIGENCIA-C        PIC  X(010).*/
        public StringBasis DATA_INIVIGENCIA_C { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  HHORA-OPERACAO            PIC  X(008).*/
        public StringBasis HHORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  WHOCORR-HISTORICO         PIC S9(004)      COMP.*/
        public IntBasis WHOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis HOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HCOD-SUBGRUP-TRANS        PIC S9(004)      COMP.*/
        public IntBasis HCOD_SUBGRUP_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0PROP-NRPARCELA           PIC S9(004)      COMP.*/
        public IntBasis V0PROP_NRPARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HCOB-NRTIT               PIC S9(013)      COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0HCOB-OCORHIST            PIC S9(004)      COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0HCOB-DTVENCTO            PIC  X(010).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0PARC-PRMVG               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0PARC-PRMAP               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0HCON-OCORHIST            PIC S9(004)      COMP.*/
        public IntBasis V0HCON_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WORIG-PRODUTO              PIC  X(010).*/
        public StringBasis WORIG_PRODUTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WHOST-COUNT-MOV            PIC S9(004)      COMP.*/
        public IntBasis WHOST_COUNT_MOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-AVERBACAO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-ADMISSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-INCLUSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASCIMENTO          PIC S9(004)      COMP.*/
        public IntBasis WDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-FATURA              PIC S9(004)      COMP.*/
        public IntBasis WDATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-REFERENCIA          PIC S9(004)      COMP.*/
        public IntBasis WDATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO1          PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-EMPRESA              PIC S9(004)      COMP.*/
        public IntBasis WCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-MOEDA                PIC S9(004)      COMP VALUE +1.*/
        public IntBasis WCOD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP.*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  REGISTRO-LINKAGE-GE0510S.*/
        public VG0030B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG0030B_REGISTRO_LINKAGE_GE0510S();
        public class VG0030B_REGISTRO_LINKAGE_GE0510S : VarBasis
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
            public VG0030B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG0030B_LK_GE510_MENSAGEM();
            public class VG0030B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01 WS-AUXILIARES.*/
            }
        }
        public VG0030B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VG0030B_WS_AUXILIARES();
        public class VG0030B_WS_AUXILIARES : VarBasis
        {
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WS-SQL-EDT          PIC  ---9.*/
            public IntBasis WS_SQL_EDT { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
            /*"  03            AC-GRAVA-LID        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_LID { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-HIS        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_HIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-PRO        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_PRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-CAR        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_CAR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-SEG        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_SEG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-MOV        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_MOV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-CAN        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_CAN { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-PRM-ZEROS  PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_PRM_ZEROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-IMP-ZEROS  PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_IMP_ZEROS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-GRAVA-VG-PRODUTO PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_VG_PRODUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-ERRO-COBERAPOL   PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_ERRO_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-ERRO-FONTE       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_ERRO_FONTE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            AC-ERRO-MOV         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_ERRO_MOV { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WTEM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
            public StringBasis WTEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WNAO-ACHEI-HIS      PIC  X(001) VALUE 'N'.*/
            public StringBasis WNAO_ACHEI_HIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WAPOLICE-ATU        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ATU { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            WAPOLICE-ANT        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            WHORA-OPERACAO-WORK.*/
            public VG0030B_WHORA_OPERACAO_WORK WHORA_OPERACAO_WORK { get; set; } = new VG0030B_WHORA_OPERACAO_WORK();
            public class VG0030B_WHORA_OPERACAO_WORK : VarBasis
            {
                /*"    05          WHORA-HORA          PIC  X(002).*/
                public StringBasis WHORA_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05          FILLER              PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    05          WHORA-MINU          PIC  X(002).*/
                public StringBasis WHORA_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05          FILLER              PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    05          WHORA-SEGU          PIC  X(002).*/
                public StringBasis WHORA_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  03            WHORA-OPERACAO-WORK-R    REDEFINES                WHORA-OPERACAO-WORK      PIC  X(008).*/
            }
            private _REDEF_StringBasis _whora_operacao_work_r { get; set; }
            public _REDEF_StringBasis WHORA_OPERACAO_WORK_R
            {
                get { _whora_operacao_work_r = new _REDEF_StringBasis(new PIC("X", "008", "X(008).")); ; _.Move(WHORA_OPERACAO_WORK, _whora_operacao_work_r); VarBasis.RedefinePassValue(WHORA_OPERACAO_WORK, _whora_operacao_work_r, WHORA_OPERACAO_WORK); _whora_operacao_work_r.ValueChanged += () => { _.Move(_whora_operacao_work_r, WHORA_OPERACAO_WORK); }; return _whora_operacao_work_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_work_r, WHORA_OPERACAO_WORK); }
            }  //Redefines
            /*"  03            WHORA-OPERACAO-1    PIC 99999999.*/
            public IntBasis WHORA_OPERACAO_1 { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
            /*"  03            WHORA-PER-X REDEFINES WHORA-OPERACAO-1.*/
            private _REDEF_VG0030B_WHORA_PER_X _whora_per_x { get; set; }
            public _REDEF_VG0030B_WHORA_PER_X WHORA_PER_X
            {
                get { _whora_per_x = new _REDEF_VG0030B_WHORA_PER_X(); _.Move(WHORA_OPERACAO_1, _whora_per_x); VarBasis.RedefinePassValue(WHORA_OPERACAO_1, _whora_per_x, WHORA_OPERACAO_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, WHORA_OPERACAO_1); }; return _whora_per_x; }
                set { VarBasis.RedefinePassValue(value, _whora_per_x, WHORA_OPERACAO_1); }
            }  //Redefines
            public class _REDEF_VG0030B_WHORA_PER_X : VarBasis
            {
                /*"     05         WHORA-OPERACAO-2    PIC 999999.*/
                public IntBasis WHORA_OPERACAO_2 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                /*"     05         FILLER              PIC 99.*/
                public IntBasis FILLER_3 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                /*"  03            WHORA-OPERACAO.*/

                public _REDEF_VG0030B_WHORA_PER_X()
                {
                    WHORA_OPERACAO_2.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public VG0030B_WHORA_OPERACAO WHORA_OPERACAO { get; set; } = new VG0030B_WHORA_OPERACAO();
            public class VG0030B_WHORA_OPERACAO : VarBasis
            {
                /*"    05          WHORA-HORA-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_HORA_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-MINU-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_MINU_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05          WHORA-SEGU-W        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WHORA_SEGU_W { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03            WHORA-OPERACAO-R    REDEFINES                WHORA-OPERACAO      PIC  9(006).*/
            }
            private _REDEF_IntBasis _whora_operacao_r { get; set; }
            public _REDEF_IntBasis WHORA_OPERACAO_R
            {
                get { _whora_operacao_r = new _REDEF_IntBasis(new PIC("9", "006", "9(006).")); ; _.Move(WHORA_OPERACAO, _whora_operacao_r); VarBasis.RedefinePassValue(WHORA_OPERACAO, _whora_operacao_r, WHORA_OPERACAO); _whora_operacao_r.ValueChanged += () => { _.Move(_whora_operacao_r, WHORA_OPERACAO); }; return _whora_operacao_r; }
                set { VarBasis.RedefinePassValue(value, _whora_operacao_r, WHORA_OPERACAO); }
            }  //Redefines
            /*"  03  WS-COUNT                      PIC 9(09) VALUE 0.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  03  ON-INTERVAL  REDEFINES WS-COUNT.*/
            private _REDEF_VG0030B_ON_INTERVAL _on_interval { get; set; }
            public _REDEF_VG0030B_ON_INTERVAL ON_INTERVAL
            {
                get { _on_interval = new _REDEF_VG0030B_ON_INTERVAL(); _.Move(WS_COUNT, _on_interval); VarBasis.RedefinePassValue(WS_COUNT, _on_interval, WS_COUNT); _on_interval.ValueChanged += () => { _.Move(_on_interval, WS_COUNT); }; return _on_interval; }
                set { VarBasis.RedefinePassValue(value, _on_interval, WS_COUNT); }
            }  //Redefines
            public class _REDEF_VG0030B_ON_INTERVAL : VarBasis
            {
                /*"      10 FILLER                     PIC 9(06).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"      10 ON-COUNTER                 PIC 9(03).*/
                public IntBasis ON_COUNTER { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"  03  WS-TIME                       PIC 99.99.99.99.*/

                public _REDEF_VG0030B_ON_INTERVAL()
                {
                    FILLER_4.ValueChanged += OnValueChanged;
                    ON_COUNTER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_TIME { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03            WS-W01DTSQL.*/
            public VG0030B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0030B_WS_W01DTSQL();
            public class VG0030B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01AASQL         PIC  9(004).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W01T1SQL         PIC  X(001).*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001).*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WPRMTOT             PIC S9(013)V99                                        VALUE +0 COMP-3.*/
            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WABEND.*/
            public VG0030B_WABEND WABEND { get; set; } = new VG0030B_WABEND();
            public class VG0030B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VG0030B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0030B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      WNR-EXEC-SQL-ANT    PIC  X(007) VALUE SPACES.*/
                public StringBasis WNR_EXEC_SQL_ANT { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VG0030B_LK_LINK LK_LINK { get; set; } = new VG0030B_LK_LINK();
        public class VG0030B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01  WS-EOF-PRODUTOS-VG          PIC  9(001)    VALUE ZEROS.*/
        }
        public IntBasis WS_EOF_PRODUTOS_VG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"01  WS-QTD-A-PROCESSAR          PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WS_QTD_A_PROCESSAR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-QTD-DISPLAY              PIC ZZZ.ZZZ.999.*/
        public IntBasis WS_QTD_DISPLAY { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.999."));


        public VG0030B_TMOVIMENTO TMOVIMENTO { get; set; } = new VG0030B_TMOVIMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -618- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -620- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -622- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -625- DISPLAY '*-------------------------------------------------*' */
            _.Display($"*-------------------------------------------------*");

            /*" -626- DISPLAY '          PROGRAMA EM EXECUCAO VG00030B           ' */
            _.Display($"          PROGRAMA EM EXECUCAO VG00030B           ");

            /*" -627- DISPLAY '*-------------------------------------------------*' */
            _.Display($"*-------------------------------------------------*");

            /*" -630- DISPLAY 'VERSAO V.31: ' FUNCTION WHEN-COMPILED ' - 361865  ' */

            $"VERSAO V.31: FUNCTION{_.WhenCompiled()} - 361865  "
            .Display();

            /*" -632- DISPLAY '*-------------------------------------------------*' */
            _.Display($"*-------------------------------------------------*");

            /*" -634- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUXILIARES.WS_TIME);

            /*" -641- DISPLAY 'PROCESSAMENTO DA VG00030B EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"PROCESSAMENTO DA VG00030B EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -653- DISPLAY '     ' */
            _.Display($"     ");

            /*" -655- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -657- PERFORM 070-000-LER-V1PARAMRAMO. */

            M_070_000_LER_V1PARAMRAMO_SECTION();

            /*" -659- PERFORM 080-000-LER-V1MOEDA. */

            M_080_000_LER_V1MOEDA_SECTION();

            /*" -661- PERFORM 095-000-CALCULO-QTD-PROCESSAR. */

            M_095_000_CALCULO_QTD_PROCESSAR_SECTION();

            /*" -663- PERFORM 090-000-CURSOR-V1MOVIMENTO. */

            M_090_000_CURSOR_V1MOVIMENTO_SECTION();

            /*" -665- PERFORM 100-000-FETCH-V1MOVIMENTO. */

            M_100_000_FETCH_V1MOVIMENTO_SECTION();

            /*" -666- IF (WFIM-MOVIMENTO EQUAL 'N' ) */

            if ((WS_AUXILIARES.WFIM_MOVIMENTO == "N"))
            {

                /*" -668- PERFORM 120-000-PROC-MOVIMENTO UNTIL WFIM-MOVIMENTO = 'S' */

                while (!(WS_AUXILIARES.WFIM_MOVIMENTO == "S"))
                {

                    M_120_000_PROC_MOVIMENTO_SECTION();
                }

                /*" -669- ELSE */
            }
            else
            {


                /*" -670- DISPLAY '*** VG0030B *** NAO HOUVE MOVIMENTO' */
                _.Display($"*** VG0030B *** NAO HOUVE MOVIMENTO");

                /*" -672- END-IF */
            }


            /*" -672- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -682- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -684- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -692- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -695- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -696- DISPLAY 'VG0030B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG0030B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -697- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -698- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -698- END-IF. */
            }


        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -692- EXEC SQL SELECT DTMOVABE, DTMOVABE - 1 DAY INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-DTMOVABE-1 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
                _.Move(executed_1.V1SISTEMA_DTMOVABE_1, V1SISTEMA_DTMOVABE_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-SECTION */
        private void M_070_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -709- MOVE '070-000-LER-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("070-000-LER-V1PARAMRAMO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -711- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -717- PERFORM M_070_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            M_070_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -720- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -721- DISPLAY 'VG0030B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                _.Display($"VG0030B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                /*" -721- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void M_070_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -717- EXEC SQL SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP, :V1PAR-RAMO-PST FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

            var m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 = new M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(m_070_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PAR_RAMO_VG, V1PAR_RAMO_VG);
                _.Move(executed_1.V1PAR_RAMO_AP, V1PAR_RAMO_AP);
                _.Move(executed_1.V1PAR_RAMO_PST, V1PAR_RAMO_PST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_070_999_EXIT*/

        [StopWatch]
        /*" M-080-000-LER-V1MOEDA-SECTION */
        private void M_080_000_LER_V1MOEDA_SECTION()
        {
            /*" -733- MOVE '080-000-LER-V1MOEDA' TO PARAGRAFO. */
            _.Move("080-000-LER-V1MOEDA", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -735- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -744- PERFORM M_080_000_LER_V1MOEDA_DB_SELECT_1 */

            M_080_000_LER_V1MOEDA_DB_SELECT_1();

            /*" -747- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -748- DISPLAY 'VG0030B - NAO CONSTA REGISTRO NA V1MOEDA' */
                _.Display($"VG0030B - NAO CONSTA REGISTRO NA V1MOEDA");

                /*" -750- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -751- MOVE V1EN-COD-MOEDA-IMP TO V1EN-COD-MOEDA-PRM. */
            _.Move(V1EN_COD_MOEDA_IMP, V1EN_COD_MOEDA_PRM);

            /*" -751- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM. */
            _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

        }

        [StopWatch]
        /*" M-080-000-LER-V1MOEDA-DB-SELECT-1 */
        public void M_080_000_LER_V1MOEDA_DB_SELECT_1()
        {
            /*" -744- EXEC SQL SELECT CODUNIMO, VLCRUZAD INTO :V1EN-COD-MOEDA-IMP, :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE TIPO_MOEDA = '0' AND SITUACAO = '0' WITH UR END-EXEC. */

            var m_080_000_LER_V1MOEDA_DB_SELECT_1_Query1 = new M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_080_000_LER_V1MOEDA_DB_SELECT_1_Query1.Execute(m_080_000_LER_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EN_COD_MOEDA_IMP, V1EN_COD_MOEDA_IMP);
                _.Move(executed_1.DVLCRUZAD_IMP, DVLCRUZAD_IMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_080_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-SECTION */
        private void M_090_000_CURSOR_V1MOVIMENTO_SECTION()
        {
            /*" -762- MOVE '090-000-CURSOR-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("090-000-CURSOR-V1MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -764- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -865- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1();

            /*" -869- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1()
        {
            /*" -865- EXEC SQL DECLARE TMOVIMENTO CURSOR FOR SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_FONTE, A.NUM_PROPOSTA, A.TIPO_SEGURADO, A.NUM_CERTIFICADO, A.DAC_CERTIFICADO, A.TIPO_INCLUSAO, A.COD_CLIENTE, A.COD_AGENCIADOR, A.COD_CORRETOR, A.COD_PLANOVGAP, A.COD_PLANOAP, A.FAIXA, A.AUTOR_AUM_AUTOMAT, A.TIPO_BENEFICIARIO, A.PERI_PAGAMENTO, A.PERI_RENOVACAO, A.COD_OCUPACAO, A.ESTADO_CIVIL, A.IDE_SEXO, A.COD_PROFISSAO, A.NATURALIDADE, A.OCORR_ENDERECO, A.OCORR_END_COBRAN, A.BCO_COBRANCA, A.AGE_COBRANCA, A.DAC_COBRANCA, A.NUM_MATRICULA, A.NUM_CTA_CORRENTE, A.DAC_CTA_CORRENTE, A.VAL_SALARIO, A.TIPO_SALARIO, A.TIPO_PLANO, A.PCT_CONJUGE_VG, A.PCT_CONJUGE_AP, A.QTD_SAL_MORNATU, A.QTD_SAL_MORACID, A.QTD_SAL_INVPERM, A.TAXA_AP_MORACID, A.TAXA_AP_INVPERM, A.TAXA_AP_AMDS, A.TAXA_AP_DH, A.TAXA_AP_DIT, A.TAXA_VG, A.IMP_MORNATU_ANT, A.IMP_MORNATU_ATU, A.IMP_MORACID_ANT, A.IMP_MORACID_ATU, A.IMP_INVPERM_ANT, A.IMP_INVPERM_ATU, A.IMP_AMDS_ANT, A.IMP_AMDS_ATU, A.IMP_DH_ANT, A.IMP_DH_ATU, A.IMP_DIT_ANT, A.IMP_DIT_ATU, A.PRM_VG_ANT, A.PRM_VG_ATU, A.PRM_AP_ANT, A.PRM_AP_ATU, A.COD_OPERACAO, A.DATA_OPERACAO, A.COD_SUBGRUPO_TRANS, A.SIT_REGISTRO, A.COD_USUARIO, A.DATA_AVERBACAO, A.DATA_ADMISSAO, A.DATA_INCLUSAO, A.DATA_NASCIMENTO, A.DATA_FATURA, A.DATA_REFERENCIA, A.DATA_MOVIMENTO, A.DATA_MOVIMENTO - 1 DAY, A.COD_EMPRESA, B.RAMO_EMISSOR, B.COD_MODALIDADE FROM SEGUROS.MOVIMENTO_VGAP A ,SEGUROS.APOLICES B WHERE A.DATA_INCLUSAO IS NULL AND A.COD_OPERACAO BETWEEN 0300 AND 499 AND A.DATA_AVERBACAO IS NOT NULL AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_APOLICE NOT IN (0109300000635, 0107700000007 ) ORDER BY B.NUM_APOLICE, A.NUM_CERTIFICADO FETCH FIRST 100000 ROWS ONLY END-EXEC. */
            TMOVIMENTO = new VG0030B_TMOVIMENTO(false);
            string GetQuery_TMOVIMENTO()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.COD_SUBGRUPO
							, 
							A.COD_FONTE
							, 
							A.NUM_PROPOSTA
							, 
							A.TIPO_SEGURADO
							, 
							A.NUM_CERTIFICADO
							, 
							A.DAC_CERTIFICADO
							, 
							A.TIPO_INCLUSAO
							, 
							A.COD_CLIENTE
							, 
							A.COD_AGENCIADOR
							, 
							A.COD_CORRETOR
							, 
							A.COD_PLANOVGAP
							, 
							A.COD_PLANOAP
							, 
							A.FAIXA
							, 
							A.AUTOR_AUM_AUTOMAT
							, 
							A.TIPO_BENEFICIARIO
							, 
							A.PERI_PAGAMENTO
							, 
							A.PERI_RENOVACAO
							, 
							A.COD_OCUPACAO
							, 
							A.ESTADO_CIVIL
							, 
							A.IDE_SEXO
							, 
							A.COD_PROFISSAO
							, 
							A.NATURALIDADE
							, 
							A.OCORR_ENDERECO
							, 
							A.OCORR_END_COBRAN
							, 
							A.BCO_COBRANCA
							, 
							A.AGE_COBRANCA
							, 
							A.DAC_COBRANCA
							, 
							A.NUM_MATRICULA
							, 
							A.NUM_CTA_CORRENTE
							, 
							A.DAC_CTA_CORRENTE
							, 
							A.VAL_SALARIO
							, 
							A.TIPO_SALARIO
							, 
							A.TIPO_PLANO
							, 
							A.PCT_CONJUGE_VG
							, 
							A.PCT_CONJUGE_AP
							, 
							A.QTD_SAL_MORNATU
							, 
							A.QTD_SAL_MORACID
							, 
							A.QTD_SAL_INVPERM
							, 
							A.TAXA_AP_MORACID
							, 
							A.TAXA_AP_INVPERM
							, 
							A.TAXA_AP_AMDS
							, 
							A.TAXA_AP_DH
							, 
							A.TAXA_AP_DIT
							, 
							A.TAXA_VG
							, 
							A.IMP_MORNATU_ANT
							, 
							A.IMP_MORNATU_ATU
							, 
							A.IMP_MORACID_ANT
							, 
							A.IMP_MORACID_ATU
							, 
							A.IMP_INVPERM_ANT
							, 
							A.IMP_INVPERM_ATU
							, 
							A.IMP_AMDS_ANT
							, 
							A.IMP_AMDS_ATU
							, 
							A.IMP_DH_ANT
							, 
							A.IMP_DH_ATU
							, 
							A.IMP_DIT_ANT
							, 
							A.IMP_DIT_ATU
							, 
							A.PRM_VG_ANT
							, 
							A.PRM_VG_ATU
							, 
							A.PRM_AP_ANT
							, 
							A.PRM_AP_ATU
							, 
							A.COD_OPERACAO
							, 
							A.DATA_OPERACAO
							, 
							A.COD_SUBGRUPO_TRANS
							, 
							A.SIT_REGISTRO
							, 
							A.COD_USUARIO
							, 
							A.DATA_AVERBACAO
							, 
							A.DATA_ADMISSAO
							, 
							A.DATA_INCLUSAO
							, 
							A.DATA_NASCIMENTO
							, 
							A.DATA_FATURA
							, 
							A.DATA_REFERENCIA
							, 
							A.DATA_MOVIMENTO
							, 
							A.DATA_MOVIMENTO - 1 DAY
							, 
							A.COD_EMPRESA
							, 
							B.RAMO_EMISSOR
							, 
							B.COD_MODALIDADE 
							FROM SEGUROS.MOVIMENTO_VGAP A 
							,SEGUROS.APOLICES B 
							WHERE A.DATA_INCLUSAO IS NULL 
							AND A.COD_OPERACAO BETWEEN 0300 AND 499 
							AND A.DATA_AVERBACAO IS NOT NULL 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_APOLICE NOT IN (0109300000635
							, 
							0107700000007 ) 
							ORDER BY B.NUM_APOLICE
							, A.NUM_CERTIFICADO 
							FETCH FIRST 100000 ROWS ONLY";

                return query;
            }
            TMOVIMENTO.GetQueryEvent += GetQuery_TMOVIMENTO;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1()
        {
            /*" -869- EXEC SQL OPEN TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-095-000-CALCULO-QTD-PROCESSAR-SECTION */
        private void M_095_000_CALCULO_QTD_PROCESSAR_SECTION()
        {
            /*" -880- MOVE '095-000-CALCULO-QTD-PROCESSAR' TO PARAGRAFO */
            _.Move("095-000-CALCULO-QTD-PROCESSAR", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -882- MOVE '095' TO WNR-EXEC-SQL. */
            _.Move("095", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -893- PERFORM M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1 */

            M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1();

            /*" -896- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -897- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WS_AUXILIARES.WFIM_MOVIMENTO);

                /*" -899- DISPLAY 'ERRO NO CALCULO DE QUANT. DE REGISTRO ' SQLCODE */
                _.Display($"ERRO NO CALCULO DE QUANT. DE REGISTRO {DB.SQLCODE}");

                /*" -900- GO TO 100-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;

                /*" -902- END-IF */
            }


            /*" -904- MOVE WS-QTD-A-PROCESSAR TO WS-QTD-DISPLAY */
            _.Move(WS_QTD_A_PROCESSAR, WS_QTD_DISPLAY);

            /*" -905- DISPLAY ' ' */
            _.Display($" ");

            /*" -906- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -908- DISPLAY 'QUANT. TOTAL A SEREM PROCESSADOS: ' WS-QTD-DISPLAY */
            _.Display($"QUANT. TOTAL A SEREM PROCESSADOS: {WS_QTD_DISPLAY}");

            /*" -909- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -911- DISPLAY ' ' */
            _.Display($" ");

            /*" -912- IF (WS-QTD-A-PROCESSAR > 100000) */

            if ((WS_QTD_A_PROCESSAR > 100000))
            {

                /*" -913- DISPLAY ' ' */
                _.Display($" ");

                /*" -914- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -915- DISPLAY '>>>>>>>>>>>>  A T E N C A O <<<<<<<<<<<<<<<<<<<' */
                _.Display($">>>>>>>>>>>>  A T E N C A O <<<<<<<<<<<<<<<<<<<");

                /*" -916- DISPLAY '>>>>>>>>>>>>  A T E N C A O <<<<<<<<<<<<<<<<<<<' */
                _.Display($">>>>>>>>>>>>  A T E N C A O <<<<<<<<<<<<<<<<<<<");

                /*" -917- DISPLAY '>>>>>>>>>>>>  A T E N C A O <<<<<<<<<<<<<<<<<<<' */
                _.Display($">>>>>>>>>>>>  A T E N C A O <<<<<<<<<<<<<<<<<<<");

                /*" -918- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -920- DISPLAY 'QTD DE CERTIFICADOS A SEREM PROCESSADOS ' 'EXCEDEM A 100.000 . ' */
                _.Display($"QTD DE CERTIFICADOS A SEREM PROCESSADOS EXCEDEM A 100.000 . ");

                /*" -922- DISPLAY 'TEMPO DE PROCESSAMENTO DO PROGRAMA PODERAH SER ' 'SUPERIOR AO HABITUAL. ' */
                _.Display($"TEMPO DE PROCESSAMENTO DO PROGRAMA PODERAH SER SUPERIOR AO HABITUAL. ");

                /*" -924- DISPLAY 'A QUANT. MAXIMA A SER PROCESSADA POR VEZ EH DE ' '100.000 REGISTROS.' */
                _.Display($"A QUANT. MAXIMA A SER PROCESSADA POR VEZ EH DE 100.000 REGISTROS.");

                /*" -925- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -926- DISPLAY '>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<' */
                _.Display($">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<");

                /*" -927- DISPLAY '>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<' */
                _.Display($">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<");

                /*" -928- DISPLAY '>>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<' */
                _.Display($">>>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<<");

                /*" -929- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -930- DISPLAY ' ' */
                _.Display($" ");

                /*" -930- END-IF. */
            }


        }

        [StopWatch]
        /*" M-095-000-CALCULO-QTD-PROCESSAR-DB-SELECT-1 */
        public void M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1()
        {
            /*" -893- EXEC SQL SELECT COUNT(*) INTO :WS-QTD-A-PROCESSAR FROM SEGUROS.MOVIMENTO_VGAP A ,SEGUROS.APOLICES B WHERE A.DATA_INCLUSAO IS NULL AND A.COD_OPERACAO BETWEEN 0300 AND 499 AND A.DATA_AVERBACAO IS NOT NULL AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_APOLICE NOT IN (0109300000635, 0107700000007 ) END-EXEC. */

            var m_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1 = new M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1.Execute(m_095_000_CALCULO_QTD_PROCESSAR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QTD_A_PROCESSAR, WS_QTD_A_PROCESSAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_095_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROC-MOVIMENTO-SECTION */
        private void M_120_000_PROC_MOVIMENTO_SECTION()
        {
            /*" -941- MOVE '120-000-PROC-MOVIMENTO' TO PARAGRAFO */
            _.Move("120-000-PROC-MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -943- PERFORM 8888-DISPLAY-TOTAIS */

            M_8888_DISPLAY_TOTAIS_SECTION();

            /*" -945- PERFORM 160-000-SELECT-V0MOVIMENTO. */

            M_160_000_SELECT_V0MOVIMENTO_SECTION();

            /*" -946- IF (WTEM-MOVIMENTO EQUAL 'S' ) */

            if ((WS_AUXILIARES.WTEM_MOVIMENTO == "S"))
            {

                /*" -947- ADD 1 TO AC-ERRO-MOV */
                WS_AUXILIARES.AC_ERRO_MOV.Value = WS_AUXILIARES.AC_ERRO_MOV + 1;

                /*" -948- GO TO 120-900-NEXT */

                M_120_900_NEXT(); //GOTO
                return;

                /*" -950- END-IF. */
            }


            /*" -951- IF (MCOD-FONTE NOT GREATER ZEROS) */

            if ((MCOD_FONTE <= 00))
            {

                /*" -952- ADD 1 TO AC-ERRO-FONTE */
                WS_AUXILIARES.AC_ERRO_FONTE.Value = WS_AUXILIARES.AC_ERRO_FONTE + 1;

                /*" -953- GO TO 120-900-NEXT */

                M_120_900_NEXT(); //GOTO
                return;

                /*" -955- END-IF. */
            }


            /*" -957- PERFORM 150-000-SELECT-V1SEGURAVG. */

            M_150_000_SELECT_V1SEGURAVG_SECTION();

            /*" -959- IF (SSIT-REGISTRO EQUAL '2' ) OR (WS-TEM-SEGURADO EQUAL 'N' ) */

            if ((SSIT_REGISTRO == "2") || (WS_TEM_SEGURADO == "N"))
            {

                /*" -960- PERFORM 420-000-UPDATE-V0PROPOSTAVA */

                M_420_000_UPDATE_V0PROPOSTAVA_SECTION();

                /*" -961- PERFORM 390-000-UPDATE-V0MOVIMENTO */

                M_390_000_UPDATE_V0MOVIMENTO_SECTION();

                /*" -962- ADD 1 TO AC-GRAVA-CAN */
                WS_AUXILIARES.AC_GRAVA_CAN.Value = WS_AUXILIARES.AC_GRAVA_CAN + 1;

                /*" -963- GO TO 120-900-NEXT */

                M_120_900_NEXT(); //GOTO
                return;

                /*" -965- END-IF. */
            }


            /*" -967- PERFORM 180-000-ENCERRA-V0COBERAPOL. */

            M_180_000_ENCERRA_V0COBERAPOL_SECTION();

            /*" -968- IF WNAO-ACHEI-HIS = 'S' */

            if (WS_AUXILIARES.WNAO_ACHEI_HIS == "S")
            {

                /*" -969- ADD 1 TO AC-ERRO-COBERAPOL */
                WS_AUXILIARES.AC_ERRO_COBERAPOL.Value = WS_AUXILIARES.AC_ERRO_COBERAPOL + 1;

                /*" -971- END-IF. */
            }


            /*" -973- PERFORM 210-000-MONTA-V0COBERAPOL. */

            M_210_000_MONTA_V0COBERAPOL_SECTION();

            /*" -975- PERFORM 330-000-INSERE-V0HISTSEGVG. */

            M_330_000_INSERE_V0HISTSEGVG_SECTION();

            /*" -977- PERFORM 360-000-UPDATE-V0SEGURAVG. */

            M_360_000_UPDATE_V0SEGURAVG_SECTION();

            /*" -979- PERFORM 390-000-UPDATE-V0MOVIMENTO. */

            M_390_000_UPDATE_V0MOVIMENTO_SECTION();

            /*" -981- PERFORM 420-000-UPDATE-V0PROPOSTAVA. */

            M_420_000_UPDATE_V0PROPOSTAVA_SECTION();

            /*" -982- IF (MNUM-APOLICE = 93010000890) */

            if ((MNUM_APOLICE == 93010000890))
            {

                /*" -983- PERFORM 430-000-UPDATE-CARENCIAS */

                M_430_000_UPDATE_CARENCIAS_SECTION();

                /*" -983- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM M_120_900_NEXT */

            M_120_900_NEXT();

        }

        [StopWatch]
        /*" M-120-900-NEXT */
        private void M_120_900_NEXT(bool isPerform = false)
        {
            /*" -987- PERFORM 100-000-FETCH-V1MOVIMENTO. */

            M_100_000_FETCH_V1MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-100-000-FETCH-V1MOVIMENTO-SECTION */
        private void M_100_000_FETCH_V1MOVIMENTO_SECTION()
        {
            /*" -997- MOVE '121-000-FETCH-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("121-000-FETCH-V1MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -999- MOVE '121' TO WNR-EXEC-SQL */
            _.Move("121", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1077- PERFORM M_100_000_FETCH_V1MOVIMENTO_DB_FETCH_1 */

            M_100_000_FETCH_V1MOVIMENTO_DB_FETCH_1();

            /*" -1080- IF (SQLCODE EQUAL 100) */

            if ((DB.SQLCODE == 100))
            {

                /*" -1081- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", WS_AUXILIARES.WFIM_MOVIMENTO);

                /*" -1081- PERFORM M_100_000_FETCH_V1MOVIMENTO_DB_CLOSE_1 */

                M_100_000_FETCH_V1MOVIMENTO_DB_CLOSE_1();

                /*" -1083- GO TO 100-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/ //GOTO
                return;

                /*" -1085- END-IF */
            }


            /*" -1087- ADD 1 TO AC-GRAVA-LID */
            WS_AUXILIARES.AC_GRAVA_LID.Value = WS_AUXILIARES.AC_GRAVA_LID + 1;

            /*" -1089- PERFORM R7777-CONS-MODALIDADE-APOL */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -1093- IF ((MPRM-VG-ATU EQUAL ZEROS) AND (MPRM-AP-ATU EQUAL ZEROS)) OR ((MIMP-MORNATU-ATU EQUAL ZEROS) AND (MIMP-MORACID-ATU EQUAL ZEROS)) */

            if (((MPRM_VG_ATU == 00) && (MPRM_AP_ATU == 00)) || ((MIMP_MORNATU_ATU == 00) && (MIMP_MORACID_ATU == 00)))
            {

                /*" -1095- PERFORM 600-000-VER-ORIG-PRODUTO */

                M_600_000_VER_ORIG_PRODUTO_SECTION();

                /*" -1097- IF WS-EOF-PRODUTOS-VG EQUAL 1 AND MNUM-APOLICE NOT EQUAL 109300000678 */

                if (WS_EOF_PRODUTOS_VG == 1 && MNUM_APOLICE != 109300000678)
                {

                    /*" -1099- IF MNUM-APOLICE EQUAL 97020000783 OR 108100000045 OR 109300000004 OR 108100000028 OR 109300001311 */

                    if (MNUM_APOLICE.In("97020000783", "108100000045", "109300000004", "108100000028", "109300001311"))
                    {

                        /*" -1100- PERFORM 390-000-UPDATE-V0MOVIMENTO */

                        M_390_000_UPDATE_V0MOVIMENTO_SECTION();

                        /*" -1101- GO TO 100-000-FETCH-V1MOVIMENTO */
                        new Task(() => M_100_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1102- ELSE */
                    }
                    else
                    {


                        /*" -1104- DISPLAY 'VG0030B - SEM PRODUTO VG ' MNUM-APOLICE ' ' WCOD-SUBGRUPO-EMP */

                        $"VG0030B - SEM PRODUTO VG {MNUM_APOLICE} {WCOD_SUBGRUPO_EMP}"
                        .Display();

                        /*" -1105- ADD 1 TO AC-GRAVA-VG-PRODUTO */
                        WS_AUXILIARES.AC_GRAVA_VG_PRODUTO.Value = WS_AUXILIARES.AC_GRAVA_VG_PRODUTO + 1;

                        /*" -1106- GO TO 100-000-FETCH-V1MOVIMENTO */
                        new Task(() => M_100_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1107- END-IF */
                    }


                    /*" -1109- END-IF */
                }


                /*" -1112- IF WORIG-PRODUTO EQUAL ( 'ESPEC' OR 'EMPRE' OR 'GLOBAL' OR 'ESPE1' OR 'ESPE2' OR 'ESPE3' ) OR MNUM-APOLICE EQUAL 109300000678 */

                if (WORIG_PRODUTO.In("ESPEC", "EMPRE", "GLOBAL", "ESPE1", "ESPE2", "ESPE3") || MNUM_APOLICE == 109300000678)
                {

                    /*" -1113- PERFORM 610-000-CONSULTA-APOLCOBER */

                    M_610_000_CONSULTA_APOLCOBER_SECTION();

                    /*" -1114- ELSE */
                }
                else
                {


                    /*" -1115- PERFORM 630-000-CONSULTA-HISCOBER */

                    M_630_000_CONSULTA_HISCOBER_SECTION();

                    /*" -1116- END-IF */
                }


                /*" -1118- END-IF */
            }


            /*" -1129- IF (MPRM-VG-ATU EQUAL ZEROS) AND (MPRM-AP-ATU EQUAL ZEROS) */

            if ((MPRM_VG_ATU == 00) && (MPRM_AP_ATU == 00))
            {

                /*" -1131- DISPLAY 'VG0030B - PREMIOS ZERADOS II ' MNUM-APOLICE ' ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0030B - PREMIOS ZERADOS II {MNUM_APOLICE} {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1132- ADD 1 TO AC-GRAVA-PRM-ZEROS */
                WS_AUXILIARES.AC_GRAVA_PRM_ZEROS.Value = WS_AUXILIARES.AC_GRAVA_PRM_ZEROS + 1;

                /*" -1134- GO TO 100-000-FETCH-V1MOVIMENTO */
                new Task(() => M_100_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1136- END-IF */
            }


            /*" -1138- IF (MIMP-MORNATU-ATU EQUAL ZEROS) AND (MIMP-MORACID-ATU EQUAL ZEROS) */

            if ((MIMP_MORNATU_ATU == 00) && (MIMP_MORACID_ATU == 00))
            {

                /*" -1140- DISPLAY 'VG0030B - IS ZERADAS ' MNUM-APOLICE ' ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0030B - IS ZERADAS {MNUM_APOLICE} {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1141- ADD 1 TO AC-GRAVA-IMP-ZEROS */
                WS_AUXILIARES.AC_GRAVA_IMP_ZEROS.Value = WS_AUXILIARES.AC_GRAVA_IMP_ZEROS + 1;

                /*" -1142- GO TO 100-000-FETCH-V1MOVIMENTO */
                new Task(() => M_100_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1144- END-IF */
            }


            /*" -1144- . */

        }

        [StopWatch]
        /*" M-100-000-FETCH-V1MOVIMENTO-DB-FETCH-1 */
        public void M_100_000_FETCH_V1MOVIMENTO_DB_FETCH_1()
        {
            /*" -1077- EXEC SQL FETCH TMOVIMENTO INTO :MNUM-APOLICE, :MCOD-SUBGRUPO, :MCOD-FONTE, :MNUM-PROPOSTA, :MTIPO-SEGURADO, :MNUM-CERTIFICADO, :MDAC-CERTIFICADO, :MTIPO-INCLUSAO, :MCOD-CLIENTE, :MCOD-AGENCIADOR, :MCOD-CORRETOR, :MCOD-PLANOVGAP, :MCOD-PLANOAP, :MFAIXA, :MAUTOR-AUM-AUTOMAT, :MTIPO-BENEFICIARIO, :MPERI-PAGAMENTO, :MPERI-RENOVACAO, :MCOD-OCUPACAO, :MESTADO-CIVIL, :MIDE-SEXO, :MCOD-PROFISSAO, :MNATURALIDADE, :MOCORR-ENDERECO, :MOCORR-END-COBRAN, :MBCO-COBRANCA, :MAGE-COBRANCA, :MDAC-COBRANCA, :MNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, :MVAL-SALARIO, :MTIPO-SALARIO, :MTIPO-PLANO, :MPCT-CONJUGE-VG, :MPCT-CONJUGE-AP, :MQTD-SAL-MORNATU, :MQTD-SAL-MORACID, :MQTD-SAL-INVPERM, :MTAXA-AP-MORACID, :MTAXA-AP-INVPERM, :MTAXA-AP-AMDS, :MTAXA-AP-DH, :MTAXA-AP-DIT, :MTAXA-VG, :MIMP-MORNATU-ANT, :MIMP-MORNATU-ATU, :MIMP-MORACID-ANT, :MIMP-MORACID-ATU, :MIMP-INVPERM-ANT, :MIMP-INVPERM-ATU, :MIMP-AMDS-ANT, :MIMP-AMDS-ATU, :MIMP-DH-ANT, :MIMP-DH-ATU, :MIMP-DIT-ANT, :MIMP-DIT-ATU, :MPRM-VG-ANT, :MPRM-VG-ATU, :MPRM-AP-ANT, :MPRM-AP-ATU, :MCOD-OPERACAO, :MDATA-OPERACAO, :COD-SUBGRUPO-TRANS, :MSIT-REGISTRO, :MCOD-USUARIO, :MDATA-AVERBACAO:WDATA-AVERBACAO, :MDATA-ADMISSAO:WDATA-ADMISSAO, :MDATA-INCLUSAO:WDATA-INCLUSAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MDATA-FATURA:WDATA-FATURA, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :SDATA-MOVIMENTO:WDATA-MOVIMENTO1, :MCOD-EMPRESA:WCOD-EMPRESA, :V0APOL-RAMO, :V0APOL-MODALIDA END-EXEC */

            if (TMOVIMENTO.Fetch())
            {
                _.Move(TMOVIMENTO.MNUM_APOLICE, MNUM_APOLICE);
                _.Move(TMOVIMENTO.MCOD_SUBGRUPO, MCOD_SUBGRUPO);
                _.Move(TMOVIMENTO.MCOD_FONTE, MCOD_FONTE);
                _.Move(TMOVIMENTO.MNUM_PROPOSTA, MNUM_PROPOSTA);
                _.Move(TMOVIMENTO.MTIPO_SEGURADO, MTIPO_SEGURADO);
                _.Move(TMOVIMENTO.MNUM_CERTIFICADO, MNUM_CERTIFICADO);
                _.Move(TMOVIMENTO.MDAC_CERTIFICADO, MDAC_CERTIFICADO);
                _.Move(TMOVIMENTO.MTIPO_INCLUSAO, MTIPO_INCLUSAO);
                _.Move(TMOVIMENTO.MCOD_CLIENTE, MCOD_CLIENTE);
                _.Move(TMOVIMENTO.MCOD_AGENCIADOR, MCOD_AGENCIADOR);
                _.Move(TMOVIMENTO.MCOD_CORRETOR, MCOD_CORRETOR);
                _.Move(TMOVIMENTO.MCOD_PLANOVGAP, MCOD_PLANOVGAP);
                _.Move(TMOVIMENTO.MCOD_PLANOAP, MCOD_PLANOAP);
                _.Move(TMOVIMENTO.MFAIXA, MFAIXA);
                _.Move(TMOVIMENTO.MAUTOR_AUM_AUTOMAT, MAUTOR_AUM_AUTOMAT);
                _.Move(TMOVIMENTO.MTIPO_BENEFICIARIO, MTIPO_BENEFICIARIO);
                _.Move(TMOVIMENTO.MPERI_PAGAMENTO, MPERI_PAGAMENTO);
                _.Move(TMOVIMENTO.MPERI_RENOVACAO, MPERI_RENOVACAO);
                _.Move(TMOVIMENTO.MCOD_OCUPACAO, MCOD_OCUPACAO);
                _.Move(TMOVIMENTO.MESTADO_CIVIL, MESTADO_CIVIL);
                _.Move(TMOVIMENTO.MIDE_SEXO, MIDE_SEXO);
                _.Move(TMOVIMENTO.MCOD_PROFISSAO, MCOD_PROFISSAO);
                _.Move(TMOVIMENTO.MNATURALIDADE, MNATURALIDADE);
                _.Move(TMOVIMENTO.MOCORR_ENDERECO, MOCORR_ENDERECO);
                _.Move(TMOVIMENTO.MOCORR_END_COBRAN, MOCORR_END_COBRAN);
                _.Move(TMOVIMENTO.MBCO_COBRANCA, MBCO_COBRANCA);
                _.Move(TMOVIMENTO.MAGE_COBRANCA, MAGE_COBRANCA);
                _.Move(TMOVIMENTO.MDAC_COBRANCA, MDAC_COBRANCA);
                _.Move(TMOVIMENTO.MNUM_MATRICULA, MNUM_MATRICULA);
                _.Move(TMOVIMENTO.MNUM_CTA_CORRENTE, MNUM_CTA_CORRENTE);
                _.Move(TMOVIMENTO.MDAC_CTA_CORRENTE, MDAC_CTA_CORRENTE);
                _.Move(TMOVIMENTO.MVAL_SALARIO, MVAL_SALARIO);
                _.Move(TMOVIMENTO.MTIPO_SALARIO, MTIPO_SALARIO);
                _.Move(TMOVIMENTO.MTIPO_PLANO, MTIPO_PLANO);
                _.Move(TMOVIMENTO.MPCT_CONJUGE_VG, MPCT_CONJUGE_VG);
                _.Move(TMOVIMENTO.MPCT_CONJUGE_AP, MPCT_CONJUGE_AP);
                _.Move(TMOVIMENTO.MQTD_SAL_MORNATU, MQTD_SAL_MORNATU);
                _.Move(TMOVIMENTO.MQTD_SAL_MORACID, MQTD_SAL_MORACID);
                _.Move(TMOVIMENTO.MQTD_SAL_INVPERM, MQTD_SAL_INVPERM);
                _.Move(TMOVIMENTO.MTAXA_AP_MORACID, MTAXA_AP_MORACID);
                _.Move(TMOVIMENTO.MTAXA_AP_INVPERM, MTAXA_AP_INVPERM);
                _.Move(TMOVIMENTO.MTAXA_AP_AMDS, MTAXA_AP_AMDS);
                _.Move(TMOVIMENTO.MTAXA_AP_DH, MTAXA_AP_DH);
                _.Move(TMOVIMENTO.MTAXA_AP_DIT, MTAXA_AP_DIT);
                _.Move(TMOVIMENTO.MTAXA_VG, MTAXA_VG);
                _.Move(TMOVIMENTO.MIMP_MORNATU_ANT, MIMP_MORNATU_ANT);
                _.Move(TMOVIMENTO.MIMP_MORNATU_ATU, MIMP_MORNATU_ATU);
                _.Move(TMOVIMENTO.MIMP_MORACID_ANT, MIMP_MORACID_ANT);
                _.Move(TMOVIMENTO.MIMP_MORACID_ATU, MIMP_MORACID_ATU);
                _.Move(TMOVIMENTO.MIMP_INVPERM_ANT, MIMP_INVPERM_ANT);
                _.Move(TMOVIMENTO.MIMP_INVPERM_ATU, MIMP_INVPERM_ATU);
                _.Move(TMOVIMENTO.MIMP_AMDS_ANT, MIMP_AMDS_ANT);
                _.Move(TMOVIMENTO.MIMP_AMDS_ATU, MIMP_AMDS_ATU);
                _.Move(TMOVIMENTO.MIMP_DH_ANT, MIMP_DH_ANT);
                _.Move(TMOVIMENTO.MIMP_DH_ATU, MIMP_DH_ATU);
                _.Move(TMOVIMENTO.MIMP_DIT_ANT, MIMP_DIT_ANT);
                _.Move(TMOVIMENTO.MIMP_DIT_ATU, MIMP_DIT_ATU);
                _.Move(TMOVIMENTO.MPRM_VG_ANT, MPRM_VG_ANT);
                _.Move(TMOVIMENTO.MPRM_VG_ATU, MPRM_VG_ATU);
                _.Move(TMOVIMENTO.MPRM_AP_ANT, MPRM_AP_ANT);
                _.Move(TMOVIMENTO.MPRM_AP_ATU, MPRM_AP_ATU);
                _.Move(TMOVIMENTO.MCOD_OPERACAO, MCOD_OPERACAO);
                _.Move(TMOVIMENTO.MDATA_OPERACAO, MDATA_OPERACAO);
                _.Move(TMOVIMENTO.COD_SUBGRUPO_TRANS, COD_SUBGRUPO_TRANS);
                _.Move(TMOVIMENTO.MSIT_REGISTRO, MSIT_REGISTRO);
                _.Move(TMOVIMENTO.MCOD_USUARIO, MCOD_USUARIO);
                _.Move(TMOVIMENTO.MDATA_AVERBACAO, MDATA_AVERBACAO);
                _.Move(TMOVIMENTO.WDATA_AVERBACAO, WDATA_AVERBACAO);
                _.Move(TMOVIMENTO.MDATA_ADMISSAO, MDATA_ADMISSAO);
                _.Move(TMOVIMENTO.WDATA_ADMISSAO, WDATA_ADMISSAO);
                _.Move(TMOVIMENTO.MDATA_INCLUSAO, MDATA_INCLUSAO);
                _.Move(TMOVIMENTO.WDATA_INCLUSAO, WDATA_INCLUSAO);
                _.Move(TMOVIMENTO.MDATA_NASCIMENTO, MDATA_NASCIMENTO);
                _.Move(TMOVIMENTO.WDATA_NASCIMENTO, WDATA_NASCIMENTO);
                _.Move(TMOVIMENTO.MDATA_FATURA, MDATA_FATURA);
                _.Move(TMOVIMENTO.WDATA_FATURA, WDATA_FATURA);
                _.Move(TMOVIMENTO.MDATA_REFERENCIA, MDATA_REFERENCIA);
                _.Move(TMOVIMENTO.WDATA_REFERENCIA, WDATA_REFERENCIA);
                _.Move(TMOVIMENTO.MDATA_MOVIMENTO, MDATA_MOVIMENTO);
                _.Move(TMOVIMENTO.WDATA_MOVIMENTO, WDATA_MOVIMENTO);
                _.Move(TMOVIMENTO.SDATA_MOVIMENTO, SDATA_MOVIMENTO);
                _.Move(TMOVIMENTO.WDATA_MOVIMENTO1, WDATA_MOVIMENTO1);
                _.Move(TMOVIMENTO.MCOD_EMPRESA, MCOD_EMPRESA);
                _.Move(TMOVIMENTO.WCOD_EMPRESA, WCOD_EMPRESA);
                _.Move(TMOVIMENTO.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(TMOVIMENTO.V0APOL_MODALIDA, V0APOL_MODALIDA);
            }

        }

        [StopWatch]
        /*" M-100-000-FETCH-V1MOVIMENTO-DB-CLOSE-1 */
        public void M_100_000_FETCH_V1MOVIMENTO_DB_CLOSE_1()
        {
            /*" -1081- EXEC SQL CLOSE TMOVIMENTO END-EXEC */

            TMOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_100_999_EXIT*/

        [StopWatch]
        /*" M-150-000-SELECT-V1SEGURAVG-SECTION */
        private void M_150_000_SELECT_V1SEGURAVG_SECTION()
        {
            /*" -1154- MOVE '150-000-SELECT-V1SEGURAVG' TO PARAGRAFO */
            _.Move("150-000-SELECT-V1SEGURAVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1156- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1158- MOVE 'S' TO WS-TEM-SEGURADO */
            _.Move("S", WS_TEM_SEGURADO);

            /*" -1168- PERFORM M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -1171- IF (SQLCODE EQUAL +100) */

            if ((DB.SQLCODE == +100))
            {

                /*" -1173- DISPLAY 'VG0030B - NAO EXISTE OCORRENCIA DE HISTORICO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0030B - NAO EXISTE OCORRENCIA DE HISTORICO {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1175- MOVE 'N' TO WS-TEM-SEGURADO */
                _.Move("N", WS_TEM_SEGURADO);

                /*" -1176- ELSE */
            }
            else
            {


                /*" -1177- COMPUTE HOCORR-HISTORICO = SOCORR-HISTORICO + 1 */
                HOCORR_HISTORICO.Value = SOCORR_HISTORICO + 1;

                /*" -1177- END-IF. */
            }


        }

        [StopWatch]
        /*" M-150-000-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -1168- EXEC SQL SELECT OCORR_HISTORICO, NUM_ITEM, SIT_REGISTRO INTO :SOCORR-HISTORICO, :SNUM-ITEM, :SSIT-REGISTRO FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1 = new M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            var executed_1 = M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1.Execute(m_150_000_SELECT_V1SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SOCORR_HISTORICO, SOCORR_HISTORICO);
                _.Move(executed_1.SNUM_ITEM, SNUM_ITEM);
                _.Move(executed_1.SSIT_REGISTRO, SSIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-160-000-SELECT-V0MOVIMENTO-SECTION */
        private void M_160_000_SELECT_V0MOVIMENTO_SECTION()
        {
            /*" -1188- MOVE '160-000-SELECT-V0MOVIMENTO' TO PARAGRAFO */
            _.Move("160-000-SELECT-V0MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1190- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1208- MOVE 'N' TO WTEM-MOVIMENTO */
            _.Move("N", WS_AUXILIARES.WTEM_MOVIMENTO);

            /*" -1220- PERFORM M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1 */

            M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1();

            /*" -1223- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1224- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1225- MOVE 'N' TO WTEM-MOVIMENTO */
                    _.Move("N", WS_AUXILIARES.WTEM_MOVIMENTO);

                    /*" -1226- ELSE */
                }
                else
                {


                    /*" -1228- DISPLAY ' ERRO NO SELECT DO V0MOVIMENTO ' MNUM-CERTIFICADO '   ' SQLCODE */

                    $" ERRO NO SELECT DO V0MOVIMENTO {MNUM_CERTIFICADO}   {DB.SQLCODE}"
                    .Display();

                    /*" -1229- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1230- ELSE */
                }

            }
            else
            {


                /*" -1232- MOVE 'S' TO WTEM-MOVIMENTO. */
                _.Move("S", WS_AUXILIARES.WTEM_MOVIMENTO);
            }


            /*" -1233- IF WHOST-COUNT-MOV GREATER ZEROS */

            if (WHOST_COUNT_MOV > 00)
            {

                /*" -1234- MOVE 'S' TO WTEM-MOVIMENTO */
                _.Move("S", WS_AUXILIARES.WTEM_MOVIMENTO);

                /*" -1235- ELSE */
            }
            else
            {


                /*" -1236- MOVE 'N' TO WTEM-MOVIMENTO */
                _.Move("N", WS_AUXILIARES.WTEM_MOVIMENTO);

                /*" -1236- END-IF. */
            }


        }

        [StopWatch]
        /*" M-160-000-SELECT-V0MOVIMENTO-DB-SELECT-1 */
        public void M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1()
        {
            /*" -1220- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-COUNT-MOV FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND DATA_INCLUSAO IS NULL AND ((COD_OPERACAO < 0300) OR (COD_OPERACAO > 0499 AND COD_OPERACAO < 0800)) AND DATA_MOVIMENTO < '9999-12-31' AND SIT_REGISTRO <> '1' WITH UR END-EXEC. */

            var m_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1 = new M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1.Execute(m_160_000_SELECT_V0MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT_MOV, WHOST_COUNT_MOV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-180-000-ENCERRA-V0COBERAPOL-SECTION */
        private void M_180_000_ENCERRA_V0COBERAPOL_SECTION()
        {
            /*" -1246- MOVE '180-000-ENCERRA-V0COBERAPOL' TO PARAGRAFO */
            _.Move("180-000-ENCERRA-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1248- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1250- MOVE 'N' TO WNAO-ACHEI-HIS. */
            _.Move("N", WS_AUXILIARES.WNAO_ACHEI_HIS);

            /*" -1252- PERFORM 190-000-BUSCA-V0COBERAPOL. */

            M_190_000_BUSCA_V0COBERAPOL_SECTION();

            /*" -1253- IF DATA-INIVIGENCIA-C GREATER SDATA-MOVIMENTO */

            if (DATA_INIVIGENCIA_C > SDATA_MOVIMENTO)
            {

                /*" -1254- MOVE V1SISTEMA-DTMOVABE-1 TO SDATA-MOVIMENTO */
                _.Move(V1SISTEMA_DTMOVABE_1, SDATA_MOVIMENTO);

                /*" -1255- MOVE V1SISTEMA-DTMOVABE TO MDATA-MOVIMENTO */
                _.Move(V1SISTEMA_DTMOVABE, MDATA_MOVIMENTO);

                /*" -1257- END-IF. */
            }


            /*" -1267- PERFORM M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1 */

            M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1();

            /*" -1270- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1271- MOVE 'S' TO WNAO-ACHEI-HIS */
                _.Move("S", WS_AUXILIARES.WNAO_ACHEI_HIS);

                /*" -1272- DISPLAY 'VG0030B - NAO EXISTE OCORRENCIA DE HISTORICO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO. */

                $"VG0030B - NAO EXISTE OCORRENCIA DE HISTORICO {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();
            }


        }

        [StopWatch]
        /*" M-180-000-ENCERRA-V0COBERAPOL-DB-UPDATE-1 */
        public void M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -1267- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET DATA_TERVIGENCIA = :SDATA-MOVIMENTO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :MNUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :SNUM-ITEM AND OCORHIST = :SOCORR-HISTORICO END-EXEC. */

            var m_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1 = new M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1()
            {
                SDATA_MOVIMENTO = SDATA_MOVIMENTO.ToString(),
                SOCORR_HISTORICO = SOCORR_HISTORICO.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1.Execute(m_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-190-000-BUSCA-V0COBERAPOL-SECTION */
        private void M_190_000_BUSCA_V0COBERAPOL_SECTION()
        {
            /*" -1284- MOVE '190-000-BUSCA-V0COBERAPOL' TO PARAGRAFO */
            _.Move("190-000-BUSCA-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1286- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1288- MOVE 'N' TO WNAO-ACHEI-HIS. */
            _.Move("N", WS_AUXILIARES.WNAO_ACHEI_HIS);

            /*" -1298- PERFORM M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1 */

            M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1();

            /*" -1301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1304- DISPLAY '190 - ERRO BUSCA SEGUROS.V0COBERAPOL ' MNUM-CERTIFICADO ' ' MNUM-APOLICE ' ' SNUM-ITEM ' ' SOCORR-HISTORICO */

                $"190 - ERRO BUSCA SEGUROS.V0COBERAPOL {MNUM_CERTIFICADO} {MNUM_APOLICE} {SNUM_ITEM} {SOCORR_HISTORICO}"
                .Display();

                /*" -1305- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1305- END-IF. */
            }


        }

        [StopWatch]
        /*" M-190-000-BUSCA-V0COBERAPOL-DB-SELECT-1 */
        public void M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -1298- EXEC SQL SELECT DATA_INIVIGENCIA INTO :DATA-INIVIGENCIA-C FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :MNUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :SNUM-ITEM AND OCORHIST = :SOCORR-HISTORICO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC. */

            var m_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1 = new M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                SOCORR_HISTORICO = SOCORR_HISTORICO.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1.Execute(m_190_000_BUSCA_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DATA_INIVIGENCIA_C, DATA_INIVIGENCIA_C);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/

        [StopWatch]
        /*" M-210-000-MONTA-V0COBERAPOL-SECTION */
        private void M_210_000_MONTA_V0COBERAPOL_SECTION()
        {
            /*" -1316- MOVE '210-000-MONTA-V0COBERAPOL' TO PARAGRAFO. */
            _.Move("210-000-MONTA-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1318- IF WAPOLICE-ATU NOT EQUAL WAPOLICE-ANT */

            if (WS_AUXILIARES.WAPOLICE_ATU != WS_AUXILIARES.WAPOLICE_ANT)
            {

                /*" -1321- MOVE WAPOLICE-ATU TO WAPOLICE-ANT. */
                _.Move(WS_AUXILIARES.WAPOLICE_ATU, WS_AUXILIARES.WAPOLICE_ANT);
            }


            /*" -1323- MOVE MNUM-APOLICE TO VGNUM-APOLICE */
            _.Move(MNUM_APOLICE, VGNUM_APOLICE);

            /*" -1324- MOVE 0 TO VGNRENDOS */
            _.Move(0, VGNRENDOS);

            /*" -1325- MOVE SNUM-ITEM TO VGNUM-ITEM. */
            _.Move(SNUM_ITEM, VGNUM_ITEM);

            /*" -1325- MOVE 0 TO VGPCT-COBERTURA1. */
            _.Move(0, VGPCT_COBERTURA1);

            /*" -0- FLUXCONTROL_PERFORM M_210_010_VERIFICA_PREMIO_VG */

            M_210_010_VERIFICA_PREMIO_VG();

        }

        [StopWatch]
        /*" M-210-010-VERIFICA-PREMIO-VG */
        private void M_210_010_VERIFICA_PREMIO_VG(bool isPerform = false)
        {
            /*" -1331- MOVE '210-010' TO WNR-EXEC-SQL-ANT */
            _.Move("210-010", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -1337- IF MIMP-MORNATU-ATU NOT EQUAL ZEROS OR (MIMP-MORNATU-ATU EQUAL ZEROS AND V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 AND MPRM-VG-ATU GREATER ZEROS) */

            if (MIMP_MORNATU_ATU != 00 || (MIMP_MORNATU_ATU == 00 && V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2 && MPRM_VG_ATU > 00))
            {

                /*" -1338- IF V0APOL-RAMO EQUAL V1PAR-RAMO-PST */

                if (V0APOL_RAMO == V1PAR_RAMO_PST)
                {

                    /*" -1339- MOVE V1PAR-RAMO-PST TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_PST, VGRAMOFR);

                    /*" -1340- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1342- END-IF */
                }


                /*" -1343- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG */

                if (V0APOL_RAMO == V1PAR_RAMO_VG)
                {

                    /*" -1344- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -1345- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1347- END-IF */
                }


                /*" -1348- IF V0APOL-RAMO EQUAL 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1349- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -1350- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1353- END-IF */
                }


                /*" -1355- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1359- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORNATU-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORNATU_ATU / DVLCRUZAD_IMP;

                /*" -1363- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-VG-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_VG_ATU / DVLCRUZAD_PRM;

                /*" -1366- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1368- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1371- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WS_AUXILIARES.WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1372- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1374- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1376- MOVE MDATA-MOVIMENTO TO VGDATA-TERVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_TERVIGENCIA);

                /*" -1378- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1383- PERFORM 400-000-PERCENTUAL1 */

                M_400_000_PERCENTUAL1_SECTION();

                /*" -1385- MOVE VGPCT-COBERTURA1 TO VGPCT-COBERTURA */
                _.Move(VGPCT_COBERTURA1, VGPCT_COBERTURA);

                /*" -1388- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1388- PERFORM 210-020-VERIFICA-PREMIO-AP. */

            M_210_020_VERIFICA_PREMIO_AP(true);

        }

        [StopWatch]
        /*" M-210-020-VERIFICA-PREMIO-AP */
        private void M_210_020_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -1392- MOVE '210-020' TO WNR-EXEC-SQL-ANT */
            _.Move("210-020", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -1394- IF MIMP-MORACID-ATU NOT EQUAL ZEROS */

            if (MIMP_MORACID_ATU != 00)
            {

                /*" -1398- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1399- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1401- MOVE 01 TO VGCOD-COBERTURA */
                _.Move(01, VGCOD_COBERTURA);

                /*" -1405- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORACID-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORACID_ATU / DVLCRUZAD_IMP;

                /*" -1409- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-AP-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_AP_ATU / DVLCRUZAD_PRM;

                /*" -1412- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1415- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1418- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WS_AUXILIARES.WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1419- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1421- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1423- MOVE MDATA-MOVIMENTO TO VGDATA-TERVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_TERVIGENCIA);

                /*" -1425- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1430- PERFORM 410-000-PERCENTUAL2 */

                M_410_000_PERCENTUAL2_SECTION();

                /*" -1431- IF VGPCT-COBERTURA2 EQUAL 0 */

                if (VGPCT_COBERTURA2 == 0)
                {

                    /*" -1433- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 */

                    if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
                    {

                        /*" -1435- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                        VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                        /*" -1437- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -1438- PERFORM 300-000-INSERE-V0COBERAPOL */

                        M_300_000_INSERE_V0COBERAPOL_SECTION();

                        /*" -1439- ELSE */
                    }
                    else
                    {


                        /*" -1441- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                        VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                        /*" -1443- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -1444- PERFORM 300-000-INSERE-V0COBERAPOL */

                        M_300_000_INSERE_V0COBERAPOL_SECTION();

                        /*" -1445- ELSE */
                    }

                }
                else
                {


                    /*" -1447- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                    VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                    /*" -1449- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                    _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                    /*" -1451- PERFORM 300-000-INSERE-V0COBERAPOL. */

                    M_300_000_INSERE_V0COBERAPOL_SECTION();
                }

            }


            /*" -1451- PERFORM 210-030-VERIFICA-INVPERM. */

            M_210_030_VERIFICA_INVPERM(true);

        }

        [StopWatch]
        /*" M-210-030-VERIFICA-INVPERM */
        private void M_210_030_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -1456- MOVE '210-030' TO WNR-EXEC-SQL-ANT */
            _.Move("210-030", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -1458- IF MIMP-INVPERM-ATU NOT EQUAL ZEROS */

            if (MIMP_INVPERM_ATU != 00)
            {

                /*" -1462- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1463- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1465- MOVE 02 TO VGCOD-COBERTURA */
                _.Move(02, VGCOD_COBERTURA);

                /*" -1469- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-INVPERM-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_INVPERM_ATU / DVLCRUZAD_IMP;

                /*" -1471- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1474- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1478- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1479- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1481- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1483- MOVE MDATA-MOVIMENTO TO VGDATA-TERVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_TERVIGENCIA);

                /*" -1485- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1486- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1488- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1488- PERFORM 210-040-VERIFICA-AMDS. */

            M_210_040_VERIFICA_AMDS(true);

        }

        [StopWatch]
        /*" M-210-040-VERIFICA-AMDS */
        private void M_210_040_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -1493- MOVE '210-040' TO WNR-EXEC-SQL-ANT */
            _.Move("210-040", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -1495- IF MIMP-AMDS-ATU NOT EQUAL ZEROS */

            if (MIMP_AMDS_ATU != 00)
            {

                /*" -1499- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1500- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1502- MOVE 03 TO VGCOD-COBERTURA */
                _.Move(03, VGCOD_COBERTURA);

                /*" -1506- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-AMDS-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_AMDS_ATU / DVLCRUZAD_IMP;

                /*" -1508- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1511- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1515- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1516- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1518- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1520- MOVE MDATA-MOVIMENTO TO VGDATA-TERVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_TERVIGENCIA);

                /*" -1522- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1523- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1525- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1525- PERFORM 210-050-VERIFICA-DH. */

            M_210_050_VERIFICA_DH(true);

        }

        [StopWatch]
        /*" M-210-050-VERIFICA-DH */
        private void M_210_050_VERIFICA_DH(bool isPerform = false)
        {
            /*" -1530- MOVE '210-050' TO WNR-EXEC-SQL-ANT */
            _.Move("210-050", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -1531- IF MIMP-DH-ATU NOT EQUAL ZEROS */

            if (MIMP_DH_ATU != 00)
            {

                /*" -1532- DISPLAY 'V1PAR-RAMO-AP      : ' V1PAR-RAMO-AP */
                _.Display($"V1PAR-RAMO-AP      : {V1PAR_RAMO_AP}");

                /*" -1533- DISPLAY 'V0APOL-MODALIDA    : ' V0APOL-MODALIDA */
                _.Display($"V0APOL-MODALIDA    : {V0APOL_MODALIDA}");

                /*" -1534- DISPLAY 'VGIMP-SEGURADA-IX 1: ' VGIMP-SEGURADA-IX */
                _.Display($"VGIMP-SEGURADA-IX 1: {VGIMP_SEGURADA_IX}");

                /*" -1535- DISPLAY 'MIMP-DH-ATU        : ' MIMP-DH-ATU */
                _.Display($"MIMP-DH-ATU        : {MIMP_DH_ATU}");

                /*" -1536- DISPLAY 'DVLCRUZAD-IMP      : ' DVLCRUZAD-IMP */
                _.Display($"DVLCRUZAD-IMP      : {DVLCRUZAD_IMP}");

                /*" -1540- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1541- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1543- MOVE 04 TO VGCOD-COBERTURA */
                _.Move(04, VGCOD_COBERTURA);

                /*" -1546- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DH-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DH_ATU / DVLCRUZAD_IMP;

                /*" -1548- DISPLAY 'VGIMP-SEGURADA-IX 2: ' VGIMP-SEGURADA-IX */
                _.Display($"VGIMP-SEGURADA-IX 2: {VGIMP_SEGURADA_IX}");

                /*" -1550- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1553- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1557- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1558- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1560- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1562- MOVE MDATA-MOVIMENTO TO VGDATA-TERVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_TERVIGENCIA);

                /*" -1564- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1565- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1567- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1567- PERFORM 210-060-VERIFICA-DIT. */

            M_210_060_VERIFICA_DIT(true);

        }

        [StopWatch]
        /*" M-210-060-VERIFICA-DIT */
        private void M_210_060_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -1572- MOVE '210-060' TO WNR-EXEC-SQL-ANT */
            _.Move("210-060", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -1574- IF MIMP-DIT-ATU NOT EQUAL ZEROS */

            if (MIMP_DIT_ATU != 00)
            {

                /*" -1578- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1579- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1581- MOVE 05 TO VGCOD-COBERTURA */
                _.Move(05, VGCOD_COBERTURA);

                /*" -1585- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DIT-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DIT_ATU / DVLCRUZAD_IMP;

                /*" -1587- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1590- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1594- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1595- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1597- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1599- MOVE MDATA-MOVIMENTO TO VGDATA-TERVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_TERVIGENCIA);

                /*" -1601- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1602- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1602- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-SECTION */
        private void M_300_000_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -1694- MOVE '300-000-INSERE-V0COBERAPOL' TO PARAGRAFO */
            _.Move("300-000-INSERE-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1696- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1698- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1700- PERFORM 310-000-SELECIONA-V0COBERAPOL */

            M_310_000_SELECIONA_V0COBERAPOL_SECTION();

            /*" -1721- PERFORM M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1 */

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -1724- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1725- MOVE SQLCODE TO WS-SQL-EDT */
                _.Move(DB.SQLCODE, WS_AUXILIARES.WS_SQL_EDT);

                /*" -1726- DISPLAY 'VG0030B - PROBLEMAS NA INCLUSAO V0COBERAPOL' */
                _.Display($"VG0030B - PROBLEMAS NA INCLUSAO V0COBERAPOL");

                /*" -1727- DISPLAY 'SQLCODE            : ' WS-SQL-EDT */
                _.Display($"SQLCODE            : {WS_AUXILIARES.WS_SQL_EDT}");

                /*" -1728- DISPLAY 'VGNUM-APOLICE      : ' VGNUM-APOLICE */
                _.Display($"VGNUM-APOLICE      : {VGNUM_APOLICE}");

                /*" -1729- DISPLAY 'VGNRENDOS          : ' VGNRENDOS */
                _.Display($"VGNRENDOS          : {VGNRENDOS}");

                /*" -1730- DISPLAY 'VGNUM-ITEM         : ' VGNUM-ITEM */
                _.Display($"VGNUM-ITEM         : {VGNUM_ITEM}");

                /*" -1731- DISPLAY 'HOCORR-HISTORICO   : ' MAX-OCORR-HIST */
                _.Display($"HOCORR-HISTORICO   : {MAX_OCORR_HIST}");

                /*" -1732- DISPLAY 'VGRAMOFR           : ' VGRAMOFR */
                _.Display($"VGRAMOFR           : {VGRAMOFR}");

                /*" -1733- DISPLAY 'VGMODALIFR         : ' VGMODALIFR */
                _.Display($"VGMODALIFR         : {VGMODALIFR}");

                /*" -1734- DISPLAY 'VGCOD-COBERTURA    : ' VGCOD-COBERTURA */
                _.Display($"VGCOD-COBERTURA    : {VGCOD_COBERTURA}");

                /*" -1735- DISPLAY 'VGIMP-SEGURADA-IX  : ' VGIMP-SEGURADA-IX */
                _.Display($"VGIMP-SEGURADA-IX  : {VGIMP_SEGURADA_IX}");

                /*" -1736- DISPLAY 'VGPRM-TARIFARIO-IX : ' VGPRM-TARIFARIO-IX */
                _.Display($"VGPRM-TARIFARIO-IX : {VGPRM_TARIFARIO_IX}");

                /*" -1737- DISPLAY 'VGIMP-SEGURADA-VAR : ' VGIMP-SEGURADA-VAR */
                _.Display($"VGIMP-SEGURADA-VAR : {VGIMP_SEGURADA_VAR}");

                /*" -1738- DISPLAY 'PRM-TARIFARIO-VAR  : ' PRM-TARIFARIO-VAR */
                _.Display($"PRM-TARIFARIO-VAR  : {PRM_TARIFARIO_VAR}");

                /*" -1739- DISPLAY 'VGPCT-COBERTURA    : ' VGPCT-COBERTURA */
                _.Display($"VGPCT-COBERTURA    : {VGPCT_COBERTURA}");

                /*" -1740- DISPLAY 'VGFATOR-MULTIPLICA : ' VGFATOR-MULTIPLICA */
                _.Display($"VGFATOR-MULTIPLICA : {VGFATOR_MULTIPLICA}");

                /*" -1741- DISPLAY 'VGDATA-INIVIGENCIA : ' VGDATA-INIVIGENCIA */
                _.Display($"VGDATA-INIVIGENCIA : {VGDATA_INIVIGENCIA}");

                /*" -1742- DISPLAY 'VGDATA-TERVIGENCIA : ' VGDATA-TERVIGENCIA */
                _.Display($"VGDATA-TERVIGENCIA : {VGDATA_TERVIGENCIA}");

                /*" -1743- DISPLAY 'MCOD-EMPRESA       : ' MCOD-EMPRESA */
                _.Display($"MCOD-EMPRESA       : {MCOD_EMPRESA}");

                /*" -1744- DISPLAY 'VGCOD-SITUACAO     : ' VGCOD-SITUACAO */
                _.Display($"VGCOD-SITUACAO     : {VGCOD_SITUACAO}");

                /*" -1745- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1745- END-IF. */
            }


        }

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -1721- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:VGNUM-APOLICE, :VGNRENDOS, :VGNUM-ITEM, :MAX-OCORR-HIST, :VGRAMOFR, :VGMODALIFR, :VGCOD-COBERTURA, :VGIMP-SEGURADA-IX, :VGPRM-TARIFARIO-IX, :VGIMP-SEGURADA-VAR, :PRM-TARIFARIO-VAR, :VGPCT-COBERTURA, :VGFATOR-MULTIPLICA, :VGDATA-INIVIGENCIA, :VGDATA-TERVIGENCIA, :MCOD-EMPRESA:WCOD-EMPRESA, CURRENT TIMESTAMP, :VGCOD-SITUACAO:VGCOD-SITUACAO-I) END-EXEC. */

            var m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                VGNUM_APOLICE = VGNUM_APOLICE.ToString(),
                VGNRENDOS = VGNRENDOS.ToString(),
                VGNUM_ITEM = VGNUM_ITEM.ToString(),
                MAX_OCORR_HIST = MAX_OCORR_HIST.ToString(),
                VGRAMOFR = VGRAMOFR.ToString(),
                VGMODALIFR = VGMODALIFR.ToString(),
                VGCOD_COBERTURA = VGCOD_COBERTURA.ToString(),
                VGIMP_SEGURADA_IX = VGIMP_SEGURADA_IX.ToString(),
                VGPRM_TARIFARIO_IX = VGPRM_TARIFARIO_IX.ToString(),
                VGIMP_SEGURADA_VAR = VGIMP_SEGURADA_VAR.ToString(),
                PRM_TARIFARIO_VAR = PRM_TARIFARIO_VAR.ToString(),
                VGPCT_COBERTURA = VGPCT_COBERTURA.ToString(),
                VGFATOR_MULTIPLICA = VGFATOR_MULTIPLICA.ToString(),
                VGDATA_INIVIGENCIA = VGDATA_INIVIGENCIA.ToString(),
                VGDATA_TERVIGENCIA = VGDATA_TERVIGENCIA.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                VGCOD_SITUACAO = VGCOD_SITUACAO.ToString(),
                VGCOD_SITUACAO_I = VGCOD_SITUACAO_I.ToString(),
            };

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-310-000-SELECIONA-V0COBERAPOL-SECTION */
        private void M_310_000_SELECIONA_V0COBERAPOL_SECTION()
        {
            /*" -1755- MOVE '310-000-SELECIONA-V0COBERAPOL' TO PARAGRAFO */
            _.Move("310-000-SELECIONA-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1757- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1765- PERFORM M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1 */

            M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1();

            /*" -1768- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1769- DISPLAY 'PROBLEMAS AO SELECIONAR V0COBERAPOL' */
                _.Display($"PROBLEMAS AO SELECIONAR V0COBERAPOL");

                /*" -1770- DISPLAY 'VGNUM-APOLICE      : ' VGNUM-APOLICE */
                _.Display($"VGNUM-APOLICE      : {VGNUM_APOLICE}");

                /*" -1771- DISPLAY 'VGNUM-ITEM         : ' VGNUM-ITEM */
                _.Display($"VGNUM-ITEM         : {VGNUM_ITEM}");

                /*" -1772- DISPLAY 'VGCOD-COBERTURA    : ' VGCOD-COBERTURA */
                _.Display($"VGCOD-COBERTURA    : {VGCOD_COBERTURA}");

                /*" -1773- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1773- END-IF. */
            }


        }

        [StopWatch]
        /*" M-310-000-SELECIONA-V0COBERAPOL-DB-SELECT-1 */
        public void M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -1765- EXEC SQL SELECT VALUE (MAX(OCORHIST),0) + 1 INTO :MAX-OCORR-HIST FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :VGNUM-APOLICE AND NUM_ITEM = :VGNUM-ITEM AND COD_COBERTURA = :VGCOD-COBERTURA WITH UR END-EXEC */

            var m_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1 = new M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                VGCOD_COBERTURA = VGCOD_COBERTURA.ToString(),
                VGNUM_APOLICE = VGNUM_APOLICE.ToString(),
                VGNUM_ITEM = VGNUM_ITEM.ToString(),
            };

            var executed_1 = M_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1.Execute(m_310_000_SELECIONA_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MAX_OCORR_HIST, MAX_OCORR_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_999_EXIT*/

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-SECTION */
        private void M_330_000_INSERE_V0HISTSEGVG_SECTION()
        {
            /*" -1782- MOVE '330-000-INCLUI-V0HISTSEGVG' TO PARAGRAFO */
            _.Move("330-000-INCLUI-V0HISTSEGVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1784- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1785- ACCEPT WHORA-OPERACAO-1 FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUXILIARES.WHORA_OPERACAO_1);

            /*" -1786- MOVE WHORA-OPERACAO-2 TO WHORA-OPERACAO-R */
            _.Move(WS_AUXILIARES.WHORA_PER_X.WHORA_OPERACAO_2, WS_AUXILIARES.WHORA_OPERACAO_R);

            /*" -1787- MOVE WHORA-HORA-W TO WHORA-HORA */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_HORA_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_HORA);

            /*" -1788- MOVE WHORA-MINU-W TO WHORA-MINU */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_MINU_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_MINU);

            /*" -1789- MOVE WHORA-SEGU-W TO WHORA-SEGU */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_SEGU_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_SEGU);

            /*" -1790- MOVE WHORA-OPERACAO-WORK-R TO HHORA-OPERACAO */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO_WORK_R, HHORA_OPERACAO);

            /*" -1792- MOVE COD-SUBGRUPO-TRANS TO HCOD-SUBGRUP-TRANS. */
            _.Move(COD_SUBGRUPO_TRANS, HCOD_SUBGRUP_TRANS);

            /*" -1794- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1811- PERFORM M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1 */

            M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1();

            /*" -1814- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1815- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1816- DISPLAY 'NUM APOLICE  :' MNUM-APOLICE */
                    _.Display($"NUM APOLICE  :{MNUM_APOLICE}");

                    /*" -1817- DISPLAY 'COD SUBGRUPO :' MCOD-SUBGRUPO */
                    _.Display($"COD SUBGRUPO :{MCOD_SUBGRUPO}");

                    /*" -1818- DISPLAY 'NUM ITEM     :' SNUM-ITEM */
                    _.Display($"NUM ITEM     :{SNUM_ITEM}");

                    /*" -1819- ELSE */
                }
                else
                {


                    /*" -1822- DISPLAY 'VG0030B - PROBLEMAS NA INCLUSAO V0HISTSEGVG ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' SNUM-ITEM */

                    $"VG0030B - PROBLEMAS NA INCLUSAO V0HISTSEGVG {MNUM_APOLICE} {MCOD_SUBGRUPO} {SNUM_ITEM}"
                    .Display();

                    /*" -1824- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1824- ADD 1 TO AC-GRAVA-HIS. */
            WS_AUXILIARES.AC_GRAVA_HIS.Value = WS_AUXILIARES.AC_GRAVA_HIS + 1;

        }

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-DB-INSERT-1 */
        public void M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1()
        {
            /*" -1811- EXEC SQL INSERT INTO SEGUROS.V0HISTSEGVG VALUES (:MNUM-APOLICE, :MCOD-SUBGRUPO, :SNUM-ITEM, :MCOD-OPERACAO, :V1SISTEMA-DTMOVABE, :HHORA-OPERACAO, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :HOCORR-HISTORICO, :HCOD-SUBGRUP-TRANS, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MCOD-USUARIO, :MCOD-EMPRESA:WCOD-EMPRESA, :V1EN-COD-MOEDA-IMP:WCOD-MOEDA, :V1EN-COD-MOEDA-PRM:WCOD-MOEDA) END-EXEC. */

            var m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1 = new M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                HHORA_OPERACAO = HHORA_OPERACAO.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                WDATA_MOVIMENTO = WDATA_MOVIMENTO.ToString(),
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                HCOD_SUBGRUP_TRANS = HCOD_SUBGRUP_TRANS.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                WDATA_REFERENCIA = WDATA_REFERENCIA.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                V1EN_COD_MOEDA_IMP = V1EN_COD_MOEDA_IMP.ToString(),
                WCOD_MOEDA = WCOD_MOEDA.ToString(),
                V1EN_COD_MOEDA_PRM = V1EN_COD_MOEDA_PRM.ToString(),
            };

            M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1.Execute(m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_330_999_EXIT*/

        [StopWatch]
        /*" M-360-000-UPDATE-V0SEGURAVG-SECTION */
        private void M_360_000_UPDATE_V0SEGURAVG_SECTION()
        {
            /*" -1835- MOVE '360-000-UPDATE-V0SEGURAVG' TO PARAGRAFO */
            _.Move("360-000-UPDATE-V0SEGURAVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1837- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1845- PERFORM M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1 */

            M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1();

            /*" -1848- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1850- DISPLAY 'VG0030B - PROBLEMAS ALTERACAO V0SEGURAVG  ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0030B - PROBLEMAS ALTERACAO V0SEGURAVG  {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1852- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1852- ADD 1 TO AC-GRAVA-SEG. */
            WS_AUXILIARES.AC_GRAVA_SEG.Value = WS_AUXILIARES.AC_GRAVA_SEG + 1;

        }

        [StopWatch]
        /*" M-360-000-UPDATE-V0SEGURAVG-DB-UPDATE-1 */
        public void M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1()
        {
            /*" -1845- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET SIT_REGISTRO = '2' , OCORR_HISTORICO = :HOCORR-HISTORICO WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1 = new M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1()
            {
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            M_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1.Execute(m_360_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-SECTION */
        private void M_390_000_UPDATE_V0MOVIMENTO_SECTION()
        {
            /*" -1862- MOVE '390-000-UPDATE-V0MOVIMENTO' TO PARAGRAFO */
            _.Move("390-000-UPDATE-V0MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1864- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1871- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1 */

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1();

            /*" -1874- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1876- DISPLAY 'VG0030B - NAO EXISTE MOVIMENTO PARA ' MCOD-FONTE ' ' MNUM-PROPOSTA */

                $"VG0030B - NAO EXISTE MOVIMENTO PARA {MCOD_FONTE} {MNUM_PROPOSTA}"
                .Display();

                /*" -1877- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1879- END-IF. */
            }


            /*" -1879- ADD 1 TO AC-GRAVA-MOV. */
            WS_AUXILIARES.AC_GRAVA_MOV.Value = WS_AUXILIARES.AC_GRAVA_MOV + 1;

        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-UPDATE-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1()
        {
            /*" -1871- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_INCLUSAO = :V1SISTEMA-DTMOVABE, DATA_REFERENCIA = :MDATA-REFERENCIA WHERE COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-400-000-PERCENTUAL1-SECTION */
        private void M_400_000_PERCENTUAL1_SECTION()
        {
            /*" -1889- IF WPRMTOT = 0 */

            if (WS_AUXILIARES.WPRMTOT == 0)
            {

                /*" -1890- MOVE 0 TO VGPCT-COBERTURA1 */
                _.Move(0, VGPCT_COBERTURA1);

                /*" -1891- ELSE */
            }
            else
            {


                /*" -1893- COMPUTE VGPCT-COBERTURA1 ROUNDED = MPRM-VG-ATU * 100 / WPRMTOT. */
                VGPCT_COBERTURA1.Value = MPRM_VG_ATU * 100 / WS_AUXILIARES.WPRMTOT;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_000_EXIT*/

        [StopWatch]
        /*" M-410-000-PERCENTUAL2-SECTION */
        private void M_410_000_PERCENTUAL2_SECTION()
        {
            /*" -1901- IF WPRMTOT = 0 */

            if (WS_AUXILIARES.WPRMTOT == 0)
            {

                /*" -1902- MOVE 0 TO VGPCT-COBERTURA2 */
                _.Move(0, VGPCT_COBERTURA2);

                /*" -1903- ELSE */
            }
            else
            {


                /*" -1905- COMPUTE VGPCT-COBERTURA2 ROUNDED = MPRM-VG-ATU * 100 / WPRMTOT. */
                VGPCT_COBERTURA2.Value = MPRM_VG_ATU * 100 / WS_AUXILIARES.WPRMTOT;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_000_EXIT*/

        [StopWatch]
        /*" M-420-000-UPDATE-V0PROPOSTAVA-SECTION */
        private void M_420_000_UPDATE_V0PROPOSTAVA_SECTION()
        {
            /*" -1914- MOVE '420-000-UPDATE-V0PROPOSTAVA' TO PARAGRAFO */
            _.Move("420-000-UPDATE-V0PROPOSTAVA", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1916- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1925- PERFORM M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1 */

            M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1();

            /*" -1928- IF (SQLCODE NOT EQUAL ZEROS AND 100) */

            if ((!DB.SQLCODE.In("00", "100")))
            {

                /*" -1930- DISPLAY 'VG0030B - ERRO UPDATE PROPOSTAVA    ' MNUM-CERTIFICADO */
                _.Display($"VG0030B - ERRO UPDATE PROPOSTAVA    {MNUM_CERTIFICADO}");

                /*" -1931- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1932- ELSE */
            }
            else
            {


                /*" -1933- ADD 1 TO AC-GRAVA-PRO */
                WS_AUXILIARES.AC_GRAVA_PRO.Value = WS_AUXILIARES.AC_GRAVA_PRO + 1;

                /*" -1933- END-IF. */
            }


        }

        [StopWatch]
        /*" M-420-000-UPDATE-V0PROPOSTAVA-DB-UPDATE-1 */
        public void M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -1925- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '4' , CODOPER = :MCOD-OPERACAO, DTMOVTO = :MDATA-OPERACAO, CODUSU = :MCOD-USUARIO, NRPROPOS = :MNUM-PROPOSTA, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :MNUM-CERTIFICADO END-EXEC. */

            var m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 = new M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1.Execute(m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-430-000-UPDATE-CARENCIAS-SECTION */
        private void M_430_000_UPDATE_CARENCIAS_SECTION()
        {
            /*" -1943- MOVE '430-000-UPDATE-CARENCIAS_VGAP' TO PARAGRAFO */
            _.Move("430-000-UPDATE-CARENCIAS_VGAP", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1945- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1952- PERFORM M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1 */

            M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1();

            /*" -1955- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1956- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1958- DISPLAY 'VG0030B - ERRO UPDATE CARENCIAS_VGAP' MNUM-CERTIFICADO */
                    _.Display($"VG0030B - ERRO UPDATE CARENCIAS_VGAP{MNUM_CERTIFICADO}");

                    /*" -1959- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1960- END-IF */
                }


                /*" -1961- ELSE */
            }
            else
            {


                /*" -1962- ADD 1 TO AC-GRAVA-CAR */
                WS_AUXILIARES.AC_GRAVA_CAR.Value = WS_AUXILIARES.AC_GRAVA_CAR + 1;

                /*" -1962- END-IF. */
            }


        }

        [StopWatch]
        /*" M-430-000-UPDATE-CARENCIAS-DB-UPDATE-1 */
        public void M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1()
        {
            /*" -1952- EXEC SQL UPDATE SEGUROS.CARENCIAS_VGAP SET DATA_MOVIMENTO = CURRENT DATE, SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND SITUACAO = '0' END-EXEC. */

            var m_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1 = new M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1.Execute(m_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/

        [StopWatch]
        /*" M-500-000-SELECT-V0PROPOSTAVA-SECTION */
        private void M_500_000_SELECT_V0PROPOSTAVA_SECTION()
        {
            /*" -1973- MOVE '500-000-SELECT-V0PROPOSTAVA' TO PARAGRAFO */
            _.Move("500-000-SELECT-V0PROPOSTAVA", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1975- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1980- PERFORM M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1 */

            M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1();

            /*" -1983- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1985- DISPLAY 'VG0030B - PROBLEMAS NO SELECT V0PROPOSTAVA ' MNUM-CERTIFICADO '  ' SQLCODE */

                $"VG0030B - PROBLEMAS NO SELECT V0PROPOSTAVA {MNUM_CERTIFICADO}  {DB.SQLCODE}"
                .Display();

                /*" -1987- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1988- PERFORM 510-000-SELECT-V0HISTCOBVA. */

            M_510_000_SELECT_V0HISTCOBVA_SECTION();

        }

        [StopWatch]
        /*" M-500-000-SELECT-V0PROPOSTAVA-DB-SELECT-1 */
        public void M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1()
        {
            /*" -1980- EXEC SQL SELECT NRPARCE INTO :V0PROP-NRPARCELA FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :MNUM-CERTIFICADO END-EXEC. */

            var m_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 = new M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1.Execute(m_500_000_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_NRPARCELA, V0PROP_NRPARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_EXIT*/

        [StopWatch]
        /*" M-510-000-SELECT-V0HISTCOBVA-SECTION */
        private void M_510_000_SELECT_V0HISTCOBVA_SECTION()
        {
            /*" -1996- MOVE '510-000-SELECT-V0HISTCOBVA ' TO PARAGRAFO */
            _.Move("510-000-SELECT-V0HISTCOBVA ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1998- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2008- PERFORM M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1 */

            M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1();

            /*" -2011- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2014- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2015- GO TO 510-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_999_EXIT*/ //GOTO
                    return;

                    /*" -2016- ELSE */
                }
                else
                {


                    /*" -2018- DISPLAY 'VG0030B - PROBLEMAS NO SELECT V0HISTCOBVA  ' MNUM-CERTIFICADO '  ' SQLCODE */

                    $"VG0030B - PROBLEMAS NO SELECT V0HISTCOBVA  {MNUM_CERTIFICADO}  {DB.SQLCODE}"
                    .Display();

                    /*" -2020- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2021- PERFORM 520-000-SELECT-V0PARCELVA. */

            M_520_000_SELECT_V0PARCELVA_SECTION();

        }

        [StopWatch]
        /*" M-510-000-SELECT-V0HISTCOBVA-DB-SELECT-1 */
        public void M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1()
        {
            /*" -2008- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :MNUM-CERTIFICADO AND NRPARCEL = :V0PROP-NRPARCELA END-EXEC. */

            var m_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1 = new M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_NRPARCELA = V0PROP_NRPARCELA.ToString(),
            };

            var executed_1 = M_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1.Execute(m_510_000_SELECT_V0HISTCOBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(executed_1.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_510_999_EXIT*/

        [StopWatch]
        /*" M-520-000-SELECT-V0PARCELVA-SECTION */
        private void M_520_000_SELECT_V0PARCELVA_SECTION()
        {
            /*" -2030- MOVE '520-000-SELECT-V0PARCELVA  ' TO PARAGRAFO */
            _.Move("520-000-SELECT-V0PARCELVA  ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2032- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2041- PERFORM M_520_000_SELECT_V0PARCELVA_DB_SELECT_1 */

            M_520_000_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -2044- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2047- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2048- GO TO 520-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_520_999_EXIT*/ //GOTO
                    return;

                    /*" -2049- ELSE */
                }
                else
                {


                    /*" -2051- DISPLAY 'VG0030B - PROBLEMAS NO SELECT V0PARCELVA   ' MNUM-CERTIFICADO '   ' SQLCODE */

                    $"VG0030B - PROBLEMAS NO SELECT V0PARCELVA   {MNUM_CERTIFICADO}   {DB.SQLCODE}"
                    .Display();

                    /*" -2053- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2054- PERFORM 530-000-INSERT-V0HCONTABILVA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_000_INSERT_V0HCONTABILVA_SECTION*/


        }

        [StopWatch]
        /*" M-520-000-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void M_520_000_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -2041- EXEC SQL SELECT PRMVG, PRMAP INTO :V0PARC-PRMVG, :V0PARC-PRMAP FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :MNUM-CERTIFICADO AND NRPARCEL = :V0PROP-NRPARCELA WITH UR END-EXEC. */

            var m_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1 = new M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_NRPARCELA = V0PROP_NRPARCELA.ToString(),
            };

            var executed_1 = M_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1.Execute(m_520_000_SELECT_V0PARCELVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_520_999_EXIT*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_000_INSERT_V0HCONTABILVA_SECTION*/

        [StopWatch]
        /*" M-530-000-INCLUI */
        private void M_530_000_INCLUI(bool isPerform = false)
        {
            /*" -2066- MOVE '530-000-INSERT-V0HISTCONTABILVA ' TO PARAGRAFO */
            _.Move("530-000-INSERT-V0HISTCONTABILVA ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2068- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2086- PERFORM M_530_000_INCLUI_DB_INSERT_1 */

            M_530_000_INCLUI_DB_INSERT_1();

            /*" -2089- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2090- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2096- PERFORM M_530_000_INCLUI_DB_SELECT_1 */

                    M_530_000_INCLUI_DB_SELECT_1();

                    /*" -2098- COMPUTE V0HCON-OCORHIST = V0HCON-OCORHIST + 1 */
                    V0HCON_OCORHIST.Value = V0HCON_OCORHIST + 1;

                    /*" -2099- MOVE V0HCON-OCORHIST TO V0HCOB-OCORHIST */
                    _.Move(V0HCON_OCORHIST, V0HCOB_OCORHIST);

                    /*" -2100- GO TO 530-000-INCLUI */
                    new Task(() => M_530_000_INCLUI()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2101- ELSE */
                }
                else
                {


                    /*" -2103- DISPLAY 'VG0030B - PROBLEMAS INSERT V0HISTCONTABILVA ' MNUM-CERTIFICADO '   ' SQLCODE */

                    $"VG0030B - PROBLEMAS INSERT V0HISTCONTABILVA {MNUM_CERTIFICADO}   {DB.SQLCODE}"
                    .Display();

                    /*" -2105- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2108- MOVE '530-010-UPDATE-V0HISTCOBVA ' TO PARAGRAFO */
            _.Move("530-010-UPDATE-V0HISTCOBVA ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2113- PERFORM M_530_000_INCLUI_DB_UPDATE_1 */

            M_530_000_INCLUI_DB_UPDATE_1();

            /*" -2116- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2118- DISPLAY 'NRCERTIF ' MNUM-CERTIFICADO 'PARCELA  ' V0PROP-NRPARCELA '  ' SQLCODE */

                $"NRCERTIF {MNUM_CERTIFICADO}PARCELA  {V0PROP_NRPARCELA}  {DB.SQLCODE}"
                .Display();

                /*" -2119- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -2121- END-IF */
            }


            /*" -2122- . */

        }

        [StopWatch]
        /*" M-530-000-INCLUI-DB-INSERT-1 */
        public void M_530_000_INCLUI_DB_INSERT_1()
        {
            /*" -2086- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:MNUM-CERTIFICADO, :V0PROP-NRPARCELA, :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :MNUM-APOLICE, :MCOD-SUBGRUPO, :MCOD-FONTE, 0, :V0PARC-PRMVG, :V0PARC-PRMAP, :V0HCOB-DTVENCTO, '0' , :MCOD-OPERACAO, CURRENT TIMESTAMP, NULL) END-EXEC. */

            var m_530_000_INCLUI_DB_INSERT_1_Insert1 = new M_530_000_INCLUI_DB_INSERT_1_Insert1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_NRPARCELA = V0PROP_NRPARCELA.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
            };

            M_530_000_INCLUI_DB_INSERT_1_Insert1.Execute(m_530_000_INCLUI_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-530-000-INCLUI-DB-SELECT-1 */
        public void M_530_000_INCLUI_DB_SELECT_1()
        {
            /*" -2096- EXEC SQL SELECT VALUE(MAX(OCOORHIST),0) INTO :V0HCON-OCORHIST FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :MNUM-CERTIFICADO AND NRPARCEL = :V0PROP-NRPARCELA END-EXEC */

            var m_530_000_INCLUI_DB_SELECT_1_Query1 = new M_530_000_INCLUI_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_NRPARCELA = V0PROP_NRPARCELA.ToString(),
            };

            var executed_1 = M_530_000_INCLUI_DB_SELECT_1_Query1.Execute(m_530_000_INCLUI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCON_OCORHIST, V0HCON_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-530-000-INCLUI-DB-UPDATE-1 */
        public void M_530_000_INCLUI_DB_UPDATE_1()
        {
            /*" -2113- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET OCORHIST = :V0HCOB-OCORHIST WHERE NRCERTIF = :MNUM-CERTIFICADO AND NRPARCEL = :V0PROP-NRPARCELA END-EXEC. */

            var m_530_000_INCLUI_DB_UPDATE_1_Update1 = new M_530_000_INCLUI_DB_UPDATE_1_Update1()
            {
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_NRPARCELA = V0PROP_NRPARCELA.ToString(),
            };

            M_530_000_INCLUI_DB_UPDATE_1_Update1.Execute(m_530_000_INCLUI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_999_EXIT*/

        [StopWatch]
        /*" M-600-000-VER-ORIG-PRODUTO-SECTION */
        private void M_600_000_VER_ORIG_PRODUTO_SECTION()
        {
            /*" -2132- MOVE '600-000-VER-ORIG-PRODUTO' TO PARAGRAFO */
            _.Move("600-000-VER-ORIG-PRODUTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2135- MOVE '600' TO WNR-EXEC-SQL */
            _.Move("600", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2142- PERFORM M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1 */

            M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1();

            /*" -2145- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2146- DISPLAY 'VG0030B-PROBLEMAS SELECT SUBGRUPOS_VGAP ' */
                _.Display($"VG0030B-PROBLEMAS SELECT SUBGRUPOS_VGAP ");

                /*" -2147- DISPLAY 'NUMERO APOLICE ... ' MNUM-APOLICE */
                _.Display($"NUMERO APOLICE ... {MNUM_APOLICE}");

                /*" -2148- DISPLAY 'CODIGO SUBGRUPO .. ' MCOD-SUBGRUPO */
                _.Display($"CODIGO SUBGRUPO .. {MCOD_SUBGRUPO}");

                /*" -2149- DISPLAY 'SQLCODE .......... ' SQLCODE */
                _.Display($"SQLCODE .......... {DB.SQLCODE}");

                /*" -2150- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -2152- END-IF */
            }


            /*" -2153- IF WTIPO-FATURAMENTO = '1' */

            if (WTIPO_FATURAMENTO == "1")
            {

                /*" -2154- MOVE ZEROS TO WCOD-SUBGRUPO-EMP */
                _.Move(0, WCOD_SUBGRUPO_EMP);

                /*" -2155- ELSE */
            }
            else
            {


                /*" -2156- MOVE MCOD-SUBGRUPO TO WCOD-SUBGRUPO-EMP */
                _.Move(MCOD_SUBGRUPO, WCOD_SUBGRUPO_EMP);

                /*" -2158- END-IF */
            }


            /*" -2160- MOVE ZEROS TO WS-EOF-PRODUTOS-VG */
            _.Move(0, WS_EOF_PRODUTOS_VG);

            /*" -2167- PERFORM M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2 */

            M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2();

            /*" -2170- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2171- MOVE 1 TO WS-EOF-PRODUTOS-VG */
                _.Move(1, WS_EOF_PRODUTOS_VG);

                /*" -2172- ELSE */
            }
            else
            {


                /*" -2173- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2174- DISPLAY 'VG0030B-PROBLEMAS SELECT PRODUTOS_VG' */
                    _.Display($"VG0030B-PROBLEMAS SELECT PRODUTOS_VG");

                    /*" -2175- DISPLAY 'NUMERO APOLICE ... ' MNUM-APOLICE */
                    _.Display($"NUMERO APOLICE ... {MNUM_APOLICE}");

                    /*" -2176- DISPLAY 'CODIGO SUBGRUPO M. ' MCOD-SUBGRUPO */
                    _.Display($"CODIGO SUBGRUPO M. {MCOD_SUBGRUPO}");

                    /*" -2177- DISPLAY 'CODIGO SUBGRUPO W. ' WCOD-SUBGRUPO-EMP */
                    _.Display($"CODIGO SUBGRUPO W. {WCOD_SUBGRUPO_EMP}");

                    /*" -2178- DISPLAY 'SQLCODE .......... ' SQLCODE */
                    _.Display($"SQLCODE .......... {DB.SQLCODE}");

                    /*" -2179- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2180- END-IF */
                }


                /*" -2182- END-IF */
            }


            /*" -2184- IF WORIG-PRODUTO EQUAL ( 'ESPEC' OR 'EMPRE' OR 'GLOBAL' OR 'ESPE1' OR 'ESPE2' OR 'ESPE3' ) */

            if (WORIG_PRODUTO.In("ESPEC", "EMPRE", "GLOBAL", "ESPE1", "ESPE2", "ESPE3"))
            {

                /*" -2195- PERFORM M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3 */

                M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3();

                /*" -2206- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2207- MOVE 1 TO WS-EOF-PRODUTOS-VG */
                    _.Move(1, WS_EOF_PRODUTOS_VG);

                    /*" -2208- ELSE */
                }
                else
                {


                    /*" -2209- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2210- DISPLAY 'VG0030B-PROBLEMAS SELECT PROPOSTAS_VA' */
                        _.Display($"VG0030B-PROBLEMAS SELECT PROPOSTAS_VA");

                        /*" -2211- DISPLAY 'NUMERO APOLICE ... ' MNUM-APOLICE */
                        _.Display($"NUMERO APOLICE ... {MNUM_APOLICE}");

                        /*" -2212- DISPLAY 'CODIGO SUBGRUPO M. ' MCOD-SUBGRUPO */
                        _.Display($"CODIGO SUBGRUPO M. {MCOD_SUBGRUPO}");

                        /*" -2213- DISPLAY 'CODIGO SUBGRUPO W. ' WCOD-SUBGRUPO-EMP */
                        _.Display($"CODIGO SUBGRUPO W. {WCOD_SUBGRUPO_EMP}");

                        /*" -2214- DISPLAY 'SQLCODE .......... ' SQLCODE */
                        _.Display($"SQLCODE .......... {DB.SQLCODE}");

                        /*" -2215- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO(); //GOTO
                        return;

                        /*" -2216- END-IF */
                    }


                    /*" -2218- END-IF */
                }


                /*" -2220- END-IF */
            }


            /*" -2220- . */

        }

        [StopWatch]
        /*" M-600-000-VER-ORIG-PRODUTO-DB-SELECT-1 */
        public void M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1()
        {
            /*" -2142- EXEC SQL SELECT TIPO_FATURAMENTO INTO :WTIPO-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :MNUM-APOLICE AND COD_SUBGRUPO = :MCOD-SUBGRUPO WITH UR END-EXEC */

            var m_600_000_VER_ORIG_PRODUTO_DB_SELECT_1_Query1 = new M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1_Query1()
            {
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_600_000_VER_ORIG_PRODUTO_DB_SELECT_1_Query1.Execute(m_600_000_VER_ORIG_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WTIPO_FATURAMENTO, WTIPO_FATURAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-600-000-VER-ORIG-PRODUTO-DB-SELECT-2 */
        public void M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2()
        {
            /*" -2167- EXEC SQL SELECT ORIG_PRODU INTO :WORIG-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :MNUM-APOLICE AND COD_SUBGRUPO = :WCOD-SUBGRUPO-EMP WITH UR END-EXEC */

            var m_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1 = new M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1()
            {
                WCOD_SUBGRUPO_EMP = WCOD_SUBGRUPO_EMP.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1.Execute(m_600_000_VER_ORIG_PRODUTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WORIG_PRODUTO, WORIG_PRODUTO);
            }


        }

        [StopWatch]
        /*" M-610-000-CONSULTA-APOLCOBER-SECTION */
        private void M_610_000_CONSULTA_APOLCOBER_SECTION()
        {
            /*" -2230- MOVE '610-000-CONSULTA-APOLCOBER' TO PARAGRAFO */
            _.Move("610-000-CONSULTA-APOLCOBER", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2235- MOVE '610' TO WNR-EXEC-SQL */
            _.Move("610", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2241- PERFORM M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1 */

            M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1();

            /*" -2244- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2245- DISPLAY 'VG0030B-PROBLEMAS SELECT SEGURADOS_VGAP ' */
                _.Display($"VG0030B-PROBLEMAS SELECT SEGURADOS_VGAP ");

                /*" -2246- DISPLAY 'NUMERO CERTIFICADO.. ' MNUM-CERTIFICADO */
                _.Display($"NUMERO CERTIFICADO.. {MNUM_CERTIFICADO}");

                /*" -2247- DISPLAY 'TIPO SEGURADO ...... ' MTIPO-SEGURADO */
                _.Display($"TIPO SEGURADO ...... {MTIPO_SEGURADO}");

                /*" -2248- DISPLAY 'SQLCODE ............ ' SQLCODE */
                _.Display($"SQLCODE ............ {DB.SQLCODE}");

                /*" -2249- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -2253- END-IF */
            }


            /*" -2269- PERFORM M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2 */

            M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2();

            /*" -2272- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2274- IF MIMP-MORNATU-ATU EQUAL ZEROS OR MPRM-VG-ATU EQUAL ZEROS */

                if (MIMP_MORNATU_ATU == 00 || MPRM_VG_ATU == 00)
                {

                    /*" -2275- PERFORM 615-000-CONSULTA-HISCOBER-VG */

                    M_615_000_CONSULTA_HISCOBER_VG_SECTION();

                    /*" -2276- END-IF */
                }


                /*" -2277- ELSE */
            }
            else
            {


                /*" -2279- MOVE 0 TO MIMP-MORNATU-ATU MPRM-VG-ATU */
                _.Move(0, MIMP_MORNATU_ATU, MPRM_VG_ATU);

                /*" -2283- END-IF */
            }


            /*" -2298- PERFORM M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3 */

            M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3();

            /*" -2301- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2303- IF MIMP-MORACID-ATU EQUAL ZEROS OR MPRM-AP-ATU EQUAL ZEROS */

                if (MIMP_MORACID_ATU == 00 || MPRM_AP_ATU == 00)
                {

                    /*" -2304- PERFORM 620-000-CONSULTA-HISCOBER-AP */

                    M_620_000_CONSULTA_HISCOBER_AP_SECTION();

                    /*" -2305- END-IF */
                }


                /*" -2306- ELSE */
            }
            else
            {


                /*" -2308- MOVE 0 TO MIMP-MORACID-ATU MPRM-AP-ATU */
                _.Move(0, MIMP_MORACID_ATU, MPRM_AP_ATU);

                /*" -2312- END-IF */
            }


            /*" -2325- PERFORM M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4 */

            M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4();

            /*" -2328- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2329- MOVE 0 TO MIMP-INVPERM-ATU */
                _.Move(0, MIMP_INVPERM_ATU);

                /*" -2333- END-IF */
            }


            /*" -2346- PERFORM M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5 */

            M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5();

            /*" -2349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2350- MOVE 0 TO MIMP-DIT-ATU */
                _.Move(0, MIMP_DIT_ATU);

                /*" -2352- END-IF */
            }


            /*" -2356- IF ((MPRM-VG-ATU EQUAL ZEROS) AND (MPRM-AP-ATU EQUAL ZEROS)) OR ((MIMP-MORNATU-ATU EQUAL ZEROS) AND (MIMP-MORACID-ATU EQUAL ZEROS)) */

            if (((MPRM_VG_ATU == 00) && (MPRM_AP_ATU == 00)) || ((MIMP_MORNATU_ATU == 00) && (MIMP_MORACID_ATU == 00)))
            {

                /*" -2357- PERFORM 625-000-CONSULTA-HISCOBER */

                M_625_000_CONSULTA_HISCOBER_SECTION();

                /*" -2359- END-IF */
            }


            /*" -2363- IF ((MPRM-VG-ATU EQUAL ZEROS) AND (MPRM-AP-ATU EQUAL ZEROS)) OR ((MIMP-MORNATU-ATU EQUAL ZEROS) AND (MIMP-MORACID-ATU EQUAL ZEROS)) */

            if (((MPRM_VG_ATU == 00) && (MPRM_AP_ATU == 00)) || ((MIMP_MORNATU_ATU == 00) && (MIMP_MORACID_ATU == 00)))
            {

                /*" -2367- MOVE 0,01 TO MIMP-MORACID-ATU MPRM-AP-ATU MIMP-MORNATU-ATU MPRM-VG-ATU */
                _.Move(0.01, MIMP_MORACID_ATU, MPRM_AP_ATU, MIMP_MORNATU_ATU, MPRM_VG_ATU);

                /*" -2369- END-IF */
            }


            /*" -2369- . */

        }

        [StopWatch]
        /*" M-610-000-CONSULTA-APOLCOBER-DB-SELECT-1 */
        public void M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1()
        {
            /*" -2241- EXEC SQL SELECT NUM_ITEM INTO :SNUM-ITEM FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC */

            var m_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1 = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            var executed_1 = M_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1.Execute(m_610_000_CONSULTA_APOLCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SNUM_ITEM, SNUM_ITEM);
            }


        }

        [StopWatch]
        /*" M-600-000-VER-ORIG-PRODUTO-DB-SELECT-3 */
        public void M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3()
        {
            /*" -2195- EXEC SQL SELECT NUM_CERTIFICADO , SIT_REGISTRO INTO :WNUM-CERTIFICADO , :WSIT-REGISTRO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE = :MNUM-APOLICE AND COD_SUBGRUPO = :WCOD-SUBGRUPO-EMP ORDER BY DATA_MOVIMENTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var m_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1 = new M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1()
            {
                WCOD_SUBGRUPO_EMP = WCOD_SUBGRUPO_EMP.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1.Execute(m_600_000_VER_ORIG_PRODUTO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WNUM_CERTIFICADO, WNUM_CERTIFICADO);
                _.Move(executed_1.WSIT_REGISTRO, WSIT_REGISTRO);
            }


        }

        [StopWatch]
        /*" M-610-000-CONSULTA-APOLCOBER-DB-SELECT-2 */
        public void M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2()
        {
            /*" -2269- EXEC SQL SELECT IMP_SEGURADA_IX , PRM_TARIFARIO_IX INTO :MIMP-MORNATU-ATU , :MPRM-VG-ATU FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :MNUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SNUM-ITEM AND RAMO_COBERTURA IN (:V1PAR-RAMO-PST, :V1PAR-RAMO-VG) AND MODALI_COBERTURA IN (0, :V0APOL-MODALIDA) AND COD_COBERTURA = 11 AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROWS ONLY END-EXEC */

            var m_610_000_CONSULTA_APOLCOBER_DB_SELECT_2_Query1 = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2_Query1()
            {
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                V1PAR_RAMO_PST = V1PAR_RAMO_PST.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                V1PAR_RAMO_VG = V1PAR_RAMO_VG.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_610_000_CONSULTA_APOLCOBER_DB_SELECT_2_Query1.Execute(m_610_000_CONSULTA_APOLCOBER_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MIMP_MORNATU_ATU, MIMP_MORNATU_ATU);
                _.Move(executed_1.MPRM_VG_ATU, MPRM_VG_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_610_999_EXIT*/

        [StopWatch]
        /*" M-610-000-CONSULTA-APOLCOBER-DB-SELECT-3 */
        public void M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3()
        {
            /*" -2298- EXEC SQL SELECT IMP_SEGURADA_IX , PRM_TARIFARIO_IX INTO :MIMP-MORACID-ATU , :MPRM-AP-ATU FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :MNUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SNUM-ITEM AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP) AND MODALI_COBERTURA IN (0, :V0APOL-MODALIDA) AND COD_COBERTURA = 1 AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROWS ONLY END-EXEC */

            var m_610_000_CONSULTA_APOLCOBER_DB_SELECT_3_Query1 = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3_Query1()
            {
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_610_000_CONSULTA_APOLCOBER_DB_SELECT_3_Query1.Execute(m_610_000_CONSULTA_APOLCOBER_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MIMP_MORACID_ATU, MIMP_MORACID_ATU);
                _.Move(executed_1.MPRM_AP_ATU, MPRM_AP_ATU);
            }


        }

        [StopWatch]
        /*" M-615-000-CONSULTA-HISCOBER-VG-SECTION */
        private void M_615_000_CONSULTA_HISCOBER_VG_SECTION()
        {
            /*" -2379- MOVE '615-000-CONSULTA-HISCOBER-VG' TO PARAGRAFO */
            _.Move("615-000-CONSULTA-HISCOBER-VG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2382- MOVE '615' TO WNR-EXEC-SQL */
            _.Move("615", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2386- MOVE ZEROS TO WIMP-MORNATU-ATU WPRM-VG-ATU WQUANT-VIDAS */
            _.Move(0, WIMP_MORNATU_ATU, WPRM_VG_ATU, WQUANT_VIDAS);

            /*" -2399- PERFORM M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1 */

            M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1();

            /*" -2402- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2403- IF WIMP-MORNATU-ATU GREATER ZEROS */

                if (WIMP_MORNATU_ATU > 00)
                {

                    /*" -2405- COMPUTE WIMP-MORNATU-ATU = WIMP-MORNATU-ATU / WQUANT-VIDAS */
                    WIMP_MORNATU_ATU.Value = WIMP_MORNATU_ATU / WQUANT_VIDAS;

                    /*" -2406- ELSE */
                }
                else
                {


                    /*" -2407- MOVE ZEROS TO WIMP-MORNATU-ATU */
                    _.Move(0, WIMP_MORNATU_ATU);

                    /*" -2408- END-IF */
                }


                /*" -2409- IF WPRM-VG-ATU GREATER ZEROS */

                if (WPRM_VG_ATU > 00)
                {

                    /*" -2411- COMPUTE WPRM-VG-ATU = WPRM-VG-ATU / WQUANT-VIDAS */
                    WPRM_VG_ATU.Value = WPRM_VG_ATU / WQUANT_VIDAS;

                    /*" -2412- ELSE */
                }
                else
                {


                    /*" -2413- MOVE ZEROS TO WPRM-VG-ATU */
                    _.Move(0, WPRM_VG_ATU);

                    /*" -2414- END-IF */
                }


                /*" -2415- MOVE WIMP-MORNATU-ATU TO MIMP-MORNATU-ATU */
                _.Move(WIMP_MORNATU_ATU, MIMP_MORNATU_ATU);

                /*" -2416- MOVE WPRM-VG-ATU TO MPRM-VG-ATU */
                _.Move(WPRM_VG_ATU, MPRM_VG_ATU);

                /*" -2417- ELSE */
            }
            else
            {


                /*" -2418- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2421- MOVE ZEROS TO WIMP-MORNATU-ATU WPRM-VG-ATU WQUANT-VIDAS */
                    _.Move(0, WIMP_MORNATU_ATU, WPRM_VG_ATU, WQUANT_VIDAS);

                    /*" -2422- ELSE */
                }
                else
                {


                    /*" -2424- DISPLAY 'VG0030B-PROBLEMAS SELECT HISCOBERPROP-VG ' WNUM-CERTIFICADO '   ' MDATA-OPERACAO '   ' SQLCODE */

                    $"VG0030B-PROBLEMAS SELECT HISCOBERPROP-VG {WNUM_CERTIFICADO}   {MDATA_OPERACAO}   {DB.SQLCODE}"
                    .Display();

                    /*" -2425- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2427- END-IF */
                }


                /*" -2427- . */
            }


        }

        [StopWatch]
        /*" M-615-000-CONSULTA-HISCOBER-VG-DB-SELECT-1 */
        public void M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1()
        {
            /*" -2399- EXEC SQL SELECT VALUE(IMP_MORNATU, 0) , VALUE(PRMVG, 0) , VALUE(QUANT_VIDAS, 0) INTO :WIMP-MORNATU-ATU , :WPRM-VG-ATU , :WQUANT-VIDAS FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WNUM-CERTIFICADO AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var m_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1_Query1 = new M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1_Query1()
            {
                WNUM_CERTIFICADO = WNUM_CERTIFICADO.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
            };

            var executed_1 = M_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1_Query1.Execute(m_615_000_CONSULTA_HISCOBER_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WIMP_MORNATU_ATU, WIMP_MORNATU_ATU);
                _.Move(executed_1.WPRM_VG_ATU, WPRM_VG_ATU);
                _.Move(executed_1.WQUANT_VIDAS, WQUANT_VIDAS);
            }


        }

        [StopWatch]
        /*" M-610-000-CONSULTA-APOLCOBER-DB-SELECT-4 */
        public void M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4()
        {
            /*" -2325- EXEC SQL SELECT IMP_SEGURADA_IX INTO :MIMP-INVPERM-ATU FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :MNUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SNUM-ITEM AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP) AND MODALI_COBERTURA IN (0, :V0APOL-MODALIDA) AND COD_COBERTURA = 2 AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROWS ONLY END-EXEC */

            var m_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1 = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1()
            {
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1.Execute(m_610_000_CONSULTA_APOLCOBER_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MIMP_INVPERM_ATU, MIMP_INVPERM_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_615_999_EXIT*/

        [StopWatch]
        /*" M-610-000-CONSULTA-APOLCOBER-DB-SELECT-5 */
        public void M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5()
        {
            /*" -2346- EXEC SQL SELECT IMP_SEGURADA_IX INTO :MIMP-DIT-ATU FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :MNUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SNUM-ITEM AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP) AND MODALI_COBERTURA IN (0, :V0APOL-MODALIDA) AND COD_COBERTURA = 5 AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROWS ONLY END-EXEC */

            var m_610_000_CONSULTA_APOLCOBER_DB_SELECT_5_Query1 = new M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5_Query1()
            {
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_610_000_CONSULTA_APOLCOBER_DB_SELECT_5_Query1.Execute(m_610_000_CONSULTA_APOLCOBER_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MIMP_DIT_ATU, MIMP_DIT_ATU);
            }


        }

        [StopWatch]
        /*" M-620-000-CONSULTA-HISCOBER-AP-SECTION */
        private void M_620_000_CONSULTA_HISCOBER_AP_SECTION()
        {
            /*" -2437- MOVE '620-000-CONSULTA-HISCOBER-AP' TO PARAGRAFO */
            _.Move("620-000-CONSULTA-HISCOBER-AP", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2440- MOVE '620' TO WNR-EXEC-SQL */
            _.Move("620", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2444- MOVE ZEROS TO WIMP-MORACID-ATU WPRM-AP-ATU WQUANT-VIDAS */
            _.Move(0, WIMP_MORACID_ATU, WPRM_AP_ATU, WQUANT_VIDAS);

            /*" -2457- PERFORM M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1 */

            M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1();

            /*" -2460- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2461- IF WIMP-MORACID-ATU GREATER ZEROS */

                if (WIMP_MORACID_ATU > 00)
                {

                    /*" -2463- COMPUTE WIMP-MORACID-ATU = WIMP-MORACID-ATU / WQUANT-VIDAS */
                    WIMP_MORACID_ATU.Value = WIMP_MORACID_ATU / WQUANT_VIDAS;

                    /*" -2464- ELSE */
                }
                else
                {


                    /*" -2465- MOVE ZEROS TO WIMP-MORACID-ATU */
                    _.Move(0, WIMP_MORACID_ATU);

                    /*" -2466- END-IF */
                }


                /*" -2467- IF WPRM-AP-ATU GREATER ZEROS */

                if (WPRM_AP_ATU > 00)
                {

                    /*" -2469- COMPUTE WPRM-AP-ATU = WPRM-AP-ATU / WQUANT-VIDAS */
                    WPRM_AP_ATU.Value = WPRM_AP_ATU / WQUANT_VIDAS;

                    /*" -2470- ELSE */
                }
                else
                {


                    /*" -2471- MOVE ZEROS TO WPRM-AP-ATU */
                    _.Move(0, WPRM_AP_ATU);

                    /*" -2472- END-IF */
                }


                /*" -2473- MOVE WIMP-MORACID-ATU TO MIMP-MORACID-ATU */
                _.Move(WIMP_MORACID_ATU, MIMP_MORACID_ATU);

                /*" -2474- MOVE WPRM-AP-ATU TO MPRM-AP-ATU */
                _.Move(WPRM_AP_ATU, MPRM_AP_ATU);

                /*" -2475- ELSE */
            }
            else
            {


                /*" -2476- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2479- MOVE ZEROS TO WIMP-MORACID-ATU WPRM-AP-ATU WQUANT-VIDAS */
                    _.Move(0, WIMP_MORACID_ATU, WPRM_AP_ATU, WQUANT_VIDAS);

                    /*" -2480- ELSE */
                }
                else
                {


                    /*" -2482- DISPLAY 'VG0030B-PROBLEMAS SELECT HISCOBERPROP-AP ' WNUM-CERTIFICADO '   ' MDATA-OPERACAO '   ' SQLCODE */

                    $"VG0030B-PROBLEMAS SELECT HISCOBERPROP-AP {WNUM_CERTIFICADO}   {MDATA_OPERACAO}   {DB.SQLCODE}"
                    .Display();

                    /*" -2483- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2485- END-IF */
                }


                /*" -2485- . */
            }


        }

        [StopWatch]
        /*" M-620-000-CONSULTA-HISCOBER-AP-DB-SELECT-1 */
        public void M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1()
        {
            /*" -2457- EXEC SQL SELECT VALUE(IMPMORACID, 0) , VALUE(PRMAP, 0) , VALUE(QUANT_VIDAS, 0) INTO :WIMP-MORACID-ATU , :WPRM-AP-ATU , :WQUANT-VIDAS FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WNUM-CERTIFICADO AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var m_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1 = new M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1()
            {
                WNUM_CERTIFICADO = WNUM_CERTIFICADO.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
            };

            var executed_1 = M_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1.Execute(m_620_000_CONSULTA_HISCOBER_AP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WIMP_MORACID_ATU, WIMP_MORACID_ATU);
                _.Move(executed_1.WPRM_AP_ATU, WPRM_AP_ATU);
                _.Move(executed_1.WQUANT_VIDAS, WQUANT_VIDAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_620_999_EXIT*/

        [StopWatch]
        /*" M-625-000-CONSULTA-HISCOBER-SECTION */
        private void M_625_000_CONSULTA_HISCOBER_SECTION()
        {
            /*" -2495- MOVE '625-000-CONSULTA-HISCOBER' TO PARAGRAFO */
            _.Move("625-000-CONSULTA-HISCOBER", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2496- MOVE '625' TO WNR-EXEC-SQL */
            _.Move("625", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2499- MOVE ' ' TO WNR-EXEC-SQL-ANT */
            _.Move(" ", WS_AUXILIARES.WABEND.WNR_EXEC_SQL_ANT);

            /*" -2505- MOVE ZEROS TO WIMP-MORACID-ATU WPRM-AP-ATU WIMP-MORNATU-ATU WPRM-VG-ATU WQUANT-VIDAS */
            _.Move(0, WIMP_MORACID_ATU, WPRM_AP_ATU, WIMP_MORNATU_ATU, WPRM_VG_ATU, WQUANT_VIDAS);

            /*" -2522- PERFORM M_625_000_CONSULTA_HISCOBER_DB_SELECT_1 */

            M_625_000_CONSULTA_HISCOBER_DB_SELECT_1();

            /*" -2525- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2526- CONTINUE */

                /*" -2527- ELSE */
            }
            else
            {


                /*" -2528- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -2533- MOVE ZEROS TO WIMP-MORACID-ATU WIMP-MORNATU-ATU WPRM-AP-ATU WPRM-VG-ATU WQUANT-VIDAS */
                    _.Move(0, WIMP_MORACID_ATU, WIMP_MORNATU_ATU, WPRM_AP_ATU, WPRM_VG_ATU, WQUANT_VIDAS);

                    /*" -2534- ELSE */
                }
                else
                {


                    /*" -2536- DISPLAY 'VG0030B-PROBLEMAS SELECT HISCOBERPROP ' WNUM-CERTIFICADO '   ' MDATA-OPERACAO '   ' SQLCODE */

                    $"VG0030B-PROBLEMAS SELECT HISCOBERPROP {WNUM_CERTIFICADO}   {MDATA_OPERACAO}   {DB.SQLCODE}"
                    .Display();

                    /*" -2537- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2539- END-IF */
                }


                /*" -2540- IF WPRM-VG-ATU GREATER ZEROS */

                if (WPRM_VG_ATU > 00)
                {

                    /*" -2542- COMPUTE WPRM-VG-ATU = WPRM-VG-ATU / WQUANT-VIDAS */
                    WPRM_VG_ATU.Value = WPRM_VG_ATU / WQUANT_VIDAS;

                    /*" -2543- IF WIMP-MORNATU-ATU GREATER ZEROS */

                    if (WIMP_MORNATU_ATU > 00)
                    {

                        /*" -2545- COMPUTE WIMP-MORNATU-ATU = WIMP-MORNATU-ATU / WQUANT-VIDAS */
                        WIMP_MORNATU_ATU.Value = WIMP_MORNATU_ATU / WQUANT_VIDAS;

                        /*" -2546- END-IF */
                    }


                    /*" -2548- END-IF */
                }


                /*" -2549- IF WPRM-AP-ATU GREATER ZEROS */

                if (WPRM_AP_ATU > 00)
                {

                    /*" -2551- COMPUTE WPRM-AP-ATU = WPRM-AP-ATU / WQUANT-VIDAS */
                    WPRM_AP_ATU.Value = WPRM_AP_ATU / WQUANT_VIDAS;

                    /*" -2552- IF WIMP-MORACID-ATU GREATER ZEROS */

                    if (WIMP_MORACID_ATU > 00)
                    {

                        /*" -2554- COMPUTE WIMP-MORACID-ATU = WIMP-MORACID-ATU / WQUANT-VIDAS */
                        WIMP_MORACID_ATU.Value = WIMP_MORACID_ATU / WQUANT_VIDAS;

                        /*" -2555- ELSE */
                    }
                    else
                    {


                        /*" -2557- IF WIMP-MORNATU-ATU GREATER ZEROS AND WPRM-VG-ATU EQUAL ZEROS */

                        if (WIMP_MORNATU_ATU > 00 && WPRM_VG_ATU == 00)
                        {

                            /*" -2559- COMPUTE WIMP-MORACID-ATU = WIMP-MORNATU-ATU / WQUANT-VIDAS */
                            WIMP_MORACID_ATU.Value = WIMP_MORNATU_ATU / WQUANT_VIDAS;

                            /*" -2560- END-IF */
                        }


                        /*" -2561- END-IF */
                    }


                    /*" -2563- END-IF */
                }


                /*" -2564- MOVE WIMP-MORACID-ATU TO MIMP-MORACID-ATU */
                _.Move(WIMP_MORACID_ATU, MIMP_MORACID_ATU);

                /*" -2565- MOVE WPRM-AP-ATU TO MPRM-AP-ATU */
                _.Move(WPRM_AP_ATU, MPRM_AP_ATU);

                /*" -2566- MOVE WIMP-MORNATU-ATU TO MIMP-MORNATU-ATU */
                _.Move(WIMP_MORNATU_ATU, MIMP_MORNATU_ATU);

                /*" -2568- MOVE WPRM-VG-ATU TO MPRM-VG-ATU */
                _.Move(WPRM_VG_ATU, MPRM_VG_ATU);

                /*" -2568- . */
            }


        }

        [StopWatch]
        /*" M-625-000-CONSULTA-HISCOBER-DB-SELECT-1 */
        public void M_625_000_CONSULTA_HISCOBER_DB_SELECT_1()
        {
            /*" -2522- EXEC SQL SELECT VALUE(PRMVG, 0) , VALUE(PRMAP, 0) , VALUE(IMP_MORNATU, 0) , VALUE(IMPMORACID, 0) , VALUE(QUANT_VIDAS, 0) INTO :WPRM-VG-ATU , :WPRM-AP-ATU , :WIMP-MORNATU-ATU , :WIMP-MORACID-ATU , :WQUANT-VIDAS FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :WNUM-CERTIFICADO AND DATA_INIVIGENCIA <= :MDATA-OPERACAO AND DATA_TERVIGENCIA >= :MDATA-OPERACAO FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var m_625_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1 = new M_625_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1()
            {
                WNUM_CERTIFICADO = WNUM_CERTIFICADO.ToString(),
                MDATA_OPERACAO = MDATA_OPERACAO.ToString(),
            };

            var executed_1 = M_625_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1.Execute(m_625_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WPRM_VG_ATU, WPRM_VG_ATU);
                _.Move(executed_1.WPRM_AP_ATU, WPRM_AP_ATU);
                _.Move(executed_1.WIMP_MORNATU_ATU, WIMP_MORNATU_ATU);
                _.Move(executed_1.WIMP_MORACID_ATU, WIMP_MORACID_ATU);
                _.Move(executed_1.WQUANT_VIDAS, WQUANT_VIDAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_625_999_EXIT*/

        [StopWatch]
        /*" M-630-000-CONSULTA-HISCOBER-SECTION */
        private void M_630_000_CONSULTA_HISCOBER_SECTION()
        {
            /*" -2578- MOVE '630-000-CONSULTA-HISCOBER' TO PARAGRAFO */
            _.Move("630-000-CONSULTA-HISCOBER", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2581- MOVE '630' TO WNR-EXEC-SQL */
            _.Move("630", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2596- PERFORM M_630_000_CONSULTA_HISCOBER_DB_SELECT_1 */

            M_630_000_CONSULTA_HISCOBER_DB_SELECT_1();

            /*" -2599- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -2601- DISPLAY 'VG0030B-PROBLEMAS SELECT HISCOBERPROP ' MNUM-CERTIFICADO '   ' SQLCODE */

                $"VG0030B-PROBLEMAS SELECT HISCOBERPROP {MNUM_CERTIFICADO}   {DB.SQLCODE}"
                .Display();

                /*" -2602- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -2602- END-IF. */
            }


        }

        [StopWatch]
        /*" M-630-000-CONSULTA-HISCOBER-DB-SELECT-1 */
        public void M_630_000_CONSULTA_HISCOBER_DB_SELECT_1()
        {
            /*" -2596- EXEC SQL SELECT VALUE(PRMVG, 0), VALUE(PRMAP, 0), VALUE(IMP_MORNATU, 0), VALUE(IMPMORACID, 0) INTO :MPRM-VG-ATU, :MPRM-AP-ATU, :MIMP-MORNATU-ATU, :MIMP-MORACID-ATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' ORDER BY OCORR_HISTORICO DESC FETCH FIRST 1 ROW ONLY WITH UR END-EXEC */

            var m_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1 = new M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1.Execute(m_630_000_CONSULTA_HISCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MPRM_VG_ATU, MPRM_VG_ATU);
                _.Move(executed_1.MPRM_AP_ATU, MPRM_AP_ATU);
                _.Move(executed_1.MIMP_MORNATU_ATU, MIMP_MORNATU_ATU);
                _.Move(executed_1.MIMP_MORACID_ATU, MIMP_MORACID_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_630_999_EXIT*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -2611- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2613- MOVE 'R7777-CONS-MODALIDADE-APOL' TO PARAGRAFO */
            _.Move("R7777-CONS-MODALIDADE-APOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2615- INITIALIZE REGISTRO-LINKAGE-GE0510S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -2616- MOVE MNUM-APOLICE TO LK-GE510-NUM-APOLICE */
            _.Move(MNUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -2618- MOVE MCOD-SUBGRUPO TO LK-GE510-COD-SUBGRUPO */
            _.Move(MCOD_SUBGRUPO, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -2620- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S. */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -2621- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -2622- MOVE LK-GE510-COD-MODALIDADE TO V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, V0APOL_MODALIDA);

                /*" -2623- ELSE */
            }
            else
            {


                /*" -2624- DISPLAY ' ' */
                _.Display($" ");

                /*" -2625- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2626- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -2627- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -2628- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2629- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -2630- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -2631- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -2632- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -2633- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -2634- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -2635- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -2636- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2637- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -2638- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" M-8888-DISPLAY-TOTAIS-SECTION */
        private void M_8888_DISPLAY_TOTAIS_SECTION()
        {
            /*" -2649- ADD 1 TO WS-COUNT. */
            WS_AUXILIARES.WS_COUNT.Value = WS_AUXILIARES.WS_COUNT + 1;

            /*" -2650- IF (ON-COUNTER EQUAL ZEROS) */

            if ((WS_AUXILIARES.ON_INTERVAL.ON_COUNTER == 00))
            {

                /*" -2651- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_AUXILIARES.WS_TIME);

                /*" -2652- MOVE WS-COUNT TO WS-QTD-DISPLAY */
                _.Move(WS_AUXILIARES.WS_COUNT, WS_QTD_DISPLAY);

                /*" -2655- DISPLAY 'QUANT. LIDOS ' WS-QTD-DISPLAY ' - ' WS-TIME ' - ' MNUM-APOLICE ' - ' MCOD-SUBGRUPO ' - ' MNUM-PROPOSTA ' - ' MNUM-CERTIFICADO */

                $"QUANT. LIDOS WS-QTD- - {WS_AUXILIARES.WS_TIME} - {MNUM_APOLICE} - {MCOD_SUBGRUPO} - {MNUM_PROPOSTA} - {MNUM_CERTIFICADO}"
                .Display();

                /*" -2657- END-IF. */
            }


            /*" -2657- MOVE MNUM-APOLICE TO WAPOLICE-ATU. */
            _.Move(MNUM_APOLICE, WS_AUXILIARES.WAPOLICE_ATU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8888_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -2668- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2671- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2672- DISPLAY 'LIDOS NO CURSOR........... ' AC-GRAVA-LID */
            _.Display($"LIDOS NO CURSOR........... {WS_AUXILIARES.AC_GRAVA_LID}");

            /*" -2673- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2674- DISPLAY '        CANCELAMENTOS EFETIVADOS       ' */
            _.Display($"        CANCELAMENTOS EFETIVADOS       ");

            /*" -2675- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2676- DISPLAY 'INSERIDOS NA HISTSEGVG ... ' AC-GRAVA-HIS */
            _.Display($"INSERIDOS NA HISTSEGVG ... {WS_AUXILIARES.AC_GRAVA_HIS}");

            /*" -2677- DISPLAY 'UPDATE    NA PROPOSTA-VA.. ' AC-GRAVA-PRO */
            _.Display($"UPDATE    NA PROPOSTA-VA.. {WS_AUXILIARES.AC_GRAVA_PRO}");

            /*" -2678- DISPLAY 'UPDATE    NA CARENCIA..... ' AC-GRAVA-CAR */
            _.Display($"UPDATE    NA CARENCIA..... {WS_AUXILIARES.AC_GRAVA_CAR}");

            /*" -2679- DISPLAY 'UPDATE    NA SEGURADOS ... ' AC-GRAVA-SEG */
            _.Display($"UPDATE    NA SEGURADOS ... {WS_AUXILIARES.AC_GRAVA_SEG}");

            /*" -2680- DISPLAY 'UPDATE    NA MOVIMENTO ... ' AC-GRAVA-MOV */
            _.Display($"UPDATE    NA MOVIMENTO ... {WS_AUXILIARES.AC_GRAVA_MOV}");

            /*" -2681- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2682- DISPLAY '       CANCELAMENTOS NAO EFETIVADO      ' */
            _.Display($"       CANCELAMENTOS NAO EFETIVADO      ");

            /*" -2683- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2684- DISPLAY 'ERRO JAH CANCELADOS....... ' AC-GRAVA-CAN */
            _.Display($"ERRO JAH CANCELADOS....... {WS_AUXILIARES.AC_GRAVA_CAN}");

            /*" -2685- DISPLAY 'ERRO PREMIOS ZERADOS...... ' AC-GRAVA-PRM-ZEROS */
            _.Display($"ERRO PREMIOS ZERADOS...... {WS_AUXILIARES.AC_GRAVA_PRM_ZEROS}");

            /*" -2686- DISPLAY 'ERRO IMPORTANCIA ZERADA... ' AC-GRAVA-IMP-ZEROS */
            _.Display($"ERRO IMPORTANCIA ZERADA... {WS_AUXILIARES.AC_GRAVA_IMP_ZEROS}");

            /*" -2687- DISPLAY 'ERRO SEM COBERAPOL........ ' AC-ERRO-COBERAPOL */
            _.Display($"ERRO SEM COBERAPOL........ {WS_AUXILIARES.AC_ERRO_COBERAPOL}");

            /*" -2688- DISPLAY 'ERRO FONTE ZERADA......... ' AC-ERRO-FONTE */
            _.Display($"ERRO FONTE ZERADA......... {WS_AUXILIARES.AC_ERRO_FONTE}");

            /*" -2689- DISPLAY 'ERRO MOVIMENTOS PENDENTES. ' AC-ERRO-MOV */
            _.Display($"ERRO MOVIMENTOS PENDENTES. {WS_AUXILIARES.AC_ERRO_MOV}");

            /*" -2690- DISPLAY 'ERRO VG PRODUTO........... ' AC-GRAVA-VG-PRODUTO */
            _.Display($"ERRO VG PRODUTO........... {WS_AUXILIARES.AC_GRAVA_VG_PRODUTO}");

            /*" -2691- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2692- DISPLAY 'FIM NORMAL      **** VG0030B ****' . */
            _.Display($"FIM NORMAL      **** VG0030B ****");

            /*" -2693- DISPLAY '----------------------------------------' */
            _.Display($"----------------------------------------");

            /*" -2694- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -2694- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -2707- DISPLAY MNUM-APOLICE ' ' MNUM-CERTIFICADO ' ' MCOD-SUBGRUPO ' ' SNUM-ITEM. */

            $"{MNUM_APOLICE} {MNUM_CERTIFICADO} {MCOD_SUBGRUPO} {SNUM_ITEM}"
            .Display();

            /*" -2708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2709- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WS_AUXILIARES.WABEND.WSQLCODE);

                /*" -2710- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WS_AUXILIARES.WABEND.WSQLCODE1);

                /*" -2711- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WS_AUXILIARES.WABEND.WSQLCODE2);

                /*" -2712- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WS_AUXILIARES.WSQLCODE3);

                /*" -2714- DISPLAY WABEND. */
                _.Display(WS_AUXILIARES.WABEND);
            }


            /*" -2716- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2720- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2723- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -2723- GOBACK. */

            throw new GoBack();

        }
    }
}