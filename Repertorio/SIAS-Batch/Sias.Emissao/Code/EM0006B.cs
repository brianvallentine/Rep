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
using Sias.Emissao.DB2.EM0006B;

namespace Code
{
    public class EM0006B
    {
        public bool IsCall { get; set; }

        public EM0006B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  EMISSAO                            *      */
        /*"      *   PROGRAMA ...............  EM0006B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  PROCAS                             *      */
        /*"      *   PROGRAMADOR ............  PROCAS                             *      */
        /*"      *   DATA CODIFICACAO .......  JANEIRO/1993                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - A PARTIR DA TABELA V1PROPOSTA    *      */
        /*"      *                               ATUALIZA O DB DE APOLICES        *      */
        /*"      *                              (INCENDIO)                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           INPUT    *      */
        /*"      * RAMOS                               V1RAMOIND         INPUT    *      */
        /*"      * NUMERO DE APOLICES/ENDOSSOS         V0NUMERO_AES      I-O      *      */
        /*"      * PROPOSTAS                           V1PROPOSTA        INPUT    *      */
        /*"      * PROPOSTA INCENDIO                   V1PROPINC         INPUT    *      */
        /*"      * PROPOSTA LOCAL INCENDIO             V1PROPLOCALINC    INPUT    *      */
        /*"      * PROPOSTA DESCONTO INCENDIO          V1PROPINCDESC     INPUT    *      */
        /*"      * COBERTURAS PROPOSTA INCENDIO        V1COBERPROP_INC   INPUT    *      */
        /*"      * DESCRICAO PROPOSTA INCENDIO         V1PROPDESCR_INC   INPUT    *      */
        /*"      * PROPOSTA DESCONTO INCENDIO          V1PROPINCDESC     INPUT    *      */
        /*"      * PROPOSTA OUTROS SEGUROS INCENDIO    V1PROPOUTINC      INPUT    *      */
        /*"      * PROPOSTA DESCRICAO COBERTURAS       V1PROPDESCOBER    INPUT    *      */
        /*"      * APOLICES                            V0APOLICE         OUTPUT   *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * APOLICE LOCAL INCENDIO              V0APOLOCALINC     OUTPUT   *      */
        /*"      * APOLICE ITENS INCENDIO              V0APOITENSINC     OUTPUT   *      */
        /*"      * COBERTURAS APOLICE INCENDIO         V0COBERINC        OUTPUT   *      */
        /*"      * DESCRICAO APOLICE INCENDIO          V0APODESITEM      OUTPUT   *      */
        /*"      * APOLICE DESCONTO INCENDIO           V0APOLINCDESC     INPUT    *      */
        /*"      * APOLICE OUTROS SEGUROS INCENDIO     V0APOLOUTINC      INPUT    *      */
        /*"      * APOLICE DESCRICAO COBERTURAS        V0APOLDESCOBER    INPUT    *      */
        /*"      * EMISSAO DIARIA                      V0EMISDIARIA      OUTPUT   *      */
        /*"      * MALHA DE PRODUCAO                   V0MALHAPROD       OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 25/04/1998.   *      */
        /*"      *                                                                *      */
        /*"      *    29/12/98 - CONSEDA4                                         *      */
        /*"      *    ALTERACAO DO CALCULO DO IOF - ACESSO A TABELA V1RAMOIND     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         W1CPRO-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis W1CPRO_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W1COBP-PCT-TOTAL    PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PCT_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1COBP-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W1COBI-ANU-IX       PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W1COBI_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-PCT-COBERT   PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis W0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         W0NAES-SEQ-APOL     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W0NAES_SEQ_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1PCOR-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W1PCOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         W1COBA-ULTENDO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis W1COBA_ULTENDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         VIND-ULTENDO        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis VIND_ULTENDO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         W0COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis W0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis W0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis W0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         W0COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis W0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         W0COBI-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis W0COBI_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         VIND-NUM-ATA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-ANO-ATA        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-SORT       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DAT_SORT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTLIBER        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTAPOLM        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTAPOLM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DAT-RCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DAT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-COD-EMP        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIMESTAMP      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CORRECAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-TIPO-ENDOSSO   PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_TIPO_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-APOLICE    PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CODPRODU       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTVENCTO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-INSPETOR       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CANALPROD      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CANALPROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-PRMTARIFA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_PRMTARIFA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-CFPREFIX       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-VLCUSEMI       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1FONT-NOMEFTE      PIC  X(040).*/
        public StringBasis V1FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1FONT-ORGAOEMIS    PIC S9(004)    VALUE +0     COMP.*/
        public IntBasis V1FONT_ORGAOEMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1RAMO-PCIOF        PIC S9(003)V99  VALUE +0   COMP-3*/
        public DoubleBasis V1RAMO_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0NAES-COD-ORGAO    PIC S9(004)     VALUE +0   COMP.*/
        public IntBasis V0NAES_COD_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-COD-RAMO     PIC S9(004)     VALUE +0   COMP.*/
        public IntBasis V0NAES_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0NAES-SEQ-APOL     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_SEQ_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSCOB     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_ENDOSCOB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-NRENDOCA     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSRES     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_ENDOSRES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSSEM     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_ENDOSSEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSCCR     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_ENDOSCCR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-ENDOSMVC     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_ENDOSMVC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-NUMSIN       PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_NUMSIN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0NAES-PROPOATM     PIC S9(009)     VALUE +0   COMP.*/
        public IntBasis V0NAES_PROPOATM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-TPPROPOS     PIC  X(001).*/
        public StringBasis V1PROP_TPPROPOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-FONTE        PIC S9(004)                COMP.*/
        public IntBasis V1PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NRPROPOS     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-RAMO         PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PROP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-MODALIDA     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PROP_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NUM-APO-ANT  PIC S9(013)   VALUE +0     COMP-3*/
        public IntBasis V1PROP_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PROP-TIPAPO       PIC  X(001).*/
        public StringBasis V1PROP_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-CODCLIEN     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PROP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PROP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-PODPUBL      PIC  X(001).*/
        public StringBasis V1PROP_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-CORRECAO     PIC  X(001).*/
        public StringBasis V1PROP_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-MOEDA-IMP    PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-MOEDA-PRM    PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-PRESTA1      PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-BCORCAP      PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-AGERCAP      PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NRRCAP       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PROP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-VLRCAP       PIC S9(013)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PROP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PROP-CDFRACIO     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTPARCEL     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROP_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-PCENTRAD     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PROP_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PROP-PCADICIO     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PROP_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PROP-IDIOF        PIC  X(001).*/
        public StringBasis V1PROP_IDIOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-ISENTA-CST   PIC  X(001).*/
        public StringBasis V1PROP_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-QTPRESTA     PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-BCOCOBR      PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-AGECOBR      PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-TPCORRET     PIC  X(001).*/
        public StringBasis V1PROP_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NRAUTCOR     PIC S9(009)  VALUE +0      COMP.*/
        public IntBasis V1PROP_NRAUTCOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-QTCORR       PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTCORR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTCORRC      PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTCORRC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-NUM-APO-MAN  PIC S9(013)  VALUE +0      COMP-3*/
        public IntBasis V1PROP_NUM_APO_MAN { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PROP-TPCOSCED     PIC  X(001).*/
        public StringBasis V1PROP_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-QTCOSSGC     PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTCOSSGC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTCOSSEG     PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTITENSI     PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTITENSI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-QTITENS      PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-TPMOVTO      PIC  X(001).*/
        public StringBasis V1PROP_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-DTENTRAD     PIC  X(010).*/
        public StringBasis V1PROP_DTENTRAD { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTCADAST     PIC  X(010).*/
        public StringBasis V1PROP_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-TIPCALC      PIC  X(001).*/
        public StringBasis V1PROP_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-LIMIND       PIC S9(004)  VALUE +0      COMP.*/
        public IntBasis V1PROP_LIMIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-CDACEITA     PIC  X(001).*/
        public StringBasis V1PROP_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NRAUTACE     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_NRAUTACE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-PCDESCON     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PROP_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PROP-IDRCAP       PIC  X(001).*/
        public StringBasis V1PROP_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-CODTXT       PIC  X(001).*/
        public StringBasis V1PROP_CODTXT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NUM-RENOV    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_NUM_RENOV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-CONV-COBR    PIC  X(001).*/
        public StringBasis V1PROP_CONV_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-OCORR-END    PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PROP_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-SITUACAO     PIC  X(001).*/
        public StringBasis V1PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-COD-USUAR    PIC  X(008).*/
        public StringBasis V1PROP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1PROP-NUM-ATA      PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-ANO-ATA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PROP_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-DATA-SORT    PIC  X(010).*/
        public StringBasis V1PROP_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTLIBER      PIC  X(010).*/
        public StringBasis V1PROP_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DTAPOLM      PIC  X(010).*/
        public StringBasis V1PROP_DTAPOLM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-DATARCAP     PIC  X(010).*/
        public StringBasis V1PROP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PROP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PROP-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V1PROP_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PROP-NUM-APOLICE  PIC S9(013)   VALUE +0     COMP-3*/
        public IntBasis V1PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1PROP-INSPETOR     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-CANALPROD    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PROP_CANALPROD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROP-CODPRODU     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROP-DTVENCTO     PIC  X(010).*/
        public StringBasis V1PROP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROP-CFPREFIX     PIC S9(004)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V1PROP_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1PROP-VLCUSEMI     PIC S9(013)V9(2) VALUE +0 COMP-3.*/
        public DoubleBasis V1PROP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0APOL-CODCLIEN    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0APOL_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-NUM-APOL    PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUM-ITEM    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0APOL_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-MODALIDA    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-ORGAO       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-RAMO        PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-NUM-APO-ANT PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V0APOL_NUM_APO_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-NUMBIL      PIC S9(015)       VALUE +0  COMP-3*/
        public IntBasis V0APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0APOL-TIPSGU      PIC  X(001).*/
        public StringBasis V0APOL_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPAPO      PIC  X(001).*/
        public StringBasis V0APOL_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-TIPCALC     PIC  X(001).*/
        public StringBasis V0APOL_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PODPUBL     PIC  X(001).*/
        public StringBasis V0APOL_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-NUM-ATA     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0APOL_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-ANO-ATA     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0APOL_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-IDEMAN      PIC  X(001).*/
        public StringBasis V0APOL_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-PCDESCON    PIC S9(003)V9(02) VALUE +0  COMP-3*/
        public DoubleBasis V0APOL_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-PCIOCC      PIC S9(003)V9(02) VALUE +0  COMP-3*/
        public DoubleBasis V0APOL_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0APOL-TPCOSCED    PIC  X(001).*/
        public StringBasis V0APOL_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APOL-QTCOSSEG    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-PCTCED      PIC S9(004)V9(05) VALUE +0  COMP-3*/
        public DoubleBasis V0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(05)"), 5);
        /*"77         V0APOL-DATA-SORT   PIC  X(010).*/
        public StringBasis V0APOL_DATA_SORT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOL-COD-EMPRESA PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0APOL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOL-CODPRODU    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-TPCORRET    PIC  X(001).*/
        public StringBasis V0APOL_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-NUM-APOL    PIC S9(013)       VALUE +0  COMP-3*/
        public IntBasis V0ENDO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ENDO-NRENDOS     PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CODSUBES    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-FONTE       PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-NRPROPOS    PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-DATPRO      PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DT-LIBER    PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTEMIS      PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-NRRCAP      PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-VLRCAP      PIC S9(013)V9(02) VALUE +0  COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"77         V0ENDO-BCORCAP     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGERCAP     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACRCAP     PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-IDRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-BCOCOBR     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-AGECOBR     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-DACCOBR     PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTINIVIG    PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-DTTERVIG    PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CDFRACIO    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-PCENTRAD    PIC S9(003)V9(02) VALUE +0  COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PCADICIO    PIC S9(003)V9(02) VALUE +0  COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"77         V0ENDO-PRESTA1     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPARCEL    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTPRESTA    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-QTITENS     PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODTXT      PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0ENDO-CDACEITA    PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-MOEDA-IMP   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-MOEDA-PRM   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-TIPEND      PIC  X(001).*/
        public StringBasis V0ENDO_TIPEND { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-COD-USUAR   PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ENDO-OCORR-END   PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-SITUACAO    PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DATARCAP    PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-COD-EMPRESA PIC S9(009)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ENDO-CORRECAO    PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-ISENTA-CST  PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ENDO-DTVENCTO    PIC  X(010).*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ENDO-CFPREFIX    PIC S9(004)V9(5)  VALUE +0  COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0ENDO-VLCUSEMI    PIC S9(013)V9(2)  VALUE +0  COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0ENDO-RAMO        PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ENDO-CODPRODU    PIC S9(004)       VALUE +0  COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PCOR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PCOR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PCOR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PCOR_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOR-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PCOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-PCPARCOR     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1PCOR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PCOR-PCCOMCOR     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1PCOR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PCOR-INDCRT       PIC  X(001).*/
        public StringBasis V1PCOR_INDCRT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PCOR-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PCOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOR-COD-USUARIO  PIC  X(008).*/
        public StringBasis V1PCOR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0ACOR-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ACOR_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ACOR-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ACOR_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOR-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ACOR_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOR-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ACOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ACOR-CODSUBES     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ACOR_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOR-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ACOR_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACOR-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ACOR_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACOR-PCPARCOR     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0ACOR_PCPARCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0ACOR-PCCOMCOR     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0ACOR_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0ACOR-TIPCOM       PIC  X(001).*/
        public StringBasis V0ACOR_TIPCOM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ACOR-INDCRT       PIC  X(001).*/
        public StringBasis V0ACOR_INDCRT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0ACOR-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ACOR_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ACOR-COD-USUARIO  PIC  X(008).*/
        public StringBasis V0ACOR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1COSS-RAMO         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COSS_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSS-CONGENER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COSS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COSS-PCPARTIC     PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COSS_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1COSS-PCCOMCOS     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COSS_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COSS-SITUACAO     PIC  X(001).*/
        public StringBasis V1COSS_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PCOS-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PCOS_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOS-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PCOS_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PCOS-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PCOS_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOS-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PCOS_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PCOS-PCPARTIC     PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1PCOS_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V1PCOS-PCCOMCOS     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1PCOS_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PCOS-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PCOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0ACOS-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ACOS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0ACOS-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ACOS_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOS-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ACOS_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0ACOS-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ACOS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACOS-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ACOS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0ACOS-PCPARTIC     PIC S9(004)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0ACOS_PCPARTIC { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0ACOS-PCCOMCOS     PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0ACOS_PCCOMCOS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0ACOS-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ACOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-NUM-ITEM     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-COD-COBER    PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PCT-COBERT   PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V0COBA-FATOR-MULT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-DTTERVIG     PIC  X(010).*/
        public StringBasis V0COBA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBA-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBA-SITREG       PIC  X(001)      VALUE      '0'.*/
        public StringBasis V0COBA_SITREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"77         V1COBA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V1COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V1COBA-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-COD-COBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-IMP-SEG-IX   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBA-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-IMP-SEG-VR   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V1COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBA-PRM-TAR-VR   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V1COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBA-PCT-COBERT   PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V1COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1COBA-FATOR-MULT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V1COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V1COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBA-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBA-SITREG       PIC  X(001)       VALUE     '0'.*/
        public StringBasis V1COBA_SITREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"77         V0APRO-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APRO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APRO-NRPROPOS     PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APRO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APRO-OPERACAO     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APRO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APRO-DATOPR       PIC  X(010).*/
        public StringBasis V0APRO_DATOPR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APRO-HORAOPER     PIC  X(008).*/
        public StringBasis V0APRO_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0APRO-OCORHIST     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APRO_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APRO-CODUSU       PIC  X(008).*/
        public StringBasis V0APRO_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0APRO-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APRO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1APRO-DATOPR       PIC  X(010).*/
        public StringBasis V1APRO_DATOPR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1APRO-HORAOPER     PIC  X(008).*/
        public StringBasis V1APRO_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V1PRIN-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRIN-FONTE        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRIN-NRPROPOS     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRIN-NUM-RISCO    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRIN-CODCOBINC    PIC  X(003).*/
        public StringBasis V1PRIN_CODCOBINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1PRIN-SUBRIS       PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRIN-NRITEM       PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRIN-COD-PLANTA   PIC  X(005).*/
        public StringBasis V1PRIN_COD_PLANTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"77         V1PRIN-COD-RUBRICA  PIC  X(003).*/
        public StringBasis V1PRIN_COD_RUBRICA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1PRIN-CLASOCUPA    PIC  X(002).*/
        public StringBasis V1PRIN_CLASOCUPA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1PRIN-CLASCONST    PIC  X(002).*/
        public StringBasis V1PRIN_CLASCONST { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1PRIN-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRIN-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRIN-IMP-SEG-IX   PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRIN-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRIN-TIPCOND      PIC  X(003).*/
        public StringBasis V1PRIN_TIPCOND { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1PRIN-TAXA-PRM     PIC S9(002)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_TAXA_PRM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(5)"), 5);
        /*"77         V1PRIN-TIPO-TAXA    PIC  X(001).*/
        public StringBasis V1PRIN_TIPO_TAXA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRIN-PCDESCON     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PRIN-TPDESCON     PIC  X(001).*/
        public StringBasis V1PRIN_TPDESCON { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRIN-PCADICIO     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PRIN-PCVALRISC    PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_PCVALRISC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PRIN-COEFAGRAV    PIC S9(003)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V1PRIN_COEFAGRAV { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
        /*"77         V1PRIN-TIPRAZO      PIC  X(001).*/
        public StringBasis V1PRIN_TIPRAZO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRIN-SITUACAO     PIC  X(001).*/
        public StringBasis V1PRIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRIN-TPMOVTO      PIC  X(001).*/
        public StringBasis V1PRIN_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PRIN-TPOCUP       PIC  X(002).*/
        public StringBasis V1PRIN_TPOCUP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1PRIN-SPOCUP       PIC  X(002).*/
        public StringBasis V1PRIN_SPOCUP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V1PRIN-QTPAVTO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PRIN_QTPAVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APIN-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APIN_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APIN-NUM-APOL     PIC S9(013)   VALUE +0     COMP-3*/
        public IntBasis V0APIN_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APIN-NRENDOS      PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APIN_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APIN-NUM-RISCO    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APIN_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APIN-CODCOBINC    PIC  X(003).*/
        public StringBasis V0APIN_CODCOBINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0APIN-SUBRIS       PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APIN_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APIN-NRITEM       PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APIN_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APIN-COD-PLANTA   PIC  X(005).*/
        public StringBasis V0APIN_COD_PLANTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"77         V0APIN-COD-RUBRICA  PIC  X(003).*/
        public StringBasis V0APIN_COD_RUBRICA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0APIN-CLASOCUPA    PIC  X(002).*/
        public StringBasis V0APIN_CLASOCUPA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0APIN-CLASCONST    PIC  X(002).*/
        public StringBasis V0APIN_CLASCONST { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0APIN-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APIN_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APIN-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APIN_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APIN-IMP-SEG-IX   PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APIN-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APIN-TIPCOND      PIC  X(003).*/
        public StringBasis V0APIN_TIPCOND { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0APIN-TAXA-PRM     PIC S9(002)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_TAXA_PRM { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(002)V9(5)"), 5);
        /*"77         V0APIN-TIPO-TAXA    PIC  X(001).*/
        public StringBasis V0APIN_TIPO_TAXA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APIN-PCDESCON     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0APIN-TPDESCON     PIC  X(001).*/
        public StringBasis V0APIN_TPDESCON { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APIN-PCADICIO     PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0APIN-PCVALRISC    PIC S9(003)V99    VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_PCVALRISC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0APIN-COEFAGRAV    PIC S9(003)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0APIN_COEFAGRAV { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
        /*"77         V0APIN-TIPRAZO      PIC  X(001).*/
        public StringBasis V0APIN_TIPRAZO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APIN-SITUACAO     PIC  X(001).*/
        public StringBasis V0APIN_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APIN-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APIN_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0APIN-TPMOVTO      PIC  X(001).*/
        public StringBasis V0APIN_TPMOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APIN-TPOCUP       PIC  X(002).*/
        public StringBasis V0APIN_TPOCUP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0APIN-SPOCUP       PIC  X(002).*/
        public StringBasis V0APIN_SPOCUP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77         V0APIN-QTPAVTO      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V0APIN_QTPAVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APIN-OCORHIST     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V0APIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APIN-OCORHIST     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1APIN_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-CODCOBER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_CODCOBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRCL-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1PRCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRCL-CODCLAUS     PIC  X(003).*/
        public StringBasis V1PRCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1PRCL-LIM-IND-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1PRCL_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1PRCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1PRCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRCL-TIPOCLAU     PIC  X(001).*/
        public StringBasis V1PRCL_TIPOCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCL-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0APCL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APCL-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-RAMOFR       PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-MODALIFR     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-COD-COBERT   PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0APCL_COD_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APCL-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APCL_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCL-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APCL_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APCL-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0APCL_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APCL-CODCLAUS     PIC  X(003).*/
        public StringBasis V0APCL_CODCLAUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0APCL-TIPOCLAU     PIC  X(001).*/
        public StringBasis V0APCL_TIPOCLAU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APCL-LIM-IND-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0APCL_LIM_IND_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0APCL-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0APCL_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1COBP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBP-NRPROPOS     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-NUM-RISCO    PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-SUBRIS       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V1COBP_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1COBP-CODCOBINC    PIC  X(003).*/
        public StringBasis V1COBP_CODCOBINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1COBP-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V1COBP-TIPCOBINC    PIC  X(003).*/
        public StringBasis V1COBP_TIPCOBINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V1COBP-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V1COBP_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V1COBP-DTINIVIG     PIC  X(010).*/
        public StringBasis V1COBP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-DTTERVIG     PIC  X(010).*/
        public StringBasis V1COBP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1COBP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V1COBP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBI-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBI-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0COBI_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0COBI-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBI-NUM-RISCO    PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBI_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBI-SUBRIS       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBI_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBI-NRITEM       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0COBI_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0COBI-CODCOBINC    PIC  X(003).*/
        public StringBasis V0COBI_CODCOBINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0COBI-IMP-SEG-IX   PIC S9(013)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V0COBI_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"77         V0COBI-TIPCOBINC    PIC  X(003).*/
        public StringBasis V0COBI_TIPCOBINC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"77         V0COBI-PRM-TAR-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBI_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBI-PRM-ANU-IX   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBI_PRM_ANU_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBI-PRM-TAR-VR   PIC S9(010)V9(5) VALUE +0  COMP-3*/
        public DoubleBasis V0COBI_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBI-DTINIVIG     PIC  X(010).*/
        public StringBasis V0COBI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBI-DTTERVIG     PIC  X(010).*/
        public StringBasis V0COBI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0COBI-SITUACAO     PIC  X(001).*/
        public StringBasis V0COBI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0COBI-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0COBI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V0COBI-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0COBI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1COBI-OCORHIST     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1COBI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CODRELAT     PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0EDIA-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0EDIA-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-DTMOVTO      PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0EDIA-ORGAO        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-RAMO         PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-FONTE        PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CONGENER     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0EDIA-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0EDIA-SITUACAO     PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0EDIA-COD-EMP      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0EDIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MPRD-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0MPRD_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0MPRD-CODSUBES     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0MPRD-CODCORR      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODPRP       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_CODPRP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODCLB       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_CODCLB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-INSPETOR     PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_INSPETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-ISPRGI       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_ISPRGI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODGTE       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_CODGTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-CODSTE       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_CODSTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-DIRRGI       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_DIRRGI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-DIRCMC       PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_DIRCMC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0MPRD-COD-EMP      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0MPRD_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDI-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRDI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDI-FONTE        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PRDI_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRDI-NRPROPOS     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRDI_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDI-NUM-RISCO    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRDI_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDI-NRITEM       PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRDI_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDI-COD-PLANTA   PIC  X(005).*/
        public StringBasis V1PRDI_COD_PLANTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"77         V1PRDI-NRLINHA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PRDI_NRLINHA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRDI-DESC-LINHA   PIC  X(035).*/
        public StringBasis V1PRDI_DESC_LINHA { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
        /*"77         V1PRDI-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRDI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRDI-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRDI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APDI-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APDI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDI-NUM-APOL     PIC S9(013)   VALUE +0     COMP-3*/
        public IntBasis V0APDI_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APDI-NRENDOS      PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APDI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDI-NUM-RISCO    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APDI_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDI-NRITEM       PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APDI_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDI-COD-PLANTA   PIC  X(005).*/
        public StringBasis V0APDI_COD_PLANTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"77         V0APDI-NRLINHA      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V0APDI_NRLINHA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APDI-DESC-LINHA   PIC  X(035).*/
        public StringBasis V0APDI_DESC_LINHA { get; set; } = new StringBasis(new PIC("X", "35", "X(035)."), @"");
        /*"77         V0APDI-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APDI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APDI-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APDI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APDI-OCORHIST     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V0APDI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRLI-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRLI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRLI-FONTE        PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PRLI_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRLI-NRPROPOS     PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRLI_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRLI-NUM-RISCO    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRLI_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRLI-COD-LOCAL    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V1PRLI_COD_LOCAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRLI-QTITENS      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1PRLI_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRLI-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRLI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRLI-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRLI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRLI-SITUACAO     PIC  X(001).*/
        public StringBasis V1PRLI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APLI-COD-EMPRESA  PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APLI_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APLI-NUM-APOL     PIC S9(013)   VALUE +0     COMP-3*/
        public IntBasis V0APLI_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APLI-NRENDOS      PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APLI_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APLI-NUM-RISCO    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APLI_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APLI-COD-LOCAL    PIC S9(009)   VALUE +0     COMP.*/
        public IntBasis V0APLI_COD_LOCAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APLI-QTITENS      PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V0APLI_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APLI-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APLI_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APLI-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APLI_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APLI-SITUACAO     PIC  X(001).*/
        public StringBasis V0APLI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APLI-OCORHIST     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V0APLI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1APLI-OCORHIST     PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis V1APLI_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PIND-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PIND-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PIND_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PIND-NRPROPOS     PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PIND_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PIND-NUM-RISCO    PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PIND_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PIND-SUBRIS       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PIND_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PIND-NRITEM       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PIND_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PIND-PLANTA       PIC  X(005).*/
        public StringBasis V1PIND_PLANTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"77         V1PIND-PCDESPRT     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PIND_PCDESPRT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PIND-TPDESCON     PIC  X(001).*/
        public StringBasis V1PIND_TPDESCON { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V1PIND-PCDESTAR     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PIND_PCDESTAR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V1PIND-DESCDESCON   PIC  X(030).*/
        public StringBasis V1PIND_DESCDESCON { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77         V1PIND-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PIND-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PIND_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PIND-SITUACAO     PIC  X(001).*/
        public StringBasis V1PIND_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APID-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APID_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APID-NUM-APOL     PIC S9(013)    VALUE +0    COMP-3*/
        public IntBasis V0APID_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APID-NRENDOS      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APID_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APID-NUM-RISCO    PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APID_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APID-SUBRIS       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APID_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APID-NRITEM       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APID_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APID-PLANTA       PIC  X(005).*/
        public StringBasis V0APID_PLANTA { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
        /*"77         V0APID-PCDESPRT     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V0APID_PCDESPRT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0APID-TPDESCON     PIC  X(001).*/
        public StringBasis V0APID_TPDESCON { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APID-PCDESTAR     PIC S9(003)V99 VALUE +0    COMP-3*/
        public DoubleBasis V0APID_PCDESTAR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77         V0APID-DESCDESCON   PIC  X(030).*/
        public StringBasis V0APID_DESCDESCON { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"77         V0APID-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APID_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APID-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APID_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APID-SITUACAO     PIC  X(001).*/
        public StringBasis V0APID_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APID-OCORHIST     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APID_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROU-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PROU_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROU_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROU-NRPROPOS     PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PROU_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROU-APOLIDER     PIC  X(015).*/
        public StringBasis V1PROU_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V1PROU-CODLIDER     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PROU_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PROU-IMP-SEG-IX   PIC S9(013)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PROU_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PROU-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PROU_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PROU-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PROU_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOU-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APOU_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-NUM-APOL     PIC S9(013)    VALUE +0    COMP-3*/
        public IntBasis V0APOU_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOU-NRENDOS      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APOU_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APOU-APOLIDER     PIC  X(015).*/
        public StringBasis V0APOU_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77         V0APOU-CODLIDER     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APOU_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOU-IMP-SEG-IX   PIC S9(013)V99 VALUE +0    COMP-3*/
        public DoubleBasis V0APOU_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APOU-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APOU_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOU-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APOU_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOU-OCORHIST     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APOU_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRDC-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PRDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDC-FONTE        PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V1PRDC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRDC-NRPROPOS     PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PRDC_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDC-NUM-RISCO    PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PRDC_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDC-SUBRIS       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PRDC_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDC-NRITEM       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V1PRDC_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PRDC-DESCR-BENS   PIC  X(040).*/
        public StringBasis V1PRDC_DESCR_BENS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V1PRDC-IMP-SEG-IX   PIC S9(013)V99 VALUE +0    COMP-3*/
        public DoubleBasis V1PRDC_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V1PRDC-DTINIVIG     PIC  X(010).*/
        public StringBasis V1PRDC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRDC-DTTERVIG     PIC  X(010).*/
        public StringBasis V1PRDC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V1PRDC-SITUACAO     PIC  X(001).*/
        public StringBasis V1PRDC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APDC-COD-EMPRESA  PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDC-NUM-APOL     PIC S9(013)    VALUE +0    COMP-3*/
        public IntBasis V0APDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APDC-NRENDOS      PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDC-NUM-RISCO    PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APDC_NUM_RISCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDC-SUBRIS       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APDC_SUBRIS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDC-NRITEM       PIC S9(009)    VALUE +0    COMP.*/
        public IntBasis V0APDC_NRITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0APDC-DESCR-BENS   PIC  X(040).*/
        public StringBasis V0APDC_DESCR_BENS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77         V0APDC-IMP-SEG-IX   PIC S9(013)V99 VALUE +0    COMP-3*/
        public DoubleBasis V0APDC_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0APDC-DTINIVIG     PIC  X(010).*/
        public StringBasis V0APDC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APDC-DTTERVIG     PIC  X(010).*/
        public StringBasis V0APDC_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APDC-SITUACAO     PIC  X(001).*/
        public StringBasis V0APDC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0APDC-OCORHIST     PIC S9(004)    VALUE +0    COMP.*/
        public IntBasis V0APDC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAC-QTD-DIAS     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRAC_QTD_DIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAC-PCTPRAZOVIG  PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1PRAC_PCTPRAZOVIG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         V1PRAL-QTD-MES      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V1PRAL_QTD_MES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PRAL-PCTPRAZOVIG  PIC S9(003)V9(2) VALUE +0  COMP-3*/
        public DoubleBasis V1PRAL_PCTPRAZOVIG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"77         W0APOL-PCTCED     PIC S9(004)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis W0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         W0APOL-QTCOSSEG   PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis W0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public EM0006B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new EM0006B_AREA_DE_WORK();
        public class EM0006B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WNUMERO-APOL      PIC  9(013)    VALUE ZEROS.*/
            public IntBasis WNUMERO_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05         FILLER            REDEFINES      WNUMERO-APOL.*/
            private _REDEF_EM0006B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM0006B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM0006B_FILLER_0(); _.Move(WNUMERO_APOL, _filler_0); VarBasis.RedefinePassValue(WNUMERO_APOL, _filler_0, WNUMERO_APOL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WNUMERO_APOL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WNUMERO_APOL); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_0 : VarBasis
            {
                /*"    10       WNUM-APOL-ORG     PIC  9(003).*/
                public IntBasis WNUM_APOL_ORG { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WNUM-APOL-RAM     PIC  9(002).*/
                public IntBasis WNUM_APOL_RAM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WNUM-APOL-SEQ     PIC  9(008).*/
                public IntBasis WNUM_APOL_SEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  05         WNUM-APOLICE      PIC S9(013)    VALUE +0  COMP-3.*/

                public _REDEF_EM0006B_FILLER_0()
                {
                    WNUM_APOL_ORG.ValueChanged += OnValueChanged;
                    WNUM_APOL_RAM.ValueChanged += OnValueChanged;
                    WNUM_APOL_SEQ.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05         WNUM-ENDOSSO      PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WNUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WHOST-NUM-ITEM    PIC S9(009)    VALUE +0  COMP.*/
            public IntBasis WHOST_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WS-COEFPRAZO      PIC S9(004)V9(5) VALUE +0 COMP-3.*/
            public DoubleBasis WS_COEFPRAZO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
            /*"  05         WS-QTD-MES        PIC S9(004)    VALUE +0   COMP.*/
            public IntBasis WS_QTD_MES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WS-OCORHIST       PIC S9(004)    VALUE +0   COMP.*/
            public IntBasis WS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WFIM-PROGRAMA     PIC  X(001)    VALUE  LOW-VALUES.*/
            public StringBasis WFIM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05         CH-I-V0COBERAPOL  PIC  X(001)    VALUE  LOW-VALUES.*/
            public StringBasis CH_I_V0COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  05         W0ACOR-CODCORR    PIC S9(009)    VALUE +0  COMP.*/
            public IntBasis W0ACOR_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WABEND-0C7-G.*/
            public EM0006B_WABEND_0C7_G WABEND_0C7_G { get; set; } = new EM0006B_WABEND_0C7_G();
            public class EM0006B_WABEND_0C7_G : VarBasis
            {
                /*"    07       WABEND-0C7        PIC  9(005) COMP-3.*/
                public IntBasis WABEND_0C7 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"  05         CH-DESPREZOU      PIC  9(002)    VALUE  0.*/
            }
            public IntBasis CH_DESPREZOU { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         CH-CORR-ANT       PIC  9(009)    VALUE  999999999.*/
            public IntBasis CH_CORR_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 999999999);
            /*"  05         WSL-SQLCODE         PIC  9(009)  VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WS-NUM-ITEM         PIC S9(009)  VALUE +0  COMP.*/
            public IntBasis WS_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WFIM-V1SISTEMA      PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPOSTA     PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBERAPOL    PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1COBERAPOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1ACOMPROP     PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1ACOMPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCORRET   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCOSCED   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPLOCINC   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPLOCINC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPINC      PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPINC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPCLAUS    PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPCLAUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1COBPROPINC   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1COBPROPINC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPDESINC   PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPDESINC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPDESCO    PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPDESCO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPOUTR     PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPOUTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1PROPDCOB     PIC  X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1PROPDCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         AC-L-V1PROPOSTA     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPOSTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPCLAUS    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPCORRET   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPCOSCED   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPLOCINC   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPLOCINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPINC      PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1COBPROPINC   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1COBPROPINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPDESINC   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPDESINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPDESCO    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPDESCO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPOUTR     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPOUTR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-V1PROPDCOB     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_L_V1PROPDCOB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ENDOSSO      PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLICE      PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLICE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCLAUS    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCLAUS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCORRET   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCORRET { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLCOSCED   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLCOSCED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0COBERAPOL    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0COBERINC     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLOCINC    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLOCINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOITENSINC  PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOITENSINC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APODESITEM   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APODESITEM { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLDESCO    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLDESCO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLOUTR     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLOUTR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0APOLDCOB     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0APOLDCOB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0ACOMPROP     PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0ACOMPROP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0EMISDIARIA   PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-I-V0MALHAPROD    PIC  9(005)    VALUE ZEROS.*/
            public IntBasis AC_I_V0MALHAPROD { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WDATA-SQL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-SQL.*/
            private _REDEF_EM0006B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM0006B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM0006B_FILLER_1(); _.Move(WDATA_SQL, _filler_1); VarBasis.RedefinePassValue(WDATA_SQL, _filler_1, WDATA_SQL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_SQL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-ANO-SQL      PIC  9(004).*/
                public IntBasis WDAT_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-MES-SQL      PIC  9(002).*/
                public IntBasis WDAT_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-DIA-SQL      PIC  9(002).*/
                public IntBasis WDAT_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-REL         PIC  X(010)    VALUE SPACES.*/

                public _REDEF_EM0006B_FILLER_1()
                {
                    WDAT_ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_EM0006B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_EM0006B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_EM0006B_FILLER_4(); _.Move(WDATA_REL, _filler_4); VarBasis.RedefinePassValue(WDATA_REL, _filler_4, WDATA_REL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_REL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_4 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDAT-REL-LIT.*/

                public _REDEF_EM0006B_FILLER_4()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public EM0006B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new EM0006B_WDAT_REL_LIT();
            public class EM0006B_WDAT_REL_LIT : VarBasis
            {
                /*"    10       WDAT-LIT-DIA      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-MES      PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDAT-LIT-ANO      PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WTIME-DAY         PIC  99.99.99.99.*/
            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  05         FILLER            REDEFINES      WTIME-DAY.*/
            private _REDEF_EM0006B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_EM0006B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_EM0006B_FILLER_9(); _.Move(WTIME_DAY, _filler_9); VarBasis.RedefinePassValue(WTIME_DAY, _filler_9, WTIME_DAY); _filler_9.ValueChanged += () => { _.Move(_filler_9, WTIME_DAY); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_9 : VarBasis
            {
                /*"    10       WTIME-DAYR.*/
                public EM0006B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM0006B_WTIME_DAYR();
                public class EM0006B_WTIME_DAYR : VarBasis
                {
                    /*"      15     WTIME-HORA        PIC  X(002).*/
                    public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT1        PIC  X(001).*/
                    public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-MINU        PIC  X(002).*/
                    public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     WTIME-2PT2        PIC  X(001).*/
                    public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15     WTIME-SEGU        PIC  X(002).*/
                    public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10       WTIME-2PT3        PIC  X(001).*/

                    public EM0006B_WTIME_DAYR()
                    {
                        WTIME_HORA.ValueChanged += OnValueChanged;
                        WTIME_2PT1.ValueChanged += OnValueChanged;
                        WTIME_MINU.ValueChanged += OnValueChanged;
                        WTIME_2PT2.ValueChanged += OnValueChanged;
                        WTIME_SEGU.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-CCSE        PIC  X(002).*/
                public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         W0NUM-ITEM        PIC  9(009) VALUE  0.*/

                public _REDEF_EM0006B_FILLER_9()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W0NUM_ITEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         FILLER    REDEFINES  W0NUM-ITEM.*/
            private _REDEF_EM0006B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_EM0006B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_EM0006B_FILLER_10(); _.Move(W0NUM_ITEM, _filler_10); VarBasis.RedefinePassValue(W0NUM_ITEM, _filler_10, W0NUM_ITEM); _filler_10.ValueChanged += () => { _.Move(_filler_10, W0NUM_ITEM); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, W0NUM_ITEM); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_10 : VarBasis
            {
                /*"    10       W0-NUMERO         PIC  9(007).*/
                public IntBasis W0_NUMERO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"    10       W0-SUB-NUMERO     PIC  9(002).*/
                public IntBasis W0_SUB_NUMERO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/

                public _REDEF_EM0006B_FILLER_10()
                {
                    W0_NUMERO.ValueChanged += OnValueChanged;
                    W0_SUB_NUMERO.ValueChanged += OnValueChanged;
                }

            }
            public EM0006B_WABEND WABEND { get; set; } = new EM0006B_WABEND();
            public class EM0006B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' EM0006B'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM0006B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    10      W0C7R                 PIC  X(002)  VALUE SPACES.*/
                public StringBasis W0C7R { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10      W0C7 REDEFINES W0C7R  PIC  9(003)  COMP-3.*/
                private _REDEF_IntBasis _w0c7 { get; set; }
                public _REDEF_IntBasis W0C7
                {
                    get { _w0c7 = new _REDEF_IntBasis(new PIC("9", "003", "9(003)")); ; _.Move(W0C7R, _w0c7); VarBasis.RedefinePassValue(W0C7R, _w0c7, W0C7R); _w0c7.ValueChanged += () => { _.Move(_w0c7, W0C7R); }; return _w0c7; }
                    set { VarBasis.RedefinePassValue(value, _w0c7, W0C7R); }
                }  //Redefines
                /*"01           WAREA.*/
            }
        }
        public EM0006B_WAREA WAREA { get; set; } = new EM0006B_WAREA();
        public class EM0006B_WAREA : VarBasis
        {
            /*"  03         WDATA1            PIC  9(008) VALUE ZEROS.*/
            public IntBasis WDATA1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER    REDEFINES  WDATA1.*/
            private _REDEF_EM0006B_FILLER_14 _filler_14 { get; set; }
            public _REDEF_EM0006B_FILLER_14 FILLER_14
            {
                get { _filler_14 = new _REDEF_EM0006B_FILLER_14(); _.Move(WDATA1, _filler_14); VarBasis.RedefinePassValue(WDATA1, _filler_14, WDATA1); _filler_14.ValueChanged += () => { _.Move(_filler_14, WDATA1); }; return _filler_14; }
                set { VarBasis.RedefinePassValue(value, _filler_14, WDATA1); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_14 : VarBasis
            {
                /*"    05       WDAT1-DIA         PIC  9(002).*/
                public IntBasis WDAT1_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT1-MES         PIC  9(002).*/
                public IntBasis WDAT1_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT1-ANO         PIC  9(004).*/
                public IntBasis WDAT1_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         WDATA2            PIC  9(008) VALUE ZEROS.*/

                public _REDEF_EM0006B_FILLER_14()
                {
                    WDAT1_DIA.ValueChanged += OnValueChanged;
                    WDAT1_MES.ValueChanged += OnValueChanged;
                    WDAT1_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER    REDEFINES  WDATA2.*/
            private _REDEF_EM0006B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_EM0006B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_EM0006B_FILLER_15(); _.Move(WDATA2, _filler_15); VarBasis.RedefinePassValue(WDATA2, _filler_15, WDATA2); _filler_15.ValueChanged += () => { _.Move(_filler_15, WDATA2); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WDATA2); }
            }  //Redefines
            public class _REDEF_EM0006B_FILLER_15 : VarBasis
            {
                /*"    05       WDAT2-DIA         PIC  9(002).*/
                public IntBasis WDAT2_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT2-MES         PIC  9(002).*/
                public IntBasis WDAT2_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WDAT2-ANO         PIC  9(004).*/
                public IntBasis WDAT2_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03         QTDIA             PIC S9(005)    VALUE +0   COMP-3.*/

                public _REDEF_EM0006B_FILLER_15()
                {
                    WDAT2_DIA.ValueChanged += OnValueChanged;
                    WDAT2_MES.ValueChanged += OnValueChanged;
                    WDAT2_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }


        public EM0006B_V1PROPOSTA V1PROPOSTA { get; set; } = new EM0006B_V1PROPOSTA();
        public EM0006B_V1PROPCORRET V1PROPCORRET { get; set; } = new EM0006B_V1PROPCORRET();
        public EM0006B_V1PROPCOSCED V1PROPCOSCED { get; set; } = new EM0006B_V1PROPCOSCED();
        public EM0006B_V1PROPLOCINC V1PROPLOCINC { get; set; } = new EM0006B_V1PROPLOCINC();
        public EM0006B_V1PROPINC V1PROPINC { get; set; } = new EM0006B_V1PROPINC();
        public EM0006B_V1PROPCLAUSULA V1PROPCLAUSULA { get; set; } = new EM0006B_V1PROPCLAUSULA();
        public EM0006B_V1COSSEGSORT V1COSSEGSORT { get; set; } = new EM0006B_V1COSSEGSORT();
        public EM0006B_V1PROPDESINC V1PROPDESINC { get; set; } = new EM0006B_V1PROPDESINC();
        public EM0006B_V1PROPDESCO V1PROPDESCO { get; set; } = new EM0006B_V1PROPDESCO();
        public EM0006B_V1PROPOUTR V1PROPOUTR { get; set; } = new EM0006B_V1PROPOUTR();
        public EM0006B_V1PROPDCOB V1PROPDCOB { get; set; } = new EM0006B_V1PROPDCOB();
        public EM0006B_V1COBPROPINC V1COBPROPINC { get; set; } = new EM0006B_V1COBPROPINC();
        public EM0006B_V1PRAZOCURTO V1PRAZOCURTO { get; set; } = new EM0006B_V1PRAZOCURTO();
        public EM0006B_V1PRAZOLONGO V1PRAZOLONGO { get; set; } = new EM0006B_V1PRAZOLONGO();
        public EM0006B_V1ACOMPROP V1ACOMPROP { get; set; } = new EM0006B_V1ACOMPROP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -970- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -971- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -974- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -977- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -977- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -985- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -986- PERFORM R0100-00-SELECT-V1SISTEMA */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -987- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -989- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -991- PERFORM R0200-00-DECLARE-V1PROPOSTA */

            R0200_00_DECLARE_V1PROPOSTA_SECTION();

            /*" -992- PERFORM R0210-00-FETCH-V1PROPOSTA */

            R0210_00_FETCH_V1PROPOSTA_SECTION();

            /*" -993- IF WFIM-V1PROPOSTA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPOSTA.IsEmpty())
            {

                /*" -994- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -996- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -999- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-PROGRAMA EQUAL HIGH-VALUES */

            while (!(AREA_DE_WORK.WFIM_PROGRAMA.IsHighValues))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -999- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1003- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1004- DISPLAY 'REGISTROS LIDOS  (LINHAS) ' */
            _.Display($"REGISTROS LIDOS  (LINHAS) ");

            /*" -1005- DISPLAY 'PROPOSTAS LIDAS          ' AC-L-V1PROPOSTA */
            _.Display($"PROPOSTAS LIDAS          {AREA_DE_WORK.AC_L_V1PROPOSTA}");

            /*" -1006- DISPLAY 'PROPOSTAS CORRETOR       ' AC-L-V1PROPCORRET */
            _.Display($"PROPOSTAS CORRETOR       {AREA_DE_WORK.AC_L_V1PROPCORRET}");

            /*" -1007- DISPLAY 'PROPOSTAS COSSEG CEDIDO  ' AC-L-V1PROPCOSCED */
            _.Display($"PROPOSTAS COSSEG CEDIDO  {AREA_DE_WORK.AC_L_V1PROPCOSCED}");

            /*" -1008- DISPLAY 'PROPOSTAS LOCAL INCENDIO ' AC-L-V1PROPLOCINC */
            _.Display($"PROPOSTAS LOCAL INCENDIO {AREA_DE_WORK.AC_L_V1PROPLOCINC}");

            /*" -1009- DISPLAY 'PROPOSTAS ITENS INCENDIO ' AC-L-V1PROPINC */
            _.Display($"PROPOSTAS ITENS INCENDIO {AREA_DE_WORK.AC_L_V1PROPINC}");

            /*" -1010- DISPLAY 'PROPOSTAS COBERTURA INC. ' AC-L-V1COBPROPINC */
            _.Display($"PROPOSTAS COBERTURA INC. {AREA_DE_WORK.AC_L_V1COBPROPINC}");

            /*" -1011- DISPLAY 'PROPOSTAS DESCRICAO INC. ' AC-L-V1PROPDESINC */
            _.Display($"PROPOSTAS DESCRICAO INC. {AREA_DE_WORK.AC_L_V1PROPDESINC}");

            /*" -1012- DISPLAY 'PROPOSTAS CLAUSULAS      ' AC-L-V1PROPCLAUS */
            _.Display($"PROPOSTAS CLAUSULAS      {AREA_DE_WORK.AC_L_V1PROPCLAUS}");

            /*" -1013- DISPLAY 'PROPOSTAS DESCONTOS INC. ' AC-L-V1PROPDESCO */
            _.Display($"PROPOSTAS DESCONTOS INC. {AREA_DE_WORK.AC_L_V1PROPDESCO}");

            /*" -1014- DISPLAY 'PROPOSTAS OUTROS    INC. ' AC-L-V1PROPOUTR */
            _.Display($"PROPOSTAS OUTROS    INC. {AREA_DE_WORK.AC_L_V1PROPOUTR}");

            /*" -1015- DISPLAY 'PROPOSTAS DESCRICAO COB. ' AC-L-V1PROPDCOB */
            _.Display($"PROPOSTAS DESCRICAO COB. {AREA_DE_WORK.AC_L_V1PROPDCOB}");

            /*" -1016- DISPLAY 'REGISTROS  INSERIDOS  (LINHAS) ' */
            _.Display($"REGISTROS  INSERIDOS  (LINHAS) ");

            /*" -1017- DISPLAY ' . APOLICES              ' AC-I-V0APOLICE */
            _.Display($" . APOLICES              {AREA_DE_WORK.AC_I_V0APOLICE}");

            /*" -1018- DISPLAY ' . ENDOSSOS              ' AC-I-V0ENDOSSO */
            _.Display($" . ENDOSSOS              {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -1019- DISPLAY ' . APOLICE CORRETOR      ' AC-I-V0APOLCORRET */
            _.Display($" . APOLICE CORRETOR      {AREA_DE_WORK.AC_I_V0APOLCORRET}");

            /*" -1020- DISPLAY ' . APOLICE COSSEG CEDIDO ' AC-I-V0APOLCOSCED */
            _.Display($" . APOLICE COSSEG CEDIDO {AREA_DE_WORK.AC_I_V0APOLCOSCED}");

            /*" -1021- DISPLAY ' . LOCAIS INCENDIO       ' AC-I-V0APOLOCINC */
            _.Display($" . LOCAIS INCENDIO       {AREA_DE_WORK.AC_I_V0APOLOCINC}");

            /*" -1022- DISPLAY ' . ITENS INCENDIO        ' AC-I-V0APOITENSINC */
            _.Display($" . ITENS INCENDIO        {AREA_DE_WORK.AC_I_V0APOITENSINC}");

            /*" -1023- DISPLAY ' . COBERTURA APOLICE     ' AC-I-V0COBERAPOL */
            _.Display($" . COBERTURA APOLICE     {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -1024- DISPLAY ' . COBERTURA APOLICE INC.' AC-I-V0COBERINC */
            _.Display($" . COBERTURA APOLICE INC.{AREA_DE_WORK.AC_I_V0COBERINC}");

            /*" -1025- DISPLAY ' . DESCRICAO ITEM INC.   ' AC-I-V0APODESITEM */
            _.Display($" . DESCRICAO ITEM INC.   {AREA_DE_WORK.AC_I_V0APODESITEM}");

            /*" -1026- DISPLAY ' . ACOMP. PROPOSTA       ' AC-I-V0ACOMPROP */
            _.Display($" . ACOMP. PROPOSTA       {AREA_DE_WORK.AC_I_V0ACOMPROP}");

            /*" -1027- DISPLAY ' . CLAUSULAS DA APOLICE  ' AC-I-V0APOLCLAUS */
            _.Display($" . CLAUSULAS DA APOLICE  {AREA_DE_WORK.AC_I_V0APOLCLAUS}");

            /*" -1028- DISPLAY ' . APOLICE DESCONTOS INC.' AC-I-V0APOLDESCO */
            _.Display($" . APOLICE DESCONTOS INC.{AREA_DE_WORK.AC_I_V0APOLDESCO}");

            /*" -1029- DISPLAY ' . APOLICE OUTROS    INC.' AC-I-V0APOLOUTR */
            _.Display($" . APOLICE OUTROS    INC.{AREA_DE_WORK.AC_I_V0APOLOUTR}");

            /*" -1030- DISPLAY ' . APOLICE DESCRICAO COB.' AC-I-V0APOLDCOB */
            _.Display($" . APOLICE DESCRICAO COB.{AREA_DE_WORK.AC_I_V0APOLDCOB}");

            /*" -1031- DISPLAY ' . MALHA DE PRODUCAO     ' AC-I-V0MALHAPROD */
            _.Display($" . MALHA DE PRODUCAO     {AREA_DE_WORK.AC_I_V0MALHAPROD}");

            /*" -1031- DISPLAY ' . EMISSAO DIARIA        ' AC-I-V0EMISDIARIA. */
            _.Display($" . EMISSAO DIARIA        {AREA_DE_WORK.AC_I_V0EMISDIARIA}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1037- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -1037- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -1051- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1056- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -1059- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1060- DISPLAY 'EM0006B - SISTEMA DE EMISSAO NAO CADASTRADO' */
                _.Display($"EM0006B - SISTEMA DE EMISSAO NAO CADASTRADO");

                /*" -1061- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -1063- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1064- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1066- DISPLAY 'R0100-00 - ERRO ACESSO V1SISTEMA , SQLCODE=' SQLCODE */
                _.Display($"R0100-00 - ERRO ACESSO V1SISTEMA , SQLCODE={DB.SQLCODE}");

                /*" -1066- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -1056- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

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
        /*" R0200-00-DECLARE-V1PROPOSTA-SECTION */
        private void R0200_00_DECLARE_V1PROPOSTA_SECTION()
        {
            /*" -1080- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1154- PERFORM R0200_00_DECLARE_V1PROPOSTA_DB_DECLARE_1 */

            R0200_00_DECLARE_V1PROPOSTA_DB_DECLARE_1();

            /*" -1156- PERFORM R0200_00_DECLARE_V1PROPOSTA_DB_OPEN_1 */

            R0200_00_DECLARE_V1PROPOSTA_DB_OPEN_1();

            /*" -1159- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1161- DISPLAY 'R0200-00 ERRO DECLARE DA V1PROPOSTA, SQLCODE=' SQLCODE */
                _.Display($"R0200-00 ERRO DECLARE DA V1PROPOSTA, SQLCODE={DB.SQLCODE}");

                /*" -1161- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1PROPOSTA-DB-DECLARE-1 */
        public void R0200_00_DECLARE_V1PROPOSTA_DB_DECLARE_1()
        {
            /*" -1154- EXEC SQL DECLARE V1PROPOSTA CURSOR FOR SELECT TPPROPOS , FONTE , NRPROPOS , RAMO , MODALIDA , NUM_APOL_ANTERIOR , TIPAPO , CODCLIEN , DTINIVIG , DTTERVIG , PODPUBL , CORRECAO , COD_MOEDA_IMP , COD_MOEDA_PRM , PRESTA1 , BCORCAP , AGERCAP , NRRCAP , VLRCAP , CDFRACIO , QTPARCEL , PCENTRAD , PCADICIO , IDIOF , ISENTA_CUSTO , QTPRESTA , BCOCOBR , AGECOBR , TPCORRET , NRAUTCOR , QTCORR , QTCORRC , NUM_APOL_MANUAL , TPCOSCED , QTCOSSGC , QTCOSSEG , QTITENSI , QTITENS , TPMOVTO , DTENTRAD , DTCADAST , TIPCALC , LIMIND , CDACEITA , NRAUTACE , PCDESCON , IDRCAP , CODTXT , NUM_RENOVACAO , CONVENIO_COBRANCA , OCORR_ENDERECO , SITUACAO , COD_USUARIO , NUM_ATA , ANO_ATA , DATA_SORTEIO , DTLIBER , DTAPOLM , DATARCAP , COD_EMPRESA , TIMESTAMP , TIPO_ENDOSSO , NUM_APOLICE , INSPETOR , CANALPROD , CODPRODU , DTVENCTO , CFPREFIX , VLCUSEMI FROM SEGUROS.V1PROPOSTA WHERE SITUACAO = '+' AND RAMO = 11 ORDER BY FONTE, NRPROPOS END-EXEC. */
            V1PROPOSTA = new EM0006B_V1PROPOSTA(false);
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
							TIMESTAMP
							, 
							TIPO_ENDOSSO
							, 
							NUM_APOLICE
							, 
							INSPETOR
							, 
							CANALPROD
							, 
							CODPRODU
							, 
							DTVENCTO
							, 
							CFPREFIX
							, 
							VLCUSEMI 
							FROM SEGUROS.V1PROPOSTA 
							WHERE SITUACAO = '+' 
							AND RAMO = 11 
							ORDER BY FONTE
							, NRPROPOS";

                return query;
            }
            V1PROPOSTA.GetQueryEvent += GetQuery_V1PROPOSTA;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-V1PROPOSTA-DB-OPEN-1 */
        public void R0200_00_DECLARE_V1PROPOSTA_DB_OPEN_1()
        {
            /*" -1156- EXEC SQL OPEN V1PROPOSTA END-EXEC. */

            V1PROPOSTA.Open();

        }

        [StopWatch]
        /*" R1600-00-DECLARE-V1PROPCORRET-DB-DECLARE-1 */
        public void R1600_00_DECLARE_V1PROPCORRET_DB_DECLARE_1()
        {
            /*" -1462- EXEC SQL DECLARE V1PROPCORRET CURSOR FOR SELECT FONTE , NRPROPOS , RAMOFR , MODALIFR , CODCORR , PCPARCOR , PCCOMCOR , INDCRT , COD_USUARIO FROM SEGUROS.V1PROPCORRET WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */
            V1PROPCORRET = new EM0006B_V1PROPCORRET(true);
            string GetQuery_V1PROPCORRET()
            {
                var query = @$"SELECT 
							FONTE
							, 
							NRPROPOS
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							CODCORR
							, 
							PCPARCOR
							, 
							PCCOMCOR
							, 
							INDCRT
							, 
							COD_USUARIO 
							FROM 
							SEGUROS.V1PROPCORRET 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}'";

                return query;
            }
            V1PROPCORRET.GetQueryEvent += GetQuery_V1PROPCORRET;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-FETCH-V1PROPOSTA-SECTION */
        private void R0210_00_FETCH_V1PROPOSTA_SECTION()
        {
            /*" -1175- MOVE '021' TO WNR-EXEC-SQL. */
            _.Move("021", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1176- IF WFIM-V1PROPOSTA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPOSTA.IsEmpty())
            {

                /*" -1178- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1248- PERFORM R0210_00_FETCH_V1PROPOSTA_DB_FETCH_1 */

            R0210_00_FETCH_V1PROPOSTA_DB_FETCH_1();

            /*" -1251- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1252- MOVE 'S' TO WFIM-V1PROPOSTA */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPOSTA);

                /*" -1253- MOVE HIGH-VALUES TO WFIM-PROGRAMA */

                AREA_DE_WORK.WFIM_PROGRAMA.IsHighValues = true;

                /*" -1253- PERFORM R0210_00_FETCH_V1PROPOSTA_DB_CLOSE_1 */

                R0210_00_FETCH_V1PROPOSTA_DB_CLOSE_1();

                /*" -1256- GO TO R0210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1257- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1259- DISPLAY 'R0210-00 - ERRO ACESSO V1PROPOSTA, SQLCODE=' SQLCODE */
                _.Display($"R0210-00 - ERRO ACESSO V1PROPOSTA, SQLCODE={DB.SQLCODE}");

                /*" -1261- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1262- IF VIND-NUM-ATA LESS 0 */

            if (VIND_NUM_ATA < 0)
            {

                /*" -1264- MOVE -1 TO VIND-NUM-ATA. */
                _.Move(-1, VIND_NUM_ATA);
            }


            /*" -1265- IF VIND-ANO-ATA LESS 0 */

            if (VIND_ANO_ATA < 0)
            {

                /*" -1267- MOVE -1 TO VIND-ANO-ATA. */
                _.Move(-1, VIND_ANO_ATA);
            }


            /*" -1268- IF VIND-COD-EMP LESS 0 */

            if (VIND_COD_EMP < 0)
            {

                /*" -1270- MOVE -1 TO VIND-COD-EMP. */
                _.Move(-1, VIND_COD_EMP);
            }


            /*" -1271- IF VIND-DAT-SORT LESS 0 */

            if (VIND_DAT_SORT < 0)
            {

                /*" -1273- MOVE -1 TO VIND-DAT-SORT. */
                _.Move(-1, VIND_DAT_SORT);
            }


            /*" -1274- IF VIND-DTLIBER LESS 0 */

            if (VIND_DTLIBER < 0)
            {

                /*" -1276- MOVE -1 TO VIND-DTLIBER. */
                _.Move(-1, VIND_DTLIBER);
            }


            /*" -1277- IF VIND-DTAPOLM LESS 0 */

            if (VIND_DTAPOLM < 0)
            {

                /*" -1279- MOVE -1 TO VIND-DTAPOLM. */
                _.Move(-1, VIND_DTAPOLM);
            }


            /*" -1280- IF VIND-DAT-RCAP LESS 0 */

            if (VIND_DAT_RCAP < 0)
            {

                /*" -1282- MOVE -1 TO VIND-DAT-RCAP. */
                _.Move(-1, VIND_DAT_RCAP);
            }


            /*" -1283- IF VIND-DTVENCTO LESS 0 */

            if (VIND_DTVENCTO < 0)
            {

                /*" -1285- MOVE -1 TO VIND-DTVENCTO. */
                _.Move(-1, VIND_DTVENCTO);
            }


            /*" -1286- IF VIND-CFPREFIX LESS 0 */

            if (VIND_CFPREFIX < 0)
            {

                /*" -1287- MOVE -1 TO VIND-CFPREFIX */
                _.Move(-1, VIND_CFPREFIX);

                /*" -1289- MOVE ZEROS TO V1PROP-CFPREFIX. */
                _.Move(0, V1PROP_CFPREFIX);
            }


            /*" -1290- IF VIND-VLCUSEMI LESS 0 */

            if (VIND_VLCUSEMI < 0)
            {

                /*" -1291- MOVE -1 TO VIND-VLCUSEMI */
                _.Move(-1, VIND_VLCUSEMI);

                /*" -1293- MOVE ZEROS TO V1PROP-VLCUSEMI. */
                _.Move(0, V1PROP_VLCUSEMI);
            }


            /*" -1294- IF VIND-INSPETOR LESS 0 */

            if (VIND_INSPETOR < 0)
            {

                /*" -1296- MOVE -1 TO VIND-INSPETOR. */
                _.Move(-1, VIND_INSPETOR);
            }


            /*" -1297- IF VIND-CANALPROD LESS 0 */

            if (VIND_CANALPROD < 0)
            {

                /*" -1299- MOVE -1 TO VIND-CANALPROD. */
                _.Move(-1, VIND_CANALPROD);
            }


            /*" -1300- IF VIND-TIPO-ENDOSSO LESS 0 */

            if (VIND_TIPO_ENDOSSO < 0)
            {

                /*" -1302- MOVE -1 TO VIND-TIPO-ENDOSSO. */
                _.Move(-1, VIND_TIPO_ENDOSSO);
            }


            /*" -1303- IF VIND-NUM-APOLICE LESS 0 */

            if (VIND_NUM_APOLICE < 0)
            {

                /*" -1305- MOVE -1 TO VIND-NUM-APOLICE. */
                _.Move(-1, VIND_NUM_APOLICE);
            }


            /*" -1306- IF VIND-CODPRODU LESS 0 */

            if (VIND_CODPRODU < 0)
            {

                /*" -1308- MOVE -1 TO VIND-CODPRODU. */
                _.Move(-1, VIND_CODPRODU);
            }


            /*" -1309- IF V1PROP-TIPO-ENDO EQUAL SPACES */

            if (V1PROP_TIPO_ENDO.IsEmpty())
            {

                /*" -1311- MOVE '0' TO V1PROP-TIPO-ENDO. */
                _.Move("0", V1PROP_TIPO_ENDO);
            }


            /*" -1311- ADD +1 TO AC-L-V1PROPOSTA. */
            AREA_DE_WORK.AC_L_V1PROPOSTA.Value = AREA_DE_WORK.AC_L_V1PROPOSTA + +1;

        }

        [StopWatch]
        /*" R0210-00-FETCH-V1PROPOSTA-DB-FETCH-1 */
        public void R0210_00_FETCH_V1PROPOSTA_DB_FETCH_1()
        {
            /*" -1248- EXEC SQL FETCH V1PROPOSTA INTO :V1PROP-TPPROPOS , :V1PROP-FONTE , :V1PROP-NRPROPOS , :V1PROP-RAMO , :V1PROP-MODALIDA , :V1PROP-NUM-APO-ANT , :V1PROP-TIPAPO , :V1PROP-CODCLIEN , :V1PROP-DTINIVIG , :V1PROP-DTTERVIG , :V1PROP-PODPUBL , :V1PROP-CORRECAO , :V1PROP-MOEDA-IMP , :V1PROP-MOEDA-PRM , :V1PROP-PRESTA1 , :V1PROP-BCORCAP , :V1PROP-AGERCAP , :V1PROP-NRRCAP , :V1PROP-VLRCAP , :V1PROP-CDFRACIO , :V1PROP-QTPARCEL , :V1PROP-PCENTRAD , :V1PROP-PCADICIO , :V1PROP-IDIOF , :V1PROP-ISENTA-CST , :V1PROP-QTPRESTA , :V1PROP-BCOCOBR , :V1PROP-AGECOBR , :V1PROP-TPCORRET , :V1PROP-NRAUTCOR , :V1PROP-QTCORR , :V1PROP-QTCORRC , :V1PROP-NUM-APO-MAN , :V1PROP-TPCOSCED , :V1PROP-QTCOSSGC , :V1PROP-QTCOSSEG , :V1PROP-QTITENSI , :V1PROP-QTITENS , :V1PROP-TPMOVTO , :V1PROP-DTENTRAD , :V1PROP-DTCADAST , :V1PROP-TIPCALC , :V1PROP-LIMIND , :V1PROP-CDACEITA , :V1PROP-NRAUTACE , :V1PROP-PCDESCON , :V1PROP-IDRCAP , :V1PROP-CODTXT , :V1PROP-NUM-RENOV , :V1PROP-CONV-COBR , :V1PROP-OCORR-END , :V1PROP-SITUACAO , :V1PROP-COD-USUAR , :V1PROP-NUM-ATA:VIND-NUM-ATA , :V1PROP-ANO-ATA:VIND-ANO-ATA , :V1PROP-DATA-SORT:VIND-DAT-SORT , :V1PROP-DTLIBER:VIND-DTLIBER , :V1PROP-DTAPOLM:VIND-DTAPOLM , :V1PROP-DATARCAP:VIND-DAT-RCAP , :V1PROP-COD-EMPRESA:VIND-COD-EMP , :V1PROP-TIMESTAMP:VIND-TIMESTAMP, :V1PROP-TIPO-ENDO:VIND-TIPO-ENDOSSO, :V1PROP-NUM-APOLICE:VIND-NUM-APOLICE, :V1PROP-INSPETOR:VIND-INSPETOR , :V1PROP-CANALPROD:VIND-CANALPROD , :V1PROP-CODPRODU:VIND-CODPRODU , :V1PROP-DTVENCTO:VIND-DTVENCTO , :V1PROP-CFPREFIX:VIND-CFPREFIX , :V1PROP-VLCUSEMI:VIND-VLCUSEMI END-EXEC. */

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
                _.Move(V1PROPOSTA.V1PROP_TIMESTAMP, V1PROP_TIMESTAMP);
                _.Move(V1PROPOSTA.VIND_TIMESTAMP, VIND_TIMESTAMP);
                _.Move(V1PROPOSTA.V1PROP_TIPO_ENDO, V1PROP_TIPO_ENDO);
                _.Move(V1PROPOSTA.VIND_TIPO_ENDOSSO, VIND_TIPO_ENDOSSO);
                _.Move(V1PROPOSTA.V1PROP_NUM_APOLICE, V1PROP_NUM_APOLICE);
                _.Move(V1PROPOSTA.VIND_NUM_APOLICE, VIND_NUM_APOLICE);
                _.Move(V1PROPOSTA.V1PROP_INSPETOR, V1PROP_INSPETOR);
                _.Move(V1PROPOSTA.VIND_INSPETOR, VIND_INSPETOR);
                _.Move(V1PROPOSTA.V1PROP_CANALPROD, V1PROP_CANALPROD);
                _.Move(V1PROPOSTA.VIND_CANALPROD, VIND_CANALPROD);
                _.Move(V1PROPOSTA.V1PROP_CODPRODU, V1PROP_CODPRODU);
                _.Move(V1PROPOSTA.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(V1PROPOSTA.V1PROP_DTVENCTO, V1PROP_DTVENCTO);
                _.Move(V1PROPOSTA.VIND_DTVENCTO, VIND_DTVENCTO);
                _.Move(V1PROPOSTA.V1PROP_CFPREFIX, V1PROP_CFPREFIX);
                _.Move(V1PROPOSTA.VIND_CFPREFIX, VIND_CFPREFIX);
                _.Move(V1PROPOSTA.V1PROP_VLCUSEMI, V1PROP_VLCUSEMI);
                _.Move(V1PROPOSTA.VIND_VLCUSEMI, VIND_VLCUSEMI);
            }

        }

        [StopWatch]
        /*" R0210-00-FETCH-V1PROPOSTA-DB-CLOSE-1 */
        public void R0210_00_FETCH_V1PROPOSTA_DB_CLOSE_1()
        {
            /*" -1253- EXEC SQL CLOSE V1PROPOSTA END-EXEC */

            V1PROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1324- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1326- PERFORM R1100-00-SELECT-V1FONTE */

            R1100_00_SELECT_V1FONTE_SECTION();

            /*" -1328- PERFORM R1200-00-SELECT-V1RAMOIND */

            R1200_00_SELECT_V1RAMOIND_SECTION();

            /*" -1329- IF V1PROP-PODPUBL NOT EQUAL 'N' */

            if (V1PROP_PODPUBL != "N")
            {

                /*" -1331- PERFORM R2500-00-DECLARE-V1COSSEGSORT. */

                R2500_00_DECLARE_V1COSSEGSORT_SECTION();
            }


            /*" -1332- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -1334- PERFORM R3100-00-INSERT-V0APOLICE. */

                R3100_00_INSERT_V0APOLICE_SECTION();
            }


            /*" -1336- PERFORM R3200-00-INSERT-V0ENDOSSO */

            R3200_00_INSERT_V0ENDOSSO_SECTION();

            /*" -1337- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -1338- MOVE SPACES TO WFIM-V1PROPCORRET */
                _.Move("", AREA_DE_WORK.WFIM_V1PROPCORRET);

                /*" -1339- MOVE 999999999 TO CH-CORR-ANT */
                _.Move(999999999, AREA_DE_WORK.CH_CORR_ANT);

                /*" -1341- MOVE ZEROS TO W1PCOR-CODCORR */
                _.Move(0, W1PCOR_CODCORR);

                /*" -1342- PERFORM R1600-00-DECLARE-V1PROPCORRET */

                R1600_00_DECLARE_V1PROPCORRET_SECTION();

                /*" -1345- PERFORM R1700-00-INSERT-V0APOLCORRET UNTIL WFIM-V1PROPCORRET NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1PROPCORRET.IsEmpty()))
                {

                    R1700_00_INSERT_V0APOLCORRET_SECTION();
                }

                /*" -1346- MOVE SPACES TO WFIM-V1PROPCOSCED */
                _.Move("", AREA_DE_WORK.WFIM_V1PROPCOSCED);

                /*" -1349- MOVE ZEROS TO W0APOL-PCTCED W0APOL-QTCOSSEG */
                _.Move(0, W0APOL_PCTCED, W0APOL_QTCOSSEG);

                /*" -1350- PERFORM R1800-00-DECLARE-V1PROPCOSCED */

                R1800_00_DECLARE_V1PROPCOSCED_SECTION();

                /*" -1353- PERFORM R1900-00-INSERT-V0APOLCOSCED UNTIL WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty()))
                {

                    R1900_00_INSERT_V0APOLCOSCED_SECTION();
                }

                /*" -1355- PERFORM R4300-00-UPDATE-V0APOLICE. */

                R4300_00_UPDATE_V0APOLICE_SECTION();
            }


            /*" -1356- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -1358- PERFORM R2000-00-PROCESSA-ITENS */

                R2000_00_PROCESSA_ITENS_SECTION();

                /*" -1359- ELSE */
            }
            else
            {


                /*" -1361- PERFORM R2300-00-PROCESSA-ENDOSSO. */

                R2300_00_PROCESSA_ENDOSSO_SECTION();
            }


            /*" -1363- PERFORM R4000-00-TRATA-COBERTURA-APOL */

            R4000_00_TRATA_COBERTURA_APOL_SECTION();

            /*" -1365- PERFORM R5100-00-INSERT-V0ACOMPROP */

            R5100_00_INSERT_V0ACOMPROP_SECTION();

            /*" -1367- PERFORM R5500-00-UPDATE-V0PROPOSTA */

            R5500_00_UPDATE_V0PROPOSTA_SECTION();

            /*" -1369- PERFORM R4700-00-UPDATE-NUMERO-AES */

            R4700_00_UPDATE_NUMERO_AES_SECTION();

            /*" -1371- PERFORM R4900-00-UPDATE-V0CONTPROP */

            R4900_00_UPDATE_V0CONTPROP_SECTION();

            /*" -1373- PERFORM R5000-00-INSERT-V0EMISDIARIA */

            R5000_00_INSERT_V0EMISDIARIA_SECTION();

            /*" -1375- PERFORM R5300-00-INSERT-V0EMISDIARIA */

            R5300_00_INSERT_V0EMISDIARIA_SECTION();

            /*" -1375- PERFORM R5200-00-INSERT-V0MALHAPROD. */

            R5200_00_INSERT_V0MALHAPROD_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1381- PERFORM R0210-00-FETCH-V1PROPOSTA. */

            R0210_00_FETCH_V1PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V1FONTE-SECTION */
        private void R1100_00_SELECT_V1FONTE_SECTION()
        {
            /*" -1394- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1399- PERFORM R1100_00_SELECT_V1FONTE_DB_SELECT_1 */

            R1100_00_SELECT_V1FONTE_DB_SELECT_1();

            /*" -1402- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1406- DISPLAY 'R1100-00 (NAO EXISTE NA V1FONTE) ... ' ' ' V1PROP-NRPROPOS ' ' V1PROP-FONTE ' ' V1PROP-RAMO */

                $"R1100-00 (NAO EXISTE NA V1FONTE) ...  {V1PROP_NRPROPOS} {V1PROP_FONTE} {V1PROP_RAMO}"
                .Display();

                /*" -1406- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V1FONTE-DB-SELECT-1 */
        public void R1100_00_SELECT_V1FONTE_DB_SELECT_1()
        {
            /*" -1399- EXEC SQL SELECT ORGAOEMIS INTO :V1FONT-ORGAOEMIS FROM SEGUROS.V1FONTE WHERE FONTE = :V1PROP-FONTE END-EXEC. */

            var r1100_00_SELECT_V1FONTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_V1FONTE_DB_SELECT_1_Query1()
            {
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V1FONTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V1FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_ORGAOEMIS, V1FONT_ORGAOEMIS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1RAMOIND-SECTION */
        private void R1200_00_SELECT_V1RAMOIND_SECTION()
        {
            /*" -1419- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1426- PERFORM R1200_00_SELECT_V1RAMOIND_DB_SELECT_1 */

            R1200_00_SELECT_V1RAMOIND_DB_SELECT_1();

            /*" -1429- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1433- DISPLAY 'R1200-00 (NAO EXISTE NA V1RAMOIND) ... ' ' ' V1PROP-NRPROPOS ' ' V1PROP-FONTE ' ' V1PROP-RAMO */

                $"R1200-00 (NAO EXISTE NA V1RAMOIND) ...  {V1PROP_NRPROPOS} {V1PROP_FONTE} {V1PROP_RAMO}"
                .Display();

                /*" -1433- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V1RAMOIND-DB-SELECT-1 */
        public void R1200_00_SELECT_V1RAMOIND_DB_SELECT_1()
        {
            /*" -1426- EXEC SQL SELECT PCIOF INTO :V1RAMO-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1PROP-RAMO AND DTINIVIG <= :V1PROP-DTINIVIG AND DTTERVIG >= :V1PROP-DTINIVIG END-EXEC. */

            var r1200_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1()
            {
                V1PROP_DTINIVIG = V1PROP_DTINIVIG.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_PCIOF, V1RAMO_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-DECLARE-V1PROPCORRET-SECTION */
        private void R1600_00_DECLARE_V1PROPCORRET_SECTION()
        {
            /*" -1446- MOVE '160' TO WNR-EXEC-SQL. */
            _.Move("160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1462- PERFORM R1600_00_DECLARE_V1PROPCORRET_DB_DECLARE_1 */

            R1600_00_DECLARE_V1PROPCORRET_DB_DECLARE_1();

            /*" -1464- PERFORM R1600_00_DECLARE_V1PROPCORRET_DB_OPEN_1 */

            R1600_00_DECLARE_V1PROPCORRET_DB_OPEN_1();

        }

        [StopWatch]
        /*" R1600-00-DECLARE-V1PROPCORRET-DB-OPEN-1 */
        public void R1600_00_DECLARE_V1PROPCORRET_DB_OPEN_1()
        {
            /*" -1464- EXEC SQL OPEN V1PROPCORRET END-EXEC. */

            V1PROPCORRET.Open();

        }

        [StopWatch]
        /*" R1800-00-DECLARE-V1PROPCOSCED-DB-DECLARE-1 */
        public void R1800_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1()
        {
            /*" -1587- EXEC SQL DECLARE V1PROPCOSCED CURSOR FOR SELECT FONTE , NRPROPOS , CODCOSS , RAMOFR , PCPARTIC , PCCOMCOS FROM SEGUROS.V1PROPCOSCED WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY CODCOSS END-EXEC. */
            V1PROPCOSCED = new EM0006B_V1PROPCOSCED(true);
            string GetQuery_V1PROPCOSCED()
            {
                var query = @$"SELECT 
							FONTE
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
							FROM 
							SEGUROS.V1PROPCOSCED 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY 
							CODCOSS";

                return query;
            }
            V1PROPCOSCED.GetQueryEvent += GetQuery_V1PROPCOSCED;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-FETCH-V1PROPCORRET-SECTION */
        private void R1610_00_FETCH_V1PROPCORRET_SECTION()
        {
            /*" -1477- MOVE '161' TO WNR-EXEC-SQL. */
            _.Move("161", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1488- PERFORM R1610_00_FETCH_V1PROPCORRET_DB_FETCH_1 */

            R1610_00_FETCH_V1PROPCORRET_DB_FETCH_1();

            /*" -1491- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1492- MOVE 'S' TO WFIM-V1PROPCORRET */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPCORRET);

                /*" -1492- PERFORM R1610_00_FETCH_V1PROPCORRET_DB_CLOSE_1 */

                R1610_00_FETCH_V1PROPCORRET_DB_CLOSE_1();

                /*" -1495- GO TO R1610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1495- ADD +1 TO AC-L-V1PROPCORRET. */
            AREA_DE_WORK.AC_L_V1PROPCORRET.Value = AREA_DE_WORK.AC_L_V1PROPCORRET + +1;

        }

        [StopWatch]
        /*" R1610-00-FETCH-V1PROPCORRET-DB-FETCH-1 */
        public void R1610_00_FETCH_V1PROPCORRET_DB_FETCH_1()
        {
            /*" -1488- EXEC SQL FETCH V1PROPCORRET INTO :V1PCOR-FONTE , :V1PCOR-NRPROPOS , :V1PCOR-RAMOFR , :V1PCOR-MODALIFR , :V1PCOR-CODCORR , :V1PCOR-PCPARCOR , :V1PCOR-PCCOMCOR , :V1PCOR-INDCRT , :V1PCOR-COD-USUARIO END-EXEC. */

            if (V1PROPCORRET.Fetch())
            {
                _.Move(V1PROPCORRET.V1PCOR_FONTE, V1PCOR_FONTE);
                _.Move(V1PROPCORRET.V1PCOR_NRPROPOS, V1PCOR_NRPROPOS);
                _.Move(V1PROPCORRET.V1PCOR_RAMOFR, V1PCOR_RAMOFR);
                _.Move(V1PROPCORRET.V1PCOR_MODALIFR, V1PCOR_MODALIFR);
                _.Move(V1PROPCORRET.V1PCOR_CODCORR, V1PCOR_CODCORR);
                _.Move(V1PROPCORRET.V1PCOR_PCPARCOR, V1PCOR_PCPARCOR);
                _.Move(V1PROPCORRET.V1PCOR_PCCOMCOR, V1PCOR_PCCOMCOR);
                _.Move(V1PROPCORRET.V1PCOR_INDCRT, V1PCOR_INDCRT);
                _.Move(V1PROPCORRET.V1PCOR_COD_USUARIO, V1PCOR_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R1610-00-FETCH-V1PROPCORRET-DB-CLOSE-1 */
        public void R1610_00_FETCH_V1PROPCORRET_DB_CLOSE_1()
        {
            /*" -1492- EXEC SQL CLOSE V1PROPCORRET END-EXEC */

            V1PROPCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-INSERT-V0APOLCORRET-SECTION */
        private void R1700_00_INSERT_V0APOLCORRET_SECTION()
        {
            /*" -1508- MOVE '170' TO WNR-EXEC-SQL. */
            _.Move("170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1509- PERFORM R1610-00-FETCH-V1PROPCORRET */

            R1610_00_FETCH_V1PROPCORRET_SECTION();

            /*" -1510- IF WFIM-V1PROPCORRET NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPCORRET.IsEmpty())
            {

                /*" -1512- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1513- MOVE V0ENDO-NUM-APOL TO V0ACOR-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0ACOR_NUM_APOL);

            /*" -1514- MOVE V1PCOR-RAMOFR TO V0ACOR-RAMOFR */
            _.Move(V1PCOR_RAMOFR, V0ACOR_RAMOFR);

            /*" -1515- MOVE V1PCOR-MODALIFR TO V0ACOR-MODALIFR */
            _.Move(V1PCOR_MODALIFR, V0ACOR_MODALIFR);

            /*" -1516- MOVE V1PCOR-CODCORR TO V0ACOR-CODCORR */
            _.Move(V1PCOR_CODCORR, V0ACOR_CODCORR);

            /*" -1517- MOVE ZEROS TO V0ACOR-CODSUBES */
            _.Move(0, V0ACOR_CODSUBES);

            /*" -1518- MOVE V1PROP-DTINIVIG TO V0ACOR-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0ACOR_DTINIVIG);

            /*" -1519- MOVE V1PROP-DTTERVIG TO V0ACOR-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0ACOR_DTTERVIG);

            /*" -1520- MOVE V1PCOR-PCPARCOR TO V0ACOR-PCPARCOR */
            _.Move(V1PCOR_PCPARCOR, V0ACOR_PCPARCOR);

            /*" -1521- MOVE V1PCOR-PCCOMCOR TO V0ACOR-PCCOMCOR */
            _.Move(V1PCOR_PCCOMCOR, V0ACOR_PCCOMCOR);

            /*" -1522- MOVE '1' TO V0ACOR-TIPCOM */
            _.Move("1", V0ACOR_TIPCOM);

            /*" -1523- MOVE V1PCOR-INDCRT TO V0ACOR-INDCRT */
            _.Move(V1PCOR_INDCRT, V0ACOR_INDCRT);

            /*" -1525- MOVE 11 TO V0ACOR-COD-EMPRESA */
            _.Move(11, V0ACOR_COD_EMPRESA);

            /*" -1527- MOVE V1PCOR-COD-USUARIO TO V0ACOR-COD-USUARIO */
            _.Move(V1PCOR_COD_USUARIO, V0ACOR_COD_USUARIO);

            /*" -1545- PERFORM R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1 */

            R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1();

            /*" -1548- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1551- DISPLAY 'R1700-00 - REGISTRO DUPLICADO (V0APOLCORRET)' ' ' V0ACOR-NUM-APOL ' ' V0ACOR-CODCORR */

                $"R1700-00 - REGISTRO DUPLICADO (V0APOLCORRET) {V0ACOR_NUM_APOL} {V0ACOR_CODCORR}"
                .Display();

                /*" -1553- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1554- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1557- DISPLAY 'R1700-00 - PROBLEMAS NO INSERT (V0APOLCORRET)' ' ' V0ACOR-NUM-APOL ' ' V0ACOR-CODCORR */

                $"R1700-00 - PROBLEMAS NO INSERT (V0APOLCORRET) {V0ACOR_NUM_APOL} {V0ACOR_CODCORR}"
                .Display();

                /*" -1559- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1559- ADD +1 TO AC-I-V0APOLCORRET. */
            AREA_DE_WORK.AC_I_V0APOLCORRET.Value = AREA_DE_WORK.AC_I_V0APOLCORRET + +1;

        }

        [StopWatch]
        /*" R1700-00-INSERT-V0APOLCORRET-DB-INSERT-1 */
        public void R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1()
        {
            /*" -1545- EXEC SQL INSERT INTO SEGUROS.V0APOLCORRET VALUES (:V0ACOR-NUM-APOL , :V0ACOR-RAMOFR , :V0ACOR-MODALIFR , :V0ACOR-CODCORR , :V0ACOR-CODSUBES , :V0ACOR-DTINIVIG , :V0ACOR-DTTERVIG , :V0ACOR-PCPARCOR , :V0ACOR-PCCOMCOR , :V0ACOR-TIPCOM , :V0ACOR-INDCRT , :V0ACOR-COD-EMPRESA , CURRENT TIMESTAMP , :V0ACOR-COD-USUARIO) END-EXEC. */

            var r1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1 = new R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1()
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
                V0ACOR_COD_USUARIO = V0ACOR_COD_USUARIO.ToString(),
            };

            R1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1.Execute(r1700_00_INSERT_V0APOLCORRET_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-DECLARE-V1PROPCOSCED-SECTION */
        private void R1800_00_DECLARE_V1PROPCOSCED_SECTION()
        {
            /*" -1572- MOVE '180' TO WNR-EXEC-SQL. */
            _.Move("180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1587- PERFORM R1800_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1 */

            R1800_00_DECLARE_V1PROPCOSCED_DB_DECLARE_1();

            /*" -1589- PERFORM R1800_00_DECLARE_V1PROPCOSCED_DB_OPEN_1 */

            R1800_00_DECLARE_V1PROPCOSCED_DB_OPEN_1();

        }

        [StopWatch]
        /*" R1800-00-DECLARE-V1PROPCOSCED-DB-OPEN-1 */
        public void R1800_00_DECLARE_V1PROPCOSCED_DB_OPEN_1()
        {
            /*" -1589- EXEC SQL OPEN V1PROPCOSCED END-EXEC. */

            V1PROPCOSCED.Open();

        }

        [StopWatch]
        /*" R2050-00-DECLARE-V1PROPLOCINC-DB-DECLARE-1 */
        public void R2050_00_DECLARE_V1PROPLOCINC_DB_DECLARE_1()
        {
            /*" -1826- EXEC SQL DECLARE V1PROPLOCINC CURSOR FOR SELECT NUM_RISCO , COD_LOGRADOURO , QTITENS , SITUACAO FROM SEGUROS.V1PROPLOCALINC WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS AND SITUACAO IN ( ' ' , '0' , '2' ) ORDER BY NUM_RISCO , COD_LOGRADOURO END-EXEC. */
            V1PROPLOCINC = new EM0006B_V1PROPLOCINC(true);
            string GetQuery_V1PROPLOCINC()
            {
                var query = @$"SELECT 
							NUM_RISCO
							, 
							COD_LOGRADOURO
							, 
							QTITENS
							, 
							SITUACAO 
							FROM 
							SEGUROS.V1PROPLOCALINC 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							AND SITUACAO IN ( ' '
							, '0'
							, '2' ) 
							ORDER BY 
							NUM_RISCO
							, 
							COD_LOGRADOURO";

                return query;
            }
            V1PROPLOCINC.GetQueryEvent += GetQuery_V1PROPLOCINC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1810-00-FETCH-V1PROPCOSCED-SECTION */
        private void R1810_00_FETCH_V1PROPCOSCED_SECTION()
        {
            /*" -1602- MOVE '181' TO WNR-EXEC-SQL. */
            _.Move("181", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1610- PERFORM R1810_00_FETCH_V1PROPCOSCED_DB_FETCH_1 */

            R1810_00_FETCH_V1PROPCOSCED_DB_FETCH_1();

            /*" -1613- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1614- MOVE 'S' TO WFIM-V1PROPCOSCED */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPCOSCED);

                /*" -1614- PERFORM R1810_00_FETCH_V1PROPCOSCED_DB_CLOSE_1 */

                R1810_00_FETCH_V1PROPCOSCED_DB_CLOSE_1();

                /*" -1617- GO TO R1810-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1618- ADD V1PCOS-PCPARTIC TO W0APOL-PCTCED */
            W0APOL_PCTCED.Value = W0APOL_PCTCED + V1PCOS_PCPARTIC;

            /*" -1620- ADD +1 TO W0APOL-QTCOSSEG */
            W0APOL_QTCOSSEG.Value = W0APOL_QTCOSSEG + +1;

            /*" -1620- ADD +1 TO AC-L-V1PROPCOSCED. */
            AREA_DE_WORK.AC_L_V1PROPCOSCED.Value = AREA_DE_WORK.AC_L_V1PROPCOSCED + +1;

        }

        [StopWatch]
        /*" R1810-00-FETCH-V1PROPCOSCED-DB-FETCH-1 */
        public void R1810_00_FETCH_V1PROPCOSCED_DB_FETCH_1()
        {
            /*" -1610- EXEC SQL FETCH V1PROPCOSCED INTO :V1PCOS-FONTE , :V1PCOS-NRPROPOS , :V1PCOS-CODCOSS , :V1PCOS-RAMOFR , :V1PCOS-PCPARTIC , :V1PCOS-PCCOMCOS END-EXEC. */

            if (V1PROPCOSCED.Fetch())
            {
                _.Move(V1PROPCOSCED.V1PCOS_FONTE, V1PCOS_FONTE);
                _.Move(V1PROPCOSCED.V1PCOS_NRPROPOS, V1PCOS_NRPROPOS);
                _.Move(V1PROPCOSCED.V1PCOS_CODCOSS, V1PCOS_CODCOSS);
                _.Move(V1PROPCOSCED.V1PCOS_RAMOFR, V1PCOS_RAMOFR);
                _.Move(V1PROPCOSCED.V1PCOS_PCPARTIC, V1PCOS_PCPARTIC);
                _.Move(V1PROPCOSCED.V1PCOS_PCCOMCOS, V1PCOS_PCCOMCOS);
            }

        }

        [StopWatch]
        /*" R1810-00-FETCH-V1PROPCOSCED-DB-CLOSE-1 */
        public void R1810_00_FETCH_V1PROPCOSCED_DB_CLOSE_1()
        {
            /*" -1614- EXEC SQL CLOSE V1PROPCOSCED END-EXEC */

            V1PROPCOSCED.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1810_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-INSERT-V0APOLCOSCED-SECTION */
        private void R1900_00_INSERT_V0APOLCOSCED_SECTION()
        {
            /*" -1633- MOVE '190' TO WNR-EXEC-SQL. */
            _.Move("190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1634- IF V1PROP-TPCOSCED NOT EQUAL '5' */

            if (V1PROP_TPCOSCED != "5")
            {

                /*" -1635- PERFORM R1810-00-FETCH-V1PROPCOSCED */

                R1810_00_FETCH_V1PROPCOSCED_SECTION();

                /*" -1636- IF WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty())
                {

                    /*" -1637- GO TO R1900-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                    return;

                    /*" -1639- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1640- ELSE */
                }

            }
            else
            {


                /*" -1641- PERFORM R2510-00-FETCH-V1COSSEGSORT */

                R2510_00_FETCH_V1COSSEGSORT_SECTION();

                /*" -1642- IF WFIM-V1PROPCOSCED NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_V1PROPCOSCED.IsEmpty())
                {

                    /*" -1644- GO TO R1900-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1645- MOVE WNUM-APOLICE TO V0ACOS-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0ACOS_NUM_APOL);

            /*" -1646- MOVE V1PROP-DTINIVIG TO V0ACOS-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0ACOS_DTINIVIG);

            /*" -1647- MOVE V1PROP-DTTERVIG TO V0ACOS-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0ACOS_DTTERVIG);

            /*" -1650- MOVE 11 TO V0ACOS-COD-EMPRESA */
            _.Move(11, V0ACOS_COD_EMPRESA);

            /*" -1651- IF V1PROP-TPCOSCED NOT EQUAL '5' */

            if (V1PROP_TPCOSCED != "5")
            {

                /*" -1652- MOVE V1PCOS-CODCOSS TO V0ACOS-CODCOSS */
                _.Move(V1PCOS_CODCOSS, V0ACOS_CODCOSS);

                /*" -1653- MOVE V1PCOS-RAMOFR TO V0ACOS-RAMOFR */
                _.Move(V1PCOS_RAMOFR, V0ACOS_RAMOFR);

                /*" -1654- MOVE V1PCOS-PCPARTIC TO V0ACOS-PCPARTIC */
                _.Move(V1PCOS_PCPARTIC, V0ACOS_PCPARTIC);

                /*" -1655- MOVE V1PCOS-PCCOMCOS TO V0ACOS-PCCOMCOS */
                _.Move(V1PCOS_PCCOMCOS, V0ACOS_PCCOMCOS);

                /*" -1656- ELSE */
            }
            else
            {


                /*" -1657- MOVE V1COSS-CONGENER TO V0ACOS-CODCOSS */
                _.Move(V1COSS_CONGENER, V0ACOS_CODCOSS);

                /*" -1658- MOVE V1COSS-RAMO TO V0ACOS-RAMOFR */
                _.Move(V1COSS_RAMO, V0ACOS_RAMOFR);

                /*" -1659- MOVE V1COSS-PCPARTIC TO V0ACOS-PCPARTIC */
                _.Move(V1COSS_PCPARTIC, V0ACOS_PCPARTIC);

                /*" -1661- MOVE V1COSS-PCCOMCOS TO V0ACOS-PCCOMCOS. */
                _.Move(V1COSS_PCCOMCOS, V0ACOS_PCCOMCOS);
            }


            /*" -1674- PERFORM R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1 */

            R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1();

            /*" -1677- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1680- DISPLAY 'R1900-00 - REGISTRO DUPLICADO (V0APOLCOSCED)' ' ' V0ACOS-NUM-APOL ' ' V0ACOS-CODCOSS */

                $"R1900-00 - REGISTRO DUPLICADO (V0APOLCOSCED) {V0ACOS_NUM_APOL} {V0ACOS_CODCOSS}"
                .Display();

                /*" -1682- GO TO R1900-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1683- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1686- DISPLAY 'R1900-00 - PROBLEMAS NO INSERT (V0APOLCOSCED)' ' ' V0ACOS-NUM-APOL ' ' V0ACOS-CODCOSS */

                $"R1900-00 - PROBLEMAS NO INSERT (V0APOLCOSCED) {V0ACOS_NUM_APOL} {V0ACOS_CODCOSS}"
                .Display();

                /*" -1688- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1688- ADD +1 TO AC-I-V0APOLCOSCED. */
            AREA_DE_WORK.AC_I_V0APOLCOSCED.Value = AREA_DE_WORK.AC_I_V0APOLCOSCED + +1;

        }

        [StopWatch]
        /*" R1900-00-INSERT-V0APOLCOSCED-DB-INSERT-1 */
        public void R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1()
        {
            /*" -1674- EXEC SQL INSERT INTO SEGUROS.V0APOLCOSCED VALUES (:V0ACOS-NUM-APOL , :V0ACOS-CODCOSS , :V0ACOS-RAMOFR , :V0ACOS-DTINIVIG , :V0ACOS-DTTERVIG , :V0ACOS-PCPARTIC , :V0ACOS-PCCOMCOS , :V0ACOS-COD-EMPRESA:VIND-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var r1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1 = new R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0ACOS_NUM_APOL = V0ACOS_NUM_APOL.ToString(),
                V0ACOS_CODCOSS = V0ACOS_CODCOSS.ToString(),
                V0ACOS_RAMOFR = V0ACOS_RAMOFR.ToString(),
                V0ACOS_DTINIVIG = V0ACOS_DTINIVIG.ToString(),
                V0ACOS_DTTERVIG = V0ACOS_DTTERVIG.ToString(),
                V0ACOS_PCPARTIC = V0ACOS_PCPARTIC.ToString(),
                V0ACOS_PCCOMCOS = V0ACOS_PCCOMCOS.ToString(),
                V0ACOS_COD_EMPRESA = V0ACOS_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1900_00_INSERT_V0APOLCOSCED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-ITENS-SECTION */
        private void R2000_00_PROCESSA_ITENS_SECTION()
        {
            /*" -1701- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1703- MOVE SPACES TO WFIM-V1PROPLOCINC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPLOCINC);

            /*" -1704- PERFORM R2050-00-DECLARE-V1PROPLOCINC */

            R2050_00_DECLARE_V1PROPLOCINC_SECTION();

            /*" -1705- PERFORM R2051-00-FETCH-V1PROPLOCINC */

            R2051_00_FETCH_V1PROPLOCINC_SECTION();

            /*" -1706- IF WFIM-V1PROPLOCINC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPLOCINC.IsEmpty())
            {

                /*" -1707- DISPLAY 'PROPOSTA SEM LOCAIS (V1PROPLOCALINC) ... ' */
                _.Display($"PROPOSTA SEM LOCAIS (V1PROPLOCALINC) ... ");

                /*" -1708- DISPLAY 'FONTE ..... ' V1PROP-FONTE */
                _.Display($"FONTE ..... {V1PROP_FONTE}");

                /*" -1709- DISPLAY 'PROPOSTA... ' V1PROP-NRPROPOS */
                _.Display($"PROPOSTA... {V1PROP_NRPROPOS}");

                /*" -1711- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1714- PERFORM R2052-00-INSERT-V0APOLOCALINC UNTIL WFIM-V1PROPLOCINC NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1PROPLOCINC.IsEmpty()))
            {

                R2052_00_INSERT_V0APOLOCALINC_SECTION();
            }

            /*" -1716- PERFORM R5550-00-UPDATE-V0PROPLOCINC */

            R5550_00_UPDATE_V0PROPLOCINC_SECTION();

            /*" -1718- MOVE SPACES TO WFIM-V1PROPINC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPINC);

            /*" -1719- PERFORM R2100-00-DECLARE-V1PROPINC */

            R2100_00_DECLARE_V1PROPINC_SECTION();

            /*" -1720- PERFORM R2110-00-FETCH-V1PROPINC */

            R2110_00_FETCH_V1PROPINC_SECTION();

            /*" -1721- IF WFIM-V1PROPINC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1PROPINC.IsEmpty())
            {

                /*" -1722- DISPLAY 'R2110-00 - PROPOSTA SEM ITENS (V1PROPINC) ' */
                _.Display($"R2110-00 - PROPOSTA SEM ITENS (V1PROPINC) ");

                /*" -1723- DISPLAY 'FONTE ..... ' V1PROP-FONTE */
                _.Display($"FONTE ..... {V1PROP_FONTE}");

                /*" -1724- DISPLAY 'PROPOSTA... ' V1PROP-NRPROPOS */
                _.Display($"PROPOSTA... {V1PROP_NRPROPOS}");

                /*" -1726- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1729- PERFORM R2120-00-INSERT-V0APOITENSINC UNTIL WFIM-V1PROPINC NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WFIM_V1PROPINC.IsEmpty()))
            {

                R2120_00_INSERT_V0APOITENSINC_SECTION();
            }

            /*" -1730- MOVE SPACES TO WFIM-V1PROPCLAUS */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPCLAUS);

            /*" -1731- PERFORM R2200-00-DECLARE-V1PROPCLAUS */

            R2200_00_DECLARE_V1PROPCLAUS_SECTION();

            /*" -1732- PERFORM R2220-00-FETCH-V1PROPCLAUS */

            R2220_00_FETCH_V1PROPCLAUS_SECTION();

            /*" -1734- IF WFIM-V1PROPCLAUS NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPCLAUS.IsEmpty())
            {

                /*" -1735- ELSE */
            }
            else
            {


                /*" -1738- PERFORM R2210-00-INSERT-V0APOLCLAUS UNTIL WFIM-V1PROPCLAUS NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPCLAUS.IsEmpty()))
                {

                    R2210_00_INSERT_V0APOLCLAUS_SECTION();
                }
            }


            /*" -1739- MOVE ZEROS TO W0COBA-IMP-SEG-IX */
            _.Move(0, W0COBA_IMP_SEG_IX);

            /*" -1740- MOVE ZEROS TO W0COBA-PRM-TAR-IX */
            _.Move(0, W0COBA_PRM_TAR_IX);

            /*" -1741- MOVE ZEROS TO W0COBA-IMP-SEG-VR */
            _.Move(0, W0COBA_IMP_SEG_VR);

            /*" -1742- MOVE ZEROS TO W0COBA-PRM-TAR-VR */
            _.Move(0, W0COBA_PRM_TAR_VR);

            /*" -1744- MOVE ZEROS TO WS-NUM-ITEM */
            _.Move(0, AREA_DE_WORK.WS_NUM_ITEM);

            /*" -1745- MOVE ZEROS TO W1COBP-PRM-TAR-IX */
            _.Move(0, W1COBP_PRM_TAR_IX);

            /*" -1747- MOVE ZEROS TO W1COBP-PCT-TOTAL */
            _.Move(0, W1COBP_PCT_TOTAL);

            /*" -1748- MOVE SPACES TO WFIM-V1COBPROPINC */
            _.Move("", AREA_DE_WORK.WFIM_V1COBPROPINC);

            /*" -1749- PERFORM R3600-00-DECLARE-V1COBPROPINC */

            R3600_00_DECLARE_V1COBPROPINC_SECTION();

            /*" -1750- PERFORM R3610-00-FETCH-V1COBPROPINC */

            R3610_00_FETCH_V1COBPROPINC_SECTION();

            /*" -1751- IF WFIM-V1COBPROPINC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1COBPROPINC.IsEmpty())
            {

                /*" -1752- DISPLAY 'R3610-00 - PROPOSTA SEM COBERTURAS ... ' */
                _.Display($"R3610-00 - PROPOSTA SEM COBERTURAS ... ");

                /*" -1753- DISPLAY 'FONTE ..... ' V1PROP-FONTE */
                _.Display($"FONTE ..... {V1PROP_FONTE}");

                /*" -1754- DISPLAY 'PROPOSTA... ' V1PROP-NRPROPOS */
                _.Display($"PROPOSTA... {V1PROP_NRPROPOS}");

                /*" -1756- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1757- MOVE SPACES TO WFIM-V1COBPROPINC */
            _.Move("", AREA_DE_WORK.WFIM_V1COBPROPINC);

            /*" -1760- PERFORM R3800-00-MONTA-V0COBERINC UNTIL WFIM-V1COBPROPINC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V1COBPROPINC.IsEmpty()))
            {

                R3800_00_MONTA_V0COBERINC_SECTION();
            }

            /*" -1761- MOVE SPACES TO WFIM-V1PROPDESINC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPDESINC);

            /*" -1762- PERFORM R2600-00-DECLARE-V1PROPDESINC */

            R2600_00_DECLARE_V1PROPDESINC_SECTION();

            /*" -1763- PERFORM R2610-00-FETCH-V1PROPDESINC */

            R2610_00_FETCH_V1PROPDESINC_SECTION();

            /*" -1765- IF WFIM-V1PROPDESINC NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPDESINC.IsEmpty())
            {

                /*" -1766- ELSE */
            }
            else
            {


                /*" -1769- PERFORM R2700-00-INSERT-V0APODESITEM UNTIL WFIM-V1PROPDESINC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPDESINC.IsEmpty()))
                {

                    R2700_00_INSERT_V0APODESITEM_SECTION();
                }
            }


            /*" -1770- MOVE SPACES TO WFIM-V1PROPDESCO */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPDESCO);

            /*" -1771- PERFORM R2800-00-DECLARE-V1PROPDESCO */

            R2800_00_DECLARE_V1PROPDESCO_SECTION();

            /*" -1772- PERFORM R2810-00-FETCH-V1PROPDESCO */

            R2810_00_FETCH_V1PROPDESCO_SECTION();

            /*" -1774- IF WFIM-V1PROPDESCO NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPDESCO.IsEmpty())
            {

                /*" -1775- ELSE */
            }
            else
            {


                /*" -1778- PERFORM R2850-00-INSERT-V0APOLDESCO UNTIL WFIM-V1PROPDESCO NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPDESCO.IsEmpty()))
                {

                    R2850_00_INSERT_V0APOLDESCO_SECTION();
                }
            }


            /*" -1780- PERFORM R5700-00-UPDATE-V0PROPDESCO */

            R5700_00_UPDATE_V0PROPDESCO_SECTION();

            /*" -1781- MOVE SPACES TO WFIM-V1PROPOUTR */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPOUTR);

            /*" -1782- PERFORM R2860-00-DECLARE-V1PROPOUTR */

            R2860_00_DECLARE_V1PROPOUTR_SECTION();

            /*" -1783- PERFORM R2870-00-FETCH-V1PROPOUTR */

            R2870_00_FETCH_V1PROPOUTR_SECTION();

            /*" -1785- IF WFIM-V1PROPOUTR NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPOUTR.IsEmpty())
            {

                /*" -1786- ELSE */
            }
            else
            {


                /*" -1789- PERFORM R2880-00-INSERT-V0APOLOUTR UNTIL WFIM-V1PROPOUTR NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPOUTR.IsEmpty()))
                {

                    R2880_00_INSERT_V0APOLOUTR_SECTION();
                }
            }


            /*" -1790- MOVE SPACES TO WFIM-V1PROPDCOB */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPDCOB);

            /*" -1791- PERFORM R2900-00-DECLARE-V1PROPDCOB */

            R2900_00_DECLARE_V1PROPDCOB_SECTION();

            /*" -1792- PERFORM R2910-00-FETCH-V1PROPDCOB */

            R2910_00_FETCH_V1PROPDCOB_SECTION();

            /*" -1794- IF WFIM-V1PROPDCOB NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPDCOB.IsEmpty())
            {

                /*" -1795- ELSE */
            }
            else
            {


                /*" -1798- PERFORM R2950-00-INSERT-V0APOLDCOB UNTIL WFIM-V1PROPDCOB NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPDCOB.IsEmpty()))
                {

                    R2950_00_INSERT_V0APOLDCOB_SECTION();
                }
            }


            /*" -1798- PERFORM R5800-00-UPDATE-V0PROPDCOB. */

            R5800_00_UPDATE_V0PROPDCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-DECLARE-V1PROPLOCINC-SECTION */
        private void R2050_00_DECLARE_V1PROPLOCINC_SECTION()
        {
            /*" -1811- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1826- PERFORM R2050_00_DECLARE_V1PROPLOCINC_DB_DECLARE_1 */

            R2050_00_DECLARE_V1PROPLOCINC_DB_DECLARE_1();

            /*" -1828- PERFORM R2050_00_DECLARE_V1PROPLOCINC_DB_OPEN_1 */

            R2050_00_DECLARE_V1PROPLOCINC_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2050-00-DECLARE-V1PROPLOCINC-DB-OPEN-1 */
        public void R2050_00_DECLARE_V1PROPLOCINC_DB_OPEN_1()
        {
            /*" -1828- EXEC SQL OPEN V1PROPLOCINC END-EXEC. */

            V1PROPLOCINC.Open();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1PROPINC-DB-DECLARE-1 */
        public void R2100_00_DECLARE_V1PROPINC_DB_DECLARE_1()
        {
            /*" -2030- EXEC SQL DECLARE V1PROPINC CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NUM_RISCO , CODCOBINC , SUBRIS , NRITEM , COD_PLANTA , RUBRICA , CLASOCUPA , CLASCONST , DTINIVIG , DTTERVIG , IMP_SEGURADA_IX , PRM_TARIFARIO_IX , TIPCOND , TAXA_PRM , TIPO_TAXA , PCDESCON , TPDESCON , PCADICIO , PCVALRISC, COEFAGRAV, TIPRAZO , SITUACAO , TPMOVTO , TIPO_OCUPACAO, SUBTP_OCUPACAO, QTPAVTO FROM SEGUROS.V1PROPINC WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS AND SITUACAO IN ( ' ' , '0' , '2' ) ORDER BY NUM_RISCO , CODCOBINC , NRITEM END-EXEC. */
            V1PROPINC = new EM0006B_V1PROPINC(true);
            string GetQuery_V1PROPINC()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NUM_RISCO
							, 
							CODCOBINC
							, 
							SUBRIS
							, 
							NRITEM
							, 
							COD_PLANTA
							, 
							RUBRICA
							, 
							CLASOCUPA
							, 
							CLASCONST
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							IMP_SEGURADA_IX
							, 
							PRM_TARIFARIO_IX
							, 
							TIPCOND
							, 
							TAXA_PRM
							, 
							TIPO_TAXA
							, 
							PCDESCON
							, 
							TPDESCON
							, 
							PCADICIO
							, 
							PCVALRISC
							, 
							COEFAGRAV
							, 
							TIPRAZO
							, 
							SITUACAO
							, 
							TPMOVTO
							, 
							TIPO_OCUPACAO
							, 
							SUBTP_OCUPACAO
							, 
							QTPAVTO 
							FROM 
							SEGUROS.V1PROPINC 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							AND SITUACAO IN ( ' '
							, '0'
							, '2' ) 
							ORDER BY 
							NUM_RISCO
							, 
							CODCOBINC
							, 
							NRITEM";

                return query;
            }
            V1PROPINC.GetQueryEvent += GetQuery_V1PROPINC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2051-00-FETCH-V1PROPLOCINC-SECTION */
        private void R2051_00_FETCH_V1PROPLOCINC_SECTION()
        {
            /*" -1841- MOVE '051' TO WNR-EXEC-SQL. */
            _.Move("051", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1847- PERFORM R2051_00_FETCH_V1PROPLOCINC_DB_FETCH_1 */

            R2051_00_FETCH_V1PROPLOCINC_DB_FETCH_1();

            /*" -1850- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1851- MOVE 'S' TO WFIM-V1PROPLOCINC */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPLOCINC);

                /*" -1851- PERFORM R2051_00_FETCH_V1PROPLOCINC_DB_CLOSE_1 */

                R2051_00_FETCH_V1PROPLOCINC_DB_CLOSE_1();

                /*" -1854- GO TO R2051-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2051_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1854- ADD +1 TO AC-L-V1PROPLOCINC. */
            AREA_DE_WORK.AC_L_V1PROPLOCINC.Value = AREA_DE_WORK.AC_L_V1PROPLOCINC + +1;

        }

        [StopWatch]
        /*" R2051-00-FETCH-V1PROPLOCINC-DB-FETCH-1 */
        public void R2051_00_FETCH_V1PROPLOCINC_DB_FETCH_1()
        {
            /*" -1847- EXEC SQL FETCH V1PROPLOCINC INTO :V1PRLI-NUM-RISCO , :V1PRLI-COD-LOCAL , :V1PRLI-QTITENS , :V1PRLI-SITUACAO END-EXEC. */

            if (V1PROPLOCINC.Fetch())
            {
                _.Move(V1PROPLOCINC.V1PRLI_NUM_RISCO, V1PRLI_NUM_RISCO);
                _.Move(V1PROPLOCINC.V1PRLI_COD_LOCAL, V1PRLI_COD_LOCAL);
                _.Move(V1PROPLOCINC.V1PRLI_QTITENS, V1PRLI_QTITENS);
                _.Move(V1PROPLOCINC.V1PRLI_SITUACAO, V1PRLI_SITUACAO);
            }

        }

        [StopWatch]
        /*" R2051-00-FETCH-V1PROPLOCINC-DB-CLOSE-1 */
        public void R2051_00_FETCH_V1PROPLOCINC_DB_CLOSE_1()
        {
            /*" -1851- EXEC SQL CLOSE V1PROPLOCINC END-EXEC */

            V1PROPLOCINC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2051_99_SAIDA*/

        [StopWatch]
        /*" R2052-00-INSERT-V0APOLOCALINC-SECTION */
        private void R2052_00_INSERT_V0APOLOCALINC_SECTION()
        {
            /*" -1867- MOVE '052' TO WNR-EXEC-SQL. */
            _.Move("052", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1869- MOVE 1 TO WS-OCORHIST. */
            _.Move(1, AREA_DE_WORK.WS_OCORHIST);

            /*" -1870- IF V1PROP-TPPROPOS EQUAL '2' OR '3' */

            if (V1PROP_TPPROPOS.In("2", "3"))
            {

                /*" -1872- PERFORM R2053-00-UPDATE-V0APOLOCALINC. */

                R2053_00_UPDATE_V0APOLOCALINC_SECTION();
            }


            /*" -1874- MOVE 11 TO V0APLI-COD-EMPRESA */
            _.Move(11, V0APLI_COD_EMPRESA);

            /*" -1875- MOVE V0ENDO-NUM-APOL TO V0APLI-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APLI_NUM_APOL);

            /*" -1876- MOVE V0ENDO-NRENDOS TO V0APLI-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APLI_NRENDOS);

            /*" -1877- MOVE V1PRLI-NUM-RISCO TO V0APLI-NUM-RISCO */
            _.Move(V1PRLI_NUM_RISCO, V0APLI_NUM_RISCO);

            /*" -1878- MOVE V1PRLI-COD-LOCAL TO V0APLI-COD-LOCAL */
            _.Move(V1PRLI_COD_LOCAL, V0APLI_COD_LOCAL);

            /*" -1879- MOVE V1PRLI-QTITENS TO V0APLI-QTITENS */
            _.Move(V1PRLI_QTITENS, V0APLI_QTITENS);

            /*" -1880- MOVE V1PROP-DTINIVIG TO V0APLI-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0APLI_DTINIVIG);

            /*" -1881- MOVE V1PROP-DTTERVIG TO V0APLI-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0APLI_DTTERVIG);

            /*" -1882- MOVE '0' TO V0APLI-SITUACAO */
            _.Move("0", V0APLI_SITUACAO);

            /*" -1884- MOVE WS-OCORHIST TO V0APLI-OCORHIST */
            _.Move(AREA_DE_WORK.WS_OCORHIST, V0APLI_OCORHIST);

            /*" -1897- PERFORM R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1 */

            R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1();

            /*" -1900- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1901- DISPLAY 'R2052 - V0APOLOCALINC (REGISTRO DUPLICADO)' */
                _.Display($"R2052 - V0APOLOCALINC (REGISTRO DUPLICADO)");

                /*" -1902- DISPLAY 'FONTE ..... ' V1PROP-FONTE */
                _.Display($"FONTE ..... {V1PROP_FONTE}");

                /*" -1903- DISPLAY 'PROPOSTA .. ' V1PROP-NRPROPOS */
                _.Display($"PROPOSTA .. {V1PROP_NRPROPOS}");

                /*" -1904- DISPLAY 'APOLICE ... ' V0APLI-NUM-APOL */
                _.Display($"APOLICE ... {V0APLI_NUM_APOL}");

                /*" -1905- DISPLAY 'ENDOSSO ... ' V0APLI-NRENDOS */
                _.Display($"ENDOSSO ... {V0APLI_NRENDOS}");

                /*" -1906- DISPLAY 'RISCO ..... ' V0APLI-NUM-RISCO */
                _.Display($"RISCO ..... {V0APLI_NUM_RISCO}");

                /*" -1908- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1909- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1910- DISPLAY 'R2052 - V0APOLOCALINC (PROBLEMAS INSERCAO)' */
                _.Display($"R2052 - V0APOLOCALINC (PROBLEMAS INSERCAO)");

                /*" -1911- DISPLAY 'FONTE ..... ' V1PROP-FONTE */
                _.Display($"FONTE ..... {V1PROP_FONTE}");

                /*" -1912- DISPLAY 'PROPOSTA .. ' V1PROP-NRPROPOS */
                _.Display($"PROPOSTA .. {V1PROP_NRPROPOS}");

                /*" -1913- DISPLAY 'APOLICE ... ' V0APLI-NUM-APOL */
                _.Display($"APOLICE ... {V0APLI_NUM_APOL}");

                /*" -1914- DISPLAY 'ENDOSSO ... ' V0APLI-NRENDOS */
                _.Display($"ENDOSSO ... {V0APLI_NRENDOS}");

                /*" -1915- DISPLAY 'RISCO ..... ' V0APLI-NUM-RISCO */
                _.Display($"RISCO ..... {V0APLI_NUM_RISCO}");

                /*" -1917- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1919- ADD +1 TO AC-I-V0APOLOCINC. */
            AREA_DE_WORK.AC_I_V0APOLOCINC.Value = AREA_DE_WORK.AC_I_V0APOLOCINC + +1;

            /*" -1919- PERFORM R2051-00-FETCH-V1PROPLOCINC. */

            R2051_00_FETCH_V1PROPLOCINC_SECTION();

        }

        [StopWatch]
        /*" R2052-00-INSERT-V0APOLOCALINC-DB-INSERT-1 */
        public void R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1()
        {
            /*" -1897- EXEC SQL INSERT INTO SEGUROS.V0APOLOCALINC VALUES (:V0APLI-COD-EMPRESA , :V0APLI-NUM-APOL , :V0APLI-NRENDOS , :V0APLI-NUM-RISCO , :V0APLI-COD-LOCAL , :V0APLI-QTITENS , :V0APLI-DTINIVIG , :V0APLI-DTTERVIG , :V0APLI-SITUACAO , CURRENT TIMESTAMP, :V0APLI-OCORHIST) END-EXEC. */

            var r2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1 = new R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1()
            {
                V0APLI_COD_EMPRESA = V0APLI_COD_EMPRESA.ToString(),
                V0APLI_NUM_APOL = V0APLI_NUM_APOL.ToString(),
                V0APLI_NRENDOS = V0APLI_NRENDOS.ToString(),
                V0APLI_NUM_RISCO = V0APLI_NUM_RISCO.ToString(),
                V0APLI_COD_LOCAL = V0APLI_COD_LOCAL.ToString(),
                V0APLI_QTITENS = V0APLI_QTITENS.ToString(),
                V0APLI_DTINIVIG = V0APLI_DTINIVIG.ToString(),
                V0APLI_DTTERVIG = V0APLI_DTTERVIG.ToString(),
                V0APLI_SITUACAO = V0APLI_SITUACAO.ToString(),
                V0APLI_OCORHIST = V0APLI_OCORHIST.ToString(),
            };

            R2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1.Execute(r2052_00_INSERT_V0APOLOCALINC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2052_99_SAIDA*/

        [StopWatch]
        /*" R2053-00-UPDATE-V0APOLOCALINC-SECTION */
        private void R2053_00_UPDATE_V0APOLOCALINC_SECTION()
        {
            /*" -1932- MOVE '053' TO WNR-EXEC-SQL. */
            _.Move("053", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1942- PERFORM R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1 */

            R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1();

            /*" -1945- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1947- MOVE 1 TO WS-OCORHIST */
                    _.Move(1, AREA_DE_WORK.WS_OCORHIST);

                    /*" -1948- GO TO R2053-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2053_99_SAIDA*/ //GOTO
                    return;

                    /*" -1949- ELSE */
                }
                else
                {


                    /*" -1953- DISPLAY 'PROBLEMAS SELECT (V1APOLOCALINC) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V1PRLI-NUM-RISCO */

                    $"PROBLEMAS SELECT (V1APOLOCALINC) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V1PRLI_NUM_RISCO}"
                    .Display();

                    /*" -1955- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1964- PERFORM R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1 */

            R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1();

            /*" -1967- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1968- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1969- GO TO R2053-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2053_99_SAIDA*/ //GOTO
                    return;

                    /*" -1970- ELSE */
                }
                else
                {


                    /*" -1975- DISPLAY 'PROBLEMAS UPDATE (V0APOLOCALINC) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V1PRLI-NUM-RISCO ' ' V1APLI-OCORHIST */

                    $"PROBLEMAS UPDATE (V0APOLOCALINC) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V1PRLI_NUM_RISCO} {V1APLI_OCORHIST}"
                    .Display();

                    /*" -1977- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1977- COMPUTE WS-OCORHIST = V1APLI-OCORHIST + 1. */
            AREA_DE_WORK.WS_OCORHIST.Value = V1APLI_OCORHIST + 1;

        }

        [StopWatch]
        /*" R2053-00-UPDATE-V0APOLOCALINC-DB-SELECT-1 */
        public void R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1()
        {
            /*" -1942- EXEC SQL SELECT OCORHIST INTO :V1APLI-OCORHIST FROM SEGUROS.V1APOLOCALINC WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NUM_RISCO = :V1PRLI-NUM-RISCO AND SITUACAO = '0' END-EXEC. */

            var r2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1 = new R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1()
            {
                V1PRLI_NUM_RISCO = V1PRLI_NUM_RISCO.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
            };

            var executed_1 = R2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1.Execute(r2053_00_UPDATE_V0APOLOCALINC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APLI_OCORHIST, V1APLI_OCORHIST);
            }


        }

        [StopWatch]
        /*" R2053-00-UPDATE-V0APOLOCALINC-DB-UPDATE-1 */
        public void R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1()
        {
            /*" -1964- EXEC SQL UPDATE SEGUROS.V0APOLOCALINC SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NUM_RISCO = :V1PRLI-NUM-RISCO AND OCORHIST = :V1APLI-OCORHIST AND SITUACAO = '0' END-EXEC. */

            var r2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1_Update1 = new R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1_Update1()
            {
                V1PRLI_NUM_RISCO = V1PRLI_NUM_RISCO.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1APLI_OCORHIST = V1APLI_OCORHIST.ToString(),
            };

            R2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1_Update1.Execute(r2053_00_UPDATE_V0APOLOCALINC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2053_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-V1PROPINC-SECTION */
        private void R2100_00_DECLARE_V1PROPINC_SECTION()
        {
            /*" -1990- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2030- PERFORM R2100_00_DECLARE_V1PROPINC_DB_DECLARE_1 */

            R2100_00_DECLARE_V1PROPINC_DB_DECLARE_1();

            /*" -2032- PERFORM R2100_00_DECLARE_V1PROPINC_DB_OPEN_1 */

            R2100_00_DECLARE_V1PROPINC_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2100-00-DECLARE-V1PROPINC-DB-OPEN-1 */
        public void R2100_00_DECLARE_V1PROPINC_DB_OPEN_1()
        {
            /*" -2032- EXEC SQL OPEN V1PROPINC END-EXEC. */

            V1PROPINC.Open();

        }

        [StopWatch]
        /*" R2200-00-DECLARE-V1PROPCLAUS-DB-DECLARE-1 */
        public void R2200_00_DECLARE_V1PROPCLAUS_DB_DECLARE_1()
        {
            /*" -2292- EXEC SQL DECLARE V1PROPCLAUSULA CURSOR FOR SELECT COD_EMPRESA, FONTE , NRPROPOS , RAMOFR , MODALIFR , COD_COBERTURA, DTINIVIG , DTTERVIG , NRITEM, CODCLAUS, LIMITE_INDENIZA_IX, TIPOCLAU FROM SEGUROS.V1PROPCLAUSULA WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY NRITEM,CODCLAUS END-EXEC. */
            V1PROPCLAUSULA = new EM0006B_V1PROPCLAUSULA(true);
            string GetQuery_V1PROPCLAUSULA()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							RAMOFR
							, 
							MODALIFR
							, 
							COD_COBERTURA
							, 
							DTINIVIG
							, 
							DTTERVIG
							, 
							NRITEM
							, 
							CODCLAUS
							, 
							LIMITE_INDENIZA_IX
							, 
							TIPOCLAU 
							FROM SEGUROS.V1PROPCLAUSULA 
							WHERE FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY NRITEM
							,CODCLAUS";

                return query;
            }
            V1PROPCLAUSULA.GetQueryEvent += GetQuery_V1PROPCLAUSULA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-FETCH-V1PROPINC-SECTION */
        private void R2110_00_FETCH_V1PROPINC_SECTION()
        {
            /*" -2045- MOVE '211' TO WNR-EXEC-SQL. */
            _.Move("211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2076- PERFORM R2110_00_FETCH_V1PROPINC_DB_FETCH_1 */

            R2110_00_FETCH_V1PROPINC_DB_FETCH_1();

            /*" -2079- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2080- MOVE 'S' TO WFIM-V1PROPINC */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPINC);

                /*" -2080- PERFORM R2110_00_FETCH_V1PROPINC_DB_CLOSE_1 */

                R2110_00_FETCH_V1PROPINC_DB_CLOSE_1();

                /*" -2083- GO TO R2110-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2083- ADD +1 TO AC-L-V1PROPINC. */
            AREA_DE_WORK.AC_L_V1PROPINC.Value = AREA_DE_WORK.AC_L_V1PROPINC + +1;

        }

        [StopWatch]
        /*" R2110-00-FETCH-V1PROPINC-DB-FETCH-1 */
        public void R2110_00_FETCH_V1PROPINC_DB_FETCH_1()
        {
            /*" -2076- EXEC SQL FETCH V1PROPINC INTO :V1PRIN-COD-EMPRESA , :V1PRIN-FONTE , :V1PRIN-NRPROPOS , :V1PRIN-NUM-RISCO , :V1PRIN-CODCOBINC , :V1PRIN-SUBRIS , :V1PRIN-NRITEM , :V1PRIN-COD-PLANTA , :V1PRIN-COD-RUBRICA , :V1PRIN-CLASOCUPA , :V1PRIN-CLASCONST , :V1PRIN-DTINIVIG , :V1PRIN-DTTERVIG , :V1PRIN-IMP-SEG-IX , :V1PRIN-PRM-TAR-IX , :V1PRIN-TIPCOND , :V1PRIN-TAXA-PRM , :V1PRIN-TIPO-TAXA , :V1PRIN-PCDESCON , :V1PRIN-TPDESCON , :V1PRIN-PCADICIO , :V1PRIN-PCVALRISC, :V1PRIN-COEFAGRAV, :V1PRIN-TIPRAZO , :V1PRIN-SITUACAO , :V1PRIN-TPMOVTO, :V1PRIN-TPOCUP, :V1PRIN-SPOCUP, :V1PRIN-QTPAVTO END-EXEC. */

            if (V1PROPINC.Fetch())
            {
                _.Move(V1PROPINC.V1PRIN_COD_EMPRESA, V1PRIN_COD_EMPRESA);
                _.Move(V1PROPINC.V1PRIN_FONTE, V1PRIN_FONTE);
                _.Move(V1PROPINC.V1PRIN_NRPROPOS, V1PRIN_NRPROPOS);
                _.Move(V1PROPINC.V1PRIN_NUM_RISCO, V1PRIN_NUM_RISCO);
                _.Move(V1PROPINC.V1PRIN_CODCOBINC, V1PRIN_CODCOBINC);
                _.Move(V1PROPINC.V1PRIN_SUBRIS, V1PRIN_SUBRIS);
                _.Move(V1PROPINC.V1PRIN_NRITEM, V1PRIN_NRITEM);
                _.Move(V1PROPINC.V1PRIN_COD_PLANTA, V1PRIN_COD_PLANTA);
                _.Move(V1PROPINC.V1PRIN_COD_RUBRICA, V1PRIN_COD_RUBRICA);
                _.Move(V1PROPINC.V1PRIN_CLASOCUPA, V1PRIN_CLASOCUPA);
                _.Move(V1PROPINC.V1PRIN_CLASCONST, V1PRIN_CLASCONST);
                _.Move(V1PROPINC.V1PRIN_DTINIVIG, V1PRIN_DTINIVIG);
                _.Move(V1PROPINC.V1PRIN_DTTERVIG, V1PRIN_DTTERVIG);
                _.Move(V1PROPINC.V1PRIN_IMP_SEG_IX, V1PRIN_IMP_SEG_IX);
                _.Move(V1PROPINC.V1PRIN_PRM_TAR_IX, V1PRIN_PRM_TAR_IX);
                _.Move(V1PROPINC.V1PRIN_TIPCOND, V1PRIN_TIPCOND);
                _.Move(V1PROPINC.V1PRIN_TAXA_PRM, V1PRIN_TAXA_PRM);
                _.Move(V1PROPINC.V1PRIN_TIPO_TAXA, V1PRIN_TIPO_TAXA);
                _.Move(V1PROPINC.V1PRIN_PCDESCON, V1PRIN_PCDESCON);
                _.Move(V1PROPINC.V1PRIN_TPDESCON, V1PRIN_TPDESCON);
                _.Move(V1PROPINC.V1PRIN_PCADICIO, V1PRIN_PCADICIO);
                _.Move(V1PROPINC.V1PRIN_PCVALRISC, V1PRIN_PCVALRISC);
                _.Move(V1PROPINC.V1PRIN_COEFAGRAV, V1PRIN_COEFAGRAV);
                _.Move(V1PROPINC.V1PRIN_TIPRAZO, V1PRIN_TIPRAZO);
                _.Move(V1PROPINC.V1PRIN_SITUACAO, V1PRIN_SITUACAO);
                _.Move(V1PROPINC.V1PRIN_TPMOVTO, V1PRIN_TPMOVTO);
                _.Move(V1PROPINC.V1PRIN_TPOCUP, V1PRIN_TPOCUP);
                _.Move(V1PROPINC.V1PRIN_SPOCUP, V1PRIN_SPOCUP);
                _.Move(V1PROPINC.V1PRIN_QTPAVTO, V1PRIN_QTPAVTO);
            }

        }

        [StopWatch]
        /*" R2110-00-FETCH-V1PROPINC-DB-CLOSE-1 */
        public void R2110_00_FETCH_V1PROPINC_DB_CLOSE_1()
        {
            /*" -2080- EXEC SQL CLOSE V1PROPINC END-EXEC */

            V1PROPINC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-INSERT-V0APOITENSINC-SECTION */
        private void R2120_00_INSERT_V0APOITENSINC_SECTION()
        {
            /*" -2096- MOVE '212' TO WNR-EXEC-SQL. */
            _.Move("212", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2098- MOVE 1 TO WS-OCORHIST. */
            _.Move(1, AREA_DE_WORK.WS_OCORHIST);

            /*" -2099- IF V1PROP-TPPROPOS EQUAL '2' OR '3' */

            if (V1PROP_TPPROPOS.In("2", "3"))
            {

                /*" -2101- PERFORM R2130-00-UPDATE-V0APOITENSINC. */

                R2130_00_UPDATE_V0APOITENSINC_SECTION();
            }


            /*" -2103- MOVE 11 TO V0APIN-COD-EMPRESA */
            _.Move(11, V0APIN_COD_EMPRESA);

            /*" -2104- MOVE V0ENDO-NUM-APOL TO V0APIN-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APIN_NUM_APOL);

            /*" -2105- MOVE V0ENDO-NRENDOS TO V0APIN-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APIN_NRENDOS);

            /*" -2106- MOVE V1PRIN-NUM-RISCO TO V0APIN-NUM-RISCO */
            _.Move(V1PRIN_NUM_RISCO, V0APIN_NUM_RISCO);

            /*" -2107- MOVE V1PRIN-CODCOBINC TO V0APIN-CODCOBINC */
            _.Move(V1PRIN_CODCOBINC, V0APIN_CODCOBINC);

            /*" -2108- MOVE V1PRIN-SUBRIS TO V0APIN-SUBRIS */
            _.Move(V1PRIN_SUBRIS, V0APIN_SUBRIS);

            /*" -2109- MOVE V1PRIN-NRITEM TO V0APIN-NRITEM */
            _.Move(V1PRIN_NRITEM, V0APIN_NRITEM);

            /*" -2110- MOVE V1PRIN-COD-PLANTA TO V0APIN-COD-PLANTA */
            _.Move(V1PRIN_COD_PLANTA, V0APIN_COD_PLANTA);

            /*" -2111- MOVE V1PRIN-COD-RUBRICA TO V0APIN-COD-RUBRICA */
            _.Move(V1PRIN_COD_RUBRICA, V0APIN_COD_RUBRICA);

            /*" -2112- MOVE V1PRIN-CLASOCUPA TO V0APIN-CLASOCUPA */
            _.Move(V1PRIN_CLASOCUPA, V0APIN_CLASOCUPA);

            /*" -2113- MOVE V1PRIN-CLASCONST TO V0APIN-CLASCONST */
            _.Move(V1PRIN_CLASCONST, V0APIN_CLASCONST);

            /*" -2114- MOVE V1PRIN-DTINIVIG TO V0APIN-DTINIVIG */
            _.Move(V1PRIN_DTINIVIG, V0APIN_DTINIVIG);

            /*" -2115- MOVE V1PRIN-DTTERVIG TO V0APIN-DTTERVIG */
            _.Move(V1PRIN_DTTERVIG, V0APIN_DTTERVIG);

            /*" -2116- MOVE V1PRIN-IMP-SEG-IX TO V0APIN-IMP-SEG-IX */
            _.Move(V1PRIN_IMP_SEG_IX, V0APIN_IMP_SEG_IX);

            /*" -2117- MOVE V1PRIN-PRM-TAR-IX TO V0APIN-PRM-TAR-IX */
            _.Move(V1PRIN_PRM_TAR_IX, V0APIN_PRM_TAR_IX);

            /*" -2118- MOVE V1PRIN-TIPCOND TO V0APIN-TIPCOND */
            _.Move(V1PRIN_TIPCOND, V0APIN_TIPCOND);

            /*" -2119- MOVE V1PRIN-TAXA-PRM TO V0APIN-TAXA-PRM */
            _.Move(V1PRIN_TAXA_PRM, V0APIN_TAXA_PRM);

            /*" -2120- MOVE V1PRIN-TIPO-TAXA TO V0APIN-TIPO-TAXA */
            _.Move(V1PRIN_TIPO_TAXA, V0APIN_TIPO_TAXA);

            /*" -2121- MOVE V1PRIN-PCDESCON TO V0APIN-PCDESCON */
            _.Move(V1PRIN_PCDESCON, V0APIN_PCDESCON);

            /*" -2122- MOVE V1PRIN-TPDESCON TO V0APIN-TPDESCON */
            _.Move(V1PRIN_TPDESCON, V0APIN_TPDESCON);

            /*" -2123- MOVE V1PRIN-PCADICIO TO V0APIN-PCADICIO */
            _.Move(V1PRIN_PCADICIO, V0APIN_PCADICIO);

            /*" -2124- MOVE V1PRIN-PCVALRISC TO V0APIN-PCVALRISC */
            _.Move(V1PRIN_PCVALRISC, V0APIN_PCVALRISC);

            /*" -2125- MOVE V1PRIN-COEFAGRAV TO V0APIN-COEFAGRAV */
            _.Move(V1PRIN_COEFAGRAV, V0APIN_COEFAGRAV);

            /*" -2126- MOVE V1PRIN-TIPRAZO TO V0APIN-TIPRAZO */
            _.Move(V1PRIN_TIPRAZO, V0APIN_TIPRAZO);

            /*" -2127- MOVE '0' TO V0APIN-SITUACAO */
            _.Move("0", V0APIN_SITUACAO);

            /*" -2128- MOVE V1PRIN-TPMOVTO TO V0APIN-TPMOVTO */
            _.Move(V1PRIN_TPMOVTO, V0APIN_TPMOVTO);

            /*" -2129- MOVE V1PRIN-TPOCUP TO V0APIN-TPOCUP */
            _.Move(V1PRIN_TPOCUP, V0APIN_TPOCUP);

            /*" -2130- MOVE V1PRIN-SPOCUP TO V0APIN-SPOCUP */
            _.Move(V1PRIN_SPOCUP, V0APIN_SPOCUP);

            /*" -2131- MOVE V1PRIN-QTPAVTO TO V0APIN-QTPAVTO */
            _.Move(V1PRIN_QTPAVTO, V0APIN_QTPAVTO);

            /*" -2133- MOVE WS-OCORHIST TO V0APIN-OCORHIST */
            _.Move(AREA_DE_WORK.WS_OCORHIST, V0APIN_OCORHIST);

            /*" -2166- PERFORM R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1 */

            R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1();

            /*" -2169- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2170- DISPLAY 'R2120 - V0APOITENSINC (REGISTRO DUPLICADO)' */
                _.Display($"R2120 - V0APOITENSINC (REGISTRO DUPLICADO)");

                /*" -2171- DISPLAY 'APOLICE ... ' V0APIN-NUM-APOL */
                _.Display($"APOLICE ... {V0APIN_NUM_APOL}");

                /*" -2172- DISPLAY 'ENDOSSO ... ' V0APIN-NRENDOS */
                _.Display($"ENDOSSO ... {V0APIN_NRENDOS}");

                /*" -2173- DISPLAY 'RISCO ..... ' V0APIN-NUM-RISCO */
                _.Display($"RISCO ..... {V0APIN_NUM_RISCO}");

                /*" -2174- DISPLAY 'ITEM ...... ' V0APIN-NRITEM */
                _.Display($"ITEM ...... {V0APIN_NRITEM}");

                /*" -2176- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2177- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2178- DISPLAY 'R2120 - V0APOITENSINC (PROBLEMAS INSERCAO)' */
                _.Display($"R2120 - V0APOITENSINC (PROBLEMAS INSERCAO)");

                /*" -2179- DISPLAY 'APOLICE ... ' V0APIN-NUM-APOL */
                _.Display($"APOLICE ... {V0APIN_NUM_APOL}");

                /*" -2180- DISPLAY 'ENDOSSO ... ' V0APIN-NRENDOS */
                _.Display($"ENDOSSO ... {V0APIN_NRENDOS}");

                /*" -2181- DISPLAY 'RISCO ..... ' V0APIN-NUM-RISCO */
                _.Display($"RISCO ..... {V0APIN_NUM_RISCO}");

                /*" -2182- DISPLAY 'ITEM ...... ' V0APIN-NRITEM */
                _.Display($"ITEM ...... {V0APIN_NRITEM}");

                /*" -2184- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2186- ADD +1 TO AC-I-V0APOITENSINC. */
            AREA_DE_WORK.AC_I_V0APOITENSINC.Value = AREA_DE_WORK.AC_I_V0APOITENSINC + +1;

            /*" -2186- PERFORM R2110-00-FETCH-V1PROPINC. */

            R2110_00_FETCH_V1PROPINC_SECTION();

        }

        [StopWatch]
        /*" R2120-00-INSERT-V0APOITENSINC-DB-INSERT-1 */
        public void R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1()
        {
            /*" -2166- EXEC SQL INSERT INTO SEGUROS.V0APOITENSINC VALUES (:V0APIN-COD-EMPRESA , :V0APIN-NUM-APOL , :V0APIN-NRENDOS , :V0APIN-NUM-RISCO , :V0APIN-CODCOBINC , :V0APIN-SUBRIS , :V0APIN-NRITEM , :V0APIN-COD-PLANTA , :V0APIN-COD-RUBRICA , :V0APIN-CLASOCUPA , :V0APIN-CLASCONST , :V0APIN-DTINIVIG , :V0APIN-DTTERVIG , :V0APIN-IMP-SEG-IX , :V0APIN-PRM-TAR-IX , :V0APIN-TIPCOND , :V0APIN-TAXA-PRM , :V0APIN-TIPO-TAXA , :V0APIN-PCDESCON , :V0APIN-TPDESCON , :V0APIN-PCADICIO , :V0APIN-PCVALRISC, :V0APIN-COEFAGRAV, :V0APIN-TIPRAZO , :V0APIN-SITUACAO , CURRENT TIMESTAMP , :V0APIN-TPMOVTO, :V0APIN-TPOCUP, :V0APIN-SPOCUP, :V0APIN-QTPAVTO, :V0APIN-OCORHIST) END-EXEC. */

            var r2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1 = new R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1()
            {
                V0APIN_COD_EMPRESA = V0APIN_COD_EMPRESA.ToString(),
                V0APIN_NUM_APOL = V0APIN_NUM_APOL.ToString(),
                V0APIN_NRENDOS = V0APIN_NRENDOS.ToString(),
                V0APIN_NUM_RISCO = V0APIN_NUM_RISCO.ToString(),
                V0APIN_CODCOBINC = V0APIN_CODCOBINC.ToString(),
                V0APIN_SUBRIS = V0APIN_SUBRIS.ToString(),
                V0APIN_NRITEM = V0APIN_NRITEM.ToString(),
                V0APIN_COD_PLANTA = V0APIN_COD_PLANTA.ToString(),
                V0APIN_COD_RUBRICA = V0APIN_COD_RUBRICA.ToString(),
                V0APIN_CLASOCUPA = V0APIN_CLASOCUPA.ToString(),
                V0APIN_CLASCONST = V0APIN_CLASCONST.ToString(),
                V0APIN_DTINIVIG = V0APIN_DTINIVIG.ToString(),
                V0APIN_DTTERVIG = V0APIN_DTTERVIG.ToString(),
                V0APIN_IMP_SEG_IX = V0APIN_IMP_SEG_IX.ToString(),
                V0APIN_PRM_TAR_IX = V0APIN_PRM_TAR_IX.ToString(),
                V0APIN_TIPCOND = V0APIN_TIPCOND.ToString(),
                V0APIN_TAXA_PRM = V0APIN_TAXA_PRM.ToString(),
                V0APIN_TIPO_TAXA = V0APIN_TIPO_TAXA.ToString(),
                V0APIN_PCDESCON = V0APIN_PCDESCON.ToString(),
                V0APIN_TPDESCON = V0APIN_TPDESCON.ToString(),
                V0APIN_PCADICIO = V0APIN_PCADICIO.ToString(),
                V0APIN_PCVALRISC = V0APIN_PCVALRISC.ToString(),
                V0APIN_COEFAGRAV = V0APIN_COEFAGRAV.ToString(),
                V0APIN_TIPRAZO = V0APIN_TIPRAZO.ToString(),
                V0APIN_SITUACAO = V0APIN_SITUACAO.ToString(),
                V0APIN_TPMOVTO = V0APIN_TPMOVTO.ToString(),
                V0APIN_TPOCUP = V0APIN_TPOCUP.ToString(),
                V0APIN_SPOCUP = V0APIN_SPOCUP.ToString(),
                V0APIN_QTPAVTO = V0APIN_QTPAVTO.ToString(),
                V0APIN_OCORHIST = V0APIN_OCORHIST.ToString(),
            };

            R2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1.Execute(r2120_00_INSERT_V0APOITENSINC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2130-00-UPDATE-V0APOITENSINC-SECTION */
        private void R2130_00_UPDATE_V0APOITENSINC_SECTION()
        {
            /*" -2199- MOVE '213' TO WNR-EXEC-SQL. */
            _.Move("213", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2214- PERFORM R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1 */

            R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1();

            /*" -2217- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2218- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2219- MOVE 1 TO WS-OCORHIST */
                    _.Move(1, AREA_DE_WORK.WS_OCORHIST);

                    /*" -2220- GO TO R2130-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/ //GOTO
                    return;

                    /*" -2221- ELSE */
                }
                else
                {


                    /*" -2230- DISPLAY 'PROBLEMAS NO SELECT (V1APOITENSINC) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V1PRIN-NUM-RISCO ' ' V1PRIN-SUBRIS ' ' V1PRIN-NRITEM ' ' V1PRIN-TIPCOND ' ' V1PRIN-CODCOBINC ' ' V1PRIN-TIPO-TAXA */

                    $"PROBLEMAS NO SELECT (V1APOITENSINC) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V1PRIN_NUM_RISCO} {V1PRIN_SUBRIS} {V1PRIN_NRITEM} {V1PRIN_TIPCOND} {V1PRIN_CODCOBINC} {V1PRIN_TIPO_TAXA}"
                    .Display();

                    /*" -2232- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2246- PERFORM R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1 */

            R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1();

            /*" -2249- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2250- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2251- GO TO R2130-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/ //GOTO
                    return;

                    /*" -2252- ELSE */
                }
                else
                {


                    /*" -2260- DISPLAY 'PROBLEMAS NO UPDATE (V0APOITENSINC) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V1PRIN-NUM-RISCO ' ' V1PRIN-SUBRIS ' ' V1PRIN-NRITEM ' ' V1PRIN-CODCOBINC ' ' V1APIN-OCORHIST */

                    $"PROBLEMAS NO UPDATE (V0APOITENSINC) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V1PRIN_NUM_RISCO} {V1PRIN_SUBRIS} {V1PRIN_NRITEM} {V1PRIN_CODCOBINC} {V1APIN_OCORHIST}"
                    .Display();

                    /*" -2262- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2262- COMPUTE WS-OCORHIST = V1APIN-OCORHIST + 1. */
            AREA_DE_WORK.WS_OCORHIST.Value = V1APIN_OCORHIST + 1;

        }

        [StopWatch]
        /*" R2130-00-UPDATE-V0APOITENSINC-DB-SELECT-1 */
        public void R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1()
        {
            /*" -2214- EXEC SQL SELECT OCORHIST INTO :V1APIN-OCORHIST FROM SEGUROS.V1APOITENSINC WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NUM_RISCO = :V1PRIN-NUM-RISCO AND SUBRIS = :V1PRIN-SUBRIS AND NRITEM = :V1PRIN-NRITEM AND TIPCOND = :V1PRIN-TIPCOND AND TIPO_TAXA = :V1PRIN-TIPO-TAXA AND CODCOBINC = :V1PRIN-CODCOBINC AND SITUACAO = '0' END-EXEC. */

            var r2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1 = new R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1()
            {
                V1PRIN_NUM_RISCO = V1PRIN_NUM_RISCO.ToString(),
                V1PRIN_TIPO_TAXA = V1PRIN_TIPO_TAXA.ToString(),
                V1PRIN_CODCOBINC = V1PRIN_CODCOBINC.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1PRIN_TIPCOND = V1PRIN_TIPCOND.ToString(),
                V1PRIN_SUBRIS = V1PRIN_SUBRIS.ToString(),
                V1PRIN_NRITEM = V1PRIN_NRITEM.ToString(),
            };

            var executed_1 = R2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1.Execute(r2130_00_UPDATE_V0APOITENSINC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1APIN_OCORHIST, V1APIN_OCORHIST);
            }


        }

        [StopWatch]
        /*" R2130-00-UPDATE-V0APOITENSINC-DB-UPDATE-1 */
        public void R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1()
        {
            /*" -2246- EXEC SQL UPDATE SEGUROS.V0APOITENSINC SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NUM_RISCO = :V1PRIN-NUM-RISCO AND SUBRIS = :V1PRIN-SUBRIS AND NRITEM = :V1PRIN-NRITEM AND TIPCOND = :V1PRIN-TIPCOND AND TIPO_TAXA = :V1PRIN-TIPO-TAXA AND CODCOBINC = :V1PRIN-CODCOBINC AND OCORHIST = :V1APIN-OCORHIST AND SITUACAO = '0' END-EXEC. */

            var r2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1 = new R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1()
            {
                V1PRIN_NUM_RISCO = V1PRIN_NUM_RISCO.ToString(),
                V1PRIN_TIPO_TAXA = V1PRIN_TIPO_TAXA.ToString(),
                V1PRIN_CODCOBINC = V1PRIN_CODCOBINC.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1APIN_OCORHIST = V1APIN_OCORHIST.ToString(),
                V1PRIN_TIPCOND = V1PRIN_TIPCOND.ToString(),
                V1PRIN_SUBRIS = V1PRIN_SUBRIS.ToString(),
                V1PRIN_NRITEM = V1PRIN_NRITEM.ToString(),
            };

            R2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1.Execute(r2130_00_UPDATE_V0APOITENSINC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2130_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-DECLARE-V1PROPCLAUS-SECTION */
        private void R2200_00_DECLARE_V1PROPCLAUS_SECTION()
        {
            /*" -2275- MOVE '220' TO WNR-EXEC-SQL. */
            _.Move("220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2292- PERFORM R2200_00_DECLARE_V1PROPCLAUS_DB_DECLARE_1 */

            R2200_00_DECLARE_V1PROPCLAUS_DB_DECLARE_1();

            /*" -2294- PERFORM R2200_00_DECLARE_V1PROPCLAUS_DB_OPEN_1 */

            R2200_00_DECLARE_V1PROPCLAUS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2200-00-DECLARE-V1PROPCLAUS-DB-OPEN-1 */
        public void R2200_00_DECLARE_V1PROPCLAUS_DB_OPEN_1()
        {
            /*" -2294- EXEC SQL OPEN V1PROPCLAUSULA END-EXEC. */

            V1PROPCLAUSULA.Open();

        }

        [StopWatch]
        /*" R2500-00-DECLARE-V1COSSEGSORT-DB-DECLARE-1 */
        public void R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1()
        {
            /*" -2518- EXEC SQL DECLARE V1COSSEGSORT CURSOR FOR SELECT RAMO , CONGENER , PCCOMCOS , PCPARTIC , SITUACAO FROM SEGUROS.V1COSSEGSORT WHERE RAMO = :V1PROP-RAMO ORDER BY CONGENER END-EXEC. */
            V1COSSEGSORT = new EM0006B_V1COSSEGSORT(true);
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
							FROM 
							SEGUROS.V1COSSEGSORT 
							WHERE 
							RAMO = '{V1PROP_RAMO}' 
							ORDER BY 
							CONGENER";

                return query;
            }
            V1COSSEGSORT.GetQueryEvent += GetQuery_V1COSSEGSORT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-INSERT-V0APOLCLAUS-SECTION */
        private void R2210_00_INSERT_V0APOLCLAUS_SECTION()
        {
            /*" -2307- MOVE '221' TO WNR-EXEC-SQL. */
            _.Move("221", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2309- MOVE 11 TO V0APCL-COD-EMPRESA */
            _.Move(11, V0APCL_COD_EMPRESA);

            /*" -2310- MOVE V0ENDO-NUM-APOL TO V0APCL-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APCL_NUM_APOL);

            /*" -2311- MOVE V0ENDO-NRENDOS TO V0APCL-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APCL_NRENDOS);

            /*" -2312- MOVE V1PRCL-RAMOFR TO V0APCL-RAMOFR */
            _.Move(V1PRCL_RAMOFR, V0APCL_RAMOFR);

            /*" -2313- MOVE V1PRCL-MODALIFR TO V0APCL-MODALIFR */
            _.Move(V1PRCL_MODALIFR, V0APCL_MODALIFR);

            /*" -2314- MOVE V1PRCL-CODCOBER TO V0APCL-COD-COBERT */
            _.Move(V1PRCL_CODCOBER, V0APCL_COD_COBERT);

            /*" -2315- MOVE V1PRCL-DTINIVIG TO V0APCL-DTINIVIG */
            _.Move(V1PRCL_DTINIVIG, V0APCL_DTINIVIG);

            /*" -2316- MOVE V1PRCL-DTTERVIG TO V0APCL-DTTERVIG */
            _.Move(V1PRCL_DTTERVIG, V0APCL_DTTERVIG);

            /*" -2317- MOVE V1PRCL-NRITEM TO V0APCL-NRITEM */
            _.Move(V1PRCL_NRITEM, V0APCL_NRITEM);

            /*" -2318- MOVE V1PRCL-CODCLAUS TO V0APCL-CODCLAUS */
            _.Move(V1PRCL_CODCLAUS, V0APCL_CODCLAUS);

            /*" -2319- MOVE V1PRCL-TIPOCLAU TO V0APCL-TIPOCLAU */
            _.Move(V1PRCL_TIPOCLAU, V0APCL_TIPOCLAU);

            /*" -2321- MOVE V1PRCL-LIM-IND-IX TO V0APCL-LIM-IND-IX */
            _.Move(V1PRCL_LIM_IND_IX, V0APCL_LIM_IND_IX);

            /*" -2336- PERFORM R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1 */

            R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1();

            /*" -2339- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2340- DISPLAY 'R2210 - V0APOLCLAUSULAS (REGISTRO DUPLICADO)' */
                _.Display($"R2210 - V0APOLCLAUSULAS (REGISTRO DUPLICADO)");

                /*" -2341- DISPLAY ' ' V0ENDO-NUM-APOL */
                _.Display($" {V0ENDO_NUM_APOL}");

                /*" -2342- DISPLAY ' ' V0ENDO-NRENDOS */
                _.Display($" {V0ENDO_NRENDOS}");

                /*" -2343- DISPLAY ' ' V1PRCL-RAMOFR */
                _.Display($" {V1PRCL_RAMOFR}");

                /*" -2344- DISPLAY ' ' V1PRCL-MODALIFR */
                _.Display($" {V1PRCL_MODALIFR}");

                /*" -2345- DISPLAY ' ' V1PRCL-CODCOBER */
                _.Display($" {V1PRCL_CODCOBER}");

                /*" -2346- DISPLAY ' ' V1PRCL-DTINIVIG */
                _.Display($" {V1PRCL_DTINIVIG}");

                /*" -2347- DISPLAY ' ' V1PRCL-DTTERVIG */
                _.Display($" {V1PRCL_DTTERVIG}");

                /*" -2348- DISPLAY ' ' V1PRCL-NRITEM */
                _.Display($" {V1PRCL_NRITEM}");

                /*" -2349- DISPLAY ' ' V1PRCL-CODCLAUS */
                _.Display($" {V1PRCL_CODCLAUS}");

                /*" -2351- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2352- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2353- DISPLAY 'R2210 - V0APOLCLAUSULAS (PROBLEMAS INSERCAO)' */
                _.Display($"R2210 - V0APOLCLAUSULAS (PROBLEMAS INSERCAO)");

                /*" -2354- DISPLAY ' ' V0ENDO-NUM-APOL */
                _.Display($" {V0ENDO_NUM_APOL}");

                /*" -2355- DISPLAY ' ' V0ENDO-NRENDOS */
                _.Display($" {V0ENDO_NRENDOS}");

                /*" -2356- DISPLAY ' ' V1PRCL-RAMOFR */
                _.Display($" {V1PRCL_RAMOFR}");

                /*" -2357- DISPLAY ' ' V1PRCL-MODALIFR */
                _.Display($" {V1PRCL_MODALIFR}");

                /*" -2358- DISPLAY ' ' V1PRCL-CODCOBER */
                _.Display($" {V1PRCL_CODCOBER}");

                /*" -2359- DISPLAY ' ' V1PRCL-DTINIVIG */
                _.Display($" {V1PRCL_DTINIVIG}");

                /*" -2360- DISPLAY ' ' V1PRCL-DTTERVIG */
                _.Display($" {V1PRCL_DTTERVIG}");

                /*" -2361- DISPLAY ' ' V1PRCL-NRITEM */
                _.Display($" {V1PRCL_NRITEM}");

                /*" -2362- DISPLAY ' ' V1PRCL-CODCLAUS */
                _.Display($" {V1PRCL_CODCLAUS}");

                /*" -2364- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2366- ADD +1 TO AC-I-V0APOLCLAUS. */
            AREA_DE_WORK.AC_I_V0APOLCLAUS.Value = AREA_DE_WORK.AC_I_V0APOLCLAUS + +1;

            /*" -2366- PERFORM R2220-00-FETCH-V1PROPCLAUS. */

            R2220_00_FETCH_V1PROPCLAUS_SECTION();

        }

        [StopWatch]
        /*" R2210-00-INSERT-V0APOLCLAUS-DB-INSERT-1 */
        public void R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1()
        {
            /*" -2336- EXEC SQL INSERT INTO SEGUROS.V0APOLCLAUSULA VALUES (:V0APCL-COD-EMPRESA, :V0APCL-NUM-APOL , :V0APCL-NRENDOS , :V0APCL-RAMOFR , :V0APCL-MODALIFR , :V0APCL-COD-COBERT , :V0APCL-DTINIVIG , :V0APCL-DTTERVIG , :V0APCL-NRITEM , :V0APCL-CODCLAUS , :V0APCL-TIPOCLAU , :V0APCL-LIM-IND-IX , CURRENT TIMESTAMP) END-EXEC. */

            var r2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1 = new R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1()
            {
                V0APCL_COD_EMPRESA = V0APCL_COD_EMPRESA.ToString(),
                V0APCL_NUM_APOL = V0APCL_NUM_APOL.ToString(),
                V0APCL_NRENDOS = V0APCL_NRENDOS.ToString(),
                V0APCL_RAMOFR = V0APCL_RAMOFR.ToString(),
                V0APCL_MODALIFR = V0APCL_MODALIFR.ToString(),
                V0APCL_COD_COBERT = V0APCL_COD_COBERT.ToString(),
                V0APCL_DTINIVIG = V0APCL_DTINIVIG.ToString(),
                V0APCL_DTTERVIG = V0APCL_DTTERVIG.ToString(),
                V0APCL_NRITEM = V0APCL_NRITEM.ToString(),
                V0APCL_CODCLAUS = V0APCL_CODCLAUS.ToString(),
                V0APCL_TIPOCLAU = V0APCL_TIPOCLAU.ToString(),
                V0APCL_LIM_IND_IX = V0APCL_LIM_IND_IX.ToString(),
            };

            R2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1.Execute(r2210_00_INSERT_V0APOLCLAUS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-FETCH-V1PROPCLAUS-SECTION */
        private void R2220_00_FETCH_V1PROPCLAUS_SECTION()
        {
            /*" -2379- MOVE '222' TO WNR-EXEC-SQL. */
            _.Move("222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2392- PERFORM R2220_00_FETCH_V1PROPCLAUS_DB_FETCH_1 */

            R2220_00_FETCH_V1PROPCLAUS_DB_FETCH_1();

            /*" -2395- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2396- MOVE 'S' TO WFIM-V1PROPCLAUS */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPCLAUS);

                /*" -2396- PERFORM R2220_00_FETCH_V1PROPCLAUS_DB_CLOSE_1 */

                R2220_00_FETCH_V1PROPCLAUS_DB_CLOSE_1();

                /*" -2399- GO TO R2220-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2399- ADD +1 TO AC-L-V1PROPCLAUS. */
            AREA_DE_WORK.AC_L_V1PROPCLAUS.Value = AREA_DE_WORK.AC_L_V1PROPCLAUS + +1;

        }

        [StopWatch]
        /*" R2220-00-FETCH-V1PROPCLAUS-DB-FETCH-1 */
        public void R2220_00_FETCH_V1PROPCLAUS_DB_FETCH_1()
        {
            /*" -2392- EXEC SQL FETCH V1PROPCLAUSULA INTO :V1PRCL-COD-EMPRESA, :V1PRCL-FONTE, :V1PRCL-NRPROPOS, :V1PRCL-RAMOFR, :V1PRCL-MODALIFR, :V1PRCL-CODCOBER, :V1PRCL-DTINIVIG , :V1PRCL-DTTERVIG , :V1PRCL-NRITEM, :V1PRCL-CODCLAUS, :V1PRCL-LIM-IND-IX, :V1PRCL-TIPOCLAU END-EXEC. */

            if (V1PROPCLAUSULA.Fetch())
            {
                _.Move(V1PROPCLAUSULA.V1PRCL_COD_EMPRESA, V1PRCL_COD_EMPRESA);
                _.Move(V1PROPCLAUSULA.V1PRCL_FONTE, V1PRCL_FONTE);
                _.Move(V1PROPCLAUSULA.V1PRCL_NRPROPOS, V1PRCL_NRPROPOS);
                _.Move(V1PROPCLAUSULA.V1PRCL_RAMOFR, V1PRCL_RAMOFR);
                _.Move(V1PROPCLAUSULA.V1PRCL_MODALIFR, V1PRCL_MODALIFR);
                _.Move(V1PROPCLAUSULA.V1PRCL_CODCOBER, V1PRCL_CODCOBER);
                _.Move(V1PROPCLAUSULA.V1PRCL_DTINIVIG, V1PRCL_DTINIVIG);
                _.Move(V1PROPCLAUSULA.V1PRCL_DTTERVIG, V1PRCL_DTTERVIG);
                _.Move(V1PROPCLAUSULA.V1PRCL_NRITEM, V1PRCL_NRITEM);
                _.Move(V1PROPCLAUSULA.V1PRCL_CODCLAUS, V1PRCL_CODCLAUS);
                _.Move(V1PROPCLAUSULA.V1PRCL_LIM_IND_IX, V1PRCL_LIM_IND_IX);
                _.Move(V1PROPCLAUSULA.V1PRCL_TIPOCLAU, V1PRCL_TIPOCLAU);
            }

        }

        [StopWatch]
        /*" R2220-00-FETCH-V1PROPCLAUS-DB-CLOSE-1 */
        public void R2220_00_FETCH_V1PROPCLAUS_DB_CLOSE_1()
        {
            /*" -2396- EXEC SQL CLOSE V1PROPCLAUSULA END-EXEC */

            V1PROPCLAUSULA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-PROCESSA-ENDOSSO-SECTION */
        private void R2300_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -2412- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2414- MOVE SPACES TO WFIM-V1PROPLOCINC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPLOCINC);

            /*" -2415- PERFORM R2050-00-DECLARE-V1PROPLOCINC */

            R2050_00_DECLARE_V1PROPLOCINC_SECTION();

            /*" -2416- PERFORM R2051-00-FETCH-V1PROPLOCINC */

            R2051_00_FETCH_V1PROPLOCINC_SECTION();

            /*" -2417- IF WFIM-V1PROPLOCINC EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1PROPLOCINC.IsEmpty())
            {

                /*" -2420- PERFORM R2052-00-INSERT-V0APOLOCALINC UNTIL WFIM-V1PROPLOCINC NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_V1PROPLOCINC.IsEmpty()))
                {

                    R2052_00_INSERT_V0APOLOCALINC_SECTION();
                }

                /*" -2422- PERFORM R5550-00-UPDATE-V0PROPLOCINC. */

                R5550_00_UPDATE_V0PROPLOCINC_SECTION();
            }


            /*" -2424- MOVE SPACES TO WFIM-V1PROPINC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPINC);

            /*" -2425- PERFORM R2100-00-DECLARE-V1PROPINC */

            R2100_00_DECLARE_V1PROPINC_SECTION();

            /*" -2426- PERFORM R2110-00-FETCH-V1PROPINC */

            R2110_00_FETCH_V1PROPINC_SECTION();

            /*" -2427- IF WFIM-V1PROPINC EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1PROPINC.IsEmpty())
            {

                /*" -2430- PERFORM R2120-00-INSERT-V0APOITENSINC UNTIL WFIM-V1PROPINC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPINC.IsEmpty()))
                {

                    R2120_00_INSERT_V0APOITENSINC_SECTION();
                }
            }


            /*" -2431- MOVE SPACES TO WFIM-V1PROPCLAUS */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPCLAUS);

            /*" -2432- PERFORM R2200-00-DECLARE-V1PROPCLAUS */

            R2200_00_DECLARE_V1PROPCLAUS_SECTION();

            /*" -2433- PERFORM R2220-00-FETCH-V1PROPCLAUS */

            R2220_00_FETCH_V1PROPCLAUS_SECTION();

            /*" -2435- IF WFIM-V1PROPCLAUS NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPCLAUS.IsEmpty())
            {

                /*" -2436- ELSE */
            }
            else
            {


                /*" -2439- PERFORM R2210-00-INSERT-V0APOLCLAUS UNTIL WFIM-V1PROPCLAUS NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPCLAUS.IsEmpty()))
                {

                    R2210_00_INSERT_V0APOLCLAUS_SECTION();
                }
            }


            /*" -2440- MOVE ZEROS TO W0COBA-IMP-SEG-IX */
            _.Move(0, W0COBA_IMP_SEG_IX);

            /*" -2441- MOVE ZEROS TO W0COBA-PRM-TAR-IX */
            _.Move(0, W0COBA_PRM_TAR_IX);

            /*" -2442- MOVE ZEROS TO W0COBA-IMP-SEG-VR */
            _.Move(0, W0COBA_IMP_SEG_VR);

            /*" -2443- MOVE ZEROS TO W0COBA-PRM-TAR-VR */
            _.Move(0, W0COBA_PRM_TAR_VR);

            /*" -2445- MOVE ZEROS TO WS-NUM-ITEM */
            _.Move(0, AREA_DE_WORK.WS_NUM_ITEM);

            /*" -2446- MOVE ZEROS TO W1COBP-PRM-TAR-IX */
            _.Move(0, W1COBP_PRM_TAR_IX);

            /*" -2448- MOVE ZEROS TO W1COBP-PCT-TOTAL */
            _.Move(0, W1COBP_PCT_TOTAL);

            /*" -2449- MOVE SPACES TO WFIM-V1COBPROPINC */
            _.Move("", AREA_DE_WORK.WFIM_V1COBPROPINC);

            /*" -2450- PERFORM R3600-00-DECLARE-V1COBPROPINC */

            R3600_00_DECLARE_V1COBPROPINC_SECTION();

            /*" -2451- PERFORM R3610-00-FETCH-V1COBPROPINC */

            R3610_00_FETCH_V1COBPROPINC_SECTION();

            /*" -2452- IF WFIM-V1COBPROPINC EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1COBPROPINC.IsEmpty())
            {

                /*" -2455- PERFORM R3800-00-MONTA-V0COBERINC UNTIL WFIM-V1COBPROPINC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1COBPROPINC.IsEmpty()))
                {

                    R3800_00_MONTA_V0COBERINC_SECTION();
                }
            }


            /*" -2456- MOVE SPACES TO WFIM-V1PROPDESINC */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPDESINC);

            /*" -2457- PERFORM R2600-00-DECLARE-V1PROPDESINC */

            R2600_00_DECLARE_V1PROPDESINC_SECTION();

            /*" -2458- PERFORM R2610-00-FETCH-V1PROPDESINC */

            R2610_00_FETCH_V1PROPDESINC_SECTION();

            /*" -2460- IF WFIM-V1PROPDESINC NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPDESINC.IsEmpty())
            {

                /*" -2461- ELSE */
            }
            else
            {


                /*" -2464- PERFORM R2700-00-INSERT-V0APODESITEM UNTIL WFIM-V1PROPDESINC NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPDESINC.IsEmpty()))
                {

                    R2700_00_INSERT_V0APODESITEM_SECTION();
                }
            }


            /*" -2465- MOVE SPACES TO WFIM-V1PROPDESCO */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPDESCO);

            /*" -2466- PERFORM R2800-00-DECLARE-V1PROPDESCO */

            R2800_00_DECLARE_V1PROPDESCO_SECTION();

            /*" -2467- PERFORM R2810-00-FETCH-V1PROPDESCO */

            R2810_00_FETCH_V1PROPDESCO_SECTION();

            /*" -2469- IF WFIM-V1PROPDESCO NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPDESCO.IsEmpty())
            {

                /*" -2470- ELSE */
            }
            else
            {


                /*" -2473- PERFORM R2850-00-INSERT-V0APOLDESCO UNTIL WFIM-V1PROPDESCO NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPDESCO.IsEmpty()))
                {

                    R2850_00_INSERT_V0APOLDESCO_SECTION();
                }
            }


            /*" -2475- PERFORM R5700-00-UPDATE-V0PROPDESCO */

            R5700_00_UPDATE_V0PROPDESCO_SECTION();

            /*" -2476- MOVE SPACES TO WFIM-V1PROPOUTR */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPOUTR);

            /*" -2477- PERFORM R2860-00-DECLARE-V1PROPOUTR */

            R2860_00_DECLARE_V1PROPOUTR_SECTION();

            /*" -2478- PERFORM R2870-00-FETCH-V1PROPOUTR */

            R2870_00_FETCH_V1PROPOUTR_SECTION();

            /*" -2480- IF WFIM-V1PROPOUTR NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPOUTR.IsEmpty())
            {

                /*" -2481- ELSE */
            }
            else
            {


                /*" -2484- PERFORM R2880-00-INSERT-V0APOLOUTR UNTIL WFIM-V1PROPOUTR NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPOUTR.IsEmpty()))
                {

                    R2880_00_INSERT_V0APOLOUTR_SECTION();
                }
            }


            /*" -2485- MOVE SPACES TO WFIM-V1PROPDCOB */
            _.Move("", AREA_DE_WORK.WFIM_V1PROPDCOB);

            /*" -2486- PERFORM R2900-00-DECLARE-V1PROPDCOB */

            R2900_00_DECLARE_V1PROPDCOB_SECTION();

            /*" -2487- PERFORM R2910-00-FETCH-V1PROPDCOB */

            R2910_00_FETCH_V1PROPDCOB_SECTION();

            /*" -2489- IF WFIM-V1PROPDCOB NOT EQUAL SPACES NEXT SENTENCE */

            if (!AREA_DE_WORK.WFIM_V1PROPDCOB.IsEmpty())
            {

                /*" -2490- ELSE */
            }
            else
            {


                /*" -2493- PERFORM R2950-00-INSERT-V0APOLDCOB UNTIL WFIM-V1PROPDCOB NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_V1PROPDCOB.IsEmpty()))
                {

                    R2950_00_INSERT_V0APOLDCOB_SECTION();
                }
            }


            /*" -2493- PERFORM R5800-00-UPDATE-V0PROPDCOB. */

            R5800_00_UPDATE_V0PROPDCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-DECLARE-V1COSSEGSORT-SECTION */
        private void R2500_00_DECLARE_V1COSSEGSORT_SECTION()
        {
            /*" -2506- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2518- PERFORM R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1 */

            R2500_00_DECLARE_V1COSSEGSORT_DB_DECLARE_1();

            /*" -2520- PERFORM R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1 */

            R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2500-00-DECLARE-V1COSSEGSORT-DB-OPEN-1 */
        public void R2500_00_DECLARE_V1COSSEGSORT_DB_OPEN_1()
        {
            /*" -2520- EXEC SQL OPEN V1COSSEGSORT END-EXEC. */

            V1COSSEGSORT.Open();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-V1PROPDESINC-DB-DECLARE-1 */
        public void R2600_00_DECLARE_V1PROPDESINC_DB_DECLARE_1()
        {
            /*" -2579- EXEC SQL DECLARE V1PROPDESINC CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NUM_RISCO , NRITEM , COD_PLANTA , NRLINHA , DESCR_LINHA FROM SEGUROS.V1PROPDESCR_INC WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY NUM_RISCO , NRITEM , COD_PLANTA , NRLINHA END-EXEC. */
            V1PROPDESINC = new EM0006B_V1PROPDESINC(true);
            string GetQuery_V1PROPDESINC()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NUM_RISCO
							, 
							NRITEM
							, 
							COD_PLANTA
							, 
							NRLINHA
							, 
							DESCR_LINHA 
							FROM 
							SEGUROS.V1PROPDESCR_INC 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY 
							NUM_RISCO
							, 
							NRITEM
							, 
							COD_PLANTA
							, 
							NRLINHA";

                return query;
            }
            V1PROPDESINC.GetQueryEvent += GetQuery_V1PROPDESINC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-FETCH-V1COSSEGSORT-SECTION */
        private void R2510_00_FETCH_V1COSSEGSORT_SECTION()
        {
            /*" -2533- MOVE '251' TO WNR-EXEC-SQL. */
            _.Move("251", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2539- PERFORM R2510_00_FETCH_V1COSSEGSORT_DB_FETCH_1 */

            R2510_00_FETCH_V1COSSEGSORT_DB_FETCH_1();

            /*" -2542- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2543- MOVE 'S' TO WFIM-V1PROPCOSCED */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPCOSCED);

                /*" -2543- PERFORM R2510_00_FETCH_V1COSSEGSORT_DB_CLOSE_1 */

                R2510_00_FETCH_V1COSSEGSORT_DB_CLOSE_1();

                /*" -2546- GO TO R2510-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2547- ADD V1COSS-PCPARTIC TO W0APOL-PCTCED */
            W0APOL_PCTCED.Value = W0APOL_PCTCED + V1COSS_PCPARTIC;

            /*" -2547- ADD +1 TO W0APOL-QTCOSSEG. */
            W0APOL_QTCOSSEG.Value = W0APOL_QTCOSSEG + +1;

        }

        [StopWatch]
        /*" R2510-00-FETCH-V1COSSEGSORT-DB-FETCH-1 */
        public void R2510_00_FETCH_V1COSSEGSORT_DB_FETCH_1()
        {
            /*" -2539- EXEC SQL FETCH V1COSSEGSORT INTO :V1COSS-RAMO , :V1COSS-CONGENER , :V1COSS-PCCOMCOS , :V1COSS-PCPARTIC , :V1COSS-SITUACAO END-EXEC. */

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
        /*" R2510-00-FETCH-V1COSSEGSORT-DB-CLOSE-1 */
        public void R2510_00_FETCH_V1COSSEGSORT_DB_CLOSE_1()
        {
            /*" -2543- EXEC SQL CLOSE V1COSSEGSORT END-EXEC */

            V1COSSEGSORT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-DECLARE-V1PROPDESINC-SECTION */
        private void R2600_00_DECLARE_V1PROPDESINC_SECTION()
        {
            /*" -2560- MOVE '260' TO WNR-EXEC-SQL. */
            _.Move("260", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2579- PERFORM R2600_00_DECLARE_V1PROPDESINC_DB_DECLARE_1 */

            R2600_00_DECLARE_V1PROPDESINC_DB_DECLARE_1();

            /*" -2581- PERFORM R2600_00_DECLARE_V1PROPDESINC_DB_OPEN_1 */

            R2600_00_DECLARE_V1PROPDESINC_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2600-00-DECLARE-V1PROPDESINC-DB-OPEN-1 */
        public void R2600_00_DECLARE_V1PROPDESINC_DB_OPEN_1()
        {
            /*" -2581- EXEC SQL OPEN V1PROPDESINC END-EXEC. */

            V1PROPDESINC.Open();

        }

        [StopWatch]
        /*" R2800-00-DECLARE-V1PROPDESCO-DB-DECLARE-1 */
        public void R2800_00_DECLARE_V1PROPDESCO_DB_DECLARE_1()
        {
            /*" -2706- EXEC SQL DECLARE V1PROPDESCO CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NUM_RISCO , SUBRIS , NRITEM , COD_PLANTA , PCDESPRT , TPDESCON , PCDESTAR , DESCRDESCON FROM SEGUROS.V1PROPINCDESC WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS AND SITUACAO IN ( ' ' , '0' ) ORDER BY NUM_RISCO , SUBRIS , NRITEM , COD_PLANTA END-EXEC. */
            V1PROPDESCO = new EM0006B_V1PROPDESCO(true);
            string GetQuery_V1PROPDESCO()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NUM_RISCO
							, 
							SUBRIS
							, 
							NRITEM
							, 
							COD_PLANTA
							, 
							PCDESPRT
							, 
							TPDESCON
							, 
							PCDESTAR
							, 
							DESCRDESCON 
							FROM 
							SEGUROS.V1PROPINCDESC 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							AND SITUACAO IN ( ' '
							, '0' ) 
							ORDER BY 
							NUM_RISCO
							, 
							SUBRIS
							, 
							NRITEM
							, 
							COD_PLANTA";

                return query;
            }
            V1PROPDESCO.GetQueryEvent += GetQuery_V1PROPDESCO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2610-00-FETCH-V1PROPDESINC-SECTION */
        private void R2610_00_FETCH_V1PROPDESINC_SECTION()
        {
            /*" -2594- MOVE '261' TO WNR-EXEC-SQL. */
            _.Move("261", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2603- PERFORM R2610_00_FETCH_V1PROPDESINC_DB_FETCH_1 */

            R2610_00_FETCH_V1PROPDESINC_DB_FETCH_1();

            /*" -2606- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2607- MOVE 'S' TO WFIM-V1PROPDESINC */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPDESINC);

                /*" -2607- PERFORM R2610_00_FETCH_V1PROPDESINC_DB_CLOSE_1 */

                R2610_00_FETCH_V1PROPDESINC_DB_CLOSE_1();

                /*" -2610- GO TO R2610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2610- ADD +1 TO AC-L-V1PROPDESINC. */
            AREA_DE_WORK.AC_L_V1PROPDESINC.Value = AREA_DE_WORK.AC_L_V1PROPDESINC + +1;

        }

        [StopWatch]
        /*" R2610-00-FETCH-V1PROPDESINC-DB-FETCH-1 */
        public void R2610_00_FETCH_V1PROPDESINC_DB_FETCH_1()
        {
            /*" -2603- EXEC SQL FETCH V1PROPDESINC INTO :V1PRDI-COD-EMPRESA , :V1PRDI-FONTE , :V1PRDI-NRPROPOS , :V1PRDI-NUM-RISCO , :V1PRDI-NRITEM , :V1PRDI-COD-PLANTA , :V1PRDI-NRLINHA , :V1PRDI-DESC-LINHA END-EXEC. */

            if (V1PROPDESINC.Fetch())
            {
                _.Move(V1PROPDESINC.V1PRDI_COD_EMPRESA, V1PRDI_COD_EMPRESA);
                _.Move(V1PROPDESINC.V1PRDI_FONTE, V1PRDI_FONTE);
                _.Move(V1PROPDESINC.V1PRDI_NRPROPOS, V1PRDI_NRPROPOS);
                _.Move(V1PROPDESINC.V1PRDI_NUM_RISCO, V1PRDI_NUM_RISCO);
                _.Move(V1PROPDESINC.V1PRDI_NRITEM, V1PRDI_NRITEM);
                _.Move(V1PROPDESINC.V1PRDI_COD_PLANTA, V1PRDI_COD_PLANTA);
                _.Move(V1PROPDESINC.V1PRDI_NRLINHA, V1PRDI_NRLINHA);
                _.Move(V1PROPDESINC.V1PRDI_DESC_LINHA, V1PRDI_DESC_LINHA);
            }

        }

        [StopWatch]
        /*" R2610-00-FETCH-V1PROPDESINC-DB-CLOSE-1 */
        public void R2610_00_FETCH_V1PROPDESINC_DB_CLOSE_1()
        {
            /*" -2607- EXEC SQL CLOSE V1PROPDESINC END-EXEC */

            V1PROPDESINC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2610_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-INSERT-V0APODESITEM-SECTION */
        private void R2700_00_INSERT_V0APODESITEM_SECTION()
        {
            /*" -2624- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2625- MOVE 11 TO V0APDI-COD-EMPRESA */
            _.Move(11, V0APDI_COD_EMPRESA);

            /*" -2626- MOVE V0ENDO-NUM-APOL TO V0APDI-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APDI_NUM_APOL);

            /*" -2627- MOVE V0ENDO-NRENDOS TO V0APDI-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APDI_NRENDOS);

            /*" -2628- MOVE V1PRDI-NUM-RISCO TO V0APDI-NUM-RISCO */
            _.Move(V1PRDI_NUM_RISCO, V0APDI_NUM_RISCO);

            /*" -2629- MOVE V1PRDI-NRITEM TO V0APDI-NRITEM */
            _.Move(V1PRDI_NRITEM, V0APDI_NRITEM);

            /*" -2630- MOVE V1PRDI-COD-PLANTA TO V0APDI-COD-PLANTA */
            _.Move(V1PRDI_COD_PLANTA, V0APDI_COD_PLANTA);

            /*" -2631- MOVE V1PRDI-NRLINHA TO V0APDI-NRLINHA */
            _.Move(V1PRDI_NRLINHA, V0APDI_NRLINHA);

            /*" -2632- MOVE V1PRDI-DESC-LINHA TO V0APDI-DESC-LINHA */
            _.Move(V1PRDI_DESC_LINHA, V0APDI_DESC_LINHA);

            /*" -2633- MOVE V0ENDO-DTINIVIG TO V0APDI-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APDI_DTINIVIG);

            /*" -2634- MOVE V0ENDO-DTTERVIG TO V0APDI-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APDI_DTTERVIG);

            /*" -2636- MOVE 1 TO V0APDI-OCORHIST */
            _.Move(1, V0APDI_OCORHIST);

            /*" -2650- PERFORM R2700_00_INSERT_V0APODESITEM_DB_INSERT_1 */

            R2700_00_INSERT_V0APODESITEM_DB_INSERT_1();

            /*" -2653- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2658- DISPLAY 'R2700-00 (REGISTRO DUPLICADO) ... ' ' ' V0APDI-NUM-APOL ' ' V0APDI-NRENDOS ' ' V0APDI-NUM-RISCO ' ' V0APDI-NRITEM */

                $"R2700-00 (REGISTRO DUPLICADO) ...  {V0APDI_NUM_APOL} {V0APDI_NRENDOS} {V0APDI_NUM_RISCO} {V0APDI_NRITEM}"
                .Display();

                /*" -2660- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2661- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2666- DISPLAY 'R2700-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0APDI-NUM-APOL ' ' V0APDI-NRENDOS ' ' V0APDI-NUM-RISCO ' ' V0APDI-NRITEM */

                $"R2700-00 (PROBLEMAS NA INSERCAO) ...  {V0APDI_NUM_APOL} {V0APDI_NRENDOS} {V0APDI_NUM_RISCO} {V0APDI_NRITEM}"
                .Display();

                /*" -2668- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2670- ADD +1 TO AC-I-V0APODESITEM */
            AREA_DE_WORK.AC_I_V0APODESITEM.Value = AREA_DE_WORK.AC_I_V0APODESITEM + +1;

            /*" -2670- PERFORM R2610-00-FETCH-V1PROPDESINC. */

            R2610_00_FETCH_V1PROPDESINC_SECTION();

        }

        [StopWatch]
        /*" R2700-00-INSERT-V0APODESITEM-DB-INSERT-1 */
        public void R2700_00_INSERT_V0APODESITEM_DB_INSERT_1()
        {
            /*" -2650- EXEC SQL INSERT INTO SEGUROS.V0APODESITEM VALUES (:V0APDI-COD-EMPRESA , :V0APDI-NUM-APOL , :V0APDI-NRENDOS , :V0APDI-NUM-RISCO , :V0APDI-NRITEM , :V0APDI-COD-PLANTA , :V0APDI-NRLINHA , :V0APDI-DESC-LINHA , :V0APDI-DTINIVIG , :V0APDI-DTTERVIG , CURRENT TIMESTAMP , :V0APDI-OCORHIST) END-EXEC. */

            var r2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1 = new R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1()
            {
                V0APDI_COD_EMPRESA = V0APDI_COD_EMPRESA.ToString(),
                V0APDI_NUM_APOL = V0APDI_NUM_APOL.ToString(),
                V0APDI_NRENDOS = V0APDI_NRENDOS.ToString(),
                V0APDI_NUM_RISCO = V0APDI_NUM_RISCO.ToString(),
                V0APDI_NRITEM = V0APDI_NRITEM.ToString(),
                V0APDI_COD_PLANTA = V0APDI_COD_PLANTA.ToString(),
                V0APDI_NRLINHA = V0APDI_NRLINHA.ToString(),
                V0APDI_DESC_LINHA = V0APDI_DESC_LINHA.ToString(),
                V0APDI_DTINIVIG = V0APDI_DTINIVIG.ToString(),
                V0APDI_DTTERVIG = V0APDI_DTTERVIG.ToString(),
                V0APDI_OCORHIST = V0APDI_OCORHIST.ToString(),
            };

            R2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1.Execute(r2700_00_INSERT_V0APODESITEM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-DECLARE-V1PROPDESCO-SECTION */
        private void R2800_00_DECLARE_V1PROPDESCO_SECTION()
        {
            /*" -2683- MOVE '280' TO WNR-EXEC-SQL. */
            _.Move("280", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2706- PERFORM R2800_00_DECLARE_V1PROPDESCO_DB_DECLARE_1 */

            R2800_00_DECLARE_V1PROPDESCO_DB_DECLARE_1();

            /*" -2708- PERFORM R2800_00_DECLARE_V1PROPDESCO_DB_OPEN_1 */

            R2800_00_DECLARE_V1PROPDESCO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2800-00-DECLARE-V1PROPDESCO-DB-OPEN-1 */
        public void R2800_00_DECLARE_V1PROPDESCO_DB_OPEN_1()
        {
            /*" -2708- EXEC SQL OPEN V1PROPDESCO END-EXEC. */

            V1PROPDESCO.Open();

        }

        [StopWatch]
        /*" R2860-00-DECLARE-V1PROPOUTR-DB-DECLARE-1 */
        public void R2860_00_DECLARE_V1PROPOUTR_DB_DECLARE_1()
        {
            /*" -2831- EXEC SQL DECLARE V1PROPOUTR CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , APOLIDER , CODLIDER , IMP_SEGURADA_IX FROM SEGUROS.V1PROPOUTINC WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY CODLIDER END-EXEC. */
            V1PROPOUTR = new EM0006B_V1PROPOUTR(true);
            string GetQuery_V1PROPOUTR()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							APOLIDER
							, 
							CODLIDER
							, 
							IMP_SEGURADA_IX 
							FROM 
							SEGUROS.V1PROPOUTINC 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY 
							CODLIDER";

                return query;
            }
            V1PROPOUTR.GetQueryEvent += GetQuery_V1PROPOUTR;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2810-00-FETCH-V1PROPDESCO-SECTION */
        private void R2810_00_FETCH_V1PROPDESCO_SECTION()
        {
            /*" -2719- MOVE '281' TO WNR-EXEC-SQL. */
            _.Move("281", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2731- PERFORM R2810_00_FETCH_V1PROPDESCO_DB_FETCH_1 */

            R2810_00_FETCH_V1PROPDESCO_DB_FETCH_1();

            /*" -2734- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2735- MOVE 'S' TO WFIM-V1PROPDESCO */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPDESCO);

                /*" -2735- PERFORM R2810_00_FETCH_V1PROPDESCO_DB_CLOSE_1 */

                R2810_00_FETCH_V1PROPDESCO_DB_CLOSE_1();

                /*" -2738- GO TO R2810-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2810_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2738- ADD +1 TO AC-L-V1PROPDESCO. */
            AREA_DE_WORK.AC_L_V1PROPDESCO.Value = AREA_DE_WORK.AC_L_V1PROPDESCO + +1;

        }

        [StopWatch]
        /*" R2810-00-FETCH-V1PROPDESCO-DB-FETCH-1 */
        public void R2810_00_FETCH_V1PROPDESCO_DB_FETCH_1()
        {
            /*" -2731- EXEC SQL FETCH V1PROPDESCO INTO :V1PIND-COD-EMPRESA , :V1PIND-FONTE , :V1PIND-NRPROPOS , :V1PIND-NUM-RISCO , :V1PIND-SUBRIS , :V1PIND-NRITEM , :V1PIND-PLANTA , :V1PIND-PCDESPRT , :V1PIND-TPDESCON , :V1PIND-PCDESTAR , :V1PIND-DESCDESCON END-EXEC. */

            if (V1PROPDESCO.Fetch())
            {
                _.Move(V1PROPDESCO.V1PIND_COD_EMPRESA, V1PIND_COD_EMPRESA);
                _.Move(V1PROPDESCO.V1PIND_FONTE, V1PIND_FONTE);
                _.Move(V1PROPDESCO.V1PIND_NRPROPOS, V1PIND_NRPROPOS);
                _.Move(V1PROPDESCO.V1PIND_NUM_RISCO, V1PIND_NUM_RISCO);
                _.Move(V1PROPDESCO.V1PIND_SUBRIS, V1PIND_SUBRIS);
                _.Move(V1PROPDESCO.V1PIND_NRITEM, V1PIND_NRITEM);
                _.Move(V1PROPDESCO.V1PIND_PLANTA, V1PIND_PLANTA);
                _.Move(V1PROPDESCO.V1PIND_PCDESPRT, V1PIND_PCDESPRT);
                _.Move(V1PROPDESCO.V1PIND_TPDESCON, V1PIND_TPDESCON);
                _.Move(V1PROPDESCO.V1PIND_PCDESTAR, V1PIND_PCDESTAR);
                _.Move(V1PROPDESCO.V1PIND_DESCDESCON, V1PIND_DESCDESCON);
            }

        }

        [StopWatch]
        /*" R2810-00-FETCH-V1PROPDESCO-DB-CLOSE-1 */
        public void R2810_00_FETCH_V1PROPDESCO_DB_CLOSE_1()
        {
            /*" -2735- EXEC SQL CLOSE V1PROPDESCO END-EXEC */

            V1PROPDESCO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2810_99_SAIDA*/

        [StopWatch]
        /*" R2850-00-INSERT-V0APOLDESCO-SECTION */
        private void R2850_00_INSERT_V0APOLDESCO_SECTION()
        {
            /*" -2750- MOVE '285' TO WNR-EXEC-SQL. */
            _.Move("285", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2751- MOVE 11 TO V0APID-COD-EMPRESA */
            _.Move(11, V0APID_COD_EMPRESA);

            /*" -2752- MOVE V0ENDO-NUM-APOL TO V0APID-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APID_NUM_APOL);

            /*" -2753- MOVE V0ENDO-NRENDOS TO V0APID-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APID_NRENDOS);

            /*" -2754- MOVE V1PIND-NUM-RISCO TO V0APID-NUM-RISCO */
            _.Move(V1PIND_NUM_RISCO, V0APID_NUM_RISCO);

            /*" -2755- MOVE V1PIND-SUBRIS TO V0APID-SUBRIS */
            _.Move(V1PIND_SUBRIS, V0APID_SUBRIS);

            /*" -2756- MOVE V1PIND-NRITEM TO V0APID-NRITEM */
            _.Move(V1PIND_NRITEM, V0APID_NRITEM);

            /*" -2757- MOVE V1PIND-PLANTA TO V0APID-PLANTA */
            _.Move(V1PIND_PLANTA, V0APID_PLANTA);

            /*" -2758- MOVE V1PIND-PCDESPRT TO V0APID-PCDESPRT */
            _.Move(V1PIND_PCDESPRT, V0APID_PCDESPRT);

            /*" -2759- MOVE V1PIND-TPDESCON TO V0APID-TPDESCON */
            _.Move(V1PIND_TPDESCON, V0APID_TPDESCON);

            /*" -2760- MOVE V1PIND-PCDESTAR TO V0APID-PCDESTAR */
            _.Move(V1PIND_PCDESTAR, V0APID_PCDESTAR);

            /*" -2761- MOVE V1PIND-DESCDESCON TO V0APID-DESCDESCON */
            _.Move(V1PIND_DESCDESCON, V0APID_DESCDESCON);

            /*" -2762- MOVE V0ENDO-DTINIVIG TO V0APID-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APID_DTINIVIG);

            /*" -2763- MOVE V0ENDO-DTTERVIG TO V0APID-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APID_DTTERVIG);

            /*" -2764- MOVE '0' TO V0APID-SITUACAO */
            _.Move("0", V0APID_SITUACAO);

            /*" -2766- MOVE 1 TO V0APID-OCORHIST. */
            _.Move(1, V0APID_OCORHIST);

            /*" -2784- PERFORM R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1 */

            R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1();

            /*" -2787- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2793- DISPLAY 'R2850-00 (REGISTRO DUPLICADO) ... ' ' ' V0APID-NUM-APOL ' ' V0APID-NRENDOS ' ' V0APID-NUM-RISCO ' ' V0APID-SUBRIS ' ' V0APID-NRITEM */

                $"R2850-00 (REGISTRO DUPLICADO) ...  {V0APID_NUM_APOL} {V0APID_NRENDOS} {V0APID_NUM_RISCO} {V0APID_SUBRIS} {V0APID_NRITEM}"
                .Display();

                /*" -2795- GO TO R2850-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2802- DISPLAY 'R2850-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0APID-NUM-APOL ' ' V0APID-NRENDOS ' ' V0APID-NUM-RISCO ' ' V0APID-SUBRIS ' ' V0APID-NRITEM */

                $"R2850-00 (PROBLEMAS NA INSERCAO) ...  {V0APID_NUM_APOL} {V0APID_NRENDOS} {V0APID_NUM_RISCO} {V0APID_SUBRIS} {V0APID_NRITEM}"
                .Display();

                /*" -2804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2806- ADD +1 TO AC-I-V0APOLDESCO */
            AREA_DE_WORK.AC_I_V0APOLDESCO.Value = AREA_DE_WORK.AC_I_V0APOLDESCO + +1;

            /*" -2806- PERFORM R2810-00-FETCH-V1PROPDESCO. */

            R2810_00_FETCH_V1PROPDESCO_SECTION();

        }

        [StopWatch]
        /*" R2850-00-INSERT-V0APOLDESCO-DB-INSERT-1 */
        public void R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1()
        {
            /*" -2784- EXEC SQL INSERT INTO SEGUROS.V0APOLINCDESC VALUES (:V0APID-COD-EMPRESA , :V0APID-NUM-APOL , :V0APID-NRENDOS , :V0APID-NUM-RISCO , :V0APID-SUBRIS , :V0APID-NRITEM , :V0APID-PLANTA , :V0APID-PCDESPRT , :V0APID-TPDESCON , :V0APID-PCDESTAR , :V0APID-DESCDESCON , :V0APID-DTINIVIG , :V0APID-DTTERVIG , :V0APID-SITUACAO , CURRENT TIMESTAMP, :V0APID-OCORHIST) END-EXEC. */

            var r2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1 = new R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1()
            {
                V0APID_COD_EMPRESA = V0APID_COD_EMPRESA.ToString(),
                V0APID_NUM_APOL = V0APID_NUM_APOL.ToString(),
                V0APID_NRENDOS = V0APID_NRENDOS.ToString(),
                V0APID_NUM_RISCO = V0APID_NUM_RISCO.ToString(),
                V0APID_SUBRIS = V0APID_SUBRIS.ToString(),
                V0APID_NRITEM = V0APID_NRITEM.ToString(),
                V0APID_PLANTA = V0APID_PLANTA.ToString(),
                V0APID_PCDESPRT = V0APID_PCDESPRT.ToString(),
                V0APID_TPDESCON = V0APID_TPDESCON.ToString(),
                V0APID_PCDESTAR = V0APID_PCDESTAR.ToString(),
                V0APID_DESCDESCON = V0APID_DESCDESCON.ToString(),
                V0APID_DTINIVIG = V0APID_DTINIVIG.ToString(),
                V0APID_DTTERVIG = V0APID_DTTERVIG.ToString(),
                V0APID_SITUACAO = V0APID_SITUACAO.ToString(),
                V0APID_OCORHIST = V0APID_OCORHIST.ToString(),
            };

            R2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1.Execute(r2850_00_INSERT_V0APOLDESCO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2850_99_SAIDA*/

        [StopWatch]
        /*" R2860-00-DECLARE-V1PROPOUTR-SECTION */
        private void R2860_00_DECLARE_V1PROPOUTR_SECTION()
        {
            /*" -2817- MOVE '286' TO WNR-EXEC-SQL. */
            _.Move("286", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2831- PERFORM R2860_00_DECLARE_V1PROPOUTR_DB_DECLARE_1 */

            R2860_00_DECLARE_V1PROPOUTR_DB_DECLARE_1();

            /*" -2833- PERFORM R2860_00_DECLARE_V1PROPOUTR_DB_OPEN_1 */

            R2860_00_DECLARE_V1PROPOUTR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2860-00-DECLARE-V1PROPOUTR-DB-OPEN-1 */
        public void R2860_00_DECLARE_V1PROPOUTR_DB_OPEN_1()
        {
            /*" -2833- EXEC SQL OPEN V1PROPOUTR END-EXEC. */

            V1PROPOUTR.Open();

        }

        [StopWatch]
        /*" R2900-00-DECLARE-V1PROPDCOB-DB-DECLARE-1 */
        public void R2900_00_DECLARE_V1PROPDCOB_DB_DECLARE_1()
        {
            /*" -2942- EXEC SQL DECLARE V1PROPDCOB CURSOR FOR SELECT COD_EMPRESA , FONTE , NRPROPOS , NUM_RISCO , SUBRIS , NRITEM , DESCR_BENS , IMP_SEGURADA_IX FROM SEGUROS.V1PROPDESCOBER WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY NUM_RISCO , SUBRIS , NRITEM END-EXEC. */
            V1PROPDCOB = new EM0006B_V1PROPDCOB(true);
            string GetQuery_V1PROPDCOB()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NUM_RISCO
							, 
							SUBRIS
							, 
							NRITEM
							, 
							DESCR_BENS
							, 
							IMP_SEGURADA_IX 
							FROM 
							SEGUROS.V1PROPDESCOBER 
							WHERE 
							FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY 
							NUM_RISCO
							, 
							SUBRIS
							, 
							NRITEM";

                return query;
            }
            V1PROPDCOB.GetQueryEvent += GetQuery_V1PROPDCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2860_99_SAIDA*/

        [StopWatch]
        /*" R2870-00-FETCH-V1PROPOUTR-SECTION */
        private void R2870_00_FETCH_V1PROPOUTR_SECTION()
        {
            /*" -2844- MOVE '287' TO WNR-EXEC-SQL. */
            _.Move("287", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2852- PERFORM R2870_00_FETCH_V1PROPOUTR_DB_FETCH_1 */

            R2870_00_FETCH_V1PROPOUTR_DB_FETCH_1();

            /*" -2855- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2856- MOVE 'S' TO WFIM-V1PROPOUTR */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPOUTR);

                /*" -2856- PERFORM R2870_00_FETCH_V1PROPOUTR_DB_CLOSE_1 */

                R2870_00_FETCH_V1PROPOUTR_DB_CLOSE_1();

                /*" -2859- GO TO R2870-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2870_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2859- ADD +1 TO AC-L-V1PROPOUTR. */
            AREA_DE_WORK.AC_L_V1PROPOUTR.Value = AREA_DE_WORK.AC_L_V1PROPOUTR + +1;

        }

        [StopWatch]
        /*" R2870-00-FETCH-V1PROPOUTR-DB-FETCH-1 */
        public void R2870_00_FETCH_V1PROPOUTR_DB_FETCH_1()
        {
            /*" -2852- EXEC SQL FETCH V1PROPOUTR INTO :V1PROU-COD-EMPRESA , :V1PROU-FONTE , :V1PROU-NRPROPOS , :V1PROU-APOLIDER , :V1PROU-CODLIDER , :V1PROU-IMP-SEG-IX END-EXEC. */

            if (V1PROPOUTR.Fetch())
            {
                _.Move(V1PROPOUTR.V1PROU_COD_EMPRESA, V1PROU_COD_EMPRESA);
                _.Move(V1PROPOUTR.V1PROU_FONTE, V1PROU_FONTE);
                _.Move(V1PROPOUTR.V1PROU_NRPROPOS, V1PROU_NRPROPOS);
                _.Move(V1PROPOUTR.V1PROU_APOLIDER, V1PROU_APOLIDER);
                _.Move(V1PROPOUTR.V1PROU_CODLIDER, V1PROU_CODLIDER);
                _.Move(V1PROPOUTR.V1PROU_IMP_SEG_IX, V1PROU_IMP_SEG_IX);
            }

        }

        [StopWatch]
        /*" R2870-00-FETCH-V1PROPOUTR-DB-CLOSE-1 */
        public void R2870_00_FETCH_V1PROPOUTR_DB_CLOSE_1()
        {
            /*" -2856- EXEC SQL CLOSE V1PROPOUTR END-EXEC */

            V1PROPOUTR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2870_99_SAIDA*/

        [StopWatch]
        /*" R2880-00-INSERT-V0APOLOUTR-SECTION */
        private void R2880_00_INSERT_V0APOLOUTR_SECTION()
        {
            /*" -2871- MOVE '288' TO WNR-EXEC-SQL. */
            _.Move("288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2872- MOVE 11 TO V0APOU-COD-EMPRESA */
            _.Move(11, V0APOU_COD_EMPRESA);

            /*" -2873- MOVE V0ENDO-NUM-APOL TO V0APOU-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APOU_NUM_APOL);

            /*" -2874- MOVE V0ENDO-NRENDOS TO V0APOU-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APOU_NRENDOS);

            /*" -2875- MOVE V1PROU-APOLIDER TO V0APOU-APOLIDER */
            _.Move(V1PROU_APOLIDER, V0APOU_APOLIDER);

            /*" -2876- MOVE V1PROU-CODLIDER TO V0APOU-CODLIDER */
            _.Move(V1PROU_CODLIDER, V0APOU_CODLIDER);

            /*" -2877- MOVE V1PROU-IMP-SEG-IX TO V0APOU-IMP-SEG-IX */
            _.Move(V1PROU_IMP_SEG_IX, V0APOU_IMP_SEG_IX);

            /*" -2878- MOVE V0ENDO-DTINIVIG TO V0APOU-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APOU_DTINIVIG);

            /*" -2879- MOVE V0ENDO-DTTERVIG TO V0APOU-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APOU_DTTERVIG);

            /*" -2881- MOVE 1 TO V0APOU-OCORHIST */
            _.Move(1, V0APOU_OCORHIST);

            /*" -2893- PERFORM R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1 */

            R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1();

            /*" -2896- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -2901- DISPLAY 'R2880-00 (REGISTRO DUPLICADO) ... ' ' ' V0APOU-NUM-APOL ' ' V0APOU-NRENDOS ' ' V0APOU-APOLIDER ' ' V0APOU-CODLIDER */

                $"R2880-00 (REGISTRO DUPLICADO) ...  {V0APOU_NUM_APOL} {V0APOU_NRENDOS} {V0APOU_APOLIDER} {V0APOU_CODLIDER}"
                .Display();

                /*" -2903- GO TO R2880-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2880_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2909- DISPLAY 'R2880-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0APOU-NUM-APOL ' ' V0APOU-NRENDOS ' ' V0APOU-APOLIDER ' ' V0APOU-CODLIDER */

                $"R2880-00 (PROBLEMAS NA INSERCAO) ...  {V0APOU_NUM_APOL} {V0APOU_NRENDOS} {V0APOU_APOLIDER} {V0APOU_CODLIDER}"
                .Display();

                /*" -2911- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2913- ADD +1 TO AC-I-V0APOLOUTR */
            AREA_DE_WORK.AC_I_V0APOLOUTR.Value = AREA_DE_WORK.AC_I_V0APOLOUTR + +1;

            /*" -2913- PERFORM R2870-00-FETCH-V1PROPOUTR. */

            R2870_00_FETCH_V1PROPOUTR_SECTION();

        }

        [StopWatch]
        /*" R2880-00-INSERT-V0APOLOUTR-DB-INSERT-1 */
        public void R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1()
        {
            /*" -2893- EXEC SQL INSERT INTO SEGUROS.V0APOLOUTINC VALUES (:V0APOU-COD-EMPRESA , :V0APOU-NUM-APOL , :V0APOU-NRENDOS , :V0APOU-APOLIDER , :V0APOU-CODLIDER , :V0APOU-IMP-SEG-IX , :V0APOU-DTINIVIG , :V0APOU-DTTERVIG , CURRENT TIMESTAMP, :V0APOU-OCORHIST ) END-EXEC. */

            var r2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1 = new R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1()
            {
                V0APOU_COD_EMPRESA = V0APOU_COD_EMPRESA.ToString(),
                V0APOU_NUM_APOL = V0APOU_NUM_APOL.ToString(),
                V0APOU_NRENDOS = V0APOU_NRENDOS.ToString(),
                V0APOU_APOLIDER = V0APOU_APOLIDER.ToString(),
                V0APOU_CODLIDER = V0APOU_CODLIDER.ToString(),
                V0APOU_IMP_SEG_IX = V0APOU_IMP_SEG_IX.ToString(),
                V0APOU_DTINIVIG = V0APOU_DTINIVIG.ToString(),
                V0APOU_DTTERVIG = V0APOU_DTTERVIG.ToString(),
                V0APOU_OCORHIST = V0APOU_OCORHIST.ToString(),
            };

            R2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1.Execute(r2880_00_INSERT_V0APOLOUTR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2880_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-DECLARE-V1PROPDCOB-SECTION */
        private void R2900_00_DECLARE_V1PROPDCOB_SECTION()
        {
            /*" -2924- MOVE '290' TO WNR-EXEC-SQL. */
            _.Move("290", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2942- PERFORM R2900_00_DECLARE_V1PROPDCOB_DB_DECLARE_1 */

            R2900_00_DECLARE_V1PROPDCOB_DB_DECLARE_1();

            /*" -2944- PERFORM R2900_00_DECLARE_V1PROPDCOB_DB_OPEN_1 */

            R2900_00_DECLARE_V1PROPDCOB_DB_OPEN_1();

        }

        [StopWatch]
        /*" R2900-00-DECLARE-V1PROPDCOB-DB-OPEN-1 */
        public void R2900_00_DECLARE_V1PROPDCOB_DB_OPEN_1()
        {
            /*" -2944- EXEC SQL OPEN V1PROPDCOB END-EXEC. */

            V1PROPDCOB.Open();

        }

        [StopWatch]
        /*" R3600-00-DECLARE-V1COBPROPINC-DB-DECLARE-1 */
        public void R3600_00_DECLARE_V1COBPROPINC_DB_DECLARE_1()
        {
            /*" -3427- EXEC SQL DECLARE V1COBPROPINC CURSOR FOR SELECT COD_EMPRESA, FONTE, NRPROPOS, NUM_RISCO, SUBRIS, NRITEM, CODCOBINC, IMP_SEGURADA_IX, TIPOCOBINC, PRM_TARIFARIO_IX FROM SEGUROS.V1COBERPROP_INC WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS ORDER BY FONTE, NRPROPOS, NUM_RISCO, SUBRIS, NRITEM, CODCOBINC END-EXEC. */
            V1COBPROPINC = new EM0006B_V1COBPROPINC(true);
            string GetQuery_V1COBPROPINC()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							FONTE
							, 
							NRPROPOS
							, 
							NUM_RISCO
							, 
							SUBRIS
							, 
							NRITEM
							, 
							CODCOBINC
							, 
							IMP_SEGURADA_IX
							, 
							TIPOCOBINC
							, 
							PRM_TARIFARIO_IX 
							FROM SEGUROS.V1COBERPROP_INC 
							WHERE FONTE = '{V1PROP_FONTE}' 
							AND NRPROPOS = '{V1PROP_NRPROPOS}' 
							ORDER BY FONTE
							, 
							NRPROPOS
							, 
							NUM_RISCO
							, 
							SUBRIS
							, 
							NRITEM
							, 
							CODCOBINC";

                return query;
            }
            V1COBPROPINC.GetQueryEvent += GetQuery_V1COBPROPINC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-FETCH-V1PROPDCOB-SECTION */
        private void R2910_00_FETCH_V1PROPDCOB_SECTION()
        {
            /*" -2955- MOVE '291' TO WNR-EXEC-SQL. */
            _.Move("291", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2964- PERFORM R2910_00_FETCH_V1PROPDCOB_DB_FETCH_1 */

            R2910_00_FETCH_V1PROPDCOB_DB_FETCH_1();

            /*" -2967- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2968- MOVE 'S' TO WFIM-V1PROPDCOB */
                _.Move("S", AREA_DE_WORK.WFIM_V1PROPDCOB);

                /*" -2968- PERFORM R2910_00_FETCH_V1PROPDCOB_DB_CLOSE_1 */

                R2910_00_FETCH_V1PROPDCOB_DB_CLOSE_1();

                /*" -2971- GO TO R2910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2971- ADD +1 TO AC-L-V1PROPDCOB. */
            AREA_DE_WORK.AC_L_V1PROPDCOB.Value = AREA_DE_WORK.AC_L_V1PROPDCOB + +1;

        }

        [StopWatch]
        /*" R2910-00-FETCH-V1PROPDCOB-DB-FETCH-1 */
        public void R2910_00_FETCH_V1PROPDCOB_DB_FETCH_1()
        {
            /*" -2964- EXEC SQL FETCH V1PROPDCOB INTO :V1PRDC-COD-EMPRESA , :V1PRDC-FONTE , :V1PRDC-NRPROPOS , :V1PRDC-NUM-RISCO , :V1PRDC-SUBRIS , :V1PRDC-NRITEM , :V1PRDC-DESCR-BENS , :V1PRDC-IMP-SEG-IX END-EXEC. */

            if (V1PROPDCOB.Fetch())
            {
                _.Move(V1PROPDCOB.V1PRDC_COD_EMPRESA, V1PRDC_COD_EMPRESA);
                _.Move(V1PROPDCOB.V1PRDC_FONTE, V1PRDC_FONTE);
                _.Move(V1PROPDCOB.V1PRDC_NRPROPOS, V1PRDC_NRPROPOS);
                _.Move(V1PROPDCOB.V1PRDC_NUM_RISCO, V1PRDC_NUM_RISCO);
                _.Move(V1PROPDCOB.V1PRDC_SUBRIS, V1PRDC_SUBRIS);
                _.Move(V1PROPDCOB.V1PRDC_NRITEM, V1PRDC_NRITEM);
                _.Move(V1PROPDCOB.V1PRDC_DESCR_BENS, V1PRDC_DESCR_BENS);
                _.Move(V1PROPDCOB.V1PRDC_IMP_SEG_IX, V1PRDC_IMP_SEG_IX);
            }

        }

        [StopWatch]
        /*" R2910-00-FETCH-V1PROPDCOB-DB-CLOSE-1 */
        public void R2910_00_FETCH_V1PROPDCOB_DB_CLOSE_1()
        {
            /*" -2968- EXEC SQL CLOSE V1PROPDCOB END-EXEC */

            V1PROPDCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2950-00-INSERT-V0APOLDCOB-SECTION */
        private void R2950_00_INSERT_V0APOLDCOB_SECTION()
        {
            /*" -2983- MOVE '295' TO WNR-EXEC-SQL. */
            _.Move("295", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2984- MOVE 11 TO V0APDC-COD-EMPRESA */
            _.Move(11, V0APDC_COD_EMPRESA);

            /*" -2985- MOVE V0ENDO-NUM-APOL TO V0APDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0APDC_NUM_APOL);

            /*" -2986- MOVE V0ENDO-NRENDOS TO V0APDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0APDC_NRENDOS);

            /*" -2987- MOVE V1PRDC-NUM-RISCO TO V0APDC-NUM-RISCO */
            _.Move(V1PRDC_NUM_RISCO, V0APDC_NUM_RISCO);

            /*" -2988- MOVE V1PRDC-SUBRIS TO V0APDC-SUBRIS */
            _.Move(V1PRDC_SUBRIS, V0APDC_SUBRIS);

            /*" -2989- MOVE V1PRDC-NRITEM TO V0APDC-NRITEM */
            _.Move(V1PRDC_NRITEM, V0APDC_NRITEM);

            /*" -2990- MOVE V1PRDC-DESCR-BENS TO V0APDC-DESCR-BENS */
            _.Move(V1PRDC_DESCR_BENS, V0APDC_DESCR_BENS);

            /*" -2991- MOVE V1PRDC-IMP-SEG-IX TO V0APDC-IMP-SEG-IX */
            _.Move(V1PRDC_IMP_SEG_IX, V0APDC_IMP_SEG_IX);

            /*" -2992- MOVE V0ENDO-DTINIVIG TO V0APDC-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0APDC_DTINIVIG);

            /*" -2993- MOVE V0ENDO-DTTERVIG TO V0APDC-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0APDC_DTTERVIG);

            /*" -2994- MOVE '0' TO V0APDC-SITUACAO */
            _.Move("0", V0APDC_SITUACAO);

            /*" -2996- MOVE 1 TO V0APDC-OCORHIST. */
            _.Move(1, V0APDC_OCORHIST);

            /*" -3011- PERFORM R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1 */

            R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1();

            /*" -3014- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3020- DISPLAY 'R2950-00 (REGISTRO DUPLICADO) ... ' ' ' V0APDC-NUM-APOL ' ' V0APDC-NRENDOS ' ' V0APDC-NUM-RISCO ' ' V0APDC-SUBRIS ' ' V0APDC-NRITEM */

                $"R2950-00 (REGISTRO DUPLICADO) ...  {V0APDC_NUM_APOL} {V0APDC_NRENDOS} {V0APDC_NUM_RISCO} {V0APDC_SUBRIS} {V0APDC_NRITEM}"
                .Display();

                /*" -3022- GO TO R2950-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2950_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3023- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3029- DISPLAY 'R2950-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0APDC-NUM-APOL ' ' V0APDC-NRENDOS ' ' V0APDC-NUM-RISCO ' ' V0APDC-SUBRIS ' ' V0APDC-NRITEM */

                $"R2950-00 (PROBLEMAS NA INSERCAO) ...  {V0APDC_NUM_APOL} {V0APDC_NRENDOS} {V0APDC_NUM_RISCO} {V0APDC_SUBRIS} {V0APDC_NRITEM}"
                .Display();

                /*" -3031- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3033- ADD +1 TO AC-I-V0APOLDCOB */
            AREA_DE_WORK.AC_I_V0APOLDCOB.Value = AREA_DE_WORK.AC_I_V0APOLDCOB + +1;

            /*" -3033- PERFORM R2910-00-FETCH-V1PROPDCOB. */

            R2910_00_FETCH_V1PROPDCOB_SECTION();

        }

        [StopWatch]
        /*" R2950-00-INSERT-V0APOLDCOB-DB-INSERT-1 */
        public void R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1()
        {
            /*" -3011- EXEC SQL INSERT INTO SEGUROS.V0APOLDESCOBER VALUES (:V0APDC-COD-EMPRESA , :V0APDC-NUM-APOL , :V0APDC-NRENDOS , :V0APDC-NUM-RISCO , :V0APDC-SUBRIS , :V0APDC-NRITEM , :V0APDC-DESCR-BENS , :V0APDC-IMP-SEG-IX , :V0APDC-DTINIVIG , :V0APDC-DTTERVIG , :V0APDC-SITUACAO , CURRENT TIMESTAMP, :V0APDC-OCORHIST) END-EXEC. */

            var r2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1 = new R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1()
            {
                V0APDC_COD_EMPRESA = V0APDC_COD_EMPRESA.ToString(),
                V0APDC_NUM_APOL = V0APDC_NUM_APOL.ToString(),
                V0APDC_NRENDOS = V0APDC_NRENDOS.ToString(),
                V0APDC_NUM_RISCO = V0APDC_NUM_RISCO.ToString(),
                V0APDC_SUBRIS = V0APDC_SUBRIS.ToString(),
                V0APDC_NRITEM = V0APDC_NRITEM.ToString(),
                V0APDC_DESCR_BENS = V0APDC_DESCR_BENS.ToString(),
                V0APDC_IMP_SEG_IX = V0APDC_IMP_SEG_IX.ToString(),
                V0APDC_DTINIVIG = V0APDC_DTINIVIG.ToString(),
                V0APDC_DTTERVIG = V0APDC_DTTERVIG.ToString(),
                V0APDC_SITUACAO = V0APDC_SITUACAO.ToString(),
                V0APDC_OCORHIST = V0APDC_OCORHIST.ToString(),
            };

            R2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1.Execute(r2950_00_INSERT_V0APOLDCOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2950_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-V0APOLICE-SECTION */
        private void R3100_00_INSERT_V0APOLICE_SECTION()
        {
            /*" -3044- PERFORM R3110-00-MONTA-APOLICE */

            R3110_00_MONTA_APOLICE_SECTION();

            /*" -3046- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3098- PERFORM R3100_00_INSERT_V0APOLICE_DB_INSERT_1 */

            R3100_00_INSERT_V0APOLICE_DB_INSERT_1();

            /*" -3101- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3103- DISPLAY 'R3100-00 (REGISTRO DUPLICADO) ... ' ' ' V0APOL-NUM-APOL */

                $"R3100-00 (REGISTRO DUPLICADO) ...  {V0APOL_NUM_APOL}"
                .Display();

                /*" -3105- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3106- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3108- DISPLAY 'R3100-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0APOL-NUM-APOL */

                $"R3100-00 (PROBLEMAS NA INSERCAO) ...  {V0APOL_NUM_APOL}"
                .Display();

                /*" -3110- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3110- ADD +1 TO AC-I-V0APOLICE. */
            AREA_DE_WORK.AC_I_V0APOLICE.Value = AREA_DE_WORK.AC_I_V0APOLICE + +1;

        }

        [StopWatch]
        /*" R3100-00-INSERT-V0APOLICE-DB-INSERT-1 */
        public void R3100_00_INSERT_V0APOLICE_DB_INSERT_1()
        {
            /*" -3098- EXEC SQL INSERT INTO SEGUROS.V0APOLICE (CODCLIEN , NUM_APOLICE , NUM_ITEM , MODALIDA , ORGAO , RAMO , NUM_APOL_ANTERIOR , NUMBIL , TIPSGU , TIPAPO , TIPCALC , PODPUBL , NUM_ATA , ANO_ATA , IDEMAN , PCDESCON , PCIOCC , TPCOSCED , QTCOSSEG , PCTCED , DATA_SORTEIO , COD_EMPRESA , TIMESTAMP , CODPRODU , TPCORRET) VALUES (:V0APOL-CODCLIEN , :V0APOL-NUM-APOL , :V0APOL-NUM-ITEM , :V0APOL-MODALIDA , :V0APOL-ORGAO , :V0APOL-RAMO , :V0APOL-NUM-APO-ANT , :V0APOL-NUMBIL , :V0APOL-TIPSGU , :V0APOL-TIPAPO , :V0APOL-TIPCALC , :V0APOL-PODPUBL , :V0APOL-NUM-ATA , :V0APOL-ANO-ATA , :V0APOL-IDEMAN , :V0APOL-PCDESCON , :V0APOL-PCIOCC , :V0APOL-TPCOSCED , :V0APOL-QTCOSSEG , :V0APOL-PCTCED , NULL , :V0APOL-COD-EMPRESA , CURRENT TIMESTAMP , :V0APOL-CODPRODU , :V0APOL-TPCORRET) END-EXEC. */

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
                V0APOL_COD_EMPRESA = V0APOL_COD_EMPRESA.ToString(),
                V0APOL_CODPRODU = V0APOL_CODPRODU.ToString(),
                V0APOL_TPCORRET = V0APOL_TPCORRET.ToString(),
            };

            R3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_V0APOLICE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-MONTA-APOLICE-SECTION */
        private void R3110_00_MONTA_APOLICE_SECTION()
        {
            /*" -3123- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3124- IF V1PROP-NUM-APO-MAN EQUAL ZEROS */

            if (V1PROP_NUM_APO_MAN == 00)
            {

                /*" -3125- PERFORM R4600-00-SELECT-NUMERO-AES */

                R4600_00_SELECT_NUMERO_AES_SECTION();

                /*" -3126- MOVE V0NAES-SEQ-APOL TO W0NAES-SEQ-APOL */
                _.Move(V0NAES_SEQ_APOL, W0NAES_SEQ_APOL);

                /*" -3127- ADD 1 TO W0NAES-SEQ-APOL */
                W0NAES_SEQ_APOL.Value = W0NAES_SEQ_APOL + 1;

                /*" -3128- MOVE W0NAES-SEQ-APOL TO V0NAES-SEQ-APOL */
                _.Move(W0NAES_SEQ_APOL, V0NAES_SEQ_APOL);

                /*" -3129- PERFORM R4700-00-UPDATE-NUMERO-AES */

                R4700_00_UPDATE_NUMERO_AES_SECTION();

                /*" -3130- MOVE V1FONT-ORGAOEMIS TO WNUM-APOL-ORG */
                _.Move(V1FONT_ORGAOEMIS, AREA_DE_WORK.FILLER_0.WNUM_APOL_ORG);

                /*" -3131- MOVE V1PROP-RAMO TO WNUM-APOL-RAM */
                _.Move(V1PROP_RAMO, AREA_DE_WORK.FILLER_0.WNUM_APOL_RAM);

                /*" -3132- MOVE W0NAES-SEQ-APOL TO WNUM-APOL-SEQ */
                _.Move(W0NAES_SEQ_APOL, AREA_DE_WORK.FILLER_0.WNUM_APOL_SEQ);

                /*" -3133- MOVE WNUMERO-APOL TO WNUM-APOLICE */
                _.Move(AREA_DE_WORK.WNUMERO_APOL, AREA_DE_WORK.WNUM_APOLICE);

                /*" -3134- ELSE */
            }
            else
            {


                /*" -3136- MOVE V1PROP-NUM-APO-MAN TO WNUM-APOLICE. */
                _.Move(V1PROP_NUM_APO_MAN, AREA_DE_WORK.WNUM_APOLICE);
            }


            /*" -3137- MOVE V1PROP-CODCLIEN TO V0APOL-CODCLIEN */
            _.Move(V1PROP_CODCLIEN, V0APOL_CODCLIEN);

            /*" -3138- MOVE WNUM-APOLICE TO V0APOL-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0APOL_NUM_APOL);

            /*" -3139- MOVE ZEROS TO V0APOL-NUM-ITEM */
            _.Move(0, V0APOL_NUM_ITEM);

            /*" -3140- MOVE V1PROP-MODALIDA TO V0APOL-MODALIDA */
            _.Move(V1PROP_MODALIDA, V0APOL_MODALIDA);

            /*" -3141- MOVE V1FONT-ORGAOEMIS TO V0APOL-ORGAO */
            _.Move(V1FONT_ORGAOEMIS, V0APOL_ORGAO);

            /*" -3142- MOVE V1PROP-RAMO TO V0APOL-RAMO */
            _.Move(V1PROP_RAMO, V0APOL_RAMO);

            /*" -3143- MOVE V1PROP-NUM-APO-ANT TO V0APOL-NUM-APO-ANT */
            _.Move(V1PROP_NUM_APO_ANT, V0APOL_NUM_APO_ANT);

            /*" -3144- MOVE ZEROS TO V0APOL-NUMBIL */
            _.Move(0, V0APOL_NUMBIL);

            /*" -3145- MOVE '1' TO V0APOL-TIPSGU */
            _.Move("1", V0APOL_TIPSGU);

            /*" -3146- MOVE V1PROP-TIPAPO TO V0APOL-TIPAPO */
            _.Move(V1PROP_TIPAPO, V0APOL_TIPAPO);

            /*" -3147- MOVE V1PROP-TIPCALC TO V0APOL-TIPCALC */
            _.Move(V1PROP_TIPCALC, V0APOL_TIPCALC);

            /*" -3148- MOVE V1PROP-PODPUBL TO V0APOL-PODPUBL */
            _.Move(V1PROP_PODPUBL, V0APOL_PODPUBL);

            /*" -3149- MOVE V1PROP-NUM-ATA TO V0APOL-NUM-ATA */
            _.Move(V1PROP_NUM_ATA, V0APOL_NUM_ATA);

            /*" -3150- MOVE V1PROP-ANO-ATA TO V0APOL-ANO-ATA */
            _.Move(V1PROP_ANO_ATA, V0APOL_ANO_ATA);

            /*" -3151- MOVE SPACES TO V0APOL-IDEMAN */
            _.Move("", V0APOL_IDEMAN);

            /*" -3153- MOVE V1PROP-PCDESCON TO V0APOL-PCDESCON */
            _.Move(V1PROP_PCDESCON, V0APOL_PCDESCON);

            /*" -3154- IF V1PROP-IDIOF EQUAL 'S' */

            if (V1PROP_IDIOF == "S")
            {

                /*" -3155- MOVE ZEROS TO V0APOL-PCIOCC */
                _.Move(0, V0APOL_PCIOCC);

                /*" -3156- ELSE */
            }
            else
            {


                /*" -3158- MOVE V1RAMO-PCIOF TO V0APOL-PCIOCC. */
                _.Move(V1RAMO_PCIOF, V0APOL_PCIOCC);
            }


            /*" -3159- MOVE V1PROP-TPCOSCED TO V0APOL-TPCOSCED */
            _.Move(V1PROP_TPCOSCED, V0APOL_TPCOSCED);

            /*" -3160- MOVE V1PROP-QTCOSSEG TO V0APOL-QTCOSSEG */
            _.Move(V1PROP_QTCOSSEG, V0APOL_QTCOSSEG);

            /*" -3161- MOVE +0 TO V0APOL-PCTCED */
            _.Move(+0, V0APOL_PCTCED);

            /*" -3162- MOVE V1PROP-DATA-SORT TO V0APOL-DATA-SORT */
            _.Move(V1PROP_DATA_SORT, V0APOL_DATA_SORT);

            /*" -3163- MOVE V1PROP-COD-EMPRESA TO V0APOL-COD-EMPRESA */
            _.Move(V1PROP_COD_EMPRESA, V0APOL_COD_EMPRESA);

            /*" -3164- MOVE ZEROS TO V0APOL-CODPRODU */
            _.Move(0, V0APOL_CODPRODU);

            /*" -3164- MOVE '1' TO V0APOL-TPCORRET. */
            _.Move("1", V0APOL_TPCORRET);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-INSERT-V0ENDOSSO-SECTION */
        private void R3200_00_INSERT_V0ENDOSSO_SECTION()
        {
            /*" -3175- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3177- PERFORM R3210-00-MONTA-V0ENDOSSO */

            R3210_00_MONTA_V0ENDOSSO_SECTION();

            /*" -3267- PERFORM R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1 */

            R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1();

            /*" -3270- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3275- DISPLAY 'R3200-00 (REGISTRO DUPLICADO) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V0ENDO-FONTE ' ' V0ENDO-NRPROPOS */

                $"R3200-00 (REGISTRO DUPLICADO) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V0ENDO_FONTE} {V0ENDO_NRPROPOS}"
                .Display();

                /*" -3277- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3283- DISPLAY 'R3200-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V0ENDO-FONTE ' ' V0ENDO-NRPROPOS */

                $"R3200-00 (PROBLEMAS NA INSERCAO) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V0ENDO_FONTE} {V0ENDO_NRPROPOS}"
                .Display();

                /*" -3285- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3285- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

        }

        [StopWatch]
        /*" R3200-00-INSERT-V0ENDOSSO-DB-INSERT-1 */
        public void R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1()
        {
            /*" -3267- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOL , :V0ENDO-NRENDOS , :V0ENDO-CODSUBES , :V0ENDO-FONTE , :V0ENDO-NRPROPOS , :V0ENDO-DATPRO , :V0ENDO-DT-LIBER , :V0ENDO-DTEMIS , :V0ENDO-NRRCAP , :V0ENDO-VLRCAP , :V0ENDO-BCORCAP , :V0ENDO-AGERCAP , :V0ENDO-DACRCAP , :V0ENDO-IDRCAP , :V0ENDO-BCOCOBR , :V0ENDO-AGECOBR , :V0ENDO-DACCOBR , :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG , :V0ENDO-CDFRACIO , :V0ENDO-PCENTRAD , :V0ENDO-PCADICIO , :V0ENDO-PRESTA1 , :V0ENDO-QTPARCEL , :V0ENDO-QTPRESTA , :V0ENDO-QTITENS , :V0ENDO-CODTXT , :V0ENDO-CDACEITA , :V0ENDO-MOEDA-IMP , :V0ENDO-MOEDA-PRM , :V0ENDO-TIPEND , :V0ENDO-COD-USUAR , :V0ENDO-OCORR-END , :V0ENDO-SITUACAO , :V0ENDO-DATARCAP:VIND-DAT-RCAP, :V0ENDO-COD-EMPRESA:VIND-COD-EMP, :V0ENDO-CORRECAO:VIND-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:VIND-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI , :V0ENDO-RAMO , :V0ENDO-CODPRODU) END-EXEC. */

            var r3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1 = new R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1()
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
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1.Execute(r3200_00_INSERT_V0ENDOSSO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-MONTA-V0ENDOSSO-SECTION */
        private void R3210_00_MONTA_V0ENDOSSO_SECTION()
        {
            /*" -3296- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3298- MOVE SPACES TO WFIM-V1ACOMPROP */
            _.Move("", AREA_DE_WORK.WFIM_V1ACOMPROP);

            /*" -3300- PERFORM R4800-00-ACESSA-V1ACOMPROP */

            R4800_00_ACESSA_V1ACOMPROP_SECTION();

            /*" -3303- MOVE 11 TO V0ENDO-COD-EMPRESA */
            _.Move(11, V0ENDO_COD_EMPRESA);

            /*" -3304- IF V1PROP-TPPROPOS EQUAL '1' OR '9' */

            if (V1PROP_TPPROPOS.In("1", "9"))
            {

                /*" -3305- MOVE WNUM-APOLICE TO V0ENDO-NUM-APOL */
                _.Move(AREA_DE_WORK.WNUM_APOLICE, V0ENDO_NUM_APOL);

                /*" -3306- MOVE ZEROS TO V0ENDO-NRENDOS */
                _.Move(0, V0ENDO_NRENDOS);

                /*" -3307- ELSE */
            }
            else
            {


                /*" -3308- MOVE V1PROP-NUM-APOLICE TO V0ENDO-NUM-APOL */
                _.Move(V1PROP_NUM_APOLICE, V0ENDO_NUM_APOL);

                /*" -3309- PERFORM R3211-00-NUMERO-ENDOSSO */

                R3211_00_NUMERO_ENDOSSO_SECTION();

                /*" -3311- MOVE WNUM-ENDOSSO TO V0ENDO-NRENDOS. */
                _.Move(AREA_DE_WORK.WNUM_ENDOSSO, V0ENDO_NRENDOS);
            }


            /*" -3312- MOVE ZEROS TO V0ENDO-CODSUBES */
            _.Move(0, V0ENDO_CODSUBES);

            /*" -3313- MOVE V1PROP-FONTE TO V0ENDO-FONTE */
            _.Move(V1PROP_FONTE, V0ENDO_FONTE);

            /*" -3314- MOVE V1PROP-NRPROPOS TO V0ENDO-NRPROPOS */
            _.Move(V1PROP_NRPROPOS, V0ENDO_NRPROPOS);

            /*" -3316- MOVE V1PROP-DTENTRAD TO V0ENDO-DATPRO */
            _.Move(V1PROP_DTENTRAD, V0ENDO_DATPRO);

            /*" -3317- IF WFIM-V1ACOMPROP EQUAL SPACES */

            if (AREA_DE_WORK.WFIM_V1ACOMPROP.IsEmpty())
            {

                /*" -3318- MOVE V1APRO-DATOPR TO V0ENDO-DT-LIBER */
                _.Move(V1APRO_DATOPR, V0ENDO_DT_LIBER);

                /*" -3319- ELSE */
            }
            else
            {


                /*" -3321- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
                _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);
            }


            /*" -3322- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -3323- MOVE V1PROP-NRRCAP TO V0ENDO-NRRCAP */
            _.Move(V1PROP_NRRCAP, V0ENDO_NRRCAP);

            /*" -3324- MOVE V1PROP-VLRCAP TO V0ENDO-VLRCAP */
            _.Move(V1PROP_VLRCAP, V0ENDO_VLRCAP);

            /*" -3325- MOVE V1PROP-BCORCAP TO V0ENDO-BCORCAP */
            _.Move(V1PROP_BCORCAP, V0ENDO_BCORCAP);

            /*" -3326- MOVE V1PROP-AGERCAP TO V0ENDO-AGERCAP */
            _.Move(V1PROP_AGERCAP, V0ENDO_AGERCAP);

            /*" -3327- MOVE SPACES TO V0ENDO-DACRCAP */
            _.Move("", V0ENDO_DACRCAP);

            /*" -3328- MOVE V1PROP-IDRCAP TO V0ENDO-IDRCAP */
            _.Move(V1PROP_IDRCAP, V0ENDO_IDRCAP);

            /*" -3329- MOVE V1PROP-BCOCOBR TO V0ENDO-BCOCOBR */
            _.Move(V1PROP_BCOCOBR, V0ENDO_BCOCOBR);

            /*" -3330- MOVE V1PROP-AGECOBR TO V0ENDO-AGECOBR */
            _.Move(V1PROP_AGECOBR, V0ENDO_AGECOBR);

            /*" -3331- MOVE SPACES TO V0ENDO-DACCOBR */
            _.Move("", V0ENDO_DACCOBR);

            /*" -3332- MOVE V1PROP-DTINIVIG TO V0ENDO-DTINIVIG */
            _.Move(V1PROP_DTINIVIG, V0ENDO_DTINIVIG);

            /*" -3333- MOVE V1PROP-DTTERVIG TO V0ENDO-DTTERVIG */
            _.Move(V1PROP_DTTERVIG, V0ENDO_DTTERVIG);

            /*" -3334- MOVE V1PROP-CDFRACIO TO V0ENDO-CDFRACIO */
            _.Move(V1PROP_CDFRACIO, V0ENDO_CDFRACIO);

            /*" -3335- MOVE V1PROP-PCENTRAD TO V0ENDO-PCENTRAD */
            _.Move(V1PROP_PCENTRAD, V0ENDO_PCENTRAD);

            /*" -3336- MOVE V1PROP-PCADICIO TO V0ENDO-PCADICIO */
            _.Move(V1PROP_PCADICIO, V0ENDO_PCADICIO);

            /*" -3337- MOVE V1PROP-PRESTA1 TO V0ENDO-PRESTA1 */
            _.Move(V1PROP_PRESTA1, V0ENDO_PRESTA1);

            /*" -3338- MOVE V1PROP-QTPARCEL TO V0ENDO-QTPARCEL */
            _.Move(V1PROP_QTPARCEL, V0ENDO_QTPARCEL);

            /*" -3339- MOVE V1PROP-QTPRESTA TO V0ENDO-QTPRESTA */
            _.Move(V1PROP_QTPRESTA, V0ENDO_QTPRESTA);

            /*" -3340- MOVE V1PROP-QTITENS TO V0ENDO-QTITENS */
            _.Move(V1PROP_QTITENS, V0ENDO_QTITENS);

            /*" -3341- MOVE V1PROP-CODTXT TO V0ENDO-CODTXT */
            _.Move(V1PROP_CODTXT, V0ENDO_CODTXT);

            /*" -3342- MOVE V1PROP-CDACEITA TO V0ENDO-CDACEITA */
            _.Move(V1PROP_CDACEITA, V0ENDO_CDACEITA);

            /*" -3343- MOVE V1PROP-MOEDA-IMP TO V0ENDO-MOEDA-IMP */
            _.Move(V1PROP_MOEDA_IMP, V0ENDO_MOEDA_IMP);

            /*" -3344- MOVE V1PROP-MOEDA-PRM TO V0ENDO-MOEDA-PRM */
            _.Move(V1PROP_MOEDA_PRM, V0ENDO_MOEDA_PRM);

            /*" -3345- MOVE V1PROP-TIPO-ENDO TO V0ENDO-TIPEND */
            _.Move(V1PROP_TIPO_ENDO, V0ENDO_TIPEND);

            /*" -3346- MOVE V1PROP-COD-USUAR TO V0ENDO-COD-USUAR */
            _.Move(V1PROP_COD_USUAR, V0ENDO_COD_USUAR);

            /*" -3347- MOVE V1PROP-OCORR-END TO V0ENDO-OCORR-END */
            _.Move(V1PROP_OCORR_END, V0ENDO_OCORR_END);

            /*" -3348- MOVE SPACES TO V0ENDO-SITUACAO */
            _.Move("", V0ENDO_SITUACAO);

            /*" -3349- MOVE V1PROP-DATARCAP TO V0ENDO-DATARCAP */
            _.Move(V1PROP_DATARCAP, V0ENDO_DATARCAP);

            /*" -3350- MOVE 0 TO VIND-CORRECAO */
            _.Move(0, VIND_CORRECAO);

            /*" -3351- MOVE V1PROP-CORRECAO TO V0ENDO-CORRECAO */
            _.Move(V1PROP_CORRECAO, V0ENDO_CORRECAO);

            /*" -3353- MOVE V1PROP-ISENTA-CST TO V0ENDO-ISENTA-CST */
            _.Move(V1PROP_ISENTA_CST, V0ENDO_ISENTA_CST);

            /*" -3354- MOVE V1PROP-DTVENCTO TO V0ENDO-DTVENCTO */
            _.Move(V1PROP_DTVENCTO, V0ENDO_DTVENCTO);

            /*" -3355- MOVE V1PROP-CFPREFIX TO V0ENDO-CFPREFIX. */
            _.Move(V1PROP_CFPREFIX, V0ENDO_CFPREFIX);

            /*" -3356- MOVE V1PROP-VLCUSEMI TO V0ENDO-VLCUSEMI. */
            _.Move(V1PROP_VLCUSEMI, V0ENDO_VLCUSEMI);

            /*" -3357- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -3357- MOVE V0APOL-CODPRODU TO V0APOL-CODPRODU. */
            _.Move(V0APOL_CODPRODU, V0APOL_CODPRODU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3211-00-NUMERO-ENDOSSO-SECTION */
        private void R3211_00_NUMERO_ENDOSSO_SECTION()
        {
            /*" -3370- MOVE '32X' TO WNR-EXEC-SQL. */
            _.Move("32X", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3372- PERFORM R4600-00-SELECT-NUMERO-AES */

            R4600_00_SELECT_NUMERO_AES_SECTION();

            /*" -3373- IF V1PROP-TIPO-ENDO EQUAL '1' */

            if (V1PROP_TIPO_ENDO == "1")
            {

                /*" -3374- ADD +1 TO V0NAES-ENDOSCOB */
                V0NAES_ENDOSCOB.Value = V0NAES_ENDOSCOB + +1;

                /*" -3375- MOVE V0NAES-ENDOSCOB TO WNUM-ENDOSSO */
                _.Move(V0NAES_ENDOSCOB, AREA_DE_WORK.WNUM_ENDOSSO);

                /*" -3376- ELSE */
            }
            else
            {


                /*" -3377- IF V1PROP-TIPO-ENDO EQUAL '3' */

                if (V1PROP_TIPO_ENDO == "3")
                {

                    /*" -3378- ADD +1 TO V0NAES-ENDOSRES */
                    V0NAES_ENDOSRES.Value = V0NAES_ENDOSRES + +1;

                    /*" -3379- MOVE V0NAES-ENDOSRES TO WNUM-ENDOSSO */
                    _.Move(V0NAES_ENDOSRES, AREA_DE_WORK.WNUM_ENDOSSO);

                    /*" -3380- ELSE */
                }
                else
                {


                    /*" -3381- IF V1PROP-TIPO-ENDO EQUAL '4' */

                    if (V1PROP_TIPO_ENDO == "4")
                    {

                        /*" -3382- ADD +1 TO V0NAES-ENDOSSEM */
                        V0NAES_ENDOSSEM.Value = V0NAES_ENDOSSEM + +1;

                        /*" -3383- MOVE V0NAES-ENDOSSEM TO WNUM-ENDOSSO */
                        _.Move(V0NAES_ENDOSSEM, AREA_DE_WORK.WNUM_ENDOSSO);

                        /*" -3384- ELSE */
                    }
                    else
                    {


                        /*" -3385- IF V1PROP-TIPO-ENDO EQUAL '5' */

                        if (V1PROP_TIPO_ENDO == "5")
                        {

                            /*" -3386- ADD +1 TO V0NAES-ENDOSCCR */
                            V0NAES_ENDOSCCR.Value = V0NAES_ENDOSCCR + +1;

                            /*" -3387- MOVE V0NAES-ENDOSCCR TO WNUM-ENDOSSO */
                            _.Move(V0NAES_ENDOSCCR, AREA_DE_WORK.WNUM_ENDOSSO);

                            /*" -3388- ELSE */
                        }
                        else
                        {


                            /*" -3389- IF V1PROP-TIPO-ENDO EQUAL '6' */

                            if (V1PROP_TIPO_ENDO == "6")
                            {

                                /*" -3390- ADD +1 TO V0NAES-ENDOSMVC */
                                V0NAES_ENDOSMVC.Value = V0NAES_ENDOSMVC + +1;

                                /*" -3391- MOVE V0NAES-ENDOSMVC TO WNUM-ENDOSSO */
                                _.Move(V0NAES_ENDOSMVC, AREA_DE_WORK.WNUM_ENDOSSO);

                                /*" -3392- ELSE */
                            }
                            else
                            {


                                /*" -3394- DISPLAY 'TIPO DE ENDOSSO INVALIDO - ' V1PROP-TIPO-ENDO */
                                _.Display($"TIPO DE ENDOSSO INVALIDO - {V1PROP_TIPO_ENDO}");

                                /*" -3396- GO TO R9999-00-ROT-ERRO. */

                                R9999_00_ROT_ERRO_SECTION(); //GOTO
                                return;
                            }

                        }

                    }

                }

            }


            /*" -3396- PERFORM R4700-00-UPDATE-NUMERO-AES. */

            R4700_00_UPDATE_NUMERO_AES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3211_99_SAIDA*/

        [StopWatch]
        /*" R3600-00-DECLARE-V1COBPROPINC-SECTION */
        private void R3600_00_DECLARE_V1COBPROPINC_SECTION()
        {
            /*" -3407- MOVE '360' TO WNR-EXEC-SQL. */
            _.Move("360", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3427- PERFORM R3600_00_DECLARE_V1COBPROPINC_DB_DECLARE_1 */

            R3600_00_DECLARE_V1COBPROPINC_DB_DECLARE_1();

            /*" -3429- PERFORM R3600_00_DECLARE_V1COBPROPINC_DB_OPEN_1 */

            R3600_00_DECLARE_V1COBPROPINC_DB_OPEN_1();

        }

        [StopWatch]
        /*" R3600-00-DECLARE-V1COBPROPINC-DB-OPEN-1 */
        public void R3600_00_DECLARE_V1COBPROPINC_DB_OPEN_1()
        {
            /*" -3429- EXEC SQL OPEN V1COBPROPINC END-EXEC. */

            V1COBPROPINC.Open();

        }

        [StopWatch]
        /*" R3910-00-SELECT-V1PRAZOCURTO-DB-DECLARE-1 */
        public void R3910_00_SELECT_V1PRAZOCURTO_DB_DECLARE_1()
        {
            /*" -3748- EXEC SQL DECLARE V1PRAZOCURTO CURSOR FOR SELECT PCTPRAZOVIG FROM SEGUROS.V1PRAZOCURTO WHERE RAMOFR = 11 AND QTD_DIAS_VIG >= :V1PRAC-QTD-DIAS AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */
            V1PRAZOCURTO = new EM0006B_V1PRAZOCURTO(true);
            string GetQuery_V1PRAZOCURTO()
            {
                var query = @$"SELECT 
							PCTPRAZOVIG 
							FROM 
							SEGUROS.V1PRAZOCURTO 
							WHERE RAMOFR = 11 
							AND QTD_DIAS_VIG >= '{V1PRAC_QTD_DIAS}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}'";

                return query;
            }
            V1PRAZOCURTO.GetQueryEvent += GetQuery_V1PRAZOCURTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3600_99_SAIDA*/

        [StopWatch]
        /*" R3610-00-FETCH-V1COBPROPINC-SECTION */
        private void R3610_00_FETCH_V1COBPROPINC_SECTION()
        {
            /*" -3440- MOVE '361' TO WNR-EXEC-SQL. */
            _.Move("361", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3451- PERFORM R3610_00_FETCH_V1COBPROPINC_DB_FETCH_1 */

            R3610_00_FETCH_V1COBPROPINC_DB_FETCH_1();

            /*" -3454- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3455- MOVE 'S' TO WFIM-V1COBPROPINC */
                _.Move("S", AREA_DE_WORK.WFIM_V1COBPROPINC);

                /*" -3455- PERFORM R3610_00_FETCH_V1COBPROPINC_DB_CLOSE_1 */

                R3610_00_FETCH_V1COBPROPINC_DB_CLOSE_1();

                /*" -3458- GO TO R3610-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3610_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3458- ADD +1 TO AC-L-V1COBPROPINC. */
            AREA_DE_WORK.AC_L_V1COBPROPINC.Value = AREA_DE_WORK.AC_L_V1COBPROPINC + +1;

        }

        [StopWatch]
        /*" R3610-00-FETCH-V1COBPROPINC-DB-FETCH-1 */
        public void R3610_00_FETCH_V1COBPROPINC_DB_FETCH_1()
        {
            /*" -3451- EXEC SQL FETCH V1COBPROPINC INTO :V1COBP-COD-EMPRESA, :V1COBP-FONTE, :V1COBP-NRPROPOS, :V1COBP-NUM-RISCO, :V1COBP-SUBRIS, :V1COBP-NRITEM, :V1COBP-CODCOBINC, :V1COBP-IMP-SEG-IX, :V1COBP-TIPCOBINC, :V1COBP-PRM-TAR-IX END-EXEC. */

            if (V1COBPROPINC.Fetch())
            {
                _.Move(V1COBPROPINC.V1COBP_COD_EMPRESA, V1COBP_COD_EMPRESA);
                _.Move(V1COBPROPINC.V1COBP_FONTE, V1COBP_FONTE);
                _.Move(V1COBPROPINC.V1COBP_NRPROPOS, V1COBP_NRPROPOS);
                _.Move(V1COBPROPINC.V1COBP_NUM_RISCO, V1COBP_NUM_RISCO);
                _.Move(V1COBPROPINC.V1COBP_SUBRIS, V1COBP_SUBRIS);
                _.Move(V1COBPROPINC.V1COBP_NRITEM, V1COBP_NRITEM);
                _.Move(V1COBPROPINC.V1COBP_CODCOBINC, V1COBP_CODCOBINC);
                _.Move(V1COBPROPINC.V1COBP_IMP_SEG_IX, V1COBP_IMP_SEG_IX);
                _.Move(V1COBPROPINC.V1COBP_TIPCOBINC, V1COBP_TIPCOBINC);
                _.Move(V1COBPROPINC.V1COBP_PRM_TAR_IX, V1COBP_PRM_TAR_IX);
            }

        }

        [StopWatch]
        /*" R3610-00-FETCH-V1COBPROPINC-DB-CLOSE-1 */
        public void R3610_00_FETCH_V1COBPROPINC_DB_CLOSE_1()
        {
            /*" -3455- EXEC SQL CLOSE V1COBPROPINC END-EXEC */

            V1COBPROPINC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3610_99_SAIDA*/

        [StopWatch]
        /*" R3800-00-MONTA-V0COBERINC-SECTION */
        private void R3800_00_MONTA_V0COBERINC_SECTION()
        {
            /*" -3469- MOVE '380' TO WNR-EXEC-SQL. */
            _.Move("380", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3471- MOVE 1 TO WS-OCORHIST. */
            _.Move(1, AREA_DE_WORK.WS_OCORHIST);

            /*" -3472- IF V1PROP-TPPROPOS EQUAL '2' OR '3' */

            if (V1PROP_TPPROPOS.In("2", "3"))
            {

                /*" -3474- PERFORM R3850-00-UPDATE-V0COBERINC. */

                R3850_00_UPDATE_V0COBERINC_SECTION();
            }


            /*" -3476- MOVE 11 TO V0COBI-COD-EMPRESA */
            _.Move(11, V0COBI_COD_EMPRESA);

            /*" -3477- MOVE V0ENDO-NUM-APOL TO V0COBI-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0COBI_NUM_APOL);

            /*" -3478- MOVE V0ENDO-NRENDOS TO V0COBI-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBI_NRENDOS);

            /*" -3479- MOVE V1COBP-NUM-RISCO TO V0COBI-NUM-RISCO */
            _.Move(V1COBP_NUM_RISCO, V0COBI_NUM_RISCO);

            /*" -3480- MOVE V1COBP-SUBRIS TO V0COBI-SUBRIS */
            _.Move(V1COBP_SUBRIS, V0COBI_SUBRIS);

            /*" -3481- MOVE V1COBP-NRITEM TO V0COBI-NRITEM */
            _.Move(V1COBP_NRITEM, V0COBI_NRITEM);

            /*" -3482- MOVE V1COBP-CODCOBINC TO V0COBI-CODCOBINC */
            _.Move(V1COBP_CODCOBINC, V0COBI_CODCOBINC);

            /*" -3483- MOVE V1COBP-IMP-SEG-IX TO V0COBI-IMP-SEG-IX */
            _.Move(V1COBP_IMP_SEG_IX, V0COBI_IMP_SEG_IX);

            /*" -3485- MOVE V1COBP-TIPCOBINC TO V0COBI-TIPCOBINC */
            _.Move(V1COBP_TIPCOBINC, V0COBI_TIPCOBINC);

            /*" -3486- IF V1COBP-CODCOBINC EQUAL '0' */

            if (V1COBP_CODCOBINC == "0")
            {

                /*" -3487- ADD V1COBP-IMP-SEG-IX TO W0COBA-IMP-SEG-IX */
                W0COBA_IMP_SEG_IX.Value = W0COBA_IMP_SEG_IX + V1COBP_IMP_SEG_IX;

                /*" -3489- ADD V1COBP-IMP-SEG-IX TO W0COBA-IMP-SEG-VR. */
                W0COBA_IMP_SEG_VR.Value = W0COBA_IMP_SEG_VR + V1COBP_IMP_SEG_IX;
            }


            /*" -3491- MOVE V1COBP-PRM-TAR-IX TO V0COBI-PRM-TAR-IX */
            _.Move(V1COBP_PRM_TAR_IX, V0COBI_PRM_TAR_IX);

            /*" -3492- IF V1PRIN-TIPRAZO NOT EQUAL 'N' */

            if (V1PRIN_TIPRAZO != "N")
            {

                /*" -3493- PERFORM R3900-00-CALC-PREMIO-ANUAL */

                R3900_00_CALC_PREMIO_ANUAL_SECTION();

                /*" -3494- ELSE */
            }
            else
            {


                /*" -3495- IF V1PROP-TPPROPOS EQUAL '2' OR '3' */

                if (V1PROP_TPPROPOS.In("2", "3"))
                {

                    /*" -3497- COMPUTE V0COBI-PRM-ANU-IX = V1COBP-PRM-TAR-IX + W1COBI-ANU-IX */
                    V0COBI_PRM_ANU_IX.Value = V1COBP_PRM_TAR_IX + W1COBI_ANU_IX;

                    /*" -3498- ELSE */
                }
                else
                {


                    /*" -3500- MOVE V1COBP-PRM-TAR-IX TO V0COBI-PRM-ANU-IX. */
                    _.Move(V1COBP_PRM_TAR_IX, V0COBI_PRM_ANU_IX);
                }

            }


            /*" -3502- MOVE V1COBP-PRM-TAR-IX TO V0COBI-PRM-TAR-VR */
            _.Move(V1COBP_PRM_TAR_IX, V0COBI_PRM_TAR_VR);

            /*" -3503- MOVE V0ENDO-DTINIVIG TO V0COBI-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0COBI_DTINIVIG);

            /*" -3504- MOVE V0ENDO-DTTERVIG TO V0COBI-DTTERVIG */
            _.Move(V0ENDO_DTTERVIG, V0COBI_DTTERVIG);

            /*" -3505- MOVE '0' TO V0COBI-SITUACAO. */
            _.Move("0", V0COBI_SITUACAO);

            /*" -3507- MOVE WS-OCORHIST TO V0COBI-OCORHIST. */
            _.Move(AREA_DE_WORK.WS_OCORHIST, V0COBI_OCORHIST);

            /*" -3508- ADD V1COBP-PRM-TAR-IX TO W0COBA-PRM-TAR-IX */
            W0COBA_PRM_TAR_IX.Value = W0COBA_PRM_TAR_IX + V1COBP_PRM_TAR_IX;

            /*" -3510- ADD V1COBP-PRM-TAR-IX TO W0COBA-PRM-TAR-VR */
            W0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR + V1COBP_PRM_TAR_IX;

            /*" -3513- MOVE '381' TO WNR-EXEC-SQL. */
            _.Move("381", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3532- PERFORM R3800_00_MONTA_V0COBERINC_DB_INSERT_1 */

            R3800_00_MONTA_V0COBERINC_DB_INSERT_1();

            /*" -3535- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3541- DISPLAY '(REGISTRO DUPLICADO) ... ' ' ' V0COBI-NUM-APOL ' ' V0COBI-NRENDOS ' ' V0COBI-NUM-RISCO ' ' V0COBI-SUBRIS ' ' V0COBI-NRITEM */

                $"(REGISTRO DUPLICADO) ...  {V0COBI_NUM_APOL} {V0COBI_NRENDOS} {V0COBI_NUM_RISCO} {V0COBI_SUBRIS} {V0COBI_NRITEM}"
                .Display();

                /*" -3543- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3544- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3550- DISPLAY '(PROBLEMAS NA INSERCAO) ... ' ' ' V0COBI-NUM-APOL ' ' V0COBI-NRENDOS ' ' V0COBI-NUM-RISCO ' ' V0COBI-SUBRIS ' ' V0COBI-NRITEM */

                $"(PROBLEMAS NA INSERCAO) ...  {V0COBI_NUM_APOL} {V0COBI_NRENDOS} {V0COBI_NUM_RISCO} {V0COBI_SUBRIS} {V0COBI_NRITEM}"
                .Display();

                /*" -3552- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3554- ADD +1 TO AC-I-V0COBERINC. */
            AREA_DE_WORK.AC_I_V0COBERINC.Value = AREA_DE_WORK.AC_I_V0COBERINC + +1;

            /*" -3554- PERFORM R3610-00-FETCH-V1COBPROPINC. */

            R3610_00_FETCH_V1COBPROPINC_SECTION();

        }

        [StopWatch]
        /*" R3800-00-MONTA-V0COBERINC-DB-INSERT-1 */
        public void R3800_00_MONTA_V0COBERINC_DB_INSERT_1()
        {
            /*" -3532- EXEC SQL INSERT INTO SEGUROS.V0COBERINC VALUES (:V0COBI-COD-EMPRESA , :V0COBI-NUM-APOL , :V0COBI-NRENDOS , :V0COBI-NUM-RISCO , :V0COBI-SUBRIS , :V0COBI-NRITEM , :V0COBI-CODCOBINC , :V0COBI-IMP-SEG-IX , :V0COBI-TIPCOBINC , :V0COBI-PRM-TAR-IX , :V0COBI-PRM-ANU-IX , :V0COBI-PRM-TAR-VR , :V0COBI-DTINIVIG , :V0COBI-DTTERVIG , :V0COBI-SITUACAO , CURRENT TIMESTAMP , :V0COBI-OCORHIST) END-EXEC. */

            var r3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1 = new R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1()
            {
                V0COBI_COD_EMPRESA = V0COBI_COD_EMPRESA.ToString(),
                V0COBI_NUM_APOL = V0COBI_NUM_APOL.ToString(),
                V0COBI_NRENDOS = V0COBI_NRENDOS.ToString(),
                V0COBI_NUM_RISCO = V0COBI_NUM_RISCO.ToString(),
                V0COBI_SUBRIS = V0COBI_SUBRIS.ToString(),
                V0COBI_NRITEM = V0COBI_NRITEM.ToString(),
                V0COBI_CODCOBINC = V0COBI_CODCOBINC.ToString(),
                V0COBI_IMP_SEG_IX = V0COBI_IMP_SEG_IX.ToString(),
                V0COBI_TIPCOBINC = V0COBI_TIPCOBINC.ToString(),
                V0COBI_PRM_TAR_IX = V0COBI_PRM_TAR_IX.ToString(),
                V0COBI_PRM_ANU_IX = V0COBI_PRM_ANU_IX.ToString(),
                V0COBI_PRM_TAR_VR = V0COBI_PRM_TAR_VR.ToString(),
                V0COBI_DTINIVIG = V0COBI_DTINIVIG.ToString(),
                V0COBI_DTTERVIG = V0COBI_DTTERVIG.ToString(),
                V0COBI_SITUACAO = V0COBI_SITUACAO.ToString(),
                V0COBI_OCORHIST = V0COBI_OCORHIST.ToString(),
            };

            R3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1.Execute(r3800_00_MONTA_V0COBERINC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3800_99_SAIDA*/

        [StopWatch]
        /*" R3850-00-UPDATE-V0COBERINC-SECTION */
        private void R3850_00_UPDATE_V0COBERINC_SECTION()
        {
            /*" -3565- MOVE '385' TO WNR-EXEC-SQL. */
            _.Move("385", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3581- PERFORM R3850_00_UPDATE_V0COBERINC_DB_SELECT_1 */

            R3850_00_UPDATE_V0COBERINC_DB_SELECT_1();

            /*" -3584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3585- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3586- MOVE +0 TO W1COBI-ANU-IX */
                    _.Move(+0, W1COBI_ANU_IX);

                    /*" -3587- GO TO R3850-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_99_SAIDA*/ //GOTO
                    return;

                    /*" -3588- ELSE */
                }
                else
                {


                    /*" -3595- DISPLAY 'PROBLEMAS NO SELECT (V1COBERINC) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V1COBP-NUM-RISCO ' ' V1COBP-SUBRIS ' ' V1COBP-NRITEM ' ' V1COBP-CODCOBINC */

                    $"PROBLEMAS NO SELECT (V1COBERINC) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V1COBP_NUM_RISCO} {V1COBP_SUBRIS} {V1COBP_NRITEM} {V1COBP_CODCOBINC}"
                    .Display();

                    /*" -3598- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3610- PERFORM R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1 */

            R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1();

            /*" -3613- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3614- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3615- GO TO R3850-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_99_SAIDA*/ //GOTO
                    return;

                    /*" -3616- ELSE */
                }
                else
                {


                    /*" -3623- DISPLAY 'PROBLEMAS NO UPDATE (V0COBERINC) ... ' ' ' V0ENDO-NUM-APOL ' ' V0ENDO-NRENDOS ' ' V1COBP-NUM-RISCO ' ' V1COBP-SUBRIS ' ' V1COBP-NRITEM ' ' V1COBP-CODCOBINC */

                    $"PROBLEMAS NO UPDATE (V0COBERINC) ...  {V0ENDO_NUM_APOL} {V0ENDO_NRENDOS} {V1COBP_NUM_RISCO} {V1COBP_SUBRIS} {V1COBP_NRITEM} {V1COBP_CODCOBINC}"
                    .Display();

                    /*" -3625- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3625- COMPUTE WS-OCORHIST = V1COBI-OCORHIST + 1. */
            AREA_DE_WORK.WS_OCORHIST.Value = V1COBI_OCORHIST + 1;

        }

        [StopWatch]
        /*" R3850-00-UPDATE-V0COBERINC-DB-SELECT-1 */
        public void R3850_00_UPDATE_V0COBERINC_DB_SELECT_1()
        {
            /*" -3581- EXEC SQL SELECT OCORHIST, PRM_ANUAL_IX INTO :V1COBI-OCORHIST, :W1COBI-ANU-IX FROM SEGUROS.V1COBERINC WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NUM_RISCO = :V1COBP-NUM-RISCO AND SUBRIS = :V1COBP-SUBRIS AND NRITEM = :V1COBP-NRITEM AND TIPOCOBINC = :V1COBP-TIPCOBINC AND CODCOBINC = :V1COBP-CODCOBINC AND SITUACAO = '0' END-EXEC. */

            var r3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1 = new R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1()
            {
                V1COBP_NUM_RISCO = V1COBP_NUM_RISCO.ToString(),
                V1COBP_TIPCOBINC = V1COBP_TIPCOBINC.ToString(),
                V1COBP_CODCOBINC = V1COBP_CODCOBINC.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1COBP_SUBRIS = V1COBP_SUBRIS.ToString(),
                V1COBP_NRITEM = V1COBP_NRITEM.ToString(),
            };

            var executed_1 = R3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1.Execute(r3850_00_UPDATE_V0COBERINC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1COBI_OCORHIST, V1COBI_OCORHIST);
                _.Move(executed_1.W1COBI_ANU_IX, W1COBI_ANU_IX);
            }


        }

        [StopWatch]
        /*" R3850-00-UPDATE-V0COBERINC-DB-UPDATE-1 */
        public void R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1()
        {
            /*" -3610- EXEC SQL UPDATE SEGUROS.V0COBERINC SET SITUACAO = '1' WHERE NUM_APOLICE = :V0ENDO-NUM-APOL AND NUM_RISCO = :V1COBP-NUM-RISCO AND SUBRIS = :V1COBP-SUBRIS AND NRITEM = :V1COBP-NRITEM AND TIPOCOBINC = :V1COBP-TIPCOBINC AND CODCOBINC = :V1COBP-CODCOBINC AND OCORHIST = :V1COBI-OCORHIST AND SITUACAO = '0' END-EXEC. */

            var r3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1 = new R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1()
            {
                V1COBP_NUM_RISCO = V1COBP_NUM_RISCO.ToString(),
                V1COBP_TIPCOBINC = V1COBP_TIPCOBINC.ToString(),
                V1COBP_CODCOBINC = V1COBP_CODCOBINC.ToString(),
                V0ENDO_NUM_APOL = V0ENDO_NUM_APOL.ToString(),
                V1COBI_OCORHIST = V1COBI_OCORHIST.ToString(),
                V1COBP_SUBRIS = V1COBP_SUBRIS.ToString(),
                V1COBP_NRITEM = V1COBP_NRITEM.ToString(),
            };

            R3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1.Execute(r3850_00_UPDATE_V0COBERINC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3850_99_SAIDA*/

        [StopWatch]
        /*" R3900-00-CALC-PREMIO-ANUAL-SECTION */
        private void R3900_00_CALC_PREMIO_ANUAL_SECTION()
        {
            /*" -3638- MOVE '390' TO WNR-EXEC-SQL. */
            _.Move("390", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3643- MOVE ZEROS TO WS-COEFPRAZO W0COBI-PRM-ANU-IX. */
            _.Move(0, AREA_DE_WORK.WS_COEFPRAZO, W0COBI_PRM_ANU_IX);

            /*" -3644- IF V1PRIN-TIPRAZO EQUAL 'C' */

            if (V1PRIN_TIPRAZO == "C")
            {

                /*" -3645- MOVE V0ENDO-DTTERVIG TO WDATA-SQL */
                _.Move(V0ENDO_DTTERVIG, AREA_DE_WORK.WDATA_SQL);

                /*" -3646- MOVE WDAT-DIA-SQL TO WDAT1-DIA */
                _.Move(AREA_DE_WORK.FILLER_1.WDAT_DIA_SQL, WAREA.FILLER_14.WDAT1_DIA);

                /*" -3647- MOVE WDAT-MES-SQL TO WDAT1-MES */
                _.Move(AREA_DE_WORK.FILLER_1.WDAT_MES_SQL, WAREA.FILLER_14.WDAT1_MES);

                /*" -3649- MOVE WDAT-ANO-SQL TO WDAT1-ANO */
                _.Move(AREA_DE_WORK.FILLER_1.WDAT_ANO_SQL, WAREA.FILLER_14.WDAT1_ANO);

                /*" -3650- MOVE V0ENDO-DTINIVIG TO WDATA-SQL */
                _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WDATA_SQL);

                /*" -3651- MOVE WDAT-DIA-SQL TO WDAT2-DIA */
                _.Move(AREA_DE_WORK.FILLER_1.WDAT_DIA_SQL, WAREA.FILLER_15.WDAT2_DIA);

                /*" -3652- MOVE WDAT-MES-SQL TO WDAT2-MES */
                _.Move(AREA_DE_WORK.FILLER_1.WDAT_MES_SQL, WAREA.FILLER_15.WDAT2_MES);

                /*" -3654- MOVE WDAT-ANO-SQL TO WDAT2-ANO */
                _.Move(AREA_DE_WORK.FILLER_1.WDAT_ANO_SQL, WAREA.FILLER_15.WDAT2_ANO);

                /*" -3658- CALL 'PRODIFC1' USING WDATA1 WDATA2 QTDIA */
                _.Call("PRODIFC1", WAREA);

                /*" -3660- MOVE QTDIA TO V1PRAC-QTD-DIAS */
                _.Move(WAREA.QTDIA, V1PRAC_QTD_DIAS);

                /*" -3662- DISPLAY 'V1PRACQTDIAS  = ' V1PRAC-QTD-DIAS */
                _.Display($"V1PRACQTDIAS  = {V1PRAC_QTD_DIAS}");

                /*" -3664- PERFORM R3910-00-SELECT-V1PRAZOCURTO */

                R3910_00_SELECT_V1PRAZOCURTO_SECTION();

                /*" -3667- COMPUTE V0COBI-PRM-ANU-IX = V1COBP-PRM-TAR-IX / WS-COEFPRAZO */
                V0COBI_PRM_ANU_IX.Value = V1COBP_PRM_TAR_IX / AREA_DE_WORK.WS_COEFPRAZO;

                /*" -3671- ELSE */
            }
            else
            {


                /*" -3672- IF V1PRIN-TIPRAZO EQUAL 'L' */

                if (V1PRIN_TIPRAZO == "L")
                {

                    /*" -3673- MOVE V0ENDO-DTTERVIG TO WDATA-SQL */
                    _.Move(V0ENDO_DTTERVIG, AREA_DE_WORK.WDATA_SQL);

                    /*" -3674- MOVE WDAT-DIA-SQL TO WDAT1-DIA */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_DIA_SQL, WAREA.FILLER_14.WDAT1_DIA);

                    /*" -3675- MOVE WDAT-MES-SQL TO WDAT1-MES */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_MES_SQL, WAREA.FILLER_14.WDAT1_MES);

                    /*" -3677- MOVE WDAT-ANO-SQL TO WDAT1-ANO */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_ANO_SQL, WAREA.FILLER_14.WDAT1_ANO);

                    /*" -3678- MOVE V0ENDO-DTINIVIG TO WDATA-SQL */
                    _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WDATA_SQL);

                    /*" -3679- MOVE WDAT-DIA-SQL TO WDAT2-DIA */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_DIA_SQL, WAREA.FILLER_15.WDAT2_DIA);

                    /*" -3680- MOVE WDAT-MES-SQL TO WDAT2-MES */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_MES_SQL, WAREA.FILLER_15.WDAT2_MES);

                    /*" -3682- MOVE WDAT-ANO-SQL TO WDAT2-ANO */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_ANO_SQL, WAREA.FILLER_15.WDAT2_ANO);

                    /*" -3686- CALL 'PRODIFC1' USING WDATA1 WDATA2 QTDIA */
                    _.Call("PRODIFC1", WAREA);

                    /*" -3689- COMPUTE WS-QTD-MES = QTDIA / 30 */
                    AREA_DE_WORK.WS_QTD_MES.Value = WAREA.QTDIA / 30;

                    /*" -3691- MOVE WS-QTD-MES TO V1PRAL-QTD-MES */
                    _.Move(AREA_DE_WORK.WS_QTD_MES, V1PRAL_QTD_MES);

                    /*" -3693- DISPLAY 'V1PRALQTDMES  = ' V1PRAL-QTD-MES */
                    _.Display($"V1PRALQTDMES  = {V1PRAL_QTD_MES}");

                    /*" -3695- PERFORM R3920-00-SELECT-V1PRAZOLONGO */

                    R3920_00_SELECT_V1PRAZOLONGO_SECTION();

                    /*" -3697- COMPUTE V0COBI-PRM-ANU-IX = V1COBP-PRM-TAR-IX / WS-COEFPRAZO */
                    V0COBI_PRM_ANU_IX.Value = V1COBP_PRM_TAR_IX / AREA_DE_WORK.WS_COEFPRAZO;

                    /*" -3701- ELSE */
                }
                else
                {


                    /*" -3702- MOVE V0ENDO-DTTERVIG TO WDATA-SQL */
                    _.Move(V0ENDO_DTTERVIG, AREA_DE_WORK.WDATA_SQL);

                    /*" -3703- MOVE WDAT-DIA-SQL TO WDAT1-DIA */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_DIA_SQL, WAREA.FILLER_14.WDAT1_DIA);

                    /*" -3704- MOVE WDAT-MES-SQL TO WDAT1-MES */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_MES_SQL, WAREA.FILLER_14.WDAT1_MES);

                    /*" -3706- MOVE WDAT-ANO-SQL TO WDAT1-ANO */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_ANO_SQL, WAREA.FILLER_14.WDAT1_ANO);

                    /*" -3707- MOVE V0ENDO-DTINIVIG TO WDATA-SQL */
                    _.Move(V0ENDO_DTINIVIG, AREA_DE_WORK.WDATA_SQL);

                    /*" -3708- MOVE WDAT-DIA-SQL TO WDAT2-DIA */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_DIA_SQL, WAREA.FILLER_15.WDAT2_DIA);

                    /*" -3709- MOVE WDAT-MES-SQL TO WDAT2-MES */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_MES_SQL, WAREA.FILLER_15.WDAT2_MES);

                    /*" -3711- MOVE WDAT-ANO-SQL TO WDAT2-ANO */
                    _.Move(AREA_DE_WORK.FILLER_1.WDAT_ANO_SQL, WAREA.FILLER_15.WDAT2_ANO);

                    /*" -3715- CALL 'PRODIFC1' USING WDATA1 WDATA2 QTDIA */
                    _.Call("PRODIFC1", WAREA);

                    /*" -3718- COMPUTE W0COBI-PRM-ANU-IX = V0COBI-PRM-TAR-IX / QTDIA */
                    W0COBI_PRM_ANU_IX.Value = V0COBI_PRM_TAR_IX / WAREA.QTDIA;

                    /*" -3721- COMPUTE W0COBI-PRM-ANU-IX = W0COBI-PRM-ANU-IX * 365 */
                    W0COBI_PRM_ANU_IX.Value = W0COBI_PRM_ANU_IX * 365;

                    /*" -3723- MOVE W0COBI-PRM-ANU-IX TO V0COBI-PRM-ANU-IX. */
                    _.Move(W0COBI_PRM_ANU_IX, V0COBI_PRM_ANU_IX);
                }

            }


            /*" -3724- IF V1PROP-TPPROPOS EQUAL '2' OR '3' */

            if (V1PROP_TPPROPOS.In("2", "3"))
            {

                /*" -3725- COMPUTE V0COBI-PRM-ANU-IX = V0COBI-PRM-ANU-IX + W1COBI-ANU-IX. */
                V0COBI_PRM_ANU_IX.Value = V0COBI_PRM_ANU_IX + W1COBI_ANU_IX;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3900_99_SAIDA*/

        [StopWatch]
        /*" R3910-00-SELECT-V1PRAZOCURTO-SECTION */
        private void R3910_00_SELECT_V1PRAZOCURTO_SECTION()
        {
            /*" -3738- MOVE '391' TO WNR-EXEC-SQL. */
            _.Move("391", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3748- PERFORM R3910_00_SELECT_V1PRAZOCURTO_DB_DECLARE_1 */

            R3910_00_SELECT_V1PRAZOCURTO_DB_DECLARE_1();

            /*" -3751- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3754- DISPLAY 'PROBLEMAS NO SELECT (V1PRAZOCURTO) ... ' ' ' V1PRAC-QTD-DIAS ' ' V0ENDO-DTINIVIG */

                $"PROBLEMAS NO SELECT (V1PRAZOCURTO) ...  {V1PRAC_QTD_DIAS} {V0ENDO_DTINIVIG}"
                .Display();

                /*" -3756- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3756- PERFORM R3910_00_SELECT_V1PRAZOCURTO_DB_OPEN_1 */

            R3910_00_SELECT_V1PRAZOCURTO_DB_OPEN_1();

            /*" -3762- PERFORM R3910_00_SELECT_V1PRAZOCURTO_DB_FETCH_1 */

            R3910_00_SELECT_V1PRAZOCURTO_DB_FETCH_1();

            /*" -3765- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3768- DISPLAY 'PROBLEMAS NO SELECT (V1PRAZOCURTO) ... ' ' ' V1PRAC-QTD-DIAS ' ' V0ENDO-DTINIVIG */

                $"PROBLEMAS NO SELECT (V1PRAZOCURTO) ...  {V1PRAC_QTD_DIAS} {V0ENDO_DTINIVIG}"
                .Display();

                /*" -3770- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3773- COMPUTE WS-COEFPRAZO = V1PRAC-PCTPRAZOVIG / 100. */
            AREA_DE_WORK.WS_COEFPRAZO.Value = V1PRAC_PCTPRAZOVIG / 100f;

            /*" -3773- PERFORM R3910_00_SELECT_V1PRAZOCURTO_DB_CLOSE_1 */

            R3910_00_SELECT_V1PRAZOCURTO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R3910-00-SELECT-V1PRAZOCURTO-DB-OPEN-1 */
        public void R3910_00_SELECT_V1PRAZOCURTO_DB_OPEN_1()
        {
            /*" -3756- EXEC SQL OPEN V1PRAZOCURTO END-EXEC. */

            V1PRAZOCURTO.Open();

        }

        [StopWatch]
        /*" R3920-00-SELECT-V1PRAZOLONGO-DB-DECLARE-1 */
        public void R3920_00_SELECT_V1PRAZOLONGO_DB_DECLARE_1()
        {
            /*" -3796- EXEC SQL DECLARE V1PRAZOLONGO CURSOR FOR SELECT PCTPRAZOVIG FROM SEGUROS.V1PRAZOLONGO WHERE RAMOFR = 11 AND QTD_MESES_VIG >= :V1PRAL-QTD-MES AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG END-EXEC. */
            V1PRAZOLONGO = new EM0006B_V1PRAZOLONGO(true);
            string GetQuery_V1PRAZOLONGO()
            {
                var query = @$"SELECT 
							PCTPRAZOVIG 
							FROM 
							SEGUROS.V1PRAZOLONGO 
							WHERE RAMOFR = 11 
							AND QTD_MESES_VIG >= '{V1PRAL_QTD_MES}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}'";

                return query;
            }
            V1PRAZOLONGO.GetQueryEvent += GetQuery_V1PRAZOLONGO;

        }

        [StopWatch]
        /*" R3910-00-SELECT-V1PRAZOCURTO-DB-FETCH-1 */
        public void R3910_00_SELECT_V1PRAZOCURTO_DB_FETCH_1()
        {
            /*" -3762- EXEC SQL FETCH V1PRAZOCURTO INTO :V1PRAC-PCTPRAZOVIG END-EXEC. */

            if (V1PRAZOCURTO.Fetch())
            {
                _.Move(V1PRAZOCURTO.V1PRAC_PCTPRAZOVIG, V1PRAC_PCTPRAZOVIG);
            }

        }

        [StopWatch]
        /*" R3910-00-SELECT-V1PRAZOCURTO-DB-CLOSE-1 */
        public void R3910_00_SELECT_V1PRAZOCURTO_DB_CLOSE_1()
        {
            /*" -3773- EXEC SQL CLOSE V1PRAZOCURTO END-EXEC. */

            V1PRAZOCURTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3910_99_SAIDA*/

        [StopWatch]
        /*" R3920-00-SELECT-V1PRAZOLONGO-SECTION */
        private void R3920_00_SELECT_V1PRAZOLONGO_SECTION()
        {
            /*" -3786- MOVE '392' TO WNR-EXEC-SQL. */
            _.Move("392", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3796- PERFORM R3920_00_SELECT_V1PRAZOLONGO_DB_DECLARE_1 */

            R3920_00_SELECT_V1PRAZOLONGO_DB_DECLARE_1();

            /*" -3799- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3802- DISPLAY 'PROBLEMAS NO SELECT (V1PRAZOLONGO) ... ' ' ' V1PRAC-QTD-DIAS ' ' V0ENDO-DTINIVIG */

                $"PROBLEMAS NO SELECT (V1PRAZOLONGO) ...  {V1PRAC_QTD_DIAS} {V0ENDO_DTINIVIG}"
                .Display();

                /*" -3804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3804- PERFORM R3920_00_SELECT_V1PRAZOLONGO_DB_OPEN_1 */

            R3920_00_SELECT_V1PRAZOLONGO_DB_OPEN_1();

            /*" -3810- PERFORM R3920_00_SELECT_V1PRAZOLONGO_DB_FETCH_1 */

            R3920_00_SELECT_V1PRAZOLONGO_DB_FETCH_1();

            /*" -3813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3816- DISPLAY 'PROBLEMAS NO SELECT (V1PRAZOLONGO) ... ' ' ' V1PRAC-QTD-DIAS ' ' V0ENDO-DTINIVIG */

                $"PROBLEMAS NO SELECT (V1PRAZOLONGO) ...  {V1PRAC_QTD_DIAS} {V0ENDO_DTINIVIG}"
                .Display();

                /*" -3818- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3821- COMPUTE WS-COEFPRAZO = V1PRAL-PCTPRAZOVIG / 100. */
            AREA_DE_WORK.WS_COEFPRAZO.Value = V1PRAL_PCTPRAZOVIG / 100f;

            /*" -3821- PERFORM R3920_00_SELECT_V1PRAZOLONGO_DB_CLOSE_1 */

            R3920_00_SELECT_V1PRAZOLONGO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R3920-00-SELECT-V1PRAZOLONGO-DB-OPEN-1 */
        public void R3920_00_SELECT_V1PRAZOLONGO_DB_OPEN_1()
        {
            /*" -3804- EXEC SQL OPEN V1PRAZOLONGO END-EXEC. */

            V1PRAZOLONGO.Open();

        }

        [StopWatch]
        /*" R4800-00-ACESSA-V1ACOMPROP-DB-DECLARE-1 */
        public void R4800_00_ACESSA_V1ACOMPROP_DB_DECLARE_1()
        {
            /*" -4022- EXEC SQL DECLARE V1ACOMPROP CURSOR FOR SELECT DATOPR , HORAOPER FROM SEGUROS.V1ACOMPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS AND OPERACAO = 9010 ORDER BY HORAOPER DESC END-EXEC. */
            V1ACOMPROP = new EM0006B_V1ACOMPROP(true);
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

        [StopWatch]
        /*" R3920-00-SELECT-V1PRAZOLONGO-DB-FETCH-1 */
        public void R3920_00_SELECT_V1PRAZOLONGO_DB_FETCH_1()
        {
            /*" -3810- EXEC SQL FETCH V1PRAZOLONGO INTO :V1PRAL-PCTPRAZOVIG END-EXEC. */

            if (V1PRAZOLONGO.Fetch())
            {
                _.Move(V1PRAZOLONGO.V1PRAL_PCTPRAZOVIG, V1PRAL_PCTPRAZOVIG);
            }

        }

        [StopWatch]
        /*" R3920-00-SELECT-V1PRAZOLONGO-DB-CLOSE-1 */
        public void R3920_00_SELECT_V1PRAZOLONGO_DB_CLOSE_1()
        {
            /*" -3821- EXEC SQL CLOSE V1PRAZOLONGO END-EXEC. */

            V1PRAZOLONGO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3920_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-COBERTURA-APOL-SECTION */
        private void R4000_00_TRATA_COBERTURA_APOL_SECTION()
        {
            /*" -3834- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3836- MOVE 11 TO V0COBA-COD-EMPRESA */
            _.Move(11, V0COBA_COD_EMPRESA);

            /*" -3837- MOVE V0ENDO-NUM-APOL TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0COBA_NUM_APOL);

            /*" -3838- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -3839- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -3840- MOVE V1PROP-RAMO TO V0COBA-RAMOFR */
            _.Move(V1PROP_RAMO, V0COBA_RAMOFR);

            /*" -3841- MOVE V1PROP-MODALIDA TO V0COBA-MODALIFR */
            _.Move(V1PROP_MODALIDA, V0COBA_MODALIFR);

            /*" -3842- MOVE 1 TO V0COBA-OCORHIST */
            _.Move(1, V0COBA_OCORHIST);

            /*" -3843- MOVE ZEROS TO V0COBA-COD-COBER */
            _.Move(0, V0COBA_COD_COBER);

            /*" -3844- MOVE W0COBA-IMP-SEG-IX TO V0COBA-IMP-SEG-IX */
            _.Move(W0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_IX);

            /*" -3845- MOVE W0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-IX */
            _.Move(W0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_IX);

            /*" -3846- MOVE W0COBA-IMP-SEG-VR TO V0COBA-IMP-SEG-VR */
            _.Move(W0COBA_IMP_SEG_VR, V0COBA_IMP_SEG_VR);

            /*" -3847- MOVE W0COBA-PRM-TAR-VR TO V0COBA-PRM-TAR-VR */
            _.Move(W0COBA_PRM_TAR_VR, V0COBA_PRM_TAR_VR);

            /*" -3848- MOVE V0ENDO-DTINIVIG TO V0COBA-DTINIVIG */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DTINIVIG);

            /*" -3850- MOVE V0ENDO-DTTERVIG TO V0COBA-DTTERVIG. */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DTTERVIG);

            /*" -3852- MOVE 100 TO V0COBA-PCT-COBERT */
            _.Move(100, V0COBA_PCT_COBERT);

            /*" -3853- IF V0COBA-IMP-SEG-VR LESS ZEROS */

            if (V0COBA_IMP_SEG_VR < 00)
            {

                /*" -3856- COMPUTE V0COBA-IMP-SEG-VR = W0COBA-IMP-SEG-VR * -1. */
                V0COBA_IMP_SEG_VR.Value = W0COBA_IMP_SEG_VR * -1;
            }


            /*" -3857- IF V0COBA-PRM-TAR-VR LESS ZEROS */

            if (V0COBA_PRM_TAR_VR < 00)
            {

                /*" -3860- COMPUTE V0COBA-PRM-TAR-VR = W0COBA-PRM-TAR-VR * -1. */
                V0COBA_PRM_TAR_VR.Value = W0COBA_PRM_TAR_VR * -1;
            }


            /*" -3861- IF V1PROP-TIPO-ENDO EQUAL '4' */

            if (V1PROP_TIPO_ENDO == "4")
            {

                /*" -3862- MOVE ZEROS TO V0COBA-IMP-SEG-IX */
                _.Move(0, V0COBA_IMP_SEG_IX);

                /*" -3863- MOVE ZEROS TO V0COBA-PRM-TAR-IX */
                _.Move(0, V0COBA_PRM_TAR_IX);

                /*" -3864- MOVE ZEROS TO V0COBA-IMP-SEG-VR */
                _.Move(0, V0COBA_IMP_SEG_VR);

                /*" -3866- MOVE ZEROS TO V0COBA-PRM-TAR-VR. */
                _.Move(0, V0COBA_PRM_TAR_VR);
            }


            /*" -3867- MOVE 1 TO V0COBA-FATOR-MULT. */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -3869- MOVE '0' TO V0COBA-SITREG. */
            _.Move("0", V0COBA_SITREG);

            /*" -3871- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3891- PERFORM R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1 */

            R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1();

            /*" -3894- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -3900- DISPLAY 'R4000-00 (REGISTRO DUPLICADO) ... ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM '  ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4000-00 (REGISTRO DUPLICADO) ... {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3902- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3903- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3909- DISPLAY 'R4000-00 (PROBLEMAS NA INSERCAO) ... ' V0COBA-NUM-APOL ' ' V0COBA-NRENDOS ' ' V0COBA-NUM-ITEM '  ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4000-00 (PROBLEMAS NA INSERCAO) ... {V0COBA_NUM_APOL} {V0COBA_NRENDOS} {V0COBA_NUM_ITEM} {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -3911- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3913- MOVE '*' TO CH-I-V0COBERAPOL */
            _.Move("*", AREA_DE_WORK.CH_I_V0COBERAPOL);

            /*" -3913- ADD +1 TO AC-I-V0COBERAPOL. */
            AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;

        }

        [StopWatch]
        /*" R4000-00-TRATA-COBERTURA-APOL-DB-INSERT-1 */
        public void R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1()
        {
            /*" -3891- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DTINIVIG , :V0COBA-DTTERVIG , :V0COBA-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP , :V0COBA-SITREG) END-EXEC. */

            var r4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1 = new R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1()
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
                V0COBA_DTINIVIG = V0COBA_DTINIVIG.ToString(),
                V0COBA_DTTERVIG = V0COBA_DTTERVIG.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
                V0COBA_SITREG = V0COBA_SITREG.ToString(),
            };

            R4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1.Execute(r4000_00_TRATA_COBERTURA_APOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-UPDATE-V0APOLICE-SECTION */
        private void R4300_00_UPDATE_V0APOLICE_SECTION()
        {
            /*" -3924- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3933- PERFORM R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1 */

            R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1();

            /*" -3936- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3938- DISPLAY 'R4200-00 (PROBLEMAS UPDATE V0APOLICE) ... ' ' ' V0APOL-NUM-APOL */

                $"R4200-00 (PROBLEMAS UPDATE V0APOLICE) ...  {V0APOL_NUM_APOL}"
                .Display();

                /*" -3938- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4300-00-UPDATE-V0APOLICE-DB-UPDATE-1 */
        public void R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1()
        {
            /*" -3933- EXEC SQL UPDATE SEGUROS.V0APOLICE SET PCTCED = :W0APOL-PCTCED, QTCOSSEG = :W0APOL-QTCOSSEG, CODCLIEN = :V1PROP-CODCLIEN, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0APOL-NUM-APOL END-EXEC. */

            var r4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1 = new R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1()
            {
                W0APOL_QTCOSSEG = W0APOL_QTCOSSEG.ToString(),
                V1PROP_CODCLIEN = V1PROP_CODCLIEN.ToString(),
                W0APOL_PCTCED = W0APOL_PCTCED.ToString(),
                V0APOL_NUM_APOL = V0APOL_NUM_APOL.ToString(),
            };

            R4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1.Execute(r4300_00_UPDATE_V0APOLICE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4600-00-SELECT-NUMERO-AES-SECTION */
        private void R4600_00_SELECT_NUMERO_AES_SECTION()
        {
            /*" -3949- MOVE '460' TO WNR-EXEC-SQL. */
            _.Move("460", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3967- PERFORM R4600_00_SELECT_NUMERO_AES_DB_SELECT_1 */

            R4600_00_SELECT_NUMERO_AES_DB_SELECT_1();

            /*" -3970- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3974- DISPLAY 'R4600-00 (NAO EXISTE NA V1NUMERO-AES) ... ' ' ' V1PROP-NRPROPOS ' ' V1PROP-FONTE ' ' V1PROP-RAMO */

                $"R4600-00 (NAO EXISTE NA V1NUMERO-AES) ...  {V1PROP_NRPROPOS} {V1PROP_FONTE} {V1PROP_RAMO}"
                .Display();

                /*" -3974- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4600-00-SELECT-NUMERO-AES-DB-SELECT-1 */
        public void R4600_00_SELECT_NUMERO_AES_DB_SELECT_1()
        {
            /*" -3967- EXEC SQL SELECT SEQ_APOLICE, ENDOSCOB , NRENDOCA , ENDOSRES , ENDOSSEM , ENDOSCCR , ENDOSMVC INTO :V0NAES-SEQ-APOL , :V0NAES-ENDOSCOB , :V0NAES-NRENDOCA , :V0NAES-ENDOSRES , :V0NAES-ENDOSSEM , :V0NAES-ENDOSCCR , :V0NAES-ENDOSMVC FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V1FONT-ORGAOEMIS AND COD_RAMO = :V1PROP-RAMO END-EXEC. */

            var r4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1 = new R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1()
            {
                V1FONT_ORGAOEMIS = V1FONT_ORGAOEMIS.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            var executed_1 = R4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1.Execute(r4600_00_SELECT_NUMERO_AES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NAES_SEQ_APOL, V0NAES_SEQ_APOL);
                _.Move(executed_1.V0NAES_ENDOSCOB, V0NAES_ENDOSCOB);
                _.Move(executed_1.V0NAES_NRENDOCA, V0NAES_NRENDOCA);
                _.Move(executed_1.V0NAES_ENDOSRES, V0NAES_ENDOSRES);
                _.Move(executed_1.V0NAES_ENDOSSEM, V0NAES_ENDOSSEM);
                _.Move(executed_1.V0NAES_ENDOSCCR, V0NAES_ENDOSCCR);
                _.Move(executed_1.V0NAES_ENDOSMVC, V0NAES_ENDOSMVC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4600_99_SAIDA*/

        [StopWatch]
        /*" R4700-00-UPDATE-NUMERO-AES-SECTION */
        private void R4700_00_UPDATE_NUMERO_AES_SECTION()
        {
            /*" -3985- MOVE '470' TO WNR-EXEC-SQL. */
            _.Move("470", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3997- PERFORM R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1 */

            R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1();

            /*" -4000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4003- DISPLAY 'R4700-00 (PROBLEMAS UPDATE NUMERO-AES) ... ' ' ' V1FONT-ORGAOEMIS ' ' V1PROP-RAMO */

                $"R4700-00 (PROBLEMAS UPDATE NUMERO-AES) ...  {V1FONT_ORGAOEMIS} {V1PROP_RAMO}"
                .Display();

                /*" -4003- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4700-00-UPDATE-NUMERO-AES-DB-UPDATE-1 */
        public void R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1()
        {
            /*" -3997- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET SEQ_APOLICE = :V0NAES-SEQ-APOL , ENDOSCOB = :V0NAES-ENDOSCOB , NRENDOCA = :V0NAES-NRENDOCA , ENDOSRES = :V0NAES-ENDOSRES , ENDOSSEM = :V0NAES-ENDOSSEM , ENDOSCCR = :V0NAES-ENDOSCCR , ENDOSMVC = :V0NAES-ENDOSMVC , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_ORGAO = :V1FONT-ORGAOEMIS AND COD_RAMO = :V1PROP-RAMO END-EXEC. */

            var r4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1 = new R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1()
            {
                V0NAES_SEQ_APOL = V0NAES_SEQ_APOL.ToString(),
                V0NAES_ENDOSCOB = V0NAES_ENDOSCOB.ToString(),
                V0NAES_NRENDOCA = V0NAES_NRENDOCA.ToString(),
                V0NAES_ENDOSRES = V0NAES_ENDOSRES.ToString(),
                V0NAES_ENDOSSEM = V0NAES_ENDOSSEM.ToString(),
                V0NAES_ENDOSCCR = V0NAES_ENDOSCCR.ToString(),
                V0NAES_ENDOSMVC = V0NAES_ENDOSMVC.ToString(),
                V1FONT_ORGAOEMIS = V1FONT_ORGAOEMIS.ToString(),
                V1PROP_RAMO = V1PROP_RAMO.ToString(),
            };

            R4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1.Execute(r4700_00_UPDATE_NUMERO_AES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4700_99_SAIDA*/

        [StopWatch]
        /*" R4800-00-ACESSA-V1ACOMPROP-SECTION */
        private void R4800_00_ACESSA_V1ACOMPROP_SECTION()
        {
            /*" -4014- MOVE '480' TO WNR-EXEC-SQL. */
            _.Move("480", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4022- PERFORM R4800_00_ACESSA_V1ACOMPROP_DB_DECLARE_1 */

            R4800_00_ACESSA_V1ACOMPROP_DB_DECLARE_1();

            /*" -4024- PERFORM R4800_00_ACESSA_V1ACOMPROP_DB_OPEN_1 */

            R4800_00_ACESSA_V1ACOMPROP_DB_OPEN_1();

            /*" -4028- MOVE '481' TO WNR-EXEC-SQL. */
            _.Move("481", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4031- PERFORM R4800_00_ACESSA_V1ACOMPROP_DB_FETCH_1 */

            R4800_00_ACESSA_V1ACOMPROP_DB_FETCH_1();

            /*" -4034- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4036- MOVE 'S' TO WFIM-V1ACOMPROP. */
                _.Move("S", AREA_DE_WORK.WFIM_V1ACOMPROP);
            }


            /*" -4036- PERFORM R4800_00_ACESSA_V1ACOMPROP_DB_CLOSE_1 */

            R4800_00_ACESSA_V1ACOMPROP_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R4800-00-ACESSA-V1ACOMPROP-DB-OPEN-1 */
        public void R4800_00_ACESSA_V1ACOMPROP_DB_OPEN_1()
        {
            /*" -4024- EXEC SQL OPEN V1ACOMPROP END-EXEC. */

            V1ACOMPROP.Open();

        }

        [StopWatch]
        /*" R4800-00-ACESSA-V1ACOMPROP-DB-FETCH-1 */
        public void R4800_00_ACESSA_V1ACOMPROP_DB_FETCH_1()
        {
            /*" -4031- EXEC SQL FETCH V1ACOMPROP INTO :V1APRO-DATOPR , :V1APRO-HORAOPER END-EXEC. */

            if (V1ACOMPROP.Fetch())
            {
                _.Move(V1ACOMPROP.V1APRO_DATOPR, V1APRO_DATOPR);
                _.Move(V1ACOMPROP.V1APRO_HORAOPER, V1APRO_HORAOPER);
            }

        }

        [StopWatch]
        /*" R4800-00-ACESSA-V1ACOMPROP-DB-CLOSE-1 */
        public void R4800_00_ACESSA_V1ACOMPROP_DB_CLOSE_1()
        {
            /*" -4036- EXEC SQL CLOSE V1ACOMPROP END-EXEC. */

            V1ACOMPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4800_99_SAIDA*/

        [StopWatch]
        /*" R4900-00-UPDATE-V0CONTPROP-SECTION */
        private void R4900_00_UPDATE_V0CONTPROP_SECTION()
        {
            /*" -4047- MOVE '490' TO WNR-EXEC-SQL. */
            _.Move("490", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4054- PERFORM R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1 */

            R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1();

            /*" -4057- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4060- DISPLAY 'R4900-00 (PROBLEMAS UPDATE V0CONTPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R4900-00 (PROBLEMAS UPDATE V0CONTPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4060- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4900-00-UPDATE-V0CONTPROP-DB-UPDATE-1 */
        public void R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1()
        {
            /*" -4054- EXEC SQL UPDATE SEGUROS.V0CONTPROP SET SITUACAO = '1' , OCORHIST = OCORHIST + 1, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1 = new R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1.Execute(r4900_00_UPDATE_V0CONTPROP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4900_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-INSERT-V0EMISDIARIA-SECTION */
        private void R5000_00_INSERT_V0EMISDIARIA_SECTION()
        {
            /*" -4071- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4074- MOVE 11 TO V0EDIA-COD-EMP. */
            _.Move(11, V0EDIA_COD_EMP);

            /*" -4075- IF V0ENDO-NRENDOS NOT EQUAL ZEROS */

            if (V0ENDO_NRENDOS != 00)
            {

                /*" -4076- MOVE 'EM0224B1' TO V0EDIA-CODRELAT */
                _.Move("EM0224B1", V0EDIA_CODRELAT);

                /*" -4077- ELSE */
            }
            else
            {


                /*" -4079- MOVE 'EM0221B1' TO V0EDIA-CODRELAT. */
                _.Move("EM0221B1", V0EDIA_CODRELAT);
            }


            /*" -4080- MOVE V0ENDO-NUM-APOL TO V0EDIA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0EDIA_NUM_APOL);

            /*" -4081- MOVE V0ENDO-NRENDOS TO V0EDIA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -4082- MOVE ZEROS TO V0EDIA-NRPARCEL */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -4083- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -4084- MOVE V1FONT-ORGAOEMIS TO V0EDIA-ORGAO */
            _.Move(V1FONT_ORGAOEMIS, V0EDIA_ORGAO);

            /*" -4085- MOVE V1PROP-RAMO TO V0EDIA-RAMO */
            _.Move(V1PROP_RAMO, V0EDIA_RAMO);

            /*" -4086- MOVE V1PROP-FONTE TO V0EDIA-FONTE */
            _.Move(V1PROP_FONTE, V0EDIA_FONTE);

            /*" -4087- MOVE ZEROS TO V0EDIA-CONGENER */
            _.Move(0, V0EDIA_CONGENER);

            /*" -4088- MOVE 0 TO V0EDIA-CODCORR */
            _.Move(0, V0EDIA_CODCORR);

            /*" -4089- MOVE '0' TO V0EDIA-SITUACAO */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -4091- MOVE V1PROP-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(V1PROP_COD_EMPRESA, V0EDIA_COD_EMP);

            /*" -4106- PERFORM R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1 */

            R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1();

            /*" -4109- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4112- DISPLAY 'R5000-00 (REGISTRO DUPLICADO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5000-00 (REGISTRO DUPLICADO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4114- GO TO R5000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4115- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4118- DISPLAY 'R5000-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5000-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4120- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4120- ADD +1 TO AC-I-V0EMISDIARIA. */
            AREA_DE_WORK.AC_I_V0EMISDIARIA.Value = AREA_DE_WORK.AC_I_V0EMISDIARIA + +1;

        }

        [StopWatch]
        /*" R5000-00-INSERT-V0EMISDIARIA-DB-INSERT-1 */
        public void R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -4106- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1()
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

            R5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r5000_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5300-00-INSERT-V0EMISDIARIA-SECTION */
        private void R5300_00_INSERT_V0EMISDIARIA_SECTION()
        {
            /*" -4133- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4135- MOVE 'EM0200B1' TO V0EDIA-CODRELAT */
            _.Move("EM0200B1", V0EDIA_CODRELAT);

            /*" -4136- MOVE V0ENDO-NUM-APOL TO V0EDIA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOL, V0EDIA_NUM_APOL);

            /*" -4137- MOVE V0ENDO-NRENDOS TO V0EDIA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -4138- MOVE ZEROS TO V0EDIA-NRPARCEL */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -4139- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -4140- MOVE V1FONT-ORGAOEMIS TO V0EDIA-ORGAO */
            _.Move(V1FONT_ORGAOEMIS, V0EDIA_ORGAO);

            /*" -4141- MOVE V1PROP-RAMO TO V0EDIA-RAMO */
            _.Move(V1PROP_RAMO, V0EDIA_RAMO);

            /*" -4142- MOVE V1PROP-FONTE TO V0EDIA-FONTE */
            _.Move(V1PROP_FONTE, V0EDIA_FONTE);

            /*" -4143- MOVE V1COSS-CONGENER TO V0EDIA-CONGENER */
            _.Move(V1COSS_CONGENER, V0EDIA_CONGENER);

            /*" -4144- MOVE V1PCOR-CODCORR TO V0EDIA-CODCORR */
            _.Move(V1PCOR_CODCORR, V0EDIA_CODCORR);

            /*" -4145- MOVE '0' TO V0EDIA-SITUACAO */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -4147- MOVE V1PROP-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(V1PROP_COD_EMPRESA, V0EDIA_COD_EMP);

            /*" -4162- PERFORM R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1 */

            R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1();

            /*" -4165- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4168- DISPLAY 'R5000-00 (REGISTRO DUPLICADO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5000-00 (REGISTRO DUPLICADO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4170- GO TO R5300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4171- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4174- DISPLAY 'R5000-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5000-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4176- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4176- ADD +1 TO AC-I-V0EMISDIARIA. */
            AREA_DE_WORK.AC_I_V0EMISDIARIA.Value = AREA_DE_WORK.AC_I_V0EMISDIARIA + +1;

        }

        [StopWatch]
        /*" R5300-00-INSERT-V0EMISDIARIA-DB-INSERT-1 */
        public void R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -4162- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1()
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

            R5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r5300_00_INSERT_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5300_99_SAIDA*/

        [StopWatch]
        /*" R5100-00-INSERT-V0ACOMPROP-SECTION */
        private void R5100_00_INSERT_V0ACOMPROP_SECTION()
        {
            /*" -4190- ACCEPT WTIME-DAY FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WTIME_DAY);

            /*" -4193- MOVE '510' TO WNR-EXEC-SQL. */
            _.Move("510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4199- PERFORM R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1 */

            R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1();

            /*" -4202- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4205- DISPLAY 'R5100-00 (NAO EXISTE NA V1CONTPROP) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5100-00 (NAO EXISTE NA V1CONTPROP) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4209- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4212- COMPUTE W1CPRO-OCORHIST = W1CPRO-OCORHIST + 1. */
            W1CPRO_OCORHIST.Value = W1CPRO_OCORHIST + 1;

            /*" -4214- MOVE 11 TO V0APRO-COD-EMPRESA. */
            _.Move(11, V0APRO_COD_EMPRESA);

            /*" -4215- MOVE V1PROP-FONTE TO V0APRO-FONTE */
            _.Move(V1PROP_FONTE, V0APRO_FONTE);

            /*" -4216- MOVE V1PROP-NRPROPOS TO V0APRO-NRPROPOS */
            _.Move(V1PROP_NRPROPOS, V0APRO_NRPROPOS);

            /*" -4217- MOVE 9019 TO V0APRO-OPERACAO */
            _.Move(9019, V0APRO_OPERACAO);

            /*" -4218- MOVE V1SIST-DTMOVABE TO V0APRO-DATOPR */
            _.Move(V1SIST_DTMOVABE, V0APRO_DATOPR);

            /*" -4219- MOVE WTIME-DAYR TO V0APRO-HORAOPER */
            _.Move(AREA_DE_WORK.FILLER_9.WTIME_DAYR, V0APRO_HORAOPER);

            /*" -4220- MOVE W1CPRO-OCORHIST TO V0APRO-OCORHIST */
            _.Move(W1CPRO_OCORHIST, V0APRO_OCORHIST);

            /*" -4222- MOVE V1PROP-COD-USUAR TO V0APRO-CODUSU. */
            _.Move(V1PROP_COD_USUAR, V0APRO_CODUSU);

            /*" -4224- MOVE '511' TO WNR-EXEC-SQL. */
            _.Move("511", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4235- PERFORM R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1 */

            R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1();

            /*" -4238- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4242- DISPLAY 'R5110-00 (REGISTRO DUPLICADO) ... ' ' ' V0APRO-FONTE ' ' V0APRO-NRPROPOS ' ' V0APRO-OPERACAO */

                $"R5110-00 (REGISTRO DUPLICADO) ...  {V0APRO_FONTE} {V0APRO_NRPROPOS} {V0APRO_OPERACAO}"
                .Display();

                /*" -4244- GO TO R5100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4245- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4249- DISPLAY 'R5110-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V0APRO-FONTE ' ' V0APRO-NRPROPOS ' ' V0APRO-OPERACAO */

                $"R5110-00 (PROBLEMAS NA INSERCAO) ...  {V0APRO_FONTE} {V0APRO_NRPROPOS} {V0APRO_OPERACAO}"
                .Display();

                /*" -4251- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4251- ADD +1 TO AC-I-V0ACOMPROP. */
            AREA_DE_WORK.AC_I_V0ACOMPROP.Value = AREA_DE_WORK.AC_I_V0ACOMPROP + +1;

        }

        [StopWatch]
        /*" R5100-00-INSERT-V0ACOMPROP-DB-SELECT-1 */
        public void R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1()
        {
            /*" -4199- EXEC SQL SELECT OCORHIST INTO :W1CPRO-OCORHIST FROM SEGUROS.V1CONTPROP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r5100_00_INSERT_V0ACOMPROP_DB_SELECT_1_Query1 = new R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1_Query1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            var executed_1 = R5100_00_INSERT_V0ACOMPROP_DB_SELECT_1_Query1.Execute(r5100_00_INSERT_V0ACOMPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W1CPRO_OCORHIST, W1CPRO_OCORHIST);
            }


        }

        [StopWatch]
        /*" R5100-00-INSERT-V0ACOMPROP-DB-INSERT-1 */
        public void R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1()
        {
            /*" -4235- EXEC SQL INSERT INTO SEGUROS.V0ACOMPROP VALUES (:V0APRO-FONTE , :V0APRO-NRPROPOS , :V0APRO-OPERACAO , :V0APRO-DATOPR , :V0APRO-HORAOPER , :V0APRO-OCORHIST , :V0APRO-CODUSU , :V0APRO-COD-EMPRESA:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1 = new R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1()
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

            R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1.Execute(r5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5100_99_SAIDA*/

        [StopWatch]
        /*" R5200-00-INSERT-V0MALHAPROD-SECTION */
        private void R5200_00_INSERT_V0MALHAPROD_SECTION()
        {
            /*" -4263- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4265- MOVE 11 TO V0MPRD-COD-EMP */
            _.Move(11, V0MPRD_COD_EMP);

            /*" -4266- MOVE WNUM-APOLICE TO V0MPRD-NUM-APOL */
            _.Move(AREA_DE_WORK.WNUM_APOLICE, V0MPRD_NUM_APOL);

            /*" -4267- MOVE V1PCOR-CODCORR TO V0MPRD-CODCORR */
            _.Move(V1PCOR_CODCORR, V0MPRD_CODCORR);

            /*" -4268- MOVE V1PROP-INSPETOR TO V0MPRD-INSPETOR */
            _.Move(V1PROP_INSPETOR, V0MPRD_INSPETOR);

            /*" -4269- MOVE V1PROP-CANALPROD TO V0MPRD-CODCLB */
            _.Move(V1PROP_CANALPROD, V0MPRD_CODCLB);

            /*" -4277- MOVE ZEROS TO V0MPRD-CODSUBES V0MPRD-CODPRP V0MPRD-ISPRGI V0MPRD-CODGTE V0MPRD-CODSTE V0MPRD-DIRRGI V0MPRD-DIRCMC */
            _.Move(0, V0MPRD_CODSUBES, V0MPRD_CODPRP, V0MPRD_ISPRGI, V0MPRD_CODGTE, V0MPRD_CODSTE, V0MPRD_DIRRGI, V0MPRD_DIRCMC);

            /*" -4292- PERFORM R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1 */

            R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1();

            /*" -4296- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4300- DISPLAY 'R5200-00 (REGISTRO DUPLICADO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS ' ' V0MPRD-NUM-APOL */

                $"R5200-00 (REGISTRO DUPLICADO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS} {V0MPRD_NUM_APOL}"
                .Display();

                /*" -4302- GO TO R5200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4303- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4307- DISPLAY 'R5200-00 (PROBLEMAS NA INSERCAO) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS ' ' V0MPRD-NUM-APOL */

                $"R5200-00 (PROBLEMAS NA INSERCAO) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS} {V0MPRD_NUM_APOL}"
                .Display();

                /*" -4309- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4309- ADD +1 TO AC-I-V0MALHAPROD. */
            AREA_DE_WORK.AC_I_V0MALHAPROD.Value = AREA_DE_WORK.AC_I_V0MALHAPROD + +1;

        }

        [StopWatch]
        /*" R5200-00-INSERT-V0MALHAPROD-DB-INSERT-1 */
        public void R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1()
        {
            /*" -4292- EXEC SQL INSERT INTO SEGUROS.V0MALHAPROD VALUES (:V0MPRD-NUM-APOL , :V0MPRD-CODSUBES , :V0MPRD-CODCORR , :V0MPRD-CODPRP , :V0MPRD-CODCLB , :V0MPRD-INSPETOR , :V0MPRD-ISPRGI , :V0MPRD-CODGTE , :V0MPRD-CODSTE , :V0MPRD-DIRRGI , :V0MPRD-DIRCMC , :V0MPRD-COD-EMP:VIND-COD-EMP, CURRENT TIMESTAMP) END-EXEC. */

            var r5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1 = new R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1()
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
                V0MPRD_COD_EMP = V0MPRD_COD_EMP.ToString(),
                VIND_COD_EMP = VIND_COD_EMP.ToString(),
            };

            R5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1.Execute(r5200_00_INSERT_V0MALHAPROD_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5200_99_SAIDA*/

        [StopWatch]
        /*" R5500-00-UPDATE-V0PROPOSTA-SECTION */
        private void R5500_00_UPDATE_V0PROPOSTA_SECTION()
        {
            /*" -4321- MOVE '550' TO WNR-EXEC-SQL. */
            _.Move("550", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4327- PERFORM R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1 */

            R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1();

            /*" -4330- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4333- DISPLAY 'R5500-00 (PROBLEMAS UPDATE V0PROPOSTA) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5500-00 (PROBLEMAS UPDATE V0PROPOSTA) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4333- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5500-00-UPDATE-V0PROPOSTA-DB-UPDATE-1 */
        public void R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1()
        {
            /*" -4327- EXEC SQL UPDATE SEGUROS.V0PROPOSTA SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1 = new R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1.Execute(r5500_00_UPDATE_V0PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R5550-00-UPDATE-V0PROPLOCINC-SECTION */
        private void R5550_00_UPDATE_V0PROPLOCINC_SECTION()
        {
            /*" -4345- MOVE '555' TO WNR-EXEC-SQL. */
            _.Move("555", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4351- PERFORM R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1 */

            R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1();

            /*" -4354- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4357- DISPLAY 'R5550-00 (PROBLEMAS UPDATE V0PROPLOCALINC)' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5550-00 (PROBLEMAS UPDATE V0PROPLOCALINC) {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4357- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5550-00-UPDATE-V0PROPLOCINC-DB-UPDATE-1 */
        public void R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1()
        {
            /*" -4351- EXEC SQL UPDATE SEGUROS.V0PROPLOCALINC SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1 = new R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1.Execute(r5550_00_UPDATE_V0PROPLOCINC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5550_99_SAIDA*/

        [StopWatch]
        /*" R5600-00-UPDATE-V0PROPINC-SECTION */
        private void R5600_00_UPDATE_V0PROPINC_SECTION()
        {
            /*" -4369- MOVE '560' TO WNR-EXEC-SQL. */
            _.Move("560", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4375- PERFORM R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1 */

            R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1();

            /*" -4378- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4381- DISPLAY 'R5600-00 (PROBLEMAS UPDATE V0PROPINC) ... ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                $"R5600-00 (PROBLEMAS UPDATE V0PROPINC) ...  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                .Display();

                /*" -4381- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5600-00-UPDATE-V0PROPINC-DB-UPDATE-1 */
        public void R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1()
        {
            /*" -4375- EXEC SQL UPDATE SEGUROS.V0PROPINC SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r5600_00_UPDATE_V0PROPINC_DB_UPDATE_1_Update1 = new R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R5600_00_UPDATE_V0PROPINC_DB_UPDATE_1_Update1.Execute(r5600_00_UPDATE_V0PROPINC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5600_99_SAIDA*/

        [StopWatch]
        /*" R5700-00-UPDATE-V0PROPDESCO-SECTION */
        private void R5700_00_UPDATE_V0PROPDESCO_SECTION()
        {
            /*" -4393- MOVE '570' TO WNR-EXEC-SQL. */
            _.Move("570", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4399- PERFORM R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1 */

            R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1();

            /*" -4402- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4403- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4406- DISPLAY 'R5700-00 (PROBLEMAS UPDATE V0PROPINCDESC) ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                    $"R5700-00 (PROBLEMAS UPDATE V0PROPINCDESC)  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                    .Display();

                    /*" -4407- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4408- ELSE */
                }
                else
                {


                    /*" -4408- GO TO R5700-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5700_99_SAIDA*/ //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5700-00-UPDATE-V0PROPDESCO-DB-UPDATE-1 */
        public void R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1()
        {
            /*" -4399- EXEC SQL UPDATE SEGUROS.V0PROPINCDESC SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1 = new R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1.Execute(r5700_00_UPDATE_V0PROPDESCO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5700_99_SAIDA*/

        [StopWatch]
        /*" R5800-00-UPDATE-V0PROPDCOB-SECTION */
        private void R5800_00_UPDATE_V0PROPDCOB_SECTION()
        {
            /*" -4420- MOVE '580' TO WNR-EXEC-SQL. */
            _.Move("580", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4426- PERFORM R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1 */

            R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1();

            /*" -4429- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4430- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -4433- DISPLAY 'R5800-00 (PROBLEMAS UPDATE V0PROPDESCOBER) ' ' ' V1PROP-FONTE ' ' V1PROP-NRPROPOS */

                    $"R5800-00 (PROBLEMAS UPDATE V0PROPDESCOBER)  {V1PROP_FONTE} {V1PROP_NRPROPOS}"
                    .Display();

                    /*" -4434- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4435- ELSE */
                }
                else
                {


                    /*" -4435- GO TO R5800-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R5800_99_SAIDA*/ //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5800-00-UPDATE-V0PROPDCOB-DB-UPDATE-1 */
        public void R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1()
        {
            /*" -4426- EXEC SQL UPDATE SEGUROS.V0PROPDESCOBER SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1PROP-FONTE AND NRPROPOS = :V1PROP-NRPROPOS END-EXEC. */

            var r5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1 = new R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1()
            {
                V1PROP_NRPROPOS = V1PROP_NRPROPOS.ToString(),
                V1PROP_FONTE = V1PROP_FONTE.ToString(),
            };

            R5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1.Execute(r5800_00_UPDATE_V0PROPDCOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5800_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -4451- MOVE '990' TO WNR-EXEC-SQL. */
            _.Move("990", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4452- MOVE V1SIST-DTMOVABE TO WDATA-REL */
            _.Move(V1SIST_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -4453- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -4454- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -4456- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_4.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -4457- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -4458- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4459- DISPLAY '*   EM0006B - ATUALIZACAO DB DE APOLICES   *' */
            _.Display($"*   EM0006B - ATUALIZACAO DB DE APOLICES   *");

            /*" -4460- DISPLAY '*   -------   ----------- -- -- --------   *' */
            _.Display($"*   -------   ----------- -- -- --------   *");

            /*" -4461- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4462- DISPLAY '*   NAO HOUVE MOVIMENTACAO DE PROPOSTAS    *' */
            _.Display($"*   NAO HOUVE MOVIMENTACAO DE PROPOSTAS    *");

            /*" -4464- DISPLAY '*   NESTA DATA ' WDAT-REL-LIT '                    *' */

            $"*   NESTA DATA {AREA_DE_WORK.WDAT_REL_LIT}                    *"
            .Display();

            /*" -4465- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -4465- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -4481- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -4482- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -4483- DISPLAY SQLERRMC. */
            _.Display(DB.SQLERRMC);

            /*" -4484- DISPLAY ' ' */
            _.Display($" ");

            /*" -4489- DISPLAY 'PROPOSTA/FONTE/RAMO = ' ' ' V1PROP-NRPROPOS ' ' V1PROP-FONTE ' ' V1PROP-RAMO. */

            $"PROPOSTA/FONTE/RAMO =  {V1PROP_NRPROPOS} {V1PROP_FONTE} {V1PROP_RAMO}"
            .Display();

            /*" -4489- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -4491- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -4495- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -4495- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}