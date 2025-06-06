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
using Sias.VidaEmGrupo.DB2.VG0010B;

namespace Code
{
    public class VG0010B
    {
        public bool IsCall { get; set; }

        public VG0010B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *                *** INCLUSAO ***                                *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  LE TABELA MOVIMENTO E INCLUI DADOS *      */
        /*"      *                             NAS TABELAS ..:V0SEGURAVG          *      */
        /*"      *                                            V0COBERAPOL         *      */
        /*"      *                                            V0HISTSEGVG         *      */
        /*"      *                                            V0CONTACOR          *      */
        /*"      *   ANALISTA/PROGRAMADOR....  PROCAS                             *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0010B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  AGOSTO/ 91                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACOES:                                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 31 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 181569.                                *      */
        /*"=     *    EM 25/01/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30 - CADMUS 154.956                                   *      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29 - CAD 135.031                                      *      */
        /*"      *             - VERIFICAR SE O NUM-ITEM DA SEGURADOS_VGAP COM  A *      */
        /*"      *               APOLICE, CONSIDERANDO SEMPRE O MAIOR NUM-ITEM    *      */
        /*"      *               ENCONTRADO, EVITANDO O SQLCODE -803              *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/04/2016 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28 - VERIFICAR SE O NUM-ITEM DA HISTORICO_SEGURADOS   *      */
        /*"      *               EH A MESMA DA TABELA APOLICES, CONSIDERANDO      *      */
        /*"      *               O MAIOR NUM-ITEM PARA FAZER UPDATE NAS TABELAS   *      */
        /*"      *               SQLCODE -803                                     *      */
        /*"      *                                                                *      */
        /*"      *             - CONTINUAR PROCESSAMENTO DO REGISTRO MESMO COM    *      */
        /*"      *               SQLCODE -803 QUANDO O CERTIFICADO JAH EXISTIR NA *      */
        /*"      *               SEGURADOS-VGAP                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/08/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.28         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.27         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 26 - CAD 117.272                                      *      */
        /*"      *                                                                *      */
        /*"      *          - CORRECAO NO PROGRAMA PARA INTEGRAR CERTIFICADOS     *      */
        /*"      *      INSERIDOS PELA CENTRAL DE RELACIONAMENTO/CALL CENTER      *      */
        /*"      *      ATRAVES DO SIAS E QUE JA POSSUEM REGISTROS NA TABELA      *      */
        /*"      *      SEGURADOS_VGAP.                                           *      */
        /*"      *                                                                *      */
        /*"      *          - ESTA MODIFICACAO FOI NECESSARIA POIS ESTES CERTIFI- *      */
        /*"      *      CADOS NAO ERAM INTEGRADOS CORRETAMENTE DEIXANDO AS TABELAS*      */
        /*"      *      SEGURADOSVGAP_HIST E APOLICE_COBERTURAS SEM REGISTROS E   *      */
        /*"      *      CAUSANDO IMPACTO EM DIVERSAS AREAS E TAMBEM NA CONSULTA DO*      */
        /*"      *      SOL/SIAC.                                                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/06/2015 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - CAD 74.584                                       *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NO CONTEUDO DO CAMPO VGMODALIFR              *      */
        /*"      *          - AJUSTE NO CONTEUDO DO CAMPO COD-CCT                 *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/10/2014 - JONNY ANDERSON C.SARAIVA                     *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.25    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 - CAD 74.584                                       *      */
        /*"      *                                                                *      */
        /*"      *          - AJUSTE NA OBTENCAO DO PERI_PAGAMENTO                *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/10/2012 - PEDRO SILVERIO (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.24    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - CAD 75.189                                       *      */
        /*"      *                                                                *      */
        /*"      *          - CORRECAO DO ABEND (PROBLEMAS ACESSO A PRODUTOS_VG)  *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/10/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.23    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - CAD 75.127                                       *      */
        /*"      *                                                                *      */
        /*"      *          - CORRECAO DO ABEND (PROBLEMAS ACESSO A PROPOSTA_VA)  *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2012 - AUGUSTO ANASTACIO (FAST COMPUTER)            *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.22    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 75.033                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CORRECAO DO ABEND (SQLCODE = -305) NA TABELA     *      */
        /*"      *               SEGUROS.PRODUTOS_VG.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/10/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.21    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 73.275                                       *      */
        /*"      *                                                                *      */
        /*"      *             - NAO GRAVAR VIGENCIA 9999-12-31 PARA PRODUTOS DE  *      */
        /*"      *               PAGAMENTO UNICO                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/08/2012 - AUGUSTO ANASTACIO  (FAST COMPUTER)           *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.20    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - CAD 51.522                                       *      */
        /*"      *             - AJUSTA O INSERT DA TABELA SEGUROS.BENEFICIARIOS  *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/12/2010 - EDIVALDO GOMES  (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.19    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CAD 49.010                                       *      */
        /*"      *                                                                *      */
        /*"      *              - MANUTENCAO DE SEGURADOS DE SEGURO               *      */
        /*"      *                VIAGEM   VIA INTERFACE ARQUIVO DE               *      */
        /*"      *                PROPOSTAS BRASIL ASSISTENCIA.                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/11/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.18             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CAD 36.215                                       *      */
        /*"      *                                                                *      */
        /*"      *              - ALTARA��O NA MOVIMENTA��O DO CAMPO              *      */
        /*"      *                VGDATA-TERVIGENCIA                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.17             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CAD 36.082                                       *      */
        /*"      *                                                                *      */
        /*"      *              - ALTARA��O NA CONSULTA NA TABELA PROPOSTA_FIDELIZ*      */
        /*"      *                                                                *      */
        /*"      *   EM 22/01/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.16             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CADMUS  32423 - FAST COMPUTER - EDIVALDO GOMES                 *      */
        /*"      *                                                                *      */
        /*"      * 11/11/2009   CORRECAO DA DATA DE TERVIGENCIA PARA CERTIFICADOS *      */
        /*"      *              DA APOLICE 107700000013                           *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE POR V.15   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CADMUS  28889 - FAST COMPUTER - EDIVALDO GOMES                 *      */
        /*"      *                                                                *      */
        /*"      * 09/09/2009   CRIACAO DOS RELATORIOS DE ERRO NA ROTINA.         *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURE POR V.14   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CADMUS  16364 - FAST COMPUTER                                  *      */
        /*"      *                                                                *      */
        /*"      * 24/10/2008   CORRECAO DA DATA TERVIGENCIA DO BENEFICIARIO      *      */
        /*"      *                                             PROCURE POR V.13   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CADMUS  15639 - FAST COMPUTER                                  *      */
        /*"      *                                                                *      */
        /*"      * 07/10/2008   CORRECAO DO ABEND OCORRIDO NA TABELA              *      */
        /*"      *              PROPOSTAS_FIDEL (SQLCODE = 100)                   *      */
        /*"      *                                             PROCURE POR V.12   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 12/08/2008   INIBIR O COMANDO DISPLAY               - WV0808   *      */
        /*"      * 11/09/2008   INCLUIR CLAUS WITH UR NO COMANDO SELECT- WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 10.559                                       *      */
        /*"      *               PAGAMENTO UNICO COM VIGENCIA DE 36 MESES PARA    *      */
        /*"      *               OS PRODUTOS:                                     *      */
        /*"      *                  . 9318 - VIDA DA GENTE       - 109300001391   *      */
        /*"      *                  . 9327 - VIDA MULHER <=30000 - 109300001392   *      */
        /*"      *                  . 9327 - VIDA MULHER         - 109300001393   *      */
        /*"      *                  . 9309 - MULTIPREMIADO SUPER - 109300001394   *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/05/2008 - FAST COMPUTER            PROCURE POR V.11    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   V.10 - ALTERA��O PARA GERA��O DO TERMINO DE VIGENCIA PARA A  *      */
        /*"      *          APOLICE 010770000011 ( PROD 77 - PRESTAMISTAS )       *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   WANGER - FAST COMPUTER   19/02/2008      PROCURAR POR V.10   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   9. 14/06/06 - IMPLEMENTA TRATAMENTO DE SQLCODE               *      */
        /*"      *                 (PROCURAR POR V.09) - LUCIA VIEIRA             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   8. 13/04/06 - DESFAZER O CONTROLE DE OCORRENCIA DA APOLICE   *      */
        /*"      *                 DO CONSORCIO POIS ESTAVA DESPONTERANDO AS      *      */
        /*"      *                 TABELAS. (PROCURAR POR FC0604)                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   7. 17/12/01 - A COLUNA LOT_EMP_SEGURADO DA SEGURADOS_VGAP    *      */
        /*"      *                 PASSA A CONTER A LOTACAO DO EMPREGADO PARA A   *      */
        /*"      *                 APOLICE 109300000567 IMAP (PROCURAR POR AUREL) *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   6. 18/01/99 - A COLUNA DATA_ADMISSAO DA SEGURADOS_VGAP       *      */
        /*"      *                 PASSA A CONTER A DATA DE TERMINO DE VIGENCIA   *      */
        /*"      *                 PARA CADA SEGURADO.      (PROCURE TL9901)      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   5. 25/02/97 - INCLUIDAS AS COLUNAS OPCAO_CAPITALIZ           *      */
        /*"      *                 EM V0CONTACOR                (TERCIO)          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   4. 12/05/95 - INCLUIDAS AS COLUNAS OPCAOPAG E DIA_DEBITO     *      */
        /*"      *                 EM V0CONTACOR                (FONSECA)         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   3. 12/07/94 - TRATAMENTO DO CODIGO DA MOEDA DO HISTORICO     *      */
        /*"      *                                              (FONSECA)         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   2. 19/05/94 - INSERIDA A COLUNA AGENCIA_ORIGEM  NO INSERT DA *      */
        /*"      *                 TABELA CONTA_CORRENTE        (FONSECA)         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   1. 25/05/92 - INSERIDA A COLUNA NUM_CERTIFICADO NO INSERT DA *      */
        /*"      *                 TABELA CONTA_CORRENTE        (FONSECA)         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 28/05/1998.   *      */
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
        /*"01            RECORD-DSAIDA       PIC X(200).*/
        public StringBasis RECORD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            RECORD-SSAIDA       PIC X(250).*/
        public StringBasis RECORD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "250", "X(250)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WK-COD-CCT                 PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WK_COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  WK-DATA-TERVIG              PIC  X(010).*/
        public StringBasis WK_DATA_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WK-COD-PLANO                PIC S9(004)     COMP.*/
        public IntBasis WK_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  MNUM-CERTIFICADO           PIC S9(015)      COMP-3.*/
        public IntBasis MNUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V0RELA-NRCERTIF            PIC S9(015)      COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
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
        /*"77  CDATA-NASCIMENTO           PIC  X(010).*/
        public StringBasis CDATA_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-FATURA               PIC  X(010).*/
        public StringBasis MDATA_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-REFERENCIA           PIC  X(010).*/
        public StringBasis MDATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-MOVIMENTO            PIC  X(010).*/
        public StringBasis MDATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MDATA-RENOVACAO            PIC  X(010).*/
        public StringBasis MDATA_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  MCOD-EMPRESA               PIC S9(009)      COMP.*/
        public IntBasis MCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  MLOT-EMP-SEGURADO          PIC  X(030).*/
        public StringBasis MLOT_EMP_SEGURADO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77  H-NUM-CERTIFICADO          PIC S9(015)      COMP-3.*/
        public IntBasis H_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  H-DAC-CERTIFICADO          PIC  X(001).*/
        public StringBasis H_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0NUM-APOLICE             PIC S9(013)      COMP-3.*/
        public IntBasis V0NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  SNUM-ITEM                 PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SNUM-ITEM-HIST            PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM_HIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SNUM-ITEM-SEGUR           PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM_SEGUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0APOL-RAMO               PIC S9(004)      COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0APOL-MODALIDA           PIC S9(004)      COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  DVLCRUZAD-IMP             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  DVLCRUZAD-PRM             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  NUMCERVG                   PIC S9(015)      COMP-3.*/
        public IntBasis NUMCERVG { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77  V1SISTEMA-DTMOVABE        PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1SISTEMA-CURRDATE        PIC  X(010).*/
        public StringBasis V1SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77  DTINIVIG                  PIC  X(010).*/
        public StringBasis DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  DTTERVIG                  PIC  X(010).*/
        public StringBasis DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77  VGCOD-EMPRESA             PIC S9(009)      COMP.*/
        public IntBasis VGCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  VGCOD-SITUACAO            PIC  X(001).*/
        public StringBasis VGCOD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  VGCOD-SIT-I               PIC  S9(004) COMP.*/
        public IntBasis VGCOD_SIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SEGUR-OCORHIST            PIC S9(004)      COMP.*/
        public IntBasis SEGUR_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SQL-NOT-NULL              PIC S9(04) COMP VALUE +1.*/
        public IntBasis SQL_NOT_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"), +1);
        /*"77  HHORA-OPERACAO            PIC  X(008).*/
        public StringBasis HHORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  HOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis HOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HCOD-SUBGRUP-TRANS        PIC S9(004)      COMP.*/
        public IntBasis HCOD_SUBGRUP_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  NUM-APOLICE               PIC S9(013)      COMP-3.*/
        public IntBasis NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  COD-SUBGRUPO              PIC S9(004)      COMP.*/
        public IntBasis COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  COD-FONTE                 PIC S9(004)      COMP.*/
        public IntBasis COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  NUM-PROPOSTA              PIC S9(009)      COMP.*/
        public IntBasis NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  NUM-BENEFICIARIO          PIC S9(004)      COMP.*/
        public IntBasis NUM_BENEFICIARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  NOME-BENEFICIARIO         PIC  X(040).*/
        public StringBasis NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  GRAU-PARENTESCO           PIC  X(010).*/
        public StringBasis GRAU_PARENTESCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  PCT-PART-BENEFICIA        PIC S9(003)V99   COMP-3.*/
        public DoubleBasis PCT_PART_BENEFICIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  COD-USUARIO               PIC  X(008).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  COD-EMPRESA               PIC S9(009)      COMP.*/
        public IntBasis COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  DAC-CERTIFICADO           PIC  X(001).*/
        public StringBasis DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0BANC-NRTIT       PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WDATA-AVERBACAO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-ADMISSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-INCLUSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASCIMENTO          PIC S9(004)      COMP.*/
        public IntBasis WDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CWDATA-NASCIMENTO         PIC S9(004)      COMP.*/
        public IntBasis CWDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-FATURA              PIC S9(004)      COMP.*/
        public IntBasis WDATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-REFERENCIA          PIC S9(004)      COMP.*/
        public IntBasis WDATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-RENOVACAO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-EMPRESA              PIC S9(004)      COMP.*/
        public IntBasis WCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WLOT-EMP-SEGURADO         PIC S9(004)      COMP.*/
        public IntBasis WLOT_EMP_SEGURADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-MOEDA                PIC S9(004)      COMP VALUE +1.*/
        public IntBasis WCOD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP.*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WNUM-CCT                  PIC S9(004)      COMP.*/
        public IntBasis WNUM_CCT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"03  W-SEGURO-DUPLICADO        PIC  X(001).*/
        public StringBasis W_SEGURO_DUPLICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"03  W-SEGURO-INTEGRIDADE      PIC  X(001).*/
        public StringBasis W_SEGURO_INTEGRIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"03  W-DATA-TRABALHO           PIC  X(010).*/
        public StringBasis W_DATA_TRABALHO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"03  FILLER REDEFINES W-DATA-TRABALHO.*/
        private _REDEF_VG0010B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VG0010B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VG0010B_FILLER_0(); _.Move(W_DATA_TRABALHO, _filler_0); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_0, W_DATA_TRABALHO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_DATA_TRABALHO); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_DATA_TRABALHO); }
        }  //Redefines
        public class _REDEF_VG0010B_FILLER_0 : VarBasis
        {
            /*"    05  W-AS-TRABALHO         PIC  9(004).*/
            public IntBasis W_AS_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  FILLER                PIC  X(001).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  W-MM-TRABALHO         PIC  9(002).*/
            public IntBasis W_MM_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05  FILLER                PIC  X(001).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05  W-DD-TRABALHO         PIC  9(002).*/
            public IntBasis W_DD_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"03  W-AS-MM-RENOVACAO         PIC  9(006).*/

            public _REDEF_VG0010B_FILLER_0()
            {
                W_AS_TRABALHO.ValueChanged += OnValueChanged;
                FILLER_1.ValueChanged += OnValueChanged;
                W_MM_TRABALHO.ValueChanged += OnValueChanged;
                FILLER_2.ValueChanged += OnValueChanged;
                W_DD_TRABALHO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_AS_MM_RENOVACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        /*"03  FILLER REDEFINES W-AS-MM-RENOVACAO.*/
        private _REDEF_VG0010B_FILLER_3 _filler_3 { get; set; }
        public _REDEF_VG0010B_FILLER_3 FILLER_3
        {
            get { _filler_3 = new _REDEF_VG0010B_FILLER_3(); _.Move(W_AS_MM_RENOVACAO, _filler_3); VarBasis.RedefinePassValue(W_AS_MM_RENOVACAO, _filler_3, W_AS_MM_RENOVACAO); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_AS_MM_RENOVACAO); }; return _filler_3; }
            set { VarBasis.RedefinePassValue(value, _filler_3, W_AS_MM_RENOVACAO); }
        }  //Redefines
        public class _REDEF_VG0010B_FILLER_3 : VarBasis
        {
            /*"    05  W-AS-RENOVACAO        PIC  9(004).*/
            public IntBasis W_AS_RENOVACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  W-MM-RENOVACAO        PIC  9(002).*/
            public IntBasis W_MM_RENOVACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"03  W-AS-MM-CURRDATE          PIC  9(006).*/

            public _REDEF_VG0010B_FILLER_3()
            {
                W_AS_RENOVACAO.ValueChanged += OnValueChanged;
                W_MM_RENOVACAO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis W_AS_MM_CURRDATE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        /*"03  FILLER REDEFINES W-AS-MM-CURRDATE.*/
        private _REDEF_VG0010B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_VG0010B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_VG0010B_FILLER_4(); _.Move(W_AS_MM_CURRDATE, _filler_4); VarBasis.RedefinePassValue(W_AS_MM_CURRDATE, _filler_4, W_AS_MM_CURRDATE); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_AS_MM_CURRDATE); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, W_AS_MM_CURRDATE); }
        }  //Redefines
        public class _REDEF_VG0010B_FILLER_4 : VarBasis
        {
            /*"    05  W-AS-CURRDATE         PIC  9(004).*/
            public IntBasis W_AS_CURRDATE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05  W-MM-CURRDATE         PIC  9(002).*/
            public IntBasis W_MM_CURRDATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"03            AC-DUPLICIDADE      PIC  9(007) VALUE ZEROS.*/

            public _REDEF_VG0010B_FILLER_4()
            {
                W_AS_CURRDATE.ValueChanged += OnValueChanged;
                W_MM_CURRDATE.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis AC_DUPLICIDADE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"03            AC-GRAVA            PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"03            AC-GRAVA-2          PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_GRAVA_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"03            AC-ERRO-DADOS       PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_ERRO_DADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"03            AC-ERRO-SISTEMA     PIC  9(006) VALUE ZEROS.*/
        public IntBasis AC_ERRO_SISTEMA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"03            WS-DESPREZA         PIC  X(001) VALUE SPACES.*/
        public StringBasis WS_DESPREZA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"03            WSQLCODE3           PIC S9(009) COMP.*/
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"03            WS-W01DTSQL.*/
        public VG0010B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0010B_WS_W01DTSQL();
        public class VG0010B_WS_W01DTSQL : VarBasis
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
            /*"03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
        }
        public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"03            WFIM-BENEFIPROP     PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_BENEFIPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03  WNUM-PROPOSTA-ATU.*/
        public VG0010B_WNUM_PROPOSTA_ATU WNUM_PROPOSTA_ATU { get; set; } = new VG0010B_WNUM_PROPOSTA_ATU();
        public class VG0010B_WNUM_PROPOSTA_ATU : VarBasis
        {
            /*"   05 WFONTE-ATU                    PIC S9(004) VALUE +0 COMP.*/
            public IntBasis WFONTE_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 WPROPOSTA-ATU                 PIC S9(009) VALUE +0 COMP.*/
            public IntBasis WPROPOSTA_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WNUM-PROPOSTA-ANT.*/
        }
        public VG0010B_WNUM_PROPOSTA_ANT WNUM_PROPOSTA_ANT { get; set; } = new VG0010B_WNUM_PROPOSTA_ANT();
        public class VG0010B_WNUM_PROPOSTA_ANT : VarBasis
        {
            /*"   05 WFONTE-ANT                    PIC S9(004) VALUE +0 COMP.*/
            public IntBasis WFONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 WPROPOSTA-ANT                 PIC S9(009) VALUE +0 COMP.*/
            public IntBasis WPROPOSTA_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WANO-BISSEXTO                 PIC  9(004) VALUE ZEROS.*/
        }
        public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"  03  WPRIMEIRA-VEZ                 PIC  X(001) VALUE 'S'.*/
        public StringBasis WPRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
        /*"  03            WAPOLICE-ATU        PIC S9(013) VALUE +0 COMP-3.*/
        public IntBasis WAPOLICE_ATU { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"  03            WAPOLICE-ANT        PIC S9(013) VALUE +0 COMP-3.*/
        public IntBasis WAPOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"  03            WHORA-OPERACAO-WORK.*/
        public VG0010B_WHORA_OPERACAO_WORK WHORA_OPERACAO_WORK { get; set; } = new VG0010B_WHORA_OPERACAO_WORK();
        public class VG0010B_WHORA_OPERACAO_WORK : VarBasis
        {
            /*"    05          WHORA-HORA          PIC  X(002).*/
            public StringBasis WHORA_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05          FILLER              PIC  X(001)  VALUE '.'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
            /*"    05          WHORA-MINU          PIC  X(002).*/
            public StringBasis WHORA_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    05          FILLER              PIC  X(001) VALUE '.'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
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
        /*"  03            WHORA-OPERACAO.*/
        public VG0010B_WHORA_OPERACAO WHORA_OPERACAO { get; set; } = new VG0010B_WHORA_OPERACAO();
        public class VG0010B_WHORA_OPERACAO : VarBasis
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
        /*"  03            WHORA-OPERACAO-1    PIC 99999999.*/
        public IntBasis WHORA_OPERACAO_1 { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
        /*"  03            WHORA-PER-X         REDEFINES                WHORA-OPERACAO-1.*/
        private _REDEF_VG0010B_WHORA_PER_X _whora_per_x { get; set; }
        public _REDEF_VG0010B_WHORA_PER_X WHORA_PER_X
        {
            get { _whora_per_x = new _REDEF_VG0010B_WHORA_PER_X(); _.Move(WHORA_OPERACAO_1, _whora_per_x); VarBasis.RedefinePassValue(WHORA_OPERACAO_1, _whora_per_x, WHORA_OPERACAO_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, WHORA_OPERACAO_1); }; return _whora_per_x; }
            set { VarBasis.RedefinePassValue(value, _whora_per_x, WHORA_OPERACAO_1); }
        }  //Redefines
        public class _REDEF_VG0010B_WHORA_PER_X : VarBasis
        {
            /*"     05         WHORA-OPERACAO-2    PIC 999999.*/
            public IntBasis WHORA_OPERACAO_2 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
            /*"     05         FILLER              PIC 99.*/
            public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"  03            WPRMTOT             PIC S9(013)V99                                        VALUE +0 COMP-3.*/

            public _REDEF_VG0010B_WHORA_PER_X()
            {
                WHORA_OPERACAO_2.ValueChanged += OnValueChanged;
                FILLER_7.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"  03            W01DIGCERT.*/
        public VG0010B_W01DIGCERT W01DIGCERT { get; set; } = new VG0010B_W01DIGCERT();
        public class VG0010B_W01DIGCERT : VarBasis
        {
            /*"    05          WCERTIFICADO    PIC  9(015)        VALUE  0.*/
            public IntBasis WCERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05          WNUMERO         PIC S9(004)  COMP  VALUE +15.*/
            public IntBasis WNUMERO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +15);
            /*"    05          WDIG            PIC  X(001)  VALUE SPACES.*/
            public StringBasis WDIG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03      HD-REG-DSAIDA.*/
        }
        public VG0010B_HD_REG_DSAIDA HD_REG_DSAIDA { get; set; } = new VG0010B_HD_REG_DSAIDA();
        public class VG0010B_HD_REG_DSAIDA : VarBasis
        {
            /*"    05    HD-COD-PRO-DSAIDA   PIC  X(008)   VALUE 'VG0010B'.*/
            public StringBasis HD_COD_PRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0010B");
            /*"    05    HD-DES-REL-DSAIDA   PIC  X(050)   VALUE    'RELATORIO DE ERROS DE DADOS'.*/
            public StringBasis HD_DES_REL_DSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE DADOS");
            /*"    05    HD-DTA-SIS-DSAIDA   PIC  X(010)   VALUE SPACES.*/
            public StringBasis HD_DTA_SIS_DSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03      CB-REG-DSAIDA.*/
        }
        public VG0010B_CB_REG_DSAIDA CB_REG_DSAIDA { get; set; } = new VG0010B_CB_REG_DSAIDA();
        public class VG0010B_CB_REG_DSAIDA : VarBasis
        {
            /*"    05    FILLER              PIC  X(045)   VALUE    'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
            /*"    05    FILLER              PIC  X(042)   VALUE    'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
            /*"    05    FILLER              PIC  X(033)   VALUE    'DETALHAMENTO DO PROBLEMA OCORRIDO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO");
            /*"  03      LD-REG-DSAIDA.*/
        }
        public VG0010B_LD_REG_DSAIDA LD_REG_DSAIDA { get; set; } = new VG0010B_LD_REG_DSAIDA();
        public class VG0010B_LD_REG_DSAIDA : VarBasis
        {
            /*"    05    LD-NUM-APOL-DSAIDA         PIC 9(013).*/
            public IntBasis LD_NUM_APOL_DSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-COD-SUBG-DSAIDA         PIC 9(004).*/
            public IntBasis LD_COD_SUBG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-COD-PROD-DSAIDA         PIC 9(004).*/
            public IntBasis LD_COD_PROD_DSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NOM-PROD-DSAIDA         PIC X(030).*/
            public StringBasis LD_NOM_PROD_DSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NUM-CERT-SUB-DSAIDA     PIC 9(015).*/
            public IntBasis LD_NUM_CERT_SUB_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NUM-CERT-SEG-DSAIDA     PIC 9(015).*/
            public IntBasis LD_NUM_CERT_SEG_DSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-DES-ERRO-DSAIDA         PIC X(080).*/
            public StringBasis LD_DES_ERRO_DSAIDA { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  03      HD-REG-SSAIDA.*/
        }
        public VG0010B_HD_REG_SSAIDA HD_REG_SSAIDA { get; set; } = new VG0010B_HD_REG_SSAIDA();
        public class VG0010B_HD_REG_SSAIDA : VarBasis
        {
            /*"    05    HD-COD-PRO-SSAIDA   PIC  X(008)   VALUE 'VG0010B'.*/
            public StringBasis HD_COD_PRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0010B");
            /*"    05    HD-DES-REL-SSAIDA   PIC  X(050)   VALUE    'RELATORIO DE ERROS DE SISTEMAS'.*/
            public StringBasis HD_DES_REL_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"RELATORIO DE ERROS DE SISTEMAS");
            /*"    05    HD-DTA-SIS-SSAIDA   PIC  X(010)   VALUE SPACES.*/
            public StringBasis HD_DTA_SIS_SSAIDA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03      CB-REG-SSAIDA.*/
        }
        public VG0010B_CB_REG_SSAIDA CB_REG_SSAIDA { get; set; } = new VG0010B_CB_REG_SSAIDA();
        public class VG0010B_CB_REG_SSAIDA : VarBasis
        {
            /*"    05    FILLER              PIC  X(045)   VALUE    'APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"APOLICE;SUBGRUPO;CODIGO PRODUTO;NOME PRODUTO;");
            /*"    05    FILLER              PIC  X(042)   VALUE    'CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"CERTIFICADO SUBGRUPO;CERTIFICADO SEGURADO;");
            /*"    05    FILLER              PIC  X(035)   VALUE    'CODIGO ERRO DB2;DESCRICAO ERRO DB2;'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"CODIGO ERRO DB2;DESCRICAO ERRO DB2;");
            /*"    05    FILLER              PIC  X(034)   VALUE    'DETALHAMENTO DO PROBLEMA OCORRIDO;'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"DETALHAMENTO DO PROBLEMA OCORRIDO;");
            /*"    05    FILLER              PIC  X(016)   VALUE    'PROGRAMA'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PROGRAMA");
            /*"  03      LD-REG-SSAIDA.*/
        }
        public VG0010B_LD_REG_SSAIDA LD_REG_SSAIDA { get; set; } = new VG0010B_LD_REG_SSAIDA();
        public class VG0010B_LD_REG_SSAIDA : VarBasis
        {
            /*"    05    LD-NUM-APOL-SSAIDA         PIC 9(013).*/
            public IntBasis LD_NUM_APOL_SSAIDA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-COD-SUBG-SSAIDA         PIC 9(004).*/
            public IntBasis LD_COD_SUBG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-COD-PROD-SSAIDA         PIC 9(004).*/
            public IntBasis LD_COD_PROD_SSAIDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NOM-PROD-SSAIDA         PIC X(030).*/
            public StringBasis LD_NOM_PROD_SSAIDA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NUM-CERT-SUB-SSAIDA     PIC 9(015).*/
            public IntBasis LD_NUM_CERT_SUB_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NUM-CERT-SEG-SSAIDA     PIC 9(015).*/
            public IntBasis LD_NUM_CERT_SEG_SSAIDA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-COD-ERRO-DB2-SSAIDA     PIC -9(004).*/
            public IntBasis LD_COD_ERRO_DB2_SSAIDA { get; set; } = new IntBasis(new PIC("-9", "4", "-9(004)."));
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-DES-ERRO-DB2-SSAIDA     PIC X(050).*/
            public StringBasis LD_DES_ERRO_DB2_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-DES-ERRO-SSAIDA         PIC X(050).*/
            public StringBasis LD_DES_ERRO_SSAIDA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"    05    FILLER                     PIC X(001)  VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    05    LD-NOM-PROG-SSAIDA        PIC X(008) VALUE 'VG0010B'.*/
            public StringBasis LD_NOM_PROG_SSAIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0010B");
            /*"  03        WABEND.*/
        }
        public VG0010B_WABEND WABEND { get; set; } = new VG0010B_WABEND();
        public class VG0010B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VG0010B'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0010B");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01  REGISTRO-LINKAGE-GE0510S.*/
        }
        public VG0010B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG0010B_REGISTRO_LINKAGE_GE0510S();
        public class VG0010B_REGISTRO_LINKAGE_GE0510S : VarBasis
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
            public VG0010B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG0010B_LK_GE510_MENSAGEM();
            public class VG0010B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01          LK-LINK.*/
            }
        }
        public VG0010B_LK_LINK LK_LINK { get; set; } = new VG0010B_LK_LINK();
        public class VG0010B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/
        }
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VG0010B_FILLER_38 _filler_38 { get; set; }
        public _REDEF_VG0010B_FILLER_38 FILLER_38
        {
            get { _filler_38 = new _REDEF_VG0010B_FILLER_38(); _.Move(W_NUMR_TITULO, _filler_38); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_38, W_NUMR_TITULO); _filler_38.ValueChanged += () => { _.Move(_filler_38, W_NUMR_TITULO); }; return _filler_38; }
            set { VarBasis.RedefinePassValue(value, _filler_38, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VG0010B_FILLER_38 : VarBasis
        {
            /*"  05    WTITL-ZEROS             PIC  9(002).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WTITL-SEQUENCIA         PIC  9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO            PIC  9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              DPARM01X.*/

            public _REDEF_VG0010B_FILLER_38()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public VG0010B_DPARM01X DPARM01X { get; set; } = new VG0010B_DPARM01X();
        public class VG0010B_DPARM01X : VarBasis
        {
            /*"  05            DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05            DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VG0010B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VG0010B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VG0010B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VG0010B_DPARM01_R : VarBasis
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

                public _REDEF_VG0010B_DPARM01_R()
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
        }


        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public VG0010B_TMOVIMENTO TMOVIMENTO { get; set; } = new VG0010B_TMOVIMENTO();
        public VG0010B_TBENEFIPROP TBENEFIPROP { get; set; } = new VG0010B_TBENEFIPROP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string DSAIDA_FILE_NAME_P, string SSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                DSAIDA.SetFile(DSAIDA_FILE_NAME_P);
                SSAIDA.SetFile(SSAIDA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -794- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -797- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -802- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -805- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -806- DISPLAY 'PROGRAMA EM EXECUCAO VG0010B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VG0010B   ");

            /*" -807- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -820- DISPLAY 'VERSAO V.31 181.569 25/01/2019 ' */
            _.Display($"VERSAO V.31 181.569 25/01/2019 ");

            /*" -826- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -829- OPEN OUTPUT DSAIDA SSAIDA. */
            DSAIDA.Open(RECORD_DSAIDA);
            SSAIDA.Open(RECORD_SSAIDA);

            /*" -833- MOVE ZEROS TO MNUM-APOLICE MCOD-SUBGRUPO MNUM-CERTIFICADO PRODUVG-COD-PRODUTO. */
            _.Move(0, MNUM_APOLICE, MCOD_SUBGRUPO, MNUM_CERTIFICADO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);

            /*" -836- MOVE SPACES TO PRODUVG-NOME-PRODUTO MTIPO-SEGURADO. */
            _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, MTIPO_SEGURADO);

            /*" -838- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA(true);

            /*" -840- PERFORM 070-000-LER-V1PARAMRAMO. */

            M_070_000_LER_V1PARAMRAMO_SECTION();

            /*" -842- PERFORM 080-000-LER-V1MOEDA. */

            M_080_000_LER_V1MOEDA_SECTION();

            /*" -844- PERFORM 090-000-CURSOR-V1MOVIMENTO */

            M_090_000_CURSOR_V1MOVIMENTO_SECTION();

            /*" -847- PERFORM 120-000-FETCH-V1MOVIMENTO UNTIL WFIM-MOVIMENTO = 'S' . */

            while (!(WFIM_MOVIMENTO == "S"))
            {

                M_120_000_FETCH_V1MOVIMENTO_SECTION();
            }

            /*" -847- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA */
        private void M_060_000_LER_TSISTEMA(bool isPerform = false)
        {
            /*" -862- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", WABEND.PARAGRAFO);

            /*" -865- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -874- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -877- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -878- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -880- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -882- MOVE 'ERRO NO ACESSO A TABELA DE SISTEMAS - VG ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A TABELA DE SISTEMAS - VG ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -883- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA */
                _.Move(HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -884- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA */
                _.Move(CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -885- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA */
                _.Move(HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -886- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA */
                _.Move(CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -887- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -888- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -889- DISPLAY 'VG0010B - NAO CONSTA REGISTRO NA TSISTEMA' */
                    _.Display($"VG0010B - NAO CONSTA REGISTRO NA TSISTEMA");

                    /*" -890- DISPLAY 'IDSISTEM =  VG ' */
                    _.Display($"IDSISTEM =  VG ");

                    /*" -891- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -892- ELSE */
                }
                else
                {


                    /*" -893- DISPLAY 'VG0010B - PROBLEMA NO ACESSO   A TSISTEMA' */
                    _.Display($"VG0010B - PROBLEMA NO ACESSO   A TSISTEMA");

                    /*" -894- DISPLAY 'IDSISTEM =  VG ' */
                    _.Display($"IDSISTEM =  VG ");

                    /*" -896- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -897- MOVE V1SISTEMA-DTMOVABE(1:4) TO HD-DTA-SIS-DSAIDA(7:4). */
            _.MoveAtPosition(V1SISTEMA_DTMOVABE.Substring(1, 4), HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 7, 4);

            /*" -898- MOVE V1SISTEMA-DTMOVABE(6:2) TO HD-DTA-SIS-DSAIDA(4:2). */
            _.MoveAtPosition(V1SISTEMA_DTMOVABE.Substring(6, 2), HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 4, 2);

            /*" -899- MOVE V1SISTEMA-DTMOVABE(9:2) TO HD-DTA-SIS-DSAIDA(1:2). */
            _.MoveAtPosition(V1SISTEMA_DTMOVABE.Substring(9, 2), HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 1, 2);

            /*" -901- MOVE '/' TO HD-DTA-SIS-DSAIDA(6:1). */
            _.MoveAtPosition("/", HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 6, 1);

            /*" -901- MOVE '/' TO HD-DTA-SIS-DSAIDA(3:1) */
            _.MoveAtPosition("/", HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, 3, 1);

            /*" -903- MOVE HD-DTA-SIS-DSAIDA TO HD-DTA-SIS-SSAIDA. */
            _.Move(HD_REG_DSAIDA.HD_DTA_SIS_DSAIDA, HD_REG_SSAIDA.HD_DTA_SIS_SSAIDA);

            /*" -904- WRITE RECORD-DSAIDA FROM HD-REG-DSAIDA. */
            _.Move(HD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -905- WRITE RECORD-DSAIDA FROM CB-REG-DSAIDA. */
            _.Move(CB_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

            DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

            /*" -906- WRITE RECORD-SSAIDA FROM HD-REG-SSAIDA. */
            _.Move(HD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

            /*" -906- WRITE RECORD-SSAIDA FROM CB-REG-SSAIDA. */
            _.Move(CB_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

            SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -874- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEMA-DTMOVABE, :V1SISTEMA-CURRDATE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
                _.Move(executed_1.V1SISTEMA_CURRDATE, V1SISTEMA_CURRDATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-SECTION */
        private void M_070_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -921- MOVE '070-000-LER-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("070-000-LER-V1PARAMRAMO", WABEND.PARAGRAFO);

            /*" -924- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -930- PERFORM M_070_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            M_070_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -933- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -934- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -936- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -938- MOVE 'ERRO NO ACESSO A VIEW DE V1PARAMRAMO ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW DE V1PARAMRAMO ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -939- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -940- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -941- DISPLAY 'VG0010B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                    _.Display($"VG0010B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                    /*" -942- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -943- ELSE */
                }
                else
                {


                    /*" -944- DISPLAY 'VG0010B - PROBLEMA NO ACESSO   A V1PARAMRAMO' */
                    _.Display($"VG0010B - PROBLEMA NO ACESSO   A V1PARAMRAMO");

                    /*" -945- DISPLAY 'IDSISTEM =  VG ' */
                    _.Display($"IDSISTEM =  VG ");

                    /*" -945- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void M_070_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -930- EXEC SQL SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP, :V1PAR-RAMO-PST FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

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
            /*" -961- MOVE '080-000-LER-V1MOEDA' TO PARAGRAFO. */
            _.Move("080-000-LER-V1MOEDA", WABEND.PARAGRAFO);

            /*" -964- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -973- PERFORM M_080_000_LER_V1MOEDA_DB_SELECT_1 */

            M_080_000_LER_V1MOEDA_DB_SELECT_1();

            /*" -976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -977- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -979- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -981- MOVE 'ERRO NO ACESSO A VIEW DE V1MOEDA ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW DE V1MOEDA ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -982- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -983- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -984- DISPLAY 'VG0010B - NAO CONSTA REGISTRO NA V1MOEDA' */
                    _.Display($"VG0010B - NAO CONSTA REGISTRO NA V1MOEDA");

                    /*" -985- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -986- ELSE */
                }
                else
                {


                    /*" -988- DISPLAY 'VG0010B - ERRO SELECT V1MOEDA. SQLCODE = ' SQLCODE */
                    _.Display($"VG0010B - ERRO SELECT V1MOEDA. SQLCODE = {DB.SQLCODE}");

                    /*" -989- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -990- END-IF */
                }


                /*" -992- END-IF. */
            }


            /*" -993- MOVE V1EN-COD-MOEDA-IMP TO V1EN-COD-MOEDA-PRM. */
            _.Move(V1EN_COD_MOEDA_IMP, V1EN_COD_MOEDA_PRM);

            /*" -993- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM. */
            _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

        }

        [StopWatch]
        /*" M-080-000-LER-V1MOEDA-DB-SELECT-1 */
        public void M_080_000_LER_V1MOEDA_DB_SELECT_1()
        {
            /*" -973- EXEC SQL SELECT CODUNIMO, VLCRUZAD INTO :V1EN-COD-MOEDA-IMP, :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE TIPO_MOEDA = '0' AND SITUACAO = '0' WITH UR END-EXEC. */

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
            /*" -1011- MOVE '090-000-CURSOR-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("090-000-CURSOR-V1MOVIMENTO", WABEND.PARAGRAFO);

            /*" -1014- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -1099- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1();

            /*" -1103- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1();

            /*" -1106- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1107- DISPLAY 'VG0010B - PROBLEMA NO OPEN       TMOVIMENTO ' */
                _.Display($"VG0010B - PROBLEMA NO OPEN       TMOVIMENTO ");

                /*" -1108- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -1109- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1111- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1113- MOVE 'ERRO ABERTURA CURSOR MOVIMENTO - TMOVIMENTO ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO ABERTURA CURSOR MOVIMENTO - TMOVIMENTO ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1114- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1114- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1()
        {
            /*" -1099- EXEC SQL DECLARE TMOVIMENTO CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, DATA_MOVIMENTO + 1 YEAR - 1 DAY, COD_EMPRESA, LOT_EMP_SEGURADO FROM SEGUROS.V1MOVIMENTO WHERE DATA_AVERBACAO IS NOT NULL AND DATA_INCLUSAO IS NULL AND COD_OPERACAO >= 0100 AND COD_OPERACAO <= 0299 END-EXEC. */
            TMOVIMENTO = new VG0010B_TMOVIMENTO(false);
            string GetQuery_TMOVIMENTO()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							TIPO_SEGURADO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							TIPO_INCLUSAO
							, 
							COD_CLIENTE
							, 
							COD_AGENCIADOR
							, 
							COD_CORRETOR
							, 
							COD_PLANOVGAP
							, 
							COD_PLANOAP
							, 
							FAIXA
							, 
							AUTOR_AUM_AUTOMAT
							, 
							TIPO_BENEFICIARIO
							, 
							PERI_PAGAMENTO
							, 
							PERI_RENOVACAO
							, 
							COD_OCUPACAO
							, 
							ESTADO_CIVIL
							, 
							IDE_SEXO
							, 
							COD_PROFISSAO
							, 
							NATURALIDADE
							, 
							OCORR_ENDERECO
							, 
							OCORR_END_COBRAN
							, 
							BCO_COBRANCA
							, 
							AGE_COBRANCA
							, 
							DAC_COBRANCA
							, 
							NUM_MATRICULA
							, 
							NUM_CTA_CORRENTE
							, 
							DAC_CTA_CORRENTE
							, 
							VAL_SALARIO
							, 
							TIPO_SALARIO
							, 
							TIPO_PLANO
							, 
							PCT_CONJUGE_VG
							, 
							PCT_CONJUGE_AP
							, 
							QTD_SAL_MORNATU
							, 
							QTD_SAL_MORACID
							, 
							QTD_SAL_INVPERM
							, 
							TAXA_AP_MORACID
							, 
							TAXA_AP_INVPERM
							, 
							TAXA_AP_AMDS
							, 
							TAXA_AP_DH
							, 
							TAXA_AP_DIT
							, 
							TAXA_VG
							, 
							IMP_MORNATU_ANT
							, 
							IMP_MORNATU_ATU
							, 
							IMP_MORACID_ANT
							, 
							IMP_MORACID_ATU
							, 
							IMP_INVPERM_ANT
							, 
							IMP_INVPERM_ATU
							, 
							IMP_AMDS_ANT
							, 
							IMP_AMDS_ATU
							, 
							IMP_DH_ANT
							, 
							IMP_DH_ATU
							, 
							IMP_DIT_ANT
							, 
							IMP_DIT_ATU
							, 
							PRM_VG_ANT
							, 
							PRM_VG_ATU
							, 
							PRM_AP_ANT
							, 
							PRM_AP_ATU
							, 
							COD_OPERACAO
							, 
							DATA_OPERACAO
							, 
							COD_SUBGRUPO_TRANS
							, 
							SIT_REGISTRO
							, 
							COD_USUARIO
							, 
							DATA_AVERBACAO
							, 
							DATA_ADMISSAO
							, 
							DATA_INCLUSAO
							, 
							DATA_NASCIMENTO
							, 
							DATA_FATURA
							, 
							DATA_REFERENCIA
							, 
							DATA_MOVIMENTO
							, 
							DATA_MOVIMENTO + 1 YEAR - 1 DAY
							, 
							COD_EMPRESA
							, 
							LOT_EMP_SEGURADO 
							FROM SEGUROS.V1MOVIMENTO 
							WHERE 
							DATA_AVERBACAO IS NOT NULL 
							AND DATA_INCLUSAO IS NULL 
							AND COD_OPERACAO >= 0100 
							AND COD_OPERACAO <= 0299";

                return query;
            }
            TMOVIMENTO.GetQueryEvent += GetQuery_TMOVIMENTO;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1()
        {
            /*" -1103- EXEC SQL OPEN TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Open();

        }

        [StopWatch]
        /*" M-420-000-CURSOR-V1BENEFIPROP-DB-DECLARE-1 */
        public void M_420_000_CURSOR_V1BENEFIPROP_DB_DECLARE_1()
        {
            /*" -2767- EXEC SQL DECLARE TBENEFIPROP CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, NUM_BENEFICIARIO, NOME_BENEFICIARIO, GRAU_PARENTESCO, PCT_PART_BENEFICIA, COD_USUARIO, COD_EMPRESA FROM SEGUROS.V1BENEFIPROP WHERE NUM_APOLICE = :MNUM-APOLICE AND COD_SUBGRUPO = :MCOD-SUBGRUPO AND COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA WITH UR END-EXEC. */
            TBENEFIPROP = new VG0010B_TBENEFIPROP(true);
            string GetQuery_TBENEFIPROP()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							NUM_BENEFICIARIO
							, 
							NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA
							, 
							COD_USUARIO
							, 
							COD_EMPRESA 
							FROM 
							SEGUROS.V1BENEFIPROP 
							WHERE 
							NUM_APOLICE = '{MNUM_APOLICE}' AND 
							COD_SUBGRUPO = '{MCOD_SUBGRUPO}' AND 
							COD_FONTE = '{MCOD_FONTE}' AND 
							NUM_PROPOSTA = '{MNUM_PROPOSTA}'";

                return query;
            }
            TBENEFIPROP.GetQueryEvent += GetQuery_TBENEFIPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-SECTION */
        private void M_120_000_FETCH_V1MOVIMENTO_SECTION()
        {
            /*" -1131- MOVE '120-000-FETCH-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("120-000-FETCH-V1MOVIMENTO", WABEND.PARAGRAFO);

            /*" -1134- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WABEND.WNR_EXEC_SQL);

            /*" -1213- PERFORM M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1 */

            M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1();

            /*" -1216- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1217- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1218- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", WFIM_MOVIMENTO);

                    /*" -1218- PERFORM M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1 */

                    M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1();

                    /*" -1220- GO TO 120-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                    return;

                    /*" -1221- ELSE */
                }
                else
                {


                    /*" -1222- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -1224- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -1226- MOVE 'ERRO NA LEITURA DO CURSOR MOVIMENTO - TMOVIMENTO ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA LEITURA DO CURSOR MOVIMENTO - TMOVIMENTO ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -1227- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -1229- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1230- IF WLOT-EMP-SEGURADO LESS ZEROS */

            if (WLOT_EMP_SEGURADO < 00)
            {

                /*" -1232- MOVE SPACES TO MLOT-EMP-SEGURADO. */
                _.Move("", MLOT_EMP_SEGURADO);
            }


            /*" -1238- IF MCOD-FONTE EQUAL ZEROS */

            if (MCOD_FONTE == 00)
            {

                /*" -1240- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1249- IF MPRM-VG-ATU EQUAL ZEROS AND MPRM-AP-ATU EQUAL ZEROS */

            if (MPRM_VG_ATU == 00 && MPRM_AP_ATU == 00)
            {

                /*" -1251- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1260- IF MIMP-MORNATU-ATU EQUAL ZEROS AND MIMP-MORACID-ATU EQUAL ZEROS */

            if (MIMP_MORNATU_ATU == 00 && MIMP_MORACID_ATU == 00)
            {

                /*" -1262- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1264- MOVE MNUM-APOLICE TO WAPOLICE-ATU. */
            _.Move(MNUM_APOLICE, WAPOLICE_ATU);

            /*" -1265- IF WPRIMEIRA-VEZ EQUAL 'S' */

            if (WPRIMEIRA_VEZ == "S")
            {

                /*" -1266- MOVE 'N' TO WPRIMEIRA-VEZ */
                _.Move("N", WPRIMEIRA_VEZ);

                /*" -1267- MOVE 9999 TO WFONTE-ANT */
                _.Move(9999, WNUM_PROPOSTA_ANT.WFONTE_ANT);

                /*" -1269- MOVE 999999 TO WPROPOSTA-ANT. */
                _.Move(999999, WNUM_PROPOSTA_ANT.WPROPOSTA_ANT);
            }


            /*" -1270- MOVE MCOD-FONTE TO WFONTE-ATU. */
            _.Move(MCOD_FONTE, WNUM_PROPOSTA_ATU.WFONTE_ATU);

            /*" -1272- MOVE MNUM-PROPOSTA TO WPROPOSTA-ATU. */
            _.Move(MNUM_PROPOSTA, WNUM_PROPOSTA_ATU.WPROPOSTA_ATU);

            /*" -1273- MOVE ZEROS TO PRODUVG-COD-PRODUTO. */
            _.Move(0, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);

            /*" -1276- MOVE SPACES TO PRODUVG-NOME-PRODUTO WS-DESPREZA. */
            _.Move("", PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, WS_DESPREZA);

            /*" -1278- PERFORM 150-000-SELECT-V0APOLICE. */

            M_150_000_SELECT_V0APOLICE_SECTION();

            /*" -1280- PERFORM R7777-CONS-MODALIDADE-APOL. */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -1281- IF (WS-DESPREZA NOT EQUAL SPACES) */

            if ((!WS_DESPREZA.IsEmpty()))
            {

                /*" -1282- GO TO 120-000-FETCH-V1MOVIMENTO */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1284- END-IF. */
            }


            /*" -1285- IF WNUM-PROPOSTA-ATU NOT EQUAL WNUM-PROPOSTA-ANT */

            if (WNUM_PROPOSTA_ATU != WNUM_PROPOSTA_ANT)
            {

                /*" -1286- MOVE MCOD-FONTE TO WFONTE-ANT */
                _.Move(MCOD_FONTE, WNUM_PROPOSTA_ANT.WFONTE_ANT);

                /*" -1287- MOVE MNUM-PROPOSTA TO WPROPOSTA-ANT */
                _.Move(MNUM_PROPOSTA, WNUM_PROPOSTA_ANT.WPROPOSTA_ANT);

                /*" -1288- IF MNUM-CERTIFICADO EQUAL ZEROS */

                if (MNUM_CERTIFICADO == 00)
                {

                    /*" -1289- PERFORM 170-000-SELECT-NUMEROS */

                    M_170_000_SELECT_NUMEROS_SECTION();

                    /*" -1291- PERFORM 450-000-ROTINA-DIGITO. */

                    M_450_000_ROTINA_DIGITO_SECTION();
                }

            }


            /*" -1292- IF MNUM-CERTIFICADO EQUAL ZEROS */

            if (MNUM_CERTIFICADO == 00)
            {

                /*" -1293- MOVE H-DAC-CERTIFICADO TO DAC-CERTIFICADO */
                _.Move(H_DAC_CERTIFICADO, DAC_CERTIFICADO);

                /*" -1294- PERFORM 520-000-UPDATE-MOVIMENTO */

                M_520_000_UPDATE_MOVIMENTO_SECTION();

                /*" -1295- MOVE H-NUM-CERTIFICADO TO MNUM-CERTIFICADO */
                _.Move(H_NUM_CERTIFICADO, MNUM_CERTIFICADO);

                /*" -1296- ELSE */
            }
            else
            {


                /*" -1298- MOVE MDAC-CERTIFICADO TO DAC-CERTIFICADO. */
                _.Move(MDAC_CERTIFICADO, DAC_CERTIFICADO);
            }


            /*" -1300- MOVE MNUM-CERTIFICADO TO V0RELA-NRCERTIF. */
            _.Move(MNUM_CERTIFICADO, V0RELA_NRCERTIF);

            /*" -1301- IF MDATA-MOVIMENTO GREATER MDATA-REFERENCIA */

            if (MDATA_MOVIMENTO > MDATA_REFERENCIA)
            {

                /*" -1302- MOVE MDATA-MOVIMENTO TO WS-W01DTSQL */
                _.Move(MDATA_MOVIMENTO, WS_W01DTSQL);

                /*" -1303- MOVE 01 TO WS-W01DDSQL */
                _.Move(01, WS_W01DTSQL.WS_W01DDSQL);

                /*" -1305- MOVE WS-W01DTSQL TO MDATA-REFERENCIA. */
                _.Move(WS_W01DTSQL, MDATA_REFERENCIA);
            }


            /*" -1306- IF WDATA-NASCIMENTO LESS ZEROS */

            if (WDATA_NASCIMENTO < 00)
            {

                /*" -1318- PERFORM 160-000-SELECT-V0CLIENTE. */

                M_160_000_SELECT_V0CLIENTE_SECTION();
            }


            /*" -1319- MOVE V1SISTEMA-CURRDATE TO W-DATA-TRABALHO */
            _.Move(V1SISTEMA_CURRDATE, W_DATA_TRABALHO);

            /*" -1320- MOVE W-AS-TRABALHO TO W-AS-CURRDATE */
            _.Move(FILLER_0.W_AS_TRABALHO, FILLER_4.W_AS_CURRDATE);

            /*" -1322- MOVE W-MM-TRABALHO TO W-MM-CURRDATE */
            _.Move(FILLER_0.W_MM_TRABALHO, FILLER_4.W_MM_CURRDATE);

            /*" -1323- MOVE MDATA-RENOVACAO TO W-DATA-TRABALHO */
            _.Move(MDATA_RENOVACAO, W_DATA_TRABALHO);

            /*" -1324- MOVE W-AS-TRABALHO TO W-AS-RENOVACAO */
            _.Move(FILLER_0.W_AS_TRABALHO, FILLER_3.W_AS_RENOVACAO);

            /*" -1326- MOVE W-MM-TRABALHO TO W-MM-RENOVACAO */
            _.Move(FILLER_0.W_MM_TRABALHO, FILLER_3.W_MM_RENOVACAO);

            /*" -1327- IF W-AS-RENOVACAO LESS W-AS-CURRDATE */

            if (FILLER_3.W_AS_RENOVACAO < FILLER_4.W_AS_CURRDATE)
            {

                /*" -1328- MOVE W-AS-CURRDATE TO W-AS-RENOVACAO */
                _.Move(FILLER_4.W_AS_CURRDATE, FILLER_3.W_AS_RENOVACAO);

                /*" -1330- END-IF */
            }


            /*" -1331- IF W-AS-MM-RENOVACAO NOT GREATER W-AS-MM-CURRDATE */

            if (W_AS_MM_RENOVACAO <= W_AS_MM_CURRDATE)
            {

                /*" -1332- ADD 1 TO W-AS-RENOVACAO */
                FILLER_3.W_AS_RENOVACAO.Value = FILLER_3.W_AS_RENOVACAO + 1;

                /*" -1334- END-IF */
            }


            /*" -1336- MOVE W-AS-RENOVACAO TO W-AS-TRABALHO */
            _.Move(FILLER_3.W_AS_RENOVACAO, FILLER_0.W_AS_TRABALHO);

            /*" -1337- IF W-MM-TRABALHO EQUAL 02 */

            if (FILLER_0.W_MM_TRABALHO == 02)
            {

                /*" -1338- IF W-DD-TRABALHO GREATER 28 */

                if (FILLER_0.W_DD_TRABALHO > 28)
                {

                    /*" -1339- COMPUTE WANO-BISSEXTO = W-AS-TRABALHO / 4 */
                    WANO_BISSEXTO.Value = FILLER_0.W_AS_TRABALHO / 4;

                    /*" -1340- COMPUTE WANO-BISSEXTO = WANO-BISSEXTO * 4 */
                    WANO_BISSEXTO.Value = WANO_BISSEXTO * 4;

                    /*" -1341- IF WANO-BISSEXTO EQUAL W-AS-TRABALHO */

                    if (WANO_BISSEXTO == FILLER_0.W_AS_TRABALHO)
                    {

                        /*" -1342- MOVE 29 TO W-DD-TRABALHO */
                        _.Move(29, FILLER_0.W_DD_TRABALHO);

                        /*" -1343- ELSE */
                    }
                    else
                    {


                        /*" -1344- MOVE 28 TO W-DD-TRABALHO */
                        _.Move(28, FILLER_0.W_DD_TRABALHO);

                        /*" -1345- END-IF */
                    }


                    /*" -1346- END-IF */
                }


                /*" -1348- END-IF */
            }


            /*" -1351- MOVE W-DATA-TRABALHO TO MDATA-RENOVACAO. */
            _.Move(W_DATA_TRABALHO, MDATA_RENOVACAO);

            /*" -1353- PERFORM 180-000-INCLUI-V0SEGURAVG. */

            M_180_000_INCLUI_V0SEGURAVG_SECTION();

            /*" -1354- IF (W-SEGURO-DUPLICADO = 'S' ) */

            if ((W_SEGURO_DUPLICADO == "S"))
            {

                /*" -1355- PERFORM 182-000-BUSCA-SEGURADO-VGAP */

                M_182_000_BUSCA_SEGURADO_VGAP();

                /*" -1357- END-IF */
            }


            /*" -1358- IF (W-SEGURO-INTEGRIDADE = 'S' ) */

            if ((W_SEGURO_INTEGRIDADE == "S"))
            {

                /*" -1359- GO TO 120-000-FETCH-V1MOVIMENTO */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1362- END-IF. */
            }


            /*" -1363- IF (MCOD-OPERACAO EQUAL 0103) */

            if ((MCOD_OPERACAO == 0103))
            {

                /*" -1364- PERFORM 190-000-ATUALIZA-PRINCIPAL */

                M_190_000_ATUALIZA_PRINCIPAL_SECTION();

                /*" -1367- END-IF. */
            }


            /*" -1369- PERFORM 210-000-MONTA-V0COBERAPOL. */

            M_210_000_MONTA_V0COBERAPOL_SECTION();

            /*" -1371- PERFORM 330-000-INSERE-V0HISTSEGVG. */

            M_330_000_INSERE_V0HISTSEGVG_SECTION();

            /*" -1373- IF (MNUM-CTA-CORRENTE NOT EQUAL ZEROS) AND (MTIPO-SEGURADO EQUAL '1' ) */

            if ((MNUM_CTA_CORRENTE != 00) && (MTIPO_SEGURADO == "1"))
            {

                /*" -1374- PERFORM 360-000-INSERE-V0CONTACOR */

                M_360_000_INSERE_V0CONTACOR_SECTION();

                /*" -1376- END-IF. */
            }


            /*" -1378- PERFORM 390-000-UPDATE-V0MOVIMENTO. */

            M_390_000_UPDATE_V0MOVIMENTO_SECTION();

            /*" -1379- IF W-SEGURO-DUPLICADO NOT EQUAL 'S' */

            if (W_SEGURO_DUPLICADO != "S")
            {

                /*" -1380- PERFORM 400-000-UPDATE-V0APOLICE */

                M_400_000_UPDATE_V0APOLICE_SECTION();

                /*" -1382- END-IF */
            }


            /*" -1384- MOVE 'N' TO WFIM-BENEFIPROP. */
            _.Move("N", WFIM_BENEFIPROP);

            /*" -1385- IF (MTIPO-SEGURADO EQUAL '1' ) */

            if ((MTIPO_SEGURADO == "1"))
            {

                /*" -1386- PERFORM 420-000-CURSOR-V1BENEFIPROP */

                M_420_000_CURSOR_V1BENEFIPROP_SECTION();

                /*" -1388- PERFORM 430-000-LE-BENEFIPROP UNTIL WFIM-BENEFIPROP = 'S' */

                while (!(WFIM_BENEFIPROP == "S"))
                {

                    M_430_000_LE_BENEFIPROP_SECTION();
                }

                /*" -1388- END-IF. */
            }


        }

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-DB-FETCH-1 */
        public void M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1()
        {
            /*" -1213- EXEC SQL FETCH TMOVIMENTO INTO :MNUM-APOLICE, :MCOD-SUBGRUPO, :MCOD-FONTE, :MNUM-PROPOSTA, :MTIPO-SEGURADO, :MNUM-CERTIFICADO, :MDAC-CERTIFICADO, :MTIPO-INCLUSAO, :MCOD-CLIENTE, :MCOD-AGENCIADOR, :MCOD-CORRETOR, :MCOD-PLANOVGAP, :MCOD-PLANOAP, :MFAIXA, :MAUTOR-AUM-AUTOMAT, :MTIPO-BENEFICIARIO, :MPERI-PAGAMENTO, :MPERI-RENOVACAO, :MCOD-OCUPACAO, :MESTADO-CIVIL, :MIDE-SEXO, :MCOD-PROFISSAO, :MNATURALIDADE, :MOCORR-ENDERECO, :MOCORR-END-COBRAN, :MBCO-COBRANCA, :MAGE-COBRANCA, :MDAC-COBRANCA, :MNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, :MVAL-SALARIO, :MTIPO-SALARIO, :MTIPO-PLANO, :MPCT-CONJUGE-VG, :MPCT-CONJUGE-AP, :MQTD-SAL-MORNATU, :MQTD-SAL-MORACID, :MQTD-SAL-INVPERM, :MTAXA-AP-MORACID, :MTAXA-AP-INVPERM, :MTAXA-AP-AMDS, :MTAXA-AP-DH, :MTAXA-AP-DIT, :MTAXA-VG, :MIMP-MORNATU-ANT, :MIMP-MORNATU-ATU, :MIMP-MORACID-ANT, :MIMP-MORACID-ATU, :MIMP-INVPERM-ANT, :MIMP-INVPERM-ATU, :MIMP-AMDS-ANT, :MIMP-AMDS-ATU, :MIMP-DH-ANT, :MIMP-DH-ATU, :MIMP-DIT-ANT, :MIMP-DIT-ATU, :MPRM-VG-ANT, :MPRM-VG-ATU, :MPRM-AP-ANT, :MPRM-AP-ATU, :MCOD-OPERACAO, :MDATA-OPERACAO, :COD-SUBGRUPO-TRANS, :MSIT-REGISTRO, :MCOD-USUARIO, :MDATA-AVERBACAO:WDATA-AVERBACAO, :MDATA-ADMISSAO:WDATA-ADMISSAO, :MDATA-INCLUSAO:WDATA-INCLUSAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MDATA-FATURA:WDATA-FATURA, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :MDATA-RENOVACAO:WDATA-RENOVACAO, :MCOD-EMPRESA:WCOD-EMPRESA, :MLOT-EMP-SEGURADO:WLOT-EMP-SEGURADO END-EXEC. */

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
                _.Move(TMOVIMENTO.MDATA_RENOVACAO, MDATA_RENOVACAO);
                _.Move(TMOVIMENTO.WDATA_RENOVACAO, WDATA_RENOVACAO);
                _.Move(TMOVIMENTO.MCOD_EMPRESA, MCOD_EMPRESA);
                _.Move(TMOVIMENTO.WCOD_EMPRESA, WCOD_EMPRESA);
                _.Move(TMOVIMENTO.MLOT_EMP_SEGURADO, MLOT_EMP_SEGURADO);
                _.Move(TMOVIMENTO.WLOT_EMP_SEGURADO, WLOT_EMP_SEGURADO);
            }

        }

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-DB-CLOSE-1 */
        public void M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1()
        {
            /*" -1218- EXEC SQL CLOSE TMOVIMENTO END-EXEC */

            TMOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-SELECT-V0APOLICE-SECTION */
        private void M_150_000_SELECT_V0APOLICE_SECTION()
        {
            /*" -1405- MOVE '150-000-SELECT-V0APOLICE' TO PARAGRAFO */
            _.Move("150-000-SELECT-V0APOLICE", WABEND.PARAGRAFO);

            /*" -1408- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -1423- PERFORM M_150_000_SELECT_V0APOLICE_DB_SELECT_1 */

            M_150_000_SELECT_V0APOLICE_DB_SELECT_1();

            /*" -1426- IF WNUM-ITEM LESS 0 */

            if (WNUM_ITEM < 0)
            {

                /*" -1427- MOVE 0 TO SNUM-ITEM */
                _.Move(0, SNUM_ITEM);

                /*" -1429- MOVE +1 TO WNUM-ITEM. */
                _.Move(+1, WNUM_ITEM);
            }


            /*" -1430- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1431- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1433- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1435- MOVE 'ERRO NO ACESSO A VIEW V0APOLICE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V0APOLICE", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1436- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1437- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1440- DISPLAY 'VG0010B - NAO EXISTE NUMERO DE ITEM ' MNUM-APOLICE */
                    _.Display($"VG0010B - NAO EXISTE NUMERO DE ITEM {MNUM_APOLICE}");

                    /*" -1441- MOVE 'S' TO WS-DESPREZA */
                    _.Move("S", WS_DESPREZA);

                    /*" -1442- GO TO 150-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/ //GOTO
                    return;

                    /*" -1443- ELSE */
                }
                else
                {


                    /*" -1445- DISPLAY 'VG0010B - ERRO SELECT V0APOLICE. SQLCODE = ' SQLCODE */
                    _.Display($"VG0010B - ERRO SELECT V0APOLICE. SQLCODE = {DB.SQLCODE}");

                    /*" -1446- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1447- END-IF */
                }


                /*" -1449- END-IF. */
            }


            /*" -1451- PERFORM 152-000-VER-NUM-ITEM-HIST */

            M_152_000_VER_NUM_ITEM_HIST_SECTION();

            /*" -1452- IF (SNUM-ITEM-HIST > SNUM-ITEM) */

            if ((SNUM_ITEM_HIST > SNUM_ITEM))
            {

                /*" -1453- MOVE SNUM-ITEM-HIST TO SNUM-ITEM */
                _.Move(SNUM_ITEM_HIST, SNUM_ITEM);

                /*" -1455- END-IF. */
            }


            /*" -1457- PERFORM 155-000-VER-NUM-ITEM-SEGUR */

            M_155_000_VER_NUM_ITEM_SEGUR_SECTION();

            /*" -1458- IF (SNUM-ITEM-SEGUR > SNUM-ITEM) */

            if ((SNUM_ITEM_SEGUR > SNUM_ITEM))
            {

                /*" -1459- MOVE SNUM-ITEM-SEGUR TO SNUM-ITEM */
                _.Move(SNUM_ITEM_SEGUR, SNUM_ITEM);

                /*" -1461- END-IF. */
            }


            /*" -1461- ADD 1 TO SNUM-ITEM. */
            SNUM_ITEM.Value = SNUM_ITEM + 1;

        }

        [StopWatch]
        /*" M-150-000-SELECT-V0APOLICE-DB-SELECT-1 */
        public void M_150_000_SELECT_V0APOLICE_DB_SELECT_1()
        {
            /*" -1423- EXEC SQL SELECT NUM_APOLICE, NUM_ITEM, MODALIDA, RAMO INTO :V0NUM-APOLICE, :SNUM-ITEM:WNUM-ITEM, :V0APOL-MODALIDA, :V0APOL-RAMO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :MNUM-APOLICE END-EXEC. */

            var m_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1 = new M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1.Execute(m_150_000_SELECT_V0APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NUM_APOLICE, V0NUM_APOLICE);
                _.Move(executed_1.SNUM_ITEM, SNUM_ITEM);
                _.Move(executed_1.WNUM_ITEM, WNUM_ITEM);
                _.Move(executed_1.V0APOL_MODALIDA, V0APOL_MODALIDA);
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-152-000-VER-NUM-ITEM-HIST-SECTION */
        private void M_152_000_VER_NUM_ITEM_HIST_SECTION()
        {
            /*" -1476- MOVE '152-000-VER-NUM-ITEM-HIST' TO PARAGRAFO */
            _.Move("152-000-VER-NUM-ITEM-HIST", WABEND.PARAGRAFO);

            /*" -1478- MOVE '152' TO WNR-EXEC-SQL. */
            _.Move("152", WABEND.WNR_EXEC_SQL);

            /*" -1484- PERFORM M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1 */

            M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1();

            /*" -1487- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1488- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1489- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1491- MOVE 'ERRO NO ACESSO AO MAX HISTSEGVG' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO AO MAX HISTSEGVG", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1492- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1494- DISPLAY 'VG0010B - ERRO SELECT V0HISTSEGVG - SQLCODE = ' SQLCODE */
                _.Display($"VG0010B - ERRO SELECT V0HISTSEGVG - SQLCODE = {DB.SQLCODE}");

                /*" -1495- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1495- END-IF. */
            }


        }

        [StopWatch]
        /*" M-152-000-VER-NUM-ITEM-HIST-DB-SELECT-1 */
        public void M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1()
        {
            /*" -1484- EXEC SQL SELECT VALUE(MAX(NUM_ITEM), 0) INTO :SNUM-ITEM-HIST FROM SEGUROS.V0HISTSEGVG WHERE NUM_APOLICE = :MNUM-APOLICE WITH UR END-EXEC. */

            var m_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1 = new M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1.Execute(m_152_000_VER_NUM_ITEM_HIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SNUM_ITEM_HIST, SNUM_ITEM_HIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_152_999_EXIT*/

        [StopWatch]
        /*" M-155-000-VER-NUM-ITEM-SEGUR-SECTION */
        private void M_155_000_VER_NUM_ITEM_SEGUR_SECTION()
        {
            /*" -1508- MOVE '155-000-VER-NUM-ITEM-SEGUR' TO PARAGRAFO */
            _.Move("155-000-VER-NUM-ITEM-SEGUR", WABEND.PARAGRAFO);

            /*" -1510- MOVE '155' TO WNR-EXEC-SQL. */
            _.Move("155", WABEND.WNR_EXEC_SQL);

            /*" -1516- PERFORM M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1 */

            M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1();

            /*" -1519- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -1520- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1521- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1523- MOVE 'ERRO NO ACESSO AO MAX SEGURADOS_VGAP ' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO AO MAX SEGURADOS_VGAP ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1524- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1526- DISPLAY 'VG0010B - ERRO SELECT SEGURADOS_VGAP - SQLCOD = ' SQLCODE */
                _.Display($"VG0010B - ERRO SELECT SEGURADOS_VGAP - SQLCOD = {DB.SQLCODE}");

                /*" -1527- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -1527- END-IF. */
            }


        }

        [StopWatch]
        /*" M-155-000-VER-NUM-ITEM-SEGUR-DB-SELECT-1 */
        public void M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1()
        {
            /*" -1516- EXEC SQL SELECT VALUE(MAX(NUM_ITEM), 0) INTO :SNUM-ITEM-SEGUR FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :MNUM-APOLICE WITH UR END-EXEC. */

            var m_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1 = new M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1.Execute(m_155_000_VER_NUM_ITEM_SEGUR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SNUM_ITEM_SEGUR, SNUM_ITEM_SEGUR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_155_999_EXIT*/

        [StopWatch]
        /*" M-160-000-SELECT-V0CLIENTE-SECTION */
        private void M_160_000_SELECT_V0CLIENTE_SECTION()
        {
            /*" -1544- MOVE '160-000-SELECT-V0CLIENTE' TO PARAGRAFO */
            _.Move("160-000-SELECT-V0CLIENTE", WABEND.PARAGRAFO);

            /*" -1547- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WABEND.WNR_EXEC_SQL);

            /*" -1557- PERFORM M_160_000_SELECT_V0CLIENTE_DB_SELECT_1 */

            M_160_000_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -1560- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1561- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1563- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1565- MOVE 'ERRO NO ACESSO A VIEW DE V0CLIENTE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW DE V0CLIENTE", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1566- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1567- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1569- DISPLAY 'VG0010B - NAO EXISTE CLIENTE ' 'COD_CLIENTE = ' MCOD-CLIENTE */

                    $"VG0010B - NAO EXISTE CLIENTE COD_CLIENTE = {MCOD_CLIENTE}"
                    .Display();

                    /*" -1570- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1571- ELSE */
                }
                else
                {


                    /*" -1573- DISPLAY 'VG0010B - ERRO SELECT V0CLIENTE. SQLCODE = ' SQLCODE */
                    _.Display($"VG0010B - ERRO SELECT V0CLIENTE. SQLCODE = {DB.SQLCODE}");

                    /*" -1574- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1575- END-IF */
                }


                /*" -1577- END-IF. */
            }


            /*" -1578- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1579- IF CWDATA-NASCIMENTO EQUAL ZEROS */

                if (CWDATA_NASCIMENTO == 00)
                {

                    /*" -1580- MOVE CDATA-NASCIMENTO TO MDATA-NASCIMENTO */
                    _.Move(CDATA_NASCIMENTO, MDATA_NASCIMENTO);

                    /*" -1580- MOVE CWDATA-NASCIMENTO TO WDATA-NASCIMENTO. */
                    _.Move(CWDATA_NASCIMENTO, WDATA_NASCIMENTO);
                }

            }


        }

        [StopWatch]
        /*" M-160-000-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void M_160_000_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -1557- EXEC SQL SELECT DATA_NASCIMENTO INTO :CDATA-NASCIMENTO:CWDATA-NASCIMENTO FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :MCOD-CLIENTE WITH UR END-EXEC. */

            var m_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                MCOD_CLIENTE = MCOD_CLIENTE.ToString(),
            };

            var executed_1 = M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(m_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CDATA_NASCIMENTO, CDATA_NASCIMENTO);
                _.Move(executed_1.CWDATA_NASCIMENTO, CWDATA_NASCIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-170-000-SELECT-NUMEROS-SECTION */
        private void M_170_000_SELECT_NUMEROS_SECTION()
        {
            /*" -1599- MOVE '170-000-SELECT-NUMEROS' TO PARAGRAFO */
            _.Move("170-000-SELECT-NUMEROS", WABEND.PARAGRAFO);

            /*" -1602- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", WABEND.WNR_EXEC_SQL);

            /*" -1609- PERFORM M_170_000_SELECT_NUMEROS_DB_SELECT_1 */

            M_170_000_SELECT_NUMEROS_DB_SELECT_1();

            /*" -1613- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1614- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1616- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1618- MOVE 'ERRO NO ACESSO A VIEW V1NUMERO_OUTROS' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO A VIEW V1NUMERO_OUTROS", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1619- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1620- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1621- DISPLAY 'VG0010B - NAO EXISTE NUM.CERT. NUMEROS-OUTROS' */
                    _.Display($"VG0010B - NAO EXISTE NUM.CERT. NUMEROS-OUTROS");

                    /*" -1622- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1623- ELSE */
                }
                else
                {


                    /*" -1625- DISPLAY 'VG0010B - ERRO SELECT V1NUMERO_OUTROS. SQLCODE=' SQLCODE */
                    _.Display($"VG0010B - ERRO SELECT V1NUMERO_OUTROS. SQLCODE={DB.SQLCODE}");

                    /*" -1626- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -1627- END-IF */
                }


                /*" -1630- END-IF. */
            }


            /*" -1632- COMPUTE H-NUM-CERTIFICADO = NUMCERVG + 1. */
            H_NUM_CERTIFICADO.Value = NUMCERVG + 1;

            /*" -1632- PERFORM 500-000-UPDATE-V0NUMERO-OUTROS. */

            M_500_000_UPDATE_V0NUMERO_OUTROS_SECTION();

        }

        [StopWatch]
        /*" M-170-000-SELECT-NUMEROS-DB-SELECT-1 */
        public void M_170_000_SELECT_NUMEROS_DB_SELECT_1()
        {
            /*" -1609- EXEC SQL SELECT NUMCERVG INTO :NUMCERVG FROM SEGUROS.V1NUMERO_OUTROS END-EXEC. */

            var m_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1 = new M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1.Execute(m_170_000_SELECT_NUMEROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUMCERVG, NUMCERVG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_170_999_EXIT*/

        [StopWatch]
        /*" M-180-000-INCLUI-V0SEGURAVG-SECTION */
        private void M_180_000_INCLUI_V0SEGURAVG_SECTION()
        {
            /*" -1650- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1654- MOVE '180-000-INCLUI-V0SEGURAVG' TO PARAGRAFO */
            _.Move("180-000-INCLUI-V0SEGURAVG", WABEND.PARAGRAFO);

            /*" -1656- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WABEND.WNR_EXEC_SQL);

            /*" -1657- MOVE ' ' TO W-SEGURO-DUPLICADO. */
            _.Move(" ", W_SEGURO_DUPLICADO);

            /*" -1659- MOVE ' ' TO W-SEGURO-INTEGRIDADE. */
            _.Move(" ", W_SEGURO_INTEGRIDADE);

            /*" -1669- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1671- MOVE 1 TO SEGUR-OCORHIST. */
            _.Move(1, SEGUR_OCORHIST);

            /*" -1728- PERFORM M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1 */

            M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1();

            /*" -1731- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1732- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1733- MOVE 'S' TO W-SEGURO-DUPLICADO */
                    _.Move("S", W_SEGURO_DUPLICADO);

                    /*" -1736- DISPLAY 'VG0010B - DUPLICIDADE NA V0SEGURAVG  ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' MNUM-CERTIFICADO */

                    $"VG0010B - DUPLICIDADE NA V0SEGURAVG  {MNUM_APOLICE} {MCOD_SUBGRUPO} {MNUM_CERTIFICADO}"
                    .Display();

                    /*" -1737- ADD 1 TO AC-DUPLICIDADE */
                    AC_DUPLICIDADE.Value = AC_DUPLICIDADE + 1;

                    /*" -1738- ELSE */
                }
                else
                {


                    /*" -1739- IF SQLCODE EQUAL -530 */

                    if (DB.SQLCODE == -530)
                    {

                        /*" -1740- MOVE 'S' TO W-SEGURO-INTEGRIDADE */
                        _.Move("S", W_SEGURO_INTEGRIDADE);

                        /*" -1743- DISPLAY 'VG0010B - PROBLEMAS NA INCLUSAO V0SEGURAVG: ' MNUM-APOLICE ';' MCOD-SUBGRUPO ';' MNUM-CERTIFICADO ';' SNUM-ITEM */

                        $"VG0010B - PROBLEMAS NA INCLUSAO V0SEGURAVG: {MNUM_APOLICE};{MCOD_SUBGRUPO};{MNUM_CERTIFICADO};{SNUM_ITEM}"
                        .Display();

                        /*" -1744- ELSE */
                    }
                    else
                    {


                        /*" -1747- DISPLAY 'VG0010B - PROBLEMAS NA INCLUSAO V0SEGURAVG  ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' MNUM-CERTIFICADO */

                        $"VG0010B - PROBLEMAS NA INCLUSAO V0SEGURAVG  {MNUM_APOLICE} {MCOD_SUBGRUPO} {MNUM_CERTIFICADO}"
                        .Display();

                        /*" -1748- PERFORM 650-000-LIMPA-REGISTROS */

                        M_650_000_LIMPA_REGISTROS_SECTION();

                        /*" -1750- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                        _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                        /*" -1752- MOVE 'ERRO NA INCLUSAO VIEW V0SEGURAVG' TO LD-DES-ERRO-SSAIDA */
                        _.Move("ERRO NA INCLUSAO VIEW V0SEGURAVG", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                        /*" -1753- PERFORM 660-000-GRAVA-REGISTROS */

                        M_660_000_GRAVA_REGISTROS_SECTION();

                        /*" -1754- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO(); //GOTO
                        return;

                        /*" -1755- ELSE */
                    }

                }

            }
            else
            {


                /*" -1755- ADD 1 TO AC-GRAVA. */
                AC_GRAVA.Value = AC_GRAVA + 1;
            }


        }

        [StopWatch]
        /*" M-180-000-INCLUI-V0SEGURAVG-DB-INSERT-1 */
        public void M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1()
        {
            /*" -1728- EXEC SQL INSERT INTO SEGUROS.V0SEGURAVG VALUES (:MNUM-APOLICE, :MCOD-SUBGRUPO, :MNUM-CERTIFICADO, :DAC-CERTIFICADO, :MTIPO-SEGURADO, :SNUM-ITEM, :MTIPO-INCLUSAO, :MCOD-CLIENTE, :MCOD-FONTE, :MNUM-PROPOSTA, :MCOD-AGENCIADOR, :MCOD-CORRETOR, :MCOD-PLANOVGAP, :MCOD-PLANOAP, :MFAIXA, :MAUTOR-AUM-AUTOMAT, :MTIPO-BENEFICIARIO, :SEGUR-OCORHIST, :MPERI-PAGAMENTO, :MPERI-RENOVACAO, 0, :MCOD-OCUPACAO, :MESTADO-CIVIL, :MIDE-SEXO, :MCOD-PROFISSAO, :MNATURALIDADE, :MOCORR-ENDERECO, :MOCORR-END-COBRAN, :MBCO-COBRANCA, :MAGE-COBRANCA, :MDAC-COBRANCA, :MNUM-MATRICULA, :MVAL-SALARIO, :MTIPO-SALARIO, :MTIPO-PLANO, :MDATA-MOVIMENTO, :MPCT-CONJUGE-VG, :MPCT-CONJUGE-AP, :MQTD-SAL-MORNATU, :MQTD-SAL-MORACID, :MQTD-SAL-INVPERM, :MTAXA-AP-MORACID, :MTAXA-AP-INVPERM, :MTAXA-AP-AMDS, :MTAXA-AP-DH, :MTAXA-AP-DIT, 0, :MTAXA-VG, '0' , :MDATA-RENOVACAO:WDATA-RENOVACAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MCOD-EMPRESA:WCOD-EMPRESA, NULL, :MLOT-EMP-SEGURADO) END-EXEC. */

            var m_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1 = new M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                DAC_CERTIFICADO = DAC_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
                MTIPO_INCLUSAO = MTIPO_INCLUSAO.ToString(),
                MCOD_CLIENTE = MCOD_CLIENTE.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_AGENCIADOR = MCOD_AGENCIADOR.ToString(),
                MCOD_CORRETOR = MCOD_CORRETOR.ToString(),
                MCOD_PLANOVGAP = MCOD_PLANOVGAP.ToString(),
                MCOD_PLANOAP = MCOD_PLANOAP.ToString(),
                MFAIXA = MFAIXA.ToString(),
                MAUTOR_AUM_AUTOMAT = MAUTOR_AUM_AUTOMAT.ToString(),
                MTIPO_BENEFICIARIO = MTIPO_BENEFICIARIO.ToString(),
                SEGUR_OCORHIST = SEGUR_OCORHIST.ToString(),
                MPERI_PAGAMENTO = MPERI_PAGAMENTO.ToString(),
                MPERI_RENOVACAO = MPERI_RENOVACAO.ToString(),
                MCOD_OCUPACAO = MCOD_OCUPACAO.ToString(),
                MESTADO_CIVIL = MESTADO_CIVIL.ToString(),
                MIDE_SEXO = MIDE_SEXO.ToString(),
                MCOD_PROFISSAO = MCOD_PROFISSAO.ToString(),
                MNATURALIDADE = MNATURALIDADE.ToString(),
                MOCORR_ENDERECO = MOCORR_ENDERECO.ToString(),
                MOCORR_END_COBRAN = MOCORR_END_COBRAN.ToString(),
                MBCO_COBRANCA = MBCO_COBRANCA.ToString(),
                MAGE_COBRANCA = MAGE_COBRANCA.ToString(),
                MDAC_COBRANCA = MDAC_COBRANCA.ToString(),
                MNUM_MATRICULA = MNUM_MATRICULA.ToString(),
                MVAL_SALARIO = MVAL_SALARIO.ToString(),
                MTIPO_SALARIO = MTIPO_SALARIO.ToString(),
                MTIPO_PLANO = MTIPO_PLANO.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                MPCT_CONJUGE_VG = MPCT_CONJUGE_VG.ToString(),
                MPCT_CONJUGE_AP = MPCT_CONJUGE_AP.ToString(),
                MQTD_SAL_MORNATU = MQTD_SAL_MORNATU.ToString(),
                MQTD_SAL_MORACID = MQTD_SAL_MORACID.ToString(),
                MQTD_SAL_INVPERM = MQTD_SAL_INVPERM.ToString(),
                MTAXA_AP_MORACID = MTAXA_AP_MORACID.ToString(),
                MTAXA_AP_INVPERM = MTAXA_AP_INVPERM.ToString(),
                MTAXA_AP_AMDS = MTAXA_AP_AMDS.ToString(),
                MTAXA_AP_DH = MTAXA_AP_DH.ToString(),
                MTAXA_AP_DIT = MTAXA_AP_DIT.ToString(),
                MTAXA_VG = MTAXA_VG.ToString(),
                MDATA_RENOVACAO = MDATA_RENOVACAO.ToString(),
                WDATA_RENOVACAO = WDATA_RENOVACAO.ToString(),
                MDATA_NASCIMENTO = MDATA_NASCIMENTO.ToString(),
                WDATA_NASCIMENTO = WDATA_NASCIMENTO.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                MLOT_EMP_SEGURADO = MLOT_EMP_SEGURADO.ToString(),
            };

            M_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1.Execute(m_180_000_INCLUI_V0SEGURAVG_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_180_999_EXIT*/

        [StopWatch]
        /*" M-182-000-BUSCA-SEGURADO-VGAP */
        private void M_182_000_BUSCA_SEGURADO_VGAP(bool isPerform = false)
        {
            /*" -1772- MOVE '182-000-BUSCA-SEGURADO-VGAP' TO PARAGRAFO */
            _.Move("182-000-BUSCA-SEGURADO-VGAP", WABEND.PARAGRAFO);

            /*" -1775- MOVE '182' TO WNR-EXEC-SQL */
            _.Move("182", WABEND.WNR_EXEC_SQL);

            /*" -1788- PERFORM M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1 */

            M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1();

            /*" -1791- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1792- MOVE SEGURVGA-NUM-ITEM TO SNUM-ITEM */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, SNUM_ITEM);

                /*" -1793- ADD 1 TO AC-GRAVA-2 */
                AC_GRAVA_2.Value = AC_GRAVA_2 + 1;

                /*" -1794- ELSE */
            }
            else
            {


                /*" -1795- DISPLAY 'VG0010B - PROBLEMAS NA CONSULTA V1SEGURAVG  ' */
                _.Display($"VG0010B - PROBLEMAS NA CONSULTA V1SEGURAVG  ");

                /*" -1796- DISPLAY 'CERTIFICADO/NUM_ITEM JA EXISTE ' */
                _.Display($"CERTIFICADO/NUM_ITEM JA EXISTE ");

                /*" -1797- DISPLAY 'NRCERTIF     ' MNUM-CERTIFICADO */
                _.Display($"NRCERTIF     {MNUM_CERTIFICADO}");

                /*" -1798- DISPLAY 'SNUM-ITEM    ' SNUM-ITEM */
                _.Display($"SNUM-ITEM    {SNUM_ITEM}");

                /*" -1799- DISPLAY 'NAO INCLUIDO' */
                _.Display($"NAO INCLUIDO");

                /*" -1800- GO TO 120-000-FETCH-V1MOVIMENTO */

                M_120_000_FETCH_V1MOVIMENTO_SECTION(); //GOTO
                return;

                /*" -1801- END-IF. */
            }


        }

        [StopWatch]
        /*" M-182-000-BUSCA-SEGURADO-VGAP-DB-SELECT-1 */
        public void M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1()
        {
            /*" -1788- EXEC SQL SELECT OCORR_HISTORICO, NUM_ITEM, SIT_REGISTRO, VALUE(DATA_INIVIGENCIA, '0001-01-01' ) INTO :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-ITEM, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-DATA-ADMISSAO FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var m_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1 = new M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1.Execute(m_182_000_BUSCA_SEGURADO_VGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(executed_1.SEGURVGA_DATA_ADMISSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_ADMISSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_182_999_EXIT*/

        [StopWatch]
        /*" M-190-000-ATUALIZA-PRINCIPAL-SECTION */
        private void M_190_000_ATUALIZA_PRINCIPAL_SECTION()
        {
            /*" -1815- MOVE '190-000-ATUALIZA-PRINCIPAL' TO PARAGRAFO */
            _.Move("190-000-ATUALIZA-PRINCIPAL", WABEND.PARAGRAFO);

            /*" -1818- MOVE '185' TO WNR-EXEC-SQL. */
            _.Move("185", WABEND.WNR_EXEC_SQL);

            /*" -1820- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1826- PERFORM M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1 */

            M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1();

            /*" -1829- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1831- DISPLAY 'VG0010B - PROBLEMAS ATUALIZACAO V0SEGURAVG ' ' ' MNUM-CERTIFICADO */

                $"VG0010B - PROBLEMAS ATUALIZACAO V0SEGURAVG  {MNUM_CERTIFICADO}"
                .Display();

                /*" -1832- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -1834- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -1836- MOVE 'ERRO NA ATUALIZACAO VIEW V0SEGURAVG' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ATUALIZACAO VIEW V0SEGURAVG", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -1837- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -1837- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-190-000-ATUALIZA-PRINCIPAL-DB-UPDATE-1 */
        public void M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -1826- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET PCT_CONJUGE_VG = :MPCT-CONJUGE-VG, PCT_CONJUGE_AP = :MPCT-CONJUGE-AP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var m_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1 = new M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                MPCT_CONJUGE_VG = MPCT_CONJUGE_VG.ToString(),
                MPCT_CONJUGE_AP = MPCT_CONJUGE_AP.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1.Execute(m_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_190_999_EXIT*/

        [StopWatch]
        /*" M-210-000-MONTA-V0COBERAPOL-SECTION */
        private void M_210_000_MONTA_V0COBERAPOL_SECTION()
        {
            /*" -1852- MOVE '210-000-MONTA-V0COBERAPOL' TO PARAGRAFO. */
            _.Move("210-000-MONTA-V0COBERAPOL", WABEND.PARAGRAFO);

            /*" -1854- IF WAPOLICE-ATU NOT EQUAL WAPOLICE-ANT */

            if (WAPOLICE_ATU != WAPOLICE_ANT)
            {

                /*" -1857- MOVE WAPOLICE-ATU TO WAPOLICE-ANT. */
                _.Move(WAPOLICE_ATU, WAPOLICE_ANT);
            }


            /*" -1859- MOVE MNUM-APOLICE TO VGNUM-APOLICE */
            _.Move(MNUM_APOLICE, VGNUM_APOLICE);

            /*" -1860- MOVE 0 TO VGNRENDOS */
            _.Move(0, VGNRENDOS);

            /*" -1861- MOVE SNUM-ITEM TO VGNUM-ITEM */
            _.Move(SNUM_ITEM, VGNUM_ITEM);

            /*" -1862- MOVE 1 TO VGOCORHIST. */
            _.Move(1, VGOCORHIST);

            /*" -1862- MOVE 0 TO VGPCT-COBERTURA1. */
            _.Move(0, VGPCT_COBERTURA1);

            /*" -0- FLUXCONTROL_PERFORM M_210_010_VERIFICA_PREMIO_VG */

            M_210_010_VERIFICA_PREMIO_VG();

        }

        [StopWatch]
        /*" M-210-010-VERIFICA-PREMIO-VG */
        private void M_210_010_VERIFICA_PREMIO_VG(bool isPerform = false)
        {
            /*" -1872- IF MIMP-MORNATU-ATU NOT EQUAL ZEROS OR (MIMP-MORNATU-ATU EQUAL ZEROS AND V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 AND MPRM-VG-ATU GREATER ZEROS) */

            if (MIMP_MORNATU_ATU != 00 || (MIMP_MORNATU_ATU == 00 && V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2 && MPRM_VG_ATU > 00))
            {

                /*" -1873- IF V0APOL-RAMO EQUAL V1PAR-RAMO-PST */

                if (V0APOL_RAMO == V1PAR_RAMO_PST)
                {

                    /*" -1874- MOVE V1PAR-RAMO-PST TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_PST, VGRAMOFR);

                    /*" -1875- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1877- END-IF */
                }


                /*" -1878- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG */

                if (V0APOL_RAMO == V1PAR_RAMO_VG)
                {

                    /*" -1879- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -1880- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1882- END-IF */
                }


                /*" -1883- IF V0APOL-RAMO EQUAL 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1884- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -1885- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1888- END-IF */
                }


                /*" -1890- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1894- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORNATU-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORNATU_ATU / DVLCRUZAD_IMP;

                /*" -1898- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-VG-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_VG_ATU / DVLCRUZAD_PRM;

                /*" -1901- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1904- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1907- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1908- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1911- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1915- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 OR (MNUM-APOLICE = 109300000635 AND MCOD-SUBGRUPO = 1) */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005 || (MNUM_APOLICE == 109300000635 && MCOD_SUBGRUPO == 1))
                {

                    /*" -1916- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1918- ELSE */
                }
                else
                {


                    /*" -1919- IF V0APOL-RAMO = V1PAR-RAMO-PST */

                    if (V0APOL_RAMO == V1PAR_RAMO_PST)
                    {

                        /*" -1921- PERFORM 600-000-GERA-TERVIG */

                        M_600_000_GERA_TERVIG_SECTION();

                        /*" -1924- ELSE */
                    }
                    else
                    {


                        /*" -1925- IF MPERI-PAGAMENTO = 0 */

                        if (MPERI_PAGAMENTO == 0)
                        {

                            /*" -1926- PERFORM 600-010-GERA-TERVIG */

                            M_600_010_GERA_TERVIG_SECTION();

                            /*" -1927- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                            _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                            /*" -1928- ELSE */
                        }
                        else
                        {


                            /*" -1929- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                            _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                            /*" -1930- END-IF */
                        }


                        /*" -1931- END-IF */
                    }


                    /*" -1933- END-IF */
                }


                /*" -1935- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1939- COMPUTE VGPCT-COBERTURA1 ROUNDED = MPRM-VG-ATU * 100 / WPRMTOT */
                VGPCT_COBERTURA1.Value = MPRM_VG_ATU * 100 / WPRMTOT;

                /*" -1941- MOVE VGPCT-COBERTURA1 TO VGPCT-COBERTURA */
                _.Move(VGPCT_COBERTURA1, VGPCT_COBERTURA);

                /*" -1944- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1944- PERFORM 210-020-VERIFICA-PREMIO-AP. */

            M_210_020_VERIFICA_PREMIO_AP(true);

        }

        [StopWatch]
        /*" M-210-020-VERIFICA-PREMIO-AP */
        private void M_210_020_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -1949- IF MIMP-MORACID-ATU NOT EQUAL ZEROS */

            if (MIMP_MORACID_ATU != 00)
            {

                /*" -1951- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1952- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1954- MOVE 01 TO VGCOD-COBERTURA */
                _.Move(01, VGCOD_COBERTURA);

                /*" -1958- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORACID-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORACID_ATU / DVLCRUZAD_IMP;

                /*" -1962- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-AP-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_AP_ATU / DVLCRUZAD_PRM;

                /*" -1965- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1968- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1971- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1972- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1975- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1978- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 OR MNUM-APOLICE = 108210696253 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005 || MNUM_APOLICE == 108210696253)
                {

                    /*" -1979- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1981- ELSE */
                }
                else
                {


                    /*" -1982- IF V0APOL-RAMO = V1PAR-RAMO-PST */

                    if (V0APOL_RAMO == V1PAR_RAMO_PST)
                    {

                        /*" -1984- PERFORM 600-000-GERA-TERVIG */

                        M_600_000_GERA_TERVIG_SECTION();

                        /*" -1987- ELSE */
                    }
                    else
                    {


                        /*" -1988- IF MPERI-PAGAMENTO = 0 */

                        if (MPERI_PAGAMENTO == 0)
                        {

                            /*" -1989- PERFORM 600-010-GERA-TERVIG */

                            M_600_010_GERA_TERVIG_SECTION();

                            /*" -1990- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                            _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                            /*" -1991- ELSE */
                        }
                        else
                        {


                            /*" -1992- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                            _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                            /*" -1993- END-IF */
                        }


                        /*" -1994- END-IF */
                    }


                    /*" -1996- END-IF */
                }


                /*" -1998- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -2002- COMPUTE VGPCT-COBERTURA2 ROUNDED = MPRM-AP-ATU * 100 / WPRMTOT */
                VGPCT_COBERTURA2.Value = MPRM_AP_ATU * 100 / WPRMTOT;

                /*" -2003- IF VGPCT-COBERTURA2 EQUAL 0 */

                if (VGPCT_COBERTURA2 == 0)
                {

                    /*" -2005- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 */

                    if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
                    {

                        /*" -2007- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                        VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                        /*" -2009- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -2010- PERFORM 300-000-INSERE-V0COBERAPOL */

                        M_300_000_INSERE_V0COBERAPOL_SECTION();

                        /*" -2011- ELSE */
                    }
                    else
                    {


                        /*" -2013- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -2014- ELSE */
                    }

                }
                else
                {


                    /*" -2016- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                    VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                    /*" -2018- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                    _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                    /*" -2020- PERFORM 300-000-INSERE-V0COBERAPOL. */

                    M_300_000_INSERE_V0COBERAPOL_SECTION();
                }

            }


            /*" -2020- PERFORM 210-030-VERIFICA-INVPERM. */

            M_210_030_VERIFICA_INVPERM(true);

        }

        [StopWatch]
        /*" M-210-030-VERIFICA-INVPERM */
        private void M_210_030_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -2025- IF MIMP-INVPERM-ATU NOT EQUAL ZEROS */

            if (MIMP_INVPERM_ATU != 00)
            {

                /*" -2029- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -2030- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -2032- MOVE 02 TO VGCOD-COBERTURA */
                _.Move(02, VGCOD_COBERTURA);

                /*" -2036- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-INVPERM-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_INVPERM_ATU / DVLCRUZAD_IMP;

                /*" -2038- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -2041- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -2045- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -2046- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -2049- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -2052- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 OR MNUM-APOLICE = 108210696253 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005 || MNUM_APOLICE == 108210696253)
                {

                    /*" -2053- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -2055- ELSE */
                }
                else
                {


                    /*" -2056- IF V0APOL-RAMO = V1PAR-RAMO-PST */

                    if (V0APOL_RAMO == V1PAR_RAMO_PST)
                    {

                        /*" -2058- PERFORM 600-000-GERA-TERVIG */

                        M_600_000_GERA_TERVIG_SECTION();

                        /*" -2061- ELSE */
                    }
                    else
                    {


                        /*" -2062- IF MPERI-PAGAMENTO = 0 */

                        if (MPERI_PAGAMENTO == 0)
                        {

                            /*" -2063- PERFORM 600-010-GERA-TERVIG */

                            M_600_010_GERA_TERVIG_SECTION();

                            /*" -2064- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                            _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                            /*" -2065- ELSE */
                        }
                        else
                        {


                            /*" -2066- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                            _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                            /*" -2067- END-IF */
                        }


                        /*" -2068- END-IF */
                    }


                    /*" -2070- END-IF */
                }


                /*" -2072- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -2073- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -2075- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -2075- PERFORM 210-040-VERIFICA-AMDS. */

            M_210_040_VERIFICA_AMDS(true);

        }

        [StopWatch]
        /*" M-210-040-VERIFICA-AMDS */
        private void M_210_040_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -2080- IF MIMP-AMDS-ATU NOT EQUAL ZEROS */

            if (MIMP_AMDS_ATU != 00)
            {

                /*" -2084- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -2085- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -2087- MOVE 03 TO VGCOD-COBERTURA */
                _.Move(03, VGCOD_COBERTURA);

                /*" -2091- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-AMDS-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_AMDS_ATU / DVLCRUZAD_IMP;

                /*" -2093- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -2096- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -2100- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -2101- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -2104- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -2106- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -2107- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -2109- ELSE */
                }
                else
                {


                    /*" -2110- IF V0APOL-RAMO = V1PAR-RAMO-PST */

                    if (V0APOL_RAMO == V1PAR_RAMO_PST)
                    {

                        /*" -2112- PERFORM 600-000-GERA-TERVIG */

                        M_600_000_GERA_TERVIG_SECTION();

                        /*" -2115- ELSE */
                    }
                    else
                    {


                        /*" -2116- IF MPERI-PAGAMENTO = 0 */

                        if (MPERI_PAGAMENTO == 0)
                        {

                            /*" -2117- PERFORM 600-010-GERA-TERVIG */

                            M_600_010_GERA_TERVIG_SECTION();

                            /*" -2118- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                            _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                            /*" -2119- ELSE */
                        }
                        else
                        {


                            /*" -2120- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                            _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                            /*" -2121- END-IF */
                        }


                        /*" -2122- END-IF */
                    }


                    /*" -2124- END-IF */
                }


                /*" -2126- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -2127- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -2129- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -2129- PERFORM 210-050-VERIFICA-DH. */

            M_210_050_VERIFICA_DH(true);

        }

        [StopWatch]
        /*" M-210-050-VERIFICA-DH */
        private void M_210_050_VERIFICA_DH(bool isPerform = false)
        {
            /*" -2134- IF MIMP-DH-ATU NOT EQUAL ZEROS */

            if (MIMP_DH_ATU != 00)
            {

                /*" -2138- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -2139- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -2141- MOVE 04 TO VGCOD-COBERTURA */
                _.Move(04, VGCOD_COBERTURA);

                /*" -2145- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DH-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DH_ATU / DVLCRUZAD_IMP;

                /*" -2147- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -2150- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -2154- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -2155- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -2158- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -2160- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -2161- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -2163- ELSE */
                }
                else
                {


                    /*" -2164- IF V0APOL-RAMO = V1PAR-RAMO-PST */

                    if (V0APOL_RAMO == V1PAR_RAMO_PST)
                    {

                        /*" -2166- PERFORM 600-000-GERA-TERVIG */

                        M_600_000_GERA_TERVIG_SECTION();

                        /*" -2169- ELSE */
                    }
                    else
                    {


                        /*" -2170- IF MPERI-PAGAMENTO = 0 */

                        if (MPERI_PAGAMENTO == 0)
                        {

                            /*" -2171- PERFORM 600-010-GERA-TERVIG */

                            M_600_010_GERA_TERVIG_SECTION();

                            /*" -2172- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                            _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                            /*" -2173- ELSE */
                        }
                        else
                        {


                            /*" -2174- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                            _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                            /*" -2175- END-IF */
                        }


                        /*" -2176- END-IF */
                    }


                    /*" -2178- END-IF */
                }


                /*" -2180- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -2181- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -2183- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -2183- PERFORM 210-060-VERIFICA-DIT. */

            M_210_060_VERIFICA_DIT(true);

        }

        [StopWatch]
        /*" M-210-060-VERIFICA-DIT */
        private void M_210_060_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -2188- IF MIMP-DIT-ATU NOT EQUAL ZEROS */

            if (MIMP_DIT_ATU != 00)
            {

                /*" -2192- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -2193- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -2195- MOVE 05 TO VGCOD-COBERTURA */
                _.Move(05, VGCOD_COBERTURA);

                /*" -2199- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DIT-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DIT_ATU / DVLCRUZAD_IMP;

                /*" -2201- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -2204- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -2208- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -2209- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -2212- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -2214- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -2215- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -2217- ELSE */
                }
                else
                {


                    /*" -2218- IF V0APOL-RAMO = V1PAR-RAMO-PST */

                    if (V0APOL_RAMO == V1PAR_RAMO_PST)
                    {

                        /*" -2220- PERFORM 600-000-GERA-TERVIG */

                        M_600_000_GERA_TERVIG_SECTION();

                        /*" -2223- ELSE */
                    }
                    else
                    {


                        /*" -2224- IF MPERI-PAGAMENTO = 0 */

                        if (MPERI_PAGAMENTO == 0)
                        {

                            /*" -2225- PERFORM 600-010-GERA-TERVIG */

                            M_600_010_GERA_TERVIG_SECTION();

                            /*" -2226- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                            _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                            /*" -2227- ELSE */
                        }
                        else
                        {


                            /*" -2228- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                            _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                            /*" -2229- END-IF */
                        }


                        /*" -2230- END-IF */
                    }


                    /*" -2232- END-IF */
                }


                /*" -2234- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -2235- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -2235- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-SECTION */
        private void M_300_000_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -2338- MOVE '300-000-INSERE-V0COBERAPOL' TO PARAGRAFO */
            _.Move("300-000-INSERE-V0COBERAPOL", WABEND.PARAGRAFO);

            /*" -2341- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WABEND.WNR_EXEC_SQL);

            /*" -2349- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -2370- PERFORM M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1 */

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -2373- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2374- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -2377- DISPLAY 'VG0010B - DUPLICIDADE NA V0COBERAPOL  ' VGNUM-APOLICE ' ' VGNRENDOS ' ' VGNUM-ITEM ' ' VGOCORHIST ' ' VGCOD-COBERTURA */

                    $"VG0010B - DUPLICIDADE NA V0COBERAPOL  {VGNUM_APOLICE} {VGNRENDOS} {VGNUM_ITEM} {VGOCORHIST} {VGCOD_COBERTURA}"
                    .Display();

                    /*" -2378- ELSE */
                }
                else
                {


                    /*" -2381- DISPLAY 'VG0010B - PROBLEMAS NA INCLUSAO V0COBERAPOL  ' VGNUM-APOLICE ' ' VGNRENDOS ' ' VGNUM-ITEM */

                    $"VG0010B - PROBLEMAS NA INCLUSAO V0COBERAPOL  {VGNUM_APOLICE} {VGNRENDOS} {VGNUM_ITEM}"
                    .Display();

                    /*" -2382- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -2384- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2386- MOVE 'ERRO NA INCLUSAO DA VIEW V0COBERAPOL' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA INCLUSAO DA VIEW V0COBERAPOL", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2387- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -2388- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2389- END-IF */
                }


                /*" -2389- END-IF. */
            }


        }

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -2370- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:VGNUM-APOLICE, :VGNRENDOS, :VGNUM-ITEM, :VGOCORHIST, :VGRAMOFR, :VGMODALIFR, :VGCOD-COBERTURA, :VGIMP-SEGURADA-IX, :VGPRM-TARIFARIO-IX, :VGIMP-SEGURADA-VAR, :PRM-TARIFARIO-VAR, :VGPCT-COBERTURA, :VGFATOR-MULTIPLICA, :VGDATA-INIVIGENCIA, :VGDATA-TERVIGENCIA, :MCOD-EMPRESA:WCOD-EMPRESA, CURRENT TIMESTAMP, :VGCOD-SITUACAO:VGCOD-SIT-I) END-EXEC. */

            var m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                VGNUM_APOLICE = VGNUM_APOLICE.ToString(),
                VGNRENDOS = VGNRENDOS.ToString(),
                VGNUM_ITEM = VGNUM_ITEM.ToString(),
                VGOCORHIST = VGOCORHIST.ToString(),
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
                VGCOD_SIT_I = VGCOD_SIT_I.ToString(),
            };

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_300_999_EXIT*/

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-SECTION */
        private void M_330_000_INSERE_V0HISTSEGVG_SECTION()
        {
            /*" -2406- MOVE '330-000-INCLUI-V0HISTSEGVG' TO PARAGRAFO */
            _.Move("330-000-INCLUI-V0HISTSEGVG", WABEND.PARAGRAFO);

            /*" -2409- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WABEND.WNR_EXEC_SQL);

            /*" -2410- ACCEPT WHORA-OPERACAO-1 FROM TIME */
            _.Move(_.AcceptDate("TIME"), WHORA_OPERACAO_1);

            /*" -2411- MOVE WHORA-OPERACAO-2 TO WHORA-OPERACAO-R */
            _.Move(WHORA_PER_X.WHORA_OPERACAO_2, WHORA_OPERACAO_R);

            /*" -2412- MOVE WHORA-HORA-W TO WHORA-HORA */
            _.Move(WHORA_OPERACAO.WHORA_HORA_W, WHORA_OPERACAO_WORK.WHORA_HORA);

            /*" -2413- MOVE WHORA-MINU-W TO WHORA-MINU */
            _.Move(WHORA_OPERACAO.WHORA_MINU_W, WHORA_OPERACAO_WORK.WHORA_MINU);

            /*" -2414- MOVE WHORA-SEGU-W TO WHORA-SEGU */
            _.Move(WHORA_OPERACAO.WHORA_SEGU_W, WHORA_OPERACAO_WORK.WHORA_SEGU);

            /*" -2415- MOVE WHORA-OPERACAO-WORK-R TO HHORA-OPERACAO */
            _.Move(WHORA_OPERACAO_WORK_R, HHORA_OPERACAO);

            /*" -2417- MOVE 1 TO HOCORR-HISTORICO */
            _.Move(1, HOCORR_HISTORICO);

            /*" -2426- MOVE COD-SUBGRUPO-TRANS TO HCOD-SUBGRUP-TRANS. */
            _.Move(COD_SUBGRUPO_TRANS, HCOD_SUBGRUP_TRANS);

            /*" -2428- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -2445- PERFORM M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1 */

            M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1();

            /*" -2448- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -2449- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -2450- DISPLAY 'VG0010B - DUPLICIDADE NA V0HISTSEGVG ' */
                    _.Display($"VG0010B - DUPLICIDADE NA V0HISTSEGVG ");

                    /*" -2453- DISPLAY 'APOLICE ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' NRCERTIF ' MNUM-CERTIFICADO ' SNUM-ITEM ' SNUM-ITEM */

                    $"APOLICE {MNUM_APOLICE} {MCOD_SUBGRUPO} NRCERTIF {MNUM_CERTIFICADO} SNUM-ITEM {SNUM_ITEM}"
                    .Display();

                    /*" -2454- ELSE */
                }
                else
                {


                    /*" -2455- DISPLAY 'VG0010B - PROBLEMAS NA INCLUSAO V0HISTSEGVG ' */
                    _.Display($"VG0010B - PROBLEMAS NA INCLUSAO V0HISTSEGVG ");

                    /*" -2458- DISPLAY 'APOLICE ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' NRCERTIF ' MNUM-CERTIFICADO ' SNUM-ITEM ' SNUM-ITEM */

                    $"APOLICE {MNUM_APOLICE} {MCOD_SUBGRUPO} NRCERTIF {MNUM_CERTIFICADO} SNUM-ITEM {SNUM_ITEM}"
                    .Display();

                    /*" -2459- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -2460- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2462- MOVE 'ERRO NA INCLUSAO DA VIEW V0HISTSEGVG' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA INCLUSAO DA VIEW V0HISTSEGVG", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2463- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -2464- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2465- END-IF */
                }


                /*" -2465- END-IF. */
            }


        }

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-DB-INSERT-1 */
        public void M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1()
        {
            /*" -2445- EXEC SQL INSERT INTO SEGUROS.V0HISTSEGVG VALUES (:MNUM-APOLICE, :MCOD-SUBGRUPO, :SNUM-ITEM, :MCOD-OPERACAO, :V1SISTEMA-DTMOVABE, :HHORA-OPERACAO, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :HOCORR-HISTORICO, :HCOD-SUBGRUP-TRANS, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MCOD-USUARIO, :MCOD-EMPRESA:WCOD-EMPRESA, :V1EN-COD-MOEDA-IMP:WCOD-MOEDA, :V1EN-COD-MOEDA-PRM:WCOD-MOEDA) END-EXEC. */

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
        /*" M-360-000-INSERE-V0CONTACOR-SECTION */
        private void M_360_000_INSERE_V0CONTACOR_SECTION()
        {
            /*" -2482- MOVE '360-000-INSERE-V0CONTACOR' TO PARAGRAFO */
            _.Move("360-000-INSERE-V0CONTACOR", WABEND.PARAGRAFO);

            /*" -2487- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", WABEND.WNR_EXEC_SQL);

            /*" -2504- PERFORM M_360_000_INSERE_V0CONTACOR_DB_INSERT_1 */

            M_360_000_INSERE_V0CONTACOR_DB_INSERT_1();

            /*" -2507- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -2508- IF (SQLCODE EQUAL -803) */

                if ((DB.SQLCODE == -803))
                {

                    /*" -2509- DISPLAY 'VG0010B - DUPLICIDADE NA V0CONTACOR ' */
                    _.Display($"VG0010B - DUPLICIDADE NA V0CONTACOR ");

                    /*" -2510- DISPLAY MCOD-CLIENTE ' ' MNUM-APOLICE */

                    $"{MCOD_CLIENTE} {MNUM_APOLICE}"
                    .Display();

                    /*" -2511- ELSE */
                }
                else
                {


                    /*" -2513- DISPLAY 'VG0010B - PROBLEMAS NA INCLUSAO V0CONTACOR  ' MCOD-CLIENTE ' ' MNUM-APOLICE */

                    $"VG0010B - PROBLEMAS NA INCLUSAO V0CONTACOR  {MCOD_CLIENTE} {MNUM_APOLICE}"
                    .Display();

                    /*" -2514- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -2516- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2518- MOVE 'ERRO NA INCLUSAO DA VIEW V0CONTADOR' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA INCLUSAO DA VIEW V0CONTADOR", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2519- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -2520- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -2521- END-IF */
                }


                /*" -2521- END-IF. */
            }


        }

        [StopWatch]
        /*" M-360-000-INSERE-V0CONTACOR-DB-INSERT-1 */
        public void M_360_000_INSERE_V0CONTACOR_DB_INSERT_1()
        {
            /*" -2504- EXEC SQL INSERT INTO SEGUROS.V0CONTACOR VALUES (:MCOD-CLIENTE, :MNUM-APOLICE, :MBCO-COBRANCA, :MAGE-COBRANCA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, '0' , :MNUM-CERTIFICADO, :MCOD-EMPRESA:WCOD-EMPRESA, :MAGE-COBRANCA:SQL-NOT-NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var m_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1 = new M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1()
            {
                MCOD_CLIENTE = MCOD_CLIENTE.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MBCO_COBRANCA = MBCO_COBRANCA.ToString(),
                MAGE_COBRANCA = MAGE_COBRANCA.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MCOD_EMPRESA = MCOD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                SQL_NOT_NULL = SQL_NOT_NULL.ToString(),
            };

            M_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1.Execute(m_360_000_INSERE_V0CONTACOR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_360_999_EXIT*/

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-SECTION */
        private void M_390_000_UPDATE_V0MOVIMENTO_SECTION()
        {
            /*" -2538- MOVE '390-000-UPDATE-V0MOVIMENTO' TO PARAGRAFO */
            _.Move("390-000-UPDATE-V0MOVIMENTO", WABEND.PARAGRAFO);

            /*" -2541- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", WABEND.WNR_EXEC_SQL);

            /*" -2549- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1 */

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1();

            /*" -2552- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2554- DISPLAY 'VG0010B - NAO EXISTE MOVIMENTO PARA ' MCOD-FONTE ' ' MNUM-PROPOSTA */

                $"VG0010B - NAO EXISTE MOVIMENTO PARA {MCOD_FONTE} {MNUM_PROPOSTA}"
                .Display();

                /*" -2555- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -2557- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2559- MOVE 'ERRO NA ATUALIZACAO DA VIEW V0MOVIMENTO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ATUALIZACAO DA VIEW V0MOVIMENTO", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2560- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -2565- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


            /*" -2567- IF (MNUM-APOLICE = 109300000559 OR 3009300000559) AND MDATA-MOVIMENTO < '2004-06-01' */

            if ((MNUM_APOLICE.In("109300000559", "3009300000559")) && MDATA_MOVIMENTO < "2004-06-01")
            {

                /*" -2569- MOVE '391' TO WNR-EXEC-SQL */
                _.Move("391", WABEND.WNR_EXEC_SQL);

                /*" -2612- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1 */

                M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1();

                /*" -2614- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2616- DISPLAY 'VG0010B - ERRO INSERT RELATORIOS    ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' V0RELA-NRCERTIF */

                    $"VG0010B - ERRO INSERT RELATORIOS    {MCOD_FONTE} {MNUM_PROPOSTA} {V0RELA_NRCERTIF}"
                    .Display();

                    /*" -2617- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -2619- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2621- MOVE 'ERRO NA INCLUSAO DA VIEW V0RELATORIOS' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA INCLUSAO DA VIEW V0RELATORIOS", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2622- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -2628- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2630- IF MNUM-APOLICE = 109300000680 AND MDATA-MOVIMENTO < '2004-07-10' */

            if (MNUM_APOLICE == 109300000680 && MDATA_MOVIMENTO < "2004-07-10")
            {

                /*" -2632- MOVE '392' TO WNR-EXEC-SQL */
                _.Move("392", WABEND.WNR_EXEC_SQL);

                /*" -2675- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2 */

                M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2();

                /*" -2677- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -2679- DISPLAY 'VG0010B - ERRO INSERT RELATORIOS    ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' V0RELA-NRCERTIF */

                    $"VG0010B - ERRO INSERT RELATORIOS    {MCOD_FONTE} {MNUM_PROPOSTA} {V0RELA_NRCERTIF}"
                    .Display();

                    /*" -2680- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -2682- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2684- MOVE 'ERRO NA INCLUSAO DA VIEW V0RELATORIOS' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA INCLUSAO DA VIEW V0RELATORIOS", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2685- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -2685- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-UPDATE-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1()
        {
            /*" -2549- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_INCLUSAO = :V1SISTEMA-DTMOVABE, DATA_NASCIMENTO = :MDATA-NASCIMENTO:WDATA-NASCIMENTO, DATA_REFERENCIA = :MDATA-REFERENCIA WHERE COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1()
            {
                MDATA_NASCIMENTO = MDATA_NASCIMENTO.ToString(),
                WDATA_NASCIMENTO = WDATA_NASCIMENTO.ToString(),
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-INSERT-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1()
        {
            /*" -2612- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0010B' , :V1SISTEMA-DTMOVABE, 'VP' , 'VP0198B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :MNUM-APOLICE, 0, 0, :V0RELA-NRCERTIF, 0, :MCOD-SUBGRUPO, :MCOD-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , ' ' , ' ' , ' ' , NULL, 0, NULL, CURRENT TIMESTAMP) END-EXEC */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-INSERT-2 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2()
        {
            /*" -2675- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VG0010B' , :V1SISTEMA-DTMOVABE, 'VP' , 'VP0199B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :MNUM-APOLICE, 0, 0, :V0RELA-NRCERTIF, 0, :MCOD-SUBGRUPO, :MCOD-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , ' ' , ' ' , ' ' , NULL, 0, NULL, CURRENT TIMESTAMP) END-EXEC */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-400-000-UPDATE-V0APOLICE-SECTION */
        private void M_400_000_UPDATE_V0APOLICE_SECTION()
        {
            /*" -2706- MOVE '400-000-UPDATE-V0APOLICE' TO PARAGRAFO */
            _.Move("400-000-UPDATE-V0APOLICE", WABEND.PARAGRAFO);

            /*" -2709- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WABEND.WNR_EXEC_SQL);

            /*" -2716- PERFORM M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1 */

            M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -2719- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2720- DISPLAY 'VG0010B - PROBLEMAS NO UPDATE V0APOLICE' */
                _.Display($"VG0010B - PROBLEMAS NO UPDATE V0APOLICE");

                /*" -2721- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -2723- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2725- MOVE 'ERRO NA ATUALIZACAO DA VIEW V0APOLICE' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ATUALIZACAO DA VIEW V0APOLICE", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2726- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -2726- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-400-000-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -2716- EXEC SQL UPDATE SEGUROS.V0APOLICE SET NUM_ITEM = :SNUM-ITEM, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0NUM-APOLICE END-EXEC. */

            var m_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                SNUM_ITEM = SNUM_ITEM.ToString(),
                V0NUM_APOLICE = V0NUM_APOLICE.ToString(),
            };

            M_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(m_400_000_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-420-000-CURSOR-V1BENEFIPROP-SECTION */
        private void M_420_000_CURSOR_V1BENEFIPROP_SECTION()
        {
            /*" -2744- MOVE '420-000-CURSOR-V1BENEFIPROP' TO PARAGRAFO */
            _.Move("420-000-CURSOR-V1BENEFIPROP", WABEND.PARAGRAFO);

            /*" -2747- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WABEND.WNR_EXEC_SQL);

            /*" -2767- PERFORM M_420_000_CURSOR_V1BENEFIPROP_DB_DECLARE_1 */

            M_420_000_CURSOR_V1BENEFIPROP_DB_DECLARE_1();

            /*" -2771- PERFORM M_420_000_CURSOR_V1BENEFIPROP_DB_OPEN_1 */

            M_420_000_CURSOR_V1BENEFIPROP_DB_OPEN_1();

            /*" -2774- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2779- DISPLAY 'VG0010B - PROBLEMAS OPEN     TBENEFIPROP ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' MCOD-FONTE ' ' MNUM-PROPOSTA */

                $"VG0010B - PROBLEMAS OPEN     TBENEFIPROP {MNUM_APOLICE} {MCOD_SUBGRUPO} {MCOD_FONTE} {MNUM_PROPOSTA}"
                .Display();

                /*" -2780- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -2782- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2784- MOVE 'ERRO NA ABERTURA DO CURSOR TBENEFIPROP' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ABERTURA DO CURSOR TBENEFIPROP", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2785- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -2785- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-420-000-CURSOR-V1BENEFIPROP-DB-OPEN-1 */
        public void M_420_000_CURSOR_V1BENEFIPROP_DB_OPEN_1()
        {
            /*" -2771- EXEC SQL OPEN TBENEFIPROP END-EXEC. */

            TBENEFIPROP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-430-000-LE-BENEFIPROP-SECTION */
        private void M_430_000_LE_BENEFIPROP_SECTION()
        {
            /*" -2803- MOVE '430-000-LE-BENEFIPROP' TO PARAGRAFO */
            _.Move("430-000-LE-BENEFIPROP", WABEND.PARAGRAFO);

            /*" -2806- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", WABEND.WNR_EXEC_SQL);

            /*" -2818- PERFORM M_430_000_LE_BENEFIPROP_DB_FETCH_1 */

            M_430_000_LE_BENEFIPROP_DB_FETCH_1();

            /*" -2822- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2823- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2823- PERFORM M_430_000_LE_BENEFIPROP_DB_CLOSE_1 */

                    M_430_000_LE_BENEFIPROP_DB_CLOSE_1();

                    /*" -2825- MOVE 'S' TO WFIM-BENEFIPROP */
                    _.Move("S", WFIM_BENEFIPROP);

                    /*" -2826- GO TO 430-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/ //GOTO
                    return;

                    /*" -2827- ELSE */
                }
                else
                {


                    /*" -2832- DISPLAY 'VG0010B - PROBLEMAS OPEN     TBENEFIPROP ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' MCOD-FONTE ' ' MNUM-PROPOSTA */

                    $"VG0010B - PROBLEMAS OPEN     TBENEFIPROP {MNUM_APOLICE} {MCOD_SUBGRUPO} {MCOD_FONTE} {MNUM_PROPOSTA}"
                    .Display();

                    /*" -2833- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -2835- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -2837- MOVE 'ERRO NA LEITURA DO CURSOR TBENEFIPROP' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NA LEITURA DO CURSOR TBENEFIPROP", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -2838- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -2840- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -2840- PERFORM 470-000-INCLUI-V0BENEFICIA. */

            M_470_000_INCLUI_V0BENEFICIA_SECTION();

        }

        [StopWatch]
        /*" M-430-000-LE-BENEFIPROP-DB-FETCH-1 */
        public void M_430_000_LE_BENEFIPROP_DB_FETCH_1()
        {
            /*" -2818- EXEC SQL FETCH TBENEFIPROP INTO :NUM-APOLICE, :COD-SUBGRUPO, :COD-FONTE, :NUM-PROPOSTA, :NUM-BENEFICIARIO, :NOME-BENEFICIARIO, :GRAU-PARENTESCO, :PCT-PART-BENEFICIA, :COD-USUARIO, :COD-EMPRESA:WCOD-EMPRESA END-EXEC. */

            if (TBENEFIPROP.Fetch())
            {
                _.Move(TBENEFIPROP.NUM_APOLICE, NUM_APOLICE);
                _.Move(TBENEFIPROP.COD_SUBGRUPO, COD_SUBGRUPO);
                _.Move(TBENEFIPROP.COD_FONTE, COD_FONTE);
                _.Move(TBENEFIPROP.NUM_PROPOSTA, NUM_PROPOSTA);
                _.Move(TBENEFIPROP.NUM_BENEFICIARIO, NUM_BENEFICIARIO);
                _.Move(TBENEFIPROP.NOME_BENEFICIARIO, NOME_BENEFICIARIO);
                _.Move(TBENEFIPROP.GRAU_PARENTESCO, GRAU_PARENTESCO);
                _.Move(TBENEFIPROP.PCT_PART_BENEFICIA, PCT_PART_BENEFICIA);
                _.Move(TBENEFIPROP.COD_USUARIO, COD_USUARIO);
                _.Move(TBENEFIPROP.COD_EMPRESA, COD_EMPRESA);
                _.Move(TBENEFIPROP.WCOD_EMPRESA, WCOD_EMPRESA);
            }

        }

        [StopWatch]
        /*" M-430-000-LE-BENEFIPROP-DB-CLOSE-1 */
        public void M_430_000_LE_BENEFIPROP_DB_CLOSE_1()
        {
            /*" -2823- EXEC SQL CLOSE TBENEFIPROP END-EXEC */

            TBENEFIPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_430_999_EXIT*/

        [StopWatch]
        /*" M-450-000-ROTINA-DIGITO-SECTION */
        private void M_450_000_ROTINA_DIGITO_SECTION()
        {
            /*" -2860- MOVE '450-000-ROTINA-DIGITO' TO PARAGRAFO */
            _.Move("450-000-ROTINA-DIGITO", WABEND.PARAGRAFO);

            /*" -2862- MOVE H-NUM-CERTIFICADO TO WCERTIFICADO. */
            _.Move(H_NUM_CERTIFICADO, W01DIGCERT.WCERTIFICADO);

            /*" -2864- CALL 'PROM1101' USING W01DIGCERT. */
            _.Call("PROM1101", W01DIGCERT);

            /*" -2864- MOVE WDIG TO H-DAC-CERTIFICADO. */
            _.Move(W01DIGCERT.WDIG, H_DAC_CERTIFICADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_450_999_EXIT*/

        [StopWatch]
        /*" M-470-000-INCLUI-V0BENEFICIA-SECTION */
        private void M_470_000_INCLUI_V0BENEFICIA_SECTION()
        {
            /*" -2898- MOVE '470-000-INCLUI-V0BENEFICIA' TO PARAGRAFO */
            _.Move("470-000-INCLUI-V0BENEFICIA", WABEND.PARAGRAFO);

            /*" -2900- MOVE '9999-12-31' TO DTTERVIG. */
            _.Move("9999-12-31", DTTERVIG);

            /*" -2904- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -2905- MOVE '470' TO WNR-EXEC-SQL */
            _.Move("470", WABEND.WNR_EXEC_SQL);

            /*" -2932- PERFORM M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1 */

            M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1();

            /*" -2935- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2937- DISPLAY 'VG0010B - PROBLEMAS INSERCAO V0BENEFICIA ' NUM-APOLICE ' ' COD-SUBGRUPO ' ' COD-FONTE */

                $"VG0010B - PROBLEMAS INSERCAO V0BENEFICIA {NUM_APOLICE} {COD_SUBGRUPO} {COD_FONTE}"
                .Display();

                /*" -2938- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -2940- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2942- MOVE 'ERRO NA INCLUSAO DA VIEW V0BENEFICIA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA INCLUSAO DA VIEW V0BENEFICIA", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2943- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -2943- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-470-000-INCLUI-V0BENEFICIA-DB-INSERT-1 */
        public void M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1()
        {
            /*" -2932- EXEC SQL INSERT INTO SEGUROS.BENEFICIARIOS (NUM_APOLICE , COD_SUBGRUPO , NUM_CERTIFICADO , DAC_CERTIFICADO , NUM_BENEFICIARIO , NOME_BENEFICIARIO , GRAU_PARENTESCO , PCT_PART_BENEFICIA, DATA_INIVIGENCIA , DATA_TERVIGENCIA , COD_USUARIO , COD_EMPRESA ) VALUES (:NUM-APOLICE, :COD-SUBGRUPO, :MNUM-CERTIFICADO, :DAC-CERTIFICADO, :NUM-BENEFICIARIO, :NOME-BENEFICIARIO, :GRAU-PARENTESCO, :PCT-PART-BENEFICIA, :MDATA-MOVIMENTO, :DTTERVIG, :COD-USUARIO, :COD-EMPRESA:WCOD-EMPRESA) END-EXEC. */

            var m_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1 = new M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1()
            {
                NUM_APOLICE = NUM_APOLICE.ToString(),
                COD_SUBGRUPO = COD_SUBGRUPO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                DAC_CERTIFICADO = DAC_CERTIFICADO.ToString(),
                NUM_BENEFICIARIO = NUM_BENEFICIARIO.ToString(),
                NOME_BENEFICIARIO = NOME_BENEFICIARIO.ToString(),
                GRAU_PARENTESCO = GRAU_PARENTESCO.ToString(),
                PCT_PART_BENEFICIA = PCT_PART_BENEFICIA.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                DTTERVIG = DTTERVIG.ToString(),
                COD_USUARIO = COD_USUARIO.ToString(),
                COD_EMPRESA = COD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
            };

            M_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1.Execute(m_470_000_INCLUI_V0BENEFICIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_470_999_EXIT*/

        [StopWatch]
        /*" M-500-000-UPDATE-V0NUMERO-OUTROS-SECTION */
        private void M_500_000_UPDATE_V0NUMERO_OUTROS_SECTION()
        {
            /*" -2960- MOVE '500-000-UPDATE-V0NUMERO-OUTROS' TO PARAGRAFO */
            _.Move("500-000-UPDATE-V0NUMERO-OUTROS", WABEND.PARAGRAFO);

            /*" -2963- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", WABEND.WNR_EXEC_SQL);

            /*" -2968- PERFORM M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1 */

            M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1();

            /*" -2972- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2974- DISPLAY 'VG0010B - PROBLEMAS ATUALIZACAO NUMERO-OUTROS' MNUM-CERTIFICADO */
                _.Display($"VG0010B - PROBLEMAS ATUALIZACAO NUMERO-OUTROS{MNUM_CERTIFICADO}");

                /*" -2975- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -2977- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -2979- MOVE 'ERRO NA ATUALIZACAO DA VIEW V1NUMERO_OUTROS' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ATUALIZACAO DA VIEW V1NUMERO_OUTROS", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -2980- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -2980- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-500-000-UPDATE-V0NUMERO-OUTROS-DB-UPDATE-1 */
        public void M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1()
        {
            /*" -2968- EXEC SQL UPDATE SEGUROS.V0NUMERO_OUTROS SET NUMCERVG = :H-NUM-CERTIFICADO WHERE NUMCERVG = :NUMCERVG END-EXEC. */

            var m_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1 = new M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1()
            {
                H_NUM_CERTIFICADO = H_NUM_CERTIFICADO.ToString(),
                NUMCERVG = NUMCERVG.ToString(),
            };

            M_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1.Execute(m_500_000_UPDATE_V0NUMERO_OUTROS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_EXIT*/

        [StopWatch]
        /*" M-520-000-UPDATE-MOVIMENTO-SECTION */
        private void M_520_000_UPDATE_MOVIMENTO_SECTION()
        {
            /*" -2997- MOVE '520-000-UPDATE-MOVIMENTO' TO PARAGRAFO */
            _.Move("520-000-UPDATE-MOVIMENTO", WABEND.PARAGRAFO);

            /*" -3000- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", WABEND.WNR_EXEC_SQL);

            /*" -3008- PERFORM M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1 */

            M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1();

            /*" -3012- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3014- DISPLAY 'VG0010B - PROBLEMAS ATUALIZACAO MOVIMENTO' MCOD-FONTE ' ' MNUM-PROPOSTA */

                $"VG0010B - PROBLEMAS ATUALIZACAO MOVIMENTO{MCOD_FONTE} {MNUM_PROPOSTA}"
                .Display();

                /*" -3015- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -3017- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3019- MOVE 'ERRO NA ATUALIZACAO DA VIEW V0MOVIMENTO' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NA ATUALIZACAO DA VIEW V0MOVIMENTO", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3020- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -3020- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-520-000-UPDATE-MOVIMENTO-DB-UPDATE-1 */
        public void M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1()
        {
            /*" -3008- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET NUM_CERTIFICADO = :H-NUM-CERTIFICADO, DAC_CERTIFICADO = :DAC-CERTIFICADO WHERE COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 = new M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1()
            {
                H_NUM_CERTIFICADO = H_NUM_CERTIFICADO.ToString(),
                DAC_CERTIFICADO = DAC_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1.Execute(m_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_520_999_EXIT*/

        [StopWatch]
        /*" M-600-000-GERA-TERVIG-SECTION */
        private void M_600_000_GERA_TERVIG_SECTION()
        {
            /*" -3037- MOVE '600-000-GERA-TERVIG' TO PARAGRAFO */
            _.Move("600-000-GERA-TERVIG", WABEND.PARAGRAFO);

            /*" -3040- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", WABEND.WNR_EXEC_SQL);

            /*" -3043- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", WABEND.WNR_EXEC_SQL);

            /*" -3050- PERFORM M_600_000_GERA_TERVIG_DB_SELECT_1 */

            M_600_000_GERA_TERVIG_DB_SELECT_1();

            /*" -3054- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3055- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3056- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -3057- ELSE */
                }
                else
                {


                    /*" -3059- DISPLAY 'VG0010B - PROBLEMAS ACESSO A PROPOSTA_FIDELIZ' ' NUM_PROPOSTA_SIVPF = ' MNUM-CERTIFICADO */

                    $"VG0010B - PROBLEMAS ACESSO A PROPOSTA_FIDELIZ NUM_PROPOSTA_SIVPF = {MNUM_CERTIFICADO}"
                    .Display();

                    /*" -3060- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -3062- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3064- MOVE 'ERRO NO ACESSO DA TABELA PROPOSTA_FIDELIZ' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO DA TABELA PROPOSTA_FIDELIZ", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3065- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -3066- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -3067- END-IF */
                }


                /*" -3068- ELSE */
            }
            else
            {


                /*" -3069- MOVE WK-DATA-TERVIG TO VGDATA-TERVIGENCIA */
                _.Move(WK_DATA_TERVIG, VGDATA_TERVIGENCIA);

                /*" -3069- END-IF. */
            }


        }

        [StopWatch]
        /*" M-600-000-GERA-TERVIG-DB-SELECT-1 */
        public void M_600_000_GERA_TERVIG_DB_SELECT_1()
        {
            /*" -3050- EXEC SQL SELECT DATA_PROPOSTA + COD_PLANO MONTHS INTO :WK-DATA-TERVIG FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_600_000_GERA_TERVIG_DB_SELECT_1_Query1 = new M_600_000_GERA_TERVIG_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_600_000_GERA_TERVIG_DB_SELECT_1_Query1.Execute(m_600_000_GERA_TERVIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WK_DATA_TERVIG, WK_DATA_TERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_600_999_EXIT*/

        [StopWatch]
        /*" M-600-010-GERA-TERVIG-SECTION */
        private void M_600_010_GERA_TERVIG_SECTION()
        {
            /*" -3084- MOVE '600-010-GERA-TERVIG' TO PARAGRAFO */
            _.Move("600-010-GERA-TERVIG", WABEND.PARAGRAFO);

            /*" -3087- MOVE '601' TO WNR-EXEC-SQL. */
            _.Move("601", WABEND.WNR_EXEC_SQL);

            /*" -3101- PERFORM M_600_010_GERA_TERVIG_DB_SELECT_1 */

            M_600_010_GERA_TERVIG_DB_SELECT_1();

            /*" -3104- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -3106- IF WNUM-CCT LESS 0 */

                if (WNUM_CCT < 0)
                {

                    /*" -3107- MOVE 36 TO WK-COD-CCT */
                    _.Move(36, WK_COD_CCT);

                    /*" -3108- MOVE '9999-12-31' TO WK-DATA-TERVIG */
                    _.Move("9999-12-31", WK_DATA_TERVIG);

                    /*" -3109- GO TO 601-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_601_999_EXIT*/ //GOTO
                    return;

                    /*" -3110- ELSE */
                }
                else
                {


                    /*" -3111- IF WK-COD-CCT EQUAL ZEROS */

                    if (WK_COD_CCT == 00)
                    {

                        /*" -3112- MOVE 36 TO WK-COD-CCT */
                        _.Move(36, WK_COD_CCT);

                        /*" -3113- MOVE '9999-12-31' TO WK-DATA-TERVIG */
                        _.Move("9999-12-31", WK_DATA_TERVIG);

                        /*" -3114- GO TO 601-999-EXIT */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_601_999_EXIT*/ //GOTO
                        return;

                        /*" -3115- END-IF */
                    }


                    /*" -3117- END-IF. */
                }

            }


            /*" -3118- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3119- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3120- MOVE '9999-12-31' TO WK-DATA-TERVIG */
                    _.Move("9999-12-31", WK_DATA_TERVIG);

                    /*" -3121- GO TO 601-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_601_999_EXIT*/ //GOTO
                    return;

                    /*" -3122- ELSE */
                }
                else
                {


                    /*" -3124- DISPLAY 'VG0010B - PROBLEMAS ACESSO A PRODUTOS_VG     ' ' NUM_PROPOSTA_SIVPF = ' MNUM-CERTIFICADO */

                    $"VG0010B - PROBLEMAS ACESSO A PRODUTOS_VG      NUM_PROPOSTA_SIVPF = {MNUM_CERTIFICADO}"
                    .Display();

                    /*" -3125- PERFORM 650-000-LIMPA-REGISTROS */

                    M_650_000_LIMPA_REGISTROS_SECTION();

                    /*" -3127- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                    _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                    /*" -3129- MOVE 'ERRO NO ACESSO DA TABELA PRODUTOS_VG' TO LD-DES-ERRO-SSAIDA */
                    _.Move("ERRO NO ACESSO DA TABELA PRODUTOS_VG", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                    /*" -3130- PERFORM 660-000-GRAVA-REGISTROS */

                    M_660_000_GRAVA_REGISTROS_SECTION();

                    /*" -3131- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -3132- END-IF */
                }


                /*" -3172- END-IF. */
            }


            /*" -3175- MOVE '602' TO WNR-EXEC-SQL. */
            _.Move("602", WABEND.WNR_EXEC_SQL);

            /*" -3184- PERFORM M_600_010_GERA_TERVIG_DB_SELECT_2 */

            M_600_010_GERA_TERVIG_DB_SELECT_2();

            /*" -3187- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3189- DISPLAY 'VG0010B - PROBLEMAS ACESSO A PROPOSTA_VA' ' NUM_CERTIFICADO = ' MNUM-CERTIFICADO */

                $"VG0010B - PROBLEMAS ACESSO A PROPOSTA_VA NUM_CERTIFICADO = {MNUM_CERTIFICADO}"
                .Display();

                /*" -3190- PERFORM 650-000-LIMPA-REGISTROS */

                M_650_000_LIMPA_REGISTROS_SECTION();

                /*" -3192- MOVE SQLCODE TO LD-COD-ERRO-DB2-SSAIDA */
                _.Move(DB.SQLCODE, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

                /*" -3194- MOVE 'ERRO NO ACESSO DA TABELA PROPOSTA_VA' TO LD-DES-ERRO-SSAIDA */
                _.Move("ERRO NO ACESSO DA TABELA PROPOSTA_VA", LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

                /*" -3195- PERFORM 660-000-GRAVA-REGISTROS */

                M_660_000_GRAVA_REGISTROS_SECTION();

                /*" -3195- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-600-010-GERA-TERVIG-DB-SELECT-1 */
        public void M_600_010_GERA_TERVIG_DB_SELECT_1()
        {
            /*" -3101- EXEC SQL SELECT COD_CCT, COD_PRODUTO, NOME_PRODUTO INTO :WK-COD-CCT:WNUM-CCT, :PRODUVG-COD-PRODUTO, :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :MNUM-APOLICE AND COD_SUBGRUPO = :MCOD-SUBGRUPO WITH UR END-EXEC. */

            var m_600_010_GERA_TERVIG_DB_SELECT_1_Query1 = new M_600_010_GERA_TERVIG_DB_SELECT_1_Query1()
            {
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
            };

            var executed_1 = M_600_010_GERA_TERVIG_DB_SELECT_1_Query1.Execute(m_600_010_GERA_TERVIG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WK_COD_CCT, WK_COD_CCT);
                _.Move(executed_1.WNUM_CCT, WNUM_CCT);
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_601_999_EXIT*/

        [StopWatch]
        /*" M-600-010-GERA-TERVIG-DB-SELECT-2 */
        public void M_600_010_GERA_TERVIG_DB_SELECT_2()
        {
            /*" -3184- EXEC SQL SELECT DATA_QUITACAO + :WK-COD-CCT MONTHS INTO :WK-DATA-TERVIG FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_600_010_GERA_TERVIG_DB_SELECT_2_Query1 = new M_600_010_GERA_TERVIG_DB_SELECT_2_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                WK_COD_CCT = WK_COD_CCT.ToString(),
            };

            var executed_1 = M_600_010_GERA_TERVIG_DB_SELECT_2_Query1.Execute(m_600_010_GERA_TERVIG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WK_DATA_TERVIG, WK_DATA_TERVIG);
            }


        }

        [StopWatch]
        /*" M-650-000-LIMPA-REGISTROS-SECTION */
        private void M_650_000_LIMPA_REGISTROS_SECTION()
        {
            /*" -3221- MOVE ZEROS TO LD-NUM-APOL-SSAIDA LD-COD-SUBG-SSAIDA LD-COD-PROD-SSAIDA LD-NUM-CERT-SUB-SSAIDA LD-NUM-CERT-SEG-SSAIDA LD-COD-ERRO-DB2-SSAIDA. */
            _.Move(0, LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA, LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA, LD_REG_SSAIDA.LD_COD_PROD_SSAIDA, LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA, LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA, LD_REG_SSAIDA.LD_COD_ERRO_DB2_SSAIDA);

            /*" -3225- MOVE SPACES TO LD-NOM-PROD-SSAIDA LD-DES-ERRO-DB2-SSAIDA LD-DES-ERRO-SSAIDA. */
            _.Move("", LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA, LD_REG_SSAIDA.LD_DES_ERRO_DB2_SSAIDA, LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA);

            /*" -3230- MOVE ZEROS TO LD-NUM-APOL-DSAIDA LD-COD-SUBG-DSAIDA LD-COD-PROD-DSAIDA LD-NUM-CERT-SUB-DSAIDA LD-NUM-CERT-SEG-DSAIDA. */
            _.Move(0, LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA, LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA, LD_REG_DSAIDA.LD_COD_PROD_DSAIDA, LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA, LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

            /*" -3231- MOVE SPACES TO LD-NOM-PROD-DSAIDA LD-DES-ERRO-DSAIDA. */
            _.Move("", LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA, LD_REG_DSAIDA.LD_DES_ERRO_DSAIDA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_650_999_EXIT*/

        [StopWatch]
        /*" M-660-000-GRAVA-REGISTROS-SECTION */
        private void M_660_000_GRAVA_REGISTROS_SECTION()
        {
            /*" -3252- IF LD-DES-ERRO-SSAIDA NOT EQUAL SPACES */

            if (!LD_REG_SSAIDA.LD_DES_ERRO_SSAIDA.IsEmpty())
            {

                /*" -3254- MOVE MNUM-APOLICE TO LD-NUM-APOL-SSAIDA */
                _.Move(MNUM_APOLICE, LD_REG_SSAIDA.LD_NUM_APOL_SSAIDA);

                /*" -3256- MOVE MCOD-SUBGRUPO TO LD-COD-SUBG-SSAIDA */
                _.Move(MCOD_SUBGRUPO, LD_REG_SSAIDA.LD_COD_SUBG_SSAIDA);

                /*" -3259- MOVE PRODUVG-COD-PRODUTO TO LD-COD-PROD-SSAIDA */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, LD_REG_SSAIDA.LD_COD_PROD_SSAIDA);

                /*" -3260- IF MTIPO-SEGURADO NOT EQUAL ZEROS */

                if (MTIPO_SEGURADO != 00)
                {

                    /*" -3262- MOVE MNUM-CERTIFICADO TO LD-NUM-CERT-SUB-SSAIDA */
                    _.Move(MNUM_CERTIFICADO, LD_REG_SSAIDA.LD_NUM_CERT_SUB_SSAIDA);

                    /*" -3263- ELSE */
                }
                else
                {


                    /*" -3265- MOVE MNUM-CERTIFICADO TO LD-NUM-CERT-SEG-SSAIDA */
                    _.Move(MNUM_CERTIFICADO, LD_REG_SSAIDA.LD_NUM_CERT_SEG_SSAIDA);

                    /*" -3267- END-IF */
                }


                /*" -3270- MOVE PRODUVG-NOME-PRODUTO TO LD-NOM-PROD-SSAIDA */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, LD_REG_SSAIDA.LD_NOM_PROD_SSAIDA);

                /*" -3271- WRITE RECORD-SSAIDA FROM LD-REG-SSAIDA */
                _.Move(LD_REG_SSAIDA.GetMoveValues(), RECORD_SSAIDA);

                SSAIDA.Write(RECORD_SSAIDA.GetMoveValues().ToString());

                /*" -3272- ADD 1 TO AC-ERRO-SISTEMA */
                AC_ERRO_SISTEMA.Value = AC_ERRO_SISTEMA + 1;

                /*" -3273- ELSE */
            }
            else
            {


                /*" -3275- MOVE MNUM-APOLICE TO LD-NUM-APOL-DSAIDA */
                _.Move(MNUM_APOLICE, LD_REG_DSAIDA.LD_NUM_APOL_DSAIDA);

                /*" -3277- MOVE MCOD-SUBGRUPO TO LD-COD-SUBG-DSAIDA */
                _.Move(MCOD_SUBGRUPO, LD_REG_DSAIDA.LD_COD_SUBG_DSAIDA);

                /*" -3280- MOVE PRODUVG-COD-PRODUTO TO LD-COD-PROD-DSAIDA */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO, LD_REG_DSAIDA.LD_COD_PROD_DSAIDA);

                /*" -3281- IF MTIPO-SEGURADO NOT EQUAL ZEROS */

                if (MTIPO_SEGURADO != 00)
                {

                    /*" -3283- MOVE MNUM-CERTIFICADO TO LD-NUM-CERT-SUB-DSAIDA */
                    _.Move(MNUM_CERTIFICADO, LD_REG_DSAIDA.LD_NUM_CERT_SUB_DSAIDA);

                    /*" -3284- ELSE */
                }
                else
                {


                    /*" -3286- MOVE MNUM-CERTIFICADO TO LD-NUM-CERT-SEG-DSAIDA */
                    _.Move(MNUM_CERTIFICADO, LD_REG_DSAIDA.LD_NUM_CERT_SEG_DSAIDA);

                    /*" -3288- END-IF */
                }


                /*" -3291- MOVE PRODUVG-NOME-PRODUTO TO LD-NOM-PROD-DSAIDA */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, LD_REG_DSAIDA.LD_NOM_PROD_DSAIDA);

                /*" -3292- WRITE RECORD-DSAIDA FROM LD-REG-DSAIDA */
                _.Move(LD_REG_DSAIDA.GetMoveValues(), RECORD_DSAIDA);

                DSAIDA.Write(RECORD_DSAIDA.GetMoveValues().ToString());

                /*" -3293- ADD 1 TO AC-ERRO-DADOS */
                AC_ERRO_DADOS.Value = AC_ERRO_DADOS + 1;

                /*" -3293- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_660_999_EXIT*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -3304- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", WABEND.WNR_EXEC_SQL);

            /*" -3306- MOVE 'R7777-CONS-MODALIDADE-APOL' TO PARAGRAFO */
            _.Move("R7777-CONS-MODALIDADE-APOL", WABEND.PARAGRAFO);

            /*" -3308- INITIALIZE REGISTRO-LINKAGE-GE0510S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -3309- MOVE MNUM-APOLICE TO LK-GE510-NUM-APOLICE */
            _.Move(MNUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -3311- MOVE MCOD-SUBGRUPO TO LK-GE510-COD-SUBGRUPO */
            _.Move(MCOD_SUBGRUPO, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -3313- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S. */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -3314- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -3315- MOVE LK-GE510-COD-MODALIDADE TO V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, V0APOL_MODALIDA);

                /*" -3316- ELSE */
            }
            else
            {


                /*" -3317- DISPLAY ' ' */
                _.Display($" ");

                /*" -3318- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3319- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -3320- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -3321- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3322- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -3323- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -3324- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -3325- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -3326- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -3327- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -3328- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -3329- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -3330- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO(); //GOTO
                return;

                /*" -3331- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -3342- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3345- DISPLAY 'INSERIDOS NA SEGURAVG ... ' AC-GRAVA */
            _.Display($"INSERIDOS NA SEGURAVG ... {AC_GRAVA}");

            /*" -3346- DISPLAY 'INSERIDOS NAS DEMAIS  ... ' AC-GRAVA-2 */
            _.Display($"INSERIDOS NAS DEMAIS  ... {AC_GRAVA_2}");

            /*" -3348- DISPLAY 'QUANT. DUPLICADO INCL ... ' AC-DUPLICIDADE */
            _.Display($"QUANT. DUPLICADO INCL ... {AC_DUPLICIDADE}");

            /*" -3350- DISPLAY 'FIM NORMAL      **** VG0010B ****' . */
            _.Display($"FIM NORMAL      **** VG0010B ****");

            /*" -3362- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -3365- CLOSE DSAIDA SSAIDA. */
            DSAIDA.Close();
            SSAIDA.Close();

            /*" -3365- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -3378- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -3379- MOVE SQLERRD(1) TO WSQLCODE1 */
            _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

            /*" -3380- MOVE SQLERRD(2) TO WSQLCODE2 */
            _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

            /*" -3381- MOVE SQLCODE TO WSQLCODE3 */
            _.Move(DB.SQLCODE, WSQLCODE3);

            /*" -3382- DISPLAY 'SQLERRMC <' SQLERRMC '>' */

            $"SQLERRMC <{DB.SQLERRMC}>"
            .Display();

            /*" -3384- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -3386- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -3390- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3393- DISPLAY 'APOLICE       ' MNUM-APOLICE. */
            _.Display($"APOLICE       {MNUM_APOLICE}");

            /*" -3394- DISPLAY 'SUBGRUPO      ' MCOD-SUBGRUPO. */
            _.Display($"SUBGRUPO      {MCOD_SUBGRUPO}");

            /*" -3395- DISPLAY 'FONTE         ' MCOD-FONTE. */
            _.Display($"FONTE         {MCOD_FONTE}");

            /*" -3396- DISPLAY 'PROPOSTA      ' MNUM-PROPOSTA. */
            _.Display($"PROPOSTA      {MNUM_PROPOSTA}");

            /*" -3397- DISPLAY 'CLIENTE       ' MCOD-CLIENTE. */
            _.Display($"CLIENTE       {MCOD_CLIENTE}");

            /*" -3398- DISPLAY 'TIPO INCLUSAO ' MTIPO-INCLUSAO. */
            _.Display($"TIPO INCLUSAO {MTIPO_INCLUSAO}");

            /*" -3402- DISPLAY 'USUARIO       ' MCOD-USUARIO. */
            _.Display($"USUARIO       {MCOD_USUARIO}");

            /*" -3404- IF AC-ERRO-DADOS GREATER ZEROS AND AC-ERRO-SISTEMA GREATER ZEROS */

            if (AC_ERRO_DADOS > 00 && AC_ERRO_SISTEMA > 00)
            {

                /*" -3405- MOVE 3 TO RETURN-CODE */
                _.Move(3, RETURN_CODE);

                /*" -3406- ELSE */
            }
            else
            {


                /*" -3407- IF AC-ERRO-SISTEMA GREATER ZEROS */

                if (AC_ERRO_SISTEMA > 00)
                {

                    /*" -3408- MOVE 2 TO RETURN-CODE */
                    _.Move(2, RETURN_CODE);

                    /*" -3409- ELSE */
                }
                else
                {


                    /*" -3410- IF AC-ERRO-DADOS GREATER ZEROS */

                    if (AC_ERRO_DADOS > 00)
                    {

                        /*" -3412- MOVE 1 TO RETURN-CODE. */
                        _.Move(1, RETURN_CODE);
                    }

                }

            }


            /*" -3414- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -3417- CLOSE DSAIDA SSAIDA. */
            DSAIDA.Close();
            SSAIDA.Close();

            /*" -3417- GOBACK. */

            throw new GoBack();

        }
    }
}