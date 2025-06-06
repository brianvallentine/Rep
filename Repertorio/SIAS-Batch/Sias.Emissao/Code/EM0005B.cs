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
using Sias.Emissao.DB2.EM0005B;

namespace Code
{
    public class EM0005B
    {
        public bool IsCall { get; set; }

        public EM0005B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0005B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1991                       *      */
        /*"      *   VERSAO .................  02012009 17:00HS                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - ATRAVES DA V1PROPOSTA, ATUALIZA  *      */
        /*"      *                               DB DE APOLICES                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           INPUT    *      */
        /*"      * RAMOS                               V1RAMOIND         INPUT    *      */
        /*"      * NUMERO DE APOLICES/ENDOSSOS         V0NUMERO_AES      I-O      *      */
        /*"      * PROPOSTAS                           V1PROPOSTA        INPUT    *      */
        /*"      * PROPOSTAS/CORRETOR                  V1PROPCORRET      INPUT    *      */
        /*"      * PROPOSTAS/COSSEGUROS CEDIDO         V1PROPCOSCED      INPUT    *      */
        /*"      * COBERTURA DE PROPOSTAS              V1COBERPROP       INPUT    *      */
        /*"      * PODER PUBLICO (COSSEGURADORAS)      V1COSSEGSORT      INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         OUTPUT   *      */
        /*"      * APOLICE/CORRETOR                    V0PROPCORRET      OUTPUT   *      */
        /*"      * APOLICE/COSSEGURO CEDIDO            V0PROPCOSCED      OUTPUT   *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * COBERTURA DE APOLICES               V0COBERPROP       OUTPUT   *      */
        /*"      * CONTROLE DE PROPOSTAS               V0CONTPROP        I-O      *      */
        /*"      * ACOMPANHA PROPOSTAS                 V0ACOMPROP        OUTPUT   *      */
        /*"      * PROPOSTA CLAUSULAS                  V1PROPCLAU        INPUT    *      */
        /*"      * APOLICE CLAUSULAS                   V0APOLCLAUSULA    OUTPUT   *      */
        /*"      * EMISSAO DIARIA                      V0EMISDIARIA      OUTPUT   *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           10/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * JAZZ 225440 - TRATAR CONGENERE NOVA                            *      */
        /*"      *             - ALTERADO PARA OBTER A CONGENERE NA DATA DO       *      */
        /*"      *               PROCESSAMENTO                                    *      */
        /*"      * EM 16/01/2020 - OLIVEIRA                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - CADMUS 82475 - NOVO PRODUTO CCA                  *      */
        /*"      *                                                                *      */
        /*"      *          INCLUSAO DO NOVO PRODUTO 1805 - CORRESPONDENTE CAIXA  *      */
        /*"      *          AQUI                                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/09/2013 - GUILHERME CORREIA        PROCURE POR V.03    *      */
        /*"V.02  *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CADMUS 74582 - PROJETO AUTO FACIL                *      */
        /*"      *                                                                *      */
        /*"      *          FORMATAR CODIGO DO BANCO NA COLUNA BANCO COBRANCA     *      */
        /*"      *          TABELA ENDOSSOS, RECUPERADO NA PROPOSTA               *      */
        /*"      *          PRODUTOS: 5302, 5303 E 5304                           *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/01/2013 - COREON                   PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - CADMUS 18.768                                    *      */
        /*"      *                                                                *      */
        /*"      *          PASSA A TRATAR O DESCONTO COMERCIAL E                 *      */
        /*"      *          NOVA DISTRIBUICAO DE CORRETAGEM NA SUBROTINA          *      */
        /*"      *          EM0912S.                                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/02/2009 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *    29/12/98 - CONSEDA4                                         *      */
        /*"      *    ALTERACAO DO CALCULO DO IOF - ACESSO A TABELA V1RAMOIND     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *    20/03/07 - FAST COMPUTER                                    *      */
        /*"      *                                                                *      */
        /*"      *    PASSA A TRATAR O PRODUTO 1804 - PROCURE FC0703              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 22/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *    21/10/08 - FAST COMPUTER                                    *      */
        /*"      *                                                                *      */
        /*"      *    CAD-13011                       PROCURE V.01                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         W1CPRO-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis W1CPRO_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W0APOL-PCTCED       PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         W1COBP-PCT-TOTAL    PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PCT_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         W1COBP-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1COBP-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1COBP-NUM-ITEM     PIC S9(009)      VALUE +0  COMP-3*/
        public IntBasis W1COBP_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W0NAES-SEQ-APOLICE  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W0NAES_SEQ_APOLICE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W0APOL-QTCOSSEG     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis W0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WS-COD-CONGENERE    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis WS_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1PCOR-CODCORR      PIC S9(009)      VALUE +0  COMP-3*/
        public IntBasis W1PCOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W0COBA-IMP-SEG-IX   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis W0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-IX   PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis W0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-IMP-SEG-VR   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis W0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-VR   PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis W0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         VIND-NUM-ATA        PIC S9(004)                COMP.*/
        public IntBasis VIND_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ANO-ATA        PIC S9(004)                COMP.*/
        public IntBasis VIND_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-SORT       PIC S9(004)                COMP.*/
        public IntBasis VIND_DAT_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)                COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTAPOLM        PIC S9(004)                COMP.*/
        public IntBasis VIND_DTAPOLM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-RCAP       PIC S9(004)                COMP.*/
        public IntBasis VIND_DAT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)                COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)                COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PRMTARIFA      PIC S9(004)                COMP.*/
        public IntBasis VIND_PRMTARIFA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-INSPETOR       PIC S9(004)                COMP.*/
        public IntBasis VIND_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CANALPROD      PIC S9(004)                COMP.*/
        public IntBasis VIND_CANALPROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTVENCTO       PIC S9(004)                COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CFPREFIX       PIC S9(004)                COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCUSEMI       PIC S9(004)                COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1FONT-ORGAOEMIS    PIC S9(004)                COMP.*/
        public IntBasis V1FONT_ORGAOEMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RAMO-PCIOF        PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1RAMO_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0EDIA-CODRELAT     PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0EDIA-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0EDIA-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-NRPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-DTMOVTO      PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0EDIA-ORGAO        PIC S9(004)                COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CONGENER     PIC S9(004)                COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CODCORR      PIC S9(009)                COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-SITUACAO     PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0EDIA-COD-EMP      PIC S9(004)                COMP.*/
        public IntBasis V0EDIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-COD-ORGAO    PIC S9(004)                COMP.*/
        public IntBasis V0NAES_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-COD-RAMO     PIC S9(004)                COMP.*/
        public IntBasis V0NAES_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-SEQ-APOLICE  PIC S9(009)                COMP.*/
        public IntBasis V0NAES_SEQ_APOLICE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSCOB     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSCOB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-NRENDOCA     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSRES     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSRES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSSEM     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSSEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSCCR     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSCCR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSMVC     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_ENDOSMVC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-NUMSIN       PIC S9(009)                COMP.*/
        public IntBasis V0NAES_NUMSIN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-PROPOATM     PIC S9(009)                COMP.*/
        public IntBasis V0NAES_PROPOATM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-TPPROPOS     PIC  X(001).*/
        public StringBasis V1PROP_TPPROPOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NRPROPOS     PIC S9(009)                COMP.*/
        public IntBasis V1PROP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V1PROP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-MODALIDA     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NUM-APO-ANT  PIC S9(013)                COMP-3*/
        public IntBasis V1PROP_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PROP-TIPAPO       PIC  X(001).*/
        public StringBasis V1PROP_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-CODCLIEN     PIC S9(009)                COMP.*/
        public IntBasis V1PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PROP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V2PROP-DTINIVIG     PIC  X(010).*/
        public StringBasis V2PROP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V3PROP-DTINIVIG     PIC  X(010).*/
        public StringBasis V3PROP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PROP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V2PROP-DTTERVIG     PIC  X(010).*/
        public StringBasis V2PROP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V3PROP-DTTERVIG     PIC  X(010).*/
        public StringBasis V3PROP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-PODPUBL      PIC  X(001).*/
        public StringBasis V1PROP_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-CORRECAO     PIC  X(001).*/
        public StringBasis V1PROP_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-MOEDA-IMP    PIC S9(004)                COMP.*/
        public IntBasis V1PROP_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-MOEDA-PRM    PIC S9(004)                COMP.*/
        public IntBasis V1PROP_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-PRESTA1      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-BCORCAP      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-AGERCAP      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NRRCAP       PIC S9(009)                COMP.*/
        public IntBasis V1PROP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-VLRCAP       PIC S9(013)V99             COMP-3*/
        public DoubleBasis V1PROP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PROP-CDFRACIO     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTPARCEL     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-PCENTRAD     PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1PROP_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PROP-PCADICIO     PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1PROP_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PROP-IDIOF        PIC  X(001).*/
        public StringBasis V1PROP_IDIOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-ISENTA-CST   PIC  X(001).*/
        public StringBasis V1PROP_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-QTPRESTA     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-BCOCOBR      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-AGECOBR      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-TPCORRET     PIC  X(001).*/
        public StringBasis V1PROP_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NRAUTCOR     PIC S9(009)                COMP.*/
        public IntBasis V1PROP_NRAUTCOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-QTCORR       PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTCORR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTCORRC      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTCORRC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NUM-APO-MAN  PIC S9(013)                COMP-3*/
        public IntBasis V1PROP_NUM_APO_MAN { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PROP-TPCOSCED     PIC  X(001).*/
        public StringBasis V1PROP_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-QTCOSSGC     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTCOSSGC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTCOSSEG     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTITENSI     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTITENSI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTITENS      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-TPMOVTO      PIC  X(001).*/
        public StringBasis V1PROP_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-DTENTRAD     PIC  X(010).*/
        public StringBasis V1PROP_DTENTRAD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTCADAST     PIC  X(010).*/
        public StringBasis V1PROP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-TIPCALC      PIC  X(001).*/
        public StringBasis V1PROP_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-LIMIND       PIC S9(004)                COMP.*/
        public IntBasis V1PROP_LIMIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-CDACEITA     PIC  X(001).*/
        public StringBasis V1PROP_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NRAUTACE     PIC S9(009)                COMP.*/
        public IntBasis V1PROP_NRAUTACE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-PCDESCON     PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1PROP_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PROP-IDRCAP       PIC  X(001).*/
        public StringBasis V1PROP_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-CODTXT       PIC  X(003).*/
        public StringBasis V1PROP_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1PROP-NUM-RENOV    PIC S9(009)                COMP.*/
        public IntBasis V1PROP_NUM_RENOV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-CONV-COBR    PIC  X(001).*/
        public StringBasis V1PROP_CONV_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-OCORR-END    PIC S9(004)                COMP.*/
        public IntBasis V1PROP_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V1PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-COD-USUAR    PIC  X(008).*/
        public StringBasis V1PROP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1PROP-NUM-ATA      PIC S9(009)                COMP.*/
        public IntBasis V1PROP_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-ANO-ATA      PIC S9(004)                COMP.*/
        public IntBasis V1PROP_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-DATA-SORT    PIC  X(010).*/
        public StringBasis V1PROP_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTLIBER      PIC  X(010).*/
        public StringBasis V1PROP_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTAPOLM      PIC  X(010).*/
        public StringBasis V1PROP_DTAPOLM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DATARCAP     PIC  X(010).*/
        public StringBasis V1PROP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1PROP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-CODPRODU     PIC S9(004)                COMP.*/
        public IntBasis V1PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-INSPETOR     PIC S9(009)                COMP.*/
        public IntBasis V1PROP_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-CANALPROD    PIC S9(009)                COMP.*/
        public IntBasis V1PROP_CANALPROD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-DTVENCTO     PIC  X(010).*/
        public StringBasis V1PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-CFPREFIX     PIC S9(004)V9(5)           COMP-3*/
        public DoubleBasis V1PROP_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1PROP-TIPO-ENDOS   PIC  X(001).*/
        public StringBasis V1PROP_TIPO_ENDOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NUM-APOLICE  PIC S9(013)                COMP-3*/
        public IntBasis V1PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PROP-VLCUSEMI     PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1PROP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1PROP-CODEMPR      PIC S9(009)                COMP.*/
        public IntBasis V1PROP_CODEMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1PCOR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-NRPROPOS     PIC S9(009)                COMP.*/
        public IntBasis V1PCOR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-CODCORR      PIC S9(009)                COMP.*/
        public IntBasis V1PCOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V1PCOR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-MODALIFR     PIC S9(004)                COMP.*/
        public IntBasis V1PCOR_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-PCPARCOR     PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V1PCOR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PCOR-PCCOMCOR     PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V1PCOR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PCOR-INDCRT       PIC  X(001).*/
        public StringBasis V1PCOR_INDCRT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PCOR-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1PCOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-COD-USUARIO  PIC  X(008).*/
        public StringBasis V1PCOR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1PCCD-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1PCCD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCCD-NRPROPOS     PIC S9(009)                COMP.*/
        public IntBasis V1PCCD_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCCD-CODCOSS      PIC S9(009)                COMP.*/
        public IntBasis V1PCCD_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCCD-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V1PCCD_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCCD-PCPARTIC     PIC S9(004)V9(5)           COMP-3*/
        public DoubleBasis V1PCCD_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1PCCD-PCCOMCOS     PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V1PCCD_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PCCD-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1PCCD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1COBP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-NRPROPOS     PIC S9(009)                COMP.*/
        public IntBasis V1COBP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-NUM-ITEM     PIC S9(004)                COMP.*/
        public IntBasis V1COBP_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V1COBP_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-MODALIFR     PIC S9(004)                COMP.*/
        public IntBasis V1COBP_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-COD-COBER    PIC S9(004)                COMP.*/
        public IntBasis V1COBP_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-IMP-SEG-IX   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V1COBP_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBP-PRM-TAR-IX   PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V1COBP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBP-DAT-INIVIG   PIC  X(010).*/
        public StringBasis V1COBP_DAT_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-DAT-TERVIG   PIC  X(010).*/
        public StringBasis V1COBP_DAT_TERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1COBP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COSS-RAMO         PIC S9(004)                COMP.*/
        public IntBasis V1COSS_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSS-CONGENER     PIC S9(004)                COMP.*/
        public IntBasis V1COSS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSS-PCCOMCOS     PIC S9(003)V99             COMP-3*/
        public DoubleBasis V1COSS_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1COSS-PCPARTIC     PIC S9(004)V9(5)           COMP-3*/
        public DoubleBasis V1COSS_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1COSS-SITUACAO     PIC  X(001).*/
        public StringBasis V1COSS_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1COSS-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V1COSS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-CODCLIEN    PIC S9(009)                 COMP.*/
        public IntBasis V0APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUM-ITEM    PIC S9(009)                 COMP.*/
        public IntBasis V0APOL_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-MODALIDA    PIC S9(004)                 COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-ORGAO       PIC S9(004)                 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-NUM-APO-ANT PIC S9(013)                 COMP-3*/
        public IntBasis V0APOL_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUMBIL      PIC S9(015)                 COMP-3*/
        public IntBasis V0APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0APOL-TIPSGU      PIC  X(001).*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPAPO      PIC  X(001).*/
        public StringBasis V0APOL_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPCALC     PIC  X(001).*/
        public StringBasis V0APOL_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PODPUBL     PIC  X(001).*/
        public StringBasis V0APOL_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-NUM-ATA     PIC S9(009)                 COMP.*/
        public IntBasis V0APOL_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-ANO-ATA     PIC S9(004)                 COMP.*/
        public IntBasis V0APOL_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-IDEMAN      PIC  X(001).*/
        public StringBasis V0APOL_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PCDESCON    PIC S9(003)V9(02)           COMP-3*/
        public DoubleBasis V0APOL_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-PCIOCC      PIC S9(003)V9(02)           COMP-3*/
        public DoubleBasis V0APOL_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-TPCOSCED    PIC  X(001).*/
        public StringBasis V0APOL_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-QTCOSSEG    PIC S9(004)                 COMP.*/
        public IntBasis V0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-PCTCED      PIC S9(004)V9(05)           COMP-3*/
        public DoubleBasis V0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
        /*"77         V0APOL-DATA-SORT   PIC  X(010).*/
        public StringBasis V0APOL_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOL-COD-EMPRESA PIC S9(009)                 COMP.*/
        public IntBasis V0APOL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-CODPRODU    PIC S9(004)                 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-TPCORRET    PIC  X(001).*/
        public StringBasis V0APOL_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ACOR-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0ACOR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ACOR-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V0ACOR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOR-MODALIFR     PIC S9(004)                COMP.*/
        public IntBasis V0ACOR_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOR-CODCORR      PIC S9(009)                COMP.*/
        public IntBasis V0ACOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ACOR-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V0ACOR_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOR-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ACOR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACOR-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ACOR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACOR-PCPARCOR     PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V0ACOR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0ACOR-PCCOMCOR     PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V0ACOR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0ACOR-TIPCOM       PIC  X(001).*/
        public StringBasis V0ACOR_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ACOR-INDCRT       PIC  X(001).*/
        public StringBasis V0ACOR_INDCRT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ACOR-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0ACOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ACOR-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0ACOR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ACCD-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0ACCD_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ACCD-CODCOSS      PIC S9(009)                COMP.*/
        public IntBasis V0ACCD_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ACCD-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V0ACCD_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACCD-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ACCD_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACCD-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ACCD_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACCD-PCPARTIC     PIC S9(004)V9(5)           COMP-3*/
        public DoubleBasis V0ACCD_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0ACCD-PCCOMCOS     PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V0ACCD_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0ACCD-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0ACCD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-NUM-APOL    PIC S9(013)                 COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS     PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CODSUBES    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-FONTE       PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-NRPROPOS    PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-DATPRO      PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DT-LIBER    PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-NRRCAP      PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-VLRCAP      PIC S9(013)V9(02)           COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0ENDO-BCORCAP     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGERCAP     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACRCAP     PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-IDRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-BCOCOBR     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGECOBR     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACCOBR     PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CDFRACIO    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-PCENTRAD    PIC S9(003)V9(02)           COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PCADICIO    PIC S9(003)V9(02)           COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PRESTA1     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPRESTA    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTITENS     PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODTXT      PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0ENDO-CDACEITA    PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-MOEDA-IMP   PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM   PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-TIPEND      PIC  X(001).*/
        public StringBasis V0ENDO_TIPEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-COD-USUAR   PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ENDO-OCORR-END   PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DATARCAP    PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-COD-EMPRESA PIC S9(009)                 COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-ISENTA-CST  PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTVENCTO    PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CFPREFIX    PIC S9(004)V9(5)            COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0ENDO-VLCUSEMI    PIC S9(013)V9(2)            COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0ENDO-RAMO        PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODPRODU    PIC S9(004)                 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-NRENDOS      PIC S9(009)                COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-ITEM     PIC S9(009)                COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-RAMOFR       PIC S9(004)                COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-MODALIFR     PIC S9(004)                COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-COD-COBER    PIC S9(004)                COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2)           COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5)           COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PCT-COBERT   PIC S9(003)V9(2)           COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0COBA-FATOR-MULT   PIC S9(004)                COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-SITREG       PIC  X(001).*/
        public StringBasis V0COBA_SITREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APRO-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V0APRO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APRO-NRPROPOS     PIC S9(009)                COMP.*/
        public IntBasis V0APRO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APRO-OPERACAO     PIC S9(004)                COMP.*/
        public IntBasis V0APRO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APRO-DATOPR       PIC  X(010).*/
        public StringBasis V0APRO_DATOPR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APRO-HORAOPER     PIC  X(008).*/
        public StringBasis V0APRO_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0APRO-OCORHIST     PIC S9(004)                COMP.*/
        public IntBasis V0APRO_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APRO-CODUSU       PIC  X(008).*/
        public StringBasis V0APRO_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0APRO-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0APRO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APRO-DATOPR       PIC  X(010).*/
        public StringBasis V1APRO_DATOPR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1APRO-HORAOPER     PIC  X(008).*/
        public StringBasis V1APRO_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0MPRD-NUM-APOL     PIC S9(013)                COMP-3*/
        public IntBasis V0MPRD_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0MPRD-CODSUBES     PIC S9(004)                COMP.*/
        public IntBasis V0MPRD_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MPRD-CODCORR      PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODPRP       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_CODPRP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODCLB       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_CODCLB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-INSPETOR     PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-ISPRGI       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_ISPRGI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODGTE       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_CODGTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODSTE       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_CODSTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-DIRRGI       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_DIRRGI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-DIRCMC       PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_DIRCMC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-COD-EMPRESA  PIC S9(009)                COMP.*/
        public IntBasis V0MPRD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0MPRD_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01           AREA-DE-WORK.*/
        public EM0005B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0005B_AREA_DE_WORK();
        public class EM0005B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WNUMERO-APOL      PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WNUMERO_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WNUMERO-APOL.*/
            private _REDEF_EM0005B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM0005B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM0005B_FILLER_0(); _.Move(WNUMERO_APOL, _filler_0); VarBasis.RedefinePassValue(WNUMERO_APOL, _filler_0, WNUMERO_APOL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WNUMERO_APOL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WNUMERO_APOL); }
            }  //Redefines
            public class _REDEF_EM0005B_FILLER_0 : VarBasis
            {
                /*"    10       WNUM-APOL-ORG     PIC  9(003).*/
                public IntBasis WNUM_APOL_ORG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WNUM-APOL-RAM     PIC  9(002).*/
                public IntBasis WNUM_APOL_RAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WNUM-APOL-SEQ     PIC  9(008).*/
                public IntBasis WNUM_APOL_SEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WNUM-APOLICE      PIC S9(013)    VALUE +0  COMP-3.*/

                public _REDEF_EM0005B_FILLER_0()
                {
                    WNUM_APOL_ORG.ValueChanged += OnValueChanged;
                    WNUM_APOL_RAM.ValueChanged += OnValueChanged;
                    WNUM_APOL_SEQ.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         WNUM-ENDOSSO      PIC  9(006)    VALUE  ZEROS.*/
            public IntBasis WNUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         W0ACOR-NUM-APOL   PIC S9(013)    VALUE +0  COMP-3.*/
            public IntBasis W0ACOR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         W0ACOR-CODCORR    PIC S9(009)    VALUE +0  COMP.*/
            public IntBasis W0ACOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         CH-I-V0COBERAPOL  PIC  X(001)    VALUE  SPACES.*/
            public StringBasis CH_I_V0COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         CH-CORR-ANT       PIC  9(009)    VALUE 999999999.*/
            public IntBasis CH_CORR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 999999999);
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPOSTA   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1APOLCORRET PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1APOLCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1APOLCOSCED PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERAPOL  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERPROP  PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1COBERPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCORRET PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCOSCED PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1ACOMPROP   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1ACOMPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCLAU   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_EM0005B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM0005B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM0005B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM0005B_FILLER_1 : VarBasis
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
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_EM0005B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public EM0005B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new EM0005B_WDAT_REL_LIT();
            public class EM0005B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WS-TIME.*/
            }
            public EM0005B_WS_TIME WS_TIME { get; set; } = new EM0005B_WS_TIME();
            public class EM0005B_WS_TIME : VarBasis
            {
                /*"    10       WS-HH-TIME        PIC 9(02)  VALUE ZEROS.*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10       WS-MM-TIME        PIC 9(02)  VALUE ZEROS.*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10       WS-SS-TIME        PIC 9(02)  VALUE ZEROS.*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    10       WS-CC-TIME        PIC 9(02)  VALUE ZEROS.*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05         WTIME-DAY         PIC  99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"  05         WTIME-DAYR        REDEFINES      WTIME-DAY.*/
            private _REDEF_EM0005B_WTIME_DAYR _wtime_dayr { get; set; }
            public _REDEF_EM0005B_WTIME_DAYR WTIME_DAYR
            {
                get { _wtime_dayr = new _REDEF_EM0005B_WTIME_DAYR(); _.Move(WTIME_DAY, _wtime_dayr); VarBasis.RedefinePassValue(WTIME_DAY, _wtime_dayr, WTIME_DAY); _wtime_dayr.ValueChanged += () => { _.Move(_wtime_dayr, WTIME_DAY); }; return _wtime_dayr; }
                set { VarBasis.RedefinePassValue(value, _wtime_dayr, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_EM0005B_WTIME_DAYR : VarBasis
            {
                /*"    10       WTIME-HORA        PIC  X(002).*/
                public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WTIME-2PT1        PIC  X(001).*/
                public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-MINU        PIC  X(002).*/
                public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WTIME-2PT2        PIC  X(001).*/
                public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-SEGU        PIC  X(002).*/
                public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         W-APOLICE         PIC  9(15) VALUE 0.*/

                public _REDEF_EM0005B_WTIME_DAYR()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_2PT1.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_2PT2.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_APOLICE { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"  05         W-NRENDOS         PIC  9(07) VALUE 0.*/
            public IntBasis W_NRENDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"  05         W-FONTE           PIC  9(05) VALUE 0.*/
            public IntBasis W_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
            /*"  05         CH-CHAVE-ATU.*/
            public EM0005B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new EM0005B_CH_CHAVE_ATU();
            public class EM0005B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10       CH-FTE-ATU        PIC S9(004) VALUE +0.*/
                public IntBasis CH_FTE_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-NRP-ATU        PIC S9(009) VALUE +0.*/
                public IntBasis CH_NRP_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-COR-ATU        PIC S9(009) VALUE +0.*/
                public IntBasis CH_COR_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-RAM-ATU        PIC S9(004) VALUE +0.*/
                public IntBasis CH_RAM_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-MOD-ATU        PIC S9(004) VALUE +0.*/
                public IntBasis CH_MOD_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05         CH-CHAVE-ANT.*/
            }
            public EM0005B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new EM0005B_CH_CHAVE_ANT();
            public class EM0005B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10       CH-FTE-ANT        PIC S9(004) VALUE +0.*/
                public IntBasis CH_FTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-NRP-ANT        PIC S9(009) VALUE +0.*/
                public IntBasis CH_NRP_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-COR-ANT        PIC S9(009) VALUE +0.*/
                public IntBasis CH_COR_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-RAM-ANT        PIC S9(004) VALUE +0.*/
                public IntBasis CH_RAM_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-MOD-ANT        PIC S9(004) VALUE +0.*/
                public IntBasis CH_MOD_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05         CH-COBER-ATU.*/
            }
            public EM0005B_CH_COBER_ATU CH_COBER_ATU { get; set; } = new EM0005B_CH_COBER_ATU();
            public class EM0005B_CH_COBER_ATU : VarBasis
            {
                /*"    10       CH-FONT-ATU       PIC S9(004) VALUE +0.*/
                public IntBasis CH_FONT_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-PROP-ATU       PIC S9(009) VALUE +0.*/
                public IntBasis CH_PROP_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-RAMO-ATU       PIC S9(004) VALUE +0.*/
                public IntBasis CH_RAMO_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05         CH-COBER-ANT.*/
            }
            public EM0005B_CH_COBER_ANT CH_COBER_ANT { get; set; } = new EM0005B_CH_COBER_ANT();
            public class EM0005B_CH_COBER_ANT : VarBasis
            {
                /*"    10       CH-FONT-ANT       PIC S9(004) VALUE +0.*/
                public IntBasis CH_FONT_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    10       CH-PROP-ANT       PIC S9(009) VALUE +0.*/
                public IntBasis CH_PROP_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10       CH-RAMO-ANT       PIC S9(004) VALUE +0.*/
                public IntBasis CH_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05            AC-S-SISTEMAS      PIC  9(005)  VALUE ZEROS.*/
            }
            public IntBasis AC_S_SISTEMAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-SISTEMAS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_SISTEMAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-SISTEMAS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_SISTEMAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-SISTEMAS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_SISTEMAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PARAMRAM      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PARAMRAM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PARAMRAM      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PARAMRAM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PARAMRAM      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PARAMRAM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PARAMRAM      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PARAMRAM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-RAMOIND       PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_RAMOIND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-RAMOIND       PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_RAMOIND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-RAMOIND       PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_RAMOIND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-RAMOIND       PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_RAMOIND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-FONTES        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-FONTES        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-FONTES        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-FONTES        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_FONTES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PROPOSTA      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PROPOSTA      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PROPOSTA      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PROPOSTA      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-ACOMPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_ACOMPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-ACOMPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_ACOMPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-ACOMPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_ACOMPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-ACOMPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_ACOMPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-APOLCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-APOLCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-APOLCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-APOLCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-APOLCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_APOLCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-APOLCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_APOLCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-APOLCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-APOLCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_APOLCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-APOLCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-APOLCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-APOLCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-APOLCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-APOLCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-APOLCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-APOLCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-APOLCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-APOLICES      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_APOLICES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-APOLICES      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_APOLICES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-APOLICES      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLICES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-APOLICES      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_APOLICES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-COBERAPOL     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-COBERAPOL     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-COBERAPOL     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-COBERAPOL     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-COBERPROP     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_COBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-COBERPROP     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_COBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-COBERPROP     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_COBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-COBERPROP     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_COBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-CONTPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_CONTPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-CONTPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_CONTPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-CONTPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_CONTPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-CONTPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_CONTPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-COSSEGSORT    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_COSSEGSORT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-COSSEGSORT    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_COSSEGSORT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-COSSEGSORT    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_COSSEGSORT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-COSSEGSORT    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_COSSEGSORT { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-EMISDIARIA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-EMISDIARIA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-EMISDIARIA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-EMISDIARIA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-ENDOSSOS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-ENDOSSOS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-ENDOSSOS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-ENDOSSOS      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MALHAPROD     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MALHAPROD { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-MALHAPROD     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_MALHAPROD { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MALHAPROD     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MALHAPROD { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-MALHAPROD     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_MALHAPROD { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-NUMEROAES     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_NUMEROAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-NUMEROAES     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_NUMEROAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-NUMEROAES     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_NUMEROAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-NUMEROAES     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_NUMEROAES { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PROPCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PROPCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PROPCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PROPCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PROPCORRET    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PROPCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PROPCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PROPCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PROPCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PROPCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PROPCOSCED    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PROPCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MOEDAS        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MOEDAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-MOEDAS        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_MOEDAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MOEDAS        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MOEDAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-MOEDAS        PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_MOEDAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PROPACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PROPACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PROPACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PROPACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PROPACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PROPACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-APOLACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_APOLACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-APOLACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_APOLACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-APOLACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_APOLACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-APOLACESS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_APOLACESS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-AUTOPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-AUTOPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-AUTOPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-AUTOPROP      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-AUTOCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-AUTOCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-AUTOCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-AUTOCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-AUTOCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-AUTOCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-AUTOCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-AUTOCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-AUTOTARIFP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-AUTOTARIFP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-AUTOTARIFP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-AUTOTARIFP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-AUTOTARIFA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-AUTOTARIFA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-AUTOTARIFA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-AUTOTARIFA    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PROPCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PROPCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PROPCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PROPCLAU      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-PROPCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_PROPCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-PROPCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_PROPCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-PROPCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_PROPCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-PROPCLAUS     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_PROPCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-AUTOAPOL      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-AUTOAPOL      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-AUTOAPOL      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-AUTOAPOL      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTRBENSPROP  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTRBENSPROP  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTRBENSPROP  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTRBENSPROP  PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTROSBENS    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTROSBENS    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTROSBENS    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTROSBENS    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-BENSCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-BENSCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-BENSCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-BENSCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-BENSCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-BENSCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-BENSCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-BENSCOBER     PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTROSPROP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTROSPROP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTROSPROP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTROSPROP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTROSAPOL    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTROSAPOL    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTROSAPOL    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTROSAPOL    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTRCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTRCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTRCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTRCOBERPROP PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTROSCOBER   PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTROSCOBER   PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTROSCOBER   PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTROSCOBER   PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-OUTRCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-U-OUTRCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_U_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-OUTRCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-D-OUTRCOBERP    PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_D_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MRPROITE      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MRPROITE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MRAPOITE      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MRAPOITE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MR023         PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MR023 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MR021         PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MR021 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MR017         PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MR017 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MR022         PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MR022 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MR026         PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MR026 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MR027         PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MR027 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MRPROCOR      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MRPROCOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MRAPOCOR      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MRAPOCOR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-S-MRPROBEN      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_S_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            AC-I-MRPROBEN      PIC  9(005)  VALUE ZEROS.*/
            public IntBasis AC_I_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05            WWORK-SELECT    PIC  ZZZZZ.*/
            public StringBasis WWORK_SELECT { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            WWORK-UPDATE    PIC  ZZZZZ.*/
            public StringBasis WWORK_UPDATE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            WWORK-INSERT    PIC  ZZZZZ.*/
            public StringBasis WWORK_INSERT { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05            WWORK-DELETE    PIC  ZZZZZ.*/
            public StringBasis WWORK_DELETE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZ."), @"");
            /*"  05        WABEND.*/
            public EM0005B_WABEND WABEND { get; set; } = new EM0005B_WABEND();
            public class EM0005B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0005B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0005B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01           W910S-CALL-EM0910S.*/
            }
        }
        public EM0005B_W910S_CALL_EM0910S W910S_CALL_EM0910S { get; set; } = new EM0005B_W910S_CALL_EM0910S();
        public class EM0005B_W910S_CALL_EM0910S : VarBasis
        {
            /*"  05         W910S-FONTE         PIC S9(004)              COMP.*/
            public IntBasis W910S_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W910S-NRPROPOS      PIC S9(009)              COMP.*/
            public IntBasis W910S_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W910S-NUM-APOL      PIC S9(013)              COMP-3*/
            public IntBasis W910S_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         W910S-NRENDOS       PIC S9(009)              COMP.*/
            public IntBasis W910S_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W910S-DTMOVABE      PIC  X(010).*/
            public StringBasis W910S_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         W910S-CODCORR       PIC S9(009)              COMP.*/
            public IntBasis W910S_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W910S-RETORNO       PIC  X(070).*/
            public StringBasis W910S_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         W910S-CODPRODU      PIC S9(004)              COMP.*/
            public IntBasis W910S_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W910S-QT-PARCEL     PIC S9(004)              COMP.*/
            public IntBasis W910S_QT_PARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W910S-VL-PARCEL     PIC S9(013)V99           COMP-3*/
            public DoubleBasis W910S_VL_PARCEL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         W910S-S-PROPACESS   PIC  9(004).*/
            public IntBasis W910S_S_PROPACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-APOLACESS   PIC  9(004).*/
            public IntBasis W910S_I_APOLACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-S-PROPCLAU    PIC  9(004).*/
            public IntBasis W910S_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-APOLCLAU    PIC  9(004).*/
            public IntBasis W910S_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-S-AUTOPROP    PIC  9(004).*/
            public IntBasis W910S_S_AUTOPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-AUTOAPOL    PIC  9(004).*/
            public IntBasis W910S_I_AUTOAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-S-AUTOCOBERP  PIC  9(004).*/
            public IntBasis W910S_S_AUTOCOBERP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-AUTOCOBER   PIC  9(004).*/
            public IntBasis W910S_I_AUTOCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-S-AUTOTARIFP  PIC  9(004).*/
            public IntBasis W910S_S_AUTOTARIFP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-AUTOTARIFA  PIC  9(004).*/
            public IntBasis W910S_I_AUTOTARIFA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-S-COBERPROP   PIC  9(004).*/
            public IntBasis W910S_S_COBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-COBERAPOL   PIC  9(004).*/
            public IntBasis W910S_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W910S-I-EMISDIARIA  PIC  9(004).*/
            public IntBasis W910S_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01           W911S-CALL-EM0911S.*/
        }
        public EM0005B_W911S_CALL_EM0911S W911S_CALL_EM0911S { get; set; } = new EM0005B_W911S_CALL_EM0911S();
        public class EM0005B_W911S_CALL_EM0911S : VarBasis
        {
            /*"  05         W911S-FONTE            PIC S9(004)           COMP.*/
            public IntBasis W911S_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W911S-NRPROPOS         PIC S9(009)           COMP.*/
            public IntBasis W911S_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W911S-NUM-APOL         PIC S9(013)           COMP-3*/
            public IntBasis W911S_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         W911S-NRENDOS          PIC S9(009)           COMP.*/
            public IntBasis W911S_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W911S-DTMOVABE         PIC  X(010).*/
            public StringBasis W911S_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         W911S-CODCORR          PIC S9(009)           COMP.*/
            public IntBasis W911S_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W911S-RETORNO          PIC  X(070).*/
            public StringBasis W911S_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         W911S-CODPRODU         PIC S9(004)           COMP.*/
            public IntBasis W911S_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W911S-S-OUTRBENSPROP   PIC  9(004).*/
            public IntBasis W911S_S_OUTRBENSPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-OUTROSBENS     PIC  9(004).*/
            public IntBasis W911S_I_OUTROSBENS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-S-BENSCOBERPROP  PIC  9(004).*/
            public IntBasis W911S_S_BENSCOBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-BENSCOBER      PIC  9(004).*/
            public IntBasis W911S_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-S-OUTROSPROP     PIC  9(004).*/
            public IntBasis W911S_S_OUTROSPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-OUTROSAPOL     PIC  9(004).*/
            public IntBasis W911S_I_OUTROSAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-S-OUTRCOBERPROP  PIC  9(004).*/
            public IntBasis W911S_S_OUTRCOBERPROP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-OUTROSCOBER    PIC  9(004).*/
            public IntBasis W911S_I_OUTROSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-S-PROPCLAU       PIC  9(004).*/
            public IntBasis W911S_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-APOLCLAU       PIC  9(004).*/
            public IntBasis W911S_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-S-OUTRCOBERP     PIC  9(004).*/
            public IntBasis W911S_S_OUTRCOBERP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-COBERAPOL      PIC  9(004).*/
            public IntBasis W911S_I_COBERAPOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W911S-I-EMISDIARIA     PIC  9(004).*/
            public IntBasis W911S_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01           W912S-CALL-EM0912S.*/
        }
        public EM0005B_W912S_CALL_EM0912S W912S_CALL_EM0912S { get; set; } = new EM0005B_W912S_CALL_EM0912S();
        public class EM0005B_W912S_CALL_EM0912S : VarBasis
        {
            /*"  05         W912S-FONTE            PIC S9(004)           COMP.*/
            public IntBasis W912S_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W912S-NRPROPOS         PIC S9(009)           COMP.*/
            public IntBasis W912S_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W912S-NUM-APOL         PIC S9(013)           COMP-3*/
            public IntBasis W912S_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         W912S-NRENDOS          PIC S9(009)           COMP.*/
            public IntBasis W912S_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W912S-DTMOVABE         PIC  X(010).*/
            public StringBasis W912S_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         W912S-CODCORR          PIC S9(009)           COMP.*/
            public IntBasis W912S_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W912S-RETORNO          PIC  X(070).*/
            public StringBasis W912S_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         W912S-CODPRODU         PIC S9(004)           COMP.*/
            public IntBasis W912S_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W912S-S-MRPROITE       PIC  9(004).*/
            public IntBasis W912S_S_MRPROITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-MRAPOITE       PIC  9(004).*/
            public IntBasis W912S_I_MRAPOITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-S-MRPROCOR       PIC  9(004).*/
            public IntBasis W912S_S_MRPROCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-MRAPOCOR       PIC  9(004).*/
            public IntBasis W912S_I_MRAPOCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-S-MRPROBEN       PIC  9(004).*/
            public IntBasis W912S_S_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-MRPROBEN       PIC  9(004).*/
            public IntBasis W912S_I_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-S-BENSCOBER      PIC  9(004).*/
            public IntBasis W912S_S_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-BENSCOBER      PIC  9(004).*/
            public IntBasis W912S_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-S-PROPCLAU       PIC  9(004).*/
            public IntBasis W912S_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-APOLCLAU       PIC  9(004).*/
            public IntBasis W912S_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-S-PROPCOBER      PIC  9(004).*/
            public IntBasis W912S_S_PROPCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-APOLCOBER      PIC  9(004).*/
            public IntBasis W912S_I_APOLCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W912S-I-EMISDIARIA     PIC  9(004).*/
            public IntBasis W912S_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01           W913S-CALL-EM0913S.*/
        }
        public EM0005B_W913S_CALL_EM0913S W913S_CALL_EM0913S { get; set; } = new EM0005B_W913S_CALL_EM0913S();
        public class EM0005B_W913S_CALL_EM0913S : VarBasis
        {
            /*"  05         W913S-FONTE            PIC S9(004)           COMP.*/
            public IntBasis W913S_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W913S-NRPROPOS         PIC S9(009)           COMP.*/
            public IntBasis W913S_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W913S-NUM-APOL         PIC S9(013)           COMP-3*/
            public IntBasis W913S_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         W913S-NRENDOS          PIC S9(009)           COMP.*/
            public IntBasis W913S_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W913S-DTMOVABE         PIC  X(010).*/
            public StringBasis W913S_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         W913S-CODCORR          PIC S9(009)           COMP.*/
            public IntBasis W913S_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W913S-RETORNO          PIC  X(070).*/
            public StringBasis W913S_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         W913S-CODPRODU         PIC S9(004)           COMP.*/
            public IntBasis W913S_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W913S-S-MRPROITE       PIC  9(004).*/
            public IntBasis W913S_S_MRPROITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-MRAPOITE       PIC  9(004).*/
            public IntBasis W913S_I_MRAPOITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-S-MR023          PIC  9(004).*/
            public IntBasis W913S_S_MR023 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-MR021          PIC  9(004).*/
            public IntBasis W913S_I_MR021 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-S-MRPROCOR       PIC  9(004).*/
            public IntBasis W913S_S_MRPROCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-MRAPOCOR       PIC  9(004).*/
            public IntBasis W913S_I_MRAPOCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-S-MRPROBEN       PIC  9(004).*/
            public IntBasis W913S_S_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-MRPROBEN       PIC  9(004).*/
            public IntBasis W913S_I_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-S-BENSCOBER      PIC  9(004).*/
            public IntBasis W913S_S_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-BENSCOBER      PIC  9(004).*/
            public IntBasis W913S_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-S-PROPCLAU       PIC  9(004).*/
            public IntBasis W913S_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-APOLCLAU       PIC  9(004).*/
            public IntBasis W913S_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-S-PROPCOBER      PIC  9(004).*/
            public IntBasis W913S_S_PROPCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-APOLCOBER      PIC  9(004).*/
            public IntBasis W913S_I_APOLCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W913S-I-EMISDIARIA     PIC  9(004).*/
            public IntBasis W913S_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"01           W914S-CALL-EM0913S.*/
        }
        public EM0005B_W914S_CALL_EM0913S W914S_CALL_EM0913S { get; set; } = new EM0005B_W914S_CALL_EM0913S();
        public class EM0005B_W914S_CALL_EM0913S : VarBasis
        {
            /*"  05         W914S-FONTE            PIC S9(004)           COMP.*/
            public IntBasis W914S_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W914S-NRPROPOS         PIC S9(009)           COMP.*/
            public IntBasis W914S_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W914S-NUM-APOL         PIC S9(013)           COMP-3*/
            public IntBasis W914S_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         W914S-NRENDOS          PIC S9(009)           COMP.*/
            public IntBasis W914S_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W914S-DTMOVABE         PIC  X(010).*/
            public StringBasis W914S_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         W914S-CODCORR          PIC S9(009)           COMP.*/
            public IntBasis W914S_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         W914S-RETORNO          PIC  X(070).*/
            public StringBasis W914S_RETORNO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"  05         W914S-CODPRODU         PIC S9(004)           COMP.*/
            public IntBasis W914S_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         W914S-S-MRPROITE       PIC  9(004).*/
            public IntBasis W914S_S_MRPROITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-MRAPOITE       PIC  9(004).*/
            public IntBasis W914S_I_MRAPOITE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-MR017          PIC  9(004).*/
            public IntBasis W914S_S_MR017 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-MR022          PIC  9(004).*/
            public IntBasis W914S_I_MR022 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-MR026          PIC  9(004).*/
            public IntBasis W914S_S_MR026 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-MR027          PIC  9(004).*/
            public IntBasis W914S_I_MR027 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-MRPROCOR       PIC  9(004).*/
            public IntBasis W914S_S_MRPROCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-MRAPOCOR       PIC  9(004).*/
            public IntBasis W914S_I_MRAPOCOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-MRPROBEN       PIC  9(004).*/
            public IntBasis W914S_S_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-MRPROBEN       PIC  9(004).*/
            public IntBasis W914S_I_MRPROBEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-BENSCOBER      PIC  9(004).*/
            public IntBasis W914S_S_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-BENSCOBER      PIC  9(004).*/
            public IntBasis W914S_I_BENSCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-PROPCLAU       PIC  9(004).*/
            public IntBasis W914S_S_PROPCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-APOLCLAU       PIC  9(004).*/
            public IntBasis W914S_I_APOLCLAU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-S-PROPCOBER      PIC  9(004).*/
            public IntBasis W914S_S_PROPCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-APOLCOBER      PIC  9(004).*/
            public IntBasis W914S_I_APOLCOBER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         W914S-I-EMISDIARIA     PIC  9(004).*/
            public IntBasis W914S_I_EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
        }


        public Copies.LBCS0701 LBCS0701 { get; set; } = new Copies.LBCS0701();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.AU085 AU085 { get; set; } = new Dclgens.AU085();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public EM0005B_V1PROPOSTA V1PROPOSTA { get; set; } = new EM0005B_V1PROPOSTA();
        public EM0005B_V1PROPCORRET V1PROPCORRET { get; set; } = new EM0005B_V1PROPCORRET();
        public EM0005B_V1PROPCOSCED V1PROPCOSCED { get; set; } = new EM0005B_V1PROPCOSCED();
        public EM0005B_V1COBERPROP V1COBERPROP { get; set; } = new EM0005B_V1COBERPROP();
        public EM0005B_V1COSSEGSORT V1COSSEGSORT { get; set; } = new EM0005B_V1COSSEGSORT();
        public EM0005B_V1ACOMPROP V1ACOMPROP { get; set; } = new EM0005B_V1ACOMPROP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -1030- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -1031- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -1034- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -1037- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -1037- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -1047- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -1048- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -1050- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1052- PERFORM R0130-00-SELECT-CONGENERE. */

            R0130_00_SELECT_CONGENERE_SECTION();

            /*" -1054- PERFORM R0900-00-DECLARE-V1PROPOSTA */

            R0900_00_DECLARE_V1PROPOSTA_SECTION();

            /*" -1055- PERFORM R0910-00-FETCH-V1PROPOSTA */

            R0910_00_FETCH_V1PROPOSTA_SECTION();

            /*" -1056- IF WFIM-V1PROPOSTA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPOSTA.IsEmpty())
            {

                /*" -1057- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -1059- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -1063- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V1PROPOSTA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PROPOSTA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1063- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1067- PERFORM R9500-00-DISPLAY-CONTROLE. */

            R9500_00_DISPLAY_CONTROLE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1073- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1073- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1086- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1091- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1094- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1095- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1096- DISPLAY 'EM0005B - SISTEMA DE EMISSAO NAO CADASTRADO' */
                    _.Display($"EM0005B - SISTEMA DE EMISSAO NAO CADASTRADO");

                    /*" -1097- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -1098- GO TO R0100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                    return;

                    /*" -1099- ELSE */
                }
                else
                {


                    /*" -1100- DISPLAY 'EM0005B - R0100 (ERRO SELECT V1SISTEMA)' */
                    _.Display($"EM0005B - R0100 (ERRO SELECT V1SISTEMA)");

                    /*" -1102- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1102- ADD 1 TO AC-S-SISTEMAS. */
            AREA_DE_WORK.AC_S_SISTEMAS.Value = AREA_DE_WORK.AC_S_SISTEMAS + 1;

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1091- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-SELECT-CONGENERE-SECTION */
        private void R0130_00_SELECT_CONGENERE_SECTION()
        {
            /*" -1112- MOVE 'R0130' TO WNR-EXEC-SQL. */
            _.Move("R0130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1113- MOVE '02' TO CS0701S-OPERACAO */
            _.Move("02", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO);

            /*" -1114- MOVE 1 TO CS0701S-COD-PARAM */
            _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM);

            /*" -1115- MOVE 'AUTO' TO CS0701S-CLASSE-PARAM */
            _.Move("AUTO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_CLASSE_PARAM);

            /*" -1116- MOVE 'AU' TO CS0701S-COD-SISTEMA */
            _.Move("AU", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_SISTEMA);

            /*" -1117- MOVE 0 TO CS0701S-COD-PRODUTO */
            _.Move(0, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PRODUTO);

            /*" -1119- MOVE V1SIST-DTMOVABE TO CS0701S-DATA-INIVIGENCIA */
            _.Move(V1SIST_DTMOVABE, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA);

            /*" -1121- CALL 'CS0701S' USING CS0701S-AREA-PARAMETROS */
            _.Call("CS0701S", LBCS0701.CS0701S_AREA_PARAMETROS);

            /*" -1123- IF CS0701S-COD-RETORNO > 0 OR CS0701S-TB-VALOR-INT(1) = 0 */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO > 0 || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[1].CS0701S_TB_VALOR_INT == 0)
            {

                /*" -1124- DISPLAY ' COD=' CS0701S-COD-RETORNO */
                _.Display($" COD={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO}");

                /*" -1125- DISPLAY ' MSG=' CS0701S-MSG-RETORNO */
                _.Display($" MSG={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO}");

                /*" -1126- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1128- END-IF */
            }


            /*" -1129- MOVE CS0701S-TB-VALOR-INT(1) TO WS-COD-CONGENERE */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[1].CS0701S_TB_VALOR_INT, WS_COD_CONGENERE);

            /*" -1130- DISPLAY 'R0130-00-COD-CONGENERE:' WS-COD-CONGENERE */
            _.Display($"R0130-00-COD-CONGENERE:{WS_COD_CONGENERE}");

            /*" -1130- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1PROPOSTA-SECTION */
        private void R0900_00_DECLARE_V1PROPOSTA_SECTION()
        {
            /*" -1139- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1213- PERFORM R0900_00_DECLARE_V1PROPOSTA_DB_DECLARE_1 */

            R0900_00_DECLARE_V1PROPOSTA_DB_DECLARE_1();

            /*" -1215- PERFORM R0900_00_DECLARE_V1PROPOSTA_DB_OPEN_1 */

            R0900_00_DECLARE_V1PROPOSTA_DB_OPEN_1();

            /*" -1218- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1219- DISPLAY 'EM0005B - ERRO DECLARE V1PROPOSTA' */
                _.Display($"EM0005B - ERRO DECLARE V1PROPOSTA");

                /*" -1219- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PROPOSTA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1PROPOSTA_DB_DECLARE_1()
        {
            /*" -1213- EXEC SQL DECLARE V1PROPOSTA CURSOR FOR SELECT TPPROPOS , FONTE , NRPROPOS , RAMO , MODALIDA , NUM_APOL_ANTERIOR , TIPAPO , CODCLIEN , DTINIVIG , DTTERVIG , PODPUBL , CORRECAO , COD_MOEDA_IMP , COD_MOEDA_PRM , PRESTA1 , BCORCAP , AGERCAP , NRRCAP , VLRCAP , CDFRACIO , QTPARCEL , PCENTRAD , PCADICIO , IDIOF , ISENTA_CUSTO , QTPRESTA , BCOCOBR , AGECOBR , TPCORRET , NRAUTCOR , QTCORR , QTCORRC , NUM_APOL_MANUAL , TPCOSCED , QTCOSSGC , QTCOSSEG , QTITENSI , QTITENS , TPMOVTO , DTENTRAD , DTCADAST , TIPCALC , LIMIND , CDACEITA , NRAUTACE , PCDESCON , IDRCAP , CODTXT , NUM_RENOVACAO , CONVENIO_COBRANCA , OCORR_ENDERECO , SITUACAO , COD_USUARIO , NUM_ATA , ANO_ATA , DATA_SORTEIO , DTLIBER , DTAPOLM , DATARCAP , COD_EMPRESA , VALUE(CODPRODU, 0) , VALUE(INSPETOR, 0) , VALUE(CANALPROD, 0) , DTVENCTO , CFPREFIX , VALUE(TIPO_ENDOSSO, ' ' ) , VALUE(NUM_APOLICE, 0), VALUE(VLCUSEMI, 0), COD_EMPRESA FROM SEGUROS.V1PROPOSTA WHERE SITUACAO = '0' ORDER BY FONTE , NRPROPOS END-EXEC. */
            V1PROPOSTA = new EM0005B_V1PROPOSTA(false);
            string GetQuery_V1PROPOSTA()
            {
                var query = @$"SELECT TPPROPOS
							, 
							FONTE
							, 
							NRPROPOS
							, 
							RAMO
							, 
							MODALIDA
							, 
							NUM_APOL_ANTERIOR
							, 
							TIPAPO
							, 
							CODCLIEN
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							PODPUBL
							, 
							CORRECAO
							, 
							COD_MOEDA_IMP
							, 
							COD_MOEDA_PRM
							, 
							PRESTA1
							, 
							BCORCAP
							, 
							AGERCAP
							, 
							NRRCAP
							, 
							VLRCAP
							, 
							CDFRACIO
							, 
							QTPARCEL
							, 
							PCENTRAD
							, 
							PCADICIO
							, 
							IDIOF
							, 
							ISENTA_CUSTO
							, 
							QTPRESTA
							, 
							BCOCOBR
							, 
							AGECOBR
							, 
							TPCORRET
							, 
							NRAUTCOR
							, 
							QTCORR
							, 
							QTCORRC
							, 
							NUM_APOL_MANUAL
							, 
							TPCOSCED
							, 
							QTCOSSGC
							, 
							QTCOSSEG
							, 
							QTITENSI
							, 
							QTITENS
							, 
							TPMOVTO
							, 
							DTENTRAD
							, 
							DTCADAST
							, 
							TIPCALC
							, 
							LIMIND
							, 
							CDACEITA
							, 
							NRAUTACE
							, 
							PCDESCON
							, 
							IDRCAP
							, 
							CODTXT
							, 
							NUM_RENOVACAO
							, 
							CONVENIO_COBRANCA
							, 
							OCORR_ENDERECO
							, 
							SITUACAO
							, 
							COD_USUARIO
							, 
							NUM_ATA
							, 
							ANO_ATA
							, 
							DATA_SORTEIO
							, 
							DTLIBER
							, 
							DTAPOLM
							, 
							DATARCAP
							, 
							COD_EMPRESA
							, 
							VALUE(CODPRODU
							, 0)
							, 
							VALUE(INSPETOR
							, 0)
							, 
							VALUE(CANALPROD
							, 0)
							, 
							DTVENCTO
							, 
							CFPREFIX
							, 
							VALUE(TIPO_ENDOSSO
							, ' ' )
							, 
							VALUE(NUM_APOLICE
							, 0)
							, 
							VALUE(VLCUSEMI
							, 0)
							, 
							COD_EMPRESA 
							FROM SEGUROS.V1PROPOSTA 
							WHERE SITUACAO = '0' 
							ORDER BY FONTE
							, 
							NRPROPOS";

                return query;
            }
            V1PROPOSTA.GetQueryEvent += GetQuery_V1PROPOSTA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1PROPOSTA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1PROPOSTA_DB_OPEN_1()
        {
            /*" -1215- EXEC SQL OPEN V1PROPOSTA END-EXEC. */

            V1PROPOSTA.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1PROPCORRET-DB-DECLARE-1 */
        public void R2100_00_DECLARE_V1PROPCORRET_DB_DECLARE_1()
        {
            /*" -1884- EXEC SQL DECLARE V1PROPCORRET CURSOR FOR SELECT FONTE , NRPROPOS , CODCORR , RAMOFR , MODALIFR , PCPARCOR , PCCOMCOR , INDCRT , COD_USUARIO FROM SEGUROS.V1PROPCORRET WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY FONTE, NRPROPOS END-EXEC. */
            V1PROPCORRET = new EM0005B_V1PROPCORRET(true);
            string GetQuery_V1PROPCORRET()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS
							, 
							CODCORR
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							PCPARCOR
							, 
							PCCOMCOR
							, 
							INDCRT
							, 
							COD_USUARIO 
							FROM SEGUROS.V1PROPCORRET 
							WHERE FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY FONTE
							, NRPROPOS";

                return query;
            }
            V1PROPCORRET.GetQueryEvent += GetQuery_V1PROPCORRET;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1PROPOSTA-SECTION */
        private void R0910_00_FETCH_V1PROPOSTA_SECTION()
        {
            /*" -1232- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1302- PERFORM R0910_00_FETCH_V1PROPOSTA_DB_FETCH_1 */

            R0910_00_FETCH_V1PROPOSTA_DB_FETCH_1();

            /*" -1305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1306- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1307- MOVE 'S' TO WFIM-V1PROPOSTA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PROPOSTA);

                    /*" -1307- PERFORM R0910_00_FETCH_V1PROPOSTA_DB_CLOSE_1 */

                    R0910_00_FETCH_V1PROPOSTA_DB_CLOSE_1();

                    /*" -1309- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1310- ELSE */
                }
                else
                {


                    /*" -1311- DISPLAY 'EM0005B - ERRO FETCH V1PROPOSTA' */
                    _.Display($"EM0005B - ERRO FETCH V1PROPOSTA");

                    /*" -1313- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1314- IF VIND-NUM-ATA LESS 0 */

            if (VIND_NUM_ATA < 0)
            {

                /*" -1316- MOVE -1 TO VIND-NUM-ATA. */
                _.Move(-1, VIND_NUM_ATA);
            }


            /*" -1317- IF VIND-ANO-ATA LESS 0 */

            if (VIND_ANO_ATA < 0)
            {

                /*" -1319- MOVE -1 TO VIND-ANO-ATA. */
                _.Move(-1, VIND_ANO_ATA);
            }


            /*" -1320- IF VIND-COD-EMP LESS 0 */

            if (VIND_COD_EMP < 0)
            {

                /*" -1322- MOVE -1 TO VIND-COD-EMP. */
                _.Move(-1, VIND_COD_EMP);
            }


            /*" -1323- IF VIND-DAT-SORT LESS 0 */

            if (VIND_DAT_SORT < 0)
            {

                /*" -1325- MOVE -1 TO VIND-DAT-SORT. */
                _.Move(-1, VIND_DAT_SORT);
            }


            /*" -1326- IF VIND-DTLIBER LESS 0 */

            if (VIND_DTLIBER < 0)
            {

                /*" -1328- MOVE -1 TO VIND-DTLIBER. */
                _.Move(-1, VIND_DTLIBER);
            }


            /*" -1329- IF VIND-DTAPOLM LESS 0 */

            if (VIND_DTAPOLM < 0)
            {

                /*" -1331- MOVE -1 TO VIND-DTAPOLM. */
                _.Move(-1, VIND_DTAPOLM);
            }


            /*" -1332- IF VIND-DAT-RCAP LESS 0 */

            if (VIND_DAT_RCAP < 0)
            {

                /*" -1334- MOVE -1 TO VIND-DAT-RCAP. */
                _.Move(-1, VIND_DAT_RCAP);
            }


            /*" -1335- IF VIND-DTVENCTO LESS 0 */

            if (VIND_DTVENCTO < 0)
            {

                /*" -1337- MOVE -1 TO VIND-DTVENCTO. */
                _.Move(-1, VIND_DTVENCTO);
            }


            /*" -1338- IF VIND-CFPREFIX LESS 0 */

            if (VIND_CFPREFIX < 0)
            {

                /*" -1340- MOVE -1 TO VIND-CFPREFIX. */
                _.Move(-1, VIND_CFPREFIX);
            }


            /*" -1341- IF VIND-VLCUSEMI LESS 0 */

            if (VIND_VLCUSEMI < 0)
            {

                /*" -1343- MOVE -1 TO VIND-VLCUSEMI. */
                _.Move(-1, VIND_VLCUSEMI);
            }


            /*" -1343- ADD 1 TO AC-S-PROPOSTA. */
            AREA_DE_WORK.AC_S_PROPOSTA.Value = AREA_DE_WORK.AC_S_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1PROPOSTA-DB-FETCH-1 */
        public void R0910_00_FETCH_V1PROPOSTA_DB_FETCH_1()
        {
            /*" -1302- EXEC SQL FETCH V1PROPOSTA INTO :V1PROP-TPPROPOS , :V1PROP-FONTE , :V1PROP-NRPROPOS , :V1PROP-RAMO , :V1PROP-MODALIDA , :V1PROP-NUM-APO-ANT , :V1PROP-TIPAPO , :V1PROP-CODCLIEN , :V1PROP-DTINIVIG , :V1PROP-DTTERVIG , :V1PROP-PODPUBL , :V1PROP-CORRECAO , :V1PROP-MOEDA-IMP , :V1PROP-MOEDA-PRM , :V1PROP-PRESTA1 , :V1PROP-BCORCAP , :V1PROP-AGERCAP , :V1PROP-NRRCAP , :V1PROP-VLRCAP , :V1PROP-CDFRACIO , :V1PROP-QTPARCEL , :V1PROP-PCENTRAD , :V1PROP-PCADICIO , :V1PROP-IDIOF , :V1PROP-ISENTA-CST , :V1PROP-QTPRESTA , :V1PROP-BCOCOBR , :V1PROP-AGECOBR , :V1PROP-TPCORRET , :V1PROP-NRAUTCOR , :V1PROP-QTCORR , :V1PROP-QTCORRC , :V1PROP-NUM-APO-MAN , :V1PROP-TPCOSCED , :V1PROP-QTCOSSGC , :V1PROP-QTCOSSEG , :V1PROP-QTITENSI , :V1PROP-QTITENS , :V1PROP-TPMOVTO , :V1PROP-DTENTRAD , :V1PROP-DTCADAST , :V1PROP-TIPCALC , :V1PROP-LIMIND , :V1PROP-CDACEITA , :V1PROP-NRAUTACE , :V1PROP-PCDESCON , :V1PROP-IDRCAP , :V1PROP-CODTXT , :V1PROP-NUM-RENOV , :V1PROP-CONV-COBR , :V1PROP-OCORR-END , :V1PROP-SITUACAO , :V1PROP-COD-USUAR , :V1PROP-NUM-ATA:VIND-NUM-ATA , :V1PROP-ANO-ATA:VIND-ANO-ATA , :V1PROP-DATA-SORT:VIND-DAT-SORT , :V1PROP-DTLIBER:VIND-DTLIBER , :V1PROP-DTAPOLM:VIND-DTAPOLM , :V1PROP-DATARCAP:VIND-DAT-RCAP , :V1PROP-COD-EMPRESA:VIND-COD-EMP , :V1PROP-CODPRODU , :V1PROP-INSPETOR , :V1PROP-CANALPROD , :V1PROP-DTVENCTO:VIND-DTVENCTO , :V1PROP-CFPREFIX:VIND-CFPREFIX , :V1PROP-TIPO-ENDOS , :V1PROP-NUM-APOLICE, :V1PROP-VLCUSEMI:VIND-VLCUSEMI, :V1PROP-CODEMPR END-EXEC. */

            if (V1PROPOSTA.Fetch())
            {
                _.Move(V1PROPOSTA.V1PROP_TPPROPOS, V1PROP_TPPROPOS);
                _.Move(V1PROPOSTA.V1PROP_FONTE, V1PROP_FONTE);
                _.Move(V1PROPOSTA.V1PROP_NRPROPOS, V1PROP_NRPROPOS);
                _.Move(V1PROPOSTA.V1PROP_RAMO, V1PROP_RAMO);
                _.Move(V1PROPOSTA.V1PROP_MODALIDA, V1PROP_MODALIDA);
                _.Move(V1PROPOSTA.V1PROP_NUM_APO_ANT, V1PROP_NUM_APO_ANT);
                _.Move(V1PROPOSTA.V1PROP_TIPAPO, V1PROP_TIPAPO);
                _.Move(V1PROPOSTA.V1PROP_CODCLIEN, V1PROP_CODCLIEN);
                _.Move(V1PROPOSTA.V1PROP_DTINIVIG, V1PROP_DTINIVIG);
                _.Move(V1PROPOSTA.V1PROP_DTTERVIG, V1PROP_DTTERVIG);
                _.Move(V1PROPOSTA.V1PROP_PODPUBL, V1PROP_PODPUBL);
                _.Move(V1PROPOSTA.V1PROP_CORRECAO, V1PROP_CORRECAO);
                _.Move(V1PROPOSTA.V1PROP_MOEDA_IMP, V1PROP_MOEDA_IMP);
                _.Move(V1PROPOSTA.V1PROP_MOEDA_PRM, V1PROP_MOEDA_PRM);
                _.Move(V1PROPOSTA.V1PROP_PRESTA1, V1PROP_PRESTA1);
                _.Move(V1PROPOSTA.V1PROP_BCORCAP, V1PROP_BCORCAP);
                _.Move(V1PROPOSTA.V1PROP_AGERCAP, V1PROP_AGERCAP);
                _.Move(V1PROPOSTA.V1PROP_NRRCAP, V1PROP_NRRCAP);
                _.Move(V1PROPOSTA.V1PROP_VLRCAP, V1PROP_VLRCAP);
                _.Move(V1PROPOSTA.V1PROP_CDFRACIO, V1PROP_CDFRACIO);
                _.Move(V1PROPOSTA.V1PROP_QTPARCEL, V1PROP_QTPARCEL);
                _.Move(V1PROPOSTA.V1PROP_PCENTRAD, V1PROP_PCENTRAD);
                _.Move(V1PROPOSTA.V1PROP_PCADICIO, V1PROP_PCADICIO);
                _.Move(V1PROPOSTA.V1PROP_IDIOF, V1PROP_IDIOF);
                _.Move(V1PROPOSTA.V1PROP_ISENTA_CST, V1PROP_ISENTA_CST);
                _.Move(V1PROPOSTA.V1PROP_QTPRESTA, V1PROP_QTPRESTA);
                _.Move(V1PROPOSTA.V1PROP_BCOCOBR, V1PROP_BCOCOBR);
                _.Move(V1PROPOSTA.V1PROP_AGECOBR, V1PROP_AGECOBR);
                _.Move(V1PROPOSTA.V1PROP_TPCORRET, V1PROP_TPCORRET);
                _.Move(V1PROPOSTA.V1PROP_NRAUTCOR, V1PROP_NRAUTCOR);
                _.Move(V1PROPOSTA.V1PROP_QTCORR, V1PROP_QTCORR);
                _.Move(V1PROPOSTA.V1PROP_QTCORRC, V1PROP_QTCORRC);
                _.Move(V1PROPOSTA.V1PROP_NUM_APO_MAN, V1PROP_NUM_APO_MAN);
                _.Move(V1PROPOSTA.V1PROP_TPCOSCED, V1PROP_TPCOSCED);
                _.Move(V1PROPOSTA.V1PROP_QTCOSSGC, V1PROP_QTCOSSGC);
                _.Move(V1PROPOSTA.V1PROP_QTCOSSEG, V1PROP_QTCOSSEG);
                _.Move(V1PROPOSTA.V1PROP_QTITENSI, V1PROP_QTITENSI);
                _.Move(V1PROPOSTA.V1PROP_QTITENS, V1PROP_QTITENS);
                _.Move(V1PROPOSTA.V1PROP_TPMOVTO, V1PROP_TPMOVTO);
                _.Move(V1PROPOSTA.V1PROP_DTENTRAD, V1PROP_DTENTRAD);
                _.Move(V1PROPOSTA.V1PROP_DTCADAST, V1PROP_DTCADAST);
                _.Move(V1PROPOSTA.V1PROP_TIPCALC, V1PROP_TIPCALC);
                _.Move(V1PROPOSTA.V1PROP_LIMIND, V1PROP_LIMIND);
                _.Move(V1PROPOSTA.V1PROP_CDACEITA, V1PROP_CDACEITA);
                _.Move(V1PROPOSTA.V1PROP_NRAUTACE, V1PROP_NRAUTACE);
                _.Move(V1PROPOSTA.V1PROP_PCDESCON, V1PROP_PCDESCON);
                _.Move(V1PROPOSTA.V1PROP_IDRCAP, V1PROP_IDRCAP);
                _.Move(V1PROPOSTA.V1PROP_CODTXT, V1PROP_CODTXT);
                _.Move(V1PROPOSTA.V1PROP_NUM_RENOV, V1PROP_NUM_RENOV);
                _.Move(V1PROPOSTA.V1PROP_CONV_COBR, V1PROP_CONV_COBR);
                _.Move(V1PROPOSTA.V1PROP_OCORR_END, V1PROP_OCORR_END);
                _.Move(V1PROPOSTA.V1PROP_SITUACAO, V1PROP_SITUACAO);
                _.Move(V1PROPOSTA.V1PROP_COD_USUAR, V1PROP_COD_USUAR);
                _.Move(V1PROPOSTA.V1PROP_NUM_ATA, V1PROP_NUM_ATA);
                _.Move(V1PROPOSTA.VIND_NUM_ATA, VIND_NUM_ATA);
                _.Move(V1PROPOSTA.V1PROP_ANO_ATA, V1PROP_ANO_ATA);
                _.Move(V1PROPOSTA.VIND_ANO_ATA, VIND_ANO_ATA);
                _.Move(V1PROPOSTA.V1PROP_DATA_SORT, V1PROP_DATA_SORT);
                _.Move(V1PROPOSTA.VIND_DAT_SORT, VIND_DAT_SORT);
                _.Move(V1PROPOSTA.V1PROP_DTLIBER, V1PROP_DTLIBER);
                _.Move(V1PROPOSTA.VIND_DTLIBER, VIND_DTLIBER);
                _.Move(V1PROPOSTA.V1PROP_DTAPOLM, V1PROP_DTAPOLM);
                _.Move(V1PROPOSTA.VIND_DTAPOLM, VIND_DTAPOLM);
                _.Move(V1PROPOSTA.V1PROP_DATARCAP, V1PROP_DATARCAP);
                _.Move(V1PROPOSTA.VIND_DAT_RCAP, VIND_DAT_RCAP);
                _.Move(V1PROPOSTA.V1PROP_COD_EMPRESA, V1PROP_COD_EMPRESA);
                _.Move(V1PROPOSTA.VIND_COD_EMP, VIND_COD_EMP);
                _.Move(V1PROPOSTA.V1PROP_CODPRODU, V1PROP_CODPRODU);
                _.Move(V1PROPOSTA.V1PROP_INSPETOR, V1PROP_INSPETOR);
                _.Move(V1PROPOSTA.V1PROP_CANALPROD, V1PROP_CANALPROD);
                _.Move(V1PROPOSTA.V1PROP_DTVENCTO, V1PROP_DTVENCTO);
                _.Move(V1PROPOSTA.VIND_DTVENCTO, VIND_DTVENCTO);
                _.Move(V1PROPOSTA.V1PROP_CFPREFIX, V1PROP_CFPREFIX);
                _.Move(V1PROPOSTA.VIND_CFPREFIX, VIND_CFPREFIX);
                _.Move(V1PROPOSTA.V1PROP_TIPO_ENDOS, V1PROP_TIPO_ENDOS);
                _.Move(V1PROPOSTA.V1PROP_NUM_APOLICE, V1PROP_NUM_APOLICE);
                _.Move(V1PROPOSTA.V1PROP_VLCUSEMI, V1PROP_VLCUSEMI);
                _.Move(V1PROPOSTA.VIND_VLCUSEMI, VIND_VLCUSEMI);
                _.Move(V1PROPOSTA.V1PROP_CODEMPR, V1PROP_CODEMPR);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1PROPOSTA-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1PROPOSTA_DB_CLOSE_1()
        {
            /*" -1307- EXEC SQL CLOSE V1PROPOSTA END-EXEC */

            V1PROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1356- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1358- PERFORM R1200-00-SELECT-V1FONTE */

            R1200_00_SELECT_V1FONTE_SECTION();

            /*" -1360- PERFORM R1300-00-SELECT-V1RAMOIND */

            R1300_00_SELECT_V1RAMOIND_SECTION();

            /*" -1361- IF V1PROP-CODPRODU EQUAL 1803 OR 1805 */

            if (V1PROP_CODPRODU.In("1803", "1805"))
            {

                /*" -1362- IF V1PROP-TPPROPOS EQUAL '1' */

                if (V1PROP_TPPROPOS == "1")
                {

                    /*" -1365- PERFORM R4450-00-LER-LTMVPROP. */

                    R4450_00_LER_LTMVPROP_SECTION();
                }

            }


            /*" -1366- IF V1PROP-PODPUBL NOT EQUAL 'N' */

            if (V1PROP_PODPUBL != "N")
            {

                /*" -1368- PERFORM R2500-00-DECLARE-V1COSSEGSORT. */

                R2500_00_DECLARE_V1COSSEGSORT_SECTION();
            }


            /*" -1369- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -1371- PERFORM R3100-00-INSERT-V0APOLICE. */

                R3100_00_INSERT_V0APOLICE_SECTION();
            }


            /*" -1373- PERFORM R3200-00-INSERT-V0ENDOSSO. */

            R3200_00_INSERT_V0ENDOSSO_SECTION();

            /*" -1374- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -1375- MOVE 999999999 TO CH-CORR-ANT */
                _.Move(999999999, AREA_DE_WORK.CH_CORR_ANT);

                /*" -1376- MOVE ZEROS TO W1PCOR-CODCORR */
                _.Move(0, W1PCOR_CODCORR);

                /*" -1377- MOVE SPACES TO WFIM-V1PROPCORRET */
                _.Move("", AREA_DE_WORK.WFIM_V1PROPCORRET);

                /*" -1378- PERFORM R2100-00-DECLARE-V1PROPCORRET */

                R2100_00_DECLARE_V1PROPCORRET_SECTION();

                /*" -1380- PERFORM R3300-00-INSERT-V0APOLCORRET UNTIL WFIM-V1PROPCORRET NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1PROPCORRET.IsEmpty()))
                {

                    R3300_00_INSERT_V0APOLCORRET_SECTION();
                }

                /*" -1381- MOVE SPACES TO WFIM-V1PROPCOSCED */
                _.Move("", AREA_DE_WORK.WFIM_V1PROPCOSCED);

                /*" -1382- MOVE ZEROS TO W0APOL-PCTCED */
                _.Move(0, W0APOL_PCTCED);

                /*" -1384- MOVE ZEROS TO W0APOL-QTCOSSEG */
                _.Move(0, W0APOL_QTCOSSEG);

                /*" -1385- IF V1PROP-PODPUBL EQUAL 'N' */

                if (V1PROP_PODPUBL == "N")
                {

                    /*" -1386- PERFORM R2200-00-DECLARE-V1PROPCOSCED */

                    R2200_00_DECLARE_V1PROPCOSCED_SECTION();

                    /*" -1388- PERFORM R3400-00-INSERT-V0APOLCOSCED UNTIL WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                    while (!(!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty()))
                    {

                        R3400_00_INSERT_V0APOLCOSCED_SECTION();
                    }

                    /*" -1389- PERFORM R4300-00-UPDATE-V0APOLICE */

                    R4300_00_UPDATE_V0APOLICE_SECTION();

                    /*" -1390- ELSE */
                }
                else
                {


                    /*" -1392- PERFORM R3400-00-INSERT-V0APOLCOSCED UNTIL WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                    while (!(!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty()))
                    {

                        R3400_00_INSERT_V0APOLCOSCED_SECTION();
                    }

                    /*" -1398- PERFORM R4300-00-UPDATE-V0APOLICE. */

                    R4300_00_UPDATE_V0APOLICE_SECTION();
                }

            }


            /*" -1399- IF V1PROP-CODPRODU EQUAL 1803 OR 1805 */

            if (V1PROP_CODPRODU.In("1803", "1805"))
            {

                /*" -1400- PERFORM R6000-00-TRATA-APOLCORRET */

                R6000_00_TRATA_APOLCORRET_SECTION();

                /*" -1406- END-IF. */
            }


            /*" -1407- IF V1PROP-TPPROPOS NOT EQUAL '1' AND '9' */

            if (!V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -1409- PERFORM R4310-00-UPDATE-V0APOLICE. */

                R4310_00_UPDATE_V0APOLICE_SECTION();
            }


            /*" -1410- IF (V1PROP-RAMO EQUAL 31 OR 53) */

            if ((V1PROP_RAMO.In("31", "53")))
            {

                /*" -1412- PERFORM R2250-00-SELECT-V1COBERPROP. */

                R2250_00_SELECT_V1COBERPROP_SECTION();
            }


            /*" -1415- IF ((V1PROP-RAMO EQUAL 31 OR 53) AND (W1COBP-NUM-ITEM NOT EQUAL ZEROS)) NEXT SENTENCE */

            if (((V1PROP_RAMO.In("31", "53")) && (W1COBP_NUM_ITEM != 00)))
            {

                /*" -1416- ELSE */
            }
            else
            {


                /*" -1418- IF V1PROP-CODPRODU EQUAL 1403 OR 1404 NEXT SENTENCE */

                if (V1PROP_CODPRODU.In("1403", "1404"))
                {

                    /*" -1419- ELSE */
                }
                else
                {


                    /*" -1424- IF ((V1PROP-CODPRODU EQUAL 1601 AND V1PROP-CODEMPR EQUAL 5495) OR (V1PROP-CODPRODU EQUAL 1602 AND V1PROP-CODEMPR EQUAL 0)) NEXT SENTENCE */

                    if (((V1PROP_CODPRODU == 1601 && V1PROP_CODEMPR == 5495) || (V1PROP_CODPRODU == 1602 && V1PROP_CODEMPR == 0)))
                    {

                        /*" -1425- ELSE */
                    }
                    else
                    {


                        /*" -1432- IF ((V1PROP-CODPRODU EQUAL 1801 AND V1PROP-CODEMPR EQUAL 5495) OR (V1PROP-CODPRODU EQUAL 1802 AND V1PROP-CODEMPR EQUAL 0) OR (V1PROP-CODPRODU EQUAL 1804 AND V1PROP-CODEMPR EQUAL 0)) NEXT SENTENCE */

                        if (((V1PROP_CODPRODU == 1801 && V1PROP_CODEMPR == 5495) || (V1PROP_CODPRODU == 1802 && V1PROP_CODEMPR == 0) || (V1PROP_CODPRODU == 1804 && V1PROP_CODEMPR == 0)))
                        {

                            /*" -1433- ELSE */
                        }
                        else
                        {


                            /*" -1434- MOVE ZEROS TO W1COBP-PRM-TAR-VR */
                            _.Move(0, W1COBP_PRM_TAR_VR);

                            /*" -1435- PERFORM R2300-00-SELECT-V1COBERPROP */

                            R2300_00_SELECT_V1COBERPROP_SECTION();

                            /*" -1436- MOVE ZEROS TO W1COBP-PCT-TOTAL */
                            _.Move(0, W1COBP_PCT_TOTAL);

                            /*" -1437- MOVE SPACES TO WFIM-V1COBERPROP */
                            _.Move("", AREA_DE_WORK.WFIM_V1COBERPROP);

                            /*" -1438- MOVE SPACES TO CH-I-V0COBERAPOL */
                            _.Move("", AREA_DE_WORK.CH_I_V0COBERAPOL);

                            /*" -1439- PERFORM R2400-00-DECLARE-V1COBERPROP */

                            R2400_00_DECLARE_V1COBERPROP_SECTION();

                            /*" -1440- PERFORM R3510-00-FETCH-V1COBERPROP */

                            R3510_00_FETCH_V1COBERPROP_SECTION();

                            /*" -1442- IF WFIM-V1COBERPROP NOT EQUAL SPACES NEXT SENTENCE */

                            if (!AREA_DE_WORK.WFIM_V1COBERPROP.IsEmpty())
                            {

                                /*" -1443- ELSE */
                            }
                            else
                            {


                                /*" -1445- PERFORM R3500-00-INSERT-V0COBERAPOL UNTIL WFIM-V1COBERPROP NOT EQUAL SPACES */

                                while (!(!AREA_DE_WORK.WFIM_V1COBERPROP.IsEmpty()))
                                {

                                    R3500_00_INSERT_V0COBERAPOL_SECTION();
                                }

                                /*" -1446- IF CH-I-V0COBERAPOL NOT EQUAL SPACES */

                                if (!AREA_DE_WORK.CH_I_V0COBERAPOL.IsEmpty())
                                {

                                    /*" -1448- PERFORM R4400-00-UPDATE-V0COBERAPOL. */

                                    R4400_00_UPDATE_V0COBERAPOL_SECTION();
                                }

                            }

                        }

                    }

                }

            }


            /*" -1450- PERFORM R3600-00-INSERT-V0ACOMPROP */

            R3600_00_INSERT_V0ACOMPROP_SECTION();

            /*" -1452- PERFORM R4100-00-UPDATE-V0PROPOSTA */

            R4100_00_UPDATE_V0PROPOSTA_SECTION();

            /*" -1456- PERFORM R4200-00-UPDATE-V0CONTPROP */

            R4200_00_UPDATE_V0CONTPROP_SECTION();

            /*" -1457- IF V1PROP-CODPRODU EQUAL 1803 OR 1805 */

            if (V1PROP_CODPRODU.In("1803", "1805"))
            {

                /*" -1458- IF V1PROP-TPPROPOS EQUAL '1' */

                if (V1PROP_TPPROPOS == "1")
                {

                    /*" -1459- PERFORM R4500-00-UPDATE-LTMVPROP */

                    R4500_00_UPDATE_LTMVPROP_SECTION();

                    /*" -1460- ELSE */
                }
                else
                {


                    /*" -1461- IF V1PROP-TPPROPOS EQUAL '3' */

                    if (V1PROP_TPPROPOS == "3")
                    {

                        /*" -1465- PERFORM R4550-00-UPDATE-LTMVPROP. */

                        R4550_00_UPDATE_LTMVPROP_SECTION();
                    }

                }

            }


            /*" -1466- IF V1PROP-RAMO EQUAL 31 OR 53 */

            if (V1PROP_RAMO.In("31", "53"))
            {

                /*" -1467- MOVE V1PROP-FONTE TO W910S-FONTE */
                _.Move(V1PROP_FONTE, W910S_CALL_EM0910S.W910S_FONTE);

                /*" -1468- MOVE V1PROP-NRPROPOS TO W910S-NRPROPOS */
                _.Move(V1PROP_NRPROPOS, W910S_CALL_EM0910S.W910S_NRPROPOS);

                /*" -1469- MOVE V0ENDO-NUM-APOL TO W910S-NUM-APOL */
                _.Move(V0ENDO_NUM_APOL, W910S_CALL_EM0910S.W910S_NUM_APOL);

                /*" -1470- MOVE V0ENDO-NRENDOS TO W910S-NRENDOS */
                _.Move(V0ENDO_NRENDOS, W910S_CALL_EM0910S.W910S_NRENDOS);

                /*" -1471- MOVE V1SIST-DTMOVABE TO W910S-DTMOVABE */
                _.Move(V1SIST_DTMOVABE, W910S_CALL_EM0910S.W910S_DTMOVABE);

                /*" -1472- MOVE W1PCOR-CODCORR TO W910S-CODCORR */
                _.Move(W1PCOR_CODCORR, W910S_CALL_EM0910S.W910S_CODCORR);

                /*" -1473- MOVE SPACES TO W910S-RETORNO */
                _.Move("", W910S_CALL_EM0910S.W910S_RETORNO);

                /*" -1474- MOVE V1PROP-CODPRODU TO W910S-CODPRODU */
                _.Move(V1PROP_CODPRODU, W910S_CALL_EM0910S.W910S_CODPRODU);

                /*" -1475- MOVE V1PROP-QTPARCEL TO W910S-QT-PARCEL */
                _.Move(V1PROP_QTPARCEL, W910S_CALL_EM0910S.W910S_QT_PARCEL);

                /*" -1476- MOVE V1PROP-VLRCAP TO W910S-VL-PARCEL */
                _.Move(V1PROP_VLRCAP, W910S_CALL_EM0910S.W910S_VL_PARCEL);

                /*" -1477- MOVE ZEROS TO W910S-S-PROPACESS */
                _.Move(0, W910S_CALL_EM0910S.W910S_S_PROPACESS);

                /*" -1478- MOVE ZEROS TO W910S-I-APOLACESS */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_APOLACESS);

                /*" -1479- MOVE ZEROS TO W910S-S-PROPCLAU */
                _.Move(0, W910S_CALL_EM0910S.W910S_S_PROPCLAU);

                /*" -1480- MOVE ZEROS TO W910S-I-APOLCLAU */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_APOLCLAU);

                /*" -1481- MOVE ZEROS TO W910S-S-AUTOPROP */
                _.Move(0, W910S_CALL_EM0910S.W910S_S_AUTOPROP);

                /*" -1482- MOVE ZEROS TO W910S-I-AUTOAPOL */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_AUTOAPOL);

                /*" -1483- MOVE ZEROS TO W910S-S-AUTOCOBERP */
                _.Move(0, W910S_CALL_EM0910S.W910S_S_AUTOCOBERP);

                /*" -1484- MOVE ZEROS TO W910S-I-AUTOCOBER */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_AUTOCOBER);

                /*" -1485- MOVE ZEROS TO W910S-S-AUTOTARIFP */
                _.Move(0, W910S_CALL_EM0910S.W910S_S_AUTOTARIFP);

                /*" -1486- MOVE ZEROS TO W910S-I-AUTOTARIFA */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_AUTOTARIFA);

                /*" -1487- MOVE ZEROS TO W910S-S-COBERPROP */
                _.Move(0, W910S_CALL_EM0910S.W910S_S_COBERPROP);

                /*" -1488- MOVE ZEROS TO W910S-I-COBERAPOL */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_COBERAPOL);

                /*" -1489- MOVE ZEROS TO W910S-I-EMISDIARIA */
                _.Move(0, W910S_CALL_EM0910S.W910S_I_EMISDIARIA);

                /*" -1490- CALL 'EM0910S' USING W910S-CALL-EM0910S */
                _.Call("EM0910S", W910S_CALL_EM0910S);

                /*" -1491- IF W910S-RETORNO NOT EQUAL SPACES */

                if (!W910S_CALL_EM0910S.W910S_RETORNO.IsEmpty())
                {

                    /*" -1492- DISPLAY 'CALL EM0910S - ' */
                    _.Display($"CALL EM0910S - ");

                    /*" -1493- DISPLAY 'FONTE    ' V1PROP-FONTE */
                    _.Display($"FONTE    {V1PROP_FONTE}");

                    /*" -1494- DISPLAY 'PROPOSTA ' V1PROP-NRPROPOS */
                    _.Display($"PROPOSTA {V1PROP_NRPROPOS}");

                    /*" -1495- DISPLAY 'APOLICE  ' V0ENDO-NUM-APOL */
                    _.Display($"APOLICE  {V0ENDO_NUM_APOL}");

                    /*" -1496- DISPLAY 'ENDOSSO  ' V0ENDO-NRENDOS */
                    _.Display($"ENDOSSO  {V0ENDO_NRENDOS}");

                    /*" -1497- DISPLAY 'TIPO END ' V0ENDO-TIPEND */
                    _.Display($"TIPO END {V0ENDO_TIPEND}");

                    /*" -1498- DISPLAY 'RETORNO  ' W910S-RETORNO */
                    _.Display($"RETORNO  {W910S_CALL_EM0910S.W910S_RETORNO}");

                    /*" -1499- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1500- ELSE */
                }
                else
                {


                    /*" -1501- ADD W910S-S-PROPACESS TO AC-S-PROPACESS */
                    AREA_DE_WORK.AC_S_PROPACESS.Value = AREA_DE_WORK.AC_S_PROPACESS + W910S_CALL_EM0910S.W910S_S_PROPACESS;

                    /*" -1502- ADD W910S-I-APOLACESS TO AC-I-APOLACESS */
                    AREA_DE_WORK.AC_I_APOLACESS.Value = AREA_DE_WORK.AC_I_APOLACESS + W910S_CALL_EM0910S.W910S_I_APOLACESS;

                    /*" -1503- ADD W910S-S-PROPCLAU TO AC-S-PROPCLAU */
                    AREA_DE_WORK.AC_S_PROPCLAU.Value = AREA_DE_WORK.AC_S_PROPCLAU + W910S_CALL_EM0910S.W910S_S_PROPCLAU;

                    /*" -1504- ADD W910S-I-APOLCLAU TO AC-I-APOLCLAU */
                    AREA_DE_WORK.AC_I_APOLCLAU.Value = AREA_DE_WORK.AC_I_APOLCLAU + W910S_CALL_EM0910S.W910S_I_APOLCLAU;

                    /*" -1505- ADD W910S-S-AUTOPROP TO AC-S-AUTOPROP */
                    AREA_DE_WORK.AC_S_AUTOPROP.Value = AREA_DE_WORK.AC_S_AUTOPROP + W910S_CALL_EM0910S.W910S_S_AUTOPROP;

                    /*" -1506- ADD W910S-I-AUTOAPOL TO AC-I-AUTOAPOL */
                    AREA_DE_WORK.AC_I_AUTOAPOL.Value = AREA_DE_WORK.AC_I_AUTOAPOL + W910S_CALL_EM0910S.W910S_I_AUTOAPOL;

                    /*" -1507- ADD W910S-S-AUTOCOBERP TO AC-S-AUTOCOBERP */
                    AREA_DE_WORK.AC_S_AUTOCOBERP.Value = AREA_DE_WORK.AC_S_AUTOCOBERP + W910S_CALL_EM0910S.W910S_S_AUTOCOBERP;

                    /*" -1508- ADD W910S-I-AUTOCOBER TO AC-I-AUTOCOBER */
                    AREA_DE_WORK.AC_I_AUTOCOBER.Value = AREA_DE_WORK.AC_I_AUTOCOBER + W910S_CALL_EM0910S.W910S_I_AUTOCOBER;

                    /*" -1509- ADD W910S-S-AUTOTARIFP TO AC-S-AUTOTARIFP */
                    AREA_DE_WORK.AC_S_AUTOTARIFP.Value = AREA_DE_WORK.AC_S_AUTOTARIFP + W910S_CALL_EM0910S.W910S_S_AUTOTARIFP;

                    /*" -1510- ADD W910S-I-AUTOTARIFA TO AC-I-AUTOTARIFA */
                    AREA_DE_WORK.AC_I_AUTOTARIFA.Value = AREA_DE_WORK.AC_I_AUTOTARIFA + W910S_CALL_EM0910S.W910S_I_AUTOTARIFA;

                    /*" -1511- ADD W910S-S-COBERPROP TO AC-S-COBERPROP */
                    AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + W910S_CALL_EM0910S.W910S_S_COBERPROP;

                    /*" -1512- ADD W910S-I-COBERAPOL TO AC-I-COBERAPOL */
                    AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + W910S_CALL_EM0910S.W910S_I_COBERAPOL;

                    /*" -1513- ADD W910S-I-EMISDIARIA TO AC-I-EMISDIARIA */
                    AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + W910S_CALL_EM0910S.W910S_I_EMISDIARIA;

                    /*" -1514- GO TO R1000-90-LEITURA */

                    R1000_90_LEITURA(); //GOTO
                    return;

                    /*" -1515- ELSE */
                }

            }
            else
            {


                /*" -1517- IF V1PROP-CODPRODU EQUAL 1403 OR 1404 */

                if (V1PROP_CODPRODU.In("1403", "1404"))
                {

                    /*" -1518- MOVE V1PROP-FONTE TO W912S-FONTE */
                    _.Move(V1PROP_FONTE, W912S_CALL_EM0912S.W912S_FONTE);

                    /*" -1519- MOVE V1PROP-NRPROPOS TO W912S-NRPROPOS */
                    _.Move(V1PROP_NRPROPOS, W912S_CALL_EM0912S.W912S_NRPROPOS);

                    /*" -1520- MOVE V0ENDO-NUM-APOL TO W912S-NUM-APOL */
                    _.Move(V0ENDO_NUM_APOL, W912S_CALL_EM0912S.W912S_NUM_APOL);

                    /*" -1521- MOVE V0ENDO-NRENDOS TO W912S-NRENDOS */
                    _.Move(V0ENDO_NRENDOS, W912S_CALL_EM0912S.W912S_NRENDOS);

                    /*" -1522- MOVE V1SIST-DTMOVABE TO W912S-DTMOVABE */
                    _.Move(V1SIST_DTMOVABE, W912S_CALL_EM0912S.W912S_DTMOVABE);

                    /*" -1523- MOVE W1PCOR-CODCORR TO W912S-CODCORR */
                    _.Move(W1PCOR_CODCORR, W912S_CALL_EM0912S.W912S_CODCORR);

                    /*" -1524- MOVE SPACES TO W912S-RETORNO */
                    _.Move("", W912S_CALL_EM0912S.W912S_RETORNO);

                    /*" -1525- MOVE V1PROP-CODPRODU TO W912S-CODPRODU */
                    _.Move(V1PROP_CODPRODU, W912S_CALL_EM0912S.W912S_CODPRODU);

                    /*" -1526- MOVE ZEROS TO W912S-S-MRPROITE */
                    _.Move(0, W912S_CALL_EM0912S.W912S_S_MRPROITE);

                    /*" -1527- MOVE ZEROS TO W912S-I-MRAPOITE */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_MRAPOITE);

                    /*" -1528- MOVE ZEROS TO W912S-S-MRPROCOR */
                    _.Move(0, W912S_CALL_EM0912S.W912S_S_MRPROCOR);

                    /*" -1529- MOVE ZEROS TO W912S-I-MRAPOCOR */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_MRAPOCOR);

                    /*" -1530- MOVE ZEROS TO W912S-S-MRPROBEN */
                    _.Move(0, W912S_CALL_EM0912S.W912S_S_MRPROBEN);

                    /*" -1531- MOVE ZEROS TO W912S-I-MRPROBEN */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_MRPROBEN);

                    /*" -1532- MOVE ZEROS TO W912S-S-BENSCOBER */
                    _.Move(0, W912S_CALL_EM0912S.W912S_S_BENSCOBER);

                    /*" -1533- MOVE ZEROS TO W912S-I-BENSCOBER */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_BENSCOBER);

                    /*" -1534- MOVE ZEROS TO W912S-S-PROPCLAU */
                    _.Move(0, W912S_CALL_EM0912S.W912S_S_PROPCLAU);

                    /*" -1535- MOVE ZEROS TO W912S-I-APOLCLAU */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_APOLCLAU);

                    /*" -1536- MOVE ZEROS TO W912S-S-PROPCOBER */
                    _.Move(0, W912S_CALL_EM0912S.W912S_S_PROPCOBER);

                    /*" -1537- MOVE ZEROS TO W912S-I-APOLCOBER */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_APOLCOBER);

                    /*" -1538- MOVE ZEROS TO W912S-I-EMISDIARIA */
                    _.Move(0, W912S_CALL_EM0912S.W912S_I_EMISDIARIA);

                    /*" -1539- CALL 'EM0912S' USING W912S-CALL-EM0912S */
                    _.Call("EM0912S", W912S_CALL_EM0912S);

                    /*" -1540- IF W912S-RETORNO NOT EQUAL SPACES */

                    if (!W912S_CALL_EM0912S.W912S_RETORNO.IsEmpty())
                    {

                        /*" -1541- DISPLAY 'CALL EM0912S - ' */
                        _.Display($"CALL EM0912S - ");

                        /*" -1542- DISPLAY 'FONTE    ' V1PROP-FONTE */
                        _.Display($"FONTE    {V1PROP_FONTE}");

                        /*" -1543- DISPLAY 'PROPOSTA ' V1PROP-NRPROPOS */
                        _.Display($"PROPOSTA {V1PROP_NRPROPOS}");

                        /*" -1544- DISPLAY 'APOLICE  ' V0ENDO-NUM-APOL */
                        _.Display($"APOLICE  {V0ENDO_NUM_APOL}");

                        /*" -1545- DISPLAY 'ENDOSSO  ' V0ENDO-NRENDOS */
                        _.Display($"ENDOSSO  {V0ENDO_NRENDOS}");

                        /*" -1546- DISPLAY ' ' W912S-RETORNO */
                        _.Display($" {W912S_CALL_EM0912S.W912S_RETORNO}");

                        /*" -1547- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1548- ELSE */
                    }
                    else
                    {


                        /*" -1549- ADD W912S-S-MRPROITE TO AC-S-MRPROITE */
                        AREA_DE_WORK.AC_S_MRPROITE.Value = AREA_DE_WORK.AC_S_MRPROITE + W912S_CALL_EM0912S.W912S_S_MRPROITE;

                        /*" -1550- ADD W912S-I-MRAPOITE TO AC-I-MRAPOITE */
                        AREA_DE_WORK.AC_I_MRAPOITE.Value = AREA_DE_WORK.AC_I_MRAPOITE + W912S_CALL_EM0912S.W912S_I_MRAPOITE;

                        /*" -1551- ADD W912S-S-MRPROCOR TO AC-S-MRPROCOR */
                        AREA_DE_WORK.AC_S_MRPROCOR.Value = AREA_DE_WORK.AC_S_MRPROCOR + W912S_CALL_EM0912S.W912S_S_MRPROCOR;

                        /*" -1552- ADD W912S-I-MRAPOCOR TO AC-I-MRAPOCOR */
                        AREA_DE_WORK.AC_I_MRAPOCOR.Value = AREA_DE_WORK.AC_I_MRAPOCOR + W912S_CALL_EM0912S.W912S_I_MRAPOCOR;

                        /*" -1553- ADD W912S-S-MRPROBEN TO AC-S-MRPROBEN */
                        AREA_DE_WORK.AC_S_MRPROBEN.Value = AREA_DE_WORK.AC_S_MRPROBEN + W912S_CALL_EM0912S.W912S_S_MRPROBEN;

                        /*" -1554- ADD W912S-I-MRPROBEN TO AC-I-MRPROBEN */
                        AREA_DE_WORK.AC_I_MRPROBEN.Value = AREA_DE_WORK.AC_I_MRPROBEN + W912S_CALL_EM0912S.W912S_I_MRPROBEN;

                        /*" -1555- ADD W912S-S-BENSCOBER TO AC-S-BENSCOBER */
                        AREA_DE_WORK.AC_S_BENSCOBER.Value = AREA_DE_WORK.AC_S_BENSCOBER + W912S_CALL_EM0912S.W912S_S_BENSCOBER;

                        /*" -1556- ADD W912S-I-BENSCOBER TO AC-I-BENSCOBER */
                        AREA_DE_WORK.AC_I_BENSCOBER.Value = AREA_DE_WORK.AC_I_BENSCOBER + W912S_CALL_EM0912S.W912S_I_BENSCOBER;

                        /*" -1557- ADD W912S-S-PROPCLAU TO AC-S-PROPCLAUS */
                        AREA_DE_WORK.AC_S_PROPCLAUS.Value = AREA_DE_WORK.AC_S_PROPCLAUS + W912S_CALL_EM0912S.W912S_S_PROPCLAU;

                        /*" -1558- ADD W912S-I-APOLCLAU TO AC-I-APOLCLAUS */
                        AREA_DE_WORK.AC_I_APOLCLAUS.Value = AREA_DE_WORK.AC_I_APOLCLAUS + W912S_CALL_EM0912S.W912S_I_APOLCLAU;

                        /*" -1559- ADD W912S-S-PROPCOBER TO AC-S-COBERPROP */
                        AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + W912S_CALL_EM0912S.W912S_S_PROPCOBER;

                        /*" -1560- ADD W912S-I-APOLCOBER TO AC-I-COBERAPOL */
                        AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + W912S_CALL_EM0912S.W912S_I_APOLCOBER;

                        /*" -1561- ADD W912S-I-EMISDIARIA TO AC-I-EMISDIARIA */
                        AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + W912S_CALL_EM0912S.W912S_I_EMISDIARIA;

                        /*" -1562- ELSE */
                    }

                }
                else
                {


                    /*" -1567- IF ((V1PROP-CODPRODU EQUAL 1601 AND V1PROP-CODEMPR EQUAL 5495) OR (V1PROP-CODPRODU EQUAL 1602 AND V1PROP-CODEMPR EQUAL 0)) */

                    if (((V1PROP_CODPRODU == 1601 && V1PROP_CODEMPR == 5495) || (V1PROP_CODPRODU == 1602 && V1PROP_CODEMPR == 0)))
                    {

                        /*" -1568- MOVE V1PROP-FONTE TO W913S-FONTE */
                        _.Move(V1PROP_FONTE, W913S_CALL_EM0913S.W913S_FONTE);

                        /*" -1569- MOVE V1PROP-NRPROPOS TO W913S-NRPROPOS */
                        _.Move(V1PROP_NRPROPOS, W913S_CALL_EM0913S.W913S_NRPROPOS);

                        /*" -1570- MOVE V0ENDO-NUM-APOL TO W913S-NUM-APOL */
                        _.Move(V0ENDO_NUM_APOL, W913S_CALL_EM0913S.W913S_NUM_APOL);

                        /*" -1571- MOVE V0ENDO-NRENDOS TO W913S-NRENDOS */
                        _.Move(V0ENDO_NRENDOS, W913S_CALL_EM0913S.W913S_NRENDOS);

                        /*" -1572- MOVE V1SIST-DTMOVABE TO W913S-DTMOVABE */
                        _.Move(V1SIST_DTMOVABE, W913S_CALL_EM0913S.W913S_DTMOVABE);

                        /*" -1573- MOVE W1PCOR-CODCORR TO W913S-CODCORR */
                        _.Move(W1PCOR_CODCORR, W913S_CALL_EM0913S.W913S_CODCORR);

                        /*" -1574- MOVE SPACES TO W913S-RETORNO */
                        _.Move("", W913S_CALL_EM0913S.W913S_RETORNO);

                        /*" -1575- MOVE V1PROP-CODPRODU TO W913S-CODPRODU */
                        _.Move(V1PROP_CODPRODU, W913S_CALL_EM0913S.W913S_CODPRODU);

                        /*" -1576- MOVE ZEROS TO W913S-S-MRPROITE */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_MRPROITE);

                        /*" -1577- MOVE ZEROS TO W913S-I-MRAPOITE */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_MRAPOITE);

                        /*" -1578- MOVE ZEROS TO W913S-S-MR023 */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_MR023);

                        /*" -1579- MOVE ZEROS TO W913S-I-MR021 */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_MR021);

                        /*" -1580- MOVE ZEROS TO W913S-S-MRPROCOR */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_MRPROCOR);

                        /*" -1581- MOVE ZEROS TO W913S-I-MRAPOCOR */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_MRAPOCOR);

                        /*" -1582- MOVE ZEROS TO W913S-S-MRPROBEN */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_MRPROBEN);

                        /*" -1583- MOVE ZEROS TO W913S-I-MRPROBEN */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_MRPROBEN);

                        /*" -1584- MOVE ZEROS TO W913S-S-BENSCOBER */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_BENSCOBER);

                        /*" -1585- MOVE ZEROS TO W913S-I-BENSCOBER */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_BENSCOBER);

                        /*" -1586- MOVE ZEROS TO W913S-S-PROPCLAU */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_PROPCLAU);

                        /*" -1587- MOVE ZEROS TO W913S-I-APOLCLAU */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_APOLCLAU);

                        /*" -1588- MOVE ZEROS TO W913S-S-PROPCOBER */
                        _.Move(0, W913S_CALL_EM0913S.W913S_S_PROPCOBER);

                        /*" -1589- MOVE ZEROS TO W913S-I-APOLCOBER */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_APOLCOBER);

                        /*" -1590- MOVE ZEROS TO W913S-I-EMISDIARIA */
                        _.Move(0, W913S_CALL_EM0913S.W913S_I_EMISDIARIA);

                        /*" -1591- CALL 'EM0913S' USING W913S-CALL-EM0913S */
                        _.Call("EM0913S", W913S_CALL_EM0913S);

                        /*" -1592- IF W913S-RETORNO NOT EQUAL SPACES */

                        if (!W913S_CALL_EM0913S.W913S_RETORNO.IsEmpty())
                        {

                            /*" -1593- DISPLAY 'CALL EM0913S - ' */
                            _.Display($"CALL EM0913S - ");

                            /*" -1594- DISPLAY 'FONTE    ' V1PROP-FONTE */
                            _.Display($"FONTE    {V1PROP_FONTE}");

                            /*" -1595- DISPLAY 'PROPOSTA ' V1PROP-NRPROPOS */
                            _.Display($"PROPOSTA {V1PROP_NRPROPOS}");

                            /*" -1596- DISPLAY 'APOLICE  ' V0ENDO-NUM-APOL */
                            _.Display($"APOLICE  {V0ENDO_NUM_APOL}");

                            /*" -1597- DISPLAY 'ENDOSSO  ' V0ENDO-NRENDOS */
                            _.Display($"ENDOSSO  {V0ENDO_NRENDOS}");

                            /*" -1598- DISPLAY ' ' W913S-RETORNO */
                            _.Display($" {W913S_CALL_EM0913S.W913S_RETORNO}");

                            /*" -1599- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1600- ELSE */
                        }
                        else
                        {


                            /*" -1601- ADD W913S-S-MRPROITE TO AC-S-MRPROITE */
                            AREA_DE_WORK.AC_S_MRPROITE.Value = AREA_DE_WORK.AC_S_MRPROITE + W913S_CALL_EM0913S.W913S_S_MRPROITE;

                            /*" -1602- ADD W913S-I-MRAPOITE TO AC-I-MRAPOITE */
                            AREA_DE_WORK.AC_I_MRAPOITE.Value = AREA_DE_WORK.AC_I_MRAPOITE + W913S_CALL_EM0913S.W913S_I_MRAPOITE;

                            /*" -1603- ADD W913S-S-MR023 TO AC-S-MR023 */
                            AREA_DE_WORK.AC_S_MR023.Value = AREA_DE_WORK.AC_S_MR023 + W913S_CALL_EM0913S.W913S_S_MR023;

                            /*" -1604- ADD W913S-I-MR021 TO AC-I-MR021 */
                            AREA_DE_WORK.AC_I_MR021.Value = AREA_DE_WORK.AC_I_MR021 + W913S_CALL_EM0913S.W913S_I_MR021;

                            /*" -1605- ADD W913S-S-MRPROCOR TO AC-S-MRPROCOR */
                            AREA_DE_WORK.AC_S_MRPROCOR.Value = AREA_DE_WORK.AC_S_MRPROCOR + W913S_CALL_EM0913S.W913S_S_MRPROCOR;

                            /*" -1606- ADD W913S-I-MRAPOCOR TO AC-I-MRAPOCOR */
                            AREA_DE_WORK.AC_I_MRAPOCOR.Value = AREA_DE_WORK.AC_I_MRAPOCOR + W913S_CALL_EM0913S.W913S_I_MRAPOCOR;

                            /*" -1607- ADD W913S-S-MRPROBEN TO AC-S-MRPROBEN */
                            AREA_DE_WORK.AC_S_MRPROBEN.Value = AREA_DE_WORK.AC_S_MRPROBEN + W913S_CALL_EM0913S.W913S_S_MRPROBEN;

                            /*" -1608- ADD W913S-I-MRPROBEN TO AC-I-MRPROBEN */
                            AREA_DE_WORK.AC_I_MRPROBEN.Value = AREA_DE_WORK.AC_I_MRPROBEN + W913S_CALL_EM0913S.W913S_I_MRPROBEN;

                            /*" -1609- ADD W913S-S-BENSCOBER TO AC-S-BENSCOBER */
                            AREA_DE_WORK.AC_S_BENSCOBER.Value = AREA_DE_WORK.AC_S_BENSCOBER + W913S_CALL_EM0913S.W913S_S_BENSCOBER;

                            /*" -1610- ADD W913S-I-BENSCOBER TO AC-I-BENSCOBER */
                            AREA_DE_WORK.AC_I_BENSCOBER.Value = AREA_DE_WORK.AC_I_BENSCOBER + W913S_CALL_EM0913S.W913S_I_BENSCOBER;

                            /*" -1611- ADD W913S-S-PROPCLAU TO AC-S-PROPCLAUS */
                            AREA_DE_WORK.AC_S_PROPCLAUS.Value = AREA_DE_WORK.AC_S_PROPCLAUS + W913S_CALL_EM0913S.W913S_S_PROPCLAU;

                            /*" -1612- ADD W913S-I-APOLCLAU TO AC-I-APOLCLAUS */
                            AREA_DE_WORK.AC_I_APOLCLAUS.Value = AREA_DE_WORK.AC_I_APOLCLAUS + W913S_CALL_EM0913S.W913S_I_APOLCLAU;

                            /*" -1613- ADD W913S-S-PROPCOBER TO AC-S-COBERPROP */
                            AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + W913S_CALL_EM0913S.W913S_S_PROPCOBER;

                            /*" -1614- ADD W913S-I-APOLCOBER TO AC-I-COBERAPOL */
                            AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + W913S_CALL_EM0913S.W913S_I_APOLCOBER;

                            /*" -1615- ADD W913S-I-EMISDIARIA TO AC-I-EMISDIARIA */
                            AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + W913S_CALL_EM0913S.W913S_I_EMISDIARIA;

                            /*" -1616- ELSE */
                        }

                    }
                    else
                    {


                        /*" -1622- IF ((V1PROP-CODPRODU EQUAL 1801 AND V1PROP-CODEMPR EQUAL 5495) OR (V1PROP-CODPRODU EQUAL 1802 AND V1PROP-CODEMPR EQUAL 0) OR (V1PROP-CODPRODU EQUAL 1804 AND V1PROP-CODEMPR EQUAL 0)) */

                        if (((V1PROP_CODPRODU == 1801 && V1PROP_CODEMPR == 5495) || (V1PROP_CODPRODU == 1802 && V1PROP_CODEMPR == 0) || (V1PROP_CODPRODU == 1804 && V1PROP_CODEMPR == 0)))
                        {

                            /*" -1623- MOVE V1PROP-FONTE TO W914S-FONTE */
                            _.Move(V1PROP_FONTE, W914S_CALL_EM0913S.W914S_FONTE);

                            /*" -1624- MOVE V1PROP-NRPROPOS TO W914S-NRPROPOS */
                            _.Move(V1PROP_NRPROPOS, W914S_CALL_EM0913S.W914S_NRPROPOS);

                            /*" -1625- MOVE V0ENDO-NUM-APOL TO W914S-NUM-APOL */
                            _.Move(V0ENDO_NUM_APOL, W914S_CALL_EM0913S.W914S_NUM_APOL);

                            /*" -1626- MOVE V0ENDO-NRENDOS TO W914S-NRENDOS */
                            _.Move(V0ENDO_NRENDOS, W914S_CALL_EM0913S.W914S_NRENDOS);

                            /*" -1627- MOVE V1SIST-DTMOVABE TO W914S-DTMOVABE */
                            _.Move(V1SIST_DTMOVABE, W914S_CALL_EM0913S.W914S_DTMOVABE);

                            /*" -1628- MOVE W1PCOR-CODCORR TO W914S-CODCORR */
                            _.Move(W1PCOR_CODCORR, W914S_CALL_EM0913S.W914S_CODCORR);

                            /*" -1629- MOVE SPACES TO W914S-RETORNO */
                            _.Move("", W914S_CALL_EM0913S.W914S_RETORNO);

                            /*" -1630- MOVE V1PROP-CODPRODU TO W914S-CODPRODU */
                            _.Move(V1PROP_CODPRODU, W914S_CALL_EM0913S.W914S_CODPRODU);

                            /*" -1631- MOVE ZEROS TO W914S-S-MRPROITE */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_MRPROITE);

                            /*" -1632- MOVE ZEROS TO W914S-I-MRAPOITE */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_MRAPOITE);

                            /*" -1633- MOVE ZEROS TO W914S-S-MR017 */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_MR017);

                            /*" -1634- MOVE ZEROS TO W914S-I-MR022 */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_MR022);

                            /*" -1635- MOVE ZEROS TO W914S-S-MR026 */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_MR026);

                            /*" -1636- MOVE ZEROS TO W914S-I-MR027 */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_MR027);

                            /*" -1637- MOVE ZEROS TO W914S-S-MRPROCOR */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_MRPROCOR);

                            /*" -1638- MOVE ZEROS TO W914S-I-MRAPOCOR */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_MRAPOCOR);

                            /*" -1639- MOVE ZEROS TO W914S-S-MRPROBEN */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_MRPROBEN);

                            /*" -1640- MOVE ZEROS TO W914S-I-MRPROBEN */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_MRPROBEN);

                            /*" -1641- MOVE ZEROS TO W914S-S-BENSCOBER */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_BENSCOBER);

                            /*" -1642- MOVE ZEROS TO W914S-I-BENSCOBER */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_BENSCOBER);

                            /*" -1643- MOVE ZEROS TO W914S-S-PROPCLAU */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_PROPCLAU);

                            /*" -1644- MOVE ZEROS TO W914S-I-APOLCLAU */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_APOLCLAU);

                            /*" -1645- MOVE ZEROS TO W914S-S-PROPCOBER */
                            _.Move(0, W914S_CALL_EM0913S.W914S_S_PROPCOBER);

                            /*" -1646- MOVE ZEROS TO W914S-I-APOLCOBER */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_APOLCOBER);

                            /*" -1647- MOVE ZEROS TO W914S-I-EMISDIARIA */
                            _.Move(0, W914S_CALL_EM0913S.W914S_I_EMISDIARIA);

                            /*" -1648- CALL 'EM0914S' USING W914S-CALL-EM0913S */
                            _.Call("EM0914S", W914S_CALL_EM0913S);

                            /*" -1649- IF W914S-RETORNO NOT EQUAL SPACES */

                            if (!W914S_CALL_EM0913S.W914S_RETORNO.IsEmpty())
                            {

                                /*" -1650- DISPLAY 'CALL EM0914S - ' */
                                _.Display($"CALL EM0914S - ");

                                /*" -1651- DISPLAY 'FONTE    ' V1PROP-FONTE */
                                _.Display($"FONTE    {V1PROP_FONTE}");

                                /*" -1652- DISPLAY 'PROPOSTA ' V1PROP-NRPROPOS */
                                _.Display($"PROPOSTA {V1PROP_NRPROPOS}");

                                /*" -1653- DISPLAY 'APOLICE  ' V0ENDO-NUM-APOL */
                                _.Display($"APOLICE  {V0ENDO_NUM_APOL}");

                                /*" -1654- DISPLAY 'ENDOSSO  ' V0ENDO-NRENDOS */
                                _.Display($"ENDOSSO  {V0ENDO_NRENDOS}");

                                /*" -1655- DISPLAY ' ' W914S-RETORNO */
                                _.Display($" {W914S_CALL_EM0913S.W914S_RETORNO}");

                                /*" -1656- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -1657- ELSE */
                            }
                            else
                            {


                                /*" -1658- ADD W914S-S-MRPROITE TO AC-S-MRPROITE */
                                AREA_DE_WORK.AC_S_MRPROITE.Value = AREA_DE_WORK.AC_S_MRPROITE + W914S_CALL_EM0913S.W914S_S_MRPROITE;

                                /*" -1659- ADD W914S-I-MRAPOITE TO AC-I-MRAPOITE */
                                AREA_DE_WORK.AC_I_MRAPOITE.Value = AREA_DE_WORK.AC_I_MRAPOITE + W914S_CALL_EM0913S.W914S_I_MRAPOITE;

                                /*" -1660- ADD W914S-S-MR017 TO AC-S-MR017 */
                                AREA_DE_WORK.AC_S_MR017.Value = AREA_DE_WORK.AC_S_MR017 + W914S_CALL_EM0913S.W914S_S_MR017;

                                /*" -1661- ADD W914S-I-MR022 TO AC-I-MR022 */
                                AREA_DE_WORK.AC_I_MR022.Value = AREA_DE_WORK.AC_I_MR022 + W914S_CALL_EM0913S.W914S_I_MR022;

                                /*" -1662- ADD W914S-S-MR026 TO AC-S-MR026 */
                                AREA_DE_WORK.AC_S_MR026.Value = AREA_DE_WORK.AC_S_MR026 + W914S_CALL_EM0913S.W914S_S_MR026;

                                /*" -1663- ADD W914S-I-MR027 TO AC-I-MR027 */
                                AREA_DE_WORK.AC_I_MR027.Value = AREA_DE_WORK.AC_I_MR027 + W914S_CALL_EM0913S.W914S_I_MR027;

                                /*" -1664- ADD W914S-S-MRPROCOR TO AC-S-MRPROCOR */
                                AREA_DE_WORK.AC_S_MRPROCOR.Value = AREA_DE_WORK.AC_S_MRPROCOR + W914S_CALL_EM0913S.W914S_S_MRPROCOR;

                                /*" -1665- ADD W914S-I-MRAPOCOR TO AC-I-MRAPOCOR */
                                AREA_DE_WORK.AC_I_MRAPOCOR.Value = AREA_DE_WORK.AC_I_MRAPOCOR + W914S_CALL_EM0913S.W914S_I_MRAPOCOR;

                                /*" -1666- ADD W914S-S-MRPROBEN TO AC-S-MRPROBEN */
                                AREA_DE_WORK.AC_S_MRPROBEN.Value = AREA_DE_WORK.AC_S_MRPROBEN + W914S_CALL_EM0913S.W914S_S_MRPROBEN;

                                /*" -1667- ADD W914S-I-MRPROBEN TO AC-I-MRPROBEN */
                                AREA_DE_WORK.AC_I_MRPROBEN.Value = AREA_DE_WORK.AC_I_MRPROBEN + W914S_CALL_EM0913S.W914S_I_MRPROBEN;

                                /*" -1668- ADD W914S-S-BENSCOBER TO AC-S-BENSCOBER */
                                AREA_DE_WORK.AC_S_BENSCOBER.Value = AREA_DE_WORK.AC_S_BENSCOBER + W914S_CALL_EM0913S.W914S_S_BENSCOBER;

                                /*" -1669- ADD W914S-I-BENSCOBER TO AC-I-BENSCOBER */
                                AREA_DE_WORK.AC_I_BENSCOBER.Value = AREA_DE_WORK.AC_I_BENSCOBER + W914S_CALL_EM0913S.W914S_I_BENSCOBER;

                                /*" -1670- ADD W914S-S-PROPCLAU TO AC-S-PROPCLAUS */
                                AREA_DE_WORK.AC_S_PROPCLAUS.Value = AREA_DE_WORK.AC_S_PROPCLAUS + W914S_CALL_EM0913S.W914S_S_PROPCLAU;

                                /*" -1671- ADD W914S-I-APOLCLAU TO AC-I-APOLCLAUS */
                                AREA_DE_WORK.AC_I_APOLCLAUS.Value = AREA_DE_WORK.AC_I_APOLCLAUS + W914S_CALL_EM0913S.W914S_I_APOLCLAU;

                                /*" -1672- ADD W914S-S-PROPCOBER TO AC-S-COBERPROP */
                                AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + W914S_CALL_EM0913S.W914S_S_PROPCOBER;

                                /*" -1673- ADD W914S-I-APOLCOBER TO AC-I-COBERAPOL */
                                AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + W914S_CALL_EM0913S.W914S_I_APOLCOBER;

                                /*" -1674- ADD W914S-I-EMISDIARIA TO AC-I-EMISDIARIA */
                                AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + W914S_CALL_EM0913S.W914S_I_EMISDIARIA;

                                /*" -1676- ELSE */
                            }

                        }
                        else
                        {


                            /*" -1677- MOVE V1PROP-FONTE TO W911S-FONTE */
                            _.Move(V1PROP_FONTE, W911S_CALL_EM0911S.W911S_FONTE);

                            /*" -1678- MOVE V1PROP-NRPROPOS TO W911S-NRPROPOS */
                            _.Move(V1PROP_NRPROPOS, W911S_CALL_EM0911S.W911S_NRPROPOS);

                            /*" -1679- MOVE V0ENDO-NUM-APOL TO W911S-NUM-APOL */
                            _.Move(V0ENDO_NUM_APOL, W911S_CALL_EM0911S.W911S_NUM_APOL);

                            /*" -1680- MOVE V0ENDO-NRENDOS TO W911S-NRENDOS */
                            _.Move(V0ENDO_NRENDOS, W911S_CALL_EM0911S.W911S_NRENDOS);

                            /*" -1681- MOVE V1SIST-DTMOVABE TO W911S-DTMOVABE */
                            _.Move(V1SIST_DTMOVABE, W911S_CALL_EM0911S.W911S_DTMOVABE);

                            /*" -1682- MOVE W1PCOR-CODCORR TO W911S-CODCORR */
                            _.Move(W1PCOR_CODCORR, W911S_CALL_EM0911S.W911S_CODCORR);

                            /*" -1683- MOVE SPACES TO W911S-RETORNO */
                            _.Move("", W911S_CALL_EM0911S.W911S_RETORNO);

                            /*" -1684- MOVE V1PROP-CODPRODU TO W911S-CODPRODU */
                            _.Move(V1PROP_CODPRODU, W911S_CALL_EM0911S.W911S_CODPRODU);

                            /*" -1685- MOVE ZEROS TO W911S-S-OUTRBENSPROP */
                            _.Move(0, W911S_CALL_EM0911S.W911S_S_OUTRBENSPROP);

                            /*" -1686- MOVE ZEROS TO W911S-I-OUTROSBENS */
                            _.Move(0, W911S_CALL_EM0911S.W911S_I_OUTROSBENS);

                            /*" -1687- MOVE ZEROS TO W911S-S-BENSCOBERPROP */
                            _.Move(0, W911S_CALL_EM0911S.W911S_S_BENSCOBERPROP);

                            /*" -1688- MOVE ZEROS TO W911S-I-BENSCOBER */
                            _.Move(0, W911S_CALL_EM0911S.W911S_I_BENSCOBER);

                            /*" -1689- MOVE ZEROS TO W911S-S-OUTROSPROP */
                            _.Move(0, W911S_CALL_EM0911S.W911S_S_OUTROSPROP);

                            /*" -1690- MOVE ZEROS TO W911S-I-OUTROSAPOL */
                            _.Move(0, W911S_CALL_EM0911S.W911S_I_OUTROSAPOL);

                            /*" -1691- MOVE ZEROS TO W911S-S-OUTRCOBERPROP */
                            _.Move(0, W911S_CALL_EM0911S.W911S_S_OUTRCOBERPROP);

                            /*" -1692- MOVE ZEROS TO W911S-I-OUTROSCOBER */
                            _.Move(0, W911S_CALL_EM0911S.W911S_I_OUTROSCOBER);

                            /*" -1693- MOVE ZEROS TO W911S-S-OUTRCOBERP */
                            _.Move(0, W911S_CALL_EM0911S.W911S_S_OUTRCOBERP);

                            /*" -1694- MOVE ZEROS TO W911S-I-COBERAPOL */
                            _.Move(0, W911S_CALL_EM0911S.W911S_I_COBERAPOL);

                            /*" -1695- MOVE ZEROS TO W911S-I-EMISDIARIA */
                            _.Move(0, W911S_CALL_EM0911S.W911S_I_EMISDIARIA);

                            /*" -1696- CALL 'EM0911S' USING W911S-CALL-EM0911S */
                            _.Call("EM0911S", W911S_CALL_EM0911S);

                            /*" -1697- IF W911S-RETORNO NOT EQUAL SPACES */

                            if (!W911S_CALL_EM0911S.W911S_RETORNO.IsEmpty())
                            {

                                /*" -1698- DISPLAY 'CALL EM0911S - ' */
                                _.Display($"CALL EM0911S - ");

                                /*" -1699- DISPLAY 'FONTE    ' V1PROP-FONTE */
                                _.Display($"FONTE    {V1PROP_FONTE}");

                                /*" -1700- DISPLAY 'PROPOSTA ' V1PROP-NRPROPOS */
                                _.Display($"PROPOSTA {V1PROP_NRPROPOS}");

                                /*" -1701- DISPLAY 'APOLICE  ' V0ENDO-NUM-APOL */
                                _.Display($"APOLICE  {V0ENDO_NUM_APOL}");

                                /*" -1702- DISPLAY 'ENDOSSO  ' V0ENDO-NRENDOS */
                                _.Display($"ENDOSSO  {V0ENDO_NRENDOS}");

                                /*" -1703- DISPLAY ' ' W911S-RETORNO */
                                _.Display($" {W911S_CALL_EM0911S.W911S_RETORNO}");

                                /*" -1704- GO TO R9999-00-ROT-ERRO */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -1705- ELSE */
                            }
                            else
                            {


                                /*" -1706- ADD W911S-S-OUTRBENSPROP TO AC-S-OUTRBENSPROP */
                                AREA_DE_WORK.AC_S_OUTRBENSPROP.Value = AREA_DE_WORK.AC_S_OUTRBENSPROP + W911S_CALL_EM0911S.W911S_S_OUTRBENSPROP;

                                /*" -1707- ADD W911S-I-OUTROSBENS TO AC-I-OUTROSBENS */
                                AREA_DE_WORK.AC_I_OUTROSBENS.Value = AREA_DE_WORK.AC_I_OUTROSBENS + W911S_CALL_EM0911S.W911S_I_OUTROSBENS;

                                /*" -1708- ADD W911S-S-BENSCOBERPROP TO AC-S-BENSCOBERPROP */
                                AREA_DE_WORK.AC_S_BENSCOBERPROP.Value = AREA_DE_WORK.AC_S_BENSCOBERPROP + W911S_CALL_EM0911S.W911S_S_BENSCOBERPROP;

                                /*" -1709- ADD W911S-I-BENSCOBER TO AC-I-BENSCOBER */
                                AREA_DE_WORK.AC_I_BENSCOBER.Value = AREA_DE_WORK.AC_I_BENSCOBER + W911S_CALL_EM0911S.W911S_I_BENSCOBER;

                                /*" -1710- ADD W911S-S-OUTROSPROP TO AC-S-OUTROSPROP */
                                AREA_DE_WORK.AC_S_OUTROSPROP.Value = AREA_DE_WORK.AC_S_OUTROSPROP + W911S_CALL_EM0911S.W911S_S_OUTROSPROP;

                                /*" -1711- ADD W911S-I-OUTROSAPOL TO AC-I-OUTROSAPOL */
                                AREA_DE_WORK.AC_I_OUTROSAPOL.Value = AREA_DE_WORK.AC_I_OUTROSAPOL + W911S_CALL_EM0911S.W911S_I_OUTROSAPOL;

                                /*" -1712- ADD W911S-S-OUTRCOBERPROP TO AC-S-OUTRCOBERPROP */
                                AREA_DE_WORK.AC_S_OUTRCOBERPROP.Value = AREA_DE_WORK.AC_S_OUTRCOBERPROP + W911S_CALL_EM0911S.W911S_S_OUTRCOBERPROP;

                                /*" -1713- ADD W911S-I-OUTROSCOBER TO AC-I-OUTROSCOBER */
                                AREA_DE_WORK.AC_I_OUTROSCOBER.Value = AREA_DE_WORK.AC_I_OUTROSCOBER + W911S_CALL_EM0911S.W911S_I_OUTROSCOBER;

                                /*" -1714- ADD W911S-S-PROPCLAU TO AC-S-PROPCLAUS */
                                AREA_DE_WORK.AC_S_PROPCLAUS.Value = AREA_DE_WORK.AC_S_PROPCLAUS + W911S_CALL_EM0911S.W911S_S_PROPCLAU;

                                /*" -1715- ADD W911S-I-APOLCLAU TO AC-I-APOLCLAUS */
                                AREA_DE_WORK.AC_I_APOLCLAUS.Value = AREA_DE_WORK.AC_I_APOLCLAUS + W911S_CALL_EM0911S.W911S_I_APOLCLAU;

                                /*" -1716- ADD W911S-S-OUTRCOBERP TO AC-S-OUTRCOBERP */
                                AREA_DE_WORK.AC_S_OUTRCOBERP.Value = AREA_DE_WORK.AC_S_OUTRCOBERP + W911S_CALL_EM0911S.W911S_S_OUTRCOBERP;

                                /*" -1717- ADD W911S-I-COBERAPOL TO AC-I-COBERAPOL */
                                AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + W911S_CALL_EM0911S.W911S_I_COBERAPOL;

                                /*" -1717- ADD W911S-I-EMISDIARIA TO AC-I-EMISDIARIA. */
                                AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + W911S_CALL_EM0911S.W911S_I_EMISDIARIA;
                            }

                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1721- PERFORM R0910-00-FETCH-V1PROPOSTA. */

            R0910_00_FETCH_V1PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1FONTE-SECTION */
        private void R1200_00_SELECT_V1FONTE_SECTION()
        {
            /*" -1734- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1739- PERFORM R1200_00_SELECT_V1FONTE_DB_SELECT_1 */

            R1200_00_SELECT_V1FONTE_DB_SELECT_1();

            /*" -1742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1743- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1744- DISPLAY 'EM0005B - R1200 (NAO ENCONTROU FONTE)' */
                    _.Display($"EM0005B - R1200 (NAO ENCONTROU FONTE)");

                    /*" -1745- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1746- ELSE */
                }
                else
                {


                    /*" -1747- DISPLAY 'EM0005B - R1200 (ERRO SELECT V1FONTE)' */
                    _.Display($"EM0005B - R1200 (ERRO SELECT V1FONTE)");

                    /*" -1749- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1749- ADD 1 TO AC-S-FONTES. */
            AREA_DE_WORK.AC_S_FONTES.Value = AREA_DE_WORK.AC_S_FONTES + 1;

        }

        [StopWatch]
        /*" R1200-00-SELECT-V1FONTE-DB-SELECT-1 */
        public void R1200_00_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -1739- EXEC SQL SELECT ORGAOEMIS INTO :V1FONT-ORGAOEMIS FROM SEGUROS.V1FONTE WHERE FONTE = :V1PROP-FONTE END-EXEC. */

            var r1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1()
            {
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_ORGAOEMIS, V1FONT_ORGAOEMIS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V1RAMOIND-SECTION */
        private void R1300_00_SELECT_V1RAMOIND_SECTION()
        {
            /*" -1762- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1769- PERFORM R1300_00_SELECT_V1RAMOIND_DB_SELECT_1 */

            R1300_00_SELECT_V1RAMOIND_DB_SELECT_1();

            /*" -1772- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1773- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1774- DISPLAY 'EM0005B - R1300 (NAO ENCONTROU RAMOIND)' */
                    _.Display($"EM0005B - R1300 (NAO ENCONTROU RAMOIND)");

                    /*" -1775- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1776- ELSE */
                }
                else
                {


                    /*" -1777- DISPLAY 'EM0005B - R1300 (ERRO SELECT V1RAMOIND)' */
                    _.Display($"EM0005B - R1300 (ERRO SELECT V1RAMOIND)");

                    /*" -1779- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1779- ADD 1 TO AC-S-RAMOIND. */
            AREA_DE_WORK.AC_S_RAMOIND.Value = AREA_DE_WORK.AC_S_RAMOIND + 1;

        }

        [StopWatch]
        /*" R1300-00-SELECT-V1RAMOIND-DB-SELECT-1 */
        public void R1300_00_SELECT_V1RAMOIND_DB_SELECT_1()
        {
            /*" -1769- EXEC SQL SELECT PCIOF INTO :V1RAMO-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1PROP-RAMO AND DTINIVIG <= :V1PROP-DTINIVIG AND DTTERVIG >= :V1PROP-DTINIVIG END-EXEC. */

            var r1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 = new R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1()
            {
                V1PROP_DTINIVIG = V1PROP_DTINIVIG.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_PCIOF, V1RAMO_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-NUMERO-AES-SECTION */
        private void R1400_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -1792- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1810- PERFORM R1400_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R1400_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -1813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1814- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1819- DISPLAY 'R1400-00 (NAO EXISTE NA V1NUMERO-AES) ... ' ' ' V1FONT-ORGAOEMIS ' ' V1PROP-RAMO ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                    $"R1400-00 (NAO EXISTE NA V1NUMERO-AES) ...  {V1FONT_ORGAOEMIS} {V1PROP_RAMO} {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                    .Display();

                    /*" -1820- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1821- ELSE */
                }
                else
                {


                    /*" -1825- DISPLAY 'R1400-00 (ERRO SELECT V1NUMERO-AES) ... ' ' ' V1PROP-NRPROPOS ' ' V1PROP-FONTE ' ' V1PROP-RAMO */

                    $"R1400-00 (ERRO SELECT V1NUMERO-AES) ...  {V1PROP_NRPROPOS} {V1PROP_FONTE} {V1PROP_RAMO}"
                    .Display();

                    /*" -1825- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R1400_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -1810- EXEC SQL SELECT SEQ_APOLICE, ENDOSCOB , NRENDOCA , ENDOSRES , ENDOSSEM , ENDOSCCR , ENDOSMVC INTO :V0NAES-SEQ-APOLICE, :V0NAES-ENDOSCOB , :V0NAES-NRENDOCA , :V0NAES-ENDOSRES , :V0NAES-ENDOSSEM , :V0NAES-ENDOSCCR , :V0NAES-ENDOSMVC FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V1FONT-ORGAOEMIS AND COD_RAMO = :V1PROP-RAMO END-EXEC. */

            var r1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                V1FONT_ORGAOEMIS = V1FONT_ORGAOEMIS.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NAES_SEQ_APOLICE, V0NAES_SEQ_APOLICE);
                _.Move(executed_1.V0NAES_ENDOSCOB, V0NAES_ENDOSCOB);
                _.Move(executed_1.V0NAES_NRENDOCA, V0NAES_NRENDOCA);
                _.Move(executed_1.V0NAES_ENDOSRES, V0NAES_ENDOSRES);
                _.Move(executed_1.V0NAES_ENDOSSEM, V0NAES_ENDOSSEM);
                _.Move(executed_1.V0NAES_ENDOSCCR, V0NAES_ENDOSCCR);
                _.Move(executed_1.V0NAES_ENDOSMVC, V0NAES_ENDOSMVC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-UPDATE-NUMERO-AES-SECTION */
        private void R1410_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -1838- MOVE '141' TO WNR-EXEC-SQL. */
            _.Move("141", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1850- PERFORM R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -1853- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1856- DISPLAY 'R1410-00 (PROBLEMAS UPDATE NUMERO-AES) ... ' ' ' V1FONT-ORGAOEMIS ' ' V1PROP-RAMO */

                $"R1410-00 (PROBLEMAS UPDATE NUMERO-AES) ...  {V1FONT_ORGAOEMIS} {V1PROP_RAMO}"
                .Display();

                /*" -1856- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1410-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -1850- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOLICE, ENDOSCOB = :V0NAES-ENDOSCOB , NRENDOCA = :V0NAES-NRENDOCA , ENDOSRES = :V0NAES-ENDOSRES , ENDOSSEM = :V0NAES-ENDOSSEM , ENDOSCCR = :V0NAES-ENDOSCCR , ENDOSMVC = :V0NAES-ENDOSMVC , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_ORGAO = :V1FONT-ORGAOEMIS AND COD_RAMO = :V1PROP-RAMO END-EXEC. */

            var r1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOLICE = V0NAES_SEQ_APOLICE.ToString(),
                V0NAES_ENDOSCOB = V0NAES_ENDOSCOB.ToString(),
                V0NAES_NRENDOCA = V0NAES_NRENDOCA.ToString(),
                V0NAES_ENDOSRES = V0NAES_ENDOSRES.ToString(),
                V0NAES_ENDOSSEM = V0NAES_ENDOSSEM.ToString(),
                V0NAES_ENDOSCCR = V0NAES_ENDOSCCR.ToString(),
                V0NAES_ENDOSMVC = V0NAES_ENDOSMVC.ToString(),
                V1FONT_ORGAOEMIS = V1FONT_ORGAOEMIS.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            R1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r1410_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-V1PROPCORRET-SECTION */
        private void R2100_00_DECLARE_V1PROPCORRET_SECTION()
        {
            /*" -1869- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1884- PERFORM R2100_00_DECLARE_V1PROPCORRET_DB_DECLARE_1 */

            R2100_00_DECLARE_V1PROPCORRET_DB_DECLARE_1();

            /*" -1886- PERFORM R2100_00_DECLARE_V1PROPCORRET_DB_OPEN_1 */

            R2100_00_DECLARE_V1PROPCORRET_DB_OPEN_1();

            /*" -1889- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1890- DISPLAY 'EM0005B - R2100 (ERRO DECLARE V1PROPCORRET)' */
                _.Display($"EM0005B - R2100 (ERRO DECLARE V1PROPCORRET)");

                /*" -1890- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1PROPCORRET-DB-OPEN-1 */
        public void R2100_00_DECLARE_V1PROPCORRET_DB_OPEN_1()
        {
            /*" -1886- EXEC SQL OPEN V1PROPCORRET END-EXEC. */

            V1PROPCORRET.Open();

        }

        [StopWatch]
        /*" R2200-00-DECLARE-V1PROPCOSCED-DB-DECLARE-1 */
        public void R2200_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1()
        {
            /*" -1915- EXEC SQL DECLARE V1PROPCOSCED CURSOR FOR SELECT FONTE , NRPROPOS , CODCOSS , RAMOFR , PCPARTIC , PCCOMCOS FROM SEGUROS.V1PROPCOSCED WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY FONTE, NRPROPOS END-EXEC. */
            V1PROPCOSCED = new EM0005B_V1PROPCOSCED(true);
            string GetQuery_V1PROPCOSCED()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS
							, 
							CODCOSS
							, 
							RAMOFR
							, 
							PCPARTIC
							, 
							PCCOMCOS 
							FROM SEGUROS.V1PROPCOSCED 
							WHERE FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY FONTE
							, NRPROPOS";

                return query;
            }
            V1PROPCOSCED.GetQueryEvent += GetQuery_V1PROPCOSCED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-DECLARE-V1PROPCOSCED-SECTION */
        private void R2200_00_DECLARE_V1PROPCOSCED_SECTION()
        {
            /*" -1903- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1915- PERFORM R2200_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1 */

            R2200_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1();

            /*" -1917- PERFORM R2200_00_DECLARE_V1PROPCOSCED_DB_OPEN_1 */

            R2200_00_DECLARE_V1PROPCOSCED_DB_OPEN_1();

            /*" -1920- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1921- DISPLAY 'EM0005B - R2200 (ERRO DECLARE V1PROPCOSCED)' */
                _.Display($"EM0005B - R2200 (ERRO DECLARE V1PROPCOSCED)");

                /*" -1921- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2200-00-DECLARE-V1PROPCOSCED-DB-OPEN-1 */
        public void R2200_00_DECLARE_V1PROPCOSCED_DB_OPEN_1()
        {
            /*" -1917- EXEC SQL OPEN V1PROPCOSCED END-EXEC. */

            V1PROPCOSCED.Open();

        }

        [StopWatch]
        /*" R2400-00-DECLARE-V1COBERPROP-DB-DECLARE-1 */
        public void R2400_00_DECLARE_V1COBERPROP_DB_DECLARE_1()
        {
            /*" -2009- EXEC SQL DECLARE V1COBERPROP CURSOR FOR SELECT FONTE , NRPROPOS , NUM_ITEM , RAMOFR , MODALIFR , COD_COBERTURA , IMP_SEGURADA_IX , PRM_TARIFARIO_IX , DATA_INIVIGENCIA , DATA_TERVIGENCIA FROM SEGUROS.V1COBERPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY FONTE, NRPROPOS, RAMOFR END-EXEC. */
            V1COBERPROP = new EM0005B_V1COBERPROP(true);
            string GetQuery_V1COBERPROP()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS
							, 
							NUM_ITEM
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_IX
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA 
							FROM SEGUROS.V1COBERPROP 
							WHERE FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY FONTE
							, NRPROPOS
							, RAMOFR";

                return query;
            }
            V1COBERPROP.GetQueryEvent += GetQuery_V1COBERPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-V1COBERPROP-SECTION */
        private void R2250_00_SELECT_V1COBERPROP_SECTION()
        {
            /*" -1934- MOVE '225' TO WNR-EXEC-SQL. */
            _.Move("225", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1941- PERFORM R2250_00_SELECT_V1COBERPROP_DB_SELECT_1 */

            R2250_00_SELECT_V1COBERPROP_DB_SELECT_1();

            /*" -1944- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1945- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1946- MOVE 99 TO W1COBP-NUM-ITEM */
                    _.Move(99, W1COBP_NUM_ITEM);

                    /*" -1947- GO TO R2250-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                    return;

                    /*" -1948- ELSE */
                }
                else
                {


                    /*" -1949- MOVE 99 TO W1COBP-NUM-ITEM */
                    _.Move(99, W1COBP_NUM_ITEM);

                    /*" -1951- GO TO R2250-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1951- ADD 1 TO AC-S-COBERPROP. */
            AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + 1;

        }

        [StopWatch]
        /*" R2250-00-SELECT-V1COBERPROP-DB-SELECT-1 */
        public void R2250_00_SELECT_V1COBERPROP_DB_SELECT_1()
        {
            /*" -1941- EXEC SQL SELECT NUM_ITEM INTO :W1COBP-NUM-ITEM FROM SEGUROS.V1COBERPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS AND RAMOFR = :V1PROP-RAMO END-EXEC. */

            var r2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 = new R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            var executed_1 = R2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1COBP_NUM_ITEM, W1COBP_NUM_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-V1COBERPROP-SECTION */
        private void R2300_00_SELECT_V1COBERPROP_SECTION()
        {
            /*" -1964- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1970- PERFORM R2300_00_SELECT_V1COBERPROP_DB_SELECT_1 */

            R2300_00_SELECT_V1COBERPROP_DB_SELECT_1();

            /*" -1973- IF VIND-PRMTARIFA LESS 0 */

            if (VIND_PRMTARIFA < 0)
            {

                /*" -1975- MOVE ZEROS TO W1COBP-PRM-TAR-VR. */
                _.Move(0, W1COBP_PRM_TAR_VR);
            }


            /*" -1976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1977- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1978- MOVE ZEROS TO W1COBP-PRM-TAR-VR */
                    _.Move(0, W1COBP_PRM_TAR_VR);

                    /*" -1979- ELSE */
                }
                else
                {


                    /*" -1980- DISPLAY 'EM0005B - R2300 (ERRO SELECT V1COBERPROP)' */
                    _.Display($"EM0005B - R2300 (ERRO SELECT V1COBERPROP)");

                    /*" -1980- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2300-00-SELECT-V1COBERPROP-DB-SELECT-1 */
        public void R2300_00_SELECT_V1COBERPROP_DB_SELECT_1()
        {
            /*" -1970- EXEC SQL SELECT SUM(PRM_TARIFARIO_IX) INTO :W1COBP-PRM-TAR-VR:VIND-PRMTARIFA FROM SEGUROS.V1COBERPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1 = new R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_V1COBERPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1COBP_PRM_TAR_VR, W1COBP_PRM_TAR_VR);
                _.Move(executed_1.VIND_PRMTARIFA, VIND_PRMTARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-DECLARE-V1COBERPROP-SECTION */
        private void R2400_00_DECLARE_V1COBERPROP_SECTION()
        {
            /*" -1993- MOVE '240' TO WNR-EXEC-SQL. */
            _.Move("240", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2009- PERFORM R2400_00_DECLARE_V1COBERPROP_DB_DECLARE_1 */

            R2400_00_DECLARE_V1COBERPROP_DB_DECLARE_1();

            /*" -2011- PERFORM R2400_00_DECLARE_V1COBERPROP_DB_OPEN_1 */

            R2400_00_DECLARE_V1COBERPROP_DB_OPEN_1();

            /*" -2014- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2015- DISPLAY 'EM0005B - R2400 (ERRO DECLARE V1COBERPROP' */
                _.Display($"EM0005B - R2400 (ERRO DECLARE V1COBERPROP");

                /*" -2015- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2400-00-DECLARE-V1COBERPROP-DB-OPEN-1 */
        public void R2400_00_DECLARE_V1COBERPROP_DB_OPEN_1()
        {
            /*" -2011- EXEC SQL OPEN V1COBERPROP END-EXEC. */

            V1COBERPROP.Open();

        }

        [StopWatch]
        /*" R2500-00-DECLARE-V1COSSEGSORT-DB-DECLARE-1 */
        public void R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1()
        {
            /*" -2038- EXEC SQL DECLARE V1COSSEGSORT CURSOR FOR SELECT RAMO , CONGENER , PCCOMCOS , PCPARTIC , SITUACAO FROM SEGUROS.V1COSSEGSORT WHERE RAMO = :V1PROP-RAMO ORDER BY CONGENER END-EXEC. */
            V1COSSEGSORT = new EM0005B_V1COSSEGSORT(true);
            string GetQuery_V1COSSEGSORT()
            {
                var query = @$"SELECT RAMO
							, 
							CONGENER
							, 
							PCCOMCOS
							, 
							PCPARTIC
							, 
							SITUACAO 
							FROM SEGUROS.V1COSSEGSORT 
							WHERE RAMO = '{V1PROP_RAMO}' 
							ORDER BY CONGENER";

                return query;
            }
            V1COSSEGSORT.GetQueryEvent += GetQuery_V1COSSEGSORT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-DECLARE-V1COSSEGSORT-SECTION */
        private void R2500_00_DECLARE_V1COSSEGSORT_SECTION()
        {
            /*" -2028- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2038- PERFORM R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1 */

            R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1();

            /*" -2040- PERFORM R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1 */

            R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1();

            /*" -2043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2044- DISPLAY 'EM0005B - R2500 (ERRO DECLARE V1COSSEGSORT)' */
                _.Display($"EM0005B - R2500 (ERRO DECLARE V1COSSEGSORT)");

                /*" -2044- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2500-00-DECLARE-V1COSSEGSORT-DB-OPEN-1 */
        public void R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1()
        {
            /*" -2040- EXEC SQL OPEN V1COSSEGSORT END-EXEC. */

            V1COSSEGSORT.Open();

        }

        [StopWatch]
        /*" R3220-00-DECLARE-V1ACOMPROP-DB-DECLARE-1 */
        public void R3220_00_DECLARE_V1ACOMPROP_DB_DECLARE_1()
        {
            /*" -2589- EXEC SQL DECLARE V1ACOMPROP CURSOR FOR SELECT DATOPR , HORAOPER FROM SEGUROS.V1ACOMPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS AND OPERACAO = 9010 ORDER BY HORAOPER DESC END-EXEC. */
            V1ACOMPROP = new EM0005B_V1ACOMPROP(true);
            string GetQuery_V1ACOMPROP()
            {
                var query = @$"SELECT DATOPR
							, 
							HORAOPER 
							FROM SEGUROS.V1ACOMPROP 
							WHERE FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							AND OPERACAO = 9010 
							ORDER BY HORAOPER DESC";

                return query;
            }
            V1ACOMPROP.GetQueryEvent += GetQuery_V1ACOMPROP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-V0APOLICE-SECTION */
        private void R3100_00_INSERT_V0APOLICE_SECTION()
        {
            /*" -2057- PERFORM R3110-00-MONTA-V0APOLICE */

            R3110_00_MONTA_V0APOLICE_SECTION();

            /*" -2059- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2111- PERFORM R3100_00_INSERT_V0APOLICE_DB_INSERT_1 */

            R3100_00_INSERT_V0APOLICE_DB_INSERT_1();

            /*" -2117- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2119- GO TO R3100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2120- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2123- DISPLAY 'R3100-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R3100-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -2125- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2125- ADD 1 TO AC-I-APOLICES. */
            AREA_DE_WORK.AC_I_APOLICES.Value = AREA_DE_WORK.AC_I_APOLICES + 1;

        }

        [StopWatch]
        /*" R3100-00-INSERT-V0APOLICE-DB-INSERT-1 */
        public void R3100_00_INSERT_V0APOLICE_DB_INSERT_1()
        {
            /*" -2111- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , :V0APOL-DATA-SORT:VIND-DAT-SORT, :V0APOL-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP, :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC. */

            var r3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1 = new R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1()
            {
                V0APOL_CODCLIEN = V0APOL_CODCLIEN.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
                V0APOL_NUM_ITEM = V0APOL_NUM_ITEM.ToString(),
                V0APOL_MODALIDA = V0APOL_MODALIDA.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
                V0APOL_NUM_APO_ANT = V0APOL_NUM_APO_ANT.ToString(),
                V0APOL_NUMBIL = V0APOL_NUMBIL.ToString(),
                V0APOL_TIPSGU = V0APOL_TIPSGU.ToString(),
                V0APOL_TIPAPO = V0APOL_TIPAPO.ToString(),
                V0APOL_TIPCALC = V0APOL_TIPCALC.ToString(),
                V0APOL_PODPUBL = V0APOL_PODPUBL.ToString(),
                V0APOL_NUM_ATA = V0APOL_NUM_ATA.ToString(),
                V0APOL_ANO_ATA = V0APOL_ANO_ATA.ToString(),
                V0APOL_IDEMAN = V0APOL_IDEMAN.ToString(),
                V0APOL_PCDESCON = V0APOL_PCDESCON.ToString(),
                V0APOL_PCIOCC = V0APOL_PCIOCC.ToString(),
                V0APOL_TPCOSCED = V0APOL_TPCOSCED.ToString(),
                V0APOL_QTCOSSEG = V0APOL_QTCOSSEG.ToString(),
                V0APOL_PCTCED = V0APOL_PCTCED.ToString(),
                V0APOL_DATA_SORT = V0APOL_DATA_SORT.ToString(),
                VIND_DAT_SORT = VIND_DAT_SORT.ToString(),
                V0APOL_COD_EMPRESA = V0APOL_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0APOL_CODPRODU = V0APOL_CODPRODU.ToString(),
                V0APOL_TPCORRET = V0APOL_TPCORRET.ToString(),
            };

            R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-MONTA-V0APOLICE-SECTION */
        private void R3110_00_MONTA_V0APOLICE_SECTION()
        {
            /*" -2140- IF V1PROP-NUM-APOLICE NOT EQUAL ZEROS AND V1PROP-NUM-APO-ANT EQUAL ZEROS */

            if (V1PROP_NUM_APOLICE != 00 && V1PROP_NUM_APO_ANT == 00)
            {

                /*" -2141- MOVE V1PROP-NUM-APOLICE TO WNUM-APOLICE */
                _.Move(V1PROP_NUM_APOLICE, AREA_DE_WORK.WNUM_APOLICE);

                /*" -2142- GO TO R3110-CONTINUA */

                R3110_CONTINUA(); //GOTO
                return;

                /*" -2144- END-IF. */
            }


            /*" -2145- IF V1PROP-NUM-APO-MAN EQUAL ZEROS */

            if (V1PROP_NUM_APO_MAN == 00)
            {

                /*" -2146- PERFORM R1400-00-SELECT-NUMERO-AES */

                R1400_00_SELECT_NUMERO_AES_SECTION();

                /*" -2147- MOVE V0NAES-SEQ-APOLICE TO W0NAES-SEQ-APOLICE */
                _.Move(V0NAES_SEQ_APOLICE, W0NAES_SEQ_APOLICE);

                /*" -2148- ADD 1 TO W0NAES-SEQ-APOLICE */
                W0NAES_SEQ_APOLICE.Value = W0NAES_SEQ_APOLICE + 1;

                /*" -2149- MOVE W0NAES-SEQ-APOLICE TO V0NAES-SEQ-APOLICE */
                _.Move(W0NAES_SEQ_APOLICE, V0NAES_SEQ_APOLICE);

                /*" -2150- PERFORM R1410-00-UPDATE-NUMERO-AES */

                R1410_00_UPDATE_NUMERO_AES_SECTION();

                /*" -2151- MOVE V1FONT-ORGAOEMIS TO WNUM-APOL-ORG */
                _.Move(V1FONT_ORGAOEMIS, AREA_DE_WORK.FILLER_0.WNUM_APOL_ORG);

                /*" -2152- MOVE V1PROP-RAMO TO WNUM-APOL-RAM */
                _.Move(V1PROP_RAMO, AREA_DE_WORK.FILLER_0.WNUM_APOL_RAM);

                /*" -2153- MOVE W0NAES-SEQ-APOLICE TO WNUM-APOL-SEQ */
                _.Move(W0NAES_SEQ_APOLICE, AREA_DE_WORK.FILLER_0.WNUM_APOL_SEQ);

                /*" -2154- MOVE WNUMERO-APOL TO WNUM-APOLICE */
                _.Move(AREA_DE_WORK.WNUMERO_APOL, AREA_DE_WORK.WNUM_APOLICE);

                /*" -2155- ELSE */
            }
            else
            {


                /*" -2162- IF (((V1PROP-CODPRODU EQUAL 1601 OR V1PROP-CODPRODU EQUAL 1801) AND V1PROP-CODEMPR EQUAL 5495) OR ((V1PROP-CODPRODU EQUAL 1602 OR V1PROP-CODPRODU EQUAL 1802 OR V1PROP-CODPRODU EQUAL 1804) AND V1PROP-CODEMPR EQUAL 0)) */

                if ((((V1PROP_CODPRODU == 1601 || V1PROP_CODPRODU == 1801) && V1PROP_CODEMPR == 5495) || ((V1PROP_CODPRODU == 1602 || V1PROP_CODPRODU == 1802 || V1PROP_CODPRODU == 1804) && V1PROP_CODEMPR == 0)))
                {

                    /*" -2163- PERFORM R1400-00-SELECT-NUMERO-AES */

                    R1400_00_SELECT_NUMERO_AES_SECTION();

                    /*" -2164- MOVE V0NAES-SEQ-APOLICE TO W0NAES-SEQ-APOLICE */
                    _.Move(V0NAES_SEQ_APOLICE, W0NAES_SEQ_APOLICE);

                    /*" -2165- ADD 1 TO W0NAES-SEQ-APOLICE */
                    W0NAES_SEQ_APOLICE.Value = W0NAES_SEQ_APOLICE + 1;

                    /*" -2166- MOVE W0NAES-SEQ-APOLICE TO V0NAES-SEQ-APOLICE */
                    _.Move(W0NAES_SEQ_APOLICE, V0NAES_SEQ_APOLICE);

                    /*" -2167- PERFORM R1410-00-UPDATE-NUMERO-AES */

                    R1410_00_UPDATE_NUMERO_AES_SECTION();

                    /*" -2168- MOVE V1FONT-ORGAOEMIS TO WNUM-APOL-ORG */
                    _.Move(V1FONT_ORGAOEMIS, AREA_DE_WORK.FILLER_0.WNUM_APOL_ORG);

                    /*" -2169- MOVE V1PROP-RAMO TO WNUM-APOL-RAM */
                    _.Move(V1PROP_RAMO, AREA_DE_WORK.FILLER_0.WNUM_APOL_RAM);

                    /*" -2170- MOVE W0NAES-SEQ-APOLICE TO WNUM-APOL-SEQ */
                    _.Move(W0NAES_SEQ_APOLICE, AREA_DE_WORK.FILLER_0.WNUM_APOL_SEQ);

                    /*" -2171- MOVE WNUMERO-APOL TO WNUM-APOLICE */
                    _.Move(AREA_DE_WORK.WNUMERO_APOL, AREA_DE_WORK.WNUM_APOLICE);

                    /*" -2172- ELSE */
                }
                else
                {


                    /*" -2172- MOVE V1PROP-NUM-APO-MAN TO WNUM-APOLICE. */
                    _.Move(V1PROP_NUM_APO_MAN, AREA_DE_WORK.WNUM_APOLICE);
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R3110_CONTINUA */

            R3110_CONTINUA();

        }

        [StopWatch]
        /*" R3110-CONTINUA */
        private void R3110_CONTINUA(bool isPerform = false)
        {
            /*" -2177- MOVE V1PROP-CODCLIEN TO V0APOL-CODCLIEN */
            _.Move(V1PROP_CODCLIEN, V0APOL_CODCLIEN);

            /*" -2178- MOVE WNUM-APOLICE TO V0APOL-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0APOL_NUM_APOL);

            /*" -2179- MOVE ZEROS TO V0APOL-NUM-ITEM */
            _.Move(0, V0APOL_NUM_ITEM);

            /*" -2180- MOVE V1PROP-MODALIDA TO V0APOL-MODALIDA */
            _.Move(V1PROP_MODALIDA, V0APOL_MODALIDA);

            /*" -2181- MOVE V1FONT-ORGAOEMIS TO V0APOL-ORGAO */
            _.Move(V1FONT_ORGAOEMIS, V0APOL_ORGAO);

            /*" -2182- MOVE V1PROP-RAMO TO V0APOL-RAMO */
            _.Move(V1PROP_RAMO, V0APOL_RAMO);

            /*" -2183- MOVE V1PROP-NUM-APO-ANT TO V0APOL-NUM-APO-ANT */
            _.Move(V1PROP_NUM_APO_ANT, V0APOL_NUM_APO_ANT);

            /*" -2184- MOVE ZEROS TO V0APOL-NUMBIL */
            _.Move(0, V0APOL_NUMBIL);

            /*" -2185- MOVE '1' TO V0APOL-TIPSGU */
            _.Move("1", V0APOL_TIPSGU);

            /*" -2186- MOVE V1PROP-TIPAPO TO V0APOL-TIPAPO */
            _.Move(V1PROP_TIPAPO, V0APOL_TIPAPO);

            /*" -2187- MOVE V1PROP-TIPCALC TO V0APOL-TIPCALC */
            _.Move(V1PROP_TIPCALC, V0APOL_TIPCALC);

            /*" -2188- MOVE V1PROP-PODPUBL TO V0APOL-PODPUBL */
            _.Move(V1PROP_PODPUBL, V0APOL_PODPUBL);

            /*" -2189- MOVE V1PROP-NUM-ATA TO V0APOL-NUM-ATA */
            _.Move(V1PROP_NUM_ATA, V0APOL_NUM_ATA);

            /*" -2190- MOVE V1PROP-ANO-ATA TO V0APOL-ANO-ATA */
            _.Move(V1PROP_ANO_ATA, V0APOL_ANO_ATA);

            /*" -2191- MOVE SPACES TO V0APOL-IDEMAN */
            _.Move("", V0APOL_IDEMAN);

            /*" -2193- MOVE V1PROP-PCDESCON TO V0APOL-PCDESCON */
            _.Move(V1PROP_PCDESCON, V0APOL_PCDESCON);

            /*" -2194- IF V1PROP-IDIOF EQUAL 'S' */

            if (V1PROP_IDIOF == "S")
            {

                /*" -2195- MOVE ZEROS TO V0APOL-PCIOCC */
                _.Move(0, V0APOL_PCIOCC);

                /*" -2196- ELSE */
            }
            else
            {


                /*" -2199- MOVE V1RAMO-PCIOF TO V0APOL-PCIOCC. */
                _.Move(V1RAMO_PCIOF, V0APOL_PCIOCC);
            }


            /*" -2200- MOVE V1PROP-TPCOSCED TO V0APOL-TPCOSCED */
            _.Move(V1PROP_TPCOSCED, V0APOL_TPCOSCED);

            /*" -2201- MOVE V1PROP-QTCOSSEG TO V0APOL-QTCOSSEG */
            _.Move(V1PROP_QTCOSSEG, V0APOL_QTCOSSEG);

            /*" -2202- MOVE V1PROP-DATA-SORT TO V0APOL-DATA-SORT */
            _.Move(V1PROP_DATA_SORT, V0APOL_DATA_SORT);

            /*" -2203- MOVE +0 TO V0APOL-PCTCED */
            _.Move(+0, V0APOL_PCTCED);

            /*" -2205- MOVE V1PROP-COD-EMPRESA TO V0APOL-COD-EMPRESA */
            _.Move(V1PROP_COD_EMPRESA, V0APOL_COD_EMPRESA);

            /*" -2206- MOVE V1PROP-CODPRODU TO V0APOL-CODPRODU */
            _.Move(V1PROP_CODPRODU, V0APOL_CODPRODU);

            /*" -2206- MOVE V1PROP-TPCORRET TO V0APOL-TPCORRET. */
            _.Move(V1PROP_TPCORRET, V0APOL_TPCORRET);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-INSERT-V0ENDOSSO-SECTION */
        private void R3200_00_INSERT_V0ENDOSSO_SECTION()
        {
            /*" -2219- PERFORM R3210-00-MONTA-V0ENDOSSO */

            R3210_00_MONTA_V0ENDOSSO_SECTION();

            /*" -2219- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R3200_10_INSERT */

            R3200_10_INSERT();

        }

        [StopWatch]
        /*" R3200-10-INSERT */
        private void R3200_10_INSERT(bool isPerform = false)
        {
            /*" -2313- PERFORM R3200_10_INSERT_DB_INSERT_1 */

            R3200_10_INSERT_DB_INSERT_1();

            /*" -2319- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2320- PERFORM R3209-00-ALTERA-NRPROPOS */

                R3209_00_ALTERA_NRPROPOS_SECTION();

                /*" -2322- GO TO R3200-10-INSERT. */
                new Task(() => R3200_10_INSERT()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2326- DISPLAY 'R3200-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R3200-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -2328- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2328- ADD +1 TO AC-I-ENDOSSOS. */
            AREA_DE_WORK.AC_I_ENDOSSOS.Value = AREA_DE_WORK.AC_I_ENDOSSOS + +1;

        }

        [StopWatch]
        /*" R3200-10-INSERT-DB-INSERT-1 */
        public void R3200_10_INSERT_DB_INSERT_1()
        {
            /*" -2313- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPEND , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DAT-RCAP , :V0ENDO-COD-EMPRESA:VIND-COD-EMP , :V0ENDO-CORRECAO:VIND-CORRECAO , :V0ENDO-ISENTA-CST , CURRENT TIMESTAMP , :V0ENDO-DTVENCTO:VIND-DTVENCTO , :V0ENDO-CFPREFIX:VIND-CFPREFIX , :V0ENDO-VLCUSEMI:VIND-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC. */

            var r3200_10_INSERT_DB_INSERT_1_Insert1 = new R3200_10_INSERT_DB_INSERT_1_Insert1()
            {
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
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
                V0ENDO_TIPEND = V0ENDO_TIPEND.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                VIND_DAT_RCAP = VIND_DAT_RCAP.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                VIND_CORRECAO = VIND_CORRECAO.ToString(),
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

            R3200_10_INSERT_DB_INSERT_1_Insert1.Execute(r3200_10_INSERT_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3209-00-ALTERA-NRPROPOS-SECTION */
        private void R3209_00_ALTERA_NRPROPOS_SECTION()
        {
            /*" -2341- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2346- PERFORM R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1 */

            R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1();

            /*" -2349- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2350- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2353- DISPLAY 'R3200-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                    $"R3200-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                    .Display();

                    /*" -2353- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3209-00-ALTERA-NRPROPOS-DB-UPDATE-1 */
        public void R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1()
        {
            /*" -2346- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET NRPROPOS = 900000000 + NRPROPOS WHERE FONTE = :V0ENDO-FONTE AND NRPROPOS = :V0ENDO-NRPROPOS END-EXEC. */

            var r3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1 = new R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1.Execute(r3209_00_ALTERA_NRPROPOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3209_00_SAIDA*/

        [StopWatch]
        /*" R3210-00-MONTA-V0ENDOSSO-SECTION */
        private void R3210_00_MONTA_V0ENDOSSO_SECTION()
        {
            /*" -2371- MOVE SPACES TO WFIM-V1ACOMPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1ACOMPROP);

            /*" -2372- PERFORM R3220-00-DECLARE-V1ACOMPROP */

            R3220_00_DECLARE_V1ACOMPROP_SECTION();

            /*" -2374- PERFORM R3221-00-FETCH-V1ACOMPROP */

            R3221_00_FETCH_V1ACOMPROP_SECTION();

            /*" -2376- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2377- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -2378- MOVE WNUM-APOLICE TO V0ENDO-NUM-APOL */
                _.Move(AREA_DE_WORK.WNUM_APOLICE, V0ENDO_NUM_APOL);

                /*" -2379- MOVE ZEROS TO V0ENDO-NRENDOS */
                _.Move(0, V0ENDO_NRENDOS);

                /*" -2380- ELSE */
            }
            else
            {


                /*" -2381- MOVE V1PROP-NUM-APOLICE TO V0ENDO-NUM-APOL */
                _.Move(V1PROP_NUM_APOLICE, V0ENDO_NUM_APOL);

                /*" -2382- PERFORM R3211-00-NUMERO-ENDOSSO */

                R3211_00_NUMERO_ENDOSSO_SECTION();

                /*" -2384- MOVE WNUM-ENDOSSO TO V0ENDO-NRENDOS. */
                _.Move(AREA_DE_WORK.WNUM_ENDOSSO, V0ENDO_NRENDOS);
            }


            /*" -2385- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -2386- MOVE V1PROP-FONTE TO V0ENDO-FONTE */
            _.Move(V1PROP_FONTE, V0ENDO_FONTE);

            /*" -2387- MOVE V1PROP-NRPROPOS TO V0ENDO-NRPROPOS */
            _.Move(V1PROP_NRPROPOS, V0ENDO_NRPROPOS);

            /*" -2389- MOVE V1PROP-DTENTRAD TO V0ENDO-DATPRO */
            _.Move(V1PROP_DTENTRAD, V0ENDO_DATPRO);

            /*" -2390- IF WFIM-V1ACOMPROP EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1ACOMPROP.IsEmpty())
            {

                /*" -2391- MOVE V1APRO-DATOPR TO V0ENDO-DT-LIBER */
                _.Move(V1APRO_DATOPR, V0ENDO_DT_LIBER);

                /*" -2392- ELSE */
            }
            else
            {


                /*" -2394- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
                _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);
            }


            /*" -2395- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -2396- MOVE V1PROP-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(V1PROP_NRRCAP, V0ENDO_NRRCAP);

            /*" -2397- MOVE V1PROP-VLRCAP TO V0ENDO-VLRCAP */
            _.Move(V1PROP_VLRCAP, V0ENDO_VLRCAP);

            /*" -2398- MOVE V1PROP-BCORCAP TO V0ENDO-BCORCAP */
            _.Move(V1PROP_BCORCAP, V0ENDO_BCORCAP);

            /*" -2399- MOVE V1PROP-AGERCAP TO V0ENDO-AGERCAP */
            _.Move(V1PROP_AGERCAP, V0ENDO_AGERCAP);

            /*" -2400- MOVE SPACES TO V0ENDO-DACRCAP */
            _.Move("", V0ENDO_DACRCAP);

            /*" -2404- MOVE V1PROP-IDRCAP TO V0ENDO-IDRCAP */
            _.Move(V1PROP_IDRCAP, V0ENDO_IDRCAP);

            /*" -2406- IF V1PROP-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (V1PROP_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -2407- IF V1PROP-TIPO-ENDOS EQUAL '0' OR '1' */

                if (V1PROP_TIPO_ENDOS.In("0", "1"))
                {

                    /*" -2408- PERFORM R3215-00-RECUPERA-AU085 */

                    R3215_00_RECUPERA_AU085_SECTION();

                    /*" -2410- IF AU085-IND-FORMA-PAGTO-AD EQUAL '0' */

                    if (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD == "0")
                    {

                        /*" -2411- MOVE 104 TO V0ENDO-BCOCOBR */
                        _.Move(104, V0ENDO_BCOCOBR);

                        /*" -2412- ELSE */
                    }
                    else
                    {


                        /*" -2413- MOVE V1PROP-BCOCOBR TO V0ENDO-BCOCOBR */
                        _.Move(V1PROP_BCOCOBR, V0ENDO_BCOCOBR);

                        /*" -2414- ELSE */
                    }

                }
                else
                {


                    /*" -2415- MOVE V1PROP-BCOCOBR TO V0ENDO-BCOCOBR */
                    _.Move(V1PROP_BCOCOBR, V0ENDO_BCOCOBR);

                    /*" -2416- ELSE */
                }

            }
            else
            {


                /*" -2418- MOVE 104 TO V0ENDO-BCOCOBR. */
                _.Move(104, V0ENDO_BCOCOBR);
            }


            /*" -2419- MOVE V1PROP-AGECOBR TO V0ENDO-AGECOBR */
            _.Move(V1PROP_AGECOBR, V0ENDO_AGECOBR);

            /*" -2420- MOVE SPACES TO V0ENDO-DACCOBR */
            _.Move("", V0ENDO_DACCOBR);

            /*" -2421- MOVE V1PROP-DTINIVIG TO V0ENDO-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0ENDO_DTINIVIG);

            /*" -2422- MOVE V1PROP-DTTERVIG TO V0ENDO-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0ENDO_DTTERVIG);

            /*" -2423- MOVE V1PROP-CDFRACIO TO V0ENDO-CDFRACIO */
            _.Move(V1PROP_CDFRACIO, V0ENDO_CDFRACIO);

            /*" -2424- MOVE V1PROP-PCENTRAD TO V0ENDO-PCENTRAD */
            _.Move(V1PROP_PCENTRAD, V0ENDO_PCENTRAD);

            /*" -2425- MOVE V1PROP-PCADICIO TO V0ENDO-PCADICIO */
            _.Move(V1PROP_PCADICIO, V0ENDO_PCADICIO);

            /*" -2427- MOVE V1PROP-PRESTA1 TO V0ENDO-PRESTA1 */
            _.Move(V1PROP_PRESTA1, V0ENDO_PRESTA1);

            /*" -2428- IF V1PROP-QTPARCEL EQUAL 1 */

            if (V1PROP_QTPARCEL == 1)
            {

                /*" -2429- MOVE 0 TO V0ENDO-QTPARCEL */
                _.Move(0, V0ENDO_QTPARCEL);

                /*" -2430- ELSE */
            }
            else
            {


                /*" -2432- MOVE V1PROP-QTPARCEL TO V0ENDO-QTPARCEL. */
                _.Move(V1PROP_QTPARCEL, V0ENDO_QTPARCEL);
            }


            /*" -2433- MOVE V1PROP-QTPRESTA TO V0ENDO-QTPRESTA */
            _.Move(V1PROP_QTPRESTA, V0ENDO_QTPRESTA);

            /*" -2434- MOVE V1PROP-QTITENS TO V0ENDO-QTITENS */
            _.Move(V1PROP_QTITENS, V0ENDO_QTITENS);

            /*" -2435- MOVE V1PROP-CODTXT TO V0ENDO-CODTXT */
            _.Move(V1PROP_CODTXT, V0ENDO_CODTXT);

            /*" -2436- MOVE V1PROP-CDACEITA TO V0ENDO-CDACEITA */
            _.Move(V1PROP_CDACEITA, V0ENDO_CDACEITA);

            /*" -2437- MOVE V1PROP-MOEDA-IMP TO V0ENDO-MOEDA-IMP */
            _.Move(V1PROP_MOEDA_IMP, V0ENDO_MOEDA_IMP);

            /*" -2438- MOVE V1PROP-MOEDA-PRM TO V0ENDO-MOEDA-PRM */
            _.Move(V1PROP_MOEDA_PRM, V0ENDO_MOEDA_PRM);

            /*" -2439- MOVE V1PROP-TIPO-ENDOS TO V0ENDO-TIPEND */
            _.Move(V1PROP_TIPO_ENDOS, V0ENDO_TIPEND);

            /*" -2440- MOVE V1PROP-COD-USUAR TO V0ENDO-COD-USUAR */
            _.Move(V1PROP_COD_USUAR, V0ENDO_COD_USUAR);

            /*" -2441- MOVE V1PROP-OCORR-END TO V0ENDO-OCORR-END */
            _.Move(V1PROP_OCORR_END, V0ENDO_OCORR_END);

            /*" -2443- MOVE SPACES TO V0ENDO-SITUACAO */
            _.Move("", V0ENDO_SITUACAO);

            /*" -2447- IF (( V1PROP-CODPRODU EQUAL 5302 OR 5303 OR 5304 ) AND ( V1PROP-TIPO-ENDOS EQUAL '0' OR '1' ) AND ( V1PROP-NRRCAP GREATER ZEROS )) */

            if (((V1PROP_CODPRODU.In("5302", "5303", "5304")) && (V1PROP_TIPO_ENDOS.In("0", "1")) && (V1PROP_NRRCAP > 00)))
            {

                /*" -2448- PERFORM R3212-00-RECUPERA-RCAP */

                R3212_00_RECUPERA_RCAP_SECTION();

                /*" -2450- MOVE RCAPS-DATA-CADASTRAMENTO TO V0ENDO-DATARCAP */
                _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO, V0ENDO_DATARCAP);

                /*" -2451- ELSE */
            }
            else
            {


                /*" -2453- MOVE V1PROP-DATARCAP TO V0ENDO-DATARCAP. */
                _.Move(V1PROP_DATARCAP, V0ENDO_DATARCAP);
            }


            /*" -2454- MOVE V1PROP-COD-EMPRESA TO V0ENDO-COD-EMPRESA */
            _.Move(V1PROP_COD_EMPRESA, V0ENDO_COD_EMPRESA);

            /*" -2455- MOVE 0 TO VIND-CORRECAO */
            _.Move(0, VIND_CORRECAO);

            /*" -2456- MOVE V1PROP-CORRECAO TO V0ENDO-CORRECAO */
            _.Move(V1PROP_CORRECAO, V0ENDO_CORRECAO);

            /*" -2458- MOVE V1PROP-ISENTA-CST TO V0ENDO-ISENTA-CST. */
            _.Move(V1PROP_ISENTA_CST, V0ENDO_ISENTA_CST);

            /*" -2460- MOVE V1PROP-DTVENCTO TO V0ENDO-DTVENCTO */
            _.Move(V1PROP_DTVENCTO, V0ENDO_DTVENCTO);

            /*" -2461- IF VIND-CFPREFIX EQUAL -1 */

            if (VIND_CFPREFIX == -1)
            {

                /*" -2462- MOVE -1 TO VIND-CFPREFIX */
                _.Move(-1, VIND_CFPREFIX);

                /*" -2463- MOVE ZEROS TO V0ENDO-CFPREFIX */
                _.Move(0, V0ENDO_CFPREFIX);

                /*" -2464- ELSE */
            }
            else
            {


                /*" -2465- MOVE ZEROS TO VIND-CFPREFIX */
                _.Move(0, VIND_CFPREFIX);

                /*" -2467- MOVE V1PROP-CFPREFIX TO V0ENDO-CFPREFIX. */
                _.Move(V1PROP_CFPREFIX, V0ENDO_CFPREFIX);
            }


            /*" -2468- IF VIND-VLCUSEMI EQUAL -1 */

            if (VIND_VLCUSEMI == -1)
            {

                /*" -2469- MOVE -1 TO VIND-VLCUSEMI */
                _.Move(-1, VIND_VLCUSEMI);

                /*" -2470- MOVE ZEROS TO V0ENDO-VLCUSEMI */
                _.Move(0, V0ENDO_VLCUSEMI);

                /*" -2471- ELSE */
            }
            else
            {


                /*" -2472- MOVE ZEROS TO VIND-VLCUSEMI */
                _.Move(0, VIND_VLCUSEMI);

                /*" -2474- MOVE V1PROP-VLCUSEMI TO V0ENDO-VLCUSEMI. */
                _.Move(V1PROP_VLCUSEMI, V0ENDO_VLCUSEMI);
            }


            /*" -2475- MOVE V1PROP-RAMO TO V0ENDO-RAMO. */
            _.Move(V1PROP_RAMO, V0ENDO_RAMO);

            /*" -2475- MOVE V1PROP-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V1PROP_CODPRODU, V0ENDO_CODPRODU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3211-00-NUMERO-ENDOSSO-SECTION */
        private void R3211_00_NUMERO_ENDOSSO_SECTION()
        {
            /*" -2488- MOVE '32X' TO WNR-EXEC-SQL. */
            _.Move("32X", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2490- PERFORM R1400-00-SELECT-NUMERO-AES. */

            R1400_00_SELECT_NUMERO_AES_SECTION();

            /*" -2491- IF V1PROP-TIPO-ENDOS = '1' */

            if (V1PROP_TIPO_ENDOS == "1")
            {

                /*" -2492- ADD +1 TO V0NAES-ENDOSCOB */
                V0NAES_ENDOSCOB.Value = V0NAES_ENDOSCOB + +1;

                /*" -2493- MOVE V0NAES-ENDOSCOB TO WNUM-ENDOSSO */
                _.Move(V0NAES_ENDOSCOB, AREA_DE_WORK.WNUM_ENDOSSO);

                /*" -2494- ELSE */
            }
            else
            {


                /*" -2495- IF V1PROP-TIPO-ENDOS = '3' */

                if (V1PROP_TIPO_ENDOS == "3")
                {

                    /*" -2496- ADD +1 TO V0NAES-ENDOSRES */
                    V0NAES_ENDOSRES.Value = V0NAES_ENDOSRES + +1;

                    /*" -2497- MOVE V0NAES-ENDOSRES TO WNUM-ENDOSSO */
                    _.Move(V0NAES_ENDOSRES, AREA_DE_WORK.WNUM_ENDOSSO);

                    /*" -2498- ELSE */
                }
                else
                {


                    /*" -2499- IF V1PROP-TIPO-ENDOS = '4' */

                    if (V1PROP_TIPO_ENDOS == "4")
                    {

                        /*" -2500- ADD +1 TO V0NAES-ENDOSSEM */
                        V0NAES_ENDOSSEM.Value = V0NAES_ENDOSSEM + +1;

                        /*" -2501- MOVE V0NAES-ENDOSSEM TO WNUM-ENDOSSO */
                        _.Move(V0NAES_ENDOSSEM, AREA_DE_WORK.WNUM_ENDOSSO);

                        /*" -2502- ELSE */
                    }
                    else
                    {


                        /*" -2503- IF V1PROP-TIPO-ENDOS = '5' */

                        if (V1PROP_TIPO_ENDOS == "5")
                        {

                            /*" -2504- ADD +1 TO V0NAES-ENDOSCCR */
                            V0NAES_ENDOSCCR.Value = V0NAES_ENDOSCCR + +1;

                            /*" -2505- MOVE V0NAES-ENDOSCCR TO WNUM-ENDOSSO */
                            _.Move(V0NAES_ENDOSCCR, AREA_DE_WORK.WNUM_ENDOSSO);

                            /*" -2506- ELSE */
                        }
                        else
                        {


                            /*" -2507- IF V1PROP-TIPO-ENDOS = '6' */

                            if (V1PROP_TIPO_ENDOS == "6")
                            {

                                /*" -2508- ADD +1 TO V0NAES-ENDOSMVC */
                                V0NAES_ENDOSMVC.Value = V0NAES_ENDOSMVC + +1;

                                /*" -2509- MOVE V0NAES-ENDOSMVC TO WNUM-ENDOSSO */
                                _.Move(V0NAES_ENDOSMVC, AREA_DE_WORK.WNUM_ENDOSSO);

                                /*" -2510- ELSE */
                            }
                            else
                            {


                                /*" -2511- DISPLAY 'ENDOSSO INVALIDO  -  ' V1PROP-TIPO-ENDOS */
                                _.Display($"ENDOSSO INVALIDO  -  {V1PROP_TIPO_ENDOS}");

                                /*" -2512- DISPLAY 'TIPO PROPOSTA     -  ' V1PROP-TPPROPOS */
                                _.Display($"TIPO PROPOSTA     -  {V1PROP_TPPROPOS}");

                                /*" -2513- DISPLAY 'FONTE             -  ' V1PROP-FONTE */
                                _.Display($"FONTE             -  {V1PROP_FONTE}");

                                /*" -2514- DISPLAY 'NUM PROPOSTA      -  ' V1PROP-NRPROPOS */
                                _.Display($"NUM PROPOSTA      -  {V1PROP_NRPROPOS}");

                                /*" -2515- DISPLAY 'RAMO              -  ' V1PROP-RAMO */
                                _.Display($"RAMO              -  {V1PROP_RAMO}");

                                /*" -2517- GO TO R9999-00-ROT-ERRO. */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -2517- PERFORM R1410-00-UPDATE-NUMERO-AES. */

            R1410_00_UPDATE_NUMERO_AES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3211_99_SAIDA*/

        [StopWatch]
        /*" R3212-00-RECUPERA-RCAP-SECTION */
        private void R3212_00_RECUPERA_RCAP_SECTION()
        {
            /*" -2530- MOVE '322' TO WNR-EXEC-SQL. */
            _.Move("322", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2532- MOVE V0ENDO-NRRCAP TO RCAPS-NUM-RCAP. */
            _.Move(V0ENDO_NRRCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);

            /*" -2537- PERFORM R3212_00_RECUPERA_RCAP_DB_SELECT_1 */

            R3212_00_RECUPERA_RCAP_DB_SELECT_1();

            /*" -2540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2543- DISPLAY 'EM0005B - R3212 (ERRO SELECT RCAPS)' ' ' V1PROP-FONTE ' ' RCAPS-NUM-RCAP */

                $"EM0005B - R3212 (ERRO SELECT RCAPS) {V1PROP_FONTE} {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}"
                .Display();

                /*" -2543- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3212-00-RECUPERA-RCAP-DB-SELECT-1 */
        public void R3212_00_RECUPERA_RCAP_DB_SELECT_1()
        {
            /*" -2537- EXEC SQL SELECT DATA_CADASTRAMENTO INTO :RCAPS-DATA-CADASTRAMENTO FROM SEGUROS.RCAPS WHERE NUM_RCAP = :RCAPS-NUM-RCAP END-EXEC. */

            var r3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1 = new R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1.Execute(r3212_00_RECUPERA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3212_99_SAIDA*/

        [StopWatch]
        /*" R3215-00-RECUPERA-AU085-SECTION */
        private void R3215_00_RECUPERA_AU085_SECTION()
        {
            /*" -2556- MOVE '325' TO WNR-EXEC-SQL. */
            _.Move("325", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2562- PERFORM R3215_00_RECUPERA_AU085_DB_SELECT_1 */

            R3215_00_RECUPERA_AU085_DB_SELECT_1();

            /*" -2565- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2568- DISPLAY 'EM0005B - R3215 (ERRO SELECT AU085)' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"EM0005B - R3215 (ERRO SELECT AU085) {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -2568- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3215-00-RECUPERA-AU085-DB-SELECT-1 */
        public void R3215_00_RECUPERA_AU085_DB_SELECT_1()
        {
            /*" -2562- EXEC SQL SELECT IND_FORMA_PAGTO_AD INTO :AU085-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_PROPOSTA_COMPL WHERE COD_FONTE = :V1PROP-FONTE AND NUM_PROPOSTA = :V1PROP-NRPROPOS END-EXEC. */

            var r3215_00_RECUPERA_AU085_DB_SELECT_1_Query1 = new R3215_00_RECUPERA_AU085_DB_SELECT_1_Query1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R3215_00_RECUPERA_AU085_DB_SELECT_1_Query1.Execute(r3215_00_RECUPERA_AU085_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU085_IND_FORMA_PAGTO_AD, AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_99_SAIDA*/

        [StopWatch]
        /*" R3220-00-DECLARE-V1ACOMPROP-SECTION */
        private void R3220_00_DECLARE_V1ACOMPROP_SECTION()
        {
            /*" -2581- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2589- PERFORM R3220_00_DECLARE_V1ACOMPROP_DB_DECLARE_1 */

            R3220_00_DECLARE_V1ACOMPROP_DB_DECLARE_1();

            /*" -2591- PERFORM R3220_00_DECLARE_V1ACOMPROP_DB_OPEN_1 */

            R3220_00_DECLARE_V1ACOMPROP_DB_OPEN_1();

            /*" -2594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2595- DISPLAY 'EM0005B - R3220 (ERRO DECLARE V1ACOMPROP)' */
                _.Display($"EM0005B - R3220 (ERRO DECLARE V1ACOMPROP)");

                /*" -2595- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3220-00-DECLARE-V1ACOMPROP-DB-OPEN-1 */
        public void R3220_00_DECLARE_V1ACOMPROP_DB_OPEN_1()
        {
            /*" -2591- EXEC SQL OPEN V1ACOMPROP END-EXEC. */

            V1ACOMPROP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/

        [StopWatch]
        /*" R3221-00-FETCH-V1ACOMPROP-SECTION */
        private void R3221_00_FETCH_V1ACOMPROP_SECTION()
        {
            /*" -2608- MOVE '322' TO WNR-EXEC-SQL. */
            _.Move("322", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2611- PERFORM R3221_00_FETCH_V1ACOMPROP_DB_FETCH_1 */

            R3221_00_FETCH_V1ACOMPROP_DB_FETCH_1();

            /*" -2614- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2615- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2616- MOVE 'S' TO WFIM-V1ACOMPROP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1ACOMPROP);

                    /*" -2617- GO TO R3221-90-CLOSE */

                    R3221_90_CLOSE(); //GOTO
                    return;

                    /*" -2618- ELSE */
                }
                else
                {


                    /*" -2619- DISPLAY 'EM0005B - R3221 (ERRO FETCH V1ACOMPROP)' */
                    _.Display($"EM0005B - R3221 (ERRO FETCH V1ACOMPROP)");

                    /*" -2621- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2621- ADD 1 TO AC-S-ACOMPROP. */
            AREA_DE_WORK.AC_S_ACOMPROP.Value = AREA_DE_WORK.AC_S_ACOMPROP + 1;

            /*" -0- FLUXCONTROL_PERFORM R3221_90_CLOSE */

            R3221_90_CLOSE();

        }

        [StopWatch]
        /*" R3221-00-FETCH-V1ACOMPROP-DB-FETCH-1 */
        public void R3221_00_FETCH_V1ACOMPROP_DB_FETCH_1()
        {
            /*" -2611- EXEC SQL FETCH V1ACOMPROP INTO :V1APRO-DATOPR , :V1APRO-HORAOPER END-EXEC. */

            if (V1ACOMPROP.Fetch())
            {
                _.Move(V1ACOMPROP.V1APRO_DATOPR, V1APRO_DATOPR);
                _.Move(V1ACOMPROP.V1APRO_HORAOPER, V1APRO_HORAOPER);
            }

        }

        [StopWatch]
        /*" R3221-90-CLOSE */
        private void R3221_90_CLOSE(bool isPerform = false)
        {
            /*" -2625- PERFORM R3221_90_CLOSE_DB_CLOSE_1 */

            R3221_90_CLOSE_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R3221-90-CLOSE-DB-CLOSE-1 */
        public void R3221_90_CLOSE_DB_CLOSE_1()
        {
            /*" -2625- EXEC SQL CLOSE V1ACOMPROP END-EXEC. */

            V1ACOMPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3221_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-INSERT-V0APOLCORRET-SECTION */
        private void R3300_00_INSERT_V0APOLCORRET_SECTION()
        {
            /*" -2638- PERFORM R3310-00-FETCH-V1PROPCORRET */

            R3310_00_FETCH_V1PROPCORRET_SECTION();

            /*" -2639- IF WFIM-V1PROPCORRET NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPCORRET.IsEmpty())
            {

                /*" -2641- GO TO R3300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2643- PERFORM R3320-00-MONTA-V0APOLCORRET */

            R3320_00_MONTA_V0APOLCORRET_SECTION();

            /*" -2645- MOVE '330' TO WNR-EXEC-SQL. */
            _.Move("330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2661- PERFORM R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1 */

            R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1();

            /*" -2664- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2671- DISPLAY 'R3300-00 (REGISTRO DUPLICADO) ... ' ' V1PROP-FONTE = ' V1PROP-FONTE ' V1PROP-NRPROPOS = ' V1PROP-NRPROPOS ' V0ACOR-NUM-APOL = ' V0ACOR-NUM-APOL ' V0ACOR-RAMOFR = ' V0ACOR-RAMOFR ' V0ACOR-MODALIFR  = ' V0ACOR-MODALIFR ' V0ACOR-CODCORR = ' V0ACOR-CODCORR */

                $"R3300-00 (REGISTRO DUPLICADO) ...  V1PROP-FONTE = {V1PROP_FONTE} V1PROP-NRPROPOS = {V1PROP_NRPROPOS} V0ACOR-NUM-APOL = {V0ACOR_NUM_APOL} V0ACOR-RAMOFR = {V0ACOR_RAMOFR} V0ACOR-MODALIFR  = {V0ACOR_MODALIFR} V0ACOR-CODCORR = {V0ACOR_CODCORR}"
                .Display();

                /*" -2673- GO TO R3300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2681- DISPLAY 'R3300-00 (PROBLEMAS NA INSERCAO) ... ' ' V1PROP-FONTE = ' V1PROP-FONTE ' V1PROP-NRPROPOS = ' V1PROP-NRPROPOS ' V0ACOR-NUM-APOL = ' V0ACOR-NUM-APOL ' V0ACOR-RAMOFR = ' V0ACOR-RAMOFR ' V0ACOR-MODALIFR  = ' V0ACOR-MODALIFR ' V0ACOR-CODCORR = ' V0ACOR-CODCORR */

                $"R3300-00 (PROBLEMAS NA INSERCAO) ...  V1PROP-FONTE = {V1PROP_FONTE} V1PROP-NRPROPOS = {V1PROP_NRPROPOS} V0ACOR-NUM-APOL = {V0ACOR_NUM_APOL} V0ACOR-RAMOFR = {V0ACOR_RAMOFR} V0ACOR-MODALIFR  = {V0ACOR_MODALIFR} V0ACOR-CODCORR = {V0ACOR_CODCORR}"
                .Display();

                /*" -2683- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2685- ADD +1 TO AC-I-APOLCORRET. */
            AREA_DE_WORK.AC_I_APOLCORRET.Value = AREA_DE_WORK.AC_I_APOLCORRET + +1;

            /*" -2688- IF (V1PROP-CDFRACIO NOT EQUAL ZEROS) OR (V1PROP-PCDESCON NOT EQUAL ZEROS) OR (V1PROP-TPCORRET EQUAL '2' ) */

            if ((V1PROP_CDFRACIO != 00) || (V1PROP_PCDESCON != 00) || (V1PROP_TPCORRET == "2"))
            {

                /*" -2689- IF CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT */

                if (AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT)
                {

                    /*" -2690- PERFORM R3710-00-MONTA-REM0104B1 */

                    R3710_00_MONTA_REM0104B1_SECTION();

                    /*" -2691- PERFORM R3800-00-INSERT-V0EMISDIARIA */

                    R3800_00_INSERT_V0EMISDIARIA_SECTION();

                    /*" -2693- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT. */
                    _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);
                }

            }


            /*" -2694- IF V1PCOR-INDCRT EQUAL '1' */

            if (V1PCOR_INDCRT == "1")
            {

                /*" -2696- IF V1PCOR-CODCORR EQUAL CH-CORR-ANT NEXT SENTENCE */

                if (V1PCOR_CODCORR == AREA_DE_WORK.CH_CORR_ANT)
                {

                    /*" -2697- ELSE */
                }
                else
                {


                    /*" -2698- MOVE V1PCOR-CODCORR TO W1PCOR-CODCORR */
                    _.Move(V1PCOR_CODCORR, W1PCOR_CODCORR);

                    /*" -2699- MOVE V1PCOR-CODCORR TO CH-CORR-ANT */
                    _.Move(V1PCOR_CODCORR, AREA_DE_WORK.CH_CORR_ANT);

                    /*" -2699- PERFORM R5600-00-INSERT-V0MALHAPROD. */

                    R5600_00_INSERT_V0MALHAPROD_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3300-00-INSERT-V0APOLCORRET-DB-INSERT-1 */
        public void R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1()
        {
            /*" -2661- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0ACOR-NUM-APOL , :V0ACOR-RAMOFR , :V0ACOR-MODALIFR , :V0ACOR-CODCORR , :V0ACOR-CODSUBES , :V0ACOR-DTINIVIG , :V0ACOR-DTTERVIG , :V0ACOR-PCPARCOR , :V0ACOR-PCCOMCOR , :V0ACOR-TIPCOM , :V0ACOR-INDCRT , :V0ACOR-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP , :V0ACOR-COD-USUARIO) END-EXEC. */

            var r3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1 = new R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1()
            {
                V0ACOR_NUM_APOL = V0ACOR_NUM_APOL.ToString(),
                V0ACOR_RAMOFR = V0ACOR_RAMOFR.ToString(),
                V0ACOR_MODALIFR = V0ACOR_MODALIFR.ToString(),
                V0ACOR_CODCORR = V0ACOR_CODCORR.ToString(),
                V0ACOR_CODSUBES = V0ACOR_CODSUBES.ToString(),
                V0ACOR_DTINIVIG = V0ACOR_DTINIVIG.ToString(),
                V0ACOR_DTTERVIG = V0ACOR_DTTERVIG.ToString(),
                V0ACOR_PCPARCOR = V0ACOR_PCPARCOR.ToString(),
                V0ACOR_PCCOMCOR = V0ACOR_PCCOMCOR.ToString(),
                V0ACOR_TIPCOM = V0ACOR_TIPCOM.ToString(),
                V0ACOR_INDCRT = V0ACOR_INDCRT.ToString(),
                V0ACOR_COD_EMPRESA = V0ACOR_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0ACOR_COD_USUARIO = V0ACOR_COD_USUARIO.ToString(),
            };

            R3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1.Execute(r3300_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R3310-00-FETCH-V1PROPCORRET-SECTION */
        private void R3310_00_FETCH_V1PROPCORRET_SECTION()
        {
            /*" -2712- MOVE '331' TO WNR-EXEC-SQL. */
            _.Move("331", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2722- PERFORM R3310_00_FETCH_V1PROPCORRET_DB_FETCH_1 */

            R3310_00_FETCH_V1PROPCORRET_DB_FETCH_1();

            /*" -2725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2726- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2727- MOVE 'S' TO WFIM-V1PROPCORRET */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PROPCORRET);

                    /*" -2727- PERFORM R3310_00_FETCH_V1PROPCORRET_DB_CLOSE_1 */

                    R3310_00_FETCH_V1PROPCORRET_DB_CLOSE_1();

                    /*" -2729- GO TO R3310-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_99_SAIDA*/ //GOTO
                    return;

                    /*" -2730- ELSE */
                }
                else
                {


                    /*" -2731- DISPLAY 'EM0005B - ERRO FETCH V1PROPCORRET' */
                    _.Display($"EM0005B - ERRO FETCH V1PROPCORRET");

                    /*" -2733- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2734- IF V1PROP-DTINIVIG NOT LESS '2000-11-01' */

            if (V1PROP_DTINIVIG >= "2000-11-01")
            {

                /*" -2736- IF V1PCOR-CODCORR EQUAL 16144 OR V1PCOR-CODCORR EQUAL 17604 */

                if (V1PCOR_CODCORR == 16144 || V1PCOR_CODCORR == 17604)
                {

                    /*" -2739- IF V1PROP-CODPRODU EQUAL 3101 OR V1PROP-CODPRODU EQUAL 3107 OR V1PROP-CODPRODU EQUAL 3109 */

                    if (V1PROP_CODPRODU == 3101 || V1PROP_CODPRODU == 3107 || V1PROP_CODPRODU == 3109)
                    {

                        /*" -2740- MOVE 2 TO V1PCOR-PCCOMCOR */
                        _.Move(2, V1PCOR_PCCOMCOR);

                        /*" -2741- END-IF */
                    }


                    /*" -2747- IF V1PROP-CODPRODU EQUAL 3102 OR V1PROP-CODPRODU EQUAL 3105 OR V1PROP-CODPRODU EQUAL 3106 OR V1PROP-CODPRODU EQUAL 3110 OR V1PROP-CODPRODU EQUAL 3111 OR V1PROP-CODPRODU EQUAL 3114 */

                    if (V1PROP_CODPRODU == 3102 || V1PROP_CODPRODU == 3105 || V1PROP_CODPRODU == 3106 || V1PROP_CODPRODU == 3110 || V1PROP_CODPRODU == 3111 || V1PROP_CODPRODU == 3114)
                    {

                        /*" -2748- MOVE 1 TO V1PCOR-PCCOMCOR */
                        _.Move(1, V1PCOR_PCCOMCOR);

                        /*" -2749- END-IF */
                    }


                    /*" -2750- END-IF */
                }


                /*" -2752- END-IF. */
            }


            /*" -2753- MOVE V1PCOR-FONTE TO CH-FTE-ATU */
            _.Move(V1PCOR_FONTE, AREA_DE_WORK.CH_CHAVE_ATU.CH_FTE_ATU);

            /*" -2754- MOVE V1PCOR-NRPROPOS TO CH-NRP-ATU */
            _.Move(V1PCOR_NRPROPOS, AREA_DE_WORK.CH_CHAVE_ATU.CH_NRP_ATU);

            /*" -2755- MOVE V1PCOR-CODCORR TO CH-COR-ATU */
            _.Move(V1PCOR_CODCORR, AREA_DE_WORK.CH_CHAVE_ATU.CH_COR_ATU);

            /*" -2756- MOVE V1PCOR-RAMOFR TO CH-RAM-ATU */
            _.Move(V1PCOR_RAMOFR, AREA_DE_WORK.CH_CHAVE_ATU.CH_RAM_ATU);

            /*" -2758- MOVE V1PCOR-MODALIFR TO CH-MOD-ATU. */
            _.Move(V1PCOR_MODALIFR, AREA_DE_WORK.CH_CHAVE_ATU.CH_MOD_ATU);

            /*" -2758- ADD 1 TO AC-S-PROPCORRET. */
            AREA_DE_WORK.AC_S_PROPCORRET.Value = AREA_DE_WORK.AC_S_PROPCORRET + 1;

        }

        [StopWatch]
        /*" R3310-00-FETCH-V1PROPCORRET-DB-FETCH-1 */
        public void R3310_00_FETCH_V1PROPCORRET_DB_FETCH_1()
        {
            /*" -2722- EXEC SQL FETCH V1PROPCORRET INTO :V1PCOR-FONTE , :V1PCOR-NRPROPOS , :V1PCOR-CODCORR , :V1PCOR-RAMOFR , :V1PCOR-MODALIFR , :V1PCOR-PCPARCOR , :V1PCOR-PCCOMCOR , :V1PCOR-INDCRT , :V1PCOR-COD-USUARIO END-EXEC. */

            if (V1PROPCORRET.Fetch())
            {
                _.Move(V1PROPCORRET.V1PCOR_FONTE, V1PCOR_FONTE);
                _.Move(V1PROPCORRET.V1PCOR_NRPROPOS, V1PCOR_NRPROPOS);
                _.Move(V1PROPCORRET.V1PCOR_CODCORR, V1PCOR_CODCORR);
                _.Move(V1PROPCORRET.V1PCOR_RAMOFR, V1PCOR_RAMOFR);
                _.Move(V1PROPCORRET.V1PCOR_MODALIFR, V1PCOR_MODALIFR);
                _.Move(V1PROPCORRET.V1PCOR_PCPARCOR, V1PCOR_PCPARCOR);
                _.Move(V1PROPCORRET.V1PCOR_PCCOMCOR, V1PCOR_PCCOMCOR);
                _.Move(V1PROPCORRET.V1PCOR_INDCRT, V1PCOR_INDCRT);
                _.Move(V1PROPCORRET.V1PCOR_COD_USUARIO, V1PCOR_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R3310-00-FETCH-V1PROPCORRET-DB-CLOSE-1 */
        public void R3310_00_FETCH_V1PROPCORRET_DB_CLOSE_1()
        {
            /*" -2727- EXEC SQL CLOSE V1PROPCORRET END-EXEC */

            V1PROPCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_99_SAIDA*/

        [StopWatch]
        /*" R3320-00-MONTA-V0APOLCORRET-SECTION */
        private void R3320_00_MONTA_V0APOLCORRET_SECTION()
        {
            /*" -2771- MOVE '332' TO WNR-EXEC-SQL. */
            _.Move("332", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2772- MOVE WNUM-APOLICE TO V0ACOR-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0ACOR_NUM_APOL);

            /*" -2773- MOVE V1PCOR-RAMOFR TO V0ACOR-RAMOFR */
            _.Move(V1PCOR_RAMOFR, V0ACOR_RAMOFR);

            /*" -2774- MOVE V1PCOR-MODALIFR TO V0ACOR-MODALIFR */
            _.Move(V1PCOR_MODALIFR, V0ACOR_MODALIFR);

            /*" -2775- MOVE V1PCOR-CODCORR TO V0ACOR-CODCORR */
            _.Move(V1PCOR_CODCORR, V0ACOR_CODCORR);

            /*" -2776- MOVE ZEROS TO V0ACOR-CODSUBES */
            _.Move(0, V0ACOR_CODSUBES);

            /*" -2777- MOVE V1PROP-DTINIVIG TO V0ACOR-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0ACOR_DTINIVIG);

            /*" -2778- MOVE V1PROP-DTTERVIG TO V0ACOR-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0ACOR_DTTERVIG);

            /*" -2779- MOVE V1PCOR-PCPARCOR TO V0ACOR-PCPARCOR */
            _.Move(V1PCOR_PCPARCOR, V0ACOR_PCPARCOR);

            /*" -2780- MOVE V1PCOR-PCCOMCOR TO V0ACOR-PCCOMCOR */
            _.Move(V1PCOR_PCCOMCOR, V0ACOR_PCCOMCOR);

            /*" -2781- MOVE '1' TO V0ACOR-TIPCOM */
            _.Move("1", V0ACOR_TIPCOM);

            /*" -2782- MOVE V1PCOR-INDCRT TO V0ACOR-INDCRT */
            _.Move(V1PCOR_INDCRT, V0ACOR_INDCRT);

            /*" -2783- MOVE V1PROP-COD-EMPRESA TO V0ACOR-COD-EMPRESA. */
            _.Move(V1PROP_COD_EMPRESA, V0ACOR_COD_EMPRESA);

            /*" -2783- MOVE V1PCOR-COD-USUARIO TO V0ACOR-COD-USUARIO. */
            _.Move(V1PCOR_COD_USUARIO, V0ACOR_COD_USUARIO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3320_99_SAIDA*/

        [StopWatch]
        /*" R3400-00-INSERT-V0APOLCOSCED-SECTION */
        private void R3400_00_INSERT_V0APOLCOSCED_SECTION()
        {
            /*" -2795- IF V1PROP-PODPUBL EQUAL 'N' */

            if (V1PROP_PODPUBL == "N")
            {

                /*" -2796- PERFORM R3410-00-FETCH-V1PROPCOSCED */

                R3410_00_FETCH_V1PROPCOSCED_SECTION();

                /*" -2797- IF WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty())
                {

                    /*" -2798- GO TO R3400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/ //GOTO
                    return;

                    /*" -2800- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -2801- ELSE */
                }

            }
            else
            {


                /*" -2802- PERFORM R3430-00-FETCH-V1COSSEGSORT */

                R3430_00_FETCH_V1COSSEGSORT_SECTION();

                /*" -2803- IF WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty())
                {

                    /*" -2805- GO TO R3400-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2807- PERFORM R3420-00-MONTA-V0APOLCOSCED */

            R3420_00_MONTA_V0APOLCOSCED_SECTION();

            /*" -2809- MOVE '340' TO WNR-EXEC-SQL. */
            _.Move("340", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2820- PERFORM R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1 */

            R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1();

            /*" -2826- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2828- GO TO R3400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2832- DISPLAY 'R3400-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R3400-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -2834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2834- ADD +1 TO AC-I-APOLCOSCED. */
            AREA_DE_WORK.AC_I_APOLCOSCED.Value = AREA_DE_WORK.AC_I_APOLCOSCED + +1;

        }

        [StopWatch]
        /*" R3400-00-INSERT-V0APOLCOSCED-DB-INSERT-1 */
        public void R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1()
        {
            /*" -2820- EXEC SQL INSERT INTO SEGUROS.V0APOLCOSCED VALUES (:V0ACCD-NUM-APOL , :V0ACCD-CODCOSS , :V0ACCD-RAMOFR , :V0ACCD-DTINIVIG , :V0ACCD-DTTERVIG , :V0ACCD-PCPARTIC , :V0ACCD-PCCOMCOS , :V0ACCD-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 = new R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0ACCD_NUM_APOL = V0ACCD_NUM_APOL.ToString(),
                V0ACCD_CODCOSS = V0ACCD_CODCOSS.ToString(),
                V0ACCD_RAMOFR = V0ACCD_RAMOFR.ToString(),
                V0ACCD_DTINIVIG = V0ACCD_DTINIVIG.ToString(),
                V0ACCD_DTTERVIG = V0ACCD_DTTERVIG.ToString(),
                V0ACCD_PCPARTIC = V0ACCD_PCPARTIC.ToString(),
                V0ACCD_PCCOMCOS = V0ACCD_PCCOMCOS.ToString(),
                V0ACCD_COD_EMPRESA = V0ACCD_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1.Execute(r3400_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_99_SAIDA*/

        [StopWatch]
        /*" R3410-00-FETCH-V1PROPCOSCED-SECTION */
        private void R3410_00_FETCH_V1PROPCOSCED_SECTION()
        {
            /*" -2847- MOVE '341' TO WNR-EXEC-SQL. */
            _.Move("341", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2854- PERFORM R3410_00_FETCH_V1PROPCOSCED_DB_FETCH_1 */

            R3410_00_FETCH_V1PROPCOSCED_DB_FETCH_1();

            /*" -2857- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2858- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2859- MOVE 'S' TO WFIM-V1PROPCOSCED */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PROPCOSCED);

                    /*" -2859- PERFORM R3410_00_FETCH_V1PROPCOSCED_DB_CLOSE_1 */

                    R3410_00_FETCH_V1PROPCOSCED_DB_CLOSE_1();

                    /*" -2861- GO TO R3410-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/ //GOTO
                    return;

                    /*" -2862- ELSE */
                }
                else
                {


                    /*" -2863- DISPLAY 'EM0005B - R3410 (ERRO FETCH V1PROPCOSCED)' */
                    _.Display($"EM0005B - R3410 (ERRO FETCH V1PROPCOSCED)");

                    /*" -2865- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2866- ADD V1PCCD-PCPARTIC TO W0APOL-PCTCED */
            W0APOL_PCTCED.Value = W0APOL_PCTCED + V1PCCD_PCPARTIC;

            /*" -2868- ADD +1 TO W0APOL-QTCOSSEG. */
            W0APOL_QTCOSSEG.Value = W0APOL_QTCOSSEG + +1;

            /*" -2868- ADD 1 TO AC-S-PROPCOSCED. */
            AREA_DE_WORK.AC_S_PROPCOSCED.Value = AREA_DE_WORK.AC_S_PROPCOSCED + 1;

        }

        [StopWatch]
        /*" R3410-00-FETCH-V1PROPCOSCED-DB-FETCH-1 */
        public void R3410_00_FETCH_V1PROPCOSCED_DB_FETCH_1()
        {
            /*" -2854- EXEC SQL FETCH V1PROPCOSCED INTO :V1PCCD-FONTE , :V1PCCD-NRPROPOS , :V1PCCD-CODCOSS , :V1PCCD-RAMOFR , :V1PCCD-PCPARTIC , :V1PCCD-PCCOMCOS END-EXEC. */

            if (V1PROPCOSCED.Fetch())
            {
                _.Move(V1PROPCOSCED.V1PCCD_FONTE, V1PCCD_FONTE);
                _.Move(V1PROPCOSCED.V1PCCD_NRPROPOS, V1PCCD_NRPROPOS);
                _.Move(V1PROPCOSCED.V1PCCD_CODCOSS, V1PCCD_CODCOSS);
                _.Move(V1PROPCOSCED.V1PCCD_RAMOFR, V1PCCD_RAMOFR);
                _.Move(V1PROPCOSCED.V1PCCD_PCPARTIC, V1PCCD_PCPARTIC);
                _.Move(V1PROPCOSCED.V1PCCD_PCCOMCOS, V1PCCD_PCCOMCOS);
            }

        }

        [StopWatch]
        /*" R3410-00-FETCH-V1PROPCOSCED-DB-CLOSE-1 */
        public void R3410_00_FETCH_V1PROPCOSCED_DB_CLOSE_1()
        {
            /*" -2859- EXEC SQL CLOSE V1PROPCOSCED END-EXEC */

            V1PROPCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3410_99_SAIDA*/

        [StopWatch]
        /*" R3420-00-MONTA-V0APOLCOSCED-SECTION */
        private void R3420_00_MONTA_V0APOLCOSCED_SECTION()
        {
            /*" -2881- MOVE '342' TO WNR-EXEC-SQL. */
            _.Move("342", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2882- MOVE WNUM-APOLICE TO V0ACCD-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0ACCD_NUM_APOL);

            /*" -2883- MOVE V1PROP-DTINIVIG TO V0ACCD-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0ACCD_DTINIVIG);

            /*" -2884- MOVE V1PROP-DTTERVIG TO V0ACCD-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0ACCD_DTTERVIG);

            /*" -2886- MOVE V1PROP-COD-EMPRESA TO V0ACCD-COD-EMPRESA. */
            _.Move(V1PROP_COD_EMPRESA, V0ACCD_COD_EMPRESA);

            /*" -2888- IF V1PCCD-CODCOSS EQUAL 5240 */

            if (V1PCCD_CODCOSS == 5240)
            {

                /*" -2890- MOVE WS-COD-CONGENERE TO V1PCCD-CODCOSS. */
                _.Move(WS_COD_CONGENERE, V1PCCD_CODCOSS);
            }


            /*" -2891- IF V1PROP-PODPUBL EQUAL 'N' */

            if (V1PROP_PODPUBL == "N")
            {

                /*" -2892- MOVE V1PCCD-CODCOSS TO V0ACCD-CODCOSS */
                _.Move(V1PCCD_CODCOSS, V0ACCD_CODCOSS);

                /*" -2893- MOVE V1PCCD-RAMOFR TO V0ACCD-RAMOFR */
                _.Move(V1PCCD_RAMOFR, V0ACCD_RAMOFR);

                /*" -2894- MOVE V1PCCD-PCPARTIC TO V0ACCD-PCPARTIC */
                _.Move(V1PCCD_PCPARTIC, V0ACCD_PCPARTIC);

                /*" -2895- MOVE V1PCCD-PCCOMCOS TO V0ACCD-PCCOMCOS */
                _.Move(V1PCCD_PCCOMCOS, V0ACCD_PCCOMCOS);

                /*" -2896- ELSE */
            }
            else
            {


                /*" -2897- MOVE V1COSS-CONGENER TO V0ACCD-CODCOSS */
                _.Move(V1COSS_CONGENER, V0ACCD_CODCOSS);

                /*" -2898- MOVE V1COSS-RAMO TO V0ACCD-RAMOFR */
                _.Move(V1COSS_RAMO, V0ACCD_RAMOFR);

                /*" -2899- MOVE V1COSS-PCPARTIC TO V0ACCD-PCPARTIC */
                _.Move(V1COSS_PCPARTIC, V0ACCD_PCPARTIC);

                /*" -2899- MOVE V1COSS-PCCOMCOS TO V0ACCD-PCCOMCOS. */
                _.Move(V1COSS_PCCOMCOS, V0ACCD_PCCOMCOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3420_99_SAIDA*/

        [StopWatch]
        /*" R3430-00-FETCH-V1COSSEGSORT-SECTION */
        private void R3430_00_FETCH_V1COSSEGSORT_SECTION()
        {
            /*" -2912- MOVE '343' TO WNR-EXEC-SQL. */
            _.Move("343", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2918- PERFORM R3430_00_FETCH_V1COSSEGSORT_DB_FETCH_1 */

            R3430_00_FETCH_V1COSSEGSORT_DB_FETCH_1();

            /*" -2921- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2922- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2923- MOVE 'S' TO WFIM-V1PROPCOSCED */
                    _.Move("S", AREA_DE_WORK.WFIM_V1PROPCOSCED);

                    /*" -2923- PERFORM R3430_00_FETCH_V1COSSEGSORT_DB_CLOSE_1 */

                    R3430_00_FETCH_V1COSSEGSORT_DB_CLOSE_1();

                    /*" -2925- GO TO R3430-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3430_99_SAIDA*/ //GOTO
                    return;

                    /*" -2926- ELSE */
                }
                else
                {


                    /*" -2927- DISPLAY 'EM0005B - R3430 (ERRO FETCH V1COSSEGSORT)' */
                    _.Display($"EM0005B - R3430 (ERRO FETCH V1COSSEGSORT)");

                    /*" -2929- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2930- ADD V1COSS-PCPARTIC TO W0APOL-PCTCED */
            W0APOL_PCTCED.Value = W0APOL_PCTCED + V1COSS_PCPARTIC;

            /*" -2932- ADD +1 TO W0APOL-QTCOSSEG. */
            W0APOL_QTCOSSEG.Value = W0APOL_QTCOSSEG + +1;

            /*" -2932- ADD 1 TO AC-S-COSSEGSORT. */
            AREA_DE_WORK.AC_S_COSSEGSORT.Value = AREA_DE_WORK.AC_S_COSSEGSORT + 1;

        }

        [StopWatch]
        /*" R3430-00-FETCH-V1COSSEGSORT-DB-FETCH-1 */
        public void R3430_00_FETCH_V1COSSEGSORT_DB_FETCH_1()
        {
            /*" -2918- EXEC SQL FETCH V1COSSEGSORT INTO :V1COSS-RAMO , :V1COSS-CONGENER , :V1COSS-PCCOMCOS , :V1COSS-PCPARTIC , :V1COSS-SITUACAO END-EXEC. */

            if (V1COSSEGSORT.Fetch())
            {
                _.Move(V1COSSEGSORT.V1COSS_RAMO, V1COSS_RAMO);
                _.Move(V1COSSEGSORT.V1COSS_CONGENER, V1COSS_CONGENER);
                _.Move(V1COSSEGSORT.V1COSS_PCCOMCOS, V1COSS_PCCOMCOS);
                _.Move(V1COSSEGSORT.V1COSS_PCPARTIC, V1COSS_PCPARTIC);
                _.Move(V1COSSEGSORT.V1COSS_SITUACAO, V1COSS_SITUACAO);
            }

        }

        [StopWatch]
        /*" R3430-00-FETCH-V1COSSEGSORT-DB-CLOSE-1 */
        public void R3430_00_FETCH_V1COSSEGSORT_DB_CLOSE_1()
        {
            /*" -2923- EXEC SQL CLOSE V1COSSEGSORT END-EXEC */

            V1COSSEGSORT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3430_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-INSERT-V0COBERAPOL-SECTION */
        private void R3500_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -2945- MOVE '350' TO WNR-EXEC-SQL. */
            _.Move("350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2946- MOVE ZEROS TO W0COBA-IMP-SEG-IX */
            _.Move(0, W0COBA_IMP_SEG_IX);

            /*" -2947- MOVE ZEROS TO W0COBA-PRM-TAR-IX */
            _.Move(0, W0COBA_PRM_TAR_IX);

            /*" -2948- MOVE ZEROS TO W0COBA-IMP-SEG-VR */
            _.Move(0, W0COBA_IMP_SEG_VR);

            /*" -2950- MOVE ZEROS TO W0COBA-PRM-TAR-VR */
            _.Move(0, W0COBA_PRM_TAR_VR);

            /*" -2952- MOVE CH-COBER-ATU TO CH-COBER-ANT */
            _.Move(AREA_DE_WORK.CH_COBER_ATU, AREA_DE_WORK.CH_COBER_ANT);

            /*" -2955- PERFORM R3520-00-INSERE-COBER-ITEM UNTIL CH-COBER-ATU NOT EQUAL CH-COBER-ANT */

            while (!(AREA_DE_WORK.CH_COBER_ATU != AREA_DE_WORK.CH_COBER_ANT))
            {

                R3520_00_INSERE_COBER_ITEM_SECTION();
            }

            /*" -2957- PERFORM R3521-00-MONTA-COBER-TOT */

            R3521_00_MONTA_COBER_TOT_SECTION();

            /*" -2957- PERFORM R3530-00-INSERE-V0COBERAPOL. */

            R3530_00_INSERE_V0COBERAPOL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R3510-00-FETCH-V1COBERPROP-SECTION */
        private void R3510_00_FETCH_V1COBERPROP_SECTION()
        {
            /*" -2970- MOVE '351' TO WNR-EXEC-SQL. */
            _.Move("351", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2981- PERFORM R3510_00_FETCH_V1COBERPROP_DB_FETCH_1 */

            R3510_00_FETCH_V1COBERPROP_DB_FETCH_1();

            /*" -2984- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2985- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2986- MOVE HIGH-VALUES TO CH-COBER-ATU */

                    AREA_DE_WORK.CH_COBER_ATU.IsHighValues = true;

                    /*" -2987- MOVE 'S' TO WFIM-V1COBERPROP */
                    _.Move("S", AREA_DE_WORK.WFIM_V1COBERPROP);

                    /*" -2987- PERFORM R3510_00_FETCH_V1COBERPROP_DB_CLOSE_1 */

                    R3510_00_FETCH_V1COBERPROP_DB_CLOSE_1();

                    /*" -2989- GO TO R3510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3510_99_SAIDA*/ //GOTO
                    return;

                    /*" -2990- ELSE */
                }
                else
                {


                    /*" -2991- DISPLAY 'EM0005B - R3510 (ERRO FETCH V1COBERPROP)' */
                    _.Display($"EM0005B - R3510 (ERRO FETCH V1COBERPROP)");

                    /*" -2993- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2994- MOVE V1COBP-FONTE TO CH-FONT-ATU */
            _.Move(V1COBP_FONTE, AREA_DE_WORK.CH_COBER_ATU.CH_FONT_ATU);

            /*" -2995- MOVE V1COBP-NRPROPOS TO CH-PROP-ATU */
            _.Move(V1COBP_NRPROPOS, AREA_DE_WORK.CH_COBER_ATU.CH_PROP_ATU);

            /*" -2997- MOVE V1COBP-RAMOFR TO CH-RAMO-ATU. */
            _.Move(V1COBP_RAMOFR, AREA_DE_WORK.CH_COBER_ATU.CH_RAMO_ATU);

            /*" -2997- ADD 1 TO AC-S-COBERPROP. */
            AREA_DE_WORK.AC_S_COBERPROP.Value = AREA_DE_WORK.AC_S_COBERPROP + 1;

        }

        [StopWatch]
        /*" R3510-00-FETCH-V1COBERPROP-DB-FETCH-1 */
        public void R3510_00_FETCH_V1COBERPROP_DB_FETCH_1()
        {
            /*" -2981- EXEC SQL FETCH V1COBERPROP INTO :V1COBP-FONTE , :V1COBP-NRPROPOS , :V1COBP-NUM-ITEM , :V1COBP-RAMOFR , :V1COBP-MODALIFR , :V1COBP-COD-COBER , :V1COBP-IMP-SEG-IX , :V1COBP-PRM-TAR-IX , :V1COBP-DAT-INIVIG , :V1COBP-DAT-TERVIG END-EXEC. */

            if (V1COBERPROP.Fetch())
            {
                _.Move(V1COBERPROP.V1COBP_FONTE, V1COBP_FONTE);
                _.Move(V1COBERPROP.V1COBP_NRPROPOS, V1COBP_NRPROPOS);
                _.Move(V1COBERPROP.V1COBP_NUM_ITEM, V1COBP_NUM_ITEM);
                _.Move(V1COBERPROP.V1COBP_RAMOFR, V1COBP_RAMOFR);
                _.Move(V1COBERPROP.V1COBP_MODALIFR, V1COBP_MODALIFR);
                _.Move(V1COBERPROP.V1COBP_COD_COBER, V1COBP_COD_COBER);
                _.Move(V1COBERPROP.V1COBP_IMP_SEG_IX, V1COBP_IMP_SEG_IX);
                _.Move(V1COBERPROP.V1COBP_PRM_TAR_IX, V1COBP_PRM_TAR_IX);
                _.Move(V1COBERPROP.V1COBP_DAT_INIVIG, V1COBP_DAT_INIVIG);
                _.Move(V1COBERPROP.V1COBP_DAT_TERVIG, V1COBP_DAT_TERVIG);
            }

        }

        [StopWatch]
        /*" R3510-00-FETCH-V1COBERPROP-DB-CLOSE-1 */
        public void R3510_00_FETCH_V1COBERPROP_DB_CLOSE_1()
        {
            /*" -2987- EXEC SQL CLOSE V1COBERPROP END-EXEC */

            V1COBERPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3510_99_SAIDA*/

        [StopWatch]
        /*" R3520-00-INSERE-COBER-ITEM-SECTION */
        private void R3520_00_INSERE_COBER_ITEM_SECTION()
        {
            /*" -3010- MOVE '352' TO WNR-EXEC-SQL. */
            _.Move("352", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3011- ADD V1COBP-IMP-SEG-IX TO W0COBA-IMP-SEG-IX */
            W0COBA_IMP_SEG_IX.Value = W0COBA_IMP_SEG_IX + V1COBP_IMP_SEG_IX;

            /*" -3012- ADD V1COBP-PRM-TAR-IX TO W0COBA-PRM-TAR-IX */
            W0COBA_PRM_TAR_IX.Value = W0COBA_PRM_TAR_IX + V1COBP_PRM_TAR_IX;

            /*" -3013- ADD V1COBP-IMP-SEG-IX TO W0COBA-IMP-SEG-VR */
            W0COBA_IMP_SEG_VR.Value = W0COBA_IMP_SEG_VR + V1COBP_IMP_SEG_IX;

            /*" -3015- ADD V1COBP-PRM-TAR-IX TO W0COBA-PRM-TAR-VR */
            W0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR + V1COBP_PRM_TAR_IX;

            /*" -3016- MOVE V0ENDO-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0COBA_NUM_APOL);

            /*" -3017- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -3019- MOVE V1COBP-NUM-ITEM TO V0COBA-NUM-ITEM */
            _.Move(V1COBP_NUM_ITEM, V0COBA_NUM_ITEM);

            /*" -3020- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -3021- MOVE V1COBP-RAMOFR TO V0COBA-RAMOFR */
            _.Move(V1COBP_RAMOFR, V0COBA_RAMOFR);

            /*" -3022- MOVE V1COBP-MODALIFR TO V0COBA-MODALIFR */
            _.Move(V1COBP_MODALIFR, V0COBA_MODALIFR);

            /*" -3023- MOVE V1COBP-COD-COBER TO V0COBA-COD-COBER */
            _.Move(V1COBP_COD_COBER, V0COBA_COD_COBER);

            /*" -3024- MOVE V1COBP-IMP-SEG-IX TO V0COBA-IMP-SEG-IX */
            _.Move(V1COBP_IMP_SEG_IX, V0COBA_IMP_SEG_IX);

            /*" -3025- MOVE V1COBP-PRM-TAR-IX TO V0COBA-PRM-TAR-IX */
            _.Move(V1COBP_PRM_TAR_IX, V0COBA_PRM_TAR_IX);

            /*" -3026- MOVE V1COBP-IMP-SEG-IX TO V0COBA-IMP-SEG-VR */
            _.Move(V1COBP_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -3028- MOVE V1COBP-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
            _.Move(V1COBP_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -3030- MOVE ZEROS TO V0COBA-PCT-COBERT */
            _.Move(0, V0COBA_PCT_COBERT);

            /*" -3031- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -3032- MOVE V1COBP-DAT-INIVIG TO V0COBA-DATA-INIVI */
            _.Move(V1COBP_DAT_INIVIG, V0COBA_DATA_INIVI);

            /*" -3033- MOVE V1COBP-DAT-TERVIG TO V0COBA-DATA-TERVI */
            _.Move(V1COBP_DAT_TERVIG, V0COBA_DATA_TERVI);

            /*" -3035- MOVE V1PROP-COD-EMPRESA TO V0COBA-COD-EMPRESA */
            _.Move(V1PROP_COD_EMPRESA, V0COBA_COD_EMPRESA);

            /*" -3037- MOVE '0' TO V0COBA-SITREG */
            _.Move("0", V0COBA_SITREG);

            /*" -3038- IF V1COBP-NUM-ITEM EQUAL ZEROS */

            if (V1COBP_NUM_ITEM == 00)
            {

                /*" -3040- GO TO R3520-90-LEITURA-COBERPROP. */

                R3520_90_LEITURA_COBERPROP(); //GOTO
                return;
            }


            /*" -3040- PERFORM R3530-00-INSERE-V0COBERAPOL. */

            R3530_00_INSERE_V0COBERAPOL_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R3520_90_LEITURA_COBERPROP */

            R3520_90_LEITURA_COBERPROP();

        }

        [StopWatch]
        /*" R3520-90-LEITURA-COBERPROP */
        private void R3520_90_LEITURA_COBERPROP(bool isPerform = false)
        {
            /*" -3044- PERFORM R3510-00-FETCH-V1COBERPROP. */

            R3510_00_FETCH_V1COBERPROP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3520_99_SAIDA*/

        [StopWatch]
        /*" R3521-00-MONTA-COBER-TOT-SECTION */
        private void R3521_00_MONTA_COBER_TOT_SECTION()
        {
            /*" -3057- MOVE '35X' TO WNR-EXEC-SQL. */
            _.Move("35X", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3058- MOVE V0ENDO-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0COBA_NUM_APOL);

            /*" -3059- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -3061- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -3063- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -3065- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -3066- MOVE W0COBA-IMP-SEG-IX TO V0COBA-IMP-SEG-IX */
            _.Move(W0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_IX);

            /*" -3067- MOVE W0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-IX */
            _.Move(W0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_IX);

            /*" -3068- MOVE W0COBA-IMP-SEG-VR TO V0COBA-IMP-SEG-VR */
            _.Move(W0COBA_IMP_SEG_VR, V0COBA_IMP_SEG_VR);

            /*" -3070- MOVE W0COBA-PRM-TAR-VR TO V0COBA-PRM-TAR-VR */
            _.Move(W0COBA_PRM_TAR_VR, V0COBA_PRM_TAR_VR);

            /*" -3071- IF W0COBA-PRM-TAR-VR NOT EQUAL 0 */

            if (W0COBA_PRM_TAR_VR != 0)
            {

                /*" -3074- COMPUTE V0COBA-PCT-COBERT = W0COBA-PRM-TAR-VR * 100 / W1COBP-PRM-TAR-VR */
                V0COBA_PCT_COBERT.Value = W0COBA_PRM_TAR_VR * 100 / W1COBP_PRM_TAR_VR;

                /*" -3075- ELSE */
            }
            else
            {


                /*" -3077- MOVE ZEROS TO V0COBA-PCT-COBERT. */
                _.Move(0, V0COBA_PCT_COBERT);
            }


            /*" -3079- ADD V0COBA-PCT-COBERT TO W1COBP-PCT-TOTAL */
            W1COBP_PCT_TOTAL.Value = W1COBP_PCT_TOTAL + V0COBA_PCT_COBERT;

            /*" -3081- MOVE 1 TO V0COBA-FATOR-MULT. */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -3081- MOVE '0' TO V0COBA-SITREG. */
            _.Move("0", V0COBA_SITREG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3521_99_SAIDA*/

        [StopWatch]
        /*" R3530-00-INSERE-V0COBERAPOL-SECTION */
        private void R3530_00_INSERE_V0COBERAPOL_SECTION()
        {
            /*" -3094- MOVE '353' TO WNR-EXEC-SQL. */
            _.Move("353", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3114- PERFORM R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1 */

            R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1();

            /*" -3123- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3125- GO TO R3530-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3530_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3132- DISPLAY 'R3530-00 (PROBLEMAS NA INSERCAO) ... ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM '  ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R3530-00 (PROBLEMAS NA INSERCAO) ... {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3134- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3136- MOVE '*' TO CH-I-V0COBERAPOL. */
            _.Move("*", AREA_DE_WORK.CH_I_V0COBERAPOL);

            /*" -3136- ADD 1 TO AC-I-COBERAPOL. */
            AREA_DE_WORK.AC_I_COBERAPOL.Value = AREA_DE_WORK.AC_I_COBERAPOL + 1;

        }

        [StopWatch]
        /*" R3530-00-INSERE-V0COBERAPOL-DB-INSERT-1 */
        public void R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -3114- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP, :V0COBA-SITREG) END-EXEC. */

            var r3530_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1 = new R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1()
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
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0COBA_SITREG = V0COBA_SITREG.ToString(),
            };

            R3530_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r3530_00_INSERE_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3530_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-INSERT-V0ACOMPROP-SECTION */
        private void R3600_00_INSERT_V0ACOMPROP_SECTION()
        {
            /*" -3149- PERFORM R3610-00-MONTA-V0ACOMPROP */

            R3610_00_MONTA_V0ACOMPROP_SECTION();

            /*" -3151- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3162- PERFORM R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1 */

            R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1();

            /*" -3168- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3170- GO TO R3600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3171- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3174- DISPLAY 'R3600-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R3600-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3176- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3176- ADD +1 TO AC-I-ACOMPROP. */
            AREA_DE_WORK.AC_I_ACOMPROP.Value = AREA_DE_WORK.AC_I_ACOMPROP + +1;

        }

        [StopWatch]
        /*" R3600-00-INSERT-V0ACOMPROP-DB-INSERT-1 */
        public void R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1()
        {
            /*" -3162- EXEC SQL INSERT INTO SEGUROS.V0ACOMPROP VALUES (:V0APRO-FONTE , :V0APRO-NRPROPOS , :V0APRO-OPERACAO , :V0APRO-DATOPR , :V0APRO-HORAOPER , :V0APRO-OCORHIST , :V0APRO-CODUSU , :V0APRO-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r3600_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1 = new R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1()
            {
                V0APRO_FONTE = V0APRO_FONTE.ToString(),
                V0APRO_NRPROPOS = V0APRO_NRPROPOS.ToString(),
                V0APRO_OPERACAO = V0APRO_OPERACAO.ToString(),
                V0APRO_DATOPR = V0APRO_DATOPR.ToString(),
                V0APRO_HORAOPER = V0APRO_HORAOPER.ToString(),
                V0APRO_OCORHIST = V0APRO_OCORHIST.ToString(),
                V0APRO_CODUSU = V0APRO_CODUSU.ToString(),
                V0APRO_COD_EMPRESA = V0APRO_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R3600_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1.Execute(r3600_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3610-00-MONTA-V0ACOMPROP-SECTION */
        private void R3610_00_MONTA_V0ACOMPROP_SECTION()
        {
            /*" -3190- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -3191- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WTIME_DAYR.WTIME_HORA);

            /*" -3192- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", AREA_DE_WORK.WTIME_DAYR.WTIME_2PT1);

            /*" -3193- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WTIME_DAYR.WTIME_MINU);

            /*" -3194- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", AREA_DE_WORK.WTIME_DAYR.WTIME_2PT2);

            /*" -3196- MOVE WS-SS-TIME TO WTIME-SEGU. */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WTIME_DAYR.WTIME_SEGU);

            /*" -3198- PERFORM R3620-00-SELECT-V1CONTPROP */

            R3620_00_SELECT_V1CONTPROP_SECTION();

            /*" -3200- MOVE '361' TO WNR-EXEC-SQL. */
            _.Move("361", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3201- MOVE V1PROP-FONTE TO V0APRO-FONTE */
            _.Move(V1PROP_FONTE, V0APRO_FONTE);

            /*" -3202- MOVE V1PROP-NRPROPOS TO V0APRO-NRPROPOS */
            _.Move(V1PROP_NRPROPOS, V0APRO_NRPROPOS);

            /*" -3203- MOVE 9019 TO V0APRO-OPERACAO */
            _.Move(9019, V0APRO_OPERACAO);

            /*" -3204- MOVE V1SIST-DTMOVABE TO V0APRO-DATOPR */
            _.Move(V1SIST_DTMOVABE, V0APRO_DATOPR);

            /*" -3205- MOVE WTIME-DAYR TO V0APRO-HORAOPER */
            _.Move(AREA_DE_WORK.WTIME_DAYR, V0APRO_HORAOPER);

            /*" -3206- MOVE W1CPRO-OCORHIST TO V0APRO-OCORHIST */
            _.Move(W1CPRO_OCORHIST, V0APRO_OCORHIST);

            /*" -3207- MOVE V1PROP-COD-USUAR TO V0APRO-CODUSU */
            _.Move(V1PROP_COD_USUAR, V0APRO_CODUSU);

            /*" -3207- MOVE V1PROP-COD-EMPRESA TO V0APRO-COD-EMPRESA. */
            _.Move(V1PROP_COD_EMPRESA, V0APRO_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3610_99_SAIDA*/

        [StopWatch]
        /*" R3620-00-SELECT-V1CONTPROP-SECTION */
        private void R3620_00_SELECT_V1CONTPROP_SECTION()
        {
            /*" -3220- MOVE '362' TO WNR-EXEC-SQL. */
            _.Move("362", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3226- PERFORM R3620_00_SELECT_V1CONTPROP_DB_SELECT_1 */

            R3620_00_SELECT_V1CONTPROP_DB_SELECT_1();

            /*" -3229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3230- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3233- DISPLAY 'R3620-00 (NAO EXITE NA V1CONTPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                    $"R3620-00 (NAO EXITE NA V1CONTPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                    .Display();

                    /*" -3234- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3235- ELSE */
                }
                else
                {


                    /*" -3238- DISPLAY 'R3620-00 (ERRO SELECT V1CONTPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                    $"R3620-00 (ERRO SELECT V1CONTPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                    .Display();

                    /*" -3242- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3245- COMPUTE W1CPRO-OCORHIST = W1CPRO-OCORHIST + 1. */
            W1CPRO_OCORHIST.Value = W1CPRO_OCORHIST + 1;

            /*" -3245- ADD 1 TO AC-S-CONTPROP. */
            AREA_DE_WORK.AC_S_CONTPROP.Value = AREA_DE_WORK.AC_S_CONTPROP + 1;

        }

        [StopWatch]
        /*" R3620-00-SELECT-V1CONTPROP-DB-SELECT-1 */
        public void R3620_00_SELECT_V1CONTPROP_DB_SELECT_1()
        {
            /*" -3226- EXEC SQL SELECT OCORHIST INTO :W1CPRO-OCORHIST FROM SEGUROS.V1CONTPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 = new R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1.Execute(r3620_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1CPRO_OCORHIST, W1CPRO_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3620_99_SAIDA*/

        [StopWatch]
        /*" R3710-00-MONTA-REM0104B1-SECTION */
        private void R3710_00_MONTA_REM0104B1_SECTION()
        {
            /*" -3258- MOVE '371' TO WNR-EXEC-SQL. */
            _.Move("371", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3259- MOVE 'EM0104B1' TO V0EDIA-CODRELAT */
            _.Move("EM0104B1", V0EDIA_CODRELAT);

            /*" -3260- MOVE WNUM-APOLICE TO V0EDIA-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -3261- MOVE ZEROS TO V0EDIA-NRENDOS */
            _.Move(0, V0EDIA_NRENDOS);

            /*" -3262- MOVE ZEROS TO V0EDIA-NRPARCEL */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -3263- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -3264- MOVE ZEROS TO V0EDIA-ORGAO */
            _.Move(0, V0EDIA_ORGAO);

            /*" -3265- MOVE ZEROS TO V0EDIA-RAMO */
            _.Move(0, V0EDIA_RAMO);

            /*" -3266- MOVE V1PROP-FONTE TO V0EDIA-FONTE */
            _.Move(V1PROP_FONTE, V0EDIA_FONTE);

            /*" -3267- MOVE ZEROS TO V0EDIA-CONGENER */
            _.Move(0, V0EDIA_CONGENER);

            /*" -3268- MOVE V0ACOR-CODCORR TO V0EDIA-CODCORR */
            _.Move(V0ACOR_CODCORR, V0EDIA_CODCORR);

            /*" -3269- MOVE '0' TO V0EDIA-SITUACAO */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -3270- MOVE V1PROP-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(V1PROP_COD_EMPRESA, V0EDIA_COD_EMP);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3710_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-INSERT-V0EMISDIARIA-SECTION */
        private void R3800_00_INSERT_V0EMISDIARIA_SECTION()
        {
            /*" -3282- MOVE '380' TO WNR-EXEC-SQL. */
            _.Move("380", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3297- PERFORM R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1 */

            R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1();

            /*" -3303- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3305- GO TO R3800-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3309- DISPLAY 'R3800-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R3800-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3311- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3311- ADD +1 TO AC-I-EMISDIARIA. */
            AREA_DE_WORK.AC_I_EMISDIARIA.Value = AREA_DE_WORK.AC_I_EMISDIARIA + +1;

        }

        [StopWatch]
        /*" R3800-00-INSERT-V0EMISDIARIA-DB-INSERT-1 */
        public void R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -3297- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1()
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
                V0EDIA_COD_EMP = V0EDIA_COD_EMP.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r3800_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-UPDATE-V0PROPOSTA-SECTION */
        private void R4100_00_UPDATE_V0PROPOSTA_SECTION()
        {
            /*" -3324- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3330- PERFORM R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1 */

            R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1();

            /*" -3333- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3336- DISPLAY 'R4100-00 (PROBLEMAS UPDATE V0PROPOSTA) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4100-00 (PROBLEMAS UPDATE V0PROPOSTA) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3338- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3338- ADD 1 TO AC-U-PROPOSTA. */
            AREA_DE_WORK.AC_U_PROPOSTA.Value = AREA_DE_WORK.AC_U_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R4100-00-UPDATE-V0PROPOSTA-DB-UPDATE-1 */
        public void R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1()
        {
            /*" -3330- EXEC SQL UPDATE SEGUROS.V0PROPOSTA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1 = new R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1.Execute(r4100_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-UPDATE-V0CONTPROP-SECTION */
        private void R4200_00_UPDATE_V0CONTPROP_SECTION()
        {
            /*" -3351- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3358- PERFORM R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1 */

            R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1();

            /*" -3361- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3364- DISPLAY 'R4200-00 (PROBLEMAS UPDATE V0CONTPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4200-00 (PROBLEMAS UPDATE V0CONTPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3366- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3366- ADD 1 TO AC-U-CONTPROP. */
            AREA_DE_WORK.AC_U_CONTPROP.Value = AREA_DE_WORK.AC_U_CONTPROP + 1;

        }

        [StopWatch]
        /*" R4200-00-UPDATE-V0CONTPROP-DB-UPDATE-1 */
        public void R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1()
        {
            /*" -3358- EXEC SQL UPDATE SEGUROS.V0CONTPROP SET SITUACAO = '1' , OCORHIST = :W1CPRO-OCORHIST , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1 = new R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1()
            {
                W1CPRO_OCORHIST = W1CPRO_OCORHIST.ToString(),
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1.Execute(r4200_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-UPDATE-V0APOLICE-SECTION */
        private void R4300_00_UPDATE_V0APOLICE_SECTION()
        {
            /*" -3379- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3385- PERFORM R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -3388- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3391- DISPLAY 'R4300-00 (PROBLEMAS UPDATE V0APOLICE) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4300-00 (PROBLEMAS UPDATE V0APOLICE) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3393- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3393- ADD 1 TO AC-U-APOLICES. */
            AREA_DE_WORK.AC_U_APOLICES.Value = AREA_DE_WORK.AC_U_APOLICES + 1;

        }

        [StopWatch]
        /*" R4300-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -3385- EXEC SQL UPDATE SEGUROS.V0APOLICE SET PCTCED = :W0APOL-PCTCED , QTCOSSEG = :W0APOL-QTCOSSEG, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0APOL-NUM-APOL END-EXEC. */

            var r4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                W0APOL_QTCOSSEG = W0APOL_QTCOSSEG.ToString(),
                W0APOL_PCTCED = W0APOL_PCTCED.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
            };

            R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(r4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4310-00-UPDATE-V0APOLICE-SECTION */
        private void R4310_00_UPDATE_V0APOLICE_SECTION()
        {
            /*" -3406- MOVE '431' TO WNR-EXEC-SQL. */
            _.Move("431", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3411- PERFORM R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -3414- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3418- DISPLAY 'R4310-00 (PROBLEMAS UPDATE V0APOLICE) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS ' ' V0ENDO-NUM-APOL */

                $"R4310-00 (PROBLEMAS UPDATE V0APOLICE) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS} {V0ENDO_NUM_APOL}"
                .Display();

                /*" -3418- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4310-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -3411- EXEC SQL UPDATE SEGUROS.V0APOLICE SET CODCLIEN = :V1PROP-CODCLIEN, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0ENDO-NUM-APOL END-EXEC. */

            var r4310_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                V1PROP_CODCLIEN = V1PROP_CODCLIEN.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
            };

            R4310_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(r4310_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4310_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-UPDATE-V0COBERAPOL-SECTION */
        private void R4400_00_UPDATE_V0COBERAPOL_SECTION()
        {
            /*" -3431- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3435- COMPUTE V0COBA-PCT-COBERT = V0COBA-PCT-COBERT + (100 - W1COBP-PCT-TOTAL) */
            V0COBA_PCT_COBERT.Value = V0COBA_PCT_COBERT + (100 - W1COBP_PCT_TOTAL);

            /*" -3445- PERFORM R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1 */

            R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1();

            /*" -3448- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3451- DISPLAY 'R4400-00 (PROBLEMAS UPDATE V0COBERAPOL) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4400-00 (PROBLEMAS UPDATE V0COBERAPOL) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3453- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3453- ADD 1 TO AC-U-COBERAPOL. */
            AREA_DE_WORK.AC_U_COBERAPOL.Value = AREA_DE_WORK.AC_U_COBERAPOL + 1;

        }

        [StopWatch]
        /*" R4400-00-UPDATE-V0COBERAPOL-DB-UPDATE-1 */
        public void R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -3445- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET PCT_COBERTURA = :V0COBA-PCT-COBERT, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0COBA-NUM-APOL AND NRENDOS = :V0COBA-NRENDOS AND NUM_ITEM = :V0COBA-NUM-ITEM AND OCORHIST = :V0COBA-OCORHIST AND RAMOFR = :V0COBA-RAMOFR AND MODALIFR = :V0COBA-MODALIFR END-EXEC. */

            var r4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 = new R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1()
            {
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
            };

            R4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1.Execute(r4400_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R4450-00-LER-LTMVPROP-SECTION */
        private void R4450_00_LER_LTMVPROP_SECTION()
        {
            /*" -3463- MOVE '445' TO WNR-EXEC-SQL. */
            _.Move("445", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3465- MOVE 0 TO LTMVPROP-PCT-JUROS */
            _.Move(0, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_JUROS);

            /*" -3473- PERFORM R4450_00_LER_LTMVPROP_DB_SELECT_1 */

            R4450_00_LER_LTMVPROP_DB_SELECT_1();

            /*" -3476- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3479- DISPLAY 'R4450-ERRO SELECT LT_MOV_PROPOSTA' 'FON=' V1PROP-FONTE 'PRO=' V1PROP-NRPROPOS */

                $"R4450-ERRO SELECT LT_MOV_PROPOSTAFON={V1PROP_FONTE}PRO={V1PROP_NRPROPOS}"
                .Display();

                /*" -3479- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4450-00-LER-LTMVPROP-DB-SELECT-1 */
        public void R4450_00_LER_LTMVPROP_DB_SELECT_1()
        {
            /*" -3473- EXEC SQL SELECT PCT_JUROS INTO :LTMVPROP-PCT-JUROS FROM SEGUROS.LT_MOV_PROPOSTA WHERE COD_FONTE = :V1PROP-FONTE AND NUM_PROPOSTA = :V1PROP-NRPROPOS AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO = '1' END-EXEC. */

            var r4450_00_LER_LTMVPROP_DB_SELECT_1_Query1 = new R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R4450_00_LER_LTMVPROP_DB_SELECT_1_Query1.Execute(r4450_00_LER_LTMVPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_PCT_JUROS, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_JUROS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4450_99_SAIDA*/

        [StopWatch]
        /*" R4500-00-UPDATE-LTMVPROP-SECTION */
        private void R4500_00_UPDATE_LTMVPROP_SECTION()
        {
            /*" -3488- MOVE '450' TO WNR-EXEC-SQL. */
            _.Move("450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3493- PERFORM R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1 */

            R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1();

            /*" -3496- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3500- DISPLAY 'R4500-00 (PROBLEMAS UPDATE LTMVPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS ' ' V0ENDO-NUM-APOL */

                $"R4500-00 (PROBLEMAS UPDATE LTMVPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS} {V0ENDO_NUM_APOL}"
                .Display();

                /*" -3500- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4500-00-UPDATE-LTMVPROP-DB-UPDATE-1 */
        public void R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1()
        {
            /*" -3493- EXEC SQL UPDATE SEGUROS.LT_MOV_PROPOSTA SET NUM_APOLICE = :V0ENDO-NUM-APOL WHERE COD_FONTE = :V1PROP-FONTE AND NUM_PROPOSTA = :V1PROP-NRPROPOS END-EXEC. */

            var r4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1 = new R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1.Execute(r4500_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4500_99_SAIDA*/

        [StopWatch]
        /*" R4550-00-UPDATE-LTMVPROP-SECTION */
        private void R4550_00_UPDATE_LTMVPROP_SECTION()
        {
            /*" -3510- MOVE '455' TO WNR-EXEC-SQL. */
            _.Move("455", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3516- PERFORM R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1 */

            R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1();

            /*" -3519- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3524- DISPLAY 'R4550-00 (PROBLEMAS UPDATE LTMVPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS */

                $"R4550-00 (PROBLEMAS UPDATE LTMVPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS} {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS}"
                .Display();

                /*" -3524- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4550-00-UPDATE-LTMVPROP-DB-UPDATE-1 */
        public void R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1()
        {
            /*" -3516- EXEC SQL UPDATE SEGUROS.LT_MOV_PROPOSTA SET NUM_ENDOSSO = :V0ENDO-NRENDOS WHERE COD_FONTE = :V1PROP-FONTE AND NUM_PROPOSTA = :V1PROP-NRPROPOS AND NUM_APOLICE = :V0ENDO-NUM-APOL END-EXEC. */

            var r4550_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1 = new R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R4550_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1.Execute(r4550_00_UPDATE_LTMVPROP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4550_99_SAIDA*/

        [StopWatch]
        /*" R5600-00-INSERT-V0MALHAPROD-SECTION */
        private void R5600_00_INSERT_V0MALHAPROD_SECTION()
        {
            /*" -3535- MOVE '560' TO WNR-EXEC-SQL. */
            _.Move("560", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3537- PERFORM R5610-00-MONTA-V0MALHAPROD */

            R5610_00_MONTA_V0MALHAPROD_SECTION();

            /*" -3552- PERFORM R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1 */

            R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1();

            /*" -3558- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3560- GO TO R5600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3561- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3564- DISPLAY 'R5600-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5600-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3566- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3566- ADD +1 TO AC-I-MALHAPROD. */
            AREA_DE_WORK.AC_I_MALHAPROD.Value = AREA_DE_WORK.AC_I_MALHAPROD + +1;

        }

        [StopWatch]
        /*" R5600-00-INSERT-V0MALHAPROD-DB-INSERT-1 */
        public void R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1()
        {
            /*" -3552- EXEC SQL INSERT INTO SEGUROS.V0MALHAPROD VALUES (:V0MPRD-NUM-APOL, :V0MPRD-CODSUBES, :V0MPRD-CODCORR, :V0MPRD-CODPRP, :V0MPRD-CODCLB, :V0MPRD-INSPETOR, :V0MPRD-ISPRGI, :V0MPRD-CODGTE, :V0MPRD-CODSTE, :V0MPRD-DIRRGI, :V0MPRD-DIRCMC, :V0MPRD-COD-EMPRESA, CURRENT TIMESTAMP) END-EXEC. */

            var r5600_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1 = new R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1()
            {
                V0MPRD_NUM_APOL = V0MPRD_NUM_APOL.ToString(),
                V0MPRD_CODSUBES = V0MPRD_CODSUBES.ToString(),
                V0MPRD_CODCORR = V0MPRD_CODCORR.ToString(),
                V0MPRD_CODPRP = V0MPRD_CODPRP.ToString(),
                V0MPRD_CODCLB = V0MPRD_CODCLB.ToString(),
                V0MPRD_INSPETOR = V0MPRD_INSPETOR.ToString(),
                V0MPRD_ISPRGI = V0MPRD_ISPRGI.ToString(),
                V0MPRD_CODGTE = V0MPRD_CODGTE.ToString(),
                V0MPRD_CODSTE = V0MPRD_CODSTE.ToString(),
                V0MPRD_DIRRGI = V0MPRD_DIRRGI.ToString(),
                V0MPRD_DIRCMC = V0MPRD_DIRCMC.ToString(),
                V0MPRD_COD_EMPRESA = V0MPRD_COD_EMPRESA.ToString(),
            };

            R5600_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1.Execute(r5600_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5600_99_SAIDA*/

        [StopWatch]
        /*" R5610-00-MONTA-V0MALHAPROD-SECTION */
        private void R5610_00_MONTA_V0MALHAPROD_SECTION()
        {
            /*" -3578- MOVE '561' TO WNR-EXEC-SQL. */
            _.Move("561", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3579- MOVE WNUM-APOLICE TO V0MPRD-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0MPRD_NUM_APOL);

            /*" -3580- MOVE V1PCOR-CODCORR TO V0MPRD-CODCORR */
            _.Move(V1PCOR_CODCORR, V0MPRD_CODCORR);

            /*" -3581- MOVE V1PROP-INSPETOR TO V0MPRD-INSPETOR */
            _.Move(V1PROP_INSPETOR, V0MPRD_INSPETOR);

            /*" -3582- MOVE V1PROP-CANALPROD TO V0MPRD-CODCLB */
            _.Move(V1PROP_CANALPROD, V0MPRD_CODCLB);

            /*" -3589- MOVE ZEROS TO V0MPRD-CODSUBES V0MPRD-CODPRP V0MPRD-ISPRGI V0MPRD-CODGTE V0MPRD-CODSTE V0MPRD-DIRRGI V0MPRD-DIRCMC V0MPRD-COD-EMPRESA. */
            _.Move(0, V0MPRD_CODSUBES, V0MPRD_CODPRP, V0MPRD_ISPRGI, V0MPRD_CODGTE, V0MPRD_CODSTE, V0MPRD_DIRRGI, V0MPRD_DIRCMC, V0MPRD_COD_EMPRESA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5610_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-TRATA-APOLCORRET-SECTION */
        private void R6000_00_TRATA_APOLCORRET_SECTION()
        {
            /*" -3602- MOVE '600' TO WNR-EXEC-SQL. */
            _.Move("600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3603- IF V1PROP-TPPROPOS NOT EQUAL '3' */

            if (V1PROP_TPPROPOS != "3")
            {

                /*" -3605- GO TO R6000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3606- MOVE V1PROP-DTINIVIG TO V3PROP-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V3PROP_DTINIVIG);

            /*" -3608- MOVE V1PROP-DTTERVIG TO V3PROP-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V3PROP_DTTERVIG);

            /*" -3614- PERFORM R6000_00_TRATA_APOLCORRET_DB_SELECT_1 */

            R6000_00_TRATA_APOLCORRET_DB_SELECT_1();

            /*" -3617- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3619- DISPLAY 'R6000-00 (PROBLEMAS NO SELECT APOLCORRET) ' ' ' V1PROP-NUM-APOLICE */

                $"R6000-00 (PROBLEMAS NO SELECT APOLCORRET)  {V1PROP_NUM_APOLICE}"
                .Display();

                /*" -3621- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3622- MOVE 999999999 TO CH-CORR-ANT */
            _.Move(999999999, AREA_DE_WORK.CH_CORR_ANT);

            /*" -3623- MOVE ZEROS TO W1PCOR-CODCORR */
            _.Move(0, W1PCOR_CODCORR);

            /*" -3624- MOVE SPACES TO WFIM-V1PROPCORRET */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPCORRET);

            /*" -3625- MOVE V1PROP-NUM-APOLICE TO WNUM-APOLICE */
            _.Move(V1PROP_NUM_APOLICE, AREA_DE_WORK.WNUM_APOLICE);

            /*" -3628- PERFORM R2100-00-DECLARE-V1PROPCORRET */

            R2100_00_DECLARE_V1PROPCORRET_SECTION();

            /*" -3629- MOVE V2PROP-DTINIVIG TO V1PROP-DTINIVIG */
            _.Move(V2PROP_DTINIVIG, V1PROP_DTINIVIG);

            /*" -3631- MOVE V2PROP-DTTERVIG TO V1PROP-DTTERVIG */
            _.Move(V2PROP_DTTERVIG, V1PROP_DTTERVIG);

            /*" -3634- PERFORM R3300-00-INSERT-V0APOLCORRET UNTIL WFIM-V1PROPCORRET NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1PROPCORRET.IsEmpty()))
            {

                R3300_00_INSERT_V0APOLCORRET_SECTION();
            }

            /*" -3635- MOVE V3PROP-DTINIVIG TO V1PROP-DTINIVIG. */
            _.Move(V3PROP_DTINIVIG, V1PROP_DTINIVIG);

            /*" -3635- MOVE V3PROP-DTTERVIG TO V1PROP-DTTERVIG. */
            _.Move(V3PROP_DTTERVIG, V1PROP_DTTERVIG);

        }

        [StopWatch]
        /*" R6000-00-TRATA-APOLCORRET-DB-SELECT-1 */
        public void R6000_00_TRATA_APOLCORRET_DB_SELECT_1()
        {
            /*" -3614- EXEC SQL SELECT DISTINCT DTINIVIG, DTTERVIG INTO :V2PROP-DTINIVIG, :V2PROP-DTTERVIG FROM SEGUROS.V0APOLCORRET WHERE NUM_APOLICE = :V1PROP-NUM-APOLICE END-EXEC. */

            var r6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1 = new R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1()
            {
                V1PROP_NUM_APOLICE = V1PROP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1.Execute(r6000_00_TRATA_APOLCORRET_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V2PROP_DTINIVIG, V2PROP_DTINIVIG);
                _.Move(executed_1.V2PROP_DTTERVIG, V2PROP_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R9500-00-DISPLAY-CONTROLE-SECTION */
        private void R9500_00_DISPLAY_CONTROLE_SECTION()
        {
            /*" -3649- DISPLAY '+---------------------------+--------+--------+----- '---+--------+' . */
            _.Display($"+---------------------------+--------+--------+----- ---+--------+");

            /*" -3651- DISPLAY 'I TABELA I SELECT I UPDATE I INSE 'RT I DELETE I' . */

            $"I TABELA I SELECT I UPDATE I INSE RTIDELETEI"
            .Display();

            /*" -3654- DISPLAY '+---------------------------+--------+--------+----- '---+--------+' . */
            _.Display($"+---------------------------+--------+--------+----- ---+--------+");

            /*" -3655- MOVE AC-S-SISTEMAS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_SISTEMAS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3656- MOVE AC-U-SISTEMAS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_SISTEMAS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3657- MOVE AC-I-SISTEMAS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_SISTEMAS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3658- MOVE AC-D-SISTEMAS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_SISTEMAS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3664- DISPLAY 'I SISTEMAS                  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I SISTEMAS                  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3665- MOVE AC-S-PARAMRAM TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PARAMRAM, AREA_DE_WORK.WWORK_SELECT);

            /*" -3666- MOVE AC-U-PARAMRAM TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PARAMRAM, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3667- MOVE AC-I-PARAMRAM TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PARAMRAM, AREA_DE_WORK.WWORK_INSERT);

            /*" -3668- MOVE AC-D-PARAMRAM TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PARAMRAM, AREA_DE_WORK.WWORK_DELETE);

            /*" -3674- DISPLAY 'I PARAMETRO DE RAMOS        I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PARAMETRO DE RAMOS        I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3675- MOVE AC-S-RAMOIND TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_RAMOIND, AREA_DE_WORK.WWORK_SELECT);

            /*" -3676- MOVE AC-U-RAMOIND TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_RAMOIND, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3677- MOVE AC-I-RAMOIND TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_RAMOIND, AREA_DE_WORK.WWORK_INSERT);

            /*" -3678- MOVE AC-D-RAMOIND TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_RAMOIND, AREA_DE_WORK.WWORK_DELETE);

            /*" -3684- DISPLAY 'I INDICADOR DE RAMOS        I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I INDICADOR DE RAMOS        I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3685- MOVE AC-S-FONTES TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_FONTES, AREA_DE_WORK.WWORK_SELECT);

            /*" -3686- MOVE AC-U-FONTES TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_FONTES, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3687- MOVE AC-I-FONTES TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_FONTES, AREA_DE_WORK.WWORK_INSERT);

            /*" -3688- MOVE AC-D-FONTES TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_FONTES, AREA_DE_WORK.WWORK_DELETE);

            /*" -3694- DISPLAY 'I FONTES PRODUTORAS         I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I FONTES PRODUTORAS         I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3695- MOVE AC-S-MOEDAS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MOEDAS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3696- MOVE AC-U-MOEDAS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_MOEDAS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3697- MOVE AC-I-MOEDAS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MOEDAS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3698- MOVE AC-D-MOEDAS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_MOEDAS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3704- DISPLAY 'I COTACAO DE MOEDAS         I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I COTACAO DE MOEDAS         I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3705- MOVE AC-S-NUMEROAES TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_NUMEROAES, AREA_DE_WORK.WWORK_SELECT);

            /*" -3706- MOVE AC-U-NUMEROAES TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_NUMEROAES, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3707- MOVE AC-I-NUMEROAES TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_NUMEROAES, AREA_DE_WORK.WWORK_INSERT);

            /*" -3708- MOVE AC-D-NUMEROAES TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_NUMEROAES, AREA_DE_WORK.WWORK_DELETE);

            /*" -3714- DISPLAY 'I NUMERACAO APOLICE/ENDOSSO I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I NUMERACAO APOLICE/ENDOSSO I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3715- MOVE AC-S-PROPOSTA TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PROPOSTA, AREA_DE_WORK.WWORK_SELECT);

            /*" -3716- MOVE AC-U-PROPOSTA TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PROPOSTA, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3717- MOVE AC-I-PROPOSTA TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PROPOSTA, AREA_DE_WORK.WWORK_INSERT);

            /*" -3718- MOVE AC-D-PROPOSTA TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PROPOSTA, AREA_DE_WORK.WWORK_DELETE);

            /*" -3724- DISPLAY 'I PROPOSTAS DE APOLICE      I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTAS DE APOLICE      I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3725- MOVE AC-S-ACOMPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_ACOMPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3726- MOVE AC-U-ACOMPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_ACOMPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3727- MOVE AC-I-ACOMPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_ACOMPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3728- MOVE AC-D-ACOMPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_ACOMPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3734- DISPLAY 'I ACOMPANHA PROPOSTAS       I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I ACOMPANHA PROPOSTAS       I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3735- MOVE AC-S-CONTPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_CONTPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3736- MOVE AC-U-CONTPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_CONTPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3737- MOVE AC-I-CONTPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_CONTPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3738- MOVE AC-D-CONTPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_CONTPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3744- DISPLAY 'I CONTROLE DE PROPOSTAS     I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I CONTROLE DE PROPOSTAS     I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3745- MOVE AC-S-PROPCLAU TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PROPCLAU, AREA_DE_WORK.WWORK_SELECT);

            /*" -3746- MOVE AC-U-PROPCLAU TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PROPCLAU, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3747- MOVE AC-I-PROPCLAU TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PROPCLAU, AREA_DE_WORK.WWORK_INSERT);

            /*" -3748- MOVE AC-D-PROPCLAU TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PROPCLAU, AREA_DE_WORK.WWORK_DELETE);

            /*" -3754- DISPLAY 'I PROPOSTA CLAUSULAS (AUTO) I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA CLAUSULAS (AUTO) I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3755- MOVE AC-S-PROPCLAUS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PROPCLAUS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3756- MOVE AC-U-PROPCLAUS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PROPCLAUS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3757- MOVE AC-I-PROPCLAUS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PROPCLAUS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3758- MOVE AC-D-PROPCLAUS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PROPCLAUS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3764- DISPLAY 'I PROPOSTA CLAUSULAS (OR)   I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA CLAUSULAS (OR)   I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3765- MOVE AC-S-APOLCLAU TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_APOLCLAU, AREA_DE_WORK.WWORK_SELECT);

            /*" -3766- MOVE AC-U-APOLCLAU TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_APOLCLAU, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3767- MOVE AC-I-APOLCLAU TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_APOLCLAU, AREA_DE_WORK.WWORK_INSERT);

            /*" -3768- MOVE AC-D-APOLCLAU TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_APOLCLAU, AREA_DE_WORK.WWORK_DELETE);

            /*" -3774- DISPLAY 'I APOLICE CLAUSULAS (AUTO)  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE CLAUSULAS (AUTO)  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3775- MOVE AC-S-APOLCLAUS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_APOLCLAUS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3776- MOVE AC-U-APOLCLAUS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_APOLCLAUS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3777- MOVE AC-I-APOLCLAUS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_APOLCLAUS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3778- MOVE AC-D-APOLCLAUS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_APOLCLAUS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3784- DISPLAY 'I APOLICE CLAUSULAS (OR)    I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE CLAUSULAS (OR)    I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3785- MOVE AC-S-PROPCORRET TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PROPCORRET, AREA_DE_WORK.WWORK_SELECT);

            /*" -3786- MOVE AC-U-PROPCORRET TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PROPCORRET, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3787- MOVE AC-I-PROPCORRET TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PROPCORRET, AREA_DE_WORK.WWORK_INSERT);

            /*" -3788- MOVE AC-D-PROPCORRET TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PROPCORRET, AREA_DE_WORK.WWORK_DELETE);

            /*" -3794- DISPLAY 'I PROPOSTA CORRETOR         I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA CORRETOR         I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3795- MOVE AC-S-APOLCORRET TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_APOLCORRET, AREA_DE_WORK.WWORK_SELECT);

            /*" -3796- MOVE AC-U-APOLCORRET TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_APOLCORRET, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3797- MOVE AC-I-APOLCORRET TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_APOLCORRET, AREA_DE_WORK.WWORK_INSERT);

            /*" -3798- MOVE AC-D-APOLCORRET TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_APOLCORRET, AREA_DE_WORK.WWORK_DELETE);

            /*" -3804- DISPLAY 'I APOLICE CORRETOR          I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE CORRETOR          I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3805- MOVE AC-S-MALHAPROD TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MALHAPROD, AREA_DE_WORK.WWORK_SELECT);

            /*" -3806- MOVE AC-U-MALHAPROD TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_MALHAPROD, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3807- MOVE AC-I-MALHAPROD TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MALHAPROD, AREA_DE_WORK.WWORK_INSERT);

            /*" -3808- MOVE AC-D-MALHAPROD TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_MALHAPROD, AREA_DE_WORK.WWORK_DELETE);

            /*" -3814- DISPLAY 'I MALHA DE PRODUCAO         I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I MALHA DE PRODUCAO         I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3815- MOVE AC-S-PROPCOSCED TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PROPCOSCED, AREA_DE_WORK.WWORK_SELECT);

            /*" -3816- MOVE AC-U-PROPCOSCED TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PROPCOSCED, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3817- MOVE AC-I-PROPCOSCED TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PROPCOSCED, AREA_DE_WORK.WWORK_INSERT);

            /*" -3818- MOVE AC-D-PROPCOSCED TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PROPCOSCED, AREA_DE_WORK.WWORK_DELETE);

            /*" -3824- DISPLAY 'I PROPOSTA COSSEG CEDIDO    I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA COSSEG CEDIDO    I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3825- MOVE AC-S-COSSEGSORT TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_COSSEGSORT, AREA_DE_WORK.WWORK_SELECT);

            /*" -3826- MOVE AC-U-COSSEGSORT TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_COSSEGSORT, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3827- MOVE AC-I-COSSEGSORT TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_COSSEGSORT, AREA_DE_WORK.WWORK_INSERT);

            /*" -3828- MOVE AC-D-COSSEGSORT TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_COSSEGSORT, AREA_DE_WORK.WWORK_DELETE);

            /*" -3834- DISPLAY 'I SORTEIO COSSEGURADORAS    I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I SORTEIO COSSEGURADORAS    I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3835- MOVE AC-S-APOLCOSCED TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_APOLCOSCED, AREA_DE_WORK.WWORK_SELECT);

            /*" -3836- MOVE AC-U-APOLCOSCED TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_APOLCOSCED, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3837- MOVE AC-I-APOLCOSCED TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_APOLCOSCED, AREA_DE_WORK.WWORK_INSERT);

            /*" -3838- MOVE AC-D-APOLCOSCED TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_APOLCOSCED, AREA_DE_WORK.WWORK_DELETE);

            /*" -3844- DISPLAY 'I APOLICE COSSEG CEDIDO     I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE COSSEG CEDIDO     I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3845- MOVE AC-S-APOLICES TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_APOLICES, AREA_DE_WORK.WWORK_SELECT);

            /*" -3846- MOVE AC-U-APOLICES TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_APOLICES, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3847- MOVE AC-I-APOLICES TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_APOLICES, AREA_DE_WORK.WWORK_INSERT);

            /*" -3848- MOVE AC-D-APOLICES TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_APOLICES, AREA_DE_WORK.WWORK_DELETE);

            /*" -3854- DISPLAY 'I APOLICES                  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICES                  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3855- MOVE AC-S-ENDOSSOS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_ENDOSSOS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3856- MOVE AC-U-ENDOSSOS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_ENDOSSOS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3857- MOVE AC-I-ENDOSSOS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_ENDOSSOS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3858- MOVE AC-D-ENDOSSOS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_ENDOSSOS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3864- DISPLAY 'I ENDOSSOS                  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I ENDOSSOS                  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3865- MOVE AC-S-PROPACESS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_PROPACESS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3866- MOVE AC-U-PROPACESS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_PROPACESS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3867- MOVE AC-I-PROPACESS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_PROPACESS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3868- MOVE AC-D-PROPACESS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_PROPACESS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3874- DISPLAY 'I PROPOSTA ACESSORIOS       I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA ACESSORIOS       I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3875- MOVE AC-S-APOLACESS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_APOLACESS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3876- MOVE AC-U-APOLACESS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_APOLACESS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3877- MOVE AC-I-APOLACESS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_APOLACESS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3878- MOVE AC-D-APOLACESS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_APOLACESS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3884- DISPLAY 'I APOLICE ACESSORIOS        I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE ACESSORIOS        I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3885- MOVE AC-S-AUTOPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_AUTOPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3886- MOVE AC-U-AUTOPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_AUTOPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3887- MOVE AC-I-AUTOPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_AUTOPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3888- MOVE AC-D-AUTOPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_AUTOPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3894- DISPLAY 'I PROPOSTA AUTOMOVEIS       I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA AUTOMOVEIS       I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3895- MOVE AC-S-AUTOAPOL TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_AUTOAPOL, AREA_DE_WORK.WWORK_SELECT);

            /*" -3896- MOVE AC-U-AUTOAPOL TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_AUTOAPOL, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3897- MOVE AC-I-AUTOAPOL TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_AUTOAPOL, AREA_DE_WORK.WWORK_INSERT);

            /*" -3898- MOVE AC-D-AUTOAPOL TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_AUTOAPOL, AREA_DE_WORK.WWORK_DELETE);

            /*" -3904- DISPLAY 'I APOLICE AUTOMOVEIS        I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE AUTOMOVEIS        I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3905- MOVE AC-S-AUTOCOBERP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_AUTOCOBERP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3906- MOVE AC-U-AUTOCOBERP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_AUTOCOBERP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3907- MOVE AC-I-AUTOCOBERP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_AUTOCOBERP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3908- MOVE AC-D-AUTOCOBERP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_AUTOCOBERP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3914- DISPLAY 'I PROPOSTA COBERTURAS AUTO  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA COBERTURAS AUTO  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3915- MOVE AC-S-AUTOCOBER TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_AUTOCOBER, AREA_DE_WORK.WWORK_SELECT);

            /*" -3916- MOVE AC-U-AUTOCOBER TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_AUTOCOBER, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3917- MOVE AC-I-AUTOCOBER TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_AUTOCOBER, AREA_DE_WORK.WWORK_INSERT);

            /*" -3918- MOVE AC-D-AUTOCOBER TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_AUTOCOBER, AREA_DE_WORK.WWORK_DELETE);

            /*" -3924- DISPLAY 'I COBERTURAS AUTO           I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I COBERTURAS AUTO           I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3925- MOVE AC-S-AUTOTARIFP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_AUTOTARIFP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3926- MOVE AC-U-AUTOTARIFP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_AUTOTARIFP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3927- MOVE AC-I-AUTOTARIFP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_AUTOTARIFP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3928- MOVE AC-D-AUTOTARIFP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_AUTOTARIFP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3934- DISPLAY 'I PROPOSTA TARIFACAO AUTO   I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA TARIFACAO AUTO   I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3935- MOVE AC-S-AUTOTARIFA TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_AUTOTARIFA, AREA_DE_WORK.WWORK_SELECT);

            /*" -3936- MOVE AC-U-AUTOTARIFA TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_AUTOTARIFA, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3937- MOVE AC-I-AUTOTARIFA TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_AUTOTARIFA, AREA_DE_WORK.WWORK_INSERT);

            /*" -3938- MOVE AC-D-AUTOTARIFA TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_AUTOTARIFA, AREA_DE_WORK.WWORK_DELETE);

            /*" -3944- DISPLAY 'I APOLICE TARIFACAO AUTO    I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE TARIFACAO AUTO    I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3945- MOVE AC-S-COBERPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_COBERPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3946- MOVE AC-U-COBERPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_COBERPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3947- MOVE AC-I-COBERPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_COBERPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3948- MOVE AC-D-COBERPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_COBERPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3954- DISPLAY 'I PROPOSTA COBERTURAS       I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA COBERTURAS       I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3955- MOVE AC-S-COBERAPOL TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_COBERAPOL, AREA_DE_WORK.WWORK_SELECT);

            /*" -3956- MOVE AC-U-COBERAPOL TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_COBERAPOL, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3957- MOVE AC-I-COBERAPOL TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_COBERAPOL, AREA_DE_WORK.WWORK_INSERT);

            /*" -3958- MOVE AC-D-COBERAPOL TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_COBERAPOL, AREA_DE_WORK.WWORK_DELETE);

            /*" -3964- DISPLAY 'I COBERTURAS                I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I COBERTURAS                I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3965- MOVE AC-S-OUTRBENSPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTRBENSPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3966- MOVE AC-U-OUTRBENSPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTRBENSPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3967- MOVE AC-I-OUTRBENSPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTRBENSPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3968- MOVE AC-D-OUTRBENSPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTRBENSPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3974- DISPLAY 'I PROPOSTA BENS (OR)        I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA BENS (OR)        I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3975- MOVE AC-S-OUTROSBENS TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTROSBENS, AREA_DE_WORK.WWORK_SELECT);

            /*" -3976- MOVE AC-U-OUTROSBENS TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTROSBENS, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3977- MOVE AC-I-OUTROSBENS TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTROSBENS, AREA_DE_WORK.WWORK_INSERT);

            /*" -3978- MOVE AC-D-OUTROSBENS TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTROSBENS, AREA_DE_WORK.WWORK_DELETE);

            /*" -3984- DISPLAY 'I APOLICE BENS (OR)         I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE BENS (OR)         I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3985- MOVE AC-S-BENSCOBERPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_BENSCOBERPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -3986- MOVE AC-U-BENSCOBERPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_BENSCOBERPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3987- MOVE AC-I-BENSCOBERPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_BENSCOBERPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -3988- MOVE AC-D-BENSCOBERPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_BENSCOBERPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -3994- DISPLAY 'I PROPOSTA COBERT. BENS (OR)I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA COBERT. BENS (OR)I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -3995- MOVE AC-S-BENSCOBER TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_BENSCOBER, AREA_DE_WORK.WWORK_SELECT);

            /*" -3996- MOVE AC-U-BENSCOBER TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_BENSCOBER, AREA_DE_WORK.WWORK_UPDATE);

            /*" -3997- MOVE AC-I-BENSCOBER TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_BENSCOBER, AREA_DE_WORK.WWORK_INSERT);

            /*" -3998- MOVE AC-D-BENSCOBER TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_BENSCOBER, AREA_DE_WORK.WWORK_DELETE);

            /*" -4004- DISPLAY 'I APOLICE COBERT. BENS  (OR)I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE COBERT. BENS  (OR)I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4005- MOVE AC-S-OUTROSPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTROSPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -4006- MOVE AC-U-OUTROSPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTROSPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4007- MOVE AC-I-OUTROSPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTROSPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -4008- MOVE AC-D-OUTROSPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTROSPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -4014- DISPLAY 'I PROPOSTA DE ITENS (OR)    I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA DE ITENS (OR)    I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4015- MOVE AC-S-OUTROSAPOL TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTROSAPOL, AREA_DE_WORK.WWORK_SELECT);

            /*" -4016- MOVE AC-U-OUTROSAPOL TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTROSAPOL, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4017- MOVE AC-I-OUTROSAPOL TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTROSAPOL, AREA_DE_WORK.WWORK_INSERT);

            /*" -4018- MOVE AC-D-OUTROSAPOL TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTROSAPOL, AREA_DE_WORK.WWORK_DELETE);

            /*" -4024- DISPLAY 'I APOLICE DE ITENS (OR)     I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE DE ITENS (OR)     I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4025- MOVE AC-S-OUTRCOBERPROP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTRCOBERPROP, AREA_DE_WORK.WWORK_SELECT);

            /*" -4026- MOVE AC-U-OUTRCOBERPROP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTRCOBERPROP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4027- MOVE AC-I-OUTRCOBERPROP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTRCOBERPROP, AREA_DE_WORK.WWORK_INSERT);

            /*" -4028- MOVE AC-D-OUTRCOBERPROP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTRCOBERPROP, AREA_DE_WORK.WWORK_DELETE);

            /*" -4034- DISPLAY 'I PROPOSTA COBERTURAS (OR)  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I PROPOSTA COBERTURAS (OR)  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4035- MOVE AC-S-OUTROSCOBER TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTROSCOBER, AREA_DE_WORK.WWORK_SELECT);

            /*" -4036- MOVE AC-U-OUTROSCOBER TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTROSCOBER, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4037- MOVE AC-I-OUTROSCOBER TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTROSCOBER, AREA_DE_WORK.WWORK_INSERT);

            /*" -4038- MOVE AC-D-OUTROSCOBER TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTROSCOBER, AREA_DE_WORK.WWORK_DELETE);

            /*" -4044- DISPLAY 'I APOLICE COBERTURAS  (OR)  I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I APOLICE COBERTURAS  (OR)  I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4045- MOVE AC-S-OUTRCOBERP TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_OUTRCOBERP, AREA_DE_WORK.WWORK_SELECT);

            /*" -4046- MOVE AC-U-OUTRCOBERP TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_OUTRCOBERP, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4047- MOVE AC-I-OUTRCOBERP TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_OUTRCOBERP, AREA_DE_WORK.WWORK_INSERT);

            /*" -4048- MOVE AC-D-OUTRCOBERP TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_OUTRCOBERP, AREA_DE_WORK.WWORK_DELETE);

            /*" -4054- DISPLAY 'I COBERTURAS (OR)           I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I COBERTURAS (OR)           I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4055- MOVE AC-S-MRPROITE TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MRPROITE, AREA_DE_WORK.WWORK_SELECT);

            /*" -4056- MOVE AC-I-MRAPOITE TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MRAPOITE, AREA_DE_WORK.WWORK_INSERT);

            /*" -4057- MOVE ZEROS TO WWORK-UPDATE */
            _.Move(0, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4058- MOVE ZEROS TO WWORK-DELETE */
            _.Move(0, AREA_DE_WORK.WWORK_DELETE);

            /*" -4064- DISPLAY 'I ITEM PROPOSTA (MR)        I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I ITEM PROPOSTA (MR)        I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4065- MOVE AC-S-MR023 TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MR023, AREA_DE_WORK.WWORK_SELECT);

            /*" -4066- MOVE AC-I-MR021 TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MR021, AREA_DE_WORK.WWORK_INSERT);

            /*" -4067- MOVE ZEROS TO WWORK-UPDATE */
            _.Move(0, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4068- MOVE ZEROS TO WWORK-DELETE */
            _.Move(0, AREA_DE_WORK.WWORK_DELETE);

            /*" -4074- DISPLAY 'I ITEM PROPOSTA COND (MR)   I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I ITEM PROPOSTA COND (MR)   I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4075- MOVE AC-S-MR017 TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MR017, AREA_DE_WORK.WWORK_SELECT);

            /*" -4076- MOVE AC-I-MR022 TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MR022, AREA_DE_WORK.WWORK_INSERT);

            /*" -4077- MOVE ZEROS TO WWORK-UPDATE */
            _.Move(0, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4078- MOVE ZEROS TO WWORK-DELETE */
            _.Move(0, AREA_DE_WORK.WWORK_DELETE);

            /*" -4084- DISPLAY 'I ITEM PROPOSTA EMPR (MR)   I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I ITEM PROPOSTA EMPR (MR)   I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4085- MOVE AC-S-MRPROCOR TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MRPROCOR, AREA_DE_WORK.WWORK_SELECT);

            /*" -4086- MOVE AC-I-MRAPOCOR TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MRAPOCOR, AREA_DE_WORK.WWORK_INSERT);

            /*" -4087- MOVE ZEROS TO WWORK-UPDATE */
            _.Move(0, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4088- MOVE ZEROS TO WWORK-DELETE */
            _.Move(0, AREA_DE_WORK.WWORK_DELETE);

            /*" -4094- DISPLAY 'I COBERTURA ITEM (MR)       I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I COBERTURA ITEM (MR)       I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4095- MOVE AC-S-MR026 TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MR026, AREA_DE_WORK.WWORK_SELECT);

            /*" -4096- MOVE AC-I-MR027 TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MR027, AREA_DE_WORK.WWORK_INSERT);

            /*" -4097- MOVE ZEROS TO WWORK-UPDATE */
            _.Move(0, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4098- MOVE ZEROS TO WWORK-DELETE */
            _.Move(0, AREA_DE_WORK.WWORK_DELETE);

            /*" -4104- DISPLAY 'I COBERTURA SUB ITEM (MR)   I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I COBERTURA SUB ITEM (MR)   I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4105- MOVE AC-S-MRPROBEN TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_MRPROBEN, AREA_DE_WORK.WWORK_SELECT);

            /*" -4106- MOVE AC-I-MRPROBEN TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_MRPROBEN, AREA_DE_WORK.WWORK_INSERT);

            /*" -4107- MOVE ZEROS TO WWORK-UPDATE */
            _.Move(0, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4108- MOVE ZEROS TO WWORK-DELETE */
            _.Move(0, AREA_DE_WORK.WWORK_DELETE);

            /*" -4114- DISPLAY 'I RELACAO DE BENS (MR)      I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I RELACAO DE BENS (MR)      I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4115- MOVE AC-S-EMISDIARIA TO WWORK-SELECT */
            _.Move(AREA_DE_WORK.AC_S_EMISDIARIA, AREA_DE_WORK.WWORK_SELECT);

            /*" -4116- MOVE AC-U-EMISDIARIA TO WWORK-UPDATE */
            _.Move(AREA_DE_WORK.AC_U_EMISDIARIA, AREA_DE_WORK.WWORK_UPDATE);

            /*" -4117- MOVE AC-I-EMISDIARIA TO WWORK-INSERT */
            _.Move(AREA_DE_WORK.AC_I_EMISDIARIA, AREA_DE_WORK.WWORK_INSERT);

            /*" -4118- MOVE AC-D-EMISDIARIA TO WWORK-DELETE */
            _.Move(AREA_DE_WORK.AC_D_EMISDIARIA, AREA_DE_WORK.WWORK_DELETE);

            /*" -4124- DISPLAY 'I EMISSAO DIARIA            I  ' WWORK-SELECT ' I  ' WWORK-UPDATE ' I  ' WWORK-INSERT ' I  ' WWORK-DELETE ' I' */

            $"I EMISSAO DIARIA            I  {AREA_DE_WORK.WWORK_SELECT} I  {AREA_DE_WORK.WWORK_UPDATE} I  {AREA_DE_WORK.WWORK_INSERT} I  {AREA_DE_WORK.WWORK_DELETE} I"
            .Display();

            /*" -4125- DISPLAY '+---------------------------+--------+--------+----- '---+--------+' . */
            _.Display($"+---------------------------+--------+--------+----- ---+--------+");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9500_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -4139- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -4140- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_1.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -4141- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_1.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -4143- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_1.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -4144- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4145- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4146- DISPLAY '*   EM0005B - ATUALIZACAO DB DE APOLICES   *' */
            _.Display($"*   EM0005B - ATUALIZACAO DB DE APOLICES   *");

            /*" -4147- DISPLAY '*   -------   ----------- -- -- --------   *' */
            _.Display($"*   -------   ----------- -- -- --------   *");

            /*" -4148- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4149- DISPLAY '*   NAO HOUVE MOVIMENTACAO DE PROPOSTAS    *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO DE PROPOSTAS    *");

            /*" -4151- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -4152- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4152- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4167- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -4169- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -4169- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -4171- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4175- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -4175- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}