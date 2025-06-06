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
using Sias.VidaEmGrupo.DB2.VG0020B;

namespace Code
{
    public class VG0020B
    {
        public bool IsCall { get; set; }

        public VG0020B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                *** ALTERACAO ***                               *      */
        /*"      *   FUNCAO .................  LE TABELA MOVIMENTO E INCLUI DADOS *      */
        /*"      *                             NAS TABELAS ..:V0COBERAPOL         *      */
        /*"      *                                            V0HISTSEGVG         *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  PROCAS                             *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0020B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  AGOSTO/ 91                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11 - CADMUS 154.956                                   *      */
        /*"      *             - SELECIONAR MODALIDADE DA APOLICE A SER EMITIDA   *      */
        /*"      *               CHAMANDO SUBROTINA GE0510S.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/10/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.11    *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 10 - CORRECAO DE ABEND  - CADMUS 151.081              *      */
        /*"      *               MELHORIA DE PERFORMACE E TRATAMENTO DE ERRO NO   *      */
        /*"      *               FETCH DO CURSOR PRINCIPAL.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/05/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 09   - CORRECAO DE ABEND / MELHORA NA PERFORMANCE     *      */
        /*"      *                 RETIRAR APOLICE 107700000007 DO CURSOR POIS    *      */
        /*"      *              SOBRECARREGA A LEITURA EM MAIS DE 80000 REGISTROS *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/12/2015 - FRANK CARVALHO                               *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 08   - ALTERACAO                                      *      */
        /*"      *                 CORRECAO DE ABEND                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/12/2015 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 07   - INCLUS�O DE DISPLAY PARA ANALISE DE TERMINO 99 *      */
        /*"      *                 DURANTE PROCESSAMENTO DO NSGD                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/07/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO 06 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 05 CAD 105.599                                                */
        /*"      *          - NAO PROCESSAR CERTIFICADOS QUE NAO POSSUAM DADOS NA        */
        /*"      *            TABELA V0COBERAPOL                                         */
        /*"      *                                                                       */
        /*"      *   EM 10/11/2014 - ELIERMES OLIVEIRA                                   */
        /*"      *                                        PROCURE POR V.05               */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EM 07-11-2014 - ELIERMES OLIVEIRA                  *      */
        /*"      *          - CORRECAO PARA ABENDAR COM RETURN-CODE 99            *      */
        /*"      *                                        PROCURE POR V.03        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EM 02-10-2014 - JONNY ANDERSON C.SARAIVA           *      */
        /*"      *          - AJUSTE NO CONTEUDO DO CAMPO VGMODALIFR              *      */
        /*"      *                                        PROCURE POR V.02        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 04/11/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1108   *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EM 12-06-2008 - MARCOS(FAST COMPUTER)              *      */
        /*"      *             TRATA DATA TERMINO DE VIGENCIA DA V0COBERAPOL      *      */
        /*"      *                                        PROCURE POR V.01        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EFETUADA EM 17-03-1999 POR LUIZ CARLOS.            *      */
        /*"      *             GERAR DATA TERMINO DE VIGENCIA DO SEGURADO,        *      */
        /*"      *                                        PROCURE POR 'LC0399'.   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EFETUADA EM 28/05/1998 POR EDUARDO (CONSEDA02)     *      */
        /*"      *             CONVERSAO PARA O ANO 2000.                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EFETUADA EM 05/04/2000 POR MANOEL MESSIAS          *      */
        /*"      *             GERA CARENCIAS PARA OS SEGURADOS DO PREFERENCIAL   *      */
        /*"      *             VIDA COM IDADE ENTRE 61 E 80 ANOS.                 *      */
        /*"      *                                        PROCURE POR 'MM0400'.   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EFETUADA EM 05/05/2000 POR MANOEL MESSIAS          *      */
        /*"      *         1 - PARA AS OPERACOES 703 E 803 ATUALIZA ESTRUTURA DO  *      */
        /*"      *             MULTIPREMIADO E GERA CARENCIAS DEPENDENDO DA IDADE.*      */
        /*"      *         2 - PARA AS DEMAIS OPERACOES DE AUMENTO E REDUCAO NAO  *      */
        /*"      *             ATUALIZA A ESTRUTURA DO MULTIPREMIADO, MAS, GERA   *      */
        /*"      *             CARENCIAS DEPENDENDO DA IDADE.                     *      */
        /*"      *                                        PROCURE POR 'MM0500'.   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   ALTERACAO EFETUADA EM 13/04/2006 POR FAST COMPUTER           *      */
        /*"      *             DESFAZER O CONTROLE DE OCORRENCIA DA APOLICE DO    *      */
        /*"      *             CONSORCIO POIS ESTAVA DESPONTERANDO AS TABELAS.    *      */
        /*"      *                                        PROCURE POR 'FC0604'.   *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  PROPVA-SITUACAO            PIC  X(001).*/
        public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-FLAG-ERRO               PIC  X(001).*/
        public StringBasis WS_FLAG_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  WS-ERRO-COBER              PIC  9(006) VALUE  0.*/
        public IntBasis WS_ERRO_COBER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
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
        /*"77  CLIE-DTNASC                PIC  X(010).*/
        public StringBasis CLIE_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0COBP-TAXA                PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-DTINIVIG            PIC  X(010).*/
        public StringBasis V0COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0COBP-DTTERVIG            PIC  X(010).*/
        public StringBasis V0COBP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0COBP-IMPSEGUR            PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-QUANT-VIDAS         PIC S9(009)      COMP.*/
        public IntBasis V0COBP_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0COBP-IMPSEGIND           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-CODOPER             PIC S9(004)      COMP.*/
        public IntBasis V0COBP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0COBP-OPCAO-COBER         PIC  X(001).*/
        public StringBasis V0COBP_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0COBP-IMPMORNATU          PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPMORACID          PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPINVPERM          PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPAMDS             PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPDH               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPDIT              PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-VLPREMIO            PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-PRMVG               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-PRMAP               PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-QTTITCAP            PIC S9(004)      COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0COBP-VLTITCAP            PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-VLCUSTCAP           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPSEGCDC           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGCDC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-VLCUSTCDG           PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPSEGAUXF          PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-IMPSEGAUXF-I        PIC S9(004)      COMP.*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0COBP-VLCUSTAUXF          PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-VLCUSTAUXF-I        PIC S9(004)      COMP.*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0COBP-PRMDIT              PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0COBP_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0COBP-PRMDIT-I            PIC S9(004)      COMP.*/
        public IntBasis V0COBP_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0COBP-QTDIT               PIC S9(004)      COMP.*/
        public IntBasis V0COBP_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0COBP-QTDIT-I             PIC S9(004)      COMP.*/
        public IntBasis V0COBP_QTDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MOVI-OPERACAO            PIC S9(004)      COMP.*/
        public IntBasis V0MOVI_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WS-DT-MAIS30D              PIC  X(010).*/
        public StringBasis WS_DT_MAIS30D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SPERI-PAGAMENTO           PIC S9(004)      COMP.*/
        public IntBasis SPERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis SOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SNUM-ITEM                 PIC S9(009)      COMP.*/
        public IntBasis SNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  SDATA-TERVIGENCIA         PIC  X(010).*/
        public StringBasis SDATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SDATA-DTTERVIG            PIC  X(010).*/
        public StringBasis SDATA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SDATA-NASC                PIC  X(010).*/
        public StringBasis SDATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  SSIT-REGISTRO             PIC  X(001).*/
        public StringBasis SSIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  DVLCRUZAD-IMP             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  DVLCRUZAD-PRM             PIC S9(006)V9(9) COMP-3.*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V9(9)"), 9);
        /*"77  V1SISTEMA-DTMOVABE        PIC  X(010).*/
        public StringBasis V1SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
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
        /*"77  V0PROP-OCORHIST           PIC S9(004)      COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
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
        /*"77  VGCOD-SITUACAO            PIC X(001).*/
        public StringBasis VGCOD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  VGCOD-SITUACAO-I          PIC S9(004) COMP.*/
        public IntBasis VGCOD_SITUACAO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HHORA-OPERACAO            PIC  X(008).*/
        public StringBasis HHORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  HHOCORR-HISTORICO         PIC S9(004)      COMP.*/
        public IntBasis HHOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HOCORR-HISTORICO          PIC S9(004)      COMP.*/
        public IntBasis HOCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  HCOD-SUBGRUP-TRANS        PIC S9(004)      COMP.*/
        public IntBasis HCOD_SUBGRUP_TRANS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MLD-IDADE               PIC S9(004)      COMP.*/
        public IntBasis V0MLD_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0MLD-CAP-MN-ANT          PIC S9(013)V99   COMP-3.*/
        public DoubleBasis V0MLD_CAP_MN_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0CAR-OCORHIST            PIC S9(004)      COMP.*/
        public IntBasis V0CAR_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CAR-CARENCIA            PIC S9(004)      COMP.*/
        public IntBasis V0CAR_CARENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0CAR-DTTERVIG            PIC  X(010).*/
        public StringBasis V0CAR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  WDATA-TERVIGENCIA         PIC S9(004)      COMP.*/
        public IntBasis WDATA_TERVIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-DTTERVIG            PIC S9(004)      COMP.*/
        public IntBasis WDATA_DTTERVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-AVERBACAO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-ADMISSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-INCLUSAO            PIC S9(004)      COMP.*/
        public IntBasis WDATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASCIMENTO          PIC S9(004)      COMP.*/
        public IntBasis WDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASC                PIC S9(004)      COMP.*/
        public IntBasis WDATA_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-FATURA              PIC S9(004)      COMP.*/
        public IntBasis WDATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-REFERENCIA          PIC S9(004)      COMP.*/
        public IntBasis WDATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO           PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO1          PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO2          PIC S9(004)      COMP.*/
        public IntBasis WDATA_MOVIMENTO2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-EMPRESA              PIC S9(004)      COMP.*/
        public IntBasis WCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-MOEDA                PIC S9(004)      COMP VALUE +1.*/
        public IntBasis WCOD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +1);
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP.*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  REGISTRO-LINKAGE-GE0510S.*/
        public VG0020B_REGISTRO_LINKAGE_GE0510S REGISTRO_LINKAGE_GE0510S { get; set; } = new VG0020B_REGISTRO_LINKAGE_GE0510S();
        public class VG0020B_REGISTRO_LINKAGE_GE0510S : VarBasis
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
            public VG0020B_LK_GE510_MENSAGEM LK_GE510_MENSAGEM { get; set; } = new VG0020B_LK_GE510_MENSAGEM();
            public class VG0020B_LK_GE510_MENSAGEM : VarBasis
            {
                /*"       20 LK-GE510-SQLCODE        PIC -ZZ9.*/
                public IntBasis LK_GE510_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       20 FILLER                  PIC X(01).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       20 LK-GE510-MSG-RETORNO    PIC X(75).*/
                public StringBasis LK_GE510_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
                /*"01  WS-AUXILIARES.*/
            }
        }
        public VG0020B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new VG0020B_WS_AUXILIARES();
        public class VG0020B_WS_AUXILIARES : VarBasis
        {
            /*"  03            WANO-BISSEXTO       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WANO_BISSEXTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03            WS-IDADE            PIC S9(004)  COMP.*/
            public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            AC-GRAVA            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WFIM-INCLUSAO       PIC  X(001) VALUE 'N'.*/
            public StringBasis WFIM_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WAPOLICE-ATU        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ATU { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            WAPOLICE-ANT        PIC S9(013) VALUE +0 COMP-3.*/
            public IntBasis WAPOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  03            WTEM-MOVIMENTO      PIC  X(001) VALUE  'N'.*/
            public StringBasis WTEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03            WTEM-OCORHIST       PIC  X(001) VALUE  'N'.*/
            public StringBasis WTEM_OCORHIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03         WK-DATA1.*/
            public VG0020B_WK_DATA1 WK_DATA1 { get; set; } = new VG0020B_WK_DATA1();
            public class VG0020B_WK_DATA1 : VarBasis
            {
                /*"    05       WK-ANO1            PIC  9(004).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WK-MES1            PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WK-DIA1            PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WK-DATA2.*/
            }
            public VG0020B_WK_DATA2 WK_DATA2 { get; set; } = new VG0020B_WK_DATA2();
            public class VG0020B_WK_DATA2 : VarBasis
            {
                /*"    05       WK-ANO2            PIC  9(004).*/
                public IntBasis WK_ANO2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WK-MES2            PIC  9(002).*/
                public IntBasis WK_MES2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       WK-DIA2            PIC  9(002).*/
                public IntBasis WK_DIA2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-W01DTTRAB.*/
            }
            public VG0020B_WS_W01DTTRAB WS_W01DTTRAB { get; set; } = new VG0020B_WS_W01DTTRAB();
            public class VG0020B_WS_W01DTTRAB : VarBasis
            {
                /*"    05          WS-W01AATRAB        PIC  9(004).*/
                public IntBasis WS_W01AATRAB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W01T1TRAB        PIC  X(001).*/
                public StringBasis WS_W01T1TRAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01MMTRAB        PIC  9(002).*/
                public IntBasis WS_W01MMTRAB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2TRAB        PIC  X(001).*/
                public StringBasis WS_W01T2TRAB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05          WS-W01DDTRAB        PIC  9(002).*/
                public IntBasis WS_W01DDTRAB { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-OPERACAO-WORK.*/
            }
            public VG0020B_WHORA_OPERACAO_WORK WHORA_OPERACAO_WORK { get; set; } = new VG0020B_WHORA_OPERACAO_WORK();
            public class VG0020B_WHORA_OPERACAO_WORK : VarBasis
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
            /*"  03            WS-W01DTSQL.*/
            public VG0020B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG0020B_WS_W01DTSQL();
            public class VG0020B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01AASQL         PIC  9(004).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WHORA-OPERACAO.*/
            }
            public VG0020B_WHORA_OPERACAO WHORA_OPERACAO { get; set; } = new VG0020B_WHORA_OPERACAO();
            public class VG0020B_WHORA_OPERACAO : VarBasis
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
            /*"  03            WHORA-OPERACAO-1    PIC 9(08).*/
            public IntBasis WHORA_OPERACAO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"  03            WHORA-PER-X REDEFINES WHORA-OPERACAO-1.*/
            private _REDEF_VG0020B_WHORA_PER_X _whora_per_x { get; set; }
            public _REDEF_VG0020B_WHORA_PER_X WHORA_PER_X
            {
                get { _whora_per_x = new _REDEF_VG0020B_WHORA_PER_X(); _.Move(WHORA_OPERACAO_1, _whora_per_x); VarBasis.RedefinePassValue(WHORA_OPERACAO_1, _whora_per_x, WHORA_OPERACAO_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, WHORA_OPERACAO_1); }; return _whora_per_x; }
                set { VarBasis.RedefinePassValue(value, _whora_per_x, WHORA_OPERACAO_1); }
            }  //Redefines
            public class _REDEF_VG0020B_WHORA_PER_X : VarBasis
            {
                /*"         10  WHORA-OPERACAO-2       PIC 9(06).*/
                public IntBasis WHORA_OPERACAO_2 { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"         10  FILLER                 PIC 9(02).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  03            WPRMTOT             PIC S9(013)V99                                        VALUE +0 COMP-3.*/

                public _REDEF_VG0020B_WHORA_PER_X()
                {
                    WHORA_OPERACAO_2.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WABEND.*/
            public VG0020B_WABEND WABEND { get; set; } = new VG0020B_WABEND();
            public class VG0020B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VG0020B'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0020B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public VG0020B_LK_LINK LK_LINK { get; set; } = new VG0020B_LK_LINK();
        public class VG0020B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public VG0020B_TMOVIMENTO TMOVIMENTO { get; set; } = new VG0020B_TMOVIMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PROCEDURE-SECTION */

                M_0000_PROCEDURE_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PROCEDURE-SECTION */
        private void M_0000_PROCEDURE_SECTION()
        {
            /*" -478- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_000_000_PRINCIPAL */

            M_000_000_PRINCIPAL();

        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -482- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -484- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -487- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -490- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -491- DISPLAY '          PROGRAMA EM EXECUCAO VG0020B          ' */
            _.Display($"          PROGRAMA EM EXECUCAO VG0020B          ");

            /*" -492- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -494- DISPLAY 'VERSAO V.11: ' FUNCTION WHEN-COMPILED ' - 154.956' */

            $"VERSAO V.11: FUNCTION{_.WhenCompiled()} - 154.956"
            .Display();

            /*" -495- DISPLAY ' ' */
            _.Display($" ");

            /*" -502- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -503- DISPLAY '   ' */
            _.Display($"   ");

            /*" -504- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -511- DISPLAY '   ' . */
            _.Display($"   ");

            /*" -513- PERFORM 060-000-LER-TSISTEMA. */

            M_060_000_LER_TSISTEMA_SECTION();

            /*" -515- PERFORM 070-000-LER-V1PARAMRAMO. */

            M_070_000_LER_V1PARAMRAMO_SECTION();

            /*" -517- PERFORM 080-000-LER-V1MOEDA. */

            M_080_000_LER_V1MOEDA_SECTION();

            /*" -519- PERFORM 090-000-CURSOR-V1MOVIMENTO */

            M_090_000_CURSOR_V1MOVIMENTO_SECTION();

            /*" -523- DISPLAY '*** VG0020B *** PROCESSANDO ... AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"*** VG0020B *** PROCESSANDO ... AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -526- PERFORM 120-000-FETCH-V1MOVIMENTO UNTIL WFIM-MOVIMENTO = 'S' . */

            while (!(WS_AUXILIARES.WFIM_MOVIMENTO == "S"))
            {

                M_120_000_FETCH_V1MOVIMENTO_SECTION();
            }

            /*" -531- DISPLAY '*** VG0020B *** COMMITING ... AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*** VG0020B *** COMMITING ... AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -531- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -534- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -535- DISPLAY '******************* VG0020B ********************' . */
            _.Display($"******************* VG0020B ********************");

            /*" -536- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -537- DISPLAY 'TOTAL DE AUMENTOS/REDUCOES..... ' AC-GRAVA. */
            _.Display($"TOTAL DE AUMENTOS/REDUCOES..... {WS_AUXILIARES.AC_GRAVA}");

            /*" -538- DISPLAY 'TOTAL CERTIF SEM V0COBERAPOL... ' WS-ERRO-COBER */
            _.Display($"TOTAL CERTIF SEM V0COBERAPOL... {WS_ERRO_COBER}");

            /*" -539- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -540- DISPLAY '****************** FIM NORMAL ******************' */
            _.Display($"****************** FIM NORMAL ******************");

            /*" -542- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -543- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -543- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-SECTION */
        private void M_060_000_LER_TSISTEMA_SECTION()
        {
            /*" -550- MOVE '060-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("060-000-LER-TSISTEMA", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -552- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -559- PERFORM M_060_000_LER_TSISTEMA_DB_SELECT_1 */

            M_060_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -562- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -563- DISPLAY 'VG0020B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG0020B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -564- DISPLAY 'IDSISTEM =  VG ' */
                _.Display($"IDSISTEM =  VG ");

                /*" -564- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-060-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_060_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -559- EXEC SQL SELECT DTMOVABE INTO :V1SISTEMA-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC. */

            var m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_060_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_060_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEMA_DTMOVABE, V1SISTEMA_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_060_999_EXIT*/

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-SECTION */
        private void M_070_000_LER_V1PARAMRAMO_SECTION()
        {
            /*" -576- MOVE '070-000-LER-V1PARAMRAMO' TO PARAGRAFO. */
            _.Move("070-000-LER-V1PARAMRAMO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -578- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -584- PERFORM M_070_000_LER_V1PARAMRAMO_DB_SELECT_1 */

            M_070_000_LER_V1PARAMRAMO_DB_SELECT_1();

            /*" -587- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -588- DISPLAY 'VG0020B - NAO CONSTA REGISTRO NA V1PARAMRAMO' */
                _.Display($"VG0020B - NAO CONSTA REGISTRO NA V1PARAMRAMO");

                /*" -588- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-070-000-LER-V1PARAMRAMO-DB-SELECT-1 */
        public void M_070_000_LER_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -584- EXEC SQL SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP, :V1PAR-RAMO-PST FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

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
            /*" -599- MOVE '080-000-LER-V1MOEDA' TO PARAGRAFO. */
            _.Move("080-000-LER-V1MOEDA", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -601- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -610- PERFORM M_080_000_LER_V1MOEDA_DB_SELECT_1 */

            M_080_000_LER_V1MOEDA_DB_SELECT_1();

            /*" -613- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -614- DISPLAY 'VG0020B - NAO CONSTA REGISTRO NA V1MOEDA' */
                _.Display($"VG0020B - NAO CONSTA REGISTRO NA V1MOEDA");

                /*" -616- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -617- MOVE V1EN-COD-MOEDA-IMP TO V1EN-COD-MOEDA-PRM. */
            _.Move(V1EN_COD_MOEDA_IMP, V1EN_COD_MOEDA_PRM);

            /*" -617- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM. */
            _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

        }

        [StopWatch]
        /*" M-080-000-LER-V1MOEDA-DB-SELECT-1 */
        public void M_080_000_LER_V1MOEDA_DB_SELECT_1()
        {
            /*" -610- EXEC SQL SELECT CODUNIMO, VLCRUZAD INTO :V1EN-COD-MOEDA-IMP, :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE TIPO_MOEDA = '0' AND SITUACAO = '0' WITH UR END-EXEC. */

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
            /*" -630- MOVE '090-000-CURSOR-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("090-000-CURSOR-V1MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -632- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -724- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1();

            /*" -727- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1()
        {
            /*" -724- EXEC SQL DECLARE TMOVIMENTO CURSOR FOR SELECT A.NUM_APOLICE, A.COD_SUBGRUPO, A.COD_FONTE, A.NUM_PROPOSTA, A.TIPO_SEGURADO, A.NUM_CERTIFICADO, A.DAC_CERTIFICADO, A.TIPO_INCLUSAO, A.COD_CLIENTE, A.COD_AGENCIADOR, A.COD_CORRETOR, A.COD_PLANOVGAP, A.COD_PLANOAP, A.FAIXA, A.AUTOR_AUM_AUTOMAT, A.TIPO_BENEFICIARIO, A.PERI_PAGAMENTO, A.PERI_RENOVACAO, A.COD_OCUPACAO, A.ESTADO_CIVIL, A.IDE_SEXO, A.COD_PROFISSAO, A.NATURALIDADE, A.OCORR_ENDERECO, A.OCORR_END_COBRAN, A.BCO_COBRANCA, A.AGE_COBRANCA, A.DAC_COBRANCA, A.NUM_MATRICULA, A.NUM_CTA_CORRENTE, A.DAC_CTA_CORRENTE, A.VAL_SALARIO, A.TIPO_SALARIO, A.TIPO_PLANO, A.PCT_CONJUGE_VG, A.PCT_CONJUGE_AP, A.QTD_SAL_MORNATU, A.QTD_SAL_MORACID, A.QTD_SAL_INVPERM, A.TAXA_AP_MORACID, A.TAXA_AP_INVPERM, A.TAXA_AP_AMDS, A.TAXA_AP_DH, A.TAXA_AP_DIT, A.TAXA_VG, A.IMP_MORNATU_ANT, A.IMP_MORNATU_ATU, A.IMP_MORACID_ANT, A.IMP_MORACID_ATU, A.IMP_INVPERM_ANT, A.IMP_INVPERM_ATU, A.IMP_AMDS_ANT, A.IMP_AMDS_ATU, A.IMP_DH_ANT, A.IMP_DH_ATU, A.IMP_DIT_ANT, A.IMP_DIT_ATU, A.PRM_VG_ANT, A.PRM_VG_ATU, A.PRM_AP_ANT, A.PRM_AP_ATU, A.COD_OPERACAO, A.DATA_OPERACAO, A.COD_SUBGRUPO_TRANS, A.SIT_REGISTRO, A.COD_USUARIO, A.DATA_AVERBACAO, A.DATA_ADMISSAO, A.DATA_INCLUSAO, A.DATA_NASCIMENTO, A.DATA_FATURA, A.DATA_REFERENCIA, A.DATA_MOVIMENTO, A.DATA_MOVIMENTO - 1 DAY, A.COD_EMPRESA, B.RAMO, B.MODALIDA, A.DATA_MOVIMENTO + 30 DAYS FROM SEGUROS.V1MOVIMENTO A, SEGUROS.V0APOLICE B WHERE A.NUM_APOLICE <> 107700000007 AND A.DATA_AVERBACAO IS NOT NULL AND A.DATA_INCLUSAO IS NULL AND A.COD_OPERACAO >= 0700 AND A.COD_OPERACAO <= 0899 AND A.NUM_APOLICE = B.NUM_APOLICE ORDER BY A.NUM_CERTIFICADO, A.DATA_MOVIMENTO END-EXEC. */
            TMOVIMENTO = new VG0020B_TMOVIMENTO(false);
            string GetQuery_TMOVIMENTO()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
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
							B.RAMO
							, 
							B.MODALIDA
							, 
							A.DATA_MOVIMENTO + 30 DAYS 
							FROM SEGUROS.V1MOVIMENTO A
							, 
							SEGUROS.V0APOLICE B 
							WHERE 
							A.NUM_APOLICE <> 107700000007 AND 
							A.DATA_AVERBACAO IS NOT NULL AND 
							A.DATA_INCLUSAO IS NULL AND 
							A.COD_OPERACAO >= 0700 AND 
							A.COD_OPERACAO <= 0899 AND 
							A.NUM_APOLICE = B.NUM_APOLICE 
							ORDER BY A.NUM_CERTIFICADO
							, 
							A.DATA_MOVIMENTO";

                return query;
            }
            TMOVIMENTO.GetQueryEvent += GetQuery_TMOVIMENTO;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1()
        {
            /*" -727- EXEC SQL OPEN TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-SECTION */
        private void M_120_000_FETCH_V1MOVIMENTO_SECTION()
        {
            /*" -739- MOVE '120-000-FETCH-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("120-000-FETCH-V1MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -742- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -822- PERFORM M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1 */

            M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1();

            /*" -825- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -826- IF (SQLCODE EQUAL +100) */

                if ((DB.SQLCODE == +100))
                {

                    /*" -827- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", WS_AUXILIARES.WFIM_MOVIMENTO);

                    /*" -827- PERFORM M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1 */

                    M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1();

                    /*" -829- GO TO 120-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                    return;

                    /*" -830- ELSE */
                }
                else
                {


                    /*" -832- DISPLAY 'VG0020B - ERRO NO FETCH TMOVIMENTO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                    $"VG0020B - ERRO NO FETCH TMOVIMENTO {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                    .Display();

                    /*" -833- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -834- END-IF */
                }


                /*" -839- END-IF. */
            }


            /*" -841- PERFORM 150-000-SELECT-V1SEGURAVG. */

            M_150_000_SELECT_V1SEGURAVG_SECTION();

            /*" -842- IF SSIT-REGISTRO EQUAL '2' */

            if (SSIT_REGISTRO == "2")
            {

                /*" -844- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -845- IF SSIT-REGISTRO EQUAL 'N' */

            if (SSIT_REGISTRO == "N")
            {

                /*" -847- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -848- IF (WS-FLAG-ERRO EQUAL 'S' ) */

            if ((WS_FLAG_ERRO == "S"))
            {

                /*" -849- ADD 1 TO WS-ERRO-COBER */
                WS_ERRO_COBER.Value = WS_ERRO_COBER + 1;

                /*" -850- GO TO 120-000-FETCH-V1MOVIMENTO */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -852- END-IF. */
            }


            /*" -860- IF MIMP-MORNATU-ATU EQUAL ZEROS AND MIMP-MORACID-ATU EQUAL ZEROS */

            if (MIMP_MORNATU_ATU == 00 && MIMP_MORACID_ATU == 00)
            {

                /*" -862- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -870- IF MPRM-VG-ATU EQUAL ZEROS AND MPRM-AP-ATU EQUAL ZEROS */

            if (MPRM_VG_ATU == 00 && MPRM_AP_ATU == 00)
            {

                /*" -872- GO TO 120-000-FETCH-V1MOVIMENTO. */
                new Task(() => M_120_000_FETCH_V1MOVIMENTO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -875- MOVE MDATA-MOVIMENTO TO WS-W01DTSQL. */
            _.Move(MDATA_MOVIMENTO, WS_AUXILIARES.WS_W01DTSQL);

            /*" -877- IF MNUM-APOLICE EQUAL 97010000889 AND MCOD-OPERACAO NOT EQUAL 820 */

            if (MNUM_APOLICE == 97010000889 && MCOD_OPERACAO != 820)
            {

                /*" -879- MOVE WS-W01MMSQL TO MPERI-RENOVACAO. */
                _.Move(WS_AUXILIARES.WS_W01DTSQL.WS_W01MMSQL, MPERI_RENOVACAO);
            }


            /*" -881- MOVE SPERI-PAGAMENTO TO MPERI-PAGAMENTO. */
            _.Move(SPERI_PAGAMENTO, MPERI_PAGAMENTO);

            /*" -887- IF MNUM-APOLICE = 97010000889 AND MCOD-OPERACAO NOT EQUAL 820 AND MCOD-OPERACAO NOT EQUAL 891 AND MCOD-OPERACAO NOT EQUAL 892 AND MCOD-OPERACAO NOT EQUAL 893 AND MDATA-MOVIMENTO > '1994-02-15' */

            if (MNUM_APOLICE == 97010000889 && MCOD_OPERACAO != 820 && MCOD_OPERACAO != 891 && MCOD_OPERACAO != 892 && MCOD_OPERACAO != 893 && MDATA_MOVIMENTO > "1994-02-15")
            {

                /*" -889- MOVE 0 TO MPERI-PAGAMENTO. */
                _.Move(0, MPERI_PAGAMENTO);
            }


            /*" -903- PERFORM 155-000-DETERMINA-DTTERVIG. */

            M_155_000_DETERMINA_DTTERVIG_SECTION();

            /*" -905- PERFORM R7777-CONS-MODALIDADE-APOL. */

            R7777_CONS_MODALIDADE_APOL_SECTION();

            /*" -907- PERFORM 160-000-UPDATE-V0SEGURAVG. */

            M_160_000_UPDATE_V0SEGURAVG_SECTION();

            /*" -908- IF MDATA-MOVIMENTO GREATER MDATA-REFERENCIA */

            if (MDATA_MOVIMENTO > MDATA_REFERENCIA)
            {

                /*" -909- MOVE 01 TO WS-W01DDSQL */
                _.Move(01, WS_AUXILIARES.WS_W01DTSQL.WS_W01DDSQL);

                /*" -911- MOVE WS-W01DTSQL TO MDATA-REFERENCIA. */
                _.Move(WS_AUXILIARES.WS_W01DTSQL, MDATA_REFERENCIA);
            }


            /*" -914- MOVE MNUM-APOLICE TO WAPOLICE-ATU. */
            _.Move(MNUM_APOLICE, WS_AUXILIARES.WAPOLICE_ATU);

            /*" -916- PERFORM 180-000-ENCERRA-V0COBERAPOL. */

            M_180_000_ENCERRA_V0COBERAPOL_SECTION();

            /*" -918- PERFORM 210-000-MONTA-V0COBERAPOL. */

            M_210_000_MONTA_V0COBERAPOL_SECTION();

            /*" -920- PERFORM 330-000-INSERE-V0HISTSEGVG. */

            M_330_000_INSERE_V0HISTSEGVG_SECTION();

            /*" -922- PERFORM 390-000-UPDATE-V0MOVIMENTO. */

            M_390_000_UPDATE_V0MOVIMENTO_SECTION();

            /*" -923- IF MNUM-APOLICE = 97010000889 */

            if (MNUM_APOLICE == 97010000889)
            {

                /*" -929- IF MCOD-SUBGRUPO = (1 OR 1948 OR 1949 OR 1950 OR 1951 OR 2910) */

                if (MCOD_SUBGRUPO.In("1", "1948", "1949", "1950", "1951", "2910"))
                {

                    /*" -931- IF MCOD-USUARIO NOT = ( 'VA0119B' AND 'VA0129B' AND 'VA1184B' AND 'VA0128B' ) */

                    if (!MCOD_USUARIO.In("VA0119B", "VA0129B", "VA1184B", "VA0128B"))
                    {

                        /*" -939- PERFORM 400-000-ATUALIZA-COBERPROPVA. */

                        M_400_000_ATUALIZA_COBERPROPVA_SECTION();
                    }

                }

            }


            /*" -940- IF MNUM-APOLICE = 93010000890 */

            if (MNUM_APOLICE == 93010000890)
            {

                /*" -941- IF MCOD-OPERACAO = 703 OR 803 */

                if (MCOD_OPERACAO.In("703", "803"))
                {

                    /*" -942- PERFORM 400-000-ATUALIZA-COBERPROPVA */

                    M_400_000_ATUALIZA_COBERPROPVA_SECTION();

                    /*" -943- PERFORM 410-000-GERA-CARENCIAS */

                    M_410_000_GERA_CARENCIAS_SECTION();

                    /*" -944- ELSE */
                }
                else
                {


                    /*" -946- IF MCOD-OPERACAO GREATER 699 AND MCOD-OPERACAO LESS 800 */

                    if (MCOD_OPERACAO > 699 && MCOD_OPERACAO < 800)
                    {

                        /*" -947- PERFORM 420-000-GERA-CARENCIAS */

                        M_420_000_GERA_CARENCIAS_SECTION();

                        /*" -948- ELSE */
                    }
                    else
                    {


                        /*" -950- IF MCOD-OPERACAO GREATER 799 AND MCOD-OPERACAO LESS 900 */

                        if (MCOD_OPERACAO > 799 && MCOD_OPERACAO < 900)
                        {

                            /*" -950- PERFORM 420-000-GERA-CARENCIAS. */

                            M_420_000_GERA_CARENCIAS_SECTION();
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-DB-FETCH-1 */
        public void M_120_000_FETCH_V1MOVIMENTO_DB_FETCH_1()
        {
            /*" -822- EXEC SQL FETCH TMOVIMENTO INTO :MNUM-APOLICE, :MCOD-SUBGRUPO, :MCOD-FONTE, :MNUM-PROPOSTA, :MTIPO-SEGURADO, :MNUM-CERTIFICADO, :MDAC-CERTIFICADO, :MTIPO-INCLUSAO, :MCOD-CLIENTE, :MCOD-AGENCIADOR, :MCOD-CORRETOR, :MCOD-PLANOVGAP, :MCOD-PLANOAP, :MFAIXA, :MAUTOR-AUM-AUTOMAT, :MTIPO-BENEFICIARIO, :MPERI-PAGAMENTO, :MPERI-RENOVACAO, :MCOD-OCUPACAO, :MESTADO-CIVIL, :MIDE-SEXO, :MCOD-PROFISSAO, :MNATURALIDADE, :MOCORR-ENDERECO, :MOCORR-END-COBRAN, :MBCO-COBRANCA, :MAGE-COBRANCA, :MDAC-COBRANCA, :MNUM-MATRICULA, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, :MVAL-SALARIO, :MTIPO-SALARIO, :MTIPO-PLANO, :MPCT-CONJUGE-VG, :MPCT-CONJUGE-AP, :MQTD-SAL-MORNATU, :MQTD-SAL-MORACID, :MQTD-SAL-INVPERM, :MTAXA-AP-MORACID, :MTAXA-AP-INVPERM, :MTAXA-AP-AMDS, :MTAXA-AP-DH, :MTAXA-AP-DIT, :MTAXA-VG, :MIMP-MORNATU-ANT, :MIMP-MORNATU-ATU, :MIMP-MORACID-ANT, :MIMP-MORACID-ATU, :MIMP-INVPERM-ANT, :MIMP-INVPERM-ATU, :MIMP-AMDS-ANT, :MIMP-AMDS-ATU, :MIMP-DH-ANT, :MIMP-DH-ATU, :MIMP-DIT-ANT, :MIMP-DIT-ATU, :MPRM-VG-ANT, :MPRM-VG-ATU, :MPRM-AP-ANT, :MPRM-AP-ATU, :MCOD-OPERACAO, :MDATA-OPERACAO, :COD-SUBGRUPO-TRANS, :MSIT-REGISTRO, :MCOD-USUARIO, :MDATA-AVERBACAO:WDATA-AVERBACAO, :MDATA-ADMISSAO:WDATA-ADMISSAO, :MDATA-INCLUSAO:WDATA-INCLUSAO, :MDATA-NASCIMENTO:WDATA-NASCIMENTO, :MDATA-FATURA:WDATA-FATURA, :MDATA-REFERENCIA:WDATA-REFERENCIA, :MDATA-MOVIMENTO:WDATA-MOVIMENTO, :SDATA-MOVIMENTO:WDATA-MOVIMENTO1, :MCOD-EMPRESA:WCOD-EMPRESA, :V0APOL-RAMO, :V0APOL-MODALIDA, :WS-DT-MAIS30D:WDATA-MOVIMENTO2 END-EXEC. */

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
                _.Move(TMOVIMENTO.WS_DT_MAIS30D, WS_DT_MAIS30D);
                _.Move(TMOVIMENTO.WDATA_MOVIMENTO2, WDATA_MOVIMENTO2);
            }

        }

        [StopWatch]
        /*" M-120-000-FETCH-V1MOVIMENTO-DB-CLOSE-1 */
        public void M_120_000_FETCH_V1MOVIMENTO_DB_CLOSE_1()
        {
            /*" -827- EXEC SQL CLOSE TMOVIMENTO END-EXEC */

            TMOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-150-000-SELECT-V1SEGURAVG-SECTION */
        private void M_150_000_SELECT_V1SEGURAVG_SECTION()
        {
            /*" -962- MOVE '150-000-SELECT-V1SEGURAVG' TO PARAGRAFO */
            _.Move("150-000-SELECT-V1SEGURAVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -964- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -985- PERFORM M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1 */

            M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1();

            /*" -988- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -991- IF (MNUM-APOLICE EQUAL 109300000635 AND MCOD-SUBGRUPO EQUAL 1) */

                if ((MNUM_APOLICE == 109300000635 && MCOD_SUBGRUPO == 1))
                {

                    /*" -992- MOVE 'N' TO SSIT-REGISTRO */
                    _.Move("N", SSIT_REGISTRO);

                    /*" -993- ELSE */
                }
                else
                {


                    /*" -995- DISPLAY 'VG0020B - NAO EXISTE OCORRENCIA DE HISTORICO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                    $"VG0020B - NAO EXISTE OCORRENCIA DE HISTORICO {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                    .Display();

                    /*" -996- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -997- END-IF */
                }


                /*" -999- END-IF */
            }


            /*" -1001- IF SSIT-REGISTRO EQUAL '2' OR SSIT-REGISTRO EQUAL 'N' */

            if (SSIT_REGISTRO == "2" || SSIT_REGISTRO == "N")
            {

                /*" -1002- GO TO 150-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/ //GOTO
                return;

                /*" -1004- END-IF */
            }


            /*" -1006- PERFORM 152-000-SELECT-V0COBERAPOL. */

            M_152_000_SELECT_V0COBERAPOL_SECTION();

            /*" -1006- COMPUTE HOCORR-HISTORICO = SOCORR-HISTORICO + 1. */
            HOCORR_HISTORICO.Value = SOCORR_HISTORICO + 1;

        }

        [StopWatch]
        /*" M-150-000-SELECT-V1SEGURAVG-DB-SELECT-1 */
        public void M_150_000_SELECT_V1SEGURAVG_DB_SELECT_1()
        {
            /*" -985- EXEC SQL SELECT OCORR_HISTORICO, NUM_ITEM, PERI_RENOVACAO, PERI_PAGAMENTO, DATA_INIVIGENCIA + 1 YEAR - 1 DAY, DATA_ADMISSAO, DATA_NASCIMENTO, SIT_REGISTRO INTO :SOCORR-HISTORICO, :SNUM-ITEM, :MPERI-RENOVACAO, :SPERI-PAGAMENTO, :SDATA-TERVIGENCIA:WDATA-TERVIGENCIA, :SDATA-DTTERVIG:WDATA-DTTERVIG, :SDATA-NASC:WDATA-NASC, :SSIT-REGISTRO FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO WITH UR END-EXEC. */

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
                _.Move(executed_1.MPERI_RENOVACAO, MPERI_RENOVACAO);
                _.Move(executed_1.SPERI_PAGAMENTO, SPERI_PAGAMENTO);
                _.Move(executed_1.SDATA_TERVIGENCIA, SDATA_TERVIGENCIA);
                _.Move(executed_1.WDATA_TERVIGENCIA, WDATA_TERVIGENCIA);
                _.Move(executed_1.SDATA_DTTERVIG, SDATA_DTTERVIG);
                _.Move(executed_1.WDATA_DTTERVIG, WDATA_DTTERVIG);
                _.Move(executed_1.SDATA_NASC, SDATA_NASC);
                _.Move(executed_1.WDATA_NASC, WDATA_NASC);
                _.Move(executed_1.SSIT_REGISTRO, SSIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_150_999_EXIT*/

        [StopWatch]
        /*" M-152-000-SELECT-V0COBERAPOL-SECTION */
        private void M_152_000_SELECT_V0COBERAPOL_SECTION()
        {
            /*" -1018- MOVE '152-000-SELECT-V0COBERAPOL' TO PARAGRAFO */
            _.Move("152-000-SELECT-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1020- MOVE '152' TO WNR-EXEC-SQL. */
            _.Move("152", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1022- MOVE 'N' TO WS-FLAG-ERRO */
            _.Move("N", WS_FLAG_ERRO);

            /*" -1029- PERFORM M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1 */

            M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1();

            /*" -1033- IF (SQLCODE EQUAL 100) OR (SOCORR-HISTORICO EQUAL ZEROS) */

            if ((DB.SQLCODE == 100) || (SOCORR_HISTORICO == 00))
            {

                /*" -1035- DISPLAY 'VG0020B - NAO EXISTE OCORR DE V0COBERAPOL ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0020B - NAO EXISTE OCORR DE V0COBERAPOL {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1037- MOVE 'S' TO WS-FLAG-ERRO */
                _.Move("S", WS_FLAG_ERRO);

                /*" -1038- END-IF. */
            }


        }

        [StopWatch]
        /*" M-152-000-SELECT-V0COBERAPOL-DB-SELECT-1 */
        public void M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -1029- EXEC SQL SELECT VALUE(MAX(OCORHIST), 0) INTO :SOCORR-HISTORICO FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :MNUM-APOLICE AND NUM_ITEM = :SNUM-ITEM WITH UR END-EXEC. */

            var m_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 = new M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
            };

            var executed_1 = M_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1.Execute(m_152_000_SELECT_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SOCORR_HISTORICO, SOCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_152_999_EXIT*/

        [StopWatch]
        /*" M-155-000-DETERMINA-DTTERVIG-SECTION */
        private void M_155_000_DETERMINA_DTTERVIG_SECTION()
        {
            /*" -1055- MOVE '155-000-DETERMINA-DTTERVIG' TO PARAGRAFO */
            _.Move("155-000-DETERMINA-DTTERVIG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1057- MOVE '155' TO WNR-EXEC-SQL. */
            _.Move("155", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1058- IF WDATA-DTTERVIG EQUAL 0 */

            if (WDATA_DTTERVIG == 0)
            {

                /*" -1060- GO TO 155-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_155_999_EXIT*/ //GOTO
                return;
            }


            /*" -1061- IF SDATA-TERVIGENCIA LESS V1SISTEMA-DTMOVABE */

            if (SDATA_TERVIGENCIA < V1SISTEMA_DTMOVABE)
            {

                /*" -1062- MOVE SDATA-TERVIGENCIA TO WS-W01DTTRAB */
                _.Move(SDATA_TERVIGENCIA, WS_AUXILIARES.WS_W01DTTRAB);

                /*" -1063- ADD 1 TO WS-W01AATRAB */
                WS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB.Value = WS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB + 1;

                /*" -1064- IF WS-W01MMTRAB EQUAL 2 */

                if (WS_AUXILIARES.WS_W01DTTRAB.WS_W01MMTRAB == 2)
                {

                    /*" -1065- IF WS-W01DDTRAB GREATER 27 */

                    if (WS_AUXILIARES.WS_W01DTTRAB.WS_W01DDTRAB > 27)
                    {

                        /*" -1066- COMPUTE WANO-BISSEXTO = WS-W01AATRAB / 4 */
                        WS_AUXILIARES.WANO_BISSEXTO.Value = WS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB / 4;

                        /*" -1067- COMPUTE WANO-BISSEXTO = WANO-BISSEXTO * 4 */
                        WS_AUXILIARES.WANO_BISSEXTO.Value = WS_AUXILIARES.WANO_BISSEXTO * 4;

                        /*" -1068- IF WANO-BISSEXTO EQUAL WS-W01AATRAB */

                        if (WS_AUXILIARES.WANO_BISSEXTO == WS_AUXILIARES.WS_W01DTTRAB.WS_W01AATRAB)
                        {

                            /*" -1069- MOVE 29 TO WS-W01DDTRAB */
                            _.Move(29, WS_AUXILIARES.WS_W01DTTRAB.WS_W01DDTRAB);

                            /*" -1070- ELSE */
                        }
                        else
                        {


                            /*" -1071- MOVE 28 TO WS-W01DDTRAB */
                            _.Move(28, WS_AUXILIARES.WS_W01DTTRAB.WS_W01DDTRAB);

                            /*" -1072- END-IF */
                        }


                        /*" -1073- END-IF */
                    }


                    /*" -1074- END-IF */
                }


                /*" -1075- MOVE WS-W01DTTRAB TO SDATA-DTTERVIG */
                _.Move(WS_AUXILIARES.WS_W01DTTRAB, SDATA_DTTERVIG);

                /*" -1076- ELSE */
            }
            else
            {


                /*" -1078- MOVE SDATA-TERVIGENCIA TO SDATA-DTTERVIG. */
                _.Move(SDATA_TERVIGENCIA, SDATA_DTTERVIG);
            }


            /*" -1079- IF SDATA-DTTERVIG LESS V1SISTEMA-DTMOVABE */

            if (SDATA_DTTERVIG < V1SISTEMA_DTMOVABE)
            {

                /*" -1080- MOVE SDATA-DTTERVIG TO SDATA-TERVIGENCIA */
                _.Move(SDATA_DTTERVIG, SDATA_TERVIGENCIA);

                /*" -1081- GO TO 155-000-DETERMINA-DTTERVIG. */
                new Task(() => M_155_000_DETERMINA_DTTERVIG_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_155_999_EXIT*/

        [StopWatch]
        /*" M-160-000-UPDATE-V0SEGURAVG-SECTION */
        private void M_160_000_UPDATE_V0SEGURAVG_SECTION()
        {
            /*" -1091- MOVE '160-000-UPDATE-V0SEGURAVG' TO PARAGRAFO */
            _.Move("160-000-UPDATE-V0SEGURAVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1093- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1111- PERFORM M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1 */

            M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1();

            /*" -1114- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1116- DISPLAY 'VG0020B - ATUALIZA OCORR-HISTORICO SEGURAVG ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0020B - ATUALIZA OCORR-HISTORICO SEGURAVG {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1116- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-160-000-UPDATE-V0SEGURAVG-DB-UPDATE-1 */
        public void M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1()
        {
            /*" -1111- EXEC SQL UPDATE SEGUROS.V0SEGURAVG SET OCORR_HISTORICO = :HOCORR-HISTORICO, COD_AGENCIADOR = :MCOD-AGENCIADOR, PERI_PAGAMENTO = :MPERI-PAGAMENTO, PERI_RENOVACAO = :MPERI-RENOVACAO, FAIXA = :MFAIXA, TAXA_VG = :MTAXA-VG, TAXA_AP_MORACID = :MTAXA-AP-MORACID, TAXA_AP_INVPERM = :MTAXA-AP-INVPERM, TAXA_AP_AMDS = :MTAXA-AP-AMDS, TAXA_AP_DH = :MTAXA-AP-DH, TAXA_AP_DIT = :MTAXA-AP-DIT, DATA_ADMISSAO = :SDATA-DTTERVIG WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1 = new M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1()
            {
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                MTAXA_AP_MORACID = MTAXA_AP_MORACID.ToString(),
                MTAXA_AP_INVPERM = MTAXA_AP_INVPERM.ToString(),
                MCOD_AGENCIADOR = MCOD_AGENCIADOR.ToString(),
                MPERI_PAGAMENTO = MPERI_PAGAMENTO.ToString(),
                MPERI_RENOVACAO = MPERI_RENOVACAO.ToString(),
                SDATA_DTTERVIG = SDATA_DTTERVIG.ToString(),
                MTAXA_AP_AMDS = MTAXA_AP_AMDS.ToString(),
                MTAXA_AP_DIT = MTAXA_AP_DIT.ToString(),
                MTAXA_AP_DH = MTAXA_AP_DH.ToString(),
                MTAXA_VG = MTAXA_VG.ToString(),
                MFAIXA = MFAIXA.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
            };

            M_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1.Execute(m_160_000_UPDATE_V0SEGURAVG_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_160_999_EXIT*/

        [StopWatch]
        /*" M-180-000-ENCERRA-V0COBERAPOL-SECTION */
        private void M_180_000_ENCERRA_V0COBERAPOL_SECTION()
        {
            /*" -1128- MOVE '180-000-ENCERRA-V0COBERAPOL' TO PARAGRAFO */
            _.Move("180-000-ENCERRA-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1130- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1140- PERFORM M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1 */

            M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1();

            /*" -1143- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1145- DISPLAY 'VG0020B - NAO EXISTE OCORRENCIA DE HISTORICO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO */

                $"VG0020B - NAO EXISTE OCORRENCIA DE HISTORICO {MNUM_CERTIFICADO} {MTIPO_SEGURADO}"
                .Display();

                /*" -1145- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-180-000-ENCERRA-V0COBERAPOL-DB-UPDATE-1 */
        public void M_180_000_ENCERRA_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -1140- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET DATA_TERVIGENCIA = :SDATA-MOVIMENTO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :MNUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :SNUM-ITEM AND OCORHIST = :SOCORR-HISTORICO END-EXEC. */

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
        /*" M-210-000-MONTA-V0COBERAPOL-SECTION */
        private void M_210_000_MONTA_V0COBERAPOL_SECTION()
        {
            /*" -1159- MOVE '210-000-MONTA-V0COBERAPOL' TO PARAGRAFO. */
            _.Move("210-000-MONTA-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1161- IF WAPOLICE-ATU NOT EQUAL WAPOLICE-ANT */

            if (WS_AUXILIARES.WAPOLICE_ATU != WS_AUXILIARES.WAPOLICE_ANT)
            {

                /*" -1164- MOVE WAPOLICE-ATU TO WAPOLICE-ANT. */
                _.Move(WS_AUXILIARES.WAPOLICE_ATU, WS_AUXILIARES.WAPOLICE_ANT);
            }


            /*" -1166- MOVE MNUM-APOLICE TO VGNUM-APOLICE */
            _.Move(MNUM_APOLICE, VGNUM_APOLICE);

            /*" -1169- MOVE 0 TO VGNRENDOS VGPCT-COBERTURA1 VGPCT-COBERTURA2. */
            _.Move(0, VGNRENDOS, VGPCT_COBERTURA1, VGPCT_COBERTURA2);

            /*" -1169- MOVE SNUM-ITEM TO VGNUM-ITEM. */
            _.Move(SNUM_ITEM, VGNUM_ITEM);

            /*" -0- FLUXCONTROL_PERFORM M_210_010_VERIFICA_PREMIO_VG */

            M_210_010_VERIFICA_PREMIO_VG();

        }

        [StopWatch]
        /*" M-210-010-VERIFICA-PREMIO-VG */
        private void M_210_010_VERIFICA_PREMIO_VG(bool isPerform = false)
        {
            /*" -1180- IF MIMP-MORNATU-ATU NOT EQUAL ZEROS OR (MIMP-MORNATU-ATU EQUAL ZEROS AND V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 AND MPRM-VG-ATU GREATER ZEROS) */

            if (MIMP_MORNATU_ATU != 00 || (MIMP_MORNATU_ATU == 00 && V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2 && MPRM_VG_ATU > 00))
            {

                /*" -1181- IF V0APOL-RAMO EQUAL V1PAR-RAMO-PST */

                if (V0APOL_RAMO == V1PAR_RAMO_PST)
                {

                    /*" -1182- MOVE V1PAR-RAMO-PST TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_PST, VGRAMOFR);

                    /*" -1183- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1185- END-IF */
                }


                /*" -1186- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG */

                if (V0APOL_RAMO == V1PAR_RAMO_VG)
                {

                    /*" -1187- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -1188- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1190- END-IF */
                }


                /*" -1191- IF V0APOL-RAMO EQUAL 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -1192- MOVE V1PAR-RAMO-VG TO VGRAMOFR */
                    _.Move(V1PAR_RAMO_VG, VGRAMOFR);

                    /*" -1193- MOVE 11 TO VGCOD-COBERTURA */
                    _.Move(11, VGCOD_COBERTURA);

                    /*" -1196- END-IF */
                }


                /*" -1198- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1202- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORNATU-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORNATU_ATU / DVLCRUZAD_IMP;

                /*" -1206- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-VG-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_VG_ATU / DVLCRUZAD_PRM;

                /*" -1209- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1213- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1216- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WS_AUXILIARES.WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1217- IF MIMP-MORACID-ATU EQUAL ZEROS */

                if (MIMP_MORACID_ATU == 00)
                {

                    /*" -1218- MOVE WPRMTOT TO MPRM-VG-ATU */
                    _.Move(WS_AUXILIARES.WPRMTOT, MPRM_VG_ATU);

                    /*" -1219- MOVE ZEROS TO MPRM-AP-ATU */
                    _.Move(0, MPRM_AP_ATU);

                    /*" -1221- END-IF */
                }


                /*" -1222- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1225- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1233- IF (MNUM-APOLICE = 93605000853 AND MCOD-USUARIO = 'VG9529B' ) OR (MNUM-APOLICE = 107700000005 AND MCOD-USUARIO = 'VG9529B' ) OR (MNUM-APOLICE = 109300000635 AND MCOD-SUBGRUPO = 1) */

                if ((MNUM_APOLICE == 93605000853 && MCOD_USUARIO == "VG9529B") || (MNUM_APOLICE == 107700000005 && MCOD_USUARIO == "VG9529B") || (MNUM_APOLICE == 109300000635 && MCOD_SUBGRUPO == 1))
                {

                    /*" -1234- MOVE WS-DT-MAIS30D TO VGDATA-TERVIGENCIA */
                    _.Move(WS_DT_MAIS30D, VGDATA_TERVIGENCIA);

                    /*" -1235- ELSE */
                }
                else
                {


                    /*" -1236- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -1238- END-IF */
                }


                /*" -1240- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1244- COMPUTE VGPCT-COBERTURA1 ROUNDED = MPRM-VG-ATU * 100 / WPRMTOT */
                VGPCT_COBERTURA1.Value = MPRM_VG_ATU * 100 / WS_AUXILIARES.WPRMTOT;

                /*" -1246- MOVE VGPCT-COBERTURA1 TO VGPCT-COBERTURA */
                _.Move(VGPCT_COBERTURA1, VGPCT_COBERTURA);

                /*" -1249- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1249- PERFORM 210-020-VERIFICA-PREMIO-AP. */

            M_210_020_VERIFICA_PREMIO_AP(true);

        }

        [StopWatch]
        /*" M-210-020-VERIFICA-PREMIO-AP */
        private void M_210_020_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -1254- IF MIMP-MORACID-ATU NOT EQUAL ZEROS */

            if (MIMP_MORACID_ATU != 00)
            {

                /*" -1258- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1259- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1261- MOVE 01 TO VGCOD-COBERTURA */
                _.Move(01, VGCOD_COBERTURA);

                /*" -1265- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-MORACID-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_MORACID_ATU / DVLCRUZAD_IMP;

                /*" -1269- COMPUTE VGPRM-TARIFARIO-IX ROUNDED = MPRM-AP-ATU / DVLCRUZAD-PRM */
                VGPRM_TARIFARIO_IX.Value = MPRM_AP_ATU / DVLCRUZAD_PRM;

                /*" -1272- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1275- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1278- COMPUTE WPRMTOT = MPRM-VG-ATU + MPRM-AP-ATU */
                WS_AUXILIARES.WPRMTOT.Value = MPRM_VG_ATU + MPRM_AP_ATU;

                /*" -1279- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1282- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1284- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -1285- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1286- ELSE */
                }
                else
                {


                    /*" -1287- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -1289- END-IF */
                }


                /*" -1291- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1295- COMPUTE VGPCT-COBERTURA2 ROUNDED = MPRM-AP-ATU * 100 / WPRMTOT */
                VGPCT_COBERTURA2.Value = MPRM_AP_ATU * 100 / WS_AUXILIARES.WPRMTOT;

                /*" -1296- IF VGPCT-COBERTURA2 EQUAL 0 */

                if (VGPCT_COBERTURA2 == 0)
                {

                    /*" -1298- IF V0APOL-RAMO EQUAL V1PAR-RAMO-VG AND V0APOL-MODALIDA EQUAL 2 */

                    if (V0APOL_RAMO == V1PAR_RAMO_VG && V0APOL_MODALIDA == 2)
                    {

                        /*" -1300- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                        VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                        /*" -1302- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -1303- PERFORM 300-000-INSERE-V0COBERAPOL */

                        M_300_000_INSERE_V0COBERAPOL_SECTION();

                        /*" -1304- ELSE */
                    }
                    else
                    {


                        /*" -1306- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                        _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                        /*" -1307- ELSE */
                    }

                }
                else
                {


                    /*" -1309- COMPUTE VGPCT-COBERTURA2 = 100 - VGPCT-COBERTURA1 */
                    VGPCT_COBERTURA2.Value = 100 - VGPCT_COBERTURA1;

                    /*" -1311- MOVE VGPCT-COBERTURA2 TO VGPCT-COBERTURA */
                    _.Move(VGPCT_COBERTURA2, VGPCT_COBERTURA);

                    /*" -1313- PERFORM 300-000-INSERE-V0COBERAPOL. */

                    M_300_000_INSERE_V0COBERAPOL_SECTION();
                }

            }


            /*" -1313- PERFORM 210-030-VERIFICA-INVPERM. */

            M_210_030_VERIFICA_INVPERM(true);

        }

        [StopWatch]
        /*" M-210-030-VERIFICA-INVPERM */
        private void M_210_030_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -1318- MOVE ' 210-030-VERIFICA-INVPERM' TO PARAGRAFO. */
            _.Move(" 210-030-VERIFICA-INVPERM", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1320- IF MIMP-INVPERM-ATU NOT EQUAL ZEROS */

            if (MIMP_INVPERM_ATU != 00)
            {

                /*" -1324- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1325- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1327- MOVE 02 TO VGCOD-COBERTURA */
                _.Move(02, VGCOD_COBERTURA);

                /*" -1331- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-INVPERM-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_INVPERM_ATU / DVLCRUZAD_IMP;

                /*" -1333- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1336- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1340- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1341- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1344- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1346- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -1347- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1348- ELSE */
                }
                else
                {


                    /*" -1349- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -1351- END-IF */
                }


                /*" -1353- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1354- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1356- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1356- PERFORM 210-040-VERIFICA-AMDS. */

            M_210_040_VERIFICA_AMDS(true);

        }

        [StopWatch]
        /*" M-210-040-VERIFICA-AMDS */
        private void M_210_040_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -1361- MOVE ' 210-040-VERIFICA-AMDS' TO PARAGRAFO. */
            _.Move(" 210-040-VERIFICA-AMDS", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1363- IF MIMP-AMDS-ATU NOT EQUAL ZEROS */

            if (MIMP_AMDS_ATU != 00)
            {

                /*" -1367- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1368- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1370- MOVE 03 TO VGCOD-COBERTURA */
                _.Move(03, VGCOD_COBERTURA);

                /*" -1374- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-AMDS-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_AMDS_ATU / DVLCRUZAD_IMP;

                /*" -1376- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1379- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1383- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1384- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1387- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1389- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -1390- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1391- ELSE */
                }
                else
                {


                    /*" -1392- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -1394- END-IF */
                }


                /*" -1396- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1397- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1399- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1399- PERFORM 210-050-VERIFICA-DH. */

            M_210_050_VERIFICA_DH(true);

        }

        [StopWatch]
        /*" M-210-050-VERIFICA-DH */
        private void M_210_050_VERIFICA_DH(bool isPerform = false)
        {
            /*" -1404- MOVE '210-050-VERIFICA-DH' TO PARAGRAFO. */
            _.Move("210-050-VERIFICA-DH", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1406- IF MIMP-DH-ATU NOT EQUAL ZEROS */

            if (MIMP_DH_ATU != 00)
            {

                /*" -1410- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1411- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1413- MOVE 04 TO VGCOD-COBERTURA */
                _.Move(04, VGCOD_COBERTURA);

                /*" -1417- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DH-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DH_ATU / DVLCRUZAD_IMP;

                /*" -1419- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1422- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1426- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1427- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1430- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1432- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -1433- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1434- ELSE */
                }
                else
                {


                    /*" -1435- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -1437- END-IF */
                }


                /*" -1439- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1440- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1442- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


            /*" -1442- PERFORM 210-060-VERIFICA-DIT. */

            M_210_060_VERIFICA_DIT(true);

        }

        [StopWatch]
        /*" M-210-060-VERIFICA-DIT */
        private void M_210_060_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -1447- MOVE '210-060-VERIFICA-DIT' TO PARAGRAFO. */
            _.Move("210-060-VERIFICA-DIT", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1449- IF MIMP-DIT-ATU NOT EQUAL ZEROS */

            if (MIMP_DIT_ATU != 00)
            {

                /*" -1453- MOVE V1PAR-RAMO-AP TO VGRAMOFR */
                _.Move(V1PAR_RAMO_AP, VGRAMOFR);

                /*" -1454- MOVE V0APOL-MODALIDA TO VGMODALIFR */
                _.Move(V0APOL_MODALIDA, VGMODALIFR);

                /*" -1456- MOVE 05 TO VGCOD-COBERTURA */
                _.Move(05, VGCOD_COBERTURA);

                /*" -1460- COMPUTE VGIMP-SEGURADA-IX ROUNDED = MIMP-DIT-ATU / DVLCRUZAD-IMP */
                VGIMP_SEGURADA_IX.Value = MIMP_DIT_ATU / DVLCRUZAD_IMP;

                /*" -1462- MOVE 0 TO VGPRM-TARIFARIO-IX */
                _.Move(0, VGPRM_TARIFARIO_IX);

                /*" -1465- MOVE VGIMP-SEGURADA-IX TO VGIMP-SEGURADA-VAR */
                _.Move(VGIMP_SEGURADA_IX, VGIMP_SEGURADA_VAR);

                /*" -1469- MOVE VGPRM-TARIFARIO-IX TO PRM-TARIFARIO-VAR */
                _.Move(VGPRM_TARIFARIO_IX, PRM_TARIFARIO_VAR);

                /*" -1470- MOVE 1 TO VGFATOR-MULTIPLICA */
                _.Move(1, VGFATOR_MULTIPLICA);

                /*" -1473- MOVE MDATA-MOVIMENTO TO VGDATA-INIVIGENCIA */
                _.Move(MDATA_MOVIMENTO, VGDATA_INIVIGENCIA);

                /*" -1475- IF MNUM-APOLICE = 93605000853 OR MNUM-APOLICE = 107700000005 */

                if (MNUM_APOLICE == 93605000853 || MNUM_APOLICE == 107700000005)
                {

                    /*" -1476- MOVE MDATA-AVERBACAO TO VGDATA-TERVIGENCIA */
                    _.Move(MDATA_AVERBACAO, VGDATA_TERVIGENCIA);

                    /*" -1477- ELSE */
                }
                else
                {


                    /*" -1478- MOVE '9999-12-31' TO VGDATA-TERVIGENCIA */
                    _.Move("9999-12-31", VGDATA_TERVIGENCIA);

                    /*" -1480- END-IF */
                }


                /*" -1482- MOVE -1 TO WCOD-EMPRESA */
                _.Move(-1, WCOD_EMPRESA);

                /*" -1483- MOVE 0 TO VGPCT-COBERTURA */
                _.Move(0, VGPCT_COBERTURA);

                /*" -1483- PERFORM 300-000-INSERE-V0COBERAPOL. */

                M_300_000_INSERE_V0COBERAPOL_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_210_999_EXIT*/

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-SECTION */
        private void M_300_000_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -1572- MOVE '300-000-INSERE-V0COBERAPOL' TO PARAGRAFO */
            _.Move("300-000-INSERE-V0COBERAPOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1589- MOVE '300' TO WNR-EXEC-SQL. */
            _.Move("300", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1591- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1612- PERFORM M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1 */

            M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -1615- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1618- DISPLAY 'VG0020B - PROBLEMAS NA INCLUSAO V0COBERAPOL  ' VGNUM-APOLICE ' ' VGNRENDOS ' ' VGNUM-ITEM */

                $"VG0020B - PROBLEMAS NA INCLUSAO V0COBERAPOL  {VGNUM_APOLICE} {VGNRENDOS} {VGNUM_ITEM}"
                .Display();

                /*" -1618- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-300-000-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -1612- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:VGNUM-APOLICE, :VGNRENDOS, :VGNUM-ITEM, :HOCORR-HISTORICO, :VGRAMOFR, :VGMODALIFR, :VGCOD-COBERTURA, :VGIMP-SEGURADA-IX, :VGPRM-TARIFARIO-IX, :VGIMP-SEGURADA-VAR, :PRM-TARIFARIO-VAR, :VGPCT-COBERTURA, :VGFATOR-MULTIPLICA, :VGDATA-INIVIGENCIA, :VGDATA-TERVIGENCIA, :MCOD-EMPRESA:WCOD-EMPRESA, CURRENT TIMESTAMP, :VGCOD-SITUACAO:VGCOD-SITUACAO-I) END-EXEC. */

            var m_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new M_300_000_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                VGNUM_APOLICE = VGNUM_APOLICE.ToString(),
                VGNRENDOS = VGNRENDOS.ToString(),
                VGNUM_ITEM = VGNUM_ITEM.ToString(),
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
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
        /*" M-310-000-SELECT-V1HISTSEGVG-SECTION */
        private void M_310_000_SELECT_V1HISTSEGVG_SECTION()
        {
            /*" -1629- MOVE '310-000-SELECT-V1HISTSEGVG' TO PARAGRAFO */
            _.Move("310-000-SELECT-V1HISTSEGVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1631- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1640- PERFORM M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1 */

            M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1();

            /*" -1643- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1644- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1645- MOVE 'N' TO WTEM-OCORHIST */
                    _.Move("N", WS_AUXILIARES.WTEM_OCORHIST);

                    /*" -1646- ELSE */
                }
                else
                {


                    /*" -1648- DISPLAY 'VG0020B - NAO EXISTE OCORRENCIA DE HISTORICO ' MNUM-CERTIFICADO ' ' MTIPO-SEGURADO ' ' SNUM-ITEM */

                    $"VG0020B - NAO EXISTE OCORRENCIA DE HISTORICO {MNUM_CERTIFICADO} {MTIPO_SEGURADO} {SNUM_ITEM}"
                    .Display();

                    /*" -1649- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1650- ELSE */
                }

            }
            else
            {


                /*" -1650- MOVE 'S' TO WTEM-OCORHIST. */
                _.Move("S", WS_AUXILIARES.WTEM_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-310-000-SELECT-V1HISTSEGVG-DB-SELECT-1 */
        public void M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1()
        {
            /*" -1640- EXEC SQL SELECT OCORR_HISTORICO INTO :HHOCORR-HISTORICO FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = 109300000635 AND NUM_ITEM = :SNUM-ITEM AND OCORR_HISTORICO = :MFAIXA WITH UR END-EXEC. */

            var m_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1 = new M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1()
            {
                SNUM_ITEM = SNUM_ITEM.ToString(),
                MFAIXA = MFAIXA.ToString(),
            };

            var executed_1 = M_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1.Execute(m_310_000_SELECT_V1HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HHOCORR_HISTORICO, HHOCORR_HISTORICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_310_999_EXIT*/

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-SECTION */
        private void M_330_000_INSERE_V0HISTSEGVG_SECTION()
        {
            /*" -1662- MOVE '330-000-INCLUI-V0HISTSEGVG' TO PARAGRAFO */
            _.Move("330-000-INCLUI-V0HISTSEGVG", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1664- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1665- ACCEPT WHORA-OPERACAO-1 FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_AUXILIARES.WHORA_OPERACAO_1);

            /*" -1666- MOVE WHORA-OPERACAO-2 TO WHORA-OPERACAO-R */
            _.Move(WS_AUXILIARES.WHORA_PER_X.WHORA_OPERACAO_2, WS_AUXILIARES.WHORA_OPERACAO_R);

            /*" -1667- MOVE WHORA-HORA-W TO WHORA-HORA */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_HORA_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_HORA);

            /*" -1668- MOVE WHORA-MINU-W TO WHORA-MINU */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_MINU_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_MINU);

            /*" -1669- MOVE WHORA-SEGU-W TO WHORA-SEGU */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO.WHORA_SEGU_W, WS_AUXILIARES.WHORA_OPERACAO_WORK.WHORA_SEGU);

            /*" -1670- MOVE WHORA-OPERACAO-WORK-R TO HHORA-OPERACAO */
            _.Move(WS_AUXILIARES.WHORA_OPERACAO_WORK_R, HHORA_OPERACAO);

            /*" -1673- MOVE 0 TO HCOD-SUBGRUP-TRANS. */
            _.Move(0, HCOD_SUBGRUP_TRANS);

            /*" -1675- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1692- PERFORM M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1 */

            M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1();

            /*" -1695- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1698- DISPLAY 'VG0020B - PROBLEMAS NA INCLUSAO V0HISTSEGVG ' MNUM-APOLICE ' ' MCOD-SUBGRUPO ' ' SNUM-ITEM */

                $"VG0020B - PROBLEMAS NA INCLUSAO V0HISTSEGVG {MNUM_APOLICE} {MCOD_SUBGRUPO} {SNUM_ITEM}"
                .Display();

                /*" -1700- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1700- ADD 1 TO AC-GRAVA. */
            WS_AUXILIARES.AC_GRAVA.Value = WS_AUXILIARES.AC_GRAVA + 1;

        }

        [StopWatch]
        /*" M-330-000-INSERE-V0HISTSEGVG-DB-INSERT-1 */
        public void M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1()
        {
            /*" -1692- EXEC SQL INSERT INTO SEGUROS.V0HISTSEGVG VALUES (:MNUM-APOLICE, :MCOD-SUBGRUPO, :SNUM-ITEM, :MCOD-OPERACAO, :V1SISTEMA-DTMOVABE, :HHORA-OPERACAO, :MDATA-MOVIMENTO, :HOCORR-HISTORICO, :HCOD-SUBGRUP-TRANS, :MDATA-REFERENCIA, :MCOD-USUARIO, :MCOD-EMPRESA:WCOD-EMPRESA, :V1EN-COD-MOEDA-IMP:WCOD-MOEDA, :V1EN-COD-MOEDA-PRM:WCOD-MOEDA) END-EXEC. */

            var m_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1 = new M_330_000_INSERE_V0HISTSEGVG_DB_INSERT_1_Insert1()
            {
                MNUM_APOLICE = MNUM_APOLICE.ToString(),
                MCOD_SUBGRUPO = MCOD_SUBGRUPO.ToString(),
                SNUM_ITEM = SNUM_ITEM.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                HHORA_OPERACAO = HHORA_OPERACAO.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                HOCORR_HISTORICO = HOCORR_HISTORICO.ToString(),
                HCOD_SUBGRUP_TRANS = HCOD_SUBGRUP_TRANS.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
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
        /*" M-390-000-UPDATE-V0MOVIMENTO-SECTION */
        private void M_390_000_UPDATE_V0MOVIMENTO_SECTION()
        {
            /*" -1712- MOVE '390-000-UPDATE-V0MOVIMENTO' TO PARAGRAFO */
            _.Move("390-000-UPDATE-V0MOVIMENTO", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1714- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1724- PERFORM M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1 */

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1();

            /*" -1727- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1729- DISPLAY 'VG0020B - NAO EXISTE MOVIMENTO PARA ' MCOD-FONTE ' ' MNUM-PROPOSTA */

                $"VG0020B - NAO EXISTE MOVIMENTO PARA {MCOD_FONTE} {MNUM_PROPOSTA}"
                .Display();

                /*" -1729- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-390-000-UPDATE-V0MOVIMENTO-DB-UPDATE-1 */
        public void M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1()
        {
            /*" -1724- EXEC SQL UPDATE SEGUROS.V0MOVIMENTO SET DATA_INCLUSAO = :V1SISTEMA-DTMOVABE, DATA_REFERENCIA = :MDATA-REFERENCIA, PERI_RENOVACAO = :MPERI-RENOVACAO WHERE COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO END-EXEC. */

            var m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 = new M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1()
            {
                V1SISTEMA_DTMOVABE = V1SISTEMA_DTMOVABE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                MPERI_RENOVACAO = MPERI_RENOVACAO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1.Execute(m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_390_999_EXIT*/

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-SECTION */
        private void M_400_000_ATUALIZA_COBERPROPVA_SECTION()
        {
            /*" -1741- MOVE '400-000-ATUALIZA-COBERPROPVA ' TO PARAGRAFO */
            _.Move("400-000-ATUALIZA-COBERPROPVA ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -1743- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1749- PERFORM M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1 */

            M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1();

            /*" -1752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1753- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1754- GO TO 400-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/ //GOTO
                    return;

                    /*" -1755- ELSE */
                }
                else
                {


                    /*" -1757- DISPLAY 'VG0020B - ERRO SQL INESPERADO       ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' MNUM-CERTIFICADO */

                    $"VG0020B - ERRO SQL INESPERADO       {MCOD_FONTE} {MNUM_PROPOSTA} {MNUM_CERTIFICADO}"
                    .Display();

                    /*" -1759- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1761- MOVE '401' TO WNR-EXEC-SQL. */
            _.Move("401", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1822- PERFORM M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2 */

            M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2();

            /*" -1825- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1827- DISPLAY 'VG0020B - ERRO SQL INESPERADO - COBP ' MCOD-FONTE ' ' MNUM-PROPOSTA ' ' MNUM-CERTIFICADO */

                $"VG0020B - ERRO SQL INESPERADO - COBP {MCOD_FONTE} {MNUM_PROPOSTA} {MNUM_CERTIFICADO}"
                .Display();

                /*" -1829- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1830- IF V0COBP-DTINIVIG EQUAL MDATA-MOVIMENTO */

            if (V0COBP_DTINIVIG == MDATA_MOVIMENTO)
            {

                /*" -1831- DISPLAY 'VG0020B - ATUALIZACAO COBERPROPVA JA EFETUADA ' */
                _.Display($"VG0020B - ATUALIZACAO COBERPROPVA JA EFETUADA ");

                /*" -1832- DISPLAY MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"{MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -1833- DISPLAY 'DTMOVTO       = ' MDATA-MOVIMENTO */
                _.Display($"DTMOVTO       = {MDATA_MOVIMENTO}");

                /*" -1835- GO TO 400-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/ //GOTO
                return;
            }


            /*" -1837- MOVE '402' TO WNR-EXEC-SQL. */
            _.Move("402", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1844- PERFORM M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1 */

            M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1();

            /*" -1847- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1849- DISPLAY 'VG0020B - ERRO UPDATE V0COBP - 1    ' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO UPDATE V0COBP - 1    {MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -1851- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1853- MOVE '403' TO WNR-EXEC-SQL. */
            _.Move("403", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1860- PERFORM M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2 */

            M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2();

            /*" -1863- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1865- DISPLAY 'VG0020B - ERRO UPDATE V0COBP - 2    ' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO UPDATE V0COBP - 2    {MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -1867- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1869- COMPUTE V0PROP-OCORHIST = V0PROP-OCORHIST + 1. */
            V0PROP_OCORHIST.Value = V0PROP_OCORHIST + 1;

            /*" -1872- COMPUTE V0COBP-TAXA = V0COBP-IMPMORNATU / V0COBP-IMPSEGUR. */
            V0COBP_TAXA.Value = V0COBP_IMPMORNATU / V0COBP_IMPSEGUR;

            /*" -1875- COMPUTE V0COBP-IMPMORNATU = V0COBP-TAXA * MIMP-MORNATU-ATU. */
            V0COBP_IMPMORNATU.Value = V0COBP_TAXA * MIMP_MORNATU_ATU;

            /*" -1878- COMPUTE V0COBP-TAXA = V0COBP-IMPMORACID / V0COBP-IMPSEGUR. */
            V0COBP_TAXA.Value = V0COBP_IMPMORACID / V0COBP_IMPSEGUR;

            /*" -1881- COMPUTE V0COBP-IMPMORACID = V0COBP-TAXA * MIMP-MORACID-ATU. */
            V0COBP_IMPMORACID.Value = V0COBP_TAXA * MIMP_MORACID_ATU;

            /*" -1884- COMPUTE V0COBP-TAXA = V0COBP-IMPINVPERM / V0COBP-IMPSEGUR. */
            V0COBP_TAXA.Value = V0COBP_IMPINVPERM / V0COBP_IMPSEGUR;

            /*" -1887- COMPUTE V0COBP-IMPINVPERM = V0COBP-TAXA * MIMP-INVPERM-ATU. */
            V0COBP_IMPINVPERM.Value = V0COBP_TAXA * MIMP_INVPERM_ATU;

            /*" -1888- IF V0COBP-IMPMORNATU NOT EQUAL ZEROS */

            if (V0COBP_IMPMORNATU != 00)
            {

                /*" -1890- MOVE V0COBP-IMPMORNATU TO V0COBP-IMPSEGUR V0COBP-IMPSEGIND */
                _.Move(V0COBP_IMPMORNATU, V0COBP_IMPSEGUR, V0COBP_IMPSEGIND);

                /*" -1891- ELSE */
            }
            else
            {


                /*" -1894- MOVE V0COBP-IMPMORACID TO V0COBP-IMPSEGUR V0COBP-IMPSEGIND. */
                _.Move(V0COBP_IMPMORACID, V0COBP_IMPSEGUR, V0COBP_IMPSEGIND);
            }


            /*" -1898- COMPUTE V0COBP-VLPREMIO = MPRM-VG-ATU + MPRM-AP-ATU + (V0COBP-QTTITCAP * V0COBP-VLCUSTCAP). */
            V0COBP_VLPREMIO.Value = MPRM_VG_ATU + MPRM_AP_ATU + (V0COBP_QTTITCAP * V0COBP_VLCUSTCAP);

            /*" -1899- MOVE MPRM-VG-ATU TO V0COBP-PRMVG. */
            _.Move(MPRM_VG_ATU, V0COBP_PRMVG);

            /*" -1901- MOVE MPRM-AP-ATU TO V0COBP-PRMAP. */
            _.Move(MPRM_AP_ATU, V0COBP_PRMAP);

            /*" -1903- MOVE SPACES TO V0COBP-OPCAO-COBER. */
            _.Move("", V0COBP_OPCAO_COBER);

            /*" -1905- MOVE '404' TO WNR-EXEC-SQL. */
            _.Move("404", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1966- PERFORM M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1 */

            M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1();

            /*" -1969- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1971- DISPLAY 'VG0020B - ERRO INSERT V0COBP        ' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO INSERT V0COBP        {MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -1973- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1975- MOVE '405' TO WNR-EXEC-SQL. */
            _.Move("405", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -1984- PERFORM M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3 */

            M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3();

            /*" -1987- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1989- DISPLAY 'VG0020B - ERRO UPDATE V0PROPOSTAVA  ' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO UPDATE V0PROPOSTAVA  {MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -1989- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-DB-SELECT-1 */
        public void M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1()
        {
            /*" -1749- EXEC SQL SELECT OCORHIST INTO :V0PROP-OCORHIST FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1_Query1 = new M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1_Query1.Execute(m_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_400_999_EXIT*/

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-DB-UPDATE-1 */
        public void M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1()
        {
            /*" -1844- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = :MDATA-MOVIMENTO WHERE NRCERTIF = :MNUM-CERTIFICADO AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1 = new M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1()
            {
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1.Execute(m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-DB-SELECT-2 */
        public void M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2()
        {
            /*" -1822- EXEC SQL SELECT DTINIVIG , DTTERVIG , IMPSEGUR , QUANT_VIDAS, IMPSEGIND , CODOPER , OPCAO_COBER, IMPMORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTTITCAP , VLTITCAP , VLCUSTCAP , IMPSEGCDC , VLCUSTCDG , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTDIT INTO :V0COBP-DTINIVIG , :V0COBP-DTTERVIG , :V0COBP-IMPSEGUR , :V0COBP-QUANT-VIDAS, :V0COBP-IMPSEGIND , :V0COBP-CODOPER , :V0COBP-OPCAO-COBER, :V0COBP-IMPMORNATU , :V0COBP-IMPMORACID , :V0COBP-IMPINVPERM , :V0COBP-IMPAMDS , :V0COBP-IMPDH , :V0COBP-IMPDIT , :V0COBP-VLPREMIO , :V0COBP-PRMVG , :V0COBP-PRMAP , :V0COBP-QTTITCAP , :V0COBP-VLTITCAP , :V0COBP-VLCUSTCAP , :V0COBP-IMPSEGCDC , :V0COBP-VLCUSTCDG , :V0COBP-IMPSEGAUXF :V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTAUXF :V0COBP-VLCUSTAUXF-I, :V0COBP-PRMDIT :V0COBP-PRMDIT-I, :V0COBP-QTDIT :V0COBP-QTDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :MNUM-CERTIFICADO AND OCORHIST = :V0PROP-OCORHIST WITH UR END-EXEC. */

            var m_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1 = new M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            var executed_1 = M_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1.Execute(m_400_000_ATUALIZA_COBERPROPVA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_DTINIVIG, V0COBP_DTINIVIG);
                _.Move(executed_1.V0COBP_DTTERVIG, V0COBP_DTTERVIG);
                _.Move(executed_1.V0COBP_IMPSEGUR, V0COBP_IMPSEGUR);
                _.Move(executed_1.V0COBP_QUANT_VIDAS, V0COBP_QUANT_VIDAS);
                _.Move(executed_1.V0COBP_IMPSEGIND, V0COBP_IMPSEGIND);
                _.Move(executed_1.V0COBP_CODOPER, V0COBP_CODOPER);
                _.Move(executed_1.V0COBP_OPCAO_COBER, V0COBP_OPCAO_COBER);
                _.Move(executed_1.V0COBP_IMPMORNATU, V0COBP_IMPMORNATU);
                _.Move(executed_1.V0COBP_IMPMORACID, V0COBP_IMPMORACID);
                _.Move(executed_1.V0COBP_IMPINVPERM, V0COBP_IMPINVPERM);
                _.Move(executed_1.V0COBP_IMPAMDS, V0COBP_IMPAMDS);
                _.Move(executed_1.V0COBP_IMPDH, V0COBP_IMPDH);
                _.Move(executed_1.V0COBP_IMPDIT, V0COBP_IMPDIT);
                _.Move(executed_1.V0COBP_VLPREMIO, V0COBP_VLPREMIO);
                _.Move(executed_1.V0COBP_PRMVG, V0COBP_PRMVG);
                _.Move(executed_1.V0COBP_PRMAP, V0COBP_PRMAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
                _.Move(executed_1.V0COBP_VLTITCAP, V0COBP_VLTITCAP);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_IMPSEGCDC, V0COBP_IMPSEGCDC);
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_PRMDIT, V0COBP_PRMDIT);
                _.Move(executed_1.V0COBP_PRMDIT_I, V0COBP_PRMDIT_I);
                _.Move(executed_1.V0COBP_QTDIT, V0COBP_QTDIT);
                _.Move(executed_1.V0COBP_QTDIT_I, V0COBP_QTDIT_I);
            }


        }

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-DB-INSERT-1 */
        public void M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1()
        {
            /*" -1966- EXEC SQL INSERT INTO SEGUROS.V0COBERPROPVA (NRCERTIF , OCORHIST , DTINIVIG , DTTERVIG , IMPSEGUR , QUANT_VIDAS, IMPSEGIND , CODOPER , OPCAO_COBER, IMPMORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTTITCAP , VLTITCAP , VLCUSTCAP , IMPSEGCDC , VLCUSTCDG , CODUSU , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTDIT ) VALUES (:MNUM-CERTIFICADO, :V0PROP-OCORHIST, :MDATA-MOVIMENTO, '9999-12-31' , :V0COBP-IMPSEGUR, :V0COBP-QUANT-VIDAS, :V0COBP-IMPSEGIND, :MCOD-OPERACAO, :V0COBP-OPCAO-COBER, :V0COBP-IMPMORNATU , :V0COBP-IMPMORACID , :V0COBP-IMPINVPERM , :V0COBP-IMPAMDS , :V0COBP-IMPDH , :V0COBP-IMPDIT , :V0COBP-VLPREMIO , :V0COBP-PRMVG , :V0COBP-PRMAP , :V0COBP-QTTITCAP , :V0COBP-VLTITCAP , :V0COBP-VLCUSTCAP , :V0COBP-IMPSEGCDC , :V0COBP-VLCUSTCDG , :MCOD-USUARIO , CURRENT TIMESTAMP , :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-PRMDIT:V0COBP-PRMDIT-I, :V0COBP-QTDIT:V0COBP-QTDIT-I) END-EXEC. */

            var m_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1 = new M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                V0COBP_IMPSEGUR = V0COBP_IMPSEGUR.ToString(),
                V0COBP_QUANT_VIDAS = V0COBP_QUANT_VIDAS.ToString(),
                V0COBP_IMPSEGIND = V0COBP_IMPSEGIND.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V0COBP_OPCAO_COBER = V0COBP_OPCAO_COBER.ToString(),
                V0COBP_IMPMORNATU = V0COBP_IMPMORNATU.ToString(),
                V0COBP_IMPMORACID = V0COBP_IMPMORACID.ToString(),
                V0COBP_IMPINVPERM = V0COBP_IMPINVPERM.ToString(),
                V0COBP_IMPAMDS = V0COBP_IMPAMDS.ToString(),
                V0COBP_IMPDH = V0COBP_IMPDH.ToString(),
                V0COBP_IMPDIT = V0COBP_IMPDIT.ToString(),
                V0COBP_VLPREMIO = V0COBP_VLPREMIO.ToString(),
                V0COBP_PRMVG = V0COBP_PRMVG.ToString(),
                V0COBP_PRMAP = V0COBP_PRMAP.ToString(),
                V0COBP_QTTITCAP = V0COBP_QTTITCAP.ToString(),
                V0COBP_VLTITCAP = V0COBP_VLTITCAP.ToString(),
                V0COBP_VLCUSTCAP = V0COBP_VLCUSTCAP.ToString(),
                V0COBP_IMPSEGCDC = V0COBP_IMPSEGCDC.ToString(),
                V0COBP_VLCUSTCDG = V0COBP_VLCUSTCDG.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                V0COBP_IMPSEGAUXF = V0COBP_IMPSEGAUXF.ToString(),
                V0COBP_IMPSEGAUXF_I = V0COBP_IMPSEGAUXF_I.ToString(),
                V0COBP_VLCUSTAUXF = V0COBP_VLCUSTAUXF.ToString(),
                V0COBP_VLCUSTAUXF_I = V0COBP_VLCUSTAUXF_I.ToString(),
                V0COBP_PRMDIT = V0COBP_PRMDIT.ToString(),
                V0COBP_PRMDIT_I = V0COBP_PRMDIT_I.ToString(),
                V0COBP_QTDIT = V0COBP_QTDIT.ToString(),
                V0COBP_QTDIT_I = V0COBP_QTDIT_I.ToString(),
            };

            M_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1.Execute(m_400_000_ATUALIZA_COBERPROPVA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-DB-UPDATE-2 */
        public void M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2()
        {
            /*" -1860- EXEC SQL UPDATE SEGUROS.V0COBERPROPVA SET DTTERVIG = DTTERVIG - 1 DAY WHERE NRCERTIF = :MNUM-CERTIFICADO AND OCORHIST = :V0PROP-OCORHIST END-EXEC. */

            var m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1 = new M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
            };

            M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1.Execute(m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-410-000-GERA-CARENCIAS-SECTION */
        private void M_410_000_GERA_CARENCIAS_SECTION()
        {
            /*" -1998- MOVE '410-000-GERA-CARENCIAS       ' TO PARAGRAFO */
            _.Move("410-000-GERA-CARENCIAS       ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2000- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2006- PERFORM M_410_000_GERA_CARENCIAS_DB_SELECT_1 */

            M_410_000_GERA_CARENCIAS_DB_SELECT_1();

            /*" -2009- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2010- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2012- DISPLAY 'VG0020B - NOT FOUND IN V0PROPOSTAVA  ' MNUM-CERTIFICADO */
                    _.Display($"VG0020B - NOT FOUND IN V0PROPOSTAVA  {MNUM_CERTIFICADO}");

                    /*" -2013- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2014- ELSE */
                }
                else
                {


                    /*" -2016- DISPLAY 'VG0020B - ERRO SELECT V0PROPOSTAVA  ' MNUM-CERTIFICADO */
                    _.Display($"VG0020B - ERRO SELECT V0PROPOSTAVA  {MNUM_CERTIFICADO}");

                    /*" -2018- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2026- PERFORM M_410_000_GERA_CARENCIAS_DB_SELECT_2 */

            M_410_000_GERA_CARENCIAS_DB_SELECT_2();

            /*" -2029- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2030- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2032- DISPLAY 'VG0020B - NOT FOUND IN V0MLDTRDAZ    ' MNUM-CERTIFICADO */
                    _.Display($"VG0020B - NOT FOUND IN V0MLDTRDAZ    {MNUM_CERTIFICADO}");

                    /*" -2033- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2034- ELSE */
                }
                else
                {


                    /*" -2036- DISPLAY 'VG0020B - ERRO SELECT V0MLDTRDAZ    ' MNUM-CERTIFICADO */
                    _.Display($"VG0020B - ERRO SELECT V0MLDTRDAZ    {MNUM_CERTIFICADO}");

                    /*" -2038- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2039- IF V0MLD-IDADE LESS 61 */

            if (V0MLD_IDADE < 61)
            {

                /*" -2041- GO TO 410-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/ //GOTO
                return;
            }


            /*" -2043- MOVE '411' TO WNR-EXEC-SQL. */
            _.Move("411", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2050- PERFORM M_410_000_GERA_CARENCIAS_DB_SELECT_3 */

            M_410_000_GERA_CARENCIAS_DB_SELECT_3();

            /*" -2053- IF V0CAR-OCORHIST EQUAL ZEROS */

            if (V0CAR_OCORHIST == 00)
            {

                /*" -2054- IF MCOD-OPERACAO EQUAL 703 */

                if (MCOD_OPERACAO == 703)
                {

                    /*" -2055- GO TO 410-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/ //GOTO
                    return;

                    /*" -2056- ELSE */
                }
                else
                {


                    /*" -2057- GO TO 410-010-INCLUI-CARENCIAS */

                    M_410_010_INCLUI_CARENCIAS(); //GOTO
                    return;

                    /*" -2058- ELSE */
                }

            }
            else
            {


                /*" -2058- GO TO 410-020-ATUALIZA-CARENCIAS. */

                M_410_020_ATUALIZA_CARENCIAS(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM M_410_010_INCLUI_CARENCIAS */

            M_410_010_INCLUI_CARENCIAS();

        }

        [StopWatch]
        /*" M-410-000-GERA-CARENCIAS-DB-SELECT-1 */
        public void M_410_000_GERA_CARENCIAS_DB_SELECT_1()
        {
            /*" -2006- EXEC SQL SELECT OCORHIST INTO :V0PROP-OCORHIST FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1 = new M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1.Execute(m_410_000_GERA_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-400-000-ATUALIZA-COBERPROPVA-DB-UPDATE-3 */
        public void M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3()
        {
            /*" -1984- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET OCORHIST = :V0PROP-OCORHIST, CODOPER = :MCOD-OPERACAO, DTMOVTO = :MDATA-MOVIMENTO, CODUSU = :MCOD-USUARIO WHERE NRCERTIF = :MNUM-CERTIFICADO END-EXEC. */

            var m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1 = new M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1()
            {
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                MDATA_MOVIMENTO = MDATA_MOVIMENTO.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                MCOD_USUARIO = MCOD_USUARIO.ToString(),
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1.Execute(m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" M-410-000-GERA-CARENCIAS-DB-SELECT-2 */
        public void M_410_000_GERA_CARENCIAS_DB_SELECT_2()
        {
            /*" -2026- EXEC SQL SELECT IDADE, CAP_MN_ANT INTO :V0MLD-IDADE, :V0MLD-CAP-MN-ANT FROM SEGUROS.V0MLDTRDAZ WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1 = new M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1.Execute(m_410_000_GERA_CARENCIAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MLD_IDADE, V0MLD_IDADE);
                _.Move(executed_1.V0MLD_CAP_MN_ANT, V0MLD_CAP_MN_ANT);
            }


        }

        [StopWatch]
        /*" M-410-010-INCLUI-CARENCIAS */
        private void M_410_010_INCLUI_CARENCIAS(bool isPerform = false)
        {
            /*" -2064- MOVE '412' TO WNR-EXEC-SQL. */
            _.Move("412", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2066- IF V0MLD-IDADE GREATER 60 AND V0MLD-IDADE LESS 66 */

            if (V0MLD_IDADE > 60 && V0MLD_IDADE < 66)
            {

                /*" -2067- MOVE 4 TO V0CAR-CARENCIA */
                _.Move(4, V0CAR_CARENCIA);

                /*" -2068- ELSE */
            }
            else
            {


                /*" -2070- IF V0MLD-IDADE GREATER 65 AND V0MLD-IDADE LESS 71 */

                if (V0MLD_IDADE > 65 && V0MLD_IDADE < 71)
                {

                    /*" -2071- MOVE 8 TO V0CAR-CARENCIA */
                    _.Move(8, V0CAR_CARENCIA);

                    /*" -2072- ELSE */
                }
                else
                {


                    /*" -2074- IF V0MLD-IDADE GREATER 70 AND V0MLD-IDADE LESS 76 */

                    if (V0MLD_IDADE > 70 && V0MLD_IDADE < 76)
                    {

                        /*" -2075- MOVE 12 TO V0CAR-CARENCIA */
                        _.Move(12, V0CAR_CARENCIA);

                        /*" -2076- ELSE */
                    }
                    else
                    {


                        /*" -2078- IF V0MLD-IDADE GREATER 75 AND V0MLD-IDADE LESS 81 */

                        if (V0MLD_IDADE > 75 && V0MLD_IDADE < 81)
                        {

                            /*" -2080- MOVE 18 TO V0CAR-CARENCIA. */
                            _.Move(18, V0CAR_CARENCIA);
                        }

                    }

                }

            }


            /*" -2089- PERFORM M_410_010_INCLUI_CARENCIAS_DB_SELECT_1 */

            M_410_010_INCLUI_CARENCIAS_DB_SELECT_1();

            /*" -2092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2093- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2095- DISPLAY 'VG0020B - NOT FOUND IN V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - NOT FOUND IN V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2096- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2097- ELSE */
                }
                else
                {


                    /*" -2099- DISPLAY 'VG0020B - ERRO SELECT V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - ERRO SELECT V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2101- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2124- PERFORM M_410_010_INCLUI_CARENCIAS_DB_INSERT_1 */

            M_410_010_INCLUI_CARENCIAS_DB_INSERT_1();

            /*" -2127- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2129- DISPLAY 'VG0020B - ERRO INSERT CARENCIAS_VGAP' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO INSERT CARENCIAS_VGAP{MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -2131- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2131- GO TO 410-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-410-010-INCLUI-CARENCIAS-DB-SELECT-1 */
        public void M_410_010_INCLUI_CARENCIAS_DB_SELECT_1()
        {
            /*" -2089- EXEC SQL SELECT DATA_REFERENCIA + :V0CAR-CARENCIA MONTHS INTO :V0CAR-DTTERVIG FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO WITH UR END-EXEC. */

            var m_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1 = new M_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                V0CAR_CARENCIA = V0CAR_CARENCIA.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            var executed_1 = M_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1.Execute(m_410_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAR_DTTERVIG, V0CAR_DTTERVIG);
            }


        }

        [StopWatch]
        /*" M-410-010-INCLUI-CARENCIAS-DB-INSERT-1 */
        public void M_410_010_INCLUI_CARENCIAS_DB_INSERT_1()
        {
            /*" -2124- EXEC SQL INSERT INTO SEGUROS.CARENCIAS_VGAP (NUM_CERTIFICADO, OCORR_HISTORICO, COD_OPERACAO , IDADE , DATA_MOVIMENTO , DATA_INIVIGENCIA, DATA_TERVIGENCIA, SITUACAO , COD_USUARIO , TIMESTAMP ) VALUES (:MNUM-CERTIFICADO, :V0PROP-OCORHIST, :MCOD-OPERACAO, :V0MLD-IDADE, CURRENT DATE, :MDATA-REFERENCIA, :V0CAR-DTTERVIG, '0' , 'VG0020B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_410_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1 = new M_410_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V0MLD_IDADE = V0MLD_IDADE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                V0CAR_DTTERVIG = V0CAR_DTTERVIG.ToString(),
            };

            M_410_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1.Execute(m_410_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-410-000-GERA-CARENCIAS-DB-SELECT-3 */
        public void M_410_000_GERA_CARENCIAS_DB_SELECT_3()
        {
            /*" -2050- EXEC SQL SELECT VALUE (MAX(OCORR_HISTORICO),0) INTO :V0CAR-OCORHIST FROM SEGUROS.CARENCIAS_VGAP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1 = new M_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1.Execute(m_410_000_GERA_CARENCIAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAR_OCORHIST, V0CAR_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-410-020-ATUALIZA-CARENCIAS */
        private void M_410_020_ATUALIZA_CARENCIAS(bool isPerform = false)
        {
            /*" -2137- MOVE ' 410-020-ATUALIZA-CARENCIAS' TO PARAGRAFO. */
            _.Move(" 410-020-ATUALIZA-CARENCIAS", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2139- MOVE '413' TO WNR-EXEC-SQL. */
            _.Move("413", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2147- PERFORM M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1 */

            M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1();

            /*" -2150- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2152- DISPLAY 'VG0020B - ERRO UPDATE CARENCIAS_VGAP' MNUM-CERTIFICADO ' ' V0CAR-OCORHIST */

                $"VG0020B - ERRO UPDATE CARENCIAS_VGAP{MNUM_CERTIFICADO} {V0CAR_OCORHIST}"
                .Display();

                /*" -2154- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2155- IF MIMP-MORNATU-ATU NOT GREATER V0MLD-CAP-MN-ANT */

            if (MIMP_MORNATU_ATU <= V0MLD_CAP_MN_ANT)
            {

                /*" -2157- GO TO 410-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/ //GOTO
                return;
            }


            /*" -2159- IF V0MLD-IDADE GREATER 60 AND V0MLD-IDADE LESS 66 */

            if (V0MLD_IDADE > 60 && V0MLD_IDADE < 66)
            {

                /*" -2160- MOVE 4 TO V0CAR-CARENCIA */
                _.Move(4, V0CAR_CARENCIA);

                /*" -2161- ELSE */
            }
            else
            {


                /*" -2163- IF V0MLD-IDADE GREATER 65 AND V0MLD-IDADE LESS 71 */

                if (V0MLD_IDADE > 65 && V0MLD_IDADE < 71)
                {

                    /*" -2164- MOVE 8 TO V0CAR-CARENCIA */
                    _.Move(8, V0CAR_CARENCIA);

                    /*" -2165- ELSE */
                }
                else
                {


                    /*" -2167- IF V0MLD-IDADE GREATER 70 AND V0MLD-IDADE LESS 76 */

                    if (V0MLD_IDADE > 70 && V0MLD_IDADE < 76)
                    {

                        /*" -2168- MOVE 12 TO V0CAR-CARENCIA */
                        _.Move(12, V0CAR_CARENCIA);

                        /*" -2169- ELSE */
                    }
                    else
                    {


                        /*" -2171- IF V0MLD-IDADE GREATER 75 AND V0MLD-IDADE LESS 81 */

                        if (V0MLD_IDADE > 75 && V0MLD_IDADE < 81)
                        {

                            /*" -2173- MOVE 18 TO V0CAR-CARENCIA. */
                            _.Move(18, V0CAR_CARENCIA);
                        }

                    }

                }

            }


            /*" -2182- PERFORM M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1 */

            M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1();

            /*" -2185- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2186- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2188- DISPLAY 'VG0020B - NOT FOUND IN V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - NOT FOUND IN V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2189- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2190- ELSE */
                }
                else
                {


                    /*" -2192- DISPLAY 'VG0020B - ERRO SELECT V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - ERRO SELECT V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2194- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2217- PERFORM M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1 */

            M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1();

            /*" -2220- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2222- DISPLAY 'VG0020B - ERRO INSERT CARENCIAS_VGAP' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO INSERT CARENCIAS_VGAP{MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -2222- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-410-020-ATUALIZA-CARENCIAS-DB-UPDATE-1 */
        public void M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1()
        {
            /*" -2147- EXEC SQL UPDATE SEGUROS.CARENCIAS_VGAP SET DATA_MOVIMENTO = CURRENT DATE, SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND OCORR_HISTORICO = :V0CAR-OCORHIST END-EXEC. */

            var m_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1 = new M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0CAR_OCORHIST = V0CAR_OCORHIST.ToString(),
            };

            M_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1.Execute(m_410_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-410-020-ATUALIZA-CARENCIAS-DB-SELECT-1 */
        public void M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1()
        {
            /*" -2182- EXEC SQL SELECT DATA_REFERENCIA + :V0CAR-CARENCIA MONTHS INTO :V0CAR-DTTERVIG FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO WITH UR END-EXEC. */

            var m_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1 = new M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                V0CAR_CARENCIA = V0CAR_CARENCIA.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            var executed_1 = M_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1.Execute(m_410_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAR_DTTERVIG, V0CAR_DTTERVIG);
            }


        }

        [StopWatch]
        /*" M-410-020-ATUALIZA-CARENCIAS-DB-INSERT-1 */
        public void M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1()
        {
            /*" -2217- EXEC SQL INSERT INTO SEGUROS.CARENCIAS_VGAP (NUM_CERTIFICADO, OCORR_HISTORICO, COD_OPERACAO , IDADE , DATA_MOVIMENTO , DATA_INIVIGENCIA, DATA_TERVIGENCIA, SITUACAO , COD_USUARIO , TIMESTAMP ) VALUES (:MNUM-CERTIFICADO, :V0PROP-OCORHIST, :MCOD-OPERACAO, :V0MLD-IDADE, CURRENT DATE, :MDATA-REFERENCIA, :V0CAR-DTTERVIG, '0' , 'VG0020B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1 = new M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V0MLD_IDADE = V0MLD_IDADE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                V0CAR_DTTERVIG = V0CAR_DTTERVIG.ToString(),
            };

            M_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1.Execute(m_410_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_410_999_EXIT*/

        [StopWatch]
        /*" M-420-000-GERA-CARENCIAS-SECTION */
        private void M_420_000_GERA_CARENCIAS_SECTION()
        {
            /*" -2232- MOVE '420-000-GERA-CARENCIAS       ' TO PARAGRAFO */
            _.Move("420-000-GERA-CARENCIAS       ", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2234- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2240- PERFORM M_420_000_GERA_CARENCIAS_DB_SELECT_1 */

            M_420_000_GERA_CARENCIAS_DB_SELECT_1();

            /*" -2243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2244- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2246- DISPLAY 'VG0020B - NOT FOUND IN V0PROPOSTAVA  ' MNUM-CERTIFICADO */
                    _.Display($"VG0020B - NOT FOUND IN V0PROPOSTAVA  {MNUM_CERTIFICADO}");

                    /*" -2247- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2248- ELSE */
                }
                else
                {


                    /*" -2250- DISPLAY 'VG0020B - ERRO SELECT V0PROPOSTAVA  ' MNUM-CERTIFICADO */
                    _.Display($"VG0020B - ERRO SELECT V0PROPOSTAVA  {MNUM_CERTIFICADO}");

                    /*" -2252- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2253- IF WDATA-NASC < 0 */

            if (WDATA_NASC < 0)
            {

                /*" -2254- MOVE '420   ' TO PARAGRAFO */
                _.Move("420   ", WS_AUXILIARES.WABEND.PARAGRAFO);

                /*" -2260- PERFORM M_420_000_GERA_CARENCIAS_DB_SELECT_2 */

                M_420_000_GERA_CARENCIAS_DB_SELECT_2();

                /*" -2262- IF WDATA-NASC < 0 */

                if (WDATA_NASC < 0)
                {

                    /*" -2263- DISPLAY 'PROBLEMAS ACESSO V0CLIENTE ' SQLCODE */
                    _.Display($"PROBLEMAS ACESSO V0CLIENTE {DB.SQLCODE}");

                    /*" -2264- DISPLAY 'SEGURADO SEM DATA DE NASCIMENTO ' */
                    _.Display($"SEGURADO SEM DATA DE NASCIMENTO ");

                    /*" -2265- DISPLAY 'CODCLIENTE ........ ' MCOD-CLIENTE */
                    _.Display($"CODCLIENTE ........ {MCOD_CLIENTE}");

                    /*" -2266- DISPLAY 'CERTIFICADO ....... ' MNUM-CERTIFICADO */
                    _.Display($"CERTIFICADO ....... {MNUM_CERTIFICADO}");

                    /*" -2267- GO TO 420-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/ //GOTO
                    return;

                    /*" -2268- ELSE */
                }
                else
                {


                    /*" -2270- MOVE CLIE-DTNASC TO SDATA-NASC. */
                    _.Move(CLIE_DTNASC, SDATA_NASC);
                }

            }


            /*" -2271- MOVE SDATA-NASC TO WK-DATA1. */
            _.Move(SDATA_NASC, WS_AUXILIARES.WK_DATA1);

            /*" -2273- MOVE V1SISTEMA-DTMOVABE TO WK-DATA2. */
            _.Move(V1SISTEMA_DTMOVABE, WS_AUXILIARES.WK_DATA2);

            /*" -2275- COMPUTE WS-IDADE = WK-ANO2 - WK-ANO1. */
            WS_AUXILIARES.WS_IDADE.Value = WS_AUXILIARES.WK_DATA2.WK_ANO2 - WS_AUXILIARES.WK_DATA1.WK_ANO1;

            /*" -2276- IF WK-MES1 > WK-MES2 */

            if (WS_AUXILIARES.WK_DATA1.WK_MES1 > WS_AUXILIARES.WK_DATA2.WK_MES2)
            {

                /*" -2278- COMPUTE WS-IDADE = WS-IDADE - 1. */
                WS_AUXILIARES.WS_IDADE.Value = WS_AUXILIARES.WS_IDADE - 1;
            }


            /*" -2280- MOVE WS-IDADE TO V0MLD-IDADE. */
            _.Move(WS_AUXILIARES.WS_IDADE, V0MLD_IDADE);

            /*" -2281- IF V0MLD-IDADE LESS 61 */

            if (V0MLD_IDADE < 61)
            {

                /*" -2283- GO TO 420-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/ //GOTO
                return;
            }


            /*" -2285- MOVE '421' TO WNR-EXEC-SQL. */
            _.Move("421", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2291- PERFORM M_420_000_GERA_CARENCIAS_DB_SELECT_3 */

            M_420_000_GERA_CARENCIAS_DB_SELECT_3();

            /*" -2294- IF V0CAR-OCORHIST EQUAL ZEROS */

            if (V0CAR_OCORHIST == 00)
            {

                /*" -2296- IF MCOD-OPERACAO GREATER 699 AND MCOD-OPERACAO LESS 800 */

                if (MCOD_OPERACAO > 699 && MCOD_OPERACAO < 800)
                {

                    /*" -2297- GO TO 420-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/ //GOTO
                    return;

                    /*" -2298- ELSE */
                }
                else
                {


                    /*" -2299- GO TO 420-010-INCLUI-CARENCIAS */

                    M_420_010_INCLUI_CARENCIAS(); //GOTO
                    return;

                    /*" -2300- ELSE */
                }

            }
            else
            {


                /*" -2300- GO TO 420-020-ATUALIZA-CARENCIAS. */

                M_420_020_ATUALIZA_CARENCIAS(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM M_420_010_INCLUI_CARENCIAS */

            M_420_010_INCLUI_CARENCIAS();

        }

        [StopWatch]
        /*" M-420-000-GERA-CARENCIAS-DB-SELECT-1 */
        public void M_420_000_GERA_CARENCIAS_DB_SELECT_1()
        {
            /*" -2240- EXEC SQL SELECT OCORHIST INTO :V0PROP-OCORHIST FROM SEGUROS.V0PROPOSTAVA WHERE NRCERTIF = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1 = new M_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1.Execute(m_420_000_GERA_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_OCORHIST, V0PROP_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-420-010-INCLUI-CARENCIAS */
        private void M_420_010_INCLUI_CARENCIAS(bool isPerform = false)
        {
            /*" -2306- MOVE '420-010-INCLUI-CARENCIAS' TO PARAGRAFO. */
            _.Move("420-010-INCLUI-CARENCIAS", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2308- MOVE '422' TO WNR-EXEC-SQL. */
            _.Move("422", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2310- IF V0MLD-IDADE GREATER 60 AND V0MLD-IDADE LESS 66 */

            if (V0MLD_IDADE > 60 && V0MLD_IDADE < 66)
            {

                /*" -2311- MOVE 4 TO V0CAR-CARENCIA */
                _.Move(4, V0CAR_CARENCIA);

                /*" -2312- ELSE */
            }
            else
            {


                /*" -2314- IF V0MLD-IDADE GREATER 65 AND V0MLD-IDADE LESS 71 */

                if (V0MLD_IDADE > 65 && V0MLD_IDADE < 71)
                {

                    /*" -2315- MOVE 8 TO V0CAR-CARENCIA */
                    _.Move(8, V0CAR_CARENCIA);

                    /*" -2316- ELSE */
                }
                else
                {


                    /*" -2318- IF V0MLD-IDADE GREATER 70 AND V0MLD-IDADE LESS 76 */

                    if (V0MLD_IDADE > 70 && V0MLD_IDADE < 76)
                    {

                        /*" -2319- MOVE 12 TO V0CAR-CARENCIA */
                        _.Move(12, V0CAR_CARENCIA);

                        /*" -2320- ELSE */
                    }
                    else
                    {


                        /*" -2322- IF V0MLD-IDADE GREATER 75 AND V0MLD-IDADE LESS 81 */

                        if (V0MLD_IDADE > 75 && V0MLD_IDADE < 81)
                        {

                            /*" -2324- MOVE 18 TO V0CAR-CARENCIA. */
                            _.Move(18, V0CAR_CARENCIA);
                        }

                    }

                }

            }


            /*" -2333- PERFORM M_420_010_INCLUI_CARENCIAS_DB_SELECT_1 */

            M_420_010_INCLUI_CARENCIAS_DB_SELECT_1();

            /*" -2336- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2337- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2339- DISPLAY 'VG0020B - NOT FOUND IN V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - NOT FOUND IN V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2340- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2341- ELSE */
                }
                else
                {


                    /*" -2343- DISPLAY 'VG0020B - ERRO SELECT V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - ERRO SELECT V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2345- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2368- PERFORM M_420_010_INCLUI_CARENCIAS_DB_INSERT_1 */

            M_420_010_INCLUI_CARENCIAS_DB_INSERT_1();

            /*" -2371- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2373- DISPLAY 'VG0020B - ERRO INSERT CARENCIAS_VGAP' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO INSERT CARENCIAS_VGAP{MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -2375- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2375- GO TO 420-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" M-420-010-INCLUI-CARENCIAS-DB-SELECT-1 */
        public void M_420_010_INCLUI_CARENCIAS_DB_SELECT_1()
        {
            /*" -2333- EXEC SQL SELECT DATA_REFERENCIA + :V0CAR-CARENCIA MONTHS INTO :V0CAR-DTTERVIG FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO WITH UR END-EXEC. */

            var m_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1 = new M_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                V0CAR_CARENCIA = V0CAR_CARENCIA.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            var executed_1 = M_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1.Execute(m_420_010_INCLUI_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAR_DTTERVIG, V0CAR_DTTERVIG);
            }


        }

        [StopWatch]
        /*" M-420-010-INCLUI-CARENCIAS-DB-INSERT-1 */
        public void M_420_010_INCLUI_CARENCIAS_DB_INSERT_1()
        {
            /*" -2368- EXEC SQL INSERT INTO SEGUROS.CARENCIAS_VGAP (NUM_CERTIFICADO, OCORR_HISTORICO, COD_OPERACAO , IDADE , DATA_MOVIMENTO , DATA_INIVIGENCIA, DATA_TERVIGENCIA, SITUACAO , COD_USUARIO , TIMESTAMP ) VALUES (:MNUM-CERTIFICADO, :V0PROP-OCORHIST, :MCOD-OPERACAO, :V0MLD-IDADE, CURRENT DATE, :MDATA-REFERENCIA, :V0CAR-DTTERVIG, '0' , 'VG0020B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_420_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1 = new M_420_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V0MLD_IDADE = V0MLD_IDADE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                V0CAR_DTTERVIG = V0CAR_DTTERVIG.ToString(),
            };

            M_420_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1.Execute(m_420_010_INCLUI_CARENCIAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-420-000-GERA-CARENCIAS-DB-SELECT-2 */
        public void M_420_000_GERA_CARENCIAS_DB_SELECT_2()
        {
            /*" -2260- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIE-DTNASC:WDATA-NASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :MCOD-CLIENTE WITH UR END-EXEC */

            var m_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1 = new M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1()
            {
                MCOD_CLIENTE = MCOD_CLIENTE.ToString(),
            };

            var executed_1 = M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1.Execute(m_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIE_DTNASC, CLIE_DTNASC);
                _.Move(executed_1.WDATA_NASC, WDATA_NASC);
            }


        }

        [StopWatch]
        /*" M-420-020-ATUALIZA-CARENCIAS */
        private void M_420_020_ATUALIZA_CARENCIAS(bool isPerform = false)
        {
            /*" -2381- MOVE '420-020-ATUALIZA-CARENCIAS' TO PARAGRAFO. */
            _.Move("420-020-ATUALIZA-CARENCIAS", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2383- MOVE '423' TO WNR-EXEC-SQL. */
            _.Move("423", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2391- PERFORM M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1 */

            M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1();

            /*" -2394- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2396- DISPLAY 'VG0020B - ERRO UPDATE CARENCIAS_VGAP' MNUM-CERTIFICADO ' ' V0CAR-OCORHIST */

                $"VG0020B - ERRO UPDATE CARENCIAS_VGAP{MNUM_CERTIFICADO} {V0CAR_OCORHIST}"
                .Display();

                /*" -2398- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2399- IF MIMP-MORNATU-ATU NOT GREATER MIMP-MORNATU-ANT */

            if (MIMP_MORNATU_ATU <= MIMP_MORNATU_ANT)
            {

                /*" -2401- GO TO 420-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/ //GOTO
                return;
            }


            /*" -2403- IF V0MLD-IDADE GREATER 60 AND V0MLD-IDADE LESS 66 */

            if (V0MLD_IDADE > 60 && V0MLD_IDADE < 66)
            {

                /*" -2404- MOVE 4 TO V0CAR-CARENCIA */
                _.Move(4, V0CAR_CARENCIA);

                /*" -2405- ELSE */
            }
            else
            {


                /*" -2407- IF V0MLD-IDADE GREATER 65 AND V0MLD-IDADE LESS 71 */

                if (V0MLD_IDADE > 65 && V0MLD_IDADE < 71)
                {

                    /*" -2408- MOVE 8 TO V0CAR-CARENCIA */
                    _.Move(8, V0CAR_CARENCIA);

                    /*" -2409- ELSE */
                }
                else
                {


                    /*" -2411- IF V0MLD-IDADE GREATER 70 AND V0MLD-IDADE LESS 76 */

                    if (V0MLD_IDADE > 70 && V0MLD_IDADE < 76)
                    {

                        /*" -2412- MOVE 12 TO V0CAR-CARENCIA */
                        _.Move(12, V0CAR_CARENCIA);

                        /*" -2413- ELSE */
                    }
                    else
                    {


                        /*" -2415- IF V0MLD-IDADE GREATER 75 AND V0MLD-IDADE LESS 81 */

                        if (V0MLD_IDADE > 75 && V0MLD_IDADE < 81)
                        {

                            /*" -2417- MOVE 18 TO V0CAR-CARENCIA. */
                            _.Move(18, V0CAR_CARENCIA);
                        }

                    }

                }

            }


            /*" -2426- PERFORM M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1 */

            M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1();

            /*" -2429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2430- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2432- DISPLAY 'VG0020B - NOT FOUND IN V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - NOT FOUND IN V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2433- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2434- ELSE */
                }
                else
                {


                    /*" -2436- DISPLAY 'VG0020B - ERRO SELECT V0MOVIMENTO   ' MNUM-CERTIFICADO ' ' MNUM-PROPOSTA ' ' MCOD-FONTE */

                    $"VG0020B - ERRO SELECT V0MOVIMENTO   {MNUM_CERTIFICADO} {MNUM_PROPOSTA} {MCOD_FONTE}"
                    .Display();

                    /*" -2438- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2461- PERFORM M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1 */

            M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1();

            /*" -2464- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2466- DISPLAY 'VG0020B - ERRO INSERT CARENCIAS_VGAP' MNUM-CERTIFICADO ' ' V0PROP-OCORHIST */

                $"VG0020B - ERRO INSERT CARENCIAS_VGAP{MNUM_CERTIFICADO} {V0PROP_OCORHIST}"
                .Display();

                /*" -2466- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-420-020-ATUALIZA-CARENCIAS-DB-UPDATE-1 */
        public void M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1()
        {
            /*" -2391- EXEC SQL UPDATE SEGUROS.CARENCIAS_VGAP SET DATA_MOVIMENTO = CURRENT DATE, SITUACAO = '2' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND OCORR_HISTORICO = :V0CAR-OCORHIST END-EXEC. */

            var m_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1 = new M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0CAR_OCORHIST = V0CAR_OCORHIST.ToString(),
            };

            M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1.Execute(m_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-420-020-ATUALIZA-CARENCIAS-DB-SELECT-1 */
        public void M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1()
        {
            /*" -2426- EXEC SQL SELECT DATA_REFERENCIA + :V0CAR-CARENCIA MONTHS INTO :V0CAR-DTTERVIG FROM SEGUROS.V0MOVIMENTO WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO AND COD_FONTE = :MCOD-FONTE AND NUM_PROPOSTA = :MNUM-PROPOSTA AND TIPO_SEGURADO = :MTIPO-SEGURADO WITH UR END-EXEC. */

            var m_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1 = new M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                MTIPO_SEGURADO = MTIPO_SEGURADO.ToString(),
                V0CAR_CARENCIA = V0CAR_CARENCIA.ToString(),
                MNUM_PROPOSTA = MNUM_PROPOSTA.ToString(),
                MCOD_FONTE = MCOD_FONTE.ToString(),
            };

            var executed_1 = M_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1.Execute(m_420_020_ATUALIZA_CARENCIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAR_DTTERVIG, V0CAR_DTTERVIG);
            }


        }

        [StopWatch]
        /*" M-420-020-ATUALIZA-CARENCIAS-DB-INSERT-1 */
        public void M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1()
        {
            /*" -2461- EXEC SQL INSERT INTO SEGUROS.CARENCIAS_VGAP (NUM_CERTIFICADO, OCORR_HISTORICO, COD_OPERACAO , IDADE , DATA_MOVIMENTO , DATA_INIVIGENCIA, DATA_TERVIGENCIA, SITUACAO , COD_USUARIO , TIMESTAMP ) VALUES (:MNUM-CERTIFICADO, :V0PROP-OCORHIST, :MCOD-OPERACAO, :V0MLD-IDADE, CURRENT DATE, :MDATA-REFERENCIA, :V0CAR-DTTERVIG, '0' , 'VG0020B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1 = new M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
                V0PROP_OCORHIST = V0PROP_OCORHIST.ToString(),
                MCOD_OPERACAO = MCOD_OPERACAO.ToString(),
                V0MLD_IDADE = V0MLD_IDADE.ToString(),
                MDATA_REFERENCIA = MDATA_REFERENCIA.ToString(),
                V0CAR_DTTERVIG = V0CAR_DTTERVIG.ToString(),
            };

            M_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1.Execute(m_420_020_ATUALIZA_CARENCIAS_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-420-000-GERA-CARENCIAS-DB-SELECT-3 */
        public void M_420_000_GERA_CARENCIAS_DB_SELECT_3()
        {
            /*" -2291- EXEC SQL SELECT VALUE (MAX(OCORR_HISTORICO),0) INTO :V0CAR-OCORHIST FROM SEGUROS.CARENCIAS_VGAP WHERE NUM_CERTIFICADO = :MNUM-CERTIFICADO WITH UR END-EXEC. */

            var m_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1 = new M_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1()
            {
                MNUM_CERTIFICADO = MNUM_CERTIFICADO.ToString(),
            };

            var executed_1 = M_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1.Execute(m_420_000_GERA_CARENCIAS_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CAR_OCORHIST, V0CAR_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" R7777-CONS-MODALIDADE-APOL-SECTION */
        private void R7777_CONS_MODALIDADE_APOL_SECTION()
        {
            /*" -2476- MOVE '7777' TO WNR-EXEC-SQL. */
            _.Move("7777", WS_AUXILIARES.WABEND.WNR_EXEC_SQL);

            /*" -2478- MOVE 'R7777-CONS-MODALIDADE-APOL' TO PARAGRAFO */
            _.Move("R7777-CONS-MODALIDADE-APOL", WS_AUXILIARES.WABEND.PARAGRAFO);

            /*" -2480- INITIALIZE REGISTRO-LINKAGE-GE0510S. */
            _.Initialize(
                REGISTRO_LINKAGE_GE0510S
            );

            /*" -2481- MOVE MNUM-APOLICE TO LK-GE510-NUM-APOLICE */
            _.Move(MNUM_APOLICE, REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE);

            /*" -2483- MOVE MCOD-SUBGRUPO TO LK-GE510-COD-SUBGRUPO */
            _.Move(MCOD_SUBGRUPO, REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO);

            /*" -2485- CALL 'GE0510S' USING REGISTRO-LINKAGE-GE0510S. */
            _.Call("GE0510S", REGISTRO_LINKAGE_GE0510S);

            /*" -2486- IF (LK-GE510-COD-RETORNO EQUAL '0' ) */

            if ((REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO == "0"))
            {

                /*" -2487- MOVE LK-GE510-COD-MODALIDADE TO V0APOL-MODALIDA */
                _.Move(REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_MODALIDADE, V0APOL_MODALIDA);

                /*" -2488- ELSE */
            }
            else
            {


                /*" -2489- DISPLAY ' ' */
                _.Display($" ");

                /*" -2490- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2491- DISPLAY '*      R7777-CONS-MODALIDA-APOL         *' */
                _.Display($"*      R7777-CONS-MODALIDA-APOL         *");

                /*" -2492- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0510S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0510S  *");

                /*" -2493- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2494- DISPLAY '=> APOLICE........ ' LK-GE510-NUM-APOLICE */
                _.Display($"=> APOLICE........ {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_APOLICE}");

                /*" -2495- DISPLAY '=> COD-SUBGRUPO... ' LK-GE510-COD-SUBGRUPO */
                _.Display($"=> COD-SUBGRUPO... {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_SUBGRUPO}");

                /*" -2496- DISPLAY '=> NUM-CERTIFICADO ' LK-GE510-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {REGISTRO_LINKAGE_GE0510S.LK_GE510_NUM_CERTIFICADO}");

                /*" -2497- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -2498- DISPLAY '=> LK-MENSAGEM ... ' LK-GE510-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM}");

                /*" -2499- DISPLAY '=> LK-COD-RETORNO. ' LK-GE510-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {REGISTRO_LINKAGE_GE0510S.LK_GE510_COD_RETORNO}");

                /*" -2500- DISPLAY '=> LK-SQLCODE..... ' LK-GE510-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {REGISTRO_LINKAGE_GE0510S.LK_GE510_MENSAGEM.LK_GE510_SQLCODE}");

                /*" -2501- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -2502- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2503- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7777_99_SAIDA*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -2513- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WS_AUXILIARES.WABEND.WSQLCODE);

            /*" -2514- MOVE SQLERRD(1) TO WSQLCODE1 */
            _.Move(DB.SQLERRD[1], WS_AUXILIARES.WABEND.WSQLCODE1);

            /*" -2515- MOVE SQLERRD(2) TO WSQLCODE2 */
            _.Move(DB.SQLERRD[2], WS_AUXILIARES.WABEND.WSQLCODE2);

            /*" -2516- MOVE SQLCODE TO WSQLCODE3 */
            _.Move(DB.SQLCODE, WS_AUXILIARES.WSQLCODE3);

            /*" -2518- DISPLAY WABEND. */
            _.Display(WS_AUXILIARES.WABEND);

            /*" -2519- DISPLAY 'APOLICE       ' MNUM-APOLICE */
            _.Display($"APOLICE       {MNUM_APOLICE}");

            /*" -2520- DISPLAY 'SUBGRUPO      ' MCOD-SUBGRUPO */
            _.Display($"SUBGRUPO      {MCOD_SUBGRUPO}");

            /*" -2521- DISPLAY 'NR ENDOSSO    ' VGNRENDOS */
            _.Display($"NR ENDOSSO    {VGNRENDOS}");

            /*" -2522- DISPLAY 'NR ITEM       ' VGNUM-ITEM */
            _.Display($"NR ITEM       {VGNUM_ITEM}");

            /*" -2523- DISPLAY 'OCORR HIST    ' HOCORR-HISTORICO */
            _.Display($"OCORR HIST    {HOCORR_HISTORICO}");

            /*" -2524- DISPLAY 'RAMO          ' VGRAMOFR */
            _.Display($"RAMO          {VGRAMOFR}");

            /*" -2525- DISPLAY 'MODALIDADE    ' VGMODALIFR */
            _.Display($"MODALIDADE    {VGMODALIFR}");

            /*" -2526- DISPLAY 'COD COBERTURA ' VGCOD-COBERTURA */
            _.Display($"COD COBERTURA {VGCOD_COBERTURA}");

            /*" -2527- DISPLAY 'FONTE         ' MCOD-FONTE */
            _.Display($"FONTE         {MCOD_FONTE}");

            /*" -2528- DISPLAY 'PROPOSTA      ' MNUM-PROPOSTA */
            _.Display($"PROPOSTA      {MNUM_PROPOSTA}");

            /*" -2530- DISPLAY 'CERTIFICADO   ' MNUM-CERTIFICADO. */
            _.Display($"CERTIFICADO   {MNUM_CERTIFICADO}");

            /*" -2532- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2536- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2540- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2540- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}