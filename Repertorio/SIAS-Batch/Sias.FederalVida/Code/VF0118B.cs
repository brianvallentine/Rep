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
using Sias.FederalVida.DB2.VF0118B;

namespace Code
{
    public class VF0118B
    {
        public bool IsCall { get; set; }

        public VF0118B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  INTEGRA V0PROPOSTAVA FEDERAL VIDA  *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA/PROGRAMADOR....  FONSECA                            *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VF0118B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  03/09/98                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *           A L T E R A C O E S                                  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *  01 - CONTROLE DE EMISSAO DE CERTIFICADOS NA NOVA VERSAO.      *      */
        /*"      *                                 PROCURE MM0701.                *      */
        /*"      *                                                                *      */
        /*"      *                MANOEL MESSIAS   09/07/2001.                    *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 201.122                                      *      */
        /*"      *             AJUSTA INSERT DA TABELA HIST_LANC_CTA              *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/07/2011 - LOPES                                        *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  VIND-DTMOVTO                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTQITBCO                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTINIVIG                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTINIVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTPROXVEN                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTPROXVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTVENCTO                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTMINVEN                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTMINVEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDAGE                           PIC S9(4) COMP.*/
        public IntBasis INDAGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDOPR                           PIC S9(4) COMP.*/
        public IntBasis INDOPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDNUM                           PIC S9(4) COMP.*/
        public IntBasis INDNUM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  INDDIG                           PIC S9(4) COMP.*/
        public IntBasis INDDIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  CEDENT-NRTIT                     PIC S9(013)      COMP-3.*/
        public IntBasis CEDENT_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0CONV-CODCONV                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis V0CONV_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis RELATO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  RELATO-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis RELATO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-NRPARCEL                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis RELATO_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  RELATO-OPERACAO                  PIC S9(4) COMP VALUE +0.*/
        public IntBasis RELATO_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRCERTIF                  PIC S9(15) COMP-3.*/
        public IntBasis PROPVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  PROPVA-NRPROPAZ                  PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NRPROPAZ { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODPRODU                  PIC S9(04) COMP.*/
        public IntBasis PROPVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-CODCLIEN                  PIC S9(09) COMP.*/
        public IntBasis PROPVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  PROPVA-OCOREND                   PIC S9(04) COMP.*/
        public IntBasis PROPVA_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PROPVA-FONTE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OPCAO-COBER               PIC  X(1).*/
        public StringBasis PROPVA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-DTQITBCO                  PIC  X(10).*/
        public StringBasis PROPVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTINIVIG                  PIC  X(10).*/
        public StringBasis PROPVA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTMINVEN                  PIC  X(10).*/
        public StringBasis PROPVA_DTMINVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-CODOPER                   PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-DTMOVTO                   PIC  X(10).*/
        public StringBasis PROPVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTPROXVEN                 PIC  X(10).*/
        public StringBasis PROPVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-DTVENCTO                  PIC  X(10).*/
        public StringBasis PROPVA_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  PROPVA-SITUACAO                  PIC  X(1).*/
        public StringBasis PROPVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-NUM-APOLICE               PIC S9(13) COMP-3.*/
        public IntBasis PROPVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  PROPVA-CODSUBES                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-OCORHIST                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-NRPARCEL                  PIC S9(4) COMP.*/
        public IntBasis PROPVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-TIMESTAMP                 PIC  X(26).*/
        public StringBasis PROPVA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01  PROPVA-IDADE                     PIC S9(4) COMP.*/
        public IntBasis PROPVA_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  PROPVA-SEXO                      PIC  X(1).*/
        public StringBasis PROPVA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  PROPVA-CODUSU                    PIC  X(8).*/
        public StringBasis PROPVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  OPCAOP-OPCAOPAG                  PIC  X(1).*/
        public StringBasis OPCAOP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  OPCAOP-PERIPGTO                  PIC S9(4)     COMP.*/
        public IntBasis OPCAOP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-DIA-DEB                   PIC S9(4)     COMP.*/
        public IntBasis OPCAOP_DIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-AGECTADEB                 PIC S9(4)     COMP.*/
        public IntBasis OPCAOP_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-OPRCTADEB                 PIC S9(4)     COMP.*/
        public IntBasis OPCAOP_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  OPCAOP-NUMCTADEB                 PIC S9(13)    COMP-3.*/
        public IntBasis OPCAOP_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  OPCAOP-DIGCTADEB                 PIC S9(4)     COMP.*/
        public IntBasis OPCAOP_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COBERP-IMPMORNATU                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPMORACID                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPINVPERM                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPDIT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-IIMPSEGAUXF               PIC S9(04)    COMP.*/
        public IntBasis COBERP_IIMPSEGAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-IVLCUSTAUXF               PIC S9(04)    COMP.*/
        public IntBasis COBERP_IVLCUSTAUXF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  COBERP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  COBERP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFPAR-PRMVGDIF                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DIFPAR_PRMVGDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  DIFPAR-PRMAPDIF                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis DIFPAR_PRMAPDIF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PROPVF-NRTIT                     PIC S9(013)      COMP-3.*/
        public IntBasis PROPVF_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  PROPVF-PRMTOTPGO                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PROPVF_PRMTOTPGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PROPVF-PRMVGPGO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PROPVF_PRMVGPGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  PROPVF-PRMAPPGO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis PROPVF_PRMAPPGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  BENEF-NRBENEF                    PIC S9(04)       COMP.*/
        public IntBasis BENEF_NRBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  BENEF-NOMBENEF                   PIC X(40).*/
        public StringBasis BENEF_NOMBENEF { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  BENEF-GRAUPAR                    PIC X(10).*/
        public StringBasis BENEF_GRAUPAR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-PCTBENEF                   PIC S9(03)V99    COMP-3.*/
        public DoubleBasis BENEF_PCTBENEF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V99"), 2);
        /*"01  BENEF-DTTERVIG                   PIC X(10).*/
        public StringBasis BENEF_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTINIVIG                   PIC X(10).*/
        public StringBasis BENEF_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  BENEF-DTTERVIG-I                 PIC S9(04)       COMP.*/
        public IntBasis BENEF_DTTERVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  PARC-DTVENCTO                    PIC  X(10).*/
        public StringBasis PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC                    PIC  X(10).*/
        public StringBasis CLIENT_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  CLIENT-DTNASC-I                  PIC S9(04) COMP.*/
        public IntBasis CLIENT_DTNASC_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  CLIENT-CGCCPF                    PIC S9(15) COMP-3.*/
        public IntBasis CLIENT_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  SAFCOB-DTINIVIG                  PIC  X(010).*/
        public StringBasis SAFCOB_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  REPSAF-DTREF                     PIC  X(010).*/
        public StringBasis REPSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  FONTE-PROPAUTOM                  PIC S9(009) COMP.*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  SISTEMA-DTMOVABE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-CURRDATE                 PIC  X(010).*/
        public StringBasis SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTACEITE                 PIC  X(010).*/
        public StringBasis SISTEMA_DTACEITE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVA15D                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVA15D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVA01M                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVA01M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTMOVA02M                PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVA02M { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMA-DTINISAF                 PIC  X(010).*/
        public StringBasis SISTEMA_DTINISAF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  CONDTE-IEA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  CONDTE-IPA                       PIC S9(005)V9(02) COMP-3.*/
        public DoubleBasis CONDTE_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V9(02)"), 2);
        /*"01  MFAIXA                           PIC S9(004)      COMP.*/
        public IntBasis MFAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  MAGENCIADOR                      PIC S9(009)      COMP.*/
        public IntBasis MAGENCIADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  MDTMOVTO                         PIC  X(010).*/
        public StringBasis MDTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MDTREF                           PIC  X(010).*/
        public StringBasis MDTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  MTPBENEF                         PIC  X(001).*/
        public StringBasis MTPBENEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTPINCLUS                        PIC  X(001).*/
        public StringBasis MTPINCLUS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MAGECOBR                         PIC S9(04)       COMP.*/
        public IntBasis MAGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  MNUM-CTA-CORRENTE                PIC S9(017)      COMP-3.*/
        public IntBasis MNUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01  MDAC-CTA-CORRENTE                PIC  X(001).*/
        public StringBasis MDAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  MTXAPMA                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPMA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXAPIP                          PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXAPIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  MTXVG                            PIC S9(003)V9(4) COMP-3.*/
        public DoubleBasis MTXVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
        /*"01  FATURC-DTREF                     PIC  X(010).*/
        public StringBasis FATURC_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  PARCEL-OCORHIST                  PIC S9(004)      COMP.*/
        public IntBasis PARCEL_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HISTCB-SITUACAO                  PIC  X(001).*/
        public StringBasis HISTCB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HISTCB-CODOPER                   PIC S9(004)      COMP.*/
        public IntBasis HISTCB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  RCAP-SITUACAO                    PIC  X(001).*/
        public StringBasis RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  HCOB-NRTIT                       PIC S9(013) COMP-3.*/
        public IntBasis HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  HCOB-OCORHIST                    PIC S9(004) COMP.*/
        public IntBasis HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  HCTBL-SITUACAO                   PIC  X(001).*/
        public StringBasis HCTBL_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01  PLCOM-CODPDT                     PIC S9(009) COMP.*/
        public IntBasis PLCOM_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  PDTVF-OCORHIST                   PIC S9(004) COMP.*/
        public IntBasis PDTVF_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-WORK-AREAS.*/
        public VF0118B_WS_WORK_AREAS WS_WORK_AREAS { get; set; } = new VF0118B_WS_WORK_AREAS();
        public class VF0118B_WS_WORK_AREAS : VarBasis
        {
            /*"    03  WS-EOF                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-EOP                       PIC 9 VALUE 0.*/
            public IntBasis WS_EOP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  WS-TEM-RCAP                  PIC 9 VALUE 0.*/
            public IntBasis WS_TEM_RCAP { get; set; } = new IntBasis(new PIC("9", "1", "9"));
            /*"    03  W01A0100.*/
            public VF0118B_W01A0100 W01A0100 { get; set; } = new VF0118B_W01A0100();
            public class VF0118B_W01A0100 : VarBasis
            {
                /*"        05 W01N0100                  PIC 9(01).*/
                public IntBasis W01N0100 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    03  WSQLCODE3                    PIC S9(009) COMP.*/
            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 W01DTSQL.*/
            public VF0118B_W01DTSQL W01DTSQL { get; set; } = new VF0118B_W01DTSQL();
            public class VF0118B_W01DTSQL : VarBasis
            {
                /*"       05  W01AASQL                  PIC 9(004).*/
                public IntBasis W01AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W01T1SQL                  PIC X(001).*/
                public StringBasis W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01MMSQL                  PIC 9(002).*/
                public IntBasis W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W01T2SQL                  PIC X(001).*/
                public StringBasis W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W01DDSQL                  PIC 9(002).*/
                public IntBasis W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W02DTSQL.*/
            }
            public VF0118B_W02DTSQL W02DTSQL { get; set; } = new VF0118B_W02DTSQL();
            public class VF0118B_W02DTSQL : VarBasis
            {
                /*"       05  W02AASQL                  PIC 9(004).*/
                public IntBasis W02AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W02T1SQL                  PIC X(001).*/
                public StringBasis W02T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02MMSQL                  PIC 9(002).*/
                public IntBasis W02MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W02T2SQL                  PIC X(001).*/
                public StringBasis W02T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W02DDSQL                  PIC 9(002).*/
                public IntBasis W02DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W03DTSQL.*/
            }
            public VF0118B_W03DTSQL W03DTSQL { get; set; } = new VF0118B_W03DTSQL();
            public class VF0118B_W03DTSQL : VarBasis
            {
                /*"       05  W03AASQL                  PIC 9(004).*/
                public IntBasis W03AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W03T1SQL                  PIC X(001).*/
                public StringBasis W03T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W03MMSQL                  PIC 9(002).*/
                public IntBasis W03MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W03T2SQL                  PIC X(001).*/
                public StringBasis W03T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W03DDSQL                  PIC 9(002).*/
                public IntBasis W03DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 W04DTSQL.*/
            }
            public VF0118B_W04DTSQL W04DTSQL { get; set; } = new VF0118B_W04DTSQL();
            public class VF0118B_W04DTSQL : VarBasis
            {
                /*"       05  W04AASQL                  PIC 9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05  W04T1SQL                  PIC X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04MMSQL                  PIC 9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05  W04T2SQL                  PIC X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05  W04DDSQL                  PIC 9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 WS-CONT-BENEF                 PIC  9(004) VALUE 0.*/
            }
            public IntBasis WS_CONT_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-CTA-CORRENTE-R.*/
            public VF0118B_WS_CTA_CORRENTE_R WS_CTA_CORRENTE_R { get; set; } = new VF0118B_WS_CTA_CORRENTE_R();
            public class VF0118B_WS_CTA_CORRENTE_R : VarBasis
            {
                /*"       05 WS-OPER-SEG                PIC  9(004).*/
                public IntBasis WS_OPER_SEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA-SEG                 PIC  9(012).*/
                public IntBasis WS_CTA_SEG { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03  WS-CTA-CORRENTE              REDEFINES        WS-CTA-CORRENTE-R            PIC  9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_corrente { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTE
            {
                get { _ws_cta_corrente = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_R, _ws_cta_corrente); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_R, _ws_cta_corrente, WS_CTA_CORRENTE_R); _ws_cta_corrente.ValueChanged += () => { _.Move(_ws_cta_corrente, WS_CTA_CORRENTE_R); }; return _ws_cta_corrente; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_corrente, WS_CTA_CORRENTE_R); }
            }  //Redefines
            /*"    03 WS-CTA-CORRENTE-VR.*/
            public VF0118B_WS_CTA_CORRENTE_VR WS_CTA_CORRENTE_VR { get; set; } = new VF0118B_WS_CTA_CORRENTE_VR();
            public class VF0118B_WS_CTA_CORRENTE_VR : VarBasis
            {
                /*"       05 WS-OPER                    PIC  9(004).*/
                public IntBasis WS_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 WS-CTA                     PIC  9(012).*/
                public IntBasis WS_CTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    03 WS-CTA-CORRENTEV              REDEFINES       WS-CTA-CORRENTE-VR            PIC  9(016).*/
            }
            private _REDEF_IntBasis _ws_cta_correntev { get; set; }
            public _REDEF_IntBasis WS_CTA_CORRENTEV
            {
                get { _ws_cta_correntev = new _REDEF_IntBasis(new PIC("9", "016", "9(016).")); ; _.Move(WS_CTA_CORRENTE_VR, _ws_cta_correntev); VarBasis.RedefinePassValue(WS_CTA_CORRENTE_VR, _ws_cta_correntev, WS_CTA_CORRENTE_VR); _ws_cta_correntev.ValueChanged += () => { _.Move(_ws_cta_correntev, WS_CTA_CORRENTE_VR); }; return _ws_cta_correntev; }
                set { VarBasis.RedefinePassValue(value, _ws_cta_correntev, WS_CTA_CORRENTE_VR); }
            }  //Redefines
            /*"    03 AC-LIDOS                      PIC  9(006) VALUE  0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-INTEGRADOS                 PIC  9(006) VALUE  0.*/
            public IntBasis AC_INTEGRADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-PRIMEIRA                   PIC  9(006) VALUE  0.*/
            public IntBasis AC_PRIMEIRA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-DEBITO                     PIC  9(006) VALUE  0.*/
            public IntBasis AC_DEBITO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 AC-CARNE                      PIC  9(006) VALUE  0.*/
            public IntBasis AC_CARNE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    03 W-NUMR-TITULO                PIC  9(013)   VALUE ZEROS.*/
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    03 FILLER                       REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_VF0118B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VF0118B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VF0118B_FILLER_0(); _.Move(W_NUMR_TITULO, _filler_0); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_0, W_NUMR_TITULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUMR_TITULO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_VF0118B_FILLER_0 : VarBasis
            {
                /*"       05    WTITL-ZEROS              PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05    WTITL-SEQUENCIA          PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"       05    WTITL-DIGITO             PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03              DPARM01X.*/

                public _REDEF_VF0118B_FILLER_0()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public VF0118B_DPARM01X DPARM01X { get; set; } = new VF0118B_DPARM01X();
            public class VF0118B_DPARM01X : VarBasis
            {
                /*"       05            DPARM01          PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"       05            DPARM01-R        REDEFINES   DPARM01.*/
                private _REDEF_VF0118B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_VF0118B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_VF0118B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_VF0118B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1        PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2        PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3        PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4        PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5        PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6        PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7        PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8        PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9        PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10       PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"       05            DPARM01-D1       PIC  9(001).*/

                    public _REDEF_VF0118B_DPARM01_R()
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
                /*"       05            DPARM01-RC       PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    03 PARM-PROSOMU1.*/
            }
            public VF0118B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new VF0118B_PARM_PROSOMU1();
            public class VF0118B_PARM_PROSOMU1 : VarBasis
            {
                /*"       05 SU1-DATA1.*/
                public VF0118B_SU1_DATA1 SU1_DATA1 { get; set; } = new VF0118B_SU1_DATA1();
                public class VF0118B_SU1_DATA1 : VarBasis
                {
                    /*"        10 SU1-DD1                   PIC 99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM1                   PIC 99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA1                   PIC 9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"       05 SU1-NRDIAS                  PIC S9(5) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(5)"));
                /*"       05 SU1-DATA2.*/
                public VF0118B_SU1_DATA2 SU1_DATA2 { get; set; } = new VF0118B_SU1_DATA2();
                public class VF0118B_SU1_DATA2 : VarBasis
                {
                    /*"        10 SU1-DD2                   PIC 99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-MM2                   PIC 99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"        10 SU1-AA2                   PIC 9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"01  WABEND.*/
                }
            }
        }
        public VF0118B_WABEND WABEND { get; set; } = new VF0118B_WABEND();
        public class VF0118B_WABEND : VarBasis
        {
            /*"       05    FILLER                   PIC  X(010) VALUE            'VF0118B  '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VF0118B  ");
            /*"       05    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"       05    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"       05    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"       05    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"       05    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"       05    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"       05    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"       05    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"       05      LOCALIZA-ABEND-1.*/
            public VF0118B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VF0118B_LOCALIZA_ABEND_1();
            public class VF0118B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"        10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"        10    PARAGRAFO                PIC  X(040)   VALUE SPACES       05      LOCALIZA-ABEND-2.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"        10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"        10    COMANDO                  PIC  X(060)   VALUE SPACES*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public VF0118B_CPROPVA CPROPVA { get; set; } = new VF0118B_CPROPVA();
        public VF0118B_CBENEFP CBENEFP { get; set; } = new VF0118B_CBENEFP();
        public VF0118B_CPLCOM CPLCOM { get; set; } = new VF0118B_CPLCOM();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -352- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -354- EXEC SQL WHENEVER SQLERROR GO TO 9999-ERRO END-EXEC. */

            /*" -356- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -359- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -360- DISPLAY 'PROGRAMA EM EXECUCAO VF0118B   ' */
            _.Display($"PROGRAMA EM EXECUCAO VF0118B   ");

            /*" -361- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -362- DISPLAY 'VERSAO V.01 201.122 14/07/2011 ' */
            _.Display($"VERSAO V.01 201.122 14/07/2011 ");

            /*" -363- DISPLAY 'VERSAO V.04 NSGD    03/12/2014 ' . */
            _.Display($"VERSAO V.04 NSGD    03/12/2014 ");

            /*" -364- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -366- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -367- MOVE '0000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-PRINCIPAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -369- MOVE 'SELECT V0SISTEMA' TO COMANDO. */
            _.Move("SELECT V0SISTEMA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -386- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -389- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -394- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -395- MOVE SISTEMA-CURRDATE TO W04DTSQL. */
            _.Move(SISTEMA_CURRDATE, WS_WORK_AREAS.W04DTSQL);

            /*" -396- MOVE W04DDSQL TO SU1-DD1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04DDSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -397- MOVE W04MMSQL TO SU1-MM1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04MMSQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -398- MOVE W04AASQL TO SU1-AA1. */
            _.Move(WS_WORK_AREAS.W04DTSQL.W04AASQL, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -399- MOVE ZEROES TO SU1-DATA2. */
            _.Move(0, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2);

            /*" -400- PERFORM 0010-SOMA-DIAS THRU 0010-FIM 6 TIMES. */

            M_0010_SOMA_DIAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/


            /*" -401- MOVE SU1-DD2 TO W04DDSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, WS_WORK_AREAS.W04DTSQL.W04DDSQL);

            /*" -402- MOVE SU1-MM2 TO W04MMSQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, WS_WORK_AREAS.W04DTSQL.W04MMSQL);

            /*" -404- MOVE SU1-AA2 TO W04AASQL. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, WS_WORK_AREAS.W04DTSQL.W04AASQL);

            /*" -405- DISPLAY 'DATA ATUAL                     ' SISTEMA-CURRDATE. */
            _.Display($"DATA ATUAL                     {SISTEMA_CURRDATE}");

            /*" -407- DISPLAY 'DATA MINIMA P/ PRIMEIRO DEBITO ' W04DTSQL. */
            _.Display($"DATA MINIMA P/ PRIMEIRO DEBITO {WS_WORK_AREAS.W04DTSQL}");

            /*" -409- MOVE 'SELECT V0CEDENTE' TO COMANDO. */
            _.Move("SELECT V0CEDENTE", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -414- PERFORM M_0000_PRINCIPAL_DB_SELECT_2 */

            M_0000_PRINCIPAL_DB_SELECT_2();

            /*" -417- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -419- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -421- MOVE CEDENT-NRTIT TO W-NUMR-TITULO. */
            _.Move(CEDENT_NRTIT, WS_WORK_AREAS.W_NUMR_TITULO);

            /*" -423- MOVE 'DECLARE CPROPVA' TO COMANDO. */
            _.Move("DECLARE CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -454- PERFORM M_0000_PRINCIPAL_DB_DECLARE_1 */

            M_0000_PRINCIPAL_DB_DECLARE_1();

            /*" -457- DISPLAY '*** VF0118B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VF0118B *** ABRINDO CURSOR ...");

            /*" -458- MOVE 'OPEN CPROPVA' TO COMANDO. */
            _.Move("OPEN CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -458- PERFORM M_0000_PRINCIPAL_DB_OPEN_1 */

            M_0000_PRINCIPAL_DB_OPEN_1();

            /*" -462- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


            /*" -463- DISPLAY '*** VF0118B *** PROCESSANDO ...' . */
            _.Display($"*** VF0118B *** PROCESSANDO ...");

            /*" -466- PERFORM 0100-PROCESSA-PROPOSTA THRU 0100-FIM UNTIL WS-EOF = 1. */

            while (!(WS_WORK_AREAS.WS_EOF == 1))
            {

                M_0100_PROCESSA_PROPOSTA(true);

                M_0100_NEXT(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

            }

            /*" -468- MOVE 'UPDATE V0CEDENTE' TO COMANDO. */
            _.Move("UPDATE V0CEDENTE", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -473- PERFORM M_0000_PRINCIPAL_DB_UPDATE_1 */

            M_0000_PRINCIPAL_DB_UPDATE_1();

            /*" -476- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -476- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -386- EXEC SQL SELECT DTMOVABE, CURRENT DATE, CURRENT DATE + 1 DAY, CURRENT DATE + 15 DAYS, CURRENT DATE + 1 MONTH, CURRENT DATE + 2 MONTHS, CURRENT DATE + 1 DAY + 6 MONTHS INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRDATE, :SISTEMA-DTACEITE, :SISTEMA-DTMOVA15D, :SISTEMA-DTMOVA01M, :SISTEMA-DTMOVA02M, :SISTEMA-DTINISAF FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VF' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRDATE, SISTEMA_CURRDATE);
                _.Move(executed_1.SISTEMA_DTACEITE, SISTEMA_DTACEITE);
                _.Move(executed_1.SISTEMA_DTMOVA15D, SISTEMA_DTMOVA15D);
                _.Move(executed_1.SISTEMA_DTMOVA01M, SISTEMA_DTMOVA01M);
                _.Move(executed_1.SISTEMA_DTMOVA02M, SISTEMA_DTMOVA02M);
                _.Move(executed_1.SISTEMA_DTINISAF, SISTEMA_DTINISAF);
            }


        }

        [StopWatch]
        /*" M-0000-TERMINA */
        private void M_0000_TERMINA(bool isPerform = false)
        {
            /*" -482- PERFORM 9000-FINALIZA THRU 9000-FIM. */

            M_9000_FINALIZA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/


            /*" -484- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -484- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-DECLARE-1 */
        public void M_0000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -454- EXEC SQL DECLARE CPROPVA CURSOR FOR SELECT B.NRCERTIF, B.CODPRODU, B.CODCLIEN, B.OCOREND, B.FONTE, B.OPCAO_COBER, B.DTQITBCO, B.DTQITBCO + 1 DAY, B.DTPROXVEN, B.DTQITBCO + 30 DAY, B.CODOPER, B.DTMOVTO, B.SITUACAO, B.NUM_APOLICE, B.CODSUBES, B.OCORHIST, B.NRPARCE, B.DTVENCTO, B.TIMESTAMP, B.IDADE, B.IDE_SEXO, B.CODUSU FROM SEGUROS.V0PRODUTOSVG A, SEGUROS.V0PROPOSTAVA B WHERE A.ESTR_EMISS = 'FEDERAL' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES AND B.CODSUBES > 0 AND B.SITUACAO = '0' END-EXEC. */
            CPROPVA = new VF0118B_CPROPVA(false);
            string GetQuery_CPROPVA()
            {
                var query = @$"SELECT B.NRCERTIF
							, 
							B.CODPRODU
							, 
							B.CODCLIEN
							, 
							B.OCOREND
							, 
							B.FONTE
							, 
							B.OPCAO_COBER
							, 
							B.DTQITBCO
							, 
							B.DTQITBCO + 1 DAY
							, 
							B.DTPROXVEN
							, 
							B.DTQITBCO + 30 DAY
							, 
							B.CODOPER
							, 
							B.DTMOVTO
							, 
							B.SITUACAO
							, 
							B.NUM_APOLICE
							, 
							B.CODSUBES
							, 
							B.OCORHIST
							, 
							B.NRPARCE
							, 
							B.DTVENCTO
							, 
							B.TIMESTAMP
							, 
							B.IDADE
							, 
							B.IDE_SEXO
							, 
							B.CODUSU 
							FROM SEGUROS.V0PRODUTOSVG A
							, 
							SEGUROS.V0PROPOSTAVA B 
							WHERE A.ESTR_EMISS = 'FEDERAL' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.CODSUBES = A.CODSUBES 
							AND B.CODSUBES > 0 
							AND B.SITUACAO = '0'";

                return query;
            }
            CPROPVA.GetQueryEvent += GetQuery_CPROPVA;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-OPEN-1 */
        public void M_0000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -458- EXEC SQL OPEN CPROPVA END-EXEC. */

            CPROPVA.Open();

        }

        [StopWatch]
        /*" M-2200-MONTA-BENEFICIARIOS-DB-DECLARE-1 */
        public void M_2200_MONTA_BENEFICIARIOS_DB_DECLARE_1()
        {
            /*" -1322- EXEC SQL DECLARE CBENEFP CURSOR FOR SELECT NOMBENEF, GRAUPAR, PCTBENEF FROM SEGUROS.V0BENEFPROPAZ WHERE NRPROPAZ = :PROPVA-NRPROPAZ AND AGELOTE = 0 AND DTLOTE = 0 AND NRLOTE = 0 AND NRSEQLOTE = 0 END-EXEC. */
            CBENEFP = new VF0118B_CBENEFP(true);
            string GetQuery_CBENEFP()
            {
                var query = @$"SELECT NOMBENEF
							, 
							GRAUPAR
							, 
							PCTBENEF 
							FROM SEGUROS.V0BENEFPROPAZ 
							WHERE NRPROPAZ = '{PROPVA_NRPROPAZ}' 
							AND AGELOTE = 0 
							AND DTLOTE = 0 
							AND NRLOTE = 0 
							AND NRSEQLOTE = 0";

                return query;
            }
            CBENEFP.GetQueryEvent += GetQuery_CBENEFP;

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-UPDATE-1 */
        public void M_0000_PRINCIPAL_DB_UPDATE_1()
        {
            /*" -473- EXEC SQL UPDATE SEGUROS.V0CEDENTE SET NUMTIT = :CEDENT-NRTIT, TIMESTAMP = CURRENT TIMESTAMP WHERE CODCDT = 19 END-EXEC. */

            var m_0000_PRINCIPAL_DB_UPDATE_1_Update1 = new M_0000_PRINCIPAL_DB_UPDATE_1_Update1()
            {
                CEDENT_NRTIT = CEDENT_NRTIT.ToString(),
            };

            M_0000_PRINCIPAL_DB_UPDATE_1_Update1.Execute(m_0000_PRINCIPAL_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -414- EXEC SQL SELECT NUMTIT INTO :CEDENT-NRTIT FROM SEGUROS.V0CEDENTE WHERE CODCDT = 19 END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENT_NRTIT, CEDENT_NRTIT);
            }


        }

        [StopWatch]
        /*" M-0010-SOMA-DIAS */
        private void M_0010_SOMA_DIAS(bool isPerform = false)
        {
            /*" -493- MOVE +1 TO SU1-NRDIAS. */
            _.Move(+1, WS_WORK_AREAS.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -494- CALL 'PROSOCU1' USING PARM-PROSOMU1. */
            _.Call("PROSOCU1", WS_WORK_AREAS.PARM_PROSOMU1);

            /*" -494- MOVE SU1-DATA2 TO SU1-DATA1. */
            _.Move(WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA2, WS_WORK_AREAS.PARM_PROSOMU1.SU1_DATA1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0010_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA */
        private void M_0100_PROCESSA_PROPOSTA(bool isPerform = false)
        {
            /*" -506- ADD 1 TO AC-LIDOS. */
            WS_WORK_AREAS.AC_LIDOS.Value = WS_WORK_AREAS.AC_LIDOS + 1;

            /*" -508- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -510- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -528- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_1 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_1();

            /*" -531- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -534- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -535- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -536- MOVE 'SELECT V0CONVSICOV' TO COMANDO */
                _.Move("SELECT V0CONVSICOV", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -541- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_2 */

                M_0100_PROCESSA_PROPOSTA_DB_SELECT_2();

                /*" -543- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -545- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -547- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -569- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_3 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_3();

            /*" -572- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -574- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -576- IF COBERP-IMPMORNATU EQUAL 0 OR COBERP-PRMVG EQUAL 0 */

            if (COBERP_IMPMORNATU == 0 || COBERP_PRMVG == 0)
            {

                /*" -578- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -580- MOVE 'SELECT V0PLANOSVA' TO COMANDO. */
            _.Move("SELECT V0PLANOSVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -595- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_4 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_4();

            /*" -598- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -600- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -602- MOVE 'SELECT V0PROPOSTAVF' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -613- PERFORM M_0100_PROCESSA_PROPOSTA_DB_SELECT_5 */

            M_0100_PROCESSA_PROPOSTA_DB_SELECT_5();

            /*" -616- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -618- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -620- PERFORM 1000-INTEGRA-PROPOSTA THRU 1000-FIM. */

            M_1000_INTEGRA_PROPOSTA(true);

            M_1000_AJUSTA_DTPROXVEN(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/


            /*" -621- MOVE '0100-PROCESSA-PROPOSTA' TO PARAGRAFO. */
            _.Move("0100-PROCESSA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -623- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO. */
            _.Move("UPDATE V0PROPOSTAVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -632- PERFORM M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1 */

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1();

            /*" -635- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -637- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -638- IF OPCAOP-OPCAOPAG EQUAL '3' */

            if (OPCAOP_OPCAOPAG == "3")
            {

                /*" -639- ADD 1 TO AC-CARNE */
                WS_WORK_AREAS.AC_CARNE.Value = WS_WORK_AREAS.AC_CARNE + 1;

                /*" -640- ELSE */
            }
            else
            {


                /*" -640- ADD 1 TO AC-DEBITO. */
                WS_WORK_AREAS.AC_DEBITO.Value = WS_WORK_AREAS.AC_DEBITO + 1;
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_1()
        {
            /*" -528- EXEC SQL SELECT OPCAOPAG, PERIPGTO, DIA_DEBITO, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB INTO :OPCAOP-OPCAOPAG, :OPCAOP-PERIPGTO, :OPCAOP-DIA-DEB, :OPCAOP-AGECTADEB:INDAGE, :OPCAOP-OPRCTADEB:INDOPR, :OPCAOP-NUMCTADEB:INDNUM, :OPCAOP-DIGCTADEB:INDDIG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCAOP_OPCAOPAG, OPCAOP_OPCAOPAG);
                _.Move(executed_1.OPCAOP_PERIPGTO, OPCAOP_PERIPGTO);
                _.Move(executed_1.OPCAOP_DIA_DEB, OPCAOP_DIA_DEB);
                _.Move(executed_1.OPCAOP_AGECTADEB, OPCAOP_AGECTADEB);
                _.Move(executed_1.INDAGE, INDAGE);
                _.Move(executed_1.OPCAOP_OPRCTADEB, OPCAOP_OPRCTADEB);
                _.Move(executed_1.INDOPR, INDOPR);
                _.Move(executed_1.OPCAOP_NUMCTADEB, OPCAOP_NUMCTADEB);
                _.Move(executed_1.INDNUM, INDNUM);
                _.Move(executed_1.OPCAOP_DIGCTADEB, OPCAOP_DIGCTADEB);
                _.Move(executed_1.INDDIG, INDDIG);
            }


        }

        [StopWatch]
        /*" M-0100-NEXT */
        private void M_0100_NEXT(bool isPerform = false)
        {
            /*" -644- PERFORM 0110-FETCH THRU 0110-FIM. */

            M_0110_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-2 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_2()
        {
            /*" -541- EXEC SQL SELECT COD_SEGURO INTO :V0CONV-CODCONV FROM SEGUROS.V0CONVSICOV WHERE CODPRODU = :PROPVA-CODPRODU END-EXEC */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1()
            {
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONV_CODCONV, V0CONV_CODCONV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0100_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-3 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_3()
        {
            /*" -569- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPDIT, VLPREMIO, PRMVG, PRMAP, IMPSEGAUXF, VLCUSTAUXF INTO :COBERP-IMPMORNATU, :COBERP-IMPMORACID, :COBERP-IMPINVPERM, :COBERP-IMPDIT, :COBERP-VLPREMIO, :COBERP-PRMVG, :COBERP-PRMAP, :COBERP-IMPSEGAUXF:COBERP-IIMPSEGAUXF, :COBERP-VLCUSTAUXF:COBERP-IVLCUSTAUXF FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :PROPVA-NRCERTIF AND OCORHIST = 1 END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERP_IMPMORNATU, COBERP_IMPMORNATU);
                _.Move(executed_1.COBERP_IMPMORACID, COBERP_IMPMORACID);
                _.Move(executed_1.COBERP_IMPINVPERM, COBERP_IMPINVPERM);
                _.Move(executed_1.COBERP_IMPDIT, COBERP_IMPDIT);
                _.Move(executed_1.COBERP_VLPREMIO, COBERP_VLPREMIO);
                _.Move(executed_1.COBERP_PRMVG, COBERP_PRMVG);
                _.Move(executed_1.COBERP_PRMAP, COBERP_PRMAP);
                _.Move(executed_1.COBERP_IMPSEGAUXF, COBERP_IMPSEGAUXF);
                _.Move(executed_1.COBERP_IIMPSEGAUXF, COBERP_IIMPSEGAUXF);
                _.Move(executed_1.COBERP_VLCUSTAUXF, COBERP_VLCUSTAUXF);
                _.Move(executed_1.COBERP_IVLCUSTAUXF, COBERP_IVLCUSTAUXF);
            }


        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-UPDATE-1 */
        public void M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1()
        {
            /*" -632- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET CODOPER = :PROPVA-CODOPER, DTPROXVEN = :PROPVA-DTPROXVEN, SITUACAO = :PROPVA-SITUACAO, NRPARCE = :PROPVA-NRPARCEL, DTVENCTO = :PROPVA-DTVENCTO, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1 = new M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPVA_DTPROXVEN = PROPVA_DTPROXVEN.ToString(),
                PROPVA_SITUACAO = PROPVA_SITUACAO.ToString(),
                PROPVA_NRPARCEL = PROPVA_NRPARCEL.ToString(),
                PROPVA_DTVENCTO = PROPVA_DTVENCTO.ToString(),
                PROPVA_CODOPER = PROPVA_CODOPER.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1.Execute(m_0100_PROCESSA_PROPOSTA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-0110-FETCH */
        private void M_0110_FETCH(bool isPerform = false)
        {
            /*" -655- MOVE '0110-FETCH' TO PARAGRAFO. */
            _.Move("0110-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -657- MOVE 'FETCH CPROPVA' TO COMANDO. */
            _.Move("FETCH CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -681- PERFORM M_0110_FETCH_DB_FETCH_1 */

            M_0110_FETCH_DB_FETCH_1();

            /*" -684- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -685- MOVE 1 TO WS-EOF */
                _.Move(1, WS_WORK_AREAS.WS_EOF);

                /*" -686- MOVE 'CLOSE CPROPVA' TO COMANDO */
                _.Move("CLOSE CPROPVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -686- PERFORM M_0110_FETCH_DB_CLOSE_1 */

                M_0110_FETCH_DB_CLOSE_1();

                /*" -687- END-IF. */
            }


        }

        [StopWatch]
        /*" M-0110-FETCH-DB-FETCH-1 */
        public void M_0110_FETCH_DB_FETCH_1()
        {
            /*" -681- EXEC SQL FETCH CPROPVA INTO :PROPVA-NRCERTIF, :PROPVA-CODPRODU, :PROPVA-CODCLIEN, :PROPVA-OCOREND, :PROPVA-FONTE, :PROPVA-OPCAO-COBER, :PROPVA-DTQITBCO:VIND-DTQITBCO, :PROPVA-DTINIVIG:VIND-DTINIVIG, :PROPVA-DTPROXVEN:VIND-DTPROXVEN, :PROPVA-DTMINVEN:VIND-DTMINVEN, :PROPVA-CODOPER, :PROPVA-DTMOVTO:VIND-DTMOVTO, :PROPVA-SITUACAO, :PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-OCORHIST, :PROPVA-NRPARCEL, :PROPVA-DTVENCTO:VIND-DTVENCTO, :PROPVA-TIMESTAMP, :PROPVA-IDADE, :PROPVA-SEXO, :PROPVA-CODUSU END-EXEC. */

            if (CPROPVA.Fetch())
            {
                _.Move(CPROPVA.PROPVA_NRCERTIF, PROPVA_NRCERTIF);
                _.Move(CPROPVA.PROPVA_CODPRODU, PROPVA_CODPRODU);
                _.Move(CPROPVA.PROPVA_CODCLIEN, PROPVA_CODCLIEN);
                _.Move(CPROPVA.PROPVA_OCOREND, PROPVA_OCOREND);
                _.Move(CPROPVA.PROPVA_FONTE, PROPVA_FONTE);
                _.Move(CPROPVA.PROPVA_OPCAO_COBER, PROPVA_OPCAO_COBER);
                _.Move(CPROPVA.PROPVA_DTQITBCO, PROPVA_DTQITBCO);
                _.Move(CPROPVA.VIND_DTQITBCO, VIND_DTQITBCO);
                _.Move(CPROPVA.PROPVA_DTINIVIG, PROPVA_DTINIVIG);
                _.Move(CPROPVA.VIND_DTINIVIG, VIND_DTINIVIG);
                _.Move(CPROPVA.PROPVA_DTPROXVEN, PROPVA_DTPROXVEN);
                _.Move(CPROPVA.VIND_DTPROXVEN, VIND_DTPROXVEN);
                _.Move(CPROPVA.PROPVA_DTMINVEN, PROPVA_DTMINVEN);
                _.Move(CPROPVA.VIND_DTMINVEN, VIND_DTMINVEN);
                _.Move(CPROPVA.PROPVA_CODOPER, PROPVA_CODOPER);
                _.Move(CPROPVA.PROPVA_DTMOVTO, PROPVA_DTMOVTO);
                _.Move(CPROPVA.VIND_DTMOVTO, VIND_DTMOVTO);
                _.Move(CPROPVA.PROPVA_SITUACAO, PROPVA_SITUACAO);
                _.Move(CPROPVA.PROPVA_NUM_APOLICE, PROPVA_NUM_APOLICE);
                _.Move(CPROPVA.PROPVA_CODSUBES, PROPVA_CODSUBES);
                _.Move(CPROPVA.PROPVA_OCORHIST, PROPVA_OCORHIST);
                _.Move(CPROPVA.PROPVA_NRPARCEL, PROPVA_NRPARCEL);
                _.Move(CPROPVA.PROPVA_DTVENCTO, PROPVA_DTVENCTO);
                _.Move(CPROPVA.VIND_DTVENCTO, VIND_DTVENCTO);
                _.Move(CPROPVA.PROPVA_TIMESTAMP, PROPVA_TIMESTAMP);
                _.Move(CPROPVA.PROPVA_IDADE, PROPVA_IDADE);
                _.Move(CPROPVA.PROPVA_SEXO, PROPVA_SEXO);
                _.Move(CPROPVA.PROPVA_CODUSU, PROPVA_CODUSU);
            }

        }

        [StopWatch]
        /*" M-0110-FETCH-DB-CLOSE-1 */
        public void M_0110_FETCH_DB_CLOSE_1()
        {
            /*" -686- EXEC SQL CLOSE CPROPVA END-EXEC */

            CPROPVA.Close();

        }

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-4 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_4()
        {
            /*" -595- EXEC SQL SELECT FAIXA, TAXAVG, TAXAAP INTO :MFAIXA, :MTXVG, :MTXAPMA FROM SEGUROS.V0PLANOSVA WHERE CODPRODU = :PROPVA-CODPRODU AND OPCAO_COBER = :PROPVA-OPCAO-COBER AND DTINIVIG <= :PROPVA-DTQITBCO AND DTTERVIG >= :PROPVA-DTQITBCO AND IDADE_INICIAL <= :PROPVA-IDADE AND IDADE_FINAL >= :PROPVA-IDADE AND PERIPGTO = :OPCAOP-PERIPGTO END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1()
            {
                PROPVA_OPCAO_COBER = PROPVA_OPCAO_COBER.ToString(),
                PROPVA_CODPRODU = PROPVA_CODPRODU.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_IDADE = PROPVA_IDADE.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MFAIXA, MFAIXA);
                _.Move(executed_1.MTXVG, MTXVG);
                _.Move(executed_1.MTXAPMA, MTXAPMA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0110_FIM*/

        [StopWatch]
        /*" M-0100-PROCESSA-PROPOSTA-DB-SELECT-5 */
        public void M_0100_PROCESSA_PROPOSTA_DB_SELECT_5()
        {
            /*" -613- EXEC SQL SELECT NRTIT, PRMTOTPGO, PRMVGPGO, PRMAPPGO INTO :PROPVF-NRTIT, :PROPVF-PRMTOTPGO, :PROPVF-PRMVGPGO, :PROPVF-PRMAPPGO FROM SEGUROS.V0PROPOSTAVF WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC. */

            var m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1 = new M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            var executed_1 = M_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1.Execute(m_0100_PROCESSA_PROPOSTA_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPVF_NRTIT, PROPVF_NRTIT);
                _.Move(executed_1.PROPVF_PRMTOTPGO, PROPVF_PRMTOTPGO);
                _.Move(executed_1.PROPVF_PRMVGPGO, PROPVF_PRMVGPGO);
                _.Move(executed_1.PROPVF_PRMAPPGO, PROPVF_PRMAPPGO);
            }


        }

        [StopWatch]
        /*" M-1000-INTEGRA-PROPOSTA */
        private void M_1000_INTEGRA_PROPOSTA(bool isPerform = false)
        {
            /*" -703- MOVE PROPVA-DTINIVIG TO MDTMOVTO. */
            _.Move(PROPVA_DTINIVIG, MDTMOVTO);

            /*" -705- MOVE '1000-INTEGRA-PROPOSTA' TO PARAGRAFO. */
            _.Move("1000-INTEGRA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -707- MOVE 0 TO WS-TEM-RCAP. */
            _.Move(0, WS_WORK_AREAS.WS_TEM_RCAP);

            /*" -708- IF PROPVF-NRTIT NOT EQUAL 0 */

            if (PROPVF_NRTIT != 0)
            {

                /*" -709- MOVE 'SELECT V0RCAP' TO COMANDO */
                _.Move("SELECT V0RCAP", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -714- PERFORM M_1000_INTEGRA_PROPOSTA_DB_SELECT_1 */

                M_1000_INTEGRA_PROPOSTA_DB_SELECT_1();

                /*" -716- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -725- MOVE 1 TO WS-TEM-RCAP. */
                    _.Move(1, WS_WORK_AREAS.WS_TEM_RCAP);
                }

            }


            /*" -726- IF WS-TEM-RCAP EQUAL 0 */

            if (WS_WORK_AREAS.WS_TEM_RCAP == 0)
            {

                /*" -727- PERFORM 1100-GERA-1A-PARCELA THRU 1100-FIM */

                M_1100_GERA_1A_PARCELA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/


                /*" -728- ADD 1 TO AC-PRIMEIRA */
                WS_WORK_AREAS.AC_PRIMEIRA.Value = WS_WORK_AREAS.AC_PRIMEIRA + 1;

                /*" -729- ELSE */
            }
            else
            {


                /*" -730- IF RCAP-SITUACAO EQUAL '2' */

                if (RCAP_SITUACAO == "2")
                {

                    /*" -731- PERFORM 1200-ATUALIZA-1A-PARCELA THRU 1200-FIM */

                    M_1200_ATUALIZA_1A_PARCELA(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/


                    /*" -732- ADD 1 TO AC-PRIMEIRA */
                    WS_WORK_AREAS.AC_PRIMEIRA.Value = WS_WORK_AREAS.AC_PRIMEIRA + 1;

                    /*" -733- ELSE */
                }
                else
                {


                    /*" -734- PERFORM M-1400-CONTABILIZA-PREMIO-PAGO THRU 1400-FIM */

                    M_1400_CONTABILIZA_PREMIO_PAGO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/


                    /*" -735- IF PROPVF-PRMTOTPGO LESS THAN COBERP-VLPREMIO */

                    if (PROPVF_PRMTOTPGO < COBERP_VLPREMIO)
                    {

                        /*" -742- PERFORM 1300-GERA-AJUSTE THRU 1300-FIM. */

                        M_1300_GERA_AJUSTE(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

                    }

                }

            }


            /*" -744- IF WS-TEM-RCAP EQUAL 1 AND RCAP-SITUACAO NOT EQUAL '2' */

            if (WS_WORK_AREAS.WS_TEM_RCAP == 1 && RCAP_SITUACAO != "2")
            {

                /*" -745- MOVE PROPVA-DTMINVEN TO W01DTSQL */
                _.Move(PROPVA_DTMINVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -746- MOVE OPCAOP-DIA-DEB TO W01DDSQL */
                _.Move(OPCAOP_DIA_DEB, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

                /*" -747- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -748- IF PROPVA-DTPROXVEN < PROPVA-DTMINVEN */

                if (PROPVA_DTPROXVEN < PROPVA_DTMINVEN)
                {

                    /*" -749- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                    _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                    /*" -750- ADD 1 TO W01MMSQL */
                    WS_WORK_AREAS.W01DTSQL.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL.W01MMSQL + 1;

                    /*" -751- IF W01MMSQL > 12 */

                    if (WS_WORK_AREAS.W01DTSQL.W01MMSQL > 12)
                    {

                        /*" -752- MOVE 01 TO W01MMSQL */
                        _.Move(01, WS_WORK_AREAS.W01DTSQL.W01MMSQL);

                        /*" -753- COMPUTE W01AASQL = W01AASQL + 1 */
                        WS_WORK_AREAS.W01DTSQL.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL.W01AASQL + 1;

                        /*" -754- END-IF */
                    }


                    /*" -754- MOVE W01DTSQL TO PROPVA-DTPROXVEN. */
                    _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);
                }

            }


        }

        [StopWatch]
        /*" M-1000-INTEGRA-PROPOSTA-DB-SELECT-1 */
        public void M_1000_INTEGRA_PROPOSTA_DB_SELECT_1()
        {
            /*" -714- EXEC SQL SELECT SITUACAO INTO :RCAP-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :PROPVF-NRTIT END-EXEC */

            var m_1000_INTEGRA_PROPOSTA_DB_SELECT_1_Query1 = new M_1000_INTEGRA_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPVF_NRTIT = PROPVF_NRTIT.ToString(),
            };

            var executed_1 = M_1000_INTEGRA_PROPOSTA_DB_SELECT_1_Query1.Execute(m_1000_INTEGRA_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAP_SITUACAO, RCAP_SITUACAO);
            }


        }

        [StopWatch]
        /*" M-1000-AJUSTA-DTPROXVEN */
        private void M_1000_AJUSTA_DTPROXVEN(bool isPerform = false)
        {
            /*" -765- IF WS-TEM-RCAP EQUAL 1 AND RCAP-SITUACAO NOT EQUAL '2' AND PROPVA-DTPROXVEN < W04DTSQL */

            if (WS_WORK_AREAS.WS_TEM_RCAP == 1 && RCAP_SITUACAO != "2" && PROPVA_DTPROXVEN < WS_WORK_AREAS.W04DTSQL)
            {

                /*" -766- MOVE PROPVA-DTPROXVEN TO W01DTSQL */
                _.Move(PROPVA_DTPROXVEN, WS_WORK_AREAS.W01DTSQL);

                /*" -767- ADD 1 TO W01MMSQL */
                WS_WORK_AREAS.W01DTSQL.W01MMSQL.Value = WS_WORK_AREAS.W01DTSQL.W01MMSQL + 1;

                /*" -768- IF W01MMSQL > 12 */

                if (WS_WORK_AREAS.W01DTSQL.W01MMSQL > 12)
                {

                    /*" -769- MOVE 01 TO W01MMSQL */
                    _.Move(01, WS_WORK_AREAS.W01DTSQL.W01MMSQL);

                    /*" -770- COMPUTE W01AASQL = W01AASQL + 1 */
                    WS_WORK_AREAS.W01DTSQL.W01AASQL.Value = WS_WORK_AREAS.W01DTSQL.W01AASQL + 1;

                    /*" -771- END-IF */
                }


                /*" -772- MOVE W01DTSQL TO PROPVA-DTPROXVEN */
                _.Move(WS_WORK_AREAS.W01DTSQL, PROPVA_DTPROXVEN);

                /*" -774- GO TO 1000-AJUSTA-DTPROXVEN. */
                new Task(() => M_1000_AJUSTA_DTPROXVEN()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -776- MOVE '3' TO MTPINCLUS. */
            _.Move("3", MTPINCLUS);

            /*" -778- PERFORM 2000-INTEGRA-VG THRU 2000-FIM. */

            M_2000_INTEGRA_VG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/


            /*" -779- MOVE '1000-INTEGRA-PROPOSTA' TO PARAGRAFO. */
            _.Move("1000-INTEGRA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -780- MOVE 'SELECT COBRANCA_MENS_VGAP' TO COMANDO. */
            _.Move("SELECT COBRANCA_MENS_VGAP", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -790- PERFORM M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1 */

            M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1();

            /*" -792- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -794- MOVE 2 TO RELATO-OPERACAO RELATO-NRPARCEL */
                _.Move(2, RELATO_OPERACAO, RELATO_NRPARCEL);

                /*" -795- ELSE */
            }
            else
            {


                /*" -800- MOVE ZEROS TO RELATO-OPERACAO RELATO-NRPARCEL. */
                _.Move(0, RELATO_OPERACAO, RELATO_NRPARCEL);
            }


            /*" -801- MOVE '1000-INTEGRA-PROPOSTA' TO PARAGRAFO. */
            _.Move("1000-INTEGRA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -803- MOVE 'INSERT V0RELATORIOS' TO COMANDO. */
            _.Move("INSERT V0RELATORIOS", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -848- PERFORM M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1 */

            M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1();

            /*" -851- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -851- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1000-AJUSTA-DTPROXVEN-DB-SELECT-1 */
        public void M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1()
        {
            /*" -790- EXEC SQL SELECT NUM_APOLICE, CODSUBES INTO :RELATO-NUM-APOLICE, :RELATO-CODSUBES FROM SEGUROS.COBRANCA_MENS_VGAP WHERE IDFORM = 'A4' AND NUM_APOLICE = :PROPVA-NUM-APOLICE AND CODSUBES = :PROPVA-CODSUBES AND COD_OPERACAO = 2 END-EXEC */

            var m_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1 = new M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1.Execute(m_1000_AJUSTA_DTPROXVEN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATO_NUM_APOLICE, RELATO_NUM_APOLICE);
                _.Move(executed_1.RELATO_CODSUBES, RELATO_CODSUBES);
            }


        }

        [StopWatch]
        /*" M-1000-AJUSTA-DTPROXVEN-DB-INSERT-1 */
        public void M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1()
        {
            /*" -848- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VF0118B' , CURRENT DATE, 'VF' , 'VF0420B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, 0, 0, 0, :PROPVA-NUM-APOLICE, 0, :RELATO-NRPARCEL, :PROPVA-NRCERTIF, 0, :PROPVA-CODSUBES, :RELATO-OPERACAO, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , NULL, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_1000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1 = new M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                RELATO_NRPARCEL = RELATO_NRPARCEL.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                RELATO_OPERACAO = RELATO_OPERACAO.ToString(),
            };

            M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1.Execute(m_1000_AJUSTA_DTPROXVEN_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1000_FIM*/

        [StopWatch]
        /*" M-1100-GERA-1A-PARCELA */
        private void M_1100_GERA_1A_PARCELA(bool isPerform = false)
        {
            /*" -862- MOVE 1 TO PROPVA-NRPARCEL. */
            _.Move(1, PROPVA_NRPARCEL);

            /*" -863- MOVE SISTEMA-DTMOVA01M TO PROPVA-DTVENCTO. */
            _.Move(SISTEMA_DTMOVA01M, PROPVA_DTVENCTO);

            /*" -865- MOVE SISTEMA-DTMOVA02M TO PROPVA-DTPROXVEN. */
            _.Move(SISTEMA_DTMOVA02M, PROPVA_DTPROXVEN);

            /*" -866- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -867- MOVE 1 TO PARCEL-OCORHIST */
                _.Move(1, PARCEL_OCORHIST);

                /*" -868- ELSE */
            }
            else
            {


                /*" -870- MOVE 0 TO PARCEL-OCORHIST. */
                _.Move(0, PARCEL_OCORHIST);
            }


            /*" -871- MOVE '1100-GERA-1A-PARCELA  ' TO PARAGRAFO. */
            _.Move("1100-GERA-1A-PARCELA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -873- MOVE 'INSERT V0PARCELVA' TO COMANDO. */
            _.Move("INSERT V0PARCELVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -885- PERFORM M_1100_GERA_1A_PARCELA_DB_INSERT_1 */

            M_1100_GERA_1A_PARCELA_DB_INSERT_1();

            /*" -889- ADD 1 TO WTITL-SEQUENCIA. */
            WS_WORK_AREAS.FILLER_0.WTITL_SEQUENCIA.Value = WS_WORK_AREAS.FILLER_0.WTITL_SEQUENCIA + 1;

            /*" -891- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WS_WORK_AREAS.FILLER_0.WTITL_SEQUENCIA, WS_WORK_AREAS.DPARM01X.DPARM01);

            /*" -893- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WS_WORK_AREAS.DPARM01X);

            /*" -894- IF DPARM01-RC NOT EQUAL +0 */

            if (WS_WORK_AREAS.DPARM01X.DPARM01_RC != +0)
            {

                /*" -895- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -897- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -899- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WS_WORK_AREAS.DPARM01X.DPARM01_D1, WS_WORK_AREAS.FILLER_0.WTITL_DIGITO);

            /*" -901- MOVE W-NUMR-TITULO TO CEDENT-NRTIT. */
            _.Move(WS_WORK_AREAS.W_NUMR_TITULO, CEDENT_NRTIT);

            /*" -902- IF OPCAOP-OPCAOPAG = '3' */

            if (OPCAOP_OPCAOPAG == "3")
            {

                /*" -903- MOVE '5' TO HISTCB-SITUACAO */
                _.Move("5", HISTCB_SITUACAO);

                /*" -904- MOVE 141 TO HISTCB-CODOPER */
                _.Move(141, HISTCB_CODOPER);

                /*" -905- ELSE */
            }
            else
            {


                /*" -906- MOVE 131 TO HISTCB-CODOPER */
                _.Move(131, HISTCB_CODOPER);

                /*" -908- MOVE '0' TO HISTCB-SITUACAO. */
                _.Move("0", HISTCB_SITUACAO);
            }


            /*" -910- MOVE 'INSERT V0HISTCOBVA' TO COMANDO. */
            _.Move("INSERT V0HISTCOBVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -926- PERFORM M_1100_GERA_1A_PARCELA_DB_INSERT_2 */

            M_1100_GERA_1A_PARCELA_DB_INSERT_2();

            /*" -930- MOVE 'INSERT V0COMPTITVA' TO COMANDO. */
            _.Move("INSERT V0COMPTITVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -940- PERFORM M_1100_GERA_1A_PARCELA_DB_INSERT_3 */

            M_1100_GERA_1A_PARCELA_DB_INSERT_3();

            /*" -943- IF OPCAOP-OPCAOPAG EQUAL '1' OR '2' */

            if (OPCAOP_OPCAOPAG.In("1", "2"))
            {

                /*" -943- PERFORM 8700-GERA-DEBITO THRU 8700-FIM. */

                M_8700_GERA_DEBITO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8700_FIM*/

            }


        }

        [StopWatch]
        /*" M-1100-GERA-1A-PARCELA-DB-INSERT-1 */
        public void M_1100_GERA_1A_PARCELA_DB_INSERT_1()
        {
            /*" -885- EXEC SQL INSERT INTO SEGUROS.V0PARCELVA VALUES (:PROPVA-NRCERTIF, :PROPVA-NRPARCEL, :PROPVA-DTVENCTO, :COBERP-PRMVG, :COBERP-PRMAP, 0, :OPCAOP-OPCAOPAG, ' ' , :PARCEL-OCORHIST, CURRENT TIMESTAMP) END-EXEC. */

            var m_1100_GERA_1A_PARCELA_DB_INSERT_1_Insert1 = new M_1100_GERA_1A_PARCELA_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRPARCEL = PROPVA_NRPARCEL.ToString(),
                PROPVA_DTVENCTO = PROPVA_DTVENCTO.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                PARCEL_OCORHIST = PARCEL_OCORHIST.ToString(),
            };

            M_1100_GERA_1A_PARCELA_DB_INSERT_1_Insert1.Execute(m_1100_GERA_1A_PARCELA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1100_FIM*/

        [StopWatch]
        /*" M-1100-GERA-1A-PARCELA-DB-INSERT-2 */
        public void M_1100_GERA_1A_PARCELA_DB_INSERT_2()
        {
            /*" -926- EXEC SQL INSERT INTO SEGUROS.V0HISTCOBVA VALUES (:PROPVA-NRCERTIF, :PROPVA-NRPARCEL, :CEDENT-NRTIT, :PROPVA-DTVENCTO, :COBERP-VLPREMIO, :OPCAOP-OPCAOPAG, :HISTCB-SITUACAO, :HISTCB-CODOPER, 0, 0, 0, 0, 0, 0) END-EXEC. */

            var m_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1 = new M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRPARCEL = PROPVA_NRPARCEL.ToString(),
                CEDENT_NRTIT = CEDENT_NRTIT.ToString(),
                PROPVA_DTVENCTO = PROPVA_DTVENCTO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
                OPCAOP_OPCAOPAG = OPCAOP_OPCAOPAG.ToString(),
                HISTCB_SITUACAO = HISTCB_SITUACAO.ToString(),
                HISTCB_CODOPER = HISTCB_CODOPER.ToString(),
            };

            M_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1.Execute(m_1100_GERA_1A_PARCELA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-1200-ATUALIZA-1A-PARCELA */
        private void M_1200_ATUALIZA_1A_PARCELA(bool isPerform = false)
        {
            /*" -955- MOVE 1 TO PROPVA-NRPARCEL. */
            _.Move(1, PROPVA_NRPARCEL);

            /*" -956- MOVE SISTEMA-DTMOVA01M TO PROPVA-DTVENCTO. */
            _.Move(SISTEMA_DTMOVA01M, PROPVA_DTVENCTO);

            /*" -958- MOVE SISTEMA-DTMOVA02M TO PROPVA-DTPROXVEN. */
            _.Move(SISTEMA_DTMOVA02M, PROPVA_DTPROXVEN);

            /*" -959- MOVE '1200-ATUALIZA-1A-PARCELA' TO PARAGRAFO. */
            _.Move("1200-ATUALIZA-1A-PARCELA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -961- MOVE 'UPDATE V0PARCELVA' TO COMANDO. */
            _.Move("UPDATE V0PARCELVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -971- PERFORM M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1 */

            M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1();

            /*" -974- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -976- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -978- ADD 1 TO WTITL-SEQUENCIA. */
            WS_WORK_AREAS.FILLER_0.WTITL_SEQUENCIA.Value = WS_WORK_AREAS.FILLER_0.WTITL_SEQUENCIA + 1;

            /*" -980- MOVE WTITL-SEQUENCIA TO DPARM01. */
            _.Move(WS_WORK_AREAS.FILLER_0.WTITL_SEQUENCIA, WS_WORK_AREAS.DPARM01X.DPARM01);

            /*" -982- CALL 'PROTIT01' USING DPARM01X. */
            _.Call("PROTIT01", WS_WORK_AREAS.DPARM01X);

            /*" -983- IF DPARM01-RC NOT EQUAL +0 */

            if (WS_WORK_AREAS.DPARM01X.DPARM01_RC != +0)
            {

                /*" -984- DISPLAY 'ERRO CHAMADA PROTIT01' */
                _.Display($"ERRO CHAMADA PROTIT01");

                /*" -986- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -988- MOVE DPARM01-D1 TO WTITL-DIGITO. */
            _.Move(WS_WORK_AREAS.DPARM01X.DPARM01_D1, WS_WORK_AREAS.FILLER_0.WTITL_DIGITO);

            /*" -990- MOVE W-NUMR-TITULO TO CEDENT-NRTIT. */
            _.Move(WS_WORK_AREAS.W_NUMR_TITULO, CEDENT_NRTIT);

            /*" -992- MOVE 'UPDATE V0HISTCOBVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1002- PERFORM M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2 */

            M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2();

            /*" -1005- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1005- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1200-ATUALIZA-1A-PARCELA-DB-UPDATE-1 */
        public void M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1()
        {
            /*" -971- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET DTVENCTO = :PROPVA-DTVENCTO, PRMVG = :COBERP-PRMVG, PRMAP = :COBERP-PRMAP, OPCAOOPAG = '3' , SITUACAO = ' ' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :PROPVA-NRPARCEL END-EXEC. */

            var m_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1_Update1 = new M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1_Update1()
            {
                PROPVA_DTVENCTO = PROPVA_DTVENCTO.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRPARCEL = PROPVA_NRPARCEL.ToString(),
            };

            M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1_Update1.Execute(m_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-1100-GERA-1A-PARCELA-DB-INSERT-3 */
        public void M_1100_GERA_1A_PARCELA_DB_INSERT_3()
        {
            /*" -940- EXEC SQL INSERT INTO SEGUROS.V0COMPTITVA VALUES (:CEDENT-NRTIT, :PROPVA-NRPARCEL, 0, :COBERP-PRMVG, :COBERP-PRMAP, :SISTEMA-DTMOVABE, 'VF0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1 = new M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1()
            {
                CEDENT_NRTIT = CEDENT_NRTIT.ToString(),
                PROPVA_NRPARCEL = PROPVA_NRPARCEL.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
            };

            M_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1.Execute(m_1100_GERA_1A_PARCELA_DB_INSERT_3_Insert1);

        }

        [StopWatch]
        /*" M-1200-ATUALIZA-1A-PARCELA-DB-UPDATE-2 */
        public void M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2()
        {
            /*" -1002- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET NRTIT = :CEDENT-NRTIT, DTVENCTO = :PROPVA-DTVENCTO, VLPRMTOT = :COBERP-VLPREMIO, OPCAOPAG = '3' , SITUACAO = '5' , CODOPER = 141 WHERE NRCERTIF = :PROPVA-NRCERTIF AND NRPARCEL = :PROPVA-NRPARCEL END-EXEC. */

            var m_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1 = new M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1()
            {
                PROPVA_DTVENCTO = PROPVA_DTVENCTO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
                CEDENT_NRTIT = CEDENT_NRTIT.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_NRPARCEL = PROPVA_NRPARCEL.ToString(),
            };

            M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1.Execute(m_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1200_FIM*/

        [StopWatch]
        /*" M-1300-GERA-AJUSTE */
        private void M_1300_GERA_AJUSTE(bool isPerform = false)
        {
            /*" -1017- COMPUTE DIFPAR-PRMVGDIF = COBERP-PRMVG - PROPVF-PRMVGPGO. */
            DIFPAR_PRMVGDIF.Value = COBERP_PRMVG - PROPVF_PRMVGPGO;

            /*" -1019- COMPUTE DIFPAR-PRMAPDIF = COBERP-PRMAP - PROPVF-PRMAPPGO. */
            DIFPAR_PRMAPDIF.Value = COBERP_PRMAP - PROPVF_PRMAPPGO;

            /*" -1020- MOVE '1300-GERA-AJUSTE' TO PARAGRAFO. */
            _.Move("1300-GERA-AJUSTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1022- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1037- PERFORM M_1300_GERA_AJUSTE_DB_INSERT_1 */

            M_1300_GERA_AJUSTE_DB_INSERT_1();

            /*" -1040- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1040- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1300-GERA-AJUSTE-DB-INSERT-1 */
        public void M_1300_GERA_AJUSTE_DB_INSERT_1()
        {
            /*" -1037- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:PROPVA-NRCERTIF, 9999, 1, 401, :PROPVA-DTQITBCO, :COBERP-PRMVG, :COBERP-PRMAP, :PROPVF-PRMVGPGO, :PROPVF-PRMAPPGO, :DIFPAR-PRMVGDIF, :DIFPAR-PRMAPDIF, 0, ' ' ) END-EXEC. */

            var m_1300_GERA_AJUSTE_DB_INSERT_1_Insert1 = new M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_DTQITBCO = PROPVA_DTQITBCO.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                PROPVF_PRMVGPGO = PROPVF_PRMVGPGO.ToString(),
                PROPVF_PRMAPPGO = PROPVF_PRMAPPGO.ToString(),
                DIFPAR_PRMVGDIF = DIFPAR_PRMVGDIF.ToString(),
                DIFPAR_PRMAPDIF = DIFPAR_PRMAPDIF.ToString(),
            };

            M_1300_GERA_AJUSTE_DB_INSERT_1_Insert1.Execute(m_1300_GERA_AJUSTE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1300_FIM*/

        [StopWatch]
        /*" M-1400-CONTABILIZA-PREMIO-PAGO */
        private void M_1400_CONTABILIZA_PREMIO_PAGO(bool isPerform = false)
        {
            /*" -1051- MOVE '1400-CONTABILIZA-PREMIO-PAGO' TO PARAGRAFO. */
            _.Move("1400-CONTABILIZA-PREMIO-PAGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1053- MOVE 'UPDATE V0HISTCONTABILVA' TO COMANDO. */
            _.Move("UPDATE V0HISTCONTABILVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1057- PERFORM M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1 */

            M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1();

            /*" -1060- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1060- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-1400-CONTABILIZA-PREMIO-PAGO-DB-UPDATE-1 */
        public void M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1()
        {
            /*" -1057- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '0' WHERE NRCERTIF = :PROPVA-NRCERTIF END-EXEC. */

            var m_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1_Update1 = new M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1_Update1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
            };

            M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1_Update1.Execute(m_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1400_FIM*/

        [StopWatch]
        /*" M-2000-INTEGRA-VG */
        private void M_2000_INTEGRA_VG(bool isPerform = false)
        {
            /*" -1071- MOVE '2000-INTEGRA-VG       ' TO PARAGRAFO. */
            _.Move("2000-INTEGRA-VG       ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1073- MOVE 'SELECT V0CONDTEC' TO COMANDO. */
            _.Move("SELECT V0CONDTEC", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1081- PERFORM M_2000_INTEGRA_VG_DB_SELECT_1 */

            M_2000_INTEGRA_VG_DB_SELECT_1();

            /*" -1084- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1086- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1088- MOVE 'SELECT V0FATURCONT 1' TO COMANDO. */
            _.Move("SELECT V0FATURCONT 1", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1094- PERFORM M_2000_INTEGRA_VG_DB_SELECT_2 */

            M_2000_INTEGRA_VG_DB_SELECT_2();

            /*" -1097- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1098- MOVE 'SELECT V0FATURCONT 2' TO COMANDO */
                _.Move("SELECT V0FATURCONT 2", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -1104- PERFORM M_2000_INTEGRA_VG_DB_SELECT_3 */

                M_2000_INTEGRA_VG_DB_SELECT_3();

                /*" -1106- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1108- GO TO 9999-ERRO. */

                    M_9999_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1109- MOVE MDTMOVTO TO W02DTSQL. */
            _.Move(MDTMOVTO, WS_WORK_AREAS.W02DTSQL);

            /*" -1111- MOVE FATURC-DTREF TO W03DTSQL. */
            _.Move(FATURC_DTREF, WS_WORK_AREAS.W03DTSQL);

            /*" -1112- IF W02AASQL > W03AASQL */

            if (WS_WORK_AREAS.W02DTSQL.W02AASQL > WS_WORK_AREAS.W03DTSQL.W03AASQL)
            {

                /*" -1113- MOVE 01 TO W02DDSQL */
                _.Move(01, WS_WORK_AREAS.W02DTSQL.W02DDSQL);

                /*" -1114- MOVE W02DTSQL TO MDTREF */
                _.Move(WS_WORK_AREAS.W02DTSQL, MDTREF);

                /*" -1115- ELSE */
            }
            else
            {


                /*" -1117- MOVE FATURC-DTREF TO MDTREF. */
                _.Move(FATURC_DTREF, MDTREF);
            }


            /*" -1119- MOVE 'SELECT V0CLIENTE' TO COMANDO. */
            _.Move("SELECT V0CLIENTE", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1124- PERFORM M_2000_INTEGRA_VG_DB_SELECT_4 */

            M_2000_INTEGRA_VG_DB_SELECT_4();

            /*" -1127- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1129- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1130- IF CLIENT-DTNASC-I LESS ZEROES */

            if (CLIENT_DTNASC_I < 00)
            {

                /*" -1131- DISPLAY 'CLIENTE SEM DATA DE NASCIMENTO' */
                _.Display($"CLIENTE SEM DATA DE NASCIMENTO");

                /*" -1133- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1135- PERFORM 2100-CALC-PROP-AUTOM THRU 2100-FIM. */

            M_2100_CALC_PROP_AUTOM(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/


            /*" -1139- IF INDAGE < 0 OR INDOPR < 0 OR INDNUM < 0 OR INDDIG < 0 */

            if (INDAGE < 0 || INDOPR < 0 || INDNUM < 0 || INDDIG < 0)
            {

                /*" -1140- MOVE 0 TO MAGECOBR */
                _.Move(0, MAGECOBR);

                /*" -1141- MOVE 0 TO MNUM-CTA-CORRENTE */
                _.Move(0, MNUM_CTA_CORRENTE);

                /*" -1142- MOVE ' ' TO MDAC-CTA-CORRENTE */
                _.Move(" ", MDAC_CTA_CORRENTE);

                /*" -1143- ELSE */
            }
            else
            {


                /*" -1144- MOVE OPCAOP-AGECTADEB TO MAGECOBR */
                _.Move(OPCAOP_AGECTADEB, MAGECOBR);

                /*" -1145- MOVE OPCAOP-OPRCTADEB TO WS-OPER-SEG */
                _.Move(OPCAOP_OPRCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_OPER_SEG);

                /*" -1146- MOVE OPCAOP-NUMCTADEB TO WS-CTA-SEG */
                _.Move(OPCAOP_NUMCTADEB, WS_WORK_AREAS.WS_CTA_CORRENTE_R.WS_CTA_SEG);

                /*" -1147- MOVE WS-CTA-CORRENTE TO MNUM-CTA-CORRENTE */
                _.Move(WS_WORK_AREAS.WS_CTA_CORRENTE, MNUM_CTA_CORRENTE);

                /*" -1148- MOVE OPCAOP-DIGCTADEB TO W01N0100 */
                _.Move(OPCAOP_DIGCTADEB, WS_WORK_AREAS.W01A0100.W01N0100);

                /*" -1150- MOVE W01A0100 TO MDAC-CTA-CORRENTE. */
                _.Move(WS_WORK_AREAS.W01A0100, MDAC_CTA_CORRENTE);
            }


            /*" -1151- MOVE '2000-INTEGRA-VG           ' TO PARAGRAFO. */
            _.Move("2000-INTEGRA-VG           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1152- COMPUTE MTXAPIP = MTXAPMA / 2. */
            MTXAPIP.Value = MTXAPMA / 2f;

            /*" -1154- COMPUTE MTXAPMA = MTXAPMA - MTXAPIP. */
            MTXAPMA.Value = MTXAPMA - MTXAPIP;

            /*" -1156- PERFORM 2200-MONTA-BENEFICIARIOS THRU 2200-FIM. */

            M_2200_MONTA_BENEFICIARIOS(true);

            M_2200_LOOP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/


            /*" -1157- IF WS-CONT-BENEF EQUAL ZEROS */

            if (WS_WORK_AREAS.WS_CONT_BENEF == 00)
            {

                /*" -1158- MOVE 'S' TO MTPBENEF */
                _.Move("S", MTPBENEF);

                /*" -1159- ELSE */
            }
            else
            {


                /*" -1161- MOVE 'N' TO MTPBENEF. */
                _.Move("N", MTPBENEF);
            }


            /*" -1162- IF COBERP-IMPMORNATU NOT EQUAL 0 */

            if (COBERP_IMPMORNATU != 0)
            {

                /*" -1164- COMPUTE COBERP-IMPMORACID = COBERP-IMPMORACID - COBERP-IMPMORNATU */
                COBERP_IMPMORACID.Value = COBERP_IMPMORACID - COBERP_IMPMORNATU;

                /*" -1166- COMPUTE COBERP-IMPMORACID = COBERP-IMPMORACID - (COBERP-IMPMORNATU * CONDTE-IEA) / 100 */
                COBERP_IMPMORACID.Value = COBERP_IMPMORACID - (COBERP_IMPMORNATU * CONDTE_IEA) / 100f;

                /*" -1169- COMPUTE COBERP-IMPINVPERM = COBERP-IMPINVPERM - (COBERP-IMPMORNATU * CONDTE-IPA) / 100. */
                COBERP_IMPINVPERM.Value = COBERP_IMPINVPERM - (COBERP_IMPMORNATU * CONDTE_IPA) / 100f;
            }


            /*" -1170- MOVE '2000-INTEGRA-VG           ' TO PARAGRAFO. */
            _.Move("2000-INTEGRA-VG           ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1172- MOVE 'INSERT V0MOVIMENTO' TO COMANDO. */
            _.Move("INSERT V0MOVIMENTO", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1249- PERFORM M_2000_INTEGRA_VG_DB_INSERT_1 */

            M_2000_INTEGRA_VG_DB_INSERT_1();

            /*" -1252- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1254- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1255- IF COBERP-VLCUSTAUXF GREATER 0 */

            if (COBERP_VLCUSTAUXF > 0)
            {

                /*" -1257- PERFORM 2300-CONCEDE-SAF THRU 2300-FIM. */

                M_2300_CONCEDE_SAF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2300_FIM*/

            }


            /*" -1258- MOVE 102 TO PROPVA-CODOPER. */
            _.Move(102, PROPVA_CODOPER);

            /*" -1260- MOVE '3' TO PROPVA-SITUACAO. */
            _.Move("3", PROPVA_SITUACAO);

            /*" -1260- PERFORM 2400-GERA-EVENTO THRU 2400-FIM. */

            M_2400_GERA_EVENTO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2400_FIM*/


        }

        [StopWatch]
        /*" M-2000-INTEGRA-VG-DB-SELECT-1 */
        public void M_2000_INTEGRA_VG_DB_SELECT_1()
        {
            /*" -1081- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA INTO :CONDTE-IEA, :CONDTE-IPA FROM SEGUROS.V0CONDTEC WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC. */

            var m_2000_INTEGRA_VG_DB_SELECT_1_Query1 = new M_2000_INTEGRA_VG_DB_SELECT_1_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_2000_INTEGRA_VG_DB_SELECT_1_Query1.Execute(m_2000_INTEGRA_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDTE_IEA, CONDTE_IEA);
                _.Move(executed_1.CONDTE_IPA, CONDTE_IPA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2000_FIM*/

        [StopWatch]
        /*" M-2000-INTEGRA-VG-DB-SELECT-2 */
        public void M_2000_INTEGRA_VG_DB_SELECT_2()
        {
            /*" -1094- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURC-DTREF FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPVA-CODSUBES END-EXEC. */

            var m_2000_INTEGRA_VG_DB_SELECT_2_Query1 = new M_2000_INTEGRA_VG_DB_SELECT_2_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
            };

            var executed_1 = M_2000_INTEGRA_VG_DB_SELECT_2_Query1.Execute(m_2000_INTEGRA_VG_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURC_DTREF, FATURC_DTREF);
            }


        }

        [StopWatch]
        /*" M-2100-CALC-PROP-AUTOM */
        private void M_2100_CALC_PROP_AUTOM(bool isPerform = false)
        {
            /*" -1271- MOVE '2100-CALC-PROP-AUTOM' TO PARAGRAFO. */
            _.Move("2100-CALC-PROP-AUTOM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1273- MOVE 'SELECT V0FONTE' TO COMANDO. */
            _.Move("SELECT V0FONTE", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1278- PERFORM M_2100_CALC_PROP_AUTOM_DB_SELECT_1 */

            M_2100_CALC_PROP_AUTOM_DB_SELECT_1();

            /*" -1281- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1283- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1285- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

            /*" -1287- MOVE 'UPDATE V0FONTE' TO COMANDO. */
            _.Move("UPDATE V0FONTE", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1292- PERFORM M_2100_CALC_PROP_AUTOM_DB_UPDATE_1 */

            M_2100_CALC_PROP_AUTOM_DB_UPDATE_1();

            /*" -1295- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1295- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2100-CALC-PROP-AUTOM-DB-SELECT-1 */
        public void M_2100_CALC_PROP_AUTOM_DB_SELECT_1()
        {
            /*" -1278- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V0FONTE WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_2100_CALC_PROP_AUTOM_DB_SELECT_1_Query1 = new M_2100_CALC_PROP_AUTOM_DB_SELECT_1_Query1()
            {
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            var executed_1 = M_2100_CALC_PROP_AUTOM_DB_SELECT_1_Query1.Execute(m_2100_CALC_PROP_AUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" M-2100-CALC-PROP-AUTOM-DB-UPDATE-1 */
        public void M_2100_CALC_PROP_AUTOM_DB_UPDATE_1()
        {
            /*" -1292- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PROPVA-FONTE END-EXEC. */

            var m_2100_CALC_PROP_AUTOM_DB_UPDATE_1_Update1 = new M_2100_CALC_PROP_AUTOM_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
            };

            M_2100_CALC_PROP_AUTOM_DB_UPDATE_1_Update1.Execute(m_2100_CALC_PROP_AUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-2000-INTEGRA-VG-DB-INSERT-1 */
        public void M_2000_INTEGRA_VG_DB_INSERT_1()
        {
            /*" -1249- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, '1' , :PROPVA-NRCERTIF, ' ' , :MTPINCLUS, :PROPVA-CODCLIEN, 0, 0, 0, 0, :MFAIXA, 'S' , :MTPBENEF, :OPCAOP-PERIPGTO, 12, ' ' , ' ' , :PROPVA-SEXO, 0, ' ' , 1, 1, 104, :MAGECOBR, ' ' , 0, :MNUM-CTA-CORRENTE, :MDAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, :MTXAPMA, :MTXAPIP, 0, 0, 0, :MTXVG, 0, :COBERP-IMPMORNATU, 0, :COBERP-IMPMORACID, 0, :COBERP-IMPINVPERM, 0, 0, 0, 0, 0, :COBERP-IMPDIT, 0, :COBERP-PRMVG, 0, :COBERP-PRMAP, 102, :SISTEMA-DTMOVABE, 0, '1' , :PROPVA-CODUSU, :SISTEMA-DTMOVABE, NULL, NULL, :CLIENT-DTNASC, NULL, :MDTREF, :MDTMOVTO, NULL, NULL) END-EXEC. */

            var m_2000_INTEGRA_VG_DB_INSERT_1_Insert1 = new M_2000_INTEGRA_VG_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                MTPINCLUS = MTPINCLUS.ToString(),
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                MFAIXA = MFAIXA.ToString(),
                MTPBENEF = MTPBENEF.ToString(),
                OPCAOP_PERIPGTO = OPCAOP_PERIPGTO.ToString(),
                PROPVA_SEXO = PROPVA_SEXO.ToString(),
                MAGECOBR = MAGECOBR.ToString(),
                MNUM_CTA_CORRENTE = MNUM_CTA_CORRENTE.ToString(),
                MDAC_CTA_CORRENTE = MDAC_CTA_CORRENTE.ToString(),
                MTXAPMA = MTXAPMA.ToString(),
                MTXAPIP = MTXAPIP.ToString(),
                MTXVG = MTXVG.ToString(),
                COBERP_IMPMORNATU = COBERP_IMPMORNATU.ToString(),
                COBERP_IMPMORACID = COBERP_IMPMORACID.ToString(),
                COBERP_IMPINVPERM = COBERP_IMPINVPERM.ToString(),
                COBERP_IMPDIT = COBERP_IMPDIT.ToString(),
                COBERP_PRMVG = COBERP_PRMVG.ToString(),
                COBERP_PRMAP = COBERP_PRMAP.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                PROPVA_CODUSU = PROPVA_CODUSU.ToString(),
                CLIENT_DTNASC = CLIENT_DTNASC.ToString(),
                MDTREF = MDTREF.ToString(),
                MDTMOVTO = MDTMOVTO.ToString(),
            };

            M_2000_INTEGRA_VG_DB_INSERT_1_Insert1.Execute(m_2000_INTEGRA_VG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" M-2000-INTEGRA-VG-DB-SELECT-3 */
        public void M_2000_INTEGRA_VG_DB_SELECT_3()
        {
            /*" -1104- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURC-DTREF FROM SEGUROS.V0FATURCONT WHERE NUM_APOLICE = :PROPVA-NUM-APOLICE AND COD_SUBGRUPO = 0 END-EXEC */

            var m_2000_INTEGRA_VG_DB_SELECT_3_Query1 = new M_2000_INTEGRA_VG_DB_SELECT_3_Query1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_2000_INTEGRA_VG_DB_SELECT_3_Query1.Execute(m_2000_INTEGRA_VG_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURC_DTREF, FATURC_DTREF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2100_FIM*/

        [StopWatch]
        /*" M-2000-INTEGRA-VG-DB-SELECT-4 */
        public void M_2000_INTEGRA_VG_DB_SELECT_4()
        {
            /*" -1124- EXEC SQL SELECT DATA_NASCIMENTO INTO :CLIENT-DTNASC:CLIENT-DTNASC-I FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :PROPVA-CODCLIEN END-EXEC. */

            var m_2000_INTEGRA_VG_DB_SELECT_4_Query1 = new M_2000_INTEGRA_VG_DB_SELECT_4_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_2000_INTEGRA_VG_DB_SELECT_4_Query1.Execute(m_2000_INTEGRA_VG_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENT_DTNASC, CLIENT_DTNASC);
                _.Move(executed_1.CLIENT_DTNASC_I, CLIENT_DTNASC_I);
            }


        }

        [StopWatch]
        /*" M-2200-MONTA-BENEFICIARIOS */
        private void M_2200_MONTA_BENEFICIARIOS(bool isPerform = false)
        {
            /*" -1307- MOVE '2200-MONTA-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("2200-MONTA-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1309- MOVE PROPVA-NRCERTIF TO PROPVA-NRPROPAZ. */
            _.Move(PROPVA_NRCERTIF, PROPVA_NRPROPAZ);

            /*" -1311- MOVE 'DECLARE CBENEFP' TO COMANDO. */
            _.Move("DECLARE CBENEFP", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1322- PERFORM M_2200_MONTA_BENEFICIARIOS_DB_DECLARE_1 */

            M_2200_MONTA_BENEFICIARIOS_DB_DECLARE_1();

            /*" -1325- MOVE 'OPEN CBENEFP' TO COMANDO. */
            _.Move("OPEN CBENEFP", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1325- PERFORM M_2200_MONTA_BENEFICIARIOS_DB_OPEN_1 */

            M_2200_MONTA_BENEFICIARIOS_DB_OPEN_1();

            /*" -1327- MOVE ZEROS TO WS-CONT-BENEF. */
            _.Move(0, WS_WORK_AREAS.WS_CONT_BENEF);

        }

        [StopWatch]
        /*" M-2200-MONTA-BENEFICIARIOS-DB-OPEN-1 */
        public void M_2200_MONTA_BENEFICIARIOS_DB_OPEN_1()
        {
            /*" -1325- EXEC SQL OPEN CBENEFP END-EXEC. */

            CBENEFP.Open();

        }

        [StopWatch]
        /*" M-2400-GERA-EVENTO-DB-DECLARE-1 */
        public void M_2400_GERA_EVENTO_DB_DECLARE_1()
        {
            /*" -1539- EXEC SQL DECLARE CPLCOM CURSOR FOR SELECT DISTINCT CODPDT FROM SEGUROS.V0PLANCOMISVF WHERE NRCERTIF = :PROPVA-NRCERTIF ORDER BY CODPDT END-EXEC. */
            CPLCOM = new VF0118B_CPLCOM(true);
            string GetQuery_CPLCOM()
            {
                var query = @$"SELECT DISTINCT CODPDT 
							FROM SEGUROS.V0PLANCOMISVF 
							WHERE NRCERTIF = '{PROPVA_NRCERTIF}' 
							ORDER BY CODPDT";

                return query;
            }
            CPLCOM.GetQueryEvent += GetQuery_CPLCOM;

        }

        [StopWatch]
        /*" M-2200-LOOP */
        private void M_2200_LOOP(bool isPerform = false)
        {
            /*" -1333- MOVE 'FETCH CBENEFP' TO COMANDO. */
            _.Move("FETCH CBENEFP", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1338- PERFORM M_2200_LOOP_DB_FETCH_1 */

            M_2200_LOOP_DB_FETCH_1();

            /*" -1341- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1342- MOVE 'CLOSE CBENEFP' TO COMANDO */
                _.Move("CLOSE CBENEFP", WABEND.LOCALIZA_ABEND_1.COMANDO);

                /*" -1342- PERFORM M_2200_LOOP_DB_CLOSE_1 */

                M_2200_LOOP_DB_CLOSE_1();

                /*" -1345- GO TO 2200-FIM. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/ //GOTO
                return;
            }


            /*" -1347- ADD 1 TO WS-CONT-BENEF. */
            WS_WORK_AREAS.WS_CONT_BENEF.Value = WS_WORK_AREAS.WS_CONT_BENEF + 1;

            /*" -1349- MOVE WS-CONT-BENEF TO BENEF-NRBENEF. */
            _.Move(WS_WORK_AREAS.WS_CONT_BENEF, BENEF_NRBENEF);

            /*" -1351- MOVE 'INSERT V0BENEFIPROP' TO COMANDO. */
            _.Move("INSERT V0BENEFIPROP", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1363- PERFORM M_2200_LOOP_DB_INSERT_1 */

            M_2200_LOOP_DB_INSERT_1();

            /*" -1365- GO TO 2200-LOOP. */
            new Task(() => M_2200_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" M-2200-LOOP-DB-FETCH-1 */
        public void M_2200_LOOP_DB_FETCH_1()
        {
            /*" -1338- EXEC SQL FETCH CBENEFP INTO :BENEF-NOMBENEF, :BENEF-GRAUPAR, :BENEF-PCTBENEF END-EXEC. */

            if (CBENEFP.Fetch())
            {
                _.Move(CBENEFP.BENEF_NOMBENEF, BENEF_NOMBENEF);
                _.Move(CBENEFP.BENEF_GRAUPAR, BENEF_GRAUPAR);
                _.Move(CBENEFP.BENEF_PCTBENEF, BENEF_PCTBENEF);
            }

        }

        [StopWatch]
        /*" M-2200-LOOP-DB-CLOSE-1 */
        public void M_2200_LOOP_DB_CLOSE_1()
        {
            /*" -1342- EXEC SQL CLOSE CBENEFP END-EXEC */

            CBENEFP.Close();

        }

        [StopWatch]
        /*" M-2200-LOOP-DB-INSERT-1 */
        public void M_2200_LOOP_DB_INSERT_1()
        {
            /*" -1363- EXEC SQL INSERT INTO SEGUROS.V0BENEFIPROP VALUES (:PROPVA-NUM-APOLICE, :PROPVA-CODSUBES, :PROPVA-FONTE, :FONTE-PROPAUTOM, :BENEF-NRBENEF, :BENEF-NOMBENEF, :BENEF-GRAUPAR, :BENEF-PCTBENEF, 'VF0118B' , NULL) END-EXEC. */

            var m_2200_LOOP_DB_INSERT_1_Insert1 = new M_2200_LOOP_DB_INSERT_1_Insert1()
            {
                PROPVA_NUM_APOLICE = PROPVA_NUM_APOLICE.ToString(),
                PROPVA_CODSUBES = PROPVA_CODSUBES.ToString(),
                PROPVA_FONTE = PROPVA_FONTE.ToString(),
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                BENEF_NRBENEF = BENEF_NRBENEF.ToString(),
                BENEF_NOMBENEF = BENEF_NOMBENEF.ToString(),
                BENEF_GRAUPAR = BENEF_GRAUPAR.ToString(),
                BENEF_PCTBENEF = BENEF_PCTBENEF.ToString(),
            };

            M_2200_LOOP_DB_INSERT_1_Insert1.Execute(m_2200_LOOP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2200_FIM*/

        [StopWatch]
        /*" M-2300-CONCEDE-SAF */
        private void M_2300_CONCEDE_SAF(bool isPerform = false)
        {
            /*" -1376- MOVE '2300-CONCEDE-SAF ' TO COMANDO. */
            _.Move("2300-CONCEDE-SAF ", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1378- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1384- PERFORM M_2300_CONCEDE_SAF_DB_SELECT_1 */

            M_2300_CONCEDE_SAF_DB_SELECT_1();

            /*" -1388- MOVE MDTMOVTO TO SISTEMA-DTINISAF. */
            _.Move(MDTMOVTO, SISTEMA_DTINISAF);

            /*" -1389- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1390- IF SAFCOB-DTINIVIG > SISTEMA-DTINISAF */

                if (SAFCOB_DTINIVIG > SISTEMA_DTINISAF)
                {

                    /*" -1391- PERFORM 2310-ELIMINA-SAF THRU 2310-FIM */

                    M_2310_ELIMINA_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2310_FIM*/


                    /*" -1392- PERFORM 2320-INCLUI-SAF THRU 2320-FIM */

                    M_2320_INCLUI_SAF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2320_FIM*/


                    /*" -1393- END-IF */
                }


                /*" -1394- ELSE */
            }
            else
            {


                /*" -1396- PERFORM 2320-INCLUI-SAF THRU 2320-FIM. */

                M_2320_INCLUI_SAF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2320_FIM*/

            }


            /*" -1397- IF WS-TEM-RCAP EQUAL 0 */

            if (WS_WORK_AREAS.WS_TEM_RCAP == 0)
            {

                /*" -1398- GO TO 2300-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2300_FIM*/ //GOTO
                return;

                /*" -1399- ELSE */
            }
            else
            {


                /*" -1400- IF RCAP-SITUACAO EQUAL '2' */

                if (RCAP_SITUACAO == "2")
                {

                    /*" -1402- GO TO 2300-FIM. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2300_FIM*/ //GOTO
                    return;
                }

            }


            /*" -1403- MOVE MDTMOVTO TO W01DTSQL */
            _.Move(MDTMOVTO, WS_WORK_AREAS.W01DTSQL);

            /*" -1404- MOVE 01 TO W01DDSQL. */
            _.Move(01, WS_WORK_AREAS.W01DTSQL.W01DDSQL);

            /*" -1406- MOVE W01DTSQL TO REPSAF-DTREF. */
            _.Move(WS_WORK_AREAS.W01DTSQL, REPSAF_DTREF);

            /*" -1407- MOVE '2300-CONCEDE-SAF          ' TO PARAGRAFO. */
            _.Move("2300-CONCEDE-SAF          ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1409- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1416- PERFORM M_2300_CONCEDE_SAF_DB_SELECT_2 */

            M_2300_CONCEDE_SAF_DB_SELECT_2();

            /*" -1419- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1419- PERFORM 2330-INCLUI-REPASSE-SAF THRU 2330-FIM. */

                M_2330_INCLUI_REPASSE_SAF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2330_FIM*/

            }


        }

        [StopWatch]
        /*" M-2300-CONCEDE-SAF-DB-SELECT-1 */
        public void M_2300_CONCEDE_SAF_DB_SELECT_1()
        {
            /*" -1384- EXEC SQL SELECT DTINIVIG INTO :SAFCOB-DTINIVIG FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var m_2300_CONCEDE_SAF_DB_SELECT_1_Query1 = new M_2300_CONCEDE_SAF_DB_SELECT_1_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            var executed_1 = M_2300_CONCEDE_SAF_DB_SELECT_1_Query1.Execute(m_2300_CONCEDE_SAF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SAFCOB_DTINIVIG, SAFCOB_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2300_FIM*/

        [StopWatch]
        /*" M-2300-CONCEDE-SAF-DB-SELECT-2 */
        public void M_2300_CONCEDE_SAF_DB_SELECT_2()
        {
            /*" -1416- EXEC SQL SELECT DTREF INTO :REPSAF-DTREF FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :PROPVA-CODCLIEN AND DTREF = :REPSAF-DTREF AND CODOPER = 1100 END-EXEC. */

            var m_2300_CONCEDE_SAF_DB_SELECT_2_Query1 = new M_2300_CONCEDE_SAF_DB_SELECT_2_Query1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
            };

            var executed_1 = M_2300_CONCEDE_SAF_DB_SELECT_2_Query1.Execute(m_2300_CONCEDE_SAF_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.REPSAF_DTREF, REPSAF_DTREF);
            }


        }

        [StopWatch]
        /*" M-2310-ELIMINA-SAF */
        private void M_2310_ELIMINA_SAF(bool isPerform = false)
        {
            /*" -1430- MOVE '2310-ELIMINA-SAF' TO PARAGRAFO. */
            _.Move("2310-ELIMINA-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1432- MOVE 'DELETE V0SAFCOBER' TO COMANDO. */
            _.Move("DELETE V0SAFCOBER", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1435- PERFORM M_2310_ELIMINA_SAF_DB_DELETE_1 */

            M_2310_ELIMINA_SAF_DB_DELETE_1();

            /*" -1438- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1438- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2310-ELIMINA-SAF-DB-DELETE-1 */
        public void M_2310_ELIMINA_SAF_DB_DELETE_1()
        {
            /*" -1435- EXEC SQL DELETE FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :PROPVA-CODCLIEN END-EXEC. */

            var m_2310_ELIMINA_SAF_DB_DELETE_1_Delete1 = new M_2310_ELIMINA_SAF_DB_DELETE_1_Delete1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
            };

            M_2310_ELIMINA_SAF_DB_DELETE_1_Delete1.Execute(m_2310_ELIMINA_SAF_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2310_FIM*/

        [StopWatch]
        /*" M-2320-INCLUI-SAF */
        private void M_2320_INCLUI_SAF(bool isPerform = false)
        {
            /*" -1449- MOVE '2320-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("2320-INCLUI-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1451- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1463- PERFORM M_2320_INCLUI_SAF_DB_INSERT_1 */

            M_2320_INCLUI_SAF_DB_INSERT_1();

            /*" -1466- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1466- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2320-INCLUI-SAF-DB-INSERT-1 */
        public void M_2320_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -1463- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:PROPVA-CODCLIEN, :SISTEMA-DTINISAF, '9999-12-31' , :COBERP-IMPSEGAUXF, :COBERP-VLCUSTAUXF, :PROPVA-NRCERTIF, :PROPVA-OCORHIST, '0' , 'VF0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_2320_INCLUI_SAF_DB_INSERT_1_Insert1 = new M_2320_INCLUI_SAF_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                SISTEMA_DTINISAF = SISTEMA_DTINISAF.ToString(),
                COBERP_IMPSEGAUXF = COBERP_IMPSEGAUXF.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                PROPVA_OCORHIST = PROPVA_OCORHIST.ToString(),
            };

            M_2320_INCLUI_SAF_DB_INSERT_1_Insert1.Execute(m_2320_INCLUI_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2320_FIM*/

        [StopWatch]
        /*" M-2330-INCLUI-REPASSE-SAF */
        private void M_2330_INCLUI_REPASSE_SAF(bool isPerform = false)
        {
            /*" -1477- MOVE '2330-INCLUI-REPASE-SAF' TO PARAGRAFO. */
            _.Move("2330-INCLUI-REPASE-SAF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1479- MOVE 'INSERT V0HISTREPSAF 102' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF 102", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1495- PERFORM M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1 */

            M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1();

            /*" -1498- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1500- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1502- MOVE 'INSERT V0HISTREPSAF 1100' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF 1100", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1518- PERFORM M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2 */

            M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2();

            /*" -1521- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1521- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-2330-INCLUI-REPASSE-SAF-DB-INSERT-1 */
        public void M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1()
        {
            /*" -1495- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:PROPVA-CODCLIEN, :REPSAF-DTREF, :PROPVA-NRCERTIF, 1, 0, :COBERP-VLCUSTAUXF, 102, '0' , '0' , 0, 0, 'VF0118B' , CURRENT TIMESTAMP, :SISTEMA-DTINISAF:VIND-DTMOVTO) END-EXEC. */

            var m_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1 = new M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                SISTEMA_DTINISAF = SISTEMA_DTINISAF.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1.Execute(m_2330_INCLUI_REPASSE_SAF_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2330_FIM*/

        [StopWatch]
        /*" M-2330-INCLUI-REPASSE-SAF-DB-INSERT-2 */
        public void M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2()
        {
            /*" -1518- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:PROPVA-CODCLIEN, :REPSAF-DTREF, :PROPVA-NRCERTIF, 1, 0, :COBERP-VLCUSTAUXF, 1100, '0' , '0' , 0, 0, 'VF0118B' , CURRENT TIMESTAMP, :SISTEMA-DTINISAF:VIND-DTMOVTO) END-EXEC. */

            var m_2330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1 = new M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1()
            {
                PROPVA_CODCLIEN = PROPVA_CODCLIEN.ToString(),
                REPSAF_DTREF = REPSAF_DTREF.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                COBERP_VLCUSTAUXF = COBERP_VLCUSTAUXF.ToString(),
                SISTEMA_DTINISAF = SISTEMA_DTINISAF.ToString(),
                VIND_DTMOVTO = VIND_DTMOVTO.ToString(),
            };

            M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1.Execute(m_2330_INCLUI_REPASSE_SAF_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" M-2400-GERA-EVENTO */
        private void M_2400_GERA_EVENTO(bool isPerform = false)
        {
            /*" -1533- MOVE '2400-GERA-EVENTO' TO PARAGRAFO. */
            _.Move("2400-GERA-EVENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1539- PERFORM M_2400_GERA_EVENTO_DB_DECLARE_1 */

            M_2400_GERA_EVENTO_DB_DECLARE_1();

            /*" -1542- MOVE 'OPEN CPLCOM' TO COMANDO. */
            _.Move("OPEN CPLCOM", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1542- PERFORM M_2400_GERA_EVENTO_DB_OPEN_1 */

            M_2400_GERA_EVENTO_DB_OPEN_1();

            /*" -1545- MOVE 0 TO WS-EOP. */
            _.Move(0, WS_WORK_AREAS.WS_EOP);

            /*" -1547- PERFORM 2440-FETCH THRU 2440-FIM. */

            M_2440_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2440_FIM*/


            /*" -1550- PERFORM 2420-GERA-EVENTO THRU 2420-FIM UNTIL WS-EOP = 1. */

            while (!(WS_WORK_AREAS.WS_EOP == 1))
            {

                M_2420_GERA_EVENTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2420_FIM*/

            }

            /*" -1551- MOVE 'CLOSE CPLCOM' TO COMANDO. */
            _.Move("CLOSE CPLCOM", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1551- PERFORM M_2400_GERA_EVENTO_DB_CLOSE_1 */

            M_2400_GERA_EVENTO_DB_CLOSE_1();

        }

        [StopWatch]
        /*" M-2400-GERA-EVENTO-DB-OPEN-1 */
        public void M_2400_GERA_EVENTO_DB_OPEN_1()
        {
            /*" -1542- EXEC SQL OPEN CPLCOM END-EXEC. */

            CPLCOM.Open();

        }

        [StopWatch]
        /*" M-2400-GERA-EVENTO-DB-CLOSE-1 */
        public void M_2400_GERA_EVENTO_DB_CLOSE_1()
        {
            /*" -1551- EXEC SQL CLOSE CPLCOM END-EXEC. */

            CPLCOM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2400_FIM*/

        [StopWatch]
        /*" M-2420-GERA-EVENTO */
        private void M_2420_GERA_EVENTO(bool isPerform = false)
        {
            /*" -1563- MOVE '2420-GERA-EVENTO' TO PARAGRAFO. */
            _.Move("2420-GERA-EVENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1565- MOVE 'SELECT V0PRODUTORVF' TO COMANDO. */
            _.Move("SELECT V0PRODUTORVF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1570- PERFORM M_2420_GERA_EVENTO_DB_SELECT_1 */

            M_2420_GERA_EVENTO_DB_SELECT_1();

            /*" -1573- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1575- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1577- ADD 1 TO PDTVF-OCORHIST. */
            PDTVF_OCORHIST.Value = PDTVF_OCORHIST + 1;

            /*" -1579- MOVE 'UPDATE V0PRODUTORVF' TO COMANDO. */
            _.Move("UPDATE V0PRODUTORVF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1583- PERFORM M_2420_GERA_EVENTO_DB_UPDATE_1 */

            M_2420_GERA_EVENTO_DB_UPDATE_1();

            /*" -1586- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1588- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


            /*" -1590- MOVE 'INSERT V0EVENTOSVF' TO COMANDO. */
            _.Move("INSERT V0EVENTOSVF", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1606- PERFORM M_2420_GERA_EVENTO_DB_INSERT_1 */

            M_2420_GERA_EVENTO_DB_INSERT_1();

            /*" -1608- PERFORM 2440-FETCH THRU 2440-FIM. */

            M_2440_FETCH(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2440_FIM*/


        }

        [StopWatch]
        /*" M-2420-GERA-EVENTO-DB-SELECT-1 */
        public void M_2420_GERA_EVENTO_DB_SELECT_1()
        {
            /*" -1570- EXEC SQL SELECT OCORHIST INTO :PDTVF-OCORHIST FROM SEGUROS.V0PRODUTORVF WHERE CODPDT = :PLCOM-CODPDT END-EXEC. */

            var m_2420_GERA_EVENTO_DB_SELECT_1_Query1 = new M_2420_GERA_EVENTO_DB_SELECT_1_Query1()
            {
                PLCOM_CODPDT = PLCOM_CODPDT.ToString(),
            };

            var executed_1 = M_2420_GERA_EVENTO_DB_SELECT_1_Query1.Execute(m_2420_GERA_EVENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PDTVF_OCORHIST, PDTVF_OCORHIST);
            }


        }

        [StopWatch]
        /*" M-2420-GERA-EVENTO-DB-UPDATE-1 */
        public void M_2420_GERA_EVENTO_DB_UPDATE_1()
        {
            /*" -1583- EXEC SQL UPDATE SEGUROS.V0PRODUTORVF SET OCORHIST = :PDTVF-OCORHIST WHERE CODPDT = :PLCOM-CODPDT END-EXEC. */

            var m_2420_GERA_EVENTO_DB_UPDATE_1_Update1 = new M_2420_GERA_EVENTO_DB_UPDATE_1_Update1()
            {
                PDTVF_OCORHIST = PDTVF_OCORHIST.ToString(),
                PLCOM_CODPDT = PLCOM_CODPDT.ToString(),
            };

            M_2420_GERA_EVENTO_DB_UPDATE_1_Update1.Execute(m_2420_GERA_EVENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-2420-GERA-EVENTO-DB-INSERT-1 */
        public void M_2420_GERA_EVENTO_DB_INSERT_1()
        {
            /*" -1606- EXEC SQL INSERT INTO SEGUROS.V0EVENTOSVF VALUES (:PLCOM-CODPDT, :PDTVF-OCORHIST, 0, :PROPVA-NRCERTIF, 1, 3, 102, :SISTEMA-DTMOVABE, :SISTEMA-DTMOVABE, '0' , :COBERP-VLPREMIO, 0, 'VF0118B' , CURRENT TIMESTAMP) END-EXEC. */

            var m_2420_GERA_EVENTO_DB_INSERT_1_Insert1 = new M_2420_GERA_EVENTO_DB_INSERT_1_Insert1()
            {
                PLCOM_CODPDT = PLCOM_CODPDT.ToString(),
                PDTVF_OCORHIST = PDTVF_OCORHIST.ToString(),
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                SISTEMA_DTMOVABE = SISTEMA_DTMOVABE.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
            };

            M_2420_GERA_EVENTO_DB_INSERT_1_Insert1.Execute(m_2420_GERA_EVENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2420_FIM*/

        [StopWatch]
        /*" M-2440-FETCH */
        private void M_2440_FETCH(bool isPerform = false)
        {
            /*" -1619- MOVE '2440-FETCH' TO PARAGRAFO. */
            _.Move("2440-FETCH", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1621- MOVE 'FETCH CLPCOM' TO COMANDO. */
            _.Move("FETCH CLPCOM", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1624- PERFORM M_2440_FETCH_DB_FETCH_1 */

            M_2440_FETCH_DB_FETCH_1();

            /*" -1627- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1627- MOVE 1 TO WS-EOP. */
                _.Move(1, WS_WORK_AREAS.WS_EOP);
            }


        }

        [StopWatch]
        /*" M-2440-FETCH-DB-FETCH-1 */
        public void M_2440_FETCH_DB_FETCH_1()
        {
            /*" -1624- EXEC SQL FETCH CPLCOM INTO :PLCOM-CODPDT END-EXEC. */

            if (CPLCOM.Fetch())
            {
                _.Move(CPLCOM.PLCOM_CODPDT, PLCOM_CODPDT);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_2440_FIM*/

        [StopWatch]
        /*" M-8700-GERA-DEBITO */
        private void M_8700_GERA_DEBITO(bool isPerform = false)
        {
            /*" -1638- MOVE '8700-GERA-DEBITO' TO PARAGRAFO. */
            _.Move("8700-GERA-DEBITO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1640- MOVE 'INSERT V0HISTCONTAVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTAVA", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1681- PERFORM M_8700_GERA_DEBITO_DB_INSERT_1 */

            M_8700_GERA_DEBITO_DB_INSERT_1();

            /*" -1684- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1684- GO TO 9999-ERRO. */

                M_9999_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-8700-GERA-DEBITO-DB-INSERT-1 */
        public void M_8700_GERA_DEBITO_DB_INSERT_1()
        {
            /*" -1681- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:PROPVA-NRCERTIF, 1, 1, :OPCAOP-AGECTADEB, :OPCAOP-OPRCTADEB, :OPCAOP-NUMCTADEB, :OPCAOP-DIGCTADEB, :PROPVA-DTVENCTO, :COBERP-VLPREMIO, '0' , '1' , CURRENT TIMESTAMP, 0, :V0CONV-CODCONV, NULL, NULL, NULL, NULL, NULL, 0) END-EXEC. */

            var m_8700_GERA_DEBITO_DB_INSERT_1_Insert1 = new M_8700_GERA_DEBITO_DB_INSERT_1_Insert1()
            {
                PROPVA_NRCERTIF = PROPVA_NRCERTIF.ToString(),
                OPCAOP_AGECTADEB = OPCAOP_AGECTADEB.ToString(),
                OPCAOP_OPRCTADEB = OPCAOP_OPRCTADEB.ToString(),
                OPCAOP_NUMCTADEB = OPCAOP_NUMCTADEB.ToString(),
                OPCAOP_DIGCTADEB = OPCAOP_DIGCTADEB.ToString(),
                PROPVA_DTVENCTO = PROPVA_DTVENCTO.ToString(),
                COBERP_VLPREMIO = COBERP_VLPREMIO.ToString(),
                V0CONV_CODCONV = V0CONV_CODCONV.ToString(),
            };

            M_8700_GERA_DEBITO_DB_INSERT_1_Insert1.Execute(m_8700_GERA_DEBITO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_8700_FIM*/

        [StopWatch]
        /*" M-9000-FINALIZA */
        private void M_9000_FINALIZA(bool isPerform = false)
        {
            /*" -1695- MOVE '9000-FINALIZA' TO PARAGRAFO. */
            _.Move("9000-FINALIZA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1696- MOVE 'COMMIT WORK' TO COMANDO. */
            _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1696- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1699- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1700- DISPLAY 'LIDOS ................ ' AC-LIDOS. */
            _.Display($"LIDOS ................ {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1701- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1702- DISPLAY 'INTEGRADOS ........... ' AC-INTEGRADOS. */
            _.Display($"INTEGRADOS ........... {WS_WORK_AREAS.AC_INTEGRADOS}");

            /*" -1703- DISPLAY 'PRIMEIRA GERADA ...... ' AC-PRIMEIRA. */
            _.Display($"PRIMEIRA GERADA ...... {WS_WORK_AREAS.AC_PRIMEIRA}");

            /*" -1704- DISPLAY 'LANCAMENTOS DEBITO ... ' AC-DEBITO. */
            _.Display($"LANCAMENTOS DEBITO ... {WS_WORK_AREAS.AC_DEBITO}");

            /*" -1705- DISPLAY 'CARNES ............... ' AC-CARNE. */
            _.Display($"CARNES ............... {WS_WORK_AREAS.AC_CARNE}");

            /*" -1706- DISPLAY ' ' */
            _.Display($" ");

            /*" -1706- DISPLAY '*** VF0118B *** TERMINO NORMAL' . */
            _.Display($"*** VF0118B *** TERMINO NORMAL");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_FIM*/

        [StopWatch]
        /*" M-9999-ERRO */
        private void M_9999_ERRO(bool isPerform = false)
        {
            /*" -1717- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1718- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1719- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1720- MOVE SQLCODE TO WSQLCODE3. */
            _.Move(DB.SQLCODE, WS_WORK_AREAS.WSQLCODE3);

            /*" -1722- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1724- DISPLAY '*** VF0118B *** ROLLBACK EM ANDAMENTO ...' . */
            _.Display($"*** VF0118B *** ROLLBACK EM ANDAMENTO ...");

            /*" -1724- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1727- MOVE '9999-ERRO' TO PARAGRAFO. */
            _.Move("9999-ERRO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1728- MOVE 'ROLLBACK WORK' TO COMANDO. */
            _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_1.COMANDO);

            /*" -1728- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1731- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1732- DISPLAY 'LIDOS ................ ' AC-LIDOS. */
            _.Display($"LIDOS ................ {WS_WORK_AREAS.AC_LIDOS}");

            /*" -1734- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1735- DISPLAY 'PROPOSTA : ' PROPVA-NRCERTIF. */
            _.Display($"PROPOSTA : {PROPVA_NRCERTIF}");

            /*" -1736- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1738- DISPLAY '*** VF0118B *** ERRO DE EXECUCAO' . */
            _.Display($"*** VF0118B *** ERRO DE EXECUCAO");

            /*" -1739- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1739- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}